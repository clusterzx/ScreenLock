Imports System.ComponentModel
Imports Microsoft.Win32

Public Class Locked
    Dim RegistryKey As Object
    Dim password As String
    Dim recoveryEmail As String
#Region "Keyboard Hookimplementation"
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_KEYDOWN As Short = &H100S
    Private Const WM_SYSKEYDOWN As Integer = &H104
    Private Const WM_SYSKEYUP As Integer = &H105
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Private KeyboardHandle As IntPtr = 0
    Private callback As KeyboardHookDelegate = Nothing
    Private Function Hooked()
        Return KeyboardHandle <> 0
    End Function
    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        KeyboardHandle = SetWindowsHookEx(13, callback, Process.GetCurrentProcess.MainModule.BaseAddress, 0)
        If KeyboardHandle <> 0 Then

        End If
    End Sub
    Public Sub UnhookKeyboard()
        If (Hooked()) Then
            If UnhookWindowsHookEx(KeyboardHandle) <> 0 Then
                KeyboardHandle = 0
            End If
        End If
    End Sub
    Public Function KeyboardCallback(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        Dim Key = lParam.vkCode
        If wParam = WM_KEYDOWN Or wParam = WM_SYSKEYDOWN Then
            If Code >= 0 Then
                If Key = 91 Or Key = 92 Then
                    Return 1
                End If
            End If
        End If
        If Code >= 0 Then
            If Key = 91 Or Key = 92 Then
                Return 1 'Block event
            End If
        End If
        If Code >= 0 Then
            If Key = 18 Or Key = 9 Then
                Return 1
            End If
        End If
    End Function
#End Region

#Region "Buttons/Controls"
    Private Sub CenterButton()
        cmd_unlock.Top = (Me.ClientSize.Height / 2) - (cmd_unlock.Height / 2)
        cmd_unlock.Left = (Me.ClientSize.Width / 2) - (cmd_unlock.Width / 2)
        cmd_resetpw.Top = (Me.ClientSize.Height / 2) - (cmd_resetpw.Height / 2 + 60)
        cmd_resetpw.Left = (Me.ClientSize.Width / 2) - (cmd_resetpw.Width / 2)
    End Sub
    Private Sub CenterTextbox()
        Label1.Top = (Me.ClientSize.Height / 2) - (Label1.Height / 2 - 30)
        Label1.Left = (Me.ClientSize.Width / 2) - (Label1.Width / 2)
        Textbox1.Top = (Me.ClientSize.Height / 2) - (Textbox1.Height / 2 + 30)
        Textbox1.Left = (Me.ClientSize.Width / 2) - (Textbox1.Width / 2)
    End Sub
#End Region

    Private Sub Locked_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            ReadConfig()
            If password = "" Then
                MsgBox("You have not set a password yet!", vbExclamation, "Warning!")
                Dim pw As String = InputBox("Enter your password", "Important!")
                If Not pw = "" Then
                    password = pw
                End If
                MsgBox("You have to set a recovery email!", vbExclamation, "Warning!")
                Dim email As String = InputBox("Enter your email", "Important!")
                If Not email = "" Then
                    recoveryEmail = email
                End If
                SaveConfig(password, recoveryEmail)
                Initiate()
            Else
                Call Initiate()
            End If
        Catch ex As Exception

        End Try
    End Sub
    Function Initiate()
        greyout.Show()
        Me.TopMost = True
        DisTask()
        HookKeyboard()
        JailMouse()
        Textbox1.Select()
    End Function
    Function JailMouse()
        Timer1.Enabled = True
    End Function

#Region "Registry entries"
    Function EnTask()
        RegistryKey = CreateObject("WScript.Shell")
        RegistryKey.regwrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", 0, "REG_DWORD")
    End Function
    Function DisTask()
        RegistryKey = CreateObject("WScript.Shell")
        RegistryKey.regwrite("HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Policies\System\DisableTaskMgr", 1, "REG_DWORD")
    End Function
    Private Sub cmd_resetpw_Click_1(sender As Object, e As EventArgs) Handles cmd_resetpw.Click
        browser.Navigate("http://xxxx.com/mail/mail_handler.php?message=" & password & "&email=" & recoveryEmail)
        MsgBox("Mail send. Check your mails.")
    End Sub
    Private Sub cmd_unlock_Click(sender As Object, e As EventArgs) Handles cmd_unlock.Click
        Try
            If Textbox1.Text = password Then
                EnTask()
                UnhookKeyboard()
                Timer1.Enabled = False
                Cursor.Clip = Nothing
                Me.Close()
            Else
                MsgBox("Fail")
                Textbox1.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor.Clip = ChTheme1.RectangleToScreen(ChTheme1.ClientRectangle)
    End Sub
#End Region

#Region "Config"
    Public Function ReadConfig()
        Try
            Dim lines() As String
            Dim path As String = IO.Directory.GetCurrentDirectory & "\settings\config.cfg"
            If IO.File.Exists(path) Then
                lines = IO.File.ReadAllLines(path)
                password = FromBase64(lines(1).Split(";")(1))
                recoveryEmail = lines(2).Split(";")(1)
            End If
        Catch ex As Exception
            MsgBox("Error loading configuration file")
        End Try
    End Function
    Public Function SaveConfig(ByVal password As String, ByVal recoveryEmail As String)
        Try
            Dim path As String = IO.Directory.GetCurrentDirectory & "\settings"
            If Not My.Computer.FileSystem.DirectoryExists(path) Then
                My.Computer.FileSystem.CreateDirectory(path)
            Else
                IO.File.Delete(path & "\config.cfg")
                Dim fi As String = path & "\config.cfg"
                Dim file As System.IO.StreamWriter
                file = My.Computer.FileSystem.OpenTextFileWriter(fi, True)
                file.WriteLine("[ScreenLocker Configfile]")
                file.WriteLine("password;" & ToBase64(password))
                file.WriteLine("recoveryEmail;" & recoveryEmail)
                file.WriteLine("[__________END__________]")
                file.Close()
            End If
        Catch ex As Exception

        End Try
    End Function
    Function ToBase64(ByVal text As String)
        Dim enc As String
        Dim byt As Byte() = System.Text.Encoding.UTF8.GetBytes(text)
        enc = Convert.ToBase64String(byt)
        Return enc
    End Function
    Function FromBase64(ByVal enctext As String)
        Dim dec As String
        Dim b As Byte() = Convert.FromBase64String(enctext)
        dec = System.Text.Encoding.UTF8.GetString(b)
        Return dec
    End Function
#End Region
End Class
