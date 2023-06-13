Imports System.Collections.Generic
Imports Timer
Imports Xmler

Friend Interface IPseudoMotion
#Region "System & Initialization"

#End Region
#Region "Pulse Input/Output Configuration"

#End Region
#Region "Velocity mode motion"

#End Region
#Region "Single Axis Position Mode"

#End Region
#Region "Linear Interpolated Motion"

#End Region
#Region "Circular Interpolation Motion"

#End Region
#Region "Helical Interpolation Motion"

#End Region
#Region "Home Return Mode"

#End Region
#Region "Manual Pulser Motion"

#End Region
#Region "Motion Status"

#End Region
#Region "Motion Interface I/O"

#End Region
#Region "Interrupt Control"

#End Region
#Region "Position Control and Counters"

#End Region
#Region "Position Compare and Latch"

#End Region
#Region "Continuous motion"

#End Region
#Region "Multiple Axes Simultaneous Operation"

#End Region
#Region "Soft Limit"

#End Region
    Function Init() As Boolean
    Sub Close()
    Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double)
    Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double)
    Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double)
    Sub SetHomeOffset(ByVal AxisID As Integer)
    Sub EmgStop(ByVal AxisID As Integer)
    Sub ChkStatus(ByVal AxisID As Integer)
    Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer)
    Sub SetMode(ByVal AxisID As Integer)
    Sub ServoOn(ByVal AxisID As Integer)
    Sub ServoOff(ByVal AxisID As Integer)
    Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0)
    Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pStatus As enumMotionFlag)
    Sub MoveArc(ByVal StateInfo As Object)
    Sub MoveHome(ByVal StateInfo As Object)
    Sub ChkSwLimit(ByVal AxisID As Integer, ByVal Target As Double, ByRef pStatus As enumMotionFlag)
    Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag
    Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag
    Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag
    Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short)
    Sub SlowStop(ByVal AxisID As Integer)
End Interface


Friend Enum enumMotionCard
    DMC2610 = 1
    Adlink8154 = 2
    Yaskawa = 3
    Advantech1240U = 4
    DMC5480A = 5
    AdlinkAMP204C = 6
End Enum

Public Enum enumMotionFlag
    eLow = 0
    eHigh = 1
    eReady = 1
    eNotReady = 0
    eNotSent = 0
    eSent = 1
    eLimitP = 3
    eLimitN = 4
End Enum

Friend Enum CurveType
    S_Curve_Non_Symmetrical_ = 0
    S_Curve_Symmetrical_ = 1
    T_Curve_Non_Symmetrical_ = 2
    T_Curve_Symmetrical_ = 3
End Enum

Public Class CMotion
#Region "CONSTANT"
    Private MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\"
#End Region
#Region "Constructors && Destructors"
    Public Sub New(ByVal AxisNum As Integer, ByVal SrcDirectory As String)
        MCS_SRC_DIRECTORY = SrcDirectory
        m_axisNum = AxisNum
        ReDim m_Axis(0 To m_axisNum - 1)
        m_Advantech1240U = New CAdvantech1240U(m_Axis)
        m_DMC2610 = New CDMC2610(m_Axis)
        m_DMC5480 = New CDMC5480(m_Axis)
        m_Adlink8154 = New CAdlink8154(m_Axis)

        m_AdlinkAMP204 = New CAdlinkAMP204(m_Axis)
        m_Yaskawa = New CYaskawa(m_Axis)
        For i As Integer = 0 To m_axisNum - 1
            m_Axis(i) = New CAxisBased
        Next
        Dim pAdlinkAMP204CardInit As Boolean = False
        Call ReadDataFromFile()
        For i As Integer = 0 To m_axisNum - 1
            Select Case m_Axis(i).CardType
                Case enumMotionCard.AdlinkAMP204C
                    If pAdlinkAMP204CardInit = False Then

                        pAdlinkAMP204CardInit = m_AdlinkAMP204.CardInit()
                    End If
            End Select
        Next
        ' Call WriteDataToFile()
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
#End Region
#Region "Delegate"

#End Region
#Region "Member"
    Private m_axisNum As Integer
    Private m_Advantech1240U As CAdvantech1240U
    Private m_DMC2610 As CDMC2610
    Private m_DMC5480 As CDMC5480
    Private m_Adlink8154 As CAdlink8154
    Private m_AdlinkAMP204 As CAdlinkAMP204
    Private m_Yaskawa As CYaskawa
    Private m_Axis() As CAxisBased
#End Region
#Region "Property"
    Friend ReadOnly Property AxisName(ByVal AxisID As Integer) As String
        Get
            Return m_Axis(AxisID).AxisName
        End Get
    End Property
    Public Property IO(ByVal AxisID As Integer) As CIO
        Get
            Return m_Axis(AxisID).IO
        End Get
        Set(ByVal value As CIO)
            m_Axis(AxisID).IO = value
        End Set
    End Property
    Friend Property Status(ByVal AxisID As Integer) As CMotionStatus
        Get
            Return m_Axis(AxisID).Status
        End Get
        Set(ByVal value As CMotionStatus)
            m_Axis(AxisID).Status = value
        End Set
    End Property
    Public Property AccExt(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Speed.AccExt
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).Speed.AccExt = value
        End Set
    End Property
    Public Property CenterX(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).CenterX
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).CenterX = value
        End Set
    End Property
    Public Property CenterY(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).CenterY
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).CenterY = value
        End Set
    End Property
    Public Property DecExt(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Speed.DecExt
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).Speed.DecExt = value
        End Set
    End Property
    Public Property Direction(ByVal AxisID As Integer) As Integer
        Get
            Return m_Axis(AxisID).Direction
        End Get
        Set(ByVal value As Integer)
            m_Axis(AxisID).Direction = value
        End Set
    End Property
    Public Property EndX(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).EndX
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).EndX = value
        End Set
    End Property
    Public Property EndY(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).EndY
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).EndY = value
        End Set
    End Property
    Public Property ErrMessage(ByVal AxisID As Integer) As String
        Get
            Return m_Axis(AxisID).ErrMessage
        End Get
        Set(ByVal value As String)
            m_Axis(AxisID).ErrMessage = value
        End Set
    End Property
    Public Property HomeCancel(ByVal AxisID As Integer) As Boolean
        Get
            Return m_Axis(AxisID).Home.Cancel
        End Get
        Set(ByVal value As Boolean)
            m_Axis(AxisID).Home.Cancel = value
        End Set
    End Property
    Public Property HomeRdy(ByVal AxisID As Integer) As enumMotionFlag
        Get
            Return m_Axis(AxisID).Status.HomeRdy
        End Get
        Set(ByVal value As enumMotionFlag)
            m_Axis(AxisID).Status.HomeRdy = value
        End Set
    End Property
    Public Property IsExternalParameters(ByVal AxisID As Integer) As Boolean
        Get
            Return m_Axis(AxisID).IsExternalParameters
        End Get
        Set(ByVal value As Boolean)
            m_Axis(AxisID).IsExternalParameters = value
        End Set
    End Property
    Public Property MaxVelExt(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Speed.MaxVelExt
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).Speed.MaxVelExt = value
        End Set
    End Property
    Public Property Scale(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Param.SwScale
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).Param.SwScale = value
        End Set
    End Property
    Public ReadOnly Property SWMax(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Param.SwMax
        End Get
    End Property
    Public ReadOnly Property SWMin(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).Param.SwMin
        End Get
    End Property
    Public Property TargetPosition(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).TargetPosition
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).TargetPosition = value
        End Set
    End Property
    Public Property TurnCount(ByVal AxisID As Integer) As Double
        Get
            Return m_Axis(AxisID).TurnCount
        End Get
        Set(ByVal value As Double)
            m_Axis(AxisID).TurnCount = value
        End Set
    End Property
#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Function ChkFeederStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.ChkFeederStop(AxisID1, AxisID2)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
                Return m_Advantech1240U.ChkMultiStop(AxisID1, AxisID2)
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.ChkMultiStop(AxisID1, AxisID2)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer)

    End Sub
    Public Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag

    End Function

    
    Public Sub MoveFeederPoint(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef rtnData As List(Of String), ByRef pResult As enumMotionFlag)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.MoveFeederPoint(AxisID1, AxisID2, rtnData, pResult)
            Case enumMotionCard.Yaskawa
        End Select
    End Sub

    Public Sub ConfigCompare(ByVal AxisID As Integer, ByVal StartPos As Double, ByVal EndPos As Double)
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.ConfigCompare(AxisID, StartPos, EndPos)
            Case enumMotionCard.Yaskawa
        End Select
    End Sub
    Public Sub ConfigCompare(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal StartPos1 As Double, ByVal EndPos1 As Double, ByVal StartPos2 As Double, ByVal EndPos2 As Double)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.ConfigCompare(AxisID1, AxisID2, StartPos1, EndPos1, StartPos2, EndPos2)
        End Select
    End Sub
    Public Sub ConfigCompare(ByVal AxisID1 As Integer, ByVal CircleCnt As Integer)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.ConfigCompare(AxisID1, CircleCnt)
        End Select
    End Sub
    Public Sub CloseCompare(ByVal AxisID As Integer)
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.CloseCompare(AxisID)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.CloseCompare()
        End Select
    End Sub
    Public Sub ChkStatus(ByVal AxisID As Integer)
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.ChkStatus(AxisID)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.ChkStatus(AxisID)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.ChkStatus(AxisID)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.ChkStatus(AxisID)

            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.ChkStatus(AxisID)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.ChkStatus(AxisID)
        End Select
    End Sub
    Public ReadOnly Property LimtP(ByVal AxisID As Integer) As enumMotionFlag
        Get
            Return m_Axis(AxisID).IO.PositiveLimitSwitch
        End Get
    End Property
    Public Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
                Return m_Advantech1240U.ChkStop(AxisID)
            Case enumMotionCard.DMC2610
                Return m_DMC2610.ChkStop(AxisID)
            Case enumMotionCard.DMC5480A
                Return m_DMC5480.ChkStop(AxisID)
            Case enumMotionCard.Adlink8154
                Return m_Adlink8154.ChkStop(AxisID)
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.ChkStop(AxisID)
            Case enumMotionCard.Yaskawa
                Return m_Yaskawa.ChkStop(AxisID)
            Case Else
                Return enumMotionFlag.eReady
        End Select
    End Function
    Public Function ChkAdvanceTableStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef line_idx As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.ChkAdvanceStop(AxisID1, AxisID2, line_idx)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Function AdvanceEMGStop(ByVal AxisID1 As Integer, ByRef line_idx As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.AdvanceEMGStop(line_idx)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Function IOTest(ByVal AxisID1 As Integer, ByRef IO As Integer, ByRef IOOnOff As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.IOTest(IO, IOOnOff)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Function ChkAdvanceNowLine(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef line_idx As Integer) As enumMotionFlag
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.AdlinkAMP204C
                Return m_AdlinkAMP204.ChkAdvanceNowLine(AxisID1, AxisID2, line_idx)
            Case enumMotionCard.Yaskawa
        End Select
    End Function
    Public Sub Close()
        Dim pci1240U As Integer = -1
        Dim dmc2610 As Integer = -1
        Dim dmc5480 As Integer = -1
        Dim pci8154 As Integer = -1
        Dim pciAMP204 As Integer = -1
        Dim yaskawa As Integer = -1
        Dim sts As Boolean = False
        For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
            Select Case m_Axis(axisID).CardType
                Case enumMotionCard.Advantech1240U
                    Call m_Advantech1240U.ServoOff(axisID)
                Case enumMotionCard.DMC2610
                    Call m_DMC2610.ServoOff(axisID)
                Case enumMotionCard.DMC5480A
                    Call m_DMC5480.ServoOff(axisID)
                Case enumMotionCard.Adlink8154
                    Call m_Adlink8154.ServoOff(axisID)
                Case enumMotionCard.AdlinkAMP204C
                    Call m_AdlinkAMP204.ServoOff(axisID)
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.ServoOff(axisID)
            End Select
        Next
        For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
            Select Case m_Axis(axisID).CardType
                Case enumMotionCard.Advantech1240U
                    If pci1240U = -1 Then
                        pci1240U = pci1240U + 1
                        Call m_Advantech1240U.Close()
                    End If
                Case enumMotionCard.DMC2610
                    If dmc2610 = -1 Then
                        dmc2610 = dmc2610 + 1
                        Call m_DMC2610.Close()
                    End If
                Case enumMotionCard.DMC5480A
                    If dmc5480 = -1 Then
                        dmc5480 = dmc5480 + 1
                        Call m_DMC5480.Close()
                    End If
                Case enumMotionCard.Adlink8154
                    If pci8154 = -1 Then
                        pci8154 = pci8154 + 1
                        Call m_Adlink8154.Close()
                    End If
                Case enumMotionCard.AdlinkAMP204C
                    If pciAMP204 = -1 Then
                        pciAMP204 = pciAMP204 + 1
                        Call m_AdlinkAMP204.Close()
                    End If
                Case enumMotionCard.Yaskawa
                    If yaskawa = -1 Then
                        yaskawa = yaskawa + 1
                        Call m_Yaskawa.Close()
                    End If
            End Select
        Next
    End Sub
    Public Sub EmgStop()
        For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
            Select Case m_Axis(axisID).CardType
                Case enumMotionCard.Advantech1240U
                    Call m_Advantech1240U.EmgStop(axisID)
                Case enumMotionCard.DMC2610
                    Call m_DMC2610.EmgStop(axisID)
                Case enumMotionCard.DMC5480A
                    Call m_DMC5480.EmgStop(axisID)
                Case enumMotionCard.Adlink8154
                    Call m_Adlink8154.EmgStop(axisID)
                Case enumMotionCard.AdlinkAMP204C
                    Call m_AdlinkAMP204.EmgStop(axisID)
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.EmgStop(axisID)
            End Select
        Next
    End Sub
    Public Sub ServoOff(ByVal AxisId As Integer)
        Select Case m_Axis(AxisId).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.ServoOff(AxisId)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.ServoOff(AxisId)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.ServoOff(AxisId)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.ServoOff(AxisId)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.ServoOff(AxisId)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.ServoOff(AxisId)
        End Select
    End Sub
    Public Sub ServoOn(ByVal AxisID As Integer) 
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.ServoOn(AxisID)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.ServoOn(AxisID)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.ServoOn(AxisID)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.ServoOn(AxisID)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.ServoOn(AxisID)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.ServoOn(AxisID)
        End Select
    End Sub
    Public Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) 

    End Sub
    Public Sub SlowStop(ByVal AxisId As Integer)
        Select Case m_Axis(AxisId).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.EmgStop(AxisId)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.EmgStop(AxisId)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.SlowStop(AxisId)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.EmgStop(AxisId)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.SlowStop(AxisId)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.EmgStop(AxisId)
        End Select
    End Sub

    Public Sub SetPositionOffset(ByVal AxisId As Integer, ByVal OffsetValue As Double)
        Select Case m_Axis(AxisId).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.SetPositionOffset(AxisId, OffsetValue)
            Case enumMotionCard.Yaskawa
        End Select
    End Sub

    Public Sub GetCmd(ByVal AxisId As Integer, ByRef pCmd As Double)
        Select Case m_Axis(AxisId).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.GetCmd(AxisId, pCmd)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.GetCmd(AxisId, pCmd)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.GetCmd(AxisId, pCmd)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.GetCmd(AxisId, pCmd)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.GetCmd(AxisId, pCmd)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.GetCmd(AxisId, pCmd)
        End Select
    End Sub
    Public Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double)
        If m_Axis(AxisID).Mode.IsServo Then
            Select Case m_Axis(AxisID).CardType
                Case enumMotionCard.Advantech1240U
                    Call m_Advantech1240U.GetEncoder(AxisID, pEncoder)
                Case enumMotionCard.DMC2610
                    Call m_DMC2610.GetEncoder(AxisID, pEncoder)
                Case enumMotionCard.DMC5480A
                    Call m_DMC5480.GetEncoder(AxisID, pEncoder)
                Case enumMotionCard.Adlink8154
                    Call m_Adlink8154.GetEncoder(AxisID, pEncoder)
                Case enumMotionCard.AdlinkAMP204C
                    Call m_AdlinkAMP204.GetEncoder(AxisID, pEncoder)
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.GetEncoder(AxisID, pEncoder)
            End Select
        Else
            Select Case m_Axis(AxisID).CardType
                Case enumMotionCard.Advantech1240U
                    Call m_Advantech1240U.GetCmd(AxisID, pEncoder)
                Case enumMotionCard.DMC2610
                    Call m_DMC2610.GetCmd(AxisID, pEncoder)
                Case enumMotionCard.DMC5480A
                    Call m_DMC5480.GetCmd(AxisID, pEncoder)
                Case enumMotionCard.Adlink8154
                    Call m_Adlink8154.GetCmd(AxisID, pEncoder)
                Case enumMotionCard.AdlinkAMP204C
                    Call m_AdlinkAMP204.GetCmd(AxisID, pEncoder)
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.GetCmd(AxisID, pEncoder)
            End Select
        End If
    End Sub
    Public Function Init() As Boolean
        Dim pci1240U As Integer = -1
        Dim dmc2610 As Integer = -1
        Dim dmc5480 As Integer = -1
        Dim pci8154 As Integer = -1
        Dim pciAMP204 As Integer = -1
        Dim yaskawa As Integer = -1
        Dim sts As Boolean = False


        For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
            Select Case m_Axis(axisID).CardType
                Case enumMotionCard.Adlink8154
                    If pci8154 = -1 Then
                        pci8154 = pci8154 + 1
                        sts = m_Adlink8154.Init()
                        If Not sts Then Exit For
                    End If
            End Select
        Next

        For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
            Select Case m_Axis(axisID).CardType
                Case enumMotionCard.Advantech1240U
                    If pci1240U = -1 Then
                        pci1240U = pci1240U + 1
                        sts = m_Advantech1240U.Init()
                        If Not sts Then Exit For
                    End If
                Case enumMotionCard.DMC2610
                    If dmc2610 = -1 Then
                        dmc2610 = dmc2610 + 1
                        sts = m_DMC2610.Init()
                        If Not sts Then Exit For
                    End If
                Case enumMotionCard.DMC5480A
                    If dmc5480 = -1 Then
                        dmc5480 = dmc5480 + 1
                        sts = m_DMC5480.Init()
                        If Not sts Then Exit For
                    End If
                Case enumMotionCard.AdlinkAMP204C
                    If pciAMP204 = -1 Then
                        pciAMP204 = pciAMP204 + 1
                        sts = m_AdlinkAMP204.Init()
                        If Not sts Then Exit For
                    End If
                Case enumMotionCard.Yaskawa
                    If yaskawa = -1 Then
                        yaskawa = yaskawa + 1
                        sts = m_Yaskawa.Init()
                        If Not sts Then Exit For
                    End If
            End Select
        Next


        If sts Then
            For axisID As Integer = LBound(m_Axis) To UBound(m_Axis)
                Select Case m_Axis(axisID).CardType
                    Case enumMotionCard.Advantech1240U
                        Call m_Advantech1240U.SetMode(axisID)
                        If m_Axis(axisID).Mode.IsServo Then Call m_Advantech1240U.ServoOn(axisID)
                    Case enumMotionCard.DMC2610
                        Call m_DMC2610.SetMode(axisID)
                    Case enumMotionCard.DMC5480A
                        Call m_DMC5480.SetMode(axisID)
                        Call m_DMC5480.SetHomeOffset(axisID)
                        If m_Axis(axisID).Mode.IsServo Then Call m_DMC5480.ServoOn(axisID)
                    Case enumMotionCard.Adlink8154
                        Call m_Adlink8154.SetMode(axisID)
                    Case enumMotionCard.AdlinkAMP204C
                        Call m_AdlinkAMP204.SetMode(axisID)
                        Call m_AdlinkAMP204.ServoOn(axisID)
                    Case enumMotionCard.Yaskawa
                        Call m_Yaskawa.SetMode(axisID)
                End Select
            Next
        End If
        Init = sts
    End Function
    Public Function LaserSetting(ByVal AxisID1 As Integer, ByVal pMode As Integer, ByVal pParamChange As String, ByVal pfixdParam As String, ByVal pFollowVType As Integer, ByVal pMaxV As Integer, ByVal pMinV As Integer, ByVal pPoint As Integer) As Boolean
        Try
            LaserSetting = False
            Select Case m_Axis(AxisID1).CardType
                Case enumMotionCard.Advantech1240U
                Case enumMotionCard.DMC2610
                Case enumMotionCard.DMC5480A
                Case enumMotionCard.Adlink8154
                Case enumMotionCard.AdlinkAMP204C
                    'pMode ' Voltage=0 ' PWM with fixed freq=1 ' PWM with fixed width=2 ' PWM with fixed duty cycle =3 
                    'param Velocity
                    'pFollowVType 'Feedback =0 Command =1
                    LaserSetting = m_AdlinkAMP204.LaserSetting(AxisID1, pMode, pParamChange, pfixdParam, pFollowVType, pMaxV, pMinV, pPoint)
                Case enumMotionCard.Yaskawa
            End Select
        Catch ex As Exception
        Finally
        End Try
    End Function
    Public Function LaserON(ByVal AxisID As Integer, Optional ByVal Param1 As String = "", Optional ByVal Param2 As String = "") As Boolean
        Try
            LaserON = False
            Select Case m_Axis(AxisID).CardType
                Case enumMotionCard.Advantech1240U
                Case enumMotionCard.DMC2610
                Case enumMotionCard.DMC5480A
                Case enumMotionCard.Adlink8154
                Case enumMotionCard.AdlinkAMP204C
                    LaserON = m_AdlinkAMP204.LaserOn(Param1, Param2)
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.LaserON()
            End Select
        Catch ex As Exception
        Finally
        End Try
    End Function
    Public Function LaserON_BoardLink(ByVal AxisID As Integer) As Boolean
        Try
            LaserON_BoardLink = False
            Select Case m_Axis(AxisID).CardType
                Case enumMotionCard.Advantech1240U
                Case enumMotionCard.DMC2610
                Case enumMotionCard.DMC5480A
                Case enumMotionCard.Adlink8154
                Case enumMotionCard.AdlinkAMP204C
                    LaserON_BoardLink = m_AdlinkAMP204.LaserOn_BoardLink()
                Case enumMotionCard.Yaskawa
            End Select
        Catch ex As Exception
        Finally
        End Try
    End Function
    Public Function LaserOFF(ByVal AxisID As Integer) As Boolean
        Try
            LaserOFF = False
            Select Case m_Axis(AxisID).CardType
                Case enumMotionCard.Advantech1240U
                Case enumMotionCard.DMC2610
                Case enumMotionCard.DMC5480A
                Case enumMotionCard.Adlink8154
                Case enumMotionCard.AdlinkAMP204C
                    LaserOFF = m_AdlinkAMP204.LaserOff()
                Case enumMotionCard.Yaskawa
                    Call m_Yaskawa.LaserOFF()
            End Select
        Catch ex As Exception
        Finally
        End Try
    End Function
    Public Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0)
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
                'Call WriteDataToFile()
            Case enumMotionCard.DMC2610
                Call m_DMC2610.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.MoveAbs(AxisID, Target, pResult, VelocityRatio, AccRatio)
        End Select
    End Sub



    Public Sub MoveAdvTablePoint(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef rtnData As List(Of String), ByRef pResult As enumMotionFlag, Optional ByVal AxisCount As Integer = 2)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
            Case enumMotionCard.DMC2610
            Case enumMotionCard.DMC5480A
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.MoveAdvPointTable(AxisID1, AxisID2, rtnData, pResult, AxisCount)
            Case enumMotionCard.Yaskawa
        End Select
    End Sub
    Public Property MoveAdvPointTableIsThreadStarted() As Boolean
        Get
            Return m_AdlinkAMP204.MoveAdvPointTableIsThreadStarted
        End Get
        Set(ByVal value As Boolean)
            m_AdlinkAMP204.MoveAdvPointTableIsThreadStarted = value
        End Set
    End Property
    Public Property MoveAdvPointTableIsThreadFinished() As Boolean
        Get
            Return m_AdlinkAMP204.MoveAdvPointTableIsThreadFinished
        End Get
        Set(ByVal value As Boolean)
            m_AdlinkAMP204.MoveAdvPointTableIsThreadFinished = value
        End Set
    End Property
    Public Property MoveAdvTableEMGStop() As Boolean
        Get
            Return m_AdlinkAMP204.MoveAdvTableEMGStop
        End Get
        Set(ByVal value As Boolean)
            m_AdlinkAMP204.MoveAdvTableEMGStop = value
        End Set
    End Property
    Public ReadOnly Property MoveAdvPointTableErrorMesseage() As String
        Get
            Return m_AdlinkAMP204.MoveAdvTableErrMessage
        End Get
    End Property
    Public Sub MoveArc(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal CenterX As Double, ByVal CenterY As Double, ByVal EndX As Double, ByVal EndY As Double, ByVal Direction As Integer, ByVal TurnCount As Double, ByRef pStatus As enumMotionFlag)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.MoveArc(AxisID1)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.MoveArc(AxisID1)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.MoveArc(AxisID1)
            Case enumMotionCard.Adlink8154
                Call m_Adlink8154.MoveArc(AxisID1)
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.MoveArc(AxisID1)

            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.MoveArc(AxisID1, AxisID2, CenterX, CenterY, EndX, EndY, Direction, TurnCount, pStatus)
                

        End Select
    End Sub
    Public Sub MoveHome(ByVal AxisID As Integer)
        Do
        Loop Until m_Axis(AxisID).IsThreadFinished = True
        m_Axis(AxisID).IsThreadStarted = False
        m_Axis(AxisID).Status.HomeRdy = enumMotionFlag.eNotReady
        m_Axis(AxisID).Home.Cancel = False
        Select Case m_Axis(AxisID).CardType
            Case enumMotionCard.Advantech1240U
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_Advantech1240U.MoveHome), AxisID)
            Case enumMotionCard.DMC2610
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_DMC2610.MoveHome), AxisID)
            Case enumMotionCard.DMC5480A
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_DMC5480.MoveHome), AxisID)
            Case enumMotionCard.Adlink8154
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_Adlink8154.MoveHome), AxisID)
            Case enumMotionCard.AdlinkAMP204C
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_AdlinkAMP204.MoveHome), AxisID)
            Case enumMotionCard.Yaskawa
                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_Yaskawa.MoveHome), AxisID)
        End Select
        Do
        Loop Until m_Axis(AxisID).IsThreadStarted
    End Sub
    Public Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pStatus As enumMotionFlag)
        Select Case m_Axis(AxisID1).CardType
            Case enumMotionCard.Advantech1240U
                Call m_Advantech1240U.MoveLinear(AxisID1, AxisID2, EndX, EndY, pStatus)
            Case enumMotionCard.DMC2610
                Call m_DMC2610.MoveLinear(AxisID1, AxisID2, EndX, EndY, pStatus)
            Case enumMotionCard.DMC5480A
                Call m_DMC5480.MoveLinear(AxisID1, AxisID2, EndX, EndY, pStatus)
            Case enumMotionCard.Adlink8154
            Case enumMotionCard.AdlinkAMP204C
                Call m_AdlinkAMP204.MoveLinear(AxisID1, AxisID2, EndX, EndY, pStatus)
            Case enumMotionCard.Yaskawa
                Call m_Yaskawa.MoveLinear(AxisID1, AxisID2, EndX, EndY, pStatus)
                'With m_Axis(AxisID1)
                '    Do
                '    Loop Until m_Axis(AxisID1).IsThreadFinished
                '    m_Axis(AxisID1).IsThreadFinished = False : m_Axis(AxisID1).Status.MoveRdy = enumMotionFlag.eNotReady
                '    .EndX = EndX : .EndY = EndY
                '    System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_Yaskawa.MoveLinea), AxisID1)
                '    Do
                '    Loop Until .IsThreadStarted
                '    pStatus = enumMotionFlag.eSent
                'End With
        End Select
    End Sub
    'Public Sub MoveArcMoveArc(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal CenterX As Double, ByVal CenterY As Double, ByVal EndX As Double, ByVal EndY As Double, ByVal Direction As Integer, ByVal TurnCount As Double, ByRef pStatus As enumMotionFlag)
    '    Select Case m_Axis(AxisID1).CardType
    '        Case enumMotionCard.Advantech1240U
    '            Call m_Advantech1240U.MoveArc(AxisID1)
    '        Case enumMotionCard.DMC2610
    '            Call m_DMC2610.MoveArc(AxisID1)
    '        Case enumMotionCard.DMC5480A
    '            Call m_DMC5480.MoveArc(AxisID1)
    '        Case enumMotionCard.Adlink8154
    '            Call m_Adlink8154.MoveArc(AxisID1)
    '        Case enumMotionCard.Yaskawa
    '            With m_Axis(AxisID1)
    '                If .Status.MoveRdy = enumMotionFlag.eReady Then
    '                    Do
    '                    Loop Until .IsThreadFinished
    '                    .IsThreadStarted = False : .Status.MoveRdy = enumMotionFlag.eNotReady
    '                    .CenterX = CenterX
    '                    .CenterY = CenterY
    '                    .EndX = EndX
    '                    .EndY = EndY
    '                    .Direction = Direction
    '                    .TurnCount = TurnCount
    '                    System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf m_Yaskawa.MoveArc), AxisID1)
    '                    Do
    '                    Loop Until .IsThreadStarted
    '                    pStatus = enumMotionFlag.eSent
    '                End If
    '            End With
    '    End Select
    'End Sub
    Public Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer
        filePath = MCS_SRC_DIRECTORY & "HardWare\Motion.xml"
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
            Dim xmlDoc As System.Xml.XmlDocument
            xmlDoc = New System.Xml.XmlDocument
            Call xmlDoc.Load(filePath)
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim stemNode As System.Xml.XmlElement
            'rootNode = CType(xmlDoc.SelectSingleNode("RootNode"), Xml.XmlElement)
            For idx = 0 To m_axisNum - 1
                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Motion_" & idx.ToString()), System.Xml.XmlElement)
                With m_Axis(idx)
                    If CXmler.GetXmlData(stemNode, "AxisID", 0, rtnText) Then .AxisID = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "AxisName", 0, rtnText) Then .AxisName = rtnText
                    If CXmler.GetXmlData(stemNode, "CardID", 0, rtnText) Then .CardID = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardName", 0, rtnText) Then .CardName = rtnText
                    If CXmler.GetXmlData(stemNode, "CardType", 0, rtnText) Then .CardType = CType(rtnText, enumMotionCard)
                    If CXmler.GetXmlData(stemNode, "ModeAlarmLogic", 0, rtnText) Then .Mode.AlarmLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeAlarmMode", 0, rtnText) Then .Mode.AlarmMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeClrMode", 0, rtnText) Then .Mode.ClrMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeCurveMode", 0, rtnText) Then .Mode.CurveMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeERCEnable", 0, rtnText) Then .Mode.ERCEnable = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeERCLogic", 0, rtnText) Then .Mode.ERCLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeEZLogic", 0, rtnText) Then .Mode.EZLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeHomeDir", 0, rtnText) Then .Mode.HomeDir = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeHomeMode", 0, rtnText) Then .Mode.HomeMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeInpEnable", 0, rtnText) Then .Mode.InpEnable = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeInpLogic", 0, rtnText) Then .Mode.InpLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeIsServo", 0, rtnText) Then .Mode.IsServo = CBool(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeOrgLatch", 0, rtnText) Then .Mode.OrgLatch = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeOrgLogic", 0, rtnText) Then .Mode.OrgLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModePCSEnable", 0, rtnText) Then .Mode.PCSEnable = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModePCSLogic", 0, rtnText) Then .Mode.PCSLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModePulseInputMode", 0, rtnText) Then .Mode.PulseInputMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModePulseLogic", 0, rtnText) Then .Mode.PulseLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModePulseOutMode", 0, rtnText) Then .Mode.PulseOutMode = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeSdEnable", 0, rtnText) Then .Mode.SdEnable = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeSdLatch", 0, rtnText) Then .Mode.SdLatch = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeSdLogic", 0, rtnText) Then .Mode.SdLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeServoONLogic", 0, rtnText) Then .Mode.ServoONLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeLimitLogic", 0, rtnText) Then .Mode.LimitLogic = CShort(rtnText)
                    If CXmler.GetXmlData(stemNode, "ModeLimitMode", 0, rtnText) Then .Mode.LimitMode = CShort(rtnText)
                End With
            Next
            filePath = MCS_SRC_DIRECTORY & "Machine\Parameter\Motion.xml"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                Dim xmlDoc1 As System.Xml.XmlDocument
                xmlDoc1 = New System.Xml.XmlDocument
                Call xmlDoc1.Load(filePath)
                Dim rootNode1 As System.Xml.XmlElement = xmlDoc1.Item("RootNode")
                Dim stemNode1 As System.Xml.XmlElement
                'rootNode = CType(xmlDoc.SelectSingleNode("RootNode"), Xml.XmlElement)
                For idx = 0 To m_axisNum - 1
                    With m_Axis(idx)
                        stemNode1 = DirectCast(CXmler.GetPreviousNode(rootNode1, "Motion_" & idx.ToString()), System.Xml.XmlElement)
                        If CXmler.GetXmlData(stemNode1, "HomeAcc", 0, rtnText) Then .Home.Acc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "HomeHighSpeed", 0, rtnText) Then .Home.HighSpeed = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "HomeLowSpeed", 0, rtnText) Then .Home.LowSpeed = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "HomeOffset", 0, rtnText) Then .Home.Offset = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "HomeEscapeDis", 0, rtnText) Then .Home.EscapeDis = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "ParamSwMax", 0, rtnText) Then .Param.SwMax = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "ParamSwMin", 0, rtnText) Then .Param.SwMin = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "ParamSwScale", 0, rtnText) Then .Param.SwScale = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "ParamEnrScale", 0, rtnText) Then .Param.EnrScale = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedIacc", 0, rtnText) Then .Speed.Iacc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedIdec", 0, rtnText) Then .Speed.Idec = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedMaxConstrainedVel", 0, rtnText) Then .Speed.MaxConstrainedVel = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedMaxVel", 0, rtnText) Then .Speed.MaxVel = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedMaxVelCircle", 0, rtnText) Then .Speed.MaxVelCircle = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedMaxVelLinear", 0, rtnText) Then .Speed.MaxVelLinear = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedRatioAcc", 0, rtnText) Then .Speed.RatioAcc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedRatioMaxVel", 0, rtnText) Then .Speed.RatioMaxVel = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedSacc", 0, rtnText) Then .Speed.Sacc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedSdec", 0, rtnText) Then .Speed.Sdec = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedStrVel", 0, rtnText) Then .Speed.StrVel = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedTacc", 0, rtnText) Then .Speed.Tacc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedAcc", 0, rtnText) Then .Speed.Acc = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedAccCircle", 0, rtnText) Then .Speed.AccCircle = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedAccLinear", 0, rtnText) Then .Speed.AccLinear = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedTdec", 0, rtnText) Then .Speed.Tdec = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedDec", 0, rtnText) Then .Speed.Dec = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedDecCircle", 0, rtnText) Then .Speed.DecCircle = CDbl(rtnText)
                        If CXmler.GetXmlData(stemNode1, "SpeedDecLinear", 0, rtnText) Then .Speed.DecLinear = CDbl(rtnText)
                    End With
                Next
            Else
                ErrMessage(0) = "馬達設定檔案損毀!!"
            End If
        Else
            ErrMessage(0) = "馬達設定檔案損毀!!"
        End If
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer
        Dim filePath As String = ""
        filePath = MCS_SRC_DIRECTORY & "HardWare\Motion.xml"
        For idx = 0 To m_axisNum - 1
            With m_Axis(idx)
                stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Motion_" & idx.ToString(), 0, nodeAttributes), System.Xml.XmlElement) ' 建立空節點
                Call CXmler.NewXmlValue(stemNode, "AxisID", 0, .AxisID)
                Call CXmler.NewXmlValue(stemNode, "AxisName", 0, .AxisName)
                Call CXmler.NewXmlValue(stemNode, "CardID", 0, .CardID)
                Call CXmler.NewXmlValue(stemNode, "CardName", 0, .CardName)
                Call CXmler.NewXmlValue(stemNode, "CardType", 0, .CardType)
                Call CXmler.NewXmlValue(stemNode, "ModeAlarmLogic", 0, .Mode.AlarmLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeAlarmMode", 0, .Mode.AlarmMode)
                Call CXmler.NewXmlValue(stemNode, "ModeClrMode", 0, .Mode.ClrMode)
                Call CXmler.NewXmlValue(stemNode, "ModeCurveMode", 0, .Mode.CurveMode)
                Call CXmler.NewXmlValue(stemNode, "ModeERCEnable", 0, .Mode.ERCEnable)
                Call CXmler.NewXmlValue(stemNode, "ModeERCLogic", 0, .Mode.ERCLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeEZLogic", 0, .Mode.EZLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeHomeDir", 0, .Mode.HomeDir)
                Call CXmler.NewXmlValue(stemNode, "ModeHomeMode", 0, .Mode.HomeMode)
                Call CXmler.NewXmlValue(stemNode, "ModeInpEnable", 0, .Mode.InpEnable)
                Call CXmler.NewXmlValue(stemNode, "ModeInpLogic", 0, .Mode.InpLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeIsServo", 0, .Mode.IsServo)
                Call CXmler.NewXmlValue(stemNode, "ModeOrgLatch", 0, .Mode.OrgLatch)
                Call CXmler.NewXmlValue(stemNode, "ModeOrgLogic", 0, .Mode.OrgLogic)
                Call CXmler.NewXmlValue(stemNode, "ModePCSEnable", 0, .Mode.PCSEnable)
                Call CXmler.NewXmlValue(stemNode, "ModePCSLogic", 0, .Mode.PCSLogic)
                Call CXmler.NewXmlValue(stemNode, "ModePulseInputMode", 0, .Mode.PulseInputMode)
                Call CXmler.NewXmlValue(stemNode, "ModePulseLogic", 0, .Mode.PulseLogic)
                Call CXmler.NewXmlValue(stemNode, "ModePulseOutMode", 0, .Mode.PulseOutMode)
                Call CXmler.NewXmlValue(stemNode, "ModeSdEnable", 0, .Mode.SdEnable)
                Call CXmler.NewXmlValue(stemNode, "ModeSdLatch", 0, .Mode.SdLatch)
                Call CXmler.NewXmlValue(stemNode, "ModeSdLogic", 0, .Mode.SdLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeServoONLogic", 0, .Mode.ServoONLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeLimitLogic", 0, .Mode.LimitLogic)
                Call CXmler.NewXmlValue(stemNode, "ModeLimitMode", 0, .Mode.LimitMode)
            End With
        Next
        Call xmlDoc.Save(filePath)

        Dim xmlDoc1 As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode1 As System.Xml.XmlElement = xmlDoc1.Item("RootNode")
        Dim nodeAttributes1 As New Dictionary(Of String, String)
        Call nodeAttributes1.Add("Attributes", "")
        Dim stemNode1 As System.Xml.XmlElement
        filePath = MCS_SRC_DIRECTORY & "Machine\Parameter\Motion.xml"
        For idx = 0 To m_axisNum - 1
            stemNode1 = DirectCast(CXmler.NewXmlNode(rootNode1, "Motion_" & idx.ToString(), 0, nodeAttributes1), System.Xml.XmlElement) ' 建立空節點
            With m_Axis(idx)
                Call CXmler.NewXmlValue(stemNode1, "HomeAcc", 0, .Home.Acc)
                Call CXmler.NewXmlValue(stemNode1, "HomeHighSpeed", 0, .Home.HighSpeed)
                Call CXmler.NewXmlValue(stemNode1, "HomeLowSpeed", 0, .Home.LowSpeed)
                Call CXmler.NewXmlValue(stemNode1, "HomeOffset", 0, .Home.Offset)
                Call CXmler.NewXmlValue(stemNode1, "HomeEscapeDis", 0, .Home.EscapeDis)
                Call CXmler.NewXmlValue(stemNode1, "ParamSwMax", 0, .Param.SwMax)
                Call CXmler.NewXmlValue(stemNode1, "ParamSwMin", 0, .Param.SwMin)
                Call CXmler.NewXmlValue(stemNode1, "ParamSwScale", 0, .Param.SwScale)
                Call CXmler.NewXmlValue(stemNode1, "ParamEnrScale", 0, .Param.EnrScale)
                Call CXmler.NewXmlValue(stemNode1, "SpeedIacc", 0, .Speed.Iacc)
                Call CXmler.NewXmlValue(stemNode1, "SpeedIdec", 0, .Speed.Idec)
                Call CXmler.NewXmlValue(stemNode1, "SpeedMaxConstrainedVel", 0, .Speed.MaxConstrainedVel)
                Call CXmler.NewXmlValue(stemNode1, "SpeedMaxVel", 0, .Speed.MaxVel)
                Call CXmler.NewXmlValue(stemNode1, "SpeedMaxVelCircle", 0, .Speed.MaxVelCircle)
                Call CXmler.NewXmlValue(stemNode1, "SpeedMaxVelLinear", 0, .Speed.MaxVelLinear)
                Call CXmler.NewXmlValue(stemNode1, "SpeedRatioAcc", 0, .Speed.RatioAcc)
                Call CXmler.NewXmlValue(stemNode1, "SpeedRatioMaxVel", 0, .Speed.RatioMaxVel)
                Call CXmler.NewXmlValue(stemNode1, "SpeedSacc", 0, .Speed.Sacc)
                Call CXmler.NewXmlValue(stemNode1, "SpeedSdec", 0, .Speed.Sdec)
                Call CXmler.NewXmlValue(stemNode1, "SpeedStrVel", 0, .Speed.StrVel)
                Call CXmler.NewXmlValue(stemNode1, "SpeedTacc", 0, .Speed.Tacc)
                Call CXmler.NewXmlValue(stemNode1, "SpeedAcc", 0, .Speed.Acc)
                Call CXmler.NewXmlValue(stemNode1, "SpeedAccCircle", 0, .Speed.AccCircle)
                Call CXmler.NewXmlValue(stemNode1, "SpeedAccLinear", 0, .Speed.AccLinear)
                Call CXmler.NewXmlValue(stemNode1, "SpeedTdec", 0, .Speed.Tdec)
                Call CXmler.NewXmlValue(stemNode1, "SpeedDec", 0, .Speed.Dec)
                Call CXmler.NewXmlValue(stemNode1, "SpeedDecCircle", 0, .Speed.DecCircle)
                Call CXmler.NewXmlValue(stemNode1, "SpeedDecLinear", 0, .Speed.DecLinear)
            End With
        Next
        Call xmlDoc1.Save(filePath)
    End Sub
#End Region
    Public Sub EmgStop(ByVal AxisID As Integer)

    End Sub
End Class
