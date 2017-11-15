using System;
using System.Collections.Generic;

namespace BinarySearchLibrary
{
    public class AdapterComparer<T> : IComparer<T>
    {
        private Comparison<T> comparison;

        public AdapterComparer(Comparison<T> comparison)
        {
            this.comparison = comparison;
        }
        public int Compare(T x, T y)
        {
            return this.comparison(x, y);
        }
    }
}