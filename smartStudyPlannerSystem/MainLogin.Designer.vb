<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")> _
Partial Class MainLogin
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
    Friend WithEvents UsernameLabel As System.Windows.Forms.Label
    Friend WithEvents UsernameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PasswordTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OK As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainLogin))
        UsernameLabel = New Label()
        UsernameTextBox = New TextBox()
        PasswordTextBox = New TextBox()
        OK = New Button()
        Label1 = New Label()
        Button1 = New Button()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Panel2 = New Panel()
        Label3 = New Label()
        Label2 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        Panel3 = New Panel()
        CheckBoxShowPassword = New CheckBox()
        Login = New Button()
        Register = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' UsernameLabel
        ' 
        UsernameLabel.Font = New Font("Lucida Console", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        UsernameLabel.ForeColor = Color.Transparent
        UsernameLabel.Location = New Point(359, 265)
        UsernameLabel.Name = "UsernameLabel"
        UsernameLabel.Size = New Size(117, 23)
        UsernameLabel.TabIndex = 0
        UsernameLabel.Text = "Username"
        UsernameLabel.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' UsernameTextBox
        ' 
        UsernameTextBox.Location = New Point(359, 291)
        UsernameTextBox.Name = "UsernameTextBox"
        UsernameTextBox.Size = New Size(263, 23)
        UsernameTextBox.TabIndex = 1
        ' 
        ' PasswordTextBox
        ' 
        PasswordTextBox.Location = New Point(359, 336)
        PasswordTextBox.Name = "PasswordTextBox"
        PasswordTextBox.PasswordChar = "*"c
        PasswordTextBox.Size = New Size(263, 23)
        PasswordTextBox.TabIndex = 3
        ' 
        ' OK
        ' 
        OK.BackColor = Color.GhostWhite
        OK.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        OK.ForeColor = Color.MidnightBlue
        OK.Location = New Point(359, 403)
        OK.Name = "OK"
        OK.Size = New Size(129, 51)
        OK.TabIndex = 4
        OK.Text = "&OK"
        OK.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Lucida Console", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.Transparent
        Label1.Location = New Point(359, 362)
        Label1.Name = "Label1"
        Label1.Size = New Size(118, 23)
        Label1.TabIndex = 0
        Label1.Text = "Password"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.MidnightBlue
        Button1.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.GhostWhite
        Button1.Location = New Point(494, 403)
        Button1.Name = "Button1"
        Button1.Size = New Size(128, 51)
        Button1.TabIndex = 4
        Button1.Text = "CANCEL"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Center
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1169, 637)
        Panel1.TabIndex = 5
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.SYNDTASK_LOGO2
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(359, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(423, 262)
        PictureBox1.TabIndex = 6
        PictureBox1.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Lavender
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(TextBox1)
        Panel2.Controls.Add(TextBox2)
        Panel2.Controls.Add(Panel3)
        Panel2.Location = New Point(403, 240)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(350, 312)
        Panel2.TabIndex = 8
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Lavender
        Label3.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.MidnightBlue
        Label3.Location = New Point(49, 107)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 35)
        Label3.TabIndex = 4
        Label3.Text = "Password"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Lavender
        Label2.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.MidnightBlue
        Label2.Location = New Point(50, 21)
        Label2.Name = "Label2"
        Label2.Size = New Size(214, 35)
        Label2.TabIndex = 4
        Label2.Text = "I.D no. or Username"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Cursor = Cursors.IBeam
        TextBox1.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.ForeColor = Color.MidnightBlue
        TextBox1.Location = New Point(30, 144)
        TextBox1.Name = "TextBox1"
        TextBox1.PasswordChar = "*"c
        TextBox1.Size = New Size(283, 35)
        TextBox1.TabIndex = 2
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.White
        TextBox2.BorderStyle = BorderStyle.FixedSingle
        TextBox2.Cursor = Cursors.IBeam
        TextBox2.Font = New Font("Microsoft Sans Serif", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.ForeColor = Color.MidnightBlue
        TextBox2.Location = New Point(30, 59)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(283, 35)
        TextBox2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Transparent
        Panel3.Controls.Add(CheckBoxShowPassword)
        Panel3.Controls.Add(Login)
        Panel3.Controls.Add(Register)
        Panel3.Location = New Point(-1, -1)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(350, 312)
        Panel3.TabIndex = 8
        ' 
        ' CheckBoxShowPassword
        ' 
        CheckBoxShowPassword.AutoSize = True
        CheckBoxShowPassword.Font = New Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBoxShowPassword.ForeColor = Color.MidnightBlue
        CheckBoxShowPassword.Location = New Point(50, 193)
        CheckBoxShowPassword.Name = "CheckBoxShowPassword"
        CheckBoxShowPassword.Size = New Size(126, 21)
        CheckBoxShowPassword.TabIndex = 3
        CheckBoxShowPassword.Text = "Show Password"
        CheckBoxShowPassword.UseVisualStyleBackColor = True
        ' 
        ' Login
        ' 
        Login.AllowDrop = True
        Login.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Login.ForeColor = Color.MidnightBlue
        Login.Location = New Point(51, 236)
        Login.Name = "Login"
        Login.Size = New Size(114, 47)
        Login.TabIndex = 4
        Login.Text = "LOG IN"
        Login.UseVisualStyleBackColor = True
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.MidnightBlue
        Register.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.GhostWhite
        Register.Location = New Point(187, 236)
        Register.Name = "Register"
        Register.Size = New Size(115, 47)
        Register.TabIndex = 5
        Register.Text = "BACK"
        Register.UseVisualStyleBackColor = False
        ' 
        ' MainLogin
        ' 
        AcceptButton = OK
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.CornflowerBlue
        ClientSize = New Size(1169, 637)
        Controls.Add(Panel1)
        Controls.Add(Button1)
        Controls.Add(OK)
        Controls.Add(PasswordTextBox)
        Controls.Add(UsernameTextBox)
        Controls.Add(Label1)
        Controls.Add(UsernameLabel)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(800, 600)
        Name = "MainLogin"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterParent
        Text = "Login"
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Login As Button
    Friend WithEvents Register As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents CheckBoxShowPassword As CheckBox

End Class
