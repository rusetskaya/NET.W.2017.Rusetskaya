using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLibrary
{
    public static class BinarySearchAlgorithm
    {
        public static bool? BinarySearch<T>(T[] array, T key, IComparer<T> comparer)
        {
            if (ReferenceEquals(array, null))
            {
                throw new ArgumentNullException($"{nameof(array)} is null");
            }

            if (ReferenceEquals(comparer, null))
            {
                comparer = Comparer<T>.Default;
            }

            return Search(array, key, comparer);
        }

        public static bool? BinarySearch<T>(T[] array, T key, Comparison<T> comparison)
        {
            return BinarySearch(array, key, new AdapterComparer<T>(comparison));
        }

        private static bool? Search<T>(T[] array, T key, IComparer<T> comparer)
        {
            return Search(array, key, 0, array.Length - 1, comparer);
        }

        private static bool? Search<T>(T[] array, T key, int lhs, int rhs, IComparer<T> comparer)
        {
            if (array.Length == 0 || comparer.Compare(key, array[lhs]) < 0 || comparer.Compare(key, array[rhs]) > 0)
                return false;
            int mid = (lhs + rhs) / 2;
            if (comparer.Compare(key, array[mid]) == 0)
                return true;
            if (comparer.Compare(key, array[mid]) < 0)
            {
                return Search(array, key, lhs, mid - 1, comparer);
            }
            if (comparer.Compare(key, array[mid]) > 0)
            {
                return Search(array, key, mid + 1, rhs, comparer);
            }
            return null;
        }
    }

}