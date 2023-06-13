Option Explicit On
Imports Timer
Imports System.Threading

Friend Class CAdlink785X
#Region "Error Const"
    Protected Const ERR_No_Error As Short = 0
    Protected Const ERR_Board_No_Init As Short = 1
    Protected Const ERR_Invalid_Board_Number As Short = 2
    Protected Const ERR_PCI_Bios_Not_Exist As Short = 3
    Protected Const ERR_Open_Driver_Fail As Short = 4
    Protected Const ERR_Memory_Mapping As Short = 5
    Protected Const ERR_Connect_Index As Short = 6
    Protected Const ERR_Satellite_Number As Short = 7
    Protected Const ERR_Count_Number As Short = 8
    Protected Const ERR_Satellite_Type As Short = 9
    Protected Const ERR_Not_ADLink_Slave_Type As Short = 10
    Protected Const ERR_Channel_Number As Short = 11
    Protected Const ERR_Over_Max_Address As Short = 12
    Protected Const ERR_AI_Range As Short = 13
    Protected Const ERR_AI_Signal_Type As Short = 14
    Protected Const ERR_AI_CJC_Status As Short = 15
    Protected Const ERR_CJC_Direction As Short = 16
    Protected Const ERR_Time_Out As Short = 17
    Protected Const ERR_Create_Timer As Short = 18
    Protected Const ERR_PID_Create_Failed As Short = 19
    Protected Const ERR_PID_Start_Failed As Short = 20
    Protected Const ERR_PID_No_Output As Short = 21
    Protected Const ERR_PID_No_FeedBack As Short = 22
    Protected Const ERR_No_PID_Controller As Short = 23
    Protected Const ERR_Logic_Input As Short = 24
    Protected Const ERR_OS_Unknown As Short = 25
    Protected Const ERR_AI16AO2_Signal_Range As Short = 26
    Protected Const ERR_AI16AO2_Read As Short = 27
    Protected Const ERR_AI16AO2_Last_Channel As Short = 28
    Protected Const ERR_AI16AO2_Set_Data As Short = 29
    Protected Const ERR_AI16AO2_Read_Signal_Type As Short = 30
    Protected Const ERR_AO_Channel_Input As Short = 31
    Protected Const ERR_AI_Channel_Input As Short = 32
    Protected Const ERR_DA_Channel_Input As Short = 33
    Protected Const ERR_Over_Voltage_Spec As Short = 34
    Protected Const ERR_File_Open_Fail As Short = 35
    Protected Const ERR_TrimDAC_Channel As Short = 36
    Protected Const ERR_Over_Current_Spec As Short = 37
    Protected Const ERR_Axis_Out_Of_Range As Short = 38
    Protected Const ERR_Send_Motion_Command As Short = 39
    Protected Const ERR_Read_Motion_HexFile As Short = 40
    Protected Const ERR_Flash_Data_Transfer As Short = 41
    Protected Const ERR_Unkown_Data_Type As Short = 42
    Protected Const ERR_CheckSum As Short = 43
    Protected Const ERR_Point_Index As Short = 44
    Protected Const ERR_DI_Channel_Input As Short = 45
    Protected Const ERR_DO_Channel_Output As Short = 46
    Protected Const ERR_No_GCode As Short = 47
    Protected Const ERR_Code_Syntax As Short = 48
    Protected Const ERR_Read_GC_TexTFile As Short = 49
    Protected Const ERR_No_Motion_Module As Short = 50
    Protected Const ERR_Owner_Set As Short = 51
    Protected Const ERR_Signal_Notify As Short = 52
    Protected Const ERR_Communication_Type_Range As Short = 53
    Protected Const ERR_Transfer_Rate As Short = 54
    Protected Const ERR_Hub_Number As Short = 55
    Protected Const ERR_Slave_Number As Short = 56
    Protected Const ERR_Slave_Not_Stop As Short = 57
    Protected Const ERR_Link_Status As Short = 58
    Protected Const ERR_Counter_Failed As Short = 59
    Protected Const ERR_Create_Event_Failed As Short = 60
    Protected Const ERR_DI_Renewal_Type As Short = 61
    Protected Const ERR_Wait_Di_Interrupt As Short = 62
    Protected Const ERR_Di_Event_Open_Already As Short = 63
    Protected Const ERR_Di_Event_Disable As Short = 64
    Protected Const ERR_Timer_Parameter As Short = 65
    Protected Const ERR_Close_Timer As Short = 66
    Protected Const ERR_Wait_Timer_Interrupt As Short = 67
    Protected Const ERR_AO_Data As Short = 68
    Protected Const ERR_Flash_Write_In As Short = 69
    Protected Const ERR_Motion_Busy As Short = 70
    Protected Const ERR_Motion_abnormal_stop As Short = 71
    Protected Const ERR_Di_Latch_time As Short = 72
    Protected Const ERR_Set_Di_Latch_Failed As Short = 73
    Protected Const ERR_Parameters_invalid As Short = 74
    Protected Const ERR_LinkIntError As Short = 75
    Protected Const ERR_HomeALL_Mode As Short = 76
#End Region

#Region "HSL Prototype"

    Protected Sub New()
        ' TODO: Complete member initialization 
    End Sub

    Protected Declare Function HSL_initial Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function HSL_close Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function HSL_auto_start Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function HSL_start Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal max_slave_No As Short) As Short
    Protected Declare Function HSL_stop Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function HSL_connect_status Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef sts_data As Short) As Short
    Protected Declare Function HSL_slave_live Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef live_data As Short) As Short
    Protected Declare Function HSL_get_irq_channel Lib "HSL.dll" (ByVal card_ID As Short, ByRef irq_no As Short) As Object
    Protected Declare Function HSL_initial_without_reset Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function HSL_auto_start_without_reset Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function HSL_start_without_reset Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal max_slave_No As Short) As Short
    Protected Declare Function HSL_set_timer Lib "HSL.dll" (ByVal card_ID As Short, ByVal c1 As Short, ByVal c2 As Short) As Short
    Protected Declare Function HSL_enable_timer_interrupt Lib "HSL.dll" (ByVal card_ID As Short, ByRef phEvent As Integer) As Short
    Protected Declare Function HSL_disable_timer_interrupt Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function HSL_set_int_timer Lib "HSL.dll" (ByVal card_ID As Short, ByVal c1 As Short) As Short
    Protected Declare Function HSL_set_int_timer_enable Lib "HSL.dll" (ByVal card_ID As Short, ByVal Enable As Short) As Short
    Protected Declare Function HSL_wait_timer_interrupt Lib "HSL.dll" (ByVal card_ID As Short, ByVal time_out_ms As Integer) As Short
    Protected Declare Function HSL_set_scan_condition Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal comm_type As Short, ByVal transfer_rate As Short, ByVal hub_number As Short) As Short
    Protected Declare Function HSL_get_scan_condition Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByRef comm_type As Short, ByRef transfer_rate As Short, ByRef hub_number As Short) As Short
    Protected Declare Function HSL_D_write_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal out_data As Integer) As Short
    Protected Declare Function HSL_D_write_channel_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByVal out_data As Short) As Short
    Protected Declare Function HSL_D_read_input Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef in_data As Integer) As Short
    Protected Declare Function HSL_D_read_channel_input Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef in_data As Short) As Short
    Protected Declare Function HSL_D_read_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef out_data_in_ram As Integer) As Short
    Protected Declare Function HSL_D_read_all_slave_input Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByRef in_data As Short) As Short
    Protected Declare Function HSL_D_write_all_slave_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByRef out_data As Short) As Short
    Protected Declare Function HSL_D_set_input_logic Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Input_Logic As Short) As Short
    Protected Declare Function HSL_D_set_output_logic Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Output_Logic As Short) As Short
    Protected Declare Function HSL_D_write_slave_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal out_data As Short) As Short
    Protected Declare Function HSL_D_read_slave_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef data_out As Short) As Short
    Protected Declare Function HSL_D_read_slave_input Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef data_in As Short) As Short
    Protected Declare Function HSL_D_set_int_renewal_type Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal renewal_type As Short) As Short
    Protected Declare Function HSL_D_set_int_renewal_bit Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal bitsOfCheck As Short) As Short
    Protected Declare Function HSL_D_set_int_control Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal Enable As Short) As Short
    Protected Declare Function HSL_D_wait_di_interrupt Lib "HSL.dll" (ByVal card_ID As Short, ByVal time_out_ms As Integer) As Short
    Protected Declare Function HSL_A_start_read Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function HSL_A_stop_read Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function HSL_A_set_signal_range Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal signal_range As Short) As Short
    Protected Declare Function HSL_A_get_signal_range Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef signal_range As Short) As Short
    Protected Declare Function HSL_A_get_input_mode Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef Mode As Short) As Short
    Protected Declare Function HSL_A_set_last_channel Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Last_Channel As Short) As Short
    Protected Declare Function HSL_A_get_last_channel Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef Last_Channel As Short) As Short
    Protected Declare Function HSL_A_read_input Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double) As Short
    Protected Declare Function HSL_A_write_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
    Protected Declare Function HSL_A_read_output Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ao_channel As Short, ByRef AO_data As Double) As Short
    Protected Declare Function HSL_A_sync_rw Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
    Protected Declare Function HSL_A_get_version Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef Ver As Short) As Short
    Protected Declare Function HSL_set_keep_mode Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Mode As Short) As Short
    Protected Declare Function HSL_D_write_channel_output_SP Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByVal out_data As Short) As Short
    Protected Declare Function HSL_A_AIO_scan_mode Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Enable As Short) As Short
    Protected Declare Function HSL_A_AIO_scan_mode Lib "HSL.dll" (ByVal card_ID As Integer, ByVal connect_index As Integer, ByVal slave_No As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function HSL_A_AIO_scan Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function HSL_A_AIO_scan Lib "HSL.dll" (ByVal card_ID As Integer, ByVal connect_index As Integer, ByVal slave_No As Integer) As Integer
    Protected Declare Function HSL_A_write_output_i Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
    Protected Declare Function HSL_A_read_output_i Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ao_channel As Short, ByRef AO_data As Double) As Short
    Protected Declare Function HSL_A_read_input_i Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double) As Short
    Protected Declare Function HSL_A_sync_rw_i Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal ai_channel As Short, ByRef AI_data As Double, ByVal ao_channel As Short, ByVal AO_data As Double) As Short
    Protected Declare Function W_HSL_Initial Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function W_HSL_Close Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function W_HSL_Auto_Start Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function W_HSL_Start Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal max_slave_No As Short) As Short
    Protected Declare Function W_HSL_Stop Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function W_HSL_Connect_Status Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef sts_data As Byte) As Short
    Protected Declare Function W_HSL_Slave_Live Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef live_data As Byte) As Short
    Protected Declare Function W_HSL_Software_Reset Lib "HSL.dll" (ByVal card_ID As Short) As Object
    Protected Declare Function W_HSL_Get_IRQ_Channel Lib "HSL.dll" (ByVal card_ID As Short, ByRef irq_no As Short) As Object
    Protected Declare Function W_HSL_DIO_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef in_data As Integer) As Short
    Protected Declare Function W_HSL_DIO_Channel_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef in_data As Short) As Short
    Protected Declare Function W_HSL_DIO_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal out_data As Integer) As Short
    Protected Declare Function W_HSL_DIO_Channel_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByVal out_data As Short) As Short
    Protected Declare Function W_HSL_DI8DO8_DIO_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef in_data As Short) As Short
    Protected Declare Function W_HSL_DI8DO8_DIO_Channel_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef in_data As Short) As Short
    Protected Declare Function W_HSL_DI8DO8_DIO_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal out_data As Short) As Short
    Protected Declare Function W_HSL_DI8DO8_DIO_Channel_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByVal out_data As Short) As Short
    Protected Declare Function W_HSL_Read_DIO_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef out_data_in_ram As Integer) As Short
    Protected Declare Function W_HSL_Read_DIO_Channel_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef out_channel_data_in_ram As Short) As Short
    Protected Declare Function W_HSL_Read_DI8DO8_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef out_data_in_ram As Short) As Short
    Protected Declare Function W_HSL_Read_DI8DO8_Channel_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef out_channel_data_in_ram As Short) As Short
    Protected Declare Function W_HSL_Set_In_Out_Logic Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Input_Logic As Short, ByVal Output_Logic As Short) As Short
    Protected Declare Function W_HSL_AI_Start_Read Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function W_HSL_AI_Stop_Read Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short) As Short
    Protected Declare Function W_HSL_AI_Channel_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByRef AI_data As Double) As Short
    Protected Declare Function W_HSL_AI_SetConfig Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal signal_range As Short, ByVal signal_type As Short, ByVal cjc_status As Short) As Short
    Protected Declare Function W_HSL_AI_GetConfig Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef signal_range As Short, ByRef signal_type As Short, ByRef cjc_status As Short) As Short
    Protected Declare Function W_HSL_AI_OffsetCalib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function W_HSL_AI_SpanCalib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function W_HSL_AI_WriteDefault Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function W_HSL_AI_SetCJCOffset Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal CJC_data2 As Double) As Short
    Protected Declare Function W_HSL_AI_GetCJCOffset Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef CJC_data As Double) As Short
    Protected Declare Function W_HSL_AI_SetChannelStatus Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal enable_chans As Integer) As Short
    Protected Declare Function W_HSL_AI_GetChannelStatus Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef enable_chans As Integer) As Short
    Protected Declare Function W_HSL_Timer_Set Lib "HSL.dll" (ByVal card_ID As Short, ByVal c1 As Short, ByVal c2 As Short) As Short
    Protected Declare Function W_HSL_TMRINT_Enable Lib "HSL.dll" (ByVal card_ID As Short, ByRef phEvent As Integer) As Short
    Protected Declare Function W_HSL_TMRINT_Disable Lib "HSL.dll" (ByVal card_ID As Short) As Short
    Protected Declare Function W_HSL_DIO_Memory_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByRef data_in As Short) As Short
    Protected Declare Function W_HSL_DIO_Memory_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByRef data_out As Short) As Short
    Protected Declare Function W_HSL_AI_Set_Last_Channel Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal Last_Channel As Short) As Short
    Protected Declare Function W_HSL_AI_Get_Last_Channel Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef Last_Channel As Short) As Short
    Protected Declare Function W_HSL_AI_Get_Version Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByRef Ver As Byte) As Short
    Protected Declare Function W_HSL_AIO_LoadConfig Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function W_HSL_AIO_SaveConfig Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short) As Short
    Protected Declare Function W_HSL_AO_Channel_Out Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal AO_Ch_No As Short, ByVal AO_data As Double) As Short
    Protected Declare Function W_HSL_AIO_Channel_InOut Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal AI_CH_No As Short, ByRef AI_data As Double, ByVal AO_Ch_No As Short, ByVal AO_data As Double) As Short
    Protected Declare Function W_HSL_AO_Channel_In Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal AO_Ch_No As Short, ByRef AO_data As Short) As Short
    Protected Declare Function W_HSL_AO_OffsetCalib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal DA_CH As Short) As Short
    Protected Declare Function W_HSL_AO_GainCalib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal DA_CH As Short) As Short
    Protected Declare Function W_HSL_TC08_Offset_Calib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short) As Short
    Protected Declare Function W_HSL_TC08_Span_Calib Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short) As Short
    Protected Declare Function W_HSL_TC08_Get_Temperature Lib "HSL.dll" (ByVal card_ID As Short, ByVal connect_index As Short, ByVal slave_No As Short, ByVal channel As Short, ByVal TC_type As Short, ByRef Temperature As Double) As Short
#End Region

End Class
Friend Class CAdlink785XDI
    Inherits CAdlink785X
    Private m_DI() As CDIBased
    Friend Sub New(ByRef pDI() As CDIBased)
        Dim card_ID As Short = -1
        Dim connectIndex As Short = -1
        Dim slaveNo As Short = -1
        Dim rtnCode As Short = 0
        Dim HSL_ModuleIsDie As Short
        Dim ModuleStatus As Short
        Try
            m_DI = pDI
            HSL_ModuleIsDie = 0
            ModuleStatus = 0
            For idx As Integer = 0 To (UBound(pDI) - 1)
                If pDI(idx).CardID > card_ID Then
                    card_ID = card_ID + 1
                    rtnCode = HSL_close(card_ID)
                    rtnCode = HSL_initial(card_ID)
                    If Not (rtnCode = ERR_No_Error) Then    ''///判斷卡是否存在
                        Call MsgBox("HSL_initial Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                        Exit Sub
                    End If
                End If
            Next
            For idx As Integer = 0 To (UBound(pDI) - 1)
                If pDI(idx).ConnectIndex > connectIndex Then
                    card_ID = pDI(idx).CardID
                    connectIndex = connectIndex + 1
                    slaveNo = pDI(idx).SlaveID
                    rtnCode = HSL_stop(card_ID, pDI(idx).ConnectIndex)
                    rtnCode = HSL_set_scan_condition(card_ID, pDI(idx).ConnectIndex, 1, 2, 0) '/* ONLY FOR 7853/54) */

                    rtnCode = HSL_auto_start(card_ID, pDI(idx).ConnectIndex)
                    If Not (rtnCode = ERR_No_Error) Then
                        Call MsgBox("HSL_start Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                        Exit Sub
                        'Else
                        '    If slaveNo = 0 Then
                        '        Call MsgBox("HSL_start Fail,Error No Slave Device", MsgBoxStyle.Information, "CAdlink785XDI->New")
                        '        Exit Sub
                        '    End If
                    End If
                End If
            Next
            For idx As Integer = 0 To (UBound(pDI) - 1)
                card_ID = pDI(idx).CardID
                connectIndex = pDI(idx).ConnectIndex
                slaveNo = pDI(idx).SlaveID
                rtnCode = HSL_slave_live(card_ID, connectIndex, slaveNo, ModuleStatus)
                If Not (rtnCode = ERR_No_Error) Then
                    Call MsgBox("HSL_slave_live Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                    Exit Sub
                Else
                    If ModuleStatus = HSL_ModuleIsDie Then
                        Call MsgBox("HSL_slave_live Fail,Error " & slaveNo & "Not Connected", MsgBoxStyle.Information, "CAdlink785XDI->New")
                        Exit Sub
                    End If
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Unexpected Error")
        Finally
        End Try
    End Sub
    Friend Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Dim card_ID As Short
        Dim connect_index As Short
        Dim slave_No As Short
        Dim channel As Short
        Dim inData As Short
        Dim rtnCode As Short
        Dim HSL_ModuleIsDie As Short = 0
        pStatus = False
        Try
            'Read back discrete I/O by channel selection
            card_ID = m_DI(SnrIdx).CardID
            connect_index = m_DI(SnrIdx).ConnectIndex
            slave_No = m_DI(SnrIdx).SlaveID
            channel = m_DI(SnrIdx).BitID

            ''tom
            ''rtnCode = HSL_slave_live(card_ID, connect_index, slave_No, ModuleStatus)
            ''If Not (rtnCode = ERR_No_Error) Then
            ''    Call MsgBox("HSL_slave_live Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
            ''    Exit Sub
            ''Else
            ''    If ModuleStatus = HSL_ModuleIsDie Then
            ''        Call MsgBox("HSL_slave_live Fail,Error " & slave_No & "Not Connected", MsgBoxStyle.Information, "CAdlink785XDI->New")
            ''        Exit Sub
            ''    End If
            ''End If

            rtnCode = HSL_D_read_channel_input(card_ID, connect_index, slave_No, channel, inData)
            If rtnCode = ERR_No_Error Then
                If (inData And &H1) = &H1 Then
                    If m_DI(SnrIdx).Logic Then
                        pStatus = True
                    Else
                        pStatus = False
                    End If
                Else
                    If m_DI(SnrIdx).Logic Then
                        pStatus = False
                    Else
                        pStatus = True
                    End If
                End If
            Else
                MsgBox("Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->CheckSensorSts")
            End If
        Catch ex As Exception
            MsgBox("Unexpected Error" & ex.ToString, MsgBoxStyle.Critical, "CAdlink785XDI->CheckSensorSts")
        Finally
        End Try
    End Sub
End Class
Friend Class CAdlink785XDO
    Inherits CAdlink785X
    Private m_DO() As CDOBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_DoCtrl As Automation.BDaq.InstantDoCtrl
    Friend Sub New(ByRef pDO() As CDOBased)
        Dim card_ID As Short = -1
        Dim connectIndex As Short = -1
        Dim slaveNo As Short = -1
        Dim rtnCode As Short = 0
        Dim HSL_ModuleIsDie As Short
        Dim ModuleStatus As Short
        Try
            m_DO = pDO
            m_Timer = New CHighResolutionTimer
            HSL_ModuleIsDie = 0
            ModuleStatus = 0
            For idx As Integer = 0 To (UBound(pDO) - 1)
                If (idx = 168 Or idx = 169 Or 185) Then
                    Continue For
                End If
                card_ID = pDO(idx).CardIDAction
                connectIndex = pDO(idx).ConnectIndexAction

                'rtnCode = HSL_auto_start(card_ID, connectIndex)
                'If rtnCode <> 0 Then
                '    MsgBox("Start Card Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                'End If

                slaveNo = pDO(idx).SlaveIDAction
                rtnCode = HSL_slave_live(card_ID, connectIndex, slaveNo, ModuleStatus)
                If Not (rtnCode = ERR_No_Error) Then
                    Call MsgBox("HSL_slave_live Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                    Exit Sub
                Else
                    If ModuleStatus = HSL_ModuleIsDie Then
                        Call MsgBox("HSL_slave_live Fail,Error " & slaveNo & "Not Connected", MsgBoxStyle.Information, "CAdlink785XDI->New")
                        Exit Sub
                    End If
                End If
                'card_ID = pDO(idx).CardIDAction
                'connectIndex = pDO(idx).ConnectIndexAction
                'slaveNo = pDO(idx).SlaveIDAction
                'rtnCode = HSL_slave_live(card_ID, connectIndex, slaveNo, ModuleStatus)
                'If Not (rtnCode = ERR_No_Error) Then
                '    Call MsgBox("HSL_slave_live Fail,Error" & rtnCode, MsgBoxStyle.Information, "CAdlink785XDI->New")
                '    Exit Sub
                'Else
                '    If ModuleStatus = HSL_ModuleIsDie Then
                '        Call MsgBox("HSL_slave_live Fail,Error " & slaveNo & "Not Connected", MsgBoxStyle.Information, "CAdlink785XDI->New")
                '        Exit Sub
                '    End If
                'End If
            Next
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Unexpected Error")
        Finally
        End Try
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CylIdx"></param>
    ''' <param name="Status"></param>
    ''' <remarks>
    ''' 0-> Action Close Normal Open
    ''' 1-> Action Close Normal Close
    ''' 2-> Action Open  Normal Close
    ''' </remarks>
    Friend Sub CylGo(ByVal CylIdx As Integer, ByVal Status As enumCyllogic)
        Dim cardId As Short
        Dim connectIndex As Short
        Dim slaveId As Short
        Dim bitId As Short
        Dim rtnCode As Short = 0
        Dim outData As Short
        Dim errCode As Automation.BDaq.ErrorCode = 0
        Select Case Status
            Case enumCyllogic.Normal
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                connectIndex = m_DO(CylIdx).ConnectIndexAction : slaveId = m_DO(CylIdx).SlaveIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                connectIndex = m_DO(CylIdx).ConnectIndexNormal : slaveId = m_DO(CylIdx).SlaveIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 1
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                If m_DO(CylIdx).Status = enumCyllogic.Normal Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.Normal
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If

            Case enumCyllogic.CloseAll
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                connectIndex = m_DO(CylIdx).ConnectIndexAction : slaveId = m_DO(CylIdx).SlaveIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                connectIndex = m_DO(CylIdx).ConnectIndexNormal : slaveId = m_DO(CylIdx).SlaveIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                If m_DO(CylIdx).Status = enumCyllogic.CloseAll Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.CloseAll
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If

            Case enumCyllogic.Action
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                connectIndex = m_DO(CylIdx).ConnectIndexAction : slaveId = m_DO(CylIdx).SlaveIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 1
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                connectIndex = m_DO(CylIdx).ConnectIndexNormal : slaveId = m_DO(CylIdx).SlaveIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = HSL_D_write_channel_output(cardId, connectIndex, slaveId, bitId, outData)
                    If Not (rtnCode = ERR_No_Error) Then
                    End If
                End If
                If m_DO(CylIdx).Status = enumCyllogic.Action Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.Action
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If
        End Select
    End Sub
End Class
