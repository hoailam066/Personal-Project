'Imports Timer
'Public Class CLaser
'    'bit 9 = 0 Sw control Interface
'    'bit 8 = 1 Alignment Laser Enable
'    'bit 4 = 0  Sw control mode
'    'bit 3 = 0  Pulsed Mode
'    'bit 1 = 1 Laser enable
'    'bit 0 = 1 Laser Rdy
'    Private WithEvents m_SerialPortLaser As System.IO.Ports.SerialPort


'    Private m_Timer As CHighResolutionTimeStamps
'    Private m_CmdTime As Double

'    Public Sub Open()
'        Call m_SerialPortLaser.Open()
'    End Sub

'    Public Sub Close()
'        Call m_SerialPortLaser.Close()
'    End Sub
'    Public Sub New()
'        m_Timer = New CHighResolutionTimeStamps
'        m_SerialPortLaser = New System.IO.Ports.SerialPort
'        With m_SerialPortLaser
'            .PortName = "COM3"
'            .BaudRate = 115200
'            .DataBits = 8
'            .StopBits = IO.Ports.StopBits.One
'            .Parity = IO.Ports.Parity.None

'            .RtsEnable = False
'            .DtrEnable = False


'            If m_SerialPortLaser.IsOpen Then
'                Throw New Exception("通訊埠已被其他程式占用!! 請關閉運行程式後再執行")
'            Else
'                Call .Open()
'                m_CmdTime = m_Timer.GetMilliseconds
'                LaserEmissionOn = False
'                Try
'                    Dim s As String = ""
'                    'SS 6 fast rise-time mode
'                    's = m_SerialPortLaser.ReadExisting()
'                    's = "SS 6" & vbCrLf
'                    'm_SerialPortLaser.WriteLine(s)
'                    'm_SerialPortLaser.WriteLine(s)
'                    'm_SerialPortLaser.WriteLine(s)

'                    OperatingModes = ""

'                    'SL 0 contineous pulsing
'                    's = m_SerialPortLaser.ReadExisting()
'                    's = "SL 0" & vbCrLf
'                    'm_SerialPortLaser.WriteLine(s)
'                    'm_SerialPortLaser.WriteLine(s)
'                    'm_SerialPortLaser.WriteLine(s)
'                    'SI 200 set power-amplifier active-state current to 20%
'                    OperatingPower = 10
'                    'SR 20000 set pulse rate to 20K
'                    PRR = 20

'                    '   LaserEmissionOn = True

'                Catch ex As Exception
'                    Throw New Exception("Message: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace & vbCrLf & "Source: " & ex.Source & vbCrLf)
'                Finally
'                End Try
'            End If
'        End With
'    End Sub
'    Private m_OperatingModes As String
'    Public Property OperatingModes() As String
'        Get
'            Return ""
'        End Get
'        Set(ByVal value As String)
'            Try
'                'Do
'                'Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                'm_CmdTime = m_Timer.GetMilliseconds()
'                'Dim s As String = ""
'                ''SW 0  select waveform0
'                's = m_SerialPortLaser.ReadExisting()
'                's = "SW 0" & vbCrLf
'                'm_SerialPortLaser.WriteLine(s)
'                m_OperatingModes = "0"
'            Catch ex As Exception
'                Throw New Exception("Message: " & ex.Message & vbCrLf & "StackTrace: " & ex.StackTrace & vbCrLf & "Source: " & ex.Source & vbCrLf)
'            Finally
'            End Try
'        End Set
'    End Property
'    Private m_PRR As Double
'    ''' <summary>
'    ''' 雷射工作頻率KHz
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property PRR() As Double
'        Get
'            'Dim s As String = ""
'            's = m_SerialPortLaser.ReadExisting()
'            's = "GR" & vbCrLf
'            'm_SerialPortLaser.WriteLine(s)
'            'Do
'            '    s = m_SerialPortLaser.ReadExisting()
'            'Loop Until s <> ""
'            'Return (CInt(s) / 1000)
'            Return (CInt(m_PRR) / 1000)
'        End Get
'        Set(ByVal value As Double)
'            Try
'                'Dim s As String = ""
'                'Do
'                'Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                'm_CmdTime = m_Timer.GetMilliseconds()
'                's = m_SerialPortLaser.ReadExisting()
'                's = "SL 0" & vbCrLf
'                'm_SerialPortLaser.WriteLine(s)
'                'Do
'                'Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                'm_CmdTime = m_Timer.GetMilliseconds()
'                's = m_SerialPortLaser.ReadExisting()
'                's = "SR " & CInt(value * 1000).ToString() & vbCrLf
'                'm_SerialPortLaser.WriteLine(s)
'                m_PRR = CInt(value * 1000)
'            Catch ex As Exception

'            Finally
'            End Try
'        End Set
'    End Property

'    Private m_OperatingPower As Double
'    Public Property OperatingPower() As Double
'        Get
'            'Dim s As String = ""
'            's = m_SerialPortLaser.ReadExisting()
'            's = "GI" & vbCrLf
'            'm_SerialPortLaser.WriteLine(s)
'            'Do
'            '    s = m_SerialPortLaser.ReadExisting()
'            'Loop Until s <> ""
'            'Return (CDbl(s) / 10)
'            Return (m_OperatingPower / 10)
'        End Get
'        Set(ByVal value As Double)
'            Try
'                'Dim s As String = ""
'                'Do
'                'Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                'm_CmdTime = m_Timer.GetMilliseconds()
'                's = m_SerialPortLaser.ReadExisting()
'                's = "SI " & CInt(value * 10).ToString() & vbCrLf
'                'm_SerialPortLaser.WriteLine(s)

'                m_OperatingPower = CInt(value * 10)
'            Catch ex As Exception

'            Finally
'            End Try
'        End Set
'    End Property

'    Public WriteOnly Property LaserEmissionOn() As Boolean
'        Set(ByVal value As Boolean)
'            Try
'                Dim s As String = ""
'                If value Then
'                    Do
'                        s = "GS" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("0, 5, 6" & vbCr) OrElse s = ("5, 6" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop
'                    'm_CmdTime = m_Timer.GetMilliseconds()

'                    If s = ("0, 5, 6" & vbCr) Then
'                        Do
'                            'SC 0 put laser into stand-by state
'                            s = "SC 0" & vbCr
'                            m_SerialPortLaser.WriteLine(s)
'                            s = "GS" & vbCr
'                            m_SerialPortLaser.WriteLine(s)
'                            s = m_SerialPortLaser.ReadLine()
'                            If s = ("5, 6" & vbCr) Then
'                                Exit Do
'                            End If
'                        Loop
'                    End If

'                    Do
'                        'SW 0  select waveform0
'                        s = "SW " & m_OperatingModes & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GW" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("0" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop



'                    Do
'                        s = "SI " & m_OperatingPower.ToString() & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GI" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = (m_OperatingPower.ToString() & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop


'                    Do
'                        s = "SL 0" & vbCrLf
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GL" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("0" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop


'                    Do
'                        s = "SR " & m_PRR.ToString() & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GR" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = (m_PRR.ToString() & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop


'                    Do
'                        'SS 0 enable laser ready bit and go into ready state
'                        s = "SS 0" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GS" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("0, 5, 6" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop

'                    Do
'                        'SS 1 start task and go into active state
'                        s = "SS 1" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GS" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("0, 5, 6" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop
'                Else
'                    Do
'                        'SC 0 put laser into stand-by state
'                        s = "SC 0" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = "GS" & vbCr
'                        m_SerialPortLaser.WriteLine(s)
'                        s = m_SerialPortLaser.ReadLine()
'                        If s = ("5, 6" & vbCr) Then
'                            Exit Do
'                        End If
'                    Loop
'                End If
'            Catch ex As Exception
'            Finally
'            End Try
'        End Set
'    End Property

'    Public WriteOnly Property GuideLaserOn() As Boolean
'        Set(ByVal value As Boolean)
'            Try
'                Dim s As String = ""
'                If value Then
'                    Do
'                    Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                    m_CmdTime = m_Timer.GetMilliseconds()
'                    s = "SS 8" & vbCr
'                    m_SerialPortLaser.WriteLine(s)
'                Else
'                    Do
'                    Loop Until (m_Timer.GetMilliseconds() - m_CmdTime) >= 50
'                    m_CmdTime = m_Timer.GetMilliseconds()
'                    s = "SC 8" & vbCr
'                    m_SerialPortLaser.WriteLine(s)
'                End If
'            Catch ex As Exception
'            Finally
'            End Try
'        End Set
'    End Property
'End Class
