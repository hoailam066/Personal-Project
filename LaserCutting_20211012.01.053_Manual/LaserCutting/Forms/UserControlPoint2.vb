Public Class UserControlPoint2
    Public Event NumX_KeyUp(ByVal row As Integer, ByVal col As Integer)
    Public Event NumY_KeyUp(ByVal row As Integer, ByVal col As Integer)
    Public Event NumX_MouseClick(ByVal row As Integer, ByVal col As Integer)
    Public Event NumY_MouseClick(ByVal row As Integer, ByVal col As Integer)
    Public Property X As Decimal
        Get
            Return CDec(txtX.Text)
        End Get
        Set(ByVal value As Decimal)
            txtX.Text = value.ToString()
        End Set
    End Property
    Public Property Y As Decimal
        Get
            Return CDec(txtY.Text)
        End Get
        Set(ByVal value As Decimal)
            txtY.Text = value
        End Set
    End Property


    Private Sub MenumY_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtY.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Dim tmp = Me.Name.Split("_"c)
            RaiseEvent NumY_KeyUp(CInt(tmp(1)), CInt(tmp(2)))
        End If
    End Sub
    Private Sub MenumX_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtX.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Dim tmp = Me.Name.Split("_"c)
            RaiseEvent NumX_KeyUp(CInt(tmp(1)), CInt(tmp(2)))
        End If
    End Sub

    Private Sub MenumX_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtX.MouseClick
        Dim tmp = Me.Name.Split("_"c)
        RaiseEvent NumX_MouseClick(CInt(tmp(1)), CInt(tmp(2)))
    End Sub

    Private Sub MenumY_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtY.MouseClick
        Dim tmp = Me.Name.Split("_"c)
        RaiseEvent NumY_MouseClick(CInt(tmp(1)), CInt(tmp(2)))
    End Sub

    Private Sub txt_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtX.KeyPress, txtY.KeyPress
        Try
            If (Char.IsControl(e.KeyChar)) Then
                Exit Sub
            End If
            Dim tmp As String = CType(sender, TextBox).Text.ToUpper()
            If Not (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c OrElse e.KeyChar = "-"c) Then
                e.Handled = True
            End If

            If (e.KeyChar = "."c AndAlso tmp.IndexOf(".") > -1) Then
                e.Handled = True
            End If

            If (e.KeyChar = "-"c AndAlso tmp.IndexOf("-") > -1) Then
                e.Handled = True
            End If

        Catch ex As Exception
            FMessageBox.Show(Me, ex.Message, "Error KeyPressEventNumberOnly_dgvData", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
        End Try
    End Sub
End Class
