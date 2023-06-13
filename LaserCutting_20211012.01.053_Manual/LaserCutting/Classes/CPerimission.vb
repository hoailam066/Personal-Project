Imports System.Text
Imports System.Security.Cryptography
Imports System.IO

Public Module CLoginInformation
    Public CurrentUser As CPermission = New CPermission()
    Public LoginTime As DateTime = New DateTime()
    Public ReadOnly Property Text As String
        Get
            If (CurrentUser.Username = "" And CurrentUser.Permission = -1) Then
                Return "Unknow"
            End If
            Dim tmp As String = ""

            Select Case CurrentUser.Permission
                Case 0, Is < 0
                    tmp += "操作員"
                Case 1, Is > 1
                    tmp += "管理員"
            End Select
            Return tmp
        End Get
    End Property
End Module
Public Class CPermission
    Public Const PERMISSION_PATH As String = "D:\DataSettings\LaserMachine\Pemission\"
    Public Username As String
    Public Password As String
    Public Permission As Int16
    Public TimeOut As Integer
    Public Sub New()
        Username = ""
        Password = ""
        Permission = -1
        TimeOut = 0
    End Sub
    Public Sub New(ByVal pUsername As String, ByVal pPassword As String, ByVal pPermission As Int16, ByVal pTimeOut As Integer)
        Me.Username = pUsername
        Me.Password = pPassword
        Me.Permission = pPermission
        Me.TimeOut = pTimeOut
    End Sub

    Public Function Compare(ByVal p As CPermission) As Boolean
        If (Me.Username <> p.Username Or Me.Password <> p.Password Or Me.Permission <> p.Permission) Then
            Return False
        End If
        Return True
    End Function
    Public ReadOnly Property Copy As CPermission
        Get
            Return New CPermission(Me.Username, Me.Password, Me.Permission, Me.TimeOut)
        End Get
    End Property
    Private Shared m_PasswordPath As String = ""
    Public Shared ReadOnly Property PasswordPath As String
        Get
            Return m_PasswordPath
        End Get
    End Property
    Public Shared Function CheckPermissionLocation() As List(Of String)
        m_PasswordPath = PERMISSION_PATH & "Pemission.pms"
        Dim m_lstPassword As List(Of String) = New List(Of String)
        If (Not Directory.Exists(PERMISSION_PATH)) Then
            Directory.CreateDirectory(PERMISSION_PATH)
        End If
        If (Not File.Exists(m_PasswordPath)) Then
            m_lstPassword.Add(MEncoderPassword.Encrypt("1"))
            m_lstPassword.Add(MEncoderPassword.Encrypt("123"))
            m_lstPassword.Add(MEncoderPassword.Encrypt("SENEI"))
            Dim sw As StreamWriter = New StreamWriter(m_PasswordPath)
            sw.Write("")
            sw.Close()
            SavePassword(m_lstPassword)
        Else
            m_lstPassword.AddRange(File.ReadAllLines(m_PasswordPath))
            If (m_lstPassword.Count = 0) Then
                m_lstPassword.Add(MEncoderPassword.Encrypt("1"))
                m_lstPassword.Add(MEncoderPassword.Encrypt("123"))
                m_lstPassword.Add(MEncoderPassword.Encrypt("SENEI"))
            ElseIf (m_lstPassword.Count = 1) Then
                m_lstPassword.Add(m_lstPassword(0))
            End If
            SavePassword(m_lstPassword)
        End If
        Return m_lstPassword
    End Function
    Public Shared Sub SavePassword(pListPassword As List(Of String))
        File.WriteAllLines(m_PasswordPath, pListPassword.ToArray())
    End Sub
End Class
Public Module MEncoderPassword
    Private m_PrivateKey As String = "SENEI"
    Public ReadOnly Property PrivateKey As String
        Get
            Return m_PrivateKey
        End Get
    End Property
    Function Encrypt(ByVal pString As String) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = UTF8Encoding.UTF8.GetBytes(pString)
        Dim hashmd5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(m_PrivateKey))
        Dim tdes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tdes.CreateEncryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        Return Convert.ToBase64String(resultArray, 0, resultArray.Length)
    End Function

    Function Decrypt(ByVal pString As String) As String
        Dim keyArray As Byte()
        Dim toEncryptArray As Byte() = Convert.FromBase64String(pString)
        Dim hashmd5 As MD5CryptoServiceProvider = New MD5CryptoServiceProvider()
        keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(m_PrivateKey))
        Dim tdes As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        tdes.Key = keyArray
        tdes.Mode = CipherMode.ECB
        tdes.Padding = PaddingMode.PKCS7
        Dim cTransform As ICryptoTransform = tdes.CreateDecryptor()
        Dim resultArray As Byte() = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length)
        Return UTF8Encoding.UTF8.GetString(resultArray)
    End Function
End Module
