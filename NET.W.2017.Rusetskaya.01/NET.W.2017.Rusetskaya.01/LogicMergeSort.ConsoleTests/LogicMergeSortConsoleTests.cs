using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LogicMergeSort.MergeSortAlgorithm;

namespace LogicMergeSort.ConsoleTests
{
    class LogicMergeSortConsoleTests
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 2, 5, 1, -1, 8 };

            Console.WriteLine(ShowArray(array));
            MergeSort(array);
            Console.WriteLine(ShowArray(array));
            Console.ReadLine();
        }

        public static string ShowArray(int[] array)
        {
            string result = String.Empty;

            for (int i = 0; i < array.Length; i++)
            {
                result += array[i] + " ";
            }
            if (array.Length == 0)
            {
                return "Array is empty";
            }
            else
            {
                return result;
            }
        }

    }
}
