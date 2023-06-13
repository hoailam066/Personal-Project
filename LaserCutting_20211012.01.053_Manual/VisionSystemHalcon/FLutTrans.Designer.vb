<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLutTrans
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
        Me.ImageViewer1 = New VisionSystem.ImageDisplay()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.cmbCamera = New System.Windows.Forms.ComboBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageViewer1
        '
        Me.ImageViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageViewer1.BackColor = System.Drawing.Color.Maroon
        Me.ImageViewer1.Location = New System.Drawing.Point(9, 9)
        Me.ImageViewer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageViewer1.Name = "ImageViewer1"
        Me.ImageViewer1.Size = New System.Drawing.Size(640, 480)
        Me.ImageViewer1.TabIndex = 3
        '
        'PictureBox1
        '
        Me.PictureBox1.BackColor = System.Drawing.Color.White
        Me.PictureBox1.Location = New System.Drawing.Point(661, 234)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(255, 255)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'cmbCamera
        '
        Me.cmbCamera.FormattingEnabled = True
        Me.cmbCamera.Location = New System.Drawing.Point(661, 12)
        Me.cmbCamera.Name = "cmbCamera"
        Me.cmbCamera.Size = New System.Drawing.Size(121, 20)
        Me.cmbCamera.TabIndex = 5
        '
        'FLutTrans
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.DarkBlue
        Me.ClientSize = New System.Drawing.Size(921, 494)
        Me.Controls.Add(Me.cmbCamera)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.ImageViewer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "FLutTrans"
        Me.Text = "FLutTrans"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageViewer1 As VisionSystem.ImageDisplay
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCamera As System.Windows.Forms.ComboBox
End Class
