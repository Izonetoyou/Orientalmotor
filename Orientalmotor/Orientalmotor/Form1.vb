
Public Class Form1

    Private motor As OrientalMotorController
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        motor = New OrientalMotorController("COM10", 115200, 1)

    End Sub

    Private Sub btnJogP_Click(sender As Object, e As EventArgs) Handles btnJogP.Click
        Dim n As Integer = 0
        n = CInt(lbPosition.Text) + CInt(cb_acc.Text)
        If n <= 1199 Then
            motor.StartJOG(n, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
        End If
    End Sub
    Private Sub btnJogN_Click(sender As Object, e As EventArgs) Handles btnJogN.Click
        Dim n As Integer = 0
        n = CInt(lbPosition.Text) - CInt(cb_acc.Text)
        If n >= 0 Then
            motor.StartJOG(n, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
        End If

    End Sub
    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        motor.ZHome()
    End Sub
    Private Sub btnreset_Click(sender As Object, e As EventArgs) Handles btnreset.Click
        motor.ResetAlarm()
    End Sub
    Private Sub btnFWPos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnFWPos.MouseDown
        motor.TurnFWPosOn()
    End Sub

    Private Sub btnFWPos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnFWPos.MouseUp
        motor.StopFWPos()
    End Sub

    Private Sub btnRVPos_MouseDown(sender As Object, e As MouseEventArgs) Handles btnRVPos.MouseDown
        motor.TurnRVPosOn()
    End Sub

    Private Sub btnRVPos_MouseUp(sender As Object, e As MouseEventArgs) Handles btnRVPos.MouseUp
        motor.StopRVPos()
    End Sub

    ' Close connection on Form close
    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        motor.Disconnect()
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Dim position As Integer = motor.ReadFeedbackPosition()
        If position <> -1 Then
            lbPosition.Text = position.ToString()
        End If

        Timer1.Enabled = True
    End Sub



    Private Sub btnPTP_Click(sender As Object, e As EventArgs) Handles btnPTP.Click
        If btnPTP.Text = "P2" Then
            motor.StartJOG(txtP1.Text, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
            btnPTP.Text = "P1"
        Else
            motor.StartJOG(txtP2.Text, txtAcc.Text, txtSpeed.Text, txtbrakes.Text)
            btnPTP.Text = "P2"
        End If

    End Sub

    Private Sub cbShowposition_CheckedChanged(sender As Object, e As EventArgs) Handles cbShowposition.CheckedChanged
        If cbShowposition.Checked = True Then
            Timer1.Enabled = True
        Else
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub btnLoop_Click(sender As Object, e As EventArgs) Handles btnLoop.Click
        For i = 0 To 5000
            btnPTP_Click(sender, e)
            Delay(100)
            i = i + 1
            Debug.Print(i)
        Next
    End Sub
    Public Sub Delay(milliSec As Integer)

        Dim sw2 As New Stopwatch
        sw2.Start()
        Do
            Application.DoEvents()
        Loop Until sw2.ElapsedMilliseconds >= milliSec

    End Sub

    Private Sub btNoOff_Click(sender As Object, e As EventArgs) Handles btNoOff.Click
        If btNoOff.Text = "OFF" Then
            motor.ControlMotor(True)
            btNoOff.Text = "ON"
        Else
            motor.ControlMotor(False)
            btNoOff.Text = "OFF"
        End If
    End Sub
End Class