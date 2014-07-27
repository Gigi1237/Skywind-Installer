using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;


namespace Skywind_Launcher
{
    static class Program
    {
        #region Properties
        public static string skywindPath { get; set; }
        #endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Registry paths for skyrim/skywind/morrowind
            skywindPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind",
                "installed path", null);

            //Check if skywind is installed
            bool installed;
            if (skywindPath == null)
            {
                installed = false;
            }
            else
            {
                installed = checkSkywind(skywindPath);
            }

            // If skywind is not installed run installer
            if (installed == false)
            {
                try
                {
                    Process installer = Process.Start("Skywind Installer.exe");
                    installer.WaitForExit();
                }
                catch (System.ComponentModel.Win32Exception)
                {
                    MessageBox.Show("'Skywind Installer.exe' was not found!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                
                Application.Run(new Welcome());
            }
        }

        public static bool checkSkywind(string path)
        {
            return File.Exists(Path.Combine(path, "Data\\Skywind.esm")) &&
                    File.Exists(Path.Combine(path, "Data\\Skywind - Patch.bsa")) &&
                    File.Exists(Path.Combine(path, "Data\\Skywind.bsa"));
        }
    }
}
