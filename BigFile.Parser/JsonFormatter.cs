using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace BigFile.Parser
{
    public class JsonFormatter : IFormatter
    {
        public string FormatError(int lineId, string line)
        {

            JObject result = new JObject(
                                            new JProperty("lineNumber", lineId),
                                            new JProperty("type", "error"),
                                            new JProperty("errorMessage", line));

            return result.ToString(Formatting.None);
        }

        public string FormatValid(int lineId, ModelLine line)
        {

            if ((line.ColumnC + line.ColumnD) <= 100)
                return string.Empty;

            JObject result = new JObject(
                                new JProperty("lineNumber", lineId),
                                new JProperty("type", "ok"),
                                new JProperty("concatAB", line.ColumnA + line.ColumnB),
                                new JProperty("sumCD", line.ColumnC + line.ColumnD));

            return result.ToString(Formatting.None);
        }

        public string FirstLine()
        {
            return "[";

        }
        public string LastLine()
        {
            return "]";
        }
    }
}
