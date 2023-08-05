using System.Linq.Expressions;
using Kusys.DAL.Repository.Abstract;
using Kusys.Domains.Domains;
using Microsoft.EntityFrameworkCore;

namespace Kusys.DAL.Repository.Concrete;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    protected DbContext _dbContext;
    private DbSet<TEntity> _dbSet;

    public Repository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<TEntity>();
    }

    public async Task<int> InsertAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task InsertRangeAsync(IEnumerable<TEntity> entities)
    {
        await _dbSet.AddRangeAsync(entities);
        await _dbContext.SaveChangesAsync();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<int> Delete(TEntity entity)
    {
        _dbSet.Remove(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public void DeleteRange(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }

    public Task<List<TEntity>> GetAllAsync()
    {
        return _dbSet.ToListAsync();
    }

    public Task<List<TEntity>> GetAllWithIncludingAsync(params string[] includes)
    {
        var query = _dbSet.AsQueryable();
        foreach (var include in includes)
            query = query.Include(include);

        return query.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public Task<TEntity?> GetByIdWithIncludeAsync(int id, params string[] includes)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();

        foreach (var include in includes)
            query = query.Include(include);

        return query.FirstOrDefaultAsync(s => s.Id == id);
    }

    public IQueryable<TEntity> Query(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null)
    {
        IQueryable<TEntity> query = _dbSet;

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);

        return query;
    }

    public IQueryable<TEntity> QueryWithInclude(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params string[] includes)
    {
        IQueryable<TEntity> query = _dbSet.AsQueryable();

        if (filter != null)
            query = query.Where(filter);

        if (orderBy != null)
            query = orderBy(query);


        foreach (var include in includes)
            query = query.Include(include);

        return query;
    }

    public async Task<int> UpdateAsync(TEntity entity)
    {
        // EntityEntry entityEntry = _dbContext.Entry(entity);
        // entityEntry.State = EntityState.Modified;
        // return await _dbContext.SaveChangesAsync();

        _dbSet.Update(entity);
        return await _dbContext.SaveChangesAsync();
    }

    public Task UpdateRangeAsync(IEnumerable<TEntity> entities)
    {
        throw new NotImplementedException();
    }
}