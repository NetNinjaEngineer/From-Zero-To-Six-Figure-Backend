using System.Linq.Expressions;

namespace Contracts;

public interface IGenericRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> GetAll(bool trackChanges);
    Task<IEnumerable<TEntity>> FindByCondition(Expression<Func<TEntity, bool>> expression, bool trackChanges);
    Task<TEntity?> GetById(Guid id);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
