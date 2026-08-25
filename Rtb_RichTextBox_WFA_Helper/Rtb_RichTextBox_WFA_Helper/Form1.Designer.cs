
namespace Rtb_RichTextBox_WFA_Helper
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabDocument = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbDocument = new System.Windows.Forms.RichTextBox();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.rtbMain = new System.Windows.Forms.RichTextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.rtbNotARealApp = new System.Windows.Forms.RichTextBox();
            this.rtbLicense = new System.Windows.Forms.RichTextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabDocument.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabAbout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1134, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabDocument);
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1134, 549);
            this.tabControl1.TabIndex = 1;
            // 
            // tabDocument
            // 
            this.tabDocument.Controls.Add(this.panel1);
            this.tabDocument.Location = new System.Drawing.Point(4, 25);
            this.tabDocument.Name = "tabDocument";
            this.tabDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tabDocument.Size = new System.Drawing.Size(1126, 520);
            this.tabDocument.TabIndex = 2;
            this.tabDocument.Text = "Document";
            this.tabDocument.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rtbDocument);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.panel1.Size = new System.Drawing.Size(1120, 514);
            this.panel1.TabIndex = 1;
            // 
            // rtbDocument
            // 
            this.rtbDocument.AcceptsTab = true;
            this.rtbDocument.BackColor = System.Drawing.SystemColors.Window;
            this.rtbDocument.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbDocument.Location = new System.Drawing.Point(20, 10);
            this.rtbDocument.Name = "rtbDocument";
            this.rtbDocument.Size = new System.Drawing.Size(1080, 499);
            this.rtbDocument.TabIndex = 0;
            this.rtbDocument.Text = "";
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.rtbMain);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1126, 518);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Testing Scratchpad";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // rtbMain
            // 
            this.rtbMain.AcceptsTab = true;
            this.rtbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMain.Location = new System.Drawing.Point(3, 3);
            this.rtbMain.Name = "rtbMain";
            this.rtbMain.Size = new System.Drawing.Size(1120, 512);
            this.rtbMain.TabIndex = 0;
            this.rtbMain.Text = "";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.btnClearLogs);
            this.tabLogs.Controls.Add(this.rtbLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1126, 518);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(996, 6);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(122, 38);
            this.btnClearLogs.TabIndex = 1;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // rtbLogs
            // 
            this.rtbLogs.AcceptsTab = true;
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbLogs.Location = new System.Drawing.Point(3, 50);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(1120, 465);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.splitContainer1);
            this.tabAbout.Location = new System.Drawing.Point(4, 25);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(1126, 520);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // rtbNotARealApp
            // 
            this.rtbNotARealApp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbNotARealApp.Enabled = false;
            this.rtbNotARealApp.Location = new System.Drawing.Point(0, 0);
            this.rtbNotARealApp.Name = "rtbNotARealApp";
            this.rtbNotARealApp.Size = new System.Drawing.Size(1120, 39);
            this.rtbNotARealApp.TabIndex = 1;
            this.rtbNotARealApp.Text = "Note:  This is not a real app of any purpose or function, other than to accompany" +
    " buildable sources and allow for testing and illustration.";
            // 
            // rtbLicense
            // 
            this.rtbLicense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLicense.Location = new System.Drawing.Point(0, 0);
            this.rtbLicense.Name = "rtbLicense";
            this.rtbLicense.Size = new System.Drawing.Size(1120, 471);
            this.rtbLicense.TabIndex = 0;
            this.rtbLicense.Text = "";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.rtbNotARealApp);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbLicense);
            this.splitContainer1.Size = new System.Drawing.Size(1120, 514);
            this.splitContainer1.SplitterDistance = 39;
            this.splitContainer1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 577);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Rtb RichTextBox Windows Forms Helper";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabDocument.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.RichTextBox rtbMain;
        private System.Windows.Forms.TabPage tabDocument;
        private System.Windows.Forms.RichTextBox rtbDocument;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.RichTextBox rtbLicense;
        private System.Windows.Forms.RichTextBox rtbNotARealApp;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}

