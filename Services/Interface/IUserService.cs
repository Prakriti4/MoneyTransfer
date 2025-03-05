using Microsoft.AspNetCore.Identity;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories.Interface;
using MoneyTransferApplication.ViewModel.Authentication.User;

namespace MoneyTransferApplication.Services.Interface
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(Guid id);
        Task<User> GetUserByEmailAsync(string email);
        Task CreateUserAsync(RegisterUserVM user);
        Task UpdateUserAsync(UpdateUserVM user);
        Task DeleteUserAsync(Guid id);
        Task<IdentityResult> RegisterAsync(RegisterUserVM user, string password);
        Task<IdentityResult> AuthenticateAsync(RegisterUserVM user, string password);
    }
}
