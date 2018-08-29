<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Ustawienia
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Ustawienia))
        Me.Group_PDF = New System.Windows.Forms.GroupBox()
        Me.T_Sciezka_PDF = New System.Windows.Forms.TextBox()
        Me.Pic_PDF = New System.Windows.Forms.PictureBox()
        Me.Group_FTP = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.T_Sciezka_FTP = New System.Windows.Forms.TextBox()
        Me.T_Haslo = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Pic_FTP = New System.Windows.Forms.PictureBox()
        Me.T_Login = New System.Windows.Forms.TextBox()
        Me.Btn_Zapisz = New System.Windows.Forms.Button()
        Me.Btn_Anuluj = New System.Windows.Forms.Button()
        Me.Wybor_Folderu = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Group_PDF.SuspendLayout()
        CType(Me.Pic_PDF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Group_FTP.SuspendLayout()
        CType(Me.Pic_FTP, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Group_PDF
        '
        Me.Group_PDF.Controls.Add(Me.T_Sciezka_PDF)
        Me.Group_PDF.Controls.Add(Me.Pic_PDF)
        Me.Group_PDF.Location = New System.Drawing.Point(12, 12)
        Me.Group_PDF.Name = "Group_PDF"
        Me.Group_PDF.Size = New System.Drawing.Size(516, 78)
        Me.Group_PDF.TabIndex = 15
        Me.Group_PDF.TabStop = False
        Me.Group_PDF.Text = "Folder with PDF files"
        '
        'T_Sciezka_PDF
        '
        Me.T_Sciezka_PDF.Location = New System.Drawing.Point(6, 19)
        Me.T_Sciezka_PDF.Multiline = True
        Me.T_Sciezka_PDF.Name = "T_Sciezka_PDF"
        Me.T_Sciezka_PDF.Size = New System.Drawing.Size(449, 45)
        Me.T_Sciezka_PDF.TabIndex = 1
        '
        'Pic_PDF
        '
        Me.Pic_PDF.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pic_PDF.Image = Global.PDF_Reader.My.Resources.Resources.Folder
        Me.Pic_PDF.Location = New System.Drawing.Point(461, 19)
        Me.Pic_PDF.Name = "Pic_PDF"
        Me.Pic_PDF.Size = New System.Drawing.Size(43, 45)
        Me.Pic_PDF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_PDF.TabIndex = 6
        Me.Pic_PDF.TabStop = False
        '
        'Group_FTP
        '
        Me.Group_FTP.Controls.Add(Me.Label4)
        Me.Group_FTP.Controls.Add(Me.T_Sciezka_FTP)
        Me.Group_FTP.Controls.Add(Me.T_Haslo)
        Me.Group_FTP.Controls.Add(Me.Label1)
        Me.Group_FTP.Controls.Add(Me.Label3)
        Me.Group_FTP.Controls.Add(Me.Pic_FTP)
        Me.Group_FTP.Controls.Add(Me.T_Login)
        Me.Group_FTP.Location = New System.Drawing.Point(11, 96)
        Me.Group_FTP.Name = "Group_FTP"
        Me.Group_FTP.Size = New System.Drawing.Size(517, 67)
        Me.Group_FTP.TabIndex = 14
        Me.Group_FTP.TabStop = False
        Me.Group_FTP.Text = "FTP"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(367, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 18)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Password"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'T_Sciezka_FTP
        '
        Me.T_Sciezka_FTP.Location = New System.Drawing.Point(8, 37)
        Me.T_Sciezka_FTP.Name = "T_Sciezka_FTP"
        Me.T_Sciezka_FTP.Size = New System.Drawing.Size(196, 20)
        Me.T_Sciezka_FTP.TabIndex = 2
        '
        'T_Haslo
        '
        Me.T_Haslo.Location = New System.Drawing.Point(369, 37)
        Me.T_Haslo.Name = "T_Haslo"
        Me.T_Haslo.Size = New System.Drawing.Size(138, 20)
        Me.T_Haslo.TabIndex = 10
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(198, 18)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Address"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(253, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(108, 18)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Login"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Pic_FTP
        '
        Me.Pic_FTP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Pic_FTP.Image = Global.PDF_Reader.My.Resources.Resources.Folder
        Me.Pic_FTP.Location = New System.Drawing.Point(210, 37)
        Me.Pic_FTP.Name = "Pic_FTP"
        Me.Pic_FTP.Size = New System.Drawing.Size(21, 20)
        Me.Pic_FTP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Pic_FTP.TabIndex = 7
        Me.Pic_FTP.TabStop = False
        '
        'T_Login
        '
        Me.T_Login.Location = New System.Drawing.Point(255, 37)
        Me.T_Login.Name = "T_Login"
        Me.T_Login.Size = New System.Drawing.Size(106, 20)
        Me.T_Login.TabIndex = 8
        '
        'Btn_Zapisz
        '
        Me.Btn_Zapisz.Location = New System.Drawing.Point(378, 182)
        Me.Btn_Zapisz.Name = "Btn_Zapisz"
        Me.Btn_Zapisz.Size = New System.Drawing.Size(150, 37)
        Me.Btn_Zapisz.TabIndex = 16
        Me.Btn_Zapisz.Text = "Save"
        Me.Btn_Zapisz.UseVisualStyleBackColor = True
        '
        'Btn_Anuluj
        '
        Me.Btn_Anuluj.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Btn_Anuluj.Location = New System.Drawing.Point(12, 182)
        Me.Btn_Anuluj.Name = "Btn_Anuluj"
        Me.Btn_Anuluj.Size = New System.Drawing.Size(150, 37)
        Me.Btn_Anuluj.TabIndex = 17
        Me.Btn_Anuluj.Text = "Cancel"
        Me.Btn_Anuluj.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form_Ustawienia
        '
        Me.AcceptButton = Me.Btn_Zapisz
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.Btn_Anuluj
        Me.ClientSize = New System.Drawing.Size(535, 225)
        Me.Controls.Add(Me.Btn_Anuluj)
        Me.Controls.Add(Me.Btn_Zapisz)
        Me.Controls.Add(Me.Group_PDF)
        Me.Controls.Add(Me.Group_FTP)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form_Ustawienia"
        Me.Text = "Preferences"
        Me.Group_PDF.ResumeLayout(False)
        Me.Group_PDF.PerformLayout()
        CType(Me.Pic_PDF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Group_FTP.ResumeLayout(False)
        Me.Group_FTP.PerformLayout()
        CType(Me.Pic_FTP, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Group_PDF As GroupBox
    Friend WithEvents T_Sciezka_PDF As TextBox
    Friend WithEvents Pic_PDF As PictureBox
    Friend WithEvents Group_FTP As GroupBox
    Friend WithEvents Label4 As Label
    Friend WithEvents T_Sciezka_FTP As TextBox
    Friend WithEvents T_Haslo As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Pic_FTP As PictureBox
    Friend WithEvents T_Login As TextBox
    Friend WithEvents Btn_Zapisz As Button
    Friend WithEvents Btn_Anuluj As Button
    Friend WithEvents Wybor_Folderu As FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
End Class
