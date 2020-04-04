using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace MyClusters
{
    static class RandUtils
    {
        static Random r=new Random();
        public static double GetUniformRandom(double lower, double upper)
        {
            if (lower == upper) return lower;
            return r.NextDouble()*(upper-lower)+lower;
        }
        public static Color RandomColor()
        {
            return Color.FromArgb(r.Next(0,256), r.Next(0, 256), r.Next(0, 256));
        }
        public static T[] Shuffle<T>(T[] a)
        {
            T[] rr = new T[a.Length];
            int i,j;
            T t;
            for(i=0;i<a.Length;i++)
            {
                rr[i] = a[i];
            }
            for (i = 0; i < rr.Length; i++)
            {
                int x, y;
                x = r.Next(0, rr.Length);
                do
                {
                    y = r.Next(0, rr.Length);
                } while (y == x);

                t = rr[x];
                rr[x] = rr[y];
                rr[y] = t;
            }
            return rr;
        }
        public static double[,] RandomMatrix05(int m,int n)
        {
            double[,] r = new double[m, n];
            int i, j;
            for(i=0;i<m;i++)
            {
                for(j=0;j<n;j++)
                {
                    r[i, j] = GetUniformRandom(-0.5, 0.5);
                }
            }
            return r;
        }
        public static double[,] UnitMatrix(int n)
        {
            double[,] r = new double[n, n];
            int i;
            for (i = 0; i < n; i++)
            {
                r[i, i] = 1;
            }
            return r;
        }
    }
}
