<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLoading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLoading))
        Me.ProgressBarEx1 = New LaserCutting.ProgressBarEx()
        Me.SuspendLayout()
        '
        'ProgressBarEx1
        '
        resources.ApplyResources(Me.ProgressBarEx1, "ProgressBarEx1")
        Me.ProgressBarEx1.Name = "ProgressBarEx1"
        Me.ProgressBarEx1.TextShow = "Loading..."
        '
        'FLoading
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.Control
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.ProgressBarEx1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FLoading"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ProgressBarEx1 As LaserCutting.ProgressBarEx
End Class
