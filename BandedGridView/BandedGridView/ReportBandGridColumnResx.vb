Imports System.ComponentModel

Public Class ReportBandGridColumnResx
    <Category("01. Mẫu báo cáo")>
    <DisplayName("Menu id")>
    <Description("Menuid")>
    <[ReadOnly](True)>
    Public Property MENUID As String

    <Category("01. Mẫu báo cáo")>
    <DisplayName("Ma_Mau")>
    <Description("MA_MAU: Mã mẫu báo cáo")>
    <[ReadOnly](True)>
    Public Property MA_MAU As String

    <Category("01. Mẫu báo cáo")>
    <DisplayName("BandName")>
    <Description("BAND_NAME: Tên của nhóm.")>
    <[ReadOnly](True)>
    Public Property BAND_NAME As String

    <Category("02. Thiết lập cột")>
    <DisplayName("FieldName")>
    <Description("FIELD_NAME: Tiêu đề hiển thị của cột.")>
    Public Property FIELD_NAME As String

    <Category("02. Thiết lập cột")>
    <DisplayName("Caption")>
    <Description("CAPTION: Tiêu đề hiển thị của cột.")>
    Public Property CAPTION As String

    <Category("02. Thiết lập cột")>
    <DisplayName("English Caption")>
    <Description("CAPTION_EN: Tiêu đề hiển thị của cột theo tiếng Anh.")>
    Public Property CAPTION_EN As String

    <Category("02. Thiết lập cột")>
    <DisplayName("Visible")>
    <Description("VISIBLE: Hiển thị")>
    Public Property VISIBLE As Boolean

    <Category("02. Thiết lập cột")>
    <DisplayName("VisibleIndex")>
    <Description("VISIBLE_INDEX: Thứ tự hiển thị")>
    Public Property VISIBLE_INDEX As Integer
        Get
            Return m_VISIBLE_INDEX
        End Get
        Set(value As Integer)
            If value < 0 Then
                System.Windows.Forms.MessageBox.Show("Vui lòng nhập giá trị >= 0", "Cảnh báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            Else
                m_VISIBLE_INDEX = value
            End If
        End Set
    End Property

    <Category("02. Thiết lập cột")>
    <DisplayName("Width")>
    <Description("WIDTH: Độ rộng cột")>
    Public Property WIDTH As Integer
        Get
            Return m_WIDTH
        End Get
        Set(value As Integer)
            If value <= 0 Then
                System.Windows.Forms.MessageBox.Show("Vui lòng nhập giá trị > 0", "Cảnh báo", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Warning)
            Else
                m_WIDTH = value
            End If
        End Set
    End Property

    <Category("03. Định dạng hiển thị cột")>
    <DisplayName("BackColor")>
    <Description("BACK_COLOR: Cài đặt màu nền cho nhóm.")>
    Public Property BACKCOLOR As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_BACK_COLOR)
        End Get
        Set(value As System.Drawing.Color)
            m_BACK_COLOR = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")
        End Set
    End Property

    <Category("03. Định dạng hiển thị cột")>
    <DisplayName("ForeColor")>
    <Description("FORE_COLOR: Cài đặt màu chữ cho nhóm.")>
    Public Property FORECOLOR As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_FORE_COLOR)
        End Get
        Set(value As System.Drawing.Color)
            m_FORE_COLOR = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")
        End Set
    End Property

    <Category("03. Định dạng hiển thị cột")>
    <DisplayName("Font")>
    <Description("FONT: Cài đặt kiểu chữ cho cột. Chỉ dùng: Font name, Font size, Font style")>
    Public Property FONT As System.Drawing.Font
        Get
            Return m_FONT
        End Get
        Set(value As System.Drawing.Font)
            m_FONT = value
            FONT_BOLD = m_FONT.Bold
            FONT_ITALIC = m_FONT.Italic
            FONT_SIZE = m_FONT.Size
            FONT_NAME = m_FONT.Name
        End Set
    End Property

    <Category("04. Căn chữ cho cột")>
    <DisplayName("Vertical Align")>
    <Description("VALIGN: căn chữ chiều dọc.")>
    Public Property V_ALIGN As eVAlign
        Get
            Select Case m_VALIGN.ToUpper()
                Case "BOTTOM"
                    Return eVAlign.Bottom
                Case "CENTER"
                    Return eVAlign.Center
                Case Else
                    Return eVAlign.Top
            End Select

        End Get
        Set(value As eVAlign)
            Select Case value
                Case eVAlign.Bottom
                    m_VALIGN = "Bottom"
                Case eVAlign.Center
                    m_VALIGN = "Center"
                Case Else
                    m_VALIGN = "Top"
            End Select
        End Set
    End Property

    <Category("04. Căn chữ cho cột")>
    <DisplayName("Horizontal Align")>
    <Description("HALIGN: căn chữ chiều ngang.")>
    Public Property H_ALIGN As eHAlign
        Get
            Select Case m_HALIGN.ToUpper()
                Case "RIGHT"
                    Return eHAlign.Right
                Case "CENTER"
                    Return eHAlign.Center
                Case Else
                    Return eHAlign.Left
            End Select

        End Get
        Set(value As eHAlign)
            Select Case value
                Case eHAlign.Right
                    m_HALIGN = "Right"
                Case eHAlign.Center
                    m_HALIGN = "Center"
                Case Else
                    m_HALIGN = "Left"
            End Select
        End Set
    End Property


    '======================
    <Category("05. Định dạng hiển thị cho ô dữ liệu")>
    <DisplayName("BackColorCell")>
    <Description("BACK_COLOR_CELL: Cài đặt màu nền cho ô.")>
    Public Property BACKCOLOR_CELL As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_BACK_COLOR_CELL)
        End Get
        Set(value As System.Drawing.Color)
            m_BACK_COLOR_CELL = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")

        End Set
    End Property

    <Category("05. Định dạng hiển thị cho ô dữ liệu")>
    <DisplayName("ForeColorCell")>
    <Description("FORE_COLOR_CELL: Cài đặt màu chữ cho ô.")>
    Public Property FORECOLOR_CELL As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_FORE_COLOR_CELL)
        End Get
        Set(value As System.Drawing.Color)
            m_FORE_COLOR_CELL = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")
        End Set
    End Property

    <Category("05. Định dạng hiển thị cho ô dữ liệu")>
    <DisplayName("FontCell")>
    <Description("FONT_CELL: Cài đặt kiểu chữ cho ô. Chỉ dùng: Font name, Font size, Font style")>
    Public Property FONT_CELL As System.Drawing.Font
        Get
            Return m_FONT_CELL
        End Get
        Set(value As System.Drawing.Font)
            m_FONT_CELL = value
            FONT_BOLD_CELL = m_FONT_CELL.Bold
            FONT_ITALIC_CELL = m_FONT_CELL.Italic
            FONT_UNDERLINE_CELL = m_FONT_CELL.Underline
            FONT_SIZE_CELL = m_FONT_CELL.Size
            FONT_NAME_CELL = m_FONT_CELL.Name

        End Set
    End Property

    <Category("05. Định dạng hiển thị cho ô dữ liệu")>
    <DisplayName("FormatType")>
    <Description("FORMAT_TYPE: Kiểu dữ liệu.")>
    Public Property TYPE As eFormatType
        Get
            Return m_TYPE
        End Get
        Set(value As eFormatType)
            m_TYPE = value
            Select Case value
                Case eFormatType.Numeric
                    m_FORMAT_TYPE = "Numeric"
                Case eFormatType.Datetime
                    m_FORMAT_TYPE = "Datetime"
                Case eFormatType.Custom
                    m_FORMAT_TYPE = "Custom"
                Case Else
                    m_FORMAT_TYPE = "None"
            End Select
        End Set
    End Property

    <Category("05. Định dạng hiển thị cho ô dữ liệu")>
    <DisplayName("FormatString")>
    <Description("FORMAT_STRING: Kiểu dữ liệu.")>
    Public Property FORMAT_STRING As String


    <Category("06. Căn chữ cho ô dữ liệu")>
    <DisplayName("Vertical Align Cell")>
    <Description("VALIGN_CELL: căn chữ chiều dọc.")>
    Public Property V_ALIGN_CELL As eVAlign
        Get
            Select Case m_VALIGN_CELL.ToUpper()
                Case "BOTTOM"
                    Return eVAlign.Bottom
                Case "CENTER"
                    Return eVAlign.Center
                Case Else
                    Return eVAlign.Top
            End Select

        End Get
        Set(value As eVAlign)
            Select Case value
                Case eVAlign.Bottom
                    m_VALIGN_CELL = "Bottom"
                Case eVAlign.Center
                    m_VALIGN_CELL = "Center"
                Case Else
                    m_VALIGN_CELL = "Top"
            End Select
        End Set
    End Property

    <Category("06. Căn chữ cho ô dữ liệu")>
    <DisplayName("Horizontal Align Cell")>
    <Description("HALIGN_CELL: căn chữ chiều ngang.")>
    Public Property H_ALIGN_CELL As eHAlign
        Get
            Select Case m_HALIGN_CELL.ToUpper()
                Case "RIGHT"
                    Return eHAlign.Right
                Case "CENTER"
                    Return eHAlign.Center
                Case Else
                    Return eHAlign.Left
            End Select

        End Get
        Set(value As eHAlign)
            Select Case value
                Case eHAlign.Right
                    m_HALIGN_CELL = "Right"
                Case eHAlign.Center
                    m_HALIGN_CELL = "Center"
                Case Else
                    m_HALIGN_CELL = "Left"
            End Select
        End Set
    End Property

    '======================



    <Category("07. Định dạng dữ liệu trong ô tổng")>
    <DisplayName("SummaryType")>
    <Description("SummaryType: loại tính tổng ở dòng footer")>
    Public Property SUMMARYTYPE As eSummaryType
        Get
            Select Case m_SUMMARYTYPE.ToUpper()
                Case "SUM"
                    Return eSummaryType.Sum
                Case "AVERAGE"
                    Return eSummaryType.Average
                Case "COUNT"
                    Return eSummaryType.Count
                Case "MIN"
                    Return eSummaryType.Min
                Case "MAX"
                    Return eSummaryType.Max
                Case Else
                    Return eSummaryType.None
            End Select

        End Get
        Set(value As eSummaryType)
            Select Case value
                Case eSummaryType.Average
                    m_SUMMARYTYPE = "Average"
                Case eSummaryType.Count
                    m_SUMMARYTYPE = "Count"
                Case eSummaryType.Max
                    m_SUMMARYTYPE = "Max"
                Case eSummaryType.Min
                    m_SUMMARYTYPE = "Min"
                Case eSummaryType.Sum
                    m_SUMMARYTYPE = "Sum"
                Case Else
                    m_SUMMARYTYPE = "None"
            End Select
        End Set
    End Property

    <Category("07. Định dạng dữ liệu trong ô tổng")>
    <DisplayName("SummaryFormat")>
    <Description("SummaryFormat: Định dạng cho kết quả tổng ở dòng footer")>
    Public Property SUMMARY_FORMAT As String

    <Category("5. Other")>
    <DisplayName("MergeBand")>
    <Description("MERGE_BAND: Sẽ gộp ô chung với band nếu band caption trống khi xuất excel")>
    Public Property MERGE_BAND As Boolean


    <Browsable(False)>
    Public Property RET As Integer?

    <Browsable(False)>
    Private m_FORMAT_TYPE As String

    <Browsable(False)>
    Private m_TYPE As eFormatType

    <Browsable(False)>
    Public Property FORMAT_TYPE As String
        Get
            Return m_FORMAT_TYPE
        End Get
        Set(value As String)
            m_FORMAT_TYPE = value
            Select Case value.ToUpper()
                Case "NUMERIC"
                    m_TYPE = eFormatType.Numeric
                Case "DATETIME", "DATE"
                    m_TYPE = eFormatType.Datetime
                Case "CUSTOM"
                    m_TYPE = eFormatType.Custom
                Case Else
                    m_TYPE = eFormatType.None
            End Select
        End Set
    End Property


    <Browsable(False)>
    Private m_WIDTH As Integer

    <Browsable(False)>
    Private m_VISIBLE_INDEX As Integer

    <Browsable(False)>
    Private m_BACK_COLOR As String

    <Browsable(False)>
    Public Property BACK_COLOR As String
        Get
            Return m_BACK_COLOR
        End Get
        Set(value As String)
            BACKCOLOR = System.Drawing.ColorTranslator.FromHtml(value)
        End Set
    End Property

    <Browsable(False)>
    Private m_FORE_COLOR As String

    <Browsable(False)>
    Public Property FORE_COLOR As String
        Get
            Return m_FORE_COLOR
        End Get
        Set(value As String)
            FORECOLOR = System.Drawing.ColorTranslator.FromHtml(value)
        End Set
    End Property


    <Browsable(False)>
    Private m_VALIGN As String

    <Browsable(False)>
    Public Property VALIGN As String
        Get
            Return m_VALIGN
        End Get
        Set(value As String)
            Select Case value.ToUpper()
                Case "BOTTOM"
                    V_ALIGN = eVAlign.Bottom
                Case "CENTER"
                    V_ALIGN = eVAlign.Center
                Case Else
                    V_ALIGN = eVAlign.Top
            End Select

        End Set
    End Property

    <Browsable(False)>
    Private m_HALIGN As String

    <Browsable(False)>
    Public Property HALIGN As String
        Get
            Return m_HALIGN
        End Get
        Set(value As String)
            Select Case value.ToUpper()
                Case "BOTTOM"
                    H_ALIGN = eHAlign.Right
                Case "CENTER"
                    H_ALIGN = eHAlign.Center
                Case Else
                    H_ALIGN = eHAlign.Left
            End Select

        End Set
    End Property

    <Browsable(False)>
    Private m_SUMMARYTYPE As String

    <Browsable(False)>
    Public Property SUMMARY_TYPE As String
        Get
            Return m_SUMMARYTYPE
        End Get
        Set(value As String)
            Select Case value.ToUpper()
                Case "SUM"
                    SUMMARYTYPE = eSummaryType.Sum
                Case "AVERAGE"
                    SUMMARYTYPE = eSummaryType.Average
                Case "COUNT"
                    SUMMARYTYPE = eSummaryType.Count
                Case "MIN"
                    SUMMARYTYPE = eSummaryType.Min
                Case "MAX"
                    SUMMARYTYPE = eSummaryType.Max
                Case Else
                    SUMMARYTYPE = eSummaryType.None
            End Select

        End Set
    End Property

    <Browsable(False)>
    Private m_FONT As System.Drawing.Font

    <Browsable(False)>
    Private Property m_FONT_NAME As String
    <Browsable(False)>
    Public Property FONT_NAME As String
        Get
            Return m_FONT_NAME
        End Get
        Set(value As String)
            m_FONT_NAME = value
            m_FONT = New Drawing.Font(value, m_FONT.Size, m_FONT.Style)
        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_ITALIC As Boolean
    <Browsable(False)>
    Public Property FONT_ITALIC As Boolean
        Get
            Return m_FONT_ITALIC
        End Get
        Set(value As Boolean)
            m_FONT_ITALIC = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            If m_FONT.Bold = True Then
                s = s Or Drawing.FontStyle.Bold
            End If
            m_FONT = New Drawing.Font(m_FONT.Name, m_FONT.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_BOLD As Boolean
    <Browsable(False)>
    Public Property FONT_BOLD As Boolean
        Get
            Return m_FONT_BOLD
        End Get
        Set(value As Boolean)
            m_FONT_BOLD = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Bold
            End If
            If m_FONT.Italic = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            m_FONT = New Drawing.Font(m_FONT.Name, m_FONT.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_SIZE As Decimal
    <Browsable(False)>
    Public Property FONT_SIZE As Decimal
        Get
            Return m_FONT_SIZE
        End Get
        Set(value As Decimal)
            m_FONT_SIZE = value
            m_FONT = New Drawing.Font(m_FONT.Name, value, m_FONT.Style)

        End Set
    End Property

    '==============================

    <Browsable(False)>
    Private m_BACK_COLOR_CELL As String

    <Browsable(False)>
    Public Property BACK_COLOR_CELL As String
        Get
            Return m_BACK_COLOR_CELL
        End Get
        Set(value As String)
            m_BACK_COLOR_CELL = value
            BACKCOLOR_CELL = System.Drawing.ColorTranslator.FromHtml(value)
        End Set
    End Property

    <Browsable(False)>
    Private m_FORE_COLOR_CELL As String

    <Browsable(False)>
    Public Property FORE_COLOR_CELL As String
        Get
            Return m_FORE_COLOR_CELL
        End Get
        Set(value As String)
            FORECOLOR_CELL = System.Drawing.ColorTranslator.FromHtml(value)
        End Set
    End Property


    <Browsable(False)>
    Private m_VALIGN_CELL As String

    <Browsable(False)>
    Public Property VALIGN_CELL As String
        Get
            Return m_VALIGN_CELL
        End Get
        Set(value As String)
            Select Case value.ToUpper()
                Case "BOTTOM"
                    V_ALIGN_CELL = eVAlign.Bottom
                Case "CENTER"
                    V_ALIGN_CELL = eVAlign.Center
                Case Else
                    V_ALIGN_CELL = eVAlign.Top
            End Select

        End Set
    End Property

    <Browsable(False)>
    Private m_HALIGN_CELL As String

    <Browsable(False)>
    Public Property HALIGN_CELL As String
        Get
            Return m_HALIGN_CELL
        End Get
        Set(value As String)
            Select Case value.ToUpper()
                Case "BOTTOM"
                    H_ALIGN_CELL = eHAlign.Right
                Case "CENTER"
                    H_ALIGN_CELL = eHAlign.Center
                Case Else
                    H_ALIGN_CELL = eHAlign.Left
            End Select

        End Set
    End Property

    <Browsable(False)>
    Private m_FONT_CELL As System.Drawing.Font

    <Browsable(False)>
    Private Property m_FONT_NAME_CELL As String
    <Browsable(False)>
    Public Property FONT_NAME_CELL As String
        Get
            Return m_FONT_NAME_CELL
        End Get
        Set(value As String)
            m_FONT_NAME_CELL = value
            m_FONT_CELL = New Drawing.Font(value, m_FONT_CELL.Size, m_FONT_CELL.Style)
        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_ITALIC_CELL As Boolean
    <Browsable(False)>
    Public Property FONT_ITALIC_CELL As Boolean
        Get
            Return m_FONT_ITALIC_CELL
        End Get
        Set(value As Boolean)
            m_FONT_ITALIC_CELL = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            If m_FONT_CELL.Bold = True Then
                s = s Or Drawing.FontStyle.Bold
            End If
            If m_FONT_CELL.Underline = True Then
                s = s Or Drawing.FontStyle.Underline
            End If
            m_FONT_CELL = New Drawing.Font(m_FONT_CELL.Name, m_FONT_CELL.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_BOLD_CELL As Boolean
    <Browsable(False)>
    Public Property FONT_BOLD_CELL As Boolean
        Get
            Return m_FONT_BOLD_CELL
        End Get
        Set(value As Boolean)
            m_FONT_BOLD_CELL = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Bold
            End If
            If m_FONT_CELL.Italic = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            If m_FONT_CELL.Underline = True Then
                s = s Or Drawing.FontStyle.Underline
            End If
            m_FONT_CELL = New Drawing.Font(m_FONT_CELL.Name, m_FONT_CELL.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_UNDERLINE_CELL As Boolean
    <Browsable(False)>
    Public Property FONT_UNDERLINE_CELL As Boolean
        Get
            Return m_FONT_UNDERLINE_CELL
        End Get
        Set(value As Boolean)
            m_FONT_UNDERLINE_CELL = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Bold
            End If
            If m_FONT_CELL.Italic = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            If m_FONT_CELL.Underline = True Then
                s = s Or Drawing.FontStyle.Underline
            End If
            m_FONT_CELL = New Drawing.Font(m_FONT_CELL.Name, m_FONT_CELL.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_SIZE_CELL As Decimal
    <Browsable(False)>
    Public Property FONT_SIZE_CELL As Decimal
        Get
            Return m_FONT_SIZE_CELL
        End Get
        Set(value As Decimal)
            m_FONT_SIZE_CELL = value
            m_FONT_CELL = New Drawing.Font(m_FONT_CELL.Name, value, m_FONT_CELL.Style)

        End Set
    End Property

    Public Sub New()
        Me.FONT = New Drawing.Font("Arial", 10, Drawing.FontStyle.Regular)
        Me.FONT_CELL = New Drawing.Font("Arial", 10, Drawing.FontStyle.Regular)
        Me.MENUID = ""
        Me.MA_MAU = ""
        Me.BAND_NAME = ""
        Me.FIELD_NAME = ""
        Me.CAPTION = ""
        Me.CAPTION_EN = ""
        Me.VISIBLE = True
        Me.VISIBLE_INDEX = 0
        Me.FORMAT_TYPE = "None"
        Me.FORMAT_STRING = ""
        Me.WIDTH = 75
        Me.BACK_COLOR = "#FFFFFF"
        Me.FORE_COLOR = "#000000"
        Me.HALIGN = "Left"
        Me.VALIGN = "Top"
        Me.SUMMARY_TYPE = "None"
        Me.SUMMARY_FORMAT = ""
        Me.MERGE_BAND = False
        'Me.BACK_COLOR_CELL = "#FFFFFF"
        Me.FORE_COLOR_CELL = "#000000"
        Me.HALIGN_CELL = "Left"
        Me.VALIGN_CELL = "Top"
    End Sub

    <Browsable(False)>
    Public ReadOnly Property DISPLAYTEXT
        Get
            Return Me.ToString()
        End Get
    End Property
    Public Overrides Function ToString() As String
        If Me.CAPTION = "" Then
            Return "[" & Me.FIELD_NAME & "]"
        Else
            Return Me.CAPTION
        End If
    End Function
    Public Function ShallowCopy() As ReportBandGridColumnResx
        Return DirectCast(Me.MemberwiseClone(), ReportBandGridColumnResx)
    End Function
End Class

Public Enum eFormatType
    None
    Numeric
    Datetime
    Custom
End Enum

Public Enum eVAlign
    Top
    Center
    Bottom
End Enum
Public Enum eHAlign
    Left
    Center
    Right
End Enum

Public Enum eSummaryType
    None
    Sum
    Min
    Max
    Count
    Average
End Enum