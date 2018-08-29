'Niniejszy program jest wolnym oprogramowaniem; możesz go
'   rozprowadzać dalej i/lub modyfikować na warunkach Powszechnej
'   Licencji Publicznej GNU, wydanej przez Fundację Wolnego
'   Oprogramowania -według wersji 3 tej Licencji lub (według twojego
'   wyboru) którejś z późniejszych wersji.

'   Niniejszy program rozpowszechniany jest z nadzieją, iż będzie On
'   użyteczny -jednak BEZ JAKIEJKOLWIEK GWARANCJI, nawet domyślnej
'   gwarancji PRZYDATNOŚCI HANDLOWEJ albo PRZYDATNOŚCI Do OKREŚLONYCH
'   ZASTOSOWAŃ.W celu uzyskania bliższych informacji sięgnij do     Powszechnej Licencji Publicznej GNU.

'   Z pewnością wraz z niniejszym programem otrzymałeś też egzemplarz
'   Powszechnej Licencji Publicznej GNU (GNU General Public License);
'   jeśli nie - zobacz <http://www.gnu.org/licenses/>.
'Program korzysta z bibliotek iTEXT dostępnych na stronie https://itextpdf.com/ na licencji AGPL. Warunki użytkowania 
'znajduja się na stronie: http://itextpdf.com/terms-of-use/
'Autor: Łukasz Morawski, e-mail: lukasz.r.morawski@gmail.com
Imports System.IO
'https://social.msdn.microsoft.com/Forums/en-US/7945dbd9-5836-4eaa-b8fe-32ad70002e43/copying-a-file-to-a-ftp-server-in-vbnet-2005-help-please?forum=vblanguage
Public Class Form_Main
    'Throw New System.Exception("An exception has occurred.") 'ZASYMULOWANIE BŁEDU Symulacja błedu

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Start.Click

        If IsConnectedToInternet() = False Then
            MsgBox("Brak dostępu do internetu. Sprawdź połączenie sieciowe.", vbOKOnly, "Błąd")
            L_PIC_FTP.BackColor = Color.Red
            Timer_PIC.Enabled = True
            Exit Sub
        Else
            Aktualizacja_Statusow(True)
        End If

        If Directory.Exists(Form_Ustawienia.T_Sciezka_PDF.Text) And L_PIC_Folder.BackColor = Color.Lime And L_PIC_FTP.BackColor = Color.Lime Then
            Timer_PIC.Enabled = False
            Form_Operacje.Show()
            Me.Hide()
            Form_Operacje.Lista_Operacji.Items.Clear()
            Form_Operacje.Text = "W trakcie przetwarzania plików..."
            'Try
            Przetworz_Pliki(True)
            ' Catch ex As Exception
            'MsgBox("Operacja przetworzenia plików nie wykonała się prawidłowo. Skontaktuj sie z twórca aplikacji", vbOKOnly, "Błąd")
            ' End Try

        ElseIf Not Directory.Exists(Form_Ustawienia.T_Sciezka_PDF.Text) Then
            Timer_PIC.Enabled = True
            MsgBox("Wybrana lokalizacja plików PDF nie istnieje. Proszę o wybranie poprawnej lokalizacji, w której znajduja się pliki PDF", vbOKOnly, "Błąd")
            Exit Sub
        Else
            MsgBox("Program nie zdążył sprawdzić wybranej lokalizacji FTP lub lokalizacja plików PDF lub FTP nie została wskazana bądź została wskazana nieprawidłowo. Prosze o sprawdzenie ustawień lub ponowne sprawdzenie za kilka sekund.", vbOKOnly, "Błąd")
        End If



        '-- STARA DZIAŁAJĄCA WERSJA --
        'Dim strFileName As String
        'OpenFileDialog1.InitialDirectory = "C:\"
        'OpenFileDialog1.FileName = ".pdf"
        'OpenFileDialog1.Title = "Otwórz plik PDF"
        'OpenFileDialog1.Filter = "Pliki PDF|*.pdf"
        'OpenFileDialog1.ShowDialog()
        'strFileName = OpenFileDialog1.FileName

        'My.Forms.Form_Podglad.Rich_Podglad.Text = ParsePdfText(strFileName)
        ''4 litera, 9 liter
        'My.Forms.Form_Podglad.Show()
    End Sub

    Private Sub Form_Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
        Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth

        'Wczytanie ustawień

        Form_Ustawienia.T_Sciezka_PDF.Text = My.Settings.Folder_PDF
        If My.Settings.Folder_FTP = "" Then

        Else
            Form_Ustawienia.T_Sciezka_FTP.Text = My.Settings.Folder_FTP
        End If
        If My.Settings.Login_FTP = "" Then

        Else
            Form_Ustawienia.T_Login.Text = My.Settings.Login_FTP
        End If
        If My.Settings.Haslo_FTP = "" Then

        Else
            Form_Ustawienia.T_Haslo.Text = My.Settings.Haslo_FTP
        End If
        'UStawienia TooTipText
        ToolTip1.SetToolTip(L_LIczba_Plikow, "Liczba odnalezionych plików typu: '.pdf'. Kliknij aby podejrzeć listę odnalezionych plików wraz z wykrytymi numerami referencyjnymi.")
        ToolTip1.SetToolTip(LL_Ilosc_plikow, "Liczba odnalezionych plików typu: '.pdf'. Kliknij aby podejrzeć listę odnalezionych plików wraz z wykrytymi numerami referencyjnymi.")
        ToolTip1.SetToolTip(Btn_Start, "Prześlij odnalezione pliki na serwer")

        Me.Height = TitlebarHeight + BorderWidth * 2 + GroupBox1.Height + MenuStrip1.Height + StatusStrip1.Height
        'Me.Width = Group_FTP.Left
        Aktualizacja_Statusow(True) 'kolorki, stan ftp itp
    End Sub







    Private Sub Btn_Ustawienia_Click(sender As Object, e As EventArgs)

    End Sub





    Private Sub Form_Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize


    End Sub

    Private Sub ToolStripMenuOtworz_Click(sender As Object, e As EventArgs) Handles ToolStripMenuOtworz.Click


        'Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
        ' Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth

    End Sub

    Private Sub ToolStripMenuPrzeslij_Click(sender As Object, e As EventArgs) Handles ToolStripMenuPrzeslij.Click
        If Not Directory.Exists(Form_Ustawienia.T_Sciezka_PDF.Text) Then
            MsgBox("Wybrana lokalizacja plików PDF nie istnieje. Proszę o wybranie poprawnej lokalizacji, w której znajduja się pliki PDF", vbOKOnly, "Błąd")
            Exit Sub
        Else 'Jeśli folder istnieje - uruchom aplikacje
            Form_Operacje.Show()
            Przetworz_Pliki(True)

        End If
    End Sub

    Private Sub ToolStripMenuZamknij_Click(sender As Object, e As EventArgs) Handles ToolStripMenuZamknij.Click
        Me.Dispose()

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick


    End Sub



    Private Sub Timer_Checker_Tick(sender As Object, e As EventArgs) Handles Timer_Checker.Tick
        Aktualizacja_Statusow(False)

    End Sub



    Private Sub L_LIczba_Plikow_Click(sender As Object, e As EventArgs) Handles L_LIczba_Plikow.Click
        Try

            Aktualizacja_Statusow(True)
            Form_Operacje.Show()
            Form_Operacje.Lista_Operacji.Items.Clear()
            If L_PIC_Folder.BackColor = Color.Lime Then
                Przetworz_Pliki(False)
            End If
            If L_PIC_FTP.BackColor = Color.Lime Then
                Timer_PIC.Enabled = False
            Else
                Timer_PIC.Enabled = True
            End If
        Catch ex As Exception
            MsgBox("Błąd wyświetlenia listy plików. Skontaktuj się z autorem programu.", vbOKOnly, "Błąd")
        End Try

    End Sub

    Private Sub L_PIC_Folder_Click(sender As Object, e As EventArgs) Handles L_PIC_Folder.Click
        Aktualizacja_Statusow(True)
        If L_PIC_Folder.BackColor = Color.Red Then
            Form_Ustawienia.Show()
        End If
    End Sub

    Private Sub L_PIC_FTP_Click(sender As Object, e As EventArgs) Handles L_PIC_FTP.Click
        Aktualizacja_Statusow(True)

        If L_PIC_FTP.BackColor = Color.Red Then
            Form_Ustawienia.Show()
        End If
    End Sub

    Private Sub L_Blad_Folder_Click(sender As Object, e As EventArgs) Handles L_Blad_Folder.Click
        If L_PIC_Folder.BackColor = Color.Red Then
            Form_Ustawienia.Show()
        End If
    End Sub

    Private Sub L_Blad_FTP_Click(sender As Object, e As EventArgs) Handles L_Blad_FTP.Click
        If L_PIC_FTP.BackColor = Color.Red Then
            Form_Ustawienia.Show()
        End If
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub OProgramieToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OProgramieToolStripMenuItem1.Click
        Form_O_Mnie.Show()
    End Sub

    Private Sub UstawieniaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UstawieniaToolStripMenuItem1.Click
        Form_Ustawienia.ShowDialog()

    End Sub

    Private Sub WyjścieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WyjścieToolStripMenuItem.Click
        Me.Dispose()
    End Sub





    Private Sub Timer_PIC_Tick(sender As Object, e As EventArgs) Handles Timer_PIC.Tick
        Iter = Iter + 1
        If Iter Mod 2 = 0 Then

            ToolStripStatus_PIC.ForeColor = Color.Red
            Select Case ToolStripStatus_PIC.Text.Count
                Case 1
                    ToolStripStatus_PIC.Text = "ll"
                Case 2
                    ToolStripStatus_PIC.Text = "lll"
                Case 3
                    ToolStripStatus_PIC.Text = "llll"
                Case 4
                    ToolStripStatus_PIC.Text = "lllll"
                Case 5
                    Aktualizacja_Statusow(True)
                    ToolStripStatus_PIC.Text = "l"
            End Select
        Else
            ToolStripStatus_PIC.ForeColor = StatusStrip1.BackColor
        End If
        ToolStripStatus_PIC.Visible = True
        ToolStripStatus_PIC_Napis.Visible = True
        If L_PIC_FTP.BackColor = Color.Lime Then
            ToolStripStatus_PIC.Visible = False
            ToolStripStatus_PIC_Napis.Visible = False
            Timer_PIC.Enabled = False
        End If

        If Iter > 10000 Then Iter = 0
    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub StatusStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles StatusStrip1.ItemClicked

    End Sub

    Private Sub ToolStripStatus_PIC_Click(sender As Object, e As EventArgs) Handles ToolStripStatus_PIC.Click

    End Sub

    Private Sub LicencjaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicencjaToolStripMenuItem.Click
        Form_Licencja.Show()
    End Sub

End Class
'RLP_RP14_XXXXXXXXXXX_Y_ZZZZZZZZZZZZZZZ.FFF

'Przykład: RLP_RP14_10000839000_1_604953697.pdf
'Elementy nazwy
'RLP_RP14 – stała nazwa
'XXXXXXXXXXX –stała wartość - numer relacji Klienta C(11 znaków – informację o numerze relacji udziela Dział Obsługi Klienta)
'Y – wartość zmienna - określająca numer kolejny dokumentu dla 1 przesyłki (liczba porządkowa załączanych plików) 
'ZZZZZZZZZZZZZZZ – wartość zmienna - numer referencyjny przesyłki lub numer przesyłki TMS (15 znaków)
'FFF – format pliku (pdf lub tif)

