using System.Net.Http.Json;
using System.Text.Json;
using VOD.Film.Common.HttpClients;

namespace VOD.Film.Common.Services.AdminService
{
    public class AdminService : IAdminService
    {
        private readonly FilmClient _http;

        public AdminService(FilmClient httpClient)
        {
            _http = httpClient;
        }
        public async Task<IReadOnlyList<TDTO>> GetAsync<TDTO>(string uri)
        {
            try
            {
                var response = await _http.client.GetAsync(uri);
                response.EnsureSuccessStatusCode();
                var result = JsonSerializer.Deserialize<IReadOnlyList<TDTO>>(await response.Content.ReadAsStreamAsync(),
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return result!;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Array.Empty<TDTO>();
            }

        }
        public async Task<TDTO> GetSingleAsync<TDTO>(string uri)
        {

            var res = await _http.client.GetFromJsonAsync<TDTO>(uri);
            return res;

        }
        public async Task<TDTO> PostAsync<TDTO>(string uri, TDTO dto)
        {
            var response = await _http.client.PostAsJsonAsync(uri, dto);
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<TDTO>(await response.Content.ReadAsStreamAsync(),
                  new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return result!;
        }
        public async Task<TDTO> PutAsync<TDTO>(string uri, TDTO dto)
        {

            var requestDataJson = JsonSerializer.Serialize(dto);
            var requestDataContent = new StringContent(requestDataJson, System.Text.Encoding.UTF8, "application/json");

            // Send the PUT request
            var response = await _http.client.PutAsync(uri, requestDataContent);
            response.EnsureSuccessStatusCode();
            var responseBodyJson = await response.Content.ReadAsStringAsync();
            var responseBody = JsonSerializer.Deserialize<TDTO>(responseBodyJson);
            return responseBody;
        }
        public async Task<bool> DeleteAsync(string uri)
        {
            var result = await _http.client.DeleteAsync(uri);
            if (!result.IsSuccessStatusCode) return false;
            return true;
        }
    }
}
