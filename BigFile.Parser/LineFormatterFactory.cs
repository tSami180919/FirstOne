﻿namespace BigFile.Parser
{
    internal static class LineFormatterFactory
    {
        internal static IFormatter Build()
        {
            return new JsonFormatter();

        }
    }
}