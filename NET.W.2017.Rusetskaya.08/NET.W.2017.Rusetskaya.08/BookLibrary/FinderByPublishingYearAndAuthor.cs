using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.BookListService;

namespace BookLibrary
{
    public class FinderByPublishingYearAndAuthor : IFinder
    {
        private string author;
        private int publishingYear;

        public FinderByPublishingYearAndAuthor(int publishingYear, string author)
        {
            this.author = author;
            this.publishingYear = publishingYear;
        }

        
        public Book Find(List<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                throw new ArgumentNullException(nameof(books));
            }

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].PublishingYear == publishingYear && books[i].Author == author)
                {
                    return books[i];
                }
            }
            return null;
        }
    }
}
