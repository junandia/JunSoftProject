Public Class Form3

    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If ProgressBar1.Value < 100 Then
            ProgressBar1.Value += 20
        ElseIf ProgressBar1.Value = 100 Then
            Timer1.Stop()
            MessageBox.Show("Selamat datang di programku ", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
End Class