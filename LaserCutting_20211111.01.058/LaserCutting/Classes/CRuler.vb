Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices
Imports System.ComponentModel
Imports Newtonsoft.Json
Imports System.IO

Public Class CRuler
    Private m_Busy As Boolean = False
    <Browsable(False)>
    Public WriteOnly Property Busy As Boolean
        Set(ByVal value As Boolean)
            m_Busy = value
        End Set
    End Property
    Private m_Color As Color = Drawing.Color.Red
    <Category("Ruler")>
    <DisplayName("Color")>
    <Description("Set color for ruler")>
    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            If (value.Name = "Maroon") Then
                value = Color.FromArgb(value.A, value.R - 1, value.G, value.B)
            End If
            m_Color = value
            If (m_Busy = False) Then
                UpdateRuler()
            End If
        End Set
    End Property
    Private m_SpotColor As Color = Drawing.Color.Red
    <Category("Laser spot")>
    <DisplayName("Spot Color")>
    <Description("Set color for laser spot")>
    Public Property SpotColor As Color
        Get
            Return m_SpotColor
        End Get
        Set(ByVal value As Color)
            m_SpotColor = value
            If (m_Busy = False) Then
                If (m_Visible = True) Then
                    m_Visible = False
                    ShowRuler()
                    m_RulerEntities(0).Color = value
                    m_Visible = True
                    ShowRuler()
                Else
                    m_RulerEntities(0).Color = value
                End If
            End If
        End Set
    End Property
    Private m_Visible As Boolean = False
    <Category("Ruler")>
    <DisplayName("Visible")>
    <Description("Determines whether the ruler is visible or hidden")>
    Public Property Visible As Boolean
        Get
            Return m_Visible
        End Get
        Set(ByVal value As Boolean)
            m_Visible = value
            If (m_Busy = False) Then
                If (m_SpotVisible = True AndAlso m_Visible = True) Then
                    Parent.Controls.Add(m_RulerEntities(0))
                Else
                    Parent.Controls.Remove(m_RulerEntities(0))
                End If
                ShowRuler()
            End If
        End Set
    End Property
    Private m_SpotSize As Integer = 500
    <Category("Laser spot")>
    <DisplayName("Spot Size")>
    <Description("Set laser spot size (um)")>
    Public Property SpotSize As Integer
        Get
            Return m_SpotSize
        End Get
        Set(ByVal value As Integer)
            m_SpotSize = value
            If (m_Busy = False) Then
                Dim spot As CRulerCircle = CType(m_RulerEntities(0), CRulerCircle)
                If (m_Visible = True) Then
                    spot.SmallestCircleRadius = SpotSizeToPixel
                Else
                    spot.SmallestCircleRadius = SpotSizeToPixel
                End If
            End If
        End Set
    End Property
    <Browsable(False)>
    Public ReadOnly Property SpotSizeToPixel As Single
        Get
            Return (Me.m_SpotSize / 1000.0) * m_SpacingBetweenMinor * m_MinorToMajorCount
        End Get
    End Property
    Private m_SpotVisible As Boolean = False
    <Category("Laser spot")>
    <DisplayName("Spot Visible")>
    <Description("Set laser spot is visible or hidden")>
    Public Property SpotVisible As Boolean
        Get
            Return m_SpotVisible
        End Get
        Set(ByVal value As Boolean)
            m_SpotVisible = value
            If (m_Busy = False) Then
                If (m_SpotVisible = True AndAlso m_Visible = True) Then
                    Parent.Controls.Add(m_RulerEntities(0))
                    Parent.Controls.SetChildIndex(m_RulerEntities(0), 0)
                Else
                    Parent.Controls.Remove(m_RulerEntities(0))
                End If
            End If
        End Set
    End Property
    Private m_RulerEntities As List(Of CRulerObject) = New List(Of CRulerObject)
    <Browsable(False)>
    Public ReadOnly Property RulerEntities As List(Of CRulerObject)
        Get
            Return m_RulerEntities
        End Get
    End Property
    Private m_Parent As Control
    <Browsable(False)>
    Public Property Parent As Control
        Get
            Return m_Parent
        End Get
        Set(ByVal value As Control)
            If (m_Parent IsNot Nothing AndAlso m_RulerEntities IsNot Nothing AndAlso m_RulerEntities.Count > 0) Then
                For i = 0 To m_RulerEntities.Count - 1
                    m_Parent.Controls.Remove(m_RulerEntities(i))
                Next
            End If
            m_Parent = value
            If (m_Busy = False) Then
                CreateRuler()
            End If
        End Set
    End Property

    Private m_CenterX As Single = 0
    <Browsable(False)>
    Public Property CenterX As Single
        Get
            Return m_CenterX
        End Get
        Set(ByVal value As Single)
            m_CenterX = value
        End Set
    End Property
    Private m_CenterY As Single = 0
    <Browsable(False)>
    Public Property CenterY As Single
        Get
            Return m_CenterY
        End Get
        Set(ByVal value As Single)
            m_CenterY = value
        End Set
    End Property

    Private m_OffsetX As Single = 0
    <Category("Ruler")>
    <DisplayName("Offset X")>
    <Description("Set offset X for center ruler (px)")>
    Public Property OffsetX As Single
        Get
            Return m_OffsetX
        End Get
        Set(ByVal value As Single)
            m_OffsetX = value
            If (m_Busy = False) Then
                CreateRuler()
            End If
        End Set
    End Property
    Private m_OffsetY As Single = 0
    <Category("Ruler")>
    <DisplayName("Offset Y")>
    <Description("Set offset Y for center ruler (px)")>
    Public Property OffsetY As Single
        Get
            Return m_OffsetY
        End Get
        Set(ByVal value As Single)
            m_OffsetY = value
            If (m_Busy = False) Then
                CreateRuler()
            End If
        End Set
    End Property

    Private m_NumberCircle As Integer = 5
    <Category("Ruler Circle")>
    <DisplayName("Number Circle")>
    <Description("Set number circle for center ruler")>
    Public Property NumberCircle As Integer
        Get
            Return m_NumberCircle
        End Get
        Set(ByVal value As Integer)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must >= 0." & vbCrLf & "(該值必須 >= 0。)", "Set value error message")
            Else
                m_NumberCircle = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property
    Private m_SmallestCircleRadius As Single = 50
    <Category("Ruler Circle")>
    <DisplayName("Smallest Circle Radius")>
    <Description("Set radius for smallest circle of ruler (px)")>
    Public Property SmallestCircleRadius As Single
        Get
            Return m_SmallestCircleRadius
        End Get
        Set(ByVal value As Single)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must > 0." & vbCrLf & "(該值必須 > 0。)", "Set value error message")
            Else
                m_SmallestCircleRadius = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property

    Private m_SpacingBetweenCircle As Single = 50
    <Category("Ruler Circle")>
    <DisplayName("Spacing Between Circle")>
    <Description("Set spacing between circle of ruler (px)")>
    Public Property SpacingBetweenCircle As Single
        Get
            Return m_SpacingBetweenCircle
        End Get
        Set(ByVal value As Single)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must > 0." & vbCrLf & "(該值必須 > 0。)", "Set value error message")
            Else
                m_SpacingBetweenCircle = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property
    Private m_SpacingBetweenMinor As Single = 5
    <Category("Ruler Axis")>
    <DisplayName("Spacing Between Minor")>
    <Description("Set spacing between minor of ruler (px)")>
    Public Property SpacingBetweenMinor As Single
        Get
            Return m_SpacingBetweenMinor
        End Get
        Set(ByVal value As Single)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must > 0." & vbCrLf & "(該值必須 > 0。)", "Set value error message")
            Else
                m_SpacingBetweenMinor = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property
    Private m_MinorLength As Integer = 2
    <Category("Ruler Axis")>
    <DisplayName("Minor Length")>
    <Description("Set length for minor of ruler (px)")>
    Public Property MinorLength As Integer
        Get
            Return m_MinorLength
        End Get
        Set(ByVal value As Integer)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must >= 0." & vbCrLf & "(該值必須 >= 0。)", "Set value error message")
            Else
                m_MinorLength = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property
    Private m_MajorLength As Integer = 7
    <Category("Ruler Axis")>
    <DisplayName("Major Length")>
    <Description("Set length for major of ruler (px)")>
    Public Property MajorLength As Integer
        Get
            Return m_MajorLength
        End Get
        Set(ByVal value As Integer)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must >= 0." & vbCrLf & "(該值必須 >= 0。)", "Set value error message")
            Else
                m_MajorLength = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property

    Private m_MinorToMajorCount As Integer = 5
    <Category("Ruler Axis")>
    <DisplayName("Minor To Major Count")>
    <Description("Set number step for minor to major")>
    Public Property MinorToMajorCount As Integer
        Get
            Return m_MinorToMajorCount
        End Get
        Set(ByVal value As Integer)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must > 0." & vbCrLf & "(該值必須 > 0。)", "Set value error message")
            Else
                m_MinorToMajorCount = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property
    Private m_LineWidth As Single = 1.0F
    <Category("Ruler")>
    <DisplayName("Line Width")>
    <Description("Set width for ruler line")>
    Public Property LineWidth As Single
        Get
            Return m_LineWidth
        End Get
        Set(ByVal value As Single)
            If (value <= 0) Then
                FMessageBox.ShowError("Value must > 0." & vbCrLf & "(該值必須 > 0。)", "Set value error message")
            Else
                m_LineWidth = value
                If (m_Busy = False) Then
                    CreateRuler()
                End If
            End If
        End Set
    End Property


    Private m_HWindow As Control
    Public Sub New(ByRef pGrbCamera As Control)
        Try
            m_Parent = pGrbCamera
            m_HWindow = m_Parent
            m_CenterX = CInt(m_HWindow.Width / 2)
            m_CenterY = CInt(m_HWindow.Height / 2)
            CreateRuler()
        Catch ex As Exception
            FMessageBox.ShowError("Error initializing the ruler." & vbCrLf & "(初始化標尺時出錯。)", "Create ruler error message", True, ex)
        End Try
    End Sub

    Public Sub CreateRuler()

        For i = 0 To m_RulerEntities.Count - 1
            m_Parent.Controls.Remove(m_RulerEntities(i))
        Next

        m_RulerEntities.Clear()

        'Draw Laser spot Circle
        Dim spot As CRulerCircle = New CRulerCircle(m_LineWidth, m_SpotColor, m_HWindow.Width, m_HWindow.Height, SpotSizeToPixel, 1, 0, m_OffsetX, m_OffsetY)
        spot.Name = "Spot"
        m_RulerEntities.Add(spot)

        'Draw axis
        Dim XAxis As CRulerLine = New CRulerLine(m_LineWidth, m_Color, 0, 0, m_HWindow.Width, m_HWindow.Height, m_MinorLength, m_SpacingBetweenMinor, m_MajorLength, m_MinorToMajorCount, m_OffsetX, m_OffsetY)
        XAxis.Name = "XAxis"
        m_RulerEntities.Add(XAxis)
        'Draw Circle
        Dim Circle As CRulerCircle = New CRulerCircle(m_LineWidth, m_Color, m_HWindow.Width, m_HWindow.Height, m_SmallestCircleRadius, m_NumberCircle, m_SpacingBetweenCircle, m_OffsetX, m_OffsetY)
        XAxis.Name = "Circle"
        m_RulerEntities.Add(Circle)

        m_Parent.Controls.AddRange(m_RulerEntities.ToArray)
        ShowRuler()

    End Sub
    Public Sub UpdateRuler()
        m_Visible = False
        ShowRuler()
        For i = 1 To m_RulerEntities.Count - 1
            m_RulerEntities(i).Color = m_Color
        Next
        m_Visible = True
        ShowRuler()
    End Sub

    Public Sub Dispose()
        For i = 0 To m_RulerEntities.Count - 1
            m_RulerEntities(i).Dispose()
        Next
    End Sub

    Public Sub ShowRuler()
        If (m_SpotVisible = True AndAlso m_Visible = True) Then
            m_RulerEntities(0).BringToFront()
            Try
                Parent.Controls.SetChildIndex(m_RulerEntities(0), 0)
            Catch
            End Try
        Else
            m_RulerEntities(0).SendToBack()
        End If
        For i = 1 To m_RulerEntities.Count - 1
            If (m_Visible = True) Then
                m_RulerEntities(i).BringToFront()
            Else
                m_RulerEntities(i).SendToBack()
            End If
        Next
    End Sub


End Class
Public Module MRuler
    Public Function ColorToHex(ByVal c As Color) As String
        Return "#" & c.R.ToString("X2") & c.G.ToString("X2") & c.B.ToString("X2")
    End Function
    Public Function HexToColor(ByVal hex As String) As Color
        Try
            Return System.Drawing.ColorTranslator.FromHtml(Hex)
        Catch ex As Exception
            Return Color.Black
        End Try
    End Function
    Public Sub Save(ByVal ruler As CRuler, ByVal pPath As String)
        Try
            Dim sw As StreamWriter = New StreamWriter(pPath, False, System.Text.Encoding.Default)
            With ruler
                Dim str As String = String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}|{10}|{11}|{12}|{13}|{14}", ColorToHex(.Color), .LineWidth, .OffsetX, .OffsetY, .Visible.ToString(), .MajorLength, .MinorLength, .MinorToMajorCount, .SpacingBetweenMinor, .NumberCircle, .SmallestCircleRadius, .SpacingBetweenCircle, ColorToHex(.SpotColor), .SpotSize, .SpotVisible.ToString())
                sw.Write(str)
            End With
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            FMessageBox.ShowError("Error while save ruler.", "Save ruler error message", True, ex)
        End Try
    End Sub
    Public Sub Load(ByRef ruler As CRuler, ByVal pPath As String)
        Try
            If (Not File.Exists(pPath)) Then
                Dim str As String = pPath.Substring(0, pPath.LastIndexOf("\"c))
                If (Not Directory.Exists(str)) Then
                    Directory.CreateDirectory(str)
                End If
                If (ruler IsNot Nothing) Then
                    Save(ruler, pPath)
                End If
                Exit Sub
            End If
            Dim sr As StreamReader = New StreamReader(pPath, System.Text.Encoding.Default)
            Dim res() As String = sr.ReadToEnd().Split("|")
            sr.Close()
            sr.Dispose()
            If (res.Length = 15) Then
                With ruler
                    .Busy = True
                    .Color = HexToColor(res(0))
                    .LineWidth = CSng(res(1))
                    .OffsetX = CInt(res(2))
                    .OffsetY = CInt(res(3))
                    '.Visible = CBool(res(4))
                    .MajorLength = CInt(res(5))
                    .MinorLength = CInt(res(6))
                    .MinorToMajorCount = CInt(res(7))
                    .SpacingBetweenMinor = CInt(res(8))
                    .NumberCircle = CInt(res(9))
                    .SmallestCircleRadius = CSng(res(10))
                    .SpacingBetweenCircle = CSng(res(11))
                    .SpotColor = HexToColor(res(12))
                    .SpotSize = CInt(res(13))
                    '.SpotVisible = CBool(res(14))
                    .Busy = False
                End With
            End If
            ruler.CreateRuler()
        Catch ex As Exception
            FMessageBox.ShowError("Error while load ruler.", "Load ruler error message", True, ex)
        End Try
    End Sub
End Module

Public MustInherit Class CRulerObject
    Inherits Panel
    Protected m_bmp As Bitmap = Nothing
    Protected m_PenWidth As Single = 1
    Protected m_Color As Color = Color.Red

    Public Property PenWidth As Single
        Get
            Return m_PenWidth
        End Get
        Set(ByVal value As Single)
            m_PenWidth = Math.Max(value, 1.0F)
            UpdateData()
        End Set
    End Property
    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
            UpdateData()
        End Set
    End Property
    Public Sub New(ByVal pPenWidth As Single, ByVal pColor As Color)
        Me.m_PenWidth = pPenWidth
        Me.m_Color = pColor
    End Sub
    Protected m_CenterX As Integer = 0
    Public Property CenterX As Integer
        Get
            Return m_CenterX
        End Get
        Set(ByVal value As Integer)
            m_CenterX = value
        End Set
    End Property
    Protected m_CenterY As Integer = 0
    Public Property CenterY As Integer
        Get
            Return m_CenterY
        End Get
        Set(ByVal value As Integer)
            m_CenterY = value
        End Set
    End Property
    Protected m_OffsetX As Integer = 0
    Public Property OffsetX As Integer
        Get
            Return m_OffsetX
        End Get
        Set(ByVal value As Integer)
            m_OffsetX = value
        End Set
    End Property
    Protected m_OffsetY As Integer = 0
    Public Property OffsetY As Integer
        Get
            Return m_OffsetY
        End Get
        Set(ByVal value As Integer)
            m_OffsetY = value
        End Set
    End Property
    Protected MustOverride Sub UpdateData()
    Protected Function GetRegion(ByVal bmp As Bitmap) As GraphicsPath
        Dim gPath As GraphicsPath = New GraphicsPath()
        gPath.FillMode = FillMode.Winding
        Dim bmData As BitmapData = Nothing
        Try
            bmData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)
            Dim stride As Integer = bmData.Stride

            For y As Integer = 0 To bmp.Height - 1

                For x As Integer = 0 To bmp.Width - 1
                    Dim b As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4)
                    Dim g As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 1)
                    Dim r As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 2)
                    Dim a As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 3)
                    If Color.FromArgb(a, r, g, b).Equals(Color.FromArgb(Me.BackColor.ToArgb())) = False Then
                        gPath.AddRectangle(New RectangleF(x, y, 1, 1))
                    End If
                Next
            Next
            bmp.UnlockBits(bmData)
        Catch
            Try
                bmp.UnlockBits(bmData)
            Catch
            End Try
        End Try
        Return gPath
    End Function
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)
        e.Graphics.DrawImage(Me.m_bmp, 0, 0)
    End Sub
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If m_bmp IsNot Nothing Then m_bmp.Dispose()
        MyBase.Dispose(disposing)
    End Sub
End Class

Public Class CRulerLine
    Inherits CRulerObject
    Private m_StartX As Single = 0
    Private m_StartY As Single = 0
    Private m_EndX As Single = 0
    Private m_EndY As Single = 0
    Public Property StartX As Single
        Get
            Return m_StartX
        End Get
        Set(ByVal value As Single)
            m_StartX = value
        End Set
    End Property
    Public Property StartY As Single
        Get
            Return m_StartY
        End Get
        Set(ByVal value As Single)
            m_StartY = value
        End Set
    End Property
    Public Property EndX As Single
        Get
            Return m_EndX
        End Get
        Set(ByVal value As Single)
            m_EndX = value
        End Set
    End Property
    Public Property EndY As Single
        Get
            Return m_EndY
        End Get
        Set(ByVal value As Single)
            m_EndY = value
        End Set
    End Property

    Private m_SpacingBetweenMinor As Single = 5
    Public Property SpacingBetweenMinor As Single
        Get
            Return m_SpacingBetweenMinor
        End Get
        Set(ByVal value As Single)
            m_SpacingBetweenMinor = value
        End Set
    End Property
    Private m_MinorLength As Integer = 2
    Public Property MinorLength As Integer
        Get
            Return m_MinorLength
        End Get
        Set(ByVal value As Integer)
            m_MinorLength = value
        End Set
    End Property
    Private m_MajorLength As Integer = 7
    Public Property MajorLenght As Integer
        Get
            Return m_MajorLength
        End Get
        Set(ByVal value As Integer)
            m_MajorLength = value
        End Set
    End Property

    Private m_MinorToMajorCount As Integer = 5
    Public Property MinorToMajorCount As Integer
        Get
            Return m_MinorToMajorCount
        End Get
        Set(ByVal value As Integer)
            m_MinorToMajorCount = value
        End Set
    End Property


    Public Sub New(ByVal pPenWidth As Single, ByVal pPenColor As Color, ByVal pStartX As Single, ByVal pStartY As Single, ByVal pEndX As Single, ByVal pEndY As Single, ByVal pMinorLength As Integer, ByVal pSpacingMinor As Integer, ByVal pMajorLength As Integer, ByVal pMinorToMajorCount As Integer, ByVal pOffsetX As Integer, ByVal pOffsetY As Integer)
        MyBase.New(pPenWidth, pPenColor)
        Me.m_StartX = pStartX
        Me.m_StartY = pStartY
        Me.m_EndX = pEndX
        Me.m_EndY = pEndY
        Me.m_MinorLength = pMinorLength
        Me.m_MinorToMajorCount = pMinorToMajorCount
        Me.m_MajorLength = pMajorLength
        Me.m_SpacingBetweenMinor = pSpacingMinor
        Me.m_OffsetX = pOffsetX
        Me.m_OffsetY = pOffsetY

        Me.Size = New Size(Math.Abs(EndX - StartX) + Me.m_PenWidth + 2 * MajorLenght, Math.Abs(EndY - StartY) + Me.m_PenWidth + 2 * MajorLenght)
        Me.Top = Math.Min(StartY, EndY) - MajorLenght
        Me.Left = Math.Min(StartX, EndX) - MajorLenght
        m_CenterX = CInt(Me.Width / 2)
        m_CenterY = CInt(Me.Height / 2)

        UpdateData()
    End Sub
    Protected Overrides Sub UpdateData()
        If Me.Region IsNot Nothing Then Me.Region.Dispose()
        Me.Region = Nothing

        If m_bmp IsNot Nothing Then
            m_bmp.Dispose()
            m_bmp = Nothing
        End If

        m_bmp = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)

        Using g As Graphics = Graphics.FromImage(m_bmp)
            g.Clear(Me.BackColor)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic

            Using pen As Pen = New Pen(Me.m_Color, Me.m_PenWidth)
                'Draw X
                g.DrawLine(pen, New PointF(0, CenterY + m_OffsetY), New PointF(m_bmp.Width, CenterY + m_OffsetY))
                Dim cnt As Integer = 0
                Dim flag1 As Boolean = False
                Dim flag2 As Boolean = False
                Dim max As Single = 0
                Dim min As Single = 9999999
                While True
                    max = m_CenterX + cnt * m_SpacingBetweenMinor + m_OffsetX
                    If (flag1 = False AndAlso max < m_CenterX * 2) Then
                        If (cnt Mod m_MinorToMajorCount = 0 AndAlso cnt <> 0) Then
                            g.DrawLine(pen, New PointF(max, m_CenterY - m_MajorLength + m_OffsetY), New PointF(max, m_CenterY + m_MajorLength + m_OffsetY))
                        Else
                            g.DrawLine(pen, New PointF(max, m_CenterY - m_MinorLength + m_OffsetY), New PointF(max, m_CenterY + m_MinorLength + m_OffsetY))
                        End If
                    Else
                        flag1 = True
                    End If
                    min = m_CenterX - cnt * m_SpacingBetweenMinor + m_OffsetX
                    If (flag2 = False AndAlso min > 0) Then
                        If (cnt Mod m_MinorToMajorCount = 0 AndAlso cnt <> 0) Then
                            g.DrawLine(pen, New PointF(min, m_CenterY - m_MajorLength + m_OffsetY), New PointF(min, m_CenterY + m_MajorLength + m_OffsetY))
                        Else
                            g.DrawLine(pen, New PointF(min, m_CenterY - m_MinorLength + m_OffsetY), New PointF(min, m_CenterY + m_MinorLength + m_OffsetY))

                        End If
                    Else
                        flag2 = True
                    End If
                    If (flag1 And flag2) Then
                        Exit While
                    End If
                    cnt += 1
                End While

                'Draw Y
                g.DrawLine(pen, New PointF(m_CenterX + m_OffsetX, 0), New PointF(m_CenterX + m_OffsetX, m_bmp.Height))
                cnt = 0
                flag1 = False
                flag2 = False
                max = 0
                min = 9999999
                While True
                    max = m_CenterY + cnt * m_SpacingBetweenMinor + OffsetY
                    If (flag1 = False AndAlso max < m_CenterY * 2) Then
                        If (cnt Mod m_MinorToMajorCount = 0 AndAlso cnt <> 0) Then
                            g.DrawLine(pen, New PointF(m_CenterX - m_MajorLength + m_OffsetX, max), New PointF(m_CenterX + m_MajorLength + m_OffsetX, max))
                        Else
                            g.DrawLine(pen, New PointF(m_CenterX - m_MinorLength + m_OffsetX, max), New PointF(m_CenterX + m_MinorLength + m_OffsetX, max))
                        End If
                    Else
                        flag1 = True
                    End If
                    min = m_CenterY - cnt * m_SpacingBetweenMinor + OffsetY
                    If (flag2 = False AndAlso min > 0) Then
                        If (cnt Mod m_MinorToMajorCount = 0 AndAlso cnt <> 0) Then
                            g.DrawLine(pen, New PointF(m_CenterX - m_MajorLength + m_OffsetX, min), New PointF(m_CenterX + m_MajorLength + m_OffsetX, min))
                        Else
                            g.DrawLine(pen, New PointF(m_CenterX - m_MinorLength + m_OffsetX, min), New PointF(m_CenterX + m_MinorLength + m_OffsetX, min))

                        End If
                    Else
                        flag2 = True
                    End If
                    If (flag1 And flag2) Then
                        Exit While
                    End If
                    cnt += 1
                End While

            End Using
        End Using

        Dim gPath As GraphicsPath = GetRegion(m_bmp)
        Me.Region = New Region(gPath)
        Me.Invalidate()
    End Sub


End Class
Public Class CRulerCircle
    Inherits CRulerObject
    Private m_NumberCircle As Integer = 5
    Public Property NumberCircle As Integer
        Get
            Return m_NumberCircle
        End Get
        Set(ByVal value As Integer)
            m_NumberCircle = value
        End Set
    End Property
    Private m_SmallestCircleRadius As Single = 50
    Public Property SmallestCircleRadius As Single
        Get
            Return m_SmallestCircleRadius
        End Get
        Set(ByVal value As Single)
            m_SmallestCircleRadius = value
            UpdateData()
        End Set
    End Property

    Private m_SpacingBetweenCircle As Single = 50
    Public Property SpacingBetweenCircle As Single
        Get
            Return m_SpacingBetweenCircle
        End Get
        Set(ByVal value As Single)
            m_SpacingBetweenCircle = value
        End Set
    End Property

    Public Sub New(ByVal pPenWidth As Single, ByVal pPenColor As Color, ByVal pWidth As Single, ByVal pHeight As Single, ByVal pSmallestRadius As Single, ByVal pNumberCircel As Integer, ByVal pSpacingBetweenCircle As Integer, ByVal pOffsetX As Integer, ByVal pOffsetY As Integer)
        MyBase.New(pPenWidth, pPenColor)
        Me.m_NumberCircle = pNumberCircel
        Me.m_SmallestCircleRadius = pSmallestRadius
        Me.m_SpacingBetweenCircle = pSpacingBetweenCircle
        Me.m_OffsetX = pOffsetX
        Me.m_OffsetY = pOffsetY
        Me.Size = New Size(pWidth, pHeight)
        Me.m_CenterX = CInt(pWidth / 2)
        Me.m_CenterY = CInt(pHeight / 2)
        Me.Left = pOffsetX / 2
        Me.Top = pOffsetY / 2

        UpdateData()
    End Sub
    Protected Overrides Sub UpdateData()
        If Me.Region IsNot Nothing Then Me.Region.Dispose()
        Me.Region = Nothing

        If m_bmp IsNot Nothing Then
            m_bmp.Dispose()
            m_bmp = Nothing
        End If

        m_bmp = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)

        Using g As Graphics = Graphics.FromImage(m_bmp)
            g.Clear(Me.BackColor)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
            Using pen As Pen = New Pen(Me.m_Color, Me.m_PenWidth)
                For i = 1 To m_NumberCircle
                    Dim width As Single = (m_SmallestCircleRadius + (i - 1) * m_SpacingBetweenCircle) * 2 - m_PenWidth
                    Dim x = CSng(m_CenterX - width / 2 + m_OffsetX / 2)
                    Dim y = CSng(m_CenterY - width / 2 + m_OffsetY / 2)
                    g.DrawEllipse(pen, x, y, width, width)
                Next
            End Using
            Dim gPath As GraphicsPath = GetRegion(m_bmp)
            Me.Region = New Region(gPath)
            g.FillRegion(New SolidBrush(m_Color), Me.Region)
        End Using
        Me.Invalidate()
    End Sub


End Class
