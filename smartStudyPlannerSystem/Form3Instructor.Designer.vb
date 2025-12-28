<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form3Instructor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form3Instructor))
        PictureBox1 = New PictureBox()
        RichTextBox3 = New RichTextBox()
        RichTextBox1 = New RichTextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label1 = New Label()
        Panel4 = New Panel()
        RichTextBox2 = New RichTextBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.MidnightBlue
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        PictureBox1.Location = New Point(489, 65)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(222, 263)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BackColor = Color.White
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(44, 276)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.ReadOnly = True
        RichTextBox3.Size = New Size(394, 49)
        RichTextBox3.TabIndex = 6
        RichTextBox3.Text = ""
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.White
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(44, 93)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(394, 49)
        RichTextBox1.TabIndex = 6
        RichTextBox1.Text = ""
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.MidnightBlue
        Label4.Location = New Point(44, 248)
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
        Label3.Location = New Point(44, 156)
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
        Label2.Location = New Point(44, 65)
        Label2.Name = "Label2"
        Label2.Size = New Size(70, 25)
        Label2.TabIndex = 5
        Label2.Text = "NAME"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Lavender
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.MidnightBlue
        Label1.Location = New Point(79, 51)
        Label1.Name = "Label1"
        Label1.Size = New Size(204, 45)
        Label1.TabIndex = 5
        Label1.Text = "INSTRUCTOR"
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Lavender
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(PictureBox1)
        Panel4.Controls.Add(RichTextBox3)
        Panel4.Controls.Add(RichTextBox2)
        Panel4.Controls.Add(RichTextBox1)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(Label3)
        Panel4.Controls.Add(Label2)
        Panel4.Location = New Point(79, 118)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(760, 399)
        Panel4.TabIndex = 4
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BackColor = Color.White
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(44, 184)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.ReadOnly = True
        RichTextBox2.Size = New Size(394, 49)
        RichTextBox2.TabIndex = 6
        RichTextBox2.Text = ""
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1174, 648)
        Panel1.TabIndex = 3
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = My.Resources.Resources.gradient
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1174, 648)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.None
        Panel3.BackColor = Color.Lavender
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(117, 59)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(931, 560)
        Panel3.TabIndex = 4
        ' 
        ' Form3Instructor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1174, 648)
        Controls.Add(Panel1)
        Name = "Form3Instructor"
        Text = "Instructor"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
End Class
