using CheckUrlCli.Models;

namespace CheckUrlCli.Exceptions
{
    public class InternalErrorException : Exception
    {
        public Error ErrorDescription { get; set; }

        public InternalErrorException(Error error)
            : this(error, null)
        { }

        public InternalErrorException(Error error, Exception? inner)
            : base(error.Message, inner)
        {
            ErrorDescription = error;
        }
    }
}
