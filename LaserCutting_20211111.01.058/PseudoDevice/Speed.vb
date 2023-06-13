Public Class CSpeed


    Private m_MaxVelExt As Double             '// Speed storage variable (for 3 axes)
    Private m_AccExt As Double             '// Acceleration storage variable (for 3 axes)
    Private m_DecExt As Double

    Private m_Acc As Double             '// Acceleration storage variable (for 3 axes)
    Private m_Dec As Double             '// Deceleration storage variable (for 3 axes)
    Private m_AccLinear As Double
    Private m_AccCircle As Double
    Private m_DecLinear As Double
    Private m_DecCircle As Double
    Private m_MaxVelLinear As Double
    Private m_MaxVelCircle As Double

    Private m_MaxConstrainedVel As Double
    Private m_RatioMaxVel As Double
    Private m_RatioAcc As Double
    Private m_MaxVel As Double
    Private m_StrVel As Double
    Private m_Tacc As Double
    Private m_Tdec As Double
    Private m_Sacc As Double
    Private m_Sdec As Double
    Private m_Iacc As Double
    Private m_Idec As Double
 
    Public Property MaxVelExt() As Double
        Get
            Return m_MaxVelExt
        End Get
        Set(ByVal value As Double)
            m_MaxVelExt = value
        End Set
    End Property
    Public Property AccExt() As Double
        Get
            Return m_AccExt
        End Get
        Set(ByVal value As Double)
            m_AccExt = value
        End Set
    End Property
    Public Property DecExt() As Double
        Get
            Return m_DecExt
        End Get
        Set(ByVal value As Double)
            m_DecExt = value
        End Set
    End Property
    Public Property Acc() As Double
        Get
            Return m_Acc
        End Get
        Set(ByVal value As Double)
            m_Acc = value
        End Set
    End Property
    Public Property Dec() As Double
        Get
            Return m_Dec
        End Get
        Set(ByVal value As Double)
            m_Dec = value
        End Set
    End Property
    Public Property AccLinear() As Double
        Get
            Return m_AccLinear
        End Get
        Set(ByVal value As Double)
            m_AccLinear = value
        End Set
    End Property
    Public Property AccCircle() As Double
        Get
            Return m_AccCircle
        End Get
        Set(ByVal value As Double)
            m_AccCircle = value
        End Set
    End Property
    Public Property DecLinear() As Double
        Get
            Return m_DecLinear
        End Get
        Set(ByVal value As Double)
            m_DecLinear = value
        End Set
    End Property
    Public Property DecCircle() As Double
        Get
            Return m_DecCircle
        End Get
        Set(ByVal value As Double)
            m_DecCircle = value
        End Set
    End Property
    Public Property MaxVelLinear() As Double
        Get
            Return m_MaxVelLinear
        End Get
        Set(ByVal value As Double)
            m_MaxVelLinear = value
        End Set
    End Property
    Public Property MaxVelCircle() As Double
        Get
            Return m_MaxVelCircle
        End Get
        Set(ByVal value As Double)
            m_MaxVelCircle = value
        End Set
    End Property
    ''' <summary>
    ''' 最大脈波速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxConstrainedVel() As Double
        Get
            Return m_MaxConstrainedVel
        End Get
        Set(ByVal value As Double)
            m_MaxConstrainedVel = value
        End Set
    End Property
    ''' <summary>
    ''' 速度比例
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RatioMaxVel() As Double
        Get
            Return m_RatioMaxVel
        End Get
        Set(ByVal value As Double)
            If value >= 1 Then value = 1
            If value <= 0.1 Then value = 0.1
            m_RatioMaxVel = value
        End Set
    End Property
    ''' <summary>
    ''' 加速度時間比例
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RatioAcc() As Double
        Get
            Return m_RatioAcc
        End Get
        Set(ByVal value As Double)
            If value >= 10 Then value = 10
            If value <= 1 Then value = 1
            m_RatioAcc = value
        End Set
    End Property
    ''' <summary>
    ''' 速度剖面最大速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaxVel() As Double
        Get
            Return m_MaxVel
        End Get
        Set(ByVal value As Double)
            m_MaxVel = value
        End Set
    End Property
    ''' <summary>
    ''' 速度剖面起始速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StrVel() As Double
        Get
            Return m_StrVel
        End Get
        Set(ByVal value As Double)
            m_StrVel = value
        End Set
    End Property
    ''' <summary>
    ''' 速度剖面加速段急跳度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Iacc() As Double
        Get
            Return m_Iacc
        End Get
        Set(ByVal value As Double)
            m_Iacc = value
        End Set
    End Property
    ''' <summary>
    ''' 速度剖面減速段急跳度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Idec() As Double
        Get
            Return m_Idec
        End Get
        Set(ByVal value As Double)
            m_Idec = value
        End Set
    End Property
    ''' <summary>
    ''' 加速時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tacc() As Double
        Get
            Return m_Tacc
        End Get
        Set(ByVal value As Double)
            m_Tacc = value
        End Set
    End Property
    ''' <summary>
    ''' 減速時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Tdec() As Double
        Get
            Return m_Tdec
        End Get
        Set(ByVal value As Double)
            m_Tdec = value
        End Set
    End Property
    ''' <summary>
    ''' 加速段S曲線速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sacc() As Double
        Get
            Return m_Sacc
        End Get
        Set(ByVal value As Double)
            m_Sacc = value
        End Set
    End Property
    ''' <summary>
    ''' 減速段S曲線速度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Sdec() As Double
        Get
            Return m_Sdec
        End Get
        Set(ByVal value As Double)
            m_Sdec = value
        End Set
    End Property
End Class
