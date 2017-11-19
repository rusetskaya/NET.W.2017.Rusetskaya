using System.Collections.Generic;

namespace BinarySearchTree
{
    public class PointComparer : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return (x.X * x.Y).CompareTo(y.X * y.Y);
        }
    }
}