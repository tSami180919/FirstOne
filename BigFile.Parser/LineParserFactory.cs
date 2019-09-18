using System;

namespace BigFile.Parser
{
    internal static class LineParserFactory
    {

        internal static LineParser Build(string firstLine)
        {
            var columnNames = firstLine.Split(';');


            if (!string.Equals(columnNames[0], Helper.Column, StringComparison.InvariantCulture))
                throw new ArgumentException($"First Line must be Column Name. First Line is  {firstLine}");

            var indexColumnA = columnNames.FindColumnIndex(Helper.ColumnA);
            var indexColumnB = columnNames.FindColumnIndex(Helper.ColumnB);
            var indexColumnC = columnNames.FindColumnIndex(Helper.ColumnC);
            var indexColumnD = columnNames.FindColumnIndex(Helper.ColumnD);


            return new LineParser(indexColumnA, indexColumnB, indexColumnC, indexColumnD);

        }
    }
}
