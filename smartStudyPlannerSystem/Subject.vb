Public Class Subject
    Public Property SubjectID As String
    Public Property SubjectName As String
    Public Property InstructorID As String
    Public Property InstructorName As String
    Public Property Department As String
    Public Property Description As String
    Public Property CreatedDate As DateTime = Now

    Public Sub New()
    End Sub

    Public Sub New(subjectName As String, instructorID As String, instructorName As String, department As String, description As String)
        Me.SubjectID = Guid.NewGuid().ToString()
        Me.SubjectName = subjectName
        Me.InstructorID = instructorID
        Me.InstructorName = instructorName
        Me.Department = department
        Me.Description = description
        Me.CreatedDate = Now
    End Sub
End Class
