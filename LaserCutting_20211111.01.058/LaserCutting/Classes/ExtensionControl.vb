Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class ButtonEx
    Inherits Button
    Private m_Direction As eArrow = eArrow.Left
    Private m_ButtonType As eButtonType = eButtonType.Square
    Private m_Radius As Integer = 1
    Public Sub New()
        MyBase.New()
        Me.BackColor = Color.FromArgb(71, 148, 186)
        Me.FlatAppearance.MouseOverBackColor = Color.SkyBlue
        Me.FlatAppearance.BorderSize = 0
    End Sub
    <Description("Direction of the button")>
    Public Property Direction As eArrow
        Get
            Return m_Direction
        End Get
        Set(value As eArrow)
            m_Direction = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Border radius. Must be > 0")>
    Public Property Radius As Single
        Get
            Return m_Radius
        End Get
        Set(value As Single)
            If (value >= 1) Then
                m_Radius = value
            Else
                m_Radius = 1
            End If
            Me.Invalidate()
        End Set
    End Property
    <Description("Border Type")>
    Public Property ButtonType As eButtonType
        Get
            Return m_ButtonType
        End Get
        Set(value As eButtonType)
            m_ButtonType = value
            Me.Invalidate()
        End Set
    End Property

    Protected Overrides Sub OnPaint(ByVal pe As PaintEventArgs)
        Dim w As Single = Me.Width
        Dim h As Single = Me.Height
        Select Case m_ButtonType
            Case eButtonType.Arrow
                Dim pts As PointF() = Nothing
                Select Case m_Direction
                    Case eArrow.Left
                        pts = New PointF() {New PointF(1, h / 2), New PointF(w / 2, h), New PointF(w / 2, 3 * h / 4), New PointF(w, 3 * h / 4), New PointF(w, h / 4), New PointF(w / 2, h / 4), New PointF(w / 2, 0)} 'LEFT
                    Case eArrow.Right
                        pts = New PointF() {New PointF(0, h / 4), New PointF(0, 3 * h / 4), New PointF(w / 2, 3 * h / 4), New PointF(w / 2, h), New PointF(w - 1, h / 2), New PointF(w / 2, 0), New PointF(w / 2, h / 4)} 'RIGHT
                    Case eArrow.Up
                        pts = New PointF() {New PointF(w / 2, 0), New PointF(1, h / 2), New PointF(w / 4, h / 2), New PointF(w / 4, h), New PointF(3 * w / 4, h), New PointF(3 * w / 4, h / 2), New PointF(w - 1, h / 2)} 'UP
                    Case eArrow.Down
                        pts = New PointF() {New PointF(w / 4, 0), New PointF(w / 4, h / 2), New PointF(1, h / 2), New PointF(w / 2, h), New PointF(w - 1, h / 2), New PointF(3 * w / 4, h / 2), New PointF(3 * w / 4, 0)} 'DOWN
                    Case Else
                End Select
                Dim gp As GraphicsPath = New GraphicsPath()
                gp.AddPolygon(pts)
                Me.Region = New Region(gp)
                Me.Text = ""
            Case eButtonType.Square
                Dim tmp As Integer = Radius
                If (tmp = 0) Then
                    tmp = 1
                End If
                Dim r2 As Single = Radius / 2.0F
                Dim Rect As Rectangle = New Rectangle(0, 0, Me.Width, Me.Height)
                Dim GraphPath As GraphicsPath = New GraphicsPath()
                GraphPath.AddArc(Rect.X, Rect.Y, Radius, Radius, 180, 90)
                GraphPath.AddLine(Rect.X + r2, Rect.Y, Rect.Width - r2, Rect.Y)
                GraphPath.AddArc(Rect.X + Rect.Width - Radius, Rect.Y, Radius, Radius, 270, 90)
                GraphPath.AddLine(Rect.Width, Rect.Y + r2, Rect.Width, Rect.Height - r2)
                GraphPath.AddArc(Rect.X + Rect.Width - Radius, Rect.Y + Rect.Height - Radius, Radius, Radius, 0, 90)
                GraphPath.AddLine(Rect.Width - r2, Rect.Height, Rect.X + r2, Rect.Height)
                GraphPath.AddArc(Rect.X, Rect.Y + Rect.Height - Radius, Radius, Radius, 90, 90)
                GraphPath.AddLine(Rect.X, Rect.Height - r2, Rect.X, Rect.Y + r2)
                GraphPath.CloseFigure()
                Me.Region = New Region(GraphPath)
            Case eButtonType.Triangle
                Dim g As Graphics = pe.Graphics
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality
                Dim pts As PointF()
                Select Case m_Direction
                    Case eArrow.Down
                        pts = New PointF() {New PointF(0, 0), New PointF(w, 0), New PointF(w / 2, h)}
                    Case eArrow.Up
                        pts = New PointF() {New PointF(w / 2, 0), New PointF(0, w), New PointF(w, h)}
                    Case eArrow.Left
                        pts = New PointF() {New PointF(w, 0), New PointF(0, h / 2), New PointF(w, h)}
                    Case eArrow.Right
                        pts = New PointF() {New PointF(0, 0), New PointF(0, h), New PointF(w, h / 2)}
                    Case Else
                        pts = New PointF() {New PointF(w / 2, 0), New PointF(0, w), New PointF(w, h)}
                End Select
                g.FillPolygon(New LinearGradientBrush(New Point(24, 0), New Point(48, 24), Me.BackColor, Color.White), pts)
                Dim gp As GraphicsPath = New GraphicsPath()
                gp.AddPolygon(pts)
                Me.Region = New Region(gp)
        End Select
        MyBase.OnPaint(pe)
    End Sub
End Class
Public Enum eArrow
    Left
    Right
    Up
    Down
End Enum
Public Enum eButtonType
    Arrow
    Square
    Triangle
End Enum
Public Class PictureBoxEx
    Inherits PictureBox
    Private m_TurnOn As Boolean = False
    <Description("Switch on/off")>
    Public Property TurnOn As Boolean
        Get
            Return m_TurnOn
        End Get
        Set(value As Boolean)
            m_TurnOn = value
            Me.Invalidate()
        End Set
    End Property


    Private m_BorderShape As eShape = eShape.Square
    <Description("The shape of the border")>
    Public Property BorderShape As eShape
        Get
            Return m_BorderShape
        End Get
        Set(value As eShape)
            m_BorderShape = value
            Me.Invalidate()
        End Set
    End Property
    Private m_Radius As Integer = 0
    <Description("The radius of border")>
     Public Property Radius As Integer
        Get
            Return m_Radius
        End Get
        Set(value As Integer)
            m_Radius = value
            Me.Invalidate()
        End Set
    End Property
    Private m_TopColorOn As Color = Color.Black
    <Description("The color on top when on")>
     Public Property TopColorOn As Color
        Get
            Return m_TopColorOn
        End Get
        Set(value As Color)
            m_TopColorOn = value
            Me.Invalidate()
        End Set
    End Property
    Private m_TopColorOff As Color = Color.Black
    <Description("The color on top when off")>
    Public Property TopColorOff As Color
        Get
            Return m_TopColorOff
        End Get
        Set(value As Color)
            m_TopColorOff = value
            Me.Invalidate()
        End Set
    End Property
    Private m_BottomColorOn As Color = Color.Black
    <Description("The color on bottom when on")>
    Public Property BottomColorOn As Color
        Get
            Return m_BottomColorOn
        End Get
        Set(value As Color)
            m_BottomColorOn = value
            Me.Invalidate()
        End Set
    End Property
    Private m_BottomColorOff As Color = Color.Black
    <Description("The color on bottom when off")>
    Public Property BottomColorOff As Color
        Get
            Return m_BottomColorOff
        End Get
        Set(value As Color)
            m_BottomColorOff = value
            Me.Invalidate()
        End Set
    End Property
    Private m_Text As String = ""
    <Description("The text show on picturebox")>
    Public Property TextShow As String
        Get
            Return m_Text
        End Get
        Set(value As String)
            m_Text = value
            Me.Invalidate()
        End Set
    End Property

    Private m_Font As Font = New Font("Arial", 10, FontStyle.Regular)
    <Description("The font of text show on picturebox")>
    Public Property TextFont As Font
        Get
            Return m_Font
        End Get
        Set(value As Font)
            m_Font = value
            Me.Invalidate()
        End Set
    End Property

    Private m_ForeColor As Color = Color.White
    <Description("The font of text show on picturebox")>
    Public Property TextColor As Color
        Get
            Return m_ForeColor
        End Get
        Set(value As Color)
            m_ForeColor = value
            Me.Invalidate()
        End Set
    End Property
    Private m_Updating As Boolean = False
    Protected Overrides Sub OnPaint(pe As System.Windows.Forms.PaintEventArgs)
        If m_Updating = True Then
            Exit Sub
        End If
        m_Updating = True
        Dim gp As GraphicsPath = New GraphicsPath()
        Dim rect As Rectangle = New Rectangle(0, 0, ClientSize.Width, ClientSize.Height)
        If (m_BorderShape = eShape.Circle) Then
            gp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height)
        Else

            If (m_Radius = 0) Then
                gp.AddRectangle(rect)
            Else
                Dim diameter As Integer = Radius * 2
                Dim size As Size = New Size(diameter, diameter)
                Dim arc As Rectangle = New Rectangle(rect.Location, size)
                gp.AddArc(arc, 180, 90)

                arc.X = rect.Right - diameter
                gp.AddArc(arc, 270, 90)

                arc.Y = rect.Bottom - diameter
                gp.AddArc(arc, 0, 90)

                arc.X = rect.Left
                gp.AddArc(arc, 90, 90)

                gp.CloseFigure()
            End If
        End If

        Dim lgb As LinearGradientBrush
        If (m_TurnOn) Then
            lgb = New LinearGradientBrush(rect, m_TopColorOn, m_BottomColorOn, 90, True)
        Else
            lgb = New LinearGradientBrush(rect, m_TopColorOff, m_BottomColorOff, 90, True)
        End If

        Me.Region = New Region(gp)
        pe.Graphics.FillRectangle(lgb, rect)
        If (m_Text <> "") Then
            Dim s As SizeF = pe.Graphics.MeasureString(m_Text, m_Font)
            Using b As SolidBrush = New SolidBrush(m_ForeColor)
                pe.Graphics.DrawString(m_Text, m_Font, b, New PointF((Me.Width - s.Width) / 2, (Me.Height - s.Height) / 2))
            End Using
        End If
        ' MyBase.OnPaint(pe)
        m_Updating = False
    End Sub

End Class
Public Enum eShape
    Circle
    Square
End Enum

Public Class GroupBoxEx
    Inherits GroupBox
    Private m_BorderColor As Color
    <Description("The Color of around border")>
    Public Property BorderColor As Color
        Get
            Return m_BorderColor
        End Get
        Set(value As Color)
            m_BorderColor = value
            Me.Invalidate()
        End Set
    End Property
    Private m_TextColor As Color
    <Description("The Color of display Text")>
    Public Property TextColor As Color
        Get
            Return m_TextColor
        End Get
        Set(value As Color)
            m_TextColor = value
            Me.Invalidate()
        End Set
    End Property
    Private m_BorderRadius As Integer
    <Description("The radius of around border")>
    Public Property BorderRadius As UInteger
        Get
            Return m_BorderRadius
        End Get
        Set(value As UInteger)
            m_BorderRadius = value
            Me.Invalidate()
        End Set
    End Property
    Public Sub New()
        MyBase.New()
        m_BorderColor = SystemColors.ControlLight
        m_TextColor = SystemColors.ControlText
        m_BorderRadius = 0
    End Sub
    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)
        DrawGroupBox(e.Graphics)
    End Sub
    Private Sub DrawGroupBox(ByVal g As Graphics)
        Dim textBrush As Brush = New SolidBrush(TextColor)
        Dim borderBrush As Brush = New SolidBrush(BorderColor)
        Dim borderPen As Pen = New Pen(borderBrush)
        Dim strSize As SizeF = g.MeasureString(Me.Text, Me.Font)
        Dim rect As Rectangle = New Rectangle(Me.ClientRectangle.X, Me.ClientRectangle.Y + CInt((strSize.Height / 2)), Me.ClientRectangle.Width - 1, Me.ClientRectangle.Height - CInt((strSize.Height / 2)) - 1)
        Dim radius As Integer = CInt(BorderRadius)
        g.Clear(Me.BackColor)
        If (radius > 0) Then
            g.DrawString(Me.Text, Me.Font, textBrush, Me.Padding.Left + radius / 2, 0)
            g.DrawLine(borderPen, New Point(rect.X, rect.Y + radius / 2), New Point(rect.X, rect.Y + rect.Height - radius / 2))  'Left
            g.DrawLine(borderPen, New Point(rect.X + rect.Width - 1, rect.Y + radius / 2), New Point(rect.X + rect.Width - 1, rect.Y + rect.Height - radius / 2)) 'Right
            g.DrawLine(borderPen, New Point(rect.X + radius / 2, rect.Y + rect.Height - 1), New Point(rect.X + rect.Width - radius / 2, rect.Y + rect.Height - 1)) 'Bottom
            g.DrawLine(borderPen, New Point(rect.X + radius / 2, rect.Y), New Point(rect.X + Me.Padding.Left + radius / 2, rect.Y)) 'Top - Left
            g.DrawLine(borderPen, New Point(rect.X + Me.Padding.Left + CInt((strSize.Width)) + radius / 2, rect.Y), New Point(rect.X + rect.Width - radius / 2, rect.Y)) 'Top - Right

            g.DrawArc(borderPen, rect.X, rect.Y, radius, radius, 180, 90) '1
            g.DrawArc(borderPen, rect.X + rect.Width - radius - 1, rect.Y, radius, radius, 270, 90)
            g.DrawArc(borderPen, rect.X + rect.Width - radius - 1, rect.Y + rect.Height - radius - 1, radius, radius, 0, 90)
            g.DrawArc(borderPen, rect.X, rect.Y + rect.Height - radius - 1, radius, radius, 90, 90)
        Else
            g.DrawString(Me.Text, Me.Font, textBrush, Me.Padding.Left, 0)
            g.DrawLine(borderPen, rect.Location, New Point(rect.X, rect.Y + rect.Height))  'Left
            g.DrawLine(borderPen, New Point(rect.X + rect.Width, rect.Y), New Point(rect.X + rect.Width, rect.Y + rect.Height)) 'Right
            g.DrawLine(borderPen, New Point(rect.X, rect.Y + rect.Height), New Point(rect.X + rect.Width, rect.Y + rect.Height)) 'Bottom
            g.DrawLine(borderPen, New Point(rect.X, rect.Y), New Point(rect.X + Me.Padding.Left, rect.Y)) 'Top - Left
            g.DrawLine(borderPen, New Point(rect.X + Me.Padding.Left + CInt((strSize.Width)), rect.Y), New Point(rect.X + rect.Width, rect.Y)) 'Top - Right
        End If
    End Sub
End Class

Public Class CheckBoxEx
    Inherits CheckBox

    Private m_BoxSize As Integer = 14
    Private m_BoxLocationX As Integer = 0
    Private m_BoxLocationY As Integer = 0
    Private m_TextX As Integer = 16
    Private m_TextY As Integer = 1
    Private m_BoxBackColor As Color = Color.Transparent
    Private m_TickColor As Color = Color.Black
    Private m_TickSize As Single = 11.0F
    Private m_BoxColor As Color = Color.Black
    Private m_TickLeftPosition As Single = 0.0F
    Private m_TickTopPosition As Single = 0.0F
    <Description("The X location of text")>
    Public Property TextLocationX As Integer
        Get
            Return m_TextX
        End Get
        Set(ByVal value As Integer)
            m_TextX = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The Y location of text")>
    Public Property TextLocationY As Integer
        Get
            Return m_TextY
        End Get
        Set(ByVal value As Integer)
            m_TextY = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The size of box")>
    Public Property BoxSize As Integer
        Get
            Return m_BoxSize
        End Get
        Set(ByVal value As Integer)
            m_BoxSize = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The X location of box")>
    Public Property BoxLocationX As Integer
        Get
            Return m_BoxLocationX
        End Get
        Set(ByVal value As Integer)
            m_BoxLocationX = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The Y location of box")>
    Public Property BoxLocationY As Integer
        Get
            Return m_BoxLocationY
        End Get
        Set(ByVal value As Integer)
            m_BoxLocationY = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The background color of box")>
    Public Property BoxBackColor As Color
        Get
            Return m_BoxBackColor
        End Get
        Set(ByVal value As Color)
            m_BoxBackColor = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The color of tick symbol")>
    Public Property TickColor As Color
        Get
            Return m_TickColor
        End Get
        Set(ByVal value As Color)
            m_TickColor = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The size of tick symbol")>
    Public Property TickSize As Single
        Get
            Return m_TickSize
        End Get
        Set(ByVal value As Single)
            m_TickSize = value
            Me.Invalidate()
        End Set
    End Property
    <Description("The color of border")>
    Public Property BoxColor As Color
        Get
            Return m_BoxColor
        End Get
        Set(ByVal value As Color)
            m_BoxColor = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Position from the left to tick symbol")>
    Public Property TickLeftPosition As Single
        Get
            Return m_TickLeftPosition
        End Get
        Set(ByVal value As Single)
            m_TickLeftPosition = value
            Me.Invalidate()
        End Set
    End Property
    <Description("Position from the top to tick symbol")>
    Public Property TickTopPosition As Single
        Get
            Return m_TickTopPosition
        End Get
        Set(ByVal value As Single)
            m_TickTopPosition = value
            Me.Invalidate()
        End Set
    End Property

    Private m_DoubleBorder As Boolean
    <Description("Duplicate the border")>
    Public Property DoubleBorder As Boolean
        Get
            Return m_DoubleBorder
        End Get
        Set(value As Boolean)
            m_DoubleBorder = value
            Me.Invalidate()
        End Set
    End Property
    Private m_BoxSpacing As Integer
    <Description("Space between the borders")>
    Public Property BoxSpacing As UInteger
        Get
            Return m_BoxSpacing
        End Get
        Set(value As UInteger)
            m_BoxSpacing = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        Appearance = Appearance.Button
        FlatStyle = FlatStyle.Flat
        TextAlign = ContentAlignment.MiddleRight
        FlatAppearance.BorderSize = 0
        AutoSize = False
    End Sub

    Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
        Try
            MyBase.OnPaint(pevent)
            pevent.Graphics.Clear(BackColor)
            Dim fc As Color = ForeColor
            If (Me.Enabled = False) Then
                fc = Color.DarkGray
            End If
            Using brushText As SolidBrush = New SolidBrush(fc)
                pevent.Graphics.DrawString(Text, Font, brushText, m_TextX, m_TextY)
            End Using

            Dim _rectangleBox As Rectangle = New Rectangle(m_BoxLocationX, m_BoxLocationY, m_BoxSize, m_BoxSize)
            
            Using brushBackColor As SolidBrush = New SolidBrush(m_BoxBackColor)
                pevent.Graphics.FillRectangle(brushBackColor, _rectangleBox)
            End Using
            Dim bc As Color = m_BoxColor
            If (Me.Enabled = False) Then
                bc = Color.DarkGray
            End If
            Using penBoxColor As Pen = New Pen(bc)
                pevent.Graphics.DrawRectangle(penBoxColor, _rectangleBox)
                If (m_DoubleBorder) Then
                    Dim _rectangleBox2 As Rectangle = New Rectangle(m_BoxLocationX + m_BoxSpacing, m_BoxLocationY + m_BoxSpacing, m_BoxSize - 2 * m_BoxSpacing, m_BoxSize - 2 * m_BoxSpacing)
                    pevent.Graphics.DrawRectangle(penBoxColor, _rectangleBox2)
                End If
            End Using

            If Checked Then
                Dim c As Color = m_TickColor
                If (Me.Enabled = False) Then
                    c = Color.DarkGray
                End If
                Using brush As SolidBrush = New SolidBrush(c)
                    Using wing As Font = New Font("Wingdings", m_TickSize, FontStyle.Bold)
                        pevent.Graphics.DrawString("ü", wing, brush, m_TickLeftPosition, m_TickTopPosition)
                    End Using
                End Using
            End If


            pevent.Dispose()
        Catch ex As Exception
        End Try
    End Sub
End Class

Public Class RadioButtonEx
    Inherits RadioButton

    Private m_CircleRadius As Integer = 8
    Public Property CircleRadius As Integer
        Get
            Return m_CircleRadius
        End Get
        Set(ByVal value As Integer)
            m_CircleRadius = value
            Me.Invalidate()
        End Set
    End Property
    Private m_CircleCheckedRadius As Integer = 6
    Public Property CircleCheckedRadius As Integer
        Get
            Return m_CircleCheckedRadius
        End Get
        Set(ByVal value As Integer)
            m_CircleCheckedRadius = value
            Me.Invalidate()
        End Set
    End Property
    Private m_CircleWidth As Single = 1.0
    Public Property CircleWidth As Single
        Get
            Return m_CircleWidth
        End Get
        Set(ByVal value As Single)
            m_CircleWidth = value
            Me.Invalidate()
        End Set
    End Property
    Private m_CircleColor As Color = Color.DimGray
        Public Property CircleColor As Color
            Get
                Return m_CircleColor
            End Get
            Set(ByVal value As Color)
                m_CircleColor = value
                Me.Invalidate()
            End Set
        End Property
    Private m_CheckedColor As Color = Color.FromArgb(255, 192, 255, 255)
    Public Property CheckedColor As Color
        Get
            Return m_CheckedColor
        End Get
        Set(ByVal value As Color)
            m_CheckedColor = value
            Me.Invalidate()
        End Set
    End Property

    Public Sub New()
        m_CircleRadius = 8
        m_CircleCheckedRadius = 6
        m_CircleGlintX = 4
        m_CircleGlintY = 4
    End Sub
    Private m_CirCleCheckedX As Integer = 2
    Private m_CirCleCheckedY As Integer = 2
    Public Property CircleCheckedX As Integer
        Get
            Return m_CirCleCheckedX
        End Get
        Set(ByVal value As Integer)
            m_CirCleCheckedX = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CircleCheckedY As Integer
        Get
            Return m_CirCleCheckedY
        End Get
        Set(ByVal value As Integer)
            m_CirCleCheckedY = value
            Me.Invalidate()
        End Set
    End Property

    Private m_CircleGlintSize As Integer = 5
    Private m_CircleGlintX As Integer = 4
    Private m_CircleGlintY As Integer = 4
    Public Property CircleGlintSize As Integer
        Get
            Return m_CircleGlintSize
        End Get
        Set(ByVal value As Integer)
            m_CircleGlintSize = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CircleGlintX As Integer
        Get
            Return m_CircleGlintX
        End Get
        Set(ByVal value As Integer)
            m_CircleGlintX = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CircleGlintY As Integer
        Get
            Return m_CircleGlintY
        End Get
        Set(ByVal value As Integer)
            m_CircleGlintY = value
            Me.Invalidate()
        End Set
    End Property

    Private m_TextOffsetX, m_TextOffsetY As Double
    Public Property TextOffsetX As Double
        Get
            Return m_TextOffsetX
        End Get
        Set(ByVal value As Double)
            m_TextOffsetX = value
            Me.Invalidate()
        End Set
    End Property
    Public Property TextOffsetY As Double
        Get
            Return m_TextOffsetY
        End Get
        Set(ByVal value As Double)
            m_TextOffsetY = value
            Me.Invalidate()
        End Set
    End Property
    Private m_CircleOffsetX, m_CircleOffsetY As Double
    Public Property CircleOffsetX As Double
        Get
            Return m_CircleOffsetX
        End Get
        Set(ByVal value As Double)
            m_CircleOffsetX = value
            Me.Invalidate()
        End Set
    End Property
    Public Property CircleOffsetY As Double
        Get
            Return m_CircleOffsetY
        End Get
        Set(ByVal value As Double)
            m_CircleOffsetY = value
            Me.Invalidate()
        End Set
    End Property
    Protected Overrides Sub OnPaint(ByVal pevent As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(pevent)
        MyBase.OnPaintBackground(pevent)
        Dim g As Graphics = pevent.Graphics
        g.Clear(Me.BackColor)
        Dim sp = g.MeasureString(Me.Text, Me.Font)
        Dim pen As Pen = Nothing
        Dim margin As Integer = CInt(m_CircleWidth / 2)
        pevent.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

        If (Me.Enabled) Then
            pen = New Pen(Me.m_CircleColor, Me.m_CircleWidth)
            g.DrawEllipse(pen, New Rectangle(margin + m_CircleOffsetX, margin + m_CircleOffsetY, m_CircleRadius * 2 - margin, m_CircleRadius * 2 - margin))
            g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), (m_CircleRadius + margin) * 2 + m_TextOffsetX, (m_CircleRadius + margin) - CInt(sp.Height / 2) + m_TextOffsetY)
        Else
            pen = New Pen(Color.Silver, Me.m_CircleWidth)
            g.DrawEllipse(pen, New Rectangle(margin + m_CircleOffsetX, margin + m_CircleOffsetY, m_CircleRadius * 2 - margin, m_CircleRadius * 2 - margin))
            g.DrawString(Me.Text, Me.Font, New SolidBrush(Color.Silver), (m_CircleRadius + margin) * 2 + m_TextOffsetX, (m_CircleRadius + margin) - CInt(sp.Height / 2) + m_TextOffsetY)
        End If
        'g.DrawString(Me.Text, Me.Font, New SolidBrush(Me.ForeColor), (m_CircleRadius + margin) * 2, (m_CircleRadius + margin) - CInt(sp.Height / 2))
        If (Me.Checked) Then
            Dim m_glint = New Rectangle(m_CircleGlintX, m_CircleGlintY, m_CircleGlintSize, m_CircleGlintSize)
            Dim m_outline As Pen = Nothing
            Dim Path As GraphicsPath = New GraphicsPath()
            Path.AddEllipse(m_glint)
            Dim m_flareBrush = New PathGradientBrush(Path)
            m_flareBrush.CenterColor = Color.White
            m_flareBrush.SurroundColors = New Color() {Color.Transparent}
            m_flareBrush.FocusScales = New PointF(0.5F, 0.5F)
            SetStyle(ControlStyles.SupportsTransparentBackColor, True)

            If (Me.Enabled = True) Then
                m_outline = New Pen(New SolidBrush(m_CircleColor), 1.0F)
                g.FillEllipse(New SolidBrush(Me.CheckedColor), New Rectangle(m_CirCleCheckedX, m_CirCleCheckedY, m_CircleCheckedRadius * 2, m_CircleCheckedRadius * 2))
            Else
                m_outline = New Pen(New SolidBrush(Color.Silver))
                g.FillEllipse(New SolidBrush(Color.Silver), New Rectangle(m_CirCleCheckedX, m_CirCleCheckedY, m_CircleCheckedRadius * 2, m_CircleCheckedRadius * 2))
            End If
            g.FillEllipse(m_flareBrush, m_glint)
            g.DrawEllipse(m_outline, New Rectangle(m_CirCleCheckedX, m_CirCleCheckedY, m_CircleCheckedRadius * 2, m_CircleCheckedRadius * 2))
        End If
    End Sub
End Class
    Public Class ProgressBarEx
        Inherits ProgressBar
        Private m_TextShow As String = ""
        <Description("The text show on progress bar")>
        Public Property TextShow As String
            Get
                Return m_TextShow
            End Get
            Set(ByVal value As String)
                m_TextShow = value
                Me.Invalidate()
            End Set
        End Property
        Public Sub New()
            MyBase.New()
            Me.SetStyle(ControlStyles.UserPaint Or ControlStyles.AllPaintingInWmPaint, True)
        End Sub
        Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
            Dim rect As Rectangle = Me.ClientRectangle
            Dim g As Graphics = e.Graphics
            ProgressBarRenderer.DrawHorizontalBar(g, rect)
            If (Value > 0) Then
                Dim clip As Rectangle = New Rectangle(rect.X, rect.Y, CInt(Math.Round(CType((Me.Value / Me.Maximum) * rect.Width, Single))), rect.Height)
                ProgressBarRenderer.DrawHorizontalChunks(g, clip)
            End If
            Using f As Font = New Font(FontFamily.GenericMonospace, 15)
                Dim sizef As SizeF = g.MeasureString(String.Format("{0} ({1}%)", m_TextShow, Me.Value), f)
                Dim location As Point = New Point()
                location.X = CInt((rect.Width / 2) - (sizef.Width / 2))
                location.Y = CInt((rect.Height / 2) - (sizef.Height / 2) + 2)
                g.DrawString(String.Format("{0} ({1}%)", m_TextShow, Me.Value), f, Brushes.DarkBlue, location)
            End Using
        End Sub
    End Class