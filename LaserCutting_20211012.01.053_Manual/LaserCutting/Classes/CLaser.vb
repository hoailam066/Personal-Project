Imports Timer
Imports System.Threading

Public Enum enumLaserMode
    CO2 = 0
    YAG1 = 1
    YAG2 = 2
    YAG3 = 3
    Mode4 = 4
    YAG5 = 5
    Mode6 = 6
End Enum
Public Class CRTC4
#Region "RTC4 APIs"
    Friend Declare Function _RTC4_getmemory Lib "RTC4DLL.DLL" Alias "getmemory" (ByVal adr As Short) As Short
    Friend Declare Sub _RTC4_n_get_waveform Lib "RTC4DLL.DLL" Alias "n_get_waveform" (ByVal n As Short, ByVal channel As Short, ByVal istop As Short, ByVal memptr As Short)
    Friend Declare Sub _RTC4_get_waveform Lib "RTC4DLL.DLL" Alias "get_waveform" (ByVal channel As Short, ByVal istop As Short, ByVal memptr As Short)
    Friend Declare Sub _RTC4_n_measurement_status Lib "RTC4DLL.DLL" Alias "n_measurement_status" (ByVal n As Short, ByRef busy As Short, ByRef position As Short)
    Friend Declare Sub _RTC4_measurement_status Lib "RTC4DLL.DLL" Alias "measurement_status" (ByRef busy As Short, ByRef position As Short)
    Friend Declare Function _RTC4_n_load_varpolydelay Lib "RTC4DLL.DLL" Alias "n_load_varpolydelay" (ByVal n As Short, ByVal stbfilename As String, ByVal tableno As Short) As Short
    Friend Declare Function _RTC4_load_varpolydelay Lib "RTC4DLL.DLL" Alias "load_varpolydelay" (ByVal stbfilename As String, ByVal tableno As Short) As Short
    Friend Declare Function _RTC4_n_load_program_file Lib "RTC4DLL.DLL" Alias "n_load_program_file" (ByVal n As Short, ByVal name As String) As Short
    Friend Declare Function _RTC4_load_program_file Lib "RTC4DLL.DLL" Alias "load_program_file" (ByVal name As String) As Short
    Friend Declare Function _RTC4_n_load_correction_file Lib "RTC4DLL.DLL" Alias "n_load_correction_file" (ByVal n As Short, ByVal filename As String, ByVal cortable As Short, ByVal kx As Double, ByVal ky As Double, ByVal phi As Double, ByVal xoffset As Double, ByVal yoffset As Double) As Short
    Friend Declare Function _RTC4_load_correction_file Lib "RTC4DLL.DLL" Alias "load_correction_file" (ByVal filename As String, ByVal cortable As Short, ByVal kx As Double, ByVal ky As Double, ByVal phi As Double, ByVal xoffset As Double, ByVal yoffset As Double) As Short
    Friend Declare Function _RTC4_n_load_z_table Lib "RTC4DLL.DLL" Alias "n_load_z_table" (ByVal n As Short, ByVal a As Double, ByVal b As Double, ByVal c As Double) As Short
    Friend Declare Function _RTC4_load_z_table Lib "RTC4DLL.DLL" Alias "load_z_table" (ByVal a As Double, ByVal b As Double, ByVal c As Double) As Short
    Friend Declare Sub _RTC4_n_list_nop Lib "RTC4DLL.DLL" Alias "n_list_nop" (ByVal n As Short)
    Friend Declare Sub _RTC4_list_nop Lib "RTC4DLL.DLL" Alias "list_nop" ()
    Friend Declare Sub _RTC4_n_set_end_of_list Lib "RTC4DLL.DLL" Alias "n_set_end_of_list" (ByVal n As Short)
    Friend Declare Sub _RTC4_set_end_of_list Lib "RTC4DLL.DLL" Alias "set_end_of_list" ()
    Friend Declare Sub _RTC4_n_jump_abs_3d Lib "RTC4DLL.DLL" Alias "n_jump_abs_3d" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_jump_abs_3d Lib "RTC4DLL.DLL" Alias "jump_abs_3d" (ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_n_jump_abs Lib "RTC4DLL.DLL" Alias "n_jump_abs" (ByVal n As Short, ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_jump_abs Lib "RTC4DLL.DLL" Alias "jump_abs" (ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_n_mark_abs_3d Lib "RTC4DLL.DLL" Alias "n_mark_abs_3d" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_mark_abs_3d Lib "RTC4DLL.DLL" Alias "mark_abs_3d" (ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_n_mark_abs Lib "RTC4DLL.DLL" Alias "n_mark_abs" (ByVal n As Short, ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_mark_abs Lib "RTC4DLL.DLL" Alias "mark_abs" (ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_n_jump_rel_3d Lib "RTC4DLL.DLL" Alias "n_jump_rel_3d" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short, ByVal dz As Short)
    Friend Declare Sub _RTC4_jump_rel_3d Lib "RTC4DLL.DLL" Alias "jump_rel_3d" (ByVal dx As Short, ByVal dy As Short, ByVal dz As Short)
    Friend Declare Sub _RTC4_n_jump_rel Lib "RTC4DLL.DLL" Alias "n_jump_rel" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short)
    Friend Declare Sub _RTC4_jump_rel Lib "RTC4DLL.DLL" Alias "jump_rel" (ByVal dx As Short, ByVal dy As Short)
    Friend Declare Sub _RTC4_n_mark_rel_3d Lib "RTC4DLL.DLL" Alias "n_mark_rel_3d" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short, ByVal dz As Short)
    Friend Declare Sub _RTC4_mark_rel_3d Lib "RTC4DLL.DLL" Alias "mark_rel_3d" (ByVal dx As Short, ByVal dy As Short, ByVal dz As Short)
    Friend Declare Sub _RTC4_n_mark_rel Lib "RTC4DLL.DLL" Alias "n_mark_rel" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short)
    Friend Declare Sub _RTC4_mark_rel Lib "RTC4DLL.DLL" Alias "mark_rel" (ByVal dx As Short, ByVal dy As Short)
    Friend Declare Sub _RTC4_n_write_8bit_port_list Lib "RTC4DLL.DLL" Alias "n_write_8bit_port_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_8bit_port_list Lib "RTC4DLL.DLL" Alias "write_8bit_port_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_write_da_1_list Lib "RTC4DLL.DLL" Alias "n_write_da_1_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_1_list Lib "RTC4DLL.DLL" Alias "write_da_1_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_write_da_2_list Lib "RTC4DLL.DLL" Alias "n_write_da_2_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_2_list Lib "RTC4DLL.DLL" Alias "write_da_2_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_matrix_list Lib "RTC4DLL.DLL" Alias "n_set_matrix_list" (ByVal n As Short, ByVal i As Short, ByVal j As Short, ByVal mij As Double)
    Friend Declare Sub _RTC4_set_matrix_list Lib "RTC4DLL.DLL" Alias "set_matrix_list" (ByVal i As Short, ByVal j As Short, ByVal mij As Double)
    Friend Declare Sub _RTC4_n_set_defocus_list Lib "RTC4DLL.DLL" Alias "n_set_defocus_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_set_defocus_list Lib "RTC4DLL.DLL" Alias "set_defocus_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_control_mode_list Lib "RTC4DLL.DLL" Alias "n_set_control_mode_list" (ByVal n As Short, ByVal mode As Short)
    Friend Declare Sub _RTC4_set_control_mode_list Lib "RTC4DLL.DLL" Alias "set_control_mode_list" (ByVal mode As Short)
    Friend Declare Sub _RTC4_n_set_offset_list Lib "RTC4DLL.DLL" Alias "n_set_offset_list" (ByVal n As Short, ByVal xoffset As Short, ByVal yoffset As Short)
    Friend Declare Sub _RTC4_set_offset_list Lib "RTC4DLL.DLL" Alias "set_offset_list" (ByVal xoffset As Short, ByVal yoffset As Short)
    Friend Declare Sub _RTC4_n_long_delay Lib "RTC4DLL.DLL" Alias "n_long_delay" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_long_delay Lib "RTC4DLL.DLL" Alias "long_delay" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_laser_on_list Lib "RTC4DLL.DLL" Alias "n_laser_on_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_laser_on_list Lib "RTC4DLL.DLL" Alias "laser_on_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_jump_speed Lib "RTC4DLL.DLL" Alias "n_set_jump_speed" (ByVal n As Short, ByVal speed As Double)
    Friend Declare Sub _RTC4_set_jump_speed Lib "RTC4DLL.DLL" Alias "set_jump_speed" (ByVal speed As Double)
    Friend Declare Sub _RTC4_n_set_mark_speed Lib "RTC4DLL.DLL" Alias "n_set_mark_speed" (ByVal n As Short, ByVal speed As Double)
    Friend Declare Sub _RTC4_set_mark_speed Lib "RTC4DLL.DLL" Alias "set_mark_speed" (ByVal speed As Double)
    Friend Declare Sub _RTC4_n_set_laser_delays Lib "RTC4DLL.DLL" Alias "n_set_laser_delays" (ByVal n As Short, ByVal ondelay As Short, ByVal offdelay As Short)
    Friend Declare Sub _RTC4_set_laser_delays Lib "RTC4DLL.DLL" Alias "set_laser_delays" (ByVal ondelay As Short, ByVal offdelay As Short)
    Friend Declare Sub _RTC4_n_set_scanner_delays Lib "RTC4DLL.DLL" Alias "n_set_scanner_delays" (ByVal n As Short, ByVal jumpdelay As Short, ByVal markdelay As Short, ByVal polydelay As Short)
    Friend Declare Sub _RTC4_set_scanner_delays Lib "RTC4DLL.DLL" Alias "set_scanner_delays" (ByVal jumpdelay As Short, ByVal markdelay As Short, ByVal polydelay As Short)
    Friend Declare Sub _RTC4_n_set_list_jump Lib "RTC4DLL.DLL" Alias "n_set_list_jump" (ByVal n As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_set_list_jump Lib "RTC4DLL.DLL" Alias "set_list_jump" (ByVal position As Short)
    Friend Declare Sub _RTC4_n_set_input_pointer Lib "RTC4DLL.DLL" Alias "n_set_input_pointer" (ByVal n As Short, ByVal pointer As Short)
    Friend Declare Sub _RTC4_set_input_pointer Lib "RTC4DLL.DLL" Alias "set_input_pointer" (ByVal pointer As Short)
    Friend Declare Sub _RTC4_n_list_call Lib "RTC4DLL.DLL" Alias "n_list_call" (ByVal n As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_list_call Lib "RTC4DLL.DLL" Alias "list_call" (ByVal position As Short)
    Friend Declare Sub _RTC4_n_list_return Lib "RTC4DLL.DLL" Alias "n_list_return" (ByVal n As Short)
    Friend Declare Sub _RTC4_list_return Lib "RTC4DLL.DLL" Alias "list_return" ()
    Friend Declare Sub _RTC4_n_z_out_list Lib "RTC4DLL.DLL" Alias "n_z_out_list" (ByVal n As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_z_out_list Lib "RTC4DLL.DLL" Alias "z_out_list" (ByVal z As Short)
    Friend Declare Sub _RTC4_n_set_standby_list Lib "RTC4DLL.DLL" Alias "n_set_standby_list" (ByVal n As Short, ByVal half_period As Short, ByVal pulse As Short)
    Friend Declare Sub _RTC4_set_standby_list Lib "RTC4DLL.DLL" Alias "set_standby_list" (ByVal half_period As Short, ByVal pulse As Short)
    Friend Declare Sub _RTC4_n_timed_jump_abs Lib "RTC4DLL.DLL" Alias "n_timed_jump_abs" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_timed_jump_abs Lib "RTC4DLL.DLL" Alias "timed_jump_abs" (ByVal x As Short, ByVal y As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_n_timed_mark_abs Lib "RTC4DLL.DLL" Alias "n_timed_mark_abs" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_timed_mark_abs Lib "RTC4DLL.DLL" Alias "timed_mark_abs" (ByVal x As Short, ByVal y As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_n_timed_jump_rel Lib "RTC4DLL.DLL" Alias "n_timed_jump_rel" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_timed_jump_rel Lib "RTC4DLL.DLL" Alias "timed_jump_rel" (ByVal dx As Short, ByVal dy As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_n_timed_mark_rel Lib "RTC4DLL.DLL" Alias "n_timed_mark_rel" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_timed_mark_rel Lib "RTC4DLL.DLL" Alias "timed_mark_rel" (ByVal dx As Short, ByVal dy As Short, ByVal time As Double)
    Friend Declare Sub _RTC4_n_set_laser_timing Lib "RTC4DLL.DLL" Alias "n_set_laser_timing" (ByVal n As Short, ByVal halfperiod As Short, ByVal pulse1 As Short, ByVal pulse2 As Short, ByVal timebase As Short)
    Friend Declare Sub _RTC4_set_laser_timing Lib "RTC4DLL.DLL" Alias "set_laser_timing" (ByVal halfperiod As Short, ByVal pulse1 As Short, ByVal pulse2 As Short, ByVal timebase As Short)
    Friend Declare Sub _RTC4_n_set_wobbel_xy Lib "RTC4DLL.DLL" Alias "n_set_wobbel_xy" (ByVal n As Short, ByVal long_wob As Short, ByVal trans_wob As Short, ByVal frequency As Double)
    Friend Declare Sub _RTC4_set_wobbel_xy Lib "RTC4DLL.DLL" Alias "set_wobbel_xy" (ByVal long_wob As Short, ByVal trans_wob As Short, ByVal frequency As Double)
    Friend Declare Sub _RTC4_n_set_wobbel Lib "RTC4DLL.DLL" Alias "n_set_wobbel" (ByVal n As Short, ByVal amplitude As Short, ByVal frequency As Double)
    Friend Declare Sub _RTC4_set_wobbel Lib "RTC4DLL.DLL" Alias "set_wobbel" (ByVal amplitude As Short, ByVal frequency As Double)
    Friend Declare Sub _RTC4_n_set_fly_x Lib "RTC4DLL.DLL" Alias "n_set_fly_x" (ByVal n As Short, ByVal kx As Double)
    Friend Declare Sub _RTC4_set_fly_x Lib "RTC4DLL.DLL" Alias "set_fly_x" (ByVal kx As Double)
    Friend Declare Sub _RTC4_n_set_fly_y Lib "RTC4DLL.DLL" Alias "n_set_fly_y" (ByVal n As Short, ByVal ky As Double)
    Friend Declare Sub _RTC4_set_fly_y Lib "RTC4DLL.DLL" Alias "set_fly_y" (ByVal ky As Double)
    Friend Declare Sub _RTC4_n_set_fly_rot Lib "RTC4DLL.DLL" Alias "n_set_fly_rot" (ByVal n As Short, ByVal resolution As Double)
    Friend Declare Sub _RTC4_set_fly_rot Lib "RTC4DLL.DLL" Alias "set_fly_rot" (ByVal resolution As Double)
    Friend Declare Sub _RTC4_n_fly_return Lib "RTC4DLL.DLL" Alias "n_fly_return" (ByVal n As Short, ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_fly_return Lib "RTC4DLL.DLL" Alias "fly_return" (ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_n_calculate_fly Lib "RTC4DLL.DLL" Alias "n_calculate_fly" (ByVal n As Short, ByVal direction As Short, ByVal distance As Double)
    Friend Declare Sub _RTC4_calculate_fly Lib "RTC4DLL.DLL" Alias "calculate_fly" (ByVal direction As Short, ByVal distance As Double)
    Friend Declare Sub _RTC4_n_write_io_port_list Lib "RTC4DLL.DLL" Alias "n_write_io_port_list" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_io_port_list Lib "RTC4DLL.DLL" Alias "write_io_port_list" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_select_cor_table_list Lib "RTC4DLL.DLL" Alias "n_select_cor_table_list" (ByVal n As Short, ByVal heada As Short, ByVal headb As Short)
    Friend Declare Sub _RTC4_select_cor_table_list Lib "RTC4DLL.DLL" Alias "select_cor_table_list" (ByVal heada As Short, ByVal headb As Short)
    Friend Declare Sub _RTC4_n_set_wait Lib "RTC4DLL.DLL" Alias "n_set_wait" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_set_wait Lib "RTC4DLL.DLL" Alias "set_wait" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_simulate_ext_start Lib "RTC4DLL.DLL" Alias "n_simulate_ext_start" (ByVal n As Short, ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_simulate_ext_start Lib "RTC4DLL.DLL" Alias "simulate_ext_start" (ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_n_write_da_x_list Lib "RTC4DLL.DLL" Alias "n_write_da_x_list" (ByVal n As Short, ByVal x As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_x_list Lib "RTC4DLL.DLL" Alias "write_da_x_list" (ByVal x As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_pixel_line Lib "RTC4DLL.DLL" Alias "n_set_pixel_line" (ByVal n As Short, ByVal pixelmode As Short, ByVal pixelperiod As Short, ByVal dx As Double, ByVal dy As Double)
    Friend Declare Sub _RTC4_set_pixel_line Lib "RTC4DLL.DLL" Alias "set_pixel_line" (ByVal pixelmode As Short, ByVal pixelperiod As Short, ByVal dx As Double, ByVal dy As Double)
    Friend Declare Sub _RTC4_n_set_pixel Lib "RTC4DLL.DLL" Alias "n_set_pixel" (ByVal n As Short, ByVal pulswidth As Short, ByVal davalue As Short, ByVal adchannel As Short)
    Friend Declare Sub _RTC4_set_pixel Lib "RTC4DLL.DLL" Alias "set_pixel" (ByVal pulswidth As Short, ByVal davalue As Short, ByVal adchannel As Short)
    Friend Declare Sub _RTC4_n_set_extstartpos_list Lib "RTC4DLL.DLL" Alias "n_set_extstartpos_list" (ByVal n As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_set_extstartpos_list Lib "RTC4DLL.DLL" Alias "set_extstartpos_list" (ByVal position As Short)
    Friend Declare Sub _RTC4_n_laser_signal_on_list Lib "RTC4DLL.DLL" Alias "n_laser_signal_on_list" (ByVal n As Short)
    Friend Declare Sub _RTC4_laser_signal_on_list Lib "RTC4DLL.DLL" Alias "laser_signal_on_list" ()
    Friend Declare Sub _RTC4_n_laser_signal_off_list Lib "RTC4DLL.DLL" Alias "n_laser_signal_off_list" (ByVal n As Short)
    Friend Declare Sub _RTC4_laser_signal_off_list Lib "RTC4DLL.DLL" Alias "laser_signal_off_list" ()
    Friend Declare Sub _RTC4_n_set_firstpulse_killer_list Lib "RTC4DLL.DLL" Alias "n_set_firstpulse_killer_list" (ByVal n As Short, ByVal fpk As Short)
    Friend Declare Sub _RTC4_set_firstpulse_killer_list Lib "RTC4DLL.DLL" Alias "set_firstpulse_killer_list" (ByVal fpk As Short)
    Friend Declare Sub _RTC4_n_set_io_cond_list Lib "RTC4DLL.DLL" Alias "n_set_io_cond_list" (ByVal n As Short, ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal mask_set As Short)
    Friend Declare Sub _RTC4_set_io_cond_list Lib "RTC4DLL.DLL" Alias "set_io_cond_list" (ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal mask_set As Short)
    Friend Declare Sub _RTC4_n_clear_io_cond_list Lib "RTC4DLL.DLL" Alias "n_clear_io_cond_list" (ByVal n As Short, ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal mask_clear As Short)
    Friend Declare Sub _RTC4_clear_io_cond_list Lib "RTC4DLL.DLL" Alias "clear_io_cond_list" (ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal mask_clear As Short)
    Friend Declare Sub _RTC4_n_list_jump_cond Lib "RTC4DLL.DLL" Alias "n_list_jump_cond" (ByVal n As Short, ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_list_jump_cond Lib "RTC4DLL.DLL" Alias "list_jump_cond" (ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_n_list_call_cond Lib "RTC4DLL.DLL" Alias "n_list_call_cond" (ByVal n As Short, ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_list_call_cond Lib "RTC4DLL.DLL" Alias "list_call_cond" (ByVal mask_1 As Short, ByVal mask_0 As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_n_save_and_restart_timer Lib "RTC4DLL.DLL" Alias "n_save_and_restart_timer" (ByVal n As Short)
    Friend Declare Sub _RTC4_save_and_restart_timer Lib "RTC4DLL.DLL" Alias "save_and_restart_timer" ()
    Friend Declare Sub _RTC4_n_set_ext_start_delay_list Lib "RTC4DLL.DLL" Alias "n_set_ext_start_delay_list" (ByVal n As Short, ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_set_ext_start_delay_list Lib "RTC4DLL.DLL" Alias "set_ext_start_delay_list" (ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_n_set_trigger Lib "RTC4DLL.DLL" Alias "n_set_trigger" (ByVal n As Short, ByVal sampleperiod As Short, ByVal channel1 As Short, ByVal channel2 As Short)
    Friend Declare Sub _RTC4_set_trigger Lib "RTC4DLL.DLL" Alias "set_trigger" (ByVal sampleperiod As Short, ByVal signal1 As Short, ByVal signal2 As Short)
    Friend Declare Sub _RTC4_n_arc_rel Lib "RTC4DLL.DLL" Alias "n_arc_rel" (ByVal n As Short, ByVal dx As Short, ByVal dy As Short, ByVal angle As Double)
    Friend Declare Sub _RTC4_arc_rel Lib "RTC4DLL.DLL" Alias "arc_rel" (ByVal dx As Short, ByVal dy As Short, ByVal angle As Double)
    Friend Declare Sub _RTC4_n_arc_abs Lib "RTC4DLL.DLL" Alias "n_arc_abs" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal angle As Double)
    Friend Declare Sub _RTC4_arc_abs Lib "RTC4DLL.DLL" Alias "arc_abs" (ByVal x As Short, ByVal y As Short, ByVal angle As Double)
    Friend Declare Sub _RTC4_drilling Lib "RTC4DLL.DLL" Alias "drilling" (ByVal pulsewidth As Short, ByVal relencoderdelay As Short)
    Friend Declare Sub _RTC4_regulation Lib "RTC4DLL.DLL" Alias "regulation" ()
    Friend Declare Sub _RTC4_flyline Lib "RTC4DLL.DLL" Alias "flyline" (ByVal encoderdelay As Short)
    Friend Declare Function _RTC4_n_get_input_pointer Lib "RTC4DLL.DLL" Alias "n_get_input_pointer" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_input_pointer Lib "RTC4DLL.DLL" Alias "get_input_pointer" () As Short
    Friend Declare Sub _RTC4_select_rtc Lib "RTC4DLL.DLL" Alias "select_rtc" (ByVal cardno As Short)
    Friend Declare Function _RTC4_rtc4_count_cards Lib "RTC4DLL.DLL" Alias "rtc4_count_cards" () As Short
    Friend Declare Sub _RTC4_n_get_status Lib "RTC4DLL.DLL" Alias "n_get_status" (ByVal n As Short, ByRef busy As Short, ByRef position As Short)
    Friend Declare Sub _RTC4_get_status Lib "RTC4DLL.DLL" Alias "get_status" (ByRef busy As Short, ByRef position As Short)
    Friend Declare Function _RTC4_n_read_status Lib "RTC4DLL.DLL" Alias "n_read_status" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_read_status Lib "RTC4DLL.DLL" Alias "read_status" () As Short
    Friend Declare Function _RTC4_n_get_startstop_info Lib "RTC4DLL.DLL" Alias "n_get_startstop_info" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_startstop_info Lib "RTC4DLL.DLL" Alias "get_startstop_info" () As Short
    Friend Declare Function _RTC4_n_get_marking_info Lib "RTC4DLL.DLL" Alias "n_get_marking_info" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_marking_info Lib "RTC4DLL.DLL" Alias "get_marking_info" () As Short
    Friend Declare Function _RTC4_get_dll_version Lib "RTC4DLL.DLL" Alias "get_dll_version" () As Short
    Friend Declare Sub _RTC4_n_set_start_list_1 Lib "RTC4DLL.DLL" Alias "n_set_start_list_1" (ByVal n As Short)
    Friend Declare Sub _RTC4_set_start_list_1 Lib "RTC4DLL.DLL" Alias "set_start_list_1" ()
    Friend Declare Sub _RTC4_n_set_start_list_2 Lib "RTC4DLL.DLL" Alias "n_set_start_list_2" (ByVal n As Short)
    Friend Declare Sub _RTC4_set_start_list_2 Lib "RTC4DLL.DLL" Alias "set_start_list_2" ()
    Friend Declare Sub _RTC4_n_set_start_list Lib "RTC4DLL.DLL" Alias "n_set_start_list" (ByVal n As Short, ByVal listno As Short)
    Friend Declare Sub _RTC4_set_start_list Lib "RTC4DLL.DLL" Alias "set_start_list" (ByVal listno As Short)
    Friend Declare Sub _RTC4_n_execute_list_1 Lib "RTC4DLL.DLL" Alias "n_execute_list_1" (ByVal n As Short)
    Friend Declare Sub _RTC4_execute_list_1 Lib "RTC4DLL.DLL" Alias "execute_list_1" ()
    Friend Declare Sub _RTC4_n_execute_list_2 Lib "RTC4DLL.DLL" Alias "n_execute_list_2" (ByVal n As Short)
    Friend Declare Sub _RTC4_execute_list_2 Lib "RTC4DLL.DLL" Alias "execute_list_2" ()
    Friend Declare Sub _RTC4_n_execute_list Lib "RTC4DLL.DLL" Alias "n_execute_list" (ByVal n As Short, ByVal listno As Short)
    Friend Declare Sub _RTC4_execute_list Lib "RTC4DLL.DLL" Alias "execute_list" (ByVal listno As Short)
    Friend Declare Sub _RTC4_n_write_8bit_port Lib "RTC4DLL.DLL" Alias "n_write_8bit_port" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_8bit_port Lib "RTC4DLL.DLL" Alias "write_8bit_port" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_write_io_port Lib "RTC4DLL.DLL" Alias "n_write_io_port" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_io_port Lib "RTC4DLL.DLL" Alias "write_io_port" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_auto_change Lib "RTC4DLL.DLL" Alias "n_auto_change" (ByVal n As Short)
    Friend Declare Sub _RTC4_auto_change Lib "RTC4DLL.DLL" Alias "auto_change" ()
    Friend Declare Sub _RTC4_n_auto_change_pos Lib "RTC4DLL.DLL" Alias "n_auto_change_pos" (ByVal n As Short, ByVal start As Short)
    Friend Declare Sub _RTC4_auto_change_pos Lib "RTC4DLL.DLL" Alias "auto_change_pos" (ByVal start As Short)
    Friend Declare Sub _RTC4_aut_change Lib "RTC4DLL.DLL" Alias "aut_change" ()
    Friend Declare Sub _RTC4_n_start_loop Lib "RTC4DLL.DLL" Alias "n_start_loop" (ByVal n As Short)
    Friend Declare Sub _RTC4_start_loop Lib "RTC4DLL.DLL" Alias "start_loop" ()
    Friend Declare Sub _RTC4_n_quit_loop Lib "RTC4DLL.DLL" Alias "n_quit_loop" (ByVal n As Short)
    Friend Declare Sub _RTC4_quit_loop Lib "RTC4DLL.DLL" Alias "quit_loop" ()
    Friend Declare Sub _RTC4_n_set_list_mode Lib "RTC4DLL.DLL" Alias "n_set_list_mode" (ByVal n As Short, ByVal mode As Short)
    Friend Declare Sub _RTC4_set_list_mode Lib "RTC4DLL.DLL" Alias "set_list_mode" (ByVal mode As Short)
    Friend Declare Sub _RTC4_n_stop_execution Lib "RTC4DLL.DLL" Alias "n_stop_execution" (ByVal n As Short)
    Friend Declare Sub _RTC4_stop_execution Lib "RTC4DLL.DLL" Alias "stop_execution" ()
    Friend Declare Function _RTC4_n_read_io_port Lib "RTC4DLL.DLL" Alias "n_read_io_port" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_read_io_port Lib "RTC4DLL.DLL" Alias "read_io_port" () As UInteger
    Friend Declare Sub _RTC4_n_write_da_1 Lib "RTC4DLL.DLL" Alias "n_write_da_1" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_1 Lib "RTC4DLL.DLL" Alias "write_da_1" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_write_da_2 Lib "RTC4DLL.DLL" Alias "n_write_da_2" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_2 Lib "RTC4DLL.DLL" Alias "write_da_2" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_max_counts Lib "RTC4DLL.DLL" Alias "n_set_max_counts" (ByVal n As Short, ByVal counts As Integer)
    Friend Declare Sub _RTC4_set_max_counts Lib "RTC4DLL.DLL" Alias "set_max_counts" (ByVal counts As Integer)
    Friend Declare Function _RTC4_n_get_counts Lib "RTC4DLL.DLL" Alias "n_get_counts" (ByVal n As Short) As Integer
    Friend Declare Function _RTC4_get_counts Lib "RTC4DLL.DLL" Alias "get_counts" () As Integer
    Friend Declare Sub _RTC4_n_set_matrix Lib "RTC4DLL.DLL" Alias "n_set_matrix" (ByVal n As Short, ByVal m11 As Double, ByVal m12 As Double, ByVal m21 As Double, ByVal m22 As Double)
    Friend Declare Sub _RTC4_set_matrix Lib "RTC4DLL.DLL" Alias "set_matrix" (ByVal m11 As Double, ByVal m12 As Double, ByVal m21 As Double, ByVal m22 As Double)
    Friend Declare Sub _RTC4_n_set_offset Lib "RTC4DLL.DLL" Alias "n_set_offset" (ByVal n As Short, ByVal xoffset As Short, ByVal yoffset As Short)
    Friend Declare Sub _RTC4_set_offset Lib "RTC4DLL.DLL" Alias "set_offset" (ByVal xoffset As Short, ByVal yoffset As Short)
    Friend Declare Sub _RTC4_n_goto_xyz Lib "RTC4DLL.DLL" Alias "n_goto_xyz" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_goto_xyz Lib "RTC4DLL.DLL" Alias "goto_xyz" (ByVal x As Short, ByVal y As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_n_goto_xy Lib "RTC4DLL.DLL" Alias "n_goto_xy" (ByVal n As Short, ByVal x As Short, ByVal y As Short)
    Friend Declare Sub _RTC4_goto_xy Lib "RTC4DLL.DLL" Alias "goto_xy" (ByVal x As Short, ByVal y As Short)
    Friend Declare Function _RTC4_n_get_hex_version Lib "RTC4DLL.DLL" Alias "n_get_hex_version" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_hex_version Lib "RTC4DLL.DLL" Alias "get_hex_version" () As Short
    Friend Declare Sub _RTC4_n_disable_laser Lib "RTC4DLL.DLL" Alias "n_disable_laser" (ByVal n As Short)
    Friend Declare Sub _RTC4_disable_laser Lib "RTC4DLL.DLL" Alias "disable_laser" ()
    Friend Declare Sub _RTC4_n_enable_laser Lib "RTC4DLL.DLL" Alias "n_enable_laser" (ByVal n As Short)
    Friend Declare Sub _RTC4_enable_laser Lib "RTC4DLL.DLL" Alias "enable_laser" ()
    Friend Declare Sub _RTC4_n_stop_list Lib "RTC4DLL.DLL" Alias "n_stop_list" (ByVal n As Short)
    Friend Declare Sub _RTC4_stop_list Lib "RTC4DLL.DLL" Alias "stop_list" ()
    Friend Declare Sub _RTC4_n_restart_list Lib "RTC4DLL.DLL" Alias "n_restart_list" (ByVal n As Short)
    Friend Declare Sub _RTC4_restart_list Lib "RTC4DLL.DLL" Alias "restart_list" ()
    Friend Declare Sub _RTC4_n_get_xyz_pos Lib "RTC4DLL.DLL" Alias "n_get_xyz_pos" (ByVal n As Short, ByRef x As Short, ByRef y As Short, ByRef z As Short)
    Friend Declare Sub _RTC4_get_xyz_pos Lib "RTC4DLL.DLL" Alias "get_xyz_pos" (ByRef x As Short, ByRef y As Short, ByRef z As Short)
    Friend Declare Sub _RTC4_n_get_xy_pos Lib "RTC4DLL.DLL" Alias "n_get_xy_pos" (ByVal n As Short, ByRef x As Short, ByRef y As Short)
    Friend Declare Sub _RTC4_get_xy_pos Lib "RTC4DLL.DLL" Alias "get_xy_pos" (ByRef x As Short, ByRef y As Short)
    Friend Declare Sub _RTC4_n_select_list Lib "RTC4DLL.DLL" Alias "n_select_list" (ByVal n As Short, ByVal list_2 As Short)
    Friend Declare Sub _RTC4_select_list Lib "RTC4DLL.DLL" Alias "select_list" (ByVal list_2 As Short)
    Friend Declare Sub _RTC4_n_z_out Lib "RTC4DLL.DLL" Alias "n_z_out" (ByVal n As Short, ByVal z As Short)
    Friend Declare Sub _RTC4_z_out Lib "RTC4DLL.DLL" Alias "z_out" (ByVal z As Short)
    Friend Declare Sub _RTC4_n_set_firstpulse_killer Lib "RTC4DLL.DLL" Alias "n_set_firstpulse_killer" (ByVal n As Short, ByVal fpk As Short)
    Friend Declare Sub _RTC4_set_firstpulse_killer Lib "RTC4DLL.DLL" Alias "set_firstpulse_killer" (ByVal fpk As Short)
    Friend Declare Sub _RTC4_n_set_standby Lib "RTC4DLL.DLL" Alias "n_set_standby" (ByVal n As Short, ByVal half_period As Short, ByVal pulse As Short)
    Friend Declare Sub _RTC4_set_standby Lib "RTC4DLL.DLL" Alias "set_standby" (ByVal half_period As Short, ByVal pulse As Short)
    Friend Declare Sub _RTC4_n_laser_signal_on Lib "RTC4DLL.DLL" Alias "n_laser_signal_on" (ByVal n As Short)
    Friend Declare Sub _RTC4_laser_signal_on Lib "RTC4DLL.DLL" Alias "laser_signal_on" ()
    Friend Declare Sub _RTC4_n_laser_signal_off Lib "RTC4DLL.DLL" Alias "n_laser_signal_off" (ByVal n As Short)
    Friend Declare Sub _RTC4_laser_signal_off Lib "RTC4DLL.DLL" Alias "laser_signal_off" ()
    Friend Declare Sub _RTC4_n_set_delay_mode Lib "RTC4DLL.DLL" Alias "n_set_delay_mode" (ByVal n As Short, ByVal varpoly As Short, ByVal directmove3d As Short, ByVal edgelevel As Short, ByVal minjumpdelay As Short, ByVal jumplengthlimit As Short)
    Friend Declare Sub _RTC4_set_delay_mode Lib "RTC4DLL.DLL" Alias "set_delay_mode" (ByVal varpoly As Short, ByVal directmove3d As Short, ByVal edgelevel As Short, ByVal minjumpdelay As Short, ByVal jumplengthlimit As Short)
    Friend Declare Sub _RTC4_n_set_piso_control Lib "RTC4DLL.DLL" Alias "n_set_piso_control" (ByVal n As Short, ByVal l1 As Short, ByVal l2 As Short)
    Friend Declare Sub _RTC4_set_piso_control Lib "RTC4DLL.DLL" Alias "set_piso_control" (ByVal l1 As Short, ByVal l2 As Short)
    Friend Declare Sub _RTC4_n_select_status Lib "RTC4DLL.DLL" Alias "n_select_status" (ByVal n As Short, ByVal mode As Short)
    Friend Declare Sub _RTC4_select_status Lib "RTC4DLL.DLL" Alias "select_status" (ByVal mode As Short)
    Friend Declare Sub _RTC4_n_get_encoder Lib "RTC4DLL.DLL" Alias "n_get_encoder" (ByVal n As Short, ByRef zx As Short, ByRef zy As Short)
    Friend Declare Sub _RTC4_get_encoder Lib "RTC4DLL.DLL" Alias "get_encoder" (ByRef zx As Short, ByRef zy As Short)
    Friend Declare Sub _RTC4_n_select_cor_table Lib "RTC4DLL.DLL" Alias "n_select_cor_table" (ByVal n As Short, ByVal heada As Short, ByVal headb As Short)
    Friend Declare Sub _RTC4_select_cor_table Lib "RTC4DLL.DLL" Alias "select_cor_table" (ByVal heada As Short, ByVal headb As Short)
    Friend Declare Sub _RTC4_n_execute_at_pointer Lib "RTC4DLL.DLL" Alias "n_execute_at_pointer" (ByVal n As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_execute_at_pointer Lib "RTC4DLL.DLL" Alias "execute_at_pointer" (ByVal position As Short)
    Friend Declare Function _RTC4_n_get_head_status Lib "RTC4DLL.DLL" Alias "n_get_head_status" (ByVal n As Short, ByVal head As Short) As Short
    Friend Declare Function _RTC4_get_head_status Lib "RTC4DLL.DLL" Alias "get_head_status" (ByVal head As Short) As Short
    Friend Declare Sub _RTC4_n_simulate_encoder Lib "RTC4DLL.DLL" Alias "n_simulate_encoder" (ByVal n As Short, ByVal channel As Short)
    Friend Declare Sub _RTC4_simulate_encoder Lib "RTC4DLL.DLL" Alias "simulate_encoder" (ByVal channel As Short)
    Friend Declare Sub _RTC4_n_set_hi Lib "RTC4DLL.DLL" Alias "n_set_hi" (ByVal n As Short, ByVal galvogainx As Double, ByVal galvogainy As Double, ByVal galvooffsetx As Short, ByVal galvooffsety As Short, ByVal head As Short)
    Friend Declare Sub _RTC4_set_hi Lib "RTC4DLL.DLL" Alias "set_hi" (ByVal galvogainx As Double, ByVal galvogainy As Double, ByVal galvooffsetx As Short, ByVal galvooffsety As Short, ByVal head As Short)
    Friend Declare Sub _RTC4_n_release_wait Lib "RTC4DLL.DLL" Alias "n_release_wait" (ByVal n As Short)
    Friend Declare Sub _RTC4_release_wait Lib "RTC4DLL.DLL" Alias "release_wait" ()
    Friend Declare Function _RTC4_n_get_wait_status Lib "RTC4DLL.DLL" Alias "n_get_wait_status" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_wait_status Lib "RTC4DLL.DLL" Alias "get_wait_status" () As Short
    Friend Declare Sub _RTC4_n_set_control_mode Lib "RTC4DLL.DLL" Alias "n_set_control_mode" (ByVal n As Short, ByVal mode As Short)
    Friend Declare Sub _RTC4_set_control_mode Lib "RTC4DLL.DLL" Alias "set_control_mode" (ByVal mode As Short)
    Friend Declare Sub _RTC4_n_set_laser_mode Lib "RTC4DLL.DLL" Alias "n_set_laser_mode" (ByVal n As Short, ByVal mode As Short)
    Friend Declare Sub _RTC4_set_laser_mode Lib "RTC4DLL.DLL" Alias "set_laser_mode" (ByVal mode As Short)
    Friend Declare Sub _RTC4_n_set_ext_start_delay Lib "RTC4DLL.DLL" Alias "n_set_ext_start_delay" (ByVal n As Short, ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_set_ext_start_delay Lib "RTC4DLL.DLL" Alias "set_ext_start_delay" (ByVal delay As Short, ByVal encoder As Short)
    Friend Declare Sub _RTC4_n_home_position Lib "RTC4DLL.DLL" Alias "n_home_position" (ByVal n As Short, ByVal xhome As Short, ByVal yhome As Short)
    Friend Declare Sub _RTC4_home_position Lib "RTC4DLL.DLL" Alias "home_position" (ByVal xhome As Short, ByVal yhome As Short)
    Friend Declare Sub _RTC4_n_set_rot_center Lib "RTC4DLL.DLL" Alias "n_set_rot_center" (ByVal n As Short, ByVal center_x As Integer, ByVal center_y As Integer)
    Friend Declare Sub _RTC4_set_rot_center Lib "RTC4DLL.DLL" Alias "set_rot_center" (ByVal center_x As Integer, ByVal center_y As Integer)
    Friend Declare Sub _RTC4_n_dsp_start Lib "RTC4DLL.DLL" Alias "n_dsp_start" (ByVal n As Short)
    Friend Declare Sub _RTC4_dsp_start Lib "RTC4DLL.DLL" Alias "dsp_start" ()
    Friend Declare Sub _RTC4_n_write_da_x Lib "RTC4DLL.DLL" Alias "n_write_da_x" (ByVal n As Short, ByVal x As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_write_da_x Lib "RTC4DLL.DLL" Alias "write_da_x" (ByVal x As Short, ByVal value As Short)
    Friend Declare Function _RTC4_n_read_ad_x Lib "RTC4DLL.DLL" Alias "n_read_ad_x" (ByVal n As Short, ByVal x As Short) As Short
    Friend Declare Function _RTC4_read_ad_x Lib "RTC4DLL.DLL" Alias "read_ad_x" (ByVal x As Short) As Short
    Friend Declare Function _RTC4_n_read_pixel_ad Lib "RTC4DLL.DLL" Alias "n_read_pixel_ad" (ByVal n As Short, ByVal pos As Short) As Short
    Friend Declare Function _RTC4_read_pixel_ad Lib "RTC4DLL.DLL" Alias "read_pixel_ad" (ByVal pos As Short) As Short
    Friend Declare Function _RTC4_n_get_z_distance Lib "RTC4DLL.DLL" Alias "n_get_z_distance" (ByVal n As Short, ByVal x As Short, ByVal y As Short, ByVal z As Short) As Short
    Friend Declare Function _RTC4_get_z_distance Lib "RTC4DLL.DLL" Alias "get_z_distance" (ByVal x As Short, ByVal y As Short, ByVal z As Short) As Short
    Friend Declare Function _RTC4_n_get_io_status Lib "RTC4DLL.DLL" Alias "n_get_io_status" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_io_status Lib "RTC4DLL.DLL" Alias "get_io_status" () As Short
    Friend Declare Function _RTC4_n_get_time Lib "RTC4DLL.DLL" Alias "n_get_time" (ByVal n As Short) As Double
    Friend Declare Function _RTC4_get_time Lib "RTC4DLL.DLL" Alias "get_time" () As Double
    Friend Declare Sub _RTC4_n_set_defocus Lib "RTC4DLL.DLL" Alias "n_set_defocus" (ByVal n As Short, ByVal value As Short)
    Friend Declare Sub _RTC4_set_defocus Lib "RTC4DLL.DLL" Alias "set_defocus" (ByVal value As Short)
    Friend Declare Sub _RTC4_n_set_softstart_mode Lib "RTC4DLL.DLL" Alias "n_set_softstart_mode" (ByVal n As Short, ByVal mode As Short, ByVal number As Short, ByVal restartdelay As Short)
    Friend Declare Sub _RTC4_set_softstart_mode Lib "RTC4DLL.DLL" Alias "set_softstart_mode" (ByVal mode As Short, ByVal number As Short, ByVal resetdelay As Short)
    Friend Declare Sub _RTC4_n_set_softstart_level Lib "RTC4DLL.DLL" Alias "n_set_softstart_level" (ByVal n As Short, ByVal index As Short, ByVal level As Short)
    Friend Declare Sub _RTC4_set_softstart_level Lib "RTC4DLL.DLL" Alias "set_softstart_level" (ByVal index As Short, ByVal level As Short)
    Friend Declare Sub _RTC4_n_control_command Lib "RTC4DLL.DLL" Alias "n_control_command" (ByVal n As Short, ByVal head As Short, ByVal axis As Short, ByVal data As Short)
    Friend Declare Sub _RTC4_control_command Lib "RTC4DLL.DLL" Alias "control_command" (ByVal head As Short, ByVal axis As Short, ByVal data As Short)
    Friend Declare Function _RTC4_load_cor Lib "RTC4DLL.DLL" Alias "load_cor" (ByVal filename As String) As Short
    Friend Declare Function _RTC4_load_pro Lib "RTC4DLL.DLL" Alias "load_pro" (ByVal filename As String) As Short
    Friend Declare Function _RTC4_n_get_serial_number Lib "RTC4DLL.DLL" Alias "n_get_serial_number" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_serial_number Lib "RTC4DLL.DLL" Alias "get_serial_number" () As Short
    Friend Declare Function _RTC4_n_get_rtc_version Lib "RTC4DLL.DLL" Alias "n_get_rtc_version" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_rtc_version Lib "RTC4DLL.DLL" Alias "get_rtc_version" () As Short
    Friend Declare Sub _RTC4_get_hi_data Lib "RTC4DLL.DLL" Alias "get_hi_data" (ByRef x1 As Short, ByRef x2 As Short, ByRef y1 As Short, ByRef y2 As Short)
    'UPGRADE_NOTE: command 升級為 command_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Friend Declare Function _RTC4_n_auto_cal Lib "RTC4DLL.DLL" Alias "n_auto_cal" (ByVal n As Short, ByVal head As Short, ByVal command_Renamed As Short) As Short
    'UPGRADE_NOTE: command 升級為 command_Renamed。 按一下以取得詳細資訊: 'ms-help://MS.VSCC.v90/dv_commoner/local/redirect.htm?keyword="A9E4979A-37FA-4718-9994-97DD76ED70A7"'
    Friend Declare Function _RTC4_auto_cal Lib "RTC4DLL.DLL" Alias "auto_cal" (ByVal head As Short, ByVal command_Renamed As Short) As Short
    Friend Declare Function _RTC4_n_get_list_space Lib "RTC4DLL.DLL" Alias "n_get_list_space" (ByVal n As Short) As Short
    Friend Declare Function _RTC4_get_list_space Lib "RTC4DLL.DLL" Alias "get_list_space" () As Short
    Friend Declare Function _RTC4_teachin Lib "RTC4DLL.DLL" Alias "teachin" (ByVal filename As String, ByVal xin As Short, ByVal yin As Short, ByVal zin As Short, ByVal ll0 As Double, ByRef xout As Short, ByRef yout As Short, ByRef zout As Short) As Short
    Friend Declare Function _RTC4_n_get_value Lib "RTC4DLL.DLL" Alias "n_get_value" (ByVal n As Short, ByVal signal As Short) As Short
    Friend Declare Function _RTC4_get_value Lib "RTC4DLL.DLL" Alias "get_value" (ByVal signal As Short) As Short
    Friend Declare Sub _RTC4_n_set_io_bit Lib "RTC4DLL.DLL" Alias "n_set_io_bit" (ByVal n As Short, ByVal mask1 As Short)
    Friend Declare Sub _RTC4_set_io_bit Lib "RTC4DLL.DLL" Alias "set_io_bit" (ByVal mask1 As Short)
    Friend Declare Sub _RTC4_n_clear_io_bit Lib "RTC4DLL.DLL" Alias "n_clear_io_bit" (ByVal n As Short, ByVal mask0 As Short)
    Friend Declare Sub _RTC4_clear_io_bit Lib "RTC4DLL.DLL" Alias "clear_io_bit" (ByVal mask0 As Short)
    Friend Declare Sub _RTC4_set_duty_cycle_table Lib "RTC4DLL.DLL" Alias "set_duty_cycle_table" (ByVal index As Short, ByVal dutycycle As Short)
    Friend Declare Sub _RTC4_n_move_to Lib "RTC4DLL.DLL" Alias "n_move_to" (ByVal n As Short, ByVal position As Short)
    Friend Declare Sub _RTC4_move_to Lib "RTC4DLL.DLL" Alias "move_to" (ByVal position As Short)
#End Region
End Class
Public Class CLaser
    Inherits CRTC4

#Region "Member"
    ''' <summary>
    ''' the signal from the arm sends the request to open the laser. 
    ''' 手臂發出的信號發送打開雷射
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PIN_INPUT As Integer = 0

    ''' <summary>
    ''' The signal from this machine sends to the arm that the burning is finished.
    ''' 該機器發出的信號發送到手臂通知完成
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PIN_OUTPUT As Integer = 0

    Private Shared m_DeviceStatus As String = "0"
    Private Shared m_CalibrationK As Double
    Private Shared m_HwCriticalError As Boolean
    Private Shared m_SwRunTimeError As Boolean
    Private Shared m_ErrMessage As String
    Private Const MCI_Protocol_Wait_Time As Int32 = 50
    Private m_SerialPortLaser As System.IO.Ports.SerialPort
    Private m_Timer As CHighResolutionTimer
    Private m_MinX As Double
    Private m_MinY As Double
    Private m_MaxX As Double
    Private m_MaxY As Double
#End Region
#Region "Property"
    
    Public ReadOnly Property CalibrationK As Double
        Get
            Return m_CalibrationK
        End Get
    End Property

    Public Property HwCriticalError() As Boolean
        Get
            Return m_HwCriticalError
        End Get
        Set(ByVal value As Boolean)
            m_HwCriticalError = value
        End Set
    End Property
    Public Property SwRunTimeError() As Boolean
        Get
            Return m_SwRunTimeError
        End Get
        Set(ByVal value As Boolean)
            m_SwRunTimeError = value
        End Set
    End Property
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property
    Public ReadOnly Property DeviceID() As String
        Get

            Dim buffer(0 To 3) As Byte
            Dim rtnBuf(0 To 200) As Byte
            Dim s As String
            Dim ss() As String
            s = ""
            buffer(0) = Asc("$")
            buffer(1) = Asc("1")
            buffer(2) = Asc(";")
            buffer(3) = &HD
            m_SerialPortLaser.Write(buffer, 0, 4)
            Thread.Sleep(MCI_Protocol_Wait_Time)
            m_SerialPortLaser.Read(rtnBuf, 0, 200)
            ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "1;")
            s = ss(1)
            Return s

        End Get
    End Property
    Public ReadOnly Property DeviceSN() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("2")
                buffer(2) = Asc(";")
                buffer(3) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "2;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property FWRevision() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
               
                buffer(0) = Asc("$")
                buffer(1) = Asc("3")
                buffer(2) = Asc(";")
                buffer(3) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "3;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property Vendor() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String = ""
                Dim ss() As String
                s = ""
               
                buffer(0) = Asc("$")
                buffer(1) = Asc("9")
                buffer(2) = Asc("9")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "99;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property

    Private Sub DeviceError(ByVal stateInfo As Object)
        Try
            Dim buffer(0 To 4) As Byte
            Dim rtnBuf(0 To 200) As Byte
            Dim s As String = ""
            Dim ss() As String
            s = ""
            
            buffer(0) = Asc("$")
            buffer(1) = Asc("4")
            buffer(2) = Asc(";")
            buffer(3) = &HD
            m_SerialPortLaser.Write(buffer, 0, 4)
            Thread.Sleep(10)
            m_SerialPortLaser.Read(rtnBuf, 0, 50)
            ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "4;")
            If UBound(ss) = 1 AndAlso ss(0) = "" Then
                m_DeviceStatus = ss(1)
            End If

        Catch ex As Exception
            m_DeviceStatus = "0"
        Finally
        End Try
    End Sub

    Public ReadOnly Property DeviceStatus() As String
        Get
            Call DeviceError("")
            'System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf DeviceError), "")
            Return m_DeviceStatus
        End Get
    End Property
    Public ReadOnly Property DeviceTemperature() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("5")
                buffer(2) = Asc(";")
                buffer(3) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "5;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property ExtendedStatus() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("1")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "11;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property BRCounter() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("2")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "12;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property SessionBRCounter() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("3")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "13;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property NominalAveragePower() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("4")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "14;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property NominalPulseDuration() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("5")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "15;")
                s = ss(1) 'ns
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property NominalPulseEnergy() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("6")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "16;")
                s = ss(1)
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property NominalPeakPower() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("7")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "17;")
                s = ss(1)
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property PRRRange() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("1")
                buffer(2) = Asc("8")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "18;")
                s = ss(1)
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property OperatingPulseEnergy() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("3")
                buffer(2) = Asc("6")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "36;")
                s = ss(1)
                    
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property ElapsedTime() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String = ""
                s = ""
                
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    ''' <summary>
    ''' 雷射工作頻率KHz
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PRR() As String
        Get
            Try
                Dim buffer(0 To 5) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("2")
                buffer(2) = Asc("9")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "29;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
        Set(ByVal value As String)
            Try
                Dim buffer(0 To 20) As Byte
                Dim i As Int32
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("2")
                buffer(2) = Asc("8")
                buffer(3) = Asc(";")
                For i = 1 To value.Length
                    buffer(3 + i) = CByte(Asc(Mid(value, i, 1)))
                Next
                buffer(3 + i) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4 + i)

            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 雷射啟用(進啟用雷射尚未實際打出雷射)
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property LaserEmission() As Boolean
        Set(ByVal value As Boolean)
            Try
                Dim buffer(0 To 6) As Byte
                
                If value Then
                    buffer(0) = Asc("$")
                    buffer(1) = Asc("3")
                    buffer(2) = Asc("0")
                    buffer(3) = Asc(";")
                Else
                    buffer(0) = Asc("$")
                    buffer(1) = Asc("3")
                    buffer(2) = Asc("1")
                    buffer(3) = Asc(";")
                End If
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)

                    
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 雷射工作功率 %
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OperatingPower() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("3")
                buffer(2) = Asc("4")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "34;")
                s = ss(1)
                    
                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
        Set(ByVal value As String)
            Try
                Dim buffer(0 To 20) As Byte
                Dim i As Int32
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("3")
                buffer(2) = Asc("2")
                buffer(3) = Asc(";")
                For i = 1 To value.Length
                    buffer(3 + i) = CByte(Asc(Mid(value, i, 1)))
                Next
                buffer(3 + i) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4 + i)

            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    Private m_LaserGuide As Boolean
    ''' <summary>
    ''' 雷射導引紅光開關
    ''' </summary>
    ''' <value>
    ''' </value>
    ''' <remarks>
    ''' </remarks>
    Public Property LaserGuide() As Boolean
        Get
            Return m_LaserGuide
        End Get
        Set(ByVal value As Boolean)
            Try
                m_LaserGuide = value
                Dim buffer(0 To 4) As Byte

                If value Then
                    buffer(0) = Asc("$")
                    buffer(1) = Asc("4")
                    buffer(2) = Asc("0")
                    buffer(3) = Asc(";")
                Else
                    buffer(0) = Asc("$")
                    buffer(1) = Asc("4")
                    buffer(2) = Asc("1")
                    buffer(3) = Asc(";")
                End If
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)

            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 錯誤重置
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property ResetAlarms() As Boolean
        Set(ByVal value As Boolean)
            Try
                Dim buffer(0 To 5) As Byte
                
                If value Then
                    buffer(0) = Asc("$")
                    buffer(1) = Asc("5")
                    buffer(2) = Asc("0")
                    buffer(3) = Asc(";")
                    buffer(4) = &HD
                    m_SerialPortLaser.Write(buffer, 0, 5)
                Else
                End If

            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    Public Property PulseDuration() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("4")
                buffer(2) = Asc("8")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "48;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
        Set(ByVal value As String)
            Try
                Dim buffer(0 To 20) As Byte
                Dim i As Int32
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("4")
                buffer(2) = Asc("9")
                buffer(3) = Asc(";")
                For i = 1 To value.Length
                    buffer(3 + i) = CByte(Asc(Mid(value, i, 1)))
                Next
                buffer(3 + i) = &HD
                m_SerialPortLaser.Write(buffer, 0, 4 + i)

            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    Public ReadOnly Property ListofPulseDurations() As String
        Get
            Try
                Dim buffer(0 To 4) As Byte
                Dim rtnBuf(0 To 200) As Byte
                Dim s As String = ""
                Dim ss() As String
                s = ""
                
                buffer(0) = Asc("$")
                buffer(1) = Asc("5")
                buffer(2) = Asc("1")
                buffer(3) = Asc(";")
                buffer(4) = &HD
                m_SerialPortLaser.Write(buffer, 0, 5)
                Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Read(rtnBuf, 0, 200)
                ss = Split(System.Text.Encoding.UTF8.GetString(rtnBuf), "51;")
                s = ss(1)

                Return s
            Catch ex As Exception
                m_SwRunTimeError = True
                m_ErrMessage = ex.Message.ToString()
                Return ""
            Finally
            End Try
        End Get
    End Property
    Public ReadOnly Property IsOpen As Boolean
        Get
            Try
                Return m_SerialPortLaser.IsOpen
            Catch ex As Exception
                Return False
            End Try
        End Get
    End Property
    
    Public ReadOnly Property MinX As Double
        Get
            Return m_MinX
        End Get
    End Property
    Public ReadOnly Property MinY As Double
        Get
            Return m_MinY
        End Get
    End Property
    Public ReadOnly Property MaxX As Double
        Get
            Return m_MaxX
        End Get
    End Property
    Public ReadOnly Property MaxY As Double
        Get
            Return m_MaxY
        End Get
    End Property
#End Region

#Region "Methods"
    Public Sub New(ByRef Param As CParam, ByRef pTimer As CHighResolutionTimer)
        Dim errCode As Int32
        Dim edgelevel As Short
        Dim rotationalAngleInRad As Double
        Try
            m_Timer = pTimer
            m_HwCriticalError = False
            m_SwRunTimeError = False
            m_ErrMessage = ""




            m_SerialPortLaser = New System.IO.Ports.SerialPort
            With m_SerialPortLaser
                .PortName = "COM1"
                .BaudRate = 57600
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Parity = IO.Ports.Parity.None
                If m_SerialPortLaser.IsOpen Then
                    m_HwCriticalError = True
                    m_ErrMessage = "通訊埠已被其他程式占用!! 請關閉運行程式後再執行"
                Else
                    Call .Open()
                    .ReadTimeout = 100
                    LaserGuide = False
                    LaserEmission = False

                    '1.Download the correction file(s) to the RTC4.
                    '2.Download DSP program file. The RTC4 signal processor starts automatically after this command.
                    '3.Set the laser mode
                    '4.Assign the correction file(s) to the scan head control port(s) if necessary
                    '5.Define the scanner delay mode
                    '6.Load a table for the variable polygon delay if necessary
                    '7.Set the FirstPulseKiller length(YAG only)
                    '8.Set the stand-by pulses(usually CO2 only)
                    '9.Load the list(s)
                    '10.Enable the external start input if necessary

                    '1~~
                    errCode = _RTC4_load_correction_file("C:\\RTC4 Files\\D2_263.ctb", 1, -1.0, -1.0, 0.0, 0.0, 0.0)
                    '2~~~
                    errCode = _RTC4_load_program_file("C:\\RTC4 Files\\RTC4D2.hex")
                    '3~~
                    rotationalAngleInRad = (Param.Variable.Laser.Angle) * Math.PI / 180
                    Call _RTC4_set_laser_mode(4)
                    'Call _RTC4_set_matrix(Math.Cos(rotationalAngleInRad), Math.Sin(rotationalAngleInRad), Math.Sin(rotationalAngleInRad), Math.Cos(rotationalAngleInRad)) '逆時針轉90度
                    Call _RTC4_set_matrix(Math.Sin(rotationalAngleInRad), Math.Cos(rotationalAngleInRad), -1 * Math.Cos(rotationalAngleInRad), Math.Sin(rotationalAngleInRad))
                    Call _RTC4_set_offset(Param.Variable.Laser.OffsetX, Param.Variable.Laser.OffsetY)
                    '4~~
                    '5~~
                    edgelevel = 2 'CShort(61 / 10)
                    Call _RTC4_set_delay_mode(0, 1, edgelevel, 0, 0)
                    '6~~
                    'Call load_varpolydelay("C:\\RTC4 Files\\VariablePolygonDelay20130305", 1)
                    'Call control_command(1, 1, &H1101)
                    'Call control_command(1, 2, &H1101)
                    '8~~
                    '9~~
                    '10~~
                    '
                    Call SetFirstPulseKiller(Param.Variable.Laser.GalvanometerFpk)
                    Call HomePosition(0, 0)
                    Call setstartlist(1)
                    Call setScannerDelays(Param.Time.Laser.JumpDelay10MicroSecond, Param.Time.Laser.MarkDelay10MicroSecond, Param.Time.Laser.PolygonDelay10MicroSecond)
                    Call SetLaserDelays(Param.Time.Laser.LaserOnDelayMicroSecond, Param.Time.Laser.LaserOffDelayMicroSecond)
                    Call SetJumpSpeed(Param.Speed.Laser.GalvanometerJumpSpeed)
                    Call SetMarkSpeed(Param.Speed.Laser.GalvanometerMarkSpeed)
                    Call SetEndofList()
                    Call ExecuteList(1)
                    Call LaserSignalOFF()

                End If
            End With

        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
        Call LoadMaxMin()
    End Sub
    Private Sub LoadMaxMin()
        Try
            If (System.IO.File.Exists("C:\\RTC4 Files\\D2_263.ctb.txt")) Then
                Dim strLines() As String = System.IO.File.ReadAllLines("C:\\RTC4 Files\\D2_263.ctb.txt")
                Dim tmp() As String = strLines(10).Split("="c)
                m_MinX = CDbl(tmp(1))
                tmp = strLines(11).Split("="c)
                m_MaxX = CDbl(tmp(1))
                tmp = strLines(12).Split("="c)
                m_MinY = CDbl(tmp(1))
                tmp = strLines(13).Split("="c)
                m_MaxY = CDbl(tmp(1))

                tmp = strLines(6).Split(" "c)
                Dim k As Integer = 0
                If (Integer.TryParse(tmp(1), k)) Then
                    m_CalibrationK = k
                Else
                    m_CalibrationK = 820
                End If
            Else
                m_MinX = -100.0
                m_MinY = -100.0
                m_MaxX = 100.0
                m_MaxY = 100.0
                m_CalibrationK = 820
            End If
        Catch ex As Exception
            m_MinX = -100.0
            m_MinY = -100.0
            m_MaxX = 100.0
            m_MaxY = 100.0
            m_CalibrationK = 820
        End Try
    End Sub

    Protected Overrides Sub Finalize()
        Try
            Call m_SerialPortLaser.Close()
        Catch ex As Exception
            Debug.Assert(False)
        Finally
        End Try
        MyBase.Finalize()
    End Sub

    Public Function AutoCal(ByVal Head As Short, ByVal Command As Short) As Short
        Try
            System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf AutoCalibration), Command)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
        Return 0
    End Function

    Private Sub AutoCalibration(ByVal stateInfo As Object)
        Try
            
            Dim err As Short
            Dim commamd As Short
            commamd = CShort(stateInfo)
            err = _RTC4_auto_cal(1, commamd)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub


    '1.LaserOffDelay > LaserOnDelay
    '2.MarkDelay > LaserOffDelay- LaserOnDelay
    '3.edgelevel > LaserOffDelay - LaserOnDelay
    Public Sub LaserSignalON()
        Try
            
            Call _RTC4_laser_signal_on()
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub LaserSignalOFF()
        Try
            Call _RTC4_laser_signal_off()
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub setstartlist(ByVal ListNo As Int32)
        Try
            
            Dim ListNo2 As Short
            ListNo2 = CShort(ListNo)
            Call _RTC4_set_start_list(ListNo2)
            '_RTC4_save_and_restart_timer()
            '_RTC4_set_trigger(1, 1, 2)

        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub JumpAbs(ByVal X As Int32, ByVal Y As Int32)
        Try
           
            Dim xbit As Short
            Dim ybit As Short
            xbit = CShort(X)  ' + offset_X '* m_CalibrationK)
            ybit = CShort(Y)  '* m_CalibrationK)
            Call _RTC4_jump_abs(xbit, ybit)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    Public Sub MarkAbs(ByVal X As Int32, ByVal Y As Int32)
        Try
            
            Dim xbit As Short
            Dim ybit As Short
            xbit = CShort(X)  ' * m_CalibrationK)
            ybit = CShort(Y)  '* m_CalibrationK)
            Call _RTC4_mark_abs(xbit, ybit)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    Public Sub ArcAbs(ByVal X As Int32, ByVal Y As Int32, ByVal Angle As Double)
        Try
            
            Dim xbit As Short
            Dim ybit As Short
            xbit = CShort(X)  '* m_CalibrationK)
            ybit = CShort(Y)  '* m_CalibrationK)
            Call _RTC4_arc_abs(xbit, ybit, Angle)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    Public Sub LongDelay(ByVal DelayInMs As Double)
        Try
            
            Dim delayTime As Short
            delayTime = CShort(DelayInMs * 1000 / 10)
            Call _RTC4_long_delay(delayTime)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Function ListExecutionFinish() As Boolean
        ListExecutionFinish = False
        Try
            Dim busy As Short
            Dim position As Short
            Call _RTC4_get_status(busy, position)
            If busy = 0 Then
                ListExecutionFinish = True
            Else
                ListExecutionFinish = False
            End If
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Function
    Public Sub SetEndofList()
        Try
            
            'Call _RTC4_save_and_restart_timer()
            Call _RTC4_set_end_of_list()
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub ExecuteList(ByVal ListNo As Int32)
        Try
            
            Dim ListNo2 As Short
            ListNo2 = CShort(ListNo)
            Call _RTC4_execute_list(ListNo2)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub StopExecute()
        Try
            Call _RTC4_stop_execution()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub setScannerDelays(ByVal JumpDelay As Int32, ByVal MarkDelay As Int32, ByVal PolyDelay As Int32)
        Try
            
            Dim jump As Short
            Dim mark As Short
            Dim poly As Short
            jump = CShort(JumpDelay / 10)
            mark = CShort(MarkDelay / 10)
            poly = CShort(PolyDelay / 10)
            Call _RTC4_set_scanner_delays(jump, mark, poly)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub SetLaserDelays(ByVal OnDelay As Int32, ByVal OffDelay As Int32)
        Try
            
            Dim laserONDelay As Short
            Dim laserOFFDelay As Short
            laserONDelay = CShort(OnDelay)
            laserOFFDelay = CShort(OffDelay)
            Call _RTC4_set_laser_delays(laserONDelay, laserOFFDelay)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub SetJumpSpeed(ByVal Speed As Double)
        Try
            
            Call _RTC4_set_jump_speed(Speed)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub SetMarkSpeed(ByVal Speed As Double)
        Try
            
            Call _RTC4_set_mark_speed(Speed)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub HomePosition(ByVal XHome As Int32, ByVal YHome As Int32)
        Try
            
            Dim xHome2 As Short
            Dim yHome2 As Short
            xHome2 = CShort(XHome)
            yHome2 = CShort(YHome)
            Call _RTC4_home_position(xHome2, yHome2)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub SetFirstPulseKiller(ByVal Fpk As Int32)
        Try
            
            Dim fpk2 As Short
            fpk2 = CShort(Fpk * 8)
            Call _RTC4_set_firstpulse_killer(fpk2)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub SetLaserMode(ByVal Mode As enumLaserMode)
        Try
            
            Dim laserMode1 As Short
            laserMode1 = CShort(Mode)
            Call _RTC4_set_laser_mode(laserMode1)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    Public Sub LoadProgramFile(ByVal Name As String)
        Try
            
            Call _RTC4_load_program_file(Name)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    Public Sub LoadCorrectionFile(ByVal Filename As String, ByVal Cortable As Int32, ByVal Kx As Double, ByVal Ky As Double, ByVal Phi As Double, ByVal XOffset As Double, ByVal YOffset As Double)
        Try
            
            Dim corTableNo1 As Short
            corTableNo1 = CShort(Cortable)
            Dim err = _RTC4_load_correction_file(Filename, corTableNo1, Kx, Ky, Phi, XOffset, YOffset)
            LoadMaxMin()
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    ''' <summary>
    ''' Rotation coordinate by the angle 
    ''' </summary>
    ''' <param name="Angle">Angle in degree</param>
    ''' <remarks></remarks>
    Public Sub SetAngle(ByVal Angle As Double)
        Try
            Dim rotationalAngleInRad As Double = Angle * Math.PI / 180
            Call _RTC4_set_matrix(Math.Cos(rotationalAngleInRad), -1 * Math.Sin(rotationalAngleInRad), Math.Sin(rotationalAngleInRad), Math.Cos(rotationalAngleInRad)) '逆時針轉90度
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Defines an offset in the X and Y directions which will be added to all subsequent vector outputs
    ''' </summary>
    ''' <param name="OffsetX">Offset X in bits. Allowed range: [ – 32768 …+32767]</param>
    ''' <param name="OffsetY">Offset Y in bits. Allowed range: [ – 32768 …+32767]</param>
    ''' <remarks></remarks>
    Public Sub SetOffset(ByVal OffsetX As Short, ByVal OffsetY As Short)
        Try
            Call _RTC4_set_offset(OffsetX, OffsetY)
        Catch ex As Exception
        End Try
    End Sub
    Public Sub CloseSerial()
        Try
            m_SerialPortLaser.Close()
        Catch ex As Exception

        End Try
    End Sub
    Public Function OpenSerial() As Boolean
        Try
            If (m_SerialPortLaser.IsOpen = False) Then m_SerialPortLaser.Open()
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub SetPRR(ByVal Hz As Integer)
        Dim period As Short
        Dim halfperiod As Short
        Dim pulseWidthperiod As Short
        Try
            'If Hz >= 2000 Then Hz = 2000

            period = CShort(1000 / Hz * 1000)
            halfperiod = CShort(period / 2)
            pulseWidthperiod = CShort(period * 0.1)
            If (m_OperatingPower > 80) Then
                'Duty Max 10%

            ElseIf (m_OperatingPower > 65) Then
                ' Duty Max 12% P: 65%~80%
                pulseWidthperiod = CShort(period * 0.12)
                If pulseWidthperiod <= 50 Then pulseWidthperiod = 50
                If pulseWidthperiod >= 10000 Then pulseWidthperiod = 10000
            ElseIf (m_OperatingPower > 50) Then
                ' Duty Max 15%  P: 50%~65%
                pulseWidthperiod = CShort(period * 0.15)
                If pulseWidthperiod <= 50 Then pulseWidthperiod = 50
                If pulseWidthperiod >= 10000 Then pulseWidthperiod = 10000
            End If
            'If pulseWidthperiod >= 50 Then pulseWidthperiod = 50
            Call _RTC4_set_laser_timing(period, pulseWidthperiod, pulseWidthperiod, 0)

        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub
    ''' <summary>
    ''' 0% ~ 100%
    ''' </summary>
    ''' <remarks></remarks>
    Private m_OperatingPower As Double
    Public Sub SetOperatingPower(ByVal Perc As Integer)
        Dim bitPec As Short

        Try
            m_OperatingPower = Perc / 10
            bitPec = CShort(406 * Perc / 1000)
            Call _RTC4_write_da_x_list(1, bitPec)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        Finally
        End Try
    End Sub

    Public Sub DigitialOutSet(ByVal pPin As Integer, ByVal pStatus As Boolean)
        Try
            Dim pResult As Short
            pResult = _RTC4_get_io_status()
            Dim Bit2 As String = Convert.ToString(pResult, 2).PadLeft(16, "0")
            Dim BitResult As String = ""

            For i = 0 To 15
                If (15 - i = pPin) Then
                    If (pStatus) Then
                        BitResult &= "1"
                    Else
                        BitResult &= "0"
                    End If
                Else
                    BitResult &= Bit2(i)
                End If
            Next
            Dim pValue As Short = Convert.ToInt16(BitResult, 2)
            Call _RTC4_write_io_port(pValue)
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        End Try

    End Sub


    Public Sub DigitialInGet(ByVal pPin As Integer, ByRef pStatus As Boolean)
        Try
            Dim pResult As UShort
            pResult = _RTC4_read_io_port()
            Dim Bit2 As String = Convert.ToString(pResult, 2).PadLeft(16, "0")
            Dim BitCheckStr As String = (Bit2(16 - 1 - pPin))
            If BitCheckStr = "1" Then
                pStatus = True
            Else
                pStatus = False
            End If
        Catch ex As Exception
            m_SwRunTimeError = True
            m_ErrMessage = ex.Message.ToString()
            Debug.Assert(False)
        End Try

    End Sub

    Public Function ReadInputPortStatus() As UShort
        Try
            Return _RTC4_read_io_port()
        Catch ex As Exception
            Return 0
        End Try
    End Function

    Public Function ReadOutputPortStatus() As Short
        Try
            Return _RTC4_get_io_status()
        Catch ex As Exception
            Return 0
        End Try
    End Function
#End Region
End Class