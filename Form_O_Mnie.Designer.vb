<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_O_Mnie
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_O_Mnie))
        Me.Btn_Zamknij = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.L_Wersja = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkWWW = New System.Windows.Forms.LinkLabel()
        Me.LinkMail = New System.Windows.Forms.LinkLabel()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Zamknij
        '
        Me.Btn_Zamknij.Location = New System.Drawing.Point(42, 266)
        Me.Btn_Zamknij.Name = "Btn_Zamknij"
        Me.Btn_Zamknij.Size = New System.Drawing.Size(165, 35)
        Me.Btn_Zamknij.TabIndex = 0
        Me.Btn_Zamknij.Text = "Close"
        Me.Btn_Zamknij.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "mail:"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 52)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Program for changing names of pdf according to string from inside of pdf file. Pr" &
    "ogram can also send changed pdf file to FTP."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 71)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "About program"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LinkMail)
        Me.GroupBox2.Controls.Add(Me.LinkWWW)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 137)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 123)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.L_Wersja)
        Me.GroupBox3.Location = New System.Drawing.Point(13, 83)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(201, 48)
        Me.GroupBox3.TabIndex = 14
        Me.GroupBox3.TabStop = False
        '
        'L_Wersja
        '
        Me.L_Wersja.Cursor = System.Windows.Forms.Cursors.Hand
        Me.L_Wersja.Dock = System.Windows.Forms.DockStyle.Fill
        Me.L_Wersja.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.L_Wersja.ForeColor = System.Drawing.Color.Blue
        Me.L_Wersja.Location = New System.Drawing.Point(3, 16)
        Me.L_Wersja.Name = "L_Wersja"
        Me.L_Wersja.Size = New System.Drawing.Size(195, 29)
        Me.L_Wersja.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "www:"
        '
        'LinkWWW
        '
        Me.LinkWWW.AutoSize = True
        Me.LinkWWW.Location = New System.Drawing.Point(47, 100)
        Me.LinkWWW.Name = "LinkWWW"
        Me.LinkWWW.Size = New System.Drawing.Size(111, 13)
        Me.LinkWWW.TabIndex = 7
        Me.LinkWWW.TabStop = True
        Me.LinkWWW.Text = "www.excelsolutions.pl"
        '
        'LinkMail
        '
        Me.LinkMail.AutoSize = True
        Me.LinkMail.Location = New System.Drawing.Point(47, 27)
        Me.LinkMail.Name = "LinkMail"
        Me.LinkMail.Size = New System.Drawing.Size(148, 13)
        Me.LinkMail.TabIndex = 3
        Me.LinkMail.TabStop = True
        Me.LinkMail.Text = "lukasz.r.morawski@gmail.com"
        '
        'Form_O_Mnie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(227, 316)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Btn_Zamknij)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_O_Mnie"
        Me.Text = "About program"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Zamknij As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents L_Wersja As Label
    Friend WithEvents LinkMail As LinkLabel
    Friend WithEvents LinkWWW As LinkLabel
    Friend WithEvents Label3 As Label
End Class
