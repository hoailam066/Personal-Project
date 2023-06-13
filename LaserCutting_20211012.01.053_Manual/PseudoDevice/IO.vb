Public Class CIO
    ''' <summary>
    ''' RDY
    ''' </summary>
    ''' <remarks></remarks>
    Private m_RdyInput As enumMotionFlag
    ''' <summary>
    ''' ALM
    ''' </summary>
    ''' <remarks></remarks>
    Private m_AlarmSignal As enumMotionFlag
    ''' <summary>
    ''' +EL
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PositiveLimitSwitch As enumMotionFlag
    ''' <summary>
    ''' -EL
    ''' </summary>
    ''' <remarks></remarks>
    Private m_NegativeLimitSwitch As enumMotionFlag
    ''' <summary>
    ''' ORG
    ''' </summary>
    ''' <remarks></remarks>
    Private m_OriginSwitch As enumMotionFlag
    ''' <summary>
    ''' DIR
    ''' </summary>
    ''' <remarks></remarks>
    Private m_DIROutput As enumMotionFlag
    ''' <summary>
    ''' EMG
    ''' </summary>
    ''' <remarks></remarks>
    Private m_EMGStatus As enumMotionFlag
    ''' <summary>
    ''' PCS
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PCSSignalInput As enumMotionFlag
    ''' <summary>
    ''' ERC
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ERCOutput As enumMotionFlag
    ''' <summary>
    ''' EZ
    ''' </summary>
    ''' <remarks></remarks>
    Private m_IndexSignal As enumMotionFlag
    ''' <summary>
    ''' CLR
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ClearSignal As enumMotionFlag
    ''' <summary>
    ''' LTC
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LatchSignalInput As enumMotionFlag
    ''' <summary>
    ''' INP
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InPositionSignalInput As enumMotionFlag
    ''' <summary>
    ''' SVON
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ServoOnOutput As enumMotionFlag
    ''' <summary>
    ''' +SD
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PositiveSlowDownPoint As enumMotionFlag
    ''' <summary>
    ''' -SD
    ''' </summary>
    ''' <remarks></remarks>
    Private m_NegativeSlowDownPoint As enumMotionFlag
    ''' <summary>
    ''' INT
    ''' </summary>
    ''' <remarks></remarks>
    Private m_InterruptStatus As enumMotionFlag
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PositiveLimitSwitch() As enumMotionFlag
        Get
            Return m_PositiveLimitSwitch
        End Get
        Set(ByVal value As enumMotionFlag)
            m_PositiveLimitSwitch = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NegativeLimitSwitch() As enumMotionFlag
        Get
            Return m_NegativeLimitSwitch
        End Get
        Set(ByVal value As enumMotionFlag)
            m_NegativeLimitSwitch = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PositiveSlowDownPoint() As enumMotionFlag
        Get
            Return m_PositiveSlowDownPoint
        End Get
        Set(ByVal value As enumMotionFlag)
            m_PositiveSlowDownPoint = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property NegativeSlowDownPoint() As enumMotionFlag
        Get
            Return m_NegativeSlowDownPoint
        End Get
        Set(ByVal value As enumMotionFlag)
            m_NegativeSlowDownPoint = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OriginSwitch() As enumMotionFlag
        Get
            Return m_OriginSwitch
        End Get
        Set(ByVal value As enumMotionFlag)
            m_OriginSwitch = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IndexSignal() As enumMotionFlag
        Get
            Return m_IndexSignal
        End Get
        Set(ByVal value As enumMotionFlag)
            m_IndexSignal = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlarmSignal() As enumMotionFlag
        Get
            Return m_AlarmSignal
        End Get
        Set(ByVal value As enumMotionFlag)
            m_AlarmSignal = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ServoOnOutput() As enumMotionFlag
        Get
            Return m_ServoOnOutput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_ServoOnOutput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RdyInput() As enumMotionFlag
        Get
            Return m_RdyInput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_RdyInput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InterruptStatus() As enumMotionFlag
        Get
            Return m_InterruptStatus
        End Get
        Set(ByVal value As enumMotionFlag)
            m_InterruptStatus = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ERCOutput() As enumMotionFlag
        Get
            Return m_ERCOutput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_ERCOutput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InPositionSignalInput() As enumMotionFlag
        Get
            Return m_InPositionSignalInput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_InPositionSignalInput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DIROutput() As enumMotionFlag
        Get
            Return m_DIROutput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_DIROutput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EMGStatus() As enumMotionFlag
        Get
            Return m_EMGStatus
        End Get
        Set(ByVal value As enumMotionFlag)
            m_EMGStatus = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PCSSignalInput() As enumMotionFlag
        Get
            Return m_PCSSignalInput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_PCSSignalInput = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClearSignal() As enumMotionFlag
        Get
            Return m_ClearSignal
        End Get
        Set(ByVal value As enumMotionFlag)
            m_ClearSignal = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LatchSignalInput() As enumMotionFlag
        Get
            Return m_LatchSignalInput
        End Get
        Set(ByVal value As enumMotionFlag)
            m_LatchSignalInput = value
        End Set
    End Property
End Class
