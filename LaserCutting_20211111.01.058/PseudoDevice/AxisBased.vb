Public Class CAxisBased
    Private m_CardID As Integer
    Private m_AxisID As Short
    Private m_ThreadID As Integer

    Private m_IsExternalParameters As Boolean
    Private m_TargetPosition As Double   'Single Axis Move          '// Target position storage variable (for 3 axes)
    Private m_EndX As Double             'Two Axis Linear Move
    Private m_EndY As Double
    Private m_CenterX As Double             'Two Axis Linear Move
    Private m_CenterY As Double
    Private m_Direction As Integer
    Private m_TurnCount As Double
     
    Private m_IsHwCriticalErr As Boolean
    Private m_CardName As String
    Private m_AxisName As String
    Private m_CardType As enumMotionCard
    Private m_Parameter As CAxisParameter
    Private m_Home As CHome
    Private m_Mode As CMode
    Private m_Speed As CSpeed
    Private m_IO As CIO
    Private m_Status As CMotionStatus
    Private m_IsThreadStarted As Boolean
    Private m_IsThreadFinished As Boolean
    Private m_IsHomming As Boolean
    Private m_ErrMessage As String = ""

    Friend Property IsHomming() As Boolean
        Get
            Return m_IsHomming
        End Get
        Set(ByVal value As Boolean)
            m_IsHomming = value
        End Set
    End Property

    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property

    Public Property ThreadID() As Integer
        Get
            Return m_ThreadID
        End Get
        Set(ByVal value As Integer)
            m_ThreadID = value
        End Set
    End Property
    Public Property IsExternalParameters() As Boolean
        Get
            Return m_IsExternalParameters
        End Get
        Set(ByVal value As Boolean)
            m_IsExternalParameters = value
        End Set
    End Property
    Public Property TargetPosition() As Double
        Get
            Return m_TargetPosition
        End Get
        Set(ByVal value As Double)
            m_TargetPosition = value
        End Set
    End Property
    Public Property EndX() As Double
        Get
            Return m_EndX
        End Get
        Set(ByVal value As Double)
            m_EndX = value
        End Set
    End Property
    Public Property EndY() As Double
        Get
            Return m_EndY
        End Get
        Set(ByVal value As Double)
            m_EndY = value
        End Set
    End Property
    Public Property CenterX() As Double
        Get
            Return m_CenterX
        End Get
        Set(ByVal value As Double)
            m_CenterX = value
        End Set
    End Property
    Public Property CenterY() As Double
        Get
            Return m_CenterY
        End Get
        Set(ByVal value As Double)
            m_CenterY = value
        End Set
    End Property
    Public Property Direction() As Integer
        Get
            Return m_Direction
        End Get
        Set(ByVal value As Integer)
            m_Direction = value
        End Set
    End Property
    Public Property TurnCount() As Double
        Get
            Return m_TurnCount
        End Get
        Set(ByVal value As Double)
            m_TurnCount = value
        End Set
    End Property
    Public Property IsThreadStarted() As Boolean
        Get
            Return m_IsThreadStarted
        End Get
        Set(ByVal value As Boolean)
            m_IsThreadStarted = value
        End Set
    End Property
    Public Property IsThreadFinished() As Boolean
        Get
            Return m_IsThreadFinished
        End Get
        Set(ByVal value As Boolean)
            m_IsThreadFinished = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CardID() As Integer
        Get
            Return m_CardID
        End Get
        Set(ByVal value As Integer)
            m_CardID = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AxisID() As Short
        Get
            Return m_AxisID
        End Get
        Set(ByVal value As Short)
            m_AxisID = value
        End Set
    End Property
    Private m_GroupID As Short
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property GroupID() As Short
        Get
            Return m_GroupID
        End Get
        Set(ByVal value As Short)
            m_GroupID = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property CardName() As String
        Get
            Return m_CardName
        End Get
        Set(ByVal value As String)
            m_CardName = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AxisName() As String
        Get
            Return m_AxisName
        End Get
        Set(ByVal value As String)
            m_AxisName = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Property CardType() As enumMotionCard
        Get
            Return m_CardType
        End Get
        Set(ByVal value As enumMotionCard)
            m_CardType = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Param() As CAxisParameter
        Get
            Return m_Parameter
        End Get
        Set(ByVal value As CAxisParameter)
            m_Parameter = value
        End Set

    End Property
    Public Property Home() As CHome
        Get
            Return m_Home
        End Get
        Set(ByVal value As CHome)
            m_Home = value
        End Set

    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Mode() As CMode
        Get
            Return m_Mode
        End Get
        Set(ByVal value As CMode)
            m_Mode = value
        End Set

    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Speed() As CSpeed
        Get
            Return m_Speed
        End Get
        Set(ByVal value As CSpeed)
            m_Speed = value
        End Set

    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IO() As CIO
        Get
            Return m_IO
        End Get
        Set(ByVal value As CIO)
            m_IO = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Status() As CMotionStatus
        Get
            Return m_Status
        End Get
        Set(ByVal value As CMotionStatus)
            m_Status = value
        End Set
    End Property
    Public Sub New()
        m_CardID = -1
        m_GroupID = -1
        m_AxisID = -1
        m_CardName = ""
        m_AxisName = ""
        If m_Parameter Is Nothing Then m_Parameter = New CAxisParameter
        If m_Home Is Nothing Then m_Home = New CHome
        If m_Mode Is Nothing Then m_Mode = New CMode
        If m_Speed Is Nothing Then m_Speed = New CSpeed
        If m_IO Is Nothing Then m_IO = New CIO
        m_Status = New CMotionStatus
        IsThreadFinished = True
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
