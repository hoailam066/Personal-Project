Imports HalconDotNet
Imports Timer
Imports Xmler

Public Interface IGraphics
    Function Copy() As IGraphics
End Interface


Public Class CGraphicsList
    'Implements ICGraphic
    Private m_GraphicsList As List(Of IGraphics)
    Public Function Copy() As CGraphicsList 'Implements ICGraphic.Clone
        Dim regGrphc As CGraphicsList
        regGrphc = New CGraphicsList
        Call regGrphc.m_GraphicsList.Clear()
        For i As Integer = 0 To regGrphc.m_GraphicsList.Count - 1
            Call regGrphc.m_GraphicsList.Add(Me.m_GraphicsList.Item(i))
        Next
        Return regGrphc
    End Function
    Public Sub New()
        If m_GraphicsList Is Nothing Then m_GraphicsList = New List(Of IGraphics)
    End Sub
    'Public Function Add(ByVal graphic As ICGraphic) As Integer
    '    Try
    '        If graphic IsNot Nothing Then
    '            If Not mCGraphicsList.Contains(graphic) Then
    '                Call mCGraphicsList.Add(graphic)

    '                If mCGraphicsList.Count = 1 Then
    '                    mActiveID = 0
    '                End If
    '                Return 0
    '            Else
    '                Return -3
    '            End If
    '        Else
    '            Return -2
    '        End If
    '    Catch ex As Exception
    '        Call MessageBox.Show(ex.GetBaseException.ToString(), "@ Function CGraphicsList.Add()", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '        Return -1
    '    End Try
    'End Function

    'Public Function AddList(ByVal graphics As CGraphicsList) As Integer
    '    Try
    '        If graphics IsNot Nothing Then
    '            For i As Integer = 0 To (graphics.Count - 1) Step 1
    '                Call MyClass.Add(graphics.Item(i))
    '            Next i

    '            Return 0
    '        Else
    '            Return -2
    '        End If
    '    Catch ex As Exception
    '        Call MessageBox.Show(ex.GetBaseException.ToString(), "@ Function CGraphicsList.AddList()", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '        Return -1
    '    End Try
    'End Function

    'Default Public ReadOnly Property Item(ByVal index As Integer) As ICGraphic
    '    Get
    '        If index > -1 AndAlso index < mCGraphicsList.Count Then
    '            Return mCGraphicsList(index)
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

    'Public Function RemoveAt(ByVal index As Integer) As Integer
    '    If index > -1 AndAlso index < mCGraphicsList.Count Then
    '        Try
    '            Call mCGraphicsList.RemoveAt(index)

    '            If Not (mActiveID < mCGraphicsList.Count) Then
    '                mActiveID = (mCGraphicsList.Count - 1)
    '            End If

    '            Return 0

    '        Catch ex As Exception
    '            Call MessageBox.Show(ex.GetBaseException().ToString(), "@ Function CGraphicsList.RemoveAt()", MessageBoxButtons.OK, MessageBoxIcon.[Error])
    '            Return -1

    '        End Try
    '    Else
    '        Return -2

    '    End If
    'End Function

    'Public Function Remove(ByVal graphic As ICGraphic) As Integer
    '    Try
    '        If graphic IsNot Nothing Then
    '            Dim index As Integer = mCGraphicsList.IndexOf(graphic)
    '            If index > -1 Then
    '                Return (MyClass.RemoveAt(index))
    '            Else
    '                Return 2
    '            End If
    '        Else
    '            Return 1
    '        End If
    '    Catch ex As Exception
    '        Return -1
    '    End Try
    'End Function

    'Public Sub Clear()
    '    mCGraphicsList.Clear()
    '    mActiveID = -1
    'End Sub

    'Public ReadOnly Property Count() As Integer
    '    Get
    '        Return mCGraphicsList.Count
    '    End Get
    'End Property

    'Public Property ActiveID() As Integer
    '    Get
    '        Return mActiveID
    '    End Get
    '    Set(ByVal value As Integer)
    '        If value > -1 AndAlso value < mCGraphicsList.Count Then
    '            mActiveID = value
    '        End If
    '    End Set
    'End Property

    'Public ReadOnly Property ActiveItem() As ICGraphic
    '    Get
    '        If mActiveID > -1 Then
    '            Return mCGraphicsList.Item(mActiveID)
    '        Else
    '            Return Nothing
    '        End If
    '    End Get
    'End Property

    'Public Property ActiveColor() As CColorConstants Implements ICGraphic.ActiveColor
    '    Get
    '        If mActiveID > -1 Then
    '            Return mCGraphicsList(mActiveID).ActiveColor
    '        Else
    '            Return CColorConstants.Black
    '        End If
    '    End Get
    '    Set(ByVal value As CColorConstants)
    '        If mActiveID > -1 Then
    '            mCGraphicsList(mActiveID).ActiveColor = value
    '        End If
    '    End Set
    'End Property

    'Public Property StaticColor() As CColorConstants Implements ICGraphic.StaticColor
    '    Get
    '        If mActiveID > -1 Then
    '            Return mCGraphicsList(mActiveID).StaticColor
    '        Else
    '            Return CColorConstants.Black
    '        End If
    '    End Get
    '    Set(ByVal value As CColorConstants)
    '        If mActiveID > -1 Then
    '            mCGraphicsList(mActiveID).StaticColor = value
    '        End If
    '    End Set
    'End Property

    'Friend Property Interactive() As Boolean Implements ICGraphic.Interactive
    '    Get
    '        If mActiveID > -1 Then
    '            Return mCGraphicsList(mActiveID).Interactive
    '        Else
    '            Return False
    '        End If
    '    End Get
    '    Set(ByVal value As Boolean)
    '        If mActiveID > -1 Then
    '            mCGraphicsList(mActiveID).Interactive = value
    '        End If
    '    End Set
    'End Property
End Class

Public MustInherit Class CGraphics
    Implements IGraphics
    Public MustOverride Function Copy() As IGraphics Implements IGraphics.Copy
    Public Sub New()
    End Sub
    Public Sub New(ByVal CenterX As Double, ByVal CenterY As Double)
        Me.CenterX = CenterX
        Me.CenterY = CenterY
    End Sub
    Protected Overrides Sub Finalize()
    End Sub
    Private m_CenterX As Double
    Protected Property CenterX() As Double
        Get
            Return m_CenterX ' 
        End Get
        Set(ByVal value As Double)
            m_CenterX = value
        End Set
    End Property
    Private m_CenterY As Double
    Protected Property CenterY() As Double
        Get
            Return m_CenterY
        End Get
        Set(ByVal value As Double)
            m_CenterY = value
        End Set
    End Property
    Private m_LengthX As Double
    Protected Property LengthX() As Double
        Get
            Return m_LengthX
        End Get
        Set(ByVal value As Double)
            m_LengthX = value
        End Set
    End Property
    Private m_LengthY As Double
    Protected Property LengthY() As Double
        Get
            Return m_LengthY
        End Get
        Set(ByVal value As Double)
            m_LengthY = value
        End Set
    End Property
    Protected ReadOnly Property Area() As Double
        Get
            Return (m_LengthX * m_LengthY)
        End Get
    End Property
End Class

'長方形
Public Class CRectangle
    Inherits CGraphics
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub

#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        If m_Rectangle IsNot Nothing Then Call m_Rectangle.Dispose()
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"

#End Region
#Region "Member"
    Private m_LeftUpperY As Double
    ''' <summary>
    ''' Y左上角座標(四象限)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LeftUpperY() As Double
        Get
            Return m_LeftUpperY
        End Get
    End Property
    Private m_LeftUpperX As Double
    ''' <summary>
    ''' X左上角座標(四象限)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property LeftUpperX() As Double
        Get
            Return m_LeftUpperX
        End Get
    End Property
    Private m_RightLowerY As Double
    ''' <summary>
    ''' Y右下角座標(四象限)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RightLowerY() As Double
        Get
            Return m_RightLowerY
        End Get
    End Property
    Private m_RightLowerX As Double
    ''' <summary>
    ''' X右下角座標(四象限)
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property RightLowerX() As Double
        Get
            Return m_RightLowerX
        End Get
    End Property
    ''' <summary>
    ''' 寬度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Width() As Double
        Get
            Return MyBase.LengthX
        End Get
    End Property
    ''' <summary>
    ''' 高度
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public ReadOnly Property Height() As Double
        Get
            Return MyBase.LengthY
        End Get
    End Property
    Private m_Color As VisionColorConstants
    Public WriteOnly Property Color() As VisionColorConstants
        Set(ByVal value As VisionColorConstants)
            m_Color = value
        End Set
    End Property
    Private m_Rectangle As HRegion
    Friend Property Based() As HRegion
        Get
            Return m_Rectangle
        End Get
        Set(ByVal value As HRegion)
            If Not [Object].ReferenceEquals(m_Rectangle, value) Then Call m_Rectangle.Dispose()
            m_Rectangle = value
        End Set
    End Property
    Friend ReadOnly Property RotationD() As Double
        Get
            Return 0
        End Get
    End Property
    Friend ReadOnly Property RotationR() As Double
        Get
            Return 0
        End Get
    End Property
#End Region
#Region "Property"
    Public Overloads ReadOnly Property CenterX() As Double
        Get
            Return MyBase.CenterX
        End Get
    End Property
    Public Overloads ReadOnly Property Centery() As Double
        Get
            Return MyBase.CenterY
        End Get
    End Property
    Public Overloads ReadOnly Property LengthX() As Double
        Get
            Return MyBase.LengthX
        End Get
    End Property
    Public Overloads ReadOnly Property LengthY() As Double
        Get
            Return MyBase.LengthY
        End Get
    End Property
#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        m_Rectangle = New HRegion
        MyBase.CenterX = 200
        MyBase.CenterY = 200
        MyBase.LengthX = 50
        MyBase.LengthY = 20
        Call SetCenterLengthsRotation(MyBase.CenterX, MyBase.CenterY, MyBase.LengthX, MyBase.LengthY, 0)
        m_Color = VisionColorConstants.Red
    End Sub
#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Overrides Function Copy() As IGraphics
        Dim destObj As CRectangle
        destObj = New CRectangle
        Call CRectangle.CopyTo(Me, destObj)
        Return destObj
    End Function
    Friend Overloads Sub CopyTo(ByRef pDestObj As CRectangle)
        Call CRectangle.CopyTo(Me, pDestObj)
    End Sub
    Friend Overloads Shared Sub CopyTo(ByVal SrcObj As CRectangle, ByRef pDestObj As CRectangle)
        If Not [Object].ReferenceEquals(SrcObj, pDestObj) Then
            If SrcObj IsNot Nothing Then
                If pDestObj Is Nothing Then pDestObj = New CRectangle
                Call pDestObj.Dispose()
                pDestObj.Based() = SrcObj.Based().Clone()
                pDestObj.m_Color = SrcObj.m_Color
            Else
                pDestObj = Nothing
            End If
        End If
    End Sub
    Friend Overloads Sub CopyOf(ByVal SrcObj As CRectangle)
        If SrcObj IsNot Nothing Then
            Call CRectangle.CopyTo(SrcObj, Me)
        End If
    End Sub
    Public Sub SetCenterLengthsRotation(ByVal CenterX As Double, ByVal CenterY As Double, ByVal Width As Double, ByVal Height As Double, ByVal AngleD As Double)
        Try
            MyBase.CenterX = CenterX
            MyBase.CenterY = CenterY
            MyBase.LengthX = Width
            MyBase.LengthY = Height
            m_LeftUpperX = MyBase.CenterX - MyBase.LengthX / 2
            m_LeftUpperY = MyBase.CenterY - MyBase.LengthY / 2
            m_RightLowerX = MyBase.CenterX + MyBase.LengthX / 2
            m_RightLowerY = MyBase.CenterY + MyBase.LengthY / 2
            Dim row1 As HTuple : row1 = New HTuple(LeftUpperY) : m_LeftUpperY = LeftUpperY
            Dim col1 As HTuple : col1 = New HTuple(LeftUpperX) : m_LeftUpperX = LeftUpperX
            Dim row2 As HTuple : row2 = New HTuple(RightLowerY) : m_RightLowerY = RightLowerY
            Dim col2 As HTuple : col2 = New HTuple(RightLowerX) : m_RightLowerX = RightLowerX
            If m_Rectangle IsNot Nothing Then m_Rectangle.Dispose()
            m_Rectangle.GenRectangle1(row1, col1, row2, col2)
            row1 = Nothing : col1 = Nothing
            row2 = Nothing : col2 = Nothing
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GetCenterLengthsRotation(ByRef pCenterX As Double, ByRef pCenterY As Double, ByRef pWidth As Double, ByRef pHeight As Double, ByRef pAngleD As Double)
        Try
            pCenterX = MyBase.CenterX
            pCenterY = MyBase.CenterY
            pWidth = MyBase.LengthX
            pHeight = MyBase.LengthY
            pAngleD = 0 'RotationD
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ReadFromFile(ByVal FilePath As String)
        Dim xmlDoc As System.Xml.XmlDocument
        Dim rtnText As String = ""
        If Microsoft.VisualBasic.FileIO.FileSystem.FileExists(FilePath) Then
            xmlDoc = New System.Xml.XmlDocument
            Call xmlDoc.Load(FilePath)
            Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
            Dim stemNode As System.Xml.XmlElement
            stemNode = DirectCast(Xmler.CXmler.GetPreviousNode(rootNode, "Rectangle"), System.Xml.XmlElement)
            Dim CenterX As Double
            Dim CenterY As Double
            Dim LengthX As Double
            Dim LengthY As Double
            If Xmler.CXmler.GetXmlData(stemNode, "CenterX", 0, rtnText) Then CenterX = CDbl(rtnText)
            If Xmler.CXmler.GetXmlData(stemNode, "CenterY", 0, rtnText) Then CenterY = CDbl(rtnText)
            If Xmler.CXmler.GetXmlData(stemNode, "LengthX", 0, rtnText) Then LengthX = CDbl(rtnText)
            If Xmler.CXmler.GetXmlData(stemNode, "LengthY", 0, rtnText) Then LengthY = CDbl(rtnText)
            Call SetCenterLengthsRotation(CenterX, CenterY, LengthX, LengthY, RotationD)
        End If
    End Sub
    Public Sub WriteToFile(ByVal FilePath As String)
        Dim xmlDoc As System.Xml.XmlDocument = Xmler.CXmler.CreateXmlDoc("")
        Dim rootNode As System.Xml.XmlElement = xmlDoc.Item("RootNode")
        Dim nodeAttributes As New Dictionary(Of String, String)
        Call nodeAttributes.Add("Attributes", "")
        Dim stemNode As System.Xml.XmlElement
        stemNode = DirectCast(Xmler.CXmler.NewXmlNode(rootNode, "Rectangle", 0, nodeAttributes), System.Xml.XmlElement)
        Call Xmler.CXmler.NewXmlValue(stemNode, "CenterX", 0, CenterX)
        Call Xmler.CXmler.NewXmlValue(stemNode, "CenterY", 0, CenterY)
        Call Xmler.CXmler.NewXmlValue(stemNode, "LengthX", 0, LengthX)
        Call Xmler.CXmler.NewXmlValue(stemNode, "LengthY", 0, LengthY)
        Call Xmler.CXmler.NewXmlValue(stemNode, "RotationD", 0, RotationD)
        Call xmlDoc.Save(FilePath)
    End Sub
#End Region
End Class
'十字線
Public Class CReticle
    Inherits CGraphics
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"

#End Region
#Region "Member"
#End Region
#Region "Property"
    Private m_Length As Double = 15
    Public Property Length() As Double
        Get
            Return m_Length
        End Get
        Set(ByVal value As Double)
            m_Length = value
        End Set
    End Property
    Private m_AngleDeg As Double
    Public Property AngleDeg() As Double
        Get
            Return m_AngleDeg
        End Get
        Set(ByVal value As Double)
            m_AngleDeg = value
            m_AngleRad = m_AngleDeg * Math.PI / 180
        End Set
    End Property
    Private m_AngleRad As Double
    Public Property AngleRad() As Double
        Get
            Return m_AngleRad
        End Get
        Set(ByVal value As Double)
            m_AngleRad = value
            m_AngleDeg = m_AngleDeg * 180 / Math.PI
        End Set
    End Property
    Private m_Color As VisionColorConstants
    Public Property Color() As VisionColorConstants
        Get
            Return m_Color
        End Get
        Set(ByVal value As VisionColorConstants)
            m_Color = value
        End Set
    End Property
    Public Property X() As Double
        Get
            Return MyBase.CenterX
        End Get
        Set(ByVal value As Double)
            MyBase.CenterX = value
        End Set
    End Property
    Public Property Y() As Double
        Get
            Return MyBase.CenterY
        End Get
        Set(ByVal value As Double)
            MyBase.CenterY = value
        End Set
    End Property
#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        Call MyBase.New()
    End Sub
    Friend Sub New(ByVal X As Double, ByVal Y As Double, ByVal AngleDeg As Double)
        Call MyClass.New()
        MyBase.CenterX = X
        MyBase.CenterY = Y
        Me.AngleDeg = AngleDeg
    End Sub
#End Region
#Region "Events"

#End Region
#Region "Methods"
    Public Overrides Function Copy() As IGraphics
        Dim pointMarker As New CReticle
        Call MyClass.CopyTo(pointMarker)
        Return pointMarker
    End Function
    Friend Shared Sub CopyTo(ByVal SrcObj As CReticle, ByRef pDstObj As CReticle)
        If Not [Object].ReferenceEquals(SrcObj, pDstObj) Then
            If SrcObj IsNot Nothing Then
                If pDstObj Is Nothing Then
                    pDstObj = New CReticle(SrcObj.CenterX, SrcObj.CenterY, SrcObj.m_AngleDeg)
                Else
                    pDstObj.CenterX = SrcObj.CenterX
                    pDstObj.CenterY = SrcObj.CenterY
                    pDstObj.AngleDeg = SrcObj.m_AngleDeg
                End If
                pDstObj.Length = SrcObj.Length
            Else
                pDstObj = Nothing
            End If
        End If
    End Sub
    Friend Sub CopyTo(ByRef pDstObj As CReticle)
        Call CReticle.CopyTo(Me, pDstObj)
    End Sub
    Friend Sub CopyOf(ByVal SrcObj As CReticle)
        If SrcObj IsNot Nothing Then
            Call CReticle.CopyTo(SrcObj, Me)
        End If
    End Sub
#End Region
End Class
'井字線
Public Class CCrissCross
    Inherits CGraphics
    Private m_ColCnt As Integer
    Public Property ColCnt() As Integer
        Get
            Return m_ColCnt
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                m_ColCnt = value
            End If
        End Set
    End Property
    Private m_ColDist As Double
    Public Property ColDist() As Double
        Get
            Return m_ColDist
        End Get
        Set(ByVal value As Double)
            If value >= 0 Then
                m_ColDist = value
            End If
        End Set
    End Property
    Private m_RowCnt As Integer
    Public Property RowCnt() As Integer
        Get
            Return m_RowCnt
        End Get
        Set(ByVal value As Integer)
            If value > 0 Then
                m_RowCnt = value
            End If
        End Set
    End Property
    Private m_RowDist As Double
    Public Property RowDist() As Double
        Get
            Return m_RowDist
        End Get
        Set(ByVal value As Double)
            If value >= 0 Then
                m_RowDist = value
            End If
        End Set
    End Property
    Private m_LengthW As Double = 20000
    Public Property LengthW() As Double
        Get
            Return m_LengthW
        End Get
        Set(ByVal value As Double)
            If value < 0.5 Then
                ' 維持原長度...
            ElseIf value > 2000000 Then
                ' 維持原長度...
            Else
                m_LengthW = value
            End If
        End Set
    End Property
    Private m_LengthH As Double = 20000
    Public Property LengthH() As Double
        Get
            Return m_LengthH
        End Get
        Set(ByVal value As Double)
            If value < 0.5 Then
                ' 維持原長度...
            ElseIf value > 2000000 Then
                ' 維持原長度...
            Else
                m_LengthH = value
            End If
        End Set
    End Property
    Private m_AngleDeg As Double
    Public Property AngleDeg() As Double
        Get
            Return m_AngleDeg
        End Get
        Set(ByVal Value As Double)
            m_AngleDeg = Value
            m_AngleRad = Value * Math.PI / 180
        End Set
    End Property
    Private m_AngleRad As Double
    Public Property AngleRad() As Double
        Get
            Return m_AngleRad
        End Get
        Set(ByVal value As Double)
            m_AngleDeg = value * 180 / Math.PI
            m_AngleRad = value
        End Set
    End Property
    Public Sub New()
        Call MyBase.New()
        m_ColCnt = 1
        m_RowCnt = 1
    End Sub
    Public Overrides Function Copy() As IGraphics
        Dim sharpMarker As CCrissCross
        sharpMarker = New CCrissCross
        Call sharpMarker.SetAppearanceProperties(MyBase.CenterX, MyBase.CenterY, Me.m_ColCnt, Me.m_RowCnt, Me.m_ColDist, Me.m_RowDist, Me.m_AngleDeg, Me.m_LengthW, Me.m_LengthH)
        Return sharpMarker
    End Function
    Public Sub GetAppearanceProperties(ByRef pCneterX As Double, ByRef pCneterY As Double, Optional ByRef pColCnt As Integer = 1, Optional ByRef pRowCnt As Integer = 1, Optional ByRef pColDist As Double = 0, Optional ByRef pRowDist As Double = 0, Optional ByRef pAngleDeg As Double = 0, Optional ByRef pLengthW As Double = 0, Optional ByRef pLengthH As Double = 0)
        pCneterX = MyBase.CenterX : pCneterY = MyBase.CenterY
        pColCnt = m_ColCnt : pColDist = m_ColDist
        pRowCnt = m_RowCnt : pRowDist = m_RowDist
        pAngleDeg = m_AngleDeg
        pLengthW = m_LengthW
        pLengthH = m_LengthH
    End Sub
    Public Sub SetAppearanceProperties(ByVal CneterX As Double, ByVal CneterY As Double, Optional ByVal ColsCount As Integer = 1, Optional ByVal RowsCount As Integer = 1, Optional ByVal ColsDistX As Double = 0, Optional ByVal RowsDistY As Double = 0, Optional ByVal AngleDeg As Double = 0, Optional ByVal LengthW As Double = 0, Optional ByVal LengthH As Double = 0)
        MyBase.CenterX = CneterX : MyBase.CenterY = CneterY
        m_ColCnt = ColsCount : m_ColDist = ColsDistX
        m_RowCnt = RowsCount : m_RowDist = RowsDistY
        Me.AngleDeg = AngleDeg
        Me.LengthW = LengthW
        Me.LengthH = LengthH
    End Sub
End Class

Public Class CLineSegment
    Inherits CGraphics
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Private m_Points As List(Of CReticle)
    Private m_AngleDeg As Double     ' Angle in Deg
    Private m_AngleRad As Double     ' Angle in Rad
    Private m_Length As Double
    Public Sub New()
        MyBase.New()
        m_Points = New List(Of CReticle)
        m_Points.Add(New CReticle(10, 10, 0))
        m_Points.Add(New CReticle(20, 10, 0))
    End Sub
    Public Overrides Function Copy() As IGraphics
        Dim regGrphic As New CLineSegment
        Call regGrphic.SetOriginEndPos(Me.OriginX, Me.OriginY, Me.EndPosX, Me.EndPosY)
        Return regGrphic
    End Function
    Public Property AngleDeg() As Double
        Get
            Return m_AngleDeg
        End Get
        Protected Set(ByVal Value As Double)
            m_AngleDeg = Value
            m_AngleRad = Value * Math.PI / 180

            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
            Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)

        End Set
    End Property
    Public Property AngleRad() As Double
        Get
            Return m_AngleRad
        End Get
        Protected Set(ByVal value As Double)
            m_AngleDeg = value * 180 / Math.PI
            m_AngleRad = value
            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).Y)
            Dim dy As Double = (m_Points.Item(1).X - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)

        End Set
    End Property
    Public ReadOnly Property Length() As Double
        Get
            Return m_Length
        End Get
    End Property
    Public Property OriginX() As Double
        Get
            Return m_Points.Item(0).X
        End Get
        Set(ByVal value As Double)
            m_Points.Item(0).X = value

            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
            Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)
            MyClass.AngleRad = Math.Atan2(dy, dx)
        End Set
    End Property
    Public Property OriginY() As Double
        Get
            Return m_Points.Item(0).Y
        End Get
        Set(ByVal value As Double)
            m_Points.Item(0).Y = value

            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
            Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)
            MyClass.AngleRad = Math.Atan2(dy, dx)
        End Set
    End Property
    Public Property EndPosX() As Double
        Get
            Return m_Points.Item(1).X
        End Get
        Set(ByVal value As Double)
            m_Points.Item(1).X = value

            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
            Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)
            MyClass.AngleRad = Math.Atan2(dy, dx)
        End Set
    End Property
    Public Property EndPosY() As Double
        Get
            Return m_Points.Item(1).Y
        End Get
        Set(ByVal value As Double)
            m_Points.Item(1).Y = value

            Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
            Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
            m_Length = Math.Sqrt(dx * dx + dy * dy)
            MyClass.AngleRad = Math.Atan2(dy, dx)
        End Set
    End Property

    Public Sub GetOriginEndPos(Optional ByRef OriginX As Double = 0, Optional ByRef OriginY As Double = 0, Optional ByRef EndPosX As Double = 0, Optional ByRef EndPosY As Double = 0)
        OriginX = m_Points.Item(0).X
        OriginY = m_Points.Item(0).Y
        EndPosX = m_Points.Item(1).X
        EndPosY = m_Points.Item(1).Y
    End Sub
    Public Function SetOriginEndPos(ByVal originX As Double, ByVal originY As Double, ByVal endPosX As Double, ByVal endPosY As Double) As Integer
        Me.OriginX = originX
        Me.OriginY = originY
        Me.EndPosX = endPosX
        Me.EndPosY = endPosY

        Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
        Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
        m_Length = Math.Sqrt(dx * dx + dy * dy)
        MyClass.AngleRad = Math.Atan2(dy, dx)
    End Function

    Public Sub GetOriginLengthAngleDeg(Optional ByRef originX As Double = 0, Optional ByRef originY As Double = 0, Optional ByRef length As Double = 0, Optional ByRef angleDeg As Double = 0)
        originX = m_Points.Item(0).X
        originY = m_Points.Item(0).Y
        length = m_Length
        angleDeg = m_AngleDeg
    End Sub
    Public Function SetOriginLengthAngleDeg(ByVal originX As Double, ByVal originY As Double, ByVal length As Double, ByVal angleDeg As Double) As Integer
        Dim AngeleRad As Double = angleDeg * Math.PI / 180
        Me.OriginX = originX
        Me.OriginY = originY
        Me.EndPosX = length * Math.Cos(AngeleRad)
        Me.EndPosY = length * Math.Sin(AngeleRad)

        Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
        Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
        m_Length = Math.Sqrt(dx * dx + dy * dy)


    End Function
    Public Sub GetCenterLengthAngleDeg(Optional ByRef centerX As Double = 0, Optional ByRef centerY As Double = 0, Optional ByRef length As Double = 0, Optional ByRef angleDeg As Double = 0)
        centerX = (m_Points.Item(0).X + m_Points.Item(1).X) / 2
        centerY = (m_Points.Item(0).Y + m_Points.Item(1).Y) / 2
        length = m_Length
        angleDeg = m_AngleDeg
    End Sub
    Public Function SetCenterLengthAngleDeg(ByVal centerX As Double, ByVal centerY As Double, ByVal length As Double, ByVal angleDeg As Double) As Integer
        Dim AngeleRad As Double = angleDeg * Math.PI / 180
        Me.OriginX = centerX - 0.5 * length * Math.Cos(AngeleRad)
        Me.OriginY = centerY - 0.5 * length * Math.Sin(AngeleRad)
        Me.EndPosX = centerX + 0.5 * length * Math.Cos(AngeleRad)
        Me.EndPosY = centerY + 0.5 * length * Math.Sin(AngeleRad)

        Dim dx As Double = (m_Points.Item(1).X - m_Points.Item(0).X)
        Dim dy As Double = (m_Points.Item(1).Y - m_Points.Item(0).Y)
        m_Length = Math.Sqrt(dx * dx + dy * dy)
    End Function
End Class
Public Class CCircle
    Inherits CGraphics
    Implements IDisposable
    Private disposedValue As Boolean = False        ' 偵測多餘的呼叫

    ' IDisposable
    Protected Overridable Sub Dispose(ByVal disposing As Boolean)
        If Not Me.disposedValue Then
            If disposing Then
                ' TODO: 釋放其他狀態 (Managed 物件)。
            End If

            ' TODO: 釋放您自己的狀態 (Unmanaged 物件)
            ' TODO: 將大型欄位設定為 null。
        End If
        Me.disposedValue = True
    End Sub
#Region " IDisposable Support "
    ' 由 Visual Basic 新增此程式碼以正確實作可處置的模式。
    Public Sub Dispose() Implements IDisposable.Dispose
        ' 請勿變更此程式碼。在以上的 Dispose 置入清除程式碼 (ByVal 視為布林值處置)。
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
    Private m_Radius As Double
    Public Property Radius As Double
        Get
            Return m_Radius
        End Get
        Set(ByVal value As Double)
            m_Radius = value
        End Set
    End Property
    Public Overloads Property CenterX As Double
        Get
            Return MyBase.CenterX
        End Get
        Set(ByVal value As Double)
            MyBase.CenterX = value
        End Set
    End Property
    Public Overloads Property CenterY As Double
        Get
            Return MyBase.CenterY
        End Get
        Set(ByVal value As Double)
            MyBase.CenterY = value
        End Set
    End Property
    Private m_IsSpotSize As Boolean = False
    Public Property IsSpotSize As Boolean
        Get
            Return m_IsSpotSize
        End Get
        Set(ByVal value As Boolean)
            m_IsSpotSize = value
        End Set
    End Property
    Public Overrides Function Copy() As IGraphics
        Dim res As CCircle = New CCircle()
        res.CenterX = Me.CenterX
        res.CenterY = Me.CenterY
        res.Radius = Me.Radius
        res.IsSpotSize = Me.IsSpotSize
        Return res
    End Function
End Class