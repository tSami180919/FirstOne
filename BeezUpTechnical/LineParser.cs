using System;

namespace BeezUpTechnical
{
    internal class LineParser
    {
        readonly int indexColumnA;
        readonly int indexColumnB;
        readonly int indexColumnC;
        readonly int indexColumnD;

        internal LineParser(int a, int b, int c, int d)
        {
            this.indexColumnA = a;
            this.indexColumnB = b;
            this.indexColumnC = c;
            this.indexColumnD = d;
        }

        internal void Act(string line)
        {
            try
            {
                var columnNames = line.Split(';');

                var columnC = columnNames[indexColumnC];
                var columnD = columnNames[indexColumnD];

                var c = int.Parse(columnC);
                var d = int.Parse(columnD);

                if(c + d > 100)
                    Console.WriteLine(columnNames[indexColumnA] + columnNames[indexColumnB]);

            }
            catch (Exception e)
            {
            }

        }




    }



}
