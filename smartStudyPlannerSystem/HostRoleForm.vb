Imports System.Windows.Forms
Imports System.ComponentModel
Public Class HostRoleForm
    Inherits Form

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Mode As String ' "Login" or "Register"

    Private ctrl As UserControl1

    Public Sub New(mode As String)
        Me.Mode = mode
        InitializeComponent()
        Me.Text = If(mode = "Login", "Select Role - Login", "Select Role - Register")

        ctrl = New UserControl1()
        ctrl.Mode = mode
        ctrl.Dock = DockStyle.Fill
        Me.Controls.Add(ctrl)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ClientSize = New System.Drawing.Size(980, 690)
        Me.Name = "HostRoleForm"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
    End Sub
End Class