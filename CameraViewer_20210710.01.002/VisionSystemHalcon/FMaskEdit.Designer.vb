<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FMaskEdit
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.rbBrushDisable = New System.Windows.Forms.RadioButton
        Me.rbBrushEnable = New System.Windows.Forms.RadioButton
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.rbBrushSize1x1 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize3x3 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize5x5 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize9x9 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize13x13 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize19x19 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize41x41 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize51x51 = New System.Windows.Forms.RadioButton
        Me.rbBrushRectangle = New System.Windows.Forms.RadioButton
        Me.rbBrushCircle = New System.Windows.Forms.RadioButton
        Me.rbBrushSize25x25 = New System.Windows.Forms.RadioButton
        Me.rbBrushSize33x33 = New System.Windows.Forms.RadioButton
        Me.btnApply = New System.Windows.Forms.Button
        Me.btnExist = New System.Windows.Forms.Button
        Me.btnDefault = New System.Windows.Forms.Button
        Me.ImageDisplay = New VisionSystem.ImageDisplay
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox2.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(626, 439)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(110, 82)
        Me.GroupBox2.TabIndex = 12
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "遮罩功能"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.rbBrushDisable, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.rbBrushEnable, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(9, 16)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(95, 59)
        Me.TableLayoutPanel3.TabIndex = 9
        '
        'rbBrushDisable
        '
        Me.rbBrushDisable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbBrushDisable.Checked = True
        Me.rbBrushDisable.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBrushDisable.Location = New System.Drawing.Point(7, 3)
        Me.rbBrushDisable.Name = "rbBrushDisable"
        Me.rbBrushDisable.Size = New System.Drawing.Size(80, 20)
        Me.rbBrushDisable.TabIndex = 0
        Me.rbBrushDisable.TabStop = True
        Me.rbBrushDisable.Text = "忽略特徵"
        Me.rbBrushDisable.UseVisualStyleBackColor = True
        '
        'rbBrushEnable
        '
        Me.rbBrushEnable.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.rbBrushEnable.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBrushEnable.Location = New System.Drawing.Point(7, 32)
        Me.rbBrushEnable.Name = "rbBrushEnable"
        Me.rbBrushEnable.Size = New System.Drawing.Size(80, 20)
        Me.rbBrushEnable.TabIndex = 0
        Me.rbBrushEnable.Text = "計算特徵"
        Me.rbBrushEnable.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.DarkSlateGray
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox1.Font = New System.Drawing.Font("Comic Sans MS", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(9, 447)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 74)
        Me.GroupBox1.TabIndex = 11
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "遮罩工具"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 6
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize1x1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize3x3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize5x5, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize9x9, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize13x13, 4, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize19x19, 5, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize41x41, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize51x51, 3, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushRectangle, 4, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushCircle, 5, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize25x25, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.rbBrushSize33x33, 1, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 17)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(584, 50)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'rbBrushSize1x1
        '
        Me.rbBrushSize1x1.Checked = True
        Me.rbBrushSize1x1.Location = New System.Drawing.Point(1, 1)
        Me.rbBrushSize1x1.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize1x1.Name = "rbBrushSize1x1"
        Me.rbBrushSize1x1.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize1x1.TabIndex = 0
        Me.rbBrushSize1x1.TabStop = True
        Me.rbBrushSize1x1.Text = "筆刷 1x1"
        Me.rbBrushSize1x1.UseVisualStyleBackColor = True
        '
        'rbBrushSize3x3
        '
        Me.rbBrushSize3x3.Location = New System.Drawing.Point(97, 1)
        Me.rbBrushSize3x3.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize3x3.Name = "rbBrushSize3x3"
        Me.rbBrushSize3x3.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize3x3.TabIndex = 0
        Me.rbBrushSize3x3.Text = "筆刷 3x3"
        Me.rbBrushSize3x3.UseVisualStyleBackColor = True
        '
        'rbBrushSize5x5
        '
        Me.rbBrushSize5x5.Location = New System.Drawing.Point(193, 1)
        Me.rbBrushSize5x5.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize5x5.Name = "rbBrushSize5x5"
        Me.rbBrushSize5x5.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize5x5.TabIndex = 0
        Me.rbBrushSize5x5.Text = "筆刷 5x5"
        Me.rbBrushSize5x5.UseVisualStyleBackColor = True
        '
        'rbBrushSize9x9
        '
        Me.rbBrushSize9x9.Location = New System.Drawing.Point(289, 1)
        Me.rbBrushSize9x9.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize9x9.Name = "rbBrushSize9x9"
        Me.rbBrushSize9x9.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize9x9.TabIndex = 0
        Me.rbBrushSize9x9.Text = "筆刷 9x9"
        Me.rbBrushSize9x9.UseVisualStyleBackColor = True
        '
        'rbBrushSize13x13
        '
        Me.rbBrushSize13x13.Location = New System.Drawing.Point(385, 1)
        Me.rbBrushSize13x13.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize13x13.Name = "rbBrushSize13x13"
        Me.rbBrushSize13x13.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize13x13.TabIndex = 0
        Me.rbBrushSize13x13.Text = "筆刷 13x13"
        Me.rbBrushSize13x13.UseVisualStyleBackColor = True
        '
        'rbBrushSize19x19
        '
        Me.rbBrushSize19x19.AccessibleDescription = ""
        Me.rbBrushSize19x19.Location = New System.Drawing.Point(481, 1)
        Me.rbBrushSize19x19.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize19x19.Name = "rbBrushSize19x19"
        Me.rbBrushSize19x19.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize19x19.TabIndex = 0
        Me.rbBrushSize19x19.Text = "筆刷 19x19"
        Me.rbBrushSize19x19.UseVisualStyleBackColor = True
        '
        'rbBrushSize41x41
        '
        Me.rbBrushSize41x41.Location = New System.Drawing.Point(193, 23)
        Me.rbBrushSize41x41.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize41x41.Name = "rbBrushSize41x41"
        Me.rbBrushSize41x41.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize41x41.TabIndex = 0
        Me.rbBrushSize41x41.Text = "筆刷 41x41"
        Me.rbBrushSize41x41.UseVisualStyleBackColor = True
        '
        'rbBrushSize51x51
        '
        Me.rbBrushSize51x51.Location = New System.Drawing.Point(289, 23)
        Me.rbBrushSize51x51.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize51x51.Name = "rbBrushSize51x51"
        Me.rbBrushSize51x51.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize51x51.TabIndex = 0
        Me.rbBrushSize51x51.Text = "筆刷 51x51"
        Me.rbBrushSize51x51.UseVisualStyleBackColor = True
        '
        'rbBrushRectangle
        '
        Me.rbBrushRectangle.Location = New System.Drawing.Point(385, 23)
        Me.rbBrushRectangle.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushRectangle.Name = "rbBrushRectangle"
        Me.rbBrushRectangle.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushRectangle.TabIndex = 0
        Me.rbBrushRectangle.Text = "方形"
        Me.rbBrushRectangle.UseVisualStyleBackColor = True
        '
        'rbBrushCircle
        '
        Me.rbBrushCircle.Location = New System.Drawing.Point(481, 23)
        Me.rbBrushCircle.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushCircle.Name = "rbBrushCircle"
        Me.rbBrushCircle.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushCircle.TabIndex = 0
        Me.rbBrushCircle.Text = "圓形"
        Me.rbBrushCircle.UseVisualStyleBackColor = True
        '
        'rbBrushSize25x25
        '
        Me.rbBrushSize25x25.Location = New System.Drawing.Point(1, 23)
        Me.rbBrushSize25x25.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize25x25.Name = "rbBrushSize25x25"
        Me.rbBrushSize25x25.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize25x25.TabIndex = 0
        Me.rbBrushSize25x25.Text = "筆刷 33x33"
        Me.rbBrushSize25x25.UseVisualStyleBackColor = True
        '
        'rbBrushSize33x33
        '
        Me.rbBrushSize33x33.Location = New System.Drawing.Point(97, 23)
        Me.rbBrushSize33x33.Margin = New System.Windows.Forms.Padding(1)
        Me.rbBrushSize33x33.Name = "rbBrushSize33x33"
        Me.rbBrushSize33x33.Size = New System.Drawing.Size(94, 20)
        Me.rbBrushSize33x33.TabIndex = 0
        Me.rbBrushSize33x33.Text = "筆刷 25x25"
        Me.rbBrushSize33x33.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApply.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApply.ForeColor = System.Drawing.Color.White
        Me.btnApply.Location = New System.Drawing.Point(503, 527)
        Me.btnApply.Name = "btnApply"
        Me.btnApply.Size = New System.Drawing.Size(139, 37)
        Me.btnApply.TabIndex = 13
        Me.btnApply.Text = "設定"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'btnExist
        '
        Me.btnExist.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExist.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExist.ForeColor = System.Drawing.Color.White
        Me.btnExist.Location = New System.Drawing.Point(646, 527)
        Me.btnExist.Name = "btnExist"
        Me.btnExist.Size = New System.Drawing.Size(139, 37)
        Me.btnExist.TabIndex = 13
        Me.btnExist.Text = "離開"
        Me.btnExist.UseVisualStyleBackColor = True
        '
        'btnDefault
        '
        Me.btnDefault.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDefault.Font = New System.Drawing.Font("Comic Sans MS", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDefault.ForeColor = System.Drawing.Color.White
        Me.btnDefault.Location = New System.Drawing.Point(358, 527)
        Me.btnDefault.Name = "btnDefault"
        Me.btnDefault.Size = New System.Drawing.Size(139, 37)
        Me.btnDefault.TabIndex = 13
        Me.btnDefault.Text = "預設值"
        Me.btnDefault.UseVisualStyleBackColor = True
        '
        'ImageDisplay
        '
        Me.ImageDisplay.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageDisplay.BackColor = System.Drawing.Color.Maroon
        Me.ImageDisplay.Location = New System.Drawing.Point(9, 9)
        Me.ImageDisplay.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageDisplay.Name = "ImageDisplay"
        Me.ImageDisplay.Size = New System.Drawing.Size(776, 427)
        Me.ImageDisplay.TabIndex = 1
        '
        'FMaskEdit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(794, 576)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExist)
        Me.Controls.Add(Me.btnDefault)
        Me.Controls.Add(Me.btnApply)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.ImageDisplay)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FMaskEdit"
        Me.Text = "FMaskEdit"
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageDisplay As VisionSystem.ImageDisplay
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbBrushDisable As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushEnable As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents rbBrushSize1x1 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize33x33 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize3x3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize5x5 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize9x9 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize13x13 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize19x19 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize25x25 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize41x41 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushSize51x51 As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushRectangle As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrushCircle As System.Windows.Forms.RadioButton
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents btnExist As System.Windows.Forms.Button
    Friend WithEvents btnDefault As System.Windows.Forms.Button
End Class
