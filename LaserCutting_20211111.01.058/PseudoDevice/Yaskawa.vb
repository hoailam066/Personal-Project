Imports System.Runtime.InteropServices
Imports System.Runtime.InteropServices.UnmanagedType
Imports System.Threading
Imports Xmler
Public Enum eDirection
    counterclockwise = 0
    Clockwise = 1
End Enum
Friend Enum eErrMsg
    MP_SUCCESS = 0
    MP_FAIL
    WDT_OVER_ERR
    MANUAL_RESET_ERR
    TLB_MLTHIT_ERR
    UBRK_ERR
    ADR_RD_ERR
    TLB_MIS_RD_ERR
    TLB_PROTECTION_RD_ERR
    GENERAL_INVALID_INS_ERR
    SLOT_ERR
    GENERAL_FPU_DISABLE_ERR
    SLOT_FPU_ERR
    ADR_WR_ERR
    TLB_MIS_WR_ERR
    TLB_PROTECTION_WR_ERR
    FPU_EXP_ERR
    INITIAL_PAGE_EXP_ERR
    ROM_ERR
    RAM_ERR
    MPU_ERR
    FPU_ERR
    CERF_ERR
    EXIO_ERR
    BUSIF_ERR
    ALM_NO_ALM
    ALM_MK_DEBUG
    ALM_MK_ROUND_ERR
    ALM_MK_FSPEED_OVER
    ALM_MK_FSPEED_NOSPEC
    ALM_MK_PRM_OVER
    ALM_MK_ARCLEN_OVER
    ALM_MK_VERT_NOSPEC
    ALM_MK_HORZ_NOSPEC
    ALM_MK_TURN_OVER
    ALM_MK_RADIUS_OVER
    ALM_MK_CENTER_ERR
    ALM_MK_BLOCK_OVER
    ALM_MK_MAXF_NOSPEC
    ALM_MK_TDATA_ERR
    ALM_MK_REG_ERR
    ALM_MK_COMMAND_CODE_ERR
    ALM_MK_AXIS_CONFLICT
    ALM_MK_POSMAX_OVER
    ALM_MK_DIST_OVER
    ALM_MK_MODE_ERR
    ALM_MK_CMD_CONFLICT
    ALM_MK_RCMD_CONFLICT
    ALM_MK_CMD_MODE_ERR
    ALM_MK_CMD_NOT_ALLOW
    ALM_MK_CMD_DEN_FAIL
    ALM_MK_H_MOVE_ERR
    ALM_MK_MOVE_NOT_SUPPORT
    ALM_MK_EVENT_NOT_SUPPORT
    ALM_MK_ACTION_NOT_SUPPORT
    ALM_MK_MOVE_TYPE_ERR
    ALM_MK_VTYPE_ERR
    ALM_MK_ATYPE_ERR
    ALM_MK_HOMING_METHOD_ERR
    ALM_MK_ACC_ERR
    ALM_MK_DEC_ERR
    ALM_MK_POS_TYPE_ERR
    ALM_MK_INVALID_EVENT_ERR
    ALM_MK_INVALID_ACTION_ERR
    ALM_MK_MOVE_NOT_ACTIVE
    ALM_MK_MOVELIST_NOT_ACTIVE
    ALM_MK_TBL_INVALID_DATA
    ALM_MK_TBL_INVALID_SEG_NUM
    ALM_MK_TBL_INVALID_AXIS_NUM
    ALM_MK_TBL_INVALID_ST_SEG
    ALM_MK_STBL_INVALID_EXE
    ALM_MK_DTBL_DUPLICATE_EXE
    ALM_MK_LATCH_CONFLICT
    ALM_MK_INVALID_AXISTYPE
    ALM_MK_NOT_SVCRDY
    ALM_MK_NOT_SVCRUN
    ALM_MK_MDALARM
    ALM_MK_SUPERPOSE_MASTER_ERR
    ALM_MK_SUPERPOSE_SLAVE_ERR
    ALM_MK_MDWARNING
    ALM_MK_MDWARNING_POSERR
    ALM_MK_NOT_INFINITE_ABS
    ALM_MK_INVALID_LOGICAL_NUM
    ALM_MK_MAX_VELOCITY_ERR
    ALM_MK_VELOCITY_ERR
    ALM_MK_APPROACH_ERR
    ALM_MK_CREEP_ERR
    ALM_MK_OS_ERR_MBOX1
    ALM_MK_OS_ERR_MBOX2
    ALM_MK_OS_ERR_SEND_MSG1
    ALM_MK_OS_ERR_SEND_MSG2
    ALM_MK_OS_ERR_SEND_MSG3
    ALM_MK_OS_ERR_SEND_MSG4
    ALM_MK_ACTION_ERR1
    ALM_MK_ACTION_ERR2
    ALM_MK_ACTION_ERR3
    ALM_MK_RCV_INV_MSG1
    ALM_MK_RCV_INV_MSG2
    ALM_MK_RCV_INV_MSG3
    ALM_MK_RCV_INV_MSG4
    ALM_MK_RCV_INV_MSG5
    ALM_MK_RCV_INV_MSG6
    ALM_MK_RCV_INV_MSG7
    ALM_MK_RCV_INV_MSG8
    ALM_MK_AXIS_HANDLE_ERROR
    ALM_MK_SLAVE_USED_AS_MASTER
    ALM_MK_MASTER_USED_AS_SLAVE
    ALM_MK_SLAVE_HAS_2_MASTERS
    ALM_MK_SLAVE_HAS_NOT_WORK
    ALM_MK_PARAM_OUT_OF_RANGE
    ALM_MK_NNUM_MAX_OVER
    ALM_MK_FGNTBL_INVALID
    ALM_MK_PARAM_OVERFLOW
    ALM_MK_ALREADY_COMMANDED
    ALM_MK_MULTIPLE_SHIFTS
    ALM_MK_CAMTBL_INVALID
    ALM_MK_ABORTED_BY_STOPMTN
    ALM_MK_HMETHOD_INVALID
    ALM_MK_MASTER_INVALID
    ALM_MK_DATA_HANDLE_INVALID
    ALM_MK_UNKNOWN_CAM_GEAR_ERR
    ALM_MK_REG_SIZE_INVALID
    ALM_MK_ACTION_HANDLE_ERROR
    ALM_MM_OS_ERR_MBOX1
    ALM_MM_OS_ERR_SEND_MSG1
    ALM_MM_OS_ERR_SEND_MSG2
    ALM_MM_OS_ERR_RCV_MSG1
    ALM_MM_MK_BUSY
    ALM_MM_RCV_INV_MSG1
    ALM_MM_RCV_INV_MSG2
    ALM_MM_RCV_INV_MSG3
    ALM_MM_RCV_INV_MSG4
    ALM_MM_RCV_INV_MSG5
    ALM_IM_DEVICEID_ERR
    ALM_IM_REGHANDLE_ERR
    ALM_IM_GLOBALHANDLE_ERR
    ALM_IM_DEVICETYPE_ERR
    ALM_IM_OFFSET_ERR
    AM_ER_UNDEF_COMMAND
    AM_ER_UNDEF_CMNDTYPE
    AM_ER_UNDEF_OBJTYPE
    AM_ER_UNDEF_HANDLETYPE
    AM_ER_UNDEF_PKTDAT
    AM_ER_UNDEF_AXIS
    AM_ER_MSGBUF_GET_FAULT
    AM_ER_ACTSIZE_GET_FAULT
    AM_ER_APIBUF_GET_FAULT
    AM_ER_MOVEOBJ_GET_FAULT
    AM_ER_EVTTBL_GET_FAULT
    AM_ER_ACTTBL_GET_FAULT
    AM_ER_1BY1APIBUF_GET_FAULT
    AM_ER_AXSTBL_GET_FAULT
    AM_ER_SUPERPOSEOBJ_GET_FAULT
    AM_ER_SUPERPOSEOBJ_CLEAR_FAULT
    AM_ER_AXIS_IN_USE
    AM_ER_HASHTBL_GET_FAULT
    AM_ER_UNMATCH_OBJHNDL
    AM_ER_UNMATCH_OBJECT
    AM_ER_UNMATCH_APIBUF
    AM_ER_UNMATCH_MSGBUF
    AM_ER_UNMATCH_ACTBUF
    AM_ER_UNMATH_SEQUENCE
    AM_ER_UNMATCH_1BY1APIBUF
    AM_ER_UNMATCH_MOVEOBJTABLE
    AM_ER_UNMATCH_MOVELISTTABLE
    AM_ER_UNMATCH_MOVELIST_OBJECT
    AM_ER_UNMATCH_MOVELIST_OBJHNDL
    AM_ER_UNGET_MOVEOBJTABLE
    AM_ER_UNGET_MOVELISTTABLE
    AM_ER_UNGET_1BY1APIBUFTABLE
    AM_ER_NOEMPTYTBL_ERROR
    AM_ER_NOTGETSEM_ERROR
    AM_ER_NOTGETTBLADD_ERROR
    AM_ER_NOTWRTTBL_ERROR
    AM_ER_TBLINDEX_ERROR
    AM_ER_ILLTBLTYPE_ERROR
    AM_ER_UNSUPORTED_EVENT
    AM_ER_WRONG_SEQUENCE
    AM_ER_MOVEOBJ_BUSY
    AM_ER_MOVELIST_BUSY
    AM_ER_MOVELIST_ADD_FAULT
    AM_ER_CONFLICT_PHI_AXS
    AM_ER_CONFLICT_LOG_AXS
    AM_ER_PKTSTS_ERROR
    AM_ER_CONFLICT_NAME
    AM_ER_ILLEGAL_NAME
    AM_ER_SEMAPHORE_ERROR
    AM_ER_LOG_AXS_OVER
    IM_STATION_ERR
    IM_IO_ERR
    MP_FILE_ERR_GENERAL
    MP_FILE_ERR_NOT_SUPPORTED
    MP_FILE_ERR_INVALID_ARGUMENT
    MP_FILE_ERR_INVALID_HANDLE
    MP_FILE_ERR_NO_FILE
    MP_FILE_ERR_INVALID_PATH
    MP_FILE_ERR_EOF
    MP_FILE_ERR_PERMISSION_DENIED
    MP_FILE_ERR_TOO_MANY_FILES
    MP_FILE_ERR_FILE_BUSY
    MP_FILE_ERR_TIMEOUT
    MP_FILE_ERR_BAD_FS
    MP_FILE_ERR_FILESYSTEM_FULL
    MP_FILE_ERR_INVALID_LFM
    MP_FILE_ERR_TOO_MANY_LFM
    MP_FILE_ERR_INVALID_PDM
    MP_FILE_ERR_INVALID_MEDIA
    MP_FILE_ERR_TOO_MANY_PDM
    MP_FILE_ERR_TOO_MANY_MEDIA
    MP_FILE_ERR_WRITE_PROTECTED
    MP_FILE_ERR_INVALID_DEVICE
    MP_FILE_ERR_DEVICE_IO
    MP_FILE_ERR_DEVICE_BUSY
    MP_FILE_ERR_NO_CARD
    MP_FILE_ERR_CARD_POWER
    MP_CARD_SYSTEM_ERR
    ERROR_CODE_GET_DIREC_OFFSET
    ERROR_CODE_GET_DIREC_INFO
    ERROR_CODE_FUNC_TABLE
    ERROR_CODE_SLEEP_TASK
    ERROR_CODE_DEVICE_HANDLE_FULL
    ERROR_CODE_ALLOC_MEMORY
    ERROR_CODE_BUFCOPY
    ERROR_CODE_GET_COMMEM_OFFSET
    ERROR_CODE_CREATE_SEMPH
    ERROR_CODE_DELETE_SEMPH
    ERROR_CODE_LOCK_SEMPH
    ERROR_CODE_UNLOCK_SEMPH
    ERROR_CODE_PACKETSIZE_OVER
    ERROR_CODE_UNREADY
    ERROR_CODE_CPUSTOP
    ERROR_CODE_CNTRNO
    ERROR_CODE_SELECTION
    ERROR_CODE_LENGTH
    ERROR_CODE_OFFSET
    ERROR_CODE_DATACOUNT
    ERROR_CODE_DATREAD
    ERROR_CODE_DATWRITE
    ERROR_CODE_BITWRITE
    ERROR_CODE_DEVCNTR
    ERROR_CODE_NOTINIT
    ERROR_CODE_SEMPHLOCK
    ERROR_CODE_SEMPHUNLOCK
    ERROR_CODE_DRV_PROC
    ERROR_CODE_GET_DRIVER_HANDLE
    ERROR_CODE_SEND_MSG
    ERROR_CODE_RECV_MSG
    ERROR_CODE_INVALID_RESPONSE
    ERROR_CODE_INVALID_ID
    ERROR_CODE_INVALID_STATUS
    ERROR_CODE_INVALID_CMDCODE
    ERROR_CODE_INVALID_SEQNO
    ERROR_CODE_SEND_RETRY_OVER
    ERROR_CODE_RECV_RETRY_OVER
    ERROR_CODE_RESPONSE_TIMEOUT
    ERROR_CODE_WAIT_FOR_EVENT
    ERROR_CODE_EVENT_OPEN
    ERROR_CODE_EVENT_RESET
    ERROR_CODE_EVENT_READY
    ERROR_CODE_PROCESSNUM
    ERROR_CODE_GET_PROC_INFO
    ERROR_CODE_THREADNUM
    ERROR_CODE_GET_THRD_INFO
    ERROR_CODE_CREATE_MBOX
    ERROR_CODE_DELETE_MBOX
    ERROR_CODE_GET_TASKID
    ERROR_CODE_NO_THREADINFO
    ERROR_CODE_COM_INITIALIZE
    ERROR_CODE_COMDEVICENUM
    ERROR_CODE_GET_COM_DEVICE_HANDLE
    ERROR_CODE_COM_DEVICE_FULL
    ERROR_CODE_CREATE_PANELOBJ
    ERROR_CODE_OPEN_PANELOBJ
    ERROR_CODE_CLOSE_PANELOBJ
    ERROR_CODE_PROC_PANELOBJ
    ERROR_CODE_CREATE_CNTROBJ
    ERROR_CODE_OPEN_CNTROBJ
    ERROR_CODE_CLOSE_CNTROBJ
    ERROR_CODE_PROC_CNTROBJ
    ERROR_CODE_CREATE_COMDEV_MUTEX
    ERROR_CODE_CREATE_COMDEV_MAPFILE
    ERROR_CODE_OPEN_COMDEV_MAPFILE
    ERROR_CODE_NOT_OBJECT_TYPE
    ERROR_CODE_COM_NOT_OPENED
    ERROR_CODE_PNLCMD_CPU_CONTROL
    ERROR_CODE_PNLCMD_SFILE_READ
    ERROR_CODE_PNLCMD_SFILE_WRITE
    ERROR_CODE_PNLCMD_REGISTER_READ
    ERROR_CODE_PNLCMD_REGISTER_WRITE
    ERROR_CODE_PNLCMD_API_SEND
    ERROR_CODE_PNLCMD_API_RECV
    ERROR_CODE_PNLCMD_NO_RESPONSE
    ERROR_CODE_PNLCMD_PACKET_READ
    ERROR_CODE_PNLCMD_PACKET_WRITE
    ERROR_CODE_PNLCMD_STATUS_READ
    ERROR_CODE_NOT_CONTROLLER_RDY
    ERROR_CODE_DOUBLE_CMD
    ERROR_CODE_DOUBLE_RCMD
    ERROR_CODE_FILE_NOT_OPENED
    ERROR_CODE_OPENFILE_NUM
    MP_CTRL_SYS_ERROR
    MP_CTRL_PARAM_ERR
    MP_CTRL_FILE_NOT_FOUND
    MP_NOTMOVEHANDLE
    MP_NOTTIMERHANDLE
    MP_NOTINTERRUPT
    MP_NOTEVENTHANDLE
    MP_NOTMESSAGEHANDLE
    MP_NOTUSERFUNCTIONHANDLE
    MP_NOTACTIONHANDLE
    MP_NOTSUBSCRIBEHANDLE
    MP_NOTDEVICEHANDLE
    MP_NOTAXISHANDLE
    MP_NOTMOVELISTHANDLE
    MP_NOTTRACEHANDLE
    MP_NOTGLOBALDATAHANDLE
    MP_NOTSUPERPOSEHANDLE
    MP_NOTCONTROLLERHANDLE
    MP_NOTFILEHANDLE
    MP_NOTREGISTERDATAHANDLE
    MP_NOTALARMHANDLE
    MP_NOTCAMHANDLE
    MP_NOTHANDLE
    MP_NOTEVENTTYPE
    MP_NOTDEVICETYPE
    MP_NOTDATAUNITSIZE
    MP_NOTDEVICE
    MP_NOTACTIONTYPE
    MP_NOTPARAMNAME
    MP_NOTDATATYPE
    MP_NOTBUFFERTYPE
    MP_NOTMOVETYPE
    MP_NOTANGLETYPE
    MP_NOTDIRECTION
    MP_NOTAXISTYPE
    MP_NOTUNITTYPE
    MP_NOTCOMDEVICETYPE
    MP_NOTCONTROLTYPE
    MP_NOTFILETYPE
    MP_NOTSEMAPHORETYPE
    MP_NOTSYSTEMOPTION
    MP_TIMEOUT_ERR
    MP_TIMEOUT
    MP_NOTSUBSCRIBETYPE
    MP_NOTSCANTYPE
    MP_DEVICEOFFSETOVER
    MP_DEVICEBITOFFSETOVER
    MP_UNITCOUNTOVER
    MP_COMPAREVALUEOVER
    MP_FCOMPAREVALUEOVER
    MP_EVENTCOUNTOVER
    MP_VALUEOVER
    MP_FVALUEOVER
    MP_PSTOREDVALUEOVER
    MP_PSTOREDFVALUEOVER
    MP_SIZEOVER
    MP_RECEIVETIMEROVER
    MP_RECNUMOVER
    MP_PARAMOVER
    MP_FRAMEOVER
    MP_RADIUSOVER
    MP_CONTROLLERNOOVER
    MP_AXISNUMOVER
    MP_DIGITOVER
    MP_CALENDARVALUEOVER
    MP_OFFSETOVER
    MP_NUMBEROVER
    MP_RACKOVER
    MP_SLOTOVER
    MP_FIXVALUEOVER
    MP_REGISTERINFOROVER
    PC_MEMORY_ERR
    MP_NOCOMMUDEVICETYPE
    MP_NOTPROTOCOLTYPE
    MP_NOTFUNCMODE
    MP_MYADDROVER
    MP_NOTPORTTYPE
    MP_NOTPROTMODE
    MP_NOTCHARSIZE
    MP_NOTPARITYBIT
    MP_NOTSTOPBIT
    MP_NOTBAUDRAT
    MP_TRANSDELAYOVER
    MP_PEERADDROVER
    MP_SUBNETMASKOVER
    MP_GWADDROVER
    MP_DIAGPORTOVER
    MP_PROCRETRYOVER
    MP_TCPZEROWINOVER
    MP_TCPRETRYOVER
    MP_TCPFINOVER
    MP_IPASSEMBLEOVER
    MP_MAXPKTLENOVER
    MP_PEERPORTOVER
    MP_MYPORTOVER
    MP_NOTTRANSPROT
    MP_NOTAPPROT
    MP_NOTCODETYPE
    MP_CYCTIMOVER
    MP_NOTIOMAPCOM
    MP_NOTIOTYPE
    MP_IOOFFSETOVER
    MP_IOSIZEOVER
    MP_TIOSIZEOVER
    MP_MEMORY_ERR
    MP_NOTPTR
    MP_TABLEOVER
    MP_ALARM
    MP_MEMORYOVER
    MP_EXEC_ERR
    MP_NOTLOGICALAXIS
    MP_NOTSUPPORTED
    MP_ILLTEXT
    MP_NOFILENAME
    MP_NOTREGSTERNAME
    MP_FILEALREADYOPEN
    MP_NOFILEPACKET
    MP_NOTFILEPACKETSIZE
    MP_NOTUSERFUNCTION
    MP_NOTPARAMETERTYPE
    MP_ILLREGHANDLETYPE
    MP_ILLREGTYPE
    MP_ILLREGSIZE
    MP_REGNUMOVER
    MP_RELEASEWAIT
    MP_PRIORITYOVER
    MP_NOTCHANGEPRIORITY
    MP_SEMAPHOREOVER
    MP_NOTSEMAPHOREHANDLE
    MP_SEMAPHORELOCKED
    MP_CONTINUE_RELEASEWAIT
    MP_NOTTABLENAME
    MP_ILLTABLETYPE
    MP_TIMEOUTVALUEOVER
    MP_OTHER_ERR
End Enum
Friend Enum eParameterNo
    PositionManagementStatus = 12
    TPOS = 14 'Machinecoordinatetargetposition  
    MPOS = 18 'Machinecoordinateposition 
    APOS = 22 'Machinecoordinatefeedbackposition
End Enum

#Region "Yaskawa Enum"
Friend Enum ApiDefs
    ' AxisType
    REAL_AXIS = 1                             ' Actual servo axis
    VIRTUAL_AXIS = 2                          ' Virtual servo axis
    EXTERNAL_ENCODER = 3                      ' External encoder

    ' SpecifyType
    PHYSICALAXIS = 1                          ' Physical axis specified
    AxisName = 2                              ' Axis name specified
    LOGICALAXIS = 3                           ' Logical axis specified

    HMETHOD_DEC1_C = 0                        ' 0: DEC1 + phase-C pulse method
    HMETHOD_ZERO = 1                          ' 1: ZERO signal method
    HMETHOD_DEC1_ZERO = 2                     ' 2: DEC1 + ZERO signal method
    HMETHOD_C = 3                             ' 3: Phase-C pulse method
    HMETHOD_DEC2_ZERO = 4                     ' 4: DEC 2 + ZERO signal method
    HMETHOD_DEC1_L_ZERO = 5                   ' 5: DEC1 + LMT + ZERO signal method
    HMETHOD_DEC2_C = 6                        ' 6: DEC2 + phase-C pulse method
    HMETHOD_DEC1_L_C = 7                      ' 7: DEC 1 + LMT + phase-C pulse method
    HMETHOD_C_ONLY = 11                       ' 11: C Pulse Only
    HMETHOD_POT_C = 12                        ' 12: POT & C Pulse
    HMETHOD_POT_ONLY = 13                     ' 13: POT Only
    HMETHOD_HOMELS_C = 14                     ' 14: Home LS C Pulse
    HMETHOD_HOMELS_ONLY = 15                  ' 15: Home LS Only
    HMETHOD_NOT_C = 16                        ' 16: NOT & C Pulse
    HMETHOD_NOT_ONLY = 17                     ' 17: NOT Only
    HMETHOD_INPUT_C = 18                      ' 18: Input & C Pulse
    HMETHOD_INPUT_ONLY = 19                   ' 19: Input Only

    ' Direction
    DIRECTION_POSITIVE = 0                    ' Positive Direction
    DIRECTION_NEGATIVE = 1                    ' Negative Direction

    ' Coordinate system specified
    WORK_SYSTEM = 0                           ' 0: Workpiece coordinate system
    MACHINE_SYSTEM = 1                        ' 1: Machine coordinate system

    ' Motion type
    MTYPE_RELATIVE = 0                        ' 0: Incremental value specified, common for linear and rotary axes
    MTYPE_ABSOLUTE = 1                        ' 1: Absolute position specified, for linear axis
    MTYPE_R_SHORTEST = 2                      ' 2: Absolute position specified, for rotary axis (Rotates to the closer direction.)
    MTYPE_R_POSITIVE = 3                      ' 3: Absolute position specified, for rotary axis (forward run)
    MTYPE_R_NEGATIVE = 4                      ' 4: Absolute position specified, for rotary axis (reverse run)

    ' Data type
    DTYPE_IMMEDIATE = 0                       ' Direct designation
    DTYPE_INDIRECT = 1                        ' Indirect designation
    DTYPE_MAX_VELOCITY = &H1                  ' bit0: Designation for Max. Velocity
    DTYPE_ACCELERATION = &H2                  ' bit1: Designation for Acceleration
    DTYPE_DECELERATION = &H4                  ' bit2: Designation for Deceleration
    DTYPE_FILTER_TIME = &H8                   ' bit3: Designation for FilterTime
    DTYPE_VELOCITY = &H10                     ' bit4: Designation for Velocity
    DTYPE_APPROCH = &H20                      ' bit5: Designation for ApproachVelocity
    DTYPE_CREEP = &H40                        ' bit6: Designation for CreepVelocity

    ' Feeding speed type
    VTYPE_UNIT_PAR = 0                        ' speed [Reference unit/s]
    VTYPE_PERCENT = 1                         ' Rated speed percentage (%) specified

    ' Acceleration/deceleration type
    ATYPE_UNIT_PAR = 0                        ' Acceleration [reference unit/s2]
    ATYPE_TIME = 1                            ' Time constant [ms]
    ATYPE_KEEP = 2                            ' Current setting held

    ' Filter type
    FTYPE_S_CURVE = 0                         ' 0: Move average filter (simple S-curve)
    FTYPE_EXP = 1                             ' 1: Exponential Filter
    FTYPE_NOTIONG = 2                         ' 2: WITHOUT Filter
    FTYPE_KEEP = 3                            ' 3: Current setting held

    ' WaitForCompletion Constant definition
    DISTRIBUTION_COMPLETED = 0                ' Distribution completed
    POSITIONING_COMPLETED = 1                 ' Positioning completed
    COMMAND_STARTED = 2                       ' Command completed
    LATCH_COMMAND_STARTED = 0                 ' Latch command started
    LATCH_COMPLETED = 1                       ' Latch completed

    ' SystemOption Constant definition
    OP_BIT_ALARM_CONTINUE = &H1               ' bit0: Normal axis operation continued at alarm occurrence

    ' Target for ChangeDynamics (1: Changed, 0: Not changed)
    SUBJECT_ACC = &H1                         ' bit0: Acceleration
    SUBJECT_DEC = &H2                         ' bit1: Deceleration
    SUBJECT_POS = &H8                         ' bit3: Position
    SUBJECT_VEL = &H10                        ' bit4: Velocity

    SERVO_OFF = &H0                           ' servo OFF
    SERVO_ON = &H1                            ' Servo ON

    ' Device type
    DEVICETYPE_IO = 1                         ' I/O
    DEVICETYPE_DIRECTIO = 2                   ' Direct i / O
    DEVICETYPE_GLOBALDATA = 3                 ' Global Data
    DEVICETYPE_REGISTER = 4                   ' Register

    ' Unit data size (number of bits)
    DATAUNITSIZE_BIT = 1                      ' 1 bit
    DATAUNITSIZE_BYTE = 8                     ' BYTE = 8 bits
    DATAUNITSIZE_WORD = 16                    ' WORD = 16 bits
    DATAUNITSIZE_LONG = 32                    ' LONG = 32 bits
    DATAUNITSIZE_FLOAT = 32                   ' FLOAT= 32 bits
    DATAUNITSIZE_DOUBLE = 64                  ' DOUBLE= 64 bits

    ' Semaphore type
    SEMAPHORE_NOUSE = 0                       ' Semaphore Not Used
    SEMAPHORE_USE = 1                         ' Semaphore Used

    ' ComDevice type
    RS232C_MODE = 1                           ' RS232C
    MODEM_MODE = 2                            ' Modem
    ETHERNET_MODE = 3                         ' Ethernet
    PCI_MODE = 4                              ' PCI bus(910)
    CONTROLLER_MODE = 5                       ' Interior of Controller

    MAX_CURRENT_ALARM = 32                    ' Maximum number of alarm information that can be obtained at a time
    MAX_DEVICE_AXIS = 32                      ' Maximum number of devices that can be defined at a time
    MAX_REGISTER_BLOCK = 499                  ' Maximum number of register blocks that can be operated at a time

    ' BitEvent type
    OFF_TO_ON = 0                             ' Rising edge detection
    ON_TO_OFF = 1                             ' Falling edge detection
    LEVEL_ON = 3                              ' Level signal ON (Event only once at level ON detection)
    LEVEL_OFF = 4                             ' Level signal OFF (Event only once at level OFF detection)

    ' Gear
    MASTER_AXIS_FEEDBACK = 0                  ' Feedback Value
    MASTER_AXIS_COMMAND = 1                   ' Command Value

    ' Gear synchronization type
    SYNCH_DISTANCE = 0                        ' distance synchronization
    SYNCH_TIME = 1                            ' Time sychronization

    ' Attribute of Gear command
    GEAR_ENGAGE_COMPLETED = 0                 ' Gear control started (Engage completed)
    GEAR_COMMAND_STARTED = 1                  ' Command started

    ' Attribute of Gear status
    GEAR_NOT_ENGAGED = 0                      ' During GEAR stop
    GEAR_WAITING_ENGAGED = 1                  ' Waiting for GEAR motion
    GEAR_ENGAGED = 2                          ' During GEAR motion
    GEAR_WAITING_DISENGAGED = 4               ' Waiting for GEAR to stop

    ' Attribute of CAM command
    CAM_ENGAGE_COMPLETED = 0                  ' CAM control started
    CAM_SHIFT_COMPLETED = 0                   ' CAM phase compensation completed

    CAM_DISENGAGE_COMPLETED = 0               ' CAM control stopped
    CAM_COMMAND_STARTED = 1                   ' Command started

    ' Attribute of Cam status
    CAM_NOT_ENGAGED = 0                       ' During CAM stop
    CAM_WAITING_ENGAGED = 1                   ' Waiting for CAM motion
    CAM_ENGAGED = 2                           ' During CAM motion
    CAM_WAITING_DISENGAGED = 4                ' Waiting for CAM to stop

    ' Shift type
    SHIFT_TIME = 0                            ' Shift by time
    SHIFT_POSITION = 1                        ' Shift by position

    ' Attribute of POSITION command
    POSITION_OFFSET_COMPLETED = 0             ' Position compensation completed
    POSITION_OFFSET_COMMAND_STARTED = 1       ' Command started

    ' Table type
    CAM_TABLE = 2                             ' CAM table file name
    INTERPOLATION_TABLE = 3                   ' Interpolation table file name
    REGISTERHANDLE = 4                        ' Register Handle
    USER_FUNCTION = 5                         ' User function
    IK_FUNCTION = 6                           ' IK function

    ' Motion parameter type
    SETTING_PARAMETER = 0                     ' setting parameter
    MONITOR_PARAMETER = 1                     ' Monitor parameter
    FIXED_PARAMETER = 2                       ' Fixed parameter

    ' Cyclic event
    HIGH_SCAN = 1                             ' High-speed scan
    MIDDLE_SCAN = 2                           ' Medium-speed scan
    LOW_SCAN = 3                              ' Low-speed scan
    SCAN_OCCURED = 1                          ' Minimum

    ' Other program (task) action
    START_PROGRAM = 1                         ' Other program (task) start

    ' Move control action
    START_MOVE = 1                            ' Start
    HOLD_MOVE = 2                             ' Hold
    RELEASE_HOLD = 3                          ' Hold released
    ABORT_MOVE = 4                            ' Abort
    SKIP_MOVE = 5                             ' Skip

    ' Segment type
    SEGMENT_TYPE_EMPTY = 0                    ' Not used
    SEGMENT_TYPE_ARC = 1                      '
    SEGMENT_TYPE_HELIX = 2                    '
    SEGMENT_TYPE_LINEAR_ABS = 3               '
    SEGMENT_TYPE_LINEAR_INC = 4               '
    SEGMENT_TYPE_CONTOUR = 5                  '


    MAX_DEVICE_AXIS_NUM = 16                  ' Maximum number of device axes

    ' Circular arc type for circular and helical interpolation
    LESS_180DEGREE = &H1                      '
    GREATER_180DEGREE = &H2                   '

    ' coordinate System
    COORDINATE_SYSTEM_DEFAULT = 0             '
    COORDINATE_SYSTEM_MACHINE = 1             ' Machine coordinate system
    ' mode
    MODE_INCREMENTAL = 0                      ' INC
    MODE_ABSOLUTE = 1                         ' ABS

    ' Feeding speed type
    F_TYPE_COMMAND_UNIT = 0                   ' reference unit / Min
    F_TYPE_PARCENT = 1                        ' % specified

    ' Acceleration/deceleration type
    ACCEL_TYPE_ACCERALATION = 0               ' Acceleration
    ACCEL_TYPE_TIME_CONSTANT = 1              ' Time Constant
    ACCEL_TYPE_NO_SPECIFY = 2                 ' Not specified

    ' Move event
    MOVE_EVENT_DISTRIBUTION_START = &H1        ' Distribution starting event
    MOVE_EVENT_DISTRIBUTION_COMPLETED = &H2    ' Distribution completion event
    MOVE_EVENT_POSITION_COMPLETED = &H3        ' Positioning completion event
    MOVE_EVENT_POSITION_COINCIDED = &H4        ' Specified position passing event
    MOVE_EVENT_VELOCITY_COINCIDED = &H5        ' Speed coincidence event
    MOVE_EVENT_TORQUE_COINCIDED = &H6          ' Torque coincidence event
    MOVE_EVENT_ACCELERATION_COMPLETED = &H7    ' Acceleration completion event
    MOVE_EVENT_DECELERATION_START = &H8        ' Deceleration starting event
    MOVE_EVENT_LATCH_COMPLETED = &H9           ' Latch completion event
    MOVE_EVENT_ALARM_OCCURRED = &HA            ' Alarm occurrence event
    MOVE_EVENT_ABORT_OCCURRED = &HB            ' Abort occurrence event

    MOVE_EVENT_SPECIFIED_DISTRIBUTION_START = &H10            ' Specified record distribution started
    MOVE_EVENT_SPECIFIED_DISTRIBUTION_COMPLETED = &H11        ' Specified record distribution completed

    ' Data comparison event
    EQUAL = &H10                              ' EQUAL
    NOT_EQUAL = &H11                          ' Not equal
    GREATER = &H12                            ' GREATER than
    LESS = &H13                               ' smaller than
    GREATER_EQUAL = &H14                      ' Equal or greater than
    LESS_EQUAL = &H15                         ' Equal or smaller than

    ' Evevt within the data range
    WITHIN = &H20                             ' Within the range
    WITHOUT = &H21                            ' Out of the range

    ' Message event
    MESSAGE_RECIEVED = 1                      ' Message received

    ' Timer event
    TIMEUP = 1                                ' Time up

    ' Move Action
    MOVE_ACTION_START_MOVE = &H1              ' Start Action
    MOVE_ACTION_HOLD_MOVE = &H2               ' Hold Action
    MOVE_ACTION_RELESE_HOLD = &H3             ' Hold release action
    MOVE_ACTION_ABORT_MOVE = &H4              ' Abort Action
    MOVE_ACTION_SKIP_MOVE = &H5               ' Skip Action
    MOVE_ACTION_POSITION_VALUE = &H6          ' Target position change action
    MOVE_ACTION_SPEED_VALUE = &H7             ' Reference speed change action
    MOVE_ACTION_TORQUE_VALUE = &H8            ' Reference torque change action
    MOVE_ACTION_OVERRIDE = &H9                ' Override change action
    MOVE_ACTION_ACCELTIME_VALUE = &HA         ' Acceleration time change action
    MOVE_ACTION_DECELTIME_VALUE = &HB         ' Deceleration time change action

    ' Bit setting action
    SET_BIT_OFF = &H0                         ' Bit OFF
    SET_BIT_ON = &H1                          ' Bit ON

    ' Bit getting action
    GET_IO = 1                                ' I/O getting

    ' Data setting action
    SET_VALUE = &H10                          ' Data setting

    ' Data getting action
    GET_VALUE = &H10                          ' Data getting

    ' Message Action
    SEND_MESSAGE = 1                          ' Message sent
    RECEIVE_MESSAGE = 2                       ' Message received

    ' Timer Action
    START_TIMER = 1                           ' Start
    STOP_TIMER = 2                            ' Stop
    CONTINUE_TIMER = 3                        ' Continuous Start
    RESET_TIMER = 4                           ' Reset


    ' User function action
    START_USERFUNCTION = 1                    ' Start
    ABORT_USERFUNCTION = 2                    ' Abort

    ' Log Read - out
    SEND_LOG = 1                              ' Sending Log
    RECV_LOG = 2                              ' Receiving Log

    ' Attribute of move
    MOVE_TYPE_DISTRIBUTION_COMPLETED = &H0        ' Distribution completed
    MOVE_TYPE_POSITIONING_COMPLETED = &H1         ' Positioning completed
    MOVE_TYPE_POSITIONING_NEIGHBORHOOD = &H2      ' Second INP completed

    ' Related to event log
    EVENTLOG_BUF_TYPE_LINEAR = 0          ' Linear Buffer
    EVENTLOG_BUF_TYPE_RING = 1            ' Ring Buffer
    EVENTLOG_DATA_TYPE_LOGDATA = 1        ' Log Data
    EVENTLOG_DATA_TYPE_STARTTIME = 2      ' Starting Time
    EVENTLOG_DATA_TYPE_STOPTIME = 3       ' Stopping Time

    ' Axis type
    AXISTYPE_USE = 1                      ' Actual servo axis used
    AXISTYPE_VIRTUAL = 2                  ' Virtual servo axis used
    AXISTYPE_EXTERNAL_ENCODER = 3         ' External encoder used

    ' Specified data type when getting axis handle
    GETAXISHANDLE_PHYSICAL_NO_TYPE = 1    ' Physical axis specified
    GETAXISHANDLE_NAME_TYPE = 2           ' Name specified

    ' UnitType definition
    UNITTYPE_PULSE = 0                    ' Pulse
    UNITTYPE_MM = 1                       ' mm
    UNITTYPE_INCH = 2                     ' inch
    UNITTYPE_DEGREE = 3                   ' degree

    ' Data type
    DATATYPE_IMMEDIATE = 0                ' Direct designation
    DATATYPE_INDIRECT = 1                 ' Indirect designation

    ' ComDevice type
    COMDEVICETYPE_RS232C_MODE = 1         ' RS232C
    COMDEVICETYPE_MODEM_MODE = 2          ' Modem
    COMDEVICETYPE_ETHERNET_MODE = 3       ' Ethernet
    COMDEVICETYPE_PCI_MODE = 4            ' PCI bus(910)
    COMDEVICETYPE_CONTROLLER_MODE = 5     ' Interior of Controller
End Enum
'/*======================================================*/
'/*                                                      */
'/*  Motion Parameter( Setting )                         */
'/*                                                      */
'/*======================================================*/
Friend Enum ApiDefs_SetPrm
    SER_RUNMOD = 1                        ' OWXX00 : Motion mode setting
    SER_SVRUNCMD = 2                      ' OWXX01 : Servo drive operation command setting
    SER_TLIMP = 3                         ' OWXX02 : TORQUE LIMIT PLUS SIDE
    SER_TLIMN = 4                         ' OWXX03 : TORQUE LIMIT MINUS SIDE
    SER_NLIMP = 5                         ' OWXX04 : SPEED LIMIT PLUS SIDE
    SER_NLIMN = 6                         ' OWXX05 : SPEED LIMIT MINUS SIDE
    SER_ABSOFF = 7                        ' OLXX06 : ABS. ORG. OFFSET
    SER_COINDAT = 9                       ' OLXX08 : COIN DATA               <YC_7>
    SER_NAPR = 11                         ' OWXX0A : APROACH SPEED           <YC_7>
    SER_NCLP = 12                         ' OWXX0B : CLEEP SPEED             <YC_7>
    SER_NACC = 13                         ' OWXX0C : ACCELARATING TIME       <YC_7>
    SER_NDCC = 14                         ' OWXX0D : DECREACING TIME         <YC_7>
    SER_PEXT = 15                         ' OWXX0E : POSITION EXTENT         <YC_7>
    SER_EOV = 16                          ' OWXX0F : DEVIATION OVER RANGE    <YC_7>
    SER_KP = 17                           ' OWXX10 : SOFT FEED BACK RATE     <YC_7>
    SER_KF = 18                           ' OWXX11 : SOFT FEED FOWARD RATE   <YC_7>
    SER_XREF = 19                         ' OLXX12 : ABS. POSITION REF       <YC_7>
    SER_NNUM = 21                         ' OWXX14 : AVERAGING TIMES         <YC_7>
    SER_NREF = 22                         ' OWXX15 : speed reference
    SER_PHBIAS = 23                       ' OLXX16 : PHASE OFFSET            <YC_7>
    SER_NCOM = 25                         ' OWXX18 : SPEED BIAS REF          <YC_7>
    SER_PV = 26                           ' OWXX19 : PROPORTIONAL_GAIN       <YC_7>
    SER_TI = 27                           ' OWXX1A : TI                      <YC_7>
    SER_TREF = 28                         ' OWXX1B : TORQUE REFERNCE         <YC_7>
    SER_NLIM = 29                         ' OWXX1C : SPEED LIMIT             <YC_7>
    SER_KV = 30                           ' OWXX1D : VELOCITY_GAIN           <YC_7>
    SER_PULBIAS = 31                      ' OLXX1E : PULSE OFFSET            <YC_7>
    SER_MCMDCODE = 33                     ' OWXX20 : Motion command code
    SER_MCMDCTRL = 34                     ' OWXX21 : Motion command control flag
    SER_RV = 35                           ' OLXX22 : Rapid feeding speed
    SER_EXMDIST = 37                      ' OLXX24 : External positioning travel distance
    SER_STOPDIST = 39                     ' OLXX26 : Stopping distance
    SER_STEP = 41                         ' OLXX28 : STEP moving amount
    SER_ZRNDIST = 43                      ' OLXX2A : Home position return final travel distance
    SER_OV = 45                           ' OWXX2C : Override
    SER_POSCTRL = 46                      ' OWXX2D : Position management control flag
    SER_OFFSET = 47                       ' OLXX2E : Workpiece coordinate system offset
    SER_POSMXTRN = 49                     ' OLXX30 : Preset data for number of POSMAX turns
    SER_INPWIDTH = 51                     ' OWXX32 : Second in-position width
    SER_PSETWIDTH = 52                    ' OWXX33 : Home position output width
    SER_PSETTIME = 53                     ' OWXX34 : Positioning completion checking time
    SER_YENTCN = 54                       ' OWXX35 : YENET servo parameter number
    SER_CNDAT = 55                        ' OLXX36 : YENET servo parameter set value
    SER_EPOSL = 57                        ' OLXX38 : Lower digit 2 words of encoder position at power OFF
    SER_EPOSH = 59                        ' OLXX3A : Upper digit 2 words of encoder position at power OFF
    SER_APOSL = 61                        ' OLXX3C : Lower digit 2 words of PULSE absolute position at power OFF
    SER_APOSH = 63                        ' OLXX3E : Upper digit 2 words of PULSE absolute position at power OFF
End Enum
'/*======================================================*'
'/*                                                      *'
'/*  Monitor Motion Parameter                            *'
'/*                                                      *'
'/*======================================================*'
Friend Enum ApiDefs_MonPrm
    SER_RUNSTS = 0                        ' IWxx00 : operation Status
    SER_ERNO = 1                          ' IWxx01 : Out-of-range occurring parameter number
    SER_WARNING = 2                       ' ILxx02 : Warning
    SER_ALARM = 4                         ' ILxx04 : ALARM
    SER_MCMDRCODE = 8                     ' IWxx08 : Motion command response code
    SER_MCMDSTS = 9                       ' IWxx09 : Motion command status
    SER_SUBCMD = 10                       ' IWxx0A : Subcommand response
    SER_SUBSTS = 11                       ' IWxx0B : Subcommand Status
    SER_POSSTS = 12                       ' IWxx0C : Position management status
    SER_TPOS = 14                         ' ILxx0E : Machine coordinate system target position (POS)
    SER_CPOS = 16                         ' ILxx10 : Machine coordinate system position calculation (CPOS)
    SER_MPOS = 18                         ' ILxx12 : Machine coordinate system reference position (MPOS)
    SER_DPOS = 20                         ' ILxx14 : 32-bit coordinate system reference position (DPOS)
    SER_APOS = 22                         ' ILxx16 : Machine coordinate system feedback position (APOS)
    SER_LPOS = 24                         ' ILxx18 : Machine coordinate system latch position (LPOS)
    SER_PERR = 26                         ' ILxx1A : Position deviation
    SER_PDV = 28                          ' ILxx1C : Target position incremental value monitor
    SER_PMAXTURN = 30                     ' ILxx1E : Number of POSMAX turns
    SER_SPDREF = 32                       ' ILxx20 : Speed reference output value monitor
    SER_XREFMON = 34                      ' ILxx22 : Position reference output monitor
    SER_YIMON = 36                        ' IWxx24 : Integral value output value monitor
    SER_LAGMON = 38                       ' ILxx26 : Primary delay monitor
    SER_PIMON = 40                        ' ILxx28 : Position loop output value monitor
    SER_SVSTS = 44                        ' IWxx2C : Servo driver status (depending on model)
    SER_SVALARM = 45                      ' IWxx2D : Servo driver ALARM code
    SER_SVIOMON = 46                      ' IWxx2E : Servo driver I/O monitor
    SER_MUSRMONSEL = 47                   ' IWxx2F : Servo driver user monitor information
    SER_USRMON2 = 48                      ' ILxx30 : Servo driver user monitor 2
    SER_USRMON3 = 50                      ' ILxx32 : Servo driver user monitor 3
    SER_USRMON4 = 52                      ' ILxx34 : Servo driver user monitor 4
    SER_MCNNO = 54                        ' IWxx36 : Servo driver parameter number
    SER_MSUBCNNO = 55                     ' IWxx37 : Auxiliary servo driver parameter number
    SER_MCNDAT = 56                       ' ILxx38 : Servo driver parameter read-out data
    SER_MSUBCNDAT = 58                    ' ILxx3A : Auxiliary servo driver parameter read-out data
    SER_SANS = 60                         ' IWxx3C : Serial command answer monitor
    SER_MSADR = 61                        ' IWxx3D : Serial command address monitor
    SER_MSDAT = 62                        ' IWxx3E : Serial command data monitor
    SER_MOTERTYPE = 63                    ' IWxx3F : Serial command data monitor
    SER_FSPD = 64                         ' ILxx40 : Feedback speed                   [Reference unit/s], [10^n reference unit/min], [0.01%]
    SER_TRQ = 66                          ' ILxx42 : Torque reference monitor
    SER_ABSREV = 74                       ' ILxx4A : Number of accumulated rotating speed received from absolute encoder
    SER_IPULSE = 76                       ' ILxx4C : Number of initial incremental pulses [pulses]
    SER_FIXPRMMON = 86                    ' ILxx56 : Fixed parameter monitor
    SER_DI = 88                           ' IWxx58 : General-purpose DI monitor
    SER_AI1 = 89                          ' IWxx59 : General-purpose AI monitor
    SER_AI2 = 90                          ' IWxx5A : General-purpose AI monitor
    SER_MEPOSML = 94                      ' ILxx5E : Lower digit 2 words of encoder position at power OFF
    SER_MEPOSMH = 96                      ' ILxx60 : Upper digit 2 words of encoder position at power OFF
    SER_MAPOSML = 98                      ' ILxx62 : Lower digit 2 words of PULSE absolute position at power OFF
    SER_MAPOSMH = 100                      ' ILxx64 : Upper digit 2 words of PULSE absolute position at power OFF
    SER_MONSTS = 102                       ' ILxx66 : Monitor data status
    SER_MONDATA = 104                      ' ILxx68 : Read-out data
End Enum
#End Region
#Region "Yaskawa Structure"
''' <summary>
''' Structure to store communication settings.
''' </summary>
''' <remarks></remarks>
Friend Structure COM_DEVICE
    Dim ComDeviceType As Int16              ' Communication type
    Dim PortNumber As Int16                 ' Port number
    Dim CpuNumber As Int16                  ' CPU number
    Dim NetworkNumber As Int16              ' Network number
    Dim StationNumber As Int16              ' Station number
    Dim UnitNumber As Int16                 ' Unit number
    Dim IPAddress As Int32                  ' IP address (Ethernet)
    Dim Timeout As Int32                    ' Communication timeout time
End Structure

' I/O data structure
Friend Structure IO_DATA
    Dim DeviceType As Integer               ' I/O, Direct I/O, Variable, Timer, Motion, etc. Applied to packet access type
    Dim DataUnitSize As Integer             ' Unit data size BIT 1, BYTE 8, WORD 16, Etc.
    Dim RackNo As Integer                   ' Rack number (1, 2, ....)
    Dim SlotNo As Integer                   ' Slot number (0, 1, ....)
    Dim SubslotNo As Integer                ' Subslot number (1, 2, ....)
    Dim StationNo As Integer                ' Station number (1, 2, ....)
    Dim hData As Long                       ' Data Handle. Global data handle or register data handle can be specified.
    Dim DeviceWordOffset As Long            ' Offset address (in the units of words). Motion parameter number
    Dim DeviceBitOffset As Integer          ' Bit Offset. BYTE 0 1(Hi,Lo), WORD,DWORD   0(reserved)
    Dim Reserve As Integer                  ' Reserved
    Dim DataUnitCount As Long               ' used for multiple bit quantities or multiple byte arrays, normally 1
End Structure

'Structure to specify position data
Friend Structure POSITION_DATA
    Dim DataType As Int32                   ' Data type (0: immediate, 1: indirect designation)
    Dim PositionData As Int32               ' Position data: hGlobalData is stored in case of indirect designation.
End Structure

'Structure of data used for gear ratio setting
Friend Structure GEAR_RATIO_DATA
    Dim Master As Int16                     ' Gear ratio (numerator) specified
    Dim Slave As Int16                      ' Gear ratio (denominator) specified
End Structure

'Structure of synchronized position data used for Gear
Friend Structure SYNC_DISTANCE
    Dim SyncType As Int16                   ' Synchronization type
    Dim DataType As Int16                   ' Master axis moving distance data type
    Dim DistanceData As Int32               ' Master axis moving distance
End Structure

'Structure of data used for phase compensation
Friend Structure POSITION_OFFSET_DATA
    Dim ShiftType As Int32                  ' Speed pattern selection (TRIANGLE, TRAPEZOIDE)
    Dim Offset As Double                    ' Position offset value (UserUnit)
    Dim Duration As Double                  ' Position compensation time (0 to 65536)
End Structure

'Structure to specify common motion data
Friend Structure MOTION_DATA
    Dim CoordinateSystem As Int16           ' Coordinate system specified
    Dim MoveType As Int16                   ' Motion type
    Dim VelocityType As Int16               ' Speed type
    Dim AccDecType As Int16                 ' Acceleration type
    Dim FilterType As Int16                 ' Filter type
    Dim DataType As Int16                   ' Data type (0: immediate, 1: indirect designation)
    Dim MaxVelocity As Int32                ' Maximum feeding speed [reference unit/s]
    Dim Acceleration As Int32               ' Acceleration [reference unit/s2], acceleration time constant [ms]
    Dim Deceleration As Int32               ' Deceleration [reference unit/s2], deceleration time constant [ms]
    Dim FilterTime As Int32                 ' Filter time [ms]
    Dim Velocity As Int32                   ' Feeding speed [reference unit/s], Offset speed
    Dim ApproachVelocity As Int32           ' Approach speed [reference unit/s]
    Dim CreepVelocity As Int32              ' Creep speed [reference unit/s]
End Structure

' Calendar data structure
Friend Structure CALENDAR_DATA
    Dim Year As Int16                       ' Year
    Dim Month As Int16                      ' Month
    Dim DayOfWeek As Int16                  ' Day of week
    Dim Day As Int16                        ' Day
    Dim Hour As Int16                       ' Hour
    Dim Minutes As Int16                    ' Minute
    Dim Second As Int16                     ' Second
    Dim Milliseconds As Int16               ' Millisecond
End Structure

'Alarm information structure
Friend Structure ALARM_INFO
    Dim ErrorCode As Int32                  ' Error code
    Dim ErrorLocation As Int32              ' Occurring position
    Dim DetectTask As Int32                 ' Detector
    Dim hDevice As Int32                    ' Device handle
    Dim TaskID As Int32                     ' Task ID
    <VBFixedString(8), MarshalAs(ByValTStr, SizeConst:=8)> _
    Dim TaskName As String                  ' Task name   8
    Dim ObjectHandle As Int32               ' Object handle
    <VBFixedString(8), MarshalAs(ByValTStr, SizeConst:=8)> _
    Dim ObjectName As String                ' Object name 8
    Dim Calendar As CALENDAR_DATA           ' Calendar
    Dim m_Axishandle As Int32                      ' AXIS handle
    Dim DetailError As Int32                ' Detailed error (any error code)
    <VBFixedString(32), MarshalAs(ByValTStr, SizeConst:=32)> _
    Dim Comment As String                   ' Comment   32
End Structure

Friend Structure DWORD_DATA
    Dim DataType As Int32
    Dim Data As Int32
End Structure

'Register information structure
<StructLayout(LayoutKind.Sequential)> _
Friend Structure REGISTER_INFO
    Dim hRegisterData As Int32              ' handle to RegisterData
    Dim RegisterDataNumber As Int32         ' Number of RegisterData
    Dim pRegisterData As IntPtr             ' pointer of Stored RegisterData
    Dim ReadDataNumber As Int32             ' Stored RegisterData Number
End Structure

'BUSIF information structure
Friend Structure BUSIF_INFO
    Dim InputDataMaxSize As Int16           ' InputDataMaxSize
    Dim InputDataAvailableSize As Int16     ' InputDataAvailableSize
    Dim OutputDataMaxSize As Int16          ' OutputDataMaxSize
    Dim OutputDataAvailableSize As Int16    ' OutputDataAvailableSize
End Structure
#End Region

Friend Module Yaskawa
#Region "Yaskawa ErrorCode"
    Friend Const MP_SUCCESS As Int32 = &H0                                               '/* API function normal completion                      */
    Friend Const MP_FAIL As Int32 = &H4000FFFF                                           '/* API function erroneous completion                   */
    Friend Const WDT_OVER_ERR As Int32 = &H81000001                                      '/*                                                     */
    Friend Const MANUAL_RESET_ERR As Int32 = &H82000020                                  '/* Manual reset error                                  */
    Friend Const TLB_MLTHIT_ERR As Int32 = &H82000140                                    '/* TLB multi hit error                                 */
    Friend Const UBRK_ERR As Int32 = &H820001E0                                          '/* User break execution error                          */
    Friend Const ADR_RD_ERR As Int32 = &H820000E0                                        '/* Address read error error                            */
    Friend Const TLB_MIS_RD_ERR As Int32 = &H82000040                                    '/* TLB read mis error                                  */
    Friend Const TLB_PROTECTION_RD_ERR As Int32 = &H820000A0                             '/* TLB protection read vaiolation error                */
    Friend Const GENERAL_INVALID_INS_ERR As Int32 = &H82000180                           '/* General invalid instruction error                   */
    Friend Const SLOT_ERR As Int32 = &H820001A0                                          '/* Slot invalid instruction error                      */
    Friend Const GENERAL_FPU_DISABLE_ERR As Int32 = &H82000800                           '/* General FPU disable error                           */
    Friend Const SLOT_FPU_ERR As Int32 = &H82000820                                      '/* Slot FPU exception error                            */
    Friend Const ADR_WR_ERR As Int32 = &H82000100                                        '/* Data address write error error                      */
    Friend Const TLB_MIS_WR_ERR As Int32 = &H82000060                                    '/* TLB write mis error                                 */
    Friend Const TLB_PROTECTION_WR_ERR As Int32 = &H820000C0                             '/* TLB protection write vaiolation error               */
    Friend Const FPU_EXP_ERR As Int32 = &H82000120                                       '/* FPU exception error                                 */
    Friend Const INITIAL_PAGE_EXP_ERR As Int32 = &H82000080                              '/* Initial page write exception error                  */
    Friend Const ROM_ERR As Int32 = &H81000041                                           '/* ROM  error                                          */
    Friend Const RAM_ERR As Int32 = &H81000042                                           '/* RAM  error                                          */
    Friend Const MPU_ERR As Int32 = &H81000043                                           '/* CPU  error                                          */
    Friend Const FPU_ERR As Int32 = &H81000044                                           '/* FPU  error                                          */
    Friend Const CERF_ERR As Int32 = &H81000049                                          '/* CERF error                                          */
    Friend Const EXIO_ERR As Int32 = &H81000050                                          '/* EXIO error                                          */
    Friend Const BUSIF_ERR As Int32 = &H8100005F                                         '/* Common RAM error for OEM                            */
    Friend Const ALM_NO_ALM As Int32 = &H0                                               '/* No alarm                                                                                            */
    Friend Const ALM_MK_DEBUG As Int32 = &H67050300                                      '/* Minor failure: Alarm code for debugging                                                             */
    Friend Const ALM_MK_ROUND_ERR As Int32 = &H67050301                                  '/* Minor failure: Improper specification of one cycle at radius specification                          */
    Friend Const ALM_MK_FSPEED_OVER As Int32 = &H67050302                                '/* Minor failure: Feeding speed exceeded                                                               */
    Friend Const ALM_MK_FSPEED_NOSPEC As Int32 = &H67050303                              '/* Minor failure: Feeding speed not specified                                                          */
    Friend Const ALM_MK_PRM_OVER As Int32 = &H67050304                                   '/* Minor failure: Value after conversion of acceleration or deceleration parameter is out of range.    */
    Friend Const ALM_MK_ARCLEN_OVER As Int32 = &H67050305                                '/* Minor failure: Arc length exceeds LONG_MAX.                                                         */
    Friend Const ALM_MK_VERT_NOSPEC As Int32 = &H67050306                                '/* Minor failure: Vertical axis by plane specification not specified                                   */
    Friend Const ALM_MK_HORZ_NOSPEC As Int32 = &H67050307                                '/* Minor failure: Horizontal axis by plane specification not specified                                 */
    Friend Const ALM_MK_TURN_OVER As Int32 = &H67050308                                  '/* Minor failure: Specified number of turns exceeded                                                   */
    Friend Const ALM_MK_RADIUS_OVER As Int32 = &H67050309                                '/* Minor failure: Radius exceeds LONG_MAX.                                                             */
    Friend Const ALM_MK_CENTER_ERR As Int32 = &H6705030A                                 '/* Minor failure: Illegal center point specification                                                   */
    Friend Const ALM_MK_BLOCK_OVER As Int32 = &H6705030B                                 '/* Minor failure: Linear interpolation block moving amount exceeded                                    */
    Friend Const ALM_MK_MAXF_NOSPEC As Int32 = &H6705030C                                '/* Minor failure: maxf not defined                                                                     */
    Friend Const ALM_MK_TDATA_ERR As Int32 = &H6705030D                                  '/* Minor failure: Address T data error                                                                 */
    Friend Const ALM_MK_REG_ERR As Int32 = &H6705030E                                    '/* Minor failure: REG data error and PP fault                                                          */
    Friend Const ALM_MK_COMMAND_CODE_ERR As Int32 = &H6705030F                           '/* Minor failure: Out-of-range command                                                                 */
    Friend Const ALM_MK_AXIS_CONFLICT As Int32 = &H67050310                              '/* Minor failure: Use of logical axis being prohibited                                                 */
    Friend Const ALM_MK_POSMAX_OVER As Int32 = &H67050311                                '/* Minor failure: Infinite length axis, MVM or ABS coordinate designation exceeds POSMAX.              */
    Friend Const ALM_MK_DIST_OVER As Int32 = &H67050312                                  '/* Minor failure: Axis moving distance is other than (LONG_MIN, LONG_MAX).                             */
    Friend Const ALM_MK_MODE_ERR As Int32 = &H67050313                                   '/* Minor failure: Illegal control mode                                                                 */
    Friend Const ALM_MK_CMD_CONFLICT As Int32 = &H67050314                               '/* Minor failure: Motion command overlapping instruction                                               */
    Friend Const ALM_MK_RCMD_CONFLICT As Int32 = &H67050315                              '/* Minor failure: Motion response command overlapping instruction                                      */
    Friend Const ALM_MK_CMD_MODE_ERR As Int32 = &H67050316                               '/* Minor failure: Illegal motion command mode                                                          */
    Friend Const ALM_MK_CMD_NOT_ALLOW As Int32 = &H67050317                              '/* Minor failure: Command cannot be executed ih this Module.                                           */
    Friend Const ALM_MK_CMD_DEN_FAIL As Int32 = &H67050318                               '/* Minor failure: Distribution is not completed.                                                       */
    Friend Const ALM_MK_H_MOVE_ERR As Int32 = &H67050319                                 '/* Minor failure: Illegal hMove                                                                        */
    Friend Const ALM_MK_MOVE_NOT_SUPPORT As Int32 = &H6705031A                           '/* Minor failure: Non-supported Move defined                                                           */
    Friend Const ALM_MK_EVENT_NOT_SUPPORT As Int32 = &H6705031B                          '/* Minor failure: Non-supported Move Event defined                                                     */
    Friend Const ALM_MK_ACTION_NOT_SUPPORT As Int32 = &H6705031C                         '/* Minor failure: Non-supported Move Action defined                                                    */
    Friend Const ALM_MK_MOVE_TYPE_ERR As Int32 = &H6705031D                              '/* Minor failure: MoveType specification error                                                         */
    Friend Const ALM_MK_VTYPE_ERR As Int32 = &H6705031E                                  '/* Minor failure: VelocityType specification error                                                     */
    Friend Const ALM_MK_ATYPE_ERR As Int32 = &H6705031F                                  '/* Minor failure: AccelerationType specification error                                                 */
    Friend Const ALM_MK_HOMING_METHOD_ERR As Int32 = &H67050320                          '/* Minor failure: Homing_method specification error                                                    */
    Friend Const ALM_MK_ACC_ERR As Int32 = &H67050321                                    '/* Minor failure: Acceleration setting error                                                           */
    Friend Const ALM_MK_DEC_ERR As Int32 = &H67050322                                    '/* Minor failure: Deceleration setting error                                                           */
    Friend Const ALM_MK_POS_TYPE_ERR As Int32 = &H67050323                               '/* Minor failure: Position reference type error                                                        */
    Friend Const ALM_MK_INVALID_EVENT_ERR As Int32 = &H67050324                          '/* Minor failure: Illegal EVENT type                                                                   */
    Friend Const ALM_MK_INVALID_ACTION_ERR As Int32 = &H67050325                         '/* Minor failure: Illegal ACTION type                                                                  */
    Friend Const ALM_MK_MOVE_NOT_ACTIVE As Int32 = &H67050326                            '/* Minor failure: Action for Move that has not been executed                                           */
    Friend Const ALM_MK_MOVELIST_NOT_ACTIVE As Int32 = &H67050327                        '/* Minor failure: Action for MoveList that has not been executed                                       */
    Friend Const ALM_MK_TBL_INVALID_DATA As Int32 = &H67050328                           '/* Minor failure: Illegal table data                                                                   */
    Friend Const ALM_MK_TBL_INVALID_SEG_NUM As Int32 = &H67050329                        '/* Minor failure: Illegal number of table interpolation execution segments                             */
    Friend Const ALM_MK_TBL_INVALID_AXIS_NUM As Int32 = &H6705032A                       '/* Minor failure: Illegal number of table interpolation axes specified                                 */
    Friend Const ALM_MK_TBL_INVALID_ST_SEG As Int32 = &H6705032B                         '/* Minor failure: Illegal table interpolation starting segment number                                  */
    Friend Const ALM_MK_STBL_INVALID_EXE As Int32 = &H6705032C                           '/* Minor failure: Execution error during Static table file being written                               */
    Friend Const ALM_MK_DTBL_DUPLICATE_EXE As Int32 = &H6705032D                         '/* Minor failure: Dynamic table duplicated execution error                                             */
    Friend Const ALM_MK_LATCH_CONFLICT As Int32 = &H6705032E                             '/* Minor failure: LATCH request overlapping instruction error                                          */
    Friend Const ALM_MK_INVALID_AXISTYPE As Int32 = &H6705032F                           '/* Minor failure: Illegal axis type (finite length axis/inifinite length axis)                         */
    Friend Const ALM_MK_NOT_SVCRDY As Int32 = &H67050330                                 '/* Minor failure: Move object executed when Motion Driver operation is not ready                       */
    Friend Const ALM_MK_NOT_SVCRUN As Int32 = &H67050331                                 '/* Minor failure: Move object executed at servo OFF                                                    */
    Friend Const ALM_MK_MDALARM As Int32 = &H67050332                                    '/* Minor failure: Move object executed at occurrence of Motion Driver alarm                            */
    Friend Const ALM_MK_SUPERPOSE_MASTER_ERR As Int32 = &H67050333                       '/* Minor failure: Distribution synthetic object master axis condition error                            */
    Friend Const ALM_MK_SUPERPOSE_SLAVE_ERR As Int32 = &H67050334                        '/* Minor failure: Distribution synthetic object slave axis condition error                             */
    Friend Const ALM_MK_MDWARNING As Int32 = &H57050335                                  '/* Warning: Motion Driver warning                                                                      */
    Friend Const ALM_MK_MDWARNING_POSERR As Int32 = &H57050336                           '/* Warning: Motion Driver deviation warning                                                            */
    Friend Const ALM_MK_NOT_INFINITE_ABS As Int32 = &H67050337                           '/* Minor failure: Specified axis cannot be used as ABS infinite length axis.                           */
    Friend Const ALM_MK_INVALID_LOGICAL_NUM As Int32 = &H67050338                        '/* Minor failure: Illegal logical axis number has been specified.                                      */
    Friend Const ALM_MK_MAX_VELOCITY_ERR As Int32 = &H67050339                           '/* Minor failure: Maximum speed setting error                                                          */
    Friend Const ALM_MK_VELOCITY_ERR As Int32 = &H6705033A                               '/* Minor failure: Speed setting error                                                                  */
    Friend Const ALM_MK_APPROACH_ERR As Int32 = &H6705033B                               '/* Minor failure: Approach speed setting error                                                         */
    Friend Const ALM_MK_CREEP_ERR As Int32 = &H6705033C                                  '/* Minor failure: Creep speed setting error                                                            */
    Friend Const ALM_MK_OS_ERR_MBOX1 As Int32 = &H83050340                               '/* Major failure: Mail box creation error (mail box for request for Motion Kernel Move object execution)*/
    Friend Const ALM_MK_OS_ERR_MBOX2 As Int32 = &H83050341                               '/* Major failure: Mail box creation error (mail box for request for Motion Kernel action execution)    */
    Friend Const ALM_MK_OS_ERR_SEND_MSG1 As Int32 = &H83050342                           '/* Major failure: Message sending error at OS level (MK to EM: Notification of event detection)        */
    Friend Const ALM_MK_OS_ERR_SEND_MSG2 As Int32 = &H83050343                           '/* Major failure: Message sending error at OS level (MK to MM: Move completion message)                */
    Friend Const ALM_MK_OS_ERR_SEND_MSG3 As Int32 = &H83050344                           '/* Major failure: Message sending error at OS level (EM to MM: Notification of Action)                 */
    Friend Const ALM_MK_OS_ERR_SEND_MSG4 As Int32 = &H83050345                           '/* Major failure: Message sending error at OS level (Others)                                           */
    Friend Const ALM_MK_ACTION_ERR1 As Int32 = &H53050346                                '/* Warning: Illegal response message received (action execution request to waiting status for response of notification of action execution completion) */
    Friend Const ALM_MK_ACTION_ERR2 As Int32 = &H53050347                                '/* Warning: Illegal response message received(not an action for Move object currently executed)        */
    Friend Const ALM_MK_ACTION_ERR3 As Int32 = &H53050348                                '/* Warning: Illegal response message received (not an action for MoveLIST object currently executed)   */
    Friend Const ALM_MK_RCV_INV_MSG1 As Int32 = &H53050349                               '/* Warning: Illegal command message received (not a MOVE object handle)                                */
    Friend Const ALM_MK_RCV_INV_MSG2 As Int32 = &H5305034A                               '/* Warning: Illegal command message received (command from other than Motion Manager)                  */
    Friend Const ALM_MK_RCV_INV_MSG3 As Int32 = &H5305034B                               '/* Warning: Illegal command message received (not a command message)                                   */
    Friend Const ALM_MK_RCV_INV_MSG4 As Int32 = &H5305034C                               '/* Warning: Illegal command message received (message other than command/response)                     */
    Friend Const ALM_MK_RCV_INV_MSG5 As Int32 = &H5305034D                               '/* Warning: Illegal command message received (command message from other than Event Manager)           */
    Friend Const ALM_MK_RCV_INV_MSG6 As Int32 = &H5305034E                               '/* Warning: Illegal command message received (command message other than request for action execution) */
    Friend Const ALM_MK_RCV_INV_MSG7 As Int32 = &H5305034F                               '/* Warning: Illegal response message received (response message from other than Event Manager)         */
    Friend Const ALM_MK_RCV_INV_MSG8 As Int32 = &H53050350                               '/* Warning: Illegal response message received (response message other than event notification completion/action completion notification)   */
    Friend Const ALM_MK_AXIS_HANDLE_ERROR As Int32 = &H67050360                          '/* Minor failure: Axis handle number is incorrect.                                                     */
    Friend Const ALM_MK_SLAVE_USED_AS_MASTER As Int32 = &H67050361                       '/* Minor failure: An attempt was made to use a slave axis as a master axis.                            */
    Friend Const ALM_MK_MASTER_USED_AS_SLAVE As Int32 = &H67050362                       '/* Minor failure: An attempt was made to use a master axis as a slave axis.                            */
    Friend Const ALM_MK_SLAVE_HAS_2_MASTERS As Int32 = &H67050363                        '/* Minor failure: More than two master axes were specified for the same slave axis.                    */
    Friend Const ALM_MK_SLAVE_HAS_NOT_WORK As Int32 = &H67050364                         '/* Minor failure: Work axis cannot be assured for a slave axis.                                        */
    Friend Const ALM_MK_PARAM_OUT_OF_RANGE As Int32 = &H67050365                         '/* Minor failure: Parameter is out of range.                                                           */
    Friend Const ALM_MK_NNUM_MAX_OVER As Int32 = &H67050366                              '/* Minor failure: Maximum number of averaging times exceeded                                           */
    Friend Const ALM_MK_FGNTBL_INVALID As Int32 = &H67050367                             '/* Minor failure: Contents of the FGN table are illegal.                                               */
    Friend Const ALM_MK_PARAM_OVERFLOW As Int32 = &H67050368                             '/* Minor failure: Set value overflows.                                                                 */
    Friend Const ALM_MK_ALREADY_COMMANDED As Int32 = &H67050369                          '/* Minor failure: CAM or GEAR has already been under execution.                                        */
    Friend Const ALM_MK_MULTIPLE_SHIFTS As Int32 = &H6705036A                            '/* Minor failure: Position Offset/Cam Shift was executed during execution of Position Offset/Cam Shift.*/
    Friend Const ALM_MK_CAMTBL_INVALID As Int32 = &H6705036B                             '/* Minor failure: CAM table is illegal (address, contents, etc.).                                      */
    Friend Const ALM_MK_ABORTED_BY_STOPMTN As Int32 = &H6705036C                         '/* Minor failure: CAM/GEAR is aborted by STOP MOTION, etc.                                             */
    Friend Const ALM_MK_HMETHOD_INVALID As Int32 = &H6705036D                            '/* Minor failure: Non-supported zero point return method                                               */
    Friend Const ALM_MK_MASTER_INVALID As Int32 = &H6705036E                             '/* Minor failure: Master axis is not specified for monitoring.                                         */
    Friend Const ALM_MK_DATA_HANDLE_INVALID As Int32 = &H6705036F                        '/* Minor failure: Register/global data handle is illegal.                                              */
    Friend Const ALM_MK_UNKNOWN_CAM_GEAR_ERR As Int32 = &H67050370                       '/* Minor failure: Unclear error related to CAM/GEAR                                                    */
    Friend Const ALM_MK_REG_SIZE_INVALID As Int32 = &H67050371                           '/* Minor failure: Register handle size is illegal.                                                     */
    Friend Const ALM_MK_ACTION_HANDLE_ERROR As Int32 = &H67050372                        '/* Minor failure: Action handle is illegal.                                                            */
    Friend Const ALM_MM_OS_ERR_MBOX1 As Int32 = &H83040380                               '/* Major failure: Mail box creation error (mail box to start up Motion Manager)                        */
    Friend Const ALM_MM_OS_ERR_SEND_MSG1 As Int32 = &H83040381                           '/* Major failure: Message sending error at OS level (Motion Manager to Motion Kernel)                  */
    Friend Const ALM_MM_OS_ERR_SEND_MSG2 As Int32 = &H83040382                           '/* Major failure: Message sending error at OS level (Motion Manager to Event Manager)                  */
    Friend Const ALM_MM_OS_ERR_RCV_MSG1 As Int32 = &H83040383                            '/* Major failure: Message receiving error at OS level                                                  */
    Friend Const ALM_MM_MK_BUSY As Int32 = &H67040384                                    '/* Minor failure: All Motion Kernels are in use.                                                       */
    Friend Const ALM_MM_RCV_INV_MSG1 As Int32 = &H53040385                               '/* Warning: Illegal command message received (illegal handle 1: Not hMOVE.)                            */
    Friend Const ALM_MM_RCV_INV_MSG2 As Int32 = &H53040386                               '/* Warning: Illegal command message received (illegal handle 2: hMOVE does not exist.)                 */
    Friend Const ALM_MM_RCV_INV_MSG3 As Int32 = &H53040387                               '/* Warning: Illegal command message received (Not request for start action execution)                  */
    Friend Const ALM_MM_RCV_INV_MSG4 As Int32 = &H53040388                               '/* Warning: Illegal response message received (response message other than event notification completion)  */
    Friend Const ALM_MM_RCV_INV_MSG5 As Int32 = &H53040389                               '/* Warning: Illegal response message received (Other messages received with action completion response message)    */
    Friend Const ALM_IM_DEVICEID_ERR As Int32 = &H53060480                               '/* DeviceID error or non-supported Device              */
    Friend Const ALM_IM_REGHANDLE_ERR As Int32 = &H53060481                              '/* Register handle error                               */
    Friend Const ALM_IM_GLOBALHANDLE_ERR As Int32 = &H53060482                           '/* Global data handle error                            */
    Friend Const ALM_IM_DEVICETYPE_ERR As Int32 = &H53060483                             '/* Non-supported data type                             */
    Friend Const ALM_IM_OFFSET_ERR As Int32 = &H53060484                                 '/* Incorrect offset value                              */
    Friend Const AM_ER_UNDEF_COMMAND As Int32 = &H57020501                               '/* Illegal command code                                */
    Friend Const AM_ER_UNDEF_CMNDTYPE As Int32 = &H57020502                              '/* Illegal command type                                */
    Friend Const AM_ER_UNDEF_OBJTYPE As Int32 = &H57020503                               '/* Illegal object type                                 */
    Friend Const AM_ER_UNDEF_HANDLETYPE As Int32 = &H57020504                            '/* Illegal handle type                                 */
    Friend Const AM_ER_UNDEF_PKTDAT As Int32 = &H57020505                                '/* Illegal packet data                                 */
    Friend Const AM_ER_UNDEF_AXIS As Int32 = &H57020506                                  '/* axis not defined                                    */
    Friend Const AM_ER_MSGBUF_GET_FAULT As Int32 = &H57020510                            '/* Acquisition failure of  message buffer managed table*/
    Friend Const AM_ER_ACTSIZE_GET_FAULT As Int32 = &H57020511                           '/* Acquisition failure of ACT size                     */
    Friend Const AM_ER_APIBUF_GET_FAULT As Int32 = &H57020512                            '/* Acquisition failure of API buffer managed table     */
    Friend Const AM_ER_MOVEOBJ_GET_FAULT As Int32 = &H57020513                           '/* Acquisition failure of MOVE object managed table    */
    Friend Const AM_ER_EVTTBL_GET_FAULT As Int32 = &H57020514                            '/* Acquisition failure of event managed table          */
    Friend Const AM_ER_ACTTBL_GET_FAULT As Int32 = &H57020515                            '/* Acquisition failure of Action managed table         */
    Friend Const AM_ER_1BY1APIBUF_GET_FAULT As Int32 = &H57020516                        '/* Acquisition failure of Sequence managed table       */
    Friend Const AM_ER_AXSTBL_GET_FAULT As Int32 = &H57020517                            '/* Acquisition failure of AXIS handle managed table    */
    Friend Const AM_ER_SUPERPOSEOBJ_GET_FAULT As Int32 = &H57020518                      '/* Acquisition failure of Distribution synthetic object managed table  */
    Friend Const AM_ER_SUPERPOSEOBJ_CLEAR_FAULT As Int32 = &H57020519                    '/* Deletion failure of Distribution synthetic object   */
    Friend Const AM_ER_AXIS_IN_USE As Int32 = &H5702051A                                 '/* axis in use                                         */
    Friend Const AM_ER_HASHTBL_GET_FAULT As Int32 = &H5702051B                           '/* Hash table acquisition failure for axial name management    */
    Friend Const AM_ER_UNMATCH_OBJHNDL As Int32 = &H57020530                             '/* MOVE object handle mismatched                       */
    Friend Const AM_ER_UNMATCH_OBJECT As Int32 = &H57020531                              '/* Object mismatched                                   */
    Friend Const AM_ER_UNMATCH_APIBUF As Int32 = &H57020532                              '/* API buffer mismatched                               */
    Friend Const AM_ER_UNMATCH_MSGBUF As Int32 = &H57020533                              '/* Message buffer mismatched                           */
    Friend Const AM_ER_UNMATCH_ACTBUF As Int32 = &H57020534                              '/* Action execution management buffer mismatched       */
    Friend Const AM_ER_UNMATH_SEQUENCE As Int32 = &H57020535                             '/* Sequence number mismatched                          */
    Friend Const AM_ER_UNMATCH_1BY1APIBUF As Int32 = &H57020536                          '/* Sequential API management table mismatched          */
    Friend Const AM_ER_UNMATCH_MOVEOBJTABLE As Int32 = &H57020537                        '/* MOVE object management table mismatched             */
    Friend Const AM_ER_UNMATCH_MOVELISTTABLE As Int32 = &H57020538                       '/* MOVE LIST management table mismatched               */
    Friend Const AM_ER_UNMATCH_MOVELIST_OBJECT As Int32 = &H57020539                     '/* MOVE LIST object mismatched                         */
    Friend Const AM_ER_UNMATCH_MOVELIST_OBJHNDL As Int32 = &H5702053A                    '/* MOVE LIST object handle mismatched                  */
    Friend Const AM_ER_UNGET_MOVEOBJTABLE As Int32 = &H57020550                          '/* MOVE object management table not assured            */
    Friend Const AM_ER_UNGET_MOVELISTTABLE As Int32 = &H57020551                         '/* MOVE LIST object management table not assured       */
    Friend Const AM_ER_UNGET_1BY1APIBUFTABLE As Int32 = &H57020552                       '/* Sequential API management table not assured         */
    Friend Const AM_ER_NOEMPTYTBL_ERROR As Int32 = &H57020560                            '/* No unused table among interpolation tables          */
    Friend Const AM_ER_NOTGETSEM_ERROR As Int32 = &H57020561                             '/* Failure to get AM-MK semaphore  (Dynamic)           */
    Friend Const AM_ER_NOTGETTBLADD_ERROR As Int32 = &H57020562                          '/* Failure to get interpolation table address          */
    Friend Const AM_ER_NOTWRTTBL_ERROR As Int32 = &H57020563                             '/* Failure to write in table at execution (Static)     */
    Friend Const AM_ER_TBLINDEX_ERROR As Int32 = &H57020564                              '/* Index setting error (Static)                        */
    Friend Const AM_ER_ILLTBLTYPE_ERROR As Int32 = &H57020565                            '/* Invalid table type specified                        */
    Friend Const AM_ER_UNSUPORTED_EVENT As Int32 = &H57020570                            '/* Event not supported or argument error               */
    Friend Const AM_ER_WRONG_SEQUENCE As Int32 = &H57020571                              '/* Sequence error                                      */
    Friend Const AM_ER_MOVEOBJ_BUSY As Int32 = &H57020572                                '/* MOVE object under execution                         */
    Friend Const AM_ER_MOVELIST_BUSY As Int32 = &H57020573                               '/* MOVE LIST under execution                           */
    Friend Const AM_ER_MOVELIST_ADD_FAULT As Int32 = &H57020574                          '/* MOVE OBJ cannot be registered.                      */
    Friend Const AM_ER_CONFLICT_PHI_AXS As Int32 = &H57020575                            '/* Physical axes overlapped                            */
    Friend Const AM_ER_CONFLICT_LOG_AXS As Int32 = &H57020576                            '/* Logic axes overlapped                               */
    Friend Const AM_ER_PKTSTS_ERROR As Int32 = &H57020577                                '/* Receiving packet status error                       */
    Friend Const AM_ER_CONFLICT_NAME As Int32 = &H57020578                               '/* Axis name overlapped                                */
    Friend Const AM_ER_ILLEGAL_NAME As Int32 = &H57020579                                '/* Incorrect axis name                                 */
    Friend Const AM_ER_SEMAPHORE_ERROR As Int32 = &H5702057A                             '/* Incorrect semaphore at host PC interruption         */
    Friend Const AM_ER_LOG_AXS_OVER As Int32 = &H5702057B                                '/* Logical axis number exceeded                        */
    Friend Const IM_STATION_ERR As Int32 = &H55060B00                                    '/* Warning: Link communication station error           */
    Friend Const IM_IO_ERR As Int32 = &H55060B01                                         '/* Warning: I/O error                                  */
    Friend Const MP_FILE_ERR_GENERAL As Int32 = &H53168001                               '/* General error.                                      */
    Friend Const MP_FILE_ERR_NOT_SUPPORTED As Int32 = &H53168002                         '/* Feature not supported.                              */
    Friend Const MP_FILE_ERR_INVALID_ARGUMENT As Int32 = &H53168003                      '/* Invalid argument                                    */
    Friend Const MP_FILE_ERR_INVALID_HANDLE As Int32 = &H53168004                        '/* Invalid handle                                      */
    Friend Const MP_FILE_ERR_NO_FILE As Int32 = &H53168064                               '/* No such file (or directory).                        */
    Friend Const MP_FILE_ERR_INVALID_PATH As Int32 = &H53168065                          '/* Invalid path.                                       */
    Friend Const MP_FILE_ERR_EOF As Int32 = &H53168066                                   '/* End of file detected.                               */
    Friend Const MP_FILE_ERR_PERMISSION_DENIED As Int32 = &H53168067                     '/* Not arrowed to access the file.                     */
    Friend Const MP_FILE_ERR_TOO_MANY_FILES As Int32 = &H53168068                        '/* Too many files opened.                              */
    Friend Const MP_FILE_ERR_FILE_BUSY As Int32 = &H53168069                             '/* File is in use.                                     */
    Friend Const MP_FILE_ERR_TIMEOUT As Int32 = &H5316806A                               '/* Timeout occured.                                    */
    Friend Const MP_FILE_ERR_BAD_FS As Int32 = &H531680C8                                '/* Invalid or unexepected logical filesystem in the mediu
    Friend Const MP_FILE_ERR_FILESYSTEM_FULL As Int32 = &H531680C9                       '/* LFS (ie the media) is full.                         */
    Friend Const MP_FILE_ERR_INVALID_LFM As Int32 = &H531680CA                           '/* Invalid LFM specified.                              */
    Friend Const MP_FILE_ERR_TOO_MANY_LFM As Int32 = &H531680CB                          '/* LFM table is full.                                  */
    Friend Const MP_FILE_ERR_INVALID_PDM As Int32 = &H5316812C                           '/* Invalid PDM specified.                              */
    Friend Const MP_FILE_ERR_INVALID_MEDIA As Int32 = &H5316812D                         '/* Invalid media specified.                            */
    Friend Const MP_FILE_ERR_TOO_MANY_PDM As Int32 = &H5316812E                          '/* Too many PDM.                                       */
    Friend Const MP_FILE_ERR_TOO_MANY_MEDIA As Int32 = &H5316812F                        '/* Too many media.                                     */
    Friend Const MP_FILE_ERR_WRITE_PROTECTED As Int32 = &H53168130                       '/* Write protected media.                              */
    Friend Const MP_FILE_ERR_INVALID_DEVICE As Int32 = &H53168190                        '/* Invalid device specified.                           */
    Friend Const MP_FILE_ERR_DEVICE_IO As Int32 = &H53168191                             '/* Error occured in accessing the device.              */
    Friend Const MP_FILE_ERR_DEVICE_BUSY As Int32 = &H53168192                           '/* Device is in use.                                   */
    Friend Const MP_FILE_ERR_NO_CARD As Int32 = &H5316A711                               '/* CF CARD not mounted.                                */
    Friend Const MP_FILE_ERR_CARD_POWER As Int32 = &H5316A712                            '/* CF CARD Power-OFF.                                  */
    Friend Const MP_CARD_SYSTEM_ERR As Int32 = &H53178FFF                                '/* Card System Error.                                  */
    Friend Const ERROR_CODE_GET_DIREC_OFFSET As Int32 = &H83001A01                       '/* Directory area offset cannot be got.                */
    Friend Const ERROR_CODE_GET_DIREC_INFO As Int32 = &H83001A02                         '/* Directory area offset cannot be got.                */
    Friend Const ERROR_CODE_FUNC_TABLE As Int32 = &H83001A03                             '/* Failure to get directory information                */
    Friend Const ERROR_CODE_SLEEP_TASK As Int32 = &H83001A04                             '/* Failure to get system call function table           */
    Friend Const ERROR_CODE_DEVICE_HANDLE_FULL As Int32 = &H43001A41                     '/* Sleep error                                         */
    Friend Const ERROR_CODE_ALLOC_MEMORY As Int32 = &H43001A42                           '/* Number of device handles exceeds the maximum value. */
    Friend Const ERROR_CODE_BUFCOPY As Int32 = &H43001A43                                '/* Failure to get the area.                            */
    Friend Const ERROR_CODE_GET_COMMEM_OFFSET As Int32 = &H43001A44                      '/* MemoryCopy(),name_copy() error                      */
    Friend Const ERROR_CODE_CREATE_SEMPH As Int32 = &H43001A45                           '/* Failure to get common memory offset value           */
    Friend Const ERROR_CODE_DELETE_SEMPH As Int32 = &H43001A46                           '/* Semaphore creation error                            */
    Friend Const ERROR_CODE_LOCK_SEMPH As Int32 = &H43001A47                             '/* Semaphore deletion error                            */
    Friend Const ERROR_CODE_UNLOCK_SEMPH As Int32 = &H43001A48                           '/* Error at semaphore lock                             */
    Friend Const ERROR_CODE_PACKETSIZE_OVER As Int32 = &H43001A49                        '/* Error at semaphore release                          */
    Friend Const ERROR_CODE_UNREADY As Int32 = &H43001A4A                                '/*  Error when controller is being initialized         */
    Friend Const ERROR_CODE_CPUSTOP As Int32 = &H43001A4B                                '/*  Error when CPU is stopping                         */
    Friend Const ERROR_CODE_CNTRNO As Int32 = &H470B1A81                                 '/*  CPU number is illegal                              */
    Friend Const ERROR_CODE_SELECTION As Int32 = &H470B1A82                              '/* Device number                                       */
    Friend Const ERROR_CODE_LENGTH As Int32 = &H470B1A83                                 '/* Illegal selected value (0 or 1)                     */
    Friend Const ERROR_CODE_OFFSET As Int32 = &H470B1A84                                 '/* Data length                                         */
    Friend Const ERROR_CODE_DATACOUNT As Int32 = &H470B1A85                              '/* Offset value                                        */
    Friend Const ERROR_CODE_DATREAD As Int32 = &H46001A86                                '/* Number of data items                                */
    Friend Const ERROR_CODE_DATWRITE As Int32 = &H46001A87                               '/* Failure to read out from common memory              */
    Friend Const ERROR_CODE_BITWRITE As Int32 = &H46001A88                               '/* Failure to write in to common memory                */
    Friend Const ERROR_CODE_DEVCNTR As Int32 = &H46001A89                                '/* Failure to write in bit data to common memory       */
    Friend Const ERROR_CODE_NOTINIT As Int32 = &H460F1A8A                                '/* DeviceIoControl() completed erroneously.            */
    Friend Const ERROR_CODE_SEMPHLOCK As Int32 = &H41001A8B                              '/* Driver initialization error                         */
    Friend Const ERROR_CODE_SEMPHUNLOCK As Int32 = &H41001A8C                            '/* Packet sending semaphore locked                     */
    Friend Const ERROR_CODE_DRV_PROC As Int32 = &H460F1A8D                               '/* Packet receiving semaphore not locked               */
    Friend Const ERROR_CODE_GET_DRIVER_HANDLE As Int32 = &H460F1A8E                      '/* Driver processing completed erroneously.            */
    Friend Const ERROR_CODE_SEND_MSG As Int32 = &H450E1AC1                               '/* Failure to get driver file handle                   */
    Friend Const ERROR_CODE_RECV_MSG As Int32 = &H450E1AC2                               '/* Message sending error                               */
    Friend Const ERROR_CODE_INVALID_RESPONSE As Int32 = &H450E1AC3                       '/* Message receiving error                             */
    Friend Const ERROR_CODE_INVALID_ID As Int32 = &H450E1AC4                             '/* Receiving packet illegal                            */
    Friend Const ERROR_CODE_INVALID_STATUS As Int32 = &H450E1AC5                         '/* Receiving packet ID illegal                         */
    Friend Const ERROR_CODE_INVALID_CMDCODE As Int32 = &H450E1AC6                        '/* Receiving packet status illegal                     */
    Friend Const ERROR_CODE_INVALID_SEQNO As Int32 = &H450E1AC7                          '/* Receiving packet command code illegal               */
    Friend Const ERROR_CODE_SEND_RETRY_OVER As Int32 = &H450E1AC8                        '/* Receiving packet sequence number illegal            */
    Friend Const ERROR_CODE_RECV_RETRY_OVER As Int32 = &H450E1AC9                        '/* Number of retries exceeded (packet sending)         */
    Friend Const ERROR_CODE_RESPONSE_TIMEOUT As Int32 = &H450E1ACA                       '/* Number of retries exceeded (packet receiving)       */
    Friend Const ERROR_CODE_WAIT_FOR_EVENT As Int32 = &H450E1ACB                         '/* Response waiting timeout error                      */
    Friend Const ERROR_CODE_EVENT_OPEN As Int32 = &H450E1ACC                             '/* Event waiting error                                 */
    Friend Const ERROR_CODE_EVENT_RESET As Int32 = &H450E1ACD                            '/* Failure to open event                               */
    Friend Const ERROR_CODE_EVENT_READY As Int32 = &H450E1ACE                            '/* Failure to reset event                              */
    Friend Const ERROR_CODE_PROCESSNUM As Int32 = &H43001B01                             '/* Failure to prepare for waiting for event            */
    Friend Const ERROR_CODE_GET_PROC_INFO As Int32 = &H43001B02                          '/* Number of processes exceeded                        */
    Friend Const ERROR_CODE_THREADNUM As Int32 = &H43001B03                              '/* Process information getting error                   */
    Friend Const ERROR_CODE_GET_THRD_INFO As Int32 = &H43001B04                          '/* Number of threads exceeded                          */
    Friend Const ERROR_CODE_CREATE_MBOX As Int32 = &H43001B05                            '/* Thread information getting error                    */
    Friend Const ERROR_CODE_DELETE_MBOX As Int32 = &H43001B06                            '/* Mail box creation error                             */
    Friend Const ERROR_CODE_GET_TASKID As Int32 = &H83001B07                             '/* Mail box deletion error                             */
    Friend Const ERROR_CODE_NO_THREADINFO As Int32 = &H43001B08                          '/* Failure to get task ID                              */
    Friend Const ERROR_CODE_COM_INITIALIZE As Int32 = &H43001B09                         '/* Specified thread information does not exist.        */
    Friend Const ERROR_CODE_COMDEVICENUM As Int32 = &H430F1B41                           '/* COM initialization error                            */
    Friend Const ERROR_CODE_GET_COM_DEVICE_HANDLE As Int32 = &H430F1B42                  '/* Number of ComDevice exceeded                        */
    Friend Const ERROR_CODE_COM_DEVICE_FULL As Int32 = &H430F1B43                        '/* Failure to get ComDevice information structure      */
    Friend Const ERROR_CODE_CREATE_PANELOBJ As Int32 = &H430F1B44                        '/* ComDevice exceeds the maximum number.               */
    Friend Const ERROR_CODE_OPEN_PANELOBJ As Int32 = &H430F1B45                          '/* Failure to create panel command object              */
    Friend Const ERROR_CODE_CLOSE_PANELOBJ As Int32 = &H430F1B46                         '/* Failure to open panel command object                */
    Friend Const ERROR_CODE_PROC_PANELOBJ As Int32 = &H430F1B47                          '/* Failure to close panel command object               */
    Friend Const ERROR_CODE_CREATE_CNTROBJ As Int32 = &H430F1B48                         '/* Failure to process panel command object             */
    Friend Const ERROR_CODE_OPEN_CNTROBJ As Int32 = &H430F1B49                           '/* Failure to create panel command object              */
    Friend Const ERROR_CODE_CLOSE_CNTROBJ As Int32 = &H430F1B4A                          '/* Failure to open panel command object                */
    Friend Const ERROR_CODE_PROC_CNTROBJ As Int32 = &H430F1B4B                           '/* Failure to close panel command object               */
    Friend Const ERROR_CODE_CREATE_COMDEV_MUTEX As Int32 = &H430F1B4C                    '/* Failure to process panel command object             */
    Friend Const ERROR_CODE_CREATE_COMDEV_MAPFILE As Int32 = &H430F1B4D                  '/* Failure to create Mutex for ComDevice table         */
    Friend Const ERROR_CODE_OPEN_COMDEV_MAPFILE As Int32 = &H430F1B4E                    '/* Failure to create MapFile for ComDevice table       */
    Friend Const ERROR_CODE_NOT_OBJECT_TYPE As Int32 = &H430F1B4F                        '/* Failure to open MapFile for ComDevice table         */
    Friend Const ERROR_CODE_COM_NOT_OPENED As Int32 = &H430F1B50                         '/* Object type error                                   */
    Friend Const ERROR_CODE_PNLCMD_CPU_CONTROL As Int32 = &H43081B80                     '/* Not opened                                          */
    Friend Const ERROR_CODE_PNLCMD_SFILE_READ As Int32 = &H43081B81                      '/* CPU control error                                   */
    Friend Const ERROR_CODE_PNLCMD_SFILE_WRITE As Int32 = &H43081B82                     '/* Failure to read out source file                     */
    Friend Const ERROR_CODE_PNLCMD_REGISTER_READ As Int32 = &H43081B83                   '/* Failure to write in source file                     */
    Friend Const ERROR_CODE_PNLCMD_REGISTER_WRITE As Int32 = &H43081B84                  '/* Failure to read out register                        */
    Friend Const ERROR_CODE_PNLCMD_API_SEND As Int32 = &H43081B85                        '/* Failure to write in register                        */
    Friend Const ERROR_CODE_PNLCMD_API_RECV As Int32 = &H43081B86                        '/* API Send command error                              */
    Friend Const ERROR_CODE_PNLCMD_NO_RESPONSE As Int32 = &H43081B87                     '/* API Recv command error                              */
    Friend Const ERROR_CODE_PNLCMD_PACKET_READ As Int32 = &H43081B88                     '/* No response packet is received at API Recv.         */
    Friend Const ERROR_CODE_PNLCMD_PACKET_WRITE As Int32 = &H43081B89                    '/* Failure to read packet                              */
    Friend Const ERROR_CODE_PNLCMD_STATUS_READ As Int32 = &H43081B8A                     '/* Failure to write packet                             */
    Friend Const ERROR_CODE_NOT_CONTROLLER_RDY As Int32 = &H440D1BA0                     '/*                                                     */
    Friend Const ERROR_CODE_DOUBLE_CMD As Int32 = &H440D1BA1                             '/*                                                     */
    Friend Const ERROR_CODE_DOUBLE_RCMD As Int32 = &H440D1BA2                            '/*                                                     */
    Friend Const ERROR_CODE_FILE_NOT_OPENED As Int32 = &H43001BC1                        '/* Failure to read status                              */
    Friend Const ERROR_CODE_OPENFILE_NUM As Int32 = &H43001BC2                           '/* File is not opened.                                 */
    Friend Const MP_CTRL_SYS_ERROR As Int32 = &H4308106F                                 '/*                                                     */
    Friend Const MP_CTRL_PARAM_ERR As Int32 = &H43081092                                 '/*                                                     */
    Friend Const MP_CTRL_FILE_NOT_FOUND As Int32 = &H43081094                            '/*                                                     */
    Friend Const MP_NOTMOVEHANDLE As Int32 = &H470B1100                                  '/* Undefined Move handle                               */
    Friend Const MP_NOTTIMERHANDLE As Int32 = &H470B1101                                 '/* Undefined timer handle                              */
    Friend Const MP_NOTINTERRUPT As Int32 = &H470B1102                                   '/* Undefined virtual interruption number               */
    Friend Const MP_NOTEVENTHANDLE As Int32 = &H470B1103                                 '/* Undefined event handle                              */
    Friend Const MP_NOTMESSAGEHANDLE As Int32 = &H470B1104                               '/* Undefined message handle                            */
    Friend Const MP_NOTUSERFUNCTIONHANDLE As Int32 = &H470B1105                          '/* Undefined user function handle                      */
    Friend Const MP_NOTACTIONHANDLE As Int32 = &H470B1106                                '/* Undefined action handle                             */
    Friend Const MP_NOTSUBSCRIBEHANDLE As Int32 = &H470B1107                             '/* Undefined Subscribe handle                          */
    Friend Const MP_NOTDEVICEHANDLE As Int32 = &H470B1108                                '/* Undefined device handle                             */
    Friend Const MP_NOTAXISHANDLE As Int32 = &H470B1109                                  '/* Undefined axis handle                               */
    Friend Const MP_NOTMOVELISTHANDLE As Int32 = &H470B110A                              '/* Undefined MoveList handle                           */
    Friend Const MP_NOTTRACEHANDLE As Int32 = &H470B110B                                 '/* Undefined Trace handle                              */
    Friend Const MP_NOTGLOBALDATAHANDLE As Int32 = &H470B110C                            '/* Undefined global data handle                        */
    Friend Const MP_NOTSUPERPOSEHANDLE As Int32 = &H470B110D                             '/* Undefined Superpose handle                          */
    Friend Const MP_NOTCONTROLLERHANDLE As Int32 = &H470B110E                            '/* Undefined Controller handle                         */
    Friend Const MP_NOTFILEHANDLE As Int32 = &H470B110F                                  '/* Undefined file handle                               */
    Friend Const MP_NOTREGISTERDATAHANDLE As Int32 = &H470B1110                          '/* Undefined register handle                           */
    Friend Const MP_NOTALARMHANDLE As Int32 = &H470B1111                                 '/* Undefined alarm handle                              */
    Friend Const MP_NOTCAMHANDLE As Int32 = &H470B1112                                   '/* Undefined CAM handle                                */
    Friend Const MP_NOTHANDLE As Int32 = &H470B11FF                                      '/* Undefined handle                                    */
    Friend Const MP_NOTEVENTTYPE As Int32 = &H470B1200                                   '/* Undefined event type                                */
    Friend Const MP_NOTDEVICETYPE As Int32 = &H470B1201                                  '/* Undefined device type                               */
    Friend Const MP_NOTDATAUNITSIZE As Int32 = &H4B0B1202                                '/* Undefined unit data size                            */
    Friend Const MP_NOTDEVICE As Int32 = &H470B1203                                      '/* Undefined device                                    */
    Friend Const MP_NOTACTIONTYPE As Int32 = &H470B1204                                  '/* Undefined action type                               */
    Friend Const MP_NOTPARAMNAME As Int32 = &H4B0B1205                                   '/* Undefined parameter name                            */
    Friend Const MP_NOTDATATYPE As Int32 = &H470B1206                                    '/* Undefined data type                                 */
    Friend Const MP_NOTBUFFERTYPE As Int32 = &H470B1207                                  '/* Undefined buffer type                               */
    Friend Const MP_NOTMOVETYPE As Int32 = &H4B0B1208                                    '/* Undefined Move type                                 */
    Friend Const MP_NOTANGLETYPE As Int32 = &H470B1209                                   '/* Undefined Angle type                                */
    Friend Const MP_NOTDIRECTION As Int32 = &H4B0B120A                                   '/* Undefined rotating direction                        */
    Friend Const MP_NOTAXISTYPE As Int32 = &H4B0B120B                                    '/* Undefined axis type                                 */
    Friend Const MP_NOTUNITTYPE As Int32 = &H4B0B120C                                    '/* Undefined unit type                                 */
    Friend Const MP_NOTCOMDEVICETYPE As Int32 = &H470B120D                               '/* Undefined ComDevice type                            */
    Friend Const MP_NOTCONTROLTYPE As Int32 = &H470B120E                                 '/* Undefined Control type                              */
    Friend Const MP_NOTFILETYPE As Int32 = &H4B0B120F                                    '/* Undefined file type                                 */
    Friend Const MP_NOTSEMAPHORETYPE As Int32 = &H470B1210                               '/* Undefined semaphore type                            */
    Friend Const MP_NOTSYSTEMOPTION As Int32 = &H470B1211                                '/* Undefined system option                             */
    Friend Const MP_TIMEOUT_ERR As Int32 = &H470B1212                                    '/* Timeout error                                       */
    Friend Const MP_TIMEOUT As Int32 = &H470B1213                                        '/* Timeout                                             */
    Friend Const MP_NOTSUBSCRIBETYPE As Int32 = &H470B1214                               '/* Undefined scan type                                 */
    Friend Const MP_NOTSCANTYPE As Int32 = &H4B0B1214                                    '/* Undefined scan type                                 */
    Friend Const MP_DEVICEOFFSETOVER As Int32 = &H470B1300                               '/* Out-of-range device offset                          */
    Friend Const MP_DEVICEBITOFFSETOVER As Int32 = &H470B1301                            '/* Out-of-range bit offset                             */
    Friend Const MP_UNITCOUNTOVER As Int32 = &H4B0B1302                                  '/* Out-of-range quantity                               */
    Friend Const MP_COMPAREVALUEOVER As Int32 = &H4B0B1303                               '/* Out-of-range compared value                         */
    Friend Const MP_FCOMPAREVALUEOVER As Int32 = &H4B0B1304                              '/* Out-of-range floating-point compared value          */
    Friend Const MP_EVENTCOUNTOVER As Int32 = &H470B1305                                 '/* Out-of-range virtual interruption number            */
    Friend Const MP_VALUEOVER As Int32 = &H470B1306                                      '/* Out-of-range value                                  */
    Friend Const MP_FVALUEOVER As Int32 = &H470B1307                                     '/* Out-of-range floating point                         */
    Friend Const MP_PSTOREDVALUEOVER As Int32 = &H470B1308                               '/* Out-of-range storage position pointer               */
    Friend Const MP_PSTOREDFVALUEOVER As Int32 = &H470B1309                              '/* Out-of-range storage position pointer (floating decimal point value)    */
    Friend Const MP_SIZEOVER As Int32 = &H470B130A                                       '/* Out-of-range size                                   */
    Friend Const MP_RECEIVETIMEROVER As Int32 = &H470B1310                               '/* Out-of-range waiting time value for receiving       */
    Friend Const MP_RECNUMOVER As Int32 = &H470B1311                                     '/* Out-of-range number of records (MoveList)           */
    Friend Const MP_PARAMOVER As Int32 = &H4B0B1312                                      '/* Out-of-range parameter                              */
    Friend Const MP_FRAMEOVER As Int32 = &H470B1313                                      '/* Out-of-range number of frames                       */
    Friend Const MP_RADIUSOVER As Int32 = &H4B0B1314                                     '/* Out-of-range radius                                 */
    Friend Const MP_CONTROLLERNOOVER As Int32 = &H470B1315                               '/* Out-of-range device number                          */
    Friend Const MP_AXISNUMOVER As Int32 = &H4B0B1316                                    '/* Out-of-range number of axes                         */
    Friend Const MP_DIGITOVER As Int32 = &H4B0B1317                                      '/* Out-of-range number of digits                       */
    Friend Const MP_CALENDARVALUEOVER As Int32 = &H4B0B1318                              '/* Out-of-range calendar data                          */
    Friend Const MP_OFFSETOVER As Int32 = &H470B1319                                     '/* Out-of-range offset                                 */
    Friend Const MP_NUMBEROVER As Int32 = &H470B131A                                     '/* Out-of-range number of registers has been specified.*/
    Friend Const MP_RACKOVER As Int32 = &H470B131B                                       '/* Out-of-range rack number has been specified.        */
    Friend Const MP_SLOTOVER As Int32 = &H470B131C                                       '/* Out-of-range slot number has been specified.        */
    Friend Const MP_FIXVALUEOVER As Int32 = &H470B131D                                   '/* Fixed decimal point type data has been out of range.*/
    Friend Const MP_REGISTERINFOROVER As Int32 = &H470B131E                              '/* Out-of-range number of register infomation has been specified.*/
    Friend Const PC_MEMORY_ERR As Int32 = &H430B1400                                     '/* PC memory shortage                                  */
    Friend Const MP_NOCOMMUDEVICETYPE As Int32 = &H470B1500                              '/* Communication device type specification error       */
    Friend Const MP_NOTPROTOCOLTYPE As Int32 = &H470B1501                                '/* Invalid protocol type                               */
    Friend Const MP_NOTFUNCMODE As Int32 = &H470B1502                                    '/* Invalid function mode                               */
    Friend Const MP_MYADDROVER As Int32 = &H470B1503                                     '/* Out-of-range local station address has been set.    */
    Friend Const MP_NOTPORTTYPE As Int32 = &H470B1504                                    '/* Invalid port type                                   */
    Friend Const MP_NOTPROTMODE As Int32 = &H470B1505                                    '/* Invalid protocol mode                               */
    Friend Const MP_NOTCHARSIZE As Int32 = &H470B1506                                    '/* Invalid character bit length                        */
    Friend Const MP_NOTPARITYBIT As Int32 = &H470B1507                                   '/* Invalid parity bit                                  */
    Friend Const MP_NOTSTOPBIT As Int32 = &H470B1508                                     '/* Invalid stop bit                                    */
    Friend Const MP_NOTBAUDRAT As Int32 = &H470B1509                                     '/* Invalid transmission speed                          */
    Friend Const MP_TRANSDELAYOVER As Int32 = &H470B1510                                 '/* Out-of-range sending delay has been specified.      */
    Friend Const MP_PEERADDROVER As Int32 = &H470B1511                                   '/* Out-of-range remote station address has been specified. */
    Friend Const MP_SUBNETMASKOVER As Int32 = &H470B1512                                 '/* Out-of-range subnet mask has been specified.        */
    Friend Const MP_GWADDROVER As Int32 = &H470B1513                                     '/* Out-of-range GW address has been specified.         */
    Friend Const MP_DIAGPORTOVER As Int32 = &H470B1514                                   '/* Out-of-range diagnostic port has been specified.    */
    Friend Const MP_PROCRETRYOVER As Int32 = &H470B1515                                  '/* Out-of-range number of retries has been specified.  */
    Friend Const MP_TCPZEROWINOVER As Int32 = &H470B1516                                 '/* Out-of-range TCP zero window timer                  */
    Friend Const MP_TCPRETRYOVER As Int32 = &H470B1517                                   '/* Out-of-range TCP resending timer value              */
    Friend Const MP_TCPFINOVER As Int32 = &H470B1518                                     '/* Out-of-range completion timer value                 */
    Friend Const MP_IPASSEMBLEOVER As Int32 = &H470B1519                                 '/* Out-of-range IP incorporating timer value           */
    Friend Const MP_MAXPKTLENOVER As Int32 = &H470B1520                                  '/* Out-of-range maximum packet length                  */
    Friend Const MP_PEERPORTOVER As Int32 = &H470B1521                                   '/* Out-of-range remote station port                    */
    Friend Const MP_MYPORTOVER As Int32 = &H470B1522                                     '/* Out-of-range local station port                     */
    Friend Const MP_NOTTRANSPROT As Int32 = &H470B1523                                   '/* Invalid transport layer protocol                    */
    Friend Const MP_NOTAPPROT As Int32 = &H470B1524                                      '/* Invalid application layer protocol                  */
    Friend Const MP_NOTCODETYPE As Int32 = &H470B1525                                    '/* Invalid code type                                   */
    Friend Const MP_CYCTIMOVER As Int32 = &H470B1526                                     '/* Out-of-range communication cycle has been specified.*/
    Friend Const MP_NOTIOMAPCOM As Int32 = &H470B1527                                    '/* Invalid I/O commands                                */
    Friend Const MP_NOTIOTYPE As Int32 = &H470B1528                                      '/* Invalid I/O type specification                      */
    Friend Const MP_IOOFFSETOVER As Int32 = &H470B1529                                   '/* Out-of-range I/O offset has been allocated.         */
    Friend Const MP_IOSIZEOVER As Int32 = &H470B1530                                     '/* Out-of-range I/O size has been allocated (individualy). */
    Friend Const MP_TIOSIZEOVER As Int32 = &H470B1531                                    '/* Out-of-range I/O size has been allocated (total).   */
    Friend Const MP_MEMORY_ERR As Int32 = &H470B1532                                     '/* Controller memory shortage                          */
    Friend Const MP_NOTPTR As Int32 = &H470B1533                                         '/* Invalid pointer (communication device specification structure/device inherent information/pointer error to objective communication device handle)   */
    Friend Const MP_TABLEOVER As Int32 = &H43001800                                      '/* Event detection table resource cannot be got.       */
    Friend Const MP_ALARM As Int32 = &H43001801                                          '/* Alarm has occurred.                                 */
    Friend Const MP_MEMORYOVER As Int32 = &H43001802                                     '/* Memory resource cannot be got.                      */
    Friend Const MP_EXEC_ERR As Int32 = &H470B1803                                       '/* System execution error                              */
    Friend Const MP_NOTLOGICALAXIS As Int32 = &H470B1804                                 '/* Logical axis number error                           */
    Friend Const MP_NOTSUPPORTED As Int32 = &H470B1805                                   '/* Not supported                                       */
    Friend Const MP_ILLTEXT As Int32 = &H470B1806                                        '/* Out-of-range length of character string was input.  */
    Friend Const MP_NOFILENAME As Int32 = &H470B1807                                     '/* File name has not been set.                         */
    Friend Const MP_NOTREGSTERNAME As Int32 = &H470B1808                                 '/* Specified register data name cannot be found.       */
    Friend Const MP_FILEALREADYOPEN As Int32 = &H4B0B1809                                '/* The same file has already been opened.              */
    Friend Const MP_NOFILEPACKET As Int32 = &H470B180A                                   '/* Specified source file packet cannot be found.       */
    Friend Const MP_NOTFILEPACKETSIZE As Int32 = &H470B180B                              '/* Source file packet size is incorrect.               */
    Friend Const MP_NOTUSERFUNCTION As Int32 = &H4B0B180C                                '/* Specified user funtion does not exist.              */
    Friend Const MP_NOTPARAMETERTYPE As Int32 = &H4B0B180D                               '/* Specified parameter type does not exist.            */
    Friend Const MP_ILLREGHANDLETYPE As Int32 = &H470B180E                               '/* Erroneous register handle type specified.           */
    Friend Const MP_ILLREGTYPE As Int32 = &H470B1810                                     '/* Erroneous register type specified.                  */
    Friend Const MP_ILLREGSIZE As Int32 = &H470B1811                                     '/* Erroneous register size specified.(other than WORD) */
    Friend Const MP_REGNUMOVER As Int32 = &H470B1812                                     '/* Out-of-range register                               */
    Friend Const MP_RELEASEWAIT As Int32 = &H470B1813                                    '/* Waiting status released                             */
    Friend Const MP_PRIORITYOVER As Int32 = &H470B1814                                   '/* Priority that can not be set                        */
    Friend Const MP_NOTCHANGEPRIORITY As Int32 = &H470B1815                              '/* Priority that cannot be changed                     */
    Friend Const MP_SEMAPHOREOVER As Int32 = &H470B1816                                  '/* Semaphore definition over                           */
    Friend Const MP_NOTSEMAPHOREHANDLE As Int32 = &H470B1817                             '/* Undefined semaphore handle specification            */
    Friend Const MP_SEMAPHORELOCKED As Int32 = &H470B1818                                '/* Specified semaphore handle being locked             */
    Friend Const MP_CONTINUE_RELEASEWAIT As Int32 = &H470B1819                           '/* Waiting status released during ymcContinueWaitForCompletion */
    Friend Const MP_NOTTABLENAME As Int32 = &H4B0B1820                                   '/* Undefined Table name                                */
    Friend Const MP_ILLTABLETYPE As Int32 = &H470B1821                                   '/* Illegal Table Type                                  */
    Friend Const MP_TIMEOUTVALUEOVER As Int32 = &H470B1822                               '/* Out-of-range timeout value has been specified       */
    Friend Const MP_OTHER_ERR As Int32 = &H470B19FF                                      '/* Other errors   
#End Region
#Region "Constant"
    Friend Const COMMUNICATION_TIME_OUT As Integer = 1000
#End Region
    '////////////////////////////////////////////////////////////
    ' ymcPCAPI Declare List
    '////////////////////////////////////////////////////////////
    '***********************************************************
    '               Sequential/event, common motion APIs
    '***********************************************************
    '===========================================================
    '               device
    '===========================================================
    ''' <summary>
    ''' Deleting axis all definition
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Declare Function ymcClearAllAxes Lib "ymcPCAPI.dll" () As Int32

    ' Function name: ymcDeclareAxis (Declaring axis handle)
    Declare Function ymcDeclareAxis Lib "ymcPCAPI.dll" (ByVal RackNo As Int16, ByVal SlotNo As Int16, ByVal SubslotNo As Int16, ByVal AxisNo As Int16, ByVal LogicalAxisNo As Int16, ByVal AxisType As Int16, ByVal pAxisName As String, ByRef m_Axishandle As Int32) As Int32

    ' Function name: ymcClearAxis (Deleting axis definition)
    Declare Function ymcClearAxis Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32) As Int32

    ' Function name: ymcDeclareDevice (Declaring device)
    Declare Function ymcDeclareDevice Lib "ymcPCAPI.dll" (ByVal AxisNum As Int16, ByRef pAxis As Int32, ByRef pDevice As Int32) As Int32

    ' Function name: ymcClearDevice (Deleting device)
    Declare Function ymcClearDevice Lib "ymcPCAPI.dll" (ByVal hDevice As Int32) As Int32

    ' Function name: ymcGetAxisHandle (Getting axis handle information)
    Declare Function ymcGetAxisHandle Lib "ymcPCAPI.dll" (ByVal SpecifyType As Int16, ByVal RackNo As Int16, ByVal SlotNo As Int16, ByVal SubslotNo As Int16, ByVal AxisNo As Int16, ByVal LogicalAxisNo As Int16, ByVal pAxisName As String, ByRef m_Axishandle As Int32) As Int32

    '===========================================================
    '               Unit conversion function
    '===========================================================
    ' Function name: ymcConvertFloat2Fix (Converting floating-point data to fixed-point data)
    Declare Function ymcConvertFloat2Fix Lib "ymcPCAPI.dll" (ByVal Digit As Int16, ByVal FloatValue As Double, ByRef pFixValue As Int32) As Int32

    ' Function name: ymcConvertFix2Float (Converting fixed-point data to floating-point data)
    Declare Function ymcConvertFix2Float Lib "ymcPCAPI.dll" (ByVal Digit As Int16, ByVal FixValue As Int32, ByRef pFloatValue As Double) As Int32

    '===========================================================
    '               axis Information
    '===========================================================

    ' Function name: ymcMoveTorque (Torque reference function)
    Declare Function ymcMoveTorque Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pSpeedLimit As POSITION_DATA, ByRef pTorqueData As POSITION_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               parameter operation
    '===========================================================
    ' Function name: ymcSetMotionParameterValue (Motion parameter setting)
    Declare Function ymcSetMotionParameterValue Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32, ByVal ParameterType As Int16, ByVal ParameterOffset As Int32, ByVal Value As Int32) As Int32

    ' Function name: ymcGetMotionParameterValue (Motion parameter got)
    Declare Function ymcGetMotionParameterValue Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32, ByVal ParameterType As Int16, ByVal ParameterOffset As Int32, ByRef pStoredValue As Int32) As Int32

    ' Function name: ymcDefinePosition (Setting current position)
    Declare Function ymcDefinePosition Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pPos As POSITION_DATA) As Int32

    '***********************************************************
    '               Sequential motion APIs
    '***********************************************************
    '===========================================================
    '               Positioning function
    '===========================================================
    ' Function name: ymcMovePositioning (Positioning: sequential type)
    Declare Function ymcMovePositioning Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcMoveExternalPositioning (External positioning)
    Declare Function ymcMoveExternalPositioning Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByRef pMaxLatchPos As POSITION_DATA, ByRef pMinLatchPos As POSITION_DATA, ByRef pDistance As POSITION_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcMoveIntimePositioning (Positioning with time specification function)
    Declare Function ymcMoveIntimePositioning Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByRef pPositioningTime As DWORD_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcMoveHomePosition (Home position return)
    Declare Function ymcMoveHomePosition Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pOffsetPosition As POSITION_DATA, ByRef pHomingMethod As Int16, ByRef pDirection As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcMoveDriverPositioning (Driver positioning)
    Declare Function ymcMoveDriverPositioning Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcStopMotion (Stopping axis execution)
    Declare Function ymcStopMotion Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcMoveJOG (Executing JOG operation)
    Declare Function ymcMoveJOG Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pDirection As Int16, ByRef pTimeout As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcStopJOG (Stopping JOG operation)
    Declare Function ymcStopJOG Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               interpolation
    '===========================================================
    ' Function name: ymcMoveLinear (Linear interpolation)
    Declare Function ymcMoveLinear Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name(): ymcMoveCircularRadius [Circular interpolation (radius specified)]
    Declare Function ymcMoveCircularRadius Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pEndPoint As POSITION_DATA, ByRef pRadius As DWORD_DATA, ByRef pTurnNumber As DWORD_DATA, ByVal Direction As Int16, ByVal AngleType As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name(): ymcMoveCircularCenter [Circular interpolation (center point coordinate specified)]
    Declare Function ymcMoveCircularCenter Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pEndPoint As POSITION_DATA, ByRef pCenter As POSITION_DATA, ByRef pTurnNumber As DWORD_DATA, ByVal Direction As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name(): ymcMoveHelicalRadius [Helical interpolation (radius specified)]
    Declare Function ymcMoveHelicalRadius Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pEndPoint As POSITION_DATA, ByRef pRadius As DWORD_DATA, ByRef pTurnNumber As DWORD_DATA, ByVal Direction As Int16, ByVal AngleType As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    '  Function name(): ymcMoveHelicalCenter [Helical interpolation (center point coordinate specified)]
    Declare Function ymcMoveHelicalCenter Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pEndPoint As POSITION_DATA, ByRef pCenter As POSITION_DATA, ByRef pTurnNumber As DWORD_DATA, ByVal Direction As Int16, ByVal hMoveIO As Int32, ByVal pObjectName As String, ByVal WaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               Synchronization (Gear)
    '===========================================================
    ' Function name: ymcEnableGear (Starting gear control)
    Declare Function ymcEnableGear Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32, ByVal hDevice As Int32, ByVal MasterType As Int32, ByRef pSyncDistance As SYNC_DISTANCE, ByRef pStatus As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcDisableGear (Stopping gear control)
    Declare Function ymcDisableGear Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32, ByVal hDevice As Int32, ByVal MasterType As Int32, ByRef pSyncDistance As SYNC_DISTANCE, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcSetGearRatio (Setting gear ratio)
    Declare Function ymcSetGearRatio Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pGearRatioData As GEAR_RATIO_DATA, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               compensation
    '===========================================================
    ' Function name: ymcPositionOffset (Position compensation)
    Declare Function ymcPositionOffset Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pPositionOffset As POSITION_OFFSET_DATA, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               Motion operation
    '===========================================================
    ' Function name: ymcChangeDynamics (Changing motion data)
    Declare Function ymcChangeDynamics Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByRef pMotionData As MOTION_DATA, ByRef pPos As POSITION_DATA, ByVal Subject As Int32, ByVal pObjectName As String, ByVal SystemOption As Int32) As Int32

    '===========================================================
    '               Driver operation
    '===========================================================
    ' Function name: ymcServoControl (Servo ON or OFF)
    Declare Function ymcServoControl Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByVal ControlType As Int16, ByVal Timeout As Int16) As Int32

    '===========================================================
    '               others
    '===========================================================
    ' Function name: ymcEnableLatch (Starting latch)
    Declare Function ymcEnableLatch Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByVal pObjectName As String, ByRef pWaitForCompletion As Int16, ByVal SystemOption As Int32) As Int32

    ' Function name: ymcDisableLatch (Stopping latch)
    Declare Function ymcDisableLatch Lib "ymcPCAPI.dll" (ByVal hDevice As Int32, ByVal pObjectName As String, ByVal SystemOption As Int32) As Int32

    '***********************************************************
    '               System APIs
    '***********************************************************
    '===========================================================
    '               Data operation
    '===========================================================
    ' Function name: ymcSetIoDataBit (Setting bit)
    Declare Function ymcSetIoDataBit Lib "ymcPCAPI.dll" (ByRef pIoData As IO_DATA, ByVal BitValue As Int32) As Int32

    ' Function name: ymcGetIoDataBit (Getting bit)
    Declare Function ymcGetIoDataBit Lib "ymcPCAPI.dll" (ByRef pIoData As IO_DATA, ByRef pStoredBitValue As Int32) As Int32

    ' Function name: ymcSetIoDataValue (Setting data)
    Declare Function ymcSetIoDataValue Lib "ymcPCAPI.dll" (ByRef pIoData As IO_DATA, ByVal Value As Int32) As Int32

    ' Function name: ymcGetIoDataValue (Getting data)
    Declare Function ymcGetIoDataValue Lib "ymcPCAPI.dll" (ByRef pIoData As IO_DATA, ByRef pStoredValue As Int32) As Int32

    ' Function name: ymcSetRegisterData (Setting value to register) for Word Register
    Declare Function ymcSetRegisterData Lib "ymcPCAPI.dll" (ByVal hRegisterData As Int32, ByVal RegisterDataNumber As Int32, ByRef pRegisterData As Int16) As Int32
    ' Function name: ymcSetRegisterData (Setting value to register) for Long Register
    Declare Function ymcSetRegisterData Lib "ymcPCAPI.dll" (ByVal hRegisterData As Int32, ByVal RegisterDataNumber As Int32, ByRef pRegisterData As Int32) As Int32

    ' Function name: ymcGetRegisterData (Reading value from register) for Word Register
    Declare Function ymcGetRegisterData Lib "ymcPCAPI.dll" (ByVal hRegisterData As Int32, ByVal RegisterDataNumber As Int32, ByRef pRegisterData As Int32, ByRef pReadDataNumber As Int32) As Int32
    ' Function name: ymcGetRegisterData (Reading value from register) for Long Register
    Declare Function ymcGetRegisterData Lib "ymcPCAPI.dll" (ByVal hRegisterData As Int32, ByVal RegisterDataNumber As Int32, ByRef pRegisterData As Int16, ByRef pReadDataNumber As Int32) As Int32

    ' Function name: ymcGetRegisterDataHandle (Getting register handle)
    Declare Function ymcGetRegisterDataHandle Lib "ymcPCAPI.dll" (ByVal pRegisterName As String, ByRef hRegisterData As Int32) As Int32

    ' Function name: ymcSetGroupRegisterData (Setting value to register (Multi))
    Declare Function ymcSetGroupRegisterData Lib "ymcPCAPI.dll" (ByVal GroupNumber As Int32, ByVal pResisterInfo() As REGISTER_INFO) As Int32

    ' Function name: ymcGetGroupRegisterData (Reading value from register (Multi))
    Declare Function ymcGetGroupRegisterData Lib "ymcPCAPI.dll" (ByVal GroupNumber As Int32, ByVal pResisterInfo() As REGISTER_INFO) As Int32
    '===========================================================
    '               System Information
    '==========================================================
    ' Function name: ymcClearAlarm (Clearing alarm)
    Declare Function ymcClearAlarm Lib "ymcPCAPI.dll" (ByVal hAlarm As Int32) As Int32

    '  Function name: ymcClearServoAlarm (Clearing alarm)
    Declare Function ymcClearServoAlarm Lib "ymcPCAPI.dll" (ByVal m_Axishandle As Int32) As Int32

    ' Function name: ymcGetAlarm (Getting current alarm)
    Declare Function ymcGetAlarm Lib "ymcPCAPI.dll" (ByVal Number As Int32, ByRef pAlarm As Int32, <OutAttribute()> ByVal pAlarmInfo() As ALARM_INFO, ByRef pAlarmNumber As Int32) As Int32

    '============================================================
    '               System operation
    '============================================================
    ' Function name: ymcSetController (Changing target MP2100)
    Declare Function ymcSetController Lib "ymcPCAPI.dll" (ByVal hController As Int32) As Int32

    ' Function name: ymcGetController (Getting the current target Controller handle)
    Declare Function ymcGetController Lib "ymcPCAPI.dll" (ByRef hController As Int32) As Int32

    ' Function name: ymcResetController (reset target MP2100)
    Declare Function ymcResetController Lib "ymcPCAPI.dll" (ByVal hController As Int32) As Int32

    ' Function name: ymcGetBusIFData (Getting value to BusIF)
    Declare Function ymcGetBusIFData Lib "ymcPCAPI.dll" (ByVal Offset As Int32, ByVal Size As Int32, ByRef pBusIFData As Int16) As Int32

    ' Function name: ymcSetBusIFData (Setting value to BusIF)
    Declare Function ymcSetBusIFData Lib "ymcPCAPI.dll" (ByVal Offset As Int32, ByVal Size As Int32, ByRef pBusIFData As Int16) As Int32

    ' Function name: ymcGetBusIFInfo (Setting value to BusIF Information)
    Declare Function ymcGetBusIFInfo Lib "ymcPCAPI.dll" (ByRef pBusIFInfo As BUSIF_INFO) As Int32

    '============================================================
    '				Declaring or deleting ComDevice
    '============================================================
    ' Function name: ymcOpenController (Declaring ComDevice)
    Declare Function ymcOpenController Lib "ymcPCAPI.dll" (ByRef pComDevice As COM_DEVICE, ByRef hController As Int32) As Int32

    ' Function name: ymcCloseController (Deleting ComDevice)
    Declare Function ymcCloseController Lib "ymcPCAPI.dll" (ByVal hController As Int32) As Int32

    '============================================================
    '  				Calendar operation
    '============================================================
    ' Function name: ymcSetCalendar (Setting calendar)
    Declare Function ymcSetCalendar Lib "ymcPCAPI.dll" (ByRef pCalendarData As CALENDAR_DATA) As Int32

    ' Function name: ymcGetCalendar (Getting calendar)
    Declare Function ymcGetCalendar Lib "ymcPCAPI.dll" (ByRef pCalendarData As CALENDAR_DATA) As Int32


    '============================================================
    '				Last error
    '============================================================
    ' Function name: ymcGetLastError (Reading out last error)
    Declare Function ymcGetLastError Lib "ymcPCAPI.dll" () As Int32

    '============================================================
    ' 				Timer
    '============================================================
    ' Function name: ymcSetAPITimeoutValue
    Declare Function ymcSetAPITimeoutValue Lib "ymcPCAPI.dll" (ByVal TimeoutValue As Int32) As Int32

    ' Funciton name: ymcWaitTime
    Declare Function ymcWaitTime Lib "ymcPCAPI.dll" (ByVal WaitTime As Int32, ByVal pObjectName As String) As Int32
End Module
