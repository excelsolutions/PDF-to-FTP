Module Module_Archiwum
    'Stara wersja algorytmu
    'Public Sub Przetworz_Pliki(Wysyłka_Na_FTP As Boolean, Zmiana_Nazwy As Boolean, Inna_Lokalizacja As Boolean, Logowanie As Boolean) 'stara wersja algorytmu
    '    Dim Wiersz(5) As String

    '    Dim Referencja As String = ""

    '    Dim itm As ListViewItem
    '    Dim i As Integer = 0
    '    Dim Ilosc_OK As Int16 = 0
    '    Dim Ilosc_NOK As Int16 = 0
    '    Dim Ilosc_OK1 As Int16 = 0
    '    Dim Ilosc_NOK1 As Int16 = 0
    '    Dim Nowa_Nazwa As String = ""
    '    Dim Tresc_Pliku As String = ""
    '    Dim Start As Long = 0
    '    Dim Dlugosc As Long = 0

    '    'TODO: A co z plikami i DUBLAMI WZ???? Jeśli mamy dubel WZ to pliki beda mialy taka sama nazwe!
    '    'TODO: jeżeli w ustawieniach wpiszemy jako startowy ciag- 0 to wywala że nie rozpoznano struktury pliku- NAPRAWIONE
    '    For Each Plik As String In My.Computer.FileSystem.GetFiles(Folder_PDF) 'Sprawdź każdy plik w folderze
    '        If UCase(Mid(Plik, Plik.Length - 3, 4)) = UCase(".pdf") Then 'jesli rozszerzenie pliku to "pdf" to bierz plik do obrobki
    '            Tresc_Pliku = ParsePdfText2(Plik, True)
    '            i = i + 1
    '            Wiersz(0) = i
    '            Wiersz(1) = System.IO.Path.GetFileName(Plik) 'lub bez rozszerzenia: System.IO.Path.GetFileNameWithoutExtension
    '            Referencja = Wytnij_String(Tresc_Pliku) 'Wycina fragment pliku wg. ustawien Mid(Tresc_Pliku, 5, 9) 'TO PODMIENIC!
    '            Wiersz(2) = Referencja
    '            Wiersz(3) = Prefix & Referencja & Suffix & ".pdf" 'Nazwa pliku
    '            If Czy_WZ_Jest_Dublem(2, Wiersz(2)) = False Then


    '                If Wysyłka_Na_FTP = True And Stan_FTP = True Then 'jesli właczylismy wysłanie na FTP  to procesuj dalej
    '                    ' If Not File.Exists(Sciezka_FTP & Wiersz(3)) Then
    '                    Dim remoteLOC As String = Folder_FTP & Wiersz(3) 'nazwa ftp plus nazwa pliku
    '                    Try
    '                        'FilenameIsOK - sprawdza czy nazwa pliku nie zawiera specjalnych znakow, ktore nie moga byc uzwane
    '                        If Sprawdz_PDF(Plik) = True And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ)
    '                            My.Computer.Network.UploadFile(Plik, remoteLOC, Login_FTP, Haslo_FTP, True, 500)
    '                            My.Computer.FileSystem.DeleteFile(Plik)
    '                            Wiersz(4) = "OK"
    '                            Wiersz(5) = "OK"
    '                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                        Else
    '                            Wiersz(5) = "NOK"
    '                            Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
    '                            Wiersz(3) = "Incorrect delivery note number inside PDF file"
    '                            My.Computer.FileSystem.WriteAllText(Folder_PDF & Nowa_Nazwa & ".txt", "Plik PDF nie został wysłany. Struktura pliku odbiega od ustawionego wzorca. Problem z odczytem numeru referencyjnego. " & vbCrLf &
    '                    "Odczytana referencja: " & Referencja & vbCrLf &
    '                    "Nazwa pliku: " & Wiersz(3) & vbCrLf &
    '                    "Treść pliku PDF: " & vbCrLf &
    '                    Tresc_Pliku, False)
    '                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                        End If


    '                    Catch ex As Exception
    '                        Zapisz_Log_Txt(ex.Message) 'zapisanie treści błedu  w pliku txt o nazwie Error_Log.txt
    '                        Try 'kolejne zabezpieczenie
    '                            My.Computer.FileSystem.WriteAllText(Folder_PDF & Wiersz(1) & ".txt", "Plik PDF nie został wysłany. " & vbCrLf &
    '                        "Odczytana referencja: " & Referencja & vbCrLf &
    '                        "Nazwa pliku: " & Wiersz(3) & vbCrLf &
    '                        "Treść pliku PDF: " & vbCrLf &
    '                        ParsePdfText2(Plik, False), False)
    '                            'zapisanie zamiast pliku pdf pliku txt z opisem błedu

    '                            Wiersz(5) = "NOK"
    '                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                        Catch ex1 As Exception
    '                            Zapisz_Log_Txt(ex1.Message)
    '                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                        End Try
    '                    End Try

    '                    'My.Computer.FileSystem.CopyFile(Plik, Sciezka_FTP & Wiersz(3),
    '                    'Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
    '                    'Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)
    '                    'End If

    '                Else 'Jeśli wybraliśmy BEZ WYSYŁANIA plików na serwer - program ma zmienić wyłacznie nazwy tych plików
    '                    Try

    '                        Dim info As New FileInfo(Plik)
    '                        If System.IO.Path.GetFileName(Plik) <> Wiersz(3) Then 'jeśli nazwa już jest ok, nie procesuj dalej
    '                            'XXXXXXXXXXXXXXXXX TU DAC ZABEZPIECZNEI SUME KONTROLNA
    '                            If Sprawdz_PDF(Plik) = True And FilenameIsOK(Wiersz(3)) Then 'zabezpieczenie, czy plik pdf na pewno ma taki sam poczatek (WZ)
    '                                If Not IsFileOpen(info) And Not File.Exists(Folder_PDF & Wiersz(3)) Then 'czy plik na pewno nie jest uzywany
    '                                    'TODO: Błąd w algorytmie, niepotrzebnie połaczone dwa warunki and: czy plik otwarty i czy plik istnieje. To nie jest tożsame
    '                                    If Zmiana_Nazwy = True Then 'jeśli chcemy zmienić nazwe pliku
    '                                        If Inna_Lokalizacja = False Then
    '                                            My.Computer.FileSystem.RenameFile(Plik, Wiersz(3))
    '                                            Wiersz(4) = "renamed"
    '                                            Nowa_Nazwa = Wiersz(3)
    '                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                        Else
    '                                            If Not File.Exists(Folder_Dest & Wiersz(3)) Then
    '                                                My.Computer.FileSystem.MoveFile(Plik, Folder_Dest & Wiersz(3))
    '                                                Wiersz(4) = "moved & renamed"
    '                                                Wiersz(5) = "NOK"
    '                                                Nowa_Nazwa = Folder_Dest & Wiersz(3)
    '                                                Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                            Else
    '                                                My.Computer.FileSystem.DeleteFile(Plik)
    '                                                Wiersz(4) = "OK"
    '                                                Wiersz(5) = "NOK"
    '                                                Nowa_Nazwa = Folder_Dest & Wiersz(3)
    '                                                Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                            End If
    '                                        End If
    '                                    Else
    '                                        Wiersz(4) = "NOK"
    '                                        Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                                    End If
    '                                    'Nowa_Nazwa = Wiersz(3)
    '                                    Wiersz(5) = "NOK"
    '                                Else 'TODO: DO SPRAWDZENIA poniższy algorytm
    '                                    'Dodałem go aby obsługiwał przypadki gdy plik juz istnieje

    '                                    If Inna_Lokalizacja = False Then
    '                                        Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
    '                                        If File.Exists(Folder_PDF & Nowa_Nazwa) Then
    '                                            Wiersz(3) = "Files is exist"
    '                                            Wiersz(4) = "OK"
    '                                            Wiersz(5) = "NOK"
    '                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                        Else
    '                                            Wiersz(3) = "Files is locked or don't exist"
    '                                            Wiersz(4) = "NOK"
    '                                            Wiersz(5) = "NOK"
    '                                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                                        End If
    '                                    Else 'jeśli plik nie bedzie procesowany ale inna lokalizacja=true wtedy dodaj folder do nazwy pliku
    '                                        Nowa_Nazwa = Folder_PDF & System.IO.Path.GetFileName(Plik)
    '                                        If File.Exists(Nowa_Nazwa) Then
    '                                            Wiersz(3) = "Files is exist"
    '                                            Wiersz(4) = "OK"
    '                                            Wiersz(5) = "NOK"
    '                                            Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                        Else
    '                                            Wiersz(3) = "Files is locked or don't exist"
    '                                            Wiersz(4) = "NOK"
    '                                            Wiersz(5) = "NOK"
    '                                            Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                                        End If
    '                                    End If

    '                                    'TODO: Problem z tym- pokazuje sie pomimo że plik nie jest zablokowany tylko ew. już istnieje. 
    '                                    'Wiersz(3) = "Files is locked or don't exist"
    '                                    'Wiersz(4) = "NOK"
    '                                    'Wiersz(5) = "NOK"

    '                                End If
    '                            Else
    '                                If Inna_Lokalizacja = False Then
    '                                    Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
    '                                Else 'jeśli plik nie bedzie procesowany ale inna lokalizacja=true wtedy dodaj folder do nazwy pliku
    '                                    Nowa_Nazwa = Folder_PDF & System.IO.Path.GetFileName(Plik)
    '                                End If

    '                                Wiersz(3) = "Incorrect delivery note number inside PDF file"
    '                                Wiersz(4) = "NOK"
    '                                Wiersz(5) = "NOK"
    '                                Form_Main.Auto_Ilosc_Error = Form_Main.Auto_Ilosc_Error + 1
    '                            End If

    '                            Wiersz(5) = "NOK"
    '                        Else 'nie zmapowałem
    '                            If Inna_Lokalizacja = False Then 'jeśli plik już istnieje i ma popr. nazwe i nie przenosimy go nigdzie- to OK. Koniec procesowania 
    '                                Nowa_Nazwa = Wiersz(3)
    '                                Wiersz(4) = "OK"
    '                                Wiersz(5) = "NOK"
    '                                Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                            Else 'jeśli plik istnieje, ma popr. nazwe to przenies go do nowej lokalizacji
    '                                If File.Exists(Folder_Dest & Wiersz(3)) Then 'jeśli pklik także istnieje już w nowej lokalizacji
    '                                    Wiersz(4) = "OK"
    '                                    Wiersz(5) = "NOK"
    '                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
    '                                    If Not IsFileOpen(info) Then
    '                                        My.Computer.FileSystem.DeleteFile(Plik)
    '                                    Else 'tu kiedys dac co innego
    '                                        Wiersz(4) = "OK"
    '                                        Wiersz(5) = "NOK"
    '                                    End If

    '                                Else ' jeśli pliku z popr. juz nazwa nie ma w nowej lokalizacji- przenieś go
    '                                    My.Computer.FileSystem.MoveFile(Plik, Folder_Dest & Wiersz(3))
    '                                    Wiersz(4) = "moved"
    '                                    Wiersz(5) = "NOK"
    '                                    Form_Main.Auto_Ilosc_Zapisanych = Form_Main.Auto_Ilosc_Zapisanych + 1
    '                                    Nowa_Nazwa = Folder_Dest & Wiersz(3)
    '                                End If
    '                            End If

    '                        End If
    '                    Catch ex As Exception
    '                        Zapisz_Log_Txt(ex.Message)
    '                    End Try

    '                End If

    '                If Logowanie = True Then
    '                    itm = New ListViewItem(Wiersz)
    '                    Form_Operacje.Lista_Operacji.Items.Add(itm)
    '                    If Wysyłka_Na_FTP = False Then
    '                        If Zmiana_Nazwy = True Then
    '                            If Inna_Lokalizacja = False Then
    '                                itm.Tag = Folder_PDF & Nowa_Nazwa
    '                            Else
    '                                itm.Tag = Nowa_Nazwa 'już bez Folder_PDF ponieważ ścieżka już zapisana jest w zmiennej
    '                            End If
    '                        Else
    '                            itm.Tag = Plik
    '                        End If

    '                    End If

    '                    'Kolumna STATUS ZAPISU
    '                    If Wiersz(4) = "NOK" Then
    '                        If Zmiana_Nazwy = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(4).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK1 = Ilosc_NOK1 + 1
    '                    ElseIf Wiersz(4) = "OK" Or Wiersz(4) = "renamed" Or Wiersz(4) = "moved & renamed" Or Wiersz(4) = "moved" Then
    '                        If Zmiana_Nazwy = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(4).BackColor = System.Drawing.Color.Lime
    '                        End If
    '                        Ilosc_OK1 = Ilosc_OK1 + 1
    '                    Else
    '                        If Zmiana_Nazwy = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(4).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK1 = Ilosc_NOK1 + 1
    '                    End If

    '                    'Kolumna STATUS WYSYŁKI na FTP
    '                    If Wiersz(5) = "NOK" Then
    '                        If Wysyłka_Na_FTP = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(5).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK = Ilosc_NOK + 1
    '                    ElseIf Wiersz(5) = "OK" Then
    '                        If Wysyłka_Na_FTP = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(5).BackColor = System.Drawing.Color.Lime
    '                        End If
    '                        Ilosc_OK = Ilosc_OK + 1
    '                    Else
    '                        If Wysyłka_Na_FTP = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(5).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK = Ilosc_NOK + 1
    '                    End If

    '                End If

    '            Else ' NA WYPADEK DUBLI !!!!!!!!!!!
    '                'Nowa_Nazwa = System.IO.Path.GetFileName(Plik)
    '                Wiersz(3) = "Duplicate name. This file will not be processed."
    '                Wiersz(4) = "NOK"
    '                Wiersz(5) = "NOK"
    '                If Logowanie = True Then
    '                    itm = New ListViewItem(Wiersz)
    '                    Form_Operacje.Lista_Operacji.Items.Add(itm)
    '                    itm.Tag = Plik

    '                    'Kolumna STATUS ZAPISU
    '                    If Wiersz(4) = "NOK" Then
    '                        If Zmiana_Nazwy = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(4).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK1 = Ilosc_NOK1 + 1
    '                    End If

    '                    'Kolumna STATUS WYSYŁKI na FTP
    '                    If Wiersz(5) = "NOK" Then
    '                        If Wysyłka_Na_FTP = True Then
    '                            itm.UseItemStyleForSubItems = False
    '                            itm.SubItems(5).BackColor = System.Drawing.Color.Red
    '                        End If
    '                        Ilosc_NOK = Ilosc_NOK + 1
    '                    End If

    '                End If
    '            End If 'CZY DUBEL WZ
    '        End If


    '    Next
    '    If Logowanie = True Then
    '        Wiersz(0) = "..........................................................................................................."
    '        Wiersz(1) = "..........................................................................................................."
    '        Wiersz(2) = "..........................................................................................................."
    '        Wiersz(3) = "..........................................................................................................."
    '        Wiersz(4) = "..........................................................................................................."
    '        Wiersz(5) = "..........................................................................................................."
    '        itm = New ListViewItem(Wiersz)
    '        Form_Operacje.Lista_Operacji.Items.Add(itm)

    '        Wiersz(0) = ""
    '        Wiersz(1) = ""
    '        Wiersz(2) = ""
    '        Wiersz(3) = "Summary"
    '        Wiersz(4) = ""
    '        Wiersz(5) = ""
    '        itm = New ListViewItem(Wiersz)
    '        Form_Operacje.Lista_Operacji.Items.Add(itm)

    '        Wiersz(0) = ""
    '        Wiersz(1) = ""
    '        Wiersz(2) = ""
    '        Wiersz(3) = "Count of successful transmissions:"
    '        Wiersz(4) = Ilosc_OK1
    '        Wiersz(5) = Ilosc_OK
    '        itm = New ListViewItem(Wiersz)
    '        Form_Operacje.Lista_Operacji.Items.Add(itm)
    '        itm.UseItemStyleForSubItems = False
    '        itm.SubItems(4).BackColor = System.Drawing.Color.Lime
    '        itm.SubItems(5).BackColor = System.Drawing.Color.Lime

    '        Wiersz(0) = ""
    '        Wiersz(1) = ""
    '        Wiersz(2) = ""
    '        Wiersz(3) = "Count of failed transmissions:"
    '        Wiersz(4) = Ilosc_NOK1
    '        Wiersz(5) = Ilosc_NOK
    '        itm = New ListViewItem(Wiersz)
    '        Form_Operacje.Lista_Operacji.Items.Add(itm)
    '        itm.UseItemStyleForSubItems = False
    '        itm.SubItems(4).BackColor = System.Drawing.Color.Red
    '        itm.SubItems(5).BackColor = System.Drawing.Color.Red
    '    End If




    'End Sub
    'Stara wersja 3.0
    'Public Function ParsePdfText(ByVal sourcePDF As String,
    '                                  Optional ByVal fromPageNum As Integer = 0,
    '                                  Optional ByVal toPageNum As Integer = 0) As String

    '    Dim sb As New System.Text.StringBuilder()
    '    Try
    '        Dim reader As New PdfReader(sourcePDF)
    '        Dim pageBytes() As Byte = Nothing
    '        Dim token As PRTokeniser = Nothing
    '        Dim tknType As Integer = -1
    '        Dim tknValue As String = String.Empty
    '        Dim Licznik As Integer = 0
    '        If fromPageNum = 0 Then
    '            fromPageNum = 1
    '        End If
    '        If toPageNum = 0 Then
    '            toPageNum = reader.NumberOfPages
    '        End If
    '        Debug.Print("Ilosc stron: " & reader.NumberOfPages)
    '        If fromPageNum > toPageNum Then
    '            Throw New ApplicationException("Parameter error: The value of fromPageNum can " &
    '                                       "not be larger than the value of toPageNum")
    '        End If

    '        For i As Integer = fromPageNum To toPageNum Step 1
    '            pageBytes = reader.GetPageContent(i)

    '            ReDim Preserve Strony_Pliku(Licznik) 'TEST DO SKASOWANIA

    '            Licznik = Licznik + 1 'TEST DO SKASOWANIA
    '            If Not IsNothing(pageBytes) Then
    '                token = New PRTokeniser(pageBytes)
    '                While token.NextToken()
    '                    tknType = token.TokenType()
    '                    tknValue = token.StringValue
    '                    If tknType = PRTokeniser.TK_STRING Then
    '                        sb.Append(token.StringValue)

    '                        'I need to add these additional tests to properly add whitespace to the output string
    '                    ElseIf tknType = 1 AndAlso tknValue = "-600" Then
    '                        sb.Append(" ")
    '                    ElseIf tknType = 10 AndAlso tknValue = "TJ" Then
    '                        sb.Append(" ")
    '                    End If
    '                End While
    '            End If
    '        Next i
    '    Catch ex As Exception
    '        Zapisz_Log_Txt(ex.Message)
    '        MessageBox.Show("Exception occured. " & ex.Message)
    '        Return String.Empty
    '    End Try
    '    Return sb.ToString()
    'End Function

    'iText 5

    'Public Whole_File As String 'procesuj caly plik czy tylko część
    'Public Half_or_Specific As String 'bierz połowe stron czy określ jakie chcesz brać
    'Public Contain_Word As String 'strony do wzięcia mają zawierac słowa czy nie
    'Public First_Last_Pages As String 'bierz 1 czy 2 połowę plik updf
    'Public Contain_Text As String 'jesli ten tekst znajdzie się na stronie PDF to program ma brac ją do dalszego procesowania
End Module
