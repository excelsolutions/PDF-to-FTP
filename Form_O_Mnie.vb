Imports System.Net.Mail
Public Class Form_O_Mnie
    Private Sub Btn_Zamknij_Click(sender As Object, e As EventArgs) Handles Btn_Zamknij.Click
        Me.Hide()
    End Sub

    Private Sub LinkMail_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkMail.LinkClicked
        Try
            Process.Start("Mailto:" & LinkMail.Text)
            My.Computer.Clipboard.SetText(LinkMail.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkTel_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)


    End Sub

    Private Sub LinkSkype_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkSkype.LinkClicked
        Try
            My.Computer.Clipboard.SetText(LinkSkype.Text)
            MsgBox("Kontakt: " & LinkSkype.Text & " skopiowano do schowka")
        Catch ex As Exception

        End Try

    End Sub

    Private Sub LinkWWW_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkWWW.LinkClicked
        Try
            Dim webAddress As String = "http://www.excelsolutions.pl"
            Process.Start(webAddress)
        Catch ex As Exception

        End Try


    End Sub

    Private Sub Form_O_Mnie_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        L_Wersja.Text = "Ver. " & Me.GetType.Assembly.GetName.Version.ToString
    End Sub

    Private Sub L_Wersja_Click(sender As Object, e As EventArgs) Handles L_Wersja.Click
        Try
            Dim webAddress As String = "http://excelsolutions.pl/pdf-to-ftp/"
            Process.Start(webAddress)
        Catch ex As Exception

        End Try

    End Sub
End Class