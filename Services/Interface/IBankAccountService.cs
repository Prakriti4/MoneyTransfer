using MoneyTransferApplication.ViewModel.BankAccount;

namespace MoneyTransferApplication.Services.Interface
{
    public interface IBankAccountService
    {
        Task<IEnumerable<GetBankAccountVM>> GetAllBankAccountsAsync();
        Task<GetBankAccountVM> GetBankAccountByIdAsync(Guid id);
        Task CreateBankAccountAsync(CreateBankAccountVM model);
        Task UpdateBankAccountAsync(Guid id, UpdateBankAccountVM model);
        Task DeleteBankAccountAsync(Guid id);

    }
}
