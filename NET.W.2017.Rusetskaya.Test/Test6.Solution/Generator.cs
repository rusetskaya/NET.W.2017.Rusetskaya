using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Test6.Solution
{
    public class Generator
    {
        public delegate T Count<T>(T prev, T curr);
        public static IEnumerable<T> GetNumbers<T>(int n, T a, T b, Count<T> rule)
        {
            T prev = a;
            T next = b;
            for (int i = 0; i < n; i++)
            {
                T sum = rule.Invoke(prev, next);
                prev = next;
                next = sum;
                yield return sum;
            }
        }

    }

    
    public class Count1<T> : ISum<T>
    {
        public T GetSum(T prev, T curr)
        {
            if (typeof(T) == typeof(int))
            {
                object sum = Convert.ToInt32(prev.ToString()) + Convert.ToInt32(curr.ToString());
                return (T)sum;
            }

            if (typeof(T) == typeof(double))
            {
                object sum = Convert.ToDouble(prev.ToString()) + Convert.ToDouble(curr.ToString());
                return (T)sum;
            }
             throw new Exception($"Format exception {typeof(T)}");
        }
    }

    public class Count2<T> : ISum<T>
    {
        public T GetSum(T prev, T curr)
        {
            if (typeof(T) == typeof(int))
            {
                object sum = 6 * Convert.ToInt32(curr.ToString()) - 8 * Convert.ToInt32(prev.ToString());
                return (T)sum;
            }

            if (typeof(T) == typeof(double))
            {
                object sum = 6 * Convert.ToDouble(curr.ToString()) + 8 * Convert.ToDouble(prev.ToString());
                return (T)sum;
            }
            throw new Exception($"Format exception {typeof(T)}");
        }
    }

    public class Count3<T> : ISum<T>
    {
        public T GetSum(T prev, T curr)
        {
            if (typeof(T) == typeof(int))
            {
                object sum = Convert.ToInt32(curr.ToString()) + Convert.ToInt32(prev.ToString())/ Convert.ToInt32(curr.ToString());
                return (T)sum;
            }

            if (typeof(T) == typeof(double))
            {
                object sum = Convert.ToDouble(curr.ToString()) + Convert.ToDouble(prev.ToString()) / Convert.ToInt32(curr.ToString());
                return (T)sum;
            }
            throw new Exception($"Format exception {typeof(T)}");
        }
    }

    public interface ISum<T>
    {
        T GetSum(T prev, T curr);
    }
}