Friend Class CDMC2610
    Implements IPseudoMotion
    Private m_Axis() As CAxisBased
    Public Sub New(ByRef pAxis() As CAxisBased)
        m_Axis = pAxis
    End Sub
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Init = True
        Dim count As Integer
        count = DMC2610.d2610_board_init()
        If count = 0 Then
            Init = False
        End If
    End Function
    Friend Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkStop
        Call ChkStatus(AxisID)
        ChkStop = enumMotionFlag.eNotReady
        With m_Axis(AxisID)
            If .IO.AlarmSignal = enumMotionFlag.eLow Then
                If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then
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
        DMC2610.d2610_emg_stop()
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        pEncoder = DMC2610.d2610_get_encoder(m_Axis(AxisID).AxisID)
        pEncoder = pEncoder / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        pCmd = DMC2610.d2610_get_position(m_Axis(AxisID).AxisID)
        pCmd = pCmd / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim status As enumMotionFlag
        Dim cmd As Double
        Dim calcDistance As Double
        Dim calcMaxVel As Double
        Dim calcTacc As Double
        Dim calcTdec As Double
        If ChkStop(AxisID) = enumMotionFlag.eReady Then
            Call ChkSwLimit(AxisID, Target, status)
            If status = enumMotionFlag.eHigh Then
                With m_Axis(AxisID)
                    If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then
                    Else
                        Call GetCmd(.AxisID, cmd)
                        calcDistance = Math.Abs(Target - cmd) * .Param.SwScale
                        If calcDistance = 0 Then
                            pResult = enumMotionFlag.eSent
                            Exit Sub
                        Else
                            calcMaxVel = (2 * calcDistance * (.Speed.MaxVel * VelocityRatio - .Speed.StrVel) / ((.Speed.Tacc + .Speed.Tdec) * AccRatio)) + (.Speed.StrVel * .Speed.StrVel)
                            calcMaxVel = calcMaxVel ^ 0.5
                            calcMaxVel = calcMaxVel * 0.9
                            If calcMaxVel >= .Speed.MaxConstrainedVel * VelocityRatio Then
                                calcMaxVel = .Speed.MaxConstrainedVel * VelocityRatio
                            End If
                            If calcMaxVel <= .Speed.StrVel Then
                                calcMaxVel = .Speed.StrVel * 2
                            End If
                            calcTacc = .Speed.Tacc * AccRatio * (calcMaxVel - .Speed.StrVel) / (.Speed.MaxVel * VelocityRatio - .Speed.StrVel)
                            If calcTacc < 0.005 Then calcTacc = 0.005
                            calcTdec = .Speed.Tdec * AccRatio * (calcMaxVel - .Speed.StrVel) / (.Speed.MaxVel * VelocityRatio - .Speed.StrVel)
                            If calcTdec < 0.005 Then calcTdec = 0.005
                        End If
                        Call DMC2610.d2610_set_s_profile(CShort(.AxisID), .Speed.StrVel, calcMaxVel, calcTacc, calcTdec, CInt(calcMaxVel / 2), CInt(calcMaxVel / 2))
                        Call DMC2610.d2610_ex_s_pmove(CShort(.AxisID), CInt(Target * .Param.SwScale), 1)
                        'Call DMC2610.d2610_ex_s_pmove(CShort(.AxisID), CInt(Target), 1)
                    End If
                End With
                pResult = enumMotionFlag.eSent
            Else
                If status = enumMotionFlag.eLimitP Then
                    pResult = enumMotionFlag.eLimitP
                ElseIf status = enumMotionFlag.eLimitN Then
                    pResult = enumMotionFlag.eLimitN
                End If
            End If
        Else
            pResult = enumMotionFlag.eNotSent
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

        Dim axisID As Integer = CInt(StateInfo)
        Dim home_Dir As Short
        Dim vel_mode As Short
        Dim status As enumMotionFlag

        m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eNotReady
        m_Axis(axisID).IsThreadFinished = False
        m_Axis(axisID).IsThreadStarted = True

        SetHomeOffset(axisID)
        With m_Axis(axisID)
            If .Mode.IsServo Then DMC2610.d2610_write_SEVON_PIN(CShort(.AxisID), 0)
            Call ChkStatus(axisID)
            home_Dir = CShort(.Mode.HomeDir) '回原点方式。1：正方向回原点，2：负方向回原点
            If home_Dir = 1 Then
                Do
                    If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Call MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status)
                        Do
                            If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                            If .Home.Cancel Then
                                .Home.Cancel = False
                                m_Axis(axisID).IsThreadFinished = True : Exit Sub
                            End If
                        Loop
                    Else
                        Exit Do
                    End If
                Loop

            Else
                Do
                    If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status)
                        Do
                            If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                            If .Home.Cancel Then
                                .Home.Cancel = False
                                m_Axis(axisID).IsThreadFinished = True : Exit Sub
                            End If
                        Loop
                    Else
                        Exit Do
                    End If
                Loop
            End If

            If .IO.NegativeLimitSwitch = enumMotionFlag.eLow OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eLow Then
                Call DMC2610.d2610_config_home_mode(CShort(.AxisID), 0, 0)
                Call DMC2610.d2610_set_profile(CShort(.AxisID), .Speed.StrVel, .Home.HighSpeed, .Home.Acc, .Home.Acc)
                vel_mode = 1 '回原点速度。0：低速回原点，1：高速回原点
                DMC2610.d2610_home_move(CShort(.AxisID), home_Dir, vel_mode)
                Do
                    If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                    If .Home.Cancel Then
                        .Home.Cancel = False
                        m_Axis(axisID).IsThreadFinished = True : Exit Sub
                    End If
                Loop
            End If
            Call SetHomeOffset(axisID)
            If home_Dir = 1 Then
                MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status)
            Else
                Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status)
            End If
            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    .Home.Cancel = False
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            Call DMC2610.d2610_set_profile(CShort(.AxisID), .Speed.StrVel, .Home.LowSpeed, .Home.Acc, .Home.Acc)
            Call DMC2610.d2610_home_move(CShort(.AxisID), home_Dir, vel_mode)
            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    .Home.Cancel = False
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            Call SetHomeOffset(axisID)
            .Status.HomeRdy = enumMotionFlag.eHigh
        End With
        m_Axis(axisID).IsThreadFinished = True
    End Sub

    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset
        With m_Axis(AxisID)
            DMC2610.d2610_set_position(CShort(.AxisID), CInt(.Home.Offset))
            DMC2610.d2610_set_encoder(CShort(.AxisID), CInt(.Home.Offset))
        End With
    End Sub

    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode
        With m_Axis(AxisID)
            Call DMC2610.d2610_set_pulse_outmode(CShort(.AxisID), CShort(.Mode.PulseOutMode))
            Call DMC2610.d2610_set_HOME_pin_logic(CShort(.AxisID), CShort(.Mode.OrgLogic), 1)
            If .Mode.IsServo Then
                Call DMC2610.d2610_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeMode), 1)
            Else
                Call DMC2610.d2610_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeMode), 0)
            End If
            Call DMC2610.d2610_config_INP_PIN(CShort(.AxisID), CShort(.Mode.InpEnable), CShort(.Mode.InpLogic))
            Call DMC2610.d2610_counter_config(CShort(.AxisID), CShort(.Mode.PulseInputMode))
            Call DMC2610.d2610_config_ALM_PIN(CShort(.AxisID), CShort(.Mode.AlarmLogic), CShort(.Mode.AlarmMode))
            Call DMC2610.d2610_config_SD_PIN(CShort(.AxisID), CShort(.Mode.SdEnable), CShort(.Mode.SdLogic), 3)
            Call DMC2610.d2610_config_EL_MODE((CShort(.AxisID)), CShort(.Mode.SdLogic))
            Call DMC2610.d2610_config_PCS_PIN(CShort(.AxisID), CShort(.Mode.PCSEnable), CShort(.Mode.PCSLogic))
            Call DMC2610.d2610_config_ERC_PIN(CShort(.AxisID), CShort(.Mode.ERCEnable), CShort(.Mode.ERCLogic), 0, 0)
            Call DMC2610.d2610_config_ALM_PIN(CShort(.AxisID), CShort(.Mode.AlarmLogic), CShort(.Mode.AlarmMode))
            Call DMC2610.d2610_config_EZ_PIN(CShort(.AxisID), CShort(.Mode.EZLogic), 1)
            Call DMC2610.d2610_config_LTC_PIN(CShort(.AxisID), 1, 0)
            Call DMC2610.d2610_config_EL_MODE(CShort(.AxisID), 2)
            Call DMC2610.d2610_write_SEVON_PIN(CShort(.AxisID), CShort(.Mode.ServoONLogic))
            Call DMC2610.d2610_config_EMG_PIN(CShort(.AxisID), 1, 0)
        End With
    End Sub

    Public Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus
        Const DMC2610_Finished = 1
        Const IO_DMC2610_PositiveLimitSwitch = 4096
        Const IO_DMC2610_NegativeLimitSwitch = 8192
        Const IO_DMC2610_PositiveSlowDownPoint = 32768
        Const IO_DMC2610_NegativeSlowDownPoint = 32768
        Const IO_DMC2610_OriginSwitch = 16384
        Const IO_DMC2610_AlarmSignal = 2048


        Const R_DMC2610_IndexSignal = 2048
        Const R_DMC2610_InPositionSignalInput = 32768
        Const R_DMC2610_EMGStatus = 128
        Const R_DMC2610_PCSSignalInput = 256
        Const R_DMC2610_ERCOutput = 512
        Dim MotionStatus As Integer
        Dim IOState As Integer
        Dim RState As Integer
        With m_Axis(AxisID)
            MotionStatus = DMC2610.d2610_check_done(CShort(.AxisID))
            .Status.MovementIsFinished = CType(IIf(MotionStatus = DMC2610_Finished, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
            IOState = DMC2610.d2610_axis_io_status(CShort(.AxisID))
            RState = DMC2610.d2610_get_rsts(CShort(.AxisID))
            With .IO
                .PositiveLimitSwitch = IIf((IO_DMC2610_PositiveLimitSwitch And IOState) = IO_DMC2610_PositiveLimitSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .NegativeLimitSwitch = IIf((IO_DMC2610_NegativeLimitSwitch And IOState) = IO_DMC2610_NegativeLimitSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .PositiveSlowDownPoint = IIf((IO_DMC2610_PositiveSlowDownPoint And IOState) = IO_DMC2610_PositiveSlowDownPoint, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .NegativeSlowDownPoint = IIf((IO_DMC2610_NegativeSlowDownPoint And IOState) = IO_DMC2610_NegativeSlowDownPoint, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .OriginSwitch = IIf((IO_DMC2610_OriginSwitch And IOState) = IO_DMC2610_OriginSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IndexSignal = IIf((R_DMC2610_IndexSignal And RState) = R_DMC2610_IndexSignal, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .AlarmSignal = IIf((IO_DMC2610_AlarmSignal And IOState) = IO_DMC2610_AlarmSignal, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .ServoOnOutput = enumMotionFlag.eLow
                .RdyInput = enumMotionFlag.eLow
                .InterruptStatus = enumMotionFlag.eLow
                .ERCOutput = CType(IIf((R_DMC2610_ERCOutput And RState) = R_DMC2610_ERCOutput, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .InPositionSignalInput = CType(IIf((R_DMC2610_InPositionSignalInput And RState) = R_DMC2610_InPositionSignalInput, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .DIROutput = enumMotionFlag.eLow
                .EMGStatus = CType(IIf((R_DMC2610_EMGStatus And RState) = R_DMC2610_EMGStatus, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .PCSSignalInput = CType(IIf((R_DMC2610_PCSSignalInput And RState) = R_DMC2610_PCSSignalInput, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .ClearSignal = enumMotionFlag.eLow
                .LatchSignalInput = enumMotionFlag.eLow
            End With
        End With
    End Sub
    Public Sub Close() Implements IPseudoMotion.Close
        Call DMC2610.d2610_board_close()
    End Sub
    Public Sub MoveArc(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc

    End Sub
    Public Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pStatus As enumMotionFlag) Implements IPseudoMotion.MoveLinear

    End Sub

    Public Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        Return enumMotionFlag.eNotReady
    End Function

    Public Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget

    End Sub

    Public Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff

    End Sub

    Public Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn

    End Sub

    Public Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer

    End Sub

    Public Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop

    End Function

    Public Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus

    End Sub

    Public Sub SlowStop(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop

    End Sub
End Class
