Imports MySql.Data.MySqlClient
Imports MaterialSkin
Imports MaterialSkin.Controls
Public Class Login


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE)
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
                query = "select id_pegawai,pass,nama from pegawai where id_pegawai ='" + txtuname.Text + "'and pass ='" + txtpass.Text + "'"
                cmd = New MySqlCommand(query, mysqlconn)
                reader = cmd.ExecuteReader
                If reader.HasRows Then
                    'MessageBox.Show("Username dan Password benar")
                    reader.Read()
                    Dim dashboard As New Dashboard
                    Me.Hide()
                    'mengirim data dari textboxt username ke label userid di form dashboard
                    dashboard.strnama.Text = reader("nama")
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

    Private Sub MaterialRaisedButton1_Click(sender As Object, e As EventArgs) Handles MaterialRaisedButton1.Click
        login()
    End Sub

End Class
