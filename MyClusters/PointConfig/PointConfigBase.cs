using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.PointConfig
{
    class PointConfigBase
    {
        public int[] count;
        public double[][] mins, maxs;
        public MyPoint[] MakePoints()
        {
            return MyPoint.RandomPointArrays(count, mins, maxs);
        }
    }
}
