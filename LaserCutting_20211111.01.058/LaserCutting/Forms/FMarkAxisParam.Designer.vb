<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMarkAxisParam
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMarkAxisParam))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numCharSpacing = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numAxisLength = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.numArrowLength = New System.Windows.Forms.NumericUpDown()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.numArrowSize = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numCharHeight = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.numCharWidth = New System.Windows.Forms.NumericUpDown()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.numOffsetX = New System.Windows.Forms.NumericUpDown()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.numOffsetY = New System.Windows.Forms.NumericUpDown()
        CType(Me.numCharSpacing, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numAxisLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numArrowLength, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numArrowSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCharHeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCharWidth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOffsetX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numOffsetY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(21, 142)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Character Spacing"
        '
        'numCharSpacing
        '
        Me.numCharSpacing.Location = New System.Drawing.Point(20, 169)
        Me.numCharSpacing.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numCharSpacing.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCharSpacing.Name = "numCharSpacing"
        Me.numCharSpacing.Size = New System.Drawing.Size(161, 29)
        Me.numCharSpacing.TabIndex = 1
        Me.numCharSpacing.Value = New Decimal(New Integer() {100, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(15, 21)
        Me.Label2.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Uint: um"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(80, 293)
        Me.Label3.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(103, 24)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Axis length"
        '
        'numAxisLength
        '
        Me.numAxisLength.Location = New System.Drawing.Point(19, 320)
        Me.numAxisLength.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numAxisLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numAxisLength.Name = "numAxisLength"
        Me.numAxisLength.Size = New System.Drawing.Size(161, 29)
        Me.numAxisLength.TabIndex = 1
        Me.numAxisLength.Value = New Decimal(New Integer() {5000, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(376, 192)
        Me.Label4.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(117, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Arrow length"
        '
        'numArrowLength
        '
        Me.numArrowLength.Location = New System.Drawing.Point(380, 219)
        Me.numArrowLength.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numArrowLength.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numArrowLength.Name = "numArrowLength"
        Me.numArrowLength.Size = New System.Drawing.Size(161, 29)
        Me.numArrowLength.TabIndex = 1
        Me.numArrowLength.Value = New Decimal(New Integer() {500, 0, 0, 0})
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.Transparent
        Me.Label5.Location = New System.Drawing.Point(374, 469)
        Me.Label5.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 24)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Arrow size"
        '
        'numArrowSize
        '
        Me.numArrowSize.Location = New System.Drawing.Point(304, 496)
        Me.numArrowSize.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numArrowSize.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numArrowSize.Name = "numArrowSize"
        Me.numArrowSize.Size = New System.Drawing.Size(161, 29)
        Me.numArrowSize.TabIndex = 1
        Me.numArrowSize.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(725, 435)
        Me.Label6.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(148, 24)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Character height"
        '
        'numCharHeight
        '
        Me.numCharHeight.Location = New System.Drawing.Point(729, 462)
        Me.numCharHeight.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numCharHeight.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCharHeight.Name = "numCharHeight"
        Me.numCharHeight.Size = New System.Drawing.Size(161, 29)
        Me.numCharHeight.TabIndex = 1
        Me.numCharHeight.Value = New Decimal(New Integer() {600, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(570, 550)
        Me.Label7.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(140, 24)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Character width"
        '
        'numCharWidth
        '
        Me.numCharWidth.Location = New System.Drawing.Point(574, 577)
        Me.numCharWidth.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numCharWidth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCharWidth.Name = "numCharWidth"
        Me.numCharWidth.Size = New System.Drawing.Size(161, 29)
        Me.numCharWidth.TabIndex = 1
        Me.numCharWidth.Value = New Decimal(New Integer() {400, 0, 0, 0})
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.Olive
        Me.btnSave.FlatAppearance.BorderSize = 0
        Me.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnSave.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(684, 206)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(139, 85)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(587, 16)
        Me.Label8.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 24)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Offset X"
        '
        'numOffsetX
        '
        Me.numOffsetX.Location = New System.Drawing.Point(586, 43)
        Me.numOffsetX.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numOffsetX.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numOffsetX.Name = "numOffsetX"
        Me.numOffsetX.Size = New System.Drawing.Size(161, 29)
        Me.numOffsetX.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(587, 90)
        Me.Label9.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 24)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Offset Y"
        '
        'numOffsetY
        '
        Me.numOffsetY.Location = New System.Drawing.Point(586, 117)
        Me.numOffsetY.Maximum = New Decimal(New Integer() {65535, 0, 0, 0})
        Me.numOffsetY.Minimum = New Decimal(New Integer() {65535, 0, 0, -2147483648})
        Me.numOffsetY.Name = "numOffsetY"
        Me.numOffsetY.Size = New System.Drawing.Size(161, 29)
        Me.numOffsetY.TabIndex = 1
        '
        'FMarkAxisParam
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 24.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = Global.LaserCutting.My.Resources.Resources.markAxis
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(914, 615)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.numArrowSize)
        Me.Controls.Add(Me.numCharWidth)
        Me.Controls.Add(Me.numCharHeight)
        Me.Controls.Add(Me.numArrowLength)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.numAxisLength)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numOffsetY)
        Me.Controls.Add(Me.numOffsetX)
        Me.Controls.Add(Me.numCharSpacing)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "FMarkAxisParam"
        Me.Text = "Mark Axis Parameter"
        CType(Me.numCharSpacing, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numAxisLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numArrowLength, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numArrowSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCharHeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCharWidth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOffsetX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numOffsetY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numCharSpacing As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numAxisLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents numArrowLength As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents numArrowSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numCharHeight As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents numCharWidth As System.Windows.Forms.NumericUpDown
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents numOffsetX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents numOffsetY As System.Windows.Forms.NumericUpDown
End Class
