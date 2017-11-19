using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixLibrary
{
    public class DiagonalMatrix<T> : Matrix<T>
    {
        private T[] array;

        public DiagonalMatrix()
        {
            array = new T[Dimension];
        }

        public DiagonalMatrix(int size)
        {
            Dimension = size;
            array = new T[Dimension];
        }

        public DiagonalMatrix(int size, IEnumerable<T> inputDiag)
            : this(size)
        {
            Fill(inputDiag);
        }

        private void Fill(IEnumerable<T> inputDiag)
        {
            if (ReferenceEquals(inputDiag, null))
            {
                throw new ArgumentNullException(nameof(inputDiag));
            }

            int tempIndex = 0;
            for (int i = 0; i < Dimension; i++)
            {
                if (tempIndex < inputDiag.Count())
                {
                    array[i] = inputDiag.ElementAt(tempIndex);
                }

                tempIndex++;
            }
        }

        protected override T GetElementOfMatrix(int i, int j)
        {
            ValidationOfIndexes(i, j);
            if (i == j)
            {
                return array[i];
            }
            else
            {
                return default(T);
            }
        }

        protected override void ChangeElementOfMatrix(T value, int i, int j)
        {
            ValidationOfIndexes(i, j);
            if (ReferenceEquals(value, null))
            {
                throw new ArgumentNullException(nameof(value));
            }

            if (i != j && !value.Equals(default(T)))
            {
                throw new Exception("The el-t not in diag");
            }

            array[i] = value;
        }
    }
}