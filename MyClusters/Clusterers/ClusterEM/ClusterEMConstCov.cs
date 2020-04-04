using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
using MyClusters.Clusterers.EMCenter;
namespace MyClusters.Clusterers.ClusterEM
{
    class ClusterEMConstCov:ClusterEMSimp
    {
        public ClusterEMConstCov(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k, extras)
        {
        }
        public override EMCenterBase getEMCenter(int n, int k, MyPoint p = null)
        {
            return new EMCenterConstCov(n, k, p);
        }
    }
}
