
namespace AggregationApp
{
    partial class CleanData
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
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.label1 = new System.Windows.Forms.Label();
            this.percentage2Lbl = new System.Windows.Forms.Label();
            this.hitcnt1Lbl = new System.Windows.Forms.Label();
            this.threshcolLbl = new System.Windows.Forms.Label();
            this.threshrowLbl = new System.Windows.Forms.Label();
            this.startbtn = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.localRadio = new System.Windows.Forms.RadioButton();
            this.remoteRadio = new System.Windows.Forms.RadioButton();
            this.cpus1Lbl = new System.Windows.Forms.Label();
            this.percentage1Lbl = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.keybtn = new System.Windows.Forms.Button();
            this.targetbtn = new System.Windows.Forms.Button();
            this.targetFileBoxLbl = new System.Windows.Forms.Label();
            this.keyFileBoxLbl = new System.Windows.Forms.Label();
            this.firstProcessPanel = new System.Windows.Forms.Panel();
            this.percentage1 = new AggregationApp.MyMaskedBox();
            this.cpus1 = new AggregationApp.MyMaskedBox();
            this.keyFileBox = new AggregationApp.MyMaskedBox();
            this.targetFileBox = new AggregationApp.MyMaskedBox();
            this.thirdProcessPanel = new System.Windows.Forms.Panel();
            this.threshcol = new AggregationApp.MyMaskedBox();
            this.threshrow = new AggregationApp.MyMaskedBox();
            this.secondProcessPanel = new System.Windows.Forms.Panel();
            this.hitcnt1 = new AggregationApp.MyMaskedBox();
            this.percentage2 = new AggregationApp.MyMaskedBox();
            this.startProcessPanel = new System.Windows.Forms.Panel();
            this.info = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.backBtn = new System.Windows.Forms.Button();
            this.nextBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.panel1.SuspendLayout();
            this.firstProcessPanel.SuspendLayout();
            this.thirdProcessPanel.SuspendLayout();
            this.secondProcessPanel.SuspendLayout();
            this.startProcessPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clean Data Portal";
            // 
            // percentage2Lbl
            // 
            this.percentage2Lbl.AutoSize = true;
            this.percentage2Lbl.Location = new System.Drawing.Point(23, 53);
            this.percentage2Lbl.Name = "percentage2Lbl";
            this.percentage2Lbl.Size = new System.Drawing.Size(61, 13);
            this.percentage2Lbl.TabIndex = 9;
            this.percentage2Lbl.Text = "% (0 - 100)*";
            // 
            // hitcnt1Lbl
            // 
            this.hitcnt1Lbl.AutoSize = true;
            this.hitcnt1Lbl.Location = new System.Drawing.Point(165, 53);
            this.hitcnt1Lbl.Name = "hitcnt1Lbl";
            this.hitcnt1Lbl.Size = new System.Drawing.Size(51, 13);
            this.hitcnt1Lbl.TabIndex = 11;
            this.hitcnt1Lbl.Text = "Hitcount*";
            // 
            // threshcolLbl
            // 
            this.threshcolLbl.AutoSize = true;
            this.threshcolLbl.Location = new System.Drawing.Point(168, 53);
            this.threshcolLbl.Name = "threshcolLbl";
            this.threshcolLbl.Size = new System.Drawing.Size(107, 13);
            this.threshcolLbl.TabIndex = 15;
            this.threshcolLbl.Text = "Threshold % Column*";
            // 
            // threshrowLbl
            // 
            this.threshrowLbl.AutoSize = true;
            this.threshrowLbl.Location = new System.Drawing.Point(23, 53);
            this.threshrowLbl.Name = "threshrowLbl";
            this.threshrowLbl.Size = new System.Drawing.Size(94, 13);
            this.threshrowLbl.TabIndex = 13;
            this.threshrowLbl.Text = "Threshold % Row*";
            // 
            // startbtn
            // 
            this.startbtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbtn.Location = new System.Drawing.Point(105, 73);
            this.startbtn.Name = "startbtn";
            this.startbtn.Size = new System.Drawing.Size(207, 75);
            this.startbtn.TabIndex = 13;
            this.startbtn.Text = "Start Process";
            this.startbtn.UseVisualStyleBackColor = true;
            this.startbtn.Click += new System.EventHandler(this.startbtn_Click);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(21, 20);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(255, 25);
            this.label12.TabIndex = 22;
            this.label12.Text = "Secondary Data Processing";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(21, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(226, 25);
            this.label13.TabIndex = 23;
            this.label13.Text = "Tertiary Data Processing";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.localRadio);
            this.panel1.Controls.Add(this.remoteRadio);
            this.panel1.Location = new System.Drawing.Point(326, 165);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(207, 75);
            this.panel1.TabIndex = 28;
            // 
            // localRadio
            // 
            this.localRadio.AutoSize = true;
            this.localRadio.Checked = true;
            this.localRadio.Location = new System.Drawing.Point(40, 15);
            this.localRadio.Name = "localRadio";
            this.localRadio.Size = new System.Drawing.Size(123, 17);
            this.localRadio.TabIndex = 11;
            this.localRadio.TabStop = true;
            this.localRadio.Text = "Files in Local System";
            this.localRadio.UseVisualStyleBackColor = true;
            this.localRadio.Click += new System.EventHandler(this.localRadio_CheckedChanged);
            // 
            // remoteRadio
            // 
            this.remoteRadio.AutoSize = true;
            this.remoteRadio.Location = new System.Drawing.Point(40, 38);
            this.remoteRadio.Name = "remoteRadio";
            this.remoteRadio.Size = new System.Drawing.Size(134, 17);
            this.remoteRadio.TabIndex = 12;
            this.remoteRadio.Text = "Files in Remote System";
            this.remoteRadio.UseVisualStyleBackColor = true;
            this.remoteRadio.Click += new System.EventHandler(this.remoteRadio_CheckedChanged);
            // 
            // cpus1Lbl
            // 
            this.cpus1Lbl.AutoSize = true;
            this.cpus1Lbl.Location = new System.Drawing.Point(18, 166);
            this.cpus1Lbl.Name = "cpus1Lbl";
            this.cpus1Lbl.Size = new System.Drawing.Size(90, 13);
            this.cpus1Lbl.TabIndex = 5;
            this.cpus1Lbl.Text = "Number of CPUs*";
            // 
            // percentage1Lbl
            // 
            this.percentage1Lbl.AutoSize = true;
            this.percentage1Lbl.Location = new System.Drawing.Point(160, 165);
            this.percentage1Lbl.Name = "percentage1Lbl";
            this.percentage1Lbl.Size = new System.Drawing.Size(61, 13);
            this.percentage1Lbl.TabIndex = 7;
            this.percentage1Lbl.Text = "% (0 - 100)*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(12, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(204, 25);
            this.label9.TabIndex = 16;
            this.label9.Text = "Initial Data Processing";
            // 
            // keybtn
            // 
            this.keybtn.Location = new System.Drawing.Point(407, 122);
            this.keybtn.Name = "keybtn";
            this.keybtn.Size = new System.Drawing.Size(126, 22);
            this.keybtn.TabIndex = 4;
            this.keybtn.Text = "Find in Local Directory";
            this.keybtn.UseVisualStyleBackColor = true;
            this.keybtn.Click += new System.EventHandler(this.btnKeyFile);
            // 
            // targetbtn
            // 
            this.targetbtn.Location = new System.Drawing.Point(407, 69);
            this.targetbtn.Name = "targetbtn";
            this.targetbtn.Size = new System.Drawing.Size(126, 22);
            this.targetbtn.TabIndex = 2;
            this.targetbtn.Text = "Find in Local Directory";
            this.targetbtn.UseVisualStyleBackColor = true;
            this.targetbtn.Click += new System.EventHandler(this.btnTargetFile);
            // 
            // targetFileBoxLbl
            // 
            this.targetFileBoxLbl.BackColor = System.Drawing.SystemColors.Control;
            this.targetFileBoxLbl.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.targetFileBoxLbl.Location = new System.Drawing.Point(18, 54);
            this.targetFileBoxLbl.Name = "targetFileBoxLbl";
            this.targetFileBoxLbl.Size = new System.Drawing.Size(522, 13);
            this.targetFileBoxLbl.TabIndex = 19;
            this.targetFileBoxLbl.Text = "Exact Path to Target Directory*";
            // 
            // keyFileBoxLbl
            // 
            this.keyFileBoxLbl.Location = new System.Drawing.Point(18, 107);
            this.keyFileBoxLbl.Name = "keyFileBoxLbl";
            this.keyFileBoxLbl.Size = new System.Drawing.Size(522, 13);
            this.keyFileBoxLbl.TabIndex = 20;
            this.keyFileBoxLbl.Text = "Exact Path to Key File*";
            // 
            // firstProcessPanel
            // 
            this.firstProcessPanel.Controls.Add(this.percentage1);
            this.firstProcessPanel.Controls.Add(this.cpus1);
            this.firstProcessPanel.Controls.Add(this.keyFileBox);
            this.firstProcessPanel.Controls.Add(this.targetFileBox);
            this.firstProcessPanel.Controls.Add(this.keyFileBoxLbl);
            this.firstProcessPanel.Controls.Add(this.targetFileBoxLbl);
            this.firstProcessPanel.Controls.Add(this.targetbtn);
            this.firstProcessPanel.Controls.Add(this.keybtn);
            this.firstProcessPanel.Controls.Add(this.label9);
            this.firstProcessPanel.Controls.Add(this.percentage1Lbl);
            this.firstProcessPanel.Controls.Add(this.cpus1Lbl);
            this.firstProcessPanel.Controls.Add(this.panel1);
            this.firstProcessPanel.Location = new System.Drawing.Point(2, 55);
            this.firstProcessPanel.Name = "firstProcessPanel";
            this.firstProcessPanel.Size = new System.Drawing.Size(555, 274);
            this.firstProcessPanel.TabIndex = 29;
            // 
            // percentage1
            // 
            this.percentage1.BorderColor = System.Drawing.Color.Black;
            this.percentage1.Location = new System.Drawing.Point(158, 182);
            this.percentage1.Mask = "000";
            this.percentage1.Name = "percentage1";
            this.percentage1.Size = new System.Drawing.Size(100, 20);
            this.percentage1.TabIndex = 6;
            this.percentage1.Text = "75";
            // 
            // cpus1
            // 
            this.cpus1.BorderColor = System.Drawing.Color.Black;
            this.cpus1.Location = new System.Drawing.Point(16, 182);
            this.cpus1.Mask = "00000";
            this.cpus1.Name = "cpus1";
            this.cpus1.Size = new System.Drawing.Size(100, 20);
            this.cpus1.TabIndex = 5;
            this.cpus1.Text = "24";
            // 
            // keyFileBox
            // 
            this.keyFileBox.BorderColor = System.Drawing.Color.Black;
            this.keyFileBox.Location = new System.Drawing.Point(16, 123);
            this.keyFileBox.Name = "keyFileBox";
            this.keyFileBox.Size = new System.Drawing.Size(397, 20);
            this.keyFileBox.TabIndex = 3;
            this.keyFileBox.Text = "/home/wrsggl/TAS/WheatKeyfile_with_RC.txt";
            // 
            // targetFileBox
            // 
            this.targetFileBox.BorderColor = System.Drawing.Color.Black;
            this.targetFileBox.Location = new System.Drawing.Point(16, 70);
            this.targetFileBox.Name = "targetFileBox";
            this.targetFileBox.Size = new System.Drawing.Size(397, 20);
            this.targetFileBox.TabIndex = 1;
            this.targetFileBox.Text = "/data/TASresults/APP_TEST";
            // 
            // thirdProcessPanel
            // 
            this.thirdProcessPanel.Controls.Add(this.threshcol);
            this.thirdProcessPanel.Controls.Add(this.threshrow);
            this.thirdProcessPanel.Controls.Add(this.label13);
            this.thirdProcessPanel.Controls.Add(this.threshcolLbl);
            this.thirdProcessPanel.Controls.Add(this.threshrowLbl);
            this.thirdProcessPanel.Location = new System.Drawing.Point(583, 55);
            this.thirdProcessPanel.Name = "thirdProcessPanel";
            this.thirdProcessPanel.Size = new System.Drawing.Size(303, 134);
            this.thirdProcessPanel.TabIndex = 30;
            this.thirdProcessPanel.Visible = false;
            // 
            // threshcol
            // 
            this.threshcol.BorderColor = System.Drawing.Color.Black;
            this.threshcol.Location = new System.Drawing.Point(171, 70);
            this.threshcol.Mask = "000";
            this.threshcol.Name = "threshcol";
            this.threshcol.Size = new System.Drawing.Size(100, 20);
            this.threshcol.TabIndex = 10;
            this.threshcol.Text = "75";
            this.threshcol.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.threshcol_MaskInputRejected);
            // 
            // threshrow
            // 
            this.threshrow.BorderColor = System.Drawing.Color.Black;
            this.threshrow.Location = new System.Drawing.Point(23, 70);
            this.threshrow.Mask = "000";
            this.threshrow.Name = "threshrow";
            this.threshrow.Size = new System.Drawing.Size(100, 20);
            this.threshrow.TabIndex = 9;
            this.threshrow.Text = "75";
            this.threshrow.MaskInputRejected += new System.Windows.Forms.MaskInputRejectedEventHandler(this.threshrow_MaskInputRejected);
            // 
            // secondProcessPanel
            // 
            this.secondProcessPanel.Controls.Add(this.hitcnt1);
            this.secondProcessPanel.Controls.Add(this.percentage2);
            this.secondProcessPanel.Controls.Add(this.percentage2Lbl);
            this.secondProcessPanel.Controls.Add(this.hitcnt1Lbl);
            this.secondProcessPanel.Controls.Add(this.label12);
            this.secondProcessPanel.Location = new System.Drawing.Point(901, 55);
            this.secondProcessPanel.Name = "secondProcessPanel";
            this.secondProcessPanel.Size = new System.Drawing.Size(303, 134);
            this.secondProcessPanel.TabIndex = 31;
            this.secondProcessPanel.Visible = false;
            // 
            // hitcnt1
            // 
            this.hitcnt1.BorderColor = System.Drawing.Color.Black;
            this.hitcnt1.Location = new System.Drawing.Point(168, 70);
            this.hitcnt1.Mask = "00000";
            this.hitcnt1.Name = "hitcnt1";
            this.hitcnt1.Size = new System.Drawing.Size(100, 20);
            this.hitcnt1.TabIndex = 8;
            this.hitcnt1.Text = "5";
            // 
            // percentage2
            // 
            this.percentage2.BorderColor = System.Drawing.Color.Black;
            this.percentage2.Location = new System.Drawing.Point(26, 70);
            this.percentage2.Mask = "000";
            this.percentage2.Name = "percentage2";
            this.percentage2.Size = new System.Drawing.Size(100, 20);
            this.percentage2.TabIndex = 7;
            this.percentage2.Text = "75";
            // 
            // startProcessPanel
            // 
            this.startProcessPanel.Controls.Add(this.info);
            this.startProcessPanel.Controls.Add(this.progressBar1);
            this.startProcessPanel.Controls.Add(this.startbtn);
            this.startProcessPanel.Location = new System.Drawing.Point(661, 209);
            this.startProcessPanel.Name = "startProcessPanel";
            this.startProcessPanel.Size = new System.Drawing.Size(418, 163);
            this.startProcessPanel.TabIndex = 32;
            this.startProcessPanel.Visible = false;
            // 
            // info
            // 
            this.info.AutoSize = true;
            this.info.Location = new System.Drawing.Point(28, 11);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(0, 13);
            this.info.TabIndex = 15;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(22, 28);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(370, 23);
            this.progressBar1.TabIndex = 14;
            // 
            // backBtn
            // 
            this.backBtn.Enabled = false;
            this.backBtn.Location = new System.Drawing.Point(18, 344);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(75, 23);
            this.backBtn.TabIndex = 33;
            this.backBtn.Text = "Back";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.backBtn_Click);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(460, 344);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(75, 23);
            this.nextBtn.TabIndex = 34;
            this.nextBtn.Text = "Next";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // CleanData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 386);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.backBtn);
            this.Controls.Add(this.startProcessPanel);
            this.Controls.Add(this.secondProcessPanel);
            this.Controls.Add(this.thirdProcessPanel);
            this.Controls.Add(this.firstProcessPanel);
            this.Controls.Add(this.label1);
            this.Name = "CleanData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CleanData";
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.firstProcessPanel.ResumeLayout(false);
            this.firstProcessPanel.PerformLayout();
            this.thirdProcessPanel.ResumeLayout(false);
            this.thirdProcessPanel.PerformLayout();
            this.secondProcessPanel.ResumeLayout(false);
            this.secondProcessPanel.PerformLayout();
            this.startProcessPanel.ResumeLayout(false);
            this.startProcessPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label percentage2Lbl;
        private System.Windows.Forms.Label hitcnt1Lbl;
        private System.Windows.Forms.Label threshcolLbl;
        private System.Windows.Forms.Label threshrowLbl;
        private System.Windows.Forms.Button startbtn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private MyMaskedBox hitcnt1;
        private MyMaskedBox threshcol;
        private MyMaskedBox threshrow;
        private MyMaskedBox percentage2;
        private System.Windows.Forms.Panel firstProcessPanel;
        private MyMaskedBox percentage1;
        private MyMaskedBox cpus1;
        private MyMaskedBox keyFileBox;
        private MyMaskedBox targetFileBox;
        private System.Windows.Forms.Label keyFileBoxLbl;
        private System.Windows.Forms.Label targetFileBoxLbl;
        private System.Windows.Forms.Button targetbtn;
        private System.Windows.Forms.Button keybtn;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label percentage1Lbl;
        private System.Windows.Forms.Label cpus1Lbl;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton localRadio;
        private System.Windows.Forms.RadioButton remoteRadio;
        private System.Windows.Forms.Panel startProcessPanel;
        private System.Windows.Forms.Panel secondProcessPanel;
        private System.Windows.Forms.Panel thirdProcessPanel;
        private System.Windows.Forms.Button nextBtn;
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label info;
    }
}

