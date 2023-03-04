using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VOD.Film.Data.DataAccess;

namespace VOD.Film.Data.Services
{
    public class MovieService : IMovieService
    {
        private readonly DataContext _dbContext;
        private readonly IMapper _mapper;
        public MovieService(DataContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TDTO> CreateWithIncludesAsync<TRequestDTO, TEntity, TDTO>(
            TRequestDTO requestDTO, TEntity entity)
            where TEntity : class
            where TDTO : class
            where TRequestDTO : class
        {
            try
            {
                var mapped = _mapper.Map(requestDTO, entity);
                //Set Unchanged state for an entity whose Key property
                //has a value and Added state for an entity
                //whose Key property is empty or the default value of data type.
                var result = _dbContext.Set<TEntity>().Attach(mapped);
                await SaveChanges<TEntity>();
                var responseDTO = _mapper.Map<TDTO>(result.Entity);
                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<TDTO> CreateAsync<TEntity, TDTO, TRequestDTO>(TRequestDTO requestDTO)
         where TEntity : class
            where TDTO : class
        {
            try
            {
                var mappedEntity = _mapper.Map<TEntity>(requestDTO);
                var result = _dbContext.Set<TEntity>().Add(mappedEntity);
                await SaveChanges<TEntity>();
                var responseDTO = _mapper.Map<TDTO>(result.Entity);
                return responseDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<bool> DeleteAsync<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
        {
            try
            {
                var query = _dbContext.Set<TEntity>();
                var entityToRemove = await query.FirstOrDefaultAsync(predicate);
                if (entityToRemove == null) return false;
                query.Remove(entityToRemove);
                return await SaveChanges<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
        public async Task<bool> DeleteManyAsync<TEntity>(Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, bool>>? predicate2 = null)
            where TEntity : class
        {
            try
            {
                var query = _dbContext.Set<TEntity>();
                var entitiesToRemove = query.Where(predicate);

                if (predicate2 is not null)
                {
                    entitiesToRemove = query.Where(predicate).Where(predicate2);
                }
                query.RemoveRange(entitiesToRemove);
                return await SaveChanges<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<IReadOnlyList<TDTO>> GetAllAsync<TEntity, TDTO>(bool asNoTracking = false)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                var query = _dbContext.Set<TEntity>();
                if (asNoTracking)
                {
                    var result = _mapper.Map<List<TDTO>>(query.AsNoTracking());
                    return result;
                }
                else
                {
                    var result = await _mapper.ProjectTo<TDTO>(query).ToListAsync();
                    return result;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<TDTO> GetByIdAsync<TEntity, TDTO>(
            Expression<Func<TEntity, bool>> predicate,
            bool asNoTracking = false)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                var result = _dbContext.Set<TEntity>();
                if (asNoTracking)
                {
                    var entityAsNoTracking = await result.AsQueryable().AsNoTracking().FirstOrDefaultAsync(predicate);
                    var dto = _mapper.Map<TDTO>(entityAsNoTracking);
                    return dto;
                }
                else
                {
                    var entityAsTracking = await result.FirstOrDefaultAsync(predicate);
                    var dto = _mapper.Map<TDTO>(entityAsTracking);
                    return dto;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }

        }

        public async Task<IReadOnlyList<TDTO>> GetByFilterAsync<TEntity, TDTO>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                var query = _dbContext.Set<TEntity>().AsQueryable();
                query = query.Where(predicate);
                var result = await _mapper.ProjectTo<TDTO>(query).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public TDTO Update<TEntity, TDTO, TRequestDTO>(TEntity entity, TRequestDTO dto)
            where TEntity : class
            where TDTO : class
            where TRequestDTO : class
        {
            try
            {
                var mappedEntity = _mapper.Map(dto, entity);
                _dbContext.Set<TEntity>().Update(mappedEntity);
                _dbContext.SaveChanges();
                var resultDTO = _mapper.Map<TDTO>(entity);
                return resultDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public async Task<TDTO> GetFirstWithIncludeAsync<TEntity, TDTO>(
            Expression<Func<TEntity, bool>> predicate,
            params string[] includes)
            where TEntity : class
            where TDTO : class
        {
            try
            {
                var query = _dbContext.Set<TEntity>()
                    .Where(predicate)
                    .AsQueryable()
                    .AsSplitQuery();
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }

                //To avoid entity tracking issues when mapping
                if (typeof(TEntity) == typeof(TDTO))
                {
                    try
                    {
                        TDTO? res = await query.FirstOrDefaultAsync() as TDTO;
                        if (res is null) throw new ArgumentNullException(nameof(res));
                        return res;
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.ToString());
                    }

                }

                return _mapper.Map<TDTO>(await query.FirstOrDefaultAsync());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public async Task<IReadOnlyList<TDTO>> GetWithIncludeAsync<TEntity, TDTO>(params string[] includes)
           where TEntity : class
           where TDTO : class
        {
            var query = _dbContext.Set<TEntity>()
                .AsQueryable()
                .AsSplitQuery()
                .AsNoTracking();

            foreach (var include in includes)
            {
                query = query.Include(include);
            }
            return await _mapper.ProjectTo<TDTO>(query).ToListAsync();
        }

        public string GetUri<TEntity>(int id) where TEntity : class
            => $"{typeof(TEntity).Name.ToLower()}/{id}";



        public Dictionary<TKey, List<TItem>> GroupByToList<TKey, TItem>(Func<TItem, TKey> keySelector)
            where TItem : class
            where TKey : class
        {
            var source = _dbContext.Set<TItem>();
            var groups = source.GroupBy(keySelector);
            return groups.ToDictionary(group => group.Key, group => group.ToList());
        }


        private async Task<bool> SaveChanges<T>() => await _dbContext.SaveChangesAsync() >= 0;

    }
}
