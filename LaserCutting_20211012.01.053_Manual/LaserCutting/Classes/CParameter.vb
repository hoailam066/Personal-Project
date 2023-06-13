Imports Newtonsoft.Json
Imports System.IO
Imports Xmler

Public Enum enumXY
    x1 = 0
    y1 = 1
    x2 = 2
    y2 = 3
End Enum
Public Enum enumCyl

    ''' <summary>
    ''' LaserPowerOn
    ''' </summary>
    ''' <remarks></remarks>
    LaserPowerOn = 0
    ''' <summary>
    ''' LaserEnable
    ''' </summary>
    ''' <remarks></remarks>
    LaserEnable = 1
    ''' <summary>
    ''' LaserReset
    ''' </summary>
    ''' <remarks></remarks>
    LaserReset = 2


    ''' <summary>
    ''' '綠燈
    ''' </summary>
    ''' <remarks></remarks>
    LightGreen = 9
    ''' <summary>
    ''' '黃燈
    ''' </summary>
    ''' <remarks></remarks>
    LightYellow = 10
    ''' <summary>
    ''' '紅燈
    ''' </summary>
    ''' <remarks></remarks>
    LightRed = 11
    ''' <summary>
    ''' '警報器
    ''' </summary>
    ''' <remarks></remarks>
    Buzzer = 12

    Maximum = 16
End Enum
Public Enum enumSnr
    ''' <summary>
    ''' LaserWarning
    ''' </summary>
    ''' <remarks></remarks>
    LaserWarning = 0
    ''' <summary>
    ''' LaserError
    ''' </summary>
    ''' <remarks></remarks>
    LaserError = 1

    Maximum = 16
End Enum
Public Class CParameter
    Private m_flags As CFlags
    Private m_Pos As CPosition
    Private m_Idx As CIdx
    Private m_Count As CCount
    Private m_Time As CTime
    Private m_Variable As CVariable
    Private m_Speed As CSpeed


    Private m_FeederRecipe(0 To 3) As CFeederRecipe
    Private m_LaserRecipe(0 To 7) As CLaserRecipe
    Private m_ZeroNumber As Double = 0
    Private m_RegisterPosition As CRegisterPosition
    Public Sub New(ByVal FilePath As String)
        ReDim m_FeederRecipe(0 To 3)
        m_FeederRecipe(0) = New CFeederRecipe("Feeder0", 350, 17, 10, 3.0, 5.5, 1, 100, 3.5)
        m_FeederRecipe(1) = New CFeederRecipe("Feeder1", 300, 17, 8, 3.0, 5.5, 1, 100, 3.5)
        m_FeederRecipe(2) = New CFeederRecipe("Feeder2", 350, 17, 12, 3.0, 5.5, 1, 100, 3.5)
        m_FeederRecipe(3) = New CFeederRecipe("Feeder3", 500, 20, 20, 5.0, 5.0, 1, 100, 10.0)
        ReDim m_LaserRecipe(0 To 7)
        m_LaserRecipe(0) = New CLaserRecipe("Laser0", 300, 700, New Double() {44.0, 47.0, 52.0, 53.0, 54.0, 54.0, 54.0, 51.0, 51.0})
        m_LaserRecipe(1) = New CLaserRecipe("Laser1", 250, 700, New Double() {39.0, 45.0, 52.0, 53.0, 53.0, 53.0, 53.0, 51.0, 51.0})
        m_LaserRecipe(2) = New CLaserRecipe("Laser2", 200, 700, New Double() {31.0, 37.0, 44.0, 45.0, 46.0, 46.0, 46.0, 43.0, 43.0})
        m_LaserRecipe(3) = New CLaserRecipe("Laser3", 150, 450, New Double() {12.6, 13.0, 13.0, 13.5, 16.5, 20.7, 21.8, 21.8, 21.0})
        m_LaserRecipe(4) = New CLaserRecipe("Laser4", 150, 450, New Double() {12.5, 12.8, 12.8, 13.0, 15.4, 20.6, 21.4, 21.4, 20.8})
        m_LaserRecipe(5) = New CLaserRecipe("Laser5", 150, 450, New Double() {12.6, 12.8, 13.2, 13.5, 16.5, 20.7, 21.8, 21.8, 21.0})
        m_LaserRecipe(6) = New CLaserRecipe("Laser6", 50, 450, New Double() {19.0, 19.0, 19.0, 19.0, 19.0, 19.0, 19.0, 19.0, 19.0})
        m_LaserRecipe(7) = New CLaserRecipe("Laser7", 10, 700, New Double() {10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0, 10.0})

        m_ZeroNumber = 0
        m_RegisterPosition = New CRegisterPosition()

        If m_flags Is Nothing Then m_flags = New CFlags
        If m_Pos Is Nothing Then m_Pos = New CPosition
        If m_Idx Is Nothing Then m_Idx = New CIdx
        If m_Count Is Nothing Then m_Count = New CCount
        If m_Time Is Nothing Then m_Time = New CTime
        If m_Variable Is Nothing Then m_Variable = New CVariable
        If m_Speed Is Nothing Then m_Speed = New CSpeed

        If ReadDataFromFile(FilePath) Then

        End If

    End Sub
    Public Sub New(ByVal feederRecipe() As CFeederRecipe, ByVal laserRecipe() As CLaserRecipe, Optional ByVal zeroNumber As Double = 0)
        Me.FeederRecipe = feederRecipe
        Me.LaserRecipe = laserRecipe
        Me.ZeroNumber = zeroNumber
    End Sub

    Public Property FeederRecipe As CFeederRecipe()
        Get
            Return m_FeederRecipe
        End Get
        Set(ByVal value As CFeederRecipe())
            m_FeederRecipe = value
        End Set
    End Property

    Public Property LaserRecipe As CLaserRecipe()
        Get
            Return m_LaserRecipe
        End Get
        Set(ByVal value As CLaserRecipe())
            m_LaserRecipe = value
        End Set
    End Property
    Public Property ZeroNumber As Double
        Get
            Return m_ZeroNumber
        End Get
        Set(ByVal value As Double)
            m_ZeroNumber = value
        End Set
    End Property
    Public Property RegisterPosition As CRegisterPosition
        Get
            Return m_RegisterPosition
        End Get
        Set(ByVal value As CRegisterPosition)
            m_RegisterPosition = value
        End Set
    End Property
    Public Property AlignPosition As CRegisterPosition
        Get
            Return m_RegisterPosition
        End Get
        Set(ByVal value As CRegisterPosition)
            m_RegisterPosition = value
        End Set
    End Property


    Public Function LoadParam(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        LoadParam = True
        Try
            Dim sr As StreamReader
            Dim res As String
            Dim save As Boolean = False
            If (File.Exists(projectPath & "\Parameter\FeederRecipe.param") = True) Then
                sr = New StreamReader(projectPath & "\Parameter\FeederRecipe.param", System.Text.Encoding.Default)
                res = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                m_FeederRecipe = JsonConvert.DeserializeObject(Of CFeederRecipe())(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
                For i = m_FeederRecipe.Length To 3
                    ReDim Preserve m_FeederRecipe(m_FeederRecipe.Length)
                    m_FeederRecipe(m_FeederRecipe.Length - 1) = New CFeederRecipe()
                    save = True
                Next
            Else
                ReDim Preserve m_FeederRecipe(0 To 3)
                For i = 0 To 3
                    m_FeederRecipe(i) = New CFeederRecipe()
                Next
                save = True
            End If
            If (File.Exists(projectPath & "\Parameter\LaserRecipe.param") = True) Then
                sr = New StreamReader(projectPath & "\Parameter\LaserRecipe.param", System.Text.Encoding.Default)
                res = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                m_LaserRecipe = JsonConvert.DeserializeObject(Of CLaserRecipe())(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
                For i = m_LaserRecipe.Length To 7
                    ReDim Preserve m_LaserRecipe(m_LaserRecipe.Length)
                    m_LaserRecipe(m_LaserRecipe.Length - 1) = New CLaserRecipe()
                    save = True
                Next
            Else
                ReDim Preserve m_LaserRecipe(0 To 7)
                For i = 0 To 7
                    m_LaserRecipe(i) = New CLaserRecipe()
                Next
                save = True
            End If
            If (File.Exists(projectPath & "\Parameter\ZeroNumber.param") = True) Then
                sr = New StreamReader(projectPath & "\Parameter\ZeroNumber.param", System.Text.Encoding.Default)
                res = sr.ReadLine()
                sr.Close()
                sr.Dispose()
                Double.TryParse(res, Me.ZeroNumber)
            Else
                Me.ZeroNumber = 0
                save = True
            End If

            If (File.Exists(projectPath & "\Parameter\RegisterPosition.param") = True) Then
                sr = New StreamReader(projectPath & "\Parameter\RegisterPosition.param", System.Text.Encoding.Default)
                res = sr.ReadToEnd()
                sr.Close()
                sr.Dispose()
                m_RegisterPosition = JsonConvert.DeserializeObject(Of CRegisterPosition)(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
                For i = m_RegisterPosition.ListRegisterPosition.Length To 15
                    ReDim Preserve m_RegisterPosition.ListRegisterPosition(m_RegisterPosition.ListRegisterPosition.Length)
                    m_RegisterPosition.ListRegisterPosition(m_RegisterPosition.ListRegisterPosition.Length - 1) = New CRegisterPositionData()
                    save = True
                Next

                For i = m_RegisterPosition.ListRegisterGlobalAlignPosition.Length To 4
                    ReDim Preserve m_RegisterPosition.ListRegisterGlobalAlignPosition(m_RegisterPosition.ListRegisterGlobalAlignPosition.Length)
                    m_RegisterPosition.ListRegisterGlobalAlignPosition(m_RegisterPosition.ListRegisterGlobalAlignPosition.Length - 1) = New CRegisterPositionData()
                    save = True
                Next

                For i = m_RegisterPosition.ListRegisterLocalAlignPosition.Length To 4
                    ReDim Preserve m_RegisterPosition.ListRegisterLocalAlignPosition(m_RegisterPosition.ListRegisterLocalAlignPosition.Length)
                    m_RegisterPosition.ListRegisterLocalAlignPosition(m_RegisterPosition.ListRegisterLocalAlignPosition.Length - 1) = New CRegisterPositionData()
                    save = True
                Next
            Else
                m_RegisterPosition = New CRegisterPosition()
                save = True
            End If

            If (save) Then
                SaveParam(projectPath)
            End If
        Catch ex As Exception
            errorString = ex.Message
            LoadParam = False
        End Try
    End Function
    Public Function SaveParam(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        SaveParam = True
        Try
            Dim err As String = ""
            SaveFeederRecipe(projectPath, err)
            errorString &= err
            err = ""
            SaveLaserRecipe(projectPath, err)
            If (errorString <> "") Then
                errorString &= vbCrLf
            End If
            errorString &= err
            err = ""
            SaveZeroNumber(projectPath, err)
            If (errorString <> "") Then
                errorString &= vbCrLf
            End If
            errorString &= err
            err = ""
            SaveRegisterPosition(projectPath, err)
            If (errorString <> "") Then
                errorString &= vbCrLf
            End If
            errorString &= err
        Catch ex As Exception
            errorString = ex.Message
            SaveParam = False
        End Try
    End Function
    Public Function SaveFeederRecipe(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        SaveFeederRecipe = True
        Try
            Dim sw As StreamWriter = New StreamWriter(projectPath & "\Parameter\FeederRecipe.param", False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(m_FeederRecipe, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            errorString = ex.Message
            SaveFeederRecipe = False
        End Try
    End Function
    Public Function SaveLaserRecipe(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        SaveLaserRecipe = True
        Try
            Dim sw As StreamWriter = New StreamWriter(projectPath & "\Parameter\LaserRecipe.param", False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(m_LaserRecipe, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            errorString = ex.Message
            SaveLaserRecipe = False
        End Try
    End Function
    Public Function SaveZeroNumber(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        SaveZeroNumber = True
        Try
            Dim sw As StreamWriter = New StreamWriter(projectPath & "\Parameter\ZeroNumber.param", False, System.Text.Encoding.Default)
            sw.WriteLine(Me.ZeroNumber.ToString())
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            errorString = ex.Message
            SaveZeroNumber = False
        End Try
    End Function
    Public Function SaveRegisterPosition(ByVal projectPath As String, Optional ByVal errorString As String = "") As Boolean
        SaveRegisterPosition = True
        Try
            Dim sw As StreamWriter = New StreamWriter(projectPath & "\Parameter\RegisterPosition.param", False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(m_RegisterPosition, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            errorString = ex.Message
            SaveRegisterPosition = False
        End Try
    End Function
    Public Function Clone(ByVal pPath As String) As CParameter
        Try
            Dim res As CParameter = New CParameter(pPath)

            Dim feeder(0 To Me.FeederRecipe.Length - 1) As CFeederRecipe
            For i = 0 To Me.FeederRecipe.Length - 1
                feeder(i) = Me.FeederRecipe(i).Clone()
            Next
            Dim laser(0 To Me.LaserRecipe.Length - 1) As CLaserRecipe
            For i = 0 To Me.LaserRecipe.Length - 1
                laser(i) = Me.LaserRecipe(i).Clone()
            Next
            Dim registerpos As CRegisterPosition
            registerpos = Me.m_RegisterPosition.Clone()
            res.FeederRecipe = feeder
            res.LaserRecipe = laser
            res.ZeroNumber = Me.ZeroNumber
            res.RegisterPosition = registerpos

            Return res
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Sub WriteLog(ByVal pPath As String, ByVal pOldParam As CParameter)
        Try
            'Write Feeder Recipe Log
            Dim lst As New List(Of String)
            Dim Time As DateTime = DateTime.Now
            For i = 0 To Me.FeederRecipe.Length - 1
                If (Me.FeederRecipe(i).BackwardDelay <> pOldParam.FeederRecipe(i).BackwardDelay) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").BackwardDelay|" & pOldParam.FeederRecipe(i).BackwardDelay & "|" & Me.FeederRecipe(i).BackwardDelay)
                End If
                If (Me.FeederRecipe(i).BackwardDistance <> pOldParam.FeederRecipe(i).BackwardDistance) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").BackwardDistance|" & pOldParam.FeederRecipe(i).BackwardDistance & "|" & Me.FeederRecipe(i).BackwardDistance)
                End If
                If (Me.FeederRecipe(i).BackwardSpeed <> pOldParam.FeederRecipe(i).BackwardSpeed) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").BackwardSpeed|" & pOldParam.FeederRecipe(i).BackwardSpeed & "|" & Me.FeederRecipe(i).BackwardSpeed)
                End If
                If (Me.FeederRecipe(i).ForwardDelay <> pOldParam.FeederRecipe(i).ForwardDelay) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").ForwardDelay|" & pOldParam.FeederRecipe(i).ForwardDelay & "|" & Me.FeederRecipe(i).ForwardDelay)
                End If
                If (Me.FeederRecipe(i).ForwardDistance1 <> pOldParam.FeederRecipe(i).ForwardDistance1) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").ForwardDistance1|" & pOldParam.FeederRecipe(i).ForwardDistance1.ToString("F3") & "|" & Me.FeederRecipe(i).ForwardDistance1.ToString("F3"))
                End If
                If (Me.FeederRecipe(i).ForwardDistance2 <> pOldParam.FeederRecipe(i).ForwardDistance2) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").ForwardDistance2|" & pOldParam.FeederRecipe(i).ForwardDistance2.ToString("F3") & "|" & Me.FeederRecipe(i).ForwardDistance2.ToString("F3"))
                End If
                If (Me.FeederRecipe(i).ForwardSpeed1 <> pOldParam.FeederRecipe(i).ForwardSpeed1) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").ForwardSpeed1|" & pOldParam.FeederRecipe(i).ForwardSpeed1 & "|" & Me.FeederRecipe(i).ForwardSpeed1)
                End If
                If (Me.FeederRecipe(i).ForwardSpeed2 <> pOldParam.FeederRecipe(i).ForwardSpeed2) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|FeederRecipe(" & i & ").ForwardSpeed2|" & pOldParam.FeederRecipe(i).ForwardSpeed2 & "|" & Me.FeederRecipe(i).ForwardSpeed2)
                End If
            Next

            'Write Feeder Recipe Log
            For i = 0 To Me.LaserRecipe.Length - 1
                If (Me.LaserRecipe(i).Interval <> pOldParam.LaserRecipe(i).Interval) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|LaserRecipe(" & i & ").Interval|" & pOldParam.LaserRecipe(i).Interval & "|" & Me.LaserRecipe(i).Interval)
                End If
                If (Me.LaserRecipe(i).SpotSize <> pOldParam.LaserRecipe(i).SpotSize) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|LaserRecipe(" & i & ").SpotSize|" & pOldParam.LaserRecipe(i).SpotSize & "|" & Me.LaserRecipe(i).SpotSize)
                End If
                For j = 0 To Me.LaserRecipe(i).Power.Length - 1
                    If (Me.LaserRecipe(i).Power(j) <> pOldParam.LaserRecipe(i).Power(j)) Then
                        lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|LaserRecipe(" & i & ").Power(" & j & ")|" & pOldParam.LaserRecipe(i).Power(j).ToString("F1") & "|" & Me.LaserRecipe(i).Power(j).ToString("F1"))
                    End If
                Next
            Next

            'Write Zero Log
            If (Me.ZeroNumber <> pOldParam.ZeroNumber) Then
                lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|ZeroNumber|" & pOldParam.ZeroNumber & "|" & Me.ZeroNumber)
            End If

            'Write Register position

            For j = 0 To Me.m_RegisterPosition.ListRegisterPosition.Length - 1
                If (Me.m_RegisterPosition.ListRegisterPosition(j).XAxis <> pOldParam.RegisterPosition.ListRegisterPosition(j).XAxis) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.XAxis(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).XAxis.ToString("F3") & "|" & Me.RegisterPosition.ListRegisterPosition(j).XAxis.ToString("F3"))
                End If
                If (Me.m_RegisterPosition.ListRegisterPosition(j).YAxis <> pOldParam.RegisterPosition.ListRegisterPosition(j).YAxis) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.YAxis(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).YAxis.ToString("F3") & "|" & Me.RegisterPosition.ListRegisterPosition(j).YAxis.ToString("F3"))
                End If
                If (Me.m_RegisterPosition.ListRegisterPosition(j).ZAxis <> pOldParam.RegisterPosition.ListRegisterPosition(j).ZAxis) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.ZAxis(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).ZAxis.ToString("F3") & "|" & Me.RegisterPosition.ListRegisterPosition(j).ZAxis.ToString("F3"))
                End If
                If (Me.m_RegisterPosition.ListRegisterPosition(j).RAxis <> pOldParam.RegisterPosition.ListRegisterPosition(j).RAxis) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.RAxis(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).RAxis.ToString("F3") & "|" & Me.RegisterPosition.ListRegisterPosition(j).RAxis.ToString("F3"))
                End If
                If (Me.m_RegisterPosition.ListRegisterPosition(j).SAxis <> pOldParam.RegisterPosition.ListRegisterPosition(j).SAxis) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.SAxis(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).SAxis.ToString("F3") & "|" & Me.RegisterPosition.ListRegisterPosition(j).SAxis.ToString("F3"))
                End If
                If (Me.m_RegisterPosition.ListRegisterPosition(j).MotionSequence <> pOldParam.RegisterPosition.ListRegisterPosition(j).MotionSequence) Then
                    lst.Add(Time.ToString("[yyyy-MM-dd] HH:mm:ss.fff") & "|" & CLoginInformation.CurrentUser.Username & "|RegisterPosition.MotionSequence(" & j & ")|" & pOldParam.RegisterPosition.ListRegisterPosition(j).MotionSequence.ToString() & "|" & Me.RegisterPosition.ListRegisterPosition(j).MotionSequence.ToString())
                End If
            Next


            CLog.SaveLog(lst, pPath & "\Log\Log.log")
        Catch ex As Exception
        End Try
    End Sub

    Private Const MCS_VARIABLE_WORKHOLDER_CCDRATIOX As String = "VARIABLE_WORKHOLDER_CCDRATIOX"
    Private Const MCS_VARIABLE_WORKHOLDER_CCDRATIOY As String = "VARIABLE_WORKHOLDER_CCDRATIOY"
    Private Const MCS_POS_LASERTESTZ_OFFSETX As String = "POS_LASERTESTZ_OFFSETX"
    Private Const MCS_POS_LASERTESTZ_OFFSETY As String = "POS_LASERTESTZ_OFFSETY"

    Private Const MCS_IDX_SYSTEM_SOLDERIDX As String = "IDX_SYSTEM_SOLDERIDX"
    Private Const MCS_IDX_SYSTEM_SOLDERLASERIDX As String = "IDX_SYSTEM_SOLDERLASERIDX"

    Public Function ReadDataFromFile(ByVal FilePath As String) As Boolean
        ReadDataFromFile = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument
            Dim rtnText As String = ""
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(FilePath) Then
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(FilePath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement

                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, "Parameter"), System.Xml.XmlElement)
                With m_Pos.Workholder
                    If CXmler.GetXmlData(stemNode, MCS_POS_LASERTESTZ_OFFSETX, 0, rtnText) Then .LaserTestZOffsetX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_POS_LASERTESTZ_OFFSETY, 0, rtnText) Then .LaserTestZOffsetY = CInt(rtnText)
                End With
                With m_Variable.Workholder
                    If CXmler.GetXmlData(stemNode, MCS_VARIABLE_WORKHOLDER_CCDRATIOX, 0, rtnText) Then .CCDRatioX = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_VARIABLE_WORKHOLDER_CCDRATIOY, 0, rtnText) Then .CCDRatioY = CInt(rtnText)
                End With


                With m_Idx.System
                    If CXmler.GetXmlData(stemNode, MCS_IDX_SYSTEM_SOLDERIDX, 0, rtnText) Then .SolderIdx = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, MCS_IDX_SYSTEM_SOLDERLASERIDX, 0, rtnText) Then .SolderLaserIdx = CInt(rtnText)
                End With
            End If
            ReadDataFromFile = True
        Catch ex As Exception

        End Try
    End Function

    Public Function WriteDataToFile(ByVal FilePath As String, ByVal machineFilePath As String) As Boolean
        WriteDataToFile = False
        Try
            Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim nodeAttributes As New Dictionary(Of String, String)
            Call nodeAttributes.Add("Attributes", "")
            Dim stemNode As System.Xml.XmlElement

            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, "Parameter", 0, nodeAttributes), System.Xml.XmlElement)

            'With m_Idx.System
            '    Call CXmler.NewXmlValue(stemNode, "Idx_PieceIn", 0, .PieceIn)
            '    Call CXmler.NewXmlValue(stemNode, "Idx_PieceOK", 0, .PieceOK)
            '    Call CXmler.NewXmlValue(stemNode, "Idx_PieceNoGood", 0, .PieceNoGood)
            'End With


            With m_Pos.Workholder
                'Call CXmler.NewXmlValue(stemNode, "", 0, .AlignX)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_ALIGNY, 0, .AlignY)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateOutX1, 0, .SubstrateOutX1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateOutY1, 0, .SubstrateOutY1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateInX1, 0, .SubstrateInX1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_SubstrateInY1, 0, .SubstrateInY1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_IMAGEALIGNT, 0, .ImageAlignT)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_PATTERNALIGNX1, 0, .PatternAlignX1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_PATTERNALIGNY1, 0, .PatternAlignY1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_PATTERNALIGNX2, 0, .PatternAlignX2)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_PATTERNALIGNY2, 0, .PatternAlignY2)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNX1, 0, .EdgeAlignX1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNY1, 0, .EdgeAlignY1)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNX2, 0, .EdgeAlignX2)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNY2, 0, .EdgeAlignY2)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNX3, 0, .EdgeAlignX3)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNY3, 0, .EdgeAlignY3)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNX4, 0, .EdgeAlignX4)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_EDGEALIGNY4, 0, .EdgeAlignY4)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERFIRSTT, 0, .LaserSetFirstT)

                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_FIRST_X, 0, .LaserTestX)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_FIRST_Y, 0, .LaserTestY)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_FIRST_T, 0, .LaserTestT)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_DIVIDE_T_DISTANCE, 0, .DivideTDistance)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_JUMPDISTANCE, 0, .JumpDistance)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_SCRIBECOUNT, 0, .ScribeCount)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_SCRIBEDISTANCE, 0, .ScribeDistance)
                'Call CXmler.NewXmlValue(stemNode, MCS_POS_WORKHOLDER_LASERTEST_SCRIBEDIRECTION, 0, .ScribeDirection)

                Call CXmler.NewXmlValue(stemNode, MCS_POS_LASERTESTZ_OFFSETX, 0, .LaserTestZOffsetX)
                Call CXmler.NewXmlValue(stemNode, MCS_POS_LASERTESTZ_OFFSETY, 0, .LaserTestZOffsetY)
            End With





            'With m_Variable.Laser
            '    Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_LASER_PINHOLEDEFLEFTX, 0, .PinHoleDefLeftX)
            '    Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_LASER_PINHOLEDEFLEFTY, 0, .PinHoleDefLeftY)
            '    Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_LASER_PINHOLEDEFRIGHTX, 0, .PinHoleDefRightX)
            '    Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_LASER_PINHOLEDEFRIGHTY, 0, .PinHoleDefRightY)
            'End With
            'With m_Variable.System
            '    Call CXmler.NewXmlValue(stemNode, "VARIABLE_System_SettingLength", 0, .SettingLength)
            '    Call CXmler.NewXmlValue(stemNode, "VARIABLE_System_RealLength", 0, .RealLength)

            '    Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_SYSTEM_MACHINENAME, 0, .MachineName)
            'End With




            With m_Variable.Workholder
                Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_CCDRATIOX, 0, .CCDRatioX)
                Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_CCDRATIOY, 0, .CCDRatioY)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetXMatch, 0, .LaserOrgCCDOffsetXMatch)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetYMatch, 0, .LaserOrgCCDOffsetYMatch)

                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETXEDGE, 0, .LaserOrgCCDOffsetXEdge)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETYEDGE, 0, .LaserOrgCCDOffsetYEdge)

                'Call CXmler.NewXmlValue(stemNode, "VARIABLE_WORKHOLDER_OrthogonalModify", 0, .OrthogonalModify)

                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_BALLSCREWPITCH, 0, .BallScrewPitch)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_RADIUS, 0, .Radius)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_PULSEPERCOUNT, 0, .PulsePerCount)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_IMAGEERROR, 0, .ImageError)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_IMAGEERRORBIGGESTDEGREE, 0, .ImageErrorBiggestDegree)
            End With

            With m_Idx.System
                Call CXmler.NewXmlValue(stemNode, MCS_IDX_SYSTEM_SOLDERIDX, 0, .SolderIdx)
                Call CXmler.NewXmlValue(stemNode, MCS_IDX_SYSTEM_SOLDERLASERIDX, 0, .SolderLaserIdx)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetXMatch, 0, .LaserOrgCCDOffsetXMatch)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LaserOrgCCDOffsetYMatch, 0, .LaserOrgCCDOffsetYMatch)

                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETXEDGE, 0, .LaserOrgCCDOffsetXEdge)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_LASERORGCCDOFFSETYEDGE, 0, .LaserOrgCCDOffsetYEdge)

                'Call CXmler.NewXmlValue(stemNode, "VARIABLE_WORKHOLDER_OrthogonalModify", 0, .OrthogonalModify)

                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_BALLSCREWPITCH, 0, .BallScrewPitch)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_RADIUS, 0, .Radius)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_PULSEPERCOUNT, 0, .PulsePerCount)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_IMAGEERROR, 0, .ImageError)
                'Call CXmler.NewXmlValue(stemNode, MCS_VARIABLE_WORKHOLDER_IMAGEERRORBIGGESTDEGREE, 0, .ImageErrorBiggestDegree)
            End With




            Call xmlDoc.Save(FilePath)
            WriteDataToFile = True




        Catch ex As Exception

        End Try

    End Function

#Region "Property"
    Public Property Flags() As CFlags
        Get
            Return m_flags
        End Get
        Set(ByVal value As CFlags)

            m_flags = value

        End Set
    End Property

    Public Property Pos() As CPosition
        Get
            Return m_Pos
        End Get
        Set(ByVal value As CPosition)

            m_Pos = value

        End Set
    End Property
    Public Property Idx() As CIdx
        Get
            Return m_Idx
        End Get
        Set(ByVal value As CIdx)
            m_Idx = value
        End Set
    End Property

    Public Property Count() As CCount
        Get
            Return m_Count
        End Get
        Set(ByVal value As CCount)
            m_Count = value
        End Set
    End Property

    Public Property Time() As CTime
        Get
            Return m_Time
        End Get
        Set(ByVal value As CTime)

            m_Time = value

        End Set
    End Property

    Public Property Variable() As CVariable
        Get
            Return m_Variable
        End Get
        Set(ByVal value As CVariable)

            m_Variable = value

        End Set
    End Property

    Public Property Speed() As CSpeed
        Get
            Return m_Speed
        End Get
        Set(ByVal value As CSpeed)

            m_Speed = value

        End Set
    End Property
#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class
Public Enum enumKeyConst
    KeyNo
    KeyStop
    KeyMainStart
    KeyMainRestart
    KeyMainExit
    KeyParameterSetting
    KeyGeneralSetting
    KeyRecorderSetting
    KeyErrRecorderSetting
    KeyLoaderPositionSetting
    KeyVisionPositionSetting
    KeyCameraMenu
    KeyLaserParameter
    KeyIOSetting
    KeyLaserSetting
End Enum
Public Enum enumSys
    MainCtl
    Top
    Workholder
    Maximum
End Enum
Public Enum enumAxis
    WorkholderX = 0
    WorkholderY = 1
    WorkholderZ = 2
    FeederZ = 3
    Maximum = 4
End Enum
Public Class CFlags
    Private m_Pause As CFlagsPause
    Private m_System As CFlagsSystem
    Private m_Workholder As CFlagsWorkholder
    Public Sub New()
        If m_Pause Is Nothing Then m_Pause = New CFlagsPause
        If m_System Is Nothing Then m_System = New CFlagsSystem
        If m_Workholder Is Nothing Then m_Workholder = New CFlagsWorkholder
    End Sub
    Protected Overrides Sub Finalize()

        m_Pause = Nothing
        m_System = Nothing
        m_Workholder = Nothing
        MyBase.Finalize()

    End Sub

    Public Property Pause() As CFlagsPause
        Get
            Return m_Pause
        End Get
        Set(ByVal value As CFlagsPause)

            m_Pause = value

        End Set
    End Property

    Public Property System() As CFlagsSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CFlagsSystem)

            m_System = value

        End Set
    End Property

    Public Property Workholder() As CFlagsWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CFlagsWorkholder)
            m_Workholder = value
        End Set
    End Property
End Class
Public Class CPosition
    Public Sub New()
        If m_Workholder Is Nothing Then m_Workholder = New CPositionWH
        If m_Focus Is Nothing Then m_Focus = New CPositionFocusZ
    End Sub
    Protected Overrides Sub Finalize()
        m_Workholder = Nothing
        m_Focus = Nothing
        Call MyBase.Finalize()
    End Sub
    Private m_Workholder As CPositionWH
    Public Property Workholder() As CPositionWH
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CPositionWH)
            m_Workholder = value
        End Set
    End Property
    Private m_Focus As CPositionFocusZ
    Public Property Focus() As CPositionFocusZ
        Get
            Return m_Focus
        End Get
        Set(ByVal value As CPositionFocusZ)
            m_Focus = value
        End Set
    End Property
End Class
Public Class CPositionWH
    Private m_AlignRealX As Double
    ''' <summary>
    ''' 基板原點視覺補正完後實際位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignRealX() As Double
        Get
            Return m_AlignRealX
        End Get
        Set(ByVal value As Double)
            m_AlignRealX = value
        End Set
    End Property
    Private m_AlignRealY As Double
    ''' <summary>
    ''' 基板原點視覺補正完後實際位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignRealY() As Double
        Get
            Return m_AlignRealY
        End Get
        Set(ByVal value As Double)
            m_AlignRealY = value
        End Set
    End Property
    Private m_AlignX As Double
    ''' <summary>
    ''' 基版原點對應雷射原點位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignX() As Double
        Get
            Return m_AlignX
        End Get
        Set(ByVal value As Double)
            m_AlignX = value
        End Set
    End Property
    Private m_AlignY As Double
    ''' <summary>
    ''' 基版原點對應雷射原點位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AlignY() As Double
        Get
            Return m_AlignY
        End Get
        Set(ByVal value As Double)
            m_AlignY = value
        End Set
    End Property
    Private m_SubstrateInX1 As Double
    ''' <summary>
    ''' 基版供料位置 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInX1() As Double
        Get
            Return m_SubstrateInX1
        End Get
        Set(ByVal value As Double)
            m_SubstrateInX1 = value
        End Set
    End Property
    Private m_SubstrateInY1 As Double
    ''' <summary>
    ''' 基版供料位置 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInY1() As Double
        Get
            Return m_SubstrateInY1
        End Get
        Set(ByVal value As Double)
            m_SubstrateInY1 = value
        End Set
    End Property
    Private m_SubstrateOutX1 As Double
    ''' <summary>
    ''' 基版退料位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateOutX1() As Double
        Get
            Return m_SubstrateOutX1
        End Get
        Set(ByVal value As Double)
            m_SubstrateOutX1 = value
        End Set
    End Property
    Private m_SubstrateOutY1 As Double
    ''' <summary>
    ''' 基版退料位置 
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateOutY1() As Double
        Get
            Return m_SubstrateOutY1
        End Get
        Set(ByVal value As Double)
            m_SubstrateOutY1 = value
        End Set
    End Property
    Private m_ImageAlignT As Double
    ''' <summary>
    ''' 基版視覺定位初始位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignT() As Double
        Get
            Return m_ImageAlignT
        End Get
        Set(ByVal value As Double)
            m_ImageAlignT = value
        End Set
    End Property
    Private m_PatternAlignX1 As Double
    ''' <summary>
    ''' 基版視覺樣板比對左邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignX1() As Double
        Get
            Return m_PatternAlignX1
        End Get
        Set(ByVal value As Double)
            m_PatternAlignX1 = value
        End Set
    End Property
    Private m_PatternAlignY1 As Double
    ''' <summary>
    ''' 基版視覺樣板比對左邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignY1() As Double
        Get
            Return m_PatternAlignY1
        End Get
        Set(ByVal value As Double)
            m_PatternAlignY1 = value
        End Set
    End Property
    Private m_PatternAlignX2 As Double
    ''' <summary>
    ''' 基版視覺樣板比對右邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignX2() As Double
        Get
            Return m_PatternAlignX2
        End Get
        Set(ByVal value As Double)
            m_PatternAlignX2 = value
        End Set
    End Property
    Private m_PatternAlignY2 As Double
    ''' <summary>
    ''' 基版視覺樣板比對右邊孔位位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternAlignY2() As Double
        Get
            Return m_PatternAlignY2
        End Get
        Set(ByVal value As Double)
            m_PatternAlignY2 = value
        End Set
    End Property
    Private m_EdgeAlignX1 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignX1() As Double
        Get
            Return m_EdgeAlignX1
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignX1 = value
        End Set
    End Property
    Private m_EdgeAlignY1 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignY1() As Double
        Get
            Return m_EdgeAlignY1
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignY1 = value
        End Set
    End Property
    Private m_EdgeAlignX2 As Double
    ''' <summary>
    ''' 基版視覺版邊比對右邊水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignX2() As Double
        Get
            Return m_EdgeAlignX2
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignX2 = value
        End Set
    End Property
    Private m_EdgeAlignY2 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊水平位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignY2() As Double
        Get
            Return m_EdgeAlignY2
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignY2 = value
        End Set
    End Property
    Private m_EdgeAlignX3 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignX3() As Double
        Get
            Return m_EdgeAlignX3
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignX3 = value
        End Set
    End Property
    Private m_EdgeAlignY3 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignY3() As Double
        Get
            Return m_EdgeAlignY3
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignY3 = value
        End Set
    End Property
    Private m_EdgeAlignX4 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignX4() As Double
        Get
            Return m_EdgeAlignX4
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignX4 = value
        End Set
    End Property

    Private m_EdgeAlignY4 As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EdgeAlignY4() As Double
        Get
            Return m_EdgeAlignY4
        End Get
        Set(ByVal value As Double)
            m_EdgeAlignY4 = value
        End Set
    End Property





    Private m_LaserTestX As Double
    ''' <summary>
    ''' 雷射測試切割FirstX
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserTestX() As Double
        Get
            Return m_LaserTestX
        End Get
        Set(ByVal value As Double)
            m_LaserTestX = value
        End Set
    End Property

    Private m_LaserTestY As Double
    ''' <summary>
    '''  雷射測試切割FirstY
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserTestY() As Double
        Get
            Return m_LaserTestY
        End Get
        Set(ByVal value As Double)
            m_LaserTestY = value
        End Set
    End Property


    Private m_LaserTestT As Double
    ''' <summary>
    '''  雷射測試切割FirstT
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserTestT() As Double
        Get
            Return m_LaserTestT
        End Get
        Set(ByVal value As Double)
            m_LaserTestT = value
        End Set
    End Property

    Private m_LaserSetFirstT As Double
    ''' <summary>
    '''  雷射測試切割FirstT
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserSetFirstT() As Double
        Get
            Return m_LaserSetFirstT
        End Get
        Set(ByVal value As Double)
            m_LaserSetFirstT = value
        End Set
    End Property

    Private m_DivideTDistance As Double
    ''' <summary>
    ''' 雷射測試切割T軸切割長度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property DivideTDistance() As Double
        Get
            Return m_DivideTDistance
        End Get
        Set(ByVal value As Double)
            m_DivideTDistance = value
        End Set
    End Property

    Private m_JumpDistance As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JumpDistance() As Double
        Get
            Return m_JumpDistance
        End Get
        Set(ByVal value As Double)
            m_JumpDistance = value
        End Set
    End Property

    Private m_ScribeCount As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ScribeCount() As Double
        Get
            Return m_ScribeCount
        End Get
        Set(ByVal value As Double)
            m_ScribeCount = value
        End Set
    End Property

    Private m_ScribeDistance As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ScribeDistance() As Double
        Get
            Return m_ScribeDistance
        End Get
        Set(ByVal value As Double)
            m_ScribeDistance = value
        End Set
    End Property
    Private m_ScribeDirection As Double
    ''' <summary>
    ''' 基版視覺版邊比對左邊垂直位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ScribeDirection() As Double
        Get
            Return m_ScribeDirection
        End Get
        Set(ByVal value As Double)
            m_ScribeDirection = value
        End Set
    End Property

    Private m_LaserTestZOffsetX As Double
    ''' <summary>
    ''' 雷射測試高度檯面距離
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserTestZOffsetX() As Double
        Get
            Return m_LaserTestZOffsetX
        End Get
        Set(ByVal value As Double)
            m_LaserTestZOffsetX = value
        End Set
    End Property

    Private m_LaserTestZOffsetY As Double
    ''' <summary>
    ''' 雷射測試高度檯面距離
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserTestZOffsetY() As Double
        Get
            Return m_LaserTestZOffsetY
        End Get
        Set(ByVal value As Double)
            m_LaserTestZOffsetY = value
        End Set
    End Property
End Class
Public Class CPositionFocusZ
    Private m_LaserFocusZ As Double
    ''' <summary>
    ''' 雷射加工面位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserFocusZ() As Double
        Get
            Return m_LaserFocusZ
        End Get
        Set(ByVal value As Double)
            m_LaserFocusZ = value
        End Set
    End Property
End Class
Public Class CIdx
    Private m_System As CIdxSystem
    Private m_Tray As CIdxTray

    Public Sub New()

        If m_System Is Nothing Then m_System = New CIdxSystem
        If m_Tray Is Nothing Then m_Tray = New CIdxTray

    End Sub

    Protected Overrides Sub Finalize()

        m_System = Nothing
        m_Tray = Nothing

        MyBase.Finalize()

    End Sub

    Public Property System() As CIdxSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CIdxSystem)
            m_System = value
        End Set
    End Property
    Public Property Tray() As CIdxTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CIdxTray)
            m_Tray = value
        End Set
    End Property
End Class
Public Class CIdxSystem
   

    ''' <summary>
    ''' Job索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_jobIdx As Integer
    ''' <summary>
    ''' 圖層索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_layIdx As Integer
    ''' <summary>
    ''' 幾何物件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_geoIdx As Integer
    ''' <summary>
    ''' 元件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_entityIdx As Integer
    ''' <summary>
    ''' 圖層切割次數
    ''' </summary>
    ''' <remarks></remarks>
    Private m_layCutCount As Integer

    ''' <summary>
    ''' Solder索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SolderIdx As Integer
    ''' <summary>
    ''' SolderLaser索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SolderLaserIdx As Integer

    Private m_ImageAlignmentRetry As Integer
    Private m_SubstrateIn As Integer
    Private m_PieceOK As Integer
    Private m_PieceNoGood As Integer

    Public Property JobIdx() As Integer
        Get
            Return m_jobIdx
        End Get
        Set(ByVal value As Integer)

            m_jobIdx = value

        End Set
    End Property

    Public Property LayIdx() As Integer
        Get
            Return m_layIdx
        End Get
        Set(ByVal value As Integer)

            m_layIdx = value

        End Set
    End Property

    Public Property GeoIdx() As Integer
        Get
            Return m_geoIdx
        End Get
        Set(ByVal value As Integer)

            m_geoIdx = value

        End Set
    End Property

    Public Property EntityIdx() As Integer
        Get
            Return m_entityIdx
        End Get
        Set(ByVal value As Integer)
            m_entityIdx = value
        End Set
    End Property

    Public Property LayCutCount() As Integer
        Get
            Return m_layCutCount
        End Get
        Set(ByVal value As Integer)

            m_layCutCount = value

        End Set
    End Property

    Private m_PieceIn As Integer
    ''' <summary>
    ''' 從料盒進料的片數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PieceIn() As Integer
        Get
            Return m_PieceIn
        End Get
        Set(ByVal value As Integer)
            m_PieceIn = value
        End Set
    End Property

    Public Property PieceOK() As Integer
        Get
            Return m_PieceOK
        End Get
        Set(ByVal value As Integer)
            m_PieceOK = value
        End Set
    End Property

    Public Property PieceNoGood() As Integer
        Get
            Return m_PieceNoGood
        End Get
        Set(ByVal value As Integer)
            m_PieceNoGood = value
        End Set
    End Property
    Private m_PieceIn1stTest As Integer
    ''' <summary>
    ''' 首件暫停機制
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PieceIn1stTest() As Integer
        Get
            Return m_PieceIn1stTest
        End Get
        Set(ByVal value As Integer)
            m_PieceIn1stTest = value
        End Set
    End Property

    Public Property ImageAlignmentRetry() As Integer
        Get
            Return m_ImageAlignmentRetry
        End Get
        Set(ByVal value As Integer)
            m_ImageAlignmentRetry = value
        End Set
    End Property
    Private m_ImageAlignmentContError As Integer
    Public Property ImageAlignmentContError() As Integer
        Get
            Return m_ImageAlignmentContError
        End Get
        Set(ByVal value As Integer)
            m_ImageAlignmentContError = value
        End Set
    End Property
    Private m_ImageAlignmentAllError As Integer
    Public Property ImageAlignmentAllError() As Integer
        Get
            Return m_ImageAlignmentAllError
        End Get
        Set(ByVal value As Integer)
            m_ImageAlignmentAllError = value
        End Set
    End Property


    Public Property SolderIdx() As Integer
        Get
            Return m_SolderIdx
        End Get
        Set(ByVal value As Integer)
            m_SolderIdx = value
        End Set
    End Property
    Public Property SolderLaserIdx() As Integer
        Get
            Return m_SolderLaserIdx
        End Get
        Set(ByVal value As Integer)
            m_SolderLaserIdx = value
        End Set
    End Property

End Class
Public Class CIdxTray
    Private m_SubstrateInNG As Integer
    ''' <summary>
    ''' 供料供料連續失敗次數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInNG() As Integer
        Get
            Return m_SubstrateInNG
        End Get
        Set(ByVal value As Integer)
            m_SubstrateInNG = value
        End Set
    End Property
End Class
Public Class CCount
    Private m_System As CCountSystem
    Private m_Tray As CCountTray
    Private m_Workholder As CCountWorkholder


    Public Sub New()

        If m_System Is Nothing Then m_System = New CCountSystem
        If m_Tray Is Nothing Then m_Tray = New CCountTray
        If m_Workholder Is Nothing Then m_Workholder = New CCountWorkholder

    End Sub

    Protected Overrides Sub Finalize()

        m_System = Nothing
        m_Tray = Nothing
        m_Workholder = Nothing

        MyBase.Finalize()

    End Sub

    Public Property System() As CCountSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CCountSystem)
            m_System = value
        End Set
    End Property
    Public Property Tray() As CCountTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CCountTray)
            m_Tray = value
        End Set
    End Property
    Public Property Workholder() As CCountWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CCountWorkholder)
            m_Workholder = value
        End Set
    End Property
End Class
Public Class CCountSystem
    ''' <summary>
    ''' 圖層索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_layIdx As Integer
    ''' <summary>
    ''' 幾何物件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_geoIdx As Integer
    ''' <summary>
    ''' 元件索引值
    ''' </summary>
    ''' <remarks></remarks>
    Private m_entityIdx As Integer

    Private m_ImageAlignmentRetry As Integer
    Private m_SubstrateIn As Integer

    Public Property LayIdx() As Integer
        Get
            Return m_layIdx
        End Get
        Set(ByVal value As Integer)

            m_layIdx = value

        End Set
    End Property

    Public Property GeoIdx() As Integer
        Get
            Return m_geoIdx
        End Get
        Set(ByVal value As Integer)

            m_geoIdx = value

        End Set
    End Property

    Public Property EntityIdx() As Integer
        Get
            Return m_entityIdx
        End Get
        Set(ByVal value As Integer)

            m_entityIdx = value

        End Set
    End Property
    Public Property ImageAlignmentRetry() As Integer
        Get
            Return m_ImageAlignmentRetry
        End Get
        Set(ByVal value As Integer)
            m_ImageAlignmentRetry = value
        End Set
    End Property
End Class

Public Class CCountTray
    ''' <summary>
    ''' 工作片數設定
    ''' </summary>
    ''' <remarks></remarks>
    Private m_PieceToStop As Integer

    Private m_MaxOutNumber As Integer

    Private m_MaxInNumber As Integer
    ''' <summary>
    ''' 收料NG數量上限
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SubstrateOutNGMax As Integer
    ''' <summary>
    ''' 工作片數設定
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    ''' 
    Public Property PieceToStop() As Integer
        Get
            Return m_PieceToStop
        End Get
        Set(ByVal value As Integer)
            m_PieceToStop = value
        End Set
    End Property

    Public Property MaxOutNumber() As Integer
        Get
            Return m_MaxOutNumber
        End Get
        Set(ByVal value As Integer)
            m_MaxOutNumber = value
        End Set
    End Property
    Public Property MaxInNumber() As Integer
        Get
            Return m_MaxInNumber
        End Get
        Set(ByVal value As Integer)
            m_MaxInNumber = value
        End Set
    End Property
    ''' <summary>
    ''' 收料NG數量上限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateOutNGMax() As Integer
        Get
            Return m_SubstrateOutNGMax
        End Get
        Set(ByVal value As Integer)
            m_SubstrateOutNGMax = value
        End Set
    End Property


    Private m_SubstrateInNGMax As Integer
    ''' <summary>
    ''' 進料NG數量上限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInNGMax() As Integer
        Get
            Return m_SubstrateInNGMax
        End Get
        Set(ByVal value As Integer)
            m_SubstrateInNGMax = value
        End Set
    End Property
End Class

Public Class CCountWorkholder
    ''' <summary>
    ''' 影像定位最大補償次數
    ''' </summary>
    ''' <remarks></remarks>
    Private m_ImageAlignmentRetryMax As Integer
    ''' <summary>
    ''' 影像定位最大補償次數
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageAlignmentRetryMax() As Integer
        Get
            Return m_ImageAlignmentRetryMax
        End Get
        Set(ByVal value As Integer)
            m_ImageAlignmentRetryMax = value
        End Set
    End Property
End Class


Public Class CFlagsPause
    Private m_EmergencyStop As Boolean
    ''' <summary>
    ''' 緊急停止
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EmergencyStop() As Boolean
        Get
            Return m_EmergencyStop
        End Get
        Set(ByVal value As Boolean)
            m_EmergencyStop = value
        End Set
    End Property
    Private m_MaunalStop As Boolean
    ''' <summary>
    ''' 立即停止
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MaunalStop() As Boolean
        Get
            Return m_MaunalStop
        End Get
        Set(ByVal value As Boolean)
            m_MaunalStop = value
        End Set
    End Property
    Private m_StopFeedSubstrate As Boolean
    ''' <summary>
    ''' 停止繼續供料
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property StopFeedSubstrate() As Boolean
        Get
            Return m_StopFeedSubstrate
        End Get
        Set(ByVal value As Boolean)
            m_StopFeedSubstrate = value
        End Set
    End Property
    Private m_SysTopFinished As Boolean
    ''' <summary>
    ''' 供料禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysTopFinished() As Boolean
        Get
            Return m_SysTopFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysTopFinished = value
        End Set
    End Property
    Private m_SysSubstrateFinished As Boolean
    ''' <summary>
    ''' 供料禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysSubstrateFinished() As Boolean
        Get
            Return m_SysSubstrateFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysSubstrateFinished = value
        End Set
    End Property
    Private m_SysTrayInFinished As Boolean
    ''' <summary>
    ''' 收料禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysTrayInFinished() As Boolean
        Get
            Return m_SysTrayInFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysTrayInFinished = value
        End Set
    End Property
    Private m_SysTrayOutFinished As Boolean
    ''' <summary>
    ''' 收料禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysTrayOutFinished() As Boolean
        Get
            Return m_SysTrayOutFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysTrayOutFinished = value
        End Set
    End Property
    Private m_SysWorkholderFinished As Boolean
    ''' <summary>
    ''' 平台禁止中途停止動作
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysWorkholderFinished() As Boolean
        Get
            Return m_SysWorkholderFinished
        End Get
        Set(ByVal value As Boolean)
            m_SysWorkholderFinished = value
        End Set
    End Property
    Private m_WaitStop As Boolean
    ''' <summary>
    ''' 等待停止
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WaitStop() As Boolean
        Get
            Return m_WaitStop
        End Get
        Set(ByVal value As Boolean)
            m_WaitStop = value
        End Set
    End Property
End Class
Public Class CFlagsSystem
    Private m_KeyCode As enumKeyConst
    Private m_MatchingTooled As Boolean
    Private m_ProductLoaded As Boolean
    Private m_SysInitHomeOk As Boolean
    Private m_AutoRunProcedure As Boolean
    Private m_VaccumLaerScribeChecked As Boolean
    Private m_ManualSubstrateIn As Boolean

    Private m_Is1stCalibration As Boolean
    ''' <summary>
    ''' 首件測試
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Is1stCalibration() As Boolean
        Get
            Return m_Is1stCalibration
        End Get
        Set(ByVal value As Boolean)
            m_Is1stCalibration = value
        End Set
    End Property

    Private m_AutoSacle As Boolean
    Public Property AutoSacle() As Boolean
        Get
            Return m_AutoSacle
        End Get
        Set(ByVal value As Boolean)
            m_AutoSacle = value
        End Set
    End Property

    ''' <summary>
    ''' 自動生產是否能中斷
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property KeyCode() As enumKeyConst
        Get
            Return m_KeyCode
        End Get
        Set(ByVal value As enumKeyConst)
            m_KeyCode = value
        End Set
    End Property

    ''' <summary>
    ''' 使用樣板比對
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PatternMatched() As Boolean
        Get
            Return m_MatchingTooled
        End Get
        Set(ByVal value As Boolean)
            m_MatchingTooled = value
        End Set
    End Property
    Private m_VisionAligned As Boolean
    ''' <summary>
    ''' 使用Vision
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VisionAligned() As Boolean
        Get
            Return m_VisionAligned
        End Get
        Set(ByVal value As Boolean)
            m_VisionAligned = value
        End Set
    End Property
    Private m_MachineType As Integer
    ''' <summary>
    ''' 機器型號
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property MachineType() As Integer
        Get
            Return m_MachineType
        End Get
        Set(ByVal value As Integer)
            m_MachineType = value
        End Set
    End Property

    ''' <summary>
    ''' 已正確讀入生產檔案
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ProductLoaded() As Boolean
        Get
            Return m_ProductLoaded
        End Get
        Set(ByVal value As Boolean)
            m_ProductLoaded = value
        End Set
    End Property
    ''' <summary>
    ''' 正常復歸完畢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SysInitHomeOk() As Boolean
        Get
            Return m_SysInitHomeOk
        End Get
        Set(ByVal value As Boolean)

            m_SysInitHomeOk = value

        End Set
    End Property
    Public Property AutoRunProcedure() As Boolean
        Get
            Return m_AutoRunProcedure
        End Get
        Set(ByVal value As Boolean)
            m_AutoRunProcedure = value
        End Set
    End Property
    ''' <summary>
    ''' 切割時透過平台真空檢查有無破片
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property VaccumLaerScribeChecked() As Boolean
        Get
            Return m_VaccumLaerScribeChecked
        End Get
        Set(ByVal value As Boolean)
            m_VaccumLaerScribeChecked = value
        End Set
    End Property

    ''' <summary>
    ''' 手動模式
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ManualSubstrateIn() As Boolean
        Get
            Return m_ManualSubstrateIn
        End Get
        Set(ByVal value As Boolean)
            m_ManualSubstrateIn = value
        End Set
    End Property

    Private m_PieceLog As Boolean
    ''' <summary>
    ''' 使用PieceLog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PieceLog() As Boolean
        Get
            Return m_PieceLog
        End Get
        Set(ByVal value As Boolean)
            m_PieceLog = value
        End Set
    End Property
    Private m_PiecePosLog As Boolean
    ''' <summary>
    ''' 使用PiecePosLog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PiecePosLog() As Boolean
        Get
            Return m_PiecePosLog
        End Get
        Set(ByVal value As Boolean)
            m_PiecePosLog = value
        End Set
    End Property

    Private m_AngleChecked As Boolean
    ''' <summary>
    ''' 使用PieceLog
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property AngleChecked() As Boolean
        Get
            Return m_AngleChecked
        End Get
        Set(ByVal value As Boolean)
            m_AngleChecked = value
        End Set
    End Property


    Private m_WorkholderVaccumSecond As Boolean
    ''' <summary>
    ''' 使用二段平台真空
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property WorkholderVaccumSecond() As Boolean
        Get
            Return m_WorkholderVaccumSecond
        End Get
        Set(ByVal value As Boolean)
            m_WorkholderVaccumSecond = value
        End Set
    End Property
End Class
Public Class CFlagsWorkholder
    Private m_CircleMapUsed(0 To 16) As Boolean
    Public Property CircleMapUsed(ByVal Idx As Integer) As Boolean
        Get
            Return m_CircleMapUsed(Idx)
        End Get
        Set(ByVal value As Boolean)

            m_CircleMapUsed(Idx) = value

        End Set
    End Property


    Public ReadOnly Property CircleMapUsed() As Boolean()
        Get
            Return m_CircleMapUsed
        End Get
    End Property

    Private m_LoaderCanUse As Boolean
    ''' <summary>
    ''' 可使用移載
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LoaderCanUse() As Boolean
        Get
            Return m_LoaderCanUse
        End Get
        Set(ByVal value As Boolean)
            m_LoaderCanUse = value
        End Set
    End Property
    Private m_TopIsFinal As Boolean
    ''' <summary>
    ''' 供料最後一片
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TopIsFinal() As Boolean
        Get
            Return m_TopIsFinal
        End Get
        Set(ByVal value As Boolean)
            m_TopIsFinal = value
        End Set
    End Property

    Private m_TopIsNG As Boolean
    ''' <summary>
    ''' 收料NG
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property TopIsNG() As Boolean
        Get
            Return m_TopIsNG
        End Get
        Set(ByVal value As Boolean)
            m_TopIsNG = value
        End Set
    End Property

    Private m_ShowCut As Boolean
    ''' <summary>
    ''' 顯示目前切割的idx
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ShowCut() As Boolean
        Get
            Return m_ShowCut
        End Get
        Set(ByVal value As Boolean)
            m_ShowCut = value
        End Set
    End Property





End Class
Public Class CTime
    Private m_Laser As CTimeLaser
    Private m_Tray As CTimeTray
    Private m_Workholder As CTimeWorkholder
    Private m_System As CTimeSystem

    Public Sub New()
        If m_Laser Is Nothing Then m_Laser = New CTimeLaser
        If m_Tray Is Nothing Then m_Tray = New CTimeTray
        If m_Workholder Is Nothing Then m_Workholder = New CTimeWorkholder
        If m_System Is Nothing Then m_System = New CTimeSystem
    End Sub

    Protected Overrides Sub Finalize()
        m_Laser = Nothing
        m_Tray = Nothing
        m_Workholder = Nothing
        m_System = Nothing
        MyBase.Finalize()
    End Sub

    Public Property Laser() As CTimeLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CTimeLaser)
            m_Laser = value
        End Set
    End Property
    Public Property Tray() As CTimeTray
        Get
            Return m_Tray
        End Get
        Set(ByVal value As CTimeTray)
            m_Tray = value
        End Set
    End Property
    Public Property Workholder() As CTimeWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CTimeWorkholder)
            m_Workholder = value
        End Set
    End Property
    Public Property System() As CTimeSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CTimeSystem)
            m_System = value
        End Set
    End Property
End Class
Public Class CTimeLaser
    Private m_CalibrationStart As Double
    Private m_EmissionEnableStart As Double
    Private m_JumpStart As Double
    Private m_MarkStart As Double
    Private m_LaserOnDelayMiniSecond As Integer
    Private m_LaserOffDelayMiniSecond As Integer
    Private m_LaserON As Double
    Private m_LaserOnStart As Double

    ''' <summary>
    ''' 跳躍延遲 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_JumpDelayMiniSecond As Integer
    Private m_MarkDelayMiniSecond As Integer
    Private m_PolygonDelayMiniSecond As Integer
    Private m_LaserOnDelayMicroSecond As Integer
    Private m_LaserOffDelayMicroSecond As Integer
    Private m_JumpDelay10MicroSecond As Integer
    Private m_MarkDelay10MicroSecond As Integer
    Private m_PolygonDelay10MicroSecond As Integer

    Public Property CalibrationStart() As Double
        Get
            Return m_CalibrationStart
        End Get
        Set(ByVal value As Double)
            m_CalibrationStart = value
        End Set
    End Property
    ''' <summary>
    ''' 雷射致能開始時間,致能開始到可以擊發需經時120mini-second
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property EmissionEnableStart() As Double
        Get
            Return m_EmissionEnableStart
        End Get
        Set(ByVal value As Double)

            m_EmissionEnableStart = value

        End Set
    End Property
    ''' <summary>
    ''' 平台移動完畢
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JumpStart() As Double
        Get
            Return m_JumpStart
        End Get
        Set(ByVal value As Double)

            m_JumpStart = value

        End Set
    End Property
    Public Property MarkStart() As Double
        Get
            Return m_MarkStart
        End Get
        Set(ByVal value As Double)

            m_MarkStart = value

        End Set
    End Property
    Public Property LaserOnDelayMiniSecond() As Integer
        Get
            Return m_LaserOnDelayMiniSecond
        End Get
        Set(ByVal value As Integer)

            m_LaserOnDelayMiniSecond = value

        End Set
    End Property
    Public Property LaserOffDelayMiniSecond() As Integer
        Get
            Return m_LaserOffDelayMiniSecond
        End Get
        Set(ByVal value As Integer)

            m_LaserOffDelayMiniSecond = value

        End Set
    End Property

    ''' <summary>
    ''' 雷射擊發時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserON() As Double
        Get
            Return m_LaserON
        End Get
        Set(ByVal value As Double)
            m_LaserON = value
        End Set
    End Property
    ''' <summary>
    ''' 雷射開始擊發的時間
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOnStart() As Double
        Get
            Return m_LaserOnStart
        End Get
        Set(ByVal value As Double)
            m_LaserOnStart = value
        End Set
    End Property

    ''' <summary>
    ''' 跳躍延遲 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property JumpDelayMiniSecond() As Integer
        Get
            Return m_JumpDelayMiniSecond
        End Get
        Set(ByVal value As Integer)
            m_JumpDelayMiniSecond = value
        End Set
    End Property
    Public Property MarkDelayMiniSecond() As Integer
        Get
            Return m_MarkDelayMiniSecond
        End Get
        Set(ByVal value As Integer)

            m_MarkDelayMiniSecond = value

        End Set
    End Property
    Public Property PolygonDelayMiniSecond() As Integer
        Get
            Return m_PolygonDelayMiniSecond
        End Get
        Set(ByVal value As Integer)

            m_PolygonDelayMiniSecond = value

        End Set
    End Property
    Public Property LaserOnDelayMicroSecond() As Integer
        Get
            Return m_LaserOnDelayMicroSecond
        End Get
        Set(ByVal value As Integer)

            m_LaserOnDelayMicroSecond = value

        End Set
    End Property
    Public Property LaserOffDelayMicroSecond() As Integer
        Get
            Return m_LaserOffDelayMicroSecond
        End Get
        Set(ByVal value As Integer)

            m_LaserOffDelayMicroSecond = value

        End Set
    End Property
    Public Property JumpDelay10MicroSecond() As Integer
        Get
            Return m_JumpDelay10MicroSecond
        End Get
        Set(ByVal value As Integer)

            m_JumpDelay10MicroSecond = value

        End Set
    End Property
    Public Property MarkDelay10MicroSecond() As Integer
        Get
            Return m_MarkDelay10MicroSecond
        End Get
        Set(ByVal value As Integer)

            m_MarkDelay10MicroSecond = value

        End Set
    End Property
    Public Property PolygonDelay10MicroSecond() As Integer
        Get
            Return m_PolygonDelay10MicroSecond
        End Get
        Set(ByVal value As Integer)

            m_PolygonDelay10MicroSecond = value

        End Set
    End Property
End Class

Public Class CTimeTray
#Region "Member"
    ''' <summary>
    ''' 供料馬達慢速下降時間 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SubstrateInDownDelayMiniSecond As Integer
    ''' <summary>
    ''' 供料供料時吹氣時間 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SubstrateInBlowDelayMiniSecond As Integer
    Private m_TrayTimeOut As Integer

    Private m_SubstrateInMoveDelay As Double

    Private m_SubstrateOutMoveDelay As Double
    Private m_SubstrateInVaccumDelayMiniSecond As Integer
    ''' <summary>
    ''' 第二平台停留時間 (ms)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SubstrateSecondWorkHolderStayTime As Integer

#End Region
#Region "Property"
    Public Property SubstrateInVaccumDelayMiniSecond() As Integer
        Get
            Return m_SubstrateInVaccumDelayMiniSecond
        End Get
        Set(ByVal value As Integer)
            m_SubstrateInVaccumDelayMiniSecond = value
        End Set
    End Property


    ''' <summary>
    ''' 供料馬達慢速下降時間 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInDownDelayMiniSecond() As Integer
        Get
            Return m_SubstrateInDownDelayMiniSecond
        End Get
        Set(ByVal value As Integer)
            m_SubstrateInDownDelayMiniSecond = value
        End Set
    End Property
    ''' <summary>
    ''' 供料供料時吹氣時間 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateInBlowDelayMiniSecond() As Integer
        Get
            Return m_SubstrateInBlowDelayMiniSecond
        End Get
        Set(ByVal value As Integer)
            m_SubstrateInBlowDelayMiniSecond = value
        End Set
    End Property
    Public Property TrayTimeOut() As Integer
        Get
            Return m_TrayTimeOut
        End Get
        Set(ByVal value As Integer)
            m_TrayTimeOut = value
        End Set
    End Property

    Public Property SubstrateInMoveDelay() As Double
        Get
            Return m_SubstrateInMoveDelay
        End Get
        Set(ByVal value As Double)
            m_SubstrateInMoveDelay = value
        End Set
    End Property
    Public Property SubstrateOutMoveDelay() As Double
        Get
            Return m_SubstrateOutMoveDelay
        End Get
        Set(ByVal value As Double)
            m_SubstrateOutMoveDelay = value
        End Set
    End Property

    ''' <summary>
    ''' 第二平台停留時間 (ms)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property SubstrateSecondWorkHolderStayTime() As Integer
        Get
            Return m_SubstrateSecondWorkHolderStayTime
        End Get
        Set(ByVal value As Integer)
            m_SubstrateSecondWorkHolderStayTime = value
        End Set
    End Property
#End Region
End Class

Public Class CTimeWorkholder
#Region "Member"
    Private m_MoveStart As Double
    Private m_VaccumStart As Double
    Private m_MoveStable As Integer

#End Region
#Region "Property"
    Public Property MoveStart() As Double
        Get
            Return m_MoveStart
        End Get
        Set(ByVal value As Double)
            m_MoveStart = value
        End Set
    End Property
    Public Property VaccumStart() As Double
        Get
            Return m_VaccumStart
        End Get
        Set(ByVal value As Double)
            m_VaccumStart = value
        End Set
    End Property
    Public Property MoveStable() As Integer
        Get
            Return m_MoveStable
        End Get
        Set(ByVal value As Integer)
            m_MoveStable = value
        End Set
    End Property

#End Region
End Class

Public Class CTimeSystem
#Region "Member"
    Private m_RecorderStart As Double
#End Region
#Region "Property"
    Public Property RecorderStart() As Double
        Get
            Return m_RecorderStart
        End Get
        Set(ByVal value As Double)
            m_RecorderStart = value
        End Set
    End Property
#End Region
End Class
Public Class CVariable
    Private m_Laser As CVariableLaser
    Private m_Workholder As CVariableWorkholder
    Private m_System As CVariableSystem
    Public Sub New()
        If m_Laser Is Nothing Then m_Laser = New CVariableLaser
        If m_Workholder Is Nothing Then m_Workholder = New CVariableWorkholder
        If m_System Is Nothing Then m_System = New CVariableSystem
    End Sub

    Protected Overrides Sub Finalize()
        m_Laser = Nothing
        m_Workholder = Nothing
        m_System = Nothing
        MyBase.Finalize()
    End Sub

    Public Property Laser() As CVariableLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CVariableLaser)
            m_Laser = value
        End Set
    End Property
    Public Property Workholder() As CVariableWorkholder
        Get
            Return m_Workholder
        End Get
        Set(ByVal value As CVariableWorkholder)
            m_Workholder = value
        End Set
    End Property
    Public Property System() As CVariableSystem
        Get
            Return m_System
        End Get
        Set(ByVal value As CVariableSystem)
            m_System = value
        End Set
    End Property
End Class
Public Class CVariableLaser

    Private m_PinHoleDefLeftX As Double
    ''' <summary>
    ''' 圖面定位孔位置,1象限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleDefLeftX() As Double
        Get
            Return m_PinHoleDefLeftX
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftX = value
        End Set
    End Property
    Private m_PinHoleDefLeftY As Double
    ''' <summary>
    ''' 圖面定位孔位置,1象限
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleDefLeftY() As Double
        Get
            Return m_PinHoleDefLeftY
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefLeftY = value
        End Set
    End Property
    Private m_PinHoleDefRightX As Double
    Public Property PinHoleDefRightX() As Double
        Get
            Return m_PinHoleDefRightX
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightX = value
        End Set
    End Property
    Private m_PinHoleDefRightY As Double
    Public Property PinHoleDefRightY() As Double
        Get
            Return m_PinHoleDefRightY
        End Get
        Set(ByVal value As Double)
            m_PinHoleDefRightY = value
        End Set
    End Property
End Class

Public Class CVariableWorkholder
    Private m_CCDRatioX As Double
    Private m_CCDRatioY As Double
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetXMatch As Double
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetYMatch As Double
    ''' <summary>
    ''' 尋邊影像中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetXEdge As Double
    ''' <summary>
    ''' 尋邊影像中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <remarks></remarks>
    Private m_LaserOrgCCDOffsetYEdge As Double

    'Private  m_MatchOrgOffsetX As Double
    'Private  m_MatchOrgOffsetY As Double
    'Private  m_MatchOrgErrorOffsetX As Double
    'Private  m_MatchOrgErrorOffsetY As Double
    Private m_OrthogonalModify As Double
    ''' <summary>
    ''' 非正交軸修正補償角度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property OrthogonalModify() As Double
        Get
            Return m_OrthogonalModify
        End Get
        Set(ByVal value As Double)
            m_OrthogonalModify = value
        End Set
    End Property

    Private m_BallScrewPitch As Integer
    Private m_Radius As Integer
    Private m_PulsePerCount As Integer
    Private m_ImageError As Integer

    Private m_PinHoleLeftX As Double
    Private m_PinHoleLeftY As Double
    Private m_PinHoleRightX As Double
    Private m_PinHoleRightY As Double
    Private m_PinHoleLeftX2 As Double
    Private m_PinHoleLeftY2 As Double
    Private m_PinHoleRightX2 As Double
    Private m_PinHoleRightY2 As Double

    Private m_PinHoleUpX As Double
    Private m_PinHoleUpY As Double
    Private m_PinHoleDownX As Double
    Private m_PinHoleDownY As Double

    Private m_ThetaRadCCW As Double
    Private m_ImageErrorBiggestDegree As Double

    Public Property CCDRatioX() As Double
        Get
            Return m_CCDRatioX
        End Get
        Set(ByVal value As Double)
            m_CCDRatioX = value
        End Set
    End Property
    Public Property CCDRatioY() As Double
        Get
            Return m_CCDRatioY
        End Get
        Set(ByVal value As Double)
            m_CCDRatioY = value
        End Set
    End Property
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetXMatch() As Double
        Get
            Return m_LaserOrgCCDOffsetXMatch
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetXMatch = value
        End Set
    End Property
    ''' <summary>
    ''' 樣版影像CCD中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetYMatch() As Double
        Get
            Return m_LaserOrgCCDOffsetYMatch
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetYMatch = value
        End Set
    End Property
    ''' <summary>
    ''' 尋邊影像中心至雷射原點水平方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetXEdge() As Double
        Get
            Return m_LaserOrgCCDOffsetXEdge
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetXEdge = value
        End Set
    End Property
    ''' <summary>
    ''' 尋邊影像中心至雷射原點垂直方向距離 (μm)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property LaserOrgCCDOffsetYEdge() As Double
        Get
            Return m_LaserOrgCCDOffsetYEdge
        End Get
        Set(ByVal value As Double)
            m_LaserOrgCCDOffsetYEdge = value
        End Set
    End Property

    '''' <summary>
    '''' 樣板比對結果中心偏差量
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Property MatchOrgOffsetX() As Double
    ' Get
    ' Return m_MatchOrgOffsetX
    ' End Get
    ' Set(ByVal value As Double)
    ' m_MatchOrgOffsetX = value
    ' End Set
    'End Property
    '''' <summary>
    '''' 樣板比對結果中心偏差量
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Property MatchOrgOffsetY() As Double
    ' Get
    ' Return m_MatchOrgOffsetY
    ' End Get
    ' Set(ByVal value As Double)
    ' m_MatchOrgOffsetY = value
    ' End Set
    'End Property
    '''' <summary>
    '''' 樣板比對教導導致中心偏差量
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Property MatchOrgErrorOffsetX() As Double
    ' Get
    ' Return m_MatchOrgErrorOffsetX
    ' End Get
    ' Set(ByVal value As Double)
    ' m_MatchOrgErrorOffsetX = value
    ' End Set
    'End Property
    '''' <summary>
    '''' 樣板比對教導導致中心偏差量
    '''' </summary>
    '''' <value></value>
    '''' <returns></returns>
    '''' <remarks></remarks>
    'Public Property MatchOrgErrorOffsetY() As Double
    ' Get
    ' Return m_MatchOrgErrorOffsetY
    ' End Get
    ' Set(ByVal value As Double)
    ' m_MatchOrgErrorOffsetY = value
    ' End Set
    'End Property

    Public Property BallScrewPitch() As Integer
        Get
            Return m_BallScrewPitch
        End Get
        Set(ByVal value As Integer)
            m_BallScrewPitch = value
        End Set
    End Property
    Public Property Radius() As Integer
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Integer)
            m_Radius = value
        End Set
    End Property
    Public Property PulsePerCount() As Integer
        Get
            Return m_PulsePerCount
        End Get
        Set(ByVal value As Integer)
            m_PulsePerCount = value
        End Set
    End Property
    Public Property ImageError() As Integer
        Get
            Return m_ImageError
        End Get
        Set(ByVal value As Integer)
            m_ImageError = value
        End Set
    End Property


    ''' <summary>
    ''' 視覺定位計算對位孔馬達位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleLeftX() As Double
        Get
            Return m_PinHoleLeftX
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftX = value
        End Set
    End Property
    ''' <summary>
    ''' 視覺定位計算對位孔馬達位置
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property PinHoleLeftY() As Double
        Get
            Return m_PinHoleLeftY
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftY = value
        End Set
    End Property
    Public Property PinHoleRightX() As Double
        Get
            Return m_PinHoleRightX
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightX = value
        End Set
    End Property
    Public Property PinHoleRightY() As Double
        Get
            Return m_PinHoleRightY
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightY = value
        End Set
    End Property
    Public Property PinHoleLeftX2() As Double
        Get
            Return m_PinHoleLeftX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftX2 = value
        End Set
    End Property
    Public Property PinHoleLeftY2() As Double
        Get
            Return m_PinHoleLeftY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleLeftY2 = value
        End Set
    End Property
    Public Property PinHoleRightX2() As Double
        Get
            Return m_PinHoleRightX2
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightX2 = value
        End Set
    End Property
    Public Property PinHoleRightY2() As Double
        Get
            Return m_PinHoleRightY2
        End Get
        Set(ByVal value As Double)
            m_PinHoleRightY2 = value
        End Set
    End Property
    Public Property PinHoleUpX() As Double
        Get
            Return m_PinHoleUpX
        End Get
        Set(ByVal value As Double)
            m_PinHoleUpX = value
        End Set
    End Property
    Public Property PinHoleUpY() As Double
        Get
            Return m_PinHoleUpY
        End Get
        Set(ByVal value As Double)
            m_PinHoleUpY = value
        End Set
    End Property
    Public Property PinHoleDownX() As Double
        Get
            Return m_PinHoleDownX
        End Get
        Set(ByVal value As Double)
            m_PinHoleDownX = value
        End Set
    End Property
    Public Property PinHoleDownY() As Double
        Get
            Return m_PinHoleDownY
        End Get
        Set(ByVal value As Double)
            m_PinHoleDownY = value
        End Set
    End Property

    ''' <summary>
    ''' 弧度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ThetaRadCCW() As Double
        Get
            Return m_ThetaRadCCW
        End Get
        Set(ByVal value As Double)
            m_ThetaRadCCW = value
        End Set
    End Property

    ''' <summary>
    ''' 允許視覺最大角度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property ImageErrorBiggestDegree() As Double
        Get
            Return m_ImageErrorBiggestDegree
        End Get
        Set(ByVal value As Double)
            m_ImageErrorBiggestDegree = value
        End Set
    End Property
End Class
Public Class CVariableSystem
    Private m_RealLength As Double
    Private m_SettingLength As Double
    Private m_AutoScale As Double

    Private m_MachineName As String

    Public Property AutoScale() As Double
        Get
            Return m_AutoScale
        End Get
        Set(ByVal value As Double)
            m_AutoScale = value
        End Set
    End Property
    Public Property RealLength() As Double
        Get
            Return m_RealLength
        End Get
        Set(ByVal value As Double)
            m_RealLength = value
        End Set
    End Property
    Public Property SettingLength() As Double
        Get
            Return m_SettingLength
        End Get
        Set(ByVal value As Double)
            m_SettingLength = value
        End Set
    End Property

    Public Property MachineName() As String
        Get
            Return m_MachineName
        End Get
        Set(ByVal value As String)
            m_MachineName = value
        End Set
    End Property
End Class
Public Class CSpeed
    Private m_Laser As CSpeedLaser
    Public Sub New()

        If m_Laser Is Nothing Then m_Laser = New CSpeedLaser

    End Sub

    Protected Overrides Sub Finalize()

        m_Laser = Nothing

        MyBase.Finalize()

    End Sub

    Public Property Laser() As CSpeedLaser
        Get
            Return m_Laser
        End Get
        Set(ByVal value As CSpeedLaser)

            m_Laser = value

        End Set
    End Property
End Class
Public Class CSpeedLaser
    Private m_TableJumpSpeed As Integer
    Public Property TableJumpSpeed() As Integer
        Get
            Return m_TableJumpSpeed
        End Get
        Set(ByVal value As Integer)
            m_TableJumpSpeed = value
        End Set
    End Property
    Private m_TableLineSpeed As Integer
    Public Property TableLineSpeed() As Integer
        Get
            Return m_TableLineSpeed
        End Get
        Set(ByVal value As Integer)
            m_TableLineSpeed = value
        End Set
    End Property
    Private m_TableAcceration As Integer
    Public Property TableAcceration() As Integer
        Get
            Return m_TableAcceration
        End Get
        Set(ByVal value As Integer)
            m_TableAcceration = value
        End Set
    End Property
    Private m_TableDeceration As Integer
    Public Property TableDeceration() As Integer
        Get
            Return m_TableDeceration
        End Get
        Set(ByVal value As Integer)
            m_TableDeceration = value
        End Set
    End Property
    Private m_TableTrasVelocity As Integer
    Public Property TableTrasVelocity() As Integer
        Get
            Return m_TableTrasVelocity
        End Get
        Set(ByVal value As Integer)
            m_TableTrasVelocity = value
        End Set
    End Property


    Private m_TableAccerationLimit As Integer
    Public Property TableAccerationLimit() As Integer
        Get
            Return m_TableAccerationLimit
        End Get
        Set(ByVal value As Integer)
            m_TableAccerationLimit = value
        End Set
    End Property
    Private m_TableDecerationLimit As Integer
    Public Property TableDecerationLimit() As Integer
        Get
            Return m_TableDecerationLimit
        End Get
        Set(ByVal value As Integer)
            m_TableDecerationLimit = value
        End Set
    End Property
    Private m_TableVelocityLimit As Integer
    Public Property TableVelocityLimit() As Integer
        Get
            Return m_TableVelocityLimit
        End Get
        Set(ByVal value As Integer)
            m_TableVelocityLimit = value
        End Set
    End Property

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class

Public Class CRegisterPosition
    Private m_ListRegisterPosition(0 To 15) As CRegisterPositionData
    Private m_ListRegisterGlobalAlignPosition(0 To 4) As CRegisterPositionData
    Private m_ListRegisterLocalAlignPosition(0 To 4) As CRegisterPositionData

    Public Property ListRegisterPosition As CRegisterPositionData()
        Get
            Return m_ListRegisterPosition
        End Get
        Set(ByVal value As CRegisterPositionData())
            m_ListRegisterPosition = value
        End Set
    End Property

    Public Property ListRegisterGlobalAlignPosition As CRegisterPositionData()
        Get
            Return m_ListRegisterGlobalAlignPosition
        End Get
        Set(ByVal value As CRegisterPositionData())
            m_ListRegisterGlobalAlignPosition = value
        End Set
    End Property

    Public Property ListRegisterLocalAlignPosition As CRegisterPositionData()
        Get
            Return m_ListRegisterLocalAlignPosition
        End Get
        Set(ByVal value As CRegisterPositionData())
            m_ListRegisterLocalAlignPosition = value
        End Set
    End Property

    Public Sub New()
        ReDim m_ListRegisterPosition(0 To 15)
        For i = 0 To 15
            m_ListRegisterPosition(i) = New CRegisterPositionData()
        Next

        ReDim m_ListRegisterGlobalAlignPosition(0 To 4)
        For i = 0 To 4
            m_ListRegisterGlobalAlignPosition(i) = New CRegisterPositionData()
        Next

        ReDim m_ListRegisterLocalAlignPosition(0 To 4)
        For i = 0 To 4
            m_ListRegisterLocalAlignPosition(i) = New CRegisterPositionData()
        Next

    End Sub
    Public Sub New(ByVal pListRegisterPosition As CRegisterPositionData(), ByVal pListRegisterGlobalAlignPosition As CRegisterPositionData(), ByVal pListRegisterLocalAlignPosition As CRegisterPositionData())
        Me.m_ListRegisterPosition = pListRegisterPosition

        Me.m_ListRegisterGlobalAlignPosition = pListRegisterGlobalAlignPosition

        Me.m_ListRegisterLocalAlignPosition = pListRegisterLocalAlignPosition

    End Sub
    Public Function Clone() As CRegisterPosition
        Try
            Dim reg(0 To Me.m_ListRegisterPosition.Length - 1) As CRegisterPositionData
            Dim reg1(0 To Me.m_ListRegisterGlobalAlignPosition.Length - 1) As CRegisterPositionData
            Dim reg2(0 To Me.m_ListRegisterLocalAlignPosition.Length - 1) As CRegisterPositionData

            For i = 0 To reg.Length - 1
                reg(i) = Me.m_ListRegisterPosition(i).Clone()
            Next

            For i = 0 To reg1.Length - 1
                reg1(i) = Me.m_ListRegisterGlobalAlignPosition(i).Clone()
            Next

            For i = 0 To reg2.Length - 1
                reg2(i) = Me.m_ListRegisterLocalAlignPosition(i).Clone()
            Next

            Dim res As CRegisterPosition = New CRegisterPosition(reg, reg1, reg2)
            Return res
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
Public Class CRegisterPositionData
    Private m_XAxis, m_YAxis, m_ZAxis, m_SAxis, m_RAxis As Double
    Private m_MotionSequence As eMotionSequence
    Public Property XAxis As Double
        Get
            Return m_XAxis
        End Get
        Set(ByVal value As Double)
            m_XAxis = value
        End Set
    End Property
    Public Property YAxis As Double
        Get
            Return m_YAxis
        End Get
        Set(ByVal value As Double)
            m_YAxis = value
        End Set
    End Property
    Public Property ZAxis As Double
        Get
            Return m_ZAxis
        End Get
        Set(ByVal value As Double)
            m_ZAxis = value
        End Set
    End Property
    Public Property SAxis As Double
        Get
            Return m_SAxis
        End Get
        Set(ByVal value As Double)
            m_SAxis = value
        End Set
    End Property
    Public Property RAxis As Double
        Get
            Return m_RAxis
        End Get
        Set(ByVal value As Double)
            m_RAxis = value
        End Set
    End Property
    Public Property MotionSequence As eMotionSequence
        Get
            Return m_MotionSequence
        End Get
        Set(ByVal value As eMotionSequence)
            m_MotionSequence = value
        End Set
    End Property
    Public Sub New()
        Me.m_XAxis = 0
        Me.m_YAxis = 0
        Me.m_ZAxis = 0
        Me.m_RAxis = 0
        Me.m_SAxis = 0
        Me.m_MotionSequence = 0
    End Sub
    Public Sub New(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pR As Double, ByVal pS As Double, ByVal pMotion As eMotionSequence)
        Me.m_XAxis = pX
        Me.m_YAxis = pY
        Me.m_ZAxis = pZ
        Me.m_RAxis = pR
        Me.m_SAxis = pS
        Me.m_MotionSequence = pMotion
    End Sub
    Public Sub New(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pMotion As eMotionSequence)
        Me.m_XAxis = pX
        Me.m_YAxis = pY
        Me.m_ZAxis = pZ
        Me.m_RAxis = 0
        Me.m_SAxis = 0
        Me.m_MotionSequence = pMotion
    End Sub
    Public Function Clone() As CRegisterPositionData
        Try
            Return New CRegisterPositionData(Me.XAxis, Me.YAxis, Me.ZAxis, Me.RAxis, Me.SAxis, Me.MotionSequence)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class


Public Class CAlignPosition
    Private m_ListAlignPosition(0 To 12) As CAlignPositionData
    Public Property ListRegisterPosition As CAlignPositionData()
        Get
            Return m_ListAlignPosition
        End Get
        Set(ByVal value As CAlignPositionData())
            m_ListAlignPosition = value
        End Set
    End Property
    Public Sub New()
        ReDim m_ListAlignPosition(0 To 12)
        For i = 0 To 12
            m_ListAlignPosition(i) = New CAlignPositionData()
        Next
    End Sub
    Public Sub New(ByVal pListAlignPosition As CAlignPositionData())
        Me.m_ListAlignPosition = pListAlignPosition
    End Sub
    Public Function Clone() As CAlignPosition
        Try
            Dim reg(0 To Me.m_ListAlignPosition.Length - 1) As CAlignPositionData
            For i = 0 To reg.Length - 1
                reg(i) = Me.m_ListAlignPosition(i).Clone()
            Next
            Dim res As CAlignPosition = New CAlignPosition(reg)
            Return res
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class
Public Class CAlignPositionData
    Private m_XAxis, m_YAxis, m_ZAxis, m_SAxis, m_RAxis As Double
    Private m_MotionSequence As eMotionSequence
    Public Property XAxis As Double
        Get
            Return m_XAxis
        End Get
        Set(ByVal value As Double)
            m_XAxis = value
        End Set
    End Property
    Public Property YAxis As Double
        Get
            Return m_YAxis
        End Get
        Set(ByVal value As Double)
            m_YAxis = value
        End Set
    End Property
    Public Property ZAxis As Double
        Get
            Return m_ZAxis
        End Get
        Set(ByVal value As Double)
            m_ZAxis = value
        End Set
    End Property
    Public Property SAxis As Double
        Get
            Return m_SAxis
        End Get
        Set(ByVal value As Double)
            m_SAxis = value
        End Set
    End Property
    Public Property RAxis As Double
        Get
            Return m_RAxis
        End Get
        Set(ByVal value As Double)
            m_RAxis = value
        End Set
    End Property
    Public Property MotionSequence As eMotionSequence
        Get
            Return m_MotionSequence
        End Get
        Set(ByVal value As eMotionSequence)
            m_MotionSequence = value
        End Set
    End Property
    Public Sub New()
        Me.m_XAxis = 0
        Me.m_YAxis = 0
        Me.m_ZAxis = 0
        Me.m_RAxis = 0
        Me.m_SAxis = 0
        Me.m_MotionSequence = 0
    End Sub
    Public Sub New(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pR As Double, ByVal pS As Double, ByVal pMotion As eMotionSequence)
        Me.m_XAxis = pX
        Me.m_YAxis = pY
        Me.m_ZAxis = pZ
        Me.m_RAxis = pR
        Me.m_SAxis = pS
        Me.m_MotionSequence = pMotion
    End Sub
    Public Sub New(ByVal pX As Double, ByVal pY As Double, ByVal pZ As Double, ByVal pMotion As eMotionSequence)
        Me.m_XAxis = pX
        Me.m_YAxis = pY
        Me.m_ZAxis = pZ
        Me.m_RAxis = 0
        Me.m_SAxis = 0
        Me.m_MotionSequence = pMotion
    End Sub
    Public Function Clone() As CAlignPositionData
        Try
            Return New CAlignPositionData(Me.XAxis, Me.YAxis, Me.ZAxis, Me.RAxis, Me.SAxis, Me.MotionSequence)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
End Class



Public Enum eMotionSequence As Integer
    R_To_XYZ = 0
    XYZ_To_R = 1
    XYZR = 2
End Enum