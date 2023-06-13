Imports System.Drawing.Drawing2D

Public Class CRuler
    Private m_Mode As Integer = 1
    Private m_Parent As Control
    Private m_PenWidth As Single = 1.0
    Private m_Color As Color = Color.Green

    ''' <summary>
    ''' Mode 2 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Radius As Single = 30

    ''' <summary>
    ''' Mode 2 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Mode2ResizeLocation As Point

    ''' <summary>
    ''' Mode 3 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Width As Single = 50

    ''' <summary>
    ''' Mode 3 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Height As Single = 50

    ''' <summary>
    ''' Mode 3 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Mode3ResizeLocationLeft As Point

    ''' <summary>
    ''' Mode 3 use
    ''' </summary>
    ''' <remarks></remarks>
    Private m_Mode3ResizeLocationRight As Point

    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
            Try
                For Each ctrl As Control In m_Parent.Controls
                    If (ctrl.GetType() Is GetType(CLine) OrElse ctrl.GetType() Is GetType(CCircle)) Then
                        ctrl.BackColor = m_Color
                    End If
                Next
            Catch ex As Exception
            End Try
        End Set
    End Property

    ''' <summary>
    ''' Mode 2 use. Radius of circle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Radius As Single
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Single)
            m_Radius = value
        End Set
    End Property

    ''' <summary>
    ''' Mode 2 use. Location of circle resize
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Mode2ResizeLocation As Point
        Get
            Return m_Mode2ResizeLocation
        End Get
    End Property

    ''' <summary>
    ''' Mode 3 use. Width of center rectangle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Width As Single
        Get
            Return m_Width
        End Get
        Set(ByVal value As Single)
            m_Width = value
        End Set
    End Property

    ''' <summary>
    ''' Mode 3 use. Height of center rectangle
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Height As Single
        Get
            Return m_Height
        End Get
        Set(ByVal value As Single)
            m_Height = value
        End Set
    End Property

    ''' <summary>
    ''' Mode 3 use. Location of circle resize left
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Mode3ResizeLocationLeft As Point
        Get
            Return m_Mode3ResizeLocationLeft
        End Get
    End Property

    ''' <summary>
    ''' Mode 3 use. Location of circle resize right
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Mode3ResizeLocationRight As Point
        Get
            Return m_Mode3ResizeLocationRight
        End Get
    End Property

    Public Sub New(ByVal pParent As Control, ByVal pMode As Integer)
        m_Parent = pParent
        m_Mode = pMode
        SetValue(m_Mode)
    End Sub

    Private m_Mode2CircleLocation As Point
    Public Sub SetValue(ByVal pMode As Integer)
        'Remove Old Control
        Dim i As Integer = 0
        While i < m_Parent.Controls.Count
            If (m_Parent.Controls(i).GetType() Is GetType(CLine) OrElse m_Parent.Controls(i).GetType() Is GetType(CCircle)) Then
                m_Parent.Controls.Remove(m_Parent.Controls(i))
            Else
                i += 1
            End If
        End While

        Select Case pMode
            Case 1
                Dim HorizontalLine As CLine = New CLine() '--
                HorizontalLine.Name = "Horizontal"
                HorizontalLine.SetValue(m_Parent.Width, m_PenWidth, m_Color)
                m_Parent.Controls.Add(HorizontalLine)
                HorizontalLine.BringToFront()
                HorizontalLine.Location = New Point(0, m_Parent.Height / 2 - m_PenWidth / 2)

                Dim VerticalLine As CLine = New CLine() '|
                VerticalLine.Name = "VerticalLine"
                VerticalLine.SetValue(m_PenWidth, m_Parent.Height, m_Color)
                m_Parent.Controls.Add(VerticalLine)
                VerticalLine.BringToFront()
                VerticalLine.Location = New Point(m_Parent.Width / 2 - m_PenWidth / 2, 0)

            Case 2
                m_Radius = 50
                Dim HorizontalLine As CLine = New CLine() '--
                HorizontalLine.Name = "Horizontal"
                HorizontalLine.SetValue(m_Parent.Width, m_PenWidth, m_Color)
                m_Parent.Controls.Add(HorizontalLine)
                HorizontalLine.BringToFront()
                HorizontalLine.Location = New Point(0, m_Parent.Height / 2 - m_PenWidth / 2)

                Dim VerticalLine As CLine = New CLine() '|
                VerticalLine.Name = "VerticalLine"
                VerticalLine.SetValue(m_PenWidth, m_Parent.Height, m_Color)
                m_Parent.Controls.Add(VerticalLine)
                VerticalLine.BringToFront()
                VerticalLine.Location = New Point(m_Parent.Width / 2 - m_PenWidth / 2, 0)

                Dim Circle As CCircle = New CCircle() 'O
                Circle.Name = "Circle"
                Circle.Location = New Point(m_Parent.Width / 2 - m_Radius, m_Parent.Height / 2 - m_Radius)
                Circle.SetValue(m_Radius, m_PenWidth, m_Color)
                m_Parent.Controls.Add(Circle)
                Circle.BringToFront()
                m_Mode2CircleLocation = Circle.Location

                Dim CircleResize As CCircle = New CCircle() 'O
                CircleResize.Name = "CircleResize"
                CircleResize.SetValue(5, m_PenWidth, m_Color)
                m_Parent.Controls.Add(CircleResize)
                CircleResize.BringToFront()
                CircleResize.Location = New Point(m_Parent.Width / 2.0 + m_Radius - 5.0, m_Parent.Height / 2.0 - 5.0)
                m_Mode2ResizeLocation = CircleResize.Location
                m_Mode2IsClicked = False
                AddHandler HorizontalLine.MouseDown, AddressOf Mode2Horizontal_MouseDown
                AddHandler HorizontalLine.MouseMove, AddressOf Mode2Horizontal_MouseMove
                AddHandler HorizontalLine.MouseUp, AddressOf Mode2Horizontal_MouseUp

                AddHandler Circle.MouseDown, AddressOf Mode2Circle_MouseDown
                AddHandler Circle.MouseMove, AddressOf Mode2Circle_MouseMove
                AddHandler Circle.MouseUp, AddressOf Mode2Circle_MouseUp

                AddHandler CircleResize.MouseDown, AddressOf Mode2Resize_MouseDown
                AddHandler CircleResize.MouseMove, AddressOf Mode2Resize_MouseMove
                AddHandler CircleResize.MouseUp, AddressOf Mode2Resize_MouseUp



            Case 3
                m_Width = 50
                m_Height = 50
                Dim HorizontalLine1 As CLine = New CLine() '--
                HorizontalLine1.Name = "Horizontal1"
                HorizontalLine1.SetValue(m_Parent.Width, m_PenWidth, m_Color)
                m_Parent.Controls.Add(HorizontalLine1)
                HorizontalLine1.BringToFront()
                HorizontalLine1.Location = New Point(0, m_Parent.Height / 2 - m_PenWidth / 2 + m_Height / 2)

                Dim HorizontalLine2 As CLine = New CLine() '--
                HorizontalLine2.Name = "Horizontal2"
                HorizontalLine2.SetValue(m_Parent.Width, m_PenWidth, m_Color)
                m_Parent.Controls.Add(HorizontalLine2)
                HorizontalLine2.BringToFront()
                HorizontalLine2.Location = New Point(0, m_Parent.Height / 2 - m_PenWidth / 2 - m_Height / 2)


                Dim VerticalLine1 As CLine = New CLine() '|
                VerticalLine1.Name = "VerticalLine1"
                VerticalLine1.SetValue(m_PenWidth, m_Parent.Height, m_Color)
                m_Parent.Controls.Add(VerticalLine1)
                VerticalLine1.BringToFront()
                VerticalLine1.Location = New Point(m_Parent.Width / 2 - m_PenWidth / 2 + m_Width / 2, 0)

                Dim VerticalLine2 As CLine = New CLine() '|
                VerticalLine2.Name = "VerticalLine2"
                VerticalLine2.SetValue(m_PenWidth, m_Parent.Height, m_Color)
                m_Parent.Controls.Add(VerticalLine2)
                VerticalLine2.BringToFront()
                VerticalLine2.Location = New Point(m_Parent.Width / 2 - m_PenWidth / 2 - m_Width / 2, 0)

                Dim CircleResizeRight As CCircle = New CCircle() 'O
                CircleResizeRight.Name = "CircleResizeRight"
                CircleResizeRight.SetValue(5, m_PenWidth, m_Color)
                m_Parent.Controls.Add(CircleResizeRight)
                CircleResizeRight.BringToFront()
                CircleResizeRight.Location = New Point(m_Parent.Width / 2.0 + m_Width / 2 - 5.0, m_Parent.Height / 2.0 - m_Height / 2 - 5.0)
                m_Mode3ResizeLocationRight = CircleResizeRight.Location

                Dim CircleResizeLeft As CCircle = New CCircle() 'O
                CircleResizeLeft.Name = "CircleResizeLeft"
                CircleResizeLeft.SetValue(5, m_PenWidth, m_Color)
                m_Parent.Controls.Add(CircleResizeLeft)
                CircleResizeLeft.BringToFront()
                CircleResizeLeft.Location = New Point(m_Parent.Width / 2.0 - m_Width / 2 - 5.0, m_Parent.Height / 2.0 + m_Height / 2 - 5.0)
                m_Mode3ResizeLocationLeft = CircleResizeLeft.Location

                m_Mode3IsClicked = False

                AddHandler HorizontalLine1.MouseDown, AddressOf Mode3HLeft_MouseDown
                AddHandler HorizontalLine1.MouseMove, AddressOf Mode3HLeft_MouseMove
                AddHandler HorizontalLine1.MouseUp, AddressOf Mode3HLeft_MouseUp

                AddHandler HorizontalLine2.MouseDown, AddressOf Mode3HRight_MouseDown
                AddHandler HorizontalLine2.MouseMove, AddressOf Mode3HRight_MouseMove
                AddHandler HorizontalLine2.MouseUp, AddressOf Mode3HRight_MouseUp

                AddHandler VerticalLine1.MouseDown, AddressOf Mode3VRight_MouseDown
                AddHandler VerticalLine1.MouseMove, AddressOf Mode3VRight_MouseMove
                AddHandler VerticalLine1.MouseUp, AddressOf Mode3VRight_MouseUp

                AddHandler VerticalLine2.MouseDown, AddressOf Mode3VLeft_MouseDown
                AddHandler VerticalLine2.MouseMove, AddressOf Mode3VLeft_MouseMove
                AddHandler VerticalLine2.MouseUp, AddressOf Mode3VLeft_MouseUp

                AddHandler CircleResizeLeft.MouseDown, AddressOf Mode3ResizeLeft_MouseDown
                AddHandler CircleResizeLeft.MouseMove, AddressOf Mode3ResizeLeft_MouseMove
                AddHandler CircleResizeLeft.MouseUp, AddressOf Mode3ResizeLeft_MouseUp


                AddHandler CircleResizeRight.MouseDown, AddressOf Mode3ResizeRight_MouseDown
                AddHandler CircleResizeRight.MouseMove, AddressOf Mode3ResizeRight_MouseMove
                AddHandler CircleResizeRight.MouseUp, AddressOf Mode3ResizeRight_MouseUp


            Case Else

        End Select
    End Sub

#Region "Mode 2 use"
    Public Sub UpdateRadius()
        Try
            Dim CircleResize As Control = m_Parent.Controls.Find("CircleResize", False)(0)
            CircleResize.Location = New Point(m_Parent.Width / 2.0 + m_Radius - 5.0, m_Parent.Height / 2.0 - 5.0)
            m_Mode2ResizeLocation = CircleResize.Location

            Dim Circle As CCircle = m_Parent.Controls.Find("Circle", False)(0)
            Circle.Location = New Point(m_Parent.Width / 2 - m_Radius, m_Parent.Height / 2 - m_Radius)
            Circle.SetValue(m_Radius, m_PenWidth, m_Color)
            m_Mode2CircleLocation = Circle.Location
        Catch ex As Exception

        End Try
    End Sub

    Private m_Mode2IsClicked As Boolean = False
    Private m_Mode2ClickPoint As Point
    Private Sub Mode2Resize_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = True
        m_Mode2ClickPoint = e.Location
    End Sub

    Private Sub Mode2Resize_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode2IsClicked = True) Then
            If (e.X <> m_Mode2ClickPoint.X) Then
                Dim newRadius As Single = Me.Radius + (e.X - m_Mode2ClickPoint.X)
                If (newRadius > 1 AndAlso newRadius < m_Parent.Width / 2) Then
                    Me.Radius = newRadius
                    Me.UpdateRadius()
                    m_Mode2ClickPoint = e.Location
                End If
            End If
        End If
    End Sub

    Private Sub Mode2Resize_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = False
    End Sub



    Private Sub Mode2Horizontal_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = True
        m_Mode2ClickPoint = e.Location
    End Sub

    Private Sub Mode2Horizontal_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode2IsClicked = True) Then
            If (Me.Mode2ResizeLocation.X - 1 <= m_Mode2ClickPoint.X AndAlso m_Mode2ClickPoint.X <= Me.Mode2ResizeLocation.X + 10) Then
                If (e.X <> m_Mode2ClickPoint.X) Then
                    Dim newRadius As Single = Me.Radius + (e.X - m_Mode2ClickPoint.X)
                    If (newRadius > 1 AndAlso newRadius < m_Parent.Width / 2) Then
                        Me.Radius = newRadius
                        Me.UpdateRadius()
                        m_Mode2ClickPoint = e.Location
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Mode2Horizontal_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = False
    End Sub

    Private Sub Mode2Circle_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = True
        m_Mode2ClickPoint = e.Location
    End Sub

    Private Sub Mode2Circle_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode2IsClicked = True) Then
            If (2 * Radius - 5 <= m_Mode2ClickPoint.X AndAlso m_Mode2ClickPoint.X <= 2 * Radius + 5 AndAlso Radius - 5 <= e.Y AndAlso e.Y <= Radius + 5) Then
                If (e.X <> m_Mode2ClickPoint.X) Then
                    Dim newRadius As Single = Me.Radius + (e.X - m_Mode2ClickPoint.X)
                    If (newRadius >= 1 AndAlso newRadius <= m_Parent.Width / 2) Then
                        Me.Radius = newRadius
                        Me.UpdateRadius()
                        m_Mode2ClickPoint = New Point(e.X + (e.X - m_Mode2ClickPoint.X), e.Y)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub Mode2Circle_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode2IsClicked = False
    End Sub

#End Region




#Region "Mode 3 use"
    Public Sub UpdateRectangle(ByVal pLeft As Boolean, ByVal pNewWidth As Single, ByVal pNewHeight As Single)
        Try
            If (pLeft = True) Then
                Dim HorizontalLine1 As CLine = m_Parent.Controls.Find("Horizontal1", False)(0) '--
                Dim HorizontalLine2 As CLine = m_Parent.Controls.Find("Horizontal2", False)(0) '--
                Dim VerticalLine1 As CLine = m_Parent.Controls.Find("VerticalLine1", False)(0) '|
                Dim VerticalLine2 As CLine = m_Parent.Controls.Find("VerticalLine2", False)(0) '|
                Dim CircleResizeLeft As CCircle = m_Parent.Controls.Find("CircleResizeLeft", False)(0) 'O
                If (pNewWidth > m_Width) Then
                    Dim dix As Integer = pNewWidth - m_Width
                    If (VerticalLine2.Location.X - dix < VerticalLine1.Location.X - 1) Then
                        VerticalLine2.Location = New Point(VerticalLine2.Location.X - dix, 0)
                    End If
                Else
                    Dim dix As Integer = m_Width - pNewWidth
                    If (VerticalLine2.Location.X + dix < VerticalLine1.Location.X - 1) Then
                        VerticalLine2.Location = New Point(VerticalLine2.Location.X + dix, 0)
                    End If
                End If
                m_Mode3ResizeLocationLeft.X = VerticalLine2.Location.X - 5
                If (pNewHeight > m_Height) Then
                    Dim dix As Integer = pNewHeight - m_Height
                    If (HorizontalLine1.Location.Y - dix > HorizontalLine2.Location.Y + 1) Then
                        HorizontalLine1.Location = New Point(0, HorizontalLine1.Location.Y - dix)
                    End If
                Else
                    Dim dix As Integer = m_Height - pNewHeight
                    If (HorizontalLine1.Location.Y + dix > HorizontalLine2.Location.Y + 1) Then
                        HorizontalLine1.Location = New Point(0, HorizontalLine1.Location.Y + dix)
                    End If
                End If
                m_Mode3ResizeLocationLeft.Y = HorizontalLine1.Location.Y - 5
                m_Width = pNewWidth
                m_Height = pNewHeight
                CircleResizeLeft.Location = m_Mode3ResizeLocationLeft

            Else
                Dim HorizontalLine1 As CLine = m_Parent.Controls.Find("Horizontal1", False)(0) '--
                Dim HorizontalLine2 As CLine = m_Parent.Controls.Find("Horizontal2", False)(0) '--
                Dim VerticalLine1 As CLine = m_Parent.Controls.Find("VerticalLine1", False)(0) '|
                Dim VerticalLine2 As CLine = m_Parent.Controls.Find("VerticalLine2", False)(0) '|
                Dim CircleResizeRight As CCircle = m_Parent.Controls.Find("CircleResizeRight", False)(0) 'O

                If (pNewWidth > m_Width) Then
                    Dim dix As Integer = pNewWidth - m_Width
                    If (VerticalLine1.Location.X + dix <= m_Parent.Width) Then
                        VerticalLine1.Location = New Point(VerticalLine1.Location.X + dix, 0)
                    End If
                Else
                    Dim dix As Integer = m_Width - pNewWidth
                    If (VerticalLine1.Location.X - dix > VerticalLine2.Location.X + 1) Then
                        VerticalLine1.Location = New Point(VerticalLine1.Location.X - dix, 0)
                    End If
                End If

                m_Mode3ResizeLocationRight.X = VerticalLine1.Location.X - 5
                If (pNewHeight > m_Height) Then
                    Dim dix As Integer = pNewHeight - m_Height
                    If (HorizontalLine2.Location.Y + dix < HorizontalLine1.Location.Y - 1) Then
                        HorizontalLine2.Location = New Point(0, HorizontalLine2.Location.Y + dix)
                    End If
                Else
                    Dim dix As Integer = m_Height - pNewHeight
                    If (HorizontalLine2.Location.Y - dix < HorizontalLine1.Location.Y - 1) Then
                        HorizontalLine2.Location = New Point(0, HorizontalLine2.Location.Y - dix)
                    End If
                End If
                m_Mode3ResizeLocationRight.Y = HorizontalLine2.Location.Y - 5
                m_Width = pNewWidth
                m_Height = pNewHeight
                CircleResizeRight.Location = m_Mode3ResizeLocationRight

            End If

        Catch ex As Exception

        End Try
    End Sub

    Private m_Mode3IsClicked As Boolean = False
    Private m_Mode3ClickPoint As Point
    Private Sub Mode3ResizeLeft_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3ResizeLeft_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                Dim newWidth As Single = Me.Width - (e.X - m_Mode3ClickPoint.X)
                Dim newHeight As Single = Me.Height - (e.Y - m_Mode3ClickPoint.Y)
                Me.UpdateRectangle(True, newWidth, newHeight)
                m_Mode3ClickPoint = e.Location
            End If
        End If
    End Sub

    Private Sub Mode3ResizeLeft_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub

    Private Sub Mode3ResizeRight_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3ResizeRight_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                Dim newWidth As Single = Me.Width + (e.X - m_Mode3ClickPoint.X)
                Dim newHeight As Single = Me.Height + (e.Y - m_Mode3ClickPoint.Y)
                Me.UpdateRectangle(False, newWidth, newHeight)
                m_Mode3ClickPoint = e.Location
            End If
        End If
    End Sub

    Private Sub Mode3ResizeRight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub

    Private Sub Mode3HRight_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3HRight_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (m_Mode3ResizeLocationRight.X - 1 <= e.X AndAlso e.X <= m_Mode3ResizeLocationRight.X + 10) Then
                If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                    Dim newWidth As Single = Me.Width + (e.X - m_Mode3ClickPoint.X)
                    Dim newHeight As Single = Me.Height + (e.Y - m_Mode3ClickPoint.Y)
                    Me.UpdateRectangle(False, newWidth, newHeight)
                    m_Mode3ClickPoint = e.Location
                End If
            End If
        End If
    End Sub

    Private Sub Mode3HRight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub

    Private Sub Mode3VRight_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3VRight_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (m_Mode3ResizeLocationRight.Y - 1 <= e.Y AndAlso e.Y <= m_Mode3ResizeLocationRight.Y + 10) Then
                If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                    Dim newWidth As Single = Me.Width + (e.X - m_Mode3ClickPoint.X)
                    Dim newHeight As Single = Me.Height + (e.Y - m_Mode3ClickPoint.Y)
                    Me.UpdateRectangle(False, newWidth, newHeight)
                    m_Mode3ClickPoint = e.Location
                End If
            End If
        End If
    End Sub

    Private Sub Mode3VRight_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub

    Private Sub Mode3HLeft_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3HLeft_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (m_Mode3ResizeLocationLeft.X - 1 <= e.X AndAlso e.X <= m_Mode3ResizeLocationLeft.X + 10) Then
                If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                    Dim newWidth As Single = Me.Width - (e.X - m_Mode3ClickPoint.X)
                    Dim newHeight As Single = Me.Height - (e.Y - m_Mode3ClickPoint.Y)
                    Me.UpdateRectangle(True, newWidth, newHeight)
                    m_Mode3ClickPoint = e.Location
                End If
            End If
        End If
    End Sub

    Private Sub Mode3HLeft_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub

    Private Sub Mode3VLeft_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = True
        m_Mode3ClickPoint = e.Location
    End Sub

    Private Sub Mode3VLeft_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (m_Mode3IsClicked = True) Then
            If (m_Mode3ResizeLocationLeft.Y - 1 <= e.Y AndAlso e.Y <= m_Mode3ResizeLocationLeft.Y + 10) Then
                If (e.X <> m_Mode3ClickPoint.X OrElse e.Y <> m_Mode3ClickPoint.Y) Then
                    Dim newWidth As Single = Me.Width - (e.X - m_Mode3ClickPoint.X)
                    Dim newHeight As Single = Me.Height - (e.Y - m_Mode3ClickPoint.Y)
                    Me.UpdateRectangle(True, newWidth, newHeight)
                    m_Mode3ClickPoint = e.Location
                End If
            End If
        End If
    End Sub

    Private Sub Mode3VLeft_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_Mode3IsClicked = False
    End Sub
#End Region
End Class

Public Class CLine
    Inherits Panel
    Private m_Width As Single
    Private m_Height As Single
    Private m_Color As Color

    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
            Me.BackColor = value
        End Set
    End Property
    Public Sub SetValue(Optional ByVal pWidth As Single = -1, Optional ByVal pHeight As Single = -1, Optional ByVal pColor As Color = Nothing)
        If (pWidth > 0) Then
            Me.Width = pWidth
        End If
        If (pHeight > 0) Then
            Me.Height = pHeight
        End If
        If (pColor <> Nothing) Then
            Me.Color = pColor
        End If
        UpdateData()
    End Sub

    Protected Sub UpdateData()
        Try
            Me.Visible = False
            If Me.Region IsNot Nothing Then Me.Region.Dispose()
            Me.Region = Nothing
            Dim gPath As GraphicsPath = New GraphicsPath()
            gPath.FillMode = FillMode.Alternate
            gPath.AddRectangle(New RectangleF(0, 0, Me.Width, Me.Height))
            Me.Region = New Region(gPath)
            Me.BackColor = Me.Color
            Me.Invalidate()
            Me.Visible = True
        Catch ex As Exception

        End Try
    End Sub

End Class

Public Class CCircle
    Inherits Panel
    Private m_Radius As Single
    Private m_PenWidth As Single
    Private m_Color As Color
    Public Overloads Property Radius As Single
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Single)
            m_Radius = value
        End Set
    End Property
    Public Overloads Property PenWidth As Single
        Get
            Return m_PenWidth
        End Get
        Set(ByVal value As Single)
            m_PenWidth = value
        End Set
    End Property

    Public Property Color As Color
        Get
            Return m_Color
        End Get
        Set(ByVal value As Color)
            m_Color = value
            Me.BackColor = value
        End Set
    End Property
    Public Sub SetValue(Optional ByVal pRadius As Single = -1, Optional ByVal pPenWidth As Single = -1, Optional ByVal pColor As Color = Nothing)
        If (pRadius > 0) Then
            Me.Radius = pRadius
        End If
        If (pPenWidth > 0) Then
            Me.PenWidth = pPenWidth
        End If
        If (pColor <> Nothing) Then
            Me.Color = pColor
        End If
        Me.Size = New Size(pRadius * 2, pRadius * 2)
        UpdateData()
    End Sub

    Private Sub UpdateData()
        Try
            Me.Visible = False
            If Me.Region IsNot Nothing Then Me.Region.Dispose()
            Me.Region = Nothing
            Dim gPath As GraphicsPath = New GraphicsPath()
            gPath.AddEllipse(New RectangleF(0, 0, Me.Radius * 2, Me.Radius * 2))
            gPath.CloseFigure()
            gPath.AddEllipse(New RectangleF(m_PenWidth, m_PenWidth, Me.Radius * 2 - 2 * Me.PenWidth, Me.Radius * 2 - 2 * m_PenWidth))
            gPath.CloseFigure()
            Me.Region = New Region(gPath)
            Me.BackColor = Me.Color
            gPath.Dispose()
            Me.Visible = True
        Catch ex As Exception

        End Try
    End Sub

End Class