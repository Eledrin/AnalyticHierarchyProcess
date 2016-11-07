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
        public List<Criterion> Criteria {  get; private set; }
        
        //Singleton costructor
        private AHP() { }

        public void prepareDataStructure(List<string> namesOfCriteria, List<string> namesOfAlternatives)
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
        public void ComputeWeightOfCriteria(int[][] Values)
        {
            double weight = 0;
            //compute weights...
            
            //setting weigts for criteria
            foreach (var criterion in Criteria)
            {
                criterion.Weight = weight;
            }
        }


    }
}
