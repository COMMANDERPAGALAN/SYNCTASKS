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
