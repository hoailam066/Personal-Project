Imports System.ComponentModel

Public Class ReportBandedGridViewResx
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

    <Category("02. Thiết lập nhóm")>
    <DisplayName("BandName")>
    <Description("BAND_NAME: Tên của nhóm. Tên phải duy nhất.")>
    Public Property BAND_NAME As String

    <Category("02. Thiết lập nhóm")>
    <DisplayName("Caption")>
    <Description("CAPTION: Tiêu đề hiển thị của nhóm.")>
    Public Property CAPTION As String

    <Category("02. Thiết lập nhóm")>
    <DisplayName("English Caption")>
    <Description("CAPTION_EN: Tiêu đề hiển thị của nhóm theo tiếng anh.")>
    Public Property CAPTION_EN As String

    <Category("02. Thiết lập nhóm")>
    <DisplayName("Visible")>
    <Description("VISIBLE: Hiển thị")>
    Public Property VISIBLE As Boolean

    <Category("02. Thiết lập nhóm")>
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

    <Category("03. Định dạng hiển thị")>
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

    <Category("03. Định dạng hiển thị")>
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

    <Category("03. Định dạng hiển thị")>
    <DisplayName("Font")>
    <Description("FONT: Cài đặt kiểu chữ cho nhóm. Chỉ dùng: Font name, Font size, Font style")>
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

    <Category("04. Căn chữ")>
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

    <Category("04. Căn chữ")>
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

    <Browsable(False)>
    Public Property RET As Integer?

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
    Private m_VISIBLE_INDEX As Integer

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

    Public Sub New()
        Me.FONT = New Drawing.Font("Arial", 10, Drawing.FontStyle.Regular)
        Me.MENUID = ""
        Me.MA_MAU = ""
        Me.BAND_NAME = ""
        Me.CAPTION = ""
        Me.CAPTION_EN = ""
        Me.VISIBLE = True
        Me.VISIBLE_INDEX = 0
        Me.BACK_COLOR = "#FFFFFF"
        Me.FORE_COLOR = "#000000"
        Me.HALIGN = "Left"
        Me.VALIGN = "Top"

    End Sub

    <Browsable(False)>
    Public ReadOnly Property DISPLAYTEXT
        Get
            Return Me.ToString()
        End Get
    End Property
    Public Overrides Function ToString() As String
        If Me.CAPTION = "" Then
            Return "[" & Me.BAND_NAME & "]"
        Else
            Return Me.CAPTION
        End If
    End Function
    Public Function ShallowCopy() As ReportBandedGridViewResx
        Return DirectCast(Me.MemberwiseClone(), ReportBandedGridViewResx)
    End Function
End Class
