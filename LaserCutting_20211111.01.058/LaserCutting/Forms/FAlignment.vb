Imports PseudoDevice
Imports ViewROI

Public Class FAlignment
    Private m_RulerColor As Color
    Private m_DiscreteMove As Double = 1
    Private m_CurProject As CProject
    Public m_Acquist As VisionSystem.CAcquisition
    Private m_Ruler As CRuler
    Private m_Motion As CMotion
    Private m_Param, m_OldParam As CParam
    Private m_ComboxBoxSelectedValue As Integer = 0
    Private m_LaserAperture As CLaserAperture

    Private m_TypeGlobalLocal As Double = 0
    Private m_MatchingToolGloBal(0 To 4) As VisionSystem.CMatchingTool
    Private m_MatchingToolLocal(0 To 4) As VisionSystem.CMatchingTool
    Private m_ShowScale As Double = 0.001

    Private Const MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\"
    Public Const MCS_PRODUCT_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\Products"
    Public ReadOnly Property RulerColor As Color
        Get
            Return m_RulerColor
        End Get
    End Property
    Public Sub New(ByRef pCurproject As CProject, ByVal pRuler As CRuler, ByRef pAcquist As VisionSystem.CAcquisition, ByRef pMotion As CMotion, ByRef pParam As CParam, ByRef pMatchingToolGloBal() As VisionSystem.CMatchingTool, ByRef pMatchingToolLocal() As VisionSystem.CMatchingTool)
        Try
            InitializeComponent()
            If (pAcquist IsNot Nothing) Then
                m_Acquist = pAcquist
            Else
                m_Acquist = New VisionSystem.CAcquisition(0)
            End If

            m_CurProject = pCurproject
            If (pRuler Is Nothing) Then
                m_Ruler = New CRuler(grbCamera)
            Else
                m_Ruler = pRuler
                m_Ruler.Parent = grbCamera
            End If

            If Not (pMotion Is Nothing) Then m_Motion = pMotion

            If (pParam IsNot Nothing) Then
                m_Param = pParam
            Else
                m_Param = New CParam(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
            End If

            If Not (pMatchingToolGloBal Is Nothing) Then m_MatchingToolGloBal = pMatchingToolGloBal

            If Not (pMatchingToolLocal Is Nothing) Then m_MatchingToolLocal = pMatchingToolLocal

            'm_OldParam = m_Param.Clone(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
            If m_LaserAperture Is Nothing Then m_LaserAperture = New CLaserAperture()

            m_RulerColor = m_Ruler.Color
            ImageViewer1.StartLive(0, m_Acquist)
            m_Ruler.Visible = True

            
        Catch ex As Exception

        End Try

    End Sub
    Private Sub btnPickColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cd As ColorDialog = New ColorDialog()
        If (cd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            m_RulerColor = cd.Color
            m_Ruler.Color = m_RulerColor
        End If
    End Sub

    Private Sub FAlignment_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer1.Enabled = False
            m_RulerColor = m_Ruler.Color
            ImageViewer1.StopLive()
            m_Ruler.Dispose()
            m_LaserAperture.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FAlignment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub
   
    Private m_IsMoving As Boolean = False
    Private m_WorkholderValueAdd As Double = 10
    Private m_axisID As Integer
    Private Sub btnContinuousMoveAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnContinuousMoveMinus_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    

    Private Sub txtUnit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
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

   

   

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Try
            btnSearch.Enabled = False
            Dim m_MatchingTool As VisionSystem.CMatchingTool = Nothing
            Dim pMatchingToolPath As String

            If m_TypeGlobalLocal = 0 Then
                pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.ProjectName & "\Image" & "\Left"
                If System.IO.Directory.Exists(pMatchingToolPath) = True Then
                    If m_MatchingTool Is Nothing Then m_MatchingTool = New VisionSystem.CMatchingTool(pMatchingToolPath)
                    m_MatchingTool.ReadFiles()
                    m_MatchingTool.Pattern.Train()
                End If
            Else
                pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.ProjectName & "\Image" & "\Right"
                If System.IO.Directory.Exists(pMatchingToolPath) = True Then
                    If m_MatchingTool Is Nothing Then m_MatchingTool = New VisionSystem.CMatchingTool(pMatchingToolPath)
                    m_MatchingTool.ReadFiles()
                    m_MatchingTool.Pattern.Train()
                End If
            End If

            Dim dbAccept As Double = 85
            Try
                dbAccept = CDbl(tbAcceptScore.Text)
            Catch ex As Exception

            End Try
            If m_MatchingTool IsNot Nothing Then
                Dim searchRegion As VisionSystem.CRectangle
                Dim img As VisionSystem.CImage
                Call Me.ImageViewer1.StopLive()
                Me.ImageViewer1.StaticGraphics.Clear()
                Call m_Acquist.Acquist(0, True)
                img = New VisionSystem.CImage
                m_Acquist.CopyTo(0, img)
                Call m_MatchingTool.RunParams.SetScoreProperty(0, dbAccept)
                Call m_MatchingTool.RunParams.SetRotaryRange(-5, 5)
                Call m_MatchingTool.RunParams.SetScaleRange(100, 100)
                searchRegion = New VisionSystem.CRectangle
                Call searchRegion.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width, img.Height, 0)
                m_MatchingTool.SearchRegion = searchRegion
                m_MatchingTool.InputImage.CopyOf(img)
                m_MatchingTool.Run(True, VisionSystem.EnumMatchShape.None)
                If m_MatchingTool.Results.Count > 0 Then
                    'Me.Text = "分數 : " & (m_MatchingTool.Results.Item(0).Score * 100) & " 橫向偏差量 :" & (m_MatchingTool.Results.Item(0).TranslationX - img.Width / 2) * m_Param.Variable.Workholder.CCDRatioX & "um 縱向偏差量:" & (m_MatchingTool.Results.Item(0).TranslationY - img.Height / 2) * m_Param.Variable.Workholder.CCDRatioY & "um"

                    tbOffsetX.Text = ((m_MatchingTool.Results.Item(0).TranslationX - img.Width / 2) * m_Param.Variable.Workholder.CCDRatioX * m_ShowScale).ToString("F4")

                    tbOffsetY.Text = ((m_MatchingTool.Results.Item(0).TranslationY - img.Height / 2) * m_Param.Variable.Workholder.CCDRatioY * m_ShowScale).ToString("F4")
                    Call Me.ImageViewer1.StaticGraphics.Add(m_MatchingTool.Results.GetGraphics(CType(VisionSystem.enumMatchingToolResultGraphicConstants.MatchRegion + VisionSystem.enumMatchingToolResultGraphicConstants.Origin, VisionSystem.enumMatchingToolResultGraphicConstants)))
                Else
                    Me.ImageViewer1.StaticGraphics.Clear()
                    tbOffsetX.Text = (0).ToString("F4")

                    tbOffsetY.Text = (0).ToString("F4")
                End If
                Call img.Dispose() : img = Nothing
                Me.ImageViewer1.StartLive(0, m_Acquist)
                Call m_MatchingTool.SaveFiles()
            Else
                Me.ImageViewer1.StaticGraphics.Clear()
                tbOffsetX.Text = (0).ToString("F4")

                tbOffsetY.Text = (0).ToString("F4")
            End If



        Catch ex As Exception
        Finally
            btnSearch.Enabled = True
        End Try


    End Sub


    Private Sub btnSearchReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReturn.Click
        Try
            Dim axisID As Integer
            Dim targetX As Double
            Dim targetY As Double
            Dim rStatus As enumMotionFlag
            Dim pSpeed As Double
            Try
                pSpeed = 10
            Catch ex As Exception

            End Try
            If pSpeed >= 1 Then
                pSpeed = 1
            ElseIf pSpeed <= 0 Then
                pSpeed = 0.1
            End If

            axisID = enumAxis.WorkholderX
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Call m_Motion.GetEncoder(axisID, targetX)
                    targetX = targetX - CDbl(tbOffsetX.Text / m_ShowScale)
                    Exit Do
                End If
            Loop
            axisID = enumAxis.WorkholderY
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Call m_Motion.GetEncoder(axisID, targetY)
                    targetY = targetY + CDbl(tbOffsetY.Text / m_ShowScale)
                    Exit Do
                End If
            Loop

            Do
                Call System.Windows.Forms.Application.DoEvents()
                m_Motion.IsExternalParameters(axisID) = False
                axisID = enumAxis.WorkholderX
                Call m_Motion.MoveAbs(axisID, targetX, rStatus, pSpeed, pSpeed)
                If rStatus = enumMotionFlag.eSent Then
                    Exit Do
                ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                    Call MsgBox("行程超過軟體極限")
                    Exit Do
                End If
            Loop
            Do
                Call System.Windows.Forms.Application.DoEvents()
                m_Motion.IsExternalParameters(axisID) = False
                axisID = enumAxis.WorkholderY
                Call m_Motion.MoveAbs(axisID, targetY, rStatus, pSpeed, pSpeed)
                If rStatus = enumMotionFlag.eSent Then
                    Exit Do
                ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                    Call MsgBox("行程超過軟體極限")
                    Exit Do
                End If
            Loop

            Do
                Call System.Windows.Forms.Application.DoEvents()
                axisID = enumAxis.WorkholderX
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    axisID = enumAxis.WorkholderY
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        Exit Do
                    End If
                End If
            Loop

        Catch ex As Exception

        End Try

    End Sub

    'Private Sub cbMove_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Try
    '        m_Ruler.Visible = cbMove.Checked
    '        If cbMove.Checked = False Then
    '            cbMove.Enabled = False
    '            rbGlobal.Enabled = False
    '            rbLocal.Enabled = False

    '            Dim img As VisionSystem.CImage

    '            If m_roiRec Is Nothing Then m_roiRec = New ROIRectangle1
    '            img = New VisionSystem.CImage
    '            Call Me.ImageViewer1.StopLive()
    '            Call Me.ImageViewer2.StopLive()

    '            Call m_Acquist.Acquist(0, True)
    '            m_Acquist.CopyTo(0, img)
    '            m_ImageViewerSaveImg = img



    '            Call Me.ImageViewer1.StaticGraphics.Clear()
    '            Call Me.ImageViewer1.InteractiveGraphics.Clear()
    '            Me.ImageViewer1.CopyOf(m_ImageViewerSaveImg)

    '            Call Me.ImageViewer1.InteractiveGraphics.Add1(m_roiRec)





    '        Else
    '            Try
    '                Dim rectangle As VisionSystem.CRectangle

    '                Dim m_MatchingTool As VisionSystem.CMatchingTool
    '                Dim pMatchingToolPath As String = ""
    '                If m_TypeGlobalLocal = 0 Then
    '                    pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\GloBal" & m_ComboxBoxSelectedValue

    '                    If m_MatchingToolGloBal(m_ComboxBoxSelectedValue) Is Nothing Then m_MatchingToolGloBal(m_ComboxBoxSelectedValue) = New VisionSystem.CMatchingTool(CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\GloBal" & m_ComboxBoxSelectedValue)
    '                    m_MatchingTool = m_MatchingToolGloBal(m_ComboxBoxSelectedValue)
    '                Else
    '                    pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\Local" & m_ComboxBoxSelectedValue

    '                    If m_MatchingToolLocal(m_ComboxBoxSelectedValue) Is Nothing Then m_MatchingToolLocal(m_ComboxBoxSelectedValue) = New VisionSystem.CMatchingTool(CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\Local" & m_ComboxBoxSelectedValue)
    '                    m_MatchingTool = m_MatchingToolLocal(m_ComboxBoxSelectedValue)
    '                End If

    '                Try
    '                    If System.IO.Directory.Exists(pMatchingToolPath) = False Then
    '                        'My.Computer.FileSystem.CreateDirectory(pMatchingToolPath)
    '                        My.Computer.FileSystem.CopyDirectory("D:\DataSettings\LaserSolder\MachineData\Reserve", pMatchingToolPath, True)
    '                    End If
    '                Catch ex As Exception

    '                End Try

    '                Call Me.ImageViewer1.StopLive()
    '                Call Me.ImageViewer2.StopLive()
    '                Try
    '                    If m_MatchingTool IsNot Nothing Then
    '                        rectangle = New VisionSystem.CRectangle

    '                        Call rectangle.SetCenterLengthsRotation(m_roiRec.midC, m_roiRec.midR, (m_roiRec.col2 - m_roiRec.col1), (m_roiRec.row2 - m_roiRec.row1), 0)

    '                        'Call m_Acquist.Acquist(0, True)
    '                        'm_Acquist.CopyTo(0, img)
    '                        'Me.ImageViewer1.CopyOf(img)

    '                        Dim dbAccept As Double = 85
    '                        Try
    '                            dbAccept = CDbl(tbAcceptScore.Text)
    '                        Catch ex As Exception

    '                        End Try


    '                        Call m_MatchingTool.InputImage.CopyOf(m_ImageViewerSaveImg)
    '                        Call m_MatchingTool.Pattern.SetRotaryRange(-5, 5)
    '                        Call m_MatchingTool.Pattern.TrainImage.CopyOf(m_ImageViewerSaveImg)
    '                        Call m_MatchingTool.RunParams.SetScaleRange(100, 100)

    '                        m_MatchingTool.RunParams.RunType = 1

    '                        m_MatchingTool.Pattern.TrainRegion = rectangle
    '                        Call m_MatchingTool.Pattern.Train()

    '                        Call m_MatchingTool.RunParams.SetScoreProperty(0, dbAccept)
    '                        Call m_MatchingTool.SaveFiles()


    '                        m_MatchingTool.Dispose()
    '                    End If
    '                Catch ex As Exception
    '                Finally

    '                End Try
    '                For i As Integer = 0 To 4 Step 1
    '                    m_MatchingToolGloBal(i) = Nothing
    '                Next
    '                For i As Integer = 0 To 4 Step 1
    '                    m_MatchingToolLocal(i) = Nothing
    '                Next

    '                'm_roiRec = Nothing
    '                For i As Integer = 0 To 4 Step 1
    '                    pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\GloBal" & i
    '                    If System.IO.Directory.Exists(pMatchingToolPath) = True Then
    '                        If m_MatchingToolGloBal(i) Is Nothing Then m_MatchingToolGloBal(i) = New VisionSystem.CMatchingTool(pMatchingToolPath)
    '                        m_MatchingToolGloBal(i).ReadFiles()
    '                        m_MatchingToolGloBal(i).Pattern.Train()
    '                    End If
    '                Next

    '                For i As Integer = 0 To 4 Step 1
    '                    pMatchingToolPath = CProject.PROJECT_PATH & m_CurProject.Key & "\Image" & "\Local" & i
    '                    If System.IO.Directory.Exists(pMatchingToolPath) = True Then
    '                        If m_MatchingToolLocal(i) Is Nothing Then m_MatchingToolLocal(i) = New VisionSystem.CMatchingTool(pMatchingToolPath)
    '                        m_MatchingToolLocal(i).ReadFiles()
    '                        m_MatchingToolLocal(i).Pattern.Train()
    '                    End If
    '                Next


    '                Me.ImageViewer1.StaticGraphics.Clear()
    '                Me.ImageViewer1.InteractiveGraphics.Clear()
    '                Call Me.ImageViewer1.StartLive(0, m_Acquist)
    '            Catch ex As Exception
    '            Finally
    '                cbMove.Enabled = True
    '                rbGlobal.Enabled = True
    '                rbLocal.Enabled = True
    '            End Try

    '        End If
    '    Catch ex As Exception
    '    Finally

    '    End Try

    'End Sub




    'Private Sub rbGlobal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim chk As RadioButtonEx = CType(sender, RadioButtonEx)
    '    Select Case chk.Name
    '        Case rbGlobal.Name
    '            m_TypeGlobalLocal = 0
    '        Case rbLocal.Name
    '            m_TypeGlobalLocal = 1
    '        Case Else
    '    End Select

    '    If m_TypeGlobalLocal = 0 Then
    '        txtPositionX.Text = (CDbl(m_Param.RegisterPosition.ListRegisterGlobalAlignPosition(m_ComboxBoxSelectedValue).XAxis))
    '        txtPositionY.Text = (CDbl(m_Param.RegisterPosition.ListRegisterGlobalAlignPosition(m_ComboxBoxSelectedValue).YAxis))
    '        txtPositionZ.Text = (CDbl(m_Param.RegisterPosition.ListRegisterGlobalAlignPosition(m_ComboxBoxSelectedValue).ZAxis))
    '    Else
    '        txtPositionX.Text = (CDbl(m_Param.RegisterPosition.ListRegisterLocalAlignPosition(m_ComboxBoxSelectedValue).XAxis))
    '        txtPositionY.Text = (CDbl(m_Param.RegisterPosition.ListRegisterLocalAlignPosition(m_ComboxBoxSelectedValue).YAxis))
    '        txtPositionZ.Text = (CDbl(m_Param.RegisterPosition.ListRegisterLocalAlignPosition(m_ComboxBoxSelectedValue).ZAxis))
    '    End If
    'End Sub
    Dim m_roiRec As ROIRectangle1
    Private m_ImageViewerSaveImg As VisionSystem.CImage


    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            If m_roiRec IsNot Nothing Then
                Dim startX As Integer = m_roiRec.col1
                Dim startY As Integer = m_roiRec.row1
                Dim endX As Integer = m_roiRec.col2
                Dim endY As Integer = m_roiRec.row2
                If startX <= 0 Then
                    startX = 0
                End If
                If startY <= 0 Then
                    startY = 0
                End If

                If m_ImageViewerSaveImg IsNot Nothing Then
                    Dim pimg As VisionSystem.CImage = m_ImageViewerSaveImg.CropPart_Public(startX, startY, endX, endY)
                    If pimg IsNot Nothing Then
                        Me.ImageViewer2.StaticGraphics.Clear()
                        Me.ImageViewer2.CopyOf(pimg)
                    End If

                End If

            End If
        Catch ex As Exception

        End Try
      
    End Sub

    Private Sub tbAcceptScore_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles tbAcceptScore.KeyPress, tbOffsetY.KeyPress, tbOffsetX.KeyPress, txtCurPosY.KeyPress, txtCurPosX.KeyPress
        If (Not (Char.IsControl(e.KeyChar) OrElse Char.IsDigit(e.KeyChar) OrElse e.KeyChar = "."c)) Then
            e.Handled = True
            Exit Sub
        End If
        Dim ctrl As TextBox = CType(sender, TextBox)
        If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            Dim axisNum As Integer
            Dim nowEncoder As Double

            axisNum = enumAxis.WorkholderX
            Call m_Motion.GetCmd(axisNum, nowEncoder)
            txtCurPosX.Text = CStr(CInt(nowEncoder) * m_ShowScale)

            axisNum = enumAxis.WorkholderY
            Call m_Motion.GetCmd(axisNum, nowEncoder)
            txtCurPosY.Text = CStr(CInt(nowEncoder) * m_ShowScale)

           
        Catch ex As Exception

        End Try
    End Sub
End Class