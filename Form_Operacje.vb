Imports System.IO
Public Class Form_Operacje
    Private Sub Lista_Operacji_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Lista_Operacji.SelectedIndexChanged

    End Sub

    Private Sub Form_Operacje_Load(sender As Object, e As EventArgs) Handles Me.Load
        'Utworzenie kolumn w Formie_Operacje
        Me.Lista_Operacji.Columns.Add("No.", 50)
        Me.Lista_Operacji.Columns.Add("File name", 100)
        Me.Lista_Operacji.Columns.Add("Received string of characters", 100)
        'Me.Lista_Operacji.Columns.Add("Delivery note number", 100)
        Me.Lista_Operacji.Columns.Add("New name of file", 250)
        Me.Lista_Operacji.Columns.Add("Save status", 90)
        Me.Lista_Operacji.Columns.Add("Sending status", 90)
    End Sub

    Private Sub Lista_Operacji_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Lista_Operacji.MouseDoubleClick
        Dim Pozycja_Startowa As Long = 0

        If Me.Lista_Operacji.SelectedItems(0).Tag IsNot Nothing Then
            'Debug.Print(Me.Lista_Operacji.SelectedItems(0).Tag)
            If File.Exists(Me.Lista_Operacji.SelectedItems(0).Tag) Then
                My.Forms.Form_Podglad.Text = "Preview PDF file: " & Me.Lista_Operacji.SelectedItems(0).Tag
                Form_Podglad.Show()
                With Form_Podglad.Rich_Podglad
                    .Text = ParsePdfText2(Me.Lista_Operacji.SelectedItems(0).Tag, True)
                    If Klucz <> "" Then
                        Pozycja_Startowa = InStr(.Text, Klucz) - 1
                    Else
                        Pozycja_Startowa = 0
                    End If
                    If Start_Pos + Pozycja_Startowa > 0 Then
                        .SelectionStart = Start_Pos + Pozycja_Startowa - 1
                    Else
                        .SelectionStart = 0
                    End If

                    .SelectionLength = Lenght_Text
                    .SelectionColor = Color.Red
                    .SelectionLength = 0

                End With

            End If

        End If


    End Sub

    Private Sub Form_Operacje_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Form_Main.Show()
    End Sub

    Private Sub Lista_Operacji_RegionChanged(sender As Object, e As EventArgs) Handles Lista_Operacji.RegionChanged

    End Sub
End Class