//Algorithmic Encryptor v01
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html


namespace AlgorithmicEncryptor_01
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabMain = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btnReadKey = new System.Windows.Forms.Button();
            this.btnSaveKey = new System.Windows.Forms.Button();
            this.btnGetMsgDecoded = new System.Windows.Forms.Button();
            this.btnGetMsgEncoded = new System.Windows.Forms.Button();
            this.btnMessageMath = new System.Windows.Forms.Button();
            this.btnGetMessageNumbers = new System.Windows.Forms.Button();
            this.btnCreateKey = new System.Windows.Forms.Button();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabKey = new System.Windows.Forms.TabPage();
            this.rtbCurrentKey = new System.Windows.Forms.RichTextBox();
            this.tabMessageIn = new System.Windows.Forms.TabPage();
            this.rtbMessageIn = new System.Windows.Forms.RichTextBox();
            this.tabMessageNumbers = new System.Windows.Forms.TabPage();
            this.rtbMessageNumbers = new System.Windows.Forms.RichTextBox();
            this.tabMessageMath = new System.Windows.Forms.TabPage();
            this.rtbMessageMath = new System.Windows.Forms.RichTextBox();
            this.tabMessageEncoded = new System.Windows.Forms.TabPage();
            this.rtbMessageEncoded = new System.Windows.Forms.RichTextBox();
            this.tabMessageDecoded = new System.Windows.Forms.TabPage();
            this.rtbMessageDecoded = new System.Windows.Forms.RichTextBox();
            this.tabInstructions = new System.Windows.Forms.TabPage();
            this.rtbInstructions = new System.Windows.Forms.RichTextBox();
            this.rtbCurrentKey2 = new System.Windows.Forms.RichTextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.rtbLogsOut = new System.Windows.Forms.RichTextBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabKey.SuspendLayout();
            this.tabMessageIn.SuspendLayout();
            this.tabMessageNumbers.SuspendLayout();
            this.tabMessageMath.SuspendLayout();
            this.tabMessageEncoded.SuspendLayout();
            this.tabMessageDecoded.SuspendLayout();
            this.tabInstructions.SuspendLayout();
            this.tabLogs.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1293, 28);
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
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Location = new System.Drawing.Point(0, 683);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1293, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1293, 655);
            this.tabControl1.TabIndex = 2;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.splitContainer2);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1285, 626);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btnReadKey);
            this.splitContainer2.Panel1.Controls.Add(this.btnSaveKey);
            this.splitContainer2.Panel1.Controls.Add(this.btnGetMsgDecoded);
            this.splitContainer2.Panel1.Controls.Add(this.btnGetMsgEncoded);
            this.splitContainer2.Panel1.Controls.Add(this.btnMessageMath);
            this.splitContainer2.Panel1.Controls.Add(this.btnGetMessageNumbers);
            this.splitContainer2.Panel1.Controls.Add(this.btnCreateKey);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1279, 620);
            this.splitContainer2.SplitterDistance = 192;
            this.splitContainer2.TabIndex = 0;
            // 
            // btnReadKey
            // 
            this.btnReadKey.Location = new System.Drawing.Point(26, 531);
            this.btnReadKey.Name = "btnReadKey";
            this.btnReadKey.Size = new System.Drawing.Size(138, 39);
            this.btnReadKey.TabIndex = 6;
            this.btnReadKey.Text = "Read Key";
            this.btnReadKey.UseVisualStyleBackColor = true;
            this.btnReadKey.Click += new System.EventHandler(this.btnReadKey_Click);
            // 
            // btnSaveKey
            // 
            this.btnSaveKey.Location = new System.Drawing.Point(26, 486);
            this.btnSaveKey.Name = "btnSaveKey";
            this.btnSaveKey.Size = new System.Drawing.Size(138, 39);
            this.btnSaveKey.TabIndex = 5;
            this.btnSaveKey.Text = "Save Key";
            this.btnSaveKey.UseVisualStyleBackColor = true;
            this.btnSaveKey.Click += new System.EventHandler(this.btnSaveKey_Click);
            // 
            // btnGetMsgDecoded
            // 
            this.btnGetMsgDecoded.Location = new System.Drawing.Point(26, 205);
            this.btnGetMsgDecoded.Name = "btnGetMsgDecoded";
            this.btnGetMsgDecoded.Size = new System.Drawing.Size(138, 39);
            this.btnGetMsgDecoded.TabIndex = 4;
            this.btnGetMsgDecoded.Text = "Get Decoded";
            this.btnGetMsgDecoded.UseVisualStyleBackColor = true;
            this.btnGetMsgDecoded.Click += new System.EventHandler(this.btnGetMsgDecoded_Click);
            // 
            // btnGetMsgEncoded
            // 
            this.btnGetMsgEncoded.Location = new System.Drawing.Point(26, 160);
            this.btnGetMsgEncoded.Name = "btnGetMsgEncoded";
            this.btnGetMsgEncoded.Size = new System.Drawing.Size(138, 39);
            this.btnGetMsgEncoded.TabIndex = 3;
            this.btnGetMsgEncoded.Text = "Get Msg Encoded";
            this.btnGetMsgEncoded.UseVisualStyleBackColor = true;
            this.btnGetMsgEncoded.Click += new System.EventHandler(this.btnGetMsgEncoded_Click);
            // 
            // btnMessageMath
            // 
            this.btnMessageMath.Location = new System.Drawing.Point(26, 115);
            this.btnMessageMath.Name = "btnMessageMath";
            this.btnMessageMath.Size = new System.Drawing.Size(138, 39);
            this.btnMessageMath.TabIndex = 2;
            this.btnMessageMath.Text = "Get Msg Math";
            this.btnMessageMath.UseVisualStyleBackColor = true;
            this.btnMessageMath.Click += new System.EventHandler(this.btnMessageMath_Click);
            // 
            // btnGetMessageNumbers
            // 
            this.btnGetMessageNumbers.Location = new System.Drawing.Point(26, 70);
            this.btnGetMessageNumbers.Name = "btnGetMessageNumbers";
            this.btnGetMessageNumbers.Size = new System.Drawing.Size(138, 39);
            this.btnGetMessageNumbers.TabIndex = 1;
            this.btnGetMessageNumbers.Text = "Get Msg Numbers";
            this.btnGetMessageNumbers.UseVisualStyleBackColor = true;
            this.btnGetMessageNumbers.Click += new System.EventHandler(this.btnGetMessageNumbers_Click);
            // 
            // btnCreateKey
            // 
            this.btnCreateKey.Location = new System.Drawing.Point(26, 25);
            this.btnCreateKey.Name = "btnCreateKey";
            this.btnCreateKey.Size = new System.Drawing.Size(138, 39);
            this.btnCreateKey.TabIndex = 0;
            this.btnCreateKey.Text = "Create Key";
            this.btnCreateKey.UseVisualStyleBackColor = true;
            this.btnCreateKey.Click += new System.EventHandler(this.btnCreateKey_Click);
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.rtbCurrentKey2);
            this.splitContainer3.Size = new System.Drawing.Size(1083, 620);
            this.splitContainer3.SplitterDistance = 433;
            this.splitContainer3.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabKey);
            this.tabControl2.Controls.Add(this.tabMessageIn);
            this.tabControl2.Controls.Add(this.tabMessageNumbers);
            this.tabControl2.Controls.Add(this.tabMessageMath);
            this.tabControl2.Controls.Add(this.tabMessageEncoded);
            this.tabControl2.Controls.Add(this.tabMessageDecoded);
            this.tabControl2.Controls.Add(this.tabInstructions);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(433, 620);
            this.tabControl2.TabIndex = 0;
            // 
            // tabKey
            // 
            this.tabKey.Controls.Add(this.rtbCurrentKey);
            this.tabKey.Location = new System.Drawing.Point(4, 25);
            this.tabKey.Name = "tabKey";
            this.tabKey.Padding = new System.Windows.Forms.Padding(3);
            this.tabKey.Size = new System.Drawing.Size(425, 591);
            this.tabKey.TabIndex = 0;
            this.tabKey.Text = "Current Key";
            this.tabKey.UseVisualStyleBackColor = true;
            // 
            // rtbCurrentKey
            // 
            this.rtbCurrentKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCurrentKey.Location = new System.Drawing.Point(3, 3);
            this.rtbCurrentKey.Name = "rtbCurrentKey";
            this.rtbCurrentKey.Size = new System.Drawing.Size(419, 585);
            this.rtbCurrentKey.TabIndex = 0;
            this.rtbCurrentKey.Text = "";
            // 
            // tabMessageIn
            // 
            this.tabMessageIn.Controls.Add(this.rtbMessageIn);
            this.tabMessageIn.Location = new System.Drawing.Point(4, 25);
            this.tabMessageIn.Name = "tabMessageIn";
            this.tabMessageIn.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageIn.Size = new System.Drawing.Size(425, 589);
            this.tabMessageIn.TabIndex = 1;
            this.tabMessageIn.Text = "Message In";
            this.tabMessageIn.UseVisualStyleBackColor = true;
            // 
            // rtbMessageIn
            // 
            this.rtbMessageIn.AcceptsTab = true;
            this.rtbMessageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageIn.Location = new System.Drawing.Point(3, 3);
            this.rtbMessageIn.Name = "rtbMessageIn";
            this.rtbMessageIn.Size = new System.Drawing.Size(419, 583);
            this.rtbMessageIn.TabIndex = 0;
            this.rtbMessageIn.Text = "";
            // 
            // tabMessageNumbers
            // 
            this.tabMessageNumbers.Controls.Add(this.rtbMessageNumbers);
            this.tabMessageNumbers.Location = new System.Drawing.Point(4, 25);
            this.tabMessageNumbers.Name = "tabMessageNumbers";
            this.tabMessageNumbers.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageNumbers.Size = new System.Drawing.Size(425, 589);
            this.tabMessageNumbers.TabIndex = 2;
            this.tabMessageNumbers.Text = "Message Numbers";
            this.tabMessageNumbers.UseVisualStyleBackColor = true;
            // 
            // rtbMessageNumbers
            // 
            this.rtbMessageNumbers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageNumbers.Location = new System.Drawing.Point(3, 3);
            this.rtbMessageNumbers.Name = "rtbMessageNumbers";
            this.rtbMessageNumbers.Size = new System.Drawing.Size(419, 583);
            this.rtbMessageNumbers.TabIndex = 0;
            this.rtbMessageNumbers.Text = "";
            // 
            // tabMessageMath
            // 
            this.tabMessageMath.Controls.Add(this.rtbMessageMath);
            this.tabMessageMath.Location = new System.Drawing.Point(4, 25);
            this.tabMessageMath.Name = "tabMessageMath";
            this.tabMessageMath.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageMath.Size = new System.Drawing.Size(425, 589);
            this.tabMessageMath.TabIndex = 3;
            this.tabMessageMath.Text = "Message Math";
            this.tabMessageMath.UseVisualStyleBackColor = true;
            // 
            // rtbMessageMath
            // 
            this.rtbMessageMath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageMath.Location = new System.Drawing.Point(3, 3);
            this.rtbMessageMath.Name = "rtbMessageMath";
            this.rtbMessageMath.Size = new System.Drawing.Size(419, 583);
            this.rtbMessageMath.TabIndex = 0;
            this.rtbMessageMath.Text = "";
            // 
            // tabMessageEncoded
            // 
            this.tabMessageEncoded.Controls.Add(this.rtbMessageEncoded);
            this.tabMessageEncoded.Location = new System.Drawing.Point(4, 25);
            this.tabMessageEncoded.Name = "tabMessageEncoded";
            this.tabMessageEncoded.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageEncoded.Size = new System.Drawing.Size(425, 589);
            this.tabMessageEncoded.TabIndex = 4;
            this.tabMessageEncoded.Text = "Message Encoded";
            this.tabMessageEncoded.UseVisualStyleBackColor = true;
            // 
            // rtbMessageEncoded
            // 
            this.rtbMessageEncoded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageEncoded.Location = new System.Drawing.Point(3, 3);
            this.rtbMessageEncoded.Name = "rtbMessageEncoded";
            this.rtbMessageEncoded.Size = new System.Drawing.Size(419, 583);
            this.rtbMessageEncoded.TabIndex = 0;
            this.rtbMessageEncoded.Text = "";
            // 
            // tabMessageDecoded
            // 
            this.tabMessageDecoded.Controls.Add(this.rtbMessageDecoded);
            this.tabMessageDecoded.Location = new System.Drawing.Point(4, 25);
            this.tabMessageDecoded.Name = "tabMessageDecoded";
            this.tabMessageDecoded.Padding = new System.Windows.Forms.Padding(3);
            this.tabMessageDecoded.Size = new System.Drawing.Size(425, 589);
            this.tabMessageDecoded.TabIndex = 5;
            this.tabMessageDecoded.Text = "Message Decoded";
            this.tabMessageDecoded.UseVisualStyleBackColor = true;
            // 
            // rtbMessageDecoded
            // 
            this.rtbMessageDecoded.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMessageDecoded.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMessageDecoded.Location = new System.Drawing.Point(3, 3);
            this.rtbMessageDecoded.Name = "rtbMessageDecoded";
            this.rtbMessageDecoded.Size = new System.Drawing.Size(419, 583);
            this.rtbMessageDecoded.TabIndex = 0;
            this.rtbMessageDecoded.Text = "";
            // 
            // tabInstructions
            // 
            this.tabInstructions.Controls.Add(this.rtbInstructions);
            this.tabInstructions.Location = new System.Drawing.Point(4, 25);
            this.tabInstructions.Name = "tabInstructions";
            this.tabInstructions.Padding = new System.Windows.Forms.Padding(3);
            this.tabInstructions.Size = new System.Drawing.Size(425, 589);
            this.tabInstructions.TabIndex = 6;
            this.tabInstructions.Text = "Instructions";
            this.tabInstructions.UseVisualStyleBackColor = true;
            // 
            // rtbInstructions
            // 
            this.rtbInstructions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbInstructions.Location = new System.Drawing.Point(3, 3);
            this.rtbInstructions.Name = "rtbInstructions";
            this.rtbInstructions.ReadOnly = true;
            this.rtbInstructions.Size = new System.Drawing.Size(419, 583);
            this.rtbInstructions.TabIndex = 0;
            this.rtbInstructions.Text = "";
            // 
            // rtbCurrentKey2
            // 
            this.rtbCurrentKey2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbCurrentKey2.Location = new System.Drawing.Point(0, 0);
            this.rtbCurrentKey2.Name = "rtbCurrentKey2";
            this.rtbCurrentKey2.Size = new System.Drawing.Size(646, 620);
            this.rtbCurrentKey2.TabIndex = 0;
            this.rtbCurrentKey2.Text = "";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.splitContainer1);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1285, 624);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.btnClearLogs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbLogsOut);
            this.splitContainer1.Size = new System.Drawing.Size(1279, 618);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(584, 38);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(139, 36);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // rtbLogsOut
            // 
            this.rtbLogsOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogsOut.Location = new System.Drawing.Point(0, 0);
            this.rtbLogsOut.Name = "rtbLogsOut";
            this.rtbLogsOut.Size = new System.Drawing.Size(1279, 517);
            this.rtbLogsOut.TabIndex = 0;
            this.rtbLogsOut.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1293, 705);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Algorithmic Encryptor v01";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabKey.ResumeLayout(false);
            this.tabMessageIn.ResumeLayout(false);
            this.tabMessageNumbers.ResumeLayout(false);
            this.tabMessageMath.ResumeLayout(false);
            this.tabMessageEncoded.ResumeLayout(false);
            this.tabMessageDecoded.ResumeLayout(false);
            this.tabInstructions.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.RichTextBox rtbLogsOut;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCreateKey;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabKey;
        private System.Windows.Forms.RichTextBox rtbCurrentKey;
        private System.Windows.Forms.TabPage tabMessageIn;
        private System.Windows.Forms.RichTextBox rtbMessageIn;
        private System.Windows.Forms.TabPage tabMessageNumbers;
        private System.Windows.Forms.RichTextBox rtbMessageNumbers;
        private System.Windows.Forms.TabPage tabMessageMath;
        private System.Windows.Forms.RichTextBox rtbMessageMath;
        private System.Windows.Forms.TabPage tabMessageEncoded;
        private System.Windows.Forms.RichTextBox rtbMessageEncoded;
        private System.Windows.Forms.TabPage tabMessageDecoded;
        private System.Windows.Forms.RichTextBox rtbMessageDecoded;
        private System.Windows.Forms.RichTextBox rtbCurrentKey2;
        private System.Windows.Forms.Button btnGetMessageNumbers;
        private System.Windows.Forms.Button btnMessageMath;
        private System.Windows.Forms.Button btnGetMsgEncoded;
        private System.Windows.Forms.Button btnGetMsgDecoded;
        private System.Windows.Forms.Button btnSaveKey;
        private System.Windows.Forms.Button btnReadKey;
        private System.Windows.Forms.TabPage tabInstructions;
        private System.Windows.Forms.RichTextBox rtbInstructions;
    }
}

