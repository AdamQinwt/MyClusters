using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClusters.Clusterers.ModelSelector
{
    class AIC:ModelSelectorBase
    {
        public AIC(Dictionary<string, double> _extraArgs, MyPoint[] _points, int _numK = 20, int _numPerK = 5):base(_extraArgs,_points,_numK,_numPerK)
        { }
        protected override void GetJs()
        {
            base.GetJs();
            int i;
            for(i=0;i<numK;i++)
            {
                Js[i] -= (MyPoint.LENGTH+1)* (MyPoint.LENGTH + 1) / 2 * (i+1);
            }
        }
    }
}
