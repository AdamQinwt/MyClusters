using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Distances
{
    class DistanceCosine : DistanceBase
    {
        public override double D(MyPoint a, MyPoint b)
        {
            double tmp1 = 0.0, tmp2 = 0.0, d = 0.0;
            int i;
            for (i = 0; i < MyPoint.LENGTH; i++)
            {
                d += a.x[i] * b.x[i];
                tmp1 += a.x[i] * a.x[i];
                tmp2 += b.x[i] * b.x[i];
            }
            return 1 - d / (tmp1 * tmp2);
        }
    }
}