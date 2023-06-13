Imports HalconDotNet

Public Class FMaskEdit
    Private m_ImageViewerSrc As ImageDisplay
    Private m_ImageViewerTemplate As ImageDisplay
    Private m_Matching As CMatchingTool = Nothing
    Private m_IsCausesValidation As Boolean = False


    Private Sub GenMaskImage(ByVal SrcImage As CImage, ByRef pDstImage As CImage)
        Dim imgW As Integer, imgH As Integer
        Dim regionMask As CRectangle : regionMask = New CRectangle
        Try
            If pDstImage IsNot Nothing Then Call pDstImage.Dispose()
            Call SrcImage.Based().GetImagePointer1("bmp", imgW, imgH)
            Call regionMask.Based().GenRectangle1(0, 0, CDbl(imgH), CDbl(imgW))
            pDstImage.Based() = regionMask.Based().RegionToBin(0, 255, imgW, imgH)
            Call regionMask.Dispose() : regionMask = Nothing
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CTemplateParam->GenTemplateImage")
        End Try
    End Sub


    Private m_imageR As CImage
    Private m_imageG As CImage
    Private m_imageB As CImage
    Private m_MaskImage As CImage
    Private Sub FMaskEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Call m_ImageViewerSrc.SetPart(m_Matching.TrainParam.SrcImage)
        m_ImageViewerSrc.IsToolShown = True
        m_imageR = New CImage
        m_imageG = New CImage
        m_imageB = New CImage
        m_MaskImage = New CImage
        m_imageR.CopyOf(m_Matching.Pattern.TrainImage)
        m_imageG.CopyOf(m_Matching.Pattern.TrainImage)
        m_imageB.CopyOf(m_Matching.Pattern.TrainImage)
        Call GenMaskImage(m_Matching.Pattern.TrainImage, m_MaskImage)
        m_MaskImage.WriteImage("C:\MaskImage.bmp")
        

        Dim imagePart As System.Drawing.Rectangle
        imagePart.X = CInt(CType(m_Matching.Pattern.TrainRegion, CRectangle).LeftUpperX)
        imagePart.Y = CInt(CType(m_Matching.Pattern.TrainRegion, CRectangle).LeftUpperY)
        imagePart.Width = 90
        imagePart.Height = 90

        Call m_ImageViewerSrc.CopyOfRGB(m_imageR, m_imageG, m_imageB, imagePart)

    End Sub

    Public Sub New(ByRef pMatchingTool As CMatchingTool)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        m_ImageViewerSrc = ImageDisplay
        m_Matching = pMatchingTool
    End Sub

    Private Sub DisplaySrcImg_DisplayMouseDown(ByVal X As Double, ByVal Y As Double) Handles ImageDisplay.ImageDisplay_MouseDown
        m_IsCausesValidation = True
    End Sub

    Private Sub DisplaySrcImg_DisplayMouseMove(ByVal X As Double, ByVal Y As Double) Handles ImageDisplay.ImageDisplay_MouseMove
        If m_IsCausesValidation Then
            If Not (Me.rbBrushRectangle.Checked OrElse Me.rbBrushCircle.Checked) Then
                Dim rectangle As CRectangle : rectangle = New CRectangle
                rectangle.Based().GenRectangle1(Y - (m_BrushSize - 1) / 2, X - (m_BrushSize - 1) / 2, Y + (m_BrushSize - 1) / 2, X + (m_BrushSize - 1) / 2)
                m_MaskImage.Based() = m_MaskImage.Based().PaintRegion(rectangle.Based(), 255.0, "fill")
                m_imageR.Based() = m_imageR.Based().PaintRegion(rectangle.Based(), 255.0, "fill")
                '    Call m_ImageViewerSrc.CopyOfRGB(m_imageR, m_imageG, m_imageB)
            End If
        End If
    End Sub
    Private Sub DisplaySrcImg_DisplayMouseUp(ByVal X As Double, ByVal Y As Double) Handles ImageDisplay.ImageDisplay_MouseUp
        m_IsCausesValidation = False
    End Sub

    ''' <summary>
    ''' 筆刷大小
    ''' </summary>
    ''' <remarks></remarks>
    Private m_BrushSize As Double = 1
    Private Sub rbBrushSize1x1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize1x1.CheckedChanged
        m_BrushSize = 1
    End Sub
    Private Sub rbBrushSize3x3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize3x3.CheckedChanged
        m_BrushSize = 3
    End Sub

    Private Sub rbBrushSize5x5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize5x5.CheckedChanged
        m_BrushSize = 5
    End Sub

    Private Sub rbBrushSize9x9_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize9x9.CheckedChanged
        m_BrushSize = 9
    End Sub

    Private Sub rbBrushSize13x13_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize13x13.CheckedChanged
        m_BrushSize = 13
    End Sub

    Private Sub rbBrushSize19x19_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize19x19.CheckedChanged
        m_BrushSize = 19
    End Sub

    Private Sub rbBrushSize25x25_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize25x25.CheckedChanged
        m_BrushSize = 25
    End Sub

    Private Sub rbBrushSize33x33_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize33x33.CheckedChanged
        m_BrushSize = 33
    End Sub

    Private Sub rbBrushSize41x41_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize41x41.CheckedChanged
        m_BrushSize = 41
    End Sub

    Private Sub rbBrushSize51x51_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushSize51x51.CheckedChanged
        m_BrushSize = 51
    End Sub

    Private Sub rbBrushRectangle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushRectangle.CheckedChanged

    End Sub

    Private Sub rbBrushCircle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrushCircle.CheckedChanged

    End Sub

    Private Sub btnDefault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDefault.Click
        m_imageR.CopyOf(m_Matching.Pattern.TrainImage)
        m_imageG.CopyOf(m_Matching.Pattern.TrainImage)
        m_imageB.CopyOf(m_Matching.Pattern.TrainImage)
        Call GenMaskImage(m_Matching.Pattern.TrainImage, m_MaskImage)
        m_MaskImage.WriteImage("C:\MaskImage.bmp")
        ' Call m_ImageViewerSrc.CopyOfRGB(m_imageR, m_imageG, m_imageB)
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        m_Matching.Pattern.TrainImageMask.CopyOf(m_MaskImage)
        ' m_Matching.Pattern.t()
    End Sub
End Class