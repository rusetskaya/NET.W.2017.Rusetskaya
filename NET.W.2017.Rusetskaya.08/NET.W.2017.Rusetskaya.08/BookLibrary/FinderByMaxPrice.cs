using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.BookListService;

namespace BookLibrary
{
    public class FinderByMaxPrice : IFinder
    {
        public Book Find(List<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                throw new ArgumentNullException(nameof(books));
            }

            double tempPrice = books[0].Price;
            Book resultBook = books[0];
            for (int i = 1; i < books.Count; i++)
            {
                if (books[i].Price >= tempPrice)
                {
                    tempPrice = books[i].Price;
                    resultBook = books[i];
                }
            }

            return resultBook;
        }
    }
}
