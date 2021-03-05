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
Imports System.IO


Module Module_INI
    'SEKCJA 1 ŚCIEZKI
    Public Folder_PDF As String
    Public Folder_FTP As String
    Public Folder_Dest As String
    'SEKCJA 2 Login i hasło do FTP
    Public Login_FTP As String
    Public Haslo_FTP As String
    ' SEKCJA 3 Ustawienia ciągu znaków do pozyskania z pliku PDF
    Public Start_Pos As String
    Public Lenght_Text As String
    Public Prefix As String
    Public Suffix As String
    Public Klucz As String '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
    'SEKCJA 4 Ustawienia ciągu znaków do rozpoznawania prawidłowego pliku
    Public Start_Pos_Sec As String
    Public Lenght_Text_Sec As String
    Public Klucz_Sec As String '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
    Public Control_String As String
    Public Checking_File As String 'do sprawdzania czy program ma weryfikowac pdf
    'SEKCJA 5 Inne ustawienia
    Public Check_FTP As String
    Public Interval As String '                interwał automatyzacji
    Public Automation As String
    Public Type_Of_Automat As String
    Public Work_On_Copies As String
    Public Allow_Duplicates As String
    'Sekcja 6 Dzielenie plikow
    Public Whole_File As String 'procesuj caly plik czy tylko część
    Public Half_or_Specific As String 'bierz połowe stron czy określ jakie chcesz brać
    Public Contain_Word As String 'strony do wzięcia mają zawierac słowa czy nie
    Public First_Last_Pages As String 'bierz 1 czy 2 połowę plik updf
    Public Contain_Text As String 'jesli ten tekst znajdzie się na stronie PDF to program ma brac ją do dalszego procesowania
    Public Group_Pages As String 'grupowanie stron ze znalezionym słowem lub zapis jako osobna strona
    Public Jezyk As String 'język programu, opisów, podpowiedzi


    Sub ZAPISZ_USTAWIENIA_INI()
        'SEKCJA 1 Ściezki dostępu do folderów
        Folder_PDF = Form_Ustawienia.T_Sciezka_PDF.Text
        Folder_FTP = Form_Ustawienia.T_Sciezka_FTP.Text
        'SEKCJA 2 Login i hasło do FTP
        Login_FTP = Form_Ustawienia.T_Login.Text
        Haslo_FTP = Form_Ustawienia.T_Haslo.Text
        ' SEKCJA 3 Ustawienia ciągu znaków do pozyskania z pliku PDF
        Start_Pos = Form_Ustawienia.Num_Start.Value
        Lenght_Text = Form_Ustawienia.Num_Dlugosc.Value
        Prefix = Form_Ustawienia.T_Prefix.Text
        Suffix = Form_Ustawienia.T_Suffix.Text
        '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        Klucz = Form_Ustawienia.T_Klucz.Text
        'SEKCJA 4 Ustawienia ciągu znaków do rozpoznawania prawidłowego pliku
        Start_Pos_Sec = Form_Ustawienia.Num_Start1.Value
        Lenght_Text_Sec = Form_Ustawienia.Num_Dlugosc1.Value
        Klucz_Sec = Form_Ustawienia.T_Klucz1.Text
        '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        Control_String = Form_Ustawienia.T_Control_String.Text
        Checking_File = Form_Ustawienia.Check_Check.CheckState
        'SEKCJA 5 Inne ustawienia
        Check_FTP = Form_Ustawienia.Check_FTP.CheckState
        Interval = Form_Ustawienia.T_Interwal.Text
        Automation = Form_Ustawienia.CheckAutomatyzacja.CheckState
        Work_On_Copies = Form_Ustawienia.Check_Rename.CheckState
        Folder_Dest = Form_Ustawienia.T_Sciezka_Destination.Text
        If Form_Ustawienia.R_Save.Checked = True Then
            Type_Of_Automat = "Only_Save"
        Else
            Type_Of_Automat = "Save_And_Send"
        End If

        Whole_File = My.Forms.Form_Ustawienia.Check_Process_File.CheckState
        If My.Forms.Form_Ustawienia.L_Polowa1.BackColor = Color.Silver Then
            First_Last_Pages = 0 '1 połowa
        Else
            First_Last_Pages = 1 '2 połowa
        End If

        If My.Forms.Form_Ustawienia.R_Contain.Checked = True Then
            Contain_Word = 1
        Else
            Contain_Word = 0
        End If

        If My.Forms.Form_Ustawienia.R_Half_PDF.Checked = True Then
            Half_or_Specific = 0 'bierz jedna albo 2 połowe
        Else
            Half_or_Specific = 1 'bierz okreslone strony z PDF
        End If
        Contain_Text = My.Forms.Form_Ustawienia.T_Tekst_Na_Stronach.Text
        If My.Forms.Form_Ustawienia.C_Group_Pages.Checked = True Then
            Group_Pages = 1 'grupuj strony z tym samym słowem
        Else
            Group_Pages = 0 'Zapisuj strony ze znalezionym słowem osobno
        End If
        Allow_Duplicates = Form_Ustawienia.Check_Duplicates.CheckState
        'Język
        If My.Forms.Form_Ustawienia.R_Polski.Checked = True Then
            Jezyk = "pl"
        ElseIf My.Forms.Form_Ustawienia.R_English.Checked = True Then
            Jezyk = "en"
        Else
            Jezyk = "en"
        End If


        'Sciezka do pliku ustawień INI
        Dim Directory As String = My.Application.Info.DirectoryPath
        Dim ini As New IniFile

        ' Load and existing file
        ini.Load(Directory & "\Preferences.ini")
        'Zapis wszystkich sekcji
        ini.AddSection("ACCESS_PATH").AddKey("Folder_PDF").Value = Folder_PDF
        ini.AddSection("ACCESS_PATH").AddKey("Folder_FTP").Value = Folder_FTP
        ini.AddSection("ACCESS_PATH").AddKey("Folder_Dest").Value = Folder_Dest
        ini.AddSection("FTP").AddKey("Login_FTP").Value = Login_FTP
        ini.AddSection("FTP").AddKey("Password_FTP").Value = Haslo_FTP

        ini.AddSection("STRING_TO_GET").AddKey("Start_Pos").Value = Start_Pos
        ini.AddSection("STRING_TO_GET").AddKey("Lenght_Text").Value = Lenght_Text
        ini.AddSection("STRING_TO_GET").AddKey("Prefix").Value = Prefix
        ini.AddSection("STRING_TO_GET").AddKey("Suffix").Value = Suffix
        ini.AddSection("STRING_TO_GET").AddKey("Key").Value = Klucz

        ini.AddSection("PDF_CHECK_KEY").AddKey("Start_Pos_Sec").Value = Start_Pos_Sec
        ini.AddSection("PDF_CHECK_KEY").AddKey("Lenght_Text_Sec").Value = Lenght_Text_Sec
        ini.AddSection("PDF_CHECK_KEY").AddKey("Key_Sec").Value = Klucz_Sec
        ini.AddSection("PDF_CHECK_KEY").AddKey("Control_String").Value = Control_String
        ini.AddSection("PDF_CHECK_KEY").AddKey("Checking_File").Value = Checking_File

        ini.AddSection("OTHER_SETTINGS").AddKey("Check_FTP").Value = Check_FTP
        ini.AddSection("OTHER_SETTINGS").AddKey("Interval").Value = Interval
        ini.AddSection("OTHER_SETTINGS").AddKey("Automation").Value = Automation
        ini.AddSection("OTHER_SETTINGS").AddKey("Type_Of_Automat").Value = Type_Of_Automat
        ini.AddSection("OTHER_SETTINGS").AddKey("Work_On_Copies").Value = Work_On_Copies
        ini.AddSection("OTHER_SETTINGS").AddKey("Allow_Duplicates").Value = Allow_Duplicates
        ini.AddSection("OTHER_SETTINGS").AddKey("Language").Value = Jezyk

        ini.AddSection("SPLITTING FILES").AddKey("Whole_File").Value = Whole_File
        ini.AddSection("SPLITTING FILES").AddKey("Half_or_Specific").Value = Half_or_Specific
        ini.AddSection("SPLITTING FILES").AddKey("Contain_Word").Value = Contain_Word
        ini.AddSection("SPLITTING FILES").AddKey("First_Last_Pages").Value = First_Last_Pages
        ini.AddSection("SPLITTING FILES").AddKey("Contain_Text").Value = Contain_Text
        ini.AddSection("SPLITTING FILES").AddKey("Group_Pages").Value = Group_Pages


        ' Key Rename Test
        'Trace.Write("Key Rename Key1 -> KeyTemp Test: ")
        'If ini.RenameKey("TEST_SECTION", "Key1", "KeyTemp") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        ' Section Rename Test
        'Trace.Write("Test section rename TEST_SECTION -> TEST_SECTION_3: ")
        'If ini.RenameSection("TEST_SECTION", "TEST_SECTION_3") Then
        '    Trace.WriteLine("Pass")
        'Else Trace.WriteLine("Fail")
        'End If


        ' Check Key Rename Post Section Rename
        'Trace.Write("Test TEST_SECTION_3 rename key KeyTemp -> Key1: ")
        'If ini.RenameKey("TEST_SECTION_3", "KeyTemp", "Key1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        ' Check Section Rename Post Section Rename
        'Trace.Write("Test section rename TEST_SECTION_3 -> TEST_SECTION: ")
        'If ini.RenameSection("TEST_SECTION_3", "TEST_SECTION") Then
        '    Trace.WriteLine("Pass")
        'Else Trace.WriteLine("Fail")
        'End If


        ' Check Key Rename Key1 -> Key2 where Key2 exists
        'Trace.Write("Test TEST_SECTION key rename Key1 -> Key2 where Key2 exists: ")
        'If ini.RenameKey("TEST_SECTION", "Key2", "Key1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        ' Check Key Rename
        'Trace.Write("Test TEST_SECTION key rename Key2 -> Key2Renamed: ")
        'If ini.RenameKey("TEST_SECTION", "Key2", "Key2Renamed") Then
        '    Trace.WriteLine("Pass")
        'Else
        'End If



        ' Test rename other section
        'Trace.Write("Test section rename TEST_SECTION_2 -> TEST_SECTION_1 : ")
        'If ini.RenameSection("TEST_SECTION_2", "TEST_SECTION_1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        ' Check remove key
        'Trace.Write("Test TEST_SECTION_1 remove key Key1: ")
        'If ini.GetSection("TEST_SECTION_1").RemoveKey("Key1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        '' Check remove key no exist
        'Trace.Write("Test TEST_SECTION_1 remove key Key1: ")
        'If ini.GetSection("TEST_SECTION_1").RemoveKey("Key1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        '' Check remove section
        'Trace.Write("Test remove section TEST_SECTION_1: ")
        'If ini.RemoveSection("TEST_SECTION_1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If


        '' Check remove section no exist
        'Trace.Write("Test remove section TEST_SECTION_1: ")
        'If ini.RemoveSection("TEST_SECTION_1") Then
        '    Trace.WriteLine("Pass")
        'Else
        '    Trace.WriteLine("Fail")
        'End If
        'Debug.Print(Directory)

        'Save the INI
        ini.Save(Directory & "\Preferences.ini")
    End Sub

    Sub WCZYTAJ_USTAWIENIA_INI()
        'Sciezka do pliku ustawień INI
        Dim Directory As String = My.Application.Info.DirectoryPath
        Dim ini As New IniFile

        ' Load and existing file
        ini.Load(Directory & "\Preferences.ini")
        'SEKCJA 1 Ściezki dostępu do folderów

        Folder_PDF = ini.GetSection("ACCESS_PATH").GetKey("Folder_PDF").GetValue()
        Folder_FTP = ini.GetSection("ACCESS_PATH").GetKey("Folder_FTP").GetValue()
        'SEKCJA 2 Login i hasło do FTP
        Login_FTP = ini.GetSection("FTP").GetKey("Login_FTP").GetValue()
        Haslo_FTP = ini.GetSection("FTP").GetKey("Password_FTP").GetValue()
        ' SEKCJA 3 Ustawienia ciągu znaków do pozyskania z pliku PDF
        Start_Pos = ini.GetSection("STRING_TO_GET").GetKey("Start_Pos").GetValue()
        Lenght_Text = ini.GetSection("STRING_TO_GET").GetKey("Lenght_Text").GetValue()
        Prefix = ini.GetSection("STRING_TO_GET").GetKey("Prefix").GetValue()
        Suffix = ini.GetSection("STRING_TO_GET").GetKey("Suffix").GetValue()
        '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        Klucz = ini.GetSection("STRING_TO_GET").GetKey("Key").GetValue()
        'SEKCJA 4 Ustawienia ciągu znaków do rozpoznawania prawidłowego pliku
        Start_Pos_Sec = ini.GetSection("PDF_CHECK_KEY").GetKey("Start_Pos_Sec").GetValue()
        Lenght_Text_Sec = ini.GetSection("PDF_CHECK_KEY").GetKey("Lenght_Text_Sec").GetValue()
        Klucz_Sec = ini.GetSection("PDF_CHECK_KEY").GetKey("Key_Sec").GetValue()
        '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        Control_String = ini.GetSection("PDF_CHECK_KEY").GetKey("Control_String").GetValue()
        ' If ini.GetSection("PDF_CHECK_KEY").GetKey("Checking_File").Value Is Nothing Then
        'ini.AddSection("PDF_CHECK_KEY").AddKey("Checking_File").Value = 0
        'ini.Save(Directory & "\Preferences.ini")
        'Else
        Checking_File = ini.GetSection("PDF_CHECK_KEY").GetKey("Checking_File").Value
        'End If


        'SEKCJA 5 Inne ustawienia
        Check_FTP = ini.GetSection("OTHER_SETTINGS").GetKey("Check_FTP").GetValue()
        Interval = ini.GetSection("OTHER_SETTINGS").GetKey("Interval").GetValue()
        Automation = ini.GetSection("OTHER_SETTINGS").GetKey("Automation").Value
        Type_Of_Automat = ini.GetSection("OTHER_SETTINGS").GetKey("Type_Of_Automat").Value
        'NP_ otwieramy naraz 2 pliki, jeden New preferences ktory umieszczac bede w zipie. Nastepnie preferences klienta:
        ' i wtedy skopiować z pliku klienta do ustawien nowych i podmienic plik
        If ini.RenameKey("OTHER_SETTINGS", "Work_On_Copies", "Work_On_Copies") Then
            'Trace.WriteLine("Pass")
            Work_On_Copies = ini.GetSection("OTHER_SETTINGS").GetKey("Work_On_Copies").Value
        Else
            'Trace.WriteLine("Fail")
            ini.AddSection("OTHER_SETTINGS").AddKey("Work_On_Copies").Value = Work_On_Copies
            ini.Save(Directory & "\Preferences.ini")
        End If
        Folder_Dest = ini.GetSection("ACCESS_PATH").GetKey("Folder_Dest").Value
        Whole_File = ini.GetSection("SPLITTING FILES").GetKey("Whole_File").Value
        Half_or_Specific = ini.GetSection("SPLITTING FILES").GetKey("Half_or_Specific").Value
        Contain_Word = ini.GetSection("SPLITTING FILES").GetKey("Contain_Word").Value
        Contain_Text = ini.GetSection("SPLITTING FILES").GetKey("Contain_Text").Value
        First_Last_Pages = ini.GetSection("SPLITTING FILES").GetKey("First_Last_Pages").Value
        If ini.RenameKey("SPLITTING FILES", "Group_Pages", "Group_Pages") Then
            Group_Pages = ini.GetSection("SPLITTING FILES").GetKey("Group_Pages").Value
        Else
            ini.AddSection("SPLITTING FILES").AddKey("Group_Pages").Value = 1
            ini.Save(Directory & "\Preferences.ini")
            Group_Pages = ini.GetSection("SPLITTING FILES").GetKey("Group_Pages").Value
        End If

        If ini.RenameKey("OTHER_SETTINGS", "Allow_Duplicates", "Allow_Duplicates") Then
            Allow_Duplicates = ini.GetSection("OTHER_SETTINGS").GetKey("Allow_Duplicates").Value
        Else
            ini.AddSection("OTHER_SETTINGS FILES").AddKey("Allow_Duplicates").Value = 1
            ini.Save(Directory & "\Preferences.ini")
            Allow_Duplicates = ini.GetSection("OTHER_SETTINGS").GetKey("Allow_Duplicates").Value
        End If

        If ini.RenameKey("OTHER_SETTINGS", "Language", "Language") Then
            Jezyk = ini.GetSection("OTHER_SETTINGS").GetKey("Language").Value
        Else
            ini.AddSection("OTHER_SETTINGS FILES").AddKey("Language").Value = "en"
            ini.Save(Directory & "\Preferences.ini")
            Jezyk = "en"
        End If




        Form_Ustawienia.T_Sciezka_PDF.Text = Folder_PDF
        Form_Ustawienia.T_Sciezka_FTP.Text = Folder_FTP
        Form_Ustawienia.T_Login.Text = Login_FTP
        Form_Ustawienia.T_Haslo.Text = Haslo_FTP
        Form_Ustawienia.Num_Start.Value = Start_Pos
        Form_Ustawienia.Num_Dlugosc.Value = Lenght_Text
        Form_Ustawienia.T_Prefix.Text = Prefix
        Form_Ustawienia.T_Suffix.Text = Suffix
        Form_Ustawienia.T_Klucz.Text = Klucz
        Form_Ustawienia.Num_Start1.Value = Start_Pos_Sec
        Form_Ustawienia.Num_Dlugosc1.Value = Lenght_Text_Sec
        Form_Ustawienia.T_Klucz1.Text = Klucz_Sec
        Form_Ustawienia.T_Control_String.Text = Control_String
        Form_Ustawienia.Check_Check.CheckState = Checking_File
        Form_Ustawienia.Check_FTP.Checked = Check_FTP
        Form_Ustawienia.T_Interwal.Text = Interval
        Form_Ustawienia.CheckAutomatyzacja.Checked = Automation
        If Automation = 1 Then
            Form_Ustawienia.L_PIC_Auto.BackColor = Color.Lime
            Form_Main.ToolStripAutomation.Visible = True
            Form_Main.ToolStripStatusLabel1.Visible = True
        Else
            Form_Ustawienia.L_PIC_Auto.BackColor = Color.Red
            Form_Main.ToolStripAutomation.Visible = False
            Form_Main.ToolStripStatusLabel1.Visible = False
        End If

        If Type_Of_Automat = "Only_Save" Then 'ustawienia automatu
            Form_Ustawienia.R_Save.Checked = True
        Else
            Form_Ustawienia.R_Send.Checked = True
        End If

        If Work_On_Copies Is Nothing Then
            Work_On_Copies = False
        End If
        If Work_On_Copies = 1 Then 'czy ma kopiowac pliki w inne miejsce
            Form_Ustawienia.Check_Rename.Checked = Work_On_Copies
            Form_Ustawienia.L_PIC_Rename.BackColor = Color.Lime
        Else
            Form_Ustawienia.Check_Rename.Checked = Work_On_Copies
            Form_Ustawienia.L_PIC_Rename.BackColor = Color.Red
        End If


        Form_Ustawienia.T_Sciezka_Destination.Text = Folder_Dest
        Form_Ustawienia.Check_Process_File.Checked = Whole_File
        Form_Ustawienia.T_Tekst_Na_Stronach.Text = Contain_Text

        Form_Ustawienia.Aktualizuj_Kolor()
        If Whole_File = 1 Then
            My.Forms.Form_Ustawienia.Check_Process_File.Checked = True
            My.Forms.Form_Ustawienia.L_Pick_Process_File.BackColor = Color.Lime
            My.Forms.Form_Ustawienia.SplitC.Visible = False
            My.Forms.Form_Ustawienia.R_Half_PDF.Visible = False
            My.Forms.Form_Ustawienia.R_Pages.Visible = False
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.Visible = False
            My.Forms.Form_Ustawienia.L_Pic_Pages.Visible = False
            My.Forms.Form_Ustawienia.L_Page_Settings_Opis.Visible = True
        Else
            My.Forms.Form_Ustawienia.Check_Process_File.Checked = False
            My.Forms.Form_Ustawienia.L_Pick_Process_File.BackColor = Color.Red
            My.Forms.Form_Ustawienia.SplitC.Visible = True
            My.Forms.Form_Ustawienia.R_Half_PDF.Visible = True
            My.Forms.Form_Ustawienia.R_Pages.Visible = True
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.Visible = True
            My.Forms.Form_Ustawienia.L_Pic_Pages.Visible = True
            My.Forms.Form_Ustawienia.L_Page_Settings_Opis.Visible = False
        End If

        If First_Last_Pages = 0 Then '0 - pierwsza połowa, 1- druga połowa
            My.Forms.Form_Ustawienia.L_Polowa1.BackColor = Color.Silver
            My.Forms.Form_Ustawienia.L_Polowa2.BackColor = Color.WhiteSmoke
        Else
            My.Forms.Form_Ustawienia.L_Polowa2.BackColor = Color.Silver
            My.Forms.Form_Ustawienia.L_Polowa1.BackColor = Color.WhiteSmoke
        End If

        If Contain_Word = 1 Then
            My.Forms.Form_Ustawienia.R_Contain.Checked = True
            My.Forms.Form_Ustawienia.L_Pic_Contain.BackColor = Color.Lime
            My.Forms.Form_Ustawienia.R_Not_Contain.Checked = False
            My.Forms.Form_Ustawienia.L_Pic_Not_Contain.BackColor = Color.Red
        Else
            My.Forms.Form_Ustawienia.R_Contain.Checked = False
            My.Forms.Form_Ustawienia.L_Pic_Contain.BackColor = Color.Red
            My.Forms.Form_Ustawienia.R_Not_Contain.Checked = True
            My.Forms.Form_Ustawienia.L_Pic_Not_Contain.BackColor = Color.Lime
        End If
        If Half_or_Specific = 0 Then '0- bierz rowne polowy, 1- bierz poszczegolne strony
            My.Forms.Form_Ustawienia.R_Half_PDF.Checked = True
            My.Forms.Form_Ustawienia.R_Pages.Checked = False
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.BackColor = Color.Lime
            My.Forms.Form_Ustawienia.L_Pic_Pages.BackColor = Color.Red
            My.Forms.Form_Ustawienia.SplitC.Panel1.Enabled = True
            My.Forms.Form_Ustawienia.SplitC.Panel2.Enabled = False
        Else
            My.Forms.Form_Ustawienia.R_Half_PDF.Checked = False
            My.Forms.Form_Ustawienia.R_Pages.Checked = True
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.BackColor = Color.Red
            My.Forms.Form_Ustawienia.L_Pic_Pages.BackColor = Color.Lime
            My.Forms.Form_Ustawienia.SplitC.Panel1.Enabled = False
            My.Forms.Form_Ustawienia.SplitC.Panel2.Enabled = True
        End If
        If Group_Pages = 1 Then
            My.Forms.Form_Ustawienia.C_Group_Pages.Checked = True
        Else
            My.Forms.Form_Ustawienia.C_Group_Pages.Checked = False
        End If
        If Allow_Duplicates = 1 Then
            My.Forms.Form_Ustawienia.Check_Duplicates.Checked = True
        Else
            My.Forms.Form_Ustawienia.Check_Duplicates.Checked = False
        End If

        Select Case Jezyk
            Case "pl"
                My.Forms.Form_Ustawienia.R_Polski.Checked = True
                My.Forms.Form_Ustawienia.R_English.Checked = False
            Case "en"
                My.Forms.Form_Ustawienia.R_Polski.Checked = False
                My.Forms.Form_Ustawienia.R_English.Checked = True
        End Select




        'If My.Forms.Form_Ustawienia.Check_Half_PDF.Checked = True Then
        '    First_Last_Pages = True 'bierz jedna albo 2 połowe
        'Else
        '    First_Last_Pages = False 'bierz okreslone strony z PDF
        'End If
    End Sub
    Sub Inicjacja_INI()
        Dim Directory As String = My.Application.Info.DirectoryPath
        Dim ini As New IniFile
        If File.Exists(Directory & "\Preferences.ini") Then
        Else
            My.Computer.FileSystem.WriteAllText(Directory & "\Preferences.ini", "[FTP_DANE]", False)
            ZAPISZ_USTAWIENIA_INI()
        End If

    End Sub
    Sub Ujawnij_Zmienne()
        Debug.Print("Folder_PDF- " & Folder_PDF)
        Debug.Print("Folder_FTP- " & Folder_FTP)
        'SEKCJA 2 Login i hasło do FTP
        Debug.Print("Login_FTP- " & Login_FTP)
        Debug.Print("Haslo_FTP- " & Haslo_FTP)
        ' SEKCJA 3 Ustawienia ciągu znaków do pozyskania z pliku PDF
        Debug.Print("Start_Pos- " & Start_Pos)
        Debug.Print("Lenght_Text- " & Lenght_Text)
        Debug.Print("Prefix- " & Prefix)
        Debug.Print("Suffix- " & Suffix)
        Debug.Print("Klucz- " & Klucz) '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        'SEKCJA 4 Ustawienia ciągu znaków do rozpoznawania prawidłowego pliku
        Debug.Print("Start_Pos_Sec- " & Start_Pos_Sec)
        Debug.Print("Lenght_Text_Sec- " & Lenght_Text_Sec)
        Debug.Print("Klucz_Sec- " & Klucz_Sec) '   Ciąg znaków, który ma być znaleziony i od którego nalezy poruszać się w prawo lub w lewo celem wyłuskania ciągu znaków
        Debug.Print("Control_String- " & Control_String)
        'SEKCJA 5 Inne ustawienia
        Debug.Print("Check_FTP- " & Check_FTP)
        Debug.Print("Interval- " & Interval) '  

    End Sub

    Public Sub Aktualizacja_Programu_Nowe_INI()
        'Procedura na wypadek jak zmieni się plik INI- dojdzie tam parę kluczy
        'Sciezka do pliku ustawień INI
        Dim Directory As String = My.Application.Info.DirectoryPath
        Dim Ini_Original As New IniFile
        Dim Ini_New As New IniFile
        Dim Napis As String = ""
        ' Load and existing file
        Ini_Original.Load(Directory & "\Preferences.ini")
        If File.Exists(Directory & "\New_Preferences.ini") Then
            Ini_New.Load(Directory & "\New_Preferences.ini")
            ' DODANIE BRAKUJĄCEJ SEKCJI
            For Each Sekcja In Ini_New.Sections
                If Ini_Original.GetSection(Sekcja.getname()) Is Nothing Then
                    Ini_Original.AddSection(Ini_New.GetSection(Sekcja.getname()).GetName())
                End If
                For Each KeyName_New In Ini_New.GetSection(Sekcja.getname()).Keys
                    If Ini_Original.GetSection(Sekcja.getname()).GetKey(KeyName_New.getname()) Is Nothing Then
                        Ini_Original.AddSection(Sekcja.getname()).AddKey(KeyName_New.getname()).Value = KeyName_New.getvalue()
                    End If
                Next
            Next
            Ini_Original.Save(Directory & "\Preferences.ini")
            'usunięcie pliku New_Preferences
            My.Computer.FileSystem.DeleteFile(Directory & "\New_Preferences.ini")
        End If

    End Sub
End Module
