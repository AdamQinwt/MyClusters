using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
using System.Drawing;
using MyClusters.Clusterers.ClusterEM;
namespace MyClusters.Clusterers
{
    abstract class ClusterBase
    {
        public double loss;
        public double[] losses;
        public double[] countC;
        public const int C = MyPoint.LENGTH;
        public bool finished;
        protected DistanceBase d;
        protected MyPoint[] points;
        public int k, n;
        public MyPoint[] centroids;
        public int[] cIndx;
        protected Brush[] normalB;
        protected Brush[] centB;
        protected Color[] clusterColors;
        protected int currentIndx;
        public double Progress;
        public delegate void onDraw_event(Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15,bool forceRemap=false);
        public delegate void onDrawClass_event(int cc,Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15);
        public event onDraw_event on_draw_event;
        public event onDrawClass_event on_draw_class_event;
        static Color[] cColors = new Color[]
        {
            Color.Red,
            Color.Blue,
            Color.Green,
            Color.Purple,
            Color.Yellow,
            Color.YellowGreen,
            Color.SkyBlue,
            Color.SeaGreen,
            Color.Orange
        };
        public void SetColors(Color[] colorsNormal, Color[] colorsCentroid)
        {
            clusterColors = new Color[k];
            normalB = new SolidBrush[k];
            centB = new SolidBrush[k];
            int i;
            for (i = 0; i < k; i++)
            {
                clusterColors[i] = colorsCentroid[i];
                normalB[i] = new SolidBrush(colorsNormal[i]);
                centB[i] = new SolidBrush(colorsCentroid[i]);
            }
        }
        public void RandomColors()
        {
            clusterColors = new Color[k];
            normalB = new SolidBrush[k];
            centB = new SolidBrush[k];
            int i;
            for (i = 0; i < k; i++)
            {
                clusterColors[i] = RandUtils.RandomColor();
                normalB[i] = new SolidBrush(clusterColors[i]);
                //centB[i] = new SolidBrush(RandUtils.RandomColor());
                centB[i] = normalB[i];
            }
        }
        public void ListColors()
        {
            clusterColors = new Color[k];
            normalB = new SolidBrush[k];
            centB = new SolidBrush[k];
            int i;
            for (i = 0; i < k&&i<cColors.Length; i++)
            {
                clusterColors[i] = cColors[i];
                normalB[i] = new SolidBrush(clusterColors[i]);
                //centB[i] = new SolidBrush(RandUtils.RandomColor());
                centB[i] = normalB[i];
            }
            for (i = cColors.Length; i < k; i++)
            {
                clusterColors[i] = RandUtils.RandomColor();
                normalB[i] = new SolidBrush(clusterColors[i]);
                centB[i] = normalB[i];
            }
        }
        protected ClusterBase(DistanceBase _d,MyPoint[] _points,int _k)
        {
            d = _d;
            points = new MyPoint[_points.Length];
            int i;
            for(i=0;i<points.Length;i++)
            {
                points[i] = new MyPoint(_points[i]);
            }
            points = _points;
            k = _k;
            n = points.Length;
            //centroids = new MyPoint[k];
            cIndx = new int[n];
            Progress = 0;
            on_draw_class_event += DrawClass1;
        }
        public static ClusterBase Cluster(string name, DistanceBase _d, MyPoint[] _points, int _k=0,Dictionary<string,double> extras=null)
        {
            switch(name)
            {
                case "K-means": return new ClusterKMeans(_d, _points, _k);
                case "CL": return new ClusterCL(_d, _points, _k, extras);
                case "FSCL": return new ClusterFSCL(_d, _points, _k, extras);
                case "RPCL": return new ClusterRPCL(_d, _points, _k, extras);
                case "EM": return new ClusterEMSimp(_d, _points, _k, extras);
                case "EML2P": return new ClusterEML2P(_d, _points, _k, extras);
                case "EMDecay": return new ClusterEML2PDecay(_d, _points, _k, extras);
                case "EML2PPruneAdd": return new ClusterEMPruneAdd(_d, _points, _k, extras);
                case "EMPDA": return new ClusterEMPruneDecayAdd(_d, _points, _k, extras);
                case "EMCC": return new ClusterEMConstCov(_d, _points, _k, extras);
                default:
                    return null;
            }
        }
        public abstract void Start();
        public abstract void Step();
        public void DrawResults(Graphics g,double stepX,double stepY,double startX,double startY,int rNormal=5,int rCentroid=15,bool forceRemap=false)
        {
            int i;
            g.Clear(Color.White);
            for(i=0;i<currentIndx;i++)
            {
                points[i].DrawCircle(g, stepX, stepY, normalB[cIndx[i]], startX, startY, rNormal,forceRemap);
            }
            for (i = 0; i < k; i++)
            {
                centroids[i].DrawCircle(g, stepX, stepY, centB[i], startX, startY, rCentroid, forceRemap);
            }
        }
        public void DrawCluster(Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15,bool forceRemap=false)
        {
            on_draw_event(g, stepX, stepY, startX, startY, rNormal, rCentroid, forceRemap);
        }
        public void DrawClass(int cc,Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15)
        {
            on_draw_class_event(cc,g, stepX, stepY, startX, startY, rNormal, rCentroid);
        }
        public void DrawClass1(int cc, Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15)
        {
            int i;
            g.Clear(Color.White);
            for (i = 0; i < currentIndx; i++)
            {
                if (cIndx[i] != cc) continue;
                points[i].DrawCircle(g, stepX, stepY, normalB[cIndx[i]], startX, startY, rNormal);
            }
            centroids[cc].ToDrawPoint(stepX, stepY, startX, startY);
            centroids[cc].DrawCircle(g, stepX, stepY, centB[cc], startX, startY, rCentroid);
        }
        public void GetMeanClassDistanceLoss()
        {
            loss = 0;
            losses = new double[k];
            int cls, i;
            double tmp;
            countC = new double[k];
            for(i=0;i<n;i++)
            {
                countC[cIndx[i]]++;
                tmp = d.D(points[i], centroids[cIndx[i]]);
                losses[cIndx[i]] += tmp;
                loss += tmp;
            }
            for(cls=0;cls<k;cls++)
            {
                losses[cls] /= countC[cls];
            }
            loss /= n;
        }
    }
}
