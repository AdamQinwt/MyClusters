namespace MyClusters
{
    partial class FrmAnalyze
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
            this.gbOpt = new System.Windows.Forms.GroupBox();
            this.txtTime = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.btnParams = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.colK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFinalK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.gbOpt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOpt
            // 
            this.gbOpt.Controls.Add(this.txtTime);
            this.gbOpt.Controls.Add(this.txtTo);
            this.gbOpt.Controls.Add(this.txtFrom);
            this.gbOpt.Controls.Add(this.btnParams);
            this.gbOpt.Controls.Add(this.btnStart);
            this.gbOpt.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbOpt.Location = new System.Drawing.Point(0, 0);
            this.gbOpt.Name = "gbOpt";
            this.gbOpt.Size = new System.Drawing.Size(615, 98);
            this.gbOpt.TabIndex = 0;
            this.gbOpt.TabStop = false;
            this.gbOpt.Text = "Options";
            // 
            // txtTime
            // 
            this.txtTime.Location = new System.Drawing.Point(322, 38);
            this.txtTime.Name = "txtTime";
            this.txtTime.Size = new System.Drawing.Size(100, 25);
            this.txtTime.TabIndex = 4;
            this.txtTime.Text = "5";
            this.txtTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(189, 38);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(100, 25);
            this.txtTo.TabIndex = 3;
            this.txtTo.Text = "10";
            this.txtTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(57, 38);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(100, 25);
            this.txtFrom.TabIndex = 2;
            this.txtFrom.Text = "1";
            this.txtFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnParams
            // 
            this.btnParams.Location = new System.Drawing.Point(530, 59);
            this.btnParams.Name = "btnParams";
            this.btnParams.Size = new System.Drawing.Size(75, 23);
            this.btnParams.TabIndex = 1;
            this.btnParams.Text = "参数";
            this.btnParams.UseVisualStyleBackColor = true;
            this.btnParams.Click += new System.EventHandler(this.btnParams_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(530, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(79, 28);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "开始";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // dgvResults
            // 
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colK,
            this.colFinalK,
            this.colDistance});
            this.dgvResults.Location = new System.Drawing.Point(0, 98);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 27;
            this.dgvResults.Size = new System.Drawing.Size(621, 161);
            this.dgvResults.TabIndex = 1;
            this.dgvResults.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvResults_RowHeaderMouseDoubleClick);
            // 
            // colK
            // 
            this.colK.HeaderText = "K";
            this.colK.Name = "colK";
            this.colK.ReadOnly = true;
            // 
            // colFinalK
            // 
            this.colFinalK.HeaderText = "最终K";
            this.colFinalK.Name = "colFinalK";
            this.colFinalK.ReadOnly = true;
            // 
            // colDistance
            // 
            this.colDistance.HeaderText = "平均距离";
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            this.colDistance.Width = 300;
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlDraw.Location = new System.Drawing.Point(0, 265);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(615, 450);
            this.pnlDraw.TabIndex = 2;
            // 
            // FrmAnalyze
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 715);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.dgvResults);
            this.Controls.Add(this.gbOpt);
            this.Name = "FrmAnalyze";
            this.Text = "FrmAnalyze";
            this.Load += new System.EventHandler(this.FrmAnalyze_Load);
            this.gbOpt.ResumeLayout(false);
            this.gbOpt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOpt;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFinalK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.Button btnParams;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTime;
    }
}