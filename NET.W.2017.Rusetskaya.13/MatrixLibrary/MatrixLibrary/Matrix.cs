using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 Создать обобщенные классы для представления квадратной, 
 симметрической и диагональной матриц 
 (симметрическая матрица – это квадратная матрица, 
 которая совпадает с транспонированной к ней; 
 диагональная матрица – это квадратная матрица, 
 у которой элементы вне главной диагонали заведомо имеют значения по умолчанию типа элемента). 
 Описать в созданных классах событие, 
 которое происходит при изменении элемента матрицы с индексами (i, j).  
 Расширить функциональность существующей иерархии классов, 
 добавив возможность операции сложения двух матриц любого типа. 
 Разработать unit-тесты.
  */

namespace MatrixLibrary
{
    public abstract class Matrix<T> : IEnumerable<T>
    {
        private int dimension = 0;

        private T[,] array;

        protected Matrix()
        {
            array = new T[Dimension, Dimension];
        }

        protected Matrix(int size)
        {
            Dimension = size;
            array = new T[Dimension, Dimension];
        }

        public int Dimension
        {
            get => dimension;
            set => dimension = value;
        }

        protected abstract T GetElementOfMatrix(int i, int j);
        protected abstract void ChangeElementOfMatrix(T value, int i, int j);

        protected virtual void ValidationOfIndexes(int i, int j)
        {
            if (i < 0 || j < 0 || i >= Dimension || j >= Dimension )
            {
                throw new ArgumentOutOfRangeException($"{nameof(i)} {nameof(j)}");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 1; i <= Dimension; i++)
            {
                for (int j = 1; j <= Dimension; j++)
                {
                    ValidationOfIndexes(i, j);
                    yield return GetElementOfMatrix(i, j);
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
