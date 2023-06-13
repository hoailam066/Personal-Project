Imports System.Collections.Generic
Imports Xmler
Imports System.IO
Imports Newtonsoft.Json

Public Enum enumUserLevel
    DenyAccess = 1
    NormalOperator = 2
    Engineer = 3
    Administrator = 4
End Enum

'OUT
Public Enum enumCyl
    ' ''' <summary>
    ' ''' '送料前進後退汽缸
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'TrayInForwardReverse = 0

    ''' <summary>
    ''' '平台真空
    ''' </summary>
    ''' <remarks></remarks>
    WorkholderVaccum = 8

    ''' <summary>
    ''' '送料升降汽缸
    ''' </summary>
    ''' <remarks></remarks>
    TrayInUpDown = 9

    ''' <summary>
    ''' '收料升降汽缸
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutUpDown = 10

    ''' <summary>
    ''' '收料左右汽缸
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutLeftRight = 11

    ''' <summary>
    ''' 吹氣1
    ''' </summary>
    ''' <remarks></remarks>
    Blow1 = 12

    ''' <summary>
    ''' 吹氣2
    ''' </summary>
    ''' <remarks></remarks>
    Blow2 = 13


    ''' <summary>
    ''' '送料取料磁鐵
    ''' </summary>
    ''' <remarks></remarks>
    MagnetOnOff = 16

    ''' <summary>
    ''' 總數
    ''' </summary>
    ''' <remarks></remarks>
    Maximum = 24
End Enum

'IN
Public Enum enumSnr
   
    ''' <summary>
    ''' ' 平台真空檢知
    ''' </summary>
    ''' <remarks></remarks>
    WorkholderVaccum = 8

    ' ''' <summary>
    ' ''' '平台原點
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'WorkholderStandOK = 1

    'WorkholderStandOrign = 2
    ' ''' <summary>
    ' ''' ' 平台前進到位
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'WorkholderForward = 3
    ' ''' <summary>
    ' ''' ' 平台後退到位
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'WorkholderReverse = 4
   
    ''' <summary>
    ''' '送料汽缸下極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayInDownLimit = 13
    ''' <summary>
    ''' '送料汽缸上極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayInUpLimit = 14




    ''' <summary>
    ''' 收料料汽缸左極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutLeftLimit = 15

    ''' <summary>
    ''' 收料料汽缸右極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutRightLimit = 16

    ''' <summary>
    ''' 收料料汽缸下極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutDownLimit = 17

    ''' <summary>
    ''' 收料料汽缸上極限開關
    ''' </summary>
    ''' <remarks></remarks>
    TrayOutUpLimit = 18

    ' ''' <summary>
    ' ''' '送料汽缸下極限開關
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'TrayInRotateOrg = 11
    ' ''' <summary>
    ' ''' '送料汽缸下極限開關
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'TrayInRotateReverse = 12

    ''' <summary>
    ''' 總數
    ''' </summary>
    ''' <remarks></remarks>
    Maximum = 24
End Enum
Public Enum enumAxis
    WorkholderX = 0
    WorkholderY = 1
    WorkholderT = 2
    Maximum = 2
End Enum

Public Enum enumSys
    MainCtl
    Top
    Workholder
    Substrate
    TopSubstrateOut
    Maximum
End Enum

Public Enum enumSysMsg
    None
    MainCtl
    TopYes
    TopCancel
    WorkholderYes
    WorkholderCancel
    TrayInYes
    TrayInCancel
    TrayOutYes
    TrayOutCancel
End Enum

Friend Enum enumConst
    High
    Low
End Enum

Public Enum enumKeyConst
    KeyNo
    KeyStop
    KeyMainStart
    KeyMainRestart
    KeyMainExit
    KeyProductSetting
    KeyParameterSetting
    KeyGeneralSetting
    KeyRecorderSetting
    KeyErrRecorderSetting
    KeyLoaderPositionSetting
    KeyVisionPositionSetting
    KeyIOSetting
    KeyLaserSetting
    keyPassword
End Enum

Public Class CFlagsPause
    Private m_WaitStop As Boolean
    Private m_MaunalStop As Boolean
    Private m_EmergencyStop As Boolean
    Private m_NoTrayInStop As Boolean
    Private m_SysWorkholderStop As Boolean
    Private m_SysTrayInStop As Boolean
    Private m_SysTrayOutStop As Boolean
    Private m_SysWorkholderFinished As Boolean
    Public Property WaitStop() As Boolean
        Get
            Return m_WaitStop
        End Get
        Set(ByVal value As Boolean)
            m_WaitStop = value
        End Set
    End Property
    Public Property MaunalStop() As Boolean
        Get
            Return m_MaunalStop
        End Get
        Set(ByVal value As Boolean)
            m_MaunalStop = value
        End Set
    End Property
    Public Property EmergencyStop() As Boolean
        Get
            Return m_EmergencyStop
        End Get
        Set(ByVal value As Boolean)
            m_EmergencyStop = value
        End Set
    End Property
    Public Property NoTrayInStop() As Boolean
        Get
            Return m_NoTrayInStop
        End Get
        Set(ByVal value As Boolean)
            m_NoTrayInStop = value
        End Set
    End Property
    Public Property SysWorkholderStop() As Boolean
        Get
            Return m_SysWorkholderStop
        End Get
        Set(ByVal value As Boolean)
            m_SysWorkholderStop = value
        End Set
    End Property
    Public Property SysTrayInStop() As Boolean
        Get
            Return m_SysTrayInStop
        End Get
        Set(ByVal value As Boolean)
            m_SysTrayInStop = value
        End Set
    End Property
    Public Property SysTrayOutStop() As Boolean
        Get
            Return m_SysTrayOutStop
        End Get
        Set(ByVal value As Boolean)
            m_SysTrayOutStop = value
        End Set
    End Property
    Public Property SysWorkholderFinished() As Boolean
        Get
            Return m_SysWorkholderFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysWorkholderFinished = value
        End Set
    End Property

    Private Shared m_SysSubstrateFinished As Boolean
    ''' <summary>
    ''' 供料禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysSubstrateFinished() As Boolean
        Get
            Return m_SysSubstrateFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysSubstrateFinished = value
        End Set
    End Property
End Class

Public Enum enumOrder As Integer
    Left = 0
    Right = 1
End Enum
Public Class CFlagsSystem
    Private m_UserLevel As enumUserLevel
    Private m_SysInitHomeOk As Boolean
    Private m_Simulate As Boolean
    Private m_KeyCode As enumKeyConst
    Private m_ProductLoaded As Boolean
    Private m_HwCriticalError As Boolean
    Private m_IsDxfFileType As Boolean
    Private m_DoorUsed As Boolean
    Private m_NormalProcedureUsed As Boolean
    Private m_VisionUsed As Boolean
    Private m_ThetaAxisUsed As Boolean
    Private m_PatternMatched As Boolean
    Private m_PatternMatchedx4 As Boolean
    Private m_PatternMatchedCircle As Boolean
    Private m_FirstInitialized As Boolean
    Private m_NoTraySystem As Boolean
    Private m_TopYes As Boolean
    Private m_TopNo As Boolean
    Private m_WorkholderYes As Boolean
    Private m_WorkholderNo As Boolean
    Private m_TrayInYes As Boolean
    Private m_TrayInNo As Boolean
    Private m_TrayOutYes As Boolean
    Private m_TrayOutNo As Boolean
    Private m_AutoRunProcedure As Boolean
    Private m_VaccumTrayInChecked As Boolean
    Private m_VaccumLaerDrillingChecked As Boolean
    Private m_VaccumTrayOutChecked As Boolean
    Private m_LaserAutoCal As Boolean
    Private m_QuickProcess As Boolean
    Private m_Order As enumOrder
    Private m_Complete As Boolean = False
    Public Property Order As enumOrder
        Get
            Return m_Order
        End Get
        Set(ByVal value As enumOrder)
            m_Order = value
        End Set
    End Property
    Public Property Complete As Boolean
        Get
            Return m_Complete
        End Get
        Set(ByVal value As Boolean)
            m_Complete = value
        End Set
    End Property
    Public Property UserLevel() As enumUserLevel
        Get
            Return m_UserLevel
        End Get
        Set(ByVal value As enumUserLevel)

            m_UserLevel = value

        End Set
    End Property
    Public Property AutoRunProcedure() As Boolean
        Get
            Return m_AutoRunProcedure
        End Get
        Set(ByVal value As Boolean)
            m_AutoRunProcedure = value
        End Set
    End Property

    Public Property DoorUsed() As Boolean
        Get
            Return m_DoorUsed
        End Get
        Set(ByVal value As Boolean)

            m_DoorUsed = value

        End Set
    End Property

    Public Property NormalProcedureUsed() As Boolean
        Get
            Return m_NormalProcedureUsed
        End Get
        Set(ByVal value As Boolean)

            m_NormalProcedureUsed = value

        End Set
    End Property

    Public Property VisionUsed() As Boolean
        Get
            Return m_VisionUsed
        End Get
        Set(ByVal value As Boolean)

            m_VisionUsed = value

        End Set
    End Property

    Public Property ThetaAxisUsed() As Boolean
        Get
            Return m_ThetaAxisUsed
        End Get
        Set(ByVal value As Boolean)

            m_ThetaAxisUsed = value

        End Set
    End Property
    Public Property PatternMatched() As Boolean
        Get
            Return m_PatternMatched
        End Get
        Set(ByVal value As Boolean)
            m_PatternMatched = value
        End Set
    End Property

    Public Property PatternMatchedx4() As Boolean
        Get
            Return m_PatternMatchedx4
        End Get
        Set(ByVal value As Boolean)
            m_PatternMatchedx4 = value
        End Set
    End Property

    Public Property PatternMatchedCircle() As Boolean
        Get
            Return m_PatternMatchedCircle
        End Get
        Set(ByVal value As Boolean)
            m_PatternMatchedCircle = value
        End Set
    End Property
    Public Property FirstInitialized() As Boolean
        Get
            Return m_FirstInitialized
        End Get
        Set(ByVal value As Boolean)
            m_FirstInitialized = value
        End Set
    End Property

    Public Property NoTraySystem() As Boolean
        Get
            Return m_NoTraySystem
        End Get
        Set(ByVal value As Boolean)
            m_NoTraySystem = value
        End Set
    End Property


    Public Property CriticalError() As Boolean
        Get
            Return m_HwCriticalError
        End Get
        Set(ByVal value As Boolean)

            m_HwCriticalError = value

        End Set
    End Property

    Public Property ProductLoaded() As Boolean
        Get
            Return m_ProductLoaded
        End Get
        Set(ByVal value As Boolean)

            m_ProductLoaded = value

        End Set
    End Property

    Public Property SysInitHomeOk() As Boolean
        Get
            Return m_SysInitHomeOk
        End Get
        Set(ByVal value As Boolean)

            m_SysInitHomeOk = value

        End Set
    End Property

    Public Property Simulate() As Boolean
        Get
            Return m_Simulate
        End Get
        Set(ByVal value As Boolean)

            m_Simulate = value

        End Set
    End Property

    Public Property KeyCode() As enumKeyConst
        Get
            Return m_KeyCode
        End Get
        Set(ByVal value As enumKeyConst)

            m_KeyCode = value

        End Set
    End Property

    Public Property IsDxfFileType() As Boolean
        Get
            Return m_IsDxfFileType
        End Get
        Set(ByVal value As Boolean)

            m_IsDxfFileType = value

        End Set
    End Property

    Public Property TopYes() As Boolean
        Get
            Return m_TopYes
        End Get
        Set(ByVal value As Boolean)

            m_TopYes = value

        End Set
    End Property

    Public Property TopNo() As Boolean
        Get
            Return m_TopNo
        End Get
        Set(ByVal value As Boolean)

            m_TopNo = value

        End Set
    End Property

    Public Property WorkholderYes() As Boolean
        Get
            Return m_WorkholderYes
        End Get
        Set(ByVal value As Boolean)

            m_WorkholderYes = value

        End Set
    End Property

    Public Property WorkholderNo() As Boolean
        Get
            Return m_WorkholderNo
        End Get
        Set(ByVal value As Boolean)

            m_WorkholderNo = value

        End Set
    End Property

    Public Property TrayInYes() As Boolean
        Get
            Return m_TrayInYes
        End Get
        Set(ByVal value As Boolean)

            m_TrayInYes = value

        End Set
    End Property

    Public Property TrayInNo() As Boolean
        Get
            Return m_TrayInNo
        End Get
        Set(ByVal value As Boolean)

            m_TrayInNo = value

        End Set
    End Property

    Public Property TrayOutYes() As Boolean
        Get
            Return m_TrayOutYes
        End Get
        Set(ByVal value As Boolean)

            m_TrayOutYes = value

        End Set
    End Property

    Public Property TrayOutNo() As Boolean
        Get
            Return m_TrayOutNo
        End Get
        Set(ByVal value As Boolean)

            m_TrayOutNo = value

        End Set
    End Property
    ''' <summary>
    ''' 進料時透過平台真空檢查有無料件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VaccumTrayInChecked() As Boolean
        Get
            Return m_VaccumTrayInChecked
        End Get
        Set(ByVal value As Boolean)
            m_VaccumTrayInChecked = value
        End Set
    End Property
    ''' <summary>
    ''' 切割時透過平台真空檢查有無破片
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VaccumLaerDrillingChecked() As Boolean
        Get
            Return m_VaccumLaerDrillingChecked
        End Get
        Set(ByVal value As Boolean)
            m_VaccumLaerDrillingChecked = value
        End Set
    End Property
    ''' <summary>
    ''' 退料時透過平台真空檢查有無料件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VaccumTrayOutChecked() As Boolean
        Get
            Return m_VaccumTrayOutChecked
        End Get
        Set(ByVal value As Boolean)
            m_VaccumTrayOutChecked = value
        End Set
    End Property

    Public Property LaserAutoCal() As Boolean
        Get
            Return m_LaserAutoCal
        End Get
        Set(ByVal value As Boolean)
            m_LaserAutoCal = value
        End Set
    End Property

    Public Property QuickProcess() As Boolean
        Get
            Return m_QuickProcess
        End Get
        Set(ByVal value As Boolean)
            m_QuickProcess = value
        End Set
    End Property
End Class

Public Class CFlagsSubstrate
    Private m_SubstrateHavePiece As Boolean
    Public Property SubstrateHavePiece() As Boolean
        Get
            Return m_SubstrateHavePiece
        End Get
        Set(ByVal value As Boolean)
            m_SubstrateHavePiece = value
        End Set
    End Property

    Private m_SubstrateCanUse As Boolean
    Public Property SubstrateCanUse() As Boolean
        Get
            Return m_SubstrateCanUse
        End Get
        Set(ByVal value As Boolean)
            m_SubstrateCanUse = value
        End Set
    End Property

End Class
Public Class CFlagsLaser
    Private m_CircleMapUsed(0 To 16) As Boolean
    Public Property CircleMapUsed(ByVal Idx As Int32) As Boolean
        Get
            Return m_CircleMapUsed(Idx)
        End Get
        Set(ByVal value As Boolean)

            m_CircleMapUsed(Idx) = value

        End Set
    End Property


    Public ReadOnly Property CircleMapUsed() As Boolean()
        Get
            Return m_CircleMapUsed
        End Get
    End Property
End Class


Public Class CFlags
    Private m_Pause As CFlagsPause
    Private m_System As CFlagsSystem
    Private m_Laser As CFlagsLaser
    Private m_Substrate As CFlagsSubstrate

    Public Sub New()

        If m_Pause Is Nothing Then m_Pause = New CFlagsPause
        If m_System Is Nothing Then m_System = New CFlagsSystem
        If m_Laser Is Nothing Then m_Laser = New CFlagsLaser
        If m_Substrate Is Nothing Then m_Substrate = New CFlagsSubstrate
    End Sub
    Protected Overrides Sub Finalize()

        m_Pause = Nothing
        m_System = Nothing
        m_Laser = Nothing
        m_Substrate = Nothing
        MyBase.Finalize()

    End Sub

    Public Property Pause() As CFlagsPause
        Get
            Return m_Pause
        End Get
        Set(ByVal value As CFlagsPause)

            m_Pause = value

        End Set
    End Property

    Public Property System() As CFlagsSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CFlagsSystem)

            m_System = value

        End Set
    End Property

    Public Property Laser() As CFlagsLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CFlagsLaser)

            m_Laser = value

        End Set
    End Property

    Public Property Substrate() As CFlagsSubstrate
        Get
            Return m_Substrate
        End Get
        Set(ByVal value As CFlagsSubstrate)
            m_Substrate = value
        End Set
    End Property
End Class



Public Class CPositionWH

    Private Shared m_SubstrateInX1 As Double
    ''' <summary>
    ''' 基版供料位置 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInX1() As Double
        Get
            Return m_SubstrateInX1
        End Get
        Set(ByVal value As Double)
            m_SubstrateInX1 = value
        End Set
    End Property

    Private Shared m_SubstratePunchX As Double
    ''' <summary>
    ''' 沖壓位置 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstratePunchX() As Double
        Get
            Return m_SubstratePunchX
        End Get
        Set(ByVal value As Double)
            m_SubstratePunchX = value
        End Set
    End Property

    Private Shared m_SubstrateOutX1 As Double
    ''' <summary>
    ''' 基版退料位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateOutX1() As Double
        Get
            Return m_SubstrateOutX1
        End Get
        Set(ByVal value As Double)
            m_SubstrateOutX1 = value
        End Set
    End Property

    Private Shared m_WorkHolderCutX1 As Double
    ''' <summary>
    ''' 平台Cut1 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkHolderCutX1() As Double
        Get
            Return m_WorkHolderCutX1
        End Get
        Set(ByVal value As Double)
            m_WorkHolderCutX1 = value
        End Set
    End Property

    Private Shared m_WorkHolderCutX2 As Double
    ''' <summary>
    ''' 平台Cut2 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkHolderCutX2() As Double
        Get
            Return m_WorkHolderCutX2
        End Get
        Set(ByVal value As Double)
            m_WorkHolderCutX2 = value
        End Set
    End Property

    Private Shared m_SubstrateBlowX As Double
    ''' <summary>
    ''' 平台吹氣 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateBlowX() As Double
        Get
            Return m_SubstrateBlowX
        End Get
        Set(ByVal value As Double)
            m_SubstrateBlowX = value
        End Set
    End Property


    Private m_ImageAlignRealOffsetX As Double
    Private m_ImageAlignRealOffsetY As Double
    Private m_AlignX As Integer
    Private m_AlignY As Integer
    Private m_TrayOutX1 As Integer
    Private m_TrayOutY1 As Integer
    Private m_TrayOutX2 As Integer
    Private m_TrayOutY2 As Integer
    Private m_TrayInX1 As Integer
    Private m_TrayInY1 As Integer
    Private m_TrayInX2 As Integer
    Private m_TrayInY2 As Integer
    Private m_TrayNGX As Integer
    Private m_TrayNGY As Integer
    Private m_ImageAlignT As Double
    Private m_PatternAlignX1 As Integer
    Private m_PatternAlignY1 As Integer
    Private m_PatternAlignX2 As Integer
    Private m_PatternAlignY2 As Integer
    Private m_PatternAlignX3 As Integer
    Private m_PatternAlignY3 As Integer
    Private m_PatternAlignX4 As Integer
    Private m_PatternAlignY4 As Integer
    Private m_EdgeAlignX1 As Integer
    Private m_EdgeAlignY1 As Integer
    Private m_EdgeAlignX2 As Integer
    Private m_EdgeAlignY2 As Integer
    Private m_EdgeAlignX3 As Integer
    Private m_EdgeAlignY3 As Integer
    Private m_EdgeAlignX4 As Integer
    Private m_EdgeAlignY4 As Integer
    ''' <summary>
    ''' 基板原點視覺補正完後實際位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignRealOffsetX() As Double
        Get
            Return m_ImageAlignRealOffsetX
        End Get
        Set(ByVal value As Double)
            m_ImageAlignRealOffsetX = value
        End Set
    End Property
    ''' <summary>
    ''' 基板原點視覺補正完後實際位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignRealOffsetY() As Double
        Get
            Return m_ImageAlignRealOffsetY
        End Get
        Set(ByVal value As Double)
            m_ImageAlignRealOffsetY = value
        End Set
    End Property

    ''' <summary>
    ''' 基版原點對應雷射原點位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignX() As Int32
        Get
            Return m_AlignX
        End Get
        Set(ByVal value As Int32)
            m_AlignX = value
        End Set
    End Property
    ''' <summary>
    ''' 基版原點對應雷射原點位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignY() As Int32
        Get
            Return m_AlignY
        End Get
        Set(ByVal value As Int32)
            m_AlignY = value
        End Set
    End Property
    ''' <summary>
    ''' 基版退料位置...基版與靠邊機構未碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayOutX1() As Int32
        Get
            Return m_TrayOutX1
        End Get
        Set(ByVal value As Int32)
            m_TrayOutX1 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版退料位置...基版與靠邊機構未碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayOutY1() As Int32
        Get
            Return m_TrayOutY1
        End Get
        Set(ByVal value As Int32)
            m_TrayOutY1 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版退料位置...基版與靠邊機構碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayOutX2() As Int32
        Get
            Return m_TrayOutX2
        End Get
        Set(ByVal value As Int32)
            m_TrayOutX2 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版退料位置...基版與靠邊機構碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayOutY2() As Int32
        Get
            Return m_TrayOutY2
        End Get
        Set(ByVal value As Int32)
            m_TrayOutY2 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版進料位置...基版與靠邊機構未碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInX1() As Int32
        Get
            Return m_TrayInX1
        End Get
        Set(ByVal value As Int32)
            m_TrayInX1 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版進料位置...基版與靠邊機構未碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInY1() As Int32
        Get
            Return m_TrayInY1
        End Get
        Set(ByVal value As Int32)
            m_TrayInY1 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版進料位置...基版與靠邊機構碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInX2() As Int32
        Get
            Return m_TrayInX2
        End Get
        Set(ByVal value As Int32)
            m_TrayInX2 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版進料位置...基版與靠邊機構碰觸
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInY2() As Int32
        Get
            Return m_TrayInY2
        End Get
        Set(ByVal value As Int32)
            m_TrayInY2 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版破片處理位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayNGX() As Int32
        Get
            Return m_TrayNGX
        End Get
        Set(ByVal value As Int32)
            m_TrayNGX = value
        End Set
    End Property
    ''' <summary>
    ''' 基版破片處理位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayNGY() As Int32
        Get
            Return m_TrayNGY
        End Get
        Set(ByVal value As Int32)
            m_TrayNGY = value
        End Set
    End Property
    ''' <summary>
    ''' 基版視覺定位初始位置(degree)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignT() As Double
        Get
            Return m_ImageAlignT
        End Get
        Set(ByVal value As Double)
            m_ImageAlignT = value
        End Set
    End Property
    ''' <summary>
    ''' 基版視覺樣板比對左邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignX1() As Integer
        Get
            Return m_PatternAlignX1
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignX1 = value
        End Set
    End Property
    ''' <summary>
    ''' 基版視覺樣板比對左邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignY1() As Integer
        Get
            Return m_PatternAlignY1
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignY1 = value
        End Set
    End Property
    Public Property PatternAlignX2() As Integer
        Get
            Return m_PatternAlignX2
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignX2 = value
        End Set
    End Property
    Public Property PatternAlignY2() As Integer
        Get
            Return m_PatternAlignY2
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignY2 = value
        End Set
    End Property
    Public Property PatternAlignX3() As Integer
        Get
            Return m_PatternAlignX3
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignX3 = value
        End Set
    End Property
    Public Property PatternAlignY3() As Integer
        Get
            Return m_PatternAlignY3
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignY3 = value
        End Set
    End Property
    Public Property PatternAlignX4() As Integer
        Get
            Return m_PatternAlignX4
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignX4 = value
        End Set
    End Property
    Public Property PatternAlignY4() As Integer
        Get
            Return m_PatternAlignY4
        End Get
        Set(ByVal value As Integer)
            m_PatternAlignY4 = value
        End Set
    End Property
    Public Property EdgeAlignX1() As Int32
        Get
            Return m_EdgeAlignX1
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignX1 = value

        End Set
    End Property
    Public Property EdgeAlignY1() As Int32
        Get
            Return m_EdgeAlignY1
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignY1 = value

        End Set
    End Property
    Public Property EdgeAlignX2() As Int32
        Get
            Return m_EdgeAlignX2
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignX2 = value

        End Set
    End Property
    Public Property EdgeAlignY2() As Int32
        Get
            Return m_EdgeAlignY2
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignY2 = value

        End Set
    End Property
    Public Property EdgeAlignX3() As Int32
        Get
            Return m_EdgeAlignX3
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignX3 = value

        End Set
    End Property
    Public Property EdgeAlignY3() As Int32
        Get
            Return m_EdgeAlignY3
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignY3 = value

        End Set
    End Property
    Public Property EdgeAlignX4() As Int32
        Get
            Return m_EdgeAlignX4
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignX4 = value

        End Set
    End Property
    Public Property EdgeAlignY4() As Int32
        Get
            Return m_EdgeAlignY4
        End Get
        Set(ByVal value As Int32)

            m_EdgeAlignY4 = value

        End Set
    End Property
End Class

Public Class CPosition
    Private m_Workholder As CPositionWH
    Public Sub New()

        If m_Workholder Is Nothing Then m_Workholder = New CPositionWH

    End Sub

    Protected Overrides Sub Finalize()

        m_Workholder = Nothing

        MyBase.Finalize()

    End Sub

    Public Property Workholder() As CPositionWH
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CPositionWH)

            m_Workholder = value

        End Set
    End Property

End Class

Public Class CIdxSystem
    ''' <summary>
    ''' 圖層索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_JobIdx As Int32
    Private m_WorkStep As Int32

    Private m_ImageAlignmentRetry As Int32
    Private m_TrayIn As Int32
    Private m_PieceOK As Int32
    Private m_PieceNoGood As Int32


    Public Property JobIdx() As Int32
        Get
            Return m_JobIdx
        End Get
        Set(ByVal value As Int32)

            m_JobIdx = value

        End Set
    End Property
    ''' <summary>
    ''' 工作的方向
    ''' </summary>
    ''' <remarks></remarks>
    Public Property WorkStep() As Int32
        Get
            Return m_WorkStep
        End Get
        Set(ByVal value As Int32)

            m_WorkStep = value

        End Set
    End Property

    Public Property PieceOK() As Int32
        Get
            Return m_PieceOK
        End Get
        Set(ByVal value As Int32)
            m_PieceOK = value
        End Set
    End Property

    Public Property PieceNoGood() As Int32
        Get
            Return m_PieceNoGood
        End Get
        Set(ByVal value As Int32)
            m_PieceNoGood = value
        End Set
    End Property

    Public Property ImageAlignmentRetry() As Int32
        Get
            Return m_ImageAlignmentRetry
        End Get
        Set(ByVal value As Int32)
            m_ImageAlignmentRetry = value
        End Set
    End Property
End Class

Public Class CIdxTray
    Private m_TrayIn As Int32
    Private m_TrayOutNG As Int32
    ''' <summary>
    ''' 載入第幾片工件
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayIn() As Int32
        Get
            Return m_TrayIn
        End Get
        Set(ByVal value As Int32)
            m_TrayIn = value
        End Set
    End Property
    Public Property TrayOutNG() As Int32
        Get
            Return m_TrayOutNG
        End Get
        Set(ByVal value As Int32)
            m_TrayOutNG = value
        End Set
    End Property
End Class

Public Class CIdx
    Private m_System As CIdxSystem
    Private m_Tray As CIdxTray

    Public Sub New()

        If m_System Is Nothing Then m_System = New CIdxSystem
        If m_Tray Is Nothing Then m_Tray = New CIdxTray

    End Sub

    Protected Overrides Sub Finalize()

        m_System = Nothing
        m_Tray = Nothing

        MyBase.Finalize()

    End Sub

    Public Property System() As CIdxSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CIdxSystem)
            m_System = value
        End Set
    End Property
    Public Property Tray() As CIdxTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CIdxTray)
            m_Tray = value
        End Set
    End Property

End Class


Public Class CCountSystem
    ''' <summary>
    ''' 圖層索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_layIdx As Int32
    ''' <summary>
    ''' 幾何物件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_geoIdx As Int32
    ''' <summary>
    ''' 元件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_entityIdx As Int32

    Private m_ImageAlignmentRetry As Int32
    Private m_TrayIn As Int32
    Private m_PieceAll As Int32

    Public Property PieceAll() As Int32
        Get
            Return m_PieceAll
        End Get
        Set(ByVal value As Int32)
            m_PieceAll = value
        End Set
    End Property

    Public Property LayIdx() As Int32
        Get
            Return m_layIdx
        End Get
        Set(ByVal value As Int32)

            m_layIdx = value

        End Set
    End Property

    Public Property GeoIdx() As Int32
        Get
            Return m_geoIdx
        End Get
        Set(ByVal value As Int32)

            m_geoIdx = value

        End Set
    End Property

    Public Property EntityIdx() As Int32
        Get
            Return m_entityIdx
        End Get
        Set(ByVal value As Int32)

            m_entityIdx = value

        End Set
    End Property
    Public Property ImageAlignmentRetry() As Int32
        Get
            Return m_ImageAlignmentRetry
        End Get
        Set(ByVal value As Int32)
            m_ImageAlignmentRetry = value
        End Set
    End Property
End Class

Public Class CCountTray
    ''' <summary>
    ''' 工作片數設定
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PieceToStop As Int32
    ''' <summary>
    ''' 收料NG數量上限
    ''' </summary>
    ''' <remarks></remarks>
    Private m_TrayOutNGMax As Int32
    ''' <summary>
    ''' 工作片數設定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PieceToStop() As Int32
        Get
            Return m_PieceToStop
        End Get
        Set(ByVal value As Int32)
            m_PieceToStop = value
        End Set
    End Property
    ''' <summary>
    ''' 收料NG數量上限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayOutNGMax() As Int32
        Get
            Return m_TrayOutNGMax
        End Get
        Set(ByVal value As Int32)
            m_TrayOutNGMax = value
        End Set
    End Property
End Class

Public Class CCountWorkholder
    ''' <summary>
    ''' 影像定位最大補償次數
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ImageAlignmentRetryMax As Int32
    ''' <summary>
    ''' 影像定位最大補償次數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignmentRetryMax() As Int32
        Get
            Return m_ImageAlignmentRetryMax
        End Get
        Set(ByVal value As Int32)
            m_ImageAlignmentRetryMax = value
        End Set
    End Property
End Class

Public Class CCount
    Private m_System As CCountSystem
    Private m_Tray As CCountTray
    Private m_Workholder As CCountWorkholder


    Public Sub New()

        If m_System Is Nothing Then m_System = New CCountSystem
        If m_Tray Is Nothing Then m_Tray = New CCountTray
        If m_Workholder Is Nothing Then m_Workholder = New CCountWorkholder

    End Sub

    Protected Overrides Sub Finalize()

        m_System = Nothing
        m_Tray = Nothing
        m_Workholder = Nothing

        MyBase.Finalize()

    End Sub

    Public Property System() As CCountSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CCountSystem)
            m_System = value
        End Set
    End Property
    Public Property Tray() As CCountTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CCountTray)
            m_Tray = value
        End Set
    End Property
    Public Property Workholder() As CCountWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CCountWorkholder)
            m_Workholder = value
        End Set
    End Property
End Class


Public Class CTimeLaser
    Private m_CalibrationStart As Double
    Private m_EmissionEnableStart As Double
    Private m_JumpStart As Double
    Private m_MarkStart As Double
    Private m_LaserOnDelayMiniSecond As Integer
    Private m_LaserOffDelayMiniSecond As Integer
    Private m_LaserON As Double
    Private m_LaserOnStart As Double

    ''' <summary>
    ''' 跳躍延遲 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_JumpDelayMiniSecond As Integer
    Private m_MarkDelayMiniSecond As Integer
    Private m_PolygonDelayMiniSecond As Integer
    Private m_LaserOnDelayMicroSecond As Integer
    Private m_LaserOffDelayMicroSecond As Integer
    Private m_JumpDelay10MicroSecond As Integer
    Private m_MarkDelay10MicroSecond As Integer
    Private m_PolygonDelay10MicroSecond As Integer

    Public Property CalibrationStart() As Double
        Get
            Return m_CalibrationStart
        End Get
        Set(ByVal value As Double)
            m_CalibrationStart = value
        End Set
    End Property
    ''' <summary>
    ''' 雷射致能開始時間,致能開始到可以擊發需經時120mini-second
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EmissionEnableStart() As Double
        Get
            Return m_EmissionEnableStart
        End Get
        Set(ByVal value As Double)

            m_EmissionEnableStart = value

        End Set
    End Property
    ''' <summary>
    ''' 平台移動完畢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JumpStart() As Double
        Get
            Return m_JumpStart
        End Get
        Set(ByVal value As Double)

            m_JumpStart = value

        End Set
    End Property
    Public Property MarkStart() As Double
        Get
            Return m_MarkStart
        End Get
        Set(ByVal value As Double)

            m_MarkStart = value

        End Set
    End Property
    Public Property LaserOnDelayMiniSecond() As Int32
        Get
            Return m_LaserOnDelayMiniSecond
        End Get
        Set(ByVal value As Int32)

            m_LaserOnDelayMiniSecond = value

        End Set
    End Property
    Public Property LaserOffDelayMiniSecond() As Int32
        Get
            Return m_LaserOffDelayMiniSecond
        End Get
        Set(ByVal value As Int32)

            m_LaserOffDelayMiniSecond = value

        End Set
    End Property

    ''' <summary>
    ''' 雷射擊發時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserON() As Double
        Get
            Return m_LaserON
        End Get
        Set(ByVal value As Double)
            m_LaserON = value
        End Set
    End Property
    ''' <summary>
    ''' 雷射開始擊發的時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOnStart() As Double
        Get
            Return m_LaserOnStart
        End Get
        Set(ByVal value As Double)
            m_LaserOnStart = value
        End Set
    End Property

    ''' <summary>
    ''' 跳躍延遲 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JumpDelayMiniSecond() As Int32
        Get
            Return m_JumpDelayMiniSecond
        End Get
        Set(ByVal value As Int32)
            m_JumpDelayMiniSecond = value
        End Set
    End Property
    Public Property MarkDelayMiniSecond() As Int32
        Get
            Return m_MarkDelayMiniSecond
        End Get
        Set(ByVal value As Int32)

            m_MarkDelayMiniSecond = value

        End Set
    End Property
    Public Property PolygonDelayMiniSecond() As Int32
        Get
            Return m_PolygonDelayMiniSecond
        End Get
        Set(ByVal value As Int32)

            m_PolygonDelayMiniSecond = value

        End Set
    End Property
    Public Property LaserOnDelayMicroSecond() As Int32
        Get
            Return m_LaserOnDelayMicroSecond
        End Get
        Set(ByVal value As Int32)

            m_LaserOnDelayMicroSecond = value

        End Set
    End Property
    Public Property LaserOffDelayMicroSecond() As Int32
        Get
            Return m_LaserOffDelayMicroSecond
        End Get
        Set(ByVal value As Int32)

            m_LaserOffDelayMicroSecond = value

        End Set
    End Property
    Public Property JumpDelay10MicroSecond() As Int32
        Get
            Return m_JumpDelay10MicroSecond
        End Get
        Set(ByVal value As Int32)

            m_JumpDelay10MicroSecond = value

        End Set
    End Property
    Public Property MarkDelay10MicroSecond() As Int32
        Get
            Return m_MarkDelay10MicroSecond
        End Get
        Set(ByVal value As Int32)

            m_MarkDelay10MicroSecond = value

        End Set
    End Property
    Public Property PolygonDelay10MicroSecond() As Int32
        Get
            Return m_PolygonDelay10MicroSecond
        End Get
        Set(ByVal value As Int32)

            m_PolygonDelay10MicroSecond = value

        End Set
    End Property
End Class

Public Class CTimeTray
#Region "Member"
    ''' <summary>
    ''' 送料馬達慢速下降時間 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_TrayInDownDelayMiniSecond As Integer
    ''' <summary>
    ''' 送料取料時吹氣時間 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_TrayInBlowDelayMiniSecond As Integer
    Private m_TrayTimeOut As Integer
    Private m_TrayInMoveStart As Double
    Private m_TrayOutMoveStart As Double
    Private m_TrayInBlowStart As Double
    Private m_TrayInVaccumDelayMiniSecond As Integer
    Private m_TrayInVaccumStart As Double
    Private m_TrayLaserStart As Double
#End Region
#Region "Property"
    ''' <summary>
    ''' 送料馬達下降延遲 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInVaccumDelayMiniSecond() As Integer
        Get
            Return m_TrayInVaccumDelayMiniSecond
        End Get
        Set(ByVal value As Integer)
            m_TrayInVaccumDelayMiniSecond = value
        End Set
    End Property
    Public Property TrayInVaccumStart() As Double
        Get
            Return m_TrayInVaccumStart
        End Get
        Set(ByVal value As Double)
            m_TrayInVaccumStart = value
        End Set
    End Property
    ''' <summary>
    ''' 送料馬達慢速下降時間 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInDownDelayMiniSecond() As Int32
        Get
            Return m_TrayInDownDelayMiniSecond
        End Get
        Set(ByVal value As Int32)
            m_TrayInDownDelayMiniSecond = value
        End Set
    End Property
    ''' <summary>
    ''' 送料取料時吹氣時間 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TrayInBlowDelayMiniSecond() As Int32
        Get
            Return m_TrayInBlowDelayMiniSecond
        End Get
        Set(ByVal value As Int32)
            m_TrayInBlowDelayMiniSecond = value
        End Set
    End Property
    Public Property TrayTimeOut() As Int32
        Get
            Return m_TrayTimeOut
        End Get
        Set(ByVal value As Int32)
            m_TrayTimeOut = value
        End Set
    End Property
    Public Property TrayInMoveStart() As Double
        Get
            Return m_TrayInMoveStart
        End Get
        Set(ByVal value As Double)
            m_TrayInMoveStart = value
        End Set
    End Property
    Public Property TrayOutMoveStart() As Double
        Get
            Return m_TrayOutMoveStart
        End Get
        Set(ByVal value As Double)
            m_TrayOutMoveStart = value
        End Set
    End Property
    Public Property TrayInBlowStart() As Double
        Get
            Return m_TrayInBlowStart
        End Get
        Set(ByVal value As Double)
            m_TrayInBlowStart = value
        End Set
    End Property

    Public Property TrayLaserStart() As Double
        Get
            Return m_TrayLaserStart
        End Get
        Set(ByVal value As Double)
            m_TrayLaserStart = value
        End Set
    End Property
#End Region
End Class

Public Class CTimeWorkholder
#Region "Member"
    Private m_MoveStart As Double
    Private m_MoveStable As Int32
#End Region
#Region "Property"
    Public Property MoveStart() As Double
        Get
            Return m_MoveStart
        End Get
        Set(ByVal value As Double)
            m_MoveStart = value
        End Set
    End Property

    Public Property MoveStable() As Int32
        Get
            Return m_MoveStable
        End Get
        Set(ByVal value As Int32)
            m_MoveStable = value
        End Set
    End Property

#End Region
End Class

Public Class CTimeSystem
#Region "Member"
    Private m_RecorderStart As Double
#End Region
#Region "Property"
    Public Property RecorderStart() As Double
        Get
            Return m_RecorderStart
        End Get
        Set(ByVal value As Double)
            m_RecorderStart = value
        End Set
    End Property
#End Region
End Class

Public Class CTime
    Private m_Laser As CTimeLaser
    Private m_Tray As CTimeTray
    Private m_Workholder As CTimeWorkholder
    Private m_System As CTimeSystem

    Public Sub New()
        If m_Laser Is Nothing Then m_Laser = New CTimeLaser
        If m_Tray Is Nothing Then m_Tray = New CTimeTray
        If m_Workholder Is Nothing Then m_Workholder = New CTimeWorkholder
        If m_System Is Nothing Then m_System = New CTimeSystem
    End Sub

    Protected Overrides Sub Finalize()
        m_Laser = Nothing
        m_Tray = Nothing
        m_Workholder = Nothing
        m_System = Nothing
        MyBase.Finalize()
    End Sub

    Public Property Laser() As CTimeLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CTimeLaser)
            m_Laser = value
        End Set
    End Property
    Public Property Tray() As CTimeTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CTimeTray)
            m_Tray = value
        End Set
    End Property
    Public Property Workholder() As CTimeWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CTimeWorkholder)
            m_Workholder = value
        End Set
    End Property
    Public Property System() As CTimeSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CTimeSystem)
            m_System = value
        End Set
    End Property
End Class

Public Class CVariableGraphic
    Private m_LineColor As Color
    Private m_PX2MM As Double
    Private m_OffsetX As Integer
    Private m_OffsetY As Integer

    Public Property LineColor As Color
        Get
            Return m_LineColor
        End Get
        Set(ByVal value As Color)
            m_LineColor = value
        End Set
    End Property

    Public Property PX2MM As Double
        Get
            Return m_PX2MM
        End Get
        Set(ByVal value As Double)
            m_PX2MM = value
        End Set
    End Property
    Public Property OffsetX As Double
        Get
            Return m_OffsetX
        End Get
        Set(ByVal value As Double)
            m_OffsetX = value
        End Set
    End Property

    Public Property OffsetY As Double
        Get
            Return m_OffsetY
        End Get
        Set(ByVal value As Double)
            m_OffsetY = value
        End Set
    End Property

    Public Function LoadParam(ByVal pPathFile As String) As Boolean
        LoadParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument
            Dim rtnText As String = ""

            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(pPathFile) Then
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(pPathFile)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement

                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Parameter"), System.Xml.XmlElement)

                With Me
                    If CXmler.GetXmlData(stemNode, "VariableGraphic_LineColor", 0, rtnText) Then .m_LineColor = Color.FromArgb(CInt(rtnText))
                End With
            Else
                Me.m_LineColor = Color.LimeGreen
            End If
            LoadParam = True
        Catch ex As Exception
            Me.m_LineColor = Color.LimeGreen
        End Try

    End Function
    Public Function SaveParam(ByVal pPath As String) As Boolean
        SaveParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim nodeAttributes As New Dictionary(Of String, String)
            Call nodeAttributes.Add("Attributes", "")
            Dim stemNode As System.Xml.XmlElement

            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Parameter", 0, nodeAttributes), System.Xml.XmlElement)
            With Me
                Call CXmler.NewXmlValue(stemNode, "VariableGraphic_LineColor", 0, .m_LineColor.ToArgb())
            End With
            Call xmlDoc.Save(pPath)
            SaveParam = True
        Catch ex As Exception
        End Try
    End Function
End Class

Public Class CVariableLaser
    Private m_LaserOnDelaySegMicrometer As Int32
    Private m_LaserOnSegMicrometer As Int32
    Private m_LaserOffDelaySegMicrometer As Int32
    Private m_LaserOffSegMicrometer As Int32
    Private m_LaserOnDelayContiMicrometer As Int32
    Private m_LaserOffDelayContiMicrometer As Int32
    Private m_SpecCircleRadiusMicrometer As Int32
    Private m_SpecCircleONDelayMicrometer As Int32
    Private m_GalvanometerGainX As Double
    Private m_GalvanometerGainY As Double
    Private m_GalvanometerRotationalAngleInDegree As Double
    Private m_GalvanometerFpk As Int32
    Private m_PRR As Double
    Private m_Power As Double
    Private m_Angle As Double
    Private m_OffsetX As Integer
    Private m_OffsetY As Integer


    ''' <summary>
    ''' Rotational angle in degrees. 
    ''' Allowed values:[-10....+10]. 
    ''' Positive angles: rotation is counterclockwise
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Angle As Double
        Get
            Return m_Angle
        End Get
        Set(ByVal value As Double)
            If (value < -10) Then
                m_Angle = -10
            ElseIf (value > 10) Then
                m_Angle = 10
            Else
                m_Angle = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' additional offset in bits. 
    ''' Allowed values: [-32768....32767]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OffsetX As Integer
        Get
            Return m_OffsetX
        End Get
        Set(ByVal value As Integer)
            If (value < -32768) Then
                m_OffsetX = -32768
            ElseIf (value > 32767) Then
                m_OffsetX = 32767
            Else
                m_OffsetX = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' additional offset in bits. 
    ''' Allowed values: [-32768....32767]
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OffsetY As Integer
        Get
            Return m_OffsetY
        End Get
        Set(ByVal value As Integer)
            If (value < -32768) Then
                m_OffsetY = -32768
            ElseIf (value > 32767) Then
                m_OffsetY = 32767
            Else
                m_OffsetY = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' 連續點判斷偏移量X (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PolyErrorXum As Int32
    ''' <summary>
    ''' 連續點判斷偏移量Y (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PolyErrorYum As Int32
    Private m_SmallArcDefInMicrometer As Int32
    Private m_CircleRadiusMapOld(0 To 16) As Int32
    Private m_CircleRadiusMapNew(0 To 16) As Int32

    'Private  m_CircleRadiusDifOld As Int32
    'Private  m_CircleRadiusDifNew As Int32

    Private m_PinHoleDefLeftX As Double
    Private m_PinHoleDefLeftY As Double
    Private m_PinHoleDefRightX As Double
    Private m_PinHoleDefRightY As Double
    Private m_PinHoleDefLeftX2 As Double
    Private m_PinHoleDefLeftY2 As Double
    Private m_PinHoleDefRightX2 As Double
    Private m_PinHoleDefRightY2 As Double
    Private m_SubstrateHeight As Double

    ''' <summary>
    ''' 圖面定位孔位置,1象限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleDefLeftX() As Double
        Get
            Return m_PinHoleDefLeftX
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftX = value
        End Set
    End Property
    ''' <summary>
    ''' 圖面定位孔位置,1象限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleDefLeftY() As Double
        Get
            Return m_PinHoleDefLeftY
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftY = value
        End Set
    End Property
    Public Property PinHoleDefRightX() As Double
        Get
            Return m_PinHoleDefRightX
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightX = value
        End Set
    End Property
    Public Property PinHoleDefRightY() As Double
        Get
            Return m_PinHoleDefRightY
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightY = value
        End Set
    End Property

    Public Property PinHoleDefLeftX2() As Double
        Get
            Return m_PinHoleDefLeftX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftX2 = value
        End Set
    End Property
    ''' <summary>
    ''' 圖面定位孔位置,1象限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleDefLeftY2() As Double
        Get
            Return m_PinHoleDefLeftY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftY2 = value
        End Set
    End Property
    Public Property PinHoleDefRightX2() As Double
        Get
            Return m_PinHoleDefRightX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightX2 = value
        End Set
    End Property
    Public Property PinHoleDefRightY2() As Double
        Get
            Return m_PinHoleDefRightY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightY2 = value
        End Set
    End Property


    Public Property SubstrateHeight() As Double
        Get
            Return m_SubstrateHeight
        End Get
        Set(ByVal value As Double)
            m_SubstrateHeight = value
        End Set
    End Property



    ''' <summary>
    ''' 平台切割需向前延伸的長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOnDelaySegMicrometer() As Int32
        Get
            Return m_LaserOnDelaySegMicrometer
        End Get
        Set(ByVal value As Int32)

            m_LaserOnDelaySegMicrometer = value

        End Set
    End Property

    ''' <summary>
    ''' 平台切割雷射開啟延伸的長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOnSegMicrometer() As Int32
        Get
            Return m_LaserOnSegMicrometer
        End Get
        Set(ByVal value As Int32)

            m_LaserOnSegMicrometer = value
        End Set
    End Property

    ''' <summary>
    ''' 平台切割需向後延伸的長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOffDelaySegMicrometer() As Int32
        Get
            Return m_LaserOffDelaySegMicrometer
        End Get
        Set(ByVal value As Int32)

            m_LaserOffDelaySegMicrometer = value

        End Set
    End Property

    ''' <summary>
    ''' 平台切割雷射關閉後延伸的長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOffSegMicrometer() As Int32
        Get
            Return m_LaserOffSegMicrometer
        End Get
        Set(ByVal value As Int32)
            m_LaserOffSegMicrometer = value
        End Set
    End Property

    Public Property LaserOnDelayContiMicrometer() As Int32
        Get
            Return m_LaserOnDelayContiMicrometer
        End Get
        Set(ByVal value As Int32)

            m_LaserOnDelayContiMicrometer = value

        End Set
    End Property

    Public Property LaserOffDelayContiMicrometer() As Int32
        Get
            Return m_LaserOffDelayContiMicrometer
        End Get
        Set(ByVal value As Int32)

            m_LaserOffDelayContiMicrometer = value

        End Set
    End Property

    Public Property SpecCircleRadiusMicrometer() As Int32
        Get
            Return m_SpecCircleRadiusMicrometer
        End Get
        Set(ByVal value As Int32)

            m_SpecCircleRadiusMicrometer = value

        End Set
    End Property

    Public Property SpecCircleONDelayMicrometer() As Int32
        Get
            Return m_SpecCircleONDelayMicrometer
        End Get
        Set(ByVal value As Int32)

            m_SpecCircleONDelayMicrometer = value

        End Set
    End Property

    Public Property GalvanometerGainX() As Double
        Get
            Return m_GalvanometerGainX
        End Get
        Set(ByVal value As Double)

            m_GalvanometerGainX = value

        End Set
    End Property

    Public Property GalvanometerGainY() As Double
        Get
            Return m_GalvanometerGainY
        End Get
        Set(ByVal value As Double)

            m_GalvanometerGainY = value

        End Set
    End Property

    Public Property GalvanometerRotationalAngleInDegree() As Double
        Get
            Return m_GalvanometerRotationalAngleInDegree
        End Get
        Set(ByVal value As Double)

            m_GalvanometerRotationalAngleInDegree = value

        End Set
    End Property
    Public Property GalvanometerFpk() As Int32
        Get
            Return m_GalvanometerFpk
        End Get
        Set(ByVal value As Int32)

            m_GalvanometerFpk = value

        End Set
    End Property

    Public Property SmallArcDefInMicrometer() As Int32
        Get
            Return m_SmallArcDefInMicrometer
        End Get
        Set(ByVal value As Int32)

            m_SmallArcDefInMicrometer = value

        End Set
    End Property

    ''' <summary>
    ''' 連續點判斷偏移量X (μm) 未使用..切割機用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PolyErrorXum() As Int32
        Get
            Return m_PolyErrorXum
        End Get
        Set(ByVal value As Int32)

            m_PolyErrorXum = value

        End Set
    End Property
    ''' <summary>
    ''' 連續點判斷偏移量Y (μm) 未使用..切割機用
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PolyErrorYum() As Int32
        Get
            Return m_PolyErrorYum
        End Get
        Set(ByVal value As Int32)

            m_PolyErrorYum = value

        End Set
    End Property

    Public Property CircleRadiusMapOld(ByVal Idx As Int32) As Int32
        Get
            Return m_CircleRadiusMapOld(Idx)
        End Get
        Set(ByVal value As Int32)

            m_CircleRadiusMapOld(Idx) = value

        End Set
    End Property

    Public Property CircleRadiusMapNew(ByVal Idx As Int32) As Int32
        Get
            Return m_CircleRadiusMapNew(Idx)
        End Get
        Set(ByVal value As Int32)

            m_CircleRadiusMapNew(Idx) = value

        End Set
    End Property

    Public Property PRR As Double
        Get
            Return m_PRR
        End Get
        Set(ByVal value As Double)
            m_PRR = value
        End Set
    End Property

    Public Property Power As Double
        Get
            Return m_Power
        End Get
        Set(ByVal value As Double)
            m_Power = value
        End Set
    End Property

    Public Sub New()

    End Sub
    Public Function LoadParam(ByVal pPath As String) As Boolean
        LoadParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument
            Dim rtnText As String = ""

            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(pPath) Then
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(pPath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement

                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Parameter"), System.Xml.XmlElement)

                With Me
                    If CXmler.GetXmlData(stemNode, "VariableLaser_PRR", 0, rtnText) Then .PRR = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "VariableLaser_Power", 0, rtnText) Then .Power = CDbl(rtnText)
                    'If CXmler.GetXmlData(stemNode, "VariableLaser_OffsetX", 0, rtnText) Then .OffsetX = CInt(rtnText)
                    'If CXmler.GetXmlData(stemNode, "VariableLaser_OffsetY", 0, rtnText) Then .OffsetY = CInt(rtnText)
                    'If CXmler.GetXmlData(stemNode, "VariableLaser_Angle", 0, rtnText) Then .Angle = CDbl(rtnText)
                End With
            Else
                m_PRR = 20
                m_Power = 20
            End If
            LoadParam = True
        Catch ex As Exception
            m_PRR = 20
            m_Power = 20
        End Try
    End Function
    Public Function SaveParam(ByVal pPath As String) As Boolean
        SaveParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim nodeAttributes As New Dictionary(Of String, String)
            Call nodeAttributes.Add("Attributes", "")
            Dim stemNode As System.Xml.XmlElement

            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Parameter", 0, nodeAttributes), System.Xml.XmlElement)
            With Me
                Call CXmler.NewXmlValue(stemNode, "VariableLaser_PRR", 0, .PRR)
                Call CXmler.NewXmlValue(stemNode, "VariableLaser_Power", 0, .Power)
                'Call CXmler.NewXmlValue(stemNode, "VariableLaser_OffsetX", 0, .OffsetX)
                'Call CXmler.NewXmlValue(stemNode, "VariableLaser_OffsetY", 0, .OffsetY)
                'Call CXmler.NewXmlValue(stemNode, "VariableLaser_Angle", 0, .Angle)
            End With
            Call xmlDoc.Save(pPath)
            SaveParam = True
        Catch ex As Exception
        End Try
    End Function
End Class

Public Class CVariableTray

End Class

Public Class CVariableWorkholder
    Private m_CCDRatioX As Double
    Private m_CCDRatioY As Double
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetXMatch As Double
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetYMatch As Double
    ''' <summary>
    ''' 尋邊影像中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetXEdge As Double
    ''' <summary>
    ''' 尋邊影像中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetYEdge As Double

    Private m_BallScrewPitch As Int32
    Private m_Radius As Int32
    Private m_PulsePerCount As Int32
    Private m_ImageError As Int32

    Private m_PinHoleLeftX As Double
    Private m_PinHoleLeftY As Double
    Private m_PinHoleRightX As Double
    Private m_PinHoleRightY As Double
    Private m_PinHoleLeftX2 As Double
    Private m_PinHoleLeftY2 As Double
    Private m_PinHoleRightX2 As Double
    Private m_PinHoleRightY2 As Double
    Private m_ThetaRadCCW As Double
    Public Property CCDRatioX() As Double
        Get
            Return m_CCDRatioX
        End Get
        Set(ByVal value As Double)
            m_CCDRatioX = value
        End Set
    End Property
    Public Property CCDRatioY() As Double
        Get
            Return m_CCDRatioY
        End Get
        Set(ByVal value As Double)
            m_CCDRatioY = value
        End Set
    End Property
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetXMatch() As Double
        Get
            Return m_LaserOrgCCDOffsetXMatch
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetXMatch = value
        End Set
    End Property
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetYMatch() As Double
        Get
            Return m_LaserOrgCCDOffsetYMatch
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetYMatch = value
        End Set
    End Property
    ''' <summary>
    ''' 尋邊影像中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetXEdge() As Double
        Get
            Return m_LaserOrgCCDOffsetXEdge
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetXEdge = value
        End Set
    End Property
    ''' <summary>
    ''' 尋邊影像中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetYEdge() As Double
        Get
            Return m_LaserOrgCCDOffsetYEdge
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetYEdge = value
        End Set
    End Property

    Public Property BallScrewPitch() As Int32
        Get
            Return m_BallScrewPitch
        End Get
        Set(ByVal value As Int32)
            m_BallScrewPitch = value
        End Set
    End Property
    Public Property Radius() As Int32
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Int32)
            m_Radius = value
        End Set
    End Property
    Public Property PulsePerCount() As Int32
        Get
            Return m_PulsePerCount
        End Get
        Set(ByVal value As Int32)
            m_PulsePerCount = value
        End Set
    End Property
    Public Property ImageError() As Int32
        Get
            Return m_ImageError
        End Get
        Set(ByVal value As Int32)
            m_ImageError = value
        End Set
    End Property

    ''' <summary>
    ''' 視覺定位計算對位孔馬達位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleLeftX() As Double
        Get
            Return m_PinHoleLeftX
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftX = value
        End Set
    End Property
    ''' <summary>
    ''' 視覺定位計算對位孔馬達位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleLeftY() As Double
        Get
            Return m_PinHoleLeftY
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftY = value
        End Set
    End Property
    Public Property PinHoleRightX() As Double
        Get
            Return m_PinHoleRightX
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightX = value
        End Set
    End Property
    Public Property PinHoleRightY() As Double
        Get
            Return m_PinHoleRightY
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightY = value
        End Set
    End Property
    Public Property PinHoleLeftX2() As Double
        Get
            Return m_PinHoleLeftX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftX2 = value
        End Set
    End Property
    Public Property PinHoleLeftY2() As Double
        Get
            Return m_PinHoleLeftY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftY2 = value
        End Set
    End Property
    Public Property PinHoleRightX2() As Double
        Get
            Return m_PinHoleRightX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightX2 = value
        End Set
    End Property
    Public Property PinHoleRightY2() As Double
        Get
            Return m_PinHoleRightY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightY2 = value
        End Set
    End Property

    ''' <summary>
    ''' 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThetaRadCCW() As Double
        Get
            Return m_ThetaRadCCW
        End Get
        Set(ByVal value As Double)
            m_ThetaRadCCW = value
        End Set
    End Property
End Class

Public Class CVariableSystem
    Private m_ProductName As String



    Public Property ProductName() As String
        Get
            Return m_ProductName
        End Get
        Set(ByVal value As String)
            m_ProductName = value
        End Set
    End Property
End Class

Public Class CVariableIO
    Private m_DIDelay As Integer
    Private m_DODelay As Integer
    Private m_Blow1Delay As Integer
    Private m_UseBlow2 As Boolean
    ''' <summary>
    ''' Digital Input Delay (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DIDelay As Integer
        Get
            Return m_DIDelay
        End Get
        Set(ByVal value As Integer)
            m_DIDelay = value
        End Set
    End Property

    ''' <summary>
    ''' Digital Output Delay (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DODelay As Integer
        Get
            Return m_DODelay
        End Get
        Set(ByVal value As Integer)
            m_DODelay = value
        End Set
    End Property

    ''' <summary>
    ''' Blow 1 Delay (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Blow1Delay As Integer
        Get
            Return m_Blow1Delay
        End Get
        Set(ByVal value As Integer)
            m_Blow1Delay = value
        End Set
    End Property

    ''' <summary>
    ''' Use Blow 2
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property UseBlow2 As Boolean
        Get
            Return m_UseBlow2
        End Get
        Set(ByVal value As Boolean)
            m_UseBlow2 = value
        End Set
    End Property

End Class
Public Class CVariable
    Private m_System As CVariableSystem
    Private m_Laser As CVariableLaser
    Private m_Tray As CVariableTray
    Private m_Workholder As CVariableWorkholder
    Private m_Align As CVariableAlign
    Private m_Graphic As CVariableGraphic
    Private m_IO As CVariableIO
    Public Sub New()
        If m_System Is Nothing Then m_System = New CVariableSystem
        If m_Laser Is Nothing Then m_Laser = New CVariableLaser
        If m_Tray Is Nothing Then m_Tray = New CVariableTray
        If m_Workholder Is Nothing Then m_Workholder = New CVariableWorkholder
        If m_Align Is Nothing Then m_Align = New CVariableAlign
        If m_Graphic Is Nothing Then m_Graphic = New CVariableGraphic
        If m_IO Is Nothing Then m_IO = New CVariableIO
    End Sub

    Protected Overrides Sub Finalize()
        m_System = Nothing
        m_Laser = Nothing
        m_Tray = Nothing
        m_Workholder = Nothing
        m_Align = Nothing
        m_Graphic = Nothing
        m_IO = Nothing
        MyBase.Finalize()
    End Sub
    Public Property System() As CVariableSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CVariableSystem)
            m_System = value
        End Set
    End Property
    Public Property Laser() As CVariableLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CVariableLaser)
            m_Laser = value
        End Set
    End Property
    Public Property Tray() As CVariableTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CVariableTray)
            m_Tray = value
        End Set
    End Property
    Public Property Workholder() As CVariableWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CVariableWorkholder)
            m_Workholder = value
        End Set
    End Property
    Public Property Align() As CVariableAlign
        Get
            Return m_Align
        End Get
        Set(ByVal value As CVariableAlign)
            m_Align = value
        End Set
    End Property
    Public Property Graphic() As CVariableGraphic
        Get
            Return m_Graphic
        End Get
        Set(ByVal value As CVariableGraphic)
            m_Graphic = value
        End Set
    End Property
    Public Property IO() As CVariableIO
        Get
            Return m_IO
        End Get
        Set(ByVal value As CVariableIO)
            m_IO = value
        End Set
    End Property
End Class



Public Class CSpeedLaser
    Private m_GalvanometerJumpSpeed As Int32
    Private m_GalvanometerMarkSpeed As Int32
    Private m_TableJumpSpeed As Int32
    Private m_TableLineSpeed As Int32
    Private m_TableArcSpeed As Int32
    Private m_TableArcSmallSpeed As Int32
    Private m_TableCircleSpeed As Int32
    Private m_TableAcceration As Int32
    Private m_TableDeceration As Int32

    Public Property GalvanometerJumpSpeed() As Int32
        Get
            Return m_GalvanometerJumpSpeed
        End Get
        Set(ByVal value As Int32)

            m_GalvanometerJumpSpeed = value

        End Set
    End Property

    Public Property GalvanometerMarkSpeed() As Int32
        Get
            Return m_GalvanometerMarkSpeed
        End Get
        Set(ByVal value As Int32)

            m_GalvanometerMarkSpeed = value

        End Set
    End Property

    Public Property TableJumpSpeed() As Int32
        Get
            Return m_TableJumpSpeed
        End Get
        Set(ByVal value As Int32)

            m_TableJumpSpeed = value

        End Set
    End Property


    Public Property TableLineSpeed() As Int32
        Get
            Return m_TableLineSpeed
        End Get
        Set(ByVal value As Int32)

            m_TableLineSpeed = value

        End Set
    End Property

    Public Property TableArcSpeed() As Int32
        Get
            Return m_TableArcSpeed
        End Get
        Set(ByVal value As Int32)

            m_TableArcSpeed = value

        End Set
    End Property

    Public Property TableArcSmallSpeed() As Int32
        Get
            Return m_TableArcSmallSpeed
        End Get
        Set(ByVal value As Int32)

            m_TableArcSmallSpeed = value

        End Set
    End Property

    Public Property TableCircleSpeed() As Int32
        Get
            Return m_TableCircleSpeed
        End Get
        Set(ByVal value As Int32)

            m_TableCircleSpeed = value

        End Set
    End Property

    Public Property TableAcceration() As Int32
        Get
            Return m_TableAcceration
        End Get
        Set(ByVal value As Int32)

            m_TableAcceration = value

        End Set
    End Property

    Public Property TableDeceration() As Int32
        Get
            Return m_TableDeceration
        End Get
        Set(ByVal value As Int32)

            m_TableDeceration = value

        End Set
    End Property

End Class

Public Class CSpeed
    Private m_Laser As CSpeedLaser
    Public Sub New()

        If m_Laser Is Nothing Then m_Laser = New CSpeedLaser

    End Sub

    Protected Overrides Sub Finalize()

        m_Laser = Nothing

        MyBase.Finalize()

    End Sub

    Public Property Laser() As CSpeedLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CSpeedLaser)

            m_Laser = value

        End Set
    End Property
End Class

Public Class CVariableAlign
    Private Const MAX_SIZE As Integer = 5
    Private m_ImageOriginalOffsetX(MAX_SIZE - 1) As Double
    Private m_ImageOriginalOffsetY(MAX_SIZE - 1) As Double
    Private m_ImageOriginalAngle(MAX_SIZE - 1) As Double

    Private m_ImageCenterX(MAX_SIZE - 1) As Double
    Private m_ImageCenterY(MAX_SIZE - 1) As Double

    Private m_AlignX(MAX_SIZE - 1) As Double
    Private m_AlignY(MAX_SIZE - 1) As Double
    Private m_AlignAngle(MAX_SIZE - 1) As Double

    ''' <summary>
    ''' Original Offset X on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOriginalOffsetX As Double()
        Get
            Return m_ImageOriginalOffsetX
        End Get
        Set(ByVal value As Double())
            m_ImageOriginalOffsetX = value
        End Set
    End Property

    ''' <summary>
    ''' Original Offset Y on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOriginalOffsetY As Double()
        Get
            Return m_ImageOriginalOffsetY
        End Get
        Set(ByVal value As Double())
            m_ImageOriginalOffsetY = value
        End Set
    End Property
    ''' <summary>
    ''' Original Angle on  Image Coordinate (uinit is degree)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOrginalAngle As Double()
        Get
            Return m_ImageOriginalAngle
        End Get
        Set(ByVal value As Double())
            m_ImageOriginalAngle = value
        End Set
    End Property

    ''' <summary>
    ''' Center X on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageCenterX As Double()
        Get
            Return m_ImageCenterX
        End Get
        Set(ByVal value As Double())
            m_ImageCenterX = value
        End Set
    End Property

    ''' <summary>
    ''' Center Y on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageCenterY As Double()
        Get
            Return m_ImageCenterY
        End Get
        Set(ByVal value As Double())
            m_ImageCenterY = value
        End Set
    End Property

    ''' <summary>
    ''' Original X on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOrginalOffsetX(ByVal idx As Integer) As Double
        Get
            Return m_ImageOriginalOffsetX(idx)
        End Get
        Set(ByVal value As Double)
            m_ImageOriginalOffsetX(idx) = value
        End Set
    End Property

    ''' <summary>
    ''' Original Y on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOrginalOffsetY(ByVal idx As Integer) As Double
        Get
            Return m_ImageOriginalOffsetY(idx)
        End Get
        Set(ByVal value As Double)
            m_ImageOriginalOffsetY(idx) = value
        End Set
    End Property
    ''' <summary>
    ''' Original Angle on  Image Coordinate (uinit is degree)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageOrginalAngle(ByVal idx As Integer) As Double
        Get
            Return m_ImageOriginalAngle(idx)
        End Get
        Set(ByVal value As Double)
            m_ImageOriginalAngle(idx) = value
        End Set
    End Property

    ''' <summary>
    ''' Center X on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageCenterX(ByVal idx As Integer) As Double
        Get
            Return m_ImageCenterX(idx)
        End Get
        Set(ByVal value As Double)
            m_ImageCenterX(idx) = value
        End Set
    End Property

    ''' <summary>
    ''' Center Y on  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageCenterY(ByVal idx As Integer) As Double
        Get
            Return m_ImageCenterY(idx)
        End Get
        Set(ByVal value As Double)
            m_ImageCenterY(idx) = value
        End Set
    End Property


    Public Function LoadParam(ByVal pPath As String) As Boolean
        LoadParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument
            Dim rtnText As String = ""

            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(pPath) Then
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(pPath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement

                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Parameter"), System.Xml.XmlElement)

                ReDim m_ImageOriginalOffsetX(0 To MAX_SIZE - 1)
                ReDim m_ImageOriginalOffsetY(0 To MAX_SIZE - 1)
                ReDim m_ImageOriginalAngle(0 To MAX_SIZE - 1)
                ReDim m_ImageCenterX(0 To MAX_SIZE - 1)
                ReDim m_ImageCenterY(0 To MAX_SIZE - 1)
                With Me

                    For idx = 0 To MAX_SIZE - 1
                        If CXmler.GetXmlData(stemNode, "VariableAlign_OrginalX_" & idx, 0, rtnText) Then .ImageOrginalOffsetX(idx) = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode, "VariableAlign_OrginalY_" & idx, 0, rtnText) Then .ImageOrginalOffsetY(idx) = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode, "VariableAlign_OrginalAngle_" & idx, 0, rtnText) Then .ImageOrginalAngle(idx) = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode, "VariableAlign_CenterX_" & idx, 0, rtnText) Then .ImageCenterX(idx) = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode, "VariableAlign_CenterY_" & idx, 0, rtnText) Then .ImageCenterY(idx) = CDbl(rtnText)
                    Next
                End With
            End If
            LoadParam = True
        Catch ex As Exception
        End Try
    End Function
    Public Function SaveParam(ByVal pPath As String) As Boolean
        SaveParam = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim nodeAttributes As New Dictionary(Of String, String)
            Call nodeAttributes.Add("Attributes", "")
            Dim stemNode As System.Xml.XmlElement

            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Parameter", 0, nodeAttributes), System.Xml.XmlElement)
            With Me

                For idx = 0 To MAX_SIZE - 1
                    Call CXmler.NewXmlValue(stemNode, "VariableAlign_OrginalX_" & idx, 0, .ImageOrginalOffsetX(idx))
                    Call CXmler.NewXmlValue(stemNode, "VariableAlign_OrginalY_" & idx, 0, .ImageOrginalOffsetY(idx))
                    Call CXmler.NewXmlValue(stemNode, "VariableAlign_OrginalAngle_" & idx, 0, .ImageOrginalAngle(idx))
                    Call CXmler.NewXmlValue(stemNode, "VariableAlign_CenterX_" & idx, 0, .ImageCenterX(idx))
                    Call CXmler.NewXmlValue(stemNode, "VariableAlign_CenterY_" & idx, 0, .ImageCenterY(idx))
                Next
            End With
            Call xmlDoc.Save(pPath)
            SaveParam = True
        Catch ex As Exception
        End Try
    End Function
End Class
Public Class CParam
#Region "CONSTANT"

    Private Const MCS_COUNT_SYSTEM_IMAGEALIGNMENTRETRY As String = "COUNT_SYSTEM_IMAGEALIGNMENTRETRY"
    Private Const MCS_COUNT_SYSTEM_TRAYIN As String = "COUNT_SYSTEM_TRAYIN"
    Private Const MCS_COUNT_TRAY_PIECETOSTOP As String = "COUNT_TRAY_PIECETOSTOP"
    Private Const MCS_COUNT_TRAY_TRAYOUTNGMAX As String = "COUNT_TRAY_TRAYOUTNGMAX"
    Private Const MCS_COUNT_WORKHOLDER_IMAGEALIGNMENTRETRYMAX As String = "COUNT_WORKHOLDER_IMAGEALIGNMENTRETRYMAX"
    Private Const MCS_FLAGS_SYSTEM_INSPECTIONMETHODS As String = "FLAGS_SYSTEM_INSPECTIONMETHODS"
    Private Const MCS_FLAGS_SYSTEM_LEFTSYSTEMUSED As String = "FLAGS_SYSTEM_LEFTSYSTEMUSED"
    Private Const MCS_FLAGS_SYSTEM_AUTORUNPROCEDURE As String = "FLAGS_SYSTEM_AUTORUNPROCEDURE"
    Private Const MCS_FLAGS_SYSTEM_NORMALPROCEDUREUSED As String = "FLAGS_SYSTEM_NORMALPROCEDUREUSED"
    Private Const MCS_FLAGS_SYSTEM_RIGHTSYSTEMUSED As String = "FLAGS_SYSTEM_RIGHTSYSTEMUSED"
    Private Const MCS_FLAGS_SYSTEM_VACCUMLASERDRILLINGCHECKED As String = "FLAGS_SYSTEM_VACCUMLASERDRILLINGCHECKED"
    Private Const MCS_FLAGS_SYSTEM_SubstrateInVaccumChecked As String = "FLAGS_SYSTEM_SubstrateInVaccumChecked"
    Private Const MCS_FLAGS_SYSTEM_VACCUMTRAYOUTCHECKED As String = "FLAGS_SYSTEM_VACCUMTRAYOUTCHECKED"

    Private Const MCS_FLAGS_SYSTEM_LASERTRIMBATCHCHECKEDUSED As String = "FLAGS_SYSTEM_LASERTRIMBATCHCHECKEDUSED"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMBATCHHIGHLIMIT As String = "FLAGS_SYSTEM_LASERTRIMBATCHHIGHLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMBATCHLOWLIMIT As String = "FLAGS_SYSTEM_LASERTRIMBATCHLOWLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMBATCHOPENLIMIT As String = "FLAGS_SYSTEM_LASERTRIMBATCHOPENLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMBATCHYIELDLIMIT As String = "FLAGS_SYSTEM_LASERTRIMBATCHYIELDLIMIT"

    Private Const MCS_FLAGS_SYSTEM_LASERTRIMPIECECHECKEDUSED As String = "FLAGS_SYSTEM_LASERTRIMPIECECHECKEDUSED"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMPIECEHIGHLIMIT As String = "FLAGS_SYSTEM_LASERTRIMPIECEHIGHLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMPIECELOWLIMIT As String = "FLAGS_SYSTEM_LASERTRIMPIECELOWLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMPIECEOPENLIMIT As String = "FLAGS_SYSTEM_LASERTRIMPIECEOPENLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMPIECEYIELDLIMIT As String = "FLAGS_SYSTEM_LASERTRIMPIECEYIELDLIMIT"

    Private Const MCS_FLAGS_SYSTEM_LASERTRIMROWSCHECKEDUSED As String = "FLAGS_SYSTEM_LASERTRIMROWSCHECKEDUSED"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMROWSHIGHLIMIT As String = "FLAGS_SYSTEM_LASERTRIMROWSHIGHLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMROWSLOWLIMIT As String = "FLAGS_SYSTEM_LASERTRIMROWSLOWLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMROWSOPENLIMIT As String = "FLAGS_SYSTEM_LASERTRIMROWSOPENLIMIT"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMROWSYIELDLIMIT As String = "FLAGS_SYSTEM_LASERTRIMROWSYIELDLIMIT"


    Private Const MCS_FLAGS_SYSTEM_LASERTRIMSTOPCHECKPIECEYIELDUSED As String = "FLAGS_SYSTEM_LASERTRIMSTOPCHECKPIECEYIELDUSED"
    Private Const MCS_FLAGS_SYSTEM_LASERTRIMSTOPCHECKPIECEYIELDNUM As String = "FLAGS_SYSTEM_LASERTRIMSTOPCHECKPIECEYIELDNUM"

    Private Const MCS_FLAGS_SYSTEM_LASERTRIMWRITEPARAMYIELDUSED As String = "FLAGS_SYSTEM_LASERTRIMWRITEPARAMYIELDUSED"

    Private Const MCS_IDX_SYSTEM_IMAGEALIGNMENTRETRY As String = "IDX_SYSTEM_IMAGEALIGNMENTRETRY"
    Private Const MCS_IDX_SYSTEM_PIECENOGOOD As String = "IDX_SYSTEM_PIECENOGOOD"
    Private Const MCS_IDX_SYSTEM_PIECEOK As String = "IDX_SYSTEM_PIECEOK"
    Private Const MCS_IDX_SYSTEM_TRAYIN As String = "IDX_SYSTEM_TRAYIN"
    Private Const MCS_IDX_TRAY_TRAYIN As String = "IDX_TRAY_TRAYIN"
    Private Const MCS_IDX_TRAY_TRAYOUTNG As String = "IDX_TRAY_TRAYOUTNG"
    Private Const MCS_POS_CLAMPER_FRONTYLEFT As String = "POS_CLAMPER_FRONTYLEFT"
    Private Const MCS_POS_CLAMPER_FRONTYRIGHT As String = "POS_CLAMPER_FRONTYRIGHT"
    Private Const MCS_POS_CLAMPER_REARYLEFT As String = "POS_CLAMPER_REARYLEFT"
    Private Const MCS_POS_CLAMPER_REARYRIGHT As String = "POS_CLAMPER_REARYRIGHT"
    Private Const MCS_POS_LASER_RESISTORGALVOMIDDLEX As String = "VARIABLE_LASER_RESISTORGALVOMIDDLEX"
    Private Const MCS_POS_LASER_axisId As String = "VARIABLE_LASER_axisId"
    Private Const MCS_POS_PROBE_INITIALZ As String = "POS_PROBE_INITIALZ"
    Private Const MCS_POS_PROBE_SAFEZ As String = "POS_PROBE_SAFEZ"
    Private Const MCS_POS_PROBE_TOUCHZ As String = "POS_PROBE_TOUCHZ"
    Private Const MCS_POS_PROBE_LOWESTZ As String = "POS_PROBE_LOWESTZ"
    Private Const MCS_POS_PROBE_CHANGEPANELZ As String = "POS_PROBE_CHANGEPANELZ"
    Private Const MCS_POS_WORKHOLDER_ALIGNCAMERAXLEFT As String = "POS_WORKHOLDER_ALIGNCAMERAXLEFT"
    Private Const MCS_POS_WORKHOLDER_ALIGNCAMERAXRIGHT As String = "POS_WORKHOLDER_ALIGNCAMERAXRIGHT"
    Private Const MCS_POS_WORKHOLDER_ALIGNCAMERAYLEFT As String = "POS_WORKHOLDER_ALIGNCAMERAYLEFT"
    Private Const MCS_POS_WORKHOLDER_ALIGNCAMERAYRIGHT As String = "POS_WORKHOLDER_ALIGNCAMERAYRIGHT"
    Private Const MCS_POS_WORKHOLDER_ALIGNLASERXLEFT As String = "POS_WORKHOLDER_ALIGNLASERXLEFT"
    Private Const MCS_POS_WORKHOLDER_ALIGNLASERXRIGHT As String = "POS_WORKHOLDER_ALIGNLASERXRIGHT"
    Private Const MCS_POS_WORKHOLDER_ALIGNLASERYLEFT As String = "POS_WORKHOLDER_ALIGNLASERYLEFT"
    Private Const MCS_POS_WORKHOLDER_ALIGNLASERYRIGHT As String = "POS_WORKHOLDER_ALIGNLASERYRIGHT"

    Private Const MCS_POS_WORKHOLDER_ALIGNREALXRIGHT As String = "POS_WORKHOLDER_ALIGNREALXRIGHT"
    Private Const MCS_POS_WORKHOLDER_ALIGNREALYLEFT As String = "POS_WORKHOLDER_ALIGNREALYLEFT"
    Private Const MCS_POS_WORKHOLDER_ALIGNREALYRIGHT As String = "POS_WORKHOLDER_ALIGNREALYRIGHT"
    Private Const MCS_POS_WORKHOLDER_SubstrateAlignTLEFT As String = "POS_WORKHOLDER_SubstrateAlignTLEFT"
    Private Const MCS_POS_WORKHOLDER_SubstrateAlignTRIGHT As String = "POS_WORKHOLDER_SubstrateAlignTRIGHT"
    Private Const MCS_POS_WORKHOLDER_SubstrateInX1Left As String = "POS_WORKHOLDER_SubstrateInX1Left"
    Private Const MCS_POS_WORKHOLDER_SubstrateInX1Right As String = "POS_WORKHOLDER_SubstrateInX1Right"
    Private Const MCS_POS_WORKHOLDER_SubstrateInY1Left As String = "POS_WORKHOLDER_SubstrateInY1Left"
    Private Const MCS_POS_WORKHOLDER_SubstrateInY1Right As String = "POS_WORKHOLDER_SubstrateInY1Right"
    Private Const MCS_POS_WORKHOLDER_SubstrateNGXLEFT As String = "POS_WORKHOLDER_SubstrateNGXLEFT"
    Private Const MCS_POS_WORKHOLDER_SubstrateNGXRIGHT As String = "POS_WORKHOLDER_SubstrateNGXRIGHT"
    Private Const MCS_POS_WORKHOLDER_SubstrateNGYLEFT As String = "POS_WORKHOLDER_SubstrateNGYLEFT"
    Private Const MCS_POS_WORKHOLDER_SubstrateNGYRIGHT As String = "POS_WORKHOLDER_SubstrateNGYRIGHT"
    Private Const MCS_POS_WORKHOLDER_SubstrateOutX1Left As String = "POS_WORKHOLDER_SubstrateOutX1Left"
    Private Const MCS_POS_WORKHOLDER_SubstrateOutX1RIGHT As String = "POS_WORKHOLDER_SubstrateOutX1RIGHT"
    Private Const MCS_POS_WORKHOLDER_SubstrateOutY1Left As String = "POS_WORKHOLDER_SubstrateOutY1Left"
    Private Const MCS_POS_WORKHOLDER_SubstrateOutY1RIGHT As String = "POS_WORKHOLDER_SubstrateOutY1RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX1LEFT As String = "POS_WORKHOLDER_VISIONALIGNX1LEFT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX1RIGHT As String = "POS_WORKHOLDER_VISIONALIGNX1RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX2LEFT As String = "POS_WORKHOLDER_VISIONALIGNX2LEFT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX2RIGHT As String = "POS_WORKHOLDER_VISIONALIGNX2RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX3LEFT As String = "POS_WORKHOLDER_VISIONALIGNX3LEFT"
    Private Const MCS_POS_WORKHOLDER_VISIONALIGNX3RIGHT As String = "POS_WORKHOLDER_VISIONALIGNX3RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY1LEFT As String = "POS_WORKHOLDER_VISONALIGNY1LEFT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY1RIGHT As String = "POS_WORKHOLDER_VISONALIGNY1RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY2LEFT As String = "POS_WORKHOLDER_VISONALIGNY2LEFT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY2RIGHT As String = "POS_WORKHOLDER_VISONALIGNY2RIGHT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY3LEFT As String = "POS_WORKHOLDER_VISONALIGNY3LEFT"
    Private Const MCS_POS_WORKHOLDER_VISONALIGNY3RIGHT As String = "POS_WORKHOLDER_VISONALIGNY3RIGHT"

    Private Const MCS_FLAGS_SYSTEM_VISIONALIGNED As String = "FLAG_SYSTEM_VISIONALIGNED"

    Private Const MCS_STATISTIC_CIRCUITCNT As String = "STATISTIC_CIRCUITCNT"
    Private Const MCS_STATISTIC_CIRCUITUPH As String = "STATISTIC_CIRCUITUPH"
    Private Const MCS_STATISTIC_FULLLENGTHCNT As String = "STATISTIC_FULLLENGTHCNT"
    Private Const MCS_STATISTIC_FULLLENGTHPERCENTAGE As String = "STATISTIC_FULLLENGTHPERCENTAGE"
    Private Const MCS_STATISTIC_IRVLOWERLIMIT As String = "STATISTIC_IRVLOWERLIMIT"
    Private Const MCS_STATISTIC_IRVUPPERLIMIT As String = "STATISTIC_IRVUPPERLIMIT"
    Private Const MCS_STATISTIC_OPENCIRCUITCNT As String = "STATISTIC_OPENCIRCUITCNT"
    Private Const MCS_STATISTIC_OPENCIRCUITPERCENTAGE As String = "STATISTIC_OPENCIRCUITPERCENTAGE"
    Private Const MCS_STATISTIC_PANNELCNT As String = "STATISTIC_PANNELCNT"
    Private Const MCS_STATISTIC_PANNELUPH As String = "STATISTIC_PANNELUPH"
    Private Const MCS_STATISTIC_POSTCPK As String = "STATISTIC_POSTCPK"
    Private Const MCS_STATISTIC_POSTGOODCNT As String = "STATISTIC_POSTGOODCNT"
    Private Const MCS_STATISTIC_POSTGOODPERCENTAGE As String = "STATISTIC_POSTGOODPERCENTAGE"
    Private Const MCS_STATISTIC_PostLowerCnt As String = "STATISTIC_PostLowerCnt"
    Private Const MCS_STATISTIC_POSTLOWERLIMITPERCENTAGE As String = "STATISTIC_POSTLOWERLIMITPERCENTAGE"
    Private Const MCS_STATISTIC_POSTMEANVALUE As String = "STATISTIC_POSTMEANVALUE"
    Private Const MCS_STATISTIC_POSTMEANVALUEPERCENTAGE As String = "STATISTIC_POSTMEANVALUEPERCENTAGE"
    Private Const MCS_STATISTIC_POSTSD As String = "STATISTIC_POSTSD"
    Private Const MCS_STATISTIC_PostUpperCnt As String = "STATISTIC_PostUpperCnt"
    Private Const MCS_STATISTIC_POSTUPPERLIMITPERCENTAGE As String = "STATISTIC_POSTUPPERLIMITPERCENTAGE"
    Private Const MCS_STATISTIC_PRECPK As String = "STATISTIC_PRECPK"
    Private Const MCS_STATISTIC_PREGOODCNT As String = "STATISTIC_PREGOODCNT"
    Private Const MCS_STATISTIC_PREGOODPERCENTAGE As String = "STATISTIC_PREGOODPERCENTAGE"
    Private Const MCS_STATISTIC_PreLowerCnt As String = "STATISTIC_PreLowerCnt"
    Private Const MCS_STATISTIC_PRELOWERLIMITPERCENTAGE As String = "STATISTIC_PRELOWERLIMITPERCENTAGE"
    Private Const MCS_STATISTIC_PREMEANVALUE As String = "STATISTIC_PREMEANVALUE"
    Private Const MCS_STATISTIC_PREMEANVALUEPERCENTAGE As String = "STATISTIC_PREMEANVALUEPERCENTAGE"
    Private Const MCS_STATISTIC_PRESD As String = "STATISTIC_PRESD"
    Private Const MCS_STATISTIC_PreUpperCnt As String = "STATISTIC_PreUpperCnt"
    Private Const MCS_STATISTIC_PREUPPERLIMITPERCENTAGE As String = "STATISTIC_PREUPPERLIMITPERCENTAGE"
    Private Const MCS_STATISTIC_TARGETRESISTOR As String = "STATISTIC_TARGETRESISTOR"
    Private Const MCS_STATISTIC_TARGETRESISTOROFFESTPERCENTAGE As String = "STATISTIC_TARGETRESISTOROFFESTPERCENTAGE"
    Private Const MCS_STATISTIC_TARGETRESISTORPERCENTAGE As String = "STATISTIC_TARGETRESISTORPERCENTAGE"
    Private Const MCS_STATISTIC_TARGETRESISTORPERCENTAGELOWERLIMIT As String = "STATISTIC_TARGETRESISTORPERCENTAGELOWERLIMIT"
    Private Const MCS_STATISTIC_TARGETRESISTORPERCENTAGEUPPERLIMIT As String = "STATISTIC_TARGETRESISTORPERCENTAGEUPPERLIMIT"
    Private Const MCS_STATISTIC_TIMEREMAINING As String = "STATISTIC_TIMEREMAINING"
    Private Const MCS_STATISTIC_TIMESPENDING As String = "STATISTIC_TIMESPENDING"
    Private Const MCS_STATISTIC_TIMESTART As String = "STATISTIC_TIMESTART"
    Private Const MCS_STATISTIC_YIELD As String = "STATISTIC_YIELD"
    Private Const MCS_TIME_TRY_SubstrateInBlowDELAYMINISECOND As String = "TIME_TRY_SubstrateInBlowDELAYMINISECOND"
    Private Const MCS_TIME_TRY_TRAYINDOWNDELAYMINISECOND As String = "TIME_TRY_TRAYINDOWNDELAYMINISECOND"
    Private Const MCS_TIME_TRY_TIMEOUT As String = "TIME_TRY_TIMEOUT"
    Private Const MCS_TIME_WORKHOLDER_MOVESTABLE As String = "TIME_WORKHOLDER_MOVESTABLE"
    Private Const MCS_TIME_WORKHOLDER_FIRSTCLIPINTIME As String = "TIME_WORKHOLDER_FIRSTCLIPINTIME"
    Private Const MCS_TIME_WORKHOLDER_FIRSTCLIPOUTTIME As String = "TIME_WORKHOLDER_FIRSTCLIPOUTTIME"
    Private Const MCS_TIME_WORKHOLDER_FIRSTWORKHOLDERVACCUMTIME As String = "TIME_WORKHOLDER_FIRSTWORKHOLDERVACCUMTIME"
    Private Const MCS_TIME_WORKHOLDER_FIRSTWORKHOLDERVACCUMOFFTIME As String = "TIME_WORKHOLDER_FIRSTWORKHOLDERVACCUMOFFTIME"
    Private Const MCS_TIME_WORKHOLDER_LASTCLIPINTIME As String = "TIME_WORKHOLDER_LASTCLIPINTIME"
    Private Const MCS_TIME_WORKHOLDER_CLIPYTIME As String = "TIME_WORKHOLDER_CLIPYTIME"
    Private Const MCS_VARIABLE_LASER_GALVORATIO As String = "VARIABLE_LASER_GALVORATIO"
    Private Const MCS_VARIABLE_LASER_GALVOSCALEBITPERMICROMETER As String = "VARIABLE_LASER_GALVOSCALEBITPERMICROMETER"
    Private Const MCS_VARIABLE_LASER_RESISTORINDEX As String = "VARIABLE_LASER_RESISTORINDEX"
    Private Const MCS_VARIABLE_LASER_RESISTORMIDDLEINDEX As String = "VARIABLE_LASER_RESISTORMIDDLEINDEX"
    Private Const MCS_VARIABLE_SYSTEM_LASERSPOTIMAGEX As String = "VARIABLE_SYSTEM_LASERSPOTIMAGEX"
    Private Const MCS_VARIABLE_SYSTEM_LASERSPOTIMAGEY As String = "VARIABLE_SYSTEM_LASERSPOTIMAGEY"
    Private Const MCS_VARIABLE_SYSTEM_PRODUCTNAME As String = "VARIABLE_SYSTEM_PRODUCTNAME"
    Private Const MCS_VARIABLE_SYSTEM_LOTNAME As String = "VARIABLE_SYSTEM_LOTNAME"
    Private Const MCS_VARIABLE_SYSTEM_PRODUCTTIME As String = "VARIABLE_SYSTEM_PRODUCTTIME"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORIMAGEXLEFT As String = "VARIABLE_SYSTEM_RESISTORIMAGEXLEFT"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORIMAGEXRIGHT As String = "VARIABLE_SYSTEM_RESISTORIMAGEXRIGHT"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORIMAGEYLEFT As String = "VARIABLE_SYSTEM_RESISTORIMAGEYLEFT"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORIMAGEYRIGHT As String = "VARIABLE_SYSTEM_RESISTORIMAGEYRIGHT"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORCOLNUMBER As String = "VARIABLE_SYSTEM_RESISTORCOLNUMBER"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORROWNUMBER As String = "VARIABLE_SYSTEM_RESISTORROWNUMBER"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORCOLPITCH As String = "VARIABLE_SYSTEM_RESISTORCOLPITCH"
    Private Const MCS_VARIABLE_SYSTEM_RESISTORROWPITCH As String = "VARIABLE_SYSTEM_RESISTORROWPITCH"
    Private Const MCS_VARIABLE_SYSTEM_PROBEROWNUMBER As String = "VARIABLE_SYSTEM_PROBEROWNUMBER"
    Private Const MCS_VARIABLE_SYSTEM_PROBEJUMPTRIMRS As String = "VARIABLE_SYSTEM_PROBEJUMPTRIMRS"
    Private Const MCS_VARIABLE_TRY_BALLSCREWPITCH As String = "VARIABLE_TRY_BALLSCREWPITCH"
    Private Const MCS_VARIABLE_TRY_CCDRATIOX As String = "VARIABLE_TRY_CCDRATIOX"
    Private Const MCS_VARIABLE_TRY_CCDRATIOY As String = "VARIABLE_TRY_CCDRATIOY"
    Private Const MCS_VARIABLE_TRY_IMAGEERROR As String = "VARIABLE_TRY_IMAGEERROR"
    Private Const MCS_VARIABLE_TRY_LASERORGCCDOFFSETXEDGE As String = "VARIABLE_TRY_LASERORGCCDOFFSETXEDGE"
    Private Const MCS_VARIABLE_TRY_LASERORGCCDOFFSETYEDGE As String = "VARIABLE_TRY_LASERORGCCDOFFSETYEDGE"
    Private Const MCS_VARIABLE_TRY_PULSEPERCOUNT As String = "VARIABLE_TRY_PULSEPERCOUNT"
    Private Const MCS_VARIABLE_TRY_RADIUS As String = "VARIABLE_TRY_RADIUS"
    Private Const MCS_VARIABLE_WORKHOLDER_THETARADCCW As String = "VARIABLE_WORKHOLDER_THETARADCCW"
    Private Const MCS_VARIABLE_WORKHOLDER_TRIMALIGNOFFSETXLEFT As String = "VARIABLE_WORKHOLDER_TRIMALIGNOFFSETXLEFT"
    Private Const MCS_VARIABLE_WORKHOLDER_TRIMALIGNOFFSETXRIGHT As String = "VARIABLE_WORKHOLDER_TRIMALIGNOFFSETXRIGHT"
    Private Const MCS_VARIABLE_WORKHOLDER_TRIMALIGNOFFSETYLEFT As String = "VARIABLE_WORKHOLDER_TRIMALIGNOFFSETYLEFT"
    Private Const MCS_VARIABLE_WORKHOLDER_TRIMALIGNOFFSETYRIGHT As String = "VARIABLE_WORKHOLDER_TRIMALIGNOFFSETYRIGHT"

    Private MCS_POS_WORKHOLDER_SubstrateInX1 As String = "POS_WORKHOLDER_SubstrateInX1"
    Private MCS_POS_WORKHOLDER_SubstrateOutX1 As String = "POS_WORKHOLDER_SubstrateOutX1"
    Private MCS_POS_WORKHOLDER_WorkHolderCutX1 As String = "POS_WORKHOLDER_WorkHolderCutX1"
    Private MCS_POS_WORKHOLDER_WorkHolderCutX2 As String = "POS_WORKHOLDER_WorkHolderCutX2"
    Private MCS_POS_WORKHOLDER_SubstratePunchX As String = "POS_WORKHOLDER_SubstratePunchX"
    Private MCS_POS_WORKHOLDER_SubstrateBlowX As String = "POS_WORKHOLDER_SubstrateBlowX"

    Private Const MCS_PRODUCT_DIRECTORY As String = "D:\DataSettings\LaserTrimming1610\MachineData\Products"
#End Region

    Private m_flags As CFlags
    Private m_Pos As CPosition
    Private m_Idx As CIdx
    Private m_Count As CCount
    Private m_Time As CTime
    Private m_Variable As CVariable
    Private m_Speed As CSpeed
    Private m_HwCriticalError As Boolean

#Region "Constructors && Destructors"
    Public Sub New(ByVal FilePath As String)

        If m_flags Is Nothing Then m_flags = New CFlags
        If m_Pos Is Nothing Then m_Pos = New CPosition
        If m_Idx Is Nothing Then m_Idx = New CIdx
        If m_Count Is Nothing Then m_Count = New CCount
        If m_Time Is Nothing Then m_Time = New CTime
        If m_Variable Is Nothing Then m_Variable = New CVariable
        If m_Speed Is Nothing Then m_Speed = New CSpeed
        If ReadDataFromFile(FilePath) Then
        Else
            m_HwCriticalError = True
        End If

        m_flags.System.FirstInitialized = True


    End Sub
    Protected Overrides Sub Finalize()

        m_flags = Nothing
        m_Pos = Nothing
        m_Idx = Nothing
        m_Count = Nothing
        m_Time = Nothing
        m_Variable = Nothing
        m_Speed = Nothing

        MyBase.Finalize()

    End Sub
#End Region

#Region "Property"
    Public Property Flags() As CFlags
        Get
            Return m_flags
        End Get
        Set(ByVal value As CFlags)

            m_flags = value

        End Set
    End Property

    Public Property Pos() As CPosition
        Get
            Return m_Pos
        End Get
        Set(ByVal value As CPosition)

            m_Pos = value

        End Set
    End Property
    Public Property Idx() As CIdx
        Get
            Return m_Idx
        End Get
        Set(ByVal value As CIdx)
            m_Idx = value
        End Set
    End Property

    Public Property Count() As CCount
        Get
            Return m_Count
        End Get
        Set(ByVal value As CCount)
            m_Count = value
        End Set
    End Property

    Public Property Time() As CTime
        Get
            Return m_Time
        End Get
        Set(ByVal value As CTime)

            m_Time = value

        End Set
    End Property

    Public Property Variable() As CVariable
        Get
            Return m_Variable
        End Get
        Set(ByVal value As CVariable)

            m_Variable = value

        End Set
    End Property

    Public Property Speed() As CSpeed
        Get
            Return m_Speed
        End Get
        Set(ByVal value As CSpeed)

            m_Speed = value

        End Set
    End Property
#End Region

#Region "Methods"


    Public Function ReadDataFromFile(ByVal FilePath As String) As Boolean
        ReadDataFromFile = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument
            Dim rtnText As String = ""
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(FilePath) Then
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(FilePath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement

                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Parameter"), System.Xml.XmlElement)
                With m_Idx.System
                    If CXmler.GetXmlData(stemNode, "Idx_PieceOK", 0, rtnText) Then .PieceOK = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "Idx_PieceNoGood", 0, rtnText) Then .PieceNoGood = CInt(rtnText)
                End With
                With m_Pos.Workholder
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_ALIGNX", 0, rtnText) Then .AlignX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_ALIGNY", 0, rtnText) Then .AlignY = CInt(rtnText)

                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_IMAGEALIGNT", 0, rtnText) Then .ImageAlignT = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNX1", 0, rtnText) Then .PatternAlignX1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNY1", 0, rtnText) Then .PatternAlignY1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNX2", 0, rtnText) Then .PatternAlignX2 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNY2", 0, rtnText) Then .PatternAlignY2 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX1", 0, rtnText) Then .EdgeAlignX1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY1", 0, rtnText) Then .EdgeAlignY1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX2", 0, rtnText) Then .EdgeAlignX2 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY2", 0, rtnText) Then .EdgeAlignY2 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX3", 0, rtnText) Then .EdgeAlignX3 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY3", 0, rtnText) Then .EdgeAlignY3 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX4", 0, rtnText) Then .EdgeAlignX4 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY4", 0, rtnText) Then .EdgeAlignY4 = CInt(rtnText)

                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_SubstrateInX1, 0, rtnText) Then .SubstrateInX1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_SubstrateOutX1, 0, rtnText) Then .SubstrateOutX1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_WorkHolderCutX1, 0, rtnText) Then .WorkHolderCutX1 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_WorkHolderCutX2, 0, rtnText) Then .WorkHolderCutX2 = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_SubstratePunchX, 0, rtnText) Then .SubstratePunchX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_WORKHOLDER_SubstrateBlowX, 0, rtnText) Then .SubstrateBlowX = CInt(rtnText)

                End With

                With m_Time.Laser
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_LASERONDELAYMINISECOND", 0, rtnText) Then .LaserOnDelayMiniSecond = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_LASEROFFDELAYMINISECOND", 0, rtnText) Then .LaserOffDelayMiniSecond = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_JUMPDELAYMINISECOND", 0, rtnText) Then .JumpDelayMiniSecond = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_MARKDELAYMINISECOND", 0, rtnText) Then .MarkDelayMiniSecond = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_POLYGONDELAYMINISECOND", 0, rtnText) Then .PolygonDelayMiniSecond = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_LASERONDELAYMICROSECOND", 0, rtnText) Then .LaserOnDelayMicroSecond = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_LASEROFFDELAYMICROSECOND", 0, rtnText) Then .LaserOffDelayMicroSecond = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_JUMPDELAY10MICROSECOND", 0, rtnText) Then .JumpDelay10MicroSecond = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_MARKDELAY10MICROSECOND", 0, rtnText) Then .MarkDelay10MicroSecond = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_POLYGONDELAY10MICROSECOND", 0, rtnText) Then .PolygonDelay10MicroSecond = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_TIME_LASER_ON", 0, rtnText) Then .LaserON = CDbl(rtnText)
                End With

                With m_Time.Workholder
                    If CXmler.GetXmlData(stemNode, MCS_TIME_WORKHOLDER_MOVESTABLE, 0, rtnText) Then .MoveStable = CInt(rtnText)
                End With

                With m_Variable.Laser
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFLEFTX", 0, rtnText) Then .PinHoleDefLeftX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFLEFTY", 0, rtnText) Then .PinHoleDefLeftY = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFRIGHTX", 0, rtnText) Then .PinHoleDefRightX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFRIGHTY", 0, rtnText) Then .PinHoleDefRightY = CInt(rtnText)

                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_OffsetX", 0, rtnText) Then .OffsetX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_OffsetY", 0, rtnText) Then .OffsetY = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_LASER_Angle", 0, rtnText) Then .Angle = CInt(rtnText)
                End With

                With m_Variable.Workholder
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_CCDRATIOX", 0, rtnText) Then .CCDRatioX = CDbl((rtnText))
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_CCDRATIOY", 0, rtnText) Then .CCDRatioY = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetXMatch", 0, rtnText) Then .LaserOrgCCDOffsetXMatch = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetYMatch", 0, rtnText) Then .LaserOrgCCDOffsetYMatch = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETXEDGE", 0, rtnText) Then .LaserOrgCCDOffsetXEdge = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETYEDGE", 0, rtnText) Then .LaserOrgCCDOffsetYEdge = CDbl(rtnText)



                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_BALLSCREWPITCH", 0, rtnText) Then .BallScrewPitch = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_RADIUS", 0, rtnText) Then .Radius = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_PULSEPERCOUNT", 0, rtnText) Then .PulsePerCount = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_WORKHOLDER_IMAGEERROR", 0, rtnText) Then .ImageError = CInt(rtnText)
                End With

                With m_Variable.System
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_SYSTEM_PRODUCTNAME", 0, rtnText) Then .ProductName = CStr(rtnText)

                End With
                With m_Variable.Graphic
                    .PX2MM = 1
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_GRAPHIC_PX2MM", 0, rtnText) Then .PX2MM = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_GRAPHIC_OFFSETX", 0, rtnText) Then .OffsetX = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_GRAPHIC_OFFSETY", 0, rtnText) Then .OffsetY = CDbl(rtnText)
                End With

                With m_Variable.IO
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_IO_DIDelay", 0, rtnText) Then .DIDelay = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_IO_DODelay", 0, rtnText) Then .DODelay = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_IO_Blow1Delay", 0, rtnText) Then .Blow1Delay = CDbl(rtnText)
                    If CXmler.GetXmlData(stemNode, "MCS_VARIABLE_IO_UseBlow2", 0, rtnText) Then .UseBlow2 = CBool(rtnText)

                End With
                If (m_Variable.IO.DIDelay <= 0) Then
                    m_Variable.IO.DIDelay = 700
                End If
                If (m_Variable.IO.DODelay <= 0) Then
                    m_Variable.IO.DODelay = 500
                End If
                If (m_Variable.IO.Blow1Delay <= 100) Then
                    m_Variable.IO.Blow1Delay = 2000
                End If
            End If
            ReadDataFromFile = True
        Catch ex As Exception

        End Try

    End Function

    Public Function WriteDataToFile(ByVal FilePath As String) As Boolean
        WriteDataToFile = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim nodeAttributes As New Dictionary(Of String, String)
            Call nodeAttributes.Add("Attributes", "")
            Dim stemNode As System.Xml.XmlElement

            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Parameter", 0, nodeAttributes), System.Xml.XmlElement)

            With m_Idx.System
                Call CXmler.NewXmlValue(stemNode, "Idx_PieceOK", 0, .PieceOK)
                Call CXmler.NewXmlValue(stemNode, "Idx_PieceNoGood", 0, .PieceNoGood)
            End With


            With m_Pos.Workholder
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_ALIGNX", 0, .AlignX)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_ALIGNY", 0, .AlignY)



                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_IMAGEALIGNT", 0, .ImageAlignT)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNX1", 0, .PatternAlignX1)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNY1", 0, .PatternAlignY1)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNX2", 0, .PatternAlignX2)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_PATTERNALIGNY2", 0, .PatternAlignY2)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX1", 0, .EdgeAlignX1)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY1", 0, .EdgeAlignY1)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX2", 0, .EdgeAlignX2)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY2", 0, .EdgeAlignY2)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX3", 0, .EdgeAlignX3)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY3", 0, .EdgeAlignY3)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNX4", 0, .EdgeAlignX4)
                Call CXmler.NewXmlValue(stemNode, "MCS_POS_WORKHOLDER_EDGEALIGNY4", 0, .EdgeAlignY4)

                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateInX1, 0, .SubstrateInX1)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateOutX1, 0, .SubstrateOutX1)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_WorkHolderCutX1, 0, .WorkHolderCutX1)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_WorkHolderCutX2, 0, .WorkHolderCutX2)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstratePunchX, 0, .SubstratePunchX)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateBlowX, 0, .SubstrateBlowX)

            End With

            With m_Time.Laser
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_LASERONDELAYMINISECOND", 0, .LaserOnDelayMiniSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_LASEROFFDELAYMINISECOND", 0, .LaserOffDelayMiniSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_JUMPDELAYMINISECOND", 0, .JumpDelayMiniSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_MARKDELAYMINISECOND", 0, .MarkDelayMiniSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_POLYGONDELAYMINISECOND", 0, .PolygonDelayMiniSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_LASERONDELAYMICROSECOND", 0, .LaserOnDelayMicroSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_LASEROFFDELAYMICROSECOND", 0, .LaserOffDelayMicroSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_JUMPDELAY10MICROSECOND", 0, .JumpDelay10MicroSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_MARKDELAY10MICROSECOND", 0, .MarkDelay10MicroSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_POLYGONDELAY10MICROSECOND", 0, .PolygonDelay10MicroSecond)
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_LASER_ON", 0, .LaserON)
            End With

            With m_Time.Workholder
                Call CXmler.NewXmlValue(stemNode, "MCS_TIME_WORKHOLDER_MOVESTABLE", 0, .MoveStable)
            End With

            With m_Variable.Laser
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFLEFTX", 0, .PinHoleDefLeftX)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFLEFTY", 0, .PinHoleDefLeftY)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFRIGHTX", 0, .PinHoleDefRightX)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_PINHOLEDEFRIGHTY", 0, .PinHoleDefRightY)

                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_OffsetX", 0, .OffsetX)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_OffsetY", 0, .OffsetY)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_LASER_Angle", 0, .Angle)
            End With

            With m_Count.Tray
                Call CXmler.NewXmlValue(stemNode, "MCS_COUNT_TRAY_PIECETOSTOP", 0, .PieceToStop)
            End With
            With m_Count.Workholder
                Call CXmler.NewXmlValue(stemNode, "MCS_COUNT_WORKHOLDER_IMAGEALIGNRETRYMAX", 0, .ImageAlignmentRetryMax)
            End With

            With m_Variable.Workholder
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_CCDRATIOX", 0, .CCDRatioX)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_CCDRATIOY", 0, .CCDRatioY)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetXMatch", 0, .LaserOrgCCDOffsetXMatch)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetYMatch", 0, .LaserOrgCCDOffsetYMatch)

                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETXEDGE", 0, .LaserOrgCCDOffsetXEdge)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETYEDGE", 0, .LaserOrgCCDOffsetYEdge)


                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_BALLSCREWPITCH", 0, .BallScrewPitch)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_RADIUS", 0, .Radius)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_PULSEPERCOUNT", 0, .PulsePerCount)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_WORKHOLDER_IMAGEERROR", 0, .ImageError)

            End With


            With m_flags.System

                Call CXmler.NewXmlValue(stemNode, "MCS_FLAG_SYSTEm_MatchingToolED", 0, .PatternMatched)

            End With

            With m_Speed.Laser
                Call CXmler.NewXmlValue(stemNode, "MCS_SPEED_LASER_TABLEJUMPSPEED", 0, .TableJumpSpeed)
                Call CXmler.NewXmlValue(stemNode, "MCS_SPEED_LASER_TABLELINESPEED", 0, .TableLineSpeed)
                Call CXmler.NewXmlValue(stemNode, "MCS_SPEED_LASER_TABLEACCERATION", 0, .TableAcceration)
                Call CXmler.NewXmlValue(stemNode, "MCS_SPEED_LASER_TABLEDECERATION", 0, .TableDeceration)

            End With

            With m_Variable.System
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_SYSTEM_PRODUCTNAME", 0, .ProductName)

            End With
            With m_Variable.Graphic
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_GRAPHIC_PX2MM", 0, .PX2MM)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_GRAPHIC_OFFSETX", 0, .OffsetX)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_GRAPHIC_OFFSETY", 0, .OffsetY)
            End With
            With m_Variable.IO
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_IO_DIDelay", 0, .DIDelay)
                Call CXmler.NewXmlValue(stemNode, "MCS_VARIABLE_IO_DODelay", 0, .DODelay)
            End With
            Call xmlDoc.Save(FilePath)
            WriteDataToFile = True

        Catch ex As Exception

        End Try

    End Function
#End Region
End Class
