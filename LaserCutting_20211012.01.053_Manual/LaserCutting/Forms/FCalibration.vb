Imports PseudoDevice

Public Class FCalibration

    Private m_RulerColor As Color = Color.Red
    Private m_DiscreteMove As Double = 1
    Public m_Acquist As VisionSystem.CAcquisition
    Private m_CurProject As CProject
    Private m_Ruler As CRuler
    Private m_Motion As CMotion
    Private m_LaserAperture As CLaserAperture
    Private m_Param As CParam
    Private Const MCS_SRC_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\"
    Public Const MCS_PRODUCT_DIRECTORY As String = "D:\DataSettings\LaserSolder\MachineData\Products"
    Public ReadOnly Property RulerColor As Color
        Get
            Return m_RulerColor
        End Get
    End Property
    Public Sub New(ByRef pCurproject As CProject, ByRef pAcquist As VisionSystem.CAcquisition, ByRef pMotion As CMotion, ByRef pParam As CParam)
        Try
            InitializeComponent()
            If (pAcquist IsNot Nothing) Then
                m_Acquist = pAcquist
            Else
                m_Acquist = New VisionSystem.CAcquisition(0)
            End If
            If (pParam Is Nothing) Then
                pParam = New CParam(MCS_PRODUCT_DIRECTORY & "\RESERVED\Parameter.xml")
            End If
            m_Param = pParam
            m_CurProject = pCurproject
            

            If Not (pMotion Is Nothing) Then m_Motion = pMotion
            If m_LaserAperture Is Nothing Then m_LaserAperture = New CLaserAperture()
            m_RulerColor = m_Ruler.Color
            ImageDisplay1.StartLive(0, m_Acquist)
            
        Catch ex As Exception
            FMessageBox.ShowError("Error when load Calibration UI", "Error change UI", True, ex)
            Me.Close()
        End Try
    End Sub
    Private Sub btnPickColor_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim cd As ColorDialog = New ColorDialog()
        If (cd.ShowDialog() = Windows.Forms.DialogResult.OK) Then
            m_RulerColor = cd.Color
            m_Ruler.Color = m_RulerColor
        End If
    End Sub
    

    Private m_IsMoving As Boolean = False
    Private m_WorkholderValueAdd As Double = 10
    Private m_axisID As Integer

    
    Private Sub txtUnit_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim ctrl As TextBox = CType(sender, TextBox)
        'Check imput only Number key or Control key
        If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
            e.Handled = False
        Else
            e.Handled = True
        End If

        'Check only 1 decimal point
        If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
            e.Handled = True
        End If
    End Sub

    
    
    Private Sub FCalibration_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            Timer1.Enabled = False
            m_RulerColor = m_Ruler.Color
            ImageDisplay1.StopLive()
            m_Ruler.Dispose()
            m_LaserAperture.Dispose()
        Catch ex As Exception

        End Try
    End Sub

   
End Class