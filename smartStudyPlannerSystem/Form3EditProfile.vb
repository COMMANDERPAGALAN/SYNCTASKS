Public Class Form3EditProfile
    Private currentUser As User

    Private Sub Form3EditProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Session.CurrentUser Is Nothing Then
            MessageBox.Show("No user loaded.", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
            Return
        End If

        currentUser = ReloadCurrentUser()
        If currentUser Is Nothing Then
            MessageBox.Show("Unable to load user details for editing.", "Edit Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Close()
            Return
        End If

        Session.CurrentUser = currentUser

        RichTextBox1.Text = (If(String.IsNullOrEmpty(currentUser.FirstName), "", currentUser.FirstName) & " " & If(String.IsNullOrEmpty(currentUser.LastName), "", currentUser.LastName)).Trim()
        RichTextBox2.Text = If(String.IsNullOrEmpty(currentUser.Gender), "", currentUser.Gender)
        RichTextBox3.Text = If(String.IsNullOrEmpty(currentUser.Department), "", currentUser.Department)

        LoadProfilePicture()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Using openFileDialog As New OpenFileDialog
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp|All Files|*.*"
            openFileDialog.Title = "Select Profile Picture"

            If openFileDialog.ShowDialog = DialogResult.OK Then
                Try
                    Dim originalImage = Image.FromFile(openFileDialog.FileName)
                    Dim pbSize = PictureBox1.Size

                    Dim ratioX = pbSize.Width / originalImage.Width
                    Dim ratioY = pbSize.Height / originalImage.Height
                    Dim ratio = Math.Max(ratioX, ratioY) ' Use max to fill (crop if needed)

                    Dim newWidth = CInt(originalImage.Width * ratio)
                    Dim newHeight = CInt(originalImage.Height * ratio)

                    Dim resizedImage As New Bitmap(pbSize.Width, pbSize.Height)
                    Using g = Graphics.FromImage(resizedImage)
                        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
                        g.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
                        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality

                        Dim x = (pbSize.Width - newWidth) \ 2
                        Dim y = (pbSize.Height - newHeight) \ 2
                        g.DrawImage(originalImage, x, y, newWidth, newHeight)
                    End Using

                    If PictureBox1.Image IsNot Nothing Then
                        PictureBox1.Image.Dispose()
                    End If

                    PictureBox1.Image = resizedImage
                    PictureBox1.SizeMode = PictureBoxSizeMode.Normal
                    originalImage.Dispose
                Catch ex As Exception
                    MessageBox.Show("Error loading image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        End Using
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        If String.IsNullOrWhiteSpace(RichTextBox1.Text) OrElse
           String.IsNullOrWhiteSpace(RichTextBox2.Text) OrElse
           String.IsNullOrWhiteSpace(RichTextBox3.Text) Then
            MessageBox.Show("Please fill all fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim nameText = RichTextBox1.Text.Trim()
        Dim nameParts = nameText.Split(New Char() {" "c}, StringSplitOptions.RemoveEmptyEntries)
        currentUser.FirstName = If(nameParts.Length > 0, nameParts(0), "")
        currentUser.LastName = If(nameParts.Length > 1, String.Join(" ", nameParts.Skip(1)), "")
        currentUser.Gender = RichTextBox2.Text.Trim()
        currentUser.Department = RichTextBox3.Text.Trim()

        If PictureBox1.Image IsNot Nothing Then
            Try
                Dim picturePath = GetProfilePicturePath()
                Dim pictureDirectory = IO.Path.GetDirectoryName(picturePath)
                If Not IO.Directory.Exists(pictureDirectory) Then
                    IO.Directory.CreateDirectory(pictureDirectory)
                End If

                If IO.File.Exists(picturePath) Then
                    IO.File.Delete(picturePath)
                End If

                Using bmp As New Bitmap(PictureBox1.Image.Width, PictureBox1.Image.Height)
                    Using g As Graphics = Graphics.FromImage(bmp)
                        g.DrawImage(PictureBox1.Image, 0, 0, bmp.Width, bmp.Height)
                    End Using
                    bmp.Save(picturePath, System.Drawing.Imaging.ImageFormat.Jpeg)
                End Using
            Catch ex As Exception
                MessageBox.Show("Error saving picture: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
        End If

        ' Save to database/DataStore
        If DataStore.UpdateUser(currentUser) Then
            ' Update Session
            Session.CurrentUser = currentUser
            MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()
        Else
            MessageBox.Show("Failed to update profile. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Close
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If currentUser Is Nothing Then
            MessageBox.Show("No user is loaded.", "Delete Account", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        Dim confirm = MessageBox.Show("This will permanently delete your account and data. Continue?", "Delete Account", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If confirm <> DialogResult.Yes Then
            Return
        End If

        If Not DataStore.DeleteUser(currentUser.Username, currentUser.Role) Then
            Return
        End If

        DeleteProfilePictureFile()
        Session.LogOut()
        MessageBox.Show("Your account has been deleted.", "Account Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Dim loginForm As New Form1()
        loginForm.Show()

        For i = Application.OpenForms.Count - 1 To 0 Step -1
            Dim frm = Application.OpenForms(i)
            If Not Object.ReferenceEquals(frm, loginForm) Then
                frm.Close()
            End If
        Next
    End Sub

    Private Sub LoadProfilePicture()
        If currentUser Is Nothing Then Return

        Try
            Dim picturePath = GetProfilePicturePath()
            If IO.File.Exists(picturePath) Then
                Using fs As New IO.FileStream(picturePath, IO.FileMode.Open, IO.FileAccess.Read, IO.FileShare.ReadWrite)
                    Using original = Image.FromStream(fs)
                        Dim copy As New Bitmap(original)
                        SetPicture(copy)
                    End Using
                End Using
            End If
        Catch
            ' Ignore image load issues to avoid blocking profile edits
        End Try
    End Sub

    Private Sub SetPicture(image As Image)
        If PictureBox1.Image IsNot Nothing Then
            PictureBox1.Image.Dispose()
        End If
        PictureBox1.Image = image
    End Sub

    Private Function GetProfilePicturePath() As String
        Dim appDir = Application.StartupPath
        Return IO.Path.Combine(appDir, "UserPictures", $"{currentUser.Username}_profile.jpg")
    End Function

    Private Function ReloadCurrentUser() As User
        If Session.CurrentUser Is Nothing Then Return Nothing
        Dim latest = DataStore.GetUser(Session.CurrentUser.Role, Session.CurrentUser.Username)
        Return If(latest, Session.CurrentUser)
    End Function

    Private Sub DeleteProfilePictureFile()
        Try
            Dim picturePath = GetProfilePicturePath()
            If IO.File.Exists(picturePath) Then
                IO.File.Delete(picturePath)
            End If
        Catch
            ' Ignore cleanup failures
        End Try
    End Sub
End Class