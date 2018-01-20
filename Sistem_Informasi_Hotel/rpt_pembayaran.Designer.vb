<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rpt_pembayaran
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rpvw_pembayaran = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvw_pembayaran
        '
        Me.rpvw_pembayaran.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpvw_pembayaran.Location = New System.Drawing.Point(0, 0)
        Me.rpvw_pembayaran.Name = "rpvw_pembayaran"
        Me.rpvw_pembayaran.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rpvw_pembayaran.Size = New System.Drawing.Size(784, 411)
        Me.rpvw_pembayaran.TabIndex = 0
        '
        'rpt_pembayaran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.rpvw_pembayaran)
        Me.Name = "rpt_pembayaran"
        Me.Text = "rpt_pembayaran"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvw_pembayaran As Microsoft.Reporting.WinForms.ReportViewer
End Class
