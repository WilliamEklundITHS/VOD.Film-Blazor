using System.Net.Http.Json;
using System.Text.Json;

namespace VOD.Film.Common.Services.ClientService
{
    public class ClientService : IClientService
    {
        private readonly HttpClient _http;
        private readonly JsonSerializerOptions _jsonSerializerOptions;
        public ClientService(HttpClient http)
        {
            _http = http;
            _jsonSerializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
        public async Task<List<T>> GetAllAsync<T>(string uri)
        {
            try
            {
                var response = await _http.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<List<T>>(await response.Content.ReadAsStreamAsync(),
                    _jsonSerializerOptions);
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<T>();
            }
        }
        public async Task<Dictionary<string, List<T>>> GetAllByGroupingAsync<T>(string uri)
        {

            try
            {
                var response = await _http.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<Dictionary<string, List<T>>>(
                    await response.Content.ReadAsStreamAsync(),
                    _jsonSerializerOptions);
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new Dictionary<string, List<T>>();
            }
        }


        public async Task<T> GetAsync<T>(string uri)
        {
            var res = await _http.GetFromJsonAsync<T>(uri);
            return res!;
        }
    }
}
