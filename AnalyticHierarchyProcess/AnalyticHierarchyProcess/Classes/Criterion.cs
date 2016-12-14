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
            for (int i = 0; i < ValuesOfAlternatives.Count; i++)
            {
                ValuesOfAlternatives[i].PairwiseValues = Matrix[i];
            }
        }

        public void ComputeAlternativesCoeffs()
        {
            double CoeffSum = 0.0;
            foreach (var item in ValuesOfAlternatives)
            {
                foreach (var element in item.PairwiseValues)
                {
                    if (item.Coeff == 0.0)
                    {
                        item.Coeff = element;
                    }
                    else
                    {
                        item.Coeff *= element;
                    }
                }
                item.Coeff = Math.Pow(item.Coeff, 1.0 / item.PairwiseValues.Length);
                CoeffSum += item.Coeff;
            }
            foreach (var item in ValuesOfAlternatives)
            {
                item.Coeff = (item.Coeff / CoeffSum) * item.PairwiseValues.Length;
                item.Coeff = Math.Round(item.Coeff, 4);
            }
        }
    }
}
