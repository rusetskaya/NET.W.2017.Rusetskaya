using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LogicQuickSort.QuickSortAlgorithm;
using System.Linq;

namespace LogicQuickSort.UnitTests
{
    [TestClass]
    public class LogicQuickSortUnitTests
    {
        [TestMethod]
        public void IsArray_2_5_1_8_minus1_AfterQuicksortEquals_minus1_1_2_5_8()
        {
            //Arrange
            int[] array = new int[] { 2,5,1,8,-1};
            int[] expected = new int[] { -1, 1, 2, 5, 8 };
            //Act
            Quicksort(array, 0, array.Length-1);
            int[] actual = array ;
            //Assert       
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}
