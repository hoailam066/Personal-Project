<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FNewProject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FNewProject))
        Me.txtProjectName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboCloneProject = New System.Windows.Forms.ComboBox()
        Me.gbInformation = New System.Windows.Forms.GroupBox()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numHeight = New System.Windows.Forms.NumericUpDown()
        Me.numYMin = New System.Windows.Forms.NumericUpDown()
        Me.numWidth = New System.Windows.Forms.NumericUpDown()
        Me.numXMin = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numWorkStep = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.chkInheritance = New LaserCutting.CheckBoxEx()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.btnCheckDuplication = New System.Windows.Forms.Button()
        Me.gbInformation.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numYMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numXMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numWorkStep, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtProjectName
        '
        Me.txtProjectName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        resources.ApplyResources(Me.txtProjectName, "txtProjectName")
        Me.txtProjectName.Name = "txtProjectName"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.Name = "Label1"
        '
        'cboCloneProject
        '
        Me.cboCloneProject.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.cboCloneProject, "cboCloneProject")
        Me.cboCloneProject.FormattingEnabled = True
        Me.cboCloneProject.Name = "cboCloneProject"
        '
        'gbInformation
        '
        Me.gbInformation.Controls.Add(Me.txtDescription)
        Me.gbInformation.Controls.Add(Me.GroupBox2)
        Me.gbInformation.Controls.Add(Me.Label9)
        Me.gbInformation.Controls.Add(Me.numWorkStep)
        Me.gbInformation.Controls.Add(Me.Label2)
        resources.ApplyResources(Me.gbInformation, "gbInformation")
        Me.gbInformation.Name = "gbInformation"
        Me.gbInformation.TabStop = False
        '
        'txtDescription
        '
        resources.ApplyResources(Me.txtDescription, "txtDescription")
        Me.txtDescription.Name = "txtDescription"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.numHeight)
        Me.GroupBox2.Controls.Add(Me.numYMin)
        Me.GroupBox2.Controls.Add(Me.numWidth)
        Me.GroupBox2.Controls.Add(Me.numXMin)
        resources.ApplyResources(Me.GroupBox2, "GroupBox2")
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        resources.ApplyResources(Me.Label8, "Label8")
        Me.Label8.Name = "Label8"
        '
        'Label6
        '
        resources.ApplyResources(Me.Label6, "Label6")
        Me.Label6.Name = "Label6"
        '
        'Label7
        '
        resources.ApplyResources(Me.Label7, "Label7")
        Me.Label7.Name = "Label7"
        '
        'Label5
        '
        resources.ApplyResources(Me.Label5, "Label5")
        Me.Label5.Name = "Label5"
        '
        'numHeight
        '
        resources.ApplyResources(Me.numHeight, "numHeight")
        Me.numHeight.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numHeight.Name = "numHeight"
        Me.numHeight.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'numYMin
        '
        resources.ApplyResources(Me.numYMin, "numYMin")
        Me.numYMin.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numYMin.Name = "numYMin"
        '
        'numWidth
        '
        resources.ApplyResources(Me.numWidth, "numWidth")
        Me.numWidth.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numWidth.Name = "numWidth"
        Me.numWidth.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'numXMin
        '
        resources.ApplyResources(Me.numXMin, "numXMin")
        Me.numXMin.Maximum = New Decimal(New Integer() {10000000, 0, 0, 0})
        Me.numXMin.Name = "numXMin"
        '
        'Label9
        '
        Me.Label9.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.Label9, "Label9")
        Me.Label9.Name = "Label9"
        '
        'numWorkStep
        '
        resources.ApplyResources(Me.numWorkStep, "numWorkStep")
        Me.numWorkStep.Maximum = New Decimal(New Integer() {4, 0, 0, 0})
        Me.numWorkStep.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numWorkStep.Name = "numWorkStep"
        Me.numWorkStep.Value = New Decimal(New Integer() {2, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Silver
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.Name = "Label2"
        '
        'chkInheritance
        '
        resources.ApplyResources(Me.chkInheritance, "chkInheritance")
        Me.chkInheritance.BackColor = System.Drawing.Color.Silver
        Me.chkInheritance.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkInheritance.BoxColor = System.Drawing.Color.Black
        Me.chkInheritance.BoxLocationX = 3
        Me.chkInheritance.BoxLocationY = 3
        Me.chkInheritance.BoxSize = 20
        Me.chkInheritance.BoxSpacing = CType(0UI, UInteger)
        Me.chkInheritance.DoubleBorder = False
        Me.chkInheritance.FlatAppearance.BorderSize = 0
        Me.chkInheritance.Name = "chkInheritance"
        Me.chkInheritance.TextLocationX = 27
        Me.chkInheritance.TextLocationY = 3
        Me.chkInheritance.TickColor = System.Drawing.Color.Cyan
        Me.chkInheritance.TickLeftPosition = 0.0!
        Me.chkInheritance.TickSize = 20.0!
        Me.chkInheritance.TickTopPosition = 0.0!
        Me.chkInheritance.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.White
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.Image = Global.LaserCutting.My.Resources.Resources.tickOKsmall
        Me.btnOK.Name = "btnOK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.White
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.Image = Global.LaserCutting.My.Resources.Resources.cancel
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnCheckDuplication
        '
        Me.btnCheckDuplication.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckDuplication.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnCheckDuplication.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnCheckDuplication, "btnCheckDuplication")
        Me.btnCheckDuplication.ForeColor = System.Drawing.Color.White
        Me.btnCheckDuplication.Image = Global.LaserCutting.My.Resources.Resources.tick
        Me.btnCheckDuplication.Name = "btnCheckDuplication"
        Me.btnCheckDuplication.UseVisualStyleBackColor = False
        '
        'FNewProject
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.CancelButton = Me.btnCancel
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.gbInformation)
        Me.Controls.Add(Me.cboCloneProject)
        Me.Controls.Add(Me.btnCheckDuplication)
        Me.Controls.Add(Me.txtProjectName)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.chkInheritance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FNewProject"
        Me.gbInformation.ResumeLayout(False)
        Me.gbInformation.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numYMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numXMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numWorkStep, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtProjectName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents chkInheritance As LaserCutting.CheckBoxEx
    Friend WithEvents cboCloneProject As System.Windows.Forms.ComboBox
    Friend WithEvents gbInformation As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents numYMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents numWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numXMin As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnCheckDuplication As System.Windows.Forms.Button
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numWorkStep As System.Windows.Forms.NumericUpDown
End Class
