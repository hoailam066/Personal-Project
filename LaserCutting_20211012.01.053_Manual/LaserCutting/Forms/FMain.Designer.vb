<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ContextMenuStripMoveLine = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.UpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DownToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloneToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyLaserParameterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PasteLaserParameterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusX = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblStatusY = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblFilePath = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLaserPRR = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel5 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblLaserPower = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblXPx = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel7 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.lblYPx = New System.Windows.Forms.ToolStripStatusLabel()
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid()
        Me.tblEditTable = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAddLine = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.btnMainGuideOFF = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnPickColor = New System.Windows.Forms.Button()
        Me.btnEdit = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numPRR = New System.Windows.Forms.NumericUpDown()
        Me.numGalvoOffsetY = New System.Windows.Forms.NumericUpDown()
        Me.numGalvoOffsetX = New System.Windows.Forms.NumericUpDown()
        Me.numGalvoAngle = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numPower = New System.Windows.Forms.NumericUpDown()
        Me.numDIDelay = New System.Windows.Forms.NumericUpDown()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.numDODelay = New System.Windows.Forms.NumericUpDown()
        Me.numScaleLaserPRR = New System.Windows.Forms.NumericUpDown()
        Me.Label55 = New System.Windows.Forms.Label()
        Me.Label57 = New System.Windows.Forms.Label()
        Me.numScaleLaserPower = New System.Windows.Forms.NumericUpDown()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.numPX2MM = New System.Windows.Forms.NumericUpDown()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnStop = New System.Windows.Forms.Button()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.btnRotateCW = New System.Windows.Forms.Button()
        Me.btnRotateCCW = New System.Windows.Forms.Button()
        Me.btnMoveUp = New LaserCutting.ButtonEx()
        Me.btnMoveLeft = New LaserCutting.ButtonEx()
        Me.btnMoveDown = New LaserCutting.ButtonEx()
        Me.btnMoveRight = New LaserCutting.ButtonEx()
        Me.chkTest = New LaserCutting.CheckBoxEx()
        Me.btnGuideON = New System.Windows.Forms.Button()
        Me.btnGuideOFF = New System.Windows.Forms.Button()
        Me.btnCorrection = New System.Windows.Forms.Button()
        Me.btnGlavoHome = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.pnEdit = New System.Windows.Forms.Panel()
        Me.GroupBoxEx2 = New LaserCutting.GroupBoxEx()
        Me.cboFixPoint = New System.Windows.Forms.ComboBox()
        Me.Label62 = New System.Windows.Forms.Label()
        Me.numFixDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label64 = New System.Windows.Forms.Label()
        Me.GroupBoxEx1 = New LaserCutting.GroupBoxEx()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cboChoosePointForEdit = New System.Windows.Forms.ComboBox()
        Me.TableLayoutPanel15 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numRotateAngle = New System.Windows.Forms.NumericUpDown()
        Me.numMoveDistance = New System.Windows.Forms.NumericUpDown()
        Me.Label63 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel12 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnMainButton = New System.Windows.Forms.Panel()
        Me.btnDrawSelecting = New System.Windows.Forms.Button()
        Me.lbLog = New System.Windows.Forms.ListBox()
        Me.TabPageAlignment = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numWorkStep = New System.Windows.Forms.NumericUpDown()
        Me.numAcceptScoreAlign = New System.Windows.Forms.NumericUpDown()
        Me.btnAlignSetStart = New System.Windows.Forms.Button()
        Me.btnAlignTest = New System.Windows.Forms.Button()
        Me.TabPageLaserParam = New System.Windows.Forms.TabPage()
        Me.grbGalvoParameter = New System.Windows.Forms.GroupBox()
        Me.chkUseScale = New LaserCutting.CheckBoxEx()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.grbGraphicParameter = New System.Windows.Forms.GroupBox()
        Me.numImageOffsetY = New System.Windows.Forms.NumericUpDown()
        Me.numImageOffsetX = New System.Windows.Forms.NumericUpDown()
        Me.Label61 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label60 = New System.Windows.Forms.Label()
        Me.Label59 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnSaveParameter = New System.Windows.Forms.Button()
        Me.TabPageCorrection = New System.Windows.Forms.TabPage()
        Me.TabControl2 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.btnMarkAxis = New System.Windows.Forms.Button()
        Me.btnMarkLine = New System.Windows.Forms.Button()
        Me.btnReloadCorectionFile = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.PropertyGrid2 = New System.Windows.Forms.PropertyGrid()
        Me.btnEmissionOff = New System.Windows.Forms.Button()
        Me.btnEmissionOn = New System.Windows.Forms.Button()
        Me.btnStopCorrection = New System.Windows.Forms.Button()
        Me.TabPageCorrectionValue = New System.Windows.Forms.TabPage()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.btnOpenInputForm = New System.Windows.Forms.Button()
        Me.btnBuildCorrectionFile = New System.Windows.Forms.Button()
        Me.btnSaveCorrectionValue = New System.Windows.Forms.Button()
        Me.dgvCorrection = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TabPageCalibration = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cboCalibrationRange = New System.Windows.Forms.ComboBox()
        Me.btnSaveCalibration = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.dgvGalvoValue = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgvImageValue = New System.Windows.Forms.DataGridView()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnKeyImageCalibration = New System.Windows.Forms.Button()
        Me.btnKeyCorrectionGalvo = New System.Windows.Forms.Button()
        Me.TabPageIOStatus = New System.Windows.Forms.TabPage()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.ptbOut15 = New LaserCutting.PictureBoxEx()
        Me.ptbIn15 = New LaserCutting.PictureBoxEx()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.ptbIn14 = New LaserCutting.PictureBoxEx()
        Me.ptbIn13 = New LaserCutting.PictureBoxEx()
        Me.ptbIn12 = New LaserCutting.PictureBoxEx()
        Me.ptbIn11 = New LaserCutting.PictureBoxEx()
        Me.ptbIn10 = New LaserCutting.PictureBoxEx()
        Me.ptbIn9 = New LaserCutting.PictureBoxEx()
        Me.ptbIn8 = New LaserCutting.PictureBoxEx()
        Me.ptbIn7 = New LaserCutting.PictureBoxEx()
        Me.ptbIn6 = New LaserCutting.PictureBoxEx()
        Me.ptbIn5 = New LaserCutting.PictureBoxEx()
        Me.ptbIn4 = New LaserCutting.PictureBoxEx()
        Me.ptbIn3 = New LaserCutting.PictureBoxEx()
        Me.ptbIn2 = New LaserCutting.PictureBoxEx()
        Me.ptbIn1 = New LaserCutting.PictureBoxEx()
        Me.ptbIn0 = New LaserCutting.PictureBoxEx()
        Me.ptbOut14 = New LaserCutting.PictureBoxEx()
        Me.ptbOut13 = New LaserCutting.PictureBoxEx()
        Me.ptbOut12 = New LaserCutting.PictureBoxEx()
        Me.ptbOut11 = New LaserCutting.PictureBoxEx()
        Me.ptbOut10 = New LaserCutting.PictureBoxEx()
        Me.ptbOut9 = New LaserCutting.PictureBoxEx()
        Me.ptbOut8 = New LaserCutting.PictureBoxEx()
        Me.ptbOut7 = New LaserCutting.PictureBoxEx()
        Me.ptbOut6 = New LaserCutting.PictureBoxEx()
        Me.ptbOut5 = New LaserCutting.PictureBoxEx()
        Me.ptbOut4 = New LaserCutting.PictureBoxEx()
        Me.ptbOut3 = New LaserCutting.PictureBoxEx()
        Me.ptbOut2 = New LaserCutting.PictureBoxEx()
        Me.ptbOut1 = New LaserCutting.PictureBoxEx()
        Me.ptbOut0 = New LaserCutting.PictureBoxEx()
        Me.TabPageAxis = New System.Windows.Forms.TabPage()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.TabPageScale = New System.Windows.Forms.TabPage()
        Me.GroupBox15 = New System.Windows.Forms.GroupBox()
        Me.chkScaleUseLaser = New System.Windows.Forms.CheckBox()
        Me.Label56 = New System.Windows.Forms.Label()
        Me.Label58 = New System.Windows.Forms.Label()
        Me.btnSaveScale = New System.Windows.Forms.Button()
        Me.btnCalScale = New System.Windows.Forms.Button()
        Me.btnMarkLineScale = New System.Windows.Forms.Button()
        Me.numCalScale = New System.Windows.Forms.NumericUpDown()
        Me.numLengthScalePX = New System.Windows.Forms.NumericUpDown()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.Label54 = New System.Windows.Forms.Label()
        Me.numLengthScaleMM = New System.Windows.Forms.NumericUpDown()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TabPagePos = New System.Windows.Forms.TabPage()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.GroupBox16 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder10 = New System.Windows.Forms.Button()
        Me.btnCylinder11 = New System.Windows.Forms.Button()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder8 = New System.Windows.Forms.Button()
        Me.btnCylinder9 = New System.Windows.Forms.Button()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder4 = New System.Windows.Forms.Button()
        Me.btnCylinder5 = New System.Windows.Forms.Button()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel17 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder2 = New System.Windows.Forms.Button()
        Me.btnCylinder3 = New System.Windows.Forms.Button()
        Me.GroupBox18 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel11 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder14 = New System.Windows.Forms.Button()
        Me.btnCylinder15 = New System.Windows.Forms.Button()
        Me.GroupBox17 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder12 = New System.Windows.Forms.Button()
        Me.btnCylinder13 = New System.Windows.Forms.Button()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel14 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder6 = New System.Windows.Forms.Button()
        Me.btnCylinder7 = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel10 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnCylinder0 = New System.Windows.Forms.Button()
        Me.btnCylinder1 = New System.Windows.Forms.Button()
        Me.btnSavePos = New System.Windows.Forms.Button()
        Me.groupWorkholderX = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.numMovingDistance0 = New System.Windows.Forms.NumericUpDown()
        Me.btnWorkholderTestMove0 = New System.Windows.Forms.Button()
        Me.btnWorkholderTestMove1 = New System.Windows.Forms.Button()
        Me.lblWorkholderXNow = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.numWorkhodlerX3 = New System.Windows.Forms.NumericUpDown()
        Me.btnWorkholderMove3 = New System.Windows.Forms.Button()
        Me.btnWorkholderSet3 = New System.Windows.Forms.Button()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.numWorkhodlerX1 = New System.Windows.Forms.NumericUpDown()
        Me.btnWorkholderMove1 = New System.Windows.Forms.Button()
        Me.btnWorkholderSet1 = New System.Windows.Forms.Button()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.numWorkhodlerX2 = New System.Windows.Forms.NumericUpDown()
        Me.btnWorkholderMove2 = New System.Windows.Forms.Button()
        Me.btnWorkholderSet2 = New System.Windows.Forms.Button()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel13 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.numWorkhodlerX0 = New System.Windows.Forms.NumericUpDown()
        Me.btnWorkholderMove0 = New System.Windows.Forms.Button()
        Me.btnWorkholderSet0 = New System.Windows.Forms.Button()
        Me.TabPageLog = New System.Windows.Forms.TabPage()
        Me.TabPagePassword = New System.Windows.Forms.TabPage()
        Me.ContextMenuStripPassword = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoginToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lnkLanguage = New System.Windows.Forms.LinkLabel()
        Me.grbCamera = New System.Windows.Forms.Panel()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnOpenProject = New System.Windows.Forms.Button()
        Me.btnNewProject = New System.Windows.Forms.Button()
        Me.Timer_GetLaserExecuteFinish = New System.Windows.Forms.Timer(Me.components)
        Me.TimerGetRTC4IO = New System.Windows.Forms.Timer(Me.components)
        Me.ContextMenuStripMoveLine.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.tblEditTable.SuspendLayout()
        CType(Me.numPRR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGalvoOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGalvoOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numGalvoAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDIDelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numDODelay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleLaserPRR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleLaserPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numPX2MM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.pnEdit.SuspendLayout()
        Me.GroupBoxEx2.SuspendLayout()
        CType(Me.numFixDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxEx1.SuspendLayout()
        Me.TableLayoutPanel15.SuspendLayout()
        CType(Me.numRotateAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMoveDistance, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel12.SuspendLayout()
        Me.pnMainButton.SuspendLayout()
        Me.TabPageAlignment.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.numWorkStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAcceptScoreAlign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageLaserParam.SuspendLayout()
        Me.grbGalvoParameter.SuspendLayout()
        Me.grbGraphicParameter.SuspendLayout()
        CType(Me.numImageOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numImageOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabPageCorrection.SuspendLayout()
        Me.TabControl2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPageCorrectionValue.SuspendLayout()
        CType(Me.dgvCorrection, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageCalibration.SuspendLayout()
        CType(Me.dgvGalvoValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvImageValue, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageIOStatus.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.ptbOut15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbIn0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptbOut0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageAxis.SuspendLayout()
        Me.TabPageScale.SuspendLayout()
        Me.GroupBox15.SuspendLayout()
        CType(Me.numCalScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLengthScalePX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numLengthScaleMM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPagePos.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox16.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.TableLayoutPanel17.SuspendLayout()
        Me.GroupBox18.SuspendLayout()
        Me.TableLayoutPanel11.SuspendLayout()
        Me.GroupBox17.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        Me.TableLayoutPanel14.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        Me.TableLayoutPanel10.SuspendLayout()
        Me.groupWorkholderX.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        CType(Me.numMovingDistance0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.numWorkhodlerX3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.numWorkhodlerX1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWorkhodlerX2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        Me.TableLayoutPanel13.SuspendLayout()
        CType(Me.numWorkhodlerX0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStripPassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'ContextMenuStripMoveLine
        '
        Me.ContextMenuStripMoveLine.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UpToolStripMenuItem, Me.DownToolStripMenuItem, Me.CloneToolStripMenuItem, Me.CopyLaserParameterToolStripMenuItem, Me.PasteLaserParameterToolStripMenuItem})
        Me.ContextMenuStripMoveLine.Name = "ContextMenuStripMoveLine"
        resources.ApplyResources(Me.ContextMenuStripMoveLine, "ContextMenuStripMoveLine")
        '
        'UpToolStripMenuItem
        '
        Me.UpToolStripMenuItem.Image = Global.LaserCutting.My.Resources.Resources.moveup
        Me.UpToolStripMenuItem.Name = "UpToolStripMenuItem"
        resources.ApplyResources(Me.UpToolStripMenuItem, "UpToolStripMenuItem")
        '
        'DownToolStripMenuItem
        '
        Me.DownToolStripMenuItem.Image = Global.LaserCutting.My.Resources.Resources.movedown
        Me.DownToolStripMenuItem.Name = "DownToolStripMenuItem"
        resources.ApplyResources(Me.DownToolStripMenuItem, "DownToolStripMenuItem")
        '
        'CloneToolStripMenuItem
        '
        Me.CloneToolStripMenuItem.Image = Global.LaserCutting.My.Resources.Resources.copy
        Me.CloneToolStripMenuItem.Name = "CloneToolStripMenuItem"
        resources.ApplyResources(Me.CloneToolStripMenuItem, "CloneToolStripMenuItem")
        '
        'CopyLaserParameterToolStripMenuItem
        '
        Me.CopyLaserParameterToolStripMenuItem.Image = Global.LaserCutting.My.Resources.Resources.copyparam
        Me.CopyLaserParameterToolStripMenuItem.Name = "CopyLaserParameterToolStripMenuItem"
        resources.ApplyResources(Me.CopyLaserParameterToolStripMenuItem, "CopyLaserParameterToolStripMenuItem")
        '
        'PasteLaserParameterToolStripMenuItem
        '
        Me.PasteLaserParameterToolStripMenuItem.Image = Global.LaserCutting.My.Resources.Resources.paste
        Me.PasteLaserParameterToolStripMenuItem.Name = "PasteLaserParameterToolStripMenuItem"
        resources.ApplyResources(Me.PasteLaserParameterToolStripMenuItem, "PasteLaserParameterToolStripMenuItem")
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.ContextMenuStrip = Me.ContextMenuStripMoveLine
        Me.TreeView1.DrawMode = System.Windows.Forms.TreeViewDrawMode.OwnerDrawText
        resources.ApplyResources(Me.TreeView1, "TreeView1")
        Me.TreeView1.HideSelection = False
        Me.TreeView1.Name = "TreeView1"
        Me.tblEditTable.SetRowSpan(Me.TreeView1, 6)
        '
        'StatusStrip1
        '
        resources.ApplyResources(Me.StatusStrip1, "StatusStrip1")
        Me.StatusStrip1.BackColor = System.Drawing.Color.White
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.lblStatusX, Me.ToolStripStatusLabel3, Me.lblStatusY, Me.lblFilePath, Me.ToolStripStatusLabel2, Me.lblLaserPRR, Me.ToolStripStatusLabel5, Me.lblLaserPower, Me.ToolStripStatusLabel4, Me.lblXPx, Me.ToolStripStatusLabel7, Me.lblYPx})
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.SizingGrip = False
        '
        'ToolStripStatusLabel1
        '
        resources.ApplyResources(Me.ToolStripStatusLabel1, "ToolStripStatusLabel1")
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        '
        'lblStatusX
        '
        resources.ApplyResources(Me.lblStatusX, "lblStatusX")
        Me.lblStatusX.Name = "lblStatusX"
        '
        'ToolStripStatusLabel3
        '
        resources.ApplyResources(Me.ToolStripStatusLabel3, "ToolStripStatusLabel3")
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        '
        'lblStatusY
        '
        resources.ApplyResources(Me.lblStatusY, "lblStatusY")
        Me.lblStatusY.Name = "lblStatusY"
        '
        'lblFilePath
        '
        Me.lblFilePath.Name = "lblFilePath"
        resources.ApplyResources(Me.lblFilePath, "lblFilePath")
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        resources.ApplyResources(Me.ToolStripStatusLabel2, "ToolStripStatusLabel2")
        '
        'lblLaserPRR
        '
        resources.ApplyResources(Me.lblLaserPRR, "lblLaserPRR")
        Me.lblLaserPRR.Name = "lblLaserPRR"
        '
        'ToolStripStatusLabel5
        '
        Me.ToolStripStatusLabel5.Name = "ToolStripStatusLabel5"
        resources.ApplyResources(Me.ToolStripStatusLabel5, "ToolStripStatusLabel5")
        '
        'lblLaserPower
        '
        resources.ApplyResources(Me.lblLaserPower, "lblLaserPower")
        Me.lblLaserPower.Name = "lblLaserPower"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        resources.ApplyResources(Me.ToolStripStatusLabel4, "ToolStripStatusLabel4")
        '
        'lblXPx
        '
        resources.ApplyResources(Me.lblXPx, "lblXPx")
        Me.lblXPx.Name = "lblXPx"
        '
        'ToolStripStatusLabel7
        '
        Me.ToolStripStatusLabel7.Name = "ToolStripStatusLabel7"
        resources.ApplyResources(Me.ToolStripStatusLabel7, "ToolStripStatusLabel7")
        '
        'lblYPx
        '
        resources.ApplyResources(Me.lblYPx, "lblYPx")
        Me.lblYPx.Name = "lblYPx"
        '
        'PropertyGrid1
        '
        resources.ApplyResources(Me.PropertyGrid1, "PropertyGrid1")
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.PropertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Categorized
        '
        'tblEditTable
        '
        resources.ApplyResources(Me.tblEditTable, "tblEditTable")
        Me.tblEditTable.Controls.Add(Me.btnAddLine, 0, 0)
        Me.tblEditTable.Controls.Add(Me.btnDelete, 0, 1)
        Me.tblEditTable.Controls.Add(Me.btnMainGuideOFF, 0, 5)
        Me.tblEditTable.Controls.Add(Me.TreeView1, 1, 0)
        Me.tblEditTable.Controls.Add(Me.Button3, 0, 2)
        Me.tblEditTable.Controls.Add(Me.btnPickColor, 0, 3)
        Me.tblEditTable.Controls.Add(Me.btnEdit, 0, 4)
        Me.tblEditTable.Name = "tblEditTable"
        '
        'btnAddLine
        '
        Me.btnAddLine.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.btnAddLine, "btnAddLine")
        Me.btnAddLine.Image = Global.LaserCutting.My.Resources.Resources.line
        Me.btnAddLine.Name = "btnAddLine"
        Me.ToolTip1.SetToolTip(Me.btnAddLine, resources.GetString("btnAddLine.ToolTip"))
        Me.btnAddLine.UseVisualStyleBackColor = False
        '
        'btnDelete
        '
        Me.btnDelete.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnDelete.BackgroundImage = Global.LaserCutting.My.Resources.Resources.cancel
        resources.ApplyResources(Me.btnDelete, "btnDelete")
        Me.btnDelete.Name = "btnDelete"
        Me.ToolTip1.SetToolTip(Me.btnDelete, resources.GetString("btnDelete.ToolTip"))
        Me.btnDelete.UseVisualStyleBackColor = False
        '
        'btnMainGuideOFF
        '
        Me.btnMainGuideOFF.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnMainGuideOFF.BackgroundImage = Global.LaserCutting.My.Resources.Resources.pulselaser2
        resources.ApplyResources(Me.btnMainGuideOFF, "btnMainGuideOFF")
        Me.btnMainGuideOFF.Name = "btnMainGuideOFF"
        Me.btnMainGuideOFF.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.BackgroundImage = Global.LaserCutting.My.Resources.Resources.Cross
        resources.ApplyResources(Me.Button3, "Button3")
        Me.Button3.Name = "Button3"
        Me.ToolTip1.SetToolTip(Me.Button3, resources.GetString("Button3.ToolTip"))
        Me.Button3.UseVisualStyleBackColor = False
        '
        'btnPickColor
        '
        Me.btnPickColor.BackgroundImage = Global.LaserCutting.My.Resources.Resources.pickcolor
        resources.ApplyResources(Me.btnPickColor, "btnPickColor")
        Me.btnPickColor.Name = "btnPickColor"
        Me.ToolTip1.SetToolTip(Me.btnPickColor, resources.GetString("btnPickColor.ToolTip"))
        Me.btnPickColor.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnEdit.BackgroundImage = Global.LaserCutting.My.Resources.Resources.edit
        resources.ApplyResources(Me.btnEdit, "btnEdit")
        Me.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.btnEdit.ForeColor = System.Drawing.Color.Red
        Me.btnEdit.Name = "btnEdit"
        Me.ToolTip1.SetToolTip(Me.btnEdit, resources.GetString("btnEdit.ToolTip"))
        Me.btnEdit.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        Me.ToolTip1.SetToolTip(Me.Label1, resources.GetString("Label1.ToolTip"))
        '
        'numPRR
        '
        Me.numPRR.DecimalPlaces = 1
        resources.ApplyResources(Me.numPRR, "numPRR")
        Me.numPRR.Maximum = New Decimal(New Integer() {101, 0, 0, 0})
        Me.numPRR.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numPRR.Name = "numPRR"
        Me.ToolTip1.SetToolTip(Me.numPRR, resources.GetString("numPRR.ToolTip"))
        Me.numPRR.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'numGalvoOffsetY
        '
        resources.ApplyResources(Me.numGalvoOffsetY, "numGalvoOffsetY")
        Me.numGalvoOffsetY.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.numGalvoOffsetY.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.numGalvoOffsetY.Name = "numGalvoOffsetY"
        Me.ToolTip1.SetToolTip(Me.numGalvoOffsetY, resources.GetString("numGalvoOffsetY.ToolTip"))
        '
        'numGalvoOffsetX
        '
        resources.ApplyResources(Me.numGalvoOffsetX, "numGalvoOffsetX")
        Me.numGalvoOffsetX.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.numGalvoOffsetX.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.numGalvoOffsetX.Name = "numGalvoOffsetX"
        Me.ToolTip1.SetToolTip(Me.numGalvoOffsetX, resources.GetString("numGalvoOffsetX.ToolTip"))
        '
        'numGalvoAngle
        '
        Me.numGalvoAngle.DecimalPlaces = 3
        resources.ApplyResources(Me.numGalvoAngle, "numGalvoAngle")
        Me.numGalvoAngle.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numGalvoAngle.Minimum = New Decimal(New Integer() {10, 0, 0, -2147483648})
        Me.numGalvoAngle.Name = "numGalvoAngle"
        Me.ToolTip1.SetToolTip(Me.numGalvoAngle, resources.GetString("numGalvoAngle.ToolTip"))
        '
        'Label14
        '
        Me.Label14.BackColor = System.Drawing.Color.White
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label14.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label14, "Label14")
        Me.Label14.Name = "Label14"
        Me.ToolTip1.SetToolTip(Me.Label14, resources.GetString("Label14.ToolTip"))
        '
        'Label13
        '
        Me.Label13.BackColor = System.Drawing.Color.White
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label13.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label13, "Label13")
        Me.Label13.Name = "Label13"
        Me.ToolTip1.SetToolTip(Me.Label13, resources.GetString("Label13.ToolTip"))
        '
        'Label12
        '
        Me.Label12.BackColor = System.Drawing.Color.White
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label12.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label12, "Label12")
        Me.Label12.Name = "Label12"
        Me.ToolTip1.SetToolTip(Me.Label12, resources.GetString("Label12.ToolTip"))
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        Me.ToolTip1.SetToolTip(Me.Label2, resources.GetString("Label2.ToolTip"))
        '
        'numPower
        '
        Me.numPower.DecimalPlaces = 1
        resources.ApplyResources(Me.numPower, "numPower")
        Me.numPower.Name = "numPower"
        Me.ToolTip1.SetToolTip(Me.numPower, resources.GetString("numPower.ToolTip"))
        Me.numPower.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'numDIDelay
        '
        resources.ApplyResources(Me.numDIDelay, "numDIDelay")
        Me.numDIDelay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numDIDelay.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numDIDelay.Name = "numDIDelay"
        Me.ToolTip1.SetToolTip(Me.numDIDelay, resources.GetString("numDIDelay.ToolTip"))
        Me.numDIDelay.Value = New Decimal(New Integer() {700, 0, 0, 0})
        '
        'Label36
        '
        Me.Label36.BackColor = System.Drawing.Color.White
        Me.Label36.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label36.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label36, "Label36")
        Me.Label36.Name = "Label36"
        Me.ToolTip1.SetToolTip(Me.Label36, resources.GetString("Label36.ToolTip"))
        '
        'Label38
        '
        Me.Label38.BackColor = System.Drawing.Color.White
        Me.Label38.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label38.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label38, "Label38")
        Me.Label38.Name = "Label38"
        Me.ToolTip1.SetToolTip(Me.Label38, resources.GetString("Label38.ToolTip"))
        '
        'numDODelay
        '
        resources.ApplyResources(Me.numDODelay, "numDODelay")
        Me.numDODelay.Maximum = New Decimal(New Integer() {10000, 0, 0, 0})
        Me.numDODelay.Minimum = New Decimal(New Integer() {100, 0, 0, 0})
        Me.numDODelay.Name = "numDODelay"
        Me.ToolTip1.SetToolTip(Me.numDODelay, resources.GetString("numDODelay.ToolTip"))
        Me.numDODelay.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'numScaleLaserPRR
        '
        Me.numScaleLaserPRR.DecimalPlaces = 1
        resources.ApplyResources(Me.numScaleLaserPRR, "numScaleLaserPRR")
        Me.numScaleLaserPRR.Maximum = New Decimal(New Integer() {101, 0, 0, 0})
        Me.numScaleLaserPRR.Minimum = New Decimal(New Integer() {2, 0, 0, 0})
        Me.numScaleLaserPRR.Name = "numScaleLaserPRR"
        Me.ToolTip1.SetToolTip(Me.numScaleLaserPRR, resources.GetString("numScaleLaserPRR.ToolTip"))
        Me.numScaleLaserPRR.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'Label55
        '
        Me.Label55.BackColor = System.Drawing.Color.White
        Me.Label55.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label55.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label55, "Label55")
        Me.Label55.Name = "Label55"
        Me.ToolTip1.SetToolTip(Me.Label55, resources.GetString("Label55.ToolTip"))
        '
        'Label57
        '
        Me.Label57.BackColor = System.Drawing.Color.White
        Me.Label57.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label57.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label57, "Label57")
        Me.Label57.Name = "Label57"
        Me.ToolTip1.SetToolTip(Me.Label57, resources.GetString("Label57.ToolTip"))
        '
        'numScaleLaserPower
        '
        Me.numScaleLaserPower.DecimalPlaces = 1
        resources.ApplyResources(Me.numScaleLaserPower, "numScaleLaserPower")
        Me.numScaleLaserPower.Name = "numScaleLaserPower"
        Me.ToolTip1.SetToolTip(Me.numScaleLaserPower, resources.GetString("numScaleLaserPower.ToolTip"))
        Me.numScaleLaserPower.Value = New Decimal(New Integer() {20, 0, 0, 0})
        '
        'lblVersion
        '
        resources.ApplyResources(Me.lblVersion, "lblVersion")
        Me.lblVersion.BackColor = System.Drawing.Color.White
        Me.lblVersion.ForeColor = System.Drawing.Color.Red
        Me.lblVersion.Name = "lblVersion"
        Me.ToolTip1.SetToolTip(Me.lblVersion, resources.GetString("lblVersion.ToolTip"))
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label10.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label10, "Label10")
        Me.Label10.Name = "Label10"
        Me.ToolTip1.SetToolTip(Me.Label10, resources.GetString("Label10.ToolTip"))
        '
        'numPX2MM
        '
        Me.numPX2MM.DecimalPlaces = 16
        resources.ApplyResources(Me.numPX2MM, "numPX2MM")
        Me.numPX2MM.Name = "numPX2MM"
        Me.ToolTip1.SetToolTip(Me.numPX2MM, resources.GetString("numPX2MM.ToolTip"))
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.RoyalBlue
        Me.btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer))
        resources.ApplyResources(Me.btnHome, "btnHome")
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Image = Global.LaserCutting.My.Resources.Resources.home4
        Me.btnHome.Name = "btnHome"
        Me.ToolTip1.SetToolTip(Me.btnHome, resources.GetString("btnHome.ToolTip"))
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnRun
        '
        Me.btnRun.BackColor = System.Drawing.Color.Green
        Me.btnRun.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnRun.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnRun, "btnRun")
        Me.btnRun.ForeColor = System.Drawing.Color.White
        Me.btnRun.Image = Global.LaserCutting.My.Resources.Resources.run
        Me.btnRun.Name = "btnRun"
        Me.ToolTip1.SetToolTip(Me.btnRun, resources.GetString("btnRun.ToolTip"))
        Me.btnRun.UseVisualStyleBackColor = False
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Red
        Me.btnStop.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStop.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.btnStop, "btnStop")
        Me.btnStop.ForeColor = System.Drawing.Color.White
        Me.btnStop.Image = Global.LaserCutting.My.Resources.Resources.stop2
        Me.btnStop.Name = "btnStop"
        Me.ToolTip1.SetToolTip(Me.btnStop, resources.GetString("btnStop.ToolTip"))
        Me.btnStop.UseVisualStyleBackColor = False
        '
        'btnApply
        '
        Me.btnApply.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnApply.FlatAppearance.BorderSize = 0
        Me.btnApply.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.btnApply, "btnApply")
        Me.btnApply.ForeColor = System.Drawing.Color.White
        Me.btnApply.Name = "btnApply"
        Me.ToolTip1.SetToolTip(Me.btnApply, resources.GetString("btnApply.ToolTip"))
        Me.btnApply.UseVisualStyleBackColor = False
        '
        'btnRotateCW
        '
        Me.btnRotateCW.BackgroundImage = Global.LaserCutting.My.Resources.Resources.feedadd
        resources.ApplyResources(Me.btnRotateCW, "btnRotateCW")
        Me.btnRotateCW.FlatAppearance.BorderSize = 0
        Me.btnRotateCW.Name = "btnRotateCW"
        Me.ToolTip1.SetToolTip(Me.btnRotateCW, resources.GetString("btnRotateCW.ToolTip"))
        Me.btnRotateCW.UseVisualStyleBackColor = True
        '
        'btnRotateCCW
        '
        Me.btnRotateCCW.BackgroundImage = Global.LaserCutting.My.Resources.Resources.feedremove
        resources.ApplyResources(Me.btnRotateCCW, "btnRotateCCW")
        Me.btnRotateCCW.FlatAppearance.BorderSize = 0
        Me.btnRotateCCW.Name = "btnRotateCCW"
        Me.ToolTip1.SetToolTip(Me.btnRotateCCW, resources.GetString("btnRotateCCW.ToolTip"))
        Me.btnRotateCCW.UseVisualStyleBackColor = True
        '
        'btnMoveUp
        '
        Me.btnMoveUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnMoveUp.ButtonType = LaserCutting.eButtonType.Arrow
        Me.btnMoveUp.Direction = LaserCutting.eArrow.Up
        Me.btnMoveUp.FlatAppearance.BorderSize = 0
        Me.btnMoveUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.btnMoveUp, "btnMoveUp")
        Me.btnMoveUp.Name = "btnMoveUp"
        Me.btnMoveUp.Radius = 1.0!
        Me.ToolTip1.SetToolTip(Me.btnMoveUp, resources.GetString("btnMoveUp.ToolTip"))
        Me.btnMoveUp.UseVisualStyleBackColor = False
        '
        'btnMoveLeft
        '
        Me.btnMoveLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnMoveLeft.ButtonType = LaserCutting.eButtonType.Arrow
        Me.btnMoveLeft.Direction = LaserCutting.eArrow.Left
        Me.btnMoveLeft.FlatAppearance.BorderSize = 0
        Me.btnMoveLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.btnMoveLeft, "btnMoveLeft")
        Me.btnMoveLeft.Name = "btnMoveLeft"
        Me.btnMoveLeft.Radius = 1.0!
        Me.ToolTip1.SetToolTip(Me.btnMoveLeft, resources.GetString("btnMoveLeft.ToolTip"))
        Me.btnMoveLeft.UseVisualStyleBackColor = False
        '
        'btnMoveDown
        '
        Me.btnMoveDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnMoveDown.ButtonType = LaserCutting.eButtonType.Arrow
        Me.btnMoveDown.Direction = LaserCutting.eArrow.Down
        Me.btnMoveDown.FlatAppearance.BorderSize = 0
        Me.btnMoveDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.btnMoveDown, "btnMoveDown")
        Me.btnMoveDown.Name = "btnMoveDown"
        Me.btnMoveDown.Radius = 1.0!
        Me.ToolTip1.SetToolTip(Me.btnMoveDown, resources.GetString("btnMoveDown.ToolTip"))
        Me.btnMoveDown.UseVisualStyleBackColor = False
        '
        'btnMoveRight
        '
        Me.btnMoveRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnMoveRight.ButtonType = LaserCutting.eButtonType.Arrow
        Me.btnMoveRight.Direction = LaserCutting.eArrow.Right
        Me.btnMoveRight.FlatAppearance.BorderSize = 0
        Me.btnMoveRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        resources.ApplyResources(Me.btnMoveRight, "btnMoveRight")
        Me.btnMoveRight.Name = "btnMoveRight"
        Me.btnMoveRight.Radius = 1.0!
        Me.ToolTip1.SetToolTip(Me.btnMoveRight, resources.GetString("btnMoveRight.ToolTip"))
        Me.btnMoveRight.UseVisualStyleBackColor = False
        '
        'chkTest
        '
        resources.ApplyResources(Me.chkTest, "chkTest")
        Me.chkTest.BackColor = System.Drawing.Color.Silver
        Me.chkTest.BoxBackColor = System.Drawing.Color.White
        Me.chkTest.BoxColor = System.Drawing.Color.Black
        Me.chkTest.BoxLocationX = 0
        Me.chkTest.BoxLocationY = 0
        Me.chkTest.BoxSize = 20
        Me.chkTest.BoxSpacing = CType(0UI, UInteger)
        Me.chkTest.DoubleBorder = False
        Me.chkTest.FlatAppearance.BorderSize = 0
        Me.chkTest.Name = "chkTest"
        Me.chkTest.TextLocationX = 23
        Me.chkTest.TextLocationY = 1
        Me.chkTest.TickColor = System.Drawing.Color.MediumSpringGreen
        Me.chkTest.TickLeftPosition = -3.0!
        Me.chkTest.TickSize = 20.0!
        Me.chkTest.TickTopPosition = -3.0!
        Me.ToolTip1.SetToolTip(Me.chkTest, resources.GetString("chkTest.ToolTip"))
        Me.chkTest.UseVisualStyleBackColor = False
        '
        'btnGuideON
        '
        Me.btnGuideON.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGuideON.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.btnGuideON, "btnGuideON")
        Me.btnGuideON.Name = "btnGuideON"
        Me.btnGuideON.UseVisualStyleBackColor = False
        '
        'btnGuideOFF
        '
        Me.btnGuideOFF.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGuideOFF.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.btnGuideOFF, "btnGuideOFF")
        Me.btnGuideOFF.Name = "btnGuideOFF"
        Me.btnGuideOFF.UseVisualStyleBackColor = False
        '
        'btnCorrection
        '
        Me.btnCorrection.BackColor = System.Drawing.Color.Green
        resources.ApplyResources(Me.btnCorrection, "btnCorrection")
        Me.btnCorrection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime
        Me.btnCorrection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCorrection.ForeColor = System.Drawing.Color.White
        Me.btnCorrection.Name = "btnCorrection"
        Me.btnCorrection.UseVisualStyleBackColor = False
        '
        'btnGlavoHome
        '
        Me.btnGlavoHome.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnGlavoHome.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.btnGlavoHome, "btnGlavoHome")
        Me.btnGlavoHome.Name = "btnGlavoHome"
        Me.btnGlavoHome.UseVisualStyleBackColor = False
        '
        'TabControl1
        '
        resources.ApplyResources(Me.TabControl1, "TabControl1")
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPageAlignment)
        Me.TabControl1.Controls.Add(Me.TabPageLaserParam)
        Me.TabControl1.Controls.Add(Me.TabPageCorrection)
        Me.TabControl1.Controls.Add(Me.TabPagePos)
        Me.TabControl1.Controls.Add(Me.TabPageLog)
        Me.TabControl1.Controls.Add(Me.TabPagePassword)
        Me.TabControl1.HotTrack = True
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Silver
        Me.TabPage1.Controls.Add(Me.pnEdit)
        Me.TabPage1.Controls.Add(Me.pnMainButton)
        Me.TabPage1.Controls.Add(Me.lbLog)
        Me.TabPage1.Controls.Add(Me.tblEditTable)
        Me.TabPage1.Controls.Add(Me.PropertyGrid1)
        resources.ApplyResources(Me.TabPage1, "TabPage1")
        Me.TabPage1.Name = "TabPage1"
        '
        'pnEdit
        '
        Me.pnEdit.Controls.Add(Me.GroupBoxEx2)
        Me.pnEdit.Controls.Add(Me.GroupBoxEx1)
        resources.ApplyResources(Me.pnEdit, "pnEdit")
        Me.pnEdit.Name = "pnEdit"
        '
        'GroupBoxEx2
        '
        Me.GroupBoxEx2.BorderColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBoxEx2.BorderRadius = CType(0UI, UInteger)
        Me.GroupBoxEx2.Controls.Add(Me.cboFixPoint)
        Me.GroupBoxEx2.Controls.Add(Me.Label62)
        Me.GroupBoxEx2.Controls.Add(Me.numFixDistance)
        Me.GroupBoxEx2.Controls.Add(Me.btnApply)
        Me.GroupBoxEx2.Controls.Add(Me.Label64)
        resources.ApplyResources(Me.GroupBoxEx2, "GroupBoxEx2")
        Me.GroupBoxEx2.Name = "GroupBoxEx2"
        Me.GroupBoxEx2.TabStop = False
        Me.GroupBoxEx2.TextColor = System.Drawing.Color.Blue
        '
        'cboFixPoint
        '
        Me.cboFixPoint.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboFixPoint, "cboFixPoint")
        Me.cboFixPoint.FormattingEnabled = True
        Me.cboFixPoint.Items.AddRange(New Object() {resources.GetString("cboFixPoint.Items"), resources.GetString("cboFixPoint.Items1"), resources.GetString("cboFixPoint.Items2")})
        Me.cboFixPoint.Name = "cboFixPoint"
        '
        'Label62
        '
        Me.Label62.BackColor = System.Drawing.Color.White
        Me.Label62.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label62, "Label62")
        Me.Label62.Name = "Label62"
        '
        'numFixDistance
        '
        resources.ApplyResources(Me.numFixDistance, "numFixDistance")
        Me.numFixDistance.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numFixDistance.Minimum = New Decimal(New Integer() {100000, 0, 0, -2147483648})
        Me.numFixDistance.Name = "numFixDistance"
        '
        'Label64
        '
        Me.Label64.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Label64, "Label64")
        Me.Label64.ForeColor = System.Drawing.Color.Black
        Me.Label64.Name = "Label64"
        '
        'GroupBoxEx1
        '
        Me.GroupBoxEx1.BorderColor = System.Drawing.SystemColors.ControlLight
        Me.GroupBoxEx1.BorderRadius = CType(0UI, UInteger)
        Me.GroupBoxEx1.Controls.Add(Me.Button4)
        Me.GroupBoxEx1.Controls.Add(Me.cboChoosePointForEdit)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel15)
        Me.GroupBoxEx1.Controls.Add(Me.Label5)
        Me.GroupBoxEx1.Controls.Add(Me.numRotateAngle)
        Me.GroupBoxEx1.Controls.Add(Me.numMoveDistance)
        Me.GroupBoxEx1.Controls.Add(Me.Label63)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel12)
        Me.GroupBoxEx1.Controls.Add(Me.Label6)
        Me.GroupBoxEx1.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.GroupBoxEx1, "GroupBoxEx1")
        Me.GroupBoxEx1.Name = "GroupBoxEx1"
        Me.GroupBoxEx1.TabStop = False
        Me.GroupBoxEx1.TextColor = System.Drawing.Color.Blue
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.LaserCutting.My.Resources.Resources.changeline1
        resources.ApplyResources(Me.Button4, "Button4")
        Me.Button4.FlatAppearance.BorderColor = System.Drawing.Color.Silver
        Me.Button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Silver
        Me.Button4.Name = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cboChoosePointForEdit
        '
        Me.cboChoosePointForEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        resources.ApplyResources(Me.cboChoosePointForEdit, "cboChoosePointForEdit")
        Me.cboChoosePointForEdit.FormattingEnabled = True
        Me.cboChoosePointForEdit.Items.AddRange(New Object() {resources.GetString("cboChoosePointForEdit.Items"), resources.GetString("cboChoosePointForEdit.Items1"), resources.GetString("cboChoosePointForEdit.Items2")})
        Me.cboChoosePointForEdit.Name = "cboChoosePointForEdit"
        '
        'TableLayoutPanel15
        '
        resources.ApplyResources(Me.TableLayoutPanel15, "TableLayoutPanel15")
        Me.TableLayoutPanel15.Controls.Add(Me.btnRotateCW, 0, 0)
        Me.TableLayoutPanel15.Controls.Add(Me.btnRotateCCW, 1, 0)
        Me.TableLayoutPanel15.Name = "TableLayoutPanel15"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'numRotateAngle
        '
        Me.numRotateAngle.DecimalPlaces = 3
        resources.ApplyResources(Me.numRotateAngle, "numRotateAngle")
        Me.numRotateAngle.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numRotateAngle.Name = "numRotateAngle"
        '
        'numMoveDistance
        '
        resources.ApplyResources(Me.numMoveDistance, "numMoveDistance")
        Me.numMoveDistance.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numMoveDistance.Name = "numMoveDistance"
        '
        'Label63
        '
        Me.Label63.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Label63, "Label63")
        Me.Label63.Name = "Label63"
        '
        'TableLayoutPanel12
        '
        resources.ApplyResources(Me.TableLayoutPanel12, "TableLayoutPanel12")
        Me.TableLayoutPanel12.Controls.Add(Me.btnMoveUp, 1, 0)
        Me.TableLayoutPanel12.Controls.Add(Me.btnMoveLeft, 0, 1)
        Me.TableLayoutPanel12.Controls.Add(Me.btnMoveDown, 1, 2)
        Me.TableLayoutPanel12.Controls.Add(Me.btnMoveRight, 2, 1)
        Me.TableLayoutPanel12.Name = "TableLayoutPanel12"
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Name = "Label6"
        '
        'pnMainButton
        '
        Me.pnMainButton.Controls.Add(Me.btnDrawSelecting)
        Me.pnMainButton.Controls.Add(Me.btnStop)
        Me.pnMainButton.Controls.Add(Me.btnHome)
        Me.pnMainButton.Controls.Add(Me.btnRun)
        Me.pnMainButton.Controls.Add(Me.chkTest)
        resources.ApplyResources(Me.pnMainButton, "pnMainButton")
        Me.pnMainButton.Name = "pnMainButton"
        '
        'btnDrawSelecting
        '
        Me.btnDrawSelecting.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDrawSelecting.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnDrawSelecting.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnDrawSelecting, "btnDrawSelecting")
        Me.btnDrawSelecting.ForeColor = System.Drawing.Color.White
        Me.btnDrawSelecting.Image = Global.LaserCutting.My.Resources.Resources.drawselecting
        Me.btnDrawSelecting.Name = "btnDrawSelecting"
        Me.btnDrawSelecting.UseVisualStyleBackColor = False
        '
        'lbLog
        '
        Me.lbLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.lbLog, "lbLog")
        Me.lbLog.FormattingEnabled = True
        Me.lbLog.Name = "lbLog"
        '
        'TabPageAlignment
        '
        Me.TabPageAlignment.BackColor = System.Drawing.Color.Silver
        Me.TabPageAlignment.Controls.Add(Me.GroupBox4)
        resources.ApplyResources(Me.TabPageAlignment, "TabPageAlignment")
        Me.TabPageAlignment.Name = "TabPageAlignment"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.numWorkStep)
        Me.GroupBox4.Controls.Add(Me.numAcceptScoreAlign)
        Me.GroupBox4.Controls.Add(Me.btnAlignSetStart)
        Me.GroupBox4.Controls.Add(Me.btnAlignTest)
        Me.GroupBox4.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.GroupBox4, "GroupBox4")
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.TabStop = False
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label8.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label7.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'numWorkStep
        '
        Me.numWorkStep.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.numWorkStep.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numWorkStep, "numWorkStep")
        Me.numWorkStep.Maximum = New Decimal(New Integer() {5, 0, 0, 0})
        Me.numWorkStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numWorkStep.Name = "numWorkStep"
        Me.numWorkStep.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numAcceptScoreAlign
        '
        Me.numAcceptScoreAlign.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.numAcceptScoreAlign.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.numAcceptScoreAlign, "numAcceptScoreAlign")
        Me.numAcceptScoreAlign.Name = "numAcceptScoreAlign"
        Me.numAcceptScoreAlign.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'btnAlignSetStart
        '
        Me.btnAlignSetStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAlignSetStart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnAlignSetStart.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnAlignSetStart, "btnAlignSetStart")
        Me.btnAlignSetStart.ForeColor = System.Drawing.Color.White
        Me.btnAlignSetStart.Name = "btnAlignSetStart"
        Me.btnAlignSetStart.Tag = "4"
        Me.btnAlignSetStart.UseVisualStyleBackColor = False
        '
        'btnAlignTest
        '
        Me.btnAlignTest.BackColor = System.Drawing.Color.Teal
        Me.btnAlignTest.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnAlignTest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        resources.ApplyResources(Me.btnAlignTest, "btnAlignTest")
        Me.btnAlignTest.ForeColor = System.Drawing.Color.White
        Me.btnAlignTest.Name = "btnAlignTest"
        Me.btnAlignTest.Tag = "5"
        Me.btnAlignTest.UseVisualStyleBackColor = False
        '
        'TabPageLaserParam
        '
        Me.TabPageLaserParam.BackColor = System.Drawing.Color.Silver
        Me.TabPageLaserParam.Controls.Add(Me.grbGalvoParameter)
        Me.TabPageLaserParam.Controls.Add(Me.grbGraphicParameter)
        Me.TabPageLaserParam.Controls.Add(Me.GroupBox5)
        Me.TabPageLaserParam.Controls.Add(Me.GroupBox3)
        Me.TabPageLaserParam.Controls.Add(Me.btnSaveParameter)
        resources.ApplyResources(Me.TabPageLaserParam, "TabPageLaserParam")
        Me.TabPageLaserParam.Name = "TabPageLaserParam"
        '
        'grbGalvoParameter
        '
        Me.grbGalvoParameter.Controls.Add(Me.chkUseScale)
        Me.grbGalvoParameter.Controls.Add(Me.numGalvoOffsetY)
        Me.grbGalvoParameter.Controls.Add(Me.numGalvoOffsetX)
        Me.grbGalvoParameter.Controls.Add(Me.numGalvoAngle)
        Me.grbGalvoParameter.Controls.Add(Me.Label14)
        Me.grbGalvoParameter.Controls.Add(Me.Label13)
        Me.grbGalvoParameter.Controls.Add(Me.Label17)
        Me.grbGalvoParameter.Controls.Add(Me.Label16)
        Me.grbGalvoParameter.Controls.Add(Me.Label15)
        Me.grbGalvoParameter.Controls.Add(Me.Label12)
        Me.grbGalvoParameter.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.grbGalvoParameter, "grbGalvoParameter")
        Me.grbGalvoParameter.Name = "grbGalvoParameter"
        Me.grbGalvoParameter.TabStop = False
        '
        'chkUseScale
        '
        resources.ApplyResources(Me.chkUseScale, "chkUseScale")
        Me.chkUseScale.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkUseScale.BoxColor = System.Drawing.Color.Black
        Me.chkUseScale.BoxLocationX = 0
        Me.chkUseScale.BoxLocationY = 0
        Me.chkUseScale.BoxSize = 14
        Me.chkUseScale.BoxSpacing = CType(0UI, UInteger)
        Me.chkUseScale.Checked = True
        Me.chkUseScale.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkUseScale.DoubleBorder = False
        Me.chkUseScale.FlatAppearance.BorderSize = 0
        Me.chkUseScale.Name = "chkUseScale"
        Me.chkUseScale.TextLocationX = 16
        Me.chkUseScale.TextLocationY = 1
        Me.chkUseScale.TickColor = System.Drawing.Color.Aqua
        Me.chkUseScale.TickLeftPosition = 0.0!
        Me.chkUseScale.TickSize = 11.0!
        Me.chkUseScale.TickTopPosition = 0.0!
        Me.chkUseScale.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.White
        Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label17.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label17, "Label17")
        Me.Label17.Name = "Label17"
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.White
        Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label16.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label16, "Label16")
        Me.Label16.Name = "Label16"
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.White
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label15.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label15, "Label15")
        Me.Label15.Name = "Label15"
        '
        'grbGraphicParameter
        '
        Me.grbGraphicParameter.Controls.Add(Me.numImageOffsetY)
        Me.grbGraphicParameter.Controls.Add(Me.numImageOffsetX)
        Me.grbGraphicParameter.Controls.Add(Me.numPX2MM)
        Me.grbGraphicParameter.Controls.Add(Me.Label10)
        Me.grbGraphicParameter.Controls.Add(Me.Label61)
        Me.grbGraphicParameter.Controls.Add(Me.Label11)
        Me.grbGraphicParameter.Controls.Add(Me.Label60)
        Me.grbGraphicParameter.Controls.Add(Me.Label59)
        Me.grbGraphicParameter.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.grbGraphicParameter, "grbGraphicParameter")
        Me.grbGraphicParameter.Name = "grbGraphicParameter"
        Me.grbGraphicParameter.TabStop = False
        '
        'numImageOffsetY
        '
        resources.ApplyResources(Me.numImageOffsetY, "numImageOffsetY")
        Me.numImageOffsetY.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.numImageOffsetY.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.numImageOffsetY.Name = "numImageOffsetY"
        '
        'numImageOffsetX
        '
        resources.ApplyResources(Me.numImageOffsetX, "numImageOffsetX")
        Me.numImageOffsetX.Maximum = New Decimal(New Integer() {32767, 0, 0, 0})
        Me.numImageOffsetX.Minimum = New Decimal(New Integer() {32768, 0, 0, -2147483648})
        Me.numImageOffsetX.Name = "numImageOffsetX"
        '
        'Label61
        '
        Me.Label61.BackColor = System.Drawing.Color.White
        Me.Label61.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label61.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label61, "Label61")
        Me.Label61.Name = "Label61"
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.White
        Me.Label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label11.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label11, "Label11")
        Me.Label11.Name = "Label11"
        '
        'Label60
        '
        Me.Label60.BackColor = System.Drawing.Color.White
        Me.Label60.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label60.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label60, "Label60")
        Me.Label60.Name = "Label60"
        '
        'Label59
        '
        Me.Label59.BackColor = System.Drawing.Color.White
        Me.Label59.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label59.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label59, "Label59")
        Me.Label59.Name = "Label59"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.numDIDelay)
        Me.GroupBox5.Controls.Add(Me.Label36)
        Me.GroupBox5.Controls.Add(Me.Label37)
        Me.GroupBox5.Controls.Add(Me.Label38)
        Me.GroupBox5.Controls.Add(Me.Label39)
        Me.GroupBox5.Controls.Add(Me.numDODelay)
        Me.GroupBox5.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.GroupBox5, "GroupBox5")
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.TabStop = False
        '
        'Label37
        '
        Me.Label37.BackColor = System.Drawing.Color.White
        Me.Label37.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label37.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label37, "Label37")
        Me.Label37.Name = "Label37"
        '
        'Label39
        '
        Me.Label39.BackColor = System.Drawing.Color.White
        Me.Label39.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label39.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label39, "Label39")
        Me.Label39.Name = "Label39"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.numPRR)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.numPower)
        Me.GroupBox3.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.GroupBox3, "GroupBox3")
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.TabStop = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.Name = "Label4"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'btnSaveParameter
        '
        Me.btnSaveParameter.BackColor = System.Drawing.Color.Olive
        Me.btnSaveParameter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnSaveParameter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnSaveParameter, "btnSaveParameter")
        Me.btnSaveParameter.ForeColor = System.Drawing.Color.White
        Me.btnSaveParameter.Image = Global.LaserCutting.My.Resources.Resources.save
        Me.btnSaveParameter.Name = "btnSaveParameter"
        Me.btnSaveParameter.UseVisualStyleBackColor = False
        '
        'TabPageCorrection
        '
        Me.TabPageCorrection.BackColor = System.Drawing.Color.Silver
        Me.TabPageCorrection.Controls.Add(Me.TabControl2)
        resources.ApplyResources(Me.TabPageCorrection, "TabPageCorrection")
        Me.TabPageCorrection.Name = "TabPageCorrection"
        '
        'TabControl2
        '
        Me.TabControl2.Controls.Add(Me.TabPage2)
        Me.TabControl2.Controls.Add(Me.TabPageCorrectionValue)
        Me.TabControl2.Controls.Add(Me.TabPageCalibration)
        Me.TabControl2.Controls.Add(Me.TabPageIOStatus)
        Me.TabControl2.Controls.Add(Me.TabPageAxis)
        Me.TabControl2.Controls.Add(Me.TabPageScale)
        resources.ApplyResources(Me.TabControl2, "TabControl2")
        Me.TabControl2.Name = "TabControl2"
        Me.TabControl2.SelectedIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Silver
        Me.TabPage2.Controls.Add(Me.btnMarkAxis)
        Me.TabPage2.Controls.Add(Me.btnMarkLine)
        Me.TabPage2.Controls.Add(Me.btnReloadCorectionFile)
        Me.TabPage2.Controls.Add(Me.Button6)
        Me.TabPage2.Controls.Add(Me.Button5)
        Me.TabPage2.Controls.Add(Me.PropertyGrid2)
        Me.TabPage2.Controls.Add(Me.btnEmissionOff)
        Me.TabPage2.Controls.Add(Me.btnEmissionOn)
        Me.TabPage2.Controls.Add(Me.btnCorrection)
        Me.TabPage2.Controls.Add(Me.btnStopCorrection)
        Me.TabPage2.Controls.Add(Me.btnGuideOFF)
        Me.TabPage2.Controls.Add(Me.btnGuideON)
        Me.TabPage2.Controls.Add(Me.btnGlavoHome)
        resources.ApplyResources(Me.TabPage2, "TabPage2")
        Me.TabPage2.Name = "TabPage2"
        '
        'btnMarkAxis
        '
        Me.btnMarkAxis.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnMarkAxis, "btnMarkAxis")
        Me.btnMarkAxis.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMarkAxis.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMarkAxis.ForeColor = System.Drawing.Color.White
        Me.btnMarkAxis.Name = "btnMarkAxis"
        Me.btnMarkAxis.UseVisualStyleBackColor = False
        '
        'btnMarkLine
        '
        Me.btnMarkLine.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnMarkLine, "btnMarkLine")
        Me.btnMarkLine.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMarkLine.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnMarkLine.ForeColor = System.Drawing.Color.White
        Me.btnMarkLine.Name = "btnMarkLine"
        Me.btnMarkLine.UseVisualStyleBackColor = False
        '
        'btnReloadCorectionFile
        '
        Me.btnReloadCorectionFile.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.btnReloadCorectionFile.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.btnReloadCorectionFile, "btnReloadCorectionFile")
        Me.btnReloadCorectionFile.Name = "btnReloadCorectionFile"
        Me.btnReloadCorectionFile.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button6.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Button6, "Button6")
        Me.Button6.Name = "Button6"
        Me.Button6.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button5.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Button5, "Button5")
        Me.Button5.Name = "Button5"
        Me.Button5.UseVisualStyleBackColor = False
        '
        'PropertyGrid2
        '
        resources.ApplyResources(Me.PropertyGrid2, "PropertyGrid2")
        Me.PropertyGrid2.Name = "PropertyGrid2"
        Me.PropertyGrid2.PropertySort = System.Windows.Forms.PropertySort.Categorized
        '
        'btnEmissionOff
        '
        Me.btnEmissionOff.BackColor = System.Drawing.Color.Teal
        resources.ApplyResources(Me.btnEmissionOff, "btnEmissionOff")
        Me.btnEmissionOff.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnEmissionOff.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnEmissionOff.ForeColor = System.Drawing.Color.White
        Me.btnEmissionOff.Name = "btnEmissionOff"
        Me.btnEmissionOff.UseVisualStyleBackColor = False
        '
        'btnEmissionOn
        '
        Me.btnEmissionOn.BackColor = System.Drawing.Color.Teal
        Me.btnEmissionOn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnEmissionOn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        resources.ApplyResources(Me.btnEmissionOn, "btnEmissionOn")
        Me.btnEmissionOn.ForeColor = System.Drawing.Color.White
        Me.btnEmissionOn.Name = "btnEmissionOn"
        Me.btnEmissionOn.UseVisualStyleBackColor = False
        '
        'btnStopCorrection
        '
        Me.btnStopCorrection.BackColor = System.Drawing.Color.Red
        Me.btnStopCorrection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnStopCorrection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.btnStopCorrection, "btnStopCorrection")
        Me.btnStopCorrection.ForeColor = System.Drawing.Color.White
        Me.btnStopCorrection.Name = "btnStopCorrection"
        Me.btnStopCorrection.UseVisualStyleBackColor = False
        '
        'TabPageCorrectionValue
        '
        Me.TabPageCorrectionValue.BackColor = System.Drawing.Color.Silver
        Me.TabPageCorrectionValue.Controls.Add(Me.Button7)
        Me.TabPageCorrectionValue.Controls.Add(Me.btnOpenInputForm)
        Me.TabPageCorrectionValue.Controls.Add(Me.btnBuildCorrectionFile)
        Me.TabPageCorrectionValue.Controls.Add(Me.btnSaveCorrectionValue)
        Me.TabPageCorrectionValue.Controls.Add(Me.dgvCorrection)
        resources.ApplyResources(Me.TabPageCorrectionValue, "TabPageCorrectionValue")
        Me.TabPageCorrectionValue.Name = "TabPageCorrectionValue"
        '
        'Button7
        '
        Me.Button7.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.Button7, "Button7")
        Me.Button7.Name = "Button7"
        Me.Button7.UseVisualStyleBackColor = False
        '
        'btnOpenInputForm
        '
        Me.btnOpenInputForm.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.btnOpenInputForm, "btnOpenInputForm")
        Me.btnOpenInputForm.Name = "btnOpenInputForm"
        Me.btnOpenInputForm.UseVisualStyleBackColor = False
        '
        'btnBuildCorrectionFile
        '
        Me.btnBuildCorrectionFile.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.btnBuildCorrectionFile, "btnBuildCorrectionFile")
        Me.btnBuildCorrectionFile.Name = "btnBuildCorrectionFile"
        Me.btnBuildCorrectionFile.UseVisualStyleBackColor = False
        '
        'btnSaveCorrectionValue
        '
        Me.btnSaveCorrectionValue.BackColor = System.Drawing.SystemColors.ControlLightLight
        resources.ApplyResources(Me.btnSaveCorrectionValue, "btnSaveCorrectionValue")
        Me.btnSaveCorrectionValue.Name = "btnSaveCorrectionValue"
        Me.btnSaveCorrectionValue.UseVisualStyleBackColor = False
        '
        'dgvCorrection
        '
        Me.dgvCorrection.AllowUserToAddRows = False
        Me.dgvCorrection.AllowUserToDeleteRows = False
        Me.dgvCorrection.AllowUserToResizeColumns = False
        Me.dgvCorrection.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvCorrection.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvCorrection.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvCorrection.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCorrection.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column5})
        resources.ApplyResources(Me.dgvCorrection, "dgvCorrection")
        Me.dgvCorrection.MultiSelect = False
        Me.dgvCorrection.Name = "dgvCorrection"
        Me.dgvCorrection.RowHeadersVisible = False
        Me.dgvCorrection.RowTemplate.Height = 24
        '
        'Column1
        '
        Me.Column1.FillWeight = 30.0!
        resources.ApplyResources(Me.Column1, "Column1")
        Me.Column1.Name = "Column1"
        Me.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column2
        '
        Me.Column2.FillWeight = 90.0!
        resources.ApplyResources(Me.Column2, "Column2")
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column3
        '
        Me.Column3.FillWeight = 90.0!
        resources.ApplyResources(Me.Column3, "Column3")
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column4
        '
        resources.ApplyResources(Me.Column4, "Column4")
        Me.Column4.Name = "Column4"
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Column5
        '
        resources.ApplyResources(Me.Column5, "Column5")
        Me.Column5.Name = "Column5"
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'TabPageCalibration
        '
        Me.TabPageCalibration.Controls.Add(Me.Button1)
        Me.TabPageCalibration.Controls.Add(Me.cboCalibrationRange)
        Me.TabPageCalibration.Controls.Add(Me.btnSaveCalibration)
        Me.TabPageCalibration.Controls.Add(Me.btnClear)
        Me.TabPageCalibration.Controls.Add(Me.Label42)
        Me.TabPageCalibration.Controls.Add(Me.Label41)
        Me.TabPageCalibration.Controls.Add(Me.Label40)
        Me.TabPageCalibration.Controls.Add(Me.dgvGalvoValue)
        Me.TabPageCalibration.Controls.Add(Me.dgvImageValue)
        Me.TabPageCalibration.Controls.Add(Me.btnKeyImageCalibration)
        Me.TabPageCalibration.Controls.Add(Me.btnKeyCorrectionGalvo)
        resources.ApplyResources(Me.TabPageCalibration, "TabPageCalibration")
        Me.TabPageCalibration.Name = "TabPageCalibration"
        Me.TabPageCalibration.UseVisualStyleBackColor = True
        '
        'Button1
        '
        resources.ApplyResources(Me.Button1, "Button1")
        Me.Button1.Name = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cboCalibrationRange
        '
        Me.cboCalibrationRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCalibrationRange.FormattingEnabled = True
        resources.ApplyResources(Me.cboCalibrationRange, "cboCalibrationRange")
        Me.cboCalibrationRange.Name = "cboCalibrationRange"
        '
        'btnSaveCalibration
        '
        Me.btnSaveCalibration.BackColor = System.Drawing.Color.Olive
        Me.btnSaveCalibration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnSaveCalibration.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnSaveCalibration, "btnSaveCalibration")
        Me.btnSaveCalibration.ForeColor = System.Drawing.Color.White
        Me.btnSaveCalibration.Name = "btnSaveCalibration"
        Me.btnSaveCalibration.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Red
        Me.btnClear.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnClear.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        resources.ApplyResources(Me.btnClear, "btnClear")
        Me.btnClear.ForeColor = System.Drawing.Color.White
        Me.btnClear.Name = "btnClear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'Label42
        '
        resources.ApplyResources(Me.Label42, "Label42")
        Me.Label42.Name = "Label42"
        '
        'Label41
        '
        resources.ApplyResources(Me.Label41, "Label41")
        Me.Label41.Name = "Label41"
        '
        'Label40
        '
        resources.ApplyResources(Me.Label40, "Label40")
        Me.Label40.Name = "Label40"
        '
        'dgvGalvoValue
        '
        Me.dgvGalvoValue.AllowUserToAddRows = False
        Me.dgvGalvoValue.AllowUserToDeleteRows = False
        Me.dgvGalvoValue.AllowUserToResizeColumns = False
        Me.dgvGalvoValue.AllowUserToResizeRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvGalvoValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGalvoValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGalvoValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGalvoValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGalvoValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.Column9, Me.Column10, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3})
        resources.ApplyResources(Me.dgvGalvoValue, "dgvGalvoValue")
        Me.dgvGalvoValue.Name = "dgvGalvoValue"
        Me.dgvGalvoValue.RowHeadersVisible = False
        Me.dgvGalvoValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.FillWeight = 40.0!
        resources.ApplyResources(Me.DataGridViewTextBoxColumn1, "DataGridViewTextBoxColumn1")
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'Column9
        '
        resources.ApplyResources(Me.Column9, "Column9")
        Me.Column9.Name = "Column9"
        '
        'Column10
        '
        resources.ApplyResources(Me.Column10, "Column10")
        Me.Column10.Name = "Column10"
        '
        'DataGridViewTextBoxColumn2
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn2, "DataGridViewTextBoxColumn2")
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        '
        'DataGridViewTextBoxColumn3
        '
        resources.ApplyResources(Me.DataGridViewTextBoxColumn3, "DataGridViewTextBoxColumn3")
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        '
        'dgvImageValue
        '
        Me.dgvImageValue.AllowUserToAddRows = False
        Me.dgvImageValue.AllowUserToDeleteRows = False
        Me.dgvImageValue.AllowUserToResizeColumns = False
        Me.dgvImageValue.AllowUserToResizeRows = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvImageValue.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvImageValue.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("PMingLiU", 12.0!)
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvImageValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvImageValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvImageValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column6, Me.Column7, Me.Column8})
        resources.ApplyResources(Me.dgvImageValue, "dgvImageValue")
        Me.dgvImageValue.Name = "dgvImageValue"
        Me.dgvImageValue.RowHeadersVisible = False
        Me.dgvImageValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'Column6
        '
        Me.Column6.FillWeight = 40.0!
        resources.ApplyResources(Me.Column6, "Column6")
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'Column7
        '
        resources.ApplyResources(Me.Column7, "Column7")
        Me.Column7.Name = "Column7"
        '
        'Column8
        '
        resources.ApplyResources(Me.Column8, "Column8")
        Me.Column8.Name = "Column8"
        '
        'btnKeyImageCalibration
        '
        Me.btnKeyImageCalibration.BackgroundImage = Global.LaserCutting.My.Resources.Resources.edit
        resources.ApplyResources(Me.btnKeyImageCalibration, "btnKeyImageCalibration")
        Me.btnKeyImageCalibration.Name = "btnKeyImageCalibration"
        Me.btnKeyImageCalibration.UseVisualStyleBackColor = True
        '
        'btnKeyCorrectionGalvo
        '
        Me.btnKeyCorrectionGalvo.BackgroundImage = Global.LaserCutting.My.Resources.Resources.edit
        resources.ApplyResources(Me.btnKeyCorrectionGalvo, "btnKeyCorrectionGalvo")
        Me.btnKeyCorrectionGalvo.Name = "btnKeyCorrectionGalvo"
        Me.btnKeyCorrectionGalvo.UseVisualStyleBackColor = True
        '
        'TabPageIOStatus
        '
        Me.TabPageIOStatus.BackColor = System.Drawing.Color.Silver
        Me.TabPageIOStatus.Controls.Add(Me.Label35)
        Me.TabPageIOStatus.Controls.Add(Me.TableLayoutPanel2)
        resources.ApplyResources(Me.TabPageIOStatus, "TabPageIOStatus")
        Me.TabPageIOStatus.Name = "TabPageIOStatus"
        '
        'Label35
        '
        resources.ApplyResources(Me.Label35, "Label35")
        Me.Label35.Name = "Label35"
        '
        'TableLayoutPanel2
        '
        resources.ApplyResources(Me.TableLayoutPanel2, "TableLayoutPanel2")
        Me.TableLayoutPanel2.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut15, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn15, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label18, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label19, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label20, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label21, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label22, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label23, 6, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label24, 7, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label25, 8, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label26, 9, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label27, 10, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label28, 11, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label29, 12, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label30, 13, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label31, 14, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label32, 15, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label33, 16, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label34, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn14, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn13, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn12, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn11, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn10, 6, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn9, 7, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn8, 8, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn7, 9, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn6, 10, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn5, 11, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn4, 12, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn3, 13, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn2, 14, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn1, 15, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbIn0, 16, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut14, 2, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut13, 3, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut12, 4, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut11, 5, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut10, 6, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut9, 7, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut8, 8, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut7, 9, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut6, 10, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut5, 11, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut4, 12, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut3, 13, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut2, 14, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut1, 15, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.ptbOut0, 16, 2)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        '
        'Label9
        '
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'ptbOut15
        '
        Me.ptbOut15.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut15.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut15.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut15, "ptbOut15")
        Me.ptbOut15.Name = "ptbOut15"
        Me.ptbOut15.Radius = 0
        Me.ptbOut15.TabStop = False
        Me.ptbOut15.Tag = "15"
        Me.ptbOut15.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut15.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut15.TurnOn = False
        '
        'ptbIn15
        '
        Me.ptbIn15.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn15.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn15.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn15, "ptbIn15")
        Me.ptbIn15.Name = "ptbIn15"
        Me.ptbIn15.Radius = 0
        Me.ptbIn15.TabStop = False
        Me.ptbIn15.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn15.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn15.TurnOn = False
        '
        'Label18
        '
        resources.ApplyResources(Me.Label18, "Label18")
        Me.Label18.Name = "Label18"
        '
        'Label19
        '
        resources.ApplyResources(Me.Label19, "Label19")
        Me.Label19.Name = "Label19"
        '
        'Label20
        '
        resources.ApplyResources(Me.Label20, "Label20")
        Me.Label20.Name = "Label20"
        '
        'Label21
        '
        resources.ApplyResources(Me.Label21, "Label21")
        Me.Label21.Name = "Label21"
        '
        'Label22
        '
        resources.ApplyResources(Me.Label22, "Label22")
        Me.Label22.Name = "Label22"
        '
        'Label23
        '
        resources.ApplyResources(Me.Label23, "Label23")
        Me.Label23.Name = "Label23"
        '
        'Label24
        '
        resources.ApplyResources(Me.Label24, "Label24")
        Me.Label24.Name = "Label24"
        '
        'Label25
        '
        resources.ApplyResources(Me.Label25, "Label25")
        Me.Label25.Name = "Label25"
        '
        'Label26
        '
        resources.ApplyResources(Me.Label26, "Label26")
        Me.Label26.Name = "Label26"
        '
        'Label27
        '
        resources.ApplyResources(Me.Label27, "Label27")
        Me.Label27.Name = "Label27"
        '
        'Label28
        '
        resources.ApplyResources(Me.Label28, "Label28")
        Me.Label28.Name = "Label28"
        '
        'Label29
        '
        resources.ApplyResources(Me.Label29, "Label29")
        Me.Label29.Name = "Label29"
        '
        'Label30
        '
        resources.ApplyResources(Me.Label30, "Label30")
        Me.Label30.Name = "Label30"
        '
        'Label31
        '
        resources.ApplyResources(Me.Label31, "Label31")
        Me.Label31.Name = "Label31"
        '
        'Label32
        '
        resources.ApplyResources(Me.Label32, "Label32")
        Me.Label32.Name = "Label32"
        '
        'Label33
        '
        resources.ApplyResources(Me.Label33, "Label33")
        Me.Label33.Name = "Label33"
        '
        'Label34
        '
        resources.ApplyResources(Me.Label34, "Label34")
        Me.Label34.Name = "Label34"
        '
        'ptbIn14
        '
        Me.ptbIn14.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn14.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn14.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn14, "ptbIn14")
        Me.ptbIn14.Name = "ptbIn14"
        Me.ptbIn14.Radius = 0
        Me.ptbIn14.TabStop = False
        Me.ptbIn14.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn14.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn14.TurnOn = False
        '
        'ptbIn13
        '
        Me.ptbIn13.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn13.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn13.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn13, "ptbIn13")
        Me.ptbIn13.Name = "ptbIn13"
        Me.ptbIn13.Radius = 0
        Me.ptbIn13.TabStop = False
        Me.ptbIn13.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn13.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn13.TurnOn = False
        '
        'ptbIn12
        '
        Me.ptbIn12.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn12.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn12.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn12, "ptbIn12")
        Me.ptbIn12.Name = "ptbIn12"
        Me.ptbIn12.Radius = 0
        Me.ptbIn12.TabStop = False
        Me.ptbIn12.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn12.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn12.TurnOn = False
        '
        'ptbIn11
        '
        Me.ptbIn11.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn11.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn11.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn11, "ptbIn11")
        Me.ptbIn11.Name = "ptbIn11"
        Me.ptbIn11.Radius = 0
        Me.ptbIn11.TabStop = False
        Me.ptbIn11.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn11.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn11.TurnOn = False
        '
        'ptbIn10
        '
        Me.ptbIn10.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn10.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn10.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn10, "ptbIn10")
        Me.ptbIn10.Name = "ptbIn10"
        Me.ptbIn10.Radius = 0
        Me.ptbIn10.TabStop = False
        Me.ptbIn10.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn10.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn10.TurnOn = False
        '
        'ptbIn9
        '
        Me.ptbIn9.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn9.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn9.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn9, "ptbIn9")
        Me.ptbIn9.Name = "ptbIn9"
        Me.ptbIn9.Radius = 0
        Me.ptbIn9.TabStop = False
        Me.ptbIn9.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn9.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn9.TurnOn = False
        '
        'ptbIn8
        '
        Me.ptbIn8.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn8.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn8.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn8, "ptbIn8")
        Me.ptbIn8.Name = "ptbIn8"
        Me.ptbIn8.Radius = 0
        Me.ptbIn8.TabStop = False
        Me.ptbIn8.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn8.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn8.TurnOn = False
        '
        'ptbIn7
        '
        Me.ptbIn7.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn7.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn7.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn7, "ptbIn7")
        Me.ptbIn7.Name = "ptbIn7"
        Me.ptbIn7.Radius = 0
        Me.ptbIn7.TabStop = False
        Me.ptbIn7.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn7.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn7.TurnOn = False
        '
        'ptbIn6
        '
        Me.ptbIn6.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn6.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn6.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn6, "ptbIn6")
        Me.ptbIn6.Name = "ptbIn6"
        Me.ptbIn6.Radius = 0
        Me.ptbIn6.TabStop = False
        Me.ptbIn6.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn6.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn6.TurnOn = False
        '
        'ptbIn5
        '
        Me.ptbIn5.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn5.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn5.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn5, "ptbIn5")
        Me.ptbIn5.Name = "ptbIn5"
        Me.ptbIn5.Radius = 0
        Me.ptbIn5.TabStop = False
        Me.ptbIn5.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn5.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn5.TurnOn = False
        '
        'ptbIn4
        '
        Me.ptbIn4.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn4.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn4.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn4, "ptbIn4")
        Me.ptbIn4.Name = "ptbIn4"
        Me.ptbIn4.Radius = 0
        Me.ptbIn4.TabStop = False
        Me.ptbIn4.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn4.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn4.TurnOn = False
        '
        'ptbIn3
        '
        Me.ptbIn3.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn3.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn3.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn3, "ptbIn3")
        Me.ptbIn3.Name = "ptbIn3"
        Me.ptbIn3.Radius = 0
        Me.ptbIn3.TabStop = False
        Me.ptbIn3.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn3.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn3.TurnOn = False
        '
        'ptbIn2
        '
        Me.ptbIn2.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn2.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn2.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn2, "ptbIn2")
        Me.ptbIn2.Name = "ptbIn2"
        Me.ptbIn2.Radius = 0
        Me.ptbIn2.TabStop = False
        Me.ptbIn2.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn2.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn2.TurnOn = False
        '
        'ptbIn1
        '
        Me.ptbIn1.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn1.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn1.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn1, "ptbIn1")
        Me.ptbIn1.Name = "ptbIn1"
        Me.ptbIn1.Radius = 0
        Me.ptbIn1.TabStop = False
        Me.ptbIn1.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn1.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn1.TurnOn = False
        '
        'ptbIn0
        '
        Me.ptbIn0.BorderShape = LaserCutting.eShape.Circle
        Me.ptbIn0.BottomColorOff = System.Drawing.Color.Black
        Me.ptbIn0.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbIn0, "ptbIn0")
        Me.ptbIn0.Name = "ptbIn0"
        Me.ptbIn0.Radius = 0
        Me.ptbIn0.TabStop = False
        Me.ptbIn0.TopColorOff = System.Drawing.Color.Maroon
        Me.ptbIn0.TopColorOn = System.Drawing.Color.Red
        Me.ptbIn0.TurnOn = False
        '
        'ptbOut14
        '
        Me.ptbOut14.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut14.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut14.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut14, "ptbOut14")
        Me.ptbOut14.Name = "ptbOut14"
        Me.ptbOut14.Radius = 0
        Me.ptbOut14.TabStop = False
        Me.ptbOut14.Tag = "14"
        Me.ptbOut14.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut14.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut14.TurnOn = False
        '
        'ptbOut13
        '
        Me.ptbOut13.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut13.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut13.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut13, "ptbOut13")
        Me.ptbOut13.Name = "ptbOut13"
        Me.ptbOut13.Radius = 0
        Me.ptbOut13.TabStop = False
        Me.ptbOut13.Tag = "13"
        Me.ptbOut13.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut13.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut13.TurnOn = False
        '
        'ptbOut12
        '
        Me.ptbOut12.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut12.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut12.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut12, "ptbOut12")
        Me.ptbOut12.Name = "ptbOut12"
        Me.ptbOut12.Radius = 0
        Me.ptbOut12.TabStop = False
        Me.ptbOut12.Tag = "12"
        Me.ptbOut12.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut12.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut12.TurnOn = False
        '
        'ptbOut11
        '
        Me.ptbOut11.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut11.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut11.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut11, "ptbOut11")
        Me.ptbOut11.Name = "ptbOut11"
        Me.ptbOut11.Radius = 0
        Me.ptbOut11.TabStop = False
        Me.ptbOut11.Tag = "11"
        Me.ptbOut11.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut11.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut11.TurnOn = False
        '
        'ptbOut10
        '
        Me.ptbOut10.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut10.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut10.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut10, "ptbOut10")
        Me.ptbOut10.Name = "ptbOut10"
        Me.ptbOut10.Radius = 0
        Me.ptbOut10.TabStop = False
        Me.ptbOut10.Tag = "10"
        Me.ptbOut10.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut10.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut10.TurnOn = False
        '
        'ptbOut9
        '
        Me.ptbOut9.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut9.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut9.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut9, "ptbOut9")
        Me.ptbOut9.Name = "ptbOut9"
        Me.ptbOut9.Radius = 0
        Me.ptbOut9.TabStop = False
        Me.ptbOut9.Tag = "9"
        Me.ptbOut9.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut9.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut9.TurnOn = False
        '
        'ptbOut8
        '
        Me.ptbOut8.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut8.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut8.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut8, "ptbOut8")
        Me.ptbOut8.Name = "ptbOut8"
        Me.ptbOut8.Radius = 0
        Me.ptbOut8.TabStop = False
        Me.ptbOut8.Tag = "8"
        Me.ptbOut8.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut8.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut8.TurnOn = False
        '
        'ptbOut7
        '
        Me.ptbOut7.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut7.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut7.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut7, "ptbOut7")
        Me.ptbOut7.Name = "ptbOut7"
        Me.ptbOut7.Radius = 0
        Me.ptbOut7.TabStop = False
        Me.ptbOut7.Tag = "7"
        Me.ptbOut7.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut7.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut7.TurnOn = False
        '
        'ptbOut6
        '
        Me.ptbOut6.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut6.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut6.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut6, "ptbOut6")
        Me.ptbOut6.Name = "ptbOut6"
        Me.ptbOut6.Radius = 0
        Me.ptbOut6.TabStop = False
        Me.ptbOut6.Tag = "6"
        Me.ptbOut6.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut6.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut6.TurnOn = False
        '
        'ptbOut5
        '
        Me.ptbOut5.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut5.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut5.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut5, "ptbOut5")
        Me.ptbOut5.Name = "ptbOut5"
        Me.ptbOut5.Radius = 0
        Me.ptbOut5.TabStop = False
        Me.ptbOut5.Tag = "5"
        Me.ptbOut5.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut5.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut5.TurnOn = False
        '
        'ptbOut4
        '
        Me.ptbOut4.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut4.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut4.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut4, "ptbOut4")
        Me.ptbOut4.Name = "ptbOut4"
        Me.ptbOut4.Radius = 0
        Me.ptbOut4.TabStop = False
        Me.ptbOut4.Tag = "4"
        Me.ptbOut4.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut4.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut4.TurnOn = False
        '
        'ptbOut3
        '
        Me.ptbOut3.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut3.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut3.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut3, "ptbOut3")
        Me.ptbOut3.Name = "ptbOut3"
        Me.ptbOut3.Radius = 0
        Me.ptbOut3.TabStop = False
        Me.ptbOut3.Tag = "3"
        Me.ptbOut3.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut3.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut3.TurnOn = False
        '
        'ptbOut2
        '
        Me.ptbOut2.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut2.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut2.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut2, "ptbOut2")
        Me.ptbOut2.Name = "ptbOut2"
        Me.ptbOut2.Radius = 0
        Me.ptbOut2.TabStop = False
        Me.ptbOut2.Tag = "2"
        Me.ptbOut2.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut2.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut2.TurnOn = False
        '
        'ptbOut1
        '
        Me.ptbOut1.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut1.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut1.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut1, "ptbOut1")
        Me.ptbOut1.Name = "ptbOut1"
        Me.ptbOut1.Radius = 0
        Me.ptbOut1.TabStop = False
        Me.ptbOut1.Tag = "1"
        Me.ptbOut1.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut1.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut1.TurnOn = False
        '
        'ptbOut0
        '
        Me.ptbOut0.BorderShape = LaserCutting.eShape.Circle
        Me.ptbOut0.BottomColorOff = System.Drawing.Color.Black
        Me.ptbOut0.BottomColorOn = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.ptbOut0, "ptbOut0")
        Me.ptbOut0.Name = "ptbOut0"
        Me.ptbOut0.Radius = 0
        Me.ptbOut0.TabStop = False
        Me.ptbOut0.Tag = "0"
        Me.ptbOut0.TopColorOff = System.Drawing.Color.DarkGreen
        Me.ptbOut0.TopColorOn = System.Drawing.Color.Lime
        Me.ptbOut0.TurnOn = False
        '
        'TabPageAxis
        '
        Me.TabPageAxis.BackgroundImage = Global.LaserCutting.My.Resources.Resources.Axis2
        resources.ApplyResources(Me.TabPageAxis, "TabPageAxis")
        Me.TabPageAxis.Controls.Add(Me.Label44)
        Me.TabPageAxis.Controls.Add(Me.Label43)
        Me.TabPageAxis.Name = "TabPageAxis"
        Me.TabPageAxis.UseVisualStyleBackColor = True
        '
        'Label44
        '
        resources.ApplyResources(Me.Label44, "Label44")
        Me.Label44.Name = "Label44"
        '
        'Label43
        '
        resources.ApplyResources(Me.Label43, "Label43")
        Me.Label43.Name = "Label43"
        '
        'TabPageScale
        '
        Me.TabPageScale.BackColor = System.Drawing.Color.Silver
        Me.TabPageScale.Controls.Add(Me.GroupBox15)
        Me.TabPageScale.Controls.Add(Me.btnSaveScale)
        Me.TabPageScale.Controls.Add(Me.btnCalScale)
        Me.TabPageScale.Controls.Add(Me.btnMarkLineScale)
        Me.TabPageScale.Controls.Add(Me.numCalScale)
        Me.TabPageScale.Controls.Add(Me.numLengthScalePX)
        Me.TabPageScale.Controls.Add(Me.Label52)
        Me.TabPageScale.Controls.Add(Me.Label54)
        Me.TabPageScale.Controls.Add(Me.numLengthScaleMM)
        Me.TabPageScale.Controls.Add(Me.Label50)
        Me.TabPageScale.Controls.Add(Me.Label48)
        Me.TabPageScale.Controls.Add(Me.Label47)
        resources.ApplyResources(Me.TabPageScale, "TabPageScale")
        Me.TabPageScale.Name = "TabPageScale"
        '
        'GroupBox15
        '
        Me.GroupBox15.Controls.Add(Me.numScaleLaserPRR)
        Me.GroupBox15.Controls.Add(Me.chkScaleUseLaser)
        Me.GroupBox15.Controls.Add(Me.Label55)
        Me.GroupBox15.Controls.Add(Me.Label56)
        Me.GroupBox15.Controls.Add(Me.Label57)
        Me.GroupBox15.Controls.Add(Me.Label58)
        Me.GroupBox15.Controls.Add(Me.numScaleLaserPower)
        Me.GroupBox15.ForeColor = System.Drawing.Color.Blue
        resources.ApplyResources(Me.GroupBox15, "GroupBox15")
        Me.GroupBox15.Name = "GroupBox15"
        Me.GroupBox15.TabStop = False
        '
        'chkScaleUseLaser
        '
        resources.ApplyResources(Me.chkScaleUseLaser, "chkScaleUseLaser")
        Me.chkScaleUseLaser.Name = "chkScaleUseLaser"
        Me.chkScaleUseLaser.UseVisualStyleBackColor = True
        '
        'Label56
        '
        Me.Label56.BackColor = System.Drawing.Color.White
        Me.Label56.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label56.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label56, "Label56")
        Me.Label56.Name = "Label56"
        '
        'Label58
        '
        Me.Label58.BackColor = System.Drawing.Color.White
        Me.Label58.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label58.ForeColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.Label58, "Label58")
        Me.Label58.Name = "Label58"
        '
        'btnSaveScale
        '
        Me.btnSaveScale.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnSaveScale, "btnSaveScale")
        Me.btnSaveScale.Name = "btnSaveScale"
        Me.btnSaveScale.UseVisualStyleBackColor = False
        '
        'btnCalScale
        '
        Me.btnCalScale.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCalScale, "btnCalScale")
        Me.btnCalScale.Name = "btnCalScale"
        Me.btnCalScale.UseVisualStyleBackColor = False
        '
        'btnMarkLineScale
        '
        Me.btnMarkLineScale.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnMarkLineScale, "btnMarkLineScale")
        Me.btnMarkLineScale.Name = "btnMarkLineScale"
        Me.btnMarkLineScale.UseVisualStyleBackColor = False
        '
        'numCalScale
        '
        Me.numCalScale.DecimalPlaces = 16
        resources.ApplyResources(Me.numCalScale, "numCalScale")
        Me.numCalScale.Name = "numCalScale"
        '
        'numLengthScalePX
        '
        resources.ApplyResources(Me.numLengthScalePX, "numLengthScalePX")
        Me.numLengthScalePX.Maximum = New Decimal(New Integer() {1000000000, 0, 0, 0})
        Me.numLengthScalePX.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLengthScalePX.Name = "numLengthScalePX"
        Me.numLengthScalePX.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label52
        '
        resources.ApplyResources(Me.Label52, "Label52")
        Me.Label52.Name = "Label52"
        '
        'Label54
        '
        resources.ApplyResources(Me.Label54, "Label54")
        Me.Label54.Name = "Label54"
        '
        'numLengthScaleMM
        '
        resources.ApplyResources(Me.numLengthScaleMM, "numLengthScaleMM")
        Me.numLengthScaleMM.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.numLengthScaleMM.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numLengthScaleMM.Name = "numLengthScaleMM"
        Me.numLengthScaleMM.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label50
        '
        resources.ApplyResources(Me.Label50, "Label50")
        Me.Label50.Name = "Label50"
        '
        'Label48
        '
        resources.ApplyResources(Me.Label48, "Label48")
        Me.Label48.Name = "Label48"
        '
        'Label47
        '
        resources.ApplyResources(Me.Label47, "Label47")
        Me.Label47.Name = "Label47"
        '
        'TabPagePos
        '
        Me.TabPagePos.BackColor = System.Drawing.Color.Silver
        Me.TabPagePos.Controls.Add(Me.GroupBox9)
        resources.ApplyResources(Me.TabPagePos, "TabPagePos")
        Me.TabPagePos.Name = "TabPagePos"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.GroupBox16)
        Me.GroupBox9.Controls.Add(Me.GroupBox14)
        Me.GroupBox9.Controls.Add(Me.GroupBox12)
        Me.GroupBox9.Controls.Add(Me.GroupBox13)
        Me.GroupBox9.Controls.Add(Me.GroupBox18)
        Me.GroupBox9.Controls.Add(Me.GroupBox17)
        Me.GroupBox9.Controls.Add(Me.GroupBox10)
        Me.GroupBox9.Controls.Add(Me.GroupBox11)
        Me.GroupBox9.Controls.Add(Me.btnSavePos)
        Me.GroupBox9.Controls.Add(Me.groupWorkholderX)
        Me.GroupBox9.Controls.Add(Me.GroupBox8)
        Me.GroupBox9.Controls.Add(Me.GroupBox7)
        Me.GroupBox9.Controls.Add(Me.GroupBox6)
        resources.ApplyResources(Me.GroupBox9, "GroupBox9")
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.TabStop = False
        '
        'GroupBox16
        '
        Me.GroupBox16.BackColor = System.Drawing.Color.Silver
        Me.GroupBox16.Controls.Add(Me.TableLayoutPanel8)
        resources.ApplyResources(Me.GroupBox16, "GroupBox16")
        Me.GroupBox16.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox16.Name = "GroupBox16"
        Me.GroupBox16.TabStop = False
        '
        'TableLayoutPanel8
        '
        resources.ApplyResources(Me.TableLayoutPanel8, "TableLayoutPanel8")
        Me.TableLayoutPanel8.Controls.Add(Me.btnCylinder10, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.btnCylinder11, 1, 0)
        Me.TableLayoutPanel8.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        '
        'btnCylinder10
        '
        Me.btnCylinder10.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder10, "btnCylinder10")
        Me.btnCylinder10.Name = "btnCylinder10"
        Me.btnCylinder10.UseVisualStyleBackColor = False
        '
        'btnCylinder11
        '
        Me.btnCylinder11.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder11, "btnCylinder11")
        Me.btnCylinder11.Name = "btnCylinder11"
        Me.btnCylinder11.UseVisualStyleBackColor = False
        '
        'GroupBox14
        '
        Me.GroupBox14.BackColor = System.Drawing.Color.Silver
        Me.GroupBox14.Controls.Add(Me.TableLayoutPanel7)
        resources.ApplyResources(Me.GroupBox14, "GroupBox14")
        Me.GroupBox14.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.TabStop = False
        '
        'TableLayoutPanel7
        '
        resources.ApplyResources(Me.TableLayoutPanel7, "TableLayoutPanel7")
        Me.TableLayoutPanel7.Controls.Add(Me.btnCylinder8, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.btnCylinder9, 1, 0)
        Me.TableLayoutPanel7.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        '
        'btnCylinder8
        '
        Me.btnCylinder8.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder8, "btnCylinder8")
        Me.btnCylinder8.Name = "btnCylinder8"
        Me.btnCylinder8.UseVisualStyleBackColor = False
        '
        'btnCylinder9
        '
        Me.btnCylinder9.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder9, "btnCylinder9")
        Me.btnCylinder9.Name = "btnCylinder9"
        Me.btnCylinder9.UseVisualStyleBackColor = False
        '
        'GroupBox12
        '
        Me.GroupBox12.BackColor = System.Drawing.Color.Silver
        Me.GroupBox12.Controls.Add(Me.TableLayoutPanel6)
        resources.ApplyResources(Me.GroupBox12, "GroupBox12")
        Me.GroupBox12.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.TabStop = False
        '
        'TableLayoutPanel6
        '
        resources.ApplyResources(Me.TableLayoutPanel6, "TableLayoutPanel6")
        Me.TableLayoutPanel6.Controls.Add(Me.btnCylinder4, 0, 0)
        Me.TableLayoutPanel6.Controls.Add(Me.btnCylinder5, 1, 0)
        Me.TableLayoutPanel6.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        '
        'btnCylinder4
        '
        Me.btnCylinder4.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder4, "btnCylinder4")
        Me.btnCylinder4.Name = "btnCylinder4"
        Me.btnCylinder4.UseVisualStyleBackColor = False
        '
        'btnCylinder5
        '
        Me.btnCylinder5.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder5, "btnCylinder5")
        Me.btnCylinder5.Name = "btnCylinder5"
        Me.btnCylinder5.UseVisualStyleBackColor = False
        '
        'GroupBox13
        '
        Me.GroupBox13.BackColor = System.Drawing.Color.Silver
        Me.GroupBox13.Controls.Add(Me.TableLayoutPanel17)
        resources.ApplyResources(Me.GroupBox13, "GroupBox13")
        Me.GroupBox13.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.TabStop = False
        '
        'TableLayoutPanel17
        '
        resources.ApplyResources(Me.TableLayoutPanel17, "TableLayoutPanel17")
        Me.TableLayoutPanel17.Controls.Add(Me.btnCylinder2, 0, 0)
        Me.TableLayoutPanel17.Controls.Add(Me.btnCylinder3, 1, 0)
        Me.TableLayoutPanel17.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel17.Name = "TableLayoutPanel17"
        '
        'btnCylinder2
        '
        Me.btnCylinder2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder2, "btnCylinder2")
        Me.btnCylinder2.Name = "btnCylinder2"
        Me.btnCylinder2.UseVisualStyleBackColor = False
        '
        'btnCylinder3
        '
        Me.btnCylinder3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder3, "btnCylinder3")
        Me.btnCylinder3.Name = "btnCylinder3"
        Me.btnCylinder3.UseVisualStyleBackColor = False
        '
        'GroupBox18
        '
        Me.GroupBox18.BackColor = System.Drawing.Color.Silver
        Me.GroupBox18.Controls.Add(Me.TableLayoutPanel11)
        resources.ApplyResources(Me.GroupBox18, "GroupBox18")
        Me.GroupBox18.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox18.Name = "GroupBox18"
        Me.GroupBox18.TabStop = False
        '
        'TableLayoutPanel11
        '
        resources.ApplyResources(Me.TableLayoutPanel11, "TableLayoutPanel11")
        Me.TableLayoutPanel11.Controls.Add(Me.btnCylinder14, 0, 0)
        Me.TableLayoutPanel11.Controls.Add(Me.btnCylinder15, 1, 0)
        Me.TableLayoutPanel11.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel11.Name = "TableLayoutPanel11"
        '
        'btnCylinder14
        '
        Me.btnCylinder14.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder14, "btnCylinder14")
        Me.btnCylinder14.Name = "btnCylinder14"
        Me.btnCylinder14.UseVisualStyleBackColor = False
        '
        'btnCylinder15
        '
        Me.btnCylinder15.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder15, "btnCylinder15")
        Me.btnCylinder15.Name = "btnCylinder15"
        Me.btnCylinder15.UseVisualStyleBackColor = False
        '
        'GroupBox17
        '
        Me.GroupBox17.BackColor = System.Drawing.Color.Silver
        Me.GroupBox17.Controls.Add(Me.TableLayoutPanel9)
        resources.ApplyResources(Me.GroupBox17, "GroupBox17")
        Me.GroupBox17.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox17.Name = "GroupBox17"
        Me.GroupBox17.TabStop = False
        '
        'TableLayoutPanel9
        '
        resources.ApplyResources(Me.TableLayoutPanel9, "TableLayoutPanel9")
        Me.TableLayoutPanel9.Controls.Add(Me.btnCylinder12, 0, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnCylinder13, 1, 0)
        Me.TableLayoutPanel9.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        '
        'btnCylinder12
        '
        Me.btnCylinder12.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder12, "btnCylinder12")
        Me.btnCylinder12.Name = "btnCylinder12"
        Me.btnCylinder12.UseVisualStyleBackColor = False
        '
        'btnCylinder13
        '
        Me.btnCylinder13.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder13, "btnCylinder13")
        Me.btnCylinder13.Name = "btnCylinder13"
        Me.btnCylinder13.UseVisualStyleBackColor = False
        '
        'GroupBox10
        '
        Me.GroupBox10.BackColor = System.Drawing.Color.Silver
        Me.GroupBox10.Controls.Add(Me.TableLayoutPanel14)
        resources.ApplyResources(Me.GroupBox10, "GroupBox10")
        Me.GroupBox10.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.TabStop = False
        '
        'TableLayoutPanel14
        '
        resources.ApplyResources(Me.TableLayoutPanel14, "TableLayoutPanel14")
        Me.TableLayoutPanel14.Controls.Add(Me.btnCylinder6, 0, 0)
        Me.TableLayoutPanel14.Controls.Add(Me.btnCylinder7, 1, 0)
        Me.TableLayoutPanel14.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel14.Name = "TableLayoutPanel14"
        '
        'btnCylinder6
        '
        Me.btnCylinder6.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder6, "btnCylinder6")
        Me.btnCylinder6.Name = "btnCylinder6"
        Me.btnCylinder6.UseVisualStyleBackColor = False
        '
        'btnCylinder7
        '
        Me.btnCylinder7.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder7, "btnCylinder7")
        Me.btnCylinder7.Name = "btnCylinder7"
        Me.btnCylinder7.UseVisualStyleBackColor = False
        '
        'GroupBox11
        '
        Me.GroupBox11.BackColor = System.Drawing.Color.Silver
        Me.GroupBox11.Controls.Add(Me.TableLayoutPanel10)
        resources.ApplyResources(Me.GroupBox11, "GroupBox11")
        Me.GroupBox11.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.TabStop = False
        '
        'TableLayoutPanel10
        '
        resources.ApplyResources(Me.TableLayoutPanel10, "TableLayoutPanel10")
        Me.TableLayoutPanel10.Controls.Add(Me.btnCylinder0, 0, 0)
        Me.TableLayoutPanel10.Controls.Add(Me.btnCylinder1, 1, 0)
        Me.TableLayoutPanel10.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel10.Name = "TableLayoutPanel10"
        '
        'btnCylinder0
        '
        Me.btnCylinder0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder0, "btnCylinder0")
        Me.btnCylinder0.Name = "btnCylinder0"
        Me.btnCylinder0.UseVisualStyleBackColor = False
        '
        'btnCylinder1
        '
        Me.btnCylinder1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnCylinder1, "btnCylinder1")
        Me.btnCylinder1.Name = "btnCylinder1"
        Me.btnCylinder1.UseVisualStyleBackColor = False
        '
        'btnSavePos
        '
        resources.ApplyResources(Me.btnSavePos, "btnSavePos")
        Me.btnSavePos.BackColor = System.Drawing.Color.Olive
        Me.btnSavePos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnSavePos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSavePos.ForeColor = System.Drawing.Color.White
        Me.btnSavePos.Image = Global.LaserCutting.My.Resources.Resources.save
        Me.btnSavePos.Name = "btnSavePos"
        Me.btnSavePos.UseVisualStyleBackColor = False
        '
        'groupWorkholderX
        '
        Me.groupWorkholderX.BackColor = System.Drawing.Color.Silver
        Me.groupWorkholderX.Controls.Add(Me.TableLayoutPanel5)
        resources.ApplyResources(Me.groupWorkholderX, "groupWorkholderX")
        Me.groupWorkholderX.ForeColor = System.Drawing.Color.Blue
        Me.groupWorkholderX.Name = "groupWorkholderX"
        Me.groupWorkholderX.TabStop = False
        '
        'TableLayoutPanel5
        '
        resources.ApplyResources(Me.TableLayoutPanel5, "TableLayoutPanel5")
        Me.TableLayoutPanel5.Controls.Add(Me.Label46, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.numMovingDistance0, 1, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.btnWorkholderTestMove0, 0, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.btnWorkholderTestMove1, 1, 1)
        Me.TableLayoutPanel5.Controls.Add(Me.lblWorkholderXNow, 2, 0)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        '
        'Label46
        '
        Me.Label46.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label46.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label46.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label46, "Label46")
        Me.Label46.ForeColor = System.Drawing.Color.Black
        Me.Label46.Name = "Label46"
        '
        'numMovingDistance0
        '
        resources.ApplyResources(Me.numMovingDistance0, "numMovingDistance0")
        Me.numMovingDistance0.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.numMovingDistance0.Name = "numMovingDistance0"
        Me.numMovingDistance0.Value = New Decimal(New Integer() {1000, 0, 0, 0})
        '
        'btnWorkholderTestMove0
        '
        Me.btnWorkholderTestMove0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderTestMove0, "btnWorkholderTestMove0")
        Me.btnWorkholderTestMove0.ForeColor = System.Drawing.Color.Black
        Me.btnWorkholderTestMove0.Name = "btnWorkholderTestMove0"
        Me.btnWorkholderTestMove0.UseVisualStyleBackColor = False
        '
        'btnWorkholderTestMove1
        '
        Me.btnWorkholderTestMove1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderTestMove1, "btnWorkholderTestMove1")
        Me.btnWorkholderTestMove1.ForeColor = System.Drawing.Color.Black
        Me.btnWorkholderTestMove1.Name = "btnWorkholderTestMove1"
        Me.btnWorkholderTestMove1.UseVisualStyleBackColor = False
        '
        'lblWorkholderXNow
        '
        Me.lblWorkholderXNow.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.lblWorkholderXNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWorkholderXNow.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.lblWorkholderXNow, "lblWorkholderXNow")
        Me.lblWorkholderXNow.ForeColor = System.Drawing.Color.Black
        Me.lblWorkholderXNow.Name = "lblWorkholderXNow"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Silver
        Me.GroupBox8.Controls.Add(Me.TableLayoutPanel4)
        resources.ApplyResources(Me.GroupBox8, "GroupBox8")
        Me.GroupBox8.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.TabStop = False
        '
        'TableLayoutPanel4
        '
        resources.ApplyResources(Me.TableLayoutPanel4, "TableLayoutPanel4")
        Me.TableLayoutPanel4.Controls.Add(Me.Label53, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.numWorkhodlerX3, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnWorkholderMove3, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnWorkholderSet3, 3, 0)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        '
        'Label53
        '
        Me.Label53.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label53.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label53.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label53, "Label53")
        Me.Label53.Name = "Label53"
        '
        'numWorkhodlerX3
        '
        resources.ApplyResources(Me.numWorkhodlerX3, "numWorkhodlerX3")
        Me.numWorkhodlerX3.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numWorkhodlerX3.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.numWorkhodlerX3.Name = "numWorkhodlerX3"
        '
        'btnWorkholderMove3
        '
        Me.btnWorkholderMove3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderMove3, "btnWorkholderMove3")
        Me.btnWorkholderMove3.Name = "btnWorkholderMove3"
        Me.btnWorkholderMove3.UseVisualStyleBackColor = False
        '
        'btnWorkholderSet3
        '
        Me.btnWorkholderSet3.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderSet3, "btnWorkholderSet3")
        Me.btnWorkholderSet3.Name = "btnWorkholderSet3"
        Me.btnWorkholderSet3.UseVisualStyleBackColor = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Silver
        Me.GroupBox7.Controls.Add(Me.TableLayoutPanel3)
        resources.ApplyResources(Me.GroupBox7, "GroupBox7")
        Me.GroupBox7.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.TabStop = False
        '
        'TableLayoutPanel3
        '
        resources.ApplyResources(Me.TableLayoutPanel3, "TableLayoutPanel3")
        Me.TableLayoutPanel3.Controls.Add(Me.Label49, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.numWorkhodlerX1, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnWorkholderMove1, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnWorkholderSet1, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label51, 0, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.numWorkhodlerX2, 1, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnWorkholderMove2, 2, 2)
        Me.TableLayoutPanel3.Controls.Add(Me.btnWorkholderSet2, 3, 2)
        Me.TableLayoutPanel3.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        '
        'Label49
        '
        Me.Label49.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label49.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label49.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label49, "Label49")
        Me.Label49.Name = "Label49"
        '
        'numWorkhodlerX1
        '
        resources.ApplyResources(Me.numWorkhodlerX1, "numWorkhodlerX1")
        Me.numWorkhodlerX1.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numWorkhodlerX1.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.numWorkhodlerX1.Name = "numWorkhodlerX1"
        '
        'btnWorkholderMove1
        '
        Me.btnWorkholderMove1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderMove1, "btnWorkholderMove1")
        Me.btnWorkholderMove1.Name = "btnWorkholderMove1"
        Me.btnWorkholderMove1.UseVisualStyleBackColor = False
        '
        'btnWorkholderSet1
        '
        Me.btnWorkholderSet1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderSet1, "btnWorkholderSet1")
        Me.btnWorkholderSet1.Name = "btnWorkholderSet1"
        Me.btnWorkholderSet1.UseVisualStyleBackColor = False
        '
        'Label51
        '
        Me.Label51.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label51.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label51.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label51, "Label51")
        Me.Label51.Name = "Label51"
        '
        'numWorkhodlerX2
        '
        resources.ApplyResources(Me.numWorkhodlerX2, "numWorkhodlerX2")
        Me.numWorkhodlerX2.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numWorkhodlerX2.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.numWorkhodlerX2.Name = "numWorkhodlerX2"
        '
        'btnWorkholderMove2
        '
        Me.btnWorkholderMove2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderMove2, "btnWorkholderMove2")
        Me.btnWorkholderMove2.Name = "btnWorkholderMove2"
        Me.btnWorkholderMove2.UseVisualStyleBackColor = False
        '
        'btnWorkholderSet2
        '
        Me.btnWorkholderSet2.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderSet2, "btnWorkholderSet2")
        Me.btnWorkholderSet2.Name = "btnWorkholderSet2"
        Me.btnWorkholderSet2.UseVisualStyleBackColor = False
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Silver
        Me.GroupBox6.Controls.Add(Me.TableLayoutPanel13)
        resources.ApplyResources(Me.GroupBox6, "GroupBox6")
        Me.GroupBox6.ForeColor = System.Drawing.Color.Blue
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.TabStop = False
        '
        'TableLayoutPanel13
        '
        resources.ApplyResources(Me.TableLayoutPanel13, "TableLayoutPanel13")
        Me.TableLayoutPanel13.Controls.Add(Me.Label45, 0, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.numWorkhodlerX0, 1, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.btnWorkholderMove0, 2, 0)
        Me.TableLayoutPanel13.Controls.Add(Me.btnWorkholderSet0, 3, 0)
        Me.TableLayoutPanel13.ForeColor = System.Drawing.Color.Black
        Me.TableLayoutPanel13.Name = "TableLayoutPanel13"
        '
        'Label45
        '
        Me.Label45.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Label45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label45.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        resources.ApplyResources(Me.Label45, "Label45")
        Me.Label45.Name = "Label45"
        '
        'numWorkhodlerX0
        '
        resources.ApplyResources(Me.numWorkhodlerX0, "numWorkhodlerX0")
        Me.numWorkhodlerX0.Maximum = New Decimal(New Integer() {1000000, 0, 0, 0})
        Me.numWorkhodlerX0.Minimum = New Decimal(New Integer() {1000000, 0, 0, -2147483648})
        Me.numWorkhodlerX0.Name = "numWorkhodlerX0"
        '
        'btnWorkholderMove0
        '
        Me.btnWorkholderMove0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderMove0, "btnWorkholderMove0")
        Me.btnWorkholderMove0.Name = "btnWorkholderMove0"
        Me.btnWorkholderMove0.UseVisualStyleBackColor = False
        '
        'btnWorkholderSet0
        '
        Me.btnWorkholderSet0.BackColor = System.Drawing.SystemColors.ButtonHighlight
        resources.ApplyResources(Me.btnWorkholderSet0, "btnWorkholderSet0")
        Me.btnWorkholderSet0.Name = "btnWorkholderSet0"
        Me.btnWorkholderSet0.UseVisualStyleBackColor = False
        '
        'TabPageLog
        '
        Me.TabPageLog.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.TabPageLog, "TabPageLog")
        Me.TabPageLog.Name = "TabPageLog"
        '
        'TabPagePassword
        '
        Me.TabPagePassword.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.TabPagePassword, "TabPagePassword")
        Me.TabPagePassword.Name = "TabPagePassword"
        '
        'ContextMenuStripPassword
        '
        Me.ContextMenuStripPassword.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem, Me.LoginToolStripMenuItem})
        Me.ContextMenuStripPassword.Name = "ContextMenuStripPassword"
        resources.ApplyResources(Me.ContextMenuStripPassword, "ContextMenuStripPassword")
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        resources.ApplyResources(Me.ChangePasswordToolStripMenuItem, "ChangePasswordToolStripMenuItem")
        '
        'LoginToolStripMenuItem
        '
        Me.LoginToolStripMenuItem.Name = "LoginToolStripMenuItem"
        resources.ApplyResources(Me.LoginToolStripMenuItem, "LoginToolStripMenuItem")
        '
        'lnkLanguage
        '
        resources.ApplyResources(Me.lnkLanguage, "lnkLanguage")
        Me.lnkLanguage.LinkColor = System.Drawing.Color.White
        Me.lnkLanguage.Name = "lnkLanguage"
        Me.lnkLanguage.TabStop = True
        Me.lnkLanguage.VisitedLinkColor = System.Drawing.Color.White
        '
        'grbCamera
        '
        Me.grbCamera.BackColor = System.Drawing.Color.Black
        resources.ApplyResources(Me.grbCamera, "grbCamera")
        Me.grbCamera.Name = "grbCamera"
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Olive
        resources.ApplyResources(Me.btnSave, "btnSave")
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Image = Global.LaserCutting.My.Resources.Resources.save
        Me.btnSave.Name = "btnSave"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnOpenProject
        '
        Me.btnOpenProject.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnOpenProject, "btnOpenProject")
        Me.btnOpenProject.ForeColor = System.Drawing.Color.White
        Me.btnOpenProject.Image = Global.LaserCutting.My.Resources.Resources.open
        Me.btnOpenProject.Name = "btnOpenProject"
        Me.btnOpenProject.UseVisualStyleBackColor = False
        '
        'btnNewProject
        '
        Me.btnNewProject.BackColor = System.Drawing.Color.Teal
        resources.ApplyResources(Me.btnNewProject, "btnNewProject")
        Me.btnNewProject.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnNewProject.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnNewProject.ForeColor = System.Drawing.Color.White
        Me.btnNewProject.Image = Global.LaserCutting.My.Resources.Resources.addnew
        Me.btnNewProject.Name = "btnNewProject"
        Me.btnNewProject.UseVisualStyleBackColor = False
        '
        'Timer_GetLaserExecuteFinish
        '
        '
        'TimerGetRTC4IO
        '
        '
        'FMain
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.lnkLanguage)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnOpenProject)
        Me.Controls.Add(Me.btnNewProject)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.grbCamera)
        Me.Name = "FMain"
        Me.ContextMenuStripMoveLine.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.tblEditTable.ResumeLayout(False)
        CType(Me.numPRR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGalvoOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGalvoOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numGalvoAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDIDelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numDODelay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleLaserPRR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleLaserPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numPX2MM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.pnEdit.ResumeLayout(False)
        Me.GroupBoxEx2.ResumeLayout(False)
        CType(Me.numFixDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxEx1.ResumeLayout(False)
        Me.TableLayoutPanel15.ResumeLayout(False)
        CType(Me.numRotateAngle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMoveDistance, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel12.ResumeLayout(False)
        Me.pnMainButton.ResumeLayout(False)
        Me.TabPageAlignment.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.numWorkStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAcceptScoreAlign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageLaserParam.ResumeLayout(False)
        Me.grbGalvoParameter.ResumeLayout(False)
        Me.grbGalvoParameter.PerformLayout()
        Me.grbGraphicParameter.ResumeLayout(False)
        CType(Me.numImageOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numImageOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TabPageCorrection.ResumeLayout(False)
        Me.TabControl2.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPageCorrectionValue.ResumeLayout(False)
        CType(Me.dgvCorrection, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageCalibration.ResumeLayout(False)
        Me.TabPageCalibration.PerformLayout()
        CType(Me.dgvGalvoValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvImageValue, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageIOStatus.ResumeLayout(False)
        Me.TabPageIOStatus.PerformLayout()
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.ptbOut15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbIn0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptbOut0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageAxis.ResumeLayout(False)
        Me.TabPageAxis.PerformLayout()
        Me.TabPageScale.ResumeLayout(False)
        Me.TabPageScale.PerformLayout()
        Me.GroupBox15.ResumeLayout(False)
        Me.GroupBox15.PerformLayout()
        CType(Me.numCalScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLengthScalePX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numLengthScaleMM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPagePos.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox16.ResumeLayout(False)
        Me.GroupBox16.PerformLayout()
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox13.PerformLayout()
        Me.TableLayoutPanel17.ResumeLayout(False)
        Me.GroupBox18.ResumeLayout(False)
        Me.GroupBox18.PerformLayout()
        Me.TableLayoutPanel11.ResumeLayout(False)
        Me.GroupBox17.ResumeLayout(False)
        Me.GroupBox17.PerformLayout()
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        Me.TableLayoutPanel14.ResumeLayout(False)
        Me.GroupBox11.ResumeLayout(False)
        Me.TableLayoutPanel10.ResumeLayout(False)
        Me.groupWorkholderX.ResumeLayout(False)
        Me.groupWorkholderX.PerformLayout()
        Me.TableLayoutPanel5.ResumeLayout(False)
        CType(Me.numMovingDistance0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.numWorkhodlerX3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.numWorkhodlerX1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWorkhodlerX2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TableLayoutPanel13.ResumeLayout(False)
        CType(Me.numWorkhodlerX0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStripPassword.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    'Friend WithEvents ImageDisplay1 As VisionSystem.ImageDisplay
    Friend WithEvents ContextMenuStripMoveLine As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusX As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblStatusY As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblFilePath As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents tblEditTable As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnAddLine As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnDrawSelecting As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents btnPickColor As System.Windows.Forms.Button
    Friend WithEvents btnMainGuideOFF As System.Windows.Forms.Button
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnNewProject As System.Windows.Forms.Button
    Friend WithEvents btnOpenProject As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnGuideON As System.Windows.Forms.Button
    Friend WithEvents btnGuideOFF As System.Windows.Forms.Button
    Friend WithEvents btnCorrection As System.Windows.Forms.Button
    Friend WithEvents Timer_GetLaserExecuteFinish As System.Windows.Forms.Timer
    Friend WithEvents btnGlavoHome As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCorrection As System.Windows.Forms.TabPage
    Friend WithEvents PropertyGrid2 As System.Windows.Forms.PropertyGrid
    Friend WithEvents btnStopCorrection As System.Windows.Forms.Button
    Friend WithEvents TabControl2 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCorrectionValue As System.Windows.Forms.TabPage
    Friend WithEvents dgvCorrection As System.Windows.Forms.DataGridView
    Friend WithEvents btnSaveCorrectionValue As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnEmissionOff As System.Windows.Forms.Button
    Friend WithEvents btnEmissionOn As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TabPageLaserParam As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numPRR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numPower As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lbLog As System.Windows.Forms.ListBox
    Friend WithEvents TabPageAlignment As System.Windows.Forms.TabPage
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents grbGraphicParameter As System.Windows.Forms.GroupBox
    Friend WithEvents btnReloadCorectionFile As System.Windows.Forms.Button
    Friend WithEvents btnSaveParameter As System.Windows.Forms.Button
    Friend WithEvents TabPageLog As System.Windows.Forms.TabPage
    Friend WithEvents TabPagePassword As System.Windows.Forms.TabPage
    Friend WithEvents chkTest As LaserCutting.CheckBoxEx
    Friend WithEvents ContextMenuStripPassword As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoginToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblLaserPower As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents grbGalvoParameter As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents numGalvoOffsetY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numGalvoOffsetX As System.Windows.Forms.NumericUpDown
    Friend WithEvents numGalvoAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents lblLaserPRR As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel5 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numAcceptScoreAlign As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnAlignSetStart As System.Windows.Forms.Button
    Friend WithEvents btnAlignTest As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numWorkStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents TabPageIOStatus As System.Windows.Forms.TabPage
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents ptbOut15 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn15 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn14 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn13 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn12 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn11 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn10 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn9 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn8 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn7 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn6 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn5 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn4 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn3 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn2 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn1 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbIn0 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut14 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut13 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut12 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut11 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut10 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut9 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut8 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut7 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut6 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut5 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut4 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut3 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut2 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut1 As LaserCutting.PictureBoxEx
    Friend WithEvents ptbOut0 As LaserCutting.PictureBoxEx
    Friend WithEvents TimerGetRTC4IO As System.Windows.Forms.Timer
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents numDIDelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents numDODelay As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnMarkLine As System.Windows.Forms.Button
    Friend WithEvents TabPageAxis As System.Windows.Forms.TabPage
    Friend WithEvents TabPageCalibration As System.Windows.Forms.TabPage
    Friend WithEvents dgvGalvoValue As System.Windows.Forms.DataGridView
    Friend WithEvents dgvImageValue As System.Windows.Forms.DataGridView
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents btnSaveCalibration As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents cboCalibrationRange As System.Windows.Forms.ComboBox
    Friend WithEvents ToolStripStatusLabel4 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblXPx As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ToolStripStatusLabel7 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents lblYPx As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents TabPagePos As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox14 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel7 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder8 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder9 As System.Windows.Forms.Button
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel6 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder4 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel17 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder2 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel14 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder6 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder7 As System.Windows.Forms.Button
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel10 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder0 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder1 As System.Windows.Forms.Button
    Friend WithEvents btnSavePos As System.Windows.Forms.Button
    Friend WithEvents groupWorkholderX As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel5 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents numMovingDistance0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnWorkholderTestMove0 As System.Windows.Forms.Button
    Friend WithEvents btnWorkholderTestMove1 As System.Windows.Forms.Button
    Friend WithEvents lblWorkholderXNow As System.Windows.Forms.Label
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents numWorkhodlerX3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnWorkholderMove3 As System.Windows.Forms.Button
    Friend WithEvents btnWorkholderSet3 As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents numWorkhodlerX1 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnWorkholderMove1 As System.Windows.Forms.Button
    Friend WithEvents btnWorkholderSet1 As System.Windows.Forms.Button
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents numWorkhodlerX2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnWorkholderMove2 As System.Windows.Forms.Button
    Friend WithEvents btnWorkholderSet2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel13 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents numWorkhodlerX0 As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnWorkholderMove0 As System.Windows.Forms.Button
    Friend WithEvents btnWorkholderSet0 As System.Windows.Forms.Button
    Friend WithEvents btnOpenInputForm As System.Windows.Forms.Button
    Friend WithEvents btnBuildCorrectionFile As System.Windows.Forms.Button
    Friend WithEvents TabPageScale As System.Windows.Forms.TabPage
    Friend WithEvents numLengthScaleMM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents btnMarkLineScale As System.Windows.Forms.Button
    Friend WithEvents numLengthScalePX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents btnCalScale As System.Windows.Forms.Button
    Friend WithEvents numCalScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents btnSaveScale As System.Windows.Forms.Button
    Friend WithEvents chkScaleUseLaser As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox15 As System.Windows.Forms.GroupBox
    Friend WithEvents numScaleLaserPRR As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents numScaleLaserPower As System.Windows.Forms.NumericUpDown

    Friend WithEvents UpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DownToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloneToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnHome As System.Windows.Forms.Button
    Friend WithEvents GroupBox16 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel8 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder10 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder11 As System.Windows.Forms.Button
    Friend WithEvents lnkLanguage As System.Windows.Forms.LinkLabel
    Friend WithEvents GroupBox17 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel9 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder12 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder13 As System.Windows.Forms.Button
    Friend WithEvents GroupBox18 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel11 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnCylinder14 As System.Windows.Forms.Button
    Friend WithEvents btnCylinder15 As System.Windows.Forms.Button
    Friend WithEvents CopyLaserParameterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PasteLaserParameterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents numImageOffsetY As System.Windows.Forms.NumericUpDown
    Friend WithEvents numImageOffsetX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents numPX2MM As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnMarkAxis As System.Windows.Forms.Button
    Friend WithEvents cboChoosePointForEdit As System.Windows.Forms.ComboBox
    Friend WithEvents TableLayoutPanel12 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMoveUp As LaserCutting.ButtonEx
    Friend WithEvents btnMoveLeft As LaserCutting.ButtonEx
    Friend WithEvents btnMoveDown As LaserCutting.ButtonEx
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numMoveDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnRotateCW As System.Windows.Forms.Button
    Friend WithEvents btnRotateCCW As System.Windows.Forms.Button
    Friend WithEvents numRotateAngle As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label63 As System.Windows.Forms.Label
    Friend WithEvents grbCamera As System.Windows.Forms.Panel
    Friend WithEvents pnMainButton As System.Windows.Forms.Panel
    Friend WithEvents pnEdit As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel15 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnMoveRight As LaserCutting.ButtonEx
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnKeyCorrectionGalvo As System.Windows.Forms.Button
    Friend WithEvents btnKeyImageCalibration As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents chkUseScale As LaserCutting.CheckBoxEx
    Friend WithEvents GroupBoxEx1 As LaserCutting.GroupBoxEx
    Friend WithEvents GroupBoxEx2 As LaserCutting.GroupBoxEx
    Friend WithEvents cboFixPoint As System.Windows.Forms.ComboBox
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents numFixDistance As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
End Class
