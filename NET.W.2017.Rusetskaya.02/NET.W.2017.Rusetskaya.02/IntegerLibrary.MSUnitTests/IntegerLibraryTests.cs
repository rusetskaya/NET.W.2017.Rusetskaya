using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static IntegerLibrary.SpecialIntegerLogic; 

namespace IntegerLibrary.MSUnitTests
{
    [TestClass]
    public class IntegerLibraryTests
    {
        [TestMethod]
        public void Is_1_2_3_4_5_6_7_68_69_70_15_17_AfterFilterDiget7_Become_7_70_17()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17 };
            int[] expected = new int[] { 7, 70, 17 };
            //Act
            int[] actual = FilterDigit(7, array); ;
            //Assert       
            CollectionAssert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void Is_1_2_30_70_60_5_7_AfterFilterDiget0_Become_30_70_60()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 30, 70, 60, 5, 7 };
            int[] expected = new int[] { 30, 70, 60 };
            //Act
            int[] actual = FilterDigit(0, array); ;
            //Assert       
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Is_1_2_30_70_60_5_7_AfterFilterDiget_minus7_ExpectedException_ArgumentOutOfRangeException()
        {
            //Arrange
            int[] array = new int[] { 1, 2, 30, 70, 60, 5, 7 };
            //Act
            int[] actual = FilterDigit(-7, array); ;
            //Assert       
        }

    }
}
