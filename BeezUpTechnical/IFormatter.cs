namespace BeezUpTechnical
{
    public interface IFormatter
    {
        string FormatValid(int lineId, ModelLine line);
        string FormatError(int lineId, string errorMessage);


    }
}
