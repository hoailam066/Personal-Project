Imports System.IO
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

Public Class FMain
    Private m_SelectedMode As Integer = 0
    Private m_Ruler As CRuler
    Public m_Acquist As VisionSystem.CAcquisition
    Private m_ImageWidth As Single
    Private m_ImageHeight As Single
    Private m_TmpImage As VisionSystem.CImage
    Private m_IsConnected As Boolean = False
    Private Sub chkMode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMode1.Click, chkMode2.Click, chkMode3.Click
        m_SelectedMode = 0
        If (sender Is chkMode1) Then
            If (chkMode1.Checked = True) Then
                chkMode2.Checked = False
                chkMode3.Checked = False
                chkMode1.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode1_2
                chkMode2.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode2_1
                chkMode3.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode3_1
                m_SelectedMode = 1
            Else
                chkMode1.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode1_1
            End If
        ElseIf (sender Is chkMode2) Then
            If (chkMode2.Checked = True) Then
                chkMode1.Checked = False
                chkMode3.Checked = False
                chkMode2.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode2_2
                chkMode1.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode1_1
                chkMode3.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode3_1
                m_SelectedMode = 2
            Else
                chkMode2.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode2_1
            End If

        ElseIf (sender Is chkMode3) Then
            If (chkMode3.Checked = True) Then
                chkMode1.Checked = False
                chkMode2.Checked = False
                chkMode3.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode3_2
                chkMode1.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode1_1
                chkMode2.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode2_1
                m_SelectedMode = 3
            Else
                chkMode3.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode3_1
            End If
        End If
        ChangeViewMode()
    End Sub

    Private Sub ChangeViewMode()
        Try
            Select Case m_SelectedMode
                Case 0
                    Dim i As Integer = 0
                    While i < grbCamera.Controls.Count
                        If (grbCamera.Controls(i).GetType() Is GetType(CLine) OrElse grbCamera.Controls(i).GetType() Is GetType(CCircle)) Then
                            grbCamera.Controls.Remove(grbCamera.Controls(i))
                        Else
                            i += 1
                        End If
                    End While
                Case Else
                    m_Ruler.SetValue(m_SelectedMode)

            End Select
        Catch ex As Exception

        End Try
    End Sub
    Dim m_TmpPath As String
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Me.Visible = False
            m_Ruler = New CRuler(grbCamera, 0)
            m_Acquist = New VisionSystem.CAcquisition(0)
            Call m_Acquist.Acquist(0, True)
            Dim img As VisionSystem.CImage = Nothing
            m_Acquist.CopyTo(0, img)
            m_ImageWidth = img.Width
            m_ImageHeight = img.Height
            img.Dispose()
            img = Nothing
            Dim bmp As Bitmap = New Bitmap(CInt(m_ImageWidth), CInt(m_ImageHeight))
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.Black)
            Dim font As Font = New Font("Arial", 15, FontStyle.Bold)
            Dim MS As SizeF = g.MeasureString("--- Disconnected from the camera ! ---", font)
            g.DrawString("--- Disconnected from the camera ! ---", font, Brushes.White, (m_ImageWidth - MS.Width) / 2, (m_ImageHeight - MS.Height) / 2)

            m_TmpPath = Path.Combine(Path.GetTempPath(), "CameraViewer" & "\tmp\")
            Dim pFile As String = "IMG_TMP.bmp"
            If (Directory.Exists(m_TmpPath)) Then
                Directory.Delete(m_TmpPath, True)
            End If
            Directory.CreateDirectory(m_TmpPath)
            bmp.Save(m_TmpPath & pFile, System.Drawing.Imaging.ImageFormat.Bmp)
            bmp.Dispose()
            g.Dispose()
            font.Dispose()
            g = Nothing
            font = Nothing
            bmp = Nothing
            m_TmpImage = New VisionSystem.CImage()
            m_TmpImage.ReadImage(m_TmpPath & pFile)

            ImageDisplay1.StopLive()
            ChangeSize()
            btnConnect.BackColor = Color.Transparent
            btnDisConnect.BackColor = Color.Red
            Me.Visible = True
            AddHandler Me.SizeChanged, AddressOf FMain_SizeChanged
            Me.WindowState = FormWindowState.Maximized
            ImageDisplay1.CopyOf(m_TmpImage)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Environment.Exit(0)
        End Try
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        Try
            If (m_IsConnected = False) Then
                ImageDisplay1.StartLive(0, m_Acquist)
                m_IsConnected = True
                btnConnect.BackColor = Color.LimeGreen
                btnDisConnect.BackColor = Color.Transparent
                m_Count = 0
                Timer1.Start()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDisConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisConnect.Click
        Try
            If (m_IsConnected = True) Then
                ImageDisplay1.StopLive()
                ImageDisplay1.CopyOf(m_TmpImage)
                m_IsConnected = False
                btnConnect.BackColor = Color.Transparent
                btnDisConnect.BackColor = Color.Red
                Timer1.Stop()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If (Directory.Exists(m_TmpPath)) Then
                Directory.Delete(m_TmpPath, True)
            End If
            Call Me.ImageDisplay1.StopLive()
        Catch ex As Exception

        End Try
    End Sub



    Private m_IsClicked As Boolean = False
    Private m_ClickPoint As PointF = New PointF(0, 0)
    Private Sub ImageDisplay1_ImageDisplay_MouseMove(ByVal X As System.Double, ByVal Y As System.Double) Handles ImageDisplay1.ImageDisplay_MouseMove
        Dim newX As Single = X * ImageDisplay1.Width / m_ImageWidth
        Dim newY As Single = Y * ImageDisplay1.Height / m_ImageHeight
        If (m_IsClicked = True) Then
            Select Case m_SelectedMode
                Case 2
                    If (m_Ruler.Mode2ResizeLocation.X - 1 <= m_ClickPoint.X AndAlso m_ClickPoint.X <= m_Ruler.Mode2ResizeLocation.X + 10) Then
                        If (newX <> m_ClickPoint.X) Then
                            Dim newRadius As Single = m_Ruler.Radius + (newX - m_ClickPoint.X)
                            If (newRadius > 1 AndAlso newRadius < grbCamera.Width / 2) Then
                                m_Ruler.Radius = newRadius
                                m_Ruler.UpdateRadius()
                                m_ClickPoint = New PointF(newX, newY)
                            End If
                        End If
                    End If
                Case 3
                    If (m_Ruler.Mode3ResizeLocationLeft.X - 1 <= m_ClickPoint.X AndAlso m_ClickPoint.X <= m_Ruler.Mode3ResizeLocationLeft.X + 10 AndAlso m_Ruler.Mode3ResizeLocationLeft.Y - 10 <= m_ClickPoint.Y AndAlso m_ClickPoint.Y <= m_Ruler.Mode3ResizeLocationLeft.Y + 10) Then
                        If (newX <> m_ClickPoint.X OrElse newY <> m_ClickPoint.Y) Then
                            Dim newWidth As Single = m_Ruler.Width - (newX - m_ClickPoint.X)
                            Dim newHeight As Single = m_Ruler.Height - (newY - m_ClickPoint.Y)
                            m_Ruler.UpdateRectangle(True, newWidth, newHeight)
                            m_ClickPoint = New PointF(newX, newY)
                        End If
                    ElseIf (m_Ruler.Mode3ResizeLocationRight.X - 1 <= m_ClickPoint.X AndAlso m_ClickPoint.X <= m_Ruler.Mode3ResizeLocationRight.X + 10 AndAlso m_Ruler.Mode3ResizeLocationRight.Y - 10 <= m_ClickPoint.Y AndAlso m_ClickPoint.Y <= m_Ruler.Mode3ResizeLocationRight.Y + 10) Then
                        If (newX <> m_ClickPoint.X OrElse newY <> m_ClickPoint.Y) Then
                            Dim newWidth As Single = m_Ruler.Width + (newX - m_ClickPoint.X)
                            Dim newHeight As Single = m_Ruler.Height + (newY - m_ClickPoint.Y)
                            m_Ruler.UpdateRectangle(False, newWidth, newHeight)
                            m_ClickPoint = New PointF(newX, newY)
                        End If
                    End If
            End Select
        End If
    End Sub

    Private Sub ImageDisplay1_ImageDisplay_MouseDown(ByVal X As System.Double, ByVal Y As System.Double) Handles ImageDisplay1.ImageDisplay_MouseDown
        m_IsClicked = True
        Dim newX As Single = X * ImageDisplay1.Width / m_ImageWidth
        Dim newY As Single = Y * ImageDisplay1.Height / m_ImageHeight

        m_ClickPoint = New PointF(newX, newY)
    End Sub

    Private Sub ImageDisplay1_ImageDisplay_MouseUp(ByVal X As System.Double, ByVal Y As System.Double) Handles ImageDisplay1.ImageDisplay_MouseUp
        m_IsClicked = False
    End Sub

    Private Sub btnCapture_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCapture.Click
        Try
            Dim img As VisionSystem.CImage = Nothing
            ImageDisplay1.CopyTo(img)
            Dim sfdg As SaveFileDialog = New SaveFileDialog()
            sfdg.Filter = "PNG File|*.png|Bitmap FIle|*.bmp"
            If (sfdg.ShowDialog() = DialogResult.OK) Then
                Dim filename As String = sfdg.FileName.Substring(0, sfdg.FileName.LastIndexOf("."))
                Dim ext As String = sfdg.FileName.Substring(sfdg.FileName.LastIndexOf(".") + 1)
                img.WriteImage(filename, ext.ToLower())
            End If
            img.Dispose()
            img = Nothing
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnChangeColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeColor.Click
        Try
            If (m_Ruler IsNot Nothing) Then
                Dim cldg As ColorDialog = New ColorDialog()
                If (cldg.ShowDialog() = DialogResult.OK) Then
                    For Each ctrl As Control In grbCamera.Controls
                        If (ctrl.GetType() Is GetType(CLine) OrElse ctrl.GetType() Is GetType(CCircle)) Then
                            ctrl.BackColor = cldg.Color
                        End If
                    Next
                    m_Ruler.Color = cldg.Color
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FMain_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        ChangeSize()
    End Sub

    Private Sub ChangeSize()
        Try
            Dim pHeight As Integer = TableLayoutPanel1.Height
            Dim pWidth As Integer = pHeight * m_ImageWidth / m_ImageHeight
            Dim dis1 As Double = CDbl(m_ImageWidth / m_ImageHeight)
            Dim dis2 As Double = CDbl(pWidth / pHeight)
            While Math.Abs(dis2 - dis1) > 0.001
                pHeight -= 1
                pWidth = pHeight * m_ImageWidth / m_ImageHeight
                dis2 = CDbl(pWidth / pHeight)
            End While
            grbCamera.Size = New Size(pWidth, pHeight)

        Catch ex As Exception
        End Try
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click
        Me.Close()
    End Sub

    Private Sub Label1_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseEnter
        Label1.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Label1_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.MouseLeave
        Label1.BackColor = Color.Red
    End Sub


    Private m_OldPoint As Point = New Point()
    Private m_Count As Integer = 0
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If (m_IsConnected = True) Then
            Dim p As Point
            If (p <> m_OldPoint) Then
                m_Count = 1
                m_OldPoint = p
            Else
                m_Count += 1
                If (m_Count >= 30) Then
                    btnDisConnect_Click(Nothing, Nothing)
                End If
            End If
        End If
    End Sub

End Class
