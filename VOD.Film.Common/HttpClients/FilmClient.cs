namespace VOD.Film.Common.HttpClients
{
    public class FilmClient
    {
        public HttpClient client;
        public FilmClient(HttpClient Client)
        {
            client = Client;

        }
    }
}
