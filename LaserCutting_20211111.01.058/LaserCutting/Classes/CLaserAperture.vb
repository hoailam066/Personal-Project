Imports System.IO.Ports

Public Class CLaserAperture
    Private m_Processing As Boolean = False
    Private m_SerialPort As SerialPort
    Private m_PortName As String
    Private m_Baudrate As Integer
    Private m_DataBit As Integer
    Private m_StopBit As StopBits
    Private m_Parity As Parity
    Private m_Connected As Boolean
    Private m_LastError As String = ""
    Private m_CurrentValue As Double = 0
    Private m_Zero As Double = 0
    Private m_Height As Double = 0
    Private m_LastCmd As String = ""
    Public Sub New()
        Me.PortName = "COM7"
        Me.Baudrate = 115200
        Me.DataBit = 8
        Me.StopBit = StopBits.One
        Me.Parity = Parity.None
    End Sub
    Public Sub New(ByVal portName As String, ByVal baudrate As Integer, ByVal bitData As Integer, ByVal stopBit As StopBits, ByVal parity As Parity)
        Me.PortName = portName
        Me.Baudrate = baudrate
        Me.DataBit = bitData
        Me.StopBit = stopBit
        Me.Parity = parity
    End Sub

    Public ReadOnly Property SerialPort As SerialPort
        Get
            Return m_SerialPort
        End Get
    End Property

    Public Property PortName As String
        Get
            Return m_PortName
        End Get
        Set(ByVal value As String)
            m_PortName = value
        End Set
    End Property

    Public Property Baudrate As Integer
        Get
            Return m_Baudrate
        End Get
        Set(ByVal value As Integer)
            m_Baudrate = value
        End Set
    End Property

    Public Property DataBit As Integer
        Get
            Return m_DataBit
        End Get
        Set(ByVal value As Integer)
            m_DataBit = value
        End Set
    End Property

    Public Property StopBit As StopBits
        Get
            Return m_StopBit
        End Get
        Set(ByVal value As StopBits)
            m_StopBit = value
        End Set
    End Property

    Public Property [Parity] As Parity
        Get
            Return m_Parity
        End Get
        Set(ByVal value As Parity)
            m_Parity = value
        End Set
    End Property

    Public ReadOnly Property Connected As Boolean
        Get
            Try
                m_Connected = m_SerialPort.IsOpen
            Catch
                m_Connected = False
            End Try
            Return m_Connected
        End Get
    End Property

    Public ReadOnly Property LastError As String
        Get
            Return m_LastError
        End Get
    End Property

    Public ReadOnly Property CurrentValue As Double
        Get
            Return m_CurrentValue
        End Get
    End Property

    Public ReadOnly Property Height As Double
        Get
            If (m_Processing = False) Then
                GetHeight()
            End If
            Return m_Height
        End Get
    End Property

    Public ReadOnly Property Zero As Double
        Get
            Return m_Zero
        End Get
    End Property

    Public Sub GetHeight()
        Try
            m_Processing = True
            Write("%01#RMD**" & vbCr)
        Catch ex As Exception

        End Try
    End Sub
    Public Sub GetHeight(ByVal No As Integer)
        Try
            m_Processing = True
            Write("%" & No.ToString("00") & "#RMD**" & vbCr)
        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' Use current value set zero
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub SetZero()
        m_Zero = m_CurrentValue
        m_Height = m_CurrentValue - m_Zero
    End Sub

    ''' <summary>
    ''' Use user value set zero
    ''' </summary>
    ''' <param name="value">The value is set to be zero</param>
    ''' <remarks></remarks>
    Public Sub SetZero(ByVal value As Double)
        m_Zero = value
        m_Height = m_CurrentValue - m_Zero
    End Sub

    ''' <summary>
    ''' Use value in file set zero
    ''' </summary>
    ''' <param name="path"></param>
    ''' <remarks></remarks>
    Public Sub SetZero(ByVal path As String)
        m_LastError = ""
        Try
            If (System.IO.File.Exists(path)) Then
                Dim str As String = System.IO.File.ReadAllText(path)
                Dim tmp As Double = 0
                If (Double.TryParse(str, tmp)) Then
                    m_Zero = tmp
                    m_Height = m_CurrentValue - m_Zero
                Else
                    m_LastError = "Cannot convert value in file: " & path
                End If
            Else
                m_LastError = "File not found."
            End If
        Catch ex As Exception
            m_LastError = ex.Message
        End Try
    End Sub
    Public Sub SaveZero(ByVal path As String)
        m_LastError = ""
        Try
            System.IO.File.WriteAllText(path, m_Zero.ToString())
        Catch ex As Exception
            m_LastError = ex.Message
        End Try
    End Sub
    Public Sub Open()
        m_SerialPort = New SerialPort(m_PortName, m_Baudrate, Parity, m_DataBit, m_StopBit)
        m_SerialPort.ReadBufferSize = 1024
        m_SerialPort.WriteBufferSize = 1024
        m_SerialPort.WriteTimeout = 300
        m_SerialPort.ReadTimeout = 300
        m_Connected = False
        m_LastError = ""
        Try
            m_SerialPort.Open()
            Delay(100)
            If (m_SerialPort.IsOpen) Then
                m_Connected = True
                AddHandler m_SerialPort.DataReceived, AddressOf SerialPort_DataReceived
            Else
                m_Connected = False
                m_LastError = "An error while try open this comport"
            End If
        Catch ex As Exception
            m_LastError = ex.Message
            m_Connected = False
        End Try
    End Sub

    ''' <summary>
    ''' Turn on or off laser aperture
    ''' </summary>
    ''' <value>True: Turn On, False: Turn Off</value>
    ''' <remarks></remarks>
    Public WriteOnly Property LaserOnOff As Boolean
        Set(ByVal value As Boolean)
            If (value) Then
                Write("%01#WLR+00001**" & vbCr)
            Else
                Write("%01#WLR+00000**" & vbCr)
            End If
        End Set
    End Property

    Public Sub Close()
        Try
            LaserOnOff = False
            Delay(100)
            m_LastError = ""
            m_SerialPort.Close()
            Delay(100)
            If (m_SerialPort.IsOpen = False) Then
                m_Connected = False
            Else
                m_Connected = True
                m_LastError = "An error while try close this comport"
            End If
        Catch ex As Exception
            m_Connected = True
            m_LastError = ex.Message
        Finally
            m_SerialPort.Dispose()
        End Try
    End Sub

    Public Sub Write(ByVal value As String)
        Try
            m_LastError = ""
            If (m_SerialPort.IsOpen) Then
                m_SerialPort.WriteLine(value)
            Else
                Me.Open()
                If (m_SerialPort.IsOpen) Then
                    m_SerialPort.WriteLine(value)
                End If
            End If
            m_LastCmd = value
        Catch ex As Exception
            m_LastError = ex.Message
            m_LastCmd = ""
        End Try
    End Sub

    Protected Sub Delay(ByVal ms As Integer)
        Dim start As DateTime = DateTime.Now
        While ((DateTime.Now - start).TotalMilliseconds < ms)
            Application.DoEvents()
        End While
    End Sub

    Private m_ReceivedString As String = ""
    Private m_OK As Boolean = False
    Protected Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            m_Processing = True
            m_OK = False
            Delay(50)
            m_ReceivedString &= m_SerialPort.ReadExisting()

            Dim x As Integer = m_ReceivedString.IndexOf("-")
            Dim y As Integer = m_ReceivedString.IndexOf("+")
            Dim idx As Integer
            If (x >= 0 AndAlso y >= 0) Then
                If (x < y) Then
                    idx = x
                Else
                    idx = y
                End If
            ElseIf (x >= 0) Then
                idx = x
            ElseIf (y >= 0) Then
                idx = y
            Else
                idx = -1
            End If
            Dim idx2 As Integer = m_ReceivedString.IndexOf("**")
            If (idx >= 0) Then
                While idx2 < m_ReceivedString.Length
                    Application.DoEvents()
                    If (idx2 - idx = 7 OrElse idx2 - idx = 8) Then
                        Dim h As String = m_ReceivedString.Substring(idx, idx2 - idx)
                        Dim val As Double
                        If (Double.TryParse(h, val)) Then
                            If (val = 9999999 OrElse val = -9999999) Then
                                Me.LaserOnOff = True
                                m_ReceivedString = ""
                                m_Processing = False
                                Exit Sub
                            End If
                            m_CurrentValue = val / 10000.0
                            m_Height = m_CurrentValue - m_Zero
                            m_OK = True
                        End If

                        m_LastCmd = ""
                        m_ReceivedString = ""
                        Exit While
                    Else
                        x = m_ReceivedString.IndexOf("-", idx2)
                        y = m_ReceivedString.IndexOf("+", idx2)
                        If (x >= 0 AndAlso y >= 0) Then
                            If (x < y) Then
                                idx = x
                            Else
                                idx = y
                            End If
                        ElseIf (x >= 0) Then
                            idx = x
                        ElseIf (y >= 0) Then
                            idx = y
                        Else
                            idx = -1
                        End If
                        idx2 = m_ReceivedString.IndexOf("**", idx2 + 2)
                        If (idx2 = -1) Then
                            Exit While
                        End If
                    End If
                End While
            End If
        Catch
        End Try
        m_Processing = False
    End Sub
    Public Sub Dispose()
        Try
            If (m_SerialPort IsNot Nothing AndAlso m_SerialPort.IsOpen = True) Then
                Me.Close()
                Delay(100)
                m_SerialPort.Dispose()
            End If
        Catch
        End Try
    End Sub
End Class