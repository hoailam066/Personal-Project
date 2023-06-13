Imports System.Threading
Imports PseudoDevice

Public Class FJog
    Private m_Motion As CMotion
    Public Sub New(ByRef pMotion As CMotion)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Try
            If Not (pMotion Is Nothing) Then m_Motion = pMotion
            AddHandler GroupBoxEx1.MouseClick, AddressOf FJog_Click
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub ButtonChangeIcon_MouseEnter(sender As System.Object, e As System.EventArgs) Handles btnFeedCounterClockwise.MouseEnter, btnFeedClockwise.MouseEnter, btnRCounterClockwise.MouseEnter, btnRClockwise.MouseEnter
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnRCounterClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove2
            Case btnFeedClockwise.Name, btnRClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd2
        End Select
    End Sub

    Private Sub ButtonChangeIcon_MouseLeave(sender As System.Object, e As System.EventArgs) Handles btnFeedCounterClockwise.MouseLeave, btnFeedClockwise.MouseLeave, btnRCounterClockwise.MouseLeave, btnRClockwise.MouseLeave
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnRCounterClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove
            Case btnFeedClockwise.Name, btnRClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd
        End Select
    End Sub
    Private m_FeedValueAdd As Double = 10
    Private Sub ButtonChangeIcon_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnFeedCounterClockwise.MouseDown, btnFeedClockwise.MouseDown, btnRCounterClockwise.MouseDown, btnRClockwise.MouseDown
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnRCounterClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove3
            Case btnFeedClockwise.Name, btnRClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd3
        End Select
       

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


    End Sub

    Private Sub ButtonChangeIcon_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnFeedCounterClockwise.MouseUp, btnFeedClockwise.MouseUp, btnRCounterClockwise.MouseUp, btnRClockwise.MouseUp
        Dim btn As Button = CType(sender, Button)
        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnRCounterClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove2
            Case btnFeedClockwise.Name, btnRClockwise.Name
                btn.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd2
        End Select

        Select Case btn.Name
            Case btnFeedCounterClockwise.Name, btnFeedClockwise.Name
                m_Motion.SlowStop(enumAxis.FeederZ)
                m_IsMoving = False
        End Select
    End Sub

    Private Sub TrackBarSpeed_ValueChanged(sender As System.Object, e As System.EventArgs) Handles TrackBarSpeed.ValueChanged
        txtSpeed.Text = TrackBarSpeed.Value
        txtSpeed.SelectionStart = txtSpeed.TextLength
    End Sub

    Private Sub txtSpeed_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSpeed.KeyPress
        'Check imput only Number key or Control key
        If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub txtSpeed_Leave(sender As System.Object, e As System.EventArgs) Handles txtSpeed.Leave
        If (txtSpeed.Text = "") Then
            txtSpeed.Text = TrackBarSpeed.Value
            txtSpeed.SelectionStart = txtSpeed.TextLength
        Else
            Dim value As Integer = CInt(txtSpeed.Text)
            If (value < TrackBarSpeed.Minimum) Then
                value = TrackBarSpeed.Minimum
            End If
            If (value > TrackBarSpeed.Maximum) Then
                value = TrackBarSpeed.Maximum
            End If
            TrackBarSpeed.Value = value
        End If
    End Sub

    Private Sub FJog_Click(sender As System.Object, e As System.EventArgs) Handles MyBase.Click
        txtSpeed_Leave(Nothing, Nothing)
    End Sub


    Private m_IsMoving As Boolean = False

    Private m_WorkholderXValueAdd As Double = 10
    Private m_WorkholderXMoveOK As Boolean = False

    Private Sub btnXYLeftContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnXYLeft.MouseDown
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

    Private Sub btnLeftContin_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYLeft.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderX)
    End Sub


    Private Sub btnRightContin_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYRight.MouseDown
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

    Private Sub btnRightContin_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYRight.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderX)
    End Sub



    Private m_WorkholderYValueAdd As Double = 10
    Private Sub btnUpContin_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYUp.MouseDown
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

    Private Sub btnUpContin_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYUp.MouseUp
        m_Motion.SlowStop(enumAxis.WorkholderY)
        m_IsMoving = False
    End Sub


    Private Sub btnDownContin_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYDown.MouseDown
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

    Private Sub btnDownContin_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles btnXYDown.MouseUp
        m_Motion.SlowStop(enumAxis.WorkholderY)
        m_IsMoving = False
    End Sub

    Private m_WorkholderZValueAdd As Double = 10
    Private m_WorkholderZMoveOK As Boolean = False

    Private Sub btnZUpContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZUp.MouseDown
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

    Private Sub btnZUpContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZUp.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderZ)
    End Sub


    Private Sub btnZDownContin_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZDown.MouseDown
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

    Private Sub btnZDownContin_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZDown.MouseUp
        m_IsMoving = False
        m_Motion.SlowStop(enumAxis.WorkholderZ)
    End Sub



End Class