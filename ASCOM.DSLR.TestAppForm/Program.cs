using ASCOM.DSLR.Classes;
using CameraControl.Plugins.ExternalDevices;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace ASCOM.DSLR
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ExecuteCommand("--status --debug --timeout 3");

            var d = ParseStatus(File.ReadAllText(@"c:\git-vtorkalo\ASCOM.DSLR\testdata\status.txt"));



            var p = new ImageDataProcessor();

            var detector = new CameraModelDetector(p);

            var data0 = p.ReadRaw(@"d:\ascomdev\git\ASCOM.DSLR\testdata\test.dng-0000.dng");


            


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        public static string ExecuteCommand(string args)
        {
            var exeDir = @"c:\Program Files (x86)\Common Files\ASCOM\Camera\ASCOM.DSLR.Camera\pktriggercord\pktriggercord-cli.exe";

            ProcessStartInfo procStartInfo = new ProcessStartInfo();

            procStartInfo.FileName = exeDir;
            procStartInfo.Arguments = args;
            procStartInfo.RedirectStandardOutput = true;
            procStartInfo.UseShellExecute = false;
            procStartInfo.CreateNoWindow = true;

            string result = string.Empty;
            using (Process process = new Process())
            {
                process.StartInfo = procStartInfo;
                process.Start();

                process.WaitForExit();

                result = process.StandardOutput.ReadToEnd();
            }
            return result;
        }

        static Dictionary<string, string> ParseStatus(string status)
        {
            var result = new Dictionary<string, string>();

            using (StringReader sr = new StringReader(status))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split(':').Select(p=>p.Trim()).ToList();
                    if (parts.Count == 2)
                    {
                        result.Add(parts[0], parts[1]);
                    }
                }
            }

            return result;
        }

     

    }
}
