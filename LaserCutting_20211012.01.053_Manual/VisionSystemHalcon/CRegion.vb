'Imports HalconDotNet

'Public Interface IGraphic
'    Function Duplicate() As IGraphic
'    Property ActiveColor() As String
'    Property StaticColor() As String
'    Property Interactive() As Boolean
'    Property LineWidth() As Integer
'End Interface

'Public Class CRectangle
'    Implements IDisposable, IGraphic
'    'Private managedResource As System.ComponentModel.Component
'    'Private unmanagedResource As IntPtr
'    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

'    ' IDisposable 
'    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
'        If Not Me.disposedValue Then
'            If disposing Then
'                ' TODO: 釋放其他狀態 (Managed 物件)。
'                'Call managedResource.Dispose()
'            End If
'            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
'            'unmanagedResource = IntPtr.Zero
'            ' TODO: 將大型欄位設定為 null。
'        End If
'        Me.disposedValue = True
'    End Sub

'#Region " IDisposable Support "
'    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
'    Public Sub Dispose() Implements IDisposable.Dispose
'        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
'        If m_HRegion IsNot Nothing Then Call m_HRegion.Dispose() : m_HRegion = Nothing
'        Dispose(True)
'        GC.SuppressFinalize(Me)
'    End Sub
'    Protected Overrides Sub Finalize()
'        Dispose(False)
'        MyBase.Finalize()
'    End Sub
'#End Region
'#Region "CONSTANT"

'#End Region
'#Region "Member"
'    Private m_HRegion As HRegion
'    Private m_LeftUpperY As Double
'    Private m_LeftUpperX As Double
'    Private m_RightLowerY As Double
'    Private m_RightLowerX As Double
'    Private m_Width As Double
'    Private m_Height As Double
'#End Region
'#Region "Constructors && Destructors"
'    Public Sub New()
'        Try
'            m_HRegion = New HRegion
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'#End Region
'#Region "Property"
'    ''' <summary>
'    ''' Y左上角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property LeftUpperY() As Double
'        Get
'            Return m_LeftUpperY
'        End Get
'    End Property
'    ''' <summary>
'    ''' X左上角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property LeftUpperX() As Double
'        Get
'            Return m_LeftUpperX
'        End Get
'    End Property
'    ''' <summary>
'    ''' Y右下角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property RightLowerY() As Double
'        Get
'            Return m_RightLowerY
'        End Get
'    End Property
'    ''' <summary>
'    ''' X右下角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property RightLowerX() As Double
'        Get
'            Return m_RightLowerX
'        End Get
'    End Property
'    ''' <summary>
'    ''' 寬度
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Width() As Double
'        Get
'            Return m_Width
'        End Get
'    End Property
'    ''' <summary>
'    ''' 高度
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Height() As Double
'        Get
'            Return m_Height
'        End Get
'    End Property
'    Friend Property BaseRegion() As HRegion
'        Get
'            Return m_HRegion
'        End Get
'        Set(ByVal value As HRegion)
'            m_HRegion = value
'        End Set
'    End Property

'#End Region
'#Region "Events"

'#End Region
'#Region "Methods"
'    ''' <summary>
'    ''' 產生不可旋轉角度矩形
'    ''' </summary>
'    ''' <param name="LeftUpperY"></param>
'    ''' <param name="LeftUpperX"></param>
'    ''' <param name="RightLowerY"></param>
'    ''' <param name="RightLowerX"></param>
'    ''' <remarks></remarks>
'    Public Sub GenRectangle1(ByVal LeftUpperX As Double, ByVal LeftUpperY As Double, ByVal RightLowerX As Double, ByVal RightLowerY As Double)
'        Try
'            Dim row1 As HTuple : row1 = New HTuple(LeftUpperY) : m_LeftUpperY = LeftUpperY
'            Dim col1 As HTuple : col1 = New HTuple(LeftUpperX) : m_LeftUpperX = LeftUpperX
'            Dim row2 As HTuple : row2 = New HTuple(RightLowerY) : m_RightLowerY = RightLowerY
'            Dim col2 As HTuple : col2 = New HTuple(RightLowerX) : m_RightLowerX = RightLowerX
'            m_Height = RightLowerY - LeftUpperY
'            m_Width = RightLowerX - LeftUpperX
'            If m_HRegion IsNot Nothing Then m_HRegion.Dispose() : m_HRegion = Nothing
'            m_HRegion = New HRegion()
'            m_HRegion.GenRectangle1(row1, col1, row2, col2)
'            row1 = Nothing
'            col1 = Nothing
'            row2 = Nothing
'            col2 = Nothing
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'    Friend Function GenBinaryImage(ByVal foregroundGray As Integer, ByVal backgroundGray As Integer, ByVal width As Integer, ByVal height As Integer) As CImage
'        Dim img As CImage = Nothing
'        Try
'            img = New CImage
'            ' img.BaseImage() = m_HRegion.RegionToBin(foregroundGray, backgroundGray, width, height)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'        Return img
'    End Function

'    Public Sub CopyTo(ByRef pDst As CRectangle)
'        Try
'            If m_HRegion Is Nothing Then
'                pDst = Nothing
'            Else
'                pDst.m_LeftUpperX = Me.m_LeftUpperX
'                pDst.m_LeftUpperY = Me.m_LeftUpperY
'                pDst.m_RightLowerX = Me.m_RightLowerX
'                pDst.m_RightLowerY = Me.m_RightLowerY
'                pDst.m_Width = Me.m_Width
'                pDst.m_Height = Me.m_Height
'                If pDst.m_HRegion IsNot Nothing Then pDst.m_HRegion.Dispose() : pDst.m_HRegion = Nothing
'                pDst.m_HRegion = New HRegion()
'                pDst.m_HRegion.GenRectangle1(pDst.m_LeftUpperX, pDst.m_LeftUpperY, pDst.m_RightLowerX, pDst.m_RightLowerY)
'            End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error")
'        End Try
'    End Sub
'#End Region
'    Private m_ActiveColor As String = "red"
'    Private m_Interactive As Boolean = False
'    Private m_LineWidth As Integer = 1
'    Private m_StaticColor As String = "red"
'    Public Property ActiveColor() As String Implements IGraphic.ActiveColor
'        Get
'            Return m_ActiveColor
'        End Get
'        Set(ByVal value As String)
'            m_ActiveColor = value
'        End Set
'    End Property
'    Public Property Interactive() As Boolean Implements IGraphic.Interactive
'        Get
'            Return m_Interactive
'        End Get
'        Set(ByVal value As Boolean)
'            m_Interactive = value
'        End Set
'    End Property

'    Public Property LineWidth() As Integer Implements IGraphic.LineWidth
'        Get
'            Return m_LineWidth
'        End Get
'        Set(ByVal value As Integer)
'            m_LineWidth = value
'        End Set
'    End Property

'    Public Property StaticColor() As String Implements IGraphic.StaticColor
'        Get
'            Return m_StaticColor
'        End Get
'        Set(ByVal value As String)
'            m_StaticColor = value
'        End Set
'    End Property

'    Public Function Duplicate() As IGraphic Implements IGraphic.Duplicate
'        Dim rectangle As CRectangle
'        rectangle = New CRectangle
'        Me.CopyTo(rectangle)
'        Return rectangle
'    End Function
'End Class

'Public Class CLineSegment
'    Implements IDisposable, IGraphic


'    'Private managedResource As System.ComponentModel.Component
'    'Private unmanagedResource As IntPtr
'    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

'    ' IDisposable 
'    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
'        If Not Me.disposedValue Then
'            If disposing Then
'                ' TODO: 釋放其他狀態 (Managed 物件)。
'                'Call managedResource.Dispose()
'            End If
'            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
'            'unmanagedResource = IntPtr.Zero
'            ' TODO: 將大型欄位設定為 null。
'        End If
'        Me.disposedValue = True
'    End Sub

'#Region " IDisposable Support "
'    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
'    Public Sub Dispose() Implements IDisposable.Dispose
'        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
'        If m_HRegion IsNot Nothing Then Call m_HRegion.Dispose() : m_HRegion = Nothing
'        Dispose(True)
'        GC.SuppressFinalize(Me)
'    End Sub
'    Protected Overrides Sub Finalize()
'        Dispose(False)
'        MyBase.Finalize()
'    End Sub
'#End Region
'#Region "CONSTANT"

'#End Region
'#Region "Member"
'    Private m_HRegion As HRegion
'    Private m_LeftUpperY As Double
'    Private m_LeftUpperX As Double
'    Private m_RightLowerY As Double
'    Private m_RightLowerX As Double
'    Private m_Width As Double
'    Private m_Height As Double
'#End Region
'#Region "Constructors && Destructors"
'    Public Sub New()
'        Try
'            m_HRegion = New HRegion
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error") 
'        End Try
'    End Sub
'#End Region
'#Region "Property"
'    ''' <summary>
'    ''' Y左上角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property LeftUpperY() As Double
'        Get
'            Return m_LeftUpperY
'        End Get
'    End Property
'    ''' <summary>
'    ''' X左上角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property LeftUpperX() As Double
'        Get
'            Return m_LeftUpperX
'        End Get
'    End Property
'    ''' <summary>
'    ''' Y右下角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property RightLowerY() As Double
'        Get
'            Return m_RightLowerY
'        End Get
'    End Property
'    ''' <summary>
'    ''' X右下角座標(四象限)
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property RightLowerX() As Double
'        Get
'            Return m_RightLowerX
'        End Get
'    End Property
'    ''' <summary>
'    ''' 寬度
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Width() As Double
'        Get
'            Return m_Width
'        End Get
'    End Property
'    ''' <summary>
'    ''' 高度
'    ''' </summary>
'    ''' <value></value>
'    ''' <returns></returns>
'    ''' <remarks></remarks>
'    Public ReadOnly Property Height() As Double
'        Get
'            Return m_Height
'        End Get
'    End Property
'    Friend Property BaseRegion() As HRegion
'        Get
'            Return m_HRegion
'        End Get
'        Set(ByVal value As HRegion)
'            m_HRegion = value
'        End Set
'    End Property

'#End Region
'#Region "Events"

'#End Region
'#Region "Methods"
'    ''' <summary>
'    ''' 產生不可旋轉角度矩形
'    ''' </summary>
'    ''' <param name="LeftUpperY"></param>
'    ''' <param name="LeftUpperX"></param>
'    ''' <param name="RightLowerY"></param>
'    ''' <param name="RightLowerX"></param>
'    ''' <remarks></remarks>
'    Public Sub GenRectangle1(ByVal LeftUpperX As Double, ByVal LeftUpperY As Double, ByVal RightLowerX As Double, ByVal RightLowerY As Double)
'        Try
'            Dim row1 As HTuple : row1 = New HTuple(LeftUpperY) : m_LeftUpperY = LeftUpperY
'            Dim col1 As HTuple : col1 = New HTuple(LeftUpperX) : m_LeftUpperX = LeftUpperX
'            Dim row2 As HTuple : row2 = New HTuple(RightLowerY) : m_RightLowerY = RightLowerY
'            Dim col2 As HTuple : col2 = New HTuple(RightLowerX) : m_RightLowerX = RightLowerX
'            m_Height = RightLowerY - LeftUpperY
'            m_Width = RightLowerX - LeftUpperX
'            If m_HRegion IsNot Nothing Then m_HRegion.Dispose() : m_HRegion = Nothing
'            m_HRegion = New HRegion()
'            m_HRegion.GenRectangle1(row1, col1, row2, col2)
'            row1 = Nothing
'            col1 = Nothing
'            row2 = Nothing
'            col2 = Nothing
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error") 
'        End Try
'    End Sub
'    Friend Function GenBinaryImage(ByVal foregroundGray As Integer, ByVal backgroundGray As Integer, ByVal width As Integer, ByVal height As Integer) As CImage
'        Dim img As CImage = Nothing
'        Try
'            img = New CImage
'            img.BaseImage() = m_HRegion.RegionToBin(foregroundGray, backgroundGray, width, height)
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error") 
'        End Try
'        Return img
'    End Function

'    Public Sub CopyTo(ByRef pDst As CRectangle)
'        Try
'            If m_HRegion Is Nothing Then
'                pDst = Nothing
'            Else
'                pDst.m_LeftUpperX = Me.m_LeftUpperX
'                pDst.m_LeftUpperY = Me.m_LeftUpperY
'                pDst.m_RightLowerX = Me.m_RightLowerX
'                pDst.m_RightLowerY = Me.m_RightLowerY
'                pDst.m_Width = Me.m_Width
'                pDst.m_Height = Me.m_Height
'                If pDst.m_HRegion IsNot Nothing Then pDst.m_HRegion.Dispose() : pDst.m_HRegion = Nothing
'                pDst.m_HRegion = New HRegion()
'                pDst.m_HRegion.GenRectangle1(pDst.m_LeftUpperX, pDst.m_LeftUpperY, pDst.m_RightLowerX, pDst.m_RightLowerY)
'            End If
'        Catch ex As Exception
'            Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "Critical Error") 
'        End Try
'    End Sub
'#End Region
'    Private m_ActiveColor As String = "red"
'    Private m_Interactive As Boolean = False
'    Private m_LineWidth As Integer = 1
'    Private m_StaticColor As String = "red"
'    Public Property ActiveColor() As String Implements IGraphic.ActiveColor
'        Get
'            Return m_ActiveColor
'        End Get
'        Set(ByVal value As String)
'            m_ActiveColor = value
'        End Set
'    End Property
'    Public Property Interactive() As Boolean Implements IGraphic.Interactive
'        Get
'            Return m_Interactive
'        End Get
'        Set(ByVal value As Boolean)
'            m_Interactive = value
'        End Set
'    End Property

'    Public Property LineWidth() As Integer Implements IGraphic.LineWidth
'        Get
'            Return m_LineWidth
'        End Get
'        Set(ByVal value As Integer)
'            m_LineWidth = value
'        End Set
'    End Property

'    Public Property StaticColor() As String Implements IGraphic.StaticColor
'        Get
'            Return m_StaticColor
'        End Get
'        Set(ByVal value As String)
'            m_StaticColor = value
'        End Set
'    End Property

'    Public Function Duplicate() As IGraphic Implements IGraphic.Duplicate
'        Dim rectangle As CRectangle
'        rectangle = New CRectangle
'        Me.CopyTo(rectangle)
'        Return rectangle
'    End Function
'End Class