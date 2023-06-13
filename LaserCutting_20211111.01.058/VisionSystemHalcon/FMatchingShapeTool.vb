'Imports HalconDotNet

'Public Class FMatchingShapeTool
'    Private m_ImageViewerSrc As myViewer
'    Private m_ImageViewerTemplate As myViewer
'    Private m_Matching As CMatchingTool = Nothing
'    Private m_IsCausesValidation As Boolean = False
'    Private Sub FMatchingShapeTool_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
'        'Try
'        cmbTemplate1.Items.Add("不優化")
'        cmbTemplate1.Items.Add("預設優化")
'        cmbTemplate1.Items.Add("角度優化")
'        cmbMetric.Items.Add("無變化")
'        cmbMetric.Items.Add("色調相反")
'        cmbMetric.Items.Add("漸層變化")
'        cmbSubPixel.Items.Add("最低精度")
'        cmbSubPixel.Items.Add("低精度")
'        cmbSubPixel.Items.Add("中等精度")
'        cmbSubPixel.Items.Add("高精度")
'        cmbSubPixel.Items.Add("最高精度")
'        cmbAlgorithmSpeed.Items.Add("最慢")
'        cmbAlgorithmSpeed.Items.Add("非常慢")
'        cmbAlgorithmSpeed.Items.Add("稍慢")
'        cmbAlgorithmSpeed.Items.Add("慢")
'        cmbAlgorithmSpeed.Items.Add("普通慢")
'        cmbAlgorithmSpeed.Items.Add("普通")
'        cmbAlgorithmSpeed.Items.Add("普通快")
'        cmbAlgorithmSpeed.Items.Add("快")
'        cmbAlgorithmSpeed.Items.Add("稍快")
'        cmbAlgorithmSpeed.Items.Add("非常快")
'        cmbAlgorithmSpeed.Items.Add("最快")
'        With m_Matching.TrainParam.Geometry
'            numNumLevels.Value = CDec(.NumLevels.D())
'            numAngleStart.Value = CDec(.AngleStart.D() * 180 / Math.PI)
'            numAngleEnd.Value = CDec((.AngleStart.D() + .AngleExtent.D()) * 180 / Math.PI)
'            numAngleStep.Value = CDec(.AngleStep.D() * 180 / Math.PI)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numContrastLow.Value = CDec(.ContrastLow.D())
'            numContrastHigh.Value = CDec(.ContrastHigh.D())
'            numMinSize.Value = CDec(.MinSize.D())
'            numMinContrast.Value = CDec(.MinContrast.D())
'        End With
'        With m_Matching.RunParam
'            numAngleStartRun.Value = CDec(.AngleStart.D() * 180 / Math.PI)
'            numAngleEndRun.Value = CDec((.AngleStart.D() + .AngleExtent.D()) * 180 / Math.PI)
'            numScaleMinRun.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMaxRun.Value = CDec(.ScaleMax.D() * 100)
'            numScaleMinRun.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMaxRun.Value = CDec(.ScaleMax.D() * 100)
'            numScoreSearch.Value = CDec(.ScoreSearch.D() * 100)
'            numScoreAccept.Value = CDec(.ScoreAccept * 100)
'            numOverlapPercent.Value = CDec(.OverlapPercent.D() * 100)
'            cmbSubPixel.SelectedIndex = .PixelAccuracy
'            cmbAlgorithmSpeed.SelectedIndex = .AlgorithmSpeed
'        End With
'        Call m_ImageViewerSrc.SetPart(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerSrc.DispImage(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerTemplate.SetPart(m_Matching.TrainParam.TemplateImage)
'        Call m_ImageViewerTemplate.DispImage(m_Matching.TrainParam.TemplateImage)
'        Call m_ImageViewerTemplate.DispObj(m_Matching.GetTemplateContours(1))
'        Call m_Matching.Run(True)
'        'Call m_ImageViewerSrc.DispRegion(m_Matching.RunParam.SearchRegion, "yellow")
'        Call tviewResult.Nodes.Clear()
'        Call tviewResult.Nodes.Add("Result")
'        For idx As Integer = 0 To (m_Matching.Count - 1)
'            Call m_ImageViewerSrc.DispCross(m_Matching.Results(idx).CenterY, m_Matching.Results(idx).CenterX, 50, 0)
'            Call m_ImageViewerSrc.DispText(20, 20, "找尋時間:" & m_Matching.RunTime.ToString("N0") & "ms", "white")
'            Call m_ImageViewerSrc.DispText(CInt(m_Matching.Results(idx).CenterX - 40), CInt(m_Matching.Results(idx).CenterY - 40), idx.ToString(), "yellow")
'            Call tviewResult.Nodes(0).Nodes.Add(idx.ToString())
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("X:" & m_Matching.Results(idx).CenterX.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Y:" & m_Matching.Results(idx).CenterY.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Angle:" & m_Matching.Results(idx).RotaryAngleD.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Scale:" & (m_Matching.Results(idx).Scale * 100).ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Score:" & (m_Matching.Results(idx).Score * 100).ToString("N2"))
'        Next

'        'Catch ex As Exception
'        'End Try
'        m_IsCausesValidation = True
'    End Sub

'    Public Sub New(ByRef pMatchingTool As CMatchingTool)
'        ' 此為 Windows Form 設計工具所需的呼叫。
'        InitializeComponent()
'        ' 在 InitializeComponent() 呼叫之後加入任何初始設定。
'        Try
'            m_IsCausesValidation = False
'            m_ImageViewerSrc = DisplaySrcImg
'            m_ImageViewerTemplate = DisplayTemplate
'            m_Matching = pMatchingTool
'        Catch ex As Exception

'        End Try
'    End Sub

'    Private Sub btnFindResult_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFindResult.Click
'        Try
'            Call m_Matching.TrainParam.SrcImage.CopyTo(m_Matching.DstImage)
'            ' m_Matching.SearchRegion.Dispose() : m_Matching.SearchRegion = Nothing

'            Call m_Matching.Run(True)
'            Call UpdateRunParameter()
'        Catch ex As Exception

'        End Try
'    End Sub
'    Private Sub numNumLevels_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numNumLevels.MouseDown
'        m_Matching.TrainParam.Geometry.NumLevels.D() = numNumLevels.Value
'        Call UpdateTrainParameter()
'    End Sub

'    Private Sub numContrastlow_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numContrastLow.MouseDown
'        m_Matching.TrainParam.Geometry.ContrastLow.D() = numContrastLow.Value
'        Call UpdateTrainParameter()
'    End Sub
'    Private Sub numContrasthigh_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numContrastHigh.MouseDown
'        m_Matching.TrainParam.Geometry.ContrastHigh.D() = numContrastHigh.Value
'        Call UpdateTrainParameter()
'    End Sub
'    Private Sub numMinSize_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numMinSize.MouseDown
'        m_Matching.TrainParam.Geometry.MinSize.D() = numMinSize.Value
'        Call UpdateTrainParameter()
'    End Sub
'    Private Sub numMinContrast_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles numMinContrast.MouseClick, numMinContrast.MouseDown
'        m_Matching.TrainParam.Geometry.MinContrast.D() = numMinContrast.Value
'        Call UpdateTrainParameter()
'    End Sub
'    Private Sub UpdateTrainParameter()
'        Call m_ImageViewerSrc.SetPart(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerSrc.DispImage(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerTemplate.SetPart(m_Matching.TrainParam.TemplateImage)
'        Call m_ImageViewerTemplate.DispImage(m_Matching.TrainParam.TemplateImage)
'        Call m_Matching.TrainManual()

'        With m_Matching.TrainParam.Geometry
'            numNumLevels.Value = CDec(.NumLevels.D())
'            numAngleStart.Value = CDec(.AngleStart.D() * 180 / Math.PI)
'            numAngleEnd.Value = CDec((.AngleStart.D() + .AngleExtent.D()) * 180 / Math.PI)
'            numAngleStep.Value = CDec(.AngleStep.D() * 180 / Math.PI)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numContrastLow.Value = CDec(.ContrastLow.D())
'            numContrastHigh.Value = CDec(.ContrastHigh.D())
'            numMinSize.Value = CDec(.MinSize.D())
'            numMinContrast.Value = CDec(.MinContrast.D())
'        End With

'        Call m_ImageViewerTemplate.DispObj(m_Matching.GetTemplateContours(1))
'        Call m_Matching.Run(True)
'        For idx As Integer = 0 To (m_Matching.Count - 1)
'            Call m_ImageViewerSrc.DispCross(m_Matching.Results(idx).CenterY, m_Matching.Results(idx).CenterX, 50, 0)
'        Next
'    End Sub

'    Private Sub btnTrainAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrainAuto.Click
'        Call m_ImageViewerSrc.SetPart(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerSrc.DispImage(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerTemplate.SetPart(m_Matching.TrainParam.TemplateImage)
'        Call m_ImageViewerTemplate.DispImage(m_Matching.TrainParam.TemplateImage)
'        Call m_Matching.TrainAuto()

'        With m_Matching.TrainParam.Geometry
'            numNumLevels.Value = CDec(.NumLevels.D())
'            numAngleStart.Value = CDec(.AngleStart.D() * 180 / Math.PI)
'            numAngleEnd.Value = CDec((.AngleStart.D() + .AngleExtent.D()) * 180 / Math.PI)
'            numAngleStep.Value = CDec(.AngleStep.D() * 180 / Math.PI)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numScaleMin.Value = CDec(.ScaleMin.D() * 100)
'            numScaleMax.Value = CDec(.ScaleMax.D() * 100)
'            numScaleStep.Value = CDec(.ScaleStep.D() * 100)
'            numContrastLow.Value = CDec(.ContrastLow.D())
'            numContrastHigh.Value = CDec(.ContrastHigh.D())
'            numMinSize.Value = CDec(.MinSize.D())
'            numMinContrast.Value = CDec(.MinContrast.D())
'        End With

'        Call m_ImageViewerTemplate.DispObj(m_Matching.GetTemplateContours(1))
'        Call m_Matching.Run(True)
'        For idx As Integer = 0 To (m_Matching.Count - 1)
'            Call m_ImageViewerSrc.DispCross(m_Matching.Results(idx).CenterY, m_Matching.Results(idx).CenterX, 50, 0)
'        Next
'    End Sub
'    Private Sub numAngleStartRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAngleStartRun.ValueChanged
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetRotaryRange(numAngleStartRun.Value, numAngleEndRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numAngleEndRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numAngleEndRun.ValueChanged
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetRotaryRange(numAngleStartRun.Value, numAngleEndRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScaleCMinRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScaleMinRun.ValueChanged
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetScaleRange(numScaleMinRun.Value, numScaleMaxRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScaleCMaxRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScaleMaxRun.ValueChanged
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetScaleRange(numScaleMinRun.Value, numScaleMaxRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScaleRMinRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetScaleRange(numScaleMinRun.Value, numScaleMaxRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScaleRMaxRun_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetScaleRange(numScaleMinRun.Value, numScaleMaxRun.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScoreSearch_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScoreSearch.ValueChanged
'        If m_IsCausesValidation Then
'            Call m_Matching.RunParam.SetScoreProperty(numScoreSearch.Value, numScoreAccept.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numScoreAccept_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numScoreAccept.ValueChanged
'        If m_IsCausesValidation Then
'            m_Matching.RunParam.SetScoreProperty(numScoreSearch.Value, numScoreAccept.Value)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub numOverlapPercent_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles numOverlapPercent.ValueChanged
'        If m_IsCausesValidation Then
'            m_Matching.RunParam.OverlapPercent = numOverlapPercent.Value
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub cmbSubPixel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSubPixel.SelectedIndexChanged
'        If m_IsCausesValidation Then
'            m_Matching.RunParam.PixelAccuracy = CType(cmbSubPixel.SelectedIndex, enumPixelAccuracy)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub cmbAlgorithmSpeed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlgorithmSpeed.SelectedIndexChanged
'        If m_IsCausesValidation Then
'            m_Matching.RunParam.AlgorithmSpeed = CType(cmbAlgorithmSpeed.SelectedIndex, enumAlgorithmSpeed)
'            Call UpdateRunParameter()
'        End If
'    End Sub
'    Private Sub UpdateRunParameter()
'        Call m_ImageViewerSrc.SetPart(m_Matching.TrainParam.SrcImage)
'        Call m_ImageViewerSrc.DispImage(m_Matching.TrainParam.SrcImage)
'        Call m_Matching.Run(True)
'        'Call m_ImageViewerSrc.DispRegion(m_Matching.RunParam.SearchRegion, "yellow")
'        Call tviewResult.Nodes.Clear()
'        Call tviewResult.Nodes.Add("Result")
'        For idx As Integer = 0 To (m_Matching.Count - 1)
'            Call m_ImageViewerSrc.DispCross(m_Matching.Results(idx).CenterY, m_Matching.Results(idx).CenterX, 50, 0)
'            Call m_ImageViewerSrc.DispText(20, 20, "找尋時間:" & m_Matching.RunTime.ToString("N0") & "ms", "white")
'            Call m_ImageViewerSrc.DispText(CInt(m_Matching.Results(idx).CenterX - 40), CInt(m_Matching.Results(idx).CenterY - 40), idx.ToString(), "yellow")
'            Call tviewResult.Nodes(0).Nodes.Add(idx.ToString())
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("X:" & m_Matching.Results(idx).CenterX.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Y:" & m_Matching.Results(idx).CenterY.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Angle:" & m_Matching.Results(idx).RotaryAngleD.ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Scale:" & (m_Matching.Results(idx).Scale * 100).ToString("N2"))
'            Call tviewResult.Nodes(0).Nodes(idx).Nodes.Add("Score:" & (m_Matching.Results(idx).Score * 100).ToString("N2"))
'        Next
'    End Sub
'End Class