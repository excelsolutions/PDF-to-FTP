Imports System.ComponentModel

Public Class Form_Ustawienia
    Public Przelacznik As Boolean = True
    Public Pica As Integer = 0
    Public Kontrolka As Label
    Public Kolor_Kontrolki As Color
    Dim Poprzednia_PDF As Int16
    Dim Poprzednia_Check As Int16
    Dim Czy_Rysować As Boolean = False
    Private Sub Btn_Zapisz_Click(sender As Object, e As EventArgs) Handles Btn_Zapisz.Click
        Aktualizacja_Statusow(True)
        ZAPISZ_USTAWIENIA_INI()
        If CheckAutomatyzacja.Checked = True Then
            If IsNumeric(CLng(Interval)) And CLng(Interval) > 0 Then
                Form_Main.Timer_Automat.Interval = CLng(Interval) * 1000
                Form_Main.Timer_Automat.Enabled = True
                Form_Main.ToolStripAutomation.Image = My.Resources.Green_Button
                Me.Hide()
                Aktualizacja_Statusow(True)
                Form_Main.Show()
            Else
                CheckAutomatyzacja.Checked = False
                Form_Main.Timer_Automat.Enabled = False
                Form_Main.ToolStripAutomation.Image = My.Resources.Red_Button
                MsgBox("The interval should be a number greater than 0", vbOKOnly, "Error")
            End If
        Else
            Form_Main.Timer_Automat.Enabled = False
            Form_Main.ToolStripAutomation.Image = My.Resources.Red_Button
            Me.Hide()
            Aktualizacja_Statusow(True)
            Form_Main.Show()
        End If


        If Stan_Polaczenia_FTP = True Then
            Form_Main.Timer_PIC.Enabled = False
        Else
            Form_Main.Timer_PIC.Enabled = True
        End If
        WCZYTAJ_USTAWIENIA_INI()





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



        WCZYTAJ_USTAWIENIA_INI()
        If Contain_Word = 1 Then
            Czy_Rysować = True
        Else
            Czy_Rysować = False
        End If
        ' Create the ToolTip and associate with the Form container.
        Aktualizuj_Kolor()


        ' Set up the delays for the ToolTip.
        ToolTip1.AutoPopDelay = 5000
        ToolTip1.InitialDelay = 1000
        ToolTip1.ReshowDelay = 500
        ' Force the ToolTip text to be displayed whether or not the form is active.
        ToolTip1.ShowAlways = True




    End Sub

    Private Sub Btn_Anuluj_Click(sender As Object, e As EventArgs) Handles Btn_Anuluj.Click
        Me.T_Sciezka_PDF.Text = Folder_PDF
        Me.T_Sciezka_FTP.Text = Folder_FTP
        Me.T_Login.Text = Login_FTP
        Me.T_Haslo.Text = Haslo_FTP
        Me.Num_Start.Value = Start_Pos
        Me.Num_Dlugosc.Value = Lenght_Text
        Me.T_Prefix.Text = Prefix
        Me.T_Suffix.Text = Suffix
        Me.T_Klucz.Text = Klucz
        Me.Hide()
        Aktualizacja_Statusow(True)
        If Stan_Polaczenia_FTP = True Then
            Form_Main.Timer_PIC.Enabled = False
        Else
            Form_Main.Timer_PIC.Enabled = True
        End If
        Form_Main.Show()
    End Sub

    Private Sub T_Sciezka_PDF_TextChanged(sender As Object, e As EventArgs) Handles T_Sciezka_PDF.TextChanged

        If Microsoft.VisualBasic.Right(T_Sciezka_PDF.Text, 1) <> "\" Then
            T_Sciezka_PDF.Text = T_Sciezka_PDF.Text & "\"
        End If
    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles L_Start_Position.Click



    End Sub


    Sub Aktualizuj_Kolor()
        Dim Znaleziona_pozycja As Long 'do wycinanego ciągu
        Dim Znaleziona_pozycja1 As Long ' do ustawień zabezpieczenia PDF
        Dim Start_Realny As Long 'do wycinanego ciągu
        Dim Start_Realny1 As Long ' do ustawień zabezpieczenia PDF
        Pic.Visible = False
        Pic1.Visible = False
        Pic_Sec.Visible = False
        If T_Klucz.Text <> "" Then
            Znaleziona_pozycja = R_Podglad.Find(Me.T_Klucz.Text, RichTextBoxFinds.MatchCase)
        Else
            Znaleziona_pozycja = 0
        End If
        Start_Realny = Me.Num_Start.Value
        If Start_Realny > 0 Then
            Start_Realny = Start_Realny - 1
        End If
        If (T_Klucz.Text = "" Or Znaleziona_pozycja < 0) And Start_Realny > 0 Then 'jesli nie wybraliśmy klucza
            Pic.Visible = False
            With R_Podglad
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                .SelectionColor = Color.Black
                If Start_Realny > 0 Then
                    .SelectionStart = Start_Realny
                Else
                    .SelectionStart = 0
                End If
                If Start_Realny > 0 Then
                    .SelectionStart = Start_Realny
                Else
                    .SelectionStart = 0
                End If

                .SelectionLength = Me.Num_Dlugosc.Value
                .SelectionColor = Color.Red
                T_Przykladowa_Nazwa.Text = T_Prefix.Text & "_1_" & R_Podglad.SelectedText & T_Suffix.Text & ".pdf"
            End With
        Else

            If Znaleziona_pozycja >= 0 Then
                Pic.Visible = True
            Else
                Pic.Visible = False
            End If

            With R_Podglad
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                .SelectionColor = Color.Black
                If Znaleziona_pozycja + Start_Realny > 0 Then
                    .SelectionStart = Znaleziona_pozycja + Start_Realny
                Else
                    .SelectionStart = 0
                End If

                .SelectionLength = Me.Num_Dlugosc.Value
                .SelectionColor = Color.Red
                T_Przykladowa_Nazwa.Text = T_Prefix.Text & "_1_" & R_Podglad.SelectedText & T_Suffix.Text & ".pdf"
            End With
        End If

        R_Podglad.ScrollToCaret()


        'DO USATWIEN SPRAWDZANIA PLIKU PDF
        If T_Klucz1.Text <> "" Then 'jak klucz  nie jest pusty to szukaj
            Znaleziona_pozycja1 = R_Podglad1.Find(Me.T_Klucz1.Text, RichTextBoxFinds.MatchCase)
        Else
            Znaleziona_pozycja1 = 0
        End If
        Start_Realny1 = Me.Num_Start1.Value
        If Start_Realny1 > 0 Then
            Start_Realny1 = Start_Realny1 - 1
        End If
        If (T_Klucz1.Text = "" Or Znaleziona_pozycja1 < 0) And Start_Realny1 > 0 Then
            Pic1.Visible = False
            With R_Podglad1
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                .SelectionColor = Color.Black
                If Start_Realny1 + Znaleziona_pozycja1 > 0 Then
                    .SelectionStart = Start_Realny1
                Else '
                    .SelectionStart = 0
                End If
                .SelectionLength = Me.Num_Dlugosc1.Value
                .SelectionColor = Color.Red
            End With
            If R_Podglad1.SelectedText = Me.T_Control_String.Text Then
                Pic_Sec.Visible = True
            Else
                Pic_Sec.Visible = False
            End If
        Else

            With R_Podglad1
                .SelectionStart = 0
                .SelectionLength = Len(.Text)
                .SelectionColor = Color.Black
                If Znaleziona_pozycja1 + Start_Realny1 > 0 Then
                    .SelectionStart = Znaleziona_pozycja1 + Start_Realny1
                Else
                    .SelectionStart = 0
                End If

                .SelectionLength = Me.Num_Dlugosc1.Value
                .SelectionColor = Color.Red
            End With

            If Znaleziona_pozycja1 >= 0 Then
                Pic1.Visible = True
                If R_Podglad1.SelectedText = Me.T_Control_String.Text Then
                    Pic_Sec.Visible = True
                Else
                    Pic_Sec.Visible = False
                End If
            Else
                Pic1.Visible = False
            End If
        End If
        If Interval > 0 Then
            Num_Sekundy.Value = Interval
        End If


        R_Podglad1.ScrollToCaret()
    End Sub



    Private Sub Num_Start_ValueChanged(sender As Object, e As EventArgs) Handles Num_Start.ValueChanged

        If Num_Start.Value = 0 Then
            If Poprzednia_PDF < Num_Start.Value Then 'naciśnięto przycisk +
                Num_Start.Value = 1
            Else
                Num_Start.Value = -1
            End If
        End If

        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
        Poprzednia_PDF = Num_Start.Value

    End Sub

    Private Sub Num_Dlugosc_ValueChanged(sender As Object, e As EventArgs) Handles Num_Dlugosc.ValueChanged

        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub R_Podglad_TextChanged(sender As Object, e As EventArgs) Handles R_Podglad.TextChanged

    End Sub

    Private Sub Pic_Wybierz_Przyklad_Click(sender As Object, e As EventArgs) Handles Pic_Wybierz_Przyklad.Click


        OpenFileDialog1.Title = "Please select a pdf file"
        'OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        OpenFileDialog1.Filter = "PDF|*.pdf"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.R_Podglad.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Me.R_Podglad1.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub Btn_Wybierz_Z_Zaznaczenia_Click(sender As Object, e As EventArgs) Handles Btn_Wybierz_Z_Zaznaczenia.Click
        Przelacznik = False
        T_Klucz.Text = ""

        With R_Podglad
            Me.Num_Start.Value = .SelectionStart + 1 'Bo selekcja zaczyna sie od 0
            Me.Num_Dlugosc.Value = .SelectionLength
            Aktualizuj_Kolor()
        End With
        Przelacznik = True
    End Sub

    Private Sub CommitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CommitToolStripMenuItem.Click
        Przelacznik = False
        With R_Podglad
            Me.Num_Start.Value = .SelectionStart
            Me.Num_Dlugosc.Value = .SelectionLength
            Aktualizuj_Kolor()
        End With
        Przelacznik = True
    End Sub

    Private Sub T_Prefix_TextChanged(sender As Object, e As EventArgs) Handles T_Prefix.TextChanged
        Aktualizuj_Kolor()
        ' R_Podglad.SelectionStart = Me.Num_Start.Value
        'R_Podglad.SelectionLength = Me.Num_Dlugosc.Value

        ' T_Przykladowa_Nazwa.Text = T_Prefix.Text & R_Podglad.SelectedText & T_Prefix.Text & ".pdf"
    End Sub

    Private Sub T_Suffix_TextChanged(sender As Object, e As EventArgs) Handles T_Suffix.TextChanged
        Aktualizuj_Kolor()
    End Sub

    Private Sub T_Klucz_TextChanged(sender As Object, e As EventArgs) Handles T_Klucz.TextChanged
        If Przelacznik = True Then
            Aktualizuj_Kolor()
            ' Num_Start.Value = 0
        End If
        If T_Klucz.Text = "" Then
            Num_Start.Minimum = 1
        Else
            Num_Start.Minimum = -99999999
        End If
        L_Pozycja_Karety.Text = R_Podglad.SelectionStart
    End Sub

    Private Sub R_Podglad_MouseClick(sender As Object, e As MouseEventArgs) Handles R_Podglad.MouseClick
        L_Pozycja_Karety.Text = R_Podglad.SelectionStart

    End Sub

    Private Sub Pic_Wybierz_Przyklad1_Click(sender As Object, e As EventArgs) Handles Pic_Wybierz_Przyklad1.Click

        OpenFileDialog1.Title = "Please select a pdf file"
        'OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        OpenFileDialog1.Filter = "PDF|*.pdf"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.R_Podglad1.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Me.R_Podglad.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub Btn_Wybierz_Z_Zaznaczenia1_Click(sender As Object, e As EventArgs) Handles Btn_Wybierz_Z_Zaznaczenia1.Click
        Przelacznik = False
        T_Klucz1.Text = ""

        With R_Podglad1
            Me.Num_Start1.Value = .SelectionStart
            Me.Num_Dlugosc1.Value = .SelectionLength
            Aktualizuj_Kolor()
        End With
        Przelacznik = True
    End Sub

    Private Sub Num_Start1_ValueChanged(sender As Object, e As EventArgs) Handles Num_Start1.ValueChanged
        If Num_Start.Value = 0 Then
            If Poprzednia_Check < Num_Start.Value Then 'naciśnięto przycisk +
                Num_Start.Value = 1
            Else
                Num_Start.Value = -1
            End If
        End If
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
        Poprzednia_Check = Num_Start.Value
    End Sub

    Private Sub Num_Dlugosc1_ValueChanged(sender As Object, e As EventArgs) Handles Num_Dlugosc1.ValueChanged
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub T_Klucz1_TextChanged(sender As Object, e As EventArgs) Handles T_Klucz1.TextChanged
        If Przelacznik = True Then
            Aktualizuj_Kolor()
            'Num_Start1.Value = 0
        End If

        L_Pozycja_Karety1.Text = R_Podglad1.SelectionStart
    End Sub

    Private Sub L_Pic_Sec_Click(sender As Object, e As EventArgs)
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub L_PIC1_Click(sender As Object, e As EventArgs)
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub L_PIC_Click(sender As Object, e As EventArgs)
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub T_Control_String_TextChanged(sender As Object, e As EventArgs) Handles T_Control_String.TextChanged
        If Przelacznik = True Then
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub R_Podglad1_TextChanged(sender As Object, e As EventArgs) Handles R_Podglad1.TextChanged

    End Sub

    Private Sub R_Podglad1_MouseClick(sender As Object, e As MouseEventArgs) Handles R_Podglad1.MouseClick
        L_Pozycja_Karety1.Text = R_Podglad1.SelectionStart
    End Sub

    Private Sub L_PIC_MouseHover(sender As Object, e As EventArgs)
        If Pic.Visible = False Then
            ToolTip1.SetToolTip(Pic, "String not found")
        Else
            ToolTip1.SetToolTip(Pic, "String found")
        End If


    End Sub

    Private Sub TabPage2_Click(sender As Object, e As EventArgs) Handles TabPage2.Click

    End Sub

    Private Sub L_Pozycja_Karety_Click(sender As Object, e As EventArgs) Handles L_Pozycja_Karety.Click

    End Sub

    Private Sub L_Wybierz_Przyklad_Click(sender As Object, e As EventArgs) Handles L_Wybierz_Przyklad.Click

        OpenFileDialog1.Title = "Please select a pdf file"
        'OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        OpenFileDialog1.Filter = "PDF|*.pdf"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.R_Podglad.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Me.R_Podglad1.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub L_Wybierz_Przyklad1_Click(sender As Object, e As EventArgs) Handles L_Wybierz_Przyklad1.Click

        OpenFileDialog1.Title = "Please select a pdf file"
        'OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        OpenFileDialog1.Filter = "PDF|*.pdf"

        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Me.R_Podglad1.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Me.R_Podglad.Text = ParsePdfText2(OpenFileDialog1.FileName, True)
            Aktualizuj_Kolor()
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged

    End Sub

    Private Sub Form_Ustawienia_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form_Main.Show()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles Num_Minuty.ValueChanged
        If T_Interwal.Text = "" Then
            T_Interwal.Text = 0
        End If
        T_Interwal.Text = Num_Sekundy.Value + Num_Minuty.Value * 60
        If T_Interwal.Text < 5 Then
            T_Interwal.Text = 5
        End If
    End Sub

    Private Sub Num_Sekundy_ValueChanged(sender As Object, e As EventArgs) Handles Num_Sekundy.ValueChanged
        If T_Interwal.Text = "" Then
            T_Interwal.Text = 0
        End If
        T_Interwal.Text = Num_Sekundy.Value + Num_Minuty.Value * 60
        If T_Interwal.Text < 10 Then
            T_Interwal.Text = 10
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles R_Send.CheckedChanged

        L_PIC_Send.BackColor = Color.Lime
        L_PIC_Save.BackColor = Color.Red
        Kontrolka = L_PIC_Send
        Kolor_Kontrolki = L_PIC_Send.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub R_Save_CheckedChanged(sender As Object, e As EventArgs) Handles R_Save.CheckedChanged

        L_PIC_Save.BackColor = Color.Lime
        L_PIC_Send.BackColor = Color.Red
        Kontrolka = L_PIC_Save
        Kolor_Kontrolki = L_PIC_Save.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub Timer_Pic_Tick(sender As Object, e As EventArgs) Handles Timer_Pic.Tick



        Pica = Pica + 1
        If Kolor_Kontrolki = Color.Lime Then
            If Pica = 5 Then
                Kontrolka.BackColor = Color.LightGray
            End If
            If Pica = 10 Then
                Kontrolka.BackColor = Color.Lime
            End If
            If Pica = 12 Then
                Kontrolka.BackColor = Color.LightGray
            End If

            If Pica = 15 Then

                Kontrolka.BackColor = Color.Lime

                Pica = 0
                Timer_Pic.Enabled = False
            End If
        Else
            Pica = 0
            Timer_Pic.Enabled = False
        End If

    End Sub


    Private Sub CheckAutomatyzacja_CheckedChanged(sender As Object, e As EventArgs) Handles CheckAutomatyzacja.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If CheckAutomatyzacja.Checked = True Then
            L_PIC_Auto.BackColor = Color.Lime
        Else
            L_PIC_Auto.BackColor = Color.Red
        End If

        Kontrolka = L_PIC_Auto
        Kolor_Kontrolki = L_PIC_Auto.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub L_PIC_Save_Click(sender As Object, e As EventArgs) Handles L_PIC_Save.Click

    End Sub

    Private Sub Pic_Destination_Click(sender As Object, e As EventArgs) Handles Pic_Destination.Click
        ' Wybor_Folderu.ShowDialog()
        If Wybor_Folderu.ShowDialog = Windows.Forms.DialogResult.OK Then
            Me.T_Sciezka_Destination.Text = (Wybor_Folderu.SelectedPath) & "\"
        End If
    End Sub

    Private Sub Check_Rename_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Rename.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If Check_Rename.Checked = True Then
            L_PIC_Rename.BackColor = Color.Lime
        Else
            L_PIC_Rename.BackColor = Color.Red
        End If
        Kontrolka = L_PIC_Rename
        Kolor_Kontrolki = L_PIC_Rename.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub Check_FTP_CheckedChanged(sender As Object, e As EventArgs) Handles Check_FTP.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If Check_FTP.Checked = True Then
            L_PIC_FTP.BackColor = Color.Lime
        Else
            L_PIC_FTP.BackColor = Color.Red
        End If
        Kontrolka = L_PIC_FTP
        Kolor_Kontrolki = L_PIC_FTP.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Check.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If Check_Check.Checked = True Then
            L_Pic_Check.BackColor = Color.Lime
        Else
            L_Pic_Check.BackColor = Color.Red
        End If
        Kontrolka = L_Pic_Check
        Kolor_Kontrolki = L_Pic_Check.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitC.Panel2.Paint
        If Czy_Rysować = True Then
            Dim blackpen As New Drawing.Pen(Color.Red, 2.0)
            Dim x1 As Int16
            Dim y1 As Int16
            Dim x2 As Int16
            Dim y2 As Int16

            x1 = Me.T_Tekst_Na_Stronach.Left + Me.T_Tekst_Na_Stronach.Width \ 2
            y1 = Me.T_Tekst_Na_Stronach.Top + Me.T_Tekst_Na_Stronach.Height + 1
            x2 = Me.L_Przyklad.Left
            y2 = Me.L_Przyklad.Top + Me.L_Przyklad.Height \ 4

            'e.Graphics.DrawRectangle(p, Me.Check_Contain.Bounds)'rysuj czerwona obwolutkę
            e.Graphics.DrawLine(blackpen, x1, y1, x2, y2)

            'e.Graphics.DrawLine(Pens.Black, X1, Y1, X2, Y2)


            blackpen.Dispose()
        Else

        End If
    End Sub

    Sub Rysuj()




    End Sub

    Private Sub L_Przyklad_Paint(sender As Object, e As PaintEventArgs) Handles L_Przyklad.Paint
        If Czy_Rysować = True Then

            Dim blackpen As New Drawing.Pen(Color.Red, 2.0)
            Dim X As Int16 = Me.L_Przyklad.Width \ 8
            Dim Y As Int16 = Me.L_Przyklad.Height \ 3.8
            Dim dlu As Int16 = Me.L_Przyklad.Width \ 5
            Dim wys As Int16 = Me.L_Przyklad.Height \ 10
            'e.Graphics.DrawRectangle(p, Me.L_Przyklad.Bounds) 'rysuj czerwona obwolutkę
            e.Graphics.DrawEllipse(blackpen, X, Y, dlu, wys)

            'e.Graphics.DrawLine(Pens.Black, X1, Y1, X2, Y2)
        Else

        End If
    End Sub



    Private Sub TabPage5_Click(sender As Object, e As EventArgs) Handles TabPage5.Click

    End Sub

    Private Sub L_Polowa1_Click(sender As Object, e As EventArgs) Handles L_Polowa1.Click

        L_Polowa1.BackColor = Color.Silver
            L_Polowa2.BackColor = Color.WhiteSmoke

    End Sub

    Private Sub L_Polowa2_Click(sender As Object, e As EventArgs) Handles L_Polowa2.Click
        L_Polowa1.BackColor = Color.WhiteSmoke
        L_Polowa2.BackColor = Color.Silver

    End Sub

    Private Sub Check_Process_File_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Process_File.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If Check_Process_File.Checked = True Then
            L_Pick_Process_File.BackColor = Color.Lime
            My.Forms.Form_Ustawienia.SplitC.Visible = False
            My.Forms.Form_Ustawienia.R_Half_PDF.Visible = False
            My.Forms.Form_Ustawienia.R_Pages.Visible = False
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.Visible = False
            My.Forms.Form_Ustawienia.L_Pic_Pages.Visible = False
            My.Forms.Form_Ustawienia.L_Page_Settings_Opis.Visible = True
        Else
            L_Pick_Process_File.BackColor = Color.Red
            My.Forms.Form_Ustawienia.SplitC.Visible = True
            My.Forms.Form_Ustawienia.R_Half_PDF.Visible = True
            My.Forms.Form_Ustawienia.R_Pages.Visible = True
            My.Forms.Form_Ustawienia.L_Pic_Half_PDF.Visible = True
            My.Forms.Form_Ustawienia.L_Pic_Pages.Visible = True
            My.Forms.Form_Ustawienia.L_Page_Settings_Opis.Visible = False
        End If

        Kontrolka = L_Pick_Process_File
        Kolor_Kontrolki = L_Pick_Process_File.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub Check_Contain_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub R_Half_PDF_CheckedChanged(sender As Object, e As EventArgs) Handles R_Half_PDF.CheckedChanged

        L_Pic_Half_PDF.BackColor = Color.Lime
        L_Pic_Pages.BackColor = Color.Red
        Kontrolka = L_Pic_Half_PDF
        Kolor_Kontrolki = L_Pic_Half_PDF.BackColor
        Timer_Pic.Enabled = True


    End Sub

    Private Sub R_Pages_CheckedChanged(sender As Object, e As EventArgs) Handles R_Pages.CheckedChanged

        L_Pic_Half_PDF.BackColor = Color.Red
        L_Pic_Pages.BackColor = Color.Lime
        Kontrolka = L_Pic_Pages
        Kolor_Kontrolki = L_Pic_Pages.BackColor
        Timer_Pic.Enabled = True

    End Sub

    Private Sub R_Contain_CheckedChanged(sender As Object, e As EventArgs) Handles R_Contain.CheckedChanged
        L_Pic_Contain.BackColor = Color.Lime
        L_Pic_Not_Contain.BackColor = Color.Red
        Kontrolka = L_Pic_Contain
        Kolor_Kontrolki = L_Pic_Contain.BackColor
        Timer_Pic.Enabled = True
        If R_Not_Contain.Checked = True Then
            Czy_Rysować = False
            L_Przyklad.Refresh()
            SplitC.Panel2.Refresh()
        Else
            Czy_Rysować = True
            L_Przyklad.Refresh()
            SplitC.Panel2.Refresh()
        End If

    End Sub

    Private Sub R_Not_Contain_CheckedChanged(sender As Object, e As EventArgs) Handles R_Not_Contain.CheckedChanged
        'https://stackoverflow.com/questions/14873293/graphics-object-in-vb-net
        L_Pic_Contain.BackColor = Color.Red
        L_Pic_Not_Contain.BackColor = Color.Lime
        Kontrolka = L_Pic_Not_Contain
        Kolor_Kontrolki = L_Pic_Not_Contain.BackColor
        Timer_Pic.Enabled = True
        If R_Not_Contain.Checked = True Then
            Czy_Rysować = False
            L_Przyklad.Refresh()
            SplitC.Panel2.Refresh()
        Else
            Czy_Rysować = True
            L_Przyklad.Refresh()
            SplitC.Panel2.Refresh()
        End If


    End Sub

    Private Sub R_Half_PDF_Click(sender As Object, e As EventArgs) Handles R_Half_PDF.Click
        My.Forms.Form_Ustawienia.SplitC.Panel1.Enabled = True
        My.Forms.Form_Ustawienia.SplitC.Panel2.Enabled = False
    End Sub

    Private Sub R_Pages_Click(sender As Object, e As EventArgs) Handles R_Pages.Click
        My.Forms.Form_Ustawienia.SplitC.Panel1.Enabled = False
        My.Forms.Form_Ustawienia.SplitC.Panel2.Enabled = True
    End Sub

    Private Sub L_Przyklad_Click(sender As Object, e As EventArgs) Handles L_Przyklad.Click

    End Sub

    Private Sub L_Przyklad_Enter(sender As Object, e As EventArgs) Handles L_Przyklad.Enter

    End Sub

    Private Sub L_Pic_Contain_Click(sender As Object, e As EventArgs) Handles L_Pic_Contain.Click

    End Sub

    Private Sub R_Group_Pages_CheckedChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub L_Pic_Not_Contain_Click(sender As Object, e As EventArgs) Handles L_Pic_Not_Contain.Click

    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles C_Group_Pages.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If C_Group_Pages.Checked = True Then
            L_Pic_Group_Pages.BackColor = Color.Lime
        Else
            L_Pic_Group_Pages.BackColor = Color.Red
        End If

        Kontrolka = L_Pic_Group_Pages
        Kolor_Kontrolki = L_Pic_Group_Pages.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub Check_Duplicates_CheckedChanged(sender As Object, e As EventArgs) Handles Check_Duplicates.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If Check_Duplicates.Checked = True Then
            L_Pic_Duplicates.BackColor = Color.Lime
        Else
            L_Pic_Duplicates.BackColor = Color.Red
        End If
        Kontrolka = L_Pic_Duplicates
        Kolor_Kontrolki = L_Pic_Duplicates.BackColor
        Timer_Pic.Enabled = True
    End Sub



    Private Sub R_Polski_CheckedChanged_1(sender As Object, e As EventArgs) Handles R_Polski.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If R_Polski.Checked = True Then
            L_Pic_Polski.BackColor = Color.Lime
        Else
            L_Pic_Polski.BackColor = Color.Red
        End If

        Kontrolka = L_Pic_Polski
        Kolor_Kontrolki = L_Pic_Polski.BackColor
        Timer_Pic.Enabled = True
        Wersja_PL()
    End Sub

    Private Sub R_English_CheckedChanged(sender As Object, e As EventArgs) Handles R_English.CheckedChanged
        Timer_Pic.Enabled = False
        Kontrolka.BackColor = Kolor_Kontrolki
        If R_English.Checked = True Then
            L_Pick_English.BackColor = Color.Lime
        Else
            L_Pick_English.BackColor = Color.Red
        End If

        Kontrolka = L_Pick_English
        Kolor_Kontrolki = L_Pick_English.BackColor
        Timer_Pic.Enabled = True
    End Sub

    Private Sub R_Polski_MouseHover(sender As Object, e As EventArgs) Handles R_Polski.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_Polski, "Zmień język na Polski")
            Case "en"
        End Select







    End Sub

    Private Sub L_Pic_Polski_Click(sender As Object, e As EventArgs) Handles L_Pic_Polski.Click

    End Sub

    Private Sub L_Pic_Polski_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Polski.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Polski, "Zmień język na Polski")
            Case "en"
        End Select
    End Sub

    Private Sub R_English_MouseHover(sender As Object, e As EventArgs) Handles R_English.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_English, "Zmień na język angielski")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pick_English_Click(sender As Object, e As EventArgs) Handles L_Pick_English.Click

    End Sub

    Private Sub L_Pick_English_MouseHover(sender As Object, e As EventArgs) Handles L_Pick_English.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pick_English, "Zmień na język angielski")
            Case "en"
        End Select
    End Sub

    Private Sub Check_Duplicates_MouseHover(sender As Object, e As EventArgs) Handles Check_Duplicates.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(Check_Duplicates, "Włączenie opcji pozwala na tworzenie kilku osobnych plików do tej samej przesyłki. Np. z różnymi WZ'tkami." & vbLf &
                    "Wszystkie pliki z tym samym numerem zostaną zapisane jako osobne pliki wraz z numeracją. " & vbLf & vbLf &
                " Wyłączenie tej opcji spowoduje pokazanie się błedu w przypadku, gdy pojawi się więcej plików z tym samym, rozpoznanym numerem. ")
            Case "en"
        End Select
    End Sub

    Private Sub Check_Rename_MouseHover(sender As Object, e As EventArgs) Handles Check_Rename.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(Check_Rename, "Włączenie opcji Pracuj na kopiach spowoduje tworzenie plików w nowej, 
                wybranej lokalizacji zamiast nadpisywania istniejących")
            Case "en"
        End Select
    End Sub

    Private Sub L_PIC_Rename_Click(sender As Object, e As EventArgs) Handles L_PIC_Rename.Click

    End Sub

    Private Sub L_PIC_Rename_MouseHover(sender As Object, e As EventArgs) Handles L_PIC_Rename.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_PIC_Rename, "Włączenie opcji Pracuj na kopiach spowoduje tworzenie plików w nowej, 
                wybranej lokalizacji zamiast nadpisywania istniejących")
            Case "en"
        End Select

    End Sub

    Private Sub Check_Check_MouseHover(sender As Object, e As EventArgs) Handles Check_Check.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(Check_Check, "Włączona opcja to dodatkowe sprawdzanie pliku PDF. Jeśli w danym pliku algorytm
                nie znajdzie wybranego ciągu znaków, nie przetworzy go. ")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Check_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Check.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Check, "Włączona opcja to dodatkowe sprawdzanie pliku PDF. Jeśli w danym pliku algorytm
                nie znajdzie wybranego ciągu znaków, nie przetworzy go. ")
            Case "en"
        End Select
    End Sub

    Private Sub CheckAutomatyzacja_MouseHover(sender As Object, e As EventArgs) Handles CheckAutomatyzacja.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(CheckAutomatyzacja, "Włączenie automatycznego przetwarzania plików bez konieczności manualnej pracy użytkownika. ")
            Case "en"
        End Select
    End Sub

    Private Sub L_PIC_Auto_Click(sender As Object, e As EventArgs) Handles L_PIC_Auto.Click

    End Sub

    Private Sub L_PIC_Auto_MouseHover(sender As Object, e As EventArgs) Handles L_PIC_Auto.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_PIC_Auto, "Włączenie automatycznego przetwarzania plików bez konieczności manualnej pracy użytkownika. ")
            Case "en"
        End Select
    End Sub

    Private Sub Check_Process_File_MouseHover(sender As Object, e As EventArgs) Handles Check_Process_File.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(Check_Process_File, "Procesuj całe pliki bez dzielenia. Wynikiem operacji będzie zawsze jeden plik. 
                Jeśli wyłączymy tą opcję program będzie dzielić plik PDF na strony według zadanych ustawień.")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Half_PDF_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Half_PDF.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Half_PDF, "Wynikiem działania programu będzie wybrana połowa pliku PDF")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pick_Process_File_Click(sender As Object, e As EventArgs) Handles L_Pick_Process_File.Click

    End Sub

    Private Sub L_Pick_Process_File_MouseHover(sender As Object, e As EventArgs) Handles L_Pick_Process_File.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pick_Process_File, "Procesuj całe pliki bez dzielenia. Wynikiem operacji będzie zawsze jeden plik. 
                Jeśli wyłączymy tą opcję program będzie dzielić plik PDF na strony według zadanych ustawień.")
            Case "en"
        End Select
    End Sub

    Private Sub R_Half_PDF_MouseHover(sender As Object, e As EventArgs) Handles R_Half_PDF.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_Half_PDF, "Wynikiem działania programu będzie wybrana połowa pliku PDF")
            Case "en"
        End Select
    End Sub

    Private Sub R_Pages_MouseHover(sender As Object, e As EventArgs) Handles R_Pages.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_Pages, "Wynikiem działania programu będzią tylko te strony z pliku PDF, które zawieraja lub niezawierają wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Pages_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Pages.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Pages, "Wynikiem działania programu będzą tylko te strony z pliku PDF, które zawieraja lub niezawierają wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub L_Polowa1_MouseHover(sender As Object, e As EventArgs) Handles L_Polowa1.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Polowa1, "Wynikiem działania programu będzie pierwsza połowa pliku PDF")
            Case "en"
        End Select
    End Sub

    Private Sub L_Polowa2_MouseHover(sender As Object, e As EventArgs) Handles L_Polowa2.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Polowa1, "Wynikiem działania programu będzie druga połowa pliku PDF")
            Case "en"
        End Select
    End Sub

    Private Sub R_Contain_MouseHover(sender As Object, e As EventArgs) Handles R_Contain.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_Contain, "Wynikiem działania programu będzą tylko te strony z pliku PDF, które zawieraja wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Contain_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Contain.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Contain, "Wynikiem działania programu będzą tylko te strony z pliku PDF, które zawieraja wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub R_Not_Contain_MouseHover(sender As Object, e As EventArgs) Handles R_Not_Contain.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(R_Not_Contain, "Wynikiem działania programu będzą tylko te strony z pliku PDF, które nie zawieraja wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Not_Contain_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Not_Contain.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Not_Contain, "Wynikiem działania programu będzą tylko te strony z pliku PDF, które nie zawieraja wskazany ciąg znaków")
            Case "en"
        End Select
    End Sub

    Private Sub C_Group_Pages_MouseHover(sender As Object, e As EventArgs) Handles C_Group_Pages.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(C_Group_Pages, "Włączenie tej opcji spowoduje grupowanie stron zawierających lub niezawierających wybrany ciąg znaków w jeden plik. Wyłączona opcja spwooduje, że każda strona zostanie zapisana jako osobny plik pdf")
            Case "en"
        End Select
    End Sub

    Private Sub L_Pic_Group_Pages_Click(sender As Object, e As EventArgs) Handles L_Pic_Group_Pages.Click

    End Sub

    Private Sub L_Pic_Group_Pages_MouseHover(sender As Object, e As EventArgs) Handles L_Pic_Group_Pages.MouseHover
        Select Case Jezyk
            Case "pl"
                ToolTip1.SetToolTip(L_Pic_Group_Pages, "Włączenie tej opcji spowoduje grupowanie stron zawierających lub niezawierających wybrany ciąg znaków w jeden plik. Wyłączona opcja spwooduje, że każda strona zostanie zapisana jako osobny plik pdf")
            Case "en"
        End Select
    End Sub
End Class