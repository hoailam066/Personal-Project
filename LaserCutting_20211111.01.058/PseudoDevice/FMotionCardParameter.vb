Public Class FMotionCardParameter
    Private m_motion As CMotion
    Private m_AxisID As Integer
    Public Sub New(ByVal AxisID As Integer, ByVal Motion As CMotion)
        m_AxisID = AxisID
        m_motion = Motion
        ' 此為 Windows Form 設計工具所需的呼叫。
        InitializeComponent()

        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。

    End Sub
    Private Sub FMotionCardParameter_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            Dim i As Integer
            'If m_MotionCardParams Is Nothing Then
            '    m_MotionCardParams = New CAxisP
            'End If

            ' ~~~ 加入屬性

            With cmbCardName
                .BeginUpdate()
                .Items.Add("Adlink8144")
                .Items.Add("Adlink8164")
                .Items.Add("Adlink8134")
                .Items.Add("Adlink8154")
                .Items.Add("Adlink8102")
                .EndUpdate()
            End With

            With cmbCardID
                .BeginUpdate()
                For i = 0 To 2
                    .Items.Add(i.ToString())
                Next i
                .EndUpdate()
            End With

            With cmbAxisID
                .BeginUpdate()
                For i = 0 To 7
                    .Items.Add(i.ToString())
                Next i
                .EndUpdate()
            End With

            With cmbIsServo
                .BeginUpdate()
                .Items.Add("Step-Motor")
                .Items.Add("Servo-Motor")
                .EndUpdate()
            End With

            With cmbAlarmLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbAlarmMode
                .BeginUpdate()
                .Items.Add("Immed.-Stop")
                .Items.Add("Decel-Stop")
                .EndUpdate()
            End With

            With cmbClrMode
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbERCEnable
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbEZLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbHomeMode
                .BeginUpdate()
                .Items.Add("ORG-Only")
                .Items.Add("Reserved")
                .Items.Add("ORG&Index")
                .EndUpdate()
            End With

            With cmbHomeDirection
                .BeginUpdate()
                .Items.Add("正方向")
                .Items.Add("負方向")
                .EndUpdate()
            End With

            With cmbInpEnable
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbInpLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbOrgLatch
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbOrgLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbPCSEnable
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbPCSLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbSdEnable
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbSdLatch
                .BeginUpdate()
                .Items.Add("關閉")
                .Items.Add("開啟")
                .EndUpdate()
            End With

            With cmbSdLogic
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With

            With cmbPulseInputMode_eAeB
                .BeginUpdate()
                .Items.Add("1X AB")
                .Items.Add("2X AB")
                .Items.Add("4X AB")
                .Items.Add("CW/CCW")
                .EndUpdate()
            End With

            With cmbPLSLogicInverseDir
                .BeginUpdate()
                .Items.Add("低電位觸發")
                .Items.Add("高電位觸發")
                .EndUpdate()
            End With
            ' ~~~

            With m_motion.Parameter(m_AxisID)
                gbDeviceConfigure.Text = "Device Configure" & .AxisName
                cmbCardName.SelectedIndex = .CardType
                cmbCardID.SelectedIndex = .CardID
                cmbAxisID.SelectedIndex = .AxisID
                numHomeHighVelocity.Value = .Home.HighSpeed
                numHomeLowVelocity.Value = .Home.LowSpeed
                numHomeDecTime.Value = .Home.Acc
                numPlsConstrainVel.Value = .Speed.MaxConstrainedVel
                numPlsMaxVel.Value = .Speed.MaxVel
                numPlsStartVel.Value = .Speed.StrVel
                numPlsAccTime.Value = .Speed.Tacc
                numPlsDecTime.Value = .Speed.Tacc
                numPlsAccSVel.Value = .Speed.Sacc
                numPlsDecSVel.Value = .Speed.Sdec
                numPlsVelRatio.Value = .Speed.RatioMaxVel
                numPlsAccDecRatio.Value = .Speed.RatioAcc
                numPlsIacc.Value = .Speed.Iacc
                numPlsIdec.Value = .Speed.Idec
            End With

            With m_motion.Parameter(m_AxisID).Mode
                cmbIsServo.SelectedIndex = .IsServo
                cmbAlarmLogic.SelectedIndex = .AlarmLogic
                cmbAlarmMode.SelectedIndex = .AlarmMode
                cmbClrMode.SelectedIndex = .ClrMode
                cmbERCEnable.SelectedIndex = .ERCEnable
                cmbEZLogic.SelectedIndex = .EZLogic
                cmbHomeMode.SelectedIndex = .HomeMode
                cmbHomeDirection.SelectedIndex = .HomeDir
                cmbInpEnable.SelectedIndex = .InpEnable
                cmbInpLogic.SelectedIndex = .InpLogic
                cmbOrgLatch.SelectedIndex = .OrgLatch
                cmbOrgLogic.SelectedIndex = .OrgLogic
                cmbPCSEnable.SelectedIndex = .PCSEnable
                cmbPCSLogic.SelectedIndex = .PCSLogic
                cmbSdEnable.SelectedIndex = .SdEnable
                cmbSdLatch.SelectedIndex = .SdLatch
                cmbSdLogic.SelectedIndex = .SdLogic
                cmbPulseInputMode_eAeB.SelectedIndex = .PulseInputMode
                cmbPLSLogicInverseDir.SelectedIndex = .PulseLogic
            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        'With m_MotionCardParams
        '    .AxisName = lblAxisName.Text
        '    .CardType = CType(cmbCardName.SelectedIndex, NaotarouMotion.Motion_Card)
        '    .CardID = CShort(cmbCardID.SelectedIndex)
        '    .AxisID = CShort(cmbAxisID.SelectedIndex)
        '    With .CardParameter
        '        With .speed
        '            .HomeLow = CDbl(IIf(Val(txtHomeLowVelocity.Text) > 0, Val(txtHomeLowVelocity.Text), 200))
        '            .HomeHigh = CDbl(IIf(Val(txtHomeHighVelocity.Text) > .HomeLow, Val(txtHomeHighVelocity.Text), .HomeLow * 2))
        '            .HomeDecelerationTime = CDbl(IIf(Val(txtHomeDecTime.Text) > 0, Val(txtHomeDecTime.Text), 0.01))
        '            .StrVel = CDbl(IIf(Val(txtPlsStartVel.Text) > 0, Val(txtPlsStartVel.Text), 200))
        '            .MaxVel = CDbl(IIf(Val(txtPlsMaxVel.Text) > .StrVel, Val(txtPlsMaxVel.Text), .StrVel * 2))
        '            .MaxConstrainedVel = CDbl(IIf(Val(txtPlsConstrainVel.Text) > .StrVel, Val(txtPlsConstrainVel.Text), .StrVel * 2))
        '            .Tacc = CDbl(IIf(Val(txtPlsAccTime.Text) > 0, Val(txtPlsAccTime.Text), 0.01))
        '            .Tdec = CDbl(IIf(Val(txtPlsDecTime.Text) > 0, Val(txtPlsDecTime.Text), 0.01))
        '            .Sacc = CDbl(IIf(Val(txtPlsAccSVel.Text) >= 0, Val(txtPlsAccSVel.Text), 0))
        '            .Sdec = CDbl(IIf(Val(txtPlsDecSVel.Text) >= 0, Val(txtPlsDecSVel.Text), 0))
        '            .RatioMaxVel = CDbl(IIf(Val(txtPlsVelRatio.Text) > 0, Val(txtPlsVelRatio.Text), 1))
        '            .RatioMaxVel = CDbl(IIf(Val(txtPlsVelRatio.Text) <= 1, Val(txtPlsVelRatio.Text), 1))
        '            .RatioAcc = CDbl(IIf(Val(txtPlsAccDecRatio.Text) >= 1, Val(txtPlsAccDecRatio.Text), 1))
        '            .RatioAcc = CDbl(IIf(Val(txtPlsAccDecRatio.Text) <= 30, Val(txtPlsAccDecRatio.Text), 1))
        '            .Iacc = CDbl(IIf(Val(txtPlsIacc.Text) > 0, Val(txtPlsIacc.Text), 1))
        '            .Idec = CDbl(IIf(Val(txtPlsIdec.Text) > 0, Val(txtPlsIdec.Text), 1))
        '        End With

        '        With .mode
        '            .IsServo = CShort(cmbIsServo.SelectedIndex)
        '            .AlarmLogic = CShort(cmbAlarmLogic.SelectedIndex)
        '            .AlarmMode = CShort(cmbAlarmMode.SelectedIndex)
        '            .ClrMode = CShort(cmbClrMode.SelectedIndex)
        '            .ERCEnable = CShort(cmbERCEnable.SelectedIndex)
        '            .EZLogic = CShort(cmbEZLogic.SelectedIndex)
        '            .HomeMode = CShort(cmbHomeMode.SelectedIndex)
        '            .HomeDirection = CBool(IIf(cmbHomeDirection.SelectedIndex = 0, True, False))
        '            .InpEnable = CShort(cmbInpEnable.SelectedIndex)
        '            .InpLogic = CShort(cmbInpLogic.SelectedIndex)
        '            .OrgLatch = CShort(cmbOrgLatch.SelectedIndex)
        '            .OrgLogic = CShort(cmbOrgLogic.SelectedIndex)
        '            .PCSEnable = CShort(cmbPCSEnable.SelectedIndex)
        '            .PCSLogic = CShort(cmbPCSLogic.SelectedIndex)
        '            .SdEnable = CShort(cmbSdEnable.SelectedIndex)
        '            .SdLatch = CShort(cmbSdLatch.SelectedIndex)
        '            .SdLogic = CShort(cmbSdLogic.SelectedIndex)
        '            .PulseInputMode_eAeB = CShort(cmbPulseInputMode_eAeB.SelectedIndex)
        '            .PLSLogicInverseDir = CShort(cmbPLSLogicInverseDir.SelectedIndex)
        '        End With
        '    End With
        'End With
        Me.Close()
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click

    End Sub
    Private Sub btnExist_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExist.Click
        Call Me.Close()
    End Sub

    
End Class