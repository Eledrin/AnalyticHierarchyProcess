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
        public int NumberOfAlternatives { get; }
        public List<string> AlternativesNames { get; }
        public List<int> WeightCriteria { get; }

        private AHP() { }

    }
}
