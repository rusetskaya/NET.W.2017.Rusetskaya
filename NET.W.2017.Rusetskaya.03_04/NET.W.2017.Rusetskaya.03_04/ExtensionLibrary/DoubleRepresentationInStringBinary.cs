using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionLibrary
{
    //!!!!!!!!!! Переделать с пом. битовых операций + тесты (после дедлайна 25.10 18.00)
    public static class DoubleRepresentationInStringBinary
    {
        public static string DoubleToStringFormatIEEE754(double number)
        {
            var bitArray = new System.Collections.BitArray(BitConverter.GetBytes(number));
            StringBuilder res = new StringBuilder(64);

            for (int i = bitArray.Length - 1; i >= 0; i--)
            {
                if (bitArray[i] == false)
                    res.Append('0');
                else
                    res.Append('1');
            }

            return res.ToString();
        }
    }
}
