Public Class Form7Subject
    Private currentUser As User
    Private allSubjects As List(Of Subject)
    Private allTasks As List(Of Task)

    Private Sub Form7Subject_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Subject", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Remove scrollbars from RichTextBoxes
        RichTextBox1.ScrollBars = RichTextBoxScrollBars.None
        RichTextBox3.ScrollBars = RichTextBoxScrollBars.None

        ' Ensure Panel4 and Panel5 are visible and brought to front
        Panel4.Visible = True
        Panel5.Visible = True
        Panel4.BringToFront()
        Panel5.BringToFront()

        ' Load tasks and subjects
        allTasks = DataStore.LoadTasks()
        allSubjects = DataStore.LoadSubjects()

        ' Load and display subjects
        LoadSubjects()
    End Sub

    Private Sub LoadSubjects()
        ' Clear existing dynamic controls from Panel3 (the scrollable container)
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel3.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Panel4 AndAlso ctrl IsNot Panel5 AndAlso ctrl IsNot VScrollBar1 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel3.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Get subjects from tasks - create subjects from tasks if they don't exist
        Dim subjectsWithTasks = allTasks.Select(Function(t) t.SubjectID).Distinct().ToList()
        Dim displayedSubjects = allSubjects.Where(Function(s) subjectsWithTasks.Contains(s.SubjectID)).ToList()

        ' If tasks exist but subjects don't, create subjects from tasks
        If allTasks.Count > 0 AndAlso displayedSubjects.Count = 0 Then
            ' Create subjects from unique task subject names
            Dim uniqueTaskSubjects = allTasks.Select(Function(t) New With {.SubjectName = t.SubjectName, .InstructorName = t.InstructorName, .SubjectID = t.SubjectID}).Distinct().ToList()
            For Each taskSubject In uniqueTaskSubjects
                ' Check if subject already exists by name
                Dim existingSubject = allSubjects.FirstOrDefault(Function(s) s.SubjectName = taskSubject.SubjectName)
                If existingSubject Is Nothing Then
                    ' Create a new subject from task data
                    Dim newSubject As New Subject With {
                        .SubjectID = taskSubject.SubjectID,
                        .SubjectName = taskSubject.SubjectName,
                        .InstructorName = taskSubject.InstructorName,
                        .InstructorID = allTasks.FirstOrDefault(Function(t) t.SubjectName = taskSubject.SubjectName)?.InstructorID,
                        .Department = "",
                        .Description = ""
                    }
                    allSubjects.Add(newSubject)
                    displayedSubjects.Add(newSubject)
                Else
                    displayedSubjects.Add(existingSubject)
                End If
            Next
        End If

        ' If still no subjects, show all subjects
        If displayedSubjects.Count = 0 Then
            displayedSubjects = allSubjects
        End If

        ' Debug: Ensure we have subjects to display
        If displayedSubjects.Count = 0 Then
            ' Show message if no subjects
            Dim rtb1 = Panel4.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1")
            If rtb1 IsNot Nothing Then
                rtb1.Text = "No subjects found. Please create subjects first."
            End If
        End If

        ' Use template Panel4 for first subject (left)
        Panel4.Visible = True
        Panel4.BringToFront()
        If displayedSubjects.Count > 0 Then
            PopulateSubjectPanel(Panel4, displayedSubjects(0), True)
        Else
            ' Show empty panel with message
            Dim rtbSubject = Panel4.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1")
            If rtbSubject IsNot Nothing Then
                rtbSubject.Text = "No subjects available"
            End If
        End If

        ' Use template Panel5 for second subject (right)
        Panel5.Visible = True
        Panel5.BringToFront()
        If displayedSubjects.Count > 1 Then
            PopulateSubjectPanel(Panel5, displayedSubjects(1), False)
        Else
            ' Hide Panel5 if only one or no subjects
            Panel5.Visible = False
        End If

        ' Calculate positions - start after template panels
        Dim startY As Integer = 122 + 422 + 10 ' After template panels, 2 lines gap (10 pixels)
        Dim panelWidth As Integer = 311
        Dim panelHeight As Integer = 422
        Dim spacing As Integer = 10 ' 2 lines gap (10 pixels)
        Dim leftX As Integer = 185 ' Panel4 X position
        Dim rightX As Integer = 526 ' Panel5 X position

        ' Display additional subjects dynamically
        Dim leftY As Integer = startY
        Dim rightY As Integer = startY

        For i As Integer = 2 To displayedSubjects.Count - 1
            Dim subject = displayedSubjects(i)
            Dim tasksForSubject = allTasks.Where(Function(t) t.SubjectID = subject.SubjectID).ToList()

            ' Alternate between left and right panels
            If i Mod 2 = 0 Then
                ' Left panel
                Dim pnlLeft = CreateSubjectPanel(subject, tasksForSubject, leftX, leftY, panelWidth, panelHeight, True)
                Panel3.Controls.Add(pnlLeft)
                leftY += panelHeight + spacing
            Else
                ' Right panel
                Dim pnlRight = CreateSubjectPanel(subject, tasksForSubject, rightX, rightY, panelWidth, panelHeight, False)
                Panel3.Controls.Add(pnlRight)
                rightY += panelHeight + spacing
            End If
        Next

        ' Enable scrolling - use Panel3 which is the scrollable container (Form3Student pattern)
        Dim maxHeight = Math.Max(leftY, rightY)
        If maxHeight < 544 Then maxHeight = 544 ' Minimum height
        Panel3.AutoScroll = True
        Panel3.AutoScrollMinSize = New Size(0, maxHeight + 100) ' Extra margin to prevent cutoff

        ' Force refresh to ensure panels are visible
        Panel3.Refresh()
        Panel4.Refresh()
        Panel5.Refresh()
        Me.Refresh()
    End Sub

    Private Sub PopulateSubjectPanel(pnl As Panel, subject As Subject, isLeftPanel As Boolean)
        ' Ensure panel is visible
        pnl.Visible = True
        pnl.BringToFront()

        ' Find controls within the panel
        Dim rtbSubject = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1" OrElse r.Name = "RichTextBox2")
        Dim rtbInstructor = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox3" OrElse r.Name = "RichTextBox4")
        Dim lnkSubject = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel1" OrElse l.Name = "LinkLabel4")
        Dim lnkInstructor = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel2" OrElse l.Name = "LinkLabel3")

        ' Update subject name
        If rtbSubject IsNot Nothing Then
            rtbSubject.Text = subject.SubjectName
            rtbSubject.Visible = True
        End If

        ' Update instructor name
        If rtbInstructor IsNot Nothing Then
            rtbInstructor.Text = subject.InstructorName
            rtbInstructor.Visible = True
        End If

        ' Update link handlers
        If lnkSubject IsNot Nothing Then
            AddHandler lnkSubject.Click, Sub(sender As Object, e As EventArgs)
                                            Session.SelectedSubject = subject
                                            If currentUser.Role = "Student" Then
                                                NavigateToForm(New Form4TasksStudent())
                                            Else
                                                NavigateToForm(New Form4TasksInstructor())
                                            End If
                                        End Sub
        End If

        If lnkInstructor IsNot Nothing Then
            AddHandler lnkInstructor.Click, Sub(sender As Object, e As EventArgs)
                                               NavigateToForm(New Form3Instructor())
                                           End Sub
        End If
    End Sub

    Private Function CreateSubjectPanel(subject As Subject, tasks As List(Of Task), x As Integer, y As Integer, width As Integer, height As Integer, isLeftPanel As Boolean) As Panel
        Dim pnl As New Panel With {
            .BackColor = Color.Lavender,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = New Point(x, y),
            .Size = New Size(width, height),
            .Anchor = AnchorStyles.None
        }

        ' SUBJECT LinkLabel
        Dim lnkSubject As New LinkLabel With {
            .Text = "SUBJECT",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(26, 43),
            .AutoSize = True
        }
        AddHandler lnkSubject.Click, Sub(sender As Object, e As EventArgs)
                                        Session.SelectedSubject = subject
                                        If currentUser.Role = "Student" Then
                                            NavigateToForm(New Form4TasksStudent())
                                        Else
                                            NavigateToForm(New Form4TasksInstructor())
                                        End If
                                    End Sub
        pnl.Controls.Add(lnkSubject)

        ' Subject Name RichTextBox
        Dim rtbSubject As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(26, 71),
            .Size = New Size(259, 32),
            .ReadOnly = True,
            .Text = subject.SubjectName
        }
        pnl.Controls.Add(rtbSubject)

        ' PictureBox
        Dim picBox As New PictureBox With {
            .BackColor = Color.SkyBlue,
            .BackgroundImageLayout = ImageLayout.Zoom,
            .BorderStyle = BorderStyle.Fixed3D,
            .Location = New Point(26, 109),
            .Size = New Size(259, 195),
            .TabStop = False
        }
        Try
            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form7Subject))
            picBox.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
        Catch
        End Try
        pnl.Controls.Add(picBox)

        ' INSTRUCTOR LinkLabel
        Dim lnkInstructor As New LinkLabel With {
            .Text = "INSTRUCTOR",
            .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular),
            .LinkColor = Color.MidnightBlue,
            .Location = New Point(26, 321),
            .AutoSize = True
        }
        AddHandler lnkInstructor.Click, Sub(sender As Object, e As EventArgs)
                                           NavigateToForm(New Form3Instructor())
                                       End Sub
        pnl.Controls.Add(lnkInstructor)

        ' Instructor Name RichTextBox
        Dim rtbInstructor As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(26, 349),
            .Size = New Size(253, 32),
            .ReadOnly = True,
            .Text = subject.InstructorName
        }
        pnl.Controls.Add(rtbInstructor)

        ' Make panel clickable to navigate to tasks
        AddHandler pnl.Click, Sub(sender As Object, e As EventArgs)
                                 Session.SelectedSubject = subject
                                 If currentUser.Role = "Student" Then
                                     NavigateToForm(New Form4TasksStudent())
                                 Else
                                     NavigateToForm(New Form4TasksInstructor())
                                 End If
                             End Sub

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

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Go to Tasks
        NavigateToForm(If(currentUser.Role = "Student", New Form4TasksStudent(), New Form4TasksInstructor()))
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        ' Go to Instructor view
        NavigateToForm(New Form3Instructor())
    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ' Go to Tasks
        NavigateToForm(If(currentUser.Role = "Student", New Form4TasksStudent, New Form4TasksInstructor))
    End Sub

    Private Sub LinkLabel3_LinkClicked_1(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ' Go to Instructor view
        NavigateToForm(New Form3Instructor)
    End Sub

    Private Sub RichTextBox1_MouseClick(sender As Object, e As MouseEventArgs) Handles RichTextBox1.MouseClick
        Dim rtb = DirectCast(sender, RichTextBox)
        Dim charIndex = rtb.GetCharIndexFromPosition(e.Location)
        Dim lineIndex = rtb.GetLineFromCharIndex(charIndex)
        Dim lineText = rtb.Lines(lineIndex)

        ' Find subject that matches the clicked line
        For Each subject In allSubjects
            If lineText.Contains(subject.SubjectName) Then
                Session.SelectedSubject = subject
                NavigateToForm(If(currentUser.Role = "Student", New Form4TasksStudent(), New Form4TasksInstructor()))
                Return
            End If
        Next
    End Sub

    Private Sub RichTextBox2_MouseClick(sender As Object, e As MouseEventArgs)
        Dim rtb = DirectCast(sender, RichTextBox)
        Dim charIndex = rtb.GetCharIndexFromPosition(e.Location)
        Dim lineIndex = rtb.GetLineFromCharIndex(charIndex)
        Dim lineText = rtb.Lines(lineIndex)

        ' Find subject that matches the clicked line
        For Each subject In allSubjects
            If lineText.Contains(subject.SubjectName) Then
                Session.SelectedSubject = subject
                NavigateToForm(If(currentUser.Role = "Student", New Form4TasksStudent, New Form4TasksInstructor))
                Return
            End If
        Next
    End Sub
End Class
