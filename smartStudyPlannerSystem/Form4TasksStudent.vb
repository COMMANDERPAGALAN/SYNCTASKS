Public Class Form4TasksStudent
    Private currentUser As User
    Private allTasks As List(Of Task)
    Private TasksFolder As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.StartupPath))), "SmartStudyPlanner", "Tasks")

    Private Sub Form4TasksStudent_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Tasks", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        currentUser = Session.CurrentUser

        ' Create Tasks folder if not exists
        If Not System.IO.Directory.Exists(TasksFolder) Then
            System.IO.Directory.CreateDirectory(TasksFolder)
        End If

        ' Load and display tasks
        LoadTasks()
    End Sub

    Private Sub LoadTasks()
        ' Update title label - always show "TASKS"
        Label1.Text = "TASKS"

        ' Load all tasks
        allTasks = DataStore.LoadTasks("")

        ' Filter by selected subject if one is set
        If Session.SelectedSubject IsNot Nothing Then
            allTasks = allTasks.Where(Function(t) t.SubjectID = Session.SelectedSubject.SubjectID).ToList()
        End If

        ' Clear Panel1 but keep Label1 and Panel3 (template) - Form3Student pattern
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel1.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Panel3 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel1.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Hide the template Panel3
        Panel3.Visible = False

        ' Calculate centered position for task panels with proper margins
        Dim panel4Width = Panel1.Width
        Dim taskPanelWidth = 991 ' Matching Designer Panel3 width
        Dim taskPanelX = Math.Max(20, (panel4Width - taskPanelWidth) \ 2) ' Center horizontally

        ' Calculate vertical position - start right after Label1
        Dim yPos As Integer = 100 ' Start position after header (Label1 + margin)

        ' Display selected subject and instructor info if subject is selected
        If Session.SelectedSubject IsNot Nothing Then
            Dim selectedSubject = Session.SelectedSubject
            ' Create a header panel to show selected subject info, centered
            Dim headerPanel As New Panel With {
                .BackColor = Color.LightBlue,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(taskPanelX, yPos),
                .Size = New Size(991, 50),
                .Anchor = AnchorStyles.None
            }

            Dim lblHeader As New Label With {
                .Text = $"Selected Subject: {selectedSubject.SubjectName} | Instructor: {selectedSubject.InstructorName}",
                .Font = New Font("Roboto", 12, FontStyle.Bold),
                .ForeColor = Color.MidnightBlue,
                .AutoSize = True,
                .Location = New Point(20, 15)
            }
            headerPanel.Controls.Add(lblHeader)
            Panel1.Controls.Add(headerPanel)
            yPos += 60
        End If

        ' Load student view
        LoadStudentView(Panel1, yPos, taskPanelX)
    End Sub

    Private Sub LoadStudentView(scrollPanel As Panel, startYPos As Integer, taskPanelX As Integer)
        Dim yPos As Integer = startYPos

        ' Get submissions for this student
        Dim submissions = DataStore.LoadSubmissions()
        Dim studentSubmissions = submissions.Where(Function(s) s.StudentID = currentUser.Username).ToList()

        If allTasks.Count = 0 Then
            Dim lblNoTasks As New Label With {
                .Text = "No tasks assigned yet.",
                .Font = New Font("Roboto", 12),
                .AutoSize = True,
                .Location = New Point(taskPanelX, yPos),
                .ForeColor = Color.MidnightBlue,
                .Anchor = AnchorStyles.None
            }
            scrollPanel.Controls.Add(lblNoTasks)
        Else
            For Each task In allTasks
                ' Create task panel matching designer style (matching Panel3), centered
                Dim pnlTask As New Panel With {
                    .BackColor = Color.Lavender,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Location = New Point(taskPanelX, yPos),
                    .Size = New Size(991, 459), ' Matching Designer: (991, 459)
                    .Anchor = AnchorStyles.None
                }

                ' PictureBox1 - Task Image/Icon (Left side) - matching Designer layout
                Dim pictureBox As New PictureBox With {
                    .BackColor = Color.SkyBlue,
                    .BorderStyle = BorderStyle.Fixed3D,
                    .Location = New Point(60, 43), ' Matching Designer: (60, 43)
                    .Size = New Size(392, 254), ' Matching Designer: (392, 254)
                    .BackgroundImageLayout = ImageLayout.Zoom,
                    .TabStop = False
                }
                ' Try to load task image if exists, otherwise use default background image
                Try
                    Dim taskImagePath = System.IO.Path.Combine(TasksFolder, task.TaskID, "task_image.jpg")
                    If System.IO.File.Exists(taskImagePath) Then
                        pictureBox.BackgroundImage = Image.FromFile(taskImagePath)
                    Else
                        ' Use default background image from resources if available
                        Try
                            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form4TasksStudent))
                            pictureBox.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
                        Catch
                            ' No default image available
                        End Try
                    End If
                Catch ex As Exception
                    ' Use default background image from resources if available
                    Try
                        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form4TasksStudent))
                        pictureBox.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
                    Catch
                        ' No default image available
                    End Try
                End Try
                pnlTask.Controls.Add(pictureBox)

                ' TextBox below picture box for instructions/assignment/task description - matching Designer layout
                Dim txtTaskInstructions As New TextBox With {
                    .Multiline = True,
                    .ScrollBars = ScrollBars.None,
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.FixedSingle,
                    .Font = New Font("Roboto Lt", 15.75F, FontStyle.Bold), ' Matching Designer font
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(60, 311), ' Matching Designer: (60, 311)
                    .Size = New Size(392, 97), ' Matching Designer: (392, 97)
                    .ReadOnly = True,
                    .Text = If(String.IsNullOrEmpty(task.Description), "No instructions provided.", task.Description)
                }
                pnlTask.Controls.Add(txtTaskInstructions)

                ' LinkLabel5 - SUBJECT label - matching Designer layout
                Dim lblSubject As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(515, 40), ' Matching Designer: (515, 40)
                    .Text = "SUBJECT",
                    .TabStop = True
                }
                ' Navigate to Form7Subject with this task's subject
                AddHandler lblSubject.Click, Sub(sender As Object, e As EventArgs)
                                                 Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectID = task.SubjectID)
                                                 If subject IsNot Nothing Then
                                                     Session.SelectedSubject = subject
                                                     NavigateToForm(New Form7Subject())
                                                 End If
                                             End Sub
                pnlTask.Controls.Add(lblSubject)

                ' RichTextBox1 - SUBJECT value - matching Designer layout
                Dim rtbSubject As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(515, 71), ' Matching Designer: (515, 71)
                    .ReadOnly = True,
                    .Size = New Size(390, 42), ' Matching Designer: (390, 42)
                    .Text = task.SubjectName
                }
                pnlTask.Controls.Add(rtbSubject)

                ' LinkLabel2 - INSTRUCTOR label - matching Designer layout
                Dim lblInstructor As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(515, 132), ' Matching Designer: (515, 132)
                    .Text = "INSTRUCTOR",
                    .TabStop = True
                }
                ' Navigate to Form3Instructor
                AddHandler lblInstructor.Click, Sub(sender As Object, e As EventArgs)
                                                    NavigateToForm(New Form3Instructor())
                                                End Sub
                pnlTask.Controls.Add(lblInstructor)

                ' RichTextBox2 - INSTRUCTOR value - matching Designer layout
                Dim rtbInstructor As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(515, 163), ' Matching Designer: (515, 163)
                    .ReadOnly = True,
                    .Size = New Size(390, 42), ' Matching Designer: (390, 42)
                    .Text = task.InstructorName
                }
                pnlTask.Controls.Add(rtbInstructor)

                ' LinkLabel3 - DEADLINE label - matching Designer layout
                Dim lblDeadline As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(515, 224), ' Matching Designer: (515, 224)
                    .Text = "DEADLINE",
                    .TabStop = True
                }
                ' Navigate to Form8Deadline
                AddHandler lblDeadline.Click, Sub(sender As Object, e As EventArgs)
                                                  NavigateToForm(New Form8Deadline())
                                              End Sub
                pnlTask.Controls.Add(lblDeadline)

                ' RichTextBox3 - DEADLINE value - matching Designer layout
                Dim rtbDeadline As New RichTextBox With {
                    .BackColor = Color.White,
                    .BorderStyle = BorderStyle.None,
                    .Font = New Font("Roboto", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .ForeColor = Color.MidnightBlue,
                    .Location = New Point(515, 255), ' Matching Designer: (515, 255)
                    .ReadOnly = True,
                    .Size = New Size(390, 42), ' Matching Designer: (390, 42)
                    .Text = task.Deadline.ToString("yyyy-MM-dd") & " | Status: " & task.GetStatus()
                }
                pnlTask.Controls.Add(rtbDeadline)

                ' Check if student submitted
                Dim studentSubmission = studentSubmissions.FirstOrDefault(Function(s) s.TaskID = task.TaskID)
                Dim submissionStatus = If(studentSubmission Is Nothing, "Not Submitted", $"Submitted {studentSubmission.SubmissionDate:MM-dd}")

                ' LinkLabel1 - DOWNLOAD link - matching Designer layout
                Dim lnkDownload As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 12.0F, FontStyle.Regular),
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(621, 321), ' Matching Designer: (621, 321)
                    .Text = "DOWNLOAD",
                    .TabStop = True
                }
                AddHandler lnkDownload.Click, Sub(sender As Object, e As EventArgs)
                                                  DownloadTaskFile(task)
                                              End Sub
                pnlTask.Controls.Add(lnkDownload)

                ' LinkLabel4 - UPLOAD link - matching Designer layout
                Dim lnkSubmit As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 12.0F, FontStyle.Regular),
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(724, 321), ' Matching Designer: (724, 321)
                    .Text = If(studentSubmission Is Nothing, "UPLOAD", "RE-UPLOAD"),
                    .TabStop = True
                }
                AddHandler lnkSubmit.Click, Sub(sender As Object, e As EventArgs)
                                                SubmitTaskFile(task, studentSubmission)
                                            End Sub
                pnlTask.Controls.Add(lnkSubmit)

                ' Submission status - centered below Download/Upload links
                Dim lblSubmissionStatus As New Label With {
                    .Text = submissionStatus,
                    .Font = New Font("Impact", 18, FontStyle.Regular),
                    .AutoSize = False,
                    .TextAlign = ContentAlignment.MiddleCenter,
                    .Location = New Point(621, 350), ' Adjusted position below links
                    .Size = New Size(200, 35),
                    .ForeColor = If(studentSubmission Is Nothing, Color.Red, Color.Green)
                }
                pnlTask.Controls.Add(lblSubmissionStatus)

                scrollPanel.Controls.Add(pnlTask)
                yPos += 469 ' 459px panel height + 10px spacing (2 lines)
            Next
        End If

        ' Enable scrolling - ensure all content is accessible (Form3Student pattern)
        ' Calculate the maximum bottom position of all controls
        Dim maxBottom As Integer = 0
        For Each ctrl As Control In scrollPanel.Controls
            If ctrl.Bottom > maxBottom Then
                maxBottom = ctrl.Bottom
            End If
        Next

        ' Set minimum scroll size with extra margin to prevent cutoff at bottom
        Dim totalHeight = Math.Max(maxBottom + 100, scrollPanel.Height + 100)
        scrollPanel.AutoScrollMinSize = New Size(0, totalHeight)

        ' Force refresh of scrollbar
        scrollPanel.PerformLayout()
        scrollPanel.Invalidate()
        scrollPanel.Update()
        Application.DoEvents()
    End Sub

    Private Sub DownloadTaskFile(task As Task)
        ' For Student: Download task files (instructor's files)
        DownloadTaskFiles(task)
    End Sub

    Private Sub DownloadTaskFiles(task As Task)
        ' Designated storage: TasksFolder/TaskID/
        Dim taskFolder = System.IO.Path.Combine(TasksFolder, task.TaskID)

        ' Ensure storage folder exists
        If Not System.IO.Directory.Exists(taskFolder) Then
            System.IO.Directory.CreateDirectory(taskFolder)
        End If

        ' Get all files from designated storage
        Dim availableFiles As New List(Of String)
        If System.IO.Directory.Exists(taskFolder) Then
            availableFiles.AddRange(System.IO.Directory.GetFiles(taskFolder))
        End If

        ' Also check files from task.FileNames list
        For Each fileName In task.FileNames
            Dim filePath = System.IO.Path.Combine(taskFolder, fileName)
            If System.IO.File.Exists(filePath) AndAlso Not availableFiles.Contains(filePath) Then
                availableFiles.Add(filePath)
            End If
        Next

        If availableFiles.Count = 0 Then
            MessageBox.Show("No task files available for download.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Use OpenFileDialog to show all files
        Try
            Using ofd As New OpenFileDialog()
                ofd.Title = $"Download Task Files - All Files"
                ofd.InitialDirectory = taskFolder
                ofd.Filter = "All Files (*.*)|*.*"
                ofd.Multiselect = True

                ' Show the dialog to view and select files
                If ofd.ShowDialog() = DialogResult.OK Then
                    ' Use FolderBrowserDialog for destination folder
                    Using fbd As New FolderBrowserDialog()
                        fbd.Description = "Select folder to download files to:"

                        If fbd.ShowDialog() = DialogResult.OK Then
                            Dim downloadedCount = 0

                            ' Download all selected files
                            For Each filePath In ofd.FileNames
                                If System.IO.File.Exists(filePath) Then
                                    Dim fileName = System.IO.Path.GetFileName(filePath)
                                    Dim destPath = System.IO.Path.Combine(fbd.SelectedPath, fileName)
                                    System.IO.File.Copy(filePath, destPath, True)
                                    downloadedCount += 1
                                End If
                            Next

                            MessageBox.Show($"Downloaded {downloadedCount} file(s) to: {fbd.SelectedPath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show($"Error downloading files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub SubmitTaskFile(task As Task, existingSubmission As TaskSubmission)
        Using ofd As New OpenFileDialog()
            ofd.Title = $"Submit file(s) for: {task.Title}"
            ofd.Multiselect = True
            ofd.Filter = "All Files (*.*)|*.*"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim submission = If(existingSubmission, New TaskSubmission(task.TaskID, currentUser.Username, currentUser.FirstName & " " & currentUser.LastName))

                    Dim submissionFolder = System.IO.Path.Combine(TasksFolder, "Submissions", task.TaskID, currentUser.Username)
                    If Not System.IO.Directory.Exists(submissionFolder) Then
                        System.IO.Directory.CreateDirectory(submissionFolder)
                    End If

                    For Each filePath In ofd.FileNames
                        Dim fileName = System.IO.Path.GetFileName(filePath)
                        Dim destPath = System.IO.Path.Combine(submissionFolder, fileName)
                        System.IO.File.Copy(filePath, destPath, True)
                        If Not submission.SubmittedFileNames.Contains(fileName) Then
                            submission.SubmittedFileNames.Add(fileName)
                        End If
                    Next

                    submission.SubmissionDate = Now
                    submission.Status = If(submission.IsLate(task.Deadline), "Late", "Submitted")

                    If DataStore.SaveSubmission(submission) Then
                        MessageBox.Show($"Submitted {ofd.FileNames.Length} file(s)!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadTasks()
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error submitting files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub NavigateToForm(frm As Form)
        ' Navigate to form by finding parent Form2
        Try
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing AndAlso TypeOf parentForm Is Form2 Then
                Dim form2 = DirectCast(parentForm, Form2)
                form2.ShowInContent(frm)
                Return
            End If
        Catch ex As Exception
            ' Fallback: show as dialog
        End Try

        ' Fallback: show as dialog
        frm.ShowDialog(Me)
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
