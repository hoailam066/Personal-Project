Imports HalconDotNet
Imports ViewROI
Imports System.IO
Imports AForge.Video.FFMPEG
Public Enum enumToolsConst
    Pan = 0
    None = 1
    ZoomIn = 2
    ZoomOut = 4
    Selection = 8
End Enum




Public Class ImageDisplay
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
        Try
            'ImageViewer.Width = Me.Size.Width
            'ImageViewer.Height = Height
            m_HorizontalLine = New HalconDotNet.HObject
            m_VerticalLine = New HalconDotNet.HObject

            If m_StaticGraphicsContainer Is Nothing Then m_StaticGraphicsContainer = New CStaticGraphicsContainer(Me.HWindowControl1)



            If m_Graphics Is Nothing Then m_Graphics = New List(Of CImage)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "myViewer->DispImage")
        End Try
    End Sub
#End Region
#Region "Member"
    Private m_viewPort As HWindowControl
    Private m_viewController As HWndCtrl
    Private m_roiController As ROIController

    Private m_IsCausesValidation As Boolean = False
    Private m_PanToolUsed As Boolean
    Private m_PanStartX As Double
    Private m_PanStartY As Double
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MouseX As Integer
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <remarks></remarks>
    Private m_MouseY As Integer
    Private m_CenterX As Double
    Private m_CenterY As Double
    Private m_Width As Double
    Private m_Height As Double
    ''' <summary>
    ''' 顯示畫面的圖
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ImageR As CImage
    Private m_ImageG As CImage
    Private m_ImageB As CImage
    Private m_HorizontalLine As HalconDotNet.HObject
    Private m_VerticalLine As HalconDotNet.HObject
    Private m_LeftUpperY As Double
    Private m_LeftUpperX As Double
    Private m_RightLowerY As Double
    Private m_RightLowerX As Double
    Public ReadOnly Property LeftUpperY() As Double
        Get
            Return m_LeftUpperY
        End Get
    End Property
    Public ReadOnly Property LeftUpperX() As Double
        Get
            Return m_LeftUpperX
        End Get
    End Property
    Public ReadOnly Property RightLowerY() As Double
        Get
            Return m_RightLowerY
        End Get
    End Property
    Public ReadOnly Property RightLowerX() As Double
        Get
            Return m_RightLowerX
        End Get
    End Property
    Private m_AutoFit As Boolean
    Private m_ActiveTool As enumToolsConst

    Private m_ImagePointCanGet As Boolean = True
    Private m_ImagePoint_X As Double = 0
    Private m_ImagePoint_Y As Double = 0

    Public Property ImagePointCanGet As Boolean
        Get
            Return m_ImagePointCanGet
        End Get
        Set(ByVal value As Boolean)
            m_ImagePointCanGet = value
        End Set
    End Property

    Public Property ImagePoint_X As Double
        Get
            Return m_ImagePoint_X
        End Get
        Set(ByVal value As Double)
            m_ImagePoint_X = value
        End Set
    End Property

    Public Property ImagePoint_Y As Double
        Get
            Return m_ImagePoint_Y
        End Get
        Set(ByVal value As Double)
            m_ImagePoint_Y = value
        End Set
    End Property
#End Region
#Region "Property"
    Private m_pVideoOutNew As System.IntPtr
    Private m_Record As Boolean
    Public Property Record As Boolean
        Get
            Return m_Record
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                m_Record = value
            End If
        End Set
    End Property

    Private m_RecordInit As Boolean
    Public Property RecordInit As Boolean
        Get
            Return m_RecordInit
        End Get
        Set(ByVal value As Boolean)
            m_RecordInit = value
        End Set
    End Property

    Private m_RecordStop As Boolean
    Public Property RecordStop As Boolean
        Get
            Return m_RecordStop
        End Get
        Set(ByVal value As Boolean)
            If Record = True Then
                m_RecordStop = value
            End If
        End Set
    End Property

    Private m_RecordPath As String
    Public Property RecordPath As String
        Get
            Return m_RecordPath
        End Get
        Set(ByVal value As String)
            m_RecordPath = value
        End Set
    End Property

    Private m_RecordIsThreadFinished As Boolean
    Public Property RecordIsThreadFinished As Boolean
        Get
            Return m_RecordIsThreadFinished
        End Get
        Set(ByVal value As Boolean)
            m_RecordIsThreadFinished = value
        End Set
    End Property

    Private m_RecordIsThreadStarted As Boolean
    Public Property RecordIsThreadStarted As Boolean
        Get
            Return m_RecordIsThreadStarted
        End Get
        Set(ByVal value As Boolean)
            m_RecordIsThreadStarted = value
        End Set
    End Property
#End Region
#Region "Delegate"
    Private Delegate Sub InvokeDisplayCallBack(ByVal SrcImage As CImage, ByVal ctrl As HalconDotNet.HWindowControl)
    Private Sub InvokeDisplay(ByVal SrcImage As CImage, ByVal ctrl As HalconDotNet.HWindowControl)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeDisplayCallBack(AddressOf InvokeDisplay)


                Me.Invoke(cb, SrcImage, ctrl)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                Dim firstDisplay As Boolean
                If m_ImageR Is Nothing Then firstDisplay = True
                If m_ImageG IsNot Nothing Then
                    m_ImageG.Dispose() : m_ImageG = Nothing
                End If
                If m_ImageB IsNot Nothing Then
                    m_ImageB.Dispose() : m_ImageB = Nothing
                End If

                If SrcImage IsNot Nothing Then SrcImage.CopyTo(m_ImageR)

                Dim ptr As System.IntPtr
                Dim width As Integer
                Dim height As Integer
                ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
                'Call HWindowControl1.HalconWindow.SetPart(0, 0, height - 1, width - 1)
                Dim imagePart As System.Drawing.Rectangle
                If firstDisplay Then
                    imagePart.X = 0
                    imagePart.Y = 0
                    imagePart.Width = width
                    imagePart.Height = height
                    m_CenterX = (imagePart.X + imagePart.Width) / 2
                    m_CenterY = (imagePart.Y + imagePart.Height) / 2
                    m_Width = imagePart.Width
                    m_Height = imagePart.Height
                    HWindowControl1.ImagePart = imagePart
                End If
                ' Call Me.HWindowControl1.HalconWindow.ClearWindow()


                Dim cnt As HalconDotNet.HTuple = m_ImageR.Based().CountChannels()
                If cnt.I = 3 Then
                    Call Me.HWindowControl1.HalconWindow.DispColor(m_ImageR.Based())
                Else
                    Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
                End If


                Try
                    m_viewController.addIconicVar(m_ImageR.Based())
                    ' viewController.repaint();
                Catch ex As Exception

                End Try




                'HWindowControl1.SetFullImagePart(m_ImageR.Based())
                Call Me.StaticGraphics.AddGraphics()
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "ImageDisplay->InvokeDisplay")
            Call Debug.Assert(False)
        End Try
    End Sub

#End Region
#Region "Events"
    Private Event ImageDisplay_ImageChanged(ByVal SrcImage As CImage)
    Public Event ImageDisplay_MouseDown(ByVal X As Double, ByVal Y As Double)
    Public Event ImageDisplay_MouseMove(ByVal X As Double, ByVal Y As Double)
    Public Event ImageDisplay_MouseUp(ByVal X As Double, ByVal Y As Double)

    Private Sub Display_ImageChanged(ByVal SrcImage As CImage) Handles Me.ImageDisplay_ImageChanged
        'Dim firstDisplay As Boolean
        'Try
        '    If m_ImageR Is Nothing Then firstDisplay = True
        '    If m_ImageG IsNot Nothing Then
        '        m_ImageG.Dispose() : m_ImageG = Nothing
        '    End If
        '    If m_ImageB IsNot Nothing Then
        '        m_ImageB.Dispose() : m_ImageB = Nothing
        '    End If

        '    If SrcImage IsNot Nothing Then SrcImage.CopyTo(m_ImageR)
        '    Dim ptr As System.IntPtr
        '    Dim width As Integer
        '    Dim height As Integer
        '    ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
        '    'Call HWindowControl1.HalconWindow.SetPart(0, 0, height - 1, width - 1)
        '    Dim imagePart As System.Drawing.Rectangle
        '    If firstDisplay Then
        '        imagePart.X = 0
        '        imagePart.Y = 0
        '        imagePart.Width = width
        '        imagePart.Height = height
        '        m_CenterX = (imagePart.X + imagePart.Width) / 2
        '        m_CenterY = (imagePart.Y + imagePart.Height) / 2
        '        m_Width = imagePart.Width
        '        m_Height = imagePart.Height
        '        HWindowControl1.ImagePart = imagePart
        '    End If
        '    ' Call Me.HWindowControl1.HalconWindow.ClearWindow()
        '    Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        '    'HWindowControl1.SetFullImagePart(m_ImageR.Based())
        '    Call Me.StaticGraphics.AddGraphics()
        'Catch ex As Exception
        '    Call MsgBox(ex.Message().Replace("Halcon", "Vision"), MsgBoxStyle.Critical, "ImageDisplay->Display_ImageChanged")
        'End Try
    End Sub
    Private Sub Display_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            HWindowControl1.Width = Me.Width
            HWindowControl1.Height = Me.Height '- ToolStrip1.Height

            m_viewPort = HWindowControl1

            m_viewController = New HWndCtrl(m_viewPort)
            m_roiController = New ROIController()
            m_viewController.useROIController(m_roiController)
            m_viewController.setViewState(HWndCtrl.MODE_VIEW_NONE)

            If m_InteractiveGraphicsContainer Is Nothing Then m_InteractiveGraphicsContainer = New CInteractiveGraphicsContainer(Me.HWindowControl1, Me.m_roiController)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "DisplayControl->Load")
        End Try
    End Sub
#End Region



    '#Region "Methods"
    '    Public Property ActiveTool() As enumToolsConst
    '        Get
    '            Return m_ActiveTool
    '        End Get
    '        Set(ByVal Value As enumToolsConst)
    '            m_ActiveTool = Value
    '        End Set
    '    End Property

    '    Public Sub StartLiveDisplay(ByRef pAcqDCamera As CAcquisition, Optional ByVal sharedMode As Boolean = False)
    '        If (pAcqDCamera IsNot Nothing) Then
    '            'pAcqDCamera.StartLive(m_ImageR, sharedMode)
    '        Else
    '            Call MsgBox("DCamNotSetupDoneException", MsgBoxStyle.Information, "DisplayControl->ClearWindow")
    '        End If
    '    End Sub




    '    'Public ReadOnly Property ActiveGraphics() As CActiveGraphicsContainer
    '    '    Get
    '    '        Return mActiveGraphics
    '    '    End Get
    '    'End Property

    '    'Public ReadOnly Property StaticGraphics() As CStaticGraphicsContainer
    '    '    Get
    '    '        Return mStaticGraphics
    '    '    End Get
    '    'End Property

    '    Friend Property AutoClear() As Boolean
    '        Get
    '            Return True
    '        End Get
    '        Set(ByVal value As Boolean)

    '        End Set
    '    End Property

    '    'Public ReadOnly Property LiveDisplayRunning() As Boolean
    '    '    Get
    '    '        Return mLiveDisplayRunning
    '    '    End Get
    '    'End Property

    '    'Public Property InfoTextVisible() As Boolean
    '    '    Get
    '    '        Return mInfoTextVisible
    '    '    End Get
    '    '    Set(ByVal value As Boolean)
    '    '        If mInfoTextVisible <> value Then
    '    '            If value Then
    '    '                Me.InfoNoneVisible = True

    '    '                If Not myViewer.ShowToolbar Then
    '    '                    myViewer.ShowToolbar = True
    '    '                    myViewer.ToolsShown = WindowsForms.ViewerTools.None
    '    '                End If
    '    '            Else
    '    '                If (Not mToolsBarVisible) AndAlso myViewer.ShowToolbar Then
    '    '                    myViewer.ShowToolbar = False
    '    '                    myViewer.ToolsShown = ConvertToNiToolsGroup(mToolsGroupConst)
    '    '                End If
    '    '            End If

    '    '            infoPanel.Visible = value
    '    '            mInfoTextVisible = value

    '    '            Call Reset_InfoZoomText()
    '    '            Call ShowInfo_Of_ImageRGB(sRegMousePoint)
    '    '        End If
    '    '    End Set
    '    'End Property




    '    Public ReadOnly Property ImageWidth() As Integer
    '        Get
    '            Return CInt(m_ImageR.Width)
    '        End Get
    '    End Property
    '    Public ReadOnly Property ImageHeight() As Integer
    '        Get
    '            Return CInt(m_ImageR.Height)
    '        End Get
    '    End Property

    '    'Public ReadOnly Property IsImageEmpty() As Boolean
    '    '    Get
    '    '        If m_ImageR IsNot Nothing Then
    '    '            Return m_ImageR.IsEmpty
    '    '        Else
    '    '            Return Nothing
    '    '        End If
    '    '    End Get
    '    'End Property

    '    'Public Property Zoom() As Double
    '    '    Get
    '    '        Return myViewer.ZoomInfo.X
    '    '    End Get
    '    '    Set(ByVal value As Double)
    '    '        If Zoom <> value Then
    '    '            myViewer.ZoomInfo.Initialize(value, value)

    '    '            Me.InfoNoneVisible = True
    '    '        End If
    '    '    End Set
    '    'End Property

    '    'Friend Property ScaledW() As Double
    '    '    Get
    '    '        Return myViewer.ZoomInfo.X
    '    '    End Get
    '    '    Set(ByVal value As Double)
    '    '        myViewer.ZoomInfo.X = value
    '    '    End Set
    '    'End Property
    '    'Friend Property ScaledH() As Double
    '    '    Get
    '    '        Return myViewer.ZoomInfo.Y
    '    '    End Get
    '    '    Set(ByVal value As Double)
    '    '        myViewer.ZoomInfo.Y = value
    '    '    End Set
    '    'End Property

    '    'Public Property CenterX() As Double
    '    '    Get
    '    '        Return myViewer.Center.X
    '    '    End Get
    '    '    Set(ByVal value As Double)
    '    '        myViewer.Center.X = value
    '    '    End Set
    '    'End Property
    '    'Public Property CenterY() As Double
    '    '    Get
    '    '        Return myViewer.Center.Y
    '    '    End Get
    '    '    Set(ByVal value As Double)
    '    '        myViewer.Center.Y = value
    '    '    End Set
    '    'End Property

    '    'Public Property AutoFit() As Boolean
    '    '    Get

    '    '        Return myViewer.ZoomToFit
    '    '    End Get
    '    '    Set(ByVal value As Boolean)
    '    '        If myViewer.ZoomToFit <> value Then
    '    '            If value Then
    '    '                Dim oldZoom As Double = Me.Zoom

    '    '                myViewer.ZoomToFit = True

    '    '                If Me.Zoom <> oldZoom Then
    '    '                    Me.InfoNoneVisible = True
    '    '                End If
    '    '            Else
    '    '                myViewer.ZoomToFit = False
    '    '            End If
    '    '        End If
    '    '    End Set
    '    'End Property


    '    'Public Sub SetColor(ByVal color As String)
    '    '    Try
    '    '        Call ImageViewer.HalconWindow.SetColor(color)
    '    '    Catch ex As Exception
    '    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->SetColor") 
    '    '    End Try
    '    'End Sub
    '    Public Sub DispImage(ByVal Image As CImage)
    '        Dim length As Double
    '        Try
    '            length = Image.Width : If Image.Width < Image.Height Then length = Image.Height


    '            Dim hv_lut As HTuple = New HTuple, hv_i As HTuple = New HTuple
    '            Dim ho_ImageInverse As HObject = Nothing
    '            hv_lut = New HTuple()
    '            For hv_i = (New HTuple(0)) To (New HTuple(255)) Step (New HTuple(1))
    '                hv_lut = hv_lut.TupleConcat((New HTuple(255)).TupleSub(hv_i))
    '            Next
    '            HOperatorSet.GenEmptyObj(ho_ImageInverse)

    '            HOperatorSet.LutTrans(Image.Based(), ho_ImageInverse, hv_lut)

    '            Call Me.HWindowControl1.HalconWindow.DispImage(Image.Based())
    '            ' Call ImageViewer.HalconWindow.DispObj(ho_ImageInverse)
    '            HOperatorSet.GenCrossContourXld(m_HorizontalLine, Image.Height / 2, Image.Width / 2, Image.Width, 0)
    '            Call HWindowControl1.HalconWindow.DispObj(m_HorizontalLine)
    '            'Call ImageViewer.HalconWindow.DispObj(m_VerticalLine)




    '            Dim nRotaryRect As CRectangle
    '            For i As Integer = 0 To m_GraphicsList.Count - 1
    '                Dim regCopy As IGraphic = m_GraphicsList.Item(i).Duplicate

    '                nRotaryRect = DirectCast(regCopy, CRectangle)
    '                Try
    '                    Call HWindowControl1.HalconWindow.SetColor("white")
    '                    Call HWindowControl1.HalconWindow.SetDraw("margin")
    '                    Call HWindowControl1.HalconWindow.SetLineWidth(1)
    '                    Call HWindowCtrl.HalconWindow.DispRegion(nRotaryRect.BaseRegion())
    '                    Call HWindowControl1.HalconWindow.SetColor("white")
    '                Catch ex As Exception
    '                    Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DispImage")
    '                End Try
    '            Next


    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DispImage")
    '        End Try
    '    End Sub
    '    Friend Sub DispObj(ByVal objectVal As HalconDotNet.HObject)
    '        Try
    '            Call HWindowControl1.HalconWindow.DispObj(objectVal)
    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DispObj")
    '        End Try
    '    End Sub
    '    Public Sub DispText(ByVal X As Integer, ByVal Y As Integer, ByVal Text As String, Optional ByVal Color As String = "white")
    '        Call HWindowControl1.HalconWindow.SetColor(Color)
    '        Call HWindowControl1.HalconWindow.SetTposition(Y, X)
    '        Call HWindowControl1.HalconWindow.WriteString(Text)
    '        Call HWindowControl1.HalconWindow.SetColor("white")
    '    End Sub
    '    Public Sub DispRegion(ByVal Region As CRectangle, Optional ByVal Color As String = "white", Optional ByVal mode As String = "margin")
    '        Try
    '            Call HWindowControl1.HalconWindow.SetColor(Color)
    '            Call HWindowControl1.HalconWindow.SetDraw(mode)
    '            Call HWindowControl1.HalconWindow.SetLineWidth(1)
    '            Call HWindowCtrl.HalconWindow.DispRegion(Region.BaseRegion())
    '            Call HWindowControl1.HalconWindow.SetColor("white")
    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DispImage")
    '        End Try
    '    End Sub
    '    Public Sub DispCross(ByVal Y As Double, ByVal X As Double, ByVal size As Double, ByVal angle As Double)
    '        Dim xldCross As HalconDotNet.HObject
    '        xldCross = New HalconDotNet.HObject
    '        Try
    '            HOperatorSet.GenCrossContourXld(xldCross, Y, X, size, angle)
    '            Call HWindowControl1.HalconWindow.DispObj(xldCross)
    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DispCross")
    '        End Try
    '        Call xldCross.Dispose() : xldCross = Nothing
    '    End Sub
    '    Public Sub SetPart(ByVal LeftUpperY As Integer, ByVal LeftUpperX As Integer, ByVal RightLowerY As Integer, ByVal RightLowerX As Integer)
    '        Try
    '            m_LeftUpperY = LeftUpperY
    '            m_LeftUpperX = LeftUpperX
    '            m_RightLowerY = RightLowerY
    '            m_RightLowerX = RightLowerX
    '            Call HWindowControl1.HalconWindow.SetPart(LeftUpperY, LeftUpperX, RightLowerY, RightLowerX)
    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->SetPart")
    '        End Try
    '    End Sub
    '    Public Sub SetPart(ByRef pImage As CImage)
    '        Dim imgW As Integer, imgH As Integer
    '        Dim imageType As String = ""
    '        Try
    '            Call pImage.Based().GetImagePointer1(imageType, imgW, imgH)
    '            m_LeftUpperY = 0
    '            m_LeftUpperX = 0
    '            m_RightLowerY = imgH
    '            m_RightLowerX = imgW
    '            Call HWindowControl1.HalconWindow.SetPart(0, 0, imgH, imgW)
    '        Catch ex As Exception
    '            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->SetPart")
    '        End Try
    '    End Sub
    '    Public Sub DispRectangle1(ByVal LeftUpperX As Double, ByVal LeftUpperY As Double, ByVal RightLowerX As Double, ByVal RightLowerY As Double)
    '        HWindowControl1.HalconWindow.DispRectangle1(LeftUpperY, LeftUpperX, RightLowerY, RightLowerX)
    '    End Sub
    '    'Public Sub DrawStaticRectangle1(ByRef LeftUpperY As Double, ByRef LeftUpperX As Double, ByRef RightLowerY As Double, ByRef RightLowerX As Double)
    '    '    Try
    '    '        'Call ImageViewer.HalconWindow.DrawRectangle1(LeftUpperY, LeftUpperX, RightLowerY, RightLowerX)
    '    '        Call ImageViewer.HalconWindow.DrawRectangle1Mod(LeftUpperY, LeftUpperX, RightLowerY, RightLowerX, LeftUpperY, LeftUpperX, RightLowerY, RightLowerX)
    '    '    Catch ex As Exception
    '    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "DisplayControl->DrawRectangle1") 
    '    '    End Try
    '    'End Sub
    '    Public Sub AddInteractiveRectangle1(ByRef LeftUpperX As Double, ByRef LeftUpperY As Double, ByRef RightLowerX As Double, ByRef RightLowerY As Double)
    '        Call HWindowControl1.HalconWindow.DrawRectangle1Mod(LeftUpperY, LeftUpperX, RightLowerY, RightLowerX, LeftUpperY, LeftUpperX, RightLowerY, RightLowerX)
    '    End Sub
    '    Private Sub ImageViewer_HMouseMove(ByVal sender As System.Object, ByVal e As HalconDotNet.HMouseEventArgs) Handles HWindowControl1.HMouseMove
    '        'Dim x As HTuple = Nothing : x = New HTuple()
    '        'Dim y As HTuple = Nothing : y = New HTuple()
    '        'Dim button As HTuple = Nothing : button = New HTuple()
    '        'HOperatorSet.GetMpositionSubPix(ImageViewer.HalconID, y, x, button)
    '        'RaiseEvent DisplayMouseMove(x.D(), y.D())
    '    End Sub
    '    Private Sub ImageViewer_HMouseUp(ByVal sender As Object, ByVal e As HalconDotNet.HMouseEventArgs) Handles HWindowControl1.HMouseUp
    '        'Dim x As HTuple = Nothing : x = New HTuple()
    '        'Dim y As HTuple = Nothing : y = New HTuple()
    '        'Dim button As HTuple = Nothing : button = New HTuple()
    '        'HOperatorSet.GetMpositionSubPix(ImageViewer.HalconID, y, x, button)
    '        'RaiseEvent DisplayMouseUp(x.D(), y.D())
    '    End Sub
    '#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim image As New CImage()
        'image.ReadImage("C:\PM_Die_Out.InputImage1.bmp")
        'Me.DispImage(image)
        'Dim rectangle As New CRectangle()
        'rectangle.GenRectangle1(50, 50, 200, 200)
        'Me.StaticGraphicAdd(rectangle)
        'Me.DispImage(image)
    End Sub
    Public Sub ClearView()
        Try
            Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        Catch ex As Exception
        End Try
    End Sub
    Friend Property Based() As HWindowControl
        Get
            Return HWindowControl1
        End Get
        Set(ByVal value As HWindowControl)
            HWindowControl1 = value
        End Set
    End Property
    ''' <summary>
    ''' Create a copy of this image in a new image. 
    ''' </summary>
    ''' <param name="pDestImage"></param>
    ''' <remarks></remarks>
    Public Sub CopyTo(ByRef pDestImage As CImage)
        Try
            If m_ImageR IsNot Nothing Then Call m_ImageR.CopyTo(pDestImage)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CopyImage")
        End Try
    End Sub
    Public Function HObject2HImage1(ByVal hObj As HObject) As HImage
        Dim image As HImage = New HImage()
        Dim type, width, height, pointer As HTuple
        HOperatorSet.GetImagePointer1(hObj, pointer, type, width, height)
        image.GenImage1(type, width, height, pointer)
        Return image
    End Function

    Public Function HObject2HImage3(ByVal hObj As HObject) As HImage
        Dim image As HImage = New HImage()
        Dim type, width, height, pointerRed, pointerGreen, pointerBlue As HTuple
        HOperatorSet.GetImagePointer3(hObj, pointerRed, pointerGreen, pointerBlue, type, width, height)
        image.GenImage3(type, width, height, pointerRed, pointerGreen, pointerBlue)
        Return image
    End Function

    Private Declare Sub CopyMemory Lib "kernel32" Alias "RtlMoveMemory" (ByVal Destination As Integer, ByRef Source As Integer, ByVal Length As Integer)
    Private Declare Sub CopyMemoryToArr Lib "kernel32 " Alias "RtlMoveMemory " (ByVal Destination() As Byte, ByRef Source As Integer, ByVal Length As Integer)
    Private Declare Sub CopyMemoryToDec Lib "kernel32 " Alias "RtlMoveMemory " (ByRef Destination As Int32, ByVal Source() As Byte, ByVal Length As Integer)
    Private Declare Sub CopyMemoryArrToArr Lib "kernel32 " Alias "RtlMoveMemory " (ByRef Destination() As Byte, ByVal Source() As Byte, ByVal Length As Integer)

    Private Shared Sub HObject2Bpp8(ByVal image As HImage, ByRef res As System.Drawing.Bitmap)
        Try
            Dim hpoint, type, width, height As HTuple
            Const Alpha As Integer = 255
            Dim ptr As Integer() = New Integer(1) {}

            Dim pwidth, pheight As Double
            Dim p_hpoint As HTuple
            p_hpoint = image.GetImagePointer1("int8", pwidth, pheight)

            HOperatorSet.GetImagePointer1(image, hpoint, type, width, height)

            res = New System.Drawing.Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            Dim pal As System.Drawing.Imaging.ColorPalette = res.Palette

            For i As Integer = 0 To 255
                pal.Entries(i) = System.Drawing.Color.FromArgb(Alpha, i, i, i)
            Next

            res.Palette = pal
            Dim rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, width, height)
            Dim bitmapData As Drawing.Imaging.BitmapData = res.LockBits(rect, System.Drawing.Imaging.ImageLockMode.[WriteOnly], System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            Dim PixelSize As Integer = CInt(System.Drawing.Bitmap.GetPixelFormatSize(bitmapData.PixelFormat) / 8)
            ptr(0) = bitmapData.Scan0.ToInt32()
            ptr(1) = hpoint.I

            If pwidth Mod 4 = 0 Then
                CopyMemory(ptr(0), ptr(1), width * height * PixelSize)
            Else

                For i As Integer = 0 To height - 1 - 1
                    ptr(1) += width
                    CopyMemory(ptr(0), ptr(1), width * PixelSize)
                    ptr(0) += bitmapData.Stride
                Next
            End If

            res.UnlockBits(bitmapData)
        Catch ex As Exception
            res = Nothing
            Throw ex
        End Try
    End Sub

    'Private Shared Function HimageToIplImage(ByVal image As HImage, ByRef pImage As Emgu.CV.Structure.MIplImage) As HObject
    'If True Then
    '    Dim Hobj As HObject

    '    If 3 = pImage.nChannels Then
    '        Dim pImageRed, pImageGreen, pImageBlue As Emgu.CV.Structure.MIplImage
    '        pImageRed = Emgu.CV.CvInvoke.cvCreateImage(Emgu.CV.CvInvoke.cvGetSize(pImage.), Emgu.CV.CvEnum.IPL_DEPTH.IPL_DEPTH_8U, 1)


    '        Dim height As Integer = pImage.height
    '        Dim width As Integer = pImage.width

    '        For i As Integer = 0 To height - 1
    '        Next
    '    End If

    '    If 1 = pImage.nChannels Then

    '        For i As Integer = 0 To Height - 1
    '        Next
    '    End If

    '    Return Hobj
    'End If
    'End Function
    'Public Function ConvertBitmapToMat(ByVal bmp As System.Drawing.Bitmap) As OpenCvSharp.Mat
    '    Dim rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height)
    '    Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat)
    '    Dim data As IntPtr = bmpData.Scan0
    '    Dim [step] As Integer = bmpData.Stride
    '    Dim mat As OpenCvSharp.Mat = New OpenCvSharp.Mat(bmp.Height, bmp.Width, OpenCvSharp.MatType.CV_8U, 8)
    '    'Dim mat As OpenCvSharp.Mat = New OpenCvSharp.Mat(bmp.Height, bmp.Width, OpenCvSharp.MatType.CV_32F, 4)
    '    bmp.UnlockBits(bmpData)
    '    Return mat

    'End Function

    Private Class CSharpImpl
        <Obsolete("Please refactor calling code to use normal Visual Basic assignment")>
        Shared Function __Assign(Of T)(ByRef target As T, ByVal value As T) As T
            target = value
            Return value
        End Function
    End Class
    'Public Function ConvertBitmapToMat(ByVal bmp As System.Drawing.Bitmap) As OpenCvSharp.Mat
    '    Dim rect As System.Drawing.Rectangle = New System.Drawing.Rectangle(0, 0, bmp.Width, bmp.Height)
    '    Dim bmpData As System.Drawing.Imaging.BitmapData = bmp.LockBits(rect, System.Drawing.Imaging.ImageLockMode.ReadWrite, bmp.PixelFormat)
    '    Dim data As IntPtr = bmpData.Scan0
    '    Dim [step] As Integer = bmpData.Stride
    '    Dim mat As OpenCvSharp.Mat = New OpenCvSharp.Mat(bmp.Height, bmp.Width, OpenCvSharp.MatType.CV_32F, 4, data, [step])
    '    bmp.UnlockBits(bmpData)
    '    Return mat

    'End Function

    Private Sub ResizeBitmap(ByRef bmp As System.Drawing.Bitmap, ByVal newWidth As Integer, ByVal newHeight As Integer)
        If (newWidth Mod 2 <> 0) Then
            newWidth += 1
        End If
        If (newHeight Mod 2 <> 0) Then
            newHeight += 1
        End If
        Dim brush = New Drawing.SolidBrush(Drawing.Color.White)
        Dim scale = Math.Min(newWidth / bmp.Width, newHeight / bmp.Height)
        Dim scaleWidth = CInt(bmp.Width * scale)
        Dim scaleHeight = CInt(bmp.Height * scale)
        Dim newbmp = New System.Drawing.Bitmap(scaleWidth, scaleHeight)
        Dim graph As Drawing.Graphics = Drawing.Graphics.FromImage(newbmp)
        graph.InterpolationMode = Drawing.Drawing2D.InterpolationMode.High
        graph.CompositingQuality = Drawing.Drawing2D.CompositingQuality.HighQuality
        graph.SmoothingMode = Drawing.Drawing2D.SmoothingMode.AntiAlias
        graph.FillRectangle(brush, New Drawing.RectangleF(0, 0, newWidth, newHeight))
        graph.DrawImage(bmp, New Drawing.Rectangle(0, 0, scaleWidth, scaleHeight))
        bmp.Dispose()
        bmp = Nothing
        bmp = CType(newbmp.Clone(), Drawing.Bitmap)
        graph.Dispose()
        brush.Dispose()
        newbmp.Dispose()
    End Sub
    Private m_pathTmp As String
    Private m_Writer As VideoFileWriter


    Private m_Graphics As List(Of CImage)


    Public Sub CopyOf(ByVal SrcImage As CImage)
        Try
            Call InvokeDisplay(SrcImage, Me.HWindowControl1)
            RaiseEvent ImageDisplay_ImageChanged(SrcImage)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "ImageDisplay->ImageDisplay_ImageChanged")
        End Try

    End Sub

    Public Sub CopyOfRGB(ByVal SrcImageR As CImage, ByVal SrcImageG As CImage, ByVal SrcImageB As CImage, ByVal ImagePart As System.Drawing.Rectangle)
        Dim firstDisplay As Boolean
        Try
            If m_ImageR Is Nothing Then firstDisplay = True
            If SrcImageR IsNot Nothing Then SrcImageR.CopyTo(m_ImageR)
            Dim ptr As System.IntPtr
            Dim width As Integer
            Dim height As Integer

            ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
            'Call HWindowControl1.HalconWindow.SetPart(0, 0, height - 1, width - 1)

            m_CenterX = (ImagePart.X + ImagePart.Width) / 2
            m_CenterY = (ImagePart.Y + ImagePart.Height) / 2
            m_Width = ImagePart.Width
            m_Height = ImagePart.Height
            HWindowControl1.ImagePart = ImagePart

            ' Call Me.HWindowControl1.HalconWindow.ClearWindow()

            Dim imageRGB As CImage : imageRGB = New CImage
            imageRGB.Based() = SrcImageR.Based().Compose3(SrcImageG.Based(), SrcImageB.Based())
            Call Me.HWindowControl1.HalconWindow.DispColor(imageRGB.Based())
            imageRGB.Dispose() : imageRGB = Nothing
            'HWindowControl1.SetFullImagePart(m_ImageR.Based())
            Call Me.StaticGraphics.AddGraphics()
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CopyImage")
        End Try
    End Sub
    ''' <summary>
    ''' Sets whether the image is resized to fit whenever the size of the control changes.
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property AutoFit() As Boolean
        Set(ByVal value As Boolean)
            'HWindowControl1.HWindowControl1.AutoFit = value
        End Set
    End Property
    Private WithEvents m_StaticGraphicsContainer As CStaticGraphicsContainer
    Public Property StaticGraphics() As CStaticGraphicsContainer
        Get
            Return m_StaticGraphicsContainer
        End Get
        Set(ByVal value As CStaticGraphicsContainer)
            m_StaticGraphicsContainer = value
        End Set
    End Property
    Private WithEvents m_InteractiveGraphicsContainer As CInteractiveGraphicsContainer
    Public Property InteractiveGraphics() As CInteractiveGraphicsContainer
        Get
            Return m_InteractiveGraphicsContainer
        End Get
        Set(ByVal value As CInteractiveGraphicsContainer)
            m_InteractiveGraphicsContainer = value
        End Set
    End Property
    Private Shared m_IsLiving As Boolean
    Private Shared m_PauseLive As Boolean
    Private Shared m_IsThreadPoolStarted As Boolean
    Private Shared m_Acquist As CAcquisition
    Private Shared m_CamIdx As Integer
    Public Sub StartLive(ByVal CamIdx As Integer, ByRef pAcquist As CAcquisition)
        Try
            m_CamIdx = CamIdx
            m_Acquist = pAcquist
            If m_IsLiving Then
            Else
                If System.Threading.ThreadPool.QueueUserWorkItem(AddressOf AuxStart, "") Then
                    Do
                    Loop Until m_IsThreadPoolStarted
                Else
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub StopLive()
        Try
            If m_IsThreadPoolStarted = True Then
                If m_IsLiving Then m_PauseLive = True
                Do
                    Call System.Windows.Forms.Application.DoEvents()
                Loop Until (Not m_IsThreadPoolStarted)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Protected Sub AuxStart(ByVal NoParameter As Object)
        Dim timSpan As Double
        Try
            m_IsLiving = True
            m_PauseLive = False
            m_IsThreadPoolStarted = True
            Do
                'Threading.Thread.Sleep(1)
                Dim image As CImage : image = New CImage
                Call m_Acquist.Acquist(m_CamIdx, True)
                m_Acquist.CopyTo(m_CamIdx, image)


                ''''''''''''''''
                Try
                    If m_Record = True AndAlso m_RecordStop = False Then
                        If m_RecordInit = False Then
                            m_RecordInit = True
                            Call m_Graphics.Clear()
                        End If
                        Dim tmpImage = New CImage
                        tmpImage.Based = image.Based().CopyImage
                        If m_Graphics.Count <= 800 Then
                            Call m_Graphics.Add(tmpImage)
                        ElseIf m_Graphics.Count > 800 Then
                            m_RecordStop = True
                        End If
                    End If
                    If m_RecordIsThreadFinished = True Then
                        m_RecordIsThreadFinished = False
                    End If

                    If m_RecordStop = True Then
                        Dim bmpnew As System.Drawing.Bitmap


                        Dim bmpName As String
                        m_pathTmp = Path.Combine(Path.GetTempPath(), "LaserSolder" & "\tmp")
                        If (Directory.Exists(m_pathTmp)) Then
                            Directory.Delete(m_pathTmp, True)
                        End If
                        Directory.CreateDirectory(m_pathTmp)

                        bmpName = m_pathTmp & "\BMP_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".bmp"
                        m_Graphics.Item(0).WriteImage(bmpName)



                        bmpnew = New System.Drawing.Bitmap(bmpName)



                        'ResizeBitmap(bmpnew, HWindowControl1.Width, HWindowControl1.Height)

                        'bmpnew.Dispose()
                        'My.Computer.FileSystem.DeleteFile(bmpName)


                        If (m_RecordPath = "") Then
                            m_RecordPath = "C:\Users\" & Environment.UserName & "\Videos\VID_" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".mp4"
                        End If
                        m_Writer = New VideoFileWriter()
                        m_Writer.Open(m_RecordPath, CInt(bmpnew.Width), CInt(bmpnew.Height), 5, VideoCodec.MPEG4)
                        m_Writer.WriteVideoFrame(bmpnew)
                        bmpnew.Dispose()
                        bmpnew = Nothing
                        My.Computer.FileSystem.DeleteFile(bmpName)
                        m_Graphics.Item(0).Dispose()
                        m_Graphics.Item(0) = Nothing
                        For listIdx As Integer = 1 To m_Graphics.Count - 1
                            If listIdx = 799 Then Dim cc2 As Integer = 1
                            bmpName = m_pathTmp & "\BMP_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".bmp"
                            m_Graphics.Item(listIdx).WriteImage(bmpName)
                            bmpnew = New System.Drawing.Bitmap(bmpName)

                            'ResizeBitmap(bmpnew, HWindowControl1.Width, HWindowControl1.Height)
                            m_Writer.WriteVideoFrame(bmpnew)
                            m_Graphics.Item(listIdx).Dispose()
                            m_Graphics.Item(listIdx) = Nothing
                            bmpnew.Dispose()
                            bmpnew = Nothing
                            My.Computer.FileSystem.DeleteFile(bmpName)
                            Try
                                Call m_Acquist.Acquist(m_CamIdx, True)
                                m_Acquist.CopyTo(m_CamIdx, image)
                                Me.CopyOf(image)
                            Catch ex As Exception

                            End Try
                        Next

                        m_RecordStop = False
                        m_Record = False
                        m_RecordInit = False
                        m_RecordPath = ""

                        m_Writer.Close()
                        m_Writer.Dispose()
                        Directory.Delete(m_pathTmp, True)


                    End If
                Catch ex As Exception
                Finally
                    m_RecordIsThreadFinished = True
                End Try



                '''''''''''''''



                timSpan = timSpan + 1
                If timSpan > 50 Then
                    timSpan = 0
                    'Me.CopyOf(image)
                End If

                Me.CopyOf(image)

                Call image.Dispose() : image = Nothing
            Loop Until m_PauseLive



        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->AuxStart")
        End Try
        m_IsLiving = False
        m_IsThreadPoolStarted = False
    End Sub

    Private Sub HWindowControl1_HMouseDown(ByVal sender As Object, ByVal e As HalconDotNet.HMouseEventArgs)
        Dim x As HTuple = Nothing : x = New HTuple()
        Dim y As HTuple = Nothing : y = New HTuple()
        Dim button As HTuple = Nothing : button = New HTuple()
        Try
            HOperatorSet.GetMpositionSubPix(HWindowControl1.HalconID, y, x, button)
            If m_PanToolUsed Then
                m_PanStartX = x.D()
                m_PanStartY = y.D()
            End If
            RaiseEvent ImageDisplay_MouseDown(x.D(), y.D())
        Catch ex As Exception
        End Try
    End Sub
    Private m_NoEvents As Boolean
    Private Sub HWindowControl1_HMouseMove(ByVal sender As System.Object, ByVal e As HalconDotNet.HMouseEventArgs)
        Dim x As HTuple = Nothing : x = New HTuple()
        Dim y As HTuple = Nothing : y = New HTuple()
        Dim button As HTuple = Nothing : button = New HTuple()
        Try
            If m_ImageR IsNot Nothing Then 'AndAlso m_Repeat > 15 Then
                If Not m_NoEvents Then
                    m_NoEvents = True
                    If m_PanToolUsed Then
                        Try

                            HOperatorSet.GetMpositionSubPix(HWindowControl1.HalconID, y, x, button)
                            ' RaiseEvent Display_MouseMove(x.D(), y.D())
                        Catch ex As Exception
                        End Try
                        'Dim isLiving As Boolean
                        'isLiving = m_IsLiving
                        'If isLiving Then Me.StopLive()

                        If m_PanStartX <> 0 AndAlso m_PanStartY <> 0 Then
                            m_CenterX = m_CenterX - (x.D() - m_PanStartX)
                            m_CenterY = m_CenterY - (y.D() - m_PanStartY)
                            m_PanStartX = x.D()
                            m_PanStartY = y.D()

                            Dim imagePart As System.Drawing.Rectangle
                            imagePart.X = CInt(m_CenterX - m_Width / 2)
                            imagePart.Y = CInt(m_CenterY - m_Height / 2)
                            imagePart.Width = CInt(m_Width)
                            imagePart.Height = CInt(m_Height)
                            HWindowControl1.ImagePart = imagePart
                            Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
                            Call Me.StaticGraphics.AddGraphics()
                            imagePart = Nothing
                        End If
                        'If isLiving Then Me.StartLive(m_CamIdx, m_Acquist)
                    Else
                        HOperatorSet.GetMpositionSubPix(HWindowControl1.HalconID, y, x, button)
                    End If
                    RaiseEvent ImageDisplay_MouseMove(x, y)
                    m_MouseX = CInt(x.D())
                    m_MouseY = CInt(y.D())
                    m_NoEvents = False
                End If
            End If
        Catch ex As Exception

        End Try
        m_NoEvents = False
    End Sub

    Private Sub HWindowControl1_HMouseUp(ByVal sender As Object, ByVal e As HalconDotNet.HMouseEventArgs)

        m_PanToolUsed = False
        m_PanStartX = 0
        m_PanStartY = 0

        Dim x As HTuple = Nothing : x = New HTuple()
        Dim y As HTuple = Nothing : y = New HTuple()
        Dim button As HTuple = Nothing : button = New HTuple()
        Try
            HOperatorSet.GetMpositionSubPix(HWindowControl1.HalconID, y, x, button)
            RaiseEvent ImageDisplay_MouseUp(x.D(), y.D())
        Catch ex As Exception
        End Try
        x = Nothing
        y = Nothing
    End Sub
    Private Sub btnNone_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNone.Click
        m_PanToolUsed = False
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        m_PanToolUsed = True
    End Sub

    Private Sub btnZoomIn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomIn.Click

        'Dim isLiving As Boolean
        'isLiving = m_IsLiving
        'If isLiving Then Me.StopLive()

        m_PanToolUsed = False
        Dim ptr As System.IntPtr
        Dim width As Integer
        Dim height As Integer
        ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
        Dim imagePart As System.Drawing.Rectangle
        imagePart.Width = CInt(m_Width / 2)
        imagePart.Height = CInt(m_Height / 2)
        imagePart.X = CInt(m_CenterX - imagePart.Width / 2)
        imagePart.Y = CInt(m_CenterY - imagePart.Height / 2)

        m_CenterX = imagePart.X + imagePart.Width / 2
        m_CenterY = imagePart.Y + imagePart.Height / 2
        m_Width = imagePart.Width
        m_Height = imagePart.Height
        HWindowControl1.ImagePart = imagePart
        Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        Call Me.StaticGraphics.AddGraphics()
        'If isLiving Then Me.StartLive(m_CamIdx, m_Acquist)
    End Sub

    Private Sub btnZoomOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomOut.Click
        'Dim isLiving As Boolean
        'isLiving = m_IsLiving
        'If isLiving Then Me.StopLive()

        m_PanToolUsed = False
        Dim ptr As System.IntPtr
        Dim width As Integer
        Dim height As Integer
        ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
        Dim imagePart As System.Drawing.Rectangle
        imagePart.Width = CInt(m_Width * 2)
        imagePart.Height = CInt(m_Height * 2)
        imagePart.X = CInt(m_CenterX - imagePart.Width / 2)
        imagePart.Y = CInt(m_CenterY - imagePart.Height / 2)

        m_CenterX = imagePart.X + imagePart.Width / 2
        m_CenterY = imagePart.Y + imagePart.Height / 2
        m_Width = imagePart.Width
        m_Height = imagePart.Height
        HWindowControl1.ImagePart = imagePart
        Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        Call Me.StaticGraphics.AddGraphics()
        'If isLiving Then Me.StartLive(m_CamIdx, m_Acquist)
    End Sub

    Private Sub btnZoomFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomFit.Click
        'Dim isLiving As Boolean
        'isLiving = m_IsLiving
        'If isLiving Then Me.StopLive()
        m_PanToolUsed = False
        Dim ptr As System.IntPtr
        Dim width As Integer
        Dim height As Integer
        ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
        Dim imagePart As System.Drawing.Rectangle
        imagePart.X = 0
        imagePart.Y = 0
        imagePart.Width = width
        imagePart.Height = height

        m_CenterX = (width / 2)
        m_CenterY = (height / 2)
        m_Width = width
        m_Height = height
        HWindowControl1.ImagePart = imagePart
        Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        Call Me.StaticGraphics.AddGraphics()
        'If isLiving Then Me.StartLive(m_CamIdx, m_Acquist)
    End Sub

    Private Sub btnZoom1x_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoom1x.Click
        'Dim isLiving As Boolean
        'isLiving = m_IsLiving
        'If isLiving Then Me.StopLive()

        m_PanToolUsed = False

        Dim ptr As System.IntPtr
        Dim width As Integer
        Dim height As Integer
        ptr = m_ImageR.Based().GetImagePointer1("bmp", width, height)
        Dim imagePart As System.Drawing.Rectangle
        imagePart.X = CInt((width / 2) - (Me.HWindowControl1.Width / 2))
        imagePart.Y = CInt((height / 2) - (Me.HWindowControl1.Height / 2))
        imagePart.Width = Me.HWindowControl1.Width
        imagePart.Height = Me.HWindowControl1.Height

        m_CenterX = (width / 2)
        m_CenterY = (height / 2)
        m_Width = Me.HWindowControl1.Width
        m_Height = Me.HWindowControl1.Height
        HWindowControl1.ImagePart = imagePart
        Call Me.HWindowControl1.HalconWindow.DispImage(m_ImageR.Based())
        Call Me.StaticGraphics.AddGraphics()
        'If isLiving Then Me.StartLive(m_CamIdx, m_Acquist)
    End Sub
    Private m_IsToolShown As Boolean
    Public WriteOnly Property IsToolShown() As Boolean
        Set(ByVal value As Boolean)
            m_IsToolShown = value
            ToolStrip1.Visible = value
            Timer1.Enabled = m_IsToolShown
        End Set
    End Property
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If m_ImageR IsNot Nothing Then
                ToolStripLabel3.Text = m_ImageR.Width.ToString() & "*" & m_ImageR.Height.ToString()
                If m_MouseX <= m_ImageR.Width AndAlso m_MouseX >= 0 Then
                    If m_MouseY <= m_ImageR.Height AndAlso m_MouseY >= 0 Then
                        Dim Grayval As HTuple
                        Dim imageType As HTuple = m_ImageR.Based().CountChannels()
                        Grayval = m_ImageR.Based().GetGrayval(New HTuple(m_MouseY), New HTuple(m_MouseX))
                        ToolStripLabel2.Text = Grayval.I().ToString()
                        ToolStripLabel1.Text = m_MouseX.ToString() & "," & m_MouseY.ToString()
                    End If
                End If
            End If
        Catch ex As Exception
            ex = ex
        End Try
    End Sub

    'Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    '    Me.IsToolShown = True
    '    Dim aquist As CAcquisition
    '    aquist = New CAcquisition
    '    'Me.StartLive(0, aquist)

    '    Call Me.StaticGraphics.Clear()
    '    Dim srcImage As VisionSystem.CImage
    '    srcImage = New VisionSystem.CImage
    '    aquist.Acquist(0, True)
    '    aquist.CopyTo(0, srcImage)
    '    Call Me.CopyOf(srcImage)
    '    Dim trainRegion As VisionSystem.CRectangle = Nothing
    '    trainRegion = New VisionSystem.CRectangle
    '    Call trainRegion.SetCenterLengthsRotation(srcImage.Width / 2, srcImage.Height / 2, srcImage.Width / 4, srcImage.Height / 4, 0)
    '    Call Me.InteractiveGraphics.Add(trainRegion)
    '    Dim m_PatternMatch(0) As VisionSystem.CMatchingTool
    '    m_PatternMatch(0) = New VisionSystem.CMatchingTool("C:\")
    '    Call m_PatternMatch(0).Pattern.TrainImage.CopyOf(srcImage)
    '    m_PatternMatch(0).Pattern.TrainRegion = trainRegion
    '    Call m_PatternMatch(0).Pattern.SetRotaryRange(-5, 5)
    '    Call m_PatternMatch(0).Pattern.SetScaleRange(100, 100)
    '    Call m_PatternMatch(0).Pattern.Train()
    '    Call m_PatternMatch(0).InputImage.CopyOf(srcImage)
    '    Dim searchRegion As VisionSystem.CRectangle = Nothing
    '    searchRegion = New VisionSystem.CRectangle
    '    Call searchRegion.SetCenterLengthsRotation(srcImage.Width / 2, srcImage.Height / 2, srcImage.Width, srcImage.Height, 0)
    '    m_PatternMatch(0).SearchRegion = searchRegion
    '    Call m_PatternMatch(0).RunParams.SetRotaryRange(-5, 5)
    '    Call m_PatternMatch(0).RunParams.SetScaleRange(100, 100)
    '    Call m_PatternMatch(0).RunParams.SetScoreProperty(60, 80)
    '    Call m_PatternMatch(0).Run(True)
    '    If m_PatternMatch(0).Results.Count > 0 Then
    '        Call Me.StaticGraphics.Add(m_PatternMatch(0).Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchRegion + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
    '    End If


    '    Dim cross As VisionSystem.CReticle
    '    cross = New VisionSystem.CReticle
    '    cross.X = 512
    '    cross.Y = 384
    '    cross.Length = 800
    '    Me.StaticGraphics.Add(cross)
    'End Sub

    Private Sub HWindowControl1_HMouseDown_1(ByVal sender As System.Object, ByVal e As HalconDotNet.HMouseEventArgs) Handles HWindowControl1.HMouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If ImagePointCanGet = True Then
                ImagePointCanGet = False
                Dim row As Double = CInt(e.X)
                Dim col As Double = CInt(e.Y)
                ImagePoint_X = row
                ImagePoint_Y = col
                ImagePointCanGet = True
            End If
        End If
        RaiseEvent ImageDisplay_MouseDown(e.X, e.Y)

    End Sub

    Private Sub HWindowControl1_HMouseMove_1(ByVal sender As System.Object, ByVal e As HalconDotNet.HMouseEventArgs) Handles HWindowControl1.HMouseMove
        RaiseEvent ImageDisplay_MouseMove(e.X, e.Y)
    End Sub

    Private Sub HWindowControl1_HMouseUp_1(ByVal sender As System.Object, ByVal e As HalconDotNet.HMouseEventArgs) Handles HWindowControl1.HMouseUp
        RaiseEvent ImageDisplay_MouseUp(e.X, e.Y)
    End Sub
End Class

Public Enum VisionColorConstants
    Yellow = 0
    Green = 1
    Red = 2
End Enum

Public Class CStaticGraphicsContainer
    Private m_Graphics As List(Of IGraphics)
    Private WithEvents m_Display As HWindowControl
    ''' <summary>
    ''' Adds a static graphic to the display.
    ''' </summary>
    ''' <param name="Graphic"></param>
    ''' <remarks></remarks>
    Public Overridable Sub Add(ByVal Graphic As IGraphics)
        m_Graphics.Add(Graphic)
        If TypeOf (Graphic) Is CRectangle Then
            Dim rectangle As CRectangle = CType(Graphic, CRectangle)
            Try
                Call m_Display.HalconWindow.SetColor("green")
                Call m_Display.HalconWindow.SetDraw("margin")
                Call m_Display.HalconWindow.SetLineWidth(1)
                Call m_Display.HalconWindow.DispRegion(rectangle.Based())
                Call m_Display.HalconWindow.SetColor("green")
            Catch ex As Exception
                Dim errCode As String
                errCode = ex.Message.Replace("HALCON", "")
                Call MsgBox(errCode, MsgBoxStyle.Critical, "CStaticGraphicsContainer->Add")
            End Try
        ElseIf TypeOf (Graphic) Is CReticle Then
            Dim pointMarker As CReticle = CType(Graphic, CReticle)
            Call m_Display.HalconWindow.SetColor("yellow")
            Call m_Display.HalconWindow.SetDraw("margin")
            Call m_Display.HalconWindow.SetLineWidth(1)
            Dim xldCont As HXLDCont
            xldCont = New HXLDCont
            xldCont.GenCrossContourXld(pointMarker.Y, pointMarker.X, pointMarker.Length, pointMarker.AngleRad)
            Call m_Display.HalconWindow.DispXld(xldCont)
            Call xldCont.Dispose() : xldCont = Nothing
            Call m_Display.HalconWindow.SetColor("white")
        ElseIf TypeOf (Graphic) Is CLineSegment Then
            Dim line As CLineSegment = CType(Graphic, CLineSegment)
            Try
                Call m_Display.HalconWindow.SetColor("green")
                Call m_Display.HalconWindow.SetDraw("margin")
                Call m_Display.HalconWindow.SetLineWidth(1)
                Call m_Display.HalconWindow.DispLine(line.OriginY, line.OriginX, line.EndPosY, line.EndPosX)
                Call m_Display.HalconWindow.SetColor("green")
            Catch ex As Exception
                Dim errCode As String
                errCode = ex.Message.Replace("HALCON", "")
                Call MsgBox(errCode, MsgBoxStyle.Critical, "CStaticGraphicsContainer->Add")
            End Try
        ElseIf TypeOf (Graphic) Is CCompositeShape Then
            Dim compositeShape As CCompositeShape = CType(Graphic, CCompositeShape)
            Call m_Display.HalconWindow.SetColor("red")
            Call m_Display.HalconWindow.SetDraw("margin")
            Call m_Display.HalconWindow.SetLineWidth(1)
            For i As Integer = 0 To compositeShape.BasedXLD().Count - 1
                If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchFeatures) = enumMatchingToolResultGraphicConstants.MatchFeatures Then
                    Call m_Display.HalconWindow.DispXld(compositeShape.BasedXLD().Item(i))
                End If
            Next
            For i As Integer = 0 To compositeShape.BasedRectangle().Count - 1
                If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchRegion) = enumMatchingToolResultGraphicConstants.MatchRegion Then
                    Call m_Display.HalconWindow.DispXld(compositeShape.BasedRectangle().Item(i).Based())
                End If
            Next
            Dim xldCont As HXLDCont
            xldCont = New HXLDCont
            For i As Integer = 0 To compositeShape.BasedReticle().Count - 1
                If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchRegion) = enumMatchingToolResultGraphicConstants.MatchRegion Then
                    xldCont.GenCrossContourXld(compositeShape.BasedReticle().Item(i).Y, compositeShape.BasedReticle().Item(i).X, compositeShape.BasedReticle().Item(i).Length, compositeShape.BasedReticle().Item(i).AngleRad)
                    Call m_Display.HalconWindow.DispXld(xldCont)
                End If
            Next
            For i As Integer = 0 To compositeShape.BasedLineSegment().Count - 1
                If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchRegion) = enumMatchingToolResultGraphicConstants.MatchRegion Then
                    Call m_Display.HalconWindow.DispLine(compositeShape.BasedLineSegment().Item(i).OriginY, compositeShape.BasedLineSegment().Item(i).OriginX, compositeShape.BasedLineSegment().Item(i).EndPosY, compositeShape.BasedLineSegment().Item(i).EndPosX)
                End If
            Next
            Call xldCont.Dispose() : xldCont = Nothing
            Call m_Display.HalconWindow.SetColor("white")
        End If
    End Sub
    ''' <summary>
    ''' Adds a list of static graphics to the display.
    ''' </summary>
    ''' <param name="GraphicsList"></param>
    ''' <remarks></remarks>
    Friend Overridable Sub AddList(ByVal GraphicsList As List(Of CGraphicsList))
        'Dim idx As Integer
        'For idx = 0 To GraphicsList.Count - 1
        '    Call m_Display.HalconWindow.StaticGraphics.Add(GraphicsList.Item(idx).Based(), "")
        'Next
    End Sub
    Public Sub Clear()
        Try
            m_Graphics.Clear()
        Catch ex As Exception

        End Try
    End Sub
    Public Overridable Sub Remove(ByVal groupName As String)

    End Sub
    Friend Sub New(ByRef pDisplay As HWindowControl)
        m_Display = pDisplay
        m_Graphics = New List(Of IGraphics)
        m_Graphics.Clear()
    End Sub
    Friend Sub AddGraphics()
        If Not (m_Graphics.Count = 0) Then
            For idx As Integer = 0 To (m_Graphics.Count - 1)
                If TypeOf (m_Graphics.Item(idx)) Is CRectangle Then
                    Dim rectangle As CRectangle = CType(m_Graphics.Item(idx), CRectangle)
                    Try
                        Call m_Display.HalconWindow.SetColor("white")
                        Call m_Display.HalconWindow.SetDraw("margin")
                        Call m_Display.HalconWindow.SetLineWidth(1)
                        Call m_Display.HalconWindow.DispRegion(rectangle.Based())
                        Call m_Display.HalconWindow.SetColor("white")
                    Catch ex As Exception
                        Dim errCode As String
                        errCode = ex.Message.Replace("HALCON", "")
                        Call MsgBox(errCode, MsgBoxStyle.Critical, "CStaticGraphicsContainer->Add")
                    End Try
                ElseIf TypeOf (m_Graphics.Item(idx)) Is CReticle Then
                    Dim pointMarker As CReticle = CType(m_Graphics.Item(idx), CReticle)
                    Call m_Display.HalconWindow.SetColor("yellow")
                    Call m_Display.HalconWindow.SetDraw("margin")
                    Call m_Display.HalconWindow.SetLineWidth(1)
                    Dim xldCont As HXLDCont
                    xldCont = New HXLDCont
                    xldCont.GenCrossContourXld(pointMarker.Y, pointMarker.X, pointMarker.Length, pointMarker.AngleRad)
                    Call m_Display.HalconWindow.DispXld(xldCont)
                    Call xldCont.Dispose() : xldCont = Nothing
                    Call m_Display.HalconWindow.SetColor("white")
                ElseIf TypeOf (m_Graphics.Item(idx)) Is CCompositeShape Then
                    Dim compositeShape As CCompositeShape = CType(m_Graphics.Item(idx), CCompositeShape)
                    Call m_Display.HalconWindow.SetColor("red")
                    Call m_Display.HalconWindow.SetDraw("margin")
                    Call m_Display.HalconWindow.SetLineWidth(1)
                    For i As Integer = 0 To compositeShape.BasedXLD().Count - 1
                        If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchFeatures) = enumMatchingToolResultGraphicConstants.MatchFeatures Then
                            Call m_Display.HalconWindow.DispXld(compositeShape.BasedXLD().Item(i))
                        End If
                    Next
                    For i As Integer = 0 To compositeShape.BasedRectangle().Count - 1
                        If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchRegion) = enumMatchingToolResultGraphicConstants.MatchRegion Then
                            Call m_Display.HalconWindow.DispXld(compositeShape.BasedRectangle().Item(i).Based())
                        End If
                    Next
                    Dim xldCont As HXLDCont
                    xldCont = New HXLDCont
                    For i As Integer = 0 To compositeShape.BasedReticle().Count - 1
                        If (compositeShape.ResultGraphicConstants And enumMatchingToolResultGraphicConstants.MatchRegion) = enumMatchingToolResultGraphicConstants.MatchRegion Then
                            xldCont.GenCrossContourXld(compositeShape.BasedReticle().Item(i).Y, compositeShape.BasedReticle().Item(i).X, compositeShape.BasedReticle().Item(i).Length, compositeShape.BasedReticle().Item(i).AngleRad)
                            Call m_Display.HalconWindow.DispXld(xldCont)
                        End If
                    Next
                    Call xldCont.Dispose() : xldCont = Nothing
                    Call m_Display.HalconWindow.SetColor("white")
                End If
            Next
        End If
    End Sub
End Class
Public Class CInteractiveGraphicsContainer
    Private WithEvents m_Display As HWindowControl
    Private m_ROIController As ROIController
    Friend Sub New(ByRef pDisplay As HWindowControl, ByRef pROIController As ROIController)
        m_Display = pDisplay
        m_ROIController = pROIController
    End Sub

    Public Overridable Sub Add1(ByRef pRect As ROIRectangle1)


        m_ROIController.setROIShape(pRect)
        m_ROIController.mouseDownAction(253, 195) '360 ,270
        'm_ROIController.paintData(m_Display.HalconWindow)
    End Sub
    ''' <summary>
    ''' Adds a interactive graphic to the display.
    ''' </summary>
    ''' <param name="Graphic"></param>
    ''' <remarks></remarks>
    Public Overridable Sub Add(ByVal Graphic As CGraphics)
        If TypeOf (Graphic) Is CRectangle Then
            Dim rectangle As CRectangle = CType(Graphic, CRectangle)
            Try
                Dim leftUpperX As Double
                Dim leftUpperY As Double
                Dim rightLowerX As Double
                Dim rightLowerY As Double
                Call m_Display.HalconWindow.SetColor("red")
                Call m_Display.HalconWindow.SetDraw("margin")
                Call m_Display.HalconWindow.SetLineWidth(1)
                Call m_Display.HalconWindow.DrawRectangle1Mod(rectangle.LeftUpperY, rectangle.LeftUpperX, rectangle.RightLowerY, rectangle.RightLowerX, leftUpperY, leftUpperX, rightLowerY, rightLowerX)
                Call rectangle.SetCenterLengthsRotation((leftUpperX + rightLowerX) / 2, (leftUpperY + rightLowerY) / 2, (rightLowerX - leftUpperX), (rightLowerY - leftUpperY), 0)
                Call m_Display.HalconWindow.SetColor("red")
            Catch ex As Exception
                Dim errCode As String
                errCode = ex.Message.Replace("HALCON", "")
                Call MsgBox(errCode, MsgBoxStyle.Critical, "CInteractiveGraphicsContainer->Add")
            End Try
            'ElseIf TypeOf (Graphic) Is CReticle Then
            '    Dim pointMarker As CReticle = CType(Graphic, CReticle)
            '    Dim m_LineH As CogLineSegment : m_LineH = New CogLineSegment
            '    Dim m_LineV As CogLineSegment : m_LineV = New CogLineSegment
            '    m_LineH.SetStartLengthRotation(pointMarker.CenterX - pointMarker.Length / 2, pointMarker.CenterY, pointMarker.Length, pointMarker.AngleRad)
            '    m_LineH.Color = CogColorConstants.Blue
            '    m_LineH.LineStyle = CogGraphicLineStyleConstants.DashDotDot

            '    m_LineV.SetStartLengthRotation(pointMarker.CenterX, pointMarker.CenterY - pointMarker.Length / 2, pointMarker.Length, pointMarker.AngleRad + Math.PI / 2)
            '    m_LineV.Color = CogColorConstants.Blue
            '    m_LineV.LineStyle = CogGraphicLineStyleConstants.DashDotDot
            '    m_Display.StaticGraphics.Add(m_LineH, "")
            '    m_Display.StaticGraphics.Add(m_LineV, "")
        End If
    End Sub

    Public Sub Clear()
        Try

            m_ROIController.reset()
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CInteractiveGraphicsContainer->Clear")
        End Try
    End Sub
End Class