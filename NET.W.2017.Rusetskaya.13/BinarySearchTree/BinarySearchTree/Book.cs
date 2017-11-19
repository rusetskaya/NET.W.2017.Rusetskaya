namespace BinarySearchTree
{
    public class Book
    {
        private string name;
        private string author;
        private int year;

        public Book(string name, string author, int year)
        {
            this.name = name;
            this.author = author;
            this.year = year;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public string Author
        {
            get => author;
            set => author = value;
        }

        public int Year
        {
            get => year;
            set => year = value;
        }
    }
}