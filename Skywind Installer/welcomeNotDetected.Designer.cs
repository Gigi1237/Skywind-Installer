namespace Skywind_Installer
{
    partial class skywindNotDetectedWelcome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.installButton = new System.Windows.Forms.Button();
            this.browseForInstall = new System.Windows.Forms.Button();
            this.browse = new System.Windows.Forms.Button();
            this.browseForSkyrim = new System.Windows.Forms.FolderBrowserDialog();
            this.browseForMorrowind = new System.Windows.Forms.FolderBrowserDialog();
            this.testbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(252, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "A Skywind install was not detected. Do you want to:";
            // 
            // installButton
            // 
            this.installButton.Location = new System.Drawing.Point(15, 25);
            this.installButton.Name = "installButton";
            this.installButton.Size = new System.Drawing.Size(155, 23);
            this.installButton.TabIndex = 1;
            this.installButton.Text = "Install Skywind";
            this.installButton.UseVisualStyleBackColor = true;
            this.installButton.Click += new System.EventHandler(this.installButton_Click);
            // 
            // browseForInstall
            // 
            this.browseForInstall.Enabled = false;
            this.browseForInstall.Location = new System.Drawing.Point(15, 56);
            this.browseForInstall.Name = "browseForInstall";
            this.browseForInstall.Size = new System.Drawing.Size(155, 23);
            this.browseForInstall.TabIndex = 2;
            this.browseForInstall.Text = "Browse for an existing install";
            this.browseForInstall.UseVisualStyleBackColor = true;
            this.browseForInstall.Click += new System.EventHandler(this.browseForInstall_Click);
            // 
            // browse
            // 
            this.browse.Enabled = false;
            this.browse.Location = new System.Drawing.Point(176, 56);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(51, 23);
            this.browse.TabIndex = 3;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // browseForSkyrim
            // 
            this.browseForSkyrim.Description = "Browse into your skyrim Installation";
            this.browseForSkyrim.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.browseForSkyrim.ShowNewFolderButton = false;
            // 
            // browseForMorrowind
            // 
            this.browseForMorrowind.Description = "Browse into your morrowind Installation";
            this.browseForMorrowind.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.browseForMorrowind.ShowNewFolderButton = false;
            // 
            // testbutton
            // 
            this.testbutton.Location = new System.Drawing.Point(192, 25);
            this.testbutton.Name = "testbutton";
            this.testbutton.Size = new System.Drawing.Size(75, 23);
            this.testbutton.TabIndex = 4;
            this.testbutton.Text = "open skywind";
            this.testbutton.UseVisualStyleBackColor = true;
            this.testbutton.Click += new System.EventHandler(this.button1_Click);
            // 
            // skywindNotDetectedWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 89);
            this.Controls.Add(this.testbutton);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.browseForInstall);
            this.Controls.Add(this.installButton);
            this.Controls.Add(this.label1);
            this.Name = "skywindNotDetectedWelcome";
            this.Text = "Install not detected";
            this.Load += new System.EventHandler(this.welcomeNotDetected_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button installButton;
        private System.Windows.Forms.Button browseForInstall;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.FolderBrowserDialog browseForSkyrim;
        private System.Windows.Forms.FolderBrowserDialog browseForMorrowind;
        private System.Windows.Forms.Button testbutton;
    }
}