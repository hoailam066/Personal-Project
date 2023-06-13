Imports System.Runtime.InteropServices

''Imports Timer
Friend Class CD2kDaskAO
    Implements IDisposable
#Region "D2K_DASK"
    'ADLink PCI Card Type
    Private Const DAQ_2010 As Short = 1
    Private Const DAQ_2205 As Short = 2
    Private Const DAQ_2206 As Short = 3
    Private Const DAQ_2005 As Short = 4
    Private Const DAQ_2204 As Short = 5
    Private Const DAQ_2006 As Short = 6
    Private Const DAQ_2501 As Short = 7
    Private Const DAQ_2502 As Short = 8
    Private Const DAQ_2208 As Short = 9
    Private Const DAQ_2213 As Short = 10
    Private Const DAQ_2214 As Short = 11
    Private Const DAQ_2016 As Short = 12
    Private Const DAQ_2020 As Short = 13
    Private Const DAQ_2022 As Short = 14

    Private Const MAX_CARD As Short = 32

    'Error Code
    Private Const NoError As Short = 0
    Private Const ErrorUnknownCardType As Short = -1
    Private Const ErrorInvalidCardNumber As Short = -2
    Private Const ErrorTooManyCardRegistered As Short = -3
    Private Const ErrorCardNotRegistered As Short = -4
    Private Const ErrorFuncNotSupport As Short = -5
    Private Const ErrorInvalidIoChannel As Short = -6
    Private Const ErrorInvalidAdRange As Short = -7
    Private Const ErrorContIoNotAllowed As Short = -8
    Private Const ErrorDiffRangeNotSupport As Short = -9
    Private Const ErrorLastChannelNotZero As Short = -10
    Private Const ErrorChannelNotDescending As Short = -11
    Private Const ErrorChannelNotAscending As Short = -12
    Private Const ErrorOpenDriverFailed As Short = -13
    Private Const ErrorOpenEventFailed As Short = -14
    Private Const ErrorTransferCountTooLarge As Short = -15
    Private Const ErrorNotDoubleBufferMode As Short = -16
    Private Const ErrorInvalidSampleRate As Short = -17
    Private Const ErrorInvalidCounterMode As Short = -18
    Private Const ErrorInvalidCounter As Short = -19
    Private Const ErrorInvalidCounterState As Short = -20
    Private Const ErrorInvalidBinBcdParam As Short = -21
    Private Const ErrorBadCardType As Short = -22
    Private Const ErrorInvalidDaRange As Short = -23
    Private Const ErrorAdTimeOut As Short = -24
    Private Const ErrorNoAsyncAI As Short = -25
    Private Const ErrorNoAsyncAO As Short = -26
    Private Const ErrorNoAsyncDI As Short = -27
    Private Const ErrorNoAsyncDO As Short = -28
    Private Const ErrorNotInputPort As Short = -29
    Private Const ErrorNotOutputPort As Short = -30
    Private Const ErrorInvalidDioPort As Short = -31
    Private Const ErrorInvalidDioLine As Short = -32
    Private Const ErrorContIoActive As Short = -33
    Private Const ErrorDblBufModeNotAllowed As Short = -34
    Private Const ErrorConfigFailed As Short = -35
    Private Const ErrorInvalidPortDirection As Short = -36
    Private Const ErrorBeginThreadError As Short = -37
    Private Const ErrorInvalidPortWidth As Short = -38
    Private Const ErrorInvalidCtrSource As Short = -39
    Private Const ErrorOpenFile As Short = -40
    Private Const ErrorAllocateMemory As Short = -41
    Private Const ErrorDaVoltageOutOfRange As Short = -42
    Private Const ErrorInvalidSyncMode As Short = -43
    Private Const ErrorInvalidBufferID As Short = -44
    Private Const ErrorInvalidCNTInterval As Short = -45
    Private Const ErrorReTrigModeNotAllowed As Short = -46
    Private Const ErrorResetBufferNotAllowed As Short = -47
    Private Const ErrorAnaTriggerLevel As Short = -48
    Private Const ErrorDAQEvent As Short = -49
    Private Const ErrorInvalidCounterValue As Short = -50
    Private Const ErrorOffsetCalibration As Short = -51
    Private Const ErrorGainCalibration As Short = -52
    Private Const ErrorCountOutofSDRAMSize As Short = -53
    Private Const ErrorNotStartTriggerModule As Short = -54
    Private Const ErrorInvalidRouteLine As Short = -55
    Private Const ErrorInvalidSignalCode As Short = -56
    Private Const ErrorInvalidSignalDirection As Short = -57
    Private Const ErrorTRGOSCalibration As Short = -58
    Private Const ErrorNoSDRAM As Short = -59
    Private Const ErrorIntegrationGain As Short = -60
    Private Const ErrorAcquisitionTiming As Short = -61
    Private Const ErrorIntegrationTiming As Short = -62
    Private Const ErrorInvalidTimeBase As Short = -70
    Private Const ErrorUndefinedParameter As Short = -71
    'Error number for calibration API
    Private Const ErrorCalAddress As Short = -110
    Private Const ErrorInvalidCalBank As Short = -111
    'Error code for driver API
    Private Const ErrorConfigIoctl As Short = -201
    Private Const ErrorAsyncSetIoctl As Short = -202
    Private Const ErrorDBSetIoctl As Short = -203
    Private Const ErrorDBHalfReadyIoctl As Short = -204
    Private Const ErrorContOPIoctl As Short = -205
    Private Const ErrorContStatusIoctl As Short = -206
    Private Const ErrorPIOIoctl As Short = -207
    Private Const ErrorDIntSetIoctl As Short = -208
    Private Const ErrorWaitEvtIoctl As Short = -209
    Private Const ErrorOpenEvtIoctl As Short = -210
    Private Const ErrorCOSIntSetIoctl As Short = -211
    Private Const ErrorMemMapIoctl As Short = -212
    Private Const ErrorMemUMapSetIoctl As Short = -213
    Private Const ErrorCTRIoctl As Short = -214
    Private Const ErrorGetResIoctl As Short = -215

    'Synchronous Mode
    Private Const SYNCH_OP As Short = 1
    Private Const ASYNCH_OP As Short = 2

    'AD Range
    Private Const AD_B_10_V As Short = 1
    Private Const AD_B_5_V As Short = 2
    Private Const AD_B_2_5_V As Short = 3
    Private Const AD_B_1_25_V As Short = 4
    Private Const AD_B_0_625_V As Short = 5
    Private Const AD_B_0_3125_V As Short = 6
    Private Const AD_B_0_5_V As Short = 7
    Private Const AD_B_0_05_V As Short = 8
    Private Const AD_B_0_005_V As Short = 9
    Private Const AD_B_1_V As Short = 10
    Private Const AD_B_0_1_V As Short = 11
    Private Const AD_B_0_01_V As Short = 12
    Private Const AD_B_0_001_V As Short = 13
    Private Const AD_U_20_V As Short = 14
    Private Const AD_U_10_V As Short = 15
    Private Const AD_U_5_V As Short = 16
    Private Const AD_U_2_5_V As Short = 17
    Private Const AD_U_1_25_V As Short = 18
    Private Const AD_U_1_V As Short = 19
    Private Const AD_U_0_1_V As Short = 20
    Private Const AD_U_0_01_V As Short = 21
    Private Const AD_U_0_001_V As Short = 22
    Private Const AD_B_2_V As Short = 23
    Private Const AD_B_0_25_V As Short = 24
    Private Const AD_B_0_2_V As Short = 25
    Private Const AD_U_4_V As Short = 26
    Private Const AD_U_2_V As Short = 27
    Private Const AD_U_0_5_V As Short = 28
    Private Const AD_U_0_4_V As Short = 29

    'Constants for DAQ2000
    Private Const All_Channels As Short = -1
    Private Const BufferNotUsed As Short = -1

    Private Const DAQ2K_AI_ADCONVSRC_Int As Short = &H0S
    Private Const DAQ2K_AI_ADCONVSRC_AFI0 As Short = &H4S
    Private Const DAQ2K_AI_ADCONVSRC_SSI As Short = &H8S
    Private Const DAQ2K_AI_ADCONVSRC_AFI1 As Short = &HCS
    Private Const DAQ2K_AI_ADCONVSRC_AFI2 As Short = &H100S
    Private Const DAQ2K_AI_ADCONVSRC_AFI3 As Short = &H200S
    Private Const DAQ2K_AI_ADCONVSRC_AFI4 As Short = &H300S
    Private Const DAQ2K_AI_ADCONVSRC_AFI5 As Short = &H400S
    Private Const DAQ2K_AI_ADCONVSRC_AFI6 As Short = &H500S
    Private Const DAQ2K_AI_ADCONVSRC_AFI7 As Short = &H600S

    'Constants for AI Delay Counter SRC: only available for DAQ-250X
    Private Const DAQ2K_AI_DTSRC_Int As Short = &H0S
    Private Const DAQ2K_AI_DTSRC_AFI1 As Short = &H10S
    Private Const DAQ2K_AI_DTSRC_GPTC0 As Short = &H20S
    Private Const DAQ2K_AI_DTSRC_GPTC1 As Short = &H30S

    Private Const DAQ2K_AI_TRGSRC_SOFT As Short = &H0S
    Private Const DAQ2K_AI_TRGSRC_ANA As Short = &H1S
    Private Const DAQ2K_AI_TRGSRC_ExtD As Short = &H2S
    Private Const DAQ2K_AI_TRSRC_SSI As Short = &H3S
    Private Const DAQ2K_AI_TRGMOD_POST As Short = &H0S 'Post Trigger Mode
    Private Const DAQ2K_AI_TRGMOD_DELAY As Short = &H8S 'Delay Trigger Mode
    Private Const DAQ2K_AI_TRGMOD_PRE As Short = &H10S 'Pre-Trigger Mode
    Private Const DAQ2K_AI_TRGMOD_MIDL As Short = &H18S 'Middle Trigger Mode
    Private Const DAQ2K_AI_ReTrigEn As Short = &H80S
    Private Const DAQ2K_AI_Dly1InSamples As Short = &H100S
    Private Const DAQ2K_AI_Dly1InTimebase As Short = &H0S
    Private Const DAQ2K_AI_MCounterEn As Short = &H400S
    Private Const DAQ2K_AI_TrgPositive As Short = &H0S
    Private Const DAQ2K_AI_TrgNegative As Short = &H1000S

    Private Const DAQ2K_AI_TRGSRC_AFI0 As Integer = &H10000
    Private Const DAQ2K_AI_TRGSRC_AFI1 As Integer = &H20000
    Private Const DAQ2K_AI_TRGSRC_AFI2 As Integer = &H30000
    Private Const DAQ2K_AI_TRGSRC_AFI3 As Integer = &H40000
    Private Const DAQ2K_AI_TRGSRC_AFI4 As Integer = &H50000
    Private Const DAQ2K_AI_TRGSRC_AFI5 As Integer = &H60000
    Private Const DAQ2K_AI_TRGSRC_AFI6 As Integer = &H70000
    Private Const DAQ2K_AI_TRGSRC_AFI7 As Integer = &H80000
    Private Const DAQ2K_AI_TRGSRC_PXIStar As Integer = &HA0000
    Private Const DAQ2K_AI_TRGSRC_SMB As Integer = &HB0000

    'AI Reference Ground (input mode)
    Private Const AI_RSE As Short = &H0S
    Private Const AI_DIFF As Short = &H100S
    Private Const AI_NRSE As Short = &H200S

    Private Const DAQ2K_DA_BiPolar As Short = &H1S
    Private Const DAQ2K_DA_UniPolar As Short = &H0S
    Private Const DAQ2K_DA_Int_REF As Short = &H0S
    Private Const DAQ2K_DA_Ext_REF As Short = &H1S

    Private Const DAQ2K_DA_WRSRC_Int As Short = &H0S
    Private Const DAQ2K_DA_WRSRC_AFI0 As Short = &H1S
    Private Const DAQ2K_DA_WRSRC_AFI1 As Short = &H1S
    Private Const DAQ2K_DA_WRSRC_SSI As Short = &H2S

    'DA group
    Private Const DA_Group_A As Short = &H0S
    Private Const DA_Group_B As Short = &H4S
    Private Const DA_Group_AB As Short = &H8S
    'DA TD Counter SRC: only available for DAQ-250X
    Private Const DAQ2K_DA_TDSRC_Int As Short = &H0S
    Private Const DAQ2K_DA_TDSRC_AFI0 As Short = &H10S
    Private Const DAQ2K_DA_TDSRC_GPTC0 As Short = &H20S
    Private Const DAQ2K_DA_TDSRC_GPTC1 As Short = &H30S
    'DA BD Counter SRC: only available for DAQ-250X
    Private Const DAQ2K_DA_BDSRC_Int As Short = &H0S
    Private Const DAQ2K_DA_BDSRC_AFI0 As Short = &H40S
    Private Const DAQ2K_DA_BDSRC_GPTC0 As Short = &H80S
    Private Const DAQ2K_DA_BDSRC_GPTC1 As Short = &HC0S
    'DA trigger constant
    Private Const DAQ2K_DA_TRGSRC_SOFT As Short = &H0S 'Software Trigger Mode
    Private Const DAQ2K_DA_TRGSRC_ANA As Short = &H1S 'Post Trigger Mode
    Private Const DAQ2K_DA_TRGSRC_ExtD As Short = &H2S 'Delay Trigger Mode
    Private Const DAQ2K_DA_TRGSRC_SSI As Short = &H3S
    Private Const DAQ2K_DA_TRGMOD_POST As Short = &H0S
    Private Const DAQ2K_DA_TRGMOD_DELAY As Short = &H4S
    Private Const DAQ2K_DA_ReTrigEn As Short = &H20S
    Private Const DAQ2K_DA_Dly1InUI As Short = &H40S
    Private Const DAQ2K_DA_Dly1InTimebase As Short = &H0S
    Private Const DAQ2K_DA_Dly2InUI As Short = &H80S
    Private Const DAQ2K_DA_Dly2InTimebase As Short = &H0S
    Private Const DAQ2K_DA_DLY2En As Short = &H100S
    Private Const DAQ2K_DA_TrgPositive As Short = &H0S
    Private Const DAQ2K_DA_TrgNegative As Short = &H200S
    'DA stop mode
    Private Const DAQ2K_DA_TerminateImmediate As Short = 0
    Private Const DAQ2K_DA_TerminateUC As Short = 1
    Private Const DAQ2K_DA_TerminateFIFORC As Short = 2
    Private Const DAQ2K_DA_TerminateIC As Short = 2
    'DA stop source : only available for DAQ-250X
    Private Const DAQ2K_DA_STOPSRC_SOFT As Short = 0
    Private Const DAQ2K_DA_STOPSRC_AFI0 As Short = 1
    Private Const DAQ2K_DA_STOPSRC_ATrig As Short = 2
    Private Const DAQ2K_DA_STOPSRC_AFI1 As Short = 3

    'DIO Port Direction
    Private Const INPUT_PORT As Short = 1
    Private Const OUTPUT_PORT As Short = 2

    'Channel&Port
    Private Const Channel_P1A As Short = 0
    Private Const Channel_P1B As Short = 1
    Private Const Channel_P1C As Short = 2
    Private Const Channel_P1CL As Short = 3
    Private Const Channel_P1CH As Short = 4
    Private Const Channel_P1AE As Short = 10
    Private Const Channel_P1BE As Short = 11
    Private Const Channel_P1CE As Short = 12
    Private Const Channel_P2A As Short = 5
    Private Const Channel_P2B As Short = 6
    Private Const Channel_P2C As Short = 7
    Private Const Channel_P2CL As Short = 8
    Private Const Channel_P2CH As Short = 9
    Private Const Channel_P2AE As Short = 15
    Private Const Channel_P2BE As Short = 16
    Private Const Channel_P2CE As Short = 17
    Private Const Channel_P3A As Short = 10
    Private Const Channel_P3B As Short = 11
    Private Const Channel_P3C As Short = 12
    Private Const Channel_P3CL As Short = 13
    Private Const Channel_P3CH As Short = 14
    Private Const Channel_P4A As Short = 15
    Private Const Channel_P4B As Short = 16
    Private Const Channel_P4C As Short = 17
    Private Const Channel_P4CL As Short = 18
    Private Const Channel_P4CH As Short = 19
    Private Const Channel_P5A As Short = 20
    Private Const Channel_P5B As Short = 21
    Private Const Channel_P5C As Short = 22
    Private Const Channel_P5CL As Short = 23
    Private Const Channel_P5CH As Short = 24
    Private Const Channel_P6A As Short = 25
    Private Const Channel_P6B As Short = 26
    Private Const Channel_P6C As Short = 27
    Private Const Channel_P6CL As Short = 28
    Private Const Channel_P6CH As Short = 29
    Private Const Channel_P1 As Short = 30
    Private Const Channel_P2 As Short = 31
    Private Const Channel_P3 As Short = 32
    Private Const Channel_P4 As Short = 33
    Private Const Channel_P1E As Short = 34
    Private Const Channel_P2E As Short = 35
    Private Const Channel_P3E As Short = 36
    Private Const Channel_P4E As Short = 37

    '--------- Constants for Timer/Counter --------------
    'Counter Mode (8254)
    Private Const TOGGLE_OUTPUT As Short = 0 'Toggle output from low to high on terminal count
    Private Const PROG_ONE_SHOT As Short = 1 'Programmable one-shot
    Private Const RATE_GENERATOR As Short = 2 'Rate generator
    Private Const SQ_WAVE_RATE_GENERATOR As Short = 3 'Square wave rate generator
    Private Const SOFT_TRIG As Short = 4 'Software-triggered strobe
    Private Const HARD_TRIG As Short = 5 'Hardware-triggered strobe

    '---------- Constants for Analog trigger ------------
    'define analog trigger condition constants
    Private Const Below_Low_level As Short = &H0S
    Private Const Above_High_Level As Short = &H100S
    Private Const Inside_Region As Short = &H200S
    Private Const High_Hysteresis As Short = &H300S
    Private Const Low_Hysteresis As Short = &H400S
    'define analog trigger Dedicated Channel
    Private Const CH0ATRIG As Short = &H0S
    Private Const CH1ATRIG As Short = &H2S
    Private Const CH2ATRIG As Short = &H4S
    Private Const CH3ATRIG As Short = &H6S
    Private Const EXTATRIG As Short = &H1S
    Private Const ADCATRIG As Short = &H0S
    '----------- Time Base -------------------
    Private Const DAQ2K_IntTimeBase As Short = &H0S
    Private Const DAQ2K_ExtTimeBase As Short = &H1S
    Private Const DAQ2K_SSITimeBase As Short = &H2S
    Private Const DAQ2K_ExtTimeBase_AFI0 As Short = &H3S
    Private Const DAQ2K_ExtTimeBase_AFI1 As Short = &H4S
    Private Const DAQ2K_ExtTimeBase_AFI2 As Short = &H5S
    Private Const DAQ2K_ExtTimeBase_AFI3 As Short = &H6S
    Private Const DAQ2K_ExtTimeBase_AFI4 As Short = &H7S
    Private Const DAQ2K_ExtTimeBase_AFI5 As Short = &H8S
    Private Const DAQ2K_ExtTimeBase_AFI6 As Short = &H9S
    Private Const DAQ2K_ExtTimeBase_AFI7 As Short = &HAS
    Private Const DAQ2K_PXI_CLK As Short = &HCS
    Private Const DAQ2K_StarTimeBase As Short = &HDS
    Private Const DAQ2K_SMBTimeBase As Short = &HES

    '------- General Purpose Timer/Counter -----------------
    'Counter Mode
    Private Const SimpleGatedEventCNT As Short = 1
    Private Const SinglePeriodMSR As Short = 2
    Private Const SinglePulseWidthMSR As Short = 3
    Private Const SingleGatedPulseGen As Short = 4
    Private Const SingleTrigPulseGen As Short = 5
    Private Const RetrigSinglePulseGen As Short = 6
    Private Const SingleTrigContPulseGen As Short = 7
    Private Const ContGatedPulseGen As Short = 8
    'GPTC clock source
    Private Const GPTC_GATESRC_EXT As Short = &H4S
    Private Const GPTC_GATESRC_INT As Short = &H0S
    Private Const GPTC_CLKSRC_EXT As Short = &H8S
    Private Const GPTC_CLKSRC_INT As Short = &H0S
    Private Const GPTC_UPDOWN_SEL_EXT As Short = &H10S
    Private Const GPTC_UPDOWN_SEL_INT As Short = &H0S
    'GPTC clock polarity
    Private Const GPTC_CLKEN_LACTIVE As Short = &H1S
    Private Const GPTC_CLKEN_HACTIVE As Short = &H0S
    Private Const GPTC_GATE_LACTIVE As Short = &H2S
    Private Const GPTC_GATE_HACTIVE As Short = &H0S
    Private Const GPTC_UPDOWN_LACTIVE As Short = &H4S
    Private Const GPTC_UPDOWN_HACTIVE As Short = &H0S
    Private Const GPTC_OUTPUT_LACTIVE As Short = &H8S
    Private Const GPTC_OUTPUT_HACTIVE As Short = &H0S
    Private Const GPTC_INT_LACTIVE As Short = &H10S
    Private Const GPTC_INT_HACTIVE As Short = &H0S
    'GPTC paramID
    Private Const GPTC_IntGATE As Short = &H0S
    Private Const GPTC_IntUpDnCTR As Short = &H1S
    Private Const GPTC_IntENABLE As Short = &H2S

    'SSI signal code
    Private Const SSI_TIME As Short = 1
    Private Const SSI_CONV As Short = 2
    Private Const SSI_WR As Short = 4
    Private Const SSI_ADTRIG As Short = &H20S
    Private Const SSI_DATRIG As Short = &H40S

    'signal code for GPTC
    Private Const GPTC_CLK_0 As Short = &H100S
    Private Const GPTC_GATE_0 As Short = &H200S
    Private Const GPTC_OUT_0 As Short = &H300S
    Private Const GPTC_CLK_1 As Short = &H400S
    Private Const GPTC_GATE_1 As Short = &H500S
    Private Const GPTC_OUT_1 As Short = &H600S
    'signal code for clockoutToSMB source
    Private Const PXI_CLK_10_M As Short = &H1000S
    Private Const CLK_20_M As Short = &H2000S
    Private Const SMB_CLK_IN As Short = &H3000S

    'signal route lines
    Private Const PXI_TRIG_0 = 0
    Private Const PXI_TRIG_1 = 1
    Private Const PXI_TRIG_2 = 2
    Private Const PXI_TRIG_3 = 3
    Private Const PXI_TRIG_4 = 4
    Private Const PXI_TRIG_5 = 5
    Private Const PXI_TRIG_6 = 6
    Private Const PXI_TRIG_7 = 7
    Private Const PXI_STAR_TRIG = 8
    Private Const TRG_IO = 9
    Private Const SMB_CLK_OUT = 10
    Private Const AFI0 = &H10
    Private Const AFI1 = &H11
    Private Const AFI2 = &H12
    Private Const AFI3 = &H13
    Private Const AFI4 = &H14
    Private Const AFI5 = &H15
    Private Const AFI6 = &H16
    Private Const AFI7 = &H17
    Private Const PXI_CLK = &H18

    'export signal plarity
    Private Const Signal_ActiveHigh = &H0
    Private Const Signal_ActiveLow = &H1

    'DAQ Event type for the event message  
    Private Const DAQEnd As Short = 0
    Private Const DBEvent As Short = 1
    Private Const DAQEnd_A As Short = 0
    Private Const DAQEnd_B As Short = 2
    Private Const DAQEnd_AB As Short = 3

    '16-bit binary or 4-decade BCD counter
    Private Const BIN As Short = 0
    Private Const BCD As Short = 1

    Private Declare Function WaitForSingleObject Lib "kernel32" (ByVal hHandle As Integer, ByVal dwMilliseconds As Integer) As Integer
    Private Delegate Sub CallbackDelegate()

    '-------------------------------------------------------------------
    '  D2K-DASK Function prototype
    '-----------------------------------------------------------------*/
    Private Declare Function D2K_Register_Card Lib "D2K-Dask.dll" (ByVal CardType As Short, ByVal card_num As Short) As Short
    Private Declare Function D2K_Register_Card_By_PXISlot_GA Lib "D2K-Dask.dll" (ByVal CardType As Short, ByVal geo_addr As Short) As Short
    Private Declare Function D2K_Release_Card Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_AIO_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal TimerBase As Short, ByVal AnaTrigCtrl As Short, ByVal H_TrgLevel As Short, ByVal L_TrgLevel As Short) As Short
    Private Declare Function D2K_GetPXISlotGeographAddr Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef geo_addr As Byte) As Short
    Private Declare Function D2K_SoftTrigGen Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef op As Byte) As Short
    'AI Functions
    Private Declare Function D2K_AI_CH_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal AdRange_RefGnd As Short) As Short
    Private Declare Function D2K_AI_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Integer, ByVal MidOrDlyScans As Integer, ByVal MCnt As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Integer, ByVal MidOrDlyScans As Integer, ByVal MCnt As Integer, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_PostTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_PostTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_DelayTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal DlyScans As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_DelayTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal DlyScans As Integer, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_PreTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MCtrEn As Short, ByVal MCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_PreTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MCtrEn As Short, ByVal MCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_MiddleTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MiddleScans As Integer, ByVal MCtrEn As Short, ByVal MCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_MiddleTrig_ConfigEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Integer, ByVal MiddleScans As Integer, ByVal MCtrEn As Short, ByVal MCnt As Integer, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AI_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef AccessCnt As Integer) As Short
    Private Declare Function D2K_AI_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef startPos As Integer, ByRef AccessCnt As Integer) As Short
    Private Declare Function D2K_AI_AsyncClearEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef startPos As Integer, ByRef AccessCnt As Integer, ByVal NoWait As Integer) As Short
    Private Declare Function D2K_AI_AsyncDblBufferHalfReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte, ByRef StopFlag As Byte) As Short
    Private Declare Function D2K_AI_AsyncDblBufferMode Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal enable As Byte) As Short
    Private Declare Function D2K_AI_AsyncDblBufferToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_AI_ContReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContScanChannels Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short

    Private Declare Function D2K_AI_ContReadChannelToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContScanChannelsToFile Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal wChannel As Short, ByVal BufId As Short, ByVal FileName As String, ByVal dwReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContReadMultiChannelsToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContReadMultiChannelsToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short

    Private Declare Function D2K_AI_ContStatus Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef status As Short) As Short
    Private Declare Function D2K_AI_InitialMemoryAllocated Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Private Declare Function D2K_AI_ReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByRef Value As Short) As Short
    Private Declare Function D2K_AI_VReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByRef Voltage As Double) As Short
    Private Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef Buffer As Short) As Short
    Private Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal Buffer As IntPtr) As Short
    Private Declare Function D2K_AI_SimuReadChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal Buffer As IntPtr) As Short

    Private Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByRef Buffer As Short) As Short
    Private Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal Buffer As IntPtr) As Short
    Private Declare Function D2K_AI_ScanReadChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal Buffer As IntPtr) As Short

    Private Declare Function D2K_AI_VoltScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal reading As UShort, ByRef Voltage As Double) As Short
    Private Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByRef readingArray As UShort, ByRef voltageArray As Double, ByVal count As Integer) As Short
    Private Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal readingArray As IntPtr, ByRef voltageArray As Double, ByVal count As Integer) As Short
    Private Declare Function D2K_AI_ContVScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal AdRange As Short, ByVal readingArray As IntPtr, ByVal voltageArray As IntPtr, ByVal count As Integer) As Short

    Private Declare Function D2K_AI_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As UShort, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short
    Private Declare Function D2K_AI_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr, ByVal ReadCount As Integer, ByRef BufferId As Short) As Short

    Private Declare Function D2K_AI_ContBufferReset Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_AI_MuxScanSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wNumChans As Short, ByRef chans As Short, ByRef AdRange_RefGnds As Short) As Short
    Private Declare Function D2K_AI_MuxScanSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wNumChans As Short, ByVal chans As IntPtr, ByVal AdRange_RefGnds As IntPtr) As Short

    Private Declare Function D2K_AI_ReadMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short) As Short
    Private Declare Function D2K_AI_ReadMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr) As Short

    Private Declare Function D2K_AI_ContMuxScan Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal BufId As Short, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_ContMuxScanToFile Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal BufId As Short, ByVal FileName As String, ByVal ReadScans As Integer, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AI_EventCallBack Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As CallbackDelegate) As Short
    Private Declare Function D2K_AI_SetTimeout Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal msec As Integer) As Integer
    Private Declare Function D2K_AI_CounterInterval Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ScanIntrv As Integer, ByVal SampIntrv As Integer) As Short
    Private Declare Function D2K_AI_AsyncDblBufferHandled Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_AI_AsyncDblBufferOverrun Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal op As Short, ByRef overrunFlag As Short) As Short
    Private Declare Function D2K_AI_AsyncReTrigNextReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef trgReady As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Short) As Short
    Private Declare Function D2K_AI_AsyncReTrigNextReadyEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef trgReady As Byte, ByRef StopFlag As Byte, ByRef RdyTrigCnt As Integer) As Short
    'AO Function
    Private Declare Function D2K_AO_CH_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal OutputPolarity As Short, ByVal wIntOrExtRef As Short, ByVal refVoltage As Double) As Short
    Private Declare Function D2K_AO_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ConfigCtrl As Short, ByVal TrigCtrl As Short, ByVal ReTrgCnt As Short, ByVal DLY1Cnt As Short, ByVal DLY2Cnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AO_PostTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Short, ByVal DLY2Ctrl As Short, ByVal DLY2Cnt As Short, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AO_DelayTrig_Config Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal ClkSrc As Short, ByVal TrigSrcCtrl As Short, ByVal DLY1Cnt As Short, ByVal DLY2Ctrl As Short, ByVal DLY2Cnt As Short, ByVal ReTrgEn As Short, ByVal ReTrgCnt As Short, ByVal AutoResetBuf As Byte) As Short
    Private Declare Function D2K_AO_InitialMemoryAllocated Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef MemSize As Integer) As Short
    Private Declare Function D2K_AO_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Stopped As Byte, ByRef WriteCnt As Integer) As Short
    Private Declare Function D2K_AO_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short) As Short
    Private Declare Function D2K_AO_AsyncClearEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short, ByVal NoWait As Integer) As Short
    Private Declare Function D2K_AO_AsyncDblBufferHalfReady Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef HalfReady As Byte) As Short
    Private Declare Function D2K_AO_AsyncDblBufferMode Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal enable As Byte) As Short
    Private Declare Function D2K_AO_ContWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AO_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef chans As Short, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short
    Private Declare Function D2K_AO_ContReadMultiChannels Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal chans As IntPtr, ByVal BufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short, ByVal SyncMode As Short) As Short

    Private Declare Function D2K_AO_SimuWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByRef Buffer As Short) As Short
    Private Declare Function D2K_AO_SimuWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal NumChans As Short, ByVal Buffer As IntPtr) As Short

    Private Declare Function D2K_AO_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByRef Buffer As Short, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short
    Private Declare Function D2K_AO_ContBufferSetup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Buffer As IntPtr, ByVal WriteCount As Integer, ByRef BufferId As Short) As Short

    Private Declare Function D2K_AO_ContBufferReset Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_AO_WriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Value As Short) As Short
    Private Declare Function D2K_AO_VWriteChannel Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Voltage As Double) As Short
    Private Declare Function D2K_AO_VoltScale Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal channel As Short, ByVal Voltage As Double, ByRef binValue As Short) As Short
    Private Declare Function D2K_AO_ContBufferComposeAll Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal UpdateCount As Integer, ByRef ConBuffer As Short, ByRef Buffer As Short, ByVal fifoload As Byte) As Short
    Private Declare Function D2K_AO_ContBufferComposeAll Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal UpdateCount As Integer, ByVal ConBuffer As IntPtr, ByVal Buffer As IntPtr, ByVal fifoload As Byte) As Short

    Private Declare Function D2K_AO_ContBufferCompose Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal channel As Short, ByVal UpdateCount As Integer, ByRef ConBuffer As Short, ByRef Buffer As Short, ByVal fifoload As Byte) As Short
    Private Declare Function D2K_AO_ContBufferCompose Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal channel As Short, ByVal UpdateCount As Integer, ByVal ConBuffer As IntPtr, ByVal Buffer As IntPtr, ByVal fifoload As Byte) As Short


    Private Declare Function D2K_AO_EventCallBack Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Mode As Short, ByVal EventType As Short, ByVal callbackAddr As Integer) As Short
    Private Declare Function D2K_AO_SetTimeout Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal msec As Integer) As Integer
    Private Declare Function D2K_A0_CounterInterval Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal CHUI As Integer) As Short
    'AO Group Functions
    Private Declare Function D2K_AO_Group_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wNumChans As Short, ByRef wChans As Short) As Short
    Private Declare Function D2K_AO_Group_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wNumChans As Short, ByVal wChans As IntPtr) As Short

    Private Declare Function D2K_AO_Group_Update Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef wBuffer As Short) As Short
    Private Declare Function D2K_AO_Group_Update Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal wBuffer As IntPtr) As Short

    Private Declare Function D2K_AO_Group_VUpdate Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef Voltage As Double) As Short
    Private Declare Function D2K_AO_Group_VUpdate Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal Voltage As IntPtr) As Short

    Private Declare Function D2K_AO_Group_FIFOLoad Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal BufId As Short, ByVal dwWriteCount As Integer) As Short
    Private Declare Function D2K_AO_Group_WFM_StopConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal stopSrc As Short, ByVal stopMode As Short) As Short
    Private Declare Function D2K_AO_Group_WFM_Start Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByVal fstBufIdOrNotUsed As Short, ByVal sndBufId As Short, ByVal UpdateCount As Integer, ByVal Iterations As Integer, ByVal CHUI As Integer, ByVal definite As Short) As Short
    Private Declare Function D2K_AO_Group_WFM_AsyncCheck Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef Stopped As Byte, ByRef WriteCnt As Integer) As Short
    Private Declare Function D2K_AO_Group_WFM_AsyncClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal group As Short, ByRef WriteCnt As Integer, ByVal stop_mode As Short) As Short
    'DI Functions
    Private Declare Function D2K_DI_ReadPort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short
    Private Declare Function D2K_DI_ReadLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short

    'DO Functions
    Private Declare Function D2K_DO_WritePort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Value As Integer) As Short
    Private Declare Function D2K_DO_WriteLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByVal Value As Short) As Short
    Private Declare Function D2K_DO_ReadLine Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Line As Short, ByRef Value As Short) As Short
    Private Declare Function D2K_DO_ReadPort Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByRef Value As Integer) As Short

    'DIO Functions
    Private Declare Function D2K_DIO_PortConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal Direction As Short) As Short
    Private Declare Function D2K_DIO_LineConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal wLine As Integer, ByVal Direction As Short) As Short
    Private Declare Function D2K_DIO_LinesConfig Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal Port As Short, ByVal wLinesdirmap As Integer) As Short

    'Counter Functions
    Private Declare Function D2K_GCTR_Setup Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal wMode As Short, ByVal SrcCtrl As Byte, ByVal PolCtrl As Byte, ByVal LReg1_Val As Short, ByVal LReg2_Val As Short) As Short
    Private Declare Function D2K_GCTR_SetupEx Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal wMode As Short, ByVal SrcCtrl As Byte, ByVal PolCtrl As Byte, ByVal LReg1_Val As Integer, ByVal LReg2_Val As Integer) As Short
    Private Declare Function D2K_GCTR_Control Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByVal ParamID As Short, ByVal Value As Short) As Short
    Private Declare Function D2K_GCTR_Reset Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short) As Short
    Private Declare Function D2K_GCTR_Read Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByRef pValue As Integer) As Short
    Private Declare Function D2K_GCTR_Status Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal wGCtr As Short, ByRef pValue As Short) As Short

    'SSI Functions
    Private Declare Function D2K_SSI_SourceConn Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
    Private Declare Function D2K_SSI_SourceDisConn Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal sigCode As Short) As Short
    Private Declare Function D2K_SSI_SourceClear Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
    Private Declare Function D2K_Route_Signal Lib "WD-Dask.dll" (ByVal CardNumber As Short, ByVal signal As Short, ByVal polarity As Short, ByVal Line As Short, ByVal direct As Short) As Short
    Private Declare Function D2K_Signal_DisConn Lib "WD-Dask.dll" (ByVal CardNumber As Short, ByVal signal As Short, ByVal polarity As Short, ByVal Line As Short) As Short

    'Calibration Functions
    Private Declare Function DAQ2204_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
    Private Declare Function DAQ2204_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
    Private Declare Function DAQ2205_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
    Private Declare Function DAQ2205_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
    Private Declare Function DAQ2206_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
    Private Declare Function DAQ2206_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef da0v_err As Single, ByRef da5v_err As Single) As Short
    Private Declare Function DAQ2010_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2010_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2005_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2005_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2006_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2006_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ2208_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByRef gain_err As Single, ByRef bioffset_err As Single, ByRef unioffset_err As Single, ByRef hg_bios_err As Single) As Short
    Private Declare Function DAQ250X_Acquire_AD_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function DAQ250X_Acquire_DA_Error Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal channel As Short, ByVal polarity As Short, ByRef gain_err As Single, ByRef offset_err As Single) As Short
    Private Declare Function D2K_DB_Auto_Calibration_ALL Lib "D2K-Dask.dll" (ByVal wCardNumber As Short) As Short
    Private Declare Function D2K_EEPROM_CAL_Constant_Update Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal bank As Short) As Short
    Private Declare Function D2K_Load_CAL_Data Lib "D2K-Dask.dll" (ByVal wCardNumber As Short, ByVal bank As Short) As Short
    Private Declare Function D2K_Set_Default_Load_Area Lib "D2K-Dask.dll" (ByVal CardNumber As Short, ByVal bank As Short) As Short
    Private Declare Function D2K_Get_Default_Load_Area Lib "D2K-Dask.dll" (ByVal CardNumber As Short) As Short
#End Region
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫
    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
            Dim errCode As Short
            Try
                'errCode = D2K_Release_Card(m_AO(0).CardID)
                'errCode = D2K_AO_Group_WFM_AsyncClear(m_AO(0).CardID, DA_Group_A, 0, 0)
                'errCode = D2K_AO_ContBufferReset(m_AO(0).CardID)
            Catch ex As Exception
            End Try
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    'Private Const ONE_CH_SIZE As Integer = 40
    'Private m_AO() As CAnalogOutBased
    'Private m_Timer As CHighResolutionTimer
    'Friend Sub New()
    'm_AO = pAO
    'm_Timer = New CHighResolutionTimer
    'Dim devNum As Short
    'devNum = D2K_Register_Card(DAQ_2501, 0)
    'If Not (m_AO(0).CardID = devNum) Then
    '    Call MsgBox("D2K_Register_Card error!", MsgBoxStyle.Information, "CD2kDaskAO?New")
    'End If

    'Dim errCode As Short
    'Dim UsedChannelCnt As Short
    'Dim da_ch(0 To 3) As Short
    ''Dim ao_buffer1(0 To 999) As Short
    ''Dim ao_buffer2(0 To 999) As Short
    'UsedChannelCnt = 2

    'If (errCode < 0) Then
    '    Call MsgBox("D2K_AO_CH_Config error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '    Exit Sub
    'End If
    'errCode = D2K_AO_CH_Config(CShort(m_AO(0).CardID), 1, DAQ2K_DA_UniPolar, DAQ2K_DA_Int_REF, 10.0)
    'If (errCode < 0) Then
    '    Call MsgBox("D2K_AO_CH_Config error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '    Exit Sub
    'End If
    'da_ch(0) = 0
    'da_ch(1) = 1
    'errCode = D2K_AO_Group_Setup(CShort(m_AO(0).CardID), DA_Group_A, UsedChannelCnt, da_ch(0))
    'If (errCode < 0) Then
    '    Call MsgBox("D2K_AO_Group_Setup error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '    Exit Sub
    'End If
    'errCode = D2K_AO_Config(CShort(m_AO(0).CardID), DA_Group_A, DAQ2K_DA_TRGMOD_POST, 0, 0, 0, 0)
    'If (errCode < 0) Then
    '    Call MsgBox("D2K_AO_Config error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '    Exit Sub
    'End If



    'errCode = D2K_AO_AsyncDblBufferMode(CShort(m_AO(0).CardID), 1)
    'If (errCode < 0) Then
    '    Call MsgBox("D2K_AO_AsyncDblBufferMode error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '    Exit Sub
    'End If
    'End Sub

    'Friend Sub StartWaveform(ByVal AryIdx As Integer, ByVal Power As Double, ByVal freqHz As Double, ByVal PulseWidthMicroSec As Double)
    '    Dim errCode As Short
    '    Dim UsedChannelCnt As Short 'AO組數
    '    Dim SamplePerCycle As Integer '一個週期幾個點 單位us
    '    Dim samp_intrv As Integer '周期 單位us
    '    Dim buf_id As Short

    '    Dim da_ch(0 To 3) As Short
    '    Dim ao_buffer1() As Short
    '    Dim ao_buffer2() As Short
    '    Dim ao_buf() As Short
    '    Try
    '        errCode = 0
    '        UsedChannelCnt = 2
    '        samp_intrv = CInt(CDbl(1 / freqHz) * 1000 * 1000)
    '        SamplePerCycle = CInt(CDbl(1 / freqHz) * 1000 * 1000)
    '        ReDim ao_buffer1(0 To (SamplePerCycle - 1))
    '        ReDim ao_buffer2(0 To (SamplePerCycle - 1))
    '        ReDim ao_buf(0 To (SamplePerCycle * 2 - 1))
    '        For adcIdx As Integer = 0 To ((SamplePerCycle - 1))
    '            If adcIdx < (SamplePerCycle * 19 / 20) Then
    '                ao_buffer1(adcIdx) = (100 / 100) * 2047
    '            End If
    '            If adcIdx < 200 Then
    '                ao_buffer2(adcIdx) = (Power * m_AO(0).WavePattern(AryIdx, adcIdx) / 100 * 2) * 2047
    '            End If
    '        Next
    '        errCode = D2K_AO_ContBufferCompose(CShort(m_AO(0).CardID), DA_Group_A, 0, SamplePerCycle, ao_buf(0), ao_buffer1(0), 0)
    '        If (errCode < 0) Then
    '            Call MsgBox("D2K_AO_ContBufferCompose error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '            Exit Sub
    '        End If
    '        errCode = D2K_AO_ContBufferCompose(CShort(m_AO(0).CardID), DA_Group_A, 1, SamplePerCycle, ao_buf(0), ao_buffer2(0), 0)
    '        If (errCode < 0) Then
    '            Call MsgBox("D2K_AO_ContBufferCompose error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '            Exit Sub
    '        End If

    '        errCode = D2K_AO_ContBufferSetup(CShort(m_AO(0).CardID), ao_buf(0), SamplePerCycle * UsedChannelCnt, buf_id)
    '        If (errCode < 0) Then
    '            Call MsgBox("D2K_AO_ContBufferSetup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '            Exit Sub
    '        End If
    '        errCode = D2K_AO_Group_WFM_Start(CShort(m_AO(0).CardID), DA_Group_A, buf_id, 0, SamplePerCycle, 1, 40, 0)
    '        If (errCode < 0) Then
    '            Call MsgBox("D2K_AO_Group_WFM_Start!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '            Exit Sub
    '        End If
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub

    'Friend Sub StopWaveform(ByVal WaveformIdx As Integer)
    '    Dim errCode As Short
    '    Try
    '        'errCode = D2K_Release_Card(m_AO(0).CardID)
    '        'errCode = D2K_AO_Group_WFM_AsyncClear(m_AO(0).CardID, DA_Group_A, 0, 0)
    '        'errCode = D2K_AO_ContBufferReset(m_AO(0).CardID)

    '        errCode = D2K_AO_Group_WFM_AsyncClear(m_AO(0).CardID, DA_Group_A, 0, DAQ2K_DA_TerminateImmediate)
    '        errCode = D2K_AO_ContBufferReset(m_AO(0).CardID)



    '        Dim UsedChannelCnt As Short
    '        Dim SamplePerCycle As Integer
    '        Dim samp_intrv As Integer
    '        Dim buf_id As Short

    '        Dim da_ch(0 To 3) As Short
    '        Dim ao_buffer1(0 To 39) As Short
    '        Dim ao_buffer2(0 To 39) As Short
    '        Dim AO_buf(0 To 79) As Short
    '        Dim period As Double
    '        Try
    '            UsedChannelCnt = 2
    '            samp_intrv = 40 * 1
    '            SamplePerCycle = 40

    '            period = ((1 / 30000) * 1000 * 1000) / SamplePerCycle
    '            samp_intrv = 40 * period
    '            For i = 0 To CInt(SamplePerCycle - 1)
    '                If i < SamplePerCycle / 2 Then
    '                    ao_buffer1(i) = (0 / 100) * 2047
    '                End If
    '                ao_buffer2(i) = (0 / 100 * 2) * 2047
    '            Next
    '            errCode = D2K_AO_ContBufferCompose(CShort(m_AO(0).CardID), DA_Group_A, 0, SamplePerCycle, AO_buf(0), ao_buffer1(0), 0)
    '            If (errCode < 0) Then
    '                Call MsgBox("D2K_AO_ContBufferCompose error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '                Exit Sub
    '            End If
    '            errCode = D2K_AO_ContBufferCompose(CShort(m_AO(0).CardID), DA_Group_A, 1, SamplePerCycle, AO_buf(0), ao_buffer2(0), 0)
    '            If (errCode < 0) Then
    '                Call MsgBox("D2K_AO_ContBufferCompose error!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '                Exit Sub
    '            End If

    '            errCode = D2K_AO_ContBufferSetup(CShort(m_AO(0).CardID), AO_buf(0), SamplePerCycle * UsedChannelCnt, buf_id)
    '            If (errCode < 0) Then
    '                Call MsgBox("D2K_AO_ContBufferSetup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '                Exit Sub
    '            End If
    '            errCode = D2K_AO_Group_WFM_Start(CShort(m_AO(0).CardID), DA_Group_A, buf_id, 0, SamplePerCycle, 1, samp_intrv, 0)
    '            If (errCode < 0) Then
    '                Call MsgBox("D2K_AO_Group_WFM_Start!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
    '                Exit Sub
    '            End If

    '            errCode = D2K_AO_Group_WFM_AsyncClear(m_AO(0).CardID, DA_Group_A, 0, DAQ2K_DA_TerminateImmediate)
    '            errCode = D2K_AO_ContBufferReset(m_AO(0).CardID)

    '        Catch ex As Exception
    '        Finally
    '        End Try
    '    Catch ex As Exception
    '    Finally
    '    End Try
    'End Sub



    Private m_CardID, m_ErrCode, m_Id As Short
    Private m_AO_Buff() As Short

    Public Sub StartWaveform()
        m_ErrCode = D2K_DO_WritePort(m_CardID, Channel_P1A, 1) 'Pin 68 HIGH
        'Threading.Thread.Sleep(10)
        'm_ErrCode = D2K_DO_WritePort(m_CardID, Channel_P1A, 0)
    End Sub
   
    Public Sub StopWaveform()
        Dim count As Short = 0
        Dim m_ErrCode As Integer
        Dim bStopped As Byte

        m_ErrCode = D2K_DO_WritePort(m_CardID, Channel_P1A, 0)

        'Do
        '    D2K_AO_Group_WFM_AsyncCheck(m_CardID, DA_Group_A, bStopped, count)
        'Loop Until (bStopped <> 0)

        'm_ErrCode = D2K_AO_Group_WFM_AsyncClear(m_CardID, DA_Group_A, count, DAQ2K_DA_TerminateImmediate)
        'm_ErrCode = D2K_AO_ContBufferReset(m_CardID)
        m_ErrCode = D2K_Release_Card(m_CardID)

    End Sub

    Private m_Polar As Short = DAQ2K_DA_BiPolar

    Private Function TranslateAOBuff(ByVal pAO_Buff0_Old() As Short) As Short()
        Dim pAO_Buff0_New() As Short
        Try
            ReDim pAO_Buff0_New(pAO_Buff0_Old.Length - 1)
            If m_Polar = DAQ2K_DA_UniPolar Then
                For i = 0 To pAO_Buff0_New.Length - 1
                    pAO_Buff0_New(i) = CType(((pAO_Buff0_Old(i)) / 100 * 2 * 2047), Short)
                Next
            ElseIf m_Polar = DAQ2K_DA_BiPolar Then
                For i = 0 To pAO_Buff0_New.Length - 1
                    pAO_Buff0_New(i) = CType(((pAO_Buff0_Old(i)) / 100 * 2045 + 2048), Short)
                Next
            End If
            Return pAO_Buff0_New
        Catch ex As Exception
            ReDim pAO_Buff0_New(pAO_Buff0_Old.Length - 1)
            If m_Polar = DAQ2K_DA_BiPolar Then
                Try
                    For i As Integer = 0 To pAO_Buff0_New.Length - 1 Step 1
                        pAO_Buff0_New(i) = 2048
                    Next
                Catch ex2 As Exception

                End Try
            End If
            Return pAO_Buff0_New
        End Try
    End Function

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pDistance">Distance between 2 points</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff">Array AO buffer for channel 0</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pDistance As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff() As Short)
        Dim SampleCount As Integer = pAO_Buff.Length
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0
        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If

        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        m_AO_Buff = pAO_Buff
        Dim da_ch() As Short = {0}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 1, da_ch(0))

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)
        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount, m_Id)

        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Exit Sub
        End If

        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_StopConfig", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Exit Sub
        End If
        Dim TimeCompleteDistance As Double = (pDistance / pSpeed) * 1000 * 1000
        Dim NumPoint As Integer = CInt(TimeCompleteDistance / (OneSampleUpdate * SampleCount))
        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, NumPoint, UI_Counter, 1)

        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Exit Sub
        End If
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pDistance">Distance between 2 points</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pDistance As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short)
        If (pAO_Buff0.Length <> pAO_Buff1.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 2 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0

        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If

        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        Dim da_ch() As Short = {0, 1}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 2, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If



        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferSetup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_WFM_Start!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If



        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 2, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If


        Dim TimeCompleteDistance As Double = (pDistance / pSpeed) * 1000 * 1000
        Dim NumPoint As Integer = CInt(TimeCompleteDistance / (OneSampleUpdate * SampleCount))

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, NumPoint, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pDistance">Distance between 2 points</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pDistance As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short, ByVal pAO_Buff2() As Short)
        If (pAO_Buff0.Length <> pAO_Buff1.Length OrElse pAO_Buff0.Length <> pAO_Buff2.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length <> pAO_Buff2.Length")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 3 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0
        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If

        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        Dim da_ch() As Short = {0, 1, 2}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 3, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 2, SampleCount, m_AO_Buff(0), pAO_Buff2(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 3, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If
        Dim TimeCompleteDistance As Double = (pDistance / pSpeed) * 1000 * 1000
        Dim NumPoint As Integer = CInt(TimeCompleteDistance / (OneSampleUpdate * SampleCount))

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, NumPoint, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pDistance">Distance between 2 points</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <param name="pAO_Buff3">Array AO buffer for channel 3</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pDistance As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short, ByVal pAO_Buff2() As Short, ByVal pAO_Buff3() As Short)
        If (pAO_Buff0.Length <> pAO_Buff1.Length OrElse pAO_Buff0.Length <> pAO_Buff2.Length OrElse pAO_Buff0.Length <> pAO_Buff3.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length <> pAO_Buff2.Length <> pAO_Buff3.Length")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 3 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0

        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If

        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        Dim da_ch() As Short = {0, 1, 2, 3}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 4, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 2, SampleCount, m_AO_Buff(0), pAO_Buff2(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 3, SampleCount, m_AO_Buff(0), pAO_Buff3(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 4, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If

        Dim TimeCompleteDistance As Double = (pDistance / pSpeed) * 1000 * 1000
        Dim NumPoint As Integer = CInt(TimeCompleteDistance / (OneSampleUpdate * SampleCount))

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, NumPoint, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pStartX">X position of the start point</param>
    ''' <param name="pStartY">Y position of the start point</param>
    ''' <param name="pEndX">X position of the end point</param>
    ''' <param name="pEndY">Y position of the end point</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff">Array AO buffer for channel 0</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pStartX As Integer, ByVal pStartY As Integer, ByVal pEndX As Integer, ByVal pEndY As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff() As Short)
        Dim Distance As Integer = CInt(Math.Sqrt(Math.Pow(pEndX - pStartX, 2) + Math.Pow(pEndY - pStartY, 2)))
        PrepareWaveform(Distance, pSpeed, pWaveformParam, pWaveformParamType, pAO_Buff)
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pStartX">X position of the start point</param>
    ''' <param name="pStartY">Y position of the start point</param>
    ''' <param name="pEndX">X position of the end point</param>
    ''' <param name="pEndY">Y position of the end point</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pStartX As Integer, ByVal pStartY As Integer, ByVal pEndX As Integer, ByVal pEndY As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short)
        Dim Distance As Integer = CInt(Math.Sqrt(Math.Pow(pEndX - pStartX, 2) + Math.Pow(pEndY - pStartY, 2)))
        PrepareWaveform(Distance, pSpeed, pWaveformParam, pWaveformParamType, pAO_Buff0, pAO_Buff1)
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pStartX">X position of the start point</param>
    ''' <param name="pStartY">Y position of the start point</param>
    ''' <param name="pEndX">X position of the end point</param>
    ''' <param name="pEndY">Y position of the end point</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pStartX As Integer, ByVal pStartY As Integer, ByVal pEndX As Integer, ByVal pEndY As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short, ByVal pAO_Buff2() As Short)
        Dim Distance As Integer = CInt(Math.Sqrt(Math.Pow(pEndX - pStartX, 2) + Math.Pow(pEndY - pStartY, 2)))
        PrepareWaveform(Distance, pSpeed, pWaveformParam, pWaveformParamType, pAO_Buff0, pAO_Buff1, pAO_Buff2)
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pStartX">X position of the start point</param>
    ''' <param name="pStartY">Y position of the start point</param>
    ''' <param name="pEndX">X position of the end point</param>
    ''' <param name="pEndY">Y position of the end point</param>
    ''' <param name="pSpeed">Speed</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <param name="pAO_Buff3">Array AO buffer for channel 3</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pStartX As Integer, ByVal pStartY As Integer, ByVal pEndX As Integer, ByVal pEndY As Integer, ByVal pSpeed As Integer, ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType, ByVal pAO_Buff0() As Short, ByVal pAO_Buff1() As Short, ByVal pAO_Buff2() As Short, ByVal pAO_Buff3() As Short)
        Dim Distance As Integer = CInt(Math.Sqrt(Math.Pow(pEndX - pStartX, 2) + Math.Pow(pEndY - pStartY, 2)))
        PrepareWaveform(Distance, pSpeed, pWaveformParam, pWaveformParamType, pAO_Buff0, pAO_Buff1, pAO_Buff2, pAO_Buff3)
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pAO_Buff">Array AO buffer for channel 0</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <remarks></remarks>
    Public Function PrepareWaveform(ByVal pAO_Buff As Short(), ByVal pWaveformParam As Double, ByVal pWaveformParamType As enumWaveformParamType) As Boolean
     Try

            pAO_Buff = TranslateAOBuff(pAO_Buff)
            pWaveformParam = (pWaveformParam / (pAO_Buff.Length - 1)) * (pAO_Buff.Length + 1)

            ReDim pAO_Buff(pAO_Buff.Length)

            If m_Polar = DAQ2K_DA_BiPolar Then
                pAO_Buff(pAO_Buff.Length - 1) = 2048
            End If

            Dim SampleCount As Integer = pAO_Buff.Length
            Dim OneSampleUpdate As Double = 0
            Dim UI_Counter As Integer = 0

            If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
                OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
                UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
            Else
                OneSampleUpdate = (pWaveformParam / SampleCount)
                UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
            End If

            If (OneSampleUpdate < 1.0) Then
                PrepareWaveform = False
                Exit Function
            End If
            m_AO_Buff = pAO_Buff
            


            Dim card As Integer
            card = D2K_Register_Card(DAQ_2501, 0)
            If (card < 0) Then
                MsgBox(String.Format("Error {0} trying to open daq2501", card))
                Exit Function
            End If
            m_CardID = card
            m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
            m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



            Dim da_ch() As Short = {0}
            m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 1, da_ch(0))
            m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgNegative Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)



            m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount, m_Id)

            If (m_ErrCode < 0) Then
                PrepareWaveform = False
                Exit Function
            End If

            'err = D2K_AO_Group_WFM_StopConfig(m_CardID, DA_Group_A, DAQ2K_DA_STOPSRC_AFI0, DAQ2K_DA_TerminateUC)
            'If (m_ErrCode < 0) Then
            '    Call MsgBox(String.Format("D2K_AO_Group_WFM_StopConfig", m_ErrCode))
            '    D2K_Release_Card(m_CardID)
            '    Exit Sub
            'End If


            If UI_Counter > 16000000 Then '16777215
                UI_Counter = 16000000
            End If

            m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, 1, UI_Counter, 1)

            'm_ErrCode = D2K_AO_Group_VUpdate(m_CardID, DA_Group_A, 10)
            If (m_ErrCode < 0) Then
                D2K_AO_ContBufferReset(m_CardID)
                PrepareWaveform = False
                Exit Function
            End If
            PrepareWaveform = True
        Catch ex As Exception
            PrepareWaveform = False
        End Try


    End Function

    ''' <summary>
    ''' Prepare Waveform Solder
    ''' </summary>
    ''' <param name="pAO_Buff">Array AO buffer for channel 0</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <remarks></remarks>
    Public Function PrepareWaveformSolder(ByVal pAO_Buff As Short(), ByVal pWaveformParam As Double, ByVal pWaveformParamType As enumWaveformParamType) As Boolean
        Try
            Dim pAO_BuffNew() As Short
            Dim SampleCount As Integer
            Dim OneSampleUpdate As Double = 0
            Dim UI_Counter As Integer = 0

            Dim PeriodT As Double 'ms
            Dim PeriodT_One_Time As Double
            Dim UI_Counter_OneTime As Double
            Dim OneCount As Integer

            '40 / (40 X 1000000) = 1us

            Dim card As Integer
            Dim da_ch() As Short = {0}

            card = D2K_Register_Card(DAQ_2501, 0)
            If (card < 0) Then
                MsgBox(String.Format("Error {0} trying to open daq2501", card))
                Exit Function
            End If

            pAO_Buff = TranslateAOBuff(pAO_Buff)

            m_CardID = card
      


            If (pWaveformParamType = enumWaveformParamType.Time) Then
                PeriodT = pWaveformParam
                PeriodT_One_Time = PeriodT / pAO_Buff.Length



                Dim pProtectNum As Integer = 1
                If PeriodT <= 10 * 1000 Then
                    '4000 / (40 X 1000000) = 0.1ms
                    '(1000 X 10) / 0.1 = 100000
                    ' ''UI_Counter_OneTime = 0.1
                    ' ''UI_Counter = 4000
                    ' ''pProtectNum = 2000

                    UI_Counter_OneTime = 1
                    UI_Counter = 40000
                    pProtectNum = 200

                ElseIf PeriodT <= 100 * 1000 Then
                    '40000 / (40 X 1000000) = 1ms
                    '(10000 X 10) / 1 = 100000
                    UI_Counter_OneTime = 1
                    UI_Counter = 40000
                    pProtectNum = 200
                ElseIf PeriodT <= 1000 * 1000 Then
                    '400000 / (40 X 1000000) = 10ms
                    '(100000 X 10) / 10 = 100000
                    UI_Counter_OneTime = 10
                    UI_Counter = 400000
                    pProtectNum = 20
                End If


                OneCount = PeriodT_One_Time / UI_Counter_OneTime

                'pProtectNum = OneCount * 9 - 1

                'Dim Total As Integer = (((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000) / UI_Counter
                ReDim pAO_BuffNew(OneCount * 9 - 1)

                If OneCount * 9 <= 1000 Then
                    pProtectNum = 1000 - OneCount * 9
                End If

                Try
                    For i As Integer = 0 To (9 - 1) Step 1
                        For j As Integer = (i * OneCount) To ((i + 1) * OneCount - 1) Step 1
                            pAO_BuffNew(j) = pAO_Buff(i)
                        Next
                    Next
                Catch ex As Exception

                End Try

                ReDim Preserve pAO_BuffNew(pAO_BuffNew.Length - 1 + pProtectNum)


                For i As Integer = pAO_BuffNew.Length - 1 - pProtectNum To pAO_BuffNew.Length - 1 Step 1
                    If m_Polar = DAQ2K_DA_BiPolar Then
                        pAO_BuffNew(i) = 2048
                    Else

                        pAO_BuffNew(i) = 0
                    End If

                Next


                If m_Polar = DAQ2K_DA_BiPolar Then
                    pAO_BuffNew(0) = 2048
                Else

                    pAO_BuffNew(0) = 0
                End If
                SampleCount = pAO_BuffNew.Length
                m_AO_Buff = pAO_BuffNew

                'For i = 0 To m_AO_Buff.Length - 1
                '    m_AO_Buff(i) = CType((Math.Sin(CDbl(i) / (m_AO_Buff.Length - 1) * Math.PI) * 4095), Short)
                'Next
            Else
                SampleCount = pAO_Buff.Length



                If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
                    OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
                    UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
                Else
                    OneSampleUpdate = (pWaveformParam / SampleCount)
                    UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
                End If

                If (OneSampleUpdate < 1.0) Then
                    PrepareWaveformSolder = False
                    Exit Function
                End If

                m_AO_Buff = pAO_Buff
            End If




            If m_Polar = DAQ2K_DA_BiPolar Then
                m_AO_Buff(0) = 2048
            Else

                m_AO_Buff(0) = 0
            End If

            If m_Polar = DAQ2K_DA_BiPolar Then
                m_AO_Buff(m_AO_Buff.Length - 1) = 2048
            Else

                m_AO_Buff(m_AO_Buff.Length - 1) = 0
            End If

            m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



            m_ErrCode = D2K_AO_CH_Config(m_CardID, All_Channels, m_Polar, DAQ2K_DA_Int_REF, 10.0)

            m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 1, da_ch(0))

            ' m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgNegative Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)
            m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgNegative, 0, 0, 0, 0)


            m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount, m_Id)

            If (m_ErrCode < 0) Then
                PrepareWaveformSolder = False
                Exit Function
            End If



            m_ErrCode = D2K_AO_Group_FIFOLoad(m_CardID, DA_Group_A, m_Id, SampleCount)


            'err = D2K_AO_Group_WFM_StopConfig(m_CardID, DA_Group_A, DAQ2K_DA_STOPSRC_AFI0, DAQ2K_DA_TerminateUC)
            'If (m_ErrCode < 0) Then
            '    Call MsgBox(String.Format("D2K_AO_Group_WFM_StopConfig", m_ErrCode))
            '    D2K_Release_Card(m_CardID)
            '    Exit Sub
            'End If


            If UI_Counter > 16000000 Then '16777215
                UI_Counter = 16000000
            End If






            '  m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, 1, UI_Counter, 1)
            m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, BufferNotUsed, 0, 0, 1, UI_Counter, 1)

            'm_ErrCode = D2K_AO_Group_VUpdate(m_CardID, DA_Group_A, 10)
            If (m_ErrCode < 0) Then
                'D2K_AO_ContBufferReset(m_CardID)
                PrepareWaveformSolder = False
                Exit Function
            End If
            PrepareWaveformSolder = True
        Catch ex As Exception
            PrepareWaveformSolder = False
        End Try



    End Function


    Public Function ChkStop() As Integer
        Dim Stopped As Byte
        Dim WriteCnt As Integer
        D2K_AO_Group_WFM_AsyncCheck(m_CardID, DA_Group_A, Stopped, WriteCnt)
        ChkStop = Stopped
    End Function

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pAO_Buff0 As Short(), ByVal pAO_Buff1 As Short(), ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType)
        If (pAO_Buff0.Length <> pAO_Buff1.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 2 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0

        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If
        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        Dim da_ch() As Short = {0, 1}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 2, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferSetup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_WFM_Start!", MsgBoxStyle.Information, "CD2kDaskAO?StartWaveform")
            Exit Sub
        End If



        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 2, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, 1, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If


    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pAO_Buff0 As Short(), ByVal pAO_Buff1 As Short(), ByVal pAO_Buff2 As Short(), ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType)
        If (pAO_Buff0.Length <> pAO_Buff1.Length OrElse pAO_Buff0.Length <> pAO_Buff2.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length <> pAO_Buff2")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 3 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0

        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If
        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If

        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)

        Dim da_ch() As Short = {0, 1, 2}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 3, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 2, SampleCount, m_AO_Buff(0), pAO_Buff2(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 3, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, 1, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If
    End Sub

    ''' <summary>
    ''' Prepare Waveform
    ''' </summary>
    ''' <param name="pAO_Buff0">Array AO buffer for channel 0</param>
    ''' <param name="pAO_Buff1">Array AO buffer for channel 1</param>
    ''' <param name="pAO_Buff2">Array AO buffer for channel 2</param>
    ''' <param name="pAO_Buff3">Array AO buffer for channel 3</param>
    ''' <param name="pWaveformParam">Frequency (Hz) or Time (us)</param>
    ''' <param name="pWaveformParamType">enumWaveformParamType: Frequency or Time</param>
    ''' <remarks></remarks>
    Public Sub PrepareWaveform(ByVal pAO_Buff0 As Short(), ByVal pAO_Buff1 As Short(), ByVal pAO_Buff2 As Short(), ByVal pAO_Buff3 As Short(), ByVal pWaveformParam As Integer, ByVal pWaveformParamType As enumWaveformParamType)
        If (pAO_Buff0.Length <> pAO_Buff1.Length OrElse pAO_Buff0.Length <> pAO_Buff2.Length OrElse pAO_Buff0.Length <> pAO_Buff3.Length) Then
            Call MsgBox("pAO_Buff0.Length <> pAO_Buff1.Length <> pAO_Buff2.Length <> pAO_Buff3.Length")
            Exit Sub
        End If
        Dim SampleCount As Integer = pAO_Buff0.Length
        ReDim m_AO_Buff(SampleCount * 3 - 1)
        Dim OneSampleUpdate As Double = 0
        Dim UI_Counter As Integer = 0
        If (pWaveformParamType = enumWaveformParamType.Frequemcy) Then
            OneSampleUpdate = ((1.0 / pWaveformParam) / SampleCount) * 1000 * 1000
            UI_Counter = CInt(((1.0 / pWaveformParam) / SampleCount) * 40 * 1000 * 1000)
        Else
            OneSampleUpdate = (pWaveformParam / SampleCount)
            UI_Counter = CInt((pWaveformParam / SampleCount) * 40)
        End If
        If (OneSampleUpdate < 1.0) Then
            Call MsgBox("Minimum update time per sample is 1 us. Current is: " & OneSampleUpdate.ToString())
            Exit Sub
        End If



        Dim card As Integer
        card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_CardID = card
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, m_Polar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)



        Dim da_ch() As Short = {0, 1, 2, 3}
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 4, da_ch(0))
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Group_Setup error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, 0, 0, 0)

        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_Config error 0 !", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 0, SampleCount, m_AO_Buff(0), pAO_Buff0(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 1, SampleCount, m_AO_Buff(0), pAO_Buff1(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 2, SampleCount, m_AO_Buff(0), pAO_Buff2(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If

        m_ErrCode = D2K_AO_ContBufferCompose(m_CardID, DA_Group_A, 3, SampleCount, m_AO_Buff(0), pAO_Buff3(0), 0)
        If (m_ErrCode < 0) Then
            Call MsgBox("D2K_AO_ContBufferCompose!", MsgBoxStyle.Information, "CD2kDaskAO?PrepareWaveform")
            Exit Sub
        End If


        m_ErrCode = D2K_AO_ContBufferSetup(m_CardID, m_AO_Buff(0), SampleCount * 4, m_Id)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_ContBufferSetup error={0} for the 1st buffer", m_ErrCode))
            D2K_Release_Card(m_CardID)
            Return
        End If

        m_ErrCode = D2K_AO_Group_WFM_Start(m_CardID, DA_Group_A, m_Id, 0, SampleCount, 1, UI_Counter, 1)


        If (m_ErrCode < 0) Then
            Call MsgBox(String.Format("D2K_AO_Group_WFM_Start Error={0}", m_ErrCode))
            D2K_AO_ContBufferReset(m_CardID)
            D2K_Release_Card(m_CardID)
            Return
        End If
    End Sub



    Public Sub New()
        m_CardID = 0


        Dim card = D2K_Register_Card(DAQ_2501, 0)
        If (card < 0) Then
            Call MsgBox(String.Format("Error {0} trying to open daq2501", card))
            Exit Sub
        End If
        m_ErrCode = D2K_AO_CH_Config(m_CardID, -1, DAQ2K_DA_UniPolar, DAQ2K_DA_Int_REF, 10.0)
        m_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)

        'm_ErrCode = D2K_DIO_PortConfig(m_CardID, Channel_P1A, OUTPUT_PORT)

        Dim da_ch() As Short = {0}
        Dim DLY2Cnt As Short = Short.MaxValue
        m_ErrCode = D2K_AO_Group_Setup(m_CardID, DA_Group_A, 1, da_ch(0))

        m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgNegative Or DAQ2K_DA_ReTrigEn, 1, 0, 0, 0)

        '   m_ErrCode = D2K_AO_Config(m_CardID, DA_Group_A Or DAQ2K_DA_WRSRC_Int, DAQ2K_DA_TRGMOD_POST Or DAQ2K_DA_TRGSRC_ExtD Or DAQ2K_DA_TrgPositive Or DAQ2K_DA_ReTrigEn, 0, DLY2Cnt, 0, 0)



     


    End Sub

    Protected Overrides Sub Finalize()
        Try
            D2K_Release_Card(m_CardID)
            MyBase.Finalize()
        Catch ex As Exception

        End Try
       
    End Sub
End Class
Public Enum enumWaveformParamType
    Frequemcy
    Time
End Enum