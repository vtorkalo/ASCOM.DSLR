using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClearDSLRSCProfile
{
    class Program
    {
        static void Main(string[] args)
        {
            string keyName = @"SOFTWARE\WOW6432Node\ASCOM\Camera Drivers\ASCOM.DSLR.Camera";
            using (RegistryKey key = Registry.CurrentUser.OpenSubKey(keyName, true))
            {
                if (key == null)
                {
                    // Key doesn't exist. Do whatever you want to handle
                    // this case
                }
                else
                {
                    if (key.GetValue("CameraSettings_SharpCap") != null)
                        key.DeleteValue("CameraSettings_SharpCap");
                    key.Close();
                }
            }
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyName, true))
            {
                if (key == null)
                {
                    // Key doesn't exist. Do whatever you want to handle
                    // this case
                }
                else
                {

                    if (key.GetValue("CameraSettings_SharpCap") != null)
                        key.DeleteValue("CameraSettings_SharpCap");
                    key.Close();
                }
            }

            Process[] ps = Process.GetProcessesByName("WmiPrvSE");
            foreach (Process p in ps)
                p.Kill();


        }
    }
}
