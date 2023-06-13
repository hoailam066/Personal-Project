
Public Enum MessageBoxIcon As UInteger
    OK = 0
    [Error] = 1
    [Stop] = 1
    Information = 2
    Warning = 3
    Question = 4
End Enum
Public Class FMessageBox
    Private m_Result As DialogResult = Windows.Forms.DialogResult.None
    Public ReadOnly Property Result As DialogResult
        Get
            Return m_Result
        End Get
    End Property
    Private m_ButtonType As MessageBoxButtons = MessageBoxButtons.OKCancel
    Public Property ButtonType As MessageBoxButtons
        Get
            Return m_ButtonType
        End Get
        Set(value As MessageBoxButtons)
            m_ButtonType = value
        End Set
    End Property
    Private m_IconType As MessageBoxIcon = MessageBoxIcon.Error
    Public Property IconType As MessageBoxIcon
        Get
            Return m_IconType
        End Get
        Set(ByVal value As MessageBoxIcon)
            m_IconType = value
        End Set
    End Property
    Private m_ShowDetail As Boolean = False
    Public Property ShowDetail As Boolean
        Get
            Return m_ShowDetail
        End Get
        Set(ByVal value As Boolean)
            m_ShowDetail = value
        End Set
    End Property
    Private m_Exception As Exception = Nothing
    Private m_ErrorMsg As String = ""
    Public Property Exception As Exception
        Get
            Return m_Exception
        End Get
        Set(ByVal value As Exception)
            m_Exception = value
        End Set
    End Property
    Public Property ErrorMsg As String
        Get
            Return m_ErrorMsg
        End Get
        Set(ByVal value As String)
            m_ErrorMsg = value
        End Set
    End Property
    Private m_Flag As Boolean = False
    Public Property Flag As Boolean
        Get
            Return m_Flag
        End Get
        Set(ByVal value As Boolean)
            m_Flag = value
        End Set
    End Property
    Private m_AutoRunFlag As Boolean = False
    Public Property AutoRunFlag As Boolean
        Get
            Return m_AutoRunFlag
        End Get
        Set(ByVal value As Boolean)
            m_AutoRunFlag = value
        End Set
    End Property

    Public Overloads Shared Function Show(ByVal ErrorString As String, ByVal CaptionText As String, ByVal Button As MessageBoxButtons, ByVal Icon As MessageBoxIcon, Optional ByVal ShowDetail As Boolean = False, Optional ByVal Exception As Exception = Nothing) As DialogResult
        Dim res As DialogResult = Windows.Forms.DialogResult.OK
        Try
            Using frm As FMessageBox = New FMessageBox
                frm.ButtonType = Button
                Select Case Button
                    Case MessageBoxButtons.OK
                        frm.btnCancel.Visible = False
                        frm.btnOK.Visible = True
                    Case MessageBoxButtons.OKCancel
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = True
                        frm.btnOK.Text = CChangeLanguage.GetString("確認") 'OK
                        frm.btnCancel.Text = CChangeLanguage.GetString("取消") 'Cancel
                    Case MessageBoxButtons.YesNo
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = True
                        frm.btnOK.Text = CChangeLanguage.GetString("是") 'Yes
                        frm.btnCancel.Text = CChangeLanguage.GetString("否") 'No
                    Case MessageBoxButtons.AbortRetryIgnore
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = False
                End Select
                Select Case Icon
                    Case MessageBoxIcon.Error, MessageBoxIcon.Stop
                        frm.ptbImage.Image = My.Resources.error0
                        frm.LinkLabel1.Visible = ShowDetail
                        If (ShowDetail = True) Then
                            Dim DetailString As String = ""
                            If (Exception IsNot Nothing) Then
                                DetailString = Exception.Message
                                DetailString &= vbCrLf & "-----------------------"
                                DetailString &= vbCrLf & Exception.StackTrace
                            End If
                            frm.RichTextBox1.Text = DetailString
                        End If
                    Case MessageBoxIcon.Information, System.Windows.Forms.MessageBoxIcon.Information
                        frm.ptbImage.Image = My.Resources.information
                    Case MessageBoxIcon.Question, System.Windows.Forms.MessageBoxIcon.Question
                        frm.ptbImage.Image = My.Resources.help
                    Case MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxIcon.Warning
                        frm.ptbImage.Image = My.Resources.warning
                    Case MessageBoxIcon.OK
                        frm.ptbImage.Image = My.Resources.tickOK
                    Case Else
                        frm.ptbImage.Image = Nothing
                End Select
                frm.ButtonType = Button
                frm.lblMessage.Text = ErrorString
                frm.Text = CaptionText
                frm.Flag = True
                frm.ShowDialog()
                frm.Flag = False
                res = frm.Result
                frm.Dispose()
            End Using
        Catch
            Return Windows.Forms.DialogResult.Cancel
        End Try
        Return res
    End Function
    Public Overloads Shared Function Show(ByVal Owner As IWin32Window, ByVal ErrorString As String, ByVal CaptionText As String, ByVal Button As MessageBoxButtons, ByVal Icon As MessageBoxIcon, Optional ByVal ShowDetail As Boolean = False, Optional ByVal Exception As Exception = Nothing) As DialogResult
        Dim res As DialogResult = Windows.Forms.DialogResult.OK
        Try
            Using frm As FMessageBox = New FMessageBox
                frm.ButtonType = Button
                Select Case Button
                    Case MessageBoxButtons.OK
                        frm.btnCancel.Visible = False
                        frm.btnOK.Visible = True
                    Case MessageBoxButtons.OKCancel
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = True
                        frm.btnOK.Text = CChangeLanguage.GetString("確認") 'OK
                        frm.btnCancel.Text = CChangeLanguage.GetString("取消") 'Cancel
                    Case MessageBoxButtons.YesNo
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = True
                        frm.btnOK.Text = CChangeLanguage.GetString("是") 'Yes
                        frm.btnCancel.Text = CChangeLanguage.GetString("否") 'No
                    Case MessageBoxButtons.AbortRetryIgnore
                        frm.btnCancel.Visible = True
                        frm.btnOK.Visible = False
                End Select
                Select Case Icon
                    Case MessageBoxIcon.Error, MessageBoxIcon.Stop, System.Windows.Forms.MessageBoxIcon.Error
                        frm.ptbImage.Image = My.Resources.error0
                        frm.LinkLabel1.Visible = ShowDetail
                        If (ShowDetail = True) Then
                            Dim DetailString As String = ""
                            If (Exception IsNot Nothing) Then
                                DetailString = Exception.Message
                                DetailString &= vbCrLf & "-----------------------"
                                DetailString &= vbCrLf & Exception.StackTrace
                            End If
                            frm.RichTextBox1.Text = DetailString
                        End If
                    Case MessageBoxIcon.Information, System.Windows.Forms.MessageBoxIcon.Information
                        frm.ptbImage.Image = My.Resources.information
                    Case MessageBoxIcon.Question, System.Windows.Forms.MessageBoxIcon.Question
                        frm.ptbImage.Image = My.Resources.help
                    Case MessageBoxIcon.Warning, System.Windows.Forms.MessageBoxIcon.Warning
                        frm.ptbImage.Image = My.Resources.warning
                    Case MessageBoxIcon.OK
                        frm.ptbImage.Image = My.Resources.tickOK
                    Case Else
                        frm.ptbImage.Image = Nothing
                End Select
                frm.ButtonType = Button
                frm.lblMessage.Text = ErrorString
                frm.Text = CaptionText
                frm.Flag = True
                frm.ShowDialog(Owner)
                frm.Flag = False
                res = frm.Result
                frm.Dispose()
            End Using
        Catch
            Return Windows.Forms.DialogResult.Cancel
        End Try
        Return res
    End Function
    Public Shared Function ShowError(ByVal ErrorString As String, ByVal CaptionText As String, Optional ByVal ShowDetail As Boolean = False, Optional ByVal Exception As Exception = Nothing) As DialogResult
        Try
            Using frm As FMessageBox = New FMessageBox
                frm.ButtonType = MessageBoxButtons.OK
                frm.btnCancel.Visible = False
                frm.btnOK.Visible = True
                frm.lblMessage.Text = ErrorString
                frm.Text = CaptionText
                frm.ptbImage.Image = My.Resources.error0
                frm.LinkLabel1.Visible = ShowDetail
                If (ShowDetail = True) Then
                    Dim DetailString As String = ""
                    If (Exception IsNot Nothing) Then
                        DetailString = Exception.Message
                        DetailString &= vbCrLf & "-----------------------"
                        DetailString &= vbCrLf & Exception.StackTrace
                    End If
                    frm.RichTextBox1.Text = DetailString
                End If
                frm.Flag = True
                frm.ShowDialog()
                frm.Flag = False
                frm.Dispose()
            End Using
        Catch ex As Exception
            MessageBox.Show(ex.Message & vbCrLf & "--- FMessageBox_Load", "Error", MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            Return Windows.Forms.DialogResult.Cancel
        End Try
        Return Windows.Forms.DialogResult.OK
    End Function

    Public Shared Function ShowAgrumentError(ByVal ErrorString As String) As DialogResult
        Using frm As FMessageBox = New FMessageBox
            frm.btnCancel.Visible = False
            frm.btnOK.Visible = True
            frm.lblMessage.Text = ErrorString
            frm.Text = CChangeLanguage.GetString("參數異常")
            frm.ptbImage.Image = My.Resources.error0
            frm.Flag = True
            frm.Show()
            frm.Flag = False
            frm.Dispose()
        End Using
        Return Windows.Forms.DialogResult.OK
    End Function

    Private Sub btnOK_Click(sender As System.Object, e As System.EventArgs) Handles btnOK.Click
        Select Case m_ButtonType
            Case MessageBoxButtons.OK, MessageBoxButtons.OKCancel
                m_Result = Windows.Forms.DialogResult.OK
            Case MessageBoxButtons.YesNo, MessageBoxButtons.YesNoCancel
                m_Result = Windows.Forms.DialogResult.Yes
            Case Else
                m_Result = Windows.Forms.DialogResult.OK
        End Select
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Select Case m_ButtonType
            Case MessageBoxButtons.OK, MessageBoxButtons.OKCancel
                m_Result = Windows.Forms.DialogResult.Cancel
            Case MessageBoxButtons.YesNo, MessageBoxButtons.YesNoCancel
                m_Result = Windows.Forms.DialogResult.No
            Case Else
                m_Result = Windows.Forms.DialogResult.Cancel
        End Select
        Me.Close()
    End Sub

    Private Sub FMessageBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.TextChanged
        Label1.Text = Me.Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        btnCancel_Click(Nothing, Nothing)
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If (m_ShowDetail) Then
            Me.Size = New Size(500, 220)
            RichTextBox1.Visible = False
            LinkLabel1.Text = CChangeLanguage.GetString("詳情") & ": ▼"
        Else
            Me.Size = New Size(500, 400)
            RichTextBox1.Visible = True
            LinkLabel1.Text = CChangeLanguage.GetString("詳情") & ": ▲"
        End If
        m_ShowDetail = Not m_ShowDetail
    End Sub

    Private Sub FMessageBox_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Me.Size = New Size(500, 220)
        RichTextBox1.Visible = False
        If (Me.Flag = False OrElse m_AutoRunFlag = True) Then
            Try
                Select Case Me.ButtonType
                    Case MessageBoxButtons.OK
                        btnCancel.Visible = False
                        btnOK.Visible = True
                    Case MessageBoxButtons.OKCancel
                        btnCancel.Visible = True
                        btnOK.Visible = True
                        btnOK.Text = CChangeLanguage.GetString("確認") 'OK
                        btnCancel.Text = CChangeLanguage.GetString("取消") 'Cancel
                    Case MessageBoxButtons.YesNo
                        btnCancel.Visible = True
                        btnOK.Visible = True
                        btnOK.Text = CChangeLanguage.GetString("是") 'Yes
                        btnCancel.Text = CChangeLanguage.GetString("否") 'No
                    Case MessageBoxButtons.AbortRetryIgnore
                        btnCancel.Visible = True
                        btnOK.Visible = False
                End Select
                Select Case Me.IconType
                    Case MessageBoxIcon.Error, MessageBoxIcon.Stop
                        ptbImage.Image = My.Resources.error0
                        LinkLabel1.Visible = Me.ShowDetail
                        If (Me.ShowDetail = True) Then
                            Dim DetailString As String = ""
                            If (Me.Exception IsNot Nothing) Then
                                DetailString = Me.Exception.Message
                                DetailString &= vbCrLf & "-----------------------"
                                DetailString &= vbCrLf & Me.Exception.StackTrace
                            End If
                            RichTextBox1.Text = DetailString
                        End If
                    Case MessageBoxIcon.Information
                        ptbImage.Image = My.Resources.information
                    Case MessageBoxIcon.Question
                        ptbImage.Image = My.Resources.help
                    Case MessageBoxIcon.Warning
                        ptbImage.Image = My.Resources.warning
                    Case MessageBoxIcon.OK
                        ptbImage.Image = My.Resources.tickOK
                    Case Else
                        ptbImage.Image = Nothing
                End Select

                lblMessage.Text = Me.ErrorMsg

            Catch ex As Exception
                MessageBox.Show(ex.Message & vbCrLf & "--- FMessageBox_Load", "Error", MessageBoxButtons.OK, Windows.Forms.MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub FMessageBox_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        GroupBoxEx1.Size = Me.Size
    End Sub
    Private m_isClick As Boolean = False
    Private m_FirstPoint As Point
    Private Sub Label1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseDown
        m_isClick = True
        m_FirstPoint = e.Location
    End Sub
    Private Sub Label1_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        m_isClick = False
    End Sub

    Private Sub Label1_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseMove
        If (m_isClick = True) Then
            If (m_FirstPoint.X > e.Location.X) Then
                Me.Left = Me.Left - (m_FirstPoint.X - e.Location.X)
            ElseIf (m_FirstPoint.X < e.Location.X) Then
                Me.Left = Me.Left - (m_FirstPoint.X - e.Location.X)
            End If
            If (m_FirstPoint.Y > e.Location.Y) Then
                Me.Top = Me.Top - (m_FirstPoint.Y - e.Location.Y)
            ElseIf (m_FirstPoint.Y < e.Location.Y) Then
                Me.Top = Me.Top - (m_FirstPoint.Y - e.Location.Y)
            End If
        End If
    End Sub

    Public Sub New()
        CChangeLanguage.setLanguage(CChangeLanguage.CurLang)
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

  
End Class