<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form6GradesInstructor
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
        Label3 = New Label()
        RichTextBox5 = New RichTextBox()
        Panel5 = New Panel()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Label1 = New Label()
        Splitter2 = New Splitter()
        Panel4 = New Panel()
        LinkLabel1 = New LinkLabel()
        Label4 = New Label()
        Label5 = New Label()
        RichTextBox1 = New RichTextBox()
        RichTextBox9 = New RichTextBox()
        RichTextBox3 = New RichTextBox()
        Panel3 = New Panel()
        Panel5.SuspendLayout()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Lavender
        Label3.Font = New Font("Impact", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.MidnightBlue
        Label3.Location = New Point(220, 17)
        Label3.Name = "Label3"
        Label3.Size = New Size(242, 39)
        Label3.TabIndex = 5
        Label3.Text = "LIST OF STUDENTS"
        ' 
        ' RichTextBox5
        ' 
        RichTextBox5.BorderStyle = BorderStyle.None
        RichTextBox5.Font = New Font("Poppins", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox5.ForeColor = Color.MidnightBlue
        RichTextBox5.Location = New Point(220, 59)
        RichTextBox5.Name = "RichTextBox5"
        RichTextBox5.Size = New Size(425, 282)
        RichTextBox5.TabIndex = 9
        RichTextBox5.Text = ""
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.Lavender
        Panel5.BackgroundImageLayout = ImageLayout.Center
        Panel5.BorderStyle = BorderStyle.FixedSingle
        Panel5.Controls.Add(Label3)
        Panel5.Controls.Add(RichTextBox5)
        Panel5.Location = New Point(-1, 426)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(1167, 378)
        Panel5.TabIndex = 6
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1167, 664)
        Panel1.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = My.Resources.Resources.gradient
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Panel5)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(Splitter2)
        Panel2.Controls.Add(Panel3)
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1167, 664)
        Panel2.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(220, 29)
        Label1.Name = "Label1"
        Label1.Size = New Size(133, 45)
        Label1.TabIndex = 5
        Label1.Text = "GRADES"
        ' 
        ' Splitter2
        ' 
        Splitter2.Dock = DockStyle.Bottom
        Splitter2.Location = New Point(0, 804)
        Splitter2.Name = "Splitter2"
        Splitter2.Size = New Size(1166, 236)
        Splitter2.TabIndex = 8
        Splitter2.TabStop = False
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Lavender
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(RichTextBox3)
        Panel4.Controls.Add(RichTextBox9)
        Panel4.Controls.Add(RichTextBox1)
        Panel4.Controls.Add(Label5)
        Panel4.Controls.Add(Label4)
        Panel4.Controls.Add(LinkLabel1)
        Panel4.Location = New Point(101, 66)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(425, 325)
        Panel4.TabIndex = 4
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.MidnightBlue
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LinkLabel1.ForeColor = Color.MidnightBlue
        LinkLabel1.LinkColor = Color.MidnightBlue
        LinkLabel1.LinkVisited = True
        LinkLabel1.Location = New Point(21, 104)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(102, 25)
        LinkLabel1.TabIndex = 8
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "SUBJECT"
        LinkLabel1.VisitedLinkColor = Color.MidnightBlue
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Roboto Bk", 24F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.ForeColor = Color.MidnightBlue
        Label4.Location = New Point(21, 26)
        Label4.Name = "Label4"
        Label4.Size = New Size(137, 38)
        Label4.TabIndex = 5
        Label4.Text = "SCORES"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Roboto Bk", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.ForeColor = Color.MidnightBlue
        Label5.Location = New Point(21, 186)
        Label5.Name = "Label5"
        Label5.Size = New Size(172, 24)
        Label5.TabIndex = 5
        Label5.Text = "STUDENT'S NAME"
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(21, 132)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(375, 32)
        RichTextBox1.TabIndex = 9
        RichTextBox1.Text = ""
        ' 
        ' RichTextBox9
        ' 
        RichTextBox9.BorderStyle = BorderStyle.None
        RichTextBox9.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox9.ForeColor = Color.MidnightBlue
        RichTextBox9.Location = New Point(164, 16)
        RichTextBox9.Name = "RichTextBox9"
        RichTextBox9.Size = New Size(232, 52)
        RichTextBox9.TabIndex = 9
        RichTextBox9.Text = ""
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(21, 213)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.Size = New Size(375, 32)
        RichTextBox3.TabIndex = 10
        RichTextBox3.Text = ""
        ' 
        ' Panel3
        ' 
        Panel3.AutoScroll = True
        Panel3.AutoScrollMargin = New Size(0, 20)
        Panel3.Controls.Add(Panel4)
        Panel3.Location = New Point(119, 11)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(899, 416)
        Panel3.TabIndex = 9
        ' 
        ' Form6GradesInstructor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1167, 664)
        Controls.Add(Panel1)
        Name = "Form6GradesInstructor"
        Text = "GRADES (INSTRUCTOR)"
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBox5 As RichTextBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Splitter2 As Splitter
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox9 As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
