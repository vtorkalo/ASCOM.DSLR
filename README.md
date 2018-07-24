# ASCOM.DSLR
ASCOM Driver for DSLR Cameras

Development environment preparation
1. Install Visual studio 2017
2. Download and install Inno Setup 5.5.8 http://files.jrsoftware.org/is/5/isetup-5.5.8-unicode.exe
3. Install ASCOM platform 6.4 https://ascom-standards.org/Downloads/Index.htm
4. Install ASCOM development components https://ascom-standards.org/Downloads/PlatDevComponents.htm
5. Open visual studio solution, right click on Solution item in Solution Explorer - Restore nuget packages.
6. Now you will be able to build solution

Installer building:
Run build.bat https://github.com/vtorkalo/ASCOM.DSLR/blob/master/build.bat
This script will compile C# project and build installer. Installer will be placed in same folder (filename DSLR.Camera Setup.exe) Note: script is created to work on x64 systems. If you are using x86 - please modify script to correct patch to "Program Filex (x86)"

Install path 