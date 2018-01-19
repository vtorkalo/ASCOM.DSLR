using ASCOM.DSLR.Classes;
using ExifToolWrap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            var w = new ExifToolWrapper();
            w.Run(@"d:\astrophoto\horse\light\LIGHT_300s_800iso_+22c_20171020-02h19m30s143ms.CR2");
            StringBuilder s = new StringBuilder();
            foreach (var e in w)
            {
                s.AppendLine(e.group + " " + e.name + " " + e.value);
            }
            var ras = s.ToString();

            var libraw = new LibRawWrapper();
            
            var d= libraw.ReadJpeg(@"d:\EOS\PREVIEW_20180118-15h23m57s389ms.JPG");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
