using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClusters.Clusterers.ClusterEM;
using MyClusters.Clusterers.EMCenter;
namespace MyClusters.Clusterers.ModelSelector
{
    abstract class ModelSelectorBase
    {
        protected ClusterEMBase[,] clusterEMBase;
        Dictionary<string, double> extraArgs;
        MyPoint[] points;
        public int N;
        string _type;
        public int numPerK, numK;
        public double[] probs;
        public double[] Js;
        public int bestK;
        public ModelSelectorBase(Dictionary<string, double> _extraArgs, MyPoint[] _points,int _numK=20,int _numPerK=5)
        {
            extraArgs = _extraArgs;
            points = _points;
            N = points.Length;
            numK = _numK;
            numPerK = _numPerK;
            RunTests();
        }
        public static ModelSelectorBase GetModelSelector(string _type, Dictionary<string, double> _extraArgs, MyPoint[] _points, int _numK = 20, int _numPerK = 5)
        {
            switch(_type)
            {
                case "AIC": return new AIC(_extraArgs, _points, _numK, _numPerK);
                case "BIC": return new BIC(_extraArgs, _points, _numK, _numPerK);
                default:
                    return null;
            }
        }
        protected void RunTests()
        {
            clusterEMBase = new ClusterEMBase[numK, numPerK];
            int i, j;
            for(i=0;i<numK;i++)
            {
                for(j=0;j<numPerK;j++)
                {
                    clusterEMBase[i,j] = (ClusterEMBase)ClusterBase.Cluster("EM", null,RandUtils.Shuffle(points), i + 1, extraArgs);
                    clusterEMBase[i, j].ListColors();
                    clusterEMBase[i, j].Start();
                    while (!clusterEMBase[i, j].finished)
                    {
                        clusterEMBase[i, j].Step();
                    }
                }
            }
            
        }
        protected void CalcP()
        {
            if (probs == null) probs = new double[numK];
            int i,j;
            for(i=0;i<numK;i++)
            {
                probs[i] = 0;
                for(j=0;j<numPerK;j++)
                {
                    probs[i] += clusterEMBase[i, j].GetTotalPAll();
                }
                probs[i] /= numPerK;
            }
        }
        protected virtual void GetJs()
        {
            if (Js == null) Js = new double[numK];
            CalcP();
            int i;
            for (i = 0; i < numK; i++)
            {
                Js[i] = probs[i];
            }
        }
        public virtual void Run()
        {
            GetJs();
            int i = 0;
            bestK = 0;
            double bestJ = Js[0];
            for(i=1;i<numK;i++)
            {
                if(Js[i]>bestJ)
                {
                    bestK = i;
                    bestJ = Js[i];
                }
            }
            bestK++;
        }
    }
}
