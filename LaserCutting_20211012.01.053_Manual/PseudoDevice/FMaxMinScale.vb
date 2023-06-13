Public Class FMaxMinScale
    Private m_motion As CMotion
    Private m_lblAxisName() As System.Windows.Forms.Label
    Private m_numMax() As System.Windows.Forms.NumericUpDown
    Private m_numMin() As System.Windows.Forms.NumericUpDown
    Private m_numHomeOffset() As System.Windows.Forms.NumericUpDown
    Private m_numScale() As System.Windows.Forms.NumericUpDown
    Public Sub New()
        ReDim m_lblAxisName(0 To 15)
        ReDim m_numMax(0 To 15)
        ReDim m_numMin(0 To 15)
        ReDim m_numHomeOffset(0 To 15)
        ReDim m_numScale(0 To 15)
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub
    Public Sub New(ByRef pMotion As CMotion)
        ReDim m_lblAxisName(0 To 15)
        ReDim m_numMax(0 To 15)
        ReDim m_numMin(0 To 15)
        ReDim m_numHomeOffset(0 To 15)
        ReDim m_numScale(0 To 15)
        m_motion = pMotion
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub
    Private Sub FMaxMinScale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        For idx As Integer = 0 To 15 ' LBound(0) To UBound(7)
            m_lblAxisName(idx) = New System.Windows.Forms.Label
            m_lblAxisName(idx).BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            m_lblAxisName(idx).FlatStyle = System.Windows.Forms.FlatStyle.Flat
            m_lblAxisName(idx).Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
            m_lblAxisName(idx).ForeColor = System.Drawing.Color.White
            'm_lblAxisName(idx).Location = New System.Drawing.Point(0, 29)
            m_lblAxisName(idx).Margin = New System.Windows.Forms.Padding(0)
            m_lblAxisName(idx).Name = "lblAxisName" & idx.ToString()
            m_lblAxisName(idx).Size = New System.Drawing.Size(164, 29)
            m_lblAxisName(idx).TabIndex = idx
            m_lblAxisName(idx).Text = "系統保留"
            m_lblAxisName(idx).TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            m_numMax(idx) = New System.Windows.Forms.NumericUpDown
            m_numMax(idx).BackColor = System.Drawing.Color.DarkSlateGray
            m_numMax(idx).Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
            m_numMax(idx).ForeColor = System.Drawing.Color.White
            'm_numMax(idx).Location = New System.Drawing.Point(164, 29)
            m_numMax(idx).Margin = New System.Windows.Forms.Padding(0)
            m_numMax(idx).Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            m_numMax(idx).Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
            m_numMax(idx).Name = "numMax" & idx.ToString()
            m_numMax(idx).Size = New System.Drawing.Size(98, 29)
            m_numMax(idx).TabIndex = idx
            m_numMax(idx).TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            m_numMin(idx) = New System.Windows.Forms.NumericUpDown
            m_numMin(idx).BackColor = System.Drawing.Color.DarkSlateGray
            m_numMin(idx).Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
            m_numMin(idx).ForeColor = System.Drawing.Color.White
            'm_numMin(idx).Location = New System.Drawing.Point(262, 29)
            m_numMin(idx).Margin = New System.Windows.Forms.Padding(0)
            m_numMin(idx).Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            m_numMin(idx).Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
            m_numMin(idx).Name = "numMin" & idx.ToString()
            m_numMin(idx).Size = New System.Drawing.Size(98, 29)
            m_numMin(idx).TabIndex = idx
            m_numMin(idx).TextAlign = System.Windows.Forms.HorizontalAlignment.Right

            m_numHomeOffset(idx) = New System.Windows.Forms.NumericUpDown
            m_numHomeOffset(idx).BackColor = System.Drawing.Color.DarkSlateGray
            m_numHomeOffset(idx).Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
            m_numHomeOffset(idx).ForeColor = System.Drawing.Color.White
            'm_numHomeOffset(idx).Location = New System.Drawing.Point(262, 29)
            m_numHomeOffset(idx).Margin = New System.Windows.Forms.Padding(0)
            m_numHomeOffset(idx).Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
            m_numHomeOffset(idx).Minimum = New Decimal(New Integer() {99999999, 0, 0, -2147483648})
            m_numHomeOffset(idx).Name = "numHomeOffset" & idx.ToString()
            m_numHomeOffset(idx).Size = New System.Drawing.Size(98, 29)
            m_numHomeOffset(idx).TabIndex = idx
            m_numHomeOffset(idx).TextAlign = System.Windows.Forms.HorizontalAlignment.Right

            m_numScale(idx) = New System.Windows.Forms.NumericUpDown
            m_numScale(idx).BackColor = System.Drawing.Color.DarkSlateGray
            m_numScale(idx).DecimalPlaces = 9
            m_numScale(idx).Font = New System.Drawing.Font("微軟正黑體", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
            m_numScale(idx).ForeColor = System.Drawing.Color.White
            'm_numScale(idx).Location = New System.Drawing.Point(458, 29)
            m_numScale(idx).Margin = New System.Windows.Forms.Padding(0)
            m_numScale(idx).Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
            m_numScale(idx).Name = "numScale" & idx.ToString()
            m_numScale(idx).Size = New System.Drawing.Size(181, 29)
            m_numScale(idx).TabIndex = idx
            m_numScale(idx).TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Next
        For idx As Integer = 0 To 15 'LBound(m_PosData) To UBound(m_PosData)
            Me.TableLayoutPanel1.Controls.Add(m_lblAxisName(idx), 0, idx + 1)
            Me.TableLayoutPanel1.Controls.Add(m_numMax(idx), 1, idx + 1)
            Me.TableLayoutPanel1.Controls.Add(m_numMin(idx), 2, idx + 1)
            Me.TableLayoutPanel1.Controls.Add(m_numHomeOffset(idx), 3, idx + 1)
            Me.TableLayoutPanel1.Controls.Add(m_numScale(idx), 4, idx + 1)
        Next
    End Sub 
    Private Sub btnExist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExist.Click
        Call Me.Close()
    End Sub
End Class