<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form9Duration
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form9Duration))
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel3 = New Panel()
        HScrollBar1 = New HScrollBar()
        VScrollBar1 = New VScrollBar()
        Panel4 = New Panel()
        RichTextBox1 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        LinkLabel3 = New LinkLabel()
        LinkLabel1 = New LinkLabel()
        Label1 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
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
        Panel1.Size = New Size(1175, 645)
        Panel1.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), Image)
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1175, 645)
        Panel2.TabIndex = 1
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.None
        Panel3.BackColor = Color.Transparent
        Panel3.Controls.Add(HScrollBar1)
        Panel3.Controls.Add(VScrollBar1)
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(Label1)
        Panel3.Location = New Point(49, 43)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(1121, 558)
        Panel3.TabIndex = 6
        ' 
        ' HScrollBar1
        ' 
        HScrollBar1.Location = New Point(0, 541)
        HScrollBar1.Name = "HScrollBar1"
        HScrollBar1.Size = New Size(1043, 17)
        HScrollBar1.TabIndex = 7
        ' 
        ' VScrollBar1
        ' 
        VScrollBar1.Location = New Point(1105, -10)
        VScrollBar1.Name = "VScrollBar1"
        VScrollBar1.Size = New Size(11, 556)
        VScrollBar1.TabIndex = 6
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Lavender
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(RichTextBox1)
        Panel4.Controls.Add(RichTextBox2)
        Panel4.Controls.Add(LinkLabel3)
        Panel4.Controls.Add(LinkLabel1)
        Panel4.Location = New Point(100, 100)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(364, 252)
        Panel4.TabIndex = 4
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(26, 71)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(304, 32)
        RichTextBox1.TabIndex = 9
        RichTextBox1.Text = ""
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(26, 155)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(304, 32)
        RichTextBox2.TabIndex = 9
        RichTextBox2.Text = ""
        ' 
        ' LinkLabel3
        ' 
        LinkLabel3.ActiveLinkColor = Color.MidnightBlue
        LinkLabel3.AutoSize = True
        LinkLabel3.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel3.ForeColor = Color.MidnightBlue
        LinkLabel3.LinkColor = Color.MidnightBlue
        LinkLabel3.LinkVisited = True
        LinkLabel3.Location = New Point(26, 127)
        LinkLabel3.Name = "LinkLabel3"
        LinkLabel3.Size = New Size(110, 25)
        LinkLabel3.TabIndex = 8
        LinkLabel3.TabStop = True
        LinkLabel3.Text = "DEADLINE"
        LinkLabel3.VisitedLinkColor = Color.MidnightBlue
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
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(100, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(165, 45)
        Label1.TabIndex = 5
        Label1.Text = "DURATION"
        ' 
        ' Form9Duration
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1175, 645)
        Controls.Add(Panel1)
        MinimumSize = New Size(800, 600)
        Name = "Form9Duration"
        Text = "DURATION"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        ResumeLayout(False)
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents LinkLabel3 As LinkLabel
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents VScrollBar1 As VScrollBar
    Friend WithEvents HScrollBar1 As HScrollBar
End Class
