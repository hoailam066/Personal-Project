Imports System.Runtime.InteropServices

Public Class DragHelper
    <DllImport("comctl32.dll")>
    Public Shared Function InitCommonControls() As Boolean
    End Function
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ImageList_BeginDrag(ByVal himlTrack As IntPtr, ByVal iTrack As Integer, ByVal dxHotspot As Integer, ByVal dyHotspot As Integer) As Boolean
    End Function
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ImageList_DragMove(ByVal x As Integer, ByVal y As Integer) As Boolean
    End Function
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Sub ImageList_EndDrag()
    End Sub
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ImageList_DragEnter(ByVal hwndLock As IntPtr, ByVal x As Integer, ByVal y As Integer) As Boolean
    End Function
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ImageList_DragLeave(ByVal hwndLock As IntPtr) As Boolean
    End Function
    <DllImport("comctl32.dll", CharSet:=CharSet.Auto)>
    Public Shared Function ImageList_DragShowNolock(ByVal fShow As Boolean) As Boolean

    End Function
    Shared Sub New()
        InitCommonControls()
    End Sub
End Class
