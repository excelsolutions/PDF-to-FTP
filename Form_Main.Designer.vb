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
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Pic_Lista = New System.Windows.Forms.PictureBox()
        Me.L_LIczba_Plikow = New System.Windows.Forms.Label()
        Me.LL_Ilosc_plikow = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.L_Current_Interval = New System.Windows.Forms.Label()
        Me.L_Count_Loops = New System.Windows.Forms.Label()
        Me.L_Count_Files = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Btn_Save = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer_PIC = New System.Windows.Forms.Timer(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripAutomation = New System.Windows.Forms.ToolStripSplitButton()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripError = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripHide = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripDisableRefreshing = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Timer_Automat = New System.Windows.Forms.Timer(Me.components)
        Me.MenuStrip1.SuspendLayout()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Pic_Lista, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Start
        '
        Me.Btn_Start.Location = New System.Drawing.Point(213, 19)
        Me.Btn_Start.Name = "Btn_Start"
        Me.Btn_Start.Size = New System.Drawing.Size(97, 37)
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
        Me.MenuStrip1.Size = New System.Drawing.Size(419, 24)
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
        Me.UstawieniaToolStripMenuItem1.Size = New System.Drawing.Size(135, 22)
        Me.UstawieniaToolStripMenuItem1.Text = "Preferences"
        '
        'WyjścieToolStripMenuItem
        '
        Me.WyjścieToolStripMenuItem.Name = "WyjścieToolStripMenuItem"
        Me.WyjścieToolStripMenuItem.Size = New System.Drawing.Size(135, 22)
        Me.WyjścieToolStripMenuItem.Text = "Exit"
        '
        'PomocToolStripMenuItem1
        '
        Me.PomocToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LicencjaToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.OProgramieToolStripMenuItem1})
        Me.PomocToolStripMenuItem1.Name = "PomocToolStripMenuItem1"
        Me.PomocToolStripMenuItem1.Size = New System.Drawing.Size(44, 20)
        Me.PomocToolStripMenuItem1.Text = "Help"
        '
        'LicencjaToolStripMenuItem
        '
        Me.LicencjaToolStripMenuItem.Name = "LicencjaToolStripMenuItem"
        Me.LicencjaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LicencjaToolStripMenuItem.Text = "Licence"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.UpdateToolStripMenuItem.Text = "Update"
        '
        'OProgramieToolStripMenuItem1
        '
        Me.OProgramieToolStripMenuItem1.Name = "OProgramieToolStripMenuItem1"
        Me.OProgramieToolStripMenuItem1.Size = New System.Drawing.Size(156, 22)
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
        Me.Timer_Checker.Interval = 3000
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
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(159, 70)
        '
        'ToolStripMenuOtworz
        '
        Me.ToolStripMenuOtworz.Name = "ToolStripMenuOtworz"
        Me.ToolStripMenuOtworz.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuOtworz.Text = "Open program"
        '
        'ToolStripMenuPrzeslij
        '
        Me.ToolStripMenuPrzeslij.Name = "ToolStripMenuPrzeslij"
        Me.ToolStripMenuPrzeslij.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuPrzeslij.Text = "Sent files to FTP"
        '
        'ToolStripMenuZamknij
        '
        Me.ToolStripMenuZamknij.Name = "ToolStripMenuZamknij"
        Me.ToolStripMenuZamknij.Size = New System.Drawing.Size(158, 22)
        Me.ToolStripMenuZamknij.Text = "Close program"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.L_Current_Interval)
        Me.GroupBox1.Controls.Add(Me.L_Count_Loops)
        Me.GroupBox1.Controls.Add(Me.L_Count_Files)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Btn_Save)
        Me.GroupBox1.Controls.Add(Me.Btn_Start)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 24)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(419, 91)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Pic_Lista)
        Me.Panel1.Controls.Add(Me.L_LIczba_Plikow)
        Me.Panel1.Controls.Add(Me.LL_Ilosc_plikow)
        Me.Panel1.Location = New System.Drawing.Point(12, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(183, 57)
        Me.Panel1.TabIndex = 34
        '
        'Pic_Lista
        '
        Me.Pic_Lista.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pic_Lista.Image = Global.PDF_Reader.My.Resources.Resources.Lista
        Me.Pic_Lista.Location = New System.Drawing.Point(8, 6)
        Me.Pic_Lista.Name = "Pic_Lista"
        Me.Pic_Lista.Size = New System.Drawing.Size(34, 46)
        Me.Pic_Lista.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_Lista.TabIndex = 2
        Me.Pic_Lista.TabStop = False
        '
        'L_LIczba_Plikow
        '
        Me.L_LIczba_Plikow.AutoSize = True
        Me.L_LIczba_Plikow.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_LIczba_Plikow.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.L_LIczba_Plikow.ForeColor = System.Drawing.Color.Blue
        Me.L_LIczba_Plikow.Location = New System.Drawing.Point(55, 3)
        Me.L_LIczba_Plikow.Name = "L_LIczba_Plikow"
        Me.L_LIczba_Plikow.Size = New System.Drawing.Size(29, 31)
        Me.L_LIczba_Plikow.TabIndex = 1
        Me.L_LIczba_Plikow.Text = "0"
        Me.L_LIczba_Plikow.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'LL_Ilosc_plikow
        '
        Me.LL_Ilosc_plikow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.LL_Ilosc_plikow.Location = New System.Drawing.Point(58, 34)
        Me.LL_Ilosc_plikow.Name = "LL_Ilosc_plikow"
        Me.LL_Ilosc_plikow.Size = New System.Drawing.Size(115, 18)
        Me.LL_Ilosc_plikow.TabIndex = 0
        Me.LL_Ilosc_plikow.Text = "count of files in folder"
        Me.LL_Ilosc_plikow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DimGray
        Me.Label4.Location = New System.Drawing.Point(1, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Auto:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomRight
        '
        'L_Current_Interval
        '
        Me.L_Current_Interval.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.L_Current_Interval.ForeColor = System.Drawing.Color.DimGray
        Me.L_Current_Interval.Location = New System.Drawing.Point(360, 73)
        Me.L_Current_Interval.Name = "L_Current_Interval"
        Me.L_Current_Interval.Size = New System.Drawing.Size(50, 15)
        Me.L_Current_Interval.TabIndex = 29
        Me.L_Current_Interval.Text = "0"
        '
        'L_Count_Loops
        '
        Me.L_Count_Loops.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.L_Count_Loops.ForeColor = System.Drawing.Color.DimGray
        Me.L_Count_Loops.Location = New System.Drawing.Point(230, 73)
        Me.L_Count_Loops.Name = "L_Count_Loops"
        Me.L_Count_Loops.Size = New System.Drawing.Size(69, 15)
        Me.L_Count_Loops.TabIndex = 28
        Me.L_Count_Loops.Text = "0"
        '
        'L_Count_Files
        '
        Me.L_Count_Files.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.L_Count_Files.ForeColor = System.Drawing.Color.DimGray
        Me.L_Count_Files.Location = New System.Drawing.Point(129, 73)
        Me.L_Count_Files.Name = "L_Count_Files"
        Me.L_Count_Files.Size = New System.Drawing.Size(50, 15)
        Me.L_Count_Files.TabIndex = 27
        Me.L_Count_Files.Text = "0"
        '
        'Label3
        '
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.ForeColor = System.Drawing.Color.DimGray
        Me.Label3.Location = New System.Drawing.Point(302, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 15)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "Interval"
        '
        'Label2
        '
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(185, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Loops"
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(39, 73)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Processed files"
        '
        'Btn_Save
        '
        Me.Btn_Save.Location = New System.Drawing.Point(316, 19)
        Me.Btn_Save.Name = "Btn_Save"
        Me.Btn_Save.Size = New System.Drawing.Size(97, 37)
        Me.Btn_Save.TabIndex = 20
        Me.Btn_Save.Text = "Save files"
        Me.Btn_Save.UseVisualStyleBackColor = True
        '
        'ToolTip1
        '
        '
        'Timer_PIC
        '
        Me.Timer_PIC.Interval = 500
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripAutomation, Me.ToolStripStatusLabel1, Me.ToolStripError, Me.ToolStripHide, Me.ToolStripDisableRefreshing})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 116)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.StatusStrip1.Size = New System.Drawing.Size(419, 24)
        Me.StatusStrip1.TabIndex = 22
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripAutomation
        '
        Me.ToolStripAutomation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripAutomation.Image = Global.PDF_Reader.My.Resources.Resources.Red_Button
        Me.ToolStripAutomation.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripAutomation.Name = "ToolStripAutomation"
        Me.ToolStripAutomation.Size = New System.Drawing.Size(32, 22)
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(74, 19)
        Me.ToolStripStatusLabel1.Text = "Automation:"
        '
        'ToolStripError
        '
        Me.ToolStripError.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.ToolStripError.ForeColor = System.Drawing.Color.Green
        Me.ToolStripError.Name = "ToolStripError"
        Me.ToolStripError.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ToolStripError.Size = New System.Drawing.Size(21, 19)
        Me.ToolStripError.Text = "ok"
        '
        'ToolStripHide
        '
        Me.ToolStripHide.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripHide.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripHide.Name = "ToolStripHide"
        Me.ToolStripHide.Size = New System.Drawing.Size(36, 19)
        Me.ToolStripHide.Text = "Hide"
        Me.ToolStripHide.ToolTipText = "Hide program"
        '
        'ToolStripDisableRefreshing
        '
        Me.ToolStripDisableRefreshing.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripDisableRefreshing.BorderStyle = System.Windows.Forms.Border3DStyle.Raised
        Me.ToolStripDisableRefreshing.Name = "ToolStripDisableRefreshing"
        Me.ToolStripDisableRefreshing.Size = New System.Drawing.Size(63, 19)
        Me.ToolStripDisableRefreshing.Text = "Check On"
        Me.ToolStripDisableRefreshing.ToolTipText = "Hide program"
        '
        'Timer_Automat
        '
        Me.Timer_Automat.Interval = 10000
        '
        'Form_Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(419, 140)
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
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Pic_Lista, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents PlikToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UstawieniaToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents WyjścieToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents PomocToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents OProgramieToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Timer_PIC As Timer
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents LicencjaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Btn_Save As Button
    Friend WithEvents UpdateToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripAutomation As ToolStripSplitButton
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents Timer_Automat As Timer
    Friend WithEvents ToolStripError As ToolStripStatusLabel
    Friend WithEvents L_Current_Interval As Label
    Friend WithEvents L_Count_Loops As Label
    Friend WithEvents L_Count_Files As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ToolStripHide As ToolStripStatusLabel
    Friend WithEvents ToolStripDisableRefreshing As ToolStripStatusLabel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Pic_Lista As PictureBox
End Class
