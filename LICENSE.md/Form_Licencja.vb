Public Class Form_Licencja
    Private Sub RichTextBox1_TextChanged(sender As Object, e As EventArgs) Handles RichTextBox1.TextChanged

    End Sub



    Private Sub RichTextBox1_LinkClicked(sender As Object, e As LinkClickedEventArgs) Handles RichTextBox1.LinkClicked
        Process.Start("http://www.gnu.org/licenses/")
    End Sub

    Private Sub Btn_Zamknij_Click(sender As Object, e As EventArgs) Handles Btn_Zamknij.Click
        Me.Hide()
    End Sub
End Class