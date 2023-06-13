Imports NaotarouHDotNet
Public Class FImageMaskEdit
    Private m_ImageViewer(0 To 3) As WindowControl

    Private m_Matching As CMatching = Nothing
    Private m_numLevelsTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_angleStartTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_angleEndTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_angleStepTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleCMinTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleCMaxTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleCStepTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleRMinTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleRMaxTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_scaleRStepTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_contrastlowTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_contrasthighTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_minSizeTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_minContrastTemplate As System.Windows.Forms.NumericUpDown = Nothing
    Private m_IsNoEvents As Boolean

    Private Sub FImageMaskEdit_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            cmbTemplate1.Items.Add("不優化")
            cmbTemplate1.Items.Add("預設優化")
            cmbTemplate1.Items.Add("角度優化")
            cmbTemplate2.Items.Add("無變化")
            cmbTemplate2.Items.Add("色調相反")
            cmbTemplate2.Items.Add("漸層變化")
            If m_Matching.ImageSource Is Nothing Then m_Matching.ImageSource = New CImage

            Call m_Matching.ImageSource.ReadImage("D:\ImageSource.bmp")
            Call m_Matching.ImageTemplate.ReadImage("D:\templateImage.bmp")
            Call m_Matching.ImageTemplateMask.ReadImage("D:\templateMaskImage.bmp")
            Call m_ImageViewer(0).SetPart(m_Matching.ImageSource)
            Call m_ImageViewer(0).DispImage(m_Matching.ImageSource)

            Call m_ImageViewer(1).SetPart(m_Matching.ImageTemplate)
            Call m_ImageViewer(1).DispImage(m_Matching.ImageTemplate)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Try
            m_IsNoEvents = True
            m_ImageViewer(0) = ImageViewerSource
            m_ImageViewer(1) = ImageViewerTemplate
            'm_ImageViewer(2) = ImageViewer2.HalconWindow
            'm_ImageViewer(3) = ImageViewer3.HalconWindow
            m_numLevelsTemplate = numTemplate1
            m_angleStartTemplate = numTemplate2
            m_angleEndTemplate = numTemplate3
            m_angleStepTemplate = numTemplate4
            m_scaleCMinTemplate = numTemplate5
            m_scaleCMaxTemplate = numTemplate6
            m_scaleCStepTemplate = numTemplate7
            m_scaleRMinTemplate = numTemplate8
            m_scaleRMaxTemplate = numTemplate9
            m_scaleRStepTemplate = numTemplate10
            m_contrastlowTemplate = numTemplate11
            m_contrasthighTemplate = numTemplate12
            m_minSizeTemplate = numTemplate13
            m_minContrastTemplate = numTemplate14
            m_Matching = New CMatching
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnPreparethetemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreparethetemplate.Click
        If m_Matching.ImageTemplate IsNot Nothing Then m_Matching.ImageTemplate.Dispose() : m_Matching.ImageTemplate = Nothing
        m_Matching.ImageTemplate = m_Matching.ImageSource.CopyImage()
    End Sub

    Private Sub btnReducetotemplateimage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReducetotemplateimage.Click
        m_IsNoEvents = True
        m_Matching.RegionTemplate = New CRegion

        Call m_ImageViewer(0).SetColor("red")
        'Call m_ImageViewer(0).DrawRectangle1(row1, column1, row2, column2)

        m_Matching.TopLeftYTemplate = 355
        m_Matching.TopLeftXTemplate = 476
        m_Matching.ButtomRightYTemplate = 419
        m_Matching.ButtomRightXTemplate = 555
        Call m_Matching.TrainAuto()
        m_numLevelsTemplate.Value = m_Matching.NumLevelsTemplate
        m_angleStartTemplate.Value = m_Matching.AngleStartTemplate
        m_angleEndTemplate.Value = CInt(m_Matching.AngleStartTemplate + m_Matching.AngleExtentTemplate)
        m_angleStepTemplate.Value = m_Matching.AngleStepTemplate
        m_scaleCMinTemplate.Value = m_Matching.ScaleMinTemplate
        m_scaleCMaxTemplate.Value = m_Matching.ScaleMaxTemplate
        m_scaleCStepTemplate.Value = m_Matching.ScaleStepTemplate
        m_scaleRMinTemplate.Value = m_Matching.ScaleMinTemplate
        m_scaleRMaxTemplate.Value = m_Matching.ScaleMaxTemplate
        m_scaleRStepTemplate.Value = m_Matching.ScaleStepTemplate
        m_contrastlowTemplate.Value = m_Matching.ContrastLowTemplate
        m_contrasthighTemplate.Value = m_Matching.ContrastHighTemplate
        m_minSizeTemplate.Value = m_Matching.MinSizeTemplate
        m_minContrastTemplate.Value = m_Matching.MinContrastTemplate
        m_ImageViewer(1).SetColor("red")
        Call m_ImageViewer(1).SetPart(m_Matching.TopLeftYTemplate, m_Matching.TopLeftXTemplate, m_Matching.ButtomRightYTemplate, m_Matching.ButtomRightXTemplate)
        Call m_ImageViewer(1).DispImage(m_Matching.ImageTemplate)
        ' Call m_ImageViewer(1).DispXld(m_Matching.GetContourTemplpate())
        m_IsNoEvents = False
    End Sub

    Private Sub numTemplate1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numTemplate1.KeyUp

    End Sub

    Private Sub numTemplate1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numTemplate1.MouseUp, numTemplate2.MouseUp, numTemplate3.MouseUp, numTemplate4.MouseUp, numTemplate5.MouseUp, numTemplate6.MouseUp, numTemplate7.MouseUp, numTemplate8.MouseUp, numTemplate9.MouseUp, numTemplate10.MouseUp, numTemplate11.MouseUp, numTemplate13.MouseUp, numTemplate12.MouseUp, numTemplate14.MouseUp
        Try
            m_Matching.NumLevelsTemplate = m_numLevelsTemplate.Value
            m_Matching.AngleStartTemplate = m_angleStartTemplate.Value
            m_Matching.AngleExtentTemplate = m_angleEndTemplate.Value - m_angleStartTemplate.Value
            'm_angleStepTemplate.Value = m_Matching.AngleStepTemplate
            m_Matching.ScaleMinTemplate = m_scaleCMinTemplate.Value
            m_Matching.ScaleMaxTemplate = m_scaleCMaxTemplate.Value
            'm_scaleCStepTemplate.Value = m_Matching.ScaleStepTemplate
            m_Matching.ScaleMinTemplate = m_scaleRMinTemplate.Value
            m_Matching.ScaleMaxTemplate = m_scaleRMaxTemplate.Value
            'm_scaleRStepTemplate.Value = m_Matching.ScaleStepTemplate
            m_Matching.ContrastLowTemplate = m_contrastlowTemplate.Value
            m_Matching.ContrastHighTemplate = m_contrasthighTemplate.Value
            m_Matching.MinSizeTemplate = m_minSizeTemplate.Value
            m_Matching.MinContrastTemplate = m_minContrastTemplate.Value
            Call m_Matching.TrainManual()
            m_angleStepTemplate.Value = m_Matching.AngleStepTemplate
            m_scaleCStepTemplate.Value = m_Matching.ScaleStepTemplate
            m_scaleRStepTemplate.Value = m_Matching.ScaleStepTemplate
            m_ImageViewer(1).SetColor("red")
            Call m_ImageViewer(1).ClearWindow()
            Call m_ImageViewer(1).SetPart(m_Matching.TopLeftYTemplate, m_Matching.TopLeftXTemplate, m_Matching.ButtomRightYTemplate - 1, m_Matching.ButtomRightXTemplate - 1)
            Call m_ImageViewer(1).DispImage(m_Matching.ImageTemplate)
            'Call m_ImageViewer(1).DispXld(m_Matching.GetContourTemplpate())
        Catch ex As Exception

        End Try
    End Sub

    'Private Sub btnMatching_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatching.Click
    '        If imageDestination IsNot Nothing Then imageDestination.Dispose() : imageDestination = Nothing
    '        imageDestination = New CImage
    '        Call imageDestination.ReadImage("D:\Img4044.bmp")

    ' HOperatorSet m_Matching

    'If sRowTupleH IsNot Nothing Then sRowTupleH = Nothing
    '        If sColTupleH IsNot Nothing Then sColTupleH = Nothing
    '        If sAglTupleH IsNot Nothing Then sAglTupleH = Nothing
    '        If sScrTupleH IsNot Nothing Then sScrTupleH = Nothing
    '        sRowTupleH = New HTuple()
    '        sColTupleH = New HTuple()
    '        sAglTupleH = New HTuple()
    '        sScrTupleH = New HTuple()
    '        shapemodel.FindShapeModel(imageDestination, New HTuple(-15).TupleRad(), New HTuple(30).TupleRad(), 0.5, 35, 0, "least_squares_very_high", 0, 1, sRowTupleH, sColTupleH, sAglTupleH, sScrTupleH)

    '    Dim imgW As Long, imgH As Long
    '    Dim imageType As String = ""
    '        Call imageDestination.GetImagePointer1(imageType, imgW, imgH)
    '        Call m_ImageViewer(0).SetPart(0, 0, imgH - 1, imgW - 1)
    '        Call m_ImageViewer(0).DispImage(imageDestination)
    '    Dim affine As HHomMat2D = Nothing
    '        affine = New HHomMat2D
    '        For i = 0 To (sRowTupleH.TupleLength() - 1)
    '            m_ImageViewer(0).SetColor(New HTuple("green"))
    '            Call m_ImageViewer(0).DispCross(sRowTupleH.TupleSelect(i).D, sColTupleH.TupleSelect(i).D, 40, sAglTupleH.TupleSelect(i).D)
    '            If xldcontourTemplate IsNot Nothing Then xldcontourTemplate.Dispose() : xldcontourTemplate = Nothing
    '            Call affine.HomMat2dIdentity()
    '    'affine.HomMat2dRotate(sAglTupleH.TupleSelect(i).D, 0, 0)
    '            affine = affine.HomMat2dTranslate(sRowTupleH.TupleSelect(i).D, sColTupleH.TupleSelect(i).D)
    '            xldcontourTemplate = affine.AffineTransContourXld(shapemodel.GetShapeModelContours(1))
    '            m_ImageViewer(0).SetColor(New HTuple("red"))
    '            Call m_ImageViewer(0).DispXld(xldcontourTemplate)
    '        Next
    '        affine = Nothing
    'End Sub

    Private Sub ImageViewerSource_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ImageViewerSource.Load

    End Sub
End Class