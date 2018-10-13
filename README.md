## ScreenLock - Locks safely your Desktop

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/29c5260b09f040b6831c7b504e14b6ee)](https://app.codacy.com/app/clusterzx/ScreenLock?utm_source=github.com&utm_medium=referral&utm_content=clusterzx/ScreenLock&utm_campaign=Badge_Grade_Dashboard)

ScreenLock allows you to lock the screen against unauthorized use. Simply compile the source code you have adapted to your needs.

### Instructions

```markdown
# Important
## ReBuild it before opening form. It is necessary to make the Theme work.

## Change Password
Go to Project Settings -> Settings -> Create a new string with name 'screenpw' and your password as value.

# Compile it
Rebuild the solution

# Windows configuration
Make the application run with Admin rights.
Unless you do that, the application won't lock the Taskmanager.

Tip: 
If you want it to run on logon with adminrights
Open cmd --> schtasks /create /tn "NAME OF TASK" /tr PATH TO EXE /sc onstart /ru SYSTEM /RL HIGHEST

```
