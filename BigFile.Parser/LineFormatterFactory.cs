namespace BigFile.Parser
{
    internal static class LineFormatterFactory
    {
        internal static IFormatter Build(OutputType outputType)
        {

            switch (outputType)
            {
                case OutputType.json:
                    return new JsonFormatter();
                case OutputType.csv:
                    return new CsvFormatter();
                default:
                    throw new System.Exception("No Formatter Defined for the wanted Format");
            }
        }
    }
}
