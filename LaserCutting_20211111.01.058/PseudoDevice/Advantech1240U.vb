Imports System
Imports System.Runtime.InteropServices
Friend Module Advantech1240U
    'Module P1240
    Friend Const CFG_DiPatternMatchValue = &H3804S

    Friend Const CW = 0
    Friend Const CCW = 1
    Friend Const ImmediateStop = 0
    Friend Const SlowStop = 1
    Friend Const RelativeCoordinate = 0
    Friend Const AbsoluteCoordinate = 1
    Friend Const TCurveAcceleration = 0
    Friend Const SCurveAcceleration = 1
    '***********************************************************************
    ' Define Hardware Register Address
    '***********************************************************************
    ' These hardware register address can be used in P1240_InpWord and P1240_OutpWord
    Friend Const HW_WR0 = &H0S
    Friend Const HW_WR1 = &H2S
    Friend Const HW_WR2 = &H4S
    Friend Const HW_WR3 = &H6S
    Friend Const HW_WR4 = &H8S
    Friend Const HW_WR5 = &HAS
    Friend Const HW_WR6 = &HCS
    Friend Const HW_WR7 = &HES
    Friend Const HW_RR0 = &H10S
    Friend Const HW_RR1 = &H12S
    Friend Const HW_RR2 = &H14S
    Friend Const HW_RR3 = &H16S
    Friend Const HW_RR4 = &H18S
    Friend Const HW_RR5 = &H1AS
    Friend Const HW_RR6 = &H1CS
    Friend Const HW_RR7 = &H1ES
    '************************************************************************
    '   Define Register ID
    '************************************************************************/
    Friend Const Rcnt = &H100S                              ' Real position counter
    Friend Const Lcnt = &H101S                              ' Logical position counter
    Friend Const Pcmp = &H102S                              ' P direction compare register
    Friend Const Ncmp = &H103S                              ' N direction compare register
    Friend Const Pnum = &H104S                              ' Pulse number

    Friend Const CurV = &H105S        ' current logical speed
    Friend Const CurAC = &H106S        ' current logical acc

    Friend Const SLDN_STOP = &H26S
    Friend Const IMME_STOP = &H27S

    Friend Const WR3_OUTSL = &H80S

    Friend Const RESET = &H8000S
    Friend Const RR0 = &H200S
    Friend Const RR1 = &H202S
    Friend Const RR2 = &H204S
    Friend Const RR3 = &H206S
    Friend Const RR4 = &H208S
    Friend Const RR5 = &H20AS
    Friend Const RR6 = &H20CS
    Friend Const RR7 = &H20ES

    Friend Const WR0 = &H210S
    Friend Const WR1 = &H212S
    Friend Const WR2 = &H214S
    Friend Const WR3 = &H216S
    Friend Const WR4 = &H218S
    Friend Const WR5 = &H21AS
    Friend Const WR6 = &H21CS
    Friend Const WR7 = &H21ES

    Friend Const RG = &H300S
    Friend Const SV = &H301S
    Friend Const DV = &H302S
    Friend Const MDV = &H303S
    Friend Const AC = &H304S
    Friend Const DC = &H305S
    Friend Const AK = &H306S
    Friend Const PLmt = &H307S
    Friend Const NLmt = &H308S
    Friend Const HomeOffset = &H309S
    Friend Const HomeMode = &H30AS
    Friend Const HomeType = &H30BS
    Friend Const HomeP0_Dir = &H30CS
    Friend Const HomeP0_Speed = &H30DS
    Friend Const HomeP1_Dir = &H30ES
    Friend Const HomeP1_Speed = &H30FS
    Friend Const HomeP2_Dir = &H310S
    Friend Const HomeOffset_Speed = &H311S
    'Friend Const RWSN = &H312S
    Friend Const HomeEzCount = &H313S

    '************************************************************************
    '   Define Operation Axis
    '************************************************************************
    Friend Const IPO_Axis = &H0S
    Friend Const X_Axis = &H1S
    Friend Const Y_Axis = &H2S
    Friend Const Z_Axis = &H4S
    Friend Const U_Axis = &H8S
    Friend Const XY_Axis = &H3S
    Friend Const XZ_Axis = &H5S
    Friend Const XU_Axis = &H9S
    Friend Const YZ_Axis = &H6S
    Friend Const YU_Axis = &HAS
    Friend Const ZU_Axis = &HCS
    Friend Const XYZ_Axis = &H7S
    Friend Const XYU_Axis = &HBS
    Friend Const XZU_axis = &HDS
    Friend Const YZU_Axis = &HES
    Friend Const XYZU_Axis = &HFS

    '************************************************************************
    '   Path type for continue moving
    '************************************************************************
    Friend Const IPO_L2 = &H30S
    Friend Const IPO_L3 = &H31S
    Friend Const IPO_CW = &H32S
    Friend Const IPO_CCW = &H134S

    '************************************************************************
    '   Return Code
    '************************************************************************
    Friend Const BoardNumErr = &H1S
    Friend Const CreateKernelDriverFail = &H2S     'internal system error
    Friend Const CallKernelDriverFail = &H3S        'internal system error
    Friend Const RegistryOpenFail = &H4S           'Open registry file fail
    Friend Const RegistryReadFail = &H5S           'Read registry file fail
    Friend Const AxisNumErr = &H6S
    Friend Const UnderRGErr = &H7S
    Friend Const OverRGErr = &H8S
    Friend Const UnderSVErr = &H9S
    Friend Const OverSVErr = &HAS
    Friend Const OverMDVErr = &HBS
    Friend Const UnderDVErr = &HCS
    Friend Const OverDVErr = &HDS
    Friend Const UnderACErr = &HES
    Friend Const OverACErr = &HFS
    Friend Const UnderAKErr = &H10S
    Friend Const OverAKErr = &H11S
    Friend Const OverPLmtErr = &H12S
    Friend Const OverNLmtErr = &H13S
    Friend Const MaxMoveDistErr = &H14S
    Friend Const AxisDrvBusy = &H15S
    Friend Const RegUnDefine = &H16S
    Friend Const ParaValueErr = &H17S
    Friend Const ParaValueOverRange = &H18S
    Friend Const ParaValueUnderRange = &H19S
    Friend Const AxisHomeBusy = &H1AS
    Friend Const AxisExtBusy = &H1BS
    Friend Const RegistryWriteFail = &H1CS
    Friend Const ParaValueOverErr = &H1DS
    Friend Const ParaValueUnderErr = &H1ES
    Friend Const OverDCErr = &H1FS
    Friend Const UnderDCErr = &H20S
    Friend Const UnderMDVErr = &H21S
    Friend Const RegistryCreateFail = &H22S
    Friend Const CreateThreadErr = &H23S            'internal system fail
    Friend Const HomeSwStop = &H24S            'P1240HomeStatus
    Friend Const ChangeSpeedErr = &H25S
    Friend Const DOPortAsDriverStatus = &H26S

    Friend Const OpenEventFail = &H30S              'Internal system fail
    Friend Const DeviceCloseErr = &H32S      'Internal system fail

    Friend Const HomeEMGStop = &H40S                'P1240HomeStatus
    Friend Const HomeLMTPStop = &H41S               'P1240HomeStatus
    Friend Const HomeLMTNStop = &H42S              'P1240HomeStatus
    Friend Const HomeALARMStop = &H43S              'P1240HomeStatus

    Friend Const AllocateBufferFail = &H50S
    Friend Const BufferReAllocate = &H51S
    Friend Const FreeBufferFail = &H52S
    Friend Const FirstPointNumberFail = &H53S
    Friend Const PointNumExceedAllocatedSize = &H54S
    Friend Const BufferNoneAllocate = &H55S
    Friend Const SequenceNumberErr = &H56S
    Friend Const PathTypeErr = &H57S
    Friend Const PathTypeMixErr = &H60S
    Friend Const BufferDataNotEnough = &H61S

    Friend Const ChangePositionErr = &H27S            'Change position error


    '************************************************************************
    '  External mode
    '************************************************************************
    Friend Const JOGDisable = &H0S
    Friend Const JOGSelfAxis = &H1S
    Friend Const JOGSelect_XAxis = &H2S
    Friend Const JOGSelect_YAxis = &H3S
    Friend Const JOGConnect_XAxis = &H4S
    Friend Const JOGConnect_YAxis = &H5S
    Friend Const JOGConnect_ZAxis = &H6S
    Friend Const JOGConnect_UAxis = &H7S
    Friend Const HandWheelDisable = &H8S
    Friend Const HandWheelSelfAxis = &H9S
    Friend Const HandWheelSelect_XAxis = &HAS
    Friend Const HandWheelSelect_YAxis = &HBS
    Friend Const HandWheelFrom_XAxis = &HCS
    Friend Const HandWheelFrom_YAxis = &HDS
    Friend Const HandWheelFrom_ZAxis = &HES
    Friend Const HandWheelFrom_UAxis = &HFS

    ' Line Interplation( 2 axes )  
    '		- dwEndPoint_ax1;
    '		- dwEndPoint_ax2;
    '		- wCommand;					; IPO_L2	
    ' Line Interplation( 3 axes )  
    '		- dwEndPoint_ax1;
    '		- dwEndPoint_ax2;
    '		- dwEndPoint_ax3;
    '		- wCommand;					; IPO_L3	
    ' Arc  Interplation( only 2 axes )  
    '		- dwEndPoint_ax1;			; Arc end point of axis 1
    '		- dwEndPoint_ax2;			; Arc end point of axis 2
    '		- dwCenPoint_ax1;			; Arc center point of axis 1
    '		- dwCenPoint_ax1;			; Arc center point of axis 2	
    '		- wCommand;					; IPO_CW,IPO_CCW
    Friend Structure MotMoveBuffer
        Dim dwEndPoint_ax1 As UInt32  ' End position for 1'st axis
        Dim dwEndPoint_ax2 As UInt32  ' End position for 2'nd axis
        Dim dwEndPoint_ax3 As UInt32 ' End position for 3'rd axis
        Dim dwCenPoint_ax1 As UInt32  ' Center position for 1'st axis	
        Dim dwCenPoint_ax2 As UInt32 ' Center position for 2'rd axis
        Dim dwPointNum As UInt32  ' Serial number for current data

        Dim wCommand As UInt16    ' IPO_CW,IPO_CCW,IPO_L2,IPO_L3 			
        Dim TempB As UInt16     ' For internal using
        Dim TempA As UInt32     ' For internal using
    End Structure

    Friend Structure MotionDataStruct
        Dim lpBufIDAddr As MotMoveBuffer ' Buffer address			
        Dim hBuf As Int32        ' Hanlde of Buffer 
        Dim dwAllPointNum As UInt32      ' How many point of continue move ( get from P1240InitContiBuf)
        Dim bPoint1Flag As Boolean
        Dim dwEndPointNum As UInt32
    End Structure

    Friend Structure MotSpeedTable
        Dim dwSpeed As UInt32 ' speed data
        Dim dwComp As UInt32  ' comparator data
    End Structure

    '---------------------------------------------------
    '   Return Code for PCI-1240
    '---------------------------------------------------;
    Friend Const FunctionNotSupport = &H62S
    Friend Const DeviceNotExist = &H63S

    ' --------------------------------------------------
    '   Used by PCI-1240 to read write SN
    ' --------------------------------------------------
    Friend Const RWSN = &H312S

    ' added by yongdong
    Friend Structure VBoard_ID
        Dim byBoard_ID As Byte
    End Structure
    Declare Function B_1240_MotDevOpen Lib "Ads1240.dll" Alias "P1240MotDevOpen" (ByVal byBoard_ID As Byte) As Integer
    Declare Function B_1240_MotDevAvailable Lib "Ads1240.dll" Alias "P1240MotDevAvailable" (ByRef BoardAvailable As UInt32) As Integer
    Declare Function B_1240_MotDevClose Lib "Ads1240.dll" Alias "P1240MotDevClose" (ByVal byBoard_ID As Byte) As Integer
    Declare Function B_1240_MotAxisParaSet Lib "Ads1240.dll" Alias "P1240MotAxisParaSet" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal byTS As Byte, ByVal dwSV As UInt32, ByVal dwDV As UInt32, ByVal dwMDV As UInt32, ByVal dwAC As UInt32, ByVal dwAK As UInt32) As Integer
    Declare Function B_1240_MotChgDV Lib "Ads1240.dll" Alias "P1240MotChgDV" (ByRef BoardAvailable As UInt32) As Integer
    Declare Function B_1240_MotChgLineArcDV Lib "Ads1240.dll" Alias "P1240MotChgLineArcDV" (ByVal byBoard_ID As Byte, ByVal dwSetDVValue As UInt32) As Integer
    Declare Function B_1240_MotCmove Lib "Ads1240.dll" Alias "P1240MotCmove" (ByVal byBoard_ID As Byte, ByVal byCMoveAxis As Byte, ByVal byAxisDirection As Byte) As Integer
    Declare Function B_1240_MotPtp Lib "Ads1240.dll" Alias "P1240MotPtp" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byRA As Byte, ByVal lPulseX As Int32, ByVal lPulseY As Int32, ByVal lPulseZ As Int32, ByVal lPulseU As Int32) As Integer
    Declare Function B_1240_MotLine Lib "Ads1240.dll" Alias "P1240MotLine" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byRA As Byte, ByVal lPulseX As Int32, ByVal lPulseY As Int32, ByVal lPulseZ As Int32, ByVal lPulseU As Int32) As Integer
    Declare Function B_1240_MotArc Lib "Ads1240.dll" Alias "P1240MotArc" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byRA As Byte, ByVal byAxisDirection As Byte, ByVal lCenter1 As Int32, ByVal lCenter2 As Int32, ByVal lEnd1 As Int32, ByVal lEnd2 As Int32) As Integer
    Declare Function B_1240_MotArcTheta Lib "Ads1240.dll" Alias "P1240MotArcTheta" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byRA As Byte, ByVal lCenter1 As Int32, ByVal lCenter2 As Int32, ByVal dMoveDeg As Double) As Integer
    Declare Function B_1240_MotStop Lib "Ads1240.dll" Alias "P1240MotStop" (ByVal byBoard_ID As Byte, ByVal byStopAxis As Byte, ByVal byStopMode As Byte) As Integer
    Declare Function B_1240_MotAxisBusy Lib "Ads1240.dll" Alias "P1240MotAxisBusy" (ByVal byBoard_ID As Byte, ByVal byCheckAxis As Byte) As Integer
    Declare Function B_1240_MotClrErr Lib "Ads1240.dll" Alias "P1240MotClrErr" (ByVal byBoard_ID As Byte, ByVal byClearAxis As Byte) As Integer
    Declare Function B_1240_MotRdReg Lib "Ads1240.dll" Alias "P1240MotRdReg" (ByVal byBoard_ID As Byte, ByVal byReadAxis As Byte, ByVal wCommandCode As UInt16, ByRef lpReturnValue As Int32) As Integer
    Declare Function B_1240_MotWrReg Lib "Ads1240.dll" Alias "P1240MotWrReg" (ByVal byBoard_ID As Byte, ByVal byWriteAxis As Byte, ByVal wCommandCode As UInt16, ByVal dwWriteValue As UInt32) As Integer
    Declare Function B_1240_MotSavePara Lib "Ads1240.dll" Alias "P1240MotSavePara" (ByVal byBoard_ID As Byte, ByVal bySaveAxis As Byte) As Integer
    Declare Function B_1240_MotEnableEvent Lib "Ads1240.dll" Alias "P1240MotEnableEvent" (ByVal byBoard_ID As Byte, ByVal bySettingAxis As Byte, ByVal byX_AxisEvent As Byte, ByVal byY_AxisEvent As Byte, ByVal byZ_AxisEvent As Byte, ByVal byU_AxisEvent As Byte) As Integer
    Declare Function B_1240_MotCheckEvent Lib "Ads1240.dll" Alias "P1240MotCheckEvent" (ByVal byBoard_ID As Byte, ByRef lpRetEventStatus As Int32, ByVal dwMillisecond As Int32) As Integer
    Declare Function B_1240_MotRdMutiReg Lib "Ads1240.dll" Alias "P1240MotRdMutiReg" (ByVal byBoard_ID As Byte, ByVal byReadAxis As Byte, ByVal wCommandCode As UInt16, ByRef lpReturn_XAxisValue As Int32, ByRef lpReturn_YAxisValue As Int32, ByRef lpReturn_ZAxisValue As Int32, ByRef lpReturn_UAxisValue As Int32) As Integer
    Declare Function B_1240_MotRdMultiReg Lib "Ads1240.dll" Alias "P1240MotRdMultiReg" (ByVal byBoard_ID As Byte, ByVal byReadAxis As Byte, ByVal wCommandCode As UInt16, ByRef lpReturn_XAxisValue As UInt32, ByRef lpReturn_YAxisValue As UInt32, ByRef lpReturn_ZAxisValue As UInt32, ByRef lpReturn_UAxisValue As UInt32) As Integer
    Declare Function B_1240_MotWrMutiReg Lib "Ads1240.dll" Alias "P1240MotWrMutiReg" (ByVal byBoard_ID As Byte, ByVal byWriteAxis As Byte, ByVal wCommandCode As UInt16, ByVal dwWrite_XAxisValue As UInt32, ByVal dwWrite_YAxisValue As UInt32, ByVal dwWrite_ZAxisValue As UInt32, ByVal dwWrite_UAxisValue As UInt32) As Integer
    Declare Function B_1240_MotWrMultiReg Lib "Ads1240.dll" Alias "P1240MotWrMultiReg" (ByVal byBoard_ID As Byte, ByVal byWriteAxis As Byte, ByVal wCommandCode As UInt16, ByVal dwWrite_XAxisValue As UInt32, ByVal dwWrite_YAxisValue As UInt32, ByVal dwWrite_ZAxisValue As UInt32, ByVal dwWrite_UAxisValue As UInt32) As Integer
    Declare Function B_1240_MotHome Lib "Ads1240.dll" Alias "P1240MotHome" (ByVal byBoard_ID As Byte, ByVal byHomeAxis As Byte) As Integer
    Declare Function B_1240_MotHomeStatus Lib "Ads1240.dll" Alias "P1240MotHomeStatus" (ByVal byBoard_ID As Byte, ByVal byHomeAxis As Byte, ByRef lpReturnValue As UInt32) As Integer
    Declare Function B_1240_MotDI Lib "Ads1240.dll" Alias "P1240MotDI" (ByVal byBoard_ID As Byte, ByVal byReadDIAxis As Byte, ByRef lpReturnValue As Byte) As Integer
    Declare Function B_1240_MotDO Lib "Ads1240.dll" Alias "P1240MotDO" (ByVal byBoard_ID As Byte, ByVal byWriteDOAxis As Byte, ByVal byWriteValue As Byte) As Integer
    Declare Function B_1240_MotExtMode Lib "Ads1240.dll" Alias "P1240MotExtMode" (ByVal byBoard_ID As Byte, ByVal byAssignmentAxis As Byte, ByVal byExternalMode As Byte, ByVal lPulseNum As Int32) As Integer
    Declare Function B_1240_MotReset Lib "Ads1240.dll" Alias "P1240MotReset" (ByVal byBoard_ID As Byte) As UInt32
    Declare Function B_1240_InitialContiBuf Lib "Ads1240.dll" Alias "P1240InitialContiBuf" (ByVal byBufID As Byte, ByVal dwAllPointNum As UInt32) As Integer
    Declare Function B_1240_FreeContiBuf Lib "Ads1240.dll" Alias "P1240FreeContiBuf" (ByVal byBufID As Byte) As Integer
    Declare Function B_1240_SetContiData Lib "Ads1240.dll" Alias "P1240SetContiData" (ByVal byBufID As Byte, ByRef lpPathData As MotMoveBuffer, ByVal dwPointNum As UInt32) As Integer
    Declare Function B_1240_StartContiDrive Lib "Ads1240.dll" Alias "P1240StartContiDrive" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byBufID As Byte) As Integer
    Declare Function B_1240_GetCurContiNum Lib "Ads1240.dll" Alias "P1240GetCurContiNum" (ByVal byBoard_ID As Byte, ByRef lpReturnValue As UInt32) As Integer
    Declare Function B_1240_ChgPosOnFly Lib "Ads1240.dll" Alias "P1240ChgPosOnFly" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byRA As Byte, ByVal lPulseX As Int32, ByVal lPulseY As Int32, ByVal lPulseZ As Int32, ByVal lPulseU As Int32) As Integer
    Declare Function B_1240_BuildCompTable Lib "Ads1240.dll" Alias "P1240BuildCompTable" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByRef dwTableArray As UInt32, ByVal dwAllPointNum As UInt32) As Integer
    Declare Function B_1240_BuildSpeedTable Lib "Ads1240.dll" Alias "P1240BuildSpeedTable" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByRef SpeedTable As MotSpeedTable, ByVal dwAllPointNum As UInt32) As Integer
    Declare Function B_1240_SetCompPLimit Lib "Ads1240.dll" Alias "P1240SetCompPLimit" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lWriteValue As Int32) As Integer
    Declare Function B_1240_SetCompNLimit Lib "Ads1240.dll" Alias "P1240SetCompNLimit" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lWriteValue As Int32) As Integer
    Declare Function B_1240_EnableCompPLimit Lib "Ads1240.dll" Alias "P1240EnableCompPLimit" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Enable As UInt16) As Integer
    Declare Function B_1240_EnableCompNLimit Lib "Ads1240.dll" Alias "P1240EnableCompNLimit" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Enable As UInt16) As Integer
    Declare Function B_1240_SetPLimitLogic Lib "Ads1240.dll" Alias "P1240SetPLimitLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetNLimitLogic Lib "Ads1240.dll" Alias "P1240SetNLimitLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetCompareObject Lib "Ads1240.dll" Alias "P1240SetCompareObject" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetPulseMode Lib "Ads1240.dll" Alias "P1240SetPulseMode" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetPulseLogic Lib "Ads1240.dll" Alias "P1240SetPulseLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetPulseDirLogic Lib "Ads1240.dll" Alias "P1240SetPulseDirLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetEncoderMultiple Lib "Ads1240.dll" Alias "P1240SetEncoderMultiple" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetServoAlarm Lib "Ads1240.dll" Alias "P1240SetServoAlarm" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Enable As UInt16, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetInPosition Lib "Ads1240.dll" Alias "P1240SetInPosition" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Enable As UInt16, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetHomeLogic Lib "Ads1240.dll" Alias "P1240SetHomeLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetZLogic Lib "Ads1240.dll" Alias "P1240SetZLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetOutput Lib "Ads1240.dll" Alias "P1240SetOutput" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Value As UInt16) As Integer
    Declare Function B_1240_SetOutputType Lib "Ads1240.dll" Alias "P1240SetOutputType" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal Enable As UInt16) As Integer
    Declare Function B_1240_SetInputLogic Lib "Ads1240.dll" Alias "P1240SetInputLogic" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal D4Value As UInt16, ByVal D6Value As UInt16) As Integer
    Declare Function B_1240_GetError Lib "Ads1240.dll" Alias "P1240GetError" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int16) As Integer
    Declare Function B_1240_GetDriverState Lib "Ads1240.dll" Alias "P1240GetDriverState" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int16) As Integer
    Declare Function B_1240_GetMotionState Lib "Ads1240.dll" Alias "P1240GetMotionState" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As UInt16) As Integer
    Declare Function B_1240_GetMotionInput Lib "Ads1240.dll" Alias "P1240GetMotionInput" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As UInt16) As Integer
    Declare Function B_1240_GetCompareState Lib "Ads1240.dll" Alias "P1240GetCompareState" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As UInt16) As Integer
    Declare Function B_1240_GetInput Lib "Ads1240.dll" Alias "P1240GetInput" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As UInt16) As Integer
    Declare Function B_1240_MoveAbs Lib "Ads1240.dll" Alias "P1240MoveAbs" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal lPulseNumber As Int32) As Integer
    Declare Function B_1240_MoveIns Lib "Ads1240.dll" Alias "P1240MoveIns" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal lPulseNumber As Int32) As Integer
    Declare Function B_1240_MoveCircle Lib "Ads1240.dll" Alias "P1240MoveCircle" (ByVal byBoard_ID As Byte, ByVal byMoveAxis As Byte, ByVal byAxisDirection As Byte, ByVal lCenter1 As Int32, ByVal lCenter2 As Int32) As Integer
    Declare Function B_1240_SetStartSpeed Lib "Ads1240.dll" Alias "P1240SetStartSpeed" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lSpeedValue As UInt32) As Integer
    Declare Function B_1240_SetDrivingSpeed Lib "Ads1240.dll" Alias "P1240SetDrivingSpeed" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lSpeedValue As UInt32) As Integer
    Declare Function B_1240_SetAcceleration Lib "Ads1240.dll" Alias "P1240SetAcceleration" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal accel As UInt32) As Integer
    Declare Function B_1240_SetDeceleration Lib "Ads1240.dll" Alias "P1240SetDeceleration" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal decel As UInt32, ByVal lRetrieve As Int32) As Integer
    Declare Function B_1240_SetJerk Lib "Ads1240.dll" Alias "P1240SetJerk" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lJerk As UInt32) As Integer
    Declare Function B_1240_SetRange Lib "Ads1240.dll" Alias "P1240SetRange" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lRange As UInt32) As Integer
    Declare Function B_1240_GetSpeed Lib "Ads1240.dll" Alias "P1240GetSpeed" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int32) As Integer
    Declare Function B_1240_GetAcel Lib "Ads1240.dll" Alias "P1240GetAcel" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int32) As Integer
    Declare Function B_1240_GetPracticalRegister Lib "Ads1240.dll" Alias "P1240GetPracticalRegister" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int32) As Integer
    Declare Function B_1240_GetTheorecticalRegister Lib "Ads1240.dll" Alias "P1240GetTheorecticalRegister" (ByVal byBoard_ID As Byte, ByVal byGetAxis As Byte, ByRef lpValue As Int32) As Integer
    Declare Function B_1240_SetPracticalRegister Lib "Ads1240.dll" Alias "P1240SetPracticalRegister" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByVal lPosition As Int32) As Integer
    Declare Function B_1240_SetTheorecticalRegister Lib "Ads1240.dll" Alias "P1240SetTheorecticalRegister" (ByVal byBoard_ID As Byte, ByVal bySetAxis As Byte, ByRef lPosition As Int32) As Integer
    Declare Function B_1240_OutpWord Lib "Ads1240.dll" Alias "P1240_OutpWord" (ByVal byBoard_ID As Byte, ByVal nPort As UInt16, ByVal wWord As UInt16) As Integer
    Declare Function B_1240_InpWord Lib "Ads1240.dll" Alias "P1240_InpWord" (ByVal byBoard_ID As Byte, ByVal nPort As UInt16, ByRef ptWord As UInt16) As Integer
    Declare Function B_1240_ReadEEPROM Lib "Ads1240.dll" Alias "P1240ReadEEPROM" (ByVal byBoard_ID As Byte, ByVal byEEPROMAddress As Byte, ByRef pusReadValue As UInt16) As Integer
    Declare Function B_1240_WriteEEPROM Lib "Ads1240.dll" Alias "P1240WriteEEPROM" (ByVal byBoard_ID As Byte, ByVal byEEPROMAddress As Byte, ByVal usWriteValue As UInt16) As Integer
    Declare Function B_1240_DaqDiGetByte Lib "Ads1240.dll" Alias "P1240DaqDiGetByte" (ByVal byBoard_ID As Byte, ByVal nPort As UInt16, ByRef ptbyDIData As Byte) As Integer
    Declare Function B_1240_DaqDiGetBit Lib "Ads1240.dll" Alias "P1240DaqDiGetBit" (ByVal byBoard_ID As Byte, ByVal DiChannel As UInt16, ByRef BitData As Byte) As Integer
    Declare Function B_1240_DaqDoSetByte Lib "Ads1240.dll" Alias "P1240DaqDoSetByte" (ByVal byBoard_ID As Byte, ByVal nPort As UInt16, ByVal byDOData As Byte) As Integer
    Declare Function B_1240_DaqDoSetBit Lib "Ads1240.dll" Alias "P1240DaqDoSetBit" (ByVal byBoard_ID As Byte, ByVal DoChannel As UInt16, ByVal BitData As Byte) As Integer
    Declare Function B_1240_DaqDoGetByte Lib "Ads1240.dll" Alias "P1240DaqDoGetByte" (ByVal byBoard_ID As Byte, ByVal nPort As UInt16, ByRef ptbyDOData As Byte) As Integer
    Declare Function B_1240_DaqDoGetBit Lib "Ads1240.dll" Alias "P1240DaqDoGetBit" (ByVal byBoard_ID As Byte, ByVal DoChannel As UInt16, ByRef BitData As Byte) As Integer
    Declare Function B_1240_GetCPLDVersion Lib "Ads1240.dll" Alias "P1240GetCPLDVersion" (ByVal byBoard_ID As Byte, ByRef ptdwCPLDVer As UInt32) As Integer
    Friend Const SERVO_HIGH_ACTIVE = &H4S
    Friend Const SERVO_LOW_ACTIVE = &HBS
    Friend Sub ShowError(ByVal Err_Renamed As Integer)
        Dim ErrMsg As String

        If Err_Renamed = 0 Then
            Exit Sub
        End If

        Select Case Err_Renamed

            Case &H1S
                ErrMsg = "The assigned Board number error"
            Case &H2S
                ErrMsg = "System return error when open kernel driver"
            Case &H3S
                ErrMsg = "System return error when call kernel driver"
            Case &H4S
                ErrMsg = "Open Registry file error"
            Case &H5S
                ErrMsg = "Read Registry file error"
            Case &H6S
                ErrMsg = "The assigned axis number error"
            Case &H7S
                ErrMsg = "RG value is under valid range"
            Case &H8S
                ErrMsg = "RG value is over valid range"
            Case &H9S
                ErrMsg = "SV value is under valid range"
            Case &HAS
                ErrMsg = "SV value is over valid range"
            Case &HBS
                ErrMsg = "MDV value is over valid range"
            Case &HCS
                ErrMsg = "DV value is under valid range"
            Case &HDS
                ErrMsg = "DV value is over valid range"
            Case &HES
                ErrMsg = "AC value is under valid range"
            Case &HFS
                ErrMsg = "AC value is over valid range"
            Case &H10S
                ErrMsg = "AK value is under valid range"
            Case &H11S
                ErrMsg = "AK value is over valid range"
            Case &H12S
                ErrMsg = "PLmt value is over valid range"
            Case &H13S
                ErrMsg = "NLmt value is over valid range"
            Case &H14S
                ErrMsg = "Moving distance is over single maximum distance"
            Case &H15S
                ErrMsg = "One of the assigned axis is in busy state"
            Case &H16S
                ErrMsg = "The assigned Register have no defined"
            Case &H17S
                ErrMsg = "One of the assigned parameter value is invalid"
            Case &H18S
                ErrMsg = "One of the assigned parameter value is over valid value"
            Case &H19S
                ErrMsg = "One of the assigned parameter value is under valid value"
            Case &H1AS
                ErrMsg = "One of the assigned axis is in Home process"
            Case &H1BS
                ErrMsg = "One of the assigned axis is in External driving mode"
            Case &H1CS
                ErrMsg = "Write Registry file error"
            Case &H1DS
                ErrMsg = "One of the assigned parameter value is over valid value"
            Case &H1ES
                ErrMsg = "One of the assigned parameter value is under valid value"
            Case &H1FS
                ErrMsg = "DC value is over valid range"
            Case &H20S
                ErrMsg = "DC value is under valid range"
            Case &H21S
                ErrMsg = "MDV value is under valid range"
            Case &H22S
                ErrMsg = "Create Registry file fail"
            Case &H23S
                ErrMsg = "Create internal Thread error"
            Case &H24S
                ErrMsg = "Return Home process be stopped by P3240MotStop function"
            Case &H25S
                ErrMsg = "The speed parameter is invalid"
            Case &H26S
                ErrMsg = "Output DO when DO type is assigned to indicator function"
            Case &H30S
                ErrMsg = "System return error when create IRQ event"
            Case &H32S
                ErrMsg = "System return error when in P3240MotDevClose process"
            Case &H40S
                ErrMsg = "Return home process be stopped by hardware emergency stop input"
            Case &H41S
                ErrMsg = "Return home process be stopped by hardware positive limited switch"
            Case &H42S
                ErrMsg = "Return home process be stopped by hardware negative limited switch"
            Case &H43S
                ErrMsg = "Return home process be stopped by ALARM signal input"
            Case &H50S
                ErrMsg = "System return error when buffer allocate"
            Case &H51S
                ErrMsg = "The assigned buffer have been allocated and try to reallocate again"
            Case &H52S
                ErrMsg = "The handle of assigned Buffer is NULL or has been freed before"
            Case &H53S
                ErrMsg = "The first data hasn't been set and try to set other number data"
            Case &H54S
                ErrMsg = "Current buffer is full"
            Case &H55S
                ErrMsg = "The assigned Buffer number hasn't created"
            Case &H56S
                ErrMsg = "The point number is not continue number of previous setting data"
            Case &H57S
                ErrMsg = "Path type is not IPO_L2, IPO_L3, IPO_CW or IPO_CCW"
            Case &H60S
                ErrMsg = "Continue Data buffer have mixed IPO_L2 and IPO_L3 or IPO_CW/IPO_CCW and IPO_L3 path type"
            Case &H61S
                ErrMsg = "Buffer contain only one data"
            Case &H62S
                ErrMsg = "Device not in the system"
            Case Else
                ErrMsg = "Undefined Error Message"
        End Select

        MsgBox(ErrMsg, MsgBoxStyle.OkOnly, "PCI-1240 Message")

    End Sub

End Module
