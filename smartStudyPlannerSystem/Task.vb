Public Class Task
    Public Property TaskID As String
Public Property SubjectID As String
    Public Property SubjectName As String
    Public Property Title As String
    Public Property Description As String
  Public Property InstructorID As String
    Public Property InstructorName As String
    Public Property Deadline As DateTime
    Public Property FilePath As String
    Public Property FileNames As List(Of String)
    Public Property CreatedDate As DateTime = Now
    Public Property Status As String = "Active" ' Active, Completed, Overdue

    Public Sub New()
   FileNames = New List(Of String)()
    End Sub

    Public Sub New(subjectID As String, subjectName As String, title As String, description As String, instructorID As String, instructorName As String, deadline As DateTime)
        Me.TaskID = Guid.NewGuid().ToString()
        Me.SubjectID = subjectID
   Me.SubjectName = subjectName
        Me.Title = title
        Me.Description = description
        Me.InstructorID = instructorID
Me.InstructorName = instructorName
  Me.Deadline = deadline
        Me.CreatedDate = Now
        Me.Status = If(deadline < Now, "Overdue", "Active")
        Me.FileNames = New List(Of String)()
    End Sub

    Public Function GetDaysRemaining() As Integer
        Return CInt((Deadline - Now).TotalDays)
    End Function

    Public Function GetStatus() As String
   If Deadline < Now Then
          Return "Overdue"
        ElseIf GetDaysRemaining() <= 3 Then
          Return "Due Soon"
        Else
            Return "Active"
        End If
    End Function
End Class
