Module Module_Tlumaczenia
    Public Sub Wersja_PL()
        '---------Form_Ustawienia-------------


        'Taby w ustawieniach
        With My.Forms.Form_Ustawienia
            .TabPage1.Text = "Foldery"
            .TabPage2.Text = "Nazwy plików"
            .TabPage3.Text = "Dodatkowa weryfikacja plików"
            .TabPage4.Text = "Automatyzacja"
            .TabPage5.Text = "Dzielenie stron"
            .TabPage6.Text = "Język"
        End With
        'Przyciski na formularzu
        With My.Forms.Form_Ustawienia
            .Btn_Zapisz.Text = "Zapisz"
            .Btn_Anuluj.Text = "Anuluj"
            .Btn_Wybierz_Z_Zaznaczenia.Text = "Wybierz z zaznaczenia"
            .Btn_Wybierz_Z_Zaznaczenia1.Text = "Wybierz z zaznaczenia"
        End With
        'GroupBoxy
        With My.Forms.Form_Ustawienia
            .Group_PDF.Text = "Folder z plikami do przetworzenia"
            .Group_Destination.Text = "Folder docelowy zapisu plików"
            .Group_FTP.Text = "FTP"
            .Group_FileName.Text = "Lokalizacja oraz długość szukanego ciągu znaków"
            .Group_Pozycja_Control_Stringu.Text = "Pozycja tekstu kontrolnego"
            .Group_Control_String.Text = "Tekst kontrolny"
            .Group_Typ_Automatyzacji.Text = "Typ pracy programu"
            .Group_Interval.Text = "Interwał pracy automatu"
            .Group_Statystyka.Text = "Statystyka"
            .Group_Jezyk.Text = "Opcje językowe"
        End With
        'Radiobutton / CheckBox
        With My.Forms.Form_Ustawienia
            .Check_Rename.Text = "Pracuj na kopiach"
            .Check_FTP.Text = "Włącz" '- zmienia się to po kliknięciu 
            .Check_Duplicates.Text = "Duplikaty"
            .Check_Check.Text = "Włącz sprawdzanie pliku"
            .CheckAutomatyzacja.Text = "Aktywuj automat po starcie programu"
            .R_Save.Text = "Zmień nazwy"
            .R_Send.Text = "Zmień nazwy i wyślij na FTP"
            .Check_Process_File.Text = "Procesuj cały plik"
            .R_Half_PDF.Text = "Procesuj połowę pliku"
            .R_Pages.Text = "Procesuj wybrane strony"
            .R_Contain.Text = "Procesuj, jeśli zawiera wybrane słowo"
            .R_Not_Contain.Text = "Procesuj, jeśli nie zawiera wybranego słowa"
            .C_Group_Pages.Text = "Grupuj strony"
        End With
        'Label
        With My.Forms.Form_Ustawienia
            .L_Haslo.Text = "Hasło"
            .L_Adres.Text = "Adres"
            .L_Start_Position.Text = "Pozycja tekstu"
            .L_Specified_Text.Text = "Szukany tekst"
            .L_Number_Chars.Text = "Liczba znaków do wzięcia"
            .L_New_File_Name.Text = "Podgląd"
            .L_Wybierz_Przyklad.Text = "Wybierz plik PDF, aby zobaczyc podgląd ustawień"
            .L_Start_Position1.Text = "Pozycja tekstu"
            .L_Specified_Text1.Text = "Szukany tekst"
            .L_Number_Chars1.Text = "Liczba znaków do wzięcia"
            .L_Wybierz_Przyklad1.Text = "Wybierz plik PDF, aby zobaczyc podgląd ustawień"
            .L_Start.Text = "Godzina startu"
            .L_Liczba_Cykli.Text = "Liczba cykli"
            .L_Liczba_Zapisanych_Plikow.Text = "Liczba zapisanych plików"
            .L_Liczba_Bledow.Text = "Liczba błedów"
            .L_Text_ToFind.Text = "Ciąg znaków"
            .L_Page_Settings_Opis.Text = "Jeśli opcja ""Procesuj cały plik"" jest wyłączona, program będzie dzielił pliki na strony według ustawień na tej stronie"
            .L_Polowa1.Text = "1 połowa"
            .L_Polowa2.Text = "2 połowa"
        End With





        '---------Form_Ustawienia-------------
        'Menu
        With My.Forms.Form_Main
            .PlikToolStripMenuItem.Text = "Plik"
            .UstawieniaToolStripMenuItem1.Text = "Ustawienia"
            .WyjścieToolStripMenuItem.Text = "Wyjście"
            .PomocToolStripMenuItem1.Text = "Pomoc"
            .LicencjaToolStripMenuItem.Text = "Licencja"
            .UpdateToolStripMenuItem.Text = "Aktualizacja"
            .OProgramieToolStripMenuItem1.Text = "O programie"
        End With
        'Przyciski
        With My.Forms.Form_Main
            .Btn_Start.Text = "Wyślij na FTP"
            .Btn_Save.Text = "Zapisz pliki"
        End With
        'Toolstripmenu
        With My.Forms.Form_Main
            .ToolStripHide.Text = "Ukryj"
            .ToolStripStatusLabel1.Text = "Automatyzacja"
        End With
        'Label
        With My.Forms.Form_Main
            .LL_Ilosc_plikow.Text = "Ilość plików"
            .L_Przetworzone_Pliki.Text = "Przetworzone"
            .L_Petle.Text = "Il. cykli"
            .L_Interval.Text = "Interwał"
        End With

        'Nazwy form
        Form_Ustawienia.Text = "Ustawienia"

    End Sub
End Module
