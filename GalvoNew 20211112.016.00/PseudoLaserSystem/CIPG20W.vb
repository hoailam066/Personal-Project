'Public Class CLaser
'    Private WithEvents m_SerialPortLaser As System.IO.Ports.SerialPort
'    Public Sub Open()
'        Call m_SerialPortLaser.Open()
'    End Sub
'    Public Sub Close()
'        Call m_SerialPortLaser.Close()
'    End Sub
'    Public Sub New()
'        m_SerialPortLaser = New System.IO.Ports.SerialPort
'        With m_SerialPortLaser
'            .PortName = "COM3"
'            .BaudRate = 57600
'            .DataBits = 8
'            .StopBits = IO.Ports.StopBits.One
'            .Parity = IO.Ports.Parity.None
'            If m_SerialPortLaser.IsOpen Then
'                Throw New Exception("通訊埠已被其他程式占用!! 請關閉運行程式後再執行")
'            Else
'                Call .Open()


'                'OperatingModes = "1202"
'                'Dim a As String = OperatingModes()

'                'PRR = "20.0"
'                'a = PRR()
'                'OperatingPower = "20.0"
'                'a = OperatingPower()
'            End If
'        End With
'    End Sub

'    Public Property OperatingModes() As String
'        Get
'            Dim buffer(0 To 4) As Byte
'            Dim s As String = ""
'            Dim ss() As String
'            buffer(0) = Asc("$")
'            buffer(1) = Asc("2")
'            buffer(2) = Asc("3")
'            buffer(3) = Asc(";")
'            buffer(4) = &HD
'            s = m_SerialPortLaser.ReadExisting()
'            s = System.Text.Encoding.UTF8.GetString(buffer)
'            m_SerialPortLaser.WriteLine(s)
'            Do
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                s = m_SerialPortLaser.ReadExisting()
'            Loop Until s <> ""
'            ss = Split(s, "23;")
'            Return ""
'        End Get
'        Set(ByVal value As String)
'            Try
'                Dim buffer() As Byte
'                Dim s As String = ""
'                Dim ss() As String
'                Dim i As Integer
'                ReDim buffer(0 To 19)
'                buffer(0) = Asc("$")
'                buffer(1) = Asc("4")
'                buffer(2) = Asc("9")
'                buffer(3) = Asc(";")
'                For i = 1 To value.Length
'                    buffer(3 + i) = CByte(Asc(Mid(value, i, 1)))
'                Next
'                buffer(3 + i) = &HD
'                'm_SerialPortLaser.Write(buffer, 0, 4 + i)
'                ReDim Preserve buffer(0 To (3 + i))
'                s = m_SerialPortLaser.ReadExisting()
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                'Do
'                '    s = m_SerialPortLaser.ReadExisting()
'                'Loop Until s <> ""
'                ss = Split(s, "49;")
'            Catch ex As Exception

'            Finally
'            End Try
'        End Set
'    End Property

'    ''' <summary>
'    ''' 雷射工作頻率KHz
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public Property PRR() As Double
'        Get
'            Dim buffer(0 To 4) As Byte
'            Dim s As String = ""
'            Dim ss() As String
'            buffer(0) = Asc("$")
'            buffer(1) = Asc("2")
'            buffer(2) = Asc("9")
'            buffer(3) = Asc(";")
'            buffer(4) = &HD
'            s = m_SerialPortLaser.ReadExisting()
'            s = System.Text.Encoding.UTF8.GetString(buffer)
'            m_SerialPortLaser.WriteLine(s)
'            'Do
'            '    s = m_SerialPortLaser.ReadExisting()
'            'Loop Until s <> ""
'            ss = Split(s, "29;")
'            Return CSng(ss(1))
'        End Get
'        Set(ByVal value As Double)
'            Try
'                Dim buffer() As Byte
'                Dim s As String = ""
'                Dim ss() As String
'                Dim i As Integer
'                ReDim buffer(0 To 19)
'                buffer(0) = Asc("$")
'                buffer(1) = Asc("2")
'                buffer(2) = Asc("8")
'                buffer(3) = Asc(";")
'                For i = 1 To value.ToString().Length
'                    buffer(3 + i) = CByte(Asc(Mid(value.ToString(), i, 1)))
'                Next
'                buffer(3 + i) = &HD
'                'm_SerialPortLaser.Write(buffer, 0, 4 + i)
'                ReDim Preserve buffer(0 To (3 + i))
'                s = m_SerialPortLaser.ReadExisting()
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                'Do
'                '    s = m_SerialPortLaser.ReadExisting()
'                'Loop Until s <> ""
'                ss = Split(s, "28;")
'            Catch ex As Exception
'            Finally
'            End Try
'        End Set
'    End Property
'    Public Property OperatingPower() As Double
'        Get
'            Dim buffer(0 To 4) As Byte
'            Dim s As String = ""
'            Dim ss() As String
'            buffer(0) = Asc("$")
'            buffer(1) = Asc("3")
'            buffer(2) = Asc("4")
'            buffer(3) = Asc(";")
'            buffer(4) = &HD
'            s = m_SerialPortLaser.ReadExisting()
'            s = System.Text.Encoding.UTF8.GetString(buffer)
'            m_SerialPortLaser.WriteLine(s)
'            'Do
'            '    s = m_SerialPortLaser.ReadExisting()
'            'Loop Until s <> ""
'            ss = Split(s, "34;")
'            Return CSng(ss(1))
'        End Get
'        Set(ByVal value As Double)
'            Try
'                Dim buffer() As Byte
'                Dim s As String = ""
'                Dim ss() As String
'                Dim i As Integer
'                ReDim buffer(0 To 19)
'                buffer(0) = Asc("$")
'                buffer(1) = Asc("3")
'                buffer(2) = Asc("2")
'                buffer(3) = Asc(";")
'                For i = 1 To value.ToString().Length
'                    buffer(3 + i) = CByte(Asc(Mid(value.ToString(), i, 1)))
'                Next
'                buffer(3 + i) = &HD
'                'm_SerialPortLaser.Write(buffer, 0, 4 + i)
'                ReDim Preserve buffer(0 To (3 + i))
'                s = m_SerialPortLaser.ReadExisting()
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                'Do
'                '    s = m_SerialPortLaser.ReadExisting()
'                'Loop Until s <> ""
'                ss = Split(s, "32;")
'            Catch ex As Exception
'            Finally
'            End Try
'        End Set
'    End Property

'    Public WriteOnly Property LaserEmissionOn() As Boolean
'        Set(ByVal value As Boolean)
'            Try
'                Dim buffer() As Byte
'                Dim s As String = ""
'                Dim ss() As String
'                Dim i As Integer
'                ReDim buffer(0 To 4)
'                If value Then
'                    buffer(0) = Asc("$")
'                    buffer(1) = Asc("3")
'                    buffer(2) = Asc("0")
'                    buffer(3) = Asc(";")
'                Else
'                    buffer(0) = Asc("$")
'                    buffer(1) = Asc("3")
'                    buffer(2) = Asc("1")
'                    buffer(3) = Asc(";")
'                End If
'                buffer(4) = &HD
'                s = m_SerialPortLaser.ReadExisting()
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                'Do
'                '    s = m_SerialPortLaser.ReadExisting()
'                'Loop Until s <> ""
'                ss = Split(s, "32;")
'            Catch ex As Exception

'            Finally
'            End Try
'        End Set
'    End Property

'    Public WriteOnly Property GuideLaserOn() As Boolean
'        Set(ByVal value As Boolean)
'            Try
'                Dim buffer() As Byte
'                Dim s As String = ""
'                Dim ss() As String
'                Dim i As Integer
'                ReDim buffer(0 To 4)
'                If value Then
'                    buffer(0) = Asc("$")
'                    buffer(1) = Asc("4")
'                    buffer(2) = Asc("0")
'                    buffer(3) = Asc(";")
'                Else
'                    buffer(0) = Asc("$")
'                    buffer(1) = Asc("4")
'                    buffer(2) = Asc("1")
'                    buffer(3) = Asc(";")
'                End If
'                buffer(4) = &HD
'                s = m_SerialPortLaser.ReadExisting()
'                s = System.Text.Encoding.UTF8.GetString(buffer)
'                m_SerialPortLaser.WriteLine(s)
'                'Do
'                '    s = m_SerialPortLaser.ReadExisting()
'                'Loop Until s <> ""
'                ss = Split(s, "32;")
'            Catch ex As Exception

'            Finally
'            End Try
'        End Set
'    End Property
'End Class
