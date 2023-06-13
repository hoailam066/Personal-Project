Imports System.Globalization
Imports System.Threading
Imports System.Resources
Imports System.Windows.Forms
Imports System.ComponentModel
Imports System.Reflection
Imports System.Windows.Forms.Form

Public Enum Language
    English
    Chinese
End Enum
Public Class CChangeLanguage

    ''' <summary>
    ''' Gets Assembly Name of project
    ''' </summary>
    ''' <returns></returns>
    Public Shared ReadOnly Property AssemblyName As String
        Get
            Return Reflection.Assembly.GetExecutingAssembly().GetName().Name
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets Current language
    ''' </summary>
    Public Shared Cul As CultureInfo = New CultureInfo("zh-TW")
    Public Shared CurLang As Language = Language.Chinese
    Shared Sub New()
        'setLanguage(CurLang)
    End Sub

    ''' <summary>
    ''' Global Resource Manager (xxx.Resource)
    ''' </summary>
    Public Shared Rm As ResourceManager = New ResourceManager(AssemblyName & ".Resource", Reflection.Assembly.GetExecutingAssembly())

    ''' <summary>
    ''' Change language
    ''' </summary>
    ''' <param name="lang">language key. zh: 中文, en: English</param>
    ''' <remarks></remarks>
    Public Shared Sub setLanguage(ByVal lang As Language)
        CurLang = lang
        Select Case (lang)
            Case Language.English
                Cul = New CultureInfo("en-US")
            Case Language.Chinese
                Cul = New CultureInfo("zh-TW")
        End Select
        Try
            System.IO.File.WriteAllText("D:\DataSettings\LaserMachine\MachineData\User\Language.lang", Cul.Name)
        Catch ex As Exception
        End Try
        Thread.CurrentThread.CurrentCulture = Cul
        Thread.CurrentThread.CurrentUICulture = Cul
        Rm = New ResourceManager(AssemblyName & ".Resource", Reflection.Assembly.GetExecutingAssembly())
    End Sub

    ''' <summary>
    ''' Set Text for control
    ''' </summary>
    ''' <param name="ctrl">Control</param>
    ''' <param name="pRm">ResourceManager</param>
    ''' <param name="child">if value is TRUE and ctrl.HasChilds > 0: function will set all child control</param>
    ''' <remarks></remarks>
    Public Shared Sub setTextControl(ByVal ctrl As Control, ByVal pRm As ResourceManager, Optional ByVal child As Boolean = True)
        Try
            If (ctrl.HasChildren And child) Then
                For Each c As Control In ctrl.Controls
                    setTextControl(c, pRm)
                Next
            Else
                If (ctrl.GetType() Is GetType(ComboBox)) Then
                    Try
                        Dim x As ComboBox = CType(ctrl, ComboBox)
                        Dim objcol = x.Items
                        If (objcol.Count > 0) Then
                            objcol(0) = pRm.GetString(x.Name & ".Items")
                            For index = 1 To x.Items.Count - 1
                                objcol(index) = pRm.GetString(x.Name & ".Items" & index)
                            Next
                        End If
                    Catch ex As Exception

                    End Try

                ElseIf (ctrl.GetType() Is GetType(MenuStrip)) Then
                    Dim x As ToolStrip = CType(ctrl, MenuStrip)
                    For Each c As ToolStripMenuItem In x.Items
                        For Each c2 As ToolStripItem In c.DropDownItems
                            c2.Text = pRm.GetString(c2.Name + ".Text")
                        Next
                        c.Text = pRm.GetString(c.Name + ".Text")
                    Next
                End If

            End If
            If (ctrl.GetType() Is GetType(NumericUpDown)) Then
                Return
            ElseIf (ctrl.GetType() Is GetType(DataGridView)) Then
                Dim x As DataGridView = CType(ctrl, DataGridView)
                For col = 0 To x.Columns.Count - 1
                    Dim newtxt As String = pRm.GetString(x.Columns(col).Name & ".HeaderText")
                    If (newtxt IsNot Nothing) Then
                        x.Columns(col).HeaderText = newtxt
                    End If
                Next
            ElseIf (ctrl.GetType() Is GetType(ContextMenuStrip)) Then
                Dim x As ContextMenuStrip = CType(ctrl, ContextMenuStrip)
                For idx = 0 To x.Items.Count - 1
                    x.Items(idx).Text = pRm.GetString(x.Items(idx).Name & ".Text")
                    Dim xx = 0
                Next
            ElseIf (ctrl.GetType() Is GetType(StatusStrip)) Then
                Dim x As StatusStrip = CType(ctrl, StatusStrip)
                For idx = 0 To x.Items.Count - 1
                    x.Items(idx).Text = pRm.GetString(x.Items(idx).Name & ".Text")
                    Dim xx = 0
                Next
            End If

            Dim txt = pRm.GetString(ctrl.Name + ".Text")
            If ctrl.Parent Is Nothing Then
                txt = pRm.GetString("$this.Text")
            End If
            If (txt <> "") Then
                ctrl.Text = txt
            End If
        Catch ex As Exception
        End Try
    End Sub

    ''' <summary>
    ''' Get the string from resource manager
    ''' </summary>
    ''' <param name="key">A keyword to get the string</param>
    ''' <returns></returns>
    Public Shared Function GetString(ByVal key As String) As String
        Dim res As String = ""
        Try
            If (Cul.Name = "zh-TW") Then
                If (key.StartsWith("Step")) Then
                    Dim lineString As String = key.Replace("Step", "")
                    res = "第" & lineString & "步"
                ElseIf (key.StartsWith("LINE")) Then
                    Dim lineString As String = key.Replace("LINE", "")
                    res = "第" & lineString & "線"
                Else
                    res = key
                End If
            Else
                If (key.StartsWith("切: 第")) Then
                    If (key.EndsWith("步測試")) Then
                        Dim lineString As String = key.Replace("切: 第", "")
                        lineString = lineString.Replace("步測試", "")
                        res = "Cut step: Step " & lineString & " Test"
                    ElseIf (key.EndsWith("步完成！")) Then
                        Dim lineString As String = key.Replace("切: 第", "")
                        lineString = lineString.Replace("步完成！", "")
                        res = "Cut step: Step " & lineString & " completed !"
                    ElseIf (key.EndsWith("步已取消！")) Then
                        Dim lineString As String = key.Replace("切: 第", "")
                        lineString = lineString.Replace("步已取消！", "")
                        res = "Cut step: Step " & lineString & " cancelled !"
                    Else
                        Dim lineString As String = key.Replace("切: 第", "")
                        lineString = lineString.Replace("步", "")
                        res = "Cut step: Step " & lineString
                    End If
                ElseIf (key.StartsWith("切:")) Then
                    If (key.EndsWith("測試")) Then
                        Dim lineString As String = key.Replace("切:", "")
                        lineString = lineString.Replace("測試", "")
                        lineString = lineString.Replace("第", "")
                        lineString = lineString.Replace("線", "")
                        res = "Cut line: LINE" & lineString & " Test"
                    ElseIf (key.EndsWith("完成！")) Then
                        Dim lineString As String = key.Replace("切:", "")
                        lineString = lineString.Replace("完成！", "")
                        lineString = lineString.Replace("第", "")
                        lineString = lineString.Replace("線", "")
                        res = "Cut line: LINE" & lineString & " completed !"
                    Else
                        Dim lineString As String = key.Replace("切:", "")
                        lineString = lineString.Replace("第", "")
                        lineString = lineString.Replace("線", "")
                        res = "Cut line: LINE" & lineString
                    End If
                ElseIf (key.StartsWith("第")) Then
                    If (key.EndsWith("線")) Then
                        Dim lineString As String = key.Replace("第", "")
                        lineString = lineString.Replace("線", "")
                        res = "LINE" & lineString
                    ElseIf (key.EndsWith("步")) Then
                        Dim lineString As String = key.Replace("第", "")
                        lineString = lineString.Replace("步", "")
                        res = "Step" & lineString
                    End If
                ElseIf (key.StartsWith("更改第") AndAlso key.EndsWith("步的視覺")) Then
                    Dim lineString As String = key.Replace("更改第", "")
                    lineString = lineString.Replace("步的視覺", "")
                    res = "Change Alginment for work step " & lineString
                Else
                    res = Rm.GetString(key, Cul)
                    If (res Is Nothing) Then
                        res = key
                    End If
                End If
            End If
        Catch ex As Exception
            res = key
        End Try
        Return res
    End Function

    Public Shared Sub ApplyLanguage(ByVal pForm As Form)
        Try
            Dim rm As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(pForm.GetType())
            rm.ApplyResources(pForm, "$this")
            For Each ctrl As Control In pForm.Controls
                If (ctrl.Visible = True AndAlso ctrl.Name <> "lblVersion") Then
                    If (ctrl.HasChildren = True) Then
                        ApplyLanguageChild(ctrl, rm)
                    Else
                        If (ctrl.GetType() Is GetType(StatusStrip)) Then
                            Dim ss As StatusStrip = CType(ctrl, StatusStrip)
                            For i = 0 To ss.Items.Count - 1
                                If (ss.Items(i).Visible = True) Then
                                    Dim e1 As Boolean = ss.Items(i).Enabled
                                    rm.ApplyResources(ss.Items(i), ss.Items(i).Name)
                                    ss.Items(i).Enabled = e1
                                End If
                            Next
                        ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                            Dim cbb As ComboBox = CType(ctrl, ComboBox)
                            If (cbb.Items IsNot Nothing) Then
                                Dim count As Integer = cbb.Items.Count
                                Dim selected As Integer = cbb.SelectedIndex
                                cbb.Items.Clear()
                                For idx = 0 To count - 1
                                    cbb.Items.Add(rm.GetString(cbb.Name & ".Items" & idx.ToString("###")))
                                Next
                                If (cbb.Items.Count > selected) Then
                                    cbb.SelectedIndex = selected
                                End If
                            End If
                        End If
                    End If
                    Dim e As Boolean = ctrl.Enabled
                    rm.ApplyResources(ctrl, ctrl.Name)
                    ctrl.Enabled = e
                End If
            Next

            Dim Method As MethodInfo = pForm.GetType().GetMethod("GetComponents")
            If (Method IsNot Nothing) Then
                Dim components As System.ComponentModel.Container = Method.Invoke(pForm, Nothing)
                For idx = 0 To components.Components.Count - 1
                    Dim type As Type = components.Components(idx).GetType()
                    If (type Is GetType(ContextMenuStrip)) Then
                        Dim cts As ContextMenuStrip = CType(components.Components(idx), ContextMenuStrip)
                        For i = 0 To cts.Items.Count - 1
                            Dim e1 As Boolean = cts.Enabled
                            rm.ApplyResources(cts.Items(i), cts.Items(i).Name)
                            cts.Items(i).Enabled = e1
                        Next
                        Dim e As Boolean = cts.Enabled
                        rm.ApplyResources(cts, cts.Name)
                        cts.Enabled = e
                    Else

                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub
    Private Shared Sub ApplyLanguageChild(ByVal ctrl As Control, ByVal rm As System.ComponentModel.ComponentResourceManager)
        Try
            If (ctrl.HasChildren = True) Then
                For Each child As Control In ctrl.Controls
                    ApplyLanguageChild(child, rm)
                Next
            ElseIf (ctrl.GetType() Is GetType(StatusStrip)) Then
                Dim ss As StatusStrip = CType(ctrl, StatusStrip)
                For i = 0 To ss.Items.Count - 1
                    If (ss.Items(i).Visible = True) Then
                        Dim e1 As Boolean = ss.Items(i).Enabled
                        rm.ApplyResources(ss.Items(i), ss.Items(i).Name)
                        ss.Items(i).Enabled = e1
                    End If
                Next
            ElseIf (ctrl.GetType() Is GetType(ComboBox)) Then
                Dim cbb As ComboBox = CType(ctrl, ComboBox)
                If (cbb.Items IsNot Nothing) Then
                    Dim count As Integer = cbb.Items.Count
                    Dim selected As Integer = cbb.SelectedIndex
                    'cbb.Items.Clear()
                    For idx = 0 To count - 1
                        Dim xxxx = cbb.Name & ".Items" & idx.ToString("###")
                        Dim s = rm.GetString(cbb.Name & ".Items" & idx.ToString("###"))
                        If (s IsNot Nothing) Then
                            cbb.Items(idx) = s
                        End If

                        'cbb.Items.Add(rm.GetString(cbb.Name & ".Items" & idx.ToString("###")))
                    Next
                    If (cbb.Items.Count > selected) Then
                        cbb.SelectedIndex = selected
                    End If
                End If
            End If
            Dim e As Boolean = ctrl.Enabled
            rm.ApplyResources(ctrl, ctrl.Name)
            ctrl.Enabled = e
        Catch ex As Exception
        End Try
    End Sub
End Class
