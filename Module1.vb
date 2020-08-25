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
'znajduja się na stronie: http ://itextpdf.com/terms-of-use/
'Autor: Łukasz Morawski, e-mail: lukasz.r.morawski@gmail.com
'Kod źródłowy dostępny pod adresem: https://github.com/excelsolutions/PDF-to-FTP
'Lista zmian:
'2020-05-25 Dodano obsługę numeracji wz o tym samym numerze. 

Imports iTextSharp.text.pdf
Imports iTextSharp.text


Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
Imports System.Threading
'https://www.codeproject.com/info/cpol10.aspx
'http://www.vbforums.com/showthread.php?475759-Extract-Text-from-Pdfs-using-iTextSharp-(02-03-2005)&highlight=pdf
' Licencja: https://itextpdf.com/AGPL
Module Module1
    Public Licznik As Integer = 0
    Public Iter As Long = 0
    Public Zapisz_Log As Boolean = True
    Public Stan_FTP As Boolean = False
    Public Strony_Pliku() As Integer 'przechowuje numery stron, które spełniaja wymagania
    Public Tresc_Strony() As String 'przechowuje tekst stron, które spełniaja wymagania
    Public Dystans As Integer = 0 'Zmienna do odroczenia w czasie wykonywania sprawdzenia ftp
    Public Stan_Internetu As String

    Public Polaczenia_FTP As String
    Public Folderow_Lokalnych As String
    Public Folderow_Z_Kopiami As String
    Public Stan_Polaczenia_FTP As Boolean
    Public Stan_Folderow_Lokalnych As Boolean
    Public Stan_Folderow_Z_Kopiami As Boolean

    Public Function ParsePdfText2(PdfFileName As String, Calosc As Boolean) As String
        'https://stackoverflow.com/questions/2550796/reading-pdf-content-with-itextsharp-dll-in-vb-net-or-c-sharp
        Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)
        Dim sOut = ""
        Dim Licznik As Integer = 0
        ReDim Strony_Pliku(0) 'zerowanie zmiennej
        ReDim Tresc_Strony(0) 'zerowanie zmiennej
        For i = 1 To oReader.NumberOfPages
            Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy
            If Calosc = False Then
                If Whole_File = "0" Then 'bierz poszczególne strony
                    If Half_or_Specific = 0 Then 'bierz połowę stron
                        If oReader.NumberOfPages > 1 Then 'dziel jeśli stron jest więcej niz 1!
                            If First_Last_Pages = 0 Then 'bierz 1 połowe pliku. 
                                If i <= Math.Round(oReader.NumberOfPages / 2, 0) Then
                                    ReDim Preserve Tresc_Strony(Licznik)
                                    Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                                    sOut &= Tresc_Strony(Licznik)
                                    ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                                    Strony_Pliku(Licznik) = i
                                    Licznik = Licznik + 1
                                    'Debug.Print(PdfFileName & " 1 Połowa") 'TEST DO SKASOWANIA
                                End If

                            ElseIf First_Last_Pages = 1 Then 'bierz drugą połowe pliku
                                If i > Math.Round(oReader.NumberOfPages / 2, 0) Then
                                    ReDim Preserve Tresc_Strony(Licznik)
                                    Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                                    sOut &= Tresc_Strony(Licznik)
                                    ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                                    Strony_Pliku(Licznik) = i
                                    Licznik = Licznik + 1
                                    'Debug.Print(PdfFileName & " 2 Połowa") 'TEST DO SKASOWANIA
                                End If
                            End If
                        Else 'jesli jest 1 strona- bierz cały plik
                            ReDim Preserve Tresc_Strony(Licznik)
                            Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                            sOut &= Tresc_Strony(Licznik)
                            ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                            Strony_Pliku(Licznik) = i
                            Licznik = Licznik + 1
                            'Debug.Print(PdfFileName & " Całośc z wyboru") 'TEST DO SKASOWANIA
                        End If

                    Else 'bierz poszczególne strony
                        If Contain_Text <> "" Then
                            If Contain_Word = 0 Then 'bierz strony, które nie zawieraja danego tekstu
                                If Not iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its).Contains(Contain_Text) Then
                                    ReDim Preserve Tresc_Strony(Licznik)
                                    Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                                    sOut &= Tresc_Strony(Licznik)
                                    ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                                    Strony_Pliku(Licznik) = i
                                    Licznik = Licznik + 1
                                    ' Debug.Print(PdfFileName & " Contain") 'TEST DO SKASOWANIA
                                End If

                            ElseIf Contain_Word = 1 Then 'bierz strony, które zawierają dany text
                                If iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its).Contains(Contain_Text) Then
                                    ReDim Preserve Tresc_Strony(Licznik)
                                    Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                                    sOut &= Tresc_Strony(Licznik)
                                    ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                                    Strony_Pliku(Licznik) = i
                                    Licznik = Licznik + 1
                                    'Debug.Print(PdfFileName & " Not Contain")
                                End If
                            End If
                        End If


                    End If

                Else 'bierz cały plik
                    ReDim Preserve Tresc_Strony(Licznik)
                    Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                    sOut &= Tresc_Strony(Licznik)
                    ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                    Strony_Pliku(Licznik) = i
                    Licznik = Licznik + 1
                    'Debug.Print(PdfFileName & " Cały plik") 'TEST DO SKASOWANIA
                End If
            Else
                ReDim Preserve Tresc_Strony(Licznik)
                Tresc_Strony(Licznik) = iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)
                sOut &= Tresc_Strony(Licznik)
                ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA
                Strony_Pliku(Licznik) = i
                Licznik = Licznik + 1 'TEST DO SKASOWANIA
                'Debug.Print(PdfFileName & " Cały Cały plik") 'TEST DO SKASOWANIA
            End If


        Next
        oReader.Close()
        Return sOut

    End Function



    Public Sub Aktualizacja_Statusow(Sprawdzanie_Stanu As Boolean)
        Dim i As Int16 = 0


        If My.Forms.Form_Main.ToolStripDisableRefreshing.Text.Contains("On") Then
            Sprawdzanie_Stanu = True
            Dystans = Dystans + 1
            If Dystans >= 5 Then
                Dim thread As New Thread(AddressOf Ftp_Istnieje)
                thread.Start() 'WYSTARTOWANIE OSOBNEGO WĄTKU !!!! ;-)
                Dystans = 0
            End If
        Else
            Sprawdzanie_Stanu = False
        End If

        If Sprawdzanie_Stanu = True Then ' jeśli sprawdZanie ma byc wykonanne
            Try
                If IsConnectedToInternet() = False Then
                    Stan_Internetu = "No internet connection"
                    My.Forms.Form_Main.Timer_PIC.Enabled = True
                    Exit Try
                End If
                If Check_FTP = True Then
                    My.Forms.Form_Main.Btn_Start.Visible = True
                    'If Stan_FTP And Ftp_Exist(Folder_FTP) Then
                    '    Polaczenia_FTP = "Connection with FTP establish: "
                    '    Stan_Polaczenia_FTP = True
                    '    My.Forms.Form_Main.Timer_PIC.Enabled = False
                    'Else
                    '    Polaczenia_FTP = "Error connection with indicated path: " & Folder_FTP & ". Wskazany adres jest niepoprawny. Kliknij aby przejść do ustawień."
                    '    Stan_Polaczenia_FTP = False
                    '    My.Forms.Form_Main.Timer_PIC.Enabled = True
                    'End If

                Else

                End If

            Catch ex As Exception
                Try
                    Zapisz_Log_Txt(ex.Message)
                Catch ex1 As Exception

                End Try

                If Check_FTP = True Then
                    Polaczenia_FTP = "Error connection with FTP: " & Folder_FTP
                    Stan_Polaczenia_FTP = False
                    My.Forms.Form_Main.Timer_PIC.Enabled = True
                End If
            End Try
            'SOURCE FOLDER - sprawdzenie
            Try
                If Directory.Exists(Folder_PDF) Then
                    Folderow_Lokalnych = "The indicated path to the PDF files is correct."
                    Stan_Folderow_Lokalnych = True
                Else
                    Folderow_Lokalnych = "The indicated path to the PDF files is not correct."
                    Stan_Folderow_Lokalnych = False
                End If
            Catch ex As Exception
                Try
                    Zapisz_Log_Txt(ex.Message)
                Catch ex1 As Exception

                End Try
                Folderow_Lokalnych = "The indicated path to the PDF files is not correct or another unidentified error occurred."
                Stan_Folderow_Lokalnych = False
            End Try

            'DESTINATION FOLDER - sprawdzenie
            If Work_On_Copies = True Then
                Try
                    If Directory.Exists(Folder_Dest) Then
                        Folderow_Z_Kopiami = "The indicated path to the destination folder is correct."
                        Stan_Folderow_Z_Kopiami = True
                    Else
                        Folderow_Z_Kopiami = "The indicated path to the destination folder is not correct."
                        Stan_Folderow_Z_Kopiami = False
                    End If
                Catch ex As Exception
                    Try
                        Zapisz_Log_Txt(ex.Message)
                    Catch ex1 As Exception
                    End Try
                    Folderow_Z_Kopiami = "The indicated path to the destination folder is not correct or another unidentified error occurred."
                    Stan_Folderow_Z_Kopiami = False
                End Try
            Else

            End If

        End If


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
        'USTAwienie ToolTip Text



    End Sub

    Public Function Ftp_Exist(Sciezka_FTP As String) As Boolean
        Ftp_Exist = False
        'WYŁĄCZENIE SPRAWDZANIA FTP !!!!!!!!
        ' If 0 = 1 Then

        If Sciezka_FTP <> "" Then
            Dim request =
           DirectCast(WebRequest.Create(Sciezka_FTP), FtpWebRequest)

            request.Credentials =
                New NetworkCredential(Login_FTP, Haslo_FTP)

            request.Method = WebRequestMethods.Ftp.ListDirectory

            Try
                Using response As FtpWebResponse =
                DirectCast(request.GetResponse(), FtpWebResponse)
                    ' Folder exists here
                    Ftp_Exist = True
                End Using

            Catch ex As WebException

                Dim response As FtpWebResponse =
                DirectCast(ex.Response, FtpWebResponse)
                'Does not exist
                If response.StatusCode =
                FtpStatusCode.ActionNotTakenFileUnavailable Then
                    Ftp_Exist = False
                End If
            End Try
        Else
            Ftp_Exist = False
        End If
        ' End If
    End Function
    Public Sub Ftp_Istnieje()
        'TODO: WYŁĄCZYĆ CZUJKI na main form bo spowalniają. Zamiast tego dać narzedzie do sprawdzania poprawności
        'WYŁĄCZENIE SPRAWDZANIA FTP !!!!!!!!
        If 0 = 1 Then
            If Folder_FTP <> "" Then
                Dim request =
               DirectCast(WebRequest.Create(Folder_FTP), FtpWebRequest)

                request.Credentials =
                    New NetworkCredential(Login_FTP, Haslo_FTP)

                request.Method = WebRequestMethods.Ftp.ListDirectory

                Try
                    Using response As FtpWebResponse =
                    DirectCast(request.GetResponse(), FtpWebResponse)
                        ' Folder exists here

                        Stan_FTP = True
                    End Using

                Catch ex As WebException

                    Dim response As FtpWebResponse =
                    DirectCast(ex.Response, FtpWebResponse)
                    'Does not exist
                    If response.StatusCode =
                    FtpStatusCode.ActionNotTakenFileUnavailable Then

                        Stan_FTP = False
                    End If
                End Try
            Else
                Stan_FTP = False
            End If
        End If
    End Sub

    Public Sub PDF_FTP()

    End Sub



    'Nowa Wersja 2.0 2018-11-14- zaimplementowana. 
    '1. Moduł dotyczący FTp niemodyfikowany. 
    '2. Ujednolicono adresy Nowego pliku- dodano na stałe folder_pdf i dolder_Dest do nazwy pliku
    '3. Poprawiono algorytm  dla plikow tylko do zmiany nazwy- wyciagnieto przed if inna_lokalizacja
    Public Sub Przetworz_Pliki2(Wysyłka_Na_FTP As Boolean, Zmiana_Nazwy As Boolean, Inna_Lokalizacja As Boolean, Logowanie As Boolean)
        'Wysyłka_Na_FTP- czy ma wysyłać na FTP, Zmiana_Nazwy- jesli false to zapewne przetwórz dla samego zliczenia
        Dim Wiersz(5) As String

        Dim Referencja As String = ""

        Dim itm As ListViewItem
        Dim i As Integer = 0
        Dim Ilosc_OK As Int16 = 0
        Dim Ilosc_NOK As Int16 = 0
        Dim Ilosc_OK1 As Int16 = 0
        Dim Ilosc_NOK1 As Int16 = 0
        Dim Nowa_Nazwa As String = ""
        Dim Tresc_Pliku As String = ""
        Dim Blokujacy As String = ""
        Dim Start As Long = 0
        Dim Dlugosc As Long = 0
        Dim Zabezpieczenie As Integer = 0
        Dim Znaleziono_Nr As Boolean = False
        Dim Licznik As Integer = 0
        Dim Numer As Integer = 1
        'TODO: A co z plikami i DUBLAMI WZ???? Jeśli mamy dubel WZ to pliki beda mialy taka sama nazwe!
        'Jeżeli w ustawieniach wpiszemy jako startowy ciag- 0 to wywala że nie rozpoznano struktury pliku- NAPRAWIONE
        For Each Plik As String In My.Computer.FileSystem.GetFiles(Folder_PDF) 'Sprawdź każdy plik w folderze
            If UCase(Mid(Plik, Plik.Length - 3, 4)) = UCase(".pdf") Then 'jesli rozszerzenie pliku to "pdf" to bierz plik do obrobki
                Tresc_Pliku = ParsePdfText2(Plik, True)
                Znaleziono_Nr = False
                i = i + 1
                Numer = 1
                Wiersz(0) = i
                Wiersz(1) = System.IO.Path.GetFileName(Plik) 'lub bez rozszerzenia: System.IO.Path.GetFileNameWithoutExtension
                Referencja = Wytnij_String(Tresc_Pliku) 'Wycina fragment pliku wg. ustawien Mid(Tresc_Pliku, 5, 9) 'TO PODMIENIC!
                If Referencja <> "" Then

                    Wiersz(3) = Prefix & "_" & Numer & "_" & Referencja & Suffix & ".pdf" 'Nazwa pliku
                    Do While Czy_WZ_Jest_Dublem(3, Wiersz(3)) = True
                        '2020-05-25 Dodano Numer- czyli numeracje kolejnych plików w przypadku, gdy plików z ttym samym nr przesyłki jest wiecej
                        Numer = Numer + 1
                        Wiersz(3) = Prefix & "_" & Numer & "_" & Referencja & Suffix & ".pdf" 'Nazwa pliku
                    Loop
                    Znaleziono_Nr = True
                Else
                    Referencja = System.IO.Path.GetFileName(Plik)
                    Wiersz(3) = Referencja 'Nazwa pliku
                    Znaleziono_Nr = False
                End If
                Wiersz(2) = Referencja

                Tresc_Pliku = ParsePdfText2(Plik, False) 'celowo wywołuje funkcję ponownie aby tym razem zaczytała plik wg ustawień a nie całość
                If Allow_Duplicates = 1 Or Czy_WZ_Jest_Dublem(2, Wiersz(2)) = False Then 'jeśli pozwalamy na duplikat to idź dalej nawet jeśli funkcja CZY znajdzie duplikat

#Region "Wysyłka na FTP"
                    If Wysyłka_Na_FTP = True And Stan_FTP = True Then 'jesli właczylismy wysłanie na FTP  to procesuj dalej
                        ' If Not File.Exists(Sciezka_FTP & Wiersz(3)) Then
                        Dim remoteLOC As String = Folder_FTP & Wiersz(3) 'nazwa ftp plus nazwa pliku
                        Try
                            'FilenameIsOK - sprawdza czy nazwa pliku nie zawiera specjalnych znakow, ktore nie moga byc uzwane

                            Dim info As New FileInfo(Plik)
                            'Sprawdź czy plik nie jest zablokowany!
                            If Sprawdz_PDF(Plik, Znaleziono_Nr) = True And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ) i ma szukany numer
                                If Whole_File = 0 Then 'jesli mamy nie procesowac całego pdf tylko strony

                                    If IsFileOpen(info) Then 'jak plik jest zablokowany to zrób jego kopie
                                        If Not File.Exists(Folder_PDF & "Temporary_File" & i & ".pdf") Then 'wynikiem tego jest wysłanie na FTp i skasowanie pliku
                                            'My.Computer.FileSystem.CopyFile(Plik, Folder_PDF & "Temporary_File" & i & ".pdf")
                                            Extract_Specific_Pages(Plik, Folder_PDF & "Temporary_File" & i & ".pdf", Strony_Pliku) 'Nadpisz plik
                                            My.Computer.Network.UploadFile(Folder_Dest & "Temporary_File" & i, remoteLOC, Login_FTP, Haslo_FTP, True, 500)
                                            My.Computer.FileSystem.DeleteFile(Folder_PDF & "Temporary_File" & i & ".pdf")
                                            Wiersz(4) = "File is locked"
                                            Wiersz(5) = "OK"
                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                        Else
                                            Wiersz(5) = "NOK"
                                            Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                                            Wiersz(3) = "Unable to save copy of pdf file. File not send to FTP."
                                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                        End If
                                    Else 'Plik niezablokowany
                                        'PROBLEM: W PRZYPADKU pliku z 1 stroną- nie dzielić
                                        'PROBLEM: W PRZYPADKU pliku bez tekstu z parzystą liczbą stron-dzielenie na pół działać ma, ale dzielenie po słowie nie
                                        'PROBLEM: W PRZYPADKU, gdy program nie znajdzie słowa kluczowego w ogóle w pliku- nie przetwarzać
                                        Extract_Specific_Pages(Plik, Folder_PDF & "Temporary_File" & i & ".pdf", Strony_Pliku) 'Stwórz nowy plik z odpowiednimi stronami
                                        My.Computer.Network.UploadFile(Folder_PDF & "Temporary_File" & i & ".pdf", remoteLOC, Login_FTP, Haslo_FTP, True, 500)
                                        My.Computer.FileSystem.DeleteFile(Plik)
                                        My.Computer.FileSystem.DeleteFile(Folder_PDF & "Temporary_File" & i & ".pdf")
                                        Wiersz(4) = "OK"
                                        Wiersz(5) = "OK"
                                        Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                    End If
                                Else 'jeśli mamy wysłac cały plik- to wysyłamy od razu

                                    'Wiersz(3) = Prefix & Referencja & Suffix & ".pdf" 'Nazwa pliku- zakomentowałem bo ten wiersz(3) jest już uzupełniony
                                    My.Computer.Network.UploadFile(Plik, remoteLOC, Login_FTP, Haslo_FTP, True, 500)
                                    If Not IsFileOpen(info) Then
                                            My.Computer.FileSystem.DeleteFile(Plik)
                                        End If

                                        Wiersz(4) = "OK"
                                        Wiersz(5) = "OK"
                                        Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                    End If



                                    Else
                                Wiersz(5) = "NOK"
                                Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                                Wiersz(3) = "Incorrect delivery note number inside PDF file"
                                My.Computer.FileSystem.WriteAllText(Folder_PDF & Nowa_Nazwa & ".txt", "Plik PDF nie został wysłany. Struktura pliku odbiega od ustawionego wzorca. Problem z odczytem numeru referencyjnego. " & vbCrLf &
                        "Odczytana referencja: " & Referencja & vbCrLf &
                        "Nazwa pliku: " & Wiersz(3) & vbCrLf &
                        "Treść pliku PDF: " & vbCrLf &
                        Tresc_Pliku, False)
                                Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                            End If


                        Catch ex As Exception
                            Try 'kolejne zabezpieczenie
                                Zapisz_Log_Txt(ex.Message) 'zapisanie treści błedu  w pliku txt o nazwie Error_Log.txt
                                My.Computer.FileSystem.WriteAllText(Folder_PDF & Wiersz(1) & ".txt", "Plik PDF nie został wysłany. " & vbCrLf &
                            "Odczytana referencja: " & Referencja & vbCrLf &
                            "Nazwa pliku: " & Wiersz(3) & vbCrLf &
                            "Treść pliku PDF: " & vbCrLf &
                            ParsePdfText2(Plik, False), False) 'zapisanie zamiast pliku pdf pliku txt z opisem błedu
                                Wiersz(5) = "NOK"
                                Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                            Catch ex1 As Exception
                                Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                            End Try
                        End Try
#End Region
#Region "Zapis plików"
                    Else 'Jeśli wybraliśmy BEZ WYSYŁANIA plików na serwer - program ma zmienić wyłacznie nazwy tych plików
                        Try
                            Dim info As New FileInfo(Plik)
                            'Debug.Print(info.Name)
                            If IsFileOpen(info) Then 'jak plik jest zablokowany - to nie procesuj dalej
                                Dim LockedFileProcesses = WhoIsLocking(Plik)
                                If LockedFileProcesses.Count > 0 Then
                                    For Each Item In LockedFileProcesses
                                        Blokujacy = Blokujacy & "; " & Item.ProcessName.ToString '& " .. " & Item.Id.ToString & vbCrLf)
                                    Next
                                End If
                                Wiersz(3) = "File is locked by: " & Blokujacy
                                Wiersz(4) = "NOK"
                                Wiersz(5) = "NOK"
                                Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                Nowa_Nazwa = Plik
                                Exit Try 'wyjdź jak zablokowany z tej pętli i przejdź do nastepnego pliku

                            End If
                            If System.IO.Path.GetFileName(Plik) <> Wiersz(3) Then 'jeśli nazwa już jest ok, nie procesuj dalej
                                'XXXXXXXXXXXXXXXXX TU DAC ZABEZPIECZNEI SUME KONTROLNA
                                If Sprawdz_PDF(Plik, Znaleziono_Nr) = True And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ) i ma szukany numer
                                    'NOWY ALGORYTM
                                    If Strony_Pliku.Length = 1 And Strony_Pliku(0) = 0 Then 'to oznacza ściśle,ze program nie znalazł żadnych pasujących stron
                                        'to oznacza ściśle,ze program nie znalazł żadnych pasujących stron
                                        Wiersz(3) = "No matching pages found."
                                        Wiersz(4) = "NOK"
                                        Wiersz(5) = "NOK"
                                        Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                        Nowa_Nazwa = Plik
                                        Exit Try 'jak plik nie zawiera żadnych pasującdych do wzorca stron- zakończ przetwarzanie
                                    End If
                                    If Zmiana_Nazwy = True Then 'gdy chcemy zmienić nazwy plików
                                        If Inna_Lokalizacja = False Then
                                            If Not File.Exists(Folder_PDF & Wiersz(3)) Then 'gdy plik nie istnieje jeszcze
                                                If Whole_File = 0 Then 'jesli mamy nie procesowac całego pdf tylko strony
                                                    'Debug.Print(Strony_Pliku(0))

                                                    If Group_Pages = 1 Then
                                                        If FilenameIsOK(Folder_PDF) Then
                                                            Extract_Specific_Pages(Plik, Folder_PDF & Wiersz(3), Strony_Pliku) 'Zapisz nowy plik z odpowiednimi stronami
                                                        End If
                                                        'dla stron, które nie mają być zgrupowane
                                                    ElseIf Group_Pages = 0 Then
                                                        Dim Strona(0) As Integer 'zbiór numerów tych samych stron, zerowany jak strona jest inna
                                                        Dim Stron_Ilosc As Integer = 0 'licznik numerów tych samych stron, zerowany jak strona jest inna
                                                        Licznik = 0
                                                        For Each pageNumber As Integer In Strony_Pliku

                                                            'TODO: Dodać tu opcję zapisu każdej strony osobno
                                                            'TODO: Przed ta funkcją dodać sprawdzenie nazw WSZYSTKICH plików
                                                            'TODO: UWAGA!!! Trzeba wiersz(3) wczytac- wydobyc tu numer wz z każdej strony OSOBNO!!!
                                                            'NIE DZIAŁA

                                                            Referencja = Wytnij_String(Tresc_Strony(Licznik))
                                                            If Licznik > 1 Then 'jesli stron bedzie wiecej niz 1
                                                                If Referencja = Wytnij_String(Tresc_Strony(Licznik - 1)) Then 'gdy referencja bedzie taka sama to zlacz strony
                                                                    Stron_Ilosc = Stron_Ilosc + 1
                                                                    ReDim Preserve Strona(Stron_Ilosc)
                                                                    Strona(Stron_Ilosc) = pageNumber
                                                                    If FilenameIsOK(Referencja) Then
                                                                        Extract_Specific_Pages(Plik, Folder_PDF & Referencja & ".pdf", Strona) 'Zapisz nowy plik ze stronami, które są już sparowane
                                                                    End If

                                                                Else
                                                                    ReDim Strona(0) 'zerowanie zmiennej
                                                                    Stron_Ilosc = 0 'mamy wtedy stronę różną od poprzedniej, wiec zakladamy że jest jedna
                                                                    Strona(Stron_Ilosc) = pageNumber
                                                                    If FilenameIsOK(Referencja) Then
                                                                        Extract_Specific_Pages(Plik, Folder_PDF & Referencja & ".pdf", Strona) 'Zapisz nowy plik jedną stroną
                                                                    End If
                                                                    Extract_Specific_Pages(Plik, Folder_PDF & Referencja & ".pdf", Strona) 'Zapisz nowy plik jedną stroną
                                                                End If
                                                            Else 'jak będzie tylko 1 strona to od razu ja zapisz
                                                                ReDim Strona(0) 'zerowanie zmiennej
                                                                Stron_Ilosc = 0 'zerowanie
                                                                Strona(Stron_Ilosc) = pageNumber
                                                                If FilenameIsOK(Referencja) Then
                                                                    Extract_Specific_Pages(Plik, Folder_PDF & Referencja & ".pdf", Strona) 'Zapisz nowy plik jedną stroną
                                                                End If

                                                            End If
                                                            Licznik = Licznik + 1 'licznik stron w-z
                                                        Next
                                                    Else

                                                        Extract_Specific_Pages(Plik, Folder_PDF & Wiersz(3), Strony_Pliku) 'Zapisz nowy plik z odpowiednimi stronami


                                                    End If

                                                    My.Computer.FileSystem.DeleteFile(Plik) 'skasowanie starego pliku. W teorii nie jest zablokowanybo inaczej wcześnie program by to wykrył!
                                                    'My.Computer.FileSystem.RenameFile(Plik, Wiersz(3))
                                                    Wiersz(4) = "renamed"
                                                    Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                Else
                                                    My.Computer.FileSystem.RenameFile(Plik, Wiersz(3))
                                                    Wiersz(4) = "renamed"
                                                    Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                End If

                                            Else 'gdy plik już istnieje. Ten plik co istnieje może juz byc zablokowany- tego program wczesniej nie sprawdzał. 
                                                If Whole_File = 0 Then 'jesli mamy nie procesowac całego pdf tylko strony
                                                    'jak plik istnieje- nie ruszamy
                                                    'My.Computer.FileSystem.RenameFile(Plik, "_copy_" & Wiersz(3))
                                                    'Extract_Specific_Pages(Folder_PDF & "_copy_" & Wiersz(3), Folder_PDF & Wiersz(3), Strony_Pliku) 'Stwórz nowy plik z odpowiednimi stronami
                                                    'My.Computer.FileSystem.DeleteFile(Folder_PDF & "_copy_" & Wiersz(3)) 'Skasuj plik tymczasowy
                                                    Wiersz(4) = "OK"
                                                    Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                Else ' jesli bierzemy plik w całości to nic już dalej nie robimy
                                                    Wiersz(4) = "OK"
                                                    Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                End If
                                            End If
                                        Else ' jesli jednak Inna_lokalizacja=true
                                            If Whole_File = 0 Then 'jesli mamy nie procesowac całego pdf tylko strony
                                                If Not File.Exists(Folder_Dest & Wiersz(3)) Then 'gdy plik nie istnieje jeszcze w nowej lokalizacji
                                                    If Group_Pages = 1 Then

                                                        Extract_Specific_Pages(Plik, Folder_Dest & Wiersz(3), Strony_Pliku) 'Zapisz nowy plik z odpowiednimi stronami


                                                    ElseIf Group_Pages = 0 Then
                                                        Dim Strona(0) As Integer 'zbiór numerów tych samych stron, zerowany jak strona jest inna
                                                        Dim Stron_Ilosc As Integer = 0 'licznik numerów tych samych stron, zerowany jak strona jest inna
                                                        Licznik = 0
                                                        For Each pageNumber As Integer In Strony_Pliku

                                                            'TODO: Dodać tu opcję zapisu każdej strony osobno
                                                            'TODO: Przed ta funkcją dodać sprawdzenie nazw WSZYSTKICH plików
                                                            'TODO: UWAGA!!! Trzeba wiersz(3) wczytac- wydobyc tu numer wz z każdej strony OSOBNO!!!
                                                            'NIE DZIAŁA

                                                            Referencja = Wytnij_String(Tresc_Strony(Licznik))
                                                            If Licznik >= 1 Then 'jesli stron bedzie wiecej niz 1
                                                                If Referencja = Wytnij_String(Tresc_Strony(Licznik - 1)) Then 'gdy referencja bedzie taka sama to zlacz strony
                                                                    Stron_Ilosc = Stron_Ilosc + 1
                                                                    ReDim Preserve Strona(Stron_Ilosc)
                                                                    Strona(Stron_Ilosc) = pageNumber
                                                                    If FilenameIsOK(Referencja) Then
                                                                        Extract_Specific_Pages(Plik, Folder_Dest & Referencja & ".pdf", Strona) 'Zapisz nowy plik ze stronami, które są już sparowane
                                                                    End If

                                                                Else
                                                                    ReDim Strona(0) 'zerowanie zmiennej
                                                                    Stron_Ilosc = 0 'mamy wtedy stronę różną od poprzedniej, wiec zakladamy że jest jedna
                                                                    Strona(Stron_Ilosc) = pageNumber
                                                                    If FilenameIsOK(Referencja) Then
                                                                        Extract_Specific_Pages(Plik, Folder_Dest & Referencja & ".pdf", Strona) 'Zapisz nowy plik jedną stroną
                                                                    End If

                                                                End If
                                                            Else 'jak będzie tylko 1 strona to od razu ja zapisz
                                                                ReDim Strona(0) 'zerowanie zmiennej
                                                                Stron_Ilosc = 0 'zerowanie
                                                                Strona(Stron_Ilosc) = pageNumber
                                                                If FilenameIsOK(Referencja) Then
                                                                    Extract_Specific_Pages(Plik, Folder_Dest & Referencja & ".pdf", Strona) 'Zapisz nowy plik jedną stroną
                                                                End If

                                                            End If
                                                            Licznik = Licznik + 1 'licznik stron w-z
                                                        Next
                                                    Else

                                                        Extract_Specific_Pages(Plik, Folder_Dest & Wiersz(3), Strony_Pliku) 'Zapisz nowy plik z odpowiednimi stronami


                                                    End If
                                                    Wiersz(4) = "moved & renamed pages"
                                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                Else 'gdy plik już w danej lokalizacji istnieje
                                                    'jak plik istnieje- nie ruszamy
                                                    'Extract_Specific_Pages(Folder_Dest & Wiersz(3), Folder_Dest & Wiersz(3), Strony_Pliku) 'Nadpisz plik z odpowiednimi stronami
                                                    'My.Computer.FileSystem.DeleteFile(Plik) 'wykasuj ze starej (jakby nie iastniał w nowje to bysmy go i tak przenieśli)
                                                    Wiersz(4) = "FILE EXIST"
                                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                End If
                                            Else
                                                If Not File.Exists(Folder_Dest & Wiersz(3)) Then 'gdy plik nie istnieje jeszcze w nowej lokalizacji
                                                    My.Computer.FileSystem.MoveFile(Plik, Folder_Dest & Wiersz(3))
                                                    Wiersz(4) = "moved & renamed"
                                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                Else 'gdy plik już w danej lokalizacji istnieje
                                                    My.Computer.FileSystem.DeleteFile(Plik) 'wykasuj ze starej (jakby nie iastniał w nowje to bysmy go i tak przenieśli)
                                                    Wiersz(4) = "FILE EXIST"
                                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                                End If
                                                Wiersz(5) = "NOK" 'tu zawsze w wierszu 5 będzie NOK bo nie wysyłany na FTP
                                            End If

                                        End If
#End Region
#Region "Podgląd plików"


                                    Else 'do podglądu
                                        If Inna_Lokalizacja = False Then
                                            If Not File.Exists(Folder_PDF & Wiersz(3)) Then 'gdy plik nie istnieje jeszcze
                                                Nowa_Nazwa = Plik
                                                Wiersz(4) = "NOK"
                                            Else
                                                Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                                Wiersz(4) = "OK"
                                            End If

                                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                        Else
                                            If Not File.Exists(Folder_Dest & Wiersz(3)) Then 'gdy plik nie istnieje jeszcze w nowej lokalizacji
                                                Nowa_Nazwa = Plik
                                                Wiersz(4) = "NOK"
                                            Else
                                                Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                                Wiersz(4) = "OK"
                                            End If
                                        End If
                                    End If

                                    'KONIEC NOWY ALGORYTM
                                    '#############################################
                                Else

                                    Wiersz(3) = "Incorrect delivery note number inside PDF file"
                                    Wiersz(4) = "NOK"
                                    Wiersz(5) = "NOK"
                                    Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                End If

                                Wiersz(5) = "NOK"
                            Else 'Plik ma już poprawna nazwę
                                If Sprawdz_PDF(Plik, Znaleziono_Nr) = True And FilenameIsOK(Wiersz(3)) Then '
                                    If Inna_Lokalizacja = False Then 'jeśli plik już istnieje i ma popr. nazwe i nie przenosimy go nigdzie- to OK. Koniec procesowania 
                                        'My.Computer.FileSystem.RenameFile(Plik, "_copy_" & Wiersz(3))
                                        'Extract_Specific_Pages(Folder_PDF & "_copy_" & Wiersz(3), Folder_PDF & Wiersz(3), Strony_Pliku) 'Stwórz nowy plik z odpowiednimi stronami
                                        'My.Computer.FileSystem.DeleteFile(Folder_PDF & "_copy_" & Wiersz(3)) 'Skasuj plik tymczasowy
                                        Nowa_Nazwa = Folder_PDF & Wiersz(3)
                                        Wiersz(4) = "OK"
                                        Wiersz(5) = "NOK"
                                        Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                    Else 'jeśli plik istnieje, ma popr. nazwe to przenies go do nowej lokalizacji
                                        If File.Exists(Folder_Dest & Wiersz(3)) Then 'jeśli pklik także istnieje już w nowej lokalizacji
                                            Wiersz(4) = "OK"
                                            Wiersz(5) = "NOK"
                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                            Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                            If Not IsFileOpen(info) Then
                                                My.Computer.FileSystem.DeleteFile(Plik) 'skasuj ze starej
                                            Else 'tu kiedys dac co innego
                                                Wiersz(4) = "OK"
                                                Wiersz(5) = "NOK"
                                            End If

                                        Else ' jeśli pliku z popr. juz nazwa nie ma w nowej lokalizacji- przenieś go
                                            My.Computer.FileSystem.MoveFile(Plik, Folder_Dest & Wiersz(3))
                                            Wiersz(4) = "moved"
                                            Wiersz(5) = "NOK"
                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
                                            Nowa_Nazwa = Folder_Dest & Wiersz(3)
                                        End If
                                    End If
                                Else
                                    Wiersz(3) = "Incorrect delivery note number inside PDF file"
                                    Wiersz(4) = "NOK"
                                    Wiersz(5) = "NOK"
                                    Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
                                    Nowa_Nazwa = Plik
                                End If
                            End If
                        Catch ex As Exception
                            Try
                                Nowa_Nazwa = Plik
                                Zapisz_Log_Txt(ex.Message)
                            Catch ex1 As Exception

                            End Try


                        End Try

                    End If
#End Region
                    If Logowanie = True Then
                        itm = New ListViewItem(Wiersz)
                        Form_Operacje.Lista_Operacji.Items.Add(itm)
                        If Wysyłka_Na_FTP = False Then
                            If Zmiana_Nazwy = True Then
                                itm.Tag = Nowa_Nazwa
                            Else
                                itm.Tag = Plik
                            End If

                        End If

                        'Kolumna STATUS ZAPISU
                        If Wiersz(4) = "NOK" Then
                            If Zmiana_Nazwy = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(4).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK1 = Ilosc_NOK1 + 1
                        ElseIf Wiersz(4) = "OK" Or Wiersz(4) = "renamed" Or Wiersz(4) = "moved & renamed" Or Wiersz(4) = "moved" Or Wiersz(4) = "moved & renamed pages" Or Wiersz(4) = "FILE EXIST" Then
                            If Zmiana_Nazwy = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(4).BackColor = System.Drawing.Color.Lime
                            End If
                            Ilosc_OK1 = Ilosc_OK1 + 1
                        Else
                            If Zmiana_Nazwy = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(4).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK1 = Ilosc_NOK1 + 1
                        End If

                        'Kolumna STATUS WYSYŁKI na FTP
                        If Wiersz(5) = "NOK" Then
                            If Wysyłka_Na_FTP = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(5).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK = Ilosc_NOK + 1
                        ElseIf Wiersz(5) = "OK" Then
                            If Wysyłka_Na_FTP = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(5).BackColor = System.Drawing.Color.Lime
                            End If
                            Ilosc_OK = Ilosc_OK + 1
                        Else
                            If Wysyłka_Na_FTP = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(5).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK = Ilosc_NOK + 1
                        End If

                    End If

                Else ' NA WYPADEK DUBLI !!!!!!!!!!!
                    'Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                    Wiersz(3) = "Duplicate name. This file will not be processed."
                    Wiersz(4) = "NOK"
                    Wiersz(5) = "NOK"
                    If Logowanie = True Then
                        itm = New ListViewItem(Wiersz)
                        Form_Operacje.Lista_Operacji.Items.Add(itm)
                        itm.Tag = Plik

                        'Kolumna STATUS ZAPISU
                        If Wiersz(4) = "NOK" Then
                            If Zmiana_Nazwy = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(4).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK1 = Ilosc_NOK1 + 1
                        End If

                        'Kolumna STATUS WYSYŁKI na FTP
                        If Wiersz(5) = "NOK" Then
                            If Wysyłka_Na_FTP = True Then
                                itm.UseItemStyleForSubItems = False
                                itm.SubItems(5).BackColor = System.Drawing.Color.Red
                            End If
                            Ilosc_NOK = Ilosc_NOK + 1
                        End If

                    End If
                End If 'CZY DUBEL WZ
            End If
        Next
        If Logowanie = True Then
            Wiersz(0) = "..........................................................................................................."
            Wiersz(1) = "..........................................................................................................."
            Wiersz(2) = "..........................................................................................................."
            Wiersz(3) = "..........................................................................................................."
            Wiersz(4) = "..........................................................................................................."
            Wiersz(5) = "..........................................................................................................."
            itm = New ListViewItem(Wiersz)
            Form_Operacje.Lista_Operacji.Items.Add(itm)

            Wiersz(0) = ""
            Wiersz(1) = ""
            Wiersz(2) = ""
            Wiersz(3) = "Summary"
            Wiersz(4) = ""
            Wiersz(5) = ""
            itm = New ListViewItem(Wiersz)
            Form_Operacje.Lista_Operacji.Items.Add(itm)

            Wiersz(0) = ""
            Wiersz(1) = ""
            Wiersz(2) = ""
            Wiersz(3) = "Count of successful transmissions:"
            Wiersz(4) = Ilosc_OK1
            Wiersz(5) = Ilosc_OK
            itm = New ListViewItem(Wiersz)
            Form_Operacje.Lista_Operacji.Items.Add(itm)
            itm.UseItemStyleForSubItems = False
            itm.SubItems(4).BackColor = System.Drawing.Color.Lime
            itm.SubItems(5).BackColor = System.Drawing.Color.Lime

            Wiersz(0) = ""
            Wiersz(1) = ""
            Wiersz(2) = ""
            Wiersz(3) = "Count of failed transmissions:"
            Wiersz(4) = Ilosc_NOK1
            Wiersz(5) = Ilosc_NOK
            itm = New ListViewItem(Wiersz)
            Form_Operacje.Lista_Operacji.Items.Add(itm)
            itm.UseItemStyleForSubItems = False
            itm.SubItems(4).BackColor = System.Drawing.Color.Red
            itm.SubItems(5).BackColor = System.Drawing.Color.Red
        End If




    End Sub

    Public Function Czy_WZ_Jest_Dublem(Kolumna_Z_Ciagami As Integer, Sprawdzany_Ciag As String) As Boolean
        Dim Licznik As Int16 = 0
        'Kolumna_Z_Ciagami=2

        For i = 0 To Form_Operacje.Lista_Operacji.Items.Count - 1 Step 1
            If Form_Operacje.Lista_Operacji.Items(i).SubItems(Kolumna_Z_Ciagami).Text = Sprawdzany_Ciag Then
                Licznik = Licznik + 1
            End If
            'Debug.Print("--" & Form_Operacje.Lista_Operacji.Items(i).SubItems(Kolumna_Z_Ciagami).Text & "---")
        Next
        If Licznik > 0 Then
            Czy_WZ_Jest_Dublem = True
        Else
            Czy_WZ_Jest_Dublem = False
        End If
    End Function
    Public Function Sprawdz_PDF(Sciezka_Do_Pliku As String, Znaleziono_Nr As Boolean) As Boolean
        If Checking_File = True Then
            Dim Text As String = ParsePdfText2(Sciezka_Do_Pliku, True)
            Dim Znaleziona_pozycja1 As Long = 0
            'Jeśli wypełnilismy klucz to wyszukajmy go w tekscie i uzyskajmy jego pozycję
            If Text <> "" And Klucz_Sec IsNot Nothing Then
                Znaleziona_pozycja1 = Text.IndexOf(Klucz_Sec, RichTextBoxFinds.MatchCase)
            Else
                'jeśli nie znaleźliśmy nic to wypiszmy -1
                Znaleziona_pozycja1 = -1
            End If
            'czy pozycja startowa stringa do sprawdzania została ustalona za pomoca klucza?
            If Klucz_Sec <> "" And Znaleziona_pozycja1 + Start_Pos_Sec > 0 Then 'zabezpieczenie, jak natrafi na inny plik
                If Mid(Text, Znaleziona_pozycja1 + Start_Pos_Sec, Lenght_Text_Sec) = Control_String Then 'PYTANIE CZY TU + 1!!!
                    Sprawdz_PDF = True
                Else
                    Sprawdz_PDF = False
                End If
            Else ' jak nie ma klucza= wtedy szukamy po wskazaniu startoqwej pozycji i a nie po pozycji klucza!
                If Start_Pos_Sec > 0 Then 'MID potrzebuje startowej pozycji wiekszej od 0!!
                    If Mid(Text, Start_Pos_Sec, Lenght_Text_Sec) = Control_String Then
                        Sprawdz_PDF = True
                    Else
                        Sprawdz_PDF = False
                    End If
                Else
                    Sprawdz_PDF = False
                End If

            End If
        Else
            If Znaleziono_Nr = True Then 'wyłaczenie zabezpieczeń nie działa tylko na sprawdzenie pliku PDF. W przypadku gdy jednak nie zawiera on wymaganej WZ nie procesuj go
                Sprawdz_PDF = True 'jesli wyłaczone jest sprawdzanie to nie sprawdzaj w ogóle poprawności PDF
            Else
                Sprawdz_PDF = False 'jesli wyłaczone jest sprawdzanie to nie sprawdzaj w ogóle poprawności PDF
            End If

        End If


    End Function

    Public Function Wytnij_String(Tresc As String) As String
        'If Start_Pos = "" Then
        '    Start_Pos = 1
        '  
        'End If
        'If Lenght_Text = String.Empty Then
        '   Lenght_Text = 1
        '  
        'End If

        Dim Pozycja_Startowa As Long = 0
        If Tresc <> "" Then
            If Klucz <> "" And Klucz <> String.Empty Then
                Pozycja_Startowa = InStr(Tresc, Klucz) - 1 'instr liczy od 1 a nie od 0! Stąd tu odejmuje 1
            Else
                Pozycja_Startowa = 0
            End If
            If Start_Pos + Pozycja_Startowa > 0 And Pozycja_Startowa > -1 Then
                Wytnij_String = Tresc.Substring(Start_Pos + Pozycja_Startowa - 1, Lenght_Text) 'substring wycina od 0 
            Else
                Wytnij_String = ""
            End If
        Else
            Wytnij_String = ""
        End If

    End Function

    Function IsFileOpen(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        IsFileOpen = False
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
        Catch ex As Exception
            'Debug.Print(ex.Message)
            If TypeOf ex Is IOException AndAlso IsFileLocked(ex) Then
                IsFileOpen = True ' do something here, either close the file if you have a handle, show a msgbox, retry  or as a last resort terminate the process - which could cause corruption and lose data
            End If
        End Try
    End Function

    Public Function IsFileLocked(exception As Exception) As Boolean
        Dim errorCode As Integer = Marshal.GetHRForException(exception) And ((1 << 16) - 1)
        Return errorCode = 32 OrElse errorCode = 33
    End Function
    Public Function IsConnectedToInternet() As Boolean
        If My.Computer.Network.IsAvailable Then
            Try
                Dim IPHost As IPHostEntry = Dns.GetHostEntry("www.google.com")
                Return True
            Catch
                Return False
            End Try
        Else
            Return False
        End If
    End Function

    Public Function FilenameIsOK(ByVal fileNameAndPath As String) As Boolean
        Dim fileName = fileNameAndPath
        For Each c In Path.GetInvalidFileNameChars()
            If fileName.Contains(c) Then
                Return False
            End If
        Next
        If fileName.Contains(";") Or fileName.Contains(":") Then
            Return False
        End If
        Return True
    End Function

    Public Sub Zapisz_Log_Txt(Tresc As String)
        Try
            Dim strFile As String = "Error_Log.txt"
            Dim fileExists As Boolean = File.Exists(strFile)
            Using sw As New StreamWriter(File.Open(strFile, FileMode.OpenOrCreate))
                sw.WriteLine(
                    IIf(fileExists,
                        "Error Message in  Occured at-- " & DateTime.Now & ". Error details: " & Tresc,
                        "Start Error Log for today" & "Error details: " & Tresc))
            End Using
        Catch ex As Exception

        End Try

    End Sub


    Public Sub ExtractPages(ByVal sourcePdfPath As String, ByVal outputPdfPath As String, ByVal startPage As Integer, ByVal endPage As Integer)
        'https://www.codeproject.com/Articles/559380/SplittingplusandplusMergingplusPdfplusFilesplusinp
        'WYpakuj strony od 1 wskazanej do n-tej
        Dim reader As PdfReader = Nothing
        Dim sourceDocument As Document = Nothing
        Dim pdfCopyProvider As PdfCopy = Nothing
        Dim importedPage As PdfImportedPage = Nothing

        Try
            reader = New PdfReader(sourcePdfPath)
            sourceDocument = New Document(reader.GetPageSizeWithRotation(startPage))
            pdfCopyProvider = New PdfCopy(sourceDocument, New System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create))
            sourceDocument.Open()

            For i As Integer = startPage To endPage
                importedPage = pdfCopyProvider.GetImportedPage(reader, i)
                'Debug.Print(importedPage.ToString)

                pdfCopyProvider.AddPage(importedPage)
            Next

            sourceDocument.Close()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Extract_Specific_Pages(ByVal sourcePdfPath As String, ByVal outputPdfPath As String, ByVal extractThesePages As Integer())
        'Wypakuj poszczególne wskazane w tablicy strony
        Dim reader As PdfReader = Nothing
        Dim sourceDocument As Document = Nothing
        Dim pdfCopyProvider As PdfCopy = Nothing
        Dim importedPage As PdfImportedPage = Nothing

        Try
            reader = New PdfReader(sourcePdfPath)
            sourceDocument = New Document(reader.GetPageSizeWithRotation(extractThesePages(0)))
            pdfCopyProvider = New PdfCopy(sourceDocument, New System.IO.FileStream(outputPdfPath, System.IO.FileMode.Create))
            sourceDocument.Open()

            For Each pageNumber As Integer In extractThesePages
                importedPage = pdfCopyProvider.GetImportedPage(reader, pageNumber)

                pdfCopyProvider.AddPage(importedPage)
            Next

            sourceDocument.Close()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub


End Module
