Public Class FLoading
    Private m_Percent As Integer = 0
    Private m_Text
    Public Sub New(ByVal pText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        m_Text = pText
        Me.Text = m_Text
        ProgressBarEx1.Value = 0
        ProgressBarEx1.TextShow = m_Text
        ProgressBarEx1.Invalidate()
        Me.Invalidate()

    End Sub
    Public Property Percent As UInteger
        Get
            Return m_Percent
        End Get
        Set(ByVal value As UInteger)
            m_Percent = value

            If (m_Percent > 100) Then
                m_Percent = 100
            End If
            ProgressBarEx1.Value = m_Percent
            If (m_Percent >= ProgressBarEx1.Maximum) Then
                ProgressBarEx1.Refresh()
                Threading.Thread.Sleep(50)
                Me.Close()
            Else
                Threading.Thread.Sleep(50)
            End If
        End Set
    End Property

End Class