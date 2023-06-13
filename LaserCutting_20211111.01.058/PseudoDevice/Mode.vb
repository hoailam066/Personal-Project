Public Class CMode
    Private m_AlarmMode As Short
    Private m_AlarmLogic As Short
    Private m_InpEnable As Short
    Private m_InpLogic As Short
    Private m_SdEnable As Short
    Private m_SdLogic As Short
    Private m_SdLatch As Short
    Private m_SdMode As Short
    Private m_ServoONLogic As Short
    Private m_ERCEnable As Short
    Private m_ERCLogic As Short
    Private m_HomeMode As Short
    Private m_OrgLogic As Short
    Private m_OrgLatch As Short
    Private m_EZLogic As Short
    Private m_PCSLogic As Short
    Private m_PCSEnable As Short
    Private m_ClrMode As Short
    Private m_HomeDir As Short
    Private m_IsServo As Boolean
    Private m_PulseLogic As Short
    Private m_PulseOutMode As Short
    Private m_PulseInputMode As Short
    Private m_CurveMode As Short
    Private m_LimitMode As Short
    Private m_LimitLogic As Short
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlarmMode() As Short
        Get
            Return m_AlarmMode
        End Get
        Set(ByVal value As Short)
            m_AlarmMode = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlarmLogic() As Short
        Get
            Return m_AlarmLogic
        End Get
        Set(ByVal value As Short)
            m_AlarmLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InpEnable() As Short
        Get
            Return m_InpEnable
        End Get
        Set(ByVal value As Short)
            m_InpEnable = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property InpLogic() As Short
        Get
            Return m_InpLogic
        End Get
        Set(ByVal value As Short)
            m_InpLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SdEnable() As Short
        Get
            Return m_SdEnable
        End Get
        Set(ByVal value As Short)
            m_SdEnable = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SdLogic() As Short
        Get
            Return m_SdLogic
        End Get
        Set(ByVal value As Short)
            m_SdLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SdLatch() As Short
        Get
            Return m_SdLatch
        End Get
        Set(ByVal value As Short)
            m_SdLatch = value
        End Set
    End Property
    Public Property SdMode() As Short
        Get
            Return m_SdMode
        End Get
        Set(ByVal value As Short)
            m_SdMode = value
        End Set
    End Property
    Public Property ServoONLogic() As Short
        Get
            Return m_ServoONLogic
        End Get
        Set(ByVal value As Short)
            m_ServoONLogic = value
        End Set
    End Property

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ERCEnable() As Short
        Get
            Return m_ERCEnable
        End Get
        Set(ByVal value As Short)
            m_ERCEnable = value
        End Set
    End Property
    Public Property ERCLogic() As Short
        Get
            Return m_ERCLogic
        End Get
        Set(ByVal value As Short)
            m_ERCLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HomeMode() As Short
        Get
            Return m_HomeMode
        End Get
        Set(ByVal value As Short)
            m_HomeMode = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrgLogic() As Short
        Get
            Return m_OrgLogic
        End Get
        Set(ByVal value As Short)
            m_OrgLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrgLatch() As Short
        Get
            Return m_OrgLatch
        End Get
        Set(ByVal value As Short)
            m_OrgLatch = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EZLogic() As Short
        Get
            Return m_EZLogic
        End Get
        Set(ByVal value As Short)
            m_EZLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PCSLogic() As Short
        Get
            Return m_PCSLogic
        End Get
        Set(ByVal value As Short)
            m_PCSLogic = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PCSEnable() As Short
        Get
            Return m_PCSEnable
        End Get
        Set(ByVal value As Short)
            m_PCSEnable = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ClrMode() As Short
        Get
            Return m_ClrMode
        End Get
        Set(ByVal value As Short)
            m_ClrMode = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property HomeDir() As Short
        Get
            Return m_HomeDir
        End Get
        Set(ByVal value As Short)
            m_HomeDir = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsServo() As Boolean
        Get
            Return m_IsServo
        End Get
        Set(ByVal value As Boolean)
            m_IsServo = value
        End Set
    End Property
    Public Property PulseLogic() As Short
        Get
            Return m_PulseLogic
        End Get
        Set(ByVal value As Short)
            m_PulseLogic = value
        End Set
    End Property
    Public Property PulseOutMode() As Short
        Get
            Return m_PulseOutMode
        End Get
        Set(ByVal value As Short)
            m_PulseOutMode = value
        End Set
    End Property
    Public Property PulseInputMode() As Short
        Get
            Return m_PulseInputMode
        End Get
        Set(ByVal value As Short)
            m_PulseInputMode = value
        End Set
    End Property
    Public Property CurveMode() As Short
        Get
            Return m_CurveMode
        End Get
        Set(ByVal value As Short)
            m_CurveMode = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LimitMode() As Short
        Get
            Return m_LimitMode
        End Get
        Set(ByVal value As Short)
            m_LimitMode = value
        End Set
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LimitLogic() As Short
        Get
            Return m_LimitLogic
        End Get
        Set(ByVal value As Short)
            m_LimitLogic = value
        End Set
    End Property
End Class
