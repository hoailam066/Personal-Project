Public Class CLaserRecipe
    Private m_Key As String
    Private m_Interval As Integer
    Private m_SpotSize As Integer
    Private m_Power() As Double
    Public Sub New()
        m_Key = "Laser0"
        m_Interval = 300
        m_SpotSize = 700
        m_Power = New Double() {44.0, 47.0, 52.0, 53.0, 54.0, 54.0, 54.0, 51.0, 51.0}
    End Sub
    Public Sub New(key As String, interval As Integer, spotSize As Integer, power As Double())
        Me.Key = key
        Me.Interval = interval
        Me.SpotSize = spotSize
        Me.Power = power
    End Sub

    Public Property Key As String
        Get
            Return m_Key
        End Get
        Set(value As String)
            m_Key = value
        End Set
    End Property

    Public Property Interval As Integer
        Get
            Return m_Interval
        End Get
        Set(value As Integer)
            m_Interval = value
        End Set
    End Property

    Public Property SpotSize As Integer
        Get
            Return m_SpotSize
        End Get
        Set(value As Integer)
            m_SpotSize = value
        End Set
    End Property

    Public Property Power As Double() '0.0~100.0
        Get
            Return m_Power
        End Get
        Set(ByVal value As Double())
            m_Power = value
        End Set
    End Property
    Public Function Clone() As CLaserRecipe
        Dim res As CLaserRecipe = New CLaserRecipe()
        res.Interval = Me.Interval
        res.Key = Me.Key
        res.SpotSize = Me.SpotSize
        Array.Copy(Me.Power, res.Power, Me.Power.Length)
        Return res
    End Function
End Class
