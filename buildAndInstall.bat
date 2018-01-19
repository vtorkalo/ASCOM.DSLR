"C:\Program Files (x86)\MSBuild\14.0\Bin\msbuild.exe" "./ASCOM.DSLR.sln" /p:configuration=debug /property:Platform="Any CPU"

"c:\Program Files (x86)\Inno Setup 5\ISCC.exe" "./DSLR.Camera Setup.iss"

".\DSLR.Camera Setup.exe" /VERYSILENT /SUPPRESSMSGBOXES
pause