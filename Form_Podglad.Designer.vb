<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Podglad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Podglad))
        Me.Rich_Podglad = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Rich_Podglad
        '
        Me.Rich_Podglad.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Rich_Podglad.Location = New System.Drawing.Point(0, 0)
        Me.Rich_Podglad.Name = "Rich_Podglad"
        Me.Rich_Podglad.Size = New System.Drawing.Size(800, 450)
        Me.Rich_Podglad.TabIndex = 2
        Me.Rich_Podglad.Text = ""
        '
        'Form_Podglad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.Rich_Podglad)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form_Podglad"
        Me.Text = "Podgląd pliku PDF"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Rich_Podglad As RichTextBox
End Class
