using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.BookListService;

namespace BookLibrary
{
    public class ComparerByDecPublishingYear : IComparer
    {
        public dynamic Compare(Book lhs, Book rhs)
        {
            return rhs.PublishingYear - lhs.PublishingYear;
        }
    }
}
