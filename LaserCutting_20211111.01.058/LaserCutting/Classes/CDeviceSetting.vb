Imports System.IO
Imports Newtonsoft.Json
Public Class CIOSetting
    Public Key As String
    Public Address As String
    Public [Type] As Integer
    Public Bit As Integer
    Public Value As Integer
    Public Recipe As String
    Public Sub New()
        Me.Key = ""
        Me.Address = 0
        Me.Type = 0
        Me.Bit = 0
        Me.Value = 0
        Me.Recipe = "0"
    End Sub
    Public Sub New(key As String, address As String, type As Integer, bit As Integer, value As Integer, recipe As String)
        Me.Key = key
        Me.Address = address
        Me.Type = type
        Me.Bit = bit
        Me.Value = value
        Me.Recipe = recipe
    End Sub
End Class
Public Class CRobotSetting
    Public Key As String
    Public Command As String
    Public Address As Integer
    Public [Type] As Type
    Public Value As Object
    Public Sub New()
        Me.Key = ""
        Me.Command = ""
        Me.Address = 0
        Me.Type = GetType(Integer)
        Me.Value = 0
    End Sub
    Public Sub New(key As String, command As String, address As Integer, type As Type, value As Object)
        Me.Key = key
        Me.Command = command
        Me.Address = address
        Me.Type = type
        Me.Value = value
    End Sub
    Public Overloads Function [GetType]() As String
        If (Type Is GetType(Integer) OrElse Type Is GetType(Int32)) Then
            Return "INTEGER"
        ElseIf (Type Is GetType(Single)) Then
            Return "FLOAT"
        ElseIf (Type Is GetType(Double)) Then
            Return "DOUBLE"
        ElseIf (Type Is GetType(Boolean)) Then
            Return "BOOL"
        Else
            Return "STRING"
        End If
    End Function
End Class

Public Class CDataSetting
    Public Key As String
    Public Address As String
    Public [Type] As Type
    Public Value As Object

    Public Sub New()
        Me.Key = ""
        Me.Address = 0
        Me.Type = GetType(Integer)
        Me.Value = 0
    End Sub
    Public Sub New(key As String, address As Integer, type As Type, value As Object)
        Me.Key = key
        Me.Address = address
        Me.Type = type
        Me.Value = value
    End Sub
    Public Overloads Function [GetType]() As String
        If (Type Is GetType(Integer) OrElse Type Is GetType(Int32)) Then
            Return "INTEGER"
        ElseIf (Type Is GetType(Single)) Then
            Return "FLOAT"
        ElseIf (Type Is GetType(Double)) Then
            Return "DOUBLE"
        ElseIf (Type Is GetType(Boolean)) Then
            Return "BOOL"
        Else
            Return "STRING"
        End If
    End Function
End Class

Public Class CConnectionSetting
    Public RobotIP As String
    Public RobotPort As Integer
    Public GigECameraID As Integer
    Public GigECameraIP As String
    Public GigECameraPort As Integer
    Public USBCameraID As Integer
    Public LaserControllerEthernet As Boolean
    Public LaserControllerIP As String
    Public LaserControllerPort As Integer
    Public LaserControllerComport As Integer
    Public LaserControllerBaudrate As Integer
    Public BarcodeComport As Integer
    Public BarcodeBaudrate As Integer
    Public LaserSensorComport As Integer
    Public LaserSensorBaudrate As Integer
    Public TempControllerComport As Integer
    Public TempControllerBaudrate As Integer
End Class

Public Module CDeviceSetting
    Public Const SETTING_PATH As String = "D:\DataSettings\LaserMachine\Setting\"
    Public Sub CheckPath()
        If (Not Directory.Exists(SETTING_PATH)) Then
            Directory.CreateDirectory(SETTING_PATH)
        End If
    End Sub
    Public Function GetIOSetting() As List(Of CIOSetting)
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "IOSetting.set"
            Dim lst As List(Of CIOSetting) = New List(Of CIOSetting)
            If (Not File.Exists(path)) Then
                Return lst
            End If

            Dim sr As StreamReader = New StreamReader(path, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            lst = JsonConvert.DeserializeObject(Of List(Of CIOSetting))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Return lst
        Catch
            Return New List(Of CIOSetting)
        End Try
    End Function
    Public Sub SaveIOSetting(lstIO As List(Of CIOSetting))
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "IOSetting.set"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(lstIO, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch
        End Try
    End Sub

    Public Function GetRobotSetting() As List(Of CRobotSetting)
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "RobotSetting.set"
            Dim lst As List(Of CRobotSetting) = New List(Of CRobotSetting)
            If (Not File.Exists(path)) Then
                lst.Add(New CRobotSetting("MaxVelocity", "", 0, GetType(Integer), 20))
                lst.Add(New CRobotSetting("MaxStepVelocity", "", 0, GetType(Integer), 150))
                lst.Add(New CRobotSetting("Acceleration", "", 0, GetType(Integer), 90))
                lst.Add(New CRobotSetting("Deceleration", "", 0, GetType(Integer), 90))
                lst.Add(New CRobotSetting("Arch", "", 0, GetType(Single), 1))
                lst.Add(New CRobotSetting("RAxisChannel", "", 0, GetType(Integer), 1))
                lst.Add(New CRobotSetting("SAxisChannel", "", 0, GetType(Integer), 1))
                lst.Add(New CRobotSetting("AxisReverse", "", 0, GetType(Integer), 1))
                lst.Add(New CRobotSetting("FirstStageLimit", "", 0, GetType(Single), 300))
                lst.Add(New CRobotSetting("FreeStagePos", "", 0, GetType(Single), 650))
                lst.Add(New CRobotSetting("SecondYAxisID", "", 0, GetType(Integer), 3))
                lst.Add(New CRobotSetting("X-Axis Direction", "", 0, GetType(Integer), 1))
                lst.Add(New CRobotSetting("Y-Axis Direction", "", 0, GetType(Integer), -1))
                lst.Add(New CRobotSetting("X-Axis MinPos", "", 0, GetType(Single), -40))
                lst.Add(New CRobotSetting("X-Axis MaxPos", "", 0, GetType(Single), 900))
                lst.Add(New CRobotSetting("Y-Axis MinPos", "", 0, GetType(Single), -40))
                lst.Add(New CRobotSetting("Y-Axis MaxPos", "", 0, GetType(Single), 900))
                lst.Add(New CRobotSetting("Z-Axis MinPos", "", 0, GetType(Single), -15))
                lst.Add(New CRobotSetting("Z-Axis MaxPos", "", 0, GetType(Single), 100))
                lst.Add(New CRobotSetting("Z-Axis ReadyPos", "", 0, GetType(Single), 10))
                SaveRobotSetting(lst)
                Return lst
            End If

            Dim sr As StreamReader = New StreamReader(path, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            lst = JsonConvert.DeserializeObject(Of List(Of CRobotSetting))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Return lst
        Catch
            Return New List(Of CRobotSetting)
        End Try
    End Function
    Public Sub SaveRobotSetting(lstRobotSetting As List(Of CRobotSetting))
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "RobotSetting.set"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(lstRobotSetting, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch
        End Try
    End Sub

    Public Function GetDataSetting() As List(Of CDataSetting)
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "DataSetting.set"
            Dim lst As List(Of CDataSetting) = New List(Of CDataSetting)
            If (Not File.Exists(path)) Then
                lst.Add(New CDataSetting("PowerCheckHour", 346, GetType(Integer), 1000))
                lst.Add(New CDataSetting("WireCheckEnable", 346, GetType(Integer), 1))
                lst.Add(New CDataSetting("DefaultJobHeight", 301, GetType(Single), 79.392))
                lst.Add(New CDataSetting("DefaultJobAngle", 304, GetType(Single), 0))
                lst.Add(New CDataSetting("IsJobRunning", 1, GetType(Integer), 0))
                lst.Add(New CDataSetting("AirBlowing", 1, GetType(Integer), 0))
                lst.Add(New CDataSetting("IsAlignOK", 1, GetType(Integer), 1))
                lst.Add(New CDataSetting("IsBarcodeOK", 1, GetType(Integer), 1))
                lst.Add(New CDataSetting("JobReadySignal", 1, GetType(Integer), 1))
                lst.Add(New CDataSetting("UnlockOffset", 1, GetType(Integer), 1))
                lst.Add(New CDataSetting("OrientationOffset", 1, GetType(Single), 0))
                lst.Add(New CDataSetting("XscaleFactor", 1, GetType(Single), 1.0))
                lst.Add(New CDataSetting("YscaleFactor", 1, GetType(Single), 1.0))
                lst.Add(New CDataSetting("DefaultTemperature", 1, GetType(Single), 300))
                lst.Add(New CDataSetting("TemperatureLimit", 1, GetType(Integer), 450))
                lst.Add(New CDataSetting("DefaultLight", 1, GetType(Integer), 170))
                lst.Add(New CDataSetting("TotalLotCount", 1, GetType(Integer), 459))
                lst.Add(New CDataSetting("RunningTime", 1, GetType(Single), 0))
                lst.Add(New CDataSetting("RecordingDate", 1, GetType(Integer), 15))
                lst.Add(New CDataSetting("DischargeOK", 1, GetType(Integer), 0))
                SaveDataSetting(lst)
                Return lst
            End If
            Dim sr As StreamReader = New StreamReader(path, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            lst = JsonConvert.DeserializeObject(Of List(Of CDataSetting))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Return lst
        Catch
            Return New List(Of CDataSetting)
        End Try
    End Function
    Public Sub SaveDataSetting(ByVal lst As List(Of CDataSetting))
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "DataSetting.set"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(lst, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch
        End Try
    End Sub

    Public Function GetConnectionSetting() As CConnectionSetting
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "ConnectionSetting.set"
            Dim result As CConnectionSetting = New CConnectionSetting()
            If (Not File.Exists(path)) Then
                With result
                    .RobotIP = "192.168.1.10"
                    .RobotPort = 9007
                    .GigECameraID = 0
                    .GigECameraIP = "192.168.1.100"
                    .GigECameraPort = 0
                    .USBCameraID = 0
                    .LaserControllerEthernet = False
                    .LaserControllerIP = ""
                    .LaserControllerPort = 0
                    .LaserControllerComport = 1
                    .LaserControllerBaudrate = 115200
                    .BarcodeComport = 9
                    .BarcodeBaudrate = 115200
                    .LaserSensorComport = 3
                    .LaserSensorBaudrate = 9600
                    .TempControllerComport = 3
                    .LaserSensorBaudrate = 9600
                End With
                SaveConnectionSetting(result)
                Return result
            End If
            Dim sr As StreamReader = New StreamReader(path, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            result = JsonConvert.DeserializeObject(Of CConnectionSetting)(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Return result
        Catch
            Return New CConnectionSetting()
        End Try
    End Function
    Public Sub SaveConnectionSetting(ByVal cnn As CConnectionSetting)
        Try
            CheckPath()
            Dim path As String = SETTING_PATH & "ConnectionSetting.set"
            Dim sw As StreamWriter = New StreamWriter(path, False, System.Text.Encoding.Default)
            Dim res As String = JsonConvert.SerializeObject(cnn, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            sw.WriteLine(res)
            sw.Close()
            sw.Dispose()
        Catch
        End Try
    End Sub
End Module