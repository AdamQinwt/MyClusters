using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyClusters.Distances;
using MyClusters.PointConfig;
using MyClusters.Clusterers;
using System.IO;
namespace MyClusters
{
    public partial class FrmMain : Form
    {
        BufferedGraphics myBuffer;
        Graphics g1, g;

        int nPoints;
        MyPoint[] points;
        MyPoint[] centroids;

        double stepX, stepY;
        double startX, startY;

        PointConfigBase Pcfg;

        DistanceBase dist;
        ClusterBase c;

        Dictionary<string, double> extraArgs=null;

        private void btnRun_Click(object sender, EventArgs e)
        {
            //if (points == null) btnGeneratePoints.Click();
            if (c != null && !c.finished) return;
            try
            {
                dist = DistanceBase.Distance(listBoxDistance.SelectedItem.ToString());
            }
            catch(Exception)
            {
                MessageBox.Show("请选择距离");
                return;
            }
            try
            {
                c = ClusterBase.Cluster(listClusterers.SelectedItem.ToString(), dist, RandUtils.Shuffle(points), int.Parse(txtK.Text),extraArgs);
                //c.RandomColors();
                c.ListColors();
            }
            catch (Exception exx)
            {
                MessageBox.Show("请选择聚类器和参数\n"+exx.ToString());
                return;
            }
            c.Start();
            //MessageBox.Show(cboxV.SelectedIndex.ToString());
            try
            { timerMain.Interval = int.Parse(cboxV.Text); }
            catch
            {
                timerMain.Interval = int.Parse(cboxV.SelectedItem.ToString());
            }
            timerMain.Enabled = true;
        }

        private void timerMain_Tick(object sender, EventArgs e)
        {
            c.Step();
            progressBarMain.Value = (int)(c.Progress * 100);
            BufferedGraphicsContext currentContext = BufferedGraphicsManager.Current;
            myBuffer = currentContext.Allocate(g1, DisplayRectangle);
            g = myBuffer.Graphics;

            c.DrawCluster(g, stepX, stepY, startX, startY);

            myBuffer.Render();
            myBuffer.Dispose();

            txtK.Text = c.k.ToString();

            if (c.finished)
            {
                timerMain.Enabled = false;
                c.GetMeanClassDistanceLoss();
                showDistances();
            }
        }

        private void btnPointSettings_Click(object sender, EventArgs e)
        {
            if (openFileDialogConfig.ShowDialog() == DialogResult.OK) Pcfg = new PointConfigFromFile(openFileDialogConfig.FileName);
        }

        private void btnParam_Click(object sender, EventArgs e)
        {
            if (openFileDialogParam.ShowDialog() == DialogResult.OK)
            {
                extraArgs = new Dictionary<string, double>(3);
                StreamReader r = new StreamReader(openFileDialogParam.FileName);
                string[] lines=r.ReadToEnd().Split('\n');
                int i;
                for(i=0;i<lines.Length;i++)
                {
                    string[] tmps = lines[i].Split('=');
                    extraArgs[tmps[0]] = double.Parse(tmps[1]);
                }
                r.Close();
            }
        }

        private void btnSetParams_Click(object sender, EventArgs e)
        {
            FrmParams frmParams = new FrmParams(extraArgs);
            if(frmParams.ShowDialog()==DialogResult.OK)
            {
                extraArgs = frmParams.extras;
            }
            frmParams.Dispose();
        }

        private void dataGridViewResults_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (c == null) return;
            if (e.RowIndex < c.k)
            {
                c.DrawClass(e.RowIndex, g1, stepX, stepY, startX, startY);
            }
            else if(e.RowIndex == c.k)
            {
                c.DrawCluster(g1, stepX, stepY, startX, startY);
            }
        }

        private void btnAnal_Click(object sender, EventArgs e)
        {
            try
            {
                dist = DistanceBase.Distance(listBoxDistance.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("请选择距离");
                return;
            }
            FrmAnalyze frmAnalyze = new FrmAnalyze(extraArgs, points, listClusterers.SelectedItem.ToString(), dist);
            frmAnalyze.ShowDialog();
            frmAnalyze.Dispose();
        }

        private void btnModelSelect_Click(object sender, EventArgs e)
        {
            try
            {
                dist = DistanceBase.Distance(listBoxDistance.SelectedItem.ToString());
            }
            catch (Exception)
            {
                MessageBox.Show("请选择距离");
                return;
            }
            FrmModelSelect frmAnalyze = new FrmModelSelect(extraArgs, points, listClusterers.SelectedItem.ToString(), dist);
            frmAnalyze.ShowDialog();
            frmAnalyze.Dispose();
        }

        public FrmMain()
        {
            InitializeComponent();
            g1 = pnlDraw.CreateGraphics();
        }

        private void btnGeneratePoints_Click(object sender, EventArgs e)
        {
            try
            {
                nPoints = int.Parse(txtBoxN.Text);
            }
            catch(Exception)
            {
                MessageBox.Show("请输入正确的输入点个数");
                return;
            }
            g1.Clear(Color.White);
            g1 = pnlDraw.CreateGraphics();
            startX = 0; startY = pnlDraw.Height;
            stepX = pnlDraw.Width / MyPoint.GLOBAL_INTERVAL;
            stepY = -pnlDraw.Height / MyPoint.GLOBAL_INTERVAL;
            //MessageBox.Show(startX.ToString() + "," + startY.ToString() + "\n" + stepX.ToString() + "," + stepY.ToString());
            points = (Pcfg??new PointConfigHand()).MakePoints();
            txtBoxN.Text = points.Length.ToString();
            MyPoint.DrawPoints(points, g1, stepX, stepY, null, startX, startY,5);
        }
        private void showDistances()
        {
            dataGridViewResults.Rows.Clear();
            DataGridViewColumn col = new DataGridViewColumn();
            int i;
            int indx;
            for (i=0;i<c.k;i++)
            {
                indx = dataGridViewResults.Rows.Add();
                dataGridViewResults.Rows[indx].Cells[0].Value = c.losses[i].ToString();
                dataGridViewResults.Rows[indx].Cells[1].Value = c.countC[i].ToString();
                dataGridViewResults.Rows[indx].Cells[2].Value = i.ToString();
            }
            indx = dataGridViewResults.Rows.Add();
            dataGridViewResults.Rows[indx].Cells[0].Value = c.loss.ToString();
            dataGridViewResults.Rows[indx].Cells[1].Value = c.n.ToString();
            dataGridViewResults.Rows[indx].Cells[2].Value = "共"+c.k.ToString()+"类";
        }
    }
}
