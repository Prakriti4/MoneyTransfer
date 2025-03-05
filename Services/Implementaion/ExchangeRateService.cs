using AutoMapper;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories;
using MoneyTransferApplication.Repositories.Interface;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.ExchangeRate;
using Newtonsoft.Json;

namespace MoneyTransferApplication.Services.Implementations
{
    public class ExchangeRateService : IExchangeRateService
    {
        private readonly IGenericRepositories<ExchangeRate> _exchangeRateRepository;
        private readonly IGenericUnitofWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly HttpClient _httpClient;

        public ExchangeRateService(IGenericRepositories<ExchangeRate> exchangeRateRepository, IGenericUnitofWork unitOfWork, IMapper mapper, HttpClient httpClient)
        {
            _exchangeRateRepository = exchangeRateRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<GetExchangeRateVM>> GetAllExchangeRatesAsync()
        {
            var exchangeRates = await _exchangeRateRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetExchangeRateVM>>(exchangeRates);
        }

        public async Task<GetExchangeRateVM> GetExchangeRateByIdAsync(Guid id)
        {
            var exchangeRate = await _exchangeRateRepository.GetByGuidAsync(id);
            return _mapper.Map<GetExchangeRateVM>(exchangeRate);
        }

        public async Task FetchAndStoreExchangeRatesFromAPI()
        {
            var response = await _httpClient.GetStringAsync("https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from=2024-06-12&to=2024-06-12");
            var exchangeRateData = JsonConvert.DeserializeObject<List<ExchangeRate>>(response);

            foreach (var rate in exchangeRateData)
            {
                await _exchangeRateRepository.AddSync(rate);
            }
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ExchangeRate> GetExchangeRateAsync()
        {
            string url = "https://www.nrb.org.np/api/forex/v1/rates?page=1&per_page=5&from=2024-06-12&to=2024-06-12";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ExchangeRate>(response);
        }
    }
}
