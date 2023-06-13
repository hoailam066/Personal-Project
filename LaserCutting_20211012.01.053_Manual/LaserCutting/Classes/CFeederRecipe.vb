Public Class CFeederRecipe
    Private m_Key As String
    Private m_ForwardDelay As Integer
    Private m_ForwardSpeed1 As Integer
    Private m_ForwardSpeed2 As Integer
    Private m_ForwardDistance1 As Double
    Private m_ForwardDistance2 As Double
    Private m_BackwardDelay As Integer
    Private m_BackwardSpeed As Integer
    Private m_BackwardDistance As Double

    Public Sub New()
        Me.Key = "Feeder0"
        Me.ForwardDelay = 350
        Me.ForwardSpeed1 = 17
        Me.ForwardSpeed2 = 10
        Me.ForwardDistance1 = 3.0
        Me.ForwardDistance2 = 5.5
        Me.BackwardDelay = 1
        Me.BackwardSpeed = 100
        Me.BackwardDistance = 3.5
    End Sub

    Public Sub New(key As String, forwardDelay As Integer, forwardSpeed1 As Integer, forwardSpeed2 As Integer, forwardDistance1 As Double, forwardDistance2 As Double, backwardDelay As Integer, backwardSpeed As Integer, backwardDistance As Double)
        Me.Key = key
        Me.ForwardDelay = forwardDelay
        Me.ForwardSpeed1 = forwardSpeed1
        Me.ForwardSpeed2 = forwardSpeed2
        Me.ForwardDistance1 = forwardDistance1
        Me.ForwardDistance2 = forwardDistance2
        Me.BackwardDelay = backwardDelay
        Me.BackwardSpeed = backwardSpeed
        Me.BackwardDistance = backwardDistance
    End Sub

    Public Property Key As String
        Get
            Return m_Key
        End Get
        Set(value As String)
            m_Key = value
        End Set
    End Property

    Public Property ForwardDelay As Integer
        Get
            Return m_ForwardDelay
        End Get
        Set(value As Integer)
            m_ForwardDelay = value
        End Set
    End Property

    Public Property ForwardSpeed1 As Integer
        Get
            Return m_ForwardSpeed1
        End Get
        Set(value As Integer)
            m_ForwardSpeed1 = value
        End Set
    End Property

    Public Property ForwardSpeed2 As Integer
        Get
            Return m_ForwardSpeed2
        End Get
        Set(value As Integer)
            m_ForwardSpeed2 = value
        End Set
    End Property

    Public Property ForwardDistance1 As Double
        Get
            Return m_ForwardDistance1
        End Get
        Set(value As Double)
            m_ForwardDistance1 = value
        End Set
    End Property

    Public Property ForwardDistance2 As Double
        Get
            Return m_ForwardDistance2
        End Get
        Set(value As Double)
            m_ForwardDistance2 = value
        End Set
    End Property

    Public Property BackwardDelay As Integer
        Get
            Return m_BackwardDelay
        End Get
        Set(value As Integer)
            m_BackwardDelay = value
        End Set
    End Property

    Public Property BackwardSpeed As Integer
        Get
            Return m_BackwardSpeed
        End Get
        Set(value As Integer)
            m_BackwardSpeed = value
        End Set
    End Property

    Public Property BackwardDistance As Double
        Get
            Return m_BackwardDistance
        End Get
        Set(value As Double)
            m_BackwardDistance = value
        End Set
    End Property
    Public Function Clone() As CFeederRecipe
        Return New CFeederRecipe(Me.Key, Me.ForwardDelay, Me.ForwardSpeed1, Me.ForwardSpeed2, Me.ForwardDistance1, Me.ForwardDistance2, Me.BackwardDelay, Me.BackwardSpeed, Me.BackwardDistance)
    End Function

End Class