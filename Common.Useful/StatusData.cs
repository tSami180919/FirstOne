using System;

namespace Common.Useful
{
    public struct StatusData<T> 
    {
        private readonly T value;
        private readonly string errorMessage;
        public readonly bool IsError;

        public T Value
        {
            get {
                if (IsError)
                    throw new Exception($"Cannot Acces Value, Status Data is in Error : {errorMessage}");
                return value; }
        }

        public string ErrorMessage
        {
            get
            {
                if (!IsError)
                    throw new Exception($"Cannot Acces Error, Status Data is Valid : {value}");
                return errorMessage;
            }
        }

        internal StatusData(string errorMessage, T val, bool isError)
        {
            this.errorMessage = errorMessage;
            this.value = val;
            this.IsError = isError;
        }
    }
}
