using System.Collections;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using MoneyTransferApplication.Data;
using MoneyTransferApplication.Repositories.Interface;
using NuGet.Protocol.Core.Types;

namespace MoneyTransferApplication.Repositories.Implementation
{
    public class GenericUnitOfWork : IGenericUnitofWork
    {
        private readonly ApplicationDbContext _context;
        private bool _disposed;
        private Hashtable _repositories;
        public GenericUnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IGenericRepositories<TEntity> GenericRepositories<TEntity>() where TEntity : class
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }
            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(GenericRepositories<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)));
                _repositories.Add(type, repositoryInstance);
            }
            return (IGenericRepositories<TEntity>)_repositories[type];
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _context.Database.BeginTransaction();
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
