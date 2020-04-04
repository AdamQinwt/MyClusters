using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using MyClusters.Clusterers.EMCenter;
using MyClusters.Distances;
namespace MyClusters.Clusterers.ClusterEM
{
    class ClusterEMPruneAdd : ClusterEMBase
    {
        protected double thresh,addThresh;
        protected int pruneInterval, pruneCounter;
        protected int addInterval, addCounter;
        protected double expel, decay;
        protected bool added;
        public ClusterEMPruneAdd(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k, extras)
        {
            try { pruneInterval = (int)extras["prune_interval"]; } catch { pruneInterval = 5; }
            try { addInterval = (int)extras["add_interval"]; } catch { addInterval = 3; }
            try { thresh = (int)extras["thresh"]; } catch { thresh = 1; }
            try { addThresh = (int)extras["add_thresh"]; } catch { addThresh = 3; }
            try { expel = extras["expel"]; } catch { expel = 1; }
            try { decay = extras["decay"]; } catch { decay = 0.9; }
        }
        public override void Start()
        {
            base.Start();
            pruneCounter = 0;
            addCounter = 0;
        }
        public override EMCenterBase getEMCenter(int n, int k, MyPoint p = null)
        {
            return new EMCenterL2P(n, k, p);
            //return new EMCenterBasic(n, k, p);
        }
        public override void Step()
        {
            int i;
            added = false;
            bool allow_add = addCounter == addInterval;
            for (i = 0; i < n; i++)
            {
                _getClassWithGMM(i, allow_add);
                if (added)
                {
                    i = 0; added = false; allow_add = false;
                    foreach (EMCenterBase center in centers.Values)
                    {
                        center.ResetNew();
                    }
                }
            }
            pruneCounter++;
            if (addCounter == addInterval)
            {
                addCounter = 0;
            }
            addCounter++;
            
            List<int> removes = new List<int>(k);
            if (currentIter == numIter - 1) thresh = 0;
            foreach (int center in centers.Keys)
            {
                if (centers[center].count <= thresh)
                {
                    removes.Add(center);
                    continue;
                }
                centers[center].M_p1();
            }
            foreach (int center in centers.Keys)
            {
                foreach (int center2 in centers.Keys)
                {
                    if (center != center2)
                        centers[center].Expel(centers[center2], expel);
                }
                centers[center].Decay(decay);
                centers[center].M_p2();
            }
            if (pruneCounter == pruneInterval|| currentIter == numIter - 1)
            {
                foreach (int c in removes)
                {
                    k--;
                    centers.Remove(c);
                }
                pruneCounter = 0;
            }
            currentIter++;
            Progress = ((double)currentIter) / numIter;
            if (currentIter == numIter)
            {
                CleanUp();
                finished = true;
            }
        }
        protected virtual void _getClassWithGMM(int i,bool canadd)
        {
            MyPoint p = points[i];
            snny[i] = 0;
            double tmp,max1=0;
            int maxI=0;
            foreach (int center in centers.Keys)
            {
                tmp = centers[center].E1(p, i);
                snny[i] += tmp;
                if(tmp>max1)
                {
                    max1 = tmp;
                    maxI = center;
                }
            }
            if(canadd&&centers[maxI].nny[i]<addThresh)
            {
                int newIndx;
                for(newIndx=1000;newIndx<10000;newIndx++)
                {
                    try
                    {
                        tmp = centers[newIndx].count;
                    }
                    catch
                    {
                        centers[newIndx] = getEMCenter(n, 1, p);
                        k++;
                        added = true;
                        return;
                    }
                }
            }
            foreach (int center in centers.Keys)
            {
                centers[center].E2(i, snny[i]);
                centers[center].count += centers[center].y[i];
                centers[center].updateCent(p, i);
                centers[center].updateCov(p, i);
            }
        }
    }
}
