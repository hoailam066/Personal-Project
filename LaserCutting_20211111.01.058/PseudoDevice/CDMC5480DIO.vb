Option Explicit On
Imports Timer
Imports System.Threading
Friend Class CDMC5480DIO
#Region "Error Const"
#End Region
#Region "Prototype"
    Protected Sub New()
        ' TODO: Complete member initialization 
    End Sub
#End Region

End Class
Friend Class CDMC5480DI
    Inherits CDMC5480DIO
    Private m_DI() As CDIBased
    Friend Sub New(ByRef pDI() As CDIBased)
        Try
            m_DI = pDI
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Unexpected Error")
        Finally
        End Try
    End Sub
    Friend Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Dim rtn As Integer
        Dim cardID As Short
        Dim bitID As Short
        Try
            cardID = CShort(m_DI(SnrIdx).CardID)
            bitID = CShort(m_DI(SnrIdx).BitID)
            rtn = DMC5480.d5480_read_inbit(cardID, bitID)
            If rtn = 0 Then
                pStatus = True
            Else
                pStatus = False
            End If
        Catch ex As Exception
            '  MsgBox("Unexpected Error" & ex.ToString, MsgBoxStyle.Critical, "CDMC5480DI->CheckSensorSts")
        Finally
        End Try
    End Sub
End Class
Friend Class CDMC5480DO
    Inherits CDMC5480DIO
    Private m_DO() As CDOBased
    Private m_Timer As CHighResolutionTimer
    Private Shared m_DoCtrl As Automation.BDaq.InstantDoCtrl
    Friend Sub New(ByRef pDO() As CDOBased)
        Try
            m_DO = pDO
            m_Timer = New CHighResolutionTimer
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Unexpected Error")
        Finally
        End Try
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
        Dim cardId As Short
        Dim bitId As Short
        Dim rtnCode As Integer = 0
        Dim outData As Short
        Dim errCode As Integer
        Select Case Status
            Case enumCyllogic.Normal
                cardId = m_DO(CylIdx).CardIDAction : bitId = m_DO(CylIdx).BitIDAction
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 1
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
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
                    outData = 0
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
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
                    outData = 1
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
                End If
                cardId = m_DO(CylIdx).CardIDNormal : bitId = m_DO(CylIdx).BitIDNormal
                If cardId <> -1 AndAlso bitId <> -1 Then
                    outData = 0
                    rtnCode = DMC5480.d5480_write_outbit(cardId, bitId, outData)
                    'If Not (rtnCode = ERR_No_Error) Then
                    'End If
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
