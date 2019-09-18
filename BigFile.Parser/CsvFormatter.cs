using Newtonsoft.Json.Linq;

namespace BigFile.Parser
{
    public class CsvFormatter : IFormatter
    {
        public string FirstLine()
        {
            return "LineNumber;Type;Line;Value";

        }

        public string FormatError(int lineId, string line)
        {

            JObject result = new JObject(
                                            new JProperty("lineNumber", lineId),
                                            new JProperty("type", "error"),
                                            new JProperty("errorMessage", line));

            return $"{lineId};error;{line};";
        }

        public string FormatValid(int lineId, ModelLine line)
        {

            if ((line.ColumnC + line.ColumnD) <= 100)
                return string.Empty;

            return $"{lineId};ok;{line.ColumnA + line.ColumnB};{line.ColumnC + line.ColumnD}";
        }

        public string LastLine()
        {
            return string.Empty;
        }
    }
}
