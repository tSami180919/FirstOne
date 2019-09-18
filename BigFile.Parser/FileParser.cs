using System;
using System.IO;

namespace BigFile.Parser
{
    public class FileParser
    {

        private readonly string fileToRead;

        public FileParser(string fileToRead)
        {
            this.fileToRead = fileToRead;
        }

        public void Execute()
        {
            if (!File.Exists(fileToRead))
                throw new ArgumentException($"File {fileToRead} Does not exist !");

            var directory = Path.GetDirectoryName(fileToRead);
            var outputFilePath = Path.Combine(directory, $"Output_{DateTime.UtcNow.Ticks}.json");


            using (var streamReader = new StreamReader(fileToRead))
            using (StreamWriter outputFileStreamWriter = File.CreateText(outputFilePath))
            {

                var firstLine = streamReader.ReadLine();
                var lineParser = LineParserFactory.Build(firstLine);
                var lineFormatter = LineFormatterFactory.Build();



                string currentLine;
                int lineNumber = 0;
                // Read and display lines from the file until the end of 
                // the file is reached.
                while ((currentLine = streamReader.ReadLine()) != null)
                {
                    var modelLines = lineParser.Act(currentLine);
                    string lineToWrite;

                    if (modelLines.IsError)
                        lineToWrite = lineFormatter.FormatError(lineNumber, modelLines.ErrorMessage);
                    else
                        lineToWrite = lineFormatter.FormatValid(lineNumber, modelLines.Value);

                    if (string.Empty != lineToWrite)
                        outputFileStreamWriter.WriteLine(lineToWrite);

                }
            }
        }


    }
}
