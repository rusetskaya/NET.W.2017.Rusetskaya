using System;
using System.Collections.Generic;
using System.Diagnostics;
using Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static Fibonacci.Logic;

namespace FibonacciTest
{
    [TestClass]
    public class FibonacciMethodTest
    {
        [TestMethod]
        public void Is_For_6_is_0_1_1_2_3_5_8()
        {
            bool temp;
            int i = 0;
            List<int> list = new List<int>() {0, 1, 1, 2, 3, 5, 8 };
            foreach (var fib in GetFibonacciNumbers(7))
            {
                temp = (fib == list[i]);
                i++;
                Debug.WriteLine(temp);
            }
        }
    }
}
