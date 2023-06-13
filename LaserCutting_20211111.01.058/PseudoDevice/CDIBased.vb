Friend Class CDIBased
    Friend Sub New()
        m_CardType = enumDAQCard.None
        m_CardID = -1
        m_BitID = -1
        m_Logic = True
        m_IsIgnore = False
        m_Name = "Default"
        m_NameChinese = "Default"
        m_WiringID = -1
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private m_WiringID As Integer
    Friend Property WiringID() As Integer
        Get
            Return m_WiringID
        End Get
        Set(ByVal value As Integer)
            m_WiringID = value
        End Set
    End Property
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
    Private m_SlaveID As Integer
    Friend Property SlaveID() As Integer
        Get
            Return m_SlaveID
        End Get
        Set(ByVal value As Integer)
            m_SlaveID = value
        End Set
    End Property
    Private m_ConnectIndex As Integer
    Friend Property ConnectIndex() As Integer
        Get
            Return m_ConnectIndex
        End Get
        Set(ByVal value As Integer)
            m_ConnectIndex = value
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
    Private m_BitAdress As String
    Friend Property BitAdress() As String
        Get
            Return m_BitAdress
        End Get
        Set(ByVal value As String)
            m_BitAdress = value
        End Set
    End Property
    Private m_Logic As Boolean
    Friend Property Logic() As Boolean
        Get
            Return m_Logic
        End Get
        Set(ByVal value As Boolean)
            m_Logic = value
        End Set
    End Property
    Private m_IsIgnore As Boolean
    Friend Property IsIgnore() As Boolean
        Get
            Return m_IsIgnore
        End Get
        Set(ByVal value As Boolean)
            m_IsIgnore = value
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
