using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace MyClusters.Clusterers.EMCenter
{
    abstract class EMCenterBase
    {
        public MyPoint cent,newCent;
        public double[,] cov,newCov;
        public double[,] covr;    //covariance^{-1}
        public double[,] covrA;    //Assistance for covariance^{-1}
        public double[] rowSums; //sum of row[i]
        public double detcov;    //covariance
        public double covL2,covrL2;
        public double constMult;
        public double count;    //total probability
        public int n;
        public double pi;   //frequency
        public double[] y;    //probability that x[i] is in "this"
        public double[] nny;   //y without normalization
        public Brush brush;
        public Color __color;
        protected delegate void onCovChanged_event();
        protected event onCovChanged_event on_cov_changed_event;
        protected void CovChanged()
        {
            on_cov_changed_event();
        }
        public Color color
        {
            get { return __color; }
            set
            {
                __color = value;
                brush = new SolidBrush(__color);
            }
        }
        protected int L;
        public EMCenterBase(int _n, int cntCls,MyPoint intiPos=null)
        {
            n = _n;
            L = MyPoint.LENGTH;

            y = new double[n];
            nny = new double[n];

            cent = intiPos!=null?new MyPoint(intiPos):MyPoint.RandomPoint();
            newCent = new MyPoint();

            color = RandUtils.RandomColor();

            cov = RandUtils.UnitMatrix(L);
            newCov = new double[L, L];
            covr = new double[L, L];
            rowSums = new double[L];

            pi = 1 / (double)cntCls;
        }
        public void M()
        {
            M_p1();
            M_p2();
        }
        public void Expel(EMCenterBase c,double mult)
        {
            int cnl;
            MyPoint pp = c.cent - cent;
            double len = Math.Sqrt(pp.getL2());
            while(len==0)
            {
                pp = MyPoint.RandomPoint();
                len = pp.getL2();
            }
            mult *= (20 / (1 + Math.Exp(len)));
            for (cnl = 0; cnl < L; cnl++)
            {
                cent.x[cnl] -= mult * pp.x[cnl] / len;
            }
        }
        public void Decay(double mult)
        {
            int cnl;
            for (cnl = 0; cnl < L; cnl++)
            {
                for (int cnl2 = 0; cnl2 < L; cnl2++)
                {
                    cov[cnl, cnl2] *= mult;
                }
            }
        }
        /// <summary>
        /// stage 1 of a standard M
        /// </summary>
        public virtual void M_p1()
        {
            int cnl;
            for (cnl = 0; cnl < L; cnl++)
            {
                cent.x[cnl] = newCent.x[cnl] / count;
                cent.changed = true;
                newCent.x[cnl] = 0;
                for (int cnl2 = 0; cnl2 < L; cnl2++)
                {
                    cov[cnl, cnl2] = newCov[cnl, cnl2] / count;
                    newCov[cnl, cnl2] = 0;
                }
            }
        }
        /// <summary>
        /// stage 2 of a standard M
        /// </summary>
        public virtual void M_p2()
        {
            CovChanged();
            constMult = 1 / Math.Sqrt(detcov * (Math.Pow(2 * Math.PI, L)));
            pi = count / n;
            count = 0;
        }
        public void M_delta()
        {
            int cnl;
            for (cnl = 0; cnl < L; cnl++)
            {
                cent.x[cnl] += newCent.x[cnl] / count;
                cent.changed = true;
                newCent.x[cnl] = 0;
                for (int cnl2 = 0; cnl2 < L; cnl2++)
                {
                    cov[cnl, cnl2] = newCov[cnl, cnl2] / count;
                    newCov[cnl, cnl2] = 0;
                }
            }
            M_p2();
        }
        public double E1(MyPoint p,int indx)
        {
            nny[indx] = _getRawProb(p);
            if (nny[indx] > 100000 || double.IsNaN(nny[indx])) nny[indx] = 100000;
            else if (nny[indx] < 1e-10) nny[indx] = 1e-10;
            return nny[indx];
        }
        /// <summary>
        /// update normalized prob
        /// </summary>
        public void E2(int indx,double sum)
        {
            _normalizeProb(indx,sum);
            //count += y[indx];
        }
        public abstract void updateCent(MyPoint p,int indx, double mult = 1);
        public abstract void updateCov(MyPoint p, int indx, double mult = 1);
        protected void _calcRowSum()
        {
            int j, kk;
            for (j = 0; j < L; j++)
            {
                rowSums[j] = 0;
                for (kk = 0; kk < L; kk++)
                {
                    rowSums[j] += covr[j, kk];
                }
            }
        }
        protected void _calcDetcov()
        {
            int i;
            for (i = 0; i < L; i++)
            {
                if (L == 1)
                {
                    detcov = cov[0, 0];
                }
                else if (L == 2)
                {
                    detcov = cov[0, 0] * cov[1, 1] - cov[1, 0] * cov[0, 1];
                }
                if (detcov < 0) detcov = -detcov;
            }
        }
        protected void _calcRcov()
        {
            int xx, yy;
            int ss = (L << 1) + 1;
            if (covrA == null) covrA = new double[(L << 1) + 1, (L << 1) + 1];
            for (xx = 0; xx < ss; xx++)
            {
                for (yy = 0; yy < ss; yy++)
                {
                    covrA[xx, yy] = 0.00000000;
                }
            }
            for (xx = 0; xx < L; xx++)
            {
                for (yy = 0; yy < L; yy++)
                {
                    covrA[xx, yy] = cov[xx, yy];
                }
            }

            for (xx = 0; xx < L; xx++)
            {
                for (yy = L; yy < ss; yy++)
                {
                    if ((yy - xx) == L)
                    {
                        covrA[xx, yy] = 1.0;
                    }
                    else
                    {
                        covrA[xx, yy] = 0;
                    }
                }
            }
            for (yy = 0; yy < L; yy++)
            {
                if (covrA[yy, yy] != 1)
                {
                    double bs = covrA[yy, yy];
                    covrA[yy, yy] = 1;
                    for (int p = yy + 1; p < (L << 1); p++)
                    {
                        covrA[yy, p] /= bs;
                    }
                }
                for (int q = 0; q < L; q++)
                {
                    if (q != yy)
                    {
                        double bs = covrA[q, yy];
                        for (int p = 0; p < (L << 1); p++)
                        {
                            covrA[q, p] -= bs * covrA[yy, p];
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            for (xx = 0; xx < L; xx++)
            {
                for (yy = L; yy < (L << 1); yy++)
                {
                    covr[xx, yy - L] = covrA[xx, yy];
                }
            }

        }
        protected void _calcConstMult()
        {
            constMult = 1 / Math.Sqrt(detcov * (Math.Pow(2 * Math.PI, MyPoint.LENGTH)));
        }
        protected abstract double _getRawProb(MyPoint p);
        public double GetRawProb(MyPoint p)
        {
            return _getRawProb(p);
        }
        protected abstract void _normalizeProb(int indx,double sum);
        public static int getCls(int indx,Dictionary<int,EMCenterBase> centers)
        {
            int indxMax = 0;
            double possib = 0.0;
            foreach(int i in centers.Keys)
            {
                if(centers[i].y[indx]>possib)
                {
                    possib = centers[i].y[indx];
                    indxMax = i;
                    if(possib>0.5)
                    {
                        return indxMax;
                    }
                }
            }
            return indxMax;
        }
        protected void getL2s()
        {
            int cnl1, cnl2;
            covL2 = 0;
            covrL2 = 0;
            for(cnl1=0;cnl1<L;cnl1++)
            {
                for(cnl2=0;cnl2<L;cnl2++)
                {
                    covL2 += cov[cnl1, cnl2] * cov[cnl1, cnl2];
                    covrL2 += covr[cnl1, cnl2] * covr[cnl1, cnl2];
                }
            }
        }
        public void ResetNew()
        {
            count = 0;
            int cnl1, cnl2;
            for(cnl1=0;cnl1<L;cnl1++)
            {
                cent.x[cnl1] = 0;
                for (cnl2 = 0; cnl2 < L; cnl2++)
                {
                    newCov[cnl1, cnl2] = 0;
                }
            }
        }
    }
}
