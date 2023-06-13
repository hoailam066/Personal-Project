Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class CListLine
    Private m_lstLine As New List(Of CLine)
    Private m_lstLineCtrl As New List(Of CLineCtrl)
    Private m_Parent As Control
    Private m_Busy As Boolean = False
    Private m_Color As Color
    Public WriteOnly Property Busy As Boolean
        Set(ByVal value As Boolean)
            m_Busy = value
        End Set
    End Property
    Public Property Parent As Control
        Get
            Return m_Parent
        End Get
        Set(ByVal value As Control)
            If (m_Parent IsNot Nothing AndAlso m_lstLineCtrl IsNot Nothing AndAlso m_lstLineCtrl.Count > 0) Then
                For i = 0 To m_lstLine.Count - 1
                    m_Parent.Controls.Remove(m_lstLineCtrl(i))
                Next
            End If
            m_Parent = value
            If (m_Busy = False) Then
                CreateListLines()
            End If
        End Set
    End Property
    Public Property ListLine As List(Of CLine)
        Get
            Return m_lstLine
        End Get
        Set(ByVal value As List(Of CLine))
            For i = 0 To m_lstLineCtrl.Count - 1
                m_Parent.Controls.Remove(m_lstLineCtrl(i))
            Next
            m_lstLine = value
            CreateListLines()
        End Set
    End Property
    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
            CreateListLines()
        End Set
    End Property
    Public Sub CreateListLines()

        For i = 0 To m_lstLineCtrl.Count - 1
            m_Parent.Controls.Remove(m_lstLineCtrl(i))
        Next

        m_lstLineCtrl.Clear()


        For i = 0 To m_lstLine.Count - 1
            Dim linectr As CLineCtrl = New CLineCtrl(m_Parent.Size, m_lstLine(i).StartX, m_lstLine(i).StartY, m_lstLine(i).EndX, m_lstLine(i).EndY, m_Color, m_lstLine(i).IsSelected)
            linectr.Name = "LINE" & i.ToString()
            m_lstLineCtrl.Add(linectr)
        Next

        m_Parent.Controls.AddRange(m_lstLineCtrl.ToArray)
        ShowListLine()
    End Sub

    Public Sub Dispose()
        For i = 0 To m_lstLineCtrl.Count - 1
            m_lstLineCtrl(i).Dispose()
        Next
    End Sub

    Public Sub ShowListLine()
        For i = 0 To m_lstLineCtrl.Count - 1
            m_lstLineCtrl(i).BringToFront()
        Next
    End Sub
End Class


Public MustInherit Class CControlObject
    Inherits Panel
    Protected m_PenWidth As Single = 2
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
    Public Sub New()

    End Sub
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
End Class

Public Class CLineCtrl
    Inherits Panel
    Private m_StartX As Double = 0
    Private m_StartY As Double = 0
    Private m_EndX As Double = 0
    Private m_EndY As Double = 0
    Protected m_PenWidth As Single = 2
    Protected m_bmp As Bitmap = Nothing
    Protected m_Color As Drawing.Color = Drawing.Color.Red

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
    Public Property StartX As Double
        Get
            Return m_StartX / FMain.VisionToViewScaleW
        End Get
        Set(ByVal value As Double)
            m_StartX = value * FMain.VisionToViewScaleW
            UpdateData()
        End Set
    End Property
    Public Property StartY As Double
        Get
            Return m_StartY / FMain.VisionToViewScaleH
        End Get
        Set(ByVal value As Double)
            m_StartY = value * FMain.VisionToViewScaleH
            UpdateData()
        End Set
    End Property
    Public Property EndX As Double
        Get
            Return m_EndX / FMain.VisionToViewScaleW
        End Get
        Set(ByVal value As Double)
            m_EndX = value * FMain.VisionToViewScaleW
            UpdateData()
        End Set
    End Property
    Public Property EndY As Double
        Get
            Return m_EndY / FMain.VisionToViewScaleH
        End Get
        Set(ByVal value As Double)
            m_EndY = value * FMain.VisionToViewScaleH
            UpdateData()
        End Set
    End Property

    Private m_IsSelected As Boolean = False
    Public Property IsSelect As Boolean
        Get
            Return m_IsSelected
        End Get
        Set(ByVal value As Boolean)
            m_IsSelected = value
            UpdateData()
        End Set
    End Property
    Private m_Line As CLine
    Public Property Line As CLine
        Get
            Return m_Line
        End Get
        Set(ByVal value As CLine)
            m_Line = value
            Me.m_StartX = m_Line.StartXPX * FMain.VisionToViewScaleW
            Me.m_StartY = m_Line.StartYPX * FMain.VisionToViewScaleH
            Me.m_EndX = m_Line.EndXPX * FMain.VisionToViewScaleW
            Me.m_EndY = m_Line.EndYPX * FMain.VisionToViewScaleH
            'Me.m_IsSelected = m_Line.IsSelected
            UpdateData()
        End Set
    End Property

    Public PointSize As Integer = 3
    Public PointLength As Integer = 15

    Public Sub New(ByVal pSize As Size, ByVal pStartX As Double, ByVal pStartY As Double, ByVal pEndX As Double, ByVal pEndY As Double, ByVal pColor As Drawing.Color, Optional ByVal pIsSelect As Boolean = False)
        Me.m_StartX = pStartX * FMain.VisionToViewScaleW
        Me.m_StartY = pStartY * FMain.VisionToViewScaleH
        Me.m_EndX = pEndX * FMain.VisionToViewScaleW
        Me.m_EndY = pEndY * FMain.VisionToViewScaleH
        Me.m_IsSelected = pIsSelect
        Me.Size = pSize
        Me.Top = 0
        Me.Left = 0
        Me.Color = pColor
        UpdateData()
    End Sub

    Protected Function GetRegion(ByVal bmp As Bitmap, ByVal startX As Integer, ByVal endX As Integer, ByVal startY As Integer, ByVal endY As Integer, ByVal color As Color) As GraphicsPath
        Dim gPath As GraphicsPath = New GraphicsPath()
        gPath.FillMode = FillMode.Winding
        Dim bmData As BitmapData = Nothing
        Try
            bmData = bmp.LockBits(New Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.[ReadOnly], PixelFormat.Format32bppArgb)
            Dim stride As Integer = bmData.Stride

            For y As Integer = startY To endY - 1

                For x As Integer = startX To endX - 1
                    Dim b As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4)
                    Dim g As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 1)
                    Dim r As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 2)
                    Dim a As Integer = Marshal.ReadByte(bmData.Scan0, y * bmData.Stride + x * 4 + 3)
                    If color.FromArgb(a, r, g, b).Equals(color.FromArgb(color.ToArgb())) = True Then
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


    Protected Sub UpdateData()
        If (Me.Visible = False) Then
            Exit Sub
        End If
        Me.Visible = False
        If Me.Region IsNot Nothing Then Me.Region.Dispose()
        Me.Region = Nothing

        If m_bmp IsNot Nothing Then
            m_bmp.Dispose()
            m_bmp = Nothing
        End If
        Dim pen As Pen
        If (IsSelect) Then
            pen = New Pen(Drawing.Color.Red, Me.m_PenWidth)
        Else
            pen = New Pen(Me.m_Color, Me.m_PenWidth)
        End If
        Dim bigArrow As AdjustableArrowCap = New AdjustableArrowCap(5, 5)
        bigArrow.Filled = False
        pen.CustomEndCap = bigArrow
        m_bmp = New Bitmap(Me.ClientSize.Width, Me.ClientSize.Height)
        Dim g As Graphics = Graphics.FromImage(m_bmp)
        g.Clear(Color.Black)
        g.SmoothingMode = SmoothingMode.AntiAlias
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawLine(pen, New PointF(m_StartX, m_StartY), New PointF(m_EndX, m_EndY))

        Dim minX, maxX, minY, maxY As Double
        Dim OutSize As Integer = 5
        minX = IIf(m_StartX - OutSize < m_EndX - OutSize, m_StartX - OutSize, m_EndX - OutSize)
        maxX = IIf(m_StartX + OutSize > m_EndX + OutSize, m_StartX + OutSize, m_EndX + OutSize)
        minY = IIf(m_StartY - OutSize < m_EndY - OutSize, m_StartY - OutSize, m_EndY - OutSize)
        maxY = IIf(m_StartY + OutSize > m_EndY + OutSize, m_StartY + OutSize, m_EndY + OutSize)

        If (minX < 0) Then
            minX = 0
        End If
        If (minY < 0) Then
            minY = 0
        End If
        If (maxX < 0) Then
            maxX = 0
        End If
        If (maxY < 0) Then
            maxY = 0
        End If


        Dim gPath As GraphicsPath = GetRegion(m_bmp, minX, maxX, minY, maxY, pen.Color)
        Me.Region = New Region(gPath)
        If (IsSelect) Then
            Me.BackColor = Drawing.Color.Red
        Else
            Me.BackColor = Me.m_Color
        End If
        Me.Invalidate()
        Me.Visible = True
        pen.Dispose()
        bigArrow.Dispose()
        g.Dispose()
        m_bmp.Dispose()
        GC.Collect()
    End Sub

    'Protected Sub UpdateData()
    '    If (Me.Visible = False) Then
    '        Exit Sub
    '    End If
    '    Me.Visible = False
    '    If Me.Region IsNot Nothing Then Me.Region.Dispose()
    '    Me.Region = Nothing

    '    Dim gPath As GraphicsPath = New GraphicsPath()
    '    gPath.FillMode = FillMode.Winding
    '    Dim p1, p2, p3, p4 As PointF
    '    If (m_StartX = m_EndX) Then
    '        p1 = New PointF(StartX - PenWidth / 2, StartY)
    '        p2 = New PointF(EndX - PenWidth / 2, EndY)
    '        p3 = New PointF(EndX + m_PenWidth / 2, EndY)
    '        p4 = New PointF(StartX + m_PenWidth / 2, StartY)

    '    ElseIf (m_StartY = m_EndY) Then
    '        p1 = New PointF(StartX, StartY - PenWidth / 2)
    '        p2 = New PointF(EndX, EndY - PenWidth / 2)
    '        p3 = New PointF(EndX, EndY + m_PenWidth / 2)
    '        p4 = New PointF(StartX, StartY + m_PenWidth / 2)

    '    Else
    '        Dim deltaX As Double = Math.Abs(EndX - StartX)
    '        Dim deltaY As Integer = Math.Abs(EndY - StartY)

    '        If (deltaX < deltaY) Then
    '            p1 = New PointF(StartX - m_PenWidth / 2, StartY)
    '            p2 = New PointF(EndX - m_PenWidth / 2, EndY)
    '            p3 = New PointF(EndX + m_PenWidth / 2, EndY)
    '            p4 = New PointF(StartX + m_PenWidth / 2, StartY)
    '        Else
    '            p1 = New PointF(StartX, StartY - m_PenWidth / 2)
    '            p2 = New PointF(EndX, EndY - m_PenWidth / 2)
    '            p3 = New PointF(EndX, EndY + m_PenWidth / 2)
    '            p4 = New PointF(StartX, StartY + m_PenWidth / 2)
    '        End If
    '    End If

    '    gPath.AddLines(New PointF() {p1, p2, p3, p4})

    '    If (IsSelect) Then
    '        Me.BackColor = Drawing.Color.Red
    '    Else
    '        Me.BackColor = m_Color
    '    End If

    '    Me.Region = New Region(gPath)
    '    Me.Invalidate()
    '    Me.Visible = True
    '    GC.Collect()
    'End Sub

    
End Class
