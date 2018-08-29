<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form_Main
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Main))
        Me.Btn_Start = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Wybor_Folderu = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.PlikToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UstawieniaToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.WyjścieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PomocToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.LicencjaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OProgramieToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProgramToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UstawieniaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.WyjdźToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PomocToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OProgramieToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Timer_Checker = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolStripMenuOtworz = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuPrzeslij = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuZamknij = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.L_Blad_FTP = New System.Windows.Forms.Label()
        Me.L_Blad_Folder = New System.Windows.Forms.Label()
        Me.L_PIC_FTP = New System.Windows.Forms.Label()
        Me.L_PIC_Folder = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LL_Ilosc_plikow = New System.Windows.Forms.Label()
        Me.L_LIczba_Plikow = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer_PIC = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatus_PIC = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatus_PIC_Napis = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Start
        '
        Me.Btn_Start.Location = New System.Drawing.Point(461, 17)
        Me.Btn_Start.Name = "Btn_Start"
        Me.Btn_Start.Size = New System.Drawing.Size(150, 37)
        Me.Btn_Start.TabIndex = 0
        Me.Btn_Start.Text = "Send files to FTP"
        Me.Btn_Start.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.PlikToolStripMenuItem, Me.PomocToolStripMenuItem1})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(619, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'PlikToolStripMenuItem
        '
        Me.PlikToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UstawieniaToolStripMenuItem1, Me.WyjścieToolStripMenuItem})
        Me.PlikToolStripMenuItem.Name = "PlikToolStripMenuItem"
        Me.PlikToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.PlikToolStripMenuItem.Text = "File"
        '
        'UstawieniaToolStripMenuItem1
        '
        Me.UstawieniaToolStripMenuItem1.Name = "UstawieniaToolStripMenuItem1"
        Me.UstawieniaToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.UstawieniaToolStripMenuItem1.Text = "Preferences"
        '
        'WyjścieToolStripMenuItem
        '
        Me.WyjścieToolStripMenuItem.Name = "WyjścieToolStripMenuItem"
        Me.WyjścieToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.WyjścieToolStripMenuItem.Text = "Exit"
        '
        'PomocToolStripMenuItem1
        '
        Me.PomocToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LicencjaToolStripMenuItem, Me.OProgramieToolStripMenuItem1})
        Me.PomocToolStripMenuItem1.Name = "PomocToolStripMenuItem1"
        Me.PomocToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.PomocToolStripMenuItem1.Text = "Help"
        '
        'LicencjaToolStripMenuItem
        '
        Me.LicencjaToolStripMenuItem.Name = "LicencjaToolStripMenuItem"
        Me.LicencjaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.LicencjaToolStripMenuItem.Text = "Licence"
        '
        'OProgramieToolStripMenuItem1
        '
        Me.OProgramieToolStripMenuItem1.Name = "OProgramieToolStripMenuItem1"
        Me.OProgramieToolStripMenuItem1.Size = New System.Drawing.Size(180, 22)
        Me.OProgramieToolStripMenuItem1.Text = "About program"
        '
        'ProgramToolStripMenuItem
        '
        Me.ProgramToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UstawieniaToolStripMenuItem, Me.WyjdźToolStripMenuItem})
        Me.ProgramToolStripMenuItem.Name = "ProgramToolStripMenuItem"
        Me.ProgramToolStripMenuItem.Size = New System.Drawing.Size(65, 20)
        Me.ProgramToolStripMenuItem.Text = "Program"
        '
        'UstawieniaToolStripMenuItem
        '
        Me.UstawieniaToolStripMenuItem.Name = "UstawieniaToolStripMenuItem"
        Me.UstawieniaToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.UstawieniaToolStripMenuItem.Text = "Ustawienia"
        '
        'WyjdźToolStripMenuItem
        '
        Me.WyjdźToolStripMenuItem.Name = "WyjdźToolStripMenuItem"
        Me.WyjdźToolStripMenuItem.Size = New System.Drawing.Size(131, 22)
        Me.WyjdźToolStripMenuItem.Text = "Wyjdź"
        '
        'PomocToolStripMenuItem
        '
        Me.PomocToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OProgramieToolStripMenuItem})
        Me.PomocToolStripMenuItem.Name = "PomocToolStripMenuItem"
        Me.PomocToolStripMenuItem.Size = New System.Drawing.Size(57, 20)
        Me.PomocToolStripMenuItem.Text = "Pomoc"
        '
        'OProgramieToolStripMenuItem
        '
        Me.OProgramieToolStripMenuItem.Name = "OProgramieToolStripMenuItem"
        Me.OProgramieToolStripMenuItem.Size = New System.Drawing.Size(141, 22)
        Me.OProgramieToolStripMenuItem.Text = "O programie"
        '
        'Timer_Checker
        '
        Me.Timer_Checker.Enabled = True
        Me.Timer_Checker.Interval = 1000
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Text = "PDF --->FTP"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuOtworz, Me.ToolStripMenuPrzeslij, Me.ToolStripMenuZamknij})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(175, 70)
        '
        'ToolStripMenuOtworz
        '
        Me.ToolStripMenuOtworz.Name = "ToolStripMenuOtworz"
        Me.ToolStripMenuOtworz.Size = New System.Drawing.Size(174, 22)
        Me.ToolStripMenuOtworz.Text = "Otwórz program"
        '
        'ToolStripMenuPrzeslij
        '
        Me.ToolStripMenuPrzeslij.Name = "ToolStripMenuPrzeslij"
        Me.ToolStripMenuPrzeslij.Size = New System.Drawing.Size(174, 22)
        Me.ToolStripMenuPrzeslij.Text = "Prześlij pliki na FTP"
        '
        'ToolStripMenuZamknij
        '
        Me.ToolStripMenuZamknij.Name = "ToolStripMenuZamknij"
        Me.ToolStripMenuZamknij.Size = New System.Drawing.Size(174, 22)
        Me.ToolStripMenuZamknij.Text = "Zamknij program"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.L_Blad_FTP)
        Me.GroupBox1.Controls.Add(Me.L_Blad_Folder)
        Me.GroupBox1.Controls.Add(Me.L_PIC_FTP)
        Me.GroupBox1.Controls.Add(Me.L_PIC_Folder)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Btn_Start)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.LL_Ilosc_plikow)
        Me.GroupBox1.Controls.Add(Me.L_LIczba_Plikow)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(619, 69)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'L_Blad_FTP
        '
        Me.L_Blad_FTP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_Blad_FTP.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.L_Blad_FTP.ForeColor = System.Drawing.Color.Red
        Me.L_Blad_FTP.Location = New System.Drawing.Point(400, 41)
        Me.L_Blad_FTP.Name = "L_Blad_FTP"
        Me.L_Blad_FTP.Size = New System.Drawing.Size(55, 19)
        Me.L_Blad_FTP.TabIndex = 19
        Me.L_Blad_FTP.Text = "Error: chech path"
        Me.L_Blad_FTP.Visible = False
        '
        'L_Blad_Folder
        '
        Me.L_Blad_Folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_Blad_Folder.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.L_Blad_Folder.ForeColor = System.Drawing.Color.Red
        Me.L_Blad_Folder.Location = New System.Drawing.Point(400, 17)
        Me.L_Blad_Folder.Name = "L_Blad_Folder"
        Me.L_Blad_Folder.Size = New System.Drawing.Size(55, 24)
        Me.L_Blad_Folder.TabIndex = 18
        Me.L_Blad_Folder.Text = "Error: chech path"
        Me.L_Blad_Folder.Visible = False
        '
        'L_PIC_FTP
        '
        Me.L_PIC_FTP.BackColor = System.Drawing.Color.Red
        Me.L_PIC_FTP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_PIC_FTP.Location = New System.Drawing.Point(381, 43)
        Me.L_PIC_FTP.Name = "L_PIC_FTP"
        Me.L_PIC_FTP.Size = New System.Drawing.Size(13, 14)
        Me.L_PIC_FTP.TabIndex = 17
        '
        'L_PIC_Folder
        '
        Me.L_PIC_Folder.BackColor = System.Drawing.Color.Red
        Me.L_PIC_Folder.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_PIC_Folder.Location = New System.Drawing.Point(381, 19)
        Me.L_PIC_Folder.Name = "L_PIC_Folder"
        Me.L_PIC_Folder.Size = New System.Drawing.Size(13, 14)
        Me.L_PIC_Folder.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label3.Location = New System.Drawing.Point(327, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "HDD"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label1.Location = New System.Drawing.Point(327, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(34, 16)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "FTP"
        '
        'LL_Ilosc_plikow
        '
        Me.LL_Ilosc_plikow.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LL_Ilosc_plikow.Location = New System.Drawing.Point(10, 17)
        Me.LL_Ilosc_plikow.Name = "LL_Ilosc_plikow"
        Me.LL_Ilosc_plikow.Size = New System.Drawing.Size(236, 37)
        Me.LL_Ilosc_plikow.TabIndex = 0
        Me.LL_Ilosc_plikow.Text = "count of files in folder:"
        Me.LL_Ilosc_plikow.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'L_LIczba_Plikow
        '
        Me.L_LIczba_Plikow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_LIczba_Plikow.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.L_LIczba_Plikow.ForeColor = System.Drawing.Color.Blue
        Me.L_LIczba_Plikow.Location = New System.Drawing.Point(252, 18)
        Me.L_LIczba_Plikow.Name = "L_LIczba_Plikow"
        Me.L_LIczba_Plikow.Size = New System.Drawing.Size(66, 37)
        Me.L_LIczba_Plikow.TabIndex = 1
        Me.L_LIczba_Plikow.Text = "0"
        Me.L_LIczba_Plikow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Timer_PIC
        '
        Me.Timer_PIC.Interval = 500
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatus_PIC, Me.ToolStripStatus_PIC_Napis})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 95)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(619, 22)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatus_PIC
        '
        Me.ToolStripStatus_PIC.AutoSize = False
        Me.ToolStripStatus_PIC.Font = New System.Drawing.Font("Wingdings", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.ToolStripStatus_PIC.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatus_PIC.Name = "ToolStripStatus_PIC"
        Me.ToolStripStatus_PIC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatus_PIC.Size = New System.Drawing.Size(52, 17)
        Me.ToolStripStatus_PIC.Text = "lllll"
        Me.ToolStripStatus_PIC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatus_PIC_Napis
        '
        Me.ToolStripStatus_PIC_Napis.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripStatus_PIC_Napis.ForeColor = System.Drawing.Color.Red
        Me.ToolStripStatus_PIC_Napis.Name = "ToolStripStatus_PIC_Napis"
        Me.ToolStripStatus_PIC_Napis.Size = New System.Drawing.Size(139, 17)
        Me.ToolStripStatus_PIC_Napis.Text = "No connection with FTP"
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 117)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form_Main"
        Me.Text = "PDF ---> FTP"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Btn_Start As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Wybor_Folderu As FolderBrowserDialog
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ProgramToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WyjdźToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PomocToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents OProgramieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Timer_Checker As Timer
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents ToolStripMenuOtworz As ToolStripMenuItem
    Friend WithEvents ToolStripMenuPrzeslij As ToolStripMenuItem
    Friend WithEvents ToolStripMenuZamknij As ToolStripMenuItem
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents L_LIczba_Plikow As Label
    Friend WithEvents LL_Ilosc_plikow As Label
    Friend WithEvents UstawieniaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents L_PIC_FTP As Label
    Friend WithEvents L_PIC_Folder As Label
    Friend WithEvents L_Blad_Folder As Label
    Friend WithEvents L_Blad_FTP As Label
    Friend WithEvents PlikToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UstawieniaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WyjścieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PomocToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OProgramieToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer_PIC As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatus_PIC As ToolStripStatusLabel
    Friend WithEvents ToolStripStatus_PIC_Napis As ToolStripStatusLabel
    Friend WithEvents LicencjaToolStripMenuItem As ToolStripMenuItem
End Class
