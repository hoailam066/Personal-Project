<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLog))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.dgvView = New System.Windows.Forms.DataGridView()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.dtpkFromDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpkToDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.chkOpenClose = New LaserCutting.CheckBoxEx()
        Me.chkStartStop = New LaserCutting.CheckBoxEx()
        Me.chkError = New LaserCutting.CheckBoxEx()
        Me.chkEdit = New LaserCutting.CheckBoxEx()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnFilter = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.chkUseFilter = New LaserCutting.CheckBoxEx()
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvView
        '
        resources.ApplyResources(Me.dgvView, "dgvView")
        Me.dgvView.AllowUserToAddRows = False
        Me.dgvView.AllowUserToDeleteRows = False
        Me.dgvView.AllowUserToResizeColumns = False
        Me.dgvView.AllowUserToResizeRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightCyan
        Me.dgvView.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvView.BackgroundColor = System.Drawing.Color.Silver
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightCyan
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvView.Name = "dgvView"
        Me.dgvView.ReadOnly = True
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvView.RowHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvView.RowHeadersVisible = False
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvView.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        resources.ApplyResources(Me.OpenFileDialog1, "OpenFileDialog1")
        '
        'dtpkFromDate
        '
        resources.ApplyResources(Me.dtpkFromDate, "dtpkFromDate")
        Me.dtpkFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpkFromDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.dtpkFromDate.Name = "dtpkFromDate"
        '
        'dtpkToDate
        '
        resources.ApplyResources(Me.dtpkToDate, "dtpkToDate")
        Me.dtpkToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpkToDate.MinDate = New Date(2020, 1, 1, 0, 0, 0, 0)
        Me.dtpkToDate.Name = "dtpkToDate"
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.Name = "Label3"
        '
        'chkOpenClose
        '
        resources.ApplyResources(Me.chkOpenClose, "chkOpenClose")
        Me.chkOpenClose.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkOpenClose.BoxColor = System.Drawing.Color.Black
        Me.chkOpenClose.BoxLocationX = 0
        Me.chkOpenClose.BoxLocationY = 4
        Me.chkOpenClose.BoxSize = 20
        Me.chkOpenClose.BoxSpacing = CType(0UI, UInteger)
        Me.chkOpenClose.Checked = True
        Me.chkOpenClose.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkOpenClose.DoubleBorder = False
        Me.chkOpenClose.FlatAppearance.BorderSize = 0
        Me.chkOpenClose.Name = "chkOpenClose"
        Me.chkOpenClose.TextLocationX = 20
        Me.chkOpenClose.TextLocationY = 1
        Me.chkOpenClose.TickColor = System.Drawing.Color.Cyan
        Me.chkOpenClose.TickLeftPosition = -3.0!
        Me.chkOpenClose.TickSize = 20.0!
        Me.chkOpenClose.TickTopPosition = 0.0!
        Me.chkOpenClose.UseVisualStyleBackColor = True
        '
        'chkStartStop
        '
        resources.ApplyResources(Me.chkStartStop, "chkStartStop")
        Me.chkStartStop.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkStartStop.BoxColor = System.Drawing.Color.Black
        Me.chkStartStop.BoxLocationX = 0
        Me.chkStartStop.BoxLocationY = 4
        Me.chkStartStop.BoxSize = 20
        Me.chkStartStop.BoxSpacing = CType(0UI, UInteger)
        Me.chkStartStop.Checked = True
        Me.chkStartStop.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkStartStop.DoubleBorder = False
        Me.chkStartStop.FlatAppearance.BorderSize = 0
        Me.chkStartStop.Name = "chkStartStop"
        Me.chkStartStop.TextLocationX = 20
        Me.chkStartStop.TextLocationY = 1
        Me.chkStartStop.TickColor = System.Drawing.Color.Cyan
        Me.chkStartStop.TickLeftPosition = -3.0!
        Me.chkStartStop.TickSize = 20.0!
        Me.chkStartStop.TickTopPosition = 0.0!
        Me.chkStartStop.UseVisualStyleBackColor = True
        '
        'chkError
        '
        resources.ApplyResources(Me.chkError, "chkError")
        Me.chkError.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkError.BoxColor = System.Drawing.Color.Black
        Me.chkError.BoxLocationX = 0
        Me.chkError.BoxLocationY = 4
        Me.chkError.BoxSize = 20
        Me.chkError.BoxSpacing = CType(0UI, UInteger)
        Me.chkError.Checked = True
        Me.chkError.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkError.DoubleBorder = False
        Me.chkError.FlatAppearance.BorderSize = 0
        Me.chkError.Name = "chkError"
        Me.chkError.TextLocationX = 20
        Me.chkError.TextLocationY = 1
        Me.chkError.TickColor = System.Drawing.Color.Cyan
        Me.chkError.TickLeftPosition = -3.0!
        Me.chkError.TickSize = 20.0!
        Me.chkError.TickTopPosition = 0.0!
        Me.chkError.UseVisualStyleBackColor = True
        '
        'chkEdit
        '
        resources.ApplyResources(Me.chkEdit, "chkEdit")
        Me.chkEdit.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkEdit.BoxColor = System.Drawing.Color.Black
        Me.chkEdit.BoxLocationX = 0
        Me.chkEdit.BoxLocationY = 4
        Me.chkEdit.BoxSize = 20
        Me.chkEdit.BoxSpacing = CType(0UI, UInteger)
        Me.chkEdit.Checked = True
        Me.chkEdit.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkEdit.DoubleBorder = False
        Me.chkEdit.FlatAppearance.BorderSize = 0
        Me.chkEdit.Name = "chkEdit"
        Me.chkEdit.TextLocationX = 20
        Me.chkEdit.TextLocationY = 1
        Me.chkEdit.TickColor = System.Drawing.Color.Cyan
        Me.chkEdit.TickLeftPosition = -3.0!
        Me.chkEdit.TickSize = 20.0!
        Me.chkEdit.TickTopPosition = 0.0!
        Me.chkEdit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        resources.ApplyResources(Me.GroupBox1, "GroupBox1")
        Me.GroupBox1.Controls.Add(Me.chkEdit)
        Me.GroupBox1.Controls.Add(Me.chkError)
        Me.GroupBox1.Controls.Add(Me.chkStartStop)
        Me.GroupBox1.Controls.Add(Me.btnFilter)
        Me.GroupBox1.Controls.Add(Me.chkOpenClose)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dtpkToDate)
        Me.GroupBox1.Controls.Add(Me.dtpkFromDate)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.TabStop = False
        '
        'btnFilter
        '
        resources.ApplyResources(Me.btnFilter, "btnFilter")
        Me.btnFilter.BackColor = System.Drawing.Color.Teal
        Me.btnFilter.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Cyan
        Me.btnFilter.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnFilter.ForeColor = System.Drawing.Color.White
        Me.btnFilter.Image = Global.LaserCutting.My.Resources.Resources.filter
        Me.btnFilter.Name = "btnFilter"
        Me.btnFilter.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        resources.ApplyResources(Me.btnExport, "btnExport")
        Me.btnExport.BackColor = System.Drawing.Color.Olive
        Me.btnExport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Yellow
        Me.btnExport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnExport.ForeColor = System.Drawing.Color.White
        Me.btnExport.Image = Global.LaserCutting.My.Resources.Resources.export
        Me.btnExport.Name = "btnExport"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'chkUseFilter
        '
        resources.ApplyResources(Me.chkUseFilter, "chkUseFilter")
        Me.chkUseFilter.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkUseFilter.BoxColor = System.Drawing.Color.Black
        Me.chkUseFilter.BoxLocationX = 0
        Me.chkUseFilter.BoxLocationY = 4
        Me.chkUseFilter.BoxSize = 20
        Me.chkUseFilter.BoxSpacing = CType(0UI, UInteger)
        Me.chkUseFilter.DoubleBorder = False
        Me.chkUseFilter.FlatAppearance.BorderSize = 0
        Me.chkUseFilter.Name = "chkUseFilter"
        Me.chkUseFilter.TextLocationX = 20
        Me.chkUseFilter.TextLocationY = 1
        Me.chkUseFilter.TickColor = System.Drawing.Color.Cyan
        Me.chkUseFilter.TickLeftPosition = -3.0!
        Me.chkUseFilter.TickSize = 20.0!
        Me.chkUseFilter.TickTopPosition = 0.0!
        Me.chkUseFilter.UseVisualStyleBackColor = True
        '
        'FLog
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.chkUseFilter)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvView)
        Me.Controls.Add(Me.btnExport)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FLog"
        CType(Me.dgvView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvView As System.Windows.Forms.DataGridView
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents dtpkFromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpkToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkOpenClose As LaserCutting.CheckBoxEx
    Friend WithEvents chkStartStop As LaserCutting.CheckBoxEx
    Friend WithEvents chkError As LaserCutting.CheckBoxEx
    Friend WithEvents chkEdit As LaserCutting.CheckBoxEx
    Friend WithEvents btnFilter As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkUseFilter As LaserCutting.CheckBoxEx
End Class
