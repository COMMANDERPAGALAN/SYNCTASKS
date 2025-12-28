Public Class Form3Student
    Private Sub Form3Student_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Student", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Load and display ONLY registered students
        LoadRegisteredStudents()
    End Sub

    ' Refresh students when form becomes visible (real-time updates)
    Private Sub Form3Student_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso Session.CurrentUser IsNot Nothing Then
            ' Reload students to get latest list
            LoadRegisteredStudents()
        End If
    End Sub

    Private Sub LoadRegisteredStudents()
        ' Create scrollable panel
        Dim scrollPanel As New Panel With {
            .AutoScroll = True,
            .Dock = DockStyle.Fill,
            .BackColor = Color.White,
            .BorderStyle = BorderStyle.FixedSingle
        }

        ' Load ONLY students
        Dim students = DataStore.LoadUsers("Student")

        ' Check if current user is an Instructor (can delete students)
        Dim isInstructor As Boolean = Session.CurrentUser IsNot Nothing AndAlso Session.CurrentUser.Role = "Instructor"

        Dim yPos As Integer = 20

        If students.Count = 0 Then
            Dim lblNoData As New Label With {
                .Text = "No students registered yet.",
                .Font = New Font("Segoe UI", 12),
                .AutoSize = True,
                .Location = New Point(20, 60),
                .ForeColor = Color.Gray
            }
            scrollPanel.Controls.Add(lblNoData)
        Else
            ' Display each student in a duplicated panel design
            For Each student In students
                Dim pnlStudent As New Panel With {
                    .BackColor = Color.Lavender,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Location = New Point(20, yPos),
                    .Size = New Size(755, 350)
                }

                ' PictureBox1 - Profile Picture (Right side)
                Dim pictureBox As New PictureBox With {
                    .BackColor = Color.MidnightBlue,
                    .BorderStyle = BorderStyle.Fixed3D,
                    .Location = New Point(487, 37),
                    .Size = New Size(222, 263),
                    .SizeMode = PictureBoxSizeMode.Zoom,
                    .TabStop = False
                }

                ' Try to load profile picture
                Try
                    Dim picturePath = System.IO.Path.Combine(Application.StartupPath, "UserPictures", $"{student.Username}_profile.jpg")
                    If System.IO.File.Exists(picturePath) Then
                        Using fs As New System.IO.FileStream(picturePath, System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite)
                            Using img = Image.FromStream(fs)
                                pictureBox.Image = New Bitmap(img)
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    ' Use default if no picture
                End Try

                pnlStudent.Controls.Add(pictureBox)

                ' Label2 - NAME label
                Dim label2 As New Label With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(42, 37),
                    .Text = "NAME",
                    .TabIndex = 5
                }
                pnlStudent.Controls.Add(label2)

                ' RichTextBox1 - NAME value (clickable if instructor)
                Dim rtb1 As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold),
                    .ForeColor = If(isInstructor, Color.Red, Color.MidnightBlue), ' Red color to indicate clickable for instructors
                    .Location = New Point(42, 65),
                    .ReadOnly = True,
                    .Size = New Size(394, 49),
                    .TabIndex = 6,
                    .Text = student.FirstName & " " & student.LastName,
                    .Cursor = If(isInstructor, Cursors.Hand, Cursors.Default) ' Show hand cursor if instructor
                }
                
                ' Store student in Tag for deletion
                rtb1.Tag = student
                
                ' Make clickable if instructor
                If isInstructor Then
                    AddHandler rtb1.MouseClick, AddressOf StudentName_Click
                    AddHandler rtb1.MouseEnter, Sub(sender As Object, e As EventArgs)
                                                    rtb1.ForeColor = Color.DarkRed
                                                End Sub
                    AddHandler rtb1.MouseLeave, Sub(sender As Object, e As EventArgs)
                                                    rtb1.ForeColor = Color.Red
                                                End Sub
                End If
                
                pnlStudent.Controls.Add(rtb1)

                ' Label3 - GENDER label
                Dim label3 As New Label With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(42, 128),
                    .Text = "GENDER",
                    .TabIndex = 5
                }
                pnlStudent.Controls.Add(label3)

                ' RichTextBox2 - GENDER value
                Dim rtb2 As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold),
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(42, 156),
                    .ReadOnly = True,
                    .Size = New Size(394, 49),
                    .TabIndex = 6,
                    .Text = student.Gender
                }
                pnlStudent.Controls.Add(rtb2)

                ' Label4 - COLLEGE DEPARTMENT label
                Dim label4 As New Label With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(42, 220),
                    .Text = "COLLEGE DEPARTMENT",
                    .TabIndex = 5
                }
                pnlStudent.Controls.Add(label4)

                ' RichTextBox3 - COLLEGE DEPARTMENT value
                Dim rtb3 As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold),
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(42, 248),
                    .ReadOnly = True,
                    .Size = New Size(394, 49),
                    .TabIndex = 6,
                    .Text = student.Department
                }
                pnlStudent.Controls.Add(rtb3)

                scrollPanel.Controls.Add(pnlStudent)
                yPos += 370
            Next
        End If

        ' Replace Panel4 content
        Panel4.Controls.Clear()
        Panel4.Controls.Add(scrollPanel)
    End Sub

    Private Sub StudentName_Click(sender As Object, e As MouseEventArgs)
        ' Only allow deletion if current user is an Instructor
        If Session.CurrentUser Is Nothing OrElse Session.CurrentUser.Role <> "Instructor" Then
            Return
        End If

        Dim rtb = TryCast(sender, RichTextBox)
        If rtb Is Nothing OrElse rtb.Tag Is Nothing Then Return

        Dim student = TryCast(rtb.Tag, User)
        If student Is Nothing Then Return

        ' Show confirmation dialog
        Dim result = MessageBox.Show(
            $"You want to delete this account?" & vbCrLf & vbCrLf &
            $"Student: {student.FirstName} {student.LastName}" & vbCrLf &
            $"Username: {student.Username}",
            "Delete Student Account",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning,
            MessageBoxDefaultButton.Button2
        )

        If result = DialogResult.Yes Then
            ' Delete the student account
            If DataStore.DeleteUser(student.Username, "Student") Then
                ' Delete profile picture if exists
                Try
                    Dim picturePath = System.IO.Path.Combine(Application.StartupPath, "UserPictures", $"{student.Username}_profile.jpg")
                    If System.IO.File.Exists(picturePath) Then
                        System.IO.File.Delete(picturePath)
                    End If
                Catch ex As Exception
                    ' Ignore picture deletion errors
                End Try

                MessageBox.Show(
                    $"Student account '{student.FirstName} {student.LastName}' has been deleted successfully.",
                    "Account Deleted",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                )

                ' Reload the student list
                LoadRegisteredStudents()
            Else
                MessageBox.Show(
                    "Failed to delete student account. Please try again.",
                    "Delete Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                )
            End If
        End If
    End Sub

    Private Sub RichTextBox3_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox3.TextChanged

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs)

    End Sub
End Class
