Public Class TaskSubmission
    Public Property SubmissionID As String
    Public Property TaskID As String
    Public Property StudentID As String
    Public Property StudentName As String
    Public Property SubmittedFilePath As String
    Public Property SubmittedFileNames As List(Of String)
    Public Property SubmissionDate As DateTime = Now
    Public Property Status As String = "Submitted" ' Submitted, Graded, Late
    Public Property InstructorFeedback As String = ""
    Public Property Score As Decimal = 0

    Public Sub New()
        SubmittedFileNames = New List(Of String)()
    End Sub

    Public Sub New(taskID As String, studentID As String, studentName As String)
        Me.SubmissionID = Guid.NewGuid().ToString()
        Me.TaskID = taskID
        Me.StudentID = studentID
        Me.StudentName = studentName
        Me.SubmissionDate = Now
        Me.SubmittedFileNames = New List(Of String)()
    End Sub

    Public Function IsLate(taskDeadline As DateTime) As Boolean
        Return SubmissionDate > taskDeadline
    End Function
End Class
