<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Locked
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Locked))
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ChTheme1 = New ScreenLock.CHTheme()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmd_unlock = New ScreenLock.CHButton()
        Me.cmd_resetpw = New ScreenLock.CHButton()
        Me.Textbox1 = New ScreenLock.CHTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.browser = New System.Windows.Forms.WebBrowser()
        Me.ChTheme1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 10
        '
        'ChTheme1
        '
        Me.ChTheme1.BackColor = System.Drawing.Color.Black
        Me.ChTheme1.BorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.ChTheme1.Controls.Add(Me.Panel1)
        Me.ChTheme1.Customization = "FxcX/wD/AP8="
        Me.ChTheme1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ChTheme1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!)
        Me.ChTheme1.Image = Nothing
        Me.ChTheme1.Location = New System.Drawing.Point(0, 0)
        Me.ChTheme1.Movable = True
        Me.ChTheme1.Name = "ChTheme1"
        Me.ChTheme1.NoRounding = False
        Me.ChTheme1.Sizable = False
        Me.ChTheme1.Size = New System.Drawing.Size(557, 371)
        Me.ChTheme1.SmartBounds = True
        Me.ChTheme1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.ChTheme1.TabIndex = 0
        Me.ChTheme1.Text = "ChTheme1"
        Me.ChTheme1.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChTheme1.Transparent = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cmd_unlock)
        Me.Panel1.Controls.Add(Me.cmd_resetpw)
        Me.Panel1.Controls.Add(Me.Textbox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.browser)
        Me.Panel1.Location = New System.Drawing.Point(25, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(510, 285)
        Me.Panel1.TabIndex = 12
        '
        'cmd_unlock
        '
        Me.cmd_unlock.Customization = "AGQA/wD/AP+Q7pD/"
        Me.cmd_unlock.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmd_unlock.Image = Nothing
        Me.cmd_unlock.Location = New System.Drawing.Point(138, 161)
        Me.cmd_unlock.Name = "cmd_unlock"
        Me.cmd_unlock.NoRounding = False
        Me.cmd_unlock.Size = New System.Drawing.Size(223, 26)
        Me.cmd_unlock.TabIndex = 11
        Me.cmd_unlock.Text = "Unlock"
        Me.cmd_unlock.Transparent = False
        '
        'cmd_resetpw
        '
        Me.cmd_resetpw.Customization = "AGQA/wD/AP+Q7pD/"
        Me.cmd_resetpw.Enabled = False
        Me.cmd_resetpw.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.cmd_resetpw.Image = Nothing
        Me.cmd_resetpw.Location = New System.Drawing.Point(138, 192)
        Me.cmd_resetpw.Name = "cmd_resetpw"
        Me.cmd_resetpw.NoRounding = False
        Me.cmd_resetpw.Size = New System.Drawing.Size(223, 26)
        Me.cmd_resetpw.TabIndex = 11
        Me.cmd_resetpw.Text = "Reset Password"
        Me.cmd_resetpw.Transparent = False
        Me.cmd_resetpw.Visible = False
        '
        'Textbox1
        '
        Me.Textbox1.BackColor = System.Drawing.Color.Transparent
        Me.Textbox1.Colors = New ScreenLock.Bloom(-1) {}
        Me.Textbox1.Customization = ""
        Me.Textbox1.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Textbox1.Image = Nothing
        Me.Textbox1.Location = New System.Drawing.Point(138, 133)
        Me.Textbox1.MaxCharacters = 0
        Me.Textbox1.Name = "Textbox1"
        Me.Textbox1.NoRounding = False
        Me.Textbox1.Size = New System.Drawing.Size(224, 25)
        Me.Textbox1.TabIndex = 9
        Me.Textbox1.Transparent = True
        Me.Textbox1.UsePasswordMask = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.Lime
        Me.Label1.Location = New System.Drawing.Point(176, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(147, 15)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Enter Password to Unlock"
        '
        'browser
        '
        Me.browser.Location = New System.Drawing.Point(417, 209)
        Me.browser.MinimumSize = New System.Drawing.Size(20, 20)
        Me.browser.Name = "browser"
        Me.browser.Size = New System.Drawing.Size(20, 20)
        Me.browser.TabIndex = 8
        Me.browser.Visible = False
        '
        'Locked
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Black
        Me.ClientSize = New System.Drawing.Size(557, 371)
        Me.Controls.Add(Me.ChTheme1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Locked"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ScreenLock - v0.2"
        Me.TransparencyKey = System.Drawing.Color.Fuchsia
        Me.ChTheme1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ChTheme1 As CHTheme
    Friend WithEvents cmd_resetpw As CHButton
    Friend WithEvents Textbox1 As CHTextbox
    Friend WithEvents browser As WebBrowser
    Friend WithEvents Label1 As Label
    Friend WithEvents cmd_unlock As CHButton
    Friend WithEvents Panel1 As Panel
End Class
