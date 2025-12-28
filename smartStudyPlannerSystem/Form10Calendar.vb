Public Class Form10Calendar
    Private currentUser As User
    Private allTasks As List(Of Task)
    Private selectedDate As DateTime = Now

    Private Sub Form10Calendar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Calendar", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        LoadCalendarEvents()
    End Sub


    Private Sub Form10Calendar_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso currentUser IsNot Nothing Then

            LoadCalendarEvents()
        End If
    End Sub

    Private Sub LoadCalendarEvents()

        allTasks = DataStore.LoadTasks("")


        Dim allSubmissions = DataStore.LoadSubmissions()
        Dim submittedTaskIDs As New HashSet(Of String)
        If currentUser.Role = "Student" Then
            submittedTaskIDs = New HashSet(Of String)(allSubmissions.Where(Function(s) s.StudentID = currentUser.Username).Select(Function(s) s.TaskID))
        End If


        Dim userTasks As List(Of Task)
        If currentUser.Role = "Instructor" Then

            userTasks = allTasks.Where(Function(t) t.InstructorID = currentUser.Username).ToList()
        Else
            userTasks = allTasks
        End If


        selectedDate = Now

        UpdateStatistics(userTasks, submittedTaskIDs)


        UpdateUpcomingTasks(selectedDate, userTasks, submittedTaskIDs)
    End Sub

    Private Sub UpdateStatistics(userTasks As List(Of Task), submittedTaskIDs As HashSet(Of String))

        Dim nonSubmittedTasks = userTasks.Where(Function(t) Not submittedTaskIDs.Contains(t.TaskID)).ToList()


        Dim activeTasks = nonSubmittedTasks.Where(Function(t) t.GetStatus() = "Active").Count()
        Dim dueSoonTasks = nonSubmittedTasks.Where(Function(t) t.GetStatus() = "Due Soon").Count()
        Dim overdueTasks = nonSubmittedTasks.Where(Function(t) t.GetStatus() = "Overdue").Count()
        Dim totalTasks = nonSubmittedTasks.Count


        RichTextBox1.Text = activeTasks.ToString()
        RichTextBox2.Text = dueSoonTasks.ToString()
        RichTextBox3.Text = overdueTasks.ToString()
        RichTextBox4.Text = totalTasks.ToString()
    End Sub


    Private Sub UpdateUpcomingTasks(selectedDate As DateTime, userTasks As List(Of Task), submittedTaskIDs As HashSet(Of String))

        Dim selectedDateTasks = userTasks.Where(Function(t) t.Deadline.Date = selectedDate.Date).OrderBy(Function(t) t.Deadline).ToList()


        Dim nextWeekTasks = userTasks.Where(Function(t) t.Deadline.Date > selectedDate.Date AndAlso t.Deadline.Date <= selectedDate.AddDays(7).Date).OrderBy(Function(t) t.Deadline).ToList()


        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel8.Controls

            If TypeOf ctrl Is Label Then
                Dim lbl = DirectCast(ctrl, Label)
                If lbl.Name = "Label4" OrElse lbl.Text.Contains("No Task Added") Then
                    Continue For
                End If
            End If

            controlsToRemove.Add(ctrl)
        Next
        For Each ctrl In controlsToRemove
            Panel8.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next


        Dim label4 = Panel8.Controls.OfType(Of Label)().FirstOrDefault(Function(l) l.Name = "Label4" OrElse l.Text.Contains("No Task Added"))
        If label4 IsNot Nothing Then
            label4.Visible = (selectedDateTasks.Count = 0 AndAlso nextWeekTasks.Count = 0)
        End If

        Dim templateWidth As Integer = 295
        Dim templateHeight As Integer = 124
        Dim spacing As Integer = 10 '
        Dim leftStartX As Integer = 99
        Dim startY As Integer = 82


        Dim allDisplayTasks = selectedDateTasks.Concat(nextWeekTasks).OrderBy(Function(t) t.Deadline).ToList()


        If allDisplayTasks.Count > 0 Then
            Dim yPos As Integer = startY
            For i As Integer = 0 To allDisplayTasks.Count - 1
                Dim task = allDisplayTasks(i)
                Dim isSubmitted = submittedTaskIDs.Contains(task.TaskID)
                Dim rtbTask = CreateTaskRichTextBox(task, leftStartX, yPos, templateWidth, templateHeight, isSubmitted)
                Panel8.Controls.Add(rtbTask)
                yPos += templateHeight + spacing
            Next
        End If

        Dim maxHeight = If(allDisplayTasks.Count > 0, startY + (allDisplayTasks.Count * (templateHeight + spacing)), 0)
        If maxHeight > 0 Then
            Panel8.AutoScroll = True
            Panel8.AutoScrollMinSize = New Size(0, maxHeight + 100)
        End If
    End Sub

    Private Function CreateTaskRichTextBox(task As Task, x As Integer, y As Integer, width As Integer, height As Integer, isSubmitted As Boolean) As RichTextBox
        Dim timeRemaining = task.Deadline - Now
        Dim daysRemaining = CInt(timeRemaining.TotalDays)
        Dim hoursRemaining = CInt(timeRemaining.TotalHours)
        Dim hoursText = If(hoursRemaining < 0, $"Overdue by {Math.Abs(hoursRemaining)} hours", $"{hoursRemaining} hours remaining")
        Dim daysText = If(daysRemaining < 0, $"Overdue by {Math.Abs(daysRemaining)} days", $"{daysRemaining} days remaining")

        Dim rtbTask As New RichTextBox With {
            .BackColor = Color.Lavender,
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
            .ForeColor = If(isSubmitted, Color.Green, Color.MidnightBlue),
            .Location = New Point(x, y),
            .Size = New Size(width, height),
            .ReadOnly = True,
            .Name = $"RichTextBox_Task_{task.TaskID}"
        }

        Dim taskText As String
        If isSubmitted Then
            taskText = $"✅ DONE SUBMIT" & vbCrLf &
                      $"Date: {task.Deadline:yyyy-MM-dd}" & vbCrLf &
                      $"SUBJECT: {task.SubjectName}" & vbCrLf &
                      $"DEADLINE: {task.Deadline:yyyy-MM-dd HH:mm}"
        Else
            taskText = $"Date: {task.Deadline:yyyy-MM-dd}" & vbCrLf &
                      $"SUBJECT: {task.SubjectName}" & vbCrLf &
                      $"DEADLINE: {task.Deadline:yyyy-MM-dd HH:mm}" & vbCrLf &
                      $"{daysText}" & vbCrLf &
                      $"{hoursText}"
        End If
        rtbTask.Text = taskText

        rtbTask.SelectAll()
        rtbTask.SelectionAlignment = HorizontalAlignment.Center
        rtbTask.DeselectAll()
        
        Return rtbTask
    End Function


    Private Sub MonthCalendar1_DateChanged_1(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        selectedDate = e.End
        allTasks = DataStore.LoadTasks("")

        Dim allSubmissions = DataStore.LoadSubmissions()
        Dim submittedTaskIDs As New HashSet(Of String)
        If currentUser.Role = "Student" Then
            submittedTaskIDs = New HashSet(Of String)(allSubmissions.Where(Function(s) s.StudentID = currentUser.Username).Select(Function(s) s.TaskID))
        End If
        
        Dim userTasks As List(Of Task)
        If currentUser.Role = "Instructor" Then
            userTasks = allTasks.Where(Function(t) t.InstructorID = currentUser.Username).ToList()
        Else
            userTasks = allTasks
        End If

        UpdateStatistics(userTasks, submittedTaskIDs)

        UpdateUpcomingTasks(selectedDate, userTasks, submittedTaskIDs)
    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub
End Class
