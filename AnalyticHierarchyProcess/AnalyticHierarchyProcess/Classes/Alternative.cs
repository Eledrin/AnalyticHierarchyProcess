using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticHierarchyProcess.Classes
{
    public class Alternative
    {
        public string Name { get; }
        public double Value { get; set; }

        public Alternative(string name)
        {
            Name = name;
        }
    }
}
