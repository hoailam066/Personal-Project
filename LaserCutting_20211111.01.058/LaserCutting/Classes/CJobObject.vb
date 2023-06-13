Imports System.ComponentModel
Imports System.IO
Imports Newtonsoft.Json
Imports System.Globalization

Public Enum eRepeatMode As Integer
    Mode1
    Mode2
End Enum
Public Enum eRepeatModeMerge As Integer
    NoSet
    Mode1
    Mode2
End Enum

Public Class CLine
    Inherits GlobalizedPropertyGrid.GlobalizedObject
    Private m_Id As String
    Private m_IsSelected As Boolean
    Private m_Name As String = "LINE"
    Private m_StartX As Double
    Private m_StartY As Double
    Private m_EndX As Double
    Private m_EndY As Double
    Private m_StartXPx As Double
    Private m_StartYPx As Double
    Private m_EndXPx As Double
    Private m_EndYPx As Double
    Private m_JumpSpeed As Integer
    Private m_MarkSpeed As Integer
    Private m_RepeatCount As Integer
    Private m_JumpDelay As Integer
    Private m_MarkDelay As Integer
    Private m_PolygonDelay As Integer
    Private m_LaserOnDelay As Integer
    Private m_LaserOffDelay As Integer
    Private m_RepeatMode As eRepeatMode
    Private m_Step As Integer
    Private m_OffsetX As Double
    Private m_OffsetY As Double
    Private m_Angle As Double
    Private m_PRR As Double
    Private m_Power As Double
    'Private m_LaserOn As Boolean = False
    <[ReadOnly](True)>
    Public ReadOnly Property ID As String
        Get
            Return m_Id
        End Get
    End Property
    <Browsable(False)>
    Public Property IsSelected As Boolean
        Get
            Return m_IsSelected
        End Get
        Set(ByVal value As Boolean)
            m_IsSelected = value
        End Set
    End Property
    <[ReadOnly](True)>
    Public Property Name As String
        Get
            Return m_Name
        End Get
        Set(ByVal value As String)
            m_Name = value
        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    Public Property StartX As Double
        Get
            Return Math.Round(m_StartX, 3)
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("開始 X"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_StartX = value
                FMain.GalvoPositionToImagePoints(m_StartX, m_StartY, m_StartXPx, m_StartYPx)
                'm_StartXPx = FMain.X0 + (value / FMain.PX2MM)
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(True)>
    Public Property StartXPX As Double
        Get
            Return m_StartXPx
        End Get
        Set(ByVal value As Double)
            If (MLineManager.LoadingProject = False) Then
                m_StartXPx = value
                FMain.ImagePointsToGalvoPosition(m_StartXPx, m_StartYPx, m_StartX, m_StartY)
                'm_StartX = CInt((value - FMain.X0) * FMain.PX2MM)
            End If

        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    Public Property StartY As Double
        Get
            Return Math.Round(m_StartY, 3)
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("開始 Y"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_StartY = value
                FMain.GalvoPositionToImagePoints(m_StartX, m_StartY, m_StartXPx, m_StartYPx)
                'm_StartYPx = FMain.ViewImageHeight - (CInt(value / FMain.PX2MM) + FMain.Y0)
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(True)>
    Public Property StartYPX As Double
        Get
            Return m_StartYPx
        End Get
        Set(ByVal value As Double)
            If (MLineManager.LoadingProject = False) Then
                m_StartYPx = value
                FMain.ImagePointsToGalvoPosition(m_StartXPx, m_StartYPx, m_StartX, m_StartY)
                'm_StartY = CInt((FMain.ViewImageHeight - value - FMain.Y0) * FMain.PX2MM)
            End If

        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    Public Property EndX As Double
        Get
            Return Math.Round(m_EndX, 3)
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("結束 X"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_EndX = value
                FMain.GalvoPositionToImagePoints(m_EndX, m_EndY, m_EndXPx, m_EndYPx)
                'm_EndXPx = FMain.X0 + (value / FMain.PX2MM)
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(True)>
    Public Property EndXPX As Double
        Get
            Return m_EndXPx
        End Get
        Set(ByVal value As Double)
            If (MLineManager.LoadingProject = False) Then
                m_EndXPx = value
                FMain.ImagePointsToGalvoPosition(m_EndXPx, m_EndYPx, m_EndX, m_EndY)
                'm_EndX = CInt((value - FMain.X0) * FMain.PX2MM)
            End If

        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    Public Property EndY As Double
        Get
            Return Math.Round(m_EndY, 3)
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("結束 Y"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_EndY = value
                FMain.GalvoPositionToImagePoints(m_EndX, m_EndY, m_EndXPx, m_EndYPx)
                'm_EndYPx = FMain.ViewImageHeight - (CInt(value / FMain.PX2MM) + FMain.Y0)
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Image Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(True)>
    Public Property EndYPX As Double
        Get
            Return m_EndYPx
        End Get
        Set(ByVal value As Double)
            If (MLineManager.LoadingProject = False) Then
                m_EndYPx = value
                FMain.ImagePointsToGalvoPosition(m_EndXPx, m_EndYPx, m_EndX, m_EndY)
                'm_EndY = CInt((FMain.ViewImageHeight - value - FMain.Y0) * FMain.PX2MM)
            End If

        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property Distance As Double
        Get
            Return Math.Round(Math.Sqrt(Math.Pow((m_EndX - m_StartX), 2) + Math.Pow((m_EndY - m_StartY), 2)), 3)
        End Get
        Set(ByVal value As Double)
            Dim delta As Double = Math.Sqrt(Math.Pow((m_EndX - m_StartX), 2) + Math.Pow((m_EndY - m_StartY), 2)) - value
            Dim a As Double = FMain.CalAngle(m_StartX, m_StartY, m_EndX, m_EndY)
            Dim newSX, newSY, newEX, newEY As Double
            FMain.NewPos(m_StartX, m_StartY, -a, newSX, newSY)
            FMain.NewPos(m_EndX, m_EndY, -a, newEX, newEY)
            If (delta < 0) Then 'Add
                If (m_StartX < m_EndX) Then
                    newSX += delta / 2
                    newEX -= delta / 2
                Else
                    newSX += delta / 2
                    newEX -= delta / 2

                End If
            ElseIf (delta > 0) Then 'Minus
                If (m_StartX < m_EndX) Then
                    newSX += delta / 2
                    newEX -= delta / 2
                Else
                    newSX += delta / 2
                    newEX -= delta / 2

                End If
            End If
            FMain.NewPos(newSX, newSY, a, StartX, StartY)
            FMain.NewPos(newEX, newEY, a, EndX, EndY)
        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(False)>
    Public Property OffsetX As Double
        Get
            Return 0
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("偏移") & " X", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    StartX += value
                    EndX += value
                Catch ex As Exception
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("偏移") & " X", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
    <Browsable(False)>
    Public Property OffsetY As Double
        Get
            Return 0
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("偏移") & " Y", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    StartY += value
                    EndY += value
                Catch ex As Exception
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("偏移") & " Y", MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try
            End If
        End Set
    End Property

    ''' <summary>
    '''  On  Galvo Coordinate
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(DoubleTypeConverter))>
     <Browsable(False)>
    Public Property Angle As Double
        Get
            Return 0
        End Get
        Set(ByVal value As Double)
            If (Double.IsNaN(value)) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("角度"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                Try
                    Dim x, y As Double
                    Dim xc As Double = (m_StartX + m_EndX) / 2
                    Dim yc As Double = (m_StartY + m_EndY) / 2
                    Call NewPos(0, 0, value, xc, yc, m_StartX, m_StartY, x, y)
                    StartX = x
                    StartY = y
                    Call NewPos(0, 0, value, xc, yc, m_EndX, m_EndY, x, y)
                    EndX = x
                    EndY = y
                Catch ex As Exception
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("角度"), MessageBoxButtons.OK, MessageBoxIcon.Error, True, ex)
                End Try
            End If
        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 1 OrElse value > 50000) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[1...50000].", "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_JumpSpeed = value
            End If

        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property MarkSpeed As Integer
        Get
            Return m_MarkSpeed
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 1 OrElse value > 50000) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[1...50000].", "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_MarkSpeed = value
            End If

        End Set
    End Property

    ''' <summary>
    ''' Start is 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property RepeatCount As Integer
        Get
            Return m_RepeatCount
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("重複次數"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 1) Then
                FMessageBox.Show(CChangeLanguage.GetString("重複計數必須大於 1。"), CChangeLanguage.GetString("重複次數"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_RepeatCount = value
            End If
        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property JumpDelay As Integer
        Get
            Return m_JumpDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670]", "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_JumpDelay = value
            End If
        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property MarkDelay As Integer
        Get
            Return m_MarkDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670]", "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_MarkDelay = value
            End If
        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property PolygonDelay As Integer
        Get
            Return m_PolygonDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 0 OrElse value > 327670) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670].", "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_PolygonDelay = value
            End If

        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property LaserOnDelay As Integer
        Get
            Return m_LaserOnDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("雷射開啟延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < -8000 OrElse value > 8000) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[-8000...8000].", CChangeLanguage.GetString("雷射開啟延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_LaserOnDelay = value
            End If

        End Set
    End Property

    <TypeConverter(GetType(IntegerTypeConverter))>
    Public Property LaserOffDelay As Integer
        Get
            Return m_LaserOffDelay
        End Get
        Set(ByVal value As Integer)
            If (value = Integer.MaxValue) Then
                FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("雷射關閉延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            ElseIf (value < 2 OrElse value > 8000) Then
                FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[2...8000].", CChangeLanguage.GetString("雷射關閉延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                m_LaserOffDelay = value
            End If

        End Set
    End Property

    Public Property RepeatMode As eRepeatMode
        Get
            Return m_RepeatMode
        End Get
        Set(ByVal value As eRepeatMode)
            m_RepeatMode = value
        End Set
    End Property

    Public Property LaserPower As Double
        Get
            Return m_Power
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                value = 0
            ElseIf (value > 100) Then
                value = 100
            End If
            m_Power = value
        End Set
    End Property

    Public Property LaserPRR As Double
        Get
            Return m_PRR
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                value = 0
            ElseIf (value > 100) Then
                value = 100
            End If
            m_PRR = value
        End Set
    End Property

    <[ReadOnly](True)>
    Public Property [Step] As Integer
        Get
            Return m_Step
        End Get
        Set(ByVal value As Integer)
            m_Step = value
        End Set
    End Property

    Public Sub New()
        StartX = 0
        StartY = 0
        EndX = 1
        EndY = 1
        m_JumpSpeed = 100
        m_MarkSpeed = 50
        m_JumpDelay = 10
        m_MarkDelay = 10
        m_RepeatCount = 10
        m_PolygonDelay = 10
        m_LaserOnDelay = 10
        m_LaserOffDelay = 10
        m_Power = 80
        m_PRR = 20
        'm_LaserOn = True
        Threading.Thread.Sleep(1)
        m_Id = "L" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
    End Sub
    Public Function Clone() As CLine
        Dim res As CLine = New CLine()
        Try
            res.m_EndX = Me.m_EndX
            res.m_EndXPx = Me.m_EndXPx
            res.m_EndY = Me.m_EndY
            res.m_EndYPx = Me.m_EndYPx
            res.m_Id = Me.m_Id
            res.m_IsSelected = Me.m_IsSelected
            res.m_JumpDelay = Me.m_JumpDelay
            res.m_JumpSpeed = Me.m_JumpSpeed
            res.m_LaserOffDelay = Me.m_LaserOffDelay
            res.m_LaserOnDelay = Me.m_LaserOnDelay
            res.m_MarkDelay = Me.m_MarkDelay
            res.m_MarkSpeed = Me.m_MarkSpeed
            res.m_Name = Me.m_Name
            res.m_Step = Me.m_Step
            res.m_PolygonDelay = Me.m_PolygonDelay
            res.m_RepeatCount = Me.m_RepeatCount
            res.m_RepeatMode = Me.m_RepeatMode
            res.m_StartX = Me.m_StartX
            res.m_StartXPx = Me.m_StartXPx
            res.m_StartY = Me.m_StartY
            res.m_StartYPx = Me.m_StartYPx
            res.m_Power = Me.m_Power
            res.m_PRR = Me.m_PRR
        Catch ex As Exception
        End Try
        Return res
    End Function
    Public Function CloneNewID()
        Dim res As CLine = New CLine()
        Try
            res.m_EndX = Me.m_EndX
            res.m_EndXPx = Me.m_EndXPx
            res.m_EndY = Me.m_EndY
            res.m_EndYPx = Me.m_EndYPx
            res.m_Id = "L" & DateTime.Now.ToString("yyyyMMddHHmmssfff")
            res.m_IsSelected = Me.m_IsSelected
            res.m_JumpDelay = Me.m_JumpDelay
            res.m_JumpSpeed = Me.m_JumpSpeed
            res.m_LaserOffDelay = Me.m_LaserOffDelay
            res.m_LaserOnDelay = Me.m_LaserOnDelay
            res.m_MarkDelay = Me.m_MarkDelay
            res.m_MarkSpeed = Me.m_MarkSpeed
            res.m_Name = Me.m_Name
            res.m_Step = Me.m_Step
            res.m_PolygonDelay = Me.m_PolygonDelay
            res.m_RepeatCount = Me.m_RepeatCount
            res.m_RepeatMode = Me.m_RepeatMode
            res.m_StartX = Me.m_StartX
            res.m_StartXPx = Me.m_StartXPx
            res.m_StartY = Me.m_StartY
            res.m_StartYPx = Me.m_StartYPx
            res.m_Power = Me.m_Power
            res.m_PRR = Me.m_PRR
        Catch ex As Exception
        End Try
        Return res
    End Function
    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        Try
            If (obj.GetType() IsNot GetType(CLine)) Then
                Return False
            End If
            Dim res As CLine = CType(obj, CLine)
            If (Math.Abs(res.m_EndX - Me.m_EndX) >= 0.001) Then
                Return False
            End If
            If (Math.Abs(res.m_EndY - Me.m_EndY) >= 0.001) Then
                Return False
            End If
            If (res.m_Id <> Me.m_Id) Then
                Return False
            End If
            If (res.m_JumpDelay <> Me.m_JumpDelay) Then
                Return False
            End If
            If (res.m_JumpSpeed <> Me.m_JumpSpeed) Then
                Return False
            End If
            If (res.m_LaserOffDelay <> Me.m_LaserOffDelay) Then
                Return False
            End If
            If (res.m_LaserOnDelay <> Me.m_LaserOnDelay) Then
                Return False
            End If
            If (res.m_MarkDelay <> Me.m_MarkDelay) Then
                Return False
            End If
            If (res.m_MarkSpeed <> Me.m_MarkSpeed) Then
                Return False
            End If
            If (res.m_Name <> Me.m_Name) Then
                Return False
            End If
            If (res.m_Step <> Me.m_Step) Then
                Return False
            End If
            If (res.m_PolygonDelay <> Me.m_PolygonDelay) Then
                Return False
            End If
            If (res.m_RepeatCount <> Me.m_RepeatCount) Then
                Return False
            End If
            If (res.m_RepeatMode <> Me.m_RepeatMode) Then
                Return False
            End If
            If (Math.Abs(res.m_StartX - Me.m_StartX) >= 0.001) Then
                Return False
            End If
            If (Math.Abs(res.m_StartY - Me.m_StartY) >= 0.001) Then
                Return False
            End If
            If (res.m_Power <> Me.m_Power) Then
                Return False
            End If
            If (res.m_PRR <> Me.m_PRR) Then
                Return False
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Shared Sub NewPos(ByVal pXOffset As Double, ByVal pYOffset As Double, ByVal pAngle As Double, ByVal pXCenter As Double, ByVal pYCenter As Double, ByVal pXOriginal As Double, ByVal pYOriginal As Double, ByRef pNewX As Double, ByRef pNewY As Double)
        pNewX = -9999999999
        pNewY = -9999999999

        Try
            pXOriginal -= pXCenter
            pYOriginal -= pYCenter

            pAngle = Math.PI * (pAngle / 180.0)
            pNewX = pXOriginal * Math.Cos(pAngle) - pYOriginal * Math.Sin(pAngle)
            pNewY = pXOriginal * Math.Sin(pAngle) + pYOriginal * Math.Cos(pAngle)

            pNewX += pXCenter + pXOffset
            pNewY += pYCenter + pYOffset

        Catch ex As Exception

        End Try
    End Sub

    Public Overrides Function ToString() As String
        Dim x As String = Me.Name.Replace("LINE", "")
        Dim idx As Integer = 0
        Integer.TryParse(x, idx)
        Return String.Format("第{0}線", idx)
    End Function
    Public Sub Refresh()
        Try
            FMain.ImagePointsToGalvoPosition(m_StartXPx, m_StartYPx, m_StartX, m_StartY)
            FMain.ImagePointsToGalvoPosition(m_EndXPx, m_EndYPx, m_EndX, m_EndY)
        Catch ex As Exception
        End Try
    End Sub
End Class

Public Class CMerge
    Inherits GlobalizedPropertyGrid.GlobalizedObject
    Private m_JumpSpeed As String
    Private m_MarkSpeed As String
    Private m_RepeatCount As String
    Private m_JumpDelay As String
    Private m_MarkDelay As String
    Private m_PolygonDelay As String
    Private m_LaserOnDelay As String
    Private m_LaserOffDelay As String
    Private m_RepeatMode As eRepeatModeMerge
    Private m_PRR As String
    Private m_Power As String

    Public Property JumpSpeed As String
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_JumpSpeed = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 1 OrElse numValue > 50000) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[1...50000].", "Jump Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_JumpSpeed = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property MarkSpeed As String
        Get
            Return m_MarkSpeed
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_MarkSpeed = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 1 OrElse numValue > 50000) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[1...50000].", "Mark Speed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_MarkSpeed = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    ''' <summary>
    ''' Start is 1
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property RepeatCount As String
        Get
            Return m_RepeatCount
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_RepeatCount = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("重複次數"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 1) Then
                        FMessageBox.Show(CChangeLanguage.GetString("重複計數必須大於 1。"), CChangeLanguage.GetString("重複次數"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_RepeatCount = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property JumpDelay As String
        Get
            Return m_JumpDelay
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_JumpDelay = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 0 OrElse numValue > 327670) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670]", "Jump Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_JumpDelay = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property MarkDelay As String
        Get
            Return m_MarkDelay
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_MarkDelay = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 0 OrElse numValue > 327670) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670]", "Mark Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_MarkDelay = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property
    Public Property PolygonDelay As String
        Get
            Return m_PolygonDelay
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_PolygonDelay = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 0 OrElse numValue > 327670) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[0...327670]", "Polygon Delay", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_PolygonDelay = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property LaserOnDelay As String
        Get
            Return m_LaserOnDelay
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_LaserOnDelay = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("雷射開啟延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < -8000 OrElse numValue > 8000) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[-8000...8000]", CChangeLanguage.GetString("雷射開啟延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_LaserOnDelay = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property LaserOffDelay As String
        Get
            Return m_LaserOffDelay
        End Get
        Set(ByVal value As String)
            Dim numValue As Integer
            If (value = "") Then
                m_LaserOffDelay = ""
            Else
                If (Integer.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("雷射關閉延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 2 OrElse numValue > 8000) Then
                        FMessageBox.Show(CChangeLanguage.GetString("值必須在範圍內") & "[2...8000]", CChangeLanguage.GetString("雷射關閉延遲"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        m_LaserOffDelay = numValue.ToString()
                    End If
                End If
            End If
        End Set
    End Property

    Public Property RepeatMode As eRepeatModeMerge
        Get
            Return m_RepeatMode
        End Get
        Set(ByVal value As eRepeatModeMerge)
            m_RepeatMode = value
        End Set
    End Property

    Public Property LaserPower As String
        Get
            Return m_Power
        End Get
        Set(ByVal value As String)
            Dim numValue As Double
            If (value = "") Then
                m_Power = ""
            Else
                If (Double.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("功率"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 0) Then
                        numValue = 0
                    ElseIf (numValue > 100) Then
                        numValue = 100
                    End If
                    m_Power = numValue.ToString()
                End If
            End If
        End Set
    End Property

    Public Property LaserPRR As String
        Get
            Return m_PRR
        End Get
        Set(ByVal value As String)
            Dim numValue As Double
            If (value = "") Then
                m_PRR = ""
            Else
                If (Double.TryParse(value, numValue) = False) Then
                    FMessageBox.Show(CChangeLanguage.GetString("無效值"), CChangeLanguage.GetString("頻率"), MessageBoxButtons.OK, MessageBoxIcon.Error)
                Else
                    If (numValue < 0) Then
                        numValue = 0
                    ElseIf (numValue > 100) Then
                        numValue = 100
                    End If
                    m_PRR = numValue.ToString()
                End If
            End If
        End Set
    End Property
    Public Sub New()
        m_JumpSpeed = ""
        m_MarkSpeed = ""
        m_JumpDelay = ""
        m_MarkDelay = ""
        m_RepeatCount = ""
        m_PolygonDelay = ""
        m_LaserOnDelay = ""
        m_LaserOffDelay = ""
        m_Power = ""
        m_PRR = ""
        m_RepeatMode = eRepeatModeMerge.NoSet
    End Sub
    <Browsable(False)>
    Public ReadOnly Property IsEmpty As Boolean
        Get
            If (m_JumpSpeed <> "") Then Return False
            If (m_MarkSpeed <> "") Then Return False
            If (m_JumpDelay <> "") Then Return False
            If (m_MarkDelay <> "") Then Return False
            If (m_RepeatCount <> "") Then Return False
            If (m_PolygonDelay <> "") Then Return False
            If (m_LaserOnDelay <> "") Then Return False
            If (m_LaserOffDelay <> "") Then Return False
            If (m_Power <> "") Then Return False
            If (m_PRR <> "") Then Return False
            If (m_RepeatMode <> eRepeatModeMerge.NoSet) Then Return False
            Return True
        End Get
    End Property
End Class

Public Class DoubleTypeConverter
    Inherits TypeConverter

    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType = GetType(String)
    End Function

    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        If TypeOf value Is String Then
            Dim s As String = CStr(value)
            Dim v As Double = 0
            If (Double.TryParse(s, v)) Then
                Return v
            Else
                Return Double.NaN
            End If
            'Return Double.Parse(s, culture)
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If destinationType = GetType(String) Then Return (CDbl(value)).ToString("F3", culture)
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class

Public Class IntegerTypeConverter
    Inherits TypeConverter

    Public Overrides Function CanConvertFrom(ByVal context As ITypeDescriptorContext, ByVal sourceType As Type) As Boolean
        Return sourceType = GetType(String)
    End Function

    Public Overrides Function ConvertFrom(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object) As Object
        If TypeOf value Is String Then
            Dim s As String = CStr(value)
            Dim v As Integer = 0
            If (Integer.TryParse(s, v)) Then
                Return v
            Else
                Return Integer.MaxValue
            End If
            'Return Double.Parse(s, culture)
        End If

        Return MyBase.ConvertFrom(context, culture, value)
    End Function

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As CultureInfo, ByVal value As Object, ByVal destinationType As Type) As Object
        If destinationType = GetType(String) Then Return (CInt(value)).ToString()
        Return MyBase.ConvertTo(context, culture, value, destinationType)
    End Function
End Class





#Region "Laser solder code"

Public Class CListJob
    Public Const MAX_LEVEL As Integer = 5
    Private m_lstJob As List(Of CJobObject) = New List(Of CJobObject)
    Private m_lstSortedJob As List(Of CJobObject) = New List(Of CJobObject)
    Private m_AlignId As Integer
    Private m_ListAlign As List(Of CJobObject)
    Private m_CurAlign(-1) As List(Of Integer)

    Public Sub AddJob(ByVal job As CJobObject)
        If (m_lstJob Is Nothing) Then
            m_lstJob = New List(Of CJobObject)
        End If
        m_lstJob.Add(job)
    End Sub

    Public Sub InsertJob(ByVal index As UInteger, ByVal job As CJobObject)
        If (m_lstJob Is Nothing AndAlso index >= 0 AndAlso index < m_lstJob.Count) Then
            m_lstJob.Insert(index, job)
        End If
    End Sub

    Public Sub RemoveJob(ByVal job As CJobObject)
        If (m_lstJob Is Nothing) Then
            m_lstJob.Remove(job)
        End If
    End Sub

    Public Sub RemoveJobAt(ByVal index As UInteger)
        If (m_lstJob Is Nothing AndAlso index >= 0 AndAlso index < m_lstJob.Count) Then
            m_lstJob.RemoveAt(index)
        End If
    End Sub

    Public Function GetJob(ByVal index As Integer) As CJobObject
        Try
            If (m_lstJob Is Nothing) Then
                Return Nothing
            ElseIf (index < 0 OrElse index >= m_lstJob.Count) Then
                Return Nothing
            End If
            Return m_lstJob.Item(index)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Public Function GetSortedJob(ByVal index As Integer) As CJobObject
        Try
            If (m_lstSortedJob Is Nothing) Then
                Return Nothing
            ElseIf (index < 0 OrElse index >= m_lstSortedJob.Count) Then
                Return Nothing
            End If
            Return m_lstSortedJob.Item(index)
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Sub Clear()
        If (m_lstJob Is Nothing) Then
            m_lstJob = New List(Of CJobObject)
        Else
            m_lstJob.Clear()
        End If
    End Sub

    Public ReadOnly Property Count As Integer
        Get
            Return m_lstJob.Count
        End Get
    End Property

    Public Property Jobs As List(Of CJobObject)
        Get
            Return m_lstJob
        End Get
        Set(ByVal value As List(Of CJobObject))
            m_lstJob = value
        End Set
    End Property

    Public ReadOnly Property ListJobs(ByVal idx As Integer) As CJobObject
        Get
            If (m_lstJob Is Nothing) Then
                Return Nothing
            ElseIf (idx < 0 OrElse idx >= m_lstJob.Count) Then
                Return Nothing
            Else
                Return m_lstJob(idx)
            End If
        End Get
    End Property

    Public ReadOnly Property ListAlign As List(Of CJobObject)
        Get
            Return m_ListAlign
        End Get
    End Property
    Public ReadOnly Property ListAlign(ByVal idx As Integer) As CAlign
        Get
            If (m_ListAlign Is Nothing) Then
                Return Nothing
            ElseIf (idx < 0 OrElse idx >= m_ListAlign.Count) Then
                Return Nothing
            Else
                Return CType(m_ListAlign(idx), CAlign)
            End If
        End Get
    End Property

    Public ReadOnly Property SortedJobs As List(Of CJobObject)
        Get
            Return m_lstSortedJob
        End Get
    End Property

    Public ReadOnly Property SortedJobs(ByVal idx As Integer) As CJobObject
        Get
            If (m_lstSortedJob Is Nothing) Then
                Return Nothing
            ElseIf (idx < 0 OrElse idx >= m_lstSortedJob.Count) Then
                Return Nothing
            Else
                Return m_lstSortedJob(idx)
            End If
        End Get
    End Property

    Public Function Clone() As CListJob
        Dim tmp As New CListJob
        For i = 0 To Me.Count - 1
            tmp.AddJob(Me.GetJob(i).Clone())
        Next
        Return tmp
    End Function

    Private Function SortJob(ByVal listJOb As CListJob) As List(Of CJobObject)
        Dim res As List(Of CJobObject) = New List(Of CJobObject)
        If (listJOb.Count > 0) Then
            Dim i As Integer = 0
            While i < listJOb.Count
                If (listJOb.GetJob(i).GetType() Is GetType(CRepeat)) Then
                    Dim rp As CRepeat = CType(listJOb.GetJob(i), CRepeat)
                    For index2 = 1 To rp.RepeatNumber
                        If (listJOb.GetJob(i).CanHasChild AndAlso listJOb.GetJob(i).ListJob.Count > 0) Then
                            res.AddRange(SortJob(listJOb.GetJob(i).ListJob))
                        End If
                    Next
                ElseIf (listJOb.GetJob(i).GetType() Is GetType(CPallet)) Then
                    Dim pallet As CPallet = CType(listJOb.GetJob(i), CPallet)
                    If (pallet.ListJob.Count > 0) Then
                        Dim p0 As CPoint = Nothing
                        Dim res2 As New List(Of CJobObject)
                        Dim stepDisX As Double = 1
                        Dim stepDisY As Double = 1
                        Dim row As Integer = 0
                        Dim col As Integer = 0
                        Dim countStep As Integer = 1
                        Dim lstPoint As New List(Of CPoint)

                        For p = 0 To pallet.ListJob.Count - 1
                            If (pallet.ListJob.GetJob(p).GetType() Is GetType(CPoint)) Then
                                lstPoint.Add(CType(pallet.ListJob.GetJob(p), CPoint))
                            End If
                        Next
                        Dim RowColIndex(lstPoint.Count - 1, 1) As Integer
                        Dim lstCountStep(lstPoint.Count - 1) As Integer

                        For c = 0 To lstCountStep.Length - 1
                            lstCountStep(c) = 1
                        Next

                        If (pallet.OrderType = eOrderType.S_Shape) Then
                            If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                                For j = 0 To pallet.ListJob.Count - 1
                                    If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                                        stepDisX = 1
                                        For r = 0 To pallet.RowNumber - 1
                                            For c = 0 To pallet.ColumnNumber - 1
                                                p0 = pallet.ListJob.GetJob(j).Clone()
                                                If (stepDisX > 0) Then
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += r * pallet.RowDistance
                                                Else
                                                    p0.Point.X += pallet.ColumnDistance * (pallet.ColumnNumber - c - 1)
                                                    p0.Point.Y += r * pallet.RowDistance
                                                End If
                                                p0.InPallet = True
                                                res2.Add(p0)
                                            Next
                                            stepDisX *= -1
                                        Next

                                    ElseIf (pallet.ListJob.GetJob(j).GetType() Is GetType(CRepeat)) Then
                                        Dim rp As CRepeat = CType(pallet.ListJob.GetJob(j), CRepeat)
                                        For index2 = 1 To rp.RepeatNumber
                                            If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                                res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                            End If
                                        Next
                                    Else
                                        res2.Add(pallet.ListJob.GetJob(j))
                                        If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                            res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                        End If
                                    End If
                                Next


                                For j = 0 To res2.Count - 1
                                    If (res2(j).GetType() Is GetType(CPoint)) Then
                                        p0 = CType(res2(j), CPoint)
                                        If (p0.InPallet) Then
                                            Dim idxRowCol As Integer = -1
                                            For idx = 0 To lstPoint.Count - 1
                                                If (p0.ID = lstPoint(idx).ID) Then
                                                    idxRowCol = idx
                                                    Exit For
                                                End If
                                            Next
                                            If (idxRowCol >= 0) Then
                                                p0.RowNumber = RowColIndex(idxRowCol, 0)
                                                p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                                RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                                If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber OrElse RowColIndex(idxRowCol, 1) = -1) Then
                                                    RowColIndex(idxRowCol, 0) += 1
                                                    lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                                    RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                                End If
                                            End If
                                        Else
                                            p0.RowNumber = 0
                                            p0.ColumnNumber = 0
                                        End If
                                    End If
                                Next

                            Else
                                For j = 0 To pallet.ListJob.Count - 1
                                    If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                                        stepDisY = 1
                                        For c = 0 To pallet.ColumnNumber - 1
                                            For r = 0 To pallet.RowNumber - 1
                                                p0 = pallet.ListJob.GetJob(j).Clone()
                                                If (stepDisY > 0) Then
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += r * pallet.RowDistance
                                                Else
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                                End If
                                                p0.InPallet = True
                                                res2.Add(p0)
                                            Next
                                            stepDisY *= -1
                                        Next

                                    ElseIf (pallet.ListJob.GetJob(j).GetType() Is GetType(CRepeat)) Then
                                        Dim rp As CRepeat = CType(pallet.ListJob.GetJob(j), CRepeat)
                                        For index2 = 1 To rp.RepeatNumber
                                            If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                                res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                            End If
                                        Next
                                    Else
                                        res2.Add(pallet.ListJob.GetJob(j))
                                        If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                            res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                        End If
                                    End If
                                Next

                                For j = 0 To res2.Count - 1
                                    If (res2(j).GetType() Is GetType(CPoint)) Then
                                        p0 = CType(res2(j), CPoint)
                                        If (p0.InPallet) Then
                                            Dim idxRowCol As Integer = -1
                                            For idx = 0 To lstPoint.Count - 1
                                                If (p0.ID = lstPoint(idx).ID) Then
                                                    idxRowCol = idx
                                                    Exit For
                                                End If
                                            Next
                                            If (idxRowCol >= 0) Then
                                                p0.RowNumber = RowColIndex(idxRowCol, 0)
                                                p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                                RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                                If (RowColIndex(idxRowCol, 0) = pallet.RowNumber OrElse RowColIndex(idxRowCol, 0) = -1) Then
                                                    RowColIndex(idxRowCol, 1) += 1
                                                    lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                                    RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                                End If
                                            End If
                                        Else
                                            p0.RowNumber = 0
                                            p0.ColumnNumber = 0
                                        End If
                                    End If
                                Next
                            End If

                        Else
                            If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                                For j = 0 To pallet.ListJob.Count - 1
                                    If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                                        For r = 0 To pallet.RowNumber - 1
                                            For c = 0 To pallet.ColumnNumber - 1
                                                p0 = pallet.ListJob.GetJob(j).Clone()
                                                If (stepDisY > 0) Then
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += r * pallet.RowDistance
                                                Else
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r)
                                                End If
                                                p0.InPallet = True
                                                res2.Add(p0)
                                            Next
                                        Next

                                    ElseIf (pallet.ListJob.GetJob(j).GetType() Is GetType(CRepeat)) Then
                                        Dim rp As CRepeat = CType(pallet.ListJob.GetJob(j), CRepeat)
                                        For index2 = 1 To rp.RepeatNumber
                                            If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                                res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                            End If
                                        Next
                                    Else
                                        res2.Add(pallet.ListJob.GetJob(j))
                                        If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                            res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                        End If
                                    End If
                                Next

                                For j = 0 To res2.Count - 1
                                    If (res2(j).GetType() Is GetType(CPoint)) Then
                                        p0 = CType(res2(j), CPoint)
                                        If (p0.InPallet) Then

                                            Dim idxRowCol As Integer = -1
                                            For idx = 0 To lstPoint.Count - 1
                                                If (p0.ID = lstPoint(idx).ID) Then
                                                    idxRowCol = idx
                                                    Exit For
                                                End If
                                            Next

                                            If (idxRowCol >= 0) Then
                                                p0.RowNumber = RowColIndex(idxRowCol, 0)
                                                p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                                RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                                If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber) Then
                                                    RowColIndex(idxRowCol, 0) += 1
                                                    RowColIndex(idxRowCol, 1) = 0
                                                End If
                                            End If

                                        Else
                                            p0.RowNumber = 0
                                            p0.ColumnNumber = 0
                                        End If
                                    End If
                                Next
                            Else
                                For j = 0 To pallet.ListJob.Count - 1
                                    If (pallet.ListJob.GetJob(j).GetType() Is GetType(CPoint)) Then
                                        For c = 0 To pallet.ColumnNumber - 1
                                            For r = 0 To pallet.RowNumber - 1
                                                p0 = pallet.ListJob.GetJob(j).Clone()
                                                If (stepDisY > 0) Then
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += r * pallet.RowDistance
                                                Else
                                                    p0.Point.X += c * pallet.ColumnDistance
                                                    p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                                End If
                                                p0.InPallet = True
                                                res2.Add(p0)
                                            Next
                                        Next
                                    ElseIf (pallet.ListJob.GetJob(j).GetType() Is GetType(CRepeat)) Then
                                        Dim rp As CRepeat = CType(pallet.ListJob.GetJob(j), CRepeat)
                                        For index2 = 1 To rp.RepeatNumber
                                            If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                                res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                            End If
                                        Next
                                    Else
                                        res2.Add(pallet.ListJob.GetJob(j))
                                        If (pallet.ListJob.GetJob(j).CanHasChild AndAlso pallet.ListJob.GetJob(j).ListJob.Count > 0) Then
                                            res2.AddRange(SortJob(pallet.ListJob.GetJob(j).ListJob))
                                        End If
                                    End If
                                Next


                                For j = 0 To res2.Count - 1
                                    If (res2(j).GetType() Is GetType(CPoint)) Then
                                        p0 = CType(res2(j), CPoint)
                                        If (p0.InPallet) Then

                                            Dim idxRowCol As Integer = -1
                                            For idx = 0 To lstPoint.Count - 1
                                                If (p0.ID = lstPoint(idx).ID) Then
                                                    idxRowCol = idx
                                                    Exit For
                                                End If
                                            Next

                                            If (idxRowCol >= 0) Then
                                                p0.RowNumber = RowColIndex(idxRowCol, 0)
                                                p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                                RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                                If (RowColIndex(idxRowCol, 0) = pallet.RowNumber) Then
                                                    RowColIndex(idxRowCol, 1) += 1
                                                    RowColIndex(idxRowCol, 0) = 0
                                                End If
                                            End If
                                        Else
                                            p0.RowNumber = 0
                                            p0.ColumnNumber = 0
                                        End If
                                    End If
                                Next
                            End If
                        End If
                        res.AddRange(res2)
                    End If

                Else
                    If (listJOb.GetJob(i).CanHasChild = False) Then
                        If (listJOb.GetJob(i).GetType() Is GetType(CPoint)) Then
                            Dim p As CPoint = listJOb.GetJob(i)
                            p.InPallet = False
                        End If
                        res.Add(listJOb.GetJob(i))
                    Else
                        Dim res2 = SortJob(listJOb.GetJob(i).ListJob)
                        res.Add(listJOb.GetJob(i))
                        res.AddRange(res2)
                    End If
                End If
                i += 1
            End While
        End If
        Return res
    End Function

    Private Sub SortAlignID()
        For idx = 0 To m_lstJob.Count - 1
            If (m_lstJob(idx).CanHasChild = False) Then
                If (m_lstJob(idx).GetType() Is GetType(CAlign)) Then
                    m_AlignId += 1
                    m_lstJob(idx).AlignID = m_AlignId
                    m_ListAlign.Add(m_lstJob(idx))
                    m_CurAlign(m_lstJob(idx).Level).Add(m_AlignId)
                Else
                    m_lstJob(idx).AlignID = m_CurAlign(m_lstJob(idx).Level)(m_CurAlign(m_lstJob(idx).Level).Count - 1)
                End If
            Else
                SortAlignID2(m_lstJob(idx).ListJob)
            End If
        Next

    End Sub

    Private Sub SortAlignID2(ByVal listJob As CListJob)
        For idx = 0 To listJob.Count - 1
            If (listJob.GetJob(idx).CanHasChild = False) Then
                If (listJob.GetJob(idx).GetType() Is GetType(CAlign)) Then
                    m_AlignId += 1
                    listJob.GetJob(idx).AlignID = m_AlignId
                    m_ListAlign.Add(listJob.GetJob(idx))
                    m_CurAlign(listJob.GetJob(idx).Level).Add(m_AlignId)
                Else
                    listJob.GetJob(idx).AlignID = m_CurAlign(listJob.GetJob(idx).Level)(m_CurAlign(listJob.GetJob(idx).Level).Count - 1)
                End If
            Else
                SortAlignID2(listJob.GetJob(idx).ListJob)
            End If
        Next
    End Sub

    Private Function GetPalletJobs(ByVal pallet As CPallet) As List(Of CJobObject)
        Dim result As New List(Of CJobObject)
        Try
            If (pallet.ListJob.Count > 0) Then
                Dim p0 As CPoint = Nothing
                Dim res As New List(Of CJobObject)
                Dim stepDisX As Double = 1
                Dim stepDisY As Double = 1
                Dim row As Integer = 0
                Dim col As Integer = 0
                Dim countStep As Integer = 1
                Dim lstPoint As New List(Of CPoint)

                For p = 0 To pallet.ListJob.Count - 1
                    If (pallet.ListJob.GetJob(p).GetType() Is GetType(CPoint)) Then
                        lstPoint.Add(CType(pallet.ListJob.GetJob(p), CPoint))
                    End If
                Next
                Dim RowColIndex(lstPoint.Count - 1, 1) As Integer
                Dim lstCountStep(lstPoint.Count - 1) As Integer

                For c = 0 To lstCountStep.Length - 1
                    lstCountStep(c) = 1
                Next

                If (pallet.OrderType = eOrderType.S_Shape) Then
                    If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                        For i = 0 To pallet.ListJob.Count - 1
                            If (pallet.ListJob.GetJob(i).GetType() Is GetType(CPoint)) Then
                                stepDisX = 1
                                For r = 0 To pallet.RowNumber - 1
                                    For c = 0 To pallet.ColumnNumber - 1
                                        p0 = pallet.ListJob.GetJob(i).Clone()
                                        If (stepDisX > 0) Then
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += r * pallet.RowDistance
                                        Else
                                            p0.Point.X += pallet.ColumnDistance * (pallet.ColumnNumber - c - 1)
                                            p0.Point.Y += r * pallet.RowDistance
                                        End If
                                        p0.InPallet = True
                                        res.Add(p0)
                                    Next
                                    stepDisX *= -1
                                Next

                            ElseIf (pallet.ListJob.GetJob(i).GetType() Is GetType(CRepeat)) Then
                                Dim rp As CRepeat = CType(pallet.ListJob.GetJob(i), CRepeat)
                                For index2 = 1 To rp.RepeatNumber
                                    If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                        res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                    End If
                                Next
                            Else
                                res.Add(pallet.ListJob.GetJob(i))
                                If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                    res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                End If
                            End If
                        Next


                        For i = 0 To res.Count - 1
                            If (res(i).GetType() Is GetType(CPoint)) Then
                                p0 = CType(res(i), CPoint)
                                If (p0.InPallet) Then
                                    Dim idxRowCol As Integer = -1
                                    For idx = 0 To lstPoint.Count - 1
                                        If (p0.ID = lstPoint(idx).ID) Then
                                            idxRowCol = idx
                                            Exit For
                                        End If
                                    Next
                                    If (idxRowCol >= 0) Then
                                        p0.RowNumber = RowColIndex(idxRowCol, 0)
                                        p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                        RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                        If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber OrElse RowColIndex(idxRowCol, 1) = -1) Then
                                            RowColIndex(idxRowCol, 0) += 1
                                            lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                            RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                        End If
                                    End If
                                Else
                                    p0.RowNumber = 0
                                    p0.ColumnNumber = 0
                                End If
                            End If
                        Next
                    Else

                        For i = 0 To pallet.ListJob.Count - 1
                            If (pallet.ListJob.GetJob(i).GetType() Is GetType(CPoint)) Then
                                stepDisY = 1
                                For c = 0 To pallet.ColumnNumber - 1
                                    For r = 0 To pallet.RowNumber - 1
                                        p0 = pallet.ListJob.GetJob(i).Clone()
                                        If (stepDisY > 0) Then
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += r * pallet.RowDistance
                                        Else
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                        End If
                                        p0.InPallet = True
                                        res.Add(p0)
                                    Next
                                    stepDisY *= -1
                                Next

                            ElseIf (pallet.ListJob.GetJob(i).GetType() Is GetType(CRepeat)) Then
                                Dim rp As CRepeat = CType(pallet.ListJob.GetJob(i), CRepeat)
                                For index2 = 1 To rp.RepeatNumber
                                    If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                        res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                    End If
                                Next
                            Else
                                res.Add(pallet.ListJob.GetJob(i))
                                If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                    res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                End If
                            End If
                        Next

                        For i = 0 To res.Count - 1
                            If (res(i).GetType() Is GetType(CPoint)) Then
                                p0 = CType(res(i), CPoint)
                                If (p0.InPallet) Then
                                    Dim idxRowCol As Integer = -1
                                    For idx = 0 To lstPoint.Count - 1
                                        If (p0.ID = lstPoint(idx).ID) Then
                                            idxRowCol = idx
                                            Exit For
                                        End If
                                    Next
                                    If (idxRowCol >= 0) Then
                                        p0.RowNumber = RowColIndex(idxRowCol, 0)
                                        p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                        RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                        If (RowColIndex(idxRowCol, 0) = pallet.RowNumber OrElse RowColIndex(idxRowCol, 0) = -1) Then
                                            RowColIndex(idxRowCol, 1) += 1
                                            lstCountStep(idxRowCol) = -lstCountStep(idxRowCol)
                                            RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                        End If
                                    End If
                                Else
                                    p0.RowNumber = 0
                                    p0.ColumnNumber = 0
                                End If
                            End If
                        Next
                    End If
                Else
                    If (pallet.OrderDirection = eOrderDirection.X_Plus) Then
                        For i = 0 To pallet.ListJob.Count - 1
                            If (pallet.ListJob.GetJob(i).GetType() Is GetType(CPoint)) Then
                                For r = 0 To pallet.RowNumber - 1
                                    For c = 0 To pallet.ColumnNumber - 1
                                        p0 = pallet.ListJob.GetJob(i).Clone()
                                        If (stepDisY > 0) Then
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += r * pallet.RowDistance
                                        Else
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r)
                                        End If
                                        p0.InPallet = True
                                        res.Add(p0)
                                    Next
                                Next

                            ElseIf (pallet.ListJob.GetJob(i).GetType() Is GetType(CRepeat)) Then
                                Dim rp As CRepeat = CType(pallet.ListJob.GetJob(i), CRepeat)
                                For index2 = 1 To rp.RepeatNumber
                                    If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                        res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                    End If
                                Next
                            Else
                                res.Add(pallet.ListJob.GetJob(i))
                                If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                    res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                End If
                            End If
                        Next

                        For i = 0 To res.Count - 1
                            If (res(i).GetType() Is GetType(CPoint)) Then
                                p0 = CType(res(i), CPoint)
                                If (p0.InPallet) Then

                                    Dim idxRowCol As Integer = -1
                                    For idx = 0 To lstPoint.Count - 1
                                        If (p0.ID = lstPoint(idx).ID) Then
                                            idxRowCol = idx
                                            Exit For
                                        End If
                                    Next

                                    If (idxRowCol >= 0) Then
                                        p0.RowNumber = RowColIndex(idxRowCol, 0)
                                        p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                        RowColIndex(idxRowCol, 1) += lstCountStep(idxRowCol)
                                        If (RowColIndex(idxRowCol, 1) = pallet.ColumnNumber) Then
                                            RowColIndex(idxRowCol, 0) += 1
                                            RowColIndex(idxRowCol, 1) = 0
                                        End If
                                    End If

                                Else
                                    p0.RowNumber = 0
                                    p0.ColumnNumber = 0
                                End If
                            End If
                        Next
                    Else

                        For i = 0 To pallet.ListJob.Count - 1
                            If (pallet.ListJob.GetJob(i).GetType() Is GetType(CPoint)) Then
                                For c = 0 To pallet.ColumnNumber - 1
                                    For r = 0 To pallet.RowNumber - 1
                                        p0 = pallet.ListJob.GetJob(i).Clone()
                                        If (stepDisY > 0) Then
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += r * pallet.RowDistance
                                        Else
                                            p0.Point.X += c * pallet.ColumnDistance
                                            p0.Point.Y += pallet.RowDistance * (pallet.RowNumber - r - 1)
                                        End If
                                        p0.InPallet = True
                                        res.Add(p0)
                                    Next
                                Next
                            ElseIf (pallet.ListJob.GetJob(i).GetType() Is GetType(CRepeat)) Then
                                Dim rp As CRepeat = CType(pallet.ListJob.GetJob(i), CRepeat)
                                For index2 = 1 To rp.RepeatNumber
                                    If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                        res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                    End If
                                Next
                            Else
                                res.Add(pallet.ListJob.GetJob(i))
                                If (pallet.ListJob.GetJob(i).CanHasChild AndAlso pallet.ListJob.GetJob(i).ListJob.Count > 0) Then
                                    res.AddRange(SortJob(pallet.ListJob.GetJob(i).ListJob))
                                End If
                            End If
                        Next


                        For i = 0 To res.Count - 1
                            If (res(i).GetType() Is GetType(CPoint)) Then
                                p0 = CType(res(i), CPoint)
                                If (p0.InPallet) Then

                                    Dim idxRowCol As Integer = -1
                                    For idx = 0 To lstPoint.Count - 1
                                        If (p0.ID = lstPoint(idx).ID) Then
                                            idxRowCol = idx
                                            Exit For
                                        End If
                                    Next

                                    If (idxRowCol >= 0) Then
                                        p0.RowNumber = RowColIndex(idxRowCol, 0)
                                        p0.ColumnNumber = RowColIndex(idxRowCol, 1)
                                        RowColIndex(idxRowCol, 0) += lstCountStep(idxRowCol)
                                        If (RowColIndex(idxRowCol, 0) = pallet.RowNumber) Then
                                            RowColIndex(idxRowCol, 1) += 1
                                            RowColIndex(idxRowCol, 0) = 0
                                        End If
                                    End If
                                Else
                                    p0.RowNumber = 0
                                    p0.ColumnNumber = 0
                                End If
                            End If
                        Next
                    End If
                End If
                result.AddRange(res)
            End If
        Catch ex As Exception
        End Try
        Return result
    End Function

    Public Sub Sort()
        ReDim m_CurAlign(MAX_LEVEL - 1)

        For index = 0 To m_CurAlign.Length - 1
            m_CurAlign(index) = New List(Of Integer)
            m_CurAlign(index).Add(-1)
        Next

        m_AlignId = -1
        m_ListAlign = New List(Of CJobObject)
        SortAlignID()
        m_lstSortedJob.Clear()

        For index = 0 To m_lstJob.Count - 1
            If (m_lstJob(index).GetType() Is GetType(CRepeat)) Then
                Dim rp As CRepeat = CType(m_lstJob(index), CRepeat)
                For index2 = 1 To rp.RepeatNumber
                    If (m_lstJob(index).CanHasChild AndAlso m_lstJob(index).ListJob.Count > 0) Then
                        m_lstSortedJob.AddRange(SortJob(m_lstJob(index).ListJob))
                    End If
                Next
            ElseIf (m_lstJob(index).GetType() Is GetType(CAlign)) Then
                If (m_CurAlign(m_lstJob(index).Level).Count > 1) Then
                    m_CurAlign(m_lstJob(index).Level).RemoveAt(0)
                End If
                m_lstSortedJob.Add(m_lstJob(index))
            ElseIf (m_lstJob(index).GetType() Is GetType(CPallet)) Then
                Dim pallet As CPallet = CType(m_lstJob(index), CPallet)
                m_lstSortedJob.AddRange(GetPalletJobs(pallet))
            Else
                m_lstSortedJob.Add(m_lstJob(index))
                If (m_lstJob(index).CanHasChild AndAlso m_lstJob(index).ListJob.Count > 0) Then
                    m_lstSortedJob.AddRange(SortJob(m_lstJob(index).ListJob))
                End If
            End If
        Next

        WriteTest(m_lstSortedJob)
        ReDim m_CurAlign(-1)
        GC.Collect()
    End Sub

    Private Sub WriteTest(ByVal res As List(Of CJobObject))
        Try
            Dim str As String = ""
            For i = 0 To res.Count - 1
                Dim space As String = ""

                For index = 0 To res(i).Level * 5
                    space &= " "
                Next

                str &= space & res(i).ToString() & "[AlignID = " & res(i).AlignID & "]"
                If (res(i).GetType() Is GetType(CPoint)) Then
                    Dim p As CPoint = CType(res(i), CPoint)
                    str &= String.Format("({0:F3}, {1:F3}, {2:F3}), ", p.Point.X, p.Point.Y, p.Point.Z)
                ElseIf (res(i).GetType() Is GetType(CAxis)) Then
                    Dim p As CAxis = CType(res(i), CAxis)
                    str &= String.Format("A({0:F3}, {1:F3}, {2:F3}), ", p.Point.X, p.Point.Y, p.Point.Z)
                End If
                str &= vbCrLf
            Next
            System.IO.File.WriteAllText("C:\Users\" & Environment.UserName & "\Documents\ListJob.txt", str)
        Catch
        End Try
    End Sub
End Class


Public MustInherit Class CJobObject
    Private m_Level As Integer = 0
    <Browsable(False)>
    Public Property Level As Integer
        Get
            Return m_Level
        End Get
        Set(ByVal value As Integer)
            m_Level = value
        End Set
    End Property
    Private m_AlignID As Integer = -1
    <Browsable(False)>
    Public Property AlignID As Integer
        Get
            Return m_AlignID
        End Get
        Set(ByVal value As Integer)
            m_AlignID = value
        End Set
    End Property
    Protected m_ID As Integer
    <Browsable(False)>
    Public Property ID As Integer
        Get
            Return m_ID
        End Get
        Set(ByVal value As Integer)
            m_ID = value
            m_CurrentID = m_ID
        End Set
    End Property
    <Browsable(False)>
    Public MustOverride ReadOnly Property Key As String

    Protected Shared m_CurrentID As Integer = 0
    <Browsable(False)>
    Public Shared Property CurrentID As Integer
        Get
            Return m_CurrentID
        End Get
        Set(ByVal value As Integer)
            m_CurrentID = value
        End Set
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property CanHasChild As Boolean
        Get
            Return False
        End Get
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property SelectedBackColor As Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml("#0078d7")
        End Get
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property SelectedForceColor As Color
        Get
            Return System.Drawing.Color.White
        End Get
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property NoSelecteBackColor As Color
        Get
            Return System.Drawing.Color.White
        End Get
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property NoSelecteForceColor As Color
        Get
            Return System.Drawing.Color.DarkBlue
        End Get
    End Property
    <Browsable(False)>
    Public Overridable ReadOnly Property ImageIdx As Integer
        Get
            Return 22
        End Get
    End Property
    <Browsable(False)>
    Protected m_lstListJob As CListJob = New CListJob()
    <Browsable(False)>
    Public Property ListJob As CListJob
        Get
            Return m_lstListJob
        End Get
        Set(ByVal value As CListJob)
            m_lstListJob = value
        End Set
    End Property

    Public Overridable Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CJobObject)
    End Function
    Public Overrides Function ToString() As String
        Return Key
    End Function
End Class

Public Class CPallet
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 1
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Pallet"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return Color.DarkGreen
        End Get
    End Property

    Private m_OrderType As eOrderType
    <Category("Common Parameters")>
    <DisplayName("Order type")>
    <Description("Set pallet order type")>
    Public Property OrderType As eOrderType
        Get
            Return m_OrderType
        End Get
        Set(ByVal value As eOrderType)
            m_OrderType = value
        End Set
    End Property
    Private m_OrderDirection As eOrderDirection
    <Category("Common Parameters")>
    <DisplayName("Order direction")>
    <Description("Set pallet order direction")>
    Public Property OrderDirection As eOrderDirection
        Get
            Return m_OrderDirection
        End Get
        Set(ByVal value As eOrderDirection)
            m_OrderDirection = value
        End Set
    End Property
    Private m_ResetOffset As Boolean
    <Category("Common Parameters")>
    <DisplayName("Reset offset")>
    <Description("Reset offset")>
    Public Property ResetOffset As Boolean
        Get
            Return m_ResetOffset
        End Get
        Set(ByVal value As Boolean)
            m_ResetOffset = value
        End Set
    End Property
    Private m_RowNumber As Integer = 1
    <Category("Common Parameters")>
    <DisplayName("Row number")>
    <Description("Row number")>
    Public Property RowNumber As Integer
        Get
            Return m_RowNumber
        End Get
        Set(ByVal value As Integer)
            If (value < 1) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 1")
            Else
                m_RowNumber = value
            End If
        End Set
    End Property
    Private m_ColumnNumber As Integer = 1
    <Category("Common Parameters")>
    <DisplayName("Column number")>
    <Description("Column number")>
    Public Property ColumnNumber As Integer
        Get
            Return m_ColumnNumber
        End Get
        Set(ByVal value As Integer)
            If (value < 1) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 1")
            Else
                m_ColumnNumber = value
            End If
        End Set
    End Property
    Private m_RowDistance As Double = 2
    <Category("Common Parameters")>
    <DisplayName("Row distance")>
    <Description("Row distance (mm)")>
    Public Property RowDistance As Double
        Get
            Return m_RowDistance
        End Get
        Set(ByVal value As Double)
            m_RowDistance = value
        End Set
    End Property
    Private m_ColumnDistance As Double = 2
    <Category("Common Parameters")>
    <DisplayName("Column distance")>
    <Description("Column distance (mm)")>
    Public Property ColumnDistance As Double
        Get
            Return m_ColumnDistance
        End Get
        Set(ByVal value As Double)
            m_ColumnDistance = value
        End Set
    End Property
    Private m_RotationAngle As Double
    <Category("Common Parameters")>
    <DisplayName("Rotation angle")>
    <Description("Rotation angle")>
    Public Property RotationAngle As Double
        Get
            Return m_RotationAngle
        End Get
        Set(ByVal value As Double)
            m_RotationAngle = value
        End Set
    End Property
    Private m_StartID As Integer
    <Category("Common Parameters")>
    <DisplayName("Start ID")>
    <Description("Start ID")>
    Public Property StartID As Integer
        Get
            Return m_StartID
        End Get
        Set(ByVal value As Integer)
            m_StartID = value
        End Set
    End Property
    Private m_EndID As Integer
    <Category("Common Parameters")>
    <DisplayName("End ID")>
    <Description("End ID")>
    Public Property EndID As Integer
        Get
            Return m_EndID
        End Get
        Set(ByVal value As Integer)
            m_EndID = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CJobObject.CurrentID + 1
        Me.ColumnDistance = 2.0
        Me.ColumnNumber = 1
        Me.EndID = 0
        Me.OrderDirection = eOrderDirection.X_Plus
        Me.OrderType = eOrderType.S_Shape
        Me.ResetOffset = False
        Me.RotationAngle = 0
        Me.RowDistance = 2.0
        Me.RowNumber = 1
        Me.StartID = 0
    End Sub
    Public Sub New(ByVal pOrderType As eOrderType, ByVal pOrderDirection As eOrderDirection, ByVal pResetOffset As Boolean, ByVal pRowNumber As Integer, ByVal pColumnNumber As Integer, ByVal pRowDistance As Double, ByVal pColumnDistance As Double, ByVal pStartID As Integer, ByVal pEndID As Integer)
        Me.ID = CJobObject.CurrentID + 1
        Me.ColumnDistance = pColumnDistance
        Me.ColumnNumber = pColumnNumber
        Me.EndID = pEndID
        Me.OrderDirection = pOrderDirection
        Me.OrderType = pOrderType
        Me.ResetOffset = pResetOffset
        Me.RotationAngle = pResetOffset
        Me.RowDistance = pRowDistance
        Me.RowNumber = pRowNumber
        Me.StartID = pStartID
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CPallet)
    End Function
End Class
Public Enum eOrderType
    <Description("S-Shape")>
    S_Shape
    <Description("Z-Shape")>
    Z_Shape
End Enum
Public Enum eOrderDirection
    <Description("X-Plus")>
    X_Plus
    <Description("Y-Plus")>
    Y_Plus
End Enum
Public Class CPoint
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 0
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            If (InPallet) Then
                Return "[" & ID & "] Point " & "[" & RowNumber & "," & ColumnNumber & "]"
            Else
                Return "[" & ID & "] Point"
            End If
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return Color.DarkBlue
        End Get
    End Property
    Private m_JumpSpeed As Integer = 25
    <Category("Common Parameters")>
    <DisplayName("Jump Speed")>
    <Description("Set the jump velocity (1~100: ratio of maximum velocity)")>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value < 1 OrElse value > 100) Then
                FMessageBox.ShowAgrumentError("The value must in [1:100]")
            Else
                m_JumpSpeed = value
            End If
        End Set
    End Property
    Private m_Arch As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Arch")>
    <Description("Set the position of Z-axis in moving to the point. (Value 0: direct)")>
    Public Property Arch As Double
        Get
            Return m_Arch
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Arch = value
            End If
        End Set
    End Property
    Private m_JobOnDelay As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Job On Delay")>
    <Description("Set waiting time to start job after starting motion. (msec)")>
    Public Property JobOnDelay As Integer
        Get
            Return m_JobOnDelay
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_JobOnDelay = value
            End If
        End Set
    End Property

    Private m_RAxisBlock As Boolean = True
    <Category("Common Parameters")>
    <DisplayName("RAxisBlock")>
    <Description("Set R-axis block. (True: don't move)")>
    Public Property RAxisBlock As Boolean
        Get
            Return m_RAxisBlock
        End Get
        Set(ByVal value As Boolean)
            m_RAxisBlock = value
        End Set
    End Property

    Private m_IndividualPositioning As Boolean = False
    <Category("Common Parameters")>
    <DisplayName("Individual positioning")>
    <Description("Set local align mode. (If True is refresh offset)")>
    Public Property IndividualPositioning As Boolean
        Get
            Return m_IndividualPositioning
        End Get
        Set(ByVal value As Boolean)
            m_IndividualPositioning = value
        End Set
    End Property

    Private m_LoadPositionOffset As Boolean = False
    <Category("Common Parameters")>
    <DisplayName("Load position offset")>
    <Description("Set local additional align mode. (Only offset refresh is False)")>
    Public Property LoadPositionOffset As Boolean
        Get
            Return m_LoadPositionOffset
        End Get
        Set(ByVal value As Boolean)
            m_LoadPositionOffset = value
        End Set
    End Property

    Private m_LocalImageID As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Local Image ID")>
    <Description("Set image reference. (Local compensation)")>
    <DefaultValue(CInt(0))>
    <TypeConverter(GetType(LocalImageList))>
    Public Property LocalImageID As Integer
        Get
            Return m_LocalImageID
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_LocalImageID = value
            End If
        End Set
    End Property

    Private m_Point As CPointAttribute = New CPointAttribute()
    <Category("Common Parameters")>
    <DisplayName("Point")>
    <Description("Point property")>
    <TypeConverter(GetType(CPointConverter))>
    Public Property Point As CPointAttribute
        Get
            Return m_Point
        End Get
        Set(ByVal value As CPointAttribute)
            m_Point = value
        End Set
    End Property

    Private m_JobEnable As Boolean = True
    <Category("Solder Parameters")>
    <DisplayName("Job Enable")>
    <Description("Enable job ")>
    Public Property JobEnable As Boolean
        Get
            Return m_JobEnable
        End Get
        Set(ByVal value As Boolean)
            m_JobEnable = value
        End Set
    End Property

    Private m_FeedingEnable As Boolean = False
    <Category("Solder Parameters")>
    <DisplayName("Feeding Enable")>
    <Description("Enable wire feeding")>
    Public Property FeedingEnable As Boolean
        Get
            Return m_FeedingEnable
        End Get
        Set(ByVal value As Boolean)
            m_FeedingEnable = value
        End Set
    End Property
    Private m_LaserRecipe As Integer = 0
    <Category("Solder Parameters")>
    <DisplayName("Laser Recipe")>
    <Description("Set the job recipe. (0~7: laser recipe id)")>
    <TypeConverter(GetType(LaserRecipeList))>
    Public Property LaserRecipe As Integer
        Get
            Return m_LaserRecipe
        End Get
        Set(ByVal value As Integer)
            m_LaserRecipe = value
        End Set
    End Property
    Private m_FeederRecipe As Integer = 0
    <Category("Solder Parameters")>
    <DisplayName("Feeder Recipe")>
    <Description("Set the feeder recipe. (0~3: feed recipe id)")>
    <TypeConverter(GetType(FeederRecipeList))>
    Public Property FeederRecipe As Integer
        Get
            Return m_FeederRecipe
        End Get
        Set(ByVal value As Integer)
            m_FeederRecipe = value
        End Set
    End Property

    Private m_RowNumber As Integer = 0
    <Browsable(False)>
    Public Property RowNumber As Integer
        Get
            Return m_RowNumber
        End Get
        Set(ByVal value As Integer)
            m_RowNumber = value
        End Set
    End Property
    Private m_ColumnNumber As Integer = 0
    <Browsable(False)>
    Public Property ColumnNumber As Integer
        Get
            Return m_ColumnNumber
        End Get
        Set(ByVal value As Integer)
            m_ColumnNumber = value
        End Set
    End Property
    Private m_InPallet As Boolean = False
    <Browsable(False)>
    Public Property InPallet As Boolean
        Get
            Return m_InPallet
        End Get
        Set(ByVal value As Boolean)
            m_InPallet = value
        End Set
    End Property
    Public Sub New()
        Me.Arch = 0
        Me.FeederRecipe = 0
        Me.FeedingEnable = False
        Me.ID = CurrentID + 1
        Me.IndividualPositioning = False
        Me.JobEnable = True
        Me.JobOnDelay = 0
        Me.JumpSpeed = 25
        Me.LaserRecipe = 0
        Me.LoadPositionOffset = False
        Me.LocalImageID = 0
        Me.Point = New CPointAttribute()
        Me.Point.ID = Me.ID
        Me.RAxisBlock = True
    End Sub
    Public Sub New(ByVal pJumpSpeed As Integer, ByVal pArch As Double, ByVal pJobOnDelay As Integer, ByVal pRAxisBlock As Boolean, ByVal pIndividualPositioning As Boolean, ByVal pLoadPositionOffset As Boolean, ByVal pLocalImageID As Integer, ByVal pPoint As CPointAttribute, ByVal pJobEnable As Boolean, ByVal pFeedingEnable As Boolean, ByVal pLaserRecipe As Integer, ByVal pFeederRecipe As Integer)
        Me.Arch = pArch
        Me.FeederRecipe = pFeederRecipe
        Me.FeedingEnable = pFeedingEnable
        Me.ID = CurrentID + 1
        Me.IndividualPositioning = pIndividualPositioning
        Me.JobEnable = pJobEnable
        Me.JobOnDelay = pJobOnDelay
        Me.JumpSpeed = pJumpSpeed
        Me.LaserRecipe = pLaserRecipe
        Me.LoadPositionOffset = pLoadPositionOffset
        Me.LocalImageID = pLocalImageID
        Me.Point = pPoint
        Me.Point.ID = Me.ID
        Me.RAxisBlock = pRAxisBlock
    End Sub
    Public Overrides Function Clone() As CJobObject
        Dim tmp = DirectCast(Me.MemberwiseClone(), CPoint)
        tmp.Point = Me.Point.Clone()
        Return tmp
    End Function
End Class
Public Class LocalImageList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 4
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class FeederRecipeList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 3
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class LaserRecipeList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 7
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class CPointAttribute
    Inherits ExpandableObjectConverter
    Private m_ID As Integer = 0
    Private m_X As Single = 0.0F
    Private m_Y As Single = 0.0F
    Private m_Z As Single = 0.0F
    Private m_R As Single = 0.0F
    Public Sub New()
        m_ID = 0
        m_X = 0.0F
        m_Y = 0.0F
        m_Z = 0.0F
        m_R = 0.0F
    End Sub
    Public Sub New(ByVal pID As Integer, ByVal pX As Single, ByVal pY As Single, ByVal pZ As Single, ByVal pR As Single)
        Me.ID = pID
        Me.X = pX
        Me.Y = pY
        Me.Z = pZ
        Me.R = pR
    End Sub
    <Browsable(False)>
    Public Property ID As Integer
        Get
            Return m_ID
        End Get
        Set(ByVal value As Integer)
            m_ID = value
        End Set
    End Property
    <DisplayName("X axis")>
    <Description("disable edit")>
    Public Property X As Single
        Get
            Return m_X
        End Get
        Set(ByVal value As Single)
            m_X = value
        End Set
    End Property
    <DisplayName("Y axis")>
    <Description("disable edit")>
    Public Property Y As Single
        Get
            Return m_Y
        End Get
        Set(ByVal value As Single)
            m_Y = value
        End Set
    End Property
    <DisplayName("Z axis")>
    <Description("disable edit")>
    Public Property Z As Single
        Get
            Return m_Z
        End Get
        Set(ByVal value As Single)
            m_Z = value
        End Set
    End Property
    <DisplayName("R axis")>
    <Description("disable edit")>
    Public Property R As Single
        Get
            Return m_R
        End Get
        Set(ByVal value As Single)
            m_R = value
        End Set
    End Property
    Public Function Clone() As CPointAttribute
        Return DirectCast(Me.MemberwiseClone(), CPointAttribute)
    End Function
End Class
Friend Class CPointConverter
    Inherits ExpandableObjectConverter

    Public Overrides Function ConvertTo(ByVal context As ITypeDescriptorContext, ByVal culture As System.Globalization.CultureInfo, ByVal value As Object, ByVal destType As Type) As Object
        If destType Is GetType(String) AndAlso TypeOf (value) Is CPointAttribute Then
            Dim pt As CPointAttribute = CType(value, CPointAttribute)
            Return "P" & pt.ID.ToString()
        End If
        Return MyBase.ConvertTo(context, culture, value, destType)
    End Function
End Class

Public Class CConditional
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 5
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] IF"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return Color.Orange
        End Get
    End Property
    Private m_Kind As eKind = eKind.IO
    <Category("Common Parameters")>
    <DisplayName("Kind")>
    <Description("Set type")>
    Public Property Kind As eKind
        Get
            Return m_Kind
        End Get
        Set(ByVal value As eKind)
            m_Kind = value
        End Set
    End Property
    Private m_Address As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Address")>
    <Description("Set address IO or GINT")>
    Public Property Address As Integer
        Get
            Return m_Address
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Address = value
            End If
        End Set
    End Property
    Private m_Bit As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Bit")>
    <Description("Set IO bit address")>
    <TypeConverter(GetType(IOBitList))>
    Public Property Bit As Integer
        Get
            Return m_Bit
        End Get
        Set(ByVal value As Integer)
            m_Bit = value
        End Set
    End Property
    Private m_IOValue As Integer = 1
    <Category("Common Parameters")>
    <DisplayName("IO Value")>
    <Description("Set IO value")>
    Public Property IOValue As Integer
        Get
            Return m_IOValue
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_IOValue = value
            End If
        End Set
    End Property
    Private m_StartID As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Start ID")>
    <Description("Set the id of starting job. (dynamic changed parameter)")>
    Public Property StartID As Integer
        Get
            Return m_StartID
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_StartID = value
            End If
        End Set
    End Property
    Private m_EndID As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("End ID")>
    <Description("Set the id of ending job. (dynamic changed parameter)")>
    Public Property EndID As Integer
        Get
            Return m_EndID
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_EndID = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.m_Address = 0
        Me.m_Bit = 0
        Me.m_IOValue = 0
        Me.m_EndID = 0
        Me.m_Kind = eKind.IO
        Me.m_StartID = 0
    End Sub
    Public Sub New(ByVal pKind As eKind, ByVal pAddress As Integer, ByVal pBit As Integer, ByVal pIOValue As Integer, ByVal pStartID As Integer, ByVal pEndID As Integer)
        Address = pAddress
        Bit = pBit
        IOValue = pIOValue
        EndID = pEndID
        Kind = pKind
        StartID = pStartID
        Me.ID = CurrentID + 1
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CConditional)
    End Function
End Class
Public Enum eKind
    IO
    GINT
End Enum
Public Class IOBitList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 7
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class CAxis
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 4
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Axis"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_JumpSpeed As Integer = 25
    <Category("Common Parameters")>
    <DisplayName("Jump Speed")>
    <Description("Set the jump velocity (1~100: ratio of maximum velocity)")>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value < 1 OrElse value > 100) Then
                FMessageBox.ShowAgrumentError("The value must in [1:100]")
            Else
                m_JumpSpeed = value
            End If
        End Set
    End Property
    Private m_Arch As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Arch")>
    <Description("Set the position of Z-axis in moving to the point. (Value 0: direct)")>
    Public Property Arch As Double
        Get
            Return m_Arch
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Arch = value
            End If
        End Set
    End Property
    Private m_MotionOrderMode As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Motion Order Mode")>
    <Description("Set motion order. (0: r->xyz; 1: xyz->r; 2: xyzr)")>
    Public Property MotionOrderMode As Double
        Get
            Return m_MotionOrderMode
        End Get
        Set(ByVal value As Double)
            If (value < 0 OrElse value > 2) Then
                FMessageBox.ShowAgrumentError("The value must in [0:2]")
            Else
                m_MotionOrderMode = value
            End If
        End Set
    End Property
    Private m_Point As CPointAttribute = New CPointAttribute()
    <Category("Common Parameters")>
    <DisplayName("Point")>
    <Description("Point property")>
    <TypeConverter(GetType(CPointConverter))>
    Public Property Point As CPointAttribute
        Get
            Return m_Point
        End Get
        Set(ByVal value As CPointAttribute)
            m_Point = value
        End Set
    End Property
    Public Sub New()
        Me.Point = New CPointAttribute()
        Me.Arch = 0
        Me.ID = CurrentID + 1
        Me.Point.ID = Me.ID
        Me.JumpSpeed = 25
        Me.MotionOrderMode = 0
    End Sub
    Public Sub New(ByVal pJumpSpeed As Integer, ByVal pArch As Double, ByVal pMotionOrderMode As Integer, ByVal pPoint As CPointAttribute)
        Me.ID = CurrentID + 1
        Me.JumpSpeed = Me.JumpSpeed
        Me.MotionOrderMode = pMotionOrderMode
        Me.Point = pPoint
        Me.Point.ID = Me.ID
    End Sub
    Public Overrides Function Clone() As CJobObject
        Dim tmp As CAxis = DirectCast(Me.MemberwiseClone(), CAxis)
        tmp.Point = Me.Point.Clone()
        Return tmp
    End Function
End Class
Public Class CIO
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 6
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] IO"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_ByName As Boolean
    <Category("Common Parameters")>
    <DisplayName("ByName")>
    <Description("Set IO register type.")>
    Public Property ByName As Boolean
        Get
            Return m_ByName
        End Get
        Set(ByVal value As Boolean)
            m_ByName = value
        End Set
    End Property
    Private m_NameIO As String
    <Category("Common Parameters")>
    <DisplayName("NameIO")>
    <Description("Set IO name.")>
    <[ReadOnly](True)>
    Public Property NameIO As String
        Get
            Return m_NameIO
        End Get
        Set(ByVal value As String)
            m_NameIO = value
        End Set
    End Property
    Private m_Value As Integer
    <Category("Common Parameters")>
    <DisplayName("Value")>
    <Description("Set IO value.")>
    Public Property Value As Integer
        Get
            Return m_Value
        End Get
        Set(ByVal value As Integer)
            m_Value = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.ByName = False
        Me.NameIO = ""
        Me.Value = 1
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CIO)
    End Function
End Class
Public Class CStandBy
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 7
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] StandBy"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_Kind As eKind = eKind.IO
    <Category("Common Parameters")>
    <DisplayName("Kind")>
    <Description("Set type")>
    Public Property Kind As eKind
        Get
            Return m_Kind
        End Get
        Set(ByVal value As eKind)
            m_Kind = value
        End Set
    End Property
    Private m_Address As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Address")>
    <Description("Set address IO or GINT")>
    Public Property Address As Integer
        Get
            Return m_Address
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Address = value
            End If
        End Set
    End Property
    Private m_Bit As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Bit")>
    <Description("Set IO bit address")>
    <TypeConverter(GetType(IOBitList))>
    Public Property Bit As Integer
        Get
            Return m_Bit
        End Get
        Set(ByVal value As Integer)
            m_Bit = value
        End Set
    End Property
    Private m_IOValue As Integer = 1
    <Category("Common Parameters")>
    <DisplayName("IO Value")>
    <Description("Set IO value")>
    Public Property IOValue As Integer
        Get
            Return m_IOValue
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_IOValue = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.Kind = eKind.IO
        Me.IOValue = 1
        Me.Address = 0
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CStandBy)
    End Function
End Class
Public Class CHome
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 8
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Home"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_JumpSpeed As Integer = 25
    <Category("Common Parameters")>
    <DisplayName("Jump Speed")>
    <Description("Set the jump velocity (1~100: ratio of maximum velocity)")>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value < 1 OrElse value > 100) Then
                FMessageBox.ShowAgrumentError("The value must in [1:100]")
            Else
                m_JumpSpeed = value
            End If
        End Set
    End Property
    Private m_Arch As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Arch")>
    <Description("Set the position of Z-axis in moving to the point. (Value 0: direct)")>
    Public Property Arch As Double
        Get
            Return m_Arch
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Arch = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.JumpSpeed = 50
        Me.Arch = 0
    End Sub
    Public Sub New(ByVal pJumpSpeed As Integer, ByVal pArch As Double)
        Me.ID = CurrentID + 1
        Me.JumpSpeed = pJumpSpeed
        Me.Arch = pArch
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CHome)
    End Function
End Class
Public Class CJump
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 9
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Jump"
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return System.Drawing.ColorTranslator.FromHtml("#999933")
        End Get
    End Property
    Private m_JumpID As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Jump ID")>
    <Description("Set the jump id for jumping")>
    Public Property JumpID As Integer
        Get
            Return m_JumpID
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_JumpID = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.JumpID = 0
    End Sub
    Public Sub New(ByVal pJumpID As Integer)
        Me.ID = CurrentID + 1
        Me.JumpID = pJumpID
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CJump)
    End Function
End Class
Public Class CWait
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 11
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Wait"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_WaitTime As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Wait Time")>
    <Description("Set waiting time.(msec)")>
    Public Property WaitTime As Integer
        Get
            Return m_WaitTime
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_WaitTime = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.WaitTime = 0
    End Sub
    Public Sub New(ByVal pWaitTime As Integer)
        Me.ID = CurrentID + 1
        Me.WaitTime = pWaitTime
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CWait)
    End Function
End Class
Public Class CRepeat
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 3
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Repeat"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return True
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return Color.Red
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Private m_RepeatNumber As Integer = 1
    <Category("Common Parameters")>
    <DisplayName("Repeat Number")>
    <Description("Set the repear number")>
    Public Property RepeatNumber As Integer
        Get
            Return m_RepeatNumber
        End Get
        Set(ByVal value As Integer)
            If (value < 1) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 1")
            Else
                m_RepeatNumber = value
            End If
        End Set
    End Property
    Private m_StartID As Integer
    <Category("Common Parameters")>
    <DisplayName("Start ID")>
    <Description("Set the id of starting job. (synamic changed parameter)")>
    Public Property StartID As Integer
        Get
            Return m_StartID
        End Get
        Set(ByVal value As Integer)
            m_StartID = value
        End Set
    End Property
    Private m_EndID As Integer
    <Category("Common Parameters")>
    <DisplayName("End ID")>
    <Description("Set the id of ending job. (synamic changed parameter)")>
    Public Property EndID As Integer
        Get
            Return m_EndID
        End Get
        Set(ByVal value As Integer)
            m_EndID = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.RepeatNumber = 1
        Me.StartID = 0
        Me.EndID = 0
    End Sub
    Public Sub New(ByVal pRepeatNumber As Integer, ByVal pStartID As Integer, ByVal pEndId As Integer)
        Me.ID = CurrentID + 1
        Me.RepeatNumber = pRepeatNumber
        Me.StartID = pStartID
        Me.EndID = pEndId
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CRepeat)
    End Function
End Class
Public Class CAlign
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 18
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Align"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_AlignType As Integer
    <Category("Common Parameters")>
    <DisplayName("Align Type")>
    <Description("Set align type. (0: search; 1: calculate)")>
    <TypeConverter(GetType(AlignTypeList))>
    Public Property AlignType As Integer
        Get
            Return m_AlignType
        End Get
        Set(ByVal value As Integer)
            m_AlignType = value
        End Set
    End Property
    Private m_FiducialID0 As Integer
    <Category("Common Parameters")>
    <DisplayName("Fiducial ID0")>
    <Description("Set the first fiducial image id.")>
    Public Property FiducialID0 As Integer
        Get
            Return m_FiducialID0
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_FiducialID0 = value
            End If
        End Set
    End Property
    Private m_FiducialID1 As Integer
    <Category("Common Parameters")>
    <DisplayName("Fiducial ID1")>
    <Description("Set the second fiducial image id.")>
    Public Property FiducialID1 As Integer
        Get
            Return m_FiducialID1
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_FiducialID1 = value
            End If
        End Set
    End Property
    Private m_JumpSpeed As Integer = 25
    <Category("Common Parameters")>
    <DisplayName("Jump Speed")>
    <Description("Set the jump velocity (1~100: ratio of maximum velocity)")>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value < 1 OrElse value > 100) Then
                FMessageBox.ShowAgrumentError("The value must in [1:100]")
            Else
                m_JumpSpeed = value
            End If
        End Set
    End Property
    Private m_Arch As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Arch")>
    <Description("Set the position of Z-axis in moving to the point. (Value 0: direct)")>
    Public Property Arch As Double
        Get
            Return m_Arch
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Arch = value
            End If
        End Set
    End Property
    Private m_Threshold As Double = 0
    <Category("Common Parameters")>
    <DisplayName("Threshold")>
    <Description("Set the threshold of matching rate.")>
    Public Property Threshold As Double
        Get
            Return m_Threshold
        End Get
        Set(ByVal value As Double)
            m_Threshold = value
        End Set
    End Property
    Private m_ROIWidth As Double = 0
    <Category("Common Parameters")>
    <DisplayName("ROI width rotion")>
    <Description("Set the ROI width rotion.")>
    Public Property ROIWidth As Double
        Get
            Return m_ROIWidth
        End Get
        Set(ByVal value As Double)
            m_ROIWidth = value
        End Set
    End Property
    Private m_ROIHeight As Double = 0
    <Category("Common Parameters")>
    <DisplayName("ROI height rotion")>
    <Description("Set the ROI height rotion.")>
    Public Property ROIHeight As Double
        Get
            Return m_ROIHeight
        End Get
        Set(ByVal value As Double)
            m_ROIHeight = value
        End Set
    End Property
    Private m_ImageCount As Integer = 0
    <Category("Common Parameters")>
    <DisplayName("Image count")>
    <Description("Set image count")>
    Public Property ImageCount As Integer
        Get
            Return m_ImageCount
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_ImageCount = value
            End If
        End Set
    End Property



    Private m_RealLocation As CPointAttribute = New CPointAttribute()
    <Browsable(False)>
    Public Property RealLocation As CPointAttribute
        Get
            Return m_RealLocation
        End Get
        Set(ByVal value As CPointAttribute)
            m_RealLocation = value
        End Set
    End Property

    Public Sub InitRealLocation()
        Try
            m_RealLocation = New CPointAttribute
        Catch ex As Exception

        End Try
    End Sub

    Public Sub New()
        Me.ID = CurrentID + 1
        Me.AlignType = 0
        Me.FiducialID0 = 0
        Me.FiducialID1 = 0
        Me.JumpSpeed = 30
        Me.Arch = 0
        Me.Threshold = 0
        Me.ROIWidth = 0
        Me.ROIHeight = 0
        Me.ImageCount = 0
        Me.m_RealLocation = New CPointAttribute()
    End Sub
    Public Sub New(ByVal pAlignType As Integer, ByVal pFiducialID0 As Integer, ByVal pFiducialID1 As Integer, ByVal pJumpSpeed As Integer, ByVal pArch As Double, ByVal pThreshold As Double, ByVal pROIWidth As Double, ByVal pROIHeight As Double, ByVal pImageCount As Integer)
        Me.ID = CurrentID + 1
        Me.AlignType = pAlignType
        Me.FiducialID0 = pFiducialID0
        Me.FiducialID1 = pFiducialID1
        Me.JumpSpeed = pJumpSpeed
        Me.Arch = pArch
        Me.Threshold = pThreshold
        Me.ROIWidth = pROIWidth
        Me.ROIHeight = pROIHeight
        Me.ImageCount = pImageCount
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CAlign)
    End Function
End Class
Public Class AlignTypeList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 1
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class CTackBegin
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 13
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Tack Begin"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_TimerID As Integer
    <Category("Common Parameters")>
    <DisplayName("TimeID")>
    <Description("Set timer id. (0: tack time)")>
    Public Property TimerID As Integer
        Get
            Return m_TimerID
        End Get
        Set(ByVal value As Integer)
            m_TimerID = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.TimerID = 0
    End Sub
    Public Sub New(ByVal pTimerID As Integer)
        Me.ID = CurrentID + 1
        Me.TimerID = pTimerID
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CTackBegin)
    End Function
End Class
Public Class CTackEnd
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 15
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Tack End"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_TimerID As Integer
    <Category("Common Parameters")>
    <DisplayName("TimeID")>
    <Description("Set timer id. (0: tack time)")>
    Public Property TimerID As Integer
        Get
            Return m_TimerID
        End Get
        Set(ByVal value As Integer)
            m_TimerID = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.TimerID = 0
    End Sub
    Public Sub New(ByVal pTimerID As Integer)
        Me.ID = CurrentID + 1
        Me.TimerID = pTimerID
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CTackEnd)
    End Function
End Class
Public Class CLotEnd
    Inherits CJobObject
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Lot End"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_Good As Integer
    <Category("Common Parameters")>
    <DisplayName("Good")>
    <Description("Set good sample number")>
    Public Property Good As Integer
        Get
            Return m_Good
        End Get
        Set(ByVal value As Integer)
            m_Good = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.Good = 0
    End Sub
    Public Sub New(ByVal pGood As Integer)
        Me.ID = CurrentID + 1
        Me.Good = pGood
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CLotEnd)
    End Function
End Class
Public Class CBlow
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 16
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Blow"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_On As Boolean
    <Category("Common Parameters")>
    <DisplayName("On")>
    <Description("Set blow")>
    Public Property [On] As Boolean
        Get
            Return m_On
        End Get
        Set(ByVal value As Boolean)
            m_On = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.On = 0
    End Sub
    Public Sub New(ByVal pOn As Boolean)
        Me.ID = CurrentID + 1
        Me.On = pOn
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CBlow)
    End Function
End Class
Public Class CRecordBegin
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 17
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Record Begin"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_FileNameType As Integer
    <Category("Common Parameters")>
    <DisplayName("FileName Type")>
    <Description("Setfile name. (0: date time; 1: barcord)")>
    <TypeConverter(GetType(FileNameTypeList))>
    Public Property FileNameType As Integer
        Get
            Return m_FileNameType
        End Get
        Set(ByVal value As Integer)
            If (value < 0 OrElse value > 1) Then
                FMessageBox.ShowAgrumentError("The value must is 0 or 1")
            Else
                m_FileNameType = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.FileNameType = 0
    End Sub
    Public Sub New(ByVal pFileNameType As Integer)
        Me.ID = CurrentID + 1
        Me.FileNameType = pFileNameType
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CRecordBegin)
    End Function
End Class
Public Class FileNameTypeList
    Inherits System.ComponentModel.Int32Converter
    Private Function myList() As Collections.IList
        Dim lst As New Collection
        With lst
            For i = 0 To 1
                .Add(i)
            Next
        End With
        Return lst
    End Function
    Public Overrides Function GetStandardValues(ByVal context As System.ComponentModel.ITypeDescriptorContext) As System.ComponentModel.TypeConverter.StandardValuesCollection
        Return New StandardValuesCollection(myList)
    End Function
    Public Overrides Function GetStandardValuesSupported(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
    Public Overrides Function GetStandardValuesExclusive(ByVal context As System.ComponentModel.ITypeDescriptorContext) As Boolean
        Return True
    End Function
End Class
Public Class CRecordStop
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 19
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Record Stop"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_Stop As Integer
    <Category("Common Parameters")>
    <DisplayName("Stop")>
    <Description("Record Stop (none parameter)")>
    <TypeConverter(GetType(FileNameTypeList))>
    <[ReadOnly](True)>
    Public Property [Stop] As Integer
        Get
            Return m_Stop
        End Get
        Set(ByVal value As Integer)
            If (value < 0 OrElse value > 1) Then
                FMessageBox.ShowAgrumentError("The value must is 0 or 1")
            Else
                m_Stop = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.Stop = 0
    End Sub
    Public Sub New(ByVal pStop As Integer)
        Me.ID = CurrentID + 1
        Me.Stop = pStop
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CRecordStop)
    End Function
End Class
Public Class CBarcode
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 20
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] Barcode"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_BarcoderID As Integer
    <Category("Common Parameters")>
    <DisplayName("Barcode ID")>
    <Description("Set barcode id")>
    Public Property BarcoderID As Integer
        Get
            Return m_BarcoderID
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_BarcoderID = value
            End If
        End Set
    End Property
    Private m_JumpSpeed As Integer
    <Category("Common Parameters")>
    <DisplayName("Jump Speed")>
    <Description("Set the jump velocity (1~100: ratio of maximum velocity)")>
    Public Property JumpSpeed As Integer
        Get
            Return m_JumpSpeed
        End Get
        Set(ByVal value As Integer)
            If (value < 1 OrElse value > 100) Then
                FMessageBox.ShowAgrumentError("The value must in [1:100]")
            Else
                m_JumpSpeed = value
            End If
        End Set
    End Property
    Private m_Arch As Double
    <Category("Common Parameters")>
    <DisplayName("Arch")>
    <Description("Set the position of Z-axis in moving to the point. (Value 0: direct)")>
    Public Property Arch As Double
        Get
            Return m_Arch
        End Get
        Set(ByVal value As Double)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_Arch = value
            End If
        End Set
    End Property
    Private m_CheckCount As Integer
    <Category("Common Parameters")>
    <DisplayName("Check Count")>
    <Description("Set check count")>
    Public Property CheckCount As Integer
        Get
            Return m_CheckCount
        End Get
        Set(ByVal value As Integer)
            If (value < 0) Then
                FMessageBox.ShowAgrumentError("The value must be greater than 0")
            Else
                m_CheckCount = value
            End If
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.JumpSpeed = 50
        Me.Arch = 0
        Me.BarcoderID = 0
        Me.CheckCount = 0
    End Sub
    Public Sub New(ByVal pBarcoderID As Integer, ByVal pJumpSpeed As Integer, ByVal pArch As Double, ByVal pCheckCount As Integer)
        Me.ID = CurrentID + 1
        Me.JumpSpeed = pJumpSpeed
        Me.Arch = pArch
        Me.BarcoderID = pBarcoderID
        Me.CheckCount = pCheckCount
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CBarcode)
    End Function
End Class
Public Class CGVariable
    Inherits CJobObject
    Public Overrides ReadOnly Property ImageIdx As Integer
        Get
            Return 21
        End Get
    End Property
    Public Overrides ReadOnly Property Key As String
        Get
            Return "[" & ID & "] GVariable"
        End Get
    End Property
    Public Overrides ReadOnly Property CanHasChild As Boolean
        Get
            Return MyBase.CanHasChild
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedBackColor As System.Drawing.Color
        Get
            Return MyBase.SelectedBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property SelectedForceColor As System.Drawing.Color
        Get
            Return MyBase.SelectedForceColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteBackColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteBackColor
        End Get
    End Property
    Public Overrides ReadOnly Property NoSelecteForceColor As System.Drawing.Color
        Get
            Return MyBase.NoSelecteForceColor
        End Get
    End Property
    Private m_UserVariable As eUserVariable
    <Category("Common Parameters")>
    <DisplayName("User Variable")>
    <Description("Set global integer variable")>
    Public Property UserVariable As eUserVariable
        Get
            Return m_UserVariable
        End Get
        Set(ByVal value As eUserVariable)
            m_UserVariable = value
        End Set
    End Property
    Private m_CalType As eCalType
    <Category("Common Parameters")>
    <DisplayName("CalType")>
    <Description("Set calculation type")>
    Public Property CalType As eCalType
        Get
            Return m_CalType
        End Get
        Set(ByVal value As eCalType)
            m_CalType = value
        End Set
    End Property
    Private m_VariableValue As Integer
    <Category("Common Parameters")>
    <DisplayName("Variable Value")>
    <Description("Set value in type")>
    Public Property VariableValue As Integer
        Get
            Return m_VariableValue
        End Get
        Set(ByVal value As Integer)
            m_VariableValue = value
        End Set
    End Property
    Public Sub New()
        Me.ID = CurrentID + 1
        Me.UserVariable = eUserVariable.NONE
        Me.CalType = eCalType.assign
        Me.VariableValue = 1
    End Sub
    Public Sub New(ByVal pUserVariable As eUserVariable, ByVal pCalType As eCalType, ByVal pVariableValue As Integer)
        Me.ID = CurrentID + 1
        Me.UserVariable = pUserVariable
        Me.CalType = pCalType
        Me.VariableValue = pVariableValue
    End Sub
    Public Overrides Function Clone() As CJobObject
        Return DirectCast(Me.MemberwiseClone(), CGVariable)
    End Function
End Class
Public Enum eUserVariable
    NONE
    IsJobRunning
    AirBlowing
    IsAlignOK
    IsBarcodeOK
    JobReadySignal
    UnlockSignal
    DischargeOK
End Enum
Public Enum eCalType
    assign
    plus
    minus
End Enum

Public Module MJobManager
    Public Function LoadListJob(ByVal pPath As String, ByRef pListJob As CListJob, Optional ByRef pError As Exception = Nothing) As Boolean
        LoadListJob = True
        Try
            Dim sr As StreamReader = New StreamReader(pPath, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            pListJob = JsonConvert.DeserializeObject(Of CListJob)(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            If (pListJob Is Nothing) Then
                pListJob = New CListJob()
            End If
            pListJob.Sort()
        Catch ex As Exception
            LoadListJob = False
            pError = ex
        End Try
    End Function
    Public Function SaveListJob(ByVal pPath As String, ByVal pListJob As CListJob, Optional ByRef pError As Exception = Nothing) As Boolean
        SaveListJob = True
        Try
            Dim res As String = JsonConvert.SerializeObject(pListJob, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw As StreamWriter = New StreamWriter(pPath, False, System.Text.Encoding.Default)
            sw.Write(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            SaveListJob = False
            pError = ex
        End Try
    End Function
End Module

#End Region

Public Module MLineManager
    Public LoadingProject As Boolean = False
    Public Function LoadListLine(ByVal pPath As String, ByRef pListJob As List(Of CLine), Optional ByRef pError As Exception = Nothing) As Boolean
        LoadListLine = True
        LoadingProject = True
        Try
            Dim sr As StreamReader = New StreamReader(pPath, System.Text.Encoding.Default)
            Dim res As String = sr.ReadToEnd()
            sr.Close()
            sr.Dispose()
            pListJob = JsonConvert.DeserializeObject(Of List(Of CLine))(res, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            If (pListJob Is Nothing) Then
                pListJob = New List(Of CLine)()
            End If

        Catch ex As Exception
            LoadListLine = False
            pError = ex
        End Try
        LoadingProject = False
    End Function
    Public Function SaveListLine(ByVal pPath As String, ByVal pListJob As List(Of CLine), Optional ByRef pError As Exception = Nothing) As Boolean
        SaveListLine = True
        Try
            Dim res As String = JsonConvert.SerializeObject(pListJob, Formatting.Indented, New JsonSerializerSettings With {.TypeNameHandling = TypeNameHandling.Auto})
            Dim sw As StreamWriter = New StreamWriter(pPath, False, System.Text.Encoding.Default)
            sw.Write(res)
            sw.Close()
            sw.Dispose()
        Catch ex As Exception
            SaveListLine = False
            pError = ex
        End Try
    End Function
End Module