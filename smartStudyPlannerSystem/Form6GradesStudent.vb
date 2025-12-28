Public Class Form6GradesStudent
    Private currentUser As User
    Private currentGrades As List(Of Grade)
    Private motivationalWords As List(Of String)
    Private currentMotivationalIndex As Integer = 0

    Private Sub Form6GradesStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Grades", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Initialize motivational words (20+ words)
        InitializeMotivationalWords()

        ' Load and display grades
        LoadStudentGrades()
    End Sub

    ' Refresh grades when form becomes visible (real-time updates)
    Private Sub Form6GradesStudent_VisibleChanged(sender As Object, e As EventArgs) Handles MyBase.VisibleChanged
        If Me.Visible AndAlso currentUser IsNot Nothing Then
            ' Reload grades to get latest updates from instructor
            LoadStudentGrades()
        End If
    End Sub

    Private Sub InitializeMotivationalWords()
        motivationalWords = New List(Of String) From {
            "🌟 Every score is a step forward in your learning journey!",
            "💪 Your dedication to learning is inspiring!",
            "🎯 Keep pushing yourself - you're doing great!",
            "✨ Every grade reflects your effort and growth!",
            "🚀 Success is built one assignment at a time!",
            "📚 Knowledge gained is never wasted!",
            "🏆 Your progress matters more than perfection!",
            "💡 Mistakes are proof that you're trying!",
            "🌈 Every challenge makes you stronger!",
            "🔥 Your hard work is paying off!",
            "⭐ Believe in your ability to improve!",
            "🎓 Education is your superpower!",
            "💎 You're becoming more capable every day!",
            "🌱 Growth happens when you challenge yourself!",
            "🎨 Your learning journey is unique and valuable!",
            "⚡ Keep going - you're on the right track!",
            "🌟 Your scores show your commitment!",
            "📖 Every subject you master opens new doors!",
            "🎯 Focus on learning, not just grades!",
            "💪 You have the power to improve!",
            "🚀 Your future self will thank you!",
            "✨ Excellence is a habit, not an act!",
            "🏅 Keep striving for your best!",
            "🌻 You're blooming into your potential!",
            "🎪 Your effort today shapes your tomorrow!"
        }
    End Sub

    Private Sub LoadStudentGrades()
        ' Clear existing dynamic controls (keep template panels: Panel4, Panel6, Panel5, and labels)
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel2.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Label2 AndAlso ctrl IsNot Label3 AndAlso ctrl IsNot Panel4 AndAlso ctrl IsNot Panel5 AndAlso ctrl IsNot Panel6 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel2.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Get grades for this student
        currentGrades = DataStore.LoadGrades("")
        Dim studentGrades = currentGrades.Where(Function(g) g.StudentID = currentUser.Username).ToList()

        ' Panel4 (SCORES) - Left side at (99, 70) - Use for first grade
        If studentGrades.Count > 0 Then
            PopulateGradePanel(Panel4, studentGrades(0))
            Panel4.Visible = True
            Panel4.Location = New Point(99, 70) ' Original design position
        Else
            Panel4.Visible = False
        End If

        ' Panel6 (OVERALL SCORES) - Right side at (475, 70) - Always visible
        Panel6.Visible = True
        Panel6.Location = New Point(475, 70) ' Original design position
        CalculateOverallScores(studentGrades)

        ' Calculate positions for additional grade panels (if more than one grade)
        ' Additional panels should be below Panel4, starting at Y = 70 + 349 + 10 = 429
        Dim startY As Integer = 70 + 349 + 10 ' After Panel4, 2 lines gap
        Dim panelWidth As Integer = 370
        Dim panelHeight As Integer = 349
        Dim spacing As Integer = 10 ' 2 lines gap (10 pixels)
        Dim leftX As Integer = 99 ' Same X as Panel4

        ' Display additional grades (skip first one, already in Panel4)
        Dim yPos As Integer = startY
        For i As Integer = 1 To studentGrades.Count - 1
            Dim pnlGrade = CreateGradePanel(studentGrades(i), leftX, yPos, panelWidth, panelHeight)
            Panel2.Controls.Add(pnlGrade)
            yPos += panelHeight + spacing
        Next

        ' Position Words of Encouragement at fixed position (original design)
        ' Label2 at (71, 451), Panel5 at (71, 500)
        Label2.Location = New Point(71, 451) ' Original design position
        Panel5.Location = New Point(71, 500) ' Original design position
        Panel5.Size = New Size(745, 125) ' Original design size

        ' Show motivational word
        RichTextBox5.Text = GetNextMotivationalWord()

        ' Enable scrolling - ensure all content is accessible
        ' Calculate max height: either additional panels or Words of Encouragement
        Dim maxHeight = Math.Max(yPos, 500 + 125) ' Words of Encouragement bottom
        Panel2.AutoScroll = True
        Panel2.AutoScrollMinSize = New Size(0, maxHeight + 100) ' Extra margin to prevent cutoff
    End Sub

    Private Sub PopulateGradePanel(pnl As Panel, grade As Grade)
        ' Find controls within the panel
        Dim rtbTitle = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox9")
        Dim rtbSubject = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox1")
        Dim rtbInstructor = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox3")
        Dim rtbTotal = pnl.Controls.OfType(Of RichTextBox)().FirstOrDefault(Function(r) r.Name = "RichTextBox2")
        Dim lnkSubject = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel1")
        Dim lnkInstructor = pnl.Controls.OfType(Of LinkLabel)().FirstOrDefault(Function(l) l.Name = "LinkLabel2")

        ' Update title
        If rtbTitle IsNot Nothing Then
            rtbTitle.Text = grade.SubjectName
        End If

        ' Update subject
        If rtbSubject IsNot Nothing Then
            rtbSubject.Text = grade.SubjectName
        End If

        ' Update instructor
        If rtbInstructor IsNot Nothing Then
            rtbInstructor.Text = If(String.IsNullOrEmpty(grade.InstructorName), "N/A", grade.InstructorName)
        End If

        ' Update total scores
        If rtbTotal IsNot Nothing Then
            rtbTotal.Text = $"{grade.Score}/{grade.TotalScore} ({grade.Percentage:F1}%) - {grade.LetterGrade}"
        End If

        ' Update link handlers
        If lnkSubject IsNot Nothing Then
            AddHandler lnkSubject.Click, Sub(sender As Object, e As EventArgs)
                                            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = grade.SubjectID)
                                            If subject IsNot Nothing Then
                                                Session.SelectedSubject = subject
                                                NavigateToForm(New Form7Subject())
                                            End If
                                        End Sub
        End If

        If lnkInstructor IsNot Nothing Then
            AddHandler lnkInstructor.Click, Sub(sender As Object, e As EventArgs)
                                               NavigateToForm(New Form3Instructor())
                                           End Sub
        End If
    End Sub


    Private Function CreateGradePanel(grade As Grade, x As Integer, y As Integer, width As Integer, height As Integer) As Panel
        Dim pnl As New Panel With {
            .BackColor = Color.Lavender,
            .BorderStyle = BorderStyle.FixedSingle,
            .Location = New Point(x, y),
            .Size = New Size(width, height),
            .Anchor = AnchorStyles.None
        }

        ' SCORES Label
        Dim lblScores As New Label With {
            .Text = "SCORES",
            .Font = New Font("Roboto Bk", 24F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 26),
            .AutoSize = True
        }
        pnl.Controls.Add(lblScores)

        ' Task/Subject Title in top right
        Dim rtbTitle As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(164, 16),
            .Size = New Size(164, 52),
            .ReadOnly = True,
            .Text = grade.SubjectName
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
                                        Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = grade.SubjectID)
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
            .Text = grade.SubjectName
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
            .Text = grade.InstructorName
        }
        pnl.Controls.Add(rtbInstructor)

        ' TOTAL SCORES Label and TextBox
        Dim lblTotal As New Label With {
            .Text = "TOTAL SCORES",
            .Font = New Font("Roboto Bk", 15F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 247),
            .AutoSize = True
        }
        pnl.Controls.Add(lblTotal)

        Dim rtbTotal As New RichTextBox With {
            .BorderStyle = BorderStyle.None,
            .Font = New Font("Segoe UI", 12F, FontStyle.Regular),
            .ForeColor = Color.MidnightBlue,
            .Location = New Point(21, 274),
            .Size = New Size(307, 32),
            .ReadOnly = True,
            .Text = $"{grade.Score}/{grade.TotalScore} ({grade.Percentage:F1}%) - {grade.LetterGrade}"
        }
        pnl.Controls.Add(rtbTotal)

        Return pnl
    End Function

    Private Sub CalculateOverallScores(studentGrades As List(Of Grade))
        If studentGrades.Count = 0 Then
            RichTextBox7.Text = "No grades available yet."
            Return
        End If

        Dim totalScore = studentGrades.Sum(Function(g) g.Score)
        Dim totalPossible = studentGrades.Sum(Function(g) g.TotalScore)
        Dim overallPercentage = If(totalPossible > 0, (totalScore / totalPossible) * 100, 0)
        Dim subjectsCount = studentGrades.Select(Function(g) g.SubjectID).Distinct().Count()

        Dim overallText As New System.Text.StringBuilder()
        overallText.AppendLine("OVERALL SCORES")
        overallText.AppendLine()
        overallText.AppendLine($"Total Subjects: {subjectsCount}")
        overallText.AppendLine($"Total Score: {totalScore}/{totalPossible}")
        overallText.AppendLine($"Overall Percentage: {overallPercentage:F1}%")
        overallText.AppendLine()
        overallText.AppendLine("By Subject:")
        For Each subjectGroup In studentGrades.GroupBy(Function(g) g.SubjectName)
            Dim subjectTotal = subjectGroup.Sum(Function(g) g.Score)
            Dim subjectPossible = subjectGroup.Sum(Function(g) g.TotalScore)
            Dim subjectPct = If(subjectPossible > 0, (subjectTotal / subjectPossible) * 100, 0)
            overallText.AppendLine($"  {subjectGroup.Key}: {subjectTotal}/{subjectPossible} ({subjectPct:F1}%)")
        Next

        RichTextBox7.Text = overallText.ToString()
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
