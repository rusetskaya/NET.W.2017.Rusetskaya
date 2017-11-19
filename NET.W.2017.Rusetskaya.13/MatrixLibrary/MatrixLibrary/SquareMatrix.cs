using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixLibrary
{
    public class SquareMatrix<T> : Matrix<T>
    {
        private T[,] array;
        private int dimension;

        public SquareMatrix()
        {
            array = new T[Dimension, Dimension];
        }

        public SquareMatrix(int size) : base(size)
        {
        }

        public SquareMatrix(int size, IEnumerable<T> input) : this(size)
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
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (tempIndex < input.Count())
                    {
                        array[i, j] = input.ElementAt(tempIndex);
                    }

                    tempIndex++;
                }
            }
        }

        protected override T GetElementOfMatrix(int i, int j)
        {
            ValidationOfIndexes(i, j);
            return array[i, j];
        }

        protected override void ChangeElementOfMatrix(T value, int i, int j)
        {
            ValidationOfIndexes(i, j);
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            array[i, j] = value;
        }
    }
}