using MoneyTransferApplication.ViewModel.Transaction;

namespace MoneyTransferApplication.Services.Interface
{
    public interface ITransactionService
    {
        Task<IEnumerable<GetTransactionVM>> GetAllTransactionsAsync();
        Task<GetTransactionVM> GetTransactionByIdAsync(Guid id);
        Task CreateTransactionAsync(CreateTransactionVM model);
        Task<IEnumerable<GetTransactionVM>> GetTransactionsByDateRangeAsync(DateTime fromDate, DateTime toDate);
    }
}
