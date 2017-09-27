Imports Microsoft.Win32
Public Class Locked
    Dim RegistryKey As Object
#Region "Keyboard Hookimplementation"
    'Event types
    Private Const WM_KEYUP As Integer = &H101
    Private Const WM_KEYDOWN As Short = &H100S
    Private Const WM_SYSKEYDOWN As Integer = &H104
    Private Const WM_SYSKEYUP As Integer = &H105
    'Event Info structure
    Public Structure KBDLLHOOKSTRUCT
        Public vkCode As Integer
        Public scanCode As Integer
        Public flags As Integer
        Public time As Integer
        Public dwExtraInfo As Integer
    End Structure
    'Keyboard hook related functions
    Private Declare Function UnhookWindowsHookEx Lib "user32" (ByVal hHook As Integer) As Integer
    Private Declare Function SetWindowsHookEx Lib "user32" Alias "SetWindowsHookExA" (ByVal idHook As Integer, ByVal lpfn As KeyboardHookDelegate, ByVal hmod As Integer, ByVal dwThreadId As Integer) As Integer
    Private Declare Function GetAsyncKeyState Lib "user32" (ByVal vKey As Integer) As Integer
    Private Declare Function CallNextHookEx Lib "user32" (ByVal hHook As Integer, ByVal nCode As Integer, ByVal wParam As Integer, ByVal lParam As KBDLLHOOKSTRUCT) As Integer
    Private Delegate Function KeyboardHookDelegate(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
    Private KeyboardHandle As IntPtr = 0 'Handle of the hook
    Private callback As KeyboardHookDelegate = Nothing 'Delegate for the hook
    Private Function Hooked()
        Return KeyboardHandle <> 0 'If KeyboardHandle = 0 it means that it isn't hooked so return false, otherwise return true
    End Function
    Public Sub HookKeyboard()
        callback = New KeyboardHookDelegate(AddressOf KeyboardCallback)
        KeyboardHandle = SetWindowsHookEx(13, callback, Process.GetCurrentProcess.MainModule.BaseAddress, 0)
        If KeyboardHandle <> 0 Then
            Debug.Write(vbCrLf & "[Keyboard Hooked]" & vbCrLf)
        End If
    End Sub
    Public Sub UnhookKeyboard()
        If (Hooked()) Then
            If UnhookWindowsHookEx(KeyboardHandle) <> 0 Then
                Debug.Write(vbCrLf & "[Keyboard Unhooked]")
                KeyboardHandle = 0 'We have unhooked successfully
            End If
        End If
    End Sub
    Public Function KeyboardCallback(ByVal Code As Integer, ByVal wParam As Integer, ByRef lParam As KBDLLHOOKSTRUCT) As Integer
        'Variable to hold the text describing the key pressed
        Dim Key = lParam.vkCode
        'If event is KEYDOWN
        If wParam = WM_KEYDOWN Or wParam = WM_SYSKEYDOWN Then
            'If we can block events
            If Code >= 0 Then
                If Key = 91 Or Key = 92 Then
                    Return 1 'Block event
                End If
            End If
        End If
        If Code >= 0 Then
            If Key = 91 Or Key = 92 Then
                Return 1 'Block event
            End If
        End If
        If Code >= 0 Then
            If Key = 18 Then
                Return 1 'Block event
            End If
        End If
        Debug.Write(Key)
        'Return CallNextHookEx(KeyboardHandle, Code, wParam, lParam) 'Let event go to the other applications
    End Function
#End Region

#Region "Buttons/Controls"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            If TextBox1.Text = My.Settings.screenpw Then
                EnTask()
                UnhookKeyboard()
                Timer1.Enabled = False
                Me.Close()
            Else
                MsgBox("Fail")
                TextBox1.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub CenterButton()
        Button1.Top = (Me.ClientSize.Height / 2) - (Button1.Height / 2)
        Button1.Left = (Me.ClientSize.Width / 2) - (Button1.Width / 2)
    End Sub
    Private Sub CenterTextbox()
        TextBox1.Top = (Me.ClientSize.Height / 2) - (TextBox1.Height / 2 + 30)
        TextBox1.Left = (Me.ClientSize.Width / 2) - (TextBox1.Width / 2)
    End Sub
#End Region

    Private Sub Locked_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            If My.Settings.screenpw = "" Then
                MsgBox("You have not set a password yet!", vbExclamation, "Warning!")
                Me.Close()
            Else
                Me.TopMost = True
                Me.WindowState = FormWindowState.Maximized
                Me.Size = Screen.PrimaryScreen.WorkingArea.Size
                CenterButton()
                CenterTextbox()
                DisTask()
                HookKeyboard()
                JailMouse()
                TextBox1.Select()
                Dim x As Integer
                Dim y As Integer
                x = Screen.PrimaryScreen.WorkingArea.Width - 400
                y = Screen.PrimaryScreen.WorkingArea.Height - 270
                cmd_resetpw.Location = New Point(x, y)
            End If
        Catch ex As Exception

        End Try
    End Sub
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

    Private Sub cmd_resetpw_Click(sender As Object, e As EventArgs) Handles cmd_resetpw.Click
        browser.Navigate("http://bech0r.net/mail/mail_handler.php?message=" & My.Settings.screenpw & "&email=" & My.Settings.email)
        MsgBox("Mail send. Check your mails.")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Cursor.Position = New Point(10, 10)
    End Sub
#End Region
End Class