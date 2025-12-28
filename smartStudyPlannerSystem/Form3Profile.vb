Public Class Form3Profile
    Private Sub Form3Profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadProfileData()
    End Sub

    ' Refresh profile when form becomes visible (real-time updates)
    Private Sub Form3Profile_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        If Me.Visible AndAlso Session.CurrentUser IsNot Nothing Then
            ' Reload profile to get latest data
            LoadProfileData()
        End If
    End Sub

    Private Sub LoadProfileData()
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        ' Reload user data from DataStore to ensure we have the latest information
        Dim currentUser = Session.CurrentUser
        Dim u = DataStore.GetUser(currentUser.Role, currentUser.Username)
        
        ' If user found in DataStore, use that; otherwise use session user
        If u IsNot Nothing Then
            Session.CurrentUser = u ' Update session with latest data
            u = Session.CurrentUser
        Else
            u = Session.CurrentUser
        End If

        ' NAME - RichTextBox1 (First Name + Last Name from registration)
        ' Combine FirstName and LastName from RegisterForm1.vb (TextBox3 and TextBox4)
        Dim firstName = If(String.IsNullOrWhiteSpace(u.FirstName), "", u.FirstName)
        Dim lastName = If(String.IsNullOrWhiteSpace(u.LastName), "", u.LastName)
        RichTextBox1.Text = (firstName & " " & lastName).Trim()
        
        ' GENDER - RichTextBox2
        RichTextBox2.Text = If(String.IsNullOrWhiteSpace(u.Gender), "", u.Gender)
        
        ' COLLEGE DEPARTMENT - RichTextBox3 (Department from registration)
        ' Display Department from RegisterForm1.vb (TextBox5)
        RichTextBox3.Text = If(String.IsNullOrWhiteSpace(u.Department), "", u.Department)

        LoadProfilePicture(u)
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        ' Open Edit Profile form
        Dim editForm As New Form3EditProfile()
        editForm.ShowDialog(Me)

        ' Reload profile after edit
        Form3Profile_Load(Nothing, Nothing)
    End Sub
    Private Sub LoadProfilePicture(user As User)
        Try
            Dim appDir = Application.StartupPath
            Dim picturePath = System.IO.Path.Combine(appDir, "UserPictures", $"{user.Username}_profile.jpg")
            If IO.File.Exists(picturePath) Then
                Using fs As New IO.FileStream(picturePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                    Using original = Image.FromStream(fs)
                        Dim copy As New Bitmap(original)
                        If PictureBox1.Image IsNot Nothing Then
                            PictureBox1.Image.Dispose()
                        End If
                        PictureBox1.Image = copy
                    End Using
                End Using
            Else
                If PictureBox1.Image IsNot Nothing Then
                    PictureBox1.Image.Dispose()
                    PictureBox1.Image = Nothing
                End If
            End If
        Catch
            ' Ignore image load issues
        End Try
    End Sub
End Class