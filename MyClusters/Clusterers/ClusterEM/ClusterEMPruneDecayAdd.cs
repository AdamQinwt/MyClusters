using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Clusterers.EMCenter;
using MyClusters.Distances;
namespace MyClusters.Clusterers.ClusterEM
{
    class ClusterEMPruneDecayAdd : ClusterEMPruneAdd
    {
        double lower;
        public ClusterEMPruneDecayAdd(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k, extras)
        {
            try { lower = extras["lower_d"]; } catch { lower = 0.1; }
        }
        public override EMCenterBase getEMCenter(int n, int k, MyPoint p = null)
        {
            return new EMCenterDecay(n, k, decay, lower,p);
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
                centers[center].M_p2();
            }
            if (pruneCounter == pruneInterval || currentIter == numIter - 1)
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
    }
}
