Imports MySql.Data.MySqlClient
Imports Microsoft.Reporting.WinForms
Public Class rpt_konsumen
    Private Sub rpt_konsumen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Me.ReportViewer1.RefreshReport()
        tampil_konsumen()
    End Sub

    Private Sub tampil_konsumen()
        Dim mysqlconn As MySqlConnection
        mysqlconn = New MySqlConnection
        mysqlconn.ConnectionString = "server=Localhost;userid=root;password= ;database=db_hotel"
        Dim adapter As New MySqlDataAdapter
        Dim ds As New DataSet_Hotel
        adapter.SelectCommand = New MySqlCommand("select * from konsumen", mysqlconn)
        adapter.Fill(ds.Tables(0))
        rpvw_konsumen.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local
        rpvw_konsumen.LocalReport.ReportPath = System.Environment.CurrentDirectory & "\rpt_konsumen.rdlc"
        rpvw_konsumen.LocalReport.DataSources.Clear()
        rpvw_konsumen.LocalReport.DataSources.Add(New Microsoft.Reporting.WinForms.ReportDataSource("DataSet_konsumen", ds.Tables(0)))
        rpvw_konsumen.DocumentMapCollapsed = True
        Me.rpvw_konsumen.RefreshReport()
    End Sub
End Class