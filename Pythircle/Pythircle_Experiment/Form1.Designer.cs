//Pythircle
//(c) 2026 - TimeWarpToaster

//https://www.gnu.org/licenses/gpl-3.0.html

namespace Pythircle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbOptions = new System.Windows.Forms.GroupBox();
            this.rtbEllipseBehaviour = new System.Windows.Forms.RichTextBox();
            this.btnGoEllipse = new System.Windows.Forms.Button();
            this.tbEllipseHeight = new System.Windows.Forms.TextBox();
            this.lblEllipseHeight = new System.Windows.Forms.Label();
            this.tbEllipseWidth = new System.Windows.Forms.TextBox();
            this.lblEllipseWidth = new System.Windows.Forms.Label();
            this.lblCircleDiameter = new System.Windows.Forms.Label();
            this.tbCircleDiameter = new System.Windows.Forms.TextBox();
            this.btnGoCircle = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabImage = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.tabPrimer = new System.Windows.Forms.TabPage();
            this.rtbPrimer = new System.Windows.Forms.RichTextBox();
            this.tabLogs = new System.Windows.Forms.TabPage();
            this.lbLogs = new System.Windows.Forms.ListBox();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.rtbAbout = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbOptions.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabImage.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.tabPrimer.SuspendLayout();
            this.tabLogs.SuspendLayout();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbOptions);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1109, 630);
            this.splitContainer1.SplitterDistance = 251;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbOptions
            // 
            this.gbOptions.Controls.Add(this.rtbEllipseBehaviour);
            this.gbOptions.Controls.Add(this.btnGoEllipse);
            this.gbOptions.Controls.Add(this.tbEllipseHeight);
            this.gbOptions.Controls.Add(this.lblEllipseHeight);
            this.gbOptions.Controls.Add(this.tbEllipseWidth);
            this.gbOptions.Controls.Add(this.lblEllipseWidth);
            this.gbOptions.Controls.Add(this.lblCircleDiameter);
            this.gbOptions.Controls.Add(this.tbCircleDiameter);
            this.gbOptions.Controls.Add(this.btnGoCircle);
            this.gbOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbOptions.Location = new System.Drawing.Point(0, 0);
            this.gbOptions.Name = "gbOptions";
            this.gbOptions.Size = new System.Drawing.Size(251, 630);
            this.gbOptions.TabIndex = 0;
            this.gbOptions.TabStop = false;
            this.gbOptions.Text = "Options:  ";
            // 
            // rtbEllipseBehaviour
            // 
            this.rtbEllipseBehaviour.AcceptsTab = true;
            this.rtbEllipseBehaviour.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbEllipseBehaviour.BackColor = System.Drawing.SystemColors.Window;
            this.rtbEllipseBehaviour.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbEllipseBehaviour.Location = new System.Drawing.Point(12, 454);
            this.rtbEllipseBehaviour.Name = "rtbEllipseBehaviour";
            this.rtbEllipseBehaviour.ReadOnly = true;
            this.rtbEllipseBehaviour.Size = new System.Drawing.Size(217, 128);
            this.rtbEllipseBehaviour.TabIndex = 9;
            this.rtbEllipseBehaviour.Text = resources.GetString("rtbEllipseBehaviour.Text");
            // 
            // btnGoEllipse
            // 
            this.btnGoEllipse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoEllipse.Location = new System.Drawing.Point(134, 363);
            this.btnGoEllipse.Name = "btnGoEllipse";
            this.btnGoEllipse.Size = new System.Drawing.Size(94, 28);
            this.btnGoEllipse.TabIndex = 8;
            this.btnGoEllipse.Text = "Ellipse";
            this.btnGoEllipse.UseVisualStyleBackColor = true;
            this.btnGoEllipse.Click += new System.EventHandler(this.btnGoEllipse_Click);
            // 
            // tbEllipseHeight
            // 
            this.tbEllipseHeight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEllipseHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEllipseHeight.Location = new System.Drawing.Point(135, 321);
            this.tbEllipseHeight.Name = "tbEllipseHeight";
            this.tbEllipseHeight.Size = new System.Drawing.Size(93, 24);
            this.tbEllipseHeight.TabIndex = 7;
            this.tbEllipseHeight.Text = "251";
            // 
            // lblEllipseHeight
            // 
            this.lblEllipseHeight.AutoSize = true;
            this.lblEllipseHeight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEllipseHeight.Location = new System.Drawing.Point(13, 324);
            this.lblEllipseHeight.Name = "lblEllipseHeight";
            this.lblEllipseHeight.Size = new System.Drawing.Size(62, 18);
            this.lblEllipseHeight.TabIndex = 6;
            this.lblEllipseHeight.Text = "Height:  ";
            // 
            // tbEllipseWidth
            // 
            this.tbEllipseWidth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbEllipseWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEllipseWidth.Location = new System.Drawing.Point(135, 282);
            this.tbEllipseWidth.Name = "tbEllipseWidth";
            this.tbEllipseWidth.Size = new System.Drawing.Size(93, 24);
            this.tbEllipseWidth.TabIndex = 5;
            this.tbEllipseWidth.Text = "501";
            // 
            // lblEllipseWidth
            // 
            this.lblEllipseWidth.AutoSize = true;
            this.lblEllipseWidth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEllipseWidth.Location = new System.Drawing.Point(13, 285);
            this.lblEllipseWidth.Name = "lblEllipseWidth";
            this.lblEllipseWidth.Size = new System.Drawing.Size(58, 18);
            this.lblEllipseWidth.TabIndex = 4;
            this.lblEllipseWidth.Text = "Width:  ";
            // 
            // lblCircleDiameter
            // 
            this.lblCircleDiameter.AutoSize = true;
            this.lblCircleDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCircleDiameter.Location = new System.Drawing.Point(13, 132);
            this.lblCircleDiameter.Name = "lblCircleDiameter";
            this.lblCircleDiameter.Size = new System.Drawing.Size(80, 18);
            this.lblCircleDiameter.TabIndex = 3;
            this.lblCircleDiameter.Text = "Diameter:  ";
            // 
            // tbCircleDiameter
            // 
            this.tbCircleDiameter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbCircleDiameter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbCircleDiameter.Location = new System.Drawing.Point(135, 132);
            this.tbCircleDiameter.Name = "tbCircleDiameter";
            this.tbCircleDiameter.Size = new System.Drawing.Size(93, 24);
            this.tbCircleDiameter.TabIndex = 2;
            this.tbCircleDiameter.Text = "401";
            // 
            // btnGoCircle
            // 
            this.btnGoCircle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGoCircle.Location = new System.Drawing.Point(135, 171);
            this.btnGoCircle.Name = "btnGoCircle";
            this.btnGoCircle.Size = new System.Drawing.Size(94, 28);
            this.btnGoCircle.TabIndex = 0;
            this.btnGoCircle.Text = "Circle";
            this.btnGoCircle.UseVisualStyleBackColor = true;
            this.btnGoCircle.Click += new System.EventHandler(this.btnGoCircle_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabImage);
            this.tabControl1.Controls.Add(this.tabPrimer);
            this.tabControl1.Controls.Add(this.tabLogs);
            this.tabControl1.Controls.Add(this.tabAbout);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(854, 630);
            this.tabControl1.TabIndex = 0;
            // 
            // tabImage
            // 
            this.tabImage.Controls.Add(this.panel1);
            this.tabImage.Location = new System.Drawing.Point(4, 25);
            this.tabImage.Name = "tabImage";
            this.tabImage.Padding = new System.Windows.Forms.Padding(3);
            this.tabImage.Size = new System.Drawing.Size(846, 601);
            this.tabImage.TabIndex = 0;
            this.tabImage.Text = "Image";
            this.tabImage.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(840, 595);
            this.panel1.TabIndex = 0;
            // 
            // pbImage
            // 
            this.pbImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbImage.Location = new System.Drawing.Point(0, 0);
            this.pbImage.Name = "pbImage";
            this.pbImage.Size = new System.Drawing.Size(840, 595);
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // tabPrimer
            // 
            this.tabPrimer.Controls.Add(this.rtbPrimer);
            this.tabPrimer.Location = new System.Drawing.Point(4, 25);
            this.tabPrimer.Name = "tabPrimer";
            this.tabPrimer.Padding = new System.Windows.Forms.Padding(3);
            this.tabPrimer.Size = new System.Drawing.Size(846, 601);
            this.tabPrimer.TabIndex = 2;
            this.tabPrimer.Text = "Primer";
            this.tabPrimer.UseVisualStyleBackColor = true;
            // 
            // rtbPrimer
            // 
            this.rtbPrimer.AcceptsTab = true;
            this.rtbPrimer.BackColor = System.Drawing.SystemColors.Window;
            this.rtbPrimer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbPrimer.Font = new System.Drawing.Font("Calibri", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rtbPrimer.Location = new System.Drawing.Point(3, 3);
            this.rtbPrimer.Margin = new System.Windows.Forms.Padding(20, 10, 20, 5);
            this.rtbPrimer.Name = "rtbPrimer";
            this.rtbPrimer.ReadOnly = true;
            this.rtbPrimer.Size = new System.Drawing.Size(840, 595);
            this.rtbPrimer.TabIndex = 0;
            this.rtbPrimer.Text = "";
            // 
            // tabLogs
            // 
            this.tabLogs.Controls.Add(this.lbLogs);
            this.tabLogs.Location = new System.Drawing.Point(4, 25);
            this.tabLogs.Name = "tabLogs";
            this.tabLogs.Padding = new System.Windows.Forms.Padding(3);
            this.tabLogs.Size = new System.Drawing.Size(846, 601);
            this.tabLogs.TabIndex = 1;
            this.tabLogs.Text = "Logs";
            this.tabLogs.UseVisualStyleBackColor = true;
            // 
            // lbLogs
            // 
            this.lbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLogs.FormattingEnabled = true;
            this.lbLogs.ItemHeight = 16;
            this.lbLogs.Location = new System.Drawing.Point(3, 3);
            this.lbLogs.Name = "lbLogs";
            this.lbLogs.Size = new System.Drawing.Size(840, 595);
            this.lbLogs.TabIndex = 0;
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.rtbAbout);
            this.tabAbout.Location = new System.Drawing.Point(4, 25);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(846, 601);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // rtbAbout
            // 
            this.rtbAbout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtbAbout.Location = new System.Drawing.Point(3, 3);
            this.rtbAbout.Name = "rtbAbout";
            this.rtbAbout.ReadOnly = true;
            this.rtbAbout.Size = new System.Drawing.Size(840, 595);
            this.rtbAbout.TabIndex = 0;
            this.rtbAbout.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1109, 630);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Pythircle Example";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbOptions.ResumeLayout(false);
            this.gbOptions.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabImage.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.tabPrimer.ResumeLayout(false);
            this.tabLogs.ResumeLayout(false);
            this.tabAbout.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gbOptions;
        private System.Windows.Forms.Button btnGoCircle;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabImage;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.ListBox lbLogs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPrimer;
        private System.Windows.Forms.RichTextBox rtbPrimer;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.RichTextBox rtbAbout;
        private System.Windows.Forms.TextBox tbCircleDiameter;
        private System.Windows.Forms.Label lblCircleDiameter;
        private System.Windows.Forms.Button btnGoEllipse;
        private System.Windows.Forms.TextBox tbEllipseHeight;
        private System.Windows.Forms.Label lblEllipseHeight;
        private System.Windows.Forms.TextBox tbEllipseWidth;
        private System.Windows.Forms.Label lblEllipseWidth;
        private System.Windows.Forms.RichTextBox rtbEllipseBehaviour;
    }
}

