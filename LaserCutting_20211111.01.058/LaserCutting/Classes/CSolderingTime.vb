Public Class CSolderingTime
    Public LaserOnTime As Double
    Public LaserOffTime As Double
    Public ForwardDelayEnd As Double
    Public ForwardMoveEnd(0 To 1) As Double
    Public BackwardDelayEnd As Double
    Public BackwardMoveEnd As Double
    Public Interval As Integer
    Public Sub New()
        LaserOnTime = 0
        LaserOffTime = 0
        ForwardDelayEnd = 0
        ForwardMoveEnd(0) = 0
        ForwardMoveEnd(1) = 0
        BackwardDelayEnd = 0
        BackwardMoveEnd = 0
        Interval = 0
    End Sub
End Class
