Imports PseudoDevice

Public Class CLaserRofinStartFiber
#Region "CONSTANT"

#End Region
#Region "Constructors && Destructors"
    Public Sub New(ByVal LaserONIdx As Integer, ByVal LaserPowerONIdx As Integer, ByRef pDA As PseudoDevice.CDAQ, Optional ByVal pCOM As String = "COM1", Optional ByRef LaserSerial As String = "None")
        Try
            Watts10V = 100
            Watts9V = 90
            Watts8V = 80
            Watts7V = 70
            Watts6V = 60
            Watts5V = 50
            m_LaserOnIdx = LaserONIdx
            m_LaserPowerOnIdx = LaserPowerONIdx
            m_DA = pDA
            m_SerialPortLaser = New System.IO.Ports.SerialPort
            m_ErrMessage = ""
            With m_SerialPortLaser
                .PortName = pCOM
                .BaudRate = 19200
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Parity = IO.Ports.Parity.None
                If m_SerialPortLaser.IsOpen Then
                    m_ErrMessage = "通訊埠已被其他程式占用!! 請關閉運行程式後再執行"
                Else
                    Call .Open()
                    .ReadTimeout = 100
                    Dim buffer(0 To 4) As Byte
                    Try
                        m_ErrMessage = ""
                        buffer(0) = Asc("E")
                        buffer(1) = Asc("S")
                        buffer(2) = Asc("?")
                        buffer(3) = &HD
                        buffer(4) = &HA
                        Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                        m_SerialPortLaser.Write(buffer, 0, 5)
                    Catch ex As Exception
                        m_ErrMessage = ex.Message.ToString()
                    Finally
                    End Try


                    'GatePulseMode = True
                    'PowerModulation = True
                    LaserGuide = False
                    m_ErrMessage = ""
                End If
            End With

            Call SeriaNumber(LaserSerial)
            If LaserSerial = "" Then
                LaserSerial = "None"
            End If
        Catch ex As Exception
        Finally
        End Try
    End Sub
#End Region
#Region "Member"
    Private m_LaserOnIdx As Integer
    Private m_LaserPowerOnIdx As Integer
    Private Const MCI_Protocol_Wait_Time As Int32 = 30
    Private m_SerialPortLaser As System.IO.Ports.SerialPort
    Private m_GatePulseMode As Boolean
    Private m_DA As PseudoDevice.CDAQ
    Private m_Frequency As Double
    Private m_Power As Double
    Private m_PulseWidth As Double
    Private m_WaveformIdx As Integer



#End Region
#Region "Property"
    Public Property Watts10V As Double
    Public Property Watts9V As Double
    Public Property Watts8V As Double
    Public Property Watts7V As Double
    Public Property Watts6V As Double
    Public Property Watts5V As Double

    Public WriteOnly Property WaveformIdx() As Integer
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
                If value Then
                    m_DA.DigO.CylGo(m_LaserPowerOnIdx, enumCyllogic.Action)
                Else
                    m_DA.DigO.CylGo(m_LaserPowerOnIdx, enumCyllogic.Normal)
                End If
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
    ''' <summary>
    ''' 雷射工作頻率Hz 1~200K
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property PRR() As String
        Set(ByVal value As String)
            Dim buffer(0 To 20) As Byte
            Dim i As Integer
            Try
                m_Frequency = CDbl(value)
                m_ErrMessage = ""
                If CInt(value) = 0 Then
                    If m_GatePulseMode Then GatePulseMode = False
                Else
                    If Not m_GatePulseMode Then GatePulseMode = True
                    buffer(0) = Asc("S")
                    buffer(1) = Asc("F")
                    For i = 1 To value.Length
                        buffer(1 + i) = CByte(Asc(Mid(value, i, 1)))
                    Next i
                    i = i - 1
                    buffer(2 + i) = &HD
                    buffer(3 + i) = &HA
                    Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                    'm_SerialPortLaser.Write(buffer, 0, 4 + i)
                End If

            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 2us~327.68us
    ''' </summary>
    ''' <value></value>
    ''' <remarks></remarks>
    Public WriteOnly Property PulseWidth() As String
        Set(ByVal value As String)
            Dim buffer(0 To 8) As Byte
            Dim i As Integer
            Try
                m_PulseWidth = CDbl(value)
                m_ErrMessage = ""
                buffer(0) = Asc("S")
                buffer(1) = Asc("W")
                value = ((CDbl(value) * 1000 - 5) / 5).ToString()
                For i = 1 To value.Length
                    buffer(1 + i) = CByte(Asc(Mid(value, i, 1)))
                Next
                i = i - 1
                buffer(2 + i) = &HD
                buffer(3 + i) = &HA
                Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                'm_SerialPortLaser.Write(buffer, 0, 4 + i)

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
            Dim i As Integer
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
                buffer(0) = Asc("P")
                buffer(1) = Asc("M")
                For i = 1 To value.Length
                    buffer(1 + i) = CByte(Asc(Mid(value, i, 1)))
                Next
                i = i - 1
                buffer(2 + i) = &HD
                buffer(3 + i) = &HA
                Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Write(buffer, 0, 4 + i)

            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property

    Private WriteOnly Property PowerModulation() As Boolean
        Set(ByVal value As Boolean)
            Try
                Dim buffer(0 To 5) As Byte
                If value Then
                    buffer(0) = Asc("P")
                    buffer(1) = Asc("O")
                    buffer(2) = Asc("M")
                    buffer(3) = Asc("3")
                Else
                    buffer(0) = Asc("P")
                    buffer(1) = Asc("O")
                    buffer(2) = Asc("M")
                    buffer(3) = Asc("2")
                End If
                buffer(4) = &HD
                buffer(5) = &HA
                Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                'm_SerialPortLaser.Write(buffer, 0, 6)

            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property

    Private WriteOnly Property GatePulseMode() As Boolean
        Set(ByVal value As Boolean)
            Try
                Dim buffer(0 To 5) As Byte
                If value Then
                    buffer(0) = Asc("L")
                    buffer(1) = Asc("O")
                    buffer(2) = Asc("M")
                    buffer(3) = Asc("1")
                    m_GatePulseMode = True
                Else
                    buffer(0) = Asc("L")
                    buffer(1) = Asc("O")
                    buffer(2) = Asc("M")
                    buffer(3) = Asc("0")
                    m_GatePulseMode = False
                End If
                buffer(4) = &HD
                buffer(5) = &HA
                Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                'm_SerialPortLaser.Write(buffer, 0, 6)
            Catch ex As Exception
                m_ErrMessage = ex.Message.ToString()
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' 雷射導引紅光開關
    ''' </summary>
    ''' <value>
    ''' </value>
    ''' <remarks>
    ''' </remarks>
    Public WriteOnly Property LaserGuide() As Boolean
        Set(ByVal value As Boolean)
            Dim buffer(0 To 4) As Byte
            Try
                If value Then
                    buffer(0) = Asc("P")
                    buffer(1) = Asc("L")
                    buffer(2) = Asc("1")
                Else
                    buffer(0) = Asc("P")
                    buffer(1) = Asc("L")
                    buffer(2) = Asc("0")
                End If
                buffer(3) = &HD
                buffer(4) = &HA
                Call Threading.Thread.Sleep(MCI_Protocol_Wait_Time)
                m_SerialPortLaser.Write(buffer, 0, 5)

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
            m_DA.AnalogOut.StopWaveform()
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

    Public Sub SeriaNumber(ByRef pStr As String)

        Try
            Dim ReceviceString As String
            Dim m_SerialNumber As String = "None"
            Call Threading.Thread.Sleep(200)
            ReceviceString = ""
            m_SerialPortLaser.ReadExisting()
            Dim buffer(0 To 5) As Byte
            buffer(0) = Asc("S")
            buffer(1) = Asc("N")
            buffer(2) = Asc("R")
            buffer(3) = Asc("?")
            buffer(4) = &HD
            buffer(5) = &HA
            m_SerialPortLaser.Write(buffer, 0, 5)
            Call Threading.Thread.Sleep(200)
            Dim num5 = m_SerialPortLaser.BytesToRead
            Call Threading.Thread.Sleep(200)
            For i = 0 To num5 - 1
                Dim num As Byte = CByte(m_SerialPortLaser.ReadByte())
                If (num = 10 Or num = 13) Then
                    ReceviceString &= " "
                Else
                    ReceviceString &= Convert.ToChar(num)
                End If
            Next
            Dim readStr As String = m_SerialPortLaser.ReadExisting()

            Dim idx As Integer = ReceviceString.ToLower().IndexOf("serialno.:")
            Dim edx As Integer = ReceviceString.ToLower().IndexOf(">")
            If (idx > -1 And edx > -1 And (edx - idx - 10) > 0) Then
                Dim tmp = ReceviceString.Substring(idx + 10, edx - idx - 10).Trim()
                If (tmp.Length = 9) Then
                    m_SerialNumber = tmp.Substring(0, 3) & "-" & tmp.Substring(3, 3) & "-" & tmp.Substring(6)
                Else
                    m_SerialNumber = tmp
                End If
            End If
            ReceviceString = ""
            pStr = m_SerialNumber
        Catch ex As Exception
            pStr = "None"
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
