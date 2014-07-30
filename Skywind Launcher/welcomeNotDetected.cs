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
using Skywind_Launcher;
using System.Diagnostics;

namespace Skywind_Launcher
{
    public partial class skywindNotDetectedWelcome : Form
    {

        #region Properties

        string installerName = "Skywind Installer.exe";
        bool openWelcome = false;
        Welcome welcome;

        #endregion

        public skywindNotDetectedWelcome(Welcome welcome)
        {
            InitializeComponent();

            this.welcome = welcome;
            if (File.Exists(installerName))
            {
                install.Enabled = false;
            }
        }

        private void browse_Click(object sender, EventArgs e)
        {
            if(browseForSkywind.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (Program.isValidSkywind(browseForSkywind.SelectedPath))
                {
                    Program.skywindPath = browseForSkywind.SelectedPath;
                }
                else
                    MessageBox.Show("Invalid skywind path!");
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (install.Checked)
            {
                Process.Start(installerName);
                Application.Exit();
            }
            else
            {
                if (Program.skywindPath != null)
                {
                    openWelcome = true;
                    this.Close();
                }
                else
                    MessageBox.Show("Plese browse into a valid skywind directory!", "Error!");
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

        private void skywindNotDetectedWelcome_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (openWelcome)
                welcome.Show();
            else
                Application.Exit();
        }
    }
}
