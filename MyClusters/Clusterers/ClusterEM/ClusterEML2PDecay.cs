using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Clusterers;
using MyClusters.Clusterers.EMCenter;
using System.Drawing;
using MyClusters.Distances;
namespace MyClusters.Clusterers.ClusterEM
{
    class ClusterEML2PDecay : ClusterEMBase
    {
        protected double expel, decay;
        public ClusterEML2PDecay(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k,extras)
        {
            try { expel = extras["expel"]; } catch { expel = 0.01; }
            try { decay = extras["decay"]; } catch { decay = 0.9; }

        }
        public override EMCenterBase getEMCenter(int n, int k, MyPoint p = null)
        {
            return new EMCenterL2P(n, k, p);
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
                center.M_p1();
            }
            foreach (int center in centers.Keys)
            {
                foreach (int center2 in centers.Keys)
                {
                    if(center!=center2)
                        centers[center].Expel(centers[center2], expel);
                }
                centers[center].Decay(decay);
                centers[center].M_p2();
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
