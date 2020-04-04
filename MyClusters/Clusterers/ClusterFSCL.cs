using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
namespace MyClusters.Clusterers
{
    class ClusterFSCL : ClusterBase
    {
        double active;
        double[] freqs;
        int[] ns;
        public ClusterFSCL(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string,double> extras) : base(_d, _points, _k)
        {
            on_draw_event += DrawResults;
            try
            {
                active = extras["active"];
            }
            catch (Exception)
            {
                active = 0.1;
            }
        }
        public override void Start()
        {
            finished = false;
            centroids = MyPoint.RandomPoints(k);
            currentIndx = 0;
            freqs = new double[k];
            ns = new int[k];
        }
        public override void Step()
        {
            MyPoint current = points[currentIndx];
            int tmp = d.GetBiasdClosestIndx(current, centroids,freqs);
            cIndx[currentIndx] = tmp;
            ns[tmp]++;
            int i;
            for (i = 0; i < MyPoint.LENGTH; i++)
            {
                centroids[tmp].x[i] += active * (current.x[i] - centroids[tmp].x[i]);
                centroids[tmp].changed = true;
            }
            currentIndx++;
            for (i=0;i<k;i++)
            {
                freqs[i] = ((double)ns[i]) / currentIndx;
            }
            Progress = ((double)currentIndx) / n;
            if (currentIndx == n)
            {
                finished = true;
            }
        }
    }
}
