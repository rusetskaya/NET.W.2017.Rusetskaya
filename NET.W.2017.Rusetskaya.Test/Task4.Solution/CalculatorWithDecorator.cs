using System.Collections.Generic;
using System.Linq;

namespace Task4.Solution
{
    public abstract class CalculatorWithDecorator //Component
    {
        public abstract double CalculateAverageMean(List<double> values);
        public abstract double CalculateAverageMedian(List<double> values);
    }

    class ConcreteCalculator : CalculatorWithDecorator
    {
        public override double CalculateAverageMean(List<double> values)
        {
            return values.Sum() / values.Count;
        }

        public override double CalculateAverageMedian(List<double> values)
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

    abstract class Decorator : CalculatorWithDecorator
    {
        protected CalculatorWithDecorator component;

        public void SetComponent(CalculatorWithDecorator component)
        {
            this.component = component;
        }

        public override double CalculateAverageMedian(List<double> values)
        {
           return component.CalculateAverageMedian(values);    
        }

        public override double CalculateAverageMean(List<double> values)
        {
            return component.CalculateAverageMean(values);
        }
    }
    class CalculateAverageMeanDec : Decorator
    {
        public override double CalculateAverageMean(List<double> values)
        {
            return base.CalculateAverageMean(values);
        }
    }
    class CalculateAverageMedianDec : Decorator
    {
        public override double CalculateAverageMedian(List<double> values)
        {
            return base.CalculateAverageMedian(values);
        }
    }
}