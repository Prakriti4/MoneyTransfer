using Microsoft.EntityFrameworkCore.Storage;

namespace MoneyTransferApplication.Repositories.Interface
{
    public interface IGenericUnitofWork
    {
        IGenericRepositories<TEntity> GenericRepositories<TEntity>() where TEntity : class;
        IDbContextTransaction BeginTransaction();
        Task<int> SaveChangesAsync();
    }
}
