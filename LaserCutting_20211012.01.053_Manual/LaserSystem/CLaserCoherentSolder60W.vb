Imports PseudoDevice

Public Class CLaserCoherentSolder60W
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Public Sub New(ByVal pLaserPowerOn As Integer, ByVal pLaserEnable As Integer, ByVal pLaserReset As Integer, ByRef pDA As PseudoDevice.CDAQ, Optional ByVal pCOM As String = "COM1", Optional ByRef LaserSerial As String = "None")
        Try
            Watts10V = 100
            Watts9V = 90
            Watts8V = 80
            Watts7V = 70
            Watts6V = 60
            Watts5V = 50
            m_LaserPowerOnIdx = pLaserPowerOn
            m_LaserEnable = pLaserEnable
            m_LaserReset = pLaserReset
            m_DA = pDA
            m_ErrMessage = ""
        Catch ex As Exception
        Finally
        End Try
    End Sub
#End Region
#Region "Member"
    Private m_LaserPowerOnIdx As Integer
    Private m_LaserEnable As Integer
    Private m_LaserReset As Integer

    Private Const MCI_Protocol_Wait_Time As Int32 = 30
    Private m_GatePulseMode As Boolean
    Private m_DA As PseudoDevice.CDAQ
    Private m_Frequency As Double
    Private m_Power As Double = 1
    Private m_PulseCnt As Integer = 9
    Private m_WaveformIdx As Integer
    Private m_LaserEmission As Boolean


#End Region
#Region "Property"
    Public Property Watts10V As Double
    Public Property Watts9V As Double
    Public Property Watts8V As Double
    Public Property Watts7V As Double
    Public Property Watts6V As Double
    Public Property Watts5V As Double

    Public Property WaveformIdx() As Integer
        Get
            Return m_WaveformIdx
        End Get
        Set(ByVal value As Integer)
            m_WaveformIdx = value
        End Set
    End Property

    ''' <summary>
    ''' 雷射啟用(進啟用雷射尚未實際打出雷射)
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property LaserEmission() As Boolean
        Set(ByVal value As Boolean)
            Try
                If m_LaserEmission <> value Then
                    If value Then
                        m_DA.DigO.CylGo(m_LaserPowerOnIdx, enumCyllogic.Action)
                        System.Threading.Thread.Sleep(50)
                        m_DA.DigO.CylGo(m_LaserEnable, enumCyllogic.Action)
                    Else
                        m_DA.DigO.CylGo(m_LaserEnable, enumCyllogic.Normal)
                        System.Threading.Thread.Sleep(50)
                        m_DA.DigO.CylGo(m_LaserPowerOnIdx, enumCyllogic.Normal)
                    End If
                End If
                m_LaserEmission = value
            Catch ex As Exception
            Finally
            End Try
        End Set
    End Property
    Private Shared m_ErrMessage As String
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property
    Public Property PulseCnt() As Integer
        Get
            Return m_PulseCnt
        End Get
        Set(value As Integer)
            m_PulseCnt = value
        End Set
    End Property

    ''' <summary>
    ''' 雷射工作頻率Hz 1~200K
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public Property PRR() As String
        Get
            Return CStr(m_Frequency)
        End Get
        Set(ByVal value As String)
            Dim buffer(0 To 20) As Byte
            Try
                m_Frequency = CDbl(value)
                m_ErrMessage = ""

            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 雷射工作功率 千分之幾
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property OperatingPower(Optional ByVal pTransPowerFlag As Boolean = False) As String
        Set(ByVal value As String)
            Dim buffer(0 To 7) As Byte
            Dim i As Integer = 0
            Try
                Dim TransPower As Double = TransNewWatts(CDbl(value))
                If pTransPowerFlag = True Then
                    If TransPower = 0 Or TransPower < 0 Then
                        TransPower = CDbl(value)
                    End If
                Else
                    TransPower = CDbl(value)
                End If
                m_Power = TransPower / 1000       'm_Power = CDbl(value) / 1000
                m_ErrMessage = ""
              
            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property

#End Region
#Region "Methods"
    Public Sub LaserSignalON(Optional ByVal OpticalUsed As Boolean = False)
        Try
            'm_DA.AnalogOut.StopWaveform()
            m_DA.AnalogOut.StartWaveform(0)
            'If OpticalUsed Then
            '    Threading.Thread.Sleep(1)
            '    'm_DA.DigO.CylGo(7, enumCyllogic.Normal)
            '    Threading.Thread.Sleep(50)
            '    m_DA.DigO.CylGo(m_LaserOnIdx, enumCyllogic.Action)
            'End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Public Sub LaserSignalOFF()
        Try
            ' m_DA.DigO.CylGo(7, enumCyllogic.Normal)
            'm_DA.DigO.CylGo(m_LaserOnIdx, enumCyllogic.Normal)
            'Threading.Thread.Sleep(3)
            m_DA.AnalogOut.StopWaveform()
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Public Sub LaserSignalReset(Optional ByVal OpticalUsed As Boolean = False)
        Try
            m_DA.DigO.CylGo(m_LaserReset, enumCyllogic.Action)
        Catch ex As Exception
        Finally
        End Try
    End Sub
    

#End Region

    Private Function TransNewWatts(ByVal OldWatts As Double) As Double
        Try
            TransNewWatts = 0
            Dim i As Integer = 0
            Dim w10V As Double = Watts10V
            Dim w9V As Double = Watts9V
            Dim w8V As Double = Watts8V
            Dim w7V As Double = Watts7V
            Dim w6V As Double = Watts6V
            Dim w5V As Double = Watts5V
            Dim wLow As Double = 40

            Dim wNow As Double = OldWatts

            Dim wNewWatts As Double = 0
            Dim wMax As Double = 1000



            If wNow >= 1000 Then
                wNewWatts = w10V
            ElseIf wNow >= 900 And wNow < 1000 Then
                wNewWatts = w10V - (1000 - wNow) * ((w10V - w9V) / 100)
            ElseIf wNow >= 800 And wNow < 900 Then
                wNewWatts = w9V - (900 - wNow) * ((w9V - w8V) / 100)
            ElseIf wNow >= 700 And wNow < 800 Then
                wNewWatts = w8V - (800 - wNow) * ((w8V - w7V) / 100)
            ElseIf wNow >= 600 And wNow < 700 Then
                wNewWatts = w7V - (700 - wNow) * ((w7V - w6V) / 100)
            ElseIf wNow >= 500 And wNow < 600 Then
                wNewWatts = w6V - (600 - wNow) * ((w6V - w5V) / 100)
            Else
                wNewWatts = 0
            End If

            If wNewWatts > wMax Then
                wNewWatts = wMax
            ElseIf wNewWatts < 0 Then
                wNewWatts = 0
            End If

            TransNewWatts = wNewWatts
        Catch ex As Exception
            TransNewWatts = 0
        End Try
    End Function
End Class
