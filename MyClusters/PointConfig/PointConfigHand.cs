using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.PointConfig
{
    class PointConfigHand : PointConfigBase
    {
        public PointConfigHand()
        {
            count = new int[3] { 2, 1,3 };
            mins = new double[3][];
            maxs = new double[3][];
            mins[0] = new double[MyPoint.LENGTH] { -3, 2 };
            maxs[0] = new double[MyPoint.LENGTH] { -1, 5 };
            mins[1] = new double[MyPoint.LENGTH] { -5, -5 };
            maxs[1] = new double[MyPoint.LENGTH] { -2, -1 };
            mins[2] = new double[MyPoint.LENGTH] { 3, -2 };
            maxs[2] = new double[MyPoint.LENGTH] { 5, 0 };
        }
    }
}
