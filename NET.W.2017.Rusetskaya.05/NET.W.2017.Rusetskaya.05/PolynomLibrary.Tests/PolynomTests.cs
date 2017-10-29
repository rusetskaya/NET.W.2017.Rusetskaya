using System;
using NUnit.Framework;
using System.Diagnostics;

namespace PolynomLibrary.Tests
{
    [TestFixture]
    public class PolynomTests
    {
        [TestCase(new double[] { 12, 0, 3 }, ExpectedResult = "12x^0+0x^1+3x^2")]
        [TestCase(new double[] { 3, 7 }, ExpectedResult = "3x^0+7x^1")]
        public string ToStringTest(double[] array)
        {
            Polynomial polinom = new Polynomial(array);
            return polinom.ToString();
        }


        [TestCase(new double[] { 3, 7, 7 }, new double[] { 7, 3, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 7, 7 }, new double[] { 3, 7, 7 }, ExpectedResult = true)]
        public bool EqualsTest(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return p1.Equals(p2);
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 6, 1, 3 }, ExpectedResult = "8x^0+1x^1+4x^2")]
        [TestCase(new double[] { 0, 1, 1 }, new double[] { 1, 4 }, ExpectedResult = "1x^0+5x^1")]
        public string OperatorPlus(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return (p1+p2).ToString();
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 6, 1, 3 }, ExpectedResult = "-4x^0-1x^1-2x^2")]
        public string OperatorMinus(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            return (p1 - p2).ToString();
        }

        [TestCase(new double[] { 2, 0, 1 }, new double[] { 1, 4 }, ExpectedResult = "2x^0+8x^1+1x^2+4x^3")]
        public string OperatorMultiply(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            //Debug.WriteLine(p1.ToString());
            //Debug.WriteLine(p2.ToString());
            return (p1*p2).ToString();
        }

        [TestCase(new double[] { 3, 7, 7 }, new double[] { 7, 3, 5 }, ExpectedResult = false)]
        [TestCase(new double[] { 3, 7, 7 }, new double[] { 3, 7, 7 }, ExpectedResult = true)]
        public bool OperatorEqual(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            bool exp = (p1 == p2);
            return exp;
        }

        [TestCase(new double[] { 3, 7, 7 }, new double[] { 7, 3, 5 }, ExpectedResult = true)]
        [TestCase(new double[] { 3, 7, 7 }, new double[] { 3, 7, 7 }, ExpectedResult = false)]
        public bool OperatorNotEqual(double[] array1, double[] array2)
        {
            Polynomial p1 = new Polynomial(array1);
            Polynomial p2 = new Polynomial(array2);
            bool exp = (p1 != p2);
            return exp;
        }
    }
}