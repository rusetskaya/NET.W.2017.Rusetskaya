using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static IntegerLibrary.SpecialIntegerLogic;
using NUnit.Framework;
using System.Diagnostics;
using System.Collections;

namespace IntegerLibrary.Tests
{
    public class IntegerLibraryTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]

        public long NextBiggerNumberTest(long actual)
        {
            return NextBiggerNumber(actual);
        }


        [TestCase(12, ExpectedResult = true)]
        [TestCase(513, ExpectedResult = true)]
        [TestCase(2017, ExpectedResult = true)]
        [TestCase(414, ExpectedResult = true)]
        [TestCase(144, ExpectedResult = true)]
        [TestCase(1234321, ExpectedResult = true)]
        [TestCase(1234126, ExpectedResult = true)]
        [TestCase(3456432, ExpectedResult = true)]
        [TestCase(10, ExpectedResult = true)]
        [TestCase(20, ExpectedResult = true)]
        //to do тесты для времени
        public bool NextBiggerNumberTimeTest(long actual)
        {
            int maxExpectedTime = 20;
            object time;
            NextBiggerNumber(actual, out time);
            bool resultTime = (int)Convert.ChangeType(time, typeof(int)) < maxExpectedTime;
            return resultTime; 
        }


        [TestCase(15, 15, 0, 0, ExpectedResult = 15)]
        [TestCase(8, 15, 0, 0, ExpectedResult = 9)]
        [TestCase(8, 15, 3, 8, ExpectedResult = 120)]
        public int InsertNumberIntoBitArrayTest(int numberSource, int numberIn, int i, int j)
        {
            return InsertNumber(numberSource, numberIn, i, j);
        }

        [Test]
        public void ReverseTest()
        {
            BitArray init = new BitArray(new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, false, false, false });
            BitArray expectedResult = new BitArray(new bool[32] { false, false, false, true, true, true, true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false });
            BitArray actual = Reverse(init);
            CollectionAssert.AreEqual(expectedResult, actual);
        }


        [TestCase(ExpectedResult = new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, false, false, false})]
        public bool[] GetBinaryRepresentationTest()
        {
            return GetBinaryRepresentation(120);
        }


        [TestCase(new bool[32] { false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, true, true, true, true, false, false, false }, ExpectedResult = 120)]
        public int GetIntFromBitArrayTest(bool[] boolArray)
        {
            BitArray array = new BitArray(boolArray);
            return GetIntFromBitArray(array);
        }
    }
}