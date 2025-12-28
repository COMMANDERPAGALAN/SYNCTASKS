Public Class Form9Duration
    Private currentUser As User
    Private allTasks As List(Of Task)

    Private Sub Form9Duration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Duration", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Load and display duration/tasks
        LoadDurations()
    End Sub

    ' Refresh durations when form becomes visible (real-time updates)
    Private Sub Form9Duration_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso currentUser IsNot Nothing Then
            ' Reload durations to get latest submission status
            LoadDurations()
        End If
    End Sub

    Private Sub LoadDurations()
        ' Clear existing dynamic controls
        Dim hostPanel = Panel3
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In hostPanel.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Panel4 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            hostPanel.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Load all tasks
        allTasks = DataStore.LoadTasks()

        ' Load submissions to check which tasks are submitted
        Dim allSubmissions = DataStore.LoadSubmissions()
        Dim submittedTaskIDs As New HashSet(Of String)
        If currentUser.Role = "Student" Then
            submittedTaskIDs = New HashSet(Of String)(allSubmissions.Where(Function(s) s.StudentID = currentUser.Username).Select(Function(s) s.TaskID))
        End If

        ' Get tasks relevant to user
        Dim userTasks As List(Of Task)
        If currentUser.Role = "Instructor" Then
            userTasks = allTasks.Where(Function(t) t.InstructorID = currentUser.Username).ToList()
        Else
            userTasks = allTasks
        End If

        ' Sort by deadline
        userTasks = userTasks.OrderBy(Function(t) t.Deadline).ToList()

        ' Use template Panel4 for first task
        If userTasks.Count > 0 Then
            PopulateDurationPanel(Panel4, userTasks(0), submittedTaskIDs.Contains(userTasks(0).TaskID))
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If

        ' Calculate positions - start after template panel
        Dim panelWidth As Integer = Panel4.Width
        Dim panelHeight As Integer = Panel4.Height
        Dim spacing As Integer = 10 ' 2 lines gap (10 pixels)
        Dim centerX As Integer = Panel4.Left
        Dim startY As Integer = Panel4.Top + panelHeight + spacing

        ' Display additional tasks dynamically (skip first one, already in Panel4)
        Dim yPos As Integer = startY
        For i As Integer = 1 To userTasks.Count - 1
            Dim isSubmitted = submittedTaskIDs.Contains(userTasks(i).TaskID)
            Dim pnl = CreateDurationPanel(userTasks(i), centerX, yPos, panelWidth, panelHeight, isSubmitted)
            hostPanel.Controls.Add(pnl)
            yPos += panelHeight + spacing
        Next

        ' Enable scrolling - ensure all content is accessible (Form3Student pattern)
        ' Add extra margin to prevent cutoff at bottom
        Dim totalHeight = yPos + 100
        If totalHeight < hostPanel.Height Then
            totalHeight = hostPanel.Height + 100
        End If
        hostPanel.AutoScroll = True
        hostPanel.AutoScrollMinSize = New Size(0, totalHeight + 100) ' Extra margin to prevent cutoff
    End Sub

    Private Sub PopulateDurationPanel(pnl As Panel, task As Task, isSubmitted As Boolean)
        ' Find controls within the panel
        Dim rtbSubject = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1")
        Dim rtbDeadline = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox2")
        Dim lnkSubject = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel1")
        Dim lnkDeadline = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel3")

        ' Update subject
        If rtbSubject IsNot Nothing Then
            rtbSubject.Text = task.SubjectName
        End If

        ' Update deadline with submission status
        If rtbDeadline IsNot Nothing Then
            Dim deadlineText As String
            If isSubmitted Then
                deadlineText = $"✅ DONE SUBMIT" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
            Else
                deadlineText = task.Deadline.ToString("yyyy-MM-dd HH:mm")
            End If
            rtbDeadline.Text = deadlineText
            rtbDeadline.ForeColor = If(isSubmitted, Color.Green, Color.MidnightBlue)
        End If

        ' Update link handlers
        If lnkSubject IsNot Nothing Then
            AddHandler lnkSubject.Click, Sub(sender As Object, e As EventArgs)
                                            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = task.SubjectID)
                                            If subject IsNot Nothing Then
                                                Session.SelectedSubject = subject
                                                NavigateToForm(New Form7Subject())
                                            End If
                                        End Sub
        End If

        If lnkDeadline IsNot Nothing Then
            AddHandler lnkDeadline.Click, Sub(sender As Object, e As EventArgs)
                                             NavigateToForm(New Form8Deadline())
                                         End Sub
        End If
    End Sub

    Private Function CreateDurationPanel(task As Task, x As Integer, y As Integer, width As Integer, height As Integer, isSubmitted As Boolean) As Panel
        Dim pnl As New Panel With {
            .BackColor = Color.Lavender,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = New Point(x, y),
            .Size = New Size(width, height),
            .Anchor = AnchorStyles.None
        }

        ' SUBJECT Link
        Dim lnkSubject As New LinkLabel With {
            .Text = "SUBJECT",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(26, 43),
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

        ' Subject TextBox
        Dim rtbSubject As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(26, 71),
            .Size = New Size(304, 32),
            .ReadOnly = True,
            .Text = task.SubjectName
        }
        pnl.Controls.Add(rtbSubject)

        ' DEADLINE Link
        Dim lnkDeadline As New LinkLabel With {
            .Text = "DEADLINE",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(26, 127),
            .AutoSize = True
        }
        AddHandler lnkDeadline.Click, Sub(sender As Object, e As EventArgs)
                                         NavigateToForm(New Form8Deadline())
                                     End Sub
        pnl.Controls.Add(lnkDeadline)

        ' Deadline TextBox with submission status
        Dim daysRemaining = task.GetDaysRemaining()
        Dim deadlineText As String
        If isSubmitted Then
            deadlineText = $"✅ DONE SUBMIT" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
        Else
            deadlineText = If(daysRemaining < 0, $"Overdue by {Math.Abs(daysRemaining)} days", $"{daysRemaining} days remaining")
            deadlineText = $"{task.Deadline:yyyy-MM-dd HH:mm}" & vbCrLf & deadlineText
        End If
        
        Dim rtbDeadline As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = If(isSubmitted, Color.Green, Color.MidnightBlue),
            .Location = New Point(26, 155),
            .Size = New Size(304, 50), ' Increased height to accommodate two lines
            .ReadOnly = True,
            .Text = deadlineText
        }
        pnl.Controls.Add(rtbDeadline)

        Return pnl
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
