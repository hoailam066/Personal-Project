Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.UnmanagedType
Imports System.Threading
Imports Xmler.CXmler
Friend Class CYaskawa
    Implements IPseudoMotion
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Friend Sub New(ByRef pAxis() As CAxisBased)
        m_Axis = pAxis
        m_Errmsg(eErrMsg.MP_SUCCESS) = "API function normal completion"
        m_Errmsg(eErrMsg.MP_FAIL) = "API function erroneous completion"
        m_Errmsg(eErrMsg.WDT_OVER_ERR) = ""
        m_Errmsg(eErrMsg.MANUAL_RESET_ERR) = "Manual reset error"
        m_Errmsg(eErrMsg.TLB_MLTHIT_ERR) = "TLB multi hit error"
        m_Errmsg(eErrMsg.UBRK_ERR) = "User break execution error"
        m_Errmsg(eErrMsg.ADR_RD_ERR) = "Address read error error"
        m_Errmsg(eErrMsg.TLB_MIS_RD_ERR) = "TLB read mis error"
        m_Errmsg(eErrMsg.TLB_PROTECTION_RD_ERR) = "TLB protection read vaiolation error"
        m_Errmsg(eErrMsg.GENERAL_INVALID_INS_ERR) = "General invalid instruction error"
        m_Errmsg(eErrMsg.SLOT_ERR) = "Slot invalid instruction error"
        m_Errmsg(eErrMsg.GENERAL_FPU_DISABLE_ERR) = "General FPU disable error"
        m_Errmsg(eErrMsg.SLOT_FPU_ERR) = "Slot FPU exception error"
        m_Errmsg(eErrMsg.ADR_WR_ERR) = "Data address write error error"
        m_Errmsg(eErrMsg.TLB_MIS_WR_ERR) = "TLB write mis error"
        m_Errmsg(eErrMsg.TLB_PROTECTION_WR_ERR) = "TLB protection write vaiolation error"
        m_Errmsg(eErrMsg.FPU_EXP_ERR) = "FPU exception error"
        m_Errmsg(eErrMsg.INITIAL_PAGE_EXP_ERR) = "Initial page write exception error"
        m_Errmsg(eErrMsg.ROM_ERR) = "ROM  error"
        m_Errmsg(eErrMsg.RAM_ERR) = "RAM  error"
        m_Errmsg(eErrMsg.MPU_ERR) = "CPU  error"
        m_Errmsg(eErrMsg.FPU_ERR) = "FPU  error"
        m_Errmsg(eErrMsg.CERF_ERR) = "CERF error"
        m_Errmsg(eErrMsg.EXIO_ERR) = "EXIO error"
        m_Errmsg(eErrMsg.BUSIF_ERR) = "Common RAM error for OEM"
        m_Errmsg(eErrMsg.ALM_NO_ALM) = "No alarm"
        m_Errmsg(eErrMsg.ALM_MK_DEBUG) = "Minor failure: Alarm code for debugging"
        m_Errmsg(eErrMsg.ALM_MK_ROUND_ERR) = "Minor failure: Improper specification of one cycle at radius specification"
        m_Errmsg(eErrMsg.ALM_MK_FSPEED_OVER) = "Minor failure: Feeding speed exceeded"
        m_Errmsg(eErrMsg.ALM_MK_FSPEED_NOSPEC) = "Minor failure: Feeding speed not specified"
        m_Errmsg(eErrMsg.ALM_MK_PRM_OVER) = "Minor failure: Value after conversion of acceleration or deceleration parameter is out of range."
        m_Errmsg(eErrMsg.ALM_MK_ARCLEN_OVER) = "Minor failure: Arc length exceeds LONG_MAX."
        m_Errmsg(eErrMsg.ALM_MK_VERT_NOSPEC) = "Minor failure: Vertical axis by plane specification not specified"
        m_Errmsg(eErrMsg.ALM_MK_HORZ_NOSPEC) = "Minor failure: Horizontal axis by plane specification not specified"
        m_Errmsg(eErrMsg.ALM_MK_TURN_OVER) = "Minor failure: Specified number of turns exceeded"
        m_Errmsg(eErrMsg.ALM_MK_RADIUS_OVER) = "Minor failure: Radius exceeds LONG_MAX."
        m_Errmsg(eErrMsg.ALM_MK_CENTER_ERR) = "Minor failure: Illegal center point specification"
        m_Errmsg(eErrMsg.ALM_MK_BLOCK_OVER) = "Minor failure: Linear interpolation block moving amount exceeded"
        m_Errmsg(eErrMsg.ALM_MK_MAXF_NOSPEC) = "Minor failure: maxf not defined"
        m_Errmsg(eErrMsg.ALM_MK_TDATA_ERR) = "Minor failure: Address T data error"
        m_Errmsg(eErrMsg.ALM_MK_REG_ERR) = "Minor failure: REG data error and PP fault"
        m_Errmsg(eErrMsg.ALM_MK_COMMAND_CODE_ERR) = "Minor failure: Out-of-range command"
        m_Errmsg(eErrMsg.ALM_MK_AXIS_CONFLICT) = "Minor failure: Use of logical axis being prohibited"
        m_Errmsg(eErrMsg.ALM_MK_POSMAX_OVER) = "Minor failure: Infinite length axis, MVM or ABS coordinate designation exceeds POSMAX."
        m_Errmsg(eErrMsg.ALM_MK_DIST_OVER) = "Minor failure: Axis moving distance is other than (LONG_MIN, LONG_MAX)."
        m_Errmsg(eErrMsg.ALM_MK_MODE_ERR) = "Minor failure: Illegal control mode"
        m_Errmsg(eErrMsg.ALM_MK_CMD_CONFLICT) = "Minor failure: Motion command overlapping instruction"
        m_Errmsg(eErrMsg.ALM_MK_RCMD_CONFLICT) = "Minor failure: Motion response command overlapping instruction"
        m_Errmsg(eErrMsg.ALM_MK_CMD_MODE_ERR) = "Minor failure: Illegal motion command mode"
        m_Errmsg(eErrMsg.ALM_MK_CMD_NOT_ALLOW) = "Minor failure: Command cannot be executed ih this Module."
        m_Errmsg(eErrMsg.ALM_MK_CMD_DEN_FAIL) = "Minor failure: Distribution is not completed."
        m_Errmsg(eErrMsg.ALM_MK_H_MOVE_ERR) = "Minor failure: Illegal hMove"
        m_Errmsg(eErrMsg.ALM_MK_MOVE_NOT_SUPPORT) = "Minor failure: Non-supported Move defined"
        m_Errmsg(eErrMsg.ALM_MK_EVENT_NOT_SUPPORT) = "Minor failure: Non-supported Move Event defined"
        m_Errmsg(eErrMsg.ALM_MK_ACTION_NOT_SUPPORT) = "Minor failure: Non-supported Move Action defined"
        m_Errmsg(eErrMsg.ALM_MK_MOVE_TYPE_ERR) = "Minor failure: MoveType specification error"
        m_Errmsg(eErrMsg.ALM_MK_VTYPE_ERR) = "Minor failure: VelocityType specification error"
        m_Errmsg(eErrMsg.ALM_MK_ATYPE_ERR) = "Minor failure: AccelerationType specification error"
        m_Errmsg(eErrMsg.ALM_MK_HOMING_METHOD_ERR) = "Minor failure: Homing_method specification error"
        m_Errmsg(eErrMsg.ALM_MK_ACC_ERR) = "Minor failure: Acceleration setting error"
        m_Errmsg(eErrMsg.ALM_MK_DEC_ERR) = "Minor failure: Deceleration setting error"
        m_Errmsg(eErrMsg.ALM_MK_POS_TYPE_ERR) = "Minor failure: Position reference type error"
        m_Errmsg(eErrMsg.ALM_MK_INVALID_EVENT_ERR) = "Minor failure: Illegal EVENT type"
        m_Errmsg(eErrMsg.ALM_MK_INVALID_ACTION_ERR) = "Minor failure: Illegal ACTION type"
        m_Errmsg(eErrMsg.ALM_MK_MOVE_NOT_ACTIVE) = "Minor failure: Action for Move that has not been executed"
        m_Errmsg(eErrMsg.ALM_MK_MOVELIST_NOT_ACTIVE) = "Minor failure: Action for MoveList that has not been executed"
        m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_DATA) = "Minor failure: Illegal table data"
        m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_SEG_NUM) = "Minor failure: Illegal number of table interpolation execution segments"
        m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_AXIS_NUM) = "Minor failure: Illegal number of table interpolation axes specified"
        m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_ST_SEG) = "Minor failure: Illegal table interpolation starting segment number"
        m_Errmsg(eErrMsg.ALM_MK_STBL_INVALID_EXE) = "Minor failure: Execution error during Static table file being written"
        m_Errmsg(eErrMsg.ALM_MK_DTBL_DUPLICATE_EXE) = "Minor failure: Dynamic table duplicated execution error"
        m_Errmsg(eErrMsg.ALM_MK_LATCH_CONFLICT) = "Minor failure: LATCH request overlapping instruction error"
        m_Errmsg(eErrMsg.ALM_MK_INVALID_AXISTYPE) = "Minor failure: Illegal axis type (finite length axis/inifinite length axis)"
        m_Errmsg(eErrMsg.ALM_MK_NOT_SVCRDY) = "Minor failure: Move object executed when Motion Driver operation is not ready"
        m_Errmsg(eErrMsg.ALM_MK_NOT_SVCRUN) = "Minor failure: Move object executed at servo OFF"
        m_Errmsg(eErrMsg.ALM_MK_MDALARM) = "Minor failure: Move object executed at occurrence of Motion Driver alarm"
        m_Errmsg(eErrMsg.ALM_MK_SUPERPOSE_MASTER_ERR) = "Minor failure: Distribution synthetic object master axis condition error"
        m_Errmsg(eErrMsg.ALM_MK_SUPERPOSE_SLAVE_ERR) = "Minor failure: Distribution synthetic object slave axis condition error"
        m_Errmsg(eErrMsg.ALM_MK_MDWARNING) = "Warning: Motion Driver warning"
        m_Errmsg(eErrMsg.ALM_MK_MDWARNING_POSERR) = "Warning: Motion Driver deviation warning"
        m_Errmsg(eErrMsg.ALM_MK_NOT_INFINITE_ABS) = "Minor failure: Specified axis cannot be used as ABS infinite length axis."
        m_Errmsg(eErrMsg.ALM_MK_INVALID_LOGICAL_NUM) = "Minor failure: Illegal logical axis number has been specified."
        m_Errmsg(eErrMsg.ALM_MK_MAX_VELOCITY_ERR) = "Minor failure: Maximum speed setting error"
        m_Errmsg(eErrMsg.ALM_MK_VELOCITY_ERR) = "Minor failure: Speed setting error"
        m_Errmsg(eErrMsg.ALM_MK_APPROACH_ERR) = "Minor failure: Approach speed setting error"
        m_Errmsg(eErrMsg.ALM_MK_CREEP_ERR) = "Minor failure: Creep speed setting error"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_MBOX1) = "Major failure: Mail box creation error (mail box for request for Motion Kernel Move object execution)"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_MBOX2) = "Major failure: Mail box creation error (mail box for request for Motion Kernel action execution)"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG1) = "Major failure: Message sending error at OS level (MK to EM: Notification of event detection)"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG2) = "Major failure: Message sending error at OS level (MK to MM: Move completion message)"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG3) = "Major failure: Message sending error at OS level (EM to MM: Notification of Action)"
        m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG4) = "Major failure: Message sending error at OS level (Others)"
        m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR1) = "Warning: Illegal response message received (action execution request to waiting status for response of notification of action execution completion)"
        m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR2) = "Warning: Illegal response message received(not an action for Move object currently executed)"
        m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR3) = "Warning: Illegal response message received (not an action for MoveLIST object currently executed)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG1) = "Warning: Illegal command message received (not a MOVE object handle)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG2) = "Warning: Illegal command message received (command from other than Motion Manager)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG3) = "Warning: Illegal command message received (not a command message)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG4) = "Warning: Illegal command message received (message other than command/response)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG5) = "Warning: Illegal command message received (command message from other than Event Manager)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG6) = "Warning: Illegal command message received (command message other than request for action execution)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG7) = "Warning: Illegal response message received (response message from other than Event Manager)"
        m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG8) = "Warning: Illegal response message received (response message other than event notification completion/action completion notification)"
        m_Errmsg(eErrMsg.ALM_MK_AXIS_HANDLE_ERROR) = "Minor failure: Axis handle number is incorrect."
        m_Errmsg(eErrMsg.ALM_MK_SLAVE_USED_AS_MASTER) = "Minor failure: An attempt was made to use a slave axis as a master axis."
        m_Errmsg(eErrMsg.ALM_MK_MASTER_USED_AS_SLAVE) = "Minor failure: An attempt was made to use a master axis as a slave axis."
        m_Errmsg(eErrMsg.ALM_MK_SLAVE_HAS_2_MASTERS) = "Minor failure: More than two master axes were specified for the same slave axis."
        m_Errmsg(eErrMsg.ALM_MK_SLAVE_HAS_NOT_WORK) = "Minor failure: Work axis cannot be assured for a slave axis."
        m_Errmsg(eErrMsg.ALM_MK_PARAM_OUT_OF_RANGE) = "Minor failure: Parameter is out of range."
        m_Errmsg(eErrMsg.ALM_MK_NNUM_MAX_OVER) = "Minor failure: Maximum number of averaging times exceeded"
        m_Errmsg(eErrMsg.ALM_MK_FGNTBL_INVALID) = "Minor failure: Contents of the FGN table are illegal."
        m_Errmsg(eErrMsg.ALM_MK_PARAM_OVERFLOW) = "Minor failure: Set value overflows."
        m_Errmsg(eErrMsg.ALM_MK_ALREADY_COMMANDED) = "Minor failure: CAM or GEAR has already been under execution."
        m_Errmsg(eErrMsg.ALM_MK_MULTIPLE_SHIFTS) = "Minor failure: Position Offset/Cam Shift was executed during execution of Position Offset/Cam Shift."
        m_Errmsg(eErrMsg.ALM_MK_CAMTBL_INVALID) = "Minor failure: CAM table is illegal (address, contents, etc.)."
        m_Errmsg(eErrMsg.ALM_MK_ABORTED_BY_STOPMTN) = "Minor failure: CAM/GEAR is aborted by STOP MOTION, etc."
        m_Errmsg(eErrMsg.ALM_MK_HMETHOD_INVALID) = "Minor failure: Non-supported zero point return method"
        m_Errmsg(eErrMsg.ALM_MK_MASTER_INVALID) = "Minor failure: Master axis is not specified for monitoring."
        m_Errmsg(eErrMsg.ALM_MK_DATA_HANDLE_INVALID) = "Minor failure: Register/global data handle is illegal."
        m_Errmsg(eErrMsg.ALM_MK_UNKNOWN_CAM_GEAR_ERR) = "Minor failure: Unclear error related to CAM/GEAR"
        m_Errmsg(eErrMsg.ALM_MK_REG_SIZE_INVALID) = "Minor failure: Register handle size is illegal."
        m_Errmsg(eErrMsg.ALM_MK_ACTION_HANDLE_ERROR) = "Minor failure: Action handle is illegal."
        m_Errmsg(eErrMsg.ALM_MM_OS_ERR_MBOX1) = "Major failure: Mail box creation error (mail box to start up Motion Manager)"
        m_Errmsg(eErrMsg.ALM_MM_OS_ERR_SEND_MSG1) = "Major failure: Message sending error at OS level (Motion Manager to Motion Kernel)"
        m_Errmsg(eErrMsg.ALM_MM_OS_ERR_SEND_MSG2) = "Major failure: Message sending error at OS level (Motion Manager to Event Manager)"
        m_Errmsg(eErrMsg.ALM_MM_OS_ERR_RCV_MSG1) = "Major failure: Message receiving error at OS level"
        m_Errmsg(eErrMsg.ALM_MM_MK_BUSY) = "Minor failure: All Motion Kernels are in use."
        m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG1) = "Warning: Illegal command message received (illegal handle 1: Not hMOVE.)"
        m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG2) = "Warning: Illegal command message received (illegal handle 2: hMOVE does not exist.)"
        m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG3) = "Warning: Illegal command message received (Not request for start action execution)"
        m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG4) = "Warning: Illegal response message received (response message other than event notification completion)"
        m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG5) = "Warning: Illegal response message received (Other messages received with action completion response message)"
        m_Errmsg(eErrMsg.ALM_IM_DEVICEID_ERR) = "DeviceID error or non-supported Device"
        m_Errmsg(eErrMsg.ALM_IM_REGHANDLE_ERR) = "Register handle error"
        m_Errmsg(eErrMsg.ALM_IM_GLOBALHANDLE_ERR) = "Global data handle error"
        m_Errmsg(eErrMsg.ALM_IM_DEVICETYPE_ERR) = "Non-supported data type"
        m_Errmsg(eErrMsg.ALM_IM_OFFSET_ERR) = "Incorrect offset value"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_COMMAND) = "Illegal command code"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_CMNDTYPE) = "Illegal command type"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_OBJTYPE) = "Illegal object type"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_HANDLETYPE) = "Illegal handle type"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_PKTDAT) = "Illegal packet data"
        m_Errmsg(eErrMsg.AM_ER_UNDEF_AXIS) = "axis not defined"
        m_Errmsg(eErrMsg.AM_ER_MSGBUF_GET_FAULT) = "Acquisition failure of  message buffer managed table"
        m_Errmsg(eErrMsg.AM_ER_ACTSIZE_GET_FAULT) = "Acquisition failure of ACT size"
        m_Errmsg(eErrMsg.AM_ER_APIBUF_GET_FAULT) = "Acquisition failure of API buffer managed table"
        m_Errmsg(eErrMsg.AM_ER_MOVEOBJ_GET_FAULT) = "Acquisition failure of MOVE object managed table"
        m_Errmsg(eErrMsg.AM_ER_EVTTBL_GET_FAULT) = "Acquisition failure of event managed table"
        m_Errmsg(eErrMsg.AM_ER_ACTTBL_GET_FAULT) = "Acquisition failure of Action managed table"
        m_Errmsg(eErrMsg.AM_ER_1BY1APIBUF_GET_FAULT) = "Acquisition failure of Sequence managed table"
        m_Errmsg(eErrMsg.AM_ER_AXSTBL_GET_FAULT) = "Acquisition failure of AXIS handle managed table"
        m_Errmsg(eErrMsg.AM_ER_SUPERPOSEOBJ_GET_FAULT) = "Acquisition failure of Distribution synthetic object managed table"
        m_Errmsg(eErrMsg.AM_ER_SUPERPOSEOBJ_CLEAR_FAULT) = "Deletion failure of Distribution synthetic object"
        m_Errmsg(eErrMsg.AM_ER_AXIS_IN_USE) = "axis in use"
        m_Errmsg(eErrMsg.AM_ER_HASHTBL_GET_FAULT) = "Hash table acquisition failure for axial name management"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_OBJHNDL) = "MOVE object handle mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_OBJECT) = "Object mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_APIBUF) = "API buffer mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_MSGBUF) = "Message buffer mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_ACTBUF) = "Action execution management buffer mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATH_SEQUENCE) = "Sequence number mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_1BY1APIBUF) = "Sequential API management table mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVEOBJTABLE) = "MOVE object management table mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELISTTABLE) = "MOVE LIST management table mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELIST_OBJECT) = "MOVE LIST object mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELIST_OBJHNDL) = "MOVE LIST object handle mismatched"
        m_Errmsg(eErrMsg.AM_ER_UNGET_MOVEOBJTABLE) = "MOVE object management table not assured"
        m_Errmsg(eErrMsg.AM_ER_UNGET_MOVELISTTABLE) = "MOVE LIST object management table not assured"
        m_Errmsg(eErrMsg.AM_ER_UNGET_1BY1APIBUFTABLE) = "Sequential API management table not assured"
        m_Errmsg(eErrMsg.AM_ER_NOEMPTYTBL_ERROR) = "No unused table among interpolation tables"
        m_Errmsg(eErrMsg.AM_ER_NOTGETSEM_ERROR) = "Failure to get AM-MK semaphore  (Dynamic)"
        m_Errmsg(eErrMsg.AM_ER_NOTGETTBLADD_ERROR) = "Failure to get interpolation table address"
        m_Errmsg(eErrMsg.AM_ER_NOTWRTTBL_ERROR) = "Failure to write in table at execution (Static)"
        m_Errmsg(eErrMsg.AM_ER_TBLINDEX_ERROR) = "Index setting error (Static)"
        m_Errmsg(eErrMsg.AM_ER_ILLTBLTYPE_ERROR) = "Invalid table type specified"
        m_Errmsg(eErrMsg.AM_ER_UNSUPORTED_EVENT) = "Event not supported or argument error"
        m_Errmsg(eErrMsg.AM_ER_WRONG_SEQUENCE) = "Sequence error"
        m_Errmsg(eErrMsg.AM_ER_MOVEOBJ_BUSY) = "MOVE object under execution"
        m_Errmsg(eErrMsg.AM_ER_MOVELIST_BUSY) = "MOVE LIST under execution"
        m_Errmsg(eErrMsg.AM_ER_MOVELIST_ADD_FAULT) = "MOVE OBJ cannot be registered."
        m_Errmsg(eErrMsg.AM_ER_CONFLICT_PHI_AXS) = "Physical axes overlapped"
        m_Errmsg(eErrMsg.AM_ER_CONFLICT_LOG_AXS) = "Logic axes overlapped"
        m_Errmsg(eErrMsg.AM_ER_PKTSTS_ERROR) = "Receiving packet status error"
        m_Errmsg(eErrMsg.AM_ER_CONFLICT_NAME) = "Axis name overlapped"
        m_Errmsg(eErrMsg.AM_ER_ILLEGAL_NAME) = "Incorrect axis name"
        m_Errmsg(eErrMsg.AM_ER_SEMAPHORE_ERROR) = "Incorrect semaphore at host PC interruption"
        m_Errmsg(eErrMsg.AM_ER_LOG_AXS_OVER) = "Logical axis number exceeded"
        m_Errmsg(eErrMsg.IM_STATION_ERR) = "Warning: Link communication station error"
        m_Errmsg(eErrMsg.IM_IO_ERR) = "Warning: I/O error"
        m_Errmsg(eErrMsg.MP_FILE_ERR_GENERAL) = "General error."
        m_Errmsg(eErrMsg.MP_FILE_ERR_NOT_SUPPORTED) = "Feature not supported."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_ARGUMENT) = "Invalid argument"
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_HANDLE) = "Invalid handle"
        m_Errmsg(eErrMsg.MP_FILE_ERR_NO_FILE) = "No such file (or directory)."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_PATH) = "Invalid path."
        m_Errmsg(eErrMsg.MP_FILE_ERR_EOF) = "End of file detected."
        m_Errmsg(eErrMsg.MP_FILE_ERR_PERMISSION_DENIED) = "Not arrowed to access the file."
        m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_FILES) = "Too many files opened."
        m_Errmsg(eErrMsg.MP_FILE_ERR_FILE_BUSY) = "File is in use."
        m_Errmsg(eErrMsg.MP_FILE_ERR_TIMEOUT) = "Timeout occured."
        m_Errmsg(eErrMsg.MP_FILE_ERR_BAD_FS) = "Invalid or unexepected logical filesystem in the mediu"
        m_Errmsg(eErrMsg.MP_FILE_ERR_FILESYSTEM_FULL) = "LFS (ie the media) is full."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_LFM) = "Invalid LFM specified."
        m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_LFM) = "LFM table is full."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_PDM) = "Invalid PDM specified."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_MEDIA) = "Invalid media specified."
        m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_PDM) = "Too many PDM."
        m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_MEDIA) = "Too many media."
        m_Errmsg(eErrMsg.MP_FILE_ERR_WRITE_PROTECTED) = "Write protected media."
        m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_DEVICE) = "Invalid device specified."
        m_Errmsg(eErrMsg.MP_FILE_ERR_DEVICE_IO) = "Error occured in accessing the device."
        m_Errmsg(eErrMsg.MP_FILE_ERR_DEVICE_BUSY) = "Device is in use."
        m_Errmsg(eErrMsg.MP_FILE_ERR_NO_CARD) = "CF CARD not mounted."
        m_Errmsg(eErrMsg.MP_FILE_ERR_CARD_POWER) = "CF CARD Power-OFF."
        m_Errmsg(eErrMsg.MP_CARD_SYSTEM_ERR) = "Card System Error."
        m_Errmsg(eErrMsg.ERROR_CODE_GET_DIREC_OFFSET) = "Directory area offset cannot be got."
        m_Errmsg(eErrMsg.ERROR_CODE_GET_DIREC_INFO) = "Directory area offset cannot be got."
        m_Errmsg(eErrMsg.ERROR_CODE_FUNC_TABLE) = "Failure to get directory information"
        m_Errmsg(eErrMsg.ERROR_CODE_SLEEP_TASK) = "Failure to get system call function table"
        m_Errmsg(eErrMsg.ERROR_CODE_DEVICE_HANDLE_FULL) = "Sleep error"
        m_Errmsg(eErrMsg.ERROR_CODE_ALLOC_MEMORY) = "Number of device handles exceeds the maximum value."
        m_Errmsg(eErrMsg.ERROR_CODE_BUFCOPY) = "Failure to get the area."
        m_Errmsg(eErrMsg.ERROR_CODE_GET_COMMEM_OFFSET) = "MemoryCopy(),name_copy() error"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_SEMPH) = "Failure to get common memory offset value"
        m_Errmsg(eErrMsg.ERROR_CODE_DELETE_SEMPH) = "Semaphore creation error"
        m_Errmsg(eErrMsg.ERROR_CODE_LOCK_SEMPH) = "Semaphore deletion error"
        m_Errmsg(eErrMsg.ERROR_CODE_UNLOCK_SEMPH) = "Error at semaphore lock"
        m_Errmsg(eErrMsg.ERROR_CODE_PACKETSIZE_OVER) = "Error at semaphore release"
        m_Errmsg(eErrMsg.ERROR_CODE_UNREADY) = " Error when controller is being initialized"
        m_Errmsg(eErrMsg.ERROR_CODE_CPUSTOP) = " Error when CPU is stopping"
        m_Errmsg(eErrMsg.ERROR_CODE_CNTRNO) = " CPU number is illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_SELECTION) = "Device number"
        m_Errmsg(eErrMsg.ERROR_CODE_LENGTH) = "Illegal selected value (0 or 1)"
        m_Errmsg(eErrMsg.ERROR_CODE_OFFSET) = "Data length"
        m_Errmsg(eErrMsg.ERROR_CODE_DATACOUNT) = "Offset value"
        m_Errmsg(eErrMsg.ERROR_CODE_DATREAD) = "Number of data items"
        m_Errmsg(eErrMsg.ERROR_CODE_DATWRITE) = "Failure to read out from common memory"
        m_Errmsg(eErrMsg.ERROR_CODE_BITWRITE) = "Failure to write in to common memory"
        m_Errmsg(eErrMsg.ERROR_CODE_DEVCNTR) = "Failure to write in bit data to common memory"
        m_Errmsg(eErrMsg.ERROR_CODE_NOTINIT) = "DeviceIoControl() completed erroneously."
        m_Errmsg(eErrMsg.ERROR_CODE_SEMPHLOCK) = "Driver initialization error"
        m_Errmsg(eErrMsg.ERROR_CODE_SEMPHUNLOCK) = "Packet sending semaphore locked"
        m_Errmsg(eErrMsg.ERROR_CODE_DRV_PROC) = "Packet receiving semaphore not locked"
        m_Errmsg(eErrMsg.ERROR_CODE_GET_DRIVER_HANDLE) = "Driver processing completed erroneously."
        m_Errmsg(eErrMsg.ERROR_CODE_SEND_MSG) = "Failure to get driver file handle"
        m_Errmsg(eErrMsg.ERROR_CODE_RECV_MSG) = "Message sending error"
        m_Errmsg(eErrMsg.ERROR_CODE_INVALID_RESPONSE) = "Message receiving error"
        m_Errmsg(eErrMsg.ERROR_CODE_INVALID_ID) = "Receiving packet illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_INVALID_STATUS) = "Receiving packet ID illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_INVALID_CMDCODE) = "Receiving packet status illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_INVALID_SEQNO) = "Receiving packet command code illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_SEND_RETRY_OVER) = "Receiving packet sequence number illegal"
        m_Errmsg(eErrMsg.ERROR_CODE_RECV_RETRY_OVER) = "Number of retries exceeded (packet sending)"
        m_Errmsg(eErrMsg.ERROR_CODE_RESPONSE_TIMEOUT) = "Number of retries exceeded (packet receiving)"
        m_Errmsg(eErrMsg.ERROR_CODE_WAIT_FOR_EVENT) = "Response waiting timeout error"
        m_Errmsg(eErrMsg.ERROR_CODE_EVENT_OPEN) = "Event waiting error"
        m_Errmsg(eErrMsg.ERROR_CODE_EVENT_RESET) = "Failure to open event"
        m_Errmsg(eErrMsg.ERROR_CODE_EVENT_READY) = "Failure to reset event"
        m_Errmsg(eErrMsg.ERROR_CODE_PROCESSNUM) = "Failure to prepare for waiting for event"
        m_Errmsg(eErrMsg.ERROR_CODE_GET_PROC_INFO) = "Number of processes exceeded"
        m_Errmsg(eErrMsg.ERROR_CODE_THREADNUM) = "Process information getting error"
        m_Errmsg(eErrMsg.ERROR_CODE_GET_THRD_INFO) = "Number of threads exceeded"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_MBOX) = "Thread information getting error"
        m_Errmsg(eErrMsg.ERROR_CODE_DELETE_MBOX) = "Mail box creation error"
        m_Errmsg(eErrMsg.ERROR_CODE_GET_TASKID) = "Mail box deletion error"
        m_Errmsg(eErrMsg.ERROR_CODE_NO_THREADINFO) = "Failure to get task ID"
        m_Errmsg(eErrMsg.ERROR_CODE_COM_INITIALIZE) = "Specified thread information does not exist."
        m_Errmsg(eErrMsg.ERROR_CODE_COMDEVICENUM) = "COM initialization error"
        m_Errmsg(eErrMsg.ERROR_CODE_GET_COM_DEVICE_HANDLE) = "Number of ComDevice exceeded"
        m_Errmsg(eErrMsg.ERROR_CODE_COM_DEVICE_FULL) = "Failure to get ComDevice information structure"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_PANELOBJ) = "ComDevice exceeds the maximum number."
        m_Errmsg(eErrMsg.ERROR_CODE_OPEN_PANELOBJ) = "Failure to create panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_CLOSE_PANELOBJ) = "Failure to open panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_PROC_PANELOBJ) = "Failure to close panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_CNTROBJ) = "Failure to process panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_OPEN_CNTROBJ) = "Failure to create panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_CLOSE_CNTROBJ) = "Failure to open panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_PROC_CNTROBJ) = "Failure to close panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_COMDEV_MUTEX) = "Failure to process panel command object"
        m_Errmsg(eErrMsg.ERROR_CODE_CREATE_COMDEV_MAPFILE) = "Failure to create Mutex for ComDevice table"
        m_Errmsg(eErrMsg.ERROR_CODE_OPEN_COMDEV_MAPFILE) = "Failure to create MapFile for ComDevice table"
        m_Errmsg(eErrMsg.ERROR_CODE_NOT_OBJECT_TYPE) = "Failure to open MapFile for ComDevice table"
        m_Errmsg(eErrMsg.ERROR_CODE_COM_NOT_OPENED) = "Object type error"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_CPU_CONTROL) = "Not opened"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_SFILE_READ) = "CPU control error"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_SFILE_WRITE) = "Failure to read out source file"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_REGISTER_READ) = "Failure to write in source file"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_REGISTER_WRITE) = "Failure to read out register"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_API_SEND) = "Failure to write in register"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_API_RECV) = "API Send command error"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_NO_RESPONSE) = "API Recv command error"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_PACKET_READ) = "No response packet is received at API Recv."
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_PACKET_WRITE) = "Failure to read packet"
        m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_STATUS_READ) = "Failure to write packet"
        m_Errmsg(eErrMsg.ERROR_CODE_NOT_CONTROLLER_RDY) = ""
        m_Errmsg(eErrMsg.ERROR_CODE_DOUBLE_CMD) = ""
        m_Errmsg(eErrMsg.ERROR_CODE_DOUBLE_RCMD) = ""
        m_Errmsg(eErrMsg.ERROR_CODE_FILE_NOT_OPENED) = "Failure to read status"
        m_Errmsg(eErrMsg.ERROR_CODE_OPENFILE_NUM) = "File is not opened."
        m_Errmsg(eErrMsg.MP_CTRL_SYS_ERROR) = ""
        m_Errmsg(eErrMsg.MP_CTRL_PARAM_ERR) = ""
        m_Errmsg(eErrMsg.MP_CTRL_FILE_NOT_FOUND) = ""
        m_Errmsg(eErrMsg.MP_NOTMOVEHANDLE) = "Undefined Move handle"
        m_Errmsg(eErrMsg.MP_NOTTIMERHANDLE) = "Undefined timer handle"
        m_Errmsg(eErrMsg.MP_NOTINTERRUPT) = "Undefined virtual interruption number"
        m_Errmsg(eErrMsg.MP_NOTEVENTHANDLE) = "Undefined event handle"
        m_Errmsg(eErrMsg.MP_NOTMESSAGEHANDLE) = "Undefined message handle"
        m_Errmsg(eErrMsg.MP_NOTUSERFUNCTIONHANDLE) = "Undefined user function handle"
        m_Errmsg(eErrMsg.MP_NOTACTIONHANDLE) = "Undefined action handle"
        m_Errmsg(eErrMsg.MP_NOTSUBSCRIBEHANDLE) = "Undefined Subscribe handle"
        m_Errmsg(eErrMsg.MP_NOTDEVICEHANDLE) = "Undefined device handle"
        m_Errmsg(eErrMsg.MP_NOTAXISHANDLE) = "Undefined axis handle"
        m_Errmsg(eErrMsg.MP_NOTMOVELISTHANDLE) = "Undefined MoveList handle"
        m_Errmsg(eErrMsg.MP_NOTTRACEHANDLE) = "Undefined Trace handle"
        m_Errmsg(eErrMsg.MP_NOTGLOBALDATAHANDLE) = "Undefined global data handle"
        m_Errmsg(eErrMsg.MP_NOTSUPERPOSEHANDLE) = "Undefined Superpose handle"
        m_Errmsg(eErrMsg.MP_NOTCONTROLLERHANDLE) = "Undefined Controller handle"
        m_Errmsg(eErrMsg.MP_NOTFILEHANDLE) = "Undefined file handle"
        m_Errmsg(eErrMsg.MP_NOTREGISTERDATAHANDLE) = "Undefined register handle"
        m_Errmsg(eErrMsg.MP_NOTALARMHANDLE) = "Undefined alarm handle"
        m_Errmsg(eErrMsg.MP_NOTCAMHANDLE) = "Undefined CAM handle"
        m_Errmsg(eErrMsg.MP_NOTHANDLE) = "Undefined handle"
        m_Errmsg(eErrMsg.MP_NOTEVENTTYPE) = "Undefined event type"
        m_Errmsg(eErrMsg.MP_NOTDEVICETYPE) = "Undefined device type"
        m_Errmsg(eErrMsg.MP_NOTDATAUNITSIZE) = "Undefined unit data size"
        m_Errmsg(eErrMsg.MP_NOTDEVICE) = "Undefined device"
        m_Errmsg(eErrMsg.MP_NOTACTIONTYPE) = "Undefined action type"
        m_Errmsg(eErrMsg.MP_NOTPARAMNAME) = "Undefined parameter name"
        m_Errmsg(eErrMsg.MP_NOTDATATYPE) = "Undefined data type"
        m_Errmsg(eErrMsg.MP_NOTBUFFERTYPE) = "Undefined buffer type"
        m_Errmsg(eErrMsg.MP_NOTMOVETYPE) = "Undefined Move type"
        m_Errmsg(eErrMsg.MP_NOTANGLETYPE) = "Undefined Angle type"
        m_Errmsg(eErrMsg.MP_NOTDIRECTION) = "Undefined rotating direction"
        m_Errmsg(eErrMsg.MP_NOTAXISTYPE) = "Undefined axis type"
        m_Errmsg(eErrMsg.MP_NOTUNITTYPE) = "Undefined unit type"
        m_Errmsg(eErrMsg.MP_NOTCOMDEVICETYPE) = "Undefined ComDevice type"
        m_Errmsg(eErrMsg.MP_NOTCONTROLTYPE) = "Undefined Control type"
        m_Errmsg(eErrMsg.MP_NOTFILETYPE) = "Undefined file type"
        m_Errmsg(eErrMsg.MP_NOTSEMAPHORETYPE) = "Undefined semaphore type"
        m_Errmsg(eErrMsg.MP_NOTSYSTEMOPTION) = "Undefined system option"
        m_Errmsg(eErrMsg.MP_TIMEOUT_ERR) = "Timeout error"
        m_Errmsg(eErrMsg.MP_TIMEOUT) = "Timeout"
        m_Errmsg(eErrMsg.MP_NOTSUBSCRIBETYPE) = "Undefined scan type"
        m_Errmsg(eErrMsg.MP_NOTSCANTYPE) = "Undefined scan type"
        m_Errmsg(eErrMsg.MP_DEVICEOFFSETOVER) = "Out-of-range device offset"
        m_Errmsg(eErrMsg.MP_DEVICEBITOFFSETOVER) = "Out-of-range bit offset"
        m_Errmsg(eErrMsg.MP_UNITCOUNTOVER) = "Out-of-range quantity"
        m_Errmsg(eErrMsg.MP_COMPAREVALUEOVER) = "Out-of-range compared value"
        m_Errmsg(eErrMsg.MP_FCOMPAREVALUEOVER) = "Out-of-range floating-point compared value"
        m_Errmsg(eErrMsg.MP_EVENTCOUNTOVER) = "Out-of-range virtual interruption number"
        m_Errmsg(eErrMsg.MP_VALUEOVER) = "Out-of-range value"
        m_Errmsg(eErrMsg.MP_FVALUEOVER) = "Out-of-range floating point"
        m_Errmsg(eErrMsg.MP_PSTOREDVALUEOVER) = "Out-of-range storage position pointer"
        m_Errmsg(eErrMsg.MP_PSTOREDFVALUEOVER) = "Out-of-range storage position pointer (floating decimal point value)"
        m_Errmsg(eErrMsg.MP_SIZEOVER) = "Out-of-range size"
        m_Errmsg(eErrMsg.MP_RECEIVETIMEROVER) = "Out-of-range waiting time value for receiving"
        m_Errmsg(eErrMsg.MP_RECNUMOVER) = "Out-of-range number of records (MoveList)"
        m_Errmsg(eErrMsg.MP_PARAMOVER) = "Out-of-range parameter"
        m_Errmsg(eErrMsg.MP_FRAMEOVER) = "Out-of-range number of frames"
        m_Errmsg(eErrMsg.MP_RADIUSOVER) = "Out-of-range radius"
        m_Errmsg(eErrMsg.MP_CONTROLLERNOOVER) = "Out-of-range device number"
        m_Errmsg(eErrMsg.MP_AXISNUMOVER) = "Out-of-range number of axes"
        m_Errmsg(eErrMsg.MP_DIGITOVER) = "Out-of-range number of digits"
        m_Errmsg(eErrMsg.MP_CALENDARVALUEOVER) = "Out-of-range calendar data"
        m_Errmsg(eErrMsg.MP_OFFSETOVER) = "Out-of-range offset"
        m_Errmsg(eErrMsg.MP_NUMBEROVER) = "Out-of-range number of registers has been specified."
        m_Errmsg(eErrMsg.MP_RACKOVER) = "Out-of-range rack number has been specified."
        m_Errmsg(eErrMsg.MP_SLOTOVER) = "Out-of-range slot number has been specified."
        m_Errmsg(eErrMsg.MP_FIXVALUEOVER) = "Fixed decimal point type data has been out of range."
        m_Errmsg(eErrMsg.MP_REGISTERINFOROVER) = "Out-of-range number of register infomation has been specified."
        m_Errmsg(eErrMsg.PC_MEMORY_ERR) = "PC memory shortage"
        m_Errmsg(eErrMsg.MP_NOCOMMUDEVICETYPE) = "Communication device type specification error"
        m_Errmsg(eErrMsg.MP_NOTPROTOCOLTYPE) = "Invalid protocol type"
        m_Errmsg(eErrMsg.MP_NOTFUNCMODE) = "Invalid function mode"
        m_Errmsg(eErrMsg.MP_MYADDROVER) = "Out-of-range local station address has been set."
        m_Errmsg(eErrMsg.MP_NOTPORTTYPE) = "Invalid port type"
        m_Errmsg(eErrMsg.MP_NOTPROTMODE) = "Invalid protocol mode"
        m_Errmsg(eErrMsg.MP_NOTCHARSIZE) = "Invalid character bit length"
        m_Errmsg(eErrMsg.MP_NOTPARITYBIT) = "Invalid parity bit"
        m_Errmsg(eErrMsg.MP_NOTSTOPBIT) = "Invalid stop bit"
        m_Errmsg(eErrMsg.MP_NOTBAUDRAT) = "Invalid transmission speed"
        m_Errmsg(eErrMsg.MP_TRANSDELAYOVER) = "Out-of-range sending delay has been specified."
        m_Errmsg(eErrMsg.MP_PEERADDROVER) = "Out-of-range remote station address has been specified."
        m_Errmsg(eErrMsg.MP_SUBNETMASKOVER) = "Out-of-range subnet mask has been specified."
        m_Errmsg(eErrMsg.MP_GWADDROVER) = "Out-of-range GW address has been specified."
        m_Errmsg(eErrMsg.MP_DIAGPORTOVER) = "Out-of-range diagnostic port has been specified."
        m_Errmsg(eErrMsg.MP_PROCRETRYOVER) = "Out-of-range number of retries has been specified."
        m_Errmsg(eErrMsg.MP_TCPZEROWINOVER) = "Out-of-range TCP zero window timer"
        m_Errmsg(eErrMsg.MP_TCPRETRYOVER) = "Out-of-range TCP resending timer value"
        m_Errmsg(eErrMsg.MP_TCPFINOVER) = "Out-of-range completion timer value"
        m_Errmsg(eErrMsg.MP_IPASSEMBLEOVER) = "Out-of-range IP incorporating timer value"
        m_Errmsg(eErrMsg.MP_MAXPKTLENOVER) = "Out-of-range maximum packet length"
        m_Errmsg(eErrMsg.MP_PEERPORTOVER) = "Out-of-range remote station port"
        m_Errmsg(eErrMsg.MP_MYPORTOVER) = "Out-of-range local station port"
        m_Errmsg(eErrMsg.MP_NOTTRANSPROT) = "Invalid transport layer protocol"
        m_Errmsg(eErrMsg.MP_NOTAPPROT) = "Invalid application layer protocol"
        m_Errmsg(eErrMsg.MP_NOTCODETYPE) = "Invalid code type"
        m_Errmsg(eErrMsg.MP_CYCTIMOVER) = "Out-of-range communication cycle has been specified."
        m_Errmsg(eErrMsg.MP_NOTIOMAPCOM) = "Invalid I/O commands"
        m_Errmsg(eErrMsg.MP_NOTIOTYPE) = "Invalid I/O type specification"
        m_Errmsg(eErrMsg.MP_IOOFFSETOVER) = "Out-of-range I/O offset has been allocated."
        m_Errmsg(eErrMsg.MP_IOSIZEOVER) = "Out-of-range I/O size has been allocated (individualy)."
        m_Errmsg(eErrMsg.MP_TIOSIZEOVER) = "Out-of-range I/O size has been allocated (total)."
        m_Errmsg(eErrMsg.MP_MEMORY_ERR) = "Controller memory shortage"
        m_Errmsg(eErrMsg.MP_NOTPTR) = "Invalid pointer (communication device specification structure/device inherent information/pointer error to objective communication device handle)"
        m_Errmsg(eErrMsg.MP_TABLEOVER) = "Event detection table resource cannot be got."
        m_Errmsg(eErrMsg.MP_ALARM) = "Alarm has occurred."
        m_Errmsg(eErrMsg.MP_MEMORYOVER) = "Memory resource cannot be got."
        m_Errmsg(eErrMsg.MP_EXEC_ERR) = "System execution error"
        m_Errmsg(eErrMsg.MP_NOTLOGICALAXIS) = "Logical axis number error"
        m_Errmsg(eErrMsg.MP_NOTSUPPORTED) = "Not supported"
        m_Errmsg(eErrMsg.MP_ILLTEXT) = "Out-of-range length of character string was input."
        m_Errmsg(eErrMsg.MP_NOFILENAME) = "File name has not been set."
        m_Errmsg(eErrMsg.MP_NOTREGSTERNAME) = "Specified register data name cannot be found."
        m_Errmsg(eErrMsg.MP_FILEALREADYOPEN) = "The same file has already been opened."
        m_Errmsg(eErrMsg.MP_NOFILEPACKET) = "Specified source file packet cannot be found."
        m_Errmsg(eErrMsg.MP_NOTFILEPACKETSIZE) = "Source file packet size is incorrect."
        m_Errmsg(eErrMsg.MP_NOTUSERFUNCTION) = "Specified user funtion does not exist."
        m_Errmsg(eErrMsg.MP_NOTPARAMETERTYPE) = "Specified parameter type does not exist."
        m_Errmsg(eErrMsg.MP_ILLREGHANDLETYPE) = "Erroneous register handle type specified."
        m_Errmsg(eErrMsg.MP_ILLREGTYPE) = "Erroneous register type specified."
        m_Errmsg(eErrMsg.MP_ILLREGSIZE) = "Erroneous register size specified.(other than WORD)"
        m_Errmsg(eErrMsg.MP_REGNUMOVER) = "Out-of-range register"
        m_Errmsg(eErrMsg.MP_RELEASEWAIT) = "Waiting status released"
        m_Errmsg(eErrMsg.MP_PRIORITYOVER) = "Priority that can not be set"
        m_Errmsg(eErrMsg.MP_NOTCHANGEPRIORITY) = "Priority that cannot be changed"
        m_Errmsg(eErrMsg.MP_SEMAPHOREOVER) = "Semaphore definition over"
        m_Errmsg(eErrMsg.MP_NOTSEMAPHOREHANDLE) = "Undefined semaphore handle specification"
        m_Errmsg(eErrMsg.MP_SEMAPHORELOCKED) = "Specified semaphore handle being locked"
        m_Errmsg(eErrMsg.MP_CONTINUE_RELEASEWAIT) = "Waiting status released during ymcContinueWaitForCompletion"
        m_Errmsg(eErrMsg.MP_NOTTABLENAME) = "Undefined Table name"
        m_Errmsg(eErrMsg.MP_ILLTABLETYPE) = "Illegal Table Type"
        m_Errmsg(eErrMsg.MP_TIMEOUTVALUEOVER) = "Out-of-range timeout value has been specified"
        m_Errmsg(eErrMsg.MP_OTHER_ERR) = "Other errors"
    End Sub
#End Region
#Region "Member"
    Private m_Axis() As CAxisBased
    Private Shared m_Errmsg(0 To 434) As String
#End Region
#Region "Property"
#End Region

#Region "Events"

#End Region
#Region "Methods"
    Friend Function ChkMultiStop(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) As enumMotionFlag Implements IPseudoMotion.ChkMultiStop
        ChkMultiStop = enumMotionFlag.eNotReady
        If m_Axis(AxisID1).Status.MoveRdy Then
            If m_Axis(AxisID2).Status.MoveRdy Then
                ChkMultiStop = m_Axis(AxisID1).Status.MoveRdy
            End If
        End If
    End Function
    Friend Sub ChkMutiStatus(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer) Implements IPseudoMotion.ChkMutiStatus

    End Sub
    Friend Function ChkPreRegisterEmpty(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkPreRegisterEmpty
        Return enumMotionFlag.eReady
    End Function
    Friend Sub ChkStatus(ByVal AxisID As Integer) Implements IPseudoMotion.ChkStatus

    End Sub



    Friend Function ChkStop(ByVal AxisID As Integer) As enumMotionFlag Implements IPseudoMotion.ChkStop
        ChkStop = m_Axis(AxisID).Status.MoveRdy
    End Function
    Friend Sub ChkSwLimit(ByVal AxisID As Integer, ByVal Target As Double, ByRef pStatus As enumMotionFlag) Implements IPseudoMotion.ChkSwLimit
        pStatus = enumMotionFlag.eHigh
    End Sub
    Friend Sub Close() Implements IPseudoMotion.Close

    End Sub


    Friend Sub LaserON()
        'Dim rc As Integer          '// Motion API return value
        ''// Definition of motion API variables
        'Dim hRegister_ML As Int32                '// Register data handle for ML register
        'Dim hRegister_MB As Int32                '// Register data handle for MB register
        'Dim hRegister_OB As Int32                '// Register data handle for OB register
        'Dim cRegisterName_ML As String        '// ML register name storage variable
        'Dim cRegisterName_MB As String        '// MB register name storage variable
        'Dim cRegisterName_OB As String          '// OB register name storage variable
        'Dim RegisterDataNumber As Int32         '// Number of read-in register
        'Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
        'Dim Reg_LongData(2) As Int32           '// L size register data storage variable
        'Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        'Dim controllerhandle As Integer
        'Dim devicehandle As Integer
        'Try
        '    comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
        '    comDevice.PortNumber = 1
        '    comDevice.CpuNumber = 1
        '    comDevice.NetworkNumber = 0
        '    comDevice.StationNumber = 0
        '    comDevice.UnitNumber = 0
        '    comDevice.IPAddress = 0
        '    comDevice.Timeout = 10000
        '    rc = ymcOpenController(comDevice, controllerhandle)
        '    If rc = MP_SUCCESS Then

        '        'Function Close
        '        '// MB Register
        '        cRegisterName_ML = "ML" & "00000"
        '        '// MB Register
        '        rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If
        '        '// MB Register
        '        Reg_LongData(0) = 2
        '        RegisterDataNumber = 1
        '        rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If


        '        'Output IO 0
        '        '// OB Register
        '        cRegisterName_OB = "OB" & "00010"
        '        '// OB Register
        '        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If
        '        '// OB Register
        '        Reg_ShortData(0) = 1
        '        RegisterDataNumber = 1
        '        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If







        '        'Function Close
        '        '// MB Register
        '        cRegisterName_MB = "MB" & "000300"
        '        '// MB Register
        '        rc = ymcGetRegisterDataHandle(cRegisterName_MB, hRegister_MB)
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If
        '        '// MB Register
        '        Reg_ShortData(0) = 0
        '        RegisterDataNumber = 1
        '        rc = ymcSetRegisterData(hRegister_MB, RegisterDataNumber, Reg_ShortData(0))
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If

        '        'Output IO 0
        '        '// OB Register
        '        cRegisterName_OB = "OB" & "00010"
        '        '// OB Register
        '        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If
        '        '// OB Register
        '        Reg_ShortData(0) = 1
        '        RegisterDataNumber = 1
        '        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
        '        If rc <> MP_SUCCESS Then
        '            MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
        '            Exit Sub
        '        End If
        '    Else
        '        Call ymcCloseController(controllerhandle)
        '        Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
        '    End If
        'Catch ex As Exception
        'Finally
        'End Try
    End Sub
    Friend Sub LaserOFF()
        Dim rc As Integer          '// Motion API return value
        '// Definition of motion API variables
        Dim hRegister_ML As Int32                '// Register data handle for ML register
        Dim hRegister_MB As Int32                '// Register data handle for MB register
        Dim hRegister_OB As Int32                '// Register data handle for OB register
        Dim cRegisterName_ML As String        '// ML register name storage variable
        Dim cRegisterName_MB As String        '// MB register name storage variable
        Dim cRegisterName_OB As String          '// OB register name storage variable
        Dim RegisterDataNumber As Int32         '// Number of read-in register
        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Try
            comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
            comDevice.PortNumber = 1
            comDevice.CpuNumber = 1
            comDevice.NetworkNumber = 0
            comDevice.StationNumber = 0
            comDevice.UnitNumber = 0
            comDevice.IPAddress = 0
            comDevice.Timeout = 10000
            rc = ymcOpenController(comDevice, controllerhandle)
            If rc = MP_SUCCESS Then
                'Function Close
                '// MB Register
                cRegisterName_ML = "ML" & "00000"
                '// MB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// MB Register
                Reg_LongData(0) = 0
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
            Else
                Call ymcCloseController(controllerhandle)
                Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub ConfigCompare(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal StartPos1 As Double, ByVal EndPos1 As Double, ByVal StartPos2 As Double, ByVal EndPos2 As Double)
        Dim rc As Integer          '// Motion API return value
        '// Definition of motion API variables
        Dim hRegister_ML As Int32                '// Register data handle for ML register
        Dim hRegister_MB As Int32                '// Register data handle for MB register
        Dim hRegister_OB As Int32                '// Register data handle for OB register
        Dim cRegisterName_ML As String        '// ML register name storage variable
        Dim cRegisterName_MB As String        '// MB register name storage variable
        Dim cRegisterName_OB As String          '// OB register name storage variable
        Dim RegisterDataNumber As Int32         '// Number of read-in register
        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Try
            comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
            comDevice.PortNumber = 1
            comDevice.CpuNumber = 1
            comDevice.NetworkNumber = 0
            comDevice.StationNumber = 0
            comDevice.UnitNumber = 0
            comDevice.IPAddress = 0
            comDevice.Timeout = 10000

            rc = ymcOpenController(comDevice, controllerhandle)
            If rc = MP_SUCCESS Then
                'Output IO 0
                '// OB Register
                cRegisterName_OB = "OB" & "00010"
                '// OB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// OB Register
                Reg_ShortData(0) = 0
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Axis X start
                '// ML Register
                cRegisterName_ML = "ML" & "00100"
                '// ML Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// ML Register
                Reg_LongData(0) = CInt(StartPos1)
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Axis X end
                '// ML Register
                cRegisterName_ML = "ML" & "00102"
                '// ML Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// ML Register
                Reg_LongData(0) = CInt(EndPos1)
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Axis Y start
                '// ML Register
                cRegisterName_ML = "ML" & "00200"
                '// ML Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// ML Register
                Reg_LongData(0) = CInt(StartPos2)
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Axis Y end
                '// ML Register
                cRegisterName_ML = "ML" & "00202"
                '// ML Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// ML Register
                Reg_LongData(0) = CInt(EndPos2)
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Function Close
                '// MB Register
                cRegisterName_ML = "ML" & "00000"
                '// MB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// MB Register
                Reg_LongData(0) = 1
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
            Else
                Call ymcCloseController(controllerhandle)
                Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
        Finally
        End Try
    End Sub
    Friend Sub ConfigCompare(ByVal AxisID1 As Integer, ByVal CircleCnt As Integer)
        Dim rc As Integer          '// Motion API return value
        '// Definition of motion API variables
        Dim hRegister_ML As Int32                '// Register data handle for ML register
        Dim hRegister_MB As Int32                '// Register data handle for MB register
        Dim hRegister_OB As Int32                '// Register data handle for OB register
        Dim cRegisterName_ML As String        '// ML register name storage variable
        Dim cRegisterName_MB As String        '// MB register name storage variable
        Dim cRegisterName_OB As String          '// OB register name storage variable
        Dim RegisterDataNumber As Int32         '// Number of read-in register
        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Try
            comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
            comDevice.PortNumber = 1
            comDevice.CpuNumber = 1
            comDevice.NetworkNumber = 0
            comDevice.StationNumber = 0
            comDevice.UnitNumber = 0
            comDevice.IPAddress = 0
            comDevice.Timeout = 10000

            rc = ymcOpenController(comDevice, controllerhandle)
            If rc = MP_SUCCESS Then
                'Circle Count
                '// MB Register
                cRegisterName_ML = "ML" & "00300"
                '// MB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// MB Register
                Reg_LongData(0) = CircleCnt
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Function Close
                '// MB Register
                cRegisterName_ML = "ML" & "00000"
                '// MB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// MB Register
                Reg_LongData(0) = 2
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
            Else
                Call ymcCloseController(controllerhandle)
                Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
        Finally
        End Try
    End Sub
    Friend Sub CloseCompare()
        Dim rc As Integer          '// Motion API return value
        '// Definition of motion API variables
        Dim hRegister_ML As Int32                '// Register data handle for ML register
        Dim hRegister_MB As Int32                '// Register data handle for MB register
        Dim hRegister_OB As Int32                '// Register data handle for OB register
        Dim cRegisterName_ML As String        '// ML register name storage variable
        Dim cRegisterName_MB As String        '// MB register name storage variable
        Dim cRegisterName_OB As String          '// OB register name storage variable
        Dim RegisterDataNumber As Int32         '// Number of read-in register
        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Try
            comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
            comDevice.PortNumber = 1
            comDevice.CpuNumber = 1
            comDevice.NetworkNumber = 0
            comDevice.StationNumber = 0
            comDevice.UnitNumber = 0
            comDevice.IPAddress = 0
            comDevice.Timeout = 10000

            rc = ymcOpenController(comDevice, controllerhandle)
            If rc = MP_SUCCESS Then
                'Output IO 0
                '// OB Register
                cRegisterName_OB = "OB" & "00010"
                '// OB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// OB Register
                Reg_ShortData(0) = 0
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                'Function Close
                '// MB Register
                cRegisterName_ML = "ML" & "00000"
                '// MB Register
                rc = ymcGetRegisterDataHandle(cRegisterName_ML, hRegister_ML)
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcGetRegisterDataHandle" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
                '// MB Register
                Reg_LongData(0) = 0
                RegisterDataNumber = 1
                rc = ymcSetRegisterData(hRegister_ML, RegisterDataNumber, Reg_LongData(0))
                If rc <> MP_SUCCESS Then
                    MsgBox("Error ymcSetRegisterData" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                    Exit Sub
                End If
            Else
                Call ymcCloseController(controllerhandle)
                Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Friend Sub EmgStop(ByVal AxisID As Integer) Implements IPseudoMotion.EmgStop
    End Sub
    Friend Sub GetCmd(ByVal AxisID As Integer, ByRef pCmd As Double) Implements IPseudoMotion.GetCmd
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim pStoredValue As Integer
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        With m_Axis(AxisID)
            Try
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000

                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    If Not .Mode.IsServo Then
                        '// Definition of motion API variables
                        Dim hRegister_OB As Int32                '// Register data handle for OB register
                        Dim cRegisterName_OB As String          '// OB register name storage variable
                        Dim RegisterDataNumber As Int32         '// Number of read-in register
                        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
                        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
                        Dim ReadDataNumber As Int32         '// Storing the number of read-in registers
                        '// OB Register
                        cRegisterName_OB = "IL" & "0014"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        RegisterDataNumber = 1
                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        pCmd = Reg_ShortData(0)
                        pCmd = pCmd / .Param.SwScale
                    Else
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            rc = ymcGetMotionParameterValue(.ThreadID, CShort(ApiDefs.MONITOR_PARAMETER), eParameterNo.MPOS, pStoredValue)
                            If rc = MP_SUCCESS Then
                                pCmd = pStoredValue
                                pCmd = pCmd / .Param.SwScale
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcGetMotionParameterValue" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            End Try
        End With
    End Sub
    Friend Sub GetEncoder(ByVal AxisID As Integer, ByRef pEncoder As Double) Implements IPseudoMotion.GetEncoder
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim pStoredValue As Integer
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        With m_Axis(AxisID)
            Try
                'If m_MoveRdy Then
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000

                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    If Not .Mode.IsServo Then
                        '// Definition of motion API variables
                        Dim hRegister_OB As Int32                '// Register data handle for OB register
                        Dim cRegisterName_OB As String          '// OB register name storage variable
                        Dim RegisterDataNumber As Int32         '// Number of read-in register
                        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
                        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
                        Dim ReadDataNumber As Int32         '// Storing the number of read-in registers
                        '// OB Register
                        cRegisterName_OB = "IL" & "0014"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        RegisterDataNumber = 1
                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        pEncoder = Reg_ShortData(0)
                        pEncoder = pEncoder / .Param.SwScale
                    Else
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            rc = ymcGetMotionParameterValue(.ThreadID, CShort(ApiDefs.MONITOR_PARAMETER), eParameterNo.APOS, pStoredValue)
                            If rc = MP_SUCCESS Then
                                pEncoder = pStoredValue
                                pEncoder = pEncoder / .Param.SwScale
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcGetMotionParameterValue" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            End Try
        End With
    End Sub
    Private Function GetErrMsg(ByVal Idx As Int32) As String
        Try
            Select Case Idx
                Case MP_SUCCESS
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SUCCESS)
                Case MP_FAIL
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FAIL)
                Case WDT_OVER_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.WDT_OVER_ERR)
                Case MANUAL_RESET_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MANUAL_RESET_ERR)
                Case TLB_MLTHIT_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.TLB_MLTHIT_ERR)
                Case UBRK_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.UBRK_ERR)
                Case Yaskawa.ADR_RD_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ADR_RD_ERR)
                Case TLB_MIS_RD_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.TLB_MIS_RD_ERR)
                Case TLB_PROTECTION_RD_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.TLB_PROTECTION_RD_ERR)
                Case GENERAL_INVALID_INS_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.GENERAL_INVALID_INS_ERR)
                Case SLOT_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.SLOT_ERR)
                Case GENERAL_FPU_DISABLE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.GENERAL_FPU_DISABLE_ERR)
                Case SLOT_FPU_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.SLOT_FPU_ERR)
                Case Yaskawa.ADR_WR_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ADR_WR_ERR)
                Case TLB_MIS_WR_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.TLB_MIS_WR_ERR)
                Case TLB_PROTECTION_WR_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.TLB_PROTECTION_WR_ERR)
                Case FPU_EXP_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.FPU_EXP_ERR)
                Case INITIAL_PAGE_EXP_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.INITIAL_PAGE_EXP_ERR)
                Case ROM_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ROM_ERR)
                Case RAM_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.RAM_ERR)
                Case MPU_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MPU_ERR)
                Case FPU_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.FPU_ERR)
                Case CERF_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.CERF_ERR)
                Case EXIO_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.EXIO_ERR)
                Case BUSIF_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.BUSIF_ERR)
                Case ALM_NO_ALM
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_NO_ALM)
                Case ALM_MK_DEBUG
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_DEBUG)
                Case ALM_MK_ROUND_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ROUND_ERR)
                Case ALM_MK_FSPEED_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_FSPEED_OVER)
                Case ALM_MK_FSPEED_NOSPEC
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_FSPEED_NOSPEC)
                Case ALM_MK_PRM_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_PRM_OVER)
                Case ALM_MK_ARCLEN_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ARCLEN_OVER)
                Case ALM_MK_VERT_NOSPEC
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_VERT_NOSPEC)
                Case ALM_MK_HORZ_NOSPEC
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_HORZ_NOSPEC)
                Case ALM_MK_TURN_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TURN_OVER)
                Case ALM_MK_RADIUS_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RADIUS_OVER)
                Case ALM_MK_CENTER_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CENTER_ERR)
                Case ALM_MK_BLOCK_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_BLOCK_OVER)
                Case ALM_MK_MAXF_NOSPEC
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MAXF_NOSPEC)
                Case ALM_MK_TDATA_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TDATA_ERR)
                Case ALM_MK_REG_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_REG_ERR)
                Case ALM_MK_COMMAND_CODE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_COMMAND_CODE_ERR)
                Case ALM_MK_AXIS_CONFLICT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_AXIS_CONFLICT)
                Case ALM_MK_POSMAX_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_POSMAX_OVER)
                Case ALM_MK_DIST_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_DIST_OVER)
                Case ALM_MK_MODE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MODE_ERR)
                Case ALM_MK_CMD_CONFLICT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CMD_CONFLICT)
                Case ALM_MK_RCMD_CONFLICT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCMD_CONFLICT)
                Case ALM_MK_CMD_MODE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CMD_MODE_ERR)
                Case ALM_MK_CMD_NOT_ALLOW
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CMD_NOT_ALLOW)
                Case ALM_MK_CMD_DEN_FAIL
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CMD_DEN_FAIL)
                Case ALM_MK_H_MOVE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_H_MOVE_ERR)
                Case ALM_MK_MOVE_NOT_SUPPORT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MOVE_NOT_SUPPORT)
                Case ALM_MK_EVENT_NOT_SUPPORT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_EVENT_NOT_SUPPORT)
                Case ALM_MK_ACTION_NOT_SUPPORT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACTION_NOT_SUPPORT)
                Case ALM_MK_MOVE_TYPE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MOVE_TYPE_ERR)
                Case ALM_MK_VTYPE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_VTYPE_ERR)
                Case ALM_MK_ATYPE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ATYPE_ERR)
                Case ALM_MK_HOMING_METHOD_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_HOMING_METHOD_ERR)
                Case ALM_MK_ACC_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACC_ERR)
                Case ALM_MK_DEC_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_DEC_ERR)
                Case ALM_MK_POS_TYPE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_POS_TYPE_ERR)
                Case ALM_MK_INVALID_EVENT_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_INVALID_EVENT_ERR)
                Case ALM_MK_INVALID_ACTION_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_INVALID_ACTION_ERR)
                Case ALM_MK_MOVE_NOT_ACTIVE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MOVE_NOT_ACTIVE)
                Case ALM_MK_MOVELIST_NOT_ACTIVE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MOVELIST_NOT_ACTIVE)
                Case ALM_MK_TBL_INVALID_DATA
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_DATA)
                Case ALM_MK_TBL_INVALID_SEG_NUM
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_SEG_NUM)
                Case ALM_MK_TBL_INVALID_AXIS_NUM
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_AXIS_NUM)
                Case ALM_MK_TBL_INVALID_ST_SEG
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_TBL_INVALID_ST_SEG)
                Case ALM_MK_STBL_INVALID_EXE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_STBL_INVALID_EXE)
                Case ALM_MK_DTBL_DUPLICATE_EXE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_DTBL_DUPLICATE_EXE)
                Case ALM_MK_LATCH_CONFLICT
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_LATCH_CONFLICT)
                Case ALM_MK_INVALID_AXISTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_INVALID_AXISTYPE)
                Case ALM_MK_NOT_SVCRDY
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_NOT_SVCRDY)
                Case ALM_MK_NOT_SVCRUN
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_NOT_SVCRUN)
                Case ALM_MK_MDALARM
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MDALARM)
                Case ALM_MK_SUPERPOSE_MASTER_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_SUPERPOSE_MASTER_ERR)
                Case ALM_MK_SUPERPOSE_SLAVE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_SUPERPOSE_SLAVE_ERR)
                Case ALM_MK_MDWARNING
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MDWARNING)
                Case ALM_MK_MDWARNING_POSERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MDWARNING_POSERR)
                Case ALM_MK_NOT_INFINITE_ABS
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_NOT_INFINITE_ABS)
                Case ALM_MK_INVALID_LOGICAL_NUM
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_INVALID_LOGICAL_NUM)
                Case ALM_MK_MAX_VELOCITY_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MAX_VELOCITY_ERR)
                Case ALM_MK_VELOCITY_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_VELOCITY_ERR)
                Case ALM_MK_APPROACH_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_APPROACH_ERR)
                Case ALM_MK_CREEP_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CREEP_ERR)
                Case ALM_MK_OS_ERR_MBOX1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_MBOX1)
                Case ALM_MK_OS_ERR_MBOX2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_MBOX2)
                Case ALM_MK_OS_ERR_SEND_MSG1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG1)
                Case ALM_MK_OS_ERR_SEND_MSG2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG2)
                Case ALM_MK_OS_ERR_SEND_MSG3
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG3)
                Case ALM_MK_OS_ERR_SEND_MSG4
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_OS_ERR_SEND_MSG4)
                Case ALM_MK_ACTION_ERR1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR1)
                Case ALM_MK_ACTION_ERR2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR2)
                Case ALM_MK_ACTION_ERR3
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACTION_ERR3)
                Case ALM_MK_RCV_INV_MSG1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG1)
                Case ALM_MK_RCV_INV_MSG2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG2)
                Case ALM_MK_RCV_INV_MSG3
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG3)
                Case ALM_MK_RCV_INV_MSG4
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG4)
                Case ALM_MK_RCV_INV_MSG5
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG5)
                Case ALM_MK_RCV_INV_MSG6
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG6)
                Case ALM_MK_RCV_INV_MSG7
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG7)
                Case ALM_MK_RCV_INV_MSG8
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_RCV_INV_MSG8)
                Case ALM_MK_AXIS_HANDLE_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_AXIS_HANDLE_ERROR)
                Case ALM_MK_SLAVE_USED_AS_MASTER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_SLAVE_USED_AS_MASTER)
                Case ALM_MK_MASTER_USED_AS_SLAVE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MASTER_USED_AS_SLAVE)
                Case ALM_MK_SLAVE_HAS_2_MASTERS
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_SLAVE_HAS_2_MASTERS)
                Case ALM_MK_SLAVE_HAS_NOT_WORK
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_SLAVE_HAS_NOT_WORK)
                Case ALM_MK_PARAM_OUT_OF_RANGE
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_PARAM_OUT_OF_RANGE)
                Case ALM_MK_NNUM_MAX_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_NNUM_MAX_OVER)
                Case ALM_MK_FGNTBL_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_FGNTBL_INVALID)
                Case ALM_MK_PARAM_OVERFLOW
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_PARAM_OVERFLOW)
                Case ALM_MK_ALREADY_COMMANDED
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ALREADY_COMMANDED)
                Case ALM_MK_MULTIPLE_SHIFTS
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MULTIPLE_SHIFTS)
                Case ALM_MK_CAMTBL_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_CAMTBL_INVALID)
                Case ALM_MK_ABORTED_BY_STOPMTN
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ABORTED_BY_STOPMTN)
                Case ALM_MK_HMETHOD_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_HMETHOD_INVALID)
                Case ALM_MK_MASTER_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_MASTER_INVALID)
                Case ALM_MK_DATA_HANDLE_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_DATA_HANDLE_INVALID)
                Case ALM_MK_UNKNOWN_CAM_GEAR_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_UNKNOWN_CAM_GEAR_ERR)
                Case ALM_MK_REG_SIZE_INVALID
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_REG_SIZE_INVALID)
                Case ALM_MK_ACTION_HANDLE_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MK_ACTION_HANDLE_ERROR)
                Case ALM_MM_OS_ERR_MBOX1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_OS_ERR_MBOX1)
                Case ALM_MM_OS_ERR_SEND_MSG1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_OS_ERR_SEND_MSG1)
                Case ALM_MM_OS_ERR_SEND_MSG2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_OS_ERR_SEND_MSG2)
                Case ALM_MM_OS_ERR_RCV_MSG1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_OS_ERR_RCV_MSG1)
                Case ALM_MM_MK_BUSY
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_MK_BUSY)
                Case ALM_MM_RCV_INV_MSG1
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG1)
                Case ALM_MM_RCV_INV_MSG2
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG2)
                Case ALM_MM_RCV_INV_MSG3
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG3)
                Case ALM_MM_RCV_INV_MSG4
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG4)
                Case ALM_MM_RCV_INV_MSG5
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_MM_RCV_INV_MSG5)
                Case ALM_IM_DEVICEID_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_IM_DEVICEID_ERR)
                Case ALM_IM_REGHANDLE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_IM_REGHANDLE_ERR)
                Case ALM_IM_GLOBALHANDLE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_IM_GLOBALHANDLE_ERR)
                Case ALM_IM_DEVICETYPE_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_IM_DEVICETYPE_ERR)
                Case ALM_IM_OFFSET_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.ALM_IM_OFFSET_ERR)
                Case AM_ER_UNDEF_COMMAND
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_COMMAND)
                Case AM_ER_UNDEF_CMNDTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_CMNDTYPE)
                Case AM_ER_UNDEF_OBJTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_OBJTYPE)
                Case AM_ER_UNDEF_HANDLETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_HANDLETYPE)
                Case AM_ER_UNDEF_PKTDAT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_PKTDAT)
                Case AM_ER_UNDEF_AXIS
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNDEF_AXIS)
                Case AM_ER_MSGBUF_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_MSGBUF_GET_FAULT)
                Case AM_ER_ACTSIZE_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_ACTSIZE_GET_FAULT)
                Case AM_ER_APIBUF_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_APIBUF_GET_FAULT)
                Case AM_ER_MOVEOBJ_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_MOVEOBJ_GET_FAULT)
                Case AM_ER_EVTTBL_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_EVTTBL_GET_FAULT)
                Case AM_ER_ACTTBL_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_ACTTBL_GET_FAULT)
                Case AM_ER_1BY1APIBUF_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_1BY1APIBUF_GET_FAULT)
                Case AM_ER_AXSTBL_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_AXSTBL_GET_FAULT)
                Case AM_ER_SUPERPOSEOBJ_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_SUPERPOSEOBJ_GET_FAULT)
                Case AM_ER_SUPERPOSEOBJ_CLEAR_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_SUPERPOSEOBJ_CLEAR_FAULT)
                Case AM_ER_AXIS_IN_USE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_AXIS_IN_USE)
                Case AM_ER_HASHTBL_GET_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_HASHTBL_GET_FAULT)
                Case AM_ER_UNMATCH_OBJHNDL
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_OBJHNDL)
                Case AM_ER_UNMATCH_OBJECT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_OBJECT)
                Case AM_ER_UNMATCH_APIBUF
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_APIBUF)
                Case AM_ER_UNMATCH_MSGBUF
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_MSGBUF)
                Case AM_ER_UNMATCH_ACTBUF
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_ACTBUF)
                Case AM_ER_UNMATH_SEQUENCE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATH_SEQUENCE)
                Case AM_ER_UNMATCH_1BY1APIBUF
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_1BY1APIBUF)
                Case AM_ER_UNMATCH_MOVEOBJTABLE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVEOBJTABLE)
                Case AM_ER_UNMATCH_MOVELISTTABLE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELISTTABLE)
                Case AM_ER_UNMATCH_MOVELIST_OBJECT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELIST_OBJECT)
                Case AM_ER_UNMATCH_MOVELIST_OBJHNDL
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNMATCH_MOVELIST_OBJHNDL)
                Case AM_ER_UNGET_MOVEOBJTABLE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNGET_MOVEOBJTABLE)
                Case AM_ER_UNGET_MOVELISTTABLE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNGET_MOVELISTTABLE)
                Case AM_ER_UNGET_1BY1APIBUFTABLE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNGET_1BY1APIBUFTABLE)
                Case AM_ER_NOEMPTYTBL_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_NOEMPTYTBL_ERROR)
                Case AM_ER_NOTGETSEM_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_NOTGETSEM_ERROR)
                Case AM_ER_NOTGETTBLADD_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_NOTGETTBLADD_ERROR)
                Case AM_ER_NOTWRTTBL_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_NOTWRTTBL_ERROR)
                Case AM_ER_TBLINDEX_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_TBLINDEX_ERROR)
                Case AM_ER_ILLTBLTYPE_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_ILLTBLTYPE_ERROR)
                Case AM_ER_UNSUPORTED_EVENT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_UNSUPORTED_EVENT)
                Case AM_ER_WRONG_SEQUENCE
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_WRONG_SEQUENCE)
                Case AM_ER_MOVEOBJ_BUSY
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_MOVEOBJ_BUSY)
                Case AM_ER_MOVELIST_BUSY
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_MOVELIST_BUSY)
                Case AM_ER_MOVELIST_ADD_FAULT
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_MOVELIST_ADD_FAULT)
                Case AM_ER_CONFLICT_PHI_AXS
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_CONFLICT_PHI_AXS)
                Case AM_ER_CONFLICT_LOG_AXS
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_CONFLICT_LOG_AXS)
                Case AM_ER_PKTSTS_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_PKTSTS_ERROR)
                Case AM_ER_CONFLICT_NAME
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_CONFLICT_NAME)
                Case AM_ER_ILLEGAL_NAME
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_ILLEGAL_NAME)
                Case AM_ER_SEMAPHORE_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_SEMAPHORE_ERROR)
                Case AM_ER_LOG_AXS_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.AM_ER_LOG_AXS_OVER)
                Case IM_STATION_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.IM_STATION_ERR)
                Case IM_IO_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.IM_IO_ERR)
                Case MP_FILE_ERR_GENERAL
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_GENERAL)
                Case MP_FILE_ERR_NOT_SUPPORTED
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_NOT_SUPPORTED)
                Case MP_FILE_ERR_INVALID_ARGUMENT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_ARGUMENT)
                Case MP_FILE_ERR_INVALID_HANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_HANDLE)
                Case MP_FILE_ERR_NO_FILE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_NO_FILE)
                Case MP_FILE_ERR_INVALID_PATH
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_PATH)
                Case MP_FILE_ERR_EOF
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_EOF)
                Case MP_FILE_ERR_PERMISSION_DENIED
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_PERMISSION_DENIED)
                Case MP_FILE_ERR_TOO_MANY_FILES
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_FILES)
                Case MP_FILE_ERR_FILE_BUSY
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_FILE_BUSY)
                Case MP_FILE_ERR_TIMEOUT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_TIMEOUT)
                Case MP_FILE_ERR_BAD_FS
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_BAD_FS)
                Case MP_FILE_ERR_FILESYSTEM_FULL
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_FILESYSTEM_FULL)
                Case MP_FILE_ERR_INVALID_LFM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_LFM)
                Case MP_FILE_ERR_TOO_MANY_LFM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_LFM)
                Case MP_FILE_ERR_INVALID_PDM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_PDM)
                Case MP_FILE_ERR_INVALID_MEDIA
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_MEDIA)
                Case MP_FILE_ERR_TOO_MANY_PDM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_PDM)
                Case MP_FILE_ERR_TOO_MANY_MEDIA
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_TOO_MANY_MEDIA)
                Case MP_FILE_ERR_WRITE_PROTECTED
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_WRITE_PROTECTED)
                Case MP_FILE_ERR_INVALID_DEVICE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_INVALID_DEVICE)
                Case MP_FILE_ERR_DEVICE_IO
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_DEVICE_IO)
                Case MP_FILE_ERR_DEVICE_BUSY
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_DEVICE_BUSY)
                Case MP_FILE_ERR_NO_CARD
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_NO_CARD)
                Case MP_FILE_ERR_CARD_POWER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILE_ERR_CARD_POWER)
                Case MP_CARD_SYSTEM_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CARD_SYSTEM_ERR)
                Case ERROR_CODE_GET_DIREC_OFFSET
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_DIREC_OFFSET)
                Case ERROR_CODE_GET_DIREC_INFO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_DIREC_INFO)
                Case ERROR_CODE_FUNC_TABLE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_FUNC_TABLE)
                Case ERROR_CODE_SLEEP_TASK
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SLEEP_TASK)
                Case ERROR_CODE_DEVICE_HANDLE_FULL
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DEVICE_HANDLE_FULL)
                Case ERROR_CODE_ALLOC_MEMORY
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_ALLOC_MEMORY)
                Case ERROR_CODE_BUFCOPY
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_BUFCOPY)
                Case ERROR_CODE_GET_COMMEM_OFFSET
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_COMMEM_OFFSET)
                Case ERROR_CODE_CREATE_SEMPH
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_SEMPH)
                Case ERROR_CODE_DELETE_SEMPH
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DELETE_SEMPH)
                Case ERROR_CODE_LOCK_SEMPH
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_LOCK_SEMPH)
                Case ERROR_CODE_UNLOCK_SEMPH
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_UNLOCK_SEMPH)
                Case ERROR_CODE_PACKETSIZE_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PACKETSIZE_OVER)
                Case ERROR_CODE_UNREADY
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_UNREADY)
                Case ERROR_CODE_CPUSTOP
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CPUSTOP)
                Case ERROR_CODE_CNTRNO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CNTRNO)
                Case ERROR_CODE_SELECTION
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SELECTION)
                Case ERROR_CODE_LENGTH
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_LENGTH)
                Case ERROR_CODE_OFFSET
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_OFFSET)
                Case ERROR_CODE_DATACOUNT
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DATACOUNT)
                Case ERROR_CODE_DATREAD
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DATREAD)
                Case ERROR_CODE_DATWRITE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DATWRITE)
                Case ERROR_CODE_BITWRITE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_BITWRITE)
                Case ERROR_CODE_DEVCNTR
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DEVCNTR)
                Case ERROR_CODE_NOTINIT
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_NOTINIT)
                Case ERROR_CODE_SEMPHLOCK
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SEMPHLOCK)
                Case ERROR_CODE_SEMPHUNLOCK
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SEMPHUNLOCK)
                Case ERROR_CODE_DRV_PROC
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DRV_PROC)
                Case ERROR_CODE_GET_DRIVER_HANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_DRIVER_HANDLE)
                Case ERROR_CODE_SEND_MSG
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SEND_MSG)
                Case ERROR_CODE_RECV_MSG
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_RECV_MSG)
                Case ERROR_CODE_INVALID_RESPONSE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_INVALID_RESPONSE)
                Case ERROR_CODE_INVALID_ID
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_INVALID_ID)
                Case ERROR_CODE_INVALID_STATUS
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_INVALID_STATUS)
                Case ERROR_CODE_INVALID_CMDCODE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_INVALID_CMDCODE)
                Case ERROR_CODE_INVALID_SEQNO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_INVALID_SEQNO)
                Case ERROR_CODE_SEND_RETRY_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_SEND_RETRY_OVER)
                Case ERROR_CODE_RECV_RETRY_OVER
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_RECV_RETRY_OVER)
                Case ERROR_CODE_RESPONSE_TIMEOUT
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_RESPONSE_TIMEOUT)
                Case ERROR_CODE_WAIT_FOR_EVENT
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_WAIT_FOR_EVENT)
                Case ERROR_CODE_EVENT_OPEN
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_EVENT_OPEN)
                Case ERROR_CODE_EVENT_RESET
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_EVENT_RESET)
                Case ERROR_CODE_EVENT_READY
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_EVENT_READY)
                Case ERROR_CODE_PROCESSNUM
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PROCESSNUM)
                Case ERROR_CODE_GET_PROC_INFO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_PROC_INFO)
                Case ERROR_CODE_THREADNUM
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_THREADNUM)
                Case ERROR_CODE_GET_THRD_INFO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_THRD_INFO)
                Case ERROR_CODE_CREATE_MBOX
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_MBOX)
                Case ERROR_CODE_DELETE_MBOX
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DELETE_MBOX)
                Case ERROR_CODE_GET_TASKID
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_TASKID)
                Case ERROR_CODE_NO_THREADINFO
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_NO_THREADINFO)
                Case ERROR_CODE_COM_INITIALIZE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_COM_INITIALIZE)
                Case ERROR_CODE_COMDEVICENUM
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_COMDEVICENUM)
                Case ERROR_CODE_GET_COM_DEVICE_HANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_GET_COM_DEVICE_HANDLE)
                Case ERROR_CODE_COM_DEVICE_FULL
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_COM_DEVICE_FULL)
                Case ERROR_CODE_CREATE_PANELOBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_PANELOBJ)
                Case ERROR_CODE_OPEN_PANELOBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_OPEN_PANELOBJ)
                Case ERROR_CODE_CLOSE_PANELOBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CLOSE_PANELOBJ)
                Case ERROR_CODE_PROC_PANELOBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PROC_PANELOBJ)
                Case ERROR_CODE_CREATE_CNTROBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_CNTROBJ)
                Case ERROR_CODE_OPEN_CNTROBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_OPEN_CNTROBJ)
                Case ERROR_CODE_CLOSE_CNTROBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CLOSE_CNTROBJ)
                Case ERROR_CODE_PROC_CNTROBJ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PROC_CNTROBJ)
                Case ERROR_CODE_CREATE_COMDEV_MUTEX
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_COMDEV_MUTEX)
                Case ERROR_CODE_CREATE_COMDEV_MAPFILE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_CREATE_COMDEV_MAPFILE)
                Case ERROR_CODE_OPEN_COMDEV_MAPFILE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_OPEN_COMDEV_MAPFILE)
                Case ERROR_CODE_NOT_OBJECT_TYPE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_NOT_OBJECT_TYPE)
                Case ERROR_CODE_COM_NOT_OPENED
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_COM_NOT_OPENED)
                Case ERROR_CODE_PNLCMD_CPU_CONTROL
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_CPU_CONTROL)
                Case ERROR_CODE_PNLCMD_SFILE_READ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_SFILE_READ)
                Case ERROR_CODE_PNLCMD_SFILE_WRITE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_SFILE_WRITE)
                Case ERROR_CODE_PNLCMD_REGISTER_READ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_REGISTER_READ)
                Case ERROR_CODE_PNLCMD_REGISTER_WRITE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_REGISTER_WRITE)
                Case ERROR_CODE_PNLCMD_API_SEND
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_API_SEND)
                Case ERROR_CODE_PNLCMD_API_RECV
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_API_RECV)
                Case ERROR_CODE_PNLCMD_NO_RESPONSE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_NO_RESPONSE)
                Case ERROR_CODE_PNLCMD_PACKET_READ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_PACKET_READ)
                Case ERROR_CODE_PNLCMD_PACKET_WRITE
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_PACKET_WRITE)
                Case ERROR_CODE_PNLCMD_STATUS_READ
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_PNLCMD_STATUS_READ)
                Case ERROR_CODE_NOT_CONTROLLER_RDY
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_NOT_CONTROLLER_RDY)
                Case ERROR_CODE_DOUBLE_CMD
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DOUBLE_CMD)
                Case ERROR_CODE_DOUBLE_RCMD
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_DOUBLE_RCMD)
                Case ERROR_CODE_FILE_NOT_OPENED
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_FILE_NOT_OPENED)
                Case ERROR_CODE_OPENFILE_NUM
                    GetErrMsg = m_Errmsg(eErrMsg.ERROR_CODE_OPENFILE_NUM)
                Case MP_CTRL_SYS_ERROR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CTRL_SYS_ERROR)
                Case MP_CTRL_PARAM_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CTRL_PARAM_ERR)
                Case MP_CTRL_FILE_NOT_FOUND
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CTRL_FILE_NOT_FOUND)
                Case MP_NOTMOVEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTMOVEHANDLE)
                Case MP_NOTTIMERHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTTIMERHANDLE)
                Case MP_NOTINTERRUPT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTINTERRUPT)
                Case MP_NOTEVENTHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTEVENTHANDLE)
                Case MP_NOTMESSAGEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTMESSAGEHANDLE)
                Case MP_NOTUSERFUNCTIONHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTUSERFUNCTIONHANDLE)
                Case MP_NOTACTIONHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTACTIONHANDLE)
                Case MP_NOTSUBSCRIBEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSUBSCRIBEHANDLE)
                Case MP_NOTDEVICEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDEVICEHANDLE)
                Case MP_NOTAXISHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTAXISHANDLE)
                Case MP_NOTMOVELISTHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTMOVELISTHANDLE)
                Case MP_NOTTRACEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTTRACEHANDLE)
                Case MP_NOTGLOBALDATAHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTGLOBALDATAHANDLE)
                Case MP_NOTSUPERPOSEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSUPERPOSEHANDLE)
                Case MP_NOTCONTROLLERHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCONTROLLERHANDLE)
                Case MP_NOTFILEHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTFILEHANDLE)
                Case MP_NOTREGISTERDATAHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTREGISTERDATAHANDLE)
                Case MP_NOTALARMHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTALARMHANDLE)
                Case MP_NOTCAMHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCAMHANDLE)
                Case MP_NOTHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTHANDLE)
                Case MP_NOTEVENTTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTEVENTTYPE)
                Case MP_NOTDEVICETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDEVICETYPE)
                Case MP_NOTDATAUNITSIZE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDATAUNITSIZE)
                Case MP_NOTDEVICE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDEVICE)
                Case MP_NOTACTIONTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTACTIONTYPE)
                Case MP_NOTPARAMNAME
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPARAMNAME)
                Case MP_NOTDATATYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDATATYPE)
                Case MP_NOTBUFFERTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTBUFFERTYPE)
                Case MP_NOTMOVETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTMOVETYPE)
                Case MP_NOTANGLETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTANGLETYPE)
                Case MP_NOTDIRECTION
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTDIRECTION)
                Case MP_NOTAXISTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTAXISTYPE)
                Case MP_NOTUNITTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTUNITTYPE)
                Case MP_NOTCOMDEVICETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCOMDEVICETYPE)
                Case MP_NOTCONTROLTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCONTROLTYPE)
                Case MP_NOTFILETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTFILETYPE)
                Case MP_NOTSEMAPHORETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSEMAPHORETYPE)
                Case MP_NOTSYSTEMOPTION
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSYSTEMOPTION)
                Case MP_TIMEOUT_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TIMEOUT_ERR)
                Case MP_TIMEOUT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TIMEOUT)
                Case MP_NOTSUBSCRIBETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSUBSCRIBETYPE)
                Case MP_NOTSCANTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSCANTYPE)
                Case MP_DEVICEOFFSETOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_DEVICEOFFSETOVER)
                Case MP_DEVICEBITOFFSETOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_DEVICEBITOFFSETOVER)
                Case MP_UNITCOUNTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_UNITCOUNTOVER)
                Case MP_COMPAREVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_COMPAREVALUEOVER)
                Case MP_FCOMPAREVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FCOMPAREVALUEOVER)
                Case MP_EVENTCOUNTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_EVENTCOUNTOVER)
                Case MP_VALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_VALUEOVER)
                Case MP_FVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FVALUEOVER)
                Case MP_PSTOREDVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PSTOREDVALUEOVER)
                Case MP_PSTOREDFVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PSTOREDFVALUEOVER)
                Case MP_SIZEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SIZEOVER)
                Case MP_RECEIVETIMEROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_RECEIVETIMEROVER)
                Case MP_RECNUMOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_RECNUMOVER)
                Case MP_PARAMOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PARAMOVER)
                Case MP_FRAMEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FRAMEOVER)
                Case MP_RADIUSOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_RADIUSOVER)
                Case MP_CONTROLLERNOOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CONTROLLERNOOVER)
                Case MP_AXISNUMOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_AXISNUMOVER)
                Case MP_DIGITOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_DIGITOVER)
                Case MP_CALENDARVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CALENDARVALUEOVER)
                Case MP_OFFSETOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_OFFSETOVER)
                Case MP_NUMBEROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NUMBEROVER)
                Case MP_RACKOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_RACKOVER)
                Case MP_SLOTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SLOTOVER)
                Case MP_FIXVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FIXVALUEOVER)
                Case MP_REGISTERINFOROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_REGISTERINFOROVER)
                Case PC_MEMORY_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.PC_MEMORY_ERR)
                Case MP_NOCOMMUDEVICETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOCOMMUDEVICETYPE)
                Case MP_NOTPROTOCOLTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPROTOCOLTYPE)
                Case MP_NOTFUNCMODE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTFUNCMODE)
                Case MP_MYADDROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_MYADDROVER)
                Case MP_NOTPORTTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPORTTYPE)
                Case MP_NOTPROTMODE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPROTMODE)
                Case MP_NOTCHARSIZE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCHARSIZE)
                Case MP_NOTPARITYBIT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPARITYBIT)
                Case MP_NOTSTOPBIT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSTOPBIT)
                Case MP_NOTBAUDRAT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTBAUDRAT)
                Case MP_TRANSDELAYOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TRANSDELAYOVER)
                Case MP_PEERADDROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PEERADDROVER)
                Case MP_SUBNETMASKOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SUBNETMASKOVER)
                Case MP_GWADDROVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_GWADDROVER)
                Case MP_DIAGPORTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_DIAGPORTOVER)
                Case MP_PROCRETRYOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PROCRETRYOVER)
                Case MP_TCPZEROWINOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TCPZEROWINOVER)
                Case MP_TCPRETRYOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TCPRETRYOVER)
                Case MP_TCPFINOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TCPFINOVER)
                Case MP_IPASSEMBLEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_IPASSEMBLEOVER)
                Case MP_MAXPKTLENOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_MAXPKTLENOVER)
                Case MP_PEERPORTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PEERPORTOVER)
                Case MP_MYPORTOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_MYPORTOVER)
                Case MP_NOTTRANSPROT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTTRANSPROT)
                Case MP_NOTAPPROT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTAPPROT)
                Case MP_NOTCODETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCODETYPE)
                Case MP_CYCTIMOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CYCTIMOVER)
                Case MP_NOTIOMAPCOM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTIOMAPCOM)
                Case MP_NOTIOTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTIOTYPE)
                Case MP_IOOFFSETOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_IOOFFSETOVER)
                Case MP_IOSIZEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_IOSIZEOVER)
                Case MP_TIOSIZEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TIOSIZEOVER)
                Case MP_MEMORY_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_MEMORY_ERR)
                Case MP_NOTPTR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPTR)
                Case MP_TABLEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TABLEOVER)
                Case MP_ALARM
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ALARM)
                Case MP_MEMORYOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_MEMORYOVER)
                Case MP_EXEC_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_EXEC_ERR)
                Case MP_NOTLOGICALAXIS
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTLOGICALAXIS)
                Case MP_NOTSUPPORTED
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSUPPORTED)
                Case MP_ILLTEXT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ILLTEXT)
                Case MP_NOFILENAME
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOFILENAME)
                Case MP_NOTREGSTERNAME
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTREGSTERNAME)
                Case MP_FILEALREADYOPEN
                    GetErrMsg = m_Errmsg(eErrMsg.MP_FILEALREADYOPEN)
                Case MP_NOFILEPACKET
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOFILEPACKET)
                Case MP_NOTFILEPACKETSIZE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTFILEPACKETSIZE)
                Case MP_NOTUSERFUNCTION
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTUSERFUNCTION)
                Case MP_NOTPARAMETERTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTPARAMETERTYPE)
                Case MP_ILLREGHANDLETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ILLREGHANDLETYPE)
                Case MP_ILLREGTYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ILLREGTYPE)
                Case MP_ILLREGSIZE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ILLREGSIZE)
                Case MP_REGNUMOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_REGNUMOVER)
                Case MP_RELEASEWAIT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_RELEASEWAIT)
                Case MP_PRIORITYOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_PRIORITYOVER)
                Case MP_NOTCHANGEPRIORITY
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTCHANGEPRIORITY)
                Case MP_SEMAPHOREOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SEMAPHOREOVER)
                Case MP_NOTSEMAPHOREHANDLE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTSEMAPHOREHANDLE)
                Case MP_SEMAPHORELOCKED
                    GetErrMsg = m_Errmsg(eErrMsg.MP_SEMAPHORELOCKED)
                Case MP_CONTINUE_RELEASEWAIT
                    GetErrMsg = m_Errmsg(eErrMsg.MP_CONTINUE_RELEASEWAIT)
                Case MP_NOTTABLENAME
                    GetErrMsg = m_Errmsg(eErrMsg.MP_NOTTABLENAME)
                Case MP_ILLTABLETYPE
                    GetErrMsg = m_Errmsg(eErrMsg.MP_ILLTABLETYPE)
                Case MP_TIMEOUTVALUEOVER
                    GetErrMsg = m_Errmsg(eErrMsg.MP_TIMEOUTVALUEOVER)
                Case MP_OTHER_ERR
                    GetErrMsg = m_Errmsg(eErrMsg.MP_OTHER_ERR)
                Case Else
                    GetErrMsg = ""
            End Select
        Catch ex As Exception
            GetErrMsg = ex.ToString()
        End Try
    End Function
    Friend Sub GetTarget(ByVal AxisID As Integer, ByRef pTarget As Double) Implements IPseudoMotion.GetTarget
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim pStoredValue As Integer
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        With m_Axis(AxisID)
            Try
                'If m_MoveRdy Then
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000


                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    If Not .Mode.IsServo Then
                        '// Definition of motion API variables
                        Dim hRegister_OB As Int32                '// Register data handle for OB register
                        Dim cRegisterName_OB As String          '// OB register name storage variable
                        Dim RegisterDataNumber As Int32         '// Number of read-in register
                        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
                        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
                        Dim ReadDataNumber As Int32         '// Storing the number of read-in registers
                        '// OB Register
                        cRegisterName_OB = "IL" & "0014"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        RegisterDataNumber = 1
                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        pTarget = Reg_ShortData(0)
                        pTarget = pTarget / .Param.SwScale
                    Else
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            rc = ymcGetMotionParameterValue(.ThreadID, CShort(ApiDefs.MONITOR_PARAMETER), eParameterNo.TPOS, pStoredValue)
                            If rc = MP_SUCCESS Then
                                pTarget = pStoredValue
                                pTarget = pTarget / .Param.SwScale
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcGetMotionParameterValue" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            End Try
        End With
    End Sub
    Friend Function Init() As Boolean Implements IPseudoMotion.Init
        Dim rc As Integer
        Dim comDevice As COM_DEVICE
        Dim axisName As String
        Dim controllerhandle As Integer
        Try
            comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
            comDevice.PortNumber = 1
            comDevice.CpuNumber = 1
            comDevice.NetworkNumber = 0
            comDevice.StationNumber = 0
            comDevice.UnitNumber = 0
            comDevice.IPAddress = 0
            comDevice.Timeout = 10 * 1000
            rc = ymcOpenController(comDevice, controllerhandle)
            If rc = MP_SUCCESS Then
                rc = ymcSetAPITimeoutValue(30 * 1000)
                If rc = MP_SUCCESS Then
                    rc = ymcClearAllAxes()
                    If rc = MP_SUCCESS Then
                        For i = 0 To UBound(m_Axis)
                            If m_Axis(i).CardType = enumMotionCard.Yaskawa Then
                                If m_Axis(i).Mode.IsServo Then
                                    axisName = "haldle" + m_Axis(i).AxisID.ToString()
                                    rc = ymcDeclareAxis(1, 0, 3, m_Axis(i).AxisID, m_Axis(i).AxisID, CShort(ApiDefs.REAL_AXIS), axisName, m_Axis(i).ThreadID)
                                    If rc = MP_SUCCESS Then
                                        rc = ymcClearServoAlarm(m_Axis(i).ThreadID)
                                        If rc = MP_SUCCESS Then

                                        Else
                                            Call MsgBox("ymcClearServoAlarm" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                            Exit For
                                        End If
                                    Else
                                        Call MsgBox("ymcDeclareAxis" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                        Exit For
                                    End If
                                End If
                            End If
                        Next
                        Call ymcCloseController(controllerhandle)
                    Else
                        Call MsgBox("ymcClearAllAxes" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                    End If
                Else
                    Call MsgBox("ymcSetAPITimeoutValue" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Else
                Call ymcCloseController(controllerhandle)
                Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
            End If
            Init = True
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            Init = False
        End Try
    End Function
    Friend Sub MoveAbs(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim status As enumMotionFlag
        Dim cmd As Double
        Dim calcDistance As Double
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
                            .IsExternalParameters = True
                            .Speed.MaxVelExt = .Speed.MaxVel * VelocityRatio
                            .Speed.AccExt = .Speed.Acc * AccRatio
                            .Speed.DecExt = .Speed.Dec * AccRatio
                            .TargetPosition = Target
                            Do
                            Loop Until m_Axis(AxisID).IsThreadFinished
                            m_Axis(AxisID).IsThreadFinished = False : m_Axis(AxisID).Status.MoveRdy = enumMotionFlag.eNotReady
                            m_Axis(AxisID).TargetPosition = Target
                            Call System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MoveAbs1), AxisID)
                            Do
                            Loop Until m_Axis(AxisID).IsThreadStarted
                            pResult = enumMotionFlag.eSent
                        End If
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
    Friend Sub MoveAbs1(ByVal StateInfo As Object)     '(ByVal AxisID As Integer, ByVal Target As Double, ByRef pResult As enumMotionFlag, Optional ByVal VelocityRatio As Double = 1.0, Optional ByVal AccRatio As Double = 1.0) Implements IPseudoMotion.MoveAbs
        Dim waitForCompletion As Short
        Dim motionData As MOTION_DATA
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Dim runMaxVelocity As Integer
        Dim AccelerationExteleration As Integer
        Dim DecelerationExteleration As Integer
        Dim runVelocity As Integer
        Dim targetPosition As Integer
        Dim positionData As POSITION_DATA
        Dim axisID As Integer = CInt(StateInfo)
        With m_Axis(axisID)
            Try
                .Status.MoveRdy = enumMotionFlag.eNotReady
                .IsThreadFinished = False
                .IsThreadStarted = True
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000

                If .IsExternalParameters Then
                    runMaxVelocity = CInt(.Speed.MaxVelExt)
                    AccelerationExteleration = CInt(.Speed.AccExt)
                    DecelerationExteleration = CInt(.Speed.DecExt)
                    runVelocity = CInt(.Speed.MaxVelExt)
                Else
                    runMaxVelocity = CInt(.Speed.MaxVel)
                    AccelerationExteleration = CInt(.Speed.Acc)
                    DecelerationExteleration = CInt(.Speed.Dec)
                    runVelocity = CInt(.Speed.MaxVel)
                End If
                targetPosition = CInt(.TargetPosition * .Param.SwScale)
                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    If Not .Mode.IsServo Then
                        '// Definition of motion API variables
                        Dim hRegister_OW As Int32                '// Register data handle for OW register
                        Dim hRegister_OB As Int32                '// Register data handle for OB register
                        Dim cRegisterName_OW As String        '// OW register name storage variable
                        Dim cRegisterName_OB As String          '// OB register name storage variable
                        Dim RegisterDataNumber As Int32         '// Number of read-in register
                        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
                        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
                        Dim ReadDataNumber As Int32         '// Storing the number of read-in registers
                        '// OW Register
                        cRegisterName_OW = "OW" & "0022"
                        '// OW Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OW Register
                        Reg_ShortData(0) = &H2000
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        cRegisterName_OB = "OB" & "00224"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 1
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        cRegisterName_OB = "OB" & "00226"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 1
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If


                        '// OW Register
                        cRegisterName_OW = "OW" & "0024"
                        '// OW Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OW Register
                        Reg_ShortData(0) = CShort(runMaxVelocity / 10)
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OW Register
                        cRegisterName_OW = "OW" & "0025"
                        '// OW Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OW Register
                        Reg_ShortData(0) = CShort(AccelerationExteleration)
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If


                        '// OB Register
                        cRegisterName_OB = "OB" & "00223"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 1
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If


                        '// OB Register
                        cRegisterName_OB = "IB" & "124"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        Do
                            '// OB Register
                            RegisterDataNumber = 1
                            rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                            If rc <> MP_SUCCESS Then
                                MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                                Exit Sub
                            End If

                            If Reg_ShortData(0) = 1 Then Exit Do
                        Loop

                        '// OB Register
                        cRegisterName_OB = "OB" & "00223"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 0
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        cRegisterName_OB = "OB" & "00224"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 0
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        cRegisterName_OB = "OB" & "00226"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 0
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        Thread.Sleep(5)


                        '// OL Register
                        cRegisterName_OW = "OW" & "0024"
                        '// OW Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OW Register
                        Reg_ShortData(0) = CShort(targetPosition)
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OL Register
                        cRegisterName_OW = "OW" & "0025"
                        '// OW Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OW Register
                        Reg_ShortData(0) = 0
                        If targetPosition < 0 Then Reg_ShortData(0) = -1
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If

                        '// OB Register
                        cRegisterName_OB = "OB" & "00228"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 1
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If


                        ''// OB Register
                        'cRegisterName_OB = "IB" & "128"
                        ''// OB Register
                        'rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        'If rc <> MP_SUCCESS Then
                        '    MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                        '    Exit Sub
                        'End If

                        'Do
                        '    '// OB Register
                        '    RegisterDataNumber = 1
                        '    rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                        '    If rc <> MP_SUCCESS Then
                        '        MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                        '        Exit Sub
                        '    End If
                        '    If Reg_ShortData(0) = 1 Then Exit Do
                        'Loop


                        '// OB Register
                        cRegisterName_OB = "OB" & "00228"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        '// OB Register
                        Reg_ShortData(0) = 0
                        RegisterDataNumber = 1
                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If



                        '// OB Register
                        cRegisterName_OB = "IB" & "128"
                        '// OB Register
                        rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                        If rc <> MP_SUCCESS Then
                            MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                            Exit Sub
                        End If
                        Do
                            '// OB Register
                            RegisterDataNumber = 1
                            rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                            If rc <> MP_SUCCESS Then
                                MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]")
                                Exit Sub
                            End If
                            If Reg_ShortData(0) = 0 Then Exit Do
                        Loop
                        .Status.MoveRdy = enumMotionFlag.eReady
                    Else
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            '// Motion data setting
                            motionData.CoordinateSystem = CShort(ApiDefs.WORK_SYSTEM) 'MACHINE_SYSTEM   '// Work coordinate system
                            motionData.MoveType = CShort(ApiDefs.MTYPE_ABSOLUTE)    'MTYPE_RELATIVE     '// Incremental value specified
                            motionData.VelocityType = CShort(ApiDefs.VTYPE_UNIT_PAR)     '// Speed [reference unit/s]
                            motionData.AccDecType = CShort(ApiDefs.ATYPE_UNIT_PAR)  '//Acceleration [reference unit/s2]         '// ATYPE_TIME-Time constant specified [ms]
                            motionData.FilterType = CShort(ApiDefs.FTYPE_S_CURVE)        '// Moving average filter (simplified S-curve)
                            motionData.DataType = 0                              '// All parameters directly specified
                            motionData.MaxVelocity = runMaxVelocity
                            motionData.Acceleration = AccelerationExteleration                 '// Acceleration time constant [ms]
                            motionData.Deceleration = DecelerationExteleration                 '// Deceleration time constant [ms]
                            motionData.FilterTime = 10                           '// Filter time [0.1 ms]
                            motionData.Velocity = runMaxVelocity                     '// Speed [reference unit/s]
                            '/* Not Use MotionData(MasterAxis).ApproachVelocity = 0 */
                            '/* Not Use MotionData(MasterAxis).CreepVelocity    = 0 */

                            '// Position data setting
                            positionData.DataType = ApiDefs.DATATYPE_IMMEDIATE
                            positionData.PositionData = targetPosition

                            '// By setting the completion attribute to "COMMAND_STARTED" (starting the command),"
                            '// the control returns to the application immediately after positioning command execution.
                            waitForCompletion = CShort(ApiDefs.POSITIONING_COMPLETED)
                            rc = ymcMoveDriverPositioning(devicehandle, motionData, positionData, 0, "a", waitForCompletion, 0)
                            If rc = MP_SUCCESS Then
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                .Status.MoveRdy = enumMotionFlag.eReady
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcMoveDriverPositioning" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
                .Status.MoveRdy = enumMotionFlag.eReady
            Finally
                .IsThreadFinished = True
            End Try
        End With
    End Sub
    Friend Sub MoveArc(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal CenterX As Double, ByVal CenterY As Double, ByVal EndX As Double, ByVal EndY As Double, ByVal Direction As Integer, ByVal TurnCount As Double, ByRef pStatus As enumMotionFlag)
        Dim status As enumMotionFlag
        Dim axisAry(0 To 1) As Integer
        Try
            pStatus = enumMotionFlag.eNotSent
            axisAry(0) = AxisID1
            axisAry(1) = AxisID2
            If ChkMultiStop(AxisID1, AxisID2) = enumMotionFlag.eReady Then
                Call ChkSwLimit(AxisID1, EndX, status)
                If status = enumMotionFlag.eHigh Then
                    Call ChkSwLimit(AxisID2, EndY, status)
                    If status = enumMotionFlag.eHigh Then
                        Do
                        Loop Until m_Axis(AxisID1).IsThreadFinished
                        m_Axis(AxisID1).IsThreadFinished = False : m_Axis(AxisID1).Status.MoveRdy = enumMotionFlag.eNotReady
                        m_Axis(AxisID1).CenterX = CenterX
                        m_Axis(AxisID1).CenterY = CenterY
                        m_Axis(AxisID1).EndX = EndX
                        m_Axis(AxisID1).EndY = EndY
                        m_Axis(AxisID1).Direction = Direction
                        m_Axis(AxisID1).TurnCount = TurnCount
                        Call System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MoveArc1), axisAry)
                        Do
                        Loop Until m_Axis(AxisID1).IsThreadStarted
                        pStatus = enumMotionFlag.eSent
                    Else
                        If status = enumMotionFlag.eLimitP Then
                            pStatus = enumMotionFlag.eLimitP
                        ElseIf status = enumMotionFlag.eLimitN Then
                            pStatus = enumMotionFlag.eLimitN
                        End If
                    End If
                Else
                    If status = enumMotionFlag.eLimitP Then
                        pStatus = enumMotionFlag.eLimitP
                    ElseIf status = enumMotionFlag.eLimitN Then
                        pStatus = enumMotionFlag.eLimitN
                    End If
                End If
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub

    Friend Sub MoveArc1(ByVal StateInfo As Object) Implements IPseudoMotion.MoveArc
        Dim waitForCompletion As Short
        Dim motionData As MOTION_DATA
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        'Dim axisName As String
        Dim endPoint(0 To 1) As POSITION_DATA
        Dim center(0 To 1) As POSITION_DATA
        Dim TurnNumber As DWORD_DATA       ' ターン数
        Dim controllerhandle As Integer
        Dim axishandle(0 To 1) As Integer
        Dim devicehandle As Integer
        Dim runMaxVelocity As Integer
        Dim AccelerationExteleration As Integer
        Dim DecelerationExteleration As Integer
        Dim runVelocity As Integer
        Dim endX As Integer
        Dim endY As Integer
        Dim centerX As Integer
        Dim centerY As Integer
        Dim axisID1 As Integer = StateInfo(0)
        Dim axisID2 As Integer = StateInfo(1)
        With m_Axis(axisID1)
            Try
                .Status.MoveRdy = enumMotionFlag.eNotReady
                .IsThreadFinished = False
                .IsThreadStarted = True
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000
                If .IsExternalParameters Then
                    runMaxVelocity = CInt(.Speed.MaxVelExt)
                    AccelerationExteleration = CInt(.Speed.AccExt)
                    DecelerationExteleration = CInt(.Speed.DecExt)
                    runVelocity = CInt(.Speed.MaxVelExt)
                Else
                    runMaxVelocity = CInt(.Speed.MaxVelCircle)
                    AccelerationExteleration = CInt(.Speed.AccCircle)
                    DecelerationExteleration = CInt(.Speed.DecCircle)
                    runVelocity = CInt(.Speed.MaxVelCircle)
                End If
                endX = CInt(.EndX * .Param.SwScale)
                endY = CInt(.EndY * m_Axis(axisID2).Param.SwScale)
                centerX = CInt(.CenterX * .Param.SwScale)
                centerY = CInt(.CenterY * m_Axis(axisID2).Param.SwScale)
                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    axishandle(1) = m_Axis(axisID2).ThreadID
                    axishandle(0) = .ThreadID
                    rc = ymcDeclareDevice(2, axishandle(0), devicehandle)
                    If rc = MP_SUCCESS Then
                        ' 軸数分のパラメータを設定する
                        motionData.CoordinateSystem = CShort(ApiDefs.WORK_SYSTEM) 'MACHINE_SYSTEM   '// Work coordinate system
                        motionData.MoveType = CShort(ApiDefs.MTYPE_ABSOLUTE)    'MTYPE_RELATIVE     '// Incremental value specified
                        motionData.VelocityType = CShort(ApiDefs.VTYPE_UNIT_PAR)     '// Speed [reference unit/s]
                        motionData.AccDecType = CShort(ApiDefs.ATYPE_UNIT_PAR)  '//Acceleration [reference unit/s2]         '// ATYPE_TIME-Time constant specified [ms]
                        motionData.FilterType = CShort(ApiDefs.FTYPE_S_CURVE)        '// Moving average filter (simplified S-curve)
                        motionData.DataType = 0                              '// All parameters directly specified
                        motionData.MaxVelocity = runMaxVelocity
                        motionData.Acceleration = AccelerationExteleration                 '// Acceleration time constant [ms]
                        motionData.Deceleration = DecelerationExteleration                 '// Deceleration time constant [ms]
                        motionData.FilterTime = 10                           '// Filter time [0.1 ms]
                        motionData.Velocity = runMaxVelocity                     '// Speed [reference unit/s]
                        '/* Not Use MotionData(MasterAxis).ApproachVelocity = 0 */
                        '/* Not Use MotionData(MasterAxis).CreepVelocity    = 0 */

                        endPoint(0).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        endPoint(0).PositionData = endX
                        endPoint(1).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        endPoint(1).PositionData = endY
                        center(0).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        center(0).PositionData = centerX
                        center(1).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        center(1).PositionData = centerY
                        TurnNumber.DataType = ApiDefs.DATATYPE_IMMEDIATE
                        TurnNumber.Data = CInt(.TurnCount)
                        waitForCompletion = CShort(ApiDefs.POSITIONING_COMPLETED)
                        ' 中心点指定の円弧補間を実行する
                        Dim dir As Short
                        dir = CShort(.Direction)
                        rc = ymcMoveCircularCenter(devicehandle, motionData, endPoint(0), center(0), TurnNumber, dir, 0, CStr(0), waitForCompletion, 0)
                        '異常判断処理
                        If rc = MP_SUCCESS Then
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            .Status.MoveRdy = enumMotionFlag.eReady
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcMoveLinear" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    Else
                        Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                        Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
                .Status.MoveRdy = enumMotionFlag.eReady
            Finally
                .IsThreadFinished = True
            End Try
        End With
    End Sub
    Friend Sub MoveHome(ByVal StateInfo As Object) Implements IPseudoMotion.MoveHome
        Dim rc As Integer                 '// Motion API return value
        Dim waitForCompletion As Short  '// Completion attribute storage variable
        Dim motionData As MOTION_DATA   '// MOTION_DATA structure
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim homeMethod As Short
        'Dim direction As Short
        Dim runIdx As Integer

        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        Dim pStoredValue As Integer
        Dim psudodir As Integer
        Dim timeOut As Integer = 1000 * 60

        Dim positionData As POSITION_DATA         '// POSITION_DATA structure (for 3 axes)
        Dim axisID As Integer = CInt(StateInfo)
        With m_Axis(axisID)
            Try
                'Update necessary data
                .Status.HomeRdy = enumMotionFlag.eNotReady
                .IsThreadFinished = False
                .IsThreadStarted = True

                '==========================================================
                If .Mode.IsServo Then
                    If axisID = 1 Then
                        If .Mode.HomeDir = 0 Then
                            homeMethod = CShort(ApiDefs.HMETHOD_POT_ONLY)
                            psudodir = 1
                        Else
                            homeMethod = CShort(ApiDefs.HMETHOD_NOT_ONLY)
                            psudodir = -1
                        End If
                    Else
                        If .Mode.HomeDir = 0 Then
                            homeMethod = CShort(ApiDefs.HMETHOD_POT_C)
                            psudodir = 1
                        Else
                            homeMethod = CShort(ApiDefs.HMETHOD_NOT_C)
                            psudodir = -1
                        End If
                    End If

                Else
                    homeMethod = CShort(ApiDefs.HMETHOD_NOT_ONLY)
                End If

                'If m_HomeDirection Then
                'direction = CShort(ApiDefs.DIRECTION_POSITIVE)
                'Else
                '    direction = CShort(ApiDefs.DIRECTION_NEGATIVE)
                'End If
                runIdx = 100


                '//============================================================================ To Contents of Processing
                '// Sets the ymcOpenController parameters.
                '//============================================================================
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000

                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    If Not .Mode.IsServo Then
                        '// Definition of motion API variables
                        Dim hRegister_OW As Int32                '// Register data handle for OW register
                        Dim hRegister_OB As Int32                '// Register data handle for OB register
                        Dim cRegisterName_OW As String        '// OW register name storage variable
                        Dim cRegisterName_OB As String          '// OB register name storage variable
                        Dim RegisterDataNumber As Int32         '// Number of read-in register
                        Dim Reg_ShortData(2) As Int16            '// W or B size register data storage variable
                        Dim Reg_LongData(2) As Int32           '// L size register data storage variable
                        Dim ReadDataNumber As Int32         '// Storing the number of read-in registers
                        Do
                            Select Case runIdx
                                Case 100
                                    cRegisterName_OW = "OW" & "0022"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = &H2000 : RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 200
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Do
                                    End If
                                Case 200
                                    cRegisterName_OB = "OB" & "00224"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 300
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 300
                                    cRegisterName_OB = "OB" & "00225"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 400
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 400
                                    cRegisterName_OW = "OW" & "0024"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 500
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 500
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 500
                                    cRegisterName_OW = "OW" & "0025"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 50
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 600
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 600
                                    cRegisterName_OB = "OB" & "00223"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 700
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 700
                                    cRegisterName_OB = "IB" & "124"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        RegisterDataNumber = 1
                                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                                        If rc = MP_SUCCESS Then
                                            If Reg_ShortData(0) = 1 Then runIdx = 800
                                        Else
                                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 800
                                    cRegisterName_OB = "OB" & "00223"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 0
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 900
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 900
                                    cRegisterName_OB = "OB" & "00224"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 0
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1000
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1000
                                    cRegisterName_OB = "OB" & "00225"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 0
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1100
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1100
                                    cRegisterName_OB = "OB" & "00226"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1200
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1200
                                    cRegisterName_OW = "OW" & "0024"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 100
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1300
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1300
                                    cRegisterName_OW = "OW" & "0025"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OW, hRegister_OW)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 100
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OW, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1400
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OW" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1400
                                    cRegisterName_OB = "OB" & "00223"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1500
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1500
                                    cRegisterName_OB = "IB" & "124"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        RegisterDataNumber = 1
                                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                                        If rc = MP_SUCCESS Then
                                            If Reg_ShortData(0) = 1 Then runIdx = 1700
                                        Else
                                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1700
                                    cRegisterName_OB = "OB" & "00223"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 0
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            runIdx = 1800
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1800
                                    cRegisterName_OB = "OB" & "00226"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 0
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            Thread.Sleep(50) : runIdx = 1900
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 1900
                                    cRegisterName_OB = "OB" & "0022A"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        Reg_ShortData(0) = 1
                                        RegisterDataNumber = 1
                                        rc = ymcSetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0))
                                        If rc = MP_SUCCESS Then
                                            Thread.Sleep(100) : runIdx = 2000
                                        Else
                                            MsgBox("Error ymcSetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 2000
                                    cRegisterName_OB = "IB" & "12A"
                                    rc = ymcGetRegisterDataHandle(cRegisterName_OB, hRegister_OB)
                                    If rc = MP_SUCCESS Then
                                        RegisterDataNumber = 1
                                        rc = ymcGetRegisterData(hRegister_OB, RegisterDataNumber, Reg_ShortData(0), ReadDataNumber)
                                        If rc = MP_SUCCESS Then
                                            If Reg_ShortData(0) = 0 Then runIdx = 2100
                                        Else
                                            MsgBox("Error ymcGetRegisterData OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                        End If
                                    Else
                                        MsgBox("Error ymcGetRegisterDataHandle OB" & vbCrLf & "ErrorCode [" & Hex(rc) & "]") : Exit Sub
                                    End If
                                Case 2100
                                    Thread.Sleep(5 * 1000) : runIdx = 0
                                    .Status.HomeRdy = enumMotionFlag.eReady
                            End Select
                        Loop Until (runIdx = 0)
                    Else
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            Do
                                Select Case runIdx
                                    Case 100
                                        '// Executes servo ON.
                                        If .Mode.IsServo Then rc = ymcServoControl(devicehandle, CShort(ApiDefs.SERVO_ON), COMMUNICATION_TIME_OUT)
                                        If rc = MP_SUCCESS Then
                                            motionData.MoveType = 0
                                            motionData.VelocityType = CShort(ApiDefs.VTYPE_UNIT_PAR)    '// Speed [reference unit/s]
                                            motionData.AccDecType = CShort(ApiDefs.ATYPE_UNIT_PAR)          '// Time constant specified [ms]
                                            motionData.DataType = 0                             '// All parameters directly specified
                                            motionData.Acceleration = CInt(.Home.Acc / 2)                       '// Acceleration time constant [ms]
                                            motionData.Deceleration = CInt(.Home.Acc / 2)                       '// Deceleration time constant [ms]
                                            motionData.ApproachVelocity = CInt(psudodir * .Home.HighSpeed)        '// Approach speed [reference unit/s]
                                            motionData.CreepVelocity = CInt(-1 * psudodir * .Home.HighSpeed)             '// Creep speed [reference unit/s]
                                            motionData.MaxVelocity = CInt(-1 * psudodir * .Home.HighSpeed)
                                            motionData.Velocity = CInt(-1 * psudodir * .Home.HighSpeed)                  '// Speed [reference unit/s]
                                            positionData.DataType = ApiDefs.DATATYPE_IMMEDIATE
                                            positionData.PositionData = 0
                                            waitForCompletion = CShort(ApiDefs.POSITIONING_COMPLETED)
                                            rc = ymcMoveHomePosition(devicehandle, motionData, positionData, homeMethod, CShort(ApiDefs.DIRECTION_POSITIVE), 0, axisID.ToString(), waitForCompletion, 0)
                                            If rc = MP_SUCCESS Then
                                                Do
                                                    rc = ymcGetMotionParameterValue(.ThreadID, CShort(ApiDefs.MONITOR_PARAMETER), eParameterNo.PositionManagementStatus, pStoredValue)
                                                    If rc = MP_SUCCESS Then
                                                        If (pStoredValue And 2) = 2 Then Exit Do
                                                    Else
                                                        Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                                        Call MsgBox("ymcGetMotionParameterValue" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                                        runIdx = 0 : Exit Do
                                                    End If
                                                Loop
                                                If runIdx = 100 Then
                                                    Thread.Sleep(500)
                                                    Dim position As POSITION_DATA
                                                    position.DataType = ApiDefs.DATATYPE_IMMEDIATE
                                                    position.PositionData = 0
                                                    rc = ymcDefinePosition(devicehandle, position)
                                                    If rc = MP_SUCCESS Then
                                                        runIdx = 0
                                                        Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                                        .Status.HomeRdy = enumMotionFlag.eReady
                                                    End If
                                                Else
                                                    Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                                    Call MsgBox("ymcMoveHomePosition" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                                End If
                                            Else
                                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                                Call MsgBox("ymcMoveHomePosition" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                                runIdx = 0
                                            End If
                                        Else
                                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                            Call MsgBox("ymcServoControl" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                                            runIdx = 0
                                        End If
                                End Select
                            Loop Until (runIdx = 0)
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
                .Status.HomeRdy = enumMotionFlag.eReady
            Finally
                .IsThreadFinished = True
            End Try
        End With
    End Sub
    Friend Sub MoveLinear(ByVal AxisID1 As Integer, ByVal AxisID2 As Integer, ByVal EndX As Double, ByVal EndY As Double, ByRef pResult As enumMotionFlag) Implements IPseudoMotion.MoveLinear
        Dim status As enumMotionFlag
        Dim axisAry(0 To 1) As Integer
        axisAry(0) = AxisID1
        axisAry(1) = AxisID2
        pResult = enumMotionFlag.eNotSent
        If ChkMultiStop(AxisID1, AxisID2) = enumMotionFlag.eReady Then
            Call ChkSwLimit(AxisID1, EndX, status)
            If status = enumMotionFlag.eHigh Then
                Call ChkSwLimit(AxisID2, EndY, status)
                If status = enumMotionFlag.eHigh Then
                    Do
                    Loop Until m_Axis(AxisID1).IsThreadFinished
                    m_Axis(AxisID1).IsThreadFinished = False : m_Axis(AxisID1).Status.MoveRdy = enumMotionFlag.eNotReady
                    m_Axis(AxisID1).EndX = EndX
                    m_Axis(AxisID1).EndY = EndY
                    System.Threading.ThreadPool.QueueUserWorkItem(New System.Threading.WaitCallback(AddressOf MoveLinear1), axisAry)
                    Do
                    Loop Until m_Axis(AxisID1).IsThreadStarted
                    pResult = enumMotionFlag.eSent
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
    End Sub
    Private Sub MoveLinear1(ByVal StateInfo As Object)
        Dim waitForCompletion As Short
        Dim motionData As MOTION_DATA
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim positionData(0 To 1) As POSITION_DATA         '// POSITION_DATA structure (for 3 axes)
        Dim controllerhandle As Integer
        Dim axishandle(0 To 1) As Integer
        Dim devicehandle As Integer
        Dim runMaxVelocity As Integer
        Dim AccelerationExteleration As Integer
        Dim DecelerationExteleration As Integer
        Dim runVelocity As Integer
        Dim endX As Integer
        Dim endY As Integer
        Dim axisID1 As Integer = StateInfo(0)
        Dim axisID2 As Integer = StateInfo(1)
        With m_Axis(axisID1)
            Try
                .Status.MoveRdy = enumMotionFlag.eNotReady
                .IsThreadFinished = False
                .IsThreadStarted = True
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000
                If .IsExternalParameters Then
                    runMaxVelocity = CInt(.Speed.MaxVelExt)
                    AccelerationExteleration = CInt(.Speed.AccExt)
                    DecelerationExteleration = CInt(.Speed.DecExt)
                    runVelocity = CInt(.Speed.MaxVelExt)
                Else
                    runMaxVelocity = CInt(.Speed.MaxVelLinear)
                    AccelerationExteleration = CInt(.Speed.AccLinear)
                    DecelerationExteleration = CInt(.Speed.DecLinear)
                    runVelocity = CInt(.Speed.MaxVelLinear)
                End If
                endX = CInt(.EndX * .Param.SwScale)
                endY = CInt(.EndY * m_Axis(axisID2).Param.SwScale)
                rc = ymcOpenController(comDevice, controllerhandle)
                If rc = MP_SUCCESS Then
                    axishandle(1) = m_Axis(axisID2).ThreadID
                    axishandle(0) = .ThreadID
                    rc = ymcDeclareDevice(2, axishandle(0), devicehandle)
                    If rc = MP_SUCCESS Then
                        ' 軸数分のパラメータを設定する
                        motionData.CoordinateSystem = CShort(ApiDefs.WORK_SYSTEM) 'MACHINE_SYSTEM   '// Work coordinate system
                        motionData.MoveType = CShort(ApiDefs.MTYPE_ABSOLUTE)    'MTYPE_RELATIVE     '// Incremental value specified
                        motionData.VelocityType = CShort(ApiDefs.VTYPE_UNIT_PAR)     '// Speed [reference unit/s]
                        motionData.AccDecType = CShort(ApiDefs.ATYPE_UNIT_PAR)  '//Acceleration [reference unit/s2]         '// ATYPE_TIME-Time constant specified [ms]
                        motionData.FilterType = CShort(ApiDefs.FTYPE_S_CURVE)        '// Moving average filter (simplified S-curve)
                        motionData.DataType = 0                              '// All parameters directly specified
                        motionData.MaxVelocity = runMaxVelocity
                        motionData.Acceleration = AccelerationExteleration                 '// Acceleration time constant [ms]
                        motionData.Deceleration = DecelerationExteleration                 '// Deceleration time constant [ms]
                        motionData.FilterTime = 10                           '// Filter time [0.1 ms]
                        motionData.Velocity = runMaxVelocity                     '// Speed [reference unit/s]
                        '/* Not Use MotionData(MasterAxis).ApproachVelocity = 0 */
                        '/* Not Use MotionData(MasterAxis).CreepVelocity    = 0 */
                        positionData(0).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        positionData(0).PositionData = endX
                        positionData(1).DataType = ApiDefs.DATATYPE_IMMEDIATE
                        positionData(1).PositionData = endY
                        waitForCompletion = CShort(ApiDefs.POSITIONING_COMPLETED)
                        ' 直線補間を実行する
                        rc = ymcMoveLinear(devicehandle, motionData, positionData(0), 0, "L" + CStr(0), waitForCompletion, 0)
                        ' 異常判断処理
                        If rc = MP_SUCCESS Then
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            .Status.MoveRdy = enumMotionFlag.eReady
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcMoveLinear" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    Else
                        Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                        Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                    End If
                Else
                    Call ymcCloseController(controllerhandle)
                    Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
                .Status.MoveRdy = enumMotionFlag.eReady
            Finally
                .IsThreadFinished = True
            End Try
        End With
    End Sub
    Friend Sub ServoOff(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOff
        '//============================================================================ To Contents of Processing
        '// Executes servo OFF.
        '// Servo OFF is executed using the device handle created when the positioning starts.
        '// All the set axes connected are servo OFF.
        '//============================================================================
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        With m_Axis(AxisID)
            Try
                '//============================================================================ To Contents of Processing
                '// Sets the ymcOpenController parameters.
                '//============================================================================
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000
                If Not m_Axis(AxisID).Mode.IsServo Then
                Else
                    rc = ymcOpenController(comDevice, controllerhandle)
                    If rc = MP_SUCCESS Then
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            rc = ymcServoControl(devicehandle, CShort(ApiDefs.SERVO_OFF), COMMUNICATION_TIME_OUT)
                            If rc = MP_SUCCESS Then
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcServoControl" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    Else
                        Call ymcCloseController(controllerhandle)
                        Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                    End If
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            End Try
        End With
    End Sub
    Friend Sub ServoOn(ByVal AxisID As Integer) Implements IPseudoMotion.ServoOn
        '//============================================================================ To Contents of Processing
        '// Executes servo ON.
        '// Servo ON is executed using the created device handle.
        '// All the set axes connected are servo ON.
        '//============================================================================
        Dim rc As Integer          '// Motion API return value
        Dim comDevice As COM_DEVICE '// The ymcOpenController setting structure
        Dim controllerhandle As Integer
        Dim devicehandle As Integer
        With m_Axis(AxisID)
            Try
                '//============================================================================ To Contents of Processing
                '// Sets the ymcOpenController parameters.
                '//============================================================================
                comDevice.ComDeviceType = CShort(ApiDefs.COMDEVICETYPE_PCI_MODE)
                comDevice.PortNumber = 1
                comDevice.CpuNumber = 1
                comDevice.NetworkNumber = 0
                comDevice.StationNumber = 0
                comDevice.UnitNumber = 0
                comDevice.IPAddress = 0
                comDevice.Timeout = 10000
                If Not .Mode.IsServo Then
                Else
                    rc = ymcOpenController(comDevice, controllerhandle)
                    If rc = MP_SUCCESS Then
                        rc = ymcDeclareDevice(1, .ThreadID, devicehandle)
                        If rc = MP_SUCCESS Then
                            rc = ymcServoControl(devicehandle, CShort(ApiDefs.SERVO_OFF), COMMUNICATION_TIME_OUT)
                            Thread.Sleep(1000)
                            rc = ymcServoControl(devicehandle, CShort(ApiDefs.SERVO_ON), COMMUNICATION_TIME_OUT)
                            If rc = MP_SUCCESS Then
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Else
                                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                                Call MsgBox("ymcServoControl" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                            End If
                        Else
                            Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                            Call MsgBox("ymcDeclareDevice" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                        End If
                    Else
                        Call ymcCloseController(controllerhandle)
                        Call MsgBox("ymcOpenController" & vbCrLf & "ErrorCode [" & Hex(rc) & "]" & vbCrLf & GetErrMsg(rc), MsgBoxStyle.Information, "Information")
                    End If
                End If
            Catch ex As Exception
                Call ymcClearDevice(devicehandle) : Call ymcCloseController(controllerhandle)
                Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error") : Call Debug.Assert(False)
            End Try
        End With
    End Sub
    Friend Sub SetContiMoveBuffer(ByVal AxisID As Integer, ByRef pContiLogic As Short) Implements IPseudoMotion.SetContiMoveBuffer

    End Sub
    Friend Sub SetHomeOffset(ByVal AxisID As Integer) Implements IPseudoMotion.SetHomeOffset

    End Sub
    Friend Sub SetMode(ByVal AxisID As Integer) Implements IPseudoMotion.SetMode

    End Sub
    Friend Sub SlowStop(ByVal AxisID As Integer) Implements IPseudoMotion.SlowStop

    End Sub
#End Region
End Class
