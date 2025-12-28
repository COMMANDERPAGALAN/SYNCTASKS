<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form2
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form2))
        Panel1 = New Panel()
        Panel2 = New Panel()
        ContentPanel = New Panel()
        Panel4 = New Panel()
        PictureBox1 = New PictureBox()
        Panel3 = New Panel()
        MenuStrip1 = New MenuStrip()
        ToolStripMenuItem1 = New ToolStripMenuItem()
        PROFILEToolStripMenuItem1 = New ToolStripMenuItem()
        TASKToolStripMenuItem = New ToolStripMenuItem()
        INSTRUCTORToolStripMenuItem = New ToolStripMenuItem()
        STUDENTToolStripMenuItem = New ToolStripMenuItem()
        PROGRESSToolStripMenuItem = New ToolStripMenuItem()
        REPORTSToolStripMenuItem = New ToolStripMenuItem()
        LOGOUTToolStripMenuItem = New ToolStripMenuItem()
        LOGOUTToolStripMenuItem1 = New ToolStripMenuItem()
        Panel5 = New Panel()
        Button2 = New Button()
        Button3 = New Button()
        Button5 = New Button()
        Button4 = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        ContentPanel.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        MenuStrip1.SuspendLayout()
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
        Panel1.Size = New Size(1155, 644)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.Transparent
        Panel2.BackgroundImage = My.Resources.Resources.gradient
        Panel2.BackgroundImageLayout = ImageLayout.Center
        Panel2.Controls.Add(ContentPanel)
        Panel2.Controls.Add(Panel3)
        Panel2.Dock = DockStyle.Fill
        Panel2.ForeColor = Color.Black
        Panel2.Location = New Point(0, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(1155, 644)
        Panel2.TabIndex = 1
        ' 
        ' ContentPanel
        ' 
        ContentPanel.BackColor = Color.White
        ContentPanel.BorderStyle = BorderStyle.FixedSingle
        ContentPanel.Controls.Add(Panel4)
        ContentPanel.Dock = DockStyle.Fill
        ContentPanel.Location = New Point(173, 0)
        ContentPanel.Name = "ContentPanel"
        ContentPanel.Size = New Size(982, 644)
        ContentPanel.TabIndex = 10
        ' 
        ' Panel4
        ' 
        Panel4.BackColor = Color.Transparent
        Panel4.BackgroundImage = My.Resources.Resources.gradient
        Panel4.BackgroundImageLayout = ImageLayout.Center
        Panel4.BorderStyle = BorderStyle.Fixed3D
        Panel4.Controls.Add(PictureBox1)
        Panel4.ForeColor = Color.Black
        Panel4.Location = New Point(-1, -1)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(990, 642)
        Panel4.TabIndex = 1
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.SYNDTASK_LOGO2
        PictureBox1.BackgroundImageLayout = ImageLayout.Zoom
        PictureBox1.Location = New Point(112, 39)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(756, 564)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.BackColor = Color.Lavender
        Panel3.BackgroundImageLayout = ImageLayout.None
        Panel3.BorderStyle = BorderStyle.FixedSingle
        Panel3.Controls.Add(MenuStrip1)
        Panel3.Controls.Add(Panel5)
        Panel3.Controls.Add(Button2)
        Panel3.Controls.Add(Button3)
        Panel3.Controls.Add(Button5)
        Panel3.Controls.Add(Button4)
        Panel3.Dock = DockStyle.Left
        Panel3.Location = New Point(0, 0)
        Panel3.MinimumSize = New Size(151, 0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(173, 644)
        Panel3.TabIndex = 2
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.BackColor = Color.White
        MenuStrip1.Dock = DockStyle.None
        MenuStrip1.Items.AddRange(New ToolStripItem() {ToolStripMenuItem1})
        MenuStrip1.Location = New Point(22, 17)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(111, 42)
        MenuStrip1.TabIndex = 1
        MenuStrip1.Text = "Profile"
        ' 
        ' ToolStripMenuItem1
        ' 
        ToolStripMenuItem1.DropDownItems.AddRange(New ToolStripItem() {PROFILEToolStripMenuItem1, TASKToolStripMenuItem, PROGRESSToolStripMenuItem, REPORTSToolStripMenuItem, LOGOUTToolStripMenuItem, LOGOUTToolStripMenuItem1})
        ToolStripMenuItem1.Font = New Font("Impact", 20.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ToolStripMenuItem1.ForeColor = Color.MidnightBlue
        ToolStripMenuItem1.Image = CType(resources.GetObject("ToolStripMenuItem1.Image"), Image)
        ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        ToolStripMenuItem1.Size = New Size(103, 38)
        ToolStripMenuItem1.Text = "MENU"
        ' 
        ' PROFILEToolStripMenuItem1
        ' 
        PROFILEToolStripMenuItem1.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PROFILEToolStripMenuItem1.ForeColor = Color.MidnightBlue
        PROFILEToolStripMenuItem1.Name = "PROFILEToolStripMenuItem1"
        PROFILEToolStripMenuItem1.Size = New Size(189, 38)
        PROFILEToolStripMenuItem1.Text = "PROFILE"
        ' 
        ' TASKToolStripMenuItem
        ' 
        TASKToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {INSTRUCTORToolStripMenuItem, STUDENTToolStripMenuItem})
        TASKToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TASKToolStripMenuItem.ForeColor = Color.MidnightBlue
        TASKToolStripMenuItem.Name = "TASKToolStripMenuItem"
        TASKToolStripMenuItem.Size = New Size(189, 38)
        TASKToolStripMenuItem.Text = "PEOPLE"
        ' 
        ' INSTRUCTORToolStripMenuItem
        ' 
        INSTRUCTORToolStripMenuItem.ForeColor = Color.MidnightBlue
        INSTRUCTORToolStripMenuItem.Name = "INSTRUCTORToolStripMenuItem"
        INSTRUCTORToolStripMenuItem.Size = New Size(201, 28)
        INSTRUCTORToolStripMenuItem.Text = "INSTRUCTOR"
        ' 
        ' STUDENTToolStripMenuItem
        ' 
        STUDENTToolStripMenuItem.ForeColor = Color.MidnightBlue
        STUDENTToolStripMenuItem.Name = "STUDENTToolStripMenuItem"
        STUDENTToolStripMenuItem.Size = New Size(201, 28)
        STUDENTToolStripMenuItem.Text = "STUDENT"
        ' 
        ' PROGRESSToolStripMenuItem
        ' 
        PROGRESSToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        PROGRESSToolStripMenuItem.ForeColor = Color.MidnightBlue
        PROGRESSToolStripMenuItem.Name = "PROGRESSToolStripMenuItem"
        PROGRESSToolStripMenuItem.Size = New Size(189, 38)
        PROGRESSToolStripMenuItem.Text = "TASKS"
        ' 
        ' REPORTSToolStripMenuItem
        ' 
        REPORTSToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        REPORTSToolStripMenuItem.ForeColor = Color.MidnightBlue
        REPORTSToolStripMenuItem.Name = "REPORTSToolStripMenuItem"
        REPORTSToolStripMenuItem.Size = New Size(189, 38)
        REPORTSToolStripMenuItem.Text = "PROGRESS"
        ' 
        ' LOGOUTToolStripMenuItem
        ' 
        LOGOUTToolStripMenuItem.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        LOGOUTToolStripMenuItem.ForeColor = Color.MidnightBlue
        LOGOUTToolStripMenuItem.Name = "LOGOUTToolStripMenuItem"
        LOGOUTToolStripMenuItem.Size = New Size(189, 38)
        LOGOUTToolStripMenuItem.Text = "GRADES"
        ' 
        ' LOGOUTToolStripMenuItem1
        ' 
        LOGOUTToolStripMenuItem1.ForeColor = Color.MidnightBlue
        LOGOUTToolStripMenuItem1.Name = "LOGOUTToolStripMenuItem1"
        LOGOUTToolStripMenuItem1.Size = New Size(189, 38)
        LOGOUTToolStripMenuItem1.Text = "LOG OUT"
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.White
        Panel5.Location = New Point(-1, -1)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(171, 64)
        Panel5.TabIndex = 0
        ' 
        ' Button2
        ' 
        Button2.AllowDrop = True
        Button2.BackColor = Color.GhostWhite
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button2.ForeColor = Color.MidnightBlue
        Button2.Location = New Point(22, 186)
        Button2.Name = "Button2"
        Button2.Size = New Size(131, 37)
        Button2.TabIndex = 7
        Button2.Text = "SUBJECT"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.AllowDrop = True
        Button3.BackColor = Color.GhostWhite
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button3.ForeColor = Color.MidnightBlue
        Button3.Location = New Point(22, 259)
        Button3.Name = "Button3"
        Button3.Size = New Size(131, 37)
        Button3.TabIndex = 6
        Button3.Text = "DEADLINE"
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button5
        ' 
        Button5.AllowDrop = True
        Button5.BackColor = Color.GhostWhite
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button5.ForeColor = Color.MidnightBlue
        Button5.Location = New Point(22, 411)
        Button5.Name = "Button5"
        Button5.Size = New Size(131, 37)
        Button5.TabIndex = 4
        Button5.Text = "CALENDAR"
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Button4
        ' 
        Button4.AllowDrop = True
        Button4.BackColor = Color.GhostWhite
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Button4.ForeColor = Color.MidnightBlue
        Button4.Location = New Point(22, 336)
        Button4.Name = "Button4"
        Button4.Size = New Size(131, 37)
        Button4.TabIndex = 5
        Button4.Text = "DURATION"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1155, 644)
        Controls.Add(Panel1)
        MainMenuStrip = MenuStrip1
        Name = "Form2"
        Text = "SMART STUDY PLANNER_PAGALAN"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        ContentPanel.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents PROFILEToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents TASKToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PROGRESSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents REPORTSToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Panel3 As Panel
    Friend WithEvents INSTRUCTORToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents STUDENTToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LOGOUTToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Button2 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents ContentPanel As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents PROFILEToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox1 As PictureBox
End Class