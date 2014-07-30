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
        public static string skywindPath;
        #endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            skywindPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind",
                "installed path", null);

            Welcome welcome = new Welcome();
            Application.Run();
        }

        public static bool isValidSkywind(string path)
        {
            return File.Exists(Path.Combine(path, "Data\\Skywind.esm")) &&
                    File.Exists(Path.Combine(path, "Data\\Skywind - Patch.bsa")) &&
                    File.Exists(Path.Combine(path, "Data\\Skywind.bsa"));
        }

        public static void launchWelcome()
        {
            Application.Run(new Welcome());
        }

        public static bool isSkywindInstalled()
        {
            bool installed = true;

            //Check if skywind is installed
            if (skywindPath == null)
                installed = false;
            else
            {
                installed = isValidSkywind(skywindPath);
            }

            return installed;
        }
    }
}
