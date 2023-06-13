Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
#If (False) Then
Public Class CLaser
#Region "Const"
    Public Const STARTBYTE As String = "FF 00"
    Public Const ENDBYTE As String = "0D"
    Public Const TEMPERATURECOMMAND As String = "01 10 47 00 56"
    Public Const CHANGEDIODECOMMAND As String = "00 96 57 00 70"
    Public Const CHECKDIODECOMMAND As String = "00 99 47 00 70"
    Public Const CHANGEFREQUENCYCOMMAND As String = "00 97 57 00 81"
    Public Const CHECKFREQUENCYCOMMAND As String = "00 98 47 00 81"
    Public Const EXTERNALSETTINGCOMMAND As String = "00 9A 57 00 92"
    Public Const GETEXTERNALSETTINGCOMMAND As String = "00 A9 47 00 92"
#End Region
    Public Enum Status
        OFF = 0
        [ON] = 1
    End Enum
    Private WithEvents m_SerialPortLaser As System.IO.Ports.SerialPort

    Private m__AvgPwTable(0 To 100, 0 To 20) As Double

    Private m_LaserStaus As Status
    Private m_SetCurrent As Double
    Private m_Current As Double
    Private m_RepetitionRate As Integer
    Private m_Works As List(Of String)
    Private m_LastError As String
    Private m_Success As Boolean
    Private m_OperatingStatus As Byte
    Private m_StatusString As String

    Public Sub New()
        m_SerialPortLaser = New System.IO.Ports.SerialPort
        m_LastError = ""
        m_Success = False
        m_Works = New List(Of String)
        With m_SerialPortLaser
            .PortName = "COM3"
            .BaudRate = 9600
            .DataBits = 8
            .StopBits = IO.Ports.StopBits.One
            .Parity = IO.Ports.Parity.None
            If m_SerialPortLaser.IsOpen Then
                Throw New Exception("通訊埠已被其他程式占用!! 請關閉運行程式後再執行")
            Else
                Call .Open()
            End If
        End With
        AddHandler m_SerialPortLaser.DataReceived, New SerialDataReceivedEventHandler(AddressOf comPort_DataReceived)

    End Sub
    Private Sub comPort_DataReceived(ByVal sender As Object, ByVal e As SerialDataReceivedEventArgs)
        Try
            Dim work As String = m_Works(0)
            m_Works.RemoveAt(0)
            m_LastError = ""
            m_Success = False
            Dim bytes As Integer = m_SerialPortLaser.BytesToRead
            Dim comBuffer As Byte() = New Byte(bytes - 1) {}
            m_SerialPortLaser.Read(comBuffer, 0, bytes)
            Dim tmp = ConvertAsciiToString(comBuffer).Split(":"c)
            If (tmp.Length = 1) Then
                m_LastError = "Bad Command"
                Exit Sub
            End If
            Dim Result As String = tmp(0)
            Dim ErrorCode As String = tmp(1).Substring(0, tmp(1).Length - 1)

            If (ErrorCode <> "0") Then
                m_LastError = "Error Code: " & ErrorCode
                m_Success = False
                Exit Sub
            End If
            m_Success = True
            Select Case work
                Case "GetLaserStaus"
                    If (Result = "0") Then
                        m_LaserStaus = Status.OFF
                    ElseIf Result = "1" Then
                        m_LaserStaus = Status.ON
                    End If
                Case "SetLaserStaus"
                Case "GetOscillatorCurrent"
                    m_SetCurrent = Double.Parse(Result)
                Case "SetOscillatorCurrent"
                Case "GetRepetitionRate"
                    m_RepetitionRate = Double.Parse(Result)
                Case "SetRepetitionRate"
                Case "GetStaus"
                    m_OperatingStatus = Byte.Parse(Result)
                Case "GetCurrent"
                    m_Current = Double.Parse(Result)
                Case Else

            End Select
        Catch ex As Exception

        End Try

    End Sub
    Public Function ConvertAsciiToString(ByVal ascii As Byte()) As String
        Dim result As String = ""
        For index = 0 To ascii.Length - 1
            result &= Char.ConvertFromUtf32(CInt(ascii(index)))
        Next
        Return result
    End Function
    Public Property OperatingModes() As String
        Get
            Return ""
        End Get
        Set(ByVal value As String)
            Try
            Catch ex As Exception

            Finally
            End Try
        End Set
    End Property

    ''' <summary>
    ''' 雷射工作頻率KHz
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PRR() As Double
        Get
            Dim param As String = "?RR"
            Dim thread As New Thread(AddressOf WriteData)
            m_Works.Add("GetRepetitionRate")
            thread.Start(param)
            thread.Join()
            Threading.Thread.Sleep(500)
            Return m_RepetitionRate
        End Get
        Set(value As Double)

            'Dim param As String = "RR=" & (value * 1000)
            'Dim thread As New Thread(AddressOf WriteData)
            'm_Works.Add("SetRepetitionRate")
            'thread.Start(param)
            'thread.Join()
            'Threading.Thread.Sleep(500)
        End Set
    End Property
    ''' <summary>
    ''' %
    ''' </summary>
    ''' <returns></returns>
    Public Property OperatingPower() As Double
        Get
            Dim param As String = "?SCIP"
            Dim thread As New Thread(AddressOf WriteData)
            m_Works.Add("GetOscillatorCurrent")
            thread.Start(param)
            thread.Join()
            Threading.Thread.Sleep(500)
            Return m_SetCurrent
        End Get
        Set(value As Double)
            Dim param As String = "CIP=" & value
            Dim thread As New Thread(AddressOf WriteData)
            m_Works.Add("SetOscillatorCurrent")
            thread.Start(param)
            thread.Join()
            Threading.Thread.Sleep(500)
        End Set
    End Property

    Public WriteOnly Property LaserEmissionOn() As Boolean
        'Get
        '    Dim param As String = "?L"
        '    Dim thread As New Thread(AddressOf WriteData)
        '    m_Works.Add("GetLaserStaus")
        '    thread.Start(param)
        '    thread.Join()
        '    Threading.Thread.Sleep(1000)
        '    Return m_LaserStaus
        'End Get
        Set(value As Boolean)
            Dim param As String = "L="
            If (value = True) Then
                param &= "1"
            Else
                param &= "0"
            End If
            Dim thread As New Thread(AddressOf WriteData)
            m_Works.Add("SetLaserStaus")
            thread.Start(param)
            thread.Join()
            Threading.Thread.Sleep(500)
            param = "?L"
            thread = New Thread(AddressOf WriteData)
            m_Works.Add("GetLaserStaus")
            thread.Start(param)
            thread.Join()
            '    Threading.Thread.Sleep(1000)
        End Set
    End Property

    Public WriteOnly Property GuideLaserOn() As Boolean
        Set(ByVal value As Boolean)
            Try
            Catch ex As Exception

            Finally
            End Try
        End Set
    End Property



#Region "WriteData"
    Private Sub WriteData(ByVal cmd As String)
        Try
            Dim newMsg As Byte() = Encoding.ASCII.GetBytes(cmd)
            ReDim Preserve newMsg(newMsg.Length)
            newMsg(newMsg.Length - 1) = 13

            m_SerialPortLaser.Write(newMsg, 0, newMsg.Length)
        Catch ex As FormatException
            MessageBox.Show(ex.Message)
        Finally
        End Try
    End Sub

#End Region



End Class
#End If
