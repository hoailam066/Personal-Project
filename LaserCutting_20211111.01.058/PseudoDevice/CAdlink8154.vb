Imports System.Threading
Friend Class CAdlink8154
    Implements IPseudoMotion
    Private m_Axis() As CAxisBased
    Public Sub New(ByRef pAxis() As CAxisBased)
        m_Axis = pAxis
    End Sub
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Init = True
        Dim count As Short
        Dim status As Integer
        status = AdlinkPCI8154.B_8154_initial(count, 1)
        If count = 0 Then
            Init = False
        End If
    End Function
    Friend Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkStop
        Call ChkStatus(AxisID)
        ChkStop = enumMotionFlag.eNotReady
        With m_Axis(AxisID)
            If .IO.AlarmSignal = enumMotionFlag.eLow Then
                If (.Status.MovementIsFinished = enumMotionFlag.eHigh) OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
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
        Call AdlinkPCI8154.B_8154_emg_stop(m_Axis(AxisID).AxisID)
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        Call AdlinkPCI8154.B_8154_get_position(m_Axis(AxisID).AxisID, pEncoder)
        pEncoder = pEncoder / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        Dim cmd As Integer
        pCmd = AdlinkPCI8154.B_8154_get_command(m_Axis(AxisID).AxisID, cmd)
        pCmd = cmd / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget
        Call AdlinkPCI8154.B_8154_get_target_pos(m_Axis(AxisID).AxisID, pTarget)
        pTarget = pTarget / m_Axis(AxisID).Param.SwScale
    End Sub
    Friend Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim status As enumMotionFlag
        pResult = enumMotionFlag.eNotSent
        If ChkStop(AxisID) = enumMotionFlag.eReady Then
            Call ChkSwLimit(AxisID, Target, status)
            If status = enumMotionFlag.eHigh Then
                With m_Axis(AxisID)
                    If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then
                    Else
                        Call AdlinkPCI8154.B_8154_start_sa_move(.AxisID, Target * .Param.SwScale, .Speed.StrVel, .Speed.MaxVel * .Speed.RatioMaxVel, .Speed.Tacc * .Speed.RatioAcc, .Speed.Tdec * .Speed.RatioAcc, 0, 0)
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
        'Dim axisParam As CAxisBased
        'axisParam = CType(StateInfo, CAxisBased)
        Dim axisID As Integer = CInt(StateInfo)
        Dim home_mode As Short
        Dim vel_mode As Short
        Dim status As enumMotionFlag

        m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eNotReady
        m_Axis(axisID).IsThreadFinished = False
        m_Axis(axisID).IsThreadStarted = True

        SetHomeOffset(m_Axis(axisID).AxisID)
        With m_Axis(axisID)
            If .Mode.IsServo Then Call ServoOn(axisID)
            Call ChkStatus(axisID)
            home_mode = CShort(.Mode.HomeDir) '回原点方式。1：正方向回原点，2：负方向回原点
            If home_mode = 1 Then
                If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then 'OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                    MoveAbs(axisID, .Home.Offset - 4000, status)
                    Do
                        If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                        If .Home.Cancel Then
                            m_Axis(axisID).IsThreadFinished = True : Exit Sub
                        End If
                    Loop
                Else

                End If
            Else
                If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then 'OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                    MoveAbs(axisID, .Home.Offset + 4000, status)
                    Do
                        If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                        If .Home.Cancel Then
                            m_Axis(axisID).IsThreadFinished = True : Exit Sub
                        End If
                    Loop
                Else

                End If
            End If
            If .IO.NegativeLimitSwitch = enumMotionFlag.eLow OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eLow Then
                If home_mode = 1 Then
                    Call AdlinkPCI8154.B_8154_home_move(.AxisID, .Speed.StrVel, .Home.HighSpeed, .Home.Acc)
                Else
                    Call AdlinkPCI8154.B_8154_home_move(.AxisID, -1 * .Speed.StrVel, -1 * .Home.HighSpeed, .Home.Acc)
                End If
                vel_mode = 1 '回原点速度。0：低速回原点，1：高速回原点
                Do
                    If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                    If .Home.Cancel Then
                        m_Axis(axisID).IsThreadFinished = True : Exit Sub
                    End If
                Loop
            End If
            Call SetHomeOffset(axisID)
            If home_mode = 1 Then
                MoveAbs(axisID, .Home.Offset - 1000, status)
            Else
                MoveAbs(axisID, .Home.Offset + 1000, status)
            End If
            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop
            If home_mode = 1 Then
                Call AdlinkPCI8154.B_8154_home_move(.AxisID, .Speed.StrVel, .Home.LowSpeed, .Home.Acc)
            Else
                Call AdlinkPCI8154.B_8154_home_move(.AxisID, -1 * .Speed.StrVel, -1 * .Home.LowSpeed, .Home.Acc)
            End If
            Do
                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                If .Home.Cancel Then
                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                End If
            Loop

            Call SetHomeOffset(axisID)
            .Status.HomeRdy = enumMotionFlag.eHigh
        End With

        m_Axis(axisID).IsThreadFinished = True
    End Sub
    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset
        Dim offset As Integer
        Thread.Sleep(2000)
        With m_Axis(AxisID)
            offset = CInt(.Home.Offset)
            Call AdlinkPCI8154.B_8154_set_position(.AxisID, .Home.Offset)
            Call AdlinkPCI8154.B_8154_reset_target_pos(.AxisID, .Home.Offset)
            Call AdlinkPCI8154.B_8154_set_command(.AxisID, offset)
            Call AdlinkPCI8154.B_8154_reset_error_counter(.AxisID)
            Call AdlinkPCI8154.B_8154_set_res_distance(.AxisID, 0)
        End With
    End Sub
    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode
        Const ExternalFeedback As Short = 0
        Const CommandPulse As Short = 1
        'Call AdlinkPCI8154.B_8154_config_from_file()
        With m_Axis(AxisID)
            Call AdlinkPCI8154.B_8154_config_from_file()
            Call AdlinkPCI8154.B_8154_set_pls_outmode(.AxisID, .Mode.PulseOutMode)
            Call AdlinkPCI8154.B_8154_set_pls_iptmode(.AxisID, .Mode.PulseInputMode, .Mode.PulseLogic)
            Call AdlinkPCI8154.B_8154_set_move_ratio(.AxisID, 1)
            If .Mode.IsServo Then
                Call AdlinkPCI8154.B_8154_set_feedback_src(.AxisID, ExternalFeedback)
            Else
                Call AdlinkPCI8154.B_8154_set_feedback_src(.AxisID, CommandPulse)
            End If
            Call AdlinkPCI8154.B_8154_set_erc(.AxisID, 0, 0, 0)
            Call AdlinkPCI8154.B_8154_set_clr_mode(.AxisID, 0, 0)
            Call AdlinkPCI8154.B_8154_set_latch_source(.AxisID, 0)
            Call AdlinkPCI8154.B_8154_set_ltc_logic(.AxisID, 0)
            Call AdlinkPCI8154.B_8154_set_pcs(.AxisID, 0)
            Call AdlinkPCI8154.B_8154_set_latch_source(.AxisID, 0)

            Call AdlinkPCI8154.B_8154_set_alm(.AxisID, .Mode.AlarmLogic, .Mode.AlarmMode)
            Call AdlinkPCI8154.B_8154_set_inp(.AxisID, .Mode.InpEnable, .Mode.InpLogic)
            Call AdlinkPCI8154.B_8154_set_sd(.AxisID, .Mode.SdLogic, .Mode.SdLatch, .Mode.SdMode)
            Call AdlinkPCI8154.B_8154_set_limit_logic(.AxisID, 1)
            Call AdlinkPCI8154.B_8154_set_limit_mode(.AxisID, 0)
            Call AdlinkPCI8154.B_8154_set_home_config(.AxisID, .Mode.HomeMode, .Mode.OrgLogic, .Mode.EZLogic, 0, 1)
            Call AdlinkPCI8154.B_8154_set_move_ratio(.AxisID, 1)
        End With
    End Sub

    Friend Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        Const MOVEISFINISHED As Short = 0
        ChkPreRegisterEmpty = enumMotionFlag.eNotReady
        If AdlinkPCI8154.B_8154_check_continuous_buffer(m_Axis(AxisID).AxisID) = MOVEISFINISHED Then ChkPreRegisterEmpty = enumMotionFlag.eReady
    End Function
    Friend Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer
        If pContiLogic <> 1 Then pContiLogic = 0
        Call AdlinkPCI8154.B_8154_set_continuous_move(m_Axis(AxisID).AxisID, pContiLogic)
    End Sub

    Friend Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn
        With m_Axis(AxisID)
            Call B_8154_set_servo(.AxisID, 1)
        End With
    End Sub
    Friend Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff
        With m_Axis(AxisID)
            Call B_8154_set_servo(.AxisID, 0)
        End With
    End Sub

    Public Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus
        Const B_8154_NORMALSTOP As Short = 0
        Const IO_8154_RDYPININPUT As Short = 1
        Const IO_8154_ALARMSIGNAL As Short = 2
        Const IO_8154_POSITIVELIMITSWITCH As Short = 4
        Const IO_8154_NEGATIVELIMITSWITCH As Short = 8
        Const IO_8154_ORIGINSWITCH As Short = 16
        Const IO_8154_DIROUTPUT As Short = 32
        Const IO_8154_EMGSTATUS As Short = 64
        Const IO_8154_PCSSIGNALINPUT As Short = 128
        Const IO_8154_ERCPINOUTPUT As Short = 256
        Const IO_8154_INDEXSIGNAL As Short = 512
        Const IO_8154_CLEARSIGNAL As Short = 1024
        Const IO_8154_LATCHSIGNALINPUT As Short = 2048
        Const IO_8154_SLOWDOWNSIGNALINPUT As Short = 4096
        Const IO_8154_INPOSITIONSIGNALINPUT As Short = 8192
        Const IO_8154_SERVOONOUTPUTSTATUS As Short = 16384

        Dim MotionStatus As Short
        Dim IOState As Short
        With m_Axis(AxisID)
            MotionStatus = AdlinkPCI8154.B_8154_motion_done(.AxisID)
            .Status.MovementIsFinished = CType(IIf(MotionStatus = B_8154_NORMALSTOP, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
            Call AdlinkPCI8154.B_8154_get_io_status(.AxisID, IOState)
            With .IO
                .RdyInput = CType(IIf(CBool(IO_8154_RDYPININPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .AlarmSignal = CType(IIf(CBool(IO_8154_ALARMSIGNAL And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .PositiveLimitSwitch = CType(IIf(CBool(IO_8154_POSITIVELIMITSWITCH And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .NegativeLimitSwitch = CType(IIf(CBool(IO_8154_NEGATIVELIMITSWITCH And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .OriginSwitch = CType(IIf(CBool(IO_8154_ORIGINSWITCH And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .DIROutput = CType(IIf(CBool(IO_8154_DIROUTPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .EMGStatus = CType(IIf(CBool(IO_8154_EMGSTATUS And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .PCSSignalInput = CType(IIf(CBool(IO_8154_PCSSIGNALINPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .ERCOutput = CType(IIf(CBool(IO_8154_ERCPINOUTPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .IndexSignal = CType(IIf(CBool(IO_8154_INDEXSIGNAL And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .ClearSignal = CType(IIf(CBool(IO_8154_CLEARSIGNAL And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .LatchSignalInput = CType(IIf(CBool(IO_8154_LATCHSIGNALINPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .InPositionSignalInput = CType(IIf(CBool(IO_8154_INPOSITIONSIGNALINPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .ServoOnOutput = CType(IIf(CBool(IO_8154_SERVOONOUTPUTSTATUS And IOState), enumMotionFlag.eLow, enumMotionFlag.eHigh), enumMotionFlag)
                .PositiveSlowDownPoint = CType(IIf(CBool(IO_8154_SLOWDOWNSIGNALINPUT And IOState), enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag)
                .NegativeSlowDownPoint = enumMotionFlag.eLow
                .InterruptStatus = enumMotionFlag.eLow
            End With
        End With
    End Sub

    Public Sub Close() Implements IPseudoMotion.Close
        Call AdlinkPCI8154.B_8154_close()
    End Sub

    Public Sub MoveArc(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc

    End Sub

    Public Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pStatus As enumMotionFlag) Implements IPseudoMotion.MoveLinear

    End Sub

    Public Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop

    End Function

    Public Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus

    End Sub

    Public Sub SlowStop(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop

    End Sub
End Class
