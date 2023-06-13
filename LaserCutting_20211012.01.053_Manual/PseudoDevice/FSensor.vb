Public Class FSensor
    Private m_DA As CDAQ
    Private m_SnrIdx As Integer
    Private m_SnrMax As Integer
    Public Sub New(ByVal SnrIdx As Integer, ByRef pDA As CDAQ)
        m_SnrMax = SnrIdx
        m_DA = pDA
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub
     
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        m_DA.DAQDI.CardID(m_SnrIdx) = cmbCardID.SelectedIndex - 1
        m_DA.DAQDI.SlaveID(m_SnrIdx) = cmbSlaveID.SelectedIndex - 1
        m_DA.DAQDI.BitID(m_SnrIdx) = cmbBitID.SelectedIndex - 1
        m_DA.DAQDI.PositiveLogic(m_SnrIdx) = chkLogic.Checked
    End Sub

    Private Sub FSensor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        With cmbCardID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbSlaveID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbBitID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 7
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        gbDeviceConfigure.Text = "Device Configure " & m_DA.DAQDI.Name(m_SnrIdx)
        cmbCardID.SelectedIndex = m_DA.DAQDI.CardID(m_SnrIdx) + 1
        cmbSlaveID.SelectedIndex = m_DA.DAQDI.SlaveID(m_SnrIdx) + 1
        cmbBitID.SelectedIndex = m_DA.DAQDI.BitID(m_SnrIdx) + 1
        chkLogic.Checked = m_DA.DAQDI.PositiveLogic(m_SnrIdx)
    End Sub

    Private Sub btnExist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExist.Click
        Call Me.Close()
    End Sub
End Class