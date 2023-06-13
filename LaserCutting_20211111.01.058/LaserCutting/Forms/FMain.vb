Imports System.Threading
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Drawing.Imaging
Imports PseudoDevice
Imports VisionSystem
Imports ViewROI
Imports System.ComponentModel

Friend Enum enumBlockRange
    Range1 = 100000
    Range2 = 200000
    Range3 = 300000
    Range4 = 400000
    Range5 = 500000
    Range6 = 600000
    Range7 = 700000
    Range8 = 800000
    Range9 = 900000
End Enum

Public Class FMain
    Private ISDEBUG As Boolean = True
    Private Const MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserMachine\MachineData\"
    'Public Shared PX2MM As Double = 1 ' 0.0649350649350649 '0.26455026455026454 ' 0.26458333333333
    Public Shared VisionToViewScaleW As Double
    Public Shared VisionToViewScaleH As Double
    Public m_Acquist As VisionSystem.CAcquisition
    Private m_MouseX As Double
    Private m_MouseY As Double
    'Private m_MouseButton As MouseButtons = MouseButtons.None
    'Private m_StartPoint As Point = New Point(0, 0)
    'Private m_EndPoint As Point = New Point(0, 0)
    'Private m_MouseDown As Boolean = False
    'Private m_MouseUp As Boolean = False
    Private m_ListLine As List(Of CLine)
    Private m_ListOriginalLine As List(Of CLine)
    Private m_LineSelected As CLine
    Private m_Laser As CLaser
    Private m_IsStartSelected As Boolean = False
    Private m_IsEndSelected As Boolean = False
    Private m_MouseDeviation As Integer = 5
    Private m_OldMouse As PointF
    Private m_IsClicked As Boolean = False
    Private m_CurrentProject As CProject
    Private m_Timer As Timer.CHighResolutionTimer
    Private m_SourceImage1st As VisionSystem.CImage
    Private Const loop_COMMAND As Integer = 1111
    Private m_SysProcessNum() As Integer
    Private m_SysTime() As Double
    Private m_BackgroundThread As Thread
    Private m_Param As CParam
    Private m_VisionLineFlag As Boolean = True
    Private m_LaserReticle As VisionSystem.CReticle
    Private m_Corection As CCorrection
    'Public Shared X0 As Integer
    'Public Shared Y0 As Integer
    Public Shared ViewImageWidth As Integer
    Public Shared ViewImageHeight As Integer
    Public Shared VisionImageWidth As Integer
    Public Shared VisionImageHeight As Integer
    Private m_MatchingTool(-1) As VisionSystem.CMatchingTool
    Private m_MatchingToolLeft As VisionSystem.CMatchingTool
    Private m_MatchingToolRight As VisionSystem.CMatchingTool
    Private m_FErrorMsg() As FMessageBox
    Private m_FLoading As FLoading
    Private m_Logs As List(Of Clog)
    Private m_WriteLogFlag As Boolean
    Private m_WriteLogComplete As Boolean
    Private m_start As Double = 0
    Private m_threadWriteLog As Thread
    Private m_FlagSave As Boolean
    Private m_lstLineOnWorkStep(-1) As List(Of Integer)
    ''' <summary>
    ''' Start is 1
    ''' </summary>
    ''' <remarks></remarks>
    Private m_SelectedStep As Integer = -1
    Private m_NoMessageShow As Boolean = False
    Private m_WantLoadMatchingCount As Integer
    Private m_LoadedMatchingCount As Integer
    Private m_StartTime As Double = 0
    Private m_Motion As CMotion
    Private m_DA As CDAQ
    Private m_CopiedParameter As CMerge = Nothing
#Region "Delegate"
    Private Delegate Sub InvokeToolStripStatusLabelCallBack(ByVal text As String, ByVal c As System.Windows.Forms.ToolStripStatusLabel)
    Private Delegate Sub InvokeFormCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Form)
    Private Delegate Sub InvokeTimerCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Timer)
    Private Delegate Sub InvokeButtonCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Button)
    Private Delegate Sub InvokeButtonTextCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.Button)
    Private Delegate Sub InvokeLabelCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.Label)
    Private Delegate Sub InvokeControlTextCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.Control)
    Private Delegate Sub InvokeNumericUpDownCallBack(ByVal Value As Integer, ByVal c As System.Windows.Forms.NumericUpDown)
    Private Delegate Sub InvokeNumericUpDown1CallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.NumericUpDown)
    Private Delegate Sub InvokePanelCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Panel)
    Private Delegate Sub InvokePanelCallBack2(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Panel)
    Private Delegate Sub InvokeTextBoxCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.TextBox)
    Private Delegate Sub InvokeTextBoxTextCallBack(ByVal Status As String, ByVal c As System.Windows.Forms.TextBox)
    Private Delegate Sub InvokeComboBoxCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.ComboBox)
    Private Delegate Sub InvokeComboBoxCallBack1(ByVal SelectedIndex As Integer, ByVal c As System.Windows.Forms.ComboBox)
    Private Delegate Sub InvokeRadioButtonCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.RadioButton)
    Private Delegate Sub InvokeTreeViewCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.TreeView)
    Private Delegate Sub InvokeListBoxCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.ListBox)
    Private Delegate Sub InvokeStatusLabelCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.ToolStripStatusLabel)
    Private Delegate Sub InvokeDataGridViewCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.DataGridView)
    Private Delegate Sub InvokePictureBoxCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.PictureBox)
    Private Delegate Sub InvokeGroupBoxVisibaleCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.GroupBox)
    Private Delegate Sub InvokePropertyGridCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.PropertyGrid)
    Private Delegate Sub InvokeCheckBoxCallBack(ByVal Status As Boolean, ByVal c As System.Windows.Forms.CheckBox)
    Private Delegate Sub InvokeForm1CallBack(ByVal c As System.Windows.Forms.Form)
    Private Delegate Sub InvokeToolTipCallBack(ByVal Message As String, ByVal c As System.Windows.Forms.ToolTip, ByVal parent As Control)
    Private Delegate Sub InvokeDrawCutLineCallBack(ByVal workStep As Integer, ByVal cutIdx As Integer)
    Private Delegate Sub InvokeDrawCutLineCallBack2(ByVal workStep As Integer)

    Private Sub InvokeToolStripStatusLabel(ByVal text As String, ByVal c As System.Windows.Forms.ToolStripStatusLabel)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeToolStripStatusLabelCallBack(AddressOf InvokeToolStripStatusLabel)
                Me.BeginInvoke(cb, text, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = text
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeToolStripStatusLabel")

        End Try
    End Sub
    Private Sub InvokeForm(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Form)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeFormCallBack(AddressOf InvokeForm)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Visible = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeForm")

        End Try
    End Sub
    Private Sub InvokeToolTip(ByVal text As String, ByVal c As System.Windows.Forms.ToolTip, ByVal parent As Control)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeToolTipCallBack(AddressOf InvokeToolTip)
                Me.BeginInvoke(cb, text, c, parent)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.SetToolTip(parent, text)
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeToolTip")

        End Try
    End Sub
    Private Sub InvokePropertyGrid(ByVal Status As Boolean, ByVal c As System.Windows.Forms.PropertyGrid)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokePropertyGridCallBack(AddressOf InvokePropertyGrid)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeForm")

        End Try
    End Sub
    Private Sub InvokeTimer(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Timer)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeTimerCallBack(AddressOf InvokeTimer)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeTimer")
        End Try
    End Sub
    Private Sub InvokeButton(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Button)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeButtonCallBack(AddressOf InvokeButton)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeButton")

        End Try
    End Sub

    Private Sub InvokeForm1(ByVal c As System.Windows.Forms.Form)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeForm1CallBack(AddressOf InvokeForm1)
                Me.BeginInvoke(cb, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Show()
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Information, "InvokeForm1")
        End Try
    End Sub

    Private Sub InvokeCheckBox(ByVal Status As Boolean, ByVal c As System.Windows.Forms.CheckBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeCheckBoxCallBack(AddressOf InvokeCheckBox)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Information, "InvokeCheckBox")
        End Try
    End Sub
    Private Sub InvokeLabel(ByVal Message As String, ByVal c As System.Windows.Forms.Label)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeLabelCallBack(AddressOf InvokeLabel)
                Me.BeginInvoke(cb, Message, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = Message
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeLabel")

        End Try
    End Sub
    Private Sub InvokeControlText(ByVal Message As String, ByVal c As System.Windows.Forms.Control)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeControlTextCallBack(AddressOf InvokeControlText)
                Me.BeginInvoke(cb, Message, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = Message
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeControlText")

        End Try
    End Sub
    Private Sub InvokeButtonText(ByVal Message As String, ByVal c As System.Windows.Forms.Button)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeButtonTextCallBack(AddressOf InvokeButtonText)
                Me.BeginInvoke(cb, Message, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = Message
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeButtonText")

        End Try
    End Sub
    Private Sub InvokeNumericUpDown(ByVal Value As Integer, ByVal c As System.Windows.Forms.NumericUpDown)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeNumericUpDownCallBack(AddressOf InvokeNumericUpDown)
                Me.BeginInvoke(cb, Value, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Value = Value
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeNumericUpDown")

        End Try
    End Sub
    Private Sub InvokePanel(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Panel)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokePanelCallBack(AddressOf InvokePanel)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeNumericUpDown1")

        End Try
    End Sub
    Private Sub InvokePanelVisible(ByVal Status As Boolean, ByVal c As System.Windows.Forms.Panel)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokePanelCallBack2(AddressOf InvokePanelVisible)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Visible = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeNumericUpDown1")

        End Try
    End Sub
    Private Sub InvokeNumericUpDown1(ByVal Status As Boolean, ByVal c As System.Windows.Forms.NumericUpDown)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeNumericUpDown1CallBack(AddressOf InvokeNumericUpDown1)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeNumericUpDown1")

        End Try
    End Sub
    Private Sub InvokeComboBox(ByVal Status As Boolean, ByVal c As System.Windows.Forms.ComboBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeComboBoxCallBack(AddressOf InvokeComboBox)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeComboBox")

        End Try
    End Sub
    Private Sub InvokeComboBox1(ByVal SelectedIndex As Integer, ByVal c As System.Windows.Forms.ComboBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeComboBoxCallBack1(AddressOf InvokeComboBox1)
                Me.BeginInvoke(cb, SelectedIndex, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.SelectedIndex = SelectedIndex
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeComboBox1")

        End Try
    End Sub
    Private Sub InvokeTextBox(ByVal Status As Boolean, ByVal c As System.Windows.Forms.TextBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeTextBoxCallBack(AddressOf InvokeTextBox)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeTextBox")

        End Try
    End Sub

    Private Sub InvokeTextBoxText(ByVal Status As String, ByVal c As System.Windows.Forms.TextBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeTextBoxTextCallBack(AddressOf InvokeTextBoxText)
                '  Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeTextBox")

        End Try
    End Sub

    Private Sub InvokeRadioButton(ByVal Status As Boolean, ByVal c As System.Windows.Forms.RadioButton)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeRadioButtonCallBack(AddressOf InvokeRadioButton)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeRadioButton")

        End Try
    End Sub
    Private Sub InvokeTreeView(ByVal Status As Boolean, ByVal c As System.Windows.Forms.TreeView)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeTreeViewCallBack(AddressOf InvokeTreeView)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeTreeView")

        End Try
    End Sub
    Private Sub InvokeListBox(ByVal Status As Boolean, ByVal c As System.Windows.Forms.ListBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeListBoxCallBack(AddressOf InvokeListBox)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Enabled = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeListBox")
        End Try
    End Sub
    Private Sub InvokeStatusLabel(ByVal Message As String, ByVal c As System.Windows.Forms.ToolStripStatusLabel)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeStatusLabelCallBack(AddressOf InvokeStatusLabel)
                Me.BeginInvoke(cb, Message, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Text = Message
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeStatusLabel")
        End Try
    End Sub
    Private Sub InvokeGroupBoxVisibale(ByVal Status As Boolean, ByVal c As System.Windows.Forms.GroupBox)
        Try
            If Me.InvokeRequired() Then
                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeGroupBoxVisibaleCallBack(AddressOf InvokeGroupBoxVisibale)
                Me.BeginInvoke(cb, Status, c)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                c.Visible = Status
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?InvokeForm")

        End Try
    End Sub
#End Region

    Private Function CallLogin() As Boolean
        Dim frm As FLogin = New FLogin()
        frm.ShowDialog()
        Dim loginOK As Boolean = frm.LoginOK
        frm.Dispose()
        Return loginOK
    End Function


    Public Sub New()
        m_Logs = New List(Of Clog)
        AddLog("啟動程式", enumLogType.OpenClose)
        If (CallLogin()) Then
            m_FLoading = New FLoading(CChangeLanguage.GetString("正在加載程式..."))
            m_FLoading.Show()
            m_FLoading.Percent = 5
            CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
            ' This call is required by the designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.
            ToolStripStatusLabel4.Visible = ISDEBUG
            ToolStripStatusLabel7.Visible = ISDEBUG
            lblXPx.Visible = ISDEBUG
            lblYPx.Visible = ISDEBUG

            m_FLoading.Percent = 25
            m_threadWriteLog = New Thread(AddressOf SubWriteLog)
            m_WriteLogFlag = True
            m_WriteLogComplete = True
            m_threadWriteLog.Priority = ThreadPriority.Lowest
            m_threadWriteLog.IsBackground = True
            m_threadWriteLog.Start()
            m_FLoading.Percent = 50

        Else
            MLog.SaveLog("啟動程式", enumLogType.OpenClose)
            MLog.SaveLog("登錄失敗", enumLogType.OpenClose)
            MLog.SaveLog("程式關閉", enumLogType.OpenClose)
            m_Logs.Clear()
            Environment.Exit(1)
        End If

    End Sub
    Private Sub SubWriteLog()
        While m_WriteLogFlag
            If (m_WriteLogComplete AndAlso m_Logs.Count <> 0) Then
                m_WriteLogComplete = False
                Try
                    Dim log As Clog = m_Logs(0)
                    While (log Is Nothing)
                        log = m_Logs(0)
                    End While
                    m_Logs.RemoveAt(0)
                    If (log IsNot Nothing) Then
                        If (log.NumPram = 2) Then
                            InvokeListBoxLog(log.DateAndTime.ToString("HH:mm:ss") & ": " & CChangeLanguage.GetString(log.LogString))
                        ElseIf (log.NumPram = 3) Then
                            InvokeListBoxLog(log.DateAndTime.ToString("HH:mm:ss") & ": " & CChangeLanguage.GetString(log.LogString) & ": " & log.NewValue)
                        Else
                            InvokeListBoxLog(log.DateAndTime.ToString("HH:mm:ss") & ": " & CChangeLanguage.GetString(log.LogString) & " " & log.NewValue)
                        End If
                        MLog.SaveLog(log)
                    End If
                Catch
                End Try
                m_WriteLogComplete = True
            Else
                Thread.Sleep(1000)
            End If
        End While
    End Sub
    Private Sub AddLog(ByVal strLog As String, ByVal LogType As enumLogType)
        m_Logs.Add(New Clog(strLog, LogType))
    End Sub
    Private Sub AddLog(ByVal strLog As String, ByVal newValue As String, ByVal LogType As enumLogType)
        m_Logs.Add(New Clog(strLog, newValue, LogType))
    End Sub
    Private Sub AddLog(ByVal paramName As String, ByVal oldValue As String, ByVal newValue As String, ByVal LogType As enumLogType)
        m_Logs.Add(New Clog(paramName, oldValue, newValue, LogType))
    End Sub
    Private Sub InvokeListBoxLog(ByVal strLog As String)
        If (Me.InvokeRequired) Then
            Me.BeginInvoke(Sub() InvokeListBoxLog(strLog))
        Else
            lbLog.Items.Insert(0, strLog)
            lbLog.SelectedIndex = 0
            If (lbLog.Items.Count > 100) Then
                lbLog.Items.RemoveAt(100)
            End If
        End If
    End Sub

    Private Sub SetPermission()

        If (CLoginInformation.CurrentUser.Permission <= 0) Then
            btnAddLine.Enabled = False
            btnDelete.Enabled = False
            If (TabControl1.TabPages.IndexOf(TabPageLaserParam) > -1) Then
                TabControl1.TabPages.Remove(TabPageAlignment)
            End If
            If (TabControl1.TabPages.IndexOf(TabPageCorrection) > -1) Then
                TabControl1.TabPages.Remove(TabPageCorrection)
            End If
            If (TabControl1.TabPages.IndexOf(TabPageLaserParam) > -1) Then
                TabControl1.TabPages.Remove(TabPageLaserParam)
            End If
            btnSavePos.Enabled = False
            btnWorkholderSet0.Enabled = False
            btnWorkholderSet1.Enabled = False
            btnWorkholderSet2.Enabled = False
            btnWorkholderSet3.Enabled = False
            btnWorkholderSet4.Enabled = False
            grbGraphicParameter.Visible = False
            grbGalvoParameter.Visible = False
            btnNewProject.Enabled = False
            btnSave.Enabled = False
            If (PropertyGrid1.SelectedObject IsNot Nothing) Then
                TypeDescriptor.AddAttributes(PropertyGrid1.SelectedObject, New Attribute() {New ReadOnlyAttribute(True)})
                PropertyGrid1.SelectedObject = PropertyGrid1.SelectedObject
            End If
            LoginToolStripMenuItem.Text = CChangeLanguage.GetString("登錄")
            AddLog("打開操作員畫面", enumLogType.OpenClose)
        Else
            AddLog("打開" & CLoginInformation.CurrentUser.Username & "畫面", enumLogType.OpenClose)
            btnAddLine.Enabled = True
            btnDelete.Enabled = True
            btnNewProject.Enabled = True
            btnSave.Enabled = True
            grbGraphicParameter.Visible = False
            grbGalvoParameter.Visible = False
            btnSavePos.Enabled = True
            btnWorkholderSet0.Enabled = True
            btnWorkholderSet1.Enabled = True
            btnWorkholderSet2.Enabled = True
            btnWorkholderSet3.Enabled = True
            btnWorkholderSet4.Enabled = True
            If (PropertyGrid1.SelectedObject IsNot Nothing) Then
                TypeDescriptor.AddAttributes(PropertyGrid1.SelectedObject, New Attribute() {New ReadOnlyAttribute(False)})
                PropertyGrid1.SelectedObject = PropertyGrid1.SelectedObject
            End If
            If (TabControl1.TabPages.IndexOf(TabPageAlignment) = -1) Then
                TabControl1.TabPages.Insert(1, TabPageAlignment)
            End If
            If (TabControl1.TabPages.IndexOf(TabPageLaserParam) = -1) Then
                TabControl1.TabPages.Insert(1, TabPageLaserParam)
            End If
            LoginToolStripMenuItem.Text = CChangeLanguage.GetString("登出")
            If (CLoginInformation.CurrentUser.Permission < 999) Then
                If (TabControl1.TabPages.IndexOf(TabPageCorrection) = -1) Then
                    TabControl1.TabPages.Insert(3, TabPageCorrection)
                End If
                If (TabControl2.TabPages.IndexOf(TabPage3) > -1) Then
                    TabControl2.TabPages.Remove(TabPage3)
                End If
            Else
                If (TabControl1.TabPages.IndexOf(TabPageCorrection) = -1) Then
                    TabControl1.TabPages.Insert(3, TabPageCorrection)
                End If
                If (TabControl2.TabPages.IndexOf(TabPage3) = -1) Then
                    TabControl2.TabPages.Insert(1, TabPage3)
                End If
            End If
        End If
    End Sub

    Private Sub FMain_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If (FMessageBox.Show(Me, CChangeLanguage.GetString("您確定要退出程式嗎?"), CChangeLanguage.GetString("關閉消息"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = Windows.Forms.DialogResult.OK) Then
            If (m_FlagSave) Then
                If (FMessageBox.Show(Me, CChangeLanguage.GetString("未保存任何更改。 您要保存項目嗎?"), CChangeLanguage.GetString("保存項目消息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    m_NoMessageShow = True
                    btnSave_Click(Nothing, Nothing)
                End If
            End If

            Try
                Me.Enabled = False
                m_Param.Flags.System.KeyCode = enumKeyConst.KeyMainExit

            Catch ex As Exception
                Call FMessageBox.Show(Me, CChangeLanguage.GetString("關閉程式時出錯。"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            End Try

            Call Me.ImageDisplay1.StopLive()
            Me.Hide()
            AddLog("關閉程式", enumLogType.StartStop)
            m_FLoading = New FLoading(CChangeLanguage.GetString("關閉程式中..."))
            m_FLoading.Show()
            m_FLoading.Percent = 25
            Thread.Sleep(10)
            While (m_threadWriteLog.IsAlive)
                m_FLoading.Percent += 25
                If (m_WriteLogComplete) Then
                    If (m_Logs.Count = 0) Then
                        m_WriteLogFlag = False
                        Application.DoEvents()
                    End If
                End If
            End While

            Do
                Call Application.DoEvents()
                If m_BackgroundThread.IsAlive Then
                Else
                    Exit Do
                End If
            Loop
            m_FLoading.Percent = 100
            m_FLoading.Close()
            m_FLoading.Dispose()
            m_FLoading = Nothing

        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub FDawLine_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TabControl1.TabPages.Remove(TabPageStepByStep)
        m_FLoading.Percent = 55
        m_Cross = New VisionSystem.CReticle
        'X0 = grbCamera.Width / 2
        'Y0 = grbCamera.Height / 2
        ViewImageWidth = grbCamera.Width
        ViewImageHeight = grbCamera.Height
        m_Timer = New Timer.CHighResolutionTimer()

        m_ListLine = New List(Of CLine)
        ReDim m_SysProcessNum(0 To enumSys.Maximum)
        ReDim m_SysTime(0 To enumSys.Maximum)
        m_Param = New CParam("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
        ' numPX2MM.Value = m_Param.Variable.Graphic.PX2MM
        'numGalvoAngle.Value = m_Param.Variable.Laser.Angle
        'numGalvoOffsetX.Value = m_Param.Variable.Laser.OffsetX
        ' numGalvoOffsetY.Value = m_Param.Variable.Laser.OffsetY
        numDIDelay.Value = m_Param.Variable.IO.DIDelay
        numDODelay.Value = m_Param.Variable.IO.DODelay
        numImageOffsetX.Value = m_Param.Variable.Graphic.OffsetX
        numImageOffsetY.Value = m_Param.Variable.Graphic.OffsetY
        numBlow1Delay.Value = m_Param.Variable.IO.Blow1Delay
        chkUseBlow2.Checked = m_Param.Variable.IO.UseBlow2

        m_Acquist = New VisionSystem.CAcquisition(0)


        Dim image As VisionSystem.CImage
        image = New VisionSystem.CImage
        Call m_Acquist.Acquist(0, True)
        Call m_Acquist.CopyTo(0, image)
        VisionImageWidth = image.Width '659
        VisionImageHeight = image.Height '494
        m_Cross.X = image.Width / 2.0 + m_Param.Variable.Graphic.OffsetX
        m_Cross.Y = image.Height / 2.0 + m_Param.Variable.Graphic.OffsetY
        m_Cross.Length = 1000

        VisionToViewScaleH = ViewImageHeight / VisionImageHeight
        VisionToViewScaleW = ViewImageWidth / VisionImageWidth

        Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
        Call Me.ImageDisplay1.StartLive(0, m_Acquist)

        m_Param.Flags.System.ProductLoaded = False
        m_Laser = New CLaser(m_Param, m_Timer)
        btnGlavoHome_Click(Nothing, Nothing)

        m_FLoading.Percent = 75
        ReDim m_FErrorMsg(0 To enumSys.Maximum)
        For i As Integer = 0 To enumSys.Maximum
            m_FErrorMsg(i) = New FMessageBox
        Next
        If m_SysCmd Is Nothing Then m_SysCmd = New CSystemCommand
        If m_SysSts Is Nothing Then m_SysSts = New CSystemStatus
        If m_Motion Is Nothing Then m_Motion = New CMotion(enumAxis.Maximum, "D:\DataSettings\LaserMachine\")
        If Not (m_Motion.Init() = True) Then
            Call FMessageBox.Show(CChangeLanguage.GetString("軸卡啟動異常"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Call Debug.Assert(False)
            End
        End If
        Dim cylName(0 To enumCyl.Maximum - 1) As String
        Dim snrName(0 To enumSnr.Maximum - 1) As String
        For aryIdx As Integer = LBound(cylName) To UBound(cylName)
            cylName(aryIdx) = "Reserved" & aryIdx
        Next

        'cylName(0) = "TrayInForwardReverse"
        'cylName(1) = "TrayInUpDown"
        'cylName(2) = "TrayInRotateInverseReverse"
        'cylName(3) = "WorkholderStand"
        'cylName(4) = "TrayInZUpDown"
        'cylName(5) = "WorkholderForwardReverse"

        cylName(8) = "WorkholderVaccum"
        cylName(9) = "TrayInUpDown"
        cylName(10) = "TrayOutUpDown"
        cylName(11) = "TrayOutLeftRight"
        cylName(12) = "Blow1"
        cylName(13) = "Blow2"
        cylName(16) = "MagnetOnOff"




        For aryIdx As Integer = LBound(snrName) To UBound(snrName)
            snrName(aryIdx) = "Reserved" & aryIdx
        Next
        'snrName(0) = "WorkholderVaccum"
        'snrName(1) = "WorkholderStandOK"
        'snrName(2) = "WorkholderStandOrign"
        'snrName(3) = "WorkholderForward"
        'snrName(4) = "WorkholderReverse"
        'snrName(5) = "TrayInZUpLimit"
        'snrName(6) = "TrayInZDownLimit"
        'snrName(7) = "TrayInForward"
        'snrName(8) = "TrayInReverse"
        'snrName(9) = "TrayInDownLimit"
        'snrName(10) = "TrayInUpLimit"
        'snrName(11) = "TrayInRotateOrg"
        'snrName(12) = "TrayInRotateReverse"
        snrName(8) = "WorkholderVaccum"
        snrName(13) = "TrayInDownLimit"
        snrName(14) = "TrayInUpLimit"
        snrName(15) = "TrayOutLeftLimit"
        snrName(16) = "TrayOutRightLimit"
        snrName(17) = "TrayOutDownLimit"
        snrName(18) = "TrayOutUpLimit"




        numWorkhodlerX0.Value = m_Param.Pos.Workholder.SubstrateInX1
        numWorkhodlerX1.Value = m_Param.Pos.Workholder.WorkHolderCutX1
        numWorkhodlerX2.Value = m_Param.Pos.Workholder.WorkHolderCutX2
        numWorkhodlerX3.Value = m_Param.Pos.Workholder.SubstrateOutX1
        numWorkhodlerX4.Value = m_Param.Pos.Workholder.SubstratePunchX
        numWorkhodlerX5.Value = m_Param.Pos.Workholder.SubstrateBlowX

        If m_DA Is Nothing Then m_DA = New CDAQ(cylName, snrName, "D:\DataSettings\LaserMachine\")
        For cylIndex = 0 To (enumCyl.Maximum - 1)
            m_DA.DigO.CylGo(cylIndex, enumCyllogic.Normal)
        Next
        cboCalibrationRange.Items.Add(eCalibrationSize.e3x3)
        cboCalibrationRange.Items.Add(eCalibrationSize.e5x5)
        cboCalibrationRange.Items.Add(eCalibrationSize.e7x7)
        cboCalibrationRange.Items.Add(eCalibrationSize.e9x9)
        cboCalibrationRange.Items.Add(eCalibrationSize.e11x11)
        cboCalibrationRange.Items.Add(eCalibrationSize.e13x13)
        cboCalibrationRange.Items.Add(eCalibrationSize.e15x15)

        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_3x3)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_5x5)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_7x7)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_9x9)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_11x11)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_13x13)
        cboAutoCalibrationRange.Items.Add(eCorrectionRange.R_15x15)
        cboAutoCalibrationRange.SelectedIndex = 0

        m_BackgroundThread = New Thread(New ThreadStart(AddressOf Main))
        m_BackgroundThread.IsBackground = False
        m_BackgroundThread.Priority = ThreadPriority.AboveNormal
        m_BackgroundThread.Start()
        m_FLoading.Percent = 100
        m_FLoading.Close()
        m_FLoading.Dispose()
        m_FLoading = Nothing

        Do
            Call Application.DoEvents()
            If m_BackgroundThread.IsAlive Then
                Exit Do
            Else
            End If
        Loop
        SetPermission()
        AddHandler ImageDisplay1.ImageDisplay_MouseMove2, AddressOf ImageDisplay1_ImageDisplay_MouseMove2


        dgvWorkStepByStep.Rows.Clear()
        dgvWorkStepByStep.Rows.Add(New Object() {"1", CChangeLanguage.GetString("送料位置")})
        dgvWorkStepByStep.Rows.Add(New Object() {"2", CChangeLanguage.GetString("吹氣1位置")})
        dgvWorkStepByStep.Rows.Add(New Object() {"3", CChangeLanguage.GetString("沖壓位置")})
        dgvWorkStepByStep.Rows.Add(New Object() {"4", CChangeLanguage.GetString("切割位置1")})
        dgvWorkStepByStep.Rows.Add(New Object() {"5", CChangeLanguage.GetString("切割位置2")})
        dgvWorkStepByStep.Rows.Add(New Object() {"6", CChangeLanguage.GetString("收料位置")})
        For i = 0 To dgvWorkStepByStep.Rows.Count - 1
            dgvWorkStepByStep.Rows(i).Height = 50
        Next



    End Sub

    Private Sub btnAddLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddLine.Click
        If (m_CurrentProject Is Nothing) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        If (m_CurrentProject IsNot Nothing) Then
            If (m_SelectedStep <= 0) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("請先選擇工作步驟"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            TreeView1.BeginUpdate()
            Dim line As CLine = New CLine()
            line.[Step] = m_SelectedStep
            m_ListLine.Add(line)
            m_ListOriginalLine.Add(line)
            TreeView1.Nodes(0).Nodes(m_SelectedStep - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))


            For s = 1 To m_CurrentProject.WorkStep
                Dim idx As Integer = 0
                For i = 0 To m_ListLine.Count - 1
                    If (m_ListLine(i).[Step] = s) Then
                        m_ListLine(i).Name = "LINE" & (idx + 1).ToString()
                        TreeView1.Nodes(0).Nodes(s - 1).Nodes(idx).Name = m_ListLine(i).ID
                        TreeView1.Nodes(0).Nodes(s - 1).Nodes(idx).Tag = m_ListLine(i)
                        TreeView1.Nodes(0).Nodes(s - 1).Nodes(idx).Text = String.Format(CChangeLanguage.GetString("第{0}線"), (idx + 1))
                        idx += 1
                    End If
                Next
            Next

            Dim newLineCtrl As CLineCtrl = New CLineCtrl(grbCamera.Size, line.StartXPX, line.StartYPX, line.EndXPX, line.EndYPX, m_Param.Variable.Graphic.LineColor)
            newLineCtrl.Name = line.ID
            newLineCtrl.TabIndex = line.[Step]

            grbCamera.Controls.Add(newLineCtrl)
            newLineCtrl.BringToFront()
            AddHandler newLineCtrl.MouseUp, AddressOf Control_MouseUp
            AddHandler newLineCtrl.MouseDown, AddressOf Control_MouseDown
            AddHandler newLineCtrl.MouseDoubleClick, AddressOf Control_MouseDoubleClick

            AddHandler newLineCtrl.MouseEnter, AddressOf Control_MouseEnter
            AddHandler newLineCtrl.MouseLeave, AddressOf Control_MouseLeave
            AddHandler newLineCtrl.MouseMove, AddressOf Control_MouseMove

            SortJob()
            m_FlagSave = True
            TreeView1.ExpandAll()
            TreeView1.EndUpdate()
        Else
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
        End If
    End Sub



    Private Sub treeView_DrawNode(ByVal sender As Object, ByVal e As DrawTreeNodeEventArgs) Handles TreeView1.DrawNode
        If e.Node Is Nothing Then Return
        Dim selected = (e.State And TreeNodeStates.Selected) = TreeNodeStates.Selected
        Dim unfocused = Not e.Node.TreeView.Focused

        If selected AndAlso unfocused Then
            Dim font = If(e.Node.NodeFont, e.Node.TreeView.Font)
            e.Graphics.FillRectangle(SystemBrushes.Highlight, e.Bounds)
            TextRenderer.DrawText(e.Graphics, e.Node.Text, font, e.Bounds, SystemColors.HighlightText, TextFormatFlags.GlyphOverhangPadding)
        Else
            e.DrawDefault = True
        End If
    End Sub

    Private m_SelectedNodes As ArrayList = New ArrayList()
    Private m_ClickNode As TreeNode = Nothing
    Private m_StartIdxSelected As Integer

    Private Sub TreeView1_NodeMouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick
        'TreeView1.BeginUpdate()
        Try
            m_ClickNode = e.Node
            Select Case e.Node.Level
                Case 0
                    RemoveSelectedBackground(m_SelectedNodes)
                    m_SelectedNodes.Clear()
                    m_SelectedStep = -1
                    PropertyGrid1.SelectedObject = m_CurrentProject
                    m_LineSelected = Nothing
                    For i = 0 To m_ListLine.Count - 1
                        Dim ctrlline As CLineCtrl = CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl)
                        ctrlline.Visible = True
                        ctrlline.IsSelect = False
                    Next
                Case 1
                    RemoveSelectedBackground(m_SelectedNodes)
                    m_SelectedNodes.Clear()
                    m_SelectedNodes.Add(e.Node)
                    m_SelectedStep = CType(e.Node.Tag, Integer)
                    PropertyGrid1.SelectedObject = Nothing
                    m_LineSelected = Nothing
                    For i = 0 To m_ListLine.Count - 1
                        Dim ctrlline As CLineCtrl = CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl)
                        If (m_SelectedStep <> ctrlline.TabIndex) Then
                            ctrlline.Visible = False
                        Else
                            ctrlline.Visible = True
                        End If
                        ctrlline.IsSelect = False
                    Next
                    If (m_Param.Flags.System.SysInitHomeOk = True) Then
                        If (m_SelectedStep = 1) Then
                            btnWorkholderMove_Click(btnWorkholderMove1, Nothing)
                        ElseIf (m_SelectedStep = 2) Then
                            btnWorkholderMove_Click(btnWorkholderMove2, Nothing)
                        End If
                    End If

                Case 2
                    Dim line As CLine = CType(e.Node.Tag, CLine)
                    Dim shift As Boolean = (ModifierKeys = Keys.Shift)
                    Dim ctrl As Boolean = (ModifierKeys = Keys.Control)

                    If (line IsNot Nothing) Then
                        If (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count = 0) Then
                            m_SelectedNodes.Add(e.Node)
                        Else
                            RemoveSelectedBackground(m_SelectedNodes)
                            TreeView1.SelectedNode = Nothing
                            Dim startNode As TreeNode = CType(m_SelectedNodes(0), TreeNode)
                            Dim rootNode As TreeNode = startNode.Parent
                            'If (startNode.Parent IsNot e.Node.Parent) Then
                            '    m_SelectedNodes.Clear()
                            '    m_SelectedNodes.Add(e.Node)
                            'Else

                            If (shift = True) Then
                                m_SelectedNodes.Clear()
                                If (m_StartIdxSelected < e.Node.Index) Then
                                    For idx = m_StartIdxSelected To e.Node.Index
                                        m_SelectedNodes.Add(rootNode.Nodes(idx))
                                    Next
                                Else
                                    For idx = e.Node.Index To m_StartIdxSelected
                                        m_SelectedNodes.Add(rootNode.Nodes(idx))
                                    Next
                                End If
                            ElseIf (ctrl = True) Then
                                If (m_SelectedNodes.IndexOf(e.Node) > -1) Then
                                    m_SelectedNodes.Remove(e.Node)
                                Else
                                    m_SelectedNodes.Add(e.Node)
                                End If
                            Else
                                m_SelectedNodes.Clear()
                                m_SelectedNodes.Add(e.Node)
                            End If
                            'End If 
                        End If

                        AddSelectedBackground(m_SelectedNodes)


                        m_SelectedStep = line.[Step]
                        For i = 0 To m_ListLine.Count - 1
                            If (m_ListLine(i).ID = line.ID) Then
                                m_LineSelected = m_ListLine(i)
                                m_ListLine(i).IsSelected = True
                                Dim ctrlline As CLineCtrl = CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl)
                                If (m_SelectedStep <> ctrlline.TabIndex) Then
                                    ctrlline.Visible = False
                                Else
                                    ctrlline.Visible = True
                                End If
                                ctrlline.IsSelect = True
                            Else
                                m_ListLine(i).IsSelected = False
                                Dim ctrlline As CLineCtrl = CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl)
                                If (m_SelectedStep <> ctrlline.TabIndex) Then
                                    ctrlline.Visible = False
                                Else
                                    ctrlline.Visible = True
                                End If
                                ctrlline.IsSelect = False
                            End If
                        Next
                        'If (CLoginInformation.CurrentUser.Permission <= 0) Then
                        TypeDescriptor.AddAttributes(m_LineSelected, New Attribute() {New ReadOnlyAttribute(True)})
                        'Else
                        'TypeDescriptor.AddAttributes(m_LineSelected, New Attribute() {New ReadOnlyAttribute(False)})
                        'End If
                        PropertyGrid1.SelectedObject = m_LineSelected
                        InvokeToolStripStatusLabel(m_LineSelected.LaserPRR.ToString().PadLeft(4, " ") & "kHz", lblLaserPRR)
                        InvokeToolStripStatusLabel(m_LineSelected.LaserPower.ToString().PadLeft(4, " ") & "W", lblLaserPower)

                    End If
            End Select
            If (m_SelectedNodes.Count = 1) Then
                If (e.Node.Parent IsNot Nothing) Then
                    m_StartIdxSelected = e.Node.Index
                End If
                btnDrawSelecting.Enabled = True
            Else
                btnDrawSelecting.Enabled = False
            End If
        Catch ex As Exception

        End Try
        'TreeView1.EndUpdate()
    End Sub
    Private Sub RemoveSelectedBackground(ByVal pArrayNode As ArrayList)
        If (pArrayNode Is Nothing) Then
            Exit Sub
        End If
        For idx = 0 To pArrayNode.Count - 1
            Dim node As TreeNode = CType(pArrayNode(idx), TreeNode)
            Dim backColor = Color.White
            Dim forceColor As Color = Color.Black
            If (node.Tag IsNot Nothing) Then
                forceColor = System.Drawing.Color.Black
                backColor = System.Drawing.Color.White
                node.ForeColor = forceColor
                node.BackColor = Color.White
            Else
                node.ForeColor = forceColor
                node.BackColor = Color.White
            End If
        Next
    End Sub
    Private Sub AddSelectedBackground(ByVal pSelectedNodes As ArrayList)
        For idx = 0 To pSelectedNodes.Count - 1
            Dim node As TreeNode = CType(pSelectedNodes(idx), TreeNode)

            node.BackColor = System.Drawing.ColorTranslator.FromHtml("#0078d7")
            node.ForeColor = System.Drawing.Color.White
            TreeView1.Refresh()
        Next
    End Sub
    Private Function FoundNode(ByVal nodes As TreeNodeCollection, ByVal Idx As String) As TreeNode

        For i = 0 To nodes.Count - 1
            If (nodes(i).Name = Idx) Then
                Return nodes(i)
            Else

                For j = 0 To nodes(i).Nodes.Count - 1
                    Return FoundNode(nodes(i).Nodes(j).Nodes, Idx)
                Next
            End If
        Next
        Return Nothing
    End Function

    Private Sub Control_MouseDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button = MouseButtons.Left AndAlso CLoginInformation.CurrentUser.Permission > 0) Then
            Dim ctrl As Control = CType(sender, Control)
            Dim i As Integer
            For i = 0 To m_ListLine.Count - 1
                If (m_ListLine(i).ID = ctrl.Name) Then
                    m_LineSelected = m_ListLine(i)
                    Exit For
                End If
            Next

            Dim sNode As TreeNode = Nothing

            For s = 1 To m_CurrentProject.WorkStep
                Dim found As Boolean = False
                For i = 0 To TreeView1.Nodes(0).Nodes(s - 1).Nodes.Count - 1
                    If (TreeView1.Nodes(0).Nodes(s - 1).Nodes(i).Name = m_LineSelected.ID) Then
                        sNode = TreeView1.Nodes(0).Nodes(s - 1).Nodes(i)
                        found = True
                        Exit For
                    End If
                Next
                If (found) Then
                    Exit For
                End If
            Next
            TreeView1.SelectedNode = sNode
            TreeView1_NodeMouseClick(TreeView1, New TreeNodeMouseClickEventArgs(sNode, MouseButtons.Left, 1, 0, 0))
        End If
    End Sub

    Private Sub Control_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If (e.Button = MouseButtons.Left AndAlso CLoginInformation.CurrentUser.Permission > 0) Then
            m_MouseX = e.X ' - X0
            m_MouseY = e.Y '- Y0
            m_OldMouse = e.Location
            m_IsClicked = True
        End If
    End Sub

    Private Sub ImageDisplay1_ImageDisplay_MouseDown2(ByVal Location As System.Drawing.PointF, e As System.Windows.Forms.MouseEventArgs) Handles ImageDisplay1.ImageDisplay_MouseDown2
        If (e.Button = MouseButtons.Left AndAlso CLoginInformation.CurrentUser.Permission > 0) Then
            m_MouseX = Location.X ' - X0
            m_MouseY = Location.Y '- Y0
            m_OldMouse = Location
            m_IsClicked = True
            If (chkPickPoint.Checked = True) Then
                Try
                    Dim range As Integer = Math.Sqrt(cboCalibrationRange.SelectedItem)
                    For i = dgvImageValue.CurrentCell.RowIndex To dgvImageValue.CurrentCell.RowIndex + range - 1
                        dgvImageValue.Rows(i).Cells(1).Value = Location.X
                    Next
                Catch ex As Exception
                End Try
            End If
            If (chkPickY.Checked = True) Then
                Dim range As Integer = Math.Sqrt(cboCalibrationRange.SelectedItem)
                For i = dgvImageValue.CurrentCell.RowIndex To dgvImageValue.Rows.Count - 1
                    dgvImageValue.Rows(i).Cells(2).Value = Location.Y
                    i = i + range - 1
                Next
            End If
        End If
    End Sub

    Private Sub Control_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        m_IsStartSelected = False
        m_IsEndSelected = False
        m_IsClicked = False
    End Sub

    Private Sub ImageDisplay1_ImageDisplay_MouseUp2(ByVal Location As System.Drawing.PointF, e As System.Windows.Forms.MouseEventArgs) Handles ImageDisplay1.ImageDisplay_MouseUp2
        m_IsStartSelected = False
        m_IsEndSelected = False
        m_IsClicked = False
    End Sub


    Private Sub Control_MouseEnter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If (CLoginInformation.CurrentUser.Permission > 0) Then
            Dim ctrl As Control = CType(sender, Control)
            If (m_StartEdit) Then
                ctrl.Cursor = Cursors.Cross
            End If
        End If
    End Sub

    Private Sub Control_MouseLeave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ctrl As Control = CType(sender, Control)
        ctrl.Cursor = Cursors.Default
    End Sub

    Private Sub Control_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        ImageDisplay1_ImageDisplay_MouseMove2(New PointF(e.X / VisionToViewScaleW, e.Y / VisionToViewScaleH), e)
    End Sub

    Private Sub ImageDisplay1_ImageDisplay_MouseMove2(ByVal Location As System.Drawing.PointF, e As System.Windows.Forms.MouseEventArgs) 'ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        Try
            If m_Param.Flags.System.AutoRunProcedure = False Then
                m_MouseX = Location.X
                m_MouseY = Location.Y
                Dim galvoPosX, galvoPosY As Double

                FMain.ImagePointsToGalvoPosition(m_MouseX, m_MouseY, galvoPosX, galvoPosY)

                lblStatusX.Text = String.Format("{0,-8:0.0000}", galvoPosX) '.ToString("F3").PadLeft(6, " ") '((m_MouseX - X0) * PX2MM).ToString("F3").PadLeft(6, " ")
                lblStatusY.Text = String.Format("{0,-8:0.0000}", galvoPosY) '.ToString("F3").PadLeft(6, " ") ' ((grbCamera.Height - m_MouseY - Y0) * PX2MM).ToString("F3").PadLeft(6, " ")
                lblXPx.Text = String.Format("{0,-8:0.0000}", Location.X) 'Location.X.ToString()
                lblYPx.Text = String.Format("{0,-8:0.0000}", Location.Y) 'Location.Y.ToString()
                'lblStatusX.Text = ((m_MouseX - X0) * PX2MM).ToString("F3").PadLeft(6, " ")
                'lblStatusY.Text = ((grbCamera.Height - m_MouseY - Y0) * PX2MM).ToString("F3").PadLeft(6, " ")
                'Dim newXGalvo, newYGalvo As Double
                'Call ImagePointsToGalvoPosition(m_MouseX, m_MouseY, newXGalvo, newYGalvo)

                ' lblStatusX.Text = newXGalvo.ToString("F3").PadLeft(6, " ")
                'lblStatusY.Text = newYGalvo.ToString("F3").PadLeft(6, " ")
                If (m_OldMouse.X = m_MouseX AndAlso m_OldMouse.Y = m_MouseY) Then
                    Exit Sub
                End If
                If (m_VisionStart = True) Then
                    Exit Sub
                End If
                If (m_StartEdit And m_CalibrationStart AndAlso (m_SelectedNodes Is Nothing OrElse m_SelectedNodes.Count <= 1)) Then
                    If (CLoginInformation.CurrentUser.Permission > 0) Then
                        If (Math.Abs((m_LineSelected.StartXPX) - m_MouseX) <= m_MouseDeviation AndAlso Math.Abs((m_LineSelected.StartYPX) - m_MouseY) <= m_MouseDeviation) Then
                            ImageDisplay1.Cursor = Cursors.Cross
                        ElseIf (Math.Abs((m_LineSelected.EndXPX) - m_MouseX) <= m_MouseDeviation AndAlso Math.Abs((m_LineSelected.EndYPX) - m_MouseY) <= m_MouseDeviation) Then
                            ImageDisplay1.Cursor = Cursors.Cross
                        End If
                    End If
                    If (m_IsClicked = True AndAlso m_LineSelected IsNot Nothing) Then
                        If (Math.Abs((m_LineSelected.StartXPX) - m_MouseX) <= m_MouseDeviation AndAlso Math.Abs((m_LineSelected.StartYPX) - m_MouseY) <= m_MouseDeviation) Then
                            m_IsStartSelected = True
                            m_IsEndSelected = False
                        End If
                        If (Math.Abs((m_LineSelected.EndXPX) - m_MouseX) <= m_MouseDeviation AndAlso Math.Abs((m_LineSelected.EndYPX) - m_MouseY) <= m_MouseDeviation) Then
                            m_IsStartSelected = False
                            m_IsEndSelected = True
                        End If

                        If (m_IsStartSelected) Then
                            m_LineSelected.StartXPX += (m_MouseX - m_OldMouse.X)
                            m_LineSelected.StartYPX += (m_MouseY - m_OldMouse.Y)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                            m_FlagSave = True
                        ElseIf (m_IsEndSelected) Then
                            m_LineSelected.EndXPX += (m_MouseX - m_OldMouse.X)
                            m_LineSelected.EndYPX += (m_MouseY - m_OldMouse.Y)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                            m_FlagSave = True
                        End If
                        If (CLoginInformation.CurrentUser.Permission <= 0) Then
                            TypeDescriptor.AddAttributes(PropertyGrid1.SelectedObject, New Attribute() {New ReadOnlyAttribute(True)})
                        Else
                            TypeDescriptor.AddAttributes(PropertyGrid1.SelectedObject, New Attribute() {New ReadOnlyAttribute(False)})
                        End If
                        PropertyGrid1.SelectedObject = PropertyGrid1.SelectedObject
                        m_OldMouse = Location

                        Call ImageDisplay1.CopyOf(m_MatchingTool(m_SelectedStep - 1).Pattern.TrainImage)
                    End If
                Else
                    If (m_IsClicked = True AndAlso chkPickPoint.Checked = False AndAlso chkPickY.Checked = False AndAlso m_CalibrationStart = False) Then
                        m_IsClicked = False
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請停止相機進行編輯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    End If
                End If
            End If

        Catch
        End Try

    End Sub



    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            If (m_LineSelected IsNot Nothing) Then
                If (FMessageBox.Show(Me, CChangeLanguage.GetString("你確定刪除這條切割線嗎？"), CChangeLanguage.GetString("警告"), MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = DialogResult.Yes) Then
                    btnDelete.Enabled = False
                    TreeView1.BeginUpdate()
                    Try
                        m_ListLine.Remove(m_LineSelected)

                        For i = 0 To m_ListOriginalLine.Count - 1
                            If (m_ListOriginalLine(i).ID = m_LineSelected.ID) Then
                                m_ListOriginalLine.RemoveAt(i)
                                Exit For
                            End If
                        Next

                        TreeView1.Nodes.Clear()
                        TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))


                        For index = 1 To m_CurrentProject.WorkStep
                            TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                            TreeView1.Nodes(0).Nodes(index - 1).Tag = index
                            Dim idx2 As Integer = 0
                            For i = 0 To m_ListLine.Count - 1
                                If (m_ListLine(i).[Step] = index) Then
                                    TreeView1.Nodes(0).Nodes(index - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))
                                    m_ListLine(i).Name = "LINE" & (idx2 + 1).ToString()
                                    TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx2).Name = m_ListLine(i).ID
                                    TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx2).Tag = m_ListLine(i)
                                    TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx2).Text = String.Format(CChangeLanguage.GetString("第{0}線"), idx2 + 1)
                                    idx2 += 1
                                End If
                            Next
                        Next

                        For i = 0 To grbCamera.Controls.Count - 1
                            If (grbCamera.Controls(i).Name = m_LineSelected.ID) Then
                                RemoveHandler grbCamera.Controls(i).MouseUp, AddressOf Control_MouseUp
                                RemoveHandler grbCamera.Controls(i).MouseDown, AddressOf Control_MouseDown
                                RemoveHandler grbCamera.Controls(i).MouseDoubleClick, AddressOf Control_MouseDoubleClick

                                RemoveHandler grbCamera.Controls(i).MouseEnter, AddressOf Control_MouseEnter
                                RemoveHandler grbCamera.Controls(i).MouseLeave, AddressOf Control_MouseLeave
                                RemoveHandler grbCamera.Controls(i).MouseMove, AddressOf Control_MouseMove
                                grbCamera.Controls.RemoveAt(i)
                                Exit For
                            End If
                        Next

                        m_LineSelected = Nothing
                        PropertyGrid1.SelectedObject = Nothing
                    Catch
                    End Try
                    SortJob()
                    m_FlagSave = True
                    TreeView1.EndUpdate()
                    TreeView1.ExpandAll()
                    btnDelete.Enabled = True
                End If
            End If
        Catch
            TreeView1.EndUpdate()
        End Try
    End Sub

    Private m_ButtonClick As Integer = 0
    Private m_DrawLineFinished As Boolean = True
    Private m_DrawLineOK As Boolean = True
    Public Function DrawSelectingLine() As Boolean
        DrawSelectingLine = False
        m_DrawLineFinished = False
        m_DrawLineOK = False
        Try
            Dim lineCenterXInGalvo As Double = 0
            Dim lineCenterYInGalvo As Double = 0
            Dim newX1InGalvo As Double = 0
            Dim newY1InGalvo As Double = 0
            Dim newX2InGalvo As Double = 0
            Dim newY2InGalvo As Double = 0
            Dim offsetXInGalvo As Double = 0
            Dim offsetYInGalvo As Double = 0
            Dim angleInGalvo As Double = 0
            Dim idx As Integer = 0
            Dim workStep = m_LineSelected.[Step] - 1

            For i = 0 To m_ListLine.Count - 1
                If (m_ListLine(i).ID = m_LineSelected.ID) Then
                    idx = i
                    Exit For
                End If
            Next
            Call m_Laser.setstartlist(1)
            Call m_Laser.setScannerDelays(m_LineSelected.JumpDelay, m_LineSelected.MarkDelay, m_LineSelected.PolygonDelay)
            Call m_Laser.SetLaserDelays(m_LineSelected.LaserOnDelay, m_LineSelected.LaserOffDelay)
            Call m_Laser.SetJumpSpeed(5000)
            Call m_Laser.SetMarkSpeed(1000)
            Call m_Laser.JumpAbs(5000, 5000)
            Call m_Laser.SetEndofList()
            Call m_Laser.ExecuteList(1)
            Do

            Loop Until m_Laser.ListExecutionFinish = True
            If (Alignment(workStep) = False) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("對位失敗"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
            ReloadCutLine(workStep, idx)

            If (chkTest.Checked = True) Then
                Call AddLog("切:" & m_LineSelected.ToString & "測試", enumLogType.StartStop)
            Else
                Call AddLog("切:" & m_LineSelected.ToString, enumLogType.StartStop)
            End If




            'offsetXInGalvo = ((m_Param.Pos.Workholder.ImageAlignRealOffsetX - m_Param.Variable.Align.ImageOrginalOffsetX(workStep)))
            'offsetYInGalvo = ((m_Param.Pos.Workholder.ImageAlignRealOffsetY - m_Param.Variable.Align.ImageOrginalOffsetY(workStep)))
            'angleInGalvo = 0 '(m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(workStep))

            'lineCenterXInGalvo = m_Param.Variable.Align.ImageOrginalOffsetX(workStep) * PX2MM
            'lineCenterYInGalvo = m_Param.Variable.Align.ImageOrginalOffsetY(workStep) * PX2MM
            'offsetXInGalvo = offsetXInGalvo * PX2MM
            'offsetYInGalvo = offsetYInGalvo * PX2MM


            'CenterX = (m_LineSelected.StartX + m_LineSelected.EndX) / 2
            'CenterY = (m_LineSelected.StartY + m_LineSelected.EndY) / 2

            'Call NewPos(offsetXInGalvo, offsetYInGalvo, angleInGalvo, lineCenterXInGalvo, lineCenterYInGalvo, m_LineSelected.StartX, m_LineSelected.StartY, newX1InGalvo, newY1InGalvo)
            'Call NewPos(offsetXInGalvo, offsetYInGalvo, angleInGalvo, lineCenterXInGalvo, lineCenterYInGalvo, m_LineSelected.EndX, m_LineSelected.EndY, newX2InGalvo, newY2InGalvo)

            newX1InGalvo = m_LineSelected.StartX
            newY1InGalvo = m_LineSelected.StartY
            newX2InGalvo = m_LineSelected.EndX
            newY2InGalvo = m_LineSelected.EndY

            'FMain.GalvoPositionToEncoder(m_LineSelected.StartX, m_LineSelected.StartY, newX1InGalvo, newY1InGalvo)
            'FMain.GalvoPositionToEncoder(m_LineSelected.EndX, m_LineSelected.EndY, newX2InGalvo, newY2InGalvo)

            If (CheckRTCOutRange(newX1InGalvo, newY1InGalvo) = True) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If
            If (CheckRTCOutRange(newX2InGalvo, newY2InGalvo) = True) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If

            Call m_Laser.setstartlist(1)
            Call m_Laser.setScannerDelays(m_LineSelected.JumpDelay, m_LineSelected.MarkDelay, m_LineSelected.PolygonDelay)
            Call m_Laser.SetLaserDelays(m_LineSelected.LaserOnDelay, m_LineSelected.LaserOffDelay)
            Call m_Laser.SetJumpSpeed(m_LineSelected.JumpSpeed)
            Call m_Laser.SetMarkSpeed(m_LineSelected.MarkSpeed)

            If (m_LineSelected.RepeatMode = eRepeatMode.Mode1) Then
                For i = 1 To m_LineSelected.RepeatCount
                    Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                    Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                Next
            Else
                Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                For i = 1 To m_LineSelected.RepeatCount
                    If (i Mod 2 = 0) Then
                        Call m_Laser.MarkAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                    Else
                        Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                    End If
                Next
            End If
            Call m_Laser.SetEndofList()
            Call m_Laser.ExecuteList(1)
            InvokeButtonText(CChangeLanguage.GetString("停止"), btnDrawSelecting)
            InvokeButton(True, btnDrawSelecting)
            Do
                If (m_StopDrawWorkStep = True) Then
                    m_Laser.StopExecute()
                    InvokeButtonText(CChangeLanguage.GetString("剪切選擇"), btnDrawSelecting)
                    InvokeButton(True, btnDrawSelecting)
                    Exit Do
                End If
                If m_Laser.ListExecutionFinish = True Then Exit Do
            Loop
            'ReloadCutLine(workStep, idx)
            'm_Laser.LaserEmission = False
            DrawSelectingLine = True
            m_DrawLineOK = True
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("剪切選擇線錯誤。"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error, True, ex)
        End Try
        m_DrawLineFinished = True
    End Function

    Private m_StopDrawWorkStep As Boolean = False
    Private Sub DrawSelectingWorkStep()
        m_WorkComplete = False
        Call EnableDrawSelectingMode(True)
        Try
            If (SortJob() = False) Then
                Exit Try
            End If
            m_StopDrawWorkStep = False
            InvokeButtonText(CChangeLanguage.GetString("停止"), btnDrawSelecting)
            If (m_lstLineOnWorkStep(m_SelectedStep - 1).Count <= 0) Then
                MessageBox.Show(Me, CChangeLanguage.GetString("請先添加剪切線"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Try
            End If

            Dim idx As Integer = 0
            Do
                Application.DoEvents()
                m_LineSelected = m_ListLine(m_lstLineOnWorkStep(m_SelectedStep - 1)(idx))
                If (chkTest.Checked = True) Then
                Else
                    m_Laser.PRR = m_LineSelected.LaserPRR ' m_Param.Variable.Laser.PRR.ToString()
                    Threading.Thread.Sleep(100)
                    m_Laser.OperatingPower = m_LineSelected.LaserPower ' m_Param.Variable.Laser.Power.ToString()
                    InvokeToolStripStatusLabel(m_LineSelected.LaserPRR.ToString().PadLeft(4, " ") & "kHz", lblLaserPRR)
                    InvokeToolStripStatusLabel(m_LineSelected.LaserPower.ToString().PadLeft(4, " ") & "W", lblLaserPower)
                End If
                Call m_Laser.setstartlist(1)
                Call m_Laser.SetJumpSpeed(1000)
                Call m_Laser.JumpAbs(5000, 5000)
                Call m_Laser.SetEndofList()
                Call m_Laser.ExecuteList(1)
                Do

                Loop Until m_Laser.ListExecutionFinish = True
                Call DrawSelectingLine()
                Do

                Loop Until m_Laser.ListExecutionFinish = True AndAlso m_DrawLineFinished = True

                If (m_DrawLineOK = False) Then
                    Exit Do
                End If
                idx = idx + 1
            Loop Until m_StopDrawWorkStep = True OrElse idx >= m_lstLineOnWorkStep(m_SelectedStep - 1).Count
            m_Laser.LaserEmission = False
            Call ImageDisplay1.StartLive(0, m_Acquist)
            InvokeButtonText(CChangeLanguage.GetString("剪切選擇"), btnDrawSelecting)

            Call AddLog("切: 第" & m_SelectedStep.ToString() & "步完成！", enumLogType.StartStop)
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("剪切選擇線錯誤。"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error, True, ex)
        End Try
        Call EnableDrawSelectingMode(False)
        InvokeButton(True, btnDrawSelecting)
        m_WorkComplete = True
    End Sub

    Private Sub brnDraw_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDrawSelecting.Click
        If (m_Param.Flags.System.SysInitHomeOk = True) Then
            If (btnDrawSelecting.Text = CChangeLanguage.GetString("停止")) Then
                m_StopDrawWorkStep = True
                Call AddLog("切: 第" & m_SelectedStep.ToString() & "步已取消！", enumLogType.StartStop)
            Else
                If (m_CurrentProject Is Nothing) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    Exit Sub
                End If

                btnDrawSelecting.Enabled = False

                If (chkTest.Checked = True) Then
                    m_Laser.LaserEmission = False
                    m_Laser.LaserGuide = True
                Else
                    m_Laser.LaserGuide = False
                    m_Laser.LaserEmission = True
                    Threading.Thread.Sleep(3000)
                End If


                Try
                    Call ImageDisplay1.StopLive()
                    If (m_LineSelected IsNot Nothing) Then
                        Call EnableDrawSelectingMode(True)

                        If (chkTest.Checked = True) Then
                        Else
                            m_Laser.PRR = m_LineSelected.LaserPRR
                            Threading.Thread.Sleep(100)
                            m_Laser.OperatingPower = m_LineSelected.LaserPower
                            InvokeToolStripStatusLabel(m_LineSelected.LaserPRR.ToString().PadLeft(4, " ") & "kHz", lblLaserPRR)
                            InvokeToolStripStatusLabel(m_LineSelected.LaserPower.ToString().PadLeft(4, " ") & "W", lblLaserPower)
                        End If

                        Call DrawSelectingLine()
                        m_Laser.LaserEmission = False
                        Call EnableDrawSelectingMode(False)
                        btnDrawSelecting.Text = CChangeLanguage.GetString("剪切選擇")
                        Call ImageDisplay1.StartLive(0, m_Acquist)

                        'Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Normal)
                        'Do
                        '    Call System.Windows.Forms.Application.DoEvents()
                        '    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                        '    If cylStatus = enumCylSts.Ready Then
                        '        Exit Do
                        '    ElseIf cylStatus = enumCylSts.TimeOut Then
                        '        Exit Do
                        '    End If
                        'Loop
                        'Call m_DA.DigO.CylGo(enumCyl.WorkholderStand, enumCyllogic.Normal)
                        'Do
                        '    Call System.Windows.Forms.Application.DoEvents()
                        '    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderStand, cylStatus)
                        '    If cylStatus = enumCylSts.Ready Then
                        '        Exit Do
                        '    ElseIf cylStatus = enumCylSts.TimeOut Then
                        '        Exit Do
                        '    End If
                        'Loop
                        Call AddLog("切:" & m_LineSelected.ToString() & "完成！", enumLogType.StartStop)
                    ElseIf (m_SelectedStep > 0) Then
                        If (chkTest.Checked = True) Then
                            Call AddLog("切: 第" & m_SelectedStep.ToString() & "步測試", enumLogType.StartStop)
                        Else
                            Call AddLog("切: 第" & m_SelectedStep.ToString() & "步", enumLogType.StartStop)
                        End If
                        Dim thread As Thread = New Thread(AddressOf DrawSelectingWorkStep)
                        thread.Start()
                        TreeView1.SelectedNode = Nothing
                    Else
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請選擇切割線或步驟進行切割"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                    End If
                Catch ex As Exception
                    FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try

            End If
        Else
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先復歸位置!"), CChangeLanguage.GetString("警告"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub


    Private Function CheckRTCOutRange(ByVal pX As Double, ByVal pY As Double) As Boolean
        Try
            If (pX < m_Laser.MinX OrElse pX > m_Laser.MaxX) Then
                Return True
            End If
            If (pY < m_Laser.MinY OrElse pY > m_Laser.MaxY) Then
                Return True
            End If
            If (pX * 1000 < -32768 OrElse pX * 1000 > 32767) Then
                Return True
            End If
            If (pY * 1000 < -32768 OrElse pY * 1000 > 32767) Then
                Return True
            End If
        Catch ex As Exception
        End Try
        Return False
    End Function
    'Private Function CheckLineOutRange() As Integer
    '    Try
    '        Dim CenterX As Double = 0
    '        Dim CenterY As Double = 0
    '        Dim NewX1 As Double = 0
    '        Dim NewY1 As Double = 0
    '        Dim NewX2 As Double = 0
    '        Dim NewY2 As Double = 0
    '        Dim OffsetX As Double = 0
    '        Dim OffsetY As Double = 0
    '        Dim Angle As Double = 0
    '        For i = 0 To m_ListLine.Count - 1
    '            CenterX = (m_ListLine(i).StartX + m_ListLine(i).EndX) / 2
    '            CenterY = (m_ListLine(i).StartY + m_ListLine(i).EndY) / 2
    '            Call NewPos(OffsetX, OffsetY, Angle, CenterX, CenterY, m_ListLine(i).StartX, m_ListLine(i).StartY, NewX1, NewY1)
    '            Call NewPos(OffsetX, OffsetY, Angle, CenterX, CenterY, m_ListLine(i).EndX, m_ListLine(i).EndY, NewX2, NewY2)

    '            If (CheckRTCOutRange(NewX1, NewY1) = True) Then
    '                Return i
    '            End If
    '            If (CheckRTCOutRange(NewX2, NewY2) = True) Then
    '                Return i
    '            End If
    '        Next
    '        Return -1
    '    Catch
    '    End Try
    '    Return -1
    'End Function

    Private Function SortJob() As Boolean
        SortJob = False
        Try
            ReDim m_lstLineOnWorkStep(m_CurrentProject.WorkStep - 1)
            For ws = 0 To m_lstLineOnWorkStep.Length - 1
                m_lstLineOnWorkStep(ws) = New List(Of Integer)
                For i = 0 To m_ListLine.Count - 1
                    If (m_ListLine(i).[Step] = ws + 1) Then
                        m_lstLineOnWorkStep(ws).Add(i)
                    End If
                Next
            Next
            SortJob = True
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("自動運行前排序作業時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Function


    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        If (m_CurrentProject Is Nothing) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("自動運行錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        If (m_ListLine Is Nothing OrElse m_ListLine.Count = 0) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先添加剪切線"), CChangeLanguage.GetString("自動運行錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If

        If (SortJob() = False) Then
            Exit Sub
        End If
        Call ImageDisplay1.StopLive()
        Do
            Application.DoEvents()
        Loop Until m_LoadedMatchingCount = m_WantLoadMatchingCount

        If (chkTest.Checked = True) Then
            m_Laser.LaserEmission = False
            Thread.Sleep(100)
            m_Laser.LaserGuide = True
        Else
            m_Laser.LaserGuide = False
            Thread.Sleep(100)
            m_Laser.LaserEmission = True
            Thread.Sleep(3000)
        End If

        If (m_ListLine IsNot Nothing AndAlso m_ListLine.Count > 0) Then
            For i = 0 To m_ListLine.Count - 1
                grbCamera.Controls(m_ListLine(i).ID).Visible = False
                CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl).IsSelect = False
            Next
        End If
        m_LineSelected = Nothing
        If (m_Param.Flags.System.AutoRunProcedure = False) Then
            If (chkTest.Checked) Then
                Call AddLog("開始自動運行測試", enumLogType.StartStop)
            Else
                Call AddLog("開始自動運行", enumLogType.StartStop)
            End If
            m_Param.Flags.System.KeyCode = enumKeyConst.KeyMainStart
        End If
    End Sub

    Private Sub SystemInitial()
        Try
            m_Param.Flags.Substrate.SubstrateCanUse = True
            m_Param.Flags.Substrate.SubstrateHavePiece = False


            m_Param.Flags.Pause.EmergencyStop = False
            m_Param.Flags.Pause.MaunalStop = False
            m_Param.Flags.Pause.SysWorkholderFinished = True
            m_Param.Flags.Pause.SysSubstrateFinished = True
            m_Param.Flags.Pause.WaitStop = False
            m_Param.Flags.System.KeyCode = enumKeyConst.KeyStop
            m_Param.Flags.System.SysInitHomeOk = False
            m_Param.Flags.System.Order = enumOrder.Left
            m_Param.Flags.System.Complete = True
            m_Param.Idx.System.WorkStep = -1
            m_Param.Idx.System.JobIdx = -1

            m_SysCmd.TopSys = enumCmdTopIDs.NoCommand
            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
            m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.NoCommand

            m_SysSts.TopSys = enumStsTopIDs.Unknow
            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
            m_SysSts.SubstrateSys = enumStsSubstrateIDs.MoveOutOK

            m_SysProcessNum(enumSys.Top) = loop_COMMAND
            m_SysProcessNum(enumSys.MainCtl) = 10
            m_SysProcessNum(enumSys.TopSubstrateOut) = 1200
            m_SysProcessNum(enumSys.Workholder) = loop_COMMAND
            m_SysProcessNum(enumSys.Substrate) = loop_COMMAND
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?SystemInitial")
            FMessageBox.Show(Me, ex.Message, "FMain?SystemInitial", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub


    Public Shared Sub NewPos(ByVal pXOffset As Double, ByVal pYOffset As Double, ByVal pAngle As Double, ByVal pXCenter As Double, ByVal pYCenter As Double, ByVal pXOriginal As Double, ByVal pYOriginal As Double, ByRef pNewX As Double, ByRef pNewY As Double)
        pNewX = -9999999999
        pNewY = -9999999999
        Dim disX As Double
        Dim disY As Double

        Try

            disX = pXOriginal - pXCenter
            disY = pYOriginal - pYCenter


            pAngle = Math.PI * (pAngle / 180.0)
            pNewX = disX * Math.Cos(pAngle) - disY * Math.Sin(pAngle) + pXCenter
            pNewY = disX * Math.Sin(pAngle) + disY * Math.Cos(pAngle) + pYCenter

            pNewX = pXOffset + pNewX
            pNewY = pYOffset + pNewY


            'pXOriginal -= pXCenter 'pixel
            'pYOriginal -= pYCenter 'pixel

            'pAngle = Math.PI * (pAngle / 180.0)
            'pNewX = pXOriginal * Math.Cos(pAngle) - pYOriginal * Math.Sin(pAngle)
            'pNewY = pXOriginal * Math.Sin(pAngle) + pYOriginal * Math.Cos(pAngle)

            'pNewX += pXCenter + pXOffset
            'pNewY += pYCenter + pYOffset

        Catch ex As Exception

        End Try
    End Sub

    Public Shared Sub NewPos(ByVal x As Double, ByVal y As Double, ByVal angle As Double, ByRef newX As Double, ByRef newY As Double)
        newX = -9999999999
        newY = -9999999999
        Try
            angle = Math.PI * (angle / 180.0)
            newX = x * Math.Cos(angle) - y * Math.Sin(angle)
            newY = x * Math.Sin(angle) + y * Math.Cos(angle)
        Catch
        End Try
    End Sub

    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        Try
            If (m_LineSelected IsNot Nothing) Then
                If (e.ChangedItem.Label = CChangeLanguage.GetString("開始 X (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("開始 Y (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("結束 X (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("結束 Y (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("距離 (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected

                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("開始 X (px)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("開始 Y (px)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("結束 X (px)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("結束 Y (px)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX

                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("偏移 X (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("偏移 Y (mm)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                ElseIf (e.ChangedItem.Label = CChangeLanguage.GetString("角度(度)")) Then
                    CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected

                ElseIf (e.ChangedItem.Label = "Step") Then

                    Dim idx As Integer = TreeView1.Nodes(0).Nodes(m_LineSelected.[Step] - 1).Nodes.Count + 1
                    Dim node As TreeNode = New TreeNode()
                    node.Tag = m_LineSelected
                    node.Name = m_LineSelected.ID
                    node.Text = "LINE" & idx

                    For s = 1 To m_CurrentProject.WorkStep
                        Dim found As Boolean = False
                        For i = 0 To TreeView1.Nodes(0).Nodes(s - 1).Nodes.Count - 1
                            If (TreeView1.Nodes(0).Nodes(s - 1).Nodes(i).Name = m_LineSelected.ID) Then
                                found = True
                                TreeView1.Nodes(0).Nodes(s - 1).Nodes.removeat(i)
                                Exit For
                            End If
                        Next
                        If (found) Then
                            Exit For
                        End If
                    Next

                    TreeView1.Nodes(0).Nodes(m_LineSelected.[Step] - 1).Nodes.Add(node)
                    TreeView1.SelectedNode = node
                    TreeView1_NodeMouseClick(TreeView1, New TreeNodeMouseClickEventArgs(node, MouseButtons.Left, 1, 0, 0))
                End If
                m_FlagSave = True
                PropertyGrid1.Refresh()
            End If
        Catch
        End Try
    End Sub

    Private Sub btnNewProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewProject.Click
        Try
            If (m_CurrentProject IsNot Nothing AndAlso m_FlagSave = True) Then
                If (FMessageBox.Show(Me, CChangeLanguage.GetString("未保存任何更改。 您要保存項目嗎?"), CChangeLanguage.GetString("信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    m_NoMessageShow = True
                    btnSave_Click(Nothing, Nothing)
                End If
            End If
            Dim fnew As FNewProject = New FNewProject()
            fnew.ShowDialog()
            If (fnew.IsOK) Then
                m_CurrentProject = fnew.Project
                m_Param.Variable.Laser.PRR = 20
                m_Param.Variable.Laser.Power = 20
                m_Param.Variable.Laser.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Parameter\Laser.def")
                If (m_ListLine IsNot Nothing AndAlso m_ListLine.Count > 0) Then
                    For i = 0 To m_ListLine.Count - 1
                        grbCamera.Controls.Remove(grbCamera.Controls(m_ListLine(i).ID))
                    Next
                End If
                ReDim m_MatchingTool(m_CurrentProject.WorkStep - 1)
                m_ListOriginalLine = New List(Of CLine)
                m_ListLine = New List(Of CLine)
                fnew.Dispose()
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))
                numWorkStep.Maximum = m_CurrentProject.WorkStep
                For index = 1 To m_CurrentProject.WorkStep
                    TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                    TreeView1.Nodes(0).Nodes(TreeView1.Nodes(0).Nodes.Count - 1).Tag = index
                Next
                TreeView1.ExpandAll()
                MLineManager.LoadListLine(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Job\ListJob.job", m_ListLine)
                Call EnableCorection(False)
                m_IsClicked = False
                m_Param.Flags.System.ProductLoaded = True
                Call AddLog("添加新項目：", m_CurrentProject.ProjectName, enumLogType.Edit)
                m_FlagSave = False
                m_StartEdit = False
                EnableEditLine(m_StartEdit)
            Else
                fnew.Dispose()
            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("創建新項目時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub btnOpenProject_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenProject.Click
        Try
            If (m_CurrentProject IsNot Nothing AndAlso m_FlagSave = True) Then
                If (FMessageBox.Show(Me, CChangeLanguage.GetString("未保存任何更改。 您要保存項目嗎?"), CChangeLanguage.GetString("信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                    m_NoMessageShow = True
                    Call btnSave_Click(Nothing, Nothing)
                End If
            End If
            Dim fopenproject As FOpenProject = New FOpenProject()
            fopenproject.ShowDialog()
            If (fopenproject.IsOK) Then
                m_FLoading = New FLoading(CChangeLanguage.GetString("正在加載項目..."))
                m_FLoading.Show()
                m_CurrentProject = fopenproject.Project
                m_FLoading.Percent = 25
                If (m_ListLine IsNot Nothing AndAlso m_ListLine.Count > 0) Then
                    For i = 0 To m_ListLine.Count - 1
                        grbCamera.Controls.Remove(grbCamera.Controls(m_ListLine(i).ID))
                    Next
                    m_ListLine.Clear()
                End If
                Dim err As Exception = Nothing
                Dim res As Boolean = MLineManager.LoadListLine(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Job\ListJob.job", m_ListLine, err)
                m_ListOriginalLine = New List(Of CLine)

                For i = 0 To m_ListLine.Count - 1
                    If (m_ListLine(i).LaserPower = 0) Then
                        m_ListLine(i).LaserPower = m_Param.Variable.Laser.Power
                    End If
                    If (m_ListLine(i).LaserPRR = 0) Then
                        m_ListLine(i).LaserPRR = m_Param.Variable.Laser.PRR
                    End If
                    m_ListOriginalLine.Add(m_ListLine(i).Clone())
                Next

                m_FLoading.Percent = 30
                If (res = False) Then
                    m_FLoading.Close()
                    m_FLoading.Dispose()
                    FMessageBox.Show(Me, CChangeLanguage.GetString("加載項目時出錯。"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, err)
                    Exit Sub
                End If
                m_FlagSave = False
                Call m_Param.Variable.Graphic.LoadParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Parameter\Graphic.xml")
                Call m_Param.Variable.Laser.LoadParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Parameter\Laser.xml")
                numPRR.Value = m_Param.Variable.Laser.PRR
                numPower.Value = m_Param.Variable.Laser.Power
                lblLaserPRR.Text = m_Param.Variable.Laser.PRR.ToString().PadLeft(4, " ") & "kHz"
                lblLaserPower.Text = m_Param.Variable.Laser.Power.ToString().PadLeft(4, " ") & "W"
                m_FLoading.Percent = 50
                TreeView1.BeginUpdate()
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))

                numWorkStep.Maximum = m_CurrentProject.WorkStep
                For index = 1 To m_CurrentProject.WorkStep
                    TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                    TreeView1.Nodes(0).Nodes(index - 1).Tag = index
                    Dim idx As Integer = 0
                    For i = 0 To m_ListLine.Count - 1
                        If (m_ListLine(i).[Step] = index) Then
                            TreeView1.Nodes(0).Nodes(index - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))
                            m_ListLine(i).Name = "LINE" & (idx + 1).ToString()
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Name = m_ListLine(i).ID
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Tag = m_ListLine(i)
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Text = String.Format(CChangeLanguage.GetString("第{0}線"), (idx + 1))
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).BackColor = Color.White
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).ForeColor = Color.Black
                            Dim newLineCtrl As CLineCtrl = New CLineCtrl(grbCamera.Size, m_ListLine(i).StartXPX, m_ListLine(i).StartYPX, m_ListLine(i).EndXPX, m_ListLine(i).EndYPX, m_Param.Variable.Graphic.LineColor)

                            newLineCtrl.Name = m_ListLine(i).ID
                            newLineCtrl.TabIndex = m_ListLine(i).[Step]
                            grbCamera.Controls.Add(newLineCtrl)
                            newLineCtrl.BringToFront()
                            AddHandler newLineCtrl.MouseUp, AddressOf Control_MouseUp
                            AddHandler newLineCtrl.MouseDown, AddressOf Control_MouseDown
                            AddHandler newLineCtrl.MouseDoubleClick, AddressOf Control_MouseDoubleClick

                            AddHandler newLineCtrl.MouseEnter, AddressOf Control_MouseEnter
                            AddHandler newLineCtrl.MouseLeave, AddressOf Control_MouseLeave
                            AddHandler newLineCtrl.MouseMove, AddressOf Control_MouseMove
                            idx += 1
                        End If
                    Next
                Next

                ReDim m_MatchingTool(m_CurrentProject.WorkStep - 1)


                m_LoadedMatchingCount = 0
                m_WantLoadMatchingCount = 0
                For i = 1 To m_CurrentProject.WorkStep
                    Dim pMatchingToolPath = CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image" & "\WorkStep" & i.ToString
                    If System.IO.Directory.Exists(pMatchingToolPath) = True Then
                        Dim idx As Integer = i - 1
                        Dim th As Thread = New Thread(Sub() LoadMatchingTool(idx, pMatchingToolPath))
                        th.IsBackground = True
                        th.Priority = ThreadPriority.Highest
                        th.Start()
                        m_WantLoadMatchingCount += 1
                        m_FLoading.Percent += 10
                    End If
                Next

                Call m_Param.Variable.Align.LoadParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image\Parameter.xml")
                TreeView1.ExpandAll()
                TreeView1.EndUpdate()
                Call EnableCorection(False)
                m_IsClicked = False
                m_Param.Flags.System.ProductLoaded = True
                m_FLoading.Percent = 100
                m_FLoading.Close()
                m_FLoading.Dispose()
                m_FLoading = Nothing
                Call AddLog("加載項目", m_CurrentProject.ProjectName, enumLogType.OpenClose)
                PropertyGrid1.SelectedObject = Nothing
            End If
        Catch ex As Exception
            If (m_FLoading IsNot Nothing) Then
                Try
                    m_FLoading.Close()
                    m_FLoading.Dispose()
                    m_FLoading = Nothing
                Catch ex2 As Exception
                End Try
            End If
            TreeView1.EndUpdate()
            FMessageBox.Show(Me, CChangeLanguage.GetString("打開項目時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub LoadMatchingTool(ByVal idx As Integer, ByVal pPath As String)
        m_MatchingTool(idx) = New VisionSystem.CMatchingTool(pPath)
        Call m_MatchingTool(idx).ReadFiles()
        Call m_MatchingTool(idx).Pattern.Train()
        m_LoadedMatchingCount += 1
    End Sub

    Private m_SaveEdit As Boolean = False
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If (m_CurrentProject IsNot Nothing) Then
            Dim err As Exception = Nothing
            If (m_StartEdit = True) Then 'Save edit position
                If (m_SaveEdit = True) Then
                    For i = 0 To m_ListOriginalLine.Count - 1
                        If m_LineSelected.ID = m_ListOriginalLine(i).ID Then
                            m_ListOriginalLine(i) = m_LineSelected.Clone()
                            Exit For
                        End If
                    Next

                    Dim res As Boolean = MLineManager.SaveListLine(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Job\ListJob.job", m_ListOriginalLine, err)
                    If (res = False) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("保存項目時出錯"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, err)
                        Exit Sub
                    Else

                        m_ListLine = New List(Of CLine)

                        For i = 0 To m_ListOriginalLine.Count - 1
                            m_ListLine.Add(m_ListOriginalLine(i).Clone())
                            If m_LineSelected.ID = m_ListOriginalLine(i).ID Then
                                m_LineSelected = m_ListLine(i)
                            End If
                        Next
                        m_LineSelectedOld = m_LineSelected.Clone()
                        If (m_NoMessageShow = False) Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("項目已保存"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                        m_NoMessageShow = False
                        m_FlagSave = False
                    End If

                End If
            Else 'Save laser parameters only
                For i = 0 To m_ListOriginalLine.Count - 1
                    For j = 0 To m_ListLine.Count - 1
                        If (m_ListOriginalLine(i).ID = m_ListLine(j).ID) Then
                            m_ListOriginalLine(i).JumpDelay = m_ListLine(j).JumpDelay
                            m_ListOriginalLine(i).JumpSpeed = m_ListLine(j).JumpSpeed
                            m_ListOriginalLine(i).LaserOffDelay = m_ListLine(j).LaserOffDelay
                            m_ListOriginalLine(i).LaserOnDelay = m_ListLine(j).LaserOnDelay
                            m_ListOriginalLine(i).LaserPower = m_ListLine(j).LaserPower
                            m_ListOriginalLine(i).LaserPRR = m_ListLine(j).LaserPRR
                            m_ListOriginalLine(i).MarkDelay = m_ListLine(j).MarkDelay
                            m_ListOriginalLine(i).MarkSpeed = m_ListLine(j).MarkSpeed
                            m_ListOriginalLine(i).PolygonDelay = m_ListLine(j).PolygonDelay
                            m_ListOriginalLine(i).RepeatCount = m_ListLine(j).RepeatCount
                            m_ListOriginalLine(i).RepeatMode = m_ListLine(j).RepeatMode
                            Exit For
                        End If
                    Next
                Next

                Dim res As Boolean = MLineManager.SaveListLine(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Job\ListJob.job", m_ListOriginalLine, err)
                If (res = False) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("保存項目時出錯"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, err)
                    Exit Sub
                Else
                    m_ListLine = New List(Of CLine)

                    For i = 0 To m_ListOriginalLine.Count - 1
                        m_ListLine.Add(m_ListOriginalLine(i).Clone())
                    Next
                    If (m_NoMessageShow = False) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("項目已保存"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End If
                    m_NoMessageShow = False
                    m_FlagSave = False
                End If
            End If
        End If
    End Sub


    Private Sub btnGuideON_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuideON.Click
        m_Laser.LaserGuide = True
    End Sub

    Private Sub btnGuideOFF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuideOFF.Click
        m_Laser.LaserGuide = False
    End Sub

    Private Sub btnCorrection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrection.Click
        btnCorrection.Enabled = False
        Call EnableCorection(True)
        Try
            If (m_Corection.LaserOn) Then
                m_ButtonClick = 1
                Call m_Laser.ExecuteList(1)
            Else
                m_ButtonClick = 6
            End If
            'Timer_GetLaserExecuteFinish.Enabled = True
            Do
                Application.DoEvents()
            Loop Until m_Laser.ListExecutionFinish = True
            btnCorrection.Enabled = True
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("繪製校正時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            btnCorrection.Enabled = True
            'Timer_GetLaserExecuteFinish.Enabled = False
        End Try

    End Sub

    Private Sub Timer_GetLaserExecuteFinish_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer_GetLaserExecuteFinish.Tick
        If (m_ButtonClick = 5) Then
            Timer_GetLaserExecuteFinish.Enabled = False
            m_Laser.StopExecute()
            m_Laser.LaserEmission = False
            m_Laser.LaserGuide = True
            Call EnableDrawSelectingMode(False)
            Call EnableRunMode(False)
        ElseIf (m_ButtonClick = 6) Then
            Call m_Laser.ExecuteList(1)
        Else
            If (m_Laser.ListExecutionFinish()) Then
                Timer_GetLaserExecuteFinish.Enabled = False
                Select Case m_ButtonClick
                    Case 1
                        btnCorrection.Enabled = True
                        Call EnableCorection(False)
                    Case 2
                        Call EnableDrawSelectingMode(False)
                        btnDrawSelecting.Text = CChangeLanguage.GetString("剪切選擇")
                        m_Laser.LaserEmission = False
                    Case 3
                        Call EnableRunMode(False)
                End Select
            End If
        End If
    End Sub

    Private Sub btnGlavoHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGlavoHome.Click
        Try
            Call m_Laser.setstartlist(1)
            Call m_Laser.setScannerDelays(1, 1, 1)
            Call m_Laser.SetLaserDelays(1, 1)
            Call m_Laser.SetJumpSpeed(1000)
            Call m_Laser.SetMarkSpeed(1000)
            Call m_Laser.JumpAbs(0, 0)
            Call m_Laser.SetEndofList()
            Call m_Laser.ExecuteList(1)
        Catch
        End Try
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Try
            If m_VisionLineFlag = True Then
                m_VisionLineFlag = False
                Call ImageDisplay1.StopLive()
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call ImageDisplay1.StartLive(0, m_Acquist)
                m_StartEdit = False
                btnEdit.Text = ""
                ToolTip1.SetToolTip(btnEdit, CChangeLanguage.GetString("停止相機以使用原始圖像進行編輯"))
            Else
                m_LaserReticle = New VisionSystem.CReticle
                m_LaserReticle.X = ImageDisplay1.ImageX / 2 + m_Param.Variable.Graphic.OffsetX
                m_LaserReticle.Y = ImageDisplay1.ImageY / 2 + m_Param.Variable.Graphic.OffsetY
                m_LaserReticle.Length = 1000
                m_VisionLineFlag = True
                Call ImageDisplay1.StopLive()
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call Me.ImageDisplay1.StaticGraphics.Add(m_LaserReticle)
                Call ImageDisplay1.StartLive(0, m_Acquist)
                Call m_LaserReticle.Dispose()
                m_LaserReticle = Nothing
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub EnableCorection(ByVal status As Boolean)
        btnEmissionOff.Enabled = Not status
    End Sub
    Private Delegate Sub InvokeEnableCallBack(ByVal Status As Boolean)
    Private Sub EnableDrawSelectingMode(ByVal status As Boolean)
        If (Me.InvokeRequired) Then
            Dim cb As New InvokeEnableCallBack(AddressOf EnableDrawSelectingMode)
            Me.BeginInvoke(cb, status)
        Else
            'PropertyGrid1.Enabled = Not status
            btnRun.Enabled = Not status
            TableLayoutPanel1.Enabled = Not status
            btnOpenProject.Enabled = Not status
            If (CLoginInformation.CurrentUser.Permission <= 0) Then
                btnNewProject.Enabled = False
                btnSave.Enabled = False
            Else
                btnNewProject.Enabled = Not status
                btnSave.Enabled = Not status
            End If
            Me.Refresh()
        End If
    End Sub
    Private Sub EnableRunMode(ByVal status As Boolean)
        If (Me.InvokeRequired) Then
            Dim cb As New InvokeEnableCallBack(AddressOf EnableRunMode)
            Me.BeginInvoke(cb, status)
        Else
            'PropertyGrid1.Enabled = Not status
            btnDrawSelecting.Enabled = Not status
            TableLayoutPanel1.Enabled = Not status
            btnOpenProject.Enabled = Not status
            btnRun.Enabled = Not status
            If (CLoginInformation.CurrentUser.Permission <= 0) Then
                btnNewProject.Enabled = False
                btnSave.Enabled = False
            Else
                btnNewProject.Enabled = Not status
                btnSave.Enabled = Not status
            End If
            Me.Refresh()
        End If
    End Sub


    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        If m_Param.Flags.System.SysInitHomeOk Then
            m_Param.Flags.Pause.WaitStop = True
        Else
            m_Param.Flags.Pause.MaunalStop = True
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If (m_Param.Flags.System.AutoRunProcedure = True) Then
            e.Cancel = True
            Exit Sub
        End If
        'If (m_Param.Flags.System.SysInitHomeOk = False) Then
        '    If (e.TabPage.Name <> TabPageLog.Name AndAlso e.TabPage.Name <> TabPagePassword.Name AndAlso e.TabPage.Name <> TabPageLaserParam.Name AndAlso e.TabPage.Name <> TabPageMain.Name) Then
        '        FMessageBox.Show(Me, CChangeLanguage.GetString("請先復歸 !!!"), CChangeLanguage.GetString("警告"), MessageBoxButtons.OK, MessageBoxIcon.Information)
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If
        If (m_VisionStart) Then
            e.Cancel = True
            Exit Sub
        End If
        If (Timer_GetLaserExecuteFinish.Enabled = True) Then
            e.Cancel = True
            Exit Sub
        End If
        chkPickPoint.Checked = False
        chkPickY.Checked = False
        Timer1.Enabled = False
        Me.Text = CChangeLanguage.GetString("雷射切割")
        Select Case e.TabPage.Name
            Case TabPageCorrection.Name
                If (m_Corection Is Nothing) Then
                    m_Corection = New CCorrection()
                    m_Corection.LoadCorectionParam()
                    m_Corection.GalvoAngle = m_Param.Variable.Laser.Angle
                    m_Corection.GalvoOffsetX = m_Param.Variable.Laser.OffsetX
                    m_Corection.GalvoOffsetY = m_Param.Variable.Laser.OffsetY
                End If
                PropertyGrid2.SelectedObject = m_Corection
                btnNewProject.Enabled = False
                btnOpenProject.Enabled = False
                btnSave.Enabled = False
                PrepareList()
                Dim info = PropertyGrid2.[GetType]().GetProperty("Controls")
                Dim collection = DirectCast(info.GetValue(PropertyGrid2, Nothing), Control.ControlCollection)
                For Each ctrl As Object In collection
                    Dim type = ctrl.GetType()
                    If (type.Name = "PropertyGridView") Then
                        ctrl.LabelRatio = 1.8
                        PropertyGrid2.HelpVisible = True
                        Exit For
                    End If
                Next

                If (TabControl2.SelectedTab Is TabPageIOStatus) Then
                    m_IsTimerRunning = False
                    TimerGetIO.Enabled = True
                Else
                    TimerGetIO.Enabled = False
                End If
            Case TabPageLaserParam.Name
                TimerGetIO.Enabled = False
                'If (m_CurrentProject Is Nothing) Then
                '    e.Cancel = True
                '    FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    Exit Sub
                'End If
                'If (m_Param IsNot Nothing) Then
                '    Try
                '        numPower.Value = m_Param.Variable.Laser.Power
                '        numPRR.Value = m_Param.Variable.Laser.PRR
                '        numPX2MM.Value = m_Param.Variable.Graphic.PX2MM
                '    Catch
                '    End Try
                'End If

            Case TabPageAlignment.Name
                TimerGetIO.Enabled = False
                If (m_CurrentProject Is Nothing) Then
                    e.Cancel = True
                    FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Do
                    Application.DoEvents()
                Loop Until m_LoadedMatchingCount = m_WantLoadMatchingCount

            Case TabPageOther.Name
                Dim x As Integer = 0
                Dim y As Integer = 0
                Dim tabIdx As Integer = -1
                Dim rect As Rectangle
                For i = 0 To TabControl1.TabPages.Count - 1
                    If (TabControl1.TabPages(i).Name <> TabPageOther.Name) Then
                        rect = TabControl1.GetTabRect(i)
                        x += rect.Width
                        y = rect.Height
                    Else
                        tabIdx = i
                    End If
                Next
                rect = TabControl1.GetTabRect(tabIdx)
                ContextMenuStripOther.Size = New Size(rect.Width, ContextMenuStripOther.Height)
                ContextMenuStripOther.Show(TabControl1, New Point(x, y))
                e.Cancel = True
            Case TabPagePos.Name
                Timer1.Enabled = True



            Case Else
                TimerGetIO.Enabled = False
                If (m_Corection IsNot Nothing) Then
                    Call m_Corection.SaveCorectionParam()
                End If
                btnOpenProject.Enabled = True
                If (CLoginInformation.CurrentUser.Permission <= 0) Then
                    btnNewProject.Enabled = False
                    btnSave.Enabled = False
                Else
                    btnNewProject.Enabled = True
                    btnSave.Enabled = True
                End If

        End Select

    End Sub

    Private Sub btnStopCorrection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStopCorrection.Click
        Try
            Call m_Laser.StopExecute()
            Timer_GetLaserExecuteFinish.Enabled = False
            btnCorrection.Enabled = True
            Call btnEmissionOff_Click(Nothing, Nothing)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub PrepareList()
        Try
            Dim startIdx As Integer = -(m_Corection.Range - 1) / 2
            Dim endIdx As Integer = (m_Corection.Range - 1) / 2
            Dim pX, pY As Integer

            If (m_Corection.LaserOn) Then
                m_Laser.PRR = m_Corection.PRR
                m_Laser.OperatingPower = m_Corection.Power
            End If

            Call m_Laser.setstartlist(1)
            Call m_Laser.setScannerDelays(m_Corection.JumpDelay, m_Corection.MarkDelay, m_Corection.PolygonDelay)
            Call m_Laser.SetLaserDelays(m_Corection.LaserOnDelay, m_Corection.LaserOffDelay)
            Call m_Laser.SetJumpSpeed(m_Corection.JumpSpeed)
            Call m_Laser.SetMarkSpeed(m_Corection.MarkSpeed)
            Call m_Laser.JumpAbs(0, 0)
            Dim lstCor As New List(Of CCorrectionData)
            'Draw Line X
            For y = startIdx To endIdx Step 1
                pY = y * m_Corection.Size * m_Corection.KFactor / 1000.0
                pX = startIdx * m_Corection.Size * m_Corection.KFactor / 1000.0
                Call m_Laser.JumpAbs(pX, pY)
                pX = endIdx * m_Corection.Size * m_Corection.KFactor / 1000.0
                Call m_Laser.MarkAbs(pX, pY)
            Next

            'Draw Line Y
            For x = startIdx To endIdx Step 1
                pX = x * m_Corection.Size * m_Corection.KFactor / 1000
                pY = startIdx * m_Corection.Size * m_Corection.KFactor / 1000
                Call m_Laser.JumpAbs(pX, pY)
                pY = endIdx * m_Corection.Size * m_Corection.KFactor / 1000
                Call m_Laser.MarkAbs(pX, pY)
            Next

            'Draw Circle
            For x = startIdx To endIdx Step 1
                For y = startIdx To endIdx Step 1
                    pY = y * m_Corection.Size * m_Corection.KFactor / 1000
                    pX = (x * m_Corection.Size + m_Corection.Radius) * m_Corection.KFactor / 1000
                    'm_Laser.JumpAbs(pX, pY)
                    pX = x * m_Corection.Size * m_Corection.KFactor / 1000
                    'm_Laser.ArcAbs(pX, pY, 353)
                    lstCor.Add(New CCorrectionData(pX, pY, 0, 0))
                Next
            Next

            dgvCorrection.Rows.Clear()


            For i = 0 To lstCor.Count - 1
                dgvCorrection.Rows.Add(New Object() {i + 1, lstCor(i).RTC_X, lstCor(i).RTC_Y, lstCor(i).REAL_X, lstCor(i).REAL_Y})
            Next
            Call m_Laser.SetEndofList()
            Call m_Corection.SaveCorectionParam()
        Catch
        End Try
    End Sub

    Private m_oldValue As Double = 0
    Private m_CurRow As Integer = 0
    Private m_CurCol As Integer = 0
    Private Sub dgvCorrection_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvCorrection.EditingControlShowing
        Try
            m_CurCol = dgvCorrection.CurrentCell.ColumnIndex
            m_CurRow = dgvCorrection.CurrentCell.RowIndex
            Dim ctr = CType(e.Control, DataGridViewTextBoxEditingControl)
            If (ctr Is Nothing) Then
                Return
            End If
            RemoveHandler ctr.KeyPress, AddressOf KeyPressEventNumberOnly_dgvData
            RemoveHandler ctr.Leave, AddressOf txt_Leave
            AddHandler ctr.KeyPress, AddressOf KeyPressEventNumberOnly_dgvData
            AddHandler ctr.Leave, AddressOf txt_Leave
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "Error dgvData_EditingControlShowing", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub


    Private Sub KeyPressEventNumberOnly_dgvData(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            If (Char.IsControl(e.KeyChar)) Then
                Exit Sub
            End If
            Dim tmp As String = CType(sender, TextBox).Text.ToUpper()
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c OrElse e.KeyChar = "-"c) Then
                e.Handled = True
            End If

            If (e.KeyChar = "."c AndAlso tmp.IndexOf(".") > -1) Then
                e.Handled = True
            End If

            If (e.KeyChar = "-"c AndAlso tmp.IndexOf("-") > -1) Then
                e.Handled = True
            End If

        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "Error KeyPressEventNumberOnly_dgvData", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub txt_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            Dim txt As TextBox = CType(sender, TextBox)
            If (txt.Text.Length = 0) Then
                txt.Text = "0"
            ElseIf (txt.Text = "." OrElse txt.Text = "-") Then
                txt.Text = "0"
            ElseIf (txt.Text(txt.Text.Length - 1) = "."c) Then
                txt.Text &= "0"
            ElseIf (txt.Text(txt.Text.Length - 1) = "-"c) Then
                txt.Text = txt.Text.Substring(0, txt.Text.Length - 1)
            ElseIf (txt.Text(0) = ".") Then
                txt.Text = "0" & txt.Text
            End If
            dgvCorrection.Rows(m_CurRow).Cells(m_CurCol).Value = txt.Text
        Catch
        End Try
    End Sub


    Private m_CorrectionDataFilePath As String = ""
    Private Sub btnSaveCorrectionValue_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCorrectionValue.Click
        Try
            m_Corection.CorrectionData.Clear()
            For i = 0 To dgvCorrection.Rows.Count - 1
                m_Corection.CorrectionData.Add(New CCorrectionData(CInt(dgvCorrection.Rows(i).Cells(1).Value), CInt(dgvCorrection.Rows(i).Cells(2).Value), CDbl(dgvCorrection.Rows(i).Cells(3).Value), CDbl(dgvCorrection.Rows(i).Cells(4).Value)))
            Next

            m_CorrectionDataFilePath = m_Corection.SaveCorectionParam()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEmissionOn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmissionOn.Click
        Try
            PropertyGrid2.Enabled = False
            btnEmissionOn.Enabled = False
            btnGuideON.Enabled = False
            btnGuideOFF.Enabled = False

            Me.Refresh()
            Dim flag As Boolean = False
            If (m_Param.Variable.Laser.Angle <> m_Corection.GalvoAngle) Then
                m_Param.Variable.Laser.Angle = m_Corection.GalvoAngle
                flag = True
            End If
            If (m_Param.Variable.Laser.OffsetX <> m_Corection.GalvoOffsetX) Then
                m_Param.Variable.Laser.OffsetX = m_Corection.GalvoOffsetX
                flag = True
            End If
            If (m_Param.Variable.Laser.OffsetY <> m_Corection.GalvoOffsetY) Then
                m_Param.Variable.Laser.OffsetY = m_Corection.GalvoOffsetY
                flag = True
            End If
            If (flag) Then
                Call m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
                'm_Laser.LoadCorrectionFile("C:\\RTC4 Files\\D2_263.ctb", 1, 1.0, 1.0, m_Param.Variable.Laser.Angle, m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
            End If
            PrepareList()
            If (m_Corection.LaserOn) Then
                m_Laser.LaserGuide = False
                m_Laser.LaserEmission = True
            Else
                m_Laser.LaserEmission = False
                m_Laser.LaserGuide = True
            End If

            Threading.Thread.Sleep(3000)
            btnEmissionOff.Enabled = True
            btnCorrection.Enabled = True
            btnMarkLine.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnEmissionOff_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmissionOff.Click
        Try
            PropertyGrid2.Enabled = True
            m_Laser.LaserEmission = False
            btnEmissionOff.Enabled = False
            btnEmissionOn.Enabled = True
            btnCorrection.Enabled = False
            btnGuideON.Enabled = True
            btnGuideOFF.Enabled = True
            btnMarkLine.Enabled = False
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("其他程序使用的串行端口。"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim fhelp As FHelpCorrection = New FHelpCorrection()
        fhelp.ShowDialog()
        fhelp.Dispose()
        fhelp = Nothing
    End Sub

    Private Sub PropertyGrid2_PropertyValueChanged(ByVal s As System.Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid2.PropertyValueChanged
        Try
            If ((e.ChangedItem.Label = "Range" AndAlso e.OldValue <> m_Corection.Range) OrElse (e.ChangedItem.Label = "Grid Size (um)" AndAlso e.OldValue <> m_Corection.Size)) Then
                m_Corection.LoadCorrectionData()
                dgvCorrection.Rows.Clear()
                For i = 0 To m_Corection.CorrectionData.Count - 1
                    dgvCorrection.Rows.Add(New Object() {i + 1, m_Corection.CorrectionData(i).RTC_X, m_Corection.CorrectionData(i).RTC_Y, m_Corection.CorrectionData(i).REAL_X, m_Corection.CorrectionData(i).REAL_Y})
                Next
            ElseIf (e.ChangedItem.Label = "Galvo Angle (deg)") Then
                m_Param.Variable.Laser.Angle = m_Corection.GalvoAngle
                numGalvoAngle.Value = m_Param.Variable.Laser.Angle
                m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
                m_Laser.SetAngle(m_Param.Variable.Laser.Angle)
            ElseIf (e.ChangedItem.Label = "Galvo Offset X (bit)") Then
                m_Param.Variable.Laser.OffsetX = m_Corection.GalvoOffsetX
                numGalvoOffsetX.Value = m_Param.Variable.Laser.OffsetX
                m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
                m_Laser.SetOffset(m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
            ElseIf (e.ChangedItem.Label = "Galvo Offset Y (bit)") Then
                m_Param.Variable.Laser.OffsetY = m_Corection.GalvoOffsetY
                numGalvoOffsetY.Value = m_Param.Variable.Laser.OffsetY
                m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
                m_Laser.SetOffset(m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
            End If
            PropertyGrid2.Refresh()
        Catch
        End Try
    End Sub

    Private Sub Main()
        Try
            Call Movie()
            Call SystemInitial()
            Call MainProcess()
        Catch ex As Exception
            ' Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Main")
            FMessageBox.Show(Me, ex.Message, "FMain?Main", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    Private Sub Movie()
        Try
            Dim pImagePointsInit As Boolean
            pImagePointsInit = ImagePointsInit("D:\DataSettings\LaserMachine\Machine\Parameter")
            If pImagePointsInit = False Then
                ' Call MsgBox("手臂校正檔異常!! ", MsgBoxStyle.Critical)
                FMessageBox.Show(Me, CChangeLanguage.GetString("手臂校正檔異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                'End
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Sub MainProcess()
        Try
            Dim sysNum As enumSys
            Do
                If m_Param.Flags.Pause.WaitStop Then
                    If IsAllProcessStop() Then
                        m_Param.Flags.Pause.WaitStop = False
                        m_Param.Flags.System.KeyCode = enumKeyConst.KeyStop
                        If (chkTest.Checked) Then
                            AddLog("停止自動運行測試", enumLogType.StartStop)
                        Else
                            AddLog("停止自動運行", enumLogType.StartStop)
                        End If
                        Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                        Call Me.ImageDisplay1.StartLive(0, m_Acquist)
                        m_StartEdit = False
                        InvokeButtonText("", btnEdit)
                        InvokeToolTip(CChangeLanguage.GetString("停止相機以使用原始圖像進行編輯"), ToolTip1, btnEdit)
                    End If
                End If
                If m_Param.Flags.Pause.MaunalStop Then
                    m_Param.Flags.Pause.WaitStop = False
                    m_Param.Flags.Pause.MaunalStop = False
                    m_Param.Flags.System.KeyCode = enumKeyConst.KeyStop
                End If

                If m_Param.Flags.Pause.EmergencyStop Then
                    m_Param.Flags.System.SysInitHomeOk = False
                    m_Param.Flags.Pause.WaitStop = False
                    m_Param.Flags.Pause.MaunalStop = False
                    m_Param.Flags.Pause.EmergencyStop = False
                    m_Param.Flags.System.KeyCode = enumKeyConst.KeyStop
                End If



                If m_Param.Flags.System.KeyCode = enumKeyConst.KeyNo Then
                Else
                    If m_Param.Flags.System.KeyCode = enumKeyConst.KeyStop Then
                        m_Param.Flags.System.KeyCode = enumKeyConst.KeyNo
                        Call LightNormalPause()
                        Call UserInterfaceRunStatus(False)
                        Call m_Param.WriteDataToFile(MCS_SRC_DIRECTORY & "User\Product\Reserved\Parameter.xml")
                        Call m_Laser.LaserSignalOFF()
                        'Call ProtectCall()

                        m_Param.Flags.System.AutoRunProcedure = False
                        m_Laser.LaserEmission = False
                        Call Manual()

                        m_Param.Flags.System.AutoRunProcedure = True


                        Call GC.Collect()
                        Call LightNormalRun()
                        Call UserInterfaceRunStatus(True)
                        If m_Param.Flags.System.KeyCode = enumKeyConst.KeyMainExit Then Exit Do
                        m_Param.Flags.System.KeyCode = enumKeyConst.KeyNo
                    End If
                End If
                sysNum = enumSys.MainCtl
                Select Case m_SysProcessNum(sysNum)
                    Case 0
                        '///[Note] 無做事....
                    Case 10
                        If m_SysCmd.TopSys = enumCmdTopIDs.NoCommand Then
                            m_SysCmd.TopSys = enumCmdTopIDs.Home
                            m_SysProcessNum(sysNum) = 20
                        End If
                    Case 20
                        If m_SysCmd.TopSys = enumCmdTopIDs.NoCommand Then
                            If m_SysSts.TopSys = enumStsTopIDs.Home Then
                                m_Param.Flags.System.SysInitHomeOk = True
                                m_Param.Flags.Pause.MaunalStop = True
                                m_SysProcessNum(sysNum) = 30
                            End If
                        End If
                    Case 30
                        If m_SysCmd.TopSys = enumCmdTopIDs.NoCommand Then
                            m_SysCmd.TopSys = enumCmdTopIDs.Work
                            m_SysProcessNum(sysNum) = 40
                        End If
                End Select
                'Layer3()
                Call Substrate_System()
                'Call TrayIn_System()
                'Call TrayOut_System()
                Call Workholder_System()
                ''Layer2()
                Call TopSubstrateOut()
                'Call TopSubstrateIn()
                Call Top_System()
            Loop
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?MainProcess")
            FMessageBox.Show(Me, ex.Message, "FMain?MainProcess", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            Call Debug.Assert(False)
        End Try
    End Sub
    Private Sub Manual()
        Try
            Do
                Call Thread.Sleep(1)
                Select Case m_Param.Flags.System.KeyCode
                    Case enumKeyConst.KeyNo
                    Case enumKeyConst.KeyMainRestart
                        m_Param.Flags.System.KeyCode = enumKeyConst.KeyNo
                        SystemInitial()
                        Call UserInterfaceRunStatus(True)
                        Exit Do
                    Case enumKeyConst.KeyMainStart
                        m_Param.Flags.System.KeyCode = enumKeyConst.KeyNo
                        If m_Param.Flags.System.SysInitHomeOk Then
                            If m_Param.Flags.System.ProductLoaded Then
                                Call UserInterfaceRunStatus(True)
                                Exit Do
                            Else
                                'Call MsgBox("請先指定生產檔案..!!", MsgBoxStyle.Information, "Information")
                                FMessageBox.Show(Me, CChangeLanguage.GetString("請先指定生產檔案..!!"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            End If
                        Else
                            SystemInitial()
                            Call UserInterfaceRunStatus(True)
                            Exit Do
                        End If
                    Case enumKeyConst.KeyMainExit
                        Exit Do

                End Select
            Loop
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Manual")
            FMessageBox.Show(Me, ex.Message, "FMain?Manual", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            Call Debug.Assert(False)
        End Try
    End Sub
    Private Sub UserInterfaceRunStatus(ByVal Status As Boolean)
        Try
            If Status Then '自動流程
                Call InvokeButton(False, btnNewProject)
                Call InvokeButton(False, btnOpenProject)
                Call InvokeButton(False, btnSave)
                Call InvokeButton(False, btnAddLine)
                Call InvokeButton(False, btnDelete)
                Call InvokeButton(False, Button3)
                Call InvokeButton(False, btnDrawSelecting)
                Call InvokeTreeView(False, TreeView1)
                'Call InvokePropertyGrid(False, PropertyGrid1)
                Call InvokeCheckBox(False, chkTest)
                Call InvokeButton(False, btnDrawSelecting)
                Call InvokeButton(False, btnRun)
                Call InvokeButton(False, btnEdit)
                Call InvokeButton(True, btnStop)
                'Call InvokeNumericUpDown1(False, numSubstrateHeight)
            Else '停下來
                Call InvokeButton(True, btnNewProject)
                Call InvokeButton(True, btnOpenProject)
                Call InvokeButton(True, btnSave)
                Call InvokeButton(True, btnAddLine)
                Call InvokeButton(True, btnDelete)
                Call InvokeButton(True, Button3)
                Call InvokeButton(True, btnDrawSelecting)
                Call InvokeTreeView(True, TreeView1)
                'Call InvokePropertyGrid(True, PropertyGrid1)
                Call InvokeCheckBox(True, chkTest)
                Call InvokeButton(True, btnDrawSelecting)
                Call InvokeButton(True, btnRun)
                Call InvokeButton(True, btnEdit)
                Call InvokeButton(False, btnStop)

            End If
        Catch ex As Exception
            ' Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?UserInterfaceRunStatus")
            FMessageBox.Show(Me, ex.Message, "FMain?UserInterfaceRunStatus", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub UserInterfaceRunStatus2(ByVal Status As Boolean)
        Try
            GroupBox6.Enabled = Status
            GroupBox7.Enabled = Status
            GroupBox8.Enabled = Status
            GroupBox10.Enabled = Status
            GroupBox11.Enabled = Status
            GroupBox12.Enabled = Status
            GroupBox13.Enabled = Status
            GroupBox17.Enabled = Status
            groupWorkholderX.Enabled = Status
            btnSavePos.Enabled = Status
        Catch ex As Exception

        End Try
    End Sub
    Private Function IsAllProcessStop() As Boolean
        IsAllProcessStop = False
        Try

            If m_Param.Flags.System.Complete = True Then
                If m_Param.Flags.Pause.SysWorkholderFinished Then
                    If m_Param.Flags.Pause.SysSubstrateFinished Then
                        If m_SysProcessNum(enumSys.Workholder) = loop_COMMAND Then
                            IsAllProcessStop = True
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?IsAllProcessStop")
            FMessageBox.Show(Me, ex.Message, "FMain?IsAllProcessStop", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Function
    Private Sub LightError()
        Try
            'Call m_DA.DigO.CylGo(enumCyl.Buzzer, enumCyllogic.Action)
            'Call m_DA.DigO.CylGo(enumCyl.LightRed, enumCyllogic.Action)
            'Call m_DA.DigO.CylGo(enumCyl.LightYellow, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightGreen, enumCyllogic.Normal)
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?LightError")
            FMessageBox.Show(Me, ex.Message, "FMain?LightError", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    Private Sub LightNormalPause()
        Try
            'Call m_DA.DigO.CylGo(enumCyl.Buzzer, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightRed, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightYellow, enumCyllogic.Action)
            'Call m_DA.DigO.CylGo(enumCyl.LightGreen, enumCyllogic.Normal)
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?LightNormalPause")
            FMessageBox.Show(Me, ex.Message, "FMain?LightNormalPause", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    Private Sub LightNormalRun()
        Try
            'Call m_DA.DigO.CylGo(enumCyl.Buzzer, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightRed, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightYellow, enumCyllogic.Normal)
            'Call m_DA.DigO.CylGo(enumCyl.LightGreen, enumCyllogic.Action)
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?LightNormalRun")
            FMessageBox.Show(Me, ex.Message, "FMain?LightNormalRun", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub ShowErrorMessage(ByVal SysNum As Integer, ByVal ErrorMessage As String)
        Try


            Call LightError()
            m_FErrorMsg(SysNum).Dispose()
            m_FErrorMsg(SysNum) = Nothing
            m_FErrorMsg(SysNum) = New FMessageBox()
            m_FErrorMsg(SysNum).ButtonType = MessageBoxButtons.YesNo
            If ErrorMessage.IndexOf("復歸完成") >= 0 Then
                Call AddLog(ErrorMessage, enumLogType.StartStop)
                m_FErrorMsg(SysNum).ButtonType = MessageBoxButtons.OK
                m_FErrorMsg(SysNum).IconType = MessageBoxIcon.OK
            Else
                Call AddLog(ErrorMessage, enumLogType.Error)
                m_FErrorMsg(SysNum).IconType = MessageBoxIcon.Error
            End If
            m_FErrorMsg(SysNum).ErrorMsg = CChangeLanguage.GetString(ErrorMessage)
            m_FErrorMsg(SysNum).ShowDetail = False
            m_FErrorMsg(SysNum).Flag = False
            m_FErrorMsg(SysNum).AutoRunFlag = True
            Call InvokeForm1(m_FErrorMsg(SysNum))

        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?ShowErrorMessage")
            FMessageBox.Show(Me, ex.Message, "FMain?ShowErrorMessage", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 手臂系統
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Substrate_System()
        Try
            Dim block_number As Integer
            Dim sysNum As Integer
            sysNum = enumSys.Substrate
            Select Case m_SysProcessNum(sysNum)
                Case loop_COMMAND
                    Select Case m_SysCmd.SubstrateSys
                        Case enumCmdSubstrateIDs.NoCommand
                        Case enumCmdSubstrateIDs.MoveIn
                            m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.NoCommand : m_SysSts.SubstrateSys = enumStsSubstrateIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range1
                        Case enumCmdSubstrateIDs.MoveOut
                            m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.NoCommand : m_SysSts.SubstrateSys = enumStsSubstrateIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range2


                    End Select
            End Select
            block_number = m_SysProcessNum(sysNum) \ enumBlockRange.Range1
            Select Case block_number
                Case 0
                Case 1
                    'm_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    'Call Substrate_System_1_MoveIn()
                    'If m_SysProcessNum(sysNum) <> loop_COMMAND Then m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                Case 2
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Substrate_System_2_MoveOut()
                    If m_SysProcessNum(sysNum) <> loop_COMMAND Then m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1

            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Substrate_System")
        End Try
    End Sub

    ''' <summary>
    ''' 將料從手臂放到料盒
    ''' m_SysSts.SubstrateLeftSys = enumStsSubstrateIDs.MoveOutOK
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Substrate_System_2_MoveOut()
        Try
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim bStatus As enumMotionFlag
            Dim sysNum As Integer
            sysNum = enumSys.Substrate
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200 '->1230
                    m_Param.Flags.Pause.SysSubstrateFinished = False
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    If (m_Param.Variable.IO.UseBlow2 = True) Then
                        Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Normal)
                    End If
                    m_SysProcessNum(sysNum) = 1210
                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_SysProcessNum(sysNum) = 1220
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                            m_SysProcessNum(sysNum) = 1215
                        End If
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<送料汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1215
                    End If
                Case 1215
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1210
                    End If
                Case 1220
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Action)
                    m_SysProcessNum(sysNum) = 1230
                Case 1230
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1240
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸右移>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1235
                    End If
                Case 1235
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1220
                    End If



                Case 1240
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Action)
                    m_SysProcessNum(sysNum) = 1250
                Case 1250
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1260
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸下降>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1255
                    End If
                Case 1255
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1240
                    End If
                Case 1260
                    Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1270
                Case 1270
                    Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1280
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料電磁鐵關閉>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1275
                    End If
                Case 1275
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1260
                    End If
                Case 1280
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1290
                Case 1290
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1300
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1295
                    End If
                Case 1295
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1240
                    End If
                Case 1300

                    m_Param.Flags.Pause.SysSubstrateFinished = True
                    m_SysSts.SubstrateSys = enumStsSubstrateIDs.MoveOutOK
                    m_SysProcessNum(sysNum) = loop_COMMAND



            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Substrate_System_2_MoveOut")
        End Try
    End Sub


    ''' <summary>
    ''' 退料主系統
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub TopSubstrateOut()
        Try
            Dim sysNum As Integer
            Dim sysProcessNum As Integer
            sysNum = enumSys.TopSubstrateOut
            sysProcessNum = m_SysProcessNum(sysNum)
            Select Case sysProcessNum
                Case 0, loop_COMMAND
                Case 1200
                    If m_Param.Flags.System.SysInitHomeOk Then
                        m_SysProcessNum(sysNum) = 1210
                    End If
                Case 1210
                    If m_Param.Flags.System.SysInitHomeOk Then
                        If m_Param.Flags.Substrate.SubstrateCanUse = True Then
                            If m_Param.Flags.Substrate.SubstrateHavePiece = True Then
                                If m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.NoCommand Then
                                    If Not (m_SysSts.SubstrateSys = enumStsSubstrateIDs.Unknow) Then
                                        m_Param.Flags.Substrate.SubstrateCanUse = False
                                        m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.MoveOut
                                        m_SysProcessNum(sysNum) = 1220
                                    End If
                                End If
                            End If
                        End If
                    Else
                        m_SysProcessNum(sysNum) = 1200
                    End If
                Case 1220
                    If m_SysCmd.SubstrateSys = enumCmdSubstrateIDs.NoCommand Then
                        Select Case m_SysSts.SubstrateSys
                            Case enumStsSubstrateIDs.Unknow
                            Case enumStsSubstrateIDs.MoveOutOK
                                m_Param.Flags.Substrate.SubstrateCanUse = True
                                m_Param.Flags.Substrate.SubstrateHavePiece = False
                                m_SysProcessNum(sysNum) = 1210
                        End Select
                    End If

            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?TopSubstrateOut")
        End Try
    End Sub



    Private m_ShowScale As Double = 0.001
    Private m_SysCmd As CSystemCommand
    Private m_SysSts As CSystemStatus

    Private m_InputStart As Integer = 0
    Private m_InputStep As Integer = 1
    Private m_OutputIsOK As Short = 0
    Private Sub Top_System()
        Try
            Dim block_number As Integer
            Dim sysNum As Integer

            sysNum = enumSys.Top
            Select Case m_SysProcessNum(sysNum)
                Case loop_COMMAND
                    Select Case m_SysCmd.TopSys
                        Case enumCmdTopIDs.NoCommand
                        Case enumCmdTopIDs.Home
                            m_SysCmd.TopSys = enumCmdTopIDs.NoCommand
                            m_SysSts.TopSys = enumStsTopIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range1
                        Case enumCmdTopIDs.Work
                            m_SysCmd.TopSys = enumCmdTopIDs.NoCommand
                            m_SysSts.TopSys = enumStsTopIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range2

                    End Select
            End Select
            block_number = m_SysProcessNum(sysNum) \ enumBlockRange.Range1
            Select Case block_number
                Case 0
                Case 1
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Top_System_1_Home()
                    If m_SysProcessNum(sysNum) <> loop_COMMAND Then
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
                Case 2
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Top_System_2_Work()
                    If m_SysProcessNum(sysNum) <> loop_COMMAND Then
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Top_System")
        End Try
    End Sub

    Private Sub Top_System_1_Home()
        Try
            Dim sysNum As Integer
            sysNum = enumSys.Top
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.Home
                    m_SysProcessNum(sysNum) = 1210
                Case 1210
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.Home
                                m_SysSts.TopSys = enumStsTopIDs.Home
                                m_SysProcessNum(sysNum) = loop_COMMAND
                        End Select
                    End If

            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Top_System_1_Home")
        End Try
    End Sub
    Private Sub Top_System_2_Work()
        Try
            Dim sysNum As Integer
            Dim snrStatus As Boolean
            Static startTime As Double
            sysNum = enumSys.Top
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    startTime = m_Timer.GetMilliseconds
                    If m_Param.Flags.System.SysInitHomeOk = True Then
                        If m_Param.Flags.Pause.WaitStop = True Then
                            m_SysProcessNum(sysNum) = 1205
                        Else
                            If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                                If Not m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow Then
                                    m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.SubstrateIn
                                    m_SysProcessNum(sysNum) = 1210
                                End If
                            End If
                        End If
                    End If
                Case 1205
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1200
                    End If
                Case 1210
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.SubstrateInOk
                                m_SysTime(sysNum) = m_Timer.GetMilliseconds
                                'm_Param.Flags.System.Complete = False
                                Call m_Laser.DigitialOutSet(CLaser.PIN_OUTPUT, False)
                                m_SysProcessNum(sysNum) = 1220
                        End Select
                    End If

                Case 1220

                    If m_Param.Flags.System.SysInitHomeOk = True Then
                        If m_Param.Flags.Pause.WaitStop = True Then
                            m_SysProcessNum(sysNum) = 1225
                        Else
                            Call m_Laser.DigitialInGet(CLaser.PIN_INPUT, snrStatus) 'low active
                            If snrStatus = False Then
                                startTime = m_Timer.GetMilliseconds
                                m_Param.Flags.System.Complete = False
                                Call m_Laser.DigitialOutSet(CLaser.PIN_OUTPUT, True)
                                m_Param.Flags.System.Complete = True
                                m_SysTime(sysNum) = m_Timer.GetMilliseconds()
                                m_Param.Idx.System.WorkStep = 0
                                m_Param.Idx.System.JobIdx = 0
                                m_SysProcessNum(sysNum) = 1230
                            End If
                        End If
                        
                    End If
                Case 1225
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1200
                    End If
                     
                Case 1230
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        If Not m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow Then
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.Punch
                            m_SysProcessNum(sysNum) = 1240
                        End If
                    End If
                Case 1240
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.PunchOK
                                m_SysProcessNum(sysNum) = 1250

                                'm_SysProcessNum(sysNum) = 2000
                            Case enumStsWorkholderIDs.PunchWorkholderVaccumError
                                Call ShowErrorMessage(sysNum, "平台真空建立異常，請手動排除!!!")
                                m_SysProcessNum(sysNum) = 1245
                            Case enumStsWorkholderIDs.BlowVaccumError
                                Call ShowErrorMessage(sysNum, "吹氣1異常，請手動排除!!!")
                                m_SysProcessNum(sysNum) = 1245

                        End Select
                    End If
                Case 1245
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        m_Param.Flags.Pause.WaitStop = True
                        m_SysProcessNum(sysNum) = 1247
                    ElseIf m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Then
                        m_Param.Flags.Pause.WaitStop = True
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1247
                    End If

                Case 1247
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1200
                    End If
                Case 1250
                    If m_Param.Flags.System.SysInitHomeOk = True Then
                        If m_Param.Flags.Pause.WaitStop = True Then
                            m_SysProcessNum(sysNum) = 1235
                        Else
                            If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                                If Not (m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow) Then
                                    m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.ImageAlignment
                                    m_Param.Idx.System.ImageAlignmentRetry = 0
                                    For i = 0 To m_ListLine.Count - 1
                                        InvokePanelVisible(False, grbCamera.Controls(m_ListLine(i).ID))
                                    Next
                                    m_SysProcessNum(sysNum) = 1260
                                End If
                            End If
                        End If
                    End If
                Case 1255
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1230
                    End If
                Case 1260
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.ImageAlignmentOK
                                m_SysProcessNum(sysNum) = 1280
                            Case enumStsWorkholderIDs.ImageAlignmentError '往下跑
                                Call ShowErrorMessage(sysNum, "對位異常，是否PASS??")
                                m_SysProcessNum(sysNum) = 1275

                        End Select
                    End If

                Case 1275
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1300
                    ElseIf m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Then
                        m_Param.Flags.Pause.WaitStop = True
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1278
                    End If

                Case 1278
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1200
                    End If

                Case 1280
                    If m_Param.Flags.Pause.WaitStop = True Then
                        m_SysProcessNum(sysNum) = 1285
                    Else
                        If (m_Param.Idx.System.JobIdx >= m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep).Count) Then
                            m_SysProcessNum(sysNum) = 1300
                        Else
                            If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                                If Not (m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow) Then
                                    m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.Run
                                    m_Param.Idx.System.ImageAlignmentRetry = 0
                                    m_SysProcessNum(sysNum) = 1290
                                End If
                            End If
                        End If

                    End If

                Case 1285
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1280
                    End If

                Case 1290
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.RunOK
                                m_SysProcessNum(sysNum) = 1300
                            Case enumStsWorkholderIDs.RunError
                                Call ShowErrorMessage(sysNum, "雷射參數異常，是否PASS??")
                                m_SysProcessNum(sysNum) = 1295
                        End Select
                    End If

                Case 1295
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1300
                    ElseIf m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Then
                        Call LightNormalRun()
                        Call ShowErrorMessage(sysNum, "雷射參數異常，請先手動移除並調整參數!!!")
                        m_SysProcessNum(sysNum) = 1297
                    End If
                Case 1297
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        m_Param.Flags.Pause.WaitStop = True
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1298
                    ElseIf m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Then
                        m_Param.Flags.Pause.WaitStop = True
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1298
                    End If
                Case 1298
                    If IsAllProcessStop() Then
                        m_SysProcessNum(sysNum) = 1200
                    End If

                Case 1300
                    m_Param.Idx.System.JobIdx = m_Param.Idx.System.JobIdx + 1

                    If (m_Param.Idx.System.JobIdx >= m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep).Count OrElse m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep).Count = 0) Then
                        m_Param.Idx.System.JobIdx = 0
                        m_Param.Idx.System.WorkStep = m_Param.Idx.System.WorkStep + 1
                        If (m_Param.Idx.System.WorkStep >= m_CurrentProject.WorkStep) Then
                            m_Param.Idx.System.JobIdx = 0
                            m_Param.Idx.System.WorkStep = 0
                            m_SysProcessNum(sysNum) = 2000
                        Else
                            m_SysProcessNum(sysNum) = 1250
                        End If
                    Else
                        m_SysProcessNum(sysNum) = 1250
                    End If

                Case 2000
                    If m_Param.Flags.Substrate.SubstrateCanUse = True Then
                        If m_Param.Flags.Substrate.SubstrateHavePiece = False Then
                            If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                                If Not (m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow) Then
                                    m_Param.Flags.Substrate.SubstrateCanUse = False
                                    m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.SubstrateOut
                                    m_Param.Idx.System.ImageAlignmentRetry = 0
                                    m_SysProcessNum(sysNum) = 2010
                                End If
                            End If
                        End If
                    End If

                Case 2010
                    If m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand Then
                        Select Case m_SysSts.WorkholderSys
                            Case enumStsWorkholderIDs.Unknow
                            Case enumStsWorkholderIDs.SubstrateOutOk, enumStsWorkholderIDs.SubstrateOutError
                                m_Param.Flags.Substrate.SubstrateHavePiece = True
                                m_Param.Flags.Substrate.SubstrateCanUse = True
                                m_SysProcessNum(sysNum) = 1200
                                Try
                                    InvokeStatusLabel(((m_Timer.GetMilliseconds - startTime) / 1000.0).ToString() & " (s)", lblCutTime)
                                Catch ex As Exception
                                End Try
                        End Select
                    End If


            End Select

        Catch ex As Exception

        End Try
    End Sub

    Private Sub Workholder_System()
        Try
            Dim block_number As Integer
            Dim sysNum As Integer
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case loop_COMMAND
                    Select Case m_SysCmd.WorkholderSys
                        Case enumCmdWorkholderIDs.NoCommand
                        Case enumCmdWorkholderIDs.Home
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range1
                        Case enumCmdWorkholderIDs.SubstrateIn
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range2
                        Case enumCmdWorkholderIDs.ImageAlignment
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range3


                            'm_SysSts.WorkholderSys = enumStsWorkholderIDs.ImageAlignmentOK
                            'm_SysProcessNum(sysNum) = loop_COMMAND

                        Case enumCmdWorkholderIDs.Run
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range4

                            'm_SysSts.WorkholderSys = enumStsWorkholderIDs.RunOK
                            'm_SysProcessNum(sysNum) = loop_COMMAND
                        Case enumCmdWorkholderIDs.SubstrateOut
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range5
                        Case enumCmdWorkholderIDs.Punch
                            m_SysCmd.WorkholderSys = enumCmdWorkholderIDs.NoCommand
                            m_SysSts.WorkholderSys = enumStsWorkholderIDs.Unknow
                            m_SysProcessNum(sysNum) = 1200 + enumBlockRange.Range6
                    End Select
            End Select
            block_number = m_SysProcessNum(sysNum) \ enumBlockRange.Range1
            Select Case block_number
                Case 0
                Case 1
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Workholder_System_1_Home()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
                Case 2
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Workholder_System_2_SubstrateIn()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
                Case 3
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Call Workholder_System_3_ImageAlignment()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
                Case 4
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Workholder_System_4_Run()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If

                Case 5
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Workholder_System_5_SubstrateOut()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
                Case 6
                    m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) - block_number * enumBlockRange.Range1
                    Workholder_System_6_Punch()
                    If m_SysProcessNum(sysNum) = loop_COMMAND Then
                    Else
                        m_SysProcessNum(sysNum) = m_SysProcessNum(sysNum) + block_number * enumBlockRange.Range1
                    End If
            End Select
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Workholder_System")
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    ''' <summary>
    ''' 平台復歸
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Workholder_System_1_Home()
        Try
            Dim sysNum As Integer
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            'Dim axisID2 As Integer
            'Dim tarPos1 As Double
            'Dim tarPos2 As Double
            'Dim bStatus As enumMotionFlag
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1210
                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                            If cylStatus = enumCylSts.Ready Then
                                Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                                If cylStatus = enumCylSts.Ready Then
                                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                                    If cylStatus = enumCylSts.Ready Then
                                        Call m_DA.DigO.CheckCylReady(enumCyl.Blow1, cylStatus)
                                        If cylStatus = enumCylSts.Ready Then
                                            Call m_DA.DigO.CheckCylReady(enumCyl.Blow2, cylStatus)
                                            If cylStatus = enumCylSts.Ready Then
                                                m_SysProcessNum(sysNum) = 1220
                                            ElseIf cylStatus = enumCylSts.TimeOut Then
                                                Call ShowErrorMessage(sysNum, "<吹氣2>動作時間過久異常!!")
                                                m_SysProcessNum(sysNum) = 1212
                                            End If
                                        ElseIf cylStatus = enumCylSts.TimeOut Then
                                            Call ShowErrorMessage(sysNum, "<吹氣1>動作時間過久異常!!")
                                            m_SysProcessNum(sysNum) = 1212
                                        End If
                                    ElseIf cylStatus = enumCylSts.TimeOut Then
                                        Call ShowErrorMessage(sysNum, "<收左右汽缸>動作時間過久異常!!")
                                        m_SysProcessNum(sysNum) = 1212
                                    End If
                                ElseIf cylStatus = enumCylSts.TimeOut Then
                                    Call ShowErrorMessage(sysNum, "<收升降汽缸>動作時間過久異常!!")
                                    m_SysProcessNum(sysNum) = 1212
                                End If
                            ElseIf cylStatus = enumCylSts.TimeOut Then
                                Call ShowErrorMessage(sysNum, "<料升降汽缸>動作時間過久異常!!")
                                m_SysProcessNum(sysNum) = 1212
                            End If
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            Call ShowErrorMessage(sysNum, "<電磁鐵>動作時間過久異常!!")
                            m_SysProcessNum(sysNum) = 1212
                        End If
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<平台真空>平太真空時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1212
                    End If
                Case 1212
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1200
                    Else
                        Call ShowErrorMessage(sysNum, "復歸異常!!")
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1220
                    axisID = enumAxis.WorkholderX
                    m_Motion.HomeCancel(axisID) = False
                    Call m_Motion.MoveHome(axisID)
                    m_Param.Time.Workholder.MoveStart = m_Timer.GetMilliseconds()
                    m_SysProcessNum(sysNum) = 1230
                Case 1230
                    If m_Timer.GetMilliseconds() - m_Param.Time.Workholder.MoveStart >= 120 * 1000 Then
                        Call ShowErrorMessage(sysNum, "平台水平軸復歸逾時,請檢查驅動器報警或軟體設定值錯誤!!")
                        m_SysProcessNum(sysNum) = 1240
                    Else
                        axisID = enumAxis.WorkholderX
                        If m_Motion.HomeRdy(axisID) = enumMotionFlag.eReady Then
                            m_SysTime(sysNum) = m_Timer.GetMilliseconds()
                            m_SysProcessNum(sysNum) = 1300
                        End If
                    End If
                Case 1240
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1220
                    End If
                Case 1300
                    Call ShowErrorMessage(sysNum, "復歸完成!!")
                    m_SysProcessNum(sysNum) = 1350
                Case 1350
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.Home
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If
            End Select
        Catch ex As Exception
            Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Workholder_System_1_Home")
        End Try
    End Sub
    Private Sub Workholder_System_4_Run()
        Try
            Dim sysNum As Integer
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim Status As enumMotionFlag
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    m_Param.Flags.Pause.SysWorkholderFinished = False
                    Dim idx As Integer = m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep)(m_Param.Idx.System.JobIdx)
                    ReloadCutLine(m_Param.Idx.System.WorkStep, idx)
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Action)
                    m_SysProcessNum(sysNum) = 1210
                     
                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1220
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1220
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1230
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1230
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1240
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1240
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1250
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1250
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        If m_Param.Idx.System.WorkStep = 0 Then
                            tarPos1 = m_Param.Pos.Workholder.WorkHolderCutX1
                        Else
                            tarPos1 = m_Param.Pos.Workholder.WorkHolderCutX2
                        End If

                        Call m_Motion.MoveAbs(axisID, tarPos1, Status)
                        'Call m_DA.DigO.CylGo(enumCyl.WorkholderForwardReverse, enumCyllogic.Normal)
                        If Status = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1260
                    End If
                 
                Case 1260
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        m_SysProcessNum(sysNum) = 1270
                    End If
 
                Case 1270
                    Try
                        Dim idx As Integer = m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep)(m_Param.Idx.System.JobIdx)
                        m_Laser.PRR = m_ListLine(idx).LaserPRR ' m_Param.Variable.Laser.PRR.ToString()
                        m_SysTime(sysNum) = m_Timer.GetMilliseconds()
                        m_SysProcessNum(sysNum) = 1280
                    Catch ex As Exception
                        m_SysProcessNum(sysNum) = 3000
                    End Try

                Case 1280
                    If m_Timer.GetMilliseconds() - m_SysTime(sysNum) >= 100 Then
                        Try
                            Dim idx As Integer = m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep)(m_Param.Idx.System.JobIdx)
                            m_Laser.OperatingPower = m_ListLine(idx).LaserPower ' m_Param.Variable.Laser.Power.ToString()
                            'm_Laser.LaserGuide = False
                            'm_Laser.LaserEmission = True
                            m_SysProcessNum(sysNum) = 1290
                        Catch ex As Exception
                            m_SysProcessNum(sysNum) = 3000
                        End Try
                    End If


                Case 1290

                    Try
                        Dim centerXInGalvo As Double = 0
                        Dim centerYInGalvo As Double = 0
                        Dim newX1InGalvo As Double = 0
                        Dim newY1InGalvo As Double = 0
                        Dim newX2InGalvo As Double = 0
                        Dim newY2InGalvo As Double = 0
                        Dim offsetXInGalvo As Double = 0
                        Dim offsetYInGalvo As Double = 0
                        Dim angleInGalvo As Double = 0
                        Dim idx As Integer = 0

                        'offsetXInGalvo = ((m_Param.Pos.Workholder.ImageAlignRealX - m_Param.Variable.Align.ImageOrginalX(m_Param.Idx.System.WorkStep))) * PX2MM
                        'offsetYInGalvo = (-((m_Param.Pos.Workholder.ImageAlignRealY - m_Param.Variable.Align.ImageOrginalY(m_Param.Idx.System.WorkStep)))) * PX2MM
                        'angleInGalvo = -(m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(m_Param.Idx.System.WorkStep))

                        'centerXInGalvo = (m_Param.Variable.Align.ImageCenterX(m_Param.Idx.System.WorkStep) - m_Cross.X) * PX2MM
                        'centerYInGalvo = -(m_Param.Variable.Align.ImageCenterY(m_Param.Idx.System.WorkStep) - m_Cross.Y) * PX2MM




                        'offsetXInGalvo = ((m_Param.Pos.Workholder.ImageAlignRealOffsetX - m_Param.Variable.Align.ImageOrginalOffsetX(m_Param.Idx.System.WorkStep)))
                        'offsetYInGalvo = ((m_Param.Pos.Workholder.ImageAlignRealOffsetY - m_Param.Variable.Align.ImageOrginalOffsetY(m_Param.Idx.System.WorkStep)))
                        'angleInGalvo = 0 '(m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(m_Param.Idx.System.WorkStep))

                        'centerXInImage = m_Param.Variable.Align.ImageCenterX(pWorkStep) + VisionImageWidth / 2
                        'centerYInImage = m_Param.Variable.Align.ImageCenterY(pWorkStep) + VisionImageHeight / 2


                        'centerXInGalvo = m_Param.Variable.Align.ImageOrginalOffsetX(m_Param.Idx.System.WorkStep) * PX2MM
                        'centerYInGalvo = m_Param.Variable.Align.ImageOrginalOffsetY(m_Param.Idx.System.WorkStep) * PX2MM
                        'offsetXInGalvo = offsetXInGalvo * PX2MM
                        'offsetYInGalvo = offsetYInGalvo * PX2MM
                        idx = m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep)(m_Param.Idx.System.JobIdx)
                        newX1InGalvo = m_ListLine(idx).StartX
                        newY1InGalvo = m_ListLine(idx).StartY
                        newX2InGalvo = m_ListLine(idx).EndX
                        newY2InGalvo = m_ListLine(idx).EndY


                        If (CheckRTCOutRange(newX1InGalvo, newY1InGalvo) = True OrElse CheckRTCOutRange(newX2InGalvo, newY2InGalvo) = True) Then
                            m_SysProcessNum(sysNum) = 1295
                        Else
                            Call m_Laser.setstartlist(1)
                            'For index = 0 To m_lstLineOnWorkStep(m_Param.Idx.System.WorkStep).Count - 1

                            Call m_Laser.setScannerDelays(m_ListLine(idx).JumpDelay, m_ListLine(idx).MarkDelay, m_ListLine(idx).PolygonDelay)
                            Call m_Laser.SetLaserDelays(m_ListLine(idx).LaserOnDelay, m_ListLine(idx).LaserOffDelay)
                            Call m_Laser.SetJumpSpeed(m_ListLine(idx).JumpSpeed)
                            Call m_Laser.SetMarkSpeed(m_ListLine(idx).MarkSpeed)

                            'Call NewPos(offsetXInGalvo, offsetYInGalvo, angleInGalvo, centerXInGalvo, centerYInGalvo, m_ListLine(idx).StartX, m_ListLine(idx).StartY, newX1InGalvo, newY1InGalvo)
                            'Call NewPos(offsetXInGalvo, offsetYInGalvo, angleInGalvo, centerXInGalvo, centerYInGalvo, m_ListLine(idx).EndX, m_ListLine(idx).EndY, newX2InGalvo, newY2InGalvo)




                            'FMain.GalvoPositionToEncoder(m_ListLine(idx).StartX, m_ListLine(idx).StartY, newX1InGalvo, newY1InGalvo)
                            'FMain.GalvoPositionToEncoder(m_ListLine(idx).EndX, m_ListLine(idx).EndY, newX2InGalvo, newY2InGalvo)

                            If (m_ListLine(idx).RepeatMode = eRepeatMode.Mode1) Then
                                For i = 1 To m_ListLine(idx).RepeatCount
                                    Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))

                                    Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                                Next
                            Else
                                Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                                For i = 1 To m_ListLine(idx).RepeatCount
                                    If (i Mod 2 = 0) Then
                                        Call m_Laser.MarkAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                                    Else
                                        Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                                    End If
                                Next
                            End If
                            'Next

                            Call m_Laser.SetEndofList()
                            Call m_Laser.ExecuteList(1)
                            m_SysProcessNum(sysNum) = 1300
                        End If
                         
                        
                    Catch ex As Exception
                        m_SysProcessNum(sysNum) = 3000
                    End Try
                Case 1295
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                    m_SysProcessNum(sysNum) = loop_COMMAND
                    m_Param.Flags.Pause.SysWorkholderFinished = True

                Case 1300
                    If m_Laser.ListExecutionFinish() = True Then
                        m_SysProcessNum(sysNum) = 2000
                    End If
                Case 2000
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunOK
                    m_SysProcessNum(sysNum) = loop_COMMAND
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                Case 3000
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.RunError
                    m_SysProcessNum(sysNum) = loop_COMMAND
                    m_Param.Flags.Pause.SysWorkholderFinished = True
            End Select
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Workholder_System_1_Home")
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System_1_Home", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 送料待料位置到達
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Workholder_System_5_SubstrateOut()
        Try
            Dim sysNum As Integer
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim bStatus As enumMotionFlag

            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    m_Param.Flags.Pause.SysWorkholderFinished = False
                    m_SysProcessNum(sysNum) = 1205
                Case 1205
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstrateOutX1
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then
                            Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Normal)
                            m_SysProcessNum(sysNum) = 1210
                        End If
                    End If
                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1220
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料上下汽缸>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1215
                    End If

                Case 1215
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1210
                    End If

                Case 1220
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1230
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料左右汽缸>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1225
                    End If

                Case 1225
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1220
                    End If

                Case 1230
                    Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1250
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<電磁鐵>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1240
                    End If

                Case 1240
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1230
                    End If

                Case 1250
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1260

                Case 1260
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1270
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料上下汽缸>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1265
                    End If

                Case 1265
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1260
                    End If

                Case 1270
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstrateOutX1
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1280
                    End If

                Case 1280
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1290
                    End If
                Case 1290
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1300
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸下降>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1295
                    End If
                Case 1295
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1290
                    End If
                Case 1300
                    Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Action)
                    m_SysProcessNum(sysNum) = 1310

                Case 1310
                    Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1320
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<電磁鐵>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1315
                    End If
                Case 1315
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1300
                    End If

                Case 1320
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1330
                Case 1330
                    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1340
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<平台解真空>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1335
                    End If

                Case 1335
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1330
                    End If

                Case 1340
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1350

                Case 1350
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1360
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1355
                    End If
                Case 1355
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1350
                    End If

                Case 1360
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.SubstrateOutOk
                    m_SysProcessNum(sysNum) = loop_COMMAND





                    'Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Action)
                    'm_SysProcessNum(sysNum) = 1370

                Case 1370
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1380
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸右移>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1375
                    End If
                Case 1375
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1370
                    End If

                Case 1380
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1390
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸下降>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1385
                    End If

                Case 1385
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1380
                    End If

                Case 1390
                    Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1398
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<電磁鐵>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1395
                    End If
                Case 1395
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1390
                    End If

                Case 1398
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstratePunchX
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1400
                    End If

                Case 1400
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1410
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1405
                    End If

                Case 1405
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.No Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Cancel Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1400
                    End If

                Case 1410
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        m_SysProcessNum(sysNum) = 1420
                    End If

                Case 1420
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.SubstrateOutOk
                    m_SysProcessNum(sysNum) = loop_COMMAND
            End Select
        Catch ex As Exception
            'Call MsgBox(ex.Message() + ex.StackTrace, MsgBoxStyle.Critical, "FMain?Workholder_System_3_ImageAlignment")
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System_5_SubstrateOut", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
    ''' <summary>
    ''' 送料待料位置到達
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Workholder_System_6_Punch()
        Try
            Dim sysNum As Integer
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim bStatus As enumMotionFlag
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    m_Param.Flags.Pause.SysWorkholderFinished = False
                    m_SysProcessNum(sysNum) = 1210

                Case 1210
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1220
                Case 1220
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_SysProcessNum(sysNum) = 1230
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                            m_SysProcessNum(sysNum) = 1225
                        End If
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<沖壓汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1225
                    End If
                Case 1225
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        m_SysProcessNum(sysNum) = 1200
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.PunchWorkholderVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1230
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstrateBlowX
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1240
                    End If

                Case 1240
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Action)
                        m_SysTime(sysNum) = m_Timer.GetMilliseconds
                        m_SysProcessNum(sysNum) = 1250
                    End If

                Case 1250
                    Call m_DA.DigO.CheckCylReady(enumCyl.Blow1, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1260
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<吹氣1>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1255
                    End If

                Case 1255
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Action)
                        m_SysTime(sysNum) = m_Timer.GetMilliseconds
                        m_SysProcessNum(sysNum) = 1250
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.BlowVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1260
                    If (m_Timer.GetMilliseconds - m_SysTime(sysNum) >= m_Param.Variable.IO.Blow1Delay) Then
                        Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1270
                    End If

                Case 1270
                    Call m_DA.DigO.CheckCylReady(enumCyl.Blow1, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1280
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<吹氣1>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1275
                    End If

                Case 1275
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1270
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.BlowVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1280
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstratePunchX
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1290
                    End If
                Case 1290
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1300
                    End If
                Case 1300
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1310
                        Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Action)
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<沖壓汽缸下降>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1305
                    End If
                Case 1305
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1300
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.PunchWorkholderVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1310
                    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1320
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<平台真空>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1315
                    End If

                Case 1315
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1310
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.PunchWorkholderVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1320
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1330
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<沖壓汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1325
                    End If

                Case 1325
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1320
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.PunchWorkholderVaccumError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1330
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.PunchOK
                    m_SysProcessNum(sysNum) = loop_COMMAND


            End Select
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System_6_Punch", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 送料待料位置到達
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Workholder_System_2_SubstrateIn()
        Try
            Dim sysNum As Integer
            Dim cylStatus As enumCylSts
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim bStatus As enumMotionFlag
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200  'Move substate in to up
                    m_Param.Flags.Pause.SysWorkholderFinished = False
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    m_SysProcessNum(sysNum) = 1210

                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1220
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<沖壓汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1215
                    End If

                Case 1215
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1210
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.SubstrateInError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1220 'Move substate out to up
                    Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1230
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<收料汽缸上升>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1225
                    End If

                Case 1225
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                        m_SysProcessNum(sysNum) = 1220
                    Else
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.SubstrateInError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If
                     
                Case 1230
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        tarPos1 = m_Param.Pos.Workholder.SubstrateInX1
                        m_Motion.IsExternalParameters(axisID) = False
                        Call m_Motion.MoveAbs(axisID, tarPos1, bStatus)
                        If bStatus = enumMotionFlag.eSent Then m_SysProcessNum(sysNum) = 1240
                    End If

                Case 1240
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.SubstrateInOk
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If


            End Select
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System_2_SubstrateIn", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    ''' <summary>
    ''' 視覺定位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Workholder_System_3_ImageAlignment()
        Try
            Dim sysNum As Integer
            Dim axisID As Integer
            Dim tarPos1 As Double
            Dim status As enumMotionFlag
            Dim cylStatus As enumCylSts
            sysNum = enumSys.Workholder
            Select Case m_SysProcessNum(sysNum)
                Case 0, loop_COMMAND
                Case 1200
                    m_Param.Flags.Pause.SysWorkholderFinished = False
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Action)
                    m_SysProcessNum(sysNum) = 1210
                Case 1210
                    Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1220
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        m_Param.Flags.Pause.SysWorkholderFinished = True
                        m_SysSts.WorkholderSys = enumStsWorkholderIDs.ImageAlignmentError
                        m_SysProcessNum(sysNum) = loop_COMMAND
                    End If

                Case 1220
                    If (m_Param.Variable.IO.UseBlow2 = True) Then
                        Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1230
                    Else
                        m_SysProcessNum(sysNum) = 1240
                    End If

                Case 1230
                    Call m_DA.DigO.CheckCylReady(enumCyl.Blow2, cylStatus)
                    If cylStatus = enumCylSts.Ready Then
                        m_SysProcessNum(sysNum) = 1240
                    ElseIf cylStatus = enumCylSts.TimeOut Then
                        Call ShowErrorMessage(sysNum, "<吹氣2>動作時間過久異常!!")
                        m_SysProcessNum(sysNum) = 1235
                    End If

                Case 1235
                    If m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.OK Or m_FErrorMsg(sysNum).Result = Windows.Forms.DialogResult.Yes Then
                        Call LightNormalRun()
                        Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Action)
                        m_SysProcessNum(sysNum) = 1230
                    Else
                         m_SysProcessNum(sysNum) = 1240
                    End If

                Case 1240
                    axisID = enumAxis.WorkholderX
                    If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                        If m_Param.Idx.System.WorkStep = 0 Then
                            tarPos1 = m_Param.Pos.Workholder.WorkHolderCutX1
                        Else
                            tarPos1 = m_Param.Pos.Workholder.WorkHolderCutX2
                        End If
                        '    m_Motion.AccExt(axisID) = 1960000 : m_Motion.DecExt(axisID) = 1960000
                        '  m_Motion.MaxVelExt(axisID) = 200000
                        ' m_Motion.IsExternalParameters(axisID) = True
                        Call m_Motion.MoveAbs(axisID, tarPos1, status)
                        'Call m_DA.DigO.CylGo(enumCyl.WorkholderForwardReverse, enumCyllogic.Normal)
                        If status = enumMotionFlag.eSent Then
                            Call m_Laser.setstartlist(1)
                            Call m_Laser.SetJumpSpeed(10000)
                            Call m_Laser.JumpAbs(5000, 5000)
                            Call m_Laser.SetEndofList()
                            Call m_Laser.ExecuteList(1)
                            m_SysProcessNum(sysNum) = 1250
                        End If

                    End If

                Case 1250
                    If (m_Laser.ListExecutionFinish = True) Then
                        axisID = enumAxis.WorkholderX
                        If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                            m_SysProcessNum(sysNum) = 1260
                        End If
                    End If
                Case 1260
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call m_Acquist.Acquist(0, True)
                    m_SysProcessNum(sysNum) = 1270
                Case 1270
                    Call m_Acquist.CopyTo(0, m_SourceImage1st)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.CopyOf(m_SourceImage1st)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    m_SysProcessNum(sysNum) = 1280
                 
                Case 1280
                    Call m_MatchingTool(m_Param.Idx.System.WorkStep).InputImage.CopyOf(m_SourceImage1st)
                    Call m_MatchingTool(m_Param.Idx.System.WorkStep).Run(False, EnumMatchShape.None)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    m_SysProcessNum(sysNum) = 1290
                Case 1290

                    If Not m_MatchingTool(m_Param.Idx.System.WorkStep).IsRunning Then
                        If m_MatchingTool(m_Param.Idx.System.WorkStep).Results.Count > 0 Then
                            Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingTool(m_Param.Idx.System.WorkStep).Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
                            m_SysProcessNum(sysNum) = 1300
                        Else
                            m_SysProcessNum(sysNum) = 1310
                        End If
                    End If
                Case 1300
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.ImageAlignmentOK
                    m_Param.Pos.Workholder.ImageAlignT = -m_MatchingTool(m_Param.Idx.System.WorkStep).Results.Item(0).RotationD
                    m_Param.Pos.Workholder.ImageAlignRealOffsetX = (m_MatchingTool(m_Param.Idx.System.WorkStep).Results.Item(0).TranslationX - m_SourceImage1st.Width / 2)
                    m_Param.Pos.Workholder.ImageAlignRealOffsetY = (m_MatchingTool(m_Param.Idx.System.WorkStep).Results.Item(0).TranslationY - m_SourceImage1st.Height / 2)
                    m_SysProcessNum(sysNum) = loop_COMMAND

                     
                Case 1310
                    m_Param.Flags.Pause.SysWorkholderFinished = True
                    m_SysSts.WorkholderSys = enumStsWorkholderIDs.ImageAlignmentError
                    m_SysProcessNum(sysNum) = loop_COMMAND

            End Select
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "FMain?Workholder_System_3_ImageAlignment", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub


    Public Function CalAngle(ByVal x1 As Double, ByVal y1 As Double, ByVal x2 As Double, ByVal y2 As Double) As Double
        Try
            Dim x As Double = 1.0
            Dim y As Double = 1.0
            Dim radians As Double
            x = x2 - x1
            y = y2 - y1
            radians = Math.Atan2(y, x)
            Return radians * (180.0 / Math.PI)
        Catch
            Return 0
        End Try
    End Function

    Private m_Cross As VisionSystem.CReticle
    Private m_ROIRec As ROIRectangle1
    Private m_VisionStart As Boolean = False
    Private m_FirstSave As Boolean = False
    Private Sub btnVisionLeftSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionLeftSet.Click
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, "Please open project first.", CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            btnVisionLeftSet.Enabled = False
            Call EnableVision(False, btnVisionLeftSet)
            If m_VisionStart = False Then
                btnVisionLeftSet.Text = "Vision Left Set End"
                Try
                    Dim img As CImage
                    If m_ROIRec Is Nothing Then m_ROIRec = New ROIRectangle1
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    Call m_Acquist.CopyTo(0, img)

                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call Me.ImageDisplay1.CopyOf(img)

                    Call Me.ImageDisplay1.InteractiveGraphics.Add1(m_ROIRec)

                Catch ex As Exception
                    'Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
                    FMessageBox.Show(Me, ex.Message, "Run-Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try
                m_VisionStart = True
            Else
                btnVisionLeftSet.Text = "Vision Left Set Start"
                Dim rectangle As CRectangle
                m_FLoading = New FLoading("Training....")
                m_FLoading.Show()
                m_FLoading.Percent = 10
                Dim img As CImage
                Try
                    rectangle = New CRectangle
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    Call m_Acquist.CopyTo(0, img)
                    Me.ImageDisplay1.CopyOf(img)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call rectangle.SetCenterLengthsRotation(m_ROIRec.midC, m_ROIRec.midR, (m_ROIRec.col2 - m_ROIRec.col1), (m_ROIRec.row2 - m_ROIRec.row1), 0)
                    Dim pMatchingToolPath As String = CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image" & "\Left"
                    m_FLoading.Percent = 30
                    If m_MatchingToolLeft Is Nothing Then m_MatchingToolLeft = New CMatchingTool(pMatchingToolPath)

                    Try
                        If System.IO.Directory.Exists(pMatchingToolPath) = False Then
                            'My.Computer.FileSystem.CreateDirectory(pMatchingToolPath)
                            My.Computer.FileSystem.CopyDirectory("D:\DataSettings\LaserMachine\MachineData\Reserve", pMatchingToolPath, True)
                        End If
                    Catch ex As Exception

                    End Try

                    Call m_MatchingToolLeft.InputImage.CopyOf(img)
                    Call m_MatchingToolLeft.Pattern.SetRotaryRange(-10, 10)

                    'Call m_MatchingToolLeft.Pattern.SetScaleRange(1, 1) 'Error Cannot Match 
                    Call m_MatchingToolLeft.Pattern.TrainImage.CopyOf(img)
                    ' Call rectangle.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width / 3, img.Height / 3, 0)
                    m_MatchingToolLeft.Pattern.TrainRegion = rectangle
                    Call m_MatchingToolLeft.Pattern.Train()
                    m_FLoading.Percent = 50
                    Call m_MatchingToolLeft.RunParams.SetScoreProperty(0, numTempleteAcceptScoreLeft.Value)

                    Call m_MatchingToolLeft.SaveFiles()

                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StartLive(0, m_Acquist)

                    rectangle.Dispose()
                    rectangle = Nothing
                    Call Me.ImageDisplay1.InteractiveGraphics.Clear()
                    m_FirstSave = True
                    Call btnVisionLeftTest_Click(Nothing, Nothing)
                    m_FLoading.Percent = 75
                Catch ex As Exception
                End Try
                m_VisionStart = False
                Call EnableVision(True, btnVisionLeftSet)
                m_FLoading.Percent = 100
                m_FLoading.Close()
                m_FLoading.Dispose()
                m_FLoading = Nothing
            End If

        Catch ex As Exception
        Finally
            btnVisionLeftSet.Enabled = True

        End Try
    End Sub

    Private Sub btnVisionLeftTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionLeftTest.Click
        Dim searchRegion As CRectangle
        Dim img As CImage
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, "Please open project first.", CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            btnVisionLeftTest.Enabled = False
            Call EnableVision(False, btnVisionLeftTest)
            Call Me.ImageDisplay1.StopLive()
            Call m_Acquist.Acquist(0, True)
            img = New CImage
            Call m_Acquist.CopyTo(0, img)
            Call m_MatchingToolLeft.RunParams.SetScoreProperty(0, numTempleteAcceptScoreLeft.Value)

            searchRegion = New CRectangle
            Call Me.ImageDisplay1.StaticGraphics.Clear()
            Call Me.ImageDisplay1.CopyOf(img)
            Call searchRegion.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width, img.Height, 0)
            m_MatchingToolLeft.SearchRegion = searchRegion

            m_MatchingToolLeft.RunParams.RotaryEnabled = True
            m_MatchingToolLeft.RunParams.RunType = 1
            m_MatchingToolLeft.RunParams.SetRotaryRange(-30, 30)
            m_MatchingToolLeft.InputImage.CopyOf(img)
            m_MatchingToolLeft.Run(True, EnumMatchShape.None)
            If m_MatchingToolLeft.Results.Count > 0 Then
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Dim x As Double = (m_MatchingToolLeft.Results.Item(0).TranslationX - img.Width / 2) * m_Param.Variable.Workholder.CCDRatioX
                Dim y As Double = -((m_MatchingToolLeft.Results.Item(0).TranslationY - img.Height / 2) * m_Param.Variable.Workholder.CCDRatioY)
                Dim a As Double = (m_MatchingToolLeft.Results.Item(0).RotationD)
                If (m_FirstSave = True) Then
                    m_FirstSave = False
                    m_Param.Variable.Align.ImageOrginalOffsetX(0) = x
                    m_Param.Variable.Align.ImageOrginalOffsetY(0) = y
                    m_Param.Variable.Align.ImageOrginalAngle(0) = a
                    m_Param.Variable.Align.ImageCenterX(0) = m_ROIRec.midC
                    m_Param.Variable.Align.ImageCenterY(0) = m_ROIRec.midR
                    m_Param.Variable.Align.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image\Parameter.xml")
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingToolLeft.Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))

                Else
                    m_Param.Pos.Workholder.ImageAlignRealOffsetX = x
                    m_Param.Pos.Workholder.ImageAlignRealOffsetY = y
                    m_Param.Pos.Workholder.ImageAlignT = a

                    Me.Text = "分數 : " & (m_MatchingToolLeft.Results.Item(0).Score * 100) & " 橫向偏差量 :" & x & "mm 縱向偏差量:" & y & "mm " & a & "Degree"
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingToolLeft.Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
                    Call ReloadCutLine(0)
                End If

            Else
                ' Me.Text = ""
            End If
            searchRegion.Dispose()
            Call img.Dispose() : img = Nothing
            Me.ImageDisplay1.StartLive(0, m_Acquist)
            Call m_MatchingToolLeft.SaveFiles()
        Catch ex As Exception

        Finally
            btnVisionLeftTest.Enabled = True
            EnableVision(True, btnVisionLeftTest)
        End Try
    End Sub

    Private Sub btnVisionRightSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionRightSet.Click
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, "Please open project first.", CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            btnVisionRightSet.Enabled = False
            EnableVision(False, btnVisionRightSet)
            If m_VisionStart = False Then
                btnVisionRightSet.Text = "Vision Right Set End"
                Try
                    Dim img As CImage
                    If m_ROIRec Is Nothing Then m_ROIRec = New ROIRectangle1
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    m_Acquist.CopyTo(0, img)

                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Me.ImageDisplay1.CopyOf(img)

                    Call Me.ImageDisplay1.InteractiveGraphics.Add1(m_ROIRec)

                Catch ex As Exception
                    'Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
                    FMessageBox.Show(Me, ex.Message, "Run-Time Error", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try
                m_VisionStart = True
            Else
                btnVisionRightSet.Text = "Vision Right Set Start"
                Dim rectangle As CRectangle
                m_FLoading = New FLoading("Training....")
                m_FLoading.Show()
                m_FLoading.Percent = 10
                Dim img As CImage
                Try
                    rectangle = New CRectangle
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    m_Acquist.CopyTo(0, img)
                    Me.ImageDisplay1.CopyOf(img)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call rectangle.SetCenterLengthsRotation(m_ROIRec.midC, m_ROIRec.midR, (m_ROIRec.col2 - m_ROIRec.col1), (m_ROIRec.row2 - m_ROIRec.row1), 0)
                    Dim pMatchingToolPath As String = CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image" & "\Right"
                    m_FLoading.Percent = 30
                    If m_MatchingToolRight Is Nothing Then m_MatchingToolRight = New CMatchingTool(pMatchingToolPath)

                    Try
                        If System.IO.Directory.Exists(pMatchingToolPath) = False Then
                            'My.Computer.FileSystem.CreateDirectory(pMatchingToolPath)
                            My.Computer.FileSystem.CopyDirectory("D:\DataSettings\LaserMachine\MachineData\Reserve", pMatchingToolPath, True)
                        End If
                    Catch ex As Exception

                    End Try

                    Call m_MatchingToolRight.InputImage.CopyOf(img)
                    Call m_MatchingToolRight.Pattern.SetRotaryRange(-30, 30)

                    'Call m_MatchingToolRight.Pattern.SetScaleRange(1, 1) 'Error Cannot Match 
                    Call m_MatchingToolRight.Pattern.TrainImage.CopyOf(img)
                    ' Call rectangle.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width / 3, img.Height / 3, 0)
                    m_MatchingToolRight.Pattern.TrainRegion = rectangle
                    Call m_MatchingToolRight.Pattern.Train()
                    m_FLoading.Percent = 50
                    Call m_MatchingToolRight.RunParams.SetScoreProperty(0, numTempleteAcceptScoreRight.Value)

                    Call m_MatchingToolRight.SaveFiles()

                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StartLive(0, m_Acquist)

                    rectangle.Dispose()
                    rectangle = Nothing
                    Call Me.ImageDisplay1.InteractiveGraphics.Clear()
                    m_FirstSave = True
                    btnVisionRightTest_Click(Nothing, Nothing)
                    m_FLoading.Percent = 75
                Catch ex As Exception
                End Try
                m_VisionStart = False
                EnableVision(True, btnVisionRightSet)
                m_FLoading.Percent = 100
                m_FLoading.Close()
                m_FLoading.Dispose()
                m_FLoading = Nothing
            End If

        Catch ex As Exception
        Finally
            btnVisionRightSet.Enabled = True

        End Try
    End Sub

    Private Sub btnVisionRightTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisionRightTest.Click
        Dim searchRegion As CRectangle
        Dim img As CImage
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, "Please open project first.", CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            btnVisionRightTest.Enabled = False
            EnableVision(False, btnVisionRightTest)
            Call Me.ImageDisplay1.StopLive()
            Call m_Acquist.Acquist(0, True)
            img = New CImage
            m_Acquist.CopyTo(0, img)
            Call m_MatchingToolRight.RunParams.SetScoreProperty(0, numTempleteAcceptScoreRight.Value)

            searchRegion = New CRectangle
            Me.ImageDisplay1.StaticGraphics.Clear()
            Me.ImageDisplay1.CopyOf(img)
            Call searchRegion.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width, img.Height, 0)
            m_MatchingToolRight.SearchRegion = searchRegion

            m_MatchingToolRight.RunParams.RotaryEnabled = True
            m_MatchingToolRight.RunParams.RunType = 1
            m_MatchingToolRight.RunParams.SetRotaryRange(-30, 30)
            m_MatchingToolRight.InputImage.CopyOf(img)
            m_MatchingToolRight.Run(True, EnumMatchShape.None)
            If m_MatchingToolRight.Results.Count > 0 Then
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Dim x As Double = (m_MatchingToolRight.Results.Item(0).TranslationX - img.Width / 2) * m_Param.Variable.Workholder.CCDRatioX
                Dim y As Double = -((m_MatchingToolRight.Results.Item(0).TranslationY - img.Height / 2) * m_Param.Variable.Workholder.CCDRatioY)
                Dim a As Double = (m_MatchingToolRight.Results.Item(0).RotationD)
                If (m_FirstSave = True) Then
                    m_FirstSave = False
                    m_Param.Variable.Align.ImageOrginalOffsetX(1) = x
                    m_Param.Variable.Align.ImageOrginalOffsetY(1) = y
                    m_Param.Variable.Align.ImageOrginalAngle(1) = a
                    m_Param.Variable.Align.ImageCenterX(1) = m_ROIRec.midC
                    m_Param.Variable.Align.ImageCenterY(1) = m_ROIRec.midR
                    m_Param.Variable.Align.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image\Parameter.xml")
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingToolRight.Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))

                Else
                    m_Param.Pos.Workholder.ImageAlignRealOffsetX = x
                    m_Param.Pos.Workholder.ImageAlignRealOffsetY = y
                    m_Param.Pos.Workholder.ImageAlignT = a

                    Me.Text = "分數 : " & (m_MatchingToolRight.Results.Item(0).Score * 100) & " 橫向偏差量 :" & x & "mm 縱向偏差量:" & y & "mm " & a & "Degree"
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingToolRight.Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
                    ReloadCutLine(0)
                End If

            Else
                ' Me.Text = ""
            End If
            searchRegion.Dispose()
            Call img.Dispose() : img = Nothing
            Me.ImageDisplay1.StartLive(0, m_Acquist)
            Call m_MatchingToolRight.SaveFiles()
        Catch ex As Exception

        Finally
            btnVisionRightTest.Enabled = True
            EnableVision(True, btnVisionRightTest)
        End Try
    End Sub
    Public Sub EnableVision(ByVal status As Boolean, ByVal btn As Button)
        btnNewProject.Enabled = status
        btnOpenProject.Enabled = status
        btnSave.Enabled = status
        numTempleteAcceptScoreLeft.Enabled = status
        numTempleteAcceptScoreRight.Enabled = status
        Dim idx As Integer = CType(btn.Tag, Integer)

        Select Case idx
            Case 0
                btnVisionRightSet.Enabled = status
                btnVisionLeftTest.Enabled = status
                btnVisionRightTest.Enabled = status
            Case 1
                btnVisionLeftSet.Enabled = status
                btnVisionLeftTest.Enabled = status
                btnVisionRightTest.Enabled = status
            Case 2
                btnVisionRightSet.Enabled = status
                btnVisionLeftSet.Enabled = status
                btnVisionRightTest.Enabled = status
            Case 3
                btnVisionRightSet.Enabled = status
                btnVisionLeftSet.Enabled = status
                btnVisionLeftTest.Enabled = status

            Case 4
                btnAlignTest.Enabled = status
                numWorkStep.Enabled = status
                numAcceptScoreAlign.Enabled = status

            Case 5
                btnAlignSetStart.Enabled = status
                numWorkStep.Enabled = status
                numAcceptScoreAlign.Enabled = status
            Case Else

        End Select

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Try
            Call m_Laser.CloseSerial()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Try
            Call m_Laser.OpenSerial()
        Catch ex As Exception
            FMessageBox.Show(Me, "Cannot connect to this port.", CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub lbLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbLog.Click
        Try
            Dim ev As System.Windows.Forms.MouseEventArgs = CType(e, System.Windows.Forms.MouseEventArgs)
            Dim idx As Integer = lbLog.IndexFromPoint(ev.Location)
            If (idx >= 0 AndAlso idx < lbLog.Items.Count) Then
                ToolTip1.SetToolTip(lbLog, CStr(lbLog.Items(idx)))
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnReloadCorectionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReloadCorectionFile.Click
        Try
            If (m_Laser IsNot Nothing) Then
                Call m_Laser.LoadCorrectionFile("C:\\RTC4 Files\\D2_263.ctb", 1, 1.0, 1.0, 0.0, 0.0, 0.0)
                Call m_Laser.SetAngle(m_Param.Variable.Laser.Angle)
                Call m_Laser.SetOffset(m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnSaveParameter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveParameter.Click
        btnSaveParameter.Enabled = False
        Try
            If (m_Param IsNot Nothing) Then
                Dim flag As Boolean = False
                Dim logPath As String = "D:\DataSettings\LaserMachine\Logs"
                If (Not System.IO.Directory.Exists(logPath)) Then
                    System.IO.Directory.CreateDirectory(logPath)
                End If
                logPath &= "\" & DateTime.Now.ToString("yyyyMMdd") & ".log"
                'If (m_Param.Variable.Laser.PRR <> numPRR.Value) Then
                '    Call MLog.SaveLog("更改頻率", m_Param.Variable.Laser.PRR.ToString("F1"), numPRR.Value.ToString("F1"), logPath)
                '    m_Param.Variable.Laser.PRR = numPRR.Value
                '    flag = True
                '    lblLaserPRR.Text = m_Param.Variable.Laser.PRR.ToString().PadLeft(4, " ") & "kHz"
                'End If

                'If (m_Param.Variable.Laser.Power <> numPower.Value) Then
                '    Call MLog.SaveLog("更改功率", m_Param.Variable.Laser.Power.ToString("F1"), numPower.Value.ToString("F1"), logPath)
                '    m_Param.Variable.Laser.Power = numPower.Value
                '    flag = True
                '    lblLaserPower.Text = m_Param.Variable.Laser.Power.ToString().PadLeft(4, " ") & "W"
                'End If

                'If (m_Param.Variable.Graphic.PX2MM <> numPX2MM.Value) Then
                '    Call MLog.SaveLog("更改Scale Pixel to mm", m_Param.Variable.Graphic.PX2MM.ToString("F16"), numPX2MM.Value.ToString("F16"), logPath)
                '    m_Param.Variable.Graphic.PX2MM = numPX2MM.Value
                '    flag = True
                '    PX2MM = m_Param.Variable.Graphic.PX2MM
                'End If

                'If (flag) Then
                '    Call m_Param.Variable.Laser.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Parameter\Laser.xml")
                'End If
                flag = False
                If (m_Param.Variable.Graphic.OffsetX <> numImageOffsetX.Value) Then
                    Call MLog.SaveLog("更改Image Offset X", m_Param.Variable.Graphic.OffsetX.ToString(), numImageOffsetX.Value.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.Graphic.OffsetX = numImageOffsetX.Value
                    flag = True
                End If

                If (m_Param.Variable.Graphic.OffsetY <> numImageOffsetY.Value) Then
                    Call MLog.SaveLog("更改Image Offset Y", m_Param.Variable.Graphic.OffsetY.ToString(), numImageOffsetY.Value.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.Graphic.OffsetY = numImageOffsetY.Value
                    flag = True
                End If
                'If (numGalvoAngle.Value <> m_Param.Variable.Laser.Angle) Then
                '    Call MLog.SaveLog("更改GalvoAngle", m_Param.Variable.Laser.Angle.ToString("F3"), numGalvoAngle.Value.ToString("F3"), logPath)
                '    m_Param.Variable.Laser.Angle = numGalvoAngle.Value
                '    flag = True
                '    m_Laser.SetAngle(m_Param.Variable.Laser.Angle)
                'End If
                'If (numGalvoOffsetX.Value <> m_Param.Variable.Laser.OffsetX) Then
                '    Call MLog.SaveLog("更改 GalvoOffsetX", m_Param.Variable.Laser.OffsetX.ToString(), numGalvoOffsetX.Value.ToString(), logPath)
                '    m_Param.Variable.Laser.OffsetX = numGalvoOffsetX.Value
                '    flag = True
                '    Call m_Laser.SetOffset(m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
                'End If
                'If (numGalvoOffsetY.Value <> m_Param.Variable.Laser.OffsetY) Then
                '    Call MLog.SaveLog("更改 GalvoOffsetY", m_Param.Variable.Laser.OffsetY.ToString(), numGalvoOffsetY.Value.ToString(), logPath)
                '    m_Param.Variable.Laser.OffsetY = numGalvoOffsetY.Value
                '    flag = True
                '    Call m_Laser.SetOffset(m_Param.Variable.Laser.OffsetX, m_Param.Variable.Laser.OffsetY)
                'End If

                If (numDIDelay.Value <> m_Param.Variable.IO.DIDelay) Then
                    Call MLog.SaveLog("更改 DIDelay", m_Param.Variable.IO.DIDelay.ToString(), numDIDelay.Value.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.IO.DIDelay = numDIDelay.Value
                    flag = True
                End If
                If (numDODelay.Value <> m_Param.Variable.IO.DODelay) Then
                    Call MLog.SaveLog("更改 DODelay", m_Param.Variable.IO.DODelay.ToString(), numDODelay.Value.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.IO.DODelay = numDODelay.Value
                    flag = True
                End If
                If (numBlow1Delay.Value <> m_Param.Variable.IO.Blow1Delay) Then
                    Call MLog.SaveLog("更改吹氣 1 延遲", m_Param.Variable.IO.Blow1Delay.ToString(), numBlow1Delay.Value.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.IO.Blow1Delay = numBlow1Delay.Value
                    flag = True
                End If
                If (chkUseBlow2.Checked <> m_Param.Variable.IO.UseBlow2) Then
                    Call MLog.SaveLog("更改啟用吹氣2", m_Param.Variable.IO.UseBlow2.ToString(), chkUseBlow2.Checked.ToString(), enumLogType.Edit, logPath)
                    m_Param.Variable.IO.UseBlow2 = chkUseBlow2.Checked
                    flag = True
                End If


                If (flag) Then
                    Call m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
                End If
            End If
        Catch ex As Exception

        End Try
        btnSaveParameter.Enabled = True
    End Sub


    ''' <summary>
    ''' Redraw line after do alignment
    ''' </summary>
    ''' <param name="pWorkStep">Start is 0</param>
    ''' <remarks></remarks>
    Private Sub ReloadCutLine(ByVal pWorkStep As Integer)

        If Me.InvokeRequired() Then

            '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
            Dim cb As New InvokeDrawCutLineCallBack2(AddressOf ReloadCutLine)
            Me.Invoke(cb, pWorkStep)
        Else

            'Dim offsetXInImage As Double
            'Dim offsetYInImage As Double
            'Dim angleInImage As Double
            'Dim newX1InImage, newY1InImage, newX2InImage, newY2InImage, centerXInImage, centerYInImage As Double

            'offsetXInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetX - m_Param.Variable.Align.ImageOrginalOffsetX(pWorkStep)))
            'offsetYInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetY - m_Param.Variable.Align.ImageOrginalOffsetY(pWorkStep)))

            'angleInImage = (m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(pWorkStep))
            For idx = 0 To m_ListLine.Count - 1
                If (m_ListLine(idx).[Step] - 1 = pWorkStep) Then
                    ReloadCutLine(pWorkStep, idx)
                    '        centerXInImage = m_Param.Variable.Align.ImageCenterX(pWorkStep) + VisionImageWidth / 2
                    '        centerYInImage = m_Param.Variable.Align.ImageCenterY(pWorkStep) + VisionImageHeight / 2


                    '        Dim x1InImage As Double = m_ListOriginalLine(idx).StartXPX * ImageDisplay1.ImageX / grbCamera.Width
                    '        Dim y1InImage As Double = m_ListOriginalLine(idx).StartYPX * ImageDisplay1.ImageY / grbCamera.Height
                    '        Dim x2InImage As Double = m_ListOriginalLine(idx).EndXPX * ImageDisplay1.ImageX / grbCamera.Width
                    '        Dim y2InImage As Double = m_ListOriginalLine(idx).EndYPX * ImageDisplay1.ImageY / grbCamera.Height

                    '        Call NewPos(offsetXInImage, offsetYInImage, angleInImage, centerXInImage, centerYInImage, x1InImage, y1InImage, newX1InImage, newY1InImage)
                    '        Call NewPos(offsetXInImage, offsetYInImage, angleInImage, centerXInImage, centerYInImage, x2InImage, y2InImage, newX2InImage, newY2InImage)

                    '        m_ListLine(idx).StartXPX = newX1InImage * grbCamera.Width / ImageDisplay1.ImageX
                    '        m_ListLine(idx).StartYPX = newY1InImage * grbCamera.Width / ImageDisplay1.ImageX
                    '        m_ListLine(idx).EndXPX = newX2InImage * grbCamera.Width / ImageDisplay1.ImageX
                    '        m_ListLine(idx).EndYPX = newY2InImage * grbCamera.Width / ImageDisplay1.ImageX
                    '        CType(grbCamera.Controls(m_ListLine(idx).ID), CLineCtrl).Line = m_ListLine(idx)
                    '        grbCamera.Controls(m_ListLine(idx).ID).Visible = True
                    '        If (m_LineSelected IsNot Nothing AndAlso m_LineSelected.ID = m_ListLine(idx).ID) Then
                    '            m_LineSelected = m_ListLine(idx)
                    '        End If
                End If
                '    grbCamera.Refresh()
            Next


        End If
    End Sub


    ''' <summary>
    ''' Redraw line after do alignment
    ''' </summary>
    ''' <param name="pWorkStep">Start is 0</param>
    ''' <remarks></remarks>
    Private Sub ReloadCutLine(ByVal pWorkStep As Integer, ByVal pIdxLine As Integer)
        Try


            If Me.InvokeRequired() Then

                '目前執行緒和UI執行緒不同...需使用Invoke對UI做更新
                Dim cb As New InvokeDrawCutLineCallBack(AddressOf ReloadCutLine)
                Me.Invoke(cb, pWorkStep, pIdxLine)
            Else
                '目前執行緒和UI執行緒相同...可以直接對UI做更新
                Dim offsetXInImage As Double
                Dim offsetYInImage As Double
                Dim angleInImage As Double
                Dim newX1InImage, newY1InImage, newX2InImage, newY2InImage, centerXInImage, centerYInImage As Double

                offsetXInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetX - m_Param.Variable.Align.ImageOrginalOffsetX(pWorkStep)))
                offsetYInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetY - m_Param.Variable.Align.ImageOrginalOffsetY(pWorkStep)))

                angleInImage = (m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(pWorkStep))

                'centerXInImage = m_Param.Variable.Align.ImageOrginalX(pWorkStep) 'm_Param.Variable.Align.ImageCenterX(pWorkStep)
                'centerYInImage = m_Param.Variable.Align.ImageOrginalY(pWorkStep) ' m_Param.Variable.Align.ImageCenterY(pWorkStep)

                centerXInImage = m_Param.Variable.Align.ImageCenterX(pWorkStep) + VisionImageWidth / 2
                centerYInImage = m_Param.Variable.Align.ImageCenterY(pWorkStep) + VisionImageHeight / 2

                Dim x1InImage As Double = m_ListOriginalLine(pIdxLine).StartXPX '* VisionImageWidth / grbCamera.Width
                Dim y1InImage As Double = m_ListOriginalLine(pIdxLine).StartYPX ' * VisionImageHeight / grbCamera.Height
                Dim x2InImage As Double = m_ListOriginalLine(pIdxLine).EndXPX '* VisionImageWidth / grbCamera.Width
                Dim y2InImage As Double = m_ListOriginalLine(pIdxLine).EndYPX '* VisionImageHeight / grbCamera.Height

                Call NewPos(offsetXInImage, offsetYInImage, angleInImage, centerXInImage, centerYInImage, x1InImage, y1InImage, newX1InImage, newY1InImage)
                Call NewPos(offsetXInImage, offsetYInImage, angleInImage, centerXInImage, centerYInImage, x2InImage, y2InImage, newX2InImage, newY2InImage)

                m_ListLine(pIdxLine).StartXPX = newX1InImage '* grbCamera.Width / VisionImageWidth
                m_ListLine(pIdxLine).StartYPX = newY1InImage ' * grbCamera.Height / VisionImageHeight
                m_ListLine(pIdxLine).EndXPX = newX2InImage '* grbCamera.Width / VisionImageWidth
                m_ListLine(pIdxLine).EndYPX = newY2InImage '* grbCamera.Height / VisionImageHeight

                CType(grbCamera.Controls(m_ListLine(pIdxLine).ID), CLineCtrl).Line = m_ListLine(pIdxLine)
                CType(grbCamera.Controls(m_ListLine(pIdxLine).ID), CLineCtrl).Visible = True

                If (m_LineSelected IsNot Nothing AndAlso m_LineSelected.ID = m_ListLine(pIdxLine).ID) Then
                    m_LineSelected = m_ListLine(pIdxLine)
                    CType(grbCamera.Controls(m_ListLine(pIdxLine).ID), CLineCtrl).IsSelect = True
                Else
                    CType(grbCamera.Controls(m_ListLine(pIdxLine).ID), CLineCtrl).IsSelect = False
                End If
                grbCamera.Refresh()
                PropertyGrid1.Refresh()
            End If
        Catch ex As Exception
        End Try

    End Sub
    Private Sub btnPickColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPickColor.Click
        If (m_CurrentProject Is Nothing) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        Dim pcl As ColorDialog = New ColorDialog()
        If (pcl.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            m_Param.Variable.Graphic.LineColor = pcl.Color
            Call m_Param.Variable.Graphic.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Parameter\Graphic.xml")
            For i = 0 To grbCamera.Controls.Count - 1
                If (grbCamera.Controls(i).GetType() Is GetType(CLineCtrl)) Then
                    CType(grbCamera.Controls(i), CLineCtrl).Color = m_Param.Variable.Graphic.LineColor
                End If
            Next

        End If
    End Sub

    Private Sub ChangePasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStripMenuItem.Click
        If (m_Param.Flags.System.AutoRunProcedure = False AndAlso m_VisionStart = False AndAlso CLoginInformation.CurrentUser.Permission > 0) Then
            Me.Visible = False
            Dim f As FChangePassword = New FChangePassword()
            f.ShowDialog()
            f.Dispose()
            f = Nothing
            Me.Visible = True
        End If
    End Sub

    Private Sub LoginToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoginToolStripMenuItem.Click
        If (LoginToolStripMenuItem.Text = CChangeLanguage.GetString("登錄")) Then
            Dim f As FLogin = New FLogin()
            f.ShowDialog()
            If (f.LoginOK) Then
                LoginToolStripMenuItem.Text = CChangeLanguage.GetString("登出")
                Call SetPermission()
            End If
            f.Dispose()
            f = Nothing
        Else
            CLoginInformation.CurrentUser = New CPermission()
            CLoginInformation.LoginTime = New DateTime()
            Call SetPermission()
            LoginToolStripMenuItem.Text = CChangeLanguage.GetString("登錄")
        End If
    End Sub

    Private Sub btnAlignSetStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignSetStart.Click
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            Call EnableVision(False, btnAlignSetStart)
            If m_VisionStart = False Then
                btnAlignSetStart.Text = CChangeLanguage.GetString("結束")
                For i = 0 To m_ListLine.Count - 1
                    InvokePanelVisible(False, grbCamera.Controls(m_ListLine(i).ID))
                Next
                Try
                    Dim img As CImage
                    If m_ROIRec Is Nothing Then m_ROIRec = New ROIRectangle1
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    Call m_Acquist.CopyTo(0, img)

                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call Me.ImageDisplay1.CopyOf(img)

                    Call Me.ImageDisplay1.InteractiveGraphics.Add1(m_ROIRec)

                Catch ex As Exception
                    'Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
                    FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try

                Call AddLog("更改第" & numWorkStep.Value & "步的視覺", enumLogType.Edit)
                m_VisionStart = True
            Else
                btnAlignSetStart.Text = CChangeLanguage.GetString("開始")
                Dim rectangle As CRectangle
                m_FLoading = New FLoading(CChangeLanguage.GetString("訓練中...."))
                m_FLoading.Show()
                m_FLoading.Percent = 10
                Dim img As CImage
                Try
                    rectangle = New CRectangle
                    img = New CImage
                    Call Me.ImageDisplay1.StopLive()
                    Call m_Acquist.Acquist(0, True)
                    Call m_Acquist.CopyTo(0, img)
                    Me.ImageDisplay1.CopyOf(img)
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call rectangle.SetCenterLengthsRotation(m_ROIRec.midC, m_ROIRec.midR, (m_ROIRec.col2 - m_ROIRec.col1), (m_ROIRec.row2 - m_ROIRec.row1), 0)
                    Dim pMatchingToolPath As String = CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image" & "\WorkStep" & numWorkStep.Value
                    m_FLoading.Percent = 30
                    If m_MatchingTool(numWorkStep.Value - 1) Is Nothing Then m_MatchingTool(numWorkStep.Value - 1) = New CMatchingTool(pMatchingToolPath)

                    Try
                        If System.IO.Directory.Exists(pMatchingToolPath) = False Then
                            'My.Computer.FileSystem.CreateDirectory(pMatchingToolPath)
                            My.Computer.FileSystem.CopyDirectory("D:\DataSettings\LaserMachine\MachineData\Reserve", pMatchingToolPath, True)
                        End If
                    Catch ex As Exception

                    End Try

                    Call m_MatchingTool(numWorkStep.Value - 1).InputImage.CopyOf(img)
                    Call m_MatchingTool(numWorkStep.Value - 1).Pattern.SetRotaryRange(-10, 10)

                    Call m_MatchingTool(numWorkStep.Value - 1).Pattern.TrainImage.CopyOf(img)
                    m_MatchingTool(numWorkStep.Value - 1).Pattern.TrainRegion = rectangle
                    Call m_MatchingTool(numWorkStep.Value - 1).Pattern.Train()
                    m_FLoading.Percent = 50
                    Call m_MatchingTool(numWorkStep.Value - 1).RunParams.SetScoreProperty(0, numAcceptScoreAlign.Value)

                    Call m_MatchingTool(numWorkStep.Value - 1).SaveFiles()

                    Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    Call Me.ImageDisplay1.StartLive(0, m_Acquist)
                    m_StartEdit = False
                    btnEdit.Text = ""
                    ToolTip1.SetToolTip(btnEdit, CChangeLanguage.GetString("停止相機以使用原始圖像進行編輯"))
                    rectangle.Dispose()
                    rectangle = Nothing
                    Call Me.ImageDisplay1.InteractiveGraphics.Clear()
                    m_FirstSave = True
                    Call btnAlignTest_Click(Nothing, Nothing)
                    m_FLoading.Percent = 75
                Catch ex As Exception
                End Try
                m_VisionStart = False
                EnableVision(True, btnAlignSetStart)
                m_FLoading.Percent = 100
                m_FLoading.Close()
                m_FLoading.Dispose()
                m_FLoading = Nothing
            End If

        Catch ex As Exception
        Finally
            btnAlignSetStart.Enabled = True

        End Try
    End Sub

    Private Sub btnAlignTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlignTest.Click
        Try
            If (m_CurrentProject Is Nothing) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Sub
            End If
            btnAlignTest.Enabled = False
            Call EnableVision(False, btnAlignTest)
            For i = 0 To m_ListLine.Count - 1
                InvokePanelVisible(False, grbCamera.Controls(m_ListLine(i).ID))
            Next

            Dim res As Boolean = False

            If (m_FirstSave = True) Then
                m_FirstSave = False
                res = Alignment(numWorkStep.Value - 1, True)
            Else
                res = Alignment(numWorkStep.Value - 1, False)
            End If

            If (res = True) Then
                Dim offsetXInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetX - m_Param.Variable.Align.ImageOrginalOffsetX(numWorkStep.Value - 1)))
                Dim offsetYInImage = ((m_Param.Pos.Workholder.ImageAlignRealOffsetY - m_Param.Variable.Align.ImageOrginalOffsetY(numWorkStep.Value - 1)))
                Dim angleInImage = (m_Param.Pos.Workholder.ImageAlignT - m_Param.Variable.Align.ImageOrginalAngle(numWorkStep.Value - 1))
                Me.Text = CChangeLanguage.GetString("分數") & ": " & (m_MatchingTool(numWorkStep.Value - 1).Results.Item(0).Score * 100) & " " & CChangeLanguage.GetString("橫向偏差量") & ": " & (offsetXInImage).ToString("F3") & "px " & CChangeLanguage.GetString("縱向偏差量") & ": " & (offsetYInImage).ToString("F3") & "px " & CChangeLanguage.GetString("角度") & ": " & angleInImage & " deg"
                Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingTool(numWorkStep.Value - 1).Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
                Call ReloadCutLine(numWorkStep.Value - 1)
            Else
                Me.Text = CChangeLanguage.GetString("對位失敗 !!!")
            End If







            Call Me.ImageDisplay1.StartLive(0, m_Acquist)
            m_StartEdit = False
            btnEdit.Text = ""
            ToolTip1.SetToolTip(btnEdit, CChangeLanguage.GetString("停止相機以使用原始圖像進行編輯"))
            'Call m_MatchingTool(numWorkStep.Value - 1).SaveFiles()
        Catch ex As Exception

        Finally
            btnAlignTest.Enabled = True
            EnableVision(True, btnAlignTest)
        End Try

    End Sub

    ''' <summary>
    ''' Alignment
    ''' </summary>
    ''' <param name="pWorkStep">Start index is 0</param>
    ''' <remarks></remarks>
    Private Function Alignment(ByVal pWorkStep As Integer, Optional ByVal pFirstTime As Boolean = False) As Boolean
        Try
            Alignment = False
            If (pFirstTime = True) Then
                Dim searchRegion As CRectangle
                'Dim img As CImage
                Call Me.ImageDisplay1.StopLive()
                Call m_Acquist.Acquist(0, True)
                'img = New CImage
                Call m_Acquist.CopyTo(0, m_SourceImage1st)
                Call m_MatchingTool(pWorkStep).RunParams.SetScoreProperty(0, numAcceptScoreAlign.Value)

                searchRegion = New CRectangle
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call Me.ImageDisplay1.CopyOf(m_SourceImage1st)
                Call searchRegion.SetCenterLengthsRotation(m_SourceImage1st.Width / 2, m_SourceImage1st.Height / 2, m_SourceImage1st.Width, m_SourceImage1st.Height, 0)
                m_MatchingTool(pWorkStep).SearchRegion = searchRegion
                m_MatchingTool(pWorkStep).RunParams.RotaryEnabled = True
                m_MatchingTool(pWorkStep).RunParams.RunType = 1
                m_MatchingTool(pWorkStep).RunParams.SetRotaryRange(-10, 10)
                m_MatchingTool(pWorkStep).InputImage.CopyOf(m_SourceImage1st)
                m_MatchingTool(pWorkStep).Run(True, EnumMatchShape.None)
            Else
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call m_Acquist.Acquist(0, True)
                Call m_Acquist.CopyTo(0, m_SourceImage1st)
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                Call Me.ImageDisplay1.CopyOf(m_SourceImage1st)
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call m_MatchingTool(pWorkStep).InputImage.CopyOf(m_SourceImage1st)
                Call m_MatchingTool(pWorkStep).Run(True, EnumMatchShape.None)
            End If

            If Not m_MatchingTool(pWorkStep).IsRunning Then
                If m_MatchingTool(pWorkStep).Results.Count > 0 Then
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call Me.ImageDisplay1.StaticGraphics.Add(m_MatchingTool(pWorkStep).Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.Origin, enumMatchingToolResultGraphicConstants)))
                    m_Param.Pos.Workholder.ImageAlignT = -m_MatchingTool(pWorkStep).Results.Item(0).RotationD
                    m_Param.Pos.Workholder.ImageAlignRealOffsetX = (m_MatchingTool(pWorkStep).Results.Item(0).TranslationX - m_SourceImage1st.Width / 2) '* m_Param.Variable.Workholder.CCDRatioX
                    m_Param.Pos.Workholder.ImageAlignRealOffsetY = (m_MatchingTool(pWorkStep).Results.Item(0).TranslationY - m_SourceImage1st.Height / 2) '* m_Param.Variable.Workholder.CCDRatioY

                    If (pFirstTime = True) Then
                        m_Param.Variable.Align.ImageOrginalOffsetX(pWorkStep) = m_Param.Pos.Workholder.ImageAlignRealOffsetX
                        m_Param.Variable.Align.ImageOrginalOffsetY(pWorkStep) = m_Param.Pos.Workholder.ImageAlignRealOffsetY
                        m_Param.Variable.Align.ImageOrginalAngle(pWorkStep) = m_Param.Pos.Workholder.ImageAlignT
                        m_Param.Variable.Align.ImageCenterX(pWorkStep) = m_ROIRec.midC - m_SourceImage1st.Width / 2
                        m_Param.Variable.Align.ImageCenterY(pWorkStep) = m_ROIRec.midR - m_SourceImage1st.Height / 2
                        Call m_Param.Variable.Align.SaveParam(CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image\Parameter.xml")
                    End If
                    Alignment = True
                Else
                    Alignment = False
                End If
            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("運行對齊功能時出錯"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            Alignment = False
        End Try
    End Function

    Private m_IsTimerRunning As Boolean = False
    Private Sub TimerGetIO_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerGetIO.Tick
        If (Not m_IsTimerRunning) Then
            m_IsTimerRunning = True
            'RTC4
            Try
                If (m_Laser IsNot Nothing) Then
                    Dim inputValue = m_Laser.ReadInputPortStatus()
                    Dim inBit As String = Convert.ToString(inputValue, 2).PadLeft(16, "0")
                    Dim outBit As String = Convert.ToString(m_Laser.ReadOutputPortStatus(), 2).PadLeft(16, "0")

                    For i = 0 To 15
                        Dim ptbIn As PictureBoxEx = CType(TableLayoutPanel2.Controls.Find("ptbRTCIn" & (15 - i), False)(0), PictureBoxEx)
                        Dim ptbOut As PictureBoxEx = CType(TableLayoutPanel2.Controls.Find("ptbRTCOut" & (15 - i), False)(0), PictureBoxEx)
                        ptbIn.TurnOn = (inBit(i) = "1")
                        ptbOut.TurnOn = (outBit(i) = "1")
                    Next
                    'TableLayoutPanel2.Refresh()
                End If
            Catch ex As Exception
            End Try

            '204C
            Try
                Dim pStatus As Boolean = False
                For i As Integer = 8 To 23
                    Call m_DA.DigI.CheckSensorSts(i, pStatus)
                    Dim ptb As PictureBoxEx = CType(TableLayoutPanel16.Controls.Find("ptb204In" & i, False)(0), PictureBoxEx)
                    ptb.TurnOn = pStatus
                Next

                For i As Integer = 8 To 23
                    Dim ptb As PictureBoxEx = CType(TableLayoutPanel16.Controls.Find("ptb204Out" & i, False)(0), PictureBoxEx)
                    If (m_DA.DigO.Status(i) = enumCyllogic.Action) Then
                        ptb.TurnOn = True
                    Else
                        ptb.TurnOn = False
                    End If
                Next
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try

            m_IsTimerRunning = False
        End If
    End Sub

    Private Sub TabControl2_Selecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl2.Selecting
        Try
            chkPickPoint.Checked = False
            chkPickY.Checked = False
            If (e.TabPage Is TabPageIOStatus) Then
                m_IsTimerRunning = False
                TimerGetIO.Enabled = True
            Else
                TimerGetIO.Enabled = False
            End If

        Catch ex As Exception

        End Try
    End Sub

    Private Sub ptbOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptbRTCOut0.Click, ptbRTCOut1.Click, ptbRTCOut2.Click, ptbRTCOut3.Click, ptbRTCOut4.Click, ptbRTCOut5.Click, ptbRTCOut6.Click, ptbRTCOut7.Click, ptbRTCOut8.Click, ptbRTCOut9.Click, ptbRTCOut10.Click, ptbRTCOut11.Click, ptbRTCOut12.Click, ptbRTCOut13.Click, ptbRTCOut14.Click, ptbRTCOut15.Click
        Try
            If (m_Laser IsNot Nothing) Then
                TimerGetIO.Enabled = False
                Dim ctrl As PictureBoxEx = CType(sender, PictureBoxEx)
                ctrl.TurnOn = False
                ctrl.Enabled = False
                Dim pPin As Short = CType(ctrl.Tag, Short)
                'If (pPin = 0) Then
                Dim s As Double = m_Timer.GetMilliseconds
                Call m_Laser.DigitialOutSet(pPin, False)
                While (m_Timer.GetMilliseconds - s < m_Param.Variable.IO.DODelay)
                    Application.DoEvents()
                End While
                Call m_Laser.DigitialOutSet(pPin, True)
                ctrl.Enabled = True
                ctrl.TurnOn = True
                TimerGetIO.Enabled = True

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ptbOut15_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ptbRTCOut9.MouseMove, ptbRTCOut8.MouseMove, ptbRTCOut7.MouseMove, ptbRTCOut6.MouseMove, ptbRTCOut5.MouseMove, ptbRTCOut4.MouseMove, ptbRTCOut3.MouseMove, ptbRTCOut2.MouseMove, ptbRTCOut15.MouseMove, ptbRTCOut14.MouseMove, ptbRTCOut13.MouseMove, ptbRTCOut12.MouseMove, ptbRTCOut11.MouseMove, ptbRTCOut10.MouseMove, ptbRTCOut1.MouseMove, ptbRTCOut0.MouseMove
        Dim ctrl As PictureBoxEx = CType(sender, PictureBoxEx)
        ctrl.Cursor = Cursors.Hand
    End Sub

    Private Sub btnMarkLine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkLine.Click
        If (m_CurrentProject Is Nothing) Then
            FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Exit Sub
        End If
        btnEmissionOff.Enabled = False
        btnCorrection.Enabled = False
        btnMarkLine.Enabled = False
        btnReloadCorectionFile.Enabled = False
        Button5.Enabled = False
        Button6.Enabled = False
        btnGlavoHome.Enabled = False
        btnGuideON.Enabled = False
        btnGuideOFF.Enabled = False

        Try
            If (m_LineSelected IsNot Nothing) Then

                If (m_Corection.LaserOn = False) Then
                    m_Laser.LaserEmission = False
                    m_Laser.LaserGuide = True

                Else
                    m_Laser.PRR = m_Param.Variable.Laser.PRR.ToString()
                    m_Laser.OperatingPower = m_Param.Variable.Laser.Power.ToString()
                    m_Laser.LaserGuide = False
                    m_Laser.LaserEmission = True
                    Threading.Thread.Sleep(3000)
                End If

                Dim CenterX As Double = 0
                Dim CenterY As Double = 0
                Dim NewX1 As Double = 0
                Dim NewY1 As Double = 0
                Dim NewX2 As Double = 0
                Dim NewY2 As Double = 0
                Dim OffsetX As Double = 0
                Dim OffsetY As Double = 0
                Dim Angle As Double = 0
                Dim idx As Integer = 0





                CenterX = (m_LineSelected.StartX + m_LineSelected.EndX) / 2
                CenterY = (m_LineSelected.StartY + m_LineSelected.EndY) / 2

                Call NewPos(OffsetX, OffsetY, Angle, CenterX, CenterY, m_LineSelected.StartX, m_LineSelected.StartY, NewX1, NewY1)
                Call NewPos(OffsetX, OffsetY, Angle, CenterX, CenterY, m_LineSelected.EndX, m_LineSelected.EndY, NewX2, NewY2)

                'FMain.GalvoPositionToEncoder(m_LineSelected.StartX, m_LineSelected.StartY, NewX1, NewY1)
                'FMain.GalvoPositionToEncoder(m_LineSelected.EndX, m_LineSelected.EndY, NewX2, NewY2)

                If (CheckRTCOutRange(NewX1, NewY1) = True) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If (CheckRTCOutRange(NewX2, NewY2) = True) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                Call m_Laser.setstartlist(1)
                Call m_Laser.setScannerDelays(m_LineSelected.JumpDelay, m_LineSelected.MarkDelay, m_LineSelected.PolygonDelay)
                Call m_Laser.SetLaserDelays(m_LineSelected.LaserOnDelay, m_LineSelected.LaserOffDelay)
                Call m_Laser.SetJumpSpeed(m_LineSelected.JumpSpeed)
                Call m_Laser.SetMarkSpeed(m_LineSelected.MarkSpeed)

                If (m_LineSelected.RepeatMode = eRepeatMode.Mode1) Then
                    For i = 1 To m_LineSelected.RepeatCount
                        Call m_Laser.JumpAbs(CInt(NewX1 * 1000), CInt(NewY1 * 1000))
                        Call m_Laser.MarkAbs(CInt(NewX2 * 1000), CInt(NewY2 * 1000))
                    Next
                Else
                    Call m_Laser.JumpAbs(CInt(NewX1 * 1000), CInt(NewY1 * 1000))
                    For i = 1 To m_LineSelected.RepeatCount
                        If (i Mod 2 = 0) Then
                            Call m_Laser.MarkAbs(CInt(NewX1 * 1000), CInt(NewY1 * 1000))
                        Else
                            Call m_Laser.MarkAbs(CInt(NewX2 * 1000), CInt(NewY2 * 1000))
                        End If
                    Next
                End If

                'If (m_LineSelected.RepeatMode = eRepeatMode.Mode1) Then
                '    For i = 1 To m_LineSelected.RepeatCount
                '        Call m_Laser.JumpAbs(CInt(NewX1), CInt(NewY1))
                '        Call m_Laser.MarkAbs(CInt(NewX2), CInt(NewY2))
                '    Next
                'Else
                '    Call m_Laser.JumpAbs(CInt(NewX1), CInt(NewY1))
                '    For i = 1 To m_LineSelected.RepeatCount
                '        If (i Mod 2 = 0) Then
                '            Call m_Laser.MarkAbs(CInt(NewX1), CInt(NewY1))
                '        Else
                '            Call m_Laser.MarkAbs(CInt(NewX2), CInt(NewY2))
                '        End If
                '    Next
                'End If

                Call m_Laser.SetEndofList()
                Call m_Laser.ExecuteList(1)
                Dim s As Double = m_Timer.GetMilliseconds
                While (m_Laser.ListExecutionFinish = False AndAlso (m_Timer.GetMilliseconds - s) < 5000)

                End While
                btnEmissionOff.Enabled = True
                btnCorrection.Enabled = True
                btnMarkLine.Enabled = True
                btnReloadCorectionFile.Enabled = True
                Button5.Enabled = True
                Button6.Enabled = True
                btnGlavoHome.Enabled = True
                btnGuideON.Enabled = True
                btnGuideOFF.Enabled = True
            Else
                FMessageBox.Show(Me, CChangeLanguage.GetString("請選擇切割線"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            End If

        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private m_StartEdit As Boolean = False

    Private m_LineSelectedOld As CLine = Nothing
    Private m_Merge As CMerge
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Try
            If (CLoginInformation.CurrentUser.Permission <= 0) Then
                FMessageBox.Show(Me, CChangeLanguage.GetString("帳戶不允許更改"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                Exit Try
            End If
            If (m_SelectedNodes IsNot Nothing AndAlso m_SelectedNodes.Count > 1) Then
                If (m_StartEdit = False) Then
                    m_StartEdit = True
                    btnEdit.Text = "X"
                    m_Merge = New CMerge()
                    TypeDescriptor.AddAttributes(m_Merge, New Attribute() {New ReadOnlyAttribute(False)})
                    PropertyGrid1.SelectedObject = m_Merge
                    If (cboChoosePointForEdit.SelectedIndex = -1) Then
                        cboChoosePointForEdit.SelectedIndex = 0
                    End If
                    If (cboFixPoint.SelectedIndex = -1) Then
                        cboFixPoint.SelectedIndex = 0
                    End If
                Else
                    btnEdit.Text = ""
                    TypeDescriptor.AddAttributes(m_Merge, New Attribute() {New ReadOnlyAttribute(True)})
                    PropertyGrid1.SelectedObject = m_Merge
                    If (m_Merge.IsEmpty = False) Then
                        If (FMessageBox.Show(Me, CChangeLanguage.GetString("未保存任何更改。 您要保存項目嗎?"), CChangeLanguage.GetString("信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            m_NoMessageShow = True
                            For idx = 0 To m_SelectedNodes.Count - 1
                                Dim node As TreeNode = CType(m_SelectedNodes(idx), TreeNode)
                                For idx2 = 0 To m_ListLine.Count - 1
                                    If (m_ListLine(idx2).ID = node.Name) Then
                                        If (m_Merge.JumpSpeed <> "") Then
                                            m_ListLine(idx2).JumpSpeed = CInt(m_Merge.JumpSpeed)
                                        End If
                                        If (m_Merge.MarkSpeed <> "") Then
                                            m_ListLine(idx2).MarkSpeed = CInt(m_Merge.MarkSpeed)
                                        End If
                                        If (m_Merge.JumpDelay <> "") Then
                                            m_ListLine(idx2).JumpDelay = CInt(m_Merge.JumpDelay)
                                        End If
                                        If (m_Merge.MarkDelay <> "") Then
                                            m_ListLine(idx2).MarkDelay = CInt(m_Merge.MarkDelay)
                                        End If
                                        If (m_Merge.RepeatCount <> "") Then
                                            m_ListLine(idx2).RepeatCount = CInt(m_Merge.RepeatCount)
                                        End If
                                        If (m_Merge.PolygonDelay <> "") Then
                                            m_ListLine(idx2).PolygonDelay = CInt(m_Merge.PolygonDelay)
                                        End If
                                        If (m_Merge.LaserOnDelay <> "") Then
                                            m_ListLine(idx2).LaserOnDelay = CInt(m_Merge.LaserOnDelay)
                                        End If
                                        If (m_Merge.LaserOffDelay <> "") Then
                                            m_ListLine(idx2).LaserOffDelay = CInt(m_Merge.LaserOffDelay)
                                        End If
                                        If (m_Merge.LaserPower <> "") Then
                                            m_ListLine(idx2).LaserPower = CDbl(m_Merge.LaserPower)
                                        End If
                                        If (m_Merge.LaserPRR <> "") Then
                                            m_ListLine(idx2).LaserPRR = CDbl(m_Merge.LaserPRR)
                                        End If
                                        If (m_Merge.RepeatMode <> eRepeatModeMerge.NoSet) Then
                                            If (m_Merge.RepeatMode = eRepeatModeMerge.Mode1) Then
                                                m_ListLine(idx2).RepeatMode = eRepeatMode.Mode1
                                            ElseIf (m_Merge.RepeatMode = eRepeatModeMerge.Mode2) Then
                                                m_ListLine(idx2).RepeatMode = eRepeatMode.Mode2
                                            End If
                                        End If
                                        Exit For
                                    End If
                                Next
                            Next
                            m_SaveEdit = False
                            btnSave_Click(Nothing, Nothing)
                        End If
                    End If
                    m_StartEdit = False
                End If

            Else
                If (m_StartEdit = False) Then
                    If (m_CurrentProject Is Nothing) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請先打開項目"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Try
                    End If
                    If (m_SelectedStep <= 0) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請選擇工作步驟"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Try
                    End If
                    If (m_MatchingTool(m_SelectedStep - 1) Is Nothing) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請添加新的視覺"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Try
                    End If
                    If (m_MatchingTool(m_SelectedStep - 1).InputImage Is Nothing) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請添加新的視覺"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Try
                    End If
                    If (m_LineSelected Is Nothing) Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("請選擇切割線"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
                        Exit Try
                    End If
                    m_StartEdit = True
                    m_LineSelectedOld = m_LineSelected.Clone()
                    'PropertyGrid1.Enabled = True
                    m_SaveOnlyWork = True
                    TypeDescriptor.AddAttributes(m_LineSelected, New Attribute() {New ReadOnlyAttribute(False)})


                    TreeView1.Enabled = False
                    Call ImageDisplay1.StopLive()
                    Call Me.ImageDisplay1.StaticGraphics.Clear()
                    Call ImageDisplay1.CopyOf(m_MatchingTool(m_SelectedStep - 1).Pattern.TrainImage)
                    btnEdit.Text = "X"
                    ToolTip1.SetToolTip(btnEdit, CChangeLanguage.GetString("啟動相機. 結束更改"))

                    m_Param.Pos.Workholder.ImageAlignRealOffsetX = m_Param.Variable.Align.ImageOrginalOffsetX(m_SelectedStep - 1)
                    m_Param.Pos.Workholder.ImageAlignRealOffsetY = m_Param.Variable.Align.ImageOrginalOffsetY(m_SelectedStep - 1)
                    m_Param.Pos.Workholder.ImageAlignT = m_Param.Variable.Align.ImageOrginalAngle(m_SelectedStep - 1)

                    For i = 0 To m_ListOriginalLine.Count - 1
                        If (m_ListOriginalLine(i).[Step] = m_SelectedStep) Then
                            m_ListLine(i) = m_ListOriginalLine(i).Clone()
                            If (m_LineSelected.ID = m_ListLine(i).ID) Then
                                m_LineSelected = m_ListLine(i)
                                PropertyGrid1.SelectedObject = m_LineSelected
                            End If
                        End If
                    Next
                    ReloadCutLine(m_SelectedStep - 1)
                    If (cboChoosePointForEdit.SelectedIndex = -1) Then
                        cboChoosePointForEdit.SelectedIndex = 0
                    End If
                    If (cboFixPoint.SelectedIndex = -1) Then
                        cboFixPoint.SelectedIndex = 0
                    End If
                Else
                    If (m_LineSelectedOld.Equals(m_LineSelected)) = False Then
                        If (FMessageBox.Show(Me, CChangeLanguage.GetString("未保存任何更改。 您要保存項目嗎?"), CChangeLanguage.GetString("信息"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                            m_NoMessageShow = True
                            m_SaveEdit = True
                            btnSave_Click(Nothing, Nothing)
                            m_SaveEdit = False
                        Else
                            For i = 0 To m_ListLine.Count - 1
                                If (m_ListLine(i).ID = m_LineSelected.ID) Then
                                    m_ListLine(i) = m_LineSelectedOld.Clone()
                                    m_LineSelected = m_ListLine(i)
                                    PropertyGrid1.SelectedObject = m_LineSelected
                                    Dim ctrlLine As CLineCtrl = CType(grbCamera.Controls(m_ListLine(i).ID), CLineCtrl)
                                    ctrlLine.Line = m_ListLine(i)
                                    Exit For
                                End If
                            Next
                            ReloadCutLine(m_SelectedStep - 1)
                        End If
                    End If
                    m_StartEdit = False
                    If (m_Param.Flags.System.AutoRunProcedure = False) Then
                        Call ImageDisplay1.StartLive(0, m_Acquist)
                        Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                    End If
                    btnEdit.Text = ""
                    ToolTip1.SetToolTip(btnEdit, CChangeLanguage.GetString("停止相機以使用原始圖像進行編輯"))
                    'PropertyGrid1.Enabled = False
                    TypeDescriptor.AddAttributes(m_LineSelected, New Attribute() {New ReadOnlyAttribute(True)})
                    PropertyGrid1.SelectedObject = m_LineSelected
                    TreeView1.Enabled = True

                End If
            End If
        Catch ex As Exception

        End Try
        EnableEditLine(m_StartEdit)
    End Sub

    Private Sub EnableEditLine(ByVal status As Boolean)
        Try
            If (status = True) Then 'Start edit
                btnOpenProject.Enabled = False
                btnNewProject.Enabled = False
                btnSave.Enabled = False
                btnAddLine.Enabled = False
                btnDelete.Enabled = False
                Button3.Enabled = False
                btnPickColor.Enabled = False
                btnDrawSelecting.Enabled = False
                btnRun.Enabled = False
                btnHome.Enabled = False
                chkTest.Enabled = False
                pnEdit.Visible = True
                pnMainButton.Visible = False
                pnEdit.Location = New Point(315, 3)
            Else 'End edit
                btnOpenProject.Enabled = True
                btnNewProject.Enabled = True
                btnSave.Enabled = True
                btnAddLine.Enabled = True
                btnDelete.Enabled = True
                Button3.Enabled = True
                btnPickColor.Enabled = True
                btnDrawSelecting.Enabled = True
                btnRun.Enabled = True
                btnHome.Enabled = True
                chkTest.Enabled = True
                pnMainButton.Visible = True
                pnEdit.Visible = False
                pnEdit.Location = New Point(515, 3)
            End If
        Catch
        End Try
    End Sub
    Private m_SaveOnlyWork As Boolean = False
    Private Shared m_GridXInCamPose() As Double
    Private Shared m_GridYInCamPose() As Double
    Private Shared m_GridXInGalvoPose() As Double
    Private Shared m_GridYInGalvoPose() As Double
    'Private Shared m_GridXInGalvoEncoder() As Integer
    'Private Shared m_GridYInGalvoEncoder() As Integer
    Private Shared m_MatrixNum As Integer

    Private Shared m_CcdWidth As Double
    Private Shared m_CcdHeight As Double

    Private Shared m_CcdWidthLow As Integer
    Private Shared m_CcdHeightLow As Integer

    Private Shared m_CcdWidthHigh As Integer
    Private Shared m_CcdHeightHigh As Integer


    Private Shared m_GalvoWidth As Double
    Private Shared m_GalvoHeight As Double

    Private Shared m_GalvoWidthLow As Double
    Private Shared m_GalvoHeightLow As Double

    Private Shared m_GalvoWidthHigh As Double
    Private Shared m_GalvoHeightHigh As Double
    Public Function ImagePointsInit(Optional ByVal pPath As String = "D:\DataSettings\LaserMachine\Machine\Parameter") As Boolean
        Try

            ImagePointsInit = False
            m_CcdWidthLow = 100000
            m_CcdHeightLow = 100000

            m_CcdWidthHigh = -100000
            m_CcdHeightHigh = -100000

            m_GalvoWidthLow = 100000
            m_GalvoHeightLow = 100000

            m_GalvoWidthHigh = -100000
            m_GalvoHeightHigh = -100000

            dgvImageValue.Rows.Clear()
            Dim pVisionPath As String = pPath & "\VisionPickCalibration.txt"


            Dim strData() As String = System.IO.File.ReadAllLines(pVisionPath, System.Text.Encoding.Default)
            Dim str() As String

            m_MatrixNum = CInt(Math.Sqrt(strData.Length))
            ReDim m_GridXInCamPose(0 To (strData.Length - 1))
            ReDim m_GridYInCamPose(0 To (strData.Length - 1))

            For aryIdx As Integer = 0 To UBound(m_GridXInCamPose)
                str = strData(aryIdx).Split(CChar(","))
                m_GridXInCamPose(aryIdx) = CDbl(str(0))
                m_GridYInCamPose(aryIdx) = CDbl(str(1))
                If m_CcdWidthLow > CDbl(str(0)) Then
                    m_CcdWidthLow = CInt(str(0))
                End If
                If m_CcdHeightLow > CDbl(str(1)) Then
                    m_CcdHeightLow = CInt(str(1))
                End If
                If m_CcdWidthHigh < CDbl(str(0)) Then
                    m_CcdWidthHigh = CInt(str(0))
                End If
                If m_CcdHeightHigh < CDbl(str(1)) Then
                    m_CcdHeightHigh = CInt(str(1))
                End If

                dgvImageValue.Rows.Add(New Object() {aryIdx + 1, m_GridXInCamPose(aryIdx), m_GridYInCamPose(aryIdx)})
                DataGridView1.Rows.Add(New Object() {aryIdx + 1, m_GridXInCamPose(aryIdx), m_GridYInCamPose(aryIdx)})
            Next

            For idx = 0 To dgvImageValue.Columns.Count - 1
                dgvImageValue.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
                DataGridView1.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
            Next



            dgvGalvoValue.Rows.Clear()
            DataGridView2.Rows.Clear()
            Dim pGalvoPath As String = pPath & "\GalvoPickCalibration.txt"
            strData = System.IO.File.ReadAllLines(pGalvoPath, System.Text.Encoding.Default)
            'Dim str() As String

            'ReDim m_GridXInGalvoEncoder(0 To (strData.Length - 1))
            'ReDim m_GridYInGalvoEncoder(0 To (strData.Length - 1))
            ReDim m_GridXInGalvoPose(0 To (strData.Length - 1))
            ReDim m_GridYInGalvoPose(0 To (strData.Length - 1))

            strData = System.IO.File.ReadAllLines(pGalvoPath, System.Text.Encoding.Default)
            For aryIdx As Integer = 0 To UBound(m_GridXInGalvoPose) Step 1
                str = strData(aryIdx).Split(CChar(","))
                'm_GridXInGalvoEncoder(aryIdx) = CInt(str(0))
                'm_GridYInGalvoEncoder(aryIdx) = CInt(str(1))
                m_GridXInGalvoPose(aryIdx) = Val(str(0))
                m_GridYInGalvoPose(aryIdx) = Val(str(1))
                If m_GalvoWidthLow > CDbl(str(0)) Then
                    m_GalvoWidthLow = CInt(str(0))
                End If
                If m_GalvoHeightLow > CDbl(str(1)) Then
                    m_GalvoHeightLow = CInt(str(1))
                End If
                If m_GalvoWidthHigh < CDbl(str(0)) Then
                    m_GalvoWidthHigh = CInt(str(0))
                End If
                If m_GalvoHeightHigh < CDbl(str(1)) Then
                    m_GalvoHeightHigh = CInt(str(1))
                End If

                dgvGalvoValue.Rows.Add(New Object() {aryIdx + 1, m_GridXInGalvoPose(aryIdx), m_GridYInGalvoPose(aryIdx)})
                DataGridView2.Rows.Add(New Object() {aryIdx + 1, m_GridXInGalvoPose(aryIdx), m_GridYInGalvoPose(aryIdx)})
            Next
            For idx = 0 To dgvGalvoValue.Columns.Count - 1
                dgvGalvoValue.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
                DataGridView2.Columns(idx).SortMode = DataGridViewColumnSortMode.NotSortable
            Next
            cboCalibrationRange.SelectedItem = CType(dgvGalvoValue.Rows.Count, eCalibrationSize)
            m_CcdWidth = m_CcdWidthHigh - m_CcdWidthLow
            m_CcdHeight = m_CcdHeightHigh - m_CcdHeightLow

            m_GalvoWidth = m_GalvoWidthHigh - m_GalvoWidthLow
            m_GalvoHeight = m_GalvoHeightHigh - m_GalvoHeightLow


            'Dim count As Integer = Math.Sqrt(dgvGalvoValue.Rows.Count)
            'Dim StepX As Integer = grbCamera.Width \ (count + 1)
            'Dim StepY As Integer = grbCamera.Height \ (count + 1)
            'ReDim m_GridXInCamPose(0 To (dgvGalvoValue.Rows.Count - 1))
            'ReDim m_GridYInCamPose(0 To (dgvGalvoValue.Rows.Count - 1))
            'dgvImageValue.Rows.Clear()
            'Dim idx As Integer = 0
            'For aryIdx = 0 To count - 1
            '    For aryIdx2 = 0 To count - 1
            '        m_GridXInCamPose(idx) = StepX * (aryIdx + 1)
            '        m_GridYInCamPose(idx) = grbCamera.Height - (StepY * (aryIdx2 + 1))
            '        dgvImageValue.Rows.Add(New Object() {idx + 1, m_GridXInCamPose(idx), m_GridYInCamPose(idx)})
            '        idx += 1
            '    Next
            'Next

            ImagePointsInit = True

        Catch ex As Exception
            ImagePointsInit = False
        End Try
    End Function



    Public Function ImagePointsIdx(ByVal pGridXInCamPose() As Double, ByVal pGridYInCamPose() As Double, ByVal XInCamPose As Double, ByRef YInCamPose As Double, ByRef pleftUpIdx As Integer, ByRef prightUpIdx As Integer, ByRef pleftDnIdx As Integer, ByRef prightDnIdx As Integer, ByRef pkX As Double, ByRef pkY As Double) As Boolean
        Try
            Dim pMatrixNum As Integer = pGridXInCamPose.Length

            Dim pMatrixNumSqr As Integer = CInt(Math.Sqrt(pMatrixNum))


            If XInCamPose >= m_CcdWidthHigh Then
                XInCamPose = m_CcdWidthHigh
            End If
            If XInCamPose <= m_CcdWidthLow Then
                XInCamPose = m_CcdWidthLow
            End If

            If YInCamPose >= m_CcdHeightHigh Then
                YInCamPose = m_CcdHeightHigh
            End If
            If YInCamPose <= m_CcdHeightLow Then
                YInCamPose = m_CcdHeightLow
            End If

            Dim pXList As New List(Of Integer)
            Dim pYList As New List(Of Integer)

            For i As Integer = 0 To pMatrixNum - 2 Step 1
                If pGridXInCamPose(i) <= XInCamPose AndAlso XInCamPose <= pGridXInCamPose(i + 1) Then
                    pXList.Add(i + 1)
                End If
            Next

            For i As Integer = 0 To pMatrixNum - pMatrixNumSqr - 1 Step 1
                If pGridYInCamPose(i) <= YInCamPose AndAlso YInCamPose <= pGridYInCamPose(i + pMatrixNumSqr) Then
                    pYList.Add(i + pMatrixNumSqr)
                End If
            Next

            '9 10 14 15

            'y=1 x=4

            Dim pIdx As Integer = -1
            For i As Integer = 0 To pXList.Count - 1 Step 1
                For j As Integer = 0 To pYList.Count - 1 Step 1
                    If pXList(i) = pYList(j) Then
                        pIdx = pXList(i)
                        Exit For
                    End If
                Next
                If pIdx <> -1 Then
                    Exit For
                End If
            Next

            pleftUpIdx = pIdx - 1 - pMatrixNumSqr
            prightUpIdx = pIdx - pMatrixNumSqr
            pleftDnIdx = pIdx - 1
            prightDnIdx = pIdx

            pkX = (XInCamPose - (pGridXInCamPose(pleftUpIdx) + pGridXInCamPose(pleftDnIdx)) / 2) / ((pGridXInCamPose(prightUpIdx) + pGridXInCamPose(prightDnIdx)) / 2 - (pGridXInCamPose(pleftUpIdx) + pGridXInCamPose(pleftDnIdx)) / 2)

            pkY = (YInCamPose - (pGridYInCamPose(pleftUpIdx) + pGridYInCamPose(prightUpIdx)) / 2) / ((pGridYInCamPose(pleftDnIdx) + pGridYInCamPose(prightDnIdx)) / 2 - (pGridYInCamPose(pleftUpIdx) + pGridYInCamPose(prightUpIdx)) / 2)

            ImagePointsIdx = False
        Catch ex As Exception
            ImagePointsIdx = True
        End Try
    End Function

    Public Shared Function ImagePointsToGalvoPosition(ByVal XInCamPose As Double, ByVal YInCamPose As Double, ByRef XInGalvoPose As Double, ByRef YInGalvoPose As Double) As Boolean
        Try

            Dim xInGalvoMin, xInGalvoMax, yInGalvoMin, yInGalvoMax As Double
            Dim xInCamMin, xInCamMax, yInCamMin, yInCamMax As Double
            Dim flagX As Boolean = False
            Dim flagY As Boolean = False
            xInGalvoMin = m_GridXInGalvoPose.Min() ' m_Laser.MinX 'mm
            xInGalvoMax = m_GridXInGalvoPose.Max() ''m_Laser.MaxX
            yInGalvoMin = m_GridYInGalvoPose.Min() ''m_Laser.MinY
            yInGalvoMax = m_GridYInGalvoPose.Max() 'm_Laser.MaxY
            xInCamMin = 0
            xInCamMax = ViewImageWidth
            yInCamMin = 0
            yInCamMax = ViewImageHeight

            Dim newGridXInGalvoPos As New List(Of Double)
            Dim newGridYInGalvoPos As New List(Of Double)
            Dim newGridXInCamPos As New List(Of Double)
            Dim newGridYInCamPos As New List(Of Double)

            newGridXInGalvoPos.AddRange(m_GridXInGalvoPose)
            newGridXInGalvoPos.Add(xInGalvoMin)
            newGridXInGalvoPos.Add(xInGalvoMax)

            newGridYInGalvoPos.AddRange(m_GridYInGalvoPose)
            newGridYInGalvoPos.Add(yInGalvoMax)
            newGridYInGalvoPos.Add(yInGalvoMin)

            newGridXInCamPos.AddRange(m_GridXInCamPose)
            newGridXInCamPos.Add(xInCamMin)
            newGridXInCamPos.Add(xInCamMax)

            newGridYInCamPos.AddRange(m_GridYInCamPose)
            newGridYInCamPos.Add(yInCamMin)
            newGridYInCamPos.Add(yInCamMax)


            xInCamMin = (From x As Double In newGridXInCamPos
                                    Where x <= XInCamPose).Max()
            xInCamMax = (From x As Double In newGridXInCamPos
                                    Where x >= XInCamPose).Min()
            yInCamMin = (From y As Double In newGridYInCamPos
                                    Where y <= YInCamPose).Max()
            yInCamMax = (From y As Double In newGridYInCamPos
                                    Where y >= YInCamPose).Min()

            Dim foundIdx As Integer = 0

            foundIdx = newGridXInCamPos.IndexOf(xInCamMin)
            xInGalvoMin = newGridXInGalvoPos(foundIdx)

            foundIdx = newGridXInCamPos.IndexOf(xInCamMax)
            xInGalvoMax = newGridXInGalvoPos(foundIdx)

            foundIdx = newGridYInCamPos.IndexOf(yInCamMin)
            yInGalvoMin = newGridYInGalvoPos(foundIdx)

            foundIdx = newGridYInCamPos.IndexOf(yInCamMax)
            yInGalvoMax = newGridYInGalvoPos(foundIdx)






            'If (XInCamPose > xInCamMax) Then
            '    XInCamPose = xInCamMax
            'End If
            'If (XInCamPose <= xInCamMin) Then
            '    XInCamPose = xInCamMin
            'End If
            'If (YInCamPose >= yInCamMax) Then
            '    YInCamPose = yInCamMax
            'End If
            'If (YInCamPose <= yInCamMin) Then
            '    YInCamPose = yInCamMin
            'End If

            ''Check out range
            'Dim XInGridCamMin, XInGridCamMax, YInGridCamMin, YInGridCamMax As Double
            'XInGridCamMin = m_GridXInCamPose.Min()
            'XInGridCamMax = m_GridXInCamPose.Max()
            'YInGridCamMin = m_GridYInCamPose.Min()
            'YInGridCamMax = m_GridYInCamPose.Max()
            'If (XInCamPose < XInGridCamMin) Then
            '    xInGalvoMin = m_Laser.MinX
            '    xInCamMin = 0
            '    flagX = True
            'End If
            'If (XInCamPose < XInGridCamMax) Then
            '    xInGalvoMax = m_Laser.MaxX
            '    xInCamMax = ViewImageWidth
            '    flagX = True
            'End If
            'If (YInCamPose < YInGridCamMin) Then
            '    yInGalvoMin = m_Laser.MinY
            '    yInCamMin = 0
            '    flagY = True
            'End If
            'If (YInCamPose < YInGridCamMax) Then
            '    yInGalvoMax = m_Laser.MaxY
            '    yInCamMax = ViewImageHeight
            '    flagY = True
            'End If


            'For idx = 0 To m_GridXInCamPose.Length - 1
            '    If (m_GridXInCamPose(idx) <= XInCamPose) Then
            '        If (m_GridXInCamPose(idx) >= xInCamMin AndAlso flagX = False) Then
            '                xInGalvoMin = m_GridXInGalvoPose(idx)
            '                xInCamMin = m_GridXInCamPose(idx)
            '        End If
            '    End If
            '    If (m_GridXInCamPose(idx) >= XInCamPose) Then
            '        If (m_GridXInCamPose(idx) <= xInCamMax AndAlso flagX = False) Then
            '            xInGalvoMax = m_GridXInGalvoPose(idx)
            '            xInCamMax = m_GridXInCamPose(idx)
            '        End If
            '    End If
            'Next

            'For idx = 0 To m_GridYInCamPose.Length - 1
            '    If (m_GridYInCamPose(idx) <= YInCamPose) Then
            '        If (m_GridYInCamPose(idx) >= yInCamMin AndAlso flagY = False) Then
            '            yInGalvoMin = m_GridYInGalvoPose(idx)
            '            yInCamMin = m_GridYInCamPose(idx)
            '        End If
            '    End If
            '    If (m_GridYInCamPose(idx) >= YInCamPose) Then
            '        If (m_GridYInCamPose(idx) <= yInCamMax AndAlso flagY = False) Then
            '            yInGalvoMax = m_GridYInGalvoPose(idx)
            '            yInCamMax = m_GridYInCamPose(idx)
            '        End If
            '    End If
            'Next
            Dim scaleX As Double = 1
            Dim scaleY As Double = 1


            If (xInGalvoMax = xInGalvoMin) Then
                XInGalvoPose = xInGalvoMin
            Else
                scaleX = (xInCamMax - xInCamMin) / (xInGalvoMax - xInGalvoMin)
                If (XInCamPose < ViewImageWidth / 2) Then
                    XInGalvoPose = xInGalvoMax - (xInCamMax - XInCamPose) / scaleX
                Else
                    XInGalvoPose = xInGalvoMin + (XInCamPose - xInCamMin) / scaleX
                End If
            End If




            If (yInGalvoMax = yInGalvoMin) Then
                YInGalvoPose = yInGalvoMin
            Else
                scaleY = (yInCamMax - yInCamMin) / (yInGalvoMax - yInGalvoMin)
                If (YInCamPose < 0) Then
                    YInGalvoPose = yInGalvoMax - (yInCamMax - YInCamPose) / scaleY
                Else
                    YInGalvoPose = yInGalvoMax - (yInCamMax - YInCamPose) / scaleY
                End If
            End If











            'ImagePointsToGalvoPosition = False
            'Dim StartXIdx As Integer
            'Dim StartYIdx As Integer

            'If XInCamPose >= m_CcdWidthHigh Then
            '    XInCamPose = m_CcdWidthHigh
            '    Exit Try
            'End If
            'If XInCamPose <= m_CcdWidthLow Then
            '    XInCamPose = m_CcdWidthLow
            '    Exit Try
            'End If

            'If YInCamPose >= m_CcdHeightHigh Then
            '    YInCamPose = m_CcdHeightHigh
            '    Exit Try
            'End If
            'If YInCamPose <= m_CcdHeightLow Then
            '    YInCamPose = m_CcdHeightLow
            '    Exit Try
            'End If

            'StartXIdx = CInt(Math.Floor((XInCamPose - m_CcdWidthLow) * (m_MatrixNum - 1) / m_CcdWidth))
            'StartYIdx = CInt(Math.Floor((YInCamPose - m_CcdHeightLow) * (m_MatrixNum - 1) / m_CcdHeight))
            ''計算比例
            'Dim kxInCam As Double, kyInCam As Double
            'kxInCam = (XInCamPose - m_GridXInCamPose(StartXIdx)) / (m_GridXInCamPose(StartXIdx + 1) - m_GridXInCamPose(StartXIdx))
            'kyInCam = (YInCamPose - m_GridYInCamPose(m_MatrixNum * StartYIdx)) / (m_GridYInCamPose(m_MatrixNum * (StartYIdx + 1)) - m_GridYInCamPose(m_MatrixNum * StartYIdx))
            'If (kxInCam = 0 AndAlso kxInCam = 0) Then
            '    For idx = 0 To m_GridXInGalvoPose.Length - 1
            '        If (m_GridXInCamPose(idx) = XInCamPose AndAlso m_GridYInCamPose(idx) = YInCamPose) Then
            '            XInGalvoPose = m_GridXInGalvoPose(idx)
            '            YInGalvoPose = m_GridYInGalvoPose(idx)
            '            Exit For
            '        End If
            '    Next
            '    Exit Try
            'End If
            ''計算非正交格線上的點
            'Dim x1InBotPose As Double, x2InBotPose As Double
            'Dim y1InBotPose As Double, y2InBotPose As Double
            'Dim x3InBotPose As Double, y3InBotPose As Double
            'Dim x4InBotPose As Double, y4InBotPose As Double
            'Dim leftUpIdx As Integer, rightUpIdx As Integer, leftDnIdx As Integer, rightDnIdx As Integer
            'leftUpIdx = m_MatrixNum * StartYIdx + StartXIdx
            'rightUpIdx = m_MatrixNum * StartYIdx + StartXIdx + 1
            'leftDnIdx = m_MatrixNum * (StartYIdx + 1) + StartXIdx
            'rightDnIdx = m_MatrixNum * (StartYIdx + 1) + StartXIdx + 1

            ''Dim pbool As Boolean
            ''  pbool = ImagePointsIdx(m_GridXInCamPose, m_GridYInCamPose, XInCamPose, YInCamPose, leftUpIdx, rightUpIdx, leftDnIdx, rightDnIdx, kxInCam, kyInCam)
            ''9 10 14 15

            ''格線上四個點
            'x1InBotPose = m_GridXInGalvoPose(leftUpIdx) - kxInCam * (m_GridXInGalvoPose(rightUpIdx) - m_GridXInGalvoPose(leftUpIdx))
            'y1InBotPose = m_GridYInGalvoPose(leftUpIdx) + kyInCam * (m_GridYInGalvoPose(rightUpIdx) - m_GridYInGalvoPose(leftUpIdx))

            'x2InBotPose = m_GridXInGalvoPose(leftDnIdx) + kxInCam * (m_GridXInGalvoPose(rightDnIdx) - m_GridXInGalvoPose(leftDnIdx))
            'y2InBotPose = m_GridYInGalvoPose(leftDnIdx) + kyInCam * (m_GridYInGalvoPose(rightDnIdx) - m_GridYInGalvoPose(leftDnIdx))

            'x3InBotPose = m_GridXInGalvoPose(leftUpIdx) + kxInCam * (m_GridXInGalvoPose(leftDnIdx) - m_GridXInGalvoPose(leftUpIdx))
            'y3InBotPose = m_GridYInGalvoPose(leftUpIdx) + kyInCam * (m_GridYInGalvoPose(leftDnIdx) - m_GridYInGalvoPose(leftUpIdx))

            'x4InBotPose = m_GridXInGalvoPose(rightUpIdx) + kxInCam * (m_GridXInGalvoPose(rightDnIdx) - m_GridXInGalvoPose(rightUpIdx))
            'y4InBotPose = m_GridYInGalvoPose(rightUpIdx) + kyInCam * (m_GridYInGalvoPose(rightDnIdx) - m_GridYInGalvoPose(rightUpIdx))
            ''直線
            ''y1=m1*x+b1
            ''y2=m2*x+b2
            'Dim m1 As Double, b1 As Double
            'Dim m2 As Double, b2 As Double
            ''y1InBotPose = m1 * x1InBotPose + b1
            '' y2InBotPose = m1 * x2InBotPose + b1
            'If x2InBotPose = x1InBotPose Then
            '    m1 = 0
            'Else
            '    m1 = (y2InBotPose - y1InBotPose) / (x2InBotPose - x1InBotPose)
            'End If
            'b1 = y1InBotPose - m1 * x1InBotPose

            ''橫線
            ''y3InBotPose = m2 * x3InBotPose + b2
            '' y4InBotPose = m2 * x4InBotPose + b2


            'If y4InBotPose = y3InBotPose Then
            '    m2 = 0
            'Else
            '    m2 = (y4InBotPose - y3InBotPose) / (x4InBotPose - x3InBotPose)
            'End If
            'b2 = y3InBotPose - m2 * x3InBotPose

            ''YInBotPose = m1 * XInBotPose + b1
            ''YInBotPose = m2 * XInBotPose + b2
            'If x2InBotPose = x1InBotPose Then
            '    XInGalvoPose = x1InBotPose
            '    If y4InBotPose = y3InBotPose Then
            '        YInGalvoPose = y3InBotPose
            '    Else
            '        YInGalvoPose = m2 * XInGalvoPose + b2
            '    End If
            'Else
            '    If y4InBotPose = y3InBotPose Then
            '        YInGalvoPose = y3InBotPose
            '        XInGalvoPose = (YInGalvoPose - b1) / m1
            '    Else
            '        XInGalvoPose = (b1 - b2) / (m2 - m1)
            '        YInGalvoPose = m1 * XInGalvoPose + b1
            '    End If
            'End If
            ImagePointsToGalvoPosition = True
        Catch ex As Exception
            ImagePointsToGalvoPosition = False
        End Try
    End Function

    Public Shared Function GalvoPositionToImagePoints(ByVal XInGalvo As Double, ByVal YInGalvo As Double, ByRef XInImage As Double, ByRef YInImage As Double) As Boolean
        Try
            Dim xInGalvoMin, xInGalvoMax, yInGalvoMin, yInGalvoMax As Double
            Dim xInImageMin, xInImageMax, yInImageMin, yInImageMax As Double
            xInGalvoMin = m_GridXInGalvoPose.Min() ' m_Laser.MinX 'mm
            xInGalvoMax = m_GridXInGalvoPose.Max() ''m_Laser.MaxX
            yInGalvoMin = m_GridYInGalvoPose.Min() ''m_Laser.MinY
            yInGalvoMax = m_GridYInGalvoPose.Max() 'm_Laser.MaxY
            xInImageMin = 0
            xInImageMax = ViewImageWidth
            yInImageMin = 0
            yInImageMax = ViewImageHeight

            'If (XInGalvo > xInGalvoMax) Then
            '    XInGalvo = xInGalvoMax
            'End If
            'If (XInGalvo < xInGalvoMin) Then
            '    XInGalvo = xInGalvoMin
            'End If
            'If (YInGalvo > yInGalvoMax) Then
            '    YInGalvo = yInGalvoMax
            'End If
            'If (YInGalvo < yInGalvoMin) Then
            '    YInGalvo = yInGalvoMin
            'End If

            'For idx = 0 To m_GridXInGalvoPose.Length - 1
            '    If (m_GridXInGalvoPose(idx) <= XInGalvo) Then
            '        If (m_GridXInGalvoPose(idx) >= xInGalvoMin) Then
            '            xInGalvoMin = m_GridXInGalvoPose(idx)
            '            xInImageMin = m_GridXInCamPose(idx)
            '        End If
            '    End If
            '    If (m_GridXInGalvoPose(idx) >= XInGalvo) Then
            '        If (m_GridXInGalvoPose(idx) <= xInGalvoMax) Then
            '            xInGalvoMax = m_GridXInGalvoPose(idx)
            '            xInImageMax = m_GridXInCamPose(idx)
            '        End If
            '    End If
            'Next

            'For idx = 0 To m_GridYInGalvoPose.Length - 1
            '    If (m_GridYInGalvoPose(idx) <= YInGalvo) Then
            '        If (m_GridYInGalvoPose(idx) >= yInGalvoMin) Then
            '            yInGalvoMin = m_GridYInGalvoPose(idx)
            '            yInImageMin = m_GridYInCamPose(idx)
            '        End If
            '    End If
            '    If (m_GridYInGalvoPose(idx) >= YInGalvo) Then
            '        If (m_GridYInGalvoPose(idx) <= yInGalvoMax) Then
            '            yInGalvoMax = m_GridYInGalvoPose(idx)
            '            yInImageMax = m_GridYInCamPose(idx)
            '        End If
            '    End If
            'Next

            Dim newGridXInGalvoPos As New List(Of Double)
            Dim newGridYInGalvoPos As New List(Of Double)
            Dim newGridXInImagePos As New List(Of Double)
            Dim newGridYInImagePos As New List(Of Double)

            newGridXInGalvoPos.AddRange(m_GridXInGalvoPose)
            newGridXInGalvoPos.Add(xInGalvoMin)
            newGridXInGalvoPos.Add(xInGalvoMax)

            newGridYInGalvoPos.AddRange(m_GridYInGalvoPose)
            newGridYInGalvoPos.Add(yInGalvoMax)
            newGridYInGalvoPos.Add(yInGalvoMin)

            newGridXInImagePos.AddRange(m_GridXInCamPose)
            newGridXInImagePos.Add(xInImageMin)
            newGridXInImagePos.Add(xInImageMax)

            newGridYInImagePos.AddRange(m_GridYInCamPose)
            newGridYInImagePos.Add(yInImageMin)
            newGridYInImagePos.Add(yInImageMax)


            xInGalvoMin = (From x As Double In newGridXInGalvoPos
                                    Where x <= XInGalvo).Max()
            xInGalvoMax = (From x As Double In newGridXInGalvoPos
                                    Where x >= XInGalvo).Min()
            yInGalvoMin = (From y As Double In newGridYInGalvoPos
                                    Where y <= YInGalvo).Max()
            yInGalvoMax = (From y As Double In newGridYInGalvoPos
                                    Where y >= YInGalvo).Min()

            Dim foundIdx As Integer = 0

            foundIdx = newGridXInGalvoPos.IndexOf(xInGalvoMin)
            xInImageMin = newGridXInImagePos(foundIdx)

            foundIdx = newGridXInGalvoPos.IndexOf(xInGalvoMax)
            xInImageMax = newGridXInImagePos(foundIdx)

            foundIdx = newGridYInGalvoPos.IndexOf(yInGalvoMin)
            yInImageMin = newGridYInImagePos(foundIdx)

            foundIdx = newGridYInGalvoPos.IndexOf(yInGalvoMax)
            yInImageMax = newGridYInImagePos(foundIdx)





            Dim scaleX As Double = 1
            Dim scaleY As Double = 1

            If (xInImageMax = xInImageMin) Then
                XInImage = xInImageMin
            Else
                scaleX = (xInGalvoMax - xInGalvoMin) / (xInImageMax - xInImageMin)
                If (XInGalvo < 0) Then
                    XInImage = xInImageMax - (xInGalvoMax - XInGalvo) / scaleX
                Else
                    XInImage = xInImageMin + (XInGalvo - xInGalvoMin) / scaleX
                End If
            End If
            If (yInImageMax = yInImageMin) Then
                YInImage = yInImageMin
            Else
                scaleY = (yInGalvoMax - yInGalvoMin) / (yInImageMax - yInImageMin)
                If (YInGalvo < 0) Then
                    YInImage = yInImageMax - (yInGalvoMax - YInGalvo) / scaleY
                Else
                    YInImage = yInImageMax - (yInGalvoMax - YInGalvo) / scaleY
                End If
            End If




















            'GalvoPositionToImagePoints = False
            'Dim StartXIdx As Integer
            'Dim StartYIdx As Integer

            'If XInGalvo >= m_GalvoWidthHigh Then
            '    XInGalvo = m_GalvoWidthHigh
            '    Exit Try
            'End If
            'If XInGalvo <= m_GalvoWidthLow Then
            '    XInGalvo = m_GalvoWidthLow
            '    Exit Try
            'End If

            'If YInGalvo >= m_GalvoHeightHigh Then
            '    YInGalvo = m_GalvoHeightHigh
            '    Exit Try
            'End If
            'If YInGalvo <= m_GalvoHeightLow Then
            '    YInGalvo = m_GalvoHeightLow
            '    Exit Try
            'End If

            'StartXIdx = CInt(Math.Floor((XInGalvo - m_GalvoWidthLow) * (m_MatrixNum - 1) / m_GalvoWidth))
            'StartYIdx = CInt(Math.Floor((YInGalvo - m_GalvoHeightLow) * (m_MatrixNum - 1) / m_GalvoHeight))
            ''計算比例
            'Dim kxInGalvo As Double, kyInGalvo As Double
            'kxInGalvo = (XInGalvo - m_GridXInGalvoPose(StartXIdx)) / (m_GridXInGalvoPose(StartXIdx + 1) - m_GridXInGalvoPose(StartXIdx))
            'kyInGalvo = (YInGalvo - m_GridYInGalvoPose(m_MatrixNum * StartYIdx)) / (m_GridYInGalvoPose(m_MatrixNum * (StartYIdx + 1)) - m_GridYInGalvoPose(m_MatrixNum * StartYIdx))


            ''計算非正交格線上的點
            'Dim x1InCamPose As Double, x2InCamPose As Double
            'Dim y1InCamPose As Double, y2InCamPose As Double
            'Dim x3InCamPose As Double, y3InCamPose As Double
            'Dim x4InCamPose As Double, y4InCamPose As Double
            'Dim leftUpIdx As Integer, rightUpIdx As Integer, leftDnIdx As Integer, rightDnIdx As Integer
            'leftUpIdx = m_MatrixNum  * StartYIdx + StartXIdx
            'rightUpIdx = m_MatrixNum  * StartYIdx + StartXIdx + 1
            'leftDnIdx = m_MatrixNum  * (StartYIdx + 1) + StartXIdx
            'rightDnIdx = m_MatrixNum  * (StartYIdx + 1) + StartXIdx + 1

            ''Dim pbool As Boolean
            ''  pbool = ImagePointsIdx(m_GridXInCamPose, m_GridYInCamPose, XInCamPose, YInCamPose, leftUpIdx, rightUpIdx, leftDnIdx, rightDnIdx, kxInCam, kyInCam)
            ''9 10 14 15

            ''格線上四個點
            'x1InCamPose = m_GridXInCamPose(leftUpIdx) + kxInGalvo * (m_GridXInCamPose(rightUpIdx) - m_GridXInCamPose(leftUpIdx))
            'y1InCamPose = m_GridYInCamPose(leftUpIdx) + kyInGalvo * (m_GridYInCamPose(rightUpIdx) - m_GridYInCamPose(leftUpIdx))

            'x2InCamPose = m_GridXInCamPose(leftDnIdx) + kxInGalvo * (m_GridXInCamPose(rightDnIdx) - m_GridXInCamPose(leftDnIdx))
            'y2InCamPose = m_GridYInCamPose(leftDnIdx) + kyInGalvo * (m_GridYInCamPose(rightDnIdx) - m_GridYInCamPose(leftDnIdx))

            'x3InCamPose = m_GridXInCamPose(leftUpIdx) + kxInGalvo * (m_GridXInCamPose(leftDnIdx) - m_GridXInCamPose(leftUpIdx))
            'y3InCamPose = m_GridYInCamPose(leftUpIdx) + kyInGalvo * (m_GridYInCamPose(leftDnIdx) - m_GridYInCamPose(leftUpIdx))

            'x4InCamPose = m_GridXInCamPose(rightUpIdx) + kxInGalvo * (m_GridXInCamPose(rightDnIdx) - m_GridXInCamPose(rightUpIdx))
            'y4InCamPose = m_GridYInCamPose(rightUpIdx) + kyInGalvo * (m_GridYInCamPose(rightDnIdx) - m_GridYInCamPose(rightUpIdx))
            ''直線
            ''y1=m1*x+b1
            ''y2=m2*x+b2
            'Dim m1 As Double, b1 As Double
            'Dim m2 As Double, b2 As Double
            ''y1InBotPose = m1 * x1InBotPose + b1
            '' y2InBotPose = m1 * x2InBotPose + b1
            'If x2InCamPose = x1InCamPose Then
            '    m1 = 0
            'Else
            '    m1 = (y2InCamPose - y1InCamPose) / (x2InCamPose - x1InCamPose)
            'End If
            'b1 = y1InCamPose - m1 * x1InCamPose

            ''橫線
            ''y3InBotPose = m2 * x3InBotPose + b2
            '' y4InBotPose = m2 * x4InBotPose + b2


            'If y4InCamPose = y3InCamPose Then
            '    m2 = 0
            'Else
            '    m2 = (y4InCamPose - y3InCamPose) / (x4InCamPose - x3InCamPose)
            'End If
            'b2 = y3InCamPose - m2 * x3InCamPose

            ''YInBotPose = m1 * XInBotPose + b1
            ''YInBotPose = m2 * XInBotPose + b2
            'If x2InCamPose = x1InCamPose Then
            '    XInImage = x1InCamPose
            '    If y4InCamPose = y3InCamPose Then
            '        YInImage = y3InCamPose
            '    Else
            '        YInImage = m2 * XInImage + b2
            '    End If
            'Else
            '    If y4InCamPose = y3InCamPose Then
            '        YInImage = y3InCamPose
            '        XInImage = (YInImage - b1) / m1
            '    Else
            '        XInImage = (b1 - b2) / (m2 - m1)
            '        YInImage = m1 * XInImage + b1
            '    End If
            'End If
            GalvoPositionToImagePoints = True
        Catch ex As Exception
            GalvoPositionToImagePoints = False
        End Try
    End Function

    'Public Shared Function GalvoPositionToEncoder(ByVal XInGalvo As Double, ByVal YInGalvo As Double, ByRef XInEncoder As Integer, ByRef YInEncoder As Integer) As Boolean
    '    Try
    '        Dim xInGalvoMin, xInGalvoMax, yInGalvoMin, yInGalvoMax As Double
    '        Dim xInEncoderMin, xInEncoderMax, yInEncoderMin, yInEncoderMax As Double
    '        xInGalvoMin = m_GridXInGalvoPose.Min() ' m_Laser.MinX 'mm
    '        xInGalvoMax = m_GridXInGalvoPose.Max() ''m_Laser.MaxX
    '        yInGalvoMin = m_GridYInGalvoPose.Min() ''m_Laser.MinY
    '        yInGalvoMax = m_GridYInGalvoPose.Max() 'm_Laser.MaxY
    '        xInEncoderMin = -32768
    '        xInEncoderMax = 32767
    '        yInEncoderMin = -32768
    '        yInEncoderMax = 32767

    '        Dim newGridXInGalvoPos As New List(Of Double)
    '        Dim newGridYInGalvoPos As New List(Of Double)
    '        Dim newGridXInEncoder As New List(Of Integer)
    '        Dim newGridYInEncoder As New List(Of Integer)

    '        newGridXInGalvoPos.AddRange(m_GridXInGalvoPose)
    '        newGridXInGalvoPos.Add(xInGalvoMin)
    '        newGridXInGalvoPos.Add(xInGalvoMax)

    '        newGridYInGalvoPos.AddRange(m_GridYInGalvoPose)
    '        newGridYInGalvoPos.Add(yInGalvoMin)
    '        newGridYInGalvoPos.Add(yInGalvoMax)

    '        newGridXInEncoder.AddRange(m_GridXInGalvoEncoder)
    '        newGridXInEncoder.Add(xInEncoderMin)
    '        newGridXInEncoder.Add(xInEncoderMax)

    '        newGridYInEncoder.AddRange(m_GridYInGalvoEncoder)
    '        newGridYInEncoder.Add(yInEncoderMin)
    '        newGridYInEncoder.Add(yInEncoderMax)


    '        xInGalvoMin = (From x As Double In newGridXInGalvoPos
    '                                Where x <= XInGalvo).Max()
    '        xInGalvoMax = (From x As Double In newGridXInGalvoPos
    '                                Where x >= XInGalvo).Min()
    '        yInGalvoMin = (From y As Double In newGridYInGalvoPos
    '                                Where y <= YInGalvo).Max()
    '        yInGalvoMax = (From y As Double In newGridYInGalvoPos
    '                                Where y >= YInGalvo).Min()

    '        Dim foundIdx As Integer = 0

    '        foundIdx = newGridXInGalvoPos.IndexOf(xInGalvoMin)
    '        xInEncoderMin = newGridXInEncoder(foundIdx)

    '        foundIdx = newGridXInGalvoPos.IndexOf(xInGalvoMax)
    '        xInEncoderMax = newGridXInEncoder(foundIdx)

    '        foundIdx = newGridYInGalvoPos.IndexOf(yInGalvoMin)
    '        yInEncoderMin = newGridYInEncoder(foundIdx)

    '        foundIdx = newGridYInGalvoPos.IndexOf(yInGalvoMax)
    '        yInEncoderMax = newGridYInEncoder(foundIdx)





    '        Dim scaleX As Double = 1
    '        Dim scaleY As Double = 1

    '        If (xInEncoderMax = xInEncoderMin) Then
    '            XInEncoder = xInEncoderMin
    '        Else
    '            scaleX = (xInGalvoMax - xInGalvoMin) / (xInEncoderMax - xInEncoderMin)
    '            If (XInGalvo < 0) Then
    '                XInEncoder = xInEncoderMax - (xInGalvoMax - XInGalvo) / scaleX
    '            Else
    '                XInEncoder = xInEncoderMin + (XInGalvo - xInGalvoMin) / scaleX
    '            End If
    '        End If
    '        If (yInEncoderMax = yInEncoderMin) Then
    '            YInEncoder = yInEncoderMin
    '        Else
    '            scaleY = (yInGalvoMax - yInGalvoMin) / (yInEncoderMax - yInEncoderMin)
    '            If (YInGalvo < 0) Then
    '                YInEncoder = yInEncoderMax - (yInGalvoMax - YInGalvo) / scaleY
    '            Else
    '                YInEncoder = yInEncoderMin + (YInGalvo - yInGalvoMin) / scaleY
    '            End If
    '        End If

    '        GalvoPositionToEncoder = True
    '    Catch ex As Exception
    '        GalvoPositionToEncoder = False
    '    End Try
    'End Function

    

    Private Sub btnSaveCalibration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveCalibration.Click
        btnSaveCalibration.Enabled = False
        Try
            Dim strImage(dgvImageValue.Rows.Count - 1) As String
            Dim strGalvo(dgvGalvoValue.Rows.Count - 1) As String

            For idx = 0 To strImage.Length - 1
                strImage(idx) = dgvImageValue.Rows(idx).Cells(1).Value.ToString() & "," & dgvImageValue.Rows(idx).Cells(2).Value.ToString()
                strGalvo(idx) = dgvGalvoValue.Rows(idx).Cells(1).Value.ToString() & "," & dgvGalvoValue.Rows(idx).Cells(2).Value.ToString()

            Next

            System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\Machine\Parameter\VisionPickCalibration.txt", strImage)
            System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\Machine\Parameter\GalvoPickCalibration.txt", strGalvo)
            ImagePointsInit("D:\DataSettings\LaserMachine\Machine\Parameter")
            FMessageBox.Show(Me, CChangeLanguage.GetString("已保存 !"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.OK)
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        btnSaveCalibration.Enabled = True
    End Sub

    Public Enum eCalibrationSize As Integer
        e3x3 = 9
        e5x5 = 25
        e7x7 = 49
        e9x9 = 81
        e11x11 = 121
        e13x13 = 169
        e15x15 = 225
    End Enum

    Private Sub btnWorkholderMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkholderMove0.Click, btnWorkholderMove1.Click, btnWorkholderMove2.Click, btnWorkholderMove3.Click, btnWorkholderMove4.Click, btnWorkholderMove5.Click
        m_WorkOK = False
        m_WorkComplete = False
        Call UserInterfaceRunStatus2(False)
        Try
            Dim idx As Integer
            Dim axisNum As enumAxis
            Dim target As Double
            Dim rStatus As enumMotionFlag
            Dim cylStatus1 As enumCylSts
            Dim cylStatus2 As enumCylSts

            Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
            Do
                Call System.Windows.Forms.Application.DoEvents()
                Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus1)
                If cylStatus1 = enumCylSts.Ready Then
                    Exit Do
                ElseIf cylStatus1 = enumCylSts.TimeOut Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
            Loop

            Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
            Do
                Call System.Windows.Forms.Application.DoEvents()
                Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus2)
                If cylStatus2 = enumCylSts.Ready Then
                    Exit Do
                ElseIf cylStatus2 = enumCylSts.TimeOut Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
            Loop
            If cylStatus1 = enumCylSts.Ready AndAlso cylStatus2 = enumCylSts.Ready Then
                idx = DirectCast((sender), Button).TabIndex
                Select Case idx
                    Case 0
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.SubstrateInX1
                    Case 1
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.WorkHolderCutX1
                    Case 2
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.WorkHolderCutX2
                    Case 3
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.SubstrateOutX1
                    Case 4
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.SubstratePunchX
                    Case 5
                        axisNum = enumAxis.WorkholderX
                        target = m_Param.Pos.Workholder.SubstrateBlowX
                End Select
                Do
                    Call System.Windows.Forms.Application.DoEvents()
                    If m_Motion.ChkStop(axisNum) = enumMotionFlag.eReady Then
                        Exit Do
                    End If
                Loop
                Do
                    Call System.Windows.Forms.Application.DoEvents()
                    m_Motion.IsExternalParameters(axisNum) = False
                    Call m_Motion.MoveAbs(axisNum, target, rStatus)
                    If rStatus = enumMotionFlag.eSent Then
                        Exit Do
                    ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                        FMessageBox.Show(Me, CChangeLanguage.GetString("行程超過軟體極限"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Exit Do
                    End If
                Loop
                Do
                    Call System.Windows.Forms.Application.DoEvents()
                    If m_Motion.ChkStop(axisNum) = enumMotionFlag.eReady Then
                        Exit Do
                    End If
                Loop
                m_WorkOK = True
            End If
        Catch ex As Exception
            'Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        Call UserInterfaceRunStatus2(True)
        m_WorkComplete = True
    End Sub

    Private Sub btnWorkholderSet0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkholderSet0.Click, btnWorkholderSet1.Click, btnWorkholderSet2.Click, btnWorkholderSet3.Click, btnWorkholderSet4.Click, btnWorkholderSet5.Click
        Call UserInterfaceRunStatus2(False)
        Try
            Dim idx As Integer
            Dim axisNum As enumAxis
            Dim target As Double
            idx = DirectCast((sender), Button).TabIndex
            Select Case idx
                Case 0
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.SubstrateInX1 = target
                    numWorkhodlerX0.Value = CDec(target)
                Case 1
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.WorkHolderCutX1 = target
                    numWorkhodlerX1.Value = CDec(target)
                Case 2
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.WorkHolderCutX2 = target
                    numWorkhodlerX2.Value = CDec(target)
                Case 3
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.SubstrateOutX1 = target
                    numWorkhodlerX3.Value = CDec(target)
                Case 4
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.SubstratePunchX = target
                    numWorkhodlerX4.Value = CDec(target)
                Case 5
                    axisNum = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisNum, target)
                    m_Param.Pos.Workholder.SubstrateBlowX = target
                    numWorkhodlerX5.Value = CDec(target)
            End Select
        Catch ex As Exception
            ' Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        Call UserInterfaceRunStatus2(True)
    End Sub

    Private Sub btnCyl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCylinder0.Click, btnCylinder1.Click, btnCylinder2.Click, btnCylinder3.Click, btnCylinder4.Click, btnCylinder5.Click, btnCylinder6.Click, btnCylinder7.Click, btnCylinder13.Click, btnCylinder12.Click, btnCylinder11.Click, btnCylinder10.Click, btnCylinder9.Click, btnCylinder8.Click
        m_WorkComplete = False
        Call UserInterfaceRunStatus2(False)
        m_WorkOK = False
        Try
            Dim cylStatus As enumCylSts
            Dim idx As Integer
            idx = DirectCast((sender), Button).TabIndex
            Select Case idx
                Case 0 '收料汽缸下降
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Action)
                    Do
                        'Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸下降>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 1 '收料汽缸上升
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    Do
                        'Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 2 '收料汽缸左移
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    Do
                        'Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Try
                        End If
                    Loop
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Normal)
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                            If cylStatus = enumCylSts.Ready Then
                                m_WorkOK = True
                                Exit Do
                            ElseIf cylStatus = enumCylSts.TimeOut Then
                                FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸左移>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Do
                            End If
                        Loop
                    End If

                Case 3 '收料汽缸右移
                    Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Try
                        End If
                    Loop
                    If cylStatus = enumCylSts.Ready Then
                        Call m_DA.DigO.CylGo(enumCyl.TrayOutLeftRight, enumCyllogic.Action)
                        Do
                            Call System.Windows.Forms.Application.DoEvents()
                            Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutLeftRight, cylStatus)
                            If cylStatus = enumCylSts.Ready Then
                                m_WorkOK = True
                                Exit Do
                            ElseIf cylStatus = enumCylSts.TimeOut Then
                                FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸右移>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                                Exit Do
                            End If
                        Loop
                    End If

                Case 4  'Magnet On
                    Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Action)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<電磁鐵>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 5 'Magnet Off
                    Call m_DA.DigO.CylGo(enumCyl.MagnetOnOff, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.MagnetOnOff, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<電磁鐵>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop

                Case 6 '沖壓汽缸下降
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Action)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<沖壓汽缸下降>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop

                Case 7  '沖壓汽缸上升
                    Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<沖壓汽缸上升>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop


                Case 8 'Blow1 On
                    Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Action)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.Blow1, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<吹氣1>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 9 'Blow1 Off
                    Call m_DA.DigO.CylGo(enumCyl.Blow1, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.Blow1, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<吹氣1>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 10 'Blow2 On
                    Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Action)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.Blow2, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<吹氣2>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop
                Case 11 'Blow2 Off
                    Call m_DA.DigO.CylGo(enumCyl.Blow2, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.Blow2, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<吹氣2>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop

                Case 12
                    btnCylinder12.BackColor = Color.DarkGray
                    btnCylinder13.BackColor = Color.White
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Action)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<平台解真空>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop

                Case 13
                    btnCylinder12.BackColor = Color.White
                    btnCylinder13.BackColor = Color.DarkGray
                    Call m_DA.DigO.CylGo(enumCyl.WorkholderVaccum, enumCyllogic.Normal)
                    Do
                        Call System.Windows.Forms.Application.DoEvents()
                        Call m_DA.DigO.CheckCylReady(enumCyl.WorkholderVaccum, cylStatus)
                        If cylStatus = enumCylSts.Ready Then
                            m_WorkOK = True
                            Exit Do
                        ElseIf cylStatus = enumCylSts.TimeOut Then
                            FMessageBox.Show(Me, CChangeLanguage.GetString("<平台解真空>動作時間過久異常!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Do
                        End If
                    Loop


            End Select
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Call UserInterfaceRunStatus2(True)
        m_WorkComplete = True
    End Sub

    Private Sub btnOpenInputForm_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenInputForm.Click
        Try
            If (m_Corection IsNot Nothing) Then
                Dim f As FInputCorrection = New FInputCorrection(m_Corection, dgvCorrection)
                f.ShowDialog()
                f.Dispose()
                f = Nothing
                dgvCorrection.Refresh()
            End If
        Catch
        End Try
    End Sub
    Private Sub CheckCorrectionFolder()
        Try
            If (Not System.IO.Directory.Exists("C:\RTC4 Files\Correction Files") OrElse Not System.IO.File.Exists("C:\RTC4 Files\Correction Files\correXion.exe")) Then
                Dim path = "C:\Users\" & Environment.UserName & "\Desktop"
                Dim folders() As String = System.IO.Directory.GetDirectories(path, "LaserCutting*")
                For idx = 0 To folders.Length - 1
                    If (System.IO.Directory.Exists(folders(idx) & "\Correction Files")) Then
                        My.Computer.FileSystem.CopyDirectory(folders(idx) & "\Correction Files", "C:\RTC4 Files\Correction Files", True)
                        Exit For
                    End If
                Next
            End If
        Catch
        End Try
    End Sub
    Private Sub btnBuildCorrectionFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuildCorrectionFile.Click
        If (m_CorrectionDataFilePath <> "") Then
            Try
                'Check program exist
                CheckCorrectionFolder()
                Dim backupFolder As String = m_CorrectionDataFilePath.Replace("D2_263.dat", "Backup")
                If (Not System.IO.Directory.Exists(backupFolder)) Then
                    System.IO.Directory.CreateDirectory(backupFolder)
                End If
                If (Not System.IO.Directory.Exists("C:\RTC4 Files")) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("文件夾 C:\RTC4 Files 不存在"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If (Not System.IO.Directory.Exists("C:\RTC4 Files\Correction Files")) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("文件夾 C:\RTC4 Files\Correction Files 不存在"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If (Not System.IO.File.Exists("C:\RTC4 Files\Correction Files\correXion.exe")) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("文件 C:\RTC4 Files\Correction Files\correXion.exe 不存在"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                If (Not System.IO.Directory.Exists("C:\RTC4 Files\Correction Files\Backup")) Then
                    System.IO.Directory.CreateDirectory("C:\RTC4 Files\Correction Files\Backup")
                End If
                If (Not System.IO.Directory.Exists("C:\RTC4 Files\Backup")) Then
                    System.IO.Directory.CreateDirectory("C:\RTC4 Files\Backup")
                End If
                Me.Enabled = False
                'Prepare file
                Dim pPath As String = m_CorrectionDataFilePath.Replace(".dat", "_tmp.dat")
                My.Computer.FileSystem.CopyFile(m_CorrectionDataFilePath, pPath, True)

                Dim strLines() As String = System.IO.File.ReadAllLines(pPath)
                strLines(3) = "NewCal = 1000" '& numNewK.Value.ToString()
                strLines(5) = "OldCTBFile = C:\RTC4 Files\D2_263.ctb"
                strLines(6) = "NewCTBFile = C:\RTC4 Files\Correction Files\NewD2_263.ctb"
                System.IO.File.WriteAllLines(pPath, strLines)
                ReDim strLines(-1)

                'Backup file
                Dim dateString As String = DateTime.Now.ToString("yyyyMMddHHmmss")
                If (System.IO.File.Exists("C:\RTC4 Files\D2_263.ctb")) Then
                    My.Computer.FileSystem.CopyFile("C:\RTC4 Files\D2_263.ctb", "C:\RTC4 Files\Backup\D2_263_BK" & dateString & ".ctb", True)
                End If
                If (System.IO.File.Exists("C:\RTC4 Files\D2_263.ctb.txt")) Then
                    My.Computer.FileSystem.CopyFile("C:\RTC4 Files\D2_263.ctb.txt", "C:\RTC4 Files\Backup\D2_263.ctb_BK" & dateString & ".txt", True)
                End If
                Try
                    Dim files() As String = System.IO.Directory.GetFiles("C:\RTC4 Files\Correction Files", "*.*").Where(Function(f) f.EndsWith(".ctb") OrElse f.EndsWith(".txt")).ToArray()
                    If (files IsNot Nothing) Then
                        If (files.Length > 0) Then
                            If (Not System.IO.Directory.Exists("C:\RTC4 Files\Correction Files\Backup\" & dateString)) Then
                                System.IO.Directory.CreateDirectory("C:\RTC4 Files\Correction Files\Backup\" & dateString)
                            End If
                        End If
                        For idx = 0 To files.Length - 1
                            Dim filename As String = files(idx).Substring(files(idx).LastIndexOf("\") + 1)
                            Dim newpath As String = files(idx).Substring(0, files(idx).LastIndexOf("\")) & "\Backup\" & dateString & "\" & filename
                            My.Computer.FileSystem.MoveFile(files(idx), newpath, True)
                        Next
                    End If
                Catch
                End Try

                'Open program
                Dim proc As Process = New Process()
                proc.StartInfo.FileName = "C:\RTC4 Files\Correction Files\correXion.exe"
                proc.StartInfo.Arguments = """" & pPath & """"
                proc.Start()
                While Not proc.HasExited
                    Application.DoEvents()
                End While

                'check OK
                Dim checkOK As Boolean = False
                Dim files2() As String = System.IO.Directory.GetFiles("C:\RTC4 Files\Correction Files", "*.*").Where(Function(f) f.ToUpper().EndsWith("NEWD2_263.CTB") OrElse f.ToUpper().EndsWith("NEWD2_263.CTB.TXT")).ToArray()
                If (files2 IsNot Nothing AndAlso files2.Length > 0) Then
                    checkOK = True
                End If

                'Backup tmp file
                My.Computer.FileSystem.CopyFile(pPath, backupFolder & "\D2_263_BK" & dateString & ".dat")

                If (checkOK = True) Then
                    If (FMessageBox.Show(Me, CChangeLanguage.GetString("您是否複製並重新加載更正文件？"), CChangeLanguage.GetString("複製並重新加載"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                        'Copy file
                        My.Computer.FileSystem.CopyFile("C:\RTC4 Files\Correction Files\NewD2_263.ctb", "C:\RTC4 Files\D2_263.ctb", True)
                        My.Computer.FileSystem.CopyFile("C:\RTC4 Files\Correction Files\NewD2_263.ctb.txt", "C:\RTC4 Files\D2_263.ctb.txt", True)

                        'Reload correction file
                        'm_Laser = New CLaser(m_Param, m_Timer)
                        FMessageBox.Show(Me, CChangeLanguage.GetString("校正完成！") & vbCrLf & CChangeLanguage.GetString("請重新啟動程式。"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Environment.Exit(0)
                    Else
                        Process.Start("C:\RTC4 Files\Correction Files")
                    End If
                Else
                    FMessageBox.Show(Me, CChangeLanguage.GetString("錯誤：無法擬合（計算 CTB）"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch
            End Try
            Me.Enabled = True
        End If
    End Sub

    Private Sub btnSavePos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSavePos.Click
        Try
            Dim flag As Boolean = False
            Dim logPath As String = "D:\DataSettings\LaserMachine\Machine\Parameter\Log"
            If (Not System.IO.Directory.Exists(logPath)) Then
                System.IO.Directory.CreateDirectory(logPath)
            End If
            logPath &= "\" & DateTime.Now.ToString("yyyyMMdd") & ".log"
            If (m_Param.Pos.Workholder.SubstrateInX1 <> numWorkhodlerX0.Value) Then
                Call MLog.SaveLog("更改 Param.Pos.Workholder.SubstrateInX1", m_Param.Pos.Workholder.SubstrateInX1.ToString(), numWorkhodlerX0.Value.ToString(), logPath)
                m_Param.Pos.Workholder.SubstrateInX1 = numWorkhodlerX0.Value
                flag = True
            End If
            If (m_Param.Pos.Workholder.WorkHolderCutX1 <> numWorkhodlerX1.Value) Then
                Call MLog.SaveLog("更改 Param.Pos.Workholder.WorkHolderCutX1", m_Param.Pos.Workholder.WorkHolderCutX1.ToString(), numWorkhodlerX1.Value.ToString(), logPath)
                m_Param.Pos.Workholder.WorkHolderCutX1 = numWorkhodlerX1.Value
                flag = True
            End If
            If (m_Param.Pos.Workholder.WorkHolderCutX2 <> numWorkhodlerX2.Value) Then
                Call MLog.SaveLog("更改 Param.Pos.Workholder.WorkHolderCutX2", m_Param.Pos.Workholder.WorkHolderCutX2.ToString(), numWorkhodlerX2.Value.ToString(), logPath)
                m_Param.Pos.Workholder.WorkHolderCutX2 = numWorkhodlerX2.Value
                flag = True
            End If
            If (m_Param.Pos.Workholder.SubstrateOutX1 <> numWorkhodlerX3.Value) Then
                Call MLog.SaveLog("Change Param.Pos.Workholder.SubstrateOutX1", m_Param.Pos.Workholder.SubstrateOutX1.ToString(), numWorkhodlerX3.Value.ToString(), logPath)
                m_Param.Pos.Workholder.SubstrateOutX1 = numWorkhodlerX3.Value
                flag = True
            End If
            If (m_Param.Pos.Workholder.SubstratePunchX <> numWorkhodlerX4.Value) Then
                Call MLog.SaveLog("Change Param.Pos.Workholder.SubstratePunchX", m_Param.Pos.Workholder.SubstratePunchX.ToString(), numWorkhodlerX4.Value.ToString(), logPath)
                m_Param.Pos.Workholder.SubstratePunchX = numWorkhodlerX4.Value
                flag = True
            End If
            If (m_Param.Pos.Workholder.SubstrateBlowX <> numWorkhodlerX5.Value) Then
                Call MLog.SaveLog("Change Param.Pos.Workholder.SubstrateBlowX", m_Param.Pos.Workholder.SubstrateBlowX.ToString(), numWorkhodlerX5.Value.ToString(), logPath)
                m_Param.Pos.Workholder.SubstrateBlowX = numWorkhodlerX5.Value
                flag = True
            End If
            Call m_Param.WriteDataToFile("D:\DataSettings\LaserMachine\Machine\Parameter\Parameter.xml")
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnWorkholderTestMove0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWorkholderTestMove0.Click, btnWorkholderTestMove1.Click
        Dim idx As Integer
        Dim axisID As enumAxis
        Dim rStatus As enumMotionFlag
        Dim target As Double
        Dim cylStatus As enumCylSts
        Try
            Call UserInterfaceRunStatus2(False)

            Call m_DA.DigO.CylGo(enumCyl.TrayOutUpDown, enumCyllogic.Normal)
            Do
                Call System.Windows.Forms.Application.DoEvents()
                Call m_DA.DigO.CheckCylReady(enumCyl.TrayOutUpDown, cylStatus)
                If cylStatus = enumCylSts.Ready Then
                    Exit Do
                ElseIf cylStatus = enumCylSts.TimeOut Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>上升時間過久異常!!請調整上感應器位置!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
            Loop

            Call m_DA.DigO.CylGo(enumCyl.TrayInUpDown, enumCyllogic.Normal)
            Do
                Call System.Windows.Forms.Application.DoEvents()
                Call m_DA.DigO.CheckCylReady(enumCyl.TrayInUpDown, cylStatus)
                If cylStatus = enumCylSts.Ready Then
                    Exit Do
                ElseIf cylStatus = enumCylSts.TimeOut Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("<收料汽缸上升>上升時間過久異常!!請調整上感應器位置!!"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
            Loop




            idx = DirectCast((sender), Button).TabIndex
            Select Case idx
                Case 0 '水平左移
                    axisID = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisID, target)
                    target = (target) - numMovingDistance0.Value

                Case 1 '水平右移
                    axisID = enumAxis.WorkholderX
                    Call m_Motion.GetCmd(axisID, target)
                    target = (target) + numMovingDistance0.Value

            End Select
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Exit Do
                End If
            Loop
            Do
                Call System.Windows.Forms.Application.DoEvents()
                m_Motion.IsExternalParameters(axisID) = False
                Call m_Motion.MoveAbs(axisID, target, rStatus, 1, 1)
                If rStatus = enumMotionFlag.eSent Then
                    Exit Do
                ElseIf rStatus = enumMotionFlag.eLimitP OrElse rStatus = enumMotionFlag.eLimitN Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString("行程超過軟體極限"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Do
                End If
            Loop
            Do
                Call System.Windows.Forms.Application.DoEvents()
                If m_Motion.ChkStop(axisID) = enumMotionFlag.eReady Then
                    Exit Do
                End If
            Loop
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Call UserInterfaceRunStatus2(True)
    End Sub

    Private m_Timer1Complete As Boolean = True
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            If (m_Timer1Complete = False) Then
                Exit Try
            End If
            m_Timer1Complete = False
            Dim axisNum As Integer
            Dim nowEncoder As Double
            axisNum = enumAxis.WorkholderX
            Call m_Motion.GetEncoder(axisNum, nowEncoder)
            lblWorkholderXNow.Text = (nowEncoder).ToString("F1")

            If (m_DA.DigO.Status(enumCyl.TrayInUpDown) = enumCyllogic.Action) Then
                btnCylinder6.BackColor = Color.Salmon
                btnCylinder7.BackColor = Color.White
            Else
                btnCylinder6.BackColor = Color.White
                btnCylinder7.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.WorkholderVaccum) = enumCyllogic.Action) Then
                btnCylinder12.BackColor = Color.Salmon
                btnCylinder13.BackColor = Color.White
            Else
                btnCylinder12.BackColor = Color.White
                btnCylinder13.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.TrayOutUpDown) = enumCyllogic.Action) Then
                btnCylinder0.BackColor = Color.Salmon
                btnCylinder1.BackColor = Color.White
            Else
                btnCylinder0.BackColor = Color.White
                btnCylinder1.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.TrayOutLeftRight) = enumCyllogic.Action) Then
                btnCylinder3.BackColor = Color.Salmon
                btnCylinder2.BackColor = Color.White
            Else
                btnCylinder3.BackColor = Color.White
                btnCylinder2.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.MagnetOnOff) = enumCyllogic.Action) Then
                btnCylinder4.BackColor = Color.Salmon
                btnCylinder5.BackColor = Color.White
            Else
                btnCylinder4.BackColor = Color.White
                btnCylinder5.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.Blow1) = enumCyllogic.Action) Then
                btnCylinder8.BackColor = Color.Salmon
                btnCylinder9.BackColor = Color.White
            Else
                btnCylinder8.BackColor = Color.White
                btnCylinder9.BackColor = Color.Salmon
            End If

            If (m_DA.DigO.Status(enumCyl.Blow2) = enumCyllogic.Action) Then
                btnCylinder10.BackColor = Color.Salmon
                btnCylinder11.BackColor = Color.White
            Else
                btnCylinder10.BackColor = Color.White
                btnCylinder11.BackColor = Color.Salmon
            End If

            m_Timer1Complete = True
        Catch ex As Exception
            m_Timer1Complete = True
        End Try
    End Sub

    Private Sub UpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpToolStripMenuItem.Click
        Try
            If (m_LineSelected IsNot Nothing) Then
                Dim idx1, idx2 As Integer

                'Find selected index
                For idx1 = 0 To m_ListLine.Count - 1
                    If (m_ListLine(idx1).ID = m_LineSelected.ID) Then
                        Exit For
                    End If
                Next

                'Find the Line on index-1
                idx2 = idx1
                For i = idx1 - 1 To 0 Step -1
                    If (m_ListLine(idx1).[Step] = m_ListLine(i).[Step]) Then
                        idx2 = i
                        Exit For
                    End If
                Next

                If (idx1 <= idx2) Then 'The selected Line is on top. So it can't move up
                    Exit Try
                End If

                'Move up
                Dim tmp As CLine = m_ListLine(idx1)
                m_ListLine(idx1) = m_ListLine(idx2)
                m_ListLine(idx2) = tmp

                'Reload Treeview
                TreeView1.BeginUpdate()
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))
                Dim selectedNode As TreeNode = Nothing
                For index = 1 To m_CurrentProject.WorkStep
                    TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                    TreeView1.Nodes(0).Nodes(index - 1).Tag = index
                    Dim idx As Integer = 0
                    For i = 0 To m_ListLine.Count - 1
                        If (m_ListLine(i).[Step] = index) Then
                            TreeView1.Nodes(0).Nodes(index - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))
                            m_ListLine(i).Name = "LINE" & (idx + 1).ToString()
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Name = m_ListLine(i).ID
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Tag = m_ListLine(i)
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Text = String.Format(CChangeLanguage.GetString("第{0}線"), (idx + 1))
                            Dim newLineCtrl As CLineCtrl = New CLineCtrl(grbCamera.Size, m_ListLine(i).StartXPX, m_ListLine(i).StartYPX, m_ListLine(i).EndXPX, m_ListLine(i).EndYPX, m_Param.Variable.Graphic.LineColor)

                            If (m_ListLine(i).ID = m_LineSelected.ID) Then
                                selectedNode = TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx)
                            End If
                            grbCamera.Controls.Remove(grbCamera.Controls(m_ListLine(i).ID))
                            newLineCtrl.Name = m_ListLine(i).ID
                            newLineCtrl.TabIndex = m_ListLine(i).[Step]
                            grbCamera.Controls.Add(newLineCtrl)
                            newLineCtrl.BringToFront()
                            AddHandler newLineCtrl.MouseUp, AddressOf Control_MouseUp
                            AddHandler newLineCtrl.MouseDown, AddressOf Control_MouseDown
                            AddHandler newLineCtrl.MouseDoubleClick, AddressOf Control_MouseDoubleClick

                            AddHandler newLineCtrl.MouseEnter, AddressOf Control_MouseEnter
                            AddHandler newLineCtrl.MouseLeave, AddressOf Control_MouseLeave
                            AddHandler newLineCtrl.MouseMove, AddressOf Control_MouseMove
                            idx += 1
                        End If
                    Next
                Next

                TreeView1.ExpandAll()
                TreeView1.EndUpdate()
                TreeView1.SelectedNode = selectedNode
                TreeView1_NodeMouseClick(TreeView1, New TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, 0, 0))

            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("向上移動錯誤"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub DownToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DownToolStripMenuItem.Click
        Try
            If (m_LineSelected IsNot Nothing) Then
                Dim idx1, idx2 As Integer

                'Find selected index
                For idx1 = 0 To m_ListLine.Count - 1
                    If (m_ListLine(idx1).ID = m_LineSelected.ID) Then
                        Exit For
                    End If
                Next

                'Find the Line on index-1
                idx2 = idx1
                For i = idx1 + 1 To m_ListLine.Count - 1
                    If (m_ListLine(idx1).[Step] = m_ListLine(i).[Step]) Then
                        idx2 = i
                        Exit For
                    End If
                Next

                If (idx1 >= idx2) Then 'The selected Line is on bottom. So it can't move down
                    Exit Try
                End If

                'Move up
                Dim tmp As CLine = m_ListLine(idx1)
                m_ListLine(idx1) = m_ListLine(idx2)
                m_ListLine(idx2) = tmp

                'Reload Treeview
                TreeView1.BeginUpdate()
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))
                Dim selectedNode As TreeNode = Nothing
                For index = 1 To m_CurrentProject.WorkStep
                    TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                    TreeView1.Nodes(0).Nodes(index - 1).Tag = index
                    Dim idx As Integer = 0
                    For i = 0 To m_ListLine.Count - 1
                        If (m_ListLine(i).[Step] = index) Then
                            TreeView1.Nodes(0).Nodes(index - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))
                            m_ListLine(i).Name = "LINE" & (idx + 1).ToString()
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Name = m_ListLine(i).ID
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Tag = m_ListLine(i)
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Text = String.Format(CChangeLanguage.GetString("第{0}線"), (idx + 1))
                            Dim newLineCtrl As CLineCtrl = New CLineCtrl(grbCamera.Size, m_ListLine(i).StartXPX, m_ListLine(i).StartYPX, m_ListLine(i).EndXPX, m_ListLine(i).EndYPX, m_Param.Variable.Graphic.LineColor)

                            If (m_ListLine(i).ID = m_LineSelected.ID) Then
                                selectedNode = TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx)
                            End If
                            grbCamera.Controls.Remove(grbCamera.Controls(m_ListLine(i).ID))
                            newLineCtrl.Name = m_ListLine(i).ID
                            newLineCtrl.TabIndex = m_ListLine(i).[Step]
                            grbCamera.Controls.Add(newLineCtrl)
                            newLineCtrl.BringToFront()
                            AddHandler newLineCtrl.MouseUp, AddressOf Control_MouseUp
                            AddHandler newLineCtrl.MouseDown, AddressOf Control_MouseDown
                            AddHandler newLineCtrl.MouseDoubleClick, AddressOf Control_MouseDoubleClick

                            AddHandler newLineCtrl.MouseEnter, AddressOf Control_MouseEnter
                            AddHandler newLineCtrl.MouseLeave, AddressOf Control_MouseLeave
                            AddHandler newLineCtrl.MouseMove, AddressOf Control_MouseMove
                            idx += 1
                        End If
                    Next
                Next

                TreeView1.ExpandAll()
                TreeView1.EndUpdate()
                TreeView1.SelectedNode = selectedNode
                TreeView1_NodeMouseClick(TreeView1, New TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, 0, 0))

            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("向下移動錯誤"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub CloneToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloneToolStripMenuItem.Click
        Try
            If (m_LineSelected IsNot Nothing) Then
                Dim idx1 As Integer

                'Find selected index
                For idx1 = 0 To m_ListLine.Count - 1
                    If (m_ListLine(idx1).ID = m_LineSelected.ID) Then
                        Exit For
                    End If
                Next

                'Clone new Line
                m_ListLine.Add(m_ListLine(idx1).CloneNewID)
                m_LineSelected = m_ListLine(m_ListLine.Count - 1)
                PropertyGrid1.SelectedObject = m_LineSelected

                'Reload Treeview
                TreeView1.BeginUpdate()
                TreeView1.Nodes.Clear()
                TreeView1.Nodes.Add(New TreeNode(m_CurrentProject.ProjectName))
                Dim selectedNode As TreeNode = Nothing
                For index = 1 To m_CurrentProject.WorkStep
                    TreeView1.Nodes(0).Nodes.Add(New TreeNode(String.Format(CChangeLanguage.GetString("第{0}步"), index)))
                    TreeView1.Nodes(0).Nodes(index - 1).Tag = index
                    Dim idx As Integer = 0
                    For i = 0 To m_ListLine.Count - 1
                        If (m_ListLine(i).[Step] = index) Then
                            TreeView1.Nodes(0).Nodes(index - 1).Nodes.Add(New TreeNode(CChangeLanguage.GetString("線")))
                            m_ListLine(i).Name = "LINE" & (idx + 1).ToString()
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Name = m_ListLine(i).ID
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Tag = m_ListLine(i)
                            TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx).Text = String.Format(CChangeLanguage.GetString("第{0}線"), (idx + 1))
                            Dim newLineCtrl As CLineCtrl = New CLineCtrl(grbCamera.Size, m_ListLine(i).StartXPX, m_ListLine(i).StartYPX, m_ListLine(i).EndXPX, m_ListLine(i).EndYPX, m_Param.Variable.Graphic.LineColor)

                            If (m_ListLine(i).ID = m_LineSelected.ID) Then
                                selectedNode = TreeView1.Nodes(0).Nodes(m_ListLine(i).[Step] - 1).Nodes(idx)
                            End If
                            grbCamera.Controls.Remove(grbCamera.Controls(m_ListLine(i).ID))
                            newLineCtrl.Name = m_ListLine(i).ID
                            newLineCtrl.TabIndex = m_ListLine(i).[Step]
                            grbCamera.Controls.Add(newLineCtrl)
                            newLineCtrl.BringToFront()
                            AddHandler newLineCtrl.MouseUp, AddressOf Control_MouseUp
                            AddHandler newLineCtrl.MouseDown, AddressOf Control_MouseDown
                            AddHandler newLineCtrl.MouseDoubleClick, AddressOf Control_MouseDoubleClick

                            AddHandler newLineCtrl.MouseEnter, AddressOf Control_MouseEnter
                            AddHandler newLineCtrl.MouseLeave, AddressOf Control_MouseLeave
                            AddHandler newLineCtrl.MouseMove, AddressOf Control_MouseMove
                            idx += 1
                        End If
                    Next
                Next

                TreeView1.ExpandAll()
                TreeView1.EndUpdate()
                TreeView1.SelectedNode = selectedNode
                TreeView1_NodeMouseClick(TreeView1, New TreeNodeMouseClickEventArgs(selectedNode, MouseButtons.Left, 1, 0, 0))

            End If
        Catch ex As Exception
            FMessageBox.Show(Me, CChangeLanguage.GetString("複製錯誤"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub btnHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHome.Click
        Try
            Call AddLog(CChangeLanguage.GetString("復歸位置"), enumLogType.StartStop)
            m_Param.Flags.System.KeyCode = enumKeyConst.KeyMainRestart
        Catch ex As Exception

        End Try
    End Sub

    Public Function GetComponents() As System.ComponentModel.Container
        Return components
    End Function

    Private Sub lnkLanguage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkLanguage.LinkClicked
        lnkLanguage.Enabled = False
        Try
            If (CChangeLanguage.CurLang = Language.Chinese) Then
                CChangeLanguage.setLanguage(Language.English)
            Else
                CChangeLanguage.setLanguage(Language.Chinese)
            End If
            CChangeLanguage.ApplyLanguage(Me)
            If (TreeView1 IsNot Nothing AndAlso TreeView1.Nodes.Count > 0) Then
                TreeView1.BeginUpdate()
                For Each node As TreeNode In TreeView1.Nodes(0).Nodes
                    UpdateTreeNodeText(node)
                    node.Text = CChangeLanguage.GetString(node.Text)
                Next
                TreeView1.EndUpdate()
            End If
            PropertyGrid1.Refresh()
            dgvWorkStepByStep.Rows.Clear()
            dgvWorkStepByStep.Rows.Add(New Object() {"1", CChangeLanguage.GetString("送料位置")})
            dgvWorkStepByStep.Rows.Add(New Object() {"2", CChangeLanguage.GetString("吹氣1位置")})
            dgvWorkStepByStep.Rows.Add(New Object() {"3", CChangeLanguage.GetString("沖壓位置")})
            dgvWorkStepByStep.Rows.Add(New Object() {"4", CChangeLanguage.GetString("切割位置1")})
            dgvWorkStepByStep.Rows.Add(New Object() {"5", CChangeLanguage.GetString("切割位置2")})
            dgvWorkStepByStep.Rows.Add(New Object() {"6", CChangeLanguage.GetString("收料位置")})
            For i = 0 To dgvWorkStepByStep.Rows.Count - 1
                dgvWorkStepByStep.Rows(i).Height = 50
            Next
        Catch ex As Exception
        End Try
        lnkLanguage.Enabled = True
    End Sub
    Private Sub UpdateTreeNodeText(ByVal node As TreeNode)
        For Each childNode As TreeNode In node.Nodes
            UpdateTreeNodeText(childNode)
        Next
        node.Text = CChangeLanguage.GetString(node.Text)
    End Sub

    Private Sub ContextMenuStripMoveLine_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ContextMenuStripMoveLine.Opening
        If (m_CopiedParameter Is Nothing) Then
            PasteLaserParameterToolStripMenuItem.Enabled = False
        Else
            PasteLaserParameterToolStripMenuItem.Enabled = True
        End If
    End Sub

    Private Sub CopyLaserParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyLaserParameterToolStripMenuItem.Click
        Try
            If (m_LineSelected IsNot Nothing) Then
                m_CopiedParameter = New CMerge()
                Dim copyToText As String = ""
                m_CopiedParameter.JumpDelay = m_LineSelected.JumpDelay
                copyToText &= "JumpDelay: " & m_LineSelected.JumpDelay & vbCrLf
                m_CopiedParameter.JumpSpeed = m_LineSelected.JumpSpeed
                copyToText &= "JumpSpeed: " & m_LineSelected.JumpSpeed & vbCrLf
                m_CopiedParameter.LaserOffDelay = m_LineSelected.LaserOffDelay
                copyToText &= "LaserOffDelay: " & m_LineSelected.LaserOffDelay & vbCrLf
                m_CopiedParameter.LaserOnDelay = m_LineSelected.LaserOnDelay
                copyToText &= "LaserOnDelay: " & m_LineSelected.LaserOnDelay & vbCrLf
                m_CopiedParameter.LaserPower = m_LineSelected.LaserPower
                copyToText &= "LaserPower: " & m_LineSelected.LaserPower & vbCrLf
                m_CopiedParameter.LaserPRR = m_LineSelected.LaserPRR
                copyToText &= "LaserPRR: " & m_LineSelected.LaserPRR & vbCrLf
                m_CopiedParameter.MarkDelay = m_LineSelected.MarkDelay
                copyToText &= "MarkDelay: " & m_LineSelected.MarkDelay & vbCrLf
                m_CopiedParameter.MarkSpeed = m_LineSelected.MarkSpeed
                copyToText &= "MarkSpeed: " & m_LineSelected.MarkSpeed & vbCrLf
                m_CopiedParameter.PolygonDelay = m_LineSelected.PolygonDelay
                copyToText &= "PolygonDelay: " & m_LineSelected.PolygonDelay & vbCrLf
                m_CopiedParameter.RepeatCount = m_LineSelected.RepeatCount
                copyToText &= "RepeatCount: " & m_LineSelected.RepeatCount & vbCrLf
                If (m_LineSelected.RepeatMode = eRepeatMode.Mode1) Then
                    m_CopiedParameter.RepeatMode = eRepeatModeMerge.Mode1
                    copyToText &= "RepeatMode: Mode1" & vbCrLf
                ElseIf (m_LineSelected.RepeatMode = eRepeatMode.Mode2) Then
                    m_CopiedParameter.RepeatMode = eRepeatModeMerge.Mode2
                    copyToText &= "RepeatMode: Mode2" & vbCrLf
                Else
                    m_CopiedParameter.RepeatMode = eRepeatModeMerge.NoSet
                    copyToText &= "RepeatMode: NoSet" & vbCrLf
                End If
                Clipboard.SetText(copyToText)
            Else
                m_CopiedParameter = Nothing
                Clipboard.SetText("")
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub PasteLaserParameterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteLaserParameterToolStripMenuItem.Click
        Try
            If (m_CopiedParameter IsNot Nothing AndAlso m_LineSelected IsNot Nothing) Then
                Dim idx As Integer = -1

                For i = 0 To m_ListLine.Count - 1
                    If (m_ListLine(i).ID = m_LineSelected.ID) Then
                        idx = i
                        Exit For
                    End If
                Next
                If (idx = -1) Then
                    Exit Sub
                End If
                m_ListLine(idx).JumpDelay = m_CopiedParameter.JumpDelay
                m_ListLine(idx).JumpSpeed = m_CopiedParameter.JumpSpeed
                m_ListLine(idx).LaserOffDelay = m_CopiedParameter.LaserOffDelay
                m_ListLine(idx).LaserOnDelay = m_CopiedParameter.LaserOnDelay
                m_ListLine(idx).LaserPower = m_CopiedParameter.LaserPower
                m_ListLine(idx).LaserPRR = m_CopiedParameter.LaserPRR
                m_ListLine(idx).MarkDelay = m_CopiedParameter.MarkDelay
                m_ListLine(idx).MarkSpeed = m_CopiedParameter.MarkSpeed
                m_ListLine(idx).PolygonDelay = m_CopiedParameter.PolygonDelay
                m_ListLine(idx).RepeatCount = m_CopiedParameter.RepeatCount
                If (m_CopiedParameter.RepeatMode = eRepeatModeMerge.Mode1) Then
                    m_ListLine(idx).RepeatMode = eRepeatMode.Mode1
                ElseIf (m_CopiedParameter.RepeatMode = eRepeatModeMerge.Mode2) Then
                    m_ListLine(idx).RepeatMode = eRepeatMode.Mode2
                Else
                End If
                m_LineSelected = m_ListLine(idx)
                PropertyGrid1.SelectedObject = m_LineSelected
                m_FlagSave = True
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoveUp.Click, btnMoveRight.Click, btnMoveLeft.Click, btnMoveDown.Click
        If (m_LineSelected Is Nothing) Then
            Exit Sub
        End If
        If (m_SelectedNodes IsNot Nothing AndAlso m_SelectedNodes.Count > 1) Then
            Exit Sub
        End If
        Dim btn As ButtonEx = Nothing
        Try
            btn = CType(sender, ButtonEx)
            btn.Enabled = False
            Dim distance As Double = CDbl(numMoveDistance.Value) / 1000.0

            Select Case btn.Direction
                Case eArrow.Up
                    Select Case cboChoosePointForEdit.SelectedIndex
                        Case 0 'Start point
                            m_LineSelected.StartY = m_LineSelected.StartY + distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX

                        Case 1 'End point
                            m_LineSelected.EndY = m_LineSelected.EndY + distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
                        Case 2 'All
                            'm_LineSelected.StartY = m_LineSelected.StartY + distance
                            'm_LineSelected.EndY = m_LineSelected.EndY + distance
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
                            Dim angle As Double = CalAngle(m_LineSelected.StartX, m_LineSelected.StartY, m_LineSelected.EndX, m_LineSelected.EndY)
                            Dim newSX, newSY, newEX, newEY As Double
                            NewPos(m_LineSelected.StartX, m_LineSelected.StartY, -angle, newSX, newSY)
                            NewPos(m_LineSelected.EndX, m_LineSelected.EndY, -angle, newEX, newEY)
                            If (m_LineSelected.StartX < m_LineSelected.EndX) Then
                                newSY = newSY + distance
                                newEY = newEY + distance
                            Else
                                newSY = newSY - distance
                                newEY = newEY - distance
                            End If


                            NewPos(newSX, newSY, angle, m_LineSelected.StartX, m_LineSelected.StartY)
                            NewPos(newEX, newEY, angle, m_LineSelected.EndX, m_LineSelected.EndY)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected


                        Case Else

                    End Select

                Case eArrow.Down
                    Select Case cboChoosePointForEdit.SelectedIndex
                        Case 0 'Start point
                            m_LineSelected.StartY = m_LineSelected.StartY - distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX

                        Case 1 'End point
                            m_LineSelected.EndY = m_LineSelected.EndY - distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
                        Case 2 'All
                            'm_LineSelected.StartY = m_LineSelected.StartY - distance
                            'm_LineSelected.EndY = m_LineSelected.EndY - distance
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
                            Dim angle As Double = CalAngle(m_LineSelected.StartX, m_LineSelected.StartY, m_LineSelected.EndX, m_LineSelected.EndY)
                            Dim newSX, newSY, newEX, newEY As Double
                            NewPos(m_LineSelected.StartX, m_LineSelected.StartY, -angle, newSX, newSY)
                            NewPos(m_LineSelected.EndX, m_LineSelected.EndY, -angle, newEX, newEY)
                            If (m_LineSelected.StartX < m_LineSelected.EndX) Then
                                newSY = newSY - distance
                                newEY = newEY - distance
                            Else
                                newSY = newSY + distance
                                newEY = newEY + distance
                            End If

                            NewPos(newSX, newSY, angle, m_LineSelected.StartX, m_LineSelected.StartY)
                            NewPos(newEX, newEY, angle, m_LineSelected.EndX, m_LineSelected.EndY)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                        Case Else

                    End Select
                Case eArrow.Left
                    Select Case cboChoosePointForEdit.SelectedIndex
                        Case 0 'Start point
                            m_LineSelected.StartX = m_LineSelected.StartX - distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX

                        Case 1 'End point
                            m_LineSelected.EndX = m_LineSelected.EndX - distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
                        Case 2 'All
                            'm_LineSelected.StartX = m_LineSelected.StartX - distance
                            'm_LineSelected.EndX = m_LineSelected.EndX - distance
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX

                            Dim angle As Double = CalAngle(m_LineSelected.StartX, m_LineSelected.StartY, m_LineSelected.EndX, m_LineSelected.EndY)
                            Dim newSX, newSY, newEX, newEY As Double
                            NewPos(m_LineSelected.StartX, m_LineSelected.StartY, -angle, newSX, newSY)
                            NewPos(m_LineSelected.EndX, m_LineSelected.EndY, -angle, newEX, newEY)
                            If (m_LineSelected.StartX < m_LineSelected.EndX) Then
                                newSX = newSX - distance
                                newEX = newEX - distance
                            Else
                                newSX = newSX + distance
                                newEX = newEX + distance
                            End If
                            NewPos(newSX, newSY, angle, m_LineSelected.StartX, m_LineSelected.StartY)
                            NewPos(newEX, newEY, angle, m_LineSelected.EndX, m_LineSelected.EndY)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected

                        Case Else

                    End Select
                Case eArrow.Right
                    Select Case cboChoosePointForEdit.SelectedIndex
                        Case 0 'Start point
                            m_LineSelected.StartX = m_LineSelected.StartX + distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX

                        Case 1 'End point
                            m_LineSelected.EndX = m_LineSelected.EndX + distance
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
                        Case 2 'All
                            'm_LineSelected.StartX = m_LineSelected.StartX + distance
                            'm_LineSelected.EndX = m_LineSelected.EndX + distance
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX
                            'CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
                            Dim angle As Double = CalAngle(m_LineSelected.StartX, m_LineSelected.StartY, m_LineSelected.EndX, m_LineSelected.EndY)
                            Dim newSX, newSY, newEX, newEY As Double
                            NewPos(m_LineSelected.StartX, m_LineSelected.StartY, -angle, newSX, newSY)
                            NewPos(m_LineSelected.EndX, m_LineSelected.EndY, -angle, newEX, newEY)
                            If (m_LineSelected.StartX < m_LineSelected.EndX) Then
                                newSX = newSX + distance
                                newEX = newEX + distance
                            Else
                                newSX = newSX - distance
                                newEX = newEX - distance
                            End If
                            NewPos(newSX, newSY, angle, m_LineSelected.StartX, m_LineSelected.StartY)
                            NewPos(newEX, newEY, angle, m_LineSelected.EndX, m_LineSelected.EndY)
                            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
                        Case Else

                    End Select
            End Select
            PropertyGrid1.Refresh()
        Catch ex As Exception
            FMessageBox.Show(CChangeLanguage.GetString("移動錯誤"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        If (btn IsNot Nothing) Then
            btn.Enabled = True
        End If
    End Sub


    Private Sub btnRotateCW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRotateCW.Click, btnRotateCCW.Click
        If (m_LineSelected Is Nothing) Then
            Exit Sub
        End If
        If (m_SelectedNodes IsNot Nothing AndAlso m_SelectedNodes.Count > 1) Then
            Exit Sub
        End If
        Dim btn As Button = Nothing
        Try
            btn = CType(sender, Button)
            btn.Enabled = False
            Dim angle As Double = CDbl(numRotateAngle.Value)
            Select Case btn.Name
                Case btnRotateCW.Name
                    angle = -angle
                Case btnRotateCCW.Name
                Case Else
            End Select
            Dim x, y As Double
            Dim xc As Double = (m_LineSelected.StartX + m_LineSelected.EndX) / 2
            Dim yc As Double = (m_LineSelected.StartY + m_LineSelected.EndY) / 2
            Call NewPos(0, 0, angle, xc, yc, m_LineSelected.StartX, m_LineSelected.StartY, x, y)
            m_LineSelected.StartX = x
            m_LineSelected.StartY = y
            Call NewPos(0, 0, angle, xc, yc, m_LineSelected.EndX, m_LineSelected.EndY, x, y)
            m_LineSelected.EndX = x
            m_LineSelected.EndY = y
            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartX = m_LineSelected.StartXPX
            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).StartY = m_LineSelected.StartYPX
            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndX = m_LineSelected.EndXPX
            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).EndY = m_LineSelected.EndYPX
            PropertyGrid1.Refresh()
        Catch ex As Exception
            FMessageBox.Show(CChangeLanguage.GetString("旋轉錯誤"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        If (btn IsNot Nothing) Then
            btn.Enabled = True
        End If
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        If (m_LineSelected Is Nothing) Then
            Exit Sub
        End If
        If (m_SelectedNodes IsNot Nothing AndAlso m_SelectedNodes.Count > 1) Then
            Exit Sub
        End If
        Try
            Dim angle As Double = CalAngle(m_LineSelected.StartX, m_LineSelected.StartY, m_LineSelected.EndX, m_LineSelected.EndY)
            Dim newSX, newSY, newEX, newEY As Double
            NewPos(m_LineSelected.StartX, m_LineSelected.StartY, -angle, newSX, newSY)
            NewPos(m_LineSelected.EndX, m_LineSelected.EndY, -angle, newEX, newEY)
            Select Case cboFixPoint.SelectedIndex
                Case 0 'Fixed Start
                    newSX -= (numFixDistance.Value / 1000)
                Case 1 'Fixed Center
                    newSX -= (numFixDistance.Value / 1000) / 2
                    newEX += (numFixDistance.Value / 1000) / 2
                Case 2 'Fixed End
                    newEX += (numFixDistance.Value / 1000)
                Case Else

            End Select
            NewPos(newSX, newSY, angle, m_LineSelected.StartX, m_LineSelected.StartY)
            NewPos(newEX, newEY, angle, m_LineSelected.EndX, m_LineSelected.EndY)
            CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected
            PropertyGrid1.Refresh()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If (FMessageBox.Show(Me, CChangeLanguage.GetString("您確定要刪除數據嗎？"), CChangeLanguage.GetString("警告"), MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
            btnClear.Enabled = False
            Try
                dgvImageValue.Rows.Clear()
                dgvGalvoValue.Rows.Clear()
                Dim count = CInt(cboCalibrationRange.SelectedValue)
                While dgvGalvoValue.Rows.Count <> count
                    dgvGalvoValue.Rows.Add(New Object() {dgvGalvoValue.Rows.Count + 1, 0, 0})
                End While
                While dgvImageValue.Rows.Count <> count
                    dgvImageValue.Rows.Add(New Object() {dgvImageValue.Rows.Count + 1, 0, 0})
                End While
            Catch ex As Exception
                FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            End Try
            btnClear.Enabled = True
        End If
    End Sub

    Private Sub btnKeyImageCalibration_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeyImageCalibration.Click
        Try
            Dim range As eCorrectionRange = CType(Math.Sqrt(cboCalibrationRange.SelectedItem), eCorrectionRange)
            Dim fInput As FInputCorrection = New FInputCorrection(range, dgvImageValue)
            fInput.ColumnX = 1
            fInput.ColumnY = 2
            fInput.DecimalPlace = 3
            fInput.ShowDialog()
            fInput.Close()
        Catch
        End Try
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Try
            Dim range As eCorrectionRange = CType(Math.Sqrt(cboCalibrationRange.SelectedItem), eCorrectionRange)
            Dim fInput As FInputCorrection = New FInputCorrection(range, dgvGalvoValue)
            fInput.ColumnX = 1
            fInput.ColumnY = 2
            fInput.ShowDialog()
            fInput.Close()
        Catch
        End Try
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Try
            Dim op As OpenFileDialog = New OpenFileDialog()
            op.Filter = "Data file|*.dat"
            op.Multiselect = False
            If (op.ShowDialog = Windows.Forms.DialogResult.OK) Then
                Dim lines() As String = System.IO.File.ReadAllLines(op.FileName)
                dgvGalvoValue.Rows.Clear()
                For index = 10 To lines.Length - 1
                    Dim idx As Integer = lines(index).IndexOf("  ")
                    While idx >= 0
                        lines(index) = lines(index).Replace("  ", " ")
                        idx = lines(index).IndexOf("  ")
                    End While
                    lines(index) = lines(index).Trim()
                    Dim tmp() As String = lines(index).Split(" "c)
                    If (tmp.Length = 4) Then
                        dgvGalvoValue.Rows.Add(New Object() {dgvGalvoValue.Rows.Count + 1, tmp(0).Replace("+", ""), tmp(1).Replace("+", ""), tmp(2).Replace("+", ""), tmp(3).Replace("+", "")})
                    Else
                        Dim xxx = 0
                    End If
                Next

            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub dgvImageValue_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvImageValue.Scroll
        Try
            dgvGalvoValue.FirstDisplayedScrollingRowIndex = dgvImageValue.FirstDisplayedScrollingRowIndex
        Catch
        End Try
    End Sub

    Private Sub dgvGalvoValue_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles dgvGalvoValue.Scroll
        Try
            dgvImageValue.FirstDisplayedScrollingRowIndex = dgvGalvoValue.FirstDisplayedScrollingRowIndex
        Catch
        End Try
    End Sub


    Private Sub dgvGalvoValue_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGalvoValue.CellClick
        Try
            If (e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0) Then
                dgvImageValue.ClearSelection()
                dgvImageValue.Rows(e.RowIndex).Selected = True
                dgvImageValue.Rows(e.RowIndex).Cells(0).Selected = True
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvImageValue_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvImageValue.CellClick
        Try
            If (e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0) Then
                dgvGalvoValue.ClearSelection()
                dgvGalvoValue.Rows(e.RowIndex).Selected = True
                dgvGalvoValue.Rows(e.RowIndex).Cells(0).Selected = True
            End If
        Catch
        End Try
    End Sub


    Private Sub dgvImageValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvImageValue.KeyDown
        Try
            Dim ctrl As Boolean = ModifierKeys = Keys.Control
            If (ctrl = True AndAlso e.KeyData = Keys.C) Then
                Clipboard.SetText(dgvImageValue.CurrentCell.Value.ToString())
            End If
        Catch
        End Try
    End Sub

    Private Sub dgvGalvoValue_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgvGalvoValue.KeyDown
        Try
            Dim ctrl As Boolean = ModifierKeys = Keys.Control
            If (ctrl = True AndAlso e.KeyData = Keys.C) Then
                Clipboard.SetText(dgvGalvoValue.CurrentCell.Value.ToString())
            End If
        Catch
        End Try
    End Sub

    Private Sub btnMarkAxis_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMarkAxis.Click
        btnMarkAxis.Enabled = False
        Try
            Call m_Laser.setstartlist(1)

            If (m_Corection.LaserOn) Then
                m_Laser.LaserGuide = False
                m_Laser.LaserEmission = True
                Thread.Sleep(3000)
                With m_Laser
                    .OperatingPower = m_Corection.Power
                    .PRR = m_Corection.PRR
                End With
            Else
                m_Laser.LaserGuide = True
                m_Laser.LaserEmission = False
            End If
            Call m_Laser.setScannerDelays(m_Corection.JumpDelay, m_Corection.MarkDelay, m_Corection.PolygonDelay)
            Call m_Laser.SetLaserDelays(m_Corection.LaserOnDelay, m_Corection.LaserOffDelay)
            Call m_Laser.SetJumpSpeed(m_Corection.JumpSpeed)
            Call m_Laser.SetMarkSpeed(m_Corection.MarkSpeed)


            Dim offsetX As Integer = 0
            Dim offsetY As Integer = 0
            Dim axisLength As Integer = 5000 'um
            Dim arrowLength As Integer = 500
            Dim arrowSize As Integer = 600 / 2
            Dim characterSpacing As Integer = 100
            Dim characterW As Integer = 400
            Dim characterH As Integer = 600
            If (System.IO.File.Exists(FMarkAxisParam.MARK_AXIS_PARAM_PATH)) Then
                Dim lines() As String = System.IO.File.ReadAllLines(FMarkAxisParam.MARK_AXIS_PARAM_PATH)
                For idx = 0 To lines.Length - 1
                    Dim value As Integer = 0
                    Select Case idx
                        Case 0
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (-65535 <= value AndAlso value <= 65535) Then
                                    offsetX = value
                                End If
                            End If
                        Case 1
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (-65535 <= value AndAlso value <= 65535) Then
                                    offsetY = value
                                End If
                            End If
                        Case 2
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    axisLength = value
                                End If
                            End If
                        Case 3
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    arrowLength = value
                                End If
                            End If
                        Case 4
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    arrowSize = value / 2
                                End If
                            End If
                        Case 5
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterSpacing = value
                                End If
                            End If
                        Case 6
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterH = value
                                End If
                            End If
                        Case 7
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterW = value
                                End If
                            End If
                    End Select
                Next

            End If

            'X axis 
            Call m_Laser.JumpAbs(offsetX * m_Corection.KFactor / 1000, offsetY * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs((axisLength + offsetX) * m_Corection.KFactor / 1000, offsetY * m_Corection.KFactor / 1000) '-

            Call m_Laser.JumpAbs((axisLength - arrowLength + offsetX) * m_Corection.KFactor / 1000, (arrowSize + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs((axisLength + offsetX) * m_Corection.KFactor / 1000, offsetY * m_Corection.KFactor / 1000) '\

            Call m_Laser.JumpAbs((axisLength - arrowLength + offsetX) * m_Corection.KFactor / 1000, (-arrowSize + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs((axisLength + offsetX) * m_Corection.KFactor / 1000, offsetY * m_Corection.KFactor / 1000) '/

            'X character
            Call m_Laser.JumpAbs((axisLength + characterSpacing + offsetX) * m_Corection.KFactor / 1000, (characterH / 2 + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs((axisLength + characterW + characterSpacing + offsetX) * m_Corection.KFactor / 1000, (-characterH / 2 + offsetY) * m_Corection.KFactor / 1000) '/

            Call m_Laser.JumpAbs((axisLength + characterSpacing + offsetX) * m_Corection.KFactor / 1000, (-characterH / 2 + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs((axisLength + characterW + characterSpacing + offsetX) * m_Corection.KFactor / 1000, (characterH / 2 + offsetY) * m_Corection.KFactor / 1000) '\

            'Y axis 
            Call m_Laser.JumpAbs(offsetX * m_Corection.KFactor / 1000, offsetY * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, (axisLength + offsetY) * m_Corection.KFactor / 1000) '-

            Call m_Laser.JumpAbs((-arrowSize + offsetX) * m_Corection.KFactor / 1000, (axisLength - arrowLength + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, axisLength * m_Corection.KFactor / 1000) '/

            Call m_Laser.JumpAbs((arrowSize + offsetX) * m_Corection.KFactor / 1000, (axisLength - arrowLength + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, axisLength * m_Corection.KFactor / 1000) '\

            'Y character
            Call m_Laser.JumpAbs((-characterW / 2 + offsetX) * m_Corection.KFactor / 1000, (axisLength + characterH + characterSpacing + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, (axisLength + characterH / 2 + characterSpacing + offsetY) * m_Corection.KFactor / 1000) '\

            Call m_Laser.JumpAbs((characterW / 2 + offsetX) * m_Corection.KFactor / 1000, (axisLength + characterH + characterSpacing + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, (axisLength + characterH / 2 + characterSpacing + offsetY) * m_Corection.KFactor / 1000) '/

            Call m_Laser.JumpAbs(offsetX * m_Corection.KFactor / 1000, (axisLength + characterSpacing + offsetY) * m_Corection.KFactor / 1000)
            Call m_Laser.MarkAbs(offsetX * m_Corection.KFactor / 1000, (axisLength + characterH / 2 + characterSpacing + offsetY) * m_Corection.KFactor / 1000) '|

            Call m_Laser.SetEndofList()
            Call m_Laser.ExecuteList(1)
            Do
                Application.DoEvents()
            Loop Until m_Laser.ListExecutionFinish = True
        Catch ex As Exception

        End Try
        btnMarkAxis.Enabled = True
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Me.Visible = False
        Try
            Dim f As FMarkAxisParam = New FMarkAxisParam()
            f.ShowDialog()
            f.Dispose()
            f = Nothing
        Catch ex As Exception

        End Try
        Me.Visible = True
    End Sub

    Private Sub numImageOffsetX_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numImageOffsetX.ValueChanged
        Try
            m_Cross.X = VisionImageWidth / 2.0 + numImageOffsetX.Value
            'm_Cross.Y = VisionImageHeight / 2.0 + m_Param.Variable.Graphic.OffsetY
            'm_Cross.Length = 1000
            Call Me.ImageDisplay1.StaticGraphics.Clear()
            Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
        Catch
        End Try
    End Sub

    Private Sub numImageOffsetY_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numImageOffsetY.ValueChanged
        Try
            ' m_Cross.X = VisionImageWidth / 2.0 + numImageOffsetX.Value
            m_Cross.Y = VisionImageHeight / 2.0 + numImageOffsetY.Value
            'm_Cross.Length = 1000
            Call Me.ImageDisplay1.StaticGraphics.Clear()
            Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
        Catch
        End Try
    End Sub

    Private Sub chkPickPoint_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPickPoint.CheckedChanged, chkPickY.CheckedChanged
        Try
            If (chkPickPoint.Checked = True OrElse chkPickY.Checked = True) Then
                ImageDisplay1.Cursor = Cursors.Cross
            Else
                ImageDisplay1.Cursor = Cursors.Default
            End If
        Catch
        End Try
    End Sub

    Private Sub cboCalibrationRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCalibrationRange.SelectedIndexChanged
        Try
            Dim count = CInt(cboCalibrationRange.SelectedItem)
            If (dgvImageValue.Rows.Count < count) Then
                While (dgvImageValue.Rows.Count <> count)
                    dgvImageValue.Rows.Add(New Object() {dgvImageValue.Rows.Count + 1, 0, 0})
                End While
            ElseIf (dgvImageValue.Rows.Count > count) Then
                While (dgvImageValue.Rows.Count <> count)
                    dgvImageValue.Rows.RemoveAt(dgvImageValue.Rows.Count - 1)
                End While
            End If
            If (dgvGalvoValue.Rows.Count < count) Then
                While (dgvGalvoValue.Rows.Count <> count)
                    dgvGalvoValue.Rows.Add(New Object() {dgvGalvoValue.Rows.Count + 1, 0, 0, 0, 0})
                End While
            ElseIf (dgvGalvoValue.Rows.Count > count) Then
                While (dgvGalvoValue.Rows.Count <> count)
                    dgvGalvoValue.Rows.RemoveAt(dgvGalvoValue.Rows.Count - 1)
                End While
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub ptb204Output_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ptb204Out17.Click, ptb204Out16.Click, ptb204Out15.Click, ptb204Out14.Click, ptb204Out13.Click, ptb204Out12.Click, ptb204Out11.Click, ptb204Out10.Click, ptb204Out23.Click, ptb204Out22.Click, ptb204Out21.Click, ptb204Out20.Click, ptb204Out19.Click, ptb204Out18.Click, ptb204Out9.Click, ptb204Out8.Click
        Try
            Dim ptb As PictureBoxEx = CType(sender, PictureBoxEx)
            Dim bit As Integer = CInt(ptb.Tag)
            If m_DA.DigO.Status(bit) = enumCyllogic.Action Then
                Call m_DA.DigO.CylGo(bit, enumCyllogic.Normal)
                'lblStatus(i).BackColor = Color.Lime
            Else
                Call m_DA.DigO.CylGo(bit, enumCyllogic.Action)
                'lblStatus(i).BackColor = Color.Red
            End If
        Catch ex As Exception
            Call MsgBox(ex.Message(), MsgBoxStyle.Information, "Run-Time Error")
        End Try
    End Sub


    Private Sub MoveToPositionToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoveToPositionToolStripMenuItem.Click
        Try
            If (m_Param.Flags.System.SysInitHomeOk = True) Then
                If (m_SelectedStep = 1) Then
                    btnWorkholderMove_Click(btnWorkholderMove1, Nothing)
                ElseIf (m_SelectedStep = 2) Then
                    btnWorkholderMove_Click(btnWorkholderMove2, Nothing)
                End If
            Else
                FMessageBox.Show(Me, CChangeLanguage.GetString("請先復歸位置!"), CChangeLanguage.GetString("警告"), MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private m_CalibrationMatchingTool As VisionSystem.CMatchingTool
    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        Try
            Dim pMatchingToolPath = "D:\DataSettings\LaserMachine\Machine\Calibration"
            If System.IO.Directory.Exists(pMatchingToolPath) = True Then
                m_CalibrationMatchingTool = New VisionSystem.CMatchingTool(pMatchingToolPath)
                Call m_CalibrationMatchingTool.ReadFiles()
                Call m_CalibrationMatchingTool.Pattern.Train()
                Button1.Enabled = True
                Button11.Enabled = True
            Else
                FMessageBox.Show("D:\DataSettings\LaserMachine\Machine\Calibration no exist", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If

        Catch
        End Try
    End Sub
    Private m_CalibrationStart As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If m_CalibrationStart = False Then
            Button1.Text = CChangeLanguage.GetString("結束")

            Try
                Dim img As CImage
                If m_ROIRec Is Nothing Then m_ROIRec = New ROIRectangle1
                img = New CImage
                Call Me.ImageDisplay1.StopLive()
                Call m_Acquist.Acquist(0, True)
                Call m_Acquist.CopyTo(0, img)

                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call Me.ImageDisplay1.CopyOf(img)

                Call Me.ImageDisplay1.InteractiveGraphics.Add1(m_ROIRec)

            Catch ex As Exception
                FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
            End Try
            m_CalibrationStart = True
        Else
            Button1.Text = CChangeLanguage.GetString("開始")
            Dim rectangle As CRectangle
            m_FLoading = New FLoading(CChangeLanguage.GetString("訓練中...."))
            m_FLoading.Show()
            m_FLoading.Percent = 10
            Dim img As CImage
            Try
                rectangle = New CRectangle
                img = New CImage
                Call Me.ImageDisplay1.StopLive()
                Call m_Acquist.Acquist(0, True)
                Call m_Acquist.CopyTo(0, img)
                Me.ImageDisplay1.CopyOf(img)
                Call Me.ImageDisplay1.StaticGraphics.Clear()
                Call rectangle.SetCenterLengthsRotation(m_ROIRec.midC, m_ROIRec.midR, (m_ROIRec.col2 - m_ROIRec.col1), (m_ROIRec.row2 - m_ROIRec.row1), 0)
                Dim pMatchingToolPath As String = "D:\DataSettings\LaserMachine\Machine\Calibration" 'CProject.PROJECT_PATH & m_CurrentProject.ProjectName & "\Image" & "\WorkStep" & numWorkStep.Value
                m_FLoading.Percent = 30
                If m_CalibrationMatchingTool Is Nothing Then m_CalibrationMatchingTool = New CMatchingTool(pMatchingToolPath)

                Try
                    If System.IO.Directory.Exists(pMatchingToolPath) = False Then
                        My.Computer.FileSystem.CopyDirectory("D:\DataSettings\LaserMachine\MachineData\Reserve", pMatchingToolPath, True)
                    End If
                Catch ex As Exception

                End Try

                Call m_CalibrationMatchingTool.InputImage.CopyOf(img)
                Call m_CalibrationMatchingTool.Pattern.SetRotaryRange(-10, 10)

                Call m_CalibrationMatchingTool.Pattern.TrainImage.CopyOf(img)
                m_CalibrationMatchingTool.Pattern.TrainRegion = rectangle
                Call m_CalibrationMatchingTool.Pattern.Train()
                m_FLoading.Percent = 50
                Call m_CalibrationMatchingTool.RunParams.SetScoreProperty(0, NumericUpDown2.Value)

                Call m_CalibrationMatchingTool.SaveFiles()

                Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                Call Me.ImageDisplay1.StartLive(0, m_Acquist)
                m_CalibrationStart = False
                rectangle.Dispose()
                rectangle = Nothing
                Call Me.ImageDisplay1.InteractiveGraphics.Clear()
                m_FLoading.Percent = 75
            Catch ex As Exception
            End Try
            m_CalibrationStart = False
            EnableVision(True, btnAlignSetStart)
            m_FLoading.Percent = 100
            m_FLoading.Close()
            m_FLoading.Dispose()
            m_FLoading = Nothing
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        Dim searchRegion As CRectangle
        Dim img As CImage
        Try
            Button11.Enabled = False
            btnVisionRightTest.Enabled = False
            EnableVision(False, btnVisionRightTest)
            Call Me.ImageDisplay1.StopLive()
            Call m_Acquist.Acquist(0, True)
            img = New CImage
            m_Acquist.CopyTo(0, img)
            Call m_CalibrationMatchingTool.RunParams.SetScoreProperty(0, NumericUpDown2.Value)

            searchRegion = New CRectangle
            Me.ImageDisplay1.StaticGraphics.Clear()
            Me.ImageDisplay1.CopyOf(img)
            Call searchRegion.SetCenterLengthsRotation(img.Width / 2, img.Height / 2, img.Width, img.Height, 0)
            m_CalibrationMatchingTool.SearchRegion = searchRegion

            m_CalibrationMatchingTool.RunParams.RotaryEnabled = True
            m_CalibrationMatchingTool.RunParams.ApproximateNumberToFind = numAutoCalibrationNumpoint.Value
            m_CalibrationMatchingTool.RunParams.RunType = 1
            m_CalibrationMatchingTool.RunParams.SetRotaryRange(-5, 5)
            m_CalibrationMatchingTool.InputImage.CopyOf(img)
            m_CalibrationMatchingTool.Run(True, EnumMatchShape.None)
            DataGridView1.Rows.Clear()
            If m_CalibrationMatchingTool.Results.Count > 0 Then
                Call Me.ImageDisplay1.StaticGraphics.Clear()

                Call Me.ImageDisplay1.StaticGraphics.Add(m_Cross)
                Call Me.ImageDisplay1.StaticGraphics.Add(m_CalibrationMatchingTool.Results.GetGraphics(CType(enumMatchingToolResultGraphicConstants.MatchFeatures + enumMatchingToolResultGraphicConstants.MatchRegion, enumMatchingToolResultGraphicConstants)))

                Dim listPoint As New List(Of PointF)

                For i = 0 To m_CalibrationMatchingTool.Results.Count - 1
                    Dim x As Double = (m_CalibrationMatchingTool.Results.Item(i).TranslationX) '- img.Width / 2)
                    Dim y As Double = ((m_CalibrationMatchingTool.Results.Item(i).TranslationY)) '- img.Height / 2))
                    listPoint.Add(New PointF(x, y))
                Next
                listPoint = (From p As PointF In listPoint
                            Order By p.X Ascending, p.Y Descending).ToList()

                Dim count As Integer = CInt(cboAutoCalibrationRange.SelectedItem)
                For i = 0 To listPoint.Count - 1 Step count
                    For j = i To i + count - 1 Step 1
                        For k = j To i + count - 1 Step 1
                            If (listPoint(k).Y > listPoint(j).Y) Then
                                Dim tmp As PointF = listPoint(k)
                                listPoint(k) = listPoint(j)
                                listPoint(j) = tmp
                            End If
                        Next
                    Next
                Next

                For i = 0 To listPoint.Count - 1
                    DataGridView1.Rows.Add(New Object() {i + 1, listPoint(i).X, listPoint(i).Y})
                Next
                listPoint.Clear()
            Else
                FMessageBox.Show("Not found !!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
            lblFoundNumpoint.Text = m_CalibrationMatchingTool.Results.Count.ToString()
            If (m_CalibrationMatchingTool.Results.Count = numAutoCalibrationNumpoint.Value) Then
                lblFoundNumpoint.ForeColor = Color.Green
            Else
                lblFoundNumpoint.ForeColor = Color.Red
            End If
            searchRegion.Dispose()
            Call img.Dispose() : img = Nothing
            Me.ImageDisplay1.StartLive(0, m_Acquist)
            Call m_CalibrationMatchingTool.SaveFiles()
            Call Me.ImageDisplay1.StartLive(0, m_Acquist)
        Catch ex As Exception

        Finally
            Button11.Enabled = True
        End Try
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        btnSaveCalibration.Enabled = False
        Try
            Dim strImage(DataGridView1.Rows.Count - 2) As String
            Dim strGalvo(DataGridView1.Rows.Count - 1) As String
            For idx = 0 To strImage.Length - 1
                strImage(idx) = DataGridView1.Rows(idx).Cells(1).Value.ToString() & "," & DataGridView1.Rows(idx).Cells(2).Value.ToString()
                strGalvo(idx) = DataGridView2.Rows(idx).Cells(1).Value.ToString() & "," & DataGridView2.Rows(idx).Cells(2).Value.ToString()
            Next
            System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\Machine\Parameter\VisionPickCalibration.txt", strImage)
            System.IO.File.WriteAllLines("D:\DataSettings\LaserMachine\Machine\Parameter\GalvoPickCalibration.txt", strGalvo)
            ImagePointsInit("D:\DataSettings\LaserMachine\Machine\Parameter")
            FMessageBox.Show(Me, CChangeLanguage.GetString("已保存 !"), CChangeLanguage.GetString("信息"), MessageBoxButtons.OK, MessageBoxIcon.OK)
        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        btnSaveCalibration.Enabled = True
    End Sub

    Private Sub cboAutoCalibrationRange_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAutoCalibrationRange.SelectedIndexChanged
        Try
            numAutoCalibrationNumpoint.Value = cboAutoCalibrationRange.SelectedItem * cboAutoCalibrationRange.SelectedItem
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAutoCalibrationStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoCalibrationStop.Click
        Try
            m_Laser.StopExecute()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAutoCalibrationMark_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoCalibrationMark.Click
        btnAutoCalibrationMark.Enabled = False
        Try
            Dim startIdx As Integer = -(cboAutoCalibrationRange.SelectedItem + 1) / 2
            Dim endIdx As Integer = (cboAutoCalibrationRange.SelectedItem + 1) / 2
            Dim pX, pY As Integer

            m_Laser.PRR = m_Corection.PRR
            m_Laser.OperatingPower = m_Corection.Power
            m_Laser.LaserGuide = False
            Threading.Thread.Sleep(100)
            m_Laser.LaserEmission = True
            Threading.Thread.Sleep(3000)

            Call m_Laser.setstartlist(1)
            Call m_Laser.setScannerDelays(m_Corection.JumpDelay, m_Corection.MarkDelay, m_Corection.PolygonDelay)
            Call m_Laser.SetLaserDelays(m_Corection.LaserOnDelay, m_Corection.LaserOffDelay)
            Call m_Laser.SetJumpSpeed(m_Corection.JumpSpeed)
            Call m_Laser.SetMarkSpeed(m_Corection.MarkSpeed)
            Call m_Laser.JumpAbs(0, 0)

            'Draw Line X
            For y = startIdx + 1 To endIdx - 1 Step 1
                pY = y * m_Corection.Size * m_Corection.KFactor / 1000.0
                pX = startIdx * m_Corection.Size * m_Corection.KFactor / 1000.0
                Call m_Laser.JumpAbs(pX, pY)
                pX = endIdx * m_Corection.Size * m_Corection.KFactor / 1000.0
                Call m_Laser.MarkAbs(pX, pY)
            Next

            'Draw Line Y
            For x = startIdx + 1 To endIdx - 1 Step 1
                pX = x * m_Corection.Size * m_Corection.KFactor / 1000
                pY = startIdx * m_Corection.Size * m_Corection.KFactor / 1000
                Call m_Laser.JumpAbs(pX, pY)
                pY = endIdx * m_Corection.Size * m_Corection.KFactor / 1000
                Call m_Laser.MarkAbs(pX, pY)
            Next

            Call m_Laser.SetEndofList()

            m_Laser.ExecuteList(1)
            Do
                Application.DoEvents()
            Loop Until m_Laser.ListExecutionFinish = True

        Catch
        End Try
        btnAutoCalibrationMark.Enabled = True
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Try
            Dim range As eCorrectionRange = cboAutoCalibrationRange.SelectedItem
            Dim fInput As FInputCorrection = New FInputCorrection(range, DataGridView2)
            fInput.ColumnX = 1
            fInput.ColumnY = 2
            fInput.ShowDialog()
            fInput.Close()
        Catch
        End Try
    End Sub

    Private Sub DataGridView1_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView1.Scroll
        Try
            DataGridView2.FirstDisplayedScrollingRowIndex = DataGridView1.FirstDisplayedScrollingRowIndex
        Catch
        End Try
    End Sub

    Private Sub DataGridView2_Scroll(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles DataGridView2.Scroll
        Try
            DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView2.FirstDisplayedScrollingRowIndex
        Catch
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            If (e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0) Then
                DataGridView2.ClearSelection()
                DataGridView2.Rows(e.RowIndex).Selected = True
                DataGridView2.Rows(e.RowIndex).Cells(0).Selected = True
            End If
        Catch
        End Try
    End Sub

    Private Sub DataGridView2_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellClick
        Try
            If (e.RowIndex >= 0 AndAlso e.ColumnIndex >= 0) Then
                DataGridView1.ClearSelection()
                DataGridView1.Rows(e.RowIndex).Selected = True
                DataGridView1.Rows(e.RowIndex).Cells(0).Selected = True
            End If
        Catch
        End Try
    End Sub


    Private Sub DataGridView1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView1.KeyDown
        Try
            Dim ctrl As Boolean = ModifierKeys = Keys.Control
            If (ctrl = True AndAlso e.KeyData = Keys.C) Then
                Clipboard.SetText(DataGridView1.CurrentCell.Value.ToString())
            End If
        Catch
        End Try
    End Sub

    Private Sub DataGridView2_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles DataGridView2.KeyDown
        Try
            Dim ctrl As Boolean = ModifierKeys = Keys.Control
            If (ctrl = True AndAlso e.KeyData = Keys.C) Then
                Clipboard.SetText(DataGridView2.CurrentCell.Value.ToString())
            End If
        Catch
        End Try
    End Sub

    Private m_WorkOK As Boolean = False
    Private m_WorkComplete As Boolean = False
    Private Sub dgvWorkStepByStep_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvWorkStepByStep.CellDoubleClick
        Me.Enabled = False
        Label25.Visible = True
        Try
            Dim workIdx As Integer = e.RowIndex + 1
            Select Case workIdx
                Case 1 'In
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove0, Nothing) 'Move to in position
                    Do
                    Loop Until m_WorkComplete = True
                Case 2 'Blow 1
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove5, Nothing) 'Move to blow 1 position
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder8, Nothing) 'Turn on blow 1
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    Dim startTime As Double = m_Timer.GetMilliseconds
                    Do
                    Loop Until m_Timer.GetMilliseconds - startTime >= m_Param.Variable.IO.Blow1Delay
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder9, Nothing) 'Turn off blow 1
                    Do
                    Loop Until m_WorkComplete = True
                Case 3 ' Punch
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove4, Nothing) 'Move to punch position
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder6, Nothing) 'Punch down
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder12, Nothing) 'Turn on workholder vaccum
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder7, Nothing)  'Punch up
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                Case 4 'Cut 1
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove1, Nothing) 'Move to cut 1 position
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If
                    If (m_Param.Variable.IO.UseBlow2 = True) Then
                        m_WorkOK = False
                        m_WorkComplete = False
                        btnCyl_Click(btnCylinder10, Nothing) 'Turn on blow 2
                        Do
                        Loop Until m_WorkComplete = True
                        If (m_WorkOK = False) Then
                            Exit Try
                        End If
                    End If

                    m_SelectedStep = 1
                    m_LineSelected = Nothing
                    m_WorkOK = False

                    m_WorkComplete = False
                    DrawSelectingWorkStep()
                    Do
                    Loop Until m_WorkComplete = True

                Case 5 'Cut 2
                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove2, Nothing) 'Move to cut 2 position
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_SelectedStep = 2
                    m_LineSelected = Nothing
                    m_WorkOK = False

                    m_WorkComplete = False
                    DrawSelectingWorkStep()
                    Do
                    Loop Until m_WorkComplete = True

                Case 6 'Out
                    If (m_Param.Variable.IO.UseBlow2 = True) Then
                        m_WorkOK = False
                        m_WorkComplete = False
                        btnCyl_Click(btnCylinder11, Nothing) 'Turn off blow 2
                        Do
                        Loop Until m_WorkComplete = True
                        If (m_WorkOK = False) Then
                            Exit Try
                        End If
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnWorkholderMove_Click(btnWorkholderMove3, Nothing) 'Move to out position
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder1, Nothing) 'Move out substrate to up
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder2, Nothing) 'Move out substrate to left
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder0, Nothing) 'Move out substrate to down
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder4, Nothing) 'Turn on Magnet
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder13, Nothing) 'Turn off workholder Vaccum
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder1, Nothing) 'Move out substrate to up
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder3, Nothing) 'Move out substrate to right
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder0, Nothing) 'Move out substrate to down
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder5, Nothing) 'Turn off Magnet
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

                    m_WorkOK = False
                    m_WorkComplete = False
                    btnCyl_Click(btnCylinder1, Nothing) 'Move out substrate to up
                    Do
                    Loop Until m_WorkComplete = True
                    If (m_WorkOK = False) Then
                        Exit Try
                    End If

            End Select
        Catch ex As Exception
        End Try
        Label25.Visible = False
        Me.Enabled = True
    End Sub

    Private Sub ToolStripMenuLog_Click(sender As System.Object, e As System.EventArgs) Handles ToolStripMenuLog.Click
        Me.Visible = False
        Try
            Dim f As FLog = New FLog()
            f.ShowDialog(Me)
        Catch
        End Try
        Me.Visible = True
    End Sub

    Private Sub btnSort_Click(sender As System.Object, e As System.EventArgs) Handles btnSort.Click
        Try
            If (DataGridView1.Rows.Count > 1) Then
                Dim listPoint As New List(Of PointF)
                For i = 0 To DataGridView1.Rows.Count - 2
                    listPoint.Add(New PointF(CSng(DataGridView1.Rows(i).Cells(1).Value), CSng(DataGridView1.Rows(i).Cells(2).Value)))
                Next
                listPoint = (From p As PointF In listPoint
                            Order By p.X Ascending, p.Y Descending).ToList()

                Dim count As Integer = CInt(cboAutoCalibrationRange.SelectedItem)
                For i = 0 To listPoint.Count - 1 Step count
                    For j = i To i + count - 1 Step 1
                        For k = j To i + count - 1 Step 1
                            If (listPoint(k).Y > listPoint(j).Y) Then
                                Dim tmp As PointF = listPoint(k)
                                listPoint(k) = listPoint(j)
                                listPoint(j) = tmp
                            End If
                        Next
                    Next
                Next

                DataGridView1.Rows.Clear()
                For i = 0 To listPoint.Count - 1
                    DataGridView1.Rows.Add(New Object() {i + 1, listPoint(i).X, listPoint(i).Y})
                Next
                listPoint.Clear()
            End If
            If (DataGridView2.Rows.Count > 0) Then
                Dim listPoint As New List(Of PointF)
                For i = 0 To DataGridView2.Rows.Count - 1
                    listPoint.Add(New PointF(CSng(DataGridView2.Rows(i).Cells(1).Value), CSng(DataGridView2.Rows(i).Cells(2).Value)))
                Next
                listPoint = (From p As PointF In listPoint
                            Order By p.X Ascending, p.Y Descending).ToList()
                DataGridView2.Rows.Clear()
                For i = 0 To listPoint.Count - 1
                    DataGridView2.Rows.Add(New Object() {i + 1, listPoint(i).X, listPoint(i).Y})
                Next
                listPoint.Clear()
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub numOffsetX_ValueChanged(sender As System.Object, e As System.EventArgs) Handles numOffsetX.ValueChanged, numOffsetY.ValueChanged
        Try
            If (m_LineSelected IsNot Nothing) Then
                Dim oldGridXInCamPose(m_GridXInCamPose.Length - 1) As Double
                Dim oldGridYInCamPose(m_GridYInCamPose.Length - 1) As Double
                Array.Copy(m_GridXInCamPose, oldGridXInCamPose, m_GridXInCamPose.Length)
                Array.Copy(m_GridYInCamPose, oldGridYInCamPose, m_GridYInCamPose.Length)
                ReDim m_GridXInCamPose(DataGridView1.Rows.Count - 1)
                ReDim m_GridYInCamPose(DataGridView1.Rows.Count - 1)
                For i = 0 To DataGridView1.Rows.Count - 2
                    m_GridXInCamPose(i) = CDbl(DataGridView1.Rows(i).Cells(1).Value) + numOffsetX.Value
                    m_GridYInCamPose(i) = CDbl(DataGridView1.Rows(i).Cells(2).Value) + numOffsetY.Value
                Next

                m_LineSelected.Refresh()
                CType(grbCamera.Controls(m_LineSelected.ID), CLineCtrl).Line = m_LineSelected

                ReDim m_GridXInCamPose(oldGridXInCamPose.Length - 1)
                ReDim m_GridYInCamPose(oldGridYInCamPose.Length - 1)
                Array.Copy(oldGridXInCamPose, m_GridXInCamPose, oldGridXInCamPose.Length)
                Array.Copy(oldGridYInCamPose, m_GridYInCamPose, oldGridYInCamPose.Length)
                ReDim oldGridXInCamPose(-1)
                ReDim oldGridYInCamPose(-1)
                'm_LineSelected.Refresh()

                Dim x = 0
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnMarkLineAutoCalibration_Click(sender As System.Object, e As System.EventArgs) Handles btnMarkLineAutoCalibration.Click
        Try
            If (m_LineSelected IsNot Nothing) Then
                Dim lineCenterXInGalvo As Double = 0
                Dim lineCenterYInGalvo As Double = 0
                Dim newX1InGalvo As Double = 0
                Dim newY1InGalvo As Double = 0
                Dim newX2InGalvo As Double = 0
                Dim newY2InGalvo As Double = 0
                Dim offsetXInGalvo As Double = 0
                Dim offsetYInGalvo As Double = 0
                Dim angleInGalvo As Double = 0
                 
                newX1InGalvo = m_LineSelected.StartX
                newY1InGalvo = m_LineSelected.StartY
                newX2InGalvo = m_LineSelected.EndX
                newY2InGalvo = m_LineSelected.EndY
                 
                If (CheckRTCOutRange(newX1InGalvo, newY1InGalvo) = True) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If
                If (CheckRTCOutRange(newX2InGalvo, newY2InGalvo) = True) Then
                    FMessageBox.Show(Me, CChangeLanguage.GetString(m_LineSelected.ToString()) & CChangeLanguage.GetString("輸出範圍"), CChangeLanguage.GetString("錯誤"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Try
                End If

                Call m_Laser.setstartlist(1)
                Call m_Laser.setScannerDelays(m_LineSelected.JumpDelay, m_LineSelected.MarkDelay, m_LineSelected.PolygonDelay)
                Call m_Laser.SetLaserDelays(m_LineSelected.LaserOnDelay, m_LineSelected.LaserOffDelay)
                Call m_Laser.SetJumpSpeed(m_LineSelected.JumpSpeed)
                Call m_Laser.SetMarkSpeed(m_LineSelected.MarkSpeed)

                If (m_LineSelected.RepeatMode = eRepeatMode.Mode1) Then
                    For i = 1 To m_LineSelected.RepeatCount
                        Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                        Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                    Next
                Else
                    Call m_Laser.JumpAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                    For i = 1 To m_LineSelected.RepeatCount
                        If (i Mod 2 = 0) Then
                            Call m_Laser.MarkAbs(CInt(newX1InGalvo * 1000), CInt(newY1InGalvo * 1000))
                        Else
                            Call m_Laser.MarkAbs(CInt(newX2InGalvo * 1000), CInt(newY2InGalvo * 1000))
                        End If
                    Next
                End If
                Call m_Laser.SetEndofList()
                Call m_Laser.ExecuteList(1)
                InvokeButtonText(CChangeLanguage.GetString("停止"), btnDrawSelecting)
                InvokeButton(True, btnDrawSelecting)
                Do

                Loop Until m_Laser.ListExecutionFinish = True

                 

            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        Try
            For i = 0 To DataGridView1.Rows.Count - 2
                DataGridView1.Rows(i).Cells(1).Value += numOffsetX.Value
                DataGridView1.Rows(i).Cells(2).Value -= numOffsetY.Value
            Next
        Catch ex As Exception

        End Try
        

    End Sub
End Class
