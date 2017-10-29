using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayLibrary
{
    public class ArraySort
    {
        public interface IComparer
        {
            int Compare(int[] lhs, int[] rhs);
        }
        /// <summary>
        /// Compare sum by inc
        /// </summary>
        public class ComparerSumByInc : IComparer
        { 
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Sum() - rhs.Sum();
            }
        }

        /// <summary>
        /// Compare sum by dec
        /// </summary>
        public class ComparerSumByDec : IComparer
        { 
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1; 
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Sum() - lhs.Sum();
            }
        }
        /// <summary>
        /// compare max by inc
        /// </summary>
        public class ComparerMaxByInc : IComparer
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Max() - rhs.Max();
            }
        }
        /// <summary>
        /// compare max by dec
        /// </summary>
        public class ComparerMaxByDec : IComparer
        { 
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1;
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Max() - lhs.Max();
            }
        }
        /// <summary>
        /// compare min by inc
        /// </summary>
        public class ComparerMinByInc : IComparer
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return 1;
                }
                if (rhs == null)
                {
                    return -1;
                }
                return lhs.Min() - rhs.Min();
            }
        }
        /// <summary>
        /// compare min by dec
        /// </summary>
        public class ComparerMinByDec : IComparer
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                if (lhs == null)
                {
                    return -1;
                }
                if (rhs == null)
                {
                    return 1;
                }
                return rhs.Min() - lhs.Min();
            }
        }

        public static class ArrayHelper
        {
            public static void BubbleSort(int[][] jaggedArray, IComparer comparer)
            {
                if (jaggedArray == null)
                {
                    throw new ArgumentNullException(nameof(jaggedArray));
                }
                for (int i = 1; i < jaggedArray.Length; i++)
                {
                    for (int j = 0; j < jaggedArray.Length - 1; j++)
                    {
                        if (comparer.Compare(jaggedArray[j], jaggedArray[j + 1]) > 0)
                        {
                            Swap(ref jaggedArray[j], ref jaggedArray[j + 1]);
                        }
                    }
                }
            }
        }
        public static void Swap<T>(ref T a, ref T b)
        {
            T t = a;
            a = b;
            b = t;
        }

        public static int SumOfRowElemets(int[] array) => array.Sum();
    }
}
