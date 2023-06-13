Public Class FChangePassword
    Private m_lstPassword As List(Of String)
    Private m_ChangeToOperatorUI As Boolean = False

    Public ReadOnly Property ChangeToOperatorUI As Boolean
        Get
            Return m_ChangeToOperatorUI
        End Get
    End Property
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Dim curPassword As String = ""
        If (rdAdmin.Checked) Then
            curPassword = m_lstPassword(0)
        Else
            curPassword = m_lstPassword(1)
        End If
        If (MEncoderPassword.Encrypt(txtPassword.Text) <> curPassword) Then
            FMessageBox.ShowError(CChangeLanguage.GetString("舊密碼不正確。"), CChangeLanguage.GetString("更改密碼結果"))
            txtPassword.Focus()
            Exit Sub
        End If
        If (txtNewPassword.Text <> txtNewPassword2.Text) Then
            FMessageBox.ShowError(CChangeLanguage.GetString("新密碼不匹配。"), CChangeLanguage.GetString("更改密碼結果"))
            txtNewPassword2.Focus()
            Exit Sub
        End If
        Dim mode As String = ""
        Dim mode2 As String = ""
        If (rdAdmin.Checked) Then
            mode = "Administrator"
            mode2 = "管理員"
        Else
            mode = "Operator"
            mode2 = "操作員"
        End If
        If (FMessageBox.Show(CChangeLanguage.GetString("您確定要更改""" & mode2 & """密碼嗎？"), CChangeLanguage.GetString("更改密碼信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            If (rdAdmin.Checked) Then
                m_lstPassword(0) = MEncoderPassword.Encrypt(txtNewPassword.Text)
                CLoginInformation.CurrentUser.Password = m_lstPassword(0)
            Else
                m_lstPassword(1) = MEncoderPassword.Encrypt(txtNewPassword.Text)
                CLoginInformation.CurrentUser.Password = m_lstPassword(1)
            End If
            CPermission.SavePassword(m_lstPassword)
            If (txtPassword.Text <> txtNewPassword.Text) Then
                MLog.SaveLog("更改" & mode2 & "密碼", CPermission.PERMISSION_PATH & "Log.log")
                'CLog.SaveLog(DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|Changed the " & mode & " password", CPermission.PERMISSION_PATH & "Log.log")
            End If
            FMessageBox.Show(CChangeLanguage.GetString("密碼更改成功。"), CChangeLanguage.GetString("更改密碼結果"), MessageBoxButtons.OK, MessageBoxIcon.OK)
            Me.Close()
        End If
    End Sub

    Private Sub FChangePassword_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        m_lstPassword = New List(Of String)
        m_lstPassword = CPermission.CheckPermissionLocation()
        If (CLoginInformation.CurrentUser.Permission >= 999) Then
            btnReset.Enabled = True
        Else
            btnReset.Enabled = False
        End If
    End Sub

    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        If (CLoginInformation.CurrentUser.Permission >= 999) Then
            If (rdAdmin.Checked = True) Then
                If (FMessageBox.Show(CChangeLanguage.GetString("您確定要重置""管理員""密碼嗎？"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    m_lstPassword(0) = MEncoderPassword.Encrypt("123")
                    CPermission.SavePassword(m_lstPassword)

                    MLog.SaveLog("重置管理員密碼", CPermission.PERMISSION_PATH & "Log.log")

                    'CLog.SaveLog(DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|Reset the Administrator password", CPermission.PERMISSION_PATH & "Log.log")
                    FMessageBox.Show(CChangeLanguage.GetString("密碼重新成功。"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.OK, MessageBoxIcon.OK)
                    Me.Close()
                End If
            Else
                If (FMessageBox.Show(CChangeLanguage.GetString("您確定要重置""操作員""密碼嗎？"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    m_lstPassword(1) = MEncoderPassword.Encrypt("123")
                    CPermission.SavePassword(m_lstPassword)
                    MLog.SaveLog("重置操作員密碼", CPermission.PERMISSION_PATH & "Log.log")
                    'CLog.SaveLog(DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|Reset the Operator password", CPermission.PERMISSION_PATH & "Log.log")
                    FMessageBox.Show(CChangeLanguage.GetString("密碼重新成功。"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.OK, MessageBoxIcon.OK)
                    Me.Close()
                End If
            End If

        Else
            If (FMessageBox.Show(CChangeLanguage.GetString("您確定要重置""操作員""密碼嗎？"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                m_lstPassword(1) = MEncoderPassword.Encrypt("123")
                CPermission.SavePassword(m_lstPassword)
                MLog.SaveLog("重置操作員密碼", CPermission.PERMISSION_PATH & "Log.log")
                'CLog.SaveLog(DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|Reset the Operator password", CPermission.PERMISSION_PATH & "Log.log")
                FMessageBox.Show(CChangeLanguage.GetString("密碼重新成功。"), CChangeLanguage.GetString("重置密碼結果"), MessageBoxButtons.OK, MessageBoxIcon.OK)
                Me.Close()
            End If
        End If
    End Sub

    Private Sub rdOperator_Click(sender As System.Object, e As System.EventArgs) Handles rdOperator.Click
        btnReset.Enabled = True
    End Sub

    Private Sub rdAdmin_Click(sender As System.Object, e As System.EventArgs) Handles rdAdmin.Click
        If (CLoginInformation.CurrentUser.Permission >= 999) Then
            btnReset.Enabled = True
        Else
            btnReset.Enabled = False
        End If
    End Sub

    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class