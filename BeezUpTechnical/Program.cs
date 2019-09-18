using System;
using System.IO;

namespace BeezUpTechnical
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var fileToRead = args[0];

            if (!File.Exists(fileToRead))
                throw new ArgumentException($"File {fileToRead} Does not exist !");


            using (var streamReader = new StreamReader(fileToRead))
            {
                var firstLine = streamReader.ReadLine();

                var lineParser = LineParserFactory.Build(firstLine);

                string currentLine;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    lineParser.Act(currentLine);

                }


            }
        }
    }
}
