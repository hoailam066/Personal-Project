'Imports System.Threading
'Imports Automation.BDaq

'' InterlockInput / VisiblePointerEnable / FA On/Off / MO On/Off / Latch
'' bit4             bit3                   bit2        bit1        bit0
'Friend Enum enumLaserCtrlPinIn
'    Alarm1 = 22 'Low ->normal
'    Alarm2 = 56 'high ->normal
'End Enum
' ''' <summary>
' ''' Nufern 50W with external hardware control
' ''' </summary>
' ''' <remarks></remarks>
'Public Class CLaserNufern50w
'#Region "CONSTANT"

'#End Region
'#Region "Constructors && Destructors"
'    Public Sub New()
'        Try
'            m_PWM = New Automation.BDaq.TimerPulseCtrl
'            m_DO = New Automation.BDaq.InstantDoCtrl
'            m_DI = New Automation.BDaq.InstantDiCtrl
'            m_PWM.SelectedDevice = New Automation.BDaq.DeviceInformation(0, "PCI-1711,BID#0", AccessMode.ModeWriteWithReset, 0)
'            m_DO.SelectedDevice = New Automation.BDaq.DeviceInformation(1, "PCI-1711,BID#0", AccessMode.ModeWriteWithReset, 0)
'            m_DI.SelectedDevice = New Automation.BDaq.DeviceInformation(1, "PCI-1711,BID#0", AccessMode.ModeRead, 0)
'            m_PWM.Channel = 0
'            m_PWM.Frequency = 50 * 1000
'            m_PWM.Enabled = True
'            Dim out As Byte
'            out = 16 '10000
'            m_DO.Write(1, out)
'            m_ErrMessage = ""
'        Catch ex As Exception
'        Finally
'        End Try
'    End Sub
'#End Region
'#Region "Member"
'    Private Shared m_PWM As Automation.BDaq.TimerPulseCtrl
'    Private Shared m_DO As Automation.BDaq.InstantDoCtrl
'    Private Shared m_DI As Automation.BDaq.InstantDiCtrl
'    Private Shared m_CalibrationK As Double
'#End Region
'#Region "Property"
'    Private Shared m_ErrMessage As String
'    Public Property ErrMessage() As String
'        Get
'            Return m_ErrMessage
'        End Get
'        Set(ByVal value As String)
'            m_ErrMessage = value
'        End Set
'    End Property
'    ''' <summary>
'    ''' 雷射工作頻率KHz
'    ''' </summary>
'    ''' <value></value>
'    ''' <remarks></remarks>
'    Public WriteOnly Property PRR() As String
'        Set(ByVal value As String)
'            Dim freq As Double
'            freq = CDbl(value)
'            m_PWM.Frequency = freq * 1000
'            m_PWM.Enabled = True
'        End Set
'    End Property
'    ''' <summary>
'    ''' 雷射啟用(進啟用雷射尚未實際打出雷射)
'    ''' </summary>
'    ''' <value></value>
'    ''' <remarks></remarks>
'    Public WriteOnly Property LaserEmission() As Boolean
'        Set(ByVal value As Boolean)
'            Try
'                Dim out As Byte
'                If value Then
'                    out = 18 '10010
'                Else
'                    out = 16 '10000
'                End If
'                m_DO.Write(1, out)
'            Catch ex As Exception
'            Finally
'            End Try
'        End Set
'    End Property
'    ''' <summary>
'    ''' 雷射工作功率 %
'    ''' </summary>
'    ''' <value></value>
'    ''' <remarks></remarks>
'    Public WriteOnly Property OperatingPower() As String
'        Set(ByVal value As String)
'            Dim out As Byte
'            out = 16 '10000
'            m_DO.Write(1, out)
'            Thread.Sleep(1)
'            out = CByte(CInt(value) / 100 * 255)
'            m_DO.Write(0, out)
'            Thread.Sleep(1)
'            out = 17 '10011
'            m_DO.Write(1, 19)
'            Thread.Sleep(1)
'            out = 16 '10000
'            m_DO.Write(1, out)
'        End Set
'    End Property
'    ''' <summary>
'    ''' 雷射導引紅光開關
'    ''' </summary>
'    ''' <value>
'    ''' </value>
'    ''' <remarks>
'    ''' </remarks>
'    Public WriteOnly Property LaserGuide() As Boolean
'        Set(ByVal value As Boolean)

'        End Set
'    End Property
'#End Region

'#Region "Methods"
'    Public Sub LaserSignalON()
'        Try
'            Dim out As Byte
'            out = 22 '10110
'            m_DO.Write(1, out)
'        Catch ex As Exception
'        Finally
'        End Try
'    End Sub
'    Public Sub LaserSignalOFF()
'        Try
'            Dim out As Byte
'            out = 16 '10000
'            m_DO.Write(1, out)
'        Catch ex As Exception
'        Finally
'        End Try
'    End Sub
'#End Region
'End Class
