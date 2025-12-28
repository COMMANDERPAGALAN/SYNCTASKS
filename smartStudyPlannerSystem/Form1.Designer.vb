<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
        Register = New Button()
        Login = New Button()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.MidnightBlue
        Register.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.GhostWhite
        Register.Location = New Point(506, 483)
        Register.Name = "Register"
        Register.Size = New Size(137, 49)
        Register.TabIndex = 0
        Register.Text = "REGISTER"
        Register.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        Login.AllowDrop = True
        Login.Font = New Font("Impact", 21.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Login.ForeColor = Color.MidnightBlue
        Login.Location = New Point(506, 428)
        Login.Name = "Login"
        Login.Size = New Size(137, 49)
        Login.TabIndex = 0
        Login.Text = "LOG IN"
        Login.UseVisualStyleBackColor = True
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImage = My.Resources.Resources.gradient
        Panel1.BackgroundImageLayout = ImageLayout.Center
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Login)
        Panel1.Controls.Add(Register)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1174, 653)
        Panel1.TabIndex = 0
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.SYNDTASK_LOGO2
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(243, 78)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(681, 373)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ActiveCaptionText
        ClientSize = New Size(1174, 653)
        Controls.Add(Panel1)
        ForeColor = SystemColors.ActiveCaptionText
        MinimumSize = New Size(800, 600)
        Name = "Form1"
        Text = "STUDY PLANNER"
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Register As Button
    Friend WithEvents Login As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox

End Class
