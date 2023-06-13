'#Region "CONSTANT"

'#End Region
'#Region "Constructors && Destructors"

'#End Region
'#Region "Member"

'#End Region
'#Region "Property"

'#End Region

'#Region "Events"

'#End Region
'#Region "Methods"

'#End Region

Imports HalconDotNet
Imports Timer
Imports Xmler


Public Enum enumMatchingToolResultGraphicConstants
    Origin = 1
    MatchRegion = 2
    MatchFeatures = 4
    BoundingBox = 8
    CoordinateAxes = 16
    All = 31
End Enum

Public Enum EnumMatchShape
    None = 0 ' 樣版亮度比對
    Reticle = 1
    Circle = 2 ' 幾何輪廓比對
End Enum


'Public Enum enumMatchAlgorithm
'    grayvalue = 0 ' 樣版亮度比對
'    correlation = 1
'    shape = 2 ' 幾何輪廓比對
'    shapemodels = 3
'    shapescale = 4
'    shapescalemodels = 5
'    shapanisomodel = 6
'    shapanisomodels = 7
'    component = 8
'    deformable = 9
'End Enum

Friend Enum enumPixelAccuracy
    lowest = 0 'interpolation
    low = 1 'least_squares
    middle = 2 'least_squares_high
    highest = 3 'least_squares_very_high
End Enum

Public Interface IMatchingTool
    Property InputImage() As CImage
    Property SearchRegion() As IGraphics
    Property Pattern() As CMatchingPattern
    Property RunParams() As CMatchingRunParams
    Property Results() As CMatchingResults
    Property FolderPath() As String
    ReadOnly Property IsRunning() As Boolean
    Sub Run(Optional ByVal Asynchronous As Boolean = False, Optional ByVal MatchShape As EnumMatchShape = EnumMatchShape.None)
    Sub CopyTo(ByRef pDestObj As CMatchingTool)
    Sub CopyOf(ByVal SrcObj As CMatchingTool)
    Sub SaveFiles()
    Function ReadFiles() As Integer
End Interface
Public MustInherit Class CMatchingToolBased
    Protected MustOverride Sub AuxMatch(ByVal index As Object)
    Friend MustOverride Sub CopyTo(ByVal SrcObj As CMatchingTool, ByRef pDestObj As CMatchingTool)
End Class

Public Class CCompositeShape
    Inherits CGraphics
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。.dis
        Try
            m_Rectangel = Nothing
            For i As Integer = 0 To m_Rectangel.Count - 1 Step 1
                Call m_Rectangel.Item(i).Dispose()
            Next i
            m_Rectangel = Nothing
            For i As Integer = 0 To m_Reticle.Count - 1 Step 1
                Call m_Reticle.Item(i).Dispose()
            Next i
            m_Reticle = Nothing
            For i As Integer = 0 To m_XldShape.Count - 1 Step 1
                Call m_XldShape.Item(i).Dispose()
            Next i
            m_XldShape = Nothing
        Catch ex As Exception

        End Try
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        If m_Rectangel Is Nothing Then m_Rectangel = New List(Of CRectangle)
        If m_Reticle Is Nothing Then m_Reticle = New List(Of CReticle)
        If m_XldShape Is Nothing Then m_XldShape = New List(Of HalconDotNet.HXLDCont)
        If m_LineSegment Is Nothing Then m_LineSegment = New List(Of CLineSegment)
    End Sub
#End Region
#Region "Member"

#End Region
#Region "Property"
    Private m_ResultGraphicConstants As enumMatchingToolResultGraphicConstants
    Friend Property ResultGraphicConstants() As enumMatchingToolResultGraphicConstants
        Get
            Return m_ResultGraphicConstants
        End Get
        Set(ByVal value As enumMatchingToolResultGraphicConstants)
            m_ResultGraphicConstants = value
        End Set
    End Property
    Private m_XldShape As List(Of HalconDotNet.HXLDCont)
    Friend Property BasedXLD() As List(Of HalconDotNet.HXLDCont)
        Get
            Return m_XldShape
        End Get
        Set(ByVal value As List(Of HalconDotNet.HXLDCont))
            If Not [Object].ReferenceEquals(m_XldShape, value) Then
                For i As Integer = 0 To m_XldShape.Count - 1 Step 1
                    m_XldShape.Item(i).Dispose()
                Next i
                Call m_XldShape.Clear() : m_XldShape = Nothing
            End If
            m_XldShape = value
        End Set
    End Property
    Private m_Rectangel As List(Of CRectangle)
    Friend Property BasedRectangle() As List(Of CRectangle)
        Get
            Return m_Rectangel
        End Get
        Set(ByVal value As List(Of CRectangle))
            If Not [Object].ReferenceEquals(m_Rectangel, value) Then
                For i As Integer = 0 To m_Rectangel.Count - 1 Step 1
                    m_Rectangel.Item(i).Dispose()
                Next i
                Call m_Rectangel.Clear() : m_Rectangel = Nothing
            End If
            m_Rectangel = value
        End Set
    End Property
    Private m_Reticle As List(Of CReticle)
    Friend Property BasedReticle() As List(Of CReticle)
        Get
            Return m_Reticle
        End Get
        Set(ByVal value As List(Of CReticle))
            If Not [Object].ReferenceEquals(m_Reticle, value) Then
                For i As Integer = 0 To m_Reticle.Count - 1 Step 1
                    m_Reticle.Item(i).Dispose()
                Next i
                Call m_Reticle.Clear() : m_Reticle = Nothing
            End If
            m_Reticle = value
        End Set
    End Property
    Private m_LineSegment As List(Of CLineSegment)
    Friend Property BasedLineSegment() As List(Of CLineSegment)
        Get
            Return m_LineSegment
        End Get
        Set(ByVal value As List(Of CLineSegment))
            If Not [Object].ReferenceEquals(m_LineSegment, value) Then
                'For i As Integer = 0 To m_LineSegment.Count - 1 Step 1
                '    m_LineSegment.Item(i).Dispose()
                'Next i
                Call m_LineSegment.Clear() : m_LineSegment = Nothing
            End If
            m_LineSegment = value
        End Set
    End Property



#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Overrides Function Copy() As IGraphics
        Dim regGrphic As CCompositeShape
        regGrphic = New CCompositeShape
        Return regGrphic
    End Function
#End Region
End Class
Public Class CMatchingPattern
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Try
            Call m_ShapeModel.Dispose()
            Call m_NCCModel.Dispose()


        Catch ex As Exception

        End Try
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region

#Region "CONSTANT"
#End Region
#Region "Constructors && Destructors"
    Public Sub New(ByRef pShapeModel As HShapeModel, ByRef pNCCModel As HNCCModel)
        Try
            m_ShapeModel = pShapeModel
            m_NCCModel = pNCCModel
            If m_AngleExtent Is Nothing Then m_AngleExtent = New HTuple(CDbl(0))
            If m_AngleStart Is Nothing Then m_AngleStart = New HTuple(CDbl(0))
            If m_AngleStep Is Nothing Then m_AngleStep = New HTuple(CDbl(0))
            If m_contrasthigh Is Nothing Then m_contrasthigh = New HTuple(CDbl(0))
            If m_contrastlow Is Nothing Then m_contrastlow = New HTuple(CDbl(0))
            m_Trained = False
            If m_metric Is Nothing Then m_metric = New HTuple("use_polarity")
            If m_minContrast Is Nothing Then m_minContrast = New HTuple(CDbl(0))
            If m_minSize Is Nothing Then m_minSize = New HTuple(CDbl(0))
            If m_numLevels Is Nothing Then m_numLevels = New HTuple(CInt(0))
            If m_optimization Is Nothing Then m_optimization = New HTuple("auto")
            If m_ScaleMax Is Nothing Then m_ScaleMax = New HTuple(CDbl(1))
            If m_ScaleMin Is Nothing Then m_ScaleMin = New HTuple(CDbl(1))
            If m_scaleStep Is Nothing Then m_scaleStep = New HTuple(CDbl(0))
            If m_TrainImage Is Nothing Then m_TrainImage = New CImage
            If m_TrainImageMask Is Nothing Then m_TrainImageMask = New CImage
            If m_TrainRegion Is Nothing Then m_TrainRegion = New CRectangle
            If m_xldcontourPattern Is Nothing Then m_xldcontourPattern = New HXLDCont
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub
#End Region
#Region "Member"
    Private m_ShapeModel As HShapeModel
    Private m_NCCModel As HNCCModel
#End Region
#Region "Property"
    Private m_AngleExtent As HTuple = Nothing
    ''' <summary>
    ''' 找尋角度範圍 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property AngleExtent() As HTuple
        Get
            Return m_AngleExtent
        End Get
    End Property
    Private ReadOnly Property AngleMax() As Double
        Get
            Return (m_AngleStart.D() + m_AngleExtent.D()) * 180 / Math.PI
        End Get
    End Property
    Private ReadOnly Property AngleMin() As Double
        Get
            Return m_AngleStart.D() * 180 / Math.PI
        End Get
    End Property
    Private m_AngleStart As HTuple = Nothing
    ''' <summary>
    ''' 找尋起始角度 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property AngleStart() As HTuple
        Get
            Return m_AngleStart
        End Get
    End Property
    Private m_AngleStep As HTuple
    Friend Property AngleStep() As HTuple
        Get
            Return m_AngleStep
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_AngleStep, value) Then m_AngleStep = Nothing
            m_AngleStep = value
        End Set
    End Property
    Private m_contrasthigh As HTuple = Nothing
    Friend Property ContrastHigh() As HTuple
        Get
            Return m_contrasthigh
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_contrasthigh, value) Then m_contrasthigh = Nothing
            m_contrasthigh = value
        End Set
    End Property
    Private m_contrastlow As HTuple = Nothing
    ''' <summary>
    ''' "auto", "auto_contrast", "auto_contrast_hyst", "auto_min_size" ,(contrast_low,contrast_high,min_size)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property ContrastLow() As HTuple
        Get
            Return m_contrastlow
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_contrastlow, value) Then m_contrastlow = Nothing
            m_contrastlow = value
        End Set
    End Property
    Private m_xldcontourPattern As HXLDCont = Nothing
    Friend ReadOnly Property CreateGraphicsCoarse(ByVal level As Integer, ByVal color As Integer) As HalconDotNet.HXLDCont
        Get
            Try
                Dim affine As HHomMat2D = Nothing : affine = New HHomMat2D
                Dim affine1 As HHomMat2D = Nothing
                If m_xldcontourPattern IsNot Nothing Then m_xldcontourPattern.Dispose() : m_xldcontourPattern = Nothing
                Call affine.HomMat2dIdentity()
                affine1 = affine.HomMat2dTranslate(m_TrainRegion.Height / 2, m_TrainRegion.Width / 2)
                m_xldcontourPattern = affine1.AffineTransContourXld(m_ShapeModel.GetShapeModelContours(level))
                affine = Nothing
                Return m_xldcontourPattern
            Catch ex As Exception
                Return Nothing
            End Try
        End Get
    End Property
    Private m_metric As HTuple = Nothing
    ''' <summary>
    ''' "use_polarity", "ignore_global_polarity", "ignore_local_polarity", "ignore_color_polarity"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Metric() As HTuple
        Get
            Return m_metric
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_metric, value) Then m_metric = Nothing
            m_metric = value
        End Set
    End Property
    Private m_minContrast As HTuple = Nothing
    Friend Property MinContrast() As HTuple
        Get
            Return m_minContrast
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_minContrast, value) Then m_minContrast = Nothing
            m_minContrast = value
        End Set
    End Property
    Private m_minSize As HTuple = Nothing
    Friend Property MinSize() As HTuple
        Get
            Return m_minSize
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_minSize, value) Then m_minSize = Nothing
            m_minSize = value
        End Set
    End Property
    Private m_numLevels As HTuple = Nothing
    Friend Property NumLevels() As HTuple
        Get
            Return m_numLevels
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_numLevels, value) Then m_numLevels = Nothing
            m_numLevels = value
        End Set
    End Property
    Private m_optimization As HTuple = Nothing
    ''' <summary>
    ''' "pregeneration" 
    ''' "auto", "none", "point_reduction_low", "point_reduction_medium", "point_reduction_high"
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property Optimization() As HTuple
        Get
            Return m_optimization
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_optimization, value) Then m_optimization = Nothing
            m_optimization = value
        End Set
    End Property
    Private m_ScaleMax As HTuple = Nothing
    Friend ReadOnly Property ScaleMax() As HTuple
        Get
            Return m_ScaleMax
        End Get
    End Property
    Private ReadOnly Property ScaleMax1() As Double
        Get
            Return m_ScaleMax.D() * 100
        End Get
    End Property
    Private m_ScaleMin As HTuple = Nothing
    Friend ReadOnly Property ScaleMin() As HTuple
        Get
            Return m_ScaleMin
        End Get
    End Property
    Private ReadOnly Property ScaleMin1() As Double
        Get
            Return m_ScaleMin.D() * 100
        End Get
    End Property
    Private m_scaleStep As HTuple = Nothing
    Friend Property ScaleStep() As HTuple
        Get
            Return m_scaleStep
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_scaleStep, value) Then m_scaleStep = Nothing
            m_scaleStep = value
        End Set
    End Property
    Private m_Trained As Boolean
    Public Property Trained() As Boolean
        Get
            Return m_Trained
        End Get
        Private Set(ByVal value As Boolean)
            m_Trained = value
        End Set
    End Property
    Private WithEvents m_TrainImage As CImage = Nothing
    ''' <summary>
    ''' 樣板圖形
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrainImage() As CImage
        Get
            Return m_TrainImage
        End Get
        Set(ByVal value As CImage)
            If Not [Object].ReferenceEquals(m_TrainImage, value) Then Call m_TrainImage.Dispose()
            m_TrainImage = value
        End Set
    End Property
    Private WithEvents m_TrainImageMask As CImage = Nothing
    ''' <summary>
    ''' 樣板遮罩圖形
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrainImageMask() As CImage
        Get
            Return m_TrainImageMask
        End Get
        Set(ByVal value As CImage)
            If Not [Object].ReferenceEquals(m_TrainImageMask, value) Then Call m_TrainImageMask.Dispose()
            m_TrainImageMask = value
        End Set
    End Property
    Private WithEvents m_TrainRegion As CRectangle = Nothing
    ''' <summary>
    ''' 樣板框選區域
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrainRegion() As IGraphics
        Get
            Return m_TrainRegion
        End Get
        Set(ByVal value As IGraphics)
            If Not [Object].ReferenceEquals(m_TrainRegion, value) Then Call m_TrainRegion.Dispose()
            m_TrainRegion = CType(value, CRectangle)
        End Set
    End Property
#End Region
#Region "Interface"
#End Region
#Region "Events"
#End Region
#Region "Methods"
    Friend Sub CopyOf(ByVal SrcObj As CMatchingPattern)
        If SrcObj IsNot Nothing Then Call CopyTo(SrcObj, Me)
    End Sub
    Friend Overloads Sub CopyTo(ByRef pDstObj As CMatchingPattern)
        Call CopyTo(Me, pDstObj)
    End Sub
    Friend Overloads Sub CopyTo(ByVal SrcObj As CMatchingPattern, ByRef pDstObj As CMatchingPattern)
        If Not [Object].ReferenceEquals(SrcObj, pDstObj) Then
            If SrcObj IsNot Nothing Then
                If pDstObj Is Nothing Then
                    Dim pmAlignTool As HShapeModel : pmAlignTool = New HShapeModel
                    Dim pmNCCAlignTool As HNCCModel : pmNCCAlignTool = New HNCCModel
                    pDstObj = New CMatchingPattern(pmAlignTool, pmNCCAlignTool)
                End If
                pDstObj.AngleStep.D() = SrcObj.AngleStep.D()
                pDstObj.ContrastHigh.I() = SrcObj.ContrastHigh.I()
                pDstObj.ContrastLow.I() = SrcObj.ContrastLow.I()
                pDstObj.Trained = SrcObj.Trained
                pDstObj.Metric.S() = SrcObj.Metric.S()
                pDstObj.MinContrast.I() = SrcObj.MinContrast.I()
                pDstObj.MinSize.I() = SrcObj.MinSize.I()
                pDstObj.NumLevels.I() = SrcObj.NumLevels.I()
                pDstObj.Optimization.I() = SrcObj.Optimization.I()
                pDstObj.ScaleStep.D() = SrcObj.ScaleStep.D()
                Call pDstObj.SetRotaryRange(SrcObj.AngleMin, SrcObj.AngleMax)
                Call pDstObj.SetScaleRange(SrcObj.ScaleMin1, SrcObj.ScaleMax1)
                Call pDstObj.TrainImage.CopyOf(SrcObj.TrainImage)
                Call pDstObj.m_TrainImageMask.CopyOf(SrcObj.m_TrainImageMask)
                Call pDstObj.m_TrainRegion.CopyOf(SrcObj.m_TrainRegion)
            Else
                pDstObj = Nothing
            End If
        End If
    End Sub
    ''' <summary>
    ''' 產生樣板圖片同時產生空白遮罩圖片
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GenMaskImage()
        Dim imgW As Integer, imgH As Integer
        Dim regionMask As CRectangle : regionMask = New CRectangle
        Try
            If m_TrainImageMask IsNot Nothing Then Call m_TrainImageMask.Dispose()
            Call m_TrainImage.Based().GetImagePointer1("bmp", imgW, imgH)
            Call regionMask.Based().GenRectangle1(0, 0, CDbl(imgH), CDbl(imgW))
            m_TrainImageMask.Based() = regionMask.Based().RegionToBin(255, 0, imgW, imgH)
            Call regionMask.Dispose() : regionMask = Nothing
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CTemplateParam->GenTemplateImage")
        End Try
    End Sub
    'Public Sub ImageMask()
    '    Dim imgW As Integer, imgH As Integer
    '    Dim imageType As String = ""

    '    Call m_TrainParam.TemplateImage.Based().GetImagePointer1(imageType, imgW, imgH)

    '    Dim regionMask As CRectangle
    '    regionMask = New CRectangle
    '    Call regionMask.GenRectangle1(imgW / 4, imgH / 4, imgW / 4 * 3, imgH / 4 * 3)
    '    If m_TrainParam.TemplateMaskImage IsNot Nothing Then Call m_TrainParam.TemplateMaskImage.Dispose() : m_TrainParam.TemplateMaskImage = Nothing
    '    m_TrainParam.TemplateMaskImage = regionMask.GenBinaryImage(255, 0, imgW, imgH)


    '    'If m_ImageTemplateMask IsNot Nothing Then Call m_ImageTemplateMask.Dispose() : m_ImageTemplateMask = Nothing
    '    'm_ImageTemplateMask = m_ImageTemplate.CropPart(CInt(m_LeftUpperYTemplate), CInt(m_LeftUpperXTemplate), CInt((m_RightLowerXTemplate - m_LeftUpperXTemplate)), CInt((m_RightLowerYTemplate - m_LeftUpperYTemplate)))
    '    'Dim width As Integer, height As Integer

    '    'm_ImageTemplateMask.GetImagePointer1("", width, height)


    '    'Dim imgP As IntPtr = m_ImageTemplateMask.GetImagePointer1("byte", width, height)
    '    'Call m_ImageTemplateMask.GenImage1("byte", imgW, imgH, imgP)

    'End Sub

    ''' <summary>
    ''' 
    ''' 1.參數 AngleMin 輸入單位為角度
    ''' 2.參數 AngleMax 輸入單位為角度
    ''' </summary>
    ''' <param name="AngleMin"></param>
    ''' <param name="AngleMax"></param>
    ''' <remarks></remarks>
    Public Sub SetRotaryRange(ByVal AngleMin As Double, ByVal AngleMax As Double)
        Try
            If AngleMin > AngleMax Then AngleMin = AngleMax
            m_AngleStart.D() = AngleMin * Math.PI / 180
            m_AngleExtent.D() = (AngleMax - AngleMin) * Math.PI / 180
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub
    ''' <summary> 
    ''' 1.參數 ScaleMin 100表示為原比例
    ''' 2.參數 ScaleMax 100表示為原比例
    ''' </summary>
    ''' <param name="ScaleMin"></param>
    ''' <param name="ScaleMax"></param>
    ''' <remarks></remarks>
    Public Sub SetScaleRange(ByVal ScaleMin As Double, ByVal ScaleMax As Double)
        Try
            If ScaleMin > ScaleMax Then ScaleMin = ScaleMax
            m_ScaleMin.D() = ScaleMin / 100 : m_ScaleMax.D() = ScaleMax / 100
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub
    Public Function CreateCrossImage(ByRef pSourceImage As CImage) As Boolean
        Try


            Dim HTuple_Threshold As HTuple = New HTuple(12)
            Dim HTuple_Sigma As HTuple = New HTuple(1.2)
            Dim HTuple_Trarsition As HTuple = New HTuple("all")
            Dim HTuple_Select As HTuple = New HTuple("all")

            Dim roiWidthLen2_1st As HTuple = New HTuple
            Dim lineRowStart_Measure_1st As HTuple = New HTuple
            Dim lineColumnStart_Measure_1st As HTuple = New HTuple
            Dim lineRowEnd_Measure_1st As HTuple = New HTuple
            Dim lineColumnEnd_Measure_1st As HTuple = New HTuple
            Dim tmpCtrl_Row_1st As HTuple = New HTuple
            Dim tmpCtrl_Column_1st As HTuple = New HTuple
            Dim tmpCtrl_Dr_1st As HTuple = New HTuple
            Dim tmpCtrl_Dc_1st As HTuple = New HTuple
            Dim tmpCtrl_Phi_1st As HTuple = New HTuple
            Dim tmpCtrl_Len1_1st As HTuple = New HTuple
            Dim tmpCtrl_Len2_1st As HTuple = New HTuple
            Dim msrHandle_Measure_1st As HTuple = New HTuple
            Dim row_Measure_1st As HTuple = New HTuple
            Dim column_Measure_1st As HTuple = New HTuple
            Dim amplitude_Measure_1st As HTuple = New HTuple
            Dim distance_Measure_1st As HTuple = New HTuple

            Dim roiWidthLen2_2nd As HTuple = New HTuple
            Dim lineRowStart_Measure_2nd As HTuple = New HTuple
            Dim lineColumnStart_Measure_2nd As HTuple = New HTuple
            Dim lineRowEnd_Measure_2nd As HTuple = New HTuple
            Dim lineColumnEnd_Measure_2nd As HTuple = New HTuple
            Dim tmpCtrl_Row_2nd As HTuple = New HTuple
            Dim tmpCtrl_Column_2nd As HTuple = New HTuple
            Dim tmpCtrl_Dr_2nd As HTuple = New HTuple
            Dim tmpCtrl_Dc_2nd As HTuple = New HTuple
            Dim tmpCtrl_Phi_2nd As HTuple = New HTuple
            Dim tmpCtrl_Len1_2nd As HTuple = New HTuple
            Dim tmpCtrl_Len2_2nd As HTuple = New HTuple
            Dim msrHandle_Measure_2nd As HTuple = New HTuple
            Dim row_Measure_2nd As HTuple = New HTuple
            Dim column_Measure_2nd As HTuple = New HTuple
            Dim amplitude_Measure_2nd As HTuple = New HTuple
            Dim distance_Measure_2nd As HTuple = New HTuple

            Dim roiWidthLen2_3rd As HTuple = New HTuple
            Dim lineRowStart_Measure_3rd As HTuple = New HTuple
            Dim lineColumnStart_Measure_3rd As HTuple = New HTuple
            Dim lineRowEnd_Measure_3rd As HTuple = New HTuple
            Dim lineColumnEnd_Measure_3rd As HTuple = New HTuple
            Dim tmpCtrl_Row_3rd As HTuple = New HTuple
            Dim tmpCtrl_Column_3rd As HTuple = New HTuple
            Dim tmpCtrl_Dr_3rd As HTuple = New HTuple
            Dim tmpCtrl_Dc_3rd As HTuple = New HTuple
            Dim tmpCtrl_Phi_3rd As HTuple = New HTuple
            Dim tmpCtrl_Len1_3rd As HTuple = New HTuple
            Dim tmpCtrl_Len2_3rd As HTuple = New HTuple
            Dim msrHandle_Measure_3rd As HTuple = New HTuple
            Dim row_Measure_3rd As HTuple = New HTuple
            Dim column_Measure_3rd As HTuple = New HTuple
            Dim amplitude_Measure_3rd As HTuple = New HTuple
            Dim distance_Measure_3rd As HTuple = New HTuple

            Dim roiWidthLen2_4th As HTuple = New HTuple
            Dim lineRowStart_Measure_4th As HTuple = New HTuple
            Dim lineColumnStart_Measure_4th As HTuple = New HTuple
            Dim lineRowEnd_Measure_4th As HTuple = New HTuple
            Dim lineColumnEnd_Measure_4th As HTuple = New HTuple
            Dim tmpCtrl_Row_4th As HTuple = New HTuple
            Dim tmpCtrl_Column_4th As HTuple = New HTuple
            Dim tmpCtrl_Dr_4th As HTuple = New HTuple
            Dim tmpCtrl_Dc_4th As HTuple = New HTuple
            Dim tmpCtrl_Phi_4th As HTuple = New HTuple
            Dim tmpCtrl_Len1_4th As HTuple = New HTuple
            Dim tmpCtrl_Len2_4th As HTuple = New HTuple
            Dim msrHandle_Measure_4th As HTuple = New HTuple
            Dim row_Measure_4th As HTuple = New HTuple
            Dim column_Measure_4th As HTuple = New HTuple
            Dim amplitude_Measure_4th As HTuple = New HTuple
            Dim distance_Measure_4th As HTuple = New HTuple

            Dim roiWidthLen2_5th As HTuple = New HTuple
            Dim lineRowStart_Measure_5th As HTuple = New HTuple
            Dim lineColumnStart_Measure_5th As HTuple = New HTuple
            Dim lineRowEnd_Measure_5th As HTuple = New HTuple
            Dim lineColumnEnd_Measure_5th As HTuple = New HTuple
            Dim tmpCtrl_Row_5th As HTuple = New HTuple
            Dim tmpCtrl_Column_5th As HTuple = New HTuple
            Dim tmpCtrl_Dr_5th As HTuple = New HTuple
            Dim tmpCtrl_Dc_5th As HTuple = New HTuple
            Dim tmpCtrl_Phi_5th As HTuple = New HTuple
            Dim tmpCtrl_Len1_5th As HTuple = New HTuple
            Dim tmpCtrl_Len2_5th As HTuple = New HTuple
            Dim msrHandle_Measure_5th As HTuple = New HTuple
            Dim row_Measure_5th As HTuple = New HTuple
            Dim column_Measure_5th As HTuple = New HTuple
            Dim amplitude_Measure_5th As HTuple = New HTuple
            Dim distance_Measure_5th As HTuple = New HTuple

            Dim roiWidthLen2_6th As HTuple = New HTuple
            Dim lineRowStart_Measure_6th As HTuple = New HTuple
            Dim lineColumnStart_Measure_6th As HTuple = New HTuple
            Dim lineRowEnd_Measure_6th As HTuple = New HTuple
            Dim lineColumnEnd_Measure_6th As HTuple = New HTuple
            Dim tmpCtrl_Row_6th As HTuple = New HTuple
            Dim tmpCtrl_Column_6th As HTuple = New HTuple
            Dim tmpCtrl_Dr_6th As HTuple = New HTuple
            Dim tmpCtrl_Dc_6th As HTuple = New HTuple
            Dim tmpCtrl_Phi_6th As HTuple = New HTuple
            Dim tmpCtrl_Len1_6th As HTuple = New HTuple
            Dim tmpCtrl_Len2_6th As HTuple = New HTuple
            Dim msrHandle_Measure_6th As HTuple = New HTuple
            Dim row_Measure_6th As HTuple = New HTuple
            Dim column_Measure_6th As HTuple = New HTuple
            Dim amplitude_Measure_6th As HTuple = New HTuple
            Dim distance_Measure_6th As HTuple = New HTuple

            Dim roiWidthLen2_7th As HTuple = New HTuple
            Dim lineRowStart_Measure_7th As HTuple = New HTuple
            Dim lineColumnStart_Measure_7th As HTuple = New HTuple
            Dim lineRowEnd_Measure_7th As HTuple = New HTuple
            Dim lineColumnEnd_Measure_7th As HTuple = New HTuple
            Dim tmpCtrl_Row_7th As HTuple = New HTuple
            Dim tmpCtrl_Column_7th As HTuple = New HTuple
            Dim tmpCtrl_Dr_7th As HTuple = New HTuple
            Dim tmpCtrl_Dc_7th As HTuple = New HTuple
            Dim tmpCtrl_Phi_7th As HTuple = New HTuple
            Dim tmpCtrl_Len1_7th As HTuple = New HTuple
            Dim tmpCtrl_Len2_7th As HTuple = New HTuple
            Dim msrHandle_Measure_7th As HTuple = New HTuple
            Dim row_Measure_7th As HTuple = New HTuple
            Dim column_Measure_7th As HTuple = New HTuple
            Dim amplitude_Measure_7th As HTuple = New HTuple
            Dim distance_Measure_7th As HTuple = New HTuple

            Dim roiWidthLen2_8th As HTuple = New HTuple
            Dim lineRowStart_Measure_8th As HTuple = New HTuple
            Dim lineColumnStart_Measure_8th As HTuple = New HTuple
            Dim lineRowEnd_Measure_8th As HTuple = New HTuple
            Dim lineColumnEnd_Measure_8th As HTuple = New HTuple
            Dim tmpCtrl_Row_8th As HTuple = New HTuple
            Dim tmpCtrl_Column_8th As HTuple = New HTuple
            Dim tmpCtrl_Dr_8th As HTuple = New HTuple
            Dim tmpCtrl_Dc_8th As HTuple = New HTuple
            Dim tmpCtrl_Phi_8th As HTuple = New HTuple
            Dim tmpCtrl_Len1_8th As HTuple = New HTuple
            Dim tmpCtrl_Len2_8th As HTuple = New HTuple
            Dim msrHandle_Measure_8th As HTuple = New HTuple
            Dim row_Measure_8th As HTuple = New HTuple
            Dim column_Measure_8th As HTuple = New HTuple
            Dim amplitude_Measure_8th As HTuple = New HTuple
            Dim distance_Measure_8th As HTuple = New HTuple

            roiWidthLen2_1st = 60
            roiWidthLen2_2nd = 60
            roiWidthLen2_3rd = 60
            roiWidthLen2_4th = 60
            roiWidthLen2_5th = 60
            roiWidthLen2_6th = 60
            roiWidthLen2_7th = 60
            roiWidthLen2_8th = 60

            Dim searchLength As Double = 50

            Dim LineRowStart_Measure_01_0 As Double = 103.711
            Dim LineColumnStart_Measure_01_0 As Double = 233.591
            Dim LineRowEnd_Measure_01_0 As Double = 103.11
            Dim LineColumnEnd_Measure_01_0 As Double = 267.934

            Dim cc As Double = m_TrainRegion.CenterX


            lineRowStart_Measure_1st = New HTuple(m_TrainRegion.Centery + (m_TrainRegion.Height / 2))
            lineColumnStart_Measure_1st = New HTuple(m_TrainRegion.CenterX - searchLength)
            lineRowEnd_Measure_1st = New HTuple(m_TrainRegion.Centery + (m_TrainRegion.Height / 2))
            lineColumnEnd_Measure_1st = New HTuple(m_TrainRegion.CenterX + searchLength)


            tmpCtrl_Row_1st = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_1st.TupleAdd(lineRowEnd_Measure_1st))
            tmpCtrl_Column_1st = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_1st.TupleAdd(lineColumnEnd_Measure_1st))
            tmpCtrl_Dr_1st = lineRowStart_Measure_1st.TupleSub(lineRowEnd_Measure_1st)
            tmpCtrl_Dc_1st = lineColumnEnd_Measure_1st.TupleSub(lineColumnStart_Measure_1st)
            tmpCtrl_Phi_1st = tmpCtrl_Dr_1st.TupleAtan2(tmpCtrl_Dc_1st)
            tmpCtrl_Len1_1st = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_1st.TupleMult(tmpCtrl_Dr_1st))).TupleAdd(tmpCtrl_Dc_1st.TupleMult(tmpCtrl_Dc_1st)))).TupleSqrt())
            tmpCtrl_Len2_1st = roiWidthLen2_1st.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_1st, tmpCtrl_Column_1st, tmpCtrl_Phi_1st, _
                                        tmpCtrl_Len1_1st, tmpCtrl_Len2_1st, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_1st)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_1st, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_1st, column_Measure_1st, amplitude_Measure_1st, distance_Measure_1st)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_2nd = New HTuple(m_TrainRegion.Centery + (m_TrainRegion.Height / 4))
            lineColumnStart_Measure_2nd = New HTuple(m_TrainRegion.CenterX - searchLength)
            lineRowEnd_Measure_2nd = New HTuple(m_TrainRegion.Centery + (m_TrainRegion.Height / 4))
            lineColumnEnd_Measure_2nd = New HTuple(m_TrainRegion.CenterX + searchLength)


            tmpCtrl_Row_2nd = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_2nd.TupleAdd(lineRowEnd_Measure_2nd))
            tmpCtrl_Column_2nd = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_2nd.TupleAdd(lineColumnEnd_Measure_2nd))
            tmpCtrl_Dr_2nd = lineRowStart_Measure_2nd.TupleSub(lineRowEnd_Measure_2nd)
            tmpCtrl_Dc_2nd = lineColumnEnd_Measure_2nd.TupleSub(lineColumnStart_Measure_2nd)
            tmpCtrl_Phi_2nd = tmpCtrl_Dr_2nd.TupleAtan2(tmpCtrl_Dc_2nd)
            tmpCtrl_Len1_2nd = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_2nd.TupleMult(tmpCtrl_Dr_2nd))).TupleAdd(tmpCtrl_Dc_2nd.TupleMult(tmpCtrl_Dc_2nd)))).TupleSqrt())
            tmpCtrl_Len2_2nd = roiWidthLen2_2nd.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_2nd, tmpCtrl_Column_2nd, tmpCtrl_Phi_2nd, _
                                        tmpCtrl_Len1_2nd, tmpCtrl_Len2_2nd, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_2nd)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_2nd, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_2nd, column_Measure_2nd, amplitude_Measure_2nd, distance_Measure_2nd)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_3rd = New HTuple(m_TrainRegion.Centery - searchLength)
            lineColumnStart_Measure_3rd = New HTuple(m_TrainRegion.CenterX - (m_TrainRegion.Width / 2))
            lineRowEnd_Measure_3rd = New HTuple(m_TrainRegion.Centery + searchLength)
            lineColumnEnd_Measure_3rd = New HTuple(m_TrainRegion.CenterX - (m_TrainRegion.Width / 2))


            tmpCtrl_Row_3rd = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_3rd.TupleAdd(lineRowEnd_Measure_3rd))
            tmpCtrl_Column_3rd = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_3rd.TupleAdd(lineColumnEnd_Measure_3rd))
            tmpCtrl_Dr_3rd = lineRowStart_Measure_3rd.TupleSub(lineRowEnd_Measure_3rd)
            tmpCtrl_Dc_3rd = lineColumnEnd_Measure_3rd.TupleSub(lineColumnStart_Measure_3rd)
            tmpCtrl_Phi_3rd = tmpCtrl_Dr_3rd.TupleAtan2(tmpCtrl_Dc_3rd)
            tmpCtrl_Len1_3rd = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_3rd.TupleMult(tmpCtrl_Dr_3rd))).TupleAdd(tmpCtrl_Dc_3rd.TupleMult(tmpCtrl_Dc_3rd)))).TupleSqrt())
            tmpCtrl_Len2_3rd = roiWidthLen2_3rd.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_3rd, tmpCtrl_Column_3rd, tmpCtrl_Phi_3rd, _
                                        tmpCtrl_Len1_3rd, tmpCtrl_Len2_3rd, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_3rd)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_3rd, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_3rd, column_Measure_3rd, amplitude_Measure_3rd, distance_Measure_3rd)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_4th = New HTuple(m_TrainRegion.Centery - searchLength)
            lineColumnStart_Measure_4th = New HTuple(m_TrainRegion.CenterX - (m_TrainRegion.Width / 4))
            lineRowEnd_Measure_4th = New HTuple(m_TrainRegion.Centery + searchLength)
            lineColumnEnd_Measure_4th = New HTuple(m_TrainRegion.CenterX - (m_TrainRegion.Width / 4))


            tmpCtrl_Row_4th = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_4th.TupleAdd(lineRowEnd_Measure_4th))
            tmpCtrl_Column_4th = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_4th.TupleAdd(lineColumnEnd_Measure_4th))
            tmpCtrl_Dr_4th = lineRowStart_Measure_4th.TupleSub(lineRowEnd_Measure_4th)
            tmpCtrl_Dc_4th = lineColumnEnd_Measure_4th.TupleSub(lineColumnStart_Measure_4th)
            tmpCtrl_Phi_4th = tmpCtrl_Dr_4th.TupleAtan2(tmpCtrl_Dc_4th)
            tmpCtrl_Len1_4th = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_4th.TupleMult(tmpCtrl_Dr_4th))).TupleAdd(tmpCtrl_Dc_4th.TupleMult(tmpCtrl_Dc_4th)))).TupleSqrt())
            tmpCtrl_Len2_4th = roiWidthLen2_4th.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_4th, tmpCtrl_Column_4th, tmpCtrl_Phi_4th, _
                                        tmpCtrl_Len1_4th, tmpCtrl_Len2_4th, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_4th)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_4th, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_4th, column_Measure_4th, amplitude_Measure_4th, distance_Measure_4th)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_5th = New HTuple(m_TrainRegion.Centery - (m_TrainRegion.Height / 2))
            lineColumnStart_Measure_5th = New HTuple(m_TrainRegion.CenterX - searchLength)
            lineRowEnd_Measure_5th = New HTuple(m_TrainRegion.Centery - (m_TrainRegion.Height / 2))
            lineColumnEnd_Measure_5th = New HTuple(m_TrainRegion.CenterX + searchLength)


            tmpCtrl_Row_5th = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_5th.TupleAdd(lineRowEnd_Measure_5th))
            tmpCtrl_Column_5th = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_5th.TupleAdd(lineColumnEnd_Measure_5th))
            tmpCtrl_Dr_5th = lineRowStart_Measure_5th.TupleSub(lineRowEnd_Measure_5th)
            tmpCtrl_Dc_5th = lineColumnEnd_Measure_5th.TupleSub(lineColumnStart_Measure_5th)
            tmpCtrl_Phi_5th = tmpCtrl_Dr_5th.TupleAtan2(tmpCtrl_Dc_5th)
            tmpCtrl_Len1_5th = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_5th.TupleMult(tmpCtrl_Dr_5th))).TupleAdd(tmpCtrl_Dc_5th.TupleMult(tmpCtrl_Dc_5th)))).TupleSqrt())
            tmpCtrl_Len2_5th = roiWidthLen2_5th.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_5th, tmpCtrl_Column_5th, tmpCtrl_Phi_5th, _
                                        tmpCtrl_Len1_5th, tmpCtrl_Len2_5th, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_5th)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_5th, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_5th, column_Measure_5th, amplitude_Measure_5th, distance_Measure_5th)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_6th = New HTuple(m_TrainRegion.Centery - (m_TrainRegion.Height / 4))
            lineColumnStart_Measure_6th = New HTuple(m_TrainRegion.CenterX - searchLength)
            lineRowEnd_Measure_6th = New HTuple(m_TrainRegion.Centery - (m_TrainRegion.Height / 4))
            lineColumnEnd_Measure_6th = New HTuple(m_TrainRegion.CenterX + searchLength)


            tmpCtrl_Row_6th = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_6th.TupleAdd(lineRowEnd_Measure_6th))
            tmpCtrl_Column_6th = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_6th.TupleAdd(lineColumnEnd_Measure_6th))
            tmpCtrl_Dr_6th = lineRowStart_Measure_6th.TupleSub(lineRowEnd_Measure_6th)
            tmpCtrl_Dc_6th = lineColumnEnd_Measure_6th.TupleSub(lineColumnStart_Measure_6th)
            tmpCtrl_Phi_6th = tmpCtrl_Dr_6th.TupleAtan2(tmpCtrl_Dc_6th)
            tmpCtrl_Len1_6th = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_6th.TupleMult(tmpCtrl_Dr_6th))).TupleAdd(tmpCtrl_Dc_6th.TupleMult(tmpCtrl_Dc_6th)))).TupleSqrt())
            tmpCtrl_Len2_6th = roiWidthLen2_6th.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_6th, tmpCtrl_Column_6th, tmpCtrl_Phi_6th, _
                                        tmpCtrl_Len1_6th, tmpCtrl_Len2_6th, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_6th)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_6th, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_6th, column_Measure_6th, amplitude_Measure_6th, distance_Measure_6th)

            ''''''''''''''''''''''''''''''''''''''''

            lineRowStart_Measure_7th = New HTuple(m_TrainRegion.Centery - searchLength)
            lineColumnStart_Measure_7th = New HTuple(m_TrainRegion.CenterX + (m_TrainRegion.Width / 2))
            lineRowEnd_Measure_7th = New HTuple(m_TrainRegion.Centery + searchLength)
            lineColumnEnd_Measure_7th = New HTuple(m_TrainRegion.CenterX + (m_TrainRegion.Width / 2))


            tmpCtrl_Row_7th = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_7th.TupleAdd(lineRowEnd_Measure_7th))
            tmpCtrl_Column_7th = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_7th.TupleAdd(lineColumnEnd_Measure_7th))
            tmpCtrl_Dr_7th = lineRowStart_Measure_7th.TupleSub(lineRowEnd_Measure_7th)
            tmpCtrl_Dc_7th = lineColumnEnd_Measure_7th.TupleSub(lineColumnStart_Measure_7th)
            tmpCtrl_Phi_7th = tmpCtrl_Dr_7th.TupleAtan2(tmpCtrl_Dc_7th)
            tmpCtrl_Len1_7th = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_7th.TupleMult(tmpCtrl_Dr_7th))).TupleAdd(tmpCtrl_Dc_7th.TupleMult(tmpCtrl_Dc_7th)))).TupleSqrt())
            tmpCtrl_Len2_7th = roiWidthLen2_7th.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_7th, tmpCtrl_Column_7th, tmpCtrl_Phi_7th, _
                                        tmpCtrl_Len1_7th, tmpCtrl_Len2_7th, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_7th)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_7th, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_7th, column_Measure_7th, amplitude_Measure_7th, distance_Measure_7th)


            lineRowStart_Measure_8th = New HTuple(m_TrainRegion.Centery - searchLength)
            lineColumnStart_Measure_8th = New HTuple(m_TrainRegion.CenterX + (m_TrainRegion.Width / 2))
            lineRowEnd_Measure_8th = New HTuple(m_TrainRegion.Centery + searchLength)
            lineColumnEnd_Measure_8th = New HTuple(m_TrainRegion.CenterX + (m_TrainRegion.Width / 2))

            ''''''''''''''''''''''''''''''''''''''''

            tmpCtrl_Row_8th = (New HTuple(0.5)).TupleMult(lineRowStart_Measure_8th.TupleAdd(lineRowEnd_Measure_8th))
            tmpCtrl_Column_8th = (New HTuple(0.5)).TupleMult(lineColumnStart_Measure_8th.TupleAdd(lineColumnEnd_Measure_8th))
            tmpCtrl_Dr_8th = lineRowStart_Measure_8th.TupleSub(lineRowEnd_Measure_8th)
            tmpCtrl_Dc_8th = lineColumnEnd_Measure_8th.TupleSub(lineColumnStart_Measure_8th)
            tmpCtrl_Phi_8th = tmpCtrl_Dr_8th.TupleAtan2(tmpCtrl_Dc_8th)
            tmpCtrl_Len1_8th = (New HTuple(0.5)).TupleMult(((((tmpCtrl_Dr_8th.TupleMult(tmpCtrl_Dr_8th))).TupleAdd(tmpCtrl_Dc_8th.TupleMult(tmpCtrl_Dc_8th)))).TupleSqrt())
            tmpCtrl_Len2_8th = roiWidthLen2_8th.Clone()
            HOperatorSet.GenMeasureRectangle2(tmpCtrl_Row_8th, tmpCtrl_Column_8th, tmpCtrl_Phi_8th, _
                                        tmpCtrl_Len1_8th, tmpCtrl_Len2_8th, New HTuple(pSourceImage.Width), New HTuple(pSourceImage.Height), New HTuple("nearest_neighbor"), _
                                        msrHandle_Measure_8th)
            'Measure 01: Execute measurements
            HOperatorSet.MeasurePos(pSourceImage.Based(), msrHandle_Measure_8th, HTuple_Sigma, HTuple_Threshold, HTuple_Trarsition, HTuple_Select, row_Measure_8th, column_Measure_8th, amplitude_Measure_8th, distance_Measure_8th)


            Dim UpX1 As Double
            Dim UpX2 As Double
            Dim UpY1 As Double
            Dim UpY2 As Double
            Dim DownX1 As Double
            Dim DownX2 As Double
            Dim DownY1 As Double
            Dim DownY2 As Double
            Dim LeftX1 As Double
            Dim LeftX2 As Double
            Dim LeftY1 As Double
            Dim LeftY2 As Double
            Dim RightX1 As Double
            Dim RightX2 As Double
            Dim RightY1 As Double
            Dim RightY2 As Double
            CreateCrossImage = True

            If (column_Measure_1st.Length() >= 2) AndAlso (column_Measure_1st.Length() < 2) AndAlso (column_Measure_2nd.Length() >= 2) AndAlso (column_Measure_2nd.Length() < 2) Then
                UpX1 = (column_Measure_1st(0).D + column_Measure_2nd(0).D) / 2
                UpX2 = (column_Measure_1st(1).D + column_Measure_2nd(1).D) / 2
            ElseIf (column_Measure_1st.Length() >= 2) AndAlso (column_Measure_1st.Length() < 3) Then
                UpX1 = (column_Measure_1st(0).D)
                UpX2 = (column_Measure_1st(1).D)
            ElseIf (column_Measure_2nd.Length() >= 2) AndAlso (column_Measure_2nd.Length() < 3) Then
                UpX1 = (column_Measure_2nd(0).D)
                UpX2 = (column_Measure_2nd(1).D)
            Else
                CreateCrossImage = False
            End If
            UpY1 = 0
            UpY2 = 0

            If CreateCrossImage = False Then
                Exit Try
            End If

            If (column_Measure_5th.Length() >= 2) AndAlso (column_Measure_5th.Length() < 3) AndAlso (column_Measure_6th.Length() >= 2) AndAlso (column_Measure_6th.Length() < 3) Then
                DownX1 = (column_Measure_5th(0).D + column_Measure_6th(0).D) / 2
                DownX2 = (column_Measure_5th(1).D + column_Measure_6th(1).D) / 2
            ElseIf (column_Measure_5th.Length() >= 2) AndAlso (column_Measure_5th.Length() < 3) Then
                DownX1 = (column_Measure_5th(0).D)
                DownX2 = (column_Measure_5th(1).D)
            ElseIf (column_Measure_6th.Length() >= 2) AndAlso (column_Measure_6th.Length() < 3) Then
                DownX1 = (column_Measure_6th(0).D)
                DownX2 = (column_Measure_6th(1).D)
            Else
                CreateCrossImage = False
            End If
            DownY1 = pSourceImage.Height
            DownY2 = pSourceImage.Height

            If CreateCrossImage = False Then
                Exit Try
            End If


            If (row_Measure_3rd.Length() >= 2) AndAlso (row_Measure_3rd.Length() < 3) AndAlso (row_Measure_4th.Length() >= 2) AndAlso (row_Measure_4th.Length() < 3) Then
                LeftY1 = (row_Measure_3rd(0).D + row_Measure_4th(0).D) / 2
                LeftY2 = (row_Measure_3rd(1).D + row_Measure_4th(1).D) / 2
            ElseIf (row_Measure_3rd.Length() >= 2) AndAlso (row_Measure_3rd.Length() < 3) Then
                LeftY1 = (row_Measure_3rd(0).D)
                LeftY2 = (row_Measure_3rd(1).D)
            ElseIf (row_Measure_4th.Length() >= 2) AndAlso (row_Measure_4th.Length() < 3) Then
                LeftY1 = (row_Measure_4th(0).D)
                LeftY2 = (row_Measure_4th(1).D)
            Else
                CreateCrossImage = False
            End If

            LeftX1 = 0
            LeftX2 = 0

            If CreateCrossImage = False Then
                Exit Try
            End If

            If (row_Measure_7th.Length() >= 2) AndAlso (row_Measure_7th.Length() < 3) AndAlso (row_Measure_8th.Length() >= 2) AndAlso (row_Measure_8th.Length() < 3) Then
                RightY1 = (row_Measure_7th(0).D + row_Measure_8th(0).D) / 2
                RightY2 = (row_Measure_7th(1).D + row_Measure_8th(1).D) / 2
            ElseIf (row_Measure_7th.Length() >= 2) AndAlso (row_Measure_7th.Length() < 3) Then
                RightY1 = (row_Measure_7th(0).D)
                RightY2 = (row_Measure_7th(1).D)
            ElseIf (row_Measure_8th.Length() >= 2) AndAlso (row_Measure_8th.Length() < 3) Then
                RightY1 = (row_Measure_8th(0).D)
                RightY2 = (row_Measure_8th(1).D)
            Else
                CreateCrossImage = False
            End If

            RightX1 = pSourceImage.Width
            RightX2 = pSourceImage.Width

            If CreateCrossImage = False Then
                Exit Try
            End If

            Dim cross1_x1 As Double = (UpX1 + DownX1) / 2
            Dim cross1_x2 As Double = (UpX2 + DownX2) / 2
            Dim cross1_y1 As Double = (UpY1 + UpY2) / 2
            Dim cross1_y2 As Double = (DownY2 + DownY2) / 2

            Dim cross2_x1 As Double = (LeftX1 + LeftX2) / 2
            Dim cross2_x2 As Double = (RightX2 + RightX1) / 2
            Dim cross2_y1 As Double = (LeftY1 + RightY1) / 2
            Dim cross2_y2 As Double = (LeftY2 + RightY2) / 2

            Dim CrossRectangel As HObject = New HObject
            Dim CrossRectange2 As HObject = New HObject

            Dim Image As HObject = New HObject
            Dim NewImage As HObject = New HObject

            If cross1_y2 < cross1_y1 Then
                Dim change As Double = cross1_y2
                cross1_y2 = cross1_y1
                cross1_y1 = change
            End If
            If cross1_x2 < cross1_x1 Then
                Dim change As Double = cross1_x2
                cross1_x2 = cross1_x1
                cross1_x1 = change
            End If
            If cross2_y2 < cross2_y1 Then
                Dim change As Double = cross2_y2
                cross2_y2 = cross2_y1
                cross2_y1 = change
            End If
            If cross2_x2 < cross2_x1 Then
                Dim change As Double = cross2_x2
                cross2_x2 = cross2_x1
                cross2_x1 = change
            End If

            Dim xxx As Double = (cross1_x1 + cross1_x2) / 2

            'cross1_x1 = (cross1_x1 + xxx) / 2
            'cross1_x2 = (cross1_x2 + xxx) / 2

            Dim yyy As Double = (cross2_y1 + cross2_y2) / 2

            'cross2_y1 = (cross2_y1 + yyy) / 2
            'cross2_y2 = (cross2_y2 + yyy) / 2

            HOperatorSet.GenRectangle1(CrossRectangel, cross1_y1, cross1_x1, cross1_y2, cross1_x2)

            HOperatorSet.GenRectangle1(CrossRectange2, cross2_y1, cross2_x1, cross2_y2, cross2_x2)

            HOperatorSet.GenImageProto(pSourceImage.Based, Image, 255)

            HOperatorSet.PaintRegion(CrossRectangel, Image, NewImage, 0, "fill")

            HOperatorSet.PaintRegion(CrossRectange2, NewImage, NewImage, 0, "fill")


            'pSourceImage.Based = CType(NewImage, HImage)(m_FolderPath & "\InputImage.bmp"
            HOperatorSet.WriteImage(NewImage, "bmp", 0, "D:\DataSettings\LaserSolder\MachineData\User\Product\RESERVED\Left\TrainImage.bmp")
            HOperatorSet.ReadImage(NewImage, "D:\DataSettings\LaserSolder\MachineData\User\Product\RESERVED\Left\TrainImage.bmp")
            pSourceImage.ReadImage("D:\DataSettings\LaserSolder\MachineData\User\Product\RESERVED\Left\TrainImage.bmp")
            'pSourceImage.Based = CType(NewImage, HImage)
        Catch ex As Exception
            CreateCrossImage = False
        End Try
    End Function
    ''' <summary>
    ''' 自動樣板產生同時產生空白遮罩
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Train()
        Try
            Dim trainedImage As CImage = Nothing : trainedImage = New CImage
            Dim trainedImage1 As CImage = Nothing : trainedImage1 = New CImage
            Dim hTrainRegion As HRegion = Nothing
            Dim hMaskRegion As HRegion = Nothing
            Dim contrast As HTuple = Nothing

            '清空參數
            Call GenMaskImage()
            hMaskRegion = m_TrainImageMask.Based().Threshold(255.0, 255.0)
            trainedImage.Based() = m_TrainImage.Based().ReduceDomain(hMaskRegion)

            Call m_TrainRegion.SetCenterLengthsRotation(m_TrainRegion.CenterX, m_TrainRegion.Centery, m_TrainRegion.Width, m_TrainRegion.Height, 0)
            trainedImage1.Based() = trainedImage.Based().ReduceDomain(m_TrainRegion.Based())

            '自動抓取最佳值
            Dim parameters As HTuple = Nothing : parameters = New HTuple("all")  ' "all", "num_levels", "angle_step", "scale_step", "scale_r_step", "scale_c_step", "optimization", "contrast", "contrast_hyst", "min_size", "min_contrast"
            Dim parameterName As HTuple = Nothing : parameterName = New HTuple()
            Dim parameterValue As HTuple = Nothing : parameterValue = New HTuple()
            Dim numLevels1 As HTuple = Nothing : numLevels1 = New HTuple("auto")
            Dim optimization1 As HTuple = Nothing : optimization1 = New HTuple("auto") ' "auto", "none","point_reduction_low","point_reduction_medium","point_reduction_high","pregeneration","no_pregeneration"
            Dim contrast1 As HTuple = Nothing : contrast1 = New HTuple("auto_contrast_hyst") '"auto", "auto_contrast", "auto_contrast_hyst", "auto_min_size"
            Dim minContrast1 As HTuple = Nothing : minContrast1 = New HTuple("auto")
            Call HOperatorSet.DetermineShapeModelParams(trainedImage1.Based(), numLevels1, AngleStart, AngleExtent, ScaleMin, ScaleMax, optimization1, Metric, contrast1, minContrast1, parameters, parameterName, parameterValue)


            NumLevels.I() = parameterValue.Item(0).I()
            AngleStep.D() = parameterValue.Item(1).D()  '弧度
            ScaleStep.D = parameterValue.Item(2).D()
            Optimization = Nothing : Optimization = New HTuple("auto", "pregeneration")
            ContrastLow.D() = parameterValue.Item(4).D()
            ContrastHigh.D() = parameterValue.Item(5).D()
            MinSize.D() = parameterValue.Item(6).D()
            contrast = New HTuple(ContrastLow, ContrastHigh, MinSize)
            MinContrast.D() = parameterValue.Item(7).D()
            If m_ShapeModel IsNot Nothing Then m_ShapeModel.Dispose()
            If m_NCCModel IsNot Nothing Then m_NCCModel.Dispose()

            Call m_ShapeModel.CreateScaledShapeModel(trainedImage1.Based(), NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Optimization, Metric, contrast, MinContrast)
            Call m_NCCModel.CreateNccModel(trainedImage1.Based(), New HTuple("auto"), AngleStart, AngleExtent, AngleStep, Metric)
            Call HOperatorSet.GetShapeModelParams(m_ShapeModel, NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Metric, MinContrast)
            parameters = Nothing
            parameterName = Nothing
            parameterValue = Nothing

            Call trainedImage.Dispose() : trainedImage = Nothing
            Call trainedImage1.Dispose() : trainedImage1 = Nothing
            Call hMaskRegion.Dispose() : hMaskRegion = Nothing
            contrast = Nothing
            m_Trained = True
        Catch ex As Exception
            m_Trained = False
        End Try
    End Sub
    ''' <summary>
    ''' 自動樣板產生使用設定遮罩
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Train1()
        Try
            Dim trainedImage As CImage = Nothing : trainedImage = New CImage
            Dim trainedImage1 As CImage = Nothing : trainedImage1 = New CImage
            Dim hTrainRegion As HRegion = Nothing
            Dim hMaskRegion As HRegion = Nothing
            Dim contrast As HTuple = Nothing

            '清空參數
            Call GenMaskImage()
            hMaskRegion = m_TrainImageMask.Based().Threshold(255.0, 255.0)
            trainedImage.Based() = m_TrainImage.Based().ReduceDomain(hMaskRegion)

            Call m_TrainRegion.SetCenterLengthsRotation(m_TrainRegion.CenterX, m_TrainRegion.Centery, m_TrainRegion.Width, m_TrainRegion.Height, 0)
            trainedImage1.Based() = trainedImage.Based().ReduceDomain(m_TrainRegion.Based())

            '自動抓取最佳值
            Dim parameters As HTuple = Nothing : parameters = New HTuple("all")  ' "all", "num_levels", "angle_step", "scale_step", "scale_r_step", "scale_c_step", "optimization", "contrast", "contrast_hyst", "min_size", "min_contrast"
            Dim parameterName As HTuple = Nothing : parameterName = New HTuple()
            Dim parameterValue As HTuple = Nothing : parameterValue = New HTuple()
            Dim numLevels1 As HTuple = Nothing : numLevels1 = New HTuple("auto")
            Dim optimization1 As HTuple = Nothing : optimization1 = New HTuple("auto") ' "auto", "none","point_reduction_low","point_reduction_medium","point_reduction_high","pregeneration","no_pregeneration"
            Dim contrast1 As HTuple = Nothing : contrast1 = New HTuple("auto_contrast_hyst") '"auto", "auto_contrast", "auto_contrast_hyst", "auto_min_size"
            Dim minContrast1 As HTuple = Nothing : minContrast1 = New HTuple("auto")
            Call HOperatorSet.DetermineShapeModelParams(trainedImage1.Based(), numLevels1, AngleStart, AngleExtent, ScaleMin, ScaleMax, optimization1, Metric, contrast1, minContrast1, parameters, parameterName, parameterValue)


            NumLevels.I() = parameterValue.Item(0).I()
            AngleStep.D() = parameterValue.Item(1).D()  '弧度
            ScaleStep.D = parameterValue.Item(2).D()
            Optimization = Nothing : Optimization = New HTuple("auto", "pregeneration")
            ContrastLow.D() = parameterValue.Item(4).D()
            ContrastHigh.D() = parameterValue.Item(5).D()
            MinSize.D() = parameterValue.Item(6).D()
            contrast = New HTuple(ContrastLow, ContrastHigh, MinSize)
            MinContrast.D() = parameterValue.Item(7).D()
            If m_ShapeModel IsNot Nothing Then m_ShapeModel.Dispose()
            Call m_ShapeModel.CreateScaledShapeModel(trainedImage1.Based(), NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Optimization, Metric, contrast, MinContrast)
            Call HOperatorSet.GetShapeModelParams(m_ShapeModel, NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Metric, MinContrast)
            parameters = Nothing
            parameterName = Nothing
            parameterValue = Nothing

            Call trainedImage.Dispose() : trainedImage = Nothing
            Call trainedImage1.Dispose() : trainedImage1 = Nothing
            Call hMaskRegion.Dispose() : hMaskRegion = Nothing
            contrast = Nothing
            m_Trained = True
        Catch ex As Exception
            m_Trained = False
        End Try
    End Sub
    ''' <summary>
    ''' 手動樣板產生使用設定遮罩
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Train2()
        Try
            Dim trainedImage As CImage = Nothing : trainedImage = New CImage
            Dim trainedImage1 As CImage = Nothing : trainedImage1 = New CImage
            Dim hTrainRegion As HRegion = Nothing
            Dim hMaskRegion As HRegion = Nothing
            hMaskRegion = m_TrainImageMask.Based().Threshold(255.0, 255.0)
            trainedImage.Based() = m_TrainImage.Based().ReduceDomain(hMaskRegion)
            Dim contrast As HTuple = Nothing : contrast = New HTuple(ContrastLow, ContrastHigh, MinSize)
            If m_ShapeModel IsNot Nothing Then m_ShapeModel.Dispose()
            Call m_ShapeModel.CreateScaledShapeModel(trainedImage.Based(), NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Optimization, Metric, ContrastLow, MinContrast)
            Call HOperatorSet.GetShapeModelParams(m_ShapeModel, NumLevels, AngleStart, AngleExtent, AngleStep, ScaleMin, ScaleMax, ScaleStep, Metric, MinContrast)
            m_Trained = True
        Catch ex As Exception
            m_Trained = False
        End Try
    End Sub
#End Region
End Class
'Public Class CMatchingPatternGray
'    Implements IDisposable
'    Private managedResource As System.ComponentModel.Component
'    Private unmanagedResource As IntPtr
'    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫
'    ' IDisposable 
'    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
'        If Not Me.disposedValue Then
'            If disposing Then
'                ' TODO: 釋放其他狀態 (Managed 物件)。
'                'Call managedResource.Dispose()
'            End If
'            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
'            'unmanagedResource = IntPtr.Zero
'            ' TODO: 將大型欄位設定為 null。
'        End If
'        Me.disposedValue = True
'    End Sub
'#Region " IDisposable Support "
'    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
'    Public Sub Dispose() Implements IDisposable.Dispose
'        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
'        Dispose(True)
'        GC.SuppressFinalize(Me)
'    End Sub
'    Protected Overrides Sub Finalize()
'        Dispose(False)
'        MyBase.Finalize()
'    End Sub
'#End Region
'#Region "CONSTANT"
'#End Region
'#Region "Member"
'    Private m_RotaryAngleDMin As Double
'    Private m_RotaryAngleDMax As Double
'    Private m_RotaryAngleRMin As Double
'    Private m_RotaryAngleRMax As Double
'    Private m_IgnorePolarity As Boolean
'#End Region
'#Region "Constructors && Destructors"
'    Public Sub New()
'        Try
'            m_RotaryAngleDMin = -20 : m_RotaryAngleRMin = m_RotaryAngleDMin / 180 * Math.PI
'            m_RotaryAngleDMax = 20 : m_RotaryAngleRMax = m_RotaryAngleDMax / 180 * Math.PI
'            m_IgnorePolarity = False
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'#End Region
'#Region "Property"
'    Public Property RotaryAngleDMin() As Double
'        Get
'            Return m_RotaryAngleDMin
'        End Get
'        Set(ByVal value As Double)
'            If Not (m_RotaryAngleDMin = value) Then Call SetRotaryRange(value, m_RotaryAngleDMax)
'        End Set
'    End Property
'    Public Property RotaryAngleDMax() As Double
'        Get
'            Return m_RotaryAngleDMax
'        End Get
'        Set(ByVal value As Double)
'            If Not (m_RotaryAngleDMax = value) Then Call SetRotaryRange(m_RotaryAngleDMin, value)
'        End Set
'    End Property
'    Public Property IgnorePolarity() As Boolean
'        Get
'            Return m_IgnorePolarity
'        End Get
'        Set(ByVal value As Boolean)
'            m_IgnorePolarity = value
'        End Set
'    End Property
'#End Region
'#Region "Interface"
'#End Region
'#Region "Events"
'#End Region
'#Region "Methods"
'    ''' <summary>
'    ''' 設定樣板角度(-180~180)
'    ''' </summary>
'    ''' <param name="RotaryAngleDMin"></param>
'    ''' <param name="RotaryAngleDMax"></param>
'    ''' <remarks></remarks>
'    Public Sub SetRotaryRange(ByVal RotaryAngleDMin As Double, ByVal RotaryAngleDMax As Double)
'        Try
'            If RotaryAngleDMin < RotaryAngleDMax Then m_RotaryAngleDMin = RotaryAngleDMin : m_RotaryAngleDMax = RotaryAngleDMax
'            m_RotaryAngleRMin = m_RotaryAngleDMin / 180 * Math.PI
'            m_RotaryAngleRMax = m_RotaryAngleDMax / 180 * Math.PI
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Shared Sub CopyTo(ByVal SrcParam As CTemplateParamGray, ByRef pDstParam As CTemplateParamGray)
'        Try
'            If SrcParam IsNot Nothing Then
'                If pDstParam Is Nothing Then pDstParam = New CTemplateParamGray
'                Call pDstParam.SetRotaryRange(SrcParam.m_RotaryAngleDMin, SrcParam.m_RotaryAngleDMax)
'                pDstParam.m_IgnorePolarity = SrcParam.m_IgnorePolarity
'            Else
'                pDstParam = Nothing
'            End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Sub CopyTo(ByRef pDstParam As CTemplateParamGray)
'        Try
'            If pDstParam Is Nothing Then pDstParam = New CTemplateParamGray
'            Call CTemplateParamGray.CopyTo(Me, pDstParam)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Sub CopyFrom(ByVal SrcParam As CTemplateParamGray)
'        Try
'            If SrcParam IsNot Nothing Then Call CTemplateParamGray.CopyTo(SrcParam, Me)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Function ModifyXmlNode(ByVal specNode As Xml.XmlElement) As Integer
'        'Try
'        '    Call ZngXmler.New_xmlValue(specNode, "MinimumAngle", m_MinimumAngle)
'        '    Call ZngXmler.New_xmlValue(specNode, "MaximumAngle", mMaximumAngle)
'        '    Call ZngXmler.New_xmlValue(specNode, "IgnorePolarity", mIgnorePolarity)

'        '    Return ZngExceptionCodes.NoException

'        'Catch ex As Exception
'        '    Return -1

'        'End Try
'    End Function
'    Friend Function AccessXmlNode(ByVal specNode As Xml.XmlElement) As Integer
'        'Try
'        '    Dim rtnText As String = ""
'        '    Dim allRight As Boolean = False
'        '    Dim objSource As New ZngTempletTrainParams

'        '    If ZngXmler.Get_xmlValue(specNode, "MinimumAngle", rtnText) = 0 Then
'        '        Dim minAngle As Double = Convert.ToDouble(rtnText)
'        '        If ZngXmler.Get_xmlValue(specNode, "MaximumAngle", rtnText) = 0 Then
'        '            Dim maxAngle As Double = Convert.ToDouble(rtnText)
'        '            Call objSource.SetRotaryRange(minAngle, maxAngle)

'        '            If ZngXmler.Get_xmlValue(specNode, "IgnorePolarity", rtnText) = 0 Then
'        '                Try
'        '                    objSource.IgnorePolarity = Convert.ToBoolean(rtnText)
'        '                Catch ex As Exception
'        '                    objSource.IgnorePolarity = False
'        '                End Try

'        '                allRight = True
'        '            End If
'        '        End If
'        '    End If

'        '    If allRight Then
'        '        Call Me.CopyOf(objSource)
'        '        Return ZngExceptionCodes.NoException
'        '    Else
'        '        Call Me.CopyOf(New ZngTempletTrainParams)
'        '        Return 1
'        '    End If

'        'Catch ex As Exception
'        '    Call Me.CopyOf(New ZngTempletTrainParams)
'        '    Return -1

'        'End Try
'    End Function
'#End Region
'End Class
'Public Class CMatchingPatternGeometry
'    Implements IDisposable
'    Private managedResource As System.ComponentModel.Component
'    Private unmanagedResource As IntPtr
'    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫
'    ' IDisposable 
'    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
'        If Not Me.disposedValue Then
'            If disposing Then
'                ' TODO: 釋放其他狀態 (Managed 物件)。
'                'Call managedResource.Dispose()
'            End If
'            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
'            'unmanagedResource = IntPtr.Zero
'            ' TODO: 將大型欄位設定為 null。
'            m_AngleStart = Nothing
'            m_AngleExtent = Nothing
'            m_AngleStep = Nothing
'            m_ScaleMin = Nothing
'            m_ScaleMax = Nothing
'            m_scaleStep = Nothing
'            m_metric = Nothing '"use_polarity"
'            m_numLevels = Nothing
'            m_contrastlow = Nothing
'            m_contrasthigh = Nothing
'            m_minSize = Nothing
'            m_minContrast = Nothing
'            m_optimization = Nothing ' "auto", "pregeneration"
'        End If
'        Me.disposedValue = True
'    End Sub
'#Region " IDisposable Support "
'    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
'    Public Sub Dispose() Implements IDisposable.Dispose
'        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
'        Dispose(True)
'        GC.SuppressFinalize(Me)
'    End Sub
'    Protected Overrides Sub Finalize()
'        Dispose(False)
'        MyBase.Finalize()
'    End Sub
'#End Region
'#Region "CONSTANT"
'    Private Const LIMITED_MINIMUM_SCALE As Double = 75
'    Private Const LIMITED_MAXIMUM_SCALE As Double = 125
'#End Region
'#Region "Member"
'    Private m_xldcontourPattern As HalconDotNet.HXLDCont = Nothing
'    Private m_AngleStart As HTuple = Nothing
'    Private m_AngleExtent As HTuple = Nothing
'    Private m_AngleStep As HTuple = Nothing
'    Private m_ScaleMin As HTuple = Nothing
'    Private m_ScaleMax As HTuple = Nothing
'    Private m_scaleStep As HTuple = Nothing
'    Private m_metric As HTuple = Nothing '"use_polarity"
'    Private m_numLevels As HTuple = Nothing
'    Private m_contrastlow As HTuple = Nothing
'    Private m_contrasthigh As HTuple = Nothing
'    Private m_minSize As HTuple = Nothing
'    Private m_minContrast As HTuple = Nothing
'    Private m_optimization As HTuple = Nothing ' "auto", "pregeneration"
'#End Region
'#Region "Constructors && Destructors"
'    Public Sub New()
'        Try
'            If m_AngleStart Is Nothing Then m_AngleStart = New HTuple(-15 * Math.PI / 180)
'            If m_AngleExtent Is Nothing Then m_AngleExtent = New HTuple(30 * Math.PI / 180)
'            If m_AngleStep Is Nothing Then m_AngleStep = New HTuple(0.0)
'            If m_ScaleMin Is Nothing Then m_ScaleMin = New HTuple(0.98)
'            If m_ScaleMax Is Nothing Then m_ScaleMax = New HTuple(1.02)
'            If m_scaleStep Is Nothing Then m_scaleStep = New HTuple(0.0)
'            If m_metric Is Nothing Then m_metric = New HTuple("use_polarity")
'            If m_numLevels Is Nothing Then m_numLevels = New HTuple(0)
'            If m_contrastlow Is Nothing Then m_contrastlow = New HTuple()
'            If m_contrasthigh Is Nothing Then m_contrasthigh = New HTuple()
'            If m_minSize Is Nothing Then m_minSize = New HTuple()
'            If m_minContrast Is Nothing Then m_minContrast = New HTuple()
'            If m_optimization Is Nothing Then m_optimization = New HTuple("point_reduction_high")
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'#End Region
'#Region "Property"
'    Public Property AngleMin() As Double
'        Get
'            Return m_AngleStart.D()
'        End Get
'        Set(ByVal value As Double)
'            Call SetRotaryRange(value, (m_AngleExtent.D() + value))
'        End Set
'    End Property
'    Public Property AngleMax() As Double
'        Get
'            Return (m_AngleExtent.D() + m_AngleStart.D())
'        End Get
'        Set(ByVal value As Double)
'            Call SetRotaryRange(m_AngleStart.D(), value)
'        End Set
'    End Property

'    Friend Property AngleStart() As HTuple
'        Get
'            Return m_AngleStart
'        End Get
'        Set(ByVal value As HTuple)
'            m_AngleStart = value
'        End Set
'    End Property
'    Friend Property AngleExtent() As HTuple
'        Get
'            Return m_AngleExtent
'        End Get
'        Set(ByVal value As HTuple)
'            m_AngleExtent = value
'        End Set
'    End Property
'    Friend Property AngleStep() As HTuple
'        Get
'            Return m_AngleStep
'        End Get
'        Set(ByVal value As HTuple)
'            m_AngleStep = value
'        End Set
'    End Property
'    Friend Property ScaleMin() As HTuple
'        Get
'            Return m_ScaleMin
'        End Get
'        Set(ByVal value As HTuple)
'            m_ScaleMin = value
'        End Set
'    End Property
'    Friend Property ScaleMax() As HTuple
'        Get
'            Return m_ScaleMax
'        End Get
'        Set(ByVal value As HTuple)
'            m_ScaleMax = value
'        End Set
'    End Property
'    Friend Property ScaleStep() As HTuple
'        Get
'            Return m_scaleStep
'        End Get
'        Set(ByVal value As HTuple)
'            m_scaleStep = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' "use_polarity", "ignore_global_polarity", "ignore_local_polarity", "ignore_color_polarity"
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Friend Property Metric() As HTuple
'        Get
'            Return m_metric
'        End Get
'        Set(ByVal value As HTuple)
'            m_metric = value
'        End Set
'    End Property
'    Friend Property NumLevels() As HTuple
'        Get
'            Return m_numLevels
'        End Get
'        Set(ByVal value As HTuple)
'            m_numLevels = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' "auto", "auto_contrast", "auto_contrast_hyst", "auto_min_size" ,(contrast_low,contrast_high,min_size)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Friend Property ContrastLow() As HTuple
'        Get
'            Return m_contrastlow
'        End Get
'        Set(ByVal value As HTuple)
'            m_contrastlow = value
'        End Set
'    End Property
'    Friend Property ContrastHigh() As HTuple
'        Get
'            Return m_contrasthigh
'        End Get
'        Set(ByVal value As HTuple)
'            m_contrasthigh = value
'        End Set
'    End Property
'    Friend Property MinSize() As HTuple
'        Get
'            Return m_minSize
'        End Get
'        Set(ByVal value As HTuple)
'            m_minSize = value
'        End Set
'    End Property
'    Friend Property MinContrast() As HTuple
'        Get
'            Return m_minContrast
'        End Get
'        Set(ByVal value As HTuple)
'            m_minContrast = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' "pregeneration" 
'    ''' "auto", "none", "point_reduction_low", "point_reduction_medium", "point_reduction_high"
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Friend Property Optimization() As HTuple
'        Get
'            Return m_optimization
'        End Get
'        Set(ByVal value As HTuple)
'            m_optimization = value
'        End Set
'    End Property
'#End Region
'#Region "Interface"
'#End Region
'#Region "Events"
'#End Region
'#Region "Methods"
'    Public Sub SetRotaryRange(ByVal MinInDegree As Double, ByVal MaxInDegree As Double)
'        Try
'            If MinInDegree < MaxInDegree Then
'                m_AngleStart.D() = MinInDegree * Math.PI / 180
'                m_AngleExtent.D() = (MaxInDegree - MinInDegree) * Math.PI / 180
'            End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub

'    Public Sub SetScaledRange(ByVal ScaleMinPercentage As Double, ByVal ScaleMaxPercentage As Double)
'        Try
'            If ScaleMinPercentage < ScaleMaxPercentage Then m_ScaleMin.D() = ScaleMinPercentage / 100 : m_ScaleMax.D() = ScaleMaxPercentage / 100
'            If m_ScaleMin.D() < LIMITED_MINIMUM_SCALE / 100 Then m_ScaleMin.D() = LIMITED_MINIMUM_SCALE / 100
'            If m_ScaleMax.D() > LIMITED_MAXIMUM_SCALE / 100 Then m_ScaleMax.D() = LIMITED_MAXIMUM_SCALE / 100
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Shared Sub CopyTo(ByVal SrcParam As CTemplateParamGeometry, ByRef pDstParam As CTemplateParamGeometry)
'        Try
'            If SrcParam IsNot Nothing Then
'                If pDstParam Is Nothing Then pDstParam = New CTemplateParamGeometry
'                Call pDstParam.SetRotaryRange(SrcParam.m_AngleStart.D(), SrcParam.m_AngleExtent.D())
'                Call pDstParam.SetScaledRange(SrcParam.m_ScaleMin.D(), SrcParam.m_ScaleMax.D())
'                pDstParam.m_AngleStep = SrcParam.m_AngleStep
'                pDstParam.m_scaleStep = SrcParam.m_scaleStep
'                pDstParam.m_metric = SrcParam.m_metric
'                pDstParam.m_numLevels = SrcParam.m_numLevels
'                pDstParam.m_contrastlow = SrcParam.m_contrastlow
'                pDstParam.m_contrasthigh = SrcParam.m_contrasthigh
'                pDstParam.m_minSize = SrcParam.m_minSize
'                pDstParam.m_minContrast = SrcParam.m_minContrast
'                pDstParam.m_optimization = SrcParam.m_optimization
'            Else
'                pDstParam = Nothing
'            End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Sub CopyTo(ByRef pDstParam As CTemplateParamGeometry)
'        Try
'            If pDstParam Is Nothing Then pDstParam = New CTemplateParamGeometry
'            Call CTemplateParamGeometry.CopyTo(Me, pDstParam)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Overloads Sub CopyFrom(ByVal SrcParam As CTemplateParamGeometry)
'        Try
'            If SrcParam IsNot Nothing Then Call CTemplateParamGeometry.CopyTo(SrcParam, Me)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Function ModifyXmlNode(ByVal specNode As Xml.XmlElement) As Integer
'        Try
'            '    Call ZngXmler.New_xmlValue(specNode, "MinimumAngle", mMinimumAngle)
'            '    Call ZngXmler.New_xmlValue(specNode, "MaximumAngle", mMaximumAngle)
'            '    Call ZngXmler.New_xmlValue(specNode, "MinimumScale", mMinimumScale)
'            '    Call ZngXmler.New_xmlValue(specNode, "MaximumScale", mMaximumScale)
'            '    Call ZngXmler.New_xmlValue(specNode, "IgnorePolarity", mIgnorePolarity)

'            '    Call ZngXmler.New_xmlValue(specNode, "AutoEdgeSize", mAutoEdgeSize)
'            '    Call ZngXmler.New_xmlValue(specNode, "AutoThreshold", mAutoThreshold)
'            '    Call ZngXmler.New_xmlValue(specNode, "EdgeThreshold", mEdgeThreshold)
'            '    Call ZngXmler.New_xmlValue(specNode, "MinimumEdgeSize", mMinimumEdgeSize)

'            '    Return ZngExceptionCodes.NoException
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Function
'    Friend Function AccessXmlNode(ByVal specNode As Xml.XmlElement) As Integer
'        Try
'            '    Dim rtnText As String = ""
'            '    Dim allRight As Boolean = False
'            '    Dim objSource As New ZngOutlineTrainParams

'            '    If ZngXmler.Get_xmlValue(specNode, "MinimumAngle", rtnText) = 0 Then
'            '        Dim minValue As Double = Convert.ToDouble(rtnText)
'            '        If ZngXmler.Get_xmlValue(specNode, "MaximumAngle", rtnText) = 0 Then
'            '            Dim maxValue As Double = Convert.ToDouble(rtnText)
'            '            Call objSource.SetRotaryRange(minValue, maxValue)

'            '            If ZngXmler.Get_xmlValue(specNode, "MinimumScale", rtnText) = 0 Then
'            '                minValue = Convert.ToDouble(rtnText)
'            '                If ZngXmler.Get_xmlValue(specNode, "MaximumScale", rtnText) = 0 Then
'            '                    maxValue = Convert.ToDouble(rtnText)
'            '                    Call objSource.SetScaledRange(minValue, maxValue)

'            '                    If ZngXmler.Get_xmlValue(specNode, "IgnorePolarity", rtnText) = 0 Then
'            '                        Try
'            '                            objSource.IgnorePolarity = Convert.ToBoolean(rtnText)
'            '                        Catch ex As Exception
'            '                            objSource.IgnorePolarity = False
'            '                        End Try

'            '                        If ZngXmler.Get_xmlValue(specNode, "AutoEdgeSize", rtnText) = 0 Then
'            '                            Try
'            '                                objSource.AutoEdgeSize = Convert.ToBoolean(rtnText)
'            '                            Catch ex As Exception
'            '                                objSource.AutoEdgeSize = False
'            '                            End Try

'            '                            If ZngXmler.Get_xmlValue(specNode, "AutoThreshold", rtnText) = 0 Then
'            '                                Try
'            '                                    objSource.AutoThreshold = Convert.ToBoolean(rtnText)
'            '                                Catch ex As Exception
'            '                                    objSource.AutoThreshold = False
'            '                                End Try

'            '                                If ZngXmler.Get_xmlValue(specNode, "EdgeThreshold", rtnText) = 0 Then
'            '                                    objSource.EdgeThreshold = Convert.ToInt32(rtnText)
'            '                                    If ZngXmler.Get_xmlValue(specNode, "MinimumEdgeSize", rtnText) = 0 Then
'            '                                        objSource.MinimumEdgeSize = Convert.ToInt32(rtnText)

'            '                                        allRight = True
'            '                                    End If
'            '                                End If
'            '                            End If
'            '                        End If
'            '                    End If
'            '                End If
'            '            End If
'            '        End If
'            '    End If

'            '    If allRight Then
'            '        Call Me.CopyOf(objSource)
'            '        Return ZngExceptionCodes.NoException
'            '    Else
'            '        Call Me.CopyOf(New ZngOutlineTrainParams)
'            '        Return 1
'            '    End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Function
'#End Region
'End Class
Public Class CMatchingResult
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Friend Sub New()

    End Sub
#End Region
#Region "Member"

#End Region
#Region "Property"
    Private m_RotationD As Double
    Public Property RotationD() As Double
        Get
            Return m_RotationD
        End Get
        Friend Set(ByVal value As Double)
            m_RotationD = value
        End Set
    End Property
    Private m_RotationR As Double
    Public Property RotationR() As Double
        Get
            Return m_RotationR
        End Get
        Friend Set(ByVal value As Double)
            m_RotationR = value
        End Set
    End Property
    Private m_Scaling As Double
    Public Property Scaling() As Double
        Get
            Return m_Scaling
        End Get
        Friend Set(ByVal value As Double)
            m_Scaling = value
        End Set
    End Property
    Private m_Score As Double
    Public Property Score() As Double
        Get
            Return m_Score
        End Get
        Friend Set(ByVal value As Double)
            m_Score = value
        End Set
    End Property
    Private m_TranslationX As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationX() As Double
        Get
            Return m_TranslationX
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationX = value
        End Set
    End Property
    Private m_TranslationY As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationY() As Double
        Get
            Return m_TranslationY
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationY = value
        End Set
    End Property
    Private m_TranslationX1 As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationX1() As Double
        Get
            Return m_TranslationX1
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationX1 = value
        End Set
    End Property

    Private m_TranslationX2 As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationX2() As Double
        Get
            Return m_TranslationX2
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationX2 = value
        End Set
    End Property
    Private m_TranslationY1 As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationY1() As Double
        Get
            Return m_TranslationY1
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationY1 = value
        End Set
    End Property

    Private m_TranslationY2 As Double    ' 十字標中心跟著輸出位置跑
    Public Property TranslationY2() As Double
        Get
            Return m_TranslationY2
        End Get
        Friend Set(ByVal value As Double)
            m_TranslationY2 = value
        End Set
    End Property
#End Region

#Region "Events"

#End Region
#Region "Methods"
    Public Function Copy() As CMatchingResult
        Try
            Dim destObj As CMatchingResult
            destObj = New CMatchingResult
            Call Me.CopyTo(destObj)
            Return destObj
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Friend Sub CopyOf(ByVal SrcObj As CMatchingResult)
        If SrcObj IsNot Nothing Then
            Call CMatchingResult.CopyTo(SrcObj, Me)
        End If
    End Sub
    Friend Sub CopyTo(ByRef pDestObj As CMatchingResult)
        Call CMatchingResult.CopyTo(Me, pDestObj)
    End Sub
    Friend Shared Sub CopyTo(ByVal SrcObj As CMatchingResult, ByRef pDestObj As CMatchingResult)
        If Not [Object].ReferenceEquals(SrcObj, pDestObj) Then
            If SrcObj IsNot Nothing Then
                If pDestObj Is Nothing Then pDestObj = New CMatchingResult
                pDestObj.RotationD = SrcObj.RotationD
                pDestObj.RotationR = SrcObj.RotationR
                pDestObj.Scaling = SrcObj.Scaling
                pDestObj.Score = SrcObj.Score
                pDestObj.TranslationX = SrcObj.TranslationX
                pDestObj.TranslationY = SrcObj.TranslationY
            Else
                pDestObj = Nothing
            End If
        End If
    End Sub
#End Region
End Class

Public Class CMatchingResults
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        If m_ResultsList Is Nothing Then m_ResultsList = New List(Of CMatchingResult)
        If m_ShapeList Is Nothing Then m_ShapeList = New CCompositeShape
    End Sub
#End Region
#Region "Member"
    Private m_ResultsList As List(Of CMatchingResult)
#End Region
#Region "Property"
    Public ReadOnly Property Count() As Integer
        Get
            Return m_ResultsList.Count
        End Get
    End Property
    Private m_ShapeList As CCompositeShape
    Public Property GetGraphics(ByVal MatchingToolResultGraphicConstants As enumMatchingToolResultGraphicConstants) As CCompositeShape
        Get
            m_ShapeList.ResultGraphicConstants = MatchingToolResultGraphicConstants
            Return m_ShapeList
        End Get
        Friend Set(ByVal value As CCompositeShape)
            If Not [Object].ReferenceEquals(m_ShapeList, value) Then Call m_ShapeList.Dispose()
            m_ShapeList = value
            m_ShapeList.ResultGraphicConstants = MatchingToolResultGraphicConstants
        End Set
    End Property
    Default Public ReadOnly Property Item(ByVal index As Integer) As CMatchingResult
        Get
            If (index > -1) AndAlso (index < m_ResultsList.Count) Then
                Return m_ResultsList(index)
            Else
                Return Nothing
            End If
        End Get
    End Property
#End Region

#Region "Events"

#End Region
#Region "Methods"
    Friend Sub Add(ByRef item As CMatchingResult)
        Try
            If Not m_ResultsList.Contains(item) Then
                Call m_ResultsList.Add(item)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Friend Sub Clear()
        Call m_ResultsList.Clear()
        For i As Integer = 0 To m_ShapeList.BasedRectangle().Count - 1 Step 1
            Call m_ShapeList.BasedRectangle().Item(i).Dispose()
        Next i
        Call m_ShapeList.BasedRectangle().Clear()
        For i As Integer = 0 To m_ShapeList.BasedReticle().Count - 1 Step 1
            Call m_ShapeList.BasedReticle().Item(i).Dispose()
        Next i
        Call m_ShapeList.BasedReticle().Clear()
        For i As Integer = 0 To m_ShapeList.BasedXLD().Count - 1 Step 1
            Call m_ShapeList.BasedXLD().Item(i).Dispose()
        Next i
        Call m_ShapeList.BasedXLD().Clear()
        m_ShapeList.BasedLineSegment().Clear()
    End Sub
    Public Function Copy() As CMatchingResults
        Try
            Dim regResults As CMatchingResults
            regResults = New CMatchingResults
            Call Me.CopyTo(regResults)
            Return regResults
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Friend Sub CopyOf(ByVal SrcObj As CMatchingResults)
        If SrcObj IsNot Nothing Then
            Call CMatchingResults.CopyTo(SrcObj, Me)
        End If
    End Sub
    Friend Sub CopyTo(ByRef pDestObj As CMatchingResults)
        Call CMatchingResults.CopyTo(Me, pDestObj)
    End Sub
    Friend Shared Sub CopyTo(ByVal SrcObj As CMatchingResults, ByRef pDestObj As CMatchingResults)
        If Not [Object].ReferenceEquals(SrcObj, pDestObj) Then
            If SrcObj IsNot Nothing Then
                If pDestObj IsNot Nothing Then pDestObj = Nothing
                pDestObj = New CMatchingResults
                For i As Integer = 0 To (SrcObj.m_ResultsList.Count - 1)
                    Call pDestObj.m_ResultsList.Add(SrcObj.m_ResultsList(i))
                Next i
            Else
                pDestObj = Nothing
            End If
        End If
    End Sub
    Friend Sub Insert(ByVal index As Integer, ByRef item As CMatchingResult)
        If index > -1 AndAlso index < m_ResultsList.Count Then
            Try
                If Not m_ResultsList.Contains(item) Then
                    Call m_ResultsList.Insert(index, item)
                End If
            Catch ex As Exception
            End Try
        End If
    End Sub
    Friend Sub Remove(ByVal item As CMatchingResult)
        Try
            If item IsNot Nothing Then
                Dim intIndex As Integer = m_ResultsList.IndexOf(item)
                Call RemoveAt(intIndex)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Friend Sub RemoveAt(ByVal index As Integer)
        If index > -1 AndAlso index < m_ResultsList.Count Then
            Try
                Call m_ResultsList.RemoveAt(index)
            Catch ex As Exception
            End Try
        End If
    End Sub
#End Region
End Class
Public Class CMatchingRunParams
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"
#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        Try
            If m_AngleExtent Is Nothing Then m_AngleExtent = New HTuple(CDbl(0))
            If m_AngleStart Is Nothing Then m_AngleStart = New HTuple(CDbl(0))
            If m_ScaleMax Is Nothing Then m_ScaleMax = New HTuple(CDbl(0))
            If m_ScaleMin Is Nothing Then m_ScaleMin = New HTuple(CDbl(0))
            If m_SearchScore Is Nothing Then m_SearchScore = New HTuple(CDbl(0))
            If m_XYOverlap Is Nothing Then m_XYOverlap = New HTuple(CDbl(0))
            Call Me.SetScoreProperty(60, 80)
            Call Me.SetRotaryRange(-5, 5)
            Call Me.SetScaleRange(100, 100)
            Accuracy = enumPixelAccuracy.highest
            AlgorithmSpeed = 0
            ApproximateNumberToFind = 1
            RotaryEnabled = True
            RunTime = 0
            ScaleEnabled = True
            XYOverlap.D() = 0
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub
#End Region
#Region "Member"
#End Region
#Region "Property"
    Private m_AcceptScore As Double
    ''' <summary>
    ''' 合格的分數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property AcceptScore() As Double
        Get
            Return m_AcceptScore * 100
        End Get
    End Property
    Private m_Accuracy As enumPixelAccuracy
    Friend Property Accuracy() As enumPixelAccuracy
        Get
            Return m_Accuracy
        End Get
        Set(ByVal value As enumPixelAccuracy)
            m_Accuracy = value
        End Set
    End Property
    Private m_AlgorithmSpeed As Double
    Friend Property AlgorithmSpeed() As Double
        Get
            Return m_AlgorithmSpeed
        End Get
        Set(ByVal value As Double)
            m_AlgorithmSpeed = value
        End Set
    End Property
    Private m_AngleExtent As HTuple = Nothing
    ''' <summary>
    ''' 找尋角度範圍 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property AngleExtent() As HTuple
        Get
            Return m_AngleExtent
        End Get
    End Property
    Private ReadOnly Property AngleMax() As Double
        Get
            Return (m_AngleStart.D() + m_AngleExtent.D()) * 180 / Math.PI
        End Get
    End Property
    Private ReadOnly Property AngleMin() As Double
        Get
            Return m_AngleStart.D() * 180 / Math.PI
        End Get
    End Property
    Private m_AngleStart As HTuple = Nothing
    ''' <summary>
    ''' 找尋起始角度 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property AngleStart() As HTuple
        Get
            Return m_AngleStart
        End Get
    End Property
    Private m_ApproximateNumberToFind As Integer
    Public Property ApproximateNumberToFind() As Integer
        Get
            Return m_ApproximateNumberToFind
        End Get
        Set(ByVal value As Integer)
            m_ApproximateNumberToFind = value
        End Set
    End Property
    Private m_RotaryEnabled As Boolean
    Public Property RotaryEnabled() As Boolean
        Get
            Return m_RotaryEnabled
        End Get
        Set(ByVal value As Boolean)
            m_RotaryEnabled = value
        End Set
    End Property
    Private m_RunTime As Double
    Public Property RunTime() As Double
        Get
            Return m_RunTime
        End Get
        Friend Set(ByVal value As Double)
            m_RunTime = value
        End Set
    End Property
    Private m_ScaleEnabled As Boolean
    Public Property ScaleEnabled() As Boolean
        Get
            Return m_ScaleEnabled
        End Get
        Set(ByVal value As Boolean)
            m_ScaleEnabled = value
        End Set
    End Property
    Private m_ScaleMax As HTuple = Nothing
    ''' <summary>
    ''' 原比例為1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property ScaleMax() As HTuple
        Get
            Return m_ScaleMax
        End Get
    End Property
    Private ReadOnly Property ScaleMax1() As HTuple
        Get
            Return m_ScaleMax.D() * 100
        End Get
    End Property
    Private m_ScaleMin As HTuple = Nothing
    ''' <summary>
    ''' 原比例為1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property ScaleMin() As HTuple
        Get
            Return m_ScaleMin
        End Get
    End Property
    Private ReadOnly Property ScaleMin1() As Double
        Get
            Return m_ScaleMin.D() * 100
        End Get
    End Property
    Private m_SearchScore As HTuple = Nothing
    ''' <summary>
    ''' specify how much of the model must be visible
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend ReadOnly Property SearchScore() As HTuple
        Get
            Return m_SearchScore
        End Get
    End Property
    Friend ReadOnly Property SearchScore1() As Double
        Get
            Return m_SearchScore.D() * 100
        End Get
    End Property
    Private m_XYOverlap As HTuple = Nothing
    Friend Property XYOverlap() As HTuple
        Get
            Return m_XYOverlap
        End Get
        Set(ByVal value As HTuple)
            If Not [Object].ReferenceEquals(m_XYOverlap, value) Then m_XYOverlap = Nothing
            m_XYOverlap = value
        End Set
    End Property

    Private m_RunType As Integer
    ''' <summary>
    ''' 合格的分數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunType() As Integer
        Get
            Return m_RunType
        End Get
        Set(ByVal value As Integer)
            m_RunType = value
        End Set
    End Property
#End Region
#Region "Interface"

#End Region
#Region "Events"

#End Region
#Region "Methods"
    Friend Sub CopyOf(ByVal SrcObj As CMatchingRunParams)
        If SrcObj IsNot Nothing Then Call CopyTo(SrcObj, Me)
    End Sub
    Friend Overloads Sub CopyTo(ByRef pDstObj As CMatchingRunParams)
        Call CopyTo(Me, pDstObj)
    End Sub
    Friend Overloads Sub CopyTo(ByVal SrcObj As CMatchingRunParams, ByRef pDstObj As CMatchingRunParams)
        If Not [Object].ReferenceEquals(SrcObj, pDstObj) Then
            If SrcObj IsNot Nothing Then
                If pDstObj Is Nothing Then
                    pDstObj = New CMatchingRunParams()
                End If
                pDstObj.Accuracy = SrcObj.Accuracy
                pDstObj.AlgorithmSpeed = SrcObj.AlgorithmSpeed
                pDstObj.ApproximateNumberToFind = SrcObj.ApproximateNumberToFind
                pDstObj.RotaryEnabled = SrcObj.RotaryEnabled
                pDstObj.RunTime = SrcObj.RunTime
                pDstObj.ScaleEnabled = SrcObj.ScaleEnabled
                Call pDstObj.SetRotaryRange(SrcObj.AngleMin, SrcObj.AngleMax)
                Call pDstObj.SetScaleRange(SrcObj.ScaleMin1, SrcObj.ScaleMax1)
                Call pDstObj.SetScoreProperty(SrcObj.SearchScore1, SrcObj.AcceptScore)
                pDstObj.XYOverlap.D() = SrcObj.XYOverlap.D()
            Else
                pDstObj = Nothing
            End If
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' 1.參數 AngleMin 輸入單位為角度
    ''' 2.參數 AngleMax 輸入單位為角度
    ''' </summary>
    ''' <param name="AngleMin"></param>
    ''' <param name="AngleMax"></param>
    ''' <remarks></remarks>
    Public Sub SetRotaryRange(ByVal AngleMin As Double, ByVal AngleMax As Double)
        Try
            If AngleMin > AngleMax Then AngleMin = AngleMax
            m_AngleStart.D() = AngleMin * Math.PI / 180
            m_AngleExtent.D() = (AngleMax - AngleMin) * Math.PI / 180
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub
    ''' <summary> 
    ''' 1.參數 ScaleMin 100表示為原比例
    ''' 2.參數 ScaleMax 100表示為原比例
    ''' </summary>
    ''' <param name="ScaleMin"></param>
    ''' <param name="ScaleMax"></param>
    ''' <remarks></remarks>
    Public Sub SetScaleRange(ByVal ScaleMin As Double, ByVal ScaleMax As Double)
        Try
            If ScaleMin > ScaleMax Then ScaleMin = ScaleMax
            m_ScaleMin.D() = ScaleMin / 100 : m_ScaleMax.D() = ScaleMax / 100
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub

    ''' <summary>
    ''' 1.參數 SearchPencertage 輸入範圍為0-100
    ''' 2.參數 AcceptPercentage 輸入範圍為0-100
    ''' </summary>
    ''' <param name="SearchPencertage"></param>
    ''' <param name="AcceptPercentage"></param>
    ''' <remarks></remarks>
    Public Sub SetScoreProperty(ByVal SearchPencertage As Double, ByVal AcceptPercentage As Double)
        Try
            m_SearchScore.D() = SearchPencertage / 100
            m_AcceptScore = AcceptPercentage / 100
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Critical Error")
        End Try
    End Sub

   
#End Region
End Class

Public Class CMatchingTool
    Inherits CMatchingToolBased
    Implements IMatchingTool
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"

#End Region
#Region "Member"
    Private MCS_SUBPIXEL() As String = {"none", "interpolation", "least_squares", "least_squares_high", "least_squares_very_high", "max_deformation 1", "max_deformation 2", "max_deformation 3", "max_deformation 4", "max_deformation 5", "max_deformation 6"}
    '產生特徵樣板(自動參數調整)
#End Region
#Region "Constructors && Destructors"
    ''' <summary>
    ''' 路徑不含"/"
    ''' </summary>
    ''' <param name="FolderPath"></param>
    ''' <remarks></remarks>
    Public Sub New(ByVal FolderPath As String)
        Try
            m_IsThreadPoolStarted = False
            m_IsThreadPoolFinished = True
            m_FolderPath = FolderPath
            If m_ShapeModel Is Nothing Then m_ShapeModel = New HShapeModel
            If m_NCCModel Is Nothing Then m_NCCModel = New HNCCModel
            If m_InputImage Is Nothing Then m_InputImage = New CImage
            m_IsRunning = False
            If m_Template Is Nothing Then m_Template = New CMatchingPattern(m_ShapeModel, m_NCCModel)
            m_Results = New CMatchingResults
            If m_RunParams Is Nothing Then m_RunParams = New CMatchingRunParams
            If m_SearchRegion Is Nothing Then m_SearchRegion = New CRectangle
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "Run-Time Error")
        End Try
    End Sub
#End Region
#Region "Property"
    Private m_ShapeModel As HShapeModel
    Private m_NCCModel As HNCCModel
    Friend Property Based() As HShapeModel
        Get
            Return m_ShapeModel
        End Get
        Set(ByVal value As HShapeModel)
            If Not [Object].ReferenceEquals(m_ShapeModel, value) Then Call m_ShapeModel.Dispose()
            m_ShapeModel = value
        End Set
    End Property
    Private m_FolderPath As String
    Public Property FolderPath() As String Implements IMatchingTool.FolderPath
        Friend Get
            Return m_FolderPath
        End Get
        Set(ByVal value As String)
            m_FolderPath = value
        End Set
    End Property
    Private WithEvents m_InputImage As CImage
    ''' <summary>
    ''' Search image used to run a PMAlign inspection.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InputImage() As CImage Implements IMatchingTool.InputImage
        Get
            Return m_InputImage
        End Get
        Set(ByVal value As CImage)
            If Not [Object].ReferenceEquals(m_InputImage, value) Then Call m_InputImage.Dispose()
            m_InputImage = value
        End Set
    End Property
    Private m_IsThreadPoolFinished As Boolean
    Private m_IsThreadPoolStarted As Boolean
    Private m_MatchShape As EnumMatchShape = EnumMatchShape.None

    Private m_IsRunning As Boolean
    ''' <summary>
    ''' 確認找尋是否完成
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property IsRunning() As Boolean Implements IMatchingTool.IsRunning
        Get
            Return m_IsRunning
        End Get
    End Property
    Private WithEvents m_Template As CMatchingPattern
    ''' <summary>
    ''' The PMAlign pattern.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Pattern() As CMatchingPattern Implements IMatchingTool.Pattern
        Get
            Return m_Template
        End Get
        Set(ByVal value As CMatchingPattern)
            If Not [Object].ReferenceEquals(m_Template, value) Then Call m_Template.Dispose()
            m_Template = value
        End Set
    End Property
    Private m_Results As CMatchingResults
    ''' <summary>
    ''' 找尋結果
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Results() As CMatchingResults Implements IMatchingTool.Results
        Get
            Return m_Results
        End Get
        Set(ByVal value As CMatchingResults)
            If Not [Object].ReferenceEquals(m_Results, value) Then m_Results = Nothing
            m_Results = value
        End Set
    End Property
    Private m_RunParams As CMatchingRunParams
    ''' <summary>
    ''' The PMAlign run parameters.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RunParams() As CMatchingRunParams Implements IMatchingTool.RunParams
        Get
            Return m_RunParams
        End Get
        Set(ByVal value As CMatchingRunParams)
            If Not [Object].ReferenceEquals(m_RunParams, value) Then Call m_RunParams.Dispose()
            m_RunParams = value
        End Set
    End Property
    Private m_SearchRegion As CRectangle
    ''' <summary>
    ''' Region of interest in the InputImage that is used to locate PMAlign pattern(s). NULL means use entire InputImage. The ICogPMAlignRunParams::SearchRegionMode property specifies exactly how the region will be applied to this image.
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SearchRegion() As IGraphics Implements IMatchingTool.SearchRegion
        Get
            Return m_SearchRegion
        End Get
        Set(ByVal value As IGraphics)
            If Not [Object].ReferenceEquals(m_SearchRegion, value) Then Call m_SearchRegion.Dispose()
            m_SearchRegion = DirectCast(value, CRectangle)
        End Set
    End Property
#End Region
#Region "Interface"

#End Region
#Region "Events"

#End Region
#Region "Methods"
    Protected Overrides Sub AuxMatch(ByVal index As Object)
        Dim resultY As HTuple
        Dim resultX As HTuple
        Dim resultAngleInRad As HTuple
        Dim resultScaleR As HTuple
        Dim resultScaleC As HTuple
        Dim resultScore As HTuple
        Dim img As CImage = Nothing

        Dim timeStart As Double
        Dim x1 As Double
        Dim y1 As Double
        Dim x2 As Double
        Dim y2 As Double
        Try

            m_IsThreadPoolFinished = False
            m_IsThreadPoolStarted = True


            timeStart = 0
            resultY = New HTuple
            resultX = New HTuple
            resultAngleInRad = New HTuple
            resultScaleR = New HTuple
            resultScaleC = New HTuple
            resultScore = New HTuple
            img = New CImage
            If m_SearchRegion Is Nothing Then
                Call img.CopyOf(m_InputImage)
            Else
                With m_SearchRegion
                    Call .SetCenterLengthsRotation(.CenterX, .CenterY, .Width, .Height, .RotationD)
                End With
                img.Based() = m_InputImage.Based().ReduceDomain(m_SearchRegion.Based())
            End If
            With m_RunParams
                If .RunType = 0 Then
                    .ApproximateNumberToFind = 1
                    Call m_NCCModel.FindNccModel(img.Based(), .AngleStart.D(), .AngleExtent.D(), .SearchScore.D(), .ApproximateNumberToFind, .XYOverlap.D(), New HTuple("true"), New HTuple(0), resultY, resultX, resultAngleInRad, resultScore)
                Else
                    If .RotaryEnabled Then
                        If .ScaleEnabled Then
                            m_ShapeModel.FindScaledShapeModel(img.Based(), .AngleStart.D(), .AngleExtent.D(), .ScaleMin.D(), .ScaleMax.D(), .SearchScore.D(), .ApproximateNumberToFind, .XYOverlap.D(), New HTuple(MCS_SUBPIXEL(.Accuracy)), New HTuple(m_Template.NumLevels.I(), 1), .AlgorithmSpeed, resultY, resultX, resultAngleInRad, resultScaleR, resultScore)
                        Else
                            m_ShapeModel.FindShapeModel(img.Based(), .AngleStart.D(), .AngleExtent.D(), .SearchScore.D(), .ApproximateNumberToFind, .XYOverlap.D(), New HTuple(MCS_SUBPIXEL(.Accuracy)), New HTuple(m_Template.NumLevels.I(), 1), .AlgorithmSpeed, resultY, resultX, resultAngleInRad, resultScore)
                        End If
                    Else
                        If .ScaleEnabled Then
                            m_ShapeModel.FindScaledShapeModel(img.Based(), CDbl(0), CDbl(0), .ScaleMin.D(), .ScaleMax.D(), .SearchScore.D(), .ApproximateNumberToFind, .XYOverlap.D(), New HTuple(MCS_SUBPIXEL(.Accuracy)), New HTuple(m_Template.NumLevels.I(), 1), .AlgorithmSpeed, resultY, resultX, resultAngleInRad, resultScaleR, resultScore)
                        Else
                            m_ShapeModel.FindShapeModel(img.Based(), CDbl(0), CDbl(0), .SearchScore.D(), .ApproximateNumberToFind, .XYOverlap.D(), New HTuple(MCS_SUBPIXEL(.Accuracy)), New HTuple(m_Template.NumLevels.I(), 1), .AlgorithmSpeed, resultY, resultX, resultAngleInRad, resultScore)
                        End If
                    End If
                End If
            End With

           
            m_Results.Clear()
            If resultY.Length() > 0 Then

                For idx As Integer = 0 To (resultY.Length() - 1)
                    If resultScore.DArr(idx) >= (m_RunParams.AcceptScore / 100) Then
                        Dim result As CMatchingResult
                        result = New CMatchingResult
                        Select Case m_MatchShape
                            Case EnumMatchShape.Reticle
                                Dim m_NewType As Integer = 0
                                If m_NewType = m_NewType Then
                                    Dim lineFinder As VisionSystem.CStraightEdgeTool
                                    lineFinder = New VisionSystem.CStraightEdgeTool
                                    lineFinder.FindReticle(m_InputImage, resultX.DArr(idx), resultY.DArr(idx), x1, y1, x2, y2)
                                    If lineFinder.Count > 0 Then
                                        result.TranslationX = (lineFinder.Point.OriginX + lineFinder.Point.EndPosX) / 2
                                        result.TranslationY = (lineFinder.Point.OriginY + lineFinder.Point.EndPosY) / 2
                                        If Math.Abs(resultX.DArr(idx) - result.TranslationX) < 15 AndAlso Math.Abs(resultY.DArr(idx) - result.TranslationY) < 15 Then
                                            result.RotationD = resultAngleInRad.DArr(idx) * 180 / Math.PI
                                            result.RotationR = resultAngleInRad.DArr(idx)
                                            ' result.Scale = resultScaleR.DArr(idx)
                                            result.Score = resultScore.DArr(idx)
                                            result.TranslationX1 = x1
                                            result.TranslationY1 = y1
                                            result.TranslationX2 = x2
                                            result.TranslationY2 = y2

                                            m_Results.Add(result)
                                            'Dim contourXld As HalconDotNet.HXLDCont : contourXld = New HalconDotNet.HXLDCont
                                            'Dim homMat2D As HalconDotNet.HHomMat2D : homMat2D = New HalconDotNet.HHomMat2D
                                            'Dim sx As Double = 1
                                            'Dim sy As Double = 1
                                            'Dim px As Double = 0
                                            'Dim py As Double = 0
                                            'Call homMat2D.HomMat2dIdentity()
                                            'homMat2D = homMat2D.HomMat2dScale(sx, sy, px, py)
                                            'homMat2D = homMat2D.HomMat2dTranslate(resultY.DArr(idx), resultX.DArr(idx))
                                            'contourXld = homMat2D.AffineTransContourXld(m_ShapeModel.GetShapeModelContours(1))
                                            'm_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedXLD().Add(contourXld)
                                            'Dim rectangle As CRectangle : rectangle = New CRectangle
                                            'rectangle.SetCenterLengthsRotation(result.TranslationX, result.TranslationY, CType(m_Template.TrainRegion, CRectangle).LengthX, CType(m_Template.TrainRegion, CRectangle).LengthY, result.RotationD)
                                            'm_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedRectangle().Add(rectangle)

                                            Dim line1 As VisionSystem.CLineSegment
                                            line1 = New VisionSystem.CLineSegment
                                            line1.SetCenterLengthAngleDeg(result.TranslationX - img.Width / 8, result.TranslationY1, img.Width / 8, 0)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedLineSegment().Add(line1)

                                            Dim line2 As VisionSystem.CLineSegment
                                            line2 = New VisionSystem.CLineSegment
                                            line2.SetCenterLengthAngleDeg(result.TranslationX + img.Width / 8, result.TranslationY2, img.Width / 8, 0)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedLineSegment().Add(line2)

                                            Dim line3 As VisionSystem.CLineSegment
                                            line3 = New VisionSystem.CLineSegment
                                            line3.SetCenterLengthAngleDeg(result.TranslationX1, result.TranslationY + img.Height / 8, img.Height / 8, 90)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedLineSegment().Add(line3)

                                            Dim line4 As VisionSystem.CLineSegment
                                            line4 = New VisionSystem.CLineSegment
                                            line4.SetCenterLengthAngleDeg(result.TranslationX2, result.TranslationY - img.Height / 8, img.Height / 8, 90)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedLineSegment().Add(line4)

                                            Dim reticle As CReticle : reticle = New CReticle
                                            reticle.X = result.TranslationX
                                            reticle.Y = result.TranslationY
                                            reticle.Length = (CType(m_Template.TrainRegion, CRectangle).LengthX + CType(m_Template.TrainRegion, CRectangle).LengthY) / 16
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedReticle().Add(reticle)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).ResultGraphicConstants = enumMatchingToolResultGraphicConstants.All
                                        End If
                                    End If
                                Else
                                    Dim lineFinder As VisionSystem.CStraightEdgeTool
                                    lineFinder = New VisionSystem.CStraightEdgeTool
                                    lineFinder.FindReticle(m_InputImage, resultX.DArr(idx), resultY.DArr(idx))
                                    If lineFinder.Count > 0 Then
                                        result.TranslationX = (lineFinder.Point.OriginX + lineFinder.Point.EndPosX) / 2
                                        result.TranslationY = (lineFinder.Point.OriginY + lineFinder.Point.EndPosY) / 2
                                        If Math.Abs(resultX.DArr(idx) - result.TranslationX) < 5 AndAlso Math.Abs(resultY.DArr(idx) - result.TranslationY) < 5 Then
                                            result.RotationD = resultAngleInRad.DArr(idx) * 180 / Math.PI
                                            result.RotationR = resultAngleInRad.DArr(idx)
                                            ' result.Scale = resultScaleR.DArr(idx)
                                            result.Score = resultScore.DArr(idx)
                                            m_Results.Add(result)
                                            'Dim contourXld As HalconDotNet.HXLDCont : contourXld = New HalconDotNet.HXLDCont
                                            'Dim homMat2D As HalconDotNet.HHomMat2D : homMat2D = New HalconDotNet.HHomMat2D
                                            'Dim sx As Double = 1
                                            'Dim sy As Double = 1
                                            'Dim px As Double = 0
                                            'Dim py As Double = 0
                                            'Call homMat2D.HomMat2dIdentity()
                                            'homMat2D = homMat2D.HomMat2dScale(sx, sy, px, py)
                                            'homMat2D = homMat2D.HomMat2dTranslate(resultY.DArr(idx), resultX.DArr(idx))
                                            'contourXld = homMat2D.AffineTransContourXld(m_ShapeModel.GetShapeModelContours(1))
                                            'm_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedXLD().Add(contourXld)
                                            'Dim rectangle As CRectangle : rectangle = New CRectangle
                                            'rectangle.SetCenterLengthsRotation(result.TranslationX, result.TranslationY, CType(m_Template.TrainRegion, CRectangle).LengthX, CType(m_Template.TrainRegion, CRectangle).LengthY, result.RotationD)
                                            'm_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedRectangle().Add(rectangle)

                                            Dim reticle1 As CReticle : reticle1 = New CReticle
                                            reticle1.Color = VisionColorConstants.Green
                                            reticle1.X = lineFinder.Point.OriginX
                                            reticle1.Y = lineFinder.Point.OriginY
                                            reticle1.Length = (CType(m_Template.TrainRegion, CRectangle).LengthX + CType(m_Template.TrainRegion, CRectangle).LengthY)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedReticle().Add(reticle1)
                                            Dim reticle2 As CReticle : reticle2 = New CReticle
                                            reticle2.Color = VisionColorConstants.Green
                                            reticle2.X = lineFinder.Point.EndPosX
                                            reticle2.Y = lineFinder.Point.EndPosY
                                            reticle2.Length = (CType(m_Template.TrainRegion, CRectangle).LengthX + CType(m_Template.TrainRegion, CRectangle).LengthY)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedReticle().Add(reticle2)
                                            m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).ResultGraphicConstants = enumMatchingToolResultGraphicConstants.All

                                            Call reticle1.Dispose()
                                        End If

                                    End If
                                End If
                               

                            Case Else
                                With m_RunParams
                                    If .RunType = 0 Then
                                        result.TranslationX = resultX.DArr(idx)
                                        result.TranslationY = resultY.DArr(idx)
                                        result.RotationD = resultAngleInRad.DArr(idx) * 180 / Math.PI
                                        result.RotationR = resultAngleInRad.DArr(idx)
                                        ' result.Scale = resultScaleR.DArr(idx)
                                        result.Score = resultScore.DArr(idx)
                                        m_Results.Add(result)
                                        Dim contourXld As HalconDotNet.HXLDCont : contourXld = New HalconDotNet.HXLDCont
                                        Dim homMat2D As HalconDotNet.HHomMat2D : homMat2D = New HalconDotNet.HHomMat2D
                                        Dim sx As Double = 1
                                        Dim sy As Double = 1
                                        Dim px As Double = 0
                                        Dim py As Double = 0
                                        Call homMat2D.HomMat2dIdentity()
                                        homMat2D = homMat2D.HomMat2dScale(sx, sy, px, py)
                                        homMat2D = homMat2D.HomMat2dTranslate(resultY.DArr(idx), resultX.DArr(idx))
                                        'contourXld = homMat2D.AffineTransContourXld(m_ShapeModel.GetShapeModelContours(1))
                                        'm_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedXLD().Add(contourXld)
                                        Dim rectangle As CRectangle : rectangle = New CRectangle
                                        rectangle.SetCenterLengthsRotation(result.TranslationX, result.TranslationY, CType(m_Template.TrainRegion, CRectangle).LengthX, CType(m_Template.TrainRegion, CRectangle).LengthY, result.RotationD)
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedRectangle().Add(rectangle)

                                        Dim reticle As CReticle : reticle = New CReticle
                                        reticle.X = result.TranslationX
                                        reticle.Y = result.TranslationY
                                        reticle.Length = (CType(m_Template.TrainRegion, CRectangle).LengthX + CType(m_Template.TrainRegion, CRectangle).LengthY) / 2
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedReticle().Add(reticle)
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).ResultGraphicConstants = enumMatchingToolResultGraphicConstants.All
                                    Else
                                        result.TranslationX = resultX.DArr(idx)
                                        result.TranslationY = resultY.DArr(idx)
                                        result.RotationD = resultAngleInRad.DArr(idx) * 180 / Math.PI
                                        result.RotationR = resultAngleInRad.DArr(idx)
                                        ' result.Scale = resultScaleR.DArr(idx)
                                        result.Score = resultScore.DArr(idx)
                                        m_Results.Add(result)
                                        Dim contourXld As HalconDotNet.HXLDCont : contourXld = New HalconDotNet.HXLDCont
                                        Dim homMat2D As HalconDotNet.HHomMat2D : homMat2D = New HalconDotNet.HHomMat2D
                                        Dim sx As Double = 1.2
                                        Dim sy As Double = 1.2
                                        Dim px As Double = 0
                                        Dim py As Double = 0
                                        Dim Angle As Double = 0

                                        Call homMat2D.HomMat2dIdentity()
                                        homMat2D = homMat2D.HomMat2dScale(sx, sy, px, py)

                                        homMat2D = homMat2D.HomMat2dRotate(Angle, px, py)

                                        homMat2D = homMat2D.HomMat2dTranslate(resultY.DArr(idx), resultX.DArr(idx))
                                        contourXld = homMat2D.AffineTransContourXld(m_ShapeModel.GetShapeModelContours(1))
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedXLD().Add(contourXld)

                                        Dim rectangle As CRectangle : rectangle = New CRectangle
                                        rectangle.SetCenterLengthsRotation(result.TranslationX, result.TranslationY, CType(m_Template.TrainRegion, CRectangle).LengthX, CType(m_Template.TrainRegion, CRectangle).LengthY, result.RotationD)
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedRectangle().Add(rectangle)

                                        Dim reticle As CReticle : reticle = New CReticle
                                        reticle.X = result.TranslationX
                                        reticle.Y = result.TranslationY
                                        reticle.Length = (CType(m_Template.TrainRegion, CRectangle).LengthX + CType(m_Template.TrainRegion, CRectangle).LengthY) / 2
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).BasedReticle().Add(reticle)
                                        m_Results.GetGraphics(enumMatchingToolResultGraphicConstants.All).ResultGraphicConstants = enumMatchingToolResultGraphicConstants.All
                                    End If
                                End With
                        End Select
                    End If
                Next
                'result = Nothing
            End If
            resultY = Nothing
            resultX = Nothing
            resultAngleInRad = Nothing
            resultScaleR = Nothing
            resultScaleC = Nothing
            resultScore = Nothing
            Call img.Dispose() : img = Nothing
            m_RunParams.RunTime = 0


        Catch ex As Exception
        End Try
        m_IsRunning = False
        m_IsThreadPoolFinished = True
    End Sub
    Public Sub CopyOf(ByVal SrcObj As CMatchingTool) Implements IMatchingTool.CopyOf
        If SrcObj IsNot Nothing Then
            Call CopyTo(SrcObj, Me)
        End If
    End Sub
    Public Overloads Sub CopyTo(ByRef pDestObj As CMatchingTool) Implements IMatchingTool.CopyTo
        Call CopyTo(Me, pDestObj)
    End Sub
    Friend Overrides Sub CopyTo(ByVal SrcObj As CMatchingTool, ByRef pDestObj As CMatchingTool)
        If Not [Object].ReferenceEquals(SrcObj, pDestObj) Then
            If SrcObj IsNot Nothing Then
                If pDestObj Is Nothing Then
                    pDestObj = New CMatchingTool(FolderPath)
                End If
                pDestObj.FolderPath = SrcObj.FolderPath
                Call SrcObj.InputImage.CopyTo(pDestObj.InputImage)
                Call SrcObj.Pattern.CopyTo(pDestObj.Pattern)
                Call SrcObj.Results.CopyTo(pDestObj.Results)
                Call SrcObj.RunParams.CopyTo(pDestObj.RunParams)
                Call pDestObj.m_SearchRegion.Dispose() : Call SrcObj.m_SearchRegion.CopyTo(pDestObj.m_SearchRegion)
            Else
                pDestObj = Nothing
            End If
        End If
    End Sub
    Public Function ReadFiles() As Integer Implements IMatchingTool.ReadFiles
        Dim xmlDoc As System.Xml.XmlDocument
        Dim rtnText As String = ""
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(m_FolderPath & "\MatchingTool.xml") Then
            xmlDoc = New System.Xml.XmlDocument
            Call xmlDoc.Load(m_FolderPath & "\MatchingTool.xml")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim stemNode As System.Xml.XmlElement
            stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "SearchRegion"), System.Xml.XmlElement)
            With m_SearchRegion
                Dim centerX As Double
                Dim centerY As Double
                Dim lengthX As Double
                Dim lengthY As Double
                Dim rotationD As Double
                If CXmler.GetXmlData(stemNode, "CenterX", 0, rtnText) Then centerX = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "CenterY", 0, rtnText) Then centerY = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "LengthX", 0, rtnText) Then lengthX = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "LengthY", 0, rtnText) Then lengthY = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "RotationD", 0, rtnText) Then rotationD = CDbl(rtnText)
                .SetCenterLengthsRotation(centerX, centerY, lengthX, lengthY, rotationD)
            End With

            stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Template"), System.Xml.XmlElement)
            With m_Template
                Dim angleExtent As Double
                Dim angleStart As Double
                If CXmler.GetXmlData(stemNode, "AngleExtent", 0, rtnText) Then angleExtent = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "AngleStart", 0, rtnText) Then angleStart = CDbl(rtnText)
                .SetRotaryRange(angleStart * Math.PI / 180, (angleStart + angleExtent) * Math.PI / 180)
                If CXmler.GetXmlData(stemNode, "ContrastHigh", 0, rtnText) Then .ContrastHigh = New HTuple(CDbl(rtnText))
                If CXmler.GetXmlData(stemNode, "ContrastLow", 0, rtnText) Then .ContrastLow = New HTuple(CDbl(rtnText))
                If CXmler.GetXmlData(stemNode, "Metric", 0, rtnText) Then .Metric = New HTuple(CStr(rtnText))
                If CXmler.GetXmlData(stemNode, "MinContrast", 0, rtnText) Then .MinContrast = New HTuple(CDbl(rtnText))
                If CXmler.GetXmlData(stemNode, "MinSize", 0, rtnText) Then .MinSize = New HTuple(CDbl(rtnText))
                If CXmler.GetXmlData(stemNode, "NumLevels", 0, rtnText) Then .NumLevels = New HTuple(CInt(rtnText))
                If CXmler.GetXmlData(stemNode, "Optimization", 0, rtnText) Then .Optimization = New HTuple(CStr(rtnText))
                Dim scaleMax As Double
                Dim scaleMin As Double
                If CXmler.GetXmlData(stemNode, "ScaleMax", 0, rtnText) Then scaleMax = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "ScaleMin", 0, rtnText) Then scaleMin = CDbl(rtnText)
                .SetScaleRange(scaleMin * 100, scaleMax * 100)
            End With
            stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "TrainRegion"), System.Xml.XmlElement)
            Dim trainRegion As CRectangle : trainRegion = New CRectangle
            With trainRegion
                Dim centerX As Double
                Dim centerY As Double
                Dim lengthX As Double
                Dim lengthY As Double
                Dim rotationD As Double
                If CXmler.GetXmlData(stemNode, "CenterX", 0, rtnText) Then centerX = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "CenterY", 0, rtnText) Then centerY = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "LengthX", 0, rtnText) Then lengthX = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "LengthY", 0, rtnText) Then lengthY = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "RotationD", 0, rtnText) Then rotationD = CDbl(rtnText)
                Call .SetCenterLengthsRotation(centerX, centerY, lengthX, lengthY, rotationD)
            End With
            m_Template.TrainRegion = trainRegion
            stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "RunParams"), System.Xml.XmlElement)
            With m_RunParams
                Dim acceptScore As Double
                Dim searchScore As Double
                Dim angleExtent As Double
                Dim angleStart As Double
                Dim scaleMax As Double
                Dim scaleMin As Double
                If CXmler.GetXmlData(stemNode, "AcceptScore", 0, rtnText) Then acceptScore = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "Accuracy", 0, rtnText) Then .Accuracy = CType(rtnText, enumPixelAccuracy)
                If CXmler.GetXmlData(stemNode, "AlgorithmSpeed", 0, rtnText) Then .AlgorithmSpeed = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "AngleExtent", 0, rtnText) Then angleExtent = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "AngleStart", 0, rtnText) Then angleStart = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "ApproximateNumberToFind", 0, rtnText) Then .ApproximateNumberToFind = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "RotaryEnabled", 0, rtnText) Then .RotaryEnabled = CBool(rtnText)
                If CXmler.GetXmlData(stemNode, "ScaleEnabled", 0, rtnText) Then .ScaleEnabled = CBool(rtnText)
                If CXmler.GetXmlData(stemNode, "ScaleMax", 0, rtnText) Then scaleMax = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "ScaleMin", 0, rtnText) Then scaleMin = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "SearchScore", 0, rtnText) Then searchScore = CDbl(rtnText)
                If CXmler.GetXmlData(stemNode, "XYOverlap", 0, rtnText) Then .XYOverlap = CDbl(rtnText)
                .RunType = 1
                If CXmler.GetXmlData(stemNode, "RunType", 0, rtnText) Then .RunType = CInt(rtnText)
                .SetRotaryRange(angleStart * Math.PI / 180, (angleStart + angleExtent) * Math.PI / 180)
                .SetScaleRange(scaleMin * 100, scaleMax * 100)
                .SetScoreProperty(searchScore, acceptScore)
            End With
        End If
        Try
            Call m_InputImage.ReadImage(m_FolderPath & "\InputImage.bmp")
            Call m_Template.TrainImage.ReadImage(m_FolderPath & "\TrainImage.bmp")
            Call m_Template.TrainImageMask.ReadImage(m_FolderPath & "\TrainImageMask.bmp")
        Catch ex As Exception
        End Try
    End Function
    ''' <summary>
    ''' 開始搜尋
    ''' </summary>
    ''' <param name="Synchronous"></param>
    ''' <remarks></remarks>
    Public Sub Run(Optional ByVal Synchronous As Boolean = False, Optional ByVal MatchShape As EnumMatchShape = EnumMatchShape.None) Implements IMatchingTool.Run
        Do
        Loop Until m_IsThreadPoolFinished = True
        Do
        Loop Until (Not m_IsRunning)
        m_MatchShape = MatchShape
        m_IsRunning = True
        Call m_Results.Clear()
        If Synchronous Then
            Call AuxMatch(0)
        Else
            Do
            Loop Until m_IsThreadPoolFinished = True
            m_IsThreadPoolStarted = False
            If System.Threading.ThreadPool.QueueUserWorkItem(AddressOf AuxMatch, 0) Then
                Do
                Loop Until m_IsThreadPoolStarted
            End If
        End If
    End Sub
    Public Sub SaveFiles() Implements IMatchingTool.SaveFiles
        Try
            If m_InputImage IsNot Nothing Then m_InputImage.WriteImage(m_FolderPath & "\InputImage.bmp")
            If m_Template.TrainImage IsNot Nothing Then m_Template.TrainImage.WriteImage(m_FolderPath & "\TrainImage.bmp")
            If m_Template.TrainImageMask IsNot Nothing Then m_Template.TrainImageMask.WriteImage(m_FolderPath & "\TrainImageMask.bmp")
        Catch ex As Exception
        End Try
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement

        stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "SearchRegion", 0, nodeAttributes), System.Xml.XmlElement)
        With m_SearchRegion
            Call CXmler.NewXmlValue(stemNode, "CenterX", 0, .CenterX)
            Call CXmler.NewXmlValue(stemNode, "CenterY", 0, .CenterY)
            Call CXmler.NewXmlValue(stemNode, "LengthX", 0, .LengthX)
            Call CXmler.NewXmlValue(stemNode, "LengthY", 0, .LengthY)
            Call CXmler.NewXmlValue(stemNode, "RotationD", 0, .RotationD)
        End With
        stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Template", 0, nodeAttributes), System.Xml.XmlElement)
        With m_Template
            Call CXmler.NewXmlValue(stemNode, "AngleExtent", 0, .AngleExtent.D())
            Call CXmler.NewXmlValue(stemNode, "AngleStart", 0, .AngleStart.D())
            Call CXmler.NewXmlValue(stemNode, "AngleStep", 0, .AngleStep.D())
            Call CXmler.NewXmlValue(stemNode, "ContrastHigh", 0, .ContrastHigh.D())
            Call CXmler.NewXmlValue(stemNode, "ContrastLow", 0, .ContrastLow.D())
            Call CXmler.NewXmlValue(stemNode, "Metric", 0, .Metric.S())
            Call CXmler.NewXmlValue(stemNode, "MinContrast", 0, .MinContrast.D)
            Call CXmler.NewXmlValue(stemNode, "MinSize", 0, .MinSize.D())
            Call CXmler.NewXmlValue(stemNode, "NumLevels", 0, .NumLevels.I())
            Call CXmler.NewXmlValue(stemNode, "Optimization", 0, .Optimization.S())
            Call CXmler.NewXmlValue(stemNode, "ScaleMax", 0, .ScaleMax.D())
            Call CXmler.NewXmlValue(stemNode, "ScaleMin", 0, .ScaleMin.D())
            Call CXmler.NewXmlValue(stemNode, "ScaleStep", 0, .ScaleStep.D())
        End With
        stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "TrainRegion", 0, nodeAttributes), System.Xml.XmlElement)
        Dim trainRegion As CRectangle = CType(m_Template.TrainRegion, CRectangle)
        With trainRegion
            Call CXmler.NewXmlValue(stemNode, "CenterX", 0, .CenterX)
            Call CXmler.NewXmlValue(stemNode, "CenterY", 0, .CenterY)
            Call CXmler.NewXmlValue(stemNode, "LengthX", 0, .LengthX)
            Call CXmler.NewXmlValue(stemNode, "LengthY", 0, .LengthY)
            Call CXmler.NewXmlValue(stemNode, "RotationD", 0, .RotationD)
        End With
        stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "RunParams", 0, nodeAttributes), System.Xml.XmlElement)
        With m_RunParams
            Call CXmler.NewXmlValue(stemNode, "AcceptScore", 0, .AcceptScore)
            Call CXmler.NewXmlValue(stemNode, "Accuracy", 0, .Accuracy)
            Call CXmler.NewXmlValue(stemNode, "AlgorithmSpeed", 0, .AlgorithmSpeed)
            Call CXmler.NewXmlValue(stemNode, "AngleExtent", 0, .AngleExtent.D())
            Call CXmler.NewXmlValue(stemNode, "AngleStart", 0, .AngleStart.D())
            Call CXmler.NewXmlValue(stemNode, "ApproximateNumberToFind", 0, .ApproximateNumberToFind)
            Call CXmler.NewXmlValue(stemNode, "RotaryEnabled", 0, .RotaryEnabled)
            Call CXmler.NewXmlValue(stemNode, "ScaleEnabled", 0, .ScaleEnabled)
            Call CXmler.NewXmlValue(stemNode, "ScaleMax", 0, .ScaleMax.D())
            Call CXmler.NewXmlValue(stemNode, "ScaleMin", 0, .ScaleMin.D())
            Call CXmler.NewXmlValue(stemNode, "SearchScore", 0, .SearchScore1)
            Call CXmler.NewXmlValue(stemNode, "XYOverlap", 0, .XYOverlap.D())
            Call CXmler.NewXmlValue(stemNode, "RunType", 0, .RunType)
        End With
        Call xmlDoc.Save(m_FolderPath & "\MatchingTool.xml")
    End Sub
#End Region
End Class
