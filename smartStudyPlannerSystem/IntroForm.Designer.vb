<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IntroForm
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
        Panel1 = New Panel()
        Register = New Button()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.Transparent
        Panel1.BackgroundImageLayout = ImageLayout.None
        Panel1.Controls.Add(Register)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1231, 662)
        Panel1.TabIndex = 0
        ' 
        ' Register
        ' 
        Register.AllowDrop = True
        Register.BackColor = Color.SteelBlue
        Register.BackgroundImageLayout = ImageLayout.Zoom
        Register.Font = New Font("Impact", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Register.ForeColor = Color.White
        Register.Location = New Point(526, 566)
        Register.Name = "Register"
        Register.Size = New Size(159, 52)
        Register.TabIndex = 1
        Register.Text = "GET STARTED"
        Register.UseVisualStyleBackColor = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.White
        PictureBox1.BackgroundImage = My.Resources.Resources.SYNDTASK10
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(1228, 672)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' IntroForm
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.gradient
        BackgroundImageLayout = ImageLayout.Center
        ClientSize = New Size(1231, 662)
        Controls.Add(Panel1)
        Name = "IntroForm"
        Text = "WELCOME"
        Panel1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Register As Button
End Class
