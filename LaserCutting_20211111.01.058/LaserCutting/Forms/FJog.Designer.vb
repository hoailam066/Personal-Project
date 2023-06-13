<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FJog
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBoxEx1 = New LaserSolder.GroupBoxEx()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnFeedCounterClockwise = New System.Windows.Forms.Button()
        Me.btnFeedClockwise = New System.Windows.Forms.Button()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.btnRCounterClockwise = New System.Windows.Forms.Button()
        Me.btnRClockwise = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnZUp = New LaserSolder.ButtonEx()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnZDown = New LaserSolder.ButtonEx()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnXYUp = New LaserSolder.ButtonEx()
        Me.btnXYLeft = New LaserSolder.ButtonEx()
        Me.btnXYRight = New LaserSolder.ButtonEx()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnXYDown = New LaserSolder.ButtonEx()
        Me.txtSpeed = New System.Windows.Forms.TextBox()
        Me.TrackBarSpeed = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBoxEx1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.TrackBarSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.GroupBoxEx1)
        Me.Panel1.Location = New System.Drawing.Point(12, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(551, 258)
        Me.Panel1.TabIndex = 0
        '
        'GroupBoxEx1
        '
        Me.GroupBoxEx1.BorderColor = System.Drawing.Color.DeepSkyBlue
        Me.GroupBoxEx1.BorderRadius = CType(10UI, UInteger)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel4)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBoxEx1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBoxEx1.Controls.Add(Me.txtSpeed)
        Me.GroupBoxEx1.Controls.Add(Me.TrackBarSpeed)
        Me.GroupBoxEx1.Controls.Add(Me.Label5)
        Me.GroupBoxEx1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBoxEx1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBoxEx1.Name = "GroupBoxEx1"
        Me.GroupBoxEx1.Size = New System.Drawing.Size(540, 248)
        Me.GroupBoxEx1.TabIndex = 0
        Me.GroupBoxEx1.TabStop = False
        Me.GroupBoxEx1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.btnFeedCounterClockwise, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnFeedClockwise, 0, 2)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(424, 53)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(72, 145)
        Me.TableLayoutPanel1.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 46)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Feed"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnFeedCounterClockwise.Location = New System.Drawing.Point(10, 0)
        Me.btnFeedCounterClockwise.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnFeedCounterClockwise.Name = "btnFeedCounterClockwise"
        Me.btnFeedCounterClockwise.Size = New System.Drawing.Size(50, 46)
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
        Me.btnFeedClockwise.Location = New System.Drawing.Point(10, 92)
        Me.btnFeedClockwise.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnFeedClockwise.Name = "btnFeedClockwise"
        Me.btnFeedClockwise.Size = New System.Drawing.Size(50, 46)
        Me.btnFeedClockwise.TabIndex = 18
        Me.btnFeedClockwise.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.Label46, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.btnRCounterClockwise, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.btnRClockwise, 0, 2)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(311, 53)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(72, 145)
        Me.TableLayoutPanel4.TabIndex = 31
        Me.TableLayoutPanel4.Visible = False
        '
        'Label46
        '
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label46.Location = New System.Drawing.Point(3, 46)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(69, 46)
        Me.Label46.TabIndex = 17
        Me.Label46.Text = "R"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnRCounterClockwise
        '
        Me.btnRCounterClockwise.BackColor = System.Drawing.Color.Transparent
        Me.btnRCounterClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedremove
        Me.btnRCounterClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRCounterClockwise.FlatAppearance.BorderSize = 0
        Me.btnRCounterClockwise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRCounterClockwise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRCounterClockwise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRCounterClockwise.Location = New System.Drawing.Point(10, 0)
        Me.btnRCounterClockwise.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnRCounterClockwise.Name = "btnRCounterClockwise"
        Me.btnRCounterClockwise.Size = New System.Drawing.Size(50, 46)
        Me.btnRCounterClockwise.TabIndex = 18
        Me.btnRCounterClockwise.UseVisualStyleBackColor = False
        '
        'btnRClockwise
        '
        Me.btnRClockwise.BackColor = System.Drawing.Color.Transparent
        Me.btnRClockwise.BackgroundImage = Global.LaserSolder.My.Resources.Resources.feedadd
        Me.btnRClockwise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnRClockwise.FlatAppearance.BorderSize = 0
        Me.btnRClockwise.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRClockwise.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRClockwise.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRClockwise.Location = New System.Drawing.Point(10, 92)
        Me.btnRClockwise.Margin = New System.Windows.Forms.Padding(10, 0, 0, 0)
        Me.btnRClockwise.Name = "btnRClockwise"
        Me.btnRClockwise.Size = New System.Drawing.Size(50, 46)
        Me.btnRClockwise.TabIndex = 18
        Me.btnRClockwise.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel3.Controls.Add(Me.btnZUp, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label9, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.btnZDown, 0, 2)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(219, 53)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 3
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(55, 145)
        Me.TableLayoutPanel3.TabIndex = 32
        '
        'btnZUp
        '
        Me.btnZUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnZUp.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnZUp.Direction = LaserSolder.eArrow.Up
        Me.btnZUp.FlatAppearance.BorderSize = 0
        Me.btnZUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnZUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZUp.ForeColor = System.Drawing.SystemColors.Control
        Me.btnZUp.Location = New System.Drawing.Point(0, 0)
        Me.btnZUp.Margin = New System.Windows.Forms.Padding(0)
        Me.btnZUp.Name = "btnZUp"
        Me.btnZUp.Radius = 1.0!
        Me.btnZUp.Size = New System.Drawing.Size(50, 46)
        Me.btnZUp.TabIndex = 24
        Me.btnZUp.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label9.Location = New System.Drawing.Point(3, 46)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 46)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Z"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZDown
        '
        Me.btnZDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnZDown.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnZDown.Direction = LaserSolder.eArrow.Down
        Me.btnZDown.FlatAppearance.BorderSize = 0
        Me.btnZDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnZDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnZDown.Location = New System.Drawing.Point(0, 92)
        Me.btnZDown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnZDown.Name = "btnZDown"
        Me.btnZDown.Radius = 1.0!
        Me.btnZDown.Size = New System.Drawing.Size(50, 46)
        Me.btnZDown.TabIndex = 24
        Me.btnZDown.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.btnXYUp, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnXYLeft, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnXYRight, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label8, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.btnXYDown, 1, 2)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(26, 53)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(153, 145)
        Me.TableLayoutPanel2.TabIndex = 30
        '
        'btnXYUp
        '
        Me.btnXYUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnXYUp.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnXYUp.Direction = LaserSolder.eArrow.Up
        Me.btnXYUp.FlatAppearance.BorderSize = 0
        Me.btnXYUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnXYUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXYUp.ForeColor = System.Drawing.SystemColors.Control
        Me.btnXYUp.Location = New System.Drawing.Point(50, 0)
        Me.btnXYUp.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXYUp.Name = "btnXYUp"
        Me.btnXYUp.Radius = 1.0!
        Me.btnXYUp.Size = New System.Drawing.Size(50, 46)
        Me.btnXYUp.TabIndex = 24
        Me.btnXYUp.UseVisualStyleBackColor = False
        '
        'btnXYLeft
        '
        Me.btnXYLeft.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnXYLeft.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnXYLeft.Direction = LaserSolder.eArrow.Left
        Me.btnXYLeft.FlatAppearance.BorderSize = 0
        Me.btnXYLeft.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnXYLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXYLeft.Location = New System.Drawing.Point(0, 46)
        Me.btnXYLeft.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXYLeft.Name = "btnXYLeft"
        Me.btnXYLeft.Radius = 1.0!
        Me.btnXYLeft.Size = New System.Drawing.Size(50, 46)
        Me.btnXYLeft.TabIndex = 24
        Me.btnXYLeft.UseVisualStyleBackColor = False
        '
        'btnXYRight
        '
        Me.btnXYRight.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnXYRight.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnXYRight.Direction = LaserSolder.eArrow.Right
        Me.btnXYRight.FlatAppearance.BorderSize = 0
        Me.btnXYRight.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnXYRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXYRight.Location = New System.Drawing.Point(100, 46)
        Me.btnXYRight.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXYRight.Name = "btnXYRight"
        Me.btnXYRight.Radius = 1.0!
        Me.btnXYRight.Size = New System.Drawing.Size(50, 46)
        Me.btnXYRight.TabIndex = 24
        Me.btnXYRight.UseVisualStyleBackColor = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Label8.Location = New System.Drawing.Point(53, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(44, 46)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "XY"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnXYDown
        '
        Me.btnXYDown.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.btnXYDown.ButtonType = LaserSolder.eButtonType.Arrow
        Me.btnXYDown.Direction = LaserSolder.eArrow.Down
        Me.btnXYDown.FlatAppearance.BorderSize = 0
        Me.btnXYDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.SkyBlue
        Me.btnXYDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnXYDown.Location = New System.Drawing.Point(50, 92)
        Me.btnXYDown.Margin = New System.Windows.Forms.Padding(0)
        Me.btnXYDown.Name = "btnXYDown"
        Me.btnXYDown.Radius = 1.0!
        Me.btnXYDown.Size = New System.Drawing.Size(50, 46)
        Me.btnXYDown.TabIndex = 24
        Me.btnXYDown.UseVisualStyleBackColor = False
        '
        'txtSpeed
        '
        Me.txtSpeed.BackColor = System.Drawing.Color.White
        Me.txtSpeed.ForeColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(148, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.txtSpeed.Location = New System.Drawing.Point(442, 6)
        Me.txtSpeed.Name = "txtSpeed"
        Me.txtSpeed.Size = New System.Drawing.Size(81, 29)
        Me.txtSpeed.TabIndex = 29
        Me.txtSpeed.Text = "30"
        '
        'TrackBarSpeed
        '
        Me.TrackBarSpeed.Location = New System.Drawing.Point(83, 8)
        Me.TrackBarSpeed.Maximum = 100
        Me.TrackBarSpeed.Name = "TrackBarSpeed"
        Me.TrackBarSpeed.Size = New System.Drawing.Size(316, 45)
        Me.TrackBarSpeed.TabIndex = 28
        Me.TrackBarSpeed.TickFrequency = 0
        Me.TrackBarSpeed.TickStyle = System.Windows.Forms.TickStyle.None
        Me.TrackBarSpeed.Value = 30
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(87, Byte), Integer), CType(CType(111, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(6, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(71, 24)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Speed"
        '
        'btnClose
        '
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.Image = Global.LaserSolder.My.Resources.Resources.cancel
        Me.btnClose.Location = New System.Drawing.Point(214, 274)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(151, 54)
        Me.btnClose.TabIndex = 1
        Me.btnClose.Text = "     Close"
        Me.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FJog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(571, 339)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximumSize = New System.Drawing.Size(577, 368)
        Me.MinimumSize = New System.Drawing.Size(577, 368)
        Me.Name = "FJog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "JOG"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBoxEx1.ResumeLayout(False)
        Me.GroupBoxEx1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        CType(Me.TrackBarSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBoxEx1 As LaserSolder.GroupBoxEx
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents btnRCounterClockwise As System.Windows.Forms.Button
    Friend WithEvents btnRClockwise As System.Windows.Forms.Button
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnZUp As LaserSolder.ButtonEx
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnZDown As LaserSolder.ButtonEx
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnXYUp As LaserSolder.ButtonEx
    Friend WithEvents btnXYLeft As LaserSolder.ButtonEx
    Friend WithEvents btnXYRight As LaserSolder.ButtonEx
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnXYDown As LaserSolder.ButtonEx
    Friend WithEvents txtSpeed As System.Windows.Forms.TextBox
    Friend WithEvents TrackBarSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnFeedCounterClockwise As System.Windows.Forms.Button
    Friend WithEvents btnFeedClockwise As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
End Class
