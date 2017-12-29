<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.btncekdb = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.label = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btntutup = New Bunifu.Framework.UI.BunifuFlatButton()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnmasuk = New Bunifu.Framework.UI.BunifuThinButton2()
        Me.txtuname = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.txtpass = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btncekdb
        '
        Me.btncekdb.Activecolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btncekdb.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btncekdb.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btncekdb.BorderRadius = 0
        Me.btncekdb.ButtonText = "Tes koneksi ke Database"
        Me.btncekdb.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btncekdb.DisabledColor = System.Drawing.Color.Gray
        Me.btncekdb.Iconcolor = System.Drawing.Color.Transparent
        Me.btncekdb.Iconimage = Nothing
        Me.btncekdb.Iconimage_right = Nothing
        Me.btncekdb.Iconimage_right_Selected = Nothing
        Me.btncekdb.Iconimage_Selected = Nothing
        Me.btncekdb.IconMarginLeft = 0
        Me.btncekdb.IconMarginRight = 0
        Me.btncekdb.IconRightVisible = True
        Me.btncekdb.IconRightZoom = 0R
        Me.btncekdb.IconVisible = True
        Me.btncekdb.IconZoom = 90.0R
        Me.btncekdb.IsTab = False
        Me.btncekdb.Location = New System.Drawing.Point(53, 426)
        Me.btncekdb.Name = "btncekdb"
        Me.btncekdb.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btncekdb.OnHovercolor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btncekdb.OnHoverTextColor = System.Drawing.Color.White
        Me.btncekdb.selected = False
        Me.btncekdb.Size = New System.Drawing.Size(224, 48)
        Me.btncekdb.TabIndex = 6
        Me.btncekdb.Text = "Tes koneksi ke Database"
        Me.btncekdb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btncekdb.Textcolor = System.Drawing.Color.White
        Me.btncekdb.TextFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'label
        '
        Me.label.AutoSize = True
        Me.label.Font = New System.Drawing.Font("Century Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label.ForeColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(70, Byte), Integer), CType(CType(99, Byte), Integer))
        Me.label.Location = New System.Drawing.Point(12, 27)
        Me.label.Name = "label"
        Me.label.Size = New System.Drawing.Size(77, 30)
        Me.label.TabIndex = 8
        Me.label.Text = "Login"
        Me.label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btntutup)
        Me.Panel1.Location = New System.Drawing.Point(0, -1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 23)
        Me.Panel1.TabIndex = 10
        '
        'btntutup
        '
        Me.btntutup.Activecolor = System.Drawing.Color.FromArgb(CType(CType(46, Byte), Integer), CType(CType(139, Byte), Integer), CType(CType(87, Byte), Integer))
        Me.btntutup.BackColor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btntutup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btntutup.BorderRadius = 0
        Me.btntutup.ButtonText = "Tutup"
        Me.btntutup.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btntutup.DisabledColor = System.Drawing.Color.Gray
        Me.btntutup.Iconcolor = System.Drawing.Color.Transparent
        Me.btntutup.Iconimage = Nothing
        Me.btntutup.Iconimage_right = Nothing
        Me.btntutup.Iconimage_right_Selected = Nothing
        Me.btntutup.Iconimage_Selected = Nothing
        Me.btntutup.IconMarginLeft = 0
        Me.btntutup.IconMarginRight = 0
        Me.btntutup.IconRightVisible = True
        Me.btntutup.IconRightZoom = 0R
        Me.btntutup.IconVisible = True
        Me.btntutup.IconZoom = 90.0R
        Me.btntutup.IsTab = False
        Me.btntutup.Location = New System.Drawing.Point(282, 1)
        Me.btntutup.Name = "btntutup"
        Me.btntutup.Normalcolor = System.Drawing.Color.FromArgb(CType(CType(48, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(159, Byte), Integer))
        Me.btntutup.OnHovercolor = System.Drawing.Color.Red
        Me.btntutup.OnHoverTextColor = System.Drawing.Color.White
        Me.btntutup.selected = False
        Me.btntutup.Size = New System.Drawing.Size(50, 23)
        Me.btntutup.TabIndex = 11
        Me.btntutup.Text = "Tutup"
        Me.btntutup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btntutup.Textcolor = System.Drawing.Color.White
        Me.btntutup.TextFont = New System.Drawing.Font("Century Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(78, 75)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(176, 172)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'btnmasuk
        '
        Me.btnmasuk.ActiveBorderThickness = 1
        Me.btnmasuk.ActiveCornerRadius = 20
        Me.btnmasuk.ActiveFillColor = System.Drawing.Color.FromArgb(CType(CType(66, Byte), Integer), CType(CType(133, Byte), Integer), CType(CType(244, Byte), Integer))
        Me.btnmasuk.ActiveForecolor = System.Drawing.Color.White
        Me.btnmasuk.ActiveLineColor = System.Drawing.Color.White
        Me.btnmasuk.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.btnmasuk.BackgroundImage = CType(resources.GetObject("btnmasuk.BackgroundImage"), System.Drawing.Image)
        Me.btnmasuk.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnmasuk.ButtonText = "Masuk"
        Me.btnmasuk.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnmasuk.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnmasuk.ForeColor = System.Drawing.Color.White
        Me.btnmasuk.IdleBorderThickness = 1
        Me.btnmasuk.IdleCornerRadius = 20
        Me.btnmasuk.IdleFillColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(204, Byte), Integer))
        Me.btnmasuk.IdleForecolor = System.Drawing.Color.White
        Me.btnmasuk.IdleLineColor = System.Drawing.Color.White
        Me.btnmasuk.Location = New System.Drawing.Point(73, 377)
        Me.btnmasuk.Margin = New System.Windows.Forms.Padding(5)
        Me.btnmasuk.Name = "btnmasuk"
        Me.btnmasuk.Size = New System.Drawing.Size(181, 41)
        Me.btnmasuk.TabIndex = 5
        Me.btnmasuk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtuname
        '
        Me.txtuname.Depth = 0
        Me.txtuname.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtuname.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.txtuname.Hint = "Username"
        Me.txtuname.Location = New System.Drawing.Point(53, 278)
        Me.txtuname.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtuname.Name = "txtuname"
        Me.txtuname.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtuname.SelectedText = ""
        Me.txtuname.SelectionLength = 0
        Me.txtuname.SelectionStart = 0
        Me.txtuname.Size = New System.Drawing.Size(223, 23)
        Me.txtuname.TabIndex = 15
        Me.txtuname.UseSystemPasswordChar = False
        '
        'txtpass
        '
        Me.txtpass.Depth = 0
        Me.txtpass.Font = New System.Drawing.Font("Century Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpass.ForeColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(44, Byte), Integer))
        Me.txtpass.Hint = "Password"
        Me.txtpass.Location = New System.Drawing.Point(52, 334)
        Me.txtpass.MouseState = MaterialSkin.MouseState.HOVER
        Me.txtpass.Name = "txtpass"
        Me.txtpass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.txtpass.SelectedText = ""
        Me.txtpass.SelectionLength = 0
        Me.txtpass.SelectionStart = 0
        Me.txtpass.Size = New System.Drawing.Size(223, 23)
        Me.txtpass.TabIndex = 16
        Me.txtpass.UseSystemPasswordChar = True
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(331, 485)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtuname)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.label)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.btncekdb)
        Me.Controls.Add(Me.btnmasuk)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Login"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnmasuk As Bunifu.Framework.UI.BunifuThinButton2
    Friend WithEvents btncekdb As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents label As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btntutup As Bunifu.Framework.UI.BunifuFlatButton
    Friend WithEvents txtuname As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents txtpass As MaterialSkin.Controls.MaterialSingleLineTextField
End Class
