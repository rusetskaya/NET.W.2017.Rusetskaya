using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit;
using NUnit.Framework;
using NUnit.Framework.Internal.Commands;
using static BookLibrary.Book;

namespace BookLibrary.Tests
{
    [TestFixture]
    public class BookLibraryTests
    {
        [TestCase("ANT", ExpectedResult = "Jeffrey Richter, CLR via C#")]
        [TestCase("ANTPY", ExpectedResult = "Jeffrey Richter, CLR via C#, Microsoft Press, 2012")]
        [TestCase("IFIANTPYPP", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter,CLR via C#, Microsoft Press, 2012, P. 826")]
        [TestCase("IFIANTPYPPP", ExpectedResult = "ISBN 13: 978-0-7356-6745-7, Jeffrey Richter,CLR via C#, Microsoft Press, 2012, P. 826, 59,99 $")]
        public string FormatterTest(string format)
        {
            Book book = new Book("978-0-7356-6745-7", "Jeffrey Richter", "CLR via C#", "Microsoft Press", 2012, 826, 59.99);
            return book.ToString(format);
        }
    }
}
