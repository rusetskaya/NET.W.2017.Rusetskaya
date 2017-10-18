using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//2. Реализовать метод быстрой сортировки для целочисленного массива. 

namespace LogicQuickSort
{
    public static class QuickSortAlgorithm
    {
        public static void Quicksort(int[] array, int left, int right)
        {
            int i = left, j = right;
            int mid = array[(left + right) / 2];

            while (i <= j)
            {
                while (array[i].CompareTo(mid) < 0)
                {
                    i++;
                }

                while (array[j].CompareTo(mid) > 0)
                {
                    j--;
                }

                if (i <= j)
                {
                    Swap(array, i, j);
                    i++;
                    j--;
                }
            }
            
            if (left < j)
            {
                Quicksort(array, left, j);
            }

            if (i < right)
            {
                Quicksort(array, i, right);
            }
        }

        public static void Swap(int[] array, int i, int j) {
            int tmp = array[i];
            array[i] = array[j];
            array[j] = tmp;
        }

    }
}
