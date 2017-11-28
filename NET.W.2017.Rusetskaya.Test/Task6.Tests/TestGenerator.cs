using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Test6.Solution;
using static Test6.Solution.Generator;

namespace Task6.Tests
{
    [TestFixture]
    public class TestGenerator
    {
        [Test]
        public void Is_For_6_is_1_1_2_3_5_8_13_21()
        {
            bool temp;
            int i = 0;
            Count1<int> counter = new Count1<int>();
            List<int> list = new List<int>() {2, 3, 5, 8 , 13, 21};
            foreach (var fib in GetNumbers(6, 1, 1, counter.GetSum))
            {
                temp = (fib == list[i]);
                i++;
                Debug.WriteLine(fib);
            }
        }

        
    }
}