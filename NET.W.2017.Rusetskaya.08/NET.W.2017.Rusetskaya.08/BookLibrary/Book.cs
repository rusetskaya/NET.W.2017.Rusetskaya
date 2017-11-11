using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Book : IEqualityComparer, IComparable
    {
        public const double EPS = 0.001;
        private const int INITIALYEAR = 1500;
        private const int CURRENTYEAR = 2017; 

        #region Private fields
        private string isbn;
        private string author;
        private string name;
        private string publishingHouse;
        private int publishingYear;
        private int numberOfPages;
        private double price;
        #endregion

        #region Public constructors
        public Book()
        {
        }

        public Book(string isbn, string author, string name, string publishingHouse, int publishingYear, int numberOfPages, double price)
        {
            this.isbn = isbn;
            if (author.Length > 0)
            {
                this.author = author;
            }

            if (name.Length > 0)
            {
                this.name = name;
            }

            if (publishingHouse.Length > 0)
            {
                this.publishingHouse = publishingHouse;
            }

            if (publishingYear > INITIALYEAR && publishingYear <= CURRENTYEAR)
            {
                this.publishingYear = publishingYear;
            }

            if (numberOfPages > 0)
            {
                this.numberOfPages = numberOfPages;
            }

            if (price >= 0)
            {
                this.price = price;
            }
        }
        #endregion

        #region Public properties

        public string Isbn => isbn;

        public string Author => author;

        public string Name => name;

        public string PublishingHouse => publishingHouse;

        public int PublishingYear => publishingYear;

        public int NumberOfPages => numberOfPages;

        public double Price => price;

        #endregion      

        #region Public methods
        public override string ToString()
        {
            return Isbn + ' ' + author + ' ' + name + ' ' +
                publishingHouse + ' ' + publishingYear.ToString() + ' ' +
                numberOfPages.ToString() + ' ' + price.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            return this.Equals((Book)obj);
        }

        public bool Equals(Book book)
        {
            if (this.Isbn == book.Isbn &&
                this.Author == book.Author &&
                this.Name == book.Name &&
                this.PublishingHouse == book.PublishingHouse &&
                this.publishingYear == book.PublishingYear &&
                this.NumberOfPages == book.NumberOfPages &&
                this.Price - book.Price <= EPS)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public int CompareTo(object secondBook)
        {
            return Compare((Book)this, (Book)secondBook);
        }

        public int Compare(Book firstBook, Book secondBook)
        {
            if ((firstBook.Price - secondBook.Price < EPS) && (firstBook.Price - secondBook.Price > 0))
            {
                return 0;
            }

            if (firstBook.Price - secondBook.Price < 0)
            {
                return -1;
            }

            return 1;
        }

        public new bool Equals(object firstBook, object secondBook)
        {
            if (firstBook == null)
            {
                return false;
            }

            if (secondBook == null)
            {
                return false;
            }

            if (secondBook.GetType() != firstBook.GetType())
            {
                return false;
            }

            return firstBook.Equals(secondBook);
        }

        public int GetHashCode(object obj)
        {
            return this.GetHashCode();
        }
        #endregion
    }
}
