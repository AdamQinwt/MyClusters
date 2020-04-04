using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
using System.Drawing;
using MyClusters.Clusterers.EMCenter;
namespace MyClusters.Clusterers.ClusterEM
{
    abstract class ClusterEMBase:ClusterBase
    {
        protected double[] snny;   //sum without normalization
        public Dictionary<int, EMCenterBase> centers;
        public Dictionary<int, int> arr2dic, dic2arr;
        protected int L, numIter, currentIter;
        public ClusterEMBase(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k)
        {
            on_draw_event += DrawResultsMixed;
            on_draw_class_event -= DrawClass1;
            on_draw_class_event += DrawClass2;
            L = MyPoint.LENGTH;
            try { numIter = (int)extras["max_iter"]; } catch { numIter = 20; }
        }
        public double GetTotalP(MyPoint p)
        {
            double sum = 0;
            foreach(EMCenterBase c in centers.Values)
            {
                sum += c.GetRawProb(p);
            }
            return Math.Log(sum);
        }
        public double GetTotalPAll()
        {
            double sum = 0;
            foreach (MyPoint pp in points)
            {
                sum += GetTotalP(pp);
            }
            return sum;
        }
        public virtual EMCenterBase getEMCenter(int n,int k,MyPoint p=null)
        {
            return new EMCenterBasic(n, k, p);
        }
        public override void Start()
        {
            finished = false;
            centers = new Dictionary<int, EMCenterBase>(n);
            currentIndx = points.Length;
            currentIter = 0;
            snny = new double[n];
            int cls;
            for (cls = 0; cls < k; cls++)
            {
                //centers[cls] = new EMCenterBasic(n, k);
                centers[cls] = getEMCenter(n,k);
            }
        }
        public override void Step()
        {
            int i;
            for (i = 0; i < n; i++)
            {
                _getClassWithGMM(i);
            }
            foreach (EMCenterBase center in centers.Values)
            {
                center.M();
            }
            currentIter++;
            Progress = ((double)currentIter) / numIter;
            if (currentIter == numIter)
            {
                CleanUp();
                finished = true;
            }
        }
        protected virtual void _getClassWithGMM(int i)
        {
            MyPoint p = points[i];
            snny[i] = 0;
            foreach (EMCenterBase center in centers.Values)
            {
                snny[i] += center.E1(p, i);
            }
            foreach (EMCenterBase center in centers.Values)
            {
                center.E2(i, snny[i]);
                center.count += center.y[i];
                center.updateCent(p, i);
                center.updateCov(p, i);
            }
        }
        public void DrawResultsMixed(Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15,bool forceRemap=false)
        {
            int i;
            g.Clear(Color.White);
            double R = 0, G = 0, B = 0;
            for (i = 0; i < currentIndx; i++)
            {
                R = 0; B = 0; G = 0;
                foreach (EMCenterBase cls in centers.Values)
                {
                    R += cls.y[i] * cls.color.R;
                    G += cls.y[i] * cls.color.G;
                    B += cls.y[i] * cls.color.B;
                }
                points[i].DrawCircle(g, stepX, stepY, new SolidBrush(Color.FromArgb((int)R, (int)G, (int)B)), startX, startY, rNormal,forceRemap);
            }
            foreach (EMCenterBase cls in centers.Values)
            {
                cls.cent.DrawCircle(g, stepX, stepY, cls.brush, startX, startY, rCentroid, forceRemap);
            }
        }
        public void DrawClass2(int cc, Graphics g, double stepX, double stepY, double startX, double startY, int rNormal = 5, int rCentroid = 15)
        {
            int i;
            g.Clear(Color.White);
            for (i = 0; i < currentIndx; i++)
            {
                if (cIndx[i] != cc) continue;
                points[i].DrawCircle(g, stepX, stepY, centers[arr2dic[cc]].brush, startX, startY, rNormal);
            }
            centers[arr2dic[cc]].cent.DrawCircle(g, stepX, stepY, centers[arr2dic[cc]].brush, startX, startY, rCentroid);
        }
        public void CleanUp()
        {
            int i;
            bool ttt;
            Dictionary<int, bool> need = new Dictionary<int, bool>(centers.Count);
            for (i = 0; i < n; i++)
            {
                cIndx[i] = EMCenterBase.getCls(i, centers);
                need[cIndx[i]] = true;
            }
            centroids = new MyPoint[centers.Count];
            i = 0;
            dic2arr = new Dictionary<int, int>(centers.Count);
            arr2dic = new Dictionary<int, int>(centers.Count);
            foreach (int center in centers.Keys)
            {
                try { ttt = need[center]; } catch { k--; continue; }
                centroids[i] = centers[center].cent;
                dic2arr[center] = i;
                arr2dic[i] = center;
                i++;
            }
            for (i = 0; i < n; i++)
            {
                cIndx[i] = dic2arr[cIndx[i]];
            }
        }
    }
}
