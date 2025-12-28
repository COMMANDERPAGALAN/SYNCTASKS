Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
    End Sub

    Private Sub Register_Click(sender As Object, e As EventArgs) Handles Register.Click
        Dim host As New HostRoleForm("Register")
        host.Show()
        Me.Hide()
    End Sub

    Private Sub Login_Click(sender As Object, e As EventArgs) Handles Login.Click
        Dim host As New HostRoleForm("Login")
        host.Show()
        Me.Hide()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class