using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
using System.Drawing;
namespace MyClusters.Clusterers
{
    /// <summary>
    /// Competitive learning
    /// </summary>
    class ClusterCL:ClusterBase
    {
        double active;
        public ClusterCL(DistanceBase _d, MyPoint[] _points, int _k, Dictionary<string, double> extras = null) : base(_d, _points, _k)
        {
            on_draw_event += DrawResults;
            try
            {
                active = extras["active"];
            }
            catch(Exception)
            {
                active = 0.1;
            }
            //active = extras<0?0.3:_active;
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
            int tmp= d.GetClosestIndx(current, centroids);
            cIndx[currentIndx]= tmp;
            int i;
            for(i=0;i<MyPoint.LENGTH;i++)
            {
                centroids[tmp].x[i] += active * (current.x[i] - centroids[tmp].x[i]);
                centroids[tmp].changed = true;
            }

            currentIndx++;
            Progress = ((double)currentIndx) / n;
            if (currentIndx==n)
            {
                finished = true;
            }
        }
    }
}
