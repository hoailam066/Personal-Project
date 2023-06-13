Imports Automation.BDaq
Imports Timer
Friend Class CAdvantech1711DI
    Private m_DI() As CDIBased
    Private Shared m_DiCtrl As Automation.BDaq.InstantDiCtrl
    Friend Sub New(ByRef pDI() As CDIBased)
        m_DI = pDI
        If m_DiCtrl Is Nothing Then   m_DiCtrl = New Automation.BDaq.InstantDiCtrl
    End Sub
    Friend Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Dim portId As Integer
        Dim bitId As Integer
        Dim rtn As Byte

        Dim deviceInfo As Automation.BDaq.DeviceInformation
        deviceInfo.DeviceMode = Automation.BDaq.AccessMode.ModeRead
        deviceInfo.Description = "PCI-1711,BID#" & m_DI(SnrIdx).CardID
        m_DiCtrl.SelectedDevice = deviceInfo
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
End Class
Friend Class CAdvantech1711DO
    Private m_DO() As CDOBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_DoCtrl As Automation.BDaq.InstantDoCtrl
    Friend Sub New(ByRef pDO() As CDOBased)
        m_DO = pDO
        m_Timer = New CHighResolutionTimer
        If m_DoCtrl Is Nothing Then   m_DoCtrl = New Automation.BDaq.InstantDoCtrl
    End Sub
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

        Dim deviceInfo As Automation.BDaq.DeviceInformation
        deviceInfo.DeviceMode = Automation.BDaq.AccessMode.ModeWriteWithReset
        deviceInfo.Description = "PCI-1711,BID#" & m_DO(CylIdx).CardIDAction
        m_DoCtrl.SelectedDevice = deviceInfo
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
End Class
Friend Class CAdvantech1711AI
    Private m_AI() As CAnalogInBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_AiCtrl As Automation.BDaq.InstantAiCtrl
    Friend Sub New(ByRef pAI() As CAnalogInBased)
        m_AI = pAI
        m_Timer = New CHighResolutionTimer
        If m_AiCtrl Is Nothing Then  m_AiCtrl = New Automation.BDaq.InstantAiCtrl
    End Sub
    Friend Sub ReadVoltage(ByVal AnalogInIdx As Integer, ByRef pVoltage As Double)
        Try
            Dim deviceInfo As Automation.BDaq.DeviceInformation
            deviceInfo.DeviceMode = Automation.BDaq.AccessMode.ModeRead
            deviceInfo.Description = "PCI-1711,BID#" & m_AI(AnalogInIdx).CardID
            m_AiCtrl.SelectedDevice = deviceInfo
            Dim errCode As Automation.BDaq.ErrorCode
            errCode = m_AiCtrl.Read(m_AI(AnalogInIdx).BitID, pVoltage)
        Catch ex As Exception
        Finally
        End Try
    End Sub
End Class
Friend Class CAdvantech1711AO
    Private m_AO() As CAnalogOutBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_AoCtrl As Automation.BDaq.InstantAoCtrl
    Friend Sub New(ByRef pAO() As CAnalogOutBased)
        m_AO = pAO
        m_Timer = New CHighResolutionTimer
        If m_AoCtrl Is Nothing Then m_AoCtrl = New Automation.BDaq.InstantAoCtrl
    End Sub
    Friend Sub SetVoltage(ByVal AnalogOutIdx As Integer, ByVal Voltage As Double)
        Try
            Dim deviceInfo As Automation.BDaq.DeviceInformation
            deviceInfo.DeviceMode = Automation.BDaq.AccessMode.ModeWriteWithReset
            deviceInfo.Description = "PCI-1711,BID#" & m_AO(AnalogOutIdx).CardID
            m_AoCtrl.SelectedDevice = deviceInfo
            Dim errCode As Automation.BDaq.ErrorCode
            errCode = m_AoCtrl.Write(m_AO(AnalogOutIdx).BitID, Voltage)
        Catch ex As Exception
        Finally
        End Try
    End Sub
End Class