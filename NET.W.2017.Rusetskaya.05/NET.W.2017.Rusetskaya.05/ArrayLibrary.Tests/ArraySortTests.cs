using System;
using NUnit.Framework;
using static ArrayLibrary.ArraySort;

namespace ArrayLibrary.Tests
{
    [TestFixture]
    public class ArraySortTests
    {
        [Test]
        public void ComparerSumByIncTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[0] = jaggedArray[2];
            expected[1] = jaggedArray[0];
            ArrayHelper.BubbleSort(jaggedArray, new ComparerSumByInc());

            CollectionAssert.AreEqual(expected, jaggedArray);
            
        }

        [Test]
        public void ComparerSumByIncWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ComparerSumByInc cmbd = new ComparerSumByInc();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);


            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerSumByDecTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ArrayHelper.BubbleSort(jaggedArray, new ComparerSumByDec());

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerSumByDecWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ComparerSumByDec cmbd = new ComparerSumByDec();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);


            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMaxByIncTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[0] = jaggedArray[2];
            expected[1] = jaggedArray[0];

            ArrayHelper.BubbleSort(jaggedArray, new ComparerMaxByInc());

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMaxByIncWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ComparerMaxByInc cmbd = new ComparerMaxByInc();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMaxByDecTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ArrayHelper.BubbleSort(jaggedArray, new ComparerMaxByDec());

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMaxByDecWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ComparerMaxByDec cmbd = new ComparerMaxByDec();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMinByIncTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[0] = jaggedArray[2];
            expected[1] = jaggedArray[0];

            ArrayHelper.BubbleSort(jaggedArray, new ComparerMinByInc());

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMinByIncWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[0] = jaggedArray[2];
            expected[1] = jaggedArray[0];

            ComparerMinByInc cmbd = new ComparerMinByInc();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMinByDecTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ArrayHelper.BubbleSort(jaggedArray, new ComparerMinByDec());

            CollectionAssert.AreEqual(expected, jaggedArray);
        }

        [Test]
        public void ComparerMinByDecWithDelegateTest()
        {
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[4] { 1, 2, 3, 40 };
            jaggedArray[2] = new int[6] { 1, 2, 3, 4, -1, -2 };

            int[][] expected = new int[3][];
            expected[1] = jaggedArray[0];
            expected[2] = jaggedArray[2];

            ComparerMinByDec cmbd = new ComparerMinByDec();
            CompareDlgt dlgt = cmbd.Compare;

            ArrayHelper.BubbleSortWithDlgt(jaggedArray, dlgt);

            CollectionAssert.AreEqual(expected, jaggedArray);
        }
    }
}