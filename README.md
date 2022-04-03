# ASCOM.DSLR
ASCOM Driver for DSLR Cameras

What is the ASCOM.DSLR project?
ASCOM.DSLR is a ASCOM compatible driver for DSLR cameras. this will make unlimited possibilities to use DSLR cameras with astrophotography.
DSLR Supports CANON, NIKON and PENTAX Cameras

What license is the code being released under?
The code is being released under GPL v3 and GPL v3 compatible licenses. Means if out use this part of your aplication you need to release the source code of you aplication.

Technologies:
The project uses C#, DigicamControl for Old Nikon Cameras, Nikoncswrapper for newer nikon cameras, CanonSDK, pktriggercord, Libraw and Innosetup

The Drivers is supported As-Is we not responsible for damages in your camera.

Note that focusing camera lenses is not possible with this driver.  ASCOM focuser drivers are distinct from camera drivers, so it isn't something that is even been considered.

Installation Guide (including where to download!): https://github.com/FearL0rd/ASCOM.DSLR/wiki/Installation

If you would like to contribute documenting ASCOM.DSLR, let me know to get you started.

Discord Channel: https://discord.gg/SanCmjQN99

Wiki: https://github.com/FearL0rd/ASCOM.DSLR/wiki

List of cameras know to work: https://github.com/FearL0rd/ASCOM.DSLR/wiki/Camera-Compatibility

Notes about using Sharpcap: https://github.com/FearL0rd/ASCOM.DSLR/wiki/Notes-about-Sharpcap

Release Notes

5/15/2020 - Added more log fo troubleshooting

5/29/2020 - Fixed Camera detection to work wil multiple cameras

6/01/2020 - New update. I have added Dropdown list for isos to supported applications like SharpCap

6/3/2020 - Some Nikon camera are working as reported by user

6/3/2020 - New Libraw implemented now it can read Canon CR3 and newer formats

6/3/2020 - Picture Preview in the TestApp (Still buggy but you have a preview)

6/10/2020 -PENTAX Cameras are working with this version. (Tested with K-30)

6/10/2020 - New Nikon API started to be implemented (NikonBeta) in the dropdown list.

6/13/2020 - Official Nikon API implemented

6/13/2020 - Old NikonDriver renamed to NikonLegacy in the selection list.

6/14/2020 - Fixed  Nikon BulbMode Issues

6/19/2020 - Fixed Connection with Nikon 3X00

6/20/2020 - Enabled Canon Liveview for supported apps (SharpCap)

6/23/2020 - Enabled Nikon LiveView for supported apps 

6/27/2020 - Added utility to clean SC DSLR camera profile in order to avoid issues changing LiveView<>Frame modes. (PLease read the instruction on Wiki Page)

7/7/2020 - updated the ClearDSLRSCProfile to clear COMM error without need to reboot the machine.
