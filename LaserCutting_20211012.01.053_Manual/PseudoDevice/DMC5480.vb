Friend Module DMC5480
    Declare Function d5480_board_init Lib "DMC5480.dll" () As Integer
    Declare Sub d5480_board_close Lib "DMC5480.dll" ()
    Declare Function d5480_get_card_ID Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_get_lib_version Lib "DMC5480.dll" () As Integer
    Declare Function d5480_get_card_version Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_get_card_soft_version Lib "DMC5480.dll" (ByVal card As Short, ByRef firm_id As Short, ByRef sub_firm_id As Short) As Integer
    Declare Function d5480_get_total_axes Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_set_pulse_outmode Lib "DMC5480.dll" (ByVal axis As Short, ByVal outmode As Short) As Integer
    Declare Function d5480_get_pulse_outmode Lib "DMC5480.dll" (ByVal axis As Short, ByVal outmode As Short) As Integer
    Declare Function d5480_counter_config Lib "DMC5480.dll" (ByVal axis As Short, ByVal mode As Short) As Integer
    Declare Function d5480_get_counter_config Lib "DMC5480.dll" (ByVal axis As Short, ByRef mode As Short) As Integer
    Declare Function d5480_config_INP_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal enable As Short, ByVal inp_logic As Short) As Integer
    Declare Function d5480_config_ERC_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal enable As Short, ByVal erc_logic As Short, ByVal erc_width As Short, ByVal erc_off_time As Short) As Integer
    Declare Function d5480_config_ALM_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal enable As Short, ByVal alm_logic As Short, ByVal alm_action As Short) As Integer
    Declare Function d5480_config_EL_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal el_logic As Short, ByVal el_mode As Short) As Integer
    'UPGRADE_NOTE: filter 升級為 filter_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_config_HOME_PIN_logic Lib "DMC5480.dll" (ByVal axis As Short, ByVal org_logic As Short, ByVal filter_Renamed As Short) As Integer
    Declare Function d5480_write_SEVON_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal on_off As Short) As Integer
    Declare Function d5480_write_ERC_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal sel As Short) As Integer
    Declare Function d5480_read_RDY_PIN Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_config_EMG_PIN Lib "DMC5480.dll" (ByVal cardno As Short, ByVal enable As Short, ByVal emg_logic As Short) As Integer
    Declare Function d5480_get_config_INP_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByRef enable As Short, ByRef inp_logic As Short) As Integer
    Declare Function d5480_get_config_ERC_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByRef enable As Short, ByRef erc_logic As Short, ByRef erc_width As Short, ByRef erc_off_time As Short) As Integer
    Declare Function d5480_get_config_ALM_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByRef alm_logic As Short, ByRef alm_action As Short) As Integer
    Declare Function d5480_get_config_EL_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByRef el_logic As Short, ByRef el_mode As Short) As Integer
    'UPGRADE_NOTE: filter 升級為 filter_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_get_config_HOME_PIN_logic Lib "DMC5480.dll" (ByVal axis As Short, ByRef org_logic As Short, ByRef filter_Renamed As Short) As Integer
    Declare Function d5480_get_config_EMG_PIN Lib "DMC5480.dll" (ByVal cardno As Short, ByRef enable As Short, ByRef emg_logic As Short) As Integer
    Declare Function d5480_read_inbit Lib "DMC5480.dll" (ByVal cardno As Short, ByVal BitNo As Short) As Integer
    Declare Function d5480_write_outbit Lib "DMC5480.dll" (ByVal cardno As Short, ByVal BitNo As Short, ByVal on_off As Short) As Integer
    Declare Function d5480_read_outbit Lib "DMC5480.dll" (ByVal cardno As Short, ByVal BitNo As Short) As Integer
    Declare Function d5480_read_inport Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_read_outport Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_write_outport Lib "DMC5480.dll" (ByVal cardno As Short, ByVal Port_Value As Integer) As Integer
    'UPGRADE_NOTE: dir 升級為 dir_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_config_home_mode Lib "DMC5480.dll" (ByVal axis As Short, ByVal dir_Renamed As Short, ByVal vel As Double, ByVal mode As Short, ByVal EZ_count As Short) As Integer
    Declare Function d5480_home_move Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_decel_stop Lib "DMC5480.dll" (ByVal axis As Short, ByVal dec As Double) As Integer
    Declare Function d5480_imd_stop Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_emg_stop Lib "DMC5480.dll" () As Integer
    Declare Function d5480_simultaneous_stop Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_get_position Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_set_position Lib "DMC5480.dll" (ByVal axis As Short, ByVal current_position As Integer) As Integer
    Declare Function d5480_check_done Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_axis_io_status Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_read_current_speed Lib "DMC5480.dll" (ByVal axis As Short) As Double
    Declare Function d5480_read_vector_speed Lib "DMC5480.dll" (ByVal card As Short) As Double
    Declare Function d5480_change_speed Lib "DMC5480.dll" (ByVal axis As Short, ByVal Curr_Vel As Double) As Integer
    Declare Function d5480_set_vector_profile Lib "DMC5480.dll" (ByVal card As Short, ByVal s_para As Double, ByVal Max_Vel As Double, ByVal acc As Double, ByVal dec As Double) As Integer
    Declare Function d5480_set_profile Lib "DMC5480.dll" (ByVal axis As Short, ByVal rev_option As Double, ByVal Max_Vel As Double, ByVal acc As Double, ByVal dec As Double) As Integer
    Declare Function d5480_get_profile Lib "DMC5480.dll" (ByVal axis As Short, ByRef rev_option As Double, ByRef Max_Vel As Double, ByRef acc As Double, ByRef dec As Double) As Integer
    Declare Function d5480_set_s_profile Lib "DMC5480.dll" (ByVal axis As Short, ByVal s_para As Double) As Integer
    Declare Function d5480_get_s_profile Lib "DMC5480.dll" (ByVal axis As Short, ByRef s_para As Double) As Integer
    Declare Function d5480_reset_target_position Lib "DMC5480.dll" (ByVal axis As Short, ByVal Dist As Integer) As Integer
    Declare Function d5480_pmove Lib "DMC5480.dll" (ByVal axis As Short, ByVal Dist As Integer, ByVal posi_mode As Short) As Integer
    Declare Function d5480_vmove Lib "DMC5480.dll" (ByVal axis As Short, ByVal posi_mode As Short, ByVal vel As Double) As Integer
    Declare Function d5480_line2 Lib "DMC5480.dll" (ByVal AXIS1 As Short, ByVal Dist1 As Integer, ByVal AXIS2 As Short, ByVal Dist2 As Integer, ByVal posi_mode As Short) As Integer
    Declare Function d5480_line3 Lib "DMC5480.dll" (ByRef axis As Short, ByVal Dist1 As Integer, ByVal Dist2 As Integer, ByVal Dist3 As Integer, ByVal posi_mode As Short) As Integer
    Declare Function d5480_line4 Lib "DMC5480.dll" (ByVal cardno As Short, ByVal Dist1 As Integer, ByVal Dist2 As Integer, ByVal Dist3 As Integer, ByVal Dist4 As Integer, ByVal posi_mode As Short) As Integer
    Declare Function d5480_arc_move Lib "DMC5480.dll" (ByRef axis As Short, ByRef target_pos As Integer, ByRef cen_pos As Integer, ByVal arc_dir As Short) As Integer
    Declare Function d5480_rel_arc_move Lib "DMC5480.dll" (ByRef axis As Short, ByRef target_pos As Integer, ByRef cen_pos As Integer, ByVal arc_dir As Short) As Integer
    Declare Function d5480_set_handwheel_inmode Lib "DMC5480.dll" (ByVal axis As Short, ByVal inmode As Short, ByVal multi As Double) As Integer
    Declare Function d5480_get_handwheel_inmode Lib "DMC5480.dll" (ByVal axis As Short, ByRef inmode As Short, ByRef multi As Double) As Integer
    Declare Function d5480_handwheel_move Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_get_encoder Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_set_encoder Lib "DMC5480.dll" (ByVal axis As Short, ByVal encoder_value As Integer) As Integer
    Declare Function d5480_config_LTC_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal ltc_logic As Short, ByVal ltc_mode As Short) As Integer
    Declare Function d5480_get_latch_value Lib "DMC5480.dll" (ByVal axis As Short) As Integer
    Declare Function d5480_get_latch_flag Lib "DMC5480.dll" (ByVal cardno As Short) As Integer
    Declare Function d5480_reset_latch_flag Lib "DMC5480.dll" (ByVal cardno As Short) As Integer
    Declare Function d5480_get_counter_flag Lib "DMC5480.dll" (ByVal cardno As Short) As Integer
    Declare Function d5480_reset_counter_flag Lib "DMC5480.dll" (ByVal cardno As Short) As Integer
    Declare Function d5480_reset_clear_flag Lib "DMC5480.dll" (ByVal cardno As Short) As Integer
    Declare Function d5480_config_EZ_PIN Lib "DMC5480.dll" (ByVal axis As Short, ByVal ez_logic As Short, ByVal ez_mode As Short) As Integer
    Declare Function d5480_config_latch_mode Lib "DMC5480.dll" (ByVal cardno As Short, ByVal all_enable As Short) As Integer
    Declare Function d5480_triger_chunnel Lib "DMC5480.dll" (ByVal cardno As Short, ByVal num As Short) As Integer
    Declare Function d5480_set_speaker_logic Lib "DMC5480.dll" (ByVal cardno As Short, ByVal logic As Short) As Integer
    Declare Function d5480_get_speaker_logic Lib "DMC5480.dll" (ByVal cardno As Short, ByVal logic As Short) As Integer
    Declare Function d5480_compare_config Lib "DMC5480.dll" (ByVal card As Short, ByVal enable As Short, ByVal axis As Short, ByVal cmp_source As Short) As Integer
    Declare Function d5480_compare_get_config Lib "DMC5480.dll" (ByVal card As Short, ByVal enable As Short, ByVal axis As Short, ByVal cmp_source As Short) As Integer
    Declare Function d5480_compare_clear_points Lib "DMC5480.dll" (ByVal card As Short) As Integer
    'UPGRADE_NOTE: dir 升級為 dir_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_compare_add_point Lib "DMC5480.dll" (ByVal card As Short, ByVal pos As Integer, ByVal dir_Renamed As Short, ByVal action As Short, ByVal actpara As Integer) As Integer
    Declare Function d5480_compare_get_current_point Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_compare_get_points_runned Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_compare_get_points_remained Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_lines Lib "DMC5480.dll" (ByVal axisNum As Short, ByRef piaxisList As Short, ByRef pPosList As Integer, ByVal posi_mode As Short) As Integer
    Declare Function d5480_conti_arc Lib "DMC5480.dll" (ByRef axis As Short, ByRef rel_pos As Integer, ByRef rel_cen As Integer, ByVal arc_dir As Short, ByVal posi_mode As Short) As Integer
    Declare Function d5480_conti_restrain_speed Lib "DMC5480.dll" (ByVal card As Short, ByVal v As Double) As Integer
    Declare Function d5480_conti_change_speed_ratio Lib "DMC5480.dll" (ByVal card As Short, ByVal percent As Double) As Integer
    Declare Function d5480_conti_get_current_speed_ratio Lib "DMC5480.dll" (ByVal card As Short) As Integer
    'UPGRADE_NOTE: filter 升級為 filter_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_conti_set_mode Lib "DMC5480.dll" (ByVal card As Short, ByVal conti_mode As Short, ByVal conti_vl As Double, ByVal conti_para As Double, ByVal filter_Renamed As Double) As Integer
    'UPGRADE_NOTE: filter 升級為 filter_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Declare Function d5480_conti_get_mode Lib "DMC5480.dll" (ByVal card As Short, ByVal conti_mode As Short, ByVal conti_vl As Double, ByVal conti_para As Double, ByVal filter_Renamed As Double) As Integer
    Declare Function d5480_conti_open_list Lib "DMC5480.dll" (ByVal axisNum As Short, ByRef piaxisList As Short) As Integer
    Declare Function d5480_conti_close_list Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_check_remain_space Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_decel_stop_list Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_sudden_stop_list Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_pause_list Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_start_list Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_read_current_mark Lib "DMC5480.dll" (ByVal card As Short) As Integer
    Declare Function d5480_conti_extern_lines Lib "DMC5480.dll" (ByVal axisNum As Short, ByRef piaxisList As Short, ByRef pPosList As Integer, ByVal posi_mode As Short, ByVal imark As Integer) As Integer
    Declare Function d5480_conti_extern_arc Lib "DMC5480.dll" (ByRef axis As Short, ByRef rel_pos As Integer, ByRef rel_cen As Integer, ByVal arc_dir As Short, ByVal posi_mode As Short, ByVal imark As Integer) As Integer
    Declare Function d5480_config_softlimit Lib "DMC5480.dll" (ByVal axis As Short, ByVal enable As Short, ByVal source_sel As Short, ByVal SL_action As Short, ByVal cmp1_data As Integer, ByVal cmp2_data As Integer) As Integer
    Declare Function d5480_get_config_softlimit Lib "DMC5480.dll" (ByVal axis As Short, ByVal enable As Short, ByVal source_sel As Short, ByVal SL_action As Short, ByVal cmp1_data As Integer, ByVal cmp2_data As Integer) As Integer
    Declare Function d5480_conti_rel_helix_move_extern Lib "DMC5480.dll" (ByVal card As Short, ByRef axis As Short, ByRef rel_pos As Integer, ByRef rel_cen As Integer, ByVal height As Integer, ByVal arc_dir As Short, ByVal imark As Integer) As Integer
    Declare Function d5480_conti_helix_move_extern Lib "DMC5480.dll" (ByVal card As Short, ByRef axis As Short, ByRef target_pos As Integer, ByRef cen_pos As Integer, ByVal height As Integer, ByVal arc_dir As Short, ByVal imark As Integer) As Integer
    'Public m_nAxisST As Short
    'Public g_UseCard As Short '????
End Module
