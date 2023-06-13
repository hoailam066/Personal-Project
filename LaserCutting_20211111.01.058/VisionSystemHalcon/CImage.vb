Imports HalconDotNet

Public Interface IImage
    Sub CopyOf(ByRef pSrcImage As CImage)
    Sub CopyTo(ByRef pDestImage As CImage)
    ReadOnly Property Height() As Double
    Sub ReadImage(ByVal fileName As String)
    ReadOnly Property Width() As Double
    Sub WriteImage(ByVal fileName As String)
End Interface

Public MustInherit Class CImageBased
    Friend MustOverride Function CropPart(ByVal LeftTopX As Integer, ByVal LeftTopY As Integer, ByVal Width As Integer, ByVal Height As Integer) As CImage
End Class
Public Class CImage
    Inherits CImageBased
    Implements IImage
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
        If m_BasedImage IsNot Nothing Then Call m_BasedImage.Dispose()
        Dispose(True)
        GC.SuppressFinalize(Me)
    End Sub
#End Region
#Region "CONSTANT"
#End Region
#Region "Member"

#End Region
#Region "Property"
    Private m_BasedImage As HImage
    Friend Property Based() As HImage
        Get
            Return m_BasedImage
        End Get
        Set(ByVal value As HImage)
            If m_BasedImage IsNot Nothing Then Call m_BasedImage.Dispose()
            m_BasedImage = value
            Dim ptr As System.IntPtr
            ptr = m_BasedImage.GetImagePointer1("bmp", m_Width, m_Height)
        End Set
    End Property
    Private m_Height As Integer
    Public ReadOnly Property Height() As Double Implements IImage.Height
        Get
            Return m_Height
        End Get
    End Property
    Private m_Width As Integer
    Public ReadOnly Property Width() As Double Implements IImage.Width
        Get
            Return m_Width
        End Get
    End Property

   

#End Region
#Region "Constructors && Destructors"
    Public Sub New()
        Try
            If m_BasedImage Is Nothing Then m_BasedImage = New HImage
            Call m_BasedImage.Dispose()
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->New")
        End Try
    End Sub
#End Region
#Region "Events"
    Friend Event Changed()
#End Region
#Region "Methods"
    ''' <summary>
    ''' 從來源複製
    ''' </summary>
    ''' <param name="pSrcImage"></param>
    ''' <remarks></remarks>
    Public Sub CopyOf(ByRef pSrcImage As CImage) Implements IImage.CopyOf
        Try
            If pSrcImage IsNot Nothing Then pSrcImage.CopyTo(Me)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CopyOf")
        End Try
    End Sub
    ''' <summary>
    ''' 複製到目標 
    ''' </summary>
    ''' <param name="pDestImage"></param>
    ''' <remarks></remarks>
    Public Sub CopyTo(ByRef pDestImage As CImage) Implements IImage.CopyTo
        Try
            Dim ptr As System.IntPtr
            If pDestImage Is Nothing Then pDestImage = New CImage
            pDestImage.Based().Dispose()
            pDestImage.Based() = m_BasedImage.CopyImage()
            ptr = pDestImage.Based().GetImagePointer1("bmp", pDestImage.m_Width, pDestImage.m_Height)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CopyTo")
        End Try
    End Sub
    Friend Sub RaiseChangedEvent()
        RaiseEvent Changed()
    End Sub
    ''' <summary>
    ''' 讀取影像檔案 
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Public Sub ReadImage(ByVal fileName As String) Implements IImage.ReadImage
        Dim ptr As System.IntPtr
        Try
            Call m_BasedImage.ReadImage(fileName)
            ptr = m_BasedImage.GetImagePointer1("bmp", m_Width, m_Height)
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->ReadImage")
        End Try
    End Sub
    ''' <summary>
    ''' 儲存檔案 
    ''' </summary>
    ''' <param name="fileName"></param>
    ''' <remarks></remarks>
    Public Sub WriteImage(ByVal fileName As String) Implements IImage.WriteImage
        Try
            Call m_BasedImage.WriteImage("bmp", 0, fileName)
        Catch ex As Exception
            'Dim errCode As String
            'errCode = ex.Message.Replace("HALCON", "")
            'Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->WriteImage")
        End Try
    End Sub
    'Public Function ReduceDomain(ByVal Region As CRectangle) As CImage
    '    Dim ptr As System.IntPtr
    '    Dim image As CImage = Nothing
    '    Dim hRegion As HRegion = Nothing
    '    Try
    '        hRegion = New HRegion
    '        Call hRegion.GenRectangle1(Region.LeftUpperX, Region.LeftUpperY, Region.RightLowerX, Region.RightLowerY)
    '        image = New CImage
    '        image.m_HImage = m_HImage.ReduceDomain(hRegion)
    '        ptr = image.m_HImage.GetImagePointer1("", image.m_Width, image.m_Height)
    '        hRegion.Dispose() : hRegion = Nothing
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "CImage->ReduceDomain")
    '    End Try
    '    Return image
    'End Function
    'Public Sub SetGrayValueRectangle(ByVal X As Double, ByVal Y As Double, ByVal Width As Integer, ByVal Height As Integer, ByVal GrayValue As Integer)
    '    Dim col As HTuple = Nothing : col = New HTuple(0)
    '    Dim row As HTuple = Nothing : row = New HTuple(0)
    '    Dim gray As HTuple = Nothing : gray = New HTuple(0)
    '    Try
    '        gray.I() = GrayValue
    '        For i As Integer = CInt(-1 * (Width - 1) / 2) To CInt((Width - 1) / 2)
    '            For j As Integer = CInt(-1 * (Height - 1) / 2) To CInt((Height - 1) / 2)
    '                col.I() = CInt(i + X)
    '                row.I() = CInt(j + Y)
    '                m_HImage.SetGrayval(row, col, gray)
    '            Next
    '        Next
    '    Catch ex As Exception
    '        Call MsgBox(ex.Message(), MsgBoxStyle.Critical, "CImage->SetGrayValueRectangle") 
    '    End Try
    'End Sub
    ''' <summary>
    ''' 剪裁圖片
    ''' </summary>
    ''' <param name="LeftTopX"></param>
    ''' <param name="LeftTopY"></param>
    ''' <param name="Width"></param>
    ''' <param name="Height"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Overrides Function CropPart(ByVal LeftTopX As Integer, ByVal LeftTopY As Integer, ByVal Width As Integer, ByVal Height As Integer) As CImage
        Try
            Dim ptr As System.IntPtr
            Dim dstImage As CImage : dstImage = New CImage
            dstImage.Based() = m_BasedImage.CropPart(LeftTopY, LeftTopX, Width, Height)
            ptr = dstImage.Based().GetImagePointer1("bmp", dstImage.m_Width, dstImage.m_Height)
            Return dstImage
        Catch ex As Exception
            Dim errCode As String
            errCode = ex.Message.Replace("HALCON", "")
            Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CropPart")
            Return Nothing
        End Try
    End Function

    Public Function CropPart_Public(ByVal LeftTopX As Integer, ByVal LeftTopY As Integer, ByVal RightDownX As Integer, ByVal RightDownY As Integer) As CImage
        Try
            Dim ptr As System.IntPtr
            Dim dstImage As CImage : dstImage = New CImage
            dstImage.Based() = m_BasedImage.CropRectangle1(LeftTopY, LeftTopX, RightDownY, RightDownX)
            ptr = dstImage.Based().GetImagePointer1("bmp", dstImage.m_Width, dstImage.m_Height)
            Return dstImage
        Catch ex As Exception
            'Dim errCode As String
            'errCode = ex.Message.Replace("HALCON", "")
            'Call MsgBox(errCode, MsgBoxStyle.Critical, "CImage->CropPart")
            Return Nothing
        End Try
    End Function
#End Region
End Class




