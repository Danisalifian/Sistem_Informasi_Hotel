Imports MySql.Data.MySqlClient
Imports MaterialSkin
Imports MaterialSkin.Controls
Imports System.IO
Public Class Dashboard
    Dim mousex, mousey As Integer
    Dim drag As Boolean
    Dim stat_btnkonsumen, stat_btnpegawai, stat_btnkamar As String

    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim SkinManager As MaterialSkinManager = MaterialSkinManager.Instance
        SkinManager.AddFormToManage(Me)
        SkinManager.Theme = MaterialSkinManager.Themes.LIGHT
        SkinManager.ColorScheme = New ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE)
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_kamar()
        disable_input_reservasi()
        disable_input_pembayaran()
        load_datapegawai()
        load_datakonsumen()
        load_datakonsumen1()
        load_datakamar()
        load_datareservasi()
        load_datapembayaran
        disable_sort_konsumen()
        cmb_jenisbayar.SelectedIndex = 1
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub btnreservasi_Click(sender As Object, e As EventArgs) Handles btnreservasi.Click
        PanelReservasi.Visible = True
        PanelKamar.Visible = False
        PanelBackup.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub btnkamar_Click(sender As Object, e As EventArgs) Handles btnkamar.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = True
        PanelBackup.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub btnpencarian_Click(sender As Object, e As EventArgs) Handles btnpencarian.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelBackup.Visible = True
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub btnlaporan_Click(sender As Object, e As EventArgs) Handles btnlaporan.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelBackup.Visible = False
        PanelLaporan.Visible = True
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = False
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub Panelheadcontrol_MouseDown(sender As Object, e As MouseEventArgs)
        If e.Button = MouseButtons.Left Then
            drag = True
            mousex = e.X
            mousey = e.Y
        End If
    End Sub

    Private Sub hitung_subtotal()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "select harga from kamar where id_kamar ='" + TextBox3.Text + "'"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            If reader.HasRows Then
                reader.Read()
                TextBox7.Text = reader("harga")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub Panelheadcontrol_MouseUp(sender As Object, e As MouseEventArgs)

    End Sub

    Private Sub BunifuFlatButton2_Click(sender As Object, e As EventArgs) Handles BunifuFlatButton2.Click
        Dim flogin As New Login
        Me.Hide()
        flogin.ShowDialog()
    End Sub

    Private Sub simpan_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_lahir As String
        Dim j_kel As String

        tgl_lahir = DateTimePicker4.Value.Date.ToString("yyyy-MM-dd")
        If RB_Lkons.Checked Then
            j_kel = "Laki-laki"
        Else
            j_kel = "Perempuan"
        End If

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO KONSUMEN (id_konsumen,nama,j_kelamin,tgl_lahir,tempat_lahir,alamat,kota,no_telp)
                     values ('" + TextBox15.Text + "','" + TextBox16.Text + "','" + j_kel + "','" + tgl_lahir +
                              "','" + TextBox18.Text + "','" + TextBox19.Text + "','" + TextBox20.Text + "','" + TextBox21.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakonsumen()
                load_datakonsumen1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub disable_input_konsumen()
        TextBox15.Enabled = False
        TextBox16.Enabled = False
        DateTimePicker4.Enabled = False
        RB_Lkons.Enabled = False
        RB_Pkons.Enabled = False
        TextBox18.Enabled = False
        TextBox19.Enabled = False
        TextBox20.Enabled = False
        TextBox21.Enabled = False
    End Sub

    Private Sub disable_input_reservasi()
        TextBox1.Enabled = False
        TextBox2.Enabled = False
        DateTimePicker1.Enabled = False
        DateTimePicker2.Enabled = False
        DateTimePicker3.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        chk_xbed.Enabled = False
    End Sub

    Private Sub disable_input_pembayaran()
        TextBox6.Enabled = False
        TextBox5.Enabled = False
        cmb_jenisbayar.Enabled = False
        TextBox7.Enabled = False
        TextBox8.Enabled = False
        TextBox9.Enabled = False
        TextBox10.Enabled = False
        TextBox11.Enabled = False
    End Sub

    Private Sub enable_input_pembayaran()
        TextBox6.Enabled = True
        TextBox5.Enabled = True
        cmb_jenisbayar.Enabled = True
        TextBox7.Enabled = True
        TextBox8.Enabled = True
        TextBox9.Enabled = True
        TextBox10.Enabled = True
        TextBox11.Enabled = True
    End Sub

    Private Sub enable_input_reservasi()
        TextBox1.Enabled = True
        TextBox2.Enabled = True
        DateTimePicker1.Enabled = True
        DateTimePicker2.Enabled = True
        DateTimePicker3.Enabled = True
        TextBox3.Enabled = True
        TextBox4.Enabled = True
        chk_xbed.Enabled = True
    End Sub

    Private Sub disable_input_pegawai()
        TextBox22.Enabled = False
        TextBox23.Enabled = False
        DateTimePicker5.Enabled = False
        RB_Lpeg.Enabled = False
        RB_Ppeg.Enabled = False
        TextBox25.Enabled = False
        TextBox26.Enabled = False
        TextBox27.Enabled = False
        TextBox28.Enabled = False
    End Sub

    Private Sub disable_sort_konsumen()
        For i As Integer = DGV_konsumen.Columns.Count - 1 To 0 Step -1
            DGV_konsumen.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next
    End Sub

    Private Sub disable_input_kamar()
        TextBox29.Enabled = False
        TextBox30.Enabled = False
        TextBox31.Enabled = False
        RichTextBox2.Enabled = False
    End Sub

    Private Sub enable_input_konsumen()
        TextBox15.Enabled = True
        TextBox16.Enabled = True
        DateTimePicker4.Enabled = True
        RB_Lkons.Enabled = True
        RB_Pkons.Enabled = True
        TextBox18.Enabled = True
        TextBox19.Enabled = True
        TextBox20.Enabled = True
        TextBox21.Enabled = True
    End Sub

    Private Sub enable_input_pegawai()
        TextBox22.Enabled = True
        TextBox23.Enabled = True
        DateTimePicker5.Enabled = True
        RB_Lpeg.Enabled = True
        RB_Ppeg.Enabled = True
        TextBox25.Enabled = True
        TextBox26.Enabled = True
        TextBox27.Enabled = True
        TextBox28.Enabled = True
    End Sub

    Private Sub enable_input_kamar()
        TextBox29.Enabled = True
        TextBox30.Enabled = True
        TextBox31.Enabled = True
        RichTextBox2.Enabled = True
    End Sub

    Private Sub clear_reservasi()
        TextBox1.Text = ""
        TextBox2.Text = ""
        DateTimePicker1.Value = DateTime.Now.ToString("dd MMMM yy")
        DateTimePicker2.Value = DateTime.Now.ToString("dd MMMM yy")
        DateTimePicker3.Value = DateTime.Now.ToString("dd MMMM yy")
        TextBox3.Text = ""
        TextBox4.Text = ""
        chk_xbed.Enabled = False
    End Sub

    Private Sub clear_pembayaran()
        TextBox6.Text = ""
        TextBox5.Text = ""
        cmb_jenisbayar.Enabled = False
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""
        TextBox11.Text = ""
    End Sub

    Private Sub clear_konsumen()
        TextBox15.Text = ""
        TextBox16.Text = ""
        DateTimePicker4.Value = DateTime.Now.ToString("dd MMMM yy")
        RB_Lkons.Checked = False
        RB_Pkons.Checked = False
        TextBox18.Text = ""
        TextBox19.Text = ""
        TextBox20.Text = ""
        TextBox21.Text = ""
    End Sub

    Private Sub clear_kamar()
        TextBox29.Text = ""
        TextBox30.Text = ""
        TextBox31.Text = ""
        RichTextBox2.Text = ""
    End Sub

    Private Sub clear_pegawai()
        TextBox22.Text = ""
        TextBox23.Text = ""
        DateTimePicker5.Value = DateTime.Now.ToString("dd MMMM yy")
        RB_Lpeg.Checked = False
        RB_Ppeg.Checked = False
        TextBox25.Text = ""
        TextBox26.Text = ""
        TextBox27.Text = ""
        TextBox28.Text = ""
    End Sub

    Private Sub btnkonsumen_Click(sender As Object, e As EventArgs) Handles btnkonsumen.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelBackup.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = True
        PanelPegawai.Visible = False
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub btnpegawai_Click(sender As Object, e As EventArgs) Handles btnpegawai.Click
        PanelReservasi.Visible = False
        PanelKamar.Visible = False
        PanelBackup.Visible = False
        PanelLaporan.Visible = False
        Panelkonsumen.Visible = False
        PanelPegawai.Visible = True
        disable_input_kamar()
        disable_input_konsumen()
        disable_input_pegawai()
        disable_input_pembayaran()
        disable_input_reservasi()
        clear_kamar()
        clear_konsumen()
        clear_pegawai()
        clear_pembayaran()
        clear_reservasi()
    End Sub

    Private Sub simpan_pegawai()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_lahir As String
        Dim j_kel As String

        tgl_lahir = DateTimePicker5.Value.Date.ToString("yyyy-MM-dd")
        If RB_Lpeg.Checked Then
            j_kel = "Laki-laki"
        Else
            j_kel = "Perempuan"
        End If

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO PEGAWAI (id_pegawai,nama,j_kelamin,tgl_lahir,tempat_lahir,alamat,no_telp,pass)
                     values ('" + TextBox22.Text + "','" + TextBox23.Text + "','" + j_kel + "','" + tgl_lahir +
                              "','" + TextBox25.Text + "','" + TextBox26.Text + "','" + TextBox27.Text + "','" + TextBox28.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            Dim result = MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datapegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub load_datapegawai()
        Dim mysqlconn As MySqlConnection
        Dim query As String

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM PEGAWAI order by id_pegawai + 0 ASC"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_pegawai As DataSet = New DataSet
            data.Fill(ds_pegawai, "pegawai")
            DGV_pegawai.DataSource = ds_pegawai.Tables("pegawai")
            With DGV_pegawai
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Pegawai"
                .Columns(1).HeaderText = "Nama"
                .Columns(2).HeaderText = "Jenis Kelamin"
                .Columns(3).HeaderText = "Tanggal Lahir"
                .Columns(4).HeaderText = "Tempat Lahir"
                .Columns(5).HeaderText = "Alamat"
                .Columns(6).HeaderText = "No Telepon"
            End With
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub load_datakonsumen()
        Dim mysqlconn As MySqlConnection
        Dim query As String

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KONSUMEN order by id_konsumen + 0 ASC"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_konsumen As DataSet = New DataSet
            data.Fill(ds_konsumen, "konsumen")
            DGV_konsumen.DataSource = ds_konsumen.Tables("konsumen")
            With DGV_konsumen
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Konsumen"
                .Columns(1).HeaderText = "Nama"
                .Columns(2).HeaderText = "Jenis Kelamin"
                .Columns(3).HeaderText = "Tanggal Lahir"
                .Columns(4).HeaderText = "Tempat Lahir"
                .Columns(5).HeaderText = "Alamat"
                .Columns(6).HeaderText = "Kota"
                .Columns(7).HeaderText = "No Telepon"
            End With

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub load_datareservasi()
        DGV_reservasi.DataSource = Nothing
        Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
            Using cmd As New MySqlCommand("SELECT * from reservasi;", mysqlconn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DGV_reservasi.DataSource = dt
                        With DGV_reservasi
                            .RowHeadersVisible = False
                            .Columns(0).HeaderText = "Id Reservasi"
                            .Columns(1).HeaderText = "Id Konsumen"
                            .Columns(2).HeaderText = "Tanggal Reservasi"
                            .Columns(3).HeaderText = "Check In"
                            .Columns(4).HeaderText = "Check out"
                            .Columns(5).HeaderText = "Nomor kamar"
                            .Columns(6).HeaderText = "Hari"
                            .Columns(7).HeaderText = "Biaya Tambahan"
                            .Columns(8).HeaderText = "Id Pegawai"
                        End With
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub load_datapembayaran()
        DGV_pembayaran.DataSource = Nothing
        Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
            Using cmd As New MySqlCommand("SELECT * from pembayaran;", mysqlconn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DGV_pembayaran.DataSource = dt
                        With DGV_pembayaran
                            .RowHeadersVisible = False
                            .Columns(0).HeaderText = "Id Pembayaran"
                            .Columns(1).HeaderText = "Id Reservasi"
                            .Columns(2).HeaderText = "Jenis Bayar"
                            .Columns(3).HeaderText = "Subtotal"
                            .Columns(4).HeaderText = "Biaya Tambahan"
                            .Columns(5).HeaderText = "Total"
                            .Columns(6).HeaderText = "Bayar"
                            .Columns(7).HeaderText = "Kembalian"
                        End With
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub load_datakonsumen1()
        DGV_konsumen1.DataSource = Nothing
        Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
            Using cmd As New MySqlCommand("SELECT * from konsumen;", mysqlconn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DGV_konsumen1.DataSource = dt
                        With DGV_konsumen1
                            .RowHeadersVisible = False
                            .Columns(0).HeaderText = "Id Konsumen"
                            .Columns(1).HeaderText = "Nama"
                            .Columns(2).HeaderText = "Jenis Kelamin"
                            .Columns(3).HeaderText = "Tanggal Lahir"
                            .Columns(4).HeaderText = "Tempat Lahir"
                            .Columns(5).HeaderText = "Alamat"
                            .Columns(6).HeaderText = "Kota"
                            .Columns(7).HeaderText = "No Telepon"
                        End With
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub load_datakamar()
        Dim mysqlconn As MySqlConnection
        Dim query As String

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KAMAR order by id_kamar + 0 ASC"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_kamar As DataSet = New DataSet
            data.Fill(ds_kamar, "kamar")
            DGV_kamar.DataSource = ds_kamar.Tables("kamar")
            With DGV_kamar
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Kamar"
                .Columns(1).HeaderText = "Tipe Kamar"
                .Columns(2).HeaderText = "Harga"
                .Columns(3).HeaderText = "Fasilitas"
            End With
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            mysqlconn.Dispose()
        End Try
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
            Dim result = MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakamar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub cari_kamar_kosong()
        Dim mysqlconn As MySqlConnection
        Dim query As String
        Dim tgl_in, tgl_out As String

        '================memformat tanggal agar bisa dibaca mysql============
        tgl_in = Date_mulai.Value.Date.ToString("yyyy-MM-dd")
        tgl_out = Date_akhir.Value.Date.ToString("yyyy-MM-dd")
        '=========================================================================

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT id_kamar,tipe_kamar,harga,fasilitas FROM kamar WHERE id_kamar NOT IN(
                        SELECT kamar.id_kamar
                        FROM kamar JOIN reservasi ON reservasi.`id_kamar`=kamar.`id_kamar`
                        WHERE reservasi.`check_in`<='" + tgl_out + "' AND reservasi.`check_out`>='" + tgl_in + "');"
            'cmd = New MySqlCommand(query, mysqlconn)
            'reader = cmd.ExecuteReader
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_kamar As DataSet = New DataSet
            data.Fill(ds_kamar, "kamar")
            DGV_kamarkosong.DataSource = ds_kamar.Tables("kamar")
            With DGV_kamarkosong
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Kamar"
                .Columns(1).HeaderText = "Tipe Kamar"
                .Columns(2).HeaderText = "Harga"
                .Columns(3).HeaderText = "Fasilitas"
            End With
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub simpan_reservasi()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_reservasi, tgl_in, tgl_out As String
        Dim id_peg As String
        Dim tambahan As String = ""
        If chk_xbed.Checked = True Then
            tambahan = "Extra Bed"
        End If

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
            query = "INSERT INTO reservasi (id_reservasi,id_konsumen,tgl_reservasi,check_in,check_out,id_kamar,hari,tambahan,id_pegawai)
                     values ('" + TextBox1.Text + "','" + TextBox2.Text + "','" + tgl_reservasi + "','" + tgl_in +
                     "','" + tgl_out + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + tambahan + "','" + id_peg + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub simpan_pembayaran()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim jenis_bayar As String = ""

        If cmb_jenisbayar.Text = "Kartu Debit" Then
            jenis_bayar = "Kartu Debit"
            hitung_subtotal()
            TextBox9.Text = "0"
        ElseIf cmb_jenisbayar.Text = "Tunai" Then
            jenis_bayar = "Tunai"
        End If

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "INSERT INTO pembayaran (id_pembayaran,id_reservasi,jenis_bayar,subtotal,bayar_tambahan,total,bayar,kembalian)
                     values ('" + TextBox6.Text + "','" + TextBox5.Text + "','" + jenis_bayar + "','" + TextBox7.Text +
                     "','" + TextBox8.Text + "','" + TextBox11.Text + "','" + TextBox10.Text + "','" + TextBox9.Text + "')"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            Dim result = MessageBox.Show("Data tersimpan", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datareservasi()
                load_datapembayaran
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub hapus_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "DELETE FROM `db_hotel`.`konsumen` WHERE `id_konsumen` = '" + TextBox15.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data terhapus", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakonsumen()
                load_datakonsumen1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub ubah_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_lahir As String
        Dim j_kel As String

        tgl_lahir = DateTimePicker4.Value.Date.ToString("yyyy-MM-dd")
        If RB_Lkons.Checked Then
            j_kel = "Laki-laki"
        Else
            j_kel = "Perempuan"
        End If

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "UPDATE konsumen SET nama='" + TextBox16.Text + "',j_kelamin='" + j_kel +
                "',tgl_lahir='" + tgl_lahir + "',tempat_lahir='" + TextBox18.Text + "',alamat='" + TextBox19.Text +
                "',kota='" + TextBox20.Text + "',no_telp='" + TextBox21.Text + "' WHERE id_konsumen='" + TextBox15.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data diperbarui", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakonsumen()
                load_datakonsumen1()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub hapus_pegawai()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "DELETE FROM `db_hotel`.`pegawai` WHERE `id_pegawai` = '" + TextBox22.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data terhapus", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datapegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub ubah_pegawai()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader
        Dim tgl_lahir As String
        Dim j_kel As String

        tgl_lahir = DateTimePicker5.Value.Date.ToString("yyyy-MM-dd")
        If RB_Lkons.Checked Then
            j_kel = "Laki-laki"
        Else
            j_kel = "Perempuan"
        End If

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "UPDATE pegawai SET nama='" + TextBox23.Text + "',j_kelamin='" + j_kel +
                "',tgl_lahir='" + tgl_lahir + "',tempat_lahir='" + TextBox25.Text + "',alamat='" + TextBox26.Text +
                "',no_telp='" + TextBox27.Text + "',pass='" + TextBox28.Text + "' WHERE id_pegawai='" + TextBox22.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data diperbarui", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datapegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub ubah_kamar()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "UPDATE kamar SET tipe_kamar='" + TextBox30.Text + "',harga='" + TextBox31.Text +
                "',fasilitas='" + RichTextBox2.Text + "' WHERE id_kamar='" + TextBox29.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data diperbarui", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakamar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub hapus_kamar()
        Dim mysqlconn As MySqlConnection
        Dim cmd As MySqlCommand
        Dim query As String
        Dim reader As MySqlDataReader

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "DELETE FROM `db_hotel`.`kamar` WHERE `id_kamar` = '" + TextBox29.Text + "';"
            cmd = New MySqlCommand(query, mysqlconn)
            reader = cmd.ExecuteReader
            mysqlconn.Close()
            Dim result = MessageBox.Show("Data terhapus", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            If result = DialogResult.OK Then
                load_datakamar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub DGV_konsumen_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_konsumen.MouseClick
        disable_input_konsumen()
        Dim id_konsumen As String = DGV_konsumen.SelectedRows(0).Cells(0).Value
        Dim nama As String = DGV_konsumen.SelectedRows(0).Cells(1).Value
        Dim tempat_lahir As String = DGV_konsumen.SelectedRows(0).Cells(4).Value
        Dim alamat As String = DGV_konsumen.SelectedRows(0).Cells(5).Value
        Dim kota As String = DGV_konsumen.SelectedRows(0).Cells(6).Value
        Dim no_telp As String = DGV_konsumen.SelectedRows(0).Cells(7).Value

        TextBox15.Text = id_konsumen
        TextBox16.Text = nama
        TextBox18.Text = tempat_lahir
        TextBox19.Text = alamat
        TextBox20.Text = kota
        TextBox21.Text = no_telp
    End Sub

    Private Sub DGV_pegawai_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_pegawai.MouseClick
        disable_input_pegawai()
        Dim id_pegawai As String = DGV_pegawai.SelectedRows(0).Cells(0).Value
        Dim nama As String = DGV_pegawai.SelectedRows(0).Cells(1).Value
        Dim tempat_lahir As String = DGV_pegawai.SelectedRows(0).Cells(4).Value
        Dim alamat As String = DGV_pegawai.SelectedRows(0).Cells(5).Value
        Dim no_telp As String = DGV_pegawai.SelectedRows(0).Cells(6).Value

        TextBox22.Text = id_pegawai
        TextBox23.Text = nama
        TextBox25.Text = tempat_lahir
        TextBox26.Text = alamat
        TextBox27.Text = no_telp
    End Sub

    Private Sub DGV_kamar_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_kamar.MouseClick
        disable_input_kamar()
        Dim id_kamar As String = DGV_kamar.SelectedRows(0).Cells(0).Value
        Dim tipe_kamar As String = DGV_kamar.SelectedRows(0).Cells(1).Value
        Dim harga As String = DGV_kamar.SelectedRows(0).Cells(2).Value
        Dim fasilitas As String = DGV_kamar.SelectedRows(0).Cells(3).Value

        TextBox29.Text = id_kamar
        TextBox30.Text = tipe_kamar
        TextBox31.Text = harga
        RichTextBox2.Text = fasilitas
    End Sub

    Private Sub cari_kamar()
        Dim mysqlconn As MySqlConnection
        Dim query As String

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KAMAR Where tipe_kamar='" + TextBox32.Text + "';"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_kamar As DataSet = New DataSet
            data.Fill(ds_kamar, "kamar")
            DGV_kamar.DataSource = ds_kamar.Tables("kamar")
            With DGV_kamar
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Kamar"
                .Columns(1).HeaderText = "Tipe Kamar"
                .Columns(2).HeaderText = "Harga"
                .Columns(3).HeaderText = "Fasilitas"
            End With
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_carikamar_Click(sender As Object, e As EventArgs) Handles btn_carikamar.Click
        cari_kamar()
    End Sub

    Private Sub btn_resetkamar_Click(sender As Object, e As EventArgs) Handles btn_resetkamar.Click
        load_datakamar()
    End Sub

    Private Sub cari_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim query As String

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KONSUMEN where nama like'" + TextBox17.Text + "%';"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_konsumen As DataSet = New DataSet
            data.Fill(ds_konsumen, "konsumen")
            DGV_konsumen.DataSource = ds_konsumen.Tables("konsumen")
            With DGV_konsumen
                .RowHeadersVisible = False
                .Columns(0).HeaderText = "Id Konsumen"
                .Columns(1).HeaderText = "Nama"
                .Columns(2).HeaderText = "Jenis Kelamin"
                .Columns(3).HeaderText = "Tanggal Lahir"
                .Columns(4).HeaderText = "Tempat Lahir"
                .Columns(5).HeaderText = "Alamat"
                .Columns(6).HeaderText = "Kota"
                .Columns(7).HeaderText = "No Telepon"
            End With

            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_carikonsumen_Click(sender As Object, e As EventArgs) Handles btn_carikonsumen.Click
        cari_konsumen()
    End Sub

    Private Sub btn_resetkonsumen_Click(sender As Object, e As EventArgs) Handles btn_resetkonsumen.Click
        load_datakonsumen()
        load_datakonsumen1()
        TextBox17.Text = ""
    End Sub

    Private Sub baca_alldb()
        Dim mysqlconn As New MySqlConnection
        Dim dt As New DataTable
        Dim query As String
        Dim dtsect As Integer
        Dim adapter As MySqlDataAdapter

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=" + TextBox12.Text + ";userid=" + TextBox13.Text + ";password=" + TextBox14.Text + ";"

        Try
            mysqlconn.Open()
            query = "SELECT DISTINCT TABLE_SCHEMA FROM information_schema.TABLES"
            adapter = New MySqlDataAdapter(query, mysqlconn)
            adapter.Fill(dt)
            dtsect = 0

            ComboBox1.Enabled = True
            ComboBox1.Items.Clear()
            ComboBox1.Items.Add("PIlih Database")
            While dtsect < dt.Rows.Count
                ComboBox1.Items.Add(dt.Rows(dtsect)(0).ToString())
                dtsect = dtsect + 1
            End While
            ComboBox1.SelectedIndex = 0
            btn_connect.Enabled = False
            btn_backup.Enabled = True
            btn_restore.Enabled = True
            mysqlconn.Clone()
            dt.Dispose()
            adapter.Dispose()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_connect_Click(sender As Object, e As EventArgs) Handles btn_connect.Click
        baca_alldb()
    End Sub

    Private Sub backup_db()
        Dim dbfile As String
        Dim mysqlconn As MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            SaveFileDialog1.Filter = "Mysql Dump File(*.sql)|*.sql|All files(*.*)|*.*"
            SaveFileDialog1.FileName = "Database Backup " + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".sql"
            If SaveFileDialog1.ShowDialog = DialogResult.OK Then
                mysqlconn.Open()
                dbfile = SaveFileDialog1.FileName
                Dim backupproses As New Process
                backupproses.StartInfo.FileName = "cmd.exe"
                backupproses.StartInfo.UseShellExecute = False
                backupproses.StartInfo.WorkingDirectory = "C:\wamp64\bin\mysql\mysql5.7.19\bin"
                backupproses.StartInfo.RedirectStandardInput = True
                backupproses.StartInfo.RedirectStandardOutput = True
                backupproses.Start()

                Dim backupstream As StreamWriter = backupproses.StandardInput
                Dim mystreamreader As StreamReader = backupproses.StandardOutput
                backupstream.WriteLine("mysqldump --user=" + TextBox13.Text + " --password=" + TextBox14.Text + " -h" + TextBox12.Text + " " + ComboBox1.Text + "> """ + dbfile + """")
                backupstream.Close()
                backupproses.WaitForExit()
                backupproses.Close()
                mysqlconn.Close()
                MessageBox.Show("Backup Database berhasil", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btn_backup_Click(sender As Object, e As EventArgs) Handles btn_backup.Click
        backup_db()
    End Sub

    Private Sub restore_db()
        Dim dbfile As String
        Dim mysqlconn As MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            OpenFileDialog1.Filter = "Mysql Dump File(*.sql)|*.sql|All files(*.*)|*.*"
            If OpenFileDialog1.ShowDialog = DialogResult.OK Then
                mysqlconn.Open()
                dbfile = OpenFileDialog1.FileName
                Dim backupproses As New Process
                backupproses.StartInfo.FileName = "cmd.exe"
                backupproses.StartInfo.UseShellExecute = False
                backupproses.StartInfo.WorkingDirectory = "C:\"
                backupproses.StartInfo.RedirectStandardInput = True
                backupproses.StartInfo.RedirectStandardOutput = True
                backupproses.Start()

                Dim backupstream As StreamWriter = backupproses.StandardInput
                Dim mystreamreader As StreamReader = backupproses.StandardOutput
                backupstream.WriteLine("mysqldump --user=" + TextBox13.Text + " --password=" + TextBox14.Text + " -h" + TextBox12.Text + " " + ComboBox1.Text + "< """ + dbfile + """")
                backupstream.Close()
                backupproses.WaitForExit()
                backupproses.Close()
                mysqlconn.Close()
                MsgBox("Restore Database berhasil", MsgBoxStyle.Information, "Restore Mysql Database")
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btn_restore_Click(sender As Object, e As EventArgs) Handles btn_restore.Click
        restore_db()
    End Sub

    Private Sub btn_tambahreserv_Click(sender As Object, e As EventArgs) Handles btn_tambahreserv.Click
        enable_input_reservasi()
        TextBox1.Focus()
    End Sub

    Private Sub btn_simpanreserv_Click(sender As Object, e As EventArgs) Handles btn_simpanreserv.Click
        If (TextBox1.Text = "") Or (TextBox2.Text = "") Or (TextBox3.Text = "") Or (TextBox4.Text = "") Then
            MessageBox.Show("Silahkan melengkapi data yang masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            simpan_reservasi()
            disable_input_reservasi()
            enable_input_pembayaran()
            TextBox6.Focus()
            TextBox5.Text = TextBox1.Text
            hitung_subtotal()
            If chk_xbed.Checked = True Then
                TextBox8.Text = "125000"
            Else
                TextBox8.Text = "0"
            End If
            TextBox5.Enabled = False
            TextBox8.Enabled = False
            TextBox7.Enabled = False
            TextBox9.Enabled = False
            TextBox11.Enabled = False
        End If
    End Sub

    Private Sub btn_simpanpembayaran_Click(sender As Object, e As EventArgs) Handles btn_simpanpembayaran.Click
        If (TextBox5.Text = "") Or (TextBox6.Text = "") Or (TextBox7.Text = "") Or (TextBox8.Text = "") Or (TextBox9.Text = "") Or (TextBox10.Text = "") Or (TextBox11.Text = "") Then
            MessageBox.Show("Silahkan melengkapi data yang masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            simpan_pembayaran()
            disable_input_reservasi()
            disable_input_pembayaran()
            clear_pembayaran()
            clear_reservasi()
            chk_xbed.Checked = False
        End If
    End Sub

    Private Sub btn_hitung_Click(sender As Object, e As EventArgs) Handles btn_hitung.Click
        Dim subtotal, tambahan, hasil As Integer
        Int32.TryParse(TextBox7.Text, subtotal)
        Int32.TryParse(TextBox8.Text, tambahan)
        hasil = subtotal + tambahan
        TextBox11.Text = hasil
        TextBox10.Focus()
    End Sub

    Private Sub btn_bayar_Click(sender As Object, e As EventArgs) Handles btn_bayar.Click
        Dim bayar, total, hasil As Integer
        If TextBox10.Text = "" Then
            MessageBox.Show("Silahkan melengkapi data pembayaran")
        Else
            Int32.TryParse(TextBox10.Text, bayar)
            Int32.TryParse(TextBox11.Text, total)
            hasil = bayar - total
            TextBox9.Text = hasil
        End If
    End Sub

    Private Sub btn_tambahkonsumen_Click(sender As Object, e As EventArgs) Handles btn_tambahkonsumen.Click
        clear_konsumen()
        enable_input_konsumen()
        TextBox15.Focus()
        stat_btnkonsumen = "Tambahkonsumen"
    End Sub

    Private Sub btn_simpankonsumen_Click(sender As Object, e As EventArgs) Handles btn_simpankonsumen.Click
        If StrComp(stat_btnkonsumen, "Tambahkonsumen", 1) = 0 Then
            If (TextBox15.Text = "") Or (TextBox16.Text = "") Or (TextBox18.Text = "") Or (TextBox19.Text = "") Or (TextBox20.Text = "") Or (TextBox21.Text = "") Then
                MessageBox.Show("Silahkan melengkapi data yang masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                simpan_konsumen()
                disable_input_konsumen()
                clear_konsumen()
            End If
        ElseIf StrComp(stat_btnkonsumen, "Ubahkonsumen", 1) = 0 Then
            ubah_konsumen()
            clear_konsumen()
            disable_input_konsumen()
        End If
    End Sub

    Private Sub btn_batalkonsumen_Click(sender As Object, e As EventArgs) Handles btn_batalkonsumen.Click
        clear_konsumen()
        disable_input_konsumen()
    End Sub

    Private Sub btn_ubahkonsumen_Click(sender As Object, e As EventArgs) Handles btn_ubahkonsumen.Click
        TextBox15.Enabled = False
        enable_input_konsumen()
        stat_btnkonsumen = "Ubahkonsumen"
    End Sub

    Private Sub btn_tambahkamar_Click(sender As Object, e As EventArgs) Handles btn_tambahkamar.Click
        clear_kamar()
        enable_input_kamar()
        TextBox29.Focus()
        stat_btnkamar = "Tambahkamar"
    End Sub

    Private Sub btn_batalkamar_Click(sender As Object, e As EventArgs) Handles btn_batalkamar.Click
        disable_input_kamar()
        clear_kamar()
    End Sub

    Private Sub btn_ubahkamar_Click(sender As Object, e As EventArgs) Handles btn_ubahkamar.Click
        TextBox29.Enabled = False
        enable_input_kamar()
        stat_btnkamar = "Ubahkamar"
    End Sub

    Private Sub btn_hapuskamar_Click(sender As Object, e As EventArgs) Handles btn_hapuskamar.Click
        hapus_kamar()
        clear_kamar()
        disable_input_kamar()
    End Sub

    Private Sub btn_tambahpegawai_Click(sender As Object, e As EventArgs) Handles btn_tambahpegawai.Click
        clear_pegawai()
        enable_input_pegawai()
        TextBox22.Focus()
        stat_btnpegawai = "Tambahpegawai"
    End Sub

    Private Sub btn_simpanpegawai_Click(sender As Object, e As EventArgs) Handles btn_simpanpegawai.Click
        If StrComp(stat_btnpegawai, "Tambahpegawai", 1) = 0 Then
            If (TextBox22.Text = "") Or (TextBox23.Text = "") Or (TextBox25.Text = "") Or (TextBox26.Text = "") Or (TextBox27.Text = "") Or (TextBox28.Text = "") Then
                MessageBox.Show("Silahkan melengkapi data yang masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                simpan_pegawai()
                disable_input_pegawai()
                clear_pegawai()
            End If
        ElseIf StrComp(stat_btnpegawai, "Ubahpegawai", 1) = 0 Then
            ubah_pegawai()
            clear_pegawai()
            disable_input_pegawai()
        End If
    End Sub

    Private Sub btn_batalpegawai_Click(sender As Object, e As EventArgs) Handles btn_batalpegawai.Click
        clear_pegawai()
        disable_input_pegawai()
    End Sub

    Private Sub btn_ubahpegawai_Click(sender As Object, e As EventArgs) Handles btn_ubahpegawai.Click
        TextBox22.Enabled = False
        enable_input_pegawai()
        stat_btnpegawai = "Ubahpegawai"
    End Sub

    Private Sub btn_hapuspegawai_Click(sender As Object, e As EventArgs) Handles btn_hapuspegawai.Click
        hapus_pegawai()
        disable_input_pegawai()
        clear_pegawai()
    End Sub

    Private Sub btn_batalreserv_Click(sender As Object, e As EventArgs) Handles btn_batalreserv.Click
        clear_reservasi()
        disable_input_reservasi()
    End Sub

    Private Sub btn_batalpembayaran_Click(sender As Object, e As EventArgs) Handles btn_batalpembayaran.Click
        clear_pembayaran()
        disable_input_pembayaran()
    End Sub

    Private Sub BunifuThinButton21_Click(sender As Object, e As EventArgs) Handles BunifuThinButton21.Click
        cari_kamar_kosong()
    End Sub

    Private Sub btn_rptreservasi_Click(sender As Object, e As EventArgs) Handles btn_rptreservasi.Click
        rpt_reservasi.ShowDialog()
    End Sub

    Private Sub btn_rptpembayaran_Click(sender As Object, e As EventArgs) Handles btn_rptpembayaran.Click
        rpt_pembayaran.ShowDialog()
    End Sub

    Private Sub btn_rptkonsumen_Click(sender As Object, e As EventArgs) Handles btn_rptkonsumen.Click
        rpt_konsumen.ShowDialog()
    End Sub

    Private Sub btn_simpankamar_Click(sender As Object, e As EventArgs) Handles btn_simpankamar.Click
        If StrComp(stat_btnkamar, "Tambahkamar", 1) = 0 Then
            If (TextBox29.Text = "") Or (TextBox30.Text = "") Or (TextBox31.Text = "") Or (RichTextBox2.Text = "") Then
                MessageBox.Show("Silahkan melengkapi data yang masih kosong", "Pemberitahuan", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                simpan_kamar()
                disable_input_kamar()
                clear_kamar()
            End If
        ElseIf StrComp(stat_btnkamar, "Ubahkamar", 1) = 0 Then
            ubah_kamar()
            clear_kamar()
            disable_input_kamar()
        End If
    End Sub

    Private Sub btn_hapuskonsumen_Click(sender As Object, e As EventArgs) Handles btn_hapuskonsumen.Click
        hapus_konsumen()
        disable_input_konsumen()
        clear_konsumen()
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
End Class