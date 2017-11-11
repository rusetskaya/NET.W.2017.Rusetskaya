using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookLibraryRunner
{
    public class BookRunner
    {
        private static void Main(string[] args)
        {
            Book[] books = 
            {
                new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99),
                new Book("1678995", "author2", "name2", "publishingHouse2", 2016, 500, 30.151),
                new Book("234577777", "author3", "name3", "publishingHouse3", 2014, 500, 30.15),
                new Book("234577777", "author3", "name3", "publishingHouse3", 2014, 500, 30.15)
            };

            Console.WriteLine(books[0].ToString("ANT"));
            Console.WriteLine(books[0].ToString("IFIANTPYPP"));
            Console.WriteLine(books[0].ToString("ANTPY"));
            Console.WriteLine(books[0].ToString("IFIANTPYPPP"));          
            BookListService service = new BookListService();
            ////service.AddBook(books[0],books[1]);
            service.AddBook(books[0]);
            service.AddBook(books[1]);
            service.AddBook(books[2]);
            service.AddBook(books[3]);
            Console.WriteLine("Are equal: " + Equals(service.GetBookList()[0], service.GetBookList()[1]));
            Console.WriteLine("Are equal: " + Equals(service.GetBookList()[2], service.GetBookList()[3]));
            Console.WriteLine(service.FindBookByTag(new FinderByMaxPrice()));
            Console.WriteLine(service.FindBookByTag(new FinderByMinPrice()));
            Console.WriteLine(service.FindBookByTag(new FinderByPublishingYearAndAuthor(2016, "author3")));
            service.SortBooksByTag(new ComparerByDecPrice());
            service.ShowBookList();
            service.SortBooksByTag(new ComparerByDecPublishingYear());
            service.ShowBookList();
            service.SortBooksByTag(new ComparerByIncPrice());
            service.ShowBookList();
            service.RemoveBook(books[2]);
            service.ShowBookList();
            service.RemoveBook(1678995);
            service.ShowBookList();
            Console.WriteLine("Write to binary file");
            IBookListStorage binaryStorage = new BookListBinaryFileStorage();
            service.SetBookListToStorage(binaryStorage);
            Console.WriteLine("Read from binary file");
            BookListService newService = new BookListService();
            newService.GetBookListFromStorage(binaryStorage);
            for (int i = 0; i < newService.GetBookList().Count; i++)
            {
                Console.WriteLine(newService.GetBookList()[i]);
            }
            
            Console.ReadLine();
        }
    }
}
