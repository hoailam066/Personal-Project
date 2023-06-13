Imports HalconDotNet
Imports Xmler

Friend Enum enumVendorID
    Empty = -1
    BaslerScout = 1
    BaslerAce = 2
    Sony = 3
    ToshibaTeli = 4
    PointGreyResearch = 5
End Enum
Public Interface IAcquisition
    ReadOnly Property CameraCount() As Integer
    Property Exposure(ByVal CameraIdx As Integer) As Double
    Property Brightness(ByVal CameraIdx As Integer) As Double
    Property Contrast(ByVal CameraIdx As Integer) As Double
    ReadOnly Property IsAcquiring(ByVal CameraIdx As Integer) As Boolean
    ReadOnly Property AcqReceived(ByVal CameraIdx As Integer) As Boolean
    Function Acquist(ByVal CameraIdx As Integer, Optional ByVal syncMode As Boolean = False) As Integer
    Sub CopyTo(ByVal CameraIdx As Integer, ByRef pDestImage As CImage)
End Interface
Friend Interface IDigCamera
    Property Exposure() As Double
    Property Brightness() As Double
    Property Contrast() As Double
    ReadOnly Property IsAcquiring() As Boolean
    ReadOnly Property AcqReceived() As Boolean
    Sub CopyTo(ByRef pDestImage As CImage)
    ReadOnly Property AcquistTime() As Double
    ReadOnly Property DCamInfo() As CDigCameraInfo
    Function Acquist(Optional ByVal syncMode As Boolean = False) As Integer
End Interface
Friend MustInherit Class CDigCameraBased
    Protected MustOverride Sub AuxStart(ByVal NoParameter As Object)
End Class
Friend Class CDigCameraInfo
    Private m_Model As String
    Private m_Vendor As String
    Private m_VendID As enumVendorID
    Private m_CamNo As Integer
    Private m_SNCode As String
    Private m_RotateImageDegree As Double
    Friend Sub New()
        Try
            m_Model = ""
            m_Vendor = ""
            m_VendID = enumVendorID.Empty
            m_CamNo = -1
            m_SNCode = ""
            m_RotateImageDegree = 0
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCameraInfo->New")
            Debug.Assert(False)
        End Try
    End Sub
    Friend Sub CopyTo(ByRef pDestInfo As CDigCameraInfo)
        Try
            If pDestInfo Is Nothing Then pDestInfo = New CDigCameraInfo
            pDestInfo.Model = Me.Model
            pDestInfo.Vendor = Me.Vendor
            pDestInfo.VendID = Me.VendID
            pDestInfo.CamNo = Me.CamNo
            pDestInfo.SNCode = Me.SNCode
            pDestInfo.RotateImageDegree = Me.RotateImageDegree
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCameraInfo->CopyTo")
            Debug.Assert(False)
        End Try
    End Sub
    Public Property Model() As String
        Get
            Return m_Model
        End Get
        Friend Set(ByVal value As String)
            m_Model = value
        End Set
    End Property
    Public Property Vendor() As String
        Get
            Return m_Vendor
        End Get
        Friend Set(ByVal value As String)
            m_Vendor = value
        End Set
    End Property
    Friend Property VendID() As enumVendorID
        Get
            Return m_VendID
        End Get
        Set(ByVal value As enumVendorID)
            m_VendID = value
        End Set
    End Property
    Public Property CamNo() As Integer
        Get
            Return m_CamNo
        End Get
        Friend Set(ByVal value As Integer)
            m_CamNo = value
        End Set
    End Property
    Public Property SNCode() As String
        Get
            Return m_SNCode
        End Get
        Friend Set(ByVal value As String)
            m_SNCode = value
        End Set
    End Property
    Public Property RotateImageDegree() As Double
        Get
            Return m_RotateImageDegree
        End Get
        Friend Set(ByVal value As Double)
            m_RotateImageDegree = value
        End Set
    End Property
    Friend ReadOnly Property IsEqual(ByVal CameraInfo As CDigCameraInfo) As Boolean
        Get
            Dim rtn As Boolean = False
            If CameraInfo IsNot Nothing Then
                If CameraInfo Is Me Then
                    rtn = True
                Else
                    If (CameraInfo.VendID = Me.VendID) AndAlso (CameraInfo.SNCode = Me.SNCode) Then rtn = True
                End If
            End If
            Return rtn
        End Get
    End Property

End Class

Friend Class CDigCamera
    Inherits CDigCameraBased
    Implements IDigCamera
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
        m_CameraInfo = Nothing
        m_LiveImagesList = Nothing
        Call m_AcquistiomImage.Dispose() : m_AcquistiomImage = Nothing

        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"

#End Region
#Region "Member"
    Private m_LutAry(0 To 255) As Integer
    Private m_AcquistTime As Double
    Private m_CameraInfo As CDigCameraInfo
    Private m_Exposure As Double
    Private m_Brightness As Double
    Private m_Contrast As Double
    Private m_TimeBase As Double
    Private m_IsAcquiring As Boolean
    Private m_AcqReceived As Boolean
    Private m_IsThreadPoolFinished As Boolean
    Private m_IsThreadPoolStarted As Boolean
    Private m_LiveImagesList As List(Of CImage)
    Private m_AcqFifoTool As HalconDotNet.HFramegrabber
    Private m_AcquistiomImage As CImage
    Private MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\"
    'Friend Event AttributesChanged(ByVal camNo As Integer, ByVal attribId As enumCameraAttributes)
#End Region
#Region "Constructors && Destructors"
    Private Sub New()
        Call MyBase.New()
        Try

            m_IsThreadPoolStarted = False
            m_IsThreadPoolFinished = True
            If m_CameraInfo Is Nothing Then m_CameraInfo = New CDigCameraInfo
            If m_AcquistiomImage Is Nothing Then m_AcquistiomImage = New CImage
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->New")
            Debug.Assert(False)
        End Try
    End Sub
    Friend Sub New(ByVal Type As String, ByVal DeviceInfo As String, ByVal CamNo As Integer)
        Call MyClass.New()
        Try
            Dim name As String = ""
            Dim horizontalResolution As Integer = 1
            Dim verticalResolution As Integer = 1
            Dim imageWidth As Integer = 0
            Dim imageHeight As Integer = 0
            Dim startRow As Integer = 0
            Dim startColumn As Integer = 0
            Dim field As String = ""
            Dim bitsPerChannel As Integer = 8
            Dim colorSpace As String = ""
            Dim generic As Double = -1
            Dim externalTrigger As String = ""
            Dim cameraType As String = ""
            Dim device As String = DeviceInfo
            Dim port As Integer = 0
            Dim lineIn As Integer = -1
            Select Case Type.ToLower()
                Case "1394IIDC".ToLower()
                    name = "1394IIDC"
                    horizontalResolution = 1
                    verticalResolution = 1
                    imageWidth = 0
                    imageHeight = 0
                    startRow = 0
                    startColumn = 0
                    field = "progressive"
                    bitsPerChannel = 8
                    colorSpace = "default"
                    generic = -1
                    externalTrigger = "false"
                    cameraType = "default"
                    device = DeviceInfo
                    port = 0
                    lineIn = -1
                    m_AcqFifoTool = New HFramegrabber(name, horizontalResolution, verticalResolution, imageWidth, imageHeight, startRow, startColumn, field, bitsPerChannel, colorSpace, generic, externalTrigger, cameraType, device, port, lineIn)
                    m_CameraInfo.Vendor = m_AcqFifoTool.GetFramegrabberParam("camera_vendor")
                    m_CameraInfo.Model = m_AcqFifoTool.GetFramegrabberParam("camera_model")
                    m_CameraInfo.SNCode = DeviceInfo

                    Select Case m_CameraInfo.Vendor.ToLower()
                        Case ("TELI").ToLower()
                            m_CameraInfo.VendID = enumVendorID.ToshibaTeli
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("CSFX36BC3 V1.12").ToLower(), ("CSFX36BC3 V1.13").ToLower()
                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 3648)
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 500)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "enable")
                            End Select

                        Case ("Point Grey Research").ToLower()
                            m_CameraInfo.VendID = enumVendorID.PointGreyResearch
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("Flea2 FL2-03S2M").ToLower()
                                    Call m_AcqFifoTool.SetFramegrabberParam("bayer_pattern", "rg_gb")
                                    Call m_AcqFifoTool.SetFramegrabberParam("bits_per_channel", 8)
                                    Call m_AcqFifoTool.SetFramegrabberParam("brightness", 127) '0-255
                                    Call m_AcqFifoTool.SetFramegrabberParam("burst_count", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("busy_timeout", 100)
                                    Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    Call m_AcqFifoTool.SetFramegrabberParam("color_space", "gray")
                                    Call m_AcqFifoTool.SetFramegrabberParam("exposure", 1) '1-1023
                                    Call m_AcqFifoTool.SetFramegrabberParam("external_trigger", "false")
                                    Call m_AcqFifoTool.SetFramegrabberParam("gamma", 512)
                                    Call m_AcqFifoTool.SetFramegrabberParam("video_gain", 250)
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 5000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("horizontal_offset", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("vertical_offset", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("horizontal_resolution", 648)
                                    Call m_AcqFifoTool.SetFramegrabberParam("vertical_resolution", 488)
                                    Call m_AcqFifoTool.SetFramegrabberParam("image_height", 376) '240)
                                    Call m_AcqFifoTool.SetFramegrabberParam("image_width", 500) ' 320)
                                    Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 3440)
                                    Call m_AcqFifoTool.SetFramegrabberParam("sharpness", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("shutter", 709) '0-709
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable")
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_column", 0) '160
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_row", 0) '120
                                    Call m_AcqFifoTool.SetFramegrabberParam("swap_bytes", "false")
                                    'trigger_delay'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    'trigger_polarity'
                                    'trigger_source'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("vertical_offset", 0)
                                    ' Call m_AcqFifoTool.SetFramegrabberParam("vertical_resolution", 488)
                                    ' Call m_AcqFifoTool.SetFramegrabberParam("video_gain", 380) '683
                            End Select

                        Case ("Basler").ToLower()
                            m_CameraInfo.VendID = enumVendorID.BaslerScout
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("scA640-70fm").ToLower()
                                    Call m_AcqFifoTool.SetFramegrabberParam("color_space", "gray")
                                    Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 1500)
                                    Call m_AcqFifoTool.SetFramegrabberParam("shutter", 1000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable")
                                Case Else
                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    'packet_size'
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 500)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'disable
                            End Select
                        Case Else
                            m_CameraInfo.VendID = enumVendorID.Empty
                    End Select

                    If Not (m_CameraInfo.VendID = enumVendorID.Empty) Then
                        'Select Case m_CameraInfo.VendID
                        '    Case enumVendorID.BaslerScout
                        '        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeBaseAbs", 20)
                        '        m_TimeBase = Fix(0.5 + 10 * m_AcqFifoTool.GetFramegrabberParam("ExposureTimeBaseAbs").D) / 10000
                        '        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", 50)
                        '        m_Exposure = m_AcqFifoTool.GetFramegrabberParam("ExposureTimeRaw").I * m_TimeBase
                        '        Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", 0)
                        '        m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 255

                        '    Case enumVendorID.BaslerAce
                        '        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 1000)
                        '        m_TimeBase = 0.001 'Fix(0.5 + 10 * m_AcqFifoTool.GetFramegrabberParam(New HTuple("ExposureTimeBaseAbs")).D) / 10000
                        '        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", 1000)
                        '        m_Exposure = m_AcqFifoTool.GetFramegrabberParam("ExposureTimeRaw").I * m_TimeBase
                        '        Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", 0)
                        '        m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 1023

                        '    Case Else
                        m_Exposure = 0
                        m_Brightness = 0
                        'End Select

                        'Select Case m_CameraInfo.Model
                        '    Case "sca640-70fm"
                        '        Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", 672)
                        '        m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 320) / 703
                        '    Case "acA640-100gm"
                        '        Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", 560)
                        '        m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 100) / 1023
                        '    Case "sla1000-30fm", "sca1000-30fm"
                        '        Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", 692)
                        '        m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 360) / 663
                        '    Case Else
                        '        Call m_AcqFifoTool.SetFramegrabberParam("contrast", 10)
                        '        m_Contrast = m_AcqFifoTool.GetFramegrabberParam("contrast").I / 100
                        'End Select
                        m_LiveImagesList = New List(Of CImage)

                        m_CameraInfo.CamNo = CamNo
                    End If
                Case ("GigEVision").ToLower()
                    name = "GigEVision"
                    horizontalResolution = 0
                    verticalResolution = 0
                    imageWidth = 0
                    imageHeight = 0
                    startRow = 0
                    startColumn = 0
                    field = "progressive"
                    bitsPerChannel = 8
                    colorSpace = "default"
                    generic = -1
                    externalTrigger = "false"
                    cameraType = "default"
                    device = DeviceInfo
                    port = 0
                    lineIn = -1
                    m_AcqFifoTool = New HFramegrabber(name, horizontalResolution, verticalResolution, imageWidth, imageHeight, startRow, startColumn, field, bitsPerChannel, colorSpace, generic, externalTrigger, cameraType, device, port, lineIn)
                    m_CameraInfo.Vendor = m_AcqFifoTool.GetFramegrabberParam("DeviceVendorName")
                    m_CameraInfo.Model = m_AcqFifoTool.GetFramegrabberParam("DeviceModelName")
                    m_CameraInfo.SNCode = m_AcqFifoTool.GetFramegrabberParam("GtlSerialNumber")

                    Select Case m_CameraInfo.Vendor.ToLower()
                        Case ("Basler").ToLower()
                            m_CameraInfo.VendID = enumVendorID.BaslerAce
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("acA1300-60gm").ToLower()
                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 1280)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 1024)


                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    'packet_size'
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 40000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 500)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable")
                            End Select
                        Case Else
                            m_CameraInfo.VendID = enumVendorID.Empty
                    End Select

                    'If Not (m_CameraInfo.VendID = enumVendorID.Empty) Then
                    '    Select Case m_CameraInfo.VendID
                    '        Case enumVendorID.BaslerScout
                    '            Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeBaseAbs", 20)
                    '            m_TimeBase = Fix(0.5 + 10 * m_AcqFifoTool.GetFramegrabberParam("ExposureTimeBaseAbs").D) / 10000
                    '            Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", 50)
                    '            m_Exposure = m_AcqFifoTool.GetFramegrabberParam("ExposureTimeRaw").I * m_TimeBase
                    '            Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", 0)
                    '            m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 255

                    '        Case enumVendorID.BaslerAce
                    '            Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 1000)
                    '            m_TimeBase = 0.001 'Fix(0.5 + 10 * m_AcqFifoTool.GetFramegrabberParam(New HTuple("ExposureTimeBaseAbs")).D) / 10000
                    '            Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", 1000)
                    '            m_Exposure = m_AcqFifoTool.GetFramegrabberParam("ExposureTimeRaw").I * m_TimeBase
                    '            Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", 0)
                    '            m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 1023

                    '        Case Else
                    '            m_Exposure = 0
                    '            m_Brightness = 0
                    '    End Select
                    '    m_LiveImagesList = New List(Of CImage)
                    m_CameraInfo.CamNo = CamNo
                    'End If
                Case "USB3Vision".ToLower()
                    name = "USB3Vision"
                    horizontalResolution = 0
                    verticalResolution = 0
                    imageWidth = 0
                    imageHeight = 0
                    startRow = 0
                    startColumn = 0
                    field = "progressive"
                    bitsPerChannel = -1 '-1 8
                    colorSpace = "default" '"rgb"
                    generic = -1
                    externalTrigger = "false"
                    cameraType = "default"
                    device = DeviceInfo
                    port = 0
                    lineIn = -1
 

                    m_AcqFifoTool = New HFramegrabber(name, horizontalResolution, verticalResolution, imageWidth, imageHeight, startRow, startColumn, field, bitsPerChannel, colorSpace, generic, externalTrigger, cameraType, device, port, lineIn)

                    m_CameraInfo.Vendor = m_AcqFifoTool.GetFramegrabberParam("DeviceVendorName")
                    m_CameraInfo.Model = m_AcqFifoTool.GetFramegrabberParam("DeviceModelName")
                    m_CameraInfo.SNCode = DeviceInfo

                    Select Case m_CameraInfo.Vendor.ToLower()
                        Case ("Point Grey Research").ToLower()
                            m_CameraInfo.VendID = enumVendorID.PointGreyResearch
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("Flea3 FL3-U3-120S3C").ToLower()

                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionMode", "SingleFrame")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "AcquisitionStart")

                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 2387)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 1795)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 806)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 602)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessAuto", "Off")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessEnabled", 0)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Sharpness", 512)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("Width", 4000)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Height", 3000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "FrameStart")
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerMode", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerSource", "Line0")
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerActivation", "RisingEdge")

                                    Call m_AcqFifoTool.SetFramegrabberParam("GainAuto", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("Gain", 24.5414)
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureMode", "Timed")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureAuto", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 20003.2)
                                    Call m_AcqFifoTool.SetFramegrabberParam("PixelFormat", "RGB8")
                                    Call m_AcqFifoTool.SetFramegrabberParam("pgrExposureCompensationAuto", "Off")
                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    ' Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 3648)
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 40000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 1000)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'enable disable
                                Case ("Chameleon3 CM3-U3-13Y3M").ToLower()

                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionMode", "SingleFrame")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "AcquisitionStart")

                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 1280)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 1024)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 0)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessAuto", "Off")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessEnabled", 0)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Sharpness", 512)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("Width", 4000)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Height", 3000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "FrameStart")
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerMode", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerSource", "Line0")
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerActivation", "RisingEdge")

                                    Call m_AcqFifoTool.SetFramegrabberParam("GainAuto", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("Gain", 24.5414)
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureMode", "Timed")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureAuto", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 20003.2)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("PixelFormat", "RGB8")
                                    Call m_AcqFifoTool.SetFramegrabberParam("pgrExposureCompensationAuto", "Off")
                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    ' Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 3648)
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 40000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 1000)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'enable disable
                            End Select
                        Case ("Basler").ToLower()
                            m_CameraInfo.VendID = enumVendorID.BaslerAce
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("QCAM-UC1300-200CE").ToLower()
                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionMode", "SingleFrame")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Width", 1280)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Height", 1024)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 0)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 0)

                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 640)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 512)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 320)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 256)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Width", 976)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Height", 630)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 152)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 197)

                                    Call m_AcqFifoTool.SetFramegrabberParam("LightSourcePreset", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("BalanceRatioSelector", "Red")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ColorAdjustmentSelector", "Red")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ColorTransformationSelector", "RGBtoRGB")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 48000.0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'enable disable
                                Case ("daA1280-54um").ToLower()
                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionMode", "SingleFrame")
                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 1280)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 960)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 0)
                                    
                                    'Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 48000.0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'enable disable

                            End Select
                        Case "FLIR".ToLower()
                            Select Case m_CameraInfo.Model.ToLower()
                                Case ("Blackfly S BFS-U3-04S2C").ToLower()

 


                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionMode", "SingleFrame") '"SingleFrame"
                                    Call m_AcqFifoTool.SetFramegrabberParam("AcquisitionFrameCount", 2)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "AcquisitionStart")

                                    Call m_AcqFifoTool.SetFramegrabberParam("Width", 720)
                                    Call m_AcqFifoTool.SetFramegrabberParam("Height", 540)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetX", 0)
                                    Call m_AcqFifoTool.SetFramegrabberParam("OffsetY", 0)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessAuto", "Off")
                                    'Call m_AcqFifoTool.SetFramegrabberParam("SharpnessEnabled", 0)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Sharpness", 512)

                                    'Call m_AcqFifoTool.SetFramegrabberParam("Width", 4000)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("Height", 3000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerSelector", "FrameStart")
                                    Call m_AcqFifoTool.SetFramegrabberParam("TriggerMode", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)
                                    'Call m_AcqFifoTool.SetFramegrabberParam("TriggerSource", "Line0")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureMode", "Timed")

                                    'Call m_AcqFifoTool.SetFramegrabberParam("TriggerActivation", "RisingEdge")

                                    Call m_AcqFifoTool.SetFramegrabberParam("GainAuto", "Off") 'Continuous
                                    Call m_AcqFifoTool.SetFramegrabberParam("Gain", 9.3)
                                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevel", 0)

                                    '      Call m_AcqFifoTool.SetFramegrabberParam("ExposureAuto", "Continuous")'Continuous


                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureMode", "Timed")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureAuto", "Off")
                                    Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 500.0) '14998.0

                                    Call m_AcqFifoTool.SetFramegrabberParam("AutoExposureExposureTimeLowerLimit", 100.0) '14998.0
                                    Call m_AcqFifoTool.SetFramegrabberParam("AutoExposureExposureTimeUpperLimit", 15000.0)
                                    'AutoExposureExposureTimeUpperLimit
                                    'Call m_AcqFifoTool.SetFramegrabberParam("PixelFormat", "RGB8")
                                    'bayer_pattern'
                                    'bits_per_channel'
                                    'busy_timeout'
                                    'color_space'
                                    'camera_type'
                                    ' Call m_AcqFifoTool.SetFramegrabberParam("camera_type", "7:0:0")
                                    'horizontal_resolution'
                                    'vertical_resolution'
                                    'horizontal_offset'
                                    'vertical_offset'
                                    'image_width'
                                    'image_height'
                                    'start_column'
                                    'start_row'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("packet_size", 3648)
                                    'brightness'
                                    'shutter'
                                    'video_gain'
                                    'external_trigger'
                                    'trigger_source'
                                    'trigger_polarity'
                                    'trigger_mode'
                                    'trigger_parameter'
                                    'Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeAbs", 40000)
                                    Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 500)
                                    'burst_count'
                                    'swap_bytes'
                                    Call m_AcqFifoTool.SetFramegrabberParam("start_async_after_grab_async", "disable") 'enable disable
                            End Select
                    End Select
                Case Else
                    name = "DirectShow"
                    horizontalResolution = 1
                    verticalResolution = 1
                    imageWidth = 0
                    imageHeight = 0
                    startRow = 0
                    startColumn = 0
                    field = "default"
                    bitsPerChannel = 8
                    colorSpace = "rgb"
                    generic = -1
                    externalTrigger = "false"
                    cameraType = "default"
                    device = DeviceInfo
                    port = 0
                    lineIn = -1
                    m_AcqFifoTool = New HFramegrabber(name, horizontalResolution, verticalResolution, imageWidth, imageHeight, startRow, startColumn, field, bitsPerChannel, colorSpace, generic, externalTrigger, cameraType, device, port, lineIn)
                    'm_CameraInfo.Vendor = m_AcqFifoTool.GetFramegrabberParam("camera_vendor")
                    'm_CameraInfo.Model = m_AcqFifoTool.GetFramegrabberParam("camera_model")
                    m_CameraInfo.SNCode = DeviceInfo
                    'Call m_AcqFifoTool.SetFramegrabberParam("frame_rate", 1000)
            End Select
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->New")
            Debug.Assert(False)
            If m_AcqFifoTool IsNot Nothing Then Call m_AcqFifoTool.Dispose() : m_AcqFifoTool = Nothing
            m_CameraInfo.VendID = enumVendorID.Empty
            m_CameraInfo.CamNo = -1
        End Try
    End Sub

#End Region
#Region "Property"
    Friend Property LutAry(ByVal AryIdx As Integer) As Integer
        Get
            Return m_LutAry(AryIdx)
        End Get
        Set(ByVal value As Integer)
            m_LutAry(AryIdx) = value
        End Set
    End Property
    Public ReadOnly Property AcqReceived() As Boolean Implements IDigCamera.AcqReceived
        Get
            Return m_AcqReceived
        End Get
    End Property
    Public ReadOnly Property AcquistTime() As Double Implements IDigCamera.AcquistTime
        Get
            Return m_AcquistTime
        End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Brightness() As Double Implements IDigCamera.Brightness
        Get
            Return m_Brightness
        End Get
        Set(ByVal value As Double)
            Select Case m_CameraInfo.VendID
                Case enumVendorID.BaslerScout
                    value = Math.Truncate(0.5 + value * 255)
                    If (value > 255) Then
                        value = 255
                    ElseIf (value < 0) Then
                        value = 0
                    End If
                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", CInt(value))
                    m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 255
                Case enumVendorID.BaslerAce
                    value = Math.Truncate(0.5 + value * 1023)
                    If (value > 1023) Then
                        value = 1023
                    ElseIf (value < 0) Then
                        value = 0
                    End If
                    Call m_AcqFifoTool.SetFramegrabberParam("BlackLevelRaw", CInt(value))
                    m_Brightness = m_AcqFifoTool.GetFramegrabberParam("BlackLevelRaw").I / 1023
                Case Else
                    m_Brightness = 0
            End Select
            'RaiseEvent AttributesChanged(m_CameraInfo.CamNo, enumCameraAttributes.Brightness) ' 為了存檔...
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Contrast() As Double Implements IDigCamera.Contrast
        Get
            Return m_Contrast
        End Get
        Set(ByVal value As Double)
            Select Case m_CameraInfo.VendID
                Case enumVendorID.BaslerScout
                    Select Case m_CameraInfo.Model
                        Case "sca640-70fm"
                            value = Math.Truncate(320.5 + value * 703)
                            If (value > 1023) Then
                                value = 1023
                            ElseIf (value < 320) Then
                                value = 320
                            End If
                            Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", CInt(value))
                            m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 320) / 703
                        Case "sla1000-30fm", "sca1000-30fm"
                            value = Math.Truncate(360.5 + value * 663)
                            If (value > 1023) Then
                                value = 1023
                            ElseIf (value < 360) Then
                                value = 360
                            End If
                            Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", CInt(value))
                            m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 360) / 663
                    End Select
                Case enumVendorID.BaslerAce
                    Select Case m_CameraInfo.Model
                        Case "acA640-100gm"
                            value = Math.Truncate(100 + value * 1023)
                            If (value > 1023) Then
                                value = 1023
                            ElseIf (value < 100) Then
                                value = 100
                            End If
                            Call m_AcqFifoTool.SetFramegrabberParam("GainRaw", CInt(value))
                            m_Contrast = (m_AcqFifoTool.GetFramegrabberParam("GainRaw").I - 100) / 1023
                    End Select
                Case Else
                    m_Contrast = 0
            End Select
            'RaiseEvent AttributesChanged(m_CameraInfo.CamNo, enumCameraAttributes.Contrast) ' 為了存檔...
        End Set
    End Property
    Friend ReadOnly Property DCamInfo() As CDigCameraInfo Implements IDigCamera.DCamInfo
        Get
            Return m_CameraInfo
        End Get
    End Property
    ''' <summary>
    ''' 曝光時間(ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Exposure() As Double Implements IDigCamera.Exposure
        Get
            Return m_Exposure
        End Get
        Set(ByVal value As Double)
            If (Math.Abs(value - m_Exposure) > 0.000001) Then
                Select Case m_CameraInfo.VendID
                    Case enumVendorID.BaslerScout
                        value = Math.Truncate(0.5 + value / m_TimeBase)
                        If (value > 4095) Then
                            value = 4095
                        ElseIf (value < 5) Then
                            value = 5
                        End If
                        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", CInt(value))
                        m_Exposure = m_AcqFifoTool.GetFramegrabberParam("ExposureTimeRaw").I * m_TimeBase
                    Case enumVendorID.BaslerAce
                        value = Math.Truncate(0.5 + value / m_TimeBase)
                        If (value > 30000) Then
                            value = 30000
                        ElseIf (value < 30) Then
                            value = 30
                        End If
                        Call m_AcqFifoTool.SetFramegrabberParam("ExposureTimeRaw", CInt(value))
                        m_Exposure = m_AcqFifoTool.GetFramegrabberParam(New HTuple("ExposureTimeRaw")).I * m_TimeBase
                    Case Else
                        m_Exposure = 0
                End Select
                'RaiseEvent AttributesChanged(m_CameraInfo.CamNo, enumCameraAttributes.Exposure) ' 為了存檔...
            End If
        End Set
    End Property
    Public ReadOnly Property IsAcquiring() As Boolean Implements IDigCamera.IsAcquiring
        Get
            Return m_IsAcquiring
        End Get
    End Property

    Friend m_IsColMirror As Boolean
    Public Property IsColMirror() As Boolean
        Get
            Return m_IsColMirror
        End Get
        Set(ByVal value As Boolean)
            m_IsColMirror = value
        End Set
    End Property
    Friend m_IsRowMirror As Boolean
    Public Property IsRowMirror() As Boolean
        Get
            Return m_IsRowMirror
        End Get
        Set(ByVal value As Boolean)
            m_IsRowMirror = value
        End Set
    End Property
#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Function Acquist(Optional ByVal syncMode As Boolean = False) As Integer Implements IDigCamera.Acquist
        Try
            If m_IsAcquiring Then
                Return -1
            Else
                m_IsAcquiring = True : m_AcqReceived = False
                If syncMode Then
                    Call AuxStart("")
                    Return 0
                Else
                    Do
                    Loop Until m_IsThreadPoolFinished = True
                    m_IsThreadPoolStarted = False
                    If System.Threading.ThreadPool.QueueUserWorkItem(AddressOf AuxStart, "") Then
                        Do
                        Loop Until m_IsThreadPoolStarted
                        Return 0
                    Else
                        m_IsAcquiring = False
                        Return -1
                    End If
                End If
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->Acquist")
            Debug.Assert(False)
            m_IsAcquiring = False
            Return -1
        End Try
    End Function
    Protected Overrides Sub AuxStart(ByVal NoParameter As Object)

        Dim image1 As HImage : image1 = New HImage
        Dim image2 As HImage : image2 = New HImage
        Dim image3 As HImage : image3 = New HImage
        Dim image4 As HImage : image4 = New HImage
        Dim image5 As HImage : image5 = New HImage

        Dim image6 As HImage : image6 = New HImage
        Dim image7 As HImage : image7 = New HImage
        Dim image8 As HImage : image8 = New HImage
        Try
            ' Threading.Thread.Sleep(1)
            m_AcqReceived = False
            m_IsAcquiring = True
            m_IsThreadPoolFinished = False
            m_IsThreadPoolStarted = True




         
            '      Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 100.0) '14998.0
            '   Call m_AcqFifoTool.SetFramegrabberParam("grab_timeout", 100)

            image8 = m_AcqFifoTool.GrabImage()

            Dim cnt As HalconDotNet.HTuple = image8.CountChannels()
            '  image1 = image8.Decompose3(image2, image3)

            Select Case DCamInfo.Model.ToLower()
                Case ("Chameleon3 CM3-U3-13Y3M").ToLower()
                    image6 = image3.ZoomImageSize(500, 376, "weighted")
                    'image4 = image6.MirrorImage("column")

                    image4 = image6.MirrorImage("column")
                    image7 = image4.MirrorImage("row")

                    ' image4 = image2.RotateImage(CDbl(0.9), "bilinear")

                    image5 = image6.RotateImage(CDbl(DCamInfo.RotateImageDegree), "bilinear")
                Case Else

                    '  Call m_AcqFifoTool.SetFramegrabberParam("ExposureTime", 1000.0)

                    ' image6 = image3.ZoomImageSize(500, 376, "weighted")
                    image7 = image8.MirrorImage("row")
                    image4 = image7.MirrorImage("column")


                    ' image4 = image2.RotateImage(CDbl(0.9), "bilinear")

                    image5 = image4.RotateImage(CDbl(DCamInfo.RotateImageDegree), "bilinear")
            End Select

            If m_AcquistiomImage.Based Is Nothing Then
                m_AcquistiomImage.Based().Dispose() : m_AcquistiomImage.Based = Nothing
            End If
            m_AcquistiomImage.Based() = image5.CopyImage()
            cnt = m_AcquistiomImage.Based().CountChannels()
            cnt = cnt

        Catch ex As Exception
            'Dim errCode As String
            'errCode = ex.Message.Replace("HALCON", "")
            'Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->AuxStart")
            'Debug.Assert(False)
        End Try

        image1.Dispose() : image1 = Nothing
        image2.Dispose() : image2 = Nothing
        image3.Dispose() : image3 = Nothing
        image4.Dispose() : image4 = Nothing
        image5.Dispose() : image5 = Nothing

        image6.Dispose() : image6 = Nothing
        image7.Dispose() : image7 = Nothing
        image8.Dispose() : image8 = Nothing
        m_AcqReceived = True
        m_IsAcquiring = False
        m_IsThreadPoolFinished = True
    End Sub
    Public Sub CopyTo(ByRef DestImage As CImage) Implements IDigCamera.CopyTo
        Try
            If m_AcqReceived Then
                Call m_AcquistiomImage.CopyTo(DestImage)
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CDigCamera->CopyTo")
            Debug.Assert(False)
        End Try
    End Sub
    'Friend Sub StartLiveDisplay(ByRef pDisplay As ImageDisplay)
    '    Try
    '        Call pDisplay.Based.StartLiveDisplay(m_AcqFifoTool.[Operator])
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "StopLiveDisplay")
    '    End Try
    'End Sub
    'Friend Sub StopLiveDisplay(ByRef pDisplay As ImageDisplay)
    '    Try
    '        Call pDisplay.Based.StopLiveDisplay()
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "StopLiveDisplay")
    '    End Try
    'End Sub
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Public Class CAcquisition
    Implements IAcquisition
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

        For i As Integer = 0 To UBound(m_Camera)
            Call m_Camera(i).Dispose() : m_Camera(i) = Nothing
        Next i
        Erase m_Camera
        m_CameraList = Nothing

        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"
    Private MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\"
#End Region
#Region "Member"
    Private WithEvents eventHandler As CDigCamera
    Private m_Camera() As CDigCamera
    Private m_CameraList As List(Of String)
#End Region
#Region "Constructors && Destructors"
    Public Sub New(ByVal pindex As Integer)
        Call MyBase.New()
        Dim i As Integer
        Dim camID As Integer = -1
        Dim fileExists As Boolean
        Dim strData() As String
        m_CameraList = New List(Of String)
        Try
            'USB3Vision
            'DirectShow
            'Dim cameraType As String = "DirectShow"
            Dim cameraType As String = "USB3Vision"
            If (My.Computer.Name.ToLower.IndexOf("alin") >= 0) Then
                cameraType = "DirectShow"
            End If
            If (m_CameraCnt = 0) Then
                Dim name As HalconDotNet.HTuple = New HTuple(cameraType)
                Dim query As HalconDotNet.HTuple = New HTuple("device")
                Dim information As HalconDotNet.HTuple = New HTuple()
                Dim valueList As HalconDotNet.HTuple = New HTuple()
                Call HOperatorSet.InfoFramegrabber(name, query, information, valueList)
                If valueList.TupleLength() > 0 Then
                    For i = 0 To (valueList.TupleLength() - 1)
                        Call m_CameraList.Add(valueList.SArr(i))
                    Next i
                    m_CameraCnt = m_CameraList.Count
                    If m_CameraCnt > 0 Then
                        ReDim m_Camera(m_CameraCnt - 1)
                        For j As Integer = 0 To (m_CameraCnt - 1)
                            camID = camID + 1
                            m_Camera(camID) = New CDigCamera(cameraType, m_CameraList(j), camID)
                            Call ReadDataFromFile()
                        Next j
                    End If
                    m_CameraCnt = camID + 1
                    If m_CameraCnt > 0 Then
                        ReDim Preserve m_Camera(m_CameraCnt - 1)
                    Else
                        Erase m_Camera
                    End If

                End If
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CAcquisition->New")
            Debug.Assert(False)
        End Try
    End Sub

    Public Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer = 0
        filePath = MCS_SRC_DIRECTORY & "Machine\Parameter\Camera.xml"
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
            Dim xmlDoc As System.Xml.XmlDocument
            xmlDoc = New System.Xml.XmlDocument
            Call xmlDoc.Load(filePath)
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim stemNode As System.Xml.XmlElement
            stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Camera" & idx.ToString()), System.Xml.XmlElement)
            If CXmler.GetXmlData(stemNode, "RotateImageDegree", 0, rtnText) Then RotateDegree(idx) = CDbl(rtnText)

        End If
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer = 0
        Dim filePath As String = ""
        filePath = MCS_SRC_DIRECTORY & "Machine\Parameter\Camera.xml"

        stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Camera" & idx.ToString(), 0, nodeAttributes), System.Xml.XmlElement)
        Call CXmler.NewXmlValue(stemNode, "RotateImageDegree", 0, RotateDegree(idx))
        Call xmlDoc.Save(filePath)

    End Sub

#End Region
#Region "Property"

    Friend Property LutAry(ByVal CameraIdx As Integer, ByVal AryIdx As Integer) As Integer
        Get
            Return m_Camera(CameraIdx).LutAry(AryIdx)
        End Get
        Set(ByVal value As Integer)
            m_Camera(CameraIdx).LutAry(AryIdx) = value
        End Set
    End Property

    Public ReadOnly Property AcqReceived(ByVal CameraIdx As Integer) As Boolean Implements IAcquisition.AcqReceived
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).AcqReceived
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return True
            End If
        End Get
    End Property
    Public Property Brightness(ByVal CameraIdx As Integer) As Double Implements IAcquisition.Brightness
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).Brightness
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return 0
            End If
        End Get
        Set(ByVal value As Double)
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                m_Camera(CameraIdx).Brightness = value
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        End Set
    End Property
    Private Shared m_CameraCnt As Integer
    Public ReadOnly Property CameraCount() As Integer Implements IAcquisition.CameraCount
        Get
            Return m_CameraCnt
        End Get
    End Property
    Public Property Contrast(ByVal CameraIdx As Integer) As Double Implements IAcquisition.Contrast
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).Contrast
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return 0
            End If
        End Get
        Set(ByVal value As Double)
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                m_Camera(CameraIdx).Contrast = value
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        End Set
    End Property
    Public Property Exposure(ByVal CameraIdx As Integer) As Double Implements IAcquisition.Exposure
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).Exposure
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return 0
            End If
        End Get
        Set(ByVal value As Double)
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                m_Camera(CameraIdx).Exposure = value
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        End Set
    End Property
    Public ReadOnly Property IsAcquiring(ByVal CameraIdx As Integer) As Boolean Implements IAcquisition.IsAcquiring
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).IsAcquiring
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return False
            End If
        End Get
    End Property
    Public Property RotateDegree(ByVal CameraIdx As Integer) As Double
        Get
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).DCamInfo.RotateImageDegree
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
                Return 0
            End If
        End Get
        Set(ByVal value As Double)
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                m_Camera(CameraIdx).DCamInfo.RotateImageDegree = value
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        End Set
    End Property
#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Function Acquist(ByVal CameraIdx As Integer, Optional ByVal syncMode As Boolean = False) As Integer Implements IAcquisition.Acquist
        Try
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Return m_Camera(CameraIdx).Acquist(syncMode)
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CAcquisition->Acquist")
            Debug.Assert(False)
            Return -1
        End Try
    End Function
    Public Sub CopyTo(ByVal CameraIdx As Integer, ByRef pDestImage As CImage) Implements IAcquisition.CopyTo
        Try
            If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
                Call m_Camera(CameraIdx).CopyTo(pDestImage)
            Else
                Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CAcquisition->CopyTo")
            Debug.Assert(False)
        End Try
    End Sub
    'Public Sub StartLiveDisplay(ByVal CameraIdx As Integer, ByRef pDisplay As ImageDisplay)
    '    Try
    '        If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
    '            Call m_Camera(CameraIdx).StartLiveDisplay(pDisplay)
    '        Else
    '            Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
    '        End If
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "CAcquisition->")
    '    End Try
    'End Sub
    'Public Sub StopLiveDisplay(ByVal CameraIdx As Integer, ByRef pDisplay As ImageDisplay)
    '    Try
    '        If CameraIdx > -1 AndAlso CameraIdx < m_CameraCnt Then
    '            Call m_Camera(CameraIdx).StopLiveDisplay(pDisplay)
    '        Else
    '            Call MsgBox("指定相機不存在", MsgBoxStyle.Information, "Information")
    '        End If
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "CAcquisition->")
    '    End Try
    'End Sub
#End Region
End Class


