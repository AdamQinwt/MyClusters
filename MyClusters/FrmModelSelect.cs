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
using MyClusters.Clusterers.ModelSelector;
using MyClusters.PointConfig;
using MyClusters.Clusterers;
using System.IO;
namespace MyClusters
{
    public partial class FrmModelSelect : Form
    {
        Graphics g;

        int nPoints;
        MyPoint[] points;
        string type;
        double stepX, stepY;
        double startX, startY;
        double endX, endY;
        double minJ, maxJ;
        double[] Js;
        double[] ks;
        int numK, numPerk;
        PointF[] drawPoints;
        Brush Avg = new SolidBrush(Color.Black);
        Font font = new Font("Arial", 12);
        Pen pAvg, pMax, pMin;
        const float RECT_SIZE = 4, RECT_HALF_SIZE = RECT_SIZE / 2;

        private void btnRun_Click(object sender, EventArgs e)
        {
            if (txtBestK.Text != "")
            {
                try
                {
                    numK = int.Parse(txtBestK.Text);
                }
                catch
                {
                    //
                }
            }
            Init();
            Run();
            DrawAll();
        }

        const float LINE_WIDTH = 2;
        const int MARGIN = 10, OFFSET = 10;
        DistanceBase dist;
        Dictionary<string, double> extraArgs;
        ModelSelectorBase selectorBase;
        public FrmModelSelect(Dictionary<string, double> _extraArgs, MyPoint[] _points, string _type, DistanceBase _dist,int _numK=20,int _numPerK=5)
        {
            InitializeComponent();
            numK = _numK;
            numPerk = _numPerK;
            points = _points;
            extraArgs = _extraArgs;
            type = _type;
            dist = _dist;
            pAvg = new Pen(Avg, LINE_WIDTH);
            g = pnlDraw.CreateGraphics();
        }
        public void Init()
        {
            selectorBase = ModelSelectorBase.GetModelSelector(cbSelection.SelectedItem.ToString(), extraArgs, points, numK, numPerk);
            startX = MARGIN; endX = pnlDraw.Width - MARGIN;
            startY = MARGIN; endY = pnlDraw.Height - MARGIN;
            stepX = (endX - startX) / numK;
            drawPoints = new PointF[numK];
            dataGridView1.Rows.Clear();
        }
        public void Run()
        {
            selectorBase.Run();
            Js = selectorBase.Js;
            txtBestK.Text = selectorBase.bestK.ToString();
            CleanUp();
        }
        public void CleanUp()
        {
            int i;
            minJ = Js[0];
            maxJ = Js[0];
            for(i=0;i<numK;i++)
            {
                RecordResultToTable(i);
                if(Js[i]<minJ)
                {
                    minJ = Js[i];
                }
                if (Js[i] > maxJ)
                {
                    maxJ = Js[i];
                }
            }
            stepY = (endY - startY) / (maxJ - minJ);
            for (i = 0; i < numK; i++)
            {
                PointsToDrawPoints(i);
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
        private void PointsToDrawPoints(int indx)
        {
            drawPoints[indx] = new PointF((float)(startX + stepX * indx), (float)(endY - stepY * (Js[indx] - minJ)));
        }
        private void RecordResultToTable(int indx)
        {
            int i = dataGridView1.Rows.Add();
            dataGridView1.Rows[i].Cells[0].Value = (1 + indx).ToString();
            dataGridView1.Rows[i].Cells[1].Value = Js[indx].ToString();
            Application.DoEvents();
        }
        private void DrawAll()
        {
            g.Clear(Color.White);
            int i;
            for (i = 0; i < numK; i++)
            {
                g.FillRectangle(Avg, new RectangleF(drawPoints[i].X - RECT_HALF_SIZE, drawPoints[i].Y - RECT_HALF_SIZE, RECT_SIZE, RECT_SIZE));
                g.DrawString((1 + i).ToString(), font, Avg, drawPoints[i]);
            }
            g.DrawLines(pAvg, drawPoints);
        }
    }
}
