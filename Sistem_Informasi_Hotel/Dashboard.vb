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
        SkinManager.ColorScheme = New ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE)
        list_pegawai()
        list_kamar()
        list_konsumen()
        disable_input_konsumen()
        'load_datapegawai()
        load_datakonsumen()
        DGV_konsumen.SelectionMode = DataGridViewSelectionMode.FullRowSelect
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
                list_konsumen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
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

    Private Sub btnsimpankonsumen_Click(sender As Object, e As EventArgs) Handles btnsimpankonsumen.Click
        simpan_konsumen()
        clear_konsumen()
        disable_input_konsumen()
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
                'load_datapegawai()
                list_pegawai()
            End If
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
    '    Dim query As String

    '    mysqlconn = New MySqlConnection
    '    mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

    '    Try
    '        mysqlconn.Open()
    '        query = "SELECT * FROM PEGAWAI"
    '        Dim data As New MySqlDataAdapter(query, mysqlconn)
    '        Dim ds_pegawai As DataSet = New DataSet
    '        data.Fill(ds_pegawai, "pegawai")
    '        DGV_pegawai.DataSource = ds_pegawai.Tables("pegawai")
    '        mysqlconn.Close()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '        mysqlconn.Dispose()
    '    End Try
    'End Sub

    Private Sub load_datakonsumen()
        Dim mysqlconn As MySqlConnection
        Dim query As String
        'DGV_konsumen.Rows.Clear()

        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KONSUMEN"
            Dim data As New MySqlDataAdapter(query, mysqlconn)
            Dim ds_konsumen As DataSet = New DataSet
            data.Fill(ds_konsumen, "konsumen")
            DGV_konsumen.DataSource = ds_konsumen.Tables("konsumen")
            With DGV_konsumen
                .RowHeadersVisible = False
                '.Columns(0).HeaderText = "Pilih"
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
            MessageBox.Show(ex.Message)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub list_konsumen()
        Dim mysqlconn As MySqlConnection
        Dim query As String
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        lvkonsumen.Items.Clear()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KONSUMEN"

            With cmd
                .CommandText = query
                .Connection = mysqlconn
            End With

            With adapter
                .SelectCommand = cmd
                .Fill(TABLE)
            End With

            For i = 0 To TABLE.Rows.Count - 1
                With lvkonsumen
                    .Items.Add(TABLE.Rows(i)("id_konsumen"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(TABLE.Rows(i)("nama"))
                        .Add(TABLE.Rows(i)("j_kelamin"))
                        .Add(TABLE.Rows(i)("tgl_lahir"))
                        .Add(TABLE.Rows(i)("tempat_lahir"))
                        .Add(TABLE.Rows(i)("alamat"))
                        .Add(TABLE.Rows(i)("kota"))
                        .Add(TABLE.Rows(i)("no_telp"))
                    End With
                End With
            Next
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub list_kamar()
        Dim mysqlconn As MySqlConnection
        Dim query As String
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        lvkamar.Items.Clear()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"

        Try
            mysqlconn.Open()
            query = "SELECT * FROM KAMAR"

            With cmd
                .CommandText = query
                .Connection = mysqlconn
            End With

            With adapter
                .SelectCommand = cmd
                .Fill(TABLE)
            End With

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
            mysqlconn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub list_pegawai()
        Dim mysqlconn As New MySqlConnection
        Dim query As String '= "SELECT * FROM PEGAWAI"
        Dim adapter As New MySqlDataAdapter
        Dim cmd As New MySqlCommand
        Dim TABLE As New DataTable
        Dim i As Integer

        lvpegawai.Items.Clear()
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
        Try
            mysqlconn.Open()
            query = "SELECT * FROM PEGAWAI"

            With cmd
                .CommandText = query
                .Connection = mysqlconn
            End With

            With adapter
                .SelectCommand = cmd
                .Fill(TABLE)
            End With

            For i = 0 To TABLE.Rows.Count - 1
                With lvpegawai
                    .Items.Add(TABLE.Rows(i)("id_pegawai"))
                    With .Items(.Items.Count - 1).SubItems
                        .Add(TABLE.Rows(i)("nama"))
                        .Add(TABLE.Rows(i)("j_kelamin"))
                        .Add(TABLE.Rows(i)("tgl_lahir"))
                        .Add(TABLE.Rows(i)("tempat_lahir"))
                        .Add(TABLE.Rows(i)("alamat"))
                        .Add(TABLE.Rows(i)("no_telp"))
                        '.Add(TABLE.Rows(i)("pass"))
                    End With
                End With
            Next
            'TABLE.Rows.Clear()
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
                list_kamar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
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

    Private Sub btn_tambahkonsumen_Click(sender As Object, e As EventArgs) Handles btn_tambahkonsumen.Click
        enable_input_konsumen()
        TextBox15.Focus()
    End Sub

    Private Sub btn_batalkonsumen_Click(sender As Object, e As EventArgs) Handles btn_batalkonsumen.Click
        clear_konsumen()
        disable_input_konsumen()
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
                list_konsumen()
                Me.bindgrid()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_hapuskonsumen_Click(sender As Object, e As EventArgs) Handles btn_hapuskonsumen.Click
        hapus_konsumen()
    End Sub

    Private Sub lvkonsumen_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvkonsumen.SelectedIndexChanged
        Dim index As Integer
        If lvkonsumen.SelectedItems.Count = 0 Then Exit Sub
        With lvkonsumen
            index = .SelectedIndices(0)
            TextBox15.Text = .Items(index).Text
            TextBox16.Text = .Items(index).SubItems(1).Text
            TextBox18.Text = .Items(index).SubItems(4).Text
            TextBox19.Text = .Items(index).SubItems(5).Text
            TextBox20.Text = .Items(index).SubItems(6).Text
            TextBox21.Text = .Items(index).SubItems(7).Text
        End With
    End Sub

    Private Sub bindgrid()
        'Dim mysqlconn As MySqlConnection

        DGV_konsumen.DataSource = Nothing
        Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
            Using cmd As New MySqlCommand("Select * from konsumen", mysqlconn)
                cmd.CommandType = CommandType.Text
                Using sda As New MySqlDataAdapter(cmd)
                    Using dt As New DataTable()
                        sda.Fill(dt)
                        DGV_konsumen.DataSource = dt
                    End Using
                End Using
            End Using
        End Using
    End Sub

    Private Sub multi_hapus()
        'Dim selectedRows As List(Of DataGridViewRow) = (From row In DGV_konsumen.Rows.Cast(Of DataGridViewRow)()
        'Where Convert.ToBoolean(row.Cells("column1").Value) = True).ToList()

        'For Each row As DataGridViewRow In selectedRows
        '    Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
        '        Using cmd As New MySqlCommand("delete from konsumen where id_konsumen = @id_konsumen", mysqlconn)
        '            cmd.CommandType = CommandType.Text
        '            cmd.Parameters.AddWithValue("@id_konsumen", row.Cells("id_konsumen").Value)
        '            mysqlconn.Open()
        '            cmd.ExecuteNonQuery()
        '            mysqlconn.Close()
        '        End Using
        '    End Using
        'Next
        Dim i As Integer
        For i = DGV_konsumen.Rows.Count - 1 To 0 Step -1
            Dim ceklis As Boolean
            ceklis = DGV_konsumen.Rows(i).Cells(0).Value
            If ceklis = True Then
                Dim row As DataGridViewRow
                row = DGV_konsumen.Rows(i)
                Using mysqlconn As New MySqlConnection("server=Localhost;userid=root;password= ;database=db_hotel")
                    Using cmd As New MySqlCommand("delete from konsumen where id_konsumen = @id_konsumen", mysqlconn)
                        cmd.CommandType = CommandType.Text
                        cmd.Parameters.AddWithValue("@id_konsumen", row.Cells(1).Value)
                        mysqlconn.Open()
                        cmd.ExecuteNonQuery()
                        mysqlconn.Close()
                    End Using
                End Using
                'MessageBox.Show(DGV_konsumen.Rows.Add(row.Cells("id_konsumen")))
            End If
        Next
        Me.load_datakonsumen()
    End Sub

    Private Sub BunifuThinButton23_Click(sender As Object, e As EventArgs) Handles BunifuThinButton23.Click
        multi_hapus()
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
                list_konsumen()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_ubahkonsumen_Click(sender As Object, e As EventArgs) Handles btn_ubahkonsumen.Click
        ubah_konsumen()
    End Sub

    Private Sub lvpegawai_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvpegawai.SelectedIndexChanged
        Dim index As Integer
        If lvpegawai.SelectedItems.Count = 0 Then Exit Sub
        With lvpegawai
            index = .SelectedIndices(0)
            TextBox22.Text = .Items(index).Text
            TextBox23.Text = .Items(index).SubItems(1).Text
            TextBox25.Text = .Items(index).SubItems(4).Text
            TextBox26.Text = .Items(index).SubItems(5).Text
            TextBox27.Text = .Items(index).SubItems(6).Text
        End With
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
                list_pegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_hapuspegawai_Click(sender As Object, e As EventArgs) Handles btn_hapuspegawai.Click
        hapus_pegawai()
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
                list_pegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_ubahpegawai_Click(sender As Object, e As EventArgs) Handles btn_ubahpegawai.Click
        ubah_pegawai()
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
                list_kamar()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_ubahkamar_Click(sender As Object, e As EventArgs) Handles btn_ubahkamar.Click
        ubah_kamar()
    End Sub

    Private Sub lvkamar_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lvkamar.SelectedIndexChanged
        Dim index As Integer
        If lvkamar.SelectedItems.Count = 0 Then Exit Sub
        With lvkamar
            index = .SelectedIndices(0)
            TextBox29.Text = .Items(index).Text
            TextBox30.Text = .Items(index).SubItems(1).Text
            TextBox31.Text = .Items(index).SubItems(2).Text
            RichTextBox2.Text = .Items(index).SubItems(3).Text
        End With
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
                list_pegawai()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            mysqlconn.Dispose()
        End Try
    End Sub

    Private Sub btn_hapuskamar_Click(sender As Object, e As EventArgs) Handles btn_hapuskamar.Click
        hapus_kamar()
    End Sub

    Private Sub DGV_konsumen_MouseClick(sender As Object, e As MouseEventArgs) Handles DGV_konsumen.MouseClick
        Dim id_kamar As String = DGV_konsumen.SelectedRows(0).Cells(0).Value

        TextBox15.Text = id_kamar

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