Imports System
Imports System.ComponentModel

Public Class RegisterForm1

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub

    Private Sub Cancel_Click(ByVal sender As Object, ByVal e As EventArgs)
        Close()
    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged

    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged

    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Role As String = "Student"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim home As New Form1()
        home.Show()
        Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim firstName As String = TextBox3.Text.Trim()
        Dim lastName As String = TextBox4.Text.Trim()
        Dim gender As String = ""
        Dim department As String = TextBox5.Text.Trim()
        Dim username As String = TextBox7.Text.Trim()
        Dim password As String = TextBox8.Text.Trim()

        If RadioButton4.Checked Then
            gender = "Male"
        ElseIf RadioButton5.Checked Then
            gender = "Female"
        End If

        If firstName = "" OrElse lastName = "" OrElse gender = "" OrElse department = "" OrElse username = "" OrElse password = "" Then
            MessageBox.Show("Please fill in all fields before signing up.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim newUser As New User With {
            .ID = Guid.NewGuid().ToString(),
            .Role = Me.Role,
            .Username = username,
            .Password = password,
            .FirstName = firstName,
            .LastName = lastName,
            .Gender = gender,
            .Department = department
        }

        ' Register the user - this function now shows its own error messages
        If Not DataStore.RegisterNewUser(newUser) Then
            ' Registration failed - error message already shown by RegisterNewUser
            Return
        End If

        Session.CurrentUser = newUser

        ' Registration succeeded - show success message with file location
        Dim filePath = DataStore.GetDataFilePath(newUser.Role)
        Dim dataDir = DataStore.GetDataDirectoryPath()
        Dim fileExists = System.IO.File.Exists(filePath)
        Dim usersInFile = DataStore.LoadUsers(newUser.Role).Count

        MessageBox.Show("Registration Successful!" & vbCrLf &
                       "Welcome, " & firstName & " " & lastName & vbCrLf & vbCrLf &
                       "Your credentials have been saved!" & vbCrLf & vbCrLf &
                       "Username: " & username & vbCrLf &
                       "Role: " & newUser.Role & vbCrLf & vbCrLf &
                       "Data Directory: " & dataDir & vbCrLf &
                       "File: " & filePath & vbCrLf &
                       "File exists: " & fileExists.ToString() & vbCrLf &
                       "Users in file: " & usersInFile.ToString() & vbCrLf & vbCrLf &
                       "You can now log in with these credentials after restarting the application.",
                       "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Try
            Dim main As New Form2(newUser)
            main.Show()
            Me.Hide()
        Catch ex As Exception
            MessageBox.Show("Error opening main application: " & ex.Message & vbCrLf & vbCrLf &
                           "You have been registered successfully. Please restart the application and log in.",
                           "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Panel4_Paint(sender As Object, e As PaintEventArgs) Handles Panel4.Paint

    End Sub

    Private Sub CheckBoxShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowPassword.CheckedChanged
        TextBox8.PasswordChar = If(CheckBoxShowPassword.Checked, ControlChars.NullChar, "*"c)
    End Sub
End Class