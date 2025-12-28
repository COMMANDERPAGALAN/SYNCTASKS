Module AppGlobals
    Public CurrentMode As String = ""     ' "Login" or "Register"
    Public CurrentUserType As String = "" ' "Instructor" or "Student"
End Module

Module Globals
    Public SelectedRole As String = "" ' "Instructor" or "Student"
End Module

' NOTE: Session, User, and DataStore are now defined in separate files:
' - Session.vb
' - User.vb  
' - DataStore.vb
' This prevents duplicate definition errors and allows better organization.
