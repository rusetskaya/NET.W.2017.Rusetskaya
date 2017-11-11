using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegerLibrary.GreatestCommonDivisor;

namespace IntegerLibrary.MSUnitTests
{
    [TestClass]
    public class GreatestCommonDivisorTests
    {
        #region Euclids Algorithm Methods Tests
        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_minus5_10_equals_5()
        {
            int first = -5, second = 10;
            int expected = 5;
            Assert.AreEqual(expected, EuclidsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_27_minus15_30_equals_5()
        {
            int first = 10, second = -15, third = 30;
            int expected = 5;
            Assert.AreEqual(expected, EuclidsAlgorithm(first, second, third).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_327_564_258_equals_3()
        {
            int first = 327, second = 564, third = 258;
            int expected = 3;
            Assert.AreEqual(expected, EuclidsAlgorithm(first, second, third).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_0_5_equals_5()
        {
            int first = 0, second = 5;
            int expected = 5;
            Assert.AreEqual(expected, EuclidsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_5_0_equals_5()
        {
            int first = 5, second = 0;
            int expected = 5;
            Assert.AreEqual(expected, EuclidsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_ByEuclide_568_26_70_minus34_20_equals_2()
        {
            int[] numbers = new int[] { 568, 26, 70, -34, 20 };
            int expected = 2;
            Assert.AreEqual(expected, EuclidsAlgorithm(numbers).Item1);
        }
        #endregion

        #region Steins Algorithm Methods Tests
        [TestMethod]
        public void GreatestCommonDivisor_BySteins_minus5_10_equals_5()
        {
            int first = -5, second = 10;
            int expected = 5;
            Assert.AreEqual(expected, SteinsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_BySteins_27_minus15_30_equals_5()
        {
            int first = 10, second = -15, third = 30;
            int expected = 5;
            Assert.AreEqual(expected, SteinsAlgorithm(first, second, third).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_BySteins_327_564_258_equals_3()
        {
            int first = 327, second = 564, third = 258;
            int expected = 3;
            Assert.AreEqual(expected, SteinsAlgorithm(first, second, third).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_BySteins_0_5_equals_5()
        {
            int first = 0, second = 5;
            int expected = 5;
            Assert.AreEqual(expected, SteinsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_BySteins_5_0_equals_5()
        {
            int first = 5, second = 0;
            int expected = 5;
            Assert.AreEqual(expected, SteinsAlgorithm(first, second).Item1);
        }

        [TestMethod]
        public void GreatestCommonDivisor_BySteins_568_26_70_minus34_20_equals_2()
        {
            int[] numbers = new int[] { 568, 26, 70, -34, 20 };
            int expected = 2;
            Assert.AreEqual(expected, SteinsAlgorithm(numbers).Item1);
        }
        #endregion
    }
}
