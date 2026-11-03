
namespace DBTest
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
            this.rbSelectByDateRange = new System.Windows.Forms.RadioButton();
            this.rbSelectBySerialNum = new System.Windows.Forms.RadioButton();
            this.rbSelectByTestId = new System.Windows.Forms.RadioButton();
            this.lblSelectBy = new System.Windows.Forms.Label();
            this.lblEngineOut = new System.Windows.Forms.Label();
            this.lblEngine = new System.Windows.Forms.Label();
            this.btnDropRecreate = new System.Windows.Forms.Button();
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
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.btnDynamicQuery = new System.Windows.Forms.Button();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabQuery = new System.Windows.Forms.TabPage();
            this.rtbMainQuery = new System.Windows.Forms.RichTextBox();
            this.tabDBSelect = new System.Windows.Forms.TabPage();
            this.btnDBSelectConnect = new System.Windows.Forms.Button();
            this.btnDBSelectRestoreCurrent = new System.Windows.Forms.Button();
            this.btnSaveConnectionString = new System.Windows.Forms.Button();
            this.tbDBSelectConnectString = new System.Windows.Forms.TextBox();
            this.lblDBSelectConnectString = new System.Windows.Forms.Label();
            this.rbDBSelectSQLite = new System.Windows.Forms.RadioButton();
            this.rbDBSelectPostgre = new System.Windows.Forms.RadioButton();
            this.rbDBSelectMSSQL = new System.Windows.Forms.RadioButton();
            this.rbDBSelectMySQL = new System.Windows.Forms.RadioButton();
            this.rbDBSelectMariaDB = new System.Windows.Forms.RadioButton();
            this.tabAdditionalTests = new System.Windows.Forms.TabPage();
            this.btnGetIndexes = new System.Windows.Forms.Button();
            this.btnOrdinal = new System.Windows.Forms.Button();
            this.btnNonQuery = new System.Windows.Forms.Button();
            this.btnCountTable = new System.Windows.Forms.Button();
            this.btnInsertSingle = new System.Windows.Forms.Button();
            this.webMainHtml = new System.Windows.Forms.WebBrowser();
            this.tabAutomation = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.gbAutomationOptions = new System.Windows.Forms.GroupBox();
            this.pnlAutomationOptions = new System.Windows.Forms.Panel();
            this.numSelectDateRange = new System.Windows.Forms.NumericUpDown();
            this.label31 = new System.Windows.Forms.Label();
            this.btnAutomateDBAll = new System.Windows.Forms.Button();
            this.cbAutomateSQLite = new System.Windows.Forms.CheckBox();
            this.cbAutomatePostgre = new System.Windows.Forms.CheckBox();
            this.cbAutomateMySQL = new System.Windows.Forms.CheckBox();
            this.cbAutomateMSSQL = new System.Windows.Forms.CheckBox();
            this.cbAutomateMariaDB = new System.Windows.Forms.CheckBox();
            this.lblAutomationDBSelect = new System.Windows.Forms.Label();
            this.btnStopAutomation = new System.Windows.Forms.Button();
            this.btnPauseAutomation = new System.Windows.Forms.Button();
            this.btnStartAutomation = new System.Windows.Forms.Button();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblAutomationSeqSelect = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numUpdate10K = new System.Windows.Forms.NumericUpDown();
            this.numUpdate1K = new System.Windows.Forms.NumericUpDown();
            this.numUpdate100 = new System.Windows.Forms.NumericUpDown();
            this.numUpdate1 = new System.Windows.Forms.NumericUpDown();
            this.numSelectVarchar25K = new System.Windows.Forms.NumericUpDown();
            this.numSelectVarchar10K = new System.Windows.Forms.NumericUpDown();
            this.numSelectVarchar1K = new System.Windows.Forms.NumericUpDown();
            this.numSelectVarchar100 = new System.Windows.Forms.NumericUpDown();
            this.numSelectVarchar1 = new System.Windows.Forms.NumericUpDown();
            this.numSelect25KNS = new System.Windows.Forms.NumericUpDown();
            this.numSelect10KNS = new System.Windows.Forms.NumericUpDown();
            this.numSelect1KNS = new System.Windows.Forms.NumericUpDown();
            this.numSelect100NS = new System.Windows.Forms.NumericUpDown();
            this.numSelect1NS = new System.Windows.Forms.NumericUpDown();
            this.numSelect25KS = new System.Windows.Forms.NumericUpDown();
            this.numSelect10KS = new System.Windows.Forms.NumericUpDown();
            this.numSelect1KS = new System.Windows.Forms.NumericUpDown();
            this.numSelect100S = new System.Windows.Forms.NumericUpDown();
            this.numSelect1S = new System.Windows.Forms.NumericUpDown();
            this.numInsert10M = new System.Windows.Forms.NumericUpDown();
            this.numInsert1M = new System.Windows.Forms.NumericUpDown();
            this.numInsert100K = new System.Windows.Forms.NumericUpDown();
            this.numInsert10K = new System.Windows.Forms.NumericUpDown();
            this.numInsert1K = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.gbAutomationLogs = new System.Windows.Forms.GroupBox();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.btnAutomationClearLogs = new System.Windows.Forms.Button();
            this.lbAutomationLogs = new System.Windows.Forms.ListBox();
            this.rtbAutomationOutput = new System.Windows.Forms.RichTextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
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
            this.tabControl2.SuspendLayout();
            this.tabQuery.SuspendLayout();
            this.tabDBSelect.SuspendLayout();
            this.tabAdditionalTests.SuspendLayout();
            this.tabAutomation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.gbAutomationOptions.SuspendLayout();
            this.pnlAutomationOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectDateRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate10K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate1K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar25K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar10K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar1K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar100)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect25KNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect10KNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1KNS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect100NS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1NS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect25KS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect10KS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1KS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect100S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1S)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert10M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert1M)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert100K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert10K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert1K)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel1.SuspendLayout();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.gbAutomationLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
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
            this.tabControl1.Controls.Add(this.tabAutomation);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1078, 725);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.splitContainer2);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3);
            this.tabMain.Size = new System.Drawing.Size(1070, 696);
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
            this.splitContainer2.Size = new System.Drawing.Size(1064, 690);
            this.splitContainer2.SplitterDistance = 175;
            this.splitContainer2.TabIndex = 0;
            // 
            // gbMainOptions
            // 
            this.gbMainOptions.Controls.Add(this.rbSelectByDateRange);
            this.gbMainOptions.Controls.Add(this.rbSelectBySerialNum);
            this.gbMainOptions.Controls.Add(this.rbSelectByTestId);
            this.gbMainOptions.Controls.Add(this.lblSelectBy);
            this.gbMainOptions.Controls.Add(this.lblEngineOut);
            this.gbMainOptions.Controls.Add(this.lblEngine);
            this.gbMainOptions.Controls.Add(this.btnDropRecreate);
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
            this.gbMainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbMainOptions.Location = new System.Drawing.Point(0, 0);
            this.gbMainOptions.Name = "gbMainOptions";
            this.gbMainOptions.Size = new System.Drawing.Size(175, 690);
            this.gbMainOptions.TabIndex = 0;
            this.gbMainOptions.TabStop = false;
            this.gbMainOptions.Text = "Options:  ";
            // 
            // rbSelectByDateRange
            // 
            this.rbSelectByDateRange.AutoSize = true;
            this.rbSelectByDateRange.Location = new System.Drawing.Point(13, 539);
            this.rbSelectByDateRange.Name = "rbSelectByDateRange";
            this.rbSelectByDateRange.Size = new System.Drawing.Size(165, 21);
            this.rbSelectByDateRange.TabIndex = 17;
            this.rbSelectByDateRange.Text = "CDT - datetime range";
            this.rbSelectByDateRange.UseVisualStyleBackColor = true;
            // 
            // rbSelectBySerialNum
            // 
            this.rbSelectBySerialNum.AutoSize = true;
            this.rbSelectBySerialNum.Location = new System.Drawing.Point(13, 512);
            this.rbSelectBySerialNum.Name = "rbSelectBySerialNum";
            this.rbSelectBySerialNum.Size = new System.Drawing.Size(181, 21);
            this.rbSelectBySerialNum.TabIndex = 16;
            this.rbSelectBySerialNum.Text = "SerialNum - varchar(40)";
            this.rbSelectBySerialNum.UseVisualStyleBackColor = true;
            // 
            // rbSelectByTestId
            // 
            this.rbSelectByTestId.AutoSize = true;
            this.rbSelectByTestId.Checked = true;
            this.rbSelectByTestId.Location = new System.Drawing.Point(13, 485);
            this.rbSelectByTestId.Name = "rbSelectByTestId";
            this.rbSelectByTestId.Size = new System.Drawing.Size(115, 21);
            this.rbSelectByTestId.TabIndex = 15;
            this.rbSelectByTestId.TabStop = true;
            this.rbSelectByTestId.Text = "TestId - bigint";
            this.rbSelectByTestId.UseVisualStyleBackColor = true;
            // 
            // lblSelectBy
            // 
            this.lblSelectBy.AutoSize = true;
            this.lblSelectBy.Location = new System.Drawing.Point(10, 464);
            this.lblSelectBy.Name = "lblSelectBy";
            this.lblSelectBy.Size = new System.Drawing.Size(79, 17);
            this.lblSelectBy.TabIndex = 14;
            this.lblSelectBy.Text = "Select By:  ";
            // 
            // lblEngineOut
            // 
            this.lblEngineOut.AutoSize = true;
            this.lblEngineOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEngineOut.Location = new System.Drawing.Point(27, 39);
            this.lblEngineOut.Name = "lblEngineOut";
            this.lblEngineOut.Size = new System.Drawing.Size(97, 24);
            this.lblEngineOut.TabIndex = 13;
            this.lblEngineOut.Text = "Unknown";
            // 
            // lblEngine
            // 
            this.lblEngine.AutoSize = true;
            this.lblEngine.Location = new System.Drawing.Point(7, 22);
            this.lblEngine.Name = "lblEngine";
            this.lblEngine.Size = new System.Drawing.Size(56, 17);
            this.lblEngine.TabIndex = 12;
            this.lblEngine.Text = "Engine:";
            // 
            // btnDropRecreate
            // 
            this.btnDropRecreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDropRecreate.Location = new System.Drawing.Point(13, 659);
            this.btnDropRecreate.Name = "btnDropRecreate";
            this.btnDropRecreate.Size = new System.Drawing.Size(162, 25);
            this.btnDropRecreate.TabIndex = 11;
            this.btnDropRecreate.Text = "DROP RECREATE";
            this.btnDropRecreate.UseVisualStyleBackColor = true;
            this.btnDropRecreate.Click += new System.EventHandler(this.btnDropRecreate_Click);
            // 
            // cbUseDbFunction
            // 
            this.cbUseDbFunction.AutoSize = true;
            this.cbUseDbFunction.Checked = true;
            this.cbUseDbFunction.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUseDbFunction.Location = new System.Drawing.Point(13, 420);
            this.cbUseDbFunction.Name = "cbUseDbFunction";
            this.cbUseDbFunction.Size = new System.Drawing.Size(136, 21);
            this.cbUseDbFunction.TabIndex = 10;
            this.cbUseDbFunction.Text = "Use DB Function";
            this.cbUseDbFunction.UseVisualStyleBackColor = true;
            this.cbUseDbFunction.Visible = false;
            // 
            // tbMinSelectId
            // 
            this.tbMinSelectId.Location = new System.Drawing.Point(13, 230);
            this.tbMinSelectId.Name = "tbMinSelectId";
            this.tbMinSelectId.Size = new System.Drawing.Size(124, 22);
            this.tbMinSelectId.TabIndex = 9;
            this.tbMinSelectId.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Min Select Id:  ";
            // 
            // btnMainSelect
            // 
            this.btnMainSelect.Location = new System.Drawing.Point(13, 379);
            this.btnMainSelect.Name = "btnMainSelect";
            this.btnMainSelect.Size = new System.Drawing.Size(124, 25);
            this.btnMainSelect.TabIndex = 2;
            this.btnMainSelect.Text = "SELECT";
            this.btnMainSelect.UseVisualStyleBackColor = true;
            this.btnMainSelect.Click += new System.EventHandler(this.btnMainSelect_Click);
            // 
            // tbInsertQty
            // 
            this.tbInsertQty.Location = new System.Drawing.Point(13, 123);
            this.tbInsertQty.Name = "tbInsertQty";
            this.tbInsertQty.Size = new System.Drawing.Size(121, 22);
            this.tbInsertQty.TabIndex = 7;
            this.tbInsertQty.Text = "100000";
            // 
            // btnMainInsertModel
            // 
            this.btnMainInsertModel.Location = new System.Drawing.Point(13, 163);
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
            this.lblInsertQty.Location = new System.Drawing.Point(10, 102);
            this.lblInsertQty.Name = "lblInsertQty";
            this.lblInsertQty.Size = new System.Drawing.Size(73, 17);
            this.lblInsertQty.TabIndex = 6;
            this.lblInsertQty.Text = "Insert Qty:";
            // 
            // tbSelectQty
            // 
            this.tbSelectQty.Location = new System.Drawing.Point(13, 338);
            this.tbSelectQty.Name = "tbSelectQty";
            this.tbSelectQty.Size = new System.Drawing.Size(124, 22);
            this.tbSelectQty.TabIndex = 5;
            this.tbSelectQty.Text = "100";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 318);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Select Qty:  ";
            // 
            // tbMaxSelectId
            // 
            this.tbMaxSelectId.Location = new System.Drawing.Point(13, 284);
            this.tbMaxSelectId.Name = "tbMaxSelectId";
            this.tbMaxSelectId.Size = new System.Drawing.Size(124, 22);
            this.tbMaxSelectId.TabIndex = 3;
            this.tbMaxSelectId.Text = "1000";
            // 
            // lblMaxSelectId
            // 
            this.lblMaxSelectId.AutoSize = true;
            this.lblMaxSelectId.Location = new System.Drawing.Point(10, 264);
            this.lblMaxSelectId.Name = "lblMaxSelectId";
            this.lblMaxSelectId.Size = new System.Drawing.Size(103, 17);
            this.lblMaxSelectId.TabIndex = 2;
            this.lblMaxSelectId.Text = "Max Select Id:  ";
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
            this.splitContainer3.Size = new System.Drawing.Size(885, 690);
            this.splitContainer3.SplitterDistance = 116;
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
            this.splitContainer4.Panel2.Controls.Add(this.tabControl2);
            this.splitContainer4.Size = new System.Drawing.Size(885, 116);
            this.splitContainer4.SplitterDistance = 75;
            this.splitContainer4.TabIndex = 0;
            // 
            // btnDynamicQuery
            // 
            this.btnDynamicQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDynamicQuery.Location = new System.Drawing.Point(0, 0);
            this.btnDynamicQuery.Name = "btnDynamicQuery";
            this.btnDynamicQuery.Size = new System.Drawing.Size(75, 116);
            this.btnDynamicQuery.TabIndex = 0;
            this.btnDynamicQuery.Text = "QUERY";
            this.btnDynamicQuery.UseVisualStyleBackColor = true;
            this.btnDynamicQuery.Click += new System.EventHandler(this.btnDynamicQuery_Click);
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabQuery);
            this.tabControl2.Controls.Add(this.tabDBSelect);
            this.tabControl2.Controls.Add(this.tabAdditionalTests);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(806, 116);
            this.tabControl2.TabIndex = 0;
            // 
            // tabQuery
            // 
            this.tabQuery.Controls.Add(this.rtbMainQuery);
            this.tabQuery.Location = new System.Drawing.Point(4, 25);
            this.tabQuery.Name = "tabQuery";
            this.tabQuery.Padding = new System.Windows.Forms.Padding(3);
            this.tabQuery.Size = new System.Drawing.Size(798, 87);
            this.tabQuery.TabIndex = 0;
            this.tabQuery.Text = "Query";
            this.tabQuery.UseVisualStyleBackColor = true;
            // 
            // rtbMainQuery
            // 
            this.rtbMainQuery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbMainQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbMainQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(120)))));
            this.rtbMainQuery.Location = new System.Drawing.Point(3, 3);
            this.rtbMainQuery.Name = "rtbMainQuery";
            this.rtbMainQuery.Size = new System.Drawing.Size(792, 81);
            this.rtbMainQuery.TabIndex = 0;
            this.rtbMainQuery.Text = "select * from TestTable T order by T.TestId desc limit 10;";
            // 
            // tabDBSelect
            // 
            this.tabDBSelect.Controls.Add(this.btnDBSelectConnect);
            this.tabDBSelect.Controls.Add(this.btnDBSelectRestoreCurrent);
            this.tabDBSelect.Controls.Add(this.btnSaveConnectionString);
            this.tabDBSelect.Controls.Add(this.tbDBSelectConnectString);
            this.tabDBSelect.Controls.Add(this.lblDBSelectConnectString);
            this.tabDBSelect.Controls.Add(this.rbDBSelectSQLite);
            this.tabDBSelect.Controls.Add(this.rbDBSelectPostgre);
            this.tabDBSelect.Controls.Add(this.rbDBSelectMSSQL);
            this.tabDBSelect.Controls.Add(this.rbDBSelectMySQL);
            this.tabDBSelect.Controls.Add(this.rbDBSelectMariaDB);
            this.tabDBSelect.Location = new System.Drawing.Point(4, 25);
            this.tabDBSelect.Name = "tabDBSelect";
            this.tabDBSelect.Padding = new System.Windows.Forms.Padding(3);
            this.tabDBSelect.Size = new System.Drawing.Size(798, 87);
            this.tabDBSelect.TabIndex = 1;
            this.tabDBSelect.Text = "DB Select";
            this.tabDBSelect.UseVisualStyleBackColor = true;
            // 
            // btnDBSelectConnect
            // 
            this.btnDBSelectConnect.Location = new System.Drawing.Point(259, 56);
            this.btnDBSelectConnect.Name = "btnDBSelectConnect";
            this.btnDBSelectConnect.Size = new System.Drawing.Size(191, 27);
            this.btnDBSelectConnect.TabIndex = 9;
            this.btnDBSelectConnect.Text = "Connect";
            this.btnDBSelectConnect.UseVisualStyleBackColor = true;
            this.btnDBSelectConnect.Click += new System.EventHandler(this.btnDBSelectConnect_Click);
            // 
            // btnDBSelectRestoreCurrent
            // 
            this.btnDBSelectRestoreCurrent.Location = new System.Drawing.Point(456, 55);
            this.btnDBSelectRestoreCurrent.Name = "btnDBSelectRestoreCurrent";
            this.btnDBSelectRestoreCurrent.Size = new System.Drawing.Size(131, 28);
            this.btnDBSelectRestoreCurrent.TabIndex = 8;
            this.btnDBSelectRestoreCurrent.Text = "Restore Current";
            this.btnDBSelectRestoreCurrent.UseVisualStyleBackColor = true;
            this.btnDBSelectRestoreCurrent.Click += new System.EventHandler(this.btnDBSelectRestoreCurrent_Click);
            // 
            // btnSaveConnectionString
            // 
            this.btnSaveConnectionString.Location = new System.Drawing.Point(593, 55);
            this.btnSaveConnectionString.Name = "btnSaveConnectionString";
            this.btnSaveConnectionString.Size = new System.Drawing.Size(139, 28);
            this.btnSaveConnectionString.TabIndex = 7;
            this.btnSaveConnectionString.Text = "Save Connection";
            this.btnSaveConnectionString.UseVisualStyleBackColor = true;
            this.btnSaveConnectionString.Click += new System.EventHandler(this.btnSaveConnectionString_Click);
            // 
            // tbDBSelectConnectString
            // 
            this.tbDBSelectConnectString.Location = new System.Drawing.Point(259, 27);
            this.tbDBSelectConnectString.Name = "tbDBSelectConnectString";
            this.tbDBSelectConnectString.Size = new System.Drawing.Size(473, 22);
            this.tbDBSelectConnectString.TabIndex = 6;
            this.tbDBSelectConnectString.Leave += new System.EventHandler(this.tbDBSelectConnectString_Leave);
            // 
            // lblDBSelectConnectString
            // 
            this.lblDBSelectConnectString.AutoSize = true;
            this.lblDBSelectConnectString.Location = new System.Drawing.Point(256, 7);
            this.lblDBSelectConnectString.Name = "lblDBSelectConnectString";
            this.lblDBSelectConnectString.Size = new System.Drawing.Size(113, 17);
            this.lblDBSelectConnectString.TabIndex = 5;
            this.lblDBSelectConnectString.Text = "Connect String:  ";
            // 
            // rbDBSelectSQLite
            // 
            this.rbDBSelectSQLite.AutoSize = true;
            this.rbDBSelectSQLite.Location = new System.Drawing.Point(138, 35);
            this.rbDBSelectSQLite.Name = "rbDBSelectSQLite";
            this.rbDBSelectSQLite.Size = new System.Drawing.Size(72, 21);
            this.rbDBSelectSQLite.TabIndex = 4;
            this.rbDBSelectSQLite.Text = "SQLite";
            this.rbDBSelectSQLite.UseVisualStyleBackColor = true;
            this.rbDBSelectSQLite.CheckedChanged += new System.EventHandler(this.rbDbSelect_CheckedChanged);
            // 
            // rbDBSelectPostgre
            // 
            this.rbDBSelectPostgre.AutoSize = true;
            this.rbDBSelectPostgre.Location = new System.Drawing.Point(138, 7);
            this.rbDBSelectPostgre.Name = "rbDBSelectPostgre";
            this.rbDBSelectPostgre.Size = new System.Drawing.Size(78, 21);
            this.rbDBSelectPostgre.TabIndex = 3;
            this.rbDBSelectPostgre.Text = "Postgre";
            this.rbDBSelectPostgre.UseVisualStyleBackColor = true;
            this.rbDBSelectPostgre.CheckedChanged += new System.EventHandler(this.rbDbSelect_CheckedChanged);
            // 
            // rbDBSelectMSSQL
            // 
            this.rbDBSelectMSSQL.AutoSize = true;
            this.rbDBSelectMSSQL.Location = new System.Drawing.Point(7, 35);
            this.rbDBSelectMSSQL.Name = "rbDBSelectMSSQL";
            this.rbDBSelectMSSQL.Size = new System.Drawing.Size(77, 21);
            this.rbDBSelectMSSQL.TabIndex = 2;
            this.rbDBSelectMSSQL.Text = "MSSQL";
            this.rbDBSelectMSSQL.UseVisualStyleBackColor = true;
            this.rbDBSelectMSSQL.CheckedChanged += new System.EventHandler(this.rbDbSelect_CheckedChanged);
            // 
            // rbDBSelectMySQL
            // 
            this.rbDBSelectMySQL.AutoSize = true;
            this.rbDBSelectMySQL.Location = new System.Drawing.Point(7, 62);
            this.rbDBSelectMySQL.Name = "rbDBSelectMySQL";
            this.rbDBSelectMySQL.Size = new System.Drawing.Size(75, 21);
            this.rbDBSelectMySQL.TabIndex = 1;
            this.rbDBSelectMySQL.Text = "MySQL";
            this.rbDBSelectMySQL.UseVisualStyleBackColor = true;
            this.rbDBSelectMySQL.CheckedChanged += new System.EventHandler(this.rbDbSelect_CheckedChanged);
            // 
            // rbDBSelectMariaDB
            // 
            this.rbDBSelectMariaDB.AutoSize = true;
            this.rbDBSelectMariaDB.Location = new System.Drawing.Point(7, 7);
            this.rbDBSelectMariaDB.Name = "rbDBSelectMariaDB";
            this.rbDBSelectMariaDB.Size = new System.Drawing.Size(87, 21);
            this.rbDBSelectMariaDB.TabIndex = 0;
            this.rbDBSelectMariaDB.Text = "Maria DB";
            this.rbDBSelectMariaDB.UseVisualStyleBackColor = true;
            this.rbDBSelectMariaDB.CheckedChanged += new System.EventHandler(this.rbDbSelect_CheckedChanged);
            // 
            // tabAdditionalTests
            // 
            this.tabAdditionalTests.Controls.Add(this.btnGetIndexes);
            this.tabAdditionalTests.Controls.Add(this.btnOrdinal);
            this.tabAdditionalTests.Controls.Add(this.btnNonQuery);
            this.tabAdditionalTests.Controls.Add(this.btnCountTable);
            this.tabAdditionalTests.Controls.Add(this.btnInsertSingle);
            this.tabAdditionalTests.Location = new System.Drawing.Point(4, 25);
            this.tabAdditionalTests.Name = "tabAdditionalTests";
            this.tabAdditionalTests.Padding = new System.Windows.Forms.Padding(3);
            this.tabAdditionalTests.Size = new System.Drawing.Size(798, 87);
            this.tabAdditionalTests.TabIndex = 3;
            this.tabAdditionalTests.Text = "Additional Tests";
            this.tabAdditionalTests.UseVisualStyleBackColor = true;
            // 
            // btnGetIndexes
            // 
            this.btnGetIndexes.Location = new System.Drawing.Point(270, 7);
            this.btnGetIndexes.Name = "btnGetIndexes";
            this.btnGetIndexes.Size = new System.Drawing.Size(112, 28);
            this.btnGetIndexes.TabIndex = 4;
            this.btnGetIndexes.Text = "Get Indexes";
            this.btnGetIndexes.UseVisualStyleBackColor = true;
            this.btnGetIndexes.Click += new System.EventHandler(this.btnGetIndexes_Click);
            // 
            // btnOrdinal
            // 
            this.btnOrdinal.Location = new System.Drawing.Point(152, 37);
            this.btnOrdinal.Name = "btnOrdinal";
            this.btnOrdinal.Size = new System.Drawing.Size(112, 28);
            this.btnOrdinal.TabIndex = 3;
            this.btnOrdinal.Text = "Ordinal";
            this.btnOrdinal.UseVisualStyleBackColor = true;
            this.btnOrdinal.Click += new System.EventHandler(this.btnOrdinal_Click);
            // 
            // btnNonQuery
            // 
            this.btnNonQuery.Location = new System.Drawing.Point(152, 7);
            this.btnNonQuery.Name = "btnNonQuery";
            this.btnNonQuery.Size = new System.Drawing.Size(112, 28);
            this.btnNonQuery.TabIndex = 2;
            this.btnNonQuery.Text = "Non Query";
            this.btnNonQuery.UseVisualStyleBackColor = true;
            this.btnNonQuery.Click += new System.EventHandler(this.btnNonQuery_Click);
            // 
            // btnCountTable
            // 
            this.btnCountTable.Location = new System.Drawing.Point(34, 37);
            this.btnCountTable.Name = "btnCountTable";
            this.btnCountTable.Size = new System.Drawing.Size(112, 28);
            this.btnCountTable.TabIndex = 1;
            this.btnCountTable.Text = "Count Table";
            this.btnCountTable.UseVisualStyleBackColor = true;
            this.btnCountTable.Click += new System.EventHandler(this.btnCountTable_Click);
            // 
            // btnInsertSingle
            // 
            this.btnInsertSingle.Location = new System.Drawing.Point(34, 7);
            this.btnInsertSingle.Name = "btnInsertSingle";
            this.btnInsertSingle.Size = new System.Drawing.Size(112, 28);
            this.btnInsertSingle.TabIndex = 0;
            this.btnInsertSingle.Text = "Insert Single";
            this.btnInsertSingle.UseVisualStyleBackColor = true;
            this.btnInsertSingle.Click += new System.EventHandler(this.btnInsertSingle_Click);
            // 
            // webMainHtml
            // 
            this.webMainHtml.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webMainHtml.Location = new System.Drawing.Point(0, 0);
            this.webMainHtml.MinimumSize = new System.Drawing.Size(20, 20);
            this.webMainHtml.Name = "webMainHtml";
            this.webMainHtml.Size = new System.Drawing.Size(885, 570);
            this.webMainHtml.TabIndex = 0;
            // 
            // tabAutomation
            // 
            this.tabAutomation.Controls.Add(this.splitContainer5);
            this.tabAutomation.Location = new System.Drawing.Point(4, 25);
            this.tabAutomation.Name = "tabAutomation";
            this.tabAutomation.Padding = new System.Windows.Forms.Padding(3);
            this.tabAutomation.Size = new System.Drawing.Size(1070, 696);
            this.tabAutomation.TabIndex = 2;
            this.tabAutomation.Text = "Automation";
            this.tabAutomation.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.AutoScroll = true;
            this.splitContainer5.Panel1.Controls.Add(this.gbAutomationOptions);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(1064, 690);
            this.splitContainer5.SplitterDistance = 210;
            this.splitContainer5.TabIndex = 0;
            // 
            // gbAutomationOptions
            // 
            this.gbAutomationOptions.Controls.Add(this.pnlAutomationOptions);
            this.gbAutomationOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAutomationOptions.Location = new System.Drawing.Point(0, 0);
            this.gbAutomationOptions.Name = "gbAutomationOptions";
            this.gbAutomationOptions.Size = new System.Drawing.Size(210, 690);
            this.gbAutomationOptions.TabIndex = 0;
            this.gbAutomationOptions.TabStop = false;
            this.gbAutomationOptions.Text = "Automation Options: ";
            // 
            // pnlAutomationOptions
            // 
            this.pnlAutomationOptions.AutoScroll = true;
            this.pnlAutomationOptions.Controls.Add(this.numSelectDateRange);
            this.pnlAutomationOptions.Controls.Add(this.label31);
            this.pnlAutomationOptions.Controls.Add(this.btnAutomateDBAll);
            this.pnlAutomationOptions.Controls.Add(this.cbAutomateSQLite);
            this.pnlAutomationOptions.Controls.Add(this.cbAutomatePostgre);
            this.pnlAutomationOptions.Controls.Add(this.cbAutomateMySQL);
            this.pnlAutomationOptions.Controls.Add(this.cbAutomateMSSQL);
            this.pnlAutomationOptions.Controls.Add(this.cbAutomateMariaDB);
            this.pnlAutomationOptions.Controls.Add(this.lblAutomationDBSelect);
            this.pnlAutomationOptions.Controls.Add(this.btnStopAutomation);
            this.pnlAutomationOptions.Controls.Add(this.btnPauseAutomation);
            this.pnlAutomationOptions.Controls.Add(this.btnStartAutomation);
            this.pnlAutomationOptions.Controls.Add(this.label27);
            this.pnlAutomationOptions.Controls.Add(this.label28);
            this.pnlAutomationOptions.Controls.Add(this.label29);
            this.pnlAutomationOptions.Controls.Add(this.label30);
            this.pnlAutomationOptions.Controls.Add(this.label26);
            this.pnlAutomationOptions.Controls.Add(this.label21);
            this.pnlAutomationOptions.Controls.Add(this.label22);
            this.pnlAutomationOptions.Controls.Add(this.label23);
            this.pnlAutomationOptions.Controls.Add(this.label24);
            this.pnlAutomationOptions.Controls.Add(this.label25);
            this.pnlAutomationOptions.Controls.Add(this.label20);
            this.pnlAutomationOptions.Controls.Add(this.label19);
            this.pnlAutomationOptions.Controls.Add(this.label18);
            this.pnlAutomationOptions.Controls.Add(this.label17);
            this.pnlAutomationOptions.Controls.Add(this.label16);
            this.pnlAutomationOptions.Controls.Add(this.label15);
            this.pnlAutomationOptions.Controls.Add(this.label14);
            this.pnlAutomationOptions.Controls.Add(this.label13);
            this.pnlAutomationOptions.Controls.Add(this.label12);
            this.pnlAutomationOptions.Controls.Add(this.label11);
            this.pnlAutomationOptions.Controls.Add(this.label10);
            this.pnlAutomationOptions.Controls.Add(this.label9);
            this.pnlAutomationOptions.Controls.Add(this.lblAutomationSeqSelect);
            this.pnlAutomationOptions.Controls.Add(this.label8);
            this.pnlAutomationOptions.Controls.Add(this.label7);
            this.pnlAutomationOptions.Controls.Add(this.label6);
            this.pnlAutomationOptions.Controls.Add(this.label5);
            this.pnlAutomationOptions.Controls.Add(this.numUpdate10K);
            this.pnlAutomationOptions.Controls.Add(this.numUpdate1K);
            this.pnlAutomationOptions.Controls.Add(this.numUpdate100);
            this.pnlAutomationOptions.Controls.Add(this.numUpdate1);
            this.pnlAutomationOptions.Controls.Add(this.numSelectVarchar25K);
            this.pnlAutomationOptions.Controls.Add(this.numSelectVarchar10K);
            this.pnlAutomationOptions.Controls.Add(this.numSelectVarchar1K);
            this.pnlAutomationOptions.Controls.Add(this.numSelectVarchar100);
            this.pnlAutomationOptions.Controls.Add(this.numSelectVarchar1);
            this.pnlAutomationOptions.Controls.Add(this.numSelect25KNS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect10KNS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect1KNS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect100NS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect1NS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect25KS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect10KS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect1KS);
            this.pnlAutomationOptions.Controls.Add(this.numSelect100S);
            this.pnlAutomationOptions.Controls.Add(this.numSelect1S);
            this.pnlAutomationOptions.Controls.Add(this.numInsert10M);
            this.pnlAutomationOptions.Controls.Add(this.numInsert1M);
            this.pnlAutomationOptions.Controls.Add(this.numInsert100K);
            this.pnlAutomationOptions.Controls.Add(this.numInsert10K);
            this.pnlAutomationOptions.Controls.Add(this.numInsert1K);
            this.pnlAutomationOptions.Controls.Add(this.label4);
            this.pnlAutomationOptions.Controls.Add(this.label3);
            this.pnlAutomationOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAutomationOptions.Location = new System.Drawing.Point(3, 18);
            this.pnlAutomationOptions.Name = "pnlAutomationOptions";
            this.pnlAutomationOptions.Size = new System.Drawing.Size(204, 669);
            this.pnlAutomationOptions.TabIndex = 0;
            // 
            // numSelectDateRange
            // 
            this.numSelectDateRange.Location = new System.Drawing.Point(63, 1132);
            this.numSelectDateRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectDateRange.Name = "numSelectDateRange";
            this.numSelectDateRange.Size = new System.Drawing.Size(108, 22);
            this.numSelectDateRange.TabIndex = 67;
            this.numSelectDateRange.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(8, 1098);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(127, 17);
            this.label31.TabIndex = 66;
            this.label31.Text = "Select Date Range";
            // 
            // btnAutomateDBAll
            // 
            this.btnAutomateDBAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutomateDBAll.Location = new System.Drawing.Point(101, 163);
            this.btnAutomateDBAll.Name = "btnAutomateDBAll";
            this.btnAutomateDBAll.Size = new System.Drawing.Size(70, 21);
            this.btnAutomateDBAll.TabIndex = 65;
            this.btnAutomateDBAll.Text = "ALL";
            this.btnAutomateDBAll.UseVisualStyleBackColor = true;
            this.btnAutomateDBAll.Click += new System.EventHandler(this.btnAutomateDBAll_Click);
            // 
            // cbAutomateSQLite
            // 
            this.cbAutomateSQLite.AutoSize = true;
            this.cbAutomateSQLite.Location = new System.Drawing.Point(11, 271);
            this.cbAutomateSQLite.Name = "cbAutomateSQLite";
            this.cbAutomateSQLite.Size = new System.Drawing.Size(73, 21);
            this.cbAutomateSQLite.TabIndex = 64;
            this.cbAutomateSQLite.Text = "SQLite";
            this.cbAutomateSQLite.UseVisualStyleBackColor = true;
            // 
            // cbAutomatePostgre
            // 
            this.cbAutomatePostgre.AutoSize = true;
            this.cbAutomatePostgre.Location = new System.Drawing.Point(11, 244);
            this.cbAutomatePostgre.Name = "cbAutomatePostgre";
            this.cbAutomatePostgre.Size = new System.Drawing.Size(79, 21);
            this.cbAutomatePostgre.TabIndex = 63;
            this.cbAutomatePostgre.Text = "Postgre";
            this.cbAutomatePostgre.UseVisualStyleBackColor = true;
            // 
            // cbAutomateMySQL
            // 
            this.cbAutomateMySQL.AutoSize = true;
            this.cbAutomateMySQL.Location = new System.Drawing.Point(11, 217);
            this.cbAutomateMySQL.Name = "cbAutomateMySQL";
            this.cbAutomateMySQL.Size = new System.Drawing.Size(76, 21);
            this.cbAutomateMySQL.TabIndex = 62;
            this.cbAutomateMySQL.Text = "MySQL";
            this.cbAutomateMySQL.UseVisualStyleBackColor = true;
            // 
            // cbAutomateMSSQL
            // 
            this.cbAutomateMSSQL.AutoSize = true;
            this.cbAutomateMSSQL.Location = new System.Drawing.Point(11, 190);
            this.cbAutomateMSSQL.Name = "cbAutomateMSSQL";
            this.cbAutomateMSSQL.Size = new System.Drawing.Size(78, 21);
            this.cbAutomateMSSQL.TabIndex = 61;
            this.cbAutomateMSSQL.Text = "MSSQL";
            this.cbAutomateMSSQL.UseVisualStyleBackColor = true;
            // 
            // cbAutomateMariaDB
            // 
            this.cbAutomateMariaDB.AutoSize = true;
            this.cbAutomateMariaDB.Location = new System.Drawing.Point(11, 163);
            this.cbAutomateMariaDB.Name = "cbAutomateMariaDB";
            this.cbAutomateMariaDB.Size = new System.Drawing.Size(84, 21);
            this.cbAutomateMariaDB.TabIndex = 60;
            this.cbAutomateMariaDB.Text = "MariaDB";
            this.cbAutomateMariaDB.UseVisualStyleBackColor = true;
            // 
            // lblAutomationDBSelect
            // 
            this.lblAutomationDBSelect.AutoSize = true;
            this.lblAutomationDBSelect.Location = new System.Drawing.Point(8, 142);
            this.lblAutomationDBSelect.Name = "lblAutomationDBSelect";
            this.lblAutomationDBSelect.Size = new System.Drawing.Size(138, 17);
            this.lblAutomationDBSelect.TabIndex = 59;
            this.lblAutomationDBSelect.Text = "Database Selections";
            // 
            // btnStopAutomation
            // 
            this.btnStopAutomation.Location = new System.Drawing.Point(8, 90);
            this.btnStopAutomation.Name = "btnStopAutomation";
            this.btnStopAutomation.Size = new System.Drawing.Size(163, 30);
            this.btnStopAutomation.TabIndex = 58;
            this.btnStopAutomation.Text = "Stop";
            this.btnStopAutomation.UseVisualStyleBackColor = true;
            this.btnStopAutomation.Click += new System.EventHandler(this.btnStopAutomation_Click);
            // 
            // btnPauseAutomation
            // 
            this.btnPauseAutomation.Location = new System.Drawing.Point(8, 54);
            this.btnPauseAutomation.Name = "btnPauseAutomation";
            this.btnPauseAutomation.Size = new System.Drawing.Size(163, 30);
            this.btnPauseAutomation.TabIndex = 57;
            this.btnPauseAutomation.Text = "Pause";
            this.btnPauseAutomation.UseVisualStyleBackColor = true;
            this.btnPauseAutomation.Click += new System.EventHandler(this.btnPauseAutomation_Click);
            // 
            // btnStartAutomation
            // 
            this.btnStartAutomation.Location = new System.Drawing.Point(8, 18);
            this.btnStartAutomation.Name = "btnStartAutomation";
            this.btnStartAutomation.Size = new System.Drawing.Size(163, 30);
            this.btnStartAutomation.TabIndex = 56;
            this.btnStartAutomation.Text = "Start Automation";
            this.btnStartAutomation.UseVisualStyleBackColor = true;
            this.btnStartAutomation.Click += new System.EventHandler(this.btnStartAutomation_Click);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(5, 1293);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(33, 17);
            this.label27.TabIndex = 55;
            this.label27.Text = "10K";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(8, 1265);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(25, 17);
            this.label28.TabIndex = 54;
            this.label28.Text = "1K";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(5, 1237);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(32, 17);
            this.label29.TabIndex = 53;
            this.label29.Text = "100";
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(8, 1209);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(16, 17);
            this.label30.TabIndex = 52;
            this.label30.Text = "1";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(8, 1173);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(85, 17);
            this.label26.TabIndex = 51;
            this.label26.Text = "Update Row";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(8, 1050);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(33, 17);
            this.label21.TabIndex = 50;
            this.label21.Text = "25K";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(8, 1022);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(33, 17);
            this.label22.TabIndex = 49;
            this.label22.Text = "10K";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(8, 994);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 17);
            this.label23.TabIndex = 48;
            this.label23.Text = "1K";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(5, 966);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(32, 17);
            this.label24.TabIndex = 47;
            this.label24.Text = "100";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(8, 938);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(16, 17);
            this.label25.TabIndex = 46;
            this.label25.Text = "1";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(8, 902);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(101, 17);
            this.label20.TabIndex = 45;
            this.label20.Text = "Select Varchar";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(8, 853);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(33, 17);
            this.label19.TabIndex = 44;
            this.label19.Text = "25K";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 825);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(33, 17);
            this.label18.TabIndex = 43;
            this.label18.Text = "10K";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(8, 797);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(25, 17);
            this.label17.TabIndex = 42;
            this.label17.Text = "1K";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(5, 769);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 17);
            this.label16.TabIndex = 41;
            this.label16.Text = "100";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 741);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(16, 17);
            this.label15.TabIndex = 40;
            this.label15.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 706);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(149, 17);
            this.label14.TabIndex = 39;
            this.label14.Text = "Non-Sequential Select";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 576);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 17);
            this.label13.TabIndex = 38;
            this.label13.Text = "100";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 548);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(16, 17);
            this.label12.TabIndex = 37;
            this.label12.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 660);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(33, 17);
            this.label11.TabIndex = 36;
            this.label11.Text = "25K";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 632);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 35;
            this.label10.Text = "10K";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 604);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 17);
            this.label9.TabIndex = 34;
            this.label9.Text = "1K";
            // 
            // lblAutomationSeqSelect
            // 
            this.lblAutomationSeqSelect.AutoSize = true;
            this.lblAutomationSeqSelect.Location = new System.Drawing.Point(8, 513);
            this.lblAutomationSeqSelect.Name = "lblAutomationSeqSelect";
            this.lblAutomationSeqSelect.Size = new System.Drawing.Size(118, 17);
            this.lblAutomationSeqSelect.TabIndex = 33;
            this.lblAutomationSeqSelect.Text = "Sequential Select";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 465);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 17);
            this.label8.TabIndex = 32;
            this.label8.Text = "10M";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 17);
            this.label7.TabIndex = 31;
            this.label7.Text = "1M";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 409);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 17);
            this.label6.TabIndex = 30;
            this.label6.Text = "100K";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 29;
            this.label5.Text = "10K";
            // 
            // numUpdate10K
            // 
            this.numUpdate10K.Location = new System.Drawing.Point(63, 1291);
            this.numUpdate10K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpdate10K.Name = "numUpdate10K";
            this.numUpdate10K.Size = new System.Drawing.Size(108, 22);
            this.numUpdate10K.TabIndex = 28;
            // 
            // numUpdate1K
            // 
            this.numUpdate1K.Location = new System.Drawing.Point(63, 1263);
            this.numUpdate1K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpdate1K.Name = "numUpdate1K";
            this.numUpdate1K.Size = new System.Drawing.Size(108, 22);
            this.numUpdate1K.TabIndex = 27;
            // 
            // numUpdate100
            // 
            this.numUpdate100.Location = new System.Drawing.Point(63, 1235);
            this.numUpdate100.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpdate100.Name = "numUpdate100";
            this.numUpdate100.Size = new System.Drawing.Size(108, 22);
            this.numUpdate100.TabIndex = 26;
            this.numUpdate100.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numUpdate1
            // 
            this.numUpdate1.Location = new System.Drawing.Point(63, 1207);
            this.numUpdate1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numUpdate1.Name = "numUpdate1";
            this.numUpdate1.Size = new System.Drawing.Size(108, 22);
            this.numUpdate1.TabIndex = 25;
            this.numUpdate1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelectVarchar25K
            // 
            this.numSelectVarchar25K.Location = new System.Drawing.Point(63, 1048);
            this.numSelectVarchar25K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectVarchar25K.Name = "numSelectVarchar25K";
            this.numSelectVarchar25K.Size = new System.Drawing.Size(108, 22);
            this.numSelectVarchar25K.TabIndex = 24;
            // 
            // numSelectVarchar10K
            // 
            this.numSelectVarchar10K.Location = new System.Drawing.Point(63, 1020);
            this.numSelectVarchar10K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectVarchar10K.Name = "numSelectVarchar10K";
            this.numSelectVarchar10K.Size = new System.Drawing.Size(108, 22);
            this.numSelectVarchar10K.TabIndex = 23;
            // 
            // numSelectVarchar1K
            // 
            this.numSelectVarchar1K.Location = new System.Drawing.Point(63, 992);
            this.numSelectVarchar1K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectVarchar1K.Name = "numSelectVarchar1K";
            this.numSelectVarchar1K.Size = new System.Drawing.Size(108, 22);
            this.numSelectVarchar1K.TabIndex = 22;
            this.numSelectVarchar1K.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelectVarchar100
            // 
            this.numSelectVarchar100.Location = new System.Drawing.Point(63, 964);
            this.numSelectVarchar100.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectVarchar100.Name = "numSelectVarchar100";
            this.numSelectVarchar100.Size = new System.Drawing.Size(108, 22);
            this.numSelectVarchar100.TabIndex = 21;
            this.numSelectVarchar100.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelectVarchar1
            // 
            this.numSelectVarchar1.Location = new System.Drawing.Point(63, 936);
            this.numSelectVarchar1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelectVarchar1.Name = "numSelectVarchar1";
            this.numSelectVarchar1.Size = new System.Drawing.Size(108, 22);
            this.numSelectVarchar1.TabIndex = 19;
            this.numSelectVarchar1.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelect25KNS
            // 
            this.numSelect25KNS.Location = new System.Drawing.Point(63, 851);
            this.numSelect25KNS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect25KNS.Name = "numSelect25KNS";
            this.numSelect25KNS.Size = new System.Drawing.Size(108, 22);
            this.numSelect25KNS.TabIndex = 18;
            // 
            // numSelect10KNS
            // 
            this.numSelect10KNS.Location = new System.Drawing.Point(63, 823);
            this.numSelect10KNS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect10KNS.Name = "numSelect10KNS";
            this.numSelect10KNS.Size = new System.Drawing.Size(108, 22);
            this.numSelect10KNS.TabIndex = 17;
            // 
            // numSelect1KNS
            // 
            this.numSelect1KNS.Location = new System.Drawing.Point(63, 795);
            this.numSelect1KNS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect1KNS.Name = "numSelect1KNS";
            this.numSelect1KNS.Size = new System.Drawing.Size(108, 22);
            this.numSelect1KNS.TabIndex = 16;
            this.numSelect1KNS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelect100NS
            // 
            this.numSelect100NS.Location = new System.Drawing.Point(63, 767);
            this.numSelect100NS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect100NS.Name = "numSelect100NS";
            this.numSelect100NS.Size = new System.Drawing.Size(108, 22);
            this.numSelect100NS.TabIndex = 15;
            this.numSelect100NS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelect1NS
            // 
            this.numSelect1NS.Location = new System.Drawing.Point(63, 739);
            this.numSelect1NS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect1NS.Name = "numSelect1NS";
            this.numSelect1NS.Size = new System.Drawing.Size(108, 22);
            this.numSelect1NS.TabIndex = 14;
            this.numSelect1NS.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // numSelect25KS
            // 
            this.numSelect25KS.Enabled = false;
            this.numSelect25KS.Location = new System.Drawing.Point(63, 658);
            this.numSelect25KS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect25KS.Name = "numSelect25KS";
            this.numSelect25KS.Size = new System.Drawing.Size(108, 22);
            this.numSelect25KS.TabIndex = 13;
            // 
            // numSelect10KS
            // 
            this.numSelect10KS.Enabled = false;
            this.numSelect10KS.Location = new System.Drawing.Point(63, 630);
            this.numSelect10KS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect10KS.Name = "numSelect10KS";
            this.numSelect10KS.Size = new System.Drawing.Size(108, 22);
            this.numSelect10KS.TabIndex = 12;
            // 
            // numSelect1KS
            // 
            this.numSelect1KS.Enabled = false;
            this.numSelect1KS.Location = new System.Drawing.Point(63, 602);
            this.numSelect1KS.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect1KS.Name = "numSelect1KS";
            this.numSelect1KS.Size = new System.Drawing.Size(108, 22);
            this.numSelect1KS.TabIndex = 11;
            // 
            // numSelect100S
            // 
            this.numSelect100S.Enabled = false;
            this.numSelect100S.Location = new System.Drawing.Point(63, 574);
            this.numSelect100S.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect100S.Name = "numSelect100S";
            this.numSelect100S.Size = new System.Drawing.Size(108, 22);
            this.numSelect100S.TabIndex = 10;
            // 
            // numSelect1S
            // 
            this.numSelect1S.Enabled = false;
            this.numSelect1S.Location = new System.Drawing.Point(63, 546);
            this.numSelect1S.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numSelect1S.Name = "numSelect1S";
            this.numSelect1S.Size = new System.Drawing.Size(108, 22);
            this.numSelect1S.TabIndex = 9;
            // 
            // numInsert10M
            // 
            this.numInsert10M.Location = new System.Drawing.Point(63, 463);
            this.numInsert10M.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInsert10M.Name = "numInsert10M";
            this.numInsert10M.Size = new System.Drawing.Size(108, 22);
            this.numInsert10M.TabIndex = 8;
            // 
            // numInsert1M
            // 
            this.numInsert1M.Location = new System.Drawing.Point(63, 435);
            this.numInsert1M.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInsert1M.Name = "numInsert1M";
            this.numInsert1M.Size = new System.Drawing.Size(108, 22);
            this.numInsert1M.TabIndex = 7;
            // 
            // numInsert100K
            // 
            this.numInsert100K.Location = new System.Drawing.Point(63, 407);
            this.numInsert100K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInsert100K.Name = "numInsert100K";
            this.numInsert100K.Size = new System.Drawing.Size(108, 22);
            this.numInsert100K.TabIndex = 6;
            this.numInsert100K.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // numInsert10K
            // 
            this.numInsert10K.Location = new System.Drawing.Point(63, 379);
            this.numInsert10K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInsert10K.Name = "numInsert10K";
            this.numInsert10K.Size = new System.Drawing.Size(108, 22);
            this.numInsert10K.TabIndex = 5;
            this.numInsert10K.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numInsert1K
            // 
            this.numInsert1K.Location = new System.Drawing.Point(63, 351);
            this.numInsert1K.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numInsert1K.Name = "numInsert1K";
            this.numInsert1K.Size = new System.Drawing.Size(108, 22);
            this.numInsert1K.TabIndex = 4;
            this.numInsert1K.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(25, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "1K";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 318);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Insert Rows";
            // 
            // splitContainer6
            // 
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.Controls.Add(this.gbAutomationLogs);
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.Controls.Add(this.rtbAutomationOutput);
            this.splitContainer6.Size = new System.Drawing.Size(850, 690);
            this.splitContainer6.SplitterDistance = 223;
            this.splitContainer6.TabIndex = 0;
            // 
            // gbAutomationLogs
            // 
            this.gbAutomationLogs.Controls.Add(this.splitContainer7);
            this.gbAutomationLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbAutomationLogs.Location = new System.Drawing.Point(0, 0);
            this.gbAutomationLogs.Name = "gbAutomationLogs";
            this.gbAutomationLogs.Size = new System.Drawing.Size(850, 223);
            this.gbAutomationLogs.TabIndex = 0;
            this.gbAutomationLogs.TabStop = false;
            this.gbAutomationLogs.Text = "Automation Logs:  ";
            // 
            // splitContainer7
            // 
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer7.IsSplitterFixed = true;
            this.splitContainer7.Location = new System.Drawing.Point(3, 18);
            this.splitContainer7.Name = "splitContainer7";
            this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.btnAutomationClearLogs);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.lbAutomationLogs);
            this.splitContainer7.Size = new System.Drawing.Size(844, 202);
            this.splitContainer7.SplitterDistance = 40;
            this.splitContainer7.TabIndex = 0;
            // 
            // btnAutomationClearLogs
            // 
            this.btnAutomationClearLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutomationClearLogs.Location = new System.Drawing.Point(3, 5);
            this.btnAutomationClearLogs.Name = "btnAutomationClearLogs";
            this.btnAutomationClearLogs.Size = new System.Drawing.Size(137, 31);
            this.btnAutomationClearLogs.TabIndex = 0;
            this.btnAutomationClearLogs.Text = "Clear Logs";
            this.btnAutomationClearLogs.UseVisualStyleBackColor = true;
            this.btnAutomationClearLogs.Click += new System.EventHandler(this.btnAutomationClearLogs_Click);
            // 
            // lbAutomationLogs
            // 
            this.lbAutomationLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbAutomationLogs.FormattingEnabled = true;
            this.lbAutomationLogs.ItemHeight = 16;
            this.lbAutomationLogs.Location = new System.Drawing.Point(0, 0);
            this.lbAutomationLogs.Name = "lbAutomationLogs";
            this.lbAutomationLogs.Size = new System.Drawing.Size(844, 158);
            this.lbAutomationLogs.TabIndex = 0;
            // 
            // rtbAutomationOutput
            // 
            this.rtbAutomationOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAutomationOutput.Location = new System.Drawing.Point(0, 0);
            this.rtbAutomationOutput.Name = "rtbAutomationOutput";
            this.rtbAutomationOutput.Size = new System.Drawing.Size(850, 463);
            this.rtbAutomationOutput.TabIndex = 0;
            this.rtbAutomationOutput.Text = "";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.splitContainer1);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(1070, 696);
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
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.rtbLogs);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 690);
            this.splitContainer1.SplitterDistance = 89;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(15, 28);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(107, 27);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // rtbLogs
            // 
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogs.Location = new System.Drawing.Point(0, 0);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.Size = new System.Drawing.Size(1064, 597);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 753);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "DB Test";
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
            this.tabControl2.ResumeLayout(false);
            this.tabQuery.ResumeLayout(false);
            this.tabDBSelect.ResumeLayout(false);
            this.tabDBSelect.PerformLayout();
            this.tabAdditionalTests.ResumeLayout(false);
            this.tabAutomation.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.gbAutomationOptions.ResumeLayout(false);
            this.pnlAutomationOptions.ResumeLayout(false);
            this.pnlAutomationOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectDateRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate10K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate1K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpdate1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar25K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar10K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar1K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar100)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelectVarchar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect25KNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect10KNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1KNS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect100NS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1NS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect25KS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect10KS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1KS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect100S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSelect1S)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert10M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert1M)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert100K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert10K)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numInsert1K)).EndInit();
            this.splitContainer6.Panel1.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.gbAutomationLogs.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
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
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox gbMainOptions;
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
        private System.Windows.Forms.Button btnDropRecreate;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabQuery;
        private System.Windows.Forms.TabPage tabDBSelect;
        private System.Windows.Forms.Button btnSaveConnectionString;
        private System.Windows.Forms.TextBox tbDBSelectConnectString;
        private System.Windows.Forms.Label lblDBSelectConnectString;
        private System.Windows.Forms.RadioButton rbDBSelectSQLite;
        private System.Windows.Forms.RadioButton rbDBSelectPostgre;
        private System.Windows.Forms.RadioButton rbDBSelectMSSQL;
        private System.Windows.Forms.RadioButton rbDBSelectMySQL;
        private System.Windows.Forms.RadioButton rbDBSelectMariaDB;
        private System.Windows.Forms.Button btnDBSelectRestoreCurrent;
        private System.Windows.Forms.Button btnDBSelectConnect;
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.TabPage tabAdditionalTests;
        private System.Windows.Forms.Button btnInsertSingle;
        private System.Windows.Forms.Button btnCountTable;
        private System.Windows.Forms.Button btnOrdinal;
        private System.Windows.Forms.Button btnNonQuery;
        private System.Windows.Forms.Label lblEngineOut;
        private System.Windows.Forms.Label lblEngine;
        private System.Windows.Forms.Button btnGetIndexes;
        private System.Windows.Forms.RadioButton rbSelectByDateRange;
        private System.Windows.Forms.RadioButton rbSelectBySerialNum;
        private System.Windows.Forms.RadioButton rbSelectByTestId;
        private System.Windows.Forms.Label lblSelectBy;
        private System.Windows.Forms.TabPage tabAutomation;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.GroupBox gbAutomationOptions;
        private System.Windows.Forms.Panel pnlAutomationOptions;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numInsert1K;
        private System.Windows.Forms.NumericUpDown numUpdate10K;
        private System.Windows.Forms.NumericUpDown numUpdate1K;
        private System.Windows.Forms.NumericUpDown numUpdate100;
        private System.Windows.Forms.NumericUpDown numUpdate1;
        private System.Windows.Forms.NumericUpDown numSelectVarchar25K;
        private System.Windows.Forms.NumericUpDown numSelectVarchar10K;
        private System.Windows.Forms.NumericUpDown numSelectVarchar1K;
        private System.Windows.Forms.NumericUpDown numSelectVarchar100;
        private System.Windows.Forms.NumericUpDown numSelectVarchar1;
        private System.Windows.Forms.NumericUpDown numSelect25KNS;
        private System.Windows.Forms.NumericUpDown numSelect10KNS;
        private System.Windows.Forms.NumericUpDown numSelect1KNS;
        private System.Windows.Forms.NumericUpDown numSelect100NS;
        private System.Windows.Forms.NumericUpDown numSelect1NS;
        private System.Windows.Forms.NumericUpDown numSelect25KS;
        private System.Windows.Forms.NumericUpDown numSelect10KS;
        private System.Windows.Forms.NumericUpDown numSelect1KS;
        private System.Windows.Forms.NumericUpDown numSelect100S;
        private System.Windows.Forms.NumericUpDown numSelect1S;
        private System.Windows.Forms.NumericUpDown numInsert10M;
        private System.Windows.Forms.NumericUpDown numInsert1M;
        private System.Windows.Forms.NumericUpDown numInsert100K;
        private System.Windows.Forms.NumericUpDown numInsert10K;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblAutomationSeqSelect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button btnStartAutomation;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.GroupBox gbAutomationLogs;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Button btnAutomationClearLogs;
        private System.Windows.Forms.ListBox lbAutomationLogs;
        private System.Windows.Forms.RichTextBox rtbAutomationOutput;
        private System.Windows.Forms.Button btnAutomateDBAll;
        private System.Windows.Forms.CheckBox cbAutomateSQLite;
        private System.Windows.Forms.CheckBox cbAutomatePostgre;
        private System.Windows.Forms.CheckBox cbAutomateMySQL;
        private System.Windows.Forms.CheckBox cbAutomateMSSQL;
        private System.Windows.Forms.CheckBox cbAutomateMariaDB;
        private System.Windows.Forms.Label lblAutomationDBSelect;
        private System.Windows.Forms.Button btnStopAutomation;
        private System.Windows.Forms.Button btnPauseAutomation;
        private System.Windows.Forms.NumericUpDown numSelectDateRange;
        private System.Windows.Forms.Label label31;
    }
}

