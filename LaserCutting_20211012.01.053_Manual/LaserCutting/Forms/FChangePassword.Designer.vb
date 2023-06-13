<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FChangePassword
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FChangePassword))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNewPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtNewPassword2 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnCancel = New LaserCutting.ButtonEx()
        Me.btnReset = New LaserCutting.ButtonEx()
        Me.btnOK = New LaserCutting.ButtonEx()
        Me.rdAdmin = New LaserCutting.RadioButtonEx()
        Me.rdOperator = New LaserCutting.RadioButtonEx()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        resources.ApplyResources(Me.Label1, "Label1")
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Name = "Label1"
        '
        'txtPassword
        '
        resources.ApplyResources(Me.txtPassword, "txtPassword")
        Me.txtPassword.ForeColor = System.Drawing.Color.Purple
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label2
        '
        resources.ApplyResources(Me.Label2, "Label2")
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Name = "Label2"
        '
        'txtNewPassword
        '
        resources.ApplyResources(Me.txtNewPassword, "txtNewPassword")
        Me.txtNewPassword.ForeColor = System.Drawing.Color.Purple
        Me.txtNewPassword.Name = "txtNewPassword"
        Me.txtNewPassword.UseSystemPasswordChar = True
        '
        'Label3
        '
        resources.ApplyResources(Me.Label3, "Label3")
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Name = "Label3"
        '
        'txtNewPassword2
        '
        resources.ApplyResources(Me.txtNewPassword2, "txtNewPassword2")
        Me.txtNewPassword2.ForeColor = System.Drawing.Color.Purple
        Me.txtNewPassword2.Name = "txtNewPassword2"
        Me.txtNewPassword2.UseSystemPasswordChar = True
        '
        'Label4
        '
        resources.ApplyResources(Me.Label4, "Label4")
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Name = "Label4"
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
        'btnReset
        '
        Me.btnReset.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnReset.ButtonType = LaserCutting.eButtonType.Square
        Me.btnReset.Direction = LaserCutting.eArrow.Left
        resources.ApplyResources(Me.btnReset, "btnReset")
        Me.btnReset.FlatAppearance.BorderSize = 0
        Me.btnReset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnReset.ForeColor = System.Drawing.Color.White
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Radius = 30.0!
        Me.btnReset.UseVisualStyleBackColor = False
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.Green
        Me.btnOK.ButtonType = LaserCutting.eButtonType.Square
        Me.btnOK.Direction = LaserCutting.eArrow.Left
        Me.btnOK.FlatAppearance.BorderSize = 0
        Me.btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        resources.ApplyResources(Me.btnOK, "btnOK")
        Me.btnOK.ForeColor = System.Drawing.Color.White
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Radius = 30.0!
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'rdAdmin
        '
        resources.ApplyResources(Me.rdAdmin, "rdAdmin")
        Me.rdAdmin.Checked = True
        Me.rdAdmin.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdAdmin.CircleCheckedRadius = 8
        Me.rdAdmin.CircleCheckedX = 2
        Me.rdAdmin.CircleCheckedY = 8
        Me.rdAdmin.CircleColor = System.Drawing.Color.DimGray
        Me.rdAdmin.CircleGlintSize = 5
        Me.rdAdmin.CircleGlintX = 5
        Me.rdAdmin.CircleGlintY = 10
        Me.rdAdmin.CircleOffsetX = 0.0R
        Me.rdAdmin.CircleOffsetY = 6.0R
        Me.rdAdmin.CircleRadius = 10
        Me.rdAdmin.CircleWidth = 1.0!
        Me.rdAdmin.ForeColor = System.Drawing.Color.White
        Me.rdAdmin.Name = "rdAdmin"
        Me.rdAdmin.TabStop = True
        Me.rdAdmin.TextOffsetX = 0.0R
        Me.rdAdmin.TextOffsetY = 7.0R
        Me.rdAdmin.UseVisualStyleBackColor = True
        '
        'rdOperator
        '
        resources.ApplyResources(Me.rdOperator, "rdOperator")
        Me.rdOperator.CheckedColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.rdOperator.CircleCheckedRadius = 8
        Me.rdOperator.CircleCheckedX = 2
        Me.rdOperator.CircleCheckedY = 8
        Me.rdOperator.CircleColor = System.Drawing.Color.DimGray
        Me.rdOperator.CircleGlintSize = 5
        Me.rdOperator.CircleGlintX = 5
        Me.rdOperator.CircleGlintY = 10
        Me.rdOperator.CircleOffsetX = 0.0R
        Me.rdOperator.CircleOffsetY = 6.0R
        Me.rdOperator.CircleRadius = 10
        Me.rdOperator.CircleWidth = 1.0!
        Me.rdOperator.ForeColor = System.Drawing.Color.White
        Me.rdOperator.Name = "rdOperator"
        Me.rdOperator.TextOffsetX = 0.0R
        Me.rdOperator.TextOffsetY = 7.0R
        Me.rdOperator.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.LaserCutting.My.Resources.Resources.changekey
        resources.ApplyResources(Me.PictureBox1, "PictureBox1")
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.TabStop = False
        '
        'FChangePassword
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.CornflowerBlue
        resources.ApplyResources(Me, "$this")
        Me.Controls.Add(Me.rdOperator)
        Me.Controls.Add(Me.rdAdmin)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.txtNewPassword2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtNewPassword)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtPassword)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "FChangePassword"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNewPassword2 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnCancel As LaserCutting.ButtonEx
    Friend WithEvents btnOK As LaserCutting.ButtonEx
    Friend WithEvents btnReset As LaserCutting.ButtonEx
    Friend WithEvents rdAdmin As LaserCutting.RadioButtonEx
    Friend WithEvents rdOperator As LaserCutting.RadioButtonEx
End Class
