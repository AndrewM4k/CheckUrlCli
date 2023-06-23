using CheckUrlCli.Exceptions;

namespace CheckUrlCli.Helpers
{
    public static class ExceptionsHelper
    {
        public static void PrintInternalException(InternalErrorException exception)
        {
            Console.WriteLine("error: {0}", exception.ErrorDescription.Message);
        }

        public static void PrintBaseException(Exception exception)
        {
            Console.WriteLine("exception: {0}", exception.Message);
        }
    }
}
