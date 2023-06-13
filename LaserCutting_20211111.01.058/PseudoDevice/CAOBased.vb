Friend Class CAnalogOutBased
    Friend Sub New()
        m_CardType = enumDAQCard.None
        m_CardID = -1
        m_BitID = -1
        m_Name = "Default"
        m_NameChinese = "Default"
        m_LaserScale1 = 1
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private m_CardType As enumDAQCard
    Friend Property CardType() As enumDAQCard
        Get
            Return m_CardType
        End Get
        Set(ByVal value As enumDAQCard)
            m_CardType = value
        End Set
    End Property
    Private m_CardID As Integer
    Friend Property CardID() As Integer
        Get
            Return m_CardID
        End Get
        Set(ByVal value As Integer)
            m_CardID = value
        End Set
    End Property
    Private m_BitID As Integer
    Friend Property BitID() As Integer
        Get
            Return m_BitID
        End Get
        Set(ByVal value As Integer)
            m_BitID = value
        End Set
    End Property
    Private m_Name As String
    Friend Property Name() As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property
    Private m_NameChinese As String
    Friend Property NameChinese() As String
        Get
            Return m_NameChinese
        End Get
        Set(ByVal value As String)
            m_NameChinese = value
        End Set
    End Property
    Private m_WavePattern(0 To 99, 0 To 199) As Short 'Jimmy
    Friend Property WavePattern(ByVal AryIdx As Integer, ByVal PatternIdx As Integer) As Short
        Get
            Return m_WavePattern(AryIdx, PatternIdx)
        End Get
        Set(ByVal value As Short)
            m_WavePattern(AryIdx, PatternIdx) = value
        End Set
    End Property
    Friend ReadOnly Property WavePatternAry() As Short(,)
        Get
            Return m_WavePattern
        End Get
    End Property
    Private m_LaserScale1 As Double
    Friend Property LaserScale1() As Double
        Get
            Return m_LaserScale1
        End Get
        Set(ByVal value As Double)
            m_LaserScale1 = value
        End Set
    End Property
End Class