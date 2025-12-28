<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form4TasksStudent
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form4TasksStudent))
        Panel2 = New Panel()
        Panel4 = New Panel()
        Panel1 = New Panel()
        Panel3 = New Panel()
        LinkLabel5 = New LinkLabel()
        LinkLabel2 = New LinkLabel()
        PictureBox1 = New PictureBox()
        TextBox1 = New TextBox()
        LinkLabel3 = New LinkLabel()
        LinkLabel4 = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        RichTextBox3 = New RichTextBox()
        RichTextBox1 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        Label1 = New Label()
        Panel5 = New Panel()
        VScrollBar1 = New VScrollBar()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        Panel1.SuspendLayout()
        Panel3.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = My.Resources.Resources.gradient
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Panel4)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1169, 675)
        Panel2.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Transparent
        Panel4.Controls.Add(Panel1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1167, 673)
        Panel4.TabIndex = 14
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.AutoScroll = True
        Panel1.AutoScrollMargin = New Size(0, 20)
        Panel1.BackColor = Color.Lavender
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(Panel3)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Panel5)
        Panel1.Location = New Point(44, 45)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1091, 596)
        Panel1.TabIndex = 14
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.None
        Panel3.BackColor = Color.Lavender
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(LinkLabel5)
        Panel3.Controls.Add(LinkLabel2)
        Panel3.Controls.Add(PictureBox1)
        Panel3.Controls.Add(TextBox1)
        Panel3.Controls.Add(LinkLabel3)
        Panel3.Controls.Add(LinkLabel4)
        Panel3.Controls.Add(LinkLabel1)
        Panel3.Controls.Add(RichTextBox3)
        Panel3.Controls.Add(RichTextBox1)
        Panel3.Controls.Add(RichTextBox2)
        Panel3.Location = New Point(45, 96)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(991, 459)
        Panel3.TabIndex = 13
        ' 
        ' LinkLabel5
        ' 
        LinkLabel5.AutoSize = True
        LinkLabel5.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel5.LinkColor = Color.MidnightBlue
        LinkLabel5.Location = New Point(515, 40)
        LinkLabel5.Name = "LinkLabel5"
        LinkLabel5.Size = New Size(102, 25)
        LinkLabel5.TabIndex = 8
        LinkLabel5.TabStop = True
        LinkLabel5.Text = "SUBJECT"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel2.LinkColor = Color.MidnightBlue
        LinkLabel2.Location = New Point(515, 132)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(139, 25)
        LinkLabel2.TabIndex = 8
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "INSTRUCTOR"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.SkyBlue
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        PictureBox1.Location = New Point(60, 43)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(392, 254)
        PictureBox1.TabIndex = 9
        PictureBox1.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.White
        TextBox1.BorderStyle = BorderStyle.FixedSingle
        TextBox1.Font = New Font("Roboto Lt", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBox1.ForeColor = Color.MidnightBlue
        TextBox1.Location = New Point(60, 311)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(392, 97)
        TextBox1.TabIndex = 10
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.AutoSize = True
        LinkLabel3.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel3.LinkColor = Color.MidnightBlue
        LinkLabel3.Location = New Point(515, 224)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(110, 25)
        LinkLabel3.TabIndex = 8
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "DEADLINE"
        ' 
        ' LinkLabel4
        ' 
        LinkLabel4.AutoSize = True
        LinkLabel4.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel4.LinkColor = Color.MidnightBlue
        LinkLabel4.Location = New Point(724, 321)
        LinkLabel4.Name = "LinkLabel4"
        LinkLabel4.Size = New Size(71, 19)
        LinkLabel4.TabIndex = 8
        LinkLabel4.TabStop = True
        LinkLabel4.Text = "UPLOAD"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.LinkColor = Color.MidnightBlue
        LinkLabel1.Location = New Point(621, 321)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(97, 19)
        LinkLabel1.TabIndex = 8
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "DOWNLOAD"
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.Anchor = AnchorStyles.None
        RichTextBox3.BackColor = Color.White
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(515, 255)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.Size = New Size(390, 42)
        RichTextBox3.TabIndex = 6
        RichTextBox3.Text = ""
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Anchor = AnchorStyles.None
        RichTextBox1.BackColor = Color.White
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(515, 71)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(390, 42)
        RichTextBox1.TabIndex = 6
        RichTextBox1.Text = ""
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.Anchor = AnchorStyles.None
        RichTextBox2.BackColor = Color.White
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(515, 163)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(390, 42)
        RichTextBox2.TabIndex = 6
        RichTextBox2.Text = ""
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.AutoSize = True
        Label1.BackColor = Color.Lavender
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.MidnightBlue
        Label1.Location = New Point(106, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(112, 45)
        Label1.TabIndex = 5
        Label1.Text = "TASKS"
        ' 
        ' Panel5
        ' 
        Panel5.BackgroundImageLayout = ImageLayout.None
        Panel5.BorderStyle = BorderStyle.Fixed3D
        Panel5.Controls.Add(VScrollBar1)
        Panel5.Location = New Point(33, 77)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1017, 492)
        Panel5.TabIndex = 14
        ' 
        ' VScrollBar1
        ' 
        VScrollBar1.Location = New Point(1006, 4)
        VScrollBar1.Name = "VScrollBar1"
        VScrollBar1.Size = New Size(11, 488)
        VScrollBar1.TabIndex = 0
        ' 
        ' Form4TasksStudent
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1169, 675)
        Controls.Add(Panel2)
        Name = "Form4TasksStudent"
        Text = "TASKS (STUDENT)"
        Panel2.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents LinkLabel5 As LinkLabel
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents VScrollBar1 As VScrollBar
End Class
