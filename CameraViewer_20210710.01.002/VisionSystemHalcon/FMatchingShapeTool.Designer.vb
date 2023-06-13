<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMatchingShapeTool
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.numNumLevels = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.numAngleStart = New System.Windows.Forms.NumericUpDown
        Me.numAngleEnd = New System.Windows.Forms.NumericUpDown
        Me.numAngleStep = New System.Windows.Forms.NumericUpDown
        Me.numScaleMin = New System.Windows.Forms.NumericUpDown
        Me.numScaleMax = New System.Windows.Forms.NumericUpDown
        Me.numScaleStep = New System.Windows.Forms.NumericUpDown
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.cmbTemplate1 = New System.Windows.Forms.ComboBox
        Me.cmbMetric = New System.Windows.Forms.ComboBox
        Me.numContrastLow = New System.Windows.Forms.NumericUpDown
        Me.numContrastHigh = New System.Windows.Forms.NumericUpDown
        Me.numMinSize = New System.Windows.Forms.NumericUpDown
        Me.numMinContrast = New System.Windows.Forms.NumericUpDown
        Me.btnTrainAuto = New System.Windows.Forms.Button
        Me.btnTrainManul = New System.Windows.Forms.Button
        Me.btnFindResult = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel
        Me.numAngleStartRun = New System.Windows.Forms.NumericUpDown
        Me.numAngleEndRun = New System.Windows.Forms.NumericUpDown
        Me.numScaleMinRun = New System.Windows.Forms.NumericUpDown
        Me.numScaleMaxRun = New System.Windows.Forms.NumericUpDown
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label29 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.numScoreSearch = New System.Windows.Forms.NumericUpDown
        Me.numScoreAccept = New System.Windows.Forms.NumericUpDown
        Me.numOverlapPercent = New System.Windows.Forms.NumericUpDown
        Me.cmbSubPixel = New System.Windows.Forms.ComboBox
        Me.cmbAlgorithmSpeed = New System.Windows.Forms.ComboBox
        Me.tviewResult = New System.Windows.Forms.TreeView
        Me.DisplayTemplate = New VisionSystem.ImageDisplay
        Me.DisplaySrcImg = New VisionSystem.ImageDisplay
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.numNumLevels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAngleStart, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAngleEnd, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAngleStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleStep, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numContrastLow, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numContrastHigh, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numMinContrast, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        CType(Me.numAngleStartRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAngleEndRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleMinRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScaleMaxRun, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScoreSearch, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numScoreAccept, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOverlapPercent, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.AutoScroll = True
        Me.TableLayoutPanel1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.numNumLevels, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.numAngleStart, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.numAngleEnd, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.numAngleStep, 1, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.numScaleMin, 1, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.numScaleMax, 1, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.numScaleStep, 1, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label3, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Label4, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.Label9, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.Label10, 0, 5)
        Me.TableLayoutPanel1.Controls.Add(Me.Label11, 0, 6)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 0, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.Label7, 0, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.Label15, 0, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 0, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.Label16, 0, 12)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbTemplate1, 1, 7)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbMetric, 1, 8)
        Me.TableLayoutPanel1.Controls.Add(Me.numContrastLow, 1, 9)
        Me.TableLayoutPanel1.Controls.Add(Me.numContrastHigh, 1, 10)
        Me.TableLayoutPanel1.Controls.Add(Me.numMinSize, 1, 11)
        Me.TableLayoutPanel1.Controls.Add(Me.numMinContrast, 1, 12)
        Me.TableLayoutPanel1.ForeColor = System.Drawing.Color.White
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(3, 15)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 13
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(251, 368)
        Me.TableLayoutPanel1.TabIndex = 7
        '
        'numNumLevels
        '
        Me.numNumLevels.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numNumLevels.Enabled = False
        Me.numNumLevels.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numNumLevels.ForeColor = System.Drawing.Color.White
        Me.numNumLevels.Location = New System.Drawing.Point(129, 3)
        Me.numNumLevels.Margin = New System.Windows.Forms.Padding(1)
        Me.numNumLevels.Name = "numNumLevels"
        Me.numNumLevels.Size = New System.Drawing.Size(88, 25)
        Me.numNumLevels.TabIndex = 1
        Me.numNumLevels.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 3)
        Me.Label1.Margin = New System.Windows.Forms.Padding(1)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(122, 27)
        Me.Label1.TabIndex = 0
        Me.Label1.Tag = "numLevels"
        Me.Label1.Text = "影像金字塔階層"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numAngleStart
        '
        Me.numAngleStart.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAngleStart.Enabled = False
        Me.numAngleStart.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAngleStart.ForeColor = System.Drawing.Color.White
        Me.numAngleStart.Location = New System.Drawing.Point(129, 34)
        Me.numAngleStart.Margin = New System.Windows.Forms.Padding(1)
        Me.numAngleStart.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numAngleStart.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.numAngleStart.Name = "numAngleStart"
        Me.numAngleStart.Size = New System.Drawing.Size(88, 25)
        Me.numAngleStart.TabIndex = 1
        Me.numAngleStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numAngleEnd
        '
        Me.numAngleEnd.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAngleEnd.Enabled = False
        Me.numAngleEnd.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAngleEnd.ForeColor = System.Drawing.Color.White
        Me.numAngleEnd.Location = New System.Drawing.Point(129, 65)
        Me.numAngleEnd.Margin = New System.Windows.Forms.Padding(1)
        Me.numAngleEnd.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numAngleEnd.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.numAngleEnd.Name = "numAngleEnd"
        Me.numAngleEnd.Size = New System.Drawing.Size(88, 25)
        Me.numAngleEnd.TabIndex = 1
        Me.numAngleEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numAngleStep
        '
        Me.numAngleStep.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAngleStep.DecimalPlaces = 5
        Me.numAngleStep.Enabled = False
        Me.numAngleStep.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAngleStep.ForeColor = System.Drawing.Color.White
        Me.numAngleStep.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numAngleStep.Location = New System.Drawing.Point(129, 96)
        Me.numAngleStep.Margin = New System.Windows.Forms.Padding(1)
        Me.numAngleStep.Name = "numAngleStep"
        Me.numAngleStep.Size = New System.Drawing.Size(88, 25)
        Me.numAngleStep.TabIndex = 1
        Me.numAngleStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScaleMin
        '
        Me.numScaleMin.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScaleMin.DecimalPlaces = 2
        Me.numScaleMin.Enabled = False
        Me.numScaleMin.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScaleMin.ForeColor = System.Drawing.Color.White
        Me.numScaleMin.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScaleMin.Location = New System.Drawing.Point(129, 127)
        Me.numScaleMin.Margin = New System.Windows.Forms.Padding(1)
        Me.numScaleMin.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numScaleMin.Name = "numScaleMin"
        Me.numScaleMin.Size = New System.Drawing.Size(88, 25)
        Me.numScaleMin.TabIndex = 1
        Me.numScaleMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScaleMax
        '
        Me.numScaleMax.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScaleMax.DecimalPlaces = 2
        Me.numScaleMax.Enabled = False
        Me.numScaleMax.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScaleMax.ForeColor = System.Drawing.Color.White
        Me.numScaleMax.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScaleMax.Location = New System.Drawing.Point(129, 158)
        Me.numScaleMax.Margin = New System.Windows.Forms.Padding(1)
        Me.numScaleMax.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numScaleMax.Name = "numScaleMax"
        Me.numScaleMax.Size = New System.Drawing.Size(88, 25)
        Me.numScaleMax.TabIndex = 1
        Me.numScaleMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScaleStep
        '
        Me.numScaleStep.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScaleStep.DecimalPlaces = 5
        Me.numScaleStep.Enabled = False
        Me.numScaleStep.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScaleStep.ForeColor = System.Drawing.Color.White
        Me.numScaleStep.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numScaleStep.Location = New System.Drawing.Point(129, 189)
        Me.numScaleStep.Margin = New System.Windows.Forms.Padding(1)
        Me.numScaleStep.Name = "numScaleStep"
        Me.numScaleStep.Size = New System.Drawing.Size(88, 25)
        Me.numScaleStep.TabIndex = 1
        Me.numScaleStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label2.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(3, 34)
        Me.Label2.Margin = New System.Windows.Forms.Padding(1)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 27)
        Me.Label2.TabIndex = 0
        Me.Label2.Tag = "angleStart"
        Me.Label2.Text = "起始角度"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label3.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 65)
        Me.Label3.Margin = New System.Windows.Forms.Padding(1)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 27)
        Me.Label3.TabIndex = 0
        Me.Label3.Tag = "angleExtent+angleStart"
        Me.Label3.Text = "結束角度"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label4.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(3, 96)
        Me.Label4.Margin = New System.Windows.Forms.Padding(1)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(122, 27)
        Me.Label4.TabIndex = 0
        Me.Label4.Tag = "angleStep"
        Me.Label4.Text = "角度間隔"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label9.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(3, 127)
        Me.Label9.Margin = New System.Windows.Forms.Padding(1)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(122, 27)
        Me.Label9.TabIndex = 0
        Me.Label9.Tag = "scaleRMin"
        Me.Label9.Text = "比例最小值"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label10.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(3, 158)
        Me.Label10.Margin = New System.Windows.Forms.Padding(1)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(122, 27)
        Me.Label10.TabIndex = 0
        Me.Label10.Tag = "scaleRMax"
        Me.Label10.Text = "比例最大值"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label11.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(3, 189)
        Me.Label11.Margin = New System.Windows.Forms.Padding(1)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(122, 27)
        Me.Label11.TabIndex = 0
        Me.Label11.Tag = "scaleRStep"
        Me.Label11.Text = "比例間隔"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label5.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(3, 220)
        Me.Label5.Margin = New System.Windows.Forms.Padding(1)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(122, 27)
        Me.Label5.TabIndex = 0
        Me.Label5.Tag = "optimization"
        Me.Label5.Text = "圖像優化"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label6.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(3, 251)
        Me.Label6.Margin = New System.Windows.Forms.Padding(1)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 27)
        Me.Label6.TabIndex = 0
        Me.Label6.Tag = "metric"
        Me.Label6.Text = "背景變化"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label7.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(3, 282)
        Me.Label7.Margin = New System.Windows.Forms.Padding(1)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(122, 27)
        Me.Label7.TabIndex = 0
        Me.Label7.Tag = "contrast"
        Me.Label7.Text = "邊緣偵測灰階值(低)"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label15.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(3, 313)
        Me.Label15.Margin = New System.Windows.Forms.Padding(1)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(122, 27)
        Me.Label15.TabIndex = 0
        Me.Label15.Tag = "contrast"
        Me.Label15.Text = "邊緣偵測灰階值(高)"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label8.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(3, 344)
        Me.Label8.Margin = New System.Windows.Forms.Padding(1)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(122, 27)
        Me.Label8.TabIndex = 0
        Me.Label8.Tag = "minContrast"
        Me.Label8.Text = "最短長度"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label16.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(3, 375)
        Me.Label16.Margin = New System.Windows.Forms.Padding(1)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(122, 22)
        Me.Label16.TabIndex = 0
        Me.Label16.Tag = "minContrast"
        Me.Label16.Text = "雜訊抑制灰階值"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTemplate1
        '
        Me.cmbTemplate1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbTemplate1.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbTemplate1.ForeColor = System.Drawing.Color.White
        Me.cmbTemplate1.FormattingEnabled = True
        Me.cmbTemplate1.Location = New System.Drawing.Point(129, 220)
        Me.cmbTemplate1.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbTemplate1.Name = "cmbTemplate1"
        Me.cmbTemplate1.Size = New System.Drawing.Size(88, 25)
        Me.cmbTemplate1.TabIndex = 2
        Me.cmbTemplate1.Text = "不優化"
        '
        'cmbMetric
        '
        Me.cmbMetric.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbMetric.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbMetric.ForeColor = System.Drawing.Color.White
        Me.cmbMetric.FormattingEnabled = True
        Me.cmbMetric.Location = New System.Drawing.Point(129, 251)
        Me.cmbMetric.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbMetric.Name = "cmbMetric"
        Me.cmbMetric.Size = New System.Drawing.Size(88, 25)
        Me.cmbMetric.TabIndex = 2
        Me.cmbMetric.Text = "無變化"
        '
        'numContrastLow
        '
        Me.numContrastLow.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numContrastLow.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numContrastLow.ForeColor = System.Drawing.Color.White
        Me.numContrastLow.Location = New System.Drawing.Point(129, 282)
        Me.numContrastLow.Margin = New System.Windows.Forms.Padding(1)
        Me.numContrastLow.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numContrastLow.Name = "numContrastLow"
        Me.numContrastLow.Size = New System.Drawing.Size(88, 25)
        Me.numContrastLow.TabIndex = 1
        Me.numContrastLow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numContrastHigh
        '
        Me.numContrastHigh.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numContrastHigh.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numContrastHigh.ForeColor = System.Drawing.Color.White
        Me.numContrastHigh.Location = New System.Drawing.Point(129, 313)
        Me.numContrastHigh.Margin = New System.Windows.Forms.Padding(1)
        Me.numContrastHigh.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numContrastHigh.Name = "numContrastHigh"
        Me.numContrastHigh.Size = New System.Drawing.Size(88, 25)
        Me.numContrastHigh.TabIndex = 1
        Me.numContrastHigh.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numMinSize
        '
        Me.numMinSize.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numMinSize.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numMinSize.ForeColor = System.Drawing.Color.White
        Me.numMinSize.Location = New System.Drawing.Point(129, 344)
        Me.numMinSize.Margin = New System.Windows.Forms.Padding(1)
        Me.numMinSize.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numMinSize.Name = "numMinSize"
        Me.numMinSize.Size = New System.Drawing.Size(88, 25)
        Me.numMinSize.TabIndex = 1
        Me.numMinSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numMinContrast
        '
        Me.numMinContrast.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numMinContrast.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numMinContrast.ForeColor = System.Drawing.Color.White
        Me.numMinContrast.Location = New System.Drawing.Point(129, 375)
        Me.numMinContrast.Margin = New System.Windows.Forms.Padding(1)
        Me.numMinContrast.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numMinContrast.Name = "numMinContrast"
        Me.numMinContrast.Size = New System.Drawing.Size(88, 25)
        Me.numMinContrast.TabIndex = 1
        Me.numMinContrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnTrainAuto
        '
        Me.btnTrainAuto.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnTrainAuto.ForeColor = System.Drawing.Color.White
        Me.btnTrainAuto.Location = New System.Drawing.Point(880, 569)
        Me.btnTrainAuto.Name = "btnTrainAuto"
        Me.btnTrainAuto.Size = New System.Drawing.Size(115, 49)
        Me.btnTrainAuto.TabIndex = 12
        Me.btnTrainAuto.Text = "恢復預設值"
        Me.btnTrainAuto.UseVisualStyleBackColor = False
        '
        'btnTrainManul
        '
        Me.btnTrainManul.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnTrainManul.ForeColor = System.Drawing.Color.White
        Me.btnTrainManul.Location = New System.Drawing.Point(880, 624)
        Me.btnTrainManul.Name = "btnTrainManul"
        Me.btnTrainManul.Size = New System.Drawing.Size(115, 49)
        Me.btnTrainManul.TabIndex = 12
        Me.btnTrainManul.Text = "手動設定樣板"
        Me.btnTrainManul.UseVisualStyleBackColor = False
        '
        'btnFindResult
        '
        Me.btnFindResult.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnFindResult.ForeColor = System.Drawing.Color.White
        Me.btnFindResult.Location = New System.Drawing.Point(880, 679)
        Me.btnFindResult.Name = "btnFindResult"
        Me.btnFindResult.Size = New System.Drawing.Size(115, 49)
        Me.btnFindResult.TabIndex = 12
        Me.btnFindResult.Text = "找尋物件"
        Me.btnFindResult.UseVisualStyleBackColor = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(1001, 9)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(260, 389)
        Me.GroupBox3.TabIndex = 13
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "樣板參數"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox4.ForeColor = System.Drawing.Color.White
        Me.GroupBox4.Location = New System.Drawing.Point(1001, 404)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(260, 317)
        Me.GroupBox4.TabIndex = 14
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "執行參數"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.AutoScroll = True
        Me.TableLayoutPanel4.BackColor = System.Drawing.Color.DarkSlateGray
        Me.TableLayoutPanel4.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel4.ColumnCount = 2
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel4.Controls.Add(Me.numAngleStartRun, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.numAngleEndRun, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.numScaleMinRun, 1, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.numScaleMaxRun, 1, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label18, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label19, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label21, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.Label22, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.Label27, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.Label17, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.Label28, 0, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.Label29, 0, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.Label20, 0, 8)
        Me.TableLayoutPanel4.Controls.Add(Me.numScoreSearch, 1, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.numScoreAccept, 1, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.numOverlapPercent, 1, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbSubPixel, 1, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbAlgorithmSpeed, 1, 8)
        Me.TableLayoutPanel4.ForeColor = System.Drawing.Color.White
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(5, 15)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 9
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(249, 292)
        Me.TableLayoutPanel4.TabIndex = 7
        '
        'numAngleStartRun
        '
        Me.numAngleStartRun.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAngleStartRun.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAngleStartRun.ForeColor = System.Drawing.Color.White
        Me.numAngleStartRun.Location = New System.Drawing.Point(129, 3)
        Me.numAngleStartRun.Margin = New System.Windows.Forms.Padding(1)
        Me.numAngleStartRun.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numAngleStartRun.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.numAngleStartRun.Name = "numAngleStartRun"
        Me.numAngleStartRun.Size = New System.Drawing.Size(88, 25)
        Me.numAngleStartRun.TabIndex = 1
        Me.numAngleStartRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numAngleEndRun
        '
        Me.numAngleEndRun.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAngleEndRun.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAngleEndRun.ForeColor = System.Drawing.Color.White
        Me.numAngleEndRun.Location = New System.Drawing.Point(129, 32)
        Me.numAngleEndRun.Margin = New System.Windows.Forms.Padding(1)
        Me.numAngleEndRun.Maximum = New Decimal(New Integer() {180, 0, 0, 0})
        Me.numAngleEndRun.Minimum = New Decimal(New Integer() {180, 0, 0, -2147483648})
        Me.numAngleEndRun.Name = "numAngleEndRun"
        Me.numAngleEndRun.Size = New System.Drawing.Size(88, 25)
        Me.numAngleEndRun.TabIndex = 1
        Me.numAngleEndRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScaleMinRun
        '
        Me.numScaleMinRun.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScaleMinRun.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScaleMinRun.ForeColor = System.Drawing.Color.White
        Me.numScaleMinRun.Location = New System.Drawing.Point(129, 61)
        Me.numScaleMinRun.Margin = New System.Windows.Forms.Padding(1)
        Me.numScaleMinRun.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numScaleMinRun.Name = "numScaleMinRun"
        Me.numScaleMinRun.Size = New System.Drawing.Size(88, 25)
        Me.numScaleMinRun.TabIndex = 1
        Me.numScaleMinRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScaleMaxRun
        '
        Me.numScaleMaxRun.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScaleMaxRun.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScaleMaxRun.ForeColor = System.Drawing.Color.White
        Me.numScaleMaxRun.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numScaleMaxRun.Location = New System.Drawing.Point(129, 90)
        Me.numScaleMaxRun.Margin = New System.Windows.Forms.Padding(1)
        Me.numScaleMaxRun.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
        Me.numScaleMaxRun.Name = "numScaleMaxRun"
        Me.numScaleMaxRun.Size = New System.Drawing.Size(88, 25)
        Me.numScaleMaxRun.TabIndex = 1
        Me.numScaleMaxRun.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label18.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(3, 3)
        Me.Label18.Margin = New System.Windows.Forms.Padding(1)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(122, 22)
        Me.Label18.TabIndex = 0
        Me.Label18.Tag = "angleStart"
        Me.Label18.Text = "起始角度"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label19.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(3, 32)
        Me.Label19.Margin = New System.Windows.Forms.Padding(1)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(122, 22)
        Me.Label19.TabIndex = 0
        Me.Label19.Tag = "angleExtent+angleStart"
        Me.Label19.Text = "結束角度"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label21
        '
        Me.Label21.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label21.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label21.ForeColor = System.Drawing.Color.White
        Me.Label21.Location = New System.Drawing.Point(3, 61)
        Me.Label21.Margin = New System.Windows.Forms.Padding(1)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(122, 22)
        Me.Label21.TabIndex = 0
        Me.Label21.Tag = "scaleRMin"
        Me.Label21.Text = "比例最小值"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label22.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label22.ForeColor = System.Drawing.Color.White
        Me.Label22.Location = New System.Drawing.Point(3, 90)
        Me.Label22.Margin = New System.Windows.Forms.Padding(1)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 22)
        Me.Label22.TabIndex = 0
        Me.Label22.Tag = "scaleRMax"
        Me.Label22.Text = "比例最大值"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label27
        '
        Me.Label27.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label27.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.White
        Me.Label27.Location = New System.Drawing.Point(3, 119)
        Me.Label27.Margin = New System.Windows.Forms.Padding(1)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(122, 22)
        Me.Label27.TabIndex = 0
        Me.Label27.Tag = "optimization"
        Me.Label27.Text = "找尋分數"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label17.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(3, 148)
        Me.Label17.Margin = New System.Windows.Forms.Padding(1)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(122, 22)
        Me.Label17.TabIndex = 0
        Me.Label17.Tag = "optimization"
        Me.Label17.Text = "合格分數"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label28.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.ForeColor = System.Drawing.Color.White
        Me.Label28.Location = New System.Drawing.Point(3, 177)
        Me.Label28.Margin = New System.Windows.Forms.Padding(1)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(122, 22)
        Me.Label28.TabIndex = 0
        Me.Label28.Tag = "metric"
        Me.Label28.Text = "重疊比例"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label29
        '
        Me.Label29.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label29.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label29.ForeColor = System.Drawing.Color.White
        Me.Label29.Location = New System.Drawing.Point(3, 206)
        Me.Label29.Margin = New System.Windows.Forms.Padding(1)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(122, 22)
        Me.Label29.TabIndex = 0
        Me.Label29.Tag = "contrast"
        Me.Label29.Text = "像素精度"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label20
        '
        Me.Label20.BackColor = System.Drawing.Color.DarkSlateGray
        Me.Label20.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.ForeColor = System.Drawing.Color.White
        Me.Label20.Location = New System.Drawing.Point(3, 235)
        Me.Label20.Margin = New System.Windows.Forms.Padding(1)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(122, 22)
        Me.Label20.TabIndex = 0
        Me.Label20.Tag = "contrast"
        Me.Label20.Text = "演算法速度"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numScoreSearch
        '
        Me.numScoreSearch.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScoreSearch.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScoreSearch.ForeColor = System.Drawing.Color.White
        Me.numScoreSearch.Increment = New Decimal(New Integer() {1, 0, 0, 393216})
        Me.numScoreSearch.Location = New System.Drawing.Point(129, 119)
        Me.numScoreSearch.Margin = New System.Windows.Forms.Padding(1)
        Me.numScoreSearch.Name = "numScoreSearch"
        Me.numScoreSearch.Size = New System.Drawing.Size(88, 25)
        Me.numScoreSearch.TabIndex = 1
        Me.numScoreSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numScoreAccept
        '
        Me.numScoreAccept.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numScoreAccept.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numScoreAccept.ForeColor = System.Drawing.Color.White
        Me.numScoreAccept.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numScoreAccept.Location = New System.Drawing.Point(129, 148)
        Me.numScoreAccept.Margin = New System.Windows.Forms.Padding(1)
        Me.numScoreAccept.Name = "numScoreAccept"
        Me.numScoreAccept.Size = New System.Drawing.Size(88, 25)
        Me.numScoreAccept.TabIndex = 1
        Me.numScoreAccept.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numOverlapPercent
        '
        Me.numOverlapPercent.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numOverlapPercent.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numOverlapPercent.ForeColor = System.Drawing.Color.White
        Me.numOverlapPercent.Increment = New Decimal(New Integer() {1, 0, 0, 131072})
        Me.numOverlapPercent.Location = New System.Drawing.Point(129, 177)
        Me.numOverlapPercent.Margin = New System.Windows.Forms.Padding(1)
        Me.numOverlapPercent.Name = "numOverlapPercent"
        Me.numOverlapPercent.Size = New System.Drawing.Size(88, 25)
        Me.numOverlapPercent.TabIndex = 1
        Me.numOverlapPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmbSubPixel
        '
        Me.cmbSubPixel.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbSubPixel.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbSubPixel.ForeColor = System.Drawing.Color.White
        Me.cmbSubPixel.FormattingEnabled = True
        Me.cmbSubPixel.Location = New System.Drawing.Point(129, 206)
        Me.cmbSubPixel.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbSubPixel.Name = "cmbSubPixel"
        Me.cmbSubPixel.Size = New System.Drawing.Size(88, 25)
        Me.cmbSubPixel.TabIndex = 2
        Me.cmbSubPixel.Text = "不優化"
        '
        'cmbAlgorithmSpeed
        '
        Me.cmbAlgorithmSpeed.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbAlgorithmSpeed.Font = New System.Drawing.Font("微軟正黑體", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cmbAlgorithmSpeed.ForeColor = System.Drawing.Color.White
        Me.cmbAlgorithmSpeed.FormattingEnabled = True
        Me.cmbAlgorithmSpeed.Location = New System.Drawing.Point(129, 235)
        Me.cmbAlgorithmSpeed.Margin = New System.Windows.Forms.Padding(1)
        Me.cmbAlgorithmSpeed.Name = "cmbAlgorithmSpeed"
        Me.cmbAlgorithmSpeed.Size = New System.Drawing.Size(88, 25)
        Me.cmbAlgorithmSpeed.TabIndex = 2
        Me.cmbAlgorithmSpeed.Text = "無變化"
        '
        'tviewResult
        '
        Me.tviewResult.BackColor = System.Drawing.Color.DarkSlateGray
        Me.tviewResult.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tviewResult.ForeColor = System.Drawing.Color.White
        Me.tviewResult.Location = New System.Drawing.Point(708, 218)
        Me.tviewResult.Name = "tviewResult"
        Me.tviewResult.Size = New System.Drawing.Size(285, 264)
        Me.tviewResult.TabIndex = 15
        '
        'DisplayTemplate
        '
        Me.DisplayTemplate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DisplayTemplate.BackColor = System.Drawing.Color.Maroon
        Me.DisplayTemplate.Location = New System.Drawing.Point(708, 9)
        Me.DisplayTemplate.Margin = New System.Windows.Forms.Padding(0)
        Me.DisplayTemplate.Name = "DisplayTemplate"
        Me.DisplayTemplate.Size = New System.Drawing.Size(290, 206)
        Me.DisplayTemplate.TabIndex = 11
        '
        'DisplaySrcImg
        '
        Me.DisplaySrcImg.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.DisplaySrcImg.BackColor = System.Drawing.Color.Maroon
        Me.DisplaySrcImg.Location = New System.Drawing.Point(3, 9)
        Me.DisplaySrcImg.Margin = New System.Windows.Forms.Padding(0)
        Me.DisplaySrcImg.Name = "DisplaySrcImg"
        Me.DisplaySrcImg.Size = New System.Drawing.Size(704, 540)
        Me.DisplaySrcImg.TabIndex = 0
        '
        'FMatchingShapeTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(1264, 730)
        Me.Controls.Add(Me.tviewResult)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.btnFindResult)
        Me.Controls.Add(Me.btnTrainManul)
        Me.Controls.Add(Me.btnTrainAuto)
        Me.Controls.Add(Me.DisplayTemplate)
        Me.Controls.Add(Me.DisplaySrcImg)
        Me.Name = "FMatchingShapeTool"
        Me.Text = "樣板比對編輯器"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.numNumLevels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAngleStart, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAngleEnd, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAngleStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleStep, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numContrastLow, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numContrastHigh, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numMinContrast, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        CType(Me.numAngleStartRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAngleEndRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleMinRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScaleMaxRun, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScoreSearch, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numScoreAccept, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOverlapPercent, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DisplaySrcImg As VisionSystem.ImageDisplay
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents numNumLevels As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numAngleStart As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAngleEnd As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAngleStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleStep As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbTemplate1 As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMetric As System.Windows.Forms.ComboBox
    Friend WithEvents numContrastLow As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numMinSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents numContrastHigh As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents numMinContrast As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents DisplayTemplate As VisionSystem.ImageDisplay
    Friend WithEvents btnTrainAuto As System.Windows.Forms.Button
    Friend WithEvents btnTrainManul As System.Windows.Forms.Button
    Friend WithEvents btnFindResult As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents numAngleStartRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents numAngleEndRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleMinRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScaleMaxRun As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScoreSearch As System.Windows.Forms.NumericUpDown
    Friend WithEvents numScoreAccept As System.Windows.Forms.NumericUpDown
    Friend WithEvents numOverlapPercent As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmbSubPixel As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAlgorithmSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents tviewResult As System.Windows.Forms.TreeView
End Class
