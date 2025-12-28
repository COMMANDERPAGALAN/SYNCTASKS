Public Class Form5Progress
    Private currentUser As User
    Private allTasks As List(Of Task)
    Private allSubmissions As List(Of TaskSubmission)
    Private motivationalWords As List(Of String)
    Private currentMotivationalIndex As Integer = 0

    Private Sub Form5Progress_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Progress", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Initialize motivational words (20+ words)
        InitializeMotivationalWords()

        ' Load tasks and submissions
        allTasks = DataStore.LoadTasks()
        allSubmissions = DataStore.LoadSubmissions()

        ' Load and display progress
        LoadProgress()
    End Sub

    Private Sub InitializeMotivationalWords()
        motivationalWords = New List(Of String) From {
            "🌟 Every task completed is a step closer to your goals!",
            "💪 You've got this! Keep pushing forward!",
            "🎯 Success is the sum of small efforts repeated day in and day out!",
            "✨ Believe in yourself and all that you are!",
            "🚀 Your hard work will pay off!",
            "📚 Knowledge is power - keep learning!",
            "🏆 Champions are made in practice, not in games!",
            "💡 Every expert was once a beginner!",
            "🌈 After every storm comes a rainbow!",
            "🔥 Turn your dreams into reality!",
            "⭐ The only way to do great work is to love what you do!",
            "🎓 Education is the most powerful weapon!",
            "💎 Pressure makes diamonds!",
            "🌱 Growth happens outside your comfort zone!",
            "🎨 Your future is created by what you do today!",
            "⚡ Don't stop when you're tired, stop when you're done!",
            "🌟 You are capable of amazing things!",
            "📖 The beautiful thing about learning is no one can take it away!",
            "🎯 Focus on progress, not perfection!",
            "💪 Hard work beats talent when talent doesn't work hard!",
            "🚀 Dream big and dare to fail!",
            "✨ Excellence is not a skill, it's an attitude!",
            "🏅 The harder you work, the luckier you get!",
            "🌻 Bloom where you are planted!",
            "🎪 Life is 10% what happens to you and 90% how you react!"
        }
    End Sub

    Private Sub LoadProgress()
        ' Clear existing dynamic controls
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel2.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Label2 AndAlso ctrl IsNot Panel4 AndAlso ctrl IsNot Panel6 AndAlso ctrl IsNot Panel5 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel2.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Get student's submissions to determine completed tasks
        Dim studentSubmissions = allSubmissions.Where(Function(s) s.StudentID = currentUser.Username).ToList()
        Dim completedTaskIDs = studentSubmissions.Select(Function(s) s.TaskID).ToList()

        ' Separate tasks into PENDING and COMPLETED
        Dim pendingTasks = allTasks.Where(Function(t) Not completedTaskIDs.Contains(t.TaskID)).ToList()
        Dim completedTasks = allTasks.Where(Function(t) completedTaskIDs.Contains(t.TaskID)).ToList()

        ' Use template Panel4 for first PENDING task
        If pendingTasks.Count > 0 Then
            PopulateTaskPanel(Panel4, pendingTasks(0), "PENDING", Color.Crimson)
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If

        ' Use template Panel6 for first COMPLETED task
        If completedTasks.Count > 0 Then
            PopulateTaskPanel(Panel6, completedTasks(0), "COMPLETED", Color.MidnightBlue)
            Panel6.Visible = True
        Else
            Panel6.Visible = False
        End If

        ' Calculate positions - start after template panels
        Dim startY As Integer = 111 + 350 + 10 ' After template panel, 2 lines gap
        Dim panelWidth As Integer = 366
        Dim panelHeight As Integer = 350
        Dim spacing As Integer = 10 ' 2 lines gap (10 pixels)
        Dim leftX As Integer = 199
        Dim rightX As Integer = 586

        ' Display additional PENDING tasks (skip first one, already in Panel4)
        Dim pendingY As Integer = startY
        For i As Integer = 1 To pendingTasks.Count - 1
            Dim pnlPending = CreateTaskPanel(pendingTasks(i), "PENDING", Color.Crimson, leftX, pendingY, panelWidth, panelHeight)
            Panel2.Controls.Add(pnlPending)
            pendingY += panelHeight + spacing
        Next

        ' Display additional COMPLETED tasks (skip first one, already in Panel6)
        Dim completedY As Integer = startY
        For i As Integer = 1 To completedTasks.Count - 1
            Dim pnlCompleted = CreateTaskPanel(completedTasks(i), "COMPLETED", Color.MidnightBlue, rightX, completedY, panelWidth, panelHeight)
            Panel2.Controls.Add(pnlCompleted)
            completedY += panelHeight + spacing
        Next

        ' Position Words of Encouragement below all tasks
        Dim maxHeight = Math.Max(pendingY, completedY)
        If maxHeight < 500 Then maxHeight = 500 ' Minimum position
        Label2.Location = New Point(199, maxHeight + 10)
        Panel5.Location = New Point(199, maxHeight + 55)
        Panel5.Size = New Size(756, 99)

        ' Show motivational word
        RichTextBox5.Text = GetNextMotivationalWord()

        ' Enable scrolling - ensure all content is accessible (Form3Student pattern)
        ' Add extra margin to prevent cutoff at bottom
        Dim totalHeight = maxHeight + 200 ' Extra margin for Words of Encouragement
        Panel2.AutoScroll = True
        Panel2.AutoScrollMinSize = New Size(0, totalHeight + 100) ' Extra margin to prevent cutoff
    End Sub

    Private Sub PopulateTaskPanel(pnl As Panel, task As Task, status As String, statusColor As Color)
        ' Determine which panel we're working with
        Dim isPanel4 = (pnl Is Panel4)
        
        ' Find controls within the panel - Panel4 uses RichTextBox8/1/3/2, Panel6 uses RichTextBox9/7/6/4
        Dim lblStatus = If(isPanel4, Label3, Label4)
        Dim rtbTitle = If(isPanel4, RichTextBox8, RichTextBox9)
        Dim rtbSubject = If(isPanel4, RichTextBox1, RichTextBox7)
        Dim rtbInstructor = If(isPanel4, RichTextBox3, RichTextBox6)
        Dim rtbDeadline = If(isPanel4, RichTextBox2, RichTextBox4)
        Dim lnkSubject = If(isPanel4, LinkLabel1, LinkLabel6)
        Dim lnkInstructor = If(isPanel4, LinkLabel2, LinkLabel5)
        Dim lnkDeadline = If(isPanel4, LinkLabel3, LinkLabel4)

        ' Update status label
        lblStatus.Text = status
        lblStatus.ForeColor = statusColor

        ' Update title
        rtbTitle.Text = task.Title

        ' Update subject
        rtbSubject.Text = task.SubjectName

        ' Update instructor
        rtbInstructor.Text = task.InstructorName

        ' Update deadline
        rtbDeadline.Text = task.Deadline.ToString("yyyy-MM-dd HH:mm")

        ' Store task reference for link handlers
        pnl.Tag = task
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        If Panel4.Tag IsNot Nothing AndAlso TypeOf Panel4.Tag Is Task Then
            Dim task = DirectCast(Panel4.Tag, Task)
            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = task.SubjectID)
            If subject IsNot Nothing Then
                Session.SelectedSubject = subject
                NavigateToForm(New Form7Subject())
            End If
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        NavigateToForm(New Form3Instructor())
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        NavigateToForm(New Form8Deadline())
    End Sub

    Private Sub LinkLabel6_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel6.LinkClicked
        If Panel6.Tag IsNot Nothing AndAlso TypeOf Panel6.Tag Is Task Then
            Dim task = DirectCast(Panel6.Tag, Task)
            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = task.SubjectID)
            If subject IsNot Nothing Then
                Session.SelectedSubject = subject
                NavigateToForm(New Form7Subject())
            End If
        End If
    End Sub

    Private Sub LinkLabel5_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel5.LinkClicked
        NavigateToForm(New Form3Instructor())
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked
        NavigateToForm(New Form8Deadline())
    End Sub

    Private Function CreateTaskPanel(task As Task, status As String, statusColor As Color, x As Integer, y As Integer, width As Integer, height As Integer) As Panel
        Dim pnl As New Panel With {
            .BackColor = Color.Lavender,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = New Point(x, y),
            .Size = New Size(width, height),
            .Anchor = AnchorStyles.None
        }

        ' Status Label (PENDING or COMPLETED)
        Dim lblStatus As New Label With {
            .Text = status,
            .Font = New Font("Roboto Bk", 24F, FontStyle.Regular),
            .ForeColor = statusColor,
            .Location = New Point(21, 17),
            .AutoSize = True
        }
        pnl.Controls.Add(lblStatus)

        ' Task Title/ID in top right
        Dim rtbTitle As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(192, 16),
            .Size = New Size(136, 52),
            .ReadOnly = True,
            .Text = task.Title
        }
        pnl.Controls.Add(rtbTitle)

        ' SUBJECT Link and TextBox
        Dim lnkSubject As New LinkLabel With {
            .Text = "SUBJECT",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(21, 76),
            .AutoSize = True
        }
        AddHandler lnkSubject.Click, Sub(sender As Object, e As EventArgs)
                                        Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = task.SubjectID)
                                        If subject IsNot Nothing Then
                                            Session.SelectedSubject = subject
                                            NavigateToForm(New Form7Subject())
                                        End If
                                    End Sub
        pnl.Controls.Add(lnkSubject)

        Dim rtbSubject As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 104),
            .Size = New Size(307, 32),
            .ReadOnly = True,
            .Text = task.SubjectName
        }
        pnl.Controls.Add(rtbSubject)

        ' INSTRUCTOR Link and TextBox
        Dim lnkInstructor As New LinkLabel With {
            .Text = "INSTRUCTOR",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(21, 161),
            .AutoSize = True
        }
        AddHandler lnkInstructor.Click, Sub(sender As Object, e As EventArgs)
                                           NavigateToForm(New Form3Instructor())
                                       End Sub
        pnl.Controls.Add(lnkInstructor)

        Dim rtbInstructor As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 189),
            .Size = New Size(307, 32),
            .ReadOnly = True,
            .Text = task.InstructorName
        }
        pnl.Controls.Add(rtbInstructor)

        ' DEADLINE Link and TextBox
        Dim lnkDeadline As New LinkLabel With {
            .Text = "DEADLINE",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(21, 252),
            .AutoSize = True
        }
        AddHandler lnkDeadline.Click, Sub(sender As Object, e As EventArgs)
                                         NavigateToForm(New Form8Deadline())
                                     End Sub
        pnl.Controls.Add(lnkDeadline)

        Dim rtbDeadline As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 280),
            .Size = New Size(307, 32),
            .ReadOnly = True,
            .Text = task.Deadline.ToString("yyyy-MM-dd HH:mm")
        }
        pnl.Controls.Add(rtbDeadline)

        Return pnl
    End Function

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs)
        ' Handled in PopulateTaskPanel
    End Sub

    Private Sub LinkLabel2_Click(sender As Object, e As EventArgs)
        ' Handled in PopulateTaskPanel
    End Sub

    Private Sub LinkLabel3_Click(sender As Object, e As EventArgs)
        ' Handled in PopulateTaskPanel
    End Sub

    Private Function GetNextMotivationalWord() As String
        If motivationalWords.Count = 0 Then Return "Keep up the great work!"
        Dim word = motivationalWords(currentMotivationalIndex)
        currentMotivationalIndex = (currentMotivationalIndex + 1) Mod motivationalWords.Count
        Return word
    End Function

    Private Sub NavigateToForm(form As Form)
        Try
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing AndAlso TypeOf parentForm Is Form2 Then
                Dim form2 = DirectCast(parentForm, Form2)
                form2.ShowInContent(form)
            Else
                form.ShowDialog(Me)
        End If
        Catch ex As Exception
            form.ShowDialog(Me)
        End Try
    End Sub
End Class
