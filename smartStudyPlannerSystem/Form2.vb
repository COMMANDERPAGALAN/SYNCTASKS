Public Class Form2
    Private currentUser As User

    Public Sub New(user As User)
        InitializeComponent()
        currentUser = user
        Session.CurrentUser = user
        Me.Text = "Smart Study Planner - " & user.FirstName & " " & user.LastName & " (" & user.Role & ")"
    End Sub

    Public Sub ShowInContent(frm As Form)
        If ContentPanel Is Nothing Then Return
        ContentPanel.Controls.Clear()
        frm.TopLevel = False
        frm.FormBorderStyle = FormBorderStyle.None
        frm.Dock = DockStyle.Fill
        ContentPanel.Controls.Add(frm)
        frm.Show()
    End Sub

    Private Sub PROFILEToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PROFILEToolStripMenuItem1.Click
        Dim f As New Form3Profile
        ShowInContent(f)
    End Sub

    Private Sub INSTRUCTORToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles INSTRUCTORToolStripMenuItem.Click
        Dim f As New Form3Instructor()
        ShowInContent(f)
    End Sub

    Private Sub STUDENTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles STUDENTToolStripMenuItem.Click
        Dim f As New Form3Student()
        ShowInContent(f)
    End Sub


    Private Sub PROGRESSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PROGRESSToolStripMenuItem.Click
        Dim formToShow As Form = If(IsStudentRole(), New Form4TasksStudent(), New Form4TasksInstructor())
        ShowInContent(formToShow)
    End Sub

    Private Sub REPORTSToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles REPORTSToolStripMenuItem.Click
        Dim f As New Form5Progress()
        ShowInContent(f)
    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Dim formToShow As Form = If(IsStudentRole(), New Form6GradesStudent(), New Form6GradesInstructor())
        ShowInContent(formToShow)
    End Sub

    Private Sub LOGOUTToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem1.Click
        Session.LogOut()
        Dim f As New Form1()
        f.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim f As New Form7Subject()
        ShowInContent(f)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim f As New Form8Deadline()
        ShowInContent(f)
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim f As New Form9Duration()
        ShowInContent(f)
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim f As New Form10Calendar()
        ShowInContent(f)
    End Sub

    Private Function IsStudentRole() As Boolean
        Return currentUser IsNot Nothing AndAlso
            currentUser.Role IsNot Nothing AndAlso
            String.Equals(currentUser.Role.Trim(), "Student", System.StringComparison.OrdinalIgnoreCase)
    End Function

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub Panel3_Paint(sender As Object, e As PaintEventArgs) Handles Panel3.Paint

    End Sub

    Private Sub Splitter1_SplitterMoved(sender As Object, e As SplitterEventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class