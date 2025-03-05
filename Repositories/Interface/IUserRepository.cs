using MoneyTransferApplication.Models;

namespace MoneyTransferApplication.Repositories.Interface
{
    public interface IUserRepository : IGenericRepositories<User>
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserWithTransactions(Guid userId);
    }
}
