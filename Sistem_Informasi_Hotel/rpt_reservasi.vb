Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class rpt_reservasi
    Private Sub rpt_reservasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.rpvw_reservasi.RefreshReport()
        tampil_reservasi()
    End Sub

    Private Sub tampil_reservasi()
        Dim mysqlconn As MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
        Dim adapter As New MySqlDataAdapter
        Dim ds As New DataSet_Hotel
        adapter.SelectCommand = New MySqlCommand("select * from reservasi", mysqlconn)
        adapter.Fill(ds.Tables(0))
        rpvw_reservasi.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        rpvw_reservasi.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\rpt_reservasi.rdlc"
        rpvw_reservasi.LocalReport.DataSources.Clear()
        rpvw_reservasi.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet_reservasi", ds.Tables(0)))
        rpvw_reservasi.DocumentMapCollapsed = True
        Me.rpvw_reservasi.RefreshReport()
    End Sub
End Class