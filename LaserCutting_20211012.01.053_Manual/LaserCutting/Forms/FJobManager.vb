Imports System.Reflection
Imports System.Threading
Imports System.IO
Imports PseudoDevice
Imports Timer

Public Class FJobManager
    Private m_ShowRuler As Boolean
    Private m_Lighting As Boolean = False
    Private m_DragNode As TreeNode = Nothing
    Private m_TempDropNode As TreeNode = Nothing
    Private m_ClickNode As TreeNode = Nothing
    Private m_SelectedNodes As ArrayList = New ArrayList()
    Private m_JobList As ArrayList = New ArrayList()
    Private m_CurProject As CProject
    Private m_ListJob As CListJob
    Private m_ListJobTmp As CListJob
    Private m_Param As CParameter
    Private m_OldParam As CParameter
    Private m_FeederRecipeSelected As Integer = -1
    Private m_LaserRecipeSelected As Integer = -1
    Private m_SolderingTime As CSolderingTime
    Public m_Acquist As VisionSystem.CAcquisition
    Private m_RulerColor As Color
    Private m_Ruler As CRuler
    Private m_Motion As CMotion
    Private m_Timer As CHighResolutionTimer
    Private m_Laser As LaserSystem.CLaserCoherentSolder60W
    Private m_DA As CDAQ
    Private m_LaserAperture As CLaserAperture
    Private m_ShowScale As Double = 0.001
    Private m_FeederAccScale As Double = 0.1
    Private m_MaxLevel As Integer = 100

    Public ReadOnly Property ShowRuler As Boolean
        Get
            Return m_ShowRuler
        End Get
    End Property
    Private Const MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\"
    Public Const MCS_PRODUCT_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\User\Product"
    Public Sub New(ByRef pProject As CProject, ByRef pListJob As CListJob, ByRef pParam As CParameter, ByVal pRuler As CRuler, ByRef pAcquist As VisionSystem.CAcquisition, ByRef pMotion As CMotion, ByRef pTimer As CHighResolutionTimer, ByRef pLaser As LaserSystem.CLaserCoherentSolder60W, ByRef pDA As CDAQ)

        Try
            m_DA = pDA
            If (pListJob Is Nothing) Then
                pListJob = New CListJob()
            End If
            If (pProject Is Nothing) Then
                FMessageBox.Show("No project yet." & vbCrLf & "(尚無項目。)", "Job manager message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Me.Close()
            End If
            If (pParam Is Nothing) Then
                pParam = New CParameter(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
            End If
            If (pAcquist IsNot Nothing) Then
                m_Acquist = pAcquist
            Else
                m_Acquist = New VisionSystem.CAcquisition(0)
            End If

            If (pTimer IsNot Nothing) Then
                m_Timer = pTimer
            Else
                m_Timer = New CHighResolutionTimer
            End If

            If Not (pMotion Is Nothing) Then m_Motion = pMotion

            If Not (pLaser Is Nothing) Then m_Laser = pLaser

            If m_LaserAperture Is Nothing Then m_LaserAperture = New CLaserAperture()
            m_Param = pParam
            m_ListJob = pListJob
            m_ListJobTmp = pListJob.Clone()
            m_CurProject = pProject
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            InitDefaultValue()
            TrackBar_ChangedValue(tbPower0, Nothing)
            TrackBar_ChangedValue(tbPower1, Nothing)
            TrackBar_ChangedValue(tbPower2, Nothing)
            TrackBar_ChangedValue(tbPower3, Nothing)
            TrackBar_ChangedValue(tbPower4, Nothing)
            TrackBar_ChangedValue(tbPower5, Nothing)
            TrackBar_ChangedValue(tbPower6, Nothing)
            TrackBar_ChangedValue(tbPower7, Nothing)
            TrackBar_ChangedValue(tbPower8, Nothing)
            TrackBar_ChangedValue(tbSpeed, Nothing)

            If (pRuler Is Nothing) Then
                m_Ruler = New CRuler(grbCamera)
            Else
                m_Ruler = pRuler
                m_Ruler.Parent = grbCamera
            End If

            m_RulerColor = m_Ruler.Color
            ImageDisplay1.StartLive(0, m_Acquist)
            m_LaserAperture.SetZero(m_Param.ZeroNumber)
            m_LaserAperture.Open()
            Exit Sub
            If (m_LaserAperture.LastError <> "") Then
                FMessageBox.ShowError("Cannot connect to Laser Aperture", "Error change UI", False)
                Me.Close()
            End If
            TimerWorkholderValue.Enabled = True
        Catch ex As Exception
            FMessageBox.ShowError("Error when load Job Manager UI", "Error change UI", True, ex)
            Me.Close()
        End Try
    End Sub
    Private Sub InitDefaultValue()
        Dim Fload As FLoading = New FLoading("Loading project...")
        Fload.StartPosition = FormStartPosition.CenterScreen
        Fload.Show()
        ShowListJobToTreeView()
        Fload.Percent = 25

        rbFeederOpt0.Checked = True
        rbFeederOpt_Click(rbFeederOpt0, Nothing)
        Fload.Percent = 50

        rbLaserOpt0.Checked = True
        rbLaserOpt_Click(rbLaserOpt0, Nothing)
        Fload.Percent = 75

        m_OldParam = m_Param.Clone(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
        Fload.Percent = 100
        Fload.Close()
        Fload.Dispose()

    End Sub
    Private Function AddSubJob(ByVal joblist As CListJob, ByRef maxID As Integer) As List(Of TreeNode)
        Dim res As List(Of TreeNode) = New List(Of TreeNode)
        For i = 0 To joblist.Count - 1
            Dim node As TreeNode = New TreeNode()
            node.Tag = joblist.GetJob(i)
            If (joblist.GetJob(i).ID > maxID) Then
                maxID = joblist.GetJob(i).ID
            End If
            node.Nodes.AddRange(AddSubJob(joblist.GetJob(i).ListJob, maxID).ToArray())
            FormatNode(node)
            res.Add(node)
        Next
        Return res
    End Function
    Private Sub ShowListJobToTreeView()
        tvJobs.Nodes.Clear()
        tvJobs.Nodes.Add(New TreeNode(m_CurProject.Key))
        FormatNode(tvJobs.Nodes(0))
        Dim maxID As Integer = 0
        For i = 0 To m_ListJob.Count - 1
            Dim node As TreeNode = New TreeNode()
            node.Tag = m_ListJob.GetJob(i)
            If (m_ListJob.GetJob(i).ID > maxID) Then
                maxID = m_ListJob.GetJob(i).ID
            End If
            node.Nodes.AddRange(AddSubJob(m_ListJob.GetJob(i).ListJob, maxID).ToArray())
            tvJobs.Nodes(0).Nodes.Add(node)
            FormatNode(node)
        Next
        CJobObject.CurrentID = maxID
        tvJobs.ExpandAll()
        pgJobProperty.SelectedObject = Nothing
        pgJobProperty.ExpandAllGridItems()
    End Sub

    Private Sub ButtonChangeIcon_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFeedCounterClockwise.MouseEnter, btnFeedClockwise.MouseEnter, btnJobZ.MouseEnter, Button49.MouseEnter, Button45.MouseEnter, Button46.MouseEnter, Button47.MouseEnter, Button48.MouseEnter, Button44.MouseEnter, Button43.MouseEnter, Button42.MouseEnter, Button41.MouseEnter, Button40.MouseEnter, btnPositionAdd.MouseEnter, Button58.MouseEnter, Button54.MouseEnter, Button55.MouseEnter, Button56.MouseEnter, Button57.MouseEnter, Button53.MouseEnter, Button52.MouseEnter, Button51.MouseEnter, Button50.MouseEnter, Button39.MouseEnter, btnPositionMinus.MouseEnter, btnResetRobotAlarm.MouseEnter
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove2
            Case btnFeedClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd2
            Case btnJobZ.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jobz2
            Case Button49.Name, Button45.Name, Button46.Name, Button47.Name, Button48.Name, Button44.Name, Button43.Name, Button42.Name, Button41.Name, Button40.Name, btnPositionAdd.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.plus2
            Case Button58.Name, Button54.Name, Button55.Name, Button56.Name, Button57.Name, Button53.Name, Button52.Name, Button51.Name, Button50.Name, Button39.Name, btnPositionMinus.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.subtract2

        End Select
    End Sub

    Private Sub ButtonChangeIcon_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFeedCounterClockwise.MouseLeave, btnFeedClockwise.MouseLeave, btnJobZ.MouseLeave, Button49.MouseLeave, Button45.MouseLeave, Button46.MouseLeave, Button47.MouseLeave, Button48.MouseLeave, Button44.MouseLeave, Button43.MouseLeave, Button42.MouseLeave, Button41.MouseLeave, Button40.MouseLeave, btnPositionAdd.MouseLeave, Button58.MouseLeave, Button54.MouseLeave, Button55.MouseLeave, Button56.MouseLeave, Button57.MouseLeave, Button53.MouseLeave, Button52.MouseLeave, Button51.MouseLeave, Button50.MouseLeave, Button39.MouseLeave, btnPositionMinus.MouseLeave, btnResetRobotAlarm.MouseLeave
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name
                btnFeedCounterClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove
            Case btnFeedClockwise.Name
                btnFeedClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd
            Case btnJobZ.Name
                btnJobZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jobz
            Case Button49.Name, Button45.Name, Button46.Name, Button47.Name, Button48.Name, Button44.Name, Button43.Name, Button42.Name, Button41.Name, Button40.Name, btnPositionAdd.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.plus
            Case Button58.Name, Button54.Name, Button55.Name, Button56.Name, Button57.Name, Button53.Name, Button52.Name, Button51.Name, Button50.Name, Button39.Name, btnPositionMinus.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.subtract

        End Select
    End Sub
    Private m_FeedValueAdd As Double = 10
    Private Sub ButtonChangeIcon_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnFeedCounterClockwise.MouseDown, btnFeedClockwise.MouseDown, btnJobZ.MouseDown, Button49.MouseDown, Button45.MouseDown, Button46.MouseDown, Button47.MouseDown, Button48.MouseDown, Button44.MouseDown, Button43.MouseDown, Button42.MouseDown, Button41.MouseDown, Button40.MouseDown, btnPositionAdd.MouseDown, Button58.MouseDown, Button54.MouseDown, Button55.MouseDown, Button56.MouseDown, Button57.MouseDown, Button53.MouseDown, Button52.MouseDown, Button51.MouseDown, Button50.MouseDown, Button39.MouseDown, btnPositionMinus.MouseDown, btnResetRobotAlarm.MouseDown, btnMoveToReadyPosition.MouseDown
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name
                btnFeedCounterClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove3
            Case btnFeedClockwise.Name
                btnFeedClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd3
            Case btnJobZ.Name
                btnJobZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jobz3
            Case Button49.Name, Button45.Name, Button46.Name, Button47.Name, Button48.Name, Button44.Name, Button43.Name, Button42.Name, Button41.Name, Button40.Name, btnPositionAdd.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.plus3
            Case Button58.Name, Button54.Name, Button55.Name, Button56.Name, Button57.Name, Button53.Name, Button52.Name, Button51.Name, Button50.Name, Button39.Name, btnPositionMinus.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.subtract3
            Case btnResetRobotAlarm.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.roll3
            Case btnMoveToReadyPosition.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.home3
        End Select

        'btnFeedCounterClockwise
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnFeedClockwise.Name
                If m_IsMoving = False Then
                    m_IsMoving = True
                    m_WorkholderXMoveOK = True
                    Select Case btn.Name
                        Case btnFeedCounterClockwise.Name
                            m_FeedValueAdd = Math.Abs(m_FeedValueAdd)
                        Case btnFeedClockwise.Name
                            m_FeedValueAdd = -1 * Math.Abs(m_FeedValueAdd)
                    End Select
                    Try
                        'Dim idx As Integer
                        Dim axisID As enumAxis
                        Dim target As Double
                        Dim rStatus As enumMotionFlag
                        'Dim quadrant As Integer
                        'Dim cylStatus2 As enumCylSts
                        axisID = enumAxis.FeederZ
                        m_Motion.SetPositionOffset(axisID, 0)

                        Dim pSpeed As Double
                        Try
                            pSpeed = CDbl(txtSpeed.Text) / 100
                        Catch ex As Exception

                        End Try
                        If pSpeed >= 1 Then
                            pSpeed = 1
                        ElseIf pSpeed <= 0 Then
                            pSpeed = 0.1
                        End If

                        If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                            If m_WorkholderXMoveOK = True Then
                                m_WorkholderXMoveOK = False
                                Call m_Motion.GetCmd(axisID, target)
                                If m_FeedValueAdd > 0 Then
                                    target = m_Motion.SWMax(axisID)
                                Else
                                    target = m_Motion.SWMin(axisID)
                                End If
                                Do
                                    Call System.Windows.Forms.Application.DoEvents()
                                    m_Motion.IsExternalParameters(axisID) = False
                                    Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                                    If rStatus = enumMotionFlag.eSent Then
                                        Exit Do
                                    ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                                        Exit Do
                                    End If
                                Loop
                            End If
                        End If
                    Catch ex As Exception

                    End Try
                End If
        End Select

    End Sub

    Private Sub ButtonChangeIcon_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnFeedCounterClockwise.MouseUp, btnFeedClockwise.MouseUp, btnJobZ.MouseUp, Button49.MouseUp, Button45.MouseUp, Button46.MouseUp, Button47.MouseUp, Button48.MouseUp, Button44.MouseUp, Button43.MouseUp, Button42.MouseUp, Button41.MouseUp, Button40.MouseUp, btnPositionAdd.MouseUp, Button58.MouseUp, Button54.MouseUp, Button55.MouseUp, Button56.MouseUp, Button57.MouseUp, Button53.MouseUp, Button52.MouseUp, Button51.MouseUp, Button50.MouseUp, Button39.MouseUp, btnPositionMinus.MouseUp, btnResetRobotAlarm.MouseUp, btnMoveToReadyPosition.MouseUp
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name
                btnFeedCounterClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove2
            Case btnFeedClockwise.Name
                btnFeedClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd2
            Case btnJobZ.Name
                btnJobZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jobz2

            Case Button49.Name, Button45.Name, Button46.Name, Button47.Name, Button48.Name, Button44.Name, Button43.Name, Button42.Name, Button41.Name, Button40.Name, btnPositionAdd.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.plus2
            Case Button58.Name, Button54.Name, Button55.Name, Button56.Name, Button57.Name, Button53.Name, Button52.Name, Button51.Name, Button50.Name, Button39.Name, btnPositionMinus.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.subtract2
            Case btnResetRobotAlarm.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.roll
            Case btnMoveToReadyPosition.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.home
        End Select

        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnFeedClockwise.Name
                m_Motion.SlowStop(enumAxis.FeederZ)
                m_IsMoving = False
        End Select
    End Sub

    Private Sub btnLighting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLighting.Click
        If (m_Lighting = False) Then
            btnLighting.BackgroundImage = Global.LaserSolder.My.Resources.Resources.lighton
        Else
            btnLighting.BackgroundImage = Global.LaserSolder.My.Resources.Resources.lightoff
        End If
        m_Lighting = Not m_Lighting
    End Sub

    Private Sub TrackBar_ChangedValue(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbPower8.ValueChanged, tbPower7.ValueChanged, tbPower6.ValueChanged, tbPower5.ValueChanged, tbPower4.ValueChanged, tbPower3.ValueChanged, tbPower2.ValueChanged, tbPower1.ValueChanged, tbPower0.ValueChanged, tbSpeed.ValueChanged
        Dim tb As TrackBar = CType(sender, TrackBar)
        Select Case tb.Name
            Case tbSpeed.Name
                txtSpeed.Text = tbSpeed.Value
            Case tbPower0.Name
                Label33.Text = (tbPower0.Value / 10.0F).ToString("F1")
            Case tbPower1.Name
                Label34.Text = (tbPower1.Value / 10.0F).ToString("F1")
            Case tbPower2.Name
                Label35.Text = (tbPower2.Value / 10.0F).ToString("F1")
            Case tbPower3.Name
                Label36.Text = (tbPower3.Value / 10.0F).ToString("F1")
            Case tbPower4.Name
                Label37.Text = (tbPower4.Value / 10.0F).ToString("F1")
            Case tbPower5.Name
                Label38.Text = (tbPower5.Value / 10.0F).ToString("F1")
            Case tbPower6.Name
                Label39.Text = (tbPower6.Value / 10.0F).ToString("F1")
            Case tbPower7.Name
                Label40.Text = (tbPower7.Value / 10.0F).ToString("F1")
            Case tbPower8.Name
                Label41.Text = (tbPower8.Value / 10.0F).ToString("F1")

        End Select
    End Sub

    Private Sub AddTrackBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button41.Click, Button49.Click, Button48.Click, Button47.Click, Button46.Click, Button45.Click, Button44.Click, Button43.Click, Button42.Click
        AddTrackBar(sender, True)
    End Sub

    Private Sub SubtractTrackBar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button50.Click, Button58.Click, Button57.Click, Button56.Click, Button55.Click, Button54.Click, Button53.Click, Button52.Click, Button51.Click
        AddTrackBar(sender, False)
    End Sub

    Private Sub AddTrackBar(ByVal sender As Object, ByVal Add As Boolean)
        Dim btn As Button = CType(sender, Button)
        Dim offset As Single = 1.0F
        If (Add = False) Then
            offset *= -1.0F
        End If
        Select Case btn.Name
            Case Button41.Name, Button50.Name
                Dim value As Single = tbPower0.Value / 10.0F + offset
                If (value > tbPower0.Maximum / 10.0F) Then
                    tbPower0.Value = tbPower0.Maximum
                ElseIf (value < tbPower0.Minimum) Then
                    tbPower0.Value = tbPower0.Minimum
                Else
                    tbPower0.Value = value * 10
                End If
            Case Button42.Name, Button51.Name
                Dim value As Single = tbPower1.Value / 10.0F + offset
                If (value > tbPower1.Maximum / 10.0F) Then
                    tbPower1.Value = tbPower1.Maximum
                ElseIf (value < tbPower1.Minimum) Then
                    tbPower1.Value = tbPower1.Minimum
                Else
                    tbPower1.Value = value * 10
                End If
            Case Button43.Name, Button52.Name
                Dim value As Single = tbPower2.Value / 10.0F + offset
                If (value > tbPower2.Maximum / 10.0F) Then
                    tbPower2.Value = tbPower2.Maximum
                ElseIf (value < tbPower2.Minimum) Then
                    tbPower2.Value = tbPower2.Minimum
                Else
                    tbPower2.Value = value * 10
                End If
            Case Button44.Name, Button53.Name
                Dim value As Single = tbPower3.Value / 10.0F + offset
                If (value > tbPower3.Maximum / 10.0F) Then
                    tbPower3.Value = tbPower3.Maximum
                ElseIf (value < tbPower3.Minimum) Then
                    tbPower3.Value = tbPower3.Minimum
                Else
                    tbPower3.Value = value * 10
                End If
            Case Button45.Name, Button54.Name
                Dim value As Single = tbPower4.Value / 10.0F + offset
                If (value > tbPower4.Maximum / 10.0F) Then
                    tbPower4.Value = tbPower4.Maximum
                ElseIf (value < tbPower4.Minimum) Then
                    tbPower4.Value = tbPower4.Minimum
                Else
                    tbPower4.Value = value * 10
                End If
            Case Button46.Name, Button55.Name
                Dim value As Single = tbPower5.Value / 10.0F + offset
                If (value > tbPower5.Maximum / 10.0F) Then
                    tbPower5.Value = tbPower5.Maximum
                ElseIf (value < tbPower5.Minimum) Then
                    tbPower5.Value = tbPower5.Minimum
                Else
                    tbPower5.Value = value * 10
                End If
            Case Button47.Name, Button56.Name
                Dim value As Single = tbPower6.Value / 10.0F + offset
                If (value > tbPower6.Maximum / 10.0F) Then
                    tbPower6.Value = tbPower6.Maximum
                ElseIf (value < tbPower6.Minimum) Then
                    tbPower6.Value = tbPower6.Minimum
                Else
                    tbPower6.Value = value * 10
                End If
            Case Button48.Name, Button57.Name
                Dim value As Single = tbPower7.Value / 10.0F + offset
                If (value > tbPower7.Maximum / 10.0F) Then
                    tbPower7.Value = tbPower7.Maximum
                ElseIf (value < tbPower7.Minimum) Then
                    tbPower7.Value = tbPower7.Minimum
                Else
                    tbPower7.Value = value * 10
                End If
            Case Button49.Name, Button58.Name
                Dim value As Single = tbPower8.Value / 10.0F + offset
                If (value > tbPower8.Maximum / 10.0F) Then
                    tbPower8.Value = tbPower8.Maximum
                ElseIf (value < tbPower8.Minimum) Then
                    tbPower8.Value = tbPower8.Minimum
                Else
                    tbPower8.Value = value * 10
                End If
        End Select
    End Sub

    Private Sub txtNumber_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtForwardDelay.KeyPress, txtSpeed.KeyPress, txtPositionZ.KeyPress, txtPositionY.KeyPress, txtPositionX.KeyPress, txtPositionR.KeyPress, txtBackwardSpeedPercent.KeyPress, txtBackwardDistancemm.KeyPress, txtForwardDistance2.KeyPress, txtForwardSpeedPercent2.KeyPress, txtDistance.KeyPress, txtAxisUnit.KeyPress, txtSpotSize.KeyPress, txtIntervalTime.KeyPress, TextBox13.KeyPress, txtForwardSpeedPercent1.KeyPress, txtForwardDistance1.KeyPress, txtBackwardDelay.KeyPress, txtHeight.KeyPress
        Dim ctrl As TextBox = CType(sender, TextBox)
        'Check imput only Number key or Control key
        If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Check only 1 decimal point
        If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
            e.Handled = True
        End If
    End Sub


    Private Sub FormatNode(ByVal node As TreeNode)

        Dim ImageIdx As Integer = 22
        Dim forceColor As Color = Color.DarkBlue
        If (node.Parent Is Nothing) Then
            node.NodeFont = New Font(tvJobs.Font.FontFamily, tvJobs.Font.Size + 1, FontStyle.Regular)
        Else
            node.NodeFont = New Font(tvJobs.Font.FontFamily, tvJobs.Font.Size, FontStyle.Regular)
        End If
        If (node.Tag IsNot Nothing) Then
            Dim job As CJobObject = CType(node.Tag, CJobObject)
            node.Text = job.Key
            forceColor = job.NoSelecteForceColor
            ImageIdx = job.ImageIdx
        End If
        node.Name = node.Text
        node.ImageIndex = ImageIdx
        node.SelectedImageIndex = ImageIdx
        node.ForeColor = forceColor
    End Sub


    Private Sub Button40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button40.Click
        AddAllTrackBar(True)
    End Sub
    Private Sub AddAllTrackBar(ByVal Add As Boolean)
        Try
            Dim value As Single = CType(TextBox13.Text, Single)
            If (rbAbs.Checked) Then
                If (Add = False) Then
                    value = -1.0F * value
                End If
                Dim tmp As Single = tbPower0.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower0.Minimum) Then
                    tbPower0.Value = tbPower0.Minimum
                ElseIf (tmp > tbPower0.Maximum) Then
                    tbPower0.Value = tbPower0.Maximum
                Else
                    tbPower0.Value = tmp
                End If
                tmp = tbPower1.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower1.Minimum) Then
                    tbPower1.Value = tbPower1.Minimum
                ElseIf (tmp > tbPower1.Maximum) Then
                    tbPower1.Value = tbPower1.Maximum
                Else
                    tbPower1.Value = tmp
                End If
                tmp = tbPower2.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower2.Minimum) Then
                    tbPower2.Value = tbPower2.Minimum
                ElseIf (tmp > tbPower2.Maximum) Then
                    tbPower2.Value = tbPower2.Maximum
                Else
                    tbPower2.Value = tmp
                End If
                tmp = tbPower3.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower3.Minimum) Then
                    tbPower3.Value = tbPower3.Minimum
                ElseIf (tmp > tbPower3.Maximum) Then
                    tbPower3.Value = tbPower3.Maximum
                Else
                    tbPower3.Value = tmp
                End If
                tmp = tbPower4.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower4.Minimum) Then
                    tbPower4.Value = tbPower4.Minimum
                ElseIf (tmp > tbPower4.Maximum) Then
                    tbPower4.Value = tbPower4.Maximum
                Else
                    tbPower4.Value = tmp
                End If
                tmp = tbPower5.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower5.Minimum) Then
                    tbPower5.Value = tbPower5.Minimum
                ElseIf (tmp > tbPower5.Maximum) Then
                    tbPower5.Value = tbPower5.Maximum
                Else
                    tbPower5.Value = tmp
                End If
                tmp = tbPower6.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower6.Minimum) Then
                    tbPower6.Value = tbPower6.Minimum
                ElseIf (tmp > tbPower6.Maximum) Then
                    tbPower6.Value = tbPower6.Maximum
                Else
                    tbPower6.Value = tmp
                End If
                tmp = tbPower7.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower7.Minimum) Then
                    tbPower7.Value = tbPower7.Minimum
                ElseIf (tmp > tbPower7.Maximum) Then
                    tbPower7.Value = tbPower7.Maximum
                Else
                    tbPower7.Value = tmp
                End If
                tmp = tbPower8.Value / 10.0F
                tmp += value
                tmp *= 10
                If (tmp < tbPower8.Minimum) Then
                    tbPower8.Value = tbPower8.Minimum
                ElseIf (tmp > tbPower8.Maximum) Then
                    tbPower8.Value = tbPower8.Maximum
                Else
                    tbPower8.Value = tmp
                End If

            Else
                Dim sign As Single = 1.0F
                If (Add = False) Then
                    sign = -1.0F
                End If
                Dim tmp As Single = tbPower0.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower0.Minimum) Then
                    tbPower0.Value = tbPower0.Minimum
                ElseIf (tmp > tbPower0.Maximum) Then
                    tbPower0.Value = tbPower0.Maximum
                Else
                    tbPower0.Value = tmp
                End If
                tmp = tbPower1.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower1.Minimum) Then
                    tbPower1.Value = tbPower1.Minimum
                ElseIf (tmp > tbPower1.Maximum) Then
                    tbPower1.Value = tbPower1.Maximum
                Else
                    tbPower1.Value = tmp
                End If
                tmp = tbPower2.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower2.Minimum) Then
                    tbPower2.Value = tbPower2.Minimum
                ElseIf (tmp > tbPower2.Maximum) Then
                    tbPower2.Value = tbPower2.Maximum
                Else
                    tbPower2.Value = tmp
                End If
                tmp = tbPower3.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower3.Minimum) Then
                    tbPower3.Value = tbPower3.Minimum
                ElseIf (tmp > tbPower3.Maximum) Then
                    tbPower3.Value = tbPower3.Maximum
                Else
                    tbPower3.Value = tmp
                End If
                tmp = tbPower4.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower4.Minimum) Then
                    tbPower4.Value = tbPower4.Minimum
                ElseIf (tmp > tbPower4.Maximum) Then
                    tbPower4.Value = tbPower4.Maximum
                Else
                    tbPower4.Value = tmp
                End If
                tmp = tbPower5.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower5.Minimum) Then
                    tbPower5.Value = tbPower5.Minimum
                ElseIf (tmp > tbPower5.Maximum) Then
                    tbPower5.Value = tbPower5.Maximum
                Else
                    tbPower5.Value = tmp
                End If
                tmp = tbPower6.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower6.Minimum) Then
                    tbPower6.Value = tbPower6.Minimum
                ElseIf (tmp > tbPower6.Maximum) Then
                    tbPower6.Value = tbPower6.Maximum
                Else
                    tbPower6.Value = tmp
                End If
                tmp = tbPower7.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower7.Minimum) Then
                    tbPower7.Value = tbPower7.Minimum
                ElseIf (tmp > tbPower7.Maximum) Then
                    tbPower7.Value = tbPower7.Maximum
                Else
                    tbPower7.Value = tmp
                End If
                tmp = tbPower8.Value / 10.0F
                tmp = Math.Round((tmp + sign * (tmp * value / 100.0F)) * 10.0F, 1)
                If (tmp < tbPower8.Minimum) Then
                    tbPower8.Value = tbPower8.Minimum
                ElseIf (tmp > tbPower8.Maximum) Then
                    tbPower8.Value = tbPower8.Maximum
                Else
                    tbPower8.Value = tmp
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Button39_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button39.Click
        AddAllTrackBar(False)
    End Sub

    Private Sub TextBox13_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox13.Leave
        Try
            If (TextBox13.Text = "") Then
                TextBox13.Text = "0.0"
            End If
            Dim value As Single = 0
            If (Single.TryParse(TextBox13.Text, value)) Then
                TextBox13.Text = value.ToString("F1")
            Else
                TextBox13.Text = "0.0"
            End If
        Catch ex As Exception
            TextBox13.Text = "0.0"
        End Try
    End Sub
    Private Sub ShowProperty(ByVal node As TreeNode)
        Try
            If (node Is Nothing) Then
                pgJobProperty.SelectedObject = Nothing
                lblProperty.Text = ""
            Else
                Dim job As CJobObject = CType(node.Tag, CJobObject)
                lblProperty.Text = job.Key
                lblProperty.ForeColor = job.NoSelecteForceColor
                pgJobProperty.SelectedObject = job
                pgJobProperty.ExpandAllGridItems()
            End If
        Catch ex As Exception
            pgJobProperty.SelectedObject = Nothing
            lblProperty.Text = ""
        End Try
    End Sub
    Private m_pointCLick As Point
    Private m_StartIdxSelected As Integer
    Private Sub tvJobs_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvJobs.NodeMouseClick
        Try
            tvJobs.BeginUpdate()
            m_pointCLick = e.Location
            m_ClickNode = e.Node
            If (e.Node.Parent Is Nothing) Then
                RemoveSelectedBackground(m_SelectedNodes)
                m_SelectedNodes.Clear()
                m_SelectedNodes.Add(e.Node)
                AddSelectedBackground(m_SelectedNodes)
                ShowProperty(Nothing)
                tvJobs.EndUpdate()
                Exit Sub
            End If
            Dim shift As Boolean = (ModifierKeys = Keys.Shift)
            Dim ctrl As Boolean = (ModifierKeys = Keys.Control)

            If (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count = 0) Then
                m_SelectedNodes.Add(e.Node)
            Else
                RemoveSelectedBackground(m_SelectedNodes)
                tvJobs.SelectedNode = Nothing
                Dim startNode As TreeNode = CType(m_SelectedNodes(0), TreeNode)
                Dim rootNode As TreeNode = startNode.Parent
                If (startNode.Parent IsNot e.Node.Parent) Then
                    m_SelectedNodes.Clear()
                    m_SelectedNodes.Add(e.Node)
                Else

                    If (shift = True) Then
                        m_SelectedNodes.Clear()
                        If (m_StartIdxSelected < e.Node.Index) Then
                            For idx = m_StartIdxSelected To e.Node.Index
                                m_SelectedNodes.Add(rootNode.Nodes(idx))
                            Next
                        Else
                            For idx = e.Node.Index To m_StartIdxSelected
                                m_SelectedNodes.Add(rootNode.Nodes(idx))
                            Next
                        End If
                    ElseIf (ctrl = True) Then
                        If (m_SelectedNodes.IndexOf(e.Node) > -1) Then
                            m_SelectedNodes.Remove(e.Node)
                        Else
                            m_SelectedNodes.Add(e.Node)
                        End If
                    Else
                        m_SelectedNodes.Clear()
                        m_SelectedNodes.Add(e.Node)
                    End If
                End If
            End If
            AddSelectedBackground(m_SelectedNodes)
            tvJobs.EndUpdate()
            If (m_SelectedNodes.Count > 0) Then
                If (tvJobs.SelectedNode IsNot m_SelectedNodes(m_SelectedNodes.Count - 1)) Then
                    tvJobs.SelectedNode = m_SelectedNodes(m_SelectedNodes.Count - 1)
                End If
            Else
                tvJobs.SelectedNode = Nothing
            End If

            If (m_SelectedNodes.Count = 1 AndAlso e.Node.Parent IsNot Nothing) Then
                ShowProperty(e.Node)
                m_StartIdxSelected = e.Node.Index
            Else
                ShowProperty(Nothing)
            End If
        Catch ex As Exception
            FMessageBox.Show("An error occurred when selecting a job." & vbCrLf & "(選擇工作時發生錯誤)", "tvJobs_NodeMouseClick error message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    Private Sub RemoveSelectedBackground(ByVal pArrayNode As ArrayList)
        If (pArrayNode Is Nothing) Then
            Exit Sub
        End If
        For idx = 0 To pArrayNode.Count - 1
            Dim node As TreeNode = CType(pArrayNode(idx), TreeNode)
            Dim backColor = Color.White
            Dim forceColor As Color = Color.DarkBlue
            If (node.Tag IsNot Nothing) Then
                Dim job As CJobObject = CType(node.Tag, CJobObject)
                forceColor = job.NoSelecteForceColor
                backColor = job.NoSelecteBackColor
                node.ForeColor = forceColor
                node.BackColor = Color.White
            Else
                node.ForeColor = forceColor
                node.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub AddSelectedBackground(ByVal pSelectedNodes As ArrayList)
        For idx = 0 To pSelectedNodes.Count - 1
            Dim node As TreeNode = CType(pSelectedNodes(idx), TreeNode)
            Dim job As CJobObject = CType(node.Tag, CJobObject)
            If (job IsNot Nothing) Then
                node.BackColor = job.SelectedBackColor
                node.ForeColor = job.SelectedForceColor
            Else
                node.BackColor = System.Drawing.ColorTranslator.FromHtml("#0078d7")
                node.ForeColor = Color.White
            End If
        Next
    End Sub

    Private Sub tvJobs_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles tvJobs.KeyUp
        Try
            If (e.KeyData = Keys.Delete AndAlso m_SelectedNodes.Count > 0) Then
                Dim parentNode As TreeNode = (CType(m_SelectedNodes(0), TreeNode)).Parent
                If (parentNode Is Nothing) Then
                    tvJobs.EndUpdate()
                    Exit Sub
                End If
                If (FMessageBox.Show("Are you sure to delete module?" & vbCrLf & "(確定消除模組嗎?)", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    tvJobs.BeginUpdate()
                    Dim maxIdx As Integer = 0
                    For idx = 0 To m_SelectedNodes.Count - 1
                        Dim node As TreeNode = CType(m_SelectedNodes(idx), TreeNode)
                        Dim parent As TreeNode = node.Parent
                        tvJobs.Nodes.Remove(node)
                        If (parent.Parent IsNot Nothing) Then
                            Dim job As CJobObject = CType(parent.Tag, CJobObject)
                            While parent.Nodes.Count = 0 AndAlso job.CanHasChild
                                Dim tmp = parent.Parent
                                tvJobs.Nodes.Remove(parent)
                                parent = tmp
                                If (parent Is Nothing) Then
                                    Exit While
                                End If
                                job = CType(parent.Tag, CJobObject)
                            End While
                        End If
                    Next
                    m_SelectedNodes.Clear()
                    If (maxIdx >= parentNode.Nodes.Count) Then
                        maxIdx -= 1
                    End If
                    If (maxIdx >= 0) Then
                        m_SelectedNodes.Add(parentNode.Nodes(maxIdx))
                    Else
                        m_SelectedNodes.Add(parentNode)
                    End If
                    m_ClickNode = m_SelectedNodes(0)

                    AddSelectedBackground(m_SelectedNodes)
                    tvJobs.EndUpdate()
                    tvJobs.SelectedNode = m_SelectedNodes(m_SelectedNodes.Count - 1)
                End If
            End If
        Catch ex As Exception
            FMessageBox.Show("An error occurred while deleting jobs." & vbCrLf & "(刪除作業時發生錯誤)", "tvJobs_KeyUp error message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Dim m_FlagFindPallet As Boolean
    Private Sub FindPallet(ByVal ListJob As CListJob, ByVal job As CJobObject, ByRef pPallet As CPallet)

        For i = 0 To ListJob.Count - 1
            If (m_FlagFindPallet = True) Then
                Exit Sub
            End If
            If (ListJob.GetJob(i).GetType() Is GetType(CPallet)) Then
                pPallet = CType(ListJob.GetJob(i), CPallet)
            Else
                If (ListJob.GetJob(i).ID = job.ID) Then
                    m_FlagFindPallet = True
                    Exit For
                End If
            End If
            If (ListJob.GetJob(i).CanHasChild) Then
                If (ListJob.GetJob(i).ListJob IsNot Nothing) Then
                    For j = 0 To ListJob.GetJob(i).ListJob.Count - 1
                        FindPallet(ListJob.GetJob(i).ListJob, job, pPallet)
                        If (m_FlagFindPallet = True) Then
                            Exit Sub
                        End If
                    Next
                End If
            End If
        Next

    End Sub

    Private Function SortJobTmp(ByVal pallet As CPallet) As List(Of CJobObject)
        Dim res As List(Of CJobObject) = New List(Of CJobObject)
        If (pallet.ListJob.Count > 0) Then
            Dim p0 As CPoint = Nothing
            Dim res2 As New List(Of CJobObject)
            Dim stepDisX As Double = 1
            Dim stepDisY As Double = 1
            Dim row As Integer = 0
            Dim col As Integer = 0
            Dim countStep As Integer = 1

            Dim lstPoint As New List(Of CPoint)

            For p = 0 To pallet.ListJob.Count - 1
                If (pallet.ListJob.GetJob(p).GetType() Is GetType(CPoint)) Then
                    lstPoint.Add(CType(pallet.ListJob.GetJob(p), CPoint))
                End If
            Next
            Dim RowColIndex(lstPoint.Count - 1, 1) As Integer
            Dim lstCountStep(lstPoint.Count - 1) As Integer

            For c = 0 To lstCountStep.Length - 1
                lstCountStep(c) = 1
            Next

            If (pallet.OrderType = eOrderType.S_Shape) Then
                If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                    For j = 0 To pallet.ListJob.Count - 1
                        If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                            stepDisX = 1
                            For r = 0 To pallet.RowNumber - 1
                                For c = 0 To pallet.ColumnNumber - 1
                                    p0 = pallet.ListJob.GetJob(j).Clone()
                                    If (stepDisX > 0) Then
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += r * pallet.RowDistance
                                    Else
                                        p0.Point.X += pallet.ColumnDistance * (pallet.ColumnNumber - c - 1)
                                        p0.Point.Y += r * pallet.RowDistance
                                    End If
                                    p0.InPallet = True
                                    res2.Add(p0)
                                Next
                                stepDisX *= -1
                            Next
                        End If
                    Next


                    For j = 0 To res2.Count - 1
                        If (res2(j).GetType() Is GetType(CPoint)) Then
                            p0 = CType(res2(j), CPoint)
                            If (p0.InPallet) Then
                                Dim idxRowCol As Integer = -1
                                For idx = 0 To lstPoint.Count - 1
                                    If (p0.ID = lstPoint(idx).ID) Then
                                        idxRowCol = idx
                                        Exit For
                                    End If
                                Next
                                If (idxRowCol >= 0) Then
                                    p0.RowNumber = RowColIndex(idxRowCol, 0)
                                    p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                    RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                    If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber OrElse RowColIndex(idxRowCol, 1) = -1) Then
                                        RowColIndex(idxRowCol, 0) += 1
                                        lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                        RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                    End If
                                End If
                            Else
                                p0.RowNumber = 0
                                p0.ColumnNumber = 0
                            End If
                        End If
                    Next
                Else
                    For j = 0 To pallet.ListJob.Count - 1
                        If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                            stepDisY = 1
                            For c = 0 To pallet.ColumnNumber - 1
                                For r = 0 To pallet.RowNumber - 1
                                    p0 = pallet.ListJob.GetJob(j).Clone()
                                    If (stepDisY > 0) Then
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += r * pallet.RowDistance
                                    Else
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                    End If
                                    p0.InPallet = True
                                    res2.Add(p0)
                                Next
                                stepDisY *= -1
                            Next
                        End If
                    Next

                    For j = 0 To res2.Count - 1
                        If (res2(j).GetType() Is GetType(CPoint)) Then
                            p0 = CType(res2(j), CPoint)
                            If (p0.InPallet) Then
                                Dim idxRowCol As Integer = -1
                                For idx = 0 To lstPoint.Count - 1
                                    If (p0.ID = lstPoint(idx).ID) Then
                                        idxRowCol = idx
                                        Exit For
                                    End If
                                Next
                                If (idxRowCol >= 0) Then
                                    p0.RowNumber = RowColIndex(idxRowCol, 0)
                                    p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                    RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                    If (RowColIndex(idxRowCol, 0) = pallet.RowNumber OrElse RowColIndex(idxRowCol, 0) = -1) Then
                                        RowColIndex(idxRowCol, 1) += 1
                                        lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                        RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                    End If
                                End If
                            Else
                                p0.RowNumber = 0
                                p0.ColumnNumber = 0
                            End If
                        End If
                    Next
                End If
            Else
                If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                    For j = 0 To pallet.ListJob.Count - 1
                        If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                            For r = 0 To pallet.RowNumber - 1
                                For c = 0 To pallet.ColumnNumber - 1
                                    p0 = pallet.ListJob.GetJob(j).Clone()
                                    If (stepDisY > 0) Then
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += r * pallet.RowDistance
                                    Else
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r)
                                    End If
                                    p0.InPallet = True
                                    res2.Add(p0)
                                Next
                            Next
                        End If
                    Next

                    For j = 0 To res2.Count - 1
                        If (res2(j).GetType() Is GetType(CPoint)) Then
                            p0 = CType(res2(j), CPoint)
                            If (p0.InPallet) Then

                                Dim idxRowCol As Integer = -1
                                For idx = 0 To lstPoint.Count - 1
                                    If (p0.ID = lstPoint(idx).ID) Then
                                        idxRowCol = idx
                                        Exit For
                                    End If
                                Next

                                If (idxRowCol >= 0) Then
                                    p0.RowNumber = RowColIndex(idxRowCol, 0)
                                    p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                    RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                    If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber) Then
                                        RowColIndex(idxRowCol, 0) += 1
                                        RowColIndex(idxRowCol, 1) = 0
                                    End If
                                End If

                            Else
                                p0.RowNumber = 0
                                p0.ColumnNumber = 0
                            End If
                        End If
                    Next
                Else
                    For j = 0 To pallet.ListJob.Count - 1
                        If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                            For c = 0 To pallet.ColumnNumber - 1
                                For r = 0 To pallet.RowNumber - 1
                                    p0 = pallet.ListJob.GetJob(j).Clone()
                                    If (stepDisY > 0) Then
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += r * pallet.RowDistance
                                    Else
                                        p0.Point.X += c * pallet.ColumnDistance
                                        p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                    End If
                                    p0.InPallet = True
                                    res2.Add(p0)
                                Next
                            Next
                        End If
                    Next


                    For j = 0 To res2.Count - 1
                        If (res2(j).GetType() Is GetType(CPoint)) Then
                            p0 = CType(res2(j), CPoint)
                            If (p0.InPallet) Then

                                Dim idxRowCol As Integer = -1
                                For idx = 0 To lstPoint.Count - 1
                                    If (p0.ID = lstPoint(idx).ID) Then
                                        idxRowCol = idx
                                        Exit For
                                    End If
                                Next

                                If (idxRowCol >= 0) Then
                                    p0.RowNumber = RowColIndex(idxRowCol, 0)
                                    p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                    RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                    If (RowColIndex(idxRowCol, 0) = pallet.RowNumber) Then
                                        RowColIndex(idxRowCol, 1) += 1
                                        RowColIndex(idxRowCol, 0) = 0
                                    End If
                                End If
                            Else
                                p0.RowNumber = 0
                                p0.ColumnNumber = 0
                            End If
                        End If
                    Next
                End If
            End If
            res.AddRange(res2)
        End If
        Return res
    End Function

    Private m_JobSelected As CJobObject = Nothing
    Private m_IsPropertyDoubleClick As Boolean = False
    Private m_MouseClickPoint As Point = New Point(0, 0)
    Private Sub PropertyDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs)
        If (m_MouseClickPoint.X = e.X AndAlso m_MouseClickPoint.Y = e.Y) Then
            Exit Sub
        End If
        m_MouseClickPoint.X = e.X
        m_MouseClickPoint.Y = e.Y


        If m_IsPropertyDoubleClick = False Then
            m_IsPropertyDoubleClick = True

            Dim selectedGridEntry As PropertyInfo = sender.GetType().GetProperty("SelectedGridEntry", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public)
            Dim gridEntry As GridItem = CType(selectedGridEntry.GetValue(sender, Nothing), GridItem)
            Dim Axis As String = gridEntry.Label
            Dim point = pgJobProperty.SelectedObject.GetType().GetProperty("Point", BindingFlags.Instance Or BindingFlags.NonPublic Or BindingFlags.Public)

            If (point IsNot Nothing) Then
                Dim posX, posY, posZ, posR As Single
                Dim changeX As Boolean = True
                Dim changeY As Boolean = True
                Dim changeZ As Boolean = True
                Dim changeR As Boolean = True
                If (Not Single.TryParse(txtPositionX.Text, posX)) Then
                    changeX = False
                End If
                If (Not Single.TryParse(txtPositionY.Text, posY)) Then
                    changeY = False
                End If
                If (Not Single.TryParse(txtPositionZ.Text, posZ)) Then
                    changeZ = False
                End If
                If (Not Single.TryParse(txtPositionR.Text, posR)) Then
                    changeR = False
                End If

                If (pgJobProperty.SelectedObject.GetType() Is GetType(CPoint)) Then
                    Dim tmp = (CType(pgJobProperty.SelectedObject, CPoint))
                    Select Case Axis.ToLower()
                        Case "x axis"
                            If (changeX) Then
                                tmp.Point.X = posX
                            End If
                        Case "y axis"
                            If (changeY) Then
                                tmp.Point.Y = posY
                            End If
                        Case "z axis"
                            If (changeZ) Then
                                tmp.Point.Z = posZ
                            End If
                        Case "r axis"
                            If (changeR) Then
                                tmp.Point.R = posR
                            End If
                        Case "point"

                            Dim parent As TreeNode = m_ClickNode.Parent
                            Dim pallet As CPallet = Nothing
                            Dim SortedJob As List(Of CJobObject) = New List(Of CJobObject)
                            If (parent IsNot Nothing) Then
                                If (parent.Level <> 0) Then '<> Root node
                                    Dim job As CJobObject = CType(parent.Tag, CJobObject)
                                    If (job IsNot Nothing) Then
                                        If (job.GetType() Is GetType(CPallet)) Then
                                            pallet = CType(job, CPallet)
                                            Dim lst As CListJob = New CListJob()
                                            Dim AlignID = 0
                                            ReDim lstAlignID(5)

                                            For index = 1 To lstAlignID.Length - 1
                                                lstAlignID(index) = -1
                                            Next
                                            lst = BuildJobList(parent.Nodes, AlignID)
                                            pallet.ListJob = lst
                                            SortedJob = SortJobTmp(pallet)
                                        End If
                                    End If
                                End If
                            End If
                            If (pallet IsNot Nothing AndAlso SortedJob IsNot Nothing AndAlso SortedJob.Count > 0) Then
                                Dim fChooseColRow As FChooseColumnRow = New FChooseColumnRow(pallet)
                                fChooseColRow.ShowDialog()
                                If (fChooseColRow.OK = True) Then
                                    Dim selectedRow, selectedCol As Integer
                                    selectedRow = fChooseColRow.Row
                                    selectedCol = fChooseColRow.Column

                                    Dim job As CJobObject = CType(m_ClickNode.Tag, CJobObject)
                                    Dim clickpoint As CPoint = Nothing
                                    If (job IsNot Nothing AndAlso job.GetType() Is GetType(CPoint)) Then
                                        clickpoint = CType(job, CPoint)
                                    End If
                                    If (clickpoint IsNot Nothing) Then
                                        Dim selectedPoint As CPoint = Nothing

                                        For i = 0 To SortedJob.Count - 1
                                            If (SortedJob(i).GetType() Is GetType(CPoint)) Then
                                                selectedPoint = CType(SortedJob(i), CPoint)
                                                If (selectedPoint.RowNumber = selectedRow AndAlso selectedPoint.ColumnNumber = selectedCol AndAlso clickpoint.ID = selectedPoint.ID) Then
                                                    Exit For
                                                End If
                                            End If
                                        Next

                                        If (selectedPoint IsNot Nothing) Then
                                            MoveToPoint(selectedPoint)
                                        End If
                                    End If
                                End If
                            Else
                                If (FMessageBox.Show("Are you sure you want to move the setting postion?" & vbCrLf & "(您確定要移動到設定位置嗎)？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                                    MoveToPoint(tmp)
                                End If
                            End If
                    End Select
                ElseIf (pgJobProperty.SelectedObject.GetType() Is GetType(CAxis)) Then
                    Dim tmp = (CType(pgJobProperty.SelectedObject, CAxis))
                    Select Case Axis.ToLower()
                        Case "x axis"
                            If (changeX) Then
                                tmp.Point.X = posX
                            End If
                        Case "y axis"
                            If (changeY) Then
                                tmp.Point.Y = posY
                            End If
                        Case "z axis"
                            If (changeZ) Then
                                tmp.Point.Z = posZ
                            End If
                        Case "r axis"
                            If (changeR) Then
                                tmp.Point.R = posR
                            End If
                        Case "point"
                            If (changeX) Then
                                tmp.Point.X = posX
                            End If
                            If (changeY) Then
                                tmp.Point.Y = posY
                            End If
                            If (changeZ) Then
                                tmp.Point.Z = posZ
                            End If
                            If (changeR) Then
                                tmp.Point.R = posR
                            End If
                    End Select
                End If
                pgJobProperty.ExpandAllGridItems()
                Select Case Axis.ToLower()
                    Case "point"
                    Case Else
                        pgJobProperty.Refresh()
                End Select

            End If
            m_IsPropertyDoubleClick = False
        End If

    End Sub

    Private Sub MoveToPoint(ByVal pPoint As CPoint)
        Call UIProtect(False)

        Dim pResult As enumMotionFlag
        Dim pSpeed As Double
        Try
            pSpeed = CDbl(txtSpeed.Text) / 100
        Catch ex As Exception

        End Try
        If pSpeed >= 1 Then
            pSpeed = 1
        ElseIf pSpeed <= 0 Then
            pSpeed = 0.1
        End If
        Dim pMove As Boolean = False
        Dim pNowEncoder As Double
        m_Motion.GetEncoder(enumAxis.WorkholderX, pNowEncoder)
        If pMove = False AndAlso pNowEncoder <> pPoint.Point.X / m_ShowScale Then
            pMove = True
        End If

        m_Motion.GetEncoder(enumAxis.WorkholderY, pNowEncoder)
        If pMove = False AndAlso pNowEncoder <> pPoint.Point.Y / m_ShowScale Then
            pMove = True
        End If

        m_Motion.GetEncoder(enumAxis.WorkholderZ, pNowEncoder)
        If pMove = False AndAlso pNowEncoder <> pPoint.Point.Z / m_ShowScale Then
            pMove = True
        End If
        pMove = True
        If pMove = True Then
            Do
                If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                        If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                            Exit Do
                        End If
                    End If
                End If
                Application.DoEvents()
            Loop
            m_Motion.MoveAbs(enumAxis.WorkholderZ, 0, pResult, pSpeed, pSpeed)
            Do
                If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                        If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                            Exit Do
                        End If
                    End If
                End If
                Application.DoEvents()
            Loop
            m_Motion.MoveAbs(enumAxis.WorkholderX, pPoint.Point.X / m_ShowScale, pResult, pSpeed, pSpeed)
            m_Motion.MoveAbs(enumAxis.WorkholderY, pPoint.Point.Y / m_ShowScale, pResult, pSpeed, pSpeed)
            Do
                If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                        If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                            Exit Do
                        End If
                    End If
                End If
                Application.DoEvents()
            Loop
            m_Motion.MoveAbs(enumAxis.WorkholderZ, pPoint.Point.Z / m_ShowScale, pResult, pSpeed, pSpeed)
            Do
                If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                        If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                            Exit Do
                        End If
                    End If
                End If
                Application.DoEvents()
            Loop
        End If


        Call UIProtect(True)
    End Sub


    Private m_OldGridProperty As Control = Nothing
    Private Sub PropertyGrid1_SelectedObjectsChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pgJobProperty.SelectedObjectsChanged
        Dim description As Control = CType(pgJobProperty.Controls(0), Control)
        Dim gridproperty As Control = CType(pgJobProperty.Controls(2), Control)
        If (m_OldGridProperty IsNot Nothing) Then
            AddHandler m_OldGridProperty.MouseDoubleClick, AddressOf PropertyDoubleClick
        End If

        description.Height = 70
        description.Location = New Point(description.Location.X, 428)
        gridproperty.Height = 400
        AddHandler gridproperty.MouseDoubleClick, AddressOf PropertyDoubleClick
        m_OldGridProperty = gridproperty
    End Sub

#Region "Add Job"
    Private Sub AddNewJob(ByVal job As CJobObject)
        tvJobs.BeginUpdate()
        Try
            If (job.CanHasChild) Then
                If (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count = 0) Then
                    FMessageBox.Show("Please select item" & vbCrLf & "(請選擇項目。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo exitsub
                End If
                Dim node As TreeNode = CType(m_SelectedNodes(0), TreeNode)
                Dim InsertChildIndex As Integer = node.Index
                Dim InsertParentIndex As Integer = node.Index
                Dim parentNode As TreeNode = node.Parent
                If (parentNode Is Nothing) Then
                    FMessageBox.Show("Please select item" & vbCrLf & "(請選擇項目。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo exitsub
                ElseIf (parentNode.Level >= CListJob.MAX_LEVEL - 1) Then
                    FMessageBox.Show("Max level supported." & vbCrLf & "(最大支持水平。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    GoTo exitsub
                End If
                Dim nodeJob As CJobObject = CType(node.Tag, CJobObject)

                If (nodeJob.CanHasChild) Then
                    Dim level As Integer = 0
                    FindMaxLevel(node, level)
                    If (level >= CListJob.MAX_LEVEL AndAlso job.CanHasChild) Then
                        FMessageBox.Show("Max level supported." & vbCrLf & "(最大支持水平。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        GoTo exitsub
                    End If
                    Dim newNode As TreeNode = New TreeNode()
                    For i = 0 To m_SelectedNodes.Count - 1
                        node = CType(m_SelectedNodes(i), TreeNode)
                        Dim nodePtr As TreeNode = node
                        Dim nodePtr2 As TreeNode = Nothing
                        While (nodePtr.Level > 1)
                            nodePtr = nodePtr.Parent
                        End While
                        parentNode.Nodes.Remove(node)
                        newNode.Nodes.Add(node)
                    Next
                    newNode.Tag = job
                    If (InsertChildIndex > parentNode.Nodes.Count) Then
                        parentNode.Nodes.Add(newNode)
                    Else
                        parentNode.Nodes.Insert(InsertChildIndex, newNode)
                    End If
                    job.Level = newNode.Level - 1
                    FormatNode(newNode)
                Else
                    Dim newNode As TreeNode = New TreeNode()
                    For i = 0 To m_SelectedNodes.Count - 1
                        node = CType(m_SelectedNodes(i), TreeNode)
                        Dim nodePtr As TreeNode = node
                        While (nodePtr.Level > 1)
                            nodePtr = nodePtr.Parent
                        End While
                        parentNode.Nodes.Remove(node)
                        If (InsertChildIndex > parentNode.Nodes.Count) Then
                            newNode.Nodes.Add(node)
                        Else
                            newNode.Nodes.Insert(InsertChildIndex, node)
                            InsertChildIndex += 1
                        End If
                    Next
                    If (job.GetType() Is GetType(CRepeat)) Then
                        Dim rp As CRepeat = CType(job, CRepeat)
                        rp.StartID = CType(newNode.Nodes(0).Tag, CJobObject).ID
                        rp.EndID = CType(newNode.Nodes(newNode.Nodes.Count - 1).Tag, CJobObject).ID
                    ElseIf (job.GetType() Is GetType(CConditional)) Then

                    End If

                    newNode.Tag = job
                    If (InsertParentIndex > parentNode.Nodes.Count) Then
                        parentNode.Nodes.Add(newNode)
                    Else
                        parentNode.Nodes.Insert(InsertParentIndex, newNode)
                    End If
                    job.Level = newNode.Level - 1
                    FormatNode(newNode)
                End If
            Else
                If (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count = 0) Then
                    Dim parentNode As TreeNode = tvJobs.Nodes(0)
                    Dim newNode As TreeNode = New TreeNode()
                    newNode.Tag = job
                    parentNode.Nodes.Add(newNode)
                    job.Level = newNode.Level - 1
                    FormatNode(newNode)
                Else
                    Dim nodeSelected As TreeNode = CType(m_SelectedNodes(0), TreeNode)
                    Dim jobSelected As CJobObject = CType(nodeSelected.Tag, CJobObject)

                    If (jobSelected Is Nothing OrElse jobSelected.CanHasChild = False) Then
                        Dim parentNode As TreeNode = (CType(m_SelectedNodes(0), TreeNode)).Parent
                        If (parentNode Is Nothing) Then
                            Dim newNode As TreeNode = New TreeNode()
                            newNode.Tag = job
                            tvJobs.Nodes(0).Nodes.Add(newNode)
                            job.Level = newNode.Level - 1
                            FormatNode(newNode)
                        Else
                            If (parentNode.Level >= CListJob.MAX_LEVEL) Then
                                FMessageBox.Show("Max level supported." & vbCrLf & "(最大支持水平。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                GoTo exitsub
                            End If
                            Dim newNode As TreeNode = New TreeNode()
                            newNode.Tag = job
                            parentNode.Nodes.Add(newNode)
                            job.Level = newNode.Level - 1
                            FormatNode(newNode)
                            End If
                    Else
                            Dim newNode As TreeNode = New TreeNode()
                            newNode.Tag = job
                            nodeSelected.Nodes.Add(newNode)
                            job.Level = newNode.Level - 1
                            FormatNode(newNode)
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
exitsub:
        tvJobs.ExpandAll()
        tvJobs.EndUpdate()
    End Sub

    Private Sub btnAddPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPoint.Click
        Dim p As CPoint = New CPoint()
        Try
            p.Point.X = CSng(txtPositionX.Text)
            p.Point.Y = CSng(txtPositionY.Text)
            p.Point.Z = CSng(txtPositionZ.Text)
            p.Point.R = CSng(txtPositionR.Text)
        Catch
        End Try
        AddNewJob(p)
    End Sub
    Private Sub btnAddPallet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddPallet.Click
        AddNewJob(New CPallet())
    End Sub
    Private Sub btnAddRepeat_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRepeat.Click
        AddNewJob(New CRepeat())
    End Sub

    Private Sub btnAddAxis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAxis.Click
        Dim p As CAxis = New CAxis()
        Try
            p.Point.X = CSng(txtPositionX.Text)
            p.Point.Y = CSng(txtPositionY.Text)
            p.Point.Z = CSng(txtPositionZ.Text)
            p.Point.R = CSng(txtPositionR.Text)
        Catch
        End Try
        AddNewJob(p)
    End Sub

    Private Sub btnAddIF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddIF.Click
        AddNewJob(New CConditional())
    End Sub

    Private Sub btnAddIO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddIO.Click
        AddNewJob(New CIO())
    End Sub

    Private Sub btnAddStandby_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddStandby.Click
        AddNewJob(New CStandBy())
    End Sub

    Private Sub btnAddHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddHome.Click
        AddNewJob(New CHome())
    End Sub

    Private Sub btnAddJump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddJump.Click
        AddNewJob(New CJump())
    End Sub

    Private Sub btnAddWait_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddWait.Click
        AddNewJob(New CWait())
    End Sub

    Private Sub btnAddTackBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTackBegin.Click
        AddNewJob(New CTackBegin())
    End Sub

    Private Sub btnAddTackEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddTackEnd.Click
        AddNewJob(New CTackEnd())
    End Sub

    Private Sub btnAddBlow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBlow.Click
        AddNewJob(New CBlow())
    End Sub

    Private Sub btnAddRecordStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecordStart.Click
        AddNewJob(New CRecordBegin())
    End Sub

    Private Sub btnAddAlign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAlign.Click
        AddNewJob(New CAlign())
    End Sub

    Private Sub btnAddRecordStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddRecordStop.Click
        AddNewJob(New CRecordStop())
    End Sub

    Private Sub btnAddBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBarcode.Click
        AddNewJob(New CBarcode())
    End Sub

    Private Sub btnAddGVariable_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddGVariable.Click
        AddNewJob(New CGVariable())
    End Sub

    Private Sub btnAddLotEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLotEnd.Click
        AddNewJob(New CLotEnd())
    End Sub
#End Region

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Function BuildJobList(ByVal node As TreeNodeCollection, ByRef AlignID As Integer) As CListJob
        Dim res As CListJob = New CListJob()
        If (node.Count > 0) Then
            Dim i As Integer = 0
            While i < node.Count
                Dim job As CJobObject = CType(node(i).Tag, CJobObject)
                If (job.CanHasChild AndAlso node(i).Nodes.Count = 0) Then
                    node.RemoveAt(i)
                Else
                    Dim res2 As CListJob = New CListJob()
                    If (job.CanHasChild) Then
                        res2 = BuildJobList(node(i).Nodes, AlignID)
                        If (res2.Count = 0) Then
                            node.RemoveAt(i)
                            Continue While
                        End If
                    End If
                    If (job.GetType() Is GetType(CAlign)) Then
                        Dim x As Integer = 0

                        For idx = 0 To lstAlignID.Length - 1
                            If (lstAlignID(idx) > x) Then
                                x = lstAlignID(idx)
                            End If
                        Next
                        AlignID = x + 1
                        lstAlignID(node(i).Level) = AlignID
                    End If

                    job.AlignID = AlignID

                    job.ListJob = res2
                    res.AddJob(job)
                    i += 1
                End If
            End While
            If (AlignID > lstAlignID(node(0).Level - 1)) Then
                AlignID = lstAlignID(node(0).Level - 1) + 1
            End If
        End If
        AlignID -= 1
        If (AlignID < -1) Then
            AlignID = -1
        End If
        Return res
    End Function

    Dim lstAlignID(-1) As Integer
    Private Sub BuildTmpListJob()

    End Sub
    Private Sub btnBuildProgram_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildProgram.Click
        Dim LoadingForm As FLoading = New FLoading("Building the program...")
        Me.Enabled = False
        Try
            Dim stepPecent As Double = (100.0 / (tvJobs.Nodes(0).Nodes.Count + 1))
            If (stepPecent * (tvJobs.Nodes(0).Nodes.Count + 1) > 100.0) Then
                stepPecent -= 0.1
            End If
            Dim stepcnt As Integer = 1
            LoadingForm.Location = New Point((Me.Location.X + Me.Width) / 2, (Me.Location.Y + Me.Height) / 2)
            LoadingForm.Show()
            m_ListJob.Clear()
            Dim i As Integer = 0
            Dim AlignID As Integer = -1

            tvJobs.BeginUpdate()
            ReDim lstAlignID(m_MaxLevel)

            For index = 1 To lstAlignID.Length - 1
                lstAlignID(index) = -1
            Next

            While i < tvJobs.Nodes(0).Nodes.Count
                Dim job As CJobObject = CType(tvJobs.Nodes(0).Nodes(i).Tag, CJobObject)
                If (job.CanHasChild AndAlso tvJobs.Nodes(0).Nodes(i).Nodes.Count = 0) Then
                    tvJobs.Nodes(0).Nodes.RemoveAt(i)
                Else
                    Dim lst As CListJob = New CListJob()
                    If (job.CanHasChild) Then
                        lst = BuildJobList(tvJobs.Nodes(0).Nodes(i).Nodes, AlignID)
                        If (lst.Count = 0) Then
                            tvJobs.Nodes(0).Nodes.RemoveAt(i)
                            Continue While
                        End If
                    End If

                    If (job.GetType() Is GetType(CAlign)) Then
                        If (AlignID < lstAlignID(tvJobs.Nodes(0).Nodes(i).Level)) Then
                            AlignID = lstAlignID(tvJobs.Nodes(0).Nodes(i).Level)
                        End If
                        AlignID += 1
                        lstAlignID(tvJobs.Nodes(0).Nodes(i).Level) = AlignID
                    End If
                    job.AlignID = AlignID
                    job.ListJob = lst
                    m_ListJob.AddJob(job)
                    i += 1
                End If
                LoadingForm.Percent = stepcnt * stepPecent
                stepcnt += 1
            End While
            ReDim lstAlignID(-1)
            tvJobs.EndUpdate()
            tvJobs.Refresh()
            m_ListJob.Sort()
            Dim err As Exception = Nothing
            Dim res = MJobManager.SaveListJob(CProject.PROJECT_PATH & m_CurProject.Key & "\Job\ListJob.job", m_ListJob, err)

            Dim err2 As String = ""
            Dim res2 = m_Param.SaveParam(CProject.PROJECT_PATH & m_CurProject.Key, err2)

            Try
                MRuler.Save(m_Ruler, "D:\DataSettings\LaserSolder\Setting\Ruler.set")
            Catch ex As Exception

            End Try
            LoadingForm.Percent = 100
            If (res = False Or res2 = False) Then
                FMessageBox.Show("Build program fail." & vbCrLf & "(生成程式失敗。)" & vbCrLf, "Build program message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, err)
            Else
                FMessageBox.Show("Build program complete." & vbCrLf & "(構建程式完成。)", "Build program message", MessageBoxButtons.OK, MessageBoxIcon.OK)
                m_Param.WriteLog(CProject.PROJECT_PATH & m_CurProject.Key, m_OldParam)
                m_OldParam = Nothing
                m_OldParam = m_Param.Clone(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
            End If
        Catch ex As Exception
            tvJobs.EndUpdate()
            LoadingForm.Close()
            FMessageBox.Show("Build program fail." & vbCrLf & "(生成程式失敗。)", "Build program message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        LoadingForm.Dispose()
        Me.Enabled = True
        Me.Focus()
    End Sub
    Private Function GetDeepestChildNodeLevel(ByVal node As TreeNode) As Integer
        Dim subLevel = node.Nodes.Cast(Of TreeNode)().[Select](AddressOf GetDeepestChildNodeLevel)
        Return IIf(subLevel.Count() = 0, 1, subLevel.Max() + 1)
    End Function
    Private Sub btnRegisterGPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRegisterGPoint.Click

        Dim pSpeed As Double
        Try
            pSpeed = CDbl(txtSpeed.Text) / 100
        Catch ex As Exception

        End Try
        If pSpeed >= 1 Then
            pSpeed = 1
        ElseIf pSpeed <= 0 Then
            pSpeed = 0.1
        End If

        Dim fRegisterPos As New FRegisterPosition(m_CurProject, m_Param, m_Motion, pSpeed)
        fRegisterPos.ShowDialog()
    End Sub
    Private Function MoveNodeUp(ByVal node As TreeNode) As TreeNode
        Dim parentNode As TreeNode = node.Parent
        Dim originalIndex As Integer = node.Index
        If node.Index = 0 Then Return node
        Dim ClonedNode As TreeNode = CType(node.Clone(), TreeNode)
        node.Remove()
        parentNode.Nodes.Insert(originalIndex - 1, ClonedNode)
        ClonedNode.ExpandAll()
        Return ClonedNode
    End Function
    Private Function MoveNodeDown(ByVal node As TreeNode) As TreeNode
        Dim parentNode As TreeNode = node.Parent
        Dim originalIndex As Integer = node.Index
        If node.Index = parentNode.Nodes.Count - 1 Then Return node
        Dim ClonedNode As TreeNode = CType(node.Clone(), TreeNode)
        node.Remove()
        parentNode.Nodes.Insert(originalIndex + 1, ClonedNode)
        ClonedNode.ExpandAll()
        Return ClonedNode
    End Function
    Private Function MoveNodeTop(ByVal node As TreeNode) As TreeNode
        Dim parentNode As TreeNode = node.Parent
        Dim originalIndex As Integer = node.Index
        If node.Index = 0 Then Return node
        Dim ClonedNode As TreeNode = CType(node.Clone(), TreeNode)
        node.Remove()
        parentNode.Nodes.Insert(0, ClonedNode)
        ClonedNode.ExpandAll()
        Return ClonedNode
    End Function
    Private Function MoveNodeBottom(ByVal node As TreeNode) As TreeNode
        Dim parentNode As TreeNode = node.Parent
        Dim originalIndex As Integer = node.Index
        If node.Index = parentNode.Nodes.Count - 1 Then Return node
        Dim ClonedNode As TreeNode = CType(node.Clone(), TreeNode)
        node.Remove()
        parentNode.Nodes.Add(ClonedNode)
        ClonedNode.ExpandAll()
        Return ClonedNode
    End Function
    Private Sub UpdateStartEndID(ByRef node As TreeNode)
        If (node.Parent IsNot Nothing AndAlso node.Parent.Tag IsNot Nothing) Then
            Dim parentNode As CJobObject = CType(node.Parent.Tag, CJobObject)
            If (parentNode.GetType() Is GetType(CRepeat)) Then
                Dim rp As CRepeat = CType(parentNode, CRepeat)
                rp.StartID = CType(node.Parent.Nodes(0).Tag, CJobObject).ID
                rp.EndID = CType(node.Parent.Nodes(node.Parent.Nodes.Count - 1).Tag, CJobObject).ID
            ElseIf (parentNode.GetType() Is GetType(CConditional)) Then

            Else

            End If
        End If
    End Sub
    Private Sub UpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpToolStripMenuItem.Click
        If (m_SelectedNodes.Count >= 1) Then
            Dim tmp As ArrayList = New ArrayList()
            RemoveSelectedBackground(m_SelectedNodes)
            For i = 0 To m_SelectedNodes.Count - 1
                Dim res As TreeNode = MoveNodeUp(m_SelectedNodes(i))
                If (res Is m_SelectedNodes(i)) Then
                    GoTo exitsub
                End If
                tmp.Add(res)
            Next
            m_SelectedNodes.Clear()
            m_SelectedNodes.AddRange(tmp)
            tmp.Clear()
exitsub:
            AddSelectedBackground(m_SelectedNodes)
            UpdateStartEndID(m_SelectedNodes(0))
        End If
    End Sub

    Private Sub DownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownToolStripMenuItem.Click
        If (m_SelectedNodes.Count >= 1) Then
            Dim tmp As ArrayList = New ArrayList()
            RemoveSelectedBackground(m_SelectedNodes)
            For i = m_SelectedNodes.Count - 1 To 0 Step -1
                Dim res As TreeNode = MoveNodeDown(m_SelectedNodes(i))
                If (res Is m_SelectedNodes(i)) Then
                    GoTo exitsub
                End If
                tmp.Add(res)
            Next
            m_SelectedNodes.Clear()
            m_SelectedNodes.AddRange(tmp)
            tmp.Clear()
exitsub:
            AddSelectedBackground(m_SelectedNodes)
            UpdateStartEndID(m_SelectedNodes(0))
        End If
    End Sub

    Private Sub TopToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TopToolStripMenuItem.Click
        If (m_SelectedNodes.Count >= 1) Then
            Dim tmp As ArrayList = New ArrayList()
            RemoveSelectedBackground(m_SelectedNodes)
            For i = m_SelectedNodes.Count - 1 To 0 Step -1
                Dim res As TreeNode = MoveNodeTop(m_SelectedNodes(i))
                If (res Is m_SelectedNodes(i)) Then
                    GoTo exitsub
                End If
                tmp.Add(res)
            Next
            m_SelectedNodes.Clear()
            m_SelectedNodes.AddRange(tmp)
            tmp.Clear()
exitsub:
            AddSelectedBackground(m_SelectedNodes)
            UpdateStartEndID(m_SelectedNodes(0))
        End If
    End Sub

    Private Sub BottomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BottomToolStripMenuItem.Click
        If (m_SelectedNodes.Count >= 1) Then
            Dim tmp As ArrayList = New ArrayList()
            RemoveSelectedBackground(m_SelectedNodes)
            For i = 0 To m_SelectedNodes.Count - 1
                Dim res As TreeNode = MoveNodeBottom(m_SelectedNodes(i))
                If (res Is m_SelectedNodes(i)) Then
                    GoTo exitsub
                End If
                tmp.Add(res)
            Next
            m_SelectedNodes.Clear()
            m_SelectedNodes.AddRange(tmp)
            tmp.Clear()
exitsub:
            AddSelectedBackground(m_SelectedNodes)
            UpdateStartEndID(m_SelectedNodes(0))
        End If
    End Sub

    Private m_isClick As Boolean = False
    Private m_FirstPoint As Point
    Private Sub Panel11_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_isClick = True
        m_FirstPoint = e.Location
    End Sub

    Private Sub Panel11_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_isClick = False
    End Sub

    Private Sub Panel11_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_isClick = True) Then
            If (m_FirstPoint.X > e.Location.X) Then
                Me.Left = Me.Left - (m_FirstPoint.X - e.Location.X)
            ElseIf (m_FirstPoint.X < e.Location.X) Then
                Me.Left = Me.Left - (m_FirstPoint.X - e.Location.X)
            End If
            If (m_FirstPoint.Y > e.Location.Y) Then
                Me.Top = Me.Top - (m_FirstPoint.Y - e.Location.Y)
            ElseIf (m_FirstPoint.Y < e.Location.Y) Then
                Me.Top = Me.Top - (m_FirstPoint.Y - e.Location.Y)
            End If
        End If
    End Sub

    Private Sub FJobManager_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        chkRuler.Checked = m_Ruler.Visible
        m_Ruler.SpotSize = m_Param.LaserRecipe(m_LaserRecipeSelected).SpotSize
        m_Ruler.ShowRuler()
        m_Ruler.SpotVisible = True

        If m_Param.Idx.System.SolderIdx = 0 Then
            rbFeederOpt_Click(rbFeederOpt0, Nothing)
            rbFeederOpt0.Checked = True
        ElseIf m_Param.Idx.System.SolderIdx = 1 Then
            rbFeederOpt_Click(rbFeederOpt1, Nothing)
            rbFeederOpt1.Checked = True
        ElseIf m_Param.Idx.System.SolderIdx = 2 Then
            rbFeederOpt_Click(rbFeederOpt2, Nothing)
            rbFeederOpt2.Checked = True
        ElseIf m_Param.Idx.System.SolderIdx = 3 Then
            rbFeederOpt_Click(rbFeederOpt3, Nothing)
            rbFeederOpt3.Checked = True
        End If

        If m_Param.Idx.System.SolderLaserIdx = 0 Then
            rbLaserOpt_Click(rbLaserOpt0, Nothing)
            rbLaserOpt0.Checked = True
        ElseIf m_Param.Idx.System.SolderLaserIdx = 1 Then
            rbLaserOpt_Click(rbLaserOpt1, Nothing)
            rbLaserOpt1.Checked = True
        ElseIf m_Param.Idx.System.SolderLaserIdx = 2 Then
            rbLaserOpt_Click(rbLaserOpt2, Nothing)
            rbLaserOpt2.Checked = True
        ElseIf m_Param.Idx.System.SolderLaserIdx = 3 Then
            rbLaserOpt_Click(rbLaserOpt3, Nothing)
            rbLaserOpt3.Checked = True
        End If

    End Sub

    Private Sub FJobManager_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown

        If (My.Computer.Screen.WorkingArea.Height >= 1040) Then
            Me.Top = 0
        Else
            Me.Top = -12
        End If
    End Sub

    Private Sub rbFeederOpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFeederOpt3.Click, rbFeederOpt2.Click, rbFeederOpt1.Click, rbFeederOpt0.Click
        Try
            Dim radio As RadioButtonEx = CType(sender, RadioButtonEx)
            Select Case radio.Name
                Case rbFeederOpt0.Name
                    If (m_FeederRecipeSelected = 0) Then
                        Exit Sub
                    End If
                    m_FeederRecipeSelected = 0
                Case rbFeederOpt1.Name
                    If (m_FeederRecipeSelected = 1) Then
                        Exit Sub
                    End If
                    m_FeederRecipeSelected = 1
                Case rbFeederOpt2.Name
                    If (m_FeederRecipeSelected = 2) Then
                        Exit Sub
                    End If
                    m_FeederRecipeSelected = 2
                Case rbFeederOpt3.Name
                    If (m_FeederRecipeSelected = 3) Then
                        Exit Sub
                    End If
                    m_FeederRecipeSelected = 3
                Case Else
                    m_FeederRecipeSelected = 0
            End Select
            txtForwardDelay.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay.ToString()
            txtForwardSpeedPercent1.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed1.ToString()
            txtForwardSpeedPercent2.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed2.ToString()
            txtForwardDistance1.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance1.ToString()
            txtForwardDistance2.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance2.ToString()
            txtBackwardDelay.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDelay.ToString()
            txtBackwardSpeedPercent.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardSpeed.ToString()
            txtBackwardDistancemm.Text = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDistance.ToString()
        Catch ex As Exception
            FMessageBox.Show("An error occurred while loading feeder parameter option." & vbCrLf & "(加載進錫器參數選件時發生錯誤。)", "rbFeederOpt_Click message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub rbLaserOpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbLaserOpt7.Click, rbLaserOpt6.Click, rbLaserOpt5.Click, rbLaserOpt4.Click, rbLaserOpt3.Click, rbLaserOpt2.Click, rbLaserOpt1.Click, rbLaserOpt0.Click
        Try
            Dim radio As RadioButtonEx = CType(sender, RadioButtonEx)
            Select Case radio.Name
                Case rbLaserOpt0.Name
                    If (m_LaserRecipeSelected = 0) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 0
                Case rbLaserOpt1.Name
                    If (m_LaserRecipeSelected = 1) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 1
                Case rbLaserOpt2.Name
                    If (m_LaserRecipeSelected = 2) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 2
                Case rbLaserOpt3.Name
                    If (m_LaserRecipeSelected = 3) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 3
                Case rbLaserOpt4.Name
                    If (m_LaserRecipeSelected = 4) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 4
                Case rbLaserOpt5.Name
                    If (m_LaserRecipeSelected = 5) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 5
                Case rbLaserOpt6.Name
                    If (m_LaserRecipeSelected = 6) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 6
                Case rbLaserOpt7.Name
                    If (m_LaserRecipeSelected = 7) Then
                        Exit Sub
                    End If
                    m_LaserRecipeSelected = 7

                Case Else
                    m_LaserRecipeSelected = 0
            End Select
            tbPower0.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(0) * 10
            tbPower1.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(1) * 10
            tbPower2.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(2) * 10
            tbPower3.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(3) * 10
            tbPower4.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(4) * 10
            tbPower5.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(5) * 10
            tbPower6.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(6) * 10
            tbPower7.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(7) * 10
            tbPower8.Value = m_Param.LaserRecipe(m_LaserRecipeSelected).Power(8) * 10
            txtIntervalTime.Text = m_Param.LaserRecipe(m_LaserRecipeSelected).Interval.ToString()
            txtSpotSize.Text = m_Param.LaserRecipe(m_LaserRecipeSelected).SpotSize.ToString()
            If (m_Ruler IsNot Nothing) Then
                m_Ruler.SpotSize = m_Param.LaserRecipe(m_LaserRecipeSelected).SpotSize
            End If

        Catch ex As Exception
            FMessageBox.Show("An error occurred while loading laser parameter option." & vbCrLf & "(加載雷射參數選項時發生錯誤。)", "rbLaserOpt_Click message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub btnSaveFeeder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveFeeder.Click
        Try
            m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay = CInt(txtForwardDelay.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed1 = CInt(txtForwardSpeedPercent1.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed2 = CDbl(txtForwardSpeedPercent2.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance1 = CDbl(txtForwardDistance1.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance2 = CDbl(txtForwardDistance2.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDelay = CInt(txtBackwardDelay.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardSpeed = CDbl(txtBackwardSpeedPercent.Text)
            m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDistance = CDbl(txtBackwardDistancemm.Text)
            m_Param.SaveFeederRecipe(CProject.PROJECT_PATH & m_CurProject.Key)

            m_Param.Idx.System.SolderIdx = m_FeederRecipeSelected
            Call m_Param.WriteDataToFile(MCS_SRC_DIRECTORY & "User\Product\Reserved\Parameter.xml", "")
            Try
                MRuler.Save(m_Ruler, "D:\DataSettings\LaserSolder\Setting\Ruler.set")
            Catch ex As Exception

            End Try
        Catch ex As Exception
            FMessageBox.Show("An error occurred while saving feeder parameter option." & vbCrLf & "(保存進錫器參數選項時發生錯誤。)", "Save Feeder Recipe message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub btnSaveLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLaser.Click
        Try
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(0) = CDbl(tbPower0.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(1) = CDbl(tbPower1.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(2) = CDbl(tbPower2.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(3) = CDbl(tbPower3.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(4) = CDbl(tbPower4.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(5) = CDbl(tbPower5.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(6) = CDbl(tbPower6.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(7) = CDbl(tbPower7.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Power(8) = CDbl(tbPower8.Value / 10.0)
            m_Param.LaserRecipe(m_LaserRecipeSelected).Interval = CInt(txtIntervalTime.Text)
            m_Param.LaserRecipe(m_LaserRecipeSelected).SpotSize = CInt(txtSpotSize.Text)
            m_Param.SaveLaserRecipe(CProject.PROJECT_PATH & m_CurProject.Key)
            m_Ruler.SpotSize = m_Param.LaserRecipe(m_LaserRecipeSelected).SpotSize

            m_Param.Idx.System.SolderLaserIdx = m_LaserRecipeSelected
            Call m_Param.WriteDataToFile(MCS_SRC_DIRECTORY & "User\Product\Reserved\Parameter.xml", "")
            Try
                MRuler.Save(m_Ruler, "D:\DataSettings\LaserSolder\Setting\Ruler.set")
            Catch ex As Exception

            End Try
        Catch ex As Exception
            FMessageBox.Show("An error occurred while saving laser parameter option." & vbCrLf & "(保存雷射參數選項時發生錯誤。)", "Save Laser Recipe message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub FJobManager_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If (FMessageBox.Show("Are you sure you want to close job window?" & vbCrLf & "(確定退出作業程序畫面嗎?)", "Close job window", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            Try
                TimerWorkholderValue.Enabled = False
                TimerGetImagePoint.Enabled = False
                If (chkRecord.Checked = True) Then
                    ImageDisplay1.RecordStop = True
                End If
                m_RulerColor = m_Ruler.Color
                Call ImageDisplay1.StopLive()
                m_Param.WriteLog(CProject.PROJECT_PATH & m_CurProject.Key, m_OldParam)
                m_Ruler.Dispose()
                m_LaserAperture.Dispose()
            Catch ex As Exception
            End Try
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub chkRuler_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRuler.CheckedChanged
        m_Ruler.Visible = chkRuler.Checked
    End Sub
    Private m_AxisMove As Double = 1
    Private Sub rbX1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbX100.Click, rbX10.Click, rbX1.Click
        Dim chk As RadioButtonEx = CType(sender, RadioButtonEx)
        Select Case chk.Name
            Case rbX1.Name
                m_AxisMove = 1
            Case rbX10.Name
                m_AxisMove = 10
            Case rbX100.Name
                m_AxisMove = 100
            Case Else
        End Select
        txtDistance.Text = ((CDbl(txtAxisUnit.Text)) * m_AxisMove).ToString("F3")
    End Sub
    Private Sub txtDiscreteMoveUnit_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAxisUnit.KeyUp
        If (txtAxisUnit.Text = "") Then
            txtDistance.Text = "0"
        Else
            txtDistance.Text = (CDbl(txtAxisUnit.Text) * m_AxisMove).ToString("F3")
        End If

    End Sub

    Private Sub btnPositionAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPositionAdd.Click
        Dim axisID As Integer
        Dim rStatus As enumMotionFlag
        Dim target As Double
        Dim pSpeed As Double
        Try
            pSpeed = CDbl(txtSpeed.Text) / 100
        Catch ex As Exception

        End Try
        If pSpeed >= 1 Then
            pSpeed = 1
        ElseIf pSpeed <= 0 Then
            pSpeed = 0.1
        End If
        If (rbActiveAxisX.Checked) Then
            axisID = enumAxis.WorkholderX
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target + CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisY.Checked) Then
            axisID = enumAxis.WorkholderY
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target + CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisZ.Checked) Then
            axisID = enumAxis.WorkholderZ
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target + CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisR.Checked) Then

        ElseIf (rbFeed.Checked) Then
            axisID = enumAxis.FeederZ
            m_Motion.SetPositionOffset(axisID, 0)
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target + CDbl(txtDistance.Text / m_ShowScale)
            End If
        End If

        If (rbActiveAxisX.Checked) OrElse (rbActiveAxisY.Checked) OrElse (rbActiveAxisZ.Checked) OrElse (rbFeed.Checked) Then
            Do
                Call System.Windows.Forms.Application.DoEvents()
                m_Motion.IsExternalParameters(axisID) = False
                Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                If rStatus = enumMotionFlag.eSent Then
                    Exit Do
                ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                    Call MsgBox("行程超過軟體極限")
                    Exit Do
                End If
            Loop
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Exit Do

                End If
            Loop
        End If

    End Sub

    Private Sub btnPositionMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPositionMinus.Click
        Dim axisID As Integer
        Dim rStatus As enumMotionFlag
        Dim target As Double
        Dim pSpeed As Double
        Try
            pSpeed = CDbl(txtSpeed.Text) / 100
        Catch ex As Exception

        End Try
        If pSpeed >= 1 Then
            pSpeed = 1
        ElseIf pSpeed <= 0 Then
            pSpeed = 0.1
        End If
        If (rbActiveAxisX.Checked) Then
            axisID = enumAxis.WorkholderX
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target - CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisY.Checked) Then
            axisID = enumAxis.WorkholderY
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target - CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisZ.Checked) Then
            axisID = enumAxis.WorkholderZ
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target - CDbl(txtDistance.Text / m_ShowScale)
            End If
        ElseIf (rbActiveAxisR.Checked) Then

        ElseIf (rbFeed.Checked) Then
            axisID = enumAxis.FeederZ
            m_Motion.SetPositionOffset(axisID, 0)
            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                Call m_Motion.GetEncoder(axisID, target)
                target = target - CDbl(txtDistance.Text / m_ShowScale)
            End If
        End If

        If (rbActiveAxisX.Checked) OrElse (rbActiveAxisY.Checked) OrElse (rbActiveAxisZ.Checked) OrElse (rbFeed.Checked) Then
            Do
                Call System.Windows.Forms.Application.DoEvents()
                m_Motion.IsExternalParameters(axisID) = False
                Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                If rStatus = enumMotionFlag.eSent Then
                    Exit Do
                ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                    Call MsgBox("行程超過軟體極限")
                    Exit Do
                End If
            Loop
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Exit Do

                End If
            Loop
        End If
    End Sub

    Private Sub tvJobs_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles tvJobs.GiveFeedback
        If (e.Effect = DragDropEffects.Move) Then
            e.UseDefaultCursors = False
            Me.tvJobs.Cursor = Cursors.Default
        Else
            e.UseDefaultCursors = True
        End If
    End Sub

    Private Sub tvJobs_ItemDrag(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ItemDragEventArgs) Handles tvJobs.ItemDrag
        Try
            If (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count = 0) Then
                Exit Sub
            End If
            If (m_SelectedNodes(0) Is tvJobs.Nodes(0)) Then
                Exit Sub
            End If
            RemoveHandler tvJobs.AfterSelect, AddressOf tvJobs_AfterSelect
            m_DragNode = CType(e.Item, TreeNode)
            RemoveSelectedBackground(m_SelectedNodes)
            tvJobs.SelectedNode = m_DragNode
            imageListDrag.Images.Clear()
            imageListDrag.ImageSize = New Size(m_DragNode.Bounds.Size.Width + tvJobs.Indent + 5, m_DragNode.Bounds.Height * m_SelectedNodes.Count)
            Dim bmp As Bitmap = New Bitmap(m_DragNode.Bounds.Size.Width + tvJobs.Indent + 5, m_DragNode.Bounds.Height * m_SelectedNodes.Count)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.Clear(System.Drawing.ColorTranslator.FromHtml("#CAE1FF"))
            Dim job As CJobObject = CType(m_DragNode.Tag, CJobObject)
            If (job Is Nothing) Then
                Exit Sub
            End If
            Dim lst = (From n As TreeNode In m_SelectedNodes
                        Order By n.Index).ToList()
            g.DrawRectangle(Pens.DarkGray, 0, 0, bmp.Width - 1, bmp.Height - 1)
            For i = 0 To lst.Count - 1
                Dim node As TreeNode = CType(lst(i), TreeNode)
                job = CType(node.Tag, CJobObject)
                g.DrawImage(imageListTreeView.Images(node.ImageIndex), 0, node.Bounds.Height * i)
                g.DrawString(node.Text, tvJobs.Font, New SolidBrush(job.NoSelecteForceColor), CSng(tvJobs.Indent), node.Bounds.Height * i)
            Next
            lst.Clear()
            imageListDrag.Images.Add(bmp)
            Dim p As Point = tvJobs.PointToClient(Control.MousePosition)
            Dim dy As Integer = p.Y - m_DragNode.Bounds.Top + tvJobs.ItemHeight
            If (DragHelper.ImageList_BeginDrag(imageListDrag.Handle, 0, 0, dy)) Then
                tvJobs.DoDragDrop(bmp, DragDropEffects.Move)
                DragHelper.ImageList_EndDrag()
            End If
        Catch ex As Exception
            FMessageBox.Show("An error occurred while moving job." & vbCrLf & "(移動作業時發生錯誤。)", "tvJobs_ItemDrag error message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub tvJobs_DragOver(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvJobs.DragOver
        Try
            Dim formP As Point = TabControl1.PointToClient(New Point(e.X, e.Y))
            DragHelper.ImageList_DragMove(formP.X - Me.tvJobs.Left, formP.Y - tvJobs.Top)
            Dim dropNode As TreeNode = tvJobs.GetNodeAt(tvJobs.PointToClient(New Point(e.X, e.Y)))
            If (dropNode Is Nothing) Then
                e.Effect = DragDropEffects.None
                Exit Sub
            End If
            e.Effect = DragDropEffects.Move
            If (m_TempDropNode IsNot dropNode) Then
                DragHelper.ImageList_DragShowNolock(False)
                tvJobs.SelectedNode = dropNode
                DragHelper.ImageList_DragShowNolock(True)
                m_TempDropNode = dropNode
            End If
            Dim tmpNode As TreeNode = dropNode
            While tmpNode.Parent IsNot Nothing
                If (tmpNode.Parent Is m_DragNode) Then e.Effect = DragDropEffects.None
                tmpNode = tmpNode.Parent
            End While
        Catch ex As Exception
            FMessageBox.Show("An error occurred while moving job." & vbCrLf & "(移動作業時發生錯誤。)", "tvJobs_DragOver error message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub tvJobs_DragLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tvJobs.DragLeave
        DragHelper.ImageList_DragLeave(tvJobs.Handle)
        TimerDragTreeView.Enabled = False
    End Sub

    Private Sub TimerDragTreeView_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerDragTreeView.Tick
        Try
            Dim pt As Point = TabControl1.PointToClient(Control.MousePosition)
            Dim node As TreeNode = tvJobs.GetNodeAt(pt)
            If (node Is Nothing) Then Exit Sub
            If (pt.Y < 30) Then
                If (node.PrevVisibleNode IsNot Nothing) Then
                    node = node.PrevVisibleNode
                    DragHelper.ImageList_DragShowNolock(False)
                    node.EnsureVisible()
                    tvJobs.Refresh()
                    DragHelper.ImageList_DragShowNolock(True)
                End If
            ElseIf (pt.Y > tvJobs.Size.Height - 30) Then
                If (node.NextVisibleNode IsNot Nothing) Then
                    node = node.NextVisibleNode
                    DragHelper.ImageList_DragShowNolock(False)
                    node.EnsureVisible()
                    tvJobs.Refresh()
                    DragHelper.ImageList_DragShowNolock(True)
                End If
            End If
        Catch
        End Try
    End Sub

    Private Sub tvJobs_DragEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvJobs.DragEnter
        DragHelper.ImageList_DragEnter(tvJobs.Handle, e.X - tvJobs.Left, e.Y - tvJobs.Top)
        TimerDragTreeView.Enabled = True
    End Sub

    Private Sub FindMaxLevel(ByVal node As TreeNode, ByRef level As Integer)
        If (node.Level > level) Then
            level = node.Level
        End If
        For i = 0 To node.Nodes.Count - 1
            FindMaxLevel(node.Nodes(i), level)
        Next

    End Sub

    Private Sub tvJobs_DragDrop(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles tvJobs.DragDrop
        Try
            tvJobs.BeginUpdate()
            DragHelper.ImageList_DragLeave(tvJobs.Handle)
            Dim dropNode As TreeNode = tvJobs.GetNodeAt(tvJobs.PointToClient(New Point(e.X, e.Y)))
            Dim chk = (From tn As TreeNode In m_SelectedNodes
                        Where tn Is dropNode).ToList()

            If (m_DragNode IsNot dropNode OrElse chk.Count = 0) Then
                Dim job As CJobObject = CType(dropNode.Tag, CJobObject)
                If (dropNode.Parent Is Nothing OrElse job.CanHasChild) Then
                    Dim node As TreeNode
                    Dim level As Integer = 0
                    For i = 0 To m_SelectedNodes.Count - 1
                        node = CType(m_SelectedNodes(i), TreeNode)
                        FindMaxLevel(node, level)
                    Next
                    node = CType(m_SelectedNodes(0), TreeNode)
                    level = level - node.Level

                    If (dropNode.Level + level >= CListJob.MAX_LEVEL) Then
                        FMessageBox.Show("Max level supported." & vbCrLf & "(最大支持水平。)", "Add job message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        For i = 0 To m_SelectedNodes.Count - 1
                            node = CType(m_SelectedNodes(i), TreeNode)

                            If (node.Parent Is Nothing) Then
                                tvJobs.Nodes.Remove(node)
                            Else
                                node.Parent.Nodes.Remove(node)
                            End If
                            dropNode.Nodes.Add(node)
                        Next
                    End If
                    m_SelectedNodes.Clear()
                    m_SelectedNodes.Add(dropNode)
                    dropNode.ExpandAll()
                    m_DragNode = Nothing
                    TimerDragTreeView.Enabled = False
                End If
            End If
            tvJobs.EndUpdate()
            AddHandler tvJobs.AfterSelect, AddressOf tvJobs_AfterSelect
            m_StartIdxSelected = dropNode.Index
        Catch ex As Exception
            FMessageBox.Show("An error occurred while moving job." & vbCrLf & "(移動作業時發生錯誤。)", "tvJobs_DragDrop error message", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub tvJobs_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles tvJobs.AfterSelect
        AddSelectedBackground(m_SelectedNodes)
        If (m_SelectedNodes.Count > 0) Then
            tvJobs.SelectedNode = m_SelectedNodes(m_SelectedNodes.Count - 1)
        Else
            tvJobs.SelectedNode = Nothing
        End If
    End Sub

    Private Sub tvJobs_BeforeSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles tvJobs.BeforeSelect
        RemoveSelectedBackground(m_SelectedNodes)
        tvJobs.SelectedNode = Nothing
    End Sub

    Private m_FeedMaxVelocity As Double = 100000
    Private m_AccDec As Double = 9800000

    Private Sub chkSolderingTime_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSolderingTime.CheckedChanged
        ptbSolderingTime.Visible = chkSolderingTime.Checked

        If (chkSolderingTime.Checked = True) Then

            Dim pFeedVelocity As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed1 / 100 * m_FeedMaxVelocity / 1000
            Dim pAccDec As Double = m_AccDec / 1000
            Dim ForwardTime1 As Double = FMain.TotalTime(pFeedVelocity, pAccDec, m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance1) * 1000

            pFeedVelocity = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed2 / 100 * m_FeedMaxVelocity / 1000
            Dim ForwardTime2 As Double = FMain.TotalTime(pFeedVelocity, pAccDec, m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance2) * 1000

            pFeedVelocity = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardSpeed / 100 * m_FeedMaxVelocity / 1000
            Dim BackwardTime2 As Double = FMain.TotalTime(pFeedVelocity, pAccDec, m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDistance) * 1000


            m_SolderingTime = New CSolderingTime()
            m_SolderingTime.Interval = m_Param.LaserRecipe(m_LaserRecipeSelected).Interval

            m_SolderingTime.LaserOnTime = 0
            m_SolderingTime.LaserOffTime = m_Param.LaserRecipe(m_LaserRecipeSelected).Interval * 9


            m_SolderingTime.ForwardDelayEnd = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay
            m_SolderingTime.ForwardMoveEnd(1) = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay + ForwardTime1 + ForwardTime2

            m_SolderingTime.BackwardDelayEnd = m_SolderingTime.ForwardMoveEnd(1) + m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDelay
            m_SolderingTime.BackwardMoveEnd = m_SolderingTime.BackwardDelayEnd + BackwardTime2







            'm_SolderingTime.ForwardDelayEnd = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay
            'm_SolderingTime.ForwardMoveEnd(1) = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay + 350

            'm_SolderingTime.BackwardDelayEnd = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay + 350 + m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDelay
            'm_SolderingTime.BackwardMoveEnd = m_SolderingTime.BackwardDelayEnd + 50








            DrawSolderingTime()
        End If
    End Sub
    Private Sub DrawSolderingTime()
        Try
            Dim bmp As Bitmap = New Bitmap(ptbSolderingTime.Width, ptbSolderingTime.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            Dim pen1 As Pen = New Pen(Brushes.Blue, 1)
            Dim pen2 As Pen = New Pen(Brushes.Orange, 5)
            Dim pen3 As Pen = New Pen(Brushes.Lime, 4)
            Dim pen4 As Pen = New Pen(Brushes.SkyBlue, 4)
            g.Clear(Color.Transparent)
            Dim MaxTime As Double = 0
            Dim Num As Integer = 10
            Dim scale As Double = 1.0
            MaxTime = IIf(m_SolderingTime.BackwardMoveEnd > m_SolderingTime.LaserOffTime, m_SolderingTime.BackwardMoveEnd, m_SolderingTime.LaserOffTime)
            Dim width As Integer = m_SolderingTime.LaserOffTime / 9
            If (MaxTime <> 0 AndAlso width <> 0) Then
                Num = MaxTime / width
                scale = CDbl(bmp.Width / MaxTime)
                g.DrawLine(pen2, CInt(m_SolderingTime.LaserOnTime * scale), bmp.Height - 18, CInt(m_SolderingTime.LaserOffTime * scale), bmp.Height - 18)
                g.DrawLine(pen3, CInt(m_SolderingTime.ForwardDelayEnd * scale), bmp.Height - 11, CInt(m_SolderingTime.ForwardMoveEnd(1) * scale), bmp.Height - 11)
                g.DrawLine(pen4, CInt(m_SolderingTime.BackwardDelayEnd * scale), bmp.Height - 4, CInt(m_SolderingTime.BackwardMoveEnd * scale), bmp.Height - 4)

                g.DrawRectangle(pen1, New Rectangle(1, bmp.Height - 20, bmp.Width - 2, 19))

                For i = 1 To Num
                    g.DrawLine(pen1, CInt(i * width * scale), bmp.Height - 2, CInt(i * width * scale), bmp.Height - 19)
                Next
            End If

            bmp.MakeTransparent()
            ptbSolderingTime.Image = bmp
            g.Dispose()
            pen1.Dispose()
            pen2.Dispose()
            pen3.Dispose()
            pen4.Dispose()
            System.GC.Collect()
            System.GC.WaitForPendingFinalizers()
        Catch ex As Exception
            FMessageBox.ShowError("There was an error in the drawing process." & vbCrLf & "(繪圖過程中出現錯誤。)", "Draw Soldering Time error", True, ex)
        End Try
    End Sub

    Private m_IsThreadFinished = True
    Private m_IsThreadStarted = False

    Private Sub btnSoldering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSoldering.Click
        Dim ctrlName As String
        ctrlName = CType(sender, Control).Name
        Do
        Loop Until m_IsThreadFinished = True
        m_IsThreadStarted = False
        System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf SolderingThread), ctrlName)
    End Sub
    'Public Shared StateInfo As String = ""
    Public m_Old_AO_Buff_Ch0() As Short
    Public m_Old_Freq As Double = 0
    Public Function LaserParamSetting(ByVal pCutIdx As Integer) As Boolean
        Try

            Dim freq As Double = 1 * 1000 / (m_Param.LaserRecipe(pCutIdx).Interval * 9)

            Dim AO_Buff_Ch0(0 To (9 - 1)) As Short

            For i = 0 To AO_Buff_Ch0.Length - 1
                AO_Buff_Ch0(i) = CType((m_Param.LaserRecipe(pCutIdx).Power(i)), Short)
            Next

            Dim pHaveToChangeParam As Boolean = False

            If m_Old_AO_Buff_Ch0 Is Nothing Then
                pHaveToChangeParam = True
            Else
                For i = 0 To AO_Buff_Ch0.Length - 1
                    If AO_Buff_Ch0(i) <> m_Old_AO_Buff_Ch0(i) Then
                        pHaveToChangeParam = True
                        Exit For
                    End If
                Next
            End If


            If m_Old_AO_Buff_Ch0 Is Nothing OrElse pHaveToChangeParam = True Then
                m_Old_AO_Buff_Ch0 = AO_Buff_Ch0
                pHaveToChangeParam = True
            End If

            If m_Old_Freq <> freq Then
                m_Old_Freq = freq
                pHaveToChangeParam = True
            End If
            Dim pPrepareOK As Boolean = True

            'For i = 0 To AO_Buff_Ch0.Length - 2
            '    AO_Buff_Ch0(i) = CType((i / (AO_Buff_Ch0.Length - 2)) * 4095, Short)    'CType((Math.Sin(CDbl(i) / (AO_Buff_Ch0.Length - 1) * Math.PI) * 4095), Short)
            'Next
            'AO_Buff_Ch0(0) = AO_Buff_Ch0(1)
            'AO_Buff_Ch0(AO_Buff_Ch0.Length - 1) = 0

            'pHaveToChangeParam = True

            pHaveToChangeParam = True
            If pHaveToChangeParam = True Then
                m_DA.AnalogOut.StopWaveform()
                'pPrepareOK = m_DA.AnalogOut.PrepareWaveform(AO_Buff_Ch0, freq, enumWaveformParamType.Frequemcy)
                pPrepareOK = m_DA.AnalogOut.PrepareWaveformSolder(AO_Buff_Ch0, (m_Param.LaserRecipe(pCutIdx).Interval * 9), enumWaveformParamType.Time)

                m_DA.AnalogOut.StartWaveform(0)
            End If
            If pPrepareOK = True Then
                LaserParamSetting = True
            Else
                LaserParamSetting = False
            End If
        Catch ex As Exception
            LaserParamSetting = False
            m_Old_AO_Buff_Ch0 = Nothing
            m_Old_Freq = 0
        End Try
    End Function
    Private Sub SolderingThread(ByVal StateInfo As Object)
        Try
            m_IsThreadFinished = False
            Dim ctrlName As String

            ctrlName = StateInfo
            Select Case ctrlName
                Case "btnSoldering"
                    Dim axisID1 = enumAxis.WorkholderX
                    Dim IO As Integer
                    Dim IOOnOff As Integer = 1
                    IO = 0
                    Try
                        Call UIProtect(False)
                        Dim pLaserOK As Boolean = LaserParamSetting(m_LaserRecipeSelected)
                        If pLaserOK = False Then
                            Dim cc2 As Integer = 0
                        End If

                        ' m_Motion.IOTest(axisID1, IO)

                        m_Motion.MoveAdvTableEMGStop = False
                        Dim pFeedForwardSpeedPercent As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed1 / 100
                        Dim pFeedForwardDistance As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance1 * 1000

                        Dim pFeedForwardSpeedPercent2 As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed2 / 100
                        Dim pFeedForwardDistance2 As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance2 * 1000

                        Dim pFeedForwardDelayTime As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay

                        Dim pFeedBackwardSpeedPercent As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardSpeed / 100
                        Dim pFeedBackwardDistance As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDistance * 1000
                        Dim pFeedBackwardDelayTIme As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).BackwardDelay
                        Dim pFeedEnable = True

                        m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay = CInt(txtForwardDelay.Text)

                        m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardSpeed1 = CInt(txtForwardSpeedPercent1.Text)
                        m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDistance1 = CDbl(txtForwardDistance1.Text)




                        Dim nowAxis2Encoder As Double
                        m_Motion.GetEncoder(FMain.axisID2_Adv, nowAxis2Encoder)
                        Dim Path_rtnData As List(Of String)
                        Dim Acc As Double = 9800000 * m_FeederAccScale
                        Dim Dec As Double = 9800000 * m_FeederAccScale
                        Dim Velocity As Double = 100000 * pFeedForwardSpeedPercent
                        Dim Velocity2 As Double = 100000 * pFeedForwardSpeedPercent2
                        Dim BackVelocity As Double = 100000 * pFeedBackwardSpeedPercent
                        Path_rtnData = TranslatePathToAdvanceSolder(
                                                                    Acc,
                                                                    Dec,
                                                                    Velocity,
                                                                    Acc,
                                                                    Dec,
                                                                    Velocity2,
                                                                    Acc,
                                                                    Dec,
                                                                    BackVelocity,
                                                                    pFeedForwardDelayTime,
                                                                    pFeedForwardDistance,
                                                                    pFeedForwardDistance2,
                                                                    pFeedBackwardDistance,
                                                                    pFeedBackwardDelayTIme,
                                                                    pFeedEnable,
                                                                   FMain.axisID2_Adv)

                        Try
                            Dim pSysProcessNum As Integer = 1200

                            Dim bStatus As enumMotionFlag
                            Dim pTime As Double

                            Do
                                Select Case pSysProcessNum
                                    Case 1200
                                        If Path_rtnData(0) = "False_Translate" Then
                                            Exit Do
                                        Else
                                            axisID1 = enumAxis.WorkholderX
                                            IOOnOff = 1
                                            m_Motion.IOTest(axisID1, IO, IOOnOff)

                                            pTime = m_Timer.GetMilliseconds
                                            pSysProcessNum = 1205
                                        End If

                                    Case 1205
                                        If m_Timer.GetMilliseconds - pTime >= 10 Then
                                            Call m_Motion.MoveAdvTablePoint(FMain.axisID1_Adv, FMain.axisID2_Adv, Path_rtnData, bStatus)

                                            If bStatus = enumMotionFlag.eSent Then
                                                pSysProcessNum = 1210
                                            End If
                                        End If


                                    Case 1210
                                        If (m_Motion.MoveAdvPointTableIsThreadStarted) Then
                                            If m_Motion.MoveAdvPointTableIsThreadFinished Then
                                                If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                                    Exit Do
                                                Else
                                                    Exit Do
                                                End If

                                            End If
                                        End If
                                End Select
                                Thread.Sleep(1)
                            Loop
                            'Thread.Sleep(12000)

                            'Do
                            '    Dim cc As Integer = 11
                            'Loop
                            Do
                                Dim line_idx As Integer
                                If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                    axisID1 = enumAxis.WorkholderY
                                    If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                        axisID1 = enumAxis.WorkholderX
                                        If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                            If m_Motion.ChkAdvanceTableStop(FMain.axisID1_Adv, FMain.axisID2_Adv, line_idx) = enumMotionFlag.eReady Then
                                                Exit Do
                                            End If
                                        End If
                                    End If
                                Else
                                    Exit Do
                                End If
                                Thread.Sleep(1)
                                Application.DoEvents()
                            Loop

                            Do
                                If m_Timer.GetMilliseconds - pTime >= (m_Param.LaserRecipe(m_LaserRecipeSelected).Interval * 10) + 10 Then
                                    Exit Do
                                End If
                            Loop



                        Catch ex As Exception

                        End Try
                    Catch ex As Exception
                    Finally
                        axisID1 = enumAxis.WorkholderX
                        IOOnOff = 0
                        m_Motion.IOTest(axisID1, IO, IOOnOff)
                        Call UIProtect(True)
                    End Try
                Case "btnRunLaser"
                    Dim IOEnable As Integer = 0
                    Dim IOTrg As Integer = 1
                    Try

                        If m_IsLaser = False Then
                            m_IsLaser = True
                            Dim pLaserParamOK As Boolean = LaserParamSetting(m_LaserRecipeSelected)
                            Dim pTime As Double
                            If pLaserParamOK = True Then
                                Dim axisID1 = enumAxis.WorkholderX


                                m_Motion.IOTest(axisID1, IOEnable, 1) 'ON
                                'Thread.Sleep(5000)
                                m_Motion.IOTest(axisID1, IOTrg, 1)
                                'm_Laser.LaserSignalON()
                                pTime = m_Timer.GetMilliseconds
                                Do
                                    If m_Timer.GetMilliseconds - pTime >= (10) Then
                                        Exit Do
                                    End If
                                    If m_StopLaser = True Then
                                        Exit Do
                                    End If
                                    Application.DoEvents()
                                    ' Thread.Sleep(1)
                                Loop
                                m_Motion.IOTest(axisID1, IOTrg, 0)
                                Do
                                    If m_StopLaser = True Then
                                        Exit Do
                                    End If
                                    If m_DA.AnalogOut.ChkStop = 1 Then
                                        Exit Do
                                    End If
                                Loop
                                Do
                                    If m_Timer.GetMilliseconds - pTime >= (m_Param.LaserRecipe(m_LaserRecipeSelected).Interval * 10) + 10 Then
                                        Exit Do
                                    End If
                                    If m_StopLaser = True Then
                                        Exit Do
                                    End If
                                    ' Thread.Sleep(1)
                                    Application.DoEvents()
                                Loop
                                m_Motion.IOTest(axisID1, IOEnable, 0) 'Off
                            Else

                            End If
                        End If

                    Catch ex As Exception
                        Try
                            Dim axisID1 = enumAxis.WorkholderX
                            m_Motion.IOTest(axisID1, IOEnable, 0) 'ON
                        Catch

                        End Try
                    Finally
                        m_StopLaser = False
                        m_IsLaser = False
                    End Try
                Case "btnRunFeeder"


                    Dim axisID1 = enumAxis.WorkholderX
                    Dim IO As Integer = 1
                    ' m_Motion.IOTest(axisID1, IO)

                    m_Motion.MoveAdvTableEMGStop = False
                    Dim pFeedForwardSpeedPercent As Double = CDbl(txtForwardSpeedPercent1.Text) / 100
                    Dim pFeedForwardDistance As Double = CDbl(txtForwardDistance1.Text) * 1000

                    Dim pFeedForwardSpeedPercent2 As Double = CDbl(txtForwardSpeedPercent2.Text) / 100
                    Dim pFeedForwardDistance2 As Double = CDbl(txtForwardDistance2.Text) * 1000

                    Dim pBackForwardSpeedPercent As Double = CDbl(txtBackwardSpeedPercent.Text) / 100
                    Dim pFeedBackwardDistance As Double = CDbl(txtBackwardDistancemm.Text) * 1000
                    Dim pFeedBackwardDelayTIme As Double = CDbl(txtBackwardDelay.Text)
                    Dim pFeedEnable As Double


                    Dim nowAxis2Encoder As Double
                    m_Motion.GetEncoder(FMain.axisID2_Adv, nowAxis2Encoder)
                    Dim Path_rtnData As List(Of String)
                    Dim Acc As Double = 9800000 * m_FeederAccScale '0.05
                    Dim Dec As Double = 9800000 * m_FeederAccScale
                    Dim Velocity As Double = 100000 * pFeedForwardSpeedPercent
                    Dim Velocity2 As Double = 100000 * pFeedForwardSpeedPercent2
                    Dim BackVelocity As Double = 100000 * pBackForwardSpeedPercent

                    Path_rtnData = TranslatePathToAdvanceSolder(
                                                                Acc,
                                                                Dec,
                                                                Velocity,
                                                                  Acc,
                                                                Dec,
                                                                Velocity2,
                                                                Acc,
                                                                Dec,
                                                                BackVelocity,
                                                                pFeedBackwardDelayTIme,
                                                                pFeedForwardDistance,
                                                                pFeedForwardDistance2,
                                                                pFeedBackwardDistance,
                                                                pFeedBackwardDelayTIme,
                                                                pFeedEnable,
                                                                FMain.axisID2_Adv)

                    Try
                        Dim pSysProcessNum As Integer = 1200

                        Dim bStatus As enumMotionFlag

                        Do
                            Select Case pSysProcessNum
                                Case 1200
                                    If Path_rtnData(0) = "False_Translate" Then
                                        Exit Do
                                    Else
                                        'm_Laser.LaserSignalON()

                                        Call m_Motion.MoveAdvTablePoint(FMain.axisID1_Adv, FMain.axisID2_Adv, Path_rtnData, bStatus)

                                        If bStatus = enumMotionFlag.eSent Then
                                            pSysProcessNum = 1210
                                        End If
                                    End If
                                Case 1210
                                    If (m_Motion.MoveAdvPointTableIsThreadStarted) Then
                                        If m_Motion.MoveAdvPointTableIsThreadFinished Then
                                            If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                                Exit Do
                                            Else
                                                Exit Do
                                            End If

                                        End If
                                    End If
                            End Select
                        Loop

                        Do
                            Dim line_idx As Double
                            If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                axisID1 = enumAxis.WorkholderY
                                If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                    axisID1 = enumAxis.WorkholderX
                                    If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                        If m_Motion.ChkAdvanceTableStop(FMain.axisID1_Adv, FMain.axisID2_Adv, line_idx) = enumMotionFlag.eReady Then
                                            axisID1 = enumAxis.WorkholderX
                                            IO = 0
                                            m_Motion.IOTest(axisID1, 0, IO)
                                            Exit Do
                                        End If
                                    End If
                                End If
                            Else
                                Exit Do
                            End If
                        Loop
                    Catch ex As Exception

                    End Try
            End Select

        Catch ex As Exception
        Finally
            m_IsThreadFinished = True
        End Try
    End Sub

    Public Function TranslatePathToAdvanceSolder(ByVal ForwardAcc As String, ByVal Forwarddec As String, ByVal ForwardVelocity As String, ByVal ForwardAcc2 As String, ByVal Forwarddec2 As String, ByVal ForwardVelocity2 As String, ByVal BackwardAcc As String, ByVal Backwarddec As String, ByVal BackwardVelocity As String, ByVal DelayTimeForWard As Double, ByVal Distance_Send As Double, ByVal Distance_Send2 As Double, ByVal Distance_Back As Double, ByVal DelayTimeBack As Double, ByVal FeedEnable As Boolean, ByVal AxisID2 As Double) As List(Of String)
        Dim error_list As New List(Of String)
        Try
            error_list.Add("False_Translate")
            Dim arrayList As New List(Of String)

            Dim ForWardMaxVelocity As String = ForwardVelocity
            Dim ForWardMaxVelocity2 As String = ForwardVelocity2
            Dim BackWardMaxVelocity As String = BackwardVelocity
            ForwardVelocity = (Convert.ToInt32(ForwardVelocity)).ToString()

            If DelayTimeForWard < 0 Then
                DelayTimeForWard = 0
            End If

            If Distance_Send < 0 Then
                Distance_Send = 0
            End If
            If Distance_Send2 < 0 Then
                Distance_Send2 = 0
            End If
            If Distance_Back < 0 Then
                Distance_Back = 0
            End If

            If DelayTimeBack < 0 Then
                DelayTimeBack = 0
            End If

            Dim Distance_Org As Double = 0

            Dim IO_CH As Integer = 1

            If (Distance_Send + Distance_Send2) - Distance_Back < 0 Then
                Distance_Org = Math.Abs((Distance_Send + Distance_Send2) - Distance_Back)
            End If
            Dim Axis2NowEncoder As Double
            m_Motion.GetEncoder(AxisID2, Axis2NowEncoder)
            ''SetOffset
            Dim axisId As Integer = enumAxis.FeederZ
            m_Motion.SetPositionOffset(axisId, Distance_Org)

            If Distance_Send > 0 Then
                If FeedEnable = True Then
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity + "," + (Distance_Org).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + "0" + "," + "," + "ON" + "," + "0" + "," + "1") '起始
                Else
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity + "," + (Distance_Org).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "0" + "," + "1") '起始
                End If
            End If

            If FeedEnable = True Then ' Trig
                arrayList.Add("Wait," + ",0," + (1).ToString + "," + "0" + ",,," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "1")
            Else
                arrayList.Add("Wait," + ",0," + (1).ToString + "," + "0" + ",,," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "1")
            End If
            If DelayTimeForWard > 0 Then
                If FeedEnable = True Then
                    arrayList.Add("Wait," + ",0," + (DelayTimeForWard - 1).ToString + "," + "0" + ",,," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "1") 'BackDelay
                Else
                    arrayList.Add("Wait," + ",0," + (DelayTimeForWard - 1).ToString + "," + "0" + ",,," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "1") 'BackDelay
                End If
            End If




            If Distance_Send > 0 Then
                If FeedEnable = True Then
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity + "," + (Distance_Org + Distance_Send).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + ForWardMaxVelocity + "," + "," + "OFF" + "," + "1") '起始
                Else
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity + "," + (Distance_Org + Distance_Send).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + ForWardMaxVelocity + "," + "," + "OFF" + "," + "1") '起始
                End If
            End If


            If Distance_Send2 > 0 Then
                If FeedEnable = True Then
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity2 + "," + (Distance_Org + Distance_Send + Distance_Send2).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + ForWardMaxVelocity2 + "," + "," + "OFF" + "," + "1") '起始
                Else
                    arrayList.Add("Line,ABS" + "," + ForWardMaxVelocity2 + "," + (Distance_Org + Distance_Send + Distance_Send2).ToString + "," + (Axis2NowEncoder).ToString + ",,," + ForwardAcc + "," + Forwarddec + "," + "0" + "," + ForWardMaxVelocity2 + "," + "," + "OFF" + "," + "1") '起始
                End If
            End If

            If DelayTimeBack > 0 Then
                arrayList.Add("Wait," + ",0," + (DelayTimeBack).ToString + "," + "0" + ",,," + "0" + "," + "0" + "," + "0" + "," + "0" + "," + "," + "OFF" + "," + "1") 'BackDelay
            End If

            If Distance_Back > 0 Then
                arrayList.Add("Line,ABS" + "," + BackWardMaxVelocity + "," + (Distance_Org + Distance_Send + Distance_Send2 - Distance_Back).ToString() + "," + (Axis2NowEncoder).ToString + ",,," + BackwardAcc + "," + Backwarddec + "," + BackWardMaxVelocity.ToString() + "," + "0" + "," + "," + "OFF" + "," + "1") '起始
            End If

            TranslatePathToAdvanceSolder = arrayList
        Catch ex As Exception
            TranslatePathToAdvanceSolder = error_list
        End Try
    End Function

    Private Sub chkRecord_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecord.CheckedChanged
        If (chkRecord.Checked = True) Then
            ImageDisplay1.Record = True
        Else
            ImageDisplay1.RecordStop = True
        End If
    End Sub

    Private Sub ShowRulerToolToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShowRulerToolToolStripMenuItem.Click
        Try
            If (m_Ruler IsNot Nothing) Then
                Dim fEditRuler As FRulerTool = New FRulerTool(m_Ruler)

                fEditRuler.Show()
            End If
        Catch
        End Try
    End Sub







    ''''''''''''''''''''''''''''''''''''''''''
    Private m_IsMoving As Boolean = False

    Private m_WorkholderXValueAdd As Double = 10
    Private m_WorkholderXMoveOK As Boolean = False

    Private Sub btnXYLeftContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx2.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderXMoveOK = True
            m_WorkholderXValueAdd = Math.Abs(m_WorkholderXValueAdd)
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderX

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    If m_WorkholderXMoveOK = True Then
                        m_WorkholderXMoveOK = False
                        Call m_Motion.GetCmd(axisID, target)
                        If m_WorkholderXValueAdd > 0 Then
                            target = m_Motion.SWMax(axisID)
                        Else
                            target = m_Motion.SWMin(axisID)
                        End If
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            m_Motion.IsExternalParameters(axisID) = False
                            Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                            If rStatus = enumMotionFlag.eSent Then
                                Exit Do
                            ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                                Exit Do
                            End If
                        Loop
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnLeftContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx2.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderX)
    End Sub


    Private Sub btnRightContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx4.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderXMoveOK = True
            m_WorkholderXValueAdd = Math.Abs(m_WorkholderXValueAdd) * -1
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderX

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    If m_WorkholderXMoveOK = True Then
                        m_WorkholderXMoveOK = False
                        Call m_Motion.GetCmd(axisID, target)
                        If m_WorkholderXValueAdd > 0 Then
                            target = m_Motion.SWMax(axisID)
                        Else
                            target = m_Motion.SWMin(axisID)
                        End If
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            m_Motion.IsExternalParameters(axisID) = False
                            Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                            If rStatus = enumMotionFlag.eSent Then
                                Exit Do
                            ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                                Exit Do
                            End If
                        Loop
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnRightContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx4.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderX)
    End Sub



    Private m_WorkholderYValueAdd As Double = 10
    Private Sub btnUpContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx1.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderYValueAdd = Math.Abs(m_WorkholderYValueAdd)
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderY

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Call m_Motion.GetCmd(axisID, target)
                    If m_WorkholderYValueAdd > 0 Then
                        target = m_Motion.SWMax(axisID)
                    Else
                        target = m_Motion.SWMin(axisID)
                    End If
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                        If rStatus = enumMotionFlag.eSent Then
                            Exit Do
                        ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                            Exit Do
                        End If
                    Loop
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnUpContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx1.MouseUp
        m_Motion.SlowStop(enumAxis.WorkholderY)
        m_IsMoving = False
    End Sub


    Private Sub btnDownContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx3.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderYValueAdd = Math.Abs(m_WorkholderYValueAdd) * -1
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderY

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Call m_Motion.GetCmd(axisID, target)
                    If m_WorkholderYValueAdd > 0 Then
                        target = m_Motion.SWMax(axisID)
                    Else
                        target = m_Motion.SWMin(axisID)
                    End If
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                        If rStatus = enumMotionFlag.eSent Then
                            Exit Do
                        ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                            Exit Do
                        End If
                    Loop
                End If
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub btnDownContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx3.MouseUp
        m_Motion.SlowStop(enumAxis.WorkholderY)
        m_IsMoving = False
    End Sub

    Private m_WorkholderZValueAdd As Double = 10
    Private m_WorkholderZMoveOK As Boolean = False

    Private Sub btnZUpContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx5.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderZMoveOK = True
            m_WorkholderZValueAdd = Math.Abs(m_WorkholderZValueAdd) * -1
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderZ

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    If m_WorkholderZMoveOK = True Then
                        m_WorkholderZMoveOK = False
                        Call m_Motion.GetCmd(axisID, target)
                        If m_WorkholderZValueAdd > 0 Then
                            target = m_Motion.SWMax(axisID)
                        Else
                            target = m_Motion.SWMin(axisID)
                        End If
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            m_Motion.IsExternalParameters(axisID) = False
                            Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                            If rStatus = enumMotionFlag.eSent Then
                                Exit Do
                            ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                                Exit Do
                            End If
                        Loop
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnZUpContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx5.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderZ)
    End Sub


    Private Sub btnZDownContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx6.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderZMoveOK = True
            m_WorkholderZValueAdd = Math.Abs(m_WorkholderZValueAdd)
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderZ

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    If m_WorkholderZMoveOK = True Then
                        m_WorkholderZMoveOK = False
                        Call m_Motion.GetCmd(axisID, target)
                        If m_WorkholderZValueAdd > 0 Then
                            target = m_Motion.SWMax(axisID)
                        Else
                            target = m_Motion.SWMin(axisID)
                        End If
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            m_Motion.IsExternalParameters(axisID) = False
                            Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                            If rStatus = enumMotionFlag.eSent Then
                                Exit Do
                            ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                                Exit Do
                            End If
                        Loop
                    End If
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnZDownContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx6.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderZ)
    End Sub

    Private Sub btnJobZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJobZ.Click
        Call UIProtect(False)
        Dim pResult As enumMotionFlag
        If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
            Dim pSpeed As Double
            Try
                pSpeed = CDbl(txtSpeed.Text) / 100
            Catch ex As Exception

            End Try
            If pSpeed >= 1 Then
                pSpeed = 1
            ElseIf pSpeed <= 0 Then
                pSpeed = 0.1
            End If



            m_Motion.MoveAbs(enumAxis.WorkholderZ, m_Param.RegisterPosition.ListRegisterPosition(ePosType.DefaultJobHeight).ZAxis / m_ShowScale, pResult, pSpeed, pSpeed)
        End If
        Call UIProtect(True)
    End Sub
    Private Sub btnZero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZero.Click
        'Dim pZ As Double
        'Call m_Motion.GetCmd(enumAxis.WorkholderZ, pZ)
        'm_Param.ZeroNumber = pZ * m_ShowScale
        m_LaserAperture.SetZero()
        m_Param.ZeroNumber = m_LaserAperture.Zero
        txtHeight.Text = m_LaserAperture.Height.ToString("F4")
    End Sub

    Private Sub TimerWorkholderValue_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerWorkholderValue.Tick
        Try
            Dim axisNum As Integer
            Dim nowEncoder As Double
            txtHeight.Text = m_LaserAperture.Height.ToString("F4")

            axisNum = enumAxis.WorkholderX
            Call m_Motion.GetCmd(axisNum, nowEncoder)
            txtPositionX.Text = CStr(CInt(nowEncoder) * m_ShowScale)

            axisNum = enumAxis.WorkholderY
            Call m_Motion.GetCmd(axisNum, nowEncoder)
            txtPositionY.Text = CStr(CInt(nowEncoder) * m_ShowScale)

            axisNum = enumAxis.WorkholderZ
            Call m_Motion.GetCmd(axisNum, nowEncoder)
            txtPositionZ.Text = CStr(CInt(nowEncoder) * m_ShowScale)

            'txtHeight.Text = CStr(CInt(nowEncoder - m_Param.ZeroNumber / m_ShowScale) * m_ShowScale)


        Catch ex As Exception

        End Try
    End Sub

    Private Sub ImageDisplay1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageDisplay1.Click

    End Sub

    Private Sub TimerGetImagePoint_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGetImagePoint.Tick
        Try
            If ImageDisplay1.ImagePointCanGet = True Then
                Dim pNowX As Double = ImageDisplay1.ImagePoint_X
                Dim pNowY As Double = ImageDisplay1.ImagePoint_Y
                Dim pGetPoint As Boolean = False
                If pNowX <> 0 Then
                    pGetPoint = True
                End If
                If pNowY <> 0 Then
                    pGetPoint = True
                End If
                If pGetPoint = True AndAlso ImageDisplay1.ImagePointCanGet = True Then
                    ImageDisplay1.ImagePointCanGet = False
                    TextBox2.Text = "X = " & pNowX - 360 & " " & "Y = " & pNowY
                    Dim axisID As Integer
                    Dim nowEncoder As Double
                    Do
                        Application.DoEvents()
                        axisID = enumAxis.WorkholderX
                        If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                            axisID = enumAxis.WorkholderY
                            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                                Exit Do
                            End If
                        End If
                    Loop
                    Dim rStatus As enumMotionFlag
                    Dim pSpeed As Double
                    Try
                        pSpeed = CDbl(txtSpeed.Text) / 100
                    Catch ex As Exception

                    End Try
                    If pSpeed >= 1 Then
                        pSpeed = 1
                    ElseIf pSpeed <= 0 Then
                        pSpeed = 0.1
                    End If
                    axisID = enumAxis.WorkholderX
                    m_Motion.GetEncoder(axisID, nowEncoder)
                    m_Motion.MoveAbs(axisID, nowEncoder - (pNowX - 360) * m_Param.Variable.Workholder.CCDRatioX, rStatus, pSpeed, pSpeed)


                    axisID = enumAxis.WorkholderY
                    m_Motion.GetEncoder(axisID, nowEncoder)
                    m_Motion.MoveAbs(axisID, nowEncoder + (pNowY - 270) * m_Param.Variable.Workholder.CCDRatioY, rStatus, pSpeed, pSpeed)
                    Do
                        Application.DoEvents()
                        axisID = enumAxis.WorkholderX
                        If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                            axisID = enumAxis.WorkholderY
                            If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                                Exit Do
                            End If
                        End If
                    Loop

                    ImageDisplay1.ImagePoint_X = 0
                    ImageDisplay1.ImagePoint_Y = 0
                    ImageDisplay1.ImagePointCanGet = True
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ButtonEx1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ButtonEx1.MouseDown
        If m_IsMoving = False Then
            m_IsMoving = True
            m_WorkholderYValueAdd = Math.Abs(m_WorkholderYValueAdd)
            Try
                'Dim idx As Integer
                Dim axisID As enumAxis
                Dim target As Double
                Dim rStatus As enumMotionFlag
                'Dim quadrant As Integer
                'Dim cylStatus2 As enumCylSts
                axisID = enumAxis.WorkholderY

                Dim pSpeed As Double
                Try
                    pSpeed = CDbl(txtSpeed.Text) / 100
                Catch ex As Exception

                End Try
                If pSpeed >= 1 Then
                    pSpeed = 1
                ElseIf pSpeed <= 0 Then
                    pSpeed = 0.1
                End If

                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Call m_Motion.GetCmd(axisID, target)
                    If m_WorkholderYValueAdd > 0 Then
                        target = m_Motion.SWMax(axisID)
                    Else
                        target = m_Motion.SWMin(axisID)
                    End If
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, target, rStatus, pSpeed, pSpeed)
                        If rStatus = enumMotionFlag.eSent Then
                            Exit Do
                        ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                            Exit Do
                        End If
                    Loop
                End If
            Catch ex As Exception

            End Try
        End If
    End Sub
    Private m_StopLaser As Boolean = False
    Private m_IsLaser As Boolean = False
    Private Sub btnRunLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunLaser.Click


        Dim ctrlName As String
        ctrlName = CType(sender, Control).Name
        Do
        Loop Until m_IsThreadFinished = True
        m_IsThreadStarted = False
        System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf SolderingThread), ctrlName)


    End Sub

    Private Sub btnStopLaser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopLaser.Click
        Try
            If m_StopLaser = False Then
                m_StopLaser = True
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnRunFeeder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunFeeder.Click
        Dim ctrlName As String
        ctrlName = CType(sender, Control).Name
        Do
        Loop Until m_IsThreadFinished = True
        m_IsThreadStarted = False
        System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf SolderingThread), ctrlName)
    End Sub


    Private Sub btnPointSoldering_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPointSoldering.Click
        ' Dim xx As Integer = m_ClickNode
        If (m_ClickNode IsNot Nothing) Then
            If (m_ClickNode.Tag.GetType Is GetType(CPoint)) Then
                Dim selectedPoint As CPoint = CType(m_ClickNode.Tag, CPoint)
                Dim axisID1 = enumAxis.WorkholderX
                Dim IOOnOff As Integer = 1
                Try
                    Call UIProtect(False)

                    Dim pLaserOK As Boolean = LaserParamSetting(selectedPoint.LaserRecipe)
                    If pLaserOK = False Then
                        Dim cc2 As Integer = 0
                    End If


                    ' m_Motion.IOTest(axisID1, IO)

                    m_Motion.MoveAdvTableEMGStop = False
                    Dim pFeedForwardSpeedPercent As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardSpeed1 / 100
                    Dim pFeedForwardDistance As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardDistance1 * 1000

                    Dim pFeedForwardDelayTime As Double = m_Param.FeederRecipe(m_FeederRecipeSelected).ForwardDelay

                    Dim pFeedForwardSpeedPercent2 As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardSpeed2 / 100
                    Dim pFeedForwardDistance2 As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardDistance2 * 1000

                    Dim pFeedBackwardSpeedPercent As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).BackwardSpeed / 100
                    Dim pFeedBackwardDistance As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).BackwardDistance * 1000
                    Dim pFeedBackwardDelayTIme As Double = m_Param.FeederRecipe(selectedPoint.FeederRecipe).BackwardDelay
                    Dim pFeedEnable = True

                    m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardDelay = CInt(txtForwardDelay.Text)

                    m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardSpeed1 = CInt(txtForwardSpeedPercent1.Text)
                    m_Param.FeederRecipe(selectedPoint.FeederRecipe).ForwardDistance1 = CDbl(txtForwardDistance1.Text)




                    Dim nowAxis2Encoder As Double
                    m_Motion.GetEncoder(FMain.axisID2_Adv, nowAxis2Encoder)
                    Dim Path_rtnData As List(Of String)
                    Dim Acc As Double = 9800000
                    Dim Dec As Double = 9800000
                    Dim Velocity As Double = 100000 * pFeedForwardSpeedPercent
                    Dim Velocity2 As Double = 100000 * pFeedForwardSpeedPercent
                    Dim BackVelocity As Double = 100000 * pFeedBackwardSpeedPercent
                    Path_rtnData = TranslatePathToAdvanceSolder(
                                                                Acc,
                                                                Dec,
                                                                Velocity,
                                                                Acc,
                                                                Dec,
                                                                Velocity,
                                                                Acc,
                                                                Dec,
                                                                BackVelocity,
                                                                pFeedForwardDelayTime,
                                                                pFeedForwardDistance,
                                                                pFeedForwardDistance2,
                                                                pFeedBackwardDistance,
                                                                pFeedBackwardDelayTIme,
                                                                pFeedEnable,
                                                               FMain.axisID2_Adv)

                    Try
                        Dim pSysProcessNum As Integer = 1200

                        Dim bStatus As enumMotionFlag
                        Dim pTime As Double

                        Do
                            Select Case pSysProcessNum
                                Case 1200
                                    If Path_rtnData(0) = "False_Translate" Then
                                        Exit Do
                                    Else
                                        If pFeedForwardDelayTime > 0 Then
                                            IOOnOff = 1
                                            m_Motion.IOTest(axisID1, 0, IOOnOff)
                                            pTime = m_Timer.GetMilliseconds
                                            pSysProcessNum = 1205
                                        End If
                                    End If

                                Case 1205
                                    Call m_Motion.MoveAdvTablePoint(FMain.axisID1_Adv, FMain.axisID2_Adv, Path_rtnData, bStatus)

                                    If bStatus = enumMotionFlag.eSent Then
                                        pSysProcessNum = 1210
                                    End If
                                Case 1210
                                    If (m_Motion.MoveAdvPointTableIsThreadStarted) Then
                                        If m_Motion.MoveAdvPointTableIsThreadFinished Then
                                            If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                                Exit Do
                                            Else
                                                Exit Do
                                            End If

                                        End If
                                    End If
                            End Select
                        Loop

                        Do
                            Dim line_idx As Double
                            If m_Motion.MoveAdvPointTableErrorMesseage = "" Then
                                axisID1 = enumAxis.WorkholderY
                                If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                    axisID1 = enumAxis.WorkholderX
                                    If m_Motion.ChkStop(axisID1) = enumMotionFlag.eReady Then
                                        If m_Motion.ChkAdvanceTableStop(FMain.axisID1_Adv, FMain.axisID2_Adv, line_idx) = enumMotionFlag.eReady Then
                                            Exit Do
                                        End If
                                    End If
                                End If
                            Else
                                Exit Do
                            End If
                        Loop
                    Catch ex As Exception

                    End Try
                Catch ex As Exception
                Finally
                    axisID1 = enumAxis.WorkholderX
                    IOOnOff = 0
                    m_Motion.IOTest(axisID1, 0, IOOnOff)
                    Call UIProtect(True)
                End Try

            End If
        End If
    End Sub

    Private Sub btnMoveToReadyPosition_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveToReadyPosition.Click
        Try
            Call UIProtect(False)
            btnMoveToReadyPosition.Enabled = False
            Dim pResult As enumMotionFlag
            Dim pSpeed As Double
            Try
                pSpeed = CDbl(txtSpeed.Text) / 100
            Catch ex As Exception

            End Try
            If pSpeed >= 1 Then
                pSpeed = 1
            ElseIf pSpeed <= 0 Then
                pSpeed = 0.1
            End If
            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, 0, pResult, pSpeed, pSpeed)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderX, m_Param.RegisterPosition.ListRegisterPosition(ePosType.ReadyPos).XAxis / m_ShowScale, pResult, pSpeed, pSpeed)
                        m_Motion.MoveAbs(enumAxis.WorkholderY, m_Param.RegisterPosition.ListRegisterPosition(ePosType.ReadyPos).YAxis / m_ShowScale, pResult, pSpeed, pSpeed)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, m_Param.RegisterPosition.ListRegisterPosition(ePosType.ReadyPos).ZAxis, pResult, pSpeed, pSpeed)
                    End If
                End If
            End If

        Catch ex As Exception
        Finally
            Call UIProtect(True)
            btnMoveToReadyPosition.Enabled = True
        End Try



    End Sub

    Private Sub btnJobToLaserTestZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJobToLaserTestZ.Click
        Try
            btnJobToLaserTestZ.Enabled = False
            Call UIProtect(False)
            Dim pResult As enumMotionFlag
            Dim pSpeed As Double
            Try
                pSpeed = CDbl(txtSpeed.Text) / 100
            Catch ex As Exception

            End Try
            If pSpeed >= 1 Then
                pSpeed = 1
            ElseIf pSpeed <= 0 Then
                pSpeed = 0.1
            End If

            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, 0, pResult, pSpeed, pSpeed)
                        Dim pXNow As Double
                        Dim pYNow As Double
                        Dim pZNow As Double
                        m_Motion.GetEncoder(enumAxis.WorkholderX, pXNow)
                        m_Motion.GetEncoder(enumAxis.WorkholderY, pYNow)
                        m_Motion.GetEncoder(enumAxis.WorkholderZ, pZNow)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderX, pXNow + m_Param.Pos.Workholder.LaserTestZOffsetX, pResult, pSpeed, pSpeed)
                        m_Motion.MoveAbs(enumAxis.WorkholderY, pYNow + m_Param.Pos.Workholder.LaserTestZOffsetY, pResult, pSpeed, pSpeed)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, pZNow, pResult, pSpeed, pSpeed)
                    End If
                End If
            End If

        Catch ex As Exception
        Finally
            Call UIProtect(True)
            btnJobToLaserTestZ.Enabled = True
        End Try
    End Sub

    Private Sub btnJobFromLaserTestZ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJobFromLaserTestZ.Click
        Try
            btnJobFromLaserTestZ.Enabled = False
            Call UIProtect(False)
            Dim pResult As enumMotionFlag
            Dim pSpeed As Double
            Try
                pSpeed = CDbl(txtSpeed.Text) / 100
            Catch ex As Exception

            End Try
            If pSpeed >= 1 Then
                pSpeed = 1
            ElseIf pSpeed <= 0 Then
                pSpeed = 0.1
            End If

            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, 0, pResult, pSpeed, pSpeed)
                        Dim pXNow As Double
                        Dim pYNow As Double
                        Dim pZNow As Double
                        m_Motion.GetEncoder(enumAxis.WorkholderX, pXNow)
                        m_Motion.GetEncoder(enumAxis.WorkholderY, pYNow)
                        m_Motion.GetEncoder(enumAxis.WorkholderZ, pZNow)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderX, pXNow - m_Param.Pos.Workholder.LaserTestZOffsetX, pResult, pSpeed, pSpeed)
                        m_Motion.MoveAbs(enumAxis.WorkholderY, pYNow - m_Param.Pos.Workholder.LaserTestZOffsetX, pResult, pSpeed, pSpeed)
                        Do
                            If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
                                If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                                    If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                                        Exit Do
                                    End If
                                End If
                            End If
                            Application.DoEvents()
                        Loop
                        m_Motion.MoveAbs(enumAxis.WorkholderZ, pZNow, pResult, pSpeed, pSpeed)
                    End If
                End If
            End If

        Catch ex As Exception
        Finally
            btnJobFromLaserTestZ.Enabled = True
            Call UIProtect(True)
        End Try
    End Sub
    Private Sub UIProtect(ByVal Status As Boolean)
        Try
            TabControl1.Enabled = Status
            Panel2.Enabled = Status
            Panel4.Enabled = Status
            btnRegisterGPoint.Enabled = Status
        Catch ex As Exception

        End Try
    End Sub

    Private Sub tvJobs_NodeMouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles tvJobs.NodeMouseDoubleClick
        Try
            Dim parent As TreeNode = m_ClickNode.Parent
            Dim pallet As CPallet = Nothing
            Dim SortedJob As List(Of CJobObject) = New List(Of CJobObject)
            If (parent IsNot Nothing) Then
                If (parent.Level <> 0) Then '<> Root node
                    Dim job As CJobObject = CType(parent.Tag, CJobObject)
                    If (job IsNot Nothing) Then
                        If (job.GetType() Is GetType(CPallet)) Then
                            pallet = CType(job, CPallet)
                            Dim lst As CListJob = New CListJob()
                            Dim AlignID = 0
                            ReDim lstAlignID(5)

                            For index = 1 To lstAlignID.Length - 1
                                lstAlignID(index) = -1
                            Next
                            lst = BuildJobList(parent.Nodes, AlignID)
                            pallet.ListJob = lst
                            SortedJob = SortJobTmp(pallet)
                        End If
                    End If
                End If
            End If
            If (pallet IsNot Nothing AndAlso SortedJob IsNot Nothing AndAlso SortedJob.Count > 0) Then
                Dim fChooseColRow As FChooseColumnRow = New FChooseColumnRow(pallet)
                fChooseColRow.ShowDialog()
                If (fChooseColRow.OK = True) Then
                    Dim selectedRow, selectedCol As Integer
                    selectedRow = fChooseColRow.Row
                    selectedCol = fChooseColRow.Column

                    Dim job As CJobObject = CType(m_ClickNode.Tag, CJobObject)
                    Dim clickpoint As CPoint = Nothing
                    If (job IsNot Nothing AndAlso job.GetType() Is GetType(CPoint)) Then
                        clickpoint = CType(job, CPoint)
                    End If
                    If (clickpoint IsNot Nothing) Then
                        Dim selectedPoint As CPoint = Nothing

                        For i = 0 To SortedJob.Count - 1
                            If (SortedJob(i).GetType() Is GetType(CPoint)) Then
                                selectedPoint = CType(SortedJob(i), CPoint)
                                If (selectedPoint.RowNumber = selectedRow AndAlso selectedPoint.ColumnNumber = selectedCol AndAlso clickpoint.ID = selectedPoint.ID) Then
                                    Exit For
                                End If
                            End If
                        Next

                        If (selectedPoint IsNot Nothing) Then
                            MoveToPoint(selectedPoint)
                        End If
                    End If
                End If
            Else
                Dim job As CJobObject = CType(e.Node.Tag, CJobObject)
                If (job IsNot Nothing) Then
                    If (job.GetType() Is GetType(CPoint)) Then
                        Dim point As CPoint = CType(job, CPoint)
                        If (FMessageBox.Show("Are you sure you want to move the setting postion?" & vbCrLf & "(您確定要移動到設定位置嗎)？", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            MoveToPoint(point)
                        End If
                    End If
                End If
            End If
        Catch
        End Try
    End Sub
End Class
