Public Class IntroForm
    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim home As New Form1()
        home.Show()
        Me.Hide()
    End Sub
End Class