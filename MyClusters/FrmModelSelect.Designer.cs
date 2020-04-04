namespace MyClusters
{
    partial class FrmModelSelect
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBestK = new System.Windows.Forms.TextBox();
            this.cbSelection = new System.Windows.Forms.ComboBox();
            this.btnParams = new System.Windows.Forms.Button();
            this.btnRun = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.colK = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colJ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBestK);
            this.groupBox1.Controls.Add(this.cbSelection);
            this.groupBox1.Controls.Add(this.btnParams);
            this.groupBox1.Controls.Add(this.btnRun);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(800, 116);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // txtBestK
            // 
            this.txtBestK.Location = new System.Drawing.Point(493, 62);
            this.txtBestK.Name = "txtBestK";
            this.txtBestK.Size = new System.Drawing.Size(168, 25);
            this.txtBestK.TabIndex = 3;
            this.txtBestK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbSelection
            // 
            this.cbSelection.FormattingEnabled = true;
            this.cbSelection.Items.AddRange(new object[] {
            "AIC",
            "BIC"});
            this.cbSelection.Location = new System.Drawing.Point(493, 23);
            this.cbSelection.Name = "cbSelection";
            this.cbSelection.Size = new System.Drawing.Size(168, 23);
            this.cbSelection.TabIndex = 2;
            this.cbSelection.Text = "AIC";
            // 
            // btnParams
            // 
            this.btnParams.Location = new System.Drawing.Point(713, 65);
            this.btnParams.Name = "btnParams";
            this.btnParams.Size = new System.Drawing.Size(75, 23);
            this.btnParams.TabIndex = 1;
            this.btnParams.Text = "参数";
            this.btnParams.UseVisualStyleBackColor = true;
            this.btnParams.Click += new System.EventHandler(this.btnParams_Click);
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(713, 24);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 0;
            this.btnRun.Text = "运行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colK,
            this.colJ});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridView1.Location = new System.Drawing.Point(0, 116);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(800, 150);
            this.dataGridView1.TabIndex = 1;
            // 
            // colK
            // 
            this.colK.HeaderText = "K";
            this.colK.Name = "colK";
            this.colK.ReadOnly = true;
            // 
            // colJ
            // 
            this.colJ.HeaderText = "J";
            this.colJ.Name = "colJ";
            this.colJ.ReadOnly = true;
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDraw.Location = new System.Drawing.Point(0, 266);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(800, 462);
            this.pnlDraw.TabIndex = 2;
            // 
            // FrmModelSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 728);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmModelSelect";
            this.Text = "FrmModelSelect";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBestK;
        private System.Windows.Forms.ComboBox cbSelection;
        private System.Windows.Forms.Button btnParams;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn colK;
        private System.Windows.Forms.DataGridViewTextBoxColumn colJ;
        private System.Windows.Forms.Panel pnlDraw;
    }
}