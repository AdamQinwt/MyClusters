using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Distances;
namespace MyClusters.Clusterers
{
    class ClusterKMeans:ClusterBase
    {
        public ClusterKMeans(DistanceBase _d, MyPoint[] _points, int _k):base(_d,_points,_k)
        {
            on_draw_event += DrawResults;
            currentIndx = points.Length;
        }
        public override void Start()
        {
            finished = false;
            centroids = MyPoint.RandomPoints(k);
        }
        public override void Step()
        {
            int i,tmp,j;
            finished = true;
            double[,] newPos = new double[k,C];
            int[] ccount = new int[k];
            for(i=0;i<n;i++)
            {
                tmp = d.GetClosestIndx(points[i], centroids);
                if(tmp!=cIndx[i])
                {
                    finished = false;
                    cIndx[i] = tmp;
                }
                ccount[tmp]++;
                for(j=0;j<C;j++)
                {
                    newPos[tmp, j] += points[i].x[j];
                }
            }
            for (i = 0; i < k; i++)
            {
                for (j = 0; j < C; j++)
                {
                    if (ccount[i] == 0) continue;
                    centroids[i].x[j] = newPos[i, j] / ccount[i];
                    centroids[i].changed = true;
                }
            }
            if(finished)
            {
                Progress = 1;
            }
        }
    }
}
