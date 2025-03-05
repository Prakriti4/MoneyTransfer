using MoneyTransferApplication.ViewModel.ExchangeRate;

namespace MoneyTransferApplication.Services.Interface
{
    public interface IExchangeRateService
    {
        Task<IEnumerable<GetExchangeRateVM>> GetAllExchangeRatesAsync();
        Task<GetExchangeRateVM> GetExchangeRateByIdAsync(Guid id);
        Task FetchAndStoreExchangeRatesFromAPI();
    }
}
