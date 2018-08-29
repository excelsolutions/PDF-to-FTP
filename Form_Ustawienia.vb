Public Class Form_Ustawienia
    Private Sub Btn_Zapisz_Click(sender As Object, e As EventArgs) Handles Btn_Zapisz.Click
        My.Settings.Folder_PDF = Me.T_Sciezka_PDF.Text
        My.Settings.Folder_FTP = Me.T_Sciezka_FTP.Text
        My.Settings.Login_FTP = Me.T_Login.Text
        My.Settings.Haslo_FTP = Me.T_Haslo.Text
        My.Settings.Save()
        Me.Hide()
        Aktualizacja_Statusow(True)
        If Form_Main.L_PIC_FTP.BackColor = Color.Lime Then
            Form_Main.Timer_PIC.Enabled = False
        Else
            Form_Main.Timer_PIC.Enabled = True
        End If
    End Sub

    Private Sub Pic_PDF_Click(sender As Object, e As EventArgs) Handles Pic_PDF.Click
        ' Wybor_Folderu.ShowDialog()
        If Wybor_Folderu.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.T_Sciezka_PDF.Text = (Wybor_Folderu.SelectedPath) & "\"
        End If

    End Sub

    Private Sub Pic_FTP_Click(sender As Object, e As EventArgs) Handles Pic_FTP.Click
        If Wybor_Folderu.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.T_Sciezka_FTP.Text = (Wybor_Folderu.SelectedPath) & "\"
        End If

    End Sub

    Private Sub Form_Ustawienia_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Btn_Anuluj_Click(sender As Object, e As EventArgs) Handles Btn_Anuluj.Click
        Me.T_Sciezka_PDF.Text = My.Settings.Folder_PDF
        Me.T_Sciezka_FTP.Text = My.Settings.Folder_FTP
        Me.T_Login.Text = My.Settings.Login_FTP
        Me.T_Haslo.Text = My.Settings.Haslo_FTP
        Me.Hide()
        Aktualizacja_Statusow(True)
        If Form_Main.L_PIC_FTP.BackColor = Color.Lime Then
            Form_Main.Timer_PIC.Enabled = False
        Else
            Form_Main.Timer_PIC.Enabled = True
        End If
    End Sub

    Private Sub T_Sciezka_PDF_TextChanged(sender As Object, e As EventArgs) Handles T_Sciezka_PDF.TextChanged

        If Microsoft.VisualBasic.Right(T_Sciezka_PDF.Text, 1) <> "\" Then
            T_Sciezka_PDF.Text = T_Sciezka_PDF.Text & "\"
        End If
    End Sub
End Class