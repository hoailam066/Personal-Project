Public Class FInputCorrection
    Private m_Corection As CCorrection
    Private m_dgvCorrection As DataGridView
    Private m_ColumnX As Integer = 3
    Private m_ColumnY As Integer = 4
    Private m_DecimalPlace As Integer = 3

    Public WriteOnly Property ColumnX As Integer
        Set(ByVal value As Integer)
            m_ColumnX = value
        End Set
    End Property
    Public WriteOnly Property ColumnY As Integer
        Set(ByVal value As Integer)
            m_ColumnY = value
        End Set
    End Property
    Public WriteOnly Property DecimalPlace As Integer
        Set(ByVal value As Integer)
            m_DecimalPlace = value
            numDecimalPlace.Value = m_DecimalPlace
        End Set
    End Property
    Public Sub New(ByVal pRange As eCorrectionRange, ByRef pDataGridView As DataGridView)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        numDecimalPlace.Value = m_DecimalPlace
        m_Corection = New CCorrection
        m_Corection.Range = pRange
        m_dgvCorrection = pDataGridView
    End Sub
    Public Sub New(ByRef pCorrection As CCorrection, ByRef pDataGridView As DataGridView)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        numDecimalPlace.Value = m_DecimalPlace
        m_Corection = pCorrection
        m_dgvCorrection = pDataGridView
    End Sub
    Dim fLoad As FLoading = New FLoading("Please wait....")
    Private Sub FInputCorrection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        fLoad.Show(Me)
        fLoad.Percent = 25
        AddNumeric()
        fLoad.Percent = 35
        ShowGridPoint()
        fLoad.Percent = 50
        Panel1.HorizontalScroll.Value = 0
        Panel1.VerticalScroll.Value = Panel1.VerticalScroll.Maximum
        m_numericPoint(0, 0).numX.Focus()
        m_numericPoint(0, 0).numX.Select(0, m_numericPoint(0, 0).numX.Value.ToString("0.000").Length)
        cboScale.SelectedIndex = 0
    End Sub

    Private m_numericPoint(14, 14) As UserControlPoint

    Private Sub AddNumeric()
        Try
            ReDim m_numericPoint(14, 14)
            Dim cnt As Integer = 1
            For row = 0 To 14
                cnt = 1
                For col = 0 To 14
                    m_numericPoint(row, col) = New UserControlPoint()
                    m_numericPoint(row, col).DecimalPlaces = m_DecimalPlace
                    m_numericPoint(row, col).Name = "numPoint_" & row.ToString() & "_" & col.ToString()
                    'm_numericPoint(row, col).X = row
                    'm_numericPoint(row, col).Y = col
                    m_numericPoint(row, col).Visible = False
                    TableLayoutPanel1.Controls.Add(m_numericPoint(row, col), col + cnt, 14 - row)
                    cnt += 1
                    If (row = 0) Then
                        AddHandler m_numericPoint(row, col).NumX_KeyUp, AddressOf numericX_KeyUp
                    End If
                    If (col = 0) Then
                        AddHandler m_numericPoint(row, col).NumY_KeyUp, AddressOf numericY_KeyUp
                    End If
                Next
            Next
        Catch ex As Exception
            FMessageBox.Show(ex.Message, "AddNumeric", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub ShowGridPoint()
        TableLayoutPanel1.SuspendLayout()
        TableLayoutPanel1.Visible = False
        Try
            Dim start As DateTime = DateTime.Now
            For row = 0 To m_Corection.Range - 1
                For col = 0 To m_Corection.Range - 1
                    RemoveHandler m_numericPoint(row, col).NumX_MouseClick, AddressOf numericX_MouseClick
                    RemoveHandler m_numericPoint(row, col).NumY_MouseClick, AddressOf numericY_MouseClick
                    If (row < m_Corection.Range AndAlso col < m_Corection.Range) Then
                        m_numericPoint(row, col).Visible = True
                    Else
                        m_numericPoint(row, col).Visible = False
                    End If
                    If (row = (m_Corection.Range - 1) / 2 AndAlso col = (m_Corection.Range - 1) / 2) Then
                        m_numericPoint(row, col).Enabled = False
                    Else
                        m_numericPoint(row, col).Enabled = True
                    End If
                    If (row = 0 AndAlso col = 0) Then
                        AddHandler m_numericPoint(row, col).NumX_MouseClick, AddressOf numericX_MouseClick
                    End If
                    If (col = 0 AndAlso row = m_Corection.Range - 1) Then
                        AddHandler m_numericPoint(row, col).NumY_MouseClick, AddressOf numericY_MouseClick
                    End If
                Next
            Next
            Dim total As Double = (DateTime.Now - start).TotalMilliseconds

            If (TableLayoutPanel1.BackgroundImage IsNot Nothing) Then
                TableLayoutPanel1.BackgroundImage.Dispose()
                TableLayoutPanel1.BackgroundImage = Nothing
            End If
            TableLayoutPanel1.Size = New Size(15 * 120, 15 * 65)
            Dim bmp As Bitmap = New Bitmap(TableLayoutPanel1.Width, TableLayoutPanel1.Height)
            Dim g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.White)
            Dim rowHeight As Integer = 65
            Dim colWidth As Integer = 122
            Dim pX, pY As Integer
            Dim offsetX As Integer = 10
            Dim offsetY As Integer = 50
            Dim cnt As Integer = 1
            Dim Diameter As Integer = 28
            Dim font As Font = New Font("Arial", 9)
            Dim p1, p2 As Point
            p1 = New Point(0, 0)
            p2 = New Point(0, 0)
            Using p As Pen = New Pen(Brushes.Black, 2)
                Using b As SolidBrush = New SolidBrush(Color.Red)
                    For col = 0 To m_Corection.Range - 1
                        For row = 0 To m_Corection.Range - 1
                            pX = colWidth * col + offsetX - 2 * col
                            pY = TableLayoutPanel1.Height - rowHeight * row - offsetY
                            g.DrawEllipse(p, pX, pY, Diameter, Diameter)
                            If ((col = 0 OrElse row = 0)) Then 'AndAlso col <= (m_Corection.Range - 1) / 2 AndAlso row <= (m_Corection.Range - 1) / 2) Then
                                b.Color = Color.LimeGreen
                                Dim size As SizeF = g.MeasureString(cnt.ToString(), font)
                                g.DrawString(cnt.ToString(), font, b, pX + (Diameter - size.Width) / 2, pY + (Diameter - size.Height) / 2)
                                b.Color = Color.Red
                            Else
                                Dim size As SizeF = g.MeasureString(cnt.ToString(), font)
                                g.DrawString(cnt.ToString(), font, b, pX + (Diameter - size.Width) / 2, pY + (Diameter - size.Height) / 2)
                            End If

                            cnt += 1
                            If (col + 1 < m_Corection.Range) Then
                                p1.X = pX + Diameter
                                p1.Y = CInt(pY + Diameter / 2)

                                p2.X = colWidth * (col + 1) + offsetX - 2 * (col + 1)
                                p2.Y = p1.Y
                                If (row = (m_Corection.Range - 1) / 2) Then
                                    p.Color = Color.Lime
                                End If
                                g.DrawLine(p, p1, p2)
                                p.Color = Color.Black
                            End If

                            If (row + 1 < m_Corection.Range) Then
                                p1.X = CInt(colWidth * col + offsetX - 2 * col + Diameter / 2)
                                p1.Y = TableLayoutPanel1.Height - rowHeight * row - offsetY

                                p2.X = p1.X
                                p2.Y = p1.Y - Diameter - 5
                                If (col = (m_Corection.Range - 1) / 2) Then
                                    p.Color = Color.Lime
                                End If
                                g.DrawLine(p, p1, p2)
                                p.Color = Color.Black
                            End If
                        Next
                    Next
                End Using
            End Using

            font.Dispose()
            font = Nothing
            g.Dispose()
            g = Nothing
            TableLayoutPanel1.BackgroundImage = CType(bmp.Clone(), Image)
            bmp.Dispose()
            bmp = Nothing
            GC.Collect()

        Catch ex As Exception
            FMessageBox.Show(ex.Message, "ShowGridPoint", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
        TableLayoutPanel1.ResumeLayout()
        TableLayoutPanel1.Visible = True
    End Sub

    Private Sub btnAutoFill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoFill.Click
        Try
            Dim X As Decimal = 0
            Dim Y As Decimal = 0


            'For row = 0 To m_Corection.Range - 1
            '    For col = 0 To m_Corection.Range - 1
            '        If (col > (m_Corection.Range - 1) / 2) Then
            '            m_numericPoint(row, col).X = (-1) * m_numericPoint(row, m_Corection.Range - 1 - col).X
            '        End If
            '    Next
            'Next

            'For col = 0 To m_Corection.Range - 1
            '    For row = 0 To m_Corection.Range - 1
            '        If (row > (m_Corection.Range - 1) / 2) Then
            '            m_numericPoint(row, col).Y = (-1) * m_numericPoint(m_Corection.Range - 1 - row, col).Y
            '        End If
            '    Next
            'Next

            For col = 0 To m_Corection.Range - 1
                X = m_numericPoint(0, col).X
                For row = 1 To m_Corection.Range - 1
                    m_numericPoint(row, col).X = X
                Next
            Next

            For row = 0 To m_Corection.Range - 1
                Y = m_numericPoint(row, 0).Y
                For col = 1 To m_Corection.Range - 1
                    m_numericPoint(row, col).Y = Y
                Next
            Next

            

        Catch ex As Exception
            FMessageBox.Show(ex.Message, "btnAutoFill_Click", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub

    Private Sub numericX_KeyUp(ByVal row As Integer, ByVal col As Integer)
        Try
            If (col < m_Corection.Range) Then
                m_numericPoint(row, col + 1).numX.Focus()
                m_numericPoint(row, col + 1).numX.Select(0, m_numericPoint(row, col + 1).numX.Value.ToString("0.000").Length)
            End If
        Catch
        End Try
    End Sub
    Private Sub numericY_KeyUp(ByVal row As Integer, ByVal col As Integer)
        Try
            If (row > 0) Then
                m_numericPoint(row - 1, col).numY.Focus()
                m_numericPoint(row - 1, col).numY.Select(0, m_numericPoint(row - 1, col).numY.Value.ToString("0.000").Length)
            End If
        Catch
        End Try
    End Sub

    Private Sub numericX_MouseClick(ByVal row As Integer, ByVal col As Integer)
        Try
            m_numericPoint(row, col).numX.Select(0, m_numericPoint(row, col).numX.Value.ToString("0.000").Length)
        Catch
        End Try
    End Sub
    Private Sub numericY_MouseClick(ByVal row As Integer, ByVal col As Integer)
        Try
            m_numericPoint(row, col).numY.Select(0, m_numericPoint(row, col).numY.Value.ToString("0.000").Length)
        Catch
        End Try
    End Sub

    Private Sub FInputCorrection_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If (MessageBox.Show("Are you want to save?", "Save ???", MessageBoxButtons.YesNo, Windows.Forms.MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                Dim dgvIdx As Integer = 0
                Dim scale As Double = 1.0 / Math.Pow(10, cboScale.SelectedIndex)

                For col = 0 To m_Corection.Range - 1
                    For row = 0 To m_Corection.Range - 1
                        m_dgvCorrection.Rows(dgvIdx).Cells(m_ColumnX).Value = m_numericPoint(row, col).X * scale
                        m_dgvCorrection.Rows(dgvIdx).Cells(m_ColumnY).Value = m_numericPoint(row, col).Y * scale
                        dgvIdx += 1
                    Next
                Next
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub FInputCorrection_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Dim t As DateTime = DateTime.Now
        Dim v As Integer = 1
        Do
            Application.DoEvents()
            If ((DateTime.Now - t).TotalSeconds >= v) Then
                v += 1
                fLoad.Percent += 10
            End If
        Loop Until (DateTime.Now - t).TotalSeconds >= 2
        fLoad.Percent = 100
        fLoad.Close()
        fLoad.Dispose()
        fLoad = Nothing

    End Sub

    Private Sub numDecimalPlace_Click(sender As System.Object, e As System.EventArgs) Handles numDecimalPlace.Click
        If (m_DecimalPlace <> numDecimalPlace.Value) Then
            m_DecimalPlace = numDecimalPlace.Value
            For rowIdx = 0 To 14
                For colIdx = 0 To 14
                    m_numericPoint(rowIdx, colIdx).DecimalPlaces = m_DecimalPlace
                Next
            Next
        End If
    End Sub

End Class