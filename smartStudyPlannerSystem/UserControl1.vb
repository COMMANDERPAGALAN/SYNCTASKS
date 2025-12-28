Imports System.ComponentModel

Public Class UserControl1
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Mode As String ' "Login" or "Register"

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' INSTRUCTOR selected
        If Mode = "Register" Then
            Dim reg As New RegisterForm1()
            reg.Role = "Instructor"
            reg.Show()
            Me.ParentFormOrOwnerHide()
        Else
            Dim loginForm As New MainLogin()
            loginForm.Role = "Instructor"
            loginForm.Show()
            Me.ParentFormOrOwnerHide()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' STUDENT selected
        If Mode = "Register" Then
            Dim reg As New RegisterForm1()
            reg.Role = "Student"
            reg.Show()
            Me.ParentFormOrOwnerHide()
        Else
            Dim loginForm As New MainLogin()
            loginForm.Role = "Student"
            loginForm.Show()
            Me.ParentFormOrOwnerHide()
        End If
    End Sub
    ' helper to hide the hosting form cleanly (HostRoleForm)
    Private Sub ParentFormOrOwnerHide()
        If Me.Parent IsNot Nothing AndAlso TypeOf Me.Parent Is Form Then
            CType(Me.Parent, Form).Hide()
        ElseIf Me.TopLevelControl IsNot Nothing AndAlso TypeOf Me.TopLevelControl Is Form Then
            CType(Me.TopLevelControl, Form).Hide()
        End If
    End Sub

End Class