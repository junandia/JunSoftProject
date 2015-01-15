Public Class Form2

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Text = "1. Pilih ukuran baju siswa yang telah diukur"
        TextBox2.Text = "2. Masukan nama siswa"
        TextBox3.Text = "3. Pilih Jurusan siswa yang telah diukur"
        TextBox4.Text = "4. Klik Button Tambahkan"
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()

    End Sub
End Class