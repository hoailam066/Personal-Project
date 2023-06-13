Public Enum enumCmdTopIDs
    NoCommand
    Home
    Work
End Enum
Public Enum enumCmdWorkholderIDs
    NoCommand
    Home
    SubstrateIn
    Punch
    ImageAlignment
    Run
    SubstrateOut
End Enum
Public Enum enumCmdSubstrateIDs
    NoCommand
    MoveIn
    MoveOut
End Enum
Public Class CSystemCommand
    Private m_TopSys As enumCmdTopIDs
    Public Property TopSys() As enumCmdTopIDs
        Get
            Return m_TopSys
        End Get
        Set(ByVal value As enumCmdTopIDs)
            m_TopSys = value
        End Set
    End Property
    Private m_WorkholderSys As enumCmdWorkholderIDs
    Public Property WorkholderSys() As enumCmdWorkholderIDs
        Get
            Return m_WorkholderSys
        End Get
        Set(ByVal value As enumCmdWorkholderIDs)
            m_WorkholderSys = value
        End Set
    End Property
    Private m_SubstrateSys As enumCmdSubstrateIDs
    Public Property SubstrateSys() As enumCmdSubstrateIDs
        Get
            Return m_SubstrateSys
        End Get
        Set(ByVal value As enumCmdSubstrateIDs)
            m_SubstrateSys = value
        End Set
    End Property
End Class
