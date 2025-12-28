Imports System.ComponentModel

Public Class MainLogin

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Role As String = "Student" ' set by caller

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim username = TextBox2.Text.Trim
        Dim password = TextBox1.Text.Trim

        If username = "" OrElse password = "" Then
            MessageBox.Show("Please enter username and password.", "Missing", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim user = ValidateLogin(Role, username, password)
        If user Is Nothing Then
            Dim filePath = GetDataFilePath(Role)
            Dim usersCount = LoadUsers(Role).Count
            Dim fileExists = IO.File.Exists(filePath)

            Dim errorMsg = "Invalid username or password for " & Role & "." & vbCrLf & vbCrLf &
                          "Debug Information:" & vbCrLf &
                          "File location: " & filePath & vbCrLf &
                          "File exists: " & fileExists.ToString & vbCrLf &
                          "Registered users: " & usersCount.ToString & vbCrLf & vbCrLf &
                          "Please check:" & vbCrLf &
                          "1. Your username and password are correct" & vbCrLf &
                          "2. You selected the correct role (Instructor/Student)" & vbCrLf &
                          "3. You have registered an account"

            MessageBox.Show(errorMsg, "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        CurrentUser = user
        Dim main As New Form2(user)
        main.Show()
        Hide()
    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim home As New Form1()
        home.Show()
        Hide()
    End Sub

    ' Back button on the login panel returns to the initial host selection
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim frm As New Form1()
        frm.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBoxShowPassword_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxShowPassword.CheckedChanged
        TextBox1.PasswordChar = If(CheckBoxShowPassword.Checked, ControlChars.NullChar, "*"c)
    End Sub


End Class
