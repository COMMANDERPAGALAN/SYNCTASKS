<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form7Subject
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form7Subject))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        VScrollBar1 = New VScrollBar()
        Label1 = New Label()
        Panel5 = New Panel()
        RichTextBox2 = New RichTextBox()
        RichTextBox4 = New RichTextBox()
        LinkLabel3 = New LinkLabel()
        LinkLabel4 = New LinkLabel()
        PictureBox2 = New PictureBox()
        Panel4 = New Panel()
        RichTextBox1 = New RichTextBox()
        RichTextBox3 = New RichTextBox()
        LinkLabel2 = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel5.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1166, 647)
        Panel1.TabIndex = 4
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
        Panel2.Size = New Size(1166, 647)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(VScrollBar1)
        Panel3.Controls.Add(Label1)
        Panel3.Controls.Add(Panel5)
        Panel3.Controls.Add(Panel4)
        Panel3.Dock = DockStyle.Fill
        Panel3.Location = New Point(0, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1164, 645)
        Panel3.TabIndex = 6
        ' 
        ' VScrollBar1
        ' 
        VScrollBar1.Location = New Point(1154, -1)
        VScrollBar1.Maximum = 1000
        VScrollBar1.Name = "VScrollBar1"
        VScrollBar1.Size = New Size(10, 646)
        VScrollBar1.TabIndex = 5
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(154, 53)
        Label1.Name = "Label1"
        Label1.Size = New Size(143, 45)
        Label1.TabIndex = 5
        Label1.Text = "SUBJECT"
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.None
        Panel5.BackColor = Color.Lavender
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Controls.Add(RichTextBox2)
        Panel5.Controls.Add(RichTextBox4)
        Panel5.Controls.Add(LinkLabel3)
        Panel5.Controls.Add(LinkLabel4)
        Panel5.Controls.Add(PictureBox2)
        Panel5.Location = New Point(468, 123)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(311, 422)
        Panel5.TabIndex = 6
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(26, 71)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox2.Size = New Size(259, 32)
        RichTextBox2.TabIndex = 9
        RichTextBox2.Text = ""
        ' 
        ' RichTextBox4
        ' 
        RichTextBox4.BorderStyle = BorderStyle.None
        RichTextBox4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox4.ForeColor = Color.MidnightBlue
        RichTextBox4.Location = New Point(26, 349)
        RichTextBox4.Name = "RichTextBox4"
        RichTextBox4.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox4.Size = New Size(253, 32)
        RichTextBox4.TabIndex = 9
        RichTextBox4.Text = ""
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.ActiveLinkColor = Color.MidnightBlue
        LinkLabel3.AutoSize = True
        LinkLabel3.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel3.ForeColor = Color.MidnightBlue
        LinkLabel3.LinkColor = Color.MidnightBlue
        LinkLabel3.LinkVisited = True
        LinkLabel3.Location = New Point(26, 321)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(139, 25)
        LinkLabel3.TabIndex = 8
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "INSTRUCTOR"
        LinkLabel3.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' LinkLabel4
        ' 
        LinkLabel4.ActiveLinkColor = Color.MidnightBlue
        LinkLabel4.AutoSize = True
        LinkLabel4.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel4.ForeColor = Color.MidnightBlue
        LinkLabel4.LinkColor = Color.MidnightBlue
        LinkLabel4.LinkVisited = True
        LinkLabel4.Location = New Point(26, 43)
        LinkLabel4.Name = "LinkLabel4"
        LinkLabel4.Size = New Size(102, 25)
        LinkLabel4.TabIndex = 8
        LinkLabel4.TabStop = True
        LinkLabel4.Text = "SUBJECT"
        LinkLabel4.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.SkyBlue
        PictureBox2.BackgroundImage = CType(resources.GetObject("PictureBox2.BackgroundImage"), Image)
        PictureBox2.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox2.BorderStyle = BorderStyle.Fixed3D
        PictureBox2.Location = New Point(26, 109)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(259, 195)
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.None
        Panel4.BackColor = Color.Lavender
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(RichTextBox1)
        Panel4.Controls.Add(RichTextBox3)
        Panel4.Controls.Add(LinkLabel2)
        Panel4.Controls.Add(LinkLabel1)
        Panel4.Controls.Add(PictureBox1)
        Panel4.Location = New Point(127, 123)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(311, 422)
        Panel4.TabIndex = 4
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(26, 71)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox1.Size = New Size(259, 32)
        RichTextBox1.TabIndex = 9
        RichTextBox1.Text = ""
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(26, 349)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox3.Size = New Size(253, 32)
        RichTextBox3.TabIndex = 9
        RichTextBox3.Text = ""
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.ActiveLinkColor = Color.MidnightBlue
        LinkLabel2.AutoSize = True
        LinkLabel2.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel2.ForeColor = Color.MidnightBlue
        LinkLabel2.LinkColor = Color.MidnightBlue
        LinkLabel2.LinkVisited = True
        LinkLabel2.Location = New Point(26, 321)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(139, 25)
        LinkLabel2.TabIndex = 8
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "INSTRUCTOR"
        LinkLabel2.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.MidnightBlue
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.ForeColor = Color.MidnightBlue
        LinkLabel1.LinkColor = Color.MidnightBlue
        LinkLabel1.LinkVisited = True
        LinkLabel1.Location = New Point(26, 43)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(102, 25)
        LinkLabel1.TabIndex = 8
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "SUBJECT"
        LinkLabel1.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.SkyBlue
        PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.BorderStyle = BorderStyle.Fixed3D
        PictureBox1.Location = New Point(26, 109)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(259, 195)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' Form7Subject
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1166, 647)
        Controls.Add(Panel1)
        MinimumSize = New Size(800, 600)
        Name = "Form7Subject"
        Text = "SUBJECT"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel4 As LinkLabel
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents VScrollBar1 As VScrollBar
End Class
