namespace Common.Useful
{
    public static class StatusDataBuilder
    {

        public static StatusData<B> Create<B>(string errorMessage)
        {
            return new StatusData<B>(errorMessage, default, true);
        }

        public static StatusData<B> Create<B>(B val)
        {
            return new StatusData<B>(string.Empty, val, false);
        }


    }


}
