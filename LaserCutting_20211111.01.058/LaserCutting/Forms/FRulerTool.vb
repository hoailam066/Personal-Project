Public Class FRulerTool
    Private m_Ruler As CRuler
    Private m_Help As Boolean
    Public Sub New(ByRef pRuler As CRuler)
        InitializeComponent()
        m_Ruler = pRuler
        m_Help = False
    End Sub

    Private Sub FEditRuler_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PropertyGrid1.SelectedObject = m_Ruler
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If (m_Help = False) Then
            m_Help = True
            Me.Size = New Point(800, 500)
        Else
            m_Help = False
            Me.Size = New Point(300, 500)
        End If
    End Sub
End Class