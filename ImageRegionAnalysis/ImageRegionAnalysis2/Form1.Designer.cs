
namespace ImageRegionAnalysis2
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
            this.pnlMainOptions = new System.Windows.Forms.Panel();
            this.numRgbThresh = new System.Windows.Forms.NumericUpDown();
            this.lblRgbThresh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboKnownImages = new System.Windows.Forms.ComboBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pnlMainImagePaths = new System.Windows.Forms.Panel();
            this.btnSaveImage = new System.Windows.Forms.Button();
            this.tbFileOut = new System.Windows.Forms.TextBox();
            this.btnLoadImage = new System.Windows.Forms.Button();
            this.tbFileIn = new System.Windows.Forms.TextBox();
            this.lblFileOut = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlMainImages = new System.Windows.Forms.Panel();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pbImageOut = new System.Windows.Forms.PictureBox();
            this.pbImageIn = new System.Windows.Forms.PictureBox();
            this.tabLines = new System.Windows.Forms.TabPage();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.pnlRowOptions = new System.Windows.Forms.Panel();
            this.btnGetTextRows = new System.Windows.Forms.Button();
            this.splitContainer6 = new System.Windows.Forms.SplitContainer();
            this.flowRowImages = new System.Windows.Forms.FlowLayoutPanel();
            this.tabCharacters = new System.Windows.Forms.TabPage();
            this.splitContainer7 = new System.Windows.Forms.SplitContainer();
            this.pnlCharacterOptions = new System.Windows.Forms.Panel();
            this.btnGetCharacters = new System.Windows.Forms.Button();
            this.splitContainer8 = new System.Windows.Forms.SplitContainer();
            this.flowCharacters = new System.Windows.Forms.FlowLayoutPanel();
            this.tabRegions = new System.Windows.Forms.TabPage();
            this.tabsRegions = new System.Windows.Forms.TabControl();
            this.tabRegionCounts = new System.Windows.Forms.TabPage();
            this.splitContainer9 = new System.Windows.Forms.SplitContainer();
            this.tbRegionsTemplatePath = new System.Windows.Forms.TextBox();
            this.btnRegionsLoadTemplates = new System.Windows.Forms.Button();
            this.btnRegionsSaveTemplates = new System.Windows.Forms.Button();
            this.btnGetRegionCounts = new System.Windows.Forms.Button();
            this.rtbRegionCounts = new System.Windows.Forms.RichTextBox();
            this.tabReadText = new System.Windows.Forms.TabPage();
            this.splitContainer12 = new System.Windows.Forms.SplitContainer();
            this.btnReadTextImage = new System.Windows.Forms.Button();
            this.tbReadTextImageFile = new System.Windows.Forms.TextBox();
            this.btnLoadTextImage = new System.Windows.Forms.Button();
            this.splitContainer13 = new System.Windows.Forms.SplitContainer();
            this.pbReadTextImage = new System.Windows.Forms.PictureBox();
            this.rtbReadTextImage = new System.Windows.Forms.RichTextBox();
            this.tabFindLines = new System.Windows.Forms.TabPage();
            this.splitContainer10 = new System.Windows.Forms.SplitContainer();
            this.gbFindLinesOptions = new System.Windows.Forms.GroupBox();
            this.numFindLinesRise = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.btnFindRise = new System.Windows.Forms.Button();
            this.btnCountLines = new System.Windows.Forms.Button();
            this.btnDrawLines = new System.Windows.Forms.Button();
            this.splitContainer11 = new System.Windows.Forms.SplitContainer();
            this.pbFindLines1 = new System.Windows.Forms.PictureBox();
            this.pbFindLines2 = new System.Windows.Forms.PictureBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.rtbLogs = new System.Windows.Forms.RichTextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabTiming = new System.Windows.Forms.TabPage();
            this.splitContainer14 = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gbTimingOptions = new System.Windows.Forms.GroupBox();
            this.cbTmgTextReadReport = new System.Windows.Forms.CheckBox();
            this.cbTmgCompareAgainstActual = new System.Windows.Forms.CheckBox();
            this.cbTmgReadText = new System.Windows.Forms.CheckBox();
            this.cbTmgFindClosestTemplate = new System.Windows.Forms.CheckBox();
            this.cbTmgCountTextImageCharacters = new System.Windows.Forms.CheckBox();
            this.cbTmgFindTextImageCharacters = new System.Windows.Forms.CheckBox();
            this.cbTmgFindTextImageLines = new System.Windows.Forms.CheckBox();
            this.cbTmgLoadTextImage = new System.Windows.Forms.CheckBox();
            this.cbTmgLoadTemplate = new System.Windows.Forms.CheckBox();
            this.cbTmgSaveTemplate = new System.Windows.Forms.CheckBox();
            this.cbTmgCountTrainingCharacters = new System.Windows.Forms.CheckBox();
            this.cbTmgFindTrainingCharacters = new System.Windows.Forms.CheckBox();
            this.cbTmgFindTrainingLines = new System.Windows.Forms.CheckBox();
            this.cbTmgLoadTrainingImage = new System.Windows.Forms.CheckBox();
            this.cbTmgTrainFont = new System.Windows.Forms.CheckBox();
            this.btnClearTiming = new System.Windows.Forms.Button();
            this.splitContainer15 = new System.Windows.Forms.SplitContainer();
            this.lbTimingOutput = new System.Windows.Forms.ListBox();
            this.gridTimingOutput = new System.Windows.Forms.DataGridView();
            this.lblReadImages = new System.Windows.Forms.Label();
            this.comboReadImages = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboKnownTemplates = new System.Windows.Forms.ComboBox();
            this.cbSaveTemplatePretty = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.pnlMainOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRgbThresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.pnlMainImagePaths.SuspendLayout();
            this.pnlMainImages.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageOut)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageIn)).BeginInit();
            this.tabLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.pnlRowOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
            this.splitContainer6.Panel2.SuspendLayout();
            this.splitContainer6.SuspendLayout();
            this.tabCharacters.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
            this.splitContainer7.Panel1.SuspendLayout();
            this.splitContainer7.Panel2.SuspendLayout();
            this.splitContainer7.SuspendLayout();
            this.pnlCharacterOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
            this.splitContainer8.Panel2.SuspendLayout();
            this.splitContainer8.SuspendLayout();
            this.tabRegions.SuspendLayout();
            this.tabsRegions.SuspendLayout();
            this.tabRegionCounts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).BeginInit();
            this.splitContainer9.Panel1.SuspendLayout();
            this.splitContainer9.Panel2.SuspendLayout();
            this.splitContainer9.SuspendLayout();
            this.tabReadText.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).BeginInit();
            this.splitContainer12.Panel1.SuspendLayout();
            this.splitContainer12.Panel2.SuspendLayout();
            this.splitContainer12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).BeginInit();
            this.splitContainer13.Panel1.SuspendLayout();
            this.splitContainer13.Panel2.SuspendLayout();
            this.splitContainer13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbReadTextImage)).BeginInit();
            this.tabFindLines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).BeginInit();
            this.splitContainer10.Panel1.SuspendLayout();
            this.splitContainer10.Panel2.SuspendLayout();
            this.splitContainer10.SuspendLayout();
            this.gbFindLinesOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFindLinesRise)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).BeginInit();
            this.splitContainer11.Panel1.SuspendLayout();
            this.splitContainer11.Panel2.SuspendLayout();
            this.splitContainer11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbFindLines1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFindLines2)).BeginInit();
            this.tabLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabTiming.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).BeginInit();
            this.splitContainer14.Panel1.SuspendLayout();
            this.splitContainer14.Panel2.SuspendLayout();
            this.splitContainer14.SuspendLayout();
            this.panel2.SuspendLayout();
            this.gbTimingOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).BeginInit();
            this.splitContainer15.Panel1.SuspendLayout();
            this.splitContainer15.Panel2.SuspendLayout();
            this.splitContainer15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTimingOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1511, 28);
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
            this.tabControl1.Controls.Add(this.tabLines);
            this.tabControl1.Controls.Add(this.tabCharacters);
            this.tabControl1.Controls.Add(this.tabRegions);
            this.tabControl1.Controls.Add(this.tabReadText);
            this.tabControl1.Controls.Add(this.tabFindLines);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.tabTiming);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1511, 776);
            this.tabControl1.TabIndex = 1;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.splitContainer2);
            this.tabMain.Location = new System.Drawing.Point(4, 25);
            this.tabMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Name = "tabMain";
            this.tabMain.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabMain.Size = new System.Drawing.Size(1503, 747);
            this.tabMain.TabIndex = 0;
            this.tabMain.Text = "Main";
            this.tabMain.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.BackColor = System.Drawing.Color.Black;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 2);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pnlMainOptions);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer2.Size = new System.Drawing.Size(1497, 743);
            this.splitContainer2.SplitterDistance = 300;
            this.splitContainer2.TabIndex = 0;
            // 
            // pnlMainOptions
            // 
            this.pnlMainOptions.AutoScroll = true;
            this.pnlMainOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMainOptions.Controls.Add(this.comboKnownTemplates);
            this.pnlMainOptions.Controls.Add(this.label4);
            this.pnlMainOptions.Controls.Add(this.comboReadImages);
            this.pnlMainOptions.Controls.Add(this.lblReadImages);
            this.pnlMainOptions.Controls.Add(this.numRgbThresh);
            this.pnlMainOptions.Controls.Add(this.lblRgbThresh);
            this.pnlMainOptions.Controls.Add(this.label2);
            this.pnlMainOptions.Controls.Add(this.comboKnownImages);
            this.pnlMainOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlMainOptions.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainOptions.Name = "pnlMainOptions";
            this.pnlMainOptions.Size = new System.Drawing.Size(300, 743);
            this.pnlMainOptions.TabIndex = 0;
            // 
            // numRgbThresh
            // 
            this.numRgbThresh.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numRgbThresh.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numRgbThresh.Location = new System.Drawing.Point(48, 528);
            this.numRgbThresh.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numRgbThresh.Name = "numRgbThresh";
            this.numRgbThresh.Size = new System.Drawing.Size(220, 26);
            this.numRgbThresh.TabIndex = 8;
            this.numRgbThresh.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // lblRgbThresh
            // 
            this.lblRgbThresh.AutoSize = true;
            this.lblRgbThresh.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRgbThresh.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblRgbThresh.Location = new System.Drawing.Point(32, 506);
            this.lblRgbThresh.Name = "lblRgbThresh";
            this.lblRgbThresh.Size = new System.Drawing.Size(138, 18);
            this.lblRgbThresh.TabIndex = 7;
            this.lblRgbThresh.Text = "RGB Thresh:  ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Chartreuse;
            this.label2.Location = new System.Drawing.Point(32, 289);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(188, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Training Images:  ";
            // 
            // comboKnownImages
            // 
            this.comboKnownImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboKnownImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKnownImages.FormattingEnabled = true;
            this.comboKnownImages.Location = new System.Drawing.Point(48, 310);
            this.comboKnownImages.Name = "comboKnownImages";
            this.comboKnownImages.Size = new System.Drawing.Size(220, 28);
            this.comboKnownImages.TabIndex = 1;
            this.comboKnownImages.SelectedValueChanged += new System.EventHandler(this.comboKnownImages_SelectedValueChanged);
            // 
            // splitContainer3
            // 
            this.splitContainer3.BackColor = System.Drawing.Color.Black;
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pnlMainImagePaths);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.pnlMainImages);
            this.splitContainer3.Size = new System.Drawing.Size(1193, 743);
            this.splitContainer3.SplitterDistance = 133;
            this.splitContainer3.TabIndex = 0;
            // 
            // pnlMainImagePaths
            // 
            this.pnlMainImagePaths.AutoScroll = true;
            this.pnlMainImagePaths.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlMainImagePaths.Controls.Add(this.btnSaveImage);
            this.pnlMainImagePaths.Controls.Add(this.tbFileOut);
            this.pnlMainImagePaths.Controls.Add(this.btnLoadImage);
            this.pnlMainImagePaths.Controls.Add(this.tbFileIn);
            this.pnlMainImagePaths.Controls.Add(this.lblFileOut);
            this.pnlMainImagePaths.Controls.Add(this.label1);
            this.pnlMainImagePaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainImagePaths.Location = new System.Drawing.Point(0, 0);
            this.pnlMainImagePaths.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainImagePaths.Name = "pnlMainImagePaths";
            this.pnlMainImagePaths.Size = new System.Drawing.Size(1193, 133);
            this.pnlMainImagePaths.TabIndex = 0;
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(761, 69);
            this.btnSaveImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Size = new System.Drawing.Size(136, 28);
            this.btnSaveImage.TabIndex = 5;
            this.btnSaveImage.Text = "Save Image";
            this.btnSaveImage.UseVisualStyleBackColor = true;
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // tbFileOut
            // 
            this.tbFileOut.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbFileOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileOut.ForeColor = System.Drawing.Color.Chartreuse;
            this.tbFileOut.Location = new System.Drawing.Point(188, 69);
            this.tbFileOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFileOut.Name = "tbFileOut";
            this.tbFileOut.Size = new System.Drawing.Size(549, 28);
            this.tbFileOut.TabIndex = 3;
            this.tbFileOut.Text = "fsfds";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(761, 25);
            this.btnLoadImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Size = new System.Drawing.Size(136, 28);
            this.btnLoadImage.TabIndex = 4;
            this.btnLoadImage.Text = "Load Image";
            this.btnLoadImage.UseVisualStyleBackColor = true;
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // tbFileIn
            // 
            this.tbFileIn.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbFileIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbFileIn.ForeColor = System.Drawing.Color.Chartreuse;
            this.tbFileIn.Location = new System.Drawing.Point(188, 25);
            this.tbFileIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbFileIn.Name = "tbFileIn";
            this.tbFileIn.Size = new System.Drawing.Size(549, 28);
            this.tbFileIn.TabIndex = 2;
            this.tbFileIn.Text = "D:\\ImgRegionTest.bmp";
            // 
            // lblFileOut
            // 
            this.lblFileOut.AutoSize = true;
            this.lblFileOut.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFileOut.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblFileOut.Location = new System.Drawing.Point(37, 71);
            this.lblFileOut.Name = "lblFileOut";
            this.lblFileOut.Size = new System.Drawing.Size(142, 23);
            this.lblFileOut.TabIndex = 1;
            this.lblFileOut.Text = "File Out:  ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Chartreuse;
            this.label1.Location = new System.Drawing.Point(37, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "File In:  ";
            // 
            // pnlMainImages
            // 
            this.pnlMainImages.AutoScroll = true;
            this.pnlMainImages.Controls.Add(this.splitContainer4);
            this.pnlMainImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainImages.Location = new System.Drawing.Point(0, 0);
            this.pnlMainImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMainImages.Name = "pnlMainImages";
            this.pnlMainImages.Size = new System.Drawing.Size(1193, 606);
            this.pnlMainImages.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer4.Name = "splitContainer4";
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pbImageOut);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pbImageIn);
            this.splitContainer4.Size = new System.Drawing.Size(1193, 606);
            this.splitContainer4.SplitterDistance = 453;
            this.splitContainer4.TabIndex = 0;
            // 
            // pbImageOut
            // 
            this.pbImageOut.BackColor = System.Drawing.Color.DimGray;
            this.pbImageOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImageOut.Location = new System.Drawing.Point(0, 0);
            this.pbImageOut.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbImageOut.Name = "pbImageOut";
            this.pbImageOut.Size = new System.Drawing.Size(453, 606);
            this.pbImageOut.TabIndex = 0;
            this.pbImageOut.TabStop = false;
            // 
            // pbImageIn
            // 
            this.pbImageIn.BackColor = System.Drawing.Color.DimGray;
            this.pbImageIn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImageIn.Location = new System.Drawing.Point(0, 0);
            this.pbImageIn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pbImageIn.Name = "pbImageIn";
            this.pbImageIn.Size = new System.Drawing.Size(736, 606);
            this.pbImageIn.TabIndex = 0;
            this.pbImageIn.TabStop = false;
            // 
            // tabLines
            // 
            this.tabLines.Controls.Add(this.splitContainer5);
            this.tabLines.Location = new System.Drawing.Point(4, 25);
            this.tabLines.Name = "tabLines";
            this.tabLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabLines.Size = new System.Drawing.Size(1503, 747);
            this.tabLines.TabIndex = 2;
            this.tabLines.Text = "Lines";
            this.tabLines.UseVisualStyleBackColor = true;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BackColor = System.Drawing.Color.Black;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(3, 3);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.pnlRowOptions);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.splitContainer6);
            this.splitContainer5.Size = new System.Drawing.Size(1497, 741);
            this.splitContainer5.SplitterDistance = 200;
            this.splitContainer5.TabIndex = 0;
            // 
            // pnlRowOptions
            // 
            this.pnlRowOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlRowOptions.Controls.Add(this.btnGetTextRows);
            this.pnlRowOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRowOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlRowOptions.Name = "pnlRowOptions";
            this.pnlRowOptions.Size = new System.Drawing.Size(200, 741);
            this.pnlRowOptions.TabIndex = 0;
            // 
            // btnGetTextRows
            // 
            this.btnGetTextRows.Location = new System.Drawing.Point(41, 295);
            this.btnGetTextRows.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetTextRows.Name = "btnGetTextRows";
            this.btnGetTextRows.Size = new System.Drawing.Size(113, 30);
            this.btnGetTextRows.TabIndex = 1;
            this.btnGetTextRows.Text = "Get Rows";
            this.btnGetTextRows.UseVisualStyleBackColor = true;
            this.btnGetTextRows.Click += new System.EventHandler(this.btnGetTextRows_Click);
            // 
            // splitContainer6
            // 
            this.splitContainer6.BackColor = System.Drawing.Color.Black;
            this.splitContainer6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer6.Location = new System.Drawing.Point(0, 0);
            this.splitContainer6.Name = "splitContainer6";
            this.splitContainer6.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer6.Panel1
            // 
            this.splitContainer6.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // splitContainer6.Panel2
            // 
            this.splitContainer6.Panel2.AutoScroll = true;
            this.splitContainer6.Panel2.BackColor = System.Drawing.Color.Blue;
            this.splitContainer6.Panel2.Controls.Add(this.flowRowImages);
            this.splitContainer6.Size = new System.Drawing.Size(1293, 741);
            this.splitContainer6.SplitterDistance = 110;
            this.splitContainer6.TabIndex = 0;
            // 
            // flowRowImages
            // 
            this.flowRowImages.BackColor = System.Drawing.Color.DimGray;
            this.flowRowImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowRowImages.Location = new System.Drawing.Point(0, 0);
            this.flowRowImages.Name = "flowRowImages";
            this.flowRowImages.Size = new System.Drawing.Size(1293, 627);
            this.flowRowImages.TabIndex = 1;
            // 
            // tabCharacters
            // 
            this.tabCharacters.Controls.Add(this.splitContainer7);
            this.tabCharacters.Location = new System.Drawing.Point(4, 25);
            this.tabCharacters.Name = "tabCharacters";
            this.tabCharacters.Padding = new System.Windows.Forms.Padding(3);
            this.tabCharacters.Size = new System.Drawing.Size(1503, 747);
            this.tabCharacters.TabIndex = 3;
            this.tabCharacters.Text = "Characters";
            this.tabCharacters.UseVisualStyleBackColor = true;
            // 
            // splitContainer7
            // 
            this.splitContainer7.BackColor = System.Drawing.Color.Black;
            this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer7.Location = new System.Drawing.Point(3, 3);
            this.splitContainer7.Name = "splitContainer7";
            // 
            // splitContainer7.Panel1
            // 
            this.splitContainer7.Panel1.Controls.Add(this.pnlCharacterOptions);
            // 
            // splitContainer7.Panel2
            // 
            this.splitContainer7.Panel2.Controls.Add(this.splitContainer8);
            this.splitContainer7.Size = new System.Drawing.Size(1497, 741);
            this.splitContainer7.SplitterDistance = 200;
            this.splitContainer7.TabIndex = 0;
            // 
            // pnlCharacterOptions
            // 
            this.pnlCharacterOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnlCharacterOptions.Controls.Add(this.btnGetCharacters);
            this.pnlCharacterOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCharacterOptions.Location = new System.Drawing.Point(0, 0);
            this.pnlCharacterOptions.Name = "pnlCharacterOptions";
            this.pnlCharacterOptions.Size = new System.Drawing.Size(200, 741);
            this.pnlCharacterOptions.TabIndex = 0;
            // 
            // btnGetCharacters
            // 
            this.btnGetCharacters.Location = new System.Drawing.Point(41, 289);
            this.btnGetCharacters.Margin = new System.Windows.Forms.Padding(4);
            this.btnGetCharacters.Name = "btnGetCharacters";
            this.btnGetCharacters.Size = new System.Drawing.Size(113, 30);
            this.btnGetCharacters.TabIndex = 2;
            this.btnGetCharacters.Text = "Get Characters";
            this.btnGetCharacters.UseVisualStyleBackColor = true;
            this.btnGetCharacters.Click += new System.EventHandler(this.btnGetCharacters_Click);
            // 
            // splitContainer8
            // 
            this.splitContainer8.BackColor = System.Drawing.Color.Black;
            this.splitContainer8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer8.Location = new System.Drawing.Point(0, 0);
            this.splitContainer8.Name = "splitContainer8";
            this.splitContainer8.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer8.Panel1
            // 
            this.splitContainer8.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            // 
            // splitContainer8.Panel2
            // 
            this.splitContainer8.Panel2.AutoScroll = true;
            this.splitContainer8.Panel2.Controls.Add(this.flowCharacters);
            this.splitContainer8.Size = new System.Drawing.Size(1293, 741);
            this.splitContainer8.SplitterDistance = 140;
            this.splitContainer8.TabIndex = 0;
            // 
            // flowCharacters
            // 
            this.flowCharacters.AutoScroll = true;
            this.flowCharacters.BackColor = System.Drawing.Color.DimGray;
            this.flowCharacters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowCharacters.Location = new System.Drawing.Point(0, 0);
            this.flowCharacters.Name = "flowCharacters";
            this.flowCharacters.Size = new System.Drawing.Size(1293, 597);
            this.flowCharacters.TabIndex = 0;
            // 
            // tabRegions
            // 
            this.tabRegions.Controls.Add(this.tabsRegions);
            this.tabRegions.Location = new System.Drawing.Point(4, 25);
            this.tabRegions.Name = "tabRegions";
            this.tabRegions.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegions.Size = new System.Drawing.Size(1503, 747);
            this.tabRegions.TabIndex = 4;
            this.tabRegions.Text = "Regions";
            this.tabRegions.UseVisualStyleBackColor = true;
            // 
            // tabsRegions
            // 
            this.tabsRegions.Controls.Add(this.tabRegionCounts);
            this.tabsRegions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabsRegions.Location = new System.Drawing.Point(3, 3);
            this.tabsRegions.Name = "tabsRegions";
            this.tabsRegions.SelectedIndex = 0;
            this.tabsRegions.Size = new System.Drawing.Size(1497, 741);
            this.tabsRegions.TabIndex = 0;
            // 
            // tabRegionCounts
            // 
            this.tabRegionCounts.Controls.Add(this.splitContainer9);
            this.tabRegionCounts.Location = new System.Drawing.Point(4, 25);
            this.tabRegionCounts.Name = "tabRegionCounts";
            this.tabRegionCounts.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegionCounts.Size = new System.Drawing.Size(1489, 712);
            this.tabRegionCounts.TabIndex = 0;
            this.tabRegionCounts.Text = "Region Counts";
            this.tabRegionCounts.UseVisualStyleBackColor = true;
            // 
            // splitContainer9
            // 
            this.splitContainer9.BackColor = System.Drawing.Color.Black;
            this.splitContainer9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer9.Location = new System.Drawing.Point(3, 3);
            this.splitContainer9.Name = "splitContainer9";
            this.splitContainer9.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer9.Panel1
            // 
            this.splitContainer9.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer9.Panel1.Controls.Add(this.cbSaveTemplatePretty);
            this.splitContainer9.Panel1.Controls.Add(this.tbRegionsTemplatePath);
            this.splitContainer9.Panel1.Controls.Add(this.btnRegionsLoadTemplates);
            this.splitContainer9.Panel1.Controls.Add(this.btnRegionsSaveTemplates);
            this.splitContainer9.Panel1.Controls.Add(this.btnGetRegionCounts);
            // 
            // splitContainer9.Panel2
            // 
            this.splitContainer9.Panel2.Controls.Add(this.rtbRegionCounts);
            this.splitContainer9.Size = new System.Drawing.Size(1483, 706);
            this.splitContainer9.SplitterDistance = 105;
            this.splitContainer9.TabIndex = 0;
            // 
            // tbRegionsTemplatePath
            // 
            this.tbRegionsTemplatePath.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbRegionsTemplatePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRegionsTemplatePath.ForeColor = System.Drawing.Color.Chartreuse;
            this.tbRegionsTemplatePath.Location = new System.Drawing.Point(682, 36);
            this.tbRegionsTemplatePath.Name = "tbRegionsTemplatePath";
            this.tbRegionsTemplatePath.Size = new System.Drawing.Size(354, 28);
            this.tbRegionsTemplatePath.TabIndex = 3;
            // 
            // btnRegionsLoadTemplates
            // 
            this.btnRegionsLoadTemplates.Location = new System.Drawing.Point(1042, 34);
            this.btnRegionsLoadTemplates.Name = "btnRegionsLoadTemplates";
            this.btnRegionsLoadTemplates.Size = new System.Drawing.Size(145, 30);
            this.btnRegionsLoadTemplates.TabIndex = 2;
            this.btnRegionsLoadTemplates.Text = "Load Template";
            this.btnRegionsLoadTemplates.UseVisualStyleBackColor = true;
            this.btnRegionsLoadTemplates.Click += new System.EventHandler(this.btnRegionsLoadTemplates_Click);
            // 
            // btnRegionsSaveTemplates
            // 
            this.btnRegionsSaveTemplates.Location = new System.Drawing.Point(1193, 34);
            this.btnRegionsSaveTemplates.Name = "btnRegionsSaveTemplates";
            this.btnRegionsSaveTemplates.Size = new System.Drawing.Size(145, 30);
            this.btnRegionsSaveTemplates.TabIndex = 1;
            this.btnRegionsSaveTemplates.Text = "Save Template";
            this.btnRegionsSaveTemplates.UseVisualStyleBackColor = true;
            this.btnRegionsSaveTemplates.Click += new System.EventHandler(this.btnRegionsSaveTemplates_Click);
            // 
            // btnGetRegionCounts
            // 
            this.btnGetRegionCounts.Location = new System.Drawing.Point(78, 34);
            this.btnGetRegionCounts.Name = "btnGetRegionCounts";
            this.btnGetRegionCounts.Size = new System.Drawing.Size(145, 30);
            this.btnGetRegionCounts.TabIndex = 0;
            this.btnGetRegionCounts.Text = "Get Counts";
            this.btnGetRegionCounts.UseVisualStyleBackColor = true;
            this.btnGetRegionCounts.Click += new System.EventHandler(this.btnGetRegionCounts_Click);
            // 
            // rtbRegionCounts
            // 
            this.rtbRegionCounts.BackColor = System.Drawing.Color.Silver;
            this.rtbRegionCounts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbRegionCounts.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbRegionCounts.Location = new System.Drawing.Point(0, 0);
            this.rtbRegionCounts.Name = "rtbRegionCounts";
            this.rtbRegionCounts.Size = new System.Drawing.Size(1483, 597);
            this.rtbRegionCounts.TabIndex = 0;
            this.rtbRegionCounts.Text = "";
            // 
            // tabReadText
            // 
            this.tabReadText.Controls.Add(this.splitContainer12);
            this.tabReadText.Location = new System.Drawing.Point(4, 25);
            this.tabReadText.Name = "tabReadText";
            this.tabReadText.Padding = new System.Windows.Forms.Padding(3);
            this.tabReadText.Size = new System.Drawing.Size(1503, 747);
            this.tabReadText.TabIndex = 6;
            this.tabReadText.Text = "Read Text";
            this.tabReadText.UseVisualStyleBackColor = true;
            // 
            // splitContainer12
            // 
            this.splitContainer12.BackColor = System.Drawing.SystemColors.WindowText;
            this.splitContainer12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer12.Location = new System.Drawing.Point(3, 3);
            this.splitContainer12.Name = "splitContainer12";
            this.splitContainer12.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer12.Panel1
            // 
            this.splitContainer12.Panel1.AutoScroll = true;
            this.splitContainer12.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer12.Panel1.Controls.Add(this.btnReadTextImage);
            this.splitContainer12.Panel1.Controls.Add(this.tbReadTextImageFile);
            this.splitContainer12.Panel1.Controls.Add(this.btnLoadTextImage);
            // 
            // splitContainer12.Panel2
            // 
            this.splitContainer12.Panel2.Controls.Add(this.splitContainer13);
            this.splitContainer12.Size = new System.Drawing.Size(1497, 741);
            this.splitContainer12.SplitterDistance = 82;
            this.splitContainer12.TabIndex = 0;
            // 
            // btnReadTextImage
            // 
            this.btnReadTextImage.Location = new System.Drawing.Point(923, 20);
            this.btnReadTextImage.Name = "btnReadTextImage";
            this.btnReadTextImage.Size = new System.Drawing.Size(145, 30);
            this.btnReadTextImage.TabIndex = 5;
            this.btnReadTextImage.Text = "Read Text Image";
            this.btnReadTextImage.UseVisualStyleBackColor = true;
            this.btnReadTextImage.Click += new System.EventHandler(this.btnReadTextImage_Click);
            // 
            // tbReadTextImageFile
            // 
            this.tbReadTextImageFile.BackColor = System.Drawing.SystemColors.WindowText;
            this.tbReadTextImageFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbReadTextImageFile.ForeColor = System.Drawing.Color.Chartreuse;
            this.tbReadTextImageFile.Location = new System.Drawing.Point(412, 22);
            this.tbReadTextImageFile.Name = "tbReadTextImageFile";
            this.tbReadTextImageFile.Size = new System.Drawing.Size(354, 28);
            this.tbReadTextImageFile.TabIndex = 4;
            // 
            // btnLoadTextImage
            // 
            this.btnLoadTextImage.Location = new System.Drawing.Point(772, 20);
            this.btnLoadTextImage.Name = "btnLoadTextImage";
            this.btnLoadTextImage.Size = new System.Drawing.Size(145, 30);
            this.btnLoadTextImage.TabIndex = 3;
            this.btnLoadTextImage.Text = "Load Text Image";
            this.btnLoadTextImage.UseVisualStyleBackColor = true;
            this.btnLoadTextImage.Click += new System.EventHandler(this.btnLoadTextImage_Click);
            // 
            // splitContainer13
            // 
            this.splitContainer13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer13.Location = new System.Drawing.Point(0, 0);
            this.splitContainer13.Name = "splitContainer13";
            // 
            // splitContainer13.Panel1
            // 
            this.splitContainer13.Panel1.AutoScroll = true;
            this.splitContainer13.Panel1.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer13.Panel1.Controls.Add(this.pbReadTextImage);
            // 
            // splitContainer13.Panel2
            // 
            this.splitContainer13.Panel2.AutoScroll = true;
            this.splitContainer13.Panel2.BackColor = System.Drawing.Color.DimGray;
            this.splitContainer13.Panel2.Controls.Add(this.rtbReadTextImage);
            this.splitContainer13.Size = new System.Drawing.Size(1497, 655);
            this.splitContainer13.SplitterDistance = 478;
            this.splitContainer13.TabIndex = 0;
            // 
            // pbReadTextImage
            // 
            this.pbReadTextImage.Location = new System.Drawing.Point(3, 3);
            this.pbReadTextImage.Name = "pbReadTextImage";
            this.pbReadTextImage.Size = new System.Drawing.Size(100, 50);
            this.pbReadTextImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbReadTextImage.TabIndex = 0;
            this.pbReadTextImage.TabStop = false;
            // 
            // rtbReadTextImage
            // 
            this.rtbReadTextImage.BackColor = System.Drawing.Color.Silver;
            this.rtbReadTextImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbReadTextImage.Font = new System.Drawing.Font("Courier New", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbReadTextImage.Location = new System.Drawing.Point(0, 0);
            this.rtbReadTextImage.Name = "rtbReadTextImage";
            this.rtbReadTextImage.Size = new System.Drawing.Size(1015, 655);
            this.rtbReadTextImage.TabIndex = 0;
            this.rtbReadTextImage.Text = "";
            // 
            // tabFindLines
            // 
            this.tabFindLines.Controls.Add(this.splitContainer10);
            this.tabFindLines.Location = new System.Drawing.Point(4, 25);
            this.tabFindLines.Name = "tabFindLines";
            this.tabFindLines.Padding = new System.Windows.Forms.Padding(3);
            this.tabFindLines.Size = new System.Drawing.Size(1503, 747);
            this.tabFindLines.TabIndex = 5;
            this.tabFindLines.Text = "Find Lines";
            this.tabFindLines.UseVisualStyleBackColor = true;
            // 
            // splitContainer10
            // 
            this.splitContainer10.BackColor = System.Drawing.Color.Black;
            this.splitContainer10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer10.Location = new System.Drawing.Point(3, 3);
            this.splitContainer10.Name = "splitContainer10";
            this.splitContainer10.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer10.Panel1
            // 
            this.splitContainer10.Panel1.Controls.Add(this.gbFindLinesOptions);
            // 
            // splitContainer10.Panel2
            // 
            this.splitContainer10.Panel2.Controls.Add(this.splitContainer11);
            this.splitContainer10.Size = new System.Drawing.Size(1497, 741);
            this.splitContainer10.SplitterDistance = 111;
            this.splitContainer10.TabIndex = 0;
            // 
            // gbFindLinesOptions
            // 
            this.gbFindLinesOptions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.gbFindLinesOptions.Controls.Add(this.numFindLinesRise);
            this.gbFindLinesOptions.Controls.Add(this.label3);
            this.gbFindLinesOptions.Controls.Add(this.btnFindRise);
            this.gbFindLinesOptions.Controls.Add(this.btnCountLines);
            this.gbFindLinesOptions.Controls.Add(this.btnDrawLines);
            this.gbFindLinesOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbFindLinesOptions.ForeColor = System.Drawing.Color.White;
            this.gbFindLinesOptions.Location = new System.Drawing.Point(0, 0);
            this.gbFindLinesOptions.Name = "gbFindLinesOptions";
            this.gbFindLinesOptions.Size = new System.Drawing.Size(1497, 111);
            this.gbFindLinesOptions.TabIndex = 0;
            this.gbFindLinesOptions.TabStop = false;
            this.gbFindLinesOptions.Text = "Find Lines Options:  ";
            // 
            // numFindLinesRise
            // 
            this.numFindLinesRise.BackColor = System.Drawing.SystemColors.WindowText;
            this.numFindLinesRise.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFindLinesRise.ForeColor = System.Drawing.Color.Chartreuse;
            this.numFindLinesRise.Location = new System.Drawing.Point(18, 57);
            this.numFindLinesRise.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.numFindLinesRise.Minimum = new decimal(new int[] {
            300,
            0,
            0,
            -2147483648});
            this.numFindLinesRise.Name = "numFindLinesRise";
            this.numFindLinesRise.Size = new System.Drawing.Size(165, 24);
            this.numFindLinesRise.TabIndex = 8;
            this.numFindLinesRise.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Chartreuse;
            this.label3.Location = new System.Drawing.Point(15, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Rise Over Width:";
            // 
            // btnFindRise
            // 
            this.btnFindRise.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnFindRise.Location = new System.Drawing.Point(761, 35);
            this.btnFindRise.Name = "btnFindRise";
            this.btnFindRise.Size = new System.Drawing.Size(126, 33);
            this.btnFindRise.TabIndex = 2;
            this.btnFindRise.Text = "Find Rise";
            this.btnFindRise.UseVisualStyleBackColor = true;
            this.btnFindRise.Click += new System.EventHandler(this.btnFindRise_Click);
            // 
            // btnCountLines
            // 
            this.btnCountLines.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnCountLines.Location = new System.Drawing.Point(603, 35);
            this.btnCountLines.Name = "btnCountLines";
            this.btnCountLines.Size = new System.Drawing.Size(126, 33);
            this.btnCountLines.TabIndex = 1;
            this.btnCountLines.Text = "Count Lines";
            this.btnCountLines.UseVisualStyleBackColor = true;
            this.btnCountLines.Click += new System.EventHandler(this.btnCountLines_Click);
            // 
            // btnDrawLines
            // 
            this.btnDrawLines.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDrawLines.Location = new System.Drawing.Point(444, 35);
            this.btnDrawLines.Name = "btnDrawLines";
            this.btnDrawLines.Size = new System.Drawing.Size(126, 33);
            this.btnDrawLines.TabIndex = 0;
            this.btnDrawLines.Text = "Draw Lines";
            this.btnDrawLines.UseVisualStyleBackColor = true;
            this.btnDrawLines.Click += new System.EventHandler(this.btnDrawLines_Click);
            // 
            // splitContainer11
            // 
            this.splitContainer11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer11.Location = new System.Drawing.Point(0, 0);
            this.splitContainer11.Name = "splitContainer11";
            // 
            // splitContainer11.Panel1
            // 
            this.splitContainer11.Panel1.AutoScroll = true;
            this.splitContainer11.Panel1.Controls.Add(this.pbFindLines1);
            // 
            // splitContainer11.Panel2
            // 
            this.splitContainer11.Panel2.AutoScroll = true;
            this.splitContainer11.Panel2.Controls.Add(this.pbFindLines2);
            this.splitContainer11.Size = new System.Drawing.Size(1497, 626);
            this.splitContainer11.SplitterDistance = 543;
            this.splitContainer11.TabIndex = 0;
            // 
            // pbFindLines1
            // 
            this.pbFindLines1.BackColor = System.Drawing.Color.DimGray;
            this.pbFindLines1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFindLines1.Location = new System.Drawing.Point(0, 0);
            this.pbFindLines1.Name = "pbFindLines1";
            this.pbFindLines1.Size = new System.Drawing.Size(543, 626);
            this.pbFindLines1.TabIndex = 0;
            this.pbFindLines1.TabStop = false;
            // 
            // pbFindLines2
            // 
            this.pbFindLines2.BackColor = System.Drawing.Color.DimGray;
            this.pbFindLines2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbFindLines2.Location = new System.Drawing.Point(0, 0);
            this.pbFindLines2.Name = "pbFindLines2";
            this.pbFindLines2.Size = new System.Drawing.Size(950, 626);
            this.pbFindLines2.TabIndex = 0;
            this.pbFindLines2.TabStop = false;
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.splitContainer1);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabLogs.Size = new System.Drawing.Size(1503, 747);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Black;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 2);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.splitContainer1.Panel1.Controls.Add(this.btnClearLogs);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.rtbLogs);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1497, 743);
            this.splitContainer1.SplitterDistance = 83;
            this.splitContainer1.TabIndex = 0;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Location = new System.Drawing.Point(667, 23);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(123, 30);
            this.btnClearLogs.TabIndex = 0;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // rtbLogs
            // 
            this.rtbLogs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.rtbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbLogs.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbLogs.Location = new System.Drawing.Point(0, 0);
            this.rtbLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.rtbLogs.Name = "rtbLogs";
            this.rtbLogs.ReadOnly = true;
            this.rtbLogs.Size = new System.Drawing.Size(1497, 656);
            this.rtbLogs.TabIndex = 0;
            this.rtbLogs.Text = "";
            this.rtbLogs.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.panel1.Size = new System.Drawing.Size(1497, 656);
            this.panel1.TabIndex = 1;
            // 
            // tabTiming
            // 
            this.tabTiming.Controls.Add(this.splitContainer14);
            this.tabTiming.Location = new System.Drawing.Point(4, 25);
            this.tabTiming.Name = "tabTiming";
            this.tabTiming.Padding = new System.Windows.Forms.Padding(3);
            this.tabTiming.Size = new System.Drawing.Size(1503, 747);
            this.tabTiming.TabIndex = 7;
            this.tabTiming.Text = "Timing";
            this.tabTiming.UseVisualStyleBackColor = true;
            // 
            // splitContainer14
            // 
            this.splitContainer14.BackColor = System.Drawing.Color.Black;
            this.splitContainer14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer14.Location = new System.Drawing.Point(3, 3);
            this.splitContainer14.Name = "splitContainer14";
            this.splitContainer14.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer14.Panel1
            // 
            this.splitContainer14.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer14.Panel2
            // 
            this.splitContainer14.Panel2.Controls.Add(this.splitContainer15);
            this.splitContainer14.Size = new System.Drawing.Size(1497, 741);
            this.splitContainer14.SplitterDistance = 116;
            this.splitContainer14.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel2.Controls.Add(this.gbTimingOptions);
            this.panel2.Controls.Add(this.btnClearTiming);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1497, 116);
            this.panel2.TabIndex = 0;
            // 
            // gbTimingOptions
            // 
            this.gbTimingOptions.Controls.Add(this.cbTmgTextReadReport);
            this.gbTimingOptions.Controls.Add(this.cbTmgCompareAgainstActual);
            this.gbTimingOptions.Controls.Add(this.cbTmgReadText);
            this.gbTimingOptions.Controls.Add(this.cbTmgFindClosestTemplate);
            this.gbTimingOptions.Controls.Add(this.cbTmgCountTextImageCharacters);
            this.gbTimingOptions.Controls.Add(this.cbTmgFindTextImageCharacters);
            this.gbTimingOptions.Controls.Add(this.cbTmgFindTextImageLines);
            this.gbTimingOptions.Controls.Add(this.cbTmgLoadTextImage);
            this.gbTimingOptions.Controls.Add(this.cbTmgLoadTemplate);
            this.gbTimingOptions.Controls.Add(this.cbTmgSaveTemplate);
            this.gbTimingOptions.Controls.Add(this.cbTmgCountTrainingCharacters);
            this.gbTimingOptions.Controls.Add(this.cbTmgFindTrainingCharacters);
            this.gbTimingOptions.Controls.Add(this.cbTmgFindTrainingLines);
            this.gbTimingOptions.Controls.Add(this.cbTmgLoadTrainingImage);
            this.gbTimingOptions.Controls.Add(this.cbTmgTrainFont);
            this.gbTimingOptions.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbTimingOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbTimingOptions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.gbTimingOptions.Location = new System.Drawing.Point(238, 0);
            this.gbTimingOptions.Name = "gbTimingOptions";
            this.gbTimingOptions.Size = new System.Drawing.Size(1259, 116);
            this.gbTimingOptions.TabIndex = 2;
            this.gbTimingOptions.TabStop = false;
            this.gbTimingOptions.Text = "Timing Options:  ";
            // 
            // cbTmgTextReadReport
            // 
            this.cbTmgTextReadReport.AutoSize = true;
            this.cbTmgTextReadReport.Location = new System.Drawing.Point(931, 88);
            this.cbTmgTextReadReport.Name = "cbTmgTextReadReport";
            this.cbTmgTextReadReport.Size = new System.Drawing.Size(146, 22);
            this.cbTmgTextReadReport.TabIndex = 14;
            this.cbTmgTextReadReport.Text = "Text Read Report";
            this.cbTmgTextReadReport.UseVisualStyleBackColor = true;
            this.cbTmgTextReadReport.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgCompareAgainstActual
            // 
            this.cbTmgCompareAgainstActual.AutoSize = true;
            this.cbTmgCompareAgainstActual.Location = new System.Drawing.Point(931, 60);
            this.cbTmgCompareAgainstActual.Name = "cbTmgCompareAgainstActual";
            this.cbTmgCompareAgainstActual.Size = new System.Drawing.Size(188, 22);
            this.cbTmgCompareAgainstActual.TabIndex = 13;
            this.cbTmgCompareAgainstActual.Text = "Compare Against Actual";
            this.cbTmgCompareAgainstActual.UseVisualStyleBackColor = true;
            this.cbTmgCompareAgainstActual.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgReadText
            // 
            this.cbTmgReadText.AutoSize = true;
            this.cbTmgReadText.Location = new System.Drawing.Point(931, 32);
            this.cbTmgReadText.Name = "cbTmgReadText";
            this.cbTmgReadText.Size = new System.Drawing.Size(154, 22);
            this.cbTmgReadText.TabIndex = 12;
            this.cbTmgReadText.Text = "Read Text (overall)";
            this.cbTmgReadText.UseVisualStyleBackColor = true;
            this.cbTmgReadText.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgFindClosestTemplate
            // 
            this.cbTmgFindClosestTemplate.AutoSize = true;
            this.cbTmgFindClosestTemplate.Location = new System.Drawing.Point(670, 88);
            this.cbTmgFindClosestTemplate.Name = "cbTmgFindClosestTemplate";
            this.cbTmgFindClosestTemplate.Size = new System.Drawing.Size(178, 22);
            this.cbTmgFindClosestTemplate.TabIndex = 11;
            this.cbTmgFindClosestTemplate.Text = "Find Closest Template";
            this.cbTmgFindClosestTemplate.UseVisualStyleBackColor = true;
            this.cbTmgFindClosestTemplate.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgCountTextImageCharacters
            // 
            this.cbTmgCountTextImageCharacters.AutoSize = true;
            this.cbTmgCountTextImageCharacters.Location = new System.Drawing.Point(670, 60);
            this.cbTmgCountTextImageCharacters.Name = "cbTmgCountTextImageCharacters";
            this.cbTmgCountTextImageCharacters.Size = new System.Drawing.Size(223, 22);
            this.cbTmgCountTextImageCharacters.TabIndex = 10;
            this.cbTmgCountTextImageCharacters.Text = "Count Text Image Characters";
            this.cbTmgCountTextImageCharacters.UseVisualStyleBackColor = true;
            this.cbTmgCountTextImageCharacters.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgFindTextImageCharacters
            // 
            this.cbTmgFindTextImageCharacters.AutoSize = true;
            this.cbTmgFindTextImageCharacters.Location = new System.Drawing.Point(670, 32);
            this.cbTmgFindTextImageCharacters.Name = "cbTmgFindTextImageCharacters";
            this.cbTmgFindTextImageCharacters.Size = new System.Drawing.Size(211, 22);
            this.cbTmgFindTextImageCharacters.TabIndex = 9;
            this.cbTmgFindTextImageCharacters.Text = "Find Text Image Characters";
            this.cbTmgFindTextImageCharacters.UseVisualStyleBackColor = true;
            this.cbTmgFindTextImageCharacters.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgFindTextImageLines
            // 
            this.cbTmgFindTextImageLines.AutoSize = true;
            this.cbTmgFindTextImageLines.Location = new System.Drawing.Point(458, 88);
            this.cbTmgFindTextImageLines.Name = "cbTmgFindTextImageLines";
            this.cbTmgFindTextImageLines.Size = new System.Drawing.Size(173, 22);
            this.cbTmgFindTextImageLines.TabIndex = 8;
            this.cbTmgFindTextImageLines.Text = "Find Text Image Lines";
            this.cbTmgFindTextImageLines.UseVisualStyleBackColor = true;
            this.cbTmgFindTextImageLines.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgLoadTextImage
            // 
            this.cbTmgLoadTextImage.AutoSize = true;
            this.cbTmgLoadTextImage.Location = new System.Drawing.Point(458, 60);
            this.cbTmgLoadTextImage.Name = "cbTmgLoadTextImage";
            this.cbTmgLoadTextImage.Size = new System.Drawing.Size(139, 22);
            this.cbTmgLoadTextImage.TabIndex = 7;
            this.cbTmgLoadTextImage.Text = "Load Text Image";
            this.cbTmgLoadTextImage.UseVisualStyleBackColor = true;
            this.cbTmgLoadTextImage.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgLoadTemplate
            // 
            this.cbTmgLoadTemplate.AutoSize = true;
            this.cbTmgLoadTemplate.Location = new System.Drawing.Point(458, 32);
            this.cbTmgLoadTemplate.Name = "cbTmgLoadTemplate";
            this.cbTmgLoadTemplate.Size = new System.Drawing.Size(128, 22);
            this.cbTmgLoadTemplate.TabIndex = 6;
            this.cbTmgLoadTemplate.Text = "Load Template";
            this.cbTmgLoadTemplate.UseVisualStyleBackColor = true;
            this.cbTmgLoadTemplate.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgSaveTemplate
            // 
            this.cbTmgSaveTemplate.AutoSize = true;
            this.cbTmgSaveTemplate.Location = new System.Drawing.Point(225, 88);
            this.cbTmgSaveTemplate.Name = "cbTmgSaveTemplate";
            this.cbTmgSaveTemplate.Size = new System.Drawing.Size(128, 22);
            this.cbTmgSaveTemplate.TabIndex = 5;
            this.cbTmgSaveTemplate.Text = "Save Template";
            this.cbTmgSaveTemplate.UseVisualStyleBackColor = true;
            this.cbTmgSaveTemplate.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgCountTrainingCharacters
            // 
            this.cbTmgCountTrainingCharacters.AutoSize = true;
            this.cbTmgCountTrainingCharacters.Location = new System.Drawing.Point(225, 60);
            this.cbTmgCountTrainingCharacters.Name = "cbTmgCountTrainingCharacters";
            this.cbTmgCountTrainingCharacters.Size = new System.Drawing.Size(203, 22);
            this.cbTmgCountTrainingCharacters.TabIndex = 4;
            this.cbTmgCountTrainingCharacters.Text = "Count Training Characters";
            this.cbTmgCountTrainingCharacters.UseVisualStyleBackColor = true;
            this.cbTmgCountTrainingCharacters.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgFindTrainingCharacters
            // 
            this.cbTmgFindTrainingCharacters.AutoSize = true;
            this.cbTmgFindTrainingCharacters.Location = new System.Drawing.Point(225, 32);
            this.cbTmgFindTrainingCharacters.Name = "cbTmgFindTrainingCharacters";
            this.cbTmgFindTrainingCharacters.Size = new System.Drawing.Size(191, 22);
            this.cbTmgFindTrainingCharacters.TabIndex = 3;
            this.cbTmgFindTrainingCharacters.Text = "Find Training Characters";
            this.cbTmgFindTrainingCharacters.UseVisualStyleBackColor = true;
            this.cbTmgFindTrainingCharacters.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgFindTrainingLines
            // 
            this.cbTmgFindTrainingLines.AutoSize = true;
            this.cbTmgFindTrainingLines.Location = new System.Drawing.Point(16, 88);
            this.cbTmgFindTrainingLines.Name = "cbTmgFindTrainingLines";
            this.cbTmgFindTrainingLines.Size = new System.Drawing.Size(153, 22);
            this.cbTmgFindTrainingLines.TabIndex = 2;
            this.cbTmgFindTrainingLines.Text = "Find Training Lines";
            this.cbTmgFindTrainingLines.UseVisualStyleBackColor = true;
            this.cbTmgFindTrainingLines.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgLoadTrainingImage
            // 
            this.cbTmgLoadTrainingImage.AutoSize = true;
            this.cbTmgLoadTrainingImage.Location = new System.Drawing.Point(16, 60);
            this.cbTmgLoadTrainingImage.Name = "cbTmgLoadTrainingImage";
            this.cbTmgLoadTrainingImage.Size = new System.Drawing.Size(163, 22);
            this.cbTmgLoadTrainingImage.TabIndex = 1;
            this.cbTmgLoadTrainingImage.Text = "Load Training Image";
            this.cbTmgLoadTrainingImage.UseVisualStyleBackColor = true;
            this.cbTmgLoadTrainingImage.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // cbTmgTrainFont
            // 
            this.cbTmgTrainFont.AutoSize = true;
            this.cbTmgTrainFont.Location = new System.Drawing.Point(16, 32);
            this.cbTmgTrainFont.Name = "cbTmgTrainFont";
            this.cbTmgTrainFont.Size = new System.Drawing.Size(97, 22);
            this.cbTmgTrainFont.TabIndex = 0;
            this.cbTmgTrainFont.Text = "Train Font";
            this.cbTmgTrainFont.UseVisualStyleBackColor = true;
            this.cbTmgTrainFont.CheckedChanged += new System.EventHandler(this.cbTiming_CheckedChanged);
            // 
            // btnClearTiming
            // 
            this.btnClearTiming.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnClearTiming.Location = new System.Drawing.Point(36, 32);
            this.btnClearTiming.Name = "btnClearTiming";
            this.btnClearTiming.Size = new System.Drawing.Size(126, 33);
            this.btnClearTiming.TabIndex = 1;
            this.btnClearTiming.Text = "Clear Timing";
            this.btnClearTiming.UseVisualStyleBackColor = true;
            this.btnClearTiming.Click += new System.EventHandler(this.btnClearTiming_Click);
            // 
            // splitContainer15
            // 
            this.splitContainer15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer15.Location = new System.Drawing.Point(0, 0);
            this.splitContainer15.Name = "splitContainer15";
            // 
            // splitContainer15.Panel1
            // 
            this.splitContainer15.Panel1.Controls.Add(this.lbTimingOutput);
            // 
            // splitContainer15.Panel2
            // 
            this.splitContainer15.Panel2.Controls.Add(this.gridTimingOutput);
            this.splitContainer15.Size = new System.Drawing.Size(1497, 621);
            this.splitContainer15.SplitterDistance = 1280;
            this.splitContainer15.TabIndex = 0;
            // 
            // lbTimingOutput
            // 
            this.lbTimingOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lbTimingOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTimingOutput.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTimingOutput.FormattingEnabled = true;
            this.lbTimingOutput.HorizontalScrollbar = true;
            this.lbTimingOutput.ItemHeight = 17;
            this.lbTimingOutput.Location = new System.Drawing.Point(0, 0);
            this.lbTimingOutput.Name = "lbTimingOutput";
            this.lbTimingOutput.Size = new System.Drawing.Size(1280, 621);
            this.lbTimingOutput.TabIndex = 0;
            // 
            // gridTimingOutput
            // 
            this.gridTimingOutput.AllowUserToAddRows = false;
            this.gridTimingOutput.AllowUserToDeleteRows = false;
            this.gridTimingOutput.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.gridTimingOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridTimingOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTimingOutput.Location = new System.Drawing.Point(0, 0);
            this.gridTimingOutput.Name = "gridTimingOutput";
            this.gridTimingOutput.ReadOnly = true;
            this.gridTimingOutput.RowHeadersWidth = 51;
            this.gridTimingOutput.RowTemplate.Height = 24;
            this.gridTimingOutput.Size = new System.Drawing.Size(213, 621);
            this.gridTimingOutput.TabIndex = 0;
            // 
            // lblReadImages
            // 
            this.lblReadImages.AutoSize = true;
            this.lblReadImages.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReadImages.ForeColor = System.Drawing.Color.Chartreuse;
            this.lblReadImages.Location = new System.Drawing.Point(32, 361);
            this.lblReadImages.Name = "lblReadImages";
            this.lblReadImages.Size = new System.Drawing.Size(148, 18);
            this.lblReadImages.TabIndex = 9;
            this.lblReadImages.Text = "Read Images:  ";
            // 
            // comboReadImages
            // 
            this.comboReadImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboReadImages.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboReadImages.FormattingEnabled = true;
            this.comboReadImages.Location = new System.Drawing.Point(48, 382);
            this.comboReadImages.Name = "comboReadImages";
            this.comboReadImages.Size = new System.Drawing.Size(220, 28);
            this.comboReadImages.TabIndex = 10;
            this.comboReadImages.SelectedValueChanged += new System.EventHandler(this.comboReadImages_SelectedValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("OCR A Extended", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Chartreuse;
            this.label4.Location = new System.Drawing.Point(32, 433);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(188, 18);
            this.label4.TabIndex = 11;
            this.label4.Text = "Known Templates:  ";
            // 
            // comboKnownTemplates
            // 
            this.comboKnownTemplates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboKnownTemplates.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboKnownTemplates.FormattingEnabled = true;
            this.comboKnownTemplates.Location = new System.Drawing.Point(48, 454);
            this.comboKnownTemplates.Name = "comboKnownTemplates";
            this.comboKnownTemplates.Size = new System.Drawing.Size(220, 28);
            this.comboKnownTemplates.TabIndex = 12;
            this.comboKnownTemplates.SelectedValueChanged += new System.EventHandler(this.comboKnownTemplates_SelectedValueChanged);
            // 
            // cbSaveTemplatePretty
            // 
            this.cbSaveTemplatePretty.AutoSize = true;
            this.cbSaveTemplatePretty.Checked = true;
            this.cbSaveTemplatePretty.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSaveTemplatePretty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSaveTemplatePretty.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.cbSaveTemplatePretty.Location = new System.Drawing.Point(1193, 71);
            this.cbSaveTemplatePretty.Name = "cbSaveTemplatePretty";
            this.cbSaveTemplatePretty.Size = new System.Drawing.Size(126, 22);
            this.cbSaveTemplatePretty.TabIndex = 4;
            this.cbSaveTemplatePretty.Text = "Save As Pretty";
            this.cbSaveTemplatePretty.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1511, 804);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Region Analysis v0.1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.pnlMainOptions.ResumeLayout(false);
            this.pnlMainOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRgbThresh)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.pnlMainImagePaths.ResumeLayout(false);
            this.pnlMainImagePaths.PerformLayout();
            this.pnlMainImages.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImageOut)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageIn)).EndInit();
            this.tabLines.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.pnlRowOptions.ResumeLayout(false);
            this.splitContainer6.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
            this.splitContainer6.ResumeLayout(false);
            this.tabCharacters.ResumeLayout(false);
            this.splitContainer7.Panel1.ResumeLayout(false);
            this.splitContainer7.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
            this.splitContainer7.ResumeLayout(false);
            this.pnlCharacterOptions.ResumeLayout(false);
            this.splitContainer8.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
            this.splitContainer8.ResumeLayout(false);
            this.tabRegions.ResumeLayout(false);
            this.tabsRegions.ResumeLayout(false);
            this.tabRegionCounts.ResumeLayout(false);
            this.splitContainer9.Panel1.ResumeLayout(false);
            this.splitContainer9.Panel1.PerformLayout();
            this.splitContainer9.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer9)).EndInit();
            this.splitContainer9.ResumeLayout(false);
            this.tabReadText.ResumeLayout(false);
            this.splitContainer12.Panel1.ResumeLayout(false);
            this.splitContainer12.Panel1.PerformLayout();
            this.splitContainer12.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer12)).EndInit();
            this.splitContainer12.ResumeLayout(false);
            this.splitContainer13.Panel1.ResumeLayout(false);
            this.splitContainer13.Panel1.PerformLayout();
            this.splitContainer13.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer13)).EndInit();
            this.splitContainer13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbReadTextImage)).EndInit();
            this.tabFindLines.ResumeLayout(false);
            this.splitContainer10.Panel1.ResumeLayout(false);
            this.splitContainer10.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer10)).EndInit();
            this.splitContainer10.ResumeLayout(false);
            this.gbFindLinesOptions.ResumeLayout(false);
            this.gbFindLinesOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFindLinesRise)).EndInit();
            this.splitContainer11.Panel1.ResumeLayout(false);
            this.splitContainer11.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer11)).EndInit();
            this.splitContainer11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbFindLines1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFindLines2)).EndInit();
            this.tabLogs.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabTiming.ResumeLayout(false);
            this.splitContainer14.Panel1.ResumeLayout(false);
            this.splitContainer14.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer14)).EndInit();
            this.splitContainer14.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.gbTimingOptions.ResumeLayout(false);
            this.gbTimingOptions.PerformLayout();
            this.splitContainer15.Panel1.ResumeLayout(false);
            this.splitContainer15.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer15)).EndInit();
            this.splitContainer15.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTimingOutput)).EndInit();
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
        private System.Windows.Forms.RichTextBox rtbLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel pnlMainOptions;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel pnlMainImagePaths;
        private System.Windows.Forms.Button btnLoadImage;
        private System.Windows.Forms.TextBox tbFileOut;
        private System.Windows.Forms.TextBox tbFileIn;
        private System.Windows.Forms.Label lblFileOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlMainImages;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox pbImageOut;
        private System.Windows.Forms.PictureBox pbImageIn;
        private System.Windows.Forms.Button btnSaveImage;
        private System.Windows.Forms.TabPage tabLines;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboKnownImages;
        private System.Windows.Forms.NumericUpDown numRgbThresh;
        private System.Windows.Forms.Label lblRgbThresh;
        private System.Windows.Forms.Panel pnlRowOptions;
        private System.Windows.Forms.Button btnGetTextRows;
        private System.Windows.Forms.FlowLayoutPanel flowRowImages;
        private System.Windows.Forms.TabPage tabCharacters;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Panel pnlCharacterOptions;
        private System.Windows.Forms.Button btnGetCharacters;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.FlowLayoutPanel flowCharacters;
        private System.Windows.Forms.TabPage tabRegions;
        private System.Windows.Forms.TabControl tabsRegions;
        private System.Windows.Forms.TabPage tabRegionCounts;
        private System.Windows.Forms.SplitContainer splitContainer9;
        private System.Windows.Forms.RichTextBox rtbRegionCounts;
        private System.Windows.Forms.Button btnGetRegionCounts;
        private System.Windows.Forms.TabPage tabFindLines;
        private System.Windows.Forms.SplitContainer splitContainer10;
        private System.Windows.Forms.SplitContainer splitContainer11;
        private System.Windows.Forms.PictureBox pbFindLines1;
        private System.Windows.Forms.PictureBox pbFindLines2;
        private System.Windows.Forms.GroupBox gbFindLinesOptions;
        private System.Windows.Forms.Button btnDrawLines;
        private System.Windows.Forms.Button btnCountLines;
        private System.Windows.Forms.Button btnFindRise;
        private System.Windows.Forms.NumericUpDown numFindLinesRise;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRegionsSaveTemplates;
        private System.Windows.Forms.Button btnRegionsLoadTemplates;
        private System.Windows.Forms.TextBox tbRegionsTemplatePath;
        private System.Windows.Forms.TabPage tabReadText;
        private System.Windows.Forms.SplitContainer splitContainer12;
        private System.Windows.Forms.Button btnLoadTextImage;
        private System.Windows.Forms.SplitContainer splitContainer13;
        private System.Windows.Forms.PictureBox pbReadTextImage;
        private System.Windows.Forms.RichTextBox rtbReadTextImage;
        private System.Windows.Forms.TextBox tbReadTextImageFile;
        private System.Windows.Forms.Button btnReadTextImage;
        private System.Windows.Forms.TabPage tabTiming;
        private System.Windows.Forms.SplitContainer splitContainer14;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClearTiming;
        private System.Windows.Forms.SplitContainer splitContainer15;
        private System.Windows.Forms.ListBox lbTimingOutput;
        private System.Windows.Forms.DataGridView gridTimingOutput;
        private System.Windows.Forms.GroupBox gbTimingOptions;
        private System.Windows.Forms.CheckBox cbTmgTextReadReport;
        private System.Windows.Forms.CheckBox cbTmgCompareAgainstActual;
        private System.Windows.Forms.CheckBox cbTmgReadText;
        private System.Windows.Forms.CheckBox cbTmgFindClosestTemplate;
        private System.Windows.Forms.CheckBox cbTmgCountTextImageCharacters;
        private System.Windows.Forms.CheckBox cbTmgFindTextImageCharacters;
        private System.Windows.Forms.CheckBox cbTmgFindTextImageLines;
        private System.Windows.Forms.CheckBox cbTmgLoadTextImage;
        private System.Windows.Forms.CheckBox cbTmgLoadTemplate;
        private System.Windows.Forms.CheckBox cbTmgSaveTemplate;
        private System.Windows.Forms.CheckBox cbTmgCountTrainingCharacters;
        private System.Windows.Forms.CheckBox cbTmgFindTrainingCharacters;
        private System.Windows.Forms.CheckBox cbTmgFindTrainingLines;
        private System.Windows.Forms.CheckBox cbTmgLoadTrainingImage;
        private System.Windows.Forms.CheckBox cbTmgTrainFont;
        private System.Windows.Forms.ComboBox comboKnownTemplates;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboReadImages;
        private System.Windows.Forms.Label lblReadImages;
        private System.Windows.Forms.CheckBox cbSaveTemplatePretty;
    }
}

