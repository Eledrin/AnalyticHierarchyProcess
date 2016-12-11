using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticHierarchyProcess.Classes
{
    public class Criterion
    {
        public string Name { get; }
        public double [] PairwiseValues { get; set; }
        public double Coeff { get; set; }
        public List<Alternative> ValuesOfAlternatives { get; }

        public Criterion(string name)
        {
            Name = name;
            ValuesOfAlternatives = new List<Alternative>();
            PairwiseValues = null;
            Coeff = 0.0;
        }

        public void SetAlternativesPairwiseValues(double[][] Matrix)
        {
            //ToDo
        }

    }
}
