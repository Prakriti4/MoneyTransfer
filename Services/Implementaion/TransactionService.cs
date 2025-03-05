using AutoMapper;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories;
using MoneyTransferApplication.Repositories.Interface;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.Transaction;

namespace MoneyTransferApplication.Services.Implementations
{
    public class TransactionService : ITransactionService
    {
        private readonly IGenericRepositories<Transaction> _transactionRepository;
        private readonly IGenericUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IGenericRepositories<Transaction> transactionRepository, IGenericUnitofWork unitOfWork, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetTransactionVM>> GetAllTransactionsAsync()
        {
            var transactions = await _transactionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetTransactionVM>>(transactions);
        }

        public async Task<GetTransactionVM> GetTransactionByIdAsync(Guid id)
        {
            var transaction = await _transactionRepository.GetByGuidAsync(id);
            return _mapper.Map<GetTransactionVM>(transaction);
        }

        public async Task CreateTransactionAsync(CreateTransactionVM model)
        {
            var transaction = _mapper.Map<Transaction>(model);
            await _transactionRepository.AddSync(transaction);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetTransactionVM>> GetTransactionsByDateRangeAsync(DateTime fromDate, DateTime toDate)
        {
            var transactions = await _transactionRepository.FirstOrDefaultAsync(t => t.CreatedAt >= fromDate && t.CreatedAt <= toDate);
            return _mapper.Map<IEnumerable<GetTransactionVM>>(transactions);
        }

    }
}
