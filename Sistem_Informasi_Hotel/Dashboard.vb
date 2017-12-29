Imports MySql.Data.MySqlClient
Imports MaterialSkin
Imports MaterialSkin.Controls
Public Class Dashboard
    Dim mousex, mousey As Integer
    Dim drag As Boolean
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE)
        list_pegawai()
        list_kamar()
        list_konsumen()
    End Sub
    Private Sub labelSI_Click(sender As Object, e As EventArgs) 

    End Sub

    Private Sub btnreservasi_Click(sender As Object, e As EventArgs) Handles btnreservasi.Click
        PanelReservasi.Visible = True
        PanelKamar.Visible = False
        PanelPencarian.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
    End Sub

    Private Sub btnkamar_Click(sender As Object, e As EventArgs) Handles btnkamar.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = True
        PanelPencarian.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
    End Sub

    Private Sub btnpencarian_Click(sender As Object, e As EventArgs) Handles btnpencarian.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelPencarian.Visible = True
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
    End Sub

    Private Sub btnlaporan_Click(sender As Object, e As EventArgs) Handles btnlaporan.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelPencarian.Visible = False
        PanelLaporan.Visible = True
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
    End Sub

    '==================================  Memindahkan form ============================================
    Private Sub Panelheadcontrol_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub Panelheadcontrol_MouseUp(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            drag = False
        End If
    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        'Application.Exit()
        Dim flogin As New Login
        Me.Hide()
        flogin.ShowDialog()
        'Me.Close()
    End Sub

    Private Sub simpan_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO KONSUMEN (id_konsumen,nama,tgl_lahir,tempat_lahir,alamat,kota,no_telp)
                     values ('" + TextBox15.Text + "','" + TextBox16.Text + "','" + TextBox17.Text +
                              "','" + TextBox18.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
    Private Sub btnsimpankonsumen_Click(sender As Object, e As EventArgs) Handles btnsimpankonsumen.Click
        simpan_konsumen()
    End Sub

    Private Sub btnkonsumen_Click(sender As Object, e As EventArgs) Handles btnkonsumen.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelPencarian.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = True
        PanelPegawai.Visible = False
    End Sub

    Private Sub btnpegawai_Click(sender As Object, e As EventArgs) Handles btnpegawai.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelPencarian.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = True
    End Sub

    Private Sub simpan_pegawai()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO PEGAWAI (id_pegawai,nama,tgl_lahir,tempat_lahir,alamat,no_telp,pass)
                     values ('" + TextBox22.Text + "','" + TextBox23.Text + "','" + TextBox24.Text +
                              "','" + TextBox25.Text + "','" + TextBox26.Text + "','" + TextBox27.Text + "','" + TextBox28.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
    Private Sub btnsimpan_pegawai_Click(sender As Object, e As EventArgs) Handles btnsimpan_pegawai.Click
        simpan_pegawai()
    End Sub

    'Private Sub load_datapegawai()
    '    Dim mysqlconn As MySqlConnection
    '    'Dim cmd As MySqlCommand
    '    Dim query As String
    '    'Dim reader As MySqlDataReader

    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

    '    Try
    '        mysqlconn.Open()
    '        query = "SELECT * FROM PEGAWAI"
    '        'cmd = New MySqlCommand(query, mysqlconn)
    '        'reader = cmd.ExecuteReader
    '        Dim data As New MySqlDataAdapter(query, mysqlconn)
    '        Dim ds_pegawai As DataSet = New DataSet
    '        data.Fill(ds_pegawai, "pegawai")
    '        DataGridView1.DataSource = ds_pegawai.Tables("pegawai")
    '        mysqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        mysqlconn.Dispose()
    '    End Try
    'End Sub

    Private Sub list_konsumen()
        Dim mysqlconn As New MySqlConnection
        Dim query As String = "SELECT * FROM KONSUMEN"
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        If mysqlconn.State = ConnectionState.Closed Then
            mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
            mysqlconn.Open()
        End If

        With cmd
            .CommandText = query
            .Connection = mysqlconn
        End With

        With adapter
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        'lvpegawai.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With lvkonsumen
                .Items.Add(TABLE.Rows(i)("id_konsumen"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(TABLE.Rows(i)("nama"))
                    .Add(TABLE.Rows(i)("tgl_lahir"))
                    .Add(TABLE.Rows(i)("tempat_lahir"))
                    .Add(TABLE.Rows(i)("alamat"))
                    .Add(TABLE.Rows(i)("kota"))
                    .Add(TABLE.Rows(i)("no_telp"))
                End With
            End With
        Next
    End Sub
    Private Sub list_kamar()
        Dim mysqlconn As New MySqlConnection
        Dim query As String = "SELECT * FROM KAMAR"
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        If mysqlconn.State = ConnectionState.Closed Then
            mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
            mysqlconn.Open()
        End If

        With cmd
            .CommandText = query
            .Connection = mysqlconn
        End With

        With adapter
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        'lvpegawai.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With lvkamar
                .Items.Add(TABLE.Rows(i)("id_kamar"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(TABLE.Rows(i)("tipe_kamar"))
                    .Add(TABLE.Rows(i)("harga"))
                    .Add(TABLE.Rows(i)("fasilitas"))
                End With
            End With
        Next
    End Sub

    Private Sub list_pegawai()
        Dim mysqlconn As New MySqlConnection
        Dim query As String = "SELECT * FROM PEGAWAI"
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        If mysqlconn.State = ConnectionState.Closed Then
            mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
            mysqlconn.Open()
        End If

        With cmd
            .CommandText = query
            .Connection = mysqlconn
        End With

        With adapter
            .SelectCommand = cmd
            .Fill(TABLE)
        End With

        'lvpegawai.Clear()

        For i = 0 To TABLE.Rows.Count - 1
            With lvpegawai
                .Items.Add(TABLE.Rows(i)("id_pegawai"))
                With .Items(.Items.Count - 1).SubItems
                    .Add(TABLE.Rows(i)("nama"))
                    .Add(TABLE.Rows(i)("tgl_lahir"))
                    .Add(TABLE.Rows(i)("tempat_lahir"))
                    .Add(TABLE.Rows(i)("alamat"))
                    .Add(TABLE.Rows(i)("no_telp"))
                    .Add(TABLE.Rows(i)("pass"))
                End With
            End With
        Next
    End Sub

    Private Sub PanelPegawai_Paint(sender As Object, e As PaintEventArgs) Handles PanelPegawai.Paint

    End Sub

    Private Sub simpan_kamar()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO kamar (id_kamar,tipe_kamar,harga,fasilitas)
                     values ('" + TextBox29.Text + "','" + TextBox30.Text + "','" + TextBox31.Text + "','" + RichTextBox2.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub
    Private Sub btnsimpan_kamar_Click(sender As Object, e As EventArgs) Handles btnsimpan_kamar.Click
        simpan_kamar()
    End Sub

    Private Sub simpan_reservasi()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_reservasi, tgl_in, tgl_out As String
        Dim id_peg As String

        id_peg = strid.Text

        '================memformat tanggal agar bisa disimpan ke mysql============
        tgl_reservasi = DateTimePicker1.Value.Date.ToString("yyyy-MM-dd")
        tgl_in = DateTimePicker2.Value.Date.ToString("yyyy-MM-dd")
        tgl_out = DateTimePicker3.Value.Date.ToString("yyyy-MM-dd")
        '=========================================================================

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO reservasi (id_reservasi,id_konsumen,tgl_reservasi,check_in,check_out,id_kamar,hari,catatan,id_pegawai)
                     values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + tgl_reservasi + "','" + tgl_in +
                     "','" + tgl_out + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + RichTextBox1.Text + "','" + id_peg + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btnsimpan_reservasi_Click(sender As Object, e As EventArgs) Handles btnsimpan_reservasi.Click
        simpan_reservasi()
    End Sub

    Private Sub Panelheadcontrol_MouseMove(sender As Object, e As MouseEventArgs)
        If drag = True Then
            Dim point As Point = New Point()
            point.X = Me.Location.X + (e.X - mousex)
            point.Y = Me.Location.Y + (e.Y - mousey)
            Me.Location = point
            point = Nothing
        End If
    End Sub
    '=========================================#########################################==============================
End Class