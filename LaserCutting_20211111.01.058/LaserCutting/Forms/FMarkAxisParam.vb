Public Class FMarkAxisParam
    Public Shared MARK_AXIS_PARAM_PATH As String = System.IO.Path.GetTempPath() & "MarkAxisParam.txt"
    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        Try
            Dim lines(7) As String
            lines(0) = numOffsetX.Value.ToString("F0")
            lines(1) = numOffsetY.Value.ToString("F0")
            lines(2) = numAxisLength.Value.ToString("F0")
            lines(3) = numArrowLength.Value.ToString("F0")
            lines(4) = numArrowSize.Value.ToString("F0")
            lines(5) = numCharSpacing.Value.ToString("F0")
            lines(6) = numCharHeight.Value.ToString("F0")
            lines(7) = numCharWidth.Value.ToString("F0")
            System.IO.File.WriteAllLines(MARK_AXIS_PARAM_PATH, lines)
            ReDim lines(-1)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FMarkAxisParam_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim offsetX As Integer = 0
            Dim offsetY As Integer = 0
            Dim axisLength As Integer = 5000 'um
            Dim arrowLength As Integer = 500
            Dim arrowSize As Integer = 600
            Dim characterSpacing As Integer = 100
            Dim characterW As Integer = 400
            Dim characterH As Integer = 600
            If (System.IO.File.Exists(MARK_AXIS_PARAM_PATH)) Then
                Dim lines() As String = System.IO.File.ReadAllLines(MARK_AXIS_PARAM_PATH)
                For idx = 0 To lines.Length - 1
                    Dim value As Integer = 0
                    Select Case idx
                        Case 0
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (-65535 <= value AndAlso value <= 65535) Then
                                    offsetX = value
                                End If
                            End If
                        Case 1
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (-65535 <= value AndAlso value <= 65535) Then
                                    offsetY = value
                                End If
                            End If
                        Case 2
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    axisLength = value
                                End If
                            End If
                        Case 3
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    arrowLength = value
                                End If
                            End If
                        Case 4
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    arrowSize = value
                                End If
                            End If
                        Case 5
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterSpacing = value
                                End If
                            End If
                        Case 6
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterH = value
                                End If
                            End If
                        Case 7
                            If (Integer.TryParse(lines(idx), value)) Then
                                If (0 < value AndAlso value <= 65535) Then
                                    characterW = value
                                End If
                            End If
                    End Select
                Next

            End If
            numOffsetX.Value = offsetX
            numOffsetY.Value = offsetY
            numAxisLength.Value = axisLength
            numArrowLength.Value = arrowLength
            numArrowSize.Value = arrowSize
            numCharSpacing.Value = characterSpacing
            numCharHeight.Value = characterH
            numCharWidth.Value = characterW
        Catch ex As Exception

        End Try
    End Sub
End Class