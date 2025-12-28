<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form3EditProfile
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3EditProfile))
        Panel2 = New Panel()
        Label1 = New Label()
        Panel4 = New Panel()
        Button1 = New Button()
        Register = New Button()
        Login = New Button()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        RichTextBox3 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        RichTextBox1 = New RichTextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = My.Resources.Resources.gradient
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Panel4)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1150, 652)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(205, 59)
        Label1.Name = "Label1"
        Label1.Size = New Size(204, 45)
        Label1.TabIndex = 5
        Label1.Text = "EDIT PROFILE"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Lavender
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(Button1)
        Panel4.Controls.Add(Register)
        Panel4.Controls.Add(Login)
        Panel4.Controls.Add(LinkLabel1)
        Panel4.Controls.Add(PictureBox1)
        Panel4.Controls.Add(RichTextBox3)
        Panel4.Controls.Add(RichTextBox2)
        Panel4.Controls.Add(RichTextBox1)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(Label3)
        Panel4.Controls.Add(Label2)
        Panel4.Location = New Point(205, 118)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(754, 418)
        Panel4.TabIndex = 4
        ' 
        ' Button1
        ' 
        Button1.AllowDrop = True
        Button1.BackColor = Color.MidnightBlue
        Button1.Font = New Font("Impact", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.GhostWhite
        Button1.Location = New Point(503, 333)
        Button1.Name = "Button1"
        Button1.Size = New Size(178, 49)
        Button1.TabIndex = 11
        Button1.Text = "DELETE ACCOUNT"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.MidnightBlue
        Register.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.GhostWhite
        Register.Location = New Point(248, 333)
        Register.Name = "Register"
        Register.Size = New Size(137, 49)
        Register.TabIndex = 11
        Register.Text = "CANCEL"
        Register.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        Login.AllowDrop = True
        Login.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Login.ForeColor = Color.MidnightBlue
        Login.Location = New Point(96, 333)
        Login.Name = "Login"
        Login.Size = New Size(137, 49)
        Login.TabIndex = 10
        Login.Text = "SAVE"
        Login.UseVisualStyleBackColor = True
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.MidnightBlue
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.ForeColor = Color.MidnightBlue
        LinkLabel1.LinkColor = Color.MidnightBlue
        LinkLabel1.LinkVisited = True
        LinkLabel1.Location = New Point(537, 300)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(114, 19)
        LinkLabel1.TabIndex = 9
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Upload Picture"
        LinkLabel1.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.MidnightBlue
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        PictureBox1.Location = New Point(483, 53)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(222, 244)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BackColor = Color.White
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(42, 248)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.Size = New Size(394, 49)
        RichTextBox3.TabIndex = 6
        RichTextBox3.Text = ""
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BackColor = Color.White
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(42, 156)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(394, 49)
        RichTextBox2.TabIndex = 6
        RichTextBox2.Text = ""
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.White
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Roboto", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(42, 65)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(394, 49)
        RichTextBox1.TabIndex = 6
        RichTextBox1.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.MidnightBlue
        Label4.Location = New Point(42, 220)
        Label4.Name = "Label4"
        Label4.Size = New Size(241, 25)
        Label4.TabIndex = 5
        Label4.Text = "COLLEGE DEPARTMENT"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.MidnightBlue
        Label3.Location = New Point(42, 128)
        Label3.Name = "Label3"
        Label3.Size = New Size(92, 25)
        Label3.TabIndex = 5
        Label3.Text = "GENDER"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.MidnightBlue
        Label2.Location = New Point(42, 37)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 25)
        Label2.TabIndex = 5
        Label2.Text = "NAME"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1150, 652)
        Panel1.TabIndex = 3
        ' 
        ' Form3EditProfile
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1150, 652)
        Controls.Add(Panel1)
        Name = "Form3EditProfile"
        Text = "EDIT PROFILE"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Login As Button
    Friend WithEvents Register As Button
    Friend WithEvents Button1 As Button
End Class
