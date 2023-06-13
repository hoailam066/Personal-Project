Option Strict On
Imports System.Collections.Generic
Imports Timer
Imports Xmler
Imports Automation.BDaq

Friend Enum enumDAQCard
    None = 0
    Advantech1758UDIO = 1
    Advantech1711 = 2
    ADLink7853 = 4
    ADlink2501 = 5
    DMC2610 = 6
    DMC5480 = 7
    AdlinkAMP204C = 10
End Enum

Public Enum enumCyllogic
    [Default] = 0
    Normal = 1
    CloseAll = 2
    Action = 3
End Enum

Public Enum enumCylSts
    Ready
    NotReady
    TimeOut
End Enum


Public Class CDO
#Region "Constant"
#End Region
#Region "Member"
    Private m_SrcDirectory As String
    Private m_ErrMessage As String
    Private Shared m_CylMaximum As Integer
    Private m_DO() As CDOBased
    Private m_Advantech1758UDIO As CAdvantech1758UDO
    Private m_ADLink7853DO As CAdlink785XDO
    Private m_DMC5480DO As CDMC5480DO
    Private m_AdlinkAMP204UDO As CAdlinkAMP204UDO
    Private m_PSeudoDI As CDI
    Private Shared m_Timer As CHighResolutionTimer
#End Region
#Region "Property"
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property
    Public Property SatbleTimeAction(ByVal CylIdx As Integer) As Integer
        Get
            Return m_DO(CylIdx).SatbleTimeAction
        End Get
        Set(ByVal value As Integer)
            m_DO(CylIdx).SatbleTimeAction = value
        End Set
    End Property
    Public Property SatbleTimeNormal(ByVal CylIdx As Integer) As Integer
        Get
            Return m_DO(CylIdx).SatbleTimeNormal
        End Get
        Set(ByVal value As Integer)
            m_DO(CylIdx).SatbleTimeNormal = value
        End Set
    End Property
    Public Property AlarmTime(ByVal CylIdx As Integer) As Integer
        Get
            Return m_DO(CylIdx).AlarmTime
        End Get
        Set(ByVal value As Integer)
            m_DO(CylIdx).AlarmTime = value
        End Set
    End Property
    Public Property Status(ByVal CylIdx As Integer) As enumCyllogic
        Get
            Return m_DO(CylIdx).Status
        End Get
        Friend Set(ByVal value As enumCyllogic)
            m_DO(CylIdx).Status = value
        End Set
    End Property
#End Region
#Region "Method"
    Public Sub New(ByVal SrcDirectory As String, ByVal CylName() As String, ByRef pPSeudoDI As CDI)
        If m_Timer Is Nothing Then m_Timer = New CHighResolutionTimer
        m_SrcDirectory = SrcDirectory
        m_PSeudoDI = pPSeudoDI
        m_CylMaximum = CylName.Length() - 1
        ReDim m_DO(0 To m_CylMaximum)

        For i As Integer = 0 To m_CylMaximum
            m_DO(i) = New CDOBased
            m_DO(i).Name = CylName(i)
            'm_DO(i).BitAdressAction = "Dev1/Port1/Line1"
            m_DO(i).NameChinese = CylName(i)
            m_DO(i).AlarmTime = 5000
        Next
        '  Call WriteDataToFile()
        Call ReadDataFromFile()

        For i As Integer = 0 To m_CylMaximum
            Select Case m_DO(i).CardType
                Case enumDAQCard.Advantech1758UDIO
                    If m_Advantech1758UDIO Is Nothing Then m_Advantech1758UDIO = New CAdvantech1758UDO(m_DO)
                    m_DO(i).WiringIDAction = m_Advantech1758UDIO.WiringIDAction(i)

                Case enumDAQCard.ADLink7853
                    If m_ADLink7853DO Is Nothing Then m_ADLink7853DO = New CAdlink785XDO(m_DO)
                Case enumDAQCard.DMC5480
                    If m_DMC5480DO Is Nothing Then m_DMC5480DO = New CDMC5480DO(m_DO)
		Case enumDAQCard.AdlinkAMP204C
                    If m_AdlinkAMP204UDO Is Nothing Then m_AdlinkAMP204UDO = New CAdlinkAMP204UDO(m_DO)
            End Select
        Next
    End Sub
    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
    Private Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer
        Dim cardType As String = ""
        filePath = m_SrcDirectory & "HardWare\DigitalOuput.xml"
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
            Dim xmlDoc As System.Xml.XmlDocument
            xmlDoc = New System.Xml.XmlDocument
            Call xmlDoc.Load(filePath)
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim stemNode As System.Xml.XmlElement

            'rootNode = CType(xmlDoc.SelectSingleNode("RootNode"), Xml.XmlElement)

            For idx = 0 To m_CylMaximum
                stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, m_DO(idx).Name), System.Xml.XmlElement)
                If CXmler.GetXmlData(stemNode, "BitIDAction", 0, rtnText) Then m_DO(idx).BitIDAction = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "BitIDNormal", 0, rtnText) Then m_DO(idx).BitIDNormal = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "BitAdressAction", 0, rtnText) Then m_DO(idx).BitAdressAction = rtnText
                If CXmler.GetXmlData(stemNode, "BitAdressNormal", 0, rtnText) Then m_DO(idx).BitAdressNormal = rtnText
                If CXmler.GetXmlData(stemNode, "CardIDAction", 0, rtnText) Then m_DO(idx).CardIDAction = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "CardIDNormal", 0, rtnText) Then m_DO(idx).CardIDNormal = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "CardType", 0, rtnText) Then cardType = rtnText
                Select Case cardType.ToLower()
                    Case "PCI1758UDIO".ToLower()
                        m_DO(idx).CardType = enumDAQCard.Advantech1758UDIO
                    Case "PCI1711".ToLower()
                        m_DO(idx).CardType = enumDAQCard.Advantech1711
                    Case "PCI7853".ToLower()
                        m_DO(idx).CardType = enumDAQCard.ADLink7853
                    Case "PCI2610".ToLower()
                        m_DO(idx).CardType = enumDAQCard.DMC2610
                    Case "PCI5480".ToLower()
                        m_DO(idx).CardType = enumDAQCard.DMC5480
		    Case "AdlinkAMP204C".ToLower()
                        m_DO(idx).CardType = enumDAQCard.AdlinkAMP204C
                    Case Else
                        m_DO(idx).CardType = enumDAQCard.None
                End Select
                If CXmler.GetXmlData(stemNode, "ConnectIndexAction", 0, rtnText) Then m_DO(idx).ConnectIndexAction = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "ConnectIndexNormal", 0, rtnText) Then m_DO(idx).ConnectIndexNormal = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "NameActionNormal", 0, rtnText) Then m_DO(idx).NameActionNormal = rtnText
                If CXmler.GetXmlData(stemNode, "NameChinese", 0, rtnText) Then m_DO(idx).NameChinese = rtnText
                If CXmler.GetXmlData(stemNode, "NameNormalAction", 0, rtnText) Then m_DO(idx).NameNormalAction = rtnText
                If CXmler.GetXmlData(stemNode, "NameNormalNormal", 0, rtnText) Then m_DO(idx).NameNormalNormal = rtnText
                If CXmler.GetXmlData(stemNode, "SlaveIDAction", 0, rtnText) Then m_DO(idx).SlaveIDAction = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "SlaveIDNormal", 0, rtnText) Then m_DO(idx).SlaveIDNormal = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "SnrIdxAction", 0, rtnText) Then m_DO(idx).SnrIdxAction = CInt(rtnText)
                If CXmler.GetXmlData(stemNode, "SnrIdxNormal", 0, rtnText) Then m_DO(idx).SnrIdxNormal = CInt(rtnText)
            Next

            filePath = m_SrcDirectory & "Machine\Parameter\DigitalOuput.xml"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                Dim xmlDoc1 As System.Xml.XmlDocument
                xmlDoc1 = New System.Xml.XmlDocument
                Call xmlDoc1.Load(filePath)
                Dim rootNode1 As System.Xml.XmlElement = xmlDoc1.Item("RootNode")
                Dim stemNode1 As System.Xml.XmlElement
                'rootNode = CType(xmlDoc.SelectSingleNode("RootNode"), Xml.XmlElement)
                For idx = 0 To m_CylMaximum
                    stemNode1 = DirectCast(CXmler.GetPreviousNode(rootNode1, m_DO(idx).Name), System.Xml.XmlElement)
                    If CXmler.GetXmlData(stemNode1, "AlarmTime", 0, rtnText) Then m_DO(idx).AlarmTime = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode1, "SatbleTimeAction", 0, rtnText) Then m_DO(idx).SatbleTimeAction = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode1, "SatbleTimeNormal", 0, rtnText) Then m_DO(idx).SatbleTimeNormal = CInt(rtnText)
                Next
            Else
                ErrMessage = m_SrcDirectory & "Machine\Parameter\DigitalOuput.xml設定檔案損毀!!"
            End If
        Else
            ErrMessage = m_SrcDirectory & "HardWare\DigitalOuput.xml設定檔案損毀!!"
        End If
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer
        Dim filePath As String = ""
        Try
            filePath = m_SrcDirectory & "HardWare\DigitalOuput.xml"
            For idx = 0 To m_CylMaximum
                stemNode = DirectCast(CXmler.NewXmlNode(rootNode, m_DO(idx).Name, 0, nodeAttributes), System.Xml.XmlElement) ' 建立空節點
                Call CXmler.NewXmlValue(stemNode, "BitIDAction", 0, m_DO(idx).BitIDAction)
                Call CXmler.NewXmlValue(stemNode, "BitIDNormal", 0, m_DO(idx).BitIDNormal)
                Call CXmler.NewXmlValue(stemNode, "BitAdressAction", 0, m_DO(idx).BitAdressAction)
                Call CXmler.NewXmlValue(stemNode, "BitAdressNormal", 0, m_DO(idx).BitAdressNormal)
                Call CXmler.NewXmlValue(stemNode, "CardIDAction", 0, m_DO(idx).CardIDAction)
                Call CXmler.NewXmlValue(stemNode, "CardIDNormal", 0, m_DO(idx).CardIDNormal)
                Select Case m_DO(idx).CardType
                    Case enumDAQCard.Advantech1758UDIO
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1758UDIO")
                    Case enumDAQCard.Advantech1711
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1711")
                    Case enumDAQCard.ADLink7853
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI7853")
                    Case enumDAQCard.DMC2610
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI2610")
                    Case enumDAQCard.DMC5480
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI5480")
                    Case enumDAQCard.AdlinkAMP204C
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "AdlinkAMP204C")
                    Case Else
                        Call CXmler.NewXmlValue(stemNode, "CardType", 0, "None")
                End Select
                Call CXmler.NewXmlValue(stemNode, "ConnectIndexAction", 0, m_DO(idx).ConnectIndexAction)
                Call CXmler.NewXmlValue(stemNode, "ConnectIndexNormal", 0, m_DO(idx).ConnectIndexNormal)
                Call CXmler.NewXmlValue(stemNode, "NameActionNormal", 0, m_DO(idx).NameActionNormal)
                Call CXmler.NewXmlValue(stemNode, "NameChinese", 0, m_DO(idx).NameChinese)
                Call CXmler.NewXmlValue(stemNode, "NameNormalAction", 0, m_DO(idx).NameNormalAction)
                Call CXmler.NewXmlValue(stemNode, "NameNormalNormal", 0, m_DO(idx).NameNormalNormal)
                Call CXmler.NewXmlValue(stemNode, "SlaveIDAction", 0, m_DO(idx).SlaveIDAction)
                Call CXmler.NewXmlValue(stemNode, "SlaveIDNormal", 0, m_DO(idx).SlaveIDNormal)
                Call CXmler.NewXmlValue(stemNode, "SnrIdxAction", 0, m_DO(idx).SnrIdxAction)
                Call CXmler.NewXmlValue(stemNode, "SnrIdxNormal", 0, m_DO(idx).SnrIdxNormal)
            Next
            Call xmlDoc.Save(filePath)

            Dim xmlDoc1 As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
            Dim rootNode1 As System.Xml.XmlElement = xmlDoc1.Item("RootNode")
            Dim nodeAttributes1 As New Dictionary(Of String, String)
            Call nodeAttributes1.Add("Attributes", "")
            Dim stemNode1 As System.Xml.XmlElement
            filePath = m_SrcDirectory & "Machine\Parameter\DigitalOuput.xml"
            For idx = 0 To m_CylMaximum
                stemNode1 = DirectCast(CXmler.NewXmlNode(rootNode1, m_DO(idx).Name, 0, nodeAttributes1), System.Xml.XmlElement) ' 建立空節點
                Call CXmler.NewXmlValue(stemNode1, "AlarmTime", 0, m_DO(idx).AlarmTime)
                Call CXmler.NewXmlValue(stemNode1, "SatbleTimeAction", 0, m_DO(idx).SatbleTimeAction)
                Call CXmler.NewXmlValue(stemNode1, "SatbleTimeNormal", 0, m_DO(idx).SatbleTimeNormal)
            Next
            Call xmlDoc1.Save(filePath)
        Catch ex As Exception

        End Try
    End Sub
    Public ReadOnly Property WiringIDAction(ByVal CylIdx As Integer) As Integer
        Get
            Return m_DO(CylIdx).WiringIDAction
        End Get
    End Property
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="CylIdx"></param>
    ''' <param name="Status"></param>
    ''' <remarks>
    ''' 0-> Action Close Normal Open
    ''' 1-> Action Close Normal Close
    ''' 2-> Action Open  Normal Close
    ''' </remarks>
    Public Sub CylGo(ByVal CylIdx As Integer, ByVal Status As enumCyllogic)
        Select Case m_DO(CylIdx).CardType
            Case enumDAQCard.Advantech1758UDIO
                Call m_Advantech1758UDIO.CylGo(CylIdx, Status)
            Case enumDAQCard.ADLink7853
                Call m_ADLink7853DO.CylGo(CylIdx, Status)
            Case enumDAQCard.DMC2610

            Case enumDAQCard.DMC5480
                Call m_DMC5480DO.CylGo(CylIdx, Status)
	    Case enumDAQCard.AdlinkAMP204C
                Call m_AdlinkAMP204UDO.CylGo(CylIdx, Status)
        End Select
    End Sub
    Public Sub CheckCylReady(ByVal CylIdx As Integer, ByRef pStatus As enumCylSts)
        Dim status As Boolean
        pStatus = enumCylSts.NotReady
        Select Case m_DO(CylIdx).ProcessNum
            Case 0
                pStatus = enumCylSts.Ready
            Case 10
                m_DO(CylIdx).StartChkTime = m_Timer.GetMilliseconds()
                m_DO(CylIdx).ProcessNum = 15
            Case 15
                'Check sensor
                Select Case m_DO(CylIdx).Status
                    Case enumCyllogic.Normal
                        If m_DO(CylIdx).SnrIdxAction = -1 Then
                            If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                m_DO(CylIdx).ProcessNum = 20
                            Else
                                Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                If status Then
                                    m_DO(CylIdx).ProcessNum = 20
                                End If
                            End If
                        Else
                            Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxAction, status)
                            If Not status Then
                                If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                    m_DO(CylIdx).ProcessNum = 20
                                Else
                                    Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                    If status Then
                                        m_DO(CylIdx).ProcessNum = 20
                                    End If
                                End If
                            End If
                        End If

                    Case enumCyllogic.CloseAll
                        If m_DO(CylIdx).SnrIdxAction = -1 Then
                            If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                m_DO(CylIdx).ProcessNum = 20
                            Else
                                Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                If Not status Then
                                    m_DO(CylIdx).ProcessNum = 20
                                End If
                            End If
                        Else
                            Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxAction, status)
                            If Not status Then
                                If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                    m_DO(CylIdx).ProcessNum = 20
                                Else
                                    Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                    If Not status Then
                                        m_DO(CylIdx).ProcessNum = 20
                                    End If
                                End If
                            End If
                        End If

                    Case enumCyllogic.Action
                        If m_DO(CylIdx).SnrIdxAction = -1 Then
                            If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                m_DO(CylIdx).ProcessNum = 20
                            Else
                                Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                If Not status Then
                                    m_DO(CylIdx).ProcessNum = 20
                                End If
                            End If
                        Else
                            Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxAction, status)
                            If status Then
                                If m_DO(CylIdx).SnrIdxNormal = -1 Then
                                    m_DO(CylIdx).ProcessNum = 20
                                Else
                                    Call m_PSeudoDI.CheckSensorSts(m_DO(CylIdx).SnrIdxNormal, status)
                                    If Not status Then
                                        m_DO(CylIdx).ProcessNum = 20
                                    End If
                                End If
                            Else
                            End If
                        End If
                End Select
                If m_Timer.GetMilliseconds() - m_DO(CylIdx).StartChkTime > m_DO(CylIdx).AlarmTime Then
                    m_DO(CylIdx).ProcessNum = 10
                    pStatus = enumCylSts.TimeOut
                End If

            Case 20
                m_DO(CylIdx).StartTime = m_Timer.GetMilliseconds()
                m_DO(CylIdx).ProcessNum = 30

            Case 30
                'chk stable time
                Select Case m_DO(CylIdx).Status
                    Case enumCyllogic.Action
                        If m_Timer.GetMilliseconds() - m_DO(CylIdx).StartTime >= m_DO(CylIdx).SatbleTimeAction Then
                            m_DO(CylIdx).ProcessNum = 0
                            pStatus = enumCylSts.Ready
                        End If
                    Case enumCyllogic.CloseAll
                        If m_Timer.GetMilliseconds() - m_DO(CylIdx).StartTime >= m_DO(CylIdx).SatbleTimeAction AndAlso m_Timer.GetMilliseconds() - m_DO(CylIdx).StartTime >= m_DO(CylIdx).SatbleTimeNormal Then
                            m_DO(CylIdx).ProcessNum = 0
                            pStatus = enumCylSts.Ready
                        End If
                    Case enumCyllogic.Normal
                        If m_Timer.GetMilliseconds() - m_DO(CylIdx).StartTime >= m_DO(CylIdx).SatbleTimeNormal Then
                            m_DO(CylIdx).ProcessNum = 0
                            pStatus = enumCylSts.Ready
                        End If
                End Select
        End Select
    End Sub
#End Region
End Class

Public Class CDI
#Region "Constant"

#End Region
#Region "Member"
    Private m_SrcDirectory As String = "D:\DataSettings\LaserSolder\"
    Private m_SnrMaximum As Integer
    Private m_DI() As CDIBased
    Private m_Advantech1758UDIO As CAdvantech1758UDI
    Private m_ADLink7853DI As CAdlink785XDI
    Private m_DMC5480DI As CDMC5480DI
    Private m_AdlinkAMP204UDI As CAdlinkAMP204UDI
#End Region
#Region "Property"
    Private m_ErrMessage As String
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property

    Public ReadOnly Property WiringID(ByVal SnrIdx As Integer) As Integer
        Get
            Return m_DI(SnrIdx).WiringID
        End Get
    End Property
#End Region
#Region "Construct & Destruct"
    Public Sub New(ByVal SrcDirectory As String, ByVal SnrName() As String, Optional ByVal IsSimulate As Boolean = False)
        m_SrcDirectory = SrcDirectory
        m_SnrMaximum = SnrName.Length() - 1
        ReDim m_DI(0 To m_SnrMaximum)

        For i As Integer = 0 To m_SnrMaximum
            m_DI(i) = New CDIBased
            m_DI(i).Name = SnrName(i)
        Next
        'Call WriteDataToFile()
        Call ReadDataFromFile()
        For i As Integer = 0 To m_SnrMaximum
            Select Case m_DI(i).CardType
                Case enumDAQCard.Advantech1758UDIO
                    If m_Advantech1758UDIO Is Nothing Then m_Advantech1758UDIO = New CAdvantech1758UDI(m_DI)
                    m_DI(i).WiringID = m_Advantech1758UDIO.WiringID(i)
                Case enumDAQCard.ADLink7853
                    If m_ADLink7853DI Is Nothing Then m_ADLink7853DI = New CAdlink785XDI(m_DI)
                Case enumDAQCard.DMC5480
                    If m_DMC5480DI Is Nothing Then m_DMC5480DI = New CDMC5480DI(m_DI)
                Case enumDAQCard.AdlinkAMP204C
                    If m_AdlinkAMP204UDI Is Nothing Then m_AdlinkAMP204UDI = New CAdlinkAMP204UDI(m_DI)		    
            End Select
        Next
    End Sub
#End Region
#Region "Method"
    Private Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer
        Dim logicSts As String = ""
        Dim cardType As String = ""
        Try
            filePath = m_SrcDirectory & "HardWare\DigitalInput.xml"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                Dim xmlDoc As System.Xml.XmlDocument
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(filePath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement
                For idx = 0 To m_SnrMaximum
                    stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, m_DI(idx).Name), System.Xml.XmlElement)
                    If CXmler.GetXmlData(stemNode, "BitID", 0, rtnText) Then m_DI(idx).BitID = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "BitAdress", 0, rtnText) Then m_DI(idx).BitAdress = rtnText
                    If CXmler.GetXmlData(stemNode, "CardID", 0, rtnText) Then m_DI(idx).CardID = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardType", 0, rtnText) Then cardType = rtnText
                    Select Case cardType.ToLower()
                        Case "PCI1758UDIO".ToLower()
                            m_DI(idx).CardType = enumDAQCard.Advantech1758UDIO
                        Case "PCI1711".ToLower()
                            m_DI(idx).CardType = enumDAQCard.Advantech1711
                        Case "PCI7853".ToLower()
                            m_DI(idx).CardType = enumDAQCard.ADLink7853
                        Case "PCI2610".ToLower()
                            m_DI(idx).CardType = enumDAQCard.DMC2610
                        Case "PCI5480".ToLower()
                            m_DI(idx).CardType = enumDAQCard.DMC5480
                        Case "AdlinkAMP204C".ToLower()
                            m_DI(idx).CardType = enumDAQCard.AdlinkAMP204C			    
                        Case Else
                            m_DI(idx).CardType = enumDAQCard.None
                    End Select
                    If CXmler.GetXmlData(stemNode, "ConnectIndex", 0, rtnText) Then m_DI(idx).ConnectIndex = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "IsIgnore", 0, rtnText) Then m_DI(idx).IsIgnore() = CBool(rtnText)
                    If CXmler.GetXmlData(stemNode, "Logic", 0, rtnText) Then logicSts = rtnText
                    If logicSts = "ActiveHigh" Then
                        m_DI(idx).Logic = True
                    Else
                        m_DI(idx).Logic = False
                    End If
                    If CXmler.GetXmlData(stemNode, "NameChinese", 0, rtnText) Then m_DI(idx).NameChinese = rtnText
                    If CXmler.GetXmlData(stemNode, "SlaveID", 0, rtnText) Then m_DI(idx).SlaveID = CInt(rtnText)
                Next
            Else
                ErrMessage = m_SrcDirectory & "HardWare\DigitalInput.xml設定檔案損毀!!"
            End If
        Catch ex As Exception
            ErrMessage = ex.ToString()
        End Try
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer
        Dim filePath As String = ""
        filePath = m_SrcDirectory & "HardWare\DigitalInput.xml"
        For idx = 0 To m_SnrMaximum
            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, m_DI(idx).Name, 0, nodeAttributes), System.Xml.XmlElement) ' 建立空節點
            Call CXmler.NewXmlValue(stemNode, "BitID", 0, m_DI(idx).BitID)
            Call CXmler.NewXmlValue(stemNode, "BitAdress", 0, m_DI(idx).BitAdress)
            Call CXmler.NewXmlValue(stemNode, "CardID", 0, m_DI(idx).CardID)
            Call CXmler.NewXmlValue(stemNode, "ConnectIndex", 0, m_DI(idx).ConnectIndex)
            Select Case m_DI(idx).CardType
                Case enumDAQCard.Advantech1758UDIO
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1758UDIO")
                Case enumDAQCard.Advantech1711
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1711")
                Case enumDAQCard.ADLink7853
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI7853")
                Case enumDAQCard.DMC2610
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI2610")
                Case enumDAQCard.DMC5480
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI5480")
                Case Else
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "None")
            End Select
            Call CXmler.NewXmlValue(stemNode, "IsIgnore", 0, m_DI(idx).IsIgnore)
            Select Case m_DI(idx).Logic
                Case True
                    Call CXmler.NewXmlValue(stemNode, "Logic", 0, "ActiveHigh")
                Case False
                    Call CXmler.NewXmlValue(stemNode, "Logic", 0, "ActiveLow")
            End Select
            Call CXmler.NewXmlValue(stemNode, "NameChinese", 0, m_DI(idx).NameChinese)
            Call CXmler.NewXmlValue(stemNode, "SlaveID", 0, m_DI(idx).SlaveID)
        Next
        Call xmlDoc.Save(filePath)
    End Sub
    Public Sub CheckSensorSts(ByVal SnrIdx As Integer, ByRef pStatus As Boolean)
        Select Case m_DI(SnrIdx).CardType
            Case enumDAQCard.Advantech1758UDIO
                Call m_Advantech1758UDIO.CheckSensorSts(SnrIdx, pStatus)
            Case enumDAQCard.ADLink7853
                Call m_ADLink7853DI.CheckSensorSts(SnrIdx, pStatus)
            Case enumDAQCard.DMC2610
            Case enumDAQCard.DMC5480
                Call m_DMC5480DI.CheckSensorSts(SnrIdx, pStatus)
            Case enumDAQCard.AdlinkAMP204C
                Call m_AdlinkAMP204UDI.CheckSensorSts(SnrIdx, pStatus)		
            Case Else
                pStatus = False
        End Select
    End Sub
#End Region
End Class

Public Class CAnalogOut
#Region "Constant"

#End Region
#Region "Member"
    Private m_SrcDirectory As String = "D:\DataSettings\LaserSolder\"
    Private m_AnalogOutMaximum As Integer
    Private m_AnalogOut() As CAnalogOutBased
    Private m_Advantech1711AO As CAdvantech1711AO
    Private m_Adlink2501AO As CD2kDaskAO
#End Region
#Region "Property"
    Private m_ErrMessage As String
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property


    Private m_LaserSerial() As String = {"150-024-629", "150-024-629", "150-024-102", "150-024-378", "150-024-628", "200-000-150", "250-025-383", "150-024-632", "150-023-967", "150-024-634", "150-024-113", "150-024-115", "200-000-168"} '150-024-381
    Public ReadOnly Property LaserSerial(ByVal idx As Integer) As String
        Get
            Return m_LaserSerial(idx)
        End Get
    End Property
#End Region
#Region "Construct & Destruct"
    Public Sub New(ByVal SrcDirectory As String, ByVal AnalogOutName() As String, Optional ByVal IsSimulate As Boolean = False, Optional ByVal pBust_Type As Boolean = False)
        m_SrcDirectory = SrcDirectory
        m_AnalogOutMaximum = AnalogOutName.Length() - 1
        m_Bust_Type = pBust_Type
        ReDim m_AnalogOut(0 To m_AnalogOutMaximum)

        For i As Integer = 0 To m_AnalogOutMaximum
            m_AnalogOut(i) = New CAnalogOutBased
            m_AnalogOut(i).Name = AnalogOutName(i)
        Next
        Call ReadDataFromFile()
        For i As Integer = 0 To m_AnalogOutMaximum
            Select Case m_AnalogOut(i).CardType
                Case enumDAQCard.ADlink2501
                    If m_Adlink2501AO Is Nothing Then m_Adlink2501AO = New CD2kDaskAO()
                Case enumDAQCard.ADLink7853
                Case enumDAQCard.Advantech1711
                    If m_Advantech1711AO Is Nothing Then m_Advantech1711AO = New CAdvantech1711AO(m_AnalogOut)
                Case enumDAQCard.Advantech1758UDIO
            End Select
        Next
    End Sub
#End Region
#Region "Method"
    Public Sub ReloadWaveForm()
        'On Error Resume Next
        Try
            Dim filePath As String
            Dim strData() As String
            For aryIdx As Integer = 0 To 99
                filePath = m_SrcDirectory & "Machine\Laser\" & "Waveform" & aryIdx & ".bin"
                If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                    strData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.Default)
                    If aryIdx = 7 Then
                        Dim a As Integer = 0
                    End If
                    For paternIdx As Integer = 0 To strData.Length - 3 Step 1
                        If paternIdx > 199 Then Exit For
                        m_AnalogOut(0).WavePattern(aryIdx, paternIdx) = CShort(strData(paternIdx + 2))
                    Next
                Else
                    ErrMessage = filePath & "設定檔案損毀!!"
                    Exit For
                End If
            Next
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "CDAQ ReloadWaveForm Error")
        End Try
    End Sub
    Public Sub UpdateWaveForm(ByVal pAryIdx As Integer, ByVal pArrayNum() As Integer)
        'On Error Resume Next
        Try
            Dim filePath As String
            Dim strData() As String

            If pAryIdx >= 0 AndAlso pAryIdx < 100 Then
                For idx As Integer = 0 To pArrayNum.Length - 1 Step 1
                    If idx > 199 Then
                        m_AnalogOut(0).WavePattern(pAryIdx, idx) = CShort(pArrayNum(idx))
                    End If
                Next
            End If

            filePath = m_SrcDirectory & "Machine\Laser\" & "Waveform" & pAryIdx & ".bin"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                strData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.Default)
                ReDim Preserve strData(pArrayNum.Length + 2)
                For idx As Integer = 0 To pArrayNum.Length - 1 Step 1
                    If idx > 199 Then
                        strData(idx + 2) = CStr(pArrayNum(idx))
                    End If
                Next
                System.IO.File.WriteAllLines(filePath, strData)
            End If


            'For aryIdx As Integer = 0 To 99
            '    filePath = m_SrcDirectory & "Machine\Laser\" & "Waveform" & aryIdx & ".bin"
            '    If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
            '        strData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.Default)
            '        If aryIdx = 7 Then
            '            Dim a As Integer = 0
            '        End If
            '        For paternIdx As Integer = 0 To strData.Length - 3 Step 1
            '            If paternIdx > 199 Then Exit For
            '            m_AnalogOut(0).WavePattern(aryIdx, paternIdx) = CShort(strData(paternIdx + 2))
            '        Next
            '    Else
            '        ErrMessage = filePath & "設定檔案損毀!!"
            '        Exit For
            '    End If
            'Next
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "CDAQ ReloadWaveForm Error")
        End Try
    End Sub
    Public Function ChkStop() As Integer
        Return m_Adlink2501AO.ChkStop()
    End Function


    Private Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer
        Dim logicSts As String = ""
        Dim cardType As String = ""
        Try
            filePath = m_SrcDirectory & "HardWare\AnalogOutput.xml"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                Dim xmlDoc As System.Xml.XmlDocument
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(filePath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement
                For idx = 0 To m_AnalogOutMaximum
                    stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, m_AnalogOut(idx).Name), System.Xml.XmlElement)
                    If CXmler.GetXmlData(stemNode, "BitID", 0, rtnText) Then m_AnalogOut(idx).BitID = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardID", 0, rtnText) Then m_AnalogOut(idx).CardID = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardType", 0, rtnText) Then cardType = rtnText
                    Select Case cardType.ToLower()
                        Case "PCI1758UDIO".ToLower()
                            m_AnalogOut(idx).CardType = enumDAQCard.Advantech1758UDIO
                        Case "PCI1711".ToLower()
                            m_AnalogOut(idx).CardType = enumDAQCard.Advantech1711
                        Case "PCI7853".ToLower()
                            m_AnalogOut(idx).CardType = enumDAQCard.ADLink7853
                        Case "PCI2501".ToLower()
                            m_AnalogOut(idx).CardType = enumDAQCard.ADlink2501
                        Case Else
                            m_AnalogOut(idx).CardType = enumDAQCard.None
                    End Select
                    If CXmler.GetXmlData(stemNode, "NameChinese", 0, rtnText) Then m_AnalogOut(idx).NameChinese = rtnText
                Next
            Else
                ErrMessage = m_SrcDirectory & "HardWare\AnalogOutput.xml設定檔案損毀!!"
            End If
            Dim strData() As String
            For aryIdx As Integer = 0 To 99
                filePath = m_SrcDirectory & "Machine\Laser\" & "Waveform" & aryIdx & ".bin"
                If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                    strData = System.IO.File.ReadAllLines(filePath, System.Text.Encoding.Default)
                    If aryIdx = 7 Then
                        Dim a As Integer = 0
                    End If
                    For paternIdx As Integer = 0 To strData.Length - 3 Step 1
                        If paternIdx > 199 Then Exit For
                        m_AnalogOut(0).WavePattern(aryIdx, paternIdx) = CShort(strData(paternIdx + 2))
                    Next
                Else
                    ErrMessage = filePath & "設定檔案損毀!!"
                    Exit For
                End If
            Next
        Catch ex As Exception
            ErrMessage = ex.ToString()
        End Try
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer
        Dim filePath As String = ""
        filePath = m_SrcDirectory & "HardWare\AnalogOutput.xml"
        For idx = 0 To m_AnalogOutMaximum
            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, m_AnalogOut(idx).Name, 0, nodeAttributes), System.Xml.XmlElement) ' 建立空節點
            Call CXmler.NewXmlValue(stemNode, "BitID", 0, m_AnalogOut(idx).BitID)
            Call CXmler.NewXmlValue(stemNode, "CardID", 0, m_AnalogOut(idx).CardID)
            Select Case m_AnalogOut(idx).CardType
                Case enumDAQCard.Advantech1758UDIO
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1758UDIO")
                Case enumDAQCard.Advantech1711
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1711")
                Case enumDAQCard.ADLink7853
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI7853")
                Case enumDAQCard.ADlink2501
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI2501")
                Case Else
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "None")
            End Select
            Call CXmler.NewXmlValue(stemNode, "NameChinese", 0, m_AnalogOut(idx).NameChinese)
        Next
        Call xmlDoc.Save(filePath)
    End Sub
    Public Sub SetVoltage(ByVal AnalogOutIdx As Integer, ByVal Voltage As Double)
        Select Case m_AnalogOut(AnalogOutIdx).CardType
            Case enumDAQCard.Advantech1711
                Call m_Advantech1711AO.SetVoltage(AnalogOutIdx, Voltage)
        End Select
    End Sub


    Public WriteOnly Property WavePattern(ByVal WaveformIdx As Integer, ByVal PatternIdx As Integer) As Short
        Set(ByVal value As Short)
            m_AnalogOut(0).WavePattern(WaveformIdx, PatternIdx) = value
        End Set
    End Property


    Private m_LaserSerialNumberType As String
    Public Property LaserSerialNumberType() As String
        Set(ByVal value As String)
            Dim find As Boolean = False
            For i As Integer = 0 To m_LaserSerial.Length - 1 Step 1
                If m_LaserSerial(i) = value Then
                    find = True
                End If
            Next

            If find = True Then
                m_Bust_Type = True
                m_LaserSerialNumberType = "True"
            Else
                m_Bust_Type = False
                m_LaserSerialNumberType = "False"
            End If
        End Set
        Get
            Return m_LaserSerialNumberType
        End Get
    End Property
    Private m_Bust_Type As Boolean = False
    Public Sub StartWaveform(ByVal WaveformIdx As Integer)
        Try
            Select Case m_AnalogOut(0).CardType
                Case enumDAQCard.ADlink2501
                    Call m_Adlink2501AO.StartWaveform()
                Case enumDAQCard.ADLink7853
                Case enumDAQCard.Advantech1711
                Case enumDAQCard.Advantech1758UDIO
            End Select
        Catch ex As Exception

        End Try
    End Sub
    Public Sub StopWaveform()
        Try
            Select Case m_AnalogOut(0).CardType
                Case enumDAQCard.ADlink2501
                    Call m_Adlink2501AO.StopWaveform()
                Case enumDAQCard.ADLink7853
                Case enumDAQCard.Advantech1711
                Case enumDAQCard.Advantech1758UDIO
            End Select
        Catch ex As Exception
        End Try
    End Sub

    Public Function PrepareWaveform(ByVal pAO_Buff As Short(), ByVal pWaveformParam As Double, ByVal pWaveformParamType As enumWaveformParamType) As Boolean
        Try
            Select Case m_AnalogOut(0).CardType
                Case enumDAQCard.ADlink2501
                    PrepareWaveform = m_Adlink2501AO.PrepareWaveform(pAO_Buff, pWaveformParam, pWaveformParamType)
                Case enumDAQCard.ADLink7853
                Case enumDAQCard.Advantech1711
                Case enumDAQCard.Advantech1758UDIO
            End Select
        Catch ex As Exception
            PrepareWaveform = False
        End Try
    End Function
    Public Function PrepareWaveformSolder(ByVal pAO_Buff As Short(), ByVal pWaveformParam As Double, ByVal pWaveformParamType As enumWaveformParamType) As Boolean
        Try
            Select Case m_AnalogOut(0).CardType
                Case enumDAQCard.ADlink2501
                    PrepareWaveformSolder = m_Adlink2501AO.PrepareWaveformSolder(pAO_Buff, pWaveformParam, pWaveformParamType)
                Case enumDAQCard.ADLink7853
                Case enumDAQCard.Advantech1711
                Case enumDAQCard.Advantech1758UDIO
            End Select
        Catch ex As Exception
            PrepareWaveformSolder = False
        End Try
    End Function
#End Region
End Class

Public Class CAnalogIn
#Region "Constant"

#End Region
#Region "Member"
    Private m_SrcDirectory As String = "D:\DataSettings\LaserSolder\"
    Private m_AnalogInMaximum As Integer
    Private m_AnalogIn() As CAnalogInBased
    Private m_Advantech1711 As CAdvantech1711AI
#End Region
#Region "Property"
    Private m_ErrMessage As String
    Public Property ErrMessage() As String
        Get
            Return m_ErrMessage
        End Get
        Set(ByVal value As String)
            m_ErrMessage = value
        End Set
    End Property
#End Region
#Region "Construct & Destruct"
    Public Sub New(ByVal SrcDirectory As String, ByVal AnalogInName() As String, Optional ByVal IsSimulate As Boolean = False)
        m_SrcDirectory = SrcDirectory
        m_AnalogInMaximum = AnalogInName.Length() - 1
        ReDim m_AnalogIn(0 To m_AnalogInMaximum)

        For i As Integer = 0 To m_AnalogInMaximum
            m_AnalogIn(i) = New CAnalogInBased
        Next
        Call ReadDataFromFile()
        For i As Integer = 0 To m_AnalogInMaximum
            Select Case m_AnalogIn(i).CardType
                Case enumDAQCard.Advantech1711
                    If m_Advantech1711 Is Nothing Then m_Advantech1711 = New CAdvantech1711AI(m_AnalogIn)
                Case Else
            End Select
        Next
    End Sub
#End Region
#Region "Method"
    Private Sub ReadDataFromFile()
        Dim filePath As String
        Dim rtnText As String = ""
        Dim idx As Integer
        Dim logicSts As String = ""
        Dim cardType As String = ""
        Try
            filePath = m_SrcDirectory & "HardWare\AnalogInput.xml"
            If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(filePath) Then
                Dim xmlDoc As System.Xml.XmlDocument
                xmlDoc = New System.Xml.XmlDocument
                Call xmlDoc.Load(filePath)
                Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
                Dim stemNode As System.Xml.XmlElement
                For idx = 0 To m_AnalogInMaximum
                    stemNode = DirectCast(CXmler.GetPreviousNode(rootNode, m_AnalogIn(idx).Name), System.Xml.XmlElement)
                    If CXmler.GetXmlData(stemNode, "BitID", 0, rtnText) Then m_AnalogIn(idx).BitID() = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardID", 0, rtnText) Then m_AnalogIn(idx).CardID() = CInt(rtnText)
                    If CXmler.GetXmlData(stemNode, "CardType", 0, rtnText) Then cardType = rtnText
                    Select Case cardType.ToLower()
                        Case "PCI1758UDIO".ToLower()
                            m_AnalogIn(idx).CardType = enumDAQCard.Advantech1758UDIO
                        Case "PCI1711".ToLower()
                            m_AnalogIn(idx).CardType = enumDAQCard.Advantech1711
                        Case "PCI7853".ToLower()
                            m_AnalogIn(idx).CardType = enumDAQCard.ADLink7853
                        Case Else
                            m_AnalogIn(idx).CardType = enumDAQCard.None
                    End Select
                    If CXmler.GetXmlData(stemNode, "NameChinese", 0, rtnText) Then m_AnalogIn(idx).NameChinese = rtnText
                Next
            Else
                ErrMessage = m_SrcDirectory & "HardWare\AnalogInput.xml設定檔案損毀!!"
            End If
        Catch ex As Exception
            ErrMessage = ex.ToString()
        End Try
    End Sub
    Public Sub WriteDataToFile()
        Dim xmlDoc As System.Xml.XmlDocument = CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        Dim idx As Integer
        Dim filePath As String = ""
        filePath = m_SrcDirectory & "HardWare\AnalogInput.xml"
        For idx = 0 To m_AnalogInMaximum
            stemNode = DirectCast(CXmler.NewXmlNode(rootNode, m_AnalogIn(idx).Name, 0, nodeAttributes), System.Xml.XmlElement) ' 建立空節點
            Call CXmler.NewXmlValue(stemNode, "BitID", 0, m_AnalogIn(idx).BitID())
            Call CXmler.NewXmlValue(stemNode, "CardID", 0, m_AnalogIn(idx).CardID())
            Select Case m_AnalogIn(idx).CardType
                Case enumDAQCard.Advantech1758UDIO
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1758UDIO")
                Case enumDAQCard.Advantech1711
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI1711")
                Case enumDAQCard.ADLink7853
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "PCI7853")
                Case Else
                    Call CXmler.NewXmlValue(stemNode, "CardType", 0, "None")
            End Select
            Call CXmler.NewXmlValue(stemNode, "NameChinese", 0, m_AnalogIn(idx).NameChinese)
        Next
        Call xmlDoc.Save(filePath)
    End Sub
    Public Sub ReadVoltage(ByVal SnrIdx As Integer, ByRef Voltage As Double)
        Select Case m_AnalogIn(SnrIdx).CardType
            Case enumDAQCard.Advantech1711
                Call m_Advantech1711.ReadVoltage(SnrIdx, Voltage)
        End Select
    End Sub
#End Region
End Class

Public Class CDAQ
#Region "Member"
    Private m_DO As CDO
    Private m_DI As CDI
    Private m_AnalogOutput As CAnalogOut
    Private m_AnalogIn As CAnalogIn

    Private m_Motin As CMotion
#End Region
#Region "Construct & Destruct"
    Public Sub New(ByVal CylName() As String, ByVal SnrName() As String, ByVal SrcDirectory As String)
        Try
            m_DI = New CDI(SrcDirectory, SnrName)
            m_DO = New CDO(SrcDirectory, CylName, m_DI)
            'm_AnalogOutput = New CNaoAnalogOutput
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Public Sub New(ByVal CylName() As String, ByVal SnrName() As String, ByVal AnalogOutName() As String, ByVal SrcDirectory As String, ByVal ss1 As String, ByVal ss2 As String, ByVal ss3 As String)
        Try
            m_DI = New CDI(SrcDirectory, SnrName)
            m_DO = New CDO(SrcDirectory, CylName, m_DI)
            m_AnalogOutput = New CAnalogOut(SrcDirectory, AnalogOutName)
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Public Sub New(ByVal CylName() As String, ByVal SnrName() As String, ByVal AnalogOutName() As String, ByVal AnalogInName() As String, ByVal SrcDirectory As String)
        Try
            m_DI = New CDI(SrcDirectory, SnrName)
            m_DO = New CDO(SrcDirectory, CylName, m_DI)
            m_AnalogOutput = New CAnalogOut(SrcDirectory, AnalogOutName)
            m_AnalogIn = New CAnalogIn(SrcDirectory, AnalogInName)
        Catch ex As Exception
        Finally
        End Try
    End Sub
    Protected Overrides Sub Finalize()
        Try
            m_DO = Nothing
            m_DI = Nothing
            m_AnalogOutput = Nothing
            m_AnalogIn = Nothing
        Catch ex As Exception
        Finally
        End Try
        MyBase.Finalize()
    End Sub
#End Region
#Region "Property"
    Public ReadOnly Property LaserSerialNumber(ByVal idx As Integer) As String
        Get
            Return m_AnalogOutput.LaserSerial(idx)
        End Get
    End Property

    Public Property LaserSerialNumberType() As String
        Get
            Return m_AnalogOutput.LaserSerialNumberType
        End Get
        Set(ByVal value As String)
            m_AnalogOutput.LaserSerialNumberType = value
        End Set
    End Property

    Public ReadOnly Property DigO() As CDO
        Get
            Return m_DO
        End Get
    End Property
    Public ReadOnly Property DigI() As CDI
        Get
            Return m_DI
        End Get
    End Property
    Public ReadOnly Property AnalogOut() As CAnalogOut
        Get
            Return m_AnalogOutput
        End Get
    End Property
    Public ReadOnly Property AnalogIn() As CAnalogOut
        Get
            Return m_AnalogOutput
        End Get
    End Property
#End Region
End Class
