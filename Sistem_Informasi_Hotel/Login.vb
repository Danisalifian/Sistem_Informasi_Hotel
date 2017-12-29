Imports MySql.Data.MySqlClient
Public Class Login


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Dim mysqlconn As MySqlConnection
    Private Sub login()
        Dim id_pegawai As String
        Dim pass As String
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        id_pegawai = txtuname.Text
        pass = txtpass.Text

        id_pegawai = id_pegawai.ToUpper

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            If txtuname.Text = "" Or txtpass.Text = "" Then
                MessageBox.Show("Field Username atau password masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                mysqlconn.Open()
                query = "select id_pegawai,pass from pegawai where id_pegawai ='" + txtuname.Text + "'and pass ='" + txtpass.Text + "'"
                cmd = New MySqlCommand(query, mysqlconn)
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    'MessageBox.Show("Username dan Password benar")
                    Dim dashboard As New Dashboard
                    Me.Hide()
                    'mengirim data dari textboxt username ke label userid di form dashboard
                    dashboard.strid.Text = txtuname.Text
                    dashboard.ShowDialog()
                    Me.Close()
                Else
                    MessageBox.Show("Username atau Password salah !", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    txtuname.Text = ""
                    txtpass.Text = ""
                    txtuname.Focus()
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btncekdb_Click(sender As Object, e As EventArgs) Handles btncekdb.Click

            mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
        Try
                mysqlconn.Open()
                MessageBox.Show("Koneksi Sukses!", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
                mysqlconn.Close()
            Catch ex As MySqlException
                'MessageBox.Show(ex.Message)
                Dim result = MessageBox.Show("MySql server tidak aktif atau Database tidak tersedia, buat database ?", "Peringatan", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                If result = DialogResult.Yes Then
                    MessageBox.Show("Yes pressed")
                    'buat_db()
                ElseIf result = DialogResult.No Then
                    MessageBox.Show("Database tidak dibuat")
                End If
            Finally
                mysqlconn.Dispose()
            End Try
        End Sub

        Private Sub btnmasuk_Click(sender As Object, e As EventArgs) Handles btnmasuk.Click
            login()
        End Sub

    Private Sub BunifuFlatButton1_Click(sender As Object, e As EventArgs) Handles btntutup.Click
        Application.Exit()
    End Sub

    Private Sub txtpass_OnValueChanged(sender As Object, e As EventArgs)

        End Sub

End Class
