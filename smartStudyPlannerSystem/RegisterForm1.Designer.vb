<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
<Global.System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726")>
Partial Class RegisterForm1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegisterForm1))
        TextBox2 = New TextBox()
        Label3 = New Label()
        Label2 = New Label()
        Panel2 = New Panel()
        TextBox1 = New TextBox()
        Register = New Button()
        Login = New Button()
        Panel1 = New Panel()
        Panel3 = New Panel()
        Panel4 = New Panel()
        RadioButton5 = New RadioButton()
        RadioButton4 = New RadioButton()
        Label8 = New Label()
        Label7 = New Label()
        Label1 = New Label()
        TextBox4 = New TextBox()
        TextBox5 = New TextBox()
        TextBox3 = New TextBox()
        TextBox8 = New TextBox()
        TextBox7 = New TextBox()
        Label6 = New Label()
        Label5 = New Label()
        Button1 = New Button()
        Label4 = New Label()
        Button2 = New Button()
        CheckBoxShowPassword = New CheckBox()
        Panel2.SuspendLayout()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        SuspendLayout()
        ' 
        ' TextBox2
        ' 
        TextBox2.BackColor = Color.White
        TextBox2.Cursor = Cursors.IBeam
        TextBox2.ForeColor = Color.Black
        TextBox2.Location = New Point(335, 245)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(283, 23)
        TextBox2.TabIndex = 11
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.Lavender
        Label3.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.MidnightBlue
        Label3.Location = New Point(355, 304)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 35)
        Label3.TabIndex = 9
        Label3.Text = "Password"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.BackColor = Color.Lavender
        Label2.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.MidnightBlue
        Label2.Location = New Point(355, 207)
        Label2.Name = "Label2"
        Label2.Size = New Size(100, 35)
        Label2.TabIndex = 10
        Label2.Text = "Username"
        Label2.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Lavender
        Panel2.Controls.Add(TextBox1)
        Panel2.Controls.Add(Register)
        Panel2.Controls.Add(Login)
        Panel2.Location = New Point(312, 123)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(333, 396)
        Panel2.TabIndex = 12
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.Cursor = Cursors.IBeam
        TextBox1.ForeColor = Color.Black
        TextBox1.Location = New Point(23, 219)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(283, 23)
        TextBox1.TabIndex = 5
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.MidnightBlue
        Register.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.GhostWhite
        Register.Location = New Point(167, 271)
        Register.Name = "Register"
        Register.Size = New Size(115, 47)
        Register.TabIndex = 0
        Register.Text = "CANCEL"
        Register.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        Login.AllowDrop = True
        Login.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Login.ForeColor = Color.MidnightBlue
        Login.Location = New Point(46, 271)
        Login.Name = "Login"
        Login.Size = New Size(114, 47)
        Login.TabIndex = 0
        Login.Text = "LOG IN"
        Login.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImage = CType(resources.GetObject("Panel1.BackgroundImage"), Image)
        Panel1.BackgroundImageLayout = ImageLayout.Center
        Panel1.Controls.Add(Panel3)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1165, 642)
        Panel1.TabIndex = 13
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Lavender
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(TextBox4)
        Panel3.Controls.Add(TextBox5)
        Panel3.Controls.Add(TextBox3)
        Panel3.Controls.Add(TextBox8)
        Panel3.Controls.Add(TextBox7)
        Panel3.Controls.Add(Label6)
        Panel3.Controls.Add(Label5)
        Panel3.Controls.Add(Button1)
        Panel3.Controls.Add(Label4)
        Panel3.Controls.Add(Button2)
        Panel3.Controls.Add(CheckBoxShowPassword)
        Panel3.Location = New Point(206, 123)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(760, 429)
        Panel3.TabIndex = 8
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.White
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(RadioButton5)
        Panel4.Controls.Add(RadioButton4)
        Panel4.Location = New Point(377, 79)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(283, 39)
        Panel4.TabIndex = 4
        ' 
        ' RadioButton5
        ' 
        RadioButton5.AutoSize = True
        RadioButton5.BackColor = Color.White
        RadioButton5.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RadioButton5.ForeColor = Color.MidnightBlue
        RadioButton5.Location = New Point(162, 3)
        RadioButton5.Name = "RadioButton5"
        RadioButton5.Size = New Size(80, 24)
        RadioButton5.TabIndex = 6
        RadioButton5.TabStop = True
        RadioButton5.Text = "Female"
        RadioButton5.TextAlign = ContentAlignment.MiddleCenter
        RadioButton5.UseVisualStyleBackColor = False
        ' 
        ' RadioButton4
        ' 
        RadioButton4.AutoSize = True
        RadioButton4.BackColor = Color.White
        RadioButton4.Font = New Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RadioButton4.ForeColor = Color.MidnightBlue
        RadioButton4.Location = New Point(36, 3)
        RadioButton4.Name = "RadioButton4"
        RadioButton4.Size = New Size(61, 24)
        RadioButton4.TabIndex = 5
        RadioButton4.TabStop = True
        RadioButton4.Text = "Male"
        RadioButton4.TextAlign = ContentAlignment.MiddleCenter
        RadioButton4.UseVisualStyleBackColor = False
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.Lavender
        Label8.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label8.ForeColor = Color.MidnightBlue
        Label8.Location = New Point(377, 216)
        Label8.Name = "Label8"
        Label8.Size = New Size(100, 35)
        Label8.TabIndex = 4
        Label8.Text = "Password"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label7
        ' 
        Label7.BackColor = Color.Lavender
        Label7.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.MidnightBlue
        Label7.Location = New Point(78, 216)
        Label7.Name = "Label7"
        Label7.Size = New Size(183, 35)
        Label7.TabIndex = 4
        Label7.Text = "I.D no. or Username"
        Label7.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.Lavender
        Label1.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.MidnightBlue
        Label1.Location = New Point(377, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(79, 35)
        Label1.TabIndex = 4
        Label1.Text = "Gender"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' TextBox4
        ' 
        TextBox4.BackColor = Color.White
        TextBox4.BorderStyle = BorderStyle.FixedSingle
        TextBox4.Cursor = Cursors.IBeam
        TextBox4.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox4.ForeColor = Color.MidnightBlue
        TextBox4.Location = New Point(377, 168)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(283, 31)
        TextBox4.TabIndex = 7
        ' 
        ' TextBox5
        ' 
        TextBox5.BackColor = Color.White
        TextBox5.BorderStyle = BorderStyle.FixedSingle
        TextBox5.Cursor = Cursors.IBeam
        TextBox5.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox5.ForeColor = Color.MidnightBlue
        TextBox5.Location = New Point(78, 168)
        TextBox5.Name = "TextBox5"
        TextBox5.Size = New Size(283, 31)
        TextBox5.TabIndex = 2
        ' 
        ' TextBox3
        ' 
        TextBox3.BackColor = Color.White
        TextBox3.BorderStyle = BorderStyle.FixedSingle
        TextBox3.Cursor = Cursors.IBeam
        TextBox3.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox3.ForeColor = Color.MidnightBlue
        TextBox3.Location = New Point(78, 79)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(283, 31)
        TextBox3.TabIndex = 1
        ' 
        ' TextBox8
        ' 
        TextBox8.BackColor = Color.White
        TextBox8.BorderStyle = BorderStyle.FixedSingle
        TextBox8.Cursor = Cursors.IBeam
        TextBox8.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox8.ForeColor = Color.MidnightBlue
        TextBox8.Location = New Point(377, 254)
        TextBox8.Name = "TextBox8"
        TextBox8.PasswordChar = "*"c
        TextBox8.Size = New Size(283, 31)
        TextBox8.TabIndex = 8
        ' 
        ' TextBox7
        ' 
        TextBox7.BackColor = Color.White
        TextBox7.BorderStyle = BorderStyle.FixedSingle
        TextBox7.Cursor = Cursors.IBeam
        TextBox7.Font = New Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox7.ForeColor = Color.MidnightBlue
        TextBox7.Location = New Point(78, 254)
        TextBox7.Name = "TextBox7"
        TextBox7.Size = New Size(283, 31)
        TextBox7.TabIndex = 3
        ' 
        ' Label6
        ' 
        Label6.BackColor = Color.Lavender
        Label6.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.ForeColor = Color.MidnightBlue
        Label6.Location = New Point(377, 131)
        Label6.Name = "Label6"
        Label6.Size = New Size(183, 35)
        Label6.TabIndex = 4
        Label6.Text = "College Department"
        Label6.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label5
        ' 
        Label5.BackColor = Color.Lavender
        Label5.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.MidnightBlue
        Label5.Location = New Point(78, 131)
        Label5.Name = "Label5"
        Label5.Size = New Size(113, 35)
        Label5.TabIndex = 4
        Label5.Text = "Last Name"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button1
        ' 
        Button1.AllowDrop = True
        Button1.BackColor = Color.MidnightBlue
        Button1.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.GhostWhite
        Button1.Location = New Point(377, 345)
        Button1.Name = "Button1"
        Button1.Size = New Size(115, 47)
        Button1.TabIndex = 11
        Button1.Text = "CANCEL"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Label4
        ' 
        Label4.BackColor = Color.Lavender
        Label4.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.MidnightBlue
        Label4.Location = New Point(78, 42)
        Label4.Name = "Label4"
        Label4.Size = New Size(113, 35)
        Label4.TabIndex = 4
        Label4.Text = "First Name"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Button2
        ' 
        Button2.AllowDrop = True
        Button2.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.MidnightBlue
        Button2.Location = New Point(242, 345)
        Button2.Name = "Button2"
        Button2.Size = New Size(119, 47)
        Button2.TabIndex = 10
        Button2.Text = "SIGN UP"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' CheckBoxShowPassword
        ' 
        CheckBoxShowPassword.AutoSize = True
        CheckBoxShowPassword.BackColor = Color.Lavender
        CheckBoxShowPassword.Font = New Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        CheckBoxShowPassword.ForeColor = Color.MidnightBlue
        CheckBoxShowPassword.Location = New Point(377, 299)
        CheckBoxShowPassword.Name = "CheckBoxShowPassword"
        CheckBoxShowPassword.Size = New Size(136, 22)
        CheckBoxShowPassword.TabIndex = 9
        CheckBoxShowPassword.Text = "Show Password"
        CheckBoxShowPassword.UseVisualStyleBackColor = False
        ' 
        ' RegisterForm1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1165, 642)
        Controls.Add(Panel1)
        Controls.Add(TextBox2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Panel2)
        MaximizeBox = False
        MinimizeBox = False
        MinimumSize = New Size(800, 600)
        Name = "RegisterForm1"
        StartPosition = FormStartPosition.CenterParent
        Text = "REGISTER"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Register As Button
    Friend WithEvents Login As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents TextBox5 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents TextBox8 As TextBox
    Friend WithEvents TextBox7 As TextBox
    Friend WithEvents TextBox4 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RadioButton5 As RadioButton
    Friend WithEvents RadioButton4 As RadioButton
    Friend WithEvents CheckBoxShowPassword As CheckBox

End Class
