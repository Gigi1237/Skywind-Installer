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
            "atimgpud.dll",
            "binkw32.dll",
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
           
            
        }
        static bool checkSkywindInstall()
        {
            return (File.Exists(Path.Combine(skywindPath, "Data\\Skywind.esm")) &&
                    File.Exists(Path.Combine(skywindPath, "Data\\Skywind - Patch.bsa")) &&
                    File.Exists(Path.Combine(skywindPath, "Data\\Skywind.bsa")));
        }
        public static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
        public static void DeleteDirectory(string path)
        {
            foreach (string directory in Directory.GetDirectories(path))
            {
                DeleteDirectory(directory);
            }

            try
            {
                Directory.Delete(path, true);
            }
            catch (IOException)
            {
                Directory.Delete(path, true);
            }
            catch (UnauthorizedAccessException)
            {
                Directory.Delete(path, true);
            }
        }
       
    }
}
