using System.Linq.Expressions;

namespace MoneyTransferApplication.Repositories.Interface
{
    public interface IGenericRepositories<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByGuidAsync(Guid id);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetConditionalAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddSync(TEntity entity);
        void Update(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task AddRange(List<TEntity> entities);
        void DeleteRange(List<TEntity> entities);
        Task DeleteAllAsync();
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
        Task<TEntity> FirstOrDefault();

        IQueryable<TEntity> GetAllForQuery();

        IQueryable<TEntity> GetConditionalForQuery(Expression<Func<TEntity, bool>> predicate);

    } 
}
