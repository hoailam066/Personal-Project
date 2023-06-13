Friend Class CDMC5480
    Implements IPseudoMotion
    Private m_Axis() As CAxisBased
    Public Sub New(ByRef pAxis() As CAxisBased)
        m_Axis = pAxis
    End Sub
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Init = True
        Dim count As Integer
        count = DMC5480.d5480_board_init()
        If count = 0 Then
            Init = False
        Else
            Call DMC5480.d5480_config_EMG_PIN(0, 1, 0)
            Call DMC5480.d5480_config_EMG_PIN(1, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(2, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(3, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(4, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(5, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(6, 1, 0)
            'Call DMC5480.d5480_config_EMG_PIN(7, 1, 0)
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
                        Else
                            ChkStop = enumMotionFlag.eNotReady
                        End If
                    Else
                        ChkStop = enumMotionFlag.eReady
                    End If
                Else
                    If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                        If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                        Else
                            ChkStop = enumMotionFlag.eNotReady
                        End If
                    Else
                    End If
                End If
            Else
                ChkStop = enumMotionFlag.eReady
            End If
        End With
    End Function
    Friend Sub ChkSwLimit(ByVal AxisID As Integer, ByVal Target As Double, ByRef pStatus As enumMotionFlag) Implements IPseudoMotion.ChkSwLimit
        'If Target >= m_Axis(AxisID).Param.SwMin Then
        '    If Target <= m_Axis(AxisID).Param.SwMax Then
        pStatus = enumMotionFlag.eHigh
        '    Else
        '        pStatus = enumMotionFlag.eLimitP
        '    End If
        'Else
        '    pStatus = enumMotionFlag.eLimitN
        'End If
    End Sub
    Friend Sub EmgStop(ByVal AxisID As Integer) Implements IPseudoMotion.EmgStop
        DMC5480.d5480_emg_stop()
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        If m_Axis(AxisID).Mode.IsServo Then
            pEncoder = DMC5480.d5480_get_encoder(m_Axis(AxisID).AxisID)
            pEncoder = pEncoder * m_Axis(AxisID).Param.EnrScale
        Else
            pEncoder = DMC5480.d5480_get_position(m_Axis(AxisID).AxisID)
        End If
        pEncoder = pEncoder / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        pCmd = DMC5480.d5480_get_position(m_Axis(AxisID).AxisID)
        pCmd = pCmd / m_Axis(AxisID).Param.SwScale
    End Sub

    Friend Sub ConfigCompare(ByVal AxisID As Integer, ByVal StartPos As Double, ByVal EndPos As Double)
        Dim enable As Short = 1
        Dim cmpEncoder As Short = 1
        Dim moveDir As Short
        Dim movePostive As Short = 1
        Dim moveNegative As Short = 0
        Dim triggerOut As Short = 1
        Dim triggerClose As Short = 2
        Dim outBit As Short = 11
        moveDir = IIf(EndPos > StartPos, movePostive, moveNegative)
        Call DMC5480.d5480_compare_clear_points(m_Axis(AxisID).CardID)
        Call DMC5480.d5480_compare_config(m_Axis(AxisID).CardID, enable, m_Axis(AxisID).AxisID, cmpEncoder)
        Call DMC5480.d5480_compare_add_point(m_Axis(AxisID).CardID, StartPos * m_Axis(AxisID).Param.SwScale / m_Axis(AxisID).Param.EnrScale, moveDir, triggerOut, outBit)
        Call DMC5480.d5480_compare_add_point(m_Axis(AxisID).CardID, EndPos * m_Axis(AxisID).Param.SwScale / m_Axis(AxisID).Param.EnrScale, moveDir, triggerClose, outBit)
    End Sub
    Friend Sub CloseCompare(ByVal AxisID As Integer)
        Call DMC5480.d5480_compare_clear_points(m_Axis(AxisID).CardID)
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
                        Call GetCmd(AxisID, cmd)
                        calcDistance = Math.Abs(Target - cmd) * .Param.SwScale
                        If calcDistance = 0 Then
                            pResult = enumMotionFlag.eSent
                            Exit Sub
                        Else
                            'calcMaxVel = (2 * calcDistance * (.Speed.MaxVel * VelocityRatio - .Speed.StrVel) / ((.Speed.Tacc + .Speed.Tdec) * AccRatio)) + (.Speed.StrVel * .Speed.StrVel)
                            'calcMaxVel = calcMaxVel ^ 0.5
                            'calcMaxVel = calcMaxVel * 0.9
                            'If calcMaxVel >= .Speed.MaxConstrainedVel * VelocityRatio Then
                            '    calcMaxVel = .Speed.MaxConstrainedVel * VelocityRatio
                            'End If
                            'If calcMaxVel <= .Speed.StrVel Then
                            '    calcMaxVel = .Speed.StrVel * 2
                            'End If
                            'calcTacc = .Speed.Tacc * AccRatio * (calcMaxVel - .Speed.StrVel) / (.Speed.MaxVel * VelocityRatio - .Speed.StrVel)
                            'If calcTacc < 0.005 Then calcTacc = 0.005
                            'calcTdec = .Speed.Tdec * AccRatio * (calcMaxVel - .Speed.StrVel) / (.Speed.MaxVel * VelocityRatio - .Speed.StrVel)
                            'If calcTdec < 0.005 Then calcTdec = 0.005
                        End If
                        calcMaxVel = .Speed.MaxVel * VelocityRatio * .Param.SwScale
                        If calcMaxVel > .Speed.MaxConstrainedVel Then calcMaxVel = .Speed.MaxConstrainedVel
                        Call DMC5480.d5480_set_profile(CShort(.AxisID), .Speed.StrVel * .Param.SwScale, calcMaxVel, .Speed.Acc * .Param.SwScale, .Speed.Dec * .Param.SwScale)
                        Call DMC5480.d5480_set_s_profile(CShort(.AxisID), 0)

                        DMC5480.d5480_pmove(CShort(.AxisID), CInt(Target * .Param.SwScale), 1)
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
        Dim status As enumMotionFlag

        m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eNotReady
        m_Axis(axisID).IsThreadFinished = False
        m_Axis(axisID).IsThreadStarted = True

        SetHomeOffset(axisID)
        With m_Axis(axisID)
            If .Mode.IsServo Then ServoOn(axisID)
            Call ChkStatus(axisID)
            home_Dir = CShort(.Mode.HomeDir) '回原点方式。1：正方向回原点，2：负方向回原点
            If home_Dir = 1 Then
                Do
                    Call Threading.Thread.Sleep(1)
                    If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Do
                            Call Threading.Thread.Sleep(1)
                            Call MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status, 0.5, 0.5)
                            If status = enumMotionFlag.eSent Then Exit Do
                        Loop

                        Do
                            Call Threading.Thread.Sleep(1)
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
                    Call Threading.Thread.Sleep(1)
                    If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                        Call SetHomeOffset(axisID)
                        Do
                            Call Threading.Thread.Sleep(1)
                            Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.5, 0.5)
                            If status = enumMotionFlag.eSent Then Exit Do
                        Loop

                        Do
                            Call Threading.Thread.Sleep(1)
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
                Call DMC5480.d5480_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeDir), .Home.HighSpeed * .Param.SwScale, CShort(.Mode.HomeMode), 0)
                Call DMC5480.d5480_set_profile(CShort(.AxisID), .Speed.StrVel * .Param.SwScale, .Home.HighSpeed * .Param.SwScale, .Home.Acc, .Home.Acc * .Param.SwScale)
                DMC5480.d5480_home_move(CShort(.AxisID))
                Do
                    Call Threading.Thread.Sleep(1)
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
                Call Threading.Thread.Sleep(1)
                If home_Dir = 1 Then
                    MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status)
                Else
                    Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.5, 0.5)
                End If
                If status = enumMotionFlag.eSent Then Exit Do
            Loop

            Do
                Call Threading.Thread.Sleep(1)
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    .Home.Cancel = False
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            Call DMC5480.d5480_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeDir), .Home.LowSpeed * .Param.SwScale, CShort(.Mode.HomeMode), 0)
            Call DMC5480.d5480_set_profile(CShort(.AxisID), .Speed.StrVel * .Param.SwScale, .Home.LowSpeed * .Param.SwScale, .Home.Acc * .Param.SwScale, .Home.Acc * .Param.SwScale)
            Call DMC5480.d5480_home_move(CShort(.AxisID))
            Do
                Call Threading.Thread.Sleep(1)
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then Exit Do
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

    Friend Sub SlowStop(ByVal AxisID As Integer)
        With m_Axis(AxisID)
            Call DMC5480.d5480_decel_stop(CShort(.AxisID), CInt(.Speed.Dec))
        End With
    End Sub

    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset
        With m_Axis(AxisID)
            DMC5480.d5480_set_position(CShort(.AxisID), CInt(.Home.Offset))
            DMC5480.d5480_set_encoder(CShort(.AxisID), CInt(.Home.Offset))
        End With
    End Sub

    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode
        With m_Axis(AxisID)
            Call DMC5480.d5480_set_pulse_outmode(CShort(.AxisID), CShort(.Mode.PulseOutMode))
            Call DMC5480.d5480_counter_config(CShort(.AxisID), CShort(.Mode.PulseInputMode))
            If .Mode.IsServo Then

                Call DMC5480.d5480_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeDir), .Home.LowSpeed, CShort(.Mode.HomeMode), 0)
            Else
                Call DMC5480.d5480_config_home_mode(CShort(.AxisID), CShort(.Mode.HomeDir), .Home.LowSpeed, CShort(.Mode.HomeMode), 0)
            End If
            Call DMC5480.d5480_config_EZ_PIN(CShort(.AxisID), 1, 0)
            Call DMC5480.d5480_config_HOME_PIN_logic(CShort(.AxisID), CShort(.Mode.OrgLogic), 1)
            Call DMC5480.d5480_config_INP_PIN(CShort(.AxisID), CShort(.Mode.InpEnable), CShort(.Mode.InpLogic))
            Call DMC5480.d5480_config_ALM_PIN(CShort(.AxisID), 1, CShort(.Mode.AlarmLogic), CShort(.Mode.AlarmMode))
            Call DMC5480.d5480_config_EL_PIN((CShort(.AxisID)), CShort(.Mode.SdLogic), 0)
            Call DMC5480.d5480_config_ERC_PIN(CShort(.AxisID), CShort(.Mode.ERCEnable), CShort(.Mode.ERCLogic), 0, 0)
            Call DMC5480.d5480_config_LTC_PIN(CShort(.AxisID), 1, 0)
            'Call DMC5480.d5480_write_SEVON_PIN(CShort(.AxisID), CShort(.Mode.ServoONLogic))
            'Call DMC5480.d5480_config_EMG_PIN(CShort(.AxisID), 1, 1)



        End With



        'If m_Axis(AxisID).Mode.IsServo Then
        '    Call ServoOn(AxisID)
        'End If
    End Sub

    Public Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus
        Const DMC5480_Finished = 1
        Const IO_DMC5480_AlarmSignal = 1
        Const IO_DMC5480_PositiveLimitSwitch = 2
        Const IO_DMC5480_NegativeLimitSwitch = 4
        Const IO_DMC5480_EmergencyStopSwitch = 8
        Const IO_DMC5480_OriginSwitch = 16
        Const IO_DMC5480_PositiveSlowDownPoint = 32
        Const IO_DMC5480_NegativeSlowDownPoint = 32
        Const IO_DMC5480_SoftPositiveLimitSwitch = 64
        Const IO_DMC5480_SoftNegativeLimitSwitch = 128
        Const IO_DMC5480_InPositionSignalInput = 256
        Dim MotionStatus As Integer
        Dim IOState As Integer
        With m_Axis(AxisID)
            MotionStatus = DMC5480.d5480_check_done(CShort(.AxisID))
            .Status.MovementIsFinished = IIf(MotionStatus = DMC5480_Finished, enumMotionFlag.eHigh, enumMotionFlag.eLow)
            .Status.MotionSts = IIf(MotionStatus = DMC5480_Finished, "Normal stopped condition", "Waiting for axis to stop")
            IOState = DMC5480.d5480_axis_io_status(CShort(.AxisID))
            With .IO
                .PositiveLimitSwitch = IIf((IO_DMC5480_PositiveLimitSwitch And IOState) = IO_DMC5480_PositiveLimitSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .NegativeLimitSwitch = IIf((IO_DMC5480_NegativeLimitSwitch And IOState) = IO_DMC5480_NegativeLimitSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .PositiveSlowDownPoint = IIf((IO_DMC5480_PositiveSlowDownPoint And IOState) = IO_DMC5480_PositiveSlowDownPoint, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .NegativeSlowDownPoint = IIf((IO_DMC5480_NegativeSlowDownPoint And IOState) = IO_DMC5480_NegativeSlowDownPoint, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .OriginSwitch = IIf((IO_DMC5480_OriginSwitch And IOState) = IO_DMC5480_OriginSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .IndexSignal = enumMotionFlag.eLow
                .AlarmSignal = IIf((IO_DMC5480_AlarmSignal And IOState) = IO_DMC5480_AlarmSignal, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .ServoOnOutput = enumMotionFlag.eLow
                .RdyInput = enumMotionFlag.eLow
                .InterruptStatus = enumMotionFlag.eLow
                .ERCOutput = enumMotionFlag.eLow
                .InPositionSignalInput = IIf((IO_DMC5480_InPositionSignalInput And IOState) = IO_DMC5480_InPositionSignalInput, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .DIROutput = enumMotionFlag.eLow
                .EMGStatus = IIf((IO_DMC5480_EmergencyStopSwitch And IOState) = IO_DMC5480_EmergencyStopSwitch, enumMotionFlag.eHigh, enumMotionFlag.eLow)
                .PCSSignalInput = enumMotionFlag.eLow
                .ClearSignal = enumMotionFlag.eLow
                .LatchSignalInput = enumMotionFlag.eLow
            End With
        End With
    End Sub
    Public Sub Close() Implements IPseudoMotion.Close
        Call DMC5480.d5480_board_close()
    End Sub
    Public Sub MoveArc(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc

    End Sub
    Public Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pResult As enumMotionFlag) Implements IPseudoMotion.MoveLinear
        Dim maxVel As Double
        Dim accLinear As Double
        Dim decLinear As Double

        If m_Axis(AxisID1).IsExternalParameters Then
            maxVel = m_Axis(AxisID1).Speed.MaxVel
            accLinear = m_Axis(AxisID1).Speed.Acc
            decLinear = m_Axis(AxisID1).Speed.Dec
            m_Axis(AxisID1).Speed.MaxVel = m_Axis(AxisID1).Speed.MaxVelExt
            m_Axis(AxisID1).Speed.Acc = m_Axis(AxisID1).Speed.AccExt
            m_Axis(AxisID1).Speed.Dec = m_Axis(AxisID1).Speed.DecExt
        End If

        Call MoveAbs(AxisID1, EndX, pResult)
        If m_Axis(AxisID1).IsExternalParameters Then
            m_Axis(AxisID1).Speed.MaxVel = maxVel
            m_Axis(AxisID1).Speed.Acc = accLinear
            m_Axis(AxisID1).Speed.Dec = decLinear
        End If

        If m_Axis(AxisID1).IsExternalParameters Then
            maxVel = m_Axis(AxisID2).Speed.MaxVel
            accLinear = m_Axis(AxisID2).Speed.Acc
            decLinear = m_Axis(AxisID2).Speed.Dec
            m_Axis(AxisID2).Speed.MaxVel = m_Axis(AxisID1).Speed.MaxVelExt
            m_Axis(AxisID2).Speed.Acc = m_Axis(AxisID1).Speed.AccExt
            m_Axis(AxisID2).Speed.Dec = m_Axis(AxisID1).Speed.DecExt
        End If

        Call MoveAbs(AxisID2, EndY, pResult)
        If m_Axis(AxisID1).IsExternalParameters Then
            m_Axis(AxisID2).Speed.MaxVel = maxVel
            m_Axis(AxisID2).Speed.Acc = accLinear
            m_Axis(AxisID2).Speed.Dec = decLinear
        End If

        'Dim status1 As enumMotionFlag
        'Dim status2 As enumMotionFlag
        'Dim runMaxVelocity As Integer
        'Dim AccelerationExteleration As Integer
        'Dim DecelerationExteleration As Integer
        'Dim runVelocity As Integer
        'Dim cmd1 As Double
        'Dim cmd2 As Double
        'Dim errCode As Integer
        'If ChkStop(AxisID1) = enumMotionFlag.eReady AndAlso ChkStop(AxisID2) = enumMotionFlag.eReady Then
        '    Call ChkSwLimit(AxisID1, EndX, status1)
        '    Call ChkSwLimit(AxisID2, EndY, status2)
        '    Call GetCmd(AxisID1, cmd1)
        '    Call GetCmd(AxisID2, cmd2)
        '    If status1 = enumMotionFlag.eHigh AndAlso status2 = enumMotionFlag.eHigh Then
        '        With m_Axis(AxisID2)
        '            If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then
        '            Else
        '                With m_Axis(AxisID1)
        '                    If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then
        '                    Else
        '                        If .IsExternalParameters Then
        '                            runMaxVelocity = CInt(.Speed.MaxVelExt)
        '                            AccelerationExteleration = CInt(.Speed.AccExt)
        '                            DecelerationExteleration = CInt(.Speed.DecExt)
        '                            runVelocity = CInt(.Speed.MaxVelExt)
        '                        Else
        '                            runMaxVelocity = CInt(.Speed.MaxVelLinear)
        '                            AccelerationExteleration = CInt(.Speed.AccLinear)
        '                            DecelerationExteleration = CInt(.Speed.DecLinear)
        '                            runVelocity = CInt(.Speed.MaxVelLinear)
        '                        End If
        '                        errCode = DMC5480.d5480_set_vector_profile(CShort(.CardID), 0, runMaxVelocity * .Param.SwScale, AccelerationExteleration * .Param.SwScale, DecelerationExteleration * .Param.SwScale)
        '                        errCode = DMC5480.d5480_line2(CShort(.AxisID), CInt((EndX - cmd1) * .Param.SwScale), CShort(m_Axis(AxisID2).AxisID), CInt((EndY - cmd2) * m_Axis(AxisID2).Param.SwScale), 0)
        '                    End If
        '                End With
        '            End If
        '        End With
        '        If errCode = 0 Then pResult = enumMotionFlag.eSent
        '    Else
        '        If status1 = enumMotionFlag.eLimitP Then
        '            pResult = enumMotionFlag.eLimitP
        '        ElseIf status1 = enumMotionFlag.eLimitN Then
        '            pResult = enumMotionFlag.eLimitN
        '        End If
        '    End If
        'Else
        '    pResult = enumMotionFlag.eNotSent
        'End If
    End Sub

    Public Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        Return enumMotionFlag.eNotReady
    End Function

    Public Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget

    End Sub

    Public Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff
        If m_Axis(AxisID).Mode.ServoONLogic = 1 Then
            Call DMC5480.d5480_write_SEVON_PIN(m_Axis(AxisID).AxisID, 0)
        Else
            Call DMC5480.d5480_write_SEVON_PIN(m_Axis(AxisID).AxisID, 1)
        End If
    End Sub

    Public Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn
        If m_Axis(AxisID).Mode.ServoONLogic = 1 Then
            Call DMC5480.d5480_write_SEVON_PIN(m_Axis(AxisID).AxisID, 1)
        Else
            Call DMC5480.d5480_write_SEVON_PIN(m_Axis(AxisID).AxisID, 0)
        End If
    End Sub

    Public Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer

    End Sub

    Public Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop

    End Function

    Public Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus

    End Sub

    Public Sub SlowStop1(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop

    End Sub
End Class
