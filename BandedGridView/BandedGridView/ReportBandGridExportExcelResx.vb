Imports System.ComponentModel

Public Class ReportBandGridExportExcelResx
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

    <Category("02. Loại đối tượng")>
    <DisplayName("IsHeader")>
    <Description("HEADER: Đánh dấu là nằm ở trên hay ở dưới bảng dữ liệu")>
    Public Property HEADER As Boolean

    <Category("02. Loại đối tượng")>
    <DisplayName("Parameter")>
    <Description("PARAMETER: Đánh dấu Giá trị được lấy từ các biến thuộc datatable như: ten_cty=Tên cty, mst=mã số thuế, address=địa chỉ cty....")>
    Public Property PARAMETER As Boolean

    <Category("03. Vị trí")>
    <DisplayName("ColumnIndex")>
    <Description("COLUMN_INDEX: Vị trí cột trong excel")>
    Public Property COLUMN_INDEX As Integer

    <Category("03. Vị trí")>
    <DisplayName("RowIndex")>
    <Description("ROW_INDEX: Vị trí dòng trong excel")>
    Public Property ROW_INDEX As Integer

    <Category("04. Kích thước")>
    <DisplayName("ColumnWidth")>
    <Description("COLUMN_WIDTH: Độ rộng cột")>
    Public Property COLUMN_WIDTH As Decimal

    <Category("04. Kích thước")>
    <DisplayName("RowHeight")>
    <Description("ROW_HIGHT: Độ cao của dòng")>
    Public Property ROW_HIGHT As Decimal

    <Category("05. Giá trị")>
    <DisplayName("Value")>
    <Description("VALUE: Giá trị ô")>
    Public Property VALUE As String

    <Category("05. Giá trị")>
    <DisplayName("ValueEnglish")>
    <Description("VALUE_EN: Giá trị ô theo tiếng anh")>
    Public Property VALUE_EN As String

    <Category("06. Hình ảnh")>
    <DisplayName("IsPicture")>
    <Description("IS_PICTURE: Giá trị là link hình ảnh")>
    Public Property IS_PICTURE As Boolean

    <Category("06. Hình ảnh")>
    <DisplayName("ScaleWidth")>
    <Description("SCALE_WIDTH: Scale độ rộng hình")>
    Public Property SCALE_WIDTH As Integer

    <Category("06. Hình ảnh")>
    <DisplayName("ScaleHeight")>
    <Description("SCALE_HEIGHT: Scale độ cao hình")>
    Public Property SCALE_HEIGHT As Integer

    <Category("06. Hình ảnh")>
    <DisplayName("OffsetX")>
    <Description("OFFSET_X: Dịch ảnh qua lại theo trục X")>
    Public Property OFFSET_X As Integer

    <Category("06. Hình ảnh")>
    <DisplayName("OffsetY")>
    <Description("OFFSET_Y: Dịch ảnh lên xuống theo trục Y")>
    Public Property OFFSET_Y As Integer

    <Category("07. Định dạng ô dữ liệu")>
    <DisplayName("DataType")>
    <Description("DATATYPE: Kiểu dữ liệu")>
    Public Property DATATYPE As eDataType
        Get
            Select Case m_TYPE.ToUpper
                Case "Text".ToUpper
                    Return eDataType.Text
                Case "Number".ToUpper
                    Return eDataType.Number
                Case "Currency".ToUpper
                    Return eDataType.Currency
                Case "Accounting".ToUpper
                    Return eDataType.Accounting
                Case "Date".ToUpper
                    Return eDataType.Date
                Case "Time".ToUpper
                    Return eDataType.Time
                Case "Percent".ToUpper
                    Return eDataType.Percent
                Case "Fraction".ToUpper
                    Return eDataType.Fraction
                Case "Scientific".ToUpper
                    Return eDataType.Scientific
                Case Else
                    Return eDataType.Genaral
            End Select
        End Get
        Set(value As eDataType)
            Select Case value
                Case eDataType.Text
                    m_TYPE = "Text"
                Case eDataType.Number
                    m_TYPE = "Number"
                Case eDataType.Currency
                    m_TYPE = "Currency"
                Case eDataType.Accounting
                    m_TYPE = "Accounting"
                Case eDataType.Date
                    m_TYPE = "Date"
                Case eDataType.Time
                    m_TYPE = "Time"
                Case eDataType.Percent
                    m_TYPE = "Percent"
                Case eDataType.Fraction
                    m_TYPE = "Fraction"
                Case eDataType.Scientific
                    m_TYPE = "Scientific"
                Case Else
                    m_TYPE = "Genaral"
            End Select
        End Set
    End Property

    <Category("07. Định dạng ô dữ liệu")>
    <DisplayName("Font")>
    <Description("FONT: Cài đặt kiểu chữ cho ô. Chỉ dùng: Font name, Font size, Font style")>
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
            FONT_UNDERLINE = m_FONT.Underline
        End Set
    End Property

    <Category("07. Định dạng ô dữ liệu")>
    <DisplayName("BackColor")>
    <Description("BACK_COLOR: Cài đặt màu nền cho ô.")>
    Public Property BACKCOLOR As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_BACK_COLOR)
        End Get
        Set(value As System.Drawing.Color)
            m_BACK_COLOR = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")
        End Set
    End Property

    <Category("07. Định dạng ô dữ liệu")>
    <DisplayName("ForeColor")>
    <Description("FORE_COLOR: Cài đặt màu chữ cho ô.")>
    Public Property FORECOLOR As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml(m_FORE_COLOR)
        End Get
        Set(value As System.Drawing.Color)
            m_FORE_COLOR = "#" + value.R.ToString("X2") + value.G.ToString("X2") + value.B.ToString("X2")
        End Set
    End Property

    <Category("07. Định dạng ô dữ liệu")>
    <DisplayName("FormatString")>
    <Description("FORMAT_STRING: Kiểu dữ liệu.")>
    Public Property FORMAT_STRING As String

    <Category("08. Kẻ khung")>
    <DisplayName("BorderLeft")>
    <Description("BORDER_LEFT: Cài đặt kẻ ô bên trái.")>
    Public Property BORDER_LEFT As Boolean

    <Category("08. Kẻ khung")>
    <DisplayName("BorderRight")>
    <Description("BORDER_RIGHT: Cài đặt kẻ ô bên phải.")>
    Public Property BORDER_RIGHT As Boolean

    <Category("08. Kẻ khung")>
    <DisplayName("BorderTop")>
    <Description("BORDER_TOP: Cài đặt kẻ ô bên trên.")>
    Public Property BORDER_TOP As Boolean

    <Category("08. Kẻ khung")>
    <DisplayName("BorderBottom")>
    <Description("BORDER_BOTTOM: Cài đặt kẻ ô bên dưới.")>
    Public Property BORDER_BOTTOM As Boolean

    <Category("09. Căn chữ")>
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

    <Category("09. Căn chữ")>
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

    <Category("09. Căn chữ")>
    <DisplayName("WrapText")>
    <Description("WRAP_TEXT: Cho phép ngắt dòng trong ô.")>
    Public Property WRAP_TEXT As Boolean

    <Category("10. Gộp ô")>
    <DisplayName("MergeCells")>
    <Description("MERGE_CELL: Gộp ô.")>
    Public Property MERGE_CELL As Boolean

    <Category("10. Gộp ô")>
    <DisplayName("ColumnTo")>
    <Description("MERGE_COLUMN_TO: Gộp ô từ ColumnIndex đến ColumnTo.")>
    Public Property MERGE_COLUMN_TO As Integer

    <Category("10. Gộp ô")>
    <DisplayName("RowTo")>
    <Description("MERGE_ROW_TO: Gộp ô từ RowIndex đến RowTo.")>
    Public Property MERGE_ROW_TO As Integer





    <Browsable(False)>
    Private m_TYPE As String
    <Browsable(False)>
    Public Property TYPE As String
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
            If m_FONT.Underline = True Then
                s = s Or Drawing.FontStyle.Underline
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
            If m_FONT.Underline = True Then
                s = s Or Drawing.FontStyle.Underline
            End If
            m_FONT = New Drawing.Font(m_FONT.Name, m_FONT.Size, s)

        End Set
    End Property

    <Browsable(False)>
    Private Property m_FONT_UNDERLINE As Boolean
    <Browsable(False)>
    Public Property FONT_UNDERLINE As Boolean
        Get
            Return m_FONT_UNDERLINE
        End Get
        Set(value As Boolean)
            m_FONT_UNDERLINE = value
            Dim s As Drawing.FontStyle = Drawing.FontStyle.Regular
            If value = True Then
                s = s Or Drawing.FontStyle.Underline
            End If
            If m_FONT.Italic = True Then
                s = s Or Drawing.FontStyle.Italic
            End If
            If m_FONT.Bold = True Then
                s = s Or Drawing.FontStyle.Bold
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

    <Browsable(False)>
    Private m_BACK_COLOR As String

    <Browsable(False)>
    Public Property BACK_COLOR As String
        Get
            Return m_BACK_COLOR
        End Get
        Set(value As String)
            If value.ToUpper = "Transparent".ToUpper Then
                BACKCOLOR = Nothing
            Else
                BACKCOLOR = System.Drawing.ColorTranslator.FromHtml(value)
            End If
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
    Public Property RET As Integer?

    Public Sub New()
        Me.FONT = New Drawing.Font("Arial", 10, Drawing.FontStyle.Regular)
        Me.MENUID = ""
        Me.MA_MAU = ""
        Me.COLUMN_INDEX = 1
        Me.ROW_INDEX = 1
        Me.COLUMN_WIDTH = 10
        Me.ROW_HIGHT = 10
        Me.VALUE = ""
        Me.VALUE_EN = ""
        Me.DATATYPE = eDataType.Genaral
        Me.IS_PICTURE = False
        Me.PARAMETER = False
        Me.BACKCOLOR = Drawing.Color.Transparent
        Me.FORECOLOR = Drawing.Color.Black
        Me.BORDER_LEFT = False
        Me.BORDER_RIGHT = False
        Me.BORDER_TOP = False
        Me.BORDER_BOTTOM = False
        Me.V_ALIGN = eVAlign.Top
        Me.H_ALIGN = eHAlign.Left
        Me.WRAP_TEXT = False
        Me.MERGE_CELL = False
        Me.MERGE_COLUMN_TO = 1
        Me.MERGE_ROW_TO = 1
        Me.FORMAT_STRING = ""
        Me.HEADER = True
    End Sub

    <Browsable(False)>
    Public ReadOnly Property DISPLAYTEXT As String
        Get
            Return Me.ToString()
        End Get
    End Property

    Public Overrides Function ToString() As String
        If Me.VALUE.Length > 100 Then
            Return String.Format("Cell ({0}:{1}): {2}...", Me.ROW_INDEX, Me.COLUMN_INDEX, Me.VALUE.Substring(0, 100))
        Else
            Return String.Format("Cell ({0}:{1}): {2}", Me.ROW_INDEX, Me.COLUMN_INDEX, Me.VALUE)
        End If
    End Function
    Public Function ShallowCopy() As ReportBandGridExportExcelResx
        Return DirectCast(Me.MemberwiseClone(), ReportBandGridExportExcelResx)
    End Function

End Class

Public Enum eDataType
    Genaral
    Number
    Currency
    Accounting
    [Date]
    [Time]
    Percent
    Fraction
    Scientific
    Text
End Enum