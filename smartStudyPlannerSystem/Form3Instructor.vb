Imports System.IO

Public Class Form3Instructor
    Private Sub Form3Instructor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Instructor", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Load and display ONLY registered instructors
        LoadRegisteredInstructors()
    End Sub

    Private Sub LoadRegisteredInstructors()
        ' Create scrollable panel
        Dim scrollPanel As New Panel With {
   .AutoScroll = True,
       .Dock = DockStyle.Fill,
   .BackColor = Color.White,
   .BorderStyle = BorderStyle.FixedSingle
  }

        ' Load ONLY instructors
        Dim instructors = DataStore.LoadUsers("Instructor")

        Dim yPos As Integer = 20

        If instructors.Count = 0 Then
            Dim lblNoData As New Label With {
 .Text = "No instructors registered yet.",
    .Font = New Font("Segoe UI", 12),
      .AutoSize = True,
     .Location = New Point(20, 60),
        .ForeColor = Color.Gray
        }
            scrollPanel.Controls.Add(lblNoData)
        Else
            ' Display each instructor in a duplicated panel design
            For Each instructor In instructors
                Dim pnlInstructor As New Panel With {
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
                    Dim picturePath = Path.Combine(Application.StartupPath, "UserPictures", $"{instructor.Username}_profile.jpg")
                    If File.Exists(picturePath) Then
                        Using fs As New FileStream(picturePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
                            Using img = Image.FromStream(fs)
                                pictureBox.Image = New Bitmap(img)
                            End Using
                        End Using
                    End If
                Catch ex As Exception
                    ' Use default if no picture
                End Try

                pnlInstructor.Controls.Add(pictureBox)

                ' Label2 - NAME label
                Dim label2 As New Label With {
        .AutoSize = True,
    .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
         .ForeColor = Color.MidnightBlue,
.Location = New Point(42, 37),
    .Text = "NAME",
         .TabIndex = 5
           }
                pnlInstructor.Controls.Add(label2)

                ' RichTextBox1 - NAME value
                Dim rtb1 As New RichTextBox With {
     .BackColor = Color.White,
          .BorderStyle = BorderStyle.None,
          .Font = New Font("Roboto Lt", 14.25F, FontStyle.Bold),
           .ForeColor = Color.MidnightBlue,
            .Location = New Point(42, 65),
    .ReadOnly = True,
        .Size = New Size(394, 49),
 .TabIndex = 6,
        .Text = instructor.FirstName & " " & instructor.LastName
          }
                pnlInstructor.Controls.Add(rtb1)

                ' Label3 - GENDER label
                Dim label3 As New Label With {
   .AutoSize = True,
        .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
     .ForeColor = Color.MidnightBlue,
          .Location = New Point(42, 128),
        .Text = "GENDER",
        .TabIndex = 5
  }
                pnlInstructor.Controls.Add(label3)

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
 .Text = instructor.Gender
      }
                pnlInstructor.Controls.Add(rtb2)

                ' Label4 - COLLEGE DEPARTMENT label
                Dim label4 As New Label With {
          .AutoSize = True,
       .Font = New Font("Roboto", 15.75F, FontStyle.Regular),
          .ForeColor = Color.MidnightBlue,
     .Location = New Point(42, 220),
       .Text = "COLLEGE DEPARTMENT",
             .TabIndex = 5
          }
                pnlInstructor.Controls.Add(label4)

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
       .Text = instructor.Department
  }
                pnlInstructor.Controls.Add(rtb3)

                scrollPanel.Controls.Add(pnlInstructor)
                yPos += 370
            Next
        End If

        ' Replace Panel4 content
        Panel4.Controls.Clear()
        Panel4.Controls.Add(scrollPanel)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
