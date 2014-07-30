using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Skywind_Launcher
{
    public partial class Welcome : Form
    {

        string myGamesDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "My Games");

        public Welcome()
        {
            InitializeComponent();

            // If skywind is not installed open the not installed dialog
            if(!Program.isSkywindInstalled())
            {
                skywindNotDetectedWelcome welcom = new skywindNotDetectedWelcome(this);
                welcom.Show();
            }
            else
                this.Show();
            skywindPath.Text = Program.skywindPath;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            // Browse dir and check if it contains skywind files
            browseSkywind.ShowDialog();
            if (Program.isValidSkywind(browseSkywind.SelectedPath))
            {
                Program.skywindPath = browseSkywind.SelectedPath;
            }
            else
                MessageBox.Show("Invalid skywind path!");
        }

        private void launch_Click(object sender, EventArgs e)
        {
            bool test = Convert.ToBoolean(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "skyrimDirInstall", null));
            if (!Convert.ToBoolean(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "skyrimDirInstall", null)))
            {
                string skyrimiINIpath = Path.Combine(myGamesDir, "Skyrim");
                string skyrimiTempINIpath = Path.Combine(myGamesDir, "Skyrim_TEMP");
                string skywindINIpath = Path.Combine(myGamesDir, "Skywind");

                if(Directory.Exists(skywindINIpath))
                {
                    Directory.Move(skyrimiINIpath, skyrimiTempINIpath);
                    Directory.Move(skywindINIpath, skyrimiINIpath);
                }
                else
                {
                    if(Directory.Exists(skyrimiINIpath))
                        Directory.Move(skyrimiINIpath, skyrimiTempINIpath);
                }
                launchSkywind();

                try
                {
                    Directory.Move(skyrimiINIpath, skywindINIpath);
                }
                catch (DirectoryNotFoundException) { }

                if (Directory.Exists(skyrimiTempINIpath))
                    Directory.Move(skyrimiTempINIpath, skyrimiINIpath);
                
            }
            else
            {
                launchSkywind();
            }
        }

        private void launchSkywind()
        {
            Process skywind;

            // Launch SKSE if it exits else launch TESV
            if(File.Exists(Path.Combine(Program.skywindPath, "skse_launcher.exe")))
            {
                //Launch SKSE
                skywind = Process.Start(Path.Combine(Program.skywindPath, "skse_launcher.exe"));
                
            }
            else
            {
                //Set env Variables to skip launcher
                Environment.SetEnvironmentVariable("SteamGameId", "72850");
                Environment.SetEnvironmentVariable("SteamAppId", "72850");

                //Launch skyrim
                skywind = Process.Start(Path.Combine(Program.skywindPath, "TESV.exe"));
            }

            skywind.WaitForExit();
        }

        private void Welcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Welcome_Shown(object sender, EventArgs e)
        {
            skywindPath.Text = Program.skywindPath;
        }

    }
}
