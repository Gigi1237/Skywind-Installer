using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Skywind_Installer
{
    static class Program
    {
        #region Properties
        public static string skywindPath { get; set; }
        public static string skyrimPath { get; set;}
        public static string morrowindPath { get; set; }
        public static string[] copySkyrim { get; private set; } 
        #endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Files to copy from skyrim directory
            copySkyrim = new string[]{
            "high.ini",
            "installscript.vdf",
            "low.ini",
            "medium.ini",
            "readme.txt",
            "SkyrimLauncher.exe",
            "steam_api.dll",
            "TESV.exe",
            "VeryHigh.ini",
            "Data\\Skyrim - Shaders.bsa",
            "Data\\Update.bsa",
            "Data\\Update.esm",
            "Data\\Skyrim.esm",
            "Data\\Update.bsa",
            "Data\\Update.esm",
            "Data\\Skyrim - Animations.bsa",
            "Data\\Skyrim - Interface.bsa",
            "Data\\Skyrim - Meshes.bsa",
            "Data\\Skyrim - Misc.bsa",
            "Data\\Skyrim - Shaders.bsa",
            "Data\\Skyrim - Sounds.bsa",
            "Data\\Skyrim - Textures.bsa",
            "Data\\Skyrim - Voices.bsa",
            "Data\\Skyrim - VoicesExtra.bsa",
            "Data\\Interface",
            "Data\\Strings",
            "Skyrim"};

            //Registry paths for skyrim/skywind/morrowind
            skywindPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind",
                "installed path", null);
            skyrimPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Bethesda softworks\\skyrim",
                    "installed path", null);
            morrowindPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Bethesda softworks\\morrowind",
                    "installed path", null);

            //Check if skywind is installed
            bool installed;
            if(skywindPath == null)
            {
                installed = false;
            }
            else
            {
                installed = checkSkywindInstall();
            }

            if (installed == false)
            {
                Application.Run(new skywindNotDetectedWelcome());
            }
            

            //string skyrimPath =(string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Bethesda sofatworks\\skyrim",
            //        "installed path", null);

            ////while(skyrimPath == null)
            //FolderBrowserDialog dialog = new FolderBrowserDialog();
            //dialog.Description = "Skyrim directory not found!\n Select skyrim directory";
            //dialog.ShowNewFolderButton = false;
            //while(dialog.ShowDialog() != System.Windows.Forms.DialogResult.Cancel)
            //{
            //    if()
            //    skyrimPath = dialog.SelectedPath;
            //}
            
        }
        static bool checkSkywindInstall()
        {
            return (File.Exists(Path.Combine(skywindPath, "Data\\Skywind.esm")) &&
                    File.Exists(Path.Combine(skywindPath, "Data\\Skywind - Patch.bsa")) &&
                    File.Exists(Path.Combine(skywindPath, "Data\\Skywind.bsa")));
        }
        public static void installType1(ProgressBar progressBar)
        {
            Directory.CreateDirectory(Path.Combine(skywindPath, "data"));
            for (int i = 0; i < copySkyrim.Count() - 3; i++)
            {
                if(File.Exists(Path.Combine(skywindPath, copySkyrim[i])))
                {
                    File.Delete(Path.Combine(skywindPath, copySkyrim[i]));
                }
                System.IO.File.Copy(Path.Combine(skyrimPath, copySkyrim[i]), Path.Combine(skywindPath, copySkyrim[i]));
                
            }
        }
       
    }
}
