using Microsoft.EntityFrameworkCore;
using MoneyTransferApplication.Data;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories.Interface;

namespace MoneyTransferApplication.Repositories.Implementation
{
    public class UserRepository : GenericRepositories<User>, IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> GetUserWithTransactions(Guid userId)
        {
            return await _context.Users
                .Include(u => u.Transactions)
                .FirstOrDefaultAsync(u => u.Id == userId);
        }
    }
}
