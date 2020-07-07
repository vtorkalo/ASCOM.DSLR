"C:\Windows\Microsoft.NET\Framework\v4.0.30319\msbuild.exe" "./ASCOM.DSLR.sln" /p:configuration=debug
powershell -NoLogo -NoProfile -Command (get-item -Path bin\ASCOM.DSLR.Camera.dll).VersionInfo.FileVersion>version.txt
set /p VERSION=<version.txt
del version.txt
"c:\Program Files (x86)\Inno Setup 5\ISCC.exe" "./DSLR.Camera Setup.iss" /DApplicationVersion=%VERSION%

pause