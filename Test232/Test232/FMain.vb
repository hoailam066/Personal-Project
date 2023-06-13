Imports System.IO.Ports

Public Class FMain
    Private m_SerialPort As CSerialport
    Private m_PeakMax As Double
    Private m_PeakMin As Double
    Private Sub FMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ports() As String = SerialPort.GetPortNames()

        For i = 0 To ports.Length - 1
            cboPortName.Items.Add(ports(i))
        Next
        If (ports.Length > 0) Then
            cboPortName.SelectedIndex = 0
        End If

        cboBaudrate.Items.Add(75)
        cboBaudrate.Items.Add(110)
        cboBaudrate.Items.Add(134)
        cboBaudrate.Items.Add(150)
        cboBaudrate.Items.Add(300)
        cboBaudrate.Items.Add(600)
        cboBaudrate.Items.Add(1200)
        cboBaudrate.Items.Add(1800)
        cboBaudrate.Items.Add(2400)
        cboBaudrate.Items.Add(4800)
        cboBaudrate.Items.Add(7200)
        cboBaudrate.Items.Add(9600)
        cboBaudrate.Items.Add(14400)
        cboBaudrate.Items.Add(19200)
        cboBaudrate.Items.Add(38400)
        cboBaudrate.Items.Add(57600)
        cboBaudrate.Items.Add(115200)
        cboBaudrate.Items.Add(128000)
        cboBaudrate.SelectedIndex = 11

        cboDataBit.Items.Add(4)
        cboDataBit.Items.Add(5)
        cboDataBit.Items.Add(6)
        cboDataBit.Items.Add(7)
        cboDataBit.Items.Add(8)
        cboDataBit.SelectedIndex = 4

        cboStopBit.Items.Add(1)
        cboStopBit.Items.Add(1.5)
        cboStopBit.Items.Add(2)
        cboStopBit.SelectedIndex = 0

        cboParity.Items.Add(Parity.Even)
        cboParity.Items.Add(Parity.Mark)
        cboParity.Items.Add(Parity.None)
        cboParity.Items.Add(Parity.Odd)
        cboParity.Items.Add(Parity.Space)
        cboParity.SelectedIndex = 2
    End Sub


    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Try
            If (m_SerialPort IsNot Nothing) Then
                Try
                    RemoveHandler m_SerialPort.DataReceived, AddressOf m_SerialPort_DataReceived
                    m_SerialPort.Dispose()
                Catch ex As Exception
                End Try
            End If
            lbReceivedData.Items.Clear()
            Dim stopbit As StopBits
            If (cboStopBit.SelectedItem = 1.5) Then
                stopbit = StopBits.OnePointFive
            Else
                stopbit = CType(cboStopBit.SelectedItem, StopBits)
            End If
            m_SerialPort = New CSerialport(cboPortName.SelectedItem, cboBaudrate.SelectedItem, cboDataBit.SelectedItem, stopbit, cboParity.SelectedItem)
            m_SerialPort.Open()
            If (m_SerialPort.LastError <> "") Then
                MessageBox.Show(m_SerialPort.LastError, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                AddHandler m_SerialPort.DataReceived, AddressOf m_SerialPort_DataReceived
                cboBaudrate.Enabled = False
                cboDataBit.Enabled = False
                cboParity.Enabled = False
                cboPortName.Enabled = False
                cboStopBit.Enabled = False
                btnOpen.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private m_SelectedIdx As Integer = 0
    Private Sub InvokeListBoxItem(ByVal value1 As Double, ByVal value2 As Double)
        If (Me.InvokeRequired) Then
            Me.BeginInvoke(Sub() InvokeListBoxItem(value1, value2))
        Else
            If (lbReceivedData.Items.Count >= 100) Then
                lbReceivedData.Items.RemoveAt(0)
            End If
            lbReceivedData.Items.Add(DateTime.Now.ToString("HH:mm:ss.fff") & ": " & value1 & ", " & value2)

            m_SelectedIdx = lbReceivedData.Items.Count - 1

            lbReceivedData.SelectedIndex = m_SelectedIdx
            txtPeakUp.Text = value1.ToString("F3")
            txtPeakDown.Text = value2.ToString("F3")
            If (chkRecord.Checked) Then
                txtPeakMax.Text = m_PeakMax.ToString("F3")
                txtPeakMin.Text = m_PeakMin.ToString("F3")
            End If
        End If
    End Sub


    Private Sub m_SerialPort_DataReceived(ByVal value1 As Double, ByVal value2 As Double)

        m_PeakMax = CDbl(IIf(m_PeakMax < value1, value1, m_PeakMax))
        m_PeakMax = CDbl(IIf(m_PeakMax < value2, value2, m_PeakMax))

        m_PeakMin = CDbl(IIf(m_PeakMin > value1, value1, m_PeakMin))
        m_PeakMin = CDbl(IIf(m_PeakMin > value2, value2, m_PeakMin))
        InvokeListBoxItem(value1, value2)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Try
            If (m_SerialPort IsNot Nothing) Then
                Try
                    RemoveHandler m_SerialPort.DataReceived, AddressOf m_SerialPort_DataReceived
                    m_SerialPort.Dispose()
                Catch ex As Exception
                End Try
            End If
            cboBaudrate.Enabled = True
            cboDataBit.Enabled = True
            cboParity.Enabled = True
            cboPortName.Enabled = True
            cboStopBit.Enabled = True
            btnOpen.Enabled = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub chkRecord_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRecord.Click
        Try
            If (chkRecord.Checked) Then
                m_PeakMax = Double.MinValue
                m_PeakMin = Double.MaxValue
            Else
                System.IO.File.WriteAllText("D:\DataSettings\" & DateTime.Now.ToString("yyyyMMdd_HHmmss") & ".csv", m_PeakMin.ToString("F3") & "," & m_PeakMax.ToString("F3"))
                m_PeakMax = 0
                m_PeakMin = 0
                txtPeakMax.Text = "0"
                txtPeakMin.Text = "0"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub FMain_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If (m_SerialPort IsNot Nothing) Then
                m_SerialPort.Dispose()
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
