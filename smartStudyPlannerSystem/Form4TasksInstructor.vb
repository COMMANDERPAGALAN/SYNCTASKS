Public Class Form4TasksInstructor
    Private currentUser As User
    Private allTasks As List(Of Task)
    Private TasksFolder As String = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(Application.StartupPath))), "SmartStudyPlanner", "Tasks")

    Private Sub Form4Tasks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        allTasks = DataStore.LoadTasks()

        ' Filter by selected subject if one is set
        If Session.SelectedSubject IsNot Nothing Then
            allTasks = allTasks.Where(Function(t) t.SubjectID = Session.SelectedSubject.SubjectID).ToList()
        End If

        ' Clear Panel1 but keep Label1, Button3, and Panel3 (template) - Form3Student pattern
        Dim controlsToRemove As New List(Of Control)
        For Each ctrl In Panel1.Controls
            If ctrl IsNot Label1 AndAlso ctrl IsNot Button3 AndAlso ctrl IsNot Panel3 Then
                controlsToRemove.Add(ctrl)
            End If
        Next
        For Each ctrl In controlsToRemove
            Panel1.Controls.Remove(ctrl)
            ctrl.Dispose()
        Next

        ' Hide the template Panel3
        Panel3.Visible = False

        ' Position Button3 matching Designer: (620, 30)
        Button3.Location = New Point(620, 30)
        If Not Panel1.Controls.Contains(Button3) Then
            Panel1.Controls.Add(Button3)
        End If

        ' Calculate centered position for task panels with proper margins
        Dim panel4Width = Panel1.Width
        Dim taskPanelWidth = 930 ' Matching Designer Panel3 width
        Dim taskPanelX = Math.Max(20, (panel4Width - taskPanelWidth) \ 2) ' Center horizontally

        ' Calculate vertical position - start right after Label1 and Button3
        Dim yPos As Integer = 100 ' Start position after header (Label1 + Button3 + margin)

        ' Display selected subject and instructor info if subject is selected
        If Session.SelectedSubject IsNot Nothing Then
            Dim selectedSubject = Session.SelectedSubject
            ' Create a header panel to show selected subject info, centered
            Dim headerPanel As New Panel With {
                .BackColor = Color.LightBlue,
                .BorderStyle = BorderStyle.FixedSingle,
                .Location = New Point(taskPanelX, yPos),
                .Size = New Size(930, 50),
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

        ' Always load instructor view for this form
        LoadInstructorView(Panel1, yPos, taskPanelX)
    End Sub

    Private Sub LoadInstructorView(scrollPanel As Panel, startYPos As Integer, taskPanelX As Integer)
        Dim yPos As Integer = startYPos

        ' Button3 is already positioned in LoadTasks, ensure event is wired (remove old handler first to avoid duplicates)
        RemoveHandler Button3.Click, AddressOf CreateNewTask
        AddHandler Button3.Click, AddressOf CreateNewTask

        ' List all tasks
        If allTasks.Count = 0 Then
            Dim lblNoTasks As New Label With {
                .Text = "No tasks created yet. Click 'CREATE NEW TASK' to get started.",
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
                    .Size = New Size(930, 434), ' Matching Designer: (930, 434)
                    .Anchor = AnchorStyles.None
                }

                ' PictureBox1 - Task Image/Icon (Left side) - matching Designer layout
                Dim pictureBox As New PictureBox With {
                    .BackColor = Color.SkyBlue,
                    .BorderStyle = BorderStyle.Fixed3D,
                    .Location = New Point(39, 36), ' Matching Designer: (39, 36)
                    .Size = New Size(416, 254), ' Matching Designer: (416, 254)
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
                            Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form4TasksInstructor))
                            pictureBox.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), Image)
                        Catch
                            ' No default image available
                        End Try
                    End If
                Catch ex As Exception
                    ' Use default background image from resources if available
                    Try
                        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(Form4TasksInstructor))
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
                    .Location = New Point(39, 306), ' Matching Designer: (39, 306)
                    .Size = New Size(416, 97), ' Matching Designer: (416, 97)
                    .ReadOnly = True,
                    .Text = If(String.IsNullOrEmpty(task.Description), "No instructions provided.", task.Description)
                }
                pnlTask.Controls.Add(txtTaskInstructions)

                ' LinkLabel5 - SUBJECT label - matching Designer layout
                Dim lblSubject As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(497, 36), ' Matching Designer: (497, 36)
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
                    .Location = New Point(497, 64), ' Matching Designer: (497, 64)
                    .ReadOnly = True,
                    .Size = New Size(399, 42), ' Matching Designer: (399, 42)
                    .Text = task.SubjectName
                }
                pnlTask.Controls.Add(rtbSubject)

                ' LinkLabel2 - INSTRUCTOR label - matching Designer layout
                Dim lblInstructor As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(497, 128), ' Matching Designer: (497, 128)
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
                    .Location = New Point(497, 156), ' Matching Designer: (497, 156)
                    .ReadOnly = True,
                    .Size = New Size(399, 42), ' Matching Designer: (399, 42)
                    .Text = task.InstructorName
                }
                pnlTask.Controls.Add(rtbInstructor)

                ' LinkLabel3 - DEADLINE label - matching Designer layout
                Dim lblDeadline As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto Bk", 15.75F, FontStyle.Regular), ' Matching Designer font
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(497, 220), ' Matching Designer: (497, 220)
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
                    .Location = New Point(497, 248), ' Matching Designer: (497, 248)
                    .ReadOnly = True,
                    .Size = New Size(399, 42), ' Matching Designer: (399, 42)
                    .Text = task.Deadline.ToString("yyyy-MM-dd")
                }
                pnlTask.Controls.Add(rtbDeadline)

                ' LinkLabel1 - DOWNLOAD link - matching Designer layout
                Dim lnkDownload As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 12.0F, FontStyle.Regular),
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(602, 306), ' Matching Designer: (602, 306)
                    .Text = "DOWNLOAD",
                    .TabStop = True
                }
                AddHandler lnkDownload.Click, Sub(sender As Object, e As EventArgs)
                                                  DownloadTaskFile(task)
                                              End Sub
                pnlTask.Controls.Add(lnkDownload)

                ' LinkLabel4 - UPLOAD link - matching Designer layout
                Dim lnkUpload As New LinkLabel With {
                    .AutoSize = True,
                    .Font = New Font("Roboto", 12.0F, FontStyle.Regular),
                    .LinkColor = Color.MidnightBlue,
                    .Location = New Point(705, 306), ' Matching Designer: (705, 306)
                    .Text = "UPLOAD",
                    .TabStop = True
                }
                AddHandler lnkUpload.Click, Sub(sender As Object, e As EventArgs)
                                                UploadTaskFile(task)
                                            End Sub
                pnlTask.Controls.Add(lnkUpload)

                ' Additional buttons for instructor actions - matching Designer layout
                Dim btnSubmissions As New Button With {
                    .Text = "👥 Submissions",
                    .Location = New Point(559, 359), ' Matching Designer: (559, 359)
                    .Size = New Size(120, 44), ' Matching Designer size
                    .BackColor = Color.Orange,
                    .ForeColor = Color.White,
                    .Font = New Font("Roboto", 10, FontStyle.Bold),
                    .FlatStyle = FlatStyle.Flat
                }
                AddHandler btnSubmissions.Click, Sub(sender As Object, e As EventArgs)
                                                     ShowSubmissions(task)
                                                 End Sub
                pnlTask.Controls.Add(btnSubmissions)

                Dim btnDelete As New Button With {
                    .Text = "🗑️ Delete",
                    .Location = New Point(716, 359), ' Matching Designer: (716, 359)
                    .Size = New Size(120, 44), ' Matching Designer size
                    .BackColor = Color.Red,
                    .ForeColor = Color.White,
                    .Font = New Font("Roboto", 10, FontStyle.Bold),
                    .FlatStyle = FlatStyle.Flat
                }
                AddHandler btnDelete.Click, Sub(sender As Object, e As EventArgs)
                                                DeleteTask(task)
                                            End Sub
                pnlTask.Controls.Add(btnDelete)

                scrollPanel.Controls.Add(pnlTask)
                yPos += 444 ' 434px panel height + 10px spacing (2 lines)
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


    Private Sub CreateNewTask(sender As Object, e As EventArgs)
        Dim taskTitle = InputBox("Enter task title:", "Create Task")
        If String.IsNullOrEmpty(taskTitle) Then Return

        Dim taskDesc = InputBox("Enter task description:", "Create Task")
        
        ' Use selected subject from Form7Subject if available, otherwise prompt
        Dim subjectID As String = ""
        Dim subjectName As String = ""
        Dim instructorName As String = ""
        
        If Session.SelectedSubject IsNot Nothing Then
            ' Use selected subject from Form7Subject
            subjectID = Session.SelectedSubject.SubjectID
            subjectName = Session.SelectedSubject.SubjectName
            instructorName = Session.SelectedSubject.InstructorName
        Else
            ' Prompt for subject name if no subject selected
            subjectName = InputBox("Enter subject name:", "Create Task")
            If String.IsNullOrEmpty(subjectName) Then Return
            
            ' Try to find subject by name
            Dim subject = DataStore.LoadSubjects().FirstOrDefault(Function(s) s.SubjectName = subjectName)
            If subject IsNot Nothing Then
                subjectID = subject.SubjectID
                instructorName = subject.InstructorName
            Else
                subjectID = "General"
                instructorName = currentUser.FirstName & " " & currentUser.LastName
            End If
        End If
        
        Dim deadlineStr = InputBox("Enter deadline (yyyy-MM-dd):", "Create Task")

        Try
            Dim deadline = DateTime.ParseExact(deadlineStr, "yyyy-MM-dd", Globalization.CultureInfo.InvariantCulture)
            Dim newTask As New Task(subjectID, subjectName, taskTitle, taskDesc, currentUser.Username, If(String.IsNullOrEmpty(instructorName), currentUser.FirstName & " " & currentUser.LastName, instructorName), deadline)
            If DataStore.SaveTask(newTask) Then
                MessageBox.Show("Task created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                LoadTasks()
            Else
                MessageBox.Show("Error creating task.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Catch ex As Exception
            MessageBox.Show($"Invalid deadline format. Use: yyyy-MM-dd", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub UploadTaskFile(task As Task)
        Using ofd As New OpenFileDialog()
            ofd.Title = $"Upload file for: {task.Title}"
            ofd.Multiselect = True
            ofd.Filter = "All Files (*.*)|*.*"

            If ofd.ShowDialog() = DialogResult.OK Then
                Try
                    Dim taskFolder = System.IO.Path.Combine(TasksFolder, task.TaskID)
                    If Not System.IO.Directory.Exists(taskFolder) Then
                        System.IO.Directory.CreateDirectory(taskFolder)
                    End If

                    For Each filePath In ofd.FileNames
                        Dim fileName = System.IO.Path.GetFileName(filePath)
                        Dim destPath = System.IO.Path.Combine(taskFolder, fileName)
                        System.IO.File.Copy(filePath, destPath, True)
                        If Not task.FileNames.Contains(fileName) Then
                            task.FileNames.Add(fileName)
                        End If
                    Next

                    If DataStore.SaveTask(task) Then
                        MessageBox.Show($"Uploaded {ofd.FileNames.Length} file(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        LoadTasks()
                    End If
                Catch ex As Exception
                    MessageBox.Show($"Error uploading files: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub DownloadTaskFile(task As Task)
        ' For Instructor: Show options to download task files or student submissions
        Dim submissions = DataStore.LoadSubmissions(task.TaskID)

        If task.FileNames.Count = 0 AndAlso submissions.Count = 0 Then
            MessageBox.Show("No files or submissions available for download.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Create a dialog to choose what to download
        Dim downloadOptions As New List(Of String)
        If task.FileNames.Count > 0 Then
            downloadOptions.Add("Task Files (Instructor's Files)")
        End If
        If submissions.Count > 0 Then
            downloadOptions.Add($"Student Submissions ({submissions.Count} student(s))")
        End If

        If downloadOptions.Count = 1 Then
            ' Only one option, proceed directly
            If downloadOptions(0).Contains("Task Files") Then
                DownloadTaskFiles(task)
            Else
                DownloadStudentSubmissions(task, submissions)
            End If
        Else
            ' Show selection dialog
            Dim result = MessageBox.Show(
                $"What would you like to download?{vbCrLf}{vbCrLf}" &
                $"1. Task Files (Instructor's Files){vbCrLf}" &
                $"2. Student Submissions ({submissions.Count} student(s)){vbCrLf}{vbCrLf}" &
                $"Click Yes for Task Files, No for Student Submissions",
                "Download Options",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                DownloadTaskFiles(task)
            ElseIf result = DialogResult.No Then
                DownloadStudentSubmissions(task, submissions)
            End If
        End If
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

        ' Use OpenFileDialog to show all files (like upload view)
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

    Private Function FormatFileSize(bytes As Long) As String
        Dim sizes() As String = {"B", "KB", "MB", "GB"}
        Dim order As Integer = 0
        Dim size As Double = bytes

        While size >= 1024 AndAlso order < sizes.Length - 1
            order += 1
            size /= 1024
        End While

        Return String.Format("{0:0.##} {1}", size, sizes(order))
    End Function

    Private Sub DownloadStudentSubmissions(task As Task, submissions As List(Of TaskSubmission))
        If submissions.Count = 0 Then
            MessageBox.Show("No student submissions available for download.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Try
            ' Show list of students to choose from
            Dim studentList As String = "Select student to view their submitted files:" & vbCrLf & vbCrLf
            For i = 0 To submissions.Count - 1
                Dim submissionItem = submissions(i)
                Dim studentInfo = (i + 1).ToString() & ". " & submissionItem.StudentName & " (" & submissionItem.StudentID & ") - " & submissionItem.SubmittedFileNames.Count.ToString() & " file(s) - " & submissionItem.SubmissionDate.ToString("yyyy-MM-dd HH:mm")
                studentList &= studentInfo & vbCrLf
            Next

            Dim selectedIndex = InputBox(studentList & vbCrLf & "Enter number (1-" & submissions.Count & "):", "Select Student Submission")

            If String.IsNullOrEmpty(selectedIndex) Then Return

            Dim index As Integer
            If Not Integer.TryParse(selectedIndex, index) OrElse index < 1 OrElse index > submissions.Count Then
                MessageBox.Show("Invalid selection.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If

            Dim selectedSubmission = submissions(index - 1)
            ' Designated storage: TasksFolder/Submissions/TaskID/StudentID/
            Dim submissionFolder = System.IO.Path.Combine(TasksFolder, "Submissions", task.TaskID, selectedSubmission.StudentID)

            ' Ensure storage folder exists
            If Not System.IO.Directory.Exists(submissionFolder) Then
                System.IO.Directory.CreateDirectory(submissionFolder)
            End If

            ' Get all files from designated storage
            Dim availableFiles As New List(Of String)
            If System.IO.Directory.Exists(submissionFolder) Then
                availableFiles.AddRange(System.IO.Directory.GetFiles(submissionFolder))
            End If

            ' Also check files from submission.SubmittedFileNames list
            For Each fileName In selectedSubmission.SubmittedFileNames
                Dim filePath = System.IO.Path.Combine(submissionFolder, fileName)
                If System.IO.File.Exists(filePath) AndAlso Not availableFiles.Contains(filePath) Then
                    availableFiles.Add(filePath)
                End If
            Next

            If availableFiles.Count = 0 Then
                MessageBox.Show($"No files found for {selectedSubmission.StudentName} in designated storage.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return
            End If

            ' Use OpenFileDialog to show all files (like upload view)
            Using ofd As New OpenFileDialog()
                ofd.Title = $"Download {selectedSubmission.StudentName}'s Submission - All Files"
                ofd.InitialDirectory = submissionFolder
                ofd.Filter = "All Files (*.*)|*.*"
                ofd.Multiselect = True

                ' Show the dialog to view and select files
                If ofd.ShowDialog() = DialogResult.OK Then
                    ' Use FolderBrowserDialog for destination folder
                    Using fbd As New FolderBrowserDialog()
                        fbd.Description = $"Select folder to download {selectedSubmission.StudentName}'s files to:"

                        If fbd.ShowDialog() = DialogResult.OK Then
                            ' Create a subfolder with student name
                            Dim studentFolder = System.IO.Path.Combine(fbd.SelectedPath, $"{selectedSubmission.StudentName}_{selectedSubmission.StudentID}")
                            If Not System.IO.Directory.Exists(studentFolder) Then
                                System.IO.Directory.CreateDirectory(studentFolder)
                            End If

                            Dim downloadedCount = 0

                            ' Download all selected files
                            For Each filePath In ofd.FileNames
                                If System.IO.File.Exists(filePath) Then
                                    Dim fileName = System.IO.Path.GetFileName(filePath)
                                    Dim destPath = System.IO.Path.Combine(studentFolder, fileName)
                                    System.IO.File.Copy(filePath, destPath, True)
                                    downloadedCount += 1
                                End If
                            Next

                            MessageBox.Show($"Downloaded {downloadedCount} file(s) from {selectedSubmission.StudentName} to: {studentFolder}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                    End Using
                End If
            End Using

        Catch ex As Exception
            MessageBox.Show($"Error downloading submissions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    Private Sub ShowSubmissions(task As Task)
        Dim submissions = DataStore.LoadSubmissions(task.TaskID)

        Dim submissionInfo = $"Submissions for: {task.Title}{vbCrLf}{vbCrLf}"
        submissionInfo &= $"Total Submissions: {submissions.Count}{vbCrLf}{vbCrLf}"

        For Each submission In submissions
            submissionInfo &= $"👤 {submission.StudentName}{vbCrLf}"
            submissionInfo &= $"   Status: {submission.Status} | Submitted: {submission.SubmissionDate:yyyy-MM-dd HH:mm}{vbCrLf}"
            submissionInfo &= $"   Files: {String.Join(", ", submission.SubmittedFileNames)}{vbCrLf}{vbCrLf}"
        Next

        MessageBox.Show(submissionInfo, "Task Submissions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub NavigateToForm(frm As Form)

        Try
            Dim parentForm = Me.FindForm()
            If parentForm IsNot Nothing AndAlso TypeOf parentForm Is Form2 Then
                Dim form2 = DirectCast(parentForm, Form2)
                form2.ShowInContent(frm)
                Return
            End If
        Catch ex As Exception

        End Try


        frm.ShowDialog(Me)
    End Sub

    Private Sub DeleteTask(task As Task)
        If MessageBox.Show("Are you sure you want to delete this task?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Try

                Dim taskFolder = System.IO.Path.Combine(TasksFolder, task.TaskID)
                If System.IO.Directory.Exists(taskFolder) Then
                    System.IO.Directory.Delete(taskFolder, True)
                End If

                ' Delete submissions folder for this task
                Dim submissionsFolder = System.IO.Path.Combine(TasksFolder, "Submissions", task.TaskID)
                If System.IO.Directory.Exists(submissionsFolder) Then
                    System.IO.Directory.Delete(submissionsFolder, True)
                End If


                If DataStore.DeleteTask(task.TaskID) Then
                    MessageBox.Show("Task deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    LoadTasks()
                    Panel1.Refresh()
                    Panel1.Update()
                Else
                    MessageBox.Show("Error deleting task from database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show($"Error deleting task: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Function GetTaskColor(status As String) As Color
        Select Case status
            Case "Active"
                Return Color.LightGreen
            Case "Due Soon"
                Return Color.LightYellow
            Case "Overdue"
                Return Color.LightCoral
            Case Else
                Return Color.LightGray
        End Select
    End Function

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub LinkLabel4_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel4.LinkClicked

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class
