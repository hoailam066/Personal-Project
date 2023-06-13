Imports System
Imports System.Text
Imports System.Drawing
Imports System.IO.Ports
Imports System.Windows.Forms
Imports System.IO
#If (True) Then
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

    Private WithEvents m_SerialPortLaser As System.IO.Ports.SerialPort
    ''' <summary>
    ''' 電流比例,頻率
    ''' </summary>
    Private m__AvgPwTable(0 To 100, 0 To 20) As Double
    Public Sub New()
        m_SerialPortLaser = New System.IO.Ports.SerialPort
        With m_SerialPortLaser
            .PortName = "COM3"
            .BaudRate = 19200
            .DataBits = 8
            .StopBits = IO.Ports.StopBits.One
            .Parity = IO.Ports.Parity.None
            If m_SerialPortLaser.IsOpen Then
                Call .Close()
                Throw New Exception("通訊埠已被其他程式占用!! 請關閉運行程式後再執行")
            End If
            Call .Open()
            '  Call ReadFromFile()
        End With
        ' 設計工具需要此呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入所有初始設定。

    End Sub
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
            Dim freq As Double
            Dim str As String
            Dim cmd As String

            str = STARTBYTE & " " & ComputeLengthCommand(CHECKFREQUENCYCOMMAND) & " " & CHECKFREQUENCYCOMMAND
            cmd = str & " " & ComputeCheckSum(str) & " " & ENDBYTE
            Call WriteData(Command)


            Dim bytes As Integer = m_SerialPortLaser.BytesToRead
            Dim comBuffer As Byte() = New Byte(bytes - 1) {}
            m_SerialPortLaser.Read(comBuffer, 0, bytes)
            Dim result As String = ByteToHex(comBuffer)
            If (result.Replace(" "c, "").Length > 30 Or result.Replace(" "c, "").Length < 20) Then
            Else
                Dim arr As String() = result.Trim().Split(" "c)
                Dim IdMessage As String = arr(3) + arr(4)
                Dim msg As String = ""
                If IdMessage = "0098" Then
                    freq = 0.1 * HexToDec(arr(8) + arr(9))
                End If
            End If
            Return freq 'KHz
        End Get
        Set(ByVal value As Double)
            Dim freq As String
            Dim str As String
            Dim cmd As String
            Try
                freq = (CInt(value * 10)).ToString("X4")
                freq = freq.Substring(0, 2) & " " & freq.Substring(2, 2)
                str = STARTBYTE & " " & ComputeLengthCommand(CHANGEFREQUENCYCOMMAND & " " & freq) & " " & CHANGEFREQUENCYCOMMAND & " " & freq
                cmd = str & " " & ComputeCheckSum(str) & " " & ENDBYTE
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)

            Catch ex As Exception
            Finally
            End Try
        End Set
    End Property
    ''' <summary>
    ''' %
    ''' </summary>
    ''' <returns></returns>
    Public Property OperatingPower() As Double
        Get
            Dim current As Double
            Dim str As String
            Dim cmd As String


            str = STARTBYTE & " " & ComputeLengthCommand(CHECKDIODECOMMAND) & " " & CHECKDIODECOMMAND
            cmd = str & " " & ComputeCheckSum(str) & " " & ENDBYTE
            Call WriteData(cmd)

            Dim bytes As Integer = m_SerialPortLaser.BytesToRead
            Dim comBuffer As Byte() = New Byte(bytes - 1) {}
            m_SerialPortLaser.Read(comBuffer, 0, bytes)
            Dim result As String = ByteToHex(comBuffer)
            If (result.Replace(" "c, "").Length > 30 Or result.Replace(" "c, "").Length < 20) Then
            Else
                Dim arr As String() = result.Trim().Split(" "c)
                Dim IdMessage As String = arr(3) + arr(4)
                Dim msg As String = ""
                If IdMessage = "0099" Then
                    current = 0.01 * HexToDec(arr(8) + arr(9))
                End If
            End If
            Return current '%
        End Get
        Set(ByVal value As Double)
            Dim current As String
            Dim str As String
            Dim cmd As String
            Try
                current = (CInt(value * 100)).ToString("X4")
                current = current.Substring(0, 2) & " " & current.Substring(2, 2)
                str = STARTBYTE & " " & ComputeLengthCommand(CHANGEDIODECOMMAND & " " & current) & " " & CHANGEDIODECOMMAND & " " & current & " "
                cmd = str & ComputeCheckSum(str) & " " & ENDBYTE
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)
                Call WriteData(cmd)

            Catch ex As Exception
            Finally
            End Try
        End Set
    End Property

    Public WriteOnly Property LaserEmissionOn() As Boolean
        Set(ByVal value As Boolean)
            Try
            Catch ex As Exception

            Finally
            End Try
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


    Private Sub CInnolas5324Y50_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call ReadFromFile()

        txt44_1.Text = m__AvgPwTable(44, 1)
        txt48_1.Text = m__AvgPwTable(48, 1)
        txt52_1.Text = m__AvgPwTable(52, 1)
        txt56_1.Text = m__AvgPwTable(56, 1)
        txt60_1.Text = m__AvgPwTable(60, 1)

        txt44_2.Text = m__AvgPwTable(44, 2)
        txt48_2.Text = m__AvgPwTable(48, 2)
        txt52_2.Text = m__AvgPwTable(52, 2)
        txt56_2.Text = m__AvgPwTable(56, 2)
        txt60_2.Text = m__AvgPwTable(60, 2)

        txt44_5.Text = m__AvgPwTable(44, 5)
        txt48_5.Text = m__AvgPwTable(48, 5)
        txt52_5.Text = m__AvgPwTable(52, 5)
        txt56_5.Text = m__AvgPwTable(56, 5)
        txt60_5.Text = m__AvgPwTable(60, 5)
        txt64_5.Text = m__AvgPwTable(64, 5)
        txt68_5.Text = m__AvgPwTable(68, 5)
        txt72_5.Text = m__AvgPwTable(72, 5)
        txt76_5.Text = m__AvgPwTable(76, 5)

        txt44_10.Text = m__AvgPwTable(44, 10)
        txt48_10.Text = m__AvgPwTable(48, 10)
        txt52_10.Text = m__AvgPwTable(52, 10)
        txt56_10.Text = m__AvgPwTable(56, 10)
        txt60_10.Text = m__AvgPwTable(60, 10)
        txt64_10.Text = m__AvgPwTable(64, 10)
        txt68_10.Text = m__AvgPwTable(68, 10)
        txt72_10.Text = m__AvgPwTable(72, 10)
        txt76_10.Text = m__AvgPwTable(76, 10)

        txt44_20.Text = m__AvgPwTable(44, 20)
        txt48_20.Text = m__AvgPwTable(48, 20)
        txt52_20.Text = m__AvgPwTable(52, 20)
        txt56_20.Text = m__AvgPwTable(56, 20)
        txt60_20.Text = m__AvgPwTable(60, 20)
        txt64_20.Text = m__AvgPwTable(64, 20)
        txt68_20.Text = m__AvgPwTable(68, 20)
        txt72_20.Text = m__AvgPwTable(72, 20)
        txt76_20.Text = m__AvgPwTable(76, 20)
    End Sub

#Region "WriteData"
    Private Sub WriteData(ByVal Msg As String)
        Dim newMsg As Byte()
        Try
            'convert the message to byte array
            newMsg = HexToByte(Msg)
            'send the message to the port
            m_SerialPortLaser.Write(newMsg, 0, newMsg.Length)
        Catch ex As FormatException
            Throw New Exception("Src : " & ex.Source & vbCrLf & "Msg : " & ex.Message())
        Finally
        End Try

    End Sub
#End Region


#Region "HexToByte"
    ''' <summary>
    ''' method to convert hex string into a byte array
    ''' </summary>
    ''' <param name="msg">string to convert</param>
    ''' <returns>a byte array</returns>
    ''' <remarks></remarks>
    Private Function HexToByte(ByVal Msg As String) As Byte()
        'remove any spaces from the string
        Msg = Msg.Replace(" ", "")
        'create a byte array the length of the
        'divided by 2 (Hex is 2 characters in length)
        Dim comBuffer As Byte() = New Byte(Msg.Length / 2 - 1) {}
        'loop through the length of the provided string
        For i As Integer = 0 To Msg.Length - 1 Step 2
            'convert each set of 2 characters to a byte
            '  and add to the array
            comBuffer(i / 2) = CByte(Convert.ToByte(Msg.Substring(i, 2), 16))
        Next
        'return the array
        Return comBuffer
    End Function
#End Region

#Region "ByteToHex"
    ''' <summary>
    ''' method to convert a byte array into a hex string
    ''' </summary>
    ''' <param name="comByte">byte array to convert</param>
    ''' <returns>a hex string</returns>
    ''' <remarks></remarks>
    Private Function ByteToHex(ByVal ComByte As Byte()) As String
        'create a new StringBuilder object
        Dim builder As StringBuilder = New StringBuilder(ComByte.Length * 3)
        'loop through each byte in the array
        For Each data As Byte In ComByte
            'convert the byte to a string and add to the stringbuilder
            builder.Append(Convert.ToString(data, 16).PadLeft(2, "0"c).PadRight(3, " "c))
        Next
        'return the converted value
        Return builder.ToString().ToUpper()
    End Function
#End Region
    Private Shared Function DecToHex(ByVal Value As Integer) As String
        Dim lst As New List(Of Integer)
        Dim du As Integer = Value Mod 16
        Value = Fix(Value / 16)
        lst.Add(du)
        While Value <> 0
            du = Value Mod 16
            Value = Fix(Value / 16)
            lst.Add(du)
        End While
        Dim result As String = ""
        If lst.Count Mod 2 <> 0 Then
            result = "0" + result
        End If
        For i As Integer = lst.Count - 1 To 0 Step -1
            Select Case lst(i)
                Case 10
                    result += "A"
                Case 11
                    result += "B"

                Case 12
                    result += "C"

                Case 13
                    result += "D"

                Case 14
                    result += "E"

                Case 15
                    result += "F"
                Case Else
                    result += lst(i).ToString()
            End Select
            If result.Replace(" ", "").Length Mod 2 = 0 Then
                result += " "
            End If
        Next

        Return result
    End Function

    Private Function ComputeLengthCommand(ByVal Command As String) As String
        Dim arr As String() = Command.Trim().Split(" "c, "")
        Return (arr.Length + 2).ToString("X2")
    End Function

    Private Function ComputeCheckSum(ByVal Command As String) As String
        Dim arr As String() = Command.Trim().Split(" "c, "")
        Dim Sum As Integer = 0
        For Each ele As String In arr
            Sum += Val("&H" & ele)
        Next
        Dim result As String = Sum.ToString("X").Replace(" "c, "")
        If result.Length = 1 Then
            Return "0" & result
        Else
            Return result(result.Length - 2) & result(result.Length - 1)
        End If
    End Function

    Private Shared Function HexToDec(ByVal val As String) As Integer
        Dim a As Integer = CInt("&H" & val.Replace(" ", ""))
        Return a
    End Function

    Private Sub btn44_1_Click(sender As Object, e As EventArgs) Handles btn44_1.Click, btn44_10.Click, btn44_2.Click, btn44_20.Click, btn44_5.Click, btn48_1.Click, btn48_10.Click, btn48_2.Click, btn48_20.Click, btn48_5.Click, btn52_1.Click, btn52_10.Click, btn52_2.Click, btn52_20.Click, btn52_5.Click, btn56_1.Click, btn56_10.Click, btn56_2.Click, btn56_20.Click, btn56_5.Click, btn60_1.Click, btn60_10.Click, btn60_2.Click, btn60_20.Click, btn60_5.Click, btn64_10.Click, btn64_20.Click, btn64_5.Click, btn68_10.Click, btn68_20.Click, btn68_5.Click, btn72_10.Click, btn72_20.Click, btn72_5.Click, btn76_10.Click, btn76_20.Click, btn76_5.Click
        Dim id As String = (CType(sender, Button)).Name.Replace("btn", "txt")
        Dim textbox As Control = Controls.Find(id, True)(0)
        Dim current As Double = CDbl(id.Replace("txt", "").Split("_"c)(0))
        Dim frequency As Double = CDbl(id.Replace("txt", "").Split("_"c)(1))

        PRR = frequency
        OperatingPower = current
    End Sub

    Private Sub ReadFromFile()
        If My.Computer.FileSystem.FileExists("D:\DataSettings\LaserTrimming1610\Machine\LaserPower\Watts.Sys") Then
            Dim strData() As String
            strData = System.IO.File.ReadAllLines("D:\DataSettings\LaserTrimming1610\Machine\LaserPower\Watts.Sys", System.Text.Encoding.Default)
            For freqIdx As Integer = 1 To 20
                For currentIdx As Integer = 1 To 100
                    m__AvgPwTable(currentIdx, freqIdx) = strData((freqIdx - 1) * 100 + (currentIdx - 1))
                Next
            Next


        End If
    End Sub

    Private Sub WriteToFile()
        Dim strData(0 To 2000) As String
        For freqIdx As Integer = 1 To 20
            For currentIdx As Integer = 1 To 100
                strData((freqIdx - 1) * 100 + (currentIdx - 1)) = m__AvgPwTable(currentIdx, freqIdx)
            Next
        Next
        System.IO.File.WriteAllLines("D:\DataSettings\LaserTrimming1610\Machine\LaserPower\Watts.Sys", strData)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click



        m__AvgPwTable(44, 1) = txt44_1.Text
        m__AvgPwTable(48, 1) = txt48_1.Text
        m__AvgPwTable(52, 1) = txt52_1.Text
        m__AvgPwTable(56, 1) = txt56_1.Text
        m__AvgPwTable(60, 1) = txt60_1.Text

        m__AvgPwTable(44, 2) = txt44_2.Text
        m__AvgPwTable(48, 2) = txt48_2.Text
        m__AvgPwTable(52, 2) = txt52_2.Text
        m__AvgPwTable(56, 2) = txt56_2.Text
        m__AvgPwTable(60, 2) = txt60_2.Text

        m__AvgPwTable(44, 5) = txt44_5.Text
        m__AvgPwTable(48, 5) = txt48_5.Text
        m__AvgPwTable(52, 5) = txt52_5.Text
        m__AvgPwTable(56, 5) = txt56_5.Text
        m__AvgPwTable(60, 5) = txt60_5.Text
        m__AvgPwTable(64, 5) = txt64_5.Text
        m__AvgPwTable(68, 5) = txt68_5.Text
        m__AvgPwTable(72, 5) = txt72_5.Text
        m__AvgPwTable(76, 5) = txt76_5.Text

        m__AvgPwTable(44, 10) = txt44_10.Text
        m__AvgPwTable(48, 10) = txt48_10.Text
        m__AvgPwTable(52, 10) = txt52_10.Text
        m__AvgPwTable(56, 10) = txt56_10.Text
        m__AvgPwTable(60, 10) = txt60_10.Text
        m__AvgPwTable(64, 10) = txt64_10.Text
        m__AvgPwTable(68, 10) = txt68_10.Text
        m__AvgPwTable(72, 10) = txt72_10.Text
        m__AvgPwTable(76, 10) = txt76_10.Text

        m__AvgPwTable(44, 20) = txt44_20.Text
        m__AvgPwTable(48, 20) = txt48_20.Text
        m__AvgPwTable(52, 20) = txt52_20.Text
        m__AvgPwTable(56, 20) = txt56_20.Text
        m__AvgPwTable(60, 20) = txt60_20.Text
        m__AvgPwTable(64, 20) = txt64_20.Text
        m__AvgPwTable(68, 20) = txt68_20.Text
        m__AvgPwTable(72, 20) = txt72_20.Text
        m__AvgPwTable(76, 20) = txt76_20.Text


        For currentIdx As Integer = 44 To 76 Step 4
            For freqIdx As Integer = 1 To 20 Step 1
                Select Case freqIdx
                    Case 1, 2, 5, 10, 20
                    Case < 5
                        If currentIdx <= 60 Then
                            m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(currentIdx, 5) - m__AvgPwTable(currentIdx, 2)) * (freqIdx - 2) / 3 + m__AvgPwTable(currentIdx, 2)
                        End If
                    Case < 10
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(currentIdx, 10) - m__AvgPwTable(currentIdx, 5)) * (freqIdx - 5) / 5 + m__AvgPwTable(currentIdx, 5)
                    Case Else
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(currentIdx, 20) - m__AvgPwTable(currentIdx, 10)) * (freqIdx - 10) / 10 + m__AvgPwTable(currentIdx, 10)
                End Select
            Next
        Next





        For freqIdx As Integer = 1 To 20 Step 1
            For currentIdx As Integer = 44 To 76 Step 1
                Select Case currentIdx
                    Case 44, 48, 52, 56, 60, 64, 68, 72, 76
                    Case < 48
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(48, freqIdx) - m__AvgPwTable(44, freqIdx)) * (currentIdx - 44) / 4 + m__AvgPwTable(44, freqIdx)
                    Case < 52
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(52, freqIdx) - m__AvgPwTable(48, freqIdx)) * (currentIdx - 48) / 4 + m__AvgPwTable(48, freqIdx)
                    Case < 56
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(56, freqIdx) - m__AvgPwTable(52, freqIdx)) * (currentIdx - 52) / 4 + m__AvgPwTable(52, freqIdx)
                    Case < 60
                        m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(60, freqIdx) - m__AvgPwTable(56, freqIdx)) * (currentIdx - 56) / 4 + m__AvgPwTable(56, freqIdx)
                    Case < 64
                        If freqIdx >= 5 Then
                            m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(64, freqIdx) - m__AvgPwTable(60, freqIdx)) * (currentIdx - 60) / 4 + m__AvgPwTable(60, freqIdx)
                        End If
                    Case < 68
                        If freqIdx >= 5 Then
                            m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(68, freqIdx) - m__AvgPwTable(64, freqIdx)) * (currentIdx - 64) / 4 + m__AvgPwTable(64, freqIdx)
                        End If
                    Case < 72
                        If freqIdx >= 5 Then
                            m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(72, freqIdx) - m__AvgPwTable(68, freqIdx)) * (currentIdx - 68) / 4 + m__AvgPwTable(68, freqIdx)
                        End If
                    Case Else
                        If freqIdx >= 5 Then
                            m__AvgPwTable(currentIdx, freqIdx) = (m__AvgPwTable(76, freqIdx) - m__AvgPwTable(72, freqIdx)) * (currentIdx - 72) / 4 + m__AvgPwTable(72, freqIdx)
                        End If
                End Select
            Next
        Next


        Dim strData(0 To 2000) As String
        For freqIdx As Integer = 1 To 20
            For currentIdx As Integer = 1 To 100
                strData((freqIdx - 1) * 100 + (currentIdx - 1)) = m__AvgPwTable(currentIdx, freqIdx)
            Next
        Next
        Call WriteToFile()
        ReadFromFile()
        Dim i As Integer
        CalculatedCurrent(2, 5, i)
    End Sub


    Public Function CalculatedCurrent(ByVal Pwr As Double, ByVal Freq As Double, ByRef Perc As Double) As Boolean
        Dim pwrReal As Double
        Select Case Freq
            Case < 5
                Perc = 60
                CalculatedCurrent = False
                pwrReal = m__AvgPwTable(60, Freq)
                If Pwr >= pwrReal Then
                Else
                    For currentIdx As Integer = 44 To 60
                        pwrReal = m__AvgPwTable(currentIdx, Freq)
                        If pwrReal >= Pwr Then
                            Perc = currentIdx
                            CalculatedCurrent = True
                            Exit For
                        End If
                    Next
                End If
            Case Else
                Perc = 76
                CalculatedCurrent = False
                pwrReal = m__AvgPwTable(76, Freq)
                If Pwr >= pwrReal Then
                Else
                    For currentIdx As Integer = 44 To 76
                        If m__AvgPwTable(currentIdx, Freq) >= Pwr Then
                            Perc = currentIdx
                            CalculatedCurrent = True
                            Exit For
                        End If
                    Next
                End If
        End Select
    End Function

    Private Sub btnLaserON_Click(sender As Object, e As EventArgs) Handles btnLaserON.Click
        Dim ctlString As String = "02 00" 'Trigger Internal+Gate low Active
        Dim str As String = STARTBYTE & " " & ComputeLengthCommand(EXTERNALSETTINGCOMMAND & " " & ctlString) & " " & EXTERNALSETTINGCOMMAND & " " & ctlString & " "
        Dim cmd As String = str & ComputeCheckSum(str) & " " & ENDBYTE
        Call WriteData(cmd)
    End Sub

    Private Sub btnLaserOFF_Click(sender As Object, e As EventArgs) Handles btnLaserOFF.Click
        Dim ctlString As String = "42 20" 'Trigger External+FPK on+Gate high Active
        Dim str As String = STARTBYTE & " " & ComputeLengthCommand(EXTERNALSETTINGCOMMAND & " " & ctlString) & " " & EXTERNALSETTINGCOMMAND & " " & ctlString & " "
        Dim cmd As String = str & ComputeCheckSum(str) & " " & ENDBYTE
        Call WriteData(cmd)
    End Sub
End Class
#End If
