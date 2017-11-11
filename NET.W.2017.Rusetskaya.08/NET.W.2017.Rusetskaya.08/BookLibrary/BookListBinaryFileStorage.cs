using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class BookListBinaryFileStorage : IBookListStorage
    {
        private const string FILENAME = "BookList.dat";

        public IEnumerable<Book> ReadFromStorage()
        {
            List<Book> bookList = new List<Book>();
            string isbn;
            string author;
            string name;
            string publishingHouse;
            int publishingYear;
            int numberOfPages;
            double price;

            using (BinaryReader reader = new BinaryReader(File.Open(FILENAME, FileMode.Open)))
            {
                ////while (reader.PeekChar() > -1) //PeekChar() create exc. if number of books>=3 "System.ArgumentException"
                ////(Буфер выходных символов не достаточен для хранения закодированных символов)
                {
                    isbn = reader.ReadString();
                    author = reader.ReadString();
                    name = reader.ReadString();
                    publishingHouse = reader.ReadString();
                    publishingYear = reader.ReadInt32();
                    numberOfPages = reader.ReadInt32();
                    price = reader.ReadDouble();
                    bookList.Add(new Book(isbn, author, name, publishingHouse, publishingYear, numberOfPages, price));
                }
            }

            return bookList;
        }

        public void WriteToStorage(IEnumerable<Book> bookList)
        {
            if (ReferenceEquals(bookList, null))
            {
                throw new ArgumentNullException(nameof(bookList));
            }

        using (BinaryWriter writer = new BinaryWriter(File.Open(FILENAME, FileMode.OpenOrCreate)))
            {
                foreach (Book book in bookList)
                {
                    writer.Write(book.Isbn);
                    writer.Write(book.Author);
                    writer.Write(book.Name);
                    writer.Write(book.PublishingHouse);
                    writer.Write(book.PublishingYear);
                    writer.Write(book.NumberOfPages);
                    writer.Write(book.Price);
                }
            }
        }
    }
}
