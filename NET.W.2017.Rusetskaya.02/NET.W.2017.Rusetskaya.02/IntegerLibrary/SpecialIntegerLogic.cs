using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace IntegerLibrary
{
    public static class SpecialIntegerLogic
    {
        #region NextBiggerNumberMethods

        public static Tuple<long, int> NextBiggerNumberAndTime(long number)
        {
            DateTime Start;
            DateTime Stoped;
            TimeSpan Elapsed = new TimeSpan();
            Start = DateTime.Now;

            long nextNumber = NextBiggerNumber(number);

            Stoped = DateTime.Now;
            Elapsed = Stoped.Subtract(Start);
            int timeInMSec = (int)Elapsed.TotalMilliseconds;
            int timeInSec = Elapsed.Seconds;
            return Tuple.Create(nextNumber, timeInSec);

        }

        public static long NextBiggerNumber(long number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(number));
            }
            if (IsNumberDecrease(number))
            {
                return -1;
            }

            string sNumber = ToSortedString(number);
            long nextNumber = ++number;
            string sNext = ToSortedString(nextNumber);
            while (sNumber != sNext)
            {
                sNext = ToSortedString(++nextNumber);
            }

            return nextNumber;

        }

        public static long NextBiggerNumber(long number, out object time)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();
            long resultNumber = NextBiggerNumber(number);
            stopWatch.Stop();
            time = (stopWatch.ElapsedTicks * 1000.0) / Stopwatch.Frequency;
            return resultNumber;
        }

        private static bool IsNumberDecrease(long number)
        {
            int prevDigit = (int)number % 10;
            int nextDigit = 0;
            number = number / 10;

            while (number != 0)
            {
                nextDigit = (int)number % 10;
                if (prevDigit > nextDigit)
                {
                    return false;
                }
                number = number / 10;
                prevDigit = nextDigit;

            }
            return true;
        }
        private static string ToSortedString(long number)
        {
            char[] array = number.ToString().ToCharArray();
            Array.Sort(array);
            return new String(array);
        }
        #endregion
    }
}
