using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Skywind_Installer
{
    public partial class s : Form
    {
        public s()
        {
            InitializeComponent();
        }

        private void welcomeNotDetected_Load(object sender, EventArgs e)
        {

        }

        private void browseForInstall_Click(object sender, EventArgs e)
        {
            browse.Enabled = true;
        }

        private void browse_Click(object sender, EventArgs e)
        {
            browseForSkywind.ShowDialog();
        }

        private void installButton_Click(object sender, EventArgs e)
        {

        }
    }
}
