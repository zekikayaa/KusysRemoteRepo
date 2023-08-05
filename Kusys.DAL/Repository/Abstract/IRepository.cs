using System.Linq.Expressions;

namespace Kusys.DAL.Repository.Abstract;

public interface IRepository<TEntity>
{
    Task<TEntity?> GetByIdAsync(int id);

    Task<TEntity?> GetByIdWithIncludeAsync(int id, params string[] includes);

    IQueryable<TEntity> Query();

    // IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null);
    //
    // IQueryable<TEntity> QueryWithInclude(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params string[] includes);

    Task<List<TEntity>> GetAllAsync();

    Task<List<TEntity>> GetAllWithIncludingAsync(params string[] includes);

    Task<int> InsertAsync(TEntity entity);

    Task InsertRangeAsync(IEnumerable<TEntity> entities);

    Task<int> UpdateAsync(TEntity entity);


    Task UpdateRangeAsync(IEnumerable<TEntity> entities);


    void Delete(int id);

    Task<int> Delete(TEntity entity);

    void DeleteRange(IEnumerable<TEntity> entities);
}