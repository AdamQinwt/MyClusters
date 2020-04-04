namespace MyClusters
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlControls = new System.Windows.Forms.Panel();
            this.btnAnal = new System.Windows.Forms.Button();
            this.btnSetParams = new System.Windows.Forms.Button();
            this.dataGridViewResults = new System.Windows.Forms.DataGridView();
            this.colDistance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colClassIndx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.progressBarMain = new System.Windows.Forms.ProgressBar();
            this.btnParam = new System.Windows.Forms.Button();
            this.txtK = new System.Windows.Forms.TextBox();
            this.listBoxDistance = new System.Windows.Forms.ListBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.listClusterers = new System.Windows.Forms.ListBox();
            this.btnPointSettings = new System.Windows.Forms.Button();
            this.lblV = new System.Windows.Forms.Label();
            this.cboxV = new System.Windows.Forms.ComboBox();
            this.btnGeneratePoints = new System.Windows.Forms.Button();
            this.txtBoxN = new System.Windows.Forms.TextBox();
            this.pnlDraw = new System.Windows.Forms.Panel();
            this.openFileDialogConfig = new System.Windows.Forms.OpenFileDialog();
            this.timerMain = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogParam = new System.Windows.Forms.OpenFileDialog();
            this.btnModelSelect = new System.Windows.Forms.Button();
            this.pnlControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlControls
            // 
            this.pnlControls.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlControls.Controls.Add(this.btnModelSelect);
            this.pnlControls.Controls.Add(this.btnAnal);
            this.pnlControls.Controls.Add(this.btnSetParams);
            this.pnlControls.Controls.Add(this.dataGridViewResults);
            this.pnlControls.Controls.Add(this.progressBarMain);
            this.pnlControls.Controls.Add(this.btnParam);
            this.pnlControls.Controls.Add(this.txtK);
            this.pnlControls.Controls.Add(this.listBoxDistance);
            this.pnlControls.Controls.Add(this.btnRun);
            this.pnlControls.Controls.Add(this.listClusterers);
            this.pnlControls.Controls.Add(this.btnPointSettings);
            this.pnlControls.Controls.Add(this.lblV);
            this.pnlControls.Controls.Add(this.cboxV);
            this.pnlControls.Controls.Add(this.btnGeneratePoints);
            this.pnlControls.Controls.Add(this.txtBoxN);
            this.pnlControls.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlControls.Location = new System.Drawing.Point(828, 0);
            this.pnlControls.Name = "pnlControls";
            this.pnlControls.Size = new System.Drawing.Size(280, 686);
            this.pnlControls.TabIndex = 1;
            // 
            // btnAnal
            // 
            this.btnAnal.Location = new System.Drawing.Point(200, 344);
            this.btnAnal.Name = "btnAnal";
            this.btnAnal.Size = new System.Drawing.Size(45, 23);
            this.btnAnal.TabIndex = 13;
            this.btnAnal.Text = "分析";
            this.btnAnal.UseVisualStyleBackColor = true;
            this.btnAnal.Click += new System.EventHandler(this.btnAnal_Click);
            // 
            // btnSetParams
            // 
            this.btnSetParams.Location = new System.Drawing.Point(6, 72);
            this.btnSetParams.Name = "btnSetParams";
            this.btnSetParams.Size = new System.Drawing.Size(134, 31);
            this.btnSetParams.TabIndex = 12;
            this.btnSetParams.Text = "设置参数";
            this.btnSetParams.UseVisualStyleBackColor = true;
            this.btnSetParams.Click += new System.EventHandler(this.btnSetParams_Click);
            // 
            // dataGridViewResults
            // 
            this.dataGridViewResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colDistance,
            this.colNum,
            this.colClassIndx});
            this.dataGridViewResults.Location = new System.Drawing.Point(6, 406);
            this.dataGridViewResults.Name = "dataGridViewResults";
            this.dataGridViewResults.RowTemplate.Height = 27;
            this.dataGridViewResults.Size = new System.Drawing.Size(260, 275);
            this.dataGridViewResults.TabIndex = 11;
            this.dataGridViewResults.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewResults_RowHeaderMouseDoubleClick);
            // 
            // colDistance
            // 
            this.colDistance.HeaderText = "平均距离";
            this.colDistance.Name = "colDistance";
            this.colDistance.ReadOnly = true;
            // 
            // colNum
            // 
            this.colNum.HeaderText = "个数";
            this.colNum.Name = "colNum";
            this.colNum.ReadOnly = true;
            this.colNum.Width = 30;
            // 
            // colClassIndx
            // 
            this.colClassIndx.HeaderText = "类别";
            this.colClassIndx.Name = "colClassIndx";
            this.colClassIndx.ReadOnly = true;
            this.colClassIndx.Width = 50;
            // 
            // progressBarMain
            // 
            this.progressBarMain.Location = new System.Drawing.Point(6, 376);
            this.progressBarMain.Name = "progressBarMain";
            this.progressBarMain.Size = new System.Drawing.Size(260, 23);
            this.progressBarMain.TabIndex = 10;
            // 
            // btnParam
            // 
            this.btnParam.Location = new System.Drawing.Point(6, 35);
            this.btnParam.Name = "btnParam";
            this.btnParam.Size = new System.Drawing.Size(134, 31);
            this.btnParam.TabIndex = 9;
            this.btnParam.Text = "导入参数";
            this.btnParam.UseVisualStyleBackColor = true;
            this.btnParam.Click += new System.EventHandler(this.btnParam_Click);
            // 
            // txtK
            // 
            this.txtK.Location = new System.Drawing.Point(6, 344);
            this.txtK.Name = "txtK";
            this.txtK.Size = new System.Drawing.Size(134, 25);
            this.txtK.TabIndex = 8;
            this.txtK.Text = "2";
            this.txtK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // listBoxDistance
            // 
            this.listBoxDistance.FormattingEnabled = true;
            this.listBoxDistance.ItemHeight = 15;
            this.listBoxDistance.Items.AddRange(new object[] {
            "Euclidian",
            "Manhattan",
            "cos"});
            this.listBoxDistance.Location = new System.Drawing.Point(147, 138);
            this.listBoxDistance.Name = "listBoxDistance";
            this.listBoxDistance.Size = new System.Drawing.Size(120, 199);
            this.listBoxDistance.TabIndex = 7;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(146, 344);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(48, 25);
            this.btnRun.TabIndex = 6;
            this.btnRun.Text = "执行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // listClusterers
            // 
            this.listClusterers.FormattingEnabled = true;
            this.listClusterers.ItemHeight = 15;
            this.listClusterers.Items.AddRange(new object[] {
            "K-means",
            "CL",
            "FSCL",
            "RPCL",
            "EM",
            "EMCC",
            "EML2P",
            "EMDecay",
            "EML2PPruneAdd",
            "EMPDA"});
            this.listClusterers.Location = new System.Drawing.Point(4, 138);
            this.listClusterers.Name = "listClusterers";
            this.listClusterers.Size = new System.Drawing.Size(136, 199);
            this.listClusterers.TabIndex = 5;
            // 
            // btnPointSettings
            // 
            this.btnPointSettings.Location = new System.Drawing.Point(146, 54);
            this.btnPointSettings.Name = "btnPointSettings";
            this.btnPointSettings.Size = new System.Drawing.Size(120, 43);
            this.btnPointSettings.TabIndex = 4;
            this.btnPointSettings.Text = "导入配置";
            this.btnPointSettings.UseVisualStyleBackColor = true;
            this.btnPointSettings.Click += new System.EventHandler(this.btnPointSettings_Click);
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Location = new System.Drawing.Point(54, 106);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(37, 15);
            this.lblV.TabIndex = 3;
            this.lblV.Text = "周期";
            // 
            // cboxV
            // 
            this.cboxV.FormattingEnabled = true;
            this.cboxV.Items.AddRange(new object[] {
            "10",
            "100",
            "1000",
            "200",
            "2000",
            "50",
            "500"});
            this.cboxV.Location = new System.Drawing.Point(146, 103);
            this.cboxV.MaxLength = 4;
            this.cboxV.Name = "cboxV";
            this.cboxV.Size = new System.Drawing.Size(121, 23);
            this.cboxV.TabIndex = 2;
            this.cboxV.Text = "10";
            // 
            // btnGeneratePoints
            // 
            this.btnGeneratePoints.Location = new System.Drawing.Point(147, 4);
            this.btnGeneratePoints.Name = "btnGeneratePoints";
            this.btnGeneratePoints.Size = new System.Drawing.Size(120, 44);
            this.btnGeneratePoints.TabIndex = 1;
            this.btnGeneratePoints.Text = "生成点";
            this.btnGeneratePoints.UseVisualStyleBackColor = true;
            this.btnGeneratePoints.Click += new System.EventHandler(this.btnGeneratePoints_Click);
            // 
            // txtBoxN
            // 
            this.txtBoxN.Location = new System.Drawing.Point(4, 4);
            this.txtBoxN.Name = "txtBoxN";
            this.txtBoxN.Size = new System.Drawing.Size(136, 25);
            this.txtBoxN.TabIndex = 0;
            this.txtBoxN.Text = "20";
            this.txtBoxN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pnlDraw
            // 
            this.pnlDraw.BackColor = System.Drawing.Color.White;
            this.pnlDraw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDraw.Location = new System.Drawing.Point(0, 0);
            this.pnlDraw.Name = "pnlDraw";
            this.pnlDraw.Size = new System.Drawing.Size(828, 686);
            this.pnlDraw.TabIndex = 2;
            // 
            // timerMain
            // 
            this.timerMain.Interval = 50;
            this.timerMain.Tick += new System.EventHandler(this.timerMain_Tick);
            // 
            // openFileDialogParam
            // 
            this.openFileDialogParam.InitialDirectory = "./";
            // 
            // btnModelSelect
            // 
            this.btnModelSelect.Location = new System.Drawing.Point(251, 343);
            this.btnModelSelect.Name = "btnModelSelect";
            this.btnModelSelect.Size = new System.Drawing.Size(16, 23);
            this.btnModelSelect.TabIndex = 14;
            this.btnModelSelect.Text = "S";
            this.btnModelSelect.UseVisualStyleBackColor = true;
            this.btnModelSelect.Click += new System.EventHandler(this.btnModelSelect_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 686);
            this.Controls.Add(this.pnlDraw);
            this.Controls.Add(this.pnlControls);
            this.Name = "FrmMain";
            this.Text = "聚类";
            this.pnlControls.ResumeLayout(false);
            this.pnlControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel pnlControls;
        private System.Windows.Forms.TextBox txtBoxN;
        private System.Windows.Forms.Button btnGeneratePoints;
        private System.Windows.Forms.Panel pnlDraw;
        private System.Windows.Forms.ComboBox cboxV;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.ListBox listClusterers;
        private System.Windows.Forms.Button btnPointSettings;
        private System.Windows.Forms.OpenFileDialog openFileDialogConfig;
        private System.Windows.Forms.Timer timerMain;
        private System.Windows.Forms.ListBox listBoxDistance;
        private System.Windows.Forms.TextBox txtK;
        private System.Windows.Forms.Button btnParam;
        private System.Windows.Forms.OpenFileDialog openFileDialogParam;
        private System.Windows.Forms.ProgressBar progressBarMain;
        private System.Windows.Forms.DataGridView dataGridViewResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDistance;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNum;
        private System.Windows.Forms.DataGridViewTextBoxColumn colClassIndx;
        private System.Windows.Forms.Button btnSetParams;
        private System.Windows.Forms.Button btnAnal;
        private System.Windows.Forms.Button btnModelSelect;
    }
}

