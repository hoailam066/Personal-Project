<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImageDisplay
    Inherits System.Windows.Forms.UserControl

    'UserControl 覆寫 Dispose 以清除元件清單。
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageDisplay))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.btnNone = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnMove = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomIn = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomOut = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoomFit = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnZoom1x = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.HWindowControl1 = New HalconDotNet.HWindowControl()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.ToolStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnNone, Me.ToolStripButton2, Me.btnMove, Me.ToolStripSeparator1, Me.btnZoomIn, Me.ToolStripSeparator2, Me.btnZoomOut, Me.ToolStripSeparator3, Me.btnZoomFit, Me.ToolStripSeparator4, Me.btnZoom1x, Me.ToolStripLabel2, Me.ToolStripSeparator5, Me.ToolStripLabel1, Me.ToolStripSeparator6, Me.ToolStripLabel3})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 420)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(708, 25)
        Me.ToolStrip1.TabIndex = 5
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'btnNone
        '
        Me.btnNone.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNone.Image = CType(resources.GetObject("btnNone.Image"), System.Drawing.Image)
        Me.btnNone.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNone.Name = "btnNone"
        Me.btnNone.Size = New System.Drawing.Size(23, 22)
        Me.btnNone.Text = "指定"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(6, 25)
        '
        'btnMove
        '
        Me.btnMove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMove.Image = CType(resources.GetObject("btnMove.Image"), System.Drawing.Image)
        Me.btnMove.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMove.Name = "btnMove"
        Me.btnMove.Size = New System.Drawing.Size(23, 22)
        Me.btnMove.Text = "平移"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'btnZoomIn
        '
        Me.btnZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomIn.Image = CType(resources.GetObject("btnZoomIn.Image"), System.Drawing.Image)
        Me.btnZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomIn.Name = "btnZoomIn"
        Me.btnZoomIn.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomIn.Text = "放大"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'btnZoomOut
        '
        Me.btnZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomOut.Image = CType(resources.GetObject("btnZoomOut.Image"), System.Drawing.Image)
        Me.btnZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomOut.Name = "btnZoomOut"
        Me.btnZoomOut.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomOut.Text = "縮小"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnZoomFit
        '
        Me.btnZoomFit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomFit.Image = CType(resources.GetObject("btnZoomFit.Image"), System.Drawing.Image)
        Me.btnZoomFit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomFit.Name = "btnZoomFit"
        Me.btnZoomFit.Size = New System.Drawing.Size(23, 22)
        Me.btnZoomFit.Text = "全畫面"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'btnZoom1x
        '
        Me.btnZoom1x.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoom1x.Image = CType(resources.GetObject("btnZoom1x.Image"), System.Drawing.Image)
        Me.btnZoom1x.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoom1x.Name = "btnZoom1x"
        Me.btnZoom1x.Size = New System.Drawing.Size(23, 22)
        Me.btnZoom1x.Text = "原始倍率"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel2.AutoSize = False
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel2.Text = "11024,768"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel1.AutoSize = False
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel1.Text = "255,255,255"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right
        Me.ToolStripLabel3.AutoSize = False
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(80, 22)
        Me.ToolStripLabel3.Text = "0,0"
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'HWindowControl1
        '
        Me.HWindowControl1.BackColor = System.Drawing.Color.Black
        Me.HWindowControl1.BorderColor = System.Drawing.Color.Black
        Me.HWindowControl1.ImagePart = New System.Drawing.Rectangle(0, 0, 640, 480)
        Me.HWindowControl1.Location = New System.Drawing.Point(0, 0)
        Me.HWindowControl1.Name = "HWindowControl1"
        Me.HWindowControl1.Size = New System.Drawing.Size(553, 377)
        Me.HWindowControl1.TabIndex = 6
        Me.HWindowControl1.WindowSize = New System.Drawing.Size(553, 377)
        '
        'ImageDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.Maroon
        Me.Controls.Add(Me.HWindowControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Margin = New System.Windows.Forms.Padding(0)
        Me.Name = "ImageDisplay"
        Me.Size = New System.Drawing.Size(708, 445)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents btnNone As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnMove As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomIn As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomOut As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoomFit As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnZoom1x As System.Windows.Forms.ToolStripButton
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents HWindowControl1 As HalconDotNet.HWindowControl

End Class
