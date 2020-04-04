using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Clusterers.EMCenter
{
    class EMCenterDecay:EMCenterBasic
    {
        double decay,currentDecay,lowerB;
        public EMCenterDecay(int _n, int cntCls,double _decay, double lower,MyPoint intiPos = null):base(_n,cntCls,intiPos)
        {
            decay = _decay;
            currentDecay = 1;
            lowerB = lower;
        }
        public override void M_p1()
        {
            int cnl;
            for (cnl = 0; cnl < L; cnl++)
            {
                cent.x[cnl] = newCent.x[cnl] / count;
                cent.changed = true;
                newCent.x[cnl] = 0;
                for (int cnl2 = 0; cnl2 < L; cnl2++)
                {
                    cov[cnl, cnl2] = currentDecay*newCov[cnl, cnl2] / count;
                    newCov[cnl, cnl2] = 0;
                }
            }
            if(currentDecay>lowerB) currentDecay *= decay;
        }
    }
}
