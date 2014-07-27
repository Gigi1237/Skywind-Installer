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
#if DEBUG
            installType2.Enabled = true;
            installType2Label.Enabled = true;
#endif
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
                    progressBar.Visible = true;
                    nextButton.Enabled = false;
                    installType1.Enabled = false;
                    installType2.Enabled = false;
                    cancelbutton.Enabled = false;
                    Program.skywindPath = browseInstallLocation.SelectedPath;
                    backgroundInstall1.RunWorkerAsync();
                }
            }
            else if (installType2.Checked)
            {
                progressBar.Visible = true;
                nextButton.Enabled = false;
                installType1.Enabled = false;
                installType2.Enabled = false;
                cancelbutton.Enabled = false;
                Program.skywindPath = Program.skyrimPath;

                string skywindFilesDir = null;
                //Obtain directory containing skywind files
                if (Directory.Exists("SkyWind_0.9.4.5_Full"))
                {
                    skywindFilesDir = "SkyWind_0.9.4.5_Full";
                }
                else
                {
                    broseSkywindFileDir.ShowDialog();
                    skywindFilesDir = broseSkywindFileDir.SelectedPath;
                }
                progressBar.Style = ProgressBarStyle.Marquee;
                copySkywind.RunWorkerAsync(skywindFilesDir);
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
            MessageBox.Show("Successfully copied skyrim files to installation directory!");
        }
        private void backgroundInstall1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //Increment the progress bar
            progressBar.Value = e.ProgressPercentage;
        }

        private void backgroundInstall1_OnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            string skywindFilesDir = null;

            //Obtain directory containing skywind files
            if (Directory.Exists("SkyWind_0.9.4.5_Full"))
            {
                skywindFilesDir = "SkyWind_0.9.4.5_Full";
            }
            else
            {
                broseSkywindFileDir.ShowDialog();
                skywindFilesDir = broseSkywindFileDir.SelectedPath;
            }
            progressBar.Style = ProgressBarStyle.Marquee;
            copySkywind.RunWorkerAsync(skywindFilesDir);

        }

        public skywindNotDetectedWelcome welcomeForm { get; set; }

        private void InstallWizard_FormClosed(object sender, FormClosedEventArgs e)
        {
            welcomeForm.Show();
        }

        private void copySkywind_DoWork(object sender, DoWorkEventArgs e)
        {
            MessageBox.Show("Will now copy skywind files to install directory.\nThe progress bar isn't impemnted for this yet");
            Program.DirectoryCopy((string)e.Argument, Path.Combine(Program.skywindPath, "Data"), true);

            //Set registry
            try
            {
                if (Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "installed_path", null) == null)
                {
                    Registry.LocalMachine.CreateSubKey(@"SOFTWARE\Skywind");
                    Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "installed_path", Program.skywindPath);
                }
                else
                {
                    if (MessageBox.Show("Skywind Registry key already exists!,\nreplace it?", "Warning!",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Registry.SetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Skywind", "installed_path", Program.skywindPath);
                    }
                }

            }
            catch (System.UnauthorizedAccessException)
            {
                MessageBox.Show("Failed to write skywind location to registry.\nPlease run the application with administrator privilages",
                    "Permission Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cancelbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void copySkywind_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
