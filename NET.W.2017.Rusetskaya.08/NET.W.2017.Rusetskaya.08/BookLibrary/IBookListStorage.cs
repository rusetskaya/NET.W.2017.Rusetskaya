using System.Collections.Generic;

namespace BookLibrary
{
    public interface IBookListStorage
    {
        IEnumerable<Book> ReadFromStorage();

        void WriteToStorage(IEnumerable<Book> bookList);
    }
}