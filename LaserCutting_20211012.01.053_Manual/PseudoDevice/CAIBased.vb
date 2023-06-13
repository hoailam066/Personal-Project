Friend Class CAnalogInBased
    Friend Sub New()
        m_CardType = enumDAQCard.None
        m_CardID = -1
        m_BitID = -1
        m_Name = "Default"
        m_NameChinese = "Default"
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
End Class
