Public Class Form6GradesInstructor
    Private currentUser As User
    Private allStudents As List(Of User)
    Private allGrades As List(Of Grade)
    Private selectedStudent As User = Nothing
    Private selectedSubject As Subject = Nothing

    Private Sub Form6GradesInstructor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Grades", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Load students and grades
        allStudents = DataStore.LoadUsers("Student")
        allGrades = DataStore.LoadGrades("")

        ' Load student list
        LoadStudentList()

        ' Hide grade input panel initially
        Panel4.Visible = False
    End Sub

    Private Sub LoadStudentList()
        ' Clear existing dynamic controls
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel5.Controls
            If ctrl IsNot Label3 AndAlso ctrl IsNot RichTextBox5 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel5.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Update RichTextBox5 to show student list
        Dim studentListText As New System.Text.StringBuilder()
        studentListText.AppendLine()
        For Each student In allStudents
            studentListText.AppendLine($"👤 {student.FirstName} {student.LastName} ({student.Username})")
        Next
        RichTextBox5.Text = studentListText.ToString()
        RichTextBox5.ReadOnly = True

        ' Make RichTextBox5 clickable for student selection
        AddHandler RichTextBox5.MouseClick, AddressOf RichTextBox5_MouseClick
    End Sub

    Private Sub RichTextBox5_MouseClick(sender As Object, e As MouseEventArgs)
        ' Get clicked line
        Dim rtb = DirectCast(sender, RichTextBox)
        Dim charIndex = rtb.GetCharIndexFromPosition(e.Location)
        Dim lineIndex = rtb.GetLineFromCharIndex(charIndex)
        Dim lineText = rtb.Lines(lineIndex)

        ' Find student from clicked line
        For Each student In allStudents
            If lineText.Contains(student.Username) Then
                selectedStudent = student
                LoadStudentGradePanel(student)
                Return
            End If
        Next
    End Sub

    Private Sub LoadStudentGradePanel(student As User)
        Panel4.Visible = True

        ' Update panel with student info
        Label5.Text = "STUDENT NAME"
        RichTextBox3.Text = $"{student.FirstName} {student.LastName}"

        ' Get tasks/subjects for this instructor
        Dim allTasks = DataStore.LoadTasks()
        Dim instructorTasks = allTasks.Where(Function(t) t.InstructorID = currentUser.Username).ToList()
        Dim subjects = DataStore.LoadSubjects().Where(Function(s) s.InstructorID = currentUser.Username).ToList()

        ' Get existing grades for this student (can have multiple grades for different subjects)
        Dim existingGrades = allGrades.Where(Function(g) g.StudentID = student.Username).ToList()
        
        ' Show first grade if exists, or allow input for new grade
        Dim existingGrade = existingGrades.FirstOrDefault()

        If existingGrade IsNot Nothing Then
            ' Show existing grade
            RichTextBox1.Text = existingGrade.SubjectName
            RichTextBox9.Text = $"{existingGrade.Score}/{existingGrade.TotalScore}"
        Else
            ' Clear fields and allow input
            RichTextBox1.Text = ""
            RichTextBox9.Text = ""
        End If

        ' Set up links
        RemoveHandler LinkLabel1.Click, AddressOf LinkLabel1_Click

        AddHandler LinkLabel1.Click, AddressOf LinkLabel1_Click


        ' Add save button if not exists
        Dim existingBtn = Panel4.Controls.OfType(Of Button)().FirstOrDefault()
        If existingBtn Is Nothing Then
            Dim btnSave As New Button With {
                .Text = "SAVE GRADE",
                .Font = New Font("Roboto", 12F, FontStyle.Bold),
                .BackColor = Color.Green,
                .ForeColor = Color.White,
                .Location = New Point(21, 280),
                .Size = New Size(150, 35),
                .FlatStyle = FlatStyle.Flat
            }
            AddHandler btnSave.Click, AddressOf SaveGrade
            Panel4.Controls.Add(btnSave)
        End If
    End Sub

    Private Sub LinkLabel1_Click(sender As Object, e As EventArgs)
        ' Navigate to Subject form
        If selectedSubject IsNot Nothing Then
            Session.SelectedSubject = selectedSubject
        End If
        NavigateToForm(New Form7Subject())
    End Sub

    Private Sub LinkLabel2_Click(sender As Object, e As EventArgs)
        ' Navigate to Instructor form
        NavigateToForm(New Form3Instructor())
    End Sub

    Private Sub RichTextBox9_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox9.TextChanged
        ' Allow instructor to input score
        If selectedStudent IsNot Nothing Then
            ' Score input is handled here
        End If
    End Sub

    Private Sub SaveGrade(sender As Object, e As EventArgs)
        If selectedStudent Is Nothing Then
            MessageBox.Show("Please select a student first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Dim scoreText = RichTextBox9.Text.Trim()
            If String.IsNullOrEmpty(scoreText) Then
                MessageBox.Show("Please enter a score.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim scoreParts = scoreText.Split("/"c)
            Dim score As Decimal = 0
            Dim totalScore As Decimal = 100

            If scoreParts.Length = 2 Then
                Decimal.TryParse(scoreParts(0).Trim(), score)
                Decimal.TryParse(scoreParts(1).Trim(), totalScore)
            Else
                Decimal.TryParse(scoreText, score)
            End If

            If score < 0 OrElse score > totalScore Then
                MessageBox.Show($"Score must be between 0 and {totalScore}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim subjectName = RichTextBox1.Text.Trim()
            If String.IsNullOrEmpty(subjectName) Then
                MessageBox.Show("Please enter a subject.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            ' Get or create subject
            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectName = subjectName)
            Dim subjectID = If(subject IsNot Nothing, subject.SubjectID, "General")

            ' Create grade
            Dim grade As New Grade With {
                .GradeID = Guid.NewGuid().ToString(), ' Ensure GradeID is set
                .StudentID = selectedStudent.Username,
                .StudentName = $"{selectedStudent.FirstName} {selectedStudent.LastName}",
                .SubjectID = subjectID,
                .SubjectName = subjectName,
                .InstructorID = currentUser.Username,
                .InstructorName = $"{currentUser.FirstName} {currentUser.LastName}",
                .Score = score,
                .TotalScore = totalScore,
                .Percentage = (score / totalScore) * 100,
                .DateSubmitted = Now
            }

            ' Calculate letter grade
            If grade.Percentage >= 90 Then
                grade.LetterGrade = "A"
            ElseIf grade.Percentage >= 80 Then
                grade.LetterGrade = "B"
            ElseIf grade.Percentage >= 70 Then
                grade.LetterGrade = "C"
            ElseIf grade.Percentage >= 60 Then
                grade.LetterGrade = "D"
            Else
                grade.LetterGrade = "F"
            End If

            ' Save grade
            If DataStore.SaveGrade(grade) Then
                MessageBox.Show($"Grade saved for {selectedStudent.FirstName} {selectedStudent.LastName}!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                ' Reload all grades to get updated list
                allGrades = DataStore.LoadGrades("")
                ' Refresh the student grade panel to show updated grade
                LoadStudentGradePanel(selectedStudent)
            Else
                MessageBox.Show("Failed to save grade.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Error saving grade: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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

    ' Add button click handler for saving (if button exists in Designer)
    Private Sub RichTextBox9_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox9.KeyDown
        If e.KeyCode = Keys.Enter Then
            SaveGrade(sender, e)
        End If
    End Sub

    Private Sub SaveGrade()
        SaveGrade(Nothing, EventArgs.Empty)
    End Sub

    Private Sub RichTextBox5_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox5.TextChanged

    End Sub
End Class
