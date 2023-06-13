Public Class FChooseColumnRow
    Private m_OK As Boolean
    Private m_Column As Integer
    Private m_Row As Integer
    Public ReadOnly Property OK As Boolean
        Get
            Return m_OK
        End Get
    End Property
    Public ReadOnly Property Column As Integer
        Get
            Return m_Column
        End Get
    End Property

    Public ReadOnly Property Row As Integer
        Get
            Return m_Row
        End Get

    End Property
    Public Sub New(ByVal pPallet As CPallet)
        Me.m_OK = False
        InitializeComponent()
        If (pPallet Is Nothing OrElse pPallet.ListJob Is Nothing OrElse pPallet.ListJob.Count <= 0) Then
            Me.Close()
        End If
        numColumn.Maximum = pPallet.ColumnNumber - 1
        numRow.Maximum = pPallet.RowNumber - 1
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.m_OK = False
        Me.Close()
    End Sub

    Private Sub FChooseColumnRow_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.m_OK = False
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Me.m_OK = True
        Me.m_Column = numColumn.Value
        Me.m_Row = numRow.Value
        Me.Close()
    End Sub
End Class