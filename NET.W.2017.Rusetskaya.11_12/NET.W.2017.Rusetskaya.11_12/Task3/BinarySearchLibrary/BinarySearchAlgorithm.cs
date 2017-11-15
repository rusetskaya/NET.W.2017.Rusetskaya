using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLibrary
{
    public static class BinarySearchAlgorithm
    {
        public static bool BinarySearch<T>(T[] array, T x, IComparer<T> comparer = null)
        {
            if (array == null) throw new ArgumentNullException($"{nameof(array)} is null");
            if (comparer == null && typeof(T).GetInterface("IComparable`1") != null || typeof(T).GetInterface("IComparable") != null)
                comparer = Comparer<T>.Default;
            else throw new ArgumentException("Values mustn't comparer.");
            return Find(array, x, 0, array.Length - 1, comparer);
        }

        public static bool BinarySearch<T>(T[] array, T x, Comparison<T> comparison)
        {
            return BinarySearch(array, x, new AdapterComparer<T>(comparison));
        }

        private static bool Find<T>(T[] a, T x, int l, int r, IComparer<T> comparer)
        {
            if (l > r)
                return false;
            if (comparer.Compare(x, a[l]) < 0 || comparer.Compare(x, a[r]) > 0)
                return false;
            int m = (l + r) / 2;
            if (comparer.Compare(x, a[m]) == 0)
                return true;
            if (comparer.Compare(x, a[m]) < 0)
                return Find(a, x, l, m - 1, comparer);
            if (comparer.Compare(x, a[m]) > 0)
                return Find(a, x, m + 1, r, comparer);
            return false;
        }

        private class AdapterComparer<T> : IComparer<T>
        {
            private Comparison<T> comparison;

            public AdapterComparer(Comparison<T> comparison)
            {
                this.comparison = comparison;
            }
            public int Compare(T x, T y)
            {
                return this.comparison(x, y);
            }
        }
    }

}
