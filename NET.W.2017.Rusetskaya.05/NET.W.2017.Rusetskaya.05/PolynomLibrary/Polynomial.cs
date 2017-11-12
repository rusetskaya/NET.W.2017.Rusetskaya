using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolynomLibrary
{
    public class Polynomial : ICloneable
    {
        private static int power;
        private double[] coefficients = new double[power];

        #region Constrs
        public Polynomial(double[] array)
        {
            power = array.Length - 1;
            ////for (int i = 0; i < power; i++)
            ////    Сoefficients[i] = array[i];
            Сoefficients = array;
        }

        ~Polynomial()
        {
            //// Do unmanaged resource clean up

            Console.WriteLine("Is destructor");
        }
        #endregion

        #region Props
        private double[] Сoefficients
        {
            get
            {
                return coefficients;
            }

            set
            {
                coefficients = value;
            }
        }

        private int Power
        {
            get
            {
                return power;
            }

            set
            {
                power = value;
            }
        }
        #endregion
        
        #region Public Methods
        
        #region Overrided operations
        public static Polynomial operator +(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (Validation(firstPolinom, secondPolinom) == true)
            {
                int resultPower = CountResultPower(firstPolinom.Power, secondPolinom.Power);
                double[] arrayResult = new double[resultPower];

                for (int i = 0; i < resultPower; i++)
                {
                    if (i >= firstPolinom.coefficients.Length)
                    {
                        arrayResult[i] += secondPolinom.coefficients[i];
                        continue;
                    }

                    if (i >= secondPolinom.coefficients.Length)
                    {
                        arrayResult[i] += firstPolinom.coefficients[i];
                        continue;
                    }

                    arrayResult[i] = firstPolinom.coefficients[i] + secondPolinom.coefficients[i];
                }

                return new Polynomial(arrayResult);
            }
            else
            {
                throw new ArgumentNullException(nameof(firstPolinom));
            }
        }

        // Перегружаем бинарный оператор - 
        public static Polynomial operator -(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (Validation(firstPolinom, secondPolinom) == true)
            {
                int resultPower = CountResultPower(firstPolinom.Power, secondPolinom.Power);
                double[] arrayResult = new double[resultPower];

                for (int i = 0; i < resultPower; i++)
                {
                    if (i >= firstPolinom.coefficients.Length)
                    {
                        arrayResult[i] -= secondPolinom.coefficients[i];
                        continue;
                    }

                    if (i >= secondPolinom.coefficients.Length)
                    {
                        arrayResult[i] += firstPolinom.coefficients[i];
                        continue;
                    }

                    arrayResult[i] = firstPolinom.coefficients[i] - secondPolinom.coefficients[i];
                }

                return new Polynomial(arrayResult);
            }
            else
            {
                throw new ArgumentNullException(nameof(firstPolinom));
            }
        }

        public static Polynomial operator *(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (Validation(firstPolinom, secondPolinom) == true)
            {
                int resultPower = firstPolinom.Power + secondPolinom.Power + 1;
                double[] arrayResult = new double[resultPower];

                for (int i = 0; i < firstPolinom.coefficients.Length; i++)
                {
                    for (int j = 0; j < secondPolinom.coefficients.Length; j++)
                    {
                        arrayResult[i + j] += firstPolinom.coefficients[i] * secondPolinom.coefficients[j];
                    }
                }

                return new Polynomial(arrayResult);
            }
            else
            {
                throw new ArgumentNullException(nameof(firstPolinom));
            }
        }

        public static bool operator ==(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return firstPolinom.Equals(secondPolinom);
        }

        public static bool operator !=(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            return !firstPolinom.Equals(secondPolinom);
        }
        #endregion

        public object Clone()
        {
            return new Polynomial(coefficients);
            ////return (Polynomial)MemberwiseClone();
        }

        #region Overrided Objects virtual methods
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Polynomial polinom = obj as Polynomial;
            if (polinom as Polynomial == null)
            {
                return false;
            }

            return polinom.Power == Power && polinom.coefficients.SequenceEqual(coefficients);
        }

        public bool Equals(Polynomial polinom)
        {
            if (ReferenceEquals(polinom, null))
            {
                return false;
            }

            return polinom.Power == Power && polinom.coefficients.SequenceEqual(coefficients);
        }

        public override int GetHashCode()
        {
            int code = (int)coefficients.Sum();
            return Power + code;
        }

        public override string ToString()
        {
            string result = string.Empty;
            for (int i = 0; i < coefficients.Length; i++)
            {
                string sign;

                if (coefficients[i] < 0)
                {
                    sign = string.Empty;
                }
                else
                {
                    sign = "+";
                }

                result += sign + coefficients[i].ToString() + "x^" + i.ToString();
            }

            if (result[0] == '+')
            {
                result = result.Substring(1);
            }

            return result.ToString();
        }

        /*
        //protected override void Finalize()
        //{
        //    // Do unmanaged resource clean up
        //}
        */

        ////Перегружаем бинарный оператор +
        #endregion

        #endregion

        #region Private methods
        private static bool Validation(Polynomial firstPolinom, Polynomial secondPolinom)
        {
            if (ReferenceEquals(firstPolinom, null) || ReferenceEquals(secondPolinom, null))
            {
                return false;
            }

            if (ReferenceEquals(firstPolinom, null) && ReferenceEquals(secondPolinom, null))
            {
                return false;
            }
            else 
            {
                return true;
            }
        }

        private static int CountResultPower(int firstPower, int secondPower)
        {
            int resultPower = (firstPower >= secondPower) ? firstPower + 1 : secondPower + 1;
            return resultPower;
        }
        #endregion
    }
}
