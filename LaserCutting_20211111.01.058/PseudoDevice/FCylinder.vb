Public Class FCylinder
    Private m_DA As CDAQ
    Private m_CylIdx As Integer
    Private m_SnrMax As Integer
    Public Sub New(ByVal CylIdx As Integer, ByVal SnrMax As Integer, ByRef pDA As CDAQ)
        m_DA = pDA
        m_CylIdx = CylIdx
        m_SnrMax = SnrMax
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()
        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
    End Sub
    Private Sub btnExist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExist.Click
        Call Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        m_DA.DAQDO.CardIDAction(m_CylIdx) = cmbActionCardID.SelectedIndex - 1
        m_DA.DAQDO.SlaveIDAction(m_CylIdx) = cmbActionSlaveID.SelectedIndex - 1
        m_DA.DAQDO.BitIDAction(m_CylIdx) = cmbActionBitID.SelectedIndex - 1
        m_DA.DAQDO.SnrIdxAction(m_CylIdx) = cmbActionSnrID.SelectedIndex - 1
        m_DA.DAQDO.CardIDNormal(m_CylIdx) = cmbNormalCardID.SelectedIndex - 1
        m_DA.DAQDO.SlaveIDNormal(m_CylIdx) = cmbNormalSlaveID.SelectedIndex - 1
        m_DA.DAQDO.BitIDNormal(m_CylIdx) = cmbNormalBitID.SelectedIndex - 1
        m_DA.DAQDO.SnrIdxNormal(m_CylIdx) = cmbNormalSnrID.SelectedIndex - 1
        m_DA.DAQDO.SatbleTimeNormalAction(m_CylIdx) = numNormalActionTime.Value
        m_DA.DAQDO.SatbleTimeActionNormal(m_CylIdx) = numActionNormalTime.Value
        m_DA.DAQDO.SatbleTimeNormalNormal(m_CylIdx) = numNormalNormalTime.Value
        m_DA.DAQDO.AlarmTime(m_CylIdx) = numAlarmTime.Value
        Call m_DA.DAQDO.WriteDataToFile()
    End Sub

    Private Sub FCylinder_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        With cmbActionCardID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbActionSlaveID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbActionBitID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 7
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbActionSnrID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To (m_SnrMax - 1)
                .Items.Add(m_DA.DAQDI.Name(i))
            Next i
            .EndUpdate()
        End With
        With cmbNormalCardID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbNormalSlaveID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 1
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbNormalBitID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To 7
                .Items.Add(i.ToString())
            Next i
            .EndUpdate()
        End With
        With cmbNormalSnrID
            .BeginUpdate()
            .Items.Add("系統保留")
            For i = 0 To (m_SnrMax - 1)
                .Items.Add(m_DA.DAQDI.Name(i))
            Next i
            .EndUpdate()
        End With
        gbDeviceConfigure.Text = "Device Configure " & m_DA.DAQDO.Name(m_CylIdx)
        cmbActionCardID.SelectedIndex = m_DA.DAQDO.CardIDAction(m_CylIdx) + 1
        cmbActionSlaveID.SelectedIndex = m_DA.DAQDO.SlaveIDAction(m_CylIdx) + 1
        cmbActionBitID.SelectedIndex = m_DA.DAQDO.BitIDAction(m_CylIdx) + 1
        cmbActionSnrID.SelectedIndex = m_DA.DAQDO.SnrIdxAction(m_CylIdx) + 1
        cmbNormalCardID.SelectedIndex = m_DA.DAQDO.CardIDNormal(m_CylIdx) + 1
        cmbNormalSlaveID.SelectedIndex = m_DA.DAQDO.SlaveIDNormal(m_CylIdx) + 1
        cmbNormalBitID.SelectedIndex = m_DA.DAQDO.BitIDNormal(m_CylIdx) + 1
        cmbNormalSnrID.SelectedIndex = m_DA.DAQDO.SnrIdxNormal(m_CylIdx) + 1
        numActionNormalTime.Value = m_DA.DAQDO.SatbleTimeActionNormal(m_CylIdx)
        numNormalActionTime.Value = m_DA.DAQDO.SatbleTimeNormalAction(m_CylIdx)
        numNormalNormalTime.Value = m_DA.DAQDO.SatbleTimeNormalNormal(m_CylIdx)
        numAlarmTime.Value = m_DA.DAQDO.AlarmTime(m_CylIdx)
    End Sub
End Class