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
        public Welcome()
        {
            InitializeComponent();

            skywindPath.Text = Program.skywindPath;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            // Browse dir and check if it contains skywind files
            browseSkywind.ShowDialog();
            if (Program.checkSkywind(browseSkywind.SelectedPath))
            {
                Program.skywindPath = browseSkywind.SelectedPath;
            }
            else
                MessageBox.Show("Invalid skywind path!");

            skywindPath.Text = Program.skywindPath;
        }

        private void launch_Click(object sender, EventArgs e)
        {
            // Launch SKSE if it exits else launch TESV
            if(File.Exists(Path.Combine(Program.skywindPath, "skse_launcher.exe")))
            {
                //Launch SKSE
                Process.Start(Path.Combine(Program.skywindPath, "skse_launcher.exe"));
                Application.Exit();
            }
            else
            {
                //Set env Variables to skip launcher
                Environment.SetEnvironmentVariable("SteamGameId", "72850");
                Environment.SetEnvironmentVariable("SteamAppId", "72850");

                //Launch skyrim
                Process.Start(Path.Combine(Program.skywindPath, "TESV.exe"));
            }
        }
    }
}
