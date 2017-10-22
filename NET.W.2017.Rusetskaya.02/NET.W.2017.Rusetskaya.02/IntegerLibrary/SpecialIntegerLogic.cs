using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Collections;

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

        #region InsertNumberMethods
        public static int InsertNumber(int numberSource, int numberIn, int i, int j)
        {
            var arrays = ConvertForBitArray(numberSource, numberIn);
            BitArray arraySource =  new BitArray(arrays.Item1);
            BitArray arrayIn = new BitArray(arrays.Item2);
            arraySource = Reverse(arraySource);
            arrayIn =Reverse(arrayIn);
            for (int k = 0; k <= (j-i); k++)
            {
                arraySource[k+i] = arrayIn[k];
            }
            arraySource = Reverse(arraySource);
            arrayIn = Reverse(arrayIn);

            return GetIntFromBitArray(arraySource);
        }
        public static BitArray Reverse(BitArray array)
        {
            BitArray temp = new BitArray(array.Count);
            for (int i = 0; i < array.Count; i++)
            {
                temp[i] = array[array.Count - i - 1];
            }
            array = new BitArray(temp);
            return array;
        }
        public static int GetIntFromBitArray(BitArray bitArray)
        {
            if (bitArray.Count> 32)
                throw new ArgumentException("Argument length shall be at most 32 bits.");

            int value = 0;
            for (int i = 31; i >=0 ; i--)
            {
                if (bitArray[Math.Abs(i -31)])
                    value += Convert.ToInt32(Math.Pow(2, i));
            }

            return value;
        }

        public static Tuple<BitArray, BitArray> ConvertForBitArray(int numberSource, int numberIn)
        {
            BitArray arraySource = new BitArray(GetBinaryRepresentation(numberSource));
            BitArray arrayIn = new BitArray(GetBinaryRepresentation(numberIn));
            return Tuple.Create(arraySource, arrayIn);
        }
        public static bool[] GetBinaryRepresentation(int number)
        {
            //List<bool> result = new List<bool>();
            bool[] result = new bool[32];
            int i = 0;
            while (number > 0)
            {
                int remainder = number % 2;
                number = number / 2;
                result[i] = (remainder == 1);
                i++;
            }
            Array.Reverse(result);
            while (result.Length != 32)
            {
                result[i] = false;
                i++;
            }
            return result;
            //return result.ToArray();
        }
        #endregion

        #region FindNthRootMethods
        public static double FindNthRoot(double number, int degree, double precision)
        {
            if ((precision < 0) || (degree < 0))
            {
                throw new ArgumentOutOfRangeException("Incorrect precision.");
            }
            double supposition = Math.Round((number / degree),6);
            double result = supposition;
            result = ((degree - 1) * result + (number / Math.Pow(result, degree - 1))) / degree;
            while (Math.Abs(result - supposition) > precision)
            {
                supposition = result;
                result = ((degree - 1) * result + (number / Math.Pow(result, degree - 1))) / degree;
            }

            int accuracy = 1;
            double tempPrecision = precision;
            while (tempPrecision < 1)
            {
                accuracy *= 10;
                tempPrecision *= 10;
            }

            return Math.Floor((result * accuracy + 0.1)) / accuracy;
        }
        #endregion

        #region FilterDigitMethods
        public static int[] FilterDigit(int digit, params int[] list)
        {
            if (digit / 10 != 0 || digit<0)
            {
                throw new ArgumentOutOfRangeException(nameof(digit));
            }

            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            List<int> result = new List<int>();

            foreach (int number in list)
            {
                if (IsDigitInList(number, digit))
                {
                    result.Add(number);
                }
            }

            return result.ToArray();
        }

        public static bool IsDigitInList(int number, int digit)
        {
            if (number == 0 && digit == 0)
            {
                return true;
            }
            while (number > 0)
            {
                if (number % 10 == digit)
                    return true;
                number /= 10;
            }
            return false;
        }
        #endregion
    }
}
