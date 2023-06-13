Public Enum enumStsTopIDs
    Unknow
    Home
End Enum
Public Enum enumStsWorkholderIDs
    Unknow
    Home

    SubstrateInOk
    SubstrateInError
    SubstrateOutOk
    SubstrateOutError
    RunOK
    RunError
    RunCuttingError
    RunImageError
    ImageAlignmentOK
    ImageAlignmentError
    ImageAlignmentEmpty
    PunchOK
    PunchWorkholderVaccumError
    BlowVaccumError
End Enum
Public Enum enumStsSubstrateIDs
    Unknow
    MoveInOK
    MoveInError
    MoveOutOK
End Enum



Public Class CSystemStatus
    Private m_TopSys As enumStsTopIDs
    Public Property TopSys() As enumStsTopIDs
        Get
            Return m_TopSys
        End Get
        Set(ByVal value As enumStsTopIDs)
            m_TopSys = value
        End Set
    End Property
    Private m_WorkholderSys As enumStsWorkholderIDs
    Public Property WorkholderSys() As enumStsWorkholderIDs
        Get
            Return m_WorkholderSys
        End Get
        Set(ByVal value As enumStsWorkholderIDs)
            m_WorkholderSys = value
        End Set
    End Property
    Private m_SubstrateSys As enumStsSubstrateIDs
    Public Property SubstrateSys() As enumStsSubstrateIDs
        Get
            Return m_SubstrateSys
        End Get
        Set(ByVal value As enumStsSubstrateIDs)
            m_SubstrateSys = value
        End Set
    End Property
End Class
