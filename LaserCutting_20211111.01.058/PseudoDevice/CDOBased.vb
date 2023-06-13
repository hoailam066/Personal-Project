Friend Class CDOBased
    Friend Sub New()
        m_CardType = enumDAQCard.None
        m_CardIDAction = -1
        m_CardIDNormal = -1
        m_BitIDAction = -1
        m_BitIDNormal = -1
        m_BitAdressAction = ""
        m_BitAdressNormal = ""
        m_SatbleTimeAction = 0
        m_SatbleTimeNormal = 0
        m_AlarmTime = 5000
        m_SnrIdxAction = -1
        m_SnrIdxNormal = -1
        m_Status = enumCyllogic.Default
        m_ProcessNum = 0
        m_StartTime = 0
        m_StartChkTime = 0
        m_Name = "Default"
        m_NameChinese = "Default"
        m_NameActionNormal = "Default"
        m_NameNormalAction = "Default"
        NameNormalNormal = "Default"

    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private m_WiringIDAction As Integer
    Friend Property WiringIDAction() As Integer
        Get
            Return m_WiringIDAction
        End Get
        Set(ByVal value As Integer)
            m_WiringIDAction = value
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
    Private m_CardIDAction As Integer
    Friend Property CardIDAction() As Integer
        Get
            Return m_CardIDAction
        End Get
        Set(ByVal value As Integer)
            m_CardIDAction = value
        End Set
    End Property
    Private m_CardIDNormal As Integer
    Friend Property CardIDNormal() As Integer
        Get
            Return m_CardIDNormal
        End Get
        Set(ByVal value As Integer)
            m_CardIDNormal = value
        End Set
    End Property
    Private m_ConnectIndexAction As Integer
    Friend Property ConnectIndexAction() As Integer
        Get
            Return m_ConnectIndexAction
        End Get
        Set(ByVal value As Integer)
            m_ConnectIndexAction = value
        End Set
    End Property
    Private m_ConnectIndexNormal As Integer
    Friend Property ConnectIndexNormal() As Integer
        Get
            Return m_ConnectIndexNormal
        End Get
        Set(ByVal value As Integer)
            m_ConnectIndexNormal = value
        End Set
    End Property

    Private m_SlaveIDAction As Integer
    Friend Property SlaveIDAction() As Integer
        Get
            Return m_SlaveIDAction
        End Get
        Set(ByVal value As Integer)
            m_SlaveIDAction = value
        End Set
    End Property
    Private m_SlaveIDNormal As Integer
    Friend Property SlaveIDNormal() As Integer
        Get
            Return m_SlaveIDNormal
        End Get
        Set(ByVal value As Integer)
            m_SlaveIDNormal = value
        End Set
    End Property
    Private m_BitIDAction As Integer
    Friend Property BitIDAction() As Integer
        Get
            Return m_BitIDAction
        End Get
        Set(ByVal value As Integer)
            m_BitIDAction = value
        End Set
    End Property
    Private m_BitIDNormal As Integer
    Friend Property BitIDNormal() As Integer
        Get
            Return m_BitIDNormal
        End Get
        Set(ByVal value As Integer)
            m_BitIDNormal = value
        End Set
    End Property
    Private m_SatbleTimeAction As Integer
    Friend Property SatbleTimeAction() As Integer
        Get
            Return m_SatbleTimeAction
        End Get
        Set(ByVal value As Integer)
            m_SatbleTimeAction = value
        End Set
    End Property
    Private m_SatbleTimeNormal As Integer
    Friend Property SatbleTimeNormal() As Integer
        Get
            Return m_SatbleTimeNormal
        End Get
        Set(ByVal value As Integer)
            m_SatbleTimeNormal = value
        End Set
    End Property
    Private m_AlarmTime As Integer
    Friend Property AlarmTime() As Integer
        Get
            Return m_AlarmTime
        End Get
        Set(ByVal value As Integer)
            m_AlarmTime = value
        End Set
    End Property
    Private m_SnrIdxAction As Integer
    Friend Property SnrIdxAction() As Integer
        Get
            Return m_SnrIdxAction
        End Get
        Set(ByVal value As Integer)
            m_SnrIdxAction = value
        End Set
    End Property
    Private m_SnrIdxNormal As Integer
    Friend Property SnrIdxNormal() As Integer
        Get
            Return m_SnrIdxNormal
        End Get
        Set(ByVal value As Integer)
            m_SnrIdxNormal = value
        End Set
    End Property
    Private m_Status As enumCyllogic
    Friend Property Status() As enumCyllogic
        Get
            Return m_Status
        End Get
        Set(ByVal value As enumCyllogic)
            m_Status = value
        End Set
    End Property
    Private m_ProcessNum As Integer
    Friend Property ProcessNum() As Integer
        Get
            Return m_ProcessNum
        End Get
        Set(ByVal value As Integer)
            m_ProcessNum = value
        End Set
    End Property
    Private m_StartTime As Double
    Friend Property StartTime() As Double
        Get
            Return m_StartTime
        End Get
        Set(ByVal value As Double)
            m_StartTime = value
        End Set
    End Property
    Private m_StartChkTime As Double
    Friend Property StartChkTime() As Double
        Get
            Return m_StartChkTime
        End Get
        Set(ByVal value As Double)
            m_StartChkTime = value
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
    Private m_NameActionNormal As String
    Friend Property NameActionNormal() As String
        Get
            Return m_NameActionNormal
        End Get
        Set(ByVal value As String)
            m_NameActionNormal = value
        End Set
    End Property
    Private m_NameNormalAction As String
    Friend Property NameNormalAction() As String
        Get
            Return m_NameNormalAction
        End Get
        Set(ByVal value As String)
            m_NameNormalAction = value
        End Set
    End Property
    Private m_NameNormalNormal As String
    Friend Property NameNormalNormal() As String
        Get
            Return m_NameNormalNormal
        End Get
        Set(ByVal value As String)
            m_NameNormalNormal = value
        End Set
    End Property

    Private m_BitAdressAction As String
    Friend Property BitAdressAction() As String
        Get
            Return m_BitAdressAction
        End Get
        Set(ByVal value As String)
            m_BitAdressAction = value
        End Set
    End Property
    Private m_BitAdressNormal As String
    Friend Property BitAdressNormal() As String
        Get
            Return m_BitAdressNormal
        End Get
        Set(ByVal value As String)
            m_BitAdressNormal = value
        End Set
    End Property
End Class
