<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Locked
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.cmd_resetpw = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.browser = New System.Windows.Forms.WebBrowser()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'cmd_resetpw
        '
        Me.cmd_resetpw.Location = New System.Drawing.Point(155, 292)
        Me.cmd_resetpw.Name = "cmd_resetpw"
        Me.cmd_resetpw.Size = New System.Drawing.Size(224, 29)
        Me.cmd_resetpw.TabIndex = 0
        Me.cmd_resetpw.Text = "Reset Password"
        Me.cmd_resetpw.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(197, 93)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Enter Password to Unlock"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(155, 109)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TextBox1.Size = New System.Drawing.Size(224, 20)
        Me.TextBox1.TabIndex = 2
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(452, 234)
        Me.browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(63, 32)
        Me.browser.TabIndex = 3
        Me.browser.Visible = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(155, 135)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(223, 24)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Unlock Screen"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'Locked
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.ClientSize = New System.Drawing.Size(557, 371)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.browser)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmd_resetpw)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Locked"
        Me.Text = "Locked"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmd_resetpw As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents browser As WebBrowser
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
End Class
