<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FCalibration
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ShowRulerToolToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.grbCamera = New LaserSolder.GroupBoxEx()
        Me.ImageDisplay1 = New VisionSystem.ImageDisplay()
        Me.GroupBoxEx1 = New LaserSolder.GroupBoxEx()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ImageDisplay2 = New VisionSystem.ImageDisplay()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.grbCamera.SuspendLayout()
        Me.GroupBoxEx1.SuspendLayout()
        Me.SuspendLayout()
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
        'grbCamera
        '
        Me.grbCamera.BackColor = System.Drawing.Color.White
        Me.grbCamera.BorderColor = System.Drawing.SystemColors.ControlLight
        Me.grbCamera.BorderRadius = CType(0UI, UInteger)
        Me.grbCamera.Controls.Add(Me.ImageDisplay1)
        Me.grbCamera.Location = New System.Drawing.Point(2, 3)
        Me.grbCamera.Name = "grbCamera"
        Me.grbCamera.Size = New System.Drawing.Size(1300, 975)
        Me.grbCamera.TabIndex = 28
        Me.grbCamera.TabStop = False
        Me.grbCamera.Tag = "FCalibration"
        Me.grbCamera.TextColor = System.Drawing.SystemColors.ControlText
        '
        'ImageDisplay1
        '
        Me.ImageDisplay1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageDisplay1.BackColor = System.Drawing.Color.Maroon
        Me.ImageDisplay1.ContextMenuStrip = Me.ContextMenuStrip1
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
        Me.ImageDisplay1.Size = New System.Drawing.Size(1300, 975)
        Me.ImageDisplay1.TabIndex = 12
        '
        'GroupBoxEx1
        '
        Me.GroupBoxEx1.BorderColor = System.Drawing.SystemColors.HotTrack
        Me.GroupBoxEx1.BorderRadius = CType(0UI, UInteger)
        Me.GroupBoxEx1.Controls.Add(Me.ImageDisplay2)
        Me.GroupBoxEx1.Location = New System.Drawing.Point(1320, 667)
        Me.GroupBoxEx1.Name = "GroupBoxEx1"
        Me.GroupBoxEx1.Size = New System.Drawing.Size(322, 322)
        Me.GroupBoxEx1.TabIndex = 26
        Me.GroupBoxEx1.TabStop = False
        Me.GroupBoxEx1.TextColor = System.Drawing.SystemColors.ControlText
        '
        'Timer1
        '
        '
        'ImageDisplay2
        '
        Me.ImageDisplay2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ImageDisplay2.BackColor = System.Drawing.Color.Maroon
        Me.ImageDisplay2.ImagePoint_X = 0.0R
        Me.ImageDisplay2.ImagePoint_Y = 0.0R
        Me.ImageDisplay2.ImagePointCanGet = True
        Me.ImageDisplay2.Location = New System.Drawing.Point(1, 1)
        Me.ImageDisplay2.Margin = New System.Windows.Forms.Padding(0)
        Me.ImageDisplay2.Name = "ImageDisplay2"
        Me.ImageDisplay2.Record = False
        Me.ImageDisplay2.RecordInit = False
        Me.ImageDisplay2.RecordIsThreadFinished = False
        Me.ImageDisplay2.RecordIsThreadStarted = False
        Me.ImageDisplay2.RecordPath = Nothing
        Me.ImageDisplay2.RecordStop = False
        Me.ImageDisplay2.Size = New System.Drawing.Size(320, 320)
        Me.ImageDisplay2.TabIndex = 0
        '
        'FCalibration
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1654, 1001)
        Me.Controls.Add(Me.grbCamera)
        Me.Controls.Add(Me.GroupBoxEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FCalibration"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FCalibration"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.grbCamera.ResumeLayout(False)
        Me.GroupBoxEx1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBoxEx1 As LaserSolder.GroupBoxEx
    Friend WithEvents ImageDisplay1 As VisionSystem.ImageDisplay
    Friend WithEvents grbCamera As LaserSolder.GroupBoxEx
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ShowRulerToolToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents ImageDisplay2 As VisionSystem.ImageDisplay
End Class
