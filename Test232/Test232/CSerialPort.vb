Imports System.IO.Ports

Public Class CSerialport
    Private m_SerialPort As SerialPort
    Private m_PortName As String
    Private m_Baudrate As Integer
    Private m_DataBit As Integer
    Private m_StopBit As StopBits
    Private m_Parity As Parity
    Private m_Connected As Boolean
    Private m_LastError As String
    Public Event DataReceived(ByVal value1 As Double, ByVal value2 As Double)
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

    Public Sub Open()
        m_SerialPort = New SerialPort(m_PortName, m_Baudrate, Parity, m_DataBit, m_StopBit)
        m_Connected = False
        m_LastError = ""
        Try
            m_SerialPort.Open()
            Delay(100)
            If (m_SerialPort.IsOpen) Then
                m_SerialPort.WriteTimeout = 300
                m_SerialPort.ReadTimeout = 300
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

    Public Sub Close()
        Try
            m_SerialPort.Close()
            Delay(100)
            If (m_SerialPort.IsOpen) Then
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
            End If
        Catch ex As Exception
            m_LastError = ex.Message
        End Try
    End Sub

    Private Sub Delay(ByVal ms As Integer)
        Dim s As DateTime = DateTime.Now
        While (DateTime.Now - s).TotalMilliseconds < ms
            Application.DoEvents()
        End While
    End Sub

    Public Sub Dispose()
        Try
            If (m_SerialPort.IsOpen) Then
                m_SerialPort.Close()
            End If
            m_SerialPort.Dispose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub SerialPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Delay(200)
            Dim size As Integer = m_SerialPort.BytesToRead
            Dim buffer(size - 1) As Byte
            m_SerialPort.Read(buffer, 0, size)
            Dim text As String = System.Text.Encoding.ASCII.GetString(buffer).Replace(vbCr, "$")

            Dim values() = text.Split("$")

            If (values.Length = 0) Then
                Exit Sub
            Else

                For i = values.Length - 1 To 0 Step -1
                    If (values(i).Length >= 9) Then
                        Dim v1 As String = values(i).Substring(0, values(i).Length - 5)
                        Dim v2 As String = values(i).Substring(values(i).Length - 5)

                        Dim value1 As Double = CDbl(v1) / 1000
                        Dim value2 As Double = CDbl(v2) / 1000
                        RaiseEvent DataReceived(value1, value2)

                    End If
                Next

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
