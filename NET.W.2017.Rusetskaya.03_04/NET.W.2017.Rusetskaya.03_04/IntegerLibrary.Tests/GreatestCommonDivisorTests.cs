using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using static IntegerLibrary.GreatestCommonDivisor;


namespace IntegerLibrary.Tests
{
    //VS почему-то не видит эти тесты
    public class GreatestCommonDivisorTests
    {
        [TestCase(345, 70, ExpectedResult = 5)]
        [TestCase(0, 500, ExpectedResult = 500)]
        [TestCase(500, 0, ExpectedResult = 500)]
        [TestCase(-5, 10, ExpectedResult = 5)]
        public int GreatestCommonDivisor_ByEuclide(int first, int second)
        {
            return EuclidsAlgorithm(first, second).Item1;
        }
    }
}
