using System;
using System.IO;
using System.Linq;
using System.Text;

namespace Task2.Solution
{
    public abstract class RandomGenerator
    {
        public string WorkingDirectory;

        public string FileExtension;

        protected RandomGenerator(string working, string file)
        {
            WorkingDirectory = working;
            FileExtension = file;
        }
        public void GenerateFiles(int filesCount, int contentLength)
        {
            for (var i = 0; i < filesCount; ++i)
            {
                var generatedFileContent = this.GenerateFileContent(contentLength);

                var generatedFileName = $"{Guid.NewGuid()}{this.FileExtension}";

                this.WriteBytesToFile(generatedFileName, generatedFileContent);
            }
        }

        protected abstract byte[] GenerateFileContent(int contentLength);

        private void WriteBytesToFile(string fileName, byte[] content)
        {
            if (!Directory.Exists(WorkingDirectory))
            {
                Directory.CreateDirectory(WorkingDirectory);
            }

            File.WriteAllBytes($"{WorkingDirectory}//{fileName}", content);
        }

        
    }

    public class RandomCharsFileGenerator : RandomGenerator
    {

        public RandomCharsFileGenerator(string working, string file) : base(working, file){ }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var generatedString = this.RandomString(contentLength);

            var bytes = Encoding.Unicode.GetBytes(generatedString);

            return bytes;
        }

        private string RandomString(int Size)
        {
            var random = new Random();

            const string input = "abcdefghijklmnopqrstuvwxyz0123456789";

            var chars = Enumerable.Range(0, Size).Select(x => input[random.Next(0, input.Length)]);

            return new string(chars.ToArray());
        }
    }

    public class RandomBytesFileGenerator : RandomGenerator
    {
        public RandomBytesFileGenerator(string working, string file) : base(working, file){ }

        protected override byte[] GenerateFileContent(int contentLength)
        {
            var random = new Random();

            var fileContent = new byte[contentLength];

            random.NextBytes(fileContent);

            return fileContent;
        }
    }
}