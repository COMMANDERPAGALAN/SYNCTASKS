Imports System.IO
Imports System.Xml.Serialization
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.Diagnostics
Imports System.Linq

Public Module DataStore
    Private ReadOnly appFolderName As String = "SmartStudyPlanner"
    Private ReadOnly dataFolderName As String = "data"

    Private Function NormalizeRole(role As String) As String
        If String.IsNullOrWhiteSpace(role) Then
            Return "students"
        End If
        Dim r = role.Trim().ToLowerInvariant()
        If r = "instructor" OrElse r = "instructors" Then
            Return "instructors"
        Else
            Return "students"
        End If
    End Function

    Public Function GetDataDirectoryPath() As String

        Dim startupPath = Application.StartupPath
        Dim projectRoot = System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(System.IO.Path.GetDirectoryName(startupPath)))
        Dim dir = Path.Combine(projectRoot, appFolderName, dataFolderName)
        Try
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)
        Catch ex As Exception
            MessageBox.Show("Unable to create data directory: " & dir & vbCrLf & ex.Message, "DataStore Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        Return dir
    End Function

    Public Function GetDataFilePath(role As String) As String
        Dim normalized = NormalizeRole(role)
        Return Path.Combine(GetDataDirectoryPath(), normalized & ".xml")
    End Function

    Public Function LoadUsers(role As String) As List(Of User)
        Dim path = GetDataFilePath(role)
        Debug.WriteLine("DataStore.LoadUsers path=" & path)
        If Not File.Exists(path) Then
            Debug.WriteLine("DataStore.LoadUsers: file not found")
            Return New List(Of User)()
        End If
        Try
            Dim xs As New XmlSerializer(GetType(List(Of User)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj Is Nothing Then
                    Debug.WriteLine("DataStore.LoadUsers: deserialized object is Nothing")
                    Return New List(Of User)()
                End If
                Return DirectCast(obj, List(Of User))
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading users from: " & path & vbCrLf & ex.Message, "DataStore Load Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("DataStore.LoadUsers exception: " & ex.ToString())
            Return New List(Of User)()
        End Try
    End Function

    Public Function SaveUsers(role As String, users As List(Of User)) As Boolean
        Dim path = GetDataFilePath(role)
        Try

            Dim dir = System.IO.Path.GetDirectoryName(path)
            If String.IsNullOrWhiteSpace(dir) Then
                dir = GetDataDirectoryPath()
            End If
            If Not Directory.Exists(dir) Then Directory.CreateDirectory(dir)

            Dim xs As New XmlSerializer(GetType(List(Of User)))
            Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                xs.Serialize(fs, users)
            End Using

            Debug.WriteLine("DataStore.SaveUsers: saved " & users.Count.ToString() & " users to " & path)
            Return True
        Catch ex As Exception
            MessageBox.Show("Error saving users to: " & path & vbCrLf & ex.Message, "DataStore Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Debug.WriteLine("DataStore.SaveUsers exception: " & ex.ToString())
            Return False
        End Try
    End Function

    Public Function RegisterNewUser(user As User) As Boolean
        If user Is Nothing Then Return False
        Dim roleKey = NormalizeRole(user.Role)
        Dim users = LoadUsers(roleKey)

        For Each u In users
            If String.Compare(u.Username, user.Username, True) = 0 Then
                MessageBox.Show("Username already exists for this role. Choose another username.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return False
            End If
        Next

        users.Add(user)
        Dim saved = SaveUsers(roleKey, users)
        If Not saved Then
            MessageBox.Show("Failed to save registered user. See debug output for details.", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return saved
    End Function

    Public Function ValidateLogin(role As String, username As String, password As String) As User
        If String.IsNullOrWhiteSpace(username) OrElse String.IsNullOrWhiteSpace(password) Then Return Nothing
        Dim roleKey = NormalizeRole(role)
        Dim users = LoadUsers(roleKey)
        Debug.WriteLine($"DataStore.ValidateLogin role={roleKey} usersCount={users.Count}")
        For Each u In users
            If String.Compare(u.Username, username, True) = 0 AndAlso u.Password = password Then
                Return u
            End If
        Next
        Return Nothing
    End Function

    Public Function UpdateUser(user As User) As Boolean
        If user Is Nothing Then Return False
        Dim roleKey = NormalizeRole(user.Role)
        Dim users = LoadUsers(roleKey)

        Dim found = False
        For i = 0 To users.Count - 1
            If String.Compare(users(i).Username, user.Username, True) = 0 Then
                users(i) = user
                found = True
                Exit For
            End If
        Next

        If Not found Then
            MessageBox.Show("User not found to update.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim saved = SaveUsers(roleKey, users)
        If Not saved Then
            MessageBox.Show("Failed to save updated user details.", "Update Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return saved
    End Function

    Public Function GetUser(role As String, username As String) As User
        If String.IsNullOrWhiteSpace(username) Then Return Nothing
        Dim roleKey = NormalizeRole(role)
        Dim users = LoadUsers(roleKey)
        Return users.FirstOrDefault(Function(u) String.Compare(u.Username, username, True) = 0)
    End Function

    Public Function DeleteUser(username As String, role As String) As Boolean
        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Unable to delete account: missing username.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        Dim roleKey = NormalizeRole(role)
        Dim users = LoadUsers(roleKey)

        Dim indexToRemove = -1
        For i = 0 To users.Count - 1
            If String.Compare(users(i).Username, username, True) = 0 Then
                indexToRemove = i
                Exit For
            End If
        Next

        If indexToRemove = -1 Then
            MessageBox.Show("User not found to delete.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
        End If

        users.RemoveAt(indexToRemove)

        Dim saved = SaveUsers(roleKey, users)
        If Not saved Then
            MessageBox.Show("Failed to delete account data.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
        Return saved
    End Function


    Public Function LoadGrades(subjectID As String) As List(Of Grade)
        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "grades.xml")
        If Not File.Exists(path) Then
            Return New List(Of Grade)()
        End If

        Try
            Dim xs As New XmlSerializer(GetType(List(Of Grade)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj Is Nothing Then
                    Return New List(Of Grade)()
                End If
                Dim allGrades = DirectCast(obj, List(Of Grade))

                If String.IsNullOrEmpty(subjectID) Then
                    Return allGrades
                Else
                    Return allGrades.Where(Function(g) g.SubjectID = subjectID).ToList()
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading grades: " & ex.ToString())
            Return New List(Of Grade)()
        End Try
    End Function

    Public Function SaveGrade(grade As Grade) As Boolean
        If grade Is Nothing Then Return False

        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "grades.xml")
        Try
            Dim dir = System.IO.Path.GetDirectoryName(path)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If


            Dim allGrades As List(Of Grade)
            If File.Exists(path) Then
                Dim xs As New XmlSerializer(GetType(List(Of Grade)))
                Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim obj = xs.Deserialize(fs)
                    If obj IsNot Nothing Then
                        allGrades = DirectCast(obj, List(Of Grade))
                    Else
                        allGrades = New List(Of Grade)()
                    End If
                End Using
            Else
                allGrades = New List(Of Grade)()
            End If

            Dim existingGrade = allGrades.FirstOrDefault(Function(g) g.StudentID = grade.StudentID AndAlso g.SubjectID = grade.SubjectID)
            If existingGrade IsNot Nothing Then
                allGrades.Remove(existingGrade)
            End If
            allGrades.Add(grade)

            Dim xsWrite As New XmlSerializer(GetType(List(Of Grade)))
            Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                xsWrite.Serialize(fs, allGrades)
            End Using

            Debug.WriteLine("Grade saved successfully")
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving grade: " & ex.ToString())
            Return False
        End Try
    End Function

    Public Function LoadSubjects() As List(Of Subject)
        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "subjects.xml")
        If Not File.Exists(path) Then
            Return New List(Of Subject)()
        End If

        Try
            Dim xs As New XmlSerializer(GetType(List(Of Subject)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj Is Nothing Then
                    Return New List(Of Subject)()
                End If
                Return DirectCast(obj, List(Of Subject))
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading subjects: " & ex.ToString())
            Return New List(Of Subject)()
        End Try
    End Function

    Public Function SaveSubject(subject As Subject) As Boolean
        If subject Is Nothing Then Return False

        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "subjects.xml")
        Try
            Dim dir = System.IO.Path.GetDirectoryName(path)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            ' Load existing subjects
            Dim allSubjects As List(Of Subject)
            If File.Exists(path) Then
                Dim xs As New XmlSerializer(GetType(List(Of Subject)))
                Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim obj = xs.Deserialize(fs)
                    If obj IsNot Nothing Then
                        allSubjects = DirectCast(obj, List(Of Subject))
                    Else
                        allSubjects = New List(Of Subject)()
                    End If
                End Using
            Else
                allSubjects = New List(Of Subject)()
            End If

            ' Add new subject
            allSubjects.Add(subject)

            ' Save all subjects
            Dim xsWrite As New XmlSerializer(GetType(List(Of Subject)))
            Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                xsWrite.Serialize(fs, allSubjects)
            End Using

            Debug.WriteLine("Subject saved successfully")
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving subject: " & ex.ToString())
            Return False
        End Try
    End Function

    ' Task Management Methods
    Public Function LoadTasks(Optional subjectID As String = "") As List(Of Task)
        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "tasks.xml")
        If Not File.Exists(path) Then
            Return New List(Of Task)()
        End If

        Try
            Dim xs As New XmlSerializer(GetType(List(Of Task)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj Is Nothing Then
                    Return New List(Of Task)()
                End If
                Dim allTasks = DirectCast(obj, List(Of Task))
                If String.IsNullOrEmpty(subjectID) Then
                    Return allTasks
                Else
                    Return allTasks.Where(Function(t) t.SubjectID = subjectID).ToList()
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading tasks: " & ex.ToString())
            Return New List(Of Task)()
        End Try
    End Function

    Public Function SaveTask(task As Task) As Boolean
        If task Is Nothing Then Return False

        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "tasks.xml")
        Try
            Dim dir = System.IO.Path.GetDirectoryName(path)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            ' Load existing tasks
            Dim allTasks As List(Of Task)
            If File.Exists(path) Then
                Dim xs As New XmlSerializer(GetType(List(Of Task)))
                Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim obj = xs.Deserialize(fs)
                    If obj IsNot Nothing Then
                        allTasks = DirectCast(obj, List(Of Task))
                    Else
                        allTasks = New List(Of Task)()
                    End If
                End Using
            Else
                allTasks = New List(Of Task)()
            End If

            ' Add or update task
            Dim existingTask = allTasks.FirstOrDefault(Function(t) t.TaskID = task.TaskID)
            If existingTask IsNot Nothing Then
                allTasks.Remove(existingTask)
            End If
            allTasks.Add(task)

            ' Save all tasks
            Dim xsWrite As New XmlSerializer(GetType(List(Of Task)))
            Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                xsWrite.Serialize(fs, allTasks)
            End Using

            Debug.WriteLine("Task saved successfully")
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving task: " & ex.ToString())
            Return False
        End Try
    End Function

    Public Function DeleteTask(taskID As String) As Boolean
        If String.IsNullOrEmpty(taskID) Then Return False

        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "tasks.xml")
        If Not File.Exists(path) Then
            Return False
        End If

        Try
            ' Load existing tasks
            Dim allTasks As List(Of Task)
            Dim xs As New XmlSerializer(GetType(List(Of Task)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj IsNot Nothing Then
                    allTasks = DirectCast(obj, List(Of Task))
                Else
                    allTasks = New List(Of Task)()
                End If
            End Using

            ' Remove the task
            Dim taskToRemove = allTasks.FirstOrDefault(Function(t) t.TaskID = taskID)
            If taskToRemove IsNot Nothing Then
                allTasks.Remove(taskToRemove)

                ' Save updated tasks list
                Dim xsWrite As New XmlSerializer(GetType(List(Of Task)))
                Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                    xsWrite.Serialize(fs, allTasks)
                End Using

                Debug.WriteLine("Task deleted successfully")
                Return True
            Else
                Debug.WriteLine("Task not found for deletion")
                Return False
            End If
        Catch ex As Exception
            Debug.WriteLine("Error deleting task: " & ex.ToString())
            Return False
        End Try
    End Function

    ' TaskSubmission Management Methods
    Public Function LoadSubmissions(Optional taskID As String = "") As List(Of TaskSubmission)
        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "submissions.xml")
        If Not File.Exists(path) Then
            Return New List(Of TaskSubmission)()
        End If

        Try
            Dim xs As New XmlSerializer(GetType(List(Of TaskSubmission)))
            Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                Dim obj = xs.Deserialize(fs)
                If obj Is Nothing Then
                    Return New List(Of TaskSubmission)()
                End If
                Dim allSubmissions = DirectCast(obj, List(Of TaskSubmission))
                If String.IsNullOrEmpty(taskID) Then
                    Return allSubmissions
                Else
                    Return allSubmissions.Where(Function(s) s.TaskID = taskID).ToList()
                End If
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error loading submissions: " & ex.ToString())
            Return New List(Of TaskSubmission)()
        End Try
    End Function

    Public Function SaveSubmission(submission As TaskSubmission) As Boolean
        If submission Is Nothing Then Return False

        Dim path As String = System.IO.Path.Combine(GetDataDirectoryPath(), "submissions.xml")
        Try
            Dim dir = System.IO.Path.GetDirectoryName(path)
            If Not Directory.Exists(dir) Then
                Directory.CreateDirectory(dir)
            End If

            ' Load existing submissions
            Dim allSubmissions As List(Of TaskSubmission)
            If File.Exists(path) Then
                Dim xs As New XmlSerializer(GetType(List(Of TaskSubmission)))
                Using fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read)
                    Dim obj = xs.Deserialize(fs)
                    If obj IsNot Nothing Then
                        allSubmissions = DirectCast(obj, List(Of TaskSubmission))
                    Else
                        allSubmissions = New List(Of TaskSubmission)()
                    End If
                End Using
            Else
                allSubmissions = New List(Of TaskSubmission)()
            End If

            ' Add or update submission
            Dim existingSubmission = allSubmissions.FirstOrDefault(Function(s) s.SubmissionID = submission.SubmissionID)
            If existingSubmission IsNot Nothing Then
                allSubmissions.Remove(existingSubmission)
            End If
            allSubmissions.Add(submission)

            ' Save all submissions
            Dim xsWrite As New XmlSerializer(GetType(List(Of TaskSubmission)))
            Using fs As New FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)
                xsWrite.Serialize(fs, allSubmissions)
            End Using

            Debug.WriteLine("Submission saved successfully")
            Return True
        Catch ex As Exception
            Debug.WriteLine("Error saving submission: " & ex.ToString())
            Return False
        End Try
    End Function
End Module

