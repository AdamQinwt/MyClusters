using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace MyClusters
{
    public class MyPoint
    {
        public const int LENGTH = 2;
        public const double GLOBAL_MIN=-5,GLOBAL_MAX=-GLOBAL_MIN, GLOBAL_INTERVAL= GLOBAL_MAX- GLOBAL_MIN;
        public double[] x;
        public static Brush black = new SolidBrush(Color.Black);
        public static Brush blue = new SolidBrush(Color.Blue);
        public static Brush green = new SolidBrush(Color.Green);
        public static Brush red = new SolidBrush(Color.Red);
        PointF p;
        public bool changed;
        public MyPoint()
        {
            x = new double[LENGTH];
            changed = true;
        }
        public MyPoint(double[] _x)
        {
            x = _x;
            changed = true;
        }
        public MyPoint(MyPoint p)
        {
            x = new double[LENGTH];
            for(int i=0;i<LENGTH;i++)
            {
                x[i] = p.x[i];
            }
            changed = true;
        }
        public static MyPoint RandomPoint(double[] mins, double[] maxs)
        {
            double[] xx = new double[LENGTH];
            int i;
            for(i=0;i<LENGTH;i++)
            {
                xx[i] = RandUtils.GetUniformRandom(mins[i], maxs[i]);
            }
            return new MyPoint(xx);
        }
        public static MyPoint RandomPoint()
        {
            double[] xx = new double[LENGTH];
            int i;
            for (i = 0; i < LENGTH; i++)
            {
                xx[i] = RandUtils.GetUniformRandom(GLOBAL_MIN, GLOBAL_MAX);
            }
            return new MyPoint(xx);
        }
        public static MyPoint[] RandomPoints(int count, double[] mins, double[] maxs)
        {
            MyPoint[] r = new MyPoint[count];
            int i;
            for(i=0;i<count;i++)
            {
                r[i] = RandomPoint(mins, maxs);
            }
            return r;
        }
        public static MyPoint[] RandomPoints(int count, double min=GLOBAL_MIN, double max=GLOBAL_MAX)
        {
            MyPoint[] r = new MyPoint[count];
            double[] mins = new double[LENGTH], maxs = new double[LENGTH];
            int i;
            for(i=0;i<LENGTH;i++)
            {
                mins[i] = min; maxs[i] = max;
            }
            for (i = 0; i < count; i++)
            {
                r[i] = RandomPoint(mins, maxs);
            }
            return r;
        }
        public static MyPoint[] ZeroPoints(int count)
        {
            MyPoint[] r = new MyPoint[count];
            int i;
            for (i = 0; i < count; i++)
            {
                r[i] = new MyPoint();
            }
            return r;
        }
        public static MyPoint[] RandomPointArrays(int[] counts, double[][] mins, double[][] maxs)
        {
            int i,j,indx=0,total=0;
            for(i=0;i<counts.Length;i++)
            {
                total += counts[i];
            }
            MyPoint[] r = new MyPoint[total];
            for (i = 0; i < counts.Length; i++)
            {
                for(j=0;j<counts[i];j++)
                {
                    r[indx] = RandomPoint(mins[i], maxs[i]);
                    indx++;
                }
            }
            return r;
        }
        public PointF ToDrawPoint(double stepX,double stepY, double startX=0, double startY=0)
        {
            return new PointF((float)(startX + stepX * (x[0] - GLOBAL_MIN)),
                (float)(startY + stepY * (x[1] - GLOBAL_MIN)));
        }
        public void DrawCircle(Graphics g, double stepX, double stepY, Brush b=null,double startX = 0, double startY = 0,int r=3,bool forceGet=false)
        {
            if (changed || p == null||forceGet)
                p = ToDrawPoint(stepX, stepY, startX, startY);
            changed = false;
            g.FillEllipse(b??black,p.X - r, p.Y - r, r, r);
        }
        public static void DrawPoints(MyPoint[] ppoints,Graphics g, double stepX, double stepY, Brush b = null, double startX = 0, double startY = 0, int r = 3)
        {
            foreach(MyPoint pp in ppoints)
            {
                pp.DrawCircle(g, stepX, stepY, b, startX, startY, r);
            }
        }
        public static MyPoint operator+(MyPoint a,MyPoint b)
        {
            MyPoint p = new MyPoint();
            int i;
            for(i=0;i<LENGTH;i++)
            {
                p.x[i] = a.x[i] + b.x[i];
            }
            return p;
        }
        public static MyPoint operator -(MyPoint a, MyPoint b)
        {
            MyPoint p = new MyPoint();
            int i;
            for (i = 0; i < LENGTH; i++)
            {
                p.x[i] = a.x[i] - b.x[i];
            }
            return p;
        }
        public static MyPoint operator *(MyPoint a, double b)
        {
            MyPoint p = new MyPoint();
            int i;
            for (i = 0; i < LENGTH; i++)
            {
                p.x[i] = a.x[i] * b;
            }
            return p;
        }
        public static MyPoint operator /(MyPoint a, double b)
        {
            MyPoint p = new MyPoint();
            int i;
            for (i = 0; i < LENGTH; i++)
            {
                p.x[i] = a.x[i] / b;
            }
            return p;
        }
        public static double[,] operator &(MyPoint a, MyPoint b)
        {
            MyPoint p = a-b;
            double[,] d = new double[LENGTH, LENGTH];
            int i,j;
            for (i = 0; i < LENGTH; i++)
            {
                for (j = 0; j < LENGTH; j++)
                {
                    d[i, j] = p.x[i] * p.x[j];
                }
            }
            return d;
        }
        public double getL2()
        {
            double ll = 0;
            foreach(double d in x)
            {
                ll += d * d;
            }
            return ll;
        }
    }
}
