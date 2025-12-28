Public Class Form8Deadline
    Private currentUser As User
    Private allTasks As List(Of Task)

    Private Sub Form8Deadline_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Deadline", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Load gradient background image
        Try
            Dim bgPath = System.IO.Path.Combine(Application.StartupPath, "BG", "gradient.png")
            If System.IO.File.Exists(bgPath) Then
                Panel1.BackgroundImage = Image.FromFile(bgPath)
                Panel1.BackgroundImageLayout = ImageLayout.Stretch
            End If
        Catch
            ' If image loading fails, use default background
        End Try

        ' Load and display deadlines
        LoadDeadlines()
    End Sub

    ' Refresh deadlines when form becomes visible (real-time updates)
    Private Sub Form8Deadline_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso currentUser IsNot Nothing Then
            ' Reload deadlines to get latest submission status
            LoadDeadlines()
        End If
    End Sub

    Private Sub LoadDeadlines()
        ' Clear existing dynamic controls from Panel3 (where additional panels are added)
        ' Keep Panel4 and Panel6 (template panels) and VScrollBar1
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel3.Controls
            If ctrl IsNot Panel4 AndAlso ctrl IsNot Panel6 AndAlso ctrl IsNot VScrollBar1 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel3.Controls.Remove(ctrl)
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

        ' Use template Panel4 for first task (left) - Panel4 is at (23, 23) within Panel3
        If userTasks.Count > 0 Then
            PopulateTaskPanelTemplate(Panel4, userTasks(0), submittedTaskIDs.Contains(userTasks(0).TaskID))
            AttachViewTaskButton(Panel4, userTasks(0))
            Panel4.Visible = True
        Else
            Panel4.Visible = False
        End If

        Dim dynamicStartIndex As Integer = 2

        ' Use template Panel6 for second task (right) - Panel6 is at (420, 23) within Panel3
        If userTasks.Count > 1 Then
            If Panel6 IsNot Nothing Then
                PopulateTaskPanelTemplate(Panel6, userTasks(1), submittedTaskIDs.Contains(userTasks(1).TaskID))
                AttachViewTaskButton(Panel6, userTasks(1))
                Panel6.Visible = True
            Else
                dynamicStartIndex = 1
            End If
        Else
            If Panel6 IsNot Nothing Then
                Panel6.Visible = False
            End If
        End If

        ' Calculate positions - start after template panels within Panel3
        ' Panel4 and Panel6 are at Y=23 within Panel3, height=252
        ' So next row starts at 23 + 252 + 10 = 285 within Panel3
        Dim startY As Integer = 285 ' After template panels, 2 lines gap (within Panel3)
        Dim panelWidth As Integer = 368
        Dim panelHeight As Integer = 252 ' Original size from Designer
        Dim spacing As Integer = 10 ' 2 lines gap (10 pixels)
        Dim leftX As Integer = 23 ' Left panel X position within Panel3 (matching Panel4)
        Dim rightX As Integer = 420 ' Right panel X position within Panel3 (matching Panel6)

        ' Display additional tasks dynamically within Panel3
        Dim leftY As Integer = startY
        Dim rightY As Integer = startY

        For i As Integer = dynamicStartIndex To userTasks.Count - 1
            Dim task = userTasks(i)
            Dim isSubmitted = submittedTaskIDs.Contains(task.TaskID)

            ' Alternate between left and right panels
            If i Mod 2 = 0 Then
                Dim pnlLeft = CreateTaskPanel(task, leftX, leftY, panelWidth, panelHeight, isSubmitted)
                Panel3.Controls.Add(pnlLeft)
                leftY += panelHeight + spacing
            Else
                Dim pnlRight = CreateTaskPanel(task, rightX, rightY, panelWidth, panelHeight, isSubmitted)
                Panel3.Controls.Add(pnlRight)
                rightY += panelHeight + spacing
            End If
        Next

        ' Update Panel3 height to accommodate all content
        Dim maxHeight = Math.Max(leftY, rightY)
        If maxHeight < 305 Then maxHeight = 305 ' Minimum height from Designer
        Panel3.Height = maxHeight + 50 ' Add some padding

        ' Position Words of Encouragement below Panel3
        ' Panel3 is at (72, 101) in Panel2, so below it would be at 101 + Panel3.Height + spacing
        Dim panel3Bottom = 101 + Panel3.Height + 10
        Label2.Location = New Point(72, panel3Bottom)
        Panel5.Location = New Point(72, panel3Bottom + 45)
        Panel5.Size = New Size(765, 99)

        ' Show motivational word
        RichTextBox5.Text = GetMotivationalWord()

        ' Enable scrolling for Panel2 - ensure all content is accessible
        Dim totalHeight = panel3Bottom + 200 ' Extra margin for Words of Encouragement
        Panel2.AutoScroll = True
        Panel2.AutoScrollMinSize = New Size(0, totalHeight + 100) ' Extra margin to prevent cutoff
    End Sub

    Private Sub PopulateTaskPanelTemplate(pnl As Panel, task As Task, isSubmitted As Boolean)
        ' Find controls within the panel
        Dim rtbSubject = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1" OrElse r.Name = "RichTextBox3")
        Dim rtbDeadline = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox2" OrElse r.Name = "RichTextBox4")
        Dim lnkSubject = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel1" OrElse l.Name = "LinkLabel4")
        Dim lnkDeadline = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel3" OrElse l.Name = "LinkLabel2")

        ' Update subject
        If rtbSubject IsNot Nothing Then
            rtbSubject.Text = task.SubjectName
        End If

        ' Update deadline with submission status
        If rtbDeadline IsNot Nothing Then
            Dim daysRemaining = CInt(Math.Floor((task.Deadline - Now).TotalDays))
            Dim hoursRemaining = CInt(Math.Floor((task.Deadline - Now).TotalHours)) Mod 24
            Dim deadlineText As String
            If isSubmitted Then
                deadlineText = $"✅ DONE SUBMIT" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
            ElseIf daysRemaining > 0 Then
                deadlineText = $"{daysRemaining} days, {hoursRemaining} hours remaining" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
            ElseIf daysRemaining = 0 AndAlso hoursRemaining > 0 Then
                deadlineText = $"{hoursRemaining} hours remaining" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
            Else
                deadlineText = "⚠️ OVERDUE" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
            End If
            rtbDeadline.Text = deadlineText
            ' Enable multiline and adjust height if needed
            rtbDeadline.Multiline = True
            rtbDeadline.Height = 50 ' Increase height to accommodate two lines
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

    Private Function CreateTaskPanel(task As Task, x As Integer, y As Integer, width As Integer, height As Integer, isSubmitted As Boolean) As Panel
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

        ' Subject TextBox - Using Roboto font, size 12 (matching Designer)
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

        ' Deadline TextBox - Using Roboto font, size 12 (matching Designer)
        Dim daysRemaining = CInt(Math.Floor((task.Deadline - Now).TotalDays))
        Dim hoursRemaining = CInt(Math.Floor((task.Deadline - Now).TotalHours)) Mod 24
        Dim deadlineText As String
        If isSubmitted Then
            deadlineText = $"✅ DONE SUBMIT" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
        ElseIf daysRemaining > 0 Then
            deadlineText = $"{daysRemaining} days, {hoursRemaining} hours remaining" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
        ElseIf daysRemaining = 0 AndAlso hoursRemaining > 0 Then
            deadlineText = $"{hoursRemaining} hours remaining" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
        Else
            deadlineText = "⚠️ OVERDUE" & vbCrLf & $"{task.Deadline:yyyy-MM-dd HH:mm}"
        End If
        
        Dim rtbDeadline As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = If(isSubmitted, Color.Green, Color.MidnightBlue),
            .Location = New Point(26, 155),
            .Size = New Size(304, 40), ' Increased height to accommodate two lines
            .Multiline = True,
            .ReadOnly = True,
            .Text = deadlineText
        }
        pnl.Controls.Add(rtbDeadline)
        
        ' Adjust button position if needed to avoid overlap
        Dim btnViewTask = pnl.Controls.OfType(Of Button)().FirstOrDefault()
        If btnViewTask IsNot Nothing Then
            btnViewTask.Location = New Point(26, 200) ' Keep original position
        End If

        AttachViewTaskButton(pnl, task)
        Return pnl
    End Function

    Private Sub OpenTaskDetail(task As Task)
        Dim detail = $"Task: {task.Title}{vbCrLf}"
        detail &= $"Subject: {task.SubjectName}{vbCrLf}"
        detail &= $"Instructor: {task.InstructorName}{vbCrLf}"
        detail &= $"Deadline: {task.Deadline:yyyy-MM-dd HH:mm}{vbCrLf}"
        detail &= $"Status: {task.GetStatus()}{vbCrLf}"
        detail &= $"Days Remaining: {task.GetDaysRemaining()}{vbCrLf}{vbCrLf}"
        detail &= $"Description:{vbCrLf}{task.Description}"

        MessageBox.Show(detail, "Task Details", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub AttachViewTaskButton(pnl As Panel, task As Task)
        If pnl Is Nothing OrElse task Is Nothing Then Return

        Dim button = pnl.Controls.OfType(Of Button)().FirstOrDefault(Function(b) b.Name = "Button1" OrElse b.Name = "Button2" OrElse b.Name = "btnViewTask")
        If button Is Nothing Then
            button = New Button With {
                .Name = "btnViewTask",
                .BackColor = Color.MidnightBlue,
                .ForeColor = Color.White,
                .FlatStyle = FlatStyle.Flat,
                .Font = New Font("Roboto", 11.25F, FontStyle.Bold),
                .Location = New Point(26, 200),
                .Size = New Size(140, 32),
                .Text = "VIEW TASK",
                .UseVisualStyleBackColor = False
            }
            button.FlatAppearance.BorderSize = 0
            pnl.Controls.Add(button)
        End If

        button.Tag = task
        RemoveHandler button.Click, AddressOf ViewTaskButton_Click
        AddHandler button.Click, AddressOf ViewTaskButton_Click
    End Sub

    Private Sub ViewTaskButton_Click(sender As Object, e As EventArgs)
        Dim btn = TryCast(sender, Button)
        If btn Is Nothing Then Return
        Dim task = TryCast(btn.Tag, Task)
        If task Is Nothing Then Return
        OpenTaskDetail(task)
    End Sub

    Private Function GetMotivationalWord() As String
        Dim words = New List(Of String) From {
            "🌟 Stay focused and meet your deadlines!",
            "💪 You can accomplish anything you set your mind to!",
            "🎯 Every deadline met is a victory!",
            "✨ Time management is the key to success!",
            "🚀 Keep pushing forward - you're doing great!"
        }
        Dim rnd As New Random()
        Return words(rnd.Next(words.Count))
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
