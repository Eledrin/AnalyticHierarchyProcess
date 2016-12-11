using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnalyticHierarchyProcess.Classes
{
    public static class ValidateValues
    {
        static List<double> allowedValues = new List<double> {
                1, 2, 3, 4, 5, 6, 7, 8, 9,
                Math.Round(1.0/2.0, 4), Math.Round(1.0/3.0,4), Math.Round(1.0/4.0,4), Math.Round(1.0/5.0,4),
                Math.Round(1.0/6.0,4), Math.Round(1.0/7.0,4), Math.Round(1.0/8.0,4), Math.Round(1.0/9.0,4)
            };
        public static void Check(double value)
        {
            value = Math.Round(value, 4);
            if (!allowedValues.Contains(value))
                throw new ArgumentException("Niepoprawna wartość");
        }
        public static void Check(double[] values)
        {
            double value = 0.0;
            foreach (var item in values)
            {
                value = Math.Round(item, 4);
                if (!allowedValues.Contains(value))
                    throw new ArgumentException("Niepoprawna wartość");
            }
        }
        public static void Check(double[][] values)
        {
            double value = 0.0;
            foreach (var item in values)
            {
                foreach (var element in item)
                {
                    value = Math.Round(element, 4);
                    if (!allowedValues.Contains(value))
                        throw new ArgumentException("Niepoprawna wartość");
                }
            }
        }
    }
}
