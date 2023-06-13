Imports System.IO
Imports System.ComponentModel
Imports Newtonsoft.Json
Public Enum enumLogType
    OpenClose
    StartStop
    [Error]
    Edit
End Enum
Public Class Clog
    Private m_User As String
    Private m_DateAndTime As DateTime
    Private m_LogString As String
    Private m_OldValue As String
    Private m_NewValue As String
    Private m_NumParam As Integer
    Private m_LogType As enumLogType
    Public Property DateAndTime As DateTime
        Get
            Return m_DateAndTime
        End Get
        Set(ByVal value As DateTime)
            m_DateAndTime = value
        End Set
    End Property
    Public Property LogString As String
        Get
            Return m_LogString
        End Get
        Set(ByVal value As String)
            m_LogString = value
        End Set
    End Property
    Public Property OldValue As String
        Get
            Return m_OldValue
        End Get
        Set(ByVal value As String)
            m_OldValue = value
        End Set
    End Property
    Public Property NewValue As String
        Get
            Return m_NewValue
        End Get
        Set(ByVal value As String)
            m_NewValue = value
        End Set
    End Property
    Public Property NumPram As Integer
        Get
            Return m_NumParam
        End Get
        Set(ByVal value As Integer)
            m_NumParam = value
        End Set
    End Property
    Public Property LogType As enumLogType
        Get
            Return m_LogType
        End Get
        Set(value As enumLogType)
            m_LogType = value
        End Set
    End Property
    Public Sub New()
        m_User = CLoginInformation.CurrentUser.Username
        m_DateAndTime = DateTime.Now
        m_LogString = ""
        m_OldValue = ""
        m_NewValue = ""
        m_NumParam = 2
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="pLogString">Log string</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pLogString As String, pLogType As enumLogType)
        m_User = CLoginInformation.CurrentUser.Username
        m_DateAndTime = DateTime.Now
        m_LogString = pLogString
        m_NumParam = 2
        m_LogType = pLogType
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="pLogString">Log string</param>
    ''' <param name="pNewValue">New value</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pLogString As String, ByVal pNewValue As String, pLogType As enumLogType)
        m_User = CLoginInformation.CurrentUser.Username
        m_DateAndTime = DateTime.Now
        m_LogString = pLogString
        m_NewValue = pNewValue
        m_NumParam = 3
        m_LogType = pLogType
    End Sub

    ''' <summary>
    ''' Constructor
    ''' </summary>
    ''' <param name="pParamName">Parameter name</param>
    ''' <param name="pOldValue">Old value</param>
    ''' <param name="pNewValue">New value</param>
    ''' <remarks></remarks>
    Public Sub New(ByVal pParamName As String, ByVal pOldValue As String, ByVal pNewValue As String, pLogType As enumLogType)
        m_User = CLoginInformation.CurrentUser.Username
        m_DateAndTime = DateTime.Now
        m_LogString = pParamName
        m_OldValue = pOldValue
        m_NewValue = pNewValue
        m_NumParam = 4
        m_LogType = pLogType
    End Sub
End Class



Public Module MLog
    Public Const LOG_PATH As String = "D:\DataSettings\LaserMachine\Logs\"
    Public Function LoadLog(ByRef plstLog As List(Of Clog), Optional ByVal pPath As String = "", Optional ByRef errorString As String = "") As Boolean
        LoadLog = True
        Try
            If (pPath = "") Then
                pPath = CheckRunLogLocation() & DateTime.Now.ToString("yyyyMMdd") & ".log"
            End If
            If (Not File.Exists(pPath)) Then
                Dim sw As StreamWriter = New StreamWriter(pPath)
                sw.Close()
                sw.Dispose()
                plstLog = New List(Of Clog)
            Else
                Try
                    Dim sr As StreamReader = New StreamReader(pPath)
                    Dim res As String = sr.ReadToEnd()
                    sr.Close()
                    sr.Dispose()
                    plstLog = JsonConvert.DeserializeObject(Of List(Of Clog))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
                Catch ex As Exception
                    plstLog = New List(Of Clog)
                End Try
            End If
        Catch ex As Exception
            LoadLog = False
            errorString = ex.Message
            plstLog = New List(Of Clog)
        End Try
    End Function
    Public Function SaveLog(ByVal plstLog As List(Of Clog), Optional ByVal pPath As String = "", Optional ByRef errorString As String = "") As Boolean
        SaveLog = True
        Try
            If (pPath = "") Then
                pPath = CheckRunLogLocation() & DateTime.Now.ToString("yyyyMMdd") & ".log"
            End If
            Dim oldLog As New List(Of Clog)
            LoadLog(oldLog, pPath)
            oldLog.AddRange(plstLog.ToArray())
            If (Not File.Exists(pPath)) Then
                Dim sw As StreamWriter = New StreamWriter(pPath)
                sw.Close()
                sw.Dispose()
            End If
            Dim res As String = JsonConvert.SerializeObject(oldLog, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw1 As StreamWriter = New StreamWriter(pPath, False)
            sw1.Write(res)
            sw1.Close()
            sw1.Dispose()
        Catch ex As Exception
            SaveLog = False
            errorString = ex.Message
        End Try
    End Function

    Public Function SaveLog(ByVal pLog As Clog, Optional ByVal pPath As String = "", Optional ByRef errorString As String = "") As Boolean
        SaveLog = True
        Try
            If (pPath = "") Then
                pPath = CheckRunLogLocation() & DateTime.Now.ToString("yyyyMMdd") & ".log"
            End If
            Dim oldLog As New List(Of Clog)
            LoadLog(oldLog, pPath)
            oldLog.Add(pLog)
            If (Not File.Exists(pPath)) Then
                Dim sw As StreamWriter = New StreamWriter(pPath)
                sw.Close()
                sw.Dispose()
            End If
            Dim res As String = JsonConvert.SerializeObject(oldLog, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw1 As StreamWriter = New StreamWriter(pPath, False)
            sw1.Write(res)
            sw1.Close()
            sw1.Dispose()
        Catch ex As Exception
            SaveLog = False
            errorString = ex.Message
        End Try
    End Function


    Public Function SaveLog(ByVal pLogString As String, pLogType As enumLogType, Optional ByVal pPath As String = "") As Boolean
        SaveLog = True
        Try
            If (pPath = "") Then
                pPath = CheckRunLogLocation() & DateTime.Now.ToString("yyyyMMdd") & ".log"
            End If
            Dim oldLog As New List(Of Clog)
            LoadLog(oldLog, pPath)
            oldLog.Add(New Clog(pLogString, pLogType))
            If (Not File.Exists(pPath)) Then
                Dim sw As StreamWriter = New StreamWriter(pPath)
                sw.Close()
                sw.Dispose()
            End If
            Dim res As String = JsonConvert.SerializeObject(oldLog, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw1 As StreamWriter = New StreamWriter(pPath, False)
            sw1.Write(res)
            sw1.Close()
            sw1.Dispose()
        Catch ex As Exception
            SaveLog = False

        End Try
    End Function

    Public Function SaveLog(ByVal pParameterName As String, ByVal pOldValue As String, ByVal pNewValue As String, pLogType As enumLogType, Optional ByVal pPath As String = "", Optional ByRef errorString As String = "") As Boolean
        SaveLog = True
        Try
            If (pPath = "") Then
                pPath = CheckRunLogLocation() & DateTime.Now.ToString("yyyyMMdd") & ".log"
            End If
            Dim oldLog As New List(Of Clog)
            LoadLog(oldLog, pPath)
            oldLog.Add(New Clog(pParameterName, pOldValue, pNewValue, pLogType))
            If (Not File.Exists(pPath)) Then
                Dim sw As StreamWriter = New StreamWriter(pPath)
                sw.Close()
                sw.Dispose()
            End If
            Dim res As String = JsonConvert.SerializeObject(oldLog, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw1 As StreamWriter = New StreamWriter(pPath, False)
            sw1.Write(res)
            sw1.Close()
            sw1.Dispose()
        Catch ex As Exception
            SaveLog = False
            errorString = ex.Message
        End Try
    End Function
    Public Function CheckRunLogLocation() As String
        If (Not Directory.Exists(LOG_PATH)) Then
            Directory.CreateDirectory(LOG_PATH)
        End If
        Return LOG_PATH
    End Function
End Module
