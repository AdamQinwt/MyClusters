﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Clusterers.EMCenter
{
    class EMCenterBasic:EMCenterBase
    {
        public EMCenterBasic(int _n, int cntCls, MyPoint intiPos = null) :base(_n,cntCls,intiPos)
        {
            on_cov_changed_event += _calcRcov;
            on_cov_changed_event += _calcDetcov;
            on_cov_changed_event += _calcRowSum;
            on_cov_changed_event += _calcConstMult;
            CovChanged();
        }
        public override void updateCent(MyPoint p, int indx,double mult=1)
        {
            newCent += p * (y[indx] * mult);
        }
        public override void updateCov(MyPoint p, int indx, double mult = 1)
        {
            double[,] ttmp = p & cent;
            int cnl, cnl2;
            for (cnl2 = 0; cnl2 < L; cnl2++)
            {
                for (cnl = 0; cnl < L; cnl++)
                {
                    newCov[cnl2, cnl] += y[indx] * mult * ttmp[cnl2, cnl];
                }
            }
        }
        protected override double _getRawProb(MyPoint p)
        {
            double sum, tmp;
            int cnl,cnl2;
            sum = 0;
            for (cnl = 0; cnl < L; cnl++)
            {
                for (cnl2 = 0; cnl2 < L; cnl2++)
                {
                    sum += covr[cnl,cnl2]*(p.x[cnl] - cent.x[cnl])*(p.x[cnl2] - cent.x[cnl2]);
                }
            }
            return pi * constMult * Math.Exp(-0.5 * sum);
        }
        protected override void _normalizeProb(int indx, double sum)
        {
            y[indx] = nny[indx] / sum;
        }
    }
}
