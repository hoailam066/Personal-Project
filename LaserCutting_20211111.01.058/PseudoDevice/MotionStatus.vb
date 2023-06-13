Public Class CMotionStatus
    Private m_HomeRdy As enumMotionFlag
    'Private m_AxisIsBusying As enumMotionFlag
    Private m_MovementIsFinished As enumMotionFlag
    'Private m_PositiveLimitSwitch As enumMotionFlag
    'Private m_NegativeLimitSwitch As enumMotionFlagAs enumMotionFlag
    'Private m_AlarmSignal As enumMotionFlag
    Private m_MoveRdy As enumMotionFlag = enumMotionFlag.eReady
    Public Property HomeRdy() As enumMotionFlag
        Get
            Return m_HomeRdy
        End Get
        Set(ByVal value As enumMotionFlag)
            m_HomeRdy = value
        End Set
    End Property

    Public Property MoveRdy() As enumMotionFlag
        Get
            Return m_MoveRdy
        End Get
        Set(ByVal value As enumMotionFlag)
            m_MoveRdy = value
        End Set
    End Property

    'Public Property AxisIsBusying() As enumMotionFlag
    '    Get
    '        Return m_AxisIsBusying
    '    End Get
    '    Set(ByVal value As enumMotionFlag)
    '        m_AxisIsBusying = value
    '    End Set
    'End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MovementIsFinished() As enumMotionFlag
        Get
            Return m_MovementIsFinished
        End Get
        Set(ByVal value As enumMotionFlag)
            m_MovementIsFinished = value
        End Set
    End Property

    Private m_MotionSts As String
    Public Property MotionSts() As String
        Get
            Return m_MotionSts
        End Get
        Set(ByVal value As String)
            m_MotionSts = value
        End Set
    End Property

    'Public Property PositiveLimitSwitch() As enumMotionFlag
    '    Get
    '        Return m_PositiveLimitSwitch
    '    End Get
    '    Set(ByVal value As enumMotionFlag)
    '        m_PositiveLimitSwitch = value
    '    End Set
    'End Property

    'Public Property NegativeLimitSwitch() As enumMotionFlag
    '    Get
    '        Return m_NegativeLimitSwitch
    '    End Get
    '    Set(ByVal value As enumMotionFlag)
    '        m_NegativeLimitSwitch = value
    '    End Set
    'End Property

    'Public Property OriginSwitch() As enumMotionFlag
    '    Get
    '        Return m_OriginSwitch
    '    End Get
    '    Set(ByVal value As enumMotionFlag)
    '        m_OriginSwitch = value
    '    End Set
    'End Property

    'Public Property AlarmSignal() As enumMotionFlag
    '    Get
    '        Return m_AlarmSignal
    '    End Get
    '    Set(ByVal value As enumMotionFlag)
    '        m_AlarmSignal = value
    '    End Set
    'End Property
End Class
