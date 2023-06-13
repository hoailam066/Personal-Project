Public Class FMotionSts
    Private m_Motion As CMotion
    Private m_AxisID As Integer
    Public Sub New(ByVal AxisID As Integer, ByRef pMotion As CMotion)
        If m_Motion Is Nothing Then m_Motion = pMotion
        m_AxisID = AxisID
        ' 此為設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Call m_Motion.ChkStatus(m_AxisID)
        Me.lblMotionSts.BackColor = IIf(m_Motion.Status(m_AxisID).MovementIsFinished = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblMotionSts.Text = m_Motion.Status(m_AxisID).MotionSts
        Me.lblAlarmSignal.BackColor = IIf(m_Motion.IO(m_AxisID).AlarmSignal = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblClearSignal.BackColor = IIf(m_Motion.IO(m_AxisID).ClearSignal = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblDIROutput.BackColor = IIf(m_Motion.IO(m_AxisID).DIROutput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblEMGStatus.BackColor = IIf(m_Motion.IO(m_AxisID).EMGStatus = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblERCPinOutput.BackColor = IIf(m_Motion.IO(m_AxisID).ERCOutput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblIndexSignal.BackColor = IIf(m_Motion.IO(m_AxisID).IndexSignal = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblInPositionSignalInput.BackColor = IIf(m_Motion.IO(m_AxisID).InPositionSignalInput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblLatchSignalInput.BackColor = IIf(m_Motion.IO(m_AxisID).LatchSignalInput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblNegativeLimitSwitch.BackColor = IIf(m_Motion.IO(m_AxisID).NegativeLimitSwitch = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblOriginSwitch.BackColor = IIf(m_Motion.IO(m_AxisID).OriginSwitch = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblPA.BackColor = IIf(1 = 2, Color.DarkGreen, Color.Black)
        Me.lblPB.BackColor = IIf(1 = 2, Color.DarkGreen, Color.Black)
        Me.lblPCSSignalInput.BackColor = IIf(m_Motion.IO(m_AxisID).PCSSignalInput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblPositiveLimitSwitch.BackColor = IIf(m_Motion.IO(m_AxisID).PositiveLimitSwitch = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblRDYPinInput.BackColor = IIf(m_Motion.IO(m_AxisID).RdyInput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblServoONOutputStatus.BackColor = IIf(m_Motion.IO(m_AxisID).ServoOnOutput = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
        Me.lblSlowDownSignalInput.BackColor = IIf(m_Motion.IO(m_AxisID).PositiveSlowDownPoint = enumMotionFlag.eHigh, Color.DarkGreen, Color.Black)
    End Sub
    Private Sub FMotionSts_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Timer1.Enabled = False
    End Sub
    Private Sub FMotionSts_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Timer1.Interval = 10
        Timer1.Enabled = True
        Me.Text = m_Motion.AxisName(m_AxisID)
    End Sub
End Class