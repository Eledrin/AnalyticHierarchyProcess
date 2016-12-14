using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticHierarchyProcess.Classes
{
    public class AHP
    {
        private static AHP anchorInstance = null;
        public static AHP Instance
        {
            get
            {
                if (anchorInstance == null)
                {
                    anchorInstance = new AHP();
                }
                return anchorInstance;
            }
        }
        public List<Criterion> Criteria { get; private set; }
        private List<double?> evaluations;

        //Singleton costructor
        private AHP() { }

        public void PrepareDataStructure(List<string> namesOfCriteria, List<string> namesOfAlternatives)
        {
            Criteria = new List<Criterion>();
            foreach (var criterionName in namesOfCriteria)
            {
                Criteria.Add(new Criterion(criterionName));
                foreach (var alternativeName in namesOfAlternatives)
                {
                    Criteria.Last().ValuesOfAlternatives.Add(new Alternative(alternativeName));
                }
            }
            evaluations = new List<double?>(namesOfAlternatives.Count);
            for (int i = 0; i < evaluations.Capacity; i++)
            {
                evaluations.Add(null);
            }
        }

        public void SetCriteriaPairwiseValues(double[][] Matrix)
        {
            for (int i = 0; i < Criteria.Count; i++)
            {
                Criteria[i].PairwiseValues = Matrix[i];
            }
        }

        private void ComputeCriteriaCoeffs()
        {
            double CoeffSum = 0.0;
            foreach (var item in Criteria)
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
            foreach (var item in Criteria)
            {
                item.Coeff = (item.Coeff / CoeffSum) * item.PairwiseValues.Length;
                item.Coeff = Math.Round(item.Coeff, 3);
            }
        }

        public void ComputeEvaluationOfAlternatives()
        {
            ComputeCriteriaCoeffs();
            foreach (var item in Criteria)
            {
                item.ComputeAlternativesCoeffs();
            }
            for (int i = 0; i < evaluations.Count; i++)
            {
                evaluations[i] = 0.0;
                foreach (var item in Criteria)
                {
                    evaluations[i] += item.Coeff * item.ValuesOfAlternatives[i].Coeff;
                }
            }
        }

        public string GetNameOfBestAlternative()
        {
            if (evaluations.Contains(null))
                throw new Exception("Brak ocen alternatyw");
            double? maxValue = evaluations.Max();
            return Criteria[0].ValuesOfAlternatives[evaluations.IndexOf(maxValue)].Name;
        }

        public double? GetEvaluationOfBestAlternative()
        {
            return evaluations.Max();
        }

        public bool CheckDataIntegrity()
        {
            List<double> RI = new List<double> { 0.0, 0.0, 0.52, 0.89, 1.11, 1.25, 1.35, 1.40, 1.45, 1.49 };
            List<double> lMax = new List<double>();
            List<double> CI = new List<double>();
            List<double> CR = new List<double>();
            double t1 = 0.0, t2 = 0.0;
            foreach (var item in Criteria)
            {
                t1 = 0.0;
                for (int i = 0; i < item.PairwiseValues.Length; i++)
                {
                    t1 += item.PairwiseValues[i];
                }
                t2 = t1 * item.Coeff;
            }
            lMax.Add(t2 / Criteria.Count);
            foreach (var item in Criteria[0].ValuesOfAlternatives)
            {
                t1 = 0.0;
                for (int i = 0; i < item.PairwiseValues.Length; i++)
                {
                    t1 += item.PairwiseValues[i];
                }
                t2 = t1 * item.Coeff;
            }
            return false;
        }
    }
}
