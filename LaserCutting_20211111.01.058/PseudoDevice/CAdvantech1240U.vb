Imports System.Threading
Imports Advantech.Motion
Imports System.Runtime.InteropServices

Friend Class CAdvantech1240U
    Implements IPseudoMotion
    Private m_Axis() As CAxisBased
    Private m_GpHand As IntPtr() = New IntPtr(31) {}
    Private m_DeviceHandle As IntPtr = IntPtr.Zero
    Private m_Axishand As IntPtr() = New IntPtr(31) {}
    Friend Sub New(ByRef pAxis() As CAxisBased)
        m_Axis = pAxis
    End Sub
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Init = True
        Dim count As Short = 0
        Dim cardID As Integer = -1
        Dim errCode As UInteger
        Dim i As UInteger = 0
        Dim slaveDevs As UInteger() = New UInteger(15) {}
        Dim AxesPerDev As New UInteger()
        Dim buffLen As UInteger = 0
        Dim DeviceNum As UInteger = 0

        Dim CurAvailableDevs As DEV_LIST() = New DEV_LIST(Motion.MAX_DEVICES - 1) {}
        Dim deviceCount As UInteger = 0

        For idx As Integer = LBound(m_Axis) To UBound(m_Axis)
            If m_Axis(idx).CardType = enumMotionCard.Advantech1240U Then
                If m_Axis(idx).CardID <> cardID Then
                    cardID = m_Axis(idx).CardID
                    errCode = Motion.mAcm_GetAvailableDevs(CurAvailableDevs, Motion.MAX_DEVICES, deviceCount)
                    DeviceNum = CurAvailableDevs(m_Axis(idx).CardID).DeviceNum
                    errCode = Motion.mAcm_DevOpen(DeviceNum, m_DeviceHandle)
                    If errCode = CUInt(ErrorCode.SUCCESS) Then
                        count = count + 1
                    End If
                End If
                'Open every Axis and get the each Axis Handle 
                'And Initial property for each Axis 
                'Open Axis 
                errCode = Motion.mAcm_AxOpen(m_DeviceHandle, CUShort(m_Axis(idx).AxisID), m_Axishand(m_Axis(idx).AxisID))
                If errCode <> CUInt(ErrorCode.SUCCESS) Then
                End If
                m_GpHand(m_Axis(idx).AxisID) = IntPtr.Zero
                'errCode = Motion.mAcm_AxResetError(m_Axishand(m_Axis(idx).AxisID))
                'If errCode <> CUInt(ErrorCode.SUCCESS) Then
                'End If
            End If
        Next
        If count = 0 Then
            Init = False
        End If
    End Function
    Friend Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkStop
        Call ChkStatus(AxisID)
        ChkStop = enumMotionFlag.eNotReady
        With m_Axis(AxisID)
            If .IO.AlarmSignal = enumMotionFlag.eLow Then
                If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                        If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                            ChkStop = enumMotionFlag.eReady
                        End If
                    Else
                        ChkStop = enumMotionFlag.eReady
                    End If
                End If
            Else
                ChkStop = enumMotionFlag.eReady
            End If
        End With
    End Function
    Friend Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop
        Dim result As UInteger
        Dim status1 As enumMotionFlag
        Dim status2 As enumMotionFlag
        ChkMultiStop = enumMotionFlag.eNotReady
        Try
            Call ChkMutiStatus(AxisID1, AxisID2)
            status1 = enumMotionFlag.eNotReady
            status2 = enumMotionFlag.eNotReady
            With m_Axis(AxisID1)
                If .IO.AlarmSignal = enumMotionFlag.eLow Then
                    If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                        If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                            If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                                status1 = enumMotionFlag.eReady
                            End If
                        Else
                            status1 = enumMotionFlag.eReady
                        End If
                    End If
                    With m_Axis(AxisID2)
                        If .IO.AlarmSignal = enumMotionFlag.eLow Then
                            If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                                If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                                    If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                                        status2 = enumMotionFlag.eReady
                                    End If
                                Else
                                    status2 = enumMotionFlag.eReady
                                End If
                            End If
                            If (status1 = enumMotionFlag.eReady) AndAlso (status2 = enumMotionFlag.eReady) Then ChkMultiStop = enumMotionFlag.eReady
                        Else
                            ChkMultiStop = enumMotionFlag.eReady
                        End If
                    End With
                Else
                    ChkMultiStop = enumMotionFlag.eReady
                End If
            End With
        Catch ex As Exception
        End Try
    End Function
    Friend Sub ChkSwLimit(ByVal AxisID As Integer, ByVal Target As Double, ByRef pStatus As enumMotionFlag) Implements IPseudoMotion.ChkSwLimit
        If Target >= m_Axis(AxisID).Param.SwMin Then
            If Target <= m_Axis(AxisID).Param.SwMax Then
                pStatus = enumMotionFlag.eHigh
            Else
                pStatus = enumMotionFlag.eLimitP
            End If
        Else
            pStatus = enumMotionFlag.eLimitN
        End If
    End Sub
    Friend Sub EmgStop(ByVal AxisID As Integer) Implements IPseudoMotion.EmgStop
        Dim errCode As UInteger
        With m_Axis(AxisID)
            errCode = Motion.mAcm_AxStopEmg(m_Axishand(.AxisID))
        End With
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        Dim errCode As UInteger
        Dim encoder As Double
        With m_Axis(AxisID)
            errCode = Motion.mAcm_AxGetActualPosition(m_Axishand(.AxisID), encoder)
            'errCode = Motion.mAcm_AxGetCmdPosition(m_Axishand(.AxisID), encoder)
            pEncoder = encoder / .Param.SwScale
        End With
        Call ChkStatus(AxisID)
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        Dim errCode As UInteger
        Dim cmd As Double
        With m_Axis(AxisID)
            errCode = Motion.mAcm_AxGetCmdPosition(m_Axishand(.AxisID), cmd)
            pCmd = cmd / .Param.SwScale
        End With
        Call ChkStatus(AxisID)
    End Sub
    Friend Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget
        pTarget = m_Axis(AxisID).TargetPosition
        Call ChkStatus(AxisID)
    End Sub
    Friend Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim status As enumMotionFlag
        Dim errCode As Integer
        Dim buffLen As UInteger = 0
        pResult = enumMotionFlag.eNotSent
        If ChkStop(AxisID) = enumMotionFlag.eReady Then
            Call ChkSwLimit(AxisID, Target, status)
            If status = enumMotionFlag.eHigh Then
                With m_Axis(AxisID)
                    If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    Else
                        .Speed.RatioMaxVel = VelocityRatio
                        .Speed.RatioAcc = AccRatio
                        If .Speed.MaxVel * .Param.SwScale > 8000 Then
                            'Configure the max velocity for the motion axis(Unit:PPU/s).
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(500000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                        Else
                            'Configure the max velocity for the motion axis(Unit:PPU/s).
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(8000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(1000000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(1000000), CUInt(Marshal.SizeOf(GetType(Double))))
                        End If
                        'Set low velocity (start velocity) of this axis (Unit: PPU/S). 
                        errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelLow), Double.Parse(.Speed.StrVel * .Param.SwScale), CUInt(Marshal.SizeOf(GetType(Double))))
                        'Set high velocity (driving velocity) of this axis (Unit:PPU/S). 
                        errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelHigh), Double.Parse(.Speed.MaxVel * .Param.SwScale * .Speed.RatioMaxVel), CUInt(Marshal.SizeOf(GetType(Double))))
                        'Set acceleration of this axis (Unit: PPU/S2). 
                        errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxAcc), Double.Parse(.Speed.Acc * .Param.SwScale * .Speed.RatioAcc), CUInt(Marshal.SizeOf(GetType(Double))))
                        'Set deceleration of this axis (Unit: PPU/S2). 
                        errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxDec), Double.Parse(.Speed.Dec * .Param.SwScale * .Speed.RatioAcc), CUInt(Marshal.SizeOf(GetType(Double))))
                        'Set the type of velocity profile: t-curve or s-curve.
                        '0 T-curve(Default) 
                        '1(!=0) S-curve 
                        errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxJerk), Double.Parse(1), CUInt(Marshal.SizeOf(GetType(Double))))
                        'Start single axis' absolute motion. 
                        Try
                            errCode = Motion.mAcm_AxMoveAbs(m_Axishand(.AxisID), Double.Parse(Target * .Param.SwScale))
                        Catch ex As Exception
                            ex = ex
                        End Try
                    End If
                End With
                If errCode = 0 Then
                    m_Axis(AxisID).TargetPosition = Target
                    pResult = enumMotionFlag.eSent
                End If
            Else
                If status = enumMotionFlag.eLimitP Then
                    pResult = enumMotionFlag.eLimitP
                ElseIf status = enumMotionFlag.eLimitN Then
                    pResult = enumMotionFlag.eLimitN
                End If
            End If
        End If
    End Sub
    Friend Sub MoveHome(ByVal StateInfo As Object) Implements IPseudoMotion.MoveHome
        'Step1 檢查是否在感應器上
        'Step2 快速往感應器復歸
        'Step3 等待復歸完畢
        'Step4 移出感應器
        'Step5 等待移動完畢
        'Step6 慢速往感應器復歸
        'Step7 等待復歸完畢
        'Step8 參考值歸零

        Const PositiveDIR As Short = 0
        Const NegativeDIR As Short = 1
        Dim axisID As Integer = CInt(StateInfo)
        Dim home_Dir As Short
        Dim status As enumMotionFlag
        Dim errCode As Integer
        m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eNotReady
        m_Axis(axisID).IsThreadFinished = False
        m_Axis(axisID).IsThreadStarted = True
        m_Axis(axisID).ErrMessage = ""

        SetHomeOffset(axisID)
        With m_Axis(axisID)
            Try
                errCode = Motion.mAcm_AxResetError(m_Axishand(.AxisID))
            Catch ex As Exception
            End Try
            'If .Mode.IsServo Then Call ServoOn(axisID)
            Call ChkStatus(axisID)
            home_Dir = CShort(.Mode.HomeDir) '回原点方式。0：正方向回原点，1：负方向回原点
            If home_Dir = PositiveDIR Then
                Do
                    Call ChkStatus(axisID)
                    If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Do
                            Call MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status, 0.25, 0.25)
                            If status = enumMotionFlag.eSent Then Exit Do
                        Loop

                        Do
                            If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                            If .Home.Cancel Then
                                Call EmgStop(axisID)
                                .Home.Cancel = False
                                m_Axis(axisID).IsThreadFinished = True : Exit Sub
                            End If
                        Loop
                    Else
                        Call EmgStop(axisID)
                        Exit Do
                    End If
                Loop

            Else
                Do
                    If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Do
                            Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.25, 0.25)
                            If status = enumMotionFlag.eSent Then Exit Do
                        Loop

                        Do
                            If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                            If .Home.Cancel Then
                                Call EmgStop(axisID)
                                .Home.Cancel = False
                                m_Axis(axisID).IsThreadFinished = True : Exit Sub
                            End If
                        Loop
                    Else
                        Call EmgStop(axisID)
                        Exit Do
                    End If
                Loop
            End If
            Thread.Sleep(1000)
            Call ChkStatus(axisID)
            If .IO.NegativeLimitSwitch = enumMotionFlag.eLow OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eLow Then
                If .Speed.MaxVel * .Param.SwScale > 8000 Then
                    'Configure the max velocity for the motion axis(Unit:PPU/s).
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(500000), CUInt(Marshal.SizeOf(GetType(Double))))
                    'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                    'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                    'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                    'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                Else
                    'Configure the max velocity for the motion axis(Unit:PPU/s).
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(8000), CUInt(Marshal.SizeOf(GetType(Double))))
                    'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                    'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(1000000), CUInt(Marshal.SizeOf(GetType(Double))))
                    'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                    'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                    errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(1000000), CUInt(Marshal.SizeOf(GetType(Double))))
                End If
                errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelLow), Double.Parse(.Home.HighSpeed * .Param.SwScale), CUInt(Marshal.SizeOf(GetType(Double))))
                errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelHigh), Double.Parse(.Home.HighSpeed * .Param.SwScale), CUInt(Marshal.SizeOf(GetType(Double))))
                errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxAcc), Double.Parse(10000), CUInt(Marshal.SizeOf(GetType(Double))))
                errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxDec), Double.Parse(10000), CUInt(Marshal.SizeOf(GetType(Double))))
                errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxHomeExSwitchMode), 2, CUInt(Marshal.SizeOf(GetType(UInt32))))
                'Home mode
                '0 MODE1_Abs  ORG only (switch off) 
                '1 MODE2_Lmt  EL only (switch off) 
                '2 MODE3_Ref  EZ only (switch off) 
                '3 MODE4_Abs_Ref  ORG+EZ(switch off) 
                '4 MODE5_Abs_NegRef  ORG+ inverse EZ (switch off) 
                '5 MODE6_Lmt_Ref  EL+EZ (switch off) 
                '6 MODE7_AbsSearch  ORG only (switch On) 
                '7 MODE8_LmtSearch  EL only (switch On) 
                '8 MODE9_AbsSearch_Ref  ORG+EZ (switch On) 
                '9 MODE10_AbsSearch_NegRef  ORG+ inverse EZ (switch On) 
                '10 MODE11_LmtSearch_Ref  EL+EZ (switch On) 
                '11: MODE12_AbsSearchReFind(AbsSearch(VH) + ReFindORG(VL))
                '12: MODE13_LmtSearchReFind(LmtSearch(VH) + ReFindEL(VL))
                '13 MODE14_AbsSearchReFind_Ref AbsSearch(VH)+ReFindORG(VL)+EZ(switch off) 
                '14 MODE15_AbsSearchReFind_NegRef AbsSearch(VH)+ReFindORG(VL)+inverse EZ (switch off) 
                '15 MODE16_LmtSearchReFind_Ref LmtSearch(VH)+ReFindEL(VL)+inverse EZ (switch off) 
                'Direction
                '0:              Positive(direction)
                '1:              Negative()
                errCode = Motion.mAcm_AxHome(m_Axishand(.AxisID), CUInt(.Mode.HomeMode), CUInt(.Mode.HomeDir))
                Do
                    If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                    If .Home.Cancel Then
                        .Home.Cancel = False
                        m_Axis(axisID).IsThreadFinished = True : Exit Sub
                    End If
                Loop
            End If
            Call Threading.Thread.Sleep(2000)
            Call SetHomeOffset(axisID)

            Do
                If home_Dir = PositiveDIR Then
                    MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status)
                Else
                    Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.25, 0.25)
                End If
                If status = enumMotionFlag.eSent Then Exit Do
            Loop

            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    .Home.Cancel = False
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            Call Threading.Thread.Sleep(1000)
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelLow), Double.Parse(.Home.LowSpeed * .Param.SwScale), CUInt(Marshal.SizeOf(GetType(Double))))
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.PAR_AxVelHigh), Double.Parse(.Home.LowSpeed * .Param.SwScale), CUInt(Marshal.SizeOf(GetType(Double))))
            errCode = Motion.mAcm_AxHome(m_Axishand(.AxisID), CUInt(.Mode.HomeMode), CUInt(.Mode.HomeDir))
            Call Threading.Thread.Sleep(100)
            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                ' If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then Exit Do
                If .Home.Cancel Then
                    .Home.Cancel = False
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            Call Threading.Thread.Sleep(2000)
            Call SetHomeOffset(axisID)
            .Status.HomeRdy = enumMotionFlag.eHigh
        End With
        m_Axis(axisID).IsThreadFinished = True
    End Sub
    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset
        Dim errCode As UInteger
        With m_Axis(AxisID)
            errCode = Motion.mAcm_AxSetCmdPosition(m_Axishand(.AxisID), Double.Parse(.Home.Offset))
            errCode = Motion.mAcm_AxSetActualPosition(m_Axishand(.AxisID), Double.Parse(.Home.Offset))
            Call Threading.Thread.Sleep(50)
        End With
    End Sub
    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode
        Dim errCode As UInteger
        Dim buffLen As UInteger = 0
        With m_Axis(AxisID)
            'Setting of command pulse output mode. 
            '1 OUT/DIR 
            '2 OUT/DIR, OUT negative logic 
            '4 OUT/DIR, DIR negative logic 
            '8 OUT/DIR, OUT&DIR negative logic 
            '16 CW/CCW 
            '32 CW/CCW, CW&CCW negative logic 
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxPulseOutMode), UInteger.Parse(.Mode.PulseOutMode), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting of encoder feedback pulse input mode. 
            '0 1X A/B
            '1 2X A/B
            '2 4X A/B
            '3 CW/CCW 
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxPulseInMode), UInteger.Parse(.Mode.PulseInputMode), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Motion Alarm function enable/disable. Alarm is a signal generated by motor drive when motor drive is in alarm status. 
            '0 Disabled (Default) or 1 Enabled
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxAlmEnable), UInteger.Parse(.Mode.AlarmMode), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting of active logic for Alarm signal. 0 Low Active or 1 High Active
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxAlmLogic), UInteger.Parse(.Mode.AlarmLogic), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'In-Position function enable/disable. 0 Disabled (Default) or 1 Enabled
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxInpEnable), UInteger.Parse(.Mode.InpEnable), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting of active logic for In-Position signal. 0 Low Active or 1 High Active
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxInpLogic), UInteger.Parse(.Mode.InpLogic), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting of active logic for hardware limit signal. 0 Low Active or 1 High Active
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxElLogic), UInteger.Parse(.Mode.LimitLogic), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting the reacting mode of EL signal.
            '0 Motor immediately stop(Default) 
            '1 Motor decelerate to stop 
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxElReact), UInteger.Parse(.Mode.LimitMode), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Setting the active logic for ORG(IN3) signal. 0 Low Active or 1 High Active
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxOrgLogic), UInteger.Parse(.Mode.OrgLogic), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Pulse per unit(PPU), a virtual unit.
            'For PCI1240 device, this property value must be greater than 0. The default value is 10. 
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxPPU), UInteger.Parse(1), CUInt(Marshal.SizeOf(GetType(UInteger))))
            'Enable PCI1240 axis general DO function.
            '0:          GEN_DO_DIS(Disabled)
            '1 GEN_DO_EN Enabled(Default) 
            errCode = Motion.mAcm_SetProperty(m_Axishand(.AxisID), CUInt(PropertyID.CFG_AxGenDoEnable), UInteger.Parse(1), CUInt(Marshal.SizeOf(GetType(UInteger))))
        End With
    End Sub
    Friend Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        ChkPreRegisterEmpty = enumMotionFlag.eReady
    End Function
    Friend Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer

    End Sub
    Friend Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn
        Dim result As UInteger
        Dim servoON As UInteger
        servoON = 1
        With m_Axis(AxisID)
            result = Motion.mAcm_AxSetSvOn(m_Axishand(.AxisID), servoON)
            If result <> CUInt(ErrorCode.SUCCESS) Then
            End If
        End With
    End Sub
    Friend Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff
        Dim result As UInteger
        Dim servoOFF As UInteger
        servoOFF = 0
        With m_Axis(AxisID)
            result = Motion.mAcm_AxSetSvOn(m_Axishand(.AxisID), servoOFF)
            If result <> CUInt(ErrorCode.SUCCESS) Then
            End If
        End With
    End Sub
    Friend Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus
        Dim result As UInteger
        Dim motionStatus As UInteger
        Dim ioStatus As UInteger
        Const B_NORMALSTOP As Short = 2
        Const B_READY As Short = 1
        Const IO_RDYINPUT = 0
        Const IO_ALARMSIGNAL = 2
        Const IO_POSITIVELIMITSWITCH = 4
        Const IO_NEGATIVELIMITSWITCH = 8
        Const IO_ORIGINSWITCH = 16
        Const IO_DIROUTPUT = 32
        Const IO_EMERGENCYSTOPSWITCH = 64
        Const IO_PCSSIGNALINPUT = 128
        Const IO_ERCOUTPUT = 256
        Const IO_INDEXSIGNAL = 512
        Const IO_CLEARSIGNAL = 1024
        Const IO_LATCHSIGNALINPUT = 2048
        Const IO_POSITIVESLOWDOWNPOINT = 4096
        Const IO_NEGATIVESLOWDOWNPOINT = 4096
        Const IO_INPOSITIONSIGNALINPUT = 8192
        Const IO_SERVOONOUTPUT = 16384
        'Const IO_SOFTPOSITIVELIMITSWITCH = 65536
        'Const IO_SOFTNEGATIVELIMITSWITCH = 131072
        With m_Axis(AxisID)
            result = Motion.mAcm_AxGetState(m_Axishand(.AxisID), motionStatus)
            If result = CUInt(ErrorCode.SUCCESS) Then
                .Status.MovementIsFinished = CType(IIf(motionStatus = B_READY, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                result = Motion.mAcm_AxGetMotionIO(m_Axishand(.AxisID), ioStatus)
                If result = CUInt(ErrorCode.SUCCESS) Then
                    With .IO
                        .RdyInput = IIf((IO_RDYINPUT And ioStatus) = IO_RDYINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .AlarmSignal = IIf((IO_ALARMSIGNAL And ioStatus) = IO_ALARMSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .PositiveLimitSwitch = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .NegativeLimitSwitch = IIf((IO_NEGATIVELIMITSWITCH And ioStatus) = IO_NEGATIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .OriginSwitch = IIf((IO_ORIGINSWITCH And ioStatus) = IO_ORIGINSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .DIROutput = IIf((IO_DIROUTPUT And ioStatus) = IO_DIROUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .EMGStatus = IIf((IO_EMERGENCYSTOPSWITCH And ioStatus) = IO_EMERGENCYSTOPSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .PCSSignalInput = IIf((IO_PCSSIGNALINPUT And ioStatus) = IO_PCSSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .ERCOutput = IIf((IO_ERCOUTPUT And ioStatus) = IO_ERCOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .IndexSignal = IIf((IO_INDEXSIGNAL And ioStatus) = IO_INDEXSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .ClearSignal = IIf((IO_CLEARSIGNAL And ioStatus) = IO_CLEARSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .LatchSignalInput = IIf((IO_LATCHSIGNALINPUT And ioStatus) = IO_LATCHSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .InPositionSignalInput = IIf((IO_INPOSITIONSIGNALINPUT And ioStatus) = IO_INPOSITIONSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .ServoOnOutput = IIf((IO_SERVOONOUTPUT And ioStatus) = IO_SERVOONOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .PositiveSlowDownPoint = IIf((IO_POSITIVESLOWDOWNPOINT And ioStatus) = IO_POSITIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .NegativeSlowDownPoint = IIf((IO_NEGATIVESLOWDOWNPOINT And ioStatus) = IO_NEGATIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        .InterruptStatus = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                        If .AlarmSignal = enumMotionFlag.eHigh Then m_Axis(AxisID).ErrMessage = "驅動器報警! Driver Alarm"
                        If .PositiveLimitSwitch = enumMotionFlag.eHigh Then m_Axis(AxisID).ErrMessage = "行程正極限! PositiveLimit Alarm"
                        If .NegativeLimitSwitch = enumMotionFlag.eHigh Then m_Axis(AxisID).ErrMessage = "行程負極限! NegativeLimit Alarm"
                    End With
                End If
            End If
        End With
    End Sub
    Friend Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus
        Dim result As UInteger
        Dim motionStatus As UShort
        Dim ioStatus As UInteger
        Const IO_RDYINPUT = 0
        Const IO_ALARMSIGNAL = 2
        Const IO_POSITIVELIMITSWITCH = 4
        Const IO_NEGATIVELIMITSWITCH = 8
        Const IO_ORIGINSWITCH = 16
        Const IO_DIROUTPUT = 32
        Const IO_EMERGENCYSTOPSWITCH = 64
        Const IO_PCSSIGNALINPUT = 128
        Const IO_ERCOUTPUT = 256
        Const IO_INDEXSIGNAL = 512
        Const IO_CLEARSIGNAL = 1024
        Const IO_LATCHSIGNALINPUT = 2048
        Const IO_POSITIVESLOWDOWNPOINT = 4096
        Const IO_NEGATIVESLOWDOWNPOINT = 4096
        Const IO_INPOSITIONSIGNALINPUT = 8192
        Const IO_SERVOONOUTPUT = 16384
        'Const IO_SOFTPOSITIVELIMITSWITCH = 65536
        'Const IO_SOFTNEGATIVELIMITSWITCH = 131072

        If m_GpHand(m_Axis(AxisID1).AxisID) = IntPtr.Zero Then
            result = Motion.mAcm_GpAddAxis(m_GpHand(m_Axis(AxisID1).AxisID), m_Axishand(m_Axis(AxisID1).AxisID))
            If Not (result = ErrorCode.SUCCESS) Then
            End If
            result = Motion.mAcm_GpAddAxis(m_GpHand(m_Axis(AxisID1).AxisID), m_Axishand(m_Axis(AxisID2).AxisID))
            If Not (result = ErrorCode.SUCCESS) Then
            End If
        End If
        result = Motion.mAcm_GpGetState(m_GpHand(m_Axis(AxisID1).AxisID), motionStatus)
        If result = UInteger.Parse(ErrorCode.SUCCESS) Then
            m_Axis(AxisID1).Status.MovementIsFinished = CType(IIf(motionStatus = GroupState.STA_Gp_Ready, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
            m_Axis(AxisID2).Status.MovementIsFinished = CType(IIf(motionStatus = GroupState.STA_Gp_Ready, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
        End If
        With m_Axis(AxisID1)
            result = Motion.mAcm_AxGetMotionIO(m_Axishand(.AxisID), ioStatus)
            If result = UInteger.Parse(ErrorCode.SUCCESS) Then
                .IO.RdyInput = IIf((IO_RDYINPUT And ioStatus) = IO_RDYINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.AlarmSignal = IIf((IO_ALARMSIGNAL And ioStatus) = IO_ALARMSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PositiveLimitSwitch = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.NegativeLimitSwitch = IIf((IO_NEGATIVELIMITSWITCH And ioStatus) = IO_NEGATIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.OriginSwitch = IIf((IO_ORIGINSWITCH And ioStatus) = IO_ORIGINSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.DIROutput = IIf((IO_DIROUTPUT And ioStatus) = IO_DIROUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.EMGStatus = IIf((IO_EMERGENCYSTOPSWITCH And ioStatus) = IO_EMERGENCYSTOPSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PCSSignalInput = IIf((IO_PCSSIGNALINPUT And ioStatus) = IO_PCSSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ERCOutput = IIf((IO_ERCOUTPUT And ioStatus) = IO_ERCOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.IndexSignal = IIf((IO_INDEXSIGNAL And ioStatus) = IO_INDEXSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ClearSignal = IIf((IO_CLEARSIGNAL And ioStatus) = IO_CLEARSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.LatchSignalInput = IIf((IO_LATCHSIGNALINPUT And ioStatus) = IO_LATCHSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.InPositionSignalInput = IIf((IO_INPOSITIONSIGNALINPUT And ioStatus) = IO_INPOSITIONSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ServoOnOutput = IIf((IO_SERVOONOUTPUT And ioStatus) = IO_SERVOONOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PositiveSlowDownPoint = IIf((IO_POSITIVESLOWDOWNPOINT And ioStatus) = IO_POSITIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.NegativeSlowDownPoint = IIf((IO_NEGATIVESLOWDOWNPOINT And ioStatus) = IO_NEGATIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.InterruptStatus = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                If .IO.AlarmSignal = enumMotionFlag.eHigh Then .ErrMessage = "驅動器報警! Driver Alarm"
                If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then .ErrMessage = "行程正極限! PositiveLimit Alarm"
                If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then .ErrMessage = "行程負極限! NegativeLimit Alarm"
            End If
        End With
        With m_Axis(AxisID2)
            result = Motion.mAcm_AxGetMotionIO(m_Axishand(.AxisID), ioStatus)
            If result = UInteger.Parse(ErrorCode.SUCCESS) Then
                .IO.RdyInput = IIf((IO_RDYINPUT And ioStatus) = IO_RDYINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.AlarmSignal = IIf((IO_ALARMSIGNAL And ioStatus) = IO_ALARMSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PositiveLimitSwitch = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.NegativeLimitSwitch = IIf((IO_NEGATIVELIMITSWITCH And ioStatus) = IO_NEGATIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.OriginSwitch = IIf((IO_ORIGINSWITCH And ioStatus) = IO_ORIGINSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.DIROutput = IIf((IO_DIROUTPUT And ioStatus) = IO_DIROUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.EMGStatus = IIf((IO_EMERGENCYSTOPSWITCH And ioStatus) = IO_EMERGENCYSTOPSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PCSSignalInput = IIf((IO_PCSSIGNALINPUT And ioStatus) = IO_PCSSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ERCOutput = IIf((IO_ERCOUTPUT And ioStatus) = IO_ERCOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.IndexSignal = IIf((IO_INDEXSIGNAL And ioStatus) = IO_INDEXSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ClearSignal = IIf((IO_CLEARSIGNAL And ioStatus) = IO_CLEARSIGNAL, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.LatchSignalInput = IIf((IO_LATCHSIGNALINPUT And ioStatus) = IO_LATCHSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.InPositionSignalInput = IIf((IO_INPOSITIONSIGNALINPUT And ioStatus) = IO_INPOSITIONSIGNALINPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.ServoOnOutput = IIf((IO_SERVOONOUTPUT And ioStatus) = IO_SERVOONOUTPUT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.PositiveSlowDownPoint = IIf((IO_POSITIVESLOWDOWNPOINT And ioStatus) = IO_POSITIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.NegativeSlowDownPoint = IIf((IO_NEGATIVESLOWDOWNPOINT And ioStatus) = IO_NEGATIVESLOWDOWNPOINT, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IO.InterruptStatus = IIf((IO_POSITIVELIMITSWITCH And ioStatus) = IO_POSITIVELIMITSWITCH, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                If .IO.AlarmSignal = enumMotionFlag.eHigh Then .ErrMessage = "驅動器報警! Driver Alarm"
                If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then .ErrMessage = "行程正極限! PositiveLimit Alarm"
                If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then .ErrMessage = "行程負極限! NegativeLimit Alarm"
            End If
        End With
    End Sub
    Friend Sub Close() Implements IPseudoMotion.Close
        For idx As Integer = LBound(m_Axis) To UBound(m_Axis)
            If m_Axis(idx).CardType = enumMotionCard.Advantech1240U Then
                Call Motion.mAcm_AxClose(m_Axishand(m_Axis(idx).AxisID))
            End If
        Next
    End Sub
    Friend Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pResult As enumMotionFlag) Implements IPseudoMotion.MoveLinear
        Dim result As UInteger
        Dim DrivingVel As Double
        Dim DrivingStrVel As Double
        Dim DrivingAcc As Double
        Dim DrivingDec As Double
        Dim status As enumMotionFlag
        Dim errCode As Integer
        Dim buffLen As UInteger = 0
        Dim motionAxisCount As UInteger
        Dim LinePosArray(0 To 7) As Double
        pResult = enumMotionFlag.eNotSent
        If m_GpHand(m_Axis(AxisID1).AxisID) = IntPtr.Zero Then
            result = Motion.mAcm_GpAddAxis(m_GpHand(m_Axis(AxisID1).AxisID), m_Axishand(m_Axis(AxisID1).AxisID))
            If Not (result = ErrorCode.SUCCESS) Then
            End If
            result = Motion.mAcm_GpAddAxis(m_GpHand(m_Axis(AxisID1).AxisID), m_Axishand(m_Axis(AxisID2).AxisID))
            If Not (result = ErrorCode.SUCCESS) Then
            End If
        End If
        If ChkMultiStop(AxisID1, AxisID2) = enumMotionFlag.eReady Then
            Call ChkSwLimit(AxisID1, EndX, status)
            If status = enumMotionFlag.eHigh Then
                Call ChkSwLimit(AxisID2, EndY, status)
                If status = enumMotionFlag.eHigh Then
                    With m_Axis(AxisID1)
                        If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                        Else
                            If m_Axis(AxisID1).IsExternalParameters Then
                                DrivingVel = m_Axis(AxisID1).Speed.MaxVelExt * m_Axis(AxisID1).Param.SwScale
                                DrivingStrVel = m_Axis(AxisID1).Speed.StrVel * m_Axis(AxisID1).Param.SwScale
                                DrivingAcc = m_Axis(AxisID1).Speed.AccExt * m_Axis(AxisID1).Param.SwScale
                                DrivingDec = m_Axis(AxisID1).Speed.DecExt * m_Axis(AxisID1).Param.SwScale
                            Else
                                DrivingVel = m_Axis(AxisID1).Speed.MaxVel * m_Axis(AxisID1).Param.SwScale
                                DrivingStrVel = m_Axis(AxisID1).Speed.StrVel * m_Axis(AxisID1).Param.SwScale
                                DrivingAcc = m_Axis(AxisID1).Speed.AccLinear * m_Axis(AxisID1).Param.SwScale
                                DrivingDec = m_Axis(AxisID1).Speed.DecLinear * m_Axis(AxisID1).Param.SwScale
                            End If
                            If DrivingVel >= m_Axis(AxisID1).Speed.MaxConstrainedVel Then
                                DrivingVel = m_Axis(AxisID1).Speed.MaxConstrainedVel
                            End If
                            If DrivingVel >= m_Axis(AxisID2).Speed.MaxConstrainedVel Then
                                DrivingVel = m_Axis(AxisID2).Speed.MaxConstrainedVel
                            End If
                            'Configure the max velocity for the motion axis(Unit:PPU/s).
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(500000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max velocity for the motion axis(Unit:PPU/s).
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID2).AxisID), CUInt(PropertyID.CFG_AxMaxVel), Double.Parse(500000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max acceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxAcc / CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID2).AxisID), CUInt(PropertyID.CFG_AxMaxAcc), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Configure the max deceleration for the motion axis(Unit:PPU/S2).
                            'For PCI1240 device, this property 's max value= FT_AxMaxDec/CFG_AxPPU and min value = 125/ CFG_AxPPU, and the value can not greater than 125*CFG_AxMaxVel.
                            errCode = Motion.mAcm_SetProperty(m_Axishand(m_Axis(AxisID2).AxisID), CUInt(PropertyID.CFG_AxMaxDec), Double.Parse(19600000), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Set low velocity (start velocity) of this axis (Unit: PPU/S). 
                            errCode = Motion.mAcm_SetProperty(m_GpHand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.PAR_GpVelLow), Double.Parse(DrivingStrVel), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Set high velocity (driving velocity) of this axis (Unit:PPU/S). 
                            errCode = Motion.mAcm_SetProperty(m_GpHand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.PAR_GpVelHigh), Double.Parse(DrivingVel), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Set acceleration of this axis (Unit: PPU/S2). 
                            errCode = Motion.mAcm_SetProperty(m_GpHand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.PAR_GpAcc), Double.Parse(DrivingAcc), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Set deceleration of this axis (Unit: PPU/S2). 
                            errCode = Motion.mAcm_SetProperty(m_GpHand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.PAR_GpDec), Double.Parse(DrivingDec), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Set the type of velocity profile: t-curve or s-curve.
                            '0 T-curve(Default) 
                            '1(!=0) S-curve 
                            errCode = Motion.mAcm_SetProperty(m_GpHand(m_Axis(AxisID1).AxisID), CUInt(PropertyID.PAR_GpJerk), Double.Parse(1), CUInt(Marshal.SizeOf(GetType(Double))))
                            'Start single axis' absolute motion. 
                            Try
                                motionAxisCount = 2
                                LinePosArray(0) = EndX * m_Axis(AxisID1).Param.SwScale
                                LinePosArray(1) = EndY * m_Axis(AxisID2).Param.SwScale
                                result = Motion.mAcm_GpMoveLinearAbs(m_GpHand(.AxisID), LinePosArray, motionAxisCount)
                            Catch ex As Exception
                                ex = ex
                            End Try
                        End If
                    End With
                    If errCode = 0 Then
                        m_Axis(AxisID1).TargetPosition = EndX
                        m_Axis(AxisID2).TargetPosition = EndY
                        pResult = enumMotionFlag.eSent
                    End If
                Else
                    If status = enumMotionFlag.eLimitP Then
                        pResult = enumMotionFlag.eLimitP
                    ElseIf status = enumMotionFlag.eLimitN Then
                        pResult = enumMotionFlag.eLimitN
                    End If
                End If
            Else
                If status = enumMotionFlag.eLimitP Then
                    pResult = enumMotionFlag.eLimitP
                ElseIf status = enumMotionFlag.eLimitN Then
                    pResult = enumMotionFlag.eLimitN
                End If
            End If
        End If
    End Sub
    Friend Sub MoveArc(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc
    End Sub
    Friend Sub SlowStop(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop

    End Sub
End Class
