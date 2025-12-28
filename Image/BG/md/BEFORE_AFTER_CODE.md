# Code Changes - Before & After

## Change #1: DataStore.vb - Line 68

### ? BEFORE (BROKEN)
```vb
Public Function SaveUsers(role As String, users As List(Of User)) As Boolean
    Dim path = GetDataFilePath(role)
    Try
        ' Correct: use System.IO.Path.GetDirectoryName to get folder portion
   Dim dir = path.GetDirectoryName(path)  ' ? ERROR: 'GetDirectoryName' is not a member of 'String'
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
```

**Problem**: `GetDirectoryName` is a static method in `System.IO.Path`, not an instance method on `String`.

### ? AFTER (FIXED)
```vb
Public Function SaveUsers(role As String, users As List(Of User)) As Boolean
    Dim path = GetDataFilePath(role)
    Try
        ' Correct: use System.IO.Path.GetDirectoryName to get folder portion
        Dim dir = System.IO.Path.GetDirectoryName(path)  ' ? FIXED: Use System.IO.Path
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
```

**Solution**: Call `System.IO.Path.GetDirectoryName()` which is the correct static method.

---

## Change #2: RegisterForm1.vb - Button Handlers

### ? BEFORE (HANDLERS SWAPPED)
```vb
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
Public Property Role As String = "Student"

' ? WRONG: Button1 (CANCEL) but goes back to login (should register!)
Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
    ' Back to login selection
    Dim loginForm As New MainLogin()
    loginForm.Role = Me.Role
    loginForm.Show()
    Me.Hide()
End Sub

' ? WRONG: Button1 (CANCEL button) but does registration (should cancel!)
Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    Dim firstName As String = TextBox3.Text.Trim()
    Dim lastName As String = TextBox4.Text.Trim()
    ' ... full registration logic ...
    If Not DataStore.RegisterNewUser(newUser) Then
        Return
    End If
    ' ... success logic ...
End Sub
```

**Problem**: The handlers are assigned to the wrong buttons:
- **Button1** is labeled "CANCEL" in Designer but had registration logic
- **Button2** is labeled "SIGN UP" in Designer but had back-button logic

When users click "SIGN UP", it goes back instead of registering. When users click "CANCEL", it tries to register!

### ? AFTER (HANDLERS CORRECTED)
```vb
<DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
Public Property Role As String = "Student"

' ? CORRECT: Button1 (CANCEL) goes back to login
Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
    ' Back to login selection
    Dim loginForm As New MainLogin()
    loginForm.Role = Me.Role
 loginForm.Show()
    Me.Hide()
End Sub

' ? CORRECT: Button2 (SIGN UP) does registration
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
```

**Solution**: Swap the handler implementations so:
- `Button1_Click` (CANCEL button) ? navigates back
- `Button2_Click` (SIGN UP button) ? registers user

---

## Change #3: User.vb - Add Serializable Attribute

### ? BEFORE (NO ATTRIBUTE)
```vb
Imports System

Public Class User
    Public Property ID As String
    Public Property Role As String
    Public Property Username As String
    Public Property Password As String
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Gender As String
  Public Property Department As String

    Public Overrides Function ToString() As String
        Return $"{FirstName} {LastName} ({Role}) - {Username}"
    End Function
End Class
```

**Issue**: While XmlSerializer doesn't strictly require `<Serializable>`, it's a best practice and ensures reliable serialization/deserialization.

### ? AFTER (WITH SERIALIZABLE ATTRIBUTE)
```vb
Imports System

<Serializable>
Public Class User
    Public Property ID As String
    Public Property Role As String
    Public Property Username As String
    Public Property Password As String
    Public Property FirstName As String
    Public Property LastName As String
    Public Property Gender As String
    Public Property Department As String

    Public Overrides Function ToString() As String
      Return $"{FirstName} {LastName} ({Role}) - {Username}"
    End Function
End Class
```

**Solution**: Add `<Serializable>` attribute to explicitly mark the class as serializable.

---

## Summary of Changes

| File | Change | Impact |
|------|--------|--------|
| DataStore.vb | Fixed `GetDirectoryName` call | User data now saves to XML files ? |
| RegisterForm1.vb | Swapped button handlers | SIGN UP button now registers users ? |
| User.vb | Added Serializable attribute | XML serialization more reliable ? |

---

## Compilation Results

### Before Fixes
```
? Build Failed
   Error BC30456: 'GetDirectoryName' is not a member of 'String'
   Location: DataStore.vb, Line 68
```

### After Fixes
```
? Build Successful
   Errors: 0
   Warnings: 0
   All files compile cleanly
```

---

**All changes are minimal, focused, and solve specific issues!** ?
