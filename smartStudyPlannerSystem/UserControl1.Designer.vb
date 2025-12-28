<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl1))
        Panel1 = New Panel()
        Panel2 = New Panel()
        PictureBox1 = New PictureBox()
        Button1 = New Button()
        Button2 = New Button()
        Login = New Button()
        Register = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Login)
        Panel1.Controls.Add(Register)
        Panel1.Location = New Point(0, 3)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(979, 683)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), Image)
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.Controls.Add(Button1)
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(PictureBox1)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(979, 683)
        Panel2.TabIndex = 3
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.SYNDTASK_LOGO2
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Image = My.Resources.Resources.SYNDTASK_LOGO
        PictureBox1.Location = New Point(220, -39)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(572, 500)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.AllowDrop = True
        Button1.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.MidnightBlue
        Button1.Location = New Point(386, 374)
        Button1.Name = "Button1"
        Button1.Size = New Size(237, 60)
        Button1.TabIndex = 0
        Button1.Text = "INSTRUCTOR"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.AllowDrop = True
        Button2.BackColor = Color.MidnightBlue
        Button2.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.GhostWhite
        Button2.Location = New Point(386, 443)
        Button2.Name = "Button2"
        Button2.Size = New Size(237, 60)
        Button2.TabIndex = 0
        Button2.Text = "STUDENT"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        Login.AllowDrop = True
        Login.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Login.ForeColor = Color.MidnightBlue
        Login.Location = New Point(363, 351)
        Login.Name = "Login"
        Login.Size = New Size(260, 73)
        Login.TabIndex = 1
        Login.Text = "INSTRUCTOR"
        Login.UseVisualStyleBackColor = True
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.MidnightBlue
        Register.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.GhostWhite
        Register.Location = New Point(363, 440)
        Register.Name = "Register"
        Register.Size = New Size(260, 73)
        Register.TabIndex = 2
        Register.Text = "STUDENT"
        Register.UseVisualStyleBackColor = False
        ' 
        ' UserControl1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Panel1)
        Name = "UserControl1"
        Size = New Size(979, 686)
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Login As Button
    Friend WithEvents Register As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox

End Class
