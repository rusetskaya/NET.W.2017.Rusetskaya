using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Test6.Solution
{
    public class Generator
    {
        public static IEnumerable<T> GetNumbers<T>(int n, T a, T b, Func<T, T, T> rule)
        {
            T prev = a;
            yield return prev;
            T next = b;
            yield return next;
            for (int i = 3; i < n; i++)
            {
                T sum = rule(next, prev);
                yield return sum;
                prev = next;
                next = sum;
            }
        }

    }

    
    public class Count1 : ISum<int>
    {
        public int GetSum(int curr, int prev) => curr + prev;
    }

    public class Count2 : ISum<int>
    {
        public int GetSum(int curr, int prev) => 6 * curr + 8 * prev;
    }

    public class Count3 : ISum<double>
    {
        public double GetSum(double curr, double prev) => curr + prev / curr;
    }

    public interface ISum<T>
    {
        T GetSum(T curr, T prev);
    }
}