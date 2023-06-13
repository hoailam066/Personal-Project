Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class FLutTrans
    Private m_CameraIdx As Integer = 0
    Private m_Acquist As CAcquisition
    Private m_cross As VisionSystem.CReticle
    Private m_NoEvent As Boolean = False
    Private m_bgBitmap As Bitmap
    Private m_Graphics As Graphics
    Private gp As GraphicsPath
    Private m_LineSelectIdx As Integer = 1
    Private mp_select As Integer = -1 '選擇方框的指標
    Private dragging As Boolean = False '是否拖曳
    Private pen1 As Pen = New Pen(Color.Blue, 1) '畫方框的筆
    Private m_MovePoint As List(Of CMovePoint) = New List(Of CMovePoint)() '儲存方框的List
    Private mImage As CImage

    Public Sub New(ByRef pAcquist As CAcquisition)
        If m_Acquist Is Nothing Then m_Acquist = pAcquist
        m_cross = New VisionSystem.CReticle
        ' 此為設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        
    End Sub

    Private Sub FLutTrans_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Dim strData As String = ""
        Try
            Call Me.ImageViewer1.StopLive()

            For aryIdx As Integer = 0 To 255
                strData = strData & m_Acquist.LutAry(m_CameraIdx, aryIdx).ToString() & ","
            Next aryIdx
            My.Computer.FileSystem.WriteAllText("D:\DataSettings\LaserSolder\HardWare\LutTrans" & m_CameraIdx & ".txt", strData, False)

            m_Acquist = Nothing
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "FLutTrans->FLutTrans_FormClosed")
        End Try
    End Sub

    Private Sub FLutTrans_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim image As VisionSystem.CImage
        Dim moveP As CMovePoint
        Try
            m_bgBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            m_Graphics = Graphics.FromImage(m_bgBitmap)
            gp = New GraphicsPath()
            For idx As Integer = 1 To 11
                moveP = New CMovePoint(New Point(CInt(0 + (idx - 1) * 25.5), CInt(PictureBox1.Height - (m_Acquist.LutAry(m_CameraIdx, CInt(0 + (idx - 1) * 25.5)))))) '方框的中心，新建立時會自動設定大小
                m_MovePoint.Add(moveP)
            Next idx
            For idx As Integer = 1 To 10
                gp.AddLine(m_MovePoint(idx - 1).p, m_MovePoint(idx).p) '兩個方框中新 畫出一直線
            Next idx
            For idx As Integer = 1 To 11
                gp.AddRectangle(m_MovePoint(idx - 1).rect) '將方框加入
            Next idx
            m_Graphics.DrawPath(pen1, gp) '                                     //將  GraphicPath 畫在畫布
            PictureBox1.BackgroundImage = m_bgBitmap

            Me.ImageViewer1.IsToolShown = True
            image = New VisionSystem.CImage
            Call m_Acquist.Acquist(m_CameraIdx, True)
            Call m_Acquist.CopyTo(m_CameraIdx, image)
            m_cross.X = image.Width / 2
            m_cross.Y = image.Height / 2
            m_cross.Length = image.Width
            Call Me.ImageViewer1.StaticGraphics.Add(m_cross)
            Call Me.ImageViewer1.StartLive(m_CameraIdx, m_Acquist)
            Call image.Dispose() : image = Nothing

            For idx As Integer = 0 To m_Acquist.CameraCount - 1
                cmbCamera.Items.Add("Camera" & idx)
            Next idx
            cmbCamera.SelectedIndex = 0
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "FLutTrans->FLutTrans_Shown")
        End Try
    End Sub

    Private Sub cmbCamera_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbCamera.MouseClick
        Try
            m_CameraIdx = cmbCamera.SelectedIndex
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "FLutTrans->cmbCamera_MouseClick")
        End Try
    End Sub


    Private Sub PictureBox1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseDown
        For i As Integer = 0 To 10
            If (m_MovePoint(i).CheckSelect(e.Location)) Then
                '檢查點選位置是否在某個小框
                mp_select = i '                 //選到的小框編號
                dragging = True '              //有選到  可以拖曳
                Exit For
            End If
        Next
    End Sub

    Private Sub PictureBox1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseUp
        dragging = False
    End Sub

    Private Sub PictureBox1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox1.MouseMove


        If m_NoEvent = False Then
            m_NoEvent = True


            If (dragging) Then
                Call Me.ImageViewer1.StopLive()
                Dim point As Point
                If Not (mp_select = 0 OrElse mp_select = 10) Then
                    point.X = CInt(e.Location.X)
                    If point.X < 0 Then point.X = 0
                    If point.X > 255 Then point.X = 255
                    If point.X < m_MovePoint(mp_select - 1).p.X Then point.X = m_MovePoint(mp_select - 1).p.X + 1
                    If point.X > m_MovePoint(mp_select + 1).p.X Then point.X = m_MovePoint(mp_select + 1).p.X - 1

                    point.Y = CInt(e.Location.Y)
                    If point.Y < 0 Then point.Y = 0
                    If point.Y > 255 Then point.Y = 255
                    m_MovePoint(mp_select).Move(point)
                    Call m_bgBitmap.Dispose()
                    m_bgBitmap = New Bitmap(PictureBox1.Width, PictureBox1.Height)
                    m_Graphics = Graphics.FromImage(m_bgBitmap)
                    gp.Reset()

                    For idx As Integer = 1 To 10
                        gp.AddLine(m_MovePoint(idx - 1).p, m_MovePoint(idx).p) '兩個方框中新 畫出一直線
                    Next

                    For idx As Integer = 1 To 11
                        gp.AddRectangle(m_MovePoint(idx - 1).rect) '將方框加入
                    Next
                    'gp.AddLine(m_MovePoint(0).p, m_MovePoint(1).p)

                    'For Each mpp As CMovePoint In m_MovePoint
                    '    gp.AddRectangle(mpp.rect)
                    'Next

                    m_Graphics.DrawPath(pen1, gp)
                    PictureBox1.BackgroundImage = m_bgBitmap

                    For idx As Integer = 1 To 10
                        For aryIdx As Integer = m_MovePoint(idx - 1).p.X To m_MovePoint(idx).p.X
                            Try
                                m_Acquist.LutAry(m_CameraIdx, aryIdx) = CInt(255 - (m_MovePoint(idx - 1).p.Y + ((m_MovePoint(idx).p.Y - m_MovePoint(idx - 1).p.Y) / (m_MovePoint(idx).p.X - m_MovePoint(idx - 1).p.X) * (aryIdx - m_MovePoint(idx - 1).p.X))))
                            Catch ex As Exception
                            End Try
                        Next aryIdx
                    Next
                End If
                Call Me.ImageViewer1.StartLive(m_CameraIdx, m_Acquist)
            End If
            m_NoEvent = False
        End If
    End Sub
End Class


''' <summary>
''' 會移動的方框
''' </summary>
''' <remarks></remarks>
Friend Class CMovePoint
    ''' <summary>
    ''' 紀錄方框中心的位置
    ''' </summary>
    ''' <remarks></remarks>
    Friend p As Point

    ''' <summary>
    ''' 依中心位置要畫出的筐
    ''' </summary>
    ''' <remarks></remarks>
    Friend rect As Rectangle

    Friend Property Rect1() As Rectangle
        Get
            Return rect
        End Get
        Set(ByVal value As Rectangle)
            rect = value
        End Set
    End Property

    Friend Sub New(ByRef Point As Point)
        p = Point
        rect = New Rectangle(p.X - 3, p.Y - 3, 6, 6)
    End Sub
    ''' <summary>
    ''' 確定是否被選到
    ''' </summary>
    ''' <param name="e"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CheckSelect(ByVal e As Point) As Boolean
        If (rect.Contains(e)) Then
            Return True
        Else
            Return False
        End If
    End Function
    ''' <summary>
    ''' 移動時重繪
    ''' </summary>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Friend Sub Move(ByVal e As Point)
        p = e
        rect = New Rectangle(p.X - 3, p.Y - 3, 6, 6)
    End Sub
End Class