Imports System
Imports System.Data
Imports System.Data.OleDb

Public Class Form1
    Dim Baris As Integer = 0

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        ListView1.GridLines = True
        ListView1.View = View.Details
        ListView1.Columns.Add("Nama", 115)
        ListView1.Columns.Add("Ukuran Baju", 110)
        ListView1.Columns.Add("Jurusan", 110)
        ComboBox1.Text = "Pilih Ukuran Baju"
        ComboBox1.Items.Add("S")
        ComboBox1.Items.Add("M")
        ComboBox1.Items.Add("L")
        ComboBox1.Items.Add("X")
        ComboBox1.Items.Add("XL")
        ComboBox1.Items.Add("XXL")
        ComboBox2.Text = "Pilih Jurusan"
        ComboBox2.Items.Add("RPL")
        ComboBox2.Items.Add("AKT")
        ComboBox2.Items.Add("ANM")
        ComboBox2.Items.Add("TKJ")
        ComboBox2.Items.Add("APK")
        ComboBox2.Items.Add("TP4")
        TextBox2.Text = "Masukan Nama Siswa"
        TextBox2.Focus()

        'Panggil Method LoadData()
        LoadData()




    End Sub
    'Method Pembantu

    Sub LoadData()
        'Deklarasi Variabel
        Dim koneksiString As String
        Dim oleDbConnection As OleDbConnection
        Dim oledbCommand = New OleDbCommand
        Dim sqlCommand As String
        Dim oledbReader As OleDbDataReader

        'Koneksi String
        koneksiString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database.mdb"
        oleDbConnection = New OleDbConnection
        oleDbConnection.ConnectionString = koneksiString

        'Buka Koneksi
        If oleDbConnection.State = ConnectionState.Closed Then oleDbConnection.Open()

        'Query untuk menampilkan data
        sqlCommand = "select * from TB_BAJU"

        'perintah untuk eksekusi data didatabase
        oledbCommand.CommandText = sqlCommand
        oledbCommand.Connection = oleDbConnection
        oledbReader = oledbCommand.ExecuteReader()

        ' deklarasi variabel listview untuk ditampilkan di list
        Dim listitem As ListViewItem
        listitem = New ListViewItem

        'Baca data didatabase dan datanya dimasukan ke listview
        While oledbReader.Read()
            Console.WriteLine(oledbReader(0).ToString())
            listitem = ListView1.Items.Add(oledbReader(0).ToString())
            listitem.SubItems.Add(oledbReader(1).ToString())
            listitem.SubItems.Add(oledbReader(2).ToString())
        End While
        oledbReader.Close()

    End Sub



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim arr(2) As String
        arr(0) = ComboBox1.Text
        arr(1) = TextBox2.Text
        arr(2) = ComboBox2.Text

        Dim listitem As ListViewItem
        listitem = New ListViewItem
        listitem = ListView1.Items.Add(arr(0))
        listitem.SubItems.Add(arr(1))
        listitem.SubItems.Add(arr(2))

        TextBox2.Focus()


        'Deklarasi Variabel
        Dim koneksiString As String
        Dim oleDbConnection As OleDbConnection
        Dim oledbReader As OleDbDataReader = Nothing
        Dim oledbCommand = New OleDbCommand
        Dim sqlCommand As String


        'Koneksi String
        koneksiString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\Database.mdb"
        oleDbConnection = New OleDbConnection
        oleDbConnection.ConnectionString = koneksiString

        'Buka Koneksi
        If oleDbConnection.State = ConnectionState.Closed Then oleDbConnection.Open()

        'Save To Database 
        Try
            sqlCommand = String.Format("insert into TB_BAJU values('{0}','{1}','{2}')", ComboBox1.Text.ToString(), TextBox2.Text.ToString(),
                                       ComboBox2.Text.ToString())
            oledbCommand.CommandText = sqlCommand
            oledbCommand.Connection = oleDbConnection
            oledbCommand.ExecuteNonQuery()
            MessageBox.Show("Simpan Sukses")
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try








    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ListView1.Items.Clear()
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged
        Baris = ListView1.FocusedItem.Index
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        For Each i As ListViewItem In ListView1.SelectedItems
            ListView1.Items.Remove(i)
        Next

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim tutup As String
        tutup = MessageBox.Show("Yakin ingin menutup applikasi ?", "Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If tutup = MsgBoxResult.Yes Then
            End
        Else
        End If

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub

    Private Sub FileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FileToolStripMenuItem.Click

    End Sub



    Private Sub TutorPenggunaanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TutorPenggunaanToolStripMenuItem.Click
        Form2.Show()

    End Sub

    Private Sub TentangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TentangToolStripMenuItem.Click
        tentang.Show()

    End Sub
End Class

