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
Imports System.ComponentModel
Imports System.IO
'https://social.msdn.microsoft.com/Forums/en-US/7945dbd9-5836-4eaa-b8fe-32ad70002e43/copying-a-file-to-a-ftp-server-in-vbnet-2005-help-please?forum=vblanguage
Public Class Form_Main
    'Throw New System.Exception("An exception has occurred.") 'ZASYMULOWANIE BŁEDU Symulacja błedu
    Public Licznik As Long = 0
    'Zmienne do automatyzacji:
    Public Auto_Start_Time As String
    Public Auto_Ilosc_Cykli As Long = 0
    Public Auto_Ilosc_Zapisanych As Long = 0
    Public Auto_Ilosc_Error As Long = 0

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Btn_Start.Click
        Aktualizacja_Statusow(True)
        If IsConnectedToInternet() = False Then
            ToolStripError.Text = "No internet connection. Check again later"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
            Timer_PIC.Enabled = True
            Exit Sub
        Else
            ToolStripError.Text = "ok"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Green
            Aktualizacja_Statusow(True)
        End If
        If L_LIczba_Plikow.Text > 0 Then
            If Directory.Exists(Folder_PDF) And Stan_Folderow_Lokalnych = True And Stan_Polaczenia_FTP = True And L_LIczba_Plikow.Text > 0 Then
                ToolStripError.Text = "ok"
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Green
                Timer_PIC.Enabled = False
                Form_Operacje.Show()
                Me.Hide()
                Form_Operacje.Lista_Operacji.Items.Clear()
                Form_Operacje.Text = "File processing..."
                Try
                    Przetworz_Pliki2(True, True, False, True)
                Catch ex As Exception
                    Try
                        Zapisz_Log_Txt(ex.Message)
                    Catch ex1 As Exception

                    End Try

                    ToolStripError.Text = "Error while file processing. Please contact with the programmer."
                    ToolStripError.ToolTipText = ToolStripError.Text
                    ToolStripError.ForeColor = Color.Red

                End Try

            ElseIf Not Directory.Exists(Folder_PDF) Then
                Timer_PIC.Enabled = True
                ToolStripError.Text = "Selected directory doesn't exist. Please check path to folder with pdf files"
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Red
                Exit Sub
            Else
                ToolStripError.Text = "Selected FTP location or the location of PDF or FTP files was not indicated or was indicated incorrectly. Please check the settings or check again in a few seconds"
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Red
            End If
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
        Inicjacja_INI() 'Na wypadek braku pliki Preferences.ini
        Aktualizacja_Programu_Nowe_INI() 'Aktualizacja pliku INI o nowy jeśli ten istnieje
        WCZYTAJ_USTAWIENIA_INI()
        'Wczytanie ustawień
        'UStawienia TooTipText
        ToolTip1.SetToolTip(L_LIczba_Plikow, "Count of found '.pdf' files. Click to view the list of found files with detected reference numbers.")
        ToolTip1.SetToolTip(LL_Ilosc_plikow, "Count of found '.pdf' files. Click to view the list of found files with detected reference numbers.")
        ToolTip1.SetToolTip(Btn_Start, "Send the found files to the server")

        Me.Height = TitlebarHeight + BorderWidth * 2 + GroupBox1.Height + MenuStrip1.Height + StatusStrip1.Height
        'Me.Width = Group_FTP.Left
        Aktualizacja_Statusow(True) 'kolorki, stan ftp itp
        Sprawdz_Aktualizacje()
        If IsNumeric(CLng(Interval)) And CLng(Interval) > 0 Then
            Timer_Automat.Interval = CLng(Interval) * 1000
        End If

        If Automation = True Then
            Timer_Automat.Enabled = True
            ToolStripAutomation.Image = My.Resources.Green_Button
        End If
        'Włączenie aktualizacji ilosci plikow
        Timer_Checker.Enabled = True
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
        If Not Directory.Exists(Folder_PDF) Then

            ToolStripError.Text = "Indicated directory with pdf files doesn't exist. Please select correct directory"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
            Exit Sub
        Else 'Jeśli folder istnieje - uruchom aplikacje
            ToolStripError.Text = "ok"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Green
            Form_Operacje.Show()
            If Work_On_Copies = True Then
                Przetworz_Pliki2(True, True, True, True)
            Else
                Przetworz_Pliki2(True, True, False, True)
            End If

        End If
    End Sub

    Private Sub ToolStripMenuZamknij_Click(sender As Object, e As EventArgs) Handles ToolStripMenuZamknij.Click
        Me.Dispose()

    End Sub

    Private Sub NotifyIcon1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDoubleClick


    End Sub



    Private Sub Timer_Checker_Tick(sender As Object, e As EventArgs) Handles Timer_Checker.Tick
        Dim i As Integer = 0
        'wyłaczone automatyczne aktualizacje
        'Poniższa część wykonuje sie stale, nieustannie
        Dim Folder As String = Folder_PDF
        If Folder <> "" Then
            Try
                For Each Plik As String In My.Computer.FileSystem.GetFiles(Folder)
                    If UCase(Mid(Plik, Plik.Length - 3, 4)) = UCase(".pdf") Then
                        i = i + 1
                    End If
                Next
            Catch ex As Exception
                Try
                    Zapisz_Log_Txt(ex.Message)
                Catch ex1 As Exception

                End Try

                My.Forms.Form_Main.L_LIczba_Plikow.Text = 0
            End Try
        End If

        My.Forms.Form_Main.L_LIczba_Plikow.Text = i
        'PROBLEM: Brak odswiezania ilosci plików count
    End Sub



    Private Sub L_LIczba_Plikow_Click(sender As Object, e As EventArgs) Handles L_LIczba_Plikow.Click
        Aktualizacja_Statusow(True)

        Try
            ToolStripError.Text = "ok"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Green
            Aktualizacja_Statusow(True)
            Form_Operacje.Show()
            Form_Operacje.Lista_Operacji.Items.Clear()
            If Stan_Folderow_Lokalnych = True Then
                Przetworz_Pliki2(False, False, False, True) 'TEST algorytmu w wersji 2.0
            End If
            If Stan_Folderow_Lokalnych = True Then
                Timer_PIC.Enabled = False
            Else
                Timer_PIC.Enabled = True
            End If
        Catch ex As Exception
            Try
                Zapisz_Log_Txt(ex.Message)
            Catch ex1 As Exception

            End Try

            ToolStripError.Text = "Unable to show list of the files. Please contact with the programmer"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
        End Try

    End Sub


    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub OProgramieToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles OProgramieToolStripMenuItem1.Click
        Form_O_Mnie.Show()
    End Sub

    Private Sub UstawieniaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles UstawieniaToolStripMenuItem1.Click
        Me.Hide()
        Form_Ustawienia.Show()
        'Form_Password.ShowDialog()



        'Timer_Automat.Enabled = False
        ' If InputBox("Enter the password:", "Password") = "qwerty1" Then
        ' Form_Ustawienia.ShowDialog()
        'End If


    End Sub

    Private Sub WyjścieToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles WyjścieToolStripMenuItem.Click
        Me.Dispose()
    End Sub





    Private Sub Timer_PIC_Tick(sender As Object, e As EventArgs) Handles Timer_PIC.Tick
        'Iter = Iter + 1
        'If Iter Mod 2 = 0 Then

        '    ToolStripStatus_PIC.ForeColor = Color.Red
        '    Select Case ToolStripStatus_PIC.Text.Count
        '        Case 1
        '            ToolStripStatus_PIC.Text = "ll"
        '        Case 2
        '            ToolStripStatus_PIC.Text = "lll"
        '        Case 3
        '            ToolStripStatus_PIC.Text = "llll"
        '        Case 4
        '            ToolStripStatus_PIC.Text = "lllll"
        '        Case 5
        '            Aktualizacja_Statusow(True)
        '            ToolStripStatus_PIC.Text = "l"
        '    End Select
        'Else
        '    ToolStripStatus_PIC.ForeColor = StatusStrip1.BackColor
        'End If
        'ToolStripStatus_PIC.Visible = True
        'ToolStripStatus_PIC_Napis.Visible = True
        'If L_PIC_FTP.BackColor = Color.Lime Then
        '    ToolStripStatus_PIC.Visible = False
        '    ToolStripStatus_PIC_Napis.Visible = False
        '    Timer_PIC.Enabled = False
        'End If

        'If Iter > 10000 Then Iter = 0
    End Sub



    Private Sub LicencjaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LicencjaToolStripMenuItem.Click
        Form_Licencja.Show()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Btn_Save.Click
        Try

            Aktualizacja_Statusow(True)

            If Stan_Folderow_Lokalnych = True And L_LIczba_Plikow.Text > 0 Then
                ToolStripError.Text = ""
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Green
                Form_Operacje.Show()
                Form_Operacje.Lista_Operacji.Items.Clear()
                If Work_On_Copies = True Then
                    Przetworz_Pliki2(False, True, True, True)
                Else
                    Przetworz_Pliki2(False, True, False, True)
                End If

            Else
                ToolStripError.Text = "No files inside indicated directory"
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Red
            End If
            If Stan_Polaczenia_FTP = True Then
                Timer_PIC.Enabled = False
            Else
                Timer_PIC.Enabled = True
            End If
        Catch ex As Exception
            Try
                Zapisz_Log_Txt(ex.Message)
            Catch ex1 As Exception

            End Try

            ToolStripError.Text = "Unable to show list of files. Please contact with the programmer"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub LL_Ilosc_plikow_Click(sender As Object, e As EventArgs) Handles LL_Ilosc_plikow.Click


    End Sub

    Private Sub UpdateToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UpdateToolStripMenuItem.Click
        Sprawdz_Aktualizacje()
    End Sub

    Private Sub ToolStripAutomation_ButtonClick(sender As Object, e As EventArgs) Handles ToolStripAutomation.ButtonClick
        If Timer_Automat.Enabled = False And Interval > 0 Then
            Timer_Automat.Enabled = True
            ToolStripAutomation.Image = My.Resources.Green_Button
        Else
            Timer_Automat.Enabled = False
            ToolStripAutomation.Image = My.Resources.Red_Button
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Timer_Automat_Tick(sender As Object, e As EventArgs) Handles Timer_Automat.Tick
        Licznik = Licznik + 1
        Try
            'STATYSTYKI
            If Licznik = 1 Then
                Auto_Start_Time = DateTime.Now
            End If
            Auto_Ilosc_Cykli = Licznik
            Form_Ustawienia.T_Czas_Startu_Automatu.Text = Auto_Start_Time
            Form_Ustawienia.T_Liczba_Cykli.Text = Auto_Ilosc_Cykli
            Form_Ustawienia.T_Liczba_Bledow.Text = Auto_Ilosc_Error 'NICE TO HAVE: Zlicza errory nawet jak raz juz je przetworzył
            Form_Ustawienia.T_Liczba_Zmienionych_Plikow.Text = Auto_Ilosc_Zapisanych

            ' L_Start_Time.Text = Auto_Start_Time
            L_Count_Loops.Text = Auto_Ilosc_Cykli
            L_Count_Files.Text = Auto_Ilosc_Zapisanych
            L_Current_Interval.Text = Timer_Automat.Interval / 1000 & " s"

            ' Auto_Ilosc_Zapisanych=
            ' Auto_Ilosc_Error=
            Aktualizacja_Statusow(True)

            If Stan_Folderow_Lokalnych = True And L_LIczba_Plikow.Text > 0 Then
                ToolStripError.Text = ""
                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Green
                Form_Operacje.Lista_Operacji.Items.Clear() 'wyczyść formę z operacjami. Dałem ostatni parametr true bo na podstawie operacji sprawdza duble
                If Automation = 0 Then '2020-06-03 właczyłem wysylanie na ftp w przypadku automatu
                    If Work_On_Copies = True Then
                        Przetworz_Pliki2(False, True, True, True)
                    Else
                        Przetworz_Pliki2(False, True, False, True)
                    End If
                Else
                    If Work_On_Copies = True Then
                        Przetworz_Pliki2(True, True, True, True)
                    Else
                        Przetworz_Pliki2(True, True, False, True)
                    End If
                End If


            Else
                If Automation = 0 Then
                    ToolStripError.Text = "No files inside indicated directory"
                End If

                ToolStripError.ToolTipText = ToolStripError.Text
                ToolStripError.ForeColor = Color.Red
            End If
            If Stan_Polaczenia_FTP = True Then
                Timer_PIC.Enabled = False
            Else
                Timer_PIC.Enabled = True
            End If
        Catch ex As Exception
            Try
                Zapisz_Log_Txt(ex.Message)
            Catch ex1 As Exception

            End Try


            ToolStripError.Text = "Unable to show list of files. Please contact with the programmer"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
        End Try




    End Sub



    Private Sub ToolStripError_Click(sender As Object, e As EventArgs) Handles ToolStripError.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Form_Main_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

    End Sub

    Private Sub ToolStripHide_Click(sender As Object, e As EventArgs) Handles ToolStripHide.Click
        If MsgBox("This option will minimize program to system tray. You can turn off program only from task manager. Continue?", vbYesNo, "Hide program") = vbYes Then
            'https://www.dreamincode.net/forums/topic/53448-minimize-to-system-tray/
            Me.WindowState = FormWindowState.Minimized
            Me.Visible = False
        End If

    End Sub

    Private Sub ToolTip1_Popup(sender As Object, e As PopupEventArgs) Handles ToolTip1.Popup

    End Sub

    Private Sub ToolStripStatusLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripDisableRefreshing.Click
        If ToolStripDisableRefreshing.BorderStyle = Border3DStyle.Raised Then
            ToolStripDisableRefreshing.BorderStyle = Border3DStyle.Sunken
            ToolStripDisableRefreshing.Text = "Check Off"
            ToolStripDisableRefreshing.BackColor = Color.Red

        Else
            ToolStripDisableRefreshing.BorderStyle = Border3DStyle.Raised
            ToolStripDisableRefreshing.Text = "Check On"
            ToolStripDisableRefreshing.BackColor = ToolStripHide.BackColor
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles Pic_Lista.Click
        Aktualizacja_Statusow(True)

        Try
            ToolStripError.Text = "ok"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Green
            Aktualizacja_Statusow(True)
            Form_Operacje.Show()
            Form_Operacje.Lista_Operacji.Items.Clear()
            If Stan_Folderow_Lokalnych = True Then
                Przetworz_Pliki2(False, False, False, True) 'TEST algorytmu w wersji 2.0
            End If
            If Stan_Folderow_Lokalnych = True Then
                Timer_PIC.Enabled = False
            Else
                Timer_PIC.Enabled = True
            End If
        Catch ex As Exception
            Try
                Zapisz_Log_Txt(ex.Message)
            Catch ex1 As Exception

            End Try

            ToolStripError.Text = "Unable to show list of the files. Please contact with the programmer"
            ToolStripError.ToolTipText = ToolStripError.Text
            ToolStripError.ForeColor = Color.Red
        End Try
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class

