Imports PseudoDevice
Public Class FRegisterPosition
    Private m_path As String = "D:\DataSettings\LaserSolder\Setting\RegisterPosition.set"
    Private m_CurProject As CProject
    Private m_Param, m_OldParam As CParameter
    Private m_SelectedRegisterPosition As Integer = 0
    Private m_ComboxBoxSelectedValue As Integer = 0
    Private m_Motion As CMotion
    Private m_ShowScale As Double = 0.001
    Private m_Speed As Double
    Public Sub New(ByRef pProject As CProject, ByRef pParam As CParameter, ByRef pMotion As CMotion, ByVal pSpeed As Double)
        InitializeComponent()
        m_CurProject = pProject
        If (pParam IsNot Nothing) Then
            m_Param = pParam
        Else
            m_Param = New CParameter(FJobManager.MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
        End If
        m_OldParam = m_Param.Clone(FJobManager.MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
        If Not (pMotion Is Nothing) Then m_Motion = pMotion
        m_Speed = pSpeed
    End Sub


    Private Sub FRegisterPosition_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try

            If rdZ.Checked = True Then
                m_SelectedRegisterPosition = 0
            ElseIf rdXYZR.Checked = True Then
                m_SelectedRegisterPosition = 1
            ElseIf rdS.Checked = True Then
                m_SelectedRegisterPosition = 2
            ElseIf rdOffset.Checked = True Then
                m_SelectedRegisterPosition = 3
            End If
            Dim nowEncoder As Double = 0
            If m_SelectedRegisterPosition = 1 Then
                m_Motion.GetCmd(enumAxis.WorkholderX, nowEncoder)
                txtX.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderY, nowEncoder)
                txtY.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderZ, nowEncoder)
                txtZ.Text = CSng(CInt(nowEncoder) * m_ShowScale)
            ElseIf m_SelectedRegisterPosition = 0 Then
                m_Motion.GetCmd(enumAxis.WorkholderZ, nowEncoder)
                txtZ.Text = CSng(CInt(nowEncoder) * m_ShowScale)
            ElseIf m_SelectedRegisterPosition = 2 Then
                m_Motion.GetCmd(enumAxis.WorkholderX, nowEncoder)
                txtX.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderY, nowEncoder)
                txtY.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderZ, nowEncoder)
                txtZ.Text = CSng(CInt(nowEncoder) * m_ShowScale)
            ElseIf m_SelectedRegisterPosition = 3 Then
                m_Motion.GetCmd(enumAxis.WorkholderX, nowEncoder)
                txtX.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderY, nowEncoder)
                txtY.Text = CSng(CInt(nowEncoder) * m_ShowScale)
                m_Motion.GetCmd(enumAxis.WorkholderZ, nowEncoder)
                txtZ.Text = CSng(CInt(nowEncoder) * m_ShowScale)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Try
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).XAxis = CDbl(txtX.Text)
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).YAxis = CDbl(txtY.Text)
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).ZAxis = CDbl(txtZ.Text)
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).RAxis = 0
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).SAxis = 0

            m_Param.SaveParam(CProject.PROJECT_PATH & m_CurProject.Key)
            m_Param.WriteLog(CProject.PROJECT_PATH & m_CurProject.Key, m_OldParam)
            m_OldParam = m_Param.Clone(FJobManager.MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
        Catch ex As Exception
            FMessageBox.ShowError("There was an error saving." & vbCrLf & "(保存錯誤。)", "Save Register position error", True, ex)
        End Try
    End Sub
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged

        m_ComboxBoxSelectedValue = CInt(ComboBox1.SelectedItem)

        txtX.Text = CSng(CInt(m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).XAxis))
        txtY.Text = CSng(CInt(m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).YAxis))
        txtZ.Text = CSng(CInt(m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).ZAxis))
        txtR.Text = CSng(CInt(m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).RAxis))
        txtS.Text = CSng(CInt(m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).SAxis))
    End Sub

    Private Sub rdXYZR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdZ.Click, rdXYZR.Click, rdS.Click, rdOffset.Click
        Dim rd As RadioButtonEx = CType(sender, RadioButtonEx)
        If (rd.Checked = True) Then
            ComboBox1.Items.Clear()
            If (rd Is rdXYZR) Then
                For index = 0 To 12
                    ComboBox1.Items.Add(CType(index, ePosType))
                Next
                ComboBox1.SelectedItem = ePosType.ReadyPos

                m_SelectedRegisterPosition = CInt(rd.Tag)

                Select Case m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).MotionSequence
                    Case eMotionSequence.R_To_XYZ
                        rdRToXYZ.Checked = True
                    Case eMotionSequence.XYZ_To_R
                        rdXYZToR.Checked = True
                    Case Else
                        rdXYZR2.Checked = True
                End Select
                Panel2.Enabled = True
                btnApply.Visible = False
                chkReverseApply.Visible = False

                txtX.ReadOnly = False
                txtY.ReadOnly = False
                txtZ.ReadOnly = False
                txtR.ReadOnly = False
                txtS.ReadOnly = False
            ElseIf (rd Is rdZ) Then
                ComboBox1.Items.Add(CType(13, ePosType))
                ComboBox1.SelectedIndex = 0
                Panel2.Enabled = False
                btnApply.Visible = True
                chkReverseApply.Visible = False

                txtX.ReadOnly = True
                txtY.ReadOnly = True
                txtZ.ReadOnly = False
                txtR.ReadOnly = True
                txtS.ReadOnly = True

            ElseIf (rd Is rdOffset) Then
                ComboBox1.Items.Add(CType(14, ePosType))
                ComboBox1.Items.Add(CType(15, ePosType))
                ComboBox1.SelectedIndex = 0
                Panel2.Enabled = False
                btnApply.Visible = True
                chkReverseApply.Visible = True

                txtX.ReadOnly = False
                txtY.ReadOnly = False
                txtZ.ReadOnly = False
                txtR.ReadOnly = True
                txtS.ReadOnly = True
            End If

            ComboBox1_SelectedIndexChanged(Nothing, Nothing)
        End If
    End Sub

    Private Sub FRegisterPosition_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs)
        Try
            m_Param.WriteLog(CProject.PROJECT_PATH & m_CurProject.Key, m_OldParam)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub RadioButtonEx1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdXYZR2.Click, rdXYZToR.Click, rdRToXYZ.Click
        Dim rd As RadioButtonEx = CType(sender, RadioButtonEx)
        If (rd.Checked = True) Then
            Dim value As Integer = CInt(rd.Tag)
            m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).MotionSequence = CType(value, eMotionSequence)
        End If
    End Sub

    Private Sub txtX_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZ.KeyPress, txtY.KeyPress, txtX.KeyPress, txtS.KeyPress, txtR.KeyPress
        Dim ctrl As TextBox = CType(sender, TextBox)
        'Check imput only Number key or Control key
        If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Check only 1 decimal point
        'If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
        '    e.Handled = True
        'End If
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        Dim pResult As enumMotionFlag
        If m_Motion.ChkStop(enumAxis.WorkholderX) = enumMotionFlag.eReady Then
            If m_Motion.ChkStop(enumAxis.WorkholderY) = enumMotionFlag.eReady Then
                If m_Motion.ChkStop(enumAxis.WorkholderZ) = enumMotionFlag.eReady Then
                    Select Case m_ComboxBoxSelectedValue
                        Case ePosType.DefaultJobHeight
                            m_Motion.MoveAbs(enumAxis.WorkholderZ, m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).ZAxis / m_ShowScale, pResult, m_Speed)
                        Case Else
                            m_Motion.MoveAbs(enumAxis.WorkholderX, m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).XAxis / m_ShowScale, pResult, m_Speed)
                            m_Motion.MoveAbs(enumAxis.WorkholderY, m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).YAxis / m_ShowScale, pResult, m_Speed)
                            m_Motion.MoveAbs(enumAxis.WorkholderZ, m_Param.RegisterPosition.ListRegisterPosition(m_ComboxBoxSelectedValue).ZAxis / m_ShowScale, pResult, m_Speed)
                    End Select
                 
                End If
            End If
        End If
    End Sub
End Class
Public Enum ePosType As Integer
    ReadyPos = 0
    LoaderReadyPos = 1
    JobReadyPos = 2
    PowerMeasurePos = 3
    BarcodeReaderPos0 = 4
    BarcodeReaderPos1 = 5
    BarcodeReaderPos2 = 6
    BarcodeReaderPos3 = 7
    DischargePos = 8
    CadOrignPos = 9
    FiducialPos0 = 10
    FiducialPos1 = 11
    LocalVisionOffset = 12
    DefaultJobHeight = 13
    CamToSolder = 14
    LaserSenToSolder = 15
End Enum
