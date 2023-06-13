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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboPortName = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnOpen = New System.Windows.Forms.Button()
        Me.cboParity = New System.Windows.Forms.ComboBox()
        Me.cboStopBit = New System.Windows.Forms.ComboBox()
        Me.cboDataBit = New System.Windows.Forms.ComboBox()
        Me.cboBaudrate = New System.Windows.Forms.ComboBox()
        Me.lbReceivedData = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtPeakMin = New System.Windows.Forms.TextBox()
        Me.txtPeakMax = New System.Windows.Forms.TextBox()
        Me.txtPeakDown = New System.Windows.Forms.TextBox()
        Me.txtPeakUp = New System.Windows.Forms.TextBox()
        Me.chkRecord = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 39)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Port Name"
        '
        'cboPortName
        '
        Me.cboPortName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPortName.FormattingEnabled = True
        Me.cboPortName.Location = New System.Drawing.Point(105, 36)
        Me.cboPortName.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboPortName.Name = "cboPortName"
        Me.cboPortName.Size = New System.Drawing.Size(134, 28)
        Me.cboPortName.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 78)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 20)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Baudrate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 117)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 20)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "DataBit"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 193)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 20)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "StopBit"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 155)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 20)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Parity"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnOpen)
        Me.GroupBox1.Controls.Add(Me.cboParity)
        Me.GroupBox1.Controls.Add(Me.cboStopBit)
        Me.GroupBox1.Controls.Add(Me.cboDataBit)
        Me.GroupBox1.Controls.Add(Me.cboBaudrate)
        Me.GroupBox1.Controls.Add(Me.cboPortName)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 462)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Serial configuration"
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(143, 238)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(87, 41)
        Me.btnClose.TabIndex = 2
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnOpen
        '
        Me.btnOpen.Location = New System.Drawing.Point(26, 238)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(87, 41)
        Me.btnOpen.TabIndex = 2
        Me.btnOpen.Text = "Open"
        Me.btnOpen.UseVisualStyleBackColor = True
        '
        'cboParity
        '
        Me.cboParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboParity.FormattingEnabled = True
        Me.cboParity.Location = New System.Drawing.Point(105, 152)
        Me.cboParity.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboParity.Name = "cboParity"
        Me.cboParity.Size = New System.Drawing.Size(134, 28)
        Me.cboParity.TabIndex = 1
        '
        'cboStopBit
        '
        Me.cboStopBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStopBit.FormattingEnabled = True
        Me.cboStopBit.Location = New System.Drawing.Point(105, 190)
        Me.cboStopBit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboStopBit.Name = "cboStopBit"
        Me.cboStopBit.Size = New System.Drawing.Size(134, 28)
        Me.cboStopBit.TabIndex = 1
        '
        'cboDataBit
        '
        Me.cboDataBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDataBit.FormattingEnabled = True
        Me.cboDataBit.Location = New System.Drawing.Point(105, 114)
        Me.cboDataBit.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboDataBit.Name = "cboDataBit"
        Me.cboDataBit.Size = New System.Drawing.Size(134, 28)
        Me.cboDataBit.TabIndex = 1
        '
        'cboBaudrate
        '
        Me.cboBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBaudrate.FormattingEnabled = True
        Me.cboBaudrate.Location = New System.Drawing.Point(105, 75)
        Me.cboBaudrate.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.cboBaudrate.Name = "cboBaudrate"
        Me.cboBaudrate.Size = New System.Drawing.Size(134, 28)
        Me.cboBaudrate.TabIndex = 1
        '
        'lbReceivedData
        '
        Me.lbReceivedData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbReceivedData.FormattingEnabled = True
        Me.lbReceivedData.ItemHeight = 20
        Me.lbReceivedData.Location = New System.Drawing.Point(11, 28)
        Me.lbReceivedData.Name = "lbReceivedData"
        Me.lbReceivedData.Size = New System.Drawing.Size(249, 424)
        Me.lbReceivedData.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.lbReceivedData)
        Me.GroupBox2.Location = New System.Drawing.Point(553, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 462)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Received Data"
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.txtPeakMin)
        Me.GroupBox3.Controls.Add(Me.txtPeakMax)
        Me.GroupBox3.Controls.Add(Me.txtPeakDown)
        Me.GroupBox3.Controls.Add(Me.txtPeakUp)
        Me.GroupBox3.Controls.Add(Me.chkRecord)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Location = New System.Drawing.Point(281, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(266, 462)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'txtPeakMin
        '
        Me.txtPeakMin.BackColor = System.Drawing.Color.White
        Me.txtPeakMin.Location = New System.Drawing.Point(118, 157)
        Me.txtPeakMin.Name = "txtPeakMin"
        Me.txtPeakMin.ReadOnly = True
        Me.txtPeakMin.Size = New System.Drawing.Size(119, 26)
        Me.txtPeakMin.TabIndex = 2
        Me.txtPeakMin.Text = "0"
        '
        'txtPeakMax
        '
        Me.txtPeakMax.BackColor = System.Drawing.Color.White
        Me.txtPeakMax.Location = New System.Drawing.Point(118, 119)
        Me.txtPeakMax.Name = "txtPeakMax"
        Me.txtPeakMax.ReadOnly = True
        Me.txtPeakMax.Size = New System.Drawing.Size(119, 26)
        Me.txtPeakMax.TabIndex = 2
        Me.txtPeakMax.Text = "0"
        '
        'txtPeakDown
        '
        Me.txtPeakDown.BackColor = System.Drawing.Color.White
        Me.txtPeakDown.Location = New System.Drawing.Point(118, 72)
        Me.txtPeakDown.Name = "txtPeakDown"
        Me.txtPeakDown.ReadOnly = True
        Me.txtPeakDown.Size = New System.Drawing.Size(119, 26)
        Me.txtPeakDown.TabIndex = 2
        '
        'txtPeakUp
        '
        Me.txtPeakUp.BackColor = System.Drawing.Color.White
        Me.txtPeakUp.Location = New System.Drawing.Point(118, 33)
        Me.txtPeakUp.Name = "txtPeakUp"
        Me.txtPeakUp.ReadOnly = True
        Me.txtPeakUp.Size = New System.Drawing.Size(119, 26)
        Me.txtPeakUp.TabIndex = 2
        '
        'chkRecord
        '
        Me.chkRecord.AutoSize = True
        Me.chkRecord.Location = New System.Drawing.Point(17, 194)
        Me.chkRecord.Name = "chkRecord"
        Me.chkRecord.Size = New System.Drawing.Size(80, 24)
        Me.chkRecord.TabIndex = 1
        Me.chkRecord.Text = "Record"
        Me.chkRecord.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 160)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 20)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Peak Min:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 20)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Peak Max:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(93, 20)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "- Peak Now:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 36)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 20)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "+ Peak Now:"
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 486)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "FMain"
        Me.Text = "R232 communication"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPortName As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents cboParity As System.Windows.Forms.ComboBox
    Friend WithEvents cboStopBit As System.Windows.Forms.ComboBox
    Friend WithEvents cboDataBit As System.Windows.Forms.ComboBox
    Friend WithEvents cboBaudrate As System.Windows.Forms.ComboBox
    Friend WithEvents lbReceivedData As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkRecord As System.Windows.Forms.CheckBox
    Friend WithEvents txtPeakMin As System.Windows.Forms.TextBox
    Friend WithEvents txtPeakMax As System.Windows.Forms.TextBox
    Friend WithEvents txtPeakDown As System.Windows.Forms.TextBox
    Friend WithEvents txtPeakUp As System.Windows.Forms.TextBox

End Class
