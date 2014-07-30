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
        public static string skywindPath;
        public static string skyrimPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Bethesda softworks\\sakyrim",
                    "installed path", null);
        public static string morrowindPath = (string)Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Bethesda softworks\\morrowind",
                    "installed path", null);
        public static string []skyrimFilesToCopy { get; private set; }
        public static string[] skyrimDirsToCopy { get; private set; }


        #endregion

        #region Private Properties
        private static string skyrimFilesConfig = "skyrimFilesToCopy.txt";
        private static string skyrimDirsConfig = "skyrimDirsToCopy.txt";

        #endregion


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            setSkryimToCopy();

            Application.Run(new InstallWizard());
            
        }

        #region Functions
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
                file.CopyTo(temppath, true);
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

        private static void setSkryimToCopy()
        {
            //Files to copy from skyrim directory
            if (File.Exists(skyrimFilesConfig))
            {
                skyrimFilesToCopy = File.ReadAllLines(skyrimFilesConfig);
            }
            else
            {
                skyrimFilesToCopy = new string[]{
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
            }

            if(File.Exists(skyrimDirsConfig))
            {
                skyrimDirsToCopy = File.ReadAllLines(skyrimFilesConfig);
            }
            else
            {
                skyrimDirsToCopy = new string[]{
                "Data\\Interface",
                "Data\\String",
                "Skyrim"};
            }

        }
        #endregion

    }
}
