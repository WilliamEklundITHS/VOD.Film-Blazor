namespace VOD.Film.Common.Services.ClientService
{
    public interface IClientService
    {
        Task<List<T>> GetAllAsync<T>(string uri);
        Task<Dictionary<string, List<T>>> GetAllByGroupingAsync<T>(string uri);
        Task<T> GetAsync<T>(string uri);

    }
}
