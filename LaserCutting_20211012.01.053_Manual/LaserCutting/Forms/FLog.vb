Public Class FLog
    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dgvView.EnableHeadersVisualStyles = False
    End Sub
    Private Sub btnOpen_Click(sender As System.Object, e As System.EventArgs) Handles btnOpen.Click
        Dim LoadingForm As FLoading = New FLoading(CChangeLanguage.GetString("加載中..."))
        Try
            OpenFileDialog1.Filter = "Log file (*.log)|*.log|Text files (*.txt)|*.txt"
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.InitialDirectory = MLog.CheckRunLogLocation
            Dim lst As List(Of Clog) = New List(Of Clog)
            If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                dgvView.Rows.Clear()
                dgvView.Refresh()
                LoadingForm.Show()
                LoadingForm.Percent = 10
                lblPath.Text = OpenFileDialog1.FileName
                MLog.LoadLog(lst, OpenFileDialog1.FileName)
                LoadingForm.Percent = 25
                dgvView.Columns.Clear()
                If (lst IsNot Nothing AndAlso lst.Count > 0) Then
                    lst.Reverse()
                    'Dim log() As String = lst(0).Split("|"c)

                    Select Case lst(0).NumPram
                        Case 2, 3
                            dgvView.ColumnCount = 2
                            dgvView.Columns(0).FillWeight = 30
                            dgvView.Columns(1).FillWeight = 100
                            dgvView.Columns(0).HeaderText = CChangeLanguage.GetString("時間")
                            dgvView.Columns(1).HeaderText = CChangeLanguage.GetString("内容")
                            Dim cs = dgvView.Columns(0).DefaultCellStyle
                            cs.Alignment = DataGridViewContentAlignment.MiddleLeft
                            cs.WrapMode = DataGridViewTriState.True
                            dgvView.Columns(0).DefaultCellStyle = cs
                            dgvView.Columns(1).DefaultCellStyle = cs
                        Case 4
                            dgvView.ColumnCount = 4
                            dgvView.Columns(0).FillWeight = 40
                            dgvView.Columns(1).FillWeight = 100
                            dgvView.Columns(2).FillWeight = 35
                            dgvView.Columns(3).FillWeight = 35
                            dgvView.Columns(0).HeaderText = CChangeLanguage.GetString("時間")
                            dgvView.Columns(1).HeaderText = CChangeLanguage.GetString("參數名稱")
                            dgvView.Columns(2).HeaderText = CChangeLanguage.GetString("舊價值")
                            dgvView.Columns(3).HeaderText = CChangeLanguage.GetString("新價值")
                            Dim cs = dgvView.Columns(0).DefaultCellStyle
                            cs.Alignment = DataGridViewContentAlignment.MiddleLeft
                            cs.WrapMode = DataGridViewTriState.True
                            dgvView.Columns(0).DefaultCellStyle = cs
                            dgvView.Columns(1).DefaultCellStyle = cs
                            dgvView.Columns(2).DefaultCellStyle = cs
                            dgvView.Columns(3).DefaultCellStyle = cs
                        Case Else
                    End Select
                    LoadingForm.Percent = 40
                    Dim stepPecent As Double = (60.0 / (lst.Count + 1))
                    If (stepPecent * (lst.Count + 1) > 60.0) Then
                        stepPecent -= 0.1
                    End If
                    Dim stepcnt As Integer = 1
                    For i = 0 To lst.Count - 1
                        Select Case dgvView.ColumnCount
                            Case 2
                                dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString)})
                            Case 3
                                dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString) & ": " & lst(i).NewValue})
                            Case 4
                                dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString), lst(i).OldValue, lst(i).NewValue})
                            Case Else
                        End Select
                        LoadingForm.Percent = 40 + (stepcnt * stepPecent)
                        stepcnt += 1
                    Next
                    LoadingForm.Percent = 100
                End If
            End If
            LoadingForm.Close()
        Catch ex As Exception
            LoadingForm.Close()
            FMessageBox.Show(Me, CChangeLanguage.GetString("打開此文件時出錯。"), CChangeLanguage.GetString("查看日誌消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        LoadingForm.Dispose()
    End Sub


    Private Sub FLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgvView.ColumnCount = 2
        dgvView.Columns(0).FillWeight = 30
        dgvView.Columns(1).FillWeight = 100
        dgvView.Columns(0).HeaderText = CChangeLanguage.GetString("時間")
        dgvView.Columns(1).HeaderText = CChangeLanguage.GetString("内容")
        Dim cs = dgvView.Columns(0).DefaultCellStyle
        cs.Alignment = DataGridViewContentAlignment.MiddleLeft
        cs.WrapMode = DataGridViewTriState.True
        dgvView.Columns(0).DefaultCellStyle = cs
        dgvView.Columns(1).DefaultCellStyle = cs
    End Sub

    Private Sub lblPath_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblPath.DoubleClick
        btnOpen_Click(Nothing, Nothing)
    End Sub
End Class