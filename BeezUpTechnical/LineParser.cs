﻿using Common.Useful;
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

        internal StatusData<ModelLine> Act(string line)
        {
            try
            {
                var columnNames = line.Split(';');

                var columnC = columnNames[indexColumnC];
                var columnD = columnNames[indexColumnD];

                var c = int.Parse(columnC);
                var d = int.Parse(columnD);

                return StatusDataBuilder.Create(new ModelLine(columnNames[indexColumnA], columnNames[indexColumnB], c, d));
            }
            catch (Exception e)
            {
                return StatusDataBuilder.Create<ModelLine>(e.Message);
            }

        }
    }
}
