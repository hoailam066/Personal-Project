Public Class CHome
    Private m_Cancel As Boolean
    Private m_HighSpeed As Double
    Private m_LowSpeed As Double
    Private m_Acc As Double
    Private m_Offset As Double

    Private m_EscapeDis As Double
    ''' <summary>
    ''' 復歸時遮到原點要直接退開距離
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EscapeDis() As Double
        Get
            Return m_EscapeDis
        End Get
        Set(ByVal value As Double)
            m_EscapeDis = value
        End Set
    End Property

    Public Property Cancel() As Boolean
        Get
            Return m_Cancel
        End Get
        Set(ByVal value As Boolean)
            m_Cancel = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HighSpeed() As Double
        Get
            Return m_HighSpeed
        End Get
        Set(ByVal value As Double)
            m_HighSpeed = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LowSpeed() As Double
        Get
            Return m_LowSpeed
        End Get
        Set(ByVal value As Double)
            m_LowSpeed = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Acc() As Double
        Get
            Return m_Acc
        End Get
        Set(ByVal value As Double)
            m_Acc = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Offset() As Double
        Get
            Return m_Offset
        End Get
        Set(ByVal value As Double)
            m_Offset = value
        End Set
    End Property
End Class
