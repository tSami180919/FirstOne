using BigFile.Parser;
using System;

namespace BeezUpTechnical
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileToRead = new FileParser(args[0]);

            Console.WriteLine($"Parsing {args[0]}");


            fileToRead.Execute();


        }
    }
}
