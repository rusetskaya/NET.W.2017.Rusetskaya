using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static IntegerLibrary.SpecialIntegerLogic;
using NUnit.Framework;

namespace IntegerLibrary.Tests
{
    public class IntegerLibraryTests
    {
        [TestCase(12, ExpectedResult = 21)]
        [TestCase(513, ExpectedResult = 531)]
        [TestCase(2017, ExpectedResult = 2071)]
        [TestCase(414, ExpectedResult = 441)]
        [TestCase(144, ExpectedResult = 414)]
        [TestCase(1234321, ExpectedResult = 1241233)]
        [TestCase(1234126, ExpectedResult = 1234162)]
        [TestCase(3456432, ExpectedResult = 3462345)]
        [TestCase(10, ExpectedResult = -1)]
        [TestCase(20, ExpectedResult = -1)]

        public long NextBiggerNumberTest(long actual)
        {
            return NextBiggerNumber(actual);
        }
    }
}




//namespace IntegerLibrary.Tests

//{

//    [TestFixture]

//    public class NUnitTests

//    {

//        [Test]

//        public void SumOfTwoNumbers()

//        {

//            Assert.AreEqual(10, 5 + 5);

//        }



//        [Test]

//        public void AreTheValuesTheSame()

//        {

//            Assert.AreSame(10, 5 + 6);

//        }

//    }

//}
