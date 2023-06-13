<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControlPoint
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numX = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numY = New System.Windows.Forms.NumericUpDown()
        CType(Me.numX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(-3, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(17, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "X"
        '
        'numX
        '
        Me.numX.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numX.DecimalPlaces = 3
        Me.numX.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numX.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.numX.Location = New System.Drawing.Point(11, 0)
        Me.numX.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.numX.Minimum = New Decimal(New Integer() {1410065408, 2, 0, -2147483648})
        Me.numX.Name = "numX"
        Me.numX.Size = New System.Drawing.Size(89, 23)
        Me.numX.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-3, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 17)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Y"
        '
        'numY
        '
        Me.numY.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.numY.DecimalPlaces = 3
        Me.numY.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numY.ImeMode = System.Windows.Forms.ImeMode.Alpha
        Me.numY.Location = New System.Drawing.Point(11, 27)
        Me.numY.Maximum = New Decimal(New Integer() {1410065408, 2, 0, 0})
        Me.numY.Minimum = New Decimal(New Integer() {1410065408, 2, 0, -2147483648})
        Me.numY.Name = "numY"
        Me.numY.Size = New System.Drawing.Size(89, 23)
        Me.numY.TabIndex = 1
        '
        'UserControlPoint
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.numY)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.numX)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UserControlPoint"
        Me.Size = New System.Drawing.Size(100, 53)
        CType(Me.numX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numY, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Public WithEvents numX As System.Windows.Forms.NumericUpDown
    Public WithEvents numY As System.Windows.Forms.NumericUpDown

End Class
