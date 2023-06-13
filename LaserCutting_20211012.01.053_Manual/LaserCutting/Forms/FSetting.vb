Imports System.Net

Public Class FSetting
    Private m_lstRobotSetting As List(Of CRobotSetting)
    Private m_lstIOSetting As List(Of CIOSetting)
    Private m_lstIOSettingType0 As List(Of CIOSetting)
    Private m_lstIOSettingType1 As List(Of CIOSetting)
    Private m_lstDataSetting As List(Of CDataSetting)
    Private m_ConnectionSetting As CConnectionSetting
    Private Sub LoadBaudrate()
        Dim lstBaudrate As List(Of Integer) = New List(Of Integer)
        lstBaudrate.Add(75)
        lstBaudrate.Add(110)
        lstBaudrate.Add(134)
        lstBaudrate.Add(150)
        lstBaudrate.Add(300)
        lstBaudrate.Add(600)
        lstBaudrate.Add(1200)
        lstBaudrate.Add(1800)
        lstBaudrate.Add(2400)
        lstBaudrate.Add(4800)
        lstBaudrate.Add(7200)
        lstBaudrate.Add(9600) '11
        lstBaudrate.Add(14400)
        lstBaudrate.Add(19200)
        lstBaudrate.Add(38400)
        lstBaudrate.Add(57600)
        lstBaudrate.Add(115200) '16
        lstBaudrate.Add(128000)
        cbbBarcodeBaudrate.DataSource = lstBaudrate.ToArray()
        cbbLaserBaudrate.DataSource = lstBaudrate.ToArray()
        cbbLaserSensorBaudrate.DataSource = lstBaudrate.ToArray()
        cbbTempBaudrate.DataSource = lstBaudrate.ToArray()
        cbbLaserBaudrate.SelectedIndex = 16
        cbbBarcodeBaudrate.SelectedIndex = 16
        cbbLaserSensorBaudrate.SelectedIndex = 11
        cbbTempBaudrate.SelectedIndex = 11
        lstBaudrate.Clear()
    End Sub
    Private Sub LoadComPort()
        Try
            Dim ports() As String = IO.Ports.SerialPort.GetPortNames()
            cbbLaserControllerComport.Items.Clear()
            cbbBarcodeComport.Items.Clear()
            cbbLaserSensorComport.Items.Clear()
            cbbTempComport.Items.Clear()
            Dim lstComport As List(Of Integer) = New List(Of Integer)
            For i = 0 To ports.Length - 1
                lstComport.Add(CInt(ports(i).Replace("COM", "")))
            Next
            cbbLaserControllerComport.DataSource = lstComport.ToArray()
            cbbBarcodeComport.DataSource = lstComport.ToArray()
            cbbLaserSensorComport.DataSource = lstComport.ToArray()
            cbbTempComport.DataSource = lstComport.ToArray()
        Catch
        End Try
    End Sub
    Private Sub TabControl1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Select Case TabControl1.SelectedIndex
            Case 0
                LoadRobotSetting()
            Case 1
                LoadIOSetting()
            Case 2
                LoadDataSetting()
            Case 3
                LoadConnectionSetting()

        End Select

    End Sub
    Private Sub LoadRobotSetting()
        m_lstRobotSetting = CDeviceSetting.GetRobotSetting()
        dgvRobotSetting.Rows.Clear()
        For i = 0 To m_lstRobotSetting.Count - 1
            With m_lstRobotSetting(i)
                dgvRobotSetting.Rows.Add(New Object() {.Key, .GetType(), .Value})
            End With
            dgvRobotSetting.Rows(i).Height = 25
        Next
        For i = 0 To dgvRobotSetting.Columns.Count - 1
            dgvRobotSetting.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub LoadIOSetting()
        m_lstIOSetting = CDeviceSetting.GetIOSetting()
        m_lstIOSettingType0 = (From io As CIOSetting In m_lstIOSetting
                               Where io.Type = 0).ToList()
        m_lstIOSettingType1 = (From io As CIOSetting In m_lstIOSetting
                               Where io.Type = 1).ToList()
        LoadIOSetting(1)
    End Sub
    Private Sub LoadIOSetting(ByVal type As Integer)
        dgvIOSetting.Rows.Clear()
        If (type = 0) Then
            For i = 0 To m_lstIOSettingType0.Count - 1
                With m_lstIOSettingType0(i)
                    dgvIOSetting.Rows.Add(New Object() {.Key, .Address, .Bit, .Value})
                End With
                dgvIOSetting.Rows(i).Height = 25
            Next
        Else
            For i = 0 To m_lstIOSettingType1.Count - 1
                With m_lstIOSettingType1(i)
                    dgvIOSetting.Rows.Add(New Object() {.Key, .Address, .Bit, .Value})
                End With
                dgvIOSetting.Rows(i).Height = 25
            Next
        End If
        For i = 0 To dgvIOSetting.Columns.Count - 1
            dgvIOSetting.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub LoadDataSetting()
        m_lstDataSetting = CDeviceSetting.GetDataSetting()
        dgvDataSetting.Rows.Clear()
        For i = 0 To m_lstDataSetting.Count - 1
            With m_lstDataSetting(i)
                dgvDataSetting.Rows.Add(New Object() {.Key, .Address, .GetType(), .Value})
            End With
            dgvDataSetting.Rows(i).Height = 25
        Next
        For i = 0 To dgvDataSetting.Columns.Count - 1
            dgvDataSetting.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub
    Private Sub LoadConnectionSetting()
        LoadBaudrate()
        LoadComPort()
        m_ConnectionSetting = CDeviceSetting.GetConnectionSetting()
        With m_ConnectionSetting
            txtRobotAddress.Text = .RobotIP
            txtRobotPort.Text = .RobotPort.ToString()
            ComboBox1.SelectedItem = .GigECameraID
            TextBox6.Text = .GigECameraIP
            TextBox7.Text = .GigECameraPort.ToString()
            ComboBox2.SelectedItem = .USBCameraID
            If (.LaserControllerEthernet) Then
                CheckBoxEx1.Checked = True
                TextBox8.Enabled = True
                TextBox8.Text = .LaserControllerIP
                TextBox9.Enabled = True
                TextBox9.Text = .LaserControllerPort.ToString()
                cbbLaserControllerComport.Enabled = False
                cbbLaserBaudrate.Enabled = False
            Else
                CheckBoxEx1.Checked = False
                TextBox8.Enabled = False
                TextBox8.Text = ""
                TextBox9.Enabled = False
                TextBox9.Text = ""
                cbbLaserControllerComport.Enabled = True
                cbbLaserBaudrate.Enabled = True
                cbbLaserControllerComport.SelectedItem = .LaserControllerComport
                cbbLaserBaudrate.SelectedItem = .LaserControllerBaudrate
            End If
            cbbBarcodeComport.SelectedItem = .BarcodeComport
            cbbBarcodeBaudrate.SelectedItem = .BarcodeBaudrate
            cbbLaserSensorComport.SelectedItem = .LaserSensorComport
            cbbLaserSensorBaudrate.SelectedItem = .LaserSensorBaudrate
            cbbTempComport.SelectedItem = .TempControllerComport
            cbbTempBaudrate.SelectedItem = .TempControllerBaudrate
            ComboBox1.Items.Clear()
            ComboBox2.Items.Clear()
            For index As Integer = 0 To 9
                ComboBox1.Items.Add(index)
                ComboBox2.Items.Add(index)
            Next
            ComboBox1.SelectedItem = .GigECameraID
            ComboBox2.SelectedItem = .USBCameraID
            

        End With
    End Sub

    Private Sub ptbStatus0_Click(sender As System.Object, e As System.EventArgs) Handles ptbStatus0.Click, ptbStatus7.Click, ptbStatus6.Click, ptbStatus5.Click, ptbStatus4.Click, ptbStatus3.Click, ptbStatus2.Click, ptbStatus1.Click
        Dim ptb As PictureBoxEx = CType(sender, PictureBoxEx)
        ptb.TurnOn = Not ptb.TurnOn
    End Sub

    Private Sub FSetting_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadRobotSetting()
    End Sub

    Private Sub dgvRobotSetting_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvRobotSetting.EditingControlShowing
        Dim ctr = CType(e.Control, DataGridViewTextBoxEditingControl)
        If (ctr Is Nothing) Then
            Return
        End If
        RemoveHandler ctr.KeyPress, AddressOf TextBox_KeyPress
        If (dgvRobotSetting.CurrentCell.ColumnIndex = 2) Then
            ctr.Tag = 1
            AddHandler ctr.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub
    Private Sub TextBox_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        Dim ctrl As TextBox = CType(sender, TextBox)
        If (TabControl1.SelectedIndex = 0) Then
            If (dgvRobotSetting.CurrentRow.Cells(1).Value = "INTEGER") Then
                If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
                If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
                    e.Handled = True
                End If
            End If
        ElseIf (TabControl1.SelectedIndex = 2) Then
            If (dgvDataSetting.CurrentRow.Cells(2).Value = "INTEGER" OrElse ctrl.Tag = 0) Then
                If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
            Else
                If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar) OrElse e.KeyChar = "."c) Then
                    e.Handled = False
                Else
                    e.Handled = True
                End If
                If (e.KeyChar = "."c AndAlso ctrl.Text.IndexOf(".") > -1) Then
                    e.Handled = True
                End If
            End If
        End If
    End Sub

    Private Sub btnSaveRobotSetting_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveRobotSetting.Click
        For i = 0 To dgvRobotSetting.Rows.Count - 1
            m_lstRobotSetting(i).Value = dgvRobotSetting.Rows(i).Cells(2).Value
        Next
        CDeviceSetting.SaveRobotSetting(m_lstRobotSetting)
        FMessageBox.Show("Saved successfully." & vbCrLf & "(保存成功。)", "Save Robot setting message", MessageBoxButtons.OK, MessageBoxIcon.OK)
    End Sub

    Private Sub dgvIOSetting_Click(sender As System.Object, e As System.EventArgs) Handles dgvIOSetting.Click
        Try
            TextBox3.Text = dgvIOSetting.CurrentRow.Cells(0).Value.ToString()
        Catch
        End Try
    End Sub

    Private Sub rbInput_Click(sender As System.Object, e As System.EventArgs) Handles rbInput.Click
        LoadIOSetting(1)
    End Sub

    Private Sub rbOutput_Click(sender As System.Object, e As System.EventArgs) Handles rbOutput.Click
        LoadIOSetting(0)
    End Sub

    Private Sub txtAddress_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAddress.KeyPress
        If (Char.IsDigit(e.KeyChar) OrElse Char.IsControl(e.KeyChar)) Then
            e.Handled = False
        Else
            e.Handled = True
        End If
    End Sub

    Private Sub btnAdd_Click(sender As System.Object, e As System.EventArgs) Handles btnAdd.Click
        If (txtKey.Text.Trim() = "") Then
            FMessageBox.Show("Please input key." & vbCrLf & "(請輸入 ""Key"")", "Add IO setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtKey.Focus()
            Exit Sub
        End If
        If (txtAddress.Text.Trim() = "") Then
            FMessageBox.Show("Please input address." & vbCrLf & "(請輸入 ""Address"")", "Add IO setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtAddress.Focus()
            Exit Sub
        End If
        Dim chk = (From io As CIOSetting In m_lstIOSetting
                   Where io.Key.ToLower() = txtKey.Text.Trim.ToLower()
                   Select io).ToList()
        If (chk IsNot Nothing AndAlso chk.Count > 0) Then
            FMessageBox.Show("The key is duplicated. Input other key please." & vbCrLf & "(""Key""已重複。 請輸入其他""Key""。)", "Add IO setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtKey.Focus()
            Exit Sub
        End If

        Dim newIo As CIOSetting = New CIOSetting()
        With newIo
            .Key = txtKey.Text
            .Address = CInt(txtAddress.Text)
            If (rbBit0.Checked) Then
                .Bit = 0
            ElseIf (rbBit1.Checked) Then
                .Bit = 1
            ElseIf (rbBit2.Checked) Then
                .Bit = 2
            ElseIf (rbBit3.Checked) Then
                .Bit = 3
            ElseIf (rbBit4.Checked) Then
                .Bit = 4
            ElseIf (rbBit5.Checked) Then
                .Bit = 5
            ElseIf (rbBit6.Checked) Then
                .Bit = 6
            Else
                .Bit = 7
            End If
            .Value = 1
            If (rbInput.Checked) Then
                .Type = 1
                m_lstIOSettingType1.Add(newIo)
                LoadIOSetting(1)
            Else
                .Type = 0
                m_lstIOSettingType0.Add(newIo)
                LoadIOSetting(0)
            End If
        End With
        m_lstIOSetting.Clear()
        m_lstIOSetting.AddRange(m_lstIOSettingType0.ToArray())
        m_lstIOSetting.AddRange(m_lstIOSettingType1.ToArray())
    End Sub

    Private Sub btnDelete_Click(sender As System.Object, e As System.EventArgs) Handles btnDelete.Click
        If (dgvIOSetting.SelectedRows.Count > 0) Then
            If (FMessageBox.Show("Are you sure you want to remove IO setting?" & vbCrLf & "(您確定要刪除IO設置嗎？)", "Delete IO setting message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes) Then
                If (rbInput.Checked) Then
                    m_lstIOSettingType1.RemoveAt(dgvIOSetting.SelectedRows(0).Index)
                    LoadIOSetting(1)
                Else
                    m_lstIOSettingType0.RemoveAt(dgvIOSetting.SelectedRows(0).Index)
                    LoadIOSetting(0)
                End If
                m_lstIOSetting.Clear()
                m_lstIOSetting.AddRange(m_lstIOSettingType0.ToArray())
                m_lstIOSetting.AddRange(m_lstIOSettingType1.ToArray())
            End If
        End If
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        CDeviceSetting.SaveIOSetting(m_lstIOSetting)
        FMessageBox.Show("Saved successfully." & vbCrLf & "(保存成功。)", "Save IO setting message", MessageBoxButtons.OK, MessageBoxIcon.OK)
    End Sub

    Private Sub btnSaveData_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveData.Click
        For i = 0 To dgvDataSetting.Rows.Count - 1
            m_lstDataSetting(i).Address = CType(dgvDataSetting.Rows(i).Cells(1).Value, Integer)
            m_lstDataSetting(i).Value = dgvDataSetting.Rows(i).Cells(3).Value
        Next
        CDeviceSetting.SaveDataSetting(m_lstDataSetting)
        FMessageBox.Show("Saved successfully." & vbCrLf & "(保存成功。)", "Save Data setting message", MessageBoxButtons.OK, MessageBoxIcon.OK)
    End Sub

    Private Sub dgvDataSetting_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles dgvDataSetting.EditingControlShowing
        Dim ctr = CType(e.Control, DataGridViewTextBoxEditingControl)
        If (ctr Is Nothing) Then
            Return
        End If

        RemoveHandler ctr.KeyPress, AddressOf TextBox_KeyPress
        If (dgvDataSetting.CurrentCell.ColumnIndex = 1) Then
            ctr.Tag = 0
            AddHandler ctr.KeyPress, AddressOf TextBox_KeyPress
        ElseIf (dgvDataSetting.CurrentCell.ColumnIndex = 3) Then
            ctr.Tag = 1
            AddHandler ctr.KeyPress, AddressOf TextBox_KeyPress
        End If
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles btnSaveConnection.Click
        Dim ip As IPAddress
        Dim port As Integer
        If (Not IPAddress.TryParse(txtRobotAddress.Text.Trim(), ip)) Then
            FMessageBox.Show("Invalid IP address." & vbCrLf & "(IP地址無效)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRobotAddress.Focus()
            Exit Sub
        End If
        If (Not Integer.TryParse(txtRobotPort.Text.Trim(), port)) Then
            FMessageBox.Show("Invalid port value." & vbCrLf & "(無效的端口值)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtRobotPort.Focus()
            Exit Sub
        End If
        If (Not IPAddress.TryParse(TextBox6.Text.Trim(), ip)) Then
            FMessageBox.Show("Invalid IP address." & vbCrLf & "(IP地址無效)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox6.Focus()
            Exit Sub
        End If
        If (Not Integer.TryParse(TextBox7.Text.Trim(), port)) Then
            FMessageBox.Show("Invalid port value." & vbCrLf & "(無效的端口值)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox7.Focus()
            Exit Sub
        End If
        If (CheckBoxEx1.Checked) Then
            If (Not IPAddress.TryParse(TextBox8.Text.Trim(), ip)) Then
                FMessageBox.Show("Invalid IP address." & vbCrLf & "(IP地址無效)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox8.Focus()
                Exit Sub
            End If
            If (Not Integer.TryParse(TextBox9.Text.Trim(), port)) Then
                FMessageBox.Show("Invalid port value." & vbCrLf & "(無效的端口值)", "Setting message", MessageBoxButtons.OK, MessageBoxIcon.Error)
                TextBox9.Focus()
                Exit Sub
            End If
            m_ConnectionSetting.LaserControllerEthernet = True
            m_ConnectionSetting.LaserControllerIP = TextBox8.Text.Trim()
            m_ConnectionSetting.LaserControllerPort = CInt(TextBox9.Text.Trim())
        Else
            m_ConnectionSetting.LaserControllerEthernet = False
            m_ConnectionSetting.LaserControllerComport = cbbLaserControllerComport.SelectedItem
            m_ConnectionSetting.LaserControllerBaudrate = cbbLaserBaudrate.SelectedItem
        End If
        m_ConnectionSetting.RobotIP = txtRobotAddress.Text.Trim()
        m_ConnectionSetting.RobotPort = CInt(txtRobotPort.Text.Trim())
        m_ConnectionSetting.GigECameraID = ComboBox1.SelectedItem
        m_ConnectionSetting.GigECameraIP = TextBox6.Text.Trim()
        m_ConnectionSetting.GigECameraPort = CInt(TextBox7.Text.Trim())
        m_ConnectionSetting.USBCameraID = ComboBox2.SelectedItem
        m_ConnectionSetting.BarcodeComport = cbbBarcodeComport.SelectedItem
        m_ConnectionSetting.BarcodeBaudrate = cbbBarcodeBaudrate.SelectedItem
        m_ConnectionSetting.LaserSensorComport = cbbLaserSensorComport.SelectedItem
        m_ConnectionSetting.LaserSensorBaudrate = cbbLaserSensorBaudrate.SelectedItem
        m_ConnectionSetting.TempControllerComport = cbbTempComport.SelectedItem
        m_ConnectionSetting.TempControllerBaudrate = cbbTempBaudrate.SelectedItem

        CDeviceSetting.SaveConnectionSetting(m_ConnectionSetting)

        FMessageBox.Show("Saved successfully." & vbCrLf & "(保存成功。)", "Save Connection setting message", MessageBoxButtons.OK, MessageBoxIcon.OK)
    End Sub

    Private Sub CheckBoxEx1_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles CheckBoxEx1.CheckedChanged
        With m_ConnectionSetting
            If (CheckBoxEx1.Checked = True) Then
                .LaserControllerEthernet = True
                TextBox8.Enabled = True
                TextBox8.Text = .LaserControllerIP
                TextBox9.Enabled = True
                TextBox9.Text = .LaserControllerPort.ToString()
                cbbLaserControllerComport.Enabled = False
                cbbLaserBaudrate.Enabled = False
            Else
                .LaserControllerEthernet = False
                TextBox8.Enabled = False
                TextBox8.Text = ""
                TextBox9.Enabled = False
                TextBox9.Text = ""
                cbbLaserControllerComport.Enabled = True
                cbbLaserBaudrate.Enabled = True
                cbbLaserControllerComport.SelectedItem = .LaserControllerComport
                cbbLaserBaudrate.SelectedItem = .LaserControllerBaudrate
            End If
        End With
    End Sub
End Class