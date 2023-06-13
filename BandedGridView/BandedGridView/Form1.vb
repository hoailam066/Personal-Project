Imports System.Windows.Forms
Imports DevExpress.Data.Filtering
Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DHSErp.Entities.Core
Imports DHSErp.Util
Public Class Form1
    Private m_lstBand As List(Of ReportBandedGridViewResx)
    Private m_lstColumn As List(Of ReportBandGridColumnResx)
    Private m_lstColumnFilter As List(Of ReportBandGridColumnResx)
    Private m_lstExcelObject As List(Of ReportBandGridExportExcelResx)
    Private m_oldBandName As String = ""
    Private m_dtPreview As DataTable
    Private m_dtType As DataTable

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PrepareConnect()
        m_lstBand = New List(Of ReportBandedGridViewResx)
        m_lstColumn = New List(Of ReportBandGridColumnResx)
        m_lstColumnFilter = New List(Of ReportBandGridColumnResx)
        LoadData()
        LoadPreview()
    End Sub


    Private Sub PrepareConnect()
        Try
            DHSErp.DAL.SqlHelper.SetParamHeader("@P")
            DHSErp.Util.CreateConnectionString.SetIniFile("Setting\Setting.ini")
            DHSErp.Util.CreateConnectionString.SetConnectionByIndex()
        Catch ex As Exception
            MessageBox.Show("Chưa cấu hình kết nối server.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(0)
        End Try
    End Sub

    Private Sub LoadPreview()
        Common.FormartBandedGridView(bgvPreview, DHSErp.Util.ConvertHelper.ListToDataTable(Of ReportBandedGridViewResx)(m_lstBand), DHSErp.Util.ConvertHelper.ListToDataTable(Of ReportBandGridColumnResx)(m_lstColumn))
        LoadDataPreview()
        gridPreview.DataSource = m_dtPreview
    End Sub

    Private Sub LoadDataPreview()
        m_dtPreview = New DataTable()
        For i = 0 To m_lstColumn.Count - 1
            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(m_lstColumn(i).FORMAT_TYPE).ToUpper()
                Case "NUMERIC"
                    m_dtPreview.Columns.Add(m_lstColumn(i).FIELD_NAME.ToUpper(), GetType(Decimal))
                Case "DATETIME", "DATE"
                    m_dtPreview.Columns.Add(m_lstColumn(i).FIELD_NAME.ToUpper(), GetType(DateTime))
                Case Else
                    m_dtPreview.Columns.Add(m_lstColumn(i).FIELD_NAME.ToUpper(), GetType(String))
            End Select
        Next
        Dim dr As DataRow = m_dtPreview.NewRow()
        Dim dr2 As DataRow = m_dtPreview.NewRow()
        For i = 0 To m_lstColumn.Count - 1
            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(m_lstColumn(i).FORMAT_TYPE).ToUpper()
                Case "NUMERIC"
                    dr(m_lstColumn(i).FIELD_NAME.ToUpper()) = 123456.123456789
                    dr2(m_lstColumn(i).FIELD_NAME.ToUpper()) = 123456.123456789
                Case "DATETIME", "DATE"
                    dr(m_lstColumn(i).FIELD_NAME.ToUpper()) = DateTime.Now
                    dr2(m_lstColumn(i).FIELD_NAME.ToUpper()) = DateTime.Now
                Case Else
                    dr(m_lstColumn(i).FIELD_NAME.ToUpper()) = "String data"
                    dr2(m_lstColumn(i).FIELD_NAME.ToUpper()) = "String data"
            End Select
        Next

        m_dtPreview.Rows.Add(dr)
        m_dtPreview.Rows.Add(dr2)
    End Sub

    Private Sub LoadData()
        Try
            m_lstBand = DHSErp.Util.ConvertHelper.TableToList(Of ReportBandedGridViewResx)(DHSErp.DAL.SqlHelper.ExecGetDataTable("spReportBandedGridViewResxGet", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys))
            m_lstColumn = DHSErp.Util.ConvertHelper.TableToList(Of ReportBandGridColumnResx)(DHSErp.DAL.SqlHelper.ExecGetDataTable("spReportBandGridColumnResxGet", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys))
            m_lstExcelObject = DHSErp.Util.ConvertHelper.TableToList(Of ReportBandGridExportExcelResx)(DHSErp.DAL.SqlHelper.ExecGetDataTable("spReportBandGridExportExcelResxGet", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys))
        Catch ex As Exception
            m_lstBand = New List(Of ReportBandedGridViewResx)()
            m_lstColumn = New List(Of ReportBandGridColumnResx)()
            m_lstColumnFilter = New List(Of ReportBandGridColumnResx)()
            m_lstExcelObject = New List(Of ReportBandGridExportExcelResx)()
        End Try
        lsbBand.DataSource = m_lstBand
        lsbBand.DisplayMember = "DISPLAYTEXT"
        lsbBand.ValueMember = "BAND_NAME"

        lsbColumn.DataSource = m_lstColumnFilter
        lsbColumn.DisplayMember = "DISPLAYTEXT"
        lsbColumn.ValueMember = "FIELD_NAME"

        lsbExcelObject.DataSource = m_lstExcelObject
        lsbExcelObject.DisplayMember = "DISPLAYTEXT"
        lsbExcelObject.ValueMember = "DISPLAYTEXT"

        lsbBand_SelectedIndexChanged(Nothing, Nothing)
        lsbExxcelObject_SelectedIndexChanged(Nothing, Nothing)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim err As String = ""
        DHSErp.DAL.SqlHelper.ExcuteNonQuery("spReportBandedGridViewResxDel", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys)
        DHSErp.DAL.SqlHelper.ExcuteNonQuery("spReportBandGridColumnResxDel", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys)
        DHSErp.DAL.SqlHelper.ExcuteNonQuery("spReportBandGridExportExcelResxDel", New With {.MENUID = txtmenuid.Text.Trim(), .MA_MAU = txtmamau.Text.Trim(), .RET = 0}, CommandType.StoredProcedure, GlobalObject.KeyIndexSys)
        DHSErp.DAL.SqlHelper.ExcuteNonQueryWithListObject(Of ReportBandedGridViewResx)("spReportBandedGridViewResxIns", m_lstBand, err, GlobalObject.KeyIndexSys)
        DHSErp.DAL.SqlHelper.ExcuteNonQueryWithListObject(Of ReportBandGridColumnResx)("spReportBandGridColumnResxIns", m_lstColumn, err, GlobalObject.KeyIndexSys)
        DHSErp.DAL.SqlHelper.ExcuteNonQueryWithListObject(Of ReportBandGridExportExcelResx)("spReportBandGridExportExcelResxIns", m_lstExcelObject, err, GlobalObject.KeyIndexSys)
        MessageBox.Show("Đã lưu", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub lsbBand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbBand.SelectedIndexChanged
        Dim rObj As ReportBandedGridViewResx = lsbBand.SelectedItem
        If rObj Is Nothing Then
            lsbColumn.DataSource = Nothing
            PropertyColumn.SelectedObject = Nothing
            GroupControl4.Text = "Band column"
            Exit Sub
        End If
        GroupControl4.Text = "List column of band: " & rObj.CAPTION
        PropertyBand.SelectedObject = rObj
        m_lstColumnFilter = m_lstColumn.Where(Function(t) t.BAND_NAME.ToUpper = rObj.BAND_NAME.ToUpper).ToList()
        lsbColumn.DataSource = m_lstColumnFilter
    End Sub

    Private Sub lsbColumn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbColumn.SelectedIndexChanged
        PropertyColumn.SelectedObject = lsbColumn.SelectedItem
    End Sub

    Private Sub PropertyBand_PropertyValueChanged(s As Object, e As PropertyValueChangedEventArgs) Handles PropertyBand.PropertyValueChanged, PropertyColumn.PropertyValueChanged, PropertyExcelObject.PropertyValueChanged
        LoadPreview()
    End Sub

    Private Sub btnBandAdd_Click(sender As Object, e As EventArgs) Handles btnBandAdd.Click
        Try
            Dim rObj As ReportBandedGridViewResx = New ReportBandedGridViewResx()
            Dim i As Integer = 0
            Dim bandname As String = "GridBand" & i
            Do
                Dim chk = m_lstBand.Where(Function(t) t.BAND_NAME.ToUpper() = bandname.ToUpper()).ToList()
                If chk.Count > 0 Then
                    i += 1
                    bandname = "GridBand" & i
                Else
                    Exit Do
                End If
            Loop
            rObj.MENUID = txtmenuid.Text.Trim
            rObj.MA_MAU = txtmamau.Text.Trim
            rObj.BAND_NAME = bandname
            rObj.CAPTION = bandname
            rObj.VISIBLE_INDEX = m_lstBand.Count
            rObj.VISIBLE = True
            m_lstBand.Add(rObj)
            lsbBand.Refresh()
            LoadPreview()
            lsbBand.SelectedIndex = lsbBand.ItemCount - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBandDel_Click(sender As Object, e As EventArgs) Handles btnBandDel.Click
        Try
            Dim rObj As ReportBandedGridViewResx = lsbBand.SelectedItem
            Dim index As Integer = lsbBand.SelectedIndex
            m_lstBand.Remove(rObj)
            For i = 0 To m_lstColumn.Count - 1
                If i >= m_lstColumn.Count Then
                    Exit For
                End If
                If m_lstColumn(i).BAND_NAME.ToUpper() = rObj.BAND_NAME.ToUpper() Then
                    m_lstColumn.RemoveAt(i)
                    i -= 1
                End If
            Next
            For i = 0 To m_lstColumnFilter.Count - 1
                If i >= m_lstColumnFilter.Count Then
                    Exit For
                End If
                If m_lstColumnFilter(i).BAND_NAME.ToUpper() = rObj.BAND_NAME.ToUpper() Then
                    m_lstColumnFilter.RemoveAt(i)
                    i -= 1
                End If
            Next
            lsbBand.Refresh()
            lsbColumn.Refresh()
            LoadPreview()
            If m_lstBand.Count > 0 Then
                If index - 1 >= 0 Then
                    lsbBand.SelectedIndex = index - 1
                Else
                    lsbBand.SelectedIndex = index
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBandUp_Click(sender As Object, e As EventArgs) Handles btnBandUp.Click
        Try
            If lsbBand.SelectedIndex > 0 Then
                Dim rObj As ReportBandedGridViewResx = m_lstBand(lsbBand.SelectedIndex)
                Dim rObj_up As ReportBandedGridViewResx = m_lstBand(lsbBand.SelectedIndex - 1)
                Dim index = rObj.VISIBLE_INDEX
                rObj.VISIBLE_INDEX = rObj_up.VISIBLE_INDEX
                rObj_up.VISIBLE_INDEX = index
                m_lstBand(lsbBand.SelectedIndex) = rObj_up
                m_lstBand(lsbBand.SelectedIndex - 1) = rObj
                lsbBand.SelectedIndex = lsbBand.SelectedIndex - 1
                lsbBand.Refresh()
                LoadPreview()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnBandDown_Click(sender As Object, e As EventArgs) Handles btnBandDown.Click
        Try
            If lsbBand.SelectedIndex < lsbBand.ItemCount Then
                Dim rObj As ReportBandedGridViewResx = m_lstBand(lsbBand.SelectedIndex)
                Dim rObj_down As ReportBandedGridViewResx = m_lstBand(lsbBand.SelectedIndex + 1)
                Dim index = rObj.VISIBLE_INDEX
                rObj.VISIBLE_INDEX = rObj_down.VISIBLE_INDEX
                rObj_down.VISIBLE_INDEX = index
                m_lstBand(lsbBand.SelectedIndex) = rObj_down
                m_lstBand(lsbBand.SelectedIndex + 1) = rObj
                lsbBand.SelectedIndex = lsbBand.SelectedIndex + 1
                lsbBand.Refresh()
                LoadPreview()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnColumnAdd_Click(sender As Object, e As EventArgs) Handles btnColumnAdd.Click
        Try
            Dim band As ReportBandedGridViewResx = lsbBand.SelectedItem
            If band IsNot Nothing Then
                Dim rObj As ReportBandGridColumnResx = New ReportBandGridColumnResx()
                Dim lstfilter = m_lstColumn.Where(Function(t) t.BAND_NAME = band.BAND_NAME).ToList()

                Dim i As Integer = 0
                Dim fieldname As String = "Column" & i
                Do
                    Dim chk = m_lstColumn.Where(Function(t) t.FIELD_NAME.ToUpper() = fieldname.ToUpper()).ToList()
                    If chk.Count > 0 Then
                        i += 1
                        fieldname = "Column" & i
                    Else
                        Exit Do
                    End If
                Loop

                rObj.MENUID = band.MENUID
                rObj.MA_MAU = band.MA_MAU
                rObj.BAND_NAME = band.BAND_NAME
                rObj.FIELD_NAME = fieldname
                rObj.CAPTION = fieldname
                rObj.VISIBLE_INDEX = lstfilter.Count
                rObj.VISIBLE = True
                rObj.WIDTH = 75
                m_lstColumn.Add(rObj)
                m_lstColumnFilter.Add(rObj)
                lsbColumn.Refresh()
                LoadPreview()
                lsbColumn.SelectedIndex = lsbColumn.ItemCount - 1
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnColumnDel_Click(sender As Object, e As EventArgs) Handles btnColumnDel.Click
        Try
            Dim rObj As ReportBandGridColumnResx = lsbColumn.SelectedItem
            Dim index As Integer = lsbColumn.SelectedIndex
            m_lstColumn.Remove(rObj)
            m_lstColumnFilter.Remove(rObj)
            lsbColumn.Refresh()
            LoadPreview()
            If m_lstColumn.Count > 0 Then
                If index - 1 >= 0 Then
                    lsbColumn.SelectedIndex = index - 1
                Else
                    lsbColumn.SelectedIndex = index
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnColumnUp_Click(sender As Object, e As EventArgs) Handles btnColumnUp.Click
        Try
            If lsbColumn.SelectedIndex > 0 Then
                Dim rObj As ReportBandGridColumnResx = m_lstColumnFilter(lsbColumn.SelectedIndex)
                Dim rObj_up As ReportBandGridColumnResx = m_lstColumnFilter(lsbColumn.SelectedIndex - 1)
                Dim index = rObj.VISIBLE_INDEX
                rObj.VISIBLE_INDEX = rObj_up.VISIBLE_INDEX
                rObj_up.VISIBLE_INDEX = index
                m_lstColumnFilter(lsbColumn.SelectedIndex) = rObj_up
                m_lstColumnFilter(lsbColumn.SelectedIndex - 1) = rObj

                Dim idx1 As Integer = m_lstColumn.IndexOf(rObj)
                Dim idx2 As Integer = m_lstColumn.IndexOf(rObj_up)

                m_lstColumn(idx1) = rObj_up
                m_lstColumn(idx2) = rObj

                lsbColumn.SelectedIndex = lsbColumn.SelectedIndex - 1
                lsbColumn.Refresh()
                LoadPreview()

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnColumnDown_Click(sender As Object, e As EventArgs) Handles btnColumnDown.Click
        Try
            If lsbColumn.SelectedIndex < lsbColumn.ItemCount Then
                Dim rObj As ReportBandGridColumnResx = m_lstColumnFilter(lsbColumn.SelectedIndex)
                Dim rObj_down As ReportBandGridColumnResx = m_lstColumnFilter(lsbColumn.SelectedIndex + 1)
                Dim index = rObj.VISIBLE_INDEX
                rObj.VISIBLE_INDEX = rObj_down.VISIBLE_INDEX
                rObj_down.VISIBLE_INDEX = index
                m_lstColumnFilter(lsbColumn.SelectedIndex) = rObj_down
                m_lstColumnFilter(lsbColumn.SelectedIndex + 1) = rObj

                Dim idx1 As Integer = m_lstColumn.IndexOf(rObj)
                Dim idx2 As Integer = m_lstColumn.IndexOf(rObj_down)

                m_lstColumn(idx1) = rObj_down
                m_lstColumn(idx2) = rObj

                lsbColumn.SelectedIndex = lsbColumn.SelectedIndex + 1
                lsbColumn.Refresh()
                LoadPreview()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lsbExxcelObject_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lsbExcelObject.SelectedIndexChanged
        PropertyExcelObject.SelectedObject = lsbExcelObject.SelectedItem
    End Sub

    Private Sub btnAddExxcel_Click(sender As Object, e As EventArgs) Handles btnAddExxcel.Click
        Try
            Dim robj As ReportBandGridExportExcelResx = New ReportBandGridExportExcelResx()
            robj.MENUID = txtmenuid.Text
            robj.MA_MAU = txtmamau.Text
            m_lstExcelObject.Add(robj)
            lsbExcelObject.Refresh()
            lsbExcelObject.SelectedIndex = m_lstExcelObject.Count - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDelExxcel_Click(sender As Object, e As EventArgs) Handles btnDelExxcel.Click
        Try
            Dim robj As ReportBandGridExportExcelResx = lsbExcelObject.SelectedItem
            Dim index = lsbExcelObject.SelectedIndex
            m_lstExcelObject.Remove(robj)
            lsbExcelObject.Refresh()
            If m_lstExcelObject.Count > 0 Then
                If index - 1 >= 0 Then
                    lsbExcelObject.SelectedIndex = index - 1
                Else
                    lsbExcelObject.SelectedIndex = index
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCopyBand_Click(sender As Object, e As EventArgs) Handles btnCopyBand.Click
        Try
            Dim rObj As ReportBandedGridViewResx = lsbBand.SelectedItem
            If rObj Is Nothing Then
                Exit Sub
            End If
            Dim nObj As ReportBandedGridViewResx = rObj.ShallowCopy()
            Dim i As Integer = 0
            Dim bandname As String = "GridBand" & i
            Do
                Dim chk = m_lstBand.Where(Function(t) t.BAND_NAME.ToUpper() = bandname.ToUpper()).ToList()
                If chk.Count > 0 Then
                    i += 1
                    bandname = "GridBand" & i
                Else
                    Exit Do
                End If
            Loop
            nObj.BAND_NAME = bandname
            nObj.CAPTION = bandname
            nObj.VISIBLE = True
            nObj.VISIBLE_INDEX = m_lstBand.Count
            m_lstBand.Add(nObj)
            lsbBand.Refresh()
            LoadPreview()
            lsbBand.SelectedIndex = lsbBand.ItemCount - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCopyColumn_Click(sender As Object, e As EventArgs) Handles btnCopyColumn.Click
        Try
            Dim rObj As ReportBandGridColumnResx = lsbColumn.SelectedItem
            If rObj Is Nothing Then
                Exit Sub
            End If
            Dim nObj As ReportBandGridColumnResx = rObj.ShallowCopy()
            Dim i As Integer = 0
            Dim column As String = "Column" & i
            Do
                Dim chk = m_lstColumn.Where(Function(t) t.FIELD_NAME.ToUpper() = column.ToUpper()).ToList()
                If chk.Count > 0 Then
                    i += 1
                    column = "Column" & i
                Else
                    Exit Do
                End If
            Loop
            nObj.FIELD_NAME = column.ToUpper()
            nObj.VISIBLE = True
            nObj.VISIBLE_INDEX = m_lstColumnFilter.Count
            m_lstColumn.Add(nObj)
            m_lstColumnFilter.Add(nObj)
            lsbColumn.Refresh()
            LoadPreview()
            lsbColumn.SelectedIndex = lsbColumn.ItemCount - 1
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnTestExportExcel_Click(sender As Object, e As EventArgs) Handles btnTestExportExcel.Click
        Cursor.Current = Cursors.WaitCursor
        Dim dtParam As DataTable = New DataTable()
        dtParam.Columns.AddRange(New DataColumn() {New DataColumn("NAME"), New DataColumn("VALUE")})
        dtParam.Rows.Add(New Object() {"MA_CTY", "Công ty TNHH DSHOFT"})
        dtParam.Rows.Add(New Object() {"DATE", "Công ty TNHH DSHOFT"})

        Common.BandedToExcel(bgvPreview, DHSErp.Util.ConvertHelper.ListToDataTable(Of ReportBandGridExportExcelResx)(m_lstExcelObject), dtParam)
        Cursor.Current = Cursors.Default
    End Sub

    Private Sub gridPreview_MouseClick(sender As Object, e As MouseEventArgs) Handles gridPreview.MouseClick
        Try
            Dim fieldname As String = bgvPreview.FocusedColumn.FieldName
            Dim selected = m_lstColumn.Where(Function(t) t.FIELD_NAME.ToUpper() = fieldname.ToUpper()).FirstOrDefault()
            Dim itband = m_lstBand.Where(Function(t) t.BAND_NAME = selected.BAND_NAME).FirstOrDefault()
            lsbBand.SelectedItem = itband
            Dim itcolum = m_lstColumnFilter.Where(Function(t) t.FIELD_NAME.ToUpper() = fieldname.ToUpper()).FirstOrDefault()
            lsbColumn.SelectedItem = itcolum
        Catch ex As Exception
        End Try
    End Sub
End Class