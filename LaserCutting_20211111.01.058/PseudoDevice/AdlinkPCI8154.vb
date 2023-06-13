Friend Module AdlinkPCI8154
    Declare Function B_8154_initial Lib "8154.dll" Alias "_8154_initial" (ByRef CardID_InBit As Short, ByVal Manual_ID As Short) As Short
    Declare Function B_8154_close Lib "8154.dll" Alias "_8154_close" () As Short
    Declare Function B_8154_get_version Lib "8154.dll" Alias "_8154_get_version" (ByVal CardID As Short, ByRef firmware_ver As Short, ByRef driver_ver As Integer, ByRef dll_ver As Integer) As Short
    Declare Function B_8154_set_security_key Lib "8154.dll" Alias "_8154_set_security_key" (ByVal CardID As Short, ByVal old_secu_code As Short, ByVal New_secu_code As Short) As Short
    Declare Function B_8154_check_security_key Lib "8154.dll" Alias "_8154_check_security_key" (ByVal CardID As Short, ByVal secu_code As Short) As Short
    Declare Function B_8154_reset_security_key Lib "8154.dll" Alias "_8154_reset_security_key" (ByVal CardID As Short) As Short
    Declare Function B_8154_config_from_file Lib "8154.dll" Alias "_8154_config_from_file" () As Short
    Declare Function B_8154_get_DBboard_type Lib "8154.dll" Alias "_8154_get_DBboard_type" (ByVal CardID As Short, ByRef DBtype As Short) As Short
    ' Pulse Input/Output Configuration Section 6.4
    Declare Function B_8154_set_pls_outmode Lib "8154.dll" Alias "_8154_set_pls_outmode" (ByVal AxisNo As Short, ByVal pls_outmode As Short) As Short
    Declare Function B_8154_set_pls_iptmode Lib "8154.dll" Alias "_8154_set_pls_iptmode" (ByVal AxisNo As Short, ByVal pls_iptmode As Short, ByVal pls_logic As Short) As Short
    Declare Function B_8154_set_feedback_src Lib "8154.dll" Alias "_8154_set_feedback_src" (ByVal AxisNo As Short, ByVal src As Short) As Short
    ' Velocity mode motion Section 6.5
    Declare Function B_8154_tv_move Lib "8154.dll" Alias "_8154_tv_move" (ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
    Declare Function B_8154_sv_move Lib "8154.dll" Alias "_8154_sv_move" (ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal SVacc As Double) As Short
    Declare Function B_8154_sd_stop Lib "8154.dll" Alias "_8154_sd_stop" (ByVal AxisNo As Short, ByVal Tdec As Double) As Short
    Declare Function B_8154_emg_stop Lib "8154.dll" Alias "_8154_emg_stop" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_get_current_speed Lib "8154.dll" Alias "_8154_get_current_speed" (ByVal AxisNo As Short, ByRef speed As Double) As Short
    Declare Function B_8154_speed_override Lib "8154.dll" Alias "_8154_speed_override" (ByVal CAxisNo As Short, ByVal NewVelPercent As Double, ByVal Time As Double) As Short
    Declare Function B_8154_speed_override2 Lib "8154.dll" Alias "_8154_speed_override2" (ByVal CAxisNo As Short, ByVal NewVel As Double, ByVal Time As Double) As Short
    Declare Function B_8154_set_max_override_speed Lib "8154.dll" Alias "_8154_set_max_override_speed" (ByVal AxisNo As Short, ByVal OvrdSpeed As Double, ByVal Enable As Short) As Short
    ' Single Axism_Position Mode Section 6.6
    Declare Function B_8154_start_tr_move Lib "8154.dll" Alias "_8154_start_tr_move" (ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_move Lib "8154.dll" Alias "_8154_start_ta_move" (ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_move Lib "8154.dll" Alias "_8154_start_sr_move" (ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_move Lib "8154.dll" Alias "_8154_start_sa_move" (ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_set_move_ratio Lib "8154.dll" Alias "_8154_set_move_ratio" (ByVal AxisNo As Short, ByVal move_ratio As Double) As Short
    Declare Function B_8154_position_override Lib "8154.dll" Alias "_8154_position_override" (ByVal AxisNo As Short, ByVal NewPos As Double) As Short
    ' Linear Interpolated Motion Section 6.7
    '  Two Axes Linear Interpolation function
    Declare Function B_8154_start_tr_move_xy Lib "8154.dll" Alias "_8154_start_tr_move_xy" (ByVal CardID As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_tr_move_zu Lib "8154.dll" Alias "_8154_start_tr_move_zu" (ByVal CardID As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_move_xy Lib "8154.dll" Alias "_8154_start_ta_move_xy" (ByVal CardID As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_move_zu Lib "8154.dll" Alias "_8154_start_ta_move_zu" (ByVal CardID As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_move_xy Lib "8154.dll" Alias "_8154_start_sr_move_xy" (ByVal CardID As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sr_move_zu Lib "8154.dll" Alias "_8154_start_sr_move_zu" (ByVal CardID As Short, ByVal DistX As Double, ByVal DistY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_move_xy Lib "8154.dll" Alias "_8154_start_sa_move_xy" (ByVal CardID As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_move_zu Lib "8154.dll" Alias "_8154_start_sa_move_zu" (ByVal CardID As Short, ByVal PosX As Double, ByVal PosY As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' Any 2 of former or later 4 axes linear interpolation function
    Declare Function B_8154_start_tr_line2 Lib "8154.dll" Alias "_8154_start_tr_line2" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_line2 Lib "8154.dll" Alias "_8154_start_ta_line2" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_line2 Lib "8154.dll" Alias "_8154_start_sr_line2" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_line2 Lib "8154.dll" Alias "_8154_start_sa_line2" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' Any 3 of former or later 4 axes linear interpolation function
    Declare Function B_8154_start_tr_line3 Lib "8154.dll" Alias "_8154_start_tr_line3" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_line3 Lib "8154.dll" Alias "_8154_start_ta_line3" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_line3 Lib "8154.dll" Alias "_8154_start_sr_line3" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_line3 Lib "8154.dll" Alias "_8154_start_sa_line3" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' Former or later 4 Axes linear interpolation function
    Declare Function B_8154_start_tr_line4 Lib "8154.dll" Alias "_8154_start_tr_line4" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_line4 Lib "8154.dll" Alias "_8154_start_ta_line4" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_line4 Lib "8154.dll" Alias "_8154_start_sr_line4" (ByRef AxisArray As Short, ByRef DistArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_line4 Lib "8154.dll" Alias "_8154_start_sa_line4" (ByRef AxisArray As Short, ByRef PosArray As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' I16 FNTYPE _8154_tv_line2(I16 *AxisArray, F64 StrVel, F64 MaxVel, F64 Tacc);
    ' I16 FNTYPE _8154_sv_line2(I16 *AxisArray,  F64 StrVel, F64 MaxVel, F64 Tacc, F64 SVacc);
    ' Circular Interpolation Motion Section 6.8
    '  Two Axes Arc Interpolation function
    Declare Function B_8154_start_tr_arc_xy Lib "8154.dll" Alias "_8154_start_tr_arc_xy" (ByVal CardID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_arc_xy Lib "8154.dll" Alias "_8154_start_ta_arc_xy" (ByVal CardID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_arc_xy Lib "8154.dll" Alias "_8154_start_sr_arc_xy" (ByVal CardID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_arc_xy Lib "8154.dll" Alias "_8154_start_sa_arc_xy" (ByVal CardID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_tr_arc_zu Lib "8154.dll" Alias "_8154_start_tr_arc_zu" (ByVal CardID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_arc_zu Lib "8154.dll" Alias "_8154_start_ta_arc_zu" (ByVal CardID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_arc_zu Lib "8154.dll" Alias "_8154_start_sr_arc_zu" (ByVal CardID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_arc_zu Lib "8154.dll" Alias "_8154_start_sa_arc_zu" (ByVal CardID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_tr_arc2 Lib "8154.dll" Alias "_8154_start_tr_arc2" (ByRef AxisArray As Short, ByRef OffsetCenter As Double, ByRef OffsetEnd As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_arc2 Lib "8154.dll" Alias "_8154_start_ta_arc2" (ByRef AxisArray As Short, ByRef CenterPos As Double, ByRef EndPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_arc2 Lib "8154.dll" Alias "_8154_start_sr_arc2" (ByRef AxisArray As Short, ByRef OffsetCenter As Double, ByRef OffsetEnd As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_arc2 Lib "8154.dll" Alias "_8154_start_sa_arc2" (ByRef AxisArray As Short, ByRef CenterPos As Double, ByRef EndPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' Helical Interpolation Motion Section 6.9
    Declare Function B_8154_start_tr_helical Lib "8154.dll" Alias "_8154_start_tr_helical" (ByVal card_ID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal PitchDist As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_ta_helical Lib "8154.dll" Alias "_8154_start_ta_helical" (ByVal card_ID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal PitchPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double) As Short
    Declare Function B_8154_start_sr_helical Lib "8154.dll" Alias "_8154_start_sr_helical" (ByVal card_ID As Short, ByVal OffsetCx As Double, ByVal OffsetCy As Double, ByVal OffsetEx As Double, ByVal OffsetEy As Double, ByVal PitchDist As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    Declare Function B_8154_start_sa_helical Lib "8154.dll" Alias "_8154_start_sa_helical" (ByVal card_ID As Short, ByVal Cx As Double, ByVal Cy As Double, ByVal Ex As Double, ByVal Ey As Double, ByVal PitchPos As Double, ByVal CW_CCW As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double) As Short
    ' Home Return Mode Section 6.10
    Declare Function B_8154_set_home_config Lib "8154.dll" Alias "_8154_set_home_config" (ByVal AxisNo As Short, ByVal home_mode As Short, ByVal org_logic As Short, ByVal ez_logic As Short, ByVal ez_count As Short, ByVal erc_out As Short) As Short
    Declare Function B_8154_home_move Lib "8154.dll" Alias "_8154_home_move" (ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double) As Short
    Declare Function B_8154_home_search Lib "8154.dll" Alias "_8154_home_search" (ByVal AxisNo As Short, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal ORGOffset As Double) As Short
    ' Manual Pulser Motion Section 6.11
    Declare Function B_8154_set_pulser_iptmode Lib "8154.dll" Alias "_8154_set_pulser_iptmode" (ByVal AxisNo As Short, ByVal InputMode As Short, ByVal Inverse As Short) As Short
    Declare Function B_8154_disable_pulser_input Lib "8154.dll" Alias "_8154_disable_pulser_input" (ByVal AxisNo As Short, ByVal Disable As Short) As Short
    Declare Function B_8154_pulser_vmove Lib "8154.dll" Alias "_8154_pulser_vmove" (ByVal AxisNo As Short, ByVal SpeedLimit As Double) As Short
    Declare Function B_8154_pulser_pmove Lib "8154.dll" Alias "_8154_pulser_pmove" (ByVal AxisNo As Short, ByVal Dist As Double, ByVal SpeedLimit As Double) As Short
    Declare Function B_8154_set_pulser_ratio Lib "8154.dll" Alias "_8154_set_pulser_ratio" (ByVal AxisNo As Short, ByVal DivF As Short, ByVal MultiF As Short) As Short
    ' Motion Status Section 6.12
    Declare Function B_8154_motion_done Lib "8154.dll" Alias "_8154_motion_done" (ByVal AxisNo As Short) As Short
    ' Motion Interface I/O Section 6.13
    Declare Function B_8154_set_servo Lib "8154.dll" Alias "_8154_set_servo" (ByVal AxisNo As Short, ByVal on_off As Short) As Short
    Declare Function B_8154_set_pcs_logic Lib "8154.dll" Alias "_8154_set_pcs_logic" (ByVal AxisNo As Short, ByVal pcs_logic As Short) As Short
    Declare Function B_8154_set_pcs Lib "8154.dll" Alias "_8154_set_pcs" (ByVal AxisNo As Short, ByVal Enable As Short) As Short
    Declare Function B_8154_set_clr_mode Lib "8154.dll" Alias "_8154_set_clr_mode" (ByVal AxisNo As Short, ByVal clr_mode As Short, ByVal targetCounterInBit As Short) As Short
    Declare Function B_8154_set_inp Lib "8154.dll" Alias "_8154_set_inp" (ByVal AxisNo As Short, ByVal inp_enable As Short, ByVal inp_logic As Short) As Short
    Declare Function B_8154_set_alm Lib "8154.dll" Alias "_8154_set_alm" (ByVal AxisNo As Short, ByVal alm_logic As Short, ByVal alm_mode As Short) As Short
    Declare Function B_8154_set_erc Lib "8154.dll" Alias "_8154_set_erc" (ByVal AxisNo As Short, ByVal erc_logic As Short, ByVal erc_pulse_width As Short, ByVal erc_mode As Short) As Short
    Declare Function B_8154_set_erc_out Lib "8154.dll" Alias "_8154_set_erc_out" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_clr_erc Lib "8154.dll" Alias "_8154_clr_erc" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_set_sd Lib "8154.dll" Alias "_8154_set_sd" (ByVal AxisNo As Short, ByVal sd_logic As Short, ByVal sd_latch As Short, ByVal sd_mode As Short) As Short
    Declare Function B_8154_enable_sd Lib "8154.dll" Alias "_8154_enable_sd" (ByVal AxisNo As Short, ByVal Enable As Short) As Short
    Declare Function B_8154_set_limit_logic Lib "8154.dll" Alias "_8154_set_limit_logic" (ByVal AxisNo As Short, ByVal Logic As Short) As Short
    Declare Function B_8154_set_limit_mode Lib "8154.dll" Alias "_8154_set_limit_mode" (ByVal AxisNo As Short, ByVal limit_mode As Short) As Short
    Declare Function B_8154_get_io_status Lib "8154.dll" Alias "_8154_get_io_status" (ByVal AxisNo As Short, ByRef io_sts As Short) As Short
    ' Interrupt Control Section 6.14
    Declare Function B_8154_int_control Lib "8154.dll" Alias "_8154_int_control" (ByVal CardID As Short, ByVal intFlag As Short) As Short
    Declare Function B_8154_wait_error_interrupt Lib "8154.dll" Alias "_8154_wait_error_interrupt" (ByVal AxisNo As Short, ByVal TimeOut_ms As Integer) As Short
    Declare Function B_8154_wait_motion_interrupt Lib "8154.dll" Alias "_8154_wait_motion_interrupt" (ByVal AxisNo As Short, ByVal IntFactorBitNo As Short, ByVal TimeOut_ms As Integer) As Short
    Declare Function B_8154_set_motion_int_factor Lib "8154.dll" Alias "_8154_set_motion_int_factor" (ByVal AxisNo As Short, ByVal int_factor As Integer) As Short
    'm_Position Control and Counters Section 6.15
    Declare Function B_8154_get_position Lib "8154.dll" Alias "_8154_get_position" (ByVal AxisNo As Short, ByRef Pos As Double) As Short
    Declare Function B_8154_set_position Lib "8154.dll" Alias "_8154_set_position" (ByVal AxisNo As Short, ByVal Pos As Double) As Short
    Declare Function B_8154_get_command Lib "8154.dll" Alias "_8154_get_command" (ByVal AxisNo As Short, ByRef Cmd As Integer) As Short
    Declare Function B_8154_set_command Lib "8154.dll" Alias "_8154_set_command" (ByVal AxisNo As Short, ByVal Cmd As Integer) As Short
    'UPGRADE_NOTE: error 升級為 error_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function B_8154_get_error_counter Lib "8154.dll" Alias "_8154_get_error_counter" (ByVal AxisNo As Short, ByRef error_Renamed As Short) As Short
    Declare Function B_8154_reset_error_counter Lib "8154.dll" Alias "_8154_reset_error_counter" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_set_general_counter Lib "8154.dll" Alias "_8154_set_general_counter" (ByVal AxisNo As Short, ByVal CntSrc As Short, ByVal CntValue As Double) As Short
    Declare Function B_8154_get_general_counter Lib "8154.dll" Alias "_8154_get_general_counter" (ByVal AxisNo As Short, ByRef CntValue As Double) As Short
    Declare Function B_8154_reset_target_pos Lib "8154.dll" Alias "_8154_reset_target_pos" (ByVal AxisNo As Short, ByVal TargetPos As Double) As Short
    Declare Function B_8154_get_target_pos Lib "8154.dll" Alias "_8154_get_target_pos" (ByVal AxisNo As Short, ByRef TargetPos As Double) As Short
    Declare Function B_8154_set_res_distance Lib "8154.dll" Alias "_8154_set_res_distance" (ByVal AxisNo As Short, ByVal ResDistance As Double) As Short
    Declare Function B_8154_get_res_distance Lib "8154.dll" Alias "_8154_get_res_distance" (ByVal AxisNo As Short, ByRef ResDistance As Double) As Short
    'm_Position Compare and Latch Section 6.16
    Declare Function B_8154_set_do_cmp_output_selection Lib "8154.dll" Alias "_8154_set_do_cmp_output_selection" (ByVal CardID As Short, ByVal Channel As Short, ByVal DoCmpOutputSelection As Short) As Short
    Declare Function B_8154_set_trigger_logic Lib "8154.dll" Alias "_8154_set_trigger_logic" (ByVal AxisNo As Short, ByVal Logic As Short) As Short
    Declare Function B_8154_set_error_comparator Lib "8154.dll" Alias "_8154_set_error_comparator" (ByVal AxisNo As Short, ByVal CmpMethod As Short, ByVal CmpAction As Short, ByVal Data As Integer) As Short
    Declare Function B_8154_set_general_comparator Lib "8154.dll" Alias "_8154_set_general_comparator" (ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal CmpAction As Short, ByVal Data As Integer) As Short
    Declare Function B_8154_set_trigger_comparator Lib "8154.dll" Alias "_8154_set_trigger_comparator" (ByVal AxisNo As Short, ByVal CmpSrc As Short, ByVal CmpMethod As Short, ByVal Data As Integer) As Short
    Declare Function B_8154_set_latch_source Lib "8154.dll" Alias "_8154_set_latch_source" (ByVal AxisNo As Short, ByVal LtcSrc As Short) As Short
    Declare Function B_8154_set_ltc_logic Lib "8154.dll" Alias "_8154_set_ltc_logic" (ByVal AxisNo As Short, ByVal LtcLogic As Short) As Short
    Declare Function B_8154_get_latch_data Lib "8154.dll" Alias "_8154_get_latch_data" (ByVal AxisNo As Short, ByVal CounterNo As Short, ByRef Pos As Double) As Short
    ' Continuous Motion Section 6.17
    Declare Function B_8154_set_continuous_move Lib "8154.dll" Alias "_8154_set_continuous_move" (ByVal AxisNo As Short, ByVal Enable As Short) As Short
    Declare Function B_8154_check_continuous_buffer Lib "8154.dll" Alias "_8154_check_continuous_buffer" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_dwell_move Lib "8154.dll" Alias "_8154_dwell_move" (ByVal AxisNo As Short, ByVal milliSecond As Double) As Short
    ' Multiple Axes Simultaneous Operation Section 6.18
    Declare Function B_8154_set_tr_move_all Lib "8154.dll" Alias "_8154_set_tr_move_all" (ByVal TotalAxes As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
    Declare Function B_8154_set_sa_move_all Lib "8154.dll" Alias "_8154_set_sa_move_all" (ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
    Declare Function B_8154_set_ta_move_all Lib "8154.dll" Alias "_8154_set_ta_move_all" (ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef PosA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double) As Short
    Declare Function B_8154_set_sr_move_all Lib "8154.dll" Alias "_8154_set_sr_move_all" (ByVal TotalAx As Short, ByRef AxisArray As Short, ByRef DistA As Double, ByRef StrVelA As Double, ByRef MaxVelA As Double, ByRef TaccA As Double, ByRef TdecA As Double, ByRef SVaccA As Double, ByRef SVdecA As Double) As Short
    Declare Function B_8154_start_move_all Lib "8154.dll" Alias "_8154_start_move_all" (ByVal FirstAxisNo As Short) As Short
    Declare Function B_8154_stop_move_all Lib "8154.dll" Alias "_8154_stop_move_all" (ByVal FirstAxisNo As Short) As Short
    ' General-purposed Input/Output Section 6.19
    Declare Function B_8154_set_gpio_output Lib "8154.dll" Alias "_8154_set_gpio_output" (ByVal CardID As Short, ByVal DoValue As Short) As Short
    Declare Function B_8154_get_gpio_output Lib "8154.dll" Alias "_8154_get_gpio_output" (ByVal CardID As Short, ByRef DoValue As Short) As Short
    Declare Function B_8154_get_gpio_input Lib "8154.dll" Alias "_8154_get_gpio_input" (ByVal CardID As Short, ByRef DiValue As Short) As Short
    Declare Function B_8154_set_gpio_input_function Lib "8154.dll" Alias "_8154_set_gpio_input_function" (ByVal CardID As Short, ByVal Channel As Short, ByVal Select_ As Short, ByVal Logic As Short) As Short
    ' Soft Limit 6.20
    Declare Function B_8154_disable_soft_limit Lib "8154.dll" Alias "_8154_disable_soft_limit" (ByVal AxisNo As Short) As Short
    Declare Function B_8154_enable_soft_limit Lib "8154.dll" Alias "_8154_enable_soft_limit" (ByVal AxisNo As Short, ByVal Action As Short) As Short
    Declare Function B_8154_set_soft_limit Lib "8154.dll" Alias "_8154_set_soft_limit" (ByVal AxisNo As Short, ByVal PlusLimit As Integer, ByVal MinusLimit As Integer) As Short
    Declare Function B_8154_check_soft_limit Lib "8154.dll" Alias "_8154_check_soft_limit" (ByVal AxisNo As Short, ByRef PlusLimit_sts As Short, ByRef MinusLimit_sts As Short) As Short
    ' Backlas Compensation / Vibration Suppression 6.21
    Declare Function B_8154_backlash_comp Lib "8154.dll" Alias "_8154_backlash_comp" (ByVal AxisNo As Short, ByVal CompPulse As Short, ByVal mode As Short) As Short
    Declare Function B_8154_suppress_vibration Lib "8154.dll" Alias "_8154_suppress_vibration" (ByVal AxisNo As Short, ByVal ReverseTime As Short, ByVal ForwardTime As Short) As Short
    Declare Function B_8154_set_fa_speed Lib "8154.dll" Alias "_8154_set_fa_speed" (ByVal AxisNo As Short, ByVal FA_Speed As Double) As Short
    ' Speed Profile Calculation 6.22
    Declare Function B_8154_get_tr_move_profile Lib "8154.dll" Alias "_8154_get_tr_move_profile" (ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pTconst As Double) As Short
    Declare Function B_8154_get_ta_move_profile Lib "8154.dll" Alias "_8154_get_ta_move_profile" (ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pTconst As Double) As Short
    Declare Function B_8154_get_sr_move_profile Lib "8154.dll" Alias "_8154_get_sr_move_profile" (ByVal AxisNo As Short, ByVal Dist As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pSVacc As Double, ByRef pSVdec As Double, ByRef pTconst As Double) As Short
    Declare Function B_8154_get_sa_move_profile Lib "8154.dll" Alias "_8154_get_sa_move_profile" (ByVal AxisNo As Short, ByVal Pos As Double, ByVal StrVel As Double, ByVal MaxVel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal SVacc As Double, ByVal SVdec As Double, ByRef pStrVel As Double, ByRef pMaxVel As Double, ByRef pTacc As Double, ByRef pTdec As Double, ByRef pSVacc As Double, ByRef pSVdec As Double, ByRef pTconst As Double) As Short
End Module
