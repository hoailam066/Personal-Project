<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FSensor
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
        Me.gbDeviceConfigure = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.chkLogic = New System.Windows.Forms.CheckBox()
        Me.cmbBitID = New System.Windows.Forms.ComboBox()
        Me.cmbCardID = New System.Windows.Forms.ComboBox()
        Me.cmbSlaveID = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnExist = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.gbDeviceConfigure.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbDeviceConfigure
        '
        Me.gbDeviceConfigure.Controls.Add(Me.TableLayoutPanel4)
        Me.gbDeviceConfigure.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDeviceConfigure.ForeColor = System.Drawing.Color.White
        Me.gbDeviceConfigure.Location = New System.Drawing.Point(5, 5)
        Me.gbDeviceConfigure.Name = "gbDeviceConfigure"
        Me.gbDeviceConfigure.Size = New System.Drawing.Size(340, 108)
        Me.gbDeviceConfigure.TabIndex = 24
        Me.gbDeviceConfigure.TabStop = False
        Me.gbDeviceConfigure.Text = "Device Configure SensorName"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 3
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel4.Controls.Add(Me.chkLogic, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbBitID, 2, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbCardID, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.cmbSlaveID, 1, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label3, 1, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label4, 2, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(6, 20)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 3
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(330, 82)
        Me.TableLayoutPanel4.TabIndex = 28
        '
        'chkLogic
        '
        Me.TableLayoutPanel4.SetColumnSpan(Me.chkLogic, 3)
        Me.chkLogic.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkLogic.ForeColor = System.Drawing.Color.White
        Me.chkLogic.Location = New System.Drawing.Point(0, 48)
        Me.chkLogic.Margin = New System.Windows.Forms.Padding(0)
        Me.chkLogic.Name = "chkLogic"
        Me.chkLogic.Size = New System.Drawing.Size(326, 24)
        Me.chkLogic.TabIndex = 8
        Me.chkLogic.Text = "High Active"
        Me.chkLogic.UseVisualStyleBackColor = True
        '
        'cmbBitID
        '
        Me.cmbBitID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbBitID.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBitID.ForeColor = System.Drawing.Color.White
        Me.cmbBitID.FormattingEnabled = True
        Me.cmbBitID.Location = New System.Drawing.Point(218, 25)
        Me.cmbBitID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbBitID.Name = "cmbBitID"
        Me.cmbBitID.Size = New System.Drawing.Size(109, 23)
        Me.cmbBitID.TabIndex = 6
        '
        'cmbCardID
        '
        Me.cmbCardID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbCardID.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCardID.ForeColor = System.Drawing.Color.White
        Me.cmbCardID.FormattingEnabled = True
        Me.cmbCardID.Location = New System.Drawing.Point(0, 25)
        Me.cmbCardID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbCardID.Name = "cmbCardID"
        Me.cmbCardID.Size = New System.Drawing.Size(109, 23)
        Me.cmbCardID.TabIndex = 7
        '
        'cmbSlaveID
        '
        Me.cmbSlaveID.BackColor = System.Drawing.Color.DarkSlateGray
        Me.cmbSlaveID.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSlaveID.ForeColor = System.Drawing.Color.White
        Me.cmbSlaveID.FormattingEnabled = True
        Me.cmbSlaveID.Location = New System.Drawing.Point(109, 25)
        Me.cmbSlaveID.Margin = New System.Windows.Forms.Padding(0)
        Me.cmbSlaveID.Name = "cmbSlaveID"
        Me.cmbSlaveID.Size = New System.Drawing.Size(109, 23)
        Me.cmbSlaveID.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(109, 0)
        Me.Label3.Margin = New System.Windows.Forms.Padding(0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 25)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Slave ID"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(218, 0)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 25)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Bit ID"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 25)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Card ID"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnExist
        '
        Me.btnExist.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnExist.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExist.ForeColor = System.Drawing.Color.White
        Me.btnExist.Location = New System.Drawing.Point(236, 117)
        Me.btnExist.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.btnExist.Name = "btnExist"
        Me.btnExist.Size = New System.Drawing.Size(109, 40)
        Me.btnExist.TabIndex = 31
        Me.btnExist.Text = "Exist"
        Me.btnExist.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.DarkSlateGray
        Me.btnSave.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.White
        Me.btnSave.Location = New System.Drawing.Point(116, 117)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(1, 1, 0, 0)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(109, 40)
        Me.btnSave.TabIndex = 30
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'FSensor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkSlateGray
        Me.ClientSize = New System.Drawing.Size(354, 161)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnExist)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.gbDeviceConfigure)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FSensor"
        Me.Text = "數位輸入設定"
        Me.gbDeviceConfigure.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbDeviceConfigure As System.Windows.Forms.GroupBox
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents cmbBitID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbCardID As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSlaveID As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkLogic As System.Windows.Forms.CheckBox
    Friend WithEvents btnExist As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
End Class
