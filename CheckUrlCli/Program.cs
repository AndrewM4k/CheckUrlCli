using CheckUrlCli.Exceptions;
using CheckUrlCli.Helpers;
using CheckUrlCli.Services;

namespace CheckUrlCli
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                ArgumentsHelper.ThrowOnIncorrectArguments(args);

                var url = args[0];
                var count = int.Parse(args[1]);

                var httpService = new HttpService();
                await httpService.CheckUrlAsync(url, count);
            }
            catch (InternalErrorException ex)
            {
                ExceptionsHelper.PrintInternalException(ex);
            }
            catch (Exception ex)
            {
                ExceptionsHelper.PrintBaseException(ex);
            }
        }
    }
}