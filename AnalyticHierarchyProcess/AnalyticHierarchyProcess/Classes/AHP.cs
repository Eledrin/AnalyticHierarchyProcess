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
        }

        private bool checkCriteriaCoeffs()
        {
            double CoeffSum = 0.0;
            foreach (var item in Criteria)
            {
                CoeffSum += item.Coeff;
            }
            return (Criteria.Count - CoeffSum < 0.1 && Criteria.Count - CoeffSum > -0.1);
        }

        public void SetCriteriaPairwiseValues(double[][] Matrix)
        {
            for (int i = 0; i < Matrix.Length; i++)
            {
                Criteria[i].PairwiseValues = Matrix[i];
            }
        }

        public void ComputeCriteriaCoeffs()
        {
            double CoeffSum = 0.0;
            foreach (var item in Criteria)
            {
                foreach(var element in item.PairwiseValues)
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
            double temp = 0.0;
            foreach (var item in Criteria)
            {
                item.Coeff = (item.Coeff / CoeffSum) * item.PairwiseValues.Length;
                item.Coeff = Math.Round(item.Coeff, 4);
                temp += item.Coeff;
            }
            //Console.WriteLine(checkCriteriaCoeffs());
        }


    }
}
