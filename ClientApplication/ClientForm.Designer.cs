namespace ClientServer
{
    partial class ClientForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientForm));
            this.connectButton = new System.Windows.Forms.Button();
            this.logTextBox = new System.Windows.Forms.TextBox();
            this.camImagePictureBox = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.eventLog1 = new System.Diagnostics.EventLog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gammaUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gammaDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyScaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastUpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contrastDownToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.darkenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertColorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lightenButton = new System.Windows.Forms.Button();
            this.darkenButton = new System.Windows.Forms.Button();
            this.brighnessLabel = new System.Windows.Forms.Label();
            this.gammaLabel = new System.Windows.Forms.Label();
            this.gammaDownButton = new System.Windows.Forms.Button();
            this.gammaUpButton = new System.Windows.Forms.Button();
            this.contrastLabel = new System.Windows.Forms.Label();
            this.contrastDownButton = new System.Windows.Forms.Button();
            this.contrastUpButton = new System.Windows.Forms.Button();
            this.captureButton = new System.Windows.Forms.Button();
            this.resizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.defaultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x480ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x600ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x768ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x960ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.camImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(12, 12);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Start";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // logTextBox
            // 
            this.logTextBox.Location = new System.Drawing.Point(12, 41);
            this.logTextBox.Multiline = true;
            this.logTextBox.Name = "logTextBox";
            this.logTextBox.Size = new System.Drawing.Size(156, 211);
            this.logTextBox.TabIndex = 1;
            // 
            // camImagePictureBox
            // 
            this.camImagePictureBox.Location = new System.Drawing.Point(174, 12);
            this.camImagePictureBox.Name = "camImagePictureBox";
            this.camImagePictureBox.Size = new System.Drawing.Size(320, 240);
            this.camImagePictureBox.TabIndex = 4;
            this.camImagePictureBox.TabStop = false;
            this.camImagePictureBox.Click += new System.EventHandler(this.camImagePictureBox_Click);
            this.camImagePictureBox.Resize += new System.EventHandler(this.camImagePictureBox_Resize);
            // 
            // stopButton
            // 
            this.stopButton.Enabled = false;
            this.stopButton.Location = new System.Drawing.Point(93, 12);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 5;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // eventLog1
            // 
            this.eventLog1.Log = "Application";
            this.eventLog1.SynchronizingObject = this;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "RemoteCam";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resizeToolStripMenuItem,
            this.gammaUpToolStripMenuItem,
            this.gammaDownToolStripMenuItem,
            this.greyScaleToolStripMenuItem,
            this.contrastUpToolStripMenuItem,
            this.contrastDownToolStripMenuItem,
            this.lightenToolStripMenuItem,
            this.darkenToolStripMenuItem,
            this.invertColorsToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(176, 268);
            // 
            // gammaUpToolStripMenuItem
            // 
            this.gammaUpToolStripMenuItem.Name = "gammaUpToolStripMenuItem";
            this.gammaUpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gammaUpToolStripMenuItem.Text = "GammaUp 10%";
            this.gammaUpToolStripMenuItem.Click += new System.EventHandler(this.gammaUpToolStripMenuItem_Click);
            // 
            // gammaDownToolStripMenuItem
            // 
            this.gammaDownToolStripMenuItem.Name = "gammaDownToolStripMenuItem";
            this.gammaDownToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.gammaDownToolStripMenuItem.Text = "GammaDown 10%";
            this.gammaDownToolStripMenuItem.Click += new System.EventHandler(this.gammaDownToolStripMenuItem_Click);
            // 
            // greyScaleToolStripMenuItem
            // 
            this.greyScaleToolStripMenuItem.Name = "greyScaleToolStripMenuItem";
            this.greyScaleToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.greyScaleToolStripMenuItem.Text = "GreyScale";
            this.greyScaleToolStripMenuItem.Click += new System.EventHandler(this.greyScaleToolStripMenuItem_Click);
            // 
            // contrastUpToolStripMenuItem
            // 
            this.contrastUpToolStripMenuItem.Name = "contrastUpToolStripMenuItem";
            this.contrastUpToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.contrastUpToolStripMenuItem.Text = "ContrastUp 10%";
            this.contrastUpToolStripMenuItem.Click += new System.EventHandler(this.contrastUpToolStripMenuItem_Click);
            // 
            // contrastDownToolStripMenuItem
            // 
            this.contrastDownToolStripMenuItem.Name = "contrastDownToolStripMenuItem";
            this.contrastDownToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.contrastDownToolStripMenuItem.Text = "ContrastDown 10%";
            this.contrastDownToolStripMenuItem.Click += new System.EventHandler(this.contrastDownToolStripMenuItem_Click);
            // 
            // lightenToolStripMenuItem
            // 
            this.lightenToolStripMenuItem.Name = "lightenToolStripMenuItem";
            this.lightenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.lightenToolStripMenuItem.Text = "Lighten 10%";
            this.lightenToolStripMenuItem.Click += new System.EventHandler(this.lightenToolStripMenuItem_Click);
            // 
            // darkenToolStripMenuItem
            // 
            this.darkenToolStripMenuItem.Name = "darkenToolStripMenuItem";
            this.darkenToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.darkenToolStripMenuItem.Text = "Darken 10%";
            this.darkenToolStripMenuItem.Click += new System.EventHandler(this.darkenToolStripMenuItem_Click);
            // 
            // invertColorsToolStripMenuItem
            // 
            this.invertColorsToolStripMenuItem.Name = "invertColorsToolStripMenuItem";
            this.invertColorsToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.invertColorsToolStripMenuItem.Text = "InvertColors";
            this.invertColorsToolStripMenuItem.Click += new System.EventHandler(this.invertColorsToolStripMenuItem_Click);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // lightenButton
            // 
            this.lightenButton.Location = new System.Drawing.Point(12, 258);
            this.lightenButton.Name = "lightenButton";
            this.lightenButton.Size = new System.Drawing.Size(54, 23);
            this.lightenButton.TabIndex = 6;
            this.lightenButton.Text = "Lighten";
            this.lightenButton.UseVisualStyleBackColor = true;
            this.lightenButton.Click += new System.EventHandler(this.lightenButton_Click);
            // 
            // darkenButton
            // 
            this.darkenButton.Location = new System.Drawing.Point(72, 258);
            this.darkenButton.Name = "darkenButton";
            this.darkenButton.Size = new System.Drawing.Size(54, 23);
            this.darkenButton.TabIndex = 7;
            this.darkenButton.Text = "Darken";
            this.darkenButton.UseVisualStyleBackColor = true;
            this.darkenButton.Click += new System.EventHandler(this.darkenButton_Click);
            // 
            // brighnessLabel
            // 
            this.brighnessLabel.AutoSize = true;
            this.brighnessLabel.Location = new System.Drawing.Point(133, 263);
            this.brighnessLabel.Name = "brighnessLabel";
            this.brighnessLabel.Size = new System.Drawing.Size(13, 13);
            this.brighnessLabel.TabIndex = 8;
            this.brighnessLabel.Text = "0";
            // 
            // gammaLabel
            // 
            this.gammaLabel.AutoSize = true;
            this.gammaLabel.Location = new System.Drawing.Point(133, 292);
            this.gammaLabel.Name = "gammaLabel";
            this.gammaLabel.Size = new System.Drawing.Size(13, 13);
            this.gammaLabel.TabIndex = 11;
            this.gammaLabel.Text = "0";
            // 
            // gammaDownButton
            // 
            this.gammaDownButton.Location = new System.Drawing.Point(72, 287);
            this.gammaDownButton.Name = "gammaDownButton";
            this.gammaDownButton.Size = new System.Drawing.Size(54, 23);
            this.gammaDownButton.TabIndex = 10;
            this.gammaDownButton.Text = "- Gam";
            this.gammaDownButton.UseVisualStyleBackColor = true;
            this.gammaDownButton.Click += new System.EventHandler(this.gammaDownButton_Click);
            // 
            // gammaUpButton
            // 
            this.gammaUpButton.Location = new System.Drawing.Point(12, 287);
            this.gammaUpButton.Name = "gammaUpButton";
            this.gammaUpButton.Size = new System.Drawing.Size(54, 23);
            this.gammaUpButton.TabIndex = 9;
            this.gammaUpButton.Text = "+ Gam";
            this.gammaUpButton.UseVisualStyleBackColor = true;
            this.gammaUpButton.Click += new System.EventHandler(this.gammaUpButton_Click);
            // 
            // contrastLabel
            // 
            this.contrastLabel.AutoSize = true;
            this.contrastLabel.Location = new System.Drawing.Point(133, 321);
            this.contrastLabel.Name = "contrastLabel";
            this.contrastLabel.Size = new System.Drawing.Size(13, 13);
            this.contrastLabel.TabIndex = 14;
            this.contrastLabel.Text = "0";
            // 
            // contrastDownButton
            // 
            this.contrastDownButton.Location = new System.Drawing.Point(72, 316);
            this.contrastDownButton.Name = "contrastDownButton";
            this.contrastDownButton.Size = new System.Drawing.Size(54, 23);
            this.contrastDownButton.TabIndex = 13;
            this.contrastDownButton.Text = "- Cont";
            this.contrastDownButton.UseVisualStyleBackColor = true;
            this.contrastDownButton.Click += new System.EventHandler(this.contrastDownButton_Click);
            // 
            // contrastUpButton
            // 
            this.contrastUpButton.Location = new System.Drawing.Point(12, 316);
            this.contrastUpButton.Name = "contrastUpButton";
            this.contrastUpButton.Size = new System.Drawing.Size(54, 23);
            this.contrastUpButton.TabIndex = 12;
            this.contrastUpButton.Text = "+ Cont";
            this.contrastUpButton.UseVisualStyleBackColor = true;
            this.contrastUpButton.Click += new System.EventHandler(this.contrastUpButton_Click);
            // 
            // captureButton
            // 
            this.captureButton.Location = new System.Drawing.Point(12, 345);
            this.captureButton.Name = "captureButton";
            this.captureButton.Size = new System.Drawing.Size(156, 23);
            this.captureButton.TabIndex = 15;
            this.captureButton.Text = "Capture New Image";
            this.captureButton.UseVisualStyleBackColor = true;
            this.captureButton.Click += new System.EventHandler(this.captureButton_Click);
            // 
            // resizeToolStripMenuItem
            // 
            this.resizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.defaultToolStripMenuItem,
            this.x480ToolStripMenuItem,
            this.x600ToolStripMenuItem,
            this.x768ToolStripMenuItem,
            this.x960ToolStripMenuItem});
            this.resizeToolStripMenuItem.Name = "resizeToolStripMenuItem";
            this.resizeToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.resizeToolStripMenuItem.Text = "Resize";
            // 
            // defaultToolStripMenuItem
            // 
            this.defaultToolStripMenuItem.Name = "defaultToolStripMenuItem";
            this.defaultToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.defaultToolStripMenuItem.Text = "Default";
            this.defaultToolStripMenuItem.Click += new System.EventHandler(this.defaultToolStripMenuItem_Click);
            // 
            // x480ToolStripMenuItem
            // 
            this.x480ToolStripMenuItem.Name = "x480ToolStripMenuItem";
            this.x480ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x480ToolStripMenuItem.Text = "640x480";
            this.x480ToolStripMenuItem.Click += new System.EventHandler(this.x480ToolStripMenuItem_Click);
            // 
            // x600ToolStripMenuItem
            // 
            this.x600ToolStripMenuItem.Name = "x600ToolStripMenuItem";
            this.x600ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x600ToolStripMenuItem.Text = "800x600";
            this.x600ToolStripMenuItem.Click += new System.EventHandler(this.x600ToolStripMenuItem_Click);
            // 
            // x768ToolStripMenuItem
            // 
            this.x768ToolStripMenuItem.Name = "x768ToolStripMenuItem";
            this.x768ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x768ToolStripMenuItem.Text = "1024x768";
            this.x768ToolStripMenuItem.Click += new System.EventHandler(this.x768ToolStripMenuItem_Click);
            // 
            // x960ToolStripMenuItem
            // 
            this.x960ToolStripMenuItem.Name = "x960ToolStripMenuItem";
            this.x960ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.x960ToolStripMenuItem.Text = "1280x960";
            this.x960ToolStripMenuItem.Click += new System.EventHandler(this.x960ToolStripMenuItem_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 387);
            this.ControlBox = false;
            this.Controls.Add(this.captureButton);
            this.Controls.Add(this.contrastLabel);
            this.Controls.Add(this.contrastDownButton);
            this.Controls.Add(this.contrastUpButton);
            this.Controls.Add(this.gammaLabel);
            this.Controls.Add(this.gammaDownButton);
            this.Controls.Add(this.gammaUpButton);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.brighnessLabel);
            this.Controls.Add(this.darkenButton);
            this.Controls.Add(this.lightenButton);
            this.Controls.Add(this.camImagePictureBox);
            this.Controls.Add(this.logTextBox);
            this.Controls.Add(this.connectButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ClientForm";
            this.ShowInTaskbar = false;
            this.Text = "Cam Viewer";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ClientForm_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ClientForm_FormClosing);
            this.Resize += new System.EventHandler(this.ClientForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.camImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eventLog1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox logTextBox;
        private System.Windows.Forms.PictureBox camImagePictureBox;
        private System.Windows.Forms.Button stopButton;
        private System.Diagnostics.EventLog eventLog1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem darkenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lightenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem greyScaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertColorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contrastDownToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaUpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gammaDownToolStripMenuItem;
        private System.Windows.Forms.Button darkenButton;
        private System.Windows.Forms.Button lightenButton;
        private System.Windows.Forms.Label brighnessLabel;
        private System.Windows.Forms.Label contrastLabel;
        private System.Windows.Forms.Button contrastDownButton;
        private System.Windows.Forms.Button contrastUpButton;
        private System.Windows.Forms.Label gammaLabel;
        private System.Windows.Forms.Button gammaDownButton;
        private System.Windows.Forms.Button gammaUpButton;
        private System.Windows.Forms.Button captureButton;
        private System.Windows.Forms.ToolStripMenuItem resizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem defaultToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x480ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x600ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x768ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x960ToolStripMenuItem;
    }
}

