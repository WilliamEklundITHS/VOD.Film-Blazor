using System.Linq.Expressions;

namespace VOD.Film.Data.Services
{
    public interface IMovieService
    {

        //Task<TDTO> CreateWithIncludesAsync<TRequestDTO, TEntity, TDTO>(TRequestDTO requestDTO, TEntity entity)
        //  where TEntity : class
        //  where TDTO : class
        //  where TRequestDTO : class; 

        Task<TDTO> CreateWithIncludesAsync<TRequestDTO, TEntity, TDTO>(
                TRequestDTO requestDTO, TEntity entity)
                where TEntity : class
                where TDTO : class
                where TRequestDTO : class;


        Task<TDTO> CreateAsync<TEntity, TDTO, TRequestDTO>(TRequestDTO requestDTO)
                where TEntity : class
                where TDTO : class;


        Task<IReadOnlyList<TDTO>> GetWithIncludeAsync<TEntity, TDTO>(params string[] includes)
                 where TEntity : class
                 where TDTO : class;


        Task<TDTO> GetFirstWithIncludeAsync<TEntity, TDTO>(Expression<Func<TEntity, bool>> predicate, params string[] includes)
            where TEntity : class
            where TDTO : class;


        Task<IReadOnlyList<TDTO>> GetAllAsync<TEntity, TDTO>(bool asNoTracking = false)
                        where TEntity : class
                        where TDTO : class;

        Task<TDTO> GetByIdAsync<TEntity, TDTO>(Expression<Func<TEntity, bool>> expression, bool asNoTracking = false)
         where TEntity : class
         where TDTO : class;

        Task<IReadOnlyList<TDTO>> GetByFilterAsync<TEntity, TDTO>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
            where TDTO : class;


        Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
                   where TEntity : class;

        Task<bool> DeleteManyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, bool>>? predicate2 = null)
            where TEntity : class;


        TDTO Update<TEntity, TDTO, TRequestDTO>(TEntity entity, TRequestDTO dto)
                where TEntity : class
                where TDTO : class
                where TRequestDTO : class;

        Dictionary<TKey, List<TItem>> GroupByToList<TKey, TItem>(Func<TItem, TKey> keySelector)
            where TItem : class
            where TKey : class;

        string GetUri<TEntity>(int id)
         where TEntity : class;


    }

}
