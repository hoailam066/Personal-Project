Imports System.IO

Public Class FLogin

    Private m_lstPassword As List(Of String)
    Private m_LoginOK As Boolean = False
    Public ReadOnly Property LoginOK As Boolean
        Get
            Return m_LoginOK
        End Get
    End Property
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        m_LoginOK = False
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(sender As System.Object, e As System.EventArgs) Handles btnLogin.Click
        Dim pass As String = MEncoderPassword.Encrypt(txtPassword.Text)
        If (rbAdmin.Checked) Then
            If ((m_lstPassword(0) = "" AndAlso txtPassword.Text = "") OrElse m_lstPassword(0) = pass) Then
                m_LoginOK = True
                CLoginInformation.CurrentUser = New CPermission("管理員", m_lstPassword(0), 1, -1)
                Me.Close()
            ElseIf ((m_lstPassword(2) = "" AndAlso txtPassword.Text = "") OrElse m_lstPassword(2) = pass) Then
                m_LoginOK = True
                CLoginInformation.CurrentUser = New CPermission("升億服務員", m_lstPassword(2), 999, -1)
                Me.Close()
            Else
                m_LoginOK = False
                FMessageBox.Show(Me, CChangeLanguage.GetString("登錄失敗。 密碼錯誤。"), CChangeLanguage.GetString("登錄結果"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtPassword.Focus()
            End If
        Else
            'If ((m_lstPassword(1) = "" AndAlso txtPassword.Text = "") OrElse m_lstPassword(1) = pass) Then
            m_LoginOK = True
            CLoginInformation.CurrentUser = New CPermission("操作員", m_lstPassword(1), 0, -1)
            Me.Close()
            '    Else
            '    m_LoginOK = False
            '    FMessageBox.Show("Login failed. Wrong password." & vbCrLf & "(登錄失敗。 密碼錯誤。)", "Login result", MessageBoxButtons.OK, MessageBoxIcon.Error)
            '    txtPassword.Focus()
            'End If
        End If
    End Sub

    Private Sub FLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
        m_lstPassword = New List(Of String)
        m_LoginOK = False
        m_lstPassword = CPermission.CheckPermissionLocation()
        'If (My.Computer.Name.ToLower.IndexOf("alin") > -1) Then
        txtPassword.Text = "1"
        '    btnLogin_Click(Nothing, Nothing)
        'End If
    End Sub

    Private Sub rbAdmin_Click(sender As System.Object, e As System.EventArgs) Handles rbAdmin.Click, rbOperator.Click

        If (rbAdmin.Checked = True) Then
            txtPassword.Enabled = True
            txtPassword.Focus()
        Else
            txtPassword.Enabled = False
        End If
    End Sub

    Private Sub txtPassword_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtPassword.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            btnLogin_Click(Nothing, Nothing)
        ElseIf (e.KeyCode = Keys.Escape) Then
            btnCancel_Click(Nothing, Nothing)
        End If
    End Sub

    Public Sub New(Optional ByVal pAdmin As Boolean = False)
        Try
            If (System.IO.File.Exists("D:\DataSettings\LaserMachine\MachineData\User\Language.lang")) Then
                Dim lang As String = System.IO.File.ReadAllText("D:\DataSettings\LaserMachine\MachineData\User\Language.lang")
                If (lang = "en-US") Then
                    CChangeLanguage.setLanguage(Language.English)
                Else
                    CChangeLanguage.setLanguage(Language.Chinese)
                End If
            Else
                CChangeLanguage.setLanguage(Language.Chinese)
            End If
        Catch ex As Exception
            CChangeLanguage.setLanguage(Language.Chinese)
        End Try

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If (pAdmin = False) Then
            rbOperator.Checked = True
        Else
            rbAdmin.Checked = True
        End If
    End Sub

End Class