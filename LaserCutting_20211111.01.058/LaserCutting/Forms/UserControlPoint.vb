Public Class UserControlPoint
    Public Event NumX_KeyUp(ByVal row As Integer, ByVal col As Integer)
    Public Event NumY_KeyUp(ByVal row As Integer, ByVal col As Integer)
    Public Event NumX_MouseClick(ByVal row As Integer, ByVal col As Integer)
    Public Event NumY_MouseClick(ByVal row As Integer, ByVal col As Integer)
    Public Property X As Decimal
        Get
            Return numX.Value
        End Get
        Set(ByVal value As Decimal)
            numX.Value = value
        End Set
    End Property
    Public Property Y As Decimal
        Get
            Return numY.Value
        End Get
        Set(ByVal value As Decimal)
            numY.Value = value
        End Set
    End Property
    Public Property DecimalPlaces As UInteger
        Get
            Return CUInt(numX.DecimalPlaces)
        End Get
        Set(ByVal value As UInteger)
            numX.DecimalPlaces = CInt(value)
            numY.DecimalPlaces = CInt(value)
        End Set
    End Property

    Private Sub MenumY_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numY.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Dim tmp = Me.Name.Split("_"c)
            RaiseEvent NumY_KeyUp(CInt(tmp(1)), CInt(tmp(2)))
        End If
    End Sub
    Private Sub MenumX_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles numX.KeyUp
        If (e.KeyCode = Keys.Enter) Then
            Dim tmp = Me.Name.Split("_"c)
            RaiseEvent NumX_KeyUp(CInt(tmp(1)), CInt(tmp(2)))
        End If
    End Sub

    Private Sub MenumX_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numX.MouseClick
        Dim tmp = Me.Name.Split("_"c)
        RaiseEvent NumX_MouseClick(CInt(tmp(1)), CInt(tmp(2)))
    End Sub

    Private Sub MenumY_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numY.MouseClick
        Dim tmp = Me.Name.Split("_"c)
        RaiseEvent NumY_MouseClick(CInt(tmp(1)), CInt(tmp(2)))
    End Sub
End Class
