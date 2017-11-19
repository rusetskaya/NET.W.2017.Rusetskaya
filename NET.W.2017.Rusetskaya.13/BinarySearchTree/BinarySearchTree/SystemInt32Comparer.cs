using System.Collections.Generic;

namespace BinarySearchTree
{
    public class SystemInt32Comparer : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return (x % 2).CompareTo(y % 2);
        }
    }
}