using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Skywind_Installer;
using System.Diagnostics;

namespace Skywind_Installer
{
    public partial class skywindNotDetectedWelcome : Form
    {
        public skywindNotDetectedWelcome()
        {
            InitializeComponent();
        }

        private void welcomeNotDetected_Load(object sender, EventArgs e)
        {

        }

        private void browseForInstall_Click(object sender, EventArgs e)
        {
            browseButton.Enabled = true;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            
        }

        private void installButton_Click(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process skywind = new Process();
            skywind.StartInfo.FileName = Path.Combine(Program.skyrimPath, "TESV.exe");
            skywind.StartInfo.WorkingDirectory = Program.skyrimPath;
            try
            {
                skywind.Start();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error executing", ex.Message, //or ex.tostring()
MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (install.Checked)
            {
                //If the path to skrym dir is null prompt user
                if (Skywind_Installer.Program.skyrimPath == null)
                {
                    if (browseForSkyrim.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Skywind_Installer.Program.skyrimPath = browseForSkyrim.SelectedPath;
                    }
                    else
                        return;
                }
                //Check if skyrim dir contains necessary files
                bool validSkyrimPath = true;
                for (int i = 0; i < Skywind_Installer.Program.copySkyrim.Count() - 3; i++)
                {
                    if (validSkyrimPath)
                    {
                        validSkyrimPath = System.IO.File.Exists(Path.Combine(
                            Skywind_Installer.Program.skyrimPath, Skywind_Installer.Program.copySkyrim[i]));
                    }
                }
                if (!validSkyrimPath)
                {
                    MessageBox.Show("Skyrim directory invalid or some files are missing!");
                    Program.skyrimPath = null;
                    return;
                }

                //If the path to morrowind dir is null prompt user
                if (Skywind_Installer.Program.morrowindPath == null)
                {
                    if (browseForMorrowind.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        Skywind_Installer.Program.morrowindPath = browseForMorrowind.SelectedPath;
                    }
                    else
                        return;
                }

                //Check morrowind HASH
                if (File.Exists(Path.Combine(Program.morrowindPath, "morrowind.exe")))
                {
                    FileStream morrowindEXE = File.Open(Program.morrowindPath + "\\Morrowind.exe", FileMode.Open);
                    byte[] hash = MD5.Create().ComputeHash(morrowindEXE);
                    morrowindEXE.Close();
                    byte[] correctHash1 = { 100, 44, 128, 91, 138, 63, 253, 57, 62, 22, 15, 108, 37, 139, 13, 165 };
                    byte[] correctHash2 = { 134, 106, 23, 159, 150, 40, 249, 108, 179, 129, 105, 220, 122, 39, 213, 173 };
                    byte[] correctHash3 = { 70, 8, 183, 71, 192, 236, 77, 115, 107, 196, 0, 129, 102, 28, 192, 135 };
                    if (!(hash.SequenceEqual(correctHash1) || hash.SequenceEqual(correctHash2) || hash.SequenceEqual(correctHash3)))
                    {
                        MessageBox.Show("Error: Morrowind is not genuine. \n If you belive this is a mistake contact the developer of this application");
                    }
                    InstallWizard installWizard = new InstallWizard();
                    installWizard.Show();
                    installWizard.welcomeForm = this;
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Invalid Morrowind directory, \nMorrowind.exe not Found");
                    Program.morrowindPath = null;
                    return;
                }
            }
            else
            {

            }
        }

        private void browse_CheckedChanged(object sender, EventArgs e)
        {
            if (browse.Checked)
            {
                browseButton.Enabled = true;
            }
            else
            {
                browseButton.Enabled = false;
            }
        }

    }
}
