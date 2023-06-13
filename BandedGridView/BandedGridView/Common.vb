Imports DevExpress.XtraGrid.Views.BandedGrid
Imports DocumentFormat.OpenXml.Spreadsheet
Imports SpreadsheetLight
Imports SpreadsheetLight.Drawing

Public Class Common

    Public Shared Sub FormartBandedGridView(BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, dtBandGrid As DataTable, dtBandedGridColumn As DataTable)
        BandedGridView1.Bands.Clear()
        BandedGridView1.Columns.Clear()
        BandedGridView1.GridControl.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat
        BandedGridView1.GridControl.LookAndFeel.UseDefaultLookAndFeel = False

        Dim chkFooter = dtBandedGridColumn.AsEnumerable().Where(Function(t) t("SUMMARY_TYPE").ToString.ToUpper <> "NONE").ToList()
        If chkFooter.Count > 0 Then
            BandedGridView1.OptionsView.ShowFooter = True
        Else
            BandedGridView1.OptionsView.ShowFooter = False
        End If
        Dim bandIdx As Integer = 0
        Dim ColIdx As Integer = 0
        For Each rBandGrid In dtBandGrid.Rows
            Dim gb As DevExpress.XtraGrid.Views.BandedGrid.GridBand = New DevExpress.XtraGrid.Views.BandedGrid.GridBand()
            If DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("CAPTION")) <> "" Then
                gb.Caption = DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("CAPTION"))
            Else
                gb.Caption = " "
            End If
            gb.Name = rBandGrid("BAND_NAME").ToString()
            gb.VisibleIndex = DHSErp.Util.ConvertHelper.ToInt(rBandGrid("VISIBLE_INDEX"))
            gb.Visible = DHSErp.Util.ConvertHelper.ToBoolean(rBandGrid("VISIBLE"))

            gb.AppearanceHeader.Options.UseBackColor = True
            gb.AppearanceHeader.Options.UseFont = True
            gb.AppearanceHeader.Options.UseForeColor = True
            gb.AppearanceHeader.Options.UseTextOptions = True

            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("HALIGN")).ToUpper()
                Case "RIGHT"
                    gb.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                Case "CENTER"
                    gb.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                Case "LEFT"
                    gb.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                Case Else
                    gb.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
            End Select

            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("VALIGN")).ToUpper()
                Case "BOTTOM"
                    gb.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
                Case "CENTER"
                    gb.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                Case "TOP"
                    gb.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
                Case Else
                    gb.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default
            End Select
            Dim bg As String = DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("BACK_COLOR"))
            If bg <> "" Then
                Try
                    gb.AppearanceHeader.BackColor = System.Drawing.ColorTranslator.FromHtml(bg)
                Catch ex As Exception
                    gb.AppearanceHeader.BackColor = System.Drawing.Color.White
                End Try
            End If
            Dim fc As String = DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("FORE_COLOR"))
            If fc <> "" Then
                Try
                    gb.AppearanceHeader.ForeColor = System.Drawing.ColorTranslator.FromHtml(fc)
                Catch ex As Exception
                    gb.AppearanceHeader.ForeColor = System.Drawing.Color.Black
                End Try
            End If
            Dim fs As Decimal = DHSErp.Util.ConvertHelper.ToDecimal(rBandGrid("FONT_SIZE"))
            Dim fn As String = DHSErp.Util.ConvertHelper.ToEmptyString(rBandGrid("FONT_NAME"))
            Dim bold As Boolean = DHSErp.Util.ConvertHelper.ToBoolean(rBandGrid("FONT_BOLD"))
            Dim italic As Boolean = DHSErp.Util.ConvertHelper.ToBoolean(rBandGrid("FONT_ITALIC"))
            If fs <= 0 Then
                fs = 10
            End If
            If fn = "" Then
                fn = "Arial"
            End If

            Dim fst As System.Drawing.FontStyle = System.Drawing.FontStyle.Regular
            If bold Then
                fst = fst Or System.Drawing.FontStyle.Bold
            End If
            If italic Then
                fst = fst Or System.Drawing.FontStyle.Italic
            End If
            gb.AppearanceHeader.Font = New System.Drawing.Font(fn, fs, fst)


            Dim drColumns = dtBandedGridColumn.AsEnumerable().Where(Function(r) r("BAND_NAME") = rBandGrid("BAND_NAME")).ToArray()
            Dim bandWidth As Integer = 0

            If drColumns IsNot Nothing AndAlso drColumns.Length > 0 Then
                For Each rcol In drColumns
                    Dim bandCol As DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn = New DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn()
                    bandCol.Caption = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("CAPTION"))
                    bandCol.FieldName = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FIELD_NAME").ToString().ToUpper())
                    bandCol.Name = bandCol.FieldName

                    'Format column header
                    If DHSErp.Util.ConvertHelper.ToInt(rcol("WIDTH")) <= 0 Then
                        bandCol.Width = 75
                    Else
                        bandCol.Width = DHSErp.Util.ConvertHelper.ToInt(rcol("WIDTH"))
                    End If
                    bandCol.Visible = DHSErp.Util.ConvertHelper.ToBoolean(rcol("VISIBLE"))
                    If bandCol.Visible = False Then
                        bandCol.VisibleIndex = -1
                    Else
                        bandCol.VisibleIndex = DHSErp.Util.ConvertHelper.ToInt(rcol("VISIBLE_INDEX"))
                        bandWidth += bandCol.Width
                    End If

                    bandCol.AppearanceHeader.Options.UseBackColor = True
                    bandCol.AppearanceHeader.Options.UseFont = True
                    bandCol.AppearanceHeader.Options.UseForeColor = True
                    bandCol.AppearanceHeader.Options.UseTextOptions = True

                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rcol("HALIGN")).ToUpper()
                        Case "RIGHT"
                            bandCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        Case "CENTER"
                            bandCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        Case "LEFT"
                            bandCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        Case Else
                            bandCol.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
                    End Select

                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rcol("VALIGN")).ToUpper()
                        Case "BOTTOM"
                            bandCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
                        Case "CENTER"
                            bandCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                        Case "TOP"
                            bandCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
                        Case Else
                            bandCol.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default
                    End Select
                    bg = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("BACK_COLOR"))
                    If bg <> "" Then
                        Try
                            bandCol.AppearanceHeader.BackColor = System.Drawing.ColorTranslator.FromHtml(bg)
                        Catch ex As Exception
                            bandCol.AppearanceHeader.BackColor = System.Drawing.Color.White
                        End Try
                    End If
                    fc = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FORE_COLOR"))
                    If fc <> "" Then
                        Try
                            bandCol.AppearanceHeader.ForeColor = System.Drawing.ColorTranslator.FromHtml(fc)
                        Catch ex As Exception
                            bandCol.AppearanceHeader.ForeColor = System.Drawing.Color.Black
                        End Try
                    End If
                    fs = DHSErp.Util.ConvertHelper.ToDecimal(rcol("FONT_SIZE"))
                    fn = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FONT_NAME"))
                    bold = DHSErp.Util.ConvertHelper.ToBoolean(rcol("FONT_BOLD"))
                    italic = DHSErp.Util.ConvertHelper.ToBoolean(rcol("FONT_ITALIC"))
                    If fs <= 0 Then
                        fs = 10
                    End If
                    If fn = "" Then
                        fn = "Arial"
                    End If

                    fst = System.Drawing.FontStyle.Regular
                    If bold Then
                        fst = fst Or System.Drawing.FontStyle.Bold
                    End If
                    If italic Then
                        fst = fst Or System.Drawing.FontStyle.Italic
                    End If
                    bandCol.AppearanceHeader.Font = New System.Drawing.Font(fn, fs, fst)

                    'Format cell
                    bandCol.OptionsColumn.AllowEdit = False
                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FORMAT_TYPE")).ToUpper()
                        Case "NUMERIC"
                            bandCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                        Case "DATETIME", "DATE"
                            bandCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                        Case "CUSTOM"
                            bandCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
                        Case Else
                            bandCol.DisplayFormat.FormatType = DevExpress.Utils.FormatType.None

                    End Select
                    bandCol.DisplayFormat.FormatString = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FORMAT_STRING"))

                    bandCol.AppearanceCell.Options.UseBackColor = True
                    bandCol.AppearanceCell.Options.UseFont = True
                    bandCol.AppearanceCell.Options.UseForeColor = True
                    bandCol.AppearanceCell.Options.UseTextOptions = True

                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rcol("HALIGN_CELL")).ToUpper()
                        Case "RIGHT"
                            bandCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far
                        Case "CENTER"
                            bandCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                        Case "LEFT"
                            bandCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near
                        Case Else
                            bandCol.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
                    End Select

                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(rcol("VALIGN_CELL")).ToUpper()
                        Case "BOTTOM"
                            bandCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Bottom
                        Case "CENTER"
                            bandCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
                        Case "TOP"
                            bandCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top
                        Case Else
                            bandCol.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Default
                    End Select
                    bg = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("BACK_COLOR_CELL"))
                    If bg <> "" Then
                        Try
                            bandCol.AppearanceCell.BackColor = System.Drawing.ColorTranslator.FromHtml(bg)
                        Catch ex As Exception
                            bandCol.AppearanceCell.BackColor = System.Drawing.Color.White
                        End Try
                    End If
                    fc = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FORE_COLOR_CELL"))
                    If fc <> "" Then
                        Try
                            bandCol.AppearanceCell.ForeColor = System.Drawing.ColorTranslator.FromHtml(fc)
                        Catch ex As Exception
                            bandCol.AppearanceCell.ForeColor = System.Drawing.Color.Black
                        End Try
                    End If
                    fs = DHSErp.Util.ConvertHelper.ToDecimal(rcol("FONT_SIZE_CELL"))
                    fn = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("FONT_NAME_CELL"))
                    bold = DHSErp.Util.ConvertHelper.ToBoolean(rcol("FONT_BOLD_CELL"))
                    italic = DHSErp.Util.ConvertHelper.ToBoolean(rcol("FONT_ITALIC_CELL"))
                    Dim under As Boolean = DHSErp.Util.ConvertHelper.ToBoolean(rcol("FONT_UNDERLINE_CELL"))
                    If fs <= 0 Then
                        fs = 10
                    End If
                    If fn = "" Then
                        fn = "Arial"
                    End If

                    fst = System.Drawing.FontStyle.Regular
                    If bold Then
                        fst = fst Or System.Drawing.FontStyle.Bold
                    End If
                    If italic Then
                        fst = fst Or System.Drawing.FontStyle.Italic
                    End If
                    If under Then
                        fst = fst Or System.Drawing.FontStyle.Underline
                    End If
                    bandCol.AppearanceCell.Font = New System.Drawing.Font(fn, fs, fst)

                    Dim smt As String = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("SUMMARY_TYPE")).ToUpper
                    Dim smf As String = DHSErp.Util.ConvertHelper.ToEmptyString(rcol("SUMMARY_FORMAT")).Trim
                    If smf <> "" Then
                        If smf.StartsWith("{") AndAlso smf.EndsWith("}") Then
                        Else
                            smf = smf.Replace("{", "")
                            smf = smf.Replace("}", "")
                            smf = "{0:" & smf & "}"
                        End If
                    End If
                    If smt <> "NONE" Then
                        Select Case smt.ToUpper()
                            Case "SUM"
                                bandCol.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, bandCol.FieldName.ToUpper(), smf)})
                            Case "AVERAGE"
                                bandCol.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Average, bandCol.FieldName.ToUpper(), smf)})
                            Case "COUNT"
                                bandCol.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, bandCol.FieldName.ToUpper(), smf)})
                            Case "MIN"
                                bandCol.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Min, bandCol.FieldName.ToUpper(), smf)})
                            Case "MAX"
                                bandCol.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, bandCol.FieldName.ToUpper(), smf)})

                        End Select
                    End If

                    BandedGridView1.Columns.Add(bandCol)
                    gb.Columns.Add(bandCol)

                    ColIdx += 1
                Next
            End If

            If bandWidth <= 0 Then
                bandWidth = 75
            End If

            gb.Width = bandWidth
            BandedGridView1.Bands.Add(gb)

            bandIdx += 1
        Next


    End Sub
    ''' <summary>
    ''' Xuất BandedGridView ra file excel
    ''' </summary>
    ''' <param name="BandedGridView1">BandedGridView</param>
    ''' <param name="dtExcelObject">Các đối tượng khai báo thêm bên ngoài</param>
    ''' <param name="dtParam">Đối tượng chứa tham số động. chứa 2 cột: NAME, VALUE</param>
    Public Shared Sub BandedToExcel(BandedGridView1 As DevExpress.XtraGrid.Views.BandedGrid.BandedGridView, dtExcelObject As DataTable, dtParam As DataTable)
        Dim dt As DataTable = Nothing
        Try
            dt = CType(BandedGridView1.DataSource, DataView).Table
        Catch ex As Exception
            dt = Nothing
        End Try
        If dt Is Nothing OrElse dt.Rows.Count = 0 Then
            Return
        End If
        Dim filePath As String = ""
        Dim filecontrl As FileControllers = New FileControllers()
        If Not filecontrl.CreateTmpFile(filePath) Then
            System.Windows.Forms.MessageBox.Show(filePath, "Error create file", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Exclamation)
            Return
        End If
        Dim sl As SLDocument = New SLDocument()
        'Add header object 
        Dim header As List(Of DataRow) = dtExcelObject.AsEnumerable().Where(Function(r) r("HEADER") = True AndAlso r("VALUE").ToString().ToUpper <> "START_FILL_DATA").ToList()
        For Each obj In header
            Dim Border = sl.CreateBorder()
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_LEFT")) Then
                Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_RIGHT")) Then
                Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_TOP")) Then
                Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_BOTTOM")) Then
                Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If

            Dim fs = DHSErp.Util.ConvertHelper.ToDecimal(obj("FONT_SIZE"))
            Dim fn = DHSErp.Util.ConvertHelper.ToEmptyString(obj("FONT_NAME"))
            Dim bold = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_BOLD"))
            Dim italic = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_ITALIC"))
            Dim under As Boolean = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_UNDERLINE"))
            If fs <= 0 Then
                fs = 10
            End If
            If fn = "" Then
                fn = "Arial"
            End If

            Dim style As SLStyle = sl.CreateStyle()
            style.Font.FontName = fn
            style.Font.FontSize = fs
            style.Font.Bold = bold
            style.Font.Italic = italic
            style.Font.Underline = IIf(under, UnderlineValues.Single, UnderlineValues.None)
            style.Font.FontColor = System.Drawing.ColorTranslator.FromHtml(obj("FORE_COLOR"))

            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("HALIGN")).ToUpper()
                Case "RIGHT"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Right
                Case "CENTER"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Center
                Case "LEFT"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Left
                Case Else
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Justify
            End Select

            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("VALIGN")).ToUpper()
                Case "BOTTOM"
                    style.Alignment.Vertical = VerticalAlignmentValues.Bottom
                Case "CENTER"
                    style.Alignment.Vertical = VerticalAlignmentValues.Center
                Case "TOP"
                    style.Alignment.Vertical = VerticalAlignmentValues.Top
                Case Else
                    style.Alignment.Vertical = VerticalAlignmentValues.Justify
            End Select

            style.SetWrapText(DHSErp.Util.ConvertHelper.ToBoolean(obj("WRAP_TEXT")))
            style.FormatCode = DHSErp.Util.ConvertHelper.ToEmptyString(obj("FORMAT_STRING"))
            style.Border = Border
            If DHSErp.Util.ConvertHelper.ToEmptyString(obj("BACK_COLOR")) = "Transparent" Then
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent)
            Else
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml(obj("BACK_COLOR")), System.Drawing.ColorTranslator.FromHtml(obj("BACK_COLOR")))
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("MERGE_CELL")) Then
                sl.SetCellStyle(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("MERGE_ROW_TO"), obj("MERGE_COLUMN_TO"), style)
                sl.MergeWorksheetCells(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("MERGE_ROW_TO"), obj("MERGE_COLUMN_TO"))
            Else
                sl.SetCellStyle(obj("ROW_INDEX"), obj("COLUMN_INDEX"), style)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("PARAMETER")) Then
                Dim param As DataRow = dtParam.AsEnumerable().Where(Function(t) t("NAME").ToString.ToUpper = obj("VALUE").ToString.ToUpper).FirstOrDefault()
                If param IsNot Nothing Then
                    If DHSErp.Util.ConvertHelper.ToBoolean(obj("IS_PICTURE")) Then
                        Dim pic As SLPicture = New SLPicture(param("VALUE"))
                        pic.SetRelativePositionInPixels(obj("ROW_INDEX"), obj("COLUMN_INDEX"), 1, 1)
                        pic.ResizeInPercentage(obj("SCALE_WIDTH"), obj("SCALE_HEIGHT"))
                        sl.InsertPicture(pic)
                    Else

                        Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("TYPE")).ToUpper()
                            Case "Text".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE").ToString())
                            Case "Number".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Currency".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Accounting".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Date".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Time".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Percent".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Fraction".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Scientific".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE"))
                            Case Else
                                sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), param("VALUE").ToString())
                        End Select
                    End If
                End If
            Else
                If DHSErp.Util.ConvertHelper.ToBoolean(obj("IS_PICTURE")) Then
                    Dim pic As SLPicture = New SLPicture(obj("VALUE"))
                    pic.SetRelativePositionInPixels(obj("ROW_INDEX"), obj("COLUMN_INDEX"), 1, 1)
                    pic.ResizeInPercentage(obj("SCALE_WIDTH"), obj("SCALE_HEIGHT"))
                    sl.InsertPicture(pic)
                Else
                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("TYPE")).ToUpper()
                        Case "Text".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE").ToString())
                        Case "Number".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Currency".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Accounting".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Date".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Time".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Percent".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Fraction".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Scientific".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE"))
                        Case Else
                            sl.SetCellValue(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("VALUE").ToString())
                    End Select
                End If
            End If
        Next

        'Add body
        Dim start_fill_data_row As Integer = 1
        Dim start_fill_data_column As Integer = 1
        Dim row As DataRow = dtExcelObject.AsEnumerable().Where(Function(r) r("VALUE").ToString.ToUpper = "START_FILL_DATA").FirstOrDefault()
        If row IsNot Nothing Then
            Dim tmp As Integer = 0
            If Integer.TryParse(row("ROW_INDEX").ToString, tmp) Then
                start_fill_data_row = tmp
            End If
            If Integer.TryParse(row("COLUMN_INDEX").ToString, tmp) Then
                start_fill_data_column = tmp
            End If
        End If
        Dim start_col As Integer = start_fill_data_column
        For Each band As GridBand In BandedGridView1.Bands
            If band.Visible = False OrElse band.Columns.Count = 0 Then
                Continue For
            End If
            Dim style1 = sl.CreateStyle()
            If band.Caption.Trim() <> "" Then
                sl.MergeWorksheetCells(start_fill_data_row, start_col, start_fill_data_row, start_col + band.Columns.Count - 1)
            End If
            style1.Font.Bold = band.AppearanceHeader.Font.Bold
            style1.Font.Italic = band.AppearanceHeader.Font.Italic
            style1.Font.Underline = IIf(band.AppearanceHeader.Font.Underline, UnderlineValues.Single, UnderlineValues.None)
            style1.Font.FontName = band.AppearanceHeader.Font.Name
            style1.Font.FontSize = band.AppearanceHeader.Font.Size
            style1.Font.FontColor = band.AppearanceHeader.ForeColor

            Dim Border1 = sl.CreateBorder()
            Border1.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            Border1.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            Border1.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            Border1.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)

            style1.Border = Border1

            style1.Fill.SetPattern(PatternValues.Solid, band.AppearanceHeader.BackColor, band.AppearanceHeader.BackColor)

            Select Case band.AppearanceHeader.TextOptions.HAlignment
                Case DevExpress.Utils.HorzAlignment.Center
                    style1.Alignment.Horizontal = HorizontalAlignmentValues.Center
                Case DevExpress.Utils.HorzAlignment.Far
                    style1.Alignment.Horizontal = HorizontalAlignmentValues.Right
                Case DevExpress.Utils.HorzAlignment.Near
                    style1.Alignment.Horizontal = HorizontalAlignmentValues.Left
                Case Else
                    style1.Alignment.Horizontal = HorizontalAlignmentValues.Justify
            End Select

            Select Case band.AppearanceHeader.TextOptions.VAlignment
                Case DevExpress.Utils.VertAlignment.Bottom
                    style1.Alignment.Vertical = VerticalAlignmentValues.Bottom
                Case DevExpress.Utils.VertAlignment.Center
                    style1.Alignment.Vertical = VerticalAlignmentValues.Center
                Case DevExpress.Utils.VertAlignment.Top
                    style1.Alignment.Vertical = VerticalAlignmentValues.Top
                Case Else
                    style1.Alignment.Vertical = VerticalAlignmentValues.Justify
            End Select

            If band.Caption.Trim() <> "" Then
                sl.SetCellStyle(start_fill_data_row, start_col, start_fill_data_row, start_col + band.Columns.Count - 1, style1)
                sl.SetCellValue(start_fill_data_row, start_col, band.Caption)
            Else
                sl.SetCellStyle(start_fill_data_row, start_col, style1)
            End If

            For Each col As BandedGridColumn In band.Columns
                If col.Visible = False Then
                    Continue For
                End If

                Dim style2 = sl.CreateStyle()
                If col.Caption.Trim() = "" Then
                    sl.MergeWorksheetCells(start_fill_data_row, start_col, start_fill_data_row + 1, start_col)
                End If
                style2.Font.Bold = col.AppearanceHeader.Font.Bold
                style2.Font.Italic = col.AppearanceHeader.Font.Italic
                style2.Font.Underline = IIf(col.AppearanceHeader.Font.Underline, UnderlineValues.Single, UnderlineValues.None)
                style2.Font.FontName = col.AppearanceHeader.Font.Name
                style2.Font.FontSize = col.AppearanceHeader.Font.Size
                style2.Font.FontColor = col.AppearanceHeader.ForeColor
                Dim Border2 = sl.CreateBorder()
                Border2.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border2.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border2.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border2.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)

                style2.Border = Border2

                style2.Fill.SetPattern(PatternValues.Solid, col.AppearanceHeader.BackColor, col.AppearanceHeader.BackColor)

                Select Case col.AppearanceHeader.TextOptions.HAlignment
                    Case DevExpress.Utils.HorzAlignment.Center
                        style2.Alignment.Horizontal = HorizontalAlignmentValues.Center
                    Case DevExpress.Utils.HorzAlignment.Far
                        style2.Alignment.Horizontal = HorizontalAlignmentValues.Right
                    Case DevExpress.Utils.HorzAlignment.Near
                        style2.Alignment.Horizontal = HorizontalAlignmentValues.Left
                    Case Else
                        style2.Alignment.Horizontal = HorizontalAlignmentValues.Justify
                End Select

                Select Case col.AppearanceHeader.TextOptions.VAlignment
                    Case DevExpress.Utils.VertAlignment.Bottom
                        style2.Alignment.Vertical = VerticalAlignmentValues.Bottom
                    Case DevExpress.Utils.VertAlignment.Center
                        style2.Alignment.Vertical = VerticalAlignmentValues.Center
                    Case DevExpress.Utils.VertAlignment.Top
                        style2.Alignment.Vertical = VerticalAlignmentValues.Top
                    Case Else
                        style2.Alignment.Vertical = VerticalAlignmentValues.Justify
                End Select

                If band.Caption.Trim() = "" Then
                    sl.SetCellStyle(start_fill_data_row, start_col, start_fill_data_row + 1, start_col, style2)
                    sl.MergeWorksheetCells(start_fill_data_row, start_col, start_fill_data_row + 1, start_col)
                    sl.SetCellValue(start_fill_data_row, start_col, col.Caption)
                Else
                    sl.SetCellStyle(start_fill_data_row + 1, start_col, style2)
                    sl.SetCellValue(start_fill_data_row + 1, start_col, col.Caption)
                End If
                sl.SetColumnWidth(start_col, col.Width / 5)

                'RowData
                Dim style3 = sl.CreateStyle()
                style3.Font.Bold = col.AppearanceCell.Font.Bold
                style3.Font.Italic = col.AppearanceCell.Font.Italic
                style3.Font.Underline = IIf(col.AppearanceCell.Font.Underline, UnderlineValues.Single, UnderlineValues.None)
                style3.Font.FontName = col.AppearanceCell.Font.Name
                style3.Font.FontSize = col.AppearanceCell.Font.Size
                style3.Font.FontColor = col.AppearanceCell.ForeColor

                Dim Border3 = sl.CreateBorder()
                Border3.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border3.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border3.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
                Border3.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)

                style3.Border = Border3

                style3.Fill.SetPattern(PatternValues.Solid, col.AppearanceCell.BackColor, col.AppearanceCell.BackColor)

                Select Case col.AppearanceCell.TextOptions.HAlignment
                    Case DevExpress.Utils.HorzAlignment.Center
                        style3.Alignment.Horizontal = HorizontalAlignmentValues.Center
                    Case DevExpress.Utils.HorzAlignment.Far
                        style3.Alignment.Horizontal = HorizontalAlignmentValues.Right
                    Case DevExpress.Utils.HorzAlignment.Near
                        style3.Alignment.Horizontal = HorizontalAlignmentValues.Left
                    Case Else
                        style3.Alignment.Horizontal = HorizontalAlignmentValues.Justify
                End Select

                Select Case col.AppearanceCell.TextOptions.VAlignment
                    Case DevExpress.Utils.VertAlignment.Bottom
                        style3.Alignment.Vertical = VerticalAlignmentValues.Bottom
                    Case DevExpress.Utils.VertAlignment.Center
                        style3.Alignment.Vertical = VerticalAlignmentValues.Center
                    Case DevExpress.Utils.VertAlignment.Top
                        style3.Alignment.Vertical = VerticalAlignmentValues.Top
                    Case Else
                        style3.Alignment.Vertical = VerticalAlignmentValues.Justify
                End Select
                style3.FormatCode = col.DisplayFormat.FormatString

                sl.SetCellStyle(start_fill_data_row + 2, start_col, start_fill_data_row + 2 + dt.Rows.Count - 1, start_col, style3)

                start_col += 1
            Next
        Next

        start_fill_data_row = start_fill_data_row + 2

        sl.CreateBorder()
        sl.ImportDataTable(start_fill_data_row, start_fill_data_column, dt, False)
        sl.AutoFitRow(1, dt.Rows.Count, 20)

        'Add footer
        start_fill_data_row = start_fill_data_row + dt.Rows.Count
        Dim footer As List(Of DataRow) = dtExcelObject.AsEnumerable().Where(Function(r) r("HEADER") = False  AndAlso r("VALUE").ToString().ToUpper <> "START_FILL_DATA").ToList()
        For Each obj In footer
            Dim Border = sl.CreateBorder()
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_LEFT")) Then
                Border.SetLeftBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_RIGHT")) Then
                Border.SetRightBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_TOP")) Then
                Border.SetTopBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("BORDER_BOTTOM")) Then
                Border.SetBottomBorder(BorderStyleValues.Thin, System.Drawing.Color.Black)
            End If

            Dim fs = DHSErp.Util.ConvertHelper.ToDecimal(obj("FONT_SIZE"))
            Dim fn = DHSErp.Util.ConvertHelper.ToEmptyString(obj("FONT_NAME"))
            Dim bold = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_BOLD"))
            Dim italic = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_ITALIC"))
            Dim under As Boolean = DHSErp.Util.ConvertHelper.ToBoolean(obj("FONT_UNDERLINE"))
            If fs <= 0 Then
                fs = 10
            End If
            If fn = "" Then
                fn = "Arial"
            End If

            Dim style As SLStyle = sl.CreateStyle()
            style.Font.FontName = fn
            style.Font.FontSize = fs
            style.Font.Bold = bold
            style.Font.Italic = italic
            style.Font.Underline = IIf(under, UnderlineValues.Single, UnderlineValues.None)
            style.Font.FontColor = System.Drawing.ColorTranslator.FromHtml(obj("FORE_COLOR"))
            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("HALIGN")).ToUpper()
                Case "RIGHT"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Right
                Case "CENTER"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Center
                Case "LEFT"
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Left
                Case Else
                    style.Alignment.Horizontal = HorizontalAlignmentValues.Justify
            End Select

            Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("VALIGN")).ToUpper()
                Case "BOTTOM"
                    style.Alignment.Vertical = VerticalAlignmentValues.Bottom
                Case "CENTER"
                    style.Alignment.Vertical = VerticalAlignmentValues.Center
                Case "TOP"
                    style.Alignment.Vertical = VerticalAlignmentValues.Top
                Case Else
                    style.Alignment.Vertical = VerticalAlignmentValues.Justify
            End Select

            style.SetWrapText(DHSErp.Util.ConvertHelper.ToBoolean(obj("WRAP_TEXT")))
            style.FormatCode = DHSErp.Util.ConvertHelper.ToEmptyString(obj("FORMAT_STRING"))
            style.Border = Border
            If DHSErp.Util.ConvertHelper.ToEmptyString(obj("BACK_COLOR")) = "Transparent" Then
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.Color.Transparent, System.Drawing.Color.Transparent)
            Else
                style.Fill.SetPattern(PatternValues.Solid, System.Drawing.ColorTranslator.FromHtml(obj("BACK_COLOR")), System.Drawing.ColorTranslator.FromHtml(obj("BACK_COLOR")))
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("MERGE_CELL")) Then
                sl.MergeWorksheetCells(obj("ROW_INDEX"), obj("COLUMN_INDEX"), obj("MERGE_ROW_TO"), obj("MERGE_COLUMN_TO"))
                sl.SetCellStyle(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("MERGE_ROW_TO") + start_fill_data_row, obj("MERGE_COLUMN_TO"), style)
            Else
                sl.SetCellStyle(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), style)
            End If
            If DHSErp.Util.ConvertHelper.ToBoolean(obj("PARAMETER")) Then
                Dim param As DataRow = dtParam.AsEnumerable().Where(Function(t) t("NAME").ToString.ToUpper = obj("VALUE").ToString.ToUpper).FirstOrDefault()
                If param IsNot Nothing Then
                    If DHSErp.Util.ConvertHelper.ToBoolean(obj("IS_PICTURE")) Then
                        Dim pic As SLPicture = New SLPicture(param("VALUE"))
                        pic.SetRelativePositionInPixels(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), 1, 1)
                        pic.ResizeInPercentage(obj("SCALE_WIDTH"), obj("SCALE_HEIGHT"))
                        sl.InsertPicture(pic)
                    Else
                        Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("TYPE")).ToUpper()
                            Case "Text".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE").ToString())
                            Case "Number".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Currency".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Accounting".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Date".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Time".ToUpper
                                sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Percent".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Fraction".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case "Scientific".ToUpper
                                sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE"))
                            Case Else
                                sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), param("VALUE").ToString())
                        End Select
                    End If
                End If
            Else
                If DHSErp.Util.ConvertHelper.ToBoolean(obj("IS_PICTURE")) Then
                    Dim pic As SLPicture = New SLPicture(obj("VALUE"))
                    pic.SetRelativePositionInPixels(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), 1, 1)
                    pic.ResizeInPercentage(obj("SCALE_WIDTH"), obj("SCALE_HEIGHT"))
                    sl.InsertPicture(pic)
                Else
                    Select Case DHSErp.Util.ConvertHelper.ToEmptyString(obj("TYPE")).ToUpper()
                        Case "Text".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE").ToString())
                        Case "Number".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Currency".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Accounting".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Date".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Time".ToUpper
                            sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Percent".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Fraction".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case "Scientific".ToUpper
                            sl.SetCellValueNumeric(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE"))
                        Case Else
                            sl.SetCellValue(obj("ROW_INDEX") + start_fill_data_row, obj("COLUMN_INDEX"), obj("VALUE").ToString())
                    End Select
                End If
            End If
        Next
        'Save to excel filel 
        sl.SaveAs(filePath)
        Process.Start(filePath)
    End Sub

End Class
