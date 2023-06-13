Imports System.IO
Public Class FNewProject
    Private m_IsOK As Boolean = False
    Private m_NewProject As CProject
    Private m_lstProject As List(Of CProject)

    Public ReadOnly Property IsOK As Boolean
        Get
            Return m_IsOK
        End Get
    End Property
    Public ReadOnly Property Project As CProject
        Get
            Return m_NewProject
        End Get
    End Property
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        m_IsOK = False
        m_NewProject = Nothing
        Me.Close()
    End Sub
    Private Const MCS_PRODUCT_DIRECTORY As String = "D:\DataSettings\LaserMachine\MachineData\Products"
    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Try
            If (CheckProject() = True) Then
                m_lstProject.Add(m_NewProject)

                If (chkInheritance.Checked) Then
                    Dim selectProjectIdx As Integer = cboCloneProject.SelectedIndex
                    If (selectProjectIdx >= 0) Then
                        Try
                            My.Computer.FileSystem.CopyDirectory(CProject.PROJECT_PATH & m_lstProject(selectProjectIdx).ProjectName, CProject.PROJECT_PATH & m_NewProject.ProjectName)
                        Catch ex As Exception

                        End Try

                        Try
                            My.Computer.FileSystem.DeleteFile(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Log\Log.log")
                        Catch ex As Exception

                        End Try

                    End If
                Else
                    My.Computer.FileSystem.CreateDirectory(CProject.PROJECT_PATH & m_NewProject.ProjectName)
                    My.Computer.FileSystem.CreateDirectory(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Image")
                    My.Computer.FileSystem.CreateDirectory(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Job")
                    My.Computer.FileSystem.CreateDirectory(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Parameter")
                    My.Computer.FileSystem.CreateDirectory(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Log")
                    Dim sw As StreamWriter = New StreamWriter(CProject.PROJECT_PATH & m_NewProject.ProjectName & "\Job\ListJob.job", False)
                    sw.Write("")
                    sw.Close()

                    'Dim param As CParam = New CParam(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
                    'param.SaveParam(CProject.PROJECT_PATH & m_NewProject.Key)

                End If
                CProject.SaveProject(m_lstProject)
                MLog.SaveLog(New Clog("添加新項目", m_NewProject.ProjectName, enumLogType.Edit))
                m_IsOK = True
                Me.Close()
            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("創建新項目時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub txtProjectName_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProjectName.KeyPress
        If (e.KeyChar = "\"c Or e.KeyChar = "/"c Or e.KeyChar = "?"c Or e.KeyChar = "*"c Or e.KeyChar = ":"c Or e.KeyChar = "<"c Or e.KeyChar = ">"c Or e.KeyChar = "|"c Or e.KeyChar = """"c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub FNewProject_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        m_NewProject = New CProject()
        cboCloneProject.Items.Clear()
        CProject.LoadProject(m_lstProject)
        For i = 0 To m_lstProject.Count - 1
            cboCloneProject.Items.Add(m_lstProject(i).ProjectName)
        Next
        If (m_lstProject.Count > 0) Then
            cboCloneProject.SelectedIndex = 0
        End If
        If (cboCloneProject.Items.Count > 0) Then
            chkInheritance.Enabled = True
        Else
            chkInheritance.Enabled = False
        End If
    End Sub


    Private Sub chkInheritance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInheritance.CheckedChanged
        cboCloneProject.Enabled = chkInheritance.Checked
        gbInformation.Enabled = Not chkInheritance.Checked
    End Sub

    Private Sub btnCheckDuplication_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCheckDuplication.Click
        If (CheckProject()) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("可用的項目名稱。"), CChangeLanguage.GetString("新項目消息"), MessageBoxButtons.OK, MessageBoxIcon.OK)
        End If
    End Sub
    Private Function CheckProject() As Boolean
        CheckProject = False
        If (txtProjectName.Text.Trim() = "") Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請輸入項目名稱。"), CChangeLanguage.GetString("新項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtProjectName.Focus()
            Exit Function
        End If

        Dim chkDuplicationProjectName = (From pro As CProject In m_lstProject
                                        Where pro.ProjectName.ToLower() = txtProjectName.Text.Trim().ToLower()
                                        Select pro).ToList()
        If (chkDuplicationProjectName IsNot Nothing AndAlso chkDuplicationProjectName.Count > 0) Then
            txtProjectName.Focus()
            FMessageBox.Show(Me, CChangeLanguage.GetString("項目名稱已存在，請輸入其他項目名稱。"), CChangeLanguage.GetString("新項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Function
        End If
        If (chkInheritance.Checked AndAlso cboCloneProject.SelectedIndex >= 0) Then
            m_NewProject = New CProject()
            With m_NewProject
                .ProjectName = txtProjectName.Text.Trim()
                .Description = m_lstProject(cboCloneProject.SelectedIndex).Description
                .Height = m_lstProject(cboCloneProject.SelectedIndex).Height
                .Time = DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss")
                .Width = m_lstProject(cboCloneProject.SelectedIndex).Width
                .XMin = m_lstProject(cboCloneProject.SelectedIndex).XMin
                .YMin = m_lstProject(cboCloneProject.SelectedIndex).YMin
                .WorkStep = m_lstProject(cboCloneProject.SelectedIndex).WorkStep
            End With
        Else
            m_NewProject = New CProject(txtProjectName.Text.Trim(), DateTime.Now.ToString("[yyyy-MM-dd] HH:mm:ss"), CDbl(numXMin.Value), CDbl(numYMin.Value), CDbl(numWidth.Value), CDbl(numHeight.Value), txtDescription.Text.Trim(), numWorkStep.Value)
        End If
        CheckProject = True
    End Function

    Private Sub cboCloneProject_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCloneProject.KeyPress
        e.Handled = True
    End Sub

    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
End Class