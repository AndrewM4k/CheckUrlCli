namespace CheckUrlCli.Helpers
{
    public static class UriHelper
    {
        public static bool IsValidUri(string uri)
        {
            return Uri.IsWellFormedUriString(uri, UriKind.Absolute);
        }
    }
}
