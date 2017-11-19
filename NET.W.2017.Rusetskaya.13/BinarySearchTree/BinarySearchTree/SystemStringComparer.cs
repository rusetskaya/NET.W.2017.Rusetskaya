using System;
using System.Collections.Generic;

namespace BinarySearchTree
{
    public class SystemStringComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            if (ReferenceEquals(x, null))
            {
                throw new ArgumentNullException(nameof(x));
            }

            if (ReferenceEquals(y, null))
            {
                throw new ArgumentNullException(nameof(y));
            }

            return x.Length.CompareTo(y.Length);
        }
    }
}