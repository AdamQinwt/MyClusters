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
    partial class FrmAnalyze : Form
    {
        Graphics g;

        int nPoints;
        MyPoint[] points;
        string type;
        double stepX, stepY;
        double startX, startY;
        double endX, endY;
        double minDist, maxDist;
        double[] lossesAvg,lossesMin,lossesMax;
        double[] ks;

        int from, to,num,cntRuns;
        PointF[] drawPointsAvg, drawPointsMin, drawPointsMax;

        Brush Avg = new SolidBrush(Color.Black);
        Brush Min = new SolidBrush(Color.Blue);
        Brush Max = new SolidBrush(Color.Red);
        Font font = new Font("Arial", 12);
        Pen pAvg,pMax,pMin;
        const float RECT_SIZE = 4, RECT_HALF_SIZE = RECT_SIZE / 2;

        private void FrmAnalyze_Load(object sender, EventArgs e)
        {

        }

        const float LINE_WIDTH = 2;
        const int MARGIN=10,OFFSET=10;

        private void dgvResults_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (c == null) return;
            if (e.RowIndex < num)
            {
                c[e.RowIndex].DrawCluster(g, pnlDraw.Width / MyPoint.GLOBAL_INTERVAL, -pnlDraw.Height / MyPoint.GLOBAL_INTERVAL,0,endY,5,15,true);
            }
            else if (e.RowIndex == num)
            {
                DrawAll();
            }
        }

        private void btnParams_Click(object sender, EventArgs e)
        {
            FrmParams frmParams = new FrmParams(extraArgs);
            if (frmParams.ShowDialog() == DialogResult.OK)
            {
                extraArgs = frmParams.extras;
            }
            frmParams.Dispose();
        }

        DistanceBase dist;
        ClusterBase[] c;
        
        Dictionary<string, double> extraArgs;
        public FrmAnalyze(Dictionary<string, double> _extraArgs,MyPoint[] _points, string _type,DistanceBase _dist)
        {
            InitializeComponent();
            points = _points;
            extraArgs = _extraArgs;
            type = _type;
            dist = _dist;
            pAvg = new Pen(Avg,LINE_WIDTH);
            pMin = new Pen(Min, LINE_WIDTH);
            pMax = new Pen(Max, LINE_WIDTH);
            g = pnlDraw.CreateGraphics();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!Init()) return;
            Run();
        }
        private bool Init()
        {
            try
            {
                from = int.Parse(txtFrom.Text);
                to = int.Parse(txtTo.Text);
                cntRuns = int.Parse(txtTime.Text);
            }
            catch
            {
                MessageBox.Show("输入无效！");
                return false;
            }
            g = pnlDraw.CreateGraphics();
            num = to - from + 1;
            drawPointsAvg = new PointF[num];
            drawPointsMax = new PointF[num];
            drawPointsMin = new PointF[num];
            lossesAvg = new double[num];
            lossesMin = new double[num];
            lossesMax = new double[num];
            ks = new double[num];
            startX = MARGIN; endX = pnlDraw.Width - MARGIN;
            startY = MARGIN; endY = pnlDraw.Height - MARGIN;
            stepX = (endX - startX) / num;
            c = new ClusterBase[num];
            dgvResults.Rows.Clear();
            return true;
        }
        private void Run()
        {
            int i,j;
            double tmp,sum,min,max,sumK;
            minDist = 100000;
            maxDist = 0;
            for(i=0;i<num;i++)
            {
                sum = 0;
                sumK = 0;
                min = 100000;
                max = -1;
                for (j = 0; j < cntRuns; j++)
                {
                    c[i] = ClusterBase.Cluster(type, dist, RandUtils.Shuffle(points), i + from, extraArgs);
                    c[i].ListColors();
                    c[i].Start();
                    while (!c[i].finished)
                    {
                        c[i].Step();
                    }
                    c[i].GetMeanClassDistanceLoss();
                    tmp = c[i].loss;
                    sum += tmp;
                    sumK += c[i].k;
                    if (tmp < min)
                    {
                        min = tmp;
                        if(tmp<minDist)
                        {
                            minDist = tmp;
                        }
                    }
                    if(tmp>max)
                    {
                        max = tmp;
                        if (tmp > maxDist)
                        {
                            maxDist = tmp;
                        }
                    }
                }
                lossesAvg[i] = sum / cntRuns;
                ks[i] = sumK / cntRuns;
                lossesMin[i] = min;
                lossesMax[i] = max;
                RecordResultToTable(i);
            }
            stepY = (endY - startY)/(maxDist - minDist);
            for(i=0;i<num;i++)
            {
                PointsToDrawPoints(i);
            }
            DrawAll();
        }
        private void RecordResultToTable(int indx)
        {
            int i = dgvResults.Rows.Add();
            dgvResults.Rows[i].Cells[0].Value = (from+indx).ToString();
            dgvResults.Rows[i].Cells[1].Value = ks[indx].ToString();
            dgvResults.Rows[i].Cells[2].Value = lossesAvg[indx].ToString();
            Application.DoEvents();
        }
        private void PointsToDrawPoints(int indx)
        {
            drawPointsAvg[indx] = new PointF((float)(startX+stepX*indx), (float)(endY - stepY * (lossesAvg[indx]-minDist)));
            drawPointsMax[indx] = new PointF((float)(startX+stepX*indx), (float)(endY - stepY * (lossesMax[indx]-minDist)));
            drawPointsMin[indx] = new PointF((float)(startX+stepX*indx), (float)(endY - stepY * (lossesMin[indx]-minDist)));
        }
        private void DrawAll()
        {
            g.Clear(Color.White);
            int i;
            for (i = 0; i < num; i++)
            {
                g.FillRectangle(Avg, new RectangleF(drawPointsAvg[i].X- RECT_HALF_SIZE, drawPointsAvg[i].Y- RECT_HALF_SIZE, RECT_SIZE, RECT_SIZE));
                g.DrawString((from + i).ToString(), font, Avg, drawPointsAvg[i]);
                g.FillRectangle(Max, new RectangleF(drawPointsMax[i].X- RECT_HALF_SIZE, drawPointsMax[i].Y- RECT_HALF_SIZE, RECT_SIZE, RECT_SIZE));
                g.FillRectangle(Min, new RectangleF(drawPointsMin[i].X- RECT_HALF_SIZE, drawPointsMin[i].Y- RECT_HALF_SIZE, RECT_SIZE, RECT_SIZE));
            }
           g.DrawLines(pAvg, drawPointsAvg);
           g.DrawLines(pMax, drawPointsMax);
           g.DrawLines(pMin, drawPointsMin);
        }
    }
}
