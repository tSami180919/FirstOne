namespace BeezUpTechnical
{
    public class ModelLine
    {

        private readonly string columnA;
        private readonly string columnB;
        private readonly int columnC;
        private readonly int columnD;

        internal ModelLine(string a, string b, int c, int d)
        {
            this.columnA = a;
            this.columnB = b;
            this.columnC = c;
            this.columnD = d;
        }

        public int ColumnD => columnD;

        public int ColumnC => columnC;

        public string ColumnA => columnA;

        public string ColumnB => columnB;
    }
}
