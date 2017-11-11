using System;
using System.Globalization;

namespace BookLibrary
{
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        private Book book = null;

        public object GetFormat(Type formatType)
        {
            return formatType == typeof(ICustomFormatter) ? this : null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            book = (Book)arg;
            string thisFmt = string.Empty;
            CultureInfo ci = new CultureInfo("en-US");
            //if (!string.IsNullOrEmpty(format))
            //{
            //    thisFmt = format.Length > 1 ? format.Substring(0, 1) : format;
            //}
            thisFmt = format;

            switch (thisFmt.ToUpper())
            {
                ////AuthorNameTitle
                case "ANT":
                    return $"{book.Author}, {book.Name}";
                ////AuthorNameTitlePublisherYear
                case "ANTPY":
                    return $"{book.Author}, {book.Name}, {book.PublishingHouse}, {book.PublishingYear}";
                ////ISBN + it's format: + IsbnAuthorNameTitlePublisherYear + P. + Pages
                case "IFIANTPYPP":
                    return $"ISBN {CountIsbnLength(book.Isbn)}: {book.Isbn}, {book.Author}," +
                           $"{book.Name}, {book.PublishingHouse}, {book.PublishingYear}, " +
                           $"P. {book.NumberOfPages}";
                ////ISBN + it's format: + IsbnAuthorNameTitlePublisherYear + P. + PagesPrice + $
                case "IFIANTPYPPP":
                    return $"ISBN {CountIsbnLength(book.Isbn)}: {book.Isbn}, {book.Author}," +
                           $"{book.Name}, {book.PublishingHouse}, {book.PublishingYear}, " +
                           $"P. {book.NumberOfPages}, {book.Price} {ci.NumberFormat.CurrencySymbol}";
                //// Handle unsupported format strings.
                default:
                    try
                    {
                        return HandleOtherFormats(format, arg);
                    }
                    catch (FormatException e)
                    {
                        throw new FormatException(String.Format("The format of '{0}' is invalid.", format), e);
                    }
            }
        }

        private static int CountIsbnLength(string isbn)
        {
            int k = 0;
            foreach (char t in isbn)
            {
                if (!t.ToString().Equals("-"))
                {
                    k++;
                }
            }

            return k;
        }

        private string HandleOtherFormats(string format, object arg)
        {
            if (arg is IFormattable)
            {
                return ((IFormattable)arg).ToString(format, CultureInfo.CurrentCulture);
            }
            else if (arg != null)
            {
                return arg.ToString();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}