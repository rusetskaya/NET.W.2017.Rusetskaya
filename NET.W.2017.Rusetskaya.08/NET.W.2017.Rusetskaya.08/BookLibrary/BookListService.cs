using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BookLibrary.Book;

namespace BookLibrary
{
    public class BookListService
    {
       private const double EPS = 0.001;
       private List<Book> bookList = new List<Book>();

       public interface IFinder
        {
            Book Find(List<Book> books);
        }

        public interface IComparer
        {
           dynamic Compare(Book lhs, Book rhs);
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            bookList.Add(book);
        }

        public void AddBook(params Book[] books)
        {
            foreach (Book book in books)
            {
                if (ReferenceEquals(book, null))
                {
                    throw new ArgumentNullException(nameof(books));
                }
            }

            bookList.AddRange(books);
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                throw new ArgumentNullException(nameof(book));
            }

            bookList.Remove(book);
        }

        public void RemoveBook(int isbn)
        {
            for (int i = 0; i < bookList.Count; i++)
            {
                if (bookList[i].Isbn.Equals(isbn))
                {
                    bookList.Remove(bookList[i]);
                    break;
                }
            }
        }

        public Book FindBookByTag(IFinder tagFinder)
        {
            if (ReferenceEquals(bookList, null))
            {
                throw new ArgumentNullException(nameof(bookList));
            }

            if (ReferenceEquals(tagFinder.Find(bookList), null) == false)
            {
                return tagFinder.Find(bookList);
            }

            return null;
        }

        public void SortBooksByTag(IComparer comparer)
        {
            if (ReferenceEquals(bookList, null))
            {
                throw new ArgumentNullException(nameof(bookList));
            }

            for (int i = 0; i < bookList.Count - 1; i++)
            {
               if (comparer.Compare(bookList[i], bookList[i + 1]) > 0)
               {
                   Book temp = bookList[i];
                   bookList[i] = bookList[i + 1];
                   bookList[i + 1] = temp;
                }
            }
        }

        public void SetBookListToStorage(IBookListStorage storage)
        {
            storage.WriteToStorage(bookList);
        }

        public void GetBookListFromStorage(IBookListStorage storage)
        {
            IEnumerable<Book> bookList = storage.ReadFromStorage();
            foreach (Book book in bookList)
            {
                this.AddBook(book);
            }
        }

        public List<Book> GetBookList()
        {
            return bookList;
        }

        public void ShowBookList()
        {
            Console.WriteLine();
            foreach (Book book in bookList)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
        }
    }
}
