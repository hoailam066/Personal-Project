Imports Newtonsoft.Json
Imports System.IO
Imports System.ComponentModel

Public Class CCorrection
    Private m_JumpSpeed As Integer
    Private m_MarkSpeed As Integer
    Private m_JumpDelay As Integer
    Private m_MarkDelay As Integer
    Private m_PolygonDelay As Integer
    Private m_LaserOnDelay As Integer
    Private m_LaserOffDelay As Integer
    Private m_Range As eCorrectionRange
    Private m_Size As Integer 'eCorrectionSize
    Private m_Radius As Integer
    Private m_PRR As Double
    Private m_Power As Double
    Private m_LaserOn As Boolean = False
    Private m_CorrectionData As List(Of CCorrectionData)
    Private m_KFactor As Integer
    Private m_GalvoAngle As Double
    Private m_GalvoOffsetX As Integer
    Private m_GalvoOffsetY As Integer
    Private m_LoopDraw As Boolean
    <Category("Common Parameters")>
    <DisplayName("Jump Speed (mm/s)")>
    <Description("Value must in the range [1...50000]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 1 OrElse value > 50000) Then
                FMessageBox.Show("Value must in the range [1...50000].", "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_JumpSpeed = value
            End If

        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Mark Speed (mm/s)")>
    <Description("Value must in the range [1...50000]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property MarkSpeed As Integer
        Get
            Return m_MarkSpeed
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 50000) Then
                FMessageBox.Show("Value must in the range [1...50000].", "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_MarkSpeed = value
            End If

        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Jump Delay (us)")>
    <Description("Value must in the range [0...327670]")>
    Public Property JumpDelay As Integer
        Get
            Return m_JumpDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show("Value must in the range [0...327670]", "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_JumpDelay = value
            End If
        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Mark Delay (us)")>
    <Description("Value must in the range [0...327670]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property MarkDelay As Integer
        Get
            Return m_MarkDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show("Value must in the range [0...327670]", "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_MarkDelay = value
            End If
        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Polygon Delay (us)")>
    <Description("Value must in the range [0...327670]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property PolygonDelay As Integer
        Get
            Return m_PolygonDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show("Value must in the range [0...327670].", "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_PolygonDelay = value
            End If

        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Laser On Delay (us)")>
    <Description("Value must in the range [-8000...8000]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property LaserOnDelay As Integer
        Get
            Return m_LaserOnDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Laser On Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < -8000 OrElse value > 8000) Then
                FMessageBox.Show("Value must in the range [-8000...8000].", "Laser On Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_LaserOnDelay = value
            End If

        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Laser Off Delay (us)")>
    <Description("Value must in the range [2...8000]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property LaserOffDelay As Integer
        Get
            Return m_LaserOffDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Laser Off Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 2 OrElse value > 8000) Then
                FMessageBox.Show("Value must in the range [2...8000].", "Laser Off Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_LaserOffDelay = value
            End If

        End Set
    End Property
    <Category("Common Parameters")>
    <DisplayName("Range")>
    <Description("Range")>
    Public Property Range As eCorrectionRange
        Get
            Return m_Range
        End Get
        Set(ByVal value As eCorrectionRange)
            'If (Me.Size * ((value - 1) / 2) > 32767) Then
            '    FMessageBox.Show("Out range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Else
            '    Dim x = m_Range
            m_Range = value
            'If (x <> m_Radius) Then
            '    LoadCorrectionData()
            'End If
            'End If
        End Set
    End Property
    <Category("Common Parameters")>
    <DisplayName("Grid Size (um)")>
    <Description("Grid Size (um)")>
    Public Property Size As Integer
        Get
            Return m_Size
        End Get
        Set(ByVal value As Integer)
            'If (value * ((Me.Range - 1) / 2) > 32767) Then
            '    FMessageBox.Show("Out range.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            'Else
            m_Size = value
            'End If
        End Set
    End Property
    <Category("Common Parameters")>
    <DisplayName("Radius (bit/mm)")>
    <Description("Radius")>
    Public Property Radius As Integer
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Integer)
            m_Radius = value
        End Set
    End Property
    <Category("Common Parameters")>
    <DisplayName("K factor (bit/mm)")>
    <Description("K factor (bit/mm)")>
    Public Property KFactor As Integer
        Get
            Return m_KFactor
        End Get
        Set(ByVal value As Integer)
            m_KFactor = value
        End Set
    End Property
    <Category("Common Parameters")>
    <DisplayName("Galvo Angle (deg)")>
    <Description("Galvo Angle (deg) must in range [-10...+10]")>
    <TypeConverter(GetType(DoubleTypeConverter))>
    Public Property GalvoAngle As Double
        Get
            Return m_GalvoAngle
        End Get
        Set(ByVal value As Double)
            If (value < -10 OrElse value > 10) Then
                FMessageBox.Show("Galvo angle must in range [-10...+10]", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_GalvoAngle = value
            End If
        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Galvo Offset X (bit)")>
    <Description("Value must in the range [-32768...32767]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property GalvoOffsetX As Integer
        Get
            Return m_GalvoOffsetX
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Galvo Offset X", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < -32768 OrElse value > 32767) Then
                FMessageBox.Show("Value must in the range [-32768...32767].", "Galvo Offset X", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_GalvoOffsetX = value
            End If

        End Set
    End Property

    <Category("Common Parameters")>
    <DisplayName("Galvo Offset Y (bit)")>
    <Description("Value must in the range [-32768...32767]")>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property GalvoOffsetY As Integer
        Get
            Return m_GalvoOffsetY
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show("Invalid value.", "Galvo Offset Y", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < -32768 OrElse value > 32767) Then
                FMessageBox.Show("Value must in the range [-32768...32767].", "Galvo Offset Y", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_GalvoOffsetY = value
            End If

        End Set
    End Property


    <Category("Common Parameters")>
    <DisplayName("Laser loop")>
    Public Property LoopDraw As Boolean
        Get
            Return m_LoopDraw
        End Get
        Set(ByVal value As Boolean)
            m_LoopDraw = value
        End Set
    End Property

    <Category("Laser Parameters")>
    <DisplayName("Laser On")>
    <Description("Laser On")>
    Public Property LaserOn As Boolean
        Get
            Return m_LaserOn
        End Get
        Set(ByVal value As Boolean)
            m_LaserOn = value
        End Set
    End Property

    <Category("Laser Parameters")>
    <DisplayName("PRR (kHz)")>
    <Description("Laser Pulse Repentition Rate (kHz)")>
    Public Property PRR As Double
        Get
            Return m_PRR
        End Get
        Set(ByVal value As Double)
            m_PRR = value
        End Set
    End Property

    <Category("Laser Parameters")>
    <DisplayName("Power (%)")>
    <Description("Laser Power (%)")>
    Public Property Power As Double
        Get
            Return m_Power
        End Get
        Set(ByVal value As Double)
            m_Power = value
        End Set
    End Property

    <Browsable(False)>
    Public Property CorrectionData As List(Of CCorrectionData)
        Get
            Return m_CorrectionData
        End Get
        Set(ByVal value As List(Of CCorrectionData))
            m_CorrectionData = value
        End Set
    End Property

    Public Sub New()
        m_JumpSpeed = 100
        m_MarkSpeed = 50
        m_JumpDelay = 10
        m_MarkDelay = 10
        m_PolygonDelay = 10
        m_LaserOnDelay = 10
        m_LaserOffDelay = 10
        m_Radius = 100
        m_Power = 30
        m_PRR = 20
        m_KFactor = 820
        m_Range = eCorrectionRange.R_3x3
        m_Size = 100 'eCorrectionSize.S_100
    End Sub
    Public Sub SaveCorectionParam2()
        Try
            Dim path As String = "D:\DataSettings\LaserMachine\MachineData\User\"
            If (Directory.Exists(path) = False) Then
                Directory.CreateDirectory(path)
            End If
            path &= "Corection.cor"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(Me, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()

            Dim lst As New List(Of String)
            lst.Add("")
            lst.Add("Limits")
            lst.Add("FitOrder = 4")
            lst.Add("NewCal = 1000")
            lst.Add("")
            lst.Add("OldCTBFile = D2_263.ctb")
            lst.Add("NewCTBFile = NewD2_263.ctb")
            lst.Add("")
            lst.Add("// RTC-X [Bit] RTC-Y[Bit] REAL-X[mm] REAL-Y[mm]")
            lst.Add("")
            Dim tmpCorData As New List(Of CCorrectionData)
            For idx = 0 To m_CorrectionData.Count - 1
                lst.Add(String.Format("{0,6:+#;-#;0}{1,7:+#;-#;0}{2,9:+#.0000;-#.0000;0.0000}{3,9:+#.0000;-#.0000;0.0000}", m_CorrectionData(idx).RTC_X, m_CorrectionData(idx).RTC_Y, m_CorrectionData(idx).REAL_X, m_CorrectionData(idx).REAL_Y))
                If ((idx + 1) Mod Me.Range = 0) Then
                    lst.Add("")
                End If
            Next
            System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\MachineData\User\CorrectionData" & Me.Range & "x" & Me.Range & "_Size" & Me.Size & ".dat", lst.ToArray())
            tmpCorData.Clear()
            tmpCorData = Nothing
            lst.Clear()
            lst = Nothing
            GC.Collect()

        Catch ex As Exception
        End Try
    End Sub
    Public Function SaveCorectionParam(Optional ByVal WriteCorrectionFile As Boolean = False) As String
        Try
            Dim path As String = "D:\DataSettings\LaserMachine\MachineData\User\"
            If (Directory.Exists(path) = False) Then
                Directory.CreateDirectory(path)
            End If
            path &= "Corection.cor"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(Me, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()

            Dim lst As New List(Of String)
            Dim lst2 As New List(Of String)
            lst.Add("")
            lst.Add("Limits")
            lst.Add("FitOrder = 4")
            lst.Add("NewCal = " & KFactor)
            lst.Add("")
            lst.Add("OldCTBFile = D2_263.ctb")
            lst.Add("NewCTBFile = NewD2_263.ctb")
            lst.Add("")
            lst.Add("// RTC-X [Bit] RTC-Y[Bit] REAL-X[mm] REAL-Y[mm]")
            lst.Add("")
            Dim tmpCorData As New List(Of CCorrectionData)
            For idx = 0 To m_CorrectionData.Count - 1
                lst.Add(String.Format("{0,6:+#;-#;0}{1,7:+#;-#;0}{2,9:+#.0000;-#.0000;0.0000}{3,9:+#.0000;-#.0000;0.0000}", m_CorrectionData(idx).RTC_X, m_CorrectionData(idx).RTC_Y, m_CorrectionData(idx).REAL_X, m_CorrectionData(idx).REAL_Y))
                If ((idx + 1) Mod Me.Range = 0) Then
                    lst.Add("")
                End If
                lst2.Add(String.Format("{0},{1},{2},{3}", m_CorrectionData(idx).RTC_X, m_CorrectionData(idx).RTC_Y, m_CorrectionData(idx).REAL_X, m_CorrectionData(idx).REAL_Y))
            Next
            Dim savePath As String = "D:\DataSettings\LaserMachine\MachineData\User\D2_263.dat" 'CorrectionData" & Me.Range & "x" & Me.Range & "_Size" & Me.Size & "_K" & KFactor & ".dat"

            If (System.IO.File.Exists("C:\RTC4 Files\D2_263.ctb")) Then
                My.Computer.FileSystem.CopyFile("C:\RTC4 Files\D2_263.ctb", "D:\DataSettings\LaserMachine\MachineData\User\D2_263.ctb", True)
            End If
            If (WriteCorrectionFile = True) Then
                If (System.IO.File.Exists("D:\DataSettings\LaserMachine\Machine\Parameter\GalvoPickCalibration.txt")) Then
                    If (Not System.IO.Directory.Exists("D:\DataSettings\LaserMachine\Machine\Parameter\Backup")) Then
                        System.IO.Directory.CreateDirectory("D:\DataSettings\LaserMachine\Machine\Parameter\Backup")
                    End If
                    My.Computer.FileSystem.CopyFile("D:\DataSettings\LaserMachine\Machine\Parameter\GalvoPickCalibration.txt", "D:\DataSettings\LaserMachine\Machine\Parameter\Backup\GalvoPickCalibration" & DateTime.Now.ToString("yyyyMMddHHmmss") & ".txt", True)
                End If
                System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\Machine\Parameter\GalvoPickCalibration.txt", lst2.ToArray())
                lst2.Clear()
                lst2 = Nothing
            End If
            System.IO.File.WriteAllLines(savePath, lst.ToArray())

            tmpCorData.Clear()
            tmpCorData = Nothing
            lst.Clear()
            lst = Nothing
            
            GC.Collect()
            Return savePath
        Catch ex As Exception
        End Try
        Return ""
    End Function
    Public Sub LoadCorectionParam()
        Try
            Dim path As String = "D:\DataSettings\LaserMachine\MachineData\User\Corection.cor"
            Dim sr As StreamReader = New StreamReader(path, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            Dim tmp = JsonConvert.DeserializeObject(Of CCorrection)(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Me.m_JumpDelay = tmp.m_JumpDelay
            Me.m_JumpSpeed = tmp.m_JumpSpeed
            Me.m_LaserOffDelay = tmp.m_LaserOffDelay
            Me.m_LaserOnDelay = tmp.m_LaserOnDelay
            Me.m_MarkDelay = tmp.m_MarkDelay
            Me.m_MarkSpeed = tmp.m_MarkSpeed
            Me.m_PolygonDelay = tmp.m_PolygonDelay
            Me.m_Size = tmp.Size
            Me.Radius = tmp.Radius
            Me.Range = tmp.Range
            Me.PRR = tmp.PRR
            Me.Power = tmp.Power
            Me.KFactor = tmp.KFactor
            'Me.CorrectionData = tmp.CorrectionData
            LoadCorrectionData()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadCorrectionData()
        Dim path As String = "D:\DataSettings\LaserMachine\MachineData\User\CorrectionData" & Me.Range & "x" & Me.Range & "_Size" & Me.Size & ".dat"
        m_CorrectionData = New List(Of CCorrectionData)
        If (Path = "" OrElse System.IO.File.Exists(Path) = False) Then
            Dim startIdx As Integer = -(Me.Range - 1) / 2
            Dim endIdx As Integer = (Me.Range - 1) / 2
            Dim pX, pY As Integer
            For x = startIdx To endIdx Step 1
                pX = x * Me.Size
                For y = startIdx To endIdx Step 1
                    pY = y * Me.Size
                    m_CorrectionData.Add(New CCorrectionData(pX, pY, 0, 0))
                Next
            Next
        Else
            Dim strs() As String = System.IO.File.ReadAllLines(Path)
            For i = 10 To strs.Length - 1
                If (strs(i) <> "" AndAlso strs(i).Length >= 31) Then
                    Dim strRTCX As String = strs(i).Substring(0, 6).Trim().Replace("+", "")
                    Dim strRTCY As String = strs(i).Substring(6, 7).Trim().Replace("+", "")
                    Dim strRealX As String = strs(i).Substring(13, 9).Trim().Replace("+", "")
                    Dim strRealY As String = strs(i).Substring(22, 9).Trim().Replace("+", "")
                    Dim tmp As Double
                    Dim cor As CCorrectionData = New CCorrectionData()
                    If (Double.TryParse(strRTCX, tmp)) Then
                        cor.RTC_X = CInt(tmp)
                    End If
                    If (Double.TryParse(strRTCY, tmp)) Then
                        cor.RTC_Y = CInt(tmp)
                    End If
                    If (Double.TryParse(strRealX, tmp)) Then
                        cor.REAL_X = tmp
                    End If
                    If (Double.TryParse(strRealY, tmp)) Then
                        cor.REAL_Y = tmp
                    End If
                    m_CorrectionData.Add(cor)
                End If
            Next
        End If
    End Sub
End Class

Public Enum eCorrectionRange As Integer
    R_3x3 = 3
    R_5x5 = 5
    R_7x7 = 7
    R_9x9 = 9
    R_11x11 = 11
    R_13x13 = 13
    R_15x15 = 15
End Enum
'Public Enum eCorrectionSize As Integer
'    S_10 = 10
'    S_100 = 100
'    S_1000 = 1000
'    S_5000 = 5000
'    S_10000 = 10000
'End Enum
Public Class CCorrectionData
    Public Property RTC_X As Integer
    Public Property RTC_Y As Integer
    Public Property REAL_X As Double
    Public Property REAL_Y As Double
    Public Sub New()
        RTC_X = 0
        RTC_Y = 0
        REAL_X = 0
        REAL_Y = 0
    End Sub
    Public Sub New(ByVal x1 As Integer, ByVal y1 As Integer, ByVal x2 As Double, ByVal y2 As Double)
        Me.RTC_X = x1
        Me.RTC_Y = y1
        Me.REAL_X = x2
        Me.REAL_Y = y2
    End Sub
    Public Overrides Function ToString() As String
        Return Me.RTC_X & "," & Me.RTC_Y & "," & Me.REAL_X & "," & Me.REAL_Y
    End Function
End Class