<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10Calendar
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10Calendar))
        Label1 = New Label()
        Panel1 = New Panel()
        Panel2 = New Panel()
        Panel4 = New Panel()
        Panel8 = New Panel()
        Panel6 = New Panel()
        Panel5 = New Panel()
        RichTextBox3 = New RichTextBox()
        RichTextBox2 = New RichTextBox()
        RichTextBox4 = New RichTextBox()
        RichTextBox1 = New RichTextBox()
        Label3 = New Label()
        Button2 = New Button()
        Button1 = New Button()
        Button3 = New Button()
        Splitter1 = New Splitter()
        Panel3 = New Panel()
        MonthCalendar1 = New MonthCalendar()
        Label2 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel3.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(151, 25)
        Label1.Name = "Label1"
        Label1.Size = New Size(167, 45)
        Label1.TabIndex = 5
        Label1.Text = "CALENDAR"
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.CornflowerBlue
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.ForeColor = Color.Black
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1170, 643)
        Panel1.TabIndex = 6
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), Image)
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Panel4)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1170, 643)
        Panel2.TabIndex = 1
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Lavender
        Panel4.BackgroundImage = My.Resources.Resources.gradient
        Panel4.BorderStyle = BorderStyle.FixedSingle
        Panel4.Controls.Add(Panel8)
        Panel4.Controls.Add(Panel6)
        Panel4.Controls.Add(Panel5)
        Panel4.Controls.Add(Splitter1)
        Panel4.Controls.Add(Panel3)
        Panel4.Controls.Add(Label2)
        Panel4.Controls.Add(Label1)
        Panel4.Dock = DockStyle.Fill
        Panel4.Location = New Point(0, 0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(1168, 641)
        Panel4.TabIndex = 4
        ' 
        ' Panel8
        ' 
        Panel8.BackgroundImage = My.Resources.Resources.gradient
        Panel8.Location = New Point(91, 360)
        Panel8.Name = "Panel8"
        Panel8.Size = New Size(1077, 281)
        Panel8.TabIndex = 1
        ' 
        ' Panel6
        ' 
        Panel6.BackColor = Color.MidnightBlue
        Panel6.BackgroundImage = My.Resources.Resources.gradient
        Panel6.Location = New Point(-2, 357)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(1170, 284)
        Panel6.TabIndex = 9
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(RichTextBox3)
        Panel5.Controls.Add(RichTextBox2)
        Panel5.Controls.Add(RichTextBox4)
        Panel5.Controls.Add(RichTextBox1)
        Panel5.Controls.Add(Label3)
        Panel5.Controls.Add(Button2)
        Panel5.Controls.Add(Button1)
        Panel5.Controls.Add(Button3)
        Panel5.Location = New Point(412, 86)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(481, 228)
        Panel5.TabIndex = 8
        ' 
        ' RichTextBox3
        ' 
        RichTextBox3.BorderStyle = BorderStyle.None
        RichTextBox3.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox3.ForeColor = Color.MidnightBlue
        RichTextBox3.Location = New Point(190, 138)
        RichTextBox3.Name = "RichTextBox3"
        RichTextBox3.ReadOnly = True
        RichTextBox3.Size = New Size(75, 45)
        RichTextBox3.TabIndex = 13
        RichTextBox3.Text = ""
        ' 
        ' RichTextBox2
        ' 
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox2.ForeColor = Color.MidnightBlue
        RichTextBox2.Location = New Point(190, 88)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.ReadOnly = True
        RichTextBox2.Size = New Size(75, 44)
        RichTextBox2.TabIndex = 13
        RichTextBox2.Text = ""
        ' 
        ' RichTextBox4
        ' 
        RichTextBox4.BorderStyle = BorderStyle.None
        RichTextBox4.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox4.Location = New Point(302, 102)
        RichTextBox4.Name = "RichTextBox4"
        RichTextBox4.ReadOnly = True
        RichTextBox4.Size = New Size(129, 45)
        RichTextBox4.TabIndex = 13
        RichTextBox4.Text = ""
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BorderStyle = BorderStyle.None
        RichTextBox1.Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.MidnightBlue
        RichTextBox1.Location = New Point(190, 37)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(75, 45)
        RichTextBox1.TabIndex = 13
        RichTextBox1.Text = ""
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Transparent
        Label3.Font = New Font("Roboto Lt", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.ForeColor = Color.MidnightBlue
        Label3.Location = New Point(318, 66)
        Label3.Name = "Label3"
        Label3.Size = New Size(90, 33)
        Label3.TabIndex = 5
        Label3.Text = "Total:"
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.None
        Button2.BackColor = Color.Red
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Impact", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.White
        Button2.Location = New Point(37, 138)
        Button2.Name = "Button2"
        Button2.Size = New Size(141, 45)
        Button2.TabIndex = 12
        Button2.Text = "OVERDUE:"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.None
        Button1.BackColor = Color.Orange
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Impact", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(37, 88)
        Button1.Name = "Button1"
        Button1.Size = New Size(141, 44)
        Button1.TabIndex = 12
        Button1.Text = "DUE SOON:"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.None
        Button3.BackColor = Color.Green
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Impact", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.White
        Button3.Location = New Point(37, 37)
        Button3.Name = "Button3"
        Button3.Size = New Size(141, 45)
        Button3.TabIndex = 12
        Button3.Text = "ACTIVE:"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Splitter1
        ' 
        Splitter1.Dock = DockStyle.Bottom
        Splitter1.Location = New Point(0, 357)
        Splitter1.Name = "Splitter1"
        Splitter1.Size = New Size(1166, 282)
        Splitter1.TabIndex = 7
        Splitter1.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(MonthCalendar1)
        Panel3.Location = New Point(90, 86)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(301, 228)
        Panel3.TabIndex = 6
        ' 
        ' MonthCalendar1
        ' 
        MonthCalendar1.Font = New Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        MonthCalendar1.Location = New Point(33, 28)
        MonthCalendar1.Name = "MonthCalendar1"
        MonthCalendar1.TabIndex = 0
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.BackColor = Color.Transparent
        Label2.Font = New Font("Impact", 27.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.White
        Label2.Location = New Point(449, 25)
        Label2.Name = "Label2"
        Label2.Size = New Size(186, 45)
        Label2.TabIndex = 5
        Label2.Text = "STATISTICS"
        ' 
        ' Form10Calendar
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1170, 643)
        Controls.Add(Panel1)
        MinimumSize = New Size(800, 600)
        Name = "Form10Calendar"
        Text = "CALENDAR"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel3.ResumeLayout(False)
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Panel3 As Panel
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents RichTextBox3 As RichTextBox
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents RichTextBox4 As RichTextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel8 As Panel
End Class
