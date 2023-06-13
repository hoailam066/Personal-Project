Option Strict On
Option Explicit On
Imports System.Runtime.InteropServices
Imports System.Threading
Imports Timer

Friend Class CAdlinkAMP204Base
    ' Initial option
    Protected Const INIT_AUTO_CARD_ID As Short = &H0S           '    ' (Bit 0) CardId assigned by system, Input parameter of APS_initial( cardId, "MODE" )
    Protected Const INIT_MANUAL_ID As Short = &H1S              '    ' (Bit 0) CardId manual by dip switch, Input parameter of APS_initial( cardId, "MODE" )
    Protected Const INIT_PARAM_IGNORE As Short = &H0S           '    ' (Bit 4-5) Load parameter method - ignore, keep current value
    Protected Const INIT_PARAM_LOAD_DEFAULT As Short = &H10S    '    ' (Bit 4-5) Load parameter method - load parameter as default value 
    Protected Const INIT_PARAM_LOAD_FLASH As Short = &H20S      '    ' (Bit 4-5) Load parameter method - load parameter from flash memory
    Protected Const INIT_MNET_INTERRUPT As Short = &H40         ' (Bit 6) Enable MNET interrupt mode. (Support motion interrupt for MotionNet series)

    ' Board parameter define (General
    Protected Const PRB_EMG_LOGIC As Short = &H0S ' Board EMG logic

    Protected Const PRB_DO_LOGIC As Short = &H14S '//DO logic, 0: no invert; 1: invert  
    Protected Const PRB_DI_LOGIC As Short = &H15S     '//DI logic, 0: no invert; 1: invert


    Protected Const MHS_GET_SERVO_OFF_INFO As Short = &H16S
    Protected Const MHS_RESET_SERVO_OFF_INFO As Short = &H17S
    Protected Const MHS_GET_ALL_STATE As Short = &H18S

    Protected Const PRB_WDT0_VALUE As Short = &H10S ' Set / Get watch dog limit.
    Protected Const PRB_WDT0_COUNTER As Short = &H11S ' Reset Wdt / Get Wdt_Count_Value
    Protected Const PRB_WDT0_UNIT As Short = &H12S ' wdt_unit
    Protected Const PRB_WDT0_ACTION As Short = &H13S ' wdt_action

    Protected Const PRA_HOME_VA As Short = &H16S  'homing approach velocity [PCI-8253/56 only]
    Protected Const PRA_HOME_SHIFT As Short = &H17S ' The shift from ORG [PCI-8254/58 only]
    Protected Const PRA_HOME_EZA As Short = &H18S ' EZ alignment enable
    Protected Const PRA_HOME_VO As Short = &H19 ' Homing leave ORG velocity
    Protected Const PRA_HOME_OFFSET As Short = &H1AS ' The escape pulse amounts(Leaving home by position)
    Protected Const PRA_HOME_POS As Short = &H1BS 'The position from ORG [PCI-8254/58 only]

    Protected Const PRB_TMR0_BASE As Short = &H20S ' Set TMR Value
    Protected Const PRB_TMR0_VALUE As Short = &H21S ' Get timer int count value

    Protected Const PRA_CURVE As Short = &H20S '// Move curve pattern
    Protected Const PRA_SF As Short = &H20S '// Move s-factor
    Protected Const PRA_ACC As Short = &H21S '// Move acceleration
    Protected Const PRA_DEC As Short = &H22S '// Move deceleration
    Protected Const PRA_VS As Short = &H23S '// Move start velocity
    Protected Const PRA_VM As Short = &H24S '// Move max velocity
    Protected Const PRA_VE As Short = &H25S '// Move end velocity
    Protected Const PRA_SACC As Short = &H26S '// S curve acceleration
    Protected Const PRA_SDEC As Short = &H27S '// S curve deceleration
    Protected Const PRA_ACC_SR As Short = &H28S '// S curve ratio in acceleration( S curve with linear acceleration)
    Protected Const PRA_DEC_SR As Short = &H29S '// S curve ratio in deceleration( S curve with linear deceleration)

    Protected Const PRA_PRE_EVENT_DIST As Short = &H2AS 'Pre-event distance
    Protected Const PRA_POST_EVENT_DIST As Short = &H2BS 'Post-event distance

    '//following only for V2...
    Protected Const PRA_DIST As Short = &H30S  '// Move distance
    Protected Const PRA_MAX_VELOCITY As Short = &H31S  '// Maximum velocity
    Protected Const PRA_SCUR_PERCENTAGE As Short = &H32S  '// Scurve percentage
    Protected Const PRA_BLENDING_MODE As Short = &H33S  '// Blending mode
    Protected Const PRA_STOP_MODE As Short = &H34S  '// Stop mode
    Protected Const PRA_STOP_DELRATE As Short = &H35S  '// Stop function deceleration rate

    Protected Const PRA_PT_STOP_ENDO As Short = &H32S  '// Disable do when point table stopping.
    Protected Const PRA_PT_STP_DO_EN As Short = &H32S  '// Disable do when point table stopping.
    Protected Const PRA_PT_STOP_DO As Short = &H33S  '// Set do value when point table stopping.
    Protected Const PRA_PT_STP_DO As Short = &H33S  '// Set do value when point table stopping.
    Protected Const PRA_PWM_OFF As Short = &H34S  '// Disable specified PWM output when ASTP input signal is active.
    Protected Const PRA_DO_OFF As Short = &H35S  '// Set DO value when ASTP input signal is active.

    Protected Const PRB_SYS_TMP_MONITOR As Short = &H30S ' Get system temperature monitor data
    Protected Const PRB_CPU_TMP_MONITOR As Short = &H31S ' Get CPU temperature monitor data
    Protected Const PRB_AUX_TMP_MONITOR As Short = &H32S ' Get AUX temperature monitor data

    Protected Const PRB_UART_MULTIPLIER As Short = &H40S ' Set UART Multiplier

    Protected Const PRA_JG_STEP As Short = &H46S '// Jog offset (For step mode)
    Protected Const PRA_JG_DELAY As Short = &H47S '// Jog delay (For step mode)
    Protected Const PRA_JG_MAP_DI_EN As Short = &H48 '// (I32) Enable Digital input map to jog command signal
    Protected Const PRA_JG_P_JOG_DI As Short = &H49S '// (I32) Mapping configuration for positive jog and digital input.
    Protected Const PRA_JG_N_JOG_DI As Short = &H4AS '// (I32) Mapping configuration for negative jog and digital input.
    Protected Const PRA_JG_JOG_DI As Short = &H4BS '// (I32) Mapping configuration for jog and digital input.

    Protected Const PRA_MDN_DELAY As Short = &H50S '// NSTP delay setting
    Protected Const PRA_SINP_WDW As Short = &H51S '// Soft INP window setting
    Protected Const PRA_SINP_STBL As Short = &H52S '// Soft INP stable cycle
    Protected Const PRA_SINP_STBT As Short = &H52S '// Soft INP stable cycle
    Protected Const PRA_SERVO_LOGIC As Short = &H53S '//  SERVO logic

    Protected Const PRA_GEAR_MASTER As Short = &H60S '// (I32) Select gearing master
    Protected Const PRA_GEAR_ENGAGE_RATE As Short = &H61S '// (F64) Gear engage rate
    Protected Const PRA_GEAR_RATIO As Short = &H62S '// (F64) Gear ratio
    Protected Const PRA_GANTRY_PROTECT_1 As Short = &H63S '// (F64) E-gear gantry mode protection level 1
    Protected Const PRA_GANTRY_PROTECT_2 As Short = &H64S '// (F64) E-gear gantry mode protection level 2
    Protected Const PRA_MOVE_RATIO As Short = &H88S       '//Move ratio

    'Protected Const _PRA_EGEAR As Short = &H84S '8253/6 use this para as unit factor, but 8258 use 0x86. 
    Protected Const PRA_ENCODER_DIR As Short = &H85S '(I32) 
    Protected Const PRA_POS_UNIT_FACTOR As Short = &H86S '(F64) position unit factor setting

    Protected Const PRB_PSR_MODE As Short = &H90S ' Config pulser mode
    Protected Const PRB_PSR_EA_LOGIC As Short = &H91S ' Set EA inverted
    Protected Const PRB_PSR_EB_LOGIC As Short = &H92S ' Set EB inverted

    ' Board parameter define (For PCI-8253/56
    Protected Const PRB_DENOMINATOR As Short = &H80S ' Floating number denominator
    'Protected Const  PRB_PSR_MODE          =&H90  ' Config pulser mode
    Protected Const PRB_PSR_ENABLE As Short = &H91S ' Enable/disable pulser mode
    Protected Const PRB_BOOT_SETTING As Short = &H100S ' Load motion parameter method when DSP boot

    Protected Const PRB_PWM0_MAP_DO As Integer = &H110S  '// Enable & Map PWM0 to Do channels
    Protected Const PRB_PWM1_MAP_DO As Integer = &H111S  '// Enable & Map PWM1 to Do channels
    Protected Const PRB_PWM2_MAP_DO As Integer = &H112S  '// Enable & Map PWM2 to Do channels
    Protected Const PRB_PWM3_MAP_DO As Integer = &H113S  '// Enable & Map PWM3 to Do channels

    Protected Const PRA_D_SAMPLE_TIME As Short = &H12CS '(I32) Derivative Sample Time

    Protected Const PRA_BIQUAD0_A1 As Short = &H132S '(F64) Biquad filter0 coefficient A1
    Protected Const PRA_BIQUAD0_A2 As Short = &H133S '(F64) Biquad filter0 coefficient A2
    Protected Const PRA_BIQUAD0_B0 As Short = &H134S '(F64) Biquad filter0 coefficient B0
    Protected Const PRA_BIQUAD0_B1 As Short = &H135S '(F64) Biquad filter0 coefficient B1
    Protected Const PRA_BIQUAD0_B2 As Short = &H136S '(F64) Biquad filter0 coefficient B2
    Protected Const PRA_BIQUAD0_DIV As Short = &H137S '(F64) Biquad filter0 divider
    Protected Const PRA_BIQUAD1_A1 As Short = &H138S '(F64) Biquad filter1 coefficient A1
    Protected Const PRA_BIQUAD1_A2 As Short = &H139S '(F64) Biquad filter1 coefficient A2
    Protected Const PRA_BIQUAD1_B0 As Short = &H13AS '(F64) Biquad filter1 coefficient B0
    Protected Const PRA_BIQUAD1_B1 As Short = &H13BS '(F64) Biquad filter1 coefficient B1
    Protected Const PRA_BIQUAD1_B2 As Short = &H13CS '(F64) Biquad filter1 coefficient B2
    Protected Const PRA_BIQUAD1_DIV As Short = &H13DS '(F64) Biquad filter1 divider
    Protected Const PRA_FRIC_GAIN As Short = &H13ES '// (F64) Friction voltage compensation

    ' Board parameter define (For PCI-8392 SSCNET
    Protected Const PRB_SSC_APPLICATION As Integer = &H10000 ' Reserved
    Protected Const PRB_SSC_CYCLE_TIME As Integer = &H10000 ' SSCNET cycle time selection(vaild befor start sscnet
    Protected Const PRB_PARA_INIT_OPT As Short = &H20S ' Initial boot mode.

    ' Board parameter define (For DPAC
    Protected Const PRB_DPAC_DISPLAY_MODE As Integer = &H10001 'DPAC Display mode
    Protected Const PRB_DPAC_DI_MODE As Integer = &H10002 'Set DI pin modes

    Protected Const PRB_DPAC_THERMAL_MONITOR_NO As Integer = &H20001 'DPAC TEST
    Protected Const PRB_DPAC_THERMAL_MONITOR_VALUE As Integer = &H20002 'DPAC TEST

    ' Axis parameter define (General
    Protected Const PRA_EL_LOGIC As Short = &H0S ' EL logic
    Protected Const PRA_ORG_LOGIC As Short = &H1S ' ORG logic
    Protected Const PRA_EL_MODE As Short = &H2S ' EL stop mode
    Protected Const PRA_MDM_CONDI As Short = &H3S ' Motion done condition
    Protected Const PRA_EL_EXCHANGE As Short = &H4S ' PEL, MEL exchange enable

    Protected Const PRA_ALM_LOGIC As Short = &H4S ' ALM logic [PCI-8253/56 only]
    Protected Const PRA_ZSP_LOGIC As Short = &H5S ' ZSP logic [PCI-8253/56 only]
    Protected Const PRA_EZ_LOGIC As Short = &H6S ' EZ logic  [PCI-8253/56 only]
    Protected Const PRA_STP_DEC As Short = &H7S ' Stop deceleration
    Protected Const PRA_SPEL_EN As Short = &H8S ' SPEL Enable
    Protected Const PRA_SMEL_EN As Short = &H9S ' SMEL Enable
    Protected Const PRA_EFB_POS0 As Short = &HAS ' EFB position 0
    Protected Const PRA_SPEL_POS As Short = &HAS ' EFB position 0
    Protected Const PRA_EFB_POS1 As Short = &HBS ' EFB position 1
    Protected Const PRA_SMEL_POS As Short = &HBS ' EFB position 1
    Protected Const PRA_EFB_CONDI0 As Short = &HCS ' EFB position 0 condition
    Protected Const PRA_EFB_CONDI1 As Short = &HDS ' EFB position 1 condition
    Protected Const PRA_EFB_SRC0 As Short = &HES ' EFB position 0 source
    Protected Const PRA_EFB_SRC1 As Short = &HFS ' EFB position 1 source
    Protected Const PRA_HOME_MODE As Short = &H10S ' home mode
    Protected Const PRA_HOME_DIR As Short = &H11S ' homing direction
    Protected Const PRA_HOME_CURVE As Short = &H12S ' homing curve parten(T or s curve
    Protected Const PRA_HOME_ACC As Short = &H13S ' Acceleration deceleration rate
    Protected Const PRA_HOME_VS As Short = &H14S ' homing start velocity
    Protected Const PRA_HOME_VM As Short = &H15S ' homing max velocity
    'Protected Const PRA_HOME_VA As Short = &H16S ' homing approach velocity     [PCI-8253/56 only]
    'Protected Const PRA_HOME_EZA As Short = &H18S ' EZ alignment enable
    'Protected Const PRA_HOME_VO As Short = &H19S ' Homing leave ORG velocity
    'Protected Const PRA_HOME_OFFSET As Short = &H1AS ' The escape pulse amounts(Leaving home by position

    Protected Const PRA_JG_MODE As Short = &H40S ' Jog mode
    Protected Const PRA_JG_DIR As Short = &H41S ' Jog move direction
    Protected Const PRA_JG_CURVE As Short = &H42S ' Jog curve parten(T or s curve
    Protected Const PRA_JG_SF As Short = &H42S ' Jog curve parten(T or s curve
    Protected Const PRA_JG_ACC As Short = &H43S ' Jog move acceleration
    Protected Const PRA_JG_DEC As Short = &H44S ' Jog move deceleration
    Protected Const PRA_JG_VM As Short = &H45S ' Jog move max velocity

    ' Axis parameter define (For PCI-8253/56
    Protected Const PRA_PLS_IPT_MODE As Short = &H80S ' Pulse input mode setting
    Protected Const PRA_PLS_OPT_MODE As Short = &H81S ' Pulse output mode setting
    Protected Const PRA_MAX_E_LIMIT As Short = &H82S ' Maximum encoder count limit
    Protected Const PRA_ENC_FILTER As Short = &H83S ' Encoder filter
    Protected Const PRA_ENCODER_FILTER As Short = &H83S ' Encoder filter
    Protected Const PRA_EGEAR As Short = &H84S ' E-Gear ratio

    Protected Const PRA_KP_GAIN As Short = &H90S ' PID controller Kp gain
    Protected Const PRA_KI_GAIN As Short = &H91S ' PID controller Ki gain
    Protected Const PRA_KD_GAIN As Short = &H92S ' PID controller Kd gain
    Protected Const PRA_KFF_GAIN As Short = &H93S ' Feed forward Kff gain
    Protected Const PRA_KVFF_GAIN As Short = &H93S ' Feed forward Kff gain

    Protected Const PRA_KVGTY_GAIN As Short = &H94S ' Gantry controller Kvgty gain
    Protected Const PRA_KPGTY_GAIN As Short = &H95S ' Gantry controller Kpgty gain
    Protected Const PRA_IKP_GAIN As Short = &H96S ' PID controller Kp gain in torque mode
    Protected Const PRA_IKI_GAIN As Short = &H97S ' PID controller Ki gain in torque mode
    Protected Const PRA_IKD_GAIN As Short = &H98S ' PID controller Kd gain in torque mode
    Protected Const PRA_IKFF_GAIN As Short = &H99S ' Feed forward Kff gain in torque mode
    Protected Const PRA_KAFF_GAIN As Short = &H9AS  ' Acceleration feedforward Kaff gain

    Protected Const PRA_KP_SHIFT As Short = &H9BS           '//Proportional control result shift
    Protected Const PRA_KI_SHIFT As Short = &H9CS            '//Integral control result shift
    Protected Const PRA_KD_SHIFT As Short = &H9DS           '// Derivative control result shift
    Protected Const PRA_KVFF_SHIFT As Short = &H9ES          '//Velocity feed-forward control result shift
    Protected Const PRA_KAFF_SHIFT As Short = &H9FS          '//Acceleration feed-forward control result shift
    Protected Const PRA_PID_SHIFT As Short = &HA0S          '//PID control result shift





    '//following only for V2...
    Protected Const PRA_VOLTAGE_MAX As Short = &H9BS  ' Maximum output limit
    Protected Const PRA_VOLTAGE_MIN As Short = &H9CS  ' Minimum output limit

    Protected Const PRA_M_INTERFACE As Short = &H100S ' Motion interface

    Protected Const PRA_M_VOL_RANGE As Short = &H110S ' Motor voltage input range
    Protected Const PRA_M_MAX_SPEED As Short = &H111S ' Motor maximum speed
    Protected Const PRA_M_ENC_RES As Short = &H112S ' Motor encoder resolution

    Protected Const PRA_V_OFFSET As Short = &H120S ' Voltage offset
    Protected Const PRA_SERVO_V_BIAS As Short = &H120S ' Voltage offset
    Protected Const PRA_DZ_LOW As Short = &H121S ' Dead zone low side
    Protected Const PRA_DZ_UP As Short = &H122S ' Dead zone up side
    Protected Const PRA_SAT_LIMIT As Short = &H123S ' Voltage saturation output limit
    Protected Const PRA_SERVO_V_LIMIT As Short = &H123S ' Voltage saturation output limit
    Protected Const PRA_ERR_C_LEVEL As Short = &H124S ' Error counter check level
    Protected Const PRA_ERR_POS_LEVEL As Short = &H124S ' Error counter check level
    Protected Const PRA_V_INVERSE As Short = &H125S ' Output voltage inverse
    Protected Const PRA_SERVO_V_INVERSE As Short = &H125S ' Output voltage inverse
    Protected Const PRA_PSR_LINK As Short = &H130S ' Connect pulser number
    Protected Const PRA_PSR_RATIO As Short = &H131S ' Set pulser ratio
    Protected Const PRA_DA_TYPE As Short = &H140S ' DAC output type
    Protected Const PRA_CONTROL_MODE As Short = &H141S ' Closed loop control mode
    Protected Const PRA_BKL_DIST As Short = &H129S 'Backlash distance
    Protected Const PRA_BKL_CNSP As Short = &H12AS 'Backlash consumption
    Protected Const PRA_INTEGRAL_LIMIT As Short = &H12BS '(I32) Integral limit

    ' Axis parameter define (For PCI-8154/58
    ' Input/Output Mode
    Protected Const PRA_PLS_IPT_LOGIC As Short = &H200S 'Reverse pulse input counting
    Protected Const PRA_FEEDBACK_SRC As Short = &H201S 'Select feedback conter

    'IO Config
    Protected Const PRA_ALM_MODE As Short = &H210S 'ALM Mode
    Protected Const PRA_INP_LOGIC As Short = &H211S 'INP Logic
    Protected Const PRA_SD_EN As Short = &H212S 'SD Enable -- Bit 8
    Protected Const PRA_SD_MODE As Short = &H213S 'SD Mode
    Protected Const PRA_SD_LOGIC As Short = &H214S 'SD Logic
    Protected Const PRA_SD_LATCH As Short = &H215S 'SD Latch
    Protected Const PRA_ERC_MODE As Short = &H216S 'ERC Mode
    Protected Const PRA_ERC_LOGIC As Short = &H217S 'ERC logic
    Protected Const PRA_ERC_LEN As Short = &H218S 'ERC pulse width
    Protected Const PRA_CLR_MODE As Short = &H219S 'CLR Mode
    Protected Const PRA_CLR_TARGET As Short = &H21AS 'CLR Target counter
    Protected Const PRA_PIN_FLT As Short = &H21BS 'EA/EB Filter Enable
    Protected Const PRA_INP_MODE As Short = &H21CS 'INP Mode
    Protected Const PRA_LTC_LOGIC As Short = &H21DS 'LTC LOGIC
    Protected Const PRA_SOFT_PLIMIT As Short = &H21ES 'SOFT PLIMIT
    Protected Const PRA_SOFT_MLIMIT As Short = &H21FS 'SOFT MLIMIT
    Protected Const PRA_SOFT_LIMIT_EN As Short = &H220S 'SOFT ENABLE
    Protected Const PRA_BACKLASH_PULSE As Short = &H221S 'BACKLASH PULSE
    Protected Const PRA_BACKLASH_MODE As Short = &H222S 'BACKLASH MODE
    Protected Const PRA_LTC_SRC As Short = &H223S 'LTC Source
    Protected Const PRA_LTC_DEST As Short = &H224S 'LTC Destination
    Protected Const PRA_LTC_DATA As Short = &H225S 'Get LTC DATA
    Protected Const PRA_GCMP_EN As Short = &H226S ' CMP Enable
    Protected Const PRA_GCMP_POS As Short = &H227S ' Get CMP position
    Protected Const PRA_GCMP_SRC As Short = &H228S ' CMP source
    Protected Const PRA_GCMP_ACTION As Short = &H229S ' CMP Action
    Protected Const PRA_GCMP_STS As Short = &H22AS ' CMP Status
    Protected Const PRA_VIBSUP_RT As Short = &H22BS '// Vibration Reverse Time
    Protected Const PRA_VIBSUP_FT As Short = &H22CS '// Vibration Forward Time
    Protected Const PRA_LTC_DATA_SPD As Short = &H22DS '// Choose latch data for current speed or error position

    Protected Const PRA_GPDO_SEL As Short = &H230S 'Select DO/CMP Output mode
    Protected Const PRA_GPDI_SEL As Short = &H231S 'Select DO/CMP Output mode
    Protected Const PRA_GPDI_LOGIC As Short = &H232S 'Set gpio input logic
    Protected Const PRA_RDY_LOGIC As Short = &H233S 'RDY logic

    'Fixed Speed
    Protected Const PRA_SPD_LIMIT As Short = &H240S ' Set Fixed Speed
    Protected Const PRA_MAX_ACCDEC As Short = &H241S ' Get max acceleration by fixed speed
    Protected Const PRA_MIN_ACCDEC As Short = &H242S ' Get min acceleration by fixed speed
    Protected Const PRA_ENABLE_SPD As Short = &H243S ' Disable/Enable Fixed Speed only for HSL-4XMO.

    'Continuous Move
    Protected Const PRA_CONTI_MODE As Short = &H250S ' Continuous Mode
    Protected Const PRA_CONTI_BUFF As Short = &H251S ' Continuous Buffer

    'Simultaneous Move
    Protected Const PRA_SYNC_STOP_MODE As Short = &H260S '// Sync Mode

    ' PCI-8144 axis parameter define
    Protected Const PRA_CMD_CNT_EN As Integer = &H10000
    Protected Const PRA_MIO_SEN As Integer = &H10001
    Protected Const PRA_START_STA As Integer = &H10002
    Protected Const PRA_SPEED_CHN As Integer = &H10003
    Protected Const PRA_ORG_STP As Short = &H1AS

    ' Axis parameter define (For PCI-8392 SSCNET
    Protected Const PRA_SSC_SERVO_PARAM_SRC As Integer = &H10000 'Servo parameter source
    Protected Const PRA_SSC_SERVO_ABS_POS_OPT As Integer = &H10001 'Absolute position system option
    Protected Const PRA_SSC_SERVO_ABS_CYC_CNT As Integer = &H10002 'Absolute cycle counter of servo driver
    Protected Const PRA_SSC_SERVO_ABS_RES_CNT As Integer = &H10003 'Absolute resolution counter of servo driver
    Protected Const PRA_SSC_TORQUE_LIMIT_P As Integer = &H10004 'Torque limit positive (0.1%
    Protected Const PRA_SSC_TORQUE_LIMIT_N As Integer = &H10005 'Torque limit negative (0.1%
    Protected Const PRA_SSC_TORQUE_CTRL As Integer = &H10006 'Torque control
    Protected Const PRA_SSC_RESOLUTION As Integer = &H10007 'resolution (E-gear
    Protected Const PRA_SSC_GMR As Integer = &H10008 'resolution (New E-gear
    Protected Const PRA_SSC_GDR As Integer = &H10009 'resolution (New E-gear

    ' Sampling parameter define
    Protected Const SAMP_PA_RATE As Short = &H0S 'Sampling rate
    Protected Const SAMP_PA_EDGE As Short = &H2S 'Edge select
    Protected Const SAMP_PA_LEVEL As Short = &H3S 'Level select
    Protected Const SAMP_PA_TRIGCH As Short = &H5S 'Select trigger channel

    '//following only for V2
    Protected Const SAMP_PA_SEL As Short = &H6S

    Protected Const SAMP_PA_SRC_CH0 As Short = &H10S 'Sample source of channel 0
    Protected Const SAMP_PA_SRC_CH1 As Short = &H11S 'Sample source of channel 1
    Protected Const SAMP_PA_SRC_CH2 As Short = &H12S 'Sample source of channel 2
    Protected Const SAMP_PA_SRC_CH3 As Short = &H13S 'Sample source of channel 3

    ' Sampling source
    Protected Const SAMP_AXIS_MASK As Short = &HF00S
    Protected Const SAMP_PARAM_MASK As Short = &HFFS
    Protected Const SAMP_COM_POS As Short = &H0S 'command position
    Protected Const SAMP_FBK_POS As Short = &H1S 'feedback position
    Protected Const SAMP_CMD_VEL As Short = &H2S 'command velocity
    Protected Const SAMP_FBK_VEL As Short = &H3S 'feedback velocity
    Protected Const SAMP_MIO As Short = &H4S 'motion IO
    Protected Const SAMP_MSTS As Short = &H5S 'motion status
    Protected Const SAMP_MSTS_ACC As Short = &H6S 'motion status acc
    Protected Const SAMP_MSTS_MV As Short = &H7S 'motion status at max velocity
    Protected Const SAMP_MSTS_DEC As Short = &H8S 'motion status at dec
    Protected Const SAMP_MSTS_CSTP As Short = &H9S 'motion status CSTP
    Protected Const SAMP_MSTS_NSTP As Short = &HAS 'motion status NSTP
    Protected Const SAMP_MSTS_MDN As Short = &HAS 'motion status NSTP
    Protected Const SAMP_MIO_INP As Short = &HBS 'motion status INP
    Protected Const SAMP_MIO_ZERO As Short = &HCS 'motion status ZERO
    Protected Const SAMP_MIO_ORG As Short = &HDS 'motion status OGR

    Protected Const SAMP_SSC_MON_0 As Short = &H10S ' SSCNET servo monitor ch0
    Protected Const SAMP_SSC_MON_1 As Short = &H11S ' SSCNET servo monitor ch1
    Protected Const SAMP_SSC_MON_2 As Short = &H12S ' SSCNET servo monitor ch2
    Protected Const SAMP_SSC_MON_3 As Short = &H13S ' SSCNET servo monitor ch3

    '//Only for PCI-8254/8, AMP-204/8C
    Protected Const SAMP_COM_POS_F64 As Short = &H10S '// Command position
    Protected Const SAMP_FBK_POS_F64 As Short = &H11S '//Feedback position
    Protected Const SAMP_CMD_VEL_F64 As Short = &H12S '// Command velocity
    Protected Const SAMP_FBK_VEL_F64 As Short = &H13S '// Feedback velocity
    Protected Const SAMP_CONTROL_VOL_F64 As Short = &H14S '// Control command voltage
    Protected Const SAMP_ERR_POS_F64 As Short = &H15S '// Error position
    Protected Const SAMP_PWM_FREQUENCY_F64 As Short = &H18S '// PWM frequency (Hz)
    Protected Const SAMP_PWM_DUTY_CYCLE_F64 As Short = &H19S '// PWM duty cycle (%)
    Protected Const SAMP_PWM_WIDTH_F64 As Short = &H1AS '// PWM width (ns)
    Protected Const SAMP_VAO_COMP_VEL_F64 As Short = &H1BS '// Composed velocity for Laser power control (pps)
    Protected Const SAMP_PTBUFF_COMP_VEL_F64 As Short = &H1CS '// Composed velocity of point table
    Protected Const SAMP_PTBUFF_COMP_ACC_F64 As Short = &H1DS '// Composed acceleration of point table

    Protected Const SAMP_CONTROL_VOL As Short = &H20S '
    Protected Const SAMP_GTY_DEVIATION As Short = &H21S
    Protected Const SAMP_ENCODER_RAW As Short = &H22S
    Protected Const SAMP_ERROR_COUNTER As Short = &H23S
    Protected Const SAMP_ERROR_POS As Short = &H23S '//Error position [PCI-8254/58]
    Protected Const SAMP_PTBUFF_RUN_INDEX As Short = &H24S '//Point table running index

    'FieldBus parameter define
    Protected Const PRF_COMMUNICATION_TYPE As Short = &H0S ' FiledBus Communication Type(Full/half duplex
    Protected Const PRF_TRANSFER_RATE As Short = &H1S ' FiledBus Transfer Rate
    Protected Const PRF_HUB_NUMBER As Short = &H2S ' FiledBus Hub Number
    Protected Const PRF_INITIAL_TYPE As Short = &H3S ' FiledBus Initial Type(Clear/Reserve Do area
    Protected Const PRF_CHKERRCNT_LAYER As Short = &H4S '// Set the check error count layer.

    'Gantry parameter number define [Only for PCI-8392, PCI-8253/56]
    Protected Const GANTRY_MODE As Short = &H0S
    Protected Const GENTRY_DEVIATION As Short = &H1S
    Protected Const GENTRY_DEVIATION_STP As Short = &H2S

    ' Filter parameter number define [Only for PCI-8253/56]
    Protected Const FTR_TYPE_ST0 As Short = &H0S  '// Station 0 filter type
    Protected Const FTR_FC_ST0 As Short = &H1S  '// Station 0 filter cutoff frequency
    Protected Const FTR_BW_ST0 As Short = &H2S  '// Station 0 filter bandwidth
    Protected Const FTR_ENABLE_ST0 As Short = &H3S  '// Station 0 filter enable/disable
    Protected Const FTR_TYPE_ST1 As Short = &H10S  '// Station 1 filter type
    Protected Const FTR_FC_ST1 As Short = &H11S  '// Station 1 filter cutoff frequency
    Protected Const FTR_BW_ST1 As Short = &H12S  '// Station 1 filter bandwidth
    Protected Const FTR_ENABLE_ST1 As Short = &H13S  '// Station 1 filter enable/disable


    ' Filter parameter number define [Only for PCI-8253/56]
    Protected Const FTR_TYPE As Short = &H0S ' Filter type
    Protected Const FTR_FC As Short = &H1S ' Filter cutoff frequency
    Protected Const FTR_BW As Short = &H2S ' Filter bandwidth
    Protected Const FTR_ENABLE As Short = &H3S ' Filter enable/disable

    ' Device name define
    Protected Const DEVICE_NAME_NULL As Short = &HFFFFS
    Protected Const DEVICE_NAME_PCI_8392 As Short = 0
    Protected Const DEVICE_NAME_PCI_825X As Short = 1
    Protected Const DEVICE_NAME_PCI_8154 As Short = 2
    Protected Const DEVICE_NAME_PCI_785X As Short = 3
    Protected Const DEVICE_NAME_PCI_8158 As Short = 4
    Protected Const DEVICE_NAME_PCI_7856 As Short = 5
    Protected Const DEVICE_NAME_ISA_DPAC1000 As Short = 6
    Protected Const DEVICE_NAME_ISA_DPAC3000 As Short = 7
    Protected Const DEVICE_NAME_PCI_8144 As Short = 8
    Protected Const DEVICE_NAME_PCI_825458 As Short = 9
    Protected Const DEVICE_NAME_PCI_8102 As Short = 10
    Protected Const DEVICE_NAME_PCI_V8258 As Short = 11
    Protected Const DEVICE_NAME_PCI_V8254 As Short = 12
    Protected Const DEVICE_NAME_PCI_8158A As Short = 13
    Protected Const DEVICE_NAME_AMP_20408C As Short = 14

    '''''''''''''''''''''''/
    '   HSL Slave module definition
    '''''''''''''''''''''''/
    Protected Const SLAVE_NAME_UNKNOWN As Short = &H0S
    Protected Const SLAVE_NAME_HSL_DI32 As Short = &H100S
    Protected Const SLAVE_NAME_HSL_DO32 As Short = &H101S
    Protected Const SLAVE_NAME_HSL_DI16DO16 As Short = &H102S
    Protected Const SLAVE_NAME_HSL_AO4 As Short = &H103S
    Protected Const SLAVE_NAME_HSL_AI16AO2_VV As Short = &H104S
    Protected Const SLAVE_NAME_HSL_AI16AO2_AV As Short = &H105S
    Protected Const SLAVE_NAME_HSL_DI16UL As Short = &H106S
    Protected Const SLAVE_NAME_HSL_DI16RO8 As Short = &H107S
    Protected Const SLAVE_NAME_HSL_4XMO As Short = &H108S
    Protected Const SLAVE_NAME_HSL_DI16_UCT As Short = &H109S
    Protected Const SLAVE_NAME_HSL_DO16_UCT As Short = &H10AS
    Protected Const SLAVE_NAME_HSL_DI8DO8 As Short = &H10BS

    '''''''''''''''''''''''/
    '   MNET Slave module definition
    '''''''''''''''''''''''/
    Protected Const SLAVE_NAME_MNET_1XMO As Short = &H200S
    Protected Const SLAVE_NAME_MNET_4XMO As Short = &H201S
    Protected Const SLAVE_NAME_MNET_4XMO_C As Short = &H202S

    '//Trigger parameter number define. [Only for DB-8150]
    Protected Const TG_PWM0_PULSE_WIDTH As Short = &H0S
    Protected Const TG_PWM1_PULSE_WIDTH As Short = &H1S
    Protected Const TG_PWM0_MODE As Short = &H2S
    Protected Const TG_PWM1_MODE As Short = &H3S
    Protected Const TG_TIMER0_INTERVAL As Short = &H4S
    Protected Const TG_TIMER1_INTERVAL As Short = &H5S
    Protected Const TG_ENC0_CNT_DIR As Short = &H6S
    Protected Const TG_ENC1_CNT_DIR As Short = &H7S
    Protected Const TG_IPT0_MODE As Short = &H8S
    Protected Const TG_IPT1_MODE As Short = &H9S
    Protected Const TG_EZ0_CLEAR_EN As Short = &HAS
    Protected Const TG_EZ1_CLEAR_EN As Short = &HBS
    Protected Const TG_EZ0_CLEAR_LOGIC As Short = &HCS
    Protected Const TG_EZ1_CLEAR_LOGIC As Short = &HDS
    Protected Const TG_CNT0_SOURCE As Short = &HES
    Protected Const TG_CNT1_SOURCE As Short = &HFS
    Protected Const TG_FTR0_EN As Short = &H10S
    Protected Const TG_FTR1_EN As Short = &H11S
    Protected Const TG_DI_LATCH0_EN As Short = &H12S
    Protected Const TG_DI_LATCH1_EN As Short = &H13S
    Protected Const TG_DI_LATCH0_EDGE As Short = &H14S
    Protected Const TG_DI_LATCH1_EDGE As Short = &H15S
    Protected Const TG_DI_LATCH0_VALUE As Short = &H16S
    Protected Const TG_DI_LATCH1_VALUE As Short = &H17S
    Protected Const TG_TRGOUT_MAP As Short = &H18S
    Protected Const TG_TRGOUT_LOGIC As Short = &H19S
    Protected Const TG_FIFO_LEVEL As Short = &H1AS
    Protected Const TG_PWM0_SOURCE As Short = &H1BS
    Protected Const TG_PWM1_SOURCE As Short = &H1CS

    'Trigger parameter number define. [Only for PCI-8253/56]
    Protected Const TG_LCMP0_SRC As Short = &H0S
    Protected Const TG_LCMP1_SRC As Short = &H1S
    Protected Const TG_TCMP0_SRC As Short = &H2S
    Protected Const TG_TCMP1_SRC As Short = &H3S

    Protected Const TG_LCMP0_EN As Short = &H4S
    Protected Const TG_LCMP1_EN As Short = &H5S
    Protected Const TG_TCMP0_EN As Short = &H6S
    Protected Const TG_TCMP1_EN As Short = &H7S

    Protected Const TG_TRG0_SRC As Short = &H10S
    Protected Const TG_TRG1_SRC As Short = &H11S
    Protected Const TG_TRG2_SRC As Short = &H12S
    Protected Const TG_TRG3_SRC As Short = &H13S

    Protected Const TG_TRG0_PWD As Short = &H14S
    Protected Const TG_TRG1_PWD As Short = &H15S
    Protected Const TG_TRG2_PWD As Short = &H16S
    Protected Const TG_TRG3_PWD As Short = &H17S

    Protected Const TG_TRG0_CFG As Short = &H18S
    Protected Const TG_TRG1_CFG As Short = &H19S
    Protected Const TG_TRG2_CFG As Short = &H1AS
    Protected Const TG_TRG3_CFG As Short = &H1BS

    Protected Const TG_TRG0_TGL As Short = &H1C
    Protected Const TG_TRG1_TGL As Short = &H1D
    Protected Const TG_TRG2_TGL As Short = &H1E
    Protected Const TG_TRG3_TGL As Short = &H1F

    Protected Const TMR_ITV As Short = &H20S
    Protected Const TMR_EN As Short = &H21S

    'Trigger parameter number define. [Only for MNET-4XMO-C]
    Protected Const TG_CMP0_SRC As Short = &H0S
    Protected Const TG_CMP1_SRC As Short = &H1S
    Protected Const TG_CMP2_SRC As Short = &H2S
    Protected Const TG_CMP3_SRC As Short = &H3S
    Protected Const TG_CMP0_EN As Short = &H4S
    Protected Const TG_CMP1_EN As Short = &H5S
    Protected Const TG_CMP2_EN As Short = &H6S
    Protected Const TG_CMP3_EN As Short = &H7S
    Protected Const TG_CMP0_TYPE As Short = &H8S
    Protected Const TG_CMP1_TYPE As Short = &H9S
    Protected Const TG_CMP2_TYPE As Short = &HAS
    Protected Const TG_CMP3_TYPE As Short = &HBS
    Protected Const TG_CMPH_EN As Short = &HCS
    Protected Const TG_CMPH_DIR_EN As Short = &HDS
    Protected Const TG_CMPH_DIR As Short = &HES

    'Protected Const  TG_TRG0_SRC                   =&H10
    'Protected Const  TG_TRG1_SRC                   =&H11
    'Protected Const  TG_TRG2_SRC                   =&H12
    'Protected Const  TG_TRG3_SRC                   =&H13

    'Protected Const  TG_TRG0_PWD                   =&H14
    'Protected Const  TG_TRG1_PWD                   =&H15
    'Protected Const  TG_TRG2_PWD                   =&H16
    'Protected Const  TG_TRG3_PWD                   =&H17

    'Protected Const  TG_TRG0_CFG                   =&H18
    'Protected Const  TG_TRG1_CFG                   =&H19
    'Protected Const  TG_TRG2_CFG                   =&H1A
    'Protected Const  TG_TRG3_CFG                   =&H1B

    Protected Const TG_ENCH_CFG As Short = &H20S

    Protected Const TG_TRG0_CMP_DIR As Short = &H21S
    Protected Const TG_TRG1_CMP_DIR As Short = &H22S
    Protected Const TG_TRG2_CMP_DIR As Short = &H23S
    Protected Const TG_TRG3_CMP_DIR As Short = &H24S

    Protected Const TG_MCMP0_SRC As Short = &H30
    Protected Const TG_MCMP1_SRC As Short = &H31
    Protected Const TG_MCMP2_SRC As Short = &H32
    Protected Const TG_MCMP3_SRC As Short = &H33

    ' Motion IO status bit number define.
    Protected Const MIO_ALM As Short = 0 ' Servo alarm.
    Protected Const MIO_PEL As Short = 1 ' Positive end limit.
    Protected Const MIO_MEL As Short = 2 ' Negative end limit.
    Protected Const MIO_ORG As Short = 3 ' ORG =Home
    Protected Const MIO_EMG As Short = 4 ' Emergency stop
    Protected Const MIO_EZ As Short = 5 ' EZ.
    Protected Const MIO_INP As Short = 6 ' In position.
    Protected Const MIO_SVON As Short = 7 ' Servo on signal.
    Protected Const MIO_RDY As Short = 8 ' Ready.
    Protected Const MIO_WARN As Short = 9 ' Warning.
    Protected Const MIO_ZSP As Short = 10 ' Zero speed.
    Protected Const MIO_SPEL As Short = 11 ' Soft positive end limit.
    Protected Const MIO_SMEL As Short = 12 ' Soft negative end limit.
    Protected Const MIO_TLC As Short = 13 ' Torque is limited by torque limit value.
    Protected Const MIO_ABSL As Short = 14 ' Absolute position lost.
    Protected Const MIO_STA As Short = 15 ' External start signal.
    Protected Const MIO_PSD As Short = 16 ' Positive slow down signal
    Protected Const MIO_MSD As Short = 17 ' Negative slow down signal

    ' Motion status bit number define.
    Protected Const MTS_CSTP As Short = 0 ' Command stop signal.
    Protected Const MTS_VM As Short = 1 ' At maximum velocity.
    Protected Const MTS_ACC As Short = 2 ' In acceleration.
    Protected Const MTS_DEC As Short = 3 ' In deceleration.
    Protected Const MTS_DIR As Short = 4 ' LastMoving direction.
    Protected Const MTS_NSTP As Short = 5 ' Normal stop(Motion done.
    Protected Const MTS_HMV As Short = 6 ' In home operation.
    Protected Const MTS_SMV As Short = 7 ' Single axis move relative, absolute, velocity move.
    Protected Const MTS_LIP As Short = 8 ' Linear interpolation.
    Protected Const MTS_CIP As Short = 9 ' Circular interpolation.
    Protected Const MTS_VS As Short = 10 ' At start velocity.
    Protected Const MTS_PMV As Short = 11 ' Point table move.
    Protected Const MTS_PDW As Short = 12 ' Point table dwell move.
    Protected Const MTS_PPS As Short = 13 ' Point table pause state.
    Protected Const MTS_SLV As Short = 14 ' Slave axis move.
    Protected Const MTS_JOG As Short = 15 ' Jog move.
    Protected Const MTS_ASTP As Short = 16 ' Abnormal stop.
    Protected Const MTS_SVONS As Short = 17 ' Servo off stopped.
    Protected Const MTS_EMGS As Short = 18 ' EMG / SEMG stopped.
    Protected Const MTS_ALMS As Short = 19 ' Alarm stop.
    Protected Const MTS_WANS As Short = 20 ' Warning stopped.
    Protected Const MTS_PELS As Short = 21 ' PEL stopped.
    Protected Const MTS_MELS As Short = 22 ' MEL stopped.
    Protected Const MTS_ECES As Short = 23 ' Error counter check level reaches and stopped.
    Protected Const MTS_SPELS As Short = 24 ' Soft PEL stopped.
    Protected Const MTS_SMELS As Short = 25 ' Soft MEL stopped.
    Protected Const MTS_STPOA As Short = 26 ' Stop by others axes.
    Protected Const MTS_GDCES As Short = 27 ' Gantry deviation error level reaches and stopped.
    Protected Const MTS_GTM As Short = 28 ' Gantry mode turn on.
    Protected Const MTS_PAPB As Short = 29 ' Pulsar mode turn on.

    ' Motion IO status bit value define.
    Protected Const MIO_ALM_V As Short = &H1S ' Servo alarm.
    Protected Const MIO_PEL_V As Short = &H2S ' Positive end limit.
    Protected Const MIO_MEL_V As Short = &H4S ' Negative end limit.
    Protected Const MIO_ORG_V As Short = &H8S ' ORG =Home.
    Protected Const MIO_EMG_V As Short = &H10S ' Emergency stop.
    Protected Const MIO_EZ_V As Short = &H20S ' EZ.
    Protected Const MIO_INP_V As Short = &H40S ' In position.
    Protected Const MIO_SVON_V As Short = &H80S ' Servo on signal.
    Protected Const MIO_RDY_V As Short = &H100S ' Ready.
    Protected Const MIO_WARN_V As Short = &H200S ' Warning.
    Protected Const MIO_ZSP_V As Short = &H400S ' Zero speed.
    Protected Const MIO_SPEL_V As Short = &H800S ' Soft positive end limit.
    Protected Const MIO_SMEL_V As Short = &H1000S ' Soft negative end limit.
    Protected Const MIO_TLC_V As Short = &H2000S ' Torque is limited by torque limit value.
    Protected Const MIO_ABSL_V As Short = &H4000S ' Absolute position lost.
    Protected Const MIO_STA_V As Short = &H8000S ' External start signal.
    Protected Const MIO_PSD_V As Integer = &H10000 ' Positive slow down signal.
    Protected Const MIO_MSD_V As Integer = &H20000 ' Negative slow down signal.

    ' Motion status bit value define.
    Protected Const MTS_CSTP_V As Short = &H1S ' Command stop signal.
    Protected Const MTS_VM_V As Short = &H2S ' At maximum velocity.
    Protected Const MTS_ACC_V As Short = &H4S ' In acceleration.
    Protected Const MTS_DEC_V As Short = &H8S ' In deceleration.
    Protected Const MTS_DIR_V As Short = &H10S ' LastMoving direction.
    Protected Const MTS_NSTP_V As Short = &H20S ' Normal stop Motion done.
    Protected Const MTS_HMV_V As Short = &H40S ' In home operation.
    Protected Const MTS_SMV_V As Short = &H80S ' Single axis move( relative, absolute, velocity move.
    Protected Const MTS_LIP_V As Short = &H100S ' Linear interpolation.
    Protected Const MTS_CIP_V As Short = &H200S ' Circular interpolation.
    Protected Const MTS_VS_V As Short = &H400S ' At start velocity.
    Protected Const MTS_PMV_V As Short = &H800S ' Point table move.
    Protected Const MTS_PDW_V As Short = &H1000S ' Point table dwell move.
    Protected Const MTS_PPS_V As Short = &H2000S ' Point table pause state.
    Protected Const MTS_SLV_V As Short = &H4000S ' Slave axis move.
    Protected Const MTS_JOG_V As Short = &H8000S ' Jog move.
    Protected Const MTS_ASTP_V As Integer = &H10000 ' Abnormal stop.
    Protected Const MTS_SVONS_V As Integer = &H20000 ' Servo off stopped.
    Protected Const MTS_EMGS_V As Integer = &H40000 ' EMG / SEMG stopped.
    Protected Const MTS_ALMS_V As Integer = &H80000 ' Alarm stop.
    Protected Const MTS_WANS_V As Integer = &H100000 ' Warning stopped.
    Protected Const MTS_PELS_V As Integer = &H200000 ' PEL stopped.
    Protected Const MTS_MELS_V As Integer = &H400000 ' MEL stopped.
    Protected Const MTS_ECES_V As Integer = &H800000 ' Error counter check level reaches and stopped.
    Protected Const MTS_SPELS_V As Integer = &H1000000 ' Soft PEL stopped.
    Protected Const MTS_SMELS_V As Integer = &H2000000 ' Soft MEL stopped.
    Protected Const MTS_STPOA_V As Integer = &H4000000 ' Stop by others axes.
    Protected Const MTS_GDCES_V As Integer = &H8000000 ' Gantry deviation error level reaches and stopped.
    Protected Const MTS_GTM_V As Integer = &H10000000 ' Gantry mode turn on.
    Protected Const MTS_PAPB_V As Integer = &H20000000 ' Pulsar mode turn on.



    'PointTable, option
    Protected Const PT_OPT_ABS As Integer = &H0    '// move, absolute
    Protected Const PT_OPT_REL As Integer = &H1    '// move, relative
    Protected Const PT_OPT_LINEAR As Integer = &H0    '// move, linear
    Protected Const PT_OPT_ARC As Integer = &H4   '// move, arc
    Protected Const PT_OPT_FC_CSTP As Integer = &H0    '// signal, command stop (finish condition)
    Protected Const PT_OPT_FC_INP As Integer = &H10    '// signal, in position
    Protected Const PT_OPT_LAST_POS As Integer = &H20    '// last point index
    Protected Const PT_OPT_DWELL As Integer = &H40   '// dwell
    Protected Const PT_OPT_RAPID As Integer = &H80    '// rapid positioning
    Protected Const PT_OPT_NOARC As Integer = &H10000    '// do not add arc
    Protected Const PT_OPT_SCUVE As Integer = &H2    '// s-curve

    'Trigger parameter number define. [Only for PCI-8258]   
    Protected Const TGR_LCMP0_SRC As Short = &H0S
    Protected Const TGR_LCMP1_SRC As Short = &H1S
    Protected Const TGR_TCMP0_SRC As Short = &H2S
    Protected Const TGR_TCMP1_SRC As Short = &H3S

    Protected Const TGR_TCMP0_DIR As Short = &H4S
    Protected Const TGR_TCMP1_DIR As Short = &H5S
    Protected Const TGR_TRG_EN As Short = &H6S

    Protected Const TGR_TRG0_SRC As Short = &H10S
    Protected Const TGR_TRG1_SRC As Short = &H11S
    Protected Const TGR_TRG2_SRC As Short = &H12S
    Protected Const TGR_TRG3_SRC As Short = &H13S

    Protected Const TGR_TRG0_PWD As Short = &H14S
    Protected Const TGR_TRG1_PWD As Short = &H15S
    Protected Const TGR_TRG2_PWD As Short = &H16S
    Protected Const TGR_TRG3_PWD As Short = &H17S

    Protected Const TGR_TRG0_LOGIC As Short = &H18S
    Protected Const TGR_TRG1_LOGIC As Short = &H19S
    Protected Const TGR_TRG2_LOGIC As Short = &H1AS
    Protected Const TGR_TRG3_LOGIC As Short = &H1BS

    Protected Const TGR_TRG0_TGL As Short = &H1CS
    Protected Const TGR_TRG1_TGL As Short = &H1DS
    Protected Const TGR_TRG2_TGL As Short = &H1ES
    Protected Const TGR_TRG3_TGL As Short = &H1FS

    Protected Const TIMR_ITV As Short = &H20S
    Protected Const TIMR_DIR As Short = &H21S
    Protected Const TIMR_RING_EN As Short = &H22S
    Protected Const TIMR_EN As Short = &H23S

    '//Trigger parameter number define. [Only for PCI-8158A & PCI-C154(+)]
    Protected Const TIG_ENC_IPT_MODE0 As Short = &H0S
    Protected Const TIG_ENC_IPT_MODE1 As Short = &H1S
    Protected Const TIG_ENC_IPT_MODE2 As Short = &H2S
    Protected Const TIG_ENC_IPT_MODE3 As Short = &H3S
    Protected Const TIG_ENC_IPT_MODE4 As Short = &H4S
    Protected Const TIG_ENC_IPT_MODE5 As Short = &H5S
    Protected Const TIG_ENC_IPT_MODE6 As Short = &H6S
    Protected Const TIG_ENC_IPT_MODE7 As Short = &H7S
    Protected Const TIG_ENC_EA_INV0 As Short = &H8S
    Protected Const TIG_ENC_EA_INV1 As Short = &H9S
    Protected Const TIG_ENC_EA_INV2 As Short = &HAS
    Protected Const TIG_ENC_EA_INV3 As Short = &HBS
    Protected Const TIG_ENC_EA_INV4 As Short = &HCS
    Protected Const TIG_ENC_EA_INV5 As Short = &HDS
    Protected Const TIG_ENC_EA_INV6 As Short = &HES
    Protected Const TIG_ENC_EA_INV7 As Short = &HFS
    Protected Const TIG_ENC_EB_INV0 As Short = &H10S
    Protected Const TIG_ENC_EB_INV1 As Short = &H11S
    Protected Const TIG_ENC_EB_INV2 As Short = &H12S
    Protected Const TIG_ENC_EB_INV3 As Short = &H13S
    Protected Const TIG_ENC_EB_INV4 As Short = &H14S
    Protected Const TIG_ENC_EB_INV5 As Short = &H15S
    Protected Const TIG_ENC_EB_INV6 As Short = &H16S
    Protected Const TIG_ENC_EB_INV7 As Short = &H17S
    Protected Const TIG_ENC_SIGNAL_FILITER_EN0 As Short = &H28S
    Protected Const TIG_ENC_SIGNAL_FILITER_EN1 As Short = &H29S
    Protected Const TIG_ENC_SIGNAL_FILITER_EN2 As Short = &H2AS
    Protected Const TIG_ENC_SIGNAL_FILITER_EN3 As Short = &H2BS
    Protected Const TIG_ENC_SIGNAL_FILITER_EN4 As Short = &H2CS
    Protected Const TIG_ENC_SIGNAL_FILITER_EN5 As Short = &H2DS
    Protected Const TIG_ENC_SIGNAL_FILITER_EN6 As Short = &H2ES
    Protected Const TIG_ENC_SIGNAL_FILITER_EN7 As Short = &H2FS
    Protected Const TIG_TIMER8_DIR As Short = &H30S
    Protected Const TIG_TIMER8_ITV As Short = &H31S
    Protected Const TIG_CMP0_SRC As Short = &H32S
    Protected Const TIG_CMP1_SRC As Short = &H33S
    Protected Const TIG_CMP2_SRC As Short = &H34S
    Protected Const TIG_CMP3_SRC As Short = &H35S
    Protected Const TIG_CMP4_SRC As Short = &H36S
    Protected Const TIG_CMP5_SRC As Short = &H37S
    Protected Const TIG_CMP6_SRC As Short = &H38S
    Protected Const TIG_CMP7_SRC As Short = &H39S
    Protected Const TIG_TRG0_SRC As Short = &H3AS
    Protected Const TIG_TRG1_SRC As Short = &H3BS
    Protected Const TIG_TRG2_SRC As Short = &H3CS
    Protected Const TIG_TRG3_SRC As Short = &H3DS
    Protected Const TIG_TRG4_SRC As Short = &H3ES
    Protected Const TIG_TRG5_SRC As Short = &H3FS
    Protected Const TIG_TRG6_SRC As Short = &H40S
    Protected Const TIG_TRG7_SRC As Short = &H41S
    Protected Const TIG_TRGOUT0_MAP As Short = &H42S
    Protected Const TIG_TRGOUT1_MAP As Short = &H43S
    Protected Const TIG_TRGOUT2_MAP As Short = &H44S
    Protected Const TIG_TRGOUT3_MAP As Short = &H45S
    Protected Const TIG_TRGOUT4_MAP As Short = &H46S
    Protected Const TIG_TRGOUT5_MAP As Short = &H47S
    Protected Const TIG_TRGOUT6_MAP As Short = &H48S
    Protected Const TIG_TRGOUT7_MAP As Short = &H49S
    Protected Const TIG_TRGOUT0_LOGIC As Short = &H4AS
    Protected Const TIG_TRGOUT1_LOGIC As Short = &H4BS
    Protected Const TIG_TRGOUT2_LOGIC As Short = &H4CS
    Protected Const TIG_TRGOUT3_LOGIC As Short = &H4DS
    Protected Const TIG_TRGOUT4_LOGIC As Short = &H4ES
    Protected Const TIG_TRGOUT5_LOGIC As Short = &H4FS
    Protected Const TIG_TRGOUT6_LOGIC As Short = &H50S
    Protected Const TIG_TRGOUT7_LOGIC As Short = &H51S
    Protected Const TIG_PWM0_PULSE_WIDTH As Short = &H52S
    Protected Const TIG_PWM1_PULSE_WIDTH As Short = &H53S
    Protected Const TIG_PWM2_PULSE_WIDTH As Short = &H54S
    Protected Const TIG_PWM3_PULSE_WIDTH As Short = &H55S
    Protected Const TIG_PWM4_PULSE_WIDTH As Short = &H56S
    Protected Const TIG_PWM5_PULSE_WIDTH As Short = &H57S
    Protected Const TIG_PWM6_PULSE_WIDTH As Short = &H58S
    Protected Const TIG_PWM7_PULSE_WIDTH As Short = &H59S
    Protected Const TIG_PWM0_MODE As Short = &H5AS
    Protected Const TIG_PWM1_MODE As Short = &H5BS
    Protected Const TIG_PWM2_MODE As Short = &H5CS
    Protected Const TIG_PWM3_MODE As Short = &H5DS
    Protected Const TIG_PWM4_MODE As Short = &H5ES
    Protected Const TIG_PWM5_MODE As Short = &H5FS
    Protected Const TIG_PWM6_MODE As Short = &H60S
    Protected Const TIG_PWM7_MODE As Short = &H61S
    Protected Const TIG_TIMER0_ITV As Short = &H62S
    Protected Const TIG_TIMER1_ITV As Short = &H63S
    Protected Const TIG_TIMER2_ITV As Short = &H64S
    Protected Const TIG_TIMER3_ITV As Short = &H65S
    Protected Const TIG_TIMER4_ITV As Short = &H66S
    Protected Const TIG_TIMER5_ITV As Short = &H67S
    Protected Const TIG_TIMER6_ITV As Short = &H68S
    Protected Const TIG_TIMER7_ITV As Short = &H69S
    Protected Const TIG_FIFO_LEVEL0 As Short = &H6AS
    Protected Const TIG_FIF1_LEVEL0 As Short = &H6BS
    Protected Const TIG_FIF2_LEVEL0 As Short = &H6CS
    Protected Const TIG_FIF3_LEVEL0 As Short = &H6DS
    Protected Const TIG_FIF4_LEVEL0 As Short = &H6ES
    Protected Const TIG_FIF5_LEVEL0 As Short = &H6FS
    Protected Const TIG_FIF6_LEVEL0 As Short = &H70S
    Protected Const TIG_FIF7_LEVEL0 As Short = &H71S
    Protected Const TIG_OUTPUT_EN0 As Short = &H72S
    Protected Const TIG_OUTPUT_EN1 As Short = &H73S
    Protected Const TIG_OUTPUT_EN2 As Short = &H74S
    Protected Const TIG_OUTPUT_EN3 As Short = &H75S
    Protected Const TIG_OUTPUT_EN4 As Short = &H76S
    Protected Const TIG_OUTPUT_EN5 As Short = &H77S
    Protected Const TIG_OUTPUT_EN6 As Short = &H78S
    Protected Const TIG_OUTPUT_EN7 As Short = &H79S


    Protected Const PRA_HOME_LATCH As Short = &H900S   '//Select Home latch source [PCI-8353 only]

    '// move option define
    Protected Const OPT_ABSOLUTE As Integer = &H0
    Protected Const OPT_RELATIVE As Integer = &H1
    Protected Const OPT_WAIT As Integer = &H100

    '// PTP buffer mode define
    Protected Const PTP_OPT_ABORTING As Integer = &H0S
    Protected Const PTP_OPT_BUFFERED As Integer = &H1000S
    Protected Const PTP_OPT_BLEND_LOW As Integer = &H2000S
    Protected Const PTP_OPT_BLEND_PREVIOUS As Integer = &H3000
    Protected Const PTP_OPT_BLEND_NEXT As Integer = &H4000S
    Protected Const PTP_OPT_BLEND_HIGH As Integer = &H5000S

    Protected Const ITP_OPT_ABORT_BLEND As Integer = &H0S
    Protected Const ITP_OPT_ABORT_FORCE As Integer = &H1000S
    Protected Const ITP_OPT_ABORT_STOP As Integer = &H2000S
    Protected Const ITP_OPT_BUFFERED As Integer = &H3000S
    Protected Const ITP_OPT_BLEND_DEC_EVENT As Integer = &H4000S
    Protected Const ITP_OPT_BLEND_RES_DIST As Integer = &H5000S
    Protected Const ITP_OPT_BLEND_RES_DIST_PERCENT As Integer = &H6000S

    'Latch parameter number define. [Only for PCI-8158A & PCI-C154(+)]
    Protected Const LTC_ENC_IPT_MODE As Integer = &H0
    Protected Const LTC_ENC_EA_INV As Integer = &H1
    Protected Const LTC_ENC_EB_INV As Integer = &H2
    Protected Const LTC_ENC_EZ_CLR_LOGIC As Integer = &H3
    Protected Const LTC_ENC_EZ_CLR_EN As Integer = &H4
    Protected Const LTC_ENC_SIGNAL_FILITER_EN As Integer = &H5
    Protected Const LTC_FIFO_HIGH_LEVEL As Integer = &H6
    Protected Const LTC_SIGNAL_FILITER_EN As Integer = &H7
    Protected Const LTC_SIGNAL_TRIG_LOGIC As Integer = &H8

    'Error code define
    Protected Const ERR_NoError As Integer = (0)        '//No Error	
    Protected Const ERR_OSVersion As Integer = (-1)   '// Operation System type mismatched
    Protected Const ERR_OpenDriverFailed As Integer = (-2) '	// Open device driver failed - Create driver interface failed
    Protected Const ERR_InsufficientMemory As Integer = (-3)   '// System memory insufficiently
    Protected Const ERR_DeviceNotInitial As Integer = (-4)   '// Cards not be initialized
    Protected Const ERR_NoDeviceFound As Integer = (-5)    '// Cards not found(No card in your system)
    Protected Const ERR_CardIdDuplicate As Integer = (-6) '	// Cards' ID is duplicated. 
    Protected Const ERR_DeviceAlreadyInitialed As Integer = (-7) '	// Cards have been initialed 
    Protected Const ERR_InterruptNotEnable As Integer = (-8) '	// Cards' interrupt events not enable or not be initialized
    Protected Const ERR_TimeOut As Integer = (-9)    '// Function time out
    Protected Const ERR_ParametersInvalid As Integer = (-10) '	// Function input parameters are invalid
    Protected Const ERR_SetEEPROM As Integer = (-11)  '// Set data to EEPROM (or nonvolatile memory) failed
    Protected Const ERR_GetEEPROM As Integer = (-12)  '// Get data from EEPROM (or nonvolatile memory) failed
    Protected Const ERR_FunctionNotAvailable As Integer = (-13) '	// Function is not available in this step, The device is not support this function or Internal process failed
    Protected Const ERR_FirmwareError As Integer = (-14)   '// Firmware error, please reboot the system
    Protected Const ERR_CommandInProcess As Integer = (-15)   '// Previous command is in process
    Protected Const ERR_AxisIdDuplicate As Integer = (-16) '	// Axes' ID is duplicated.
    Protected Const ERR_ModuleNotFound As Integer = (-17)  ' // Slave module not found.
    Protected Const ERR_InsufficientModuleNo As Integer = (-18)  '// System ModuleNo insufficiently
    Protected Const ERR_HandShakeFailed As Integer = (-19)   '// HandSake with the DSP out of time.
    Protected Const ERR_FILE_FORMAT As Integer = (-20)  '// Config file format error.(cannot be parsed)
    Protected Const ERR_ParametersReadOnly As Integer = (-21)   '// Function parameters read only.
    Protected Const ERR_DistantNotEnough As Integer = (-22)  '// Distant is not enough for motion.
    Protected Const ERR_FunctionNotEnable As Integer = (-23)   '// Function is not enabled.
    Protected Const ERR_ServerAlreadyClose As Integer = (-24)  '// Server already closed.
    Protected Const ERR_DllNotFound As Integer = (-25)  '// Related dll is not found, not in correct path.
    Protected Const ERR_TrimDAC_Channel As Integer = (-26)
    Protected Const ERR_Satellite_Type As Integer = (-27)
    Protected Const ERR_Over_Voltage_Spec As Integer = (-28)
    Protected Const ERR_Over_Current_Spec As Integer = (-29)
    Protected Const ERR_SlaveIsNotAI As Integer = (-30)
    Protected Const ERR_Over_AO_Channel_Scope As Integer = (-31)
    Protected Const ERR_DllFuncFailed As Integer = (-32)    '// Failed to invoke dll function. Extension Dll version is wrong.
    Protected Const ERR_FeederAbnormalStop As Integer = (-33) '//Feeder abnormal stop, External stop or feeding stop
    Protected Const ERR_Read_ModuleType_Dismatch As Integer = (-34)
    Protected Const ERR_Win32Error As Integer = (-1000) '// No such INT number, or WIN32_API error, contact with ADLINK's FAE staff.
    Protected Const ERR_DspStart As Integer = (-2000) '// The base for DSP error

    '  Copyright  Lib "APS168.dll" (C) 1995-2009 Adlink Technology INC.
    '  All rights reserved.
    'APS type_def+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    Protected Structure STR_SAMP_DATA_4CH
        Dim tick As Short
        Dim data_0 As Short 'Total channel = 4
        Dim data_1 As Short 'Total channel = 4
        Dim data_2 As Short 'Total channel = 4
        Dim data_3 As Short 'Total channel = 4
    End Structure

    Protected Structure STR_SAMP_DATA_8CH
        Dim tick As Int32
        Dim data_0 As Int32 'Total channel = 4
        Dim data_1 As Int32 'Total channel = 4
        Dim data_2 As Int32 'Total channel = 4
        Dim data_3 As Int32 'Total channel = 4
        Dim data_4 As Int32 'Total channel = 4
        Dim data_5 As Int32 'Total channel = 4
        Dim data_6 As Int32 'Total channel = 4
        Dim data_7 As Int32 'Total channel = 4
    End Structure

    Protected Structure MOVE_PARA 'Speed pattern
        Dim i16_accType As Short 'Axis parameter
        Dim i16_decType As Short 'Axis parameter
        Dim i32_acc As Integer 'Axis parameter
        Dim i32_dec As Integer 'Axis parameter
        Dim i32_initSpeed As Integer 'Axis parameter
        Dim i32_maxSpeed As Integer 'Axis parameter
        Dim i32_endSpeed As Integer 'Axis parameter
    End Structure

    Protected Structure POINT_DATA
        Dim i32_pos As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse)
        Dim i16_accType As Short ' Acceleration pattern 0: T-curve,  1: S-curve
        Dim i16_decType As Short ' Deceleration pattern 0: T-curve,  1: S-curve
        Dim i32_acc As Integer ' Acceleration rate  Lib "APS168.dll" ( pulse / ss )
        Dim i32_dec As Integer ' Deceleration rate  Lib "APS168.dll" ( pulse / ss )
        Dim i32_initSpeed As Integer ' Start velocity         Lib "APS168.dll" ( pulse / s )
        Dim i32_maxSpeed As Integer ' Maximum velocity   Lib "APS168.dll" ( pulse / s )
        Dim i32_endSpeed As Integer ' End velocity           Lib "APS168.dll" ( pulse / s )
        Dim i32_angle As Integer ' Arc move angle     Lib "APS168.dll" ( degree, -360 ~ 360 )
        Dim u32_dwell As Integer ' Dwell times        Lib "APS168.dll" ( unit: ms )
        Dim i32_opt As Integer ' Option '0xABCD , D:0 absolute, 1:relative
    End Structure

    Protected Structure POINT_DATA_EX
        Dim i32_pos As Integer         '//(Center)Position data (could be relative or absolute value) 
        Dim i16_accType As Short       '//Acceleration pattern 0: T curve, 1:S curve   
        Dim i16_decType As Short       '// Deceleration pattern 0: T curve, 1:S curve 
        Dim i32_acc As Integer           '  //Acceleration rate ( pulse / sec 2 ) 
        Dim i32_dec As Integer          '   //Deceleration rate ( pulse / sec 2  ) 
        Dim i32_initSpeed As Integer   '  //Start velocity ( pulse / s ) 
        Dim i32_maxSpeed As Integer  '//Maximum velocity    ( pulse / s ) 
        Dim i32_endSpeed As Integer   '//End velocity  ( pulse / s )     
        Dim i32_angle As Integer         ' //Arc move angle ( degree, -360 ~ 360 ) 
        Dim u32_dwell As Integer         '//dwell times ( unit: ms ) *Divided by system cycle time. 
        Dim i32_opt As Integer           '//Point move option. (*) 
        Dim i32_pitch As Integer               '// pitch for helical move
        Dim i32_totalheight As Integer   '// total hight
        Dim i16_cw As Short                    '// cw or ccw
        Dim i16_opt_ext As Short             '// option extend
    End Structure

    Protected Structure POINT_DATA2
        Dim i32_pos_0 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_1 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_2 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_3 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_4 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_5 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_6 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_7 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_8 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_9 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_10 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_11 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_12 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_13 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_14 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_pos_15 As Integer ' Position data  Lib "APS168.dll" (relative or absolute)  Lib "APS168.dll" (pulse) , Arraysize = 16
        Dim i32_initSpeed As Integer ' Start velocity         Lib "APS168.dll" ( pulse / s )
        Dim i32_maxSpeed As Integer ' Maximum velocity   Lib "APS168.dll" ( pulse / s )
        Dim i32_angle As Integer ' Arc move angle     Lib "APS168.dll" ( degree, -360 ~ 360 )
        Dim u32_dwell As Integer ' Dwell times        Lib "APS168.dll" ( unit: ms )
        Dim i32_opt As Integer ' Option '0xABCD , D:0 absolute, 1:relative
    End Structure


    Protected Structure POINT_DATA3
        Dim i32_pos_0 As Integer
        Dim i32_pos_1 As Integer
        Dim i32_pos_2 As Integer
        Dim i32_pos_3 As Integer
        Dim i32_maxSpeed As Integer

        Dim i32_endPos_0 As Integer
        Dim i32_endPos_1 As Integer

        Dim i32_dir As Integer
        Dim i32_opt As Integer
    End Structure

    Protected Structure JOG_DATA
        Dim i16_jogMode As Short ' Jog mode. 0:Free running mode, 1:Step mode
        Dim i16_dir As Short ' Jog direction. 0:positive, 1:negative direction
        Dim i16_accType As Short ' Acceleration pattern 0: T-curve,  1: S-curve
        Dim i32_acc As Integer ' Acceleration rate  Lib "APS168.dll" ( pulse / ss )
        Dim i32_dec As Integer ' Deceleration rate  Lib "APS168.dll" ( pulse / ss )
        Dim i32_maxSpeed As Integer ' Positive value, maximum velocity   Lib "APS168.dll" ( pulse / s )
        Dim i32_offset As Integer ' Positive value, a step  Lib "APS168.dll" (pulse)
        Dim i32_delayTime As Integer ' Delay time,  Lib "APS168.dll" ( range: 0 ~ 65535 millisecond, align by cycle time)
    End Structure

    Protected Structure HOME_PARA
        Dim u8_homeMode As Byte
        Dim u8_homeDir As Byte
        Dim u8_curveType As Byte
        Dim i32_orgOffset As Integer
        Dim i32_acceleration As Integer
        Dim i32_startVelocity As Integer
        Dim i32_maxVelocity As Integer
        Dim i32_OrgVelocity As Integer
    End Structure

    Protected Structure FILTER_COEF
        Dim a1 As Double ' Biquad filter output polynomial coefficient
        Dim a2 As Double ' Biquad filter output polynomial coefficient
        Dim b0 As Double ' Biquad filter input polynomial coefficient
        Dim b1 As Double ' Biquad filter input polynomial coefficient
        Dim b2 As Double ' Biquad filter input polynomial coefficient
    End Structure
    Protected Structure POS_DATA_2D
        Dim u32_opt As Integer         'option, [0x00000000,0xFFFFFFFF]
        Dim i32_x As Integer           ' x-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_y As Integer           'y-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_theta As Integer       'x-y plane arc move angle  Lib "APS168.dll" (0.001 degree), [-360000,360000]
    End Structure

    Protected Structure PNT_DATA_2D
        Dim u32_opt As Integer        ' option, [0x00000000,0xFFFFFFFF]
        Dim i32_x As Integer          ' x-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_y As Integer          ' y-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_theta As Integer      ' x-y plane arc move angle  Lib "APS168.dll" (0.001 degree), [-360000,360000]
        Dim i32_acc As Integer        ' acceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_dec As Integer        ' deceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_vi As Integer         ' initial velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_vm As Integer         ' maximum velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_ve As Integer         ' ending velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
    End Structure

    Protected Structure PNT_DATA_2D_F64
        Dim u32_opt As Integer        '// option, [0x00000000,0xFFFFFFFF]
        Dim f64_x As Double          '// x-axis component (pulse), [-2147483648,2147484647]
        Dim f64_y As Double          '// y-axis component (pulse), [-2147483648,2147484647]
        Dim f64_theta As Double      '// x-y plane arc move angle (0.000001 degree), [-360000,360000]
        Dim f64_acc As Double        '// acceleration rate (pulse/ss), [0,2147484647]
        Dim f64_dec As Double        '// deceleration rate (pulse/ss), [0,2147484647]
        Dim f64_vi As Double         '// initial velocity (pulse/s), [0,2147484647]
        Dim f64_vm As Double         '// maximum velocity (pulse/s), [0,2147484647]
        Dim f64_ve As Double         '// ending velocity (pulse/s), [0,2147484647]
        Dim f64_sf As Double             ' // s-factor [0.0 ~ 1.0]
    End Structure
    ' Point table Protected Structure  Lib "APS168.dll" (Four dimension)
    Protected Structure PNT_DATA_4DL
        Dim u32_opt As Integer        ' option, [0x00000000,0xFFFFFFFF]
        Dim i32_x As Integer          ' x-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_y As Integer          ' y-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_z As Integer          ' z-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_u As Integer          ' u-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_acc As Integer        ' acceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_dec As Integer        ' deceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_vi As Integer         ' initial velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_vm As Integer         ' maximum velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_ve As Integer         ' ending velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
    End Structure


    ' Point table Protected Structure  Lib "APS168.dll" (One dimension)
    Protected Structure PNT_DATA
        Dim u32_opt As Integer        ' option, [0x00000000,0xFFFFFFFF]
        Dim i32_x As Integer          ' x-axis component  Lib "APS168.dll" (pulse), [-2147483648,2147484647]
        Dim i32_theta As Integer      ' x-y plane arc move angle  Lib "APS168.dll" (0.001 degree), [-360000,360000]
        Dim i32_acc As Integer        ' acceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_dec As Integer        ' deceleration rate  Lib "APS168.dll" (pulse/ss), [0,2147484647]
        Dim i32_vi As Integer         ' initial velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_vm As Integer         ' maximum velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
        Dim i32_ve As Integer         ' ending velocity  Lib "APS168.dll" (pulse/s), [0,2147484647]
    End Structure
    '//Asynchronized call
    Protected Structure ASYNCALL
        'HANDLE	h_event; // IntPtr
        Dim h_event As IntPtr
        Dim i32_ret As Integer
    End Structure
    Protected Structure TSK_INFO
        Dim State As UShort
        Dim RunTimeErr As UShort
        Dim IP As UShort
        Dim SP As UShort
        Dim BP As UShort
        Dim MsgQueueSts As UShort
    End Structure
    Protected Structure VAO_DATA
        'Param
        Dim outputType As Integer 'Output type, [0, 3]
        Dim inputType As Integer 'Input type, [0, 1]
        Dim config As Integer 'PWM configuration according to output type
        Dim inputSrc As Integer 'Input source by axis, [0, 0xf]
        'Mapping table
        Dim minVel As Integer 'Minimum linear speed, [ positive ]
        Dim velInterval As Integer 'Speed interval, [ positive ]
        Dim totalPoints As Integer 'Total points, [1, 32]
        Dim mappingDataArr_0 As Integer 'mapping data array
        Dim mappingDataArr_1 As Integer 'mapping data array
        Dim mappingDataArr_2 As Integer 'mapping data array
        Dim mappingDataArr_3 As Integer 'mapping data array
        Dim mappingDataArr_4 As Integer 'mapping data array
        Dim mappingDataArr_5 As Integer 'mapping data array
        Dim mappingDataArr_6 As Integer 'mapping data array
        Dim mappingDataArr_7 As Integer 'mapping data array
        Dim mappingDataArr_8 As Integer 'mapping data array
        Dim mappingDataArr_9 As Integer 'mapping data array
        Dim mappingDataArr_10 As Integer 'mapping data array
        Dim mappingDataArr_11 As Integer 'mapping data array
        Dim mappingDataArr_12 As Integer 'mapping data array
        Dim mappingDataArr_13 As Integer 'mapping data array
        Dim mappingDataArr_14 As Integer 'mapping data array
        Dim mappingDataArr_15 As Integer 'mapping data array
        Dim mappingDataArr_16 As Integer 'mapping data array
        Dim mappingDataArr_17 As Integer 'mapping data array
        Dim mappingDataArr_18 As Integer 'mapping data array
        Dim mappingDataArr_19 As Integer 'mapping data array
        Dim mappingDataArr_20 As Integer 'mapping data array
        Dim mappingDataArr_21 As Integer 'mapping data array
        Dim mappingDataArr_22 As Integer 'mapping data array
        Dim mappingDataArr_23 As Integer 'mapping data array
        Dim mappingDataArr_24 As Integer 'mapping data array
        Dim mappingDataArr_25 As Integer 'mapping data array
        Dim mappingDataArr_26 As Integer 'mapping data array
        Dim mappingDataArr_27 As Integer 'mapping data array
        Dim mappingDataArr_28 As Integer 'mapping data array
        Dim mappingDataArr_29 As Integer 'mapping data array
        Dim mappingDataArr_30 As Integer 'mapping data array
        Dim mappingDataArr_31 As Integer 'mapping data array

    End Structure

    Protected Const MAX_SAMPL_CH = (8)
    Protected Const MAX_SAMPL_SRC = (2)

    Public Structure SAMP_PARAM
        Dim rate As Integer             '//Sampling rate
        Dim edge As Integer             '//Trigger edge
        Dim level As Integer            '//Trigger level
        Dim trigCh As Integer           '//Trigger channel
        Dim sourceByCh_0_0 As Integer
        Dim sourceByCh_0_1 As Integer
        Dim sourceByCh_1_0 As Integer
        Dim sourceByCh_1_1 As Integer
        Dim sourceByCh_2_0 As Integer
        Dim sourceByCh_2_1 As Integer
        Dim sourceByCh_3_0 As Integer
        Dim sourceByCh_3_1 As Integer
        Dim sourceByCh_4_0 As Integer
        Dim sourceByCh_4_1 As Integer
        Dim sourceByCh_5_0 As Integer
        Dim sourceByCh_5_1 As Integer
        Dim sourceByCh_6_0 As Integer
        Dim sourceByCh_6_1 As Integer
        Dim sourceByCh_7_0 As Integer
        Dim sourceByCh_7_1 As Integer
        '//Sampling source by channel, named sourceByCh[a][b], 
        '//a: Channel
        '//b: 0: Sampling source 1: Sampling axis
        '//Sampling source: F64 data occupies two channel, I32 data occupies one channel.
    End Structure

    Protected Const MAX_PT_DIM = (6)

    Protected Structure PTINFO
        Dim Dimension As Integer
        'Dim AxisArr%(MAX_PT_DIM) As Integer
        Dim AxisArr_0 As Integer
        Dim AxisArr_1 As Integer
        Dim AxisArr_2 As Integer
        Dim AxisArr_3 As Integer
        Dim AxisArr_4 As Integer
        Dim AxisArr_5 As Integer
    End Structure

    Protected Structure PTDWL
        Dim DwTime As Double '//Unit is ms
    End Structure

    Protected Structure PTLINE
        Dim Dimension As Integer
        'Dim Pos#(MAX_PT_DIM) As Double
        Dim Pos_0 As Double
        Dim Pos_1 As Double
        Dim Pos_2 As Double
        Dim Pos_3 As Double
        Dim Pos_4 As Double
        Dim Pos_5 As Double
    End Structure

    Protected Const MAXHEXLIX = &H3 'Helix axes is 3.
    Protected Const MAXARC3 = &H3 'ARC3 axes is 3.
    Protected Const MAXARC2 = &H2 'ARC2 axes is 2.

    Protected Structure PTA2CA
        'Dim Index(MAXARC2) As Byte 'Index X,Y
        Dim Index_0 As Byte
        Dim Index_1 As Byte
        'Dim Center#(MAXARC2) As Double 'Center Arr
        Dim Center_0 As Double
        Dim Center_1 As Double
        Dim Angle As Double 'Angle
    End Structure

    Protected Structure PTA2CE
        'Dim Index(MAXARC2) As Byte 'Index X,Y
        Dim index_0 As Byte
        Dim index_1 As Byte
        'Dim Center#(MAXARC2) As Double
        Dim Center_0 As Double
        Dim Center_1 As Double
        'Dim End_pos(MAXARC2) As Double
        Dim End_pos_0 As Double
        Dim End_pos_1 As Double
        Dim Dir As Short
    End Structure
    Protected Structure PTA3CA
        'Dim Index(MAXARC3) As Byte 'Index X,Y
        Dim Index_0 As Byte
        Dim Index_1 As Byte
        Dim Index_2 As Byte
        'Dim Center#(MAXARC3) As Double 'Center Arr
        Dim Center_0 As Double
        Dim Center_1 As Double
        Dim Center_2 As Double
        'Dim Noraml(MAXARC3) As Double 'Normal Arr
        Dim Noraml_0 As Double
        Dim Noraml_1 As Double
        Dim Noraml_2 As Double
        Dim Angle As Double 'Angle
    End Structure

    Protected Structure PTA3CE
        'Dim Index(MAXARC3) As Byte 'Index X,Y
        Dim index_0 As Byte
        Dim index_1 As Byte
        Dim index_2 As Byte
        'Dim Center#(MAXARC3) As Double
        Dim Center_0 As Double
        Dim Center_1 As Double
        Dim Center_2 As Double
        'Dim End_pos(MAXARC3) As Double
        Dim End_pos_0 As Double
        Dim End_pos_1 As Double
        Dim End_pos_2 As Double
        Dim Dir As Short
    End Structure

    Protected Structure PTHCA
        'Dim Index(MAXHEXLIX) As Byte 'Index X,Y
        Dim Index_0 As Byte
        Dim Index_1 As Byte
        Dim Index_2 As Byte
        'Dim Center(MAXHEXLIX) As Double 'Center Arr
        Dim Center_0 As Double
        Dim Center_1 As Double
        Dim Center_2 As Double
        'Dim Noraml(MAXHEXLIX) As Double 'Normal Arr
        Dim Noraml_0 As Double
        Dim Noraml_1 As Double
        Dim Noraml_2 As Double
        Dim Angle As Double 'Angle
        Dim DeltaH As Double
        Dim FinalR As Double
    End Structure

    Protected Structure PTHCE
        'Dim Index(MAXHEXLIX) As Byte 'Index X,Y
        Dim Index_0 As Byte
        Dim Index_1 As Byte
        Dim Index_2 As Byte
        'Dim Center(MAXHEXLIX) As Double 'Center Arr
        Dim Center_0 As Double
        Dim Center_1 As Double
        Dim Center_2 As Double
        'Dim Noraml(MAXHEXLIX) As Double 'Normal Arr
        Dim Noraml_0 As Double
        Dim Noraml_1 As Double
        Dim Noraml_2 As Double
        'Dim End_pos(MAXHEXLIX) As Double 'End Arr
        Dim End_pos_0 As Double
        Dim End_pos_1 As Double
        Dim End_pos_2 As Double
        Dim Dir As Short
    End Structure
    Protected Structure PTSTS
        Dim BitSts As UShort
        'b0: Is PTB work? [1:working, 0:Stopped]
        'b1: Is point buffer full? [1:full, 0:not full]
        'b2: Is point buffer empty? [1:empty, 0:not empty]
        'b3, b4, b5: Reserved for future
        'b6~: Be always 0
        Dim PntBufFreeSpace As UShort
        Dim PntBufUsageSpace As UShort
        Dim RunningCnt As UInteger
    End Structure

    Protected Structure LPSTS
        Dim MotionLoopLoading As UInteger
        Dim HostLoopLoading As UInteger
        Dim MotionLoopLoadingMax As UInteger
        Dim HostLoopLoadingMax As UInteger
    End Structure

    Protected Structure DEBUG_DATA
        Dim ServoOffCondition As UInteger
        Dim DspCmdPos As Double
        Dim DspFeedbackPos As Double
        Dim FpgaCmdPos As Double
        Dim FpgaFeedbackPos As Double
        Dim FpgaOutputVoltage As Double
    End Structure

    Protected Structure DEBUG_STATE
        Dim AxisState As UInteger
        Dim GroupState As UInteger
        Dim AxisSuperState As UInteger
    End Structure

    'New ADCNC Protected Structure define
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Protected Structure POS_DATA_2D_F64
        ' This Protected Structure extends original point data contents from "I32" to "F64" 
        'for internal computation. It's important to prevent data overflow.

        Dim u32_opt As UInteger        '// option, [0x00000000, 0xFFFFFFFF]
        Dim f64_x As Double          '// x-axis component (pulse), [-9223372036854775808, 9223372036854775807]
        Dim f64_y As Double          '// y-axis component (pulse), [-9223372036854775808, 9223372036854775807]
        Dim f64_theta As Double      '// x-y plane arc move angle (0.000001 degree), [-360000, 360000]
    End Structure

    Protected Structure POS_DATA_2D_RPS
        '/* This Protected Structure adds another variable to record what point was be saved */		
        Dim u32_opt As UInteger        '// option, [0x00000000, 0xFFFFFFFF]
        Dim i32_x As Integer          '// x-axis component (pulse), [-2147483648, 2147483647]
        Dim i32_y As Integer          '// y-axis component (pulse), [-2147483648, 2147483647]
        Dim i32_theta As Integer      '// x-y plane arc move angle (0.000001 degree), [-360000, 360000]
        Dim crpi As UInteger                  '// current reading point index
    End Structure

    Protected Structure POS_DATA_2D_F64_RPS
        '/* This Protected Structure adds another variable to record what point was be saved */
        Dim u32_opt As UInteger        '// option, [0x00000000, 0xFFFFFFFF]
        Dim f64_x As Double          '// x-axis component (pulse), [-2147483648, 2147483647]
        Dim f64_y As Double          '// y-axis component (pulse), [-2147483648, 2147483647]
        Dim f64_theta As Double      '// x-y plane arc move angle (0.000001 degree), [-360000, 360000]
        Dim crpi As UInteger           '// current reading point index
    End Structure

    Protected Structure PNT_DATA_2D_EXT
        Dim u32_opt As UInteger        '// option, [0x00000000,0xFFFFFFFF]
        Dim f64_x As Double          '// x-axis component (pulse), [-2147483648,2147484647]
        Dim f64_y As Double         ' // y-axis component (pulse), [-2147483648,2147484647]
        Dim f64_theta As Double     ' // x-y plane arc move angle (0.000001 degree), [-360000,360000]  
        Dim f64_acc_0 As Double     '   // acceleration rate (pulse/ss), [0,2147484647]
        Dim f64_acc_1 As Double     '   // acceleration rate (pulse/ss), [0,2147484647]
        Dim f64_acc_2 As Double     '   // acceleration rate (pulse/ss), [0,2147484647]
        Dim f64_acc_3 As Double     '   // acceleration rate (pulse/ss), [0,2147484647]

        Dim f64_dec_0 As Double      '  // deceleration rate (pulse/ss), [0,2147484647]
        Dim f64_dec_1 As Double      '  // deceleration rate (pulse/ss), [0,2147484647]
        Dim f64_dec_2 As Double      '  // deceleration rate (pulse/ss), [0,2147484647]
        Dim f64_dec_3 As Double      '  // deceleration rate (pulse/ss), [0,2147484647]
        Dim crossover As Integer
        Dim Iboundary As Integer   '	// initial boundary
        Dim f64_vi_0 As Double   '   // initial velocity (pulse/s), [0,2147484647]
        Dim f64_vi_1 As Double   '   // initial velocity (pulse/s), [0,2147484647]
        Dim f64_vi_2 As Double   '   // initial velocity (pulse/s), [0,2147484647]
        Dim f64_vi_3 As Double   '   // initial velocity (pulse/s), [0,2147484647]
        Dim vi_cmpr As UInteger
        Dim f64_vm_0 As Double     ' // maximum velocity (pulse/s), [0,2147484647]
        Dim f64_vm_1 As Double     ' // maximum velocity (pulse/s), [0,2147484647]
        Dim f64_vm_2 As Double     ' // maximum velocity (pulse/s), [0,2147484647]
        Dim f64_vm_3 As Double     ' // maximum velocity (pulse/s), [0,2147484647]
        Dim vm_cmpr As UInteger
        Dim f64_ve_0 As Double      '// ending velocity (pulse/s), [0,2147484647]
        Dim f64_ve_1 As Double      '// ending velocity (pulse/s), [0,2147484647]
        Dim f64_ve_2 As Double      '// ending velocity (pulse/s), [0,2147484647]
        Dim f64_ve_3 As Double      '// ending velocity (pulse/s), [0,2147484647]
        Dim ve_cmpr As UInteger
        Dim Eboundary As Integer       '// end boundary
        Dim f64_dist As Double        '// point distance
        Dim f64_angle As Double        '// path angle between previous & current point
        Dim f64_radius As Double      '// point radiua (used in arc move)
        Dim i32_arcstate As Integer
        Dim spt As UInteger           '// speed profile type

        '// unit time measured by DSP sampling period
        Dim t_0 As Double
        Dim t_1 As Double
        Dim t_2 As Double
        Dim t_3 As Double

        '// Horizontal & Vertical line flag
        Dim HorizontalFlag As Integer
        Dim VerticalFlag As Integer
    End Structure
    ' //**********************************************
    '// New header functions; 20151102
    '//**********************************************
    Structure MCMP_POINT
        Dim axisX As Double '// x axis data for multi-dimension comparator 0
        Dim axisY As Double '// y axis data for multi-dimension comparator 1
        Dim axisZ As Double '// z axis data for multi-dimension comparator 2
        Dim axisU As Double '// u axis data for multi-dimension comparator 3
        Dim chInBit As Integer '// pwm output channel in bit format; 20150609
    End Structure
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


    'APS Library+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    '  System & Initialization
    Protected Declare Function APS_initial Lib "APS168.dll" (ByRef BoardID_InBits As Integer, ByVal Mode As Integer) As Integer
    Protected Declare Function APS_close Lib "APS168.dll" () As Integer
    Protected Declare Function APS_version Lib "APS168.dll" () As Integer
    Protected Declare Function APS_device_driver_version Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_get_axis_info Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Board_ID As Integer, ByRef Axis_No As Integer, ByRef Port_ID As Integer, ByRef Module_ID As Integer) As Integer
    Protected Declare Function APS_set_board_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BOD_Param_No As Integer, ByVal BOD_Param As Integer) As Integer
    Protected Declare Function APS_get_board_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BOD_Param_No As Integer, ByRef BOD_Param As Integer) As Integer
    Protected Declare Function APS_set_axis_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal AXS_Param_No As Integer, ByVal AXS_Param As Integer) As Integer
    Protected Declare Function APS_get_axis_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal AXS_Param_No As Integer, ByRef AXS_Param As Integer) As Integer
    Protected Declare Function APS_get_system_timer Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef SysTimer As Integer) As Integer
    Protected Declare Function APS_get_device_info Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Info_No As Integer, ByRef Info As Integer) As Integer
    Protected Declare Function APS_get_card_name Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef CardName As Integer) As Integer
    Protected Declare Function APS_disable_device Lib "APS168.dll" (ByVal DeviceName As Integer) As Integer
    Protected Declare Function APS_get_first_axisId Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef StartAxisID As Integer, ByRef TotalAxisNum As Integer) As Integer
    Protected Declare Function APS_set_security_key Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal OldPassword As Integer, ByVal NewPassword As Integer) As Integer
    Protected Declare Function APS_check_security_key Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Password As Integer) As Integer
    Protected Declare Function APS_reset_security_key Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_load_param_from_file Lib "APS168.dll" (ByVal pXMLFile As String) As Integer
    'Virtual board settings  [Only for PCI-8254/8]
    Protected Declare Function APS_register_virtual_board Lib "APS168.dll" (ByVal VirCardIndex As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_virtual_board_info Lib "APS168.dll" (ByVal VirCardIndex As Integer, ByRef Enable As Integer) As Integer
    'Parameters setting by float [Only for PCI-8254/8]
    Protected Declare Function APS_set_axis_param_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal AXS_Param_No As Integer, ByVal AXS_Param As Double) As Integer
    Protected Declare Function APS_get_axis_param_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal AXS_Param_No As Integer, ByRef AXS_Param As Double) As Integer
    'Control driver mode [Only for PCI-8254/8]
    Protected Declare Function APS_get_curr_sys_ctrl_mode Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Mode As Integer) As Integer
    '  Flash function [Only for PCI-8253/56, PCI-8392 Lib "APS168.dll" (H)]
    Protected Declare Function APS_save_parameter_to_flash Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_load_parameter_from_flash Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_load_parameter_from_default Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    '
    '  SSCNET-3 functions [Only for PCI-8392 Lib "APS168.dll" (H)]
    Protected Declare Function APS_start_sscnet Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef AxisFound_InBits As Integer) As Integer
    Protected Declare Function APS_stop_sscnet Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_get_sscnet_servo_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Para_No1 As Integer, ByRef Para_Dat1 As Integer, ByVal Para_No2 As Integer, ByRef Para_Dat2 As Integer) As Integer
    Protected Declare Function APS_set_sscnet_servo_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Para_No1 As Integer, ByVal Para_Dat1 As Integer, ByVal Para_No2 As Integer, ByVal Para_Dat2 As Integer) As Integer
    Protected Declare Function APS_get_sscnet_servo_alarm Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Alarm_No As Integer, ByRef Alarm_Detail As Integer) As Integer
    Protected Declare Function APS_reset_sscnet_servo_alarm Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_save_sscnet_servo_param Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_get_sscnet_servo_abs_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Cyc_Cnt As Integer, ByRef Res_Cnt As Integer) As Integer
    Protected Declare Function APS_save_sscnet_servo_abs_position Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_load_sscnet_servo_abs_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Abs_Option As Integer, ByRef Cyc_Cnt As Integer, ByRef Res_Cnt As Integer) As Integer
    Protected Declare Function APS_get_sscnet_link_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Link_Status As Integer) As Integer
    Protected Declare Function APS_set_sscnet_servo_monitor_src Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mon_No As Integer, ByVal Mon_Src As Integer) As Integer
    Protected Declare Function APS_get_sscnet_servo_monitor_src Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mon_No As Integer, ByRef Mon_Src As Integer) As Integer
    Protected Declare Function APS_get_sscnet_servo_monitor_data Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Arr_Size As Integer, ByRef Data_Arr As Integer) As Integer
    Protected Declare Function APS_set_sscnet_control_mode Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mode As Integer) As Integer
    Protected Declare Function APS_set_sscnet_abs_enable Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Mode As Integer) As Integer
    Protected Declare Function APS_set_sscnet_abs_enable_by_axis Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mode As Integer) As Integer
    '  Motion IO & motion status
    Protected Declare Function APS_get_command Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef CommandCnt As Integer) As Integer
    Protected Declare Function APS_set_command Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal CommandCnt As Integer) As Integer
    Protected Declare Function APS_motion_status Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_motion_io_status Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_set_servo_on Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Servo_On As Integer) As Integer
    Protected Declare Function APS_get_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Position As Integer) As Integer
    Protected Declare Function APS_set_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Position As Integer) As Integer
    Protected Declare Function APS_get_command_velocity Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Velocity As Integer) As Integer
    Protected Declare Function APS_get_feedback_velocity Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Velocity As Integer) As Integer
    Protected Declare Function APS_get_error_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Err_Pos As Integer) As Integer
    Protected Declare Function APS_get_target_position Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Targ_Pos As Integer) As Integer
    ' Monitor functions by float [Only for PCI-8254/8]
    Protected Declare Function APS_get_command_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Command As Double) As Integer
    Protected Declare Function APS_set_command_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Command As Double) As Integer
    Protected Declare Function APS_get_position_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Position As Double) As Integer
    Protected Declare Function APS_set_position_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Position As Double) As Integer
    Protected Declare Function APS_get_command_velocity_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Velocity As Double) As Integer
    Protected Declare Function APS_get_target_position_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Targ_Pos As Double) As Integer
    Protected Declare Function APS_get_error_position_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Err_Pos As Double) As Integer
    Protected Declare Function APS_get_feedback_velocity_f Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Velocity As Double) As Integer
    'Motion queue status [Only for PCI-8254/8]
    Protected Declare Function APS_get_mq_free_space Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Space As Integer) As Integer
    Protected Declare Function APS_get_mq_usage Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Usage As Integer) As Integer
    'Motion Stop Code [Only for PCI-8254/8]
    Protected Declare Function APS_get_stop_code Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Code As Integer) As Integer
    '
    '  Single axis motion
    Protected Declare Function APS_relative_move Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Distance As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_absolute_move Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Position As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_velocity_move Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_home_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_stop_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_emg_stop Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_relative_move2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Distance As Integer, ByVal Start_Speed As Integer, ByVal Max_Speed As Integer, ByVal End_Speed As Integer, ByVal Acc_Rate As Integer, ByVal Dec_Rate As Integer) As Integer
    Protected Declare Function APS_absolute_move2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Position As Integer, ByVal Start_Speed As Integer, ByVal Max_Speed As Integer, ByVal End_Speed As Integer, ByVal Acc_Rate As Integer, ByVal Dec_Rate As Integer) As Integer
    Protected Declare Function APS_home_move2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Driection As Integer, ByVal Acc As Integer, ByVal Start_Speed As Integer, ByVal Max_Speed As Integer, ByVal ORG_Speed As Integer) As Integer
    Protected Declare Function APS_home_escape Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer

    ' JOG functions [Only for PCI-8392, PCI-8253/56]
    Protected Declare Function APS_set_jog_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef pStr_Jog As JOG_DATA, ByVal Mask As Integer) As Integer
    Protected Declare Function APS_get_jog_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef pStr_Jog As JOG_DATA) As Integer
    Protected Declare Function APS_jog_mode_switch Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Turn_No As Integer) As Integer
    Protected Declare Function APS_jog_start Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal STA_On As Integer) As Integer
    '
    '  Interpolation
    Protected Declare Function APS_absolute_linear_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Position_Array As Integer, ByVal Max_Linear_Speed As Integer) As Integer
    Protected Declare Function APS_relative_linear_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Distance_Array As Integer, ByVal Max_Linear_Speed As Integer) As Integer
    Protected Declare Function APS_absolute_arc_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Center_Pos_Array As Integer, ByVal Max_Arc_Speed As Integer, ByVal Angle As Integer) As Integer
    Protected Declare Function APS_relative_arc_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Center_Offset_Array As Integer, ByVal Max_Arc_Speed As Integer, ByVal Angle As Integer) As Integer
    '
    ' Helical interpolation [Only for PCI-8392, PCI-8253/56]
    Protected Declare Function APS_absolute_helix_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Center_Pos_Array As Integer, ByVal Max_Arc_Speed As Integer, ByVal Pitch As Integer, ByVal TotalHeight As Integer, ByVal CwOrCcw As Integer) As Integer
    Protected Declare Function APS_relative_helix_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Center_PosOffset_Array As Integer, ByVal Max_Arc_Speed As Integer, ByVal Pitch As Integer, ByVal TotalHeight As Integer, ByVal CwOrCcw As Integer) As Integer

    ' Circular interpolation( Support 2D and 3D ) [Only for PCI-8392, PCI-8253/56]
    Protected Declare Function APS_absolute_arc_move_3pe Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Pass_Pos_Array As Integer, ByRef End_Pos_Array As Integer, ByVal Max_Arc_Speed As Integer) As Integer
    Protected Declare Function APS_relative_arc_move_3pe Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Pass_PosOffset_Array As Integer, ByRef End_PosOffset_Array As Integer, ByVal Max_Arc_Speed As Integer) As Integer

    '  Interrupt functions
    Protected Declare Function APS_int_enable Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_set_int_factor Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Item_No As Integer, ByVal Factor_No As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_int_factor Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Item_No As Integer, ByVal Factor_No As Integer, ByRef Enable As Integer) As Integer
    Protected Declare Function APS_set_field_bus_int_factor_di Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal bitsOfCheck As Integer) As Integer
    Protected Declare Function APS_get_field_bus_int_factor_di Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef bitsOfCheck As Integer) As Integer
    '//[Only for PCI-7856 motion interrupt]
    Protected Declare Function APS_set_field_bus_int_factor_motion Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Factor_No As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_field_bus_int_factor_motion Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Factor_No As Integer, ByRef Enable As Integer) As Integer
    Protected Declare Function APS_set_field_bus_int_factor_error Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Factor_No As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_field_bus_int_factor_error Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Factor_No As Integer, ByRef Enable As Integer) As Integer
    Protected Declare Function APS_reset_field_bus_int_motion Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_wait_field_bus_error_int_motion Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Time_Out As Integer) As Integer

    Protected Declare Function APS_set_int_factorH Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Item_No As Integer, ByVal Factor_No As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_int_no_to_handle Lib "APS168.dll" (ByVal Int_No As Integer) As Integer

    '
    Protected Declare Function APS_wait_single_int Lib "APS168.dll" (ByVal Int_No As Integer, ByVal Time_Out As Integer) As Integer
    Protected Declare Function APS_wait_multiple_int Lib "APS168.dll" (ByVal Int_Count As Integer, ByRef Int_No_Array As Integer, ByVal Wait_All As Integer, ByVal Time_Out As Integer) As Integer
    Protected Declare Function APS_reset_int Lib "APS168.dll" (ByVal Int_No As Integer) As Integer
    Protected Declare Function APS_set_int Lib "APS168.dll" (ByVal Int_No As Integer) As Integer
    ' [Only for PCI-8154/58]
    Protected Declare Function APS_wait_error_int Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Item_No As Integer, ByVal Time_Out As Integer) As Integer
    '
    '  Sampling functions [Only for PCI-8392, PCI-8253/56]
    Protected Declare Function APS_set_sampling_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal ParaNum As Integer, ByVal ParaDat As Integer) As Integer
    Protected Declare Function APS_get_sampling_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal ParaNum As Integer, ByRef ParaDat As Integer) As Integer
    Protected Declare Function APS_wait_trigger_sampling Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Length As Integer, ByVal PreTrgLen As Integer, ByVal TimeOutMs As Integer, ByRef DataArr As STR_SAMP_DATA_4CH) As Integer
    Protected Declare Function APS_wait_trigger_sampling_async Lib "APS168.dll" (ByVal Board_ID As Object, ByVal Length As Integer, ByVal PreTrgLen As Integer, ByVal TimeOutMs As Integer, ByRef DataArr As STR_SAMP_DATA_4CH) As Integer
    Protected Declare Function APS_get_sampling_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef SampCnt As Integer) As Integer
    Protected Declare Function APS_stop_wait_sampling Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_auto_sampling Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal StartStop As Integer) As Integer
    Protected Declare Function APS_get_sampling_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Length As Integer, ByRef DataArr As STR_SAMP_DATA_4CH, ByRef Status As Integer) As Integer
    '
    ' Sampling functions extension[Only for PCI-82548 for up to 8 channel]
    Protected Declare Function APS_set_sampling_param_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Param As SAMP_PARAM) As Integer
    Protected Declare Function APS_get_sampling_param_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Param As SAMP_PARAM) As Integer
    Protected Declare Function APS_wait_trigger_sampling_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Length As Integer, ByVal PreTrgLen As Integer, ByVal TimeOutMs As Integer, ByRef DataArr As STR_SAMP_DATA_8CH) As Integer
    Protected Declare Function APS_wait_trigger_sampling_async_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Length As Integer, ByVal PreTrgLen As Integer, ByVal TimeOutMs As Integer, ByRef DataArr As STR_SAMP_DATA_8CH) As Integer
    Protected Declare Function APS_get_sampling_data_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Length As Integer, ByRef DataArr As STR_SAMP_DATA_8CH, ByRef Status As Integer) As Integer
    '
    ' DIO & AIO
    Protected Declare Function APS_write_d_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DO_Group As Integer, ByVal DO_Data As Integer) As Integer
    Protected Declare Function APS_read_d_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DO_Group As Integer, ByRef DO_Data As Integer) As Integer
    Protected Declare Function APS_read_d_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DI_Group As Integer, ByRef DI_Data As Integer) As Integer
    'PCI-82548 Only for channel I/O
    Protected Declare Function APS_write_d_channel_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DO_Group As Integer, ByVal Ch_No As Integer, ByVal DO_Data As Integer) As Integer
    Protected Declare Function APS_read_d_channel_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DO_Group As Integer, ByVal Ch_No As Integer, ByRef DO_Data As Integer) As Integer
    Protected Declare Function APS_read_d_channel_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal DI_Group As Integer, ByVal Ch_No As Integer, ByRef DI_Data As Integer) As Integer
    '
    Protected Declare Function APS_read_a_input_value Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Channel_No As Integer, ByRef Convert_Data As Double) As Integer
    Protected Declare Function APS_read_a_input_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Channel_No As Integer, ByRef Raw_Data As Integer) As Integer
    Protected Declare Function APS_write_a_output_value Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Channel_No As Integer, ByVal Convert_Data As Double) As Integer
    Protected Declare Function APS_write_a_output_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Channel_No As Integer, ByVal Raw_Data As Integer) As Integer
    'New AIO [Only for PCI-82548]
    Protected Declare Function APS_read_a_output_value Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Channel_No As Integer, ByRef Convert_Data As Double) As Integer
    '
    ' Point table move
    Protected Declare Function APS_set_point_table Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA) As Integer
    Protected Declare Function APS_get_point_table Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA) As Integer
    Protected Declare Function APS_get_running_point_index Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_get_start_point_index Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_get_end_point_index Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_set_table_move_pause Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Pause_en As Integer) As Integer
    Protected Declare Function APS_set_table_move_repeat Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Repeat_en As Integer) As Integer
    Protected Declare Function APS_get_table_move_repeat_count Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef RepeatCnt As Integer) As Integer
    Protected Declare Function APS_point_table_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal StartIndex As Integer, ByVal EndIndex As Integer) As Integer

    Protected Declare Function APS_set_point_tableEx Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer, ByRef Point As PNT_DATA) As Integer
    Protected Declare Function APS_set_point_tableEx_2D Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Axis_ID_2 As Integer, ByVal Index As Integer, ByRef Point As PNT_DATA_2D) As Integer
    Protected Declare Function APS_set_point_table_4DL Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal Index As Integer, ByRef Point As PNT_DATA_4DL) As Integer

    '//Point table + IO - Pause / Resume
    Protected Declare Function APS_set_table_move_ex_pause Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_set_table_move_ex_rollback Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_set_table_move_ex_resume Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer

    '//Only for PCI-8392 to replace APS_set_point_table & APS_get_point_table
    Protected Declare Function APS_set_point_table_ex Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA_EX) As Integer
    Protected Declare Function APS_get_point_table_ex Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA_EX) As Integer

    '//Point table Feeder (Only for PCI-825x)
    Protected Declare Function APS_set_feeder_group Lib "APS168.dll" (ByVal GroupId As Integer, ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer
    Protected Declare Function APS_get_feeder_group Lib "APS168.dll" (ByVal GroupId As Integer, ByRef Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer
    Protected Declare Function APS_free_feeder_group Lib "APS168.dll" (ByVal GroupId As Integer) As Integer
    Protected Declare Function APS_reset_feeder_buffer Lib "APS168.dll" (ByVal GroupId As Integer) As Integer
    Protected Declare Function APS_set_feeder_point_2D Lib "APS168.dll" (ByVal GroupId As Integer, ByRef PtArray As PNT_DATA_2D, ByVal Size As Integer, ByVal LastFlag As Integer) As Integer
    Protected Declare Function APS_set_feeder_point_2D_ex Lib "APS168.dll" (ByVal GroupId As Integer, ByRef PtArray As PNT_DATA_2D_F64, ByVal Size As Integer, ByVal LastFlag As Integer) As Integer
    Protected Declare Function APS_start_feeder_move Lib "APS168.dll" (ByVal GroupId As Integer) As Integer
    Protected Declare Function APS_get_feeder_status Lib "APS168.dll" (ByVal GroupId As Integer, ByRef State As Integer, ByRef ErrCode As Integer) As Integer
    Protected Declare Function APS_get_feeder_running_index Lib "APS168.dll" (ByVal GroupId As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_get_feeder_feed_index Lib "APS168.dll" (ByVal GroupId As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_set_feeder_ex_pause Lib "APS168.dll" (ByVal GroupId As Integer) As Integer
    Protected Declare Function APS_set_feeder_ex_rollback Lib "APS168.dll" (ByVal GroupId As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_set_feeder_ex_resume Lib "APS168.dll" (ByVal GroupId As Integer) As Integer
    Protected Declare Function APS_set_feeder_cfg_acc_type Lib "APS168.dll" (ByVal GroupId As Integer, ByVal type As Integer) As Integer
    '
    'Point table move2
    Protected Declare Function APS_set_point_table_mode2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mode As Integer) As Integer
    Protected Declare Function APS_set_point_table2 Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA2) As Integer
    Protected Declare Function APS_point_table_continuous_move2 Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer
    Protected Declare Function APS_point_table_single_move2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Index As Integer) As Integer
    Protected Declare Function APS_get_running_point_index2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Index As Integer) As Integer
    Protected Declare Function APS_point_table_status2 Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Status As Integer) As Integer
    '
    'Point table Only for HSL-4XMO
    Protected Declare Function APS_set_point_table3 Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal Index As Integer, ByRef Point As POINT_DATA3) As Integer
    Protected Declare Function APS_point_table_move3 Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal StartIndex As Integer, ByVal EndIndex As Integer) As Integer
    Protected Declare Function APS_set_point_table_param3 Lib "APS168.dll" (ByVal FirstAxid As Integer, ByVal ParaNum As Integer, ByVal ParaDat As Integer) As Integer

    'Gantry functions. [Only for PCI-8392, PCI-8253/56]
    Protected Declare Function APS_set_gantry_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal GroupNum As Integer, ByVal ParaNum As Integer, ByVal ParaDat As Integer) As Integer
    Protected Declare Function APS_get_gantry_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal GroupNum As Integer, ByVal ParaNum As Integer, ByRef ParaDat As Integer) As Integer
    Protected Declare Function APS_set_gantry_axis Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal GroupNum As Integer, ByVal Master_Axis_ID As Integer, ByVal Slave_Axis_ID As Integer) As Integer
    Protected Declare Function APS_get_gantry_axis Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal GroupNum As Integer, ByRef Master_Axis_ID As Integer, ByRef Slave_Axis_ID As Integer) As Integer
    Protected Declare Function APS_get_gantry_error Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal GroupNum As Integer, ByRef GentryError As Integer) As Integer
    '
    'Digital filter functions. [Only for PCI-8253/56]
    Protected Declare Function APS_set_filter_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Filter_paramNo As Integer, ByVal param_val As Integer) As Integer
    Protected Declare Function APS_get_filter_param Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Filter_paramNo As Integer, ByRef param_val As Integer) As Integer
    ' Field bus master fucntions For PCI-8392(H)
    Protected Declare Function APS_set_field_bus_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal BUS_Param_No As Integer, ByVal BUS_Param As Integer) As Integer
    Protected Declare Function APS_get_field_bus_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal BUS_Param_No As Integer, ByRef BUS_Param As Integer) As Integer
    Protected Declare Function APS_start_field_bus Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal Start_Axis_ID As Integer) As Integer
    Protected Declare Function APS_stop_field_bus Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer) As Integer
    '
    Protected Declare Function APS_get_field_bus_device_info Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Info_No As Integer, ByRef Info As Integer) As Integer
    Protected Declare Function APS_get_field_bus_last_scan_info Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByRef Info_Array As Integer, ByVal Array_Size As Integer, ByRef Info_Count As Integer) As Integer
    Protected Declare Function APS_get_field_bus_master_type Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByRef BUS_Type As Integer) As Integer
    Protected Declare Function APS_get_field_bus_slave_type Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef MOD_Type As Integer) As Integer
    Protected Declare Function APS_get_field_bus_slave_name Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef MOD_Name As Integer) As Integer
    Protected Declare Function APS_get_field_bus_slave_first_axisno Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef AxisNo As Integer, ByRef TotalAxes As Integer) As Integer
    '
    ' Field bus slave general functions
    Protected Declare Function APS_set_field_bus_slave_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal ParaNum As Integer, ByVal ParaDat As Integer) As Integer
    Protected Declare Function APS_get_field_bus_slave_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal ParaNum As Integer, ByRef ParaDat As Integer) As Integer
    Protected Declare Function APS_get_slave_connect_quality Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef Sts_data As Integer) As Integer
    Protected Declare Function APS_get_slave_online_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef Live As Integer) As Integer
    '
    ' Field bus DIO slave fucntions For PCI-8392(H)
    Protected Declare Function APS_set_field_bus_d_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal DO_Value As Integer) As Integer
    Protected Declare Function APS_get_field_bus_d_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef DO_Value As Integer) As Integer
    Protected Declare Function APS_get_field_bus_d_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef DI_Value As Integer) As Integer
    Protected Declare Function APS_set_field_bus_d_channel_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal DO_Value As Integer) As Integer
    Protected Declare Function APS_get_field_bus_d_channel_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef DO_Value As Integer) As Integer
    Protected Declare Function APS_get_field_bus_d_channel_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef DI_Value As Integer) As Integer
    '
    ' Field bus AIO slave function
    Protected Declare Function APS_set_field_bus_a_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal AO_Value As Double) As Integer
    Protected Declare Function APS_get_field_bus_a_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef AO_Value As Double) As Integer
    Protected Declare Function APS_get_field_bus_a_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef AI_Value As Double) As Integer
    Protected Declare Function APS_get_field_bus_a_input_plc Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef AI_Value As Double, ByVal RunStep As Double) As Integer
    '
    'Field bus Comparing trigger functions
    Protected Declare Function APS_set_field_bus_trigger_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Param_No As Integer, ByVal param_val As Integer) As Integer
    Protected Declare Function APS_get_field_bus_trigger_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Param_No As Integer, ByRef param_val As Integer) As Integer
    Protected Declare Function APS_set_field_bus_trigger_linear Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal LCmpCh As Integer, ByVal StartPoint As Integer, ByVal RepeatTimes As Integer, ByVal Interval As Integer) As Integer
    Protected Declare Function APS_set_field_bus_trigger_table Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TCmpCh As Integer, ByRef DataArr As Integer, ByVal ArraySize As Integer) As Integer
    Protected Declare Function APS_set_field_bus_trigger_manual Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TrgCh As Integer) As Integer
    Protected Declare Function APS_set_field_bus_trigger_manual_s Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TrgChInBit As Integer) As Integer
    Protected Declare Function APS_get_field_bus_trigger_table_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TCmpCh As Integer, ByRef CmpVal As Integer) As Integer
    Protected Declare Function APS_get_field_bus_trigger_linear_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal LCmpCh As Integer, ByRef CmpVal As Integer) As Integer
    Protected Declare Function APS_get_field_bus_trigger_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TrgCh As Integer, ByRef TrgCnt As Integer) As Integer
    Protected Declare Function APS_reset_field_bus_trigger_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TrgCh As Integer) As Integer
    Protected Declare Function APS_get_field_bus_linear_cmp_remain_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal LCmpCh As Integer, ByRef Cnt As Integer) As Integer
    Protected Declare Function APS_get_field_bus_table_cmp_remain_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal TCmpCh As Integer, ByRef Cnt As Integer) As Integer
    Protected Declare Function APS_get_field_bus_encoder Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal EncCh As Integer, ByRef EncCnt As Integer) As Integer
    Protected Declare Function APS_set_field_bus_encoder Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal EncCh As Integer, ByVal EncCnt As Integer) As Integer
    '
    '  Comparing trigger functions
    Protected Declare Function APS_set_trigger_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Param_No As Integer, ByVal param_val As Integer) As Integer
    Protected Declare Function APS_get_trigger_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Param_No As Integer, ByRef param_val As Integer) As Integer
    Protected Declare Function APS_set_trigger_linear Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal LCmpCh As Integer, ByVal StartPoint As Integer, ByVal RepeatTimes As Integer, ByVal Interval As Integer) As Integer
    Protected Declare Function APS_set_trigger_table Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TCmpCh As Integer, ByRef DataArr As Integer, ByVal ArraySize As Integer) As Integer
    Protected Declare Function APS_set_trigger_manual Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer) As Integer
    Protected Declare Function APS_set_trigger_manual_s Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgChInBit As Integer) As Integer
    Protected Declare Function APS_get_trigger_table_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TCmpCh As Integer, ByRef CmpVal As Integer) As Integer
    Protected Declare Function APS_get_trigger_linear_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal LCmpCh As Integer, ByRef CmpVal As Integer) As Integer
    Protected Declare Function APS_get_trigger_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer, ByRef TrgCnt As Integer) As Integer
    Protected Declare Function APS_reset_trigger_count Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer) As Integer
    Protected Declare Function APS_enable_trigger_fifo_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FCmpCh As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_trigger_fifo_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FCmpCh As Integer, ByRef CmpVal As Integer) As Integer
    Protected Declare Function APS_get_trigger_fifo_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FCmpCh As Integer, ByRef FifoSts As Integer) As Integer
    Protected Declare Function APS_set_trigger_fifo_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FCmpCh As Integer, ByRef DataArr As Integer, ByVal ArraySize As Integer, ByVal ShiftFlag As Integer) As Integer
    Protected Declare Function APS_set_trigger_encoder_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer, ByVal TrgCnt As Integer) As Integer
    Protected Declare Function APS_get_trigger_encoder_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer, ByRef TrgCnt As Integer) As Integer
    Protected Declare Function APS_start_timer Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TrgCh As Integer, ByVal Start As Integer) As Integer
    Protected Declare Function APS_get_timer_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TmrCh As Integer, ByRef Cnt As Integer) As Integer
    Protected Declare Function APS_set_timer_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TmrCh As Integer, ByVal Cnt As Integer) As Integer
    '
    ' Multi-Trigger for PCI-8254/58
    Protected Declare Function APS_set_multi_trigger_table Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Dimension As Integer, ByRef DataArr As MCMP_POINT, ByVal ArraySize As Integer, ByVal Window As Integer) As Integer
    Protected Declare Function APS_get_multi_trigger_table_cmp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Dimension As Integer, ByRef DataArr As MCMP_POINT) As Integer
    '
    '  Pulser counter function
    Protected Declare Function APS_get_pulser_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Counter As Integer) As Integer
    Protected Declare Function APS_set_pulser_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Counter As Integer) As Integer
    '  Reserved functions
    Protected Declare Function APS_field_bus_slave_set_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal ParaNum As Integer, ByVal ParaDat As Integer) As Integer
    Protected Declare Function APS_field_bus_slave_get_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal ParaNum As Integer, ByRef ParaDat As Integer) As Integer
    '
    Protected Declare Function APS_field_bus_d_set_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal DO_Value As Integer) As Integer
    Protected Declare Function APS_field_bus_d_get_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef DO_Value As Integer) As Integer
    Protected Declare Function APS_field_bus_d_get_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByRef DI_Value As Integer) As Integer
    '
    Protected Declare Function APS_field_bus_A_set_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByVal AO_Value As Double) As Integer
    Protected Declare Function APS_field_bus_A_get_output Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef AO_Value As Double) As Integer
    Protected Declare Function APS_field_bus_A_get_input Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal BUS_No As Integer, ByVal MOD_No As Integer, ByVal Ch_No As Integer, ByRef AI_Value As Double) As Integer

    ' Dpac Function
    Protected Declare Function APS_rescan_CF Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_get_battery_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Battery_status As Integer) As Integer
    '
    ' DPAC Display & Display Button
    Protected Declare Function APS_get_display_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal displayDigit As Integer, ByRef displayIndex As Integer) As Integer
    Protected Declare Function APS_set_display_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal displayDigit As Integer, ByVal displayIndex As Integer) As Integer
    Protected Declare Function APS_get_button_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef buttonstatus As Integer) As Integer
    '
    ' nv RAM funciton
    Protected Declare Function APS_set_nv_ram Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal RamNo As Integer, ByVal DataWidth As Integer, ByVal Offset As Integer, ByVal data As Integer) As Integer
    Protected Declare Function APS_get_nv_ram Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal RamNo As Integer, ByVal DataWidth As Integer, ByVal Offset As Integer, ByRef data As Integer) As Integer
    Protected Declare Function APS_clear_nv_ram Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal RamNo As Integer) As Integer
    'VAO function(Laser function)
    Protected Declare Function APS_set_vao_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Param_No As Integer, ByVal Param_Val As Integer) As Integer
    Protected Declare Function APS_get_vao_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Param_No As Integer, ByRef Param_Val As Integer) As Integer
    Protected Declare Function APS_set_vao_table Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Table_No As Integer, ByVal MinVelocity As Integer, ByVal VelInterval As Integer, ByVal TotalPoints As Integer, ByVal MappingDataArray() As Integer) As Integer
    Protected Declare Function APS_switch_vao_table Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Table_No As Integer) As Integer
    Protected Declare Function APS_start_vao Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Output_Ch As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_vao_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Status As Integer) As Integer
    Protected Declare Function APS_check_vao_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Table_No As Integer, ByRef Status As Integer) As Integer
    Protected Declare Function APS_set_vao_param_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Table_No As Integer, ByRef VaoData As VAO_DATA) As Integer
    Protected Declare Function APS_get_vao_param_ex Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Table_No As Integer, ByRef VaoData As VAO_DATA) As Integer
    'PWM function
    Protected Declare Function APS_set_pwm_width Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PWM_Ch As Integer, ByVal Width As Integer) As Integer
    Protected Declare Function APS_get_pwm_width Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PWM_Ch As Integer, ByRef Width As Integer) As Integer
    Protected Declare Function APS_set_pwm_frequency Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PWM_Ch As Integer, ByVal Frequency As Integer) As Integer
    Protected Declare Function APS_get_pwm_frequency Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PWM_Ch As Integer, ByRef Frequency As Integer) As Integer
    Protected Declare Function APS_set_pwm_on Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PWM_Ch As Integer, ByVal PWM_On As Integer) As Integer

    'Simultaneous move [Only for MNET series and 8392]
    Protected Declare Function APS_set_relative_simultaneous_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Distance_Array As Integer, ByRef Max_Speed_Array As Integer) As Integer
    Protected Declare Function APS_set_absolute_simultaneous_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Position_Array As Integer, ByRef Max_Speed_Array As Integer) As Integer
    Protected Declare Function APS_start_simultaneous_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_stop_simultaneous_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_set_velocity_simultaneous_move Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByRef Max_Speed_Array As Integer) As Integer
    Protected Declare Function APS_release_simultaneous_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    Protected Declare Function APS_emg_stop_simultaneous_move Lib "APS168.dll" (ByVal Axis_ID As Integer) As Integer
    'Override functions [Only for MNET series]
    Protected Declare Function APS_speed_override Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal MaxSpeed As Integer) As Integer
    'Only for MNET-1XMO/MNET-4XMO
    Protected Declare Function APS_relative_move_ovrd Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Distance As Integer, ByVal Max_Speed As Integer) As Integer
    Protected Declare Function APS_absolute_move_ovrd Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Position As Integer, ByVal Max_Speed As Integer) As Integer
    'New Interface
    Protected Declare Function APS_ptp Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal APS_Option As Integer, ByVal Position As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_ptp_v Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal APS_Option As Integer, ByVal Position As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_ptp_all Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal APS_Option As Integer, ByVal Position As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_vel Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal APS_Option As Integer, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer

    Protected Declare Function APS_vel_all Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal APS_Option As Integer, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer

    Protected Declare Function APS_line Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef PositionArray As Double, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_line_v Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef PositionArray As Double, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_line_all Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef PositionArray As Double, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer

    Protected Declare Function APS_arc2_ca Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc2_ca_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc2_ca_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc2_ce Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc2_ce_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc2_ce_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ca Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ca_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ca_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ce Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ce_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_arc3_ce_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ca Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByVal DeltaH As Double, ByVal FinalR As Double, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ca_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByVal DeltaH As Double, ByVal FinalR As Double, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ca_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByVal Angle As Double, ByVal DeltaH As Double, ByVal FinalR As Double, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ce Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ce_v Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vm As Double, ByRef Wait As ASYNCALL) As Integer
    Protected Declare Function APS_spiral_ce_all Lib "APS168.dll" (ByRef Axis_ID_Array As Integer, ByVal APS_Option As Integer, ByRef CenterArray As Double, ByRef NormalArray As Double, ByRef EndArray As Double, ByVal Dir As Short, ByRef TransPara As Double, ByVal Vs As Double, ByVal Vm As Double, ByVal Ve As Double, ByVal Acc As Double, ByVal Dec As Double, ByVal SFac As Double, ByRef Wait As ASYNCALL) As Integer
    '
    'Point table Feeder  Lib "APS168.dll" (Only for PCI-8254/8)
    Protected Declare Function APS_pt_dwell Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTDWL, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_line Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTLINE, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_arc2_ca Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTA2CA, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_arc2_ce Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTA2CE, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_arc3_ca Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTA3CA, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_arc3_ce Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTA3CE, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_spiral_ca Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTHCA, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_pt_spiral_ce Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Prof As PTHCE, ByRef Status As PTSTS) As Integer

    '
    'enable & disable
    Protected Declare Function APS_pt_enable Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Dimension As Integer, ByVal AxisArr() As Integer) As Integer
    Protected Declare Function APS_pt_disable Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_get_pt_info Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Info As PTINFO) As Integer
    Protected Declare Function APS_pt_set_vs Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Vs As Double) As Integer
    Protected Declare Function APS_pt_get_vs Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Vs As Double) As Integer
    Protected Declare Function APS_pt_start Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_stop Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_get_pt_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef Status As PTSTS) As Integer
    Protected Declare Function APS_reset_pt_buffer Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_roll_back Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Max_Speed As Double) As Integer
    Protected Declare Function APS_pt_get_error Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByRef ErrCode As Integer) As Integer

    'Cmd buffer setting
    Protected Declare Function APS_pt_ext_set_do_ch Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Channel As Integer, ByVal OnOff As Integer) As Integer
    Protected Declare Function APS_pt_ext_set_table_no Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal CtrlNo As Integer, ByVal TableNo As Integer) As Integer




    Protected Declare Function APS_manual_set_filter Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Coefficient As FILTER_COEF) As Integer
    Protected Declare Function APS_get_filter_coef Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Coefficient As FILTER_COEF) As Integer



    Protected Declare Function APS_register_virtual_board_ex Lib "APS168.dll" (ByVal VirCardIndex As Integer, ByVal Count As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_virtual_board_info_ex Lib "APS168.dll" (ByVal VirCardIndex As Integer, ByRef Count As Integer, ByRef Enable As Integer) As Integer

    'Control driver mode [Only for PCI-8254/8]
    Protected Declare Function APS_get_eep_curr_drv_ctrl_mode Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef ModeInBit As Integer) As Integer





    'Profile buffer setting
    Protected Declare Function APS_pt_set_absolute Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_set_relative Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_set_trans_buffered Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_set_trans_inp Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer) As Integer
    Protected Declare Function APS_pt_set_trans_blend_dec Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Bp As Double) As Integer
    Protected Declare Function APS_pt_set_trans_blend_dist Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Bp As Double) As Integer
    Protected Declare Function APS_pt_set_trans_blend_pcnt Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Bp As Double) As Integer
    Protected Declare Function APS_pt_set_acc Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Acc As Double) As Integer
    Protected Declare Function APS_pt_set_dec Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Dec As Double) As Integer
    Protected Declare Function APS_pt_set_acc_dec Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal AccDec As Double) As Integer
    Protected Declare Function APS_pt_set_s Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Sf As Double) As Integer
    Protected Declare Function APS_pt_set_vm Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Vm As Double) As Integer
    Protected Declare Function APS_pt_set_ve Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal PtbId As Integer, ByVal Ve As Double) As Integer

    'Program download - APS
    Protected Declare Function APS_load_vmc_program Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef pFile As String, ByVal Password As Integer) As Integer
    Protected Declare Function APS_save_vmc_program Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef pFile As String, ByVal Password As Integer) As Integer
    Protected Declare Function APS_load_amc_program Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef pFile As String, ByVal Password As Integer) As Integer
    Protected Declare Function APS_save_amc_program Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef pFile As String, ByVal Password As Integer) As Integer
    Protected Declare Function APS_set_task_mode Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByVal Mode As Byte, ByVal LastIP As UShort) As Integer
    Protected Declare Function APS_get_task_mode Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef Mode As Byte, ByRef LastIP As UShort) As Integer
    Protected Declare Function APS_start_task Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByVal CtrlCmd As Integer) As Integer
    Protected Declare Function APS_get_task_info Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TaskNum As Integer, ByRef Info As TSK_INFO) As Integer
    Protected Declare Function APS_get_task_msg Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef QueueSts As UShort, ByRef ActualSize As UShort, ByRef CharArr As Byte) As Integer

    '//Latch functins
    Protected Declare Function APS_get_encoder Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Encoder As Integer) As Integer
    Protected Declare Function APS_get_latch_counter Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Src As Integer, ByRef Counter As Integer) As Integer
    Protected Declare Function APS_get_latch_event Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Src As Integer, ByRef ENT As Integer) As Integer

    'Raw command counter [Only for PCI-8254/8]
    Protected Declare Function APS_get_command_counter Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Counter As Integer) As Integer

    '//Watch dog timer
    Protected Declare Function APS_wdt_start Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer, ByVal TimeOut As Integer) As Integer
    Protected Declare Function APS_wdt_get_timeout_period Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer, ByRef TimeOut As Integer) As Integer
    Protected Declare Function APS_wdt_reset_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer) As Integer
    Protected Declare Function APS_wdt_get_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer, ByRef Counter As Integer) As Integer
    Protected Declare Function APS_wdt_set_action_event Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer, ByVal EventByBit As Integer) As Integer
    Protected Declare Function APS_wdt_get_action_event Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal TimerNo As Integer, ByRef EventByBit As Integer) As Integer

    'Multi-axes simultaneuos move start/stop
    Protected Declare Function APS_move_trigger Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer
    Protected Declare Function APS_stop_move_multi Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer
    Protected Declare Function APS_emg_stop_multi Lib "APS168.dll" (ByVal Dimension As Integer, ByRef Axis_ID_Array As Integer) As Integer

    'Gear/Gantry function
    Protected Declare Function APS_start_gear Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Mode As Integer) As Integer
    Protected Declare Function APS_get_gear_status Lib "APS168.dll" (ByVal Axis_ID As Integer, ByRef Status As Integer) As Integer

    '//Latch Function: for latching multi-points
    Protected Declare Function APS_set_ltc_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal CntNum As Integer, ByVal CntValue As Integer) As Integer
    Protected Declare Function APS_get_ltc_counter Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal CntNum As Integer, ByRef CntValue As Integer) As Integer
    Protected Declare Function APS_set_ltc_fifo_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByVal Param_No As Integer, ByVal Param_Val As Integer) As Integer
    Protected Declare Function APS_get_ltc_fifo_param Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByVal Param_No As Integer, ByRef Param_Val As Integer) As Integer
    Protected Declare Function APS_manual_latch Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal LatchSignalInBits As Integer) As Integer
    Protected Declare Function APS_enable_ltc_fifo Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_reset_ltc_fifo Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer) As Integer
    Protected Declare Function APS_get_ltc_fifo_data Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByRef Data As Integer) As Integer
    Protected Declare Function APS_get_ltc_fifo_usage Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByRef Usage As Integer) As Integer
    Protected Declare Function APS_get_ltc_fifo_free_space Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByRef FreeSpace As Integer) As Integer
    Protected Declare Function APS_get_ltc_fifo_status Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal FLtcCh As Integer, ByRef Status As Integer) As Integer

    '//For Single latch for PCI8154/58/MNET-4XMO-(C)
    Protected Declare Function APS_manual_latch2 Lib "APS168.dll" (ByVal Board_ID As Integer) As Integer
    Protected Declare Function APS_get_latch_data2 Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal LatchNum As Integer, ByRef LatchData As Integer) As Integer
    Protected Declare Function APS_set_backlash_en Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_backlash_en Lib "APS168.dll" (ByVal Board_ID As Integer, ByRef Enable As Integer) As Integer


    ' Pulser for PCI-8254/58
    Protected Declare Function APS_manual_pulser_start Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_manual_pulser_configuration Lib "APS168.dll" (ByVal Board_ID As Integer, ByVal Mode As Integer, ByVal InvPA As Integer, ByVal InvPB As Integer, ByVal InvDir As Integer, ByVal Ratio As Double) As Integer
    Protected Declare Function APS_manual_pulser_velocity_move Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal MaxVelocity As Double) As Integer
    Protected Declare Function APS_manual_pulser_relative_move Lib "APS168.dll" (ByVal Axis_ID As Integer, ByVal Distance As Double, ByVal MaxVelocity As Double) As Integer

    ' Clrcular limit for PCI-8254/58
    Protected Declare Function APS_set_circular_limit Lib "APS168.dll" (ByVal Axis_A As Integer, ByVal Axis_B As Integer, ByVal Center_A As Double, ByVal Center_B As Double, ByVal Radius As Double, ByVal Stop_mode As Integer, ByVal Enable As Integer) As Integer
    Protected Declare Function APS_get_circular_limit Lib "APS168.dll" (ByVal Axis_A As Integer, ByVal Axis_B As Integer, ByRef Center_A As Double, ByRef Center_B As Double, ByRef Radius As Double, ByRef Stop_mode As Integer, ByRef Enable As Integer) As Integer


    '  Copyright  Lib "ADCNC.dll" (C) 1995-2009 Adlink Technology INC.
    '  All rights reserved.

    Protected Structure VP_PARAM_CONFIG
        Dim u32_vmax As UInteger    ' maximum velocity (pulse/s)
        Dim u32_acc As UInteger       ' maximum acceleration (pulse/s^2)
        Dim u32_rvmax As UInteger   ' rapid, maximum velocity (pulse/s)
        Dim u32_racc As UInteger      ' rapid, maximum acceleration (pulse/s^2)
        Dim u32_corner As UInteger   ' corner velocity setting
        Dim u32_dt As UInteger         ' cycle time (unit: nano second)
        Dim u32_opt As UInteger      ' reserved
        Dim f64_sfactor As Double     ' s-curve factor
    End Structure
    Protected Declare Function ADCNC_Velocity_Planning Lib "ADCNC.dll" (ByRef VpConfig As VP_PARAM_CONFIG, ByVal PosCount As UInt32, ByRef PosArray As POS_DATA_2D_F64, ByRef PntArray As PNT_DATA_2D_F64) As Int32
    Protected Declare Function ADCNC_Path_Optimize Lib "ADCNC.dll" (ByVal pointnumber As UInt32, ByVal PosArrayIn As IntPtr, ByVal ToleranceError As Double, ByRef reducepointnumber As UInt32, ByVal PosArrayOut As IntPtr, ByRef df_tolerr As Double) As Int32
    Protected Declare Function PosData2_FileLoad_F64 Lib "ADCNC.dll" (<MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal FileName As String, ByRef PosCount As UInt32, ByVal PosArray As IntPtr) As Int32
    Protected Declare Function PosData2_FileSave_F64 Lib "ADCNC.dll" (<MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal FileName As String, ByVal PosCount As UInt32, ByVal PosArray As IntPtr) As Int32
    Protected Declare Function PntData2_FileLoad_F64 Lib "ADCNC.dll" (<MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal FileName As String, ByRef PntCount As UInt32, ByVal PntArray As IntPtr) As Int32
    Protected Declare Function PntData2_FileSave_F64 Lib "ADCNC.dll" (<MarshalAsAttribute(UnmanagedType.LPWStr)> ByVal FileName As String, ByVal PntCount As UInt32, ByVal PntArray As IntPtr) As Int32
    Protected Declare Function ADCNC_Version Lib "ADCNC.dll" () As Int32

End Class


Friend Class CAdlinkAMP204
    Inherits CAdlinkAMP204Base
    Implements IPseudoMotion
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Friend Sub New(ByRef pAxis() As CAxisBased)

        Try
            m_Timer = New CHighResolutionTimer
            m_Axis = pAxis
            m_MoveAdvTableIsThreadFinished = True
            m_MoveAdvTableIsThreadStarted = False
            m_MoveAdvTableErrMessage = ""
            m_MoveAdvTableEMGStop = False
            m_nowLine = 0
        Catch ex As Exception
        Finally
        End Try
    End Sub
#End Region
#Region "Member"
    Private m_Axis() As CAxisBased
    Private m_Timer As Timer.CHighResolutionTimer
#End Region
#Region "Property"

#End Region

#Region "Events"

#End Region
#Region "Methods"
    Friend Sub ChkMultiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus
        Try
            Call ChkStatus(AxisID1)
            Call ChkStatus(AxisID2)
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop
        Dim status1 As enumMotionFlag
        Dim status2 As enumMotionFlag
        ChkMultiStop = enumMotionFlag.eNotReady
        Try
            Call ChkMultiStatus(AxisID1, AxisID2)
            status1 = enumMotionFlag.eNotReady
            status2 = enumMotionFlag.eNotReady
            With m_Axis(AxisID1)
                If .IO.AlarmSignal = enumMotionFlag.eLow Then
                    If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then
                        If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                            If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                                status1 = enumMotionFlag.eReady
                            End If
                        Else
                            status1 = enumMotionFlag.eReady
                        End If
                    ElseIf .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                        If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then
                            '     m_Axis(AxisID1).ErrMessage = "Axis" & AxisID1 & "正硬體極限ON"
                        End If
                        If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                            '  m_Axis(AxisID1).ErrMessage = "Axis" & AxisID1 & "負硬體極限ON"
                        End If
                        status1 = enumMotionFlag.eReady
                    End If
                    With m_Axis(AxisID2)
                        If .IO.AlarmSignal = enumMotionFlag.eLow Then
                            If (.Status.MovementIsFinished = enumMotionFlag.eHigh) Then
                                If (.Mode.InpEnable = enumMotionFlag.eHigh) Then
                                    If (.IO.InPositionSignalInput = enumMotionFlag.eHigh) Then
                                        status2 = enumMotionFlag.eReady
                                    End If
                                Else
                                    status2 = enumMotionFlag.eReady
                                End If
                            ElseIf .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                                If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then
                                    '   m_Axis(AxisID2).ErrMessage = "Axis" & AxisID2 & "正硬體極限ON"
                                End If
                                If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                                    '    m_Axis(AxisID2).ErrMessage = "Axis" & AxisID2 & "負硬體極限ON"
                                End If
                                status1 = enumMotionFlag.eReady
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
        Finally
        End Try
    End Function



    Friend Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        ChkPreRegisterEmpty = enumMotionFlag.eReady
    End Function
    Friend Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus
        ' Motion IO status bit number define.
        Const MIO_ALM As Short = 0 ' Servo alarm.
        Const MIO_PEL As Short = 1 ' Positive end limit.
        Const MIO_MEL As Short = 2 ' Negative end limit.
        Const MIO_ORG As Short = 3 ' ORG =Home
        Const MIO_EMG As Short = 4 ' Emergency stop
        Const MIO_EZ As Short = 5 ' EZ.
        Const MIO_INP As Short = 6 ' In position.
        Const MIO_SVON As Short = 7 ' Servo on signal.
        Const MIO_RDY As Short = 8 ' Ready.
        Const MIO_WARN As Short = 9 ' Warning.
        Const MIO_ZSP As Short = 10 ' Zero speed.
        Const MIO_SPEL As Short = 11 ' Soft positive end limit.
        Const MIO_SMEL As Short = 12 ' Soft negative end limit.
        Const MIO_TLC As Short = 13 ' Torque is limited by torque limit value.
        Const MIO_ABSL As Short = 14 ' Absolute position lost.
        Const MIO_STA As Short = 15 ' External start signal.
        Const MIO_PSD As Short = 16 ' Positive slow down signal
        Const MIO_MSD As Short = 17 ' Negative slow down signal

        ' Motion status bit number define.
        Const MTS_CSTP As Short = 0 ' Command stop signal.
        Const MTS_VM As Short = 1 ' At maximum velocity.
        Const MTS_ACC As Short = 2 ' In acceleration.
        Const MTS_DEC As Short = 3 ' In deceleration.
        Const MTS_DIR As Short = 4 ' LastMoving direction.
        Const MTS_NSTP As Short = 5 ' Normal stop(Motion done.
        Const MTS_HMV As Short = 6 ' In home operation.
        Const MTS_SMV As Short = 7 ' Single axis move relative, absolute, velocity move.
        Const MTS_LIP As Short = 8 ' Linear interpolation.
        Const MTS_CIP As Short = 9 ' Circular interpolation.
        Const MTS_VS As Short = 10 ' At start velocity.
        Const MTS_PMV As Short = 11 ' Point table move.
        Const MTS_PDW As Short = 12 ' Point table dwell move.
        Const MTS_PPS As Short = 13 ' Point table pause state.
        Const MTS_SLV As Short = 14 ' Slave axis move.
        Const MTS_JOG As Short = 15 ' Jog move.
        Const MTS_ASTP As Short = 16 ' Abnormal stop.
        Const MTS_SVONS As Short = 17 ' Servo off stopped.
        Const MTS_EMGS As Short = 18 ' EMG / SEMG stopped.
        Const MTS_ALMS As Short = 19 ' Alarm stop.
        Const MTS_WANS As Short = 20 ' Warning stopped.
        Const MTS_PELS As Short = 21 ' PEL stopped.
        Const MTS_MELS As Short = 22 ' MEL stopped.
        Const MTS_ECES As Short = 23 ' Error counter check level reaches and stopped.
        Const MTS_SPELS As Short = 24 ' Soft PEL stopped.
        Const MTS_SMELS As Short = 25 ' Soft MEL stopped.
        Const MTS_STPOA As Short = 26 ' Stop by others axes.
        Const MTS_GDCES As Short = 27 ' Gantry deviation error level reaches and stopped.
        Const MTS_GTM As Short = 28 ' Gantry mode turn on.
        Const MTS_PAPB As Short = 29 ' Pulsar mode turn on.

        'Following definition for PCI-8254/8
        Const MTS_MDN As Short = 5         '// Motion done. 0: In motion, 1: Motion done ( It could be abnormal stop)
        Const MTS_WAIT As Short = 10        '// Axis is in waiting state. ( Wait move trigger )
        Const MTS_PTB As Short = 11       ' // Axis is in point buffer moving. ( When this bit on, MDN and ASTP will be cleared )
        Const MTS_BLD As Short = 17        '// Axis (Axes) in blending moving
        Const MTS_PRED As Short = 18        '// Pre-distance event, 1: event arrived. The event will be clear when axis start moving 
        Const MTS_POSTD As Short = 19        '// Post-distance event. 1: event arrived. The event will be clear when axis start moving
        Const MTS_GER As Short = 28       ' // 1: In geared ( This axis as slave axis and it follow a master specified in axis parameter. )

        ' Motion IO status bit value define.
        Const MIO_ALM_V As Short = &H1S ' Servo alarm.
        Const MIO_PEL_V As Short = &H2S ' Positive end limit.
        Const MIO_MEL_V As Short = &H4S ' Negative end limit.
        Const MIO_ORG_V As Short = &H8S ' ORG =Home.
        Const MIO_EMG_V As Short = &H10S ' Emergency stop.
        Const MIO_EZ_V As Short = &H20S ' EZ.
        Const MIO_INP_V As Short = &H40S ' In position.
        Const MIO_SVON_V As Short = &H80S ' Servo on signal.
        Const MIO_RDY_V As Short = &H100S ' Ready.
        Const MIO_WARN_V As Short = &H200S ' Warning.
        Const MIO_ZSP_V As Short = &H400S ' Zero speed.
        Const MIO_SPEL_V As Short = &H800S ' Soft positive end limit.
        Const MIO_SMEL_V As Short = &H1000S ' Soft negative end limit.
        Const MIO_TLC_V As Short = &H2000S ' Torque is limited by torque limit value.
        Const MIO_ABSL_V As Short = &H4000S ' Absolute position lost.
        Const MIO_STA_V As Short = &H8000S ' External start signal.
        Const MIO_PSD_V As Integer = &H10000 ' Positive slow down signal.
        Const MIO_MSD_V As Integer = &H20000 ' Negative slow down signal.

        ' Motion status bit value define.
        Const MTS_CSTP_V As Short = &H1S ' Command stop signal.
        Const MTS_VM_V As Short = &H2S ' At maximum velocity.
        Const MTS_ACC_V As Short = &H4S ' In acceleration.
        Const MTS_DEC_V As Short = &H8S ' In deceleration.
        Const MTS_DIR_V As Short = &H10S ' LastMoving direction.
        Const MTS_NSTP_V As Short = &H20S ' Normal stop Motion done.
        Const MTS_HMV_V As Short = &H40S ' In home operation.
        Const MTS_SMV_V As Short = &H80S ' Single axis move( relative, absolute, velocity move.
        Const MTS_LIP_V As Short = &H100S ' Linear interpolation.
        Const MTS_CIP_V As Short = &H200S ' Circular interpolation.
        Const MTS_VS_V As Short = &H400S ' At start velocity.
        Const MTS_PMV_V As Short = &H800S ' Point table move.
        Const MTS_PDW_V As Short = &H1000S ' Point table dwell move.
        Const MTS_PPS_V As Short = &H2000S ' Point table pause state.
        Const MTS_SLV_V As Short = &H4000S ' Slave axis move.
        Const MTS_JOG_V As Short = &H8000S ' Jog move.
        Const MTS_ASTP_V As Integer = &H10000 ' Abnormal stop.
        Const MTS_SVONS_V As Integer = &H20000 ' Servo off stopped.
        Const MTS_EMGS_V As Integer = &H40000 ' EMG / SEMG stopped.
        Const MTS_ALMS_V As Integer = &H80000 ' Alarm stop.
        Const MTS_WANS_V As Integer = &H100000 ' Warning stopped.
        Const MTS_PELS_V As Integer = &H200000 ' PEL stopped.
        Const MTS_MELS_V As Integer = &H400000 ' MEL stopped.
        Const MTS_ECES_V As Integer = &H800000 ' Error counter check level reaches and stopped.
        Const MTS_SPELS_V As Integer = &H1000000 ' Soft PEL stopped.
        Const MTS_SMELS_V As Integer = &H2000000 ' Soft MEL stopped.
        Const MTS_STPOA_V As Integer = &H4000000 ' Stop by others axes.
        Const MTS_GDCES_V As Integer = &H8000000 ' Gantry deviation error level reaches and stopped.
        Const MTS_GTM_V As Integer = &H10000000 ' Gantry mode turn on.
        Const MTS_PAPB_V As Integer = &H20000000 ' Pulsar mode turn on.

        Dim MotionStatus As Integer
        Dim IOState As Integer
        With m_Axis(AxisID)
            IOState = APS_motion_io_status(.AxisID)
            With .IO
                .RdyInput = CType(CType(IIf((MIO_RDY_V And IOState) = MIO_RDY_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .AlarmSignal = CType(CType(IIf((MIO_ALM_V And IOState) = MIO_ALM_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .PositiveLimitSwitch = CType(CType(IIf((MIO_PEL_V And IOState) = MIO_PEL_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .NegativeLimitSwitch = CType(CType(IIf((MIO_MEL_V And IOState) = MIO_MEL_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .OriginSwitch = CType(CType(IIf((MIO_ORG_V And IOState) = MIO_ORG_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .DIROutput = CType(enumMotionFlag.eLow, enumMotionFlag)
                .EMGStatus = CType(CType(IIf((MIO_EMG_V And IOState) = MIO_EMG_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .PCSSignalInput = CType(enumMotionFlag.eLow, enumMotionFlag)
                .ERCOutput = CType(enumMotionFlag.eLow, enumMotionFlag)
                .IndexSignal = CType(CType(IIf((MIO_EZ_V And IOState) = MIO_EZ_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .ClearSignal = CType(enumMotionFlag.eLow, enumMotionFlag)
                .LatchSignalInput = CType(enumMotionFlag.eLow, enumMotionFlag)
                .InPositionSignalInput = CType(CType(IIf((MIO_INP_V And IOState) = MIO_INP_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .ServoOnOutput = CType(CType(IIf((MIO_SVON_V And IOState) = MIO_SVON_V, enumMotionFlag.eLow, enumMotionFlag.eHigh), enumMotionFlag), enumMotionFlag)
                .PositiveSlowDownPoint = CType(CType(IIf((MIO_PSD_V And IOState) = MIO_PSD_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .NegativeSlowDownPoint = CType(CType(IIf((MIO_MSD_V And IOState) = MIO_MSD_V, enumMotionFlag.eHigh, enumMotionFlag.eLow), enumMotionFlag), enumMotionFlag)
                .InterruptStatus = CType(enumMotionFlag.eLow, enumMotionFlag)

                If .AlarmSignal = enumMotionFlag.eHigh Then
                    m_Axis(AxisID).ErrMessage = "Driver Alarm"
                Else
                    'If .PositiveLimitSwitch = enumMotionFlag.eHigh Then
                    '    m_Axis(AxisID).ErrMessage = "PositiveLimit Alarm"
                    'Else
                    '    If .NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    '        m_Axis(AxisID).ErrMessage = "NegativeLimit Alarm"
                    '    Else
                    '        m_Axis(AxisID).ErrMessage = ""
                    '    End If
                    'End If
                End If

            End With
            MotionStatus = APS_motion_status(.AxisID)
            .Status.MovementIsFinished = CType(enumMotionFlag.eLow, enumMotionFlag)
            If (MotionStatus And MTS_NSTP_V) = MTS_NSTP_V Then
                .Status.MovementIsFinished = CType(enumMotionFlag.eHigh, enumMotionFlag)
            Else
                If (MotionStatus And MTS_ASTP_V) = MTS_ASTP_V Then
                    .Status.MovementIsFinished = CType(enumMotionFlag.eHigh, enumMotionFlag)
                    Dim rtnCode As Integer
                    Call APS_get_stop_code(.AxisID, rtnCode)
                    Select Case rtnCode
                        Case 0
                            'Normal Stop
                        Case 1
                            '.ErrMessage = AxisID & "緊急停止訊號啟用,軸卡停止驅動!"
                        Case 2
                            '  .ErrMessage = AxisID & "驅動器異常訊號啟用,軸卡停止驅動!"
                        Case 3
                            .ErrMessage = AxisID & "馬達未激磁,軸卡停止驅動!"
                        Case 4
                            If Not m_Axis(AxisID).IsHomming Then
                                '   .ErrMessage = AxisID & "硬體正極限訊號啟用,軸卡停止驅動!"
                            End If
                        Case 5
                            If Not m_Axis(AxisID).IsHomming Then
                                '     .ErrMessage = AxisID & "硬體負極限訊號啟用,軸卡停止驅動!"
                            End If
                        Case 6
                            .ErrMessage = AxisID & "軟體正極限訊號啟用,軸卡停止驅動!"
                        Case 7
                            .ErrMessage = AxisID & "軟體負極限訊號啟用,軸卡停止驅動!"
                        Case 8
                            .ErrMessage = AxisID & "EMG stop by user!"
                        Case 9
                            .ErrMessage = AxisID & "Stop by user!"
                        Case 10
                            .ErrMessage = AxisID & "Stop by E-Gear gantry protect level 1 condition is met!"
                        Case 11
                            .ErrMessage = AxisID & "Stop by E-Gear gantry protect level 2 condition is met!"
                        Case 12
                            .ErrMessage = AxisID & "Stop because gear slave axis!"
                        Case 13
                            .ErrMessage = AxisID & "追隨誤差過大,軸卡停止驅動!"
                        Case 14
                            .ErrMessage = AxisID & "數位訊號啟用,軸卡停止驅動!"
                    End Select
                Else
                    If (MotionStatus And MTS_SVONS_V) = MTS_SVONS_V Then
                        .Status.MovementIsFinished = CType(enumMotionFlag.eHigh, enumMotionFlag)
                        .ErrMessage = "Servo off stopped"
                    Else
                        'If (MotionStatus And MTS_EMGS_V) = MTS_EMGS_V Then
                        '    .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '    .ErrMessage = "EMG / SEMG stopped"
                        'Else
                        '    If (MotionStatus And MTS_ALMS_V) = MTS_ALMS_V Then
                        '        .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '        .ErrMessage = "Alarm stop"
                        '    Else
                        '        If (MotionStatus And MTS_WANS_V) = MTS_WANS_V Then
                        '            .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '            .ErrMessage = "Warning stopped"
                        '        Else
                        '            If (MotionStatus And MTS_PELS_V) = MTS_PELS_V Then
                        '                .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '                .ErrMessage = "PEL stopped"
                        '            Else
                        '                If (MotionStatus And MTS_MELS_V) = MTS_MELS_V Then
                        '                    .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '                    .ErrMessage = "MEL stopped"
                        '                Else
                        '                    If (MotionStatus And MTS_ECES_V) = MTS_ECES_V Then
                        '                        .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '                        .ErrMessage = "Error counter check level reaches and stopped"
                        '                    Else
                        '                        If (MotionStatus And MTS_SPELS_V) = MTS_SPELS_V Then
                        '                            .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '                            .ErrMessage = "Soft PEL stopped"
                        '                        Else
                        '                            If (MotionStatus And MTS_SMELS_V) = MTS_SMELS_V Then
                        '                                .Status.MovementIsFinished = enumMotionFlag.eHigh
                        '                                .ErrMessage = "Soft MEL stopped"
                        '                            End If
                        '                        End If
                        '                    End If
                        '                End If
                        '            End If
                        '        End If
                        '    End If
                        'End If
                    End If
                End If
            End If


        End With
    End Sub

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
                ElseIf .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    'If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then
                    '    m_Axis(AxisID).ErrMessage = "Axis" & AxisID & "正硬體極限ON"
                    'End If
                    'If .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    '    m_Axis(AxisID).ErrMessage = "Axis" & AxisID & "負硬體極限ON"
                    'End If
                    'ChkStop = enumMotionFlag.eReady
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
    Friend Sub Close() Implements IPseudoMotion.Close
        Dim ret As Integer
        Try
            ret = APS_close()
            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub ConfigCompare(ByVal AxisID As Integer, ByVal StartPos As Double, ByVal EndPos As Double)
        Dim ret As Integer
        Dim Size As Integer = 2
        Dim activeHigh As Integer = 1
        Dim outLevel As Integer = 1
        Dim dataAry(0 To 1) As Integer
        Dim rtncmp As Integer
        Dim bidirection As Integer = 2
        Try
            '0,2,0
            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TCMP0_SRC, m_Axis(AxisID).AxisID) 'Set encoder counter 0 as TCMP0’s source.
            dataAry(0) = CInt(StartPos * m_Axis(AxisID).Param.SwScale / m_Axis(AxisID).Param.EnrScale)
            dataAry(1) = CInt(EndPos * m_Axis(AxisID).Param.SwScale / m_Axis(AxisID).Param.EnrScale)
            '0,0,
            Do
                ret = APS_set_trigger_table(m_Axis(AxisID).CardID, 0, dataAry(0), Size)
                ret = APS_get_trigger_table_cmp(m_Axis(AxisID).CardID, 0, rtncmp)
            Loop Until rtncmp = dataAry(0)
            '0, ,1
            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TRG0_LOGIC, 0) ' set Logic
            '0, , 1
            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TRG0_TGL, outLevel) ' set Toggle

            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TRG0_SRC, 4)
            ret = APS_get_trigger_param(m_Axis(AxisID).CardID, TGR_TRG_EN, activeHigh) ' TG Enable

            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TCMP0_DIR, bidirection)


            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub CloseCompare(ByVal AxisID As Integer)
        Dim ret As Integer
        Dim manual0 As Integer = 0
        Dim activeLow As Integer = 0
        Try
            Do
                ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TRG0_SRC, manual0) ' TG Disable
            Loop While ret < 0
            ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TGR_TRG_EN, activeLow) ' TG Enable
            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub EmgStop(ByVal AxisID As Integer) Implements IPseudoMotion.EmgStop
        Dim ret As Integer
        Dim groupId As Short
        Try
            ret = APS_emg_stop(m_Axis(AxisID).AxisID)
            If ret = ERR_NoError Then
                If m_Axis(AxisID).GroupID = -1 Then
                    groupId = 0
                    m_Axis(AxisID).GroupID = CShort(groupId)
                    Dim axisAry(0 To 1) As Integer
                    axisAry(0) = m_Axis(AxisID).AxisID
                    axisAry(1) = m_Axis(AxisID + 1).AxisID
                    ret = APS_free_feeder_group(groupId)
                    If (ret = ERR_NoError) Then
                        ret = APS_set_feeder_group(groupId, 2, axisAry(0))
                        If (ret = ERR_NoError) Then
                            ret = APS_set_feeder_ex_pause(groupId)
                            ret = APS_reset_feeder_buffer(groupId)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        Dim ret As Integer
        Dim cmd As Double
        Try
            ret = APS_get_command_f(m_Axis(AxisID).AxisID, cmd)
            If ret = ERR_NoError Then

            End If
            pCmd = cmd / m_Axis(AxisID).Param.SwScale
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        Dim ret As Integer
        Dim enr As Double
        Try
            ret = APS_get_position_f(m_Axis(AxisID).AxisID, enr)
            If ret = ERR_NoError Then

            End If
            pEncoder = enr / m_Axis(AxisID).Param.SwScale
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget
        Dim ret As Integer
        Dim tarPos As Double
        Try
            ret = APS_get_target_position_f(m_Axis(AxisID).AxisID, tarPos)
            If ret = ERR_NoError Then

            End If
            pTarget = tarPos / m_Axis(AxisID).Param.SwScale
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Function CardInit() As Boolean
        CardInit = False
        Dim ret As Integer
        Dim boardIDInBits As Integer = -1
        Dim mode As Integer = 0
        Try
            Dim pCardCount As Integer = -1
            Dim pListOfCardID As New List(Of Integer)
            For i As Integer = 0 To m_Axis.Length - 1 Step 1
                If m_Axis(i).CardType = enumMotionCard.AdlinkAMP204C Then
                    Dim pHaveCardIDBool As Boolean = False
                    For j As Integer = 0 To pListOfCardID.Count - 1 Step 1
                        If pListOfCardID(j) = m_Axis(i).CardID Then
                            pHaveCardIDBool = True
                            Exit For
                        End If
                    Next
                    If pHaveCardIDBool = False Then
                        pListOfCardID.Add(m_Axis(i).CardID)
                    End If
                End If
            Next
            ret = APS_initial(boardIDInBits, mode)
            'If ret = ERR_NoError Then
            ret = APS_load_param_from_file("C:\param.xml")
            For i As Integer = 1 To pListOfCardID.Count - 1 Step 1
                ret = APS_load_param_from_file("C:\param" & i & ".xml")
            Next
            If ret = ERR_NoError Then
                ret = APS_set_trigger_param(0, TG_TRG0_SRC, &H0)
                ret = APS_set_trigger_param(0, TG_TCMP0_EN, &H0)
                CardInit = True
            End If
            'End If
        Catch ex As Exception

        Finally

        End Try
    End Function
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Init = False
        Try
            Init = True
        Catch ex As Exception

        Finally

        End Try
    End Function
    Friend Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim ret As Integer
        Dim cmd As Double
        Dim calcDistance As Double
        Dim calcMaxVel As Double
        Dim calcStartVel As Double
        Dim calcEndVel As Double
        Dim calcAcc As Double
        Dim calcDec As Double
        Dim status As enumMotionFlag
        pResult = enumMotionFlag.eNotSent
        Try
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
                            End If
                            calcMaxVel = .Speed.MaxVel * VelocityRatio * .Param.SwScale
                            If calcMaxVel > .Speed.MaxConstrainedVel * .Param.SwScale Then calcMaxVel = .Speed.MaxConstrainedVel
                            calcStartVel = .Speed.StrVel * VelocityRatio * .Param.SwScale
                            calcStartVel = 0
                            calcEndVel = .Speed.StrVel * VelocityRatio * .Param.SwScale
                            calcEndVel = 0
                            calcAcc = .Speed.Acc * AccRatio * .Param.SwScale
                            calcDec = .Speed.Dec * AccRatio * .Param.SwScale

                            'If m_Axis(AxisID).IsExternalParameters Then
                            '    DrivingVel = CInt(m_Axis(AxisID).Speed.MaxVelExt * m_Axis(AxisID).Param.SwScale)
                            '    DrivingStrVel = CInt(m_Axis(AxisID).Speed.StrVel * m_Axis(AxisID).Param.SwScale)
                            '    DrivingAcc = m_Axis(AxisID).Speed.AccExt * m_Axis(AxisID).Param.SwScale
                            '    DrivingDec = m_Axis(AxisID).Speed.DecExt * m_Axis(AxisID).Param.SwScale
                            'Else
                            '    DrivingVel = CInt(m_Axis(AxisID).Speed.MaxVel * m_Axis(AxisID).Param.SwScale)
                            '    DrivingStrVel = CInt(m_Axis(AxisID).Speed.StrVel * m_Axis(AxisID).Param.SwScale)

                            '    DrivingAcc = m_Axis(AxisID).Speed.AccLinear * m_Axis(AxisID).Param.SwScale
                            '    DrivingDec = m_Axis(AxisID).Speed.DecLinear * m_Axis(AxisID).Param.SwScale
                            'End If

                            ret = APS_ptp_all(.AxisID, 0, Target * .Param.SwScale, calcStartVel, calcMaxVel, calcEndVel, calcAcc, calcDec, .Speed.Sacc, Nothing) '.Speed.Sacc
                            ' If ret = ERR_NoError Then
                            pResult = enumMotionFlag.eSent
                            'End If
                        End If
                    End With
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
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub MoveArc(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="AxisID1"></param>
    ''' <param name="AxisID2"></param>
    ''' <param name="rtnData"></param>
    ''' <param name="pResult"></param>
    ''' <remarks></remarks>
    Friend Sub MoveFeederPoint(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef rtnData As List(Of String), ByRef pResult As enumMotionFlag)
        Dim calcMaxVel As Double
        Dim calcAcc As Double
        'Velocity Planning
        Dim vpConfig As VP_PARAM_CONFIG
        Dim posTable() As POS_DATA_2D_F64
        Dim pntFeeder() As PNT_DATA_2D_F64
        Dim ret As Integer
        Dim ss() As String
        Dim rapidMove As Integer = 384 '0x180
        Dim extentionMove As Integer = 256 '0x100
        Dim workLine As Integer = 768 '0x300
        Dim workArc As Integer = 772 '0x304
        Dim groupId As Integer = m_Axis(AxisID1).GroupID
        Dim dimension As Integer = 2
        Dim axisAry(1) As Integer
        Dim SS1() As String

        pResult = enumMotionFlag.eNotSent
        Try
            If (ChkFeederStop(AxisID1, AxisID2) = enumMotionFlag.eReady) Then
                groupId = m_Axis(AxisID1).GroupID
                If Not ((m_Axis(AxisID1).IO.EMGStatus = enumMotionFlag.eHigh) OrElse (m_Axis(AxisID1).IO.AlarmSignal = enumMotionFlag.eHigh)) Then
                    If Not ((m_Axis(AxisID2).IO.EMGStatus = enumMotionFlag.eHigh) OrElse (m_Axis(AxisID2).IO.AlarmSignal = enumMotionFlag.eHigh)) Then
                        ss = Split(rtnData(0), ",")
                        calcMaxVel = CDbl(ss(2)) * m_Axis(AxisID1).Param.SwScale
                        If calcMaxVel > m_Axis(AxisID1).Speed.MaxConstrainedVel Then calcMaxVel = m_Axis(AxisID1).Speed.MaxConstrainedVel
                        calcAcc = CDbl(ss(3)) * m_Axis(AxisID1).Param.SwScale
                        vpConfig.u32_vmax = CUInt(calcMaxVel)               ' config setting
                        vpConfig.u32_acc = CUInt(calcAcc)
                        calcMaxVel = CDbl(ss(0)) * m_Axis(AxisID1).Param.SwScale
                        If calcMaxVel > m_Axis(AxisID1).Speed.MaxConstrainedVel Then calcMaxVel = m_Axis(AxisID1).Speed.MaxConstrainedVel
                        vpConfig.u32_rvmax = CUInt(calcMaxVel)
                        calcAcc = CDbl(ss(1)) * m_Axis(AxisID1).Param.SwScale
                        vpConfig.u32_racc = CUInt(calcAcc)
                        vpConfig.u32_corner = CUInt(8000000)
                        vpConfig.f64_sfactor = CDbl(0)
                        vpConfig.u32_dt = 1000000 'hardware frequency must be 1000000ns
                        ReDim posTable(rtnData.Count - 2)
                        ReDim pntFeeder(rtnData.Count - 2)
                        ReDim SS1(rtnData.Count - 2)
                        For aryIdx = 1 To rtnData.Count - 1
                            ss = Split(rtnData(aryIdx), ",")
                            posTable(aryIdx - 1).f64_x = CDbl(ss(1)) * m_Axis(AxisID1).Param.SwScale
                            posTable(aryIdx - 1).f64_y = CDbl(ss(2)) * m_Axis(AxisID2).Param.SwScale
                            posTable(aryIdx - 1).f64_theta = CDbl(CInt(ss(3)))
                            SS1(aryIdx - 1) = ss(0)
                            ss(0) = "&h" & ss(0).Substring(2, ss(0).Length - 2)
                            posTable(aryIdx - 1).u32_opt = CUInt(ss(0))
                        Next aryIdx
                        ret = ADCNC_Velocity_Planning(vpConfig, CUInt(posTable.Length), posTable(0), pntFeeder(0))

                        '' //     opt               x               y           theta             acc             dec              vi              vm              ve
                        'My.Computer.FileSystem.WriteAllText("C:\Test.txt", "//     opt               x               y           theta             acc             dec              vi              vm              ve" & vbCrLf, False)
                        'For aryIdx As Integer = 0 To UBound(pntFeeder)
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_x, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_y, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_theta, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_acc, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_dec, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_vi, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_vm, 0).ToString().PadLeft(12, CChar(" ")) & ".000"
                        '    SS1(aryIdx) = SS1(aryIdx) & Math.Round(pntFeeder(aryIdx).f64_ve, 0).ToString().PadLeft(12, CChar(" ")) & ".000" & vbCrLf
                        '    My.Computer.FileSystem.WriteAllText("C:\Test.txt", SS1(aryIdx), True)
                        'Next aryIdx

                        If (ret = ERR_NoError) Then
                            axisAry(0) = m_Axis(AxisID1).AxisID
                            axisAry(1) = m_Axis(AxisID2).AxisID
                            ret = APS_free_feeder_group(m_Axis(AxisID1).GroupID)
                            If (ret = ERR_NoError) Then
                                ret = APS_set_feeder_group(groupId, 2, axisAry(0))
                                If (ret = ERR_NoError) Then
                                    ret = APS_set_feeder_group(groupId, 2, axisAry(0))
                                    If (ret = ERR_NoError) Then
                                    End If
                                End If
                            End If
                            ret = APS_reset_feeder_buffer(groupId)
                            If (ret = ERR_NoError) Then
                                ret = APS_set_feeder_point_2D_ex(groupId, pntFeeder(0), pntFeeder.Length, 1)
                                If (ret = ERR_NoError) Then
                                    ret = APS_start_feeder_move(groupId)
                                    If (ret = ERR_NoError) Then
                                        pResult = enumMotionFlag.eSent
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Private m_channel As Integer = 1
    Friend Function LaserOn(ByVal param1 As String, ByVal param2 As String) As Boolean
        Try
            LaserOn = False
            Dim intCardID As Integer = 0
            Dim v_card_id As Integer = intCardID

            Dim ret As Integer = 0
            Dim Board_ID As Integer = v_card_id
            Dim CH As Integer = 0               'Range is from 0 to 1
            Dim Frequency As Integer = CInt(param1) '20000     'Unit: Hz. Range is from 3 to 50000000.
            Dim Width As Integer = CInt(param2)  '25000         'Unit: ns. Range is from 20 to 335544300.



            ret = APS_set_board_param(intCardID, &H110, -1)
            ret = APS_start_vao(intCardID, 0, 0)

            'Disable all PWM signals. 
            For CH = 0 To (m_channel - 1)
                ret = APS_set_pwm_on(Board_ID, CH, 0)
            Next

            'Set PWM parameters
            For CH = 0 To (m_channel - 1)
                ret = APS_set_pwm_frequency(Board_ID, CH, Frequency)
                ret = APS_set_pwm_width(Board_ID, CH, Width)
            Next

            'Wait for stable.
            Thread.Sleep(1)

            'Note:
            'The PWM output (TG) is used by two function APIs, that are APS_set_pwm_on() and APS_start_vao(). 
            'Don() 't use them at the same time.
            'Be sure that only one of them is enabled, specified PWM m_channel could rightly work. 

            'start output PWM signal.
            For CH = 0 To (m_channel - 1)
                ret = APS_set_pwm_on(Board_ID, CH, 1)
            Next
            Thread.Sleep(1000)
            LaserOn = True
        Catch ex As Exception
            Call MsgBox("PWM_On Error")
        End Try
    End Function
    Friend Function LaserOn_BoardLink() As Boolean
        Try
            LaserOn_BoardLink = False

            Dim intCardID As Integer = 0
            Dim v_card_id As Integer = intCardID
            Dim ret As Integer = 0
            Dim Board_ID As Integer = v_card_id
            ret = APS_set_board_param(intCardID, &H110, &H100)
            If ret = 0 Then
                ret = APS_switch_vao_table(intCardID, 0)
                If ret = 0 Then
                    ret = APS_start_vao(intCardID, 0, 1)
                    If ret = 0 Then
                        LaserOn_BoardLink = True
                    End If
                End If
            End If
        Catch ex As Exception
            Call MsgBox("LaserBoardLink Error")
        End Try
    End Function
    Friend Function LaserSetting(ByVal AxisID1 As Integer, ByVal pMode As Integer, ByVal pParamChange As String, ByVal pfixdParam As String, ByVal pFollowVType As Integer, ByVal pMaxV As Integer, ByVal pMinV As Integer, ByVal pPoint As Integer) As Boolean
        Try
            LaserSetting = False
            Dim param() As String = pParamChange.Split(CChar(",")) 'pmode = 0 Voltage 'pmode = 1 Dutycycle 'pmode = 2 Freq 'pmode = 3 Freq
            Dim intVAO(param.Length - 1) As Integer
            Dim intInterval As Integer
            Dim intAxis As Integer = 0
            Dim intIndex As Integer
            Dim intCardID As Integer = 0
            Dim ret As Integer = 0
            Dim cboVAOTable As Integer = 0
            Dim cboVAOMode As Integer = pMode ' Voltage=0 ' PWM with fixed freq=1 ' PWM with fixed width=2 ' PWM with fixed duty cycle =3 
            Dim txtVAOConfig As String = pfixdParam 'Fixed Param
            Dim cboVAOType As Integer = pFollowVType 'Feedback =0 Command =1
            Dim txtVAO_MaxV As Integer = CInt(pMaxV * m_Axis(AxisID1).Param.SwScale)
            Dim txtVAO_MinV As Integer = CInt(pMinV * m_Axis(AxisID1).Param.SwScale)
            Dim txtVAO_Point As Integer = pPoint  'Range is 1 ~ 32.
            'txtVAO_MaxV = 20000

            'Dim Frequency As Integer = CInt(param1) '20000     'Unit: Hz. Range is from 3 to 50000000.
            'Dim Width As Integer = CInt(param2)  '25000         'Unit: ns. Range is from 20 to 335544300.

            If param.Count > 0 Then
                If CDbl(txtVAO_Point) > 1 Then
                    intInterval = CInt((CDbl(txtVAO_MaxV) - CDbl(txtVAO_MinV)) / (CDbl(txtVAO_Point) - 1))
                Else
                    intInterval = CInt((CDbl(txtVAO_MaxV) - CDbl(txtVAO_MinV)))
                End If

                For intIndex = 0 To 1
                    intAxis = intAxis Or 2 '(2 ^ cboAxisID(intIndex).SelectedIndex)
                Next intIndex
                intAxis = 3


                For intIndex = 0 To param.Length - 1
                    intVAO(intIndex) = CInt(param(intIndex))
                Next intIndex

                ret = APS_set_vao_param(intCardID, cboVAOTable * 2, cboVAOMode)
                If ret < 0 Then
                    LaserSetting = False
                    Exit Function
                End If
                ret = APS_set_vao_param(intCardID, cboVAOTable * 2 + 1, cboVAOType)
                If ret < 0 Then
                    LaserSetting = False
                    Exit Function
                End If
                ret = APS_set_vao_param(intCardID, cboVAOTable + &H20, intAxis)
                If ret < 0 Then
                    LaserSetting = False
                    Exit Function
                End If
                ret = APS_set_vao_param(intCardID, cboVAOTable + &H10, CInt(txtVAOConfig))
                If ret < 0 Then
                    LaserSetting = False
                    Exit Function
                End If
                ret = APS_set_vao_table(intCardID, cboVAOTable, CInt(txtVAO_MinV), intInterval, CInt(txtVAO_Point), intVAO)
                If ret < 0 Then
                    LaserSetting = False
                    Exit Function
                End If



            End If



            Dim intErr As Integer
            intErr = APS_set_board_param(intCardID, &H110, &H100)
            If intErr < 0 Then
                LaserSetting = False
                Exit Function
            End If


            ret = APS_switch_vao_table(intCardID, 0)
            If ret < 0 Then
                LaserSetting = False
                Exit Function
            End If
            ret = APS_start_vao(intCardID, 0, 1)
            If ret < 0 Then
                LaserSetting = False
                Exit Function
            End If


            LaserSetting = True
        Catch ex As Exception
            LaserSetting = False
        End Try
    End Function

    Friend Function LaserOff() As Boolean
        Dim intCardID As Integer = 0
        Dim v_card_id As Integer = intCardID
        Dim Board_ID As Integer = v_card_id
        Dim CH As Integer = 0               'Range is from 0 to 1
        Dim ret As Integer
        LaserOff = False
        Try
            'Disable all PWM signals. 
            For CH = 0 To (m_channel - 1)
                ret = APS_set_pwm_on(intCardID, CH, 0)
                ret = APS_start_vao(intCardID, CH, 0)
            Next
            ret = APS_set_board_param(intCardID, &H110, -1)

            LaserOff = True
        Catch ex As Exception
            Call MsgBox("PWM_Off Error")
        End Try
    End Function
    Friend Function ChkFeederStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag
        Dim ret As Int32
        Dim stsID As Int32
        Dim errCode As Int32
        Dim groupId As Int32 = m_Axis(AxisID1).GroupID

        If m_Axis(AxisID1).GroupID = -1 Then
            groupId = 0
            m_Axis(AxisID1).GroupID = CShort(groupId)
            Dim axisAry(0 To 1) As Integer
            axisAry(0) = m_Axis(AxisID1).AxisID
            axisAry(1) = m_Axis(AxisID2).AxisID
            ret = APS_free_feeder_group(groupId)
            If (ret = ERR_NoError) Then
                ret = APS_set_feeder_group(groupId, 2, axisAry(0))
                If (ret = ERR_NoError) Then

                End If
            End If
        End If
        ChkFeederStop = enumMotionFlag.eNotReady
        With m_Axis(AxisID1)
            APS_get_feeder_feed_index(groupId, stsID)
            ret = APS_get_feeder_status(groupId, stsID, errCode)
            If (ret = ERR_NoError) Then
                If stsID = 0 Then
                    If ChkMultiStop(AxisID1, AxisID2) = enumMotionFlag.eReady Then
                        ChkFeederStop = enumMotionFlag.eReady
                    End If
                End If
            End If
        End With
    End Function
    Private m_MoveAdvTableIsThreadStarted As Boolean
    Public Property MoveAdvPointTableIsThreadStarted() As Boolean
        Get
            Return m_MoveAdvTableIsThreadStarted
        End Get
        Set(ByVal value As Boolean)
            m_MoveAdvTableIsThreadStarted = value
        End Set
    End Property
    Private m_MoveAdvTableIsThreadFinished As Boolean
    Public Property MoveAdvPointTableIsThreadFinished() As Boolean
        Get
            Return m_MoveAdvTableIsThreadFinished
        End Get
        Set(ByVal value As Boolean)
            m_MoveAdvTableIsThreadFinished = value
        End Set
    End Property
    Private m_MoveAdvTableEMGStop As Boolean
    Public Property MoveAdvTableEMGStop() As Boolean
        Get
            Return m_MoveAdvTableEMGStop
        End Get
        Set(ByVal value As Boolean)
            m_MoveAdvTableEMGStop = value
        End Set
    End Property
    Private m_MoveAdvTableErrMessage As String
    Public ReadOnly Property MoveAdvTableErrMessage As String
        Get
            Return m_MoveAdvTableErrMessage
        End Get
    End Property

    Private m_AdvPointTableAxisCount As Integer

    Friend Sub MoveAdvPointTable(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal rtnData As List(Of String), ByRef pResult As enumMotionFlag, ByVal AxisCount As Integer)
        pResult = enumMotionFlag.eNotSent
        Try
            Dim ret As Integer
            Dim intCardID As Integer = 0
            Dim PointTableID As Integer = 0
            m_AdvPointTableAxisCount = AxisCount
            If ChkStop(AxisID1) = enumMotionFlag.eReady Then
                If Not (m_Axis(AxisID1).IO.EMGStatus = enumMotionFlag.eHigh OrElse m_Axis(AxisID1).IO.AlarmSignal = enumMotionFlag.eHigh) OrElse m_Axis(AxisID1).IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse m_Axis(AxisID1).IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                    If ChkStop(AxisID2) = enumMotionFlag.eReady Then
                        If Not (m_Axis(AxisID2).IO.EMGStatus = enumMotionFlag.eHigh OrElse m_Axis(AxisID2).IO.AlarmSignal = enumMotionFlag.eHigh) OrElse m_Axis(AxisID2).IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse m_Axis(AxisID2).IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                            If m_MoveAdvTableIsThreadFinished Then
                                m_MoveAdvTableIsThreadStarted = False
                                m_MoveAdvTableErrMessage = ""
                                Dim intAxisID(1) As Integer
                                intAxisID(0) = m_Axis(AxisID1).AxisID
                                intAxisID(1) = m_Axis(AxisID2).AxisID
                                ret = APS_pt_enable(intCardID, PointTableID, m_AdvPointTableAxisCount, intAxisID)
                                If Not (ret >= 0) Then
                                    pResult = enumMotionFlag.eNotSent
                                    m_MoveAdvTableErrMessage = "Adv異常"
                                    Exit Sub
                                End If

                                For i As Integer = 0 To rtnData.Count - 1 Step 1
                                    Dim array_pos() As String = rtnData(i).Split(CChar(","))
                                    Dim velocityScale As Double = m_Axis(AxisID1).Param.SwScale
                                    If array_pos(0) = "Line" Then
                                        array_pos(2) = CStr(CDbl(array_pos(2)) * velocityScale)
                                        array_pos(3) = CStr(CDbl(array_pos(3)) * m_Axis(AxisID1).Param.SwScale)
                                        array_pos(4) = CStr(CDbl(array_pos(4)) * m_Axis(AxisID2).Param.SwScale)
                                        array_pos(7) = CStr(CDbl(array_pos(7)) * velocityScale)
                                        array_pos(8) = CStr(CDbl(array_pos(8)) * velocityScale)
                                        array_pos(9) = CStr(CDbl(array_pos(9)) * velocityScale)
                                        array_pos(10) = CStr(CDbl(array_pos(10)) * velocityScale)
                                    ElseIf array_pos(0) = "Arc_ce" Then
                                        array_pos(2) = CStr(CDbl(array_pos(2)) * velocityScale)
                                        array_pos(3) = CStr(CDbl(array_pos(3)) * m_Axis(AxisID1).Param.SwScale)
                                        array_pos(4) = CStr(CDbl(array_pos(4)) * m_Axis(AxisID2).Param.SwScale)
                                        array_pos(5) = CStr(CDbl(array_pos(5)) * m_Axis(AxisID1).Param.SwScale)
                                        array_pos(6) = CStr(CDbl(array_pos(6)) * m_Axis(AxisID2).Param.SwScale)
                                        array_pos(7) = CStr(CDbl(array_pos(7)) * velocityScale)
                                        array_pos(8) = CStr(CDbl(array_pos(8)) * velocityScale)
                                        array_pos(9) = CStr(CDbl(array_pos(9)) * velocityScale)
                                        array_pos(10) = CStr(CDbl(array_pos(10)) * velocityScale)
                                    End If
                                    rtnData(i) = array_pos(0)
                                    For j As Integer = 1 To array_pos.Length - 1 Step 1
                                        rtnData(i) += "," & array_pos(j)
                                    Next
                                Next
                                System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MoveAdvPointTable1), rtnData)
                                pResult = enumMotionFlag.eSent
                            Else
                                pResult = enumMotionFlag.eNotSent
                            End If
                        End If
                    Else
                        pResult = enumMotionFlag.eNotSent
                    End If
                End If
            Else
                pResult = enumMotionFlag.eNotSent
            End If
        Catch ex As Exception
            pResult = enumMotionFlag.eNotSent
            m_MoveAdvTableErrMessage = "Adv異常"
        Finally
        End Try
    End Sub

    Private Sub MoveAdvPointTable1(ByVal StateInfo As Object)
        Try
            Dim intCardID As Integer = 0
            Dim rtnData As List(Of String) = CType(StateInfo, Global.System.Collections.Generic.List(Of String))
            Dim ret As Integer
            Dim ptStatus As PTSTS
            Dim PointTableID As Integer = 0
            Dim IOchannel As Integer = 0
            Dim IOOnOff As Integer  'on =1 off =0
            Dim IOOn As Integer = 1
            Dim IOOff As Integer = 0

            Dim LastTime As Double
            'Dim axisAry(1) As Integer
            'axisAry(0) = m_Axis(AxisID1).AxisID
            'axisAry(1) = m_Axis(AxisID2).AxisID
            m_MoveAdvTableIsThreadFinished = False
            m_MoveAdvTableIsThreadStarted = True
            ret = APS_reset_pt_buffer(intCardID, PointTableID)
            If Not (ret >= 0) Then
                m_MoveAdvTableErrMessage = "Adv異常"
                Exit Try
            End If
            ret = APS_pt_set_s(intCardID, PointTableID, 0)
            If Not (ret >= 0) Then
                m_MoveAdvTableErrMessage = "Adv異常"
                Exit Try
            End If
            For idx As Integer = 0 To rtnData.Count - 1 Step 1
                LastTime = m_Timer.GetMilliseconds
                Do While (ptStatus.PntBufFreeSpace < 3) Or (ret < 0)
                    ret = APS_get_pt_status(intCardID, 0, ptStatus)
                    m_nowLine = CInt(ptStatus.RunningCnt)
                    If m_Timer.GetMilliseconds - LastTime > 30 * 1000 Then
                        m_MoveAdvTableErrMessage = "AdvPointTable異常"
                        Exit Try
                    End If
                    If m_MoveAdvTableEMGStop Then
                        m_MoveAdvTableEMGStop = False
                        m_MoveAdvTableErrMessage = "緊急停止"
                        Exit Try
                    End If
                Loop
                If Not (ret >= 0) Then
                    m_MoveAdvTableErrMessage = "Adv異常"
                    m_MoveAdvTableIsThreadFinished = True
                    Exit Try
                End If

                Dim Param() As String = rtnData(idx).Split(CChar(","))
                ' (0) = 號碼 (1) = Line or Arc_ce (2) = ABS or Relative 
                '(3) = Vm (4) = X1 (5) = Y1 (6) = X2 (7) = Y2 (8) = Acc (9) = Dec (10) = Vs (11) = Ve (12) = Angle (13)ON/OFF 設置

                If Param.Length > 10 Then
                    If Param(12) = "ON" Then '設定ON/OFF
                        If Param.Length = 13 Then
                            ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, IOchannel, IOOn)
                        Else
                            For i As Integer = 13 To Param.Length - 1 Step 1
                                ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, CInt(Param(i)), IOOn)
                            Next
                        End If

                    Else
                        If Param.Length = 13 Then
                            ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, IOchannel, IOOff)
                        Else
                            For i As Integer = 13 To Param.Length - 1 Step 1
                                ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, CInt(Param(i)), IOOff)
                            Next
                        End If

                    End If

                    ret = APS_pt_set_vs(intCardID, PointTableID, CDbl((CInt(Param(9))))) 'Start Velocity
                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If
                    ret = APS_pt_set_vm(intCardID, PointTableID, CDbl((CInt(Param(2))))) 'Max Velocity
                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If
                    ret = APS_pt_set_ve(intCardID, PointTableID, CDbl((CInt(Param(10))))) 'End Velocity
                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If
                    ret = APS_pt_set_acc(intCardID, PointTableID, CDbl((CInt(Param(7))))) 'ACC
                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If
                    ret = APS_pt_set_dec(intCardID, PointTableID, CDbl((CInt(Param(8))))) 'Dec
                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If

                    If Not (ret >= 0) Then
                        m_MoveAdvTableErrMessage = "Adv異常"
                        Exit Try
                    End If

                    If Not (Param(1) = "ABS") Then '設定Relative or Absoulte
                        ret = APS_pt_set_relative(intCardID, PointTableID)
                        If Not (ret >= 0) Then
                            m_MoveAdvTableErrMessage = "Adv異常"
                            Exit Try
                        End If
                    Else
                        ret = APS_pt_set_absolute(intCardID, PointTableID)
                        If Not (ret >= 0) Then
                            m_MoveAdvTableErrMessage = "Adv異常"
                            Exit Try
                        End If
                    End If
                End If





                Select Case Param(0)
                    Case "Wait"
                        Dim ptDwlTime As PTDWL
                        ptDwlTime.DwTime = CDbl(CInt(Param(3)))
                        ret = APS_pt_dwell(intCardID, PointTableID, ptDwlTime, ptStatus)
                    Case "Line"
                        Dim ptPosL As PTLINE
                        ptPosL.Dimension = 2
                        For intLoop = 0 To m_AdvPointTableAxisCount - 1 Step 1
                            Select Case intLoop
                                Case 0
                                    ptPosL.Pos_0 = CDbl(CInt(Param(3)))
                                Case 1
                                    ptPosL.Pos_1 = CDbl(CInt(Param(4)))
                            End Select
                        Next intLoop
                        ret = APS_pt_line(intCardID, PointTableID, ptPosL, ptStatus)
                        If Not (ret >= 0) Then
                            m_MoveAdvTableErrMessage = "Adv異常"
                            m_MoveAdvTableIsThreadFinished = True
                            Exit Try
                        End If
                    Case "Arc_ce"
                        If m_AdvPointTableAxisCount = 2 Then
                            Dim ptPos2E As PTA2CE

                            ptPos2E.index_0 = 0
                            ptPos2E.index_1 = 1
                            ptPos2E.Center_0 = CDbl((CInt(Param(3))))
                            ptPos2E.Center_1 = CDbl((CInt(Param(4))))
                            ptPos2E.End_pos_0 = CDbl((CInt(Param(5))))
                            ptPos2E.End_pos_1 = CDbl((CInt(Param(6))))
                            ptPos2E.Dir = CShort(CDbl((CInt(Param(11)))))
                            ret = APS_pt_arc2_ce(intCardID, PointTableID, ptPos2E, ptStatus)
                        End If
                End Select
                'If Param.Length > 10 Then

                '    If Param.Length = 13 Then
                '        If Param(12) = "ON" Then '設定ON/OFF
                '            ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, IOchannel, IOOff)
                '        Else

                '        End If
                '    Else
                '        For i As Integer = 13 To Param.Length - 1 Step 1
                '            ret = APS_pt_ext_set_do_ch(intCardID, PointTableID, CInt(Param(i)), IOOff)
                '        Next
                '    End If

                'End If

                If m_MoveAdvTableEMGStop Then
                    m_MoveAdvTableEMGStop = False
                    m_MoveAdvTableErrMessage = "緊急停止"
                    Exit Try
                End If
                ret = APS_get_pt_status(intCardID, 0, ptStatus)
                m_nowLine = CInt(ptStatus.RunningCnt)
                If (ptStatus.PntBufUsageSpace > 35) Or (idx = rtnData.Count - 1) Then
                    ret = APS_get_pt_status(intCardID, 0, ptStatus)
                    m_nowLine = CInt(ptStatus.RunningCnt)
                    Dim infor As String = (Convert.ToString(ptStatus.BitSts, 2))
                    Dim cc As String = infor(infor.Length - 1)
                    If cc = "0" Then
                        ret = APS_pt_start(intCardID, 0)
                    End If
                End If
            Next
        Catch ex As Exception
            m_MoveAdvTableErrMessage = ex.ToString
        End Try
        m_MoveAdvTableIsThreadFinished = True
    End Sub

    Friend Function AdvanceEMGStop(ByRef idx_line As Integer) As enumMotionFlag
        Try
            AdvanceEMGStop = enumMotionFlag.eNotSent
            Dim intCardID As Integer = 0
            Dim ptStatus As PTSTS
            Dim ret As Integer
            ret = APS_get_pt_status(intCardID, 0, ptStatus)
            idx_line = CInt(ptStatus.RunningCnt)
            ret = APS_pt_stop(intCardID, 0)
            APS_reset_pt_buffer(intCardID, 0)
            APS_pt_disable(intCardID, 0)
            AdvanceEMGStop = enumMotionFlag.eSent
        Catch ex As Exception

        End Try

    End Function
    Friend Function IOTest(ByVal IO As Integer, ByVal IOOnOff As Integer) As enumMotionFlag
        Try
            IOTest = enumMotionFlag.eNotSent
            Dim intCardID As Integer = 0
            Dim ret As Integer
            ret = APS_write_d_channel_output(intCardID, 0, IO, IOOnOff)

            IOTest = enumMotionFlag.eSent
        Catch ex As Exception

        End Try

    End Function
    Friend Function ChkAdvanceStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef idx_line As Integer) As enumMotionFlag
        Try
            ChkAdvanceStop = enumMotionFlag.eNotReady
            Dim intCardID As Integer = 0
            Dim ptStatus As PTSTS
            Dim ret As Integer
            ret = APS_get_pt_status(intCardID, 0, ptStatus)

            If (ptStatus.PntBufUsageSpace = 0) Then
                ret = APS_get_pt_status(intCardID, 0, ptStatus)
                Try
                    idx_line = CInt(ptStatus.RunningCnt)
                Catch ex As Exception

                End Try
                APS_pt_disable(intCardID, 0)
                ChkAdvanceStop = enumMotionFlag.eReady
            End If
            Try
                idx_line = CInt(ptStatus.RunningCnt)
            Catch ex As Exception

            End Try
        Catch ex As Exception

        End Try
    End Function
    Private m_nowLine As Integer
    Friend Function ChkAdvanceNowLine(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByRef idx_line As Integer) As enumMotionFlag
        Try
            ChkAdvanceNowLine = enumMotionFlag.eNotReady
            Dim intCardID As Integer = 0
            Dim ptStatus As PTSTS
            Dim ret As Integer
            If m_MoveAdvTableIsThreadFinished Then
                ret = APS_get_pt_status(intCardID, 0, ptStatus)
                m_nowLine = CInt(ptStatus.RunningCnt)
                idx_line = m_nowLine
            Else
                idx_line = m_nowLine
            End If
        
            ChkAdvanceNowLine = enumMotionFlag.eReady
        Catch ex As Exception

        End Try
    End Function


    Friend Sub MoveHome(ByVal StateInfo As Object) Implements IPseudoMotion.MoveHome
        'Step1 檢查是否在感應器上
        'Step2 快速往感應器復歸
        'Step3 等待復歸完畢
        'Step4 移出感應器
        'Step5 等待移動完畢
        'Step6 慢速往感應器復歸
        'Step7 等待復歸完畢
        'Step8 參考值歸零
        Dim ret As Integer
        Dim axisID As Integer = CInt(StateInfo)
        Dim home_Dir As Short
        Dim status As enumMotionFlag

        Try
            m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eNotReady
            m_Axis(axisID).IsThreadFinished = False
            m_Axis(axisID).IsThreadStarted = True
            m_Axis(axisID).IsHomming = True
            Call ServoOn(axisID)
            m_Axis(axisID).ErrMessage = ""
            SetHomeOffset(axisID)
            With m_Axis(axisID)
                Call ChkStatus(axisID)
                m_Axis(axisID).ErrMessage = ""
                home_Dir = CShort(.Mode.HomeDir) '回原点方式。0：正方向回原点，1：负方向回原点
                If home_Dir = 1 Then
                    Do
                        Call Threading.Thread.Sleep(1)
                        If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh Then
                            Call SetHomeOffset(axisID)
                            Do
                                Call Threading.Thread.Sleep(1)
                                Call MoveAbs(axisID, .Home.Offset - .Home.EscapeDis, status, 0.5, 0.5)
                                If status = enumMotionFlag.eSent Then Exit Do
                            Loop
                            Call Threading.Thread.Sleep(100)
                            Do
                                Call Threading.Thread.Sleep(1)
                                If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                                If .Home.Cancel Then
                                    .Home.Cancel = False
                                    m_Axis(axisID).IsThreadFinished = True : Exit Sub
                                End If
                            Loop
                        ElseIf .IO.NegativeLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                            Call SetHomeOffset(axisID)
                            Do
                                Call Threading.Thread.Sleep(1)
                                Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.5, 0.5)
                                'Call MoveAbs(axisID, 0, status, 0.5, 0.5)
                                If status = enumMotionFlag.eSent Then Exit Do
                            Loop
                            Call Threading.Thread.Sleep(100)
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
                        ElseIf .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
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
                End If

                If .IO.NegativeLimitSwitch = enumMotionFlag.eLow OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eLow Then
                    ' 1. Select home mode and config home parameters
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_MODE, m_Axis(axisID).Mode.HomeMode) 'Set home mode 0: home mode 1 (ORG)  1: home mode 2 (EL) 2: home mode 3 (EZ)
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_DIR, m_Axis(axisID).Mode.HomeDir) 'Set home direction 0: positive direction 1: negative(direction)
                    ret = APS_set_axis_param_f(m_Axis(axisID).AxisID, PRA_HOME_CURVE, 0.5) ' Set acceleration paten (T-curve) [ 0.0 ~ 1.0 ] 0:T(curve)  1:S(curve)
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_ACC, CInt(m_Axis(axisID).Home.Acc * m_Axis(axisID).Param.SwScale)) 'Set homing acceleration rate
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_VM, CInt(m_Axis(axisID).Home.HighSpeed * m_Axis(axisID).Param.SwScale)) 'Set homing maximum velocity.
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_VO, CInt(m_Axis(axisID).Home.LowSpeed * m_Axis(axisID).Param.SwScale)) 'Set homing
                    ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_EZA, 0) 'Set homing 0: Not enable 1: Enable()
                    'ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_SHIFT, 0) 'Set homing
                    'ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_POS, CInt(m_Axis(axisID).Home.Offset * m_Axis(axisID).Param.SwScale)) 'Set homing
                    ' 2. Start home move
                    ret = APS_home_move(m_Axis(axisID).AxisID) 'Start homing
                    If (ret = ERR_NoError) Then
                        '3. Wait home move done,
                        Do
                            Thread.Sleep(100)
                            If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                            If m_Axis(axisID).Home.Cancel Then Exit Do
                        Loop
                        home_Dir = CShort(.Mode.HomeDir) '回原点方式。1：正方向回原点，2：负方向回原点
                        If home_Dir = 1 Then
                            Do
                                Call Threading.Thread.Sleep(1)
                                If .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.OriginSwitch = enumMotionFlag.eHigh Then
                                    Call SetHomeOffset(axisID)
                                    Do
                                        Call Threading.Thread.Sleep(1)
                                        Call MoveAbs(axisID, .Home.Offset + .Home.EscapeDis, status, 0.5, 0.5)
                                        If status = enumMotionFlag.eSent Then Exit Do
                                    Loop
                                    Call Threading.Thread.Sleep(100)
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
                        End If

                        If .IO.NegativeLimitSwitch = enumMotionFlag.eLow OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eLow Then
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_MODE, m_Axis(axisID).Mode.HomeMode) 'Set home mode 0: home mode 1 (ORG)  1: home mode 2 (EL) 2: home mode 3 (EZ)
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_DIR, m_Axis(axisID).Mode.HomeDir) 'Set home direction 0: positive direction 1: negative(direction)
                            ret = APS_set_axis_param_f(m_Axis(axisID).AxisID, PRA_HOME_CURVE, 0.5) ' Set acceleration paten (T-curve) [ 0.0 ~ 1.0 ] 0:T(curve)  1:S(curve)
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_ACC, CInt(m_Axis(axisID).Home.Acc * m_Axis(axisID).Param.SwScale)) 'Set homing acceleration rate
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_VM, CInt(m_Axis(axisID).Home.LowSpeed * m_Axis(axisID).Param.SwScale)) 'Set homing maximum velocity.
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_VO, CInt(m_Axis(axisID).Home.LowSpeed / 2 * m_Axis(axisID).Param.SwScale)) 'Set homing
                            ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_EZA, 0) 'Set homing 0: Not enable 1: Enable()
                            'ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_SHIFT, 0) 'Set homing
                            'ret = APS_set_axis_param(m_Axis(axisID).AxisID, PRA_HOME_POS, CInt(m_Axis(axisID).Home.Offset * m_Axis(axisID).Param.SwScale)) 'Set homing
                            ret = APS_home_move(m_Axis(axisID).AxisID) 'Start homing
                            If (ret = ERR_NoError) Then
                                Do
                                    Thread.Sleep(100)
                                    If ChkStop(axisID) = enumMotionFlag.eReady Then Exit Do
                                    If m_Axis(axisID).Home.Cancel Then Exit Do
                                Loop
                        If Not m_Axis(axisID).Home.Cancel Then
                            ' 4. Check home move success or not
                            If m_Axis(axisID).ErrMessage = "" Then
                                Call Threading.Thread.Sleep(2000)
                                Call SetHomeOffset(axisID)
                                m_Axis(axisID).Status.HomeRdy = enumMotionFlag.eHigh
                            Else
                                Call EmgStop(axisID)
                            End If
                        End If
                    End If
                End If

                    End If
                End If
                'Call Threading.Thread.Sleep(2000)
                'Call SetHomeOffset(axisID)
                '.Status.HomeRdy = enumMotionFlag.eHigh
            End With
        Catch ex As Exception

        Finally
            m_Axis(axisID).IsHomming = False
            m_Axis(axisID).IsThreadFinished = True
        End Try
    End Sub
    Friend Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pResult As enumMotionFlag) Implements IPseudoMotion.MoveLinear
        Dim DrivingVel As Integer
        Dim DrivingStrVel As Integer
        Dim DrivingAcc As Double
        Dim DrivingDec As Double
        Dim status As enumMotionFlag
        Dim LineAxisArray(0 To 1) As Integer
        Dim LinePosArray(0 To 1) As Integer
        Dim ret As Integer
        Try
            pResult = enumMotionFlag.eNotSent

            If ChkMultiStop(AxisID1, AxisID2) = enumMotionFlag.eReady Then
                Call ChkSwLimit(AxisID1, EndX, status)
                If status = enumMotionFlag.eHigh Then
                    Call ChkSwLimit(AxisID2, EndY, status)
                    If status = enumMotionFlag.eHigh Then
                        With m_Axis(AxisID1)
                            If .IO.EMGStatus = enumMotionFlag.eHigh OrElse .IO.AlarmSignal = enumMotionFlag.eHigh Then 'OrElse .IO.PositiveLimitSwitch = enumMotionFlag.eHigh OrElse .IO.NegativeLimitSwitch = enumMotionFlag.eHigh Then
                            Else
                                If m_Axis(AxisID1).IsExternalParameters Then
                                    DrivingVel = CInt(m_Axis(AxisID1).Speed.MaxVelExt * m_Axis(AxisID1).Param.SwScale)
                                    DrivingStrVel = CInt(m_Axis(AxisID1).Speed.StrVel * m_Axis(AxisID1).Param.SwScale)
                                    DrivingAcc = m_Axis(AxisID1).Speed.AccExt * m_Axis(AxisID1).Param.SwScale
                                    DrivingDec = m_Axis(AxisID1).Speed.DecExt * m_Axis(AxisID1).Param.SwScale
                                Else
                                    DrivingVel = CInt(m_Axis(AxisID1).Speed.MaxVel * m_Axis(AxisID1).Param.SwScale)
                                    DrivingStrVel = CInt(m_Axis(AxisID1).Speed.StrVel * m_Axis(AxisID1).Param.SwScale)
                                    DrivingAcc = m_Axis(AxisID1).Speed.AccLinear * m_Axis(AxisID1).Param.SwScale
                                    DrivingDec = m_Axis(AxisID1).Speed.DecLinear * m_Axis(AxisID1).Param.SwScale
                                End If
                                If DrivingVel >= m_Axis(AxisID1).Speed.MaxConstrainedVel Then
                                    DrivingVel = CInt(m_Axis(AxisID1).Speed.MaxConstrainedVel)
                                End If
                                If DrivingVel >= m_Axis(AxisID2).Speed.MaxConstrainedVel Then
                                    DrivingVel = CInt(m_Axis(AxisID2).Speed.MaxConstrainedVel)
                                End If

                                LineAxisArray(0) = m_Axis(AxisID1).AxisID
                                LineAxisArray(1) = m_Axis(AxisID2).AxisID
                                LinePosArray(0) = CInt(EndX * m_Axis(AxisID1).Param.SwScale)
                                LinePosArray(1) = CInt(EndY * m_Axis(AxisID2).Param.SwScale)
                                ret = APS_set_axis_param_f(m_Axis(AxisID1).AxisID, PRA_CURVE, m_Axis(AxisID1).Speed.Sacc) 'Set S-factor
                                ret = APS_set_axis_param_f(m_Axis(AxisID1).AxisID, PRA_ACC, DrivingAcc) 'Set acceleration
                                ret = APS_set_axis_param_f(m_Axis(AxisID1).AxisID, PRA_DEC, DrivingDec) 'Set deceleration
                                ret = APS_absolute_linear_move(2, LineAxisArray(0), LinePosArray(0), DrivingVel)
                            End If
                        End With
                        If ret = ERR_NoError Then
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
        Catch ex As Exception
        Finally
        End Try


        'Dim maxVel As Double
        'Dim accLinear As Double
        'Dim decLinear As Double

        'If m_Axis(AxisID1).IsExternalParameters Then
        '    maxVel = m_Axis(AxisID1).Speed.MaxVel
        '    accLinear = m_Axis(AxisID1).Speed.Acc
        '    decLinear = m_Axis(AxisID1).Speed.Dec
        '    m_Axis(AxisID1).Speed.MaxVel = m_Axis(AxisID1).Speed.MaxVelExt
        '    m_Axis(AxisID1).Speed.Acc = m_Axis(AxisID1).Speed.AccExt
        '    m_Axis(AxisID1).Speed.Dec = m_Axis(AxisID1).Speed.DecExt
        'End If

        'Call MoveAbs(AxisID1, EndX, pResult)
        'If m_Axis(AxisID1).IsExternalParameters Then
        '    m_Axis(AxisID1).Speed.MaxVel = maxVel
        '    m_Axis(AxisID1).Speed.Acc = accLinear
        '    m_Axis(AxisID1).Speed.Dec = decLinear
        'End If

        'If m_Axis(AxisID1).IsExternalParameters Then
        '    maxVel = m_Axis(AxisID2).Speed.MaxVel
        '    accLinear = m_Axis(AxisID2).Speed.Acc
        '    decLinear = m_Axis(AxisID2).Speed.Dec
        '    m_Axis(AxisID2).Speed.MaxVel = m_Axis(AxisID1).Speed.MaxVelExt
        '    m_Axis(AxisID2).Speed.Acc = m_Axis(AxisID1).Speed.AccExt
        '    m_Axis(AxisID2).Speed.Dec = m_Axis(AxisID1).Speed.DecExt
        'End If

        'Call MoveAbs(AxisID2, EndY, pResult)
        'If m_Axis(AxisID1).IsExternalParameters Then
        '    m_Axis(AxisID2).Speed.MaxVel = maxVel
        '    m_Axis(AxisID2).Speed.Acc = accLinear
        '    m_Axis(AxisID2).Speed.Dec = decLinear
        'End If


    End Sub
    Friend Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff
        Dim ret As Integer
        Dim servoOff = 0
        Try
            ret = APS_set_servo_on(m_Axis(AxisID).AxisID, servoOff)
            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn
        Dim ret As Integer
        Dim servoOn = 1
        Try
            ret = APS_set_servo_on(m_Axis(AxisID).AxisID, servoOn)
            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer

    End Sub
    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset
        Dim offset As Integer
        Dim ret As Integer
        Try
            With m_Axis(AxisID)
                offset = CInt(.Home.Offset)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub SetPositionOffset(ByVal AxisID As Integer, ByVal poffset As Integer)
        Dim offset As Integer
        Dim ret As Integer
        Try
            With m_Axis(AxisID)
                offset = poffset
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_command_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
                ret = APS_set_position_f(m_Axis(AxisID).AxisID, offset * m_Axis(AxisID).Param.SwScale)
            End With
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode
        Dim ret As Integer
        Try
            With m_Axis(AxisID)
                ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TG_TRG0_SRC, &H0)
                ret = APS_set_trigger_param(m_Axis(AxisID).CardID, TG_TCMP0_EN, &H0)
            End With
        Catch ex As Exception
        Finally
        End Try


        'Dim ret As Integer
        'Dim servoOn = 1
        'Try
        '    ' PEL/MEL input logic 0:Not inverse 1:Inverse
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_EL_LOGIC, m_Axis(AxisID).Mode.LimitLogic)
        '    ' ORG input logic 0:Not inverse 1:Inverse
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_ORG_LOGIC, m_Axis(AxisID).Mode.OrgLogic)
        '    'Stop mode when EL turns on. Note: Deceleration profile is given according to PRA_SD_DEC. 0: Deceleration stop 1: Stop immediately
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_EL_MODE, m_Axis(AxisID).Mode.LimitMode)
        '    'Motion done condition ( Affective with motion stats NSTP bit) 0: Command done; 1: Command done with INP
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_MDM_CONDI, 0)
        '    'Set ALM logic 0: Low active 1:High(active)
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_ALM_LOGIC, m_Axis(AxisID).Mode.AlarmLogic)
        '    'Set EZ logic
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_EZ_LOGIC, m_Axis(AxisID).Mode.EZLogic)
        '    'Soft PEL enable 0: Disable 1:Reserved 2:Soft(-Limit(SPEL))
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_SPEL_EN, 0)
        '    'PRA_SMEL_EN 0: Disable 1:Reserved 2:Soft(-Limit(SMEL))
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_SMEL_EN, 0)
        '    'Pulse input mode 
        '    '0:DEC_OUT_DIR_MODE0
        '    '1:DEC_CW_CCW_MODE0
        '    '2:DEC_1XAB
        '    '3:DEC_2XAB
        '    '4:DEC_4XAB
        '    '5:DEC_OUT_DIR_MODE1
        '    '6:DEC_OUT_DIR_MODE2
        '    '7:DEC_OUT_DIR_MODE3
        '    '8:DEC_CW_CCW_MODE1
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_PLS_IPT_MODE, m_Axis(AxisID).Mode.PulseOutMode)
        '    'Pulse output mode
        '    '0x00: OUT/DIR
        '    '0x01: CW/CCW
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_PLS_OPT_MODE, m_Axis(AxisID).Mode.PulseInputMode)
        '    'Encoder direction
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_ENCODER_DIR, 0)
        '    'Move ratio
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_MOVE_RATIO, 1)
        '    'Set inp logic 0:Not inverse 1:Inverse
        '    ret = APS_set_axis_param_f(m_Axis(AxisID).AxisID, PRA_INP_LOGIC, m_Axis(AxisID).Mode.InpLogic)
        '    If ret = ERR_NoError Then
        '    End If
        'Catch ex As Exception
        'Finally
        'End Try


    End Sub
    Friend Sub SlowStop(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop
        Dim ret As Integer
        Dim dec As Integer
        Try
            dec = CInt(m_Axis(AxisID).Speed.Dec * m_Axis(AxisID).Param.SwScale)
            ret = APS_set_axis_param(m_Axis(AxisID).AxisID, PRA_STP_DEC, dec)
            ret = APS_stop_move(m_Axis(AxisID).AxisID)
            If ret = ERR_NoError Then
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub





#End Region
End Class

Friend Class CAdlinkAMP204UDO
    Inherits CAdlinkAMP204Base
    Private m_Timer As Timer.CHighResolutionTimer
    Private Shared m_WiringID(63) As Integer
    Const __MAX_DO_CH = (24)
    Private m_DO() As CDOBased

    Public Sub New(ByRef pDO() As CDOBased)
        m_DO = pDO
        m_Timer = New CHighResolutionTimer
    End Sub

    Friend Sub CylGo(ByVal CylIdx As Integer, ByVal Status As enumCyllogic)
        Try
            Dim Board_ID As Integer = m_DO(CylIdx).CardIDAction
            Dim digital_output_value As Integer = 0
            Dim do_ch(__MAX_DO_CH) As Integer

            APS_read_d_output(Board_ID, 0, digital_output_value)
            For i = 0 To (__MAX_DO_CH - 1)
                do_ch(i) = ((digital_output_value >> i) And 1)
            Next


            Dim cardId As Integer = 0
            Dim portId As Integer = 0
            Dim bitId As Integer

            Dim rtn As Byte = 0
            Dim data As Byte = 0
            Dim errCode As Automation.BDaq.ErrorCode = 0
            Dim pOn As Integer = 1
            Dim pOff As Integer = 0

            Select Case Status
                Case enumCyllogic.Normal

                    cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDAction) = pOff

                        digital_output_value = 0
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDNormal) = pOn

                        digital_output_value = pOn
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    If m_DO(CylIdx).Status = enumCyllogic.Normal Then
                    Else
                        m_DO(CylIdx).Status = enumCyllogic.Normal
                        m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                        m_DO(CylIdx).ProcessNum = 10
                    End If

                Case enumCyllogic.CloseAll

                    cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDAction) = pOff

                        digital_output_value = 0
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDNormal) = pOff

                        digital_output_value = pOff
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    If m_DO(CylIdx).Status = enumCyllogic.CloseAll Then
                    Else
                        m_DO(CylIdx).Status = enumCyllogic.CloseAll
                        m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                        m_DO(CylIdx).ProcessNum = 10
                    End If

                Case enumCyllogic.Action
                    cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDAction) = pOn

                        digital_output_value = 0
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                    If cardId <> -1 AndAlso bitId <> -1 AndAlso bitId >= 0 AndAlso bitId < __MAX_DO_CH Then
                        do_ch(m_DO(CylIdx).BitIDNormal) = pOff

                        digital_output_value = pOff
                        For i = 0 To (__MAX_DO_CH - 1)
                            digital_output_value = (digital_output_value) Or (do_ch(i) << i)
                        Next
                        APS_write_d_output(Board_ID, 0, digital_output_value)
                    End If

                    If m_DO(CylIdx).Status = enumCyllogic.Action Then
                    Else
                        m_DO(CylIdx).Status = enumCyllogic.Action
                        m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                        m_DO(CylIdx).ProcessNum = 10
                    End If
            End Select
        Catch ex As Exception

        End Try

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Friend Class CAdlinkAMP204UDI
    Inherits CAdlinkAMP204Base
    Private m_Timer As Timer.CHighResolutionTimer
    Private Shared m_WiringID(63) As Integer
    Const __MAX_DI_CH = (24)
    Private m_DI() As CDIBased

    Public Sub New(ByRef pDI() As CDIBased)
        m_DI = pDI
        m_Timer = New CHighResolutionTimer
    End Sub

    Friend ReadOnly Property WiringID(ByVal SnrIdx As Integer) As Integer
        Get
            Dim WiringIdx As Integer
            If (m_DI(SnrIdx).BitID >= LBound(m_WiringID)) And m_DI(SnrIdx).BitID <= UBound(m_WiringID) Then
                WiringIdx = m_WiringID(m_DI(SnrIdx).BitID)
            End If
            Return WiringIdx
        End Get
    End Property
    Friend Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Dim Board_ID As Integer = m_DI(SnrIdx).CardID
        If (Board_ID = -1) Then
            pStatus = False
            Exit Sub
        End If
        Dim digital_input_value As Integer = 0
        Dim di_ch(__MAX_DI_CH) As Integer
        Dim pOn As Integer = 1
        Dim pOff As Integer = 0
        APS_read_d_input(Board_ID, 0, digital_input_value)
        For i = 0 To (__MAX_DI_CH - 1)
            di_ch(i) = ((digital_input_value >> i) And 1)
        Next

        If m_DI(SnrIdx).Logic Then
            If di_ch(m_DI(SnrIdx).BitID) = pOn Then
                pStatus = True
            Else
                pStatus = False
            End If
        Else
            If di_ch(m_DI(SnrIdx).BitID) = pOff Then
                pStatus = True
            Else
                pStatus = False
            End If
        End If

    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
