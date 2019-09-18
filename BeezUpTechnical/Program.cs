using BigFile.Parser;
using System;
using System.IO;

namespace BeezUpTechnical
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {

                if (args.Length < 1)
                    throw new ArgumentException($"Missing Argument. Must provide a Full Path");

                var fileToRead = args[0];
                var outputType = OutputType.json; // Default Value to Json

                if (args.Length == 2 && Enum.TryParse(typeof(OutputType), args[1], out object extracted))
                    outputType = (OutputType)extracted;

                if (!File.Exists(fileToRead))
                    throw new ArgumentException($"File {fileToRead} Does not exist !");

                var directory = Path.GetDirectoryName(fileToRead);
                var outputFilePath = Path.Combine(directory, $"Output_{DateTime.UtcNow.Ticks}.{outputType.ToString()}");

                Console.WriteLine($"Parsing file {fileToRead} \nOutputing result to file {outputFilePath}");


                var fileParser = new FileParser(fileToRead, outputType, outputFilePath);

                fileParser.Execute();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception thrown : {e.Message}, {e.StackTrace}");
            }
        }
    }
}
