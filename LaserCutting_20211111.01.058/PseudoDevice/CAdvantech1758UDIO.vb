Imports Automation.BDaq
Imports Timer
Friend Class CAdvantech1758UDI
    Private m_DI() As CDIBased
    Private Shared m_DiCtrl As Automation.BDaq.InstantDiCtrl
    Private Shared m_WiringID(63) As Integer
    Friend Sub New(ByRef pDI() As CDIBased)
        m_DI = pDI
        If m_DiCtrl Is Nothing Then
            m_DiCtrl = New Automation.BDaq.InstantDiCtrl
            m_DiCtrl.SelectedDevice = New Automation.BDaq.DeviceInformation(2, "PCI-1758UDIO,BID#0", AccessMode.ModeRead, 0)
        End If

        m_WiringID(0) = 7
        m_WiringID(1) = 8
        m_WiringID(2) = 9
        m_WiringID(3) = 10
        m_WiringID(4) = 11
        m_WiringID(5) = 12
        m_WiringID(6) = 13
        m_WiringID(7) = 14
        m_WiringID(8) = 15
        m_WiringID(9) = 16
        m_WiringID(10) = 17
        m_WiringID(11) = 18
        m_WiringID(12) = 19
        m_WiringID(13) = 20
        m_WiringID(14) = 21
        m_WiringID(15) = 22
        m_WiringID(16) = 33
        m_WiringID(17) = 34
        m_WiringID(18) = 35
        m_WiringID(19) = 36
        m_WiringID(20) = 37
        m_WiringID(21) = 38
        m_WiringID(22) = 39
        m_WiringID(23) = 40
        m_WiringID(24) = 41
        m_WiringID(25) = 42
        m_WiringID(26) = 43
        m_WiringID(27) = 44
        m_WiringID(28) = 45
        m_WiringID(29) = 46
        m_WiringID(30) = 47
        m_WiringID(31) = 48
        m_WiringID(32) = 57
        m_WiringID(33) = 58
        m_WiringID(34) = 59
        m_WiringID(35) = 60
        m_WiringID(36) = 61
        m_WiringID(37) = 62
        m_WiringID(38) = 63
        m_WiringID(39) = 64
        m_WiringID(40) = 65
        m_WiringID(41) = 66
        m_WiringID(42) = 67
        m_WiringID(43) = 68
        m_WiringID(44) = 69
        m_WiringID(45) = 70
        m_WiringID(46) = 71
        m_WiringID(47) = 72
        m_WiringID(48) = 83
        m_WiringID(49) = 84
        m_WiringID(50) = 85
        m_WiringID(51) = 86
        m_WiringID(52) = 87
        m_WiringID(53) = 88
        m_WiringID(54) = 89
        m_WiringID(55) = 90
        m_WiringID(56) = 91
        m_WiringID(57) = 92
        m_WiringID(58) = 93
        m_WiringID(59) = 94
        m_WiringID(60) = 95
        m_WiringID(61) = 96
        m_WiringID(62) = 97
        m_WiringID(63) = 98
    End Sub

    Friend ReadOnly Property WiringID(ByVal SnrIdx As Integer) As Integer
        Get
            Dim WiringIdx As Integer
            If (m_DI(SnrIdx).BitID >= LBound(m_WiringID)) And m_DI(SnrIdx).BitID <= UBound(m_WiringID) Then
                WiringIdx = m_WiringID(m_DI(SnrIdx).BitID)
            End If
            Return WiringIdx
        End Get
    End Property
    Friend Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Dim portId As Integer
        Dim bitId As Integer
        Dim rtn As Byte
        bitId = m_DI(SnrIdx).BitID Mod 8
        portId = m_DI(SnrIdx).BitID \ 8
        m_DiCtrl.Read(portId, rtn)
        If m_DI(SnrIdx).Logic Then
            If (rtn And 2 ^ bitId) = 2 ^ bitId Then
                pStatus = True
            Else
                pStatus = False
            End If
        Else
            If (rtn And 2 ^ bitId) = 2 ^ bitId Then
                pStatus = False
            Else
                pStatus = True
            End If
        End If
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
Friend Class CAdvantech1758UDO
    Private m_DO() As CDOBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_DoCtrl As Automation.BDaq.InstantDoCtrl
    Private Shared m_WiringID(63) As Integer

    Friend Sub New(ByRef pDO() As CDOBased)
        m_DO = pDO
        m_Timer = New CHighResolutionTimer
        If m_DoCtrl Is Nothing Then
            m_DoCtrl = New Automation.BDaq.InstantDoCtrl
            m_DoCtrl.SelectedDevice = New Automation.BDaq.DeviceInformation(2, "PCI-1758UDIO,BID#0", AccessMode.ModeWriteWithReset, 0)
        End If

        m_WiringID(0) = 7
        m_WiringID(1) = 8
        m_WiringID(2) = 9
        m_WiringID(3) = 10
        m_WiringID(4) = 11
        m_WiringID(5) = 12
        m_WiringID(6) = 13
        m_WiringID(7) = 14
        m_WiringID(8) = 15
        m_WiringID(9) = 16
        m_WiringID(10) = 17
        m_WiringID(11) = 18
        m_WiringID(12) = 19
        m_WiringID(13) = 20
        m_WiringID(14) = 21
        m_WiringID(15) = 22
        m_WiringID(16) = 33
        m_WiringID(17) = 34
        m_WiringID(18) = 35
        m_WiringID(19) = 36
        m_WiringID(20) = 37
        m_WiringID(21) = 38
        m_WiringID(22) = 39
        m_WiringID(23) = 40
        m_WiringID(24) = 41
        m_WiringID(25) = 42
        m_WiringID(26) = 43
        m_WiringID(27) = 44
        m_WiringID(28) = 45
        m_WiringID(29) = 46
        m_WiringID(30) = 47
        m_WiringID(31) = 48
        m_WiringID(32) = 57
        m_WiringID(33) = 58
        m_WiringID(34) = 59
        m_WiringID(35) = 60
        m_WiringID(36) = 61
        m_WiringID(37) = 62
        m_WiringID(38) = 63
        m_WiringID(39) = 64
        m_WiringID(40) = 65
        m_WiringID(41) = 66
        m_WiringID(42) = 67
        m_WiringID(43) = 68
        m_WiringID(44) = 69
        m_WiringID(45) = 70
        m_WiringID(46) = 71
        m_WiringID(47) = 72
        m_WiringID(48) = 83
        m_WiringID(49) = 84
        m_WiringID(50) = 85
        m_WiringID(51) = 86
        m_WiringID(52) = 87
        m_WiringID(53) = 88
        m_WiringID(54) = 89
        m_WiringID(55) = 90
        m_WiringID(56) = 91
        m_WiringID(57) = 92
        m_WiringID(58) = 93
        m_WiringID(59) = 94
        m_WiringID(60) = 95
        m_WiringID(61) = 96
        m_WiringID(62) = 97
        m_WiringID(63) = 98
    End Sub
    Friend ReadOnly Property WiringIDAction(ByVal SnrIdx As Integer) As Integer
        Get
            Dim WiringIdx As Integer
            If (m_DO(SnrIdx).BitIDAction >= LBound(m_WiringID)) And m_DO(SnrIdx).BitIDAction <= UBound(m_WiringID) Then
                WiringIdx = m_WiringID(m_DO(SnrIdx).BitIDAction)
            End If
            Return WiringIdx
        End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CylIdx"></param>
    ''' <param name="Status"></param>
    ''' <remarks>
    ''' 0-> Action Close Normal Open
    ''' 1-> Action Close Normal Close
    ''' 2-> Action Open  Normal Close
    ''' </remarks>
    Friend Sub CylGo(ByVal CylIdx As Integer, ByVal Status As enumCyllogic)
        Dim cardId As Integer
        Dim portId As Integer
        Dim bitId As Integer

        Dim rtn As Byte
        Dim data As Byte
        Dim errCode As Automation.BDaq.ErrorCode
        Select Case Status
            Case enumCyllogic.Normal
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDAction Mod 8
                    portId = m_DO(CylIdx).BitIDAction \ 8
                    errCode = m_DoCtrl.Read(portId, rtn)
                    Select Case bitId
                        Case 0
                            data = 254
                        Case 1
                            data = 253
                        Case 2
                            data = 251
                        Case 3
                            data = 247
                        Case 4
                            data = 239
                        Case 5
                            data = 223
                        Case 6
                            data = 191
                        Case 7
                            data = 127
                    End Select
                    data = data And rtn
                    m_DoCtrl.Write(portId, data)
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDNormal Mod 8
                    portId = m_DO(CylIdx).BitIDNormal \ 8
                    m_DoCtrl.Read(portId, rtn)
                    data = 2 ^ bitId
                    data = data Or rtn
                    m_DoCtrl.Write(portId, data)
                End If
                If m_DO(CylIdx).Status = enumCyllogic.Normal Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.Normal
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If

            Case enumCyllogic.CloseAll
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDAction Mod 8
                    portId = m_DO(CylIdx).BitIDAction \ 8
                    m_DoCtrl.Read(portId, rtn)
                    Select Case bitId
                        Case 0
                            data = 254
                        Case 1
                            data = 253
                        Case 2
                            data = 251
                        Case 3
                            data = 247
                        Case 4
                            data = 239
                        Case 5
                            data = 223
                        Case 6
                            data = 191
                        Case 7
                            data = 127
                    End Select
                    data = data And rtn
                    m_DoCtrl.Write(portId, data)
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDNormal Mod 8
                    portId = m_DO(CylIdx).BitIDNormal \ 8
                    m_DoCtrl.Read(portId, rtn)
                    Select Case bitId
                        Case 0
                            data = 254
                        Case 1
                            data = 253
                        Case 2
                            data = 251
                        Case 3
                            data = 247
                        Case 4
                            data = 239
                        Case 5
                            data = 223
                        Case 6
                            data = 191
                        Case 7
                            data = 127
                    End Select
                    data = data And rtn
                    m_DoCtrl.Write(portId, data)
                End If
                If m_DO(CylIdx).Status = enumCyllogic.CloseAll Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.CloseAll
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If

            Case enumCyllogic.Action
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDAction Mod 8
                    portId = m_DO(CylIdx).BitIDAction \ 8
                    m_DoCtrl.Read(portId, rtn)
                    data = 2 ^ bitId
                    data = data Or rtn
                    m_DoCtrl.Write(portId, data)
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    bitId = m_DO(CylIdx).BitIDNormal Mod 8
                    portId = m_DO(CylIdx).BitIDNormal \ 8

                    m_DoCtrl.Read(portId, rtn)
                    Select Case bitId
                        Case 0
                            data = 254
                        Case 1
                            data = 253
                        Case 2
                            data = 251
                        Case 3
                            data = 247
                        Case 4
                            data = 239
                        Case 5
                            data = 223
                        Case 6
                            data = 191
                        Case 7
                            data = 127
                    End Select
                    data = data And rtn
                    m_DoCtrl.Write(portId, data)
                End If
                If m_DO(CylIdx).Status = enumCyllogic.Action Then
                Else
                    m_DO(CylIdx).Status = enumCyllogic.Action
                    m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                    m_DO(CylIdx).ProcessNum = 10
                End If
        End Select
    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
