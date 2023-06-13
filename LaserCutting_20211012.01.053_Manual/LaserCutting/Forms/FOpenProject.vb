Public Class FOpenProject
    Private m_IsOK As Boolean = False
    Private m_NewProject As CProject
    Private m_lstProject As List(Of CProject)
    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        If (CLoginInformation.CurrentUser.Permission >= 1) Then
            btnDelete.Enabled = True
            btnSave.Enabled = True
            txtProject.Enabled = True
        Else
            btnDelete.Enabled = False
            btnSave.Enabled = False
            txtProject.Enabled = False
        End If
    End Sub
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
    Private Sub FOpenProject_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CProject.LoadProject(m_lstProject)
        LoadDataGridView()

    End Sub
    Private m_selectedIdx As Integer
    Private Sub DataGridView1_Click(sender As System.Object, e As System.EventArgs) Handles DataGridView1.Click
        If (DataGridView1.SelectedRows.Count > 0) Then
            m_selectedIdx = DataGridView1.SelectedRows(0).Cells(0).RowIndex
            Try
                txtProject.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString()
            Catch
                txtProject.Text = ""
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        m_IsOK = False
        Me.Close()
    End Sub

    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Try
            If (DataGridView1.SelectedRows.Count > 0) Then
                m_NewProject = m_lstProject(DataGridView1.SelectedRows(0).Index)
                m_IsOK = True
                Me.Close()
            Else
                FMessageBox.Show(Me, CChangeLanguage.GetString("請選擇項目"), CChangeLanguage.GetString("打開項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("打開項目時發生錯誤。 請再試一次。"), CChangeLanguage.GetString("打開項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    Private Sub LoadDataGridView()
        DataGridView1.Rows.Clear()
        For i = 0 To m_lstProject.Count - 1
            With m_lstProject(i)
                DataGridView1.Rows.Add(New Object() {.ProjectName, .WorkStep, .Width, .Height, .XMin, .YMin, .Time, .Description})
                DataGridView1.Rows(i).Height = 28
            End With
        Next
    End Sub
    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.SelectedRows.Count > 0) Then
                'If (CLoginInformation.CurrentUser.Permission <= 0) Then
                'FMessageBox.Show("Only administrator is permitted." & vbCrLf & "(只允許管理員。)", "Delete project message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                'Else
                If (m_NewProject IsNot Nothing AndAlso m_NewProject.ProjectName.ToLower() = m_lstProject(DataGridView1.SelectedRows(0).Index).ProjectName.ToLower()) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("當前項目不會被刪除。"), CChangeLanguage.GetString("刪除項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (FMessageBox.Show(Me, CChangeLanguage.GetString("您確定要刪除項目嗎？"), CChangeLanguage.GetString("刪除項目消息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        Try
                            My.Computer.FileSystem.DeleteDirectory(CProject.PROJECT_PATH & m_lstProject(DataGridView1.SelectedRows(0).Index).ProjectName, FileIO.DeleteDirectoryOption.DeleteAllContents)
                            MLog.SaveLog(New Clog("刪除項目", m_lstProject(DataGridView1.SelectedRows(0).Index).ProjectName))
                            m_lstProject.RemoveAt(DataGridView1.SelectedRows(0).Index)
                            LoadDataGridView()
                            CProject.SaveProject(m_lstProject)
                            txtProject.Text = ""
                        Catch ex As Exception
                            FMessageBox.Show(Me, CChangeLanguage.GetString("當前項目不會被刪除。"), CChangeLanguage.GetString("刪除項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                        End Try
                    End If
                End If
            End If
            'End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("刪除項目時發生錯誤。 請再試一次。"), CChangeLanguage.GetString("刪除項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub


    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        btnOpen_Click(Nothing, Nothing)
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            If (DataGridView1.SelectedRows.Count > 0) Then
                If (m_selectedIdx >= 0) Then
                    If (FMessageBox.Show(Me, CChangeLanguage.GetString("您確定要重命名項目嗎？"), CChangeLanguage.GetString("更改項目消息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        Try
                            Dim oldName As String = m_lstProject(m_selectedIdx).ProjectName
                            My.Computer.FileSystem.RenameDirectory(CProject.PROJECT_PATH & m_lstProject(m_selectedIdx).ProjectName, txtProject.Text)
                            m_lstProject(m_selectedIdx).ProjectName = txtProject.Text
                            LoadDataGridView()
                            CProject.SaveProject(m_lstProject)
                            MLog.SaveLog(New Clog("項目名稱更改", oldName, txtProject.Text), CProject.PROJECT_PATH & m_lstProject(m_selectedIdx).ProjectName & "\Log\Log.log")
                        Catch ex As Exception
                            FMessageBox.Show(Me, CChangeLanguage.GetString("當前無法重命名項目。"), CChangeLanguage.GetString("更改項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                        End Try
                    End If
                End If
            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("當前無法重命名項目。"), CChangeLanguage.GetString("更改項目消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
End Class
