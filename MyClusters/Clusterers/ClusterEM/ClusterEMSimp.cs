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
    class ClusterEMSimp:ClusterEMBase
    {
        public ClusterEMSimp(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k,extras)
        {
        }
    }
}
