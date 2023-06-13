Imports System.IO
Imports Newtonsoft.Json
Imports System.ComponentModel

Public Class CProject
    Inherits GlobalizedPropertyGrid.GlobalizedObject
    Public Const PROJECT_PATH As String = "D:\DataSettings\LaserMachine\MachineData\Products\"
    <Category("Common Parameters")>
    <[ReadOnly](True)>
    Public Property ProjectName As String

    <Category("Common Parameters")>
    <[ReadOnly](True)>
    Public Property Time As String

    <Category("Common Parameters")>
    <[ReadOnly](True)>
    Public Property Description As String

    <Browsable(False)>
    Public Property XMin As Double
    <Browsable(False)>
    Public Property YMin As Double
    <Browsable(False)>
    Public Property Width As Double
    <Browsable(False)>
    Public Property Height As Double

    <Category("Common Parameters")>
    <[ReadOnly](True)>
    Public Property WorkStep As Integer

    Public Sub New(ByVal projName As String, ByVal time As String, ByVal xmin As Double, ByVal ymin As Double, ByVal width As Double, ByVal height As Double, ByVal des As String, ByVal workstep As Integer)
        Me.ProjectName = projName
        Me.Time = time
        Me.XMin = xmin
        Me.YMin = ymin
        Me.Width = width
        Me.Height = height
        Me.Description = des
        Me.WorkStep = workstep
    End Sub
    Public Sub New()
        Me.ProjectName = ""
        Me.Time = ""
        Me.XMin = 0
        Me.YMin = 0
        Me.Width = 500
        Me.Height = 500
        Me.Description = ""
        Me.WorkStep = 2
    End Sub
    Public Shared Function SaveProject(ByVal lstProject As List(Of CProject), Optional ByVal errorString As String = "") As Boolean
        SaveProject = True
        Try
            Dim sw As StreamWriter = New StreamWriter(PROJECT_PATH & "project.lsproj", False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(lstProject, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            SaveProject = False
            errorString = ex.Message
        End Try
    End Function
    Public Shared Function LoadProject(ByRef lstProject As List(Of CProject), Optional ByVal errorString As String = "") As Boolean
        LoadProject = True
        Try
            Dim sr As StreamReader = New StreamReader(PROJECT_PATH & "project.lsproj", System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            lstProject = JsonConvert.DeserializeObject(Of List(Of CProject))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
        Catch ex As Exception
            lstProject = New List(Of CProject)
            LoadProject = False
            errorString = ex.Message
        End Try
    End Function
End Class
