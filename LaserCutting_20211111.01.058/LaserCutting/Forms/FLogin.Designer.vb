<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FLogin
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FLogin))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancel = New LaserCutting.ButtonEx()
        Me.btnLogin = New LaserCutting.ButtonEx()
        Me.rbOperator = New LaserCutting.RadioButtonEx()
        Me.rbAdmin = New LaserCutting.RadioButtonEx()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.ForeColor = System.Drawing.Color.Purple
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LaserCutting.My.Resources.Resources.key
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'btnCancel
        '
        Me.btnCancel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCancel.ButtonType = LaserCutting.eButtonType.Square
        Me.btnCancel.Direction = LaserCutting.eArrow.Left
        Me.btnCancel.FlatAppearance.BorderSize = 0
        Me.btnCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.MistyRose
        Me.btnCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer))
        resources.ApplyResources(Me.btnCancel, "btnCancel")
        Me.btnCancel.ForeColor = System.Drawing.Color.White
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Radius = 30.0!
        Me.btnCancel.UseVisualStyleBackColor = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.Green
        Me.btnLogin.ButtonType = LaserCutting.eButtonType.Square
        Me.btnLogin.Direction = LaserCutting.eArrow.Left
        Me.btnLogin.FlatAppearance.BorderSize = 0
        Me.btnLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnLogin, "btnLogin")
        Me.btnLogin.ForeColor = System.Drawing.Color.White
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Radius = 30.0!
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'rbOperator
        '
        resources.ApplyResources(Me.rbOperator, "rbOperator")
        Me.rbOperator.BackColor = System.Drawing.Color.CornflowerBlue
        Me.rbOperator.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbOperator.CircleCheckedRadius = 7
        Me.rbOperator.CircleCheckedX = 3
        Me.rbOperator.CircleCheckedY = 7
        Me.rbOperator.CircleColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbOperator.CircleGlintSize = 5
        Me.rbOperator.CircleGlintX = 6
        Me.rbOperator.CircleGlintY = 10
        Me.rbOperator.CircleOffsetX = 0.0R
        Me.rbOperator.CircleOffsetY = 4.0R
        Me.rbOperator.CircleRadius = 10
        Me.rbOperator.CircleWidth = 1.0!
        Me.rbOperator.ForeColor = System.Drawing.Color.White
        Me.rbOperator.Name = "rbOperator"
        Me.rbOperator.TextOffsetX = 0.0R
        Me.rbOperator.TextOffsetY = 7.0R
        Me.rbOperator.UseVisualStyleBackColor = False
        '
        'rbAdmin
        '
        resources.ApplyResources(Me.rbAdmin, "rbAdmin")
        Me.rbAdmin.BackColor = System.Drawing.Color.CornflowerBlue
        Me.rbAdmin.Checked = True
        Me.rbAdmin.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rbAdmin.CircleCheckedRadius = 7
        Me.rbAdmin.CircleCheckedX = 3
        Me.rbAdmin.CircleCheckedY = 7
        Me.rbAdmin.CircleColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.rbAdmin.CircleGlintSize = 5
        Me.rbAdmin.CircleGlintX = 6
        Me.rbAdmin.CircleGlintY = 10
        Me.rbAdmin.CircleOffsetX = 0.0R
        Me.rbAdmin.CircleOffsetY = 4.0R
        Me.rbAdmin.CircleRadius = 10
        Me.rbAdmin.CircleWidth = 1.0!
        Me.rbAdmin.ForeColor = System.Drawing.Color.White
        Me.rbAdmin.Name = "rbAdmin"
        Me.rbAdmin.TabStop = True
        Me.rbAdmin.TextOffsetX = 0.0R
        Me.rbAdmin.TextOffsetY = 7.0R
        Me.rbAdmin.UseVisualStyleBackColor = False
        '
        'FLogin
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.rbOperator)
        Me.Controls.Add(Me.rbAdmin)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FLogin"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents btnLogin As LaserCutting.ButtonEx
    Friend WithEvents btnCancel As LaserCutting.ButtonEx
    Friend WithEvents rbOperator As LaserCutting.RadioButtonEx
    Friend WithEvents rbAdmin As LaserCutting.RadioButtonEx
End Class
