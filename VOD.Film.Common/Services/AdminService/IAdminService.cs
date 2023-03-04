namespace VOD.Film.Common.Services.AdminService
{
    public interface IAdminService
    {
        Task<IReadOnlyList<TDTO>> GetAsync<TDTO>(string uri);
        Task<TDTO> GetSingleAsync<TDTO>(string uri);
        Task<TDTO> PostAsync<TDTO>(string uri, TDTO dto);

        Task<T> PutAsync<T>(string uri, T dto);
        Task<bool> DeleteAsync(string uri);


    }
}
