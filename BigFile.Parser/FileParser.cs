using System;
using System.IO;

namespace BigFile.Parser
{
    public class FileParser
    {
        private readonly string fileToRead;
        private readonly OutputType outputType;
        private readonly string fileToCreate;

        public FileParser(string fileToRead, OutputType outputType, string fileToCreate)
        {
            this.fileToRead = fileToRead;
            this.outputType = outputType;
            this.fileToCreate = fileToCreate;
        }

        public void Execute()
        {

            using (var streamReader = new StreamReader(fileToRead))
            using (StreamWriter outputFileStreamWriter = File.CreateText(fileToCreate))
            {

                var firstLine = streamReader.ReadLine();
                var lineParser = LineParserFactory.Build(firstLine);
                var lineFormatter = LineFormatterFactory.Build(outputType);


                outputFileStreamWriter.WriteLine(lineFormatter.FirstLine());



                string currentLine;
                int lineNumber = 0;
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

                outputFileStreamWriter.WriteLine(lineFormatter.LastLine());

            }
        }
    }
}
