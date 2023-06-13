Imports System
Imports System.Globalization
Imports System.Resources
Imports System.Reflection

Namespace GlobalizedPropertyGrid
    <AttributeUsage(AttributeTargets.[Property], AllowMultiple:=False, Inherited:=True)>
    Public Class GlobalizedPropertyAttribute
        Inherits Attribute

        Private resourceName As String = ""
        Private resourceDescription As String = ""
        Private resourceTable As String = ""

        Public Sub New(ByVal name As String)
            resourceName = name
        End Sub

        Public Property Name As String
            Get
                Return resourceName
            End Get
            Set(ByVal value As String)
                resourceName = value
            End Set
        End Property

        Public Property Description As String
            Get
                Return resourceDescription
            End Get
            Set(ByVal value As String)
                resourceDescription = value
            End Set
        End Property

        Public Property Table As String
            Get
                Return resourceTable
            End Get
            Set(ByVal value As String)
                resourceTable = value
            End Set
        End Property
    End Class
End Namespace
