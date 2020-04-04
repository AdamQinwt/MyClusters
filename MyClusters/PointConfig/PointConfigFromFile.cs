using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace MyClusters.PointConfig
{
    class PointConfigFromFile:PointConfigBase
    {
        public PointConfigFromFile(string path)
        {
            StreamReader r = new StreamReader(path);
            string[] lines = r.ReadToEnd().Split('\n');
            string[] attris,a;
            int kk = int.Parse(lines[0]);
            int i, j,indx=1;
            count = new int[kk];
            mins = new double[kk][];
            maxs = new double[kk][];
            for(i=0;i<kk;i++)
            {
                if (lines[indx][0] == '#')
                { indx++; continue; }
                attris = lines[indx].Split(',');
                count[i] = int.Parse(attris[0]);
                indx++;
                mins[i] = new double[MyPoint.LENGTH];
                maxs[i] = new double[MyPoint.LENGTH];
                for (j = 0; j < MyPoint.LENGTH; j++)
                {
                    a = attris[j+1].Split(':');
                    mins[i][j] = double.Parse(a[0]);
                    maxs[i][j] = double.Parse(a[1]);
                }
            }
        }
    }
}
