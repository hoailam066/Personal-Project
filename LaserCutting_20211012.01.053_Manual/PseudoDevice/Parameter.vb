Public Class CAxisParameter
    Private m_SwMax As Double
    Private m_SwMin As Double
    Private m_SwScale As Double
    Private m_EnrScale As Double
    ''' <summary>
    ''' 軟體正極限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SwMax() As Double
        Get
            Return m_SwMax
        End Get
        Set(ByVal value As Double)
            m_SwMax = value
        End Set
    End Property
    ''' <summary>
    ''' 軟體負極限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SwMin() As Double
        Get
            Return m_SwMin
        End Get
        Set(ByVal value As Double)
            m_SwMin = value
        End Set
    End Property
    ''' <summary>
    ''' 物理單位和脈衝量轉換比例
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SwScale() As Double
        Get
            Return m_SwScale
        End Get
        Set(ByVal value As Double)
            m_SwScale = value
        End Set
    End Property
    ''' <summary>
    ''' 物理單位和脈衝量轉換比例
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EnrScale() As Double
        Get
            Return m_EnrScale
        End Get
        Set(ByVal value As Double)
            m_EnrScale = value
        End Set
    End Property
End Class
