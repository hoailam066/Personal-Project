<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FAlignment
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
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbOffsetY = New System.Windows.Forms.TextBox()
        Me.tbOffsetX = New System.Windows.Forms.TextBox()
        Me.tbAcceptScore = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.btnSearchReturn = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowRulerToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.grbCamera = New LaserSolder.GroupBoxEx()
        Me.ImageViewer1 = New VisionSystem.ImageDisplay()
        Me.GroupBoxEx1 = New LaserSolder.GroupBoxEx()
        Me.ImageViewer2 = New VisionSystem.ImageDisplay()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TrackBarJogSpeed = New System.Windows.Forms.TrackBar()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbActiveAxisZ = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisY = New LaserSolder.RadioButtonEx()
        Me.rbActiveAxisX = New LaserSolder.RadioButtonEx()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnContinuousMoveAdd = New System.Windows.Forms.Button()
        Me.btnContinuousMoveMinus = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCurPosX = New System.Windows.Forms.TextBox()
        Me.txtCurPosY = New System.Windows.Forms.TextBox()
        Me.Panel6.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grbCamera.SuspendLayout()
        Me.GroupBoxEx1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.TrackBarJogSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel6
        '
        Me.Panel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel6.Controls.Add(Me.Label17)
        Me.Panel6.Controls.Add(Me.GroupBox2)
        Me.Panel6.Controls.Add(Me.btnSearchReturn)
        Me.Panel6.Controls.Add(Me.btnSearch)
        Me.Panel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel6.Location = New System.Drawing.Point(1309, 481)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(338, 159)
        Me.Panel6.TabIndex = 10
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(4, 3)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 20)
        Me.Label17.TabIndex = 0
        Me.Label17.Text = "Result"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbOffsetY)
        Me.GroupBox2.Controls.Add(Me.tbOffsetX)
        Me.GroupBox2.Controls.Add(Me.tbAcceptScore)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 14)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(327, 83)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'tbOffsetY
        '
        Me.tbOffsetY.Location = New System.Drawing.Point(225, 50)
        Me.tbOffsetY.Name = "tbOffsetY"
        Me.tbOffsetY.Size = New System.Drawing.Size(95, 26)
        Me.tbOffsetY.TabIndex = 1
        Me.tbOffsetY.Text = "0.0"
        '
        'tbOffsetX
        '
        Me.tbOffsetX.Location = New System.Drawing.Point(117, 50)
        Me.tbOffsetX.Name = "tbOffsetX"
        Me.tbOffsetX.Size = New System.Drawing.Size(95, 26)
        Me.tbOffsetX.TabIndex = 1
        Me.tbOffsetX.Text = "0.0"
        '
        'tbAcceptScore
        '
        Me.tbAcceptScore.Location = New System.Drawing.Point(117, 20)
        Me.tbAcceptScore.Name = "tbAcceptScore"
        Me.tbAcceptScore.Size = New System.Drawing.Size(95, 26)
        Me.tbAcceptScore.TabIndex = 1
        Me.tbAcceptScore.Text = "85.0"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(215, 22)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(23, 20)
        Me.Label20.TabIndex = 0
        Me.Label20.Text = "%"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(209, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(20, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Y"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(98, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(2, 53)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(93, 20)
        Me.Label19.TabIndex = 0
        Me.Label19.Text = "Offset (mm)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(2, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(113, 20)
        Me.Label18.TabIndex = 0
        Me.Label18.Text = "Matching Rate"
        '
        'btnSearchReturn
        '
        Me.btnSearchReturn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearchReturn.Image = Global.LaserSolder.My.Resources.Resources.returnicon
        Me.btnSearchReturn.Location = New System.Drawing.Point(188, 102)
        Me.btnSearchReturn.Name = "btnSearchReturn"
        Me.btnSearchReturn.Size = New System.Drawing.Size(116, 49)
        Me.btnSearchReturn.TabIndex = 3
        Me.btnSearchReturn.Text = "Return"
        Me.btnSearchReturn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearchReturn.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = Global.LaserSolder.My.Resources.Resources.searchicon
        Me.btnSearch.Location = New System.Drawing.Point(36, 102)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(116, 49)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ShowRulerToolToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(160, 26)
        '
        'ShowRulerToolToolStripMenuItem
        '
        Me.ShowRulerToolToolStripMenuItem.Name = "ShowRulerToolToolStripMenuItem"
        Me.ShowRulerToolToolStripMenuItem.Size = New System.Drawing.Size(159, 22)
        Me.ShowRulerToolToolStripMenuItem.Text = "Show Ruler Tool"
        '
        'Timer1
        '
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        '
        'grbCamera
        '
        Me.grbCamera.BackColor = System.Drawing.Color.White
        Me.grbCamera.BorderColor = System.Drawing.Color.White
        Me.grbCamera.BorderRadius = CType(0UI, UInteger)
        Me.grbCamera.Controls.Add(Me.ImageViewer1)
        Me.grbCamera.Location = New System.Drawing.Point(1, 2)
        Me.grbCamera.Name = "grbCamera"
        Me.grbCamera.Size = New System.Drawing.Size(1300, 975)
        Me.grbCamera.TabIndex = 14
        Me.grbCamera.TabStop = False
        Me.grbCamera.Tag = "FAlignment"
        Me.grbCamera.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ImageViewer1
        '
        Me.ImageViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageViewer1.BackColor = System.Drawing.Color.Maroon
        Me.ImageViewer1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ImageViewer1.ImagePoint_X = 0.0R
        Me.ImageViewer1.ImagePoint_Y = 0.0R
        Me.ImageViewer1.ImagePointCanGet = True
        Me.ImageViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ImageViewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageViewer1.Name = "ImageViewer1"
        Me.ImageViewer1.Record = False
        Me.ImageViewer1.RecordInit = False
        Me.ImageViewer1.RecordIsThreadFinished = False
        Me.ImageViewer1.RecordIsThreadStarted = False
        Me.ImageViewer1.RecordPath = Nothing
        Me.ImageViewer1.RecordStop = False
        Me.ImageViewer1.Size = New System.Drawing.Size(1300, 975)
        Me.ImageViewer1.TabIndex = 0
        '
        'GroupBoxEx1
        '
        Me.GroupBoxEx1.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBoxEx1.BorderRadius = CType(0UI, UInteger)
        Me.GroupBoxEx1.Controls.Add(Me.ImageViewer2)
        Me.GroupBoxEx1.Location = New System.Drawing.Point(1309, 646)
        Me.GroupBoxEx1.Name = "GroupBoxEx1"
        Me.GroupBoxEx1.Size = New System.Drawing.Size(332, 332)
        Me.GroupBoxEx1.TabIndex = 11
        Me.GroupBoxEx1.TabStop = False
        Me.GroupBoxEx1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ImageViewer2
        '
        Me.ImageViewer2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageViewer2.BackColor = System.Drawing.Color.Maroon
        Me.ImageViewer2.ContextMenuStrip = Me.ContextMenuStrip1
        Me.ImageViewer2.ImagePoint_X = 0.0R
        Me.ImageViewer2.ImagePoint_Y = 0.0R
        Me.ImageViewer2.ImagePointCanGet = True
        Me.ImageViewer2.Location = New System.Drawing.Point(1, 1)
        Me.ImageViewer2.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageViewer2.MaximumSize = New System.Drawing.Size(800, 867)
        Me.ImageViewer2.Name = "ImageViewer2"
        Me.ImageViewer2.Record = False
        Me.ImageViewer2.RecordInit = False
        Me.ImageViewer2.RecordIsThreadFinished = False
        Me.ImageViewer2.RecordIsThreadStarted = False
        Me.ImageViewer2.RecordPath = Nothing
        Me.ImageViewer2.RecordStop = False
        Me.ImageViewer2.Size = New System.Drawing.Size(330, 330)
        Me.ImageViewer2.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.txtCurPosY)
        Me.Panel2.Controls.Add(Me.btnContinuousMoveAdd)
        Me.Panel2.Controls.Add(Me.txtCurPosX)
        Me.Panel2.Controls.Add(Me.btnContinuousMoveMinus)
        Me.Panel2.Controls.Add(Me.rbActiveAxisZ)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.rbActiveAxisY)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.rbActiveAxisX)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.TrackBarJogSpeed)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Location = New System.Drawing.Point(1310, 343)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(345, 132)
        Me.Panel2.TabIndex = 15
        '
        'TrackBarJogSpeed
        '
        Me.TrackBarJogSpeed.AutoSize = False
        Me.TrackBarJogSpeed.Location = New System.Drawing.Point(69, 40)
        Me.TrackBarJogSpeed.Maximum = 100
        Me.TrackBarJogSpeed.Minimum = 1
        Me.TrackBarJogSpeed.Name = "TrackBarJogSpeed"
        Me.TrackBarJogSpeed.Size = New System.Drawing.Size(244, 26)
        Me.TrackBarJogSpeed.TabIndex = 7
        Me.TrackBarJogSpeed.TickFrequency = 100
        Me.TrackBarJogSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarJogSpeed.Value = 25
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 20)
        Me.Label8.TabIndex = 5
        Me.Label8.Text = "Speed"
        '
        'rbActiveAxisZ
        '
        Me.rbActiveAxisZ.AutoSize = True
        Me.rbActiveAxisZ.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisZ.CircleCheckedRadius = 6
        Me.rbActiveAxisZ.CircleCheckedX = 2
        Me.rbActiveAxisZ.CircleCheckedY = 2
        Me.rbActiveAxisZ.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisZ.CircleGlintSize = 5
        Me.rbActiveAxisZ.CircleGlintX = 4
        Me.rbActiveAxisZ.CircleGlintY = 4
        Me.rbActiveAxisZ.CircleRadius = 8
        Me.rbActiveAxisZ.CircleWidth = 1.0!
        Me.rbActiveAxisZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisZ.Location = New System.Drawing.Point(272, 12)
        Me.rbActiveAxisZ.Name = "rbActiveAxisZ"
        Me.rbActiveAxisZ.Size = New System.Drawing.Size(37, 24)
        Me.rbActiveAxisZ.TabIndex = 15
        Me.rbActiveAxisZ.Text = "Z"
        Me.rbActiveAxisZ.UseVisualStyleBackColor = True
        '
        'rbActiveAxisY
        '
        Me.rbActiveAxisY.AutoSize = True
        Me.rbActiveAxisY.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisY.CircleCheckedRadius = 6
        Me.rbActiveAxisY.CircleCheckedX = 2
        Me.rbActiveAxisY.CircleCheckedY = 2
        Me.rbActiveAxisY.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisY.CircleGlintSize = 5
        Me.rbActiveAxisY.CircleGlintX = 4
        Me.rbActiveAxisY.CircleGlintY = 4
        Me.rbActiveAxisY.CircleRadius = 8
        Me.rbActiveAxisY.CircleWidth = 1.0!
        Me.rbActiveAxisY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisY.Location = New System.Drawing.Point(225, 12)
        Me.rbActiveAxisY.Name = "rbActiveAxisY"
        Me.rbActiveAxisY.Size = New System.Drawing.Size(38, 24)
        Me.rbActiveAxisY.TabIndex = 17
        Me.rbActiveAxisY.Text = "Y"
        Me.rbActiveAxisY.UseVisualStyleBackColor = True
        '
        'rbActiveAxisX
        '
        Me.rbActiveAxisX.AutoSize = True
        Me.rbActiveAxisX.Checked = True
        Me.rbActiveAxisX.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbActiveAxisX.CircleCheckedRadius = 6
        Me.rbActiveAxisX.CircleCheckedX = 2
        Me.rbActiveAxisX.CircleCheckedY = 2
        Me.rbActiveAxisX.CircleColor = System.Drawing.Color.DimGray
        Me.rbActiveAxisX.CircleGlintSize = 5
        Me.rbActiveAxisX.CircleGlintX = 4
        Me.rbActiveAxisX.CircleGlintY = 4
        Me.rbActiveAxisX.CircleRadius = 8
        Me.rbActiveAxisX.CircleWidth = 1.0!
        Me.rbActiveAxisX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbActiveAxisX.Location = New System.Drawing.Point(178, 12)
        Me.rbActiveAxisX.Name = "rbActiveAxisX"
        Me.rbActiveAxisX.Size = New System.Drawing.Size(38, 24)
        Me.rbActiveAxisX.TabIndex = 16
        Me.rbActiveAxisX.TabStop = True
        Me.rbActiveAxisX.Text = "X"
        Me.rbActiveAxisX.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(92, 10)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(83, 20)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Active axis"
        '
        'btnContinuousMoveAdd
        '
        Me.btnContinuousMoveAdd.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveAdd.BackgroundImage = Global.LaserSolder.My.Resources.Resources.plus
        Me.btnContinuousMoveAdd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContinuousMoveAdd.FlatAppearance.BorderSize = 0
        Me.btnContinuousMoveAdd.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveAdd.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinuousMoveAdd.Location = New System.Drawing.Point(229, 66)
        Me.btnContinuousMoveAdd.Name = "btnContinuousMoveAdd"
        Me.btnContinuousMoveAdd.Size = New System.Drawing.Size(48, 52)
        Me.btnContinuousMoveAdd.TabIndex = 19
        Me.btnContinuousMoveAdd.UseVisualStyleBackColor = False
        '
        'btnContinuousMoveMinus
        '
        Me.btnContinuousMoveMinus.BackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveMinus.BackgroundImage = Global.LaserSolder.My.Resources.Resources.subtract
        Me.btnContinuousMoveMinus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.btnContinuousMoveMinus.FlatAppearance.BorderSize = 0
        Me.btnContinuousMoveMinus.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveMinus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnContinuousMoveMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnContinuousMoveMinus.Location = New System.Drawing.Point(288, 66)
        Me.btnContinuousMoveMinus.Name = "btnContinuousMoveMinus"
        Me.btnContinuousMoveMinus.Size = New System.Drawing.Size(48, 52)
        Me.btnContinuousMoveMinus.TabIndex = 18
        Me.btnContinuousMoveMinus.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(0, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "X"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(114, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Y"
        '
        'txtCurPosX
        '
        Me.txtCurPosX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurPosX.Location = New System.Drawing.Point(18, 89)
        Me.txtCurPosX.Name = "txtCurPosX"
        Me.txtCurPosX.Size = New System.Drawing.Size(95, 26)
        Me.txtCurPosX.TabIndex = 1
        Me.txtCurPosX.Text = "0.0"
        '
        'txtCurPosY
        '
        Me.txtCurPosY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCurPosY.Location = New System.Drawing.Point(130, 89)
        Me.txtCurPosY.Name = "txtCurPosY"
        Me.txtCurPosY.Size = New System.Drawing.Size(95, 26)
        Me.txtCurPosY.TabIndex = 1
        Me.txtCurPosY.Text = "0.0"
        '
        'FAlignment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1659, 991)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.grbCamera)
        Me.Controls.Add(Me.GroupBoxEx1)
        Me.Controls.Add(Me.Panel6)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(1920, 1124)
        Me.MinimizeBox = False
        Me.Name = "FAlignment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FAlignment"
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grbCamera.ResumeLayout(False)
        Me.GroupBoxEx1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TrackBarJogSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageViewer1 As VisionSystem.ImageDisplay
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents tbOffsetY As System.Windows.Forms.TextBox
    Friend WithEvents tbOffsetX As System.Windows.Forms.TextBox
    Friend WithEvents tbAcceptScore As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents btnSearchReturn As System.Windows.Forms.Button
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents GroupBoxEx1 As LaserSolder.GroupBoxEx
    Friend WithEvents grbCamera As LaserSolder.GroupBoxEx
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowRulerToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageViewer2 As VisionSystem.ImageDisplay
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnContinuousMoveAdd As System.Windows.Forms.Button
    Friend WithEvents btnContinuousMoveMinus As System.Windows.Forms.Button
    Friend WithEvents rbActiveAxisZ As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisY As LaserSolder.RadioButtonEx
    Friend WithEvents rbActiveAxisX As LaserSolder.RadioButtonEx
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrackBarJogSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCurPosY As System.Windows.Forms.TextBox
    Friend WithEvents txtCurPosX As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
End Class
