Imports System.Net.Mail
Public Class Form_O_Mnie
    Private Sub Btn_Zamknij_Click(sender As Object, e As EventArgs) Handles Btn_Zamknij.Click
        Me.Hide()
    End Sub

    Private Sub LinkMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkMail.LinkClicked
        Process.Start("Mailto:" & LinkMail.Text)
        My.Computer.Clipboard.SetText(LinkMail.Text)
    End Sub

    Private Sub LinkTel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkTel.LinkClicked
        My.Computer.Clipboard.SetText(LinkTel.Text)

    End Sub

    Private Sub LinkSkype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSkype.LinkClicked
        My.Computer.Clipboard.SetText(LinkSkype.Text)
        MsgBox("Kontakt: " & LinkSkype.Text & " skopiowano do schowka")
    End Sub

    Private Sub LinkWWW_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkWWW.LinkClicked
        Dim webAddress As String = "http://www.excelsolutions.pl"
        Process.Start(webAddress)

    End Sub
End Class