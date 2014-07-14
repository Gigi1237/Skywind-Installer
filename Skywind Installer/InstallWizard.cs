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
                }
            }
        }

    }
}
