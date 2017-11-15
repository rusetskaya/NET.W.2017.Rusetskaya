using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class Logic
    {
        public static IEnumerable<int> GetFibonacciNumbers(int n)
        {
            int prev = -1;
            int next = 1;
            for (int i = 0; i < n; i++)
            {
                int sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}
