using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MatrixLibrary
{
    public class SymmetricMatrix<T> : Matrix<T>
    {
        private T[][] array;

        public SymmetricMatrix()
        {
            array = new T[Dimension][];
            for (int i = 0; i < Dimension; i++)
            {
                array[i] = new T[i+1];
            }
        }

        public SymmetricMatrix(int size)
        {
            Dimension = size;
            array = new T[Dimension][];
            for (int i = 0; i < Dimension; i++)
            {
                array[i] = new T[i + 1];
            }
        }

        public SymmetricMatrix(int size, IEnumerable<T> input)
            : this(size)
        {
            Fill(input);
        }

        private void Fill(IEnumerable<T> input)
        {
            if (ReferenceEquals(input, null))
            {
                throw new ArgumentNullException(nameof(input));
            }

            int tempIndex = 0;
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (tempIndex < input.Count())
                    {
                        array[i][j] = input.ElementAt(tempIndex);
                    }

                    tempIndex++;
                }
            }
        }

        protected override T GetElementOfMatrix(int i, int j)
        {
            ValidationOfIndexes(i, j);
            if (j <= i)
            {
                return array[i][j];
            }
            else
            {
                return array[j][i];
            }
        }

        protected override void ChangeElementOfMatrix(T value, int i, int j)
        {
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            ValidationOfIndexes(i, j);
            if (j <= i)
            {
                array[i][j] = value;
            }
            else
            {
                array[j][i] = value;
            }
        }
    }
}