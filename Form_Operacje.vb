Public Class Form_Operacje
    Private Sub Lista_Operacji_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lista_Operacji.SelectedIndexChanged

    End Sub

    Private Sub Form_Operacje_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Utworzenie kolumn w Formie_Operacje
        Me.Lista_Operacji.Columns.Add("No.", 50)
        Me.Lista_Operacji.Columns.Add("File name", 100)
        Me.Lista_Operacji.Columns.Add("Delivery note number", 100)
        Me.Lista_Operacji.Columns.Add("New name of file", 250)
        Me.Lista_Operacji.Columns.Add("Sending status", 90)
    End Sub

    Private Sub Lista_Operacji_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Lista_Operacji.MouseDoubleClick
        If Me.Lista_Operacji.SelectedItems(0).Tag IsNot Nothing Then
            Form_Podglad.Show()
            Form_Podglad.Rich_Podglad.Text = ParsePdfText(Me.Lista_Operacji.SelectedItems(0).Tag)
        End If

    End Sub

    Private Sub Form_Operacje_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form_Main.Show()
    End Sub
End Class