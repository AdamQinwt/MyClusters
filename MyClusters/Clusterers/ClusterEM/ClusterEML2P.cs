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
    class ClusterEML2P : ClusterEMBase
    {
        public ClusterEML2P(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k,extras)
        {
        }
        public override EMCenterBase getEMCenter(int n, int k, MyPoint p = null)
        {
            return new EMCenterL2P(n, k, p);
        }
    }
}
