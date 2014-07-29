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
            this.browseButton = new System.Windows.Forms.Button();
            this.browseForSkyrim = new System.Windows.Forms.FolderBrowserDialog();
            this.browseForMorrowind = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.browse = new System.Windows.Forms.RadioButton();
            this.install = new System.Windows.Forms.RadioButton();
            this.nextButton = new System.Windows.Forms.Button();
            this.browseForSkywind = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // browseButton
            // 
            this.browseButton.Enabled = false;
            this.browseButton.Location = new System.Drawing.Point(312, 44);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(51, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browse_Click);
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.browse);
            this.groupBox1.Controls.Add(this.install);
            this.groupBox1.Controls.Add(this.browseButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(377, 77);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "A Skywind install was not detected. Do you want to:";
            // 
            // browse
            // 
            this.browse.AutoSize = true;
            this.browse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browse.Location = new System.Drawing.Point(6, 45);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(300, 20);
            this.browse.TabIndex = 1;
            this.browse.TabStop = true;
            this.browse.Text = "Browse for an existing install of Skywind";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.CheckedChanged += new System.EventHandler(this.browse_CheckedChanged);
            // 
            // install
            // 
            this.install.AutoSize = true;
            this.install.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.install.Location = new System.Drawing.Point(6, 19);
            this.install.Name = "install";
            this.install.Size = new System.Drawing.Size(128, 20);
            this.install.TabIndex = 0;
            this.install.TabStop = true;
            this.install.Text = "Install Skywind";
            this.install.UseVisualStyleBackColor = true;
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(314, 95);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 5;
            this.nextButton.Text = "Next >";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // browseForSkywind
            // 
            this.browseForSkywind.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.browseForSkywind.ShowNewFolderButton = false;
            // 
            // skywindNotDetectedWelcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 127);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "skywindNotDetectedWelcome";
            this.Text = "Install not detected";
            this.Load += new System.EventHandler(this.welcomeNotDetected_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.FolderBrowserDialog browseForSkyrim;
        private System.Windows.Forms.FolderBrowserDialog browseForMorrowind;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton browse;
        private System.Windows.Forms.RadioButton install;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.FolderBrowserDialog browseForSkywind;
    }
}