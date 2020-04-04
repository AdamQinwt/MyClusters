﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Distances
{
    class DistanceManhattan : DistanceBase
    {
        public override double D(MyPoint a, MyPoint b)
        {
            double tmp, d = 0.0;
            int i;
            for (i = 0; i < MyPoint.LENGTH; i++)
            {
                tmp = a.x[i] - b.x[i];
                d += Math.Abs(tmp);
            }
            return Math.Sqrt(d);
        }
    }
}
