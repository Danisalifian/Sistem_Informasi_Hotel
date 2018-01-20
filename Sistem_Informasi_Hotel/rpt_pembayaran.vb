Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class rpt_pembayaran
    Private Sub rpt_pembayaran_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
        tampil_pembayaran()
    End Sub

    Private Sub tampil_pembayaran()
        Dim mysqlconn As MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
        Dim adapter As New MySqlDataAdapter
        Dim ds As New DataSet_Hotel
        adapter.SelectCommand = New MySqlCommand("select * from pembayaran", mysqlconn)
        adapter.Fill(ds.Tables(0))
        rpvw_pembayaran.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        rpvw_pembayaran.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\rpt_pembayaran.rdlc"
        rpvw_pembayaran.LocalReport.DataSources.Clear()
        rpvw_pembayaran.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet_pembayaran", ds.Tables(0)))
        rpvw_pembayaran.DocumentMapCollapsed = True
        Me.rpvw_pembayaran.RefreshReport()
    End Sub
End Class