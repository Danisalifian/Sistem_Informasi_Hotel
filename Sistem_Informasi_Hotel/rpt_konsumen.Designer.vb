<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class rpt_konsumen
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
        Me.rpvw_konsumen = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.SuspendLayout()
        '
        'rpvw_konsumen
        '
        Me.rpvw_konsumen.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rpvw_konsumen.Location = New System.Drawing.Point(0, 0)
        Me.rpvw_konsumen.Name = "rpvw_konsumen"
        Me.rpvw_konsumen.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Remote
        Me.rpvw_konsumen.Size = New System.Drawing.Size(784, 411)
        Me.rpvw_konsumen.TabIndex = 0
        '
        'rpt_konsumen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 411)
        Me.Controls.Add(Me.rpvw_konsumen)
        Me.MaximizeBox = False
        Me.Name = "rpt_konsumen"
        Me.Text = "rpt_konsumen"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents rpvw_konsumen As Microsoft.Reporting.WinForms.ReportViewer
End Class
