<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
    'Inherits System.Windows.Forms.Form
    Inherits MaterialSkin.Controls.MaterialForm

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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.txtuname = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.txtpass = New MaterialSkin.Controls.MaterialSingleLineTextField()
        Me.MaterialRaisedButton1 = New MaterialSkin.Controls.MaterialRaisedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        'MaterialRaisedButton1
        '
        Me.MaterialRaisedButton1.Depth = 0
        Me.MaterialRaisedButton1.Location = New System.Drawing.Point(53, 390)
        Me.MaterialRaisedButton1.MouseState = MaterialSkin.MouseState.HOVER
        Me.MaterialRaisedButton1.Name = "MaterialRaisedButton1"
        Me.MaterialRaisedButton1.Primary = True
        Me.MaterialRaisedButton1.Size = New System.Drawing.Size(222, 45)
        Me.MaterialRaisedButton1.TabIndex = 18
        Me.MaterialRaisedButton1.Text = "Masuk"
        Me.MaterialRaisedButton1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Roboto", 13.0!)
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(91, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 23)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Sang Surya Hotel"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(0, 23)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(331, 46)
        Me.Panel1.TabIndex = 20
        '
        'Login
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(247, Byte), Integer), CType(CType(248, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(331, 457)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MaterialRaisedButton1)
        Me.Controls.Add(Me.txtpass)
        Me.Controls.Add(Me.txtuname)
        Me.Controls.Add(Me.PictureBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents txtuname As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents txtpass As MaterialSkin.Controls.MaterialSingleLineTextField
    Friend WithEvents MaterialRaisedButton1 As MaterialSkin.Controls.MaterialRaisedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
End Class
