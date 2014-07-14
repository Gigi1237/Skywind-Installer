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
using Microsoft.Win32;

namespace Skywind_Installer
{
    public partial class InstallWizard : Form
    {
        public InstallWizard()
        {
            InitializeComponent();
        }

        private void installType1_CheckedChanged(object sender, EventArgs e)
        {
            cleanInstall.Enabled = false;
            cleanInstall.Checked = false;
        }

        private void installType2_CheckedChanged(object sender, EventArgs e)
        {
            cleanInstall.Enabled = true;
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (installType1.Checked)
            {
                if (browseInstallLocation.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Program.skywindPath = browseInstallLocation.SelectedPath;
                    progress.Visible = true;
                    nextButton.Enabled = false;
                    installType1.Enabled = false;
                    installType2.Enabled = false;
                    backgroundInstall1.RunWorkerAsync();
                    //MessageBox.Show("succes!");
                }
            }
        }
        private void backgroundInstall1_DoWork(object sender, DoWorkEventArgs e)
        {
            //Create Data Directory
            Directory.CreateDirectory(Path.Combine(Program.skywindPath, "Data"));

            for (int i = 0; i < Program.copySkyrim.Length - 4; i++)
            {
                string originalPath = Path.Combine(Program.skyrimPath, Program.copySkyrim[i]);
                string copyPath = Path.Combine(Program.skywindPath, Program.copySkyrim[i]);

                //If file exists, delete it
                if (File.Exists(copyPath))
                {
                    File.Delete(copyPath);
                }

                File.Copy(originalPath, copyPath);
                float progress = ((float)i / ((float)Program.copySkyrim.Length - 1f)) * 100f;
                backgroundInstall1.ReportProgress((int)progress);
            }

            for (int i = Program.copySkyrim.Length - 3; i <= Program.copySkyrim.Length - 1; i++)
            {
                string originalPath = Path.Combine(Program.skyrimPath, Program.copySkyrim[i]);
                string copyPath = Path.Combine(Program.skywindPath, Program.copySkyrim[i]);

                //If directory exists, delete it
                if (Directory.Exists(copyPath))
                {
                    Program.DeleteDirectory(copyPath);
                }

                Program.DirectoryCopy(originalPath, copyPath, true);
                float progress = ((float)i / ((float)Program.copySkyrim.Length - 1f)) * 100f;
                backgroundInstall1.ReportProgress((int)progress);
            }
            //if (Directory.Exists("SkyWind_*"))
            //{
            //    Program.DirectoryCopy("SkyWind_*", Path.Combine(Program.skywindPath, "Data"), true);
            //}


            
              MessageBox.Show("Successfully copied skyrim files to installation directory!");

                try
                {
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Skywind");
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "installed_path", Program.skywindPath);
                }
                catch (System.UnauthorizedAccessException)
                {
                    MessageBox.Show("Failed to write skywind location to registry.\nPlease run the application with administrator privilages", "Permission Error");
                }
        }
        private void backgroundInstall1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Increment the progress bar
            progress.Value = e.ProgressPercentage;
        }

        private void backgroundInstall1_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            welcomeForm.Show();
            this.Close();
        }

        public skywindNotDetectedWelcome welcomeForm { get; set; }
    }
}
