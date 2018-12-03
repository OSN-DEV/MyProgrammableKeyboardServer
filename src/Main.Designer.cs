namespace MyProgamableKeyboardServer {
    partial class Main {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.cUrl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cPortNo = new System.Windows.Forms.TextBox();
            this.cApply = new System.Windows.Forms.Button();
            this.cExit = new System.Windows.Forms.Button();
            this.cClose = new System.Windows.Forms.Button();
            this.cNotify = new System.Windows.Forms.NotifyIcon(this.components);
            this.cTasktrayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cTasktrayMenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cTasktrayMenuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.cTasktrayMenuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.cTasktrayMenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.cStart = new System.Windows.Forms.Button();
            this.cStop = new System.Windows.Forms.Button();
            this.cTasktrayMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // cUrl
            // 
            this.cUrl.BackColor = System.Drawing.Color.White;
            this.cUrl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.cUrl.Location = new System.Drawing.Point(12, 9);
            this.cUrl.Name = "cUrl";
            this.cUrl.Size = new System.Drawing.Size(270, 70);
            this.cUrl.TabIndex = 0;
            this.cUrl.Text = "http://www.hoge.jp";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Port No";
            // 
            // cPortNo
            // 
            this.cPortNo.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cPortNo.Location = new System.Drawing.Point(84, 103);
            this.cPortNo.MaxLength = 5;
            this.cPortNo.Name = "cPortNo";
            this.cPortNo.Size = new System.Drawing.Size(60, 24);
            this.cPortNo.TabIndex = 2;
            this.cPortNo.Text = "12345";
            // 
            // cApply
            // 
            this.cApply.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cApply.Location = new System.Drawing.Point(150, 103);
            this.cApply.Name = "cApply";
            this.cApply.Size = new System.Drawing.Size(57, 23);
            this.cApply.TabIndex = 3;
            this.cApply.Text = "Apply";
            this.cApply.UseVisualStyleBackColor = true;
            this.cApply.Click += new System.EventHandler(this.cApply_Click);
            // 
            // cExit
            // 
            this.cExit.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cExit.Location = new System.Drawing.Point(150, 149);
            this.cExit.Name = "cExit";
            this.cExit.Size = new System.Drawing.Size(57, 23);
            this.cExit.TabIndex = 4;
            this.cExit.Text = "Exit";
            this.cExit.UseVisualStyleBackColor = true;
            this.cExit.Click += new System.EventHandler(this.cExit_Click);
            // 
            // cClose
            // 
            this.cClose.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cClose.Location = new System.Drawing.Point(225, 149);
            this.cClose.Name = "cClose";
            this.cClose.Size = new System.Drawing.Size(57, 23);
            this.cClose.TabIndex = 5;
            this.cClose.Text = "Close";
            this.cClose.UseVisualStyleBackColor = true;
            this.cClose.Click += new System.EventHandler(this.cClose_Click);
            // 
            // cNotify
            // 
            this.cNotify.ContextMenuStrip = this.cTasktrayMenu;
            this.cNotify.Icon = ((System.Drawing.Icon)(resources.GetObject("cNotify.Icon")));
            this.cNotify.Text = "notifyIcon1";
            this.cNotify.Visible = true;
            // 
            // cTasktrayMenu
            // 
            this.cTasktrayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cTasktrayMenuSetting,
            this.toolStripSeparator1,
            this.cTasktrayMenuStart,
            this.cTasktrayMenuStop,
            this.toolStripSeparator2,
            this.cTasktrayMenuExit});
            this.cTasktrayMenu.Name = "cTasktrayMenu";
            this.cTasktrayMenu.Size = new System.Drawing.Size(112, 104);
            this.cTasktrayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.cTasktrayMenu_Opening);
            // 
            // cTasktrayMenuSetting
            // 
            this.cTasktrayMenuSetting.Name = "cTasktrayMenuSetting";
            this.cTasktrayMenuSetting.Size = new System.Drawing.Size(111, 22);
            this.cTasktrayMenuSetting.Text = "Setting";
            this.cTasktrayMenuSetting.Click += new System.EventHandler(this.cTasktrayMenuSetting_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(108, 6);
            // 
            // cTasktrayMenuStart
            // 
            this.cTasktrayMenuStart.Name = "cTasktrayMenuStart";
            this.cTasktrayMenuStart.Size = new System.Drawing.Size(111, 22);
            this.cTasktrayMenuStart.Text = "Start";
            this.cTasktrayMenuStart.Click += new System.EventHandler(this.cTasktrayMenuStart_Click);
            // 
            // cTasktrayMenuStop
            // 
            this.cTasktrayMenuStop.Name = "cTasktrayMenuStop";
            this.cTasktrayMenuStop.Size = new System.Drawing.Size(111, 22);
            this.cTasktrayMenuStop.Text = "Stop";
            this.cTasktrayMenuStop.Click += new System.EventHandler(this.cTasktrayMenuStop_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(108, 6);
            // 
            // cTasktrayMenuExit
            // 
            this.cTasktrayMenuExit.Name = "cTasktrayMenuExit";
            this.cTasktrayMenuExit.Size = new System.Drawing.Size(111, 22);
            this.cTasktrayMenuExit.Text = "Exit";
            this.cTasktrayMenuExit.Click += new System.EventHandler(this.cTasktrayMenuExit_Click);
            // 
            // cStart
            // 
            this.cStart.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cStart.Location = new System.Drawing.Point(15, 149);
            this.cStart.Name = "cStart";
            this.cStart.Size = new System.Drawing.Size(57, 23);
            this.cStart.TabIndex = 6;
            this.cStart.Text = "Start";
            this.cStart.UseVisualStyleBackColor = true;
            this.cStart.Click += new System.EventHandler(this.cStart_Click);
            // 
            // cStop
            // 
            this.cStop.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.cStop.Location = new System.Drawing.Point(78, 149);
            this.cStop.Name = "cStop";
            this.cStop.Size = new System.Drawing.Size(57, 23);
            this.cStop.TabIndex = 7;
            this.cStop.Text = "Stop";
            this.cStop.UseVisualStyleBackColor = true;
            this.cStop.Click += new System.EventHandler(this.cStop_Click);
            // 
            // Main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(294, 189);
            this.Controls.Add(this.cStop);
            this.Controls.Add(this.cStart);
            this.Controls.Add(this.cClose);
            this.Controls.Add(this.cExit);
            this.Controls.Add(this.cApply);
            this.Controls.Add(this.cPortNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cUrl);
            this.Font = new System.Drawing.Font("Meiryo UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Activated += new System.EventHandler(this.Main_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.Load += new System.EventHandler(this.Main_Load);
            this.cTasktrayMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label cUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox cPortNo;
        private System.Windows.Forms.Button cApply;
        private System.Windows.Forms.Button cExit;
        private System.Windows.Forms.Button cClose;
        private System.Windows.Forms.NotifyIcon cNotify;
        private System.Windows.Forms.ContextMenuStrip cTasktrayMenu;
        private System.Windows.Forms.ToolStripMenuItem cTasktrayMenuSetting;
        private System.Windows.Forms.ToolStripMenuItem cTasktrayMenuStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem cTasktrayMenuStart;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem cTasktrayMenuExit;
        private System.Windows.Forms.Button cStart;
        private System.Windows.Forms.Button cStop;
    }
}