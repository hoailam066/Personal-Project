Imports System
Imports System.ComponentModel
Imports System.Globalization
Imports System.Resources
Imports System.Reflection

Namespace GlobalizedPropertyGrid
    Public Class GlobalizedPropertyDescriptor
        Inherits PropertyDescriptor

        Private basePropertyDescriptor As PropertyDescriptor
        Private localizedName As String = ""
        Private localizedDescription As String = ""
        Private localizedCategory As String = ""

        Public Sub New(ByVal basePropertyDescriptor As PropertyDescriptor)
            MyBase.New(basePropertyDescriptor)
            Me.basePropertyDescriptor = basePropertyDescriptor
        End Sub

        Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
            Return basePropertyDescriptor.CanResetValue(component)
        End Function

        Public Overrides ReadOnly Property ComponentType As Type
            Get
                Return basePropertyDescriptor.ComponentType
            End Get
        End Property

        Public Overrides ReadOnly Property DisplayName As String
            Get
                Dim tableName As String = ""
                Dim pDisplayName As String = ""

                For Each oAttrib As Attribute In Me.basePropertyDescriptor.Attributes

                    If oAttrib.[GetType]().Equals(GetType(GlobalizedPropertyAttribute)) Then
                        pDisplayName = (CType(oAttrib, GlobalizedPropertyAttribute)).Name
                        tableName = (CType(oAttrib, GlobalizedPropertyAttribute)).Table
                    End If
                Next

                If tableName.Length = 0 Then tableName = basePropertyDescriptor.ComponentType.[Namespace] & "." & basePropertyDescriptor.ComponentType.Name
                If pDisplayName.Length = 0 Then pDisplayName = Me.basePropertyDescriptor.DisplayName
                Dim rm As ResourceManager = New ResourceManager(tableName, basePropertyDescriptor.ComponentType.Assembly)
                Dim s As String = rm.GetString(pDisplayName)
                If (s Is Nothing) Then
                    s = rm.GetString("[" & pDisplayName & "]")
                End If
                Me.localizedName = If((s IsNot Nothing), s, Me.basePropertyDescriptor.DisplayName)
                Return Me.localizedName
            End Get
        End Property

        Public Overrides ReadOnly Property Description As String
            Get
                Dim tableName As String = ""
                Dim pDescription As String = ""

                For Each oAttrib As Attribute In Me.basePropertyDescriptor.Attributes

                    If oAttrib.[GetType]().Equals(GetType(GlobalizedPropertyAttribute)) Then
                        pDescription = (CType(oAttrib, GlobalizedPropertyAttribute)).Description
                        tableName = (CType(oAttrib, GlobalizedPropertyAttribute)).Table
                    End If
                Next

                If tableName.Length = 0 Then tableName = basePropertyDescriptor.ComponentType.[Namespace] & "." & basePropertyDescriptor.ComponentType.Name
                If pDescription.Length = 0 Then pDescription = Me.basePropertyDescriptor.DisplayName & "Description"
                Dim rm As ResourceManager = New ResourceManager(tableName, basePropertyDescriptor.ComponentType.Assembly)
                Dim s As String = rm.GetString(pDescription)
                If (s Is Nothing) Then
                    s = rm.GetString("[" & pDescription & "]")
                End If
                Me.localizedDescription = If((s IsNot Nothing), s, Me.basePropertyDescriptor.DisplayName)
                Return Me.localizedDescription
            End Get
        End Property

        Public Overrides ReadOnly Property Category As String
            Get
                Dim tableName As String = ""
                Dim pCategory As String = ""

                For Each oAttrib As Attribute In Me.basePropertyDescriptor.Attributes

                    If oAttrib.[GetType]().Equals(GetType(GlobalizedPropertyAttribute)) Then
                        pCategory = (CType(oAttrib, GlobalizedPropertyAttribute)).Description
                        tableName = (CType(oAttrib, GlobalizedPropertyAttribute)).Table
                    End If
                Next

                If tableName.Length = 0 Then tableName = basePropertyDescriptor.ComponentType.[Namespace] & "." & basePropertyDescriptor.ComponentType.Name
                If pCategory.Length = 0 Then pCategory = Me.basePropertyDescriptor.DisplayName & "Category"
                Dim rm As ResourceManager = New ResourceManager(tableName, basePropertyDescriptor.ComponentType.Assembly)
                Dim s As String = rm.GetString(pCategory)
                If (s Is Nothing) Then
                    s = rm.GetString("[" & pCategory & "]")
                End If
                Me.localizedCategory = If((s IsNot Nothing), s, "")
                Return Me.localizedCategory
            End Get
        End Property

        Public Overrides Function GetValue(ByVal component As Object) As Object
            Return Me.basePropertyDescriptor.GetValue(component)
        End Function

        Public Overrides ReadOnly Property IsReadOnly As Boolean
            Get
                Return Me.basePropertyDescriptor.IsReadOnly
            End Get
        End Property

        Public Overrides ReadOnly Property Name As String
            Get
                Return Me.basePropertyDescriptor.Name
            End Get
        End Property

        Public Overrides ReadOnly Property PropertyType As Type
            Get
                Return Me.basePropertyDescriptor.PropertyType
            End Get
        End Property

        Public Overrides Sub ResetValue(ByVal component As Object)
            Me.basePropertyDescriptor.ResetValue(component)
        End Sub

        Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
            Return Me.basePropertyDescriptor.ShouldSerializeValue(component)
        End Function

        Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
            Me.basePropertyDescriptor.SetValue(component, value)
        End Sub
    End Class

    Public Class GlobalizedObject
        Implements ICustomTypeDescriptor

        Private globalizedProps As PropertyDescriptorCollection

        Public Function GetClassName() As String Implements ICustomTypeDescriptor.GetClassName
            Return TypeDescriptor.GetClassName(Me, True)
        End Function

        Public Function GetAttributes() As AttributeCollection Implements ICustomTypeDescriptor.GetAttributes
            Return TypeDescriptor.GetAttributes(Me, True)
        End Function

        Public Function GetComponentName() As String Implements ICustomTypeDescriptor.GetComponentName
            Return TypeDescriptor.GetComponentName(Me, True)
        End Function

        Public Function GetConverter() As TypeConverter Implements ICustomTypeDescriptor.GetConverter
            Return TypeDescriptor.GetConverter(Me, True)
        End Function

        Public Function GetDefaultEvent() As EventDescriptor Implements ICustomTypeDescriptor.GetDefaultEvent
            Return TypeDescriptor.GetDefaultEvent(Me, True)
        End Function

        Public Function GetDefaultProperty() As PropertyDescriptor Implements ICustomTypeDescriptor.GetDefaultProperty
            Return TypeDescriptor.GetDefaultProperty(Me, True)
        End Function

        Public Function GetEditor(ByVal editorBaseType As Type) As Object Implements ICustomTypeDescriptor.GetEditor
            Return TypeDescriptor.GetEditor(Me, editorBaseType, True)
        End Function

        Public Function GetEvents(ByVal attributes As Attribute()) As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, attributes, True)
        End Function

        Public Function GetEvents() As EventDescriptorCollection Implements ICustomTypeDescriptor.GetEvents
            Return TypeDescriptor.GetEvents(Me, True)
        End Function

        Public Function GetProperties(ByVal attributes As Attribute()) As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            If globalizedProps Is Nothing Then
                Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, attributes, True)
                globalizedProps = New PropertyDescriptorCollection(Nothing)

                For Each oProp As PropertyDescriptor In baseProps
                    globalizedProps.Add(New GlobalizedPropertyDescriptor(oProp))
                Next
            End If

            Return globalizedProps
        End Function

        Public Function GetProperties() As PropertyDescriptorCollection Implements ICustomTypeDescriptor.GetProperties
            If globalizedProps Is Nothing Then
                Dim baseProps As PropertyDescriptorCollection = TypeDescriptor.GetProperties(Me, True)
                globalizedProps = New PropertyDescriptorCollection(Nothing)

                For Each oProp As PropertyDescriptor In baseProps
                    globalizedProps.Add(New GlobalizedPropertyDescriptor(oProp))
                Next
            End If

            Return globalizedProps
        End Function

        Public Function GetPropertyOwner(ByVal pd As PropertyDescriptor) As Object Implements ICustomTypeDescriptor.GetPropertyOwner
            Return Me
        End Function
    End Class
End Namespace
