<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMotionSts
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblMotionSts = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblRDYPinInput = New System.Windows.Forms.Label()
        Me.lblAlarmSignal = New System.Windows.Forms.Label()
        Me.lblPositiveLimitSwitch = New System.Windows.Forms.Label()
        Me.lblClearSignal = New System.Windows.Forms.Label()
        Me.lblLatchSignalInput = New System.Windows.Forms.Label()
        Me.lblSlowDownSignalInput = New System.Windows.Forms.Label()
        Me.lblNegativeLimitSwitch = New System.Windows.Forms.Label()
        Me.lblOriginSwitch = New System.Windows.Forms.Label()
        Me.lblDIROutput = New System.Windows.Forms.Label()
        Me.lblEMGStatus = New System.Windows.Forms.Label()
        Me.lblPCSSignalInput = New System.Windows.Forms.Label()
        Me.lblERCPinOutput = New System.Windows.Forms.Label()
        Me.lblIndexSignal = New System.Windows.Forms.Label()
        Me.lblInPositionSignalInput = New System.Windows.Forms.Label()
        Me.lblServoONOutputStatus = New System.Windows.Forms.Label()
        Me.lblPA = New System.Windows.Forms.Label()
        Me.lblPB = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.GroupBox17.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox17.Controls.Add(Me.TableLayoutPanel9)
        Me.GroupBox17.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox17.ForeColor = System.Drawing.Color.White
        Me.GroupBox17.Location = New System.Drawing.Point(2, 3)
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.Size = New System.Drawing.Size(432, 49)
        Me.GroupBox17.TabIndex = 39
        Me.GroupBox17.TabStop = False
        Me.GroupBox17.Text = "軸卡狀態"
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel9.AutoSize = True
        Me.TableLayoutPanel9.ColumnCount = 1
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel9.Controls.Add(Me.lblMotionSts, 0, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(6, 21)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(424, 22)
        Me.TableLayoutPanel9.TabIndex = 0
        '
        'lblMotionSts
        '
        Me.lblMotionSts.BackColor = System.Drawing.Color.DarkSlateGray
        Me.lblMotionSts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblMotionSts.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblMotionSts.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMotionSts.ForeColor = System.Drawing.Color.White
        Me.lblMotionSts.Location = New System.Drawing.Point(1, 1)
        Me.lblMotionSts.Margin = New System.Windows.Forms.Padding(1)
        Me.lblMotionSts.Name = "lblMotionSts"
        Me.lblMotionSts.Size = New System.Drawing.Size(418, 20)
        Me.lblMotionSts.TabIndex = 0
        Me.lblMotionSts.Text = "Normal stopped condition"
        Me.lblMotionSts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(2, 56)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 68)
        Me.GroupBox1.TabIndex = 39
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "外部接點狀態"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.AutoSize = True
        Me.TableLayoutPanel1.ColumnCount = 10
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.lblRDYPinInput, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblAlarmSignal, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPositiveLimitSwitch, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblClearSignal, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblLatchSignalInput, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblSlowDownSignalInput, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblNegativeLimitSwitch, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblOriginSwitch, 4, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblDIROutput, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblEMGStatus, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPCSSignalInput, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblERCPinOutput, 8, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblIndexSignal, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblInPositionSignalInput, 3, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblServoONOutputStatus, 4, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPA, 5, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblPB, 6, 1)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(422, 45)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'lblRDYPinInput
        '
        Me.lblRDYPinInput.BackColor = System.Drawing.Color.Black
        Me.lblRDYPinInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRDYPinInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblRDYPinInput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblRDYPinInput.ForeColor = System.Drawing.Color.White
        Me.lblRDYPinInput.Location = New System.Drawing.Point(1, 1)
        Me.lblRDYPinInput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblRDYPinInput.Name = "lblRDYPinInput"
        Me.lblRDYPinInput.Size = New System.Drawing.Size(40, 20)
        Me.lblRDYPinInput.TabIndex = 0
        Me.lblRDYPinInput.Text = "RDY"
        Me.lblRDYPinInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblAlarmSignal
        '
        Me.lblAlarmSignal.BackColor = System.Drawing.Color.Black
        Me.lblAlarmSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAlarmSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblAlarmSignal.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblAlarmSignal.ForeColor = System.Drawing.Color.White
        Me.lblAlarmSignal.Location = New System.Drawing.Point(43, 1)
        Me.lblAlarmSignal.Margin = New System.Windows.Forms.Padding(1)
        Me.lblAlarmSignal.Name = "lblAlarmSignal"
        Me.lblAlarmSignal.Size = New System.Drawing.Size(40, 20)
        Me.lblAlarmSignal.TabIndex = 0
        Me.lblAlarmSignal.Text = "ALM"
        Me.lblAlarmSignal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPositiveLimitSwitch
        '
        Me.lblPositiveLimitSwitch.BackColor = System.Drawing.Color.Black
        Me.lblPositiveLimitSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPositiveLimitSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPositiveLimitSwitch.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPositiveLimitSwitch.ForeColor = System.Drawing.Color.White
        Me.lblPositiveLimitSwitch.Location = New System.Drawing.Point(85, 1)
        Me.lblPositiveLimitSwitch.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPositiveLimitSwitch.Name = "lblPositiveLimitSwitch"
        Me.lblPositiveLimitSwitch.Size = New System.Drawing.Size(40, 20)
        Me.lblPositiveLimitSwitch.TabIndex = 0
        Me.lblPositiveLimitSwitch.Text = "+EL"
        Me.lblPositiveLimitSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClearSignal
        '
        Me.lblClearSignal.BackColor = System.Drawing.Color.Black
        Me.lblClearSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblClearSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblClearSignal.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblClearSignal.ForeColor = System.Drawing.Color.White
        Me.lblClearSignal.Location = New System.Drawing.Point(1, 23)
        Me.lblClearSignal.Margin = New System.Windows.Forms.Padding(1)
        Me.lblClearSignal.Name = "lblClearSignal"
        Me.lblClearSignal.Size = New System.Drawing.Size(40, 20)
        Me.lblClearSignal.TabIndex = 0
        Me.lblClearSignal.Text = "CLR"
        Me.lblClearSignal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblLatchSignalInput
        '
        Me.lblLatchSignalInput.BackColor = System.Drawing.Color.Black
        Me.lblLatchSignalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblLatchSignalInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblLatchSignalInput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblLatchSignalInput.ForeColor = System.Drawing.Color.White
        Me.lblLatchSignalInput.Location = New System.Drawing.Point(43, 23)
        Me.lblLatchSignalInput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblLatchSignalInput.Name = "lblLatchSignalInput"
        Me.lblLatchSignalInput.Size = New System.Drawing.Size(40, 20)
        Me.lblLatchSignalInput.TabIndex = 0
        Me.lblLatchSignalInput.Text = "LTC"
        Me.lblLatchSignalInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblSlowDownSignalInput
        '
        Me.lblSlowDownSignalInput.BackColor = System.Drawing.Color.Black
        Me.lblSlowDownSignalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSlowDownSignalInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblSlowDownSignalInput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblSlowDownSignalInput.ForeColor = System.Drawing.Color.White
        Me.lblSlowDownSignalInput.Location = New System.Drawing.Point(85, 23)
        Me.lblSlowDownSignalInput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblSlowDownSignalInput.Name = "lblSlowDownSignalInput"
        Me.lblSlowDownSignalInput.Size = New System.Drawing.Size(40, 20)
        Me.lblSlowDownSignalInput.TabIndex = 0
        Me.lblSlowDownSignalInput.Text = "SD"
        Me.lblSlowDownSignalInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNegativeLimitSwitch
        '
        Me.lblNegativeLimitSwitch.BackColor = System.Drawing.Color.Black
        Me.lblNegativeLimitSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblNegativeLimitSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblNegativeLimitSwitch.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblNegativeLimitSwitch.ForeColor = System.Drawing.Color.White
        Me.lblNegativeLimitSwitch.Location = New System.Drawing.Point(127, 1)
        Me.lblNegativeLimitSwitch.Margin = New System.Windows.Forms.Padding(1)
        Me.lblNegativeLimitSwitch.Name = "lblNegativeLimitSwitch"
        Me.lblNegativeLimitSwitch.Size = New System.Drawing.Size(40, 20)
        Me.lblNegativeLimitSwitch.TabIndex = 0
        Me.lblNegativeLimitSwitch.Text = "-EL"
        Me.lblNegativeLimitSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblOriginSwitch
        '
        Me.lblOriginSwitch.BackColor = System.Drawing.Color.Black
        Me.lblOriginSwitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblOriginSwitch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblOriginSwitch.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblOriginSwitch.ForeColor = System.Drawing.Color.White
        Me.lblOriginSwitch.Location = New System.Drawing.Point(169, 1)
        Me.lblOriginSwitch.Margin = New System.Windows.Forms.Padding(1)
        Me.lblOriginSwitch.Name = "lblOriginSwitch"
        Me.lblOriginSwitch.Size = New System.Drawing.Size(40, 20)
        Me.lblOriginSwitch.TabIndex = 0
        Me.lblOriginSwitch.Text = "ORG"
        Me.lblOriginSwitch.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblDIROutput
        '
        Me.lblDIROutput.BackColor = System.Drawing.Color.Black
        Me.lblDIROutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblDIROutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblDIROutput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblDIROutput.ForeColor = System.Drawing.Color.White
        Me.lblDIROutput.Location = New System.Drawing.Point(211, 1)
        Me.lblDIROutput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblDIROutput.Name = "lblDIROutput"
        Me.lblDIROutput.Size = New System.Drawing.Size(40, 20)
        Me.lblDIROutput.TabIndex = 0
        Me.lblDIROutput.Text = "DIR"
        Me.lblDIROutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEMGStatus
        '
        Me.lblEMGStatus.BackColor = System.Drawing.Color.Black
        Me.lblEMGStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblEMGStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblEMGStatus.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblEMGStatus.ForeColor = System.Drawing.Color.White
        Me.lblEMGStatus.Location = New System.Drawing.Point(253, 1)
        Me.lblEMGStatus.Margin = New System.Windows.Forms.Padding(1)
        Me.lblEMGStatus.Name = "lblEMGStatus"
        Me.lblEMGStatus.Size = New System.Drawing.Size(40, 20)
        Me.lblEMGStatus.TabIndex = 0
        Me.lblEMGStatus.Text = "EMG"
        Me.lblEMGStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPCSSignalInput
        '
        Me.lblPCSSignalInput.BackColor = System.Drawing.Color.Black
        Me.lblPCSSignalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPCSSignalInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPCSSignalInput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPCSSignalInput.ForeColor = System.Drawing.Color.White
        Me.lblPCSSignalInput.Location = New System.Drawing.Point(295, 1)
        Me.lblPCSSignalInput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPCSSignalInput.Name = "lblPCSSignalInput"
        Me.lblPCSSignalInput.Size = New System.Drawing.Size(40, 20)
        Me.lblPCSSignalInput.TabIndex = 0
        Me.lblPCSSignalInput.Text = "PCS"
        Me.lblPCSSignalInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblERCPinOutput
        '
        Me.lblERCPinOutput.BackColor = System.Drawing.Color.Black
        Me.lblERCPinOutput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblERCPinOutput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblERCPinOutput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblERCPinOutput.ForeColor = System.Drawing.Color.White
        Me.lblERCPinOutput.Location = New System.Drawing.Point(337, 1)
        Me.lblERCPinOutput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblERCPinOutput.Name = "lblERCPinOutput"
        Me.lblERCPinOutput.Size = New System.Drawing.Size(40, 20)
        Me.lblERCPinOutput.TabIndex = 0
        Me.lblERCPinOutput.Text = "ERC"
        Me.lblERCPinOutput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblIndexSignal
        '
        Me.lblIndexSignal.BackColor = System.Drawing.Color.Black
        Me.lblIndexSignal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblIndexSignal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblIndexSignal.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblIndexSignal.ForeColor = System.Drawing.Color.White
        Me.lblIndexSignal.Location = New System.Drawing.Point(379, 1)
        Me.lblIndexSignal.Margin = New System.Windows.Forms.Padding(1)
        Me.lblIndexSignal.Name = "lblIndexSignal"
        Me.lblIndexSignal.Size = New System.Drawing.Size(40, 20)
        Me.lblIndexSignal.TabIndex = 0
        Me.lblIndexSignal.Text = "EZ"
        Me.lblIndexSignal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInPositionSignalInput
        '
        Me.lblInPositionSignalInput.BackColor = System.Drawing.Color.Black
        Me.lblInPositionSignalInput.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblInPositionSignalInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblInPositionSignalInput.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblInPositionSignalInput.ForeColor = System.Drawing.Color.White
        Me.lblInPositionSignalInput.Location = New System.Drawing.Point(127, 23)
        Me.lblInPositionSignalInput.Margin = New System.Windows.Forms.Padding(1)
        Me.lblInPositionSignalInput.Name = "lblInPositionSignalInput"
        Me.lblInPositionSignalInput.Size = New System.Drawing.Size(40, 20)
        Me.lblInPositionSignalInput.TabIndex = 0
        Me.lblInPositionSignalInput.Text = "INP"
        Me.lblInPositionSignalInput.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblServoONOutputStatus
        '
        Me.lblServoONOutputStatus.BackColor = System.Drawing.Color.Black
        Me.lblServoONOutputStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblServoONOutputStatus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblServoONOutputStatus.Font = New System.Drawing.Font("微軟正黑體", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblServoONOutputStatus.ForeColor = System.Drawing.Color.White
        Me.lblServoONOutputStatus.Location = New System.Drawing.Point(169, 23)
        Me.lblServoONOutputStatus.Margin = New System.Windows.Forms.Padding(1)
        Me.lblServoONOutputStatus.Name = "lblServoONOutputStatus"
        Me.lblServoONOutputStatus.Size = New System.Drawing.Size(40, 20)
        Me.lblServoONOutputStatus.TabIndex = 0
        Me.lblServoONOutputStatus.Text = "SVON"
        Me.lblServoONOutputStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPA
        '
        Me.lblPA.BackColor = System.Drawing.Color.Black
        Me.lblPA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPA.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPA.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPA.ForeColor = System.Drawing.Color.White
        Me.lblPA.Location = New System.Drawing.Point(211, 23)
        Me.lblPA.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPA.Name = "lblPA"
        Me.lblPA.Size = New System.Drawing.Size(40, 20)
        Me.lblPA.TabIndex = 0
        Me.lblPA.Text = "PA"
        Me.lblPA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPB
        '
        Me.lblPB.BackColor = System.Drawing.Color.Black
        Me.lblPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblPB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.lblPB.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblPB.ForeColor = System.Drawing.Color.White
        Me.lblPB.Location = New System.Drawing.Point(253, 23)
        Me.lblPB.Margin = New System.Windows.Forms.Padding(1)
        Me.lblPB.Name = "lblPB"
        Me.lblPB.Size = New System.Drawing.Size(40, 20)
        Me.lblPB.TabIndex = 0
        Me.lblPB.Text = "PB"
        Me.lblPB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Timer1
        '
        '
        'FMotionSts
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(437, 128)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox17)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FMotionSts"
        Me.Text = "FMotionSts"
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblMotionSts As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblRDYPinInput As System.Windows.Forms.Label
    Friend WithEvents lblAlarmSignal As System.Windows.Forms.Label
    Friend WithEvents lblPositiveLimitSwitch As System.Windows.Forms.Label
    Friend WithEvents lblClearSignal As System.Windows.Forms.Label
    Friend WithEvents lblLatchSignalInput As System.Windows.Forms.Label
    Friend WithEvents lblSlowDownSignalInput As System.Windows.Forms.Label
    Friend WithEvents lblNegativeLimitSwitch As System.Windows.Forms.Label
    Friend WithEvents lblOriginSwitch As System.Windows.Forms.Label
    Friend WithEvents lblDIROutput As System.Windows.Forms.Label
    Friend WithEvents lblEMGStatus As System.Windows.Forms.Label
    Friend WithEvents lblPCSSignalInput As System.Windows.Forms.Label
    Friend WithEvents lblERCPinOutput As System.Windows.Forms.Label
    Friend WithEvents lblIndexSignal As System.Windows.Forms.Label
    Friend WithEvents lblInPositionSignalInput As System.Windows.Forms.Label
    Friend WithEvents lblServoONOutputStatus As System.Windows.Forms.Label
    Friend WithEvents lblPA As System.Windows.Forms.Label
    Friend WithEvents lblPB As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
