using System;
using System.Collections.Generic;
using NUnit.Framework;
using static Task4.Solution.Calculator;

namespace Task4.Tests
{
    [TestFixture]
    public class TestCalculator
    {
        private readonly List<double> values = new List<double> { 10, 5, 7, 15, 13, 12, 8, 7, 4, 2, 9 };

        [Test]
        public void Test_AverageByMean()
        {

            double expected = 8.3636363;

            double actual = CalculateAverage(CalculateAverageMean, values);

            Assert.AreEqual(expected, actual, 0.000001);
        }

        [Test]
        public void Test_AverageByMedian()
        {
            double expected = 8.0;

            double actual = CalculateAverage(CalculateAverageMedian, values);

            Assert.AreEqual(expected, actual, 0.000001);
        }
    }
}