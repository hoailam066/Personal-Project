<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRegisterPosition
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
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.btnMove = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtS = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.txtR = New System.Windows.Forms.TextBox()
        Me.txtZ = New System.Windows.Forms.TextBox()
        Me.txtY = New System.Windows.Forms.TextBox()
        Me.txtX = New System.Windows.Forms.TextBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnApply = New System.Windows.Forms.Button()
        Me.chkReverseApply = New LaserSolder.CheckBoxEx()
        Me.rdXYZR2 = New LaserSolder.RadioButtonEx()
        Me.rdRToXYZ = New LaserSolder.RadioButtonEx()
        Me.rdXYZToR = New LaserSolder.RadioButtonEx()
        Me.rdS = New LaserSolder.RadioButtonEx()
        Me.rdOffset = New LaserSolder.RadioButtonEx()
        Me.rdZ = New LaserSolder.RadioButtonEx()
        Me.rdXYZR = New LaserSolder.RadioButtonEx()
        Me.RadioButtonEx1 = New LaserSolder.RadioButtonEx()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(4, 5)
        Me.ComboBox1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(238, 28)
        Me.ComboBox1.TabIndex = 1
        '
        'btnMove
        '
        Me.btnMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMove.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnMove.Image = Global.LaserSolder.My.Resources.Resources.start
        Me.btnMove.Location = New System.Drawing.Point(363, 20)
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(114, 40)
        Me.btnMove.TabIndex = 2
        Me.btnMove.Text = "Move"
        Me.btnMove.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnMove.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.chkReverseApply)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.txtS)
        Me.Panel1.Controls.Add(Me.btnApply)
        Me.Panel1.Controls.Add(Me.btnUpdate)
        Me.Panel1.Controls.Add(Me.txtR)
        Me.Panel1.Controls.Add(Me.txtZ)
        Me.Panel1.Controls.Add(Me.txtY)
        Me.Panel1.Controls.Add(Me.txtX)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Location = New System.Drawing.Point(3, 46)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(517, 201)
        Me.Panel1.TabIndex = 3
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.btnMove)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 124)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(501, 70)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = " Motion Sequence "
        '
        'txtS
        '
        Me.txtS.Location = New System.Drawing.Point(408, 41)
        Me.txtS.Name = "txtS"
        Me.txtS.Size = New System.Drawing.Size(100, 26)
        Me.txtS.TabIndex = 2
        '
        'btnUpdate
        '
        Me.btnUpdate.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpdate.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnUpdate.Location = New System.Drawing.Point(296, 85)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(212, 37)
        Me.btnUpdate.TabIndex = 2
        Me.btnUpdate.Text = "Update Current Position"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'txtR
        '
        Me.txtR.Location = New System.Drawing.Point(307, 41)
        Me.txtR.Name = "txtR"
        Me.txtR.Size = New System.Drawing.Size(100, 26)
        Me.txtR.TabIndex = 2
        '
        'txtZ
        '
        Me.txtZ.Location = New System.Drawing.Point(206, 41)
        Me.txtZ.Name = "txtZ"
        Me.txtZ.Size = New System.Drawing.Size(100, 26)
        Me.txtZ.TabIndex = 2
        '
        'txtY
        '
        Me.txtY.Location = New System.Drawing.Point(105, 41)
        Me.txtY.Name = "txtY"
        Me.txtY.Size = New System.Drawing.Size(100, 26)
        Me.txtY.TabIndex = 2
        '
        'txtX
        '
        Me.txtX.Location = New System.Drawing.Point(4, 41)
        Me.txtX.Name = "txtX"
        Me.txtX.Size = New System.Drawing.Size(100, 26)
        Me.txtX.TabIndex = 2
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnSave.Image = Global.LaserSolder.My.Resources.Resources.save
        Me.btnSave.Location = New System.Drawing.Point(286, 254)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 40)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "Save"
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancel.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnCancel.Image = Global.LaserSolder.My.Resources.Resources.cancel
        Me.btnCancel.Location = New System.Drawing.Point(406, 254)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(114, 40)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rdXYZR2)
        Me.Panel2.Controls.Add(Me.rdRToXYZ)
        Me.Panel2.Controls.Add(Me.rdXYZToR)
        Me.Panel2.Location = New System.Drawing.Point(8, 26)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(276, 38)
        Me.Panel2.TabIndex = 3
        '
        'btnApply
        '
        Me.btnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.Color.SteelBlue
        Me.btnApply.Location = New System.Drawing.Point(19, 81)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(212, 37)
        Me.btnApply.TabIndex = 2
        Me.btnApply.Text = "Apply to job points"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'chkReverseApply
        '
        Me.chkReverseApply.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkReverseApply.BoxBackColor = System.Drawing.Color.Transparent
        Me.chkReverseApply.BoxColor = System.Drawing.Color.Black
        Me.chkReverseApply.BoxLocationX = 0
        Me.chkReverseApply.BoxLocationY = 3
        Me.chkReverseApply.BoxSize = 14
        Me.chkReverseApply.BoxSpacing = CType(0UI, UInteger)
        Me.chkReverseApply.DoubleBorder = False
        Me.chkReverseApply.FlatAppearance.BorderSize = 0
        Me.chkReverseApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkReverseApply.Location = New System.Drawing.Point(379, 5)
        Me.chkReverseApply.Name = "chkReverseApply"
        Me.chkReverseApply.Size = New System.Drawing.Size(130, 23)
        Me.chkReverseApply.TabIndex = 4
        Me.chkReverseApply.Text = "Reverse Apply"
        Me.chkReverseApply.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkReverseApply.TextLocationX = 16
        Me.chkReverseApply.TextLocationY = 1
        Me.chkReverseApply.TickColor = System.Drawing.Color.SkyBlue
        Me.chkReverseApply.TickLeftPosition = -4.0!
        Me.chkReverseApply.TickSize = 17.0!
        Me.chkReverseApply.TickTopPosition = -2.0!
        Me.chkReverseApply.UseVisualStyleBackColor = True
        '
        'rdXYZR2
        '
        Me.rdXYZR2.AutoSize = True
        Me.rdXYZR2.Checked = True
        Me.rdXYZR2.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdXYZR2.CircleCheckedRadius = 6
        Me.rdXYZR2.CircleCheckedX = 2
        Me.rdXYZR2.CircleCheckedY = 2
        Me.rdXYZR2.CircleColor = System.Drawing.Color.DimGray
        Me.rdXYZR2.CircleGlintSize = 5
        Me.rdXYZR2.CircleGlintX = 4
        Me.rdXYZR2.CircleGlintY = 4
        Me.rdXYZR2.CircleRadius = 8
        Me.rdXYZR2.CircleWidth = 1.0!
        Me.rdXYZR2.Location = New System.Drawing.Point(199, 8)
        Me.rdXYZR2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdXYZR2.Name = "rdXYZR2"
        Me.rdXYZR2.Size = New System.Drawing.Size(71, 24)
        Me.rdXYZR2.TabIndex = 0
        Me.rdXYZR2.TabStop = True
        Me.rdXYZR2.Tag = "2"
        Me.rdXYZR2.Text = "XYZR"
        Me.rdXYZR2.UseVisualStyleBackColor = True
        '
        'rdRToXYZ
        '
        Me.rdRToXYZ.AutoSize = True
        Me.rdRToXYZ.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdRToXYZ.CircleCheckedRadius = 6
        Me.rdRToXYZ.CircleCheckedX = 2
        Me.rdRToXYZ.CircleCheckedY = 2
        Me.rdRToXYZ.CircleColor = System.Drawing.Color.DimGray
        Me.rdRToXYZ.CircleGlintSize = 5
        Me.rdRToXYZ.CircleGlintX = 4
        Me.rdRToXYZ.CircleGlintY = 4
        Me.rdRToXYZ.CircleRadius = 8
        Me.rdRToXYZ.CircleWidth = 1.0!
        Me.rdRToXYZ.Location = New System.Drawing.Point(4, 8)
        Me.rdRToXYZ.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdRToXYZ.Name = "rdRToXYZ"
        Me.rdRToXYZ.Size = New System.Drawing.Size(85, 24)
        Me.rdRToXYZ.TabIndex = 0
        Me.rdRToXYZ.Tag = "0"
        Me.rdRToXYZ.Text = "R->XYZ"
        Me.rdRToXYZ.UseVisualStyleBackColor = True
        '
        'rdXYZToR
        '
        Me.rdXYZToR.AutoSize = True
        Me.rdXYZToR.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdXYZToR.CircleCheckedRadius = 6
        Me.rdXYZToR.CircleCheckedX = 2
        Me.rdXYZToR.CircleCheckedY = 2
        Me.rdXYZToR.CircleColor = System.Drawing.Color.DimGray
        Me.rdXYZToR.CircleGlintSize = 5
        Me.rdXYZToR.CircleGlintX = 4
        Me.rdXYZToR.CircleGlintY = 4
        Me.rdXYZToR.CircleRadius = 8
        Me.rdXYZToR.CircleWidth = 1.0!
        Me.rdXYZToR.Location = New System.Drawing.Point(101, 8)
        Me.rdXYZToR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdXYZToR.Name = "rdXYZToR"
        Me.rdXYZToR.Size = New System.Drawing.Size(85, 24)
        Me.rdXYZToR.TabIndex = 0
        Me.rdXYZToR.Tag = "1"
        Me.rdXYZToR.Text = "XYZ->R"
        Me.rdXYZToR.UseVisualStyleBackColor = True
        '
        'rdS
        '
        Me.rdS.AutoSize = True
        Me.rdS.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdS.CircleCheckedRadius = 6
        Me.rdS.CircleCheckedX = 2
        Me.rdS.CircleCheckedY = 2
        Me.rdS.CircleColor = System.Drawing.Color.DimGray
        Me.rdS.CircleGlintSize = 5
        Me.rdS.CircleGlintX = 4
        Me.rdS.CircleGlintY = 4
        Me.rdS.CircleRadius = 8
        Me.rdS.CircleWidth = 1.0!
        Me.rdS.Location = New System.Drawing.Point(256, 14)
        Me.rdS.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdS.Name = "rdS"
        Me.rdS.Size = New System.Drawing.Size(38, 24)
        Me.rdS.TabIndex = 0
        Me.rdS.Tag = "3"
        Me.rdS.Text = "S"
        Me.rdS.UseVisualStyleBackColor = True
        Me.rdS.Visible = False
        '
        'rdOffset
        '
        Me.rdOffset.AutoSize = True
        Me.rdOffset.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdOffset.CircleCheckedRadius = 6
        Me.rdOffset.CircleCheckedX = 2
        Me.rdOffset.CircleCheckedY = 2
        Me.rdOffset.CircleColor = System.Drawing.Color.DimGray
        Me.rdOffset.CircleGlintSize = 5
        Me.rdOffset.CircleGlintX = 4
        Me.rdOffset.CircleGlintY = 4
        Me.rdOffset.CircleRadius = 8
        Me.rdOffset.CircleWidth = 1.0!
        Me.rdOffset.Location = New System.Drawing.Point(174, 14)
        Me.rdOffset.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdOffset.Name = "rdOffset"
        Me.rdOffset.Size = New System.Drawing.Size(71, 24)
        Me.rdOffset.TabIndex = 0
        Me.rdOffset.Tag = "2"
        Me.rdOffset.Text = "Offset"
        Me.rdOffset.UseVisualStyleBackColor = True
        '
        'rdZ
        '
        Me.rdZ.AutoSize = True
        Me.rdZ.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdZ.CircleCheckedRadius = 6
        Me.rdZ.CircleCheckedX = 2
        Me.rdZ.CircleCheckedY = 2
        Me.rdZ.CircleColor = System.Drawing.Color.DimGray
        Me.rdZ.CircleGlintSize = 5
        Me.rdZ.CircleGlintX = 4
        Me.rdZ.CircleGlintY = 4
        Me.rdZ.CircleRadius = 8
        Me.rdZ.CircleWidth = 1.0!
        Me.rdZ.Location = New System.Drawing.Point(103, 14)
        Me.rdZ.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdZ.Name = "rdZ"
        Me.rdZ.Size = New System.Drawing.Size(37, 24)
        Me.rdZ.TabIndex = 0
        Me.rdZ.Tag = "1"
        Me.rdZ.Text = "Z"
        Me.rdZ.UseVisualStyleBackColor = True
        '
        'rdXYZR
        '
        Me.rdXYZR.AutoSize = True
        Me.rdXYZR.Checked = True
        Me.rdXYZR.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdXYZR.CircleCheckedRadius = 6
        Me.rdXYZR.CircleCheckedX = 2
        Me.rdXYZR.CircleCheckedY = 2
        Me.rdXYZR.CircleColor = System.Drawing.Color.DimGray
        Me.rdXYZR.CircleGlintSize = 5
        Me.rdXYZR.CircleGlintX = 4
        Me.rdXYZR.CircleGlintY = 4
        Me.rdXYZR.CircleRadius = 8
        Me.rdXYZR.CircleWidth = 1.0!
        Me.rdXYZR.Location = New System.Drawing.Point(7, 14)
        Me.rdXYZR.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.rdXYZR.Name = "rdXYZR"
        Me.rdXYZR.Size = New System.Drawing.Size(71, 24)
        Me.rdXYZR.TabIndex = 0
        Me.rdXYZR.TabStop = True
        Me.rdXYZR.Tag = "0"
        Me.rdXYZR.Text = "XYZR"
        Me.rdXYZR.UseVisualStyleBackColor = True
        '
        'RadioButtonEx1
        '
        Me.RadioButtonEx1.AutoSize = True
        Me.RadioButtonEx1.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.RadioButtonEx1.CircleCheckedRadius = 6
        Me.RadioButtonEx1.CircleCheckedX = 2
        Me.RadioButtonEx1.CircleCheckedY = 2
        Me.RadioButtonEx1.CircleColor = System.Drawing.Color.DimGray
        Me.RadioButtonEx1.CircleGlintSize = 5
        Me.RadioButtonEx1.CircleGlintX = 4
        Me.RadioButtonEx1.CircleGlintY = 4
        Me.RadioButtonEx1.CircleRadius = 8
        Me.RadioButtonEx1.CircleWidth = 1.0!
        Me.RadioButtonEx1.Location = New System.Drawing.Point(16, 27)
        Me.RadioButtonEx1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.RadioButtonEx1.Name = "RadioButtonEx1"
        Me.RadioButtonEx1.Size = New System.Drawing.Size(85, 24)
        Me.RadioButtonEx1.TabIndex = 0
        Me.RadioButtonEx1.Tag = "0"
        Me.RadioButtonEx1.Text = "R->XYZ"
        Me.RadioButtonEx1.UseVisualStyleBackColor = True
        '
        'FRegisterPosition
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(525, 300)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.rdS)
        Me.Controls.Add(Me.rdOffset)
        Me.Controls.Add(Me.rdZ)
        Me.Controls.Add(Me.rdXYZR)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRegisterPosition"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Register Position"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rdXYZR As LaserSolder.RadioButtonEx
    Friend WithEvents rdZ As LaserSolder.RadioButtonEx
    Friend WithEvents rdOffset As LaserSolder.RadioButtonEx
    Friend WithEvents rdS As LaserSolder.RadioButtonEx
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents btnMove As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rdXYZR2 As LaserSolder.RadioButtonEx
    Friend WithEvents rdXYZToR As LaserSolder.RadioButtonEx
    Friend WithEvents rdRToXYZ As LaserSolder.RadioButtonEx
    Friend WithEvents txtS As System.Windows.Forms.TextBox
    Friend WithEvents btnUpdate As System.Windows.Forms.Button
    Friend WithEvents txtR As System.Windows.Forms.TextBox
    Friend WithEvents txtZ As System.Windows.Forms.TextBox
    Friend WithEvents txtY As System.Windows.Forms.TextBox
    Friend WithEvents txtX As System.Windows.Forms.TextBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents RadioButtonEx1 As LaserSolder.RadioButtonEx
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents chkReverseApply As LaserSolder.CheckBoxEx
End Class
