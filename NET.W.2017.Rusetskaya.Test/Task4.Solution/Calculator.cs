using System;
using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public delegate double Average(List<double> valList);
    public class Calculator
    {
        public static double CalculateAverage(Average average, List<double> values)
        {
            if (ReferenceEquals(average, null))
            {
                throw new ArgumentNullException(nameof(average));
            }

            return average.Invoke(values);
        }

        public static double CalculateAverageMean(List<double> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException(nameof(values));
            }

            return values.Sum() / values.Count;
        }

        public static double CalculateAverageMedian(List<double> values)
        {
            var sortedValues = values.OrderBy(x => x).ToList();

            int n = sortedValues.Count;

            if (n % 2 == 1)
            {
                return sortedValues[(n - 1) / 2];
            }

            return (sortedValues[sortedValues.Count / 2 - 1] + sortedValues[n / 2]) / 2;
        }
    }
}