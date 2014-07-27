namespace Skywind_Launcher
{
    partial class Welcome
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Welcome));
            this.label1 = new System.Windows.Forms.Label();
            this.browse = new System.Windows.Forms.Button();
            this.skywindPath = new System.Windows.Forms.TextBox();
            this.browseSkywind = new System.Windows.Forms.FolderBrowserDialog();
            this.launch = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "We have detected a Skywind install in the following folder:";
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(327, 30);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(24, 22);
            this.browse.TabIndex = 2;
            this.browse.Text = "...";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.browse_Click);
            // 
            // skywindPath
            // 
            this.skywindPath.Enabled = false;
            this.skywindPath.Location = new System.Drawing.Point(16, 31);
            this.skywindPath.Name = "skywindPath";
            this.skywindPath.Size = new System.Drawing.Size(311, 20);
            this.skywindPath.TabIndex = 3;
            // 
            // launch
            // 
            this.launch.Location = new System.Drawing.Point(16, 58);
            this.launch.Name = "launch";
            this.launch.Size = new System.Drawing.Size(112, 23);
            this.launch.TabIndex = 4;
            this.launch.Text = "Launch the game";
            this.launch.UseVisualStyleBackColor = true;
            this.launch.Click += new System.EventHandler(this.launch_Click);
            // 
            // Welcome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 95);
            this.Controls.Add(this.launch);
            this.Controls.Add(this.skywindPath);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Welcome";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.TextBox skywindPath;
        private System.Windows.Forms.FolderBrowserDialog browseSkywind;
        private System.Windows.Forms.Button launch;
    }
}