using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Clusterers.EMCenter
{
    class EMCenterConstCov : EMCenterBasic
    {
        public EMCenterConstCov(int _n, int cntCls, MyPoint intiPos = null) : base(_n, cntCls, intiPos)
        {
        }
        public override void updateCov(MyPoint p, int indx, double mult = 1)
        {
        }
        public override void M_p1()
        {
            int cnl;
            for (cnl = 0; cnl < L; cnl++)
            {
                cent.x[cnl] = newCent.x[cnl] / count;
                cent.changed = true;
                newCent.x[cnl] = 0;
            }
        }
    }
}
