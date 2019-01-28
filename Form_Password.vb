Public Class Form_Password


    ' (See https://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If PasswordTextBox.Text = "qwerty1" Then
            L_Pass_Incorect.Visible = False
            Me.Close()

            Form_Main.Hide()
            Form_Ustawienia.Show()

        Else
            L_Pass_Incorect.Visible = True
        End If
    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub Form_Password_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PasswordTextBox.Text = ""
    End Sub

    Private Sub LogoPictureBox_Click(sender As Object, e As EventArgs) Handles LogoPictureBox.Click

    End Sub

    Private Sub LogoPictureBox_DoubleClick(sender As Object, e As EventArgs) Handles LogoPictureBox.DoubleClick

    End Sub
End Class
