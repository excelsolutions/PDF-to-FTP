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


Imports iTextSharp.text.pdf
Imports System.ComponentModel
Imports System.IO
Imports System.Net
Imports System.Runtime.InteropServices
'https://www.codeproject.com/info/cpol10.aspx
'http://www.vbforums.com/showthread.php?475759-Extract-Text-from-Pdfs-using-iTextSharp-(02-03-2005)&highlight=pdf
' Licencja: https://itextpdf.com/AGPL
Module Module1
    Public Licznik As Integer = 0
    Public Iter As Long = 0

    Public Function ParsePdfText(ByVal sourcePDF As String,
                                      Optional ByVal fromPageNum As Integer = 0,
                                      Optional ByVal toPageNum As Integer = 0) As String

        Dim sb As New System.Text.StringBuilder()
        Try
            Dim reader As New PdfReader(sourcePDF)
            Dim pageBytes() As Byte = Nothing
            Dim token As PRTokeniser = Nothing
            Dim tknType As Integer = -1
            Dim tknValue As String = String.Empty

            If fromPageNum = 0 Then
                fromPageNum = 1
            End If
            If toPageNum = 0 Then
                toPageNum = reader.NumberOfPages
            End If

            If fromPageNum > toPageNum Then
                Throw New ApplicationException("Parameter error: The value of fromPageNum can " &
                                           "not be larger than the value of toPageNum")
            End If

            For i As Integer = fromPageNum To toPageNum Step 1
                pageBytes = reader.GetPageContent(i)
                If Not IsNothing(pageBytes) Then
                    token = New PRTokeniser(pageBytes)
                    While token.NextToken()
                        tknType = token.TokenType()
                        tknValue = token.StringValue
                        If tknType = PRTokeniser.TK_STRING Then
                            sb.Append(token.StringValue)
                            'I need to add these additional tests to properly add whitespace to the output string
                        ElseIf tknType = 1 AndAlso tknValue = "-600" Then
                            sb.Append(" ")
                        ElseIf tknType = 10 AndAlso tknValue = "TJ" Then
                            sb.Append(" ")
                        End If
                    End While
                End If
            Next i
        Catch ex As Exception
            MessageBox.Show("Exception occured. " & ex.Message)
            Return String.Empty
        End Try
        Return sb.ToString()
    End Function

    Public Sub Aktualizacja_Statusow(Sprawdzanie_Stanu As Boolean)
        Dim i As Int16 = 0

        If Sprawdzanie_Stanu = True Then ' jeśli sprawdZanie ma byc wykonanne
            Try
                If IsConnectedToInternet() = False Then
                    My.Forms.Form_Main.L_PIC_FTP.BackColor = Color.Red
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_FTP, "Brak połączenia z internetem")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_FTP, "Brak połączenia z internetem")
                    My.Forms.Form_Main.ToolStripStatus_PIC.Visible = True
                    My.Forms.Form_Main.ToolStripStatus_PIC_Napis.Visible = True
                    My.Forms.Form_Main.Timer_PIC.Enabled = True
                    Exit Try
                End If
                If Ftp_Exist(Form_Ustawienia.T_Sciezka_FTP.Text) Then
                    My.Forms.Form_Main.L_Blad_FTP.Visible = False
                    My.Forms.Form_Main.L_PIC_FTP.BackColor = Color.Lime
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_FTP, "Połączono z folderem sieciowym: " & Form_Ustawienia.T_Sciezka_FTP.Text)
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_FTP, "Połączono z folderem sieciowym: " & Form_Ustawienia.T_Sciezka_FTP.Text)
                    My.Forms.Form_Main.ToolStripStatus_PIC.Visible = False
                    My.Forms.Form_Main.ToolStripStatus_PIC_Napis.Visible = False
                    My.Forms.Form_Main.Timer_PIC.Enabled = False
                Else
                    My.Forms.Form_Main.L_Blad_FTP.Visible = True
                    My.Forms.Form_Main.L_PIC_FTP.BackColor = Color.Red
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_FTP, "Brak połączenia ze wskazanym adresem: " & Form_Ustawienia.T_Sciezka_FTP.Text & ". Wskazany adres jest niepoprawny. Kliknij aby przejść do ustawień.")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_FTP, "Brak połączenia ze wskazanym adresem: " & Form_Ustawienia.T_Sciezka_FTP.Text & ". Wskazany adres jest niepoprawny. Kliknij aby przejść do ustawień.")
                    My.Forms.Form_Main.ToolStripStatus_PIC.Visible = True
                    My.Forms.Form_Main.ToolStripStatus_PIC_Napis.Visible = True
                    My.Forms.Form_Main.Timer_PIC.Enabled = True
                End If
            Catch ex As Exception
                My.Forms.Form_Main.L_Blad_FTP.Visible = True
                My.Forms.Form_Main.L_Blad_FTP.Text = "Błąd sprawdzania"
                My.Forms.Form_Main.L_PIC_FTP.BackColor = Color.Red
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_FTP, "Brak połączenia ze wskazanym FTP: " & Form_Ustawienia.T_Sciezka_FTP.Text & ", lub inny niezidentyfikowany błąd. Wskazany adres jest niepoprawny. Kliknij aby przejść do ustawień.")
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_FTP, "Brak połączenia ze wskazanym FTP: " & Form_Ustawienia.T_Sciezka_FTP.Text & ", lub inny niezidentyfikowany błąd. Wskazany adres jest niepoprawny. Kliknij aby przejść do ustawień.")
                My.Forms.Form_Main.ToolStripStatus_PIC.Visible = True
                My.Forms.Form_Main.ToolStripStatus_PIC_Napis.Visible = True
                My.Forms.Form_Main.Timer_PIC.Enabled = True
            End Try

            Try
                If Directory.Exists(Form_Ustawienia.T_Sciezka_PDF.Text) Then
                    My.Forms.Form_Main.L_Blad_Folder.Visible = False
                    My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Lime
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest poprawna. ")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest poprawna. ")
                Else
                    My.Forms.Form_Main.L_Blad_Folder.Visible = True
                    My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Red
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna. Kliknij celem przejścia do ustawień.")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna. Kliknij celem przejścia do ustawień.")
                End If
            Catch ex As Exception
                My.Forms.Form_Main.L_Blad_Folder.Visible = True
                My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Red
                My.Forms.Form_Main.L_Blad_Folder.Text = "Błąd sprawdzania. "
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna, lub wystąpił inny niezidentyfikowany bład. Kliknij celem przejścia do ustawień.")
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna, lub wystąpił inny niezidentyfikowany bład. Kliknij celem przejścia do ustawień.")
            End Try
        End If


        'Poniższa część wykonuje sie stale, nieustannie
        Dim Folder As String = Form_Ustawienia.T_Sciezka_PDF.Text
        Try
            For Each Plik As String In My.Computer.FileSystem.GetFiles(Folder)

                If UCase(Mid(Plik, Plik.Length - 3, 4)) = UCase(".pdf") Then
                    i = i + 1

                End If
            Next
        Catch ex As Exception
            Try
                If Directory.Exists(Form_Ustawienia.T_Sciezka_PDF.Text) Then
                    My.Forms.Form_Main.L_Blad_Folder.Visible = False
                    My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Lime
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest poprawna. ")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest poprawna. ")
                Else
                    My.Forms.Form_Main.L_Blad_Folder.Visible = True
                    My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Red
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna. Kliknij celem przejścia do ustawień.")
                    My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna. Kliknij celem przejścia do ustawień.")
                End If
            Catch ex1 As Exception
                My.Forms.Form_Main.L_Blad_Folder.Visible = True
                My.Forms.Form_Main.L_PIC_Folder.BackColor = Color.Red
                My.Forms.Form_Main.L_Blad_Folder.Text = "Błąd sprawdzania. "
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_Blad_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna, lub wystąpił inny niezidentyfikowany bład. Kliknij celem przejścia do ustawień.")
                My.Forms.Form_Main.ToolTip1.SetToolTip(My.Forms.Form_Main.L_PIC_Folder, "Wskazana ścieżka z plikami PDF jest niepoprawna, lub wystąpił inny niezidentyfikowany bład. Kliknij celem przejścia do ustawień.")
            End Try

            My.Forms.Form_Main.L_LIczba_Plikow.Text = 0
        End Try

        My.Forms.Form_Main.L_LIczba_Plikow.Text = i
        'USTAwienie ToolTip Text



    End Sub

    Public Function Ftp_Exist(Sciezka_FTP As String) As Boolean

        Ftp_Exist = False
        If Sciezka_FTP <> "" Then
            Dim request =
       DirectCast(WebRequest.Create(Sciezka_FTP), FtpWebRequest)

            request.Credentials =
            New NetworkCredential("ewzvelux", "43wercfe4we4")

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
        End If


    End Function


    Public Sub Przetworz_Pliki(Wysyłka_Na_FTP As Boolean)
        Dim Wiersz(4) As String
        Dim Sciezka_FTP As String = Form_Ustawienia.T_Sciezka_FTP.Text
        Dim Referencja As String = ""

        Dim itm As ListViewItem
        Dim i As Integer = 0
        Dim Ilosc_OK As Int16 = 0
        Dim Ilosc_NOK As Int16 = 0
        Dim Nowa_Nazwa As String = ""
        Dim Folder As String = Form_Ustawienia.T_Sciezka_PDF.Text
        For Each Plik As String In My.Computer.FileSystem.GetFiles(Folder) 'Sprawdź każdy plik w folderze
            If UCase(Mid(Plik, Plik.Length - 3, 4)) = UCase(".pdf") Then 'jesli rozszerzenie pliku to "pdf" to bierz plik do obrobki
                i = i + 1
                Wiersz(0) = i
                Wiersz(1) = System.IO.Path.GetFileName(Plik) 'lub bez rozszerzenia: System.IO.Path.GetFileNameWithoutExtension
                Referencja = Mid(ParsePdfText(Plik), 5, 9)
                Wiersz(2) = Referencja
                Wiersz(3) = "RLP_RP14_10131088000_1_" & Referencja & ".pdf" 'Nazwa pliku

                If Wysyłka_Na_FTP = True And Ftp_Exist(Sciezka_FTP) = True Then 'jesli właczylismy wysłanie na FTP  to procesuj dalej
                    ' If Not File.Exists(Sciezka_FTP & Wiersz(3)) Then
                    Dim remoteLOC As String = Sciezka_FTP & Wiersz(3) 'nazwa ftp plus nazwa pliku
                    Try
                        If Mid(ParsePdfText(Plik), 1, 2) = "WZ" And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ)
                            My.Computer.Network.UploadFile(Plik, remoteLOC, Form_Ustawienia.T_Login.Text, Form_Ustawienia.T_Haslo.Text, True, 500)
                            My.Computer.FileSystem.DeleteFile(Plik)
                            Wiersz(4) = "OK"
                        Else
                            Wiersz(4) = "NOK"
                            Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                            Wiersz(3) = "Incorrect delivery note number inside PDF file"
                            My.Computer.FileSystem.WriteAllText(Folder & Nowa_Nazwa & ".txt", "Plik PDF nie został wysłany. Struktura pliku odbiega od ustawionego wzorca. Problem z odczytem numeru referencyjnego. " & vbCrLf &
                        "Odczytana referencja: " & Referencja & vbCrLf &
                        "Nazwa pliku: " & Wiersz(3) & vbCrLf &
                        "Treść pliku PDF: " & vbCrLf &
                        ParsePdfText(Plik), False)
                        End If


                    Catch ex As Exception

                        Debug.Print(ex.Message)
                        Try 'kolejne zabezpieczenie
                            My.Computer.FileSystem.WriteAllText(Folder & Wiersz(1) & ".txt", "Plik PDF nie został wysłany. " & vbCrLf &
                            "Odczytana referencja: " & Referencja & vbCrLf &
                            "Nazwa pliku: " & Wiersz(3) & vbCrLf &
                            "Treść pliku PDF: " & vbCrLf &
                            ParsePdfText(Plik), False)
                            Wiersz(4) = "NOK"
                        Catch ex1 As Exception
                            Debug.Print(ex1.Message)
                        End Try

                    End Try

                    'My.Computer.FileSystem.CopyFile(Plik, Sciezka_FTP & Wiersz(3),
                    'Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                    'Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
                    'End If

                Else 'Jeśli wybraliśmy BEZ WYSYŁANIA plików na serwer - program ma zmienić wyłacznie nazwy tych plików
                    ' Try
                    Dim info As New FileInfo(Plik)
                    If System.IO.Path.GetFileName(Plik) <> Wiersz(3) Then 'jeśli nazwa już jest ok, nie procesuj dalej
                        If Mid(ParsePdfText(Plik), 1, 2) = "WZ" And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ)
                            If Not IsFileOpen(info) And Not File.Exists(Folder & Wiersz(3)) Then 'czy plik na pewno nie jest uzywany
                                My.Computer.FileSystem.RenameFile(Plik, Wiersz(3))
                                Nowa_Nazwa = Wiersz(3)
                                Wiersz(4) = "NOK"
                            Else
                                Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                                Wiersz(3) = "Files is locked or don't exist"
                                Wiersz(4) = "NOK"
                            End If
                        Else
                            Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
                            Wiersz(3) = "Incorrect delivery note number inside PDF file"
                            Wiersz(4) = "NOK"
                        End If
                        Wiersz(4) = "NOK"
                    Else
                        Nowa_Nazwa = Wiersz(3)
                        Wiersz(4) = "NOK"
                    End If

                End If


                itm = New ListViewItem(Wiersz)
                Form_Operacje.Lista_Operacji.Items.Add(itm)
                If Wysyłka_Na_FTP = False Then
                    itm.Tag = Folder & Nowa_Nazwa
                End If

                If Wiersz(4) = "NOK" Then
                    itm.UseItemStyleForSubItems = False
                    itm.SubItems(4).BackColor = Color.Red
                    Ilosc_NOK = Ilosc_NOK + 1
                ElseIf Wiersz(4) = "OK" Then
                    itm.UseItemStyleForSubItems = False
                    itm.SubItems(4).BackColor = Color.Lime
                    Ilosc_OK = Ilosc_OK + 1
                Else
                    itm.UseItemStyleForSubItems = False
                    itm.SubItems(4).BackColor = Color.Red
                    Ilosc_NOK = Ilosc_NOK + 1
                End If
            End If
        Next

        Wiersz(0) = "..........................................................................................................."
        Wiersz(1) = "..........................................................................................................."
        Wiersz(2) = "..........................................................................................................."
        Wiersz(3) = "..........................................................................................................."
        Wiersz(4) = "..........................................................................................................."
        itm = New ListViewItem(Wiersz)
        Form_Operacje.Lista_Operacji.Items.Add(itm)

        Wiersz(0) = ""
        Wiersz(1) = ""
        Wiersz(2) = ""
        Wiersz(3) = "Summary"
        Wiersz(4) = ""
        itm = New ListViewItem(Wiersz)
        Form_Operacje.Lista_Operacji.Items.Add(itm)

        Wiersz(0) = ""
        Wiersz(1) = ""
        Wiersz(2) = ""
        Wiersz(3) = "Count of successful transmissions:"
        Wiersz(4) = Ilosc_OK
        itm = New ListViewItem(Wiersz)
        Form_Operacje.Lista_Operacji.Items.Add(itm)
        itm.UseItemStyleForSubItems = False
        itm.SubItems(4).BackColor = Color.Lime

        Wiersz(0) = ""
        Wiersz(1) = ""
        Wiersz(2) = ""
        Wiersz(3) = "Count of failed transmissions:"
        Wiersz(4) = Ilosc_NOK
        itm = New ListViewItem(Wiersz)
        Form_Operacje.Lista_Operacji.Items.Add(itm)
        itm.UseItemStyleForSubItems = False
        itm.SubItems(4).BackColor = Color.Red



    End Sub

    Function IsFileOpen(ByVal file As FileInfo) As Boolean
        Dim stream As FileStream = Nothing
        IsFileOpen = False
        Try
            stream = file.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None)
            stream.Close()
        Catch ex As Exception

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
        Return True
    End Function




End Module
