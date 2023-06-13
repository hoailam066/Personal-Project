Friend Module DMC2610
    Declare Function d2610_board_init Lib "DMC2610.dll" () As Int16
    Declare Sub d2610_board_close Lib "DMC2610.dll" ()

    '闕喳怀怀堤饜离
    Declare Sub d2610_set_pulse_outmode Lib "DMC2610.dll" (ByVal axis As Int16, ByVal outmode As Int16)

    '蚳蚚 
    Declare Sub d2610_config_SD_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal sd_logic As Int16, ByVal sd_mode As Int16)
    Declare Sub d2610_config_PCS_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal pcs_logic As Int16)
    Declare Sub d2610_config_INP_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal inp_logic As Int16)
    Declare Sub d2610_config_ERC_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal enable As Int16, ByVal erc_logic As Int16, ByVal erc_width As Int16, ByVal erc_off_time As Int16)
    Declare Sub d2610_config_ALM_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal alm_logic As Int16, ByVal alm_action As Int16)
    Declare Sub d2610_config_EL_MODE Lib "DMC2610.dll" (ByVal axis As Int16, ByVal el_mode As Int16)
    Declare Sub d2610_set_HOME_pin_logic Lib "DMC2610.dll" (ByVal axis As Int16, ByVal org_logic As Int16, ByVal filter As Int16)

    Declare Function d2610_read_SEVON_PIN Lib "DMC2610.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2610_write_SEVON_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal on_off As Int16)
    Declare Sub d2610_write_ERC_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal sel As Int16)
    Declare Function d2610_read_RDY_PIN Lib "DMC2610.dll" (ByVal axis As Int16) As Int32

    '弇离掀誕
    Declare Sub d2610_config_CMP_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal cmp1_enable As Int16, ByVal cmp2_enable As Int16, ByVal CMP_logic As Int16)
    Declare Sub d2610_config_comparator Lib "DMC2610.dll" (ByVal axis As Int16, ByVal cmp1_condition As Int16, ByVal cmp2_condition As Int16, ByVal source_sel As Int16, ByVal SL_action As Int16)
    Declare Sub d2610_set_comparator_data Lib "DMC2610.dll" (ByVal axis As Int16, ByVal cmp1_data As Int32, ByVal cmp2_data As Int32)
    Declare Function d2610_read_CMP_PIN Lib "DMC2610.dll" (ByVal axis As Int16) As Int16

    '籵蚚怀/怀堤諷秶滲杅
    Declare Function d2610_read_inbit Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Sub d2610_write_outbit Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal BitNo As Int16, ByVal on_off As Int16)
    Declare Function d2610_read_outbit Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal BitNo As Int16) As Int32
    Declare Function d2610_read_inport Lib "DMC2610.dll" (ByVal card As Int16) As Int32
    Declare Function d2610_read_outport Lib "DMC2610.dll" (ByVal card As Int16) As Int32
    Declare Sub d2610_write_outport Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal Port_Value As Int32)

    '梑埻萸
    Declare Sub d2610_config_home_mode Lib "DMC2610.dll" (ByVal axis As Int16, ByVal mode As Int16, ByVal EZ_count As Int16)
    Declare Sub d2610_home_move Lib "DMC2610.dll" (ByVal axis As Int16, ByVal home_mode As Int16, ByVal vel_mode As Int16)

    '秶雄滲杅
    Declare Sub d2610_decel_stop Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Tdec As Double)
    Declare Sub d2610_imd_stop Lib "DMC2610.dll" (ByVal axis As Int16)
    Declare Sub d2610_emg_stop Lib "DMC2610.dll" ()
    Declare Sub d2610_simultaneous_stop Lib "DMC2610.dll" (ByVal axis As Int16)

    '弇离扢离睿黍滲杅
    Declare Function d2610_get_position Lib "DMC2610.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2610_set_position Lib "DMC2610.dll" (ByVal axis As Int16, ByVal current_position As Int32)

    '袨怓潰聆滲杅
    Declare Function d2610_check_done Lib "DMC2610.dll" (ByVal axis As Int16) As Int16
    Declare Function d2610_prebuff_status Lib "DMC2610.dll" (ByVal axis As Int16) As Int16
    Declare Function d2610_axis_io_status Lib "DMC2610.dll" (ByVal axis As Int16) As Int16
    Declare Function d2610_axis_status Lib "DMC2610.dll" (ByVal axis As Int16) As Int16
    Declare Function d2610_get_rsts Lib "DMC2610.dll" (ByVal axis As Int16) As Int32

    '等粣隅酗堍雄
    Declare Sub d2610_t_pmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_ex_t_pmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_s_pmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_ex_s_pmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist As Int32, ByVal posi_mode As Int16)

    '等粣蟀哿堍雄
    Declare Sub d2610_s_vmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dir As Int16)
    Declare Sub d2610_t_vmove Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dir As Int16)


    '厒僅扢离
    Declare Sub d2610_variety_speed_range Lib "DMC2610.dll" (ByVal axis As Int16, ByVal chg_enable As Int16, ByVal Max_Vel As Double)
    Declare Function d2610_read_current_speed Lib "DMC2610.dll" (ByVal axis As Int16) As Double
    Declare Sub d2610_change_speed Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Curr_Vel As Double)
    Declare Sub d2610_set_vector_profile Lib "DMC2610.dll" (ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2610_set_profile Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double)
    Declare Sub d2610_set_s_profile Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Sacc As Int32, ByVal Sdec As Int32)
    Declare Sub d2610_set_st_profile Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Min_Vel As Double, ByVal Max_Vel As Double, ByVal Tacc As Double, ByVal Tdec As Double, ByVal Tsacc As Double, ByVal Tsdec As Double)

    Declare Sub d2610_reset_target_position Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist As Int32)

    '盄俶脣硃
    Declare Sub d2610_t_line2 Lib "DMC2610.dll" (ByVal AXIS1 As Int16, ByVal Dist1 As Int32, ByVal AXIS2 As Int16, ByVal Dist2 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_t_line3 Lib "DMC2610.dll" (ByVal axis As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_t_line4 Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal Dist1 As Int32, ByVal Dist2 As Int32, ByVal Dist3 As Int32, ByVal Dist4 As Int32, ByVal posi_mode As Int16)
    Declare Sub d2610_t_line6 Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal p_dist As Int32, ByVal posi_mode As Int16)


    '埴說脣硃
    Declare Sub d2610_arc_move Lib "DMC2610.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)
    Declare Sub d2610_rel_arc_move Lib "DMC2610.dll" (ByVal axis As Int16, ByVal target_pos As Int32, ByVal cen_pos As Int32, ByVal arc_dir As Int16)


    '忒謫堍雄
    Declare Sub d2610_set_handwheel_inmode Lib "DMC2610.dll" (ByVal axis As Int16, ByVal inmode As Int16, ByVal count_dir As Int16)
    Declare Sub d2610_handwheel_move Lib "DMC2610.dll" (ByVal axis As Int16, ByVal vh As Double)


    '//---------------------   晤鎢數杅髡夔PLD  ----------------------//
    Declare Function d2610_get_encoder Lib "DMC2610.dll" (ByVal axis As Int16) As Int32
    Declare Sub d2610_set_encoder Lib "DMC2610.dll" (ByVal axis As Int16, ByVal encoder_value As Int32)

    Declare Sub d2610_counter_config Lib "DMC2610.dll" (ByVal axis As Int16, ByVal mode As Int16)
    Declare Sub d2610_config_LTC_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal ltc_logic As Int16, ByVal ltc_mode As Int16)

    Declare Function d2610_get_latch_value Lib "DMC2610.dll" (ByVal axis As Int16) As Int32

    Declare Function d2610_get_latch_flag Lib "DMC2610.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2610_reset_latch_flag Lib "DMC2610.dll" (ByVal cardno As Int16)

    Declare Function d2610_get_counter_flag Lib "DMC2610.dll" (ByVal cardno As Int16) As Int32
    Declare Sub d2610_reset_counter_flag Lib "DMC2610.dll" (ByVal cardno As Int16)

    Declare Sub d2610_reset_clear_flag Lib "DMC2610.dll" (ByVal cardno As Int16)

    '//---------------------   DMC2410陔樓髡夔 ----------------------//
    Declare Sub d2610_config_EZ_PIN Lib "DMC2610.dll" (ByVal axis As Int16, ByVal ez_logic As Int16, ByVal ez_mode As Int16)

    Declare Sub d2610_config_latch_mode Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal all_enable As Int16)

    Declare Sub d2610_triger_chunnel Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal num As Int16)

    Declare Sub d2610_set_speaker_logic Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal logic As Int16)

    Declare Sub d2610_config_EMG_PIN Lib "DMC2610.dll" (ByVal cardno As Int16, ByVal enable As Int16, ByVal emg_logic As Int16)


    '//闕喳絞講扢离睿邳埴脣硃, 闕喳敕遠
    Declare Function d2610_get_equiv Lib "DMC2610.dll" (ByVal axis As Int16, ByRef equiv As Double) As Int32
    Declare Function d2610_set_equiv Lib "DMC2610.dll" (ByVal axis As Int16, ByVal new_equiv As Double) As Int32

    Declare Function d2610_get_position_unitmm Lib "DMC2610.dll" (ByVal axis As Int16, ByRef pos_by_mm As Double) As Int32
    Declare Function d2610_set_position_unitmm Lib "DMC2610.dll" (ByVal axis As Int16, ByVal pos_by_mm As Double) As Int32
    Declare Function d2610_read_current_speed_unitmm Lib "DMC2610.dll" (ByVal axis As Int16, ByRef current_speed As Double) As Int32

    Declare Function d2610_get_encoder_unitmm Lib "DMC2610.dll" (ByVal axis As Int16, ByRef encoder_pos_by_mm As Double) As Int32
    Declare Function d2610_set_encoder_unitmm Lib "DMC2610.dll" (ByVal axis As Int16, ByVal encoder_pos_by_mm As Double) As Int32

    Declare Sub d2610_arc_move_unitmm Lib "DMC2610.dll" (ByRef axis As Int16, ByRef target_pos As Double, ByRef cen_pos As Double, ByVal arc_dir As Int16)
    Declare Sub d2610_rel_arc_move_unitmm Lib "DMC2610.dll" (ByRef axis As Int16, ByRef rel_pos As Double, ByRef rel_cen As Double, ByVal arc_dir As Int16)


    '//崝樓肮奀礿紱釬
    Declare Function d2610_set_t_move_all Lib "DMC2610.dll" (ByVal TotalAxes As Int16, ByRef pAxis As Int16, ByRef pDist As Int32, ByVal posi_mode As Int16) As Int32
    Declare Function d2610_start_move_all Lib "DMC2610.dll" (ByVal FirstAxis As Int16) As Int32

    Declare Function d2610_set_sync_option Lib "DMC2610.dll" (ByVal axis As Int16, ByVal sync_stop_on As Int16, ByVal cstop_output_on As Int16, ByVal sync_option1 As Int16, ByVal sync_option2 As Int16) As Int32
    Declare Function d2610_set_sync_stop_mode Lib "DMC2610.dll" (ByVal axis As Int16, ByVal stop_mode As Int16) As Int32

    '//闕喳敕遠紱釬
    Declare Function d2610_pulse_loop Lib "DMC2610.dll" (ByVal axis As Int16) As Int32
 
End Module
