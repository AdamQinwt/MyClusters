using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
namespace MyClusters.Clusterers
{
    class ClusterRPCL : ClusterBase
    {
        double active, push;
        public ClusterRPCL(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras) : base(_d, _points, _k)
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
            try
            {
                push = extras["push"];
            }
            catch (Exception)
            {
                push = 0.001;
            }
        }
        public override void Start()
        {
            finished = false;
            centroids = MyPoint.RandomPoints(k);
            currentIndx = 0;
        }
        public override void Step()
        {
            MyPoint current = points[currentIndx];
            int[] tmp = d.Get2ClosestIndx(current, centroids);
            cIndx[currentIndx] = tmp[0];
            int i, j; j = tmp[0];
            for (i = 0; i < MyPoint.LENGTH; i++)
            {
                centroids[j].x[i] += active * (current.x[i] - centroids[j].x[i]);
                centroids[j].changed = true;
            }
            j = tmp[1];
            for (i = 0; i < MyPoint.LENGTH; i++)
            {
                centroids[j].x[i] -= push * (current.x[i] - centroids[j].x[i]);
                centroids[j].changed = true;
            }

            currentIndx++;
            Progress = ((double)currentIndx) / n;
            if (currentIndx == n)
            {
                finished = true;
            }
        }
    }
}
