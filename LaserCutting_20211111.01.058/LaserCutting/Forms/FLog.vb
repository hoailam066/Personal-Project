Public Class FLog
    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dgvView.EnableHeadersVisualStyles = False
        dgvView.Columns.Clear()
        dgvView.ColumnCount = 5
        dgvView.Columns(0).FillWeight = 40
        dgvView.Columns(1).FillWeight = 100
        dgvView.Columns(2).FillWeight = 35
        dgvView.Columns(3).FillWeight = 35
        dgvView.Columns(4).FillWeight = 35
        dgvView.Columns(0).HeaderText = CChangeLanguage.GetString("時間")
        dgvView.Columns(1).HeaderText = CChangeLanguage.GetString("參數名稱")
        dgvView.Columns(2).HeaderText = CChangeLanguage.GetString("舊價值")
        dgvView.Columns(3).HeaderText = CChangeLanguage.GetString("新價值")
        dgvView.Columns(4).HeaderText = CChangeLanguage.GetString("類型")
        Dim cs = dgvView.Columns(0).DefaultCellStyle
        cs.Alignment = DataGridViewContentAlignment.MiddleLeft
        cs.WrapMode = DataGridViewTriState.True
        dgvView.Columns(0).DefaultCellStyle = cs
        dgvView.Columns(1).DefaultCellStyle = cs
        dgvView.Columns(2).DefaultCellStyle = cs
        dgvView.Columns(3).DefaultCellStyle = cs
        dgvView.Columns(4).DefaultCellStyle = cs
        LoadLog("D:\DataSettings\LaserMachine\Logs\" & DateTime.Today.ToString("yyyyMMdd") & ".log")
    End Sub
    Dim m_startDate, m_endDate As DateTime
    Private Sub btnFilter_Click(sender As System.Object, e As System.EventArgs) Handles btnFilter.Click
        If (dtpkToDate.Value - dtpkFromDate.Value).TotalSeconds <= 0 Then
            FMessageBox.Show(CChangeLanguage.GetString("日期選擇無效"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            Dim LoadingForm As FLoading = New FLoading(CChangeLanguage.GetString("加載中..."))
            Try
                LoadingForm.Show()
                If (m_ListLog IsNot Nothing) Then
                    m_ListLog.Clear()
                Else
                    m_ListLog = New List(Of Clog)
                End If
                LoadingForm.Percent = 10
                Dim startDay As DateTime = New DateTime(dtpkFromDate.Value.Year, dtpkFromDate.Value.Month, dtpkFromDate.Value.Day)
                Dim endDay As DateTime = New DateTime(dtpkToDate.Value.Year, dtpkToDate.Value.Month, dtpkToDate.Value.Day)
                Dim totalday As Integer = (endDay - startDay).TotalDays
                m_startDate = dtpkFromDate.Value
                m_endDate = dtpkToDate.Value
                Dim lstAllLog As New List(Of Clog)
                Dim d As DateTime
                Dim path As String
                Dim lst As New List(Of Clog)
                For i = 0 To totalday
                    d = startDay.AddDays(i)
                    path = "D:\DataSettings\LaserMachine\Logs\" & d.ToString("yyyyMMdd") & ".log"
                    MLog.LoadLog(lst, path)
                    lstAllLog.AddRange(lst)
                    lst.Clear()
                Next
                LoadingForm.Percent = 20
                If (chkOpenClose.Checked = True) Then
                    lst = (From log As Clog In lstAllLog
                           Where log.LogType = enumLogType.OpenClose AndAlso m_startDate <= log.DateAndTime AndAlso log.DateAndTime <= m_endDate).ToList()
                    If (lst IsNot Nothing) Then
                        m_ListLog.AddRange(lst)
                        lst.Clear()
                    End If
                End If
                LoadingForm.Percent = 30
                If (chkStartStop.Checked = True) Then
                    lst = (From log As Clog In lstAllLog
                          Where log.LogType = enumLogType.StartStop AndAlso m_startDate <= log.DateAndTime AndAlso log.DateAndTime <= m_endDate).ToList()
                    If (lst IsNot Nothing) Then
                        m_ListLog.AddRange(lst)
                        lst.Clear()
                    End If
                End If
                LoadingForm.Percent = 40
                If (chkError.Checked = True) Then
                    lst = (From log As Clog In lstAllLog
                          Where log.LogType = enumLogType.Error AndAlso m_startDate <= log.DateAndTime AndAlso log.DateAndTime <= m_endDate).ToList()
                    If (lst IsNot Nothing) Then
                        m_ListLog.AddRange(lst)
                        lst.Clear()
                    End If
                End If
                LoadingForm.Percent = 50
                If (chkEdit.Checked = True) Then
                    lst = (From log As Clog In lstAllLog
                          Where log.LogType = enumLogType.Edit AndAlso m_startDate <= log.DateAndTime AndAlso log.DateAndTime <= m_endDate).ToList()
                    If (lst IsNot Nothing) Then
                        m_ListLog.AddRange(lst)
                        lst.Clear()
                    End If
                End If
                Dim stepPecent As Double = (40.0 / (m_ListLog.Count + 1))
                If (stepPecent * (m_ListLog.Count + 1) > 40.0) Then
                    stepPecent -= 0.1
                End If
                Dim stepcnt As Integer = 1
                m_ListLog = (From log As Clog In m_ListLog
                                        Order By log.DateAndTime Ascending).ToList()
                dgvView.Rows.Clear()
                For i = 0 To m_ListLog.Count - 1
                    Select Case m_ListLog(i).LogType
                        Case enumLogType.Edit, enumLogType.OpenClose
                            dgvView.Rows.Add(New Object() {m_ListLog(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(m_ListLog(i).LogString), m_ListLog(i).OldValue, m_ListLog(i).NewValue, m_ListLog(i).LogType.ToString()})
                        Case Else
                            dgvView.Rows.Add(New Object() {m_ListLog(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(m_ListLog(i).LogString), "", "", m_ListLog(i).LogType.ToString()})
                    End Select
                    LoadingForm.Percent = 60 + (stepcnt * stepPecent)
                    stepcnt += 1
                Next
                LoadingForm.Percent = 100
            Catch
            End Try
            LoadingForm.Dispose()
            LoadingForm = Nothing
        End If

































        'Try
        '    OpenFileDialog1.Filter = "Log file (*.log)|*.log|Text files (*.txt)|*.txt"
        '    OpenFileDialog1.FileName = ""
        '    OpenFileDialog1.InitialDirectory = MLog.CheckRunLogLocation

        '    If (OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
        '        LoadLog(OpenFileDialog1.FileName)
        '    End If
        'Catch ex As Exception

        'End Try

    End Sub
    Private m_ListLog As List(Of Clog)
    Public Sub LoadLog(ByVal pPath As String)
        Dim LoadingForm As FLoading = New FLoading(CChangeLanguage.GetString("加載中..."))
        Try
            m_ListLog = New List(Of Clog)
            dgvView.Rows.Clear()
            dgvView.Refresh()
            LoadingForm.Show()
            LoadingForm.Percent = 10
            MLog.LoadLog(m_ListLog, pPath)
            LoadingForm.Percent = 25
            If (m_ListLog IsNot Nothing AndAlso m_ListLog.Count > 0) Then
                m_ListLog.Reverse()
                 
                LoadingForm.Percent = 40
                Dim stepPecent As Double = (60.0 / (m_ListLog.Count + 1))
                If (stepPecent * (m_ListLog.Count + 1) > 60.0) Then
                    stepPecent -= 0.1
                End If
                Dim stepcnt As Integer = 1
                For i = 0 To m_ListLog.Count - 1

                    Select Case m_ListLog(i).LogType
                        Case enumLogType.Edit
                            dgvView.Rows.Add(New Object() {m_ListLog(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(m_ListLog(i).LogString), m_ListLog(i).OldValue, m_ListLog(i).NewValue, m_ListLog(i).LogType.ToString()})
                        Case Else
                            dgvView.Rows.Add(New Object() {m_ListLog(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(m_ListLog(i).LogString), "", "", m_ListLog(i).LogType.ToString()})
                    End Select
                     
                    'Select Case dgvView.ColumnCount
                    '    Case 2
                    '        dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString), lst(i).LogType.ToString()})
                    '    Case 3
                    '        dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString) & ": " & lst(i).NewValue, lst(i).LogType.ToString()})
                    '    Case 4
                    '        dgvView.Rows.Add(New Object() {lst(i).DateAndTime.ToString("yyyy-MM-dd HH:mm:ss"), CChangeLanguage.GetString(lst(i).LogString), lst(i).OldValue, lst(i).NewValue, lst(i).LogType.ToString()})
                    '    Case Else
                    'End Select
                    LoadingForm.Percent = 40 + (stepcnt * stepPecent)
                    stepcnt += 1
                Next
                LoadingForm.Percent = 100
            Else
               
            End If
            LoadingForm.Close()
        Catch ex As Exception
            LoadingForm.Close()
            FMessageBox.Show(Me, CChangeLanguage.GetString("打開此文件時出錯。"), CChangeLanguage.GetString("查看日誌消息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        LoadingForm.Dispose()
    End Sub

    Private Sub FLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        dtpkFromDate.Value = DateTime.Today
        dtpkFromDate.Value = dtpkFromDate.Value.AddHours(8)
        dtpkFromDate.Value = dtpkFromDate.Value.AddMinutes(30)
        dtpkToDate.Value = DateTime.Today
        dtpkToDate.Value = dtpkToDate.Value.AddHours(17)
        dtpkToDate.Value = dtpkToDate.Value.AddMinutes(30)

    End Sub

    Private Sub chkUseFilter_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUseFilter.CheckedChanged
        GroupBox1.Enabled = chkUseFilter.Checked
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim floading As FLoading = New FLoading("Exporting.....")
        Try
            Dim exportPath As String = "D:\DataSettings\LaserMachine\MachineData\Export\"
            Dim headerPath As String = exportPath & "Header.txt"
            Dim rowPath As String = exportPath & "Row.txt"
            Dim footerPath As String = exportPath & "Footer.txt"
            If (System.IO.Directory.Exists(exportPath)) Then
                If (System.IO.File.Exists(headerPath)) Then
                    If (System.IO.File.Exists(rowPath)) Then
                        If (System.IO.File.Exists(footerPath)) Then
                            Dim sfdg As SaveFileDialog = New SaveFileDialog()
                            sfdg.Filter = "XML file|*.xml"
                            sfdg.FileName = DateTime.Today.ToString("yyyyMMdd")
                            sfdg.InitialDirectory = "C:\Users\" & Environment.UserName & "\Desktop\"
                            If (sfdg.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                                floading.Show()
                                floading.Percent = 10
                                Dim header As String = System.IO.File.ReadAllText(headerPath)
                                Dim row As String = System.IO.File.ReadAllText(rowPath)
                                Dim footer As String = System.IO.File.ReadAllText(footerPath)
                                Dim allString As String = ""
                                floading.Percent = 20
                                Dim stepPecent As Double = (70.0 / (m_ListLog.Count + 1))
                                If (stepPecent * (m_ListLog.Count + 1) > 70.0) Then
                                    stepPecent -= 0.1
                                End If
                                Dim stepcnt As Integer = 1
                                For i = 0 To m_ListLog.Count - 1
                                    allString = allString & String.Format(row, i + 1, m_ListLog(i).DateAndTime, m_ListLog(i).LogString, m_ListLog(i).OldValue, m_ListLog(i).NewValue, m_ListLog(i).LogType) & vbCrLf
                                    floading.Percent = 20 + (stepcnt * stepPecent)
                                    stepcnt += 1
                                Next
                                Dim d As String = ""
                                If (chkUseFilter.Checked = True) Then
                                    d = "(" & m_startDate.ToString("yyyy年MM月dd日 tt hh:mm:ss") & " 至 " & m_endDate.ToString("yyyy年MM月dd日 tt hh:mm:ss") & ")"
                                Else
                                    d = "(" & DateTime.Today.ToString("yyyy年MM月dd日") & ")"
                                End If
                                allString = String.Format(header, d) & allString & footer
                                System.IO.File.WriteAllText(sfdg.FileName, allString)
                            End If
                            floading.Percent = 100
                        Else
                            FMessageBox.Show("No templete file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    Else
                        FMessageBox.Show("No templete file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                Else
                    FMessageBox.Show("No templete file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Else
                FMessageBox.Show("No templete file", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            FMessageBox.Show("Export error !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        floading.Dispose()
        floading = Nothing
    End Sub
End Class