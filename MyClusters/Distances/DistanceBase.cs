using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Distances
{
    public abstract class DistanceBase
    {
        public abstract double D(MyPoint a, MyPoint b);
        public static DistanceBase Distance(string name)
        {
            switch(name)
            {
                case "Euclidian":return new DistanceEuclidian();
                case "Manhattan": return new DistanceManhattan();
                case "cos":return new DistanceEuclidian();
                default:
                    return null;
            }
        }
        public int GetClosestIndx(MyPoint from, MyPoint[] tgts)
        {
            int indx = 0,i;
            double mdistance=D(from,tgts[0]),tmp;
            for(i=1;i<tgts.Length;i++)
            {
                tmp = D(from, tgts[i]);
                if (tmp == 0) return i;
                if(tmp<mdistance)
                {
                    indx = i;
                    mdistance = tmp;
                }
            }
            return indx;
        }
        public int[] Get2ClosestIndx(MyPoint from, MyPoint[] tgts)
        {
            int indx1 = 0,indx2=1, i;
            if (tgts.Length < 2) return new int[2] { 0, 0 };
            double mdistance1 = D(from, tgts[0]), mdistance2 = D(from, tgts[1]), tmp;
            if(mdistance1>mdistance2)
            {
                tmp = mdistance1;
                mdistance1 = tmp;
                mdistance2 = tmp;
                indx1 ^= indx2;
                indx2 ^= indx1;
                indx1 ^= indx2;
            }
            for (i = 1; i < tgts.Length; i++)
            {
                tmp = D(from, tgts[i]);
                if (tmp >= mdistance2) continue;
                else if (tmp <= mdistance1)
                {
                    indx2 = indx1;
                    mdistance2 = mdistance1;
                    indx1 = i;
                    mdistance1 = tmp;
                }
                else if(tmp<mdistance2)
                {
                    indx2 = i;
                    mdistance2 = tmp;
                }
            }
            return new int[2] { indx1, indx2 };
        }
        public int GetBiasdClosestIndx(MyPoint from, MyPoint[] tgts,double[] biases)
        {
            int indx = 0, i;
            double mdistance = biases[0]*D(from, tgts[0]), tmp;
            for (i = 1; i < tgts.Length; i++)
            {
                tmp = biases[i]*D(from, tgts[i]);
                if (tmp == 0) return i;
                if (tmp < mdistance)
                {
                    indx = i;
                    mdistance = tmp;
                }
            }
            return indx;
        }
        public int GetClosestWithDist(MyPoint from, MyPoint[] tgts,out double distance)
        {
            int indx = 0, i;
            double mdistance = D(from, tgts[0]), tmp;
            for (i = 1; i < tgts.Length; i++)
            {
                tmp = D(from, tgts[i]);
                if (tmp == 0)
                {
                    distance = 0;
                    return i;
                }
                if (tmp < mdistance)
                {
                    indx = i;
                    mdistance = tmp;
                }
            }
            distance = mdistance;
            return indx;
        }
    }
}
