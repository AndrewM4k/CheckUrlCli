using CheckUrlCli.Exceptions;
using CheckUrlCli.Helpers;
using Polly;
using Polly.Retry;
namespace CheckUrlCli.Services

{
    public class HttpService
    {
        public async Task CheckUrlAsync(string url, int attempts)
        {
            var policy = Policy
            .Handle<Exception>()
            .WaitAndRetryAsync(attempts, attempt =>
            {
                var timeToWait = TimeSpan.FromSeconds(Math.Pow(attempt, 2));
                return timeToWait;
            })
            .ExecuteAsync(async () =>
            {
                for (int i = 0; i < attempts; i++)
                {
                    using (var http = new HttpClient())
                    {
                        var result = http.GetAsync(url).IsFaulted;
                        if (result)
                        {
                            Console.WriteLine("cant connect to the site");
                            return false;
                        }
                    }
                    Console.WriteLine("Success!");
                }
                return true;
            });
        }
    }
}
