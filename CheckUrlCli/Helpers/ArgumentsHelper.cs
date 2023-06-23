using CheckUrlCli.Exceptions;
using CheckUrlCli.Models;

namespace CheckUrlCli.Helpers
{
    public static class ArgumentsHelper
    {
        public static void ThrowOnIncorrectArguments(string[] args)
        {
            if (args.Length != 2)
            {
                throw new InternalErrorException(new Error("Incorrect count of arguments."));
            }

            var url = CorrectionUrl(args[0]);
            if (!UriHelper.IsValidUri(url))
            {
                throw new InternalErrorException(new Error("Incorrect URI."));
            }

            var stringCount = args[1];
            var validNumber = int.TryParse(stringCount, out var count);
            if (!validNumber || count < 1)
            {
                throw new InternalErrorException(new Error("Incorrect attempts count."));
            }
        }
        public static string CorrectionUrl(string url)
        {
            if (!UriHelper.IsValidUri(url))
            {
                url = "http://" + url;
            }
            return url;
        }
    }
}
