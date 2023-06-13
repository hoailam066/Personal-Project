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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FMain))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.grbCamera = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnChangeColor = New System.Windows.Forms.Button()
        Me.btnCapture = New System.Windows.Forms.Button()
        Me.chkMode3 = New System.Windows.Forms.CheckBox()
        Me.btnDisConnect = New System.Windows.Forms.Button()
        Me.chkMode2 = New System.Windows.Forms.CheckBox()
        Me.chkMode1 = New System.Windows.Forms.CheckBox()
        Me.btnConnect = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageDisplay1 = New VisionSystem.ImageDisplay()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.grbCamera.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 4
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.grbCamera, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel4, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Label2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 3, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1364, 766)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'grbCamera
        '
        Me.grbCamera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.grbCamera.Controls.Add(Me.ImageDisplay1)
        Me.grbCamera.Location = New System.Drawing.Point(330, 0)
        Me.grbCamera.Margin = New System.Windows.Forms.Padding(0)
        Me.grbCamera.Name = "grbCamera"
        Me.TableLayoutPanel1.SetRowSpan(Me.grbCamera, 2)
        Me.grbCamera.Size = New System.Drawing.Size(807, 646)
        Me.grbCamera.TabIndex = 1
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.btnChangeColor, 0, 7)
        Me.TableLayoutPanel4.Controls.Add(Me.btnCapture, 0, 6)
        Me.TableLayoutPanel4.Controls.Add(Me.chkMode3, 0, 5)
        Me.TableLayoutPanel4.Controls.Add(Me.btnDisConnect, 0, 2)
        Me.TableLayoutPanel4.Controls.Add(Me.chkMode2, 0, 4)
        Me.TableLayoutPanel4.Controls.Add(Me.chkMode1, 0, 3)
        Me.TableLayoutPanel4.Controls.Add(Me.btnConnect, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(277, 22)
        Me.TableLayoutPanel4.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 8
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 53.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(50, 766)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'btnChangeColor
        '
        Me.btnChangeColor.BackgroundImage = Global.CameraViewer.My.Resources.Resources.pickcolor
        Me.btnChangeColor.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnChangeColor.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnChangeColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnChangeColor.Location = New System.Drawing.Point(0, 371)
        Me.btnChangeColor.Margin = New System.Windows.Forms.Padding(0)
        Me.btnChangeColor.Name = "btnChangeColor"
        Me.btnChangeColor.Size = New System.Drawing.Size(48, 48)
        Me.btnChangeColor.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnChangeColor, "Change color")
        Me.btnChangeColor.UseVisualStyleBackColor = True
        '
        'btnCapture
        '
        Me.btnCapture.BackgroundImage = Global.CameraViewer.My.Resources.Resources.capture
        Me.btnCapture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCapture.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnCapture.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCapture.Location = New System.Drawing.Point(0, 318)
        Me.btnCapture.Margin = New System.Windows.Forms.Padding(0)
        Me.btnCapture.Name = "btnCapture"
        Me.btnCapture.Size = New System.Drawing.Size(48, 48)
        Me.btnCapture.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnCapture, "Capture picture")
        Me.btnCapture.UseVisualStyleBackColor = True
        '
        'chkMode3
        '
        Me.chkMode3.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMode3.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode3_1
        Me.chkMode3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkMode3.FlatAppearance.BorderSize = 0
        Me.chkMode3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMode3.Location = New System.Drawing.Point(0, 265)
        Me.chkMode3.Margin = New System.Windows.Forms.Padding(0)
        Me.chkMode3.Name = "chkMode3"
        Me.chkMode3.Size = New System.Drawing.Size(48, 48)
        Me.chkMode3.TabIndex = 1
        Me.chkMode3.UseVisualStyleBackColor = True
        '
        'btnDisConnect
        '
        Me.btnDisConnect.BackgroundImage = Global.CameraViewer.My.Resources.Resources.camera2
        Me.btnDisConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnDisConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnDisConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDisConnect.Location = New System.Drawing.Point(0, 106)
        Me.btnDisConnect.Margin = New System.Windows.Forms.Padding(0)
        Me.btnDisConnect.Name = "btnDisConnect"
        Me.btnDisConnect.Size = New System.Drawing.Size(48, 48)
        Me.btnDisConnect.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnDisConnect, "Disconnect to camera")
        Me.btnDisConnect.UseVisualStyleBackColor = True
        '
        'chkMode2
        '
        Me.chkMode2.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMode2.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode2_1
        Me.chkMode2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkMode2.FlatAppearance.BorderSize = 0
        Me.chkMode2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMode2.Location = New System.Drawing.Point(0, 212)
        Me.chkMode2.Margin = New System.Windows.Forms.Padding(0)
        Me.chkMode2.Name = "chkMode2"
        Me.chkMode2.Size = New System.Drawing.Size(48, 48)
        Me.chkMode2.TabIndex = 1
        Me.chkMode2.UseVisualStyleBackColor = True
        '
        'chkMode1
        '
        Me.chkMode1.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkMode1.BackgroundImage = Global.CameraViewer.My.Resources.Resources.mode1_1
        Me.chkMode1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.chkMode1.FlatAppearance.BorderSize = 0
        Me.chkMode1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkMode1.Location = New System.Drawing.Point(0, 159)
        Me.chkMode1.Margin = New System.Windows.Forms.Padding(0)
        Me.chkMode1.Name = "chkMode1"
        Me.chkMode1.Size = New System.Drawing.Size(48, 48)
        Me.chkMode1.TabIndex = 1
        Me.chkMode1.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.BackgroundImage = Global.CameraViewer.My.Resources.Resources.camera1
        Me.btnConnect.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnConnect.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.btnConnect.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnConnect.Location = New System.Drawing.Point(0, 53)
        Me.btnConnect.Margin = New System.Windows.Forms.Padding(0)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(48, 48)
        Me.btnConnect.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.btnConnect, "Connect to camera")
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.TableLayoutPanel1.SetColumnSpan(Me.Label2, 2)
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(324, 22)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Camera Viewer    v20210712.01.002"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(1137, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(227, 22)
        Me.TableLayoutPanel2.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Red
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(207, 0)
        Me.Label1.Margin = New System.Windows.Forms.Padding(0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 22)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1366, 768)
        Me.Panel1.TabIndex = 1
        '
        'Timer1
        '
        Me.Timer1.Interval = 60000
        '
        'ImageDisplay1
        '
        Me.ImageDisplay1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageDisplay1.BackColor = System.Drawing.Color.Maroon
        Me.ImageDisplay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImageDisplay1.ImagePoint_X = 0.0R
        Me.ImageDisplay1.ImagePoint_Y = 0.0R
        Me.ImageDisplay1.ImagePointCanGet = True
        Me.ImageDisplay1.Location = New System.Drawing.Point(0, 0)
        Me.ImageDisplay1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageDisplay1.Name = "ImageDisplay1"
        Me.ImageDisplay1.Record = False
        Me.ImageDisplay1.RecordInit = False
        Me.ImageDisplay1.RecordIsThreadFinished = False
        Me.ImageDisplay1.RecordIsThreadStarted = False
        Me.ImageDisplay1.RecordPath = Nothing
        Me.ImageDisplay1.RecordStop = False
        Me.ImageDisplay1.Size = New System.Drawing.Size(805, 644)
        Me.ImageDisplay1.TabIndex = 0
        '
        'FMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1366, 768)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(1366, 740)
        Me.Name = "FMain"
        Me.Text = "CameraMeasure"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.grbCamera.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents grbCamera As System.Windows.Forms.Panel
    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents btnDisConnect As System.Windows.Forms.Button
    Friend WithEvents chkMode3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMode1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkMode2 As System.Windows.Forms.CheckBox
    Friend WithEvents ImageDisplay1 As VisionSystem.ImageDisplay
    Friend WithEvents btnCapture As System.Windows.Forms.Button
    Friend WithEvents btnChangeColor As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel4 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TableLayoutPanel2 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
