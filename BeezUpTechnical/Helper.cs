using System.Linq;

namespace BeezUpTechnical
{
    internal static class Helper{

        internal const string Column = "column";
        internal const string ColumnA = "columnA";
        internal const string ColumnB = "columnB";
        internal const string ColumnC = "columnC";
        internal const string ColumnD = "columnD";


        public static int FindColumnIndex(this string[] splittedColumn, string columnName)
        {
            return splittedColumn.Select((name, idx) => new { idx, name }).Single(tu => string.Equals(tu.name, columnName)).idx;
        }


    }
}
