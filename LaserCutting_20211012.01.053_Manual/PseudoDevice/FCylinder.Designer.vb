<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCylinder
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
        Me.btnExist = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.gbDeviceConfigure = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel
        Me.numAlarmTime = New System.Windows.Forms.NumericUpDown
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.numNormalNormalTime = New System.Windows.Forms.NumericUpDown
        Me.numNormalActionTime = New System.Windows.Forms.NumericUpDown
        Me.numActionNormalTime = New System.Windows.Forms.NumericUpDown
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel
        Me.cmbNormalBitID = New System.Windows.Forms.ComboBox
        Me.cmbNormalCardID = New System.Windows.Forms.ComboBox
        Me.cmbNormalSlaveID = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbNormalSnrID = New System.Windows.Forms.ComboBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.cmbActionBitID = New System.Windows.Forms.ComboBox
        Me.cmbActionCardID = New System.Windows.Forms.ComboBox
        Me.cmbActionSlaveID = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.cmbActionSnrID = New System.Windows.Forms.ComboBox
        Me.gbDeviceConfigure.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.numAlarmTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNormalNormalTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numNormalActionTime, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numActionNormalTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnExist
        '
        Me.btnExist.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnExist.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExist.ForeColor = System.Drawing.Color.White
        Me.btnExist.Location = New System.Drawing.Point(338, 284)
        Me.btnExist.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.btnExist.Name = "btnExist"
        Me.btnExist.Size = New System.Drawing.Size(109, 40)
        Me.btnExist.TabIndex = 34
        Me.btnExist.Text = "Exist"
        Me.btnExist.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(218, 284)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 40)
        Me.btnSave.TabIndex = 33
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'gbDeviceConfigure
        '
        Me.gbDeviceConfigure.Controls.Add(Me.GroupBox3)
        Me.gbDeviceConfigure.Controls.Add(Me.GroupBox2)
        Me.gbDeviceConfigure.Controls.Add(Me.GroupBox1)
        Me.gbDeviceConfigure.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDeviceConfigure.ForeColor = System.Drawing.Color.White
        Me.gbDeviceConfigure.Location = New System.Drawing.Point(5, 5)
        Me.gbDeviceConfigure.Name = "gbDeviceConfigure"
        Me.gbDeviceConfigure.Size = New System.Drawing.Size(442, 275)
        Me.gbDeviceConfigure.TabIndex = 32
        Me.gbDeviceConfigure.TabStop = False
        Me.gbDeviceConfigure.Text = "Device Configure CylinderName"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel3)
        Me.GroupBox3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox3.ForeColor = System.Drawing.Color.White
        Me.GroupBox3.Location = New System.Drawing.Point(6, 190)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(430, 80)
        Me.GroupBox3.TabIndex = 38
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Setting Time miniSecond"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 4
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel3.Controls.Add(Me.numAlarmTime, 3, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Label12, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label13, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label14, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Label15, 3, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.numNormalNormalTime, 2, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.numNormalActionTime, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.numActionNormalTime, 0, 1)
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(419, 55)
        Me.TableLayoutPanel3.TabIndex = 28
        '
        'numAlarmTime
        '
        Me.numAlarmTime.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numAlarmTime.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numAlarmTime.ForeColor = System.Drawing.Color.White
        Me.numAlarmTime.Location = New System.Drawing.Point(336, 25)
        Me.numAlarmTime.Margin = New System.Windows.Forms.Padding(0)
        Me.numAlarmTime.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.numAlarmTime.Name = "numAlarmTime"
        Me.numAlarmTime.Size = New System.Drawing.Size(79, 29)
        Me.numAlarmTime.TabIndex = 35
        Me.numAlarmTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label12.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label12.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(109, 0)
        Me.Label12.Margin = New System.Windows.Forms.Padding(0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(109, 25)
        Me.Label12.TabIndex = 3
        Me.Label12.Text = "NormalAction"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label13
        '
        Me.Label13.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label13.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label13.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(218, 0)
        Me.Label13.Margin = New System.Windows.Forms.Padding(0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(118, 25)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "NormalNormal"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label14
        '
        Me.Label14.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label14.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label14.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(0, 0)
        Me.Label14.Margin = New System.Windows.Forms.Padding(0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(109, 25)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "ActionNormal"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label15
        '
        Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label15.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label15.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(336, 0)
        Me.Label15.Margin = New System.Windows.Forms.Padding(0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 25)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Alarm"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'numNormalNormalTime
        '
        Me.numNormalNormalTime.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numNormalNormalTime.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numNormalNormalTime.ForeColor = System.Drawing.Color.White
        Me.numNormalNormalTime.Location = New System.Drawing.Point(218, 25)
        Me.numNormalNormalTime.Margin = New System.Windows.Forms.Padding(0)
        Me.numNormalNormalTime.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.numNormalNormalTime.Name = "numNormalNormalTime"
        Me.numNormalNormalTime.Size = New System.Drawing.Size(118, 29)
        Me.numNormalNormalTime.TabIndex = 35
        Me.numNormalNormalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numNormalActionTime
        '
        Me.numNormalActionTime.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numNormalActionTime.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numNormalActionTime.ForeColor = System.Drawing.Color.White
        Me.numNormalActionTime.Location = New System.Drawing.Point(109, 25)
        Me.numNormalActionTime.Margin = New System.Windows.Forms.Padding(0)
        Me.numNormalActionTime.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.numNormalActionTime.Name = "numNormalActionTime"
        Me.numNormalActionTime.Size = New System.Drawing.Size(109, 29)
        Me.numNormalActionTime.TabIndex = 35
        Me.numNormalActionTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'numActionNormalTime
        '
        Me.numActionNormalTime.BackColor = System.Drawing.Color.DarkSlateGray
        Me.numActionNormalTime.Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.numActionNormalTime.ForeColor = System.Drawing.Color.White
        Me.numActionNormalTime.Location = New System.Drawing.Point(0, 25)
        Me.numActionNormalTime.Margin = New System.Windows.Forms.Padding(0)
        Me.numActionNormalTime.Maximum = New Decimal(New Integer() {50000, 0, 0, 0})
        Me.numActionNormalTime.Name = "numActionNormalTime"
        Me.numActionNormalTime.Size = New System.Drawing.Size(109, 29)
        Me.numActionNormalTime.TabIndex = 35
        Me.numActionNormalTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TableLayoutPanel2)
        Me.GroupBox2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.ForeColor = System.Drawing.Color.White
        Me.GroupBox2.Location = New System.Drawing.Point(6, 106)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(430, 80)
        Me.GroupBox2.TabIndex = 37
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Normal"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbNormalBitID, 2, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbNormalCardID, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbNormalSlaveID, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label7, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.cmbNormalSnrID, 3, 1)
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(419, 55)
        Me.TableLayoutPanel2.TabIndex = 28
        '
        'cmbNormalBitID
        '
        Me.cmbNormalBitID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbNormalBitID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNormalBitID.ForeColor = System.Drawing.Color.White
        Me.cmbNormalBitID.FormattingEnabled = True
        Me.cmbNormalBitID.Location = New System.Drawing.Point(190, 25)
        Me.cmbNormalBitID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbNormalBitID.Name = "cmbNormalBitID"
        Me.cmbNormalBitID.Size = New System.Drawing.Size(95, 27)
        Me.cmbNormalBitID.TabIndex = 6
        '
        'cmbNormalCardID
        '
        Me.cmbNormalCardID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbNormalCardID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNormalCardID.ForeColor = System.Drawing.Color.White
        Me.cmbNormalCardID.FormattingEnabled = True
        Me.cmbNormalCardID.Location = New System.Drawing.Point(0, 25)
        Me.cmbNormalCardID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbNormalCardID.Name = "cmbNormalCardID"
        Me.cmbNormalCardID.Size = New System.Drawing.Size(95, 27)
        Me.cmbNormalCardID.TabIndex = 7
        '
        'cmbNormalSlaveID
        '
        Me.cmbNormalSlaveID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbNormalSlaveID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNormalSlaveID.ForeColor = System.Drawing.Color.White
        Me.cmbNormalSlaveID.FormattingEnabled = True
        Me.cmbNormalSlaveID.Location = New System.Drawing.Point(95, 25)
        Me.cmbNormalSlaveID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbNormalSlaveID.Name = "cmbNormalSlaveID"
        Me.cmbNormalSlaveID.Size = New System.Drawing.Size(95, 27)
        Me.cmbNormalSlaveID.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(95, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(95, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Slave ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(190, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(95, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Bit ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(95, 25)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Card ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label7.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(285, 0)
        Me.Label7.Margin = New System.Windows.Forms.Padding(0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 25)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Sensor ID"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbNormalSnrID
        '
        Me.cmbNormalSnrID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbNormalSnrID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNormalSnrID.ForeColor = System.Drawing.Color.White
        Me.cmbNormalSnrID.FormattingEnabled = True
        Me.cmbNormalSnrID.Location = New System.Drawing.Point(285, 25)
        Me.cmbNormalSnrID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbNormalSnrID.Name = "cmbNormalSnrID"
        Me.cmbNormalSnrID.Size = New System.Drawing.Size(134, 27)
        Me.cmbNormalSnrID.TabIndex = 6
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel1)
        Me.GroupBox1.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(6, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(430, 80)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Action"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbActionBitID, 2, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbActionCardID, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbActionSlaveID, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label5, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label6, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label8, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.cmbActionSnrID, 3, 1)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle)
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(419, 55)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'cmbActionBitID
        '
        Me.cmbActionBitID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbActionBitID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActionBitID.ForeColor = System.Drawing.Color.White
        Me.cmbActionBitID.FormattingEnabled = True
        Me.cmbActionBitID.Location = New System.Drawing.Point(190, 25)
        Me.cmbActionBitID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbActionBitID.Name = "cmbActionBitID"
        Me.cmbActionBitID.Size = New System.Drawing.Size(95, 27)
        Me.cmbActionBitID.TabIndex = 6
        '
        'cmbActionCardID
        '
        Me.cmbActionCardID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbActionCardID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActionCardID.ForeColor = System.Drawing.Color.White
        Me.cmbActionCardID.FormattingEnabled = True
        Me.cmbActionCardID.Location = New System.Drawing.Point(0, 25)
        Me.cmbActionCardID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbActionCardID.Name = "cmbActionCardID"
        Me.cmbActionCardID.Size = New System.Drawing.Size(95, 27)
        Me.cmbActionCardID.TabIndex = 7
        '
        'cmbActionSlaveID
        '
        Me.cmbActionSlaveID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbActionSlaveID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActionSlaveID.ForeColor = System.Drawing.Color.White
        Me.cmbActionSlaveID.FormattingEnabled = True
        Me.cmbActionSlaveID.Location = New System.Drawing.Point(95, 25)
        Me.cmbActionSlaveID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbActionSlaveID.Name = "cmbActionSlaveID"
        Me.cmbActionSlaveID.Size = New System.Drawing.Size(95, 27)
        Me.cmbActionSlaveID.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label2.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(95, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 25)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Slave ID"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label5.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(190, 0)
        Me.Label5.Margin = New System.Windows.Forms.Padding(0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 25)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Bit ID"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label6.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(0, 0)
        Me.Label6.Margin = New System.Windows.Forms.Padding(0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(95, 25)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Card ID"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label8
        '
        Me.Label8.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label8.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(285, 0)
        Me.Label8.Margin = New System.Windows.Forms.Padding(0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 25)
        Me.Label8.TabIndex = 4
        Me.Label8.Text = "Sensor ID"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmbActionSnrID
        '
        Me.cmbActionSnrID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbActionSnrID.Font = New System.Drawing.Font("Calibri", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbActionSnrID.ForeColor = System.Drawing.Color.White
        Me.cmbActionSnrID.FormattingEnabled = True
        Me.cmbActionSnrID.Location = New System.Drawing.Point(285, 25)
        Me.cmbActionSnrID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbActionSnrID.Name = "cmbActionSnrID"
        Me.cmbActionSnrID.Size = New System.Drawing.Size(134, 27)
        Me.cmbActionSnrID.TabIndex = 6
        '
        'FCylinder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(451, 331)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExist)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbDeviceConfigure)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FCylinder"
        Me.Text = "Digital Ouput Device "
        Me.gbDeviceConfigure.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.numAlarmTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNormalNormalTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numNormalActionTime, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numActionNormalTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnExist As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents gbDeviceConfigure As System.Windows.Forms.GroupBox
    Friend WithEvents numAlarmTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel3 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbNormalBitID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNormalCardID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNormalSlaveID As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbNormalSnrID As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbActionBitID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbActionCardID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbActionSlaveID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbActionSnrID As System.Windows.Forms.ComboBox
    Friend WithEvents numNormalNormalTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents numNormalActionTime As System.Windows.Forms.NumericUpDown
    Friend WithEvents numActionNormalTime As System.Windows.Forms.NumericUpDown
End Class
