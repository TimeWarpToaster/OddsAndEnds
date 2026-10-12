
namespace PostgreTesting
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
            this.tabMain = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.gbMainOptions = new System.Windows.Forms.GroupBox();
            this.cbUseDbFunction = new System.Windows.Forms.CheckBox();
            this.tbMinSelectId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnMainSelect = new System.Windows.Forms.Button();
            this.tbInsertQty = new System.Windows.Forms.TextBox();
            this.btnMainInsertModel = new System.Windows.Forms.Button();
            this.lblInsertQty = new System.Windows.Forms.Label();
            this.tbSelectQty = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMaxSelectId = new System.Windows.Forms.TextBox();
            this.lblMaxSelectId = new System.Windows.Forms.Label();
            this.lblMainRowsOut = new System.Windows.Forms.Label();
            this.lblMainRows = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnDynamicQuery = new System.Windows.Forms.Button();
            this.rtbMainQuery = new System.Windows.Forms.RichTextBox();
            this.webMainHtml = new System.Windows.Forms.WebBrowser();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbMainOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
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
            this.menuStrip1.Size = new System.Drawing.Size(1078, 28);
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
            this.tabControl1.Controls.Add(this.tabMain);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1078, 612);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.splitContainer2);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1070, 583);
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
            this.splitContainer2.Panel1.AutoScroll = true;
            this.splitContainer2.Panel1.Controls.Add(this.gbMainOptions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1064, 577);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbMainOptions
            // 
            this.gbMainOptions.Controls.Add(this.cbUseDbFunction);
            this.gbMainOptions.Controls.Add(this.tbMinSelectId);
            this.gbMainOptions.Controls.Add(this.label2);
            this.gbMainOptions.Controls.Add(this.btnMainSelect);
            this.gbMainOptions.Controls.Add(this.tbInsertQty);
            this.gbMainOptions.Controls.Add(this.btnMainInsertModel);
            this.gbMainOptions.Controls.Add(this.lblInsertQty);
            this.gbMainOptions.Controls.Add(this.tbSelectQty);
            this.gbMainOptions.Controls.Add(this.label1);
            this.gbMainOptions.Controls.Add(this.tbMaxSelectId);
            this.gbMainOptions.Controls.Add(this.lblMaxSelectId);
            this.gbMainOptions.Controls.Add(this.lblMainRowsOut);
            this.gbMainOptions.Controls.Add(this.lblMainRows);
            this.gbMainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainOptions.Location = new System.Drawing.Point(0, 0);
            this.gbMainOptions.Name = "gbMainOptions";
            this.gbMainOptions.Size = new System.Drawing.Size(175, 577);
            this.gbMainOptions.TabIndex = 0;
            this.gbMainOptions.TabStop = false;
            this.gbMainOptions.Text = "Options:  ";
            // 
            // cbUseDbFunction
            // 
            this.cbUseDbFunction.AutoSize = true;
            this.cbUseDbFunction.Checked = true;
            this.cbUseDbFunction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseDbFunction.Location = new System.Drawing.Point(13, 462);
            this.cbUseDbFunction.Name = "cbUseDbFunction";
            this.cbUseDbFunction.Size = new System.Drawing.Size(136, 21);
            this.cbUseDbFunction.TabIndex = 10;
            this.cbUseDbFunction.Text = "Use DB Function";
            this.cbUseDbFunction.UseVisualStyleBackColor = true;
            // 
            // tbMinSelectId
            // 
            this.tbMinSelectId.Location = new System.Drawing.Point(13, 272);
            this.tbMinSelectId.Name = "tbMinSelectId";
            this.tbMinSelectId.Size = new System.Drawing.Size(124, 22);
            this.tbMinSelectId.TabIndex = 9;
            this.tbMinSelectId.Text = "25001";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 252);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Min Select Id:  ";
            // 
            // btnMainSelect
            // 
            this.btnMainSelect.Location = new System.Drawing.Point(13, 421);
            this.btnMainSelect.Name = "btnMainSelect";
            this.btnMainSelect.Size = new System.Drawing.Size(124, 25);
            this.btnMainSelect.TabIndex = 2;
            this.btnMainSelect.Text = "SELECT";
            this.btnMainSelect.UseVisualStyleBackColor = true;
            this.btnMainSelect.Click += new System.EventHandler(this.btnMainSelect_Click);
            // 
            // tbInsertQty
            // 
            this.tbInsertQty.Location = new System.Drawing.Point(13, 119);
            this.tbInsertQty.Name = "tbInsertQty";
            this.tbInsertQty.Size = new System.Drawing.Size(121, 22);
            this.tbInsertQty.TabIndex = 7;
            this.tbInsertQty.Text = "100000";
            // 
            // btnMainInsertModel
            // 
            this.btnMainInsertModel.Location = new System.Drawing.Point(13, 159);
            this.btnMainInsertModel.Name = "btnMainInsertModel";
            this.btnMainInsertModel.Size = new System.Drawing.Size(121, 25);
            this.btnMainInsertModel.TabIndex = 1;
            this.btnMainInsertModel.Text = "INSERT";
            this.btnMainInsertModel.UseVisualStyleBackColor = true;
            this.btnMainInsertModel.Click += new System.EventHandler(this.btnMainQuery_Click);
            // 
            // lblInsertQty
            // 
            this.lblInsertQty.AutoSize = true;
            this.lblInsertQty.Location = new System.Drawing.Point(10, 98);
            this.lblInsertQty.Name = "lblInsertQty";
            this.lblInsertQty.Size = new System.Drawing.Size(73, 17);
            this.lblInsertQty.TabIndex = 6;
            this.lblInsertQty.Text = "Insert Qty:";
            // 
            // tbSelectQty
            // 
            this.tbSelectQty.Location = new System.Drawing.Point(13, 380);
            this.tbSelectQty.Name = "tbSelectQty";
            this.tbSelectQty.Size = new System.Drawing.Size(124, 22);
            this.tbSelectQty.TabIndex = 5;
            this.tbSelectQty.Text = "1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 360);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Qty:  ";
            // 
            // tbMaxSelectId
            // 
            this.tbMaxSelectId.Location = new System.Drawing.Point(13, 326);
            this.tbMaxSelectId.Name = "tbMaxSelectId";
            this.tbMaxSelectId.Size = new System.Drawing.Size(124, 22);
            this.tbMaxSelectId.TabIndex = 3;
            this.tbMaxSelectId.Text = "100000";
            // 
            // lblMaxSelectId
            // 
            this.lblMaxSelectId.AutoSize = true;
            this.lblMaxSelectId.Location = new System.Drawing.Point(10, 306);
            this.lblMaxSelectId.Name = "lblMaxSelectId";
            this.lblMaxSelectId.Size = new System.Drawing.Size(103, 17);
            this.lblMaxSelectId.TabIndex = 2;
            this.lblMaxSelectId.Text = "Max Select Id:  ";
            // 
            // lblMainRowsOut
            // 
            this.lblMainRowsOut.AutoSize = true;
            this.lblMainRowsOut.Location = new System.Drawing.Point(70, 46);
            this.lblMainRowsOut.Name = "lblMainRowsOut";
            this.lblMainRowsOut.Size = new System.Drawing.Size(45, 17);
            this.lblMainRowsOut.TabIndex = 1;
            this.lblMainRowsOut.Text = "Unset";
            // 
            // lblMainRows
            // 
            this.lblMainRows.AutoSize = true;
            this.lblMainRows.Location = new System.Drawing.Point(10, 46);
            this.lblMainRows.Name = "lblMainRows";
            this.lblMainRows.Size = new System.Drawing.Size(54, 17);
            this.lblMainRows.TabIndex = 0;
            this.lblMainRows.Text = "Rows:  ";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.webMainHtml);
            this.splitContainer3.Size = new System.Drawing.Size(885, 577);
            this.splitContainer3.SplitterDistance = 93;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.btnDynamicQuery);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.rtbMainQuery);
            this.splitContainer4.Size = new System.Drawing.Size(885, 93);
            this.splitContainer4.SplitterDistance = 75;
            this.splitContainer4.TabIndex = 0;
            // 
            // btnDynamicQuery
            // 
            this.btnDynamicQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDynamicQuery.Location = new System.Drawing.Point(0, 0);
            this.btnDynamicQuery.Name = "btnDynamicQuery";
            this.btnDynamicQuery.Size = new System.Drawing.Size(75, 93);
            this.btnDynamicQuery.TabIndex = 0;
            this.btnDynamicQuery.Text = "QUERY";
            this.btnDynamicQuery.UseVisualStyleBackColor = true;
            this.btnDynamicQuery.Click += new System.EventHandler(this.btnDynamicQuery_Click);
            // 
            // rtbMainQuery
            // 
            this.rtbMainQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMainQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))));
            this.rtbMainQuery.Location = new System.Drawing.Point(0, 0);
            this.rtbMainQuery.Name = "rtbMainQuery";
            this.rtbMainQuery.Size = new System.Drawing.Size(806, 93);
            this.rtbMainQuery.TabIndex = 0;
            this.rtbMainQuery.Text = "select * from TestTable T order by T.TestId desc limit 10;";
            // 
            // webMainHtml
            // 
            this.webMainHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMainHtml.Location = new System.Drawing.Point(0, 0);
            this.webMainHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMainHtml.Name = "webMainHtml";
            this.webMainHtml.Size = new System.Drawing.Size(885, 480);
            this.webMainHtml.TabIndex = 0;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.splitContainer1);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1070, 583);
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
            this.splitContainer1.Panel2.Controls.Add(this.lbLogs);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 577);
            this.splitContainer1.SplitterDistance = 76;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(554, 24);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(103, 26);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 16;
            this.lbLogs.Location = new System.Drawing.Point(0, 0);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(1064, 497);
            this.lbLogs.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 640);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbMainOptions.ResumeLayout(false);
            this.gbMainOptions.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabMain;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbMainOptions;
        private System.Windows.Forms.Label lblMainRowsOut;
        private System.Windows.Forms.Label lblMainRows;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btnMainInsertModel;
        private System.Windows.Forms.RichTextBox rtbMainQuery;
        private System.Windows.Forms.WebBrowser webMainHtml;
        private System.Windows.Forms.Button btnMainSelect;
        private System.Windows.Forms.TextBox tbSelectQty;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMaxSelectId;
        private System.Windows.Forms.Label lblMaxSelectId;
        private System.Windows.Forms.TextBox tbInsertQty;
        private System.Windows.Forms.Label lblInsertQty;
        private System.Windows.Forms.TextBox tbMinSelectId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox cbUseDbFunction;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnDynamicQuery;
    }
}

