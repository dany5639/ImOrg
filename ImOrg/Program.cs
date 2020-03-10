using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImOrg
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!File.Exists("AxInterop.WMPLib.dll") || !File.Exists("Interop.WMPLib.dll"))
            {
                MessageBox.Show("ERROR: this library is required to play videos: AxInterop.WMPLib.dll & Interop.WMPLib.dll. This cannot continue.");
                return;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
