using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegerLibrary
{
    public static class GreatestCommonDivisor
    {
        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Tuple with gcd and time</returns>
        #region Public Euclids Algorithm Methods
        public static Tuple<int, int> EuclidsAlgorithm(params int[] numbers)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int tempGCD = EuclidsAlgorithm(numbers[0], numbers[1]).Item1;
            for (int i = 3; i < numbers.Length; i++)
            {
                tempGCD = EuclidsAlgorithm(tempGCD, numbers[i]).Item1;
            }

            stopWatch.Stop();
            int resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
            return Tuple.Create(tempGCD, resultTime);
        }

        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns>Tuple with gcd and time</returns>
        public static Tuple<int, int> EuclidsAlgorithm(int first, int second, int third)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int tempGCD = EuclidsAlgorithm(EuclidsAlgorithm(first, second).Item1, third).Item1;
            stopWatch.Stop();
            int resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
            return Tuple.Create(tempGCD, resultTime);
        }

        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Tuple with gcd and time</returns>
        public static Tuple<int, int> EuclidsAlgorithm(int first, int second)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int resultTime;
            if (Validation(first, second) == 0)
            {
                first = Math.Abs(first);
                second = Math.Abs(second);
            }

            if (Validation(first, second) == 1)
            {
                if (first == 0)
                {
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(second, resultTime);
                }

                if (second == 0)
                {
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(first, resultTime);
                }

                while (first != second)
                {
                    if (first > second)
                    {
                        first = first - second;
                    }
                    else
                    {
                        second = second - first;
                    }
                }

                stopWatch.Stop();
                resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                return Tuple.Create(first, resultTime);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(first));
            }
        }

        #endregion

        #region Public Steins Algorithm Methods
        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns>Tuple with gcd and time</returns>
        public static Tuple<int, int> SteinsAlgorithm(params int[] numbers)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int tempGCD = SteinsAlgorithm(numbers[0], numbers[1]).Item1;
            for (int i = 3; i < numbers.Length; i++)
            {
                tempGCD = SteinsAlgorithm(tempGCD, numbers[i]).Item1;
            }

            stopWatch.Stop();
            int resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
            return Tuple.Create(tempGCD, resultTime);
        }

        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <param name="third"></param>
        /// <returns>Tuple with gcd and time</returns>
        public static Tuple<int, int> SteinsAlgorithm(int first, int second, int third)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            int tempGCD = SteinsAlgorithm(SteinsAlgorithm(first, second).Item1, third).Item1;
            stopWatch.Stop();
            int resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
            return Tuple.Create(tempGCD, resultTime);
        }

        /// <summary>
        /// Counts Greatest Common Divisor
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns>Tuple with gcd and time</returns>
        public static Tuple<int, int> SteinsAlgorithm(int first, int second)
        {
            int resultTime = 0;
            int tempGCD;
            Stopwatch stopWatch = Stopwatch.StartNew();
            if (Validation(first, second) == 0)
            {
                first = Math.Abs(first);
                second = Math.Abs(second);
            }

            if (Validation(first, second) == 1)
            {
                if (first == second)
                {
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(first, resultTime);
                }

                if (first == 0)
                {
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(second, resultTime);
                }

                if (second == 0)
                {
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(first, resultTime);
                }

                if ((~first & 1) != 0)
                {
                    if ((second & 1) != 0)
                    {
                        tempGCD = SteinsAlgorithm(first >> 1, second).Item1;
                        stopWatch.Stop();
                        resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                        return Tuple.Create(tempGCD, resultTime);
                    }
                    else
                    {
                        tempGCD = SteinsAlgorithm(first >> 1, second >> 1).Item1 << 1;
                        stopWatch.Stop();
                        resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                        return Tuple.Create(tempGCD, resultTime);
                    }
                }

                if ((~second & 1) != 0)
                {
                    tempGCD = SteinsAlgorithm(first, second >> 1).Item1;
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(tempGCD, resultTime);
                }

                if (first > second)
                {
                    tempGCD = SteinsAlgorithm((first - second) >> 1, second).Item1;
                    stopWatch.Stop();
                    resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                    return Tuple.Create(tempGCD, resultTime);
                }

                tempGCD = SteinsAlgorithm((second - first) >> 1, first).Item1;
                stopWatch.Stop();
                resultTime = (int)((stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency);
                return Tuple.Create(tempGCD, resultTime);
            }
            else
            {
                throw new ArgumentOutOfRangeException(nameof(first));
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validate
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns> -1 if invalid
        ///            1 if valid
        ///            0 if should be Abs
        /// </returns>
        private static int Validation(int first, int second) ////Будет возвращать только -1, 0, 1  как результат проверки
        {
            int valid = 1;
            int invalid = -1;
            int needAbs = 0;
            if (first == 0 && second == 0)
            {
                return invalid;
            }
            else
            {
                if (first < 0 || second < 0)
                {
                    return needAbs;
                }
                else
                {
                    return valid;
                }
            }
        }
        #endregion
    }
}
