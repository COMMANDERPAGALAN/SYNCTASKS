Public Class Grade
    Public Property GradeID As String
    Public Property StudentID As String
    Public Property StudentName As String
    Public Property SubjectID As String
    Public Property SubjectName As String
    Public Property InstructorID As String
    Public Property InstructorName As String
    Public Property Score As Decimal
    Public Property TotalScore As Decimal = 100
    Public Property Percentage As Decimal
    Public Property LetterGrade As String
    Public Property DateSubmitted As DateTime = Now

    Public Sub New()
    End Sub

    Public Sub New(studentID As String, studentName As String, subjectID As String, subjectName As String, score As Decimal)
        Me.GradeID = Guid.NewGuid().ToString()
        Me.StudentID = studentID
        Me.StudentName = studentName
        Me.SubjectID = subjectID
        Me.SubjectName = subjectName
        Me.Score = score
        Me.TotalScore = 100
        Me.Percentage = (score / 100) * 100
        Me.LetterGrade = CalculateLetterGrade(Me.Percentage)
        Me.DateSubmitted = Now
    End Sub

    Private Function CalculateLetterGrade(percentage As Decimal) As String
        If percentage >= 90 Then
            Return "A"
        ElseIf percentage >= 80 Then
            Return "B"
        ElseIf percentage >= 70 Then
            Return "C"
        ElseIf percentage >= 60 Then
            Return "D"
        Else
            Return "F"
        End If
    End Function
End Class
