using System;

namespace Storage.BLL.Exceptions
{
    public class DataException : Exception
    {
        public string Property { get; protected set; }
        public DataException(string message, string prop) : base(message)
        {
            Property = prop;
        }
    }
}
