namespace Skywind_Installer
{
    partial class InstallWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InstallWizard));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cleanInstall = new System.Windows.Forms.CheckBox();
            this.installType2 = new System.Windows.Forms.RadioButton();
            this.installType1 = new System.Windows.Forms.RadioButton();
            this.installType2Label = new System.Windows.Forms.Label();
            this.installType1Label = new System.Windows.Forms.Label();
            this.nextButton = new System.Windows.Forms.Button();
            this.cancelbutton = new System.Windows.Forms.Button();
            this.browseInstallLocation = new System.Windows.Forms.FolderBrowserDialog();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.backgroundInstall1 = new System.ComponentModel.BackgroundWorker();
            this.broseSkywindFileDir = new System.Windows.Forms.FolderBrowserDialog();
            this.copySkywind = new System.ComponentModel.BackgroundWorker();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cleanInstall);
            this.groupBox1.Controls.Add(this.installType2);
            this.groupBox1.Controls.Add(this.installType1);
            this.groupBox1.Controls.Add(this.installType2Label);
            this.groupBox1.Controls.Add(this.installType1Label);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 207);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "How would you like to install?";
            // 
            // cleanInstall
            // 
            this.cleanInstall.AutoSize = true;
            this.cleanInstall.Enabled = false;
            this.cleanInstall.Location = new System.Drawing.Point(224, 165);
            this.cleanInstall.Name = "cleanInstall";
            this.cleanInstall.Size = new System.Drawing.Size(258, 17);
            this.cleanInstall.TabIndex = 6;
            this.cleanInstall.Text = "Delete all unnecessary files in the skyrim directory";
            this.cleanInstall.UseVisualStyleBackColor = true;
            // 
            // installType2
            // 
            this.installType2.AutoSize = true;
            this.installType2.Enabled = false;
            this.installType2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installType2.Location = new System.Drawing.Point(22, 100);
            this.installType2.Name = "installType2";
            this.installType2.Size = new System.Drawing.Size(190, 20);
            this.installType2.TabIndex = 5;
            this.installType2.TabStop = true;
            this.installType2.Text = "Copy into Skyrim folder:";
            this.installType2.UseVisualStyleBackColor = true;
            this.installType2.CheckedChanged += new System.EventHandler(this.installType2_CheckedChanged);
            // 
            // installType1
            // 
            this.installType1.AutoSize = true;
            this.installType1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.installType1.Location = new System.Drawing.Point(22, 20);
            this.installType1.Name = "installType1";
            this.installType1.Size = new System.Drawing.Size(170, 20);
            this.installType1.TabIndex = 4;
            this.installType1.TabStop = true;
            this.installType1.Text = "Custom folder install:";
            this.installType1.UseVisualStyleBackColor = true;
            this.installType1.CheckedChanged += new System.EventHandler(this.installType1_CheckedChanged);
            // 
            // installType2Label
            // 
            this.installType2Label.AutoSize = true;
            this.installType2Label.Enabled = false;
            this.installType2Label.Location = new System.Drawing.Point(38, 123);
            this.installType2Label.Name = "installType2Label";
            this.installType2Label.Size = new System.Drawing.Size(528, 39);
            this.installType2Label.TabIndex = 3;
            this.installType2Label.Text = "Skywind is copied to your existing Skyrim install. \r\nNew game or use a Skyrim cha" +
    "racter. Possible corruption, conflicts and stability problems to your Skyrim gam" +
    "e. \r\n(Needs 3.5GB of free disk space)\r\n";
            // 
            // installType1Label
            // 
            this.installType1Label.AutoSize = true;
            this.installType1Label.Location = new System.Drawing.Point(38, 43);
            this.installType1Label.Name = "installType1Label";
            this.installType1Label.Size = new System.Drawing.Size(576, 39);
            this.installType1Label.TabIndex = 1;
            this.installType1Label.Text = resources.GetString("installType1Label.Text");
            // 
            // nextButton
            // 
            this.nextButton.Location = new System.Drawing.Point(498, 225);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 7;
            this.nextButton.Text = "Next >";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // cancelbutton
            // 
            this.cancelbutton.Location = new System.Drawing.Point(579, 225);
            this.cancelbutton.Name = "cancelbutton";
            this.cancelbutton.Size = new System.Drawing.Size(75, 23);
            this.cancelbutton.TabIndex = 8;
            this.cancelbutton.Text = "Cancel";
            this.cancelbutton.UseVisualStyleBackColor = true;
            this.cancelbutton.Click += new System.EventHandler(this.cancelbutton_Click);
            // 
            // browseInstallLocation
            // 
            this.browseInstallLocation.Description = "Select the folder where you want to install skywind:";
            this.browseInstallLocation.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(13, 225);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(481, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 9;
            this.progressBar.Visible = false;
            // 
            // backgroundInstall1
            // 
            this.backgroundInstall1.WorkerReportsProgress = true;
            this.backgroundInstall1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundInstall1_DoWork);
            this.backgroundInstall1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundInstall1_ProgressChanged);
            this.backgroundInstall1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundInstall1_OnRunWorkerCompleted);
            // 
            // broseSkywindFileDir
            // 
            this.broseSkywindFileDir.Description = "Browse into the folder containing the skywind files.";
            this.broseSkywindFileDir.RootFolder = System.Environment.SpecialFolder.MyComputer;
            this.broseSkywindFileDir.ShowNewFolderButton = false;
            // 
            // copySkywind
            // 
            this.copySkywind.WorkerReportsProgress = true;
            this.copySkywind.DoWork += new System.ComponentModel.DoWorkEventHandler(this.copySkywind_DoWork);
            this.copySkywind.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.copySkywind_RunWorkerCompleted);
            // 
            // InstallWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 255);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.cancelbutton);
            this.Controls.Add(this.groupBox1);
            this.Name = "InstallWizard";
            this.Text = "Install Wizard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.InstallWizard_FormClosed);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton installType2;
        private System.Windows.Forms.RadioButton installType1;
        private System.Windows.Forms.Label installType2Label;
        private System.Windows.Forms.Label installType1Label;
        private System.Windows.Forms.CheckBox cleanInstall;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button cancelbutton;
        private System.Windows.Forms.FolderBrowserDialog browseInstallLocation;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.ComponentModel.BackgroundWorker backgroundInstall1;
        private System.Windows.Forms.FolderBrowserDialog broseSkywindFileDir;
        private System.ComponentModel.BackgroundWorker copySkywind;

    }
}