﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.LinkMail = New System.Windows.Forms.LinkLabel()
        Me.LinkSkype = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.LinkWWW = New System.Windows.Forms.LinkLabel()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LinkTel = New System.Windows.Forms.LinkLabel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Btn_Zamknij
        '
        Me.Btn_Zamknij.Location = New System.Drawing.Point(257, 232)
        Me.Btn_Zamknij.Name = "Btn_Zamknij"
        Me.Btn_Zamknij.Size = New System.Drawing.Size(165, 35)
        Me.Btn_Zamknij.TabIndex = 0
        Me.Btn_Zamknij.Text = "Close"
        Me.Btn_Zamknij.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.PDF_Reader.My.Resources.Resources.P1080372
        Me.PictureBox1.Location = New System.Drawing.Point(-13, -1)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(224, 278)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "e-mail:"
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
        'LinkSkype
        '
        Me.LinkSkype.AutoSize = True
        Me.LinkSkype.LinkColor = System.Drawing.Color.Black
        Me.LinkSkype.Location = New System.Drawing.Point(47, 76)
        Me.LinkSkype.Name = "LinkSkype"
        Me.LinkSkype.Size = New System.Drawing.Size(150, 13)
        Me.LinkSkype.TabIndex = 5
        Me.LinkSkype.TabStop = True
        Me.LinkSkype.Text = "lukaszmorawski@outlook.com"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 76)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "skype:"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "www:"
        '
        'LinkTel
        '
        Me.LinkTel.AutoSize = True
        Me.LinkTel.LinkColor = System.Drawing.Color.Black
        Me.LinkTel.Location = New System.Drawing.Point(47, 51)
        Me.LinkTel.Name = "LinkTel"
        Me.LinkTel.Size = New System.Drawing.Size(67, 13)
        Me.LinkTel.TabIndex = 9
        Me.LinkTel.TabStop = True
        Me.LinkTel.Text = "792-792-211"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "tel:"
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Location = New System.Drawing.Point(3, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(195, 52)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Program do zmiany nazw plików PDF na podstawie ich treści oraz ich wysyłania na w" &
    "skazany serwer FTP."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Location = New System.Drawing.Point(220, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 71)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "O programie"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LinkMail)
        Me.GroupBox2.Controls.Add(Me.LinkTel)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.LinkSkype)
        Me.GroupBox2.Controls.Add(Me.LinkWWW)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(220, 89)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(201, 137)
        Me.GroupBox2.TabIndex = 13
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Kontakt z autorem"
        '
        'Form_O_Mnie
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 273)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Btn_Zamknij)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_O_Mnie"
        Me.Text = "About program"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Btn_Zamknij As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents LinkMail As LinkLabel
    Friend WithEvents LinkSkype As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents LinkWWW As LinkLabel
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkTel As LinkLabel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
