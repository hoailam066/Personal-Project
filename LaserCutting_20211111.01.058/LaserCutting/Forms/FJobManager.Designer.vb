<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FJobManager
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FJobManager))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnZero = New System.Windows.Forms.Button()
        Me.txtHeight = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtPositionR = New System.Windows.Forms.TextBox()
        Me.txtPositionZ = New System.Windows.Forms.TextBox()
        Me.txtPositionY = New System.Windows.Forms.TextBox()
        Me.txtPositionX = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnPositionMinus = New System.Windows.Forms.Button()
        Me.btnPositionAdd = New System.Windows.Forms.Button()
        Me.txtDistance = New System.Windows.Forms.TextBox()
        Me.txtAxisUnit = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnMoveToReadyPosition = New System.Windows.Forms.Button()
        Me.btnResetRobotAlarm = New System.Windows.Forms.Button()
        Me.btnJobFromLaserTestZ = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.btnFeedCounterClockwise = New System.Windows.Forms.Button()
        Me.btnFeedClockwise = New System.Windows.Forms.Button()
        Me.btnJobToLaserTestZ = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnJobZ = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.tbSpeed = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.lblProperty = New System.Windows.Forms.Label()
        Me.btnBuildProgram = New System.Windows.Forms.Button()
        Me.btnPointSoldering = New System.Windows.Forms.Button()
        Me.pgJobProperty = New System.Windows.Forms.PropertyGrid()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAddPoint = New System.Windows.Forms.Button()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.btnAddAxis = New System.Windows.Forms.Button()
        Me.btnAddIO = New System.Windows.Forms.Button()
        Me.btnAddHome = New System.Windows.Forms.Button()
        Me.btnAddDischarge = New System.Windows.Forms.Button()
        Me.btnAddLamp = New System.Windows.Forms.Button()
        Me.btnAddLotEnd = New System.Windows.Forms.Button()
        Me.btnAddBlow = New System.Windows.Forms.Button()
        Me.btnAddAlign = New System.Windows.Forms.Button()
        Me.btnAddBarcode = New System.Windows.Forms.Button()
        Me.btnAddPallet = New System.Windows.Forms.Button()
        Me.btnAddRepeat = New System.Windows.Forms.Button()
        Me.btnAddIF = New System.Windows.Forms.Button()
        Me.btnAddStandby = New System.Windows.Forms.Button()
        Me.btnAddJump = New System.Windows.Forms.Button()
        Me.btnAddWait = New System.Windows.Forms.Button()
        Me.btnAddTackBegin = New System.Windows.Forms.Button()
        Me.btnAddTackEnd = New System.Windows.Forms.Button()
        Me.btnAddRecordStart = New System.Windows.Forms.Button()
        Me.btnAddRecordStop = New System.Windows.Forms.Button()
        Me.btnAddGVariable = New System.Windows.Forms.Button()
        Me.tvJobs = New System.Windows.Forms.TreeView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TopToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BottomToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.imageListTreeView = New System.Windows.Forms.ImageList(Me.components)
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.btnSoldering = New System.Windows.Forms.Button()
        Me.btnLighting = New System.Windows.Forms.Button()
        Me.btnBlowing = New System.Windows.Forms.Button()
        Me.btnRedBeam = New System.Windows.Forms.Button()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.btnSaveLaser = New System.Windows.Forms.Button()
        Me.btnStopLaser = New System.Windows.Forms.Button()
        Me.btnRunLaser = New System.Windows.Forms.Button()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.Button50 = New System.Windows.Forms.Button()
        Me.Button51 = New System.Windows.Forms.Button()
        Me.Button52 = New System.Windows.Forms.Button()
        Me.Button53 = New System.Windows.Forms.Button()
        Me.Button54 = New System.Windows.Forms.Button()
        Me.Button55 = New System.Windows.Forms.Button()
        Me.Button44 = New System.Windows.Forms.Button()
        Me.Button41 = New System.Windows.Forms.Button()
        Me.Button42 = New System.Windows.Forms.Button()
        Me.Button43 = New System.Windows.Forms.Button()
        Me.Button45 = New System.Windows.Forms.Button()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.Button49 = New System.Windows.Forms.Button()
        Me.Button48 = New System.Windows.Forms.Button()
        Me.Button47 = New System.Windows.Forms.Button()
        Me.Button58 = New System.Windows.Forms.Button()
        Me.Button57 = New System.Windows.Forms.Button()
        Me.Button56 = New System.Windows.Forms.Button()
        Me.txtSpotSize = New System.Windows.Forms.TextBox()
        Me.txtIntervalTime = New System.Windows.Forms.TextBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.tbPower1 = New System.Windows.Forms.TrackBar()
        Me.tbPower0 = New System.Windows.Forms.TrackBar()
        Me.tbPower2 = New System.Windows.Forms.TrackBar()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.tbPower8 = New System.Windows.Forms.TrackBar()
        Me.tbPower3 = New System.Windows.Forms.TrackBar()
        Me.tbPower7 = New System.Windows.Forms.TrackBar()
        Me.tbPower4 = New System.Windows.Forms.TrackBar()
        Me.tbPower6 = New System.Windows.Forms.TrackBar()
        Me.tbPower5 = New System.Windows.Forms.TrackBar()
        Me.Button40 = New System.Windows.Forms.Button()
        Me.Button39 = New System.Windows.Forms.Button()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.btnSaveFeeder = New System.Windows.Forms.Button()
        Me.btnRunFeeder = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtForwardDistance1 = New System.Windows.Forms.TextBox()
        Me.txtForwardSpeedPercent1 = New System.Windows.Forms.TextBox()
        Me.txtBackwardDistancemm = New System.Windows.Forms.TextBox()
        Me.txtBackwardSpeedPercent = New System.Windows.Forms.TextBox()
        Me.txtBackwardDelay = New System.Windows.Forms.TextBox()
        Me.txtForwardDistance2 = New System.Windows.Forms.TextBox()
        Me.txtForwardSpeedPercent2 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtForwardDelay = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TimerDragTreeView = New System.Windows.Forms.Timer(Me.components)
        Me.imageListDrag = New System.Windows.Forms.ImageList(Me.components)
        Me.ContextMenuStrip2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowRulerToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnRegisterGPoint = New System.Windows.Forms.Button()
        Me.ptbSolderingTime = New System.Windows.Forms.PictureBox()
        Me.TimerWorkholderValue = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGetImagePoint = New System.Windows.Forms.Timer(Me.components)
        Me.grbCamera = New LaserSolder.GroupBoxEx()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.ImageDisplay1 = New VisionSystem.ImageDisplay()
        Me.rbAll = New LaserSolder.RadioButtonEx()
        Me.rbEach = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt7 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt3 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt6 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt2 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt5 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt1 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt4 = New LaserSolder.RadioButtonEx()
        Me.rbLaserOpt0 = New LaserSolder.RadioButtonEx()
        Me.rbAbs = New LaserSolder.RadioButtonEx()
        Me.rbRatio = New LaserSolder.RadioButtonEx()
        Me.rbFeederOpt3 = New LaserSolder.RadioButtonEx()
        Me.rbFeederOpt2 = New LaserSolder.RadioButtonEx()
        Me.rbFeederOpt1 = New LaserSolder.RadioButtonEx()
        Me.rbFeederOpt0 = New LaserSolder.RadioButtonEx()
        Me.chkSolderingTime = New LaserSolder.CheckBoxEx()
        Me.chkRecord = New LaserSolder.CheckBoxEx()
        Me.chkRuler = New LaserSolder.CheckBoxEx()
        Me.ButtonEx5 = New LaserSolder.ButtonEx()
        Me.ButtonEx6 = New LaserSolder.ButtonEx()
        Me.ButtonEx1 = New LaserSolder.ButtonEx()
        Me.ButtonEx2 = New LaserSolder.ButtonEx()
        Me.ButtonEx4 = New LaserSolder.ButtonEx()
        Me.ButtonEx3 = New LaserSolder.ButtonEx()
        Me.rbFeed = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisR = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisZ = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisY = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisX = New LaserSolder.RadioButtonEx()
        Me.rbX100 = New LaserSolder.RadioButtonEx()
        Me.rbX1 = New LaserSolder.RadioButtonEx()
        Me.rbX10 = New LaserSolder.RadioButtonEx()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel8.SuspendLayout()
        Me.Panel10.SuspendLayout()
        CType(Me.tbPower1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbPower5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel9.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip2.SuspendLayout()
        CType(Me.ptbSolderingTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grbCamera.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.btnZero)
        Me.Panel1.Controls.Add(Me.txtHeight)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.txtPositionR)
        Me.Panel1.Controls.Add(Me.txtPositionZ)
        Me.Panel1.Controls.Add(Me.txtPositionY)
        Me.Panel1.Controls.Add(Me.txtPositionX)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(0, 1051)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(800, 46)
        Me.Panel1.TabIndex = 0
        '
        'btnZero
        '
        Me.btnZero.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZero.Location = New System.Drawing.Point(732, 7)
        Me.btnZero.Name = "btnZero"
        Me.btnZero.Size = New System.Drawing.Size(62, 30)
        Me.btnZero.TabIndex = 12
        Me.btnZero.Text = "ZERO"
        Me.btnZero.UseVisualStyleBackColor = True
        '
        'txtHeight
        '
        Me.txtHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeight.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtHeight.Location = New System.Drawing.Point(627, 9)
        Me.txtHeight.Name = "txtHeight"
        Me.txtHeight.Size = New System.Drawing.Size(95, 26)
        Me.txtHeight.TabIndex = 11
        Me.txtHeight.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label12.Location = New System.Drawing.Point(566, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 17)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Height"
        '
        'txtPositionR
        '
        Me.txtPositionR.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPositionR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPositionR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtPositionR.Location = New System.Drawing.Point(353, 9)
        Me.txtPositionR.Name = "txtPositionR"
        Me.txtPositionR.ReadOnly = True
        Me.txtPositionR.Size = New System.Drawing.Size(94, 26)
        Me.txtPositionR.TabIndex = 8
        Me.txtPositionR.Text = "0"
        '
        'txtPositionZ
        '
        Me.txtPositionZ.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPositionZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPositionZ.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtPositionZ.Location = New System.Drawing.Point(258, 9)
        Me.txtPositionZ.Name = "txtPositionZ"
        Me.txtPositionZ.ReadOnly = True
        Me.txtPositionZ.Size = New System.Drawing.Size(94, 26)
        Me.txtPositionZ.TabIndex = 9
        Me.txtPositionZ.Text = "0"
        '
        'txtPositionY
        '
        Me.txtPositionY.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPositionY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPositionY.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtPositionY.Location = New System.Drawing.Point(163, 9)
        Me.txtPositionY.Name = "txtPositionY"
        Me.txtPositionY.ReadOnly = True
        Me.txtPositionY.Size = New System.Drawing.Size(94, 26)
        Me.txtPositionY.TabIndex = 7
        Me.txtPositionY.Text = "0"
        '
        'txtPositionX
        '
        Me.txtPositionX.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtPositionX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPositionX.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtPositionX.Location = New System.Drawing.Point(68, 9)
        Me.txtPositionX.Name = "txtPositionX"
        Me.txtPositionX.ReadOnly = True
        Me.txtPositionX.Size = New System.Drawing.Size(94, 26)
        Me.txtPositionX.TabIndex = 5
        Me.txtPositionX.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(1, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(66, 17)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Position"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.btnPositionMinus)
        Me.Panel2.Controls.Add(Me.rbFeed)
        Me.Panel2.Controls.Add(Me.rbActiveAxisR)
        Me.Panel2.Controls.Add(Me.rbActiveAxisZ)
        Me.Panel2.Controls.Add(Me.rbActiveAxisY)
        Me.Panel2.Controls.Add(Me.rbActiveAxisX)
        Me.Panel2.Controls.Add(Me.btnPositionAdd)
        Me.Panel2.Controls.Add(Me.txtDistance)
        Me.Panel2.Controls.Add(Me.txtAxisUnit)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 972)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(800, 76)
        Me.Panel2.TabIndex = 2
        '
        'btnPositionMinus
        '
        Me.btnPositionMinus.BackColor = System.Drawing.Color.Transparent
        Me.btnPositionMinus.BackgroundImage = CType(resources.GetObject("btnPositionMinus.BackgroundImage"), System.Drawing.Image)
        Me.btnPositionMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPositionMinus.FlatAppearance.BorderSize = 0
        Me.btnPositionMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPositionMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPositionMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPositionMinus.Location = New System.Drawing.Point(744, 13)
        Me.btnPositionMinus.Name = "btnPositionMinus"
        Me.btnPositionMinus.Size = New System.Drawing.Size(48, 48)
        Me.btnPositionMinus.TabIndex = 15
        Me.btnPositionMinus.UseVisualStyleBackColor = False
        '
        'btnPositionAdd
        '
        Me.btnPositionAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnPositionAdd.BackgroundImage = CType(resources.GetObject("btnPositionAdd.BackgroundImage"), System.Drawing.Image)
        Me.btnPositionAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPositionAdd.FlatAppearance.BorderSize = 0
        Me.btnPositionAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnPositionAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnPositionAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPositionAdd.Location = New System.Drawing.Point(689, 13)
        Me.btnPositionAdd.Name = "btnPositionAdd"
        Me.btnPositionAdd.Size = New System.Drawing.Size(48, 48)
        Me.btnPositionAdd.TabIndex = 15
        Me.btnPositionAdd.UseVisualStyleBackColor = False
        '
        'txtDistance
        '
        Me.txtDistance.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtDistance.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtDistance.Location = New System.Drawing.Point(586, 33)
        Me.txtDistance.Name = "txtDistance"
        Me.txtDistance.ReadOnly = True
        Me.txtDistance.Size = New System.Drawing.Size(81, 23)
        Me.txtDistance.TabIndex = 13
        Me.txtDistance.Text = "0.1"
        '
        'txtAxisUnit
        '
        Me.txtAxisUnit.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtAxisUnit.Location = New System.Drawing.Point(179, 35)
        Me.txtAxisUnit.Name = "txtAxisUnit"
        Me.txtAxisUnit.Size = New System.Drawing.Size(66, 23)
        Me.txtAxisUnit.TabIndex = 12
        Me.txtAxisUnit.Text = "0.1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(513, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Distance"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(120, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(58, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Unit D."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, -2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 20)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Axis Control"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(118, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 17)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Select Axis"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.rbX100)
        Me.Panel3.Controls.Add(Me.rbX1)
        Me.Panel3.Controls.Add(Me.rbX10)
        Me.Panel3.Location = New System.Drawing.Point(244, 35)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(205, 34)
        Me.Panel3.TabIndex = 14
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel4.Controls.Add(Me.TextBox2)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.btnMoveToReadyPosition)
        Me.Panel4.Controls.Add(Me.chkSolderingTime)
        Me.Panel4.Controls.Add(Me.btnResetRobotAlarm)
        Me.Panel4.Controls.Add(Me.chkRecord)
        Me.Panel4.Controls.Add(Me.btnJobFromLaserTestZ)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel4)
        Me.Panel4.Controls.Add(Me.btnJobToLaserTestZ)
        Me.Panel4.Controls.Add(Me.chkRuler)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel3)
        Me.Panel4.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel4.Controls.Add(Me.btnJobZ)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtSpeed)
        Me.Panel4.Controls.Add(Me.tbSpeed)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel4.Location = New System.Drawing.Point(0, 805)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(800, 161)
        Me.Panel4.TabIndex = 3
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(472, 88)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(93, 23)
        Me.TextBox2.TabIndex = 27
        Me.TextBox2.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, -3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 20)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Jog Control"
        '
        'btnMoveToReadyPosition
        '
        Me.btnMoveToReadyPosition.BackColor = System.Drawing.Color.Transparent
        Me.btnMoveToReadyPosition.BackgroundImage = Global.LaserSolder.My.Resources.Resources.home
        Me.btnMoveToReadyPosition.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnMoveToReadyPosition.FlatAppearance.BorderSize = 0
        Me.btnMoveToReadyPosition.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnMoveToReadyPosition.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnMoveToReadyPosition.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMoveToReadyPosition.Location = New System.Drawing.Point(647, 82)
        Me.btnMoveToReadyPosition.Name = "btnMoveToReadyPosition"
        Me.btnMoveToReadyPosition.Size = New System.Drawing.Size(48, 48)
        Me.btnMoveToReadyPosition.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnMoveToReadyPosition, "Move to the ready position")
        Me.btnMoveToReadyPosition.UseVisualStyleBackColor = False
        '
        'btnResetRobotAlarm
        '
        Me.btnResetRobotAlarm.BackColor = System.Drawing.Color.Transparent
        Me.btnResetRobotAlarm.BackgroundImage = Global.LaserSolder.My.Resources.Resources.roll
        Me.btnResetRobotAlarm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnResetRobotAlarm.FlatAppearance.BorderSize = 0
        Me.btnResetRobotAlarm.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnResetRobotAlarm.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnResetRobotAlarm.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnResetRobotAlarm.Location = New System.Drawing.Point(571, 82)
        Me.btnResetRobotAlarm.Name = "btnResetRobotAlarm"
        Me.btnResetRobotAlarm.Size = New System.Drawing.Size(48, 48)
        Me.btnResetRobotAlarm.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnResetRobotAlarm, "Reset robot alarm")
        Me.btnResetRobotAlarm.UseVisualStyleBackColor = False
        '
        'btnJobFromLaserTestZ
        '
        Me.btnJobFromLaserTestZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.leftcut
        Me.btnJobFromLaserTestZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnJobFromLaserTestZ.Location = New System.Drawing.Point(647, 25)
        Me.btnJobFromLaserTestZ.Name = "btnJobFromLaserTestZ"
        Me.btnJobFromLaserTestZ.Size = New System.Drawing.Size(48, 48)
        Me.btnJobFromLaserTestZ.TabIndex = 0
        Me.btnJobFromLaserTestZ.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.Label46, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnFeedCounterClockwise, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnFeedClockwise, 0, 2)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(311, 25)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(56, 124)
        Me.TableLayoutPanel4.TabIndex = 26
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(3, 52)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(50, 18)
        Me.Label46.TabIndex = 17
        Me.Label46.Text = "Feed"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnFeedCounterClockwise
        '
        Me.btnFeedCounterClockwise.BackColor = System.Drawing.Color.Transparent
        Me.btnFeedCounterClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove
        Me.btnFeedCounterClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnFeedCounterClockwise.FlatAppearance.BorderSize = 0
        Me.btnFeedCounterClockwise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnFeedCounterClockwise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnFeedCounterClockwise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFeedCounterClockwise.Location = New System.Drawing.Point(4, 0)
        Me.btnFeedCounterClockwise.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnFeedCounterClockwise.Name = "btnFeedCounterClockwise"
        Me.btnFeedCounterClockwise.Size = New System.Drawing.Size(48, 52)
        Me.btnFeedCounterClockwise.TabIndex = 18
        Me.btnFeedCounterClockwise.UseVisualStyleBackColor = False
        '
        'btnFeedClockwise
        '
        Me.btnFeedClockwise.BackColor = System.Drawing.Color.Transparent
        Me.btnFeedClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd
        Me.btnFeedClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnFeedClockwise.FlatAppearance.BorderSize = 0
        Me.btnFeedClockwise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnFeedClockwise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnFeedClockwise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFeedClockwise.Location = New System.Drawing.Point(4, 70)
        Me.btnFeedClockwise.Margin = New System.Windows.Forms.Padding(4, 0, 0, 0)
        Me.btnFeedClockwise.Name = "btnFeedClockwise"
        Me.btnFeedClockwise.Size = New System.Drawing.Size(48, 52)
        Me.btnFeedClockwise.TabIndex = 18
        Me.btnFeedClockwise.UseVisualStyleBackColor = False
        '
        'btnJobToLaserTestZ
        '
        Me.btnJobToLaserTestZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.rightcut
        Me.btnJobToLaserTestZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnJobToLaserTestZ.Location = New System.Drawing.Point(571, 25)
        Me.btnJobToLaserTestZ.Name = "btnJobToLaserTestZ"
        Me.btnJobToLaserTestZ.Size = New System.Drawing.Size(48, 48)
        Me.btnJobToLaserTestZ.TabIndex = 0
        Me.btnJobToLaserTestZ.UseVisualStyleBackColor = True
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonEx5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.ButtonEx6, 0, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(208, 25)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(43, 124)
        Me.TableLayoutPanel3.TabIndex = 26
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(0, 39)
        Me.Label9.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(41, 39)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Z"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonEx1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonEx2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonEx4, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ButtonEx3, 1, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(26, 25)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(126, 124)
        Me.TableLayoutPanel2.TabIndex = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(43, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 39)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "XY"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnJobZ
        '
        Me.btnJobZ.BackColor = System.Drawing.Color.Transparent
        Me.btnJobZ.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jobz
        Me.btnJobZ.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnJobZ.FlatAppearance.BorderSize = 0
        Me.btnJobZ.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnJobZ.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnJobZ.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnJobZ.Location = New System.Drawing.Point(418, 48)
        Me.btnJobZ.Name = "btnJobZ"
        Me.btnJobZ.Size = New System.Drawing.Size(48, 52)
        Me.btnJobZ.TabIndex = 23
        Me.btnJobZ.UseVisualStyleBackColor = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(416, 107)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 17)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Job Z"
        '
        'txtSpeed
        '
        Me.txtSpeed.BackColor = System.Drawing.Color.White
        Me.txtSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtSpeed.Location = New System.Drawing.Point(413, 0)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.ReadOnly = True
        Me.txtSpeed.Size = New System.Drawing.Size(60, 23)
        Me.txtSpeed.TabIndex = 9
        Me.txtSpeed.Text = "30"
        '
        'tbSpeed
        '
        Me.tbSpeed.AutoSize = False
        Me.tbSpeed.Location = New System.Drawing.Point(167, -3)
        Me.tbSpeed.Maximum = 100
        Me.tbSpeed.Name = "tbSpeed"
        Me.tbSpeed.Size = New System.Drawing.Size(241, 24)
        Me.tbSpeed.TabIndex = 8
        Me.tbSpeed.TickFrequency = 0
        Me.tbSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbSpeed.Value = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(114, -1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 17)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Speed"
        '
        'TabControl1
        '
        Me.TabControl1.Appearance = System.Windows.Forms.TabAppearance.Buttons
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(800, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(441, 1048)
        Me.TabControl1.TabIndex = 7
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lblProperty)
        Me.TabPage2.Controls.Add(Me.rbAll)
        Me.TabPage2.Controls.Add(Me.rbEach)
        Me.TabPage2.Controls.Add(Me.btnBuildProgram)
        Me.TabPage2.Controls.Add(Me.btnPointSoldering)
        Me.TabPage2.Controls.Add(Me.pgJobProperty)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPage2.Controls.Add(Me.tvJobs)
        Me.TabPage2.Location = New System.Drawing.Point(4, 32)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(433, 1012)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Builder"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lblProperty
        '
        Me.lblProperty.BackColor = System.Drawing.Color.White
        Me.lblProperty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblProperty.Location = New System.Drawing.Point(80, 381)
        Me.lblProperty.Name = "lblProperty"
        Me.lblProperty.Size = New System.Drawing.Size(223, 23)
        Me.lblProperty.TabIndex = 9
        Me.lblProperty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuildProgram
        '
        Me.btnBuildProgram.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuildProgram.Image = Global.LaserSolder.My.Resources.Resources.program
        Me.btnBuildProgram.Location = New System.Drawing.Point(224, 952)
        Me.btnBuildProgram.Name = "btnBuildProgram"
        Me.btnBuildProgram.Size = New System.Drawing.Size(196, 44)
        Me.btnBuildProgram.TabIndex = 7
        Me.btnBuildProgram.Text = "Build Program"
        Me.btnBuildProgram.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuildProgram.UseVisualStyleBackColor = True
        '
        'btnPointSoldering
        '
        Me.btnPointSoldering.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnPointSoldering.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPointSoldering.Image = Global.LaserSolder.My.Resources.Resources.pulselaser2
        Me.btnPointSoldering.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPointSoldering.Location = New System.Drawing.Point(17, 953)
        Me.btnPointSoldering.Name = "btnPointSoldering"
        Me.btnPointSoldering.Size = New System.Drawing.Size(196, 44)
        Me.btnPointSoldering.TabIndex = 6
        Me.btnPointSoldering.Text = "Soldering (Point)"
        Me.btnPointSoldering.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnPointSoldering.UseVisualStyleBackColor = True
        '
        'pgJobProperty
        '
        Me.pgJobProperty.LineColor = System.Drawing.SystemColors.ControlDark
        Me.pgJobProperty.Location = New System.Drawing.Point(6, 411)
        Me.pgJobProperty.Name = "pgJobProperty"
        Me.pgJobProperty.PropertySort = System.Windows.Forms.PropertySort.Categorized
        Me.pgJobProperty.Size = New System.Drawing.Size(423, 540)
        Me.pgJobProperty.TabIndex = 5
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 382)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 20)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Property"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddPoint, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddLine, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddAxis, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddIO, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddHome, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddDischarge, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddLamp, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddLotEnd, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddBlow, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddAlign, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddBarcode, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddPallet, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddRepeat, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddIF, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddStandby, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddJump, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddWait, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddTackBegin, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddTackEnd, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddRecordStart, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddRecordStop, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAddGVariable, 1, 10)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(362, 1)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 11
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(68, 374)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'btnAddPoint
        '
        Me.btnAddPoint.BackgroundImage = Global.LaserSolder.My.Resources.Resources.point
        Me.btnAddPoint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddPoint.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddPoint.Location = New System.Drawing.Point(1, 1)
        Me.btnAddPoint.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddPoint.Name = "btnAddPoint"
        Me.btnAddPoint.Size = New System.Drawing.Size(32, 32)
        Me.btnAddPoint.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddPoint, "Register point soldering")
        Me.btnAddPoint.UseVisualStyleBackColor = True
        '
        'btnAddLine
        '
        Me.btnAddLine.BackgroundImage = Global.LaserSolder.My.Resources.Resources.line
        Me.btnAddLine.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddLine.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddLine.Location = New System.Drawing.Point(1, 35)
        Me.btnAddLine.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddLine.Name = "btnAddLine"
        Me.btnAddLine.Size = New System.Drawing.Size(32, 32)
        Me.btnAddLine.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddLine, "Register line soldering")
        Me.btnAddLine.UseVisualStyleBackColor = True
        '
        'btnAddAxis
        '
        Me.btnAddAxis.BackgroundImage = Global.LaserSolder.My.Resources.Resources.axisicon
        Me.btnAddAxis.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddAxis.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddAxis.Location = New System.Drawing.Point(1, 69)
        Me.btnAddAxis.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddAxis.Name = "btnAddAxis"
        Me.btnAddAxis.Size = New System.Drawing.Size(32, 32)
        Me.btnAddAxis.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddAxis, "Move position")
        Me.btnAddAxis.UseVisualStyleBackColor = True
        '
        'btnAddIO
        '
        Me.btnAddIO.BackgroundImage = Global.LaserSolder.My.Resources.Resources.io
        Me.btnAddIO.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddIO.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddIO.Location = New System.Drawing.Point(1, 103)
        Me.btnAddIO.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddIO.Name = "btnAddIO"
        Me.btnAddIO.Size = New System.Drawing.Size(32, 32)
        Me.btnAddIO.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddIO, "Register i/o value")
        Me.btnAddIO.UseVisualStyleBackColor = True
        '
        'btnAddHome
        '
        Me.btnAddHome.BackgroundImage = Global.LaserSolder.My.Resources.Resources.home2
        Me.btnAddHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddHome.Location = New System.Drawing.Point(1, 137)
        Me.btnAddHome.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddHome.Name = "btnAddHome"
        Me.btnAddHome.Size = New System.Drawing.Size(32, 32)
        Me.btnAddHome.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddHome, "Register ready position")
        Me.btnAddHome.UseVisualStyleBackColor = True
        '
        'btnAddDischarge
        '
        Me.btnAddDischarge.BackgroundImage = Global.LaserSolder.My.Resources.Resources.updown
        Me.btnAddDischarge.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddDischarge.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddDischarge.Location = New System.Drawing.Point(1, 171)
        Me.btnAddDischarge.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddDischarge.Name = "btnAddDischarge"
        Me.btnAddDischarge.Size = New System.Drawing.Size(32, 32)
        Me.btnAddDischarge.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddDischarge, "Register discharge movement")
        Me.btnAddDischarge.UseVisualStyleBackColor = True
        '
        'btnAddLamp
        '
        Me.btnAddLamp.BackgroundImage = Global.LaserSolder.My.Resources.Resources.lighttowner
        Me.btnAddLamp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddLamp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddLamp.Location = New System.Drawing.Point(1, 205)
        Me.btnAddLamp.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddLamp.Name = "btnAddLamp"
        Me.btnAddLamp.Size = New System.Drawing.Size(32, 32)
        Me.btnAddLamp.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddLamp, "Register tower lamp control")
        Me.btnAddLamp.UseVisualStyleBackColor = True
        '
        'btnAddLotEnd
        '
        Me.btnAddLotEnd.BackgroundImage = Global.LaserSolder.My.Resources.Resources.counter
        Me.btnAddLotEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddLotEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddLotEnd.Location = New System.Drawing.Point(1, 239)
        Me.btnAddLotEnd.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddLotEnd.Name = "btnAddLotEnd"
        Me.btnAddLotEnd.Size = New System.Drawing.Size(32, 32)
        Me.btnAddLotEnd.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddLotEnd, "Register job count")
        Me.btnAddLotEnd.UseVisualStyleBackColor = True
        '
        'btnAddBlow
        '
        Me.btnAddBlow.BackgroundImage = Global.LaserSolder.My.Resources.Resources.blowing
        Me.btnAddBlow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddBlow.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddBlow.Location = New System.Drawing.Point(1, 273)
        Me.btnAddBlow.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddBlow.Name = "btnAddBlow"
        Me.btnAddBlow.Size = New System.Drawing.Size(32, 32)
        Me.btnAddBlow.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddBlow, "Register blowing on off")
        Me.btnAddBlow.UseVisualStyleBackColor = True
        '
        'btnAddAlign
        '
        Me.btnAddAlign.BackgroundImage = Global.LaserSolder.My.Resources.Resources.captureicon
        Me.btnAddAlign.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddAlign.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddAlign.Location = New System.Drawing.Point(1, 307)
        Me.btnAddAlign.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddAlign.Name = "btnAddAlign"
        Me.btnAddAlign.Size = New System.Drawing.Size(32, 32)
        Me.btnAddAlign.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddAlign, "Register vision alignment")
        Me.btnAddAlign.UseVisualStyleBackColor = True
        '
        'btnAddBarcode
        '
        Me.btnAddBarcode.BackgroundImage = Global.LaserSolder.My.Resources.Resources.qrcode
        Me.btnAddBarcode.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddBarcode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddBarcode.Location = New System.Drawing.Point(1, 341)
        Me.btnAddBarcode.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddBarcode.Name = "btnAddBarcode"
        Me.btnAddBarcode.Size = New System.Drawing.Size(32, 32)
        Me.btnAddBarcode.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddBarcode, "Register barcode scanning")
        Me.btnAddBarcode.UseVisualStyleBackColor = True
        '
        'btnAddPallet
        '
        Me.btnAddPallet.BackgroundImage = Global.LaserSolder.My.Resources.Resources.multicircle
        Me.btnAddPallet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddPallet.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddPallet.Location = New System.Drawing.Point(35, 1)
        Me.btnAddPallet.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddPallet.Name = "btnAddPallet"
        Me.btnAddPallet.Size = New System.Drawing.Size(32, 32)
        Me.btnAddPallet.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddPallet, "Register palletizing of jobs")
        Me.btnAddPallet.UseVisualStyleBackColor = True
        '
        'btnAddRepeat
        '
        Me.btnAddRepeat.BackgroundImage = Global.LaserSolder.My.Resources.Resources.repeat
        Me.btnAddRepeat.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddRepeat.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddRepeat.Location = New System.Drawing.Point(35, 35)
        Me.btnAddRepeat.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddRepeat.Name = "btnAddRepeat"
        Me.btnAddRepeat.Size = New System.Drawing.Size(32, 32)
        Me.btnAddRepeat.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddRepeat, "Register repeat jobs")
        Me.btnAddRepeat.UseVisualStyleBackColor = True
        '
        'btnAddIF
        '
        Me.btnAddIF.BackgroundImage = Global.LaserSolder.My.Resources.Resources.ificon
        Me.btnAddIF.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddIF.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddIF.Location = New System.Drawing.Point(35, 69)
        Me.btnAddIF.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddIF.Name = "btnAddIF"
        Me.btnAddIF.Size = New System.Drawing.Size(32, 32)
        Me.btnAddIF.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddIF, "Register conditional play")
        Me.btnAddIF.UseVisualStyleBackColor = True
        '
        'btnAddStandby
        '
        Me.btnAddStandby.BackgroundImage = Global.LaserSolder.My.Resources.Resources.stopicon
        Me.btnAddStandby.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddStandby.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddStandby.Location = New System.Drawing.Point(35, 103)
        Me.btnAddStandby.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddStandby.Name = "btnAddStandby"
        Me.btnAddStandby.Size = New System.Drawing.Size(32, 32)
        Me.btnAddStandby.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddStandby, "Standby until condition is true")
        Me.btnAddStandby.UseVisualStyleBackColor = True
        '
        'btnAddJump
        '
        Me.btnAddJump.BackgroundImage = Global.LaserSolder.My.Resources.Resources.jump
        Me.btnAddJump.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddJump.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddJump.Location = New System.Drawing.Point(35, 137)
        Me.btnAddJump.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddJump.Name = "btnAddJump"
        Me.btnAddJump.Size = New System.Drawing.Size(32, 32)
        Me.btnAddJump.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddJump, "Jump to selected module")
        Me.btnAddJump.UseVisualStyleBackColor = True
        '
        'btnAddWait
        '
        Me.btnAddWait.BackgroundImage = Global.LaserSolder.My.Resources.Resources.wait
        Me.btnAddWait.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddWait.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddWait.Location = New System.Drawing.Point(35, 171)
        Me.btnAddWait.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddWait.Name = "btnAddWait"
        Me.btnAddWait.Size = New System.Drawing.Size(32, 32)
        Me.btnAddWait.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddWait, "Wait for selected time")
        Me.btnAddWait.UseVisualStyleBackColor = True
        '
        'btnAddTackBegin
        '
        Me.btnAddTackBegin.BackgroundImage = Global.LaserSolder.My.Resources.Resources.alarm_start
        Me.btnAddTackBegin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddTackBegin.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddTackBegin.Location = New System.Drawing.Point(35, 205)
        Me.btnAddTackBegin.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddTackBegin.Name = "btnAddTackBegin"
        Me.btnAddTackBegin.Size = New System.Drawing.Size(32, 32)
        Me.btnAddTackBegin.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddTackBegin, "Register at starting position of tack time measurement")
        Me.btnAddTackBegin.UseVisualStyleBackColor = True
        '
        'btnAddTackEnd
        '
        Me.btnAddTackEnd.BackgroundImage = Global.LaserSolder.My.Resources.Resources.alarm_stop
        Me.btnAddTackEnd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddTackEnd.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddTackEnd.Location = New System.Drawing.Point(35, 239)
        Me.btnAddTackEnd.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddTackEnd.Name = "btnAddTackEnd"
        Me.btnAddTackEnd.Size = New System.Drawing.Size(32, 32)
        Me.btnAddTackEnd.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddTackEnd, "Register at ending position of tack time measurement")
        Me.btnAddTackEnd.UseVisualStyleBackColor = True
        '
        'btnAddRecordStart
        '
        Me.btnAddRecordStart.BackgroundImage = Global.LaserSolder.My.Resources.Resources.record_start
        Me.btnAddRecordStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddRecordStart.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddRecordStart.Location = New System.Drawing.Point(35, 273)
        Me.btnAddRecordStart.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddRecordStart.Name = "btnAddRecordStart"
        Me.btnAddRecordStart.Size = New System.Drawing.Size(32, 32)
        Me.btnAddRecordStart.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddRecordStart, "Register record start")
        Me.btnAddRecordStart.UseVisualStyleBackColor = True
        '
        'btnAddRecordStop
        '
        Me.btnAddRecordStop.BackgroundImage = Global.LaserSolder.My.Resources.Resources.record_stop
        Me.btnAddRecordStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddRecordStop.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddRecordStop.Location = New System.Drawing.Point(35, 307)
        Me.btnAddRecordStop.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddRecordStop.Name = "btnAddRecordStop"
        Me.btnAddRecordStop.Size = New System.Drawing.Size(32, 32)
        Me.btnAddRecordStop.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddRecordStop, "Register record stop")
        Me.btnAddRecordStop.UseVisualStyleBackColor = True
        '
        'btnAddGVariable
        '
        Me.btnAddGVariable.BackgroundImage = Global.LaserSolder.My.Resources.Resources.gi
        Me.btnAddGVariable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAddGVariable.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddGVariable.Location = New System.Drawing.Point(35, 341)
        Me.btnAddGVariable.Margin = New System.Windows.Forms.Padding(1)
        Me.btnAddGVariable.Name = "btnAddGVariable"
        Me.btnAddGVariable.Size = New System.Drawing.Size(32, 32)
        Me.btnAddGVariable.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnAddGVariable, "Register integer variable")
        Me.btnAddGVariable.UseVisualStyleBackColor = True
        '
        'tvJobs
        '
        Me.tvJobs.AllowDrop = True
        Me.tvJobs.ContextMenuStrip = Me.ContextMenuStrip1
        Me.tvJobs.ImageIndex = 1
        Me.tvJobs.ImageList = Me.imageListTreeView
        Me.tvJobs.Indent = 22
        Me.tvJobs.ItemHeight = 25
        Me.tvJobs.Location = New System.Drawing.Point(6, 1)
        Me.tvJobs.Name = "tvJobs"
        Me.tvJobs.SelectedImageIndex = 0
        Me.tvJobs.Size = New System.Drawing.Size(352, 375)
        Me.tvJobs.TabIndex = 0
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TopToolStripMenuItem, Me.UpToolStripMenuItem, Me.DownToolStripMenuItem, Me.BottomToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(115, 92)
        '
        'TopToolStripMenuItem
        '
        Me.TopToolStripMenuItem.Image = Global.LaserSolder.My.Resources.Resources.movetop
        Me.TopToolStripMenuItem.Name = "TopToolStripMenuItem"
        Me.TopToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.TopToolStripMenuItem.Text = "Top"
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.Image = Global.LaserSolder.My.Resources.Resources.moveup
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        Me.UpToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.UpToolStripMenuItem.Text = "Up"
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.Image = Global.LaserSolder.My.Resources.Resources.movedown
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        Me.DownToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.DownToolStripMenuItem.Text = "Down"
        '
        'BottomToolStripMenuItem
        '
        Me.BottomToolStripMenuItem.Image = Global.LaserSolder.My.Resources.Resources.movebottom
        Me.BottomToolStripMenuItem.Name = "BottomToolStripMenuItem"
        Me.BottomToolStripMenuItem.Size = New System.Drawing.Size(114, 22)
        Me.BottomToolStripMenuItem.Text = "Bottom"
        '
        'imageListTreeView
        '
        Me.imageListTreeView.ImageStream = CType(resources.GetObject("imageListTreeView.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imageListTreeView.TransparentColor = System.Drawing.Color.Transparent
        Me.imageListTreeView.Images.SetKeyName(0, "point.png")
        Me.imageListTreeView.Images.SetKeyName(1, "multicircle.png")
        Me.imageListTreeView.Images.SetKeyName(2, "line.png")
        Me.imageListTreeView.Images.SetKeyName(3, "repeat.png")
        Me.imageListTreeView.Images.SetKeyName(4, "axisicon.png")
        Me.imageListTreeView.Images.SetKeyName(5, "ificon.png")
        Me.imageListTreeView.Images.SetKeyName(6, "io.png")
        Me.imageListTreeView.Images.SetKeyName(7, "stopicon.png")
        Me.imageListTreeView.Images.SetKeyName(8, "home2.png")
        Me.imageListTreeView.Images.SetKeyName(9, "jump.png")
        Me.imageListTreeView.Images.SetKeyName(10, "updown.png")
        Me.imageListTreeView.Images.SetKeyName(11, "wait.png")
        Me.imageListTreeView.Images.SetKeyName(12, "lighttowner.png")
        Me.imageListTreeView.Images.SetKeyName(13, "alarm_start.png")
        Me.imageListTreeView.Images.SetKeyName(14, "counter.png")
        Me.imageListTreeView.Images.SetKeyName(15, "alarm_stop.png")
        Me.imageListTreeView.Images.SetKeyName(16, "blowing.png")
        Me.imageListTreeView.Images.SetKeyName(17, "record_start.png")
        Me.imageListTreeView.Images.SetKeyName(18, "captureicon.png")
        Me.imageListTreeView.Images.SetKeyName(19, "record_stop.png")
        Me.imageListTreeView.Images.SetKeyName(20, "qrcode.png")
        Me.imageListTreeView.Images.SetKeyName(21, "gi.png")
        Me.imageListTreeView.Images.SetKeyName(22, "treenoderoot.png")
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Controls.Add(Me.Panel8)
        Me.TabPage1.Controls.Add(Me.Panel7)
        Me.TabPage1.Location = New System.Drawing.Point(4, 32)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(433, 1012)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Solder"
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.Label29)
        Me.Panel6.Controls.Add(Me.Label28)
        Me.Panel6.Controls.Add(Me.Label27)
        Me.Panel6.Controls.Add(Me.Label26)
        Me.Panel6.Controls.Add(Me.btnSoldering)
        Me.Panel6.Controls.Add(Me.btnLighting)
        Me.Panel6.Controls.Add(Me.btnBlowing)
        Me.Panel6.Controls.Add(Me.btnRedBeam)
        Me.Panel6.Location = New System.Drawing.Point(0, 852)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(430, 89)
        Me.Panel6.TabIndex = 2
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(243, 59)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(58, 17)
        Me.Label29.TabIndex = 2
        Me.Label29.Text = "Lighting"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(126, 59)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 17)
        Me.Label28.TabIndex = 2
        Me.Label28.Text = "Blowing"
        Me.Label28.Visible = False
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(3, 59)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(74, 17)
        Me.Label27.TabIndex = 2
        Me.Label27.Text = "Red Beam"
        Me.Label27.Visible = False
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(356, 60)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(68, 17)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "Soldering"
        '
        'btnSoldering
        '
        Me.btnSoldering.BackgroundImage = Global.LaserSolder.My.Resources.Resources.pulselaser
        Me.btnSoldering.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSoldering.Location = New System.Drawing.Point(365, 10)
        Me.btnSoldering.Name = "btnSoldering"
        Me.btnSoldering.Size = New System.Drawing.Size(48, 48)
        Me.btnSoldering.TabIndex = 0
        Me.btnSoldering.UseVisualStyleBackColor = True
        '
        'btnLighting
        '
        Me.btnLighting.BackgroundImage = Global.LaserSolder.My.Resources.Resources.lightoff
        Me.btnLighting.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnLighting.Location = New System.Drawing.Point(248, 10)
        Me.btnLighting.Name = "btnLighting"
        Me.btnLighting.Size = New System.Drawing.Size(48, 48)
        Me.btnLighting.TabIndex = 0
        Me.btnLighting.UseVisualStyleBackColor = True
        '
        'btnBlowing
        '
        Me.btnBlowing.BackgroundImage = Global.LaserSolder.My.Resources.Resources.blowing
        Me.btnBlowing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnBlowing.Location = New System.Drawing.Point(131, 10)
        Me.btnBlowing.Name = "btnBlowing"
        Me.btnBlowing.Size = New System.Drawing.Size(48, 48)
        Me.btnBlowing.TabIndex = 0
        Me.btnBlowing.UseVisualStyleBackColor = True
        Me.btnBlowing.Visible = False
        '
        'btnRedBeam
        '
        Me.btnRedBeam.BackgroundImage = Global.LaserSolder.My.Resources.Resources.redbeam
        Me.btnRedBeam.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnRedBeam.Location = New System.Drawing.Point(14, 10)
        Me.btnRedBeam.Name = "btnRedBeam"
        Me.btnRedBeam.Size = New System.Drawing.Size(48, 48)
        Me.btnRedBeam.TabIndex = 0
        Me.btnRedBeam.UseVisualStyleBackColor = True
        Me.btnRedBeam.Visible = False
        '
        'Panel8
        '
        Me.Panel8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel8.Controls.Add(Me.rbLaserOpt7)
        Me.Panel8.Controls.Add(Me.rbLaserOpt3)
        Me.Panel8.Controls.Add(Me.rbLaserOpt6)
        Me.Panel8.Controls.Add(Me.rbLaserOpt2)
        Me.Panel8.Controls.Add(Me.btnSaveLaser)
        Me.Panel8.Controls.Add(Me.rbLaserOpt5)
        Me.Panel8.Controls.Add(Me.rbLaserOpt1)
        Me.Panel8.Controls.Add(Me.rbLaserOpt4)
        Me.Panel8.Controls.Add(Me.btnStopLaser)
        Me.Panel8.Controls.Add(Me.rbLaserOpt0)
        Me.Panel8.Controls.Add(Me.btnRunLaser)
        Me.Panel8.Controls.Add(Me.Panel10)
        Me.Panel8.Controls.Add(Me.Button40)
        Me.Panel8.Controls.Add(Me.Button39)
        Me.Panel8.Controls.Add(Me.TextBox13)
        Me.Panel8.Controls.Add(Me.Panel9)
        Me.Panel8.Controls.Add(Me.Label32)
        Me.Panel8.Controls.Add(Me.Label30)
        Me.Panel8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel8.Location = New System.Drawing.Point(0, 324)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(433, 519)
        Me.Panel8.TabIndex = 4
        '
        'btnSaveLaser
        '
        Me.btnSaveLaser.Image = CType(resources.GetObject("btnSaveLaser.Image"), System.Drawing.Image)
        Me.btnSaveLaser.Location = New System.Drawing.Point(319, 463)
        Me.btnSaveLaser.Name = "btnSaveLaser"
        Me.btnSaveLaser.Size = New System.Drawing.Size(105, 43)
        Me.btnSaveLaser.TabIndex = 13
        Me.btnSaveLaser.Text = "Save"
        Me.btnSaveLaser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveLaser.UseVisualStyleBackColor = True
        '
        'btnStopLaser
        '
        Me.btnStopLaser.Image = CType(resources.GetObject("btnStopLaser.Image"), System.Drawing.Image)
        Me.btnStopLaser.Location = New System.Drawing.Point(201, 463)
        Me.btnStopLaser.Name = "btnStopLaser"
        Me.btnStopLaser.Size = New System.Drawing.Size(105, 43)
        Me.btnStopLaser.TabIndex = 13
        Me.btnStopLaser.Text = "Stop"
        Me.btnStopLaser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnStopLaser.UseVisualStyleBackColor = True
        '
        'btnRunLaser
        '
        Me.btnRunLaser.Image = CType(resources.GetObject("btnRunLaser.Image"), System.Drawing.Image)
        Me.btnRunLaser.Location = New System.Drawing.Point(83, 463)
        Me.btnRunLaser.Name = "btnRunLaser"
        Me.btnRunLaser.Size = New System.Drawing.Size(105, 43)
        Me.btnRunLaser.TabIndex = 13
        Me.btnRunLaser.Text = "Run"
        Me.btnRunLaser.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRunLaser.UseVisualStyleBackColor = True
        '
        'Panel10
        '
        Me.Panel10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel10.Controls.Add(Me.Button50)
        Me.Panel10.Controls.Add(Me.Button51)
        Me.Panel10.Controls.Add(Me.Button52)
        Me.Panel10.Controls.Add(Me.Button53)
        Me.Panel10.Controls.Add(Me.Button54)
        Me.Panel10.Controls.Add(Me.Button55)
        Me.Panel10.Controls.Add(Me.Button44)
        Me.Panel10.Controls.Add(Me.Button41)
        Me.Panel10.Controls.Add(Me.Button42)
        Me.Panel10.Controls.Add(Me.Button43)
        Me.Panel10.Controls.Add(Me.Button45)
        Me.Panel10.Controls.Add(Me.Button46)
        Me.Panel10.Controls.Add(Me.Button49)
        Me.Panel10.Controls.Add(Me.Button48)
        Me.Panel10.Controls.Add(Me.Button47)
        Me.Panel10.Controls.Add(Me.Button58)
        Me.Panel10.Controls.Add(Me.Button57)
        Me.Panel10.Controls.Add(Me.Button56)
        Me.Panel10.Controls.Add(Me.txtSpotSize)
        Me.Panel10.Controls.Add(Me.txtIntervalTime)
        Me.Panel10.Controls.Add(Me.Label44)
        Me.Panel10.Controls.Add(Me.Label43)
        Me.Panel10.Controls.Add(Me.Label45)
        Me.Panel10.Controls.Add(Me.Label42)
        Me.Panel10.Controls.Add(Me.Label41)
        Me.Panel10.Controls.Add(Me.Label40)
        Me.Panel10.Controls.Add(Me.Label39)
        Me.Panel10.Controls.Add(Me.Label38)
        Me.Panel10.Controls.Add(Me.Label37)
        Me.Panel10.Controls.Add(Me.Label35)
        Me.Panel10.Controls.Add(Me.Label36)
        Me.Panel10.Controls.Add(Me.Label34)
        Me.Panel10.Controls.Add(Me.tbPower1)
        Me.Panel10.Controls.Add(Me.tbPower0)
        Me.Panel10.Controls.Add(Me.tbPower2)
        Me.Panel10.Controls.Add(Me.Label33)
        Me.Panel10.Controls.Add(Me.tbPower8)
        Me.Panel10.Controls.Add(Me.tbPower3)
        Me.Panel10.Controls.Add(Me.tbPower7)
        Me.Panel10.Controls.Add(Me.tbPower4)
        Me.Panel10.Controls.Add(Me.tbPower6)
        Me.Panel10.Controls.Add(Me.tbPower5)
        Me.Panel10.Location = New System.Drawing.Point(3, 103)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(423, 338)
        Me.Panel10.TabIndex = 8
        '
        'Button50
        '
        Me.Button50.BackColor = System.Drawing.Color.Transparent
        Me.Button50.BackgroundImage = CType(resources.GetObject("Button50.BackgroundImage"), System.Drawing.Image)
        Me.Button50.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button50.FlatAppearance.BorderSize = 0
        Me.Button50.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button50.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button50.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button50.Location = New System.Drawing.Point(6, 241)
        Me.Button50.Name = "Button50"
        Me.Button50.Size = New System.Drawing.Size(28, 28)
        Me.Button50.TabIndex = 15
        Me.Button50.UseVisualStyleBackColor = False
        '
        'Button51
        '
        Me.Button51.BackColor = System.Drawing.Color.Transparent
        Me.Button51.BackgroundImage = CType(resources.GetObject("Button51.BackgroundImage"), System.Drawing.Image)
        Me.Button51.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button51.FlatAppearance.BorderSize = 0
        Me.Button51.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button51.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button51.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button51.Location = New System.Drawing.Point(54, 241)
        Me.Button51.Name = "Button51"
        Me.Button51.Size = New System.Drawing.Size(28, 28)
        Me.Button51.TabIndex = 18
        Me.Button51.UseVisualStyleBackColor = False
        '
        'Button52
        '
        Me.Button52.BackColor = System.Drawing.Color.Transparent
        Me.Button52.BackgroundImage = CType(resources.GetObject("Button52.BackgroundImage"), System.Drawing.Image)
        Me.Button52.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button52.FlatAppearance.BorderSize = 0
        Me.Button52.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button52.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button52.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button52.Location = New System.Drawing.Point(102, 241)
        Me.Button52.Name = "Button52"
        Me.Button52.Size = New System.Drawing.Size(28, 28)
        Me.Button52.TabIndex = 21
        Me.Button52.UseVisualStyleBackColor = False
        '
        'Button53
        '
        Me.Button53.BackColor = System.Drawing.Color.Transparent
        Me.Button53.BackgroundImage = CType(resources.GetObject("Button53.BackgroundImage"), System.Drawing.Image)
        Me.Button53.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button53.FlatAppearance.BorderSize = 0
        Me.Button53.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button53.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button53.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button53.Location = New System.Drawing.Point(150, 241)
        Me.Button53.Name = "Button53"
        Me.Button53.Size = New System.Drawing.Size(28, 28)
        Me.Button53.TabIndex = 24
        Me.Button53.UseVisualStyleBackColor = False
        '
        'Button54
        '
        Me.Button54.BackColor = System.Drawing.Color.Transparent
        Me.Button54.BackgroundImage = CType(resources.GetObject("Button54.BackgroundImage"), System.Drawing.Image)
        Me.Button54.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button54.FlatAppearance.BorderSize = 0
        Me.Button54.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button54.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button54.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button54.Location = New System.Drawing.Point(198, 241)
        Me.Button54.Name = "Button54"
        Me.Button54.Size = New System.Drawing.Size(28, 28)
        Me.Button54.TabIndex = 27
        Me.Button54.UseVisualStyleBackColor = False
        '
        'Button55
        '
        Me.Button55.BackColor = System.Drawing.Color.Transparent
        Me.Button55.BackgroundImage = CType(resources.GetObject("Button55.BackgroundImage"), System.Drawing.Image)
        Me.Button55.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button55.FlatAppearance.BorderSize = 0
        Me.Button55.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button55.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button55.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button55.Location = New System.Drawing.Point(246, 241)
        Me.Button55.Name = "Button55"
        Me.Button55.Size = New System.Drawing.Size(28, 28)
        Me.Button55.TabIndex = 30
        Me.Button55.UseVisualStyleBackColor = False
        '
        'Button44
        '
        Me.Button44.BackColor = System.Drawing.Color.Transparent
        Me.Button44.BackgroundImage = CType(resources.GetObject("Button44.BackgroundImage"), System.Drawing.Image)
        Me.Button44.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button44.FlatAppearance.BorderSize = 0
        Me.Button44.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button44.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button44.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button44.Location = New System.Drawing.Point(150, 3)
        Me.Button44.Name = "Button44"
        Me.Button44.Size = New System.Drawing.Size(28, 28)
        Me.Button44.TabIndex = 22
        Me.Button44.UseVisualStyleBackColor = False
        '
        'Button41
        '
        Me.Button41.BackColor = System.Drawing.Color.Transparent
        Me.Button41.BackgroundImage = CType(resources.GetObject("Button41.BackgroundImage"), System.Drawing.Image)
        Me.Button41.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button41.FlatAppearance.BorderSize = 0
        Me.Button41.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button41.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button41.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button41.Location = New System.Drawing.Point(6, 3)
        Me.Button41.Name = "Button41"
        Me.Button41.Size = New System.Drawing.Size(28, 28)
        Me.Button41.TabIndex = 13
        Me.Button41.UseVisualStyleBackColor = False
        '
        'Button42
        '
        Me.Button42.BackColor = System.Drawing.Color.Transparent
        Me.Button42.BackgroundImage = CType(resources.GetObject("Button42.BackgroundImage"), System.Drawing.Image)
        Me.Button42.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button42.FlatAppearance.BorderSize = 0
        Me.Button42.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button42.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button42.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button42.Location = New System.Drawing.Point(54, 3)
        Me.Button42.Name = "Button42"
        Me.Button42.Size = New System.Drawing.Size(28, 28)
        Me.Button42.TabIndex = 16
        Me.Button42.UseVisualStyleBackColor = False
        '
        'Button43
        '
        Me.Button43.BackColor = System.Drawing.Color.Transparent
        Me.Button43.BackgroundImage = CType(resources.GetObject("Button43.BackgroundImage"), System.Drawing.Image)
        Me.Button43.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button43.FlatAppearance.BorderSize = 0
        Me.Button43.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button43.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button43.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button43.Location = New System.Drawing.Point(102, 3)
        Me.Button43.Name = "Button43"
        Me.Button43.Size = New System.Drawing.Size(28, 28)
        Me.Button43.TabIndex = 19
        Me.Button43.UseVisualStyleBackColor = False
        '
        'Button45
        '
        Me.Button45.BackColor = System.Drawing.Color.Transparent
        Me.Button45.BackgroundImage = CType(resources.GetObject("Button45.BackgroundImage"), System.Drawing.Image)
        Me.Button45.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button45.FlatAppearance.BorderSize = 0
        Me.Button45.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button45.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button45.Location = New System.Drawing.Point(198, 3)
        Me.Button45.Name = "Button45"
        Me.Button45.Size = New System.Drawing.Size(28, 28)
        Me.Button45.TabIndex = 25
        Me.Button45.UseVisualStyleBackColor = False
        '
        'Button46
        '
        Me.Button46.BackColor = System.Drawing.Color.Transparent
        Me.Button46.BackgroundImage = CType(resources.GetObject("Button46.BackgroundImage"), System.Drawing.Image)
        Me.Button46.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button46.FlatAppearance.BorderSize = 0
        Me.Button46.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button46.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button46.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button46.Location = New System.Drawing.Point(246, 3)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(28, 28)
        Me.Button46.TabIndex = 28
        Me.Button46.UseVisualStyleBackColor = False
        '
        'Button49
        '
        Me.Button49.BackColor = System.Drawing.Color.Transparent
        Me.Button49.BackgroundImage = CType(resources.GetObject("Button49.BackgroundImage"), System.Drawing.Image)
        Me.Button49.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button49.FlatAppearance.BorderSize = 0
        Me.Button49.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button49.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button49.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button49.Location = New System.Drawing.Point(390, 3)
        Me.Button49.Name = "Button49"
        Me.Button49.Size = New System.Drawing.Size(28, 28)
        Me.Button49.TabIndex = 37
        Me.Button49.UseVisualStyleBackColor = False
        '
        'Button48
        '
        Me.Button48.BackColor = System.Drawing.Color.Transparent
        Me.Button48.BackgroundImage = CType(resources.GetObject("Button48.BackgroundImage"), System.Drawing.Image)
        Me.Button48.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button48.FlatAppearance.BorderSize = 0
        Me.Button48.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button48.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button48.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button48.Location = New System.Drawing.Point(342, 3)
        Me.Button48.Name = "Button48"
        Me.Button48.Size = New System.Drawing.Size(28, 28)
        Me.Button48.TabIndex = 34
        Me.Button48.UseVisualStyleBackColor = False
        '
        'Button47
        '
        Me.Button47.BackColor = System.Drawing.Color.Transparent
        Me.Button47.BackgroundImage = CType(resources.GetObject("Button47.BackgroundImage"), System.Drawing.Image)
        Me.Button47.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button47.FlatAppearance.BorderSize = 0
        Me.Button47.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button47.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button47.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button47.Location = New System.Drawing.Point(294, 3)
        Me.Button47.Name = "Button47"
        Me.Button47.Size = New System.Drawing.Size(28, 28)
        Me.Button47.TabIndex = 31
        Me.Button47.UseVisualStyleBackColor = False
        '
        'Button58
        '
        Me.Button58.BackColor = System.Drawing.Color.Transparent
        Me.Button58.BackgroundImage = CType(resources.GetObject("Button58.BackgroundImage"), System.Drawing.Image)
        Me.Button58.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button58.FlatAppearance.BorderSize = 0
        Me.Button58.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button58.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button58.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button58.Location = New System.Drawing.Point(389, 241)
        Me.Button58.Name = "Button58"
        Me.Button58.Size = New System.Drawing.Size(28, 28)
        Me.Button58.TabIndex = 39
        Me.Button58.UseVisualStyleBackColor = False
        '
        'Button57
        '
        Me.Button57.BackColor = System.Drawing.Color.Transparent
        Me.Button57.BackgroundImage = CType(resources.GetObject("Button57.BackgroundImage"), System.Drawing.Image)
        Me.Button57.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button57.FlatAppearance.BorderSize = 0
        Me.Button57.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button57.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button57.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button57.Location = New System.Drawing.Point(342, 241)
        Me.Button57.Name = "Button57"
        Me.Button57.Size = New System.Drawing.Size(28, 28)
        Me.Button57.TabIndex = 36
        Me.Button57.UseVisualStyleBackColor = False
        '
        'Button56
        '
        Me.Button56.BackColor = System.Drawing.Color.Transparent
        Me.Button56.BackgroundImage = CType(resources.GetObject("Button56.BackgroundImage"), System.Drawing.Image)
        Me.Button56.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button56.FlatAppearance.BorderSize = 0
        Me.Button56.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button56.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button56.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button56.Location = New System.Drawing.Point(294, 241)
        Me.Button56.Name = "Button56"
        Me.Button56.Size = New System.Drawing.Size(28, 28)
        Me.Button56.TabIndex = 33
        Me.Button56.UseVisualStyleBackColor = False
        '
        'txtSpotSize
        '
        Me.txtSpotSize.Location = New System.Drawing.Point(320, 301)
        Me.txtSpotSize.Name = "txtSpotSize"
        Me.txtSpotSize.Size = New System.Drawing.Size(75, 26)
        Me.txtSpotSize.TabIndex = 50
        '
        'txtIntervalTime
        '
        Me.txtIntervalTime.Location = New System.Drawing.Point(105, 301)
        Me.txtIntervalTime.Name = "txtIntervalTime"
        Me.txtIntervalTime.Size = New System.Drawing.Size(75, 26)
        Me.txtIntervalTime.TabIndex = 50
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(179, 306)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 17)
        Me.Label44.TabIndex = 51
        Me.Label44.Text = "msec"
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(245, 307)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(77, 17)
        Me.Label43.TabIndex = 49
        Me.Label43.Text = "Spot Size"
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(393, 306)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(29, 17)
        Me.Label45.TabIndex = 52
        Me.Label45.Text = "um"
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(3, 307)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(102, 17)
        Me.Label42.TabIndex = 49
        Me.Label42.Text = "Interval Time"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(386, 271)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(36, 17)
        Me.Label41.TabIndex = 48
        Me.Label41.Text = "00.0"
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(338, 271)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(36, 17)
        Me.Label40.TabIndex = 47
        Me.Label40.Text = "00.0"
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(290, 271)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(36, 17)
        Me.Label39.TabIndex = 46
        Me.Label39.Text = "00.0"
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(242, 271)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(36, 17)
        Me.Label38.TabIndex = 45
        Me.Label38.Text = "00.0"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(194, 271)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(36, 17)
        Me.Label37.TabIndex = 44
        Me.Label37.Text = "00.0"
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(99, 270)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(36, 17)
        Me.Label35.TabIndex = 43
        Me.Label35.Text = "00.0"
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(146, 271)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(36, 17)
        Me.Label36.TabIndex = 43
        Me.Label36.Text = "00.0"
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(51, 271)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(36, 17)
        Me.Label34.TabIndex = 42
        Me.Label34.Text = "00.0"
        '
        'tbPower1
        '
        Me.tbPower1.Location = New System.Drawing.Point(58, 30)
        Me.tbPower1.Maximum = 1000
        Me.tbPower1.Name = "tbPower1"
        Me.tbPower1.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower1.Size = New System.Drawing.Size(45, 211)
        Me.tbPower1.TabIndex = 20
        Me.tbPower1.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower1.Value = 162
        '
        'tbPower0
        '
        Me.tbPower0.Location = New System.Drawing.Point(9, 27)
        Me.tbPower0.Maximum = 1000
        Me.tbPower0.Name = "tbPower0"
        Me.tbPower0.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower0.Size = New System.Drawing.Size(45, 211)
        Me.tbPower0.TabIndex = 20
        Me.tbPower0.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower0.Value = 152
        '
        'tbPower2
        '
        Me.tbPower2.Location = New System.Drawing.Point(106, 30)
        Me.tbPower2.Maximum = 1000
        Me.tbPower2.Name = "tbPower2"
        Me.tbPower2.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower2.Size = New System.Drawing.Size(45, 211)
        Me.tbPower2.TabIndex = 20
        Me.tbPower2.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower2.Value = 167
        '
        'Label33
        '
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(2, 271)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(36, 17)
        Me.Label33.TabIndex = 40
        Me.Label33.Text = "00.0"
        '
        'tbPower8
        '
        Me.tbPower8.Location = New System.Drawing.Point(394, 30)
        Me.tbPower8.Maximum = 1000
        Me.tbPower8.Name = "tbPower8"
        Me.tbPower8.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower8.Size = New System.Drawing.Size(45, 211)
        Me.tbPower8.TabIndex = 38
        Me.tbPower8.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower8.Value = 32
        '
        'tbPower3
        '
        Me.tbPower3.Location = New System.Drawing.Point(154, 30)
        Me.tbPower3.Maximum = 1000
        Me.tbPower3.Name = "tbPower3"
        Me.tbPower3.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower3.Size = New System.Drawing.Size(45, 211)
        Me.tbPower3.TabIndex = 23
        Me.tbPower3.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower3.Value = 171
        '
        'tbPower7
        '
        Me.tbPower7.Location = New System.Drawing.Point(346, 30)
        Me.tbPower7.Maximum = 1000
        Me.tbPower7.Name = "tbPower7"
        Me.tbPower7.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower7.Size = New System.Drawing.Size(45, 211)
        Me.tbPower7.TabIndex = 35
        Me.tbPower7.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower7.Value = 62
        '
        'tbPower4
        '
        Me.tbPower4.Location = New System.Drawing.Point(202, 30)
        Me.tbPower4.Maximum = 1000
        Me.tbPower4.Name = "tbPower4"
        Me.tbPower4.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower4.Size = New System.Drawing.Size(45, 211)
        Me.tbPower4.TabIndex = 26
        Me.tbPower4.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower4.Value = 167
        '
        'tbPower6
        '
        Me.tbPower6.Location = New System.Drawing.Point(298, 30)
        Me.tbPower6.Maximum = 1000
        Me.tbPower6.Name = "tbPower6"
        Me.tbPower6.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower6.Size = New System.Drawing.Size(45, 211)
        Me.tbPower6.TabIndex = 32
        Me.tbPower6.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower6.Value = 132
        '
        'tbPower5
        '
        Me.tbPower5.Location = New System.Drawing.Point(250, 30)
        Me.tbPower5.Maximum = 1000
        Me.tbPower5.Name = "tbPower5"
        Me.tbPower5.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tbPower5.Size = New System.Drawing.Size(45, 211)
        Me.tbPower5.TabIndex = 29
        Me.tbPower5.TickStyle = System.Windows.Forms.TickStyle.None
        Me.tbPower5.Value = 142
        '
        'Button40
        '
        Me.Button40.BackColor = System.Drawing.Color.Transparent
        Me.Button40.BackgroundImage = CType(resources.GetObject("Button40.BackgroundImage"), System.Drawing.Image)
        Me.Button40.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button40.FlatAppearance.BorderSize = 0
        Me.Button40.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button40.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button40.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button40.Location = New System.Drawing.Point(400, 64)
        Me.Button40.Name = "Button40"
        Me.Button40.Size = New System.Drawing.Size(28, 28)
        Me.Button40.TabIndex = 12
        Me.Button40.UseVisualStyleBackColor = False
        '
        'Button39
        '
        Me.Button39.BackColor = System.Drawing.Color.Transparent
        Me.Button39.BackgroundImage = CType(resources.GetObject("Button39.BackgroundImage"), System.Drawing.Image)
        Me.Button39.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button39.FlatAppearance.BorderSize = 0
        Me.Button39.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.Button39.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.Button39.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button39.Location = New System.Drawing.Point(267, 64)
        Me.Button39.Name = "Button39"
        Me.Button39.Size = New System.Drawing.Size(28, 28)
        Me.Button39.TabIndex = 11
        Me.Button39.UseVisualStyleBackColor = False
        '
        'TextBox13
        '
        Me.TextBox13.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.TextBox13.Location = New System.Drawing.Point(298, 64)
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(100, 26)
        Me.TextBox13.TabIndex = 10
        Me.TextBox13.Text = "0.0"
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.rbAbs)
        Me.Panel9.Controls.Add(Me.rbRatio)
        Me.Panel9.Location = New System.Drawing.Point(96, 63)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(164, 26)
        Me.Panel9.TabIndex = 9
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(4, 65)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(83, 20)
        Me.Label32.TabIndex = 8
        Me.Label32.Text = "All Power"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 0)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(115, 20)
        Me.Label30.TabIndex = 8
        Me.Label30.Text = "Laser Recipe"
        '
        'Panel7
        '
        Me.Panel7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel7.Controls.Add(Me.rbFeederOpt3)
        Me.Panel7.Controls.Add(Me.rbFeederOpt2)
        Me.Panel7.Controls.Add(Me.rbFeederOpt1)
        Me.Panel7.Controls.Add(Me.rbFeederOpt0)
        Me.Panel7.Controls.Add(Me.btnSaveFeeder)
        Me.Panel7.Controls.Add(Me.btnRunFeeder)
        Me.Panel7.Controls.Add(Me.GroupBox2)
        Me.Panel7.Controls.Add(Me.Label31)
        Me.Panel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(433, 318)
        Me.Panel7.TabIndex = 3
        '
        'btnSaveFeeder
        '
        Me.btnSaveFeeder.Image = CType(resources.GetObject("btnSaveFeeder.Image"), System.Drawing.Image)
        Me.btnSaveFeeder.Location = New System.Drawing.Point(328, 271)
        Me.btnSaveFeeder.Name = "btnSaveFeeder"
        Me.btnSaveFeeder.Size = New System.Drawing.Size(97, 42)
        Me.btnSaveFeeder.TabIndex = 2
        Me.btnSaveFeeder.Text = "Save"
        Me.btnSaveFeeder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSaveFeeder.UseVisualStyleBackColor = True
        '
        'btnRunFeeder
        '
        Me.btnRunFeeder.Image = CType(resources.GetObject("btnRunFeeder.Image"), System.Drawing.Image)
        Me.btnRunFeeder.Location = New System.Drawing.Point(219, 271)
        Me.btnRunFeeder.Name = "btnRunFeeder"
        Me.btnRunFeeder.Size = New System.Drawing.Size(97, 42)
        Me.btnRunFeeder.TabIndex = 2
        Me.btnRunFeeder.Text = "Run"
        Me.btnRunFeeder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRunFeeder.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtForwardDistance1)
        Me.GroupBox2.Controls.Add(Me.txtForwardSpeedPercent1)
        Me.GroupBox2.Controls.Add(Me.txtBackwardDistancemm)
        Me.GroupBox2.Controls.Add(Me.txtBackwardSpeedPercent)
        Me.GroupBox2.Controls.Add(Me.txtBackwardDelay)
        Me.GroupBox2.Controls.Add(Me.txtForwardDistance2)
        Me.GroupBox2.Controls.Add(Me.txtForwardSpeedPercent2)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtForwardDelay)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 55)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(419, 213)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'txtForwardDistance1
        '
        Me.txtForwardDistance1.Location = New System.Drawing.Point(195, 80)
        Me.txtForwardDistance1.Name = "txtForwardDistance1"
        Me.txtForwardDistance1.Size = New System.Drawing.Size(85, 26)
        Me.txtForwardDistance1.TabIndex = 14
        '
        'txtForwardSpeedPercent1
        '
        Me.txtForwardSpeedPercent1.Location = New System.Drawing.Point(195, 48)
        Me.txtForwardSpeedPercent1.Name = "txtForwardSpeedPercent1"
        Me.txtForwardSpeedPercent1.Size = New System.Drawing.Size(85, 26)
        Me.txtForwardSpeedPercent1.TabIndex = 13
        '
        'txtBackwardDistancemm
        '
        Me.txtBackwardDistancemm.Location = New System.Drawing.Point(282, 176)
        Me.txtBackwardDistancemm.Name = "txtBackwardDistancemm"
        Me.txtBackwardDistancemm.Size = New System.Drawing.Size(85, 26)
        Me.txtBackwardDistancemm.TabIndex = 12
        '
        'txtBackwardSpeedPercent
        '
        Me.txtBackwardSpeedPercent.Location = New System.Drawing.Point(282, 144)
        Me.txtBackwardSpeedPercent.Name = "txtBackwardSpeedPercent"
        Me.txtBackwardSpeedPercent.Size = New System.Drawing.Size(85, 26)
        Me.txtBackwardSpeedPercent.TabIndex = 11
        '
        'txtBackwardDelay
        '
        Me.txtBackwardDelay.Location = New System.Drawing.Point(282, 112)
        Me.txtBackwardDelay.Name = "txtBackwardDelay"
        Me.txtBackwardDelay.Size = New System.Drawing.Size(85, 26)
        Me.txtBackwardDelay.TabIndex = 10
        '
        'txtForwardDistance2
        '
        Me.txtForwardDistance2.Location = New System.Drawing.Point(282, 80)
        Me.txtForwardDistance2.Name = "txtForwardDistance2"
        Me.txtForwardDistance2.Size = New System.Drawing.Size(85, 26)
        Me.txtForwardDistance2.TabIndex = 9
        '
        'txtForwardSpeedPercent2
        '
        Me.txtForwardSpeedPercent2.Location = New System.Drawing.Point(282, 48)
        Me.txtForwardSpeedPercent2.Name = "txtForwardSpeedPercent2"
        Me.txtForwardSpeedPercent2.Size = New System.Drawing.Size(85, 26)
        Me.txtForwardSpeedPercent2.TabIndex = 8
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(367, 147)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(24, 20)
        Me.Label22.TabIndex = 7
        Me.Label22.Text = "%"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(367, 51)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(24, 20)
        Me.Label21.TabIndex = 7
        Me.Label21.Text = "%"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(367, 179)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(37, 20)
        Me.Label25.TabIndex = 7
        Me.Label25.Text = "mm"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(367, 83)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(37, 20)
        Me.Label24.TabIndex = 7
        Me.Label24.Text = "mm"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(367, 115)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(51, 20)
        Me.Label23.TabIndex = 7
        Me.Label23.Text = "msec"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(367, 20)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 20)
        Me.Label20.TabIndex = 7
        Me.Label20.Text = "msec"
        '
        'txtForwardDelay
        '
        Me.txtForwardDelay.Location = New System.Drawing.Point(282, 16)
        Me.txtForwardDelay.Name = "txtForwardDelay"
        Me.txtForwardDelay.Size = New System.Drawing.Size(85, 26)
        Me.txtForwardDelay.TabIndex = 6
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 179)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(163, 20)
        Me.Label19.TabIndex = 5
        Me.Label19.Text = "Backward Distance"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 147)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(144, 20)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Backward Speed"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(5, 115)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(180, 20)
        Me.Label17.TabIndex = 3
        Me.Label17.Text = "Backward Delay Time"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(5, 83)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(193, 20)
        Me.Label16.TabIndex = 2
        Me.Label16.Text = "Forward Distance (1-2)"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 51)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(174, 20)
        Me.Label15.TabIndex = 1
        Me.Label15.Text = "Forward Speed (1-2)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(5, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(167, 20)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Forward Delay Time"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(3, 1)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(127, 20)
        Me.Label31.TabIndex = 0
        Me.Label31.Text = "Feeder Recipe"
        '
        'TimerDragTreeView
        '
        Me.TimerDragTreeView.Interval = 200
        '
        'imageListDrag
        '
        Me.imageListDrag.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
        Me.imageListDrag.ImageSize = New System.Drawing.Size(16, 16)
        Me.imageListDrag.TransparentColor = System.Drawing.Color.Transparent
        '
        'ContextMenuStrip2
        '
        Me.ContextMenuStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowRulerToolToolStripMenuItem})
        Me.ContextMenuStrip2.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip2.Size = New System.Drawing.Size(160, 26)
        '
        'ShowRulerToolToolStripMenuItem
        '
        Me.ShowRulerToolToolStripMenuItem.Name = "ShowRulerToolToolStripMenuItem"
        Me.ShowRulerToolToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ShowRulerToolToolStripMenuItem.Text = "Show Ruler Tool"
        '
        'btnRegisterGPoint
        '
        Me.btnRegisterGPoint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegisterGPoint.Image = Global.LaserSolder.My.Resources.Resources.tick
        Me.btnRegisterGPoint.Location = New System.Drawing.Point(821, 1035)
        Me.btnRegisterGPoint.Name = "btnRegisterGPoint"
        Me.btnRegisterGPoint.Padding = New System.Windows.Forms.Padding(40, 0, 0, 0)
        Me.btnRegisterGPoint.Size = New System.Drawing.Size(403, 59)
        Me.btnRegisterGPoint.TabIndex = 1
        Me.btnRegisterGPoint.Text = "   Register G. Points"
        Me.btnRegisterGPoint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnRegisterGPoint.UseVisualStyleBackColor = True
        '
        'ptbSolderingTime
        '
        Me.ptbSolderingTime.BackColor = System.Drawing.Color.Transparent
        Me.ptbSolderingTime.Location = New System.Drawing.Point(0, 774)
        Me.ptbSolderingTime.Name = "ptbSolderingTime"
        Me.ptbSolderingTime.Size = New System.Drawing.Size(800, 25)
        Me.ptbSolderingTime.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.ptbSolderingTime.TabIndex = 12
        Me.ptbSolderingTime.TabStop = False
        Me.ptbSolderingTime.Visible = False
        '
        'TimerWorkholderValue
        '
        '
        'TimerGetImagePoint
        '
        Me.TimerGetImagePoint.Enabled = True
        '
        'grbCamera
        '
        Me.grbCamera.BackColor = System.Drawing.Color.White
        Me.grbCamera.BorderColor = System.Drawing.SystemColors.ControlLight
        Me.grbCamera.BorderRadius = CType(0UI, UInteger)
        Me.grbCamera.Controls.Add(Me.Panel11)
        Me.grbCamera.Controls.Add(Me.Panel5)
        Me.grbCamera.Controls.Add(Me.ImageDisplay1)
        Me.grbCamera.Location = New System.Drawing.Point(-1, 0)
        Me.grbCamera.Margin = New System.Windows.Forms.Padding(0)
        Me.grbCamera.Name = "grbCamera"
        Me.grbCamera.Padding = New System.Windows.Forms.Padding(0)
        Me.grbCamera.Size = New System.Drawing.Size(800, 800)
        Me.grbCamera.TabIndex = 13
        Me.grbCamera.TabStop = False
        Me.grbCamera.Tag = "FJobManager"
        Me.grbCamera.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Panel11
        '
        Me.Panel11.BackColor = System.Drawing.Color.Black
        Me.Panel11.Location = New System.Drawing.Point(0, 700)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(800, 100)
        Me.Panel11.TabIndex = 7
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.Black
        Me.Panel5.Location = New System.Drawing.Point(0, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(800, 100)
        Me.Panel5.TabIndex = 7
        '
        'ImageDisplay1
        '
        Me.ImageDisplay1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageDisplay1.BackColor = System.Drawing.Color.Maroon
        Me.ImageDisplay1.ContextMenuStrip = Me.ContextMenuStrip2
        Me.ImageDisplay1.ImagePoint_X = 0.0R
        Me.ImageDisplay1.ImagePoint_Y = 0.0R
        Me.ImageDisplay1.ImagePointCanGet = True
        Me.ImageDisplay1.Location = New System.Drawing.Point(0, 100)
        Me.ImageDisplay1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageDisplay1.MaximumSize = New System.Drawing.Size(800, 600)
        Me.ImageDisplay1.Name = "ImageDisplay1"
        Me.ImageDisplay1.Record = False
        Me.ImageDisplay1.RecordInit = False
        Me.ImageDisplay1.RecordIsThreadFinished = False
        Me.ImageDisplay1.RecordIsThreadStarted = False
        Me.ImageDisplay1.RecordPath = Nothing
        Me.ImageDisplay1.RecordStop = False
        Me.ImageDisplay1.Size = New System.Drawing.Size(800, 600)
        Me.ImageDisplay1.TabIndex = 6
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.BackColor = System.Drawing.SystemColors.Control
        Me.rbAll.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbAll.CircleCheckedRadius = 8
        Me.rbAll.CircleCheckedX = 2
        Me.rbAll.CircleCheckedY = 2
        Me.rbAll.CircleColor = System.Drawing.Color.DimGray
        Me.rbAll.CircleGlintSize = 5
        Me.rbAll.CircleGlintX = 5
        Me.rbAll.CircleGlintY = 5
        Me.rbAll.CircleRadius = 10
        Me.rbAll.CircleWidth = 1.0!
        Me.rbAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAll.Location = New System.Drawing.Point(383, 380)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(44, 24)
        Me.rbAll.TabIndex = 8
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = False
        '
        'rbEach
        '
        Me.rbEach.AutoSize = True
        Me.rbEach.BackColor = System.Drawing.SystemColors.Control
        Me.rbEach.Checked = True
        Me.rbEach.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbEach.CircleCheckedRadius = 8
        Me.rbEach.CircleCheckedX = 2
        Me.rbEach.CircleCheckedY = 2
        Me.rbEach.CircleColor = System.Drawing.Color.DimGray
        Me.rbEach.CircleGlintSize = 5
        Me.rbEach.CircleGlintX = 5
        Me.rbEach.CircleGlintY = 5
        Me.rbEach.CircleRadius = 10
        Me.rbEach.CircleWidth = 1.0!
        Me.rbEach.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEach.Location = New System.Drawing.Point(309, 380)
        Me.rbEach.Name = "rbEach"
        Me.rbEach.Size = New System.Drawing.Size(64, 24)
        Me.rbEach.TabIndex = 8
        Me.rbEach.TabStop = True
        Me.rbEach.Text = "Each"
        Me.rbEach.UseVisualStyleBackColor = False
        '
        'rbLaserOpt7
        '
        Me.rbLaserOpt7.AutoSize = True
        Me.rbLaserOpt7.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt7.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt7.CircleCheckedRadius = 8
        Me.rbLaserOpt7.CircleCheckedX = 2
        Me.rbLaserOpt7.CircleCheckedY = 2
        Me.rbLaserOpt7.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt7.CircleGlintSize = 5
        Me.rbLaserOpt7.CircleGlintX = 5
        Me.rbLaserOpt7.CircleGlintY = 5
        Me.rbLaserOpt7.CircleRadius = 10
        Me.rbLaserOpt7.CircleWidth = 1.0!
        Me.rbLaserOpt7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt7.Location = New System.Drawing.Point(388, 33)
        Me.rbLaserOpt7.Name = "rbLaserOpt7"
        Me.rbLaserOpt7.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt7.TabIndex = 9
        Me.rbLaserOpt7.Text = "7"
        Me.rbLaserOpt7.UseVisualStyleBackColor = False
        '
        'rbLaserOpt3
        '
        Me.rbLaserOpt3.AutoSize = True
        Me.rbLaserOpt3.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt3.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt3.CircleCheckedRadius = 8
        Me.rbLaserOpt3.CircleCheckedX = 2
        Me.rbLaserOpt3.CircleCheckedY = 2
        Me.rbLaserOpt3.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt3.CircleGlintSize = 5
        Me.rbLaserOpt3.CircleGlintX = 5
        Me.rbLaserOpt3.CircleGlintY = 5
        Me.rbLaserOpt3.CircleRadius = 10
        Me.rbLaserOpt3.CircleWidth = 1.0!
        Me.rbLaserOpt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt3.Location = New System.Drawing.Point(176, 33)
        Me.rbLaserOpt3.Name = "rbLaserOpt3"
        Me.rbLaserOpt3.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt3.TabIndex = 9
        Me.rbLaserOpt3.Text = "3"
        Me.rbLaserOpt3.UseVisualStyleBackColor = False
        '
        'rbLaserOpt6
        '
        Me.rbLaserOpt6.AutoSize = True
        Me.rbLaserOpt6.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt6.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt6.CircleCheckedRadius = 8
        Me.rbLaserOpt6.CircleCheckedX = 2
        Me.rbLaserOpt6.CircleCheckedY = 2
        Me.rbLaserOpt6.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt6.CircleGlintSize = 5
        Me.rbLaserOpt6.CircleGlintX = 5
        Me.rbLaserOpt6.CircleGlintY = 5
        Me.rbLaserOpt6.CircleRadius = 10
        Me.rbLaserOpt6.CircleWidth = 1.0!
        Me.rbLaserOpt6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt6.Location = New System.Drawing.Point(335, 33)
        Me.rbLaserOpt6.Name = "rbLaserOpt6"
        Me.rbLaserOpt6.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt6.TabIndex = 9
        Me.rbLaserOpt6.Text = "6"
        Me.rbLaserOpt6.UseVisualStyleBackColor = False
        '
        'rbLaserOpt2
        '
        Me.rbLaserOpt2.AutoSize = True
        Me.rbLaserOpt2.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt2.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt2.CircleCheckedRadius = 8
        Me.rbLaserOpt2.CircleCheckedX = 2
        Me.rbLaserOpt2.CircleCheckedY = 2
        Me.rbLaserOpt2.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt2.CircleGlintSize = 5
        Me.rbLaserOpt2.CircleGlintX = 5
        Me.rbLaserOpt2.CircleGlintY = 5
        Me.rbLaserOpt2.CircleRadius = 10
        Me.rbLaserOpt2.CircleWidth = 1.0!
        Me.rbLaserOpt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt2.Location = New System.Drawing.Point(123, 33)
        Me.rbLaserOpt2.Name = "rbLaserOpt2"
        Me.rbLaserOpt2.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt2.TabIndex = 9
        Me.rbLaserOpt2.Text = "2"
        Me.rbLaserOpt2.UseVisualStyleBackColor = False
        '
        'rbLaserOpt5
        '
        Me.rbLaserOpt5.AutoSize = True
        Me.rbLaserOpt5.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt5.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt5.CircleCheckedRadius = 8
        Me.rbLaserOpt5.CircleCheckedX = 2
        Me.rbLaserOpt5.CircleCheckedY = 2
        Me.rbLaserOpt5.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt5.CircleGlintSize = 5
        Me.rbLaserOpt5.CircleGlintX = 5
        Me.rbLaserOpt5.CircleGlintY = 5
        Me.rbLaserOpt5.CircleRadius = 10
        Me.rbLaserOpt5.CircleWidth = 1.0!
        Me.rbLaserOpt5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt5.Location = New System.Drawing.Point(282, 33)
        Me.rbLaserOpt5.Name = "rbLaserOpt5"
        Me.rbLaserOpt5.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt5.TabIndex = 9
        Me.rbLaserOpt5.Text = "5"
        Me.rbLaserOpt5.UseVisualStyleBackColor = False
        '
        'rbLaserOpt1
        '
        Me.rbLaserOpt1.AutoSize = True
        Me.rbLaserOpt1.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt1.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt1.CircleCheckedRadius = 8
        Me.rbLaserOpt1.CircleCheckedX = 2
        Me.rbLaserOpt1.CircleCheckedY = 2
        Me.rbLaserOpt1.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt1.CircleGlintSize = 5
        Me.rbLaserOpt1.CircleGlintX = 5
        Me.rbLaserOpt1.CircleGlintY = 5
        Me.rbLaserOpt1.CircleRadius = 10
        Me.rbLaserOpt1.CircleWidth = 1.0!
        Me.rbLaserOpt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt1.Location = New System.Drawing.Point(70, 33)
        Me.rbLaserOpt1.Name = "rbLaserOpt1"
        Me.rbLaserOpt1.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt1.TabIndex = 9
        Me.rbLaserOpt1.Text = "1"
        Me.rbLaserOpt1.UseVisualStyleBackColor = False
        '
        'rbLaserOpt4
        '
        Me.rbLaserOpt4.AutoSize = True
        Me.rbLaserOpt4.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt4.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt4.CircleCheckedRadius = 8
        Me.rbLaserOpt4.CircleCheckedX = 2
        Me.rbLaserOpt4.CircleCheckedY = 2
        Me.rbLaserOpt4.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt4.CircleGlintSize = 5
        Me.rbLaserOpt4.CircleGlintX = 5
        Me.rbLaserOpt4.CircleGlintY = 5
        Me.rbLaserOpt4.CircleRadius = 10
        Me.rbLaserOpt4.CircleWidth = 1.0!
        Me.rbLaserOpt4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt4.Location = New System.Drawing.Point(229, 33)
        Me.rbLaserOpt4.Name = "rbLaserOpt4"
        Me.rbLaserOpt4.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt4.TabIndex = 9
        Me.rbLaserOpt4.Text = "4"
        Me.rbLaserOpt4.UseVisualStyleBackColor = False
        '
        'rbLaserOpt0
        '
        Me.rbLaserOpt0.AutoSize = True
        Me.rbLaserOpt0.BackColor = System.Drawing.SystemColors.Control
        Me.rbLaserOpt0.Checked = True
        Me.rbLaserOpt0.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbLaserOpt0.CircleCheckedRadius = 8
        Me.rbLaserOpt0.CircleCheckedX = 2
        Me.rbLaserOpt0.CircleCheckedY = 2
        Me.rbLaserOpt0.CircleColor = System.Drawing.Color.DimGray
        Me.rbLaserOpt0.CircleGlintSize = 5
        Me.rbLaserOpt0.CircleGlintX = 5
        Me.rbLaserOpt0.CircleGlintY = 5
        Me.rbLaserOpt0.CircleRadius = 10
        Me.rbLaserOpt0.CircleWidth = 1.0!
        Me.rbLaserOpt0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbLaserOpt0.Location = New System.Drawing.Point(17, 33)
        Me.rbLaserOpt0.Name = "rbLaserOpt0"
        Me.rbLaserOpt0.Size = New System.Drawing.Size(36, 24)
        Me.rbLaserOpt0.TabIndex = 9
        Me.rbLaserOpt0.TabStop = True
        Me.rbLaserOpt0.Text = "0"
        Me.rbLaserOpt0.UseVisualStyleBackColor = False
        '
        'rbAbs
        '
        Me.rbAbs.AutoSize = True
        Me.rbAbs.BackColor = System.Drawing.SystemColors.Control
        Me.rbAbs.Checked = True
        Me.rbAbs.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbAbs.CircleCheckedRadius = 8
        Me.rbAbs.CircleCheckedX = 2
        Me.rbAbs.CircleCheckedY = 2
        Me.rbAbs.CircleColor = System.Drawing.Color.DimGray
        Me.rbAbs.CircleGlintSize = 5
        Me.rbAbs.CircleGlintX = 5
        Me.rbAbs.CircleGlintY = 5
        Me.rbAbs.CircleRadius = 10
        Me.rbAbs.CircleWidth = 1.0!
        Me.rbAbs.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAbs.Location = New System.Drawing.Point(0, 1)
        Me.rbAbs.Name = "rbAbs"
        Me.rbAbs.Size = New System.Drawing.Size(55, 24)
        Me.rbAbs.TabIndex = 9
        Me.rbAbs.TabStop = True
        Me.rbAbs.Text = "Abs"
        Me.rbAbs.UseVisualStyleBackColor = False
        '
        'rbRatio
        '
        Me.rbRatio.AutoSize = True
        Me.rbRatio.BackColor = System.Drawing.SystemColors.Control
        Me.rbRatio.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbRatio.CircleCheckedRadius = 8
        Me.rbRatio.CircleCheckedX = 2
        Me.rbRatio.CircleCheckedY = 2
        Me.rbRatio.CircleColor = System.Drawing.Color.DimGray
        Me.rbRatio.CircleGlintSize = 5
        Me.rbRatio.CircleGlintX = 5
        Me.rbRatio.CircleGlintY = 5
        Me.rbRatio.CircleRadius = 10
        Me.rbRatio.CircleWidth = 1.0!
        Me.rbRatio.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRatio.Location = New System.Drawing.Point(80, 1)
        Me.rbRatio.Name = "rbRatio"
        Me.rbRatio.Size = New System.Drawing.Size(65, 24)
        Me.rbRatio.TabIndex = 9
        Me.rbRatio.Text = "Ratio"
        Me.rbRatio.UseVisualStyleBackColor = False
        '
        'rbFeederOpt3
        '
        Me.rbFeederOpt3.AutoSize = True
        Me.rbFeederOpt3.BackColor = System.Drawing.SystemColors.Control
        Me.rbFeederOpt3.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbFeederOpt3.CircleCheckedRadius = 8
        Me.rbFeederOpt3.CircleCheckedX = 2
        Me.rbFeederOpt3.CircleCheckedY = 2
        Me.rbFeederOpt3.CircleColor = System.Drawing.Color.DimGray
        Me.rbFeederOpt3.CircleGlintSize = 5
        Me.rbFeederOpt3.CircleGlintX = 5
        Me.rbFeederOpt3.CircleGlintY = 5
        Me.rbFeederOpt3.CircleRadius = 10
        Me.rbFeederOpt3.CircleWidth = 1.0!
        Me.rbFeederOpt3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFeederOpt3.Location = New System.Drawing.Point(232, 34)
        Me.rbFeederOpt3.Name = "rbFeederOpt3"
        Me.rbFeederOpt3.Size = New System.Drawing.Size(36, 24)
        Me.rbFeederOpt3.TabIndex = 9
        Me.rbFeederOpt3.Text = "3"
        Me.rbFeederOpt3.UseVisualStyleBackColor = False
        '
        'rbFeederOpt2
        '
        Me.rbFeederOpt2.AutoSize = True
        Me.rbFeederOpt2.BackColor = System.Drawing.SystemColors.Control
        Me.rbFeederOpt2.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbFeederOpt2.CircleCheckedRadius = 8
        Me.rbFeederOpt2.CircleCheckedX = 2
        Me.rbFeederOpt2.CircleCheckedY = 2
        Me.rbFeederOpt2.CircleColor = System.Drawing.Color.DimGray
        Me.rbFeederOpt2.CircleGlintSize = 5
        Me.rbFeederOpt2.CircleGlintX = 5
        Me.rbFeederOpt2.CircleGlintY = 5
        Me.rbFeederOpt2.CircleRadius = 10
        Me.rbFeederOpt2.CircleWidth = 1.0!
        Me.rbFeederOpt2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFeederOpt2.Location = New System.Drawing.Point(164, 34)
        Me.rbFeederOpt2.Name = "rbFeederOpt2"
        Me.rbFeederOpt2.Size = New System.Drawing.Size(36, 24)
        Me.rbFeederOpt2.TabIndex = 9
        Me.rbFeederOpt2.Text = "2"
        Me.rbFeederOpt2.UseVisualStyleBackColor = False
        '
        'rbFeederOpt1
        '
        Me.rbFeederOpt1.AutoSize = True
        Me.rbFeederOpt1.BackColor = System.Drawing.SystemColors.Control
        Me.rbFeederOpt1.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbFeederOpt1.CircleCheckedRadius = 8
        Me.rbFeederOpt1.CircleCheckedX = 2
        Me.rbFeederOpt1.CircleCheckedY = 2
        Me.rbFeederOpt1.CircleColor = System.Drawing.Color.DimGray
        Me.rbFeederOpt1.CircleGlintSize = 5
        Me.rbFeederOpt1.CircleGlintX = 5
        Me.rbFeederOpt1.CircleGlintY = 5
        Me.rbFeederOpt1.CircleRadius = 10
        Me.rbFeederOpt1.CircleWidth = 1.0!
        Me.rbFeederOpt1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFeederOpt1.Location = New System.Drawing.Point(96, 34)
        Me.rbFeederOpt1.Name = "rbFeederOpt1"
        Me.rbFeederOpt1.Size = New System.Drawing.Size(36, 24)
        Me.rbFeederOpt1.TabIndex = 9
        Me.rbFeederOpt1.Text = "1"
        Me.rbFeederOpt1.UseVisualStyleBackColor = False
        '
        'rbFeederOpt0
        '
        Me.rbFeederOpt0.AutoSize = True
        Me.rbFeederOpt0.BackColor = System.Drawing.SystemColors.Control
        Me.rbFeederOpt0.Checked = True
        Me.rbFeederOpt0.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbFeederOpt0.CircleCheckedRadius = 8
        Me.rbFeederOpt0.CircleCheckedX = 2
        Me.rbFeederOpt0.CircleCheckedY = 2
        Me.rbFeederOpt0.CircleColor = System.Drawing.Color.DimGray
        Me.rbFeederOpt0.CircleGlintSize = 5
        Me.rbFeederOpt0.CircleGlintX = 5
        Me.rbFeederOpt0.CircleGlintY = 5
        Me.rbFeederOpt0.CircleRadius = 10
        Me.rbFeederOpt0.CircleWidth = 1.0!
        Me.rbFeederOpt0.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFeederOpt0.Location = New System.Drawing.Point(28, 34)
        Me.rbFeederOpt0.Name = "rbFeederOpt0"
        Me.rbFeederOpt0.Size = New System.Drawing.Size(36, 24)
        Me.rbFeederOpt0.TabIndex = 9
        Me.rbFeederOpt0.TabStop = True
        Me.rbFeederOpt0.Text = "0"
        Me.rbFeederOpt0.UseVisualStyleBackColor = False
        '
        'chkSolderingTime
        '
        Me.chkSolderingTime.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkSolderingTime.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkSolderingTime.BoxColor = System.Drawing.Color.SteelBlue
        Me.chkSolderingTime.BoxLocationX = 0
        Me.chkSolderingTime.BoxLocationY = 3
        Me.chkSolderingTime.BoxSize = 15
        Me.chkSolderingTime.BoxSpacing = CType(2UI, UInteger)
        Me.chkSolderingTime.DoubleBorder = True
        Me.chkSolderingTime.FlatAppearance.BorderSize = 0
        Me.chkSolderingTime.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkSolderingTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkSolderingTime.Location = New System.Drawing.Point(482, 0)
        Me.chkSolderingTime.Name = "chkSolderingTime"
        Me.chkSolderingTime.Size = New System.Drawing.Size(145, 25)
        Me.chkSolderingTime.TabIndex = 8
        Me.chkSolderingTime.Text = "Soldering Time"
        Me.chkSolderingTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkSolderingTime.TextLocationX = 20
        Me.chkSolderingTime.TextLocationY = 1
        Me.chkSolderingTime.TickColor = System.Drawing.Color.SteelBlue
        Me.chkSolderingTime.TickLeftPosition = -5.0!
        Me.chkSolderingTime.TickSize = 20.0!
        Me.chkSolderingTime.TickTopPosition = -5.0!
        Me.chkSolderingTime.UseVisualStyleBackColor = True
        '
        'chkRecord
        '
        Me.chkRecord.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRecord.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkRecord.BoxColor = System.Drawing.Color.SteelBlue
        Me.chkRecord.BoxLocationX = 0
        Me.chkRecord.BoxLocationY = 3
        Me.chkRecord.BoxSize = 15
        Me.chkRecord.BoxSpacing = CType(2UI, UInteger)
        Me.chkRecord.DoubleBorder = True
        Me.chkRecord.FlatAppearance.BorderSize = 0
        Me.chkRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRecord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRecord.Location = New System.Drawing.Point(633, 0)
        Me.chkRecord.Name = "chkRecord"
        Me.chkRecord.Size = New System.Drawing.Size(86, 25)
        Me.chkRecord.TabIndex = 9
        Me.chkRecord.Text = "Record"
        Me.chkRecord.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRecord.TextLocationX = 20
        Me.chkRecord.TextLocationY = 1
        Me.chkRecord.TickColor = System.Drawing.Color.SteelBlue
        Me.chkRecord.TickLeftPosition = -5.0!
        Me.chkRecord.TickSize = 20.0!
        Me.chkRecord.TickTopPosition = -5.0!
        Me.chkRecord.UseVisualStyleBackColor = True
        '
        'chkRuler
        '
        Me.chkRuler.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkRuler.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkRuler.BoxColor = System.Drawing.Color.SteelBlue
        Me.chkRuler.BoxLocationX = 0
        Me.chkRuler.BoxLocationY = 3
        Me.chkRuler.BoxSize = 15
        Me.chkRuler.BoxSpacing = CType(2UI, UInteger)
        Me.chkRuler.DoubleBorder = True
        Me.chkRuler.FlatAppearance.BorderSize = 0
        Me.chkRuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkRuler.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkRuler.Location = New System.Drawing.Point(722, 0)
        Me.chkRuler.Name = "chkRuler"
        Me.chkRuler.Size = New System.Drawing.Size(72, 25)
        Me.chkRuler.TabIndex = 10
        Me.chkRuler.Text = "Ruler"
        Me.chkRuler.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkRuler.TextLocationX = 20
        Me.chkRuler.TextLocationY = 1
        Me.chkRuler.TickColor = System.Drawing.Color.SteelBlue
        Me.chkRuler.TickLeftPosition = -5.0!
        Me.chkRuler.TickSize = 20.0!
        Me.chkRuler.TickTopPosition = -5.0!
        Me.chkRuler.UseVisualStyleBackColor = True
        '
        'ButtonEx5
        '
        Me.ButtonEx5.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx5.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx5.Direction = LaserSolder.eArrow.Up
        Me.ButtonEx5.FlatAppearance.BorderSize = 0
        Me.ButtonEx5.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx5.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonEx5.Location = New System.Drawing.Point(0, 0)
        Me.ButtonEx5.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx5.Name = "ButtonEx5"
        Me.ButtonEx5.Radius = 1.0!
        Me.ButtonEx5.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx5.TabIndex = 24
        Me.ButtonEx5.UseVisualStyleBackColor = False
        '
        'ButtonEx6
        '
        Me.ButtonEx6.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx6.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx6.Direction = LaserSolder.eArrow.Down
        Me.ButtonEx6.FlatAppearance.BorderSize = 0
        Me.ButtonEx6.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx6.Location = New System.Drawing.Point(0, 78)
        Me.ButtonEx6.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx6.Name = "ButtonEx6"
        Me.ButtonEx6.Radius = 1.0!
        Me.ButtonEx6.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx6.TabIndex = 24
        Me.ButtonEx6.UseVisualStyleBackColor = False
        '
        'ButtonEx1
        '
        Me.ButtonEx1.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx1.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx1.Direction = LaserSolder.eArrow.Up
        Me.ButtonEx1.FlatAppearance.BorderSize = 0
        Me.ButtonEx1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx1.ForeColor = System.Drawing.SystemColors.Control
        Me.ButtonEx1.Location = New System.Drawing.Point(40, 0)
        Me.ButtonEx1.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx1.Name = "ButtonEx1"
        Me.ButtonEx1.Radius = 1.0!
        Me.ButtonEx1.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx1.TabIndex = 24
        Me.ButtonEx1.UseVisualStyleBackColor = False
        '
        'ButtonEx2
        '
        Me.ButtonEx2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx2.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx2.Direction = LaserSolder.eArrow.Left
        Me.ButtonEx2.FlatAppearance.BorderSize = 0
        Me.ButtonEx2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx2.Location = New System.Drawing.Point(0, 39)
        Me.ButtonEx2.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx2.Name = "ButtonEx2"
        Me.ButtonEx2.Radius = 1.0!
        Me.ButtonEx2.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx2.TabIndex = 24
        Me.ButtonEx2.UseVisualStyleBackColor = False
        '
        'ButtonEx4
        '
        Me.ButtonEx4.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx4.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx4.Direction = LaserSolder.eArrow.Right
        Me.ButtonEx4.FlatAppearance.BorderSize = 0
        Me.ButtonEx4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx4.Location = New System.Drawing.Point(80, 39)
        Me.ButtonEx4.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx4.Name = "ButtonEx4"
        Me.ButtonEx4.Radius = 1.0!
        Me.ButtonEx4.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx4.TabIndex = 24
        Me.ButtonEx4.UseVisualStyleBackColor = False
        '
        'ButtonEx3
        '
        Me.ButtonEx3.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.ButtonEx3.ButtonType = LaserSolder.eButtonType.Arrow
        Me.ButtonEx3.Direction = LaserSolder.eArrow.Down
        Me.ButtonEx3.FlatAppearance.BorderSize = 0
        Me.ButtonEx3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.ButtonEx3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ButtonEx3.Location = New System.Drawing.Point(40, 78)
        Me.ButtonEx3.Margin = New System.Windows.Forms.Padding(0)
        Me.ButtonEx3.Name = "ButtonEx3"
        Me.ButtonEx3.Radius = 1.0!
        Me.ButtonEx3.Size = New System.Drawing.Size(40, 39)
        Me.ButtonEx3.TabIndex = 24
        Me.ButtonEx3.UseVisualStyleBackColor = False
        '
        'rbFeed
        '
        Me.rbFeed.AutoSize = True
        Me.rbFeed.BackColor = System.Drawing.SystemColors.Control
        Me.rbFeed.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbFeed.CircleCheckedRadius = 8
        Me.rbFeed.CircleCheckedX = 2
        Me.rbFeed.CircleCheckedY = 2
        Me.rbFeed.CircleColor = System.Drawing.Color.DimGray
        Me.rbFeed.CircleGlintSize = 5
        Me.rbFeed.CircleGlintX = 5
        Me.rbFeed.CircleGlintY = 5
        Me.rbFeed.CircleRadius = 10
        Me.rbFeed.CircleWidth = 1.0!
        Me.rbFeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFeed.Location = New System.Drawing.Point(500, 5)
        Me.rbFeed.Name = "rbFeed"
        Me.rbFeed.Size = New System.Drawing.Size(64, 24)
        Me.rbFeed.TabIndex = 8
        Me.rbFeed.Text = "Feed"
        Me.rbFeed.UseVisualStyleBackColor = False
        '
        'rbActiveAxisR
        '
        Me.rbActiveAxisR.AutoSize = True
        Me.rbActiveAxisR.BackColor = System.Drawing.SystemColors.Control
        Me.rbActiveAxisR.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisR.CircleCheckedRadius = 8
        Me.rbActiveAxisR.CircleCheckedX = 2
        Me.rbActiveAxisR.CircleCheckedY = 2
        Me.rbActiveAxisR.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisR.CircleGlintSize = 5
        Me.rbActiveAxisR.CircleGlintX = 5
        Me.rbActiveAxisR.CircleGlintY = 5
        Me.rbActiveAxisR.CircleRadius = 10
        Me.rbActiveAxisR.CircleWidth = 1.0!
        Me.rbActiveAxisR.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisR.Location = New System.Drawing.Point(435, 5)
        Me.rbActiveAxisR.Name = "rbActiveAxisR"
        Me.rbActiveAxisR.Size = New System.Drawing.Size(39, 24)
        Me.rbActiveAxisR.TabIndex = 8
        Me.rbActiveAxisR.Text = "R"
        Me.rbActiveAxisR.UseVisualStyleBackColor = False
        '
        'rbActiveAxisZ
        '
        Me.rbActiveAxisZ.AutoSize = True
        Me.rbActiveAxisZ.BackColor = System.Drawing.SystemColors.Control
        Me.rbActiveAxisZ.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisZ.CircleCheckedRadius = 8
        Me.rbActiveAxisZ.CircleCheckedX = 2
        Me.rbActiveAxisZ.CircleCheckedY = 2
        Me.rbActiveAxisZ.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisZ.CircleGlintSize = 5
        Me.rbActiveAxisZ.CircleGlintX = 5
        Me.rbActiveAxisZ.CircleGlintY = 5
        Me.rbActiveAxisZ.CircleRadius = 10
        Me.rbActiveAxisZ.CircleWidth = 1.0!
        Me.rbActiveAxisZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisZ.Location = New System.Drawing.Point(375, 5)
        Me.rbActiveAxisZ.Name = "rbActiveAxisZ"
        Me.rbActiveAxisZ.Size = New System.Drawing.Size(37, 24)
        Me.rbActiveAxisZ.TabIndex = 8
        Me.rbActiveAxisZ.Text = "Z"
        Me.rbActiveAxisZ.UseVisualStyleBackColor = False
        '
        'rbActiveAxisY
        '
        Me.rbActiveAxisY.AutoSize = True
        Me.rbActiveAxisY.BackColor = System.Drawing.SystemColors.Control
        Me.rbActiveAxisY.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisY.CircleCheckedRadius = 8
        Me.rbActiveAxisY.CircleCheckedX = 2
        Me.rbActiveAxisY.CircleCheckedY = 2
        Me.rbActiveAxisY.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisY.CircleGlintSize = 5
        Me.rbActiveAxisY.CircleGlintX = 5
        Me.rbActiveAxisY.CircleGlintY = 5
        Me.rbActiveAxisY.CircleRadius = 10
        Me.rbActiveAxisY.CircleWidth = 1.0!
        Me.rbActiveAxisY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisY.Location = New System.Drawing.Point(313, 5)
        Me.rbActiveAxisY.Name = "rbActiveAxisY"
        Me.rbActiveAxisY.Size = New System.Drawing.Size(38, 24)
        Me.rbActiveAxisY.TabIndex = 8
        Me.rbActiveAxisY.Text = "Y"
        Me.rbActiveAxisY.UseVisualStyleBackColor = False
        '
        'rbActiveAxisX
        '
        Me.rbActiveAxisX.AutoSize = True
        Me.rbActiveAxisX.BackColor = System.Drawing.SystemColors.Control
        Me.rbActiveAxisX.Checked = True
        Me.rbActiveAxisX.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisX.CircleCheckedRadius = 8
        Me.rbActiveAxisX.CircleCheckedX = 2
        Me.rbActiveAxisX.CircleCheckedY = 2
        Me.rbActiveAxisX.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisX.CircleGlintSize = 5
        Me.rbActiveAxisX.CircleGlintX = 5
        Me.rbActiveAxisX.CircleGlintY = 5
        Me.rbActiveAxisX.CircleRadius = 10
        Me.rbActiveAxisX.CircleWidth = 1.0!
        Me.rbActiveAxisX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisX.Location = New System.Drawing.Point(251, 5)
        Me.rbActiveAxisX.Name = "rbActiveAxisX"
        Me.rbActiveAxisX.Size = New System.Drawing.Size(38, 24)
        Me.rbActiveAxisX.TabIndex = 8
        Me.rbActiveAxisX.TabStop = True
        Me.rbActiveAxisX.Text = "X"
        Me.rbActiveAxisX.UseVisualStyleBackColor = False
        '
        'rbX100
        '
        Me.rbX100.AutoSize = True
        Me.rbX100.BackColor = System.Drawing.SystemColors.Control
        Me.rbX100.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbX100.CircleCheckedRadius = 8
        Me.rbX100.CircleCheckedX = 2
        Me.rbX100.CircleCheckedY = 2
        Me.rbX100.CircleColor = System.Drawing.Color.DimGray
        Me.rbX100.CircleGlintSize = 5
        Me.rbX100.CircleGlintX = 5
        Me.rbX100.CircleGlintY = 5
        Me.rbX100.CircleRadius = 10
        Me.rbX100.CircleWidth = 1.0!
        Me.rbX100.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbX100.Location = New System.Drawing.Point(131, 3)
        Me.rbX100.Name = "rbX100"
        Me.rbX100.Size = New System.Drawing.Size(61, 24)
        Me.rbX100.TabIndex = 8
        Me.rbX100.Text = "x100"
        Me.rbX100.UseVisualStyleBackColor = False
        '
        'rbX1
        '
        Me.rbX1.AutoSize = True
        Me.rbX1.BackColor = System.Drawing.SystemColors.Control
        Me.rbX1.Checked = True
        Me.rbX1.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbX1.CircleCheckedRadius = 8
        Me.rbX1.CircleCheckedX = 2
        Me.rbX1.CircleCheckedY = 2
        Me.rbX1.CircleColor = System.Drawing.Color.DimGray
        Me.rbX1.CircleGlintSize = 5
        Me.rbX1.CircleGlintX = 5
        Me.rbX1.CircleGlintY = 5
        Me.rbX1.CircleRadius = 10
        Me.rbX1.CircleWidth = 1.0!
        Me.rbX1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbX1.Location = New System.Drawing.Point(7, 3)
        Me.rbX1.Name = "rbX1"
        Me.rbX1.Size = New System.Drawing.Size(43, 24)
        Me.rbX1.TabIndex = 8
        Me.rbX1.TabStop = True
        Me.rbX1.Text = "x1"
        Me.rbX1.UseVisualStyleBackColor = False
        '
        'rbX10
        '
        Me.rbX10.AutoSize = True
        Me.rbX10.BackColor = System.Drawing.SystemColors.Control
        Me.rbX10.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbX10.CircleCheckedRadius = 8
        Me.rbX10.CircleCheckedX = 2
        Me.rbX10.CircleCheckedY = 2
        Me.rbX10.CircleColor = System.Drawing.Color.DimGray
        Me.rbX10.CircleGlintSize = 5
        Me.rbX10.CircleGlintX = 5
        Me.rbX10.CircleGlintY = 5
        Me.rbX10.CircleRadius = 10
        Me.rbX10.CircleWidth = 1.0!
        Me.rbX10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbX10.Location = New System.Drawing.Point(69, 3)
        Me.rbX10.Name = "rbX10"
        Me.rbX10.Size = New System.Drawing.Size(52, 24)
        Me.rbX10.TabIndex = 8
        Me.rbX10.Text = "x10"
        Me.rbX10.UseVisualStyleBackColor = False
        '
        'FJobManager
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1240, 1071)
        Me.Controls.Add(Me.btnRegisterGPoint)
        Me.Controls.Add(Me.ptbSolderingTime)
        Me.Controls.Add(Me.grbCamera)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1920, 1124)
        Me.MinimizeBox = False
        Me.Name = "FJobManager"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Job Manager"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.tbSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        CType(Me.tbPower1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbPower5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel9.ResumeLayout(False)
        Me.Panel9.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip2.ResumeLayout(False)
        CType(Me.ptbSolderingTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grbCamera.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtPositionR As System.Windows.Forms.TextBox
    Friend WithEvents txtPositionZ As System.Windows.Forms.TextBox
    Friend WithEvents txtPositionY As System.Windows.Forms.TextBox
    Friend WithEvents txtPositionX As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnRegisterGPoint As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtDistance As System.Windows.Forms.TextBox
    Friend WithEvents txtAxisUnit As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnPositionMinus As System.Windows.Forms.Button
    Friend WithEvents btnPositionAdd As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tbSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents btnMoveToReadyPosition As System.Windows.Forms.Button
    Friend WithEvents btnResetRobotAlarm As System.Windows.Forms.Button
    Friend WithEvents btnJobFromLaserTestZ As System.Windows.Forms.Button
    Friend WithEvents btnJobToLaserTestZ As System.Windows.Forms.Button
    Friend WithEvents ImageDisplay1 As VisionSystem.ImageDisplay
    Friend WithEvents btnZero As System.Windows.Forms.Button
    Friend WithEvents txtHeight As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAddPoint As System.Windows.Forms.Button
    Friend WithEvents btnAddLine As System.Windows.Forms.Button
    Friend WithEvents btnAddAxis As System.Windows.Forms.Button
    Friend WithEvents btnAddIO As System.Windows.Forms.Button
    Friend WithEvents btnAddHome As System.Windows.Forms.Button
    Friend WithEvents btnAddDischarge As System.Windows.Forms.Button
    Friend WithEvents btnAddLamp As System.Windows.Forms.Button
    Friend WithEvents btnAddLotEnd As System.Windows.Forms.Button
    Friend WithEvents btnAddBlow As System.Windows.Forms.Button
    Friend WithEvents btnAddAlign As System.Windows.Forms.Button
    Friend WithEvents btnAddBarcode As System.Windows.Forms.Button
    Friend WithEvents btnAddPallet As System.Windows.Forms.Button
    Friend WithEvents btnAddRepeat As System.Windows.Forms.Button
    Friend WithEvents btnAddIF As System.Windows.Forms.Button
    Friend WithEvents btnAddStandby As System.Windows.Forms.Button
    Friend WithEvents btnAddJump As System.Windows.Forms.Button
    Friend WithEvents btnAddWait As System.Windows.Forms.Button
    Friend WithEvents btnAddTackBegin As System.Windows.Forms.Button
    Friend WithEvents btnAddTackEnd As System.Windows.Forms.Button
    Friend WithEvents btnAddRecordStart As System.Windows.Forms.Button
    Friend WithEvents btnAddRecordStop As System.Windows.Forms.Button
    Friend WithEvents btnAddGVariable As System.Windows.Forms.Button
    Friend WithEvents tvJobs As System.Windows.Forms.TreeView
    Friend WithEvents btnBuildProgram As System.Windows.Forms.Button
    Friend WithEvents btnPointSoldering As System.Windows.Forms.Button
    Friend WithEvents pgJobProperty As System.Windows.Forms.PropertyGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtForwardDistance1 As System.Windows.Forms.TextBox
    Friend WithEvents txtForwardSpeedPercent1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBackwardDistancemm As System.Windows.Forms.TextBox
    Friend WithEvents txtBackwardSpeedPercent As System.Windows.Forms.TextBox
    Friend WithEvents txtBackwardDelay As System.Windows.Forms.TextBox
    Friend WithEvents txtForwardDistance2 As System.Windows.Forms.TextBox
    Friend WithEvents txtForwardSpeedPercent2 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtForwardDelay As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents btnSaveFeeder As System.Windows.Forms.Button
    Friend WithEvents btnRunFeeder As System.Windows.Forms.Button
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents btnSoldering As System.Windows.Forms.Button
    Friend WithEvents btnLighting As System.Windows.Forms.Button
    Friend WithEvents btnBlowing As System.Windows.Forms.Button
    Friend WithEvents btnRedBeam As System.Windows.Forms.Button
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Button40 As System.Windows.Forms.Button
    Friend WithEvents Button39 As System.Windows.Forms.Button
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents Button41 As System.Windows.Forms.Button
    Friend WithEvents Button50 As System.Windows.Forms.Button
    Friend WithEvents tbPower8 As System.Windows.Forms.TrackBar
    Friend WithEvents Button49 As System.Windows.Forms.Button
    Friend WithEvents Button58 As System.Windows.Forms.Button
    Friend WithEvents tbPower7 As System.Windows.Forms.TrackBar
    Friend WithEvents Button48 As System.Windows.Forms.Button
    Friend WithEvents Button57 As System.Windows.Forms.Button
    Friend WithEvents tbPower6 As System.Windows.Forms.TrackBar
    Friend WithEvents Button47 As System.Windows.Forms.Button
    Friend WithEvents Button56 As System.Windows.Forms.Button
    Friend WithEvents tbPower5 As System.Windows.Forms.TrackBar
    Friend WithEvents Button46 As System.Windows.Forms.Button
    Friend WithEvents Button55 As System.Windows.Forms.Button
    Friend WithEvents tbPower4 As System.Windows.Forms.TrackBar
    Friend WithEvents Button45 As System.Windows.Forms.Button
    Friend WithEvents Button54 As System.Windows.Forms.Button
    Friend WithEvents tbPower3 As System.Windows.Forms.TrackBar
    Friend WithEvents Button44 As System.Windows.Forms.Button
    Friend WithEvents Button53 As System.Windows.Forms.Button
    Friend WithEvents tbPower2 As System.Windows.Forms.TrackBar
    Friend WithEvents Button43 As System.Windows.Forms.Button
    Friend WithEvents Button52 As System.Windows.Forms.Button
    Friend WithEvents Button42 As System.Windows.Forms.Button
    Friend WithEvents Button51 As System.Windows.Forms.Button
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents txtSpotSize As System.Windows.Forms.TextBox
    Friend WithEvents txtIntervalTime As System.Windows.Forms.TextBox
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents btnSaveLaser As System.Windows.Forms.Button
    Friend WithEvents btnStopLaser As System.Windows.Forms.Button
    Friend WithEvents btnRunLaser As System.Windows.Forms.Button
    Friend WithEvents btnJobZ As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEx1 As LaserSolder.ButtonEx
    Friend WithEvents ButtonEx2 As LaserSolder.ButtonEx
    Friend WithEvents ButtonEx3 As LaserSolder.ButtonEx
    Friend WithEvents ButtonEx4 As LaserSolder.ButtonEx
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ButtonEx5 As LaserSolder.ButtonEx
    Friend WithEvents ButtonEx6 As LaserSolder.ButtonEx
    Friend WithEvents btnFeedCounterClockwise As System.Windows.Forms.Button
    Friend WithEvents btnFeedClockwise As System.Windows.Forms.Button
    Friend WithEvents chkSolderingTime As LaserSolder.CheckBoxEx
    Friend WithEvents chkRecord As LaserSolder.CheckBoxEx
    Friend WithEvents chkRuler As LaserSolder.CheckBoxEx
    Friend WithEvents rbEach As LaserSolder.RadioButtonEx
    Friend WithEvents rbAll As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisZ As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisY As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisX As LaserSolder.RadioButtonEx
    Friend WithEvents rbFeed As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisR As LaserSolder.RadioButtonEx
    Friend WithEvents rbX100 As LaserSolder.RadioButtonEx
    Friend WithEvents rbX1 As LaserSolder.RadioButtonEx
    Friend WithEvents rbX10 As LaserSolder.RadioButtonEx
    Friend WithEvents rbFeederOpt3 As LaserSolder.RadioButtonEx
    Friend WithEvents rbFeederOpt2 As LaserSolder.RadioButtonEx
    Friend WithEvents rbFeederOpt1 As LaserSolder.RadioButtonEx
    Friend WithEvents rbFeederOpt0 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt3 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt2 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt1 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt0 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt7 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt6 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt5 As LaserSolder.RadioButtonEx
    Friend WithEvents rbLaserOpt4 As LaserSolder.RadioButtonEx
    Friend WithEvents rbAbs As LaserSolder.RadioButtonEx
    Friend WithEvents rbRatio As LaserSolder.RadioButtonEx
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tbPower1 As System.Windows.Forms.TrackBar
    Friend WithEvents tbPower0 As System.Windows.Forms.TrackBar
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TopToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BottomToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents lblProperty As System.Windows.Forms.Label
    Friend WithEvents TimerDragTreeView As System.Windows.Forms.Timer
    Private WithEvents imageListTreeView As System.Windows.Forms.ImageList
    Private WithEvents imageListDrag As System.Windows.Forms.ImageList
    Friend WithEvents ptbSolderingTime As System.Windows.Forms.PictureBox
    Friend WithEvents grbCamera As LaserSolder.GroupBoxEx
    Friend WithEvents ContextMenuStrip2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowRulerToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TimerWorkholderValue As System.Windows.Forms.Timer
    Friend WithEvents TimerGetImagePoint As System.Windows.Forms.Timer
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel


End Class
