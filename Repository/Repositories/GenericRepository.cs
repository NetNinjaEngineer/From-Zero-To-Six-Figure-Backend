using Contracts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repository.Repositories;
public class GenericRepository<TEntity>(ApplicationDbContext context) : IGenericRepository<TEntity> where TEntity : class
{
    public void Create(TEntity entity)
        => context.Set<TEntity>().Add(entity);

    public void Delete(TEntity entity)
        => context.Set<TEntity>().Remove(entity);

    public async Task<IEnumerable<TEntity>> FindByCondition(
        Expression<Func<TEntity, bool>> expression, bool trackChanges)
        => !trackChanges ?
        await context.Set<TEntity>()
        .Where(expression)
        .AsNoTracking()
        .ToListAsync() : context.Set<TEntity>().Where(expression);

    public async Task<IEnumerable<TEntity>> GetAll(bool trackChanges)
        => !trackChanges
        ? [.. context.Set<TEntity>().AsNoTracking()] :
        await context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> GetById(Guid id)
        => await context.Set<TEntity>().FindAsync(id);

    public void Update(TEntity entity)
        => context.Update(entity);
}
