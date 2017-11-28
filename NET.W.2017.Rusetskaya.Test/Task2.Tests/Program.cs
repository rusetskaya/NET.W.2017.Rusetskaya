using Task2.Solution;
namespace Task2.Tests
{
    public class Program
    {
        static void Main(string[] args)
        {
            RandomGenerator gen1 = new RandomBytesFileGenerator("Files with random chars", ".txt");
            RandomGenerator gen2 = new RandomCharsFileGenerator("Files with random bytes", ".bytes");
        }
    }
}