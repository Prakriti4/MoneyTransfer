using AutoMapper;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.Repositories.Interface;
using MoneyTransferApplication.Services.Interface;
using MoneyTransferApplication.ViewModel.BankAccount;

namespace MoneyTransferApplication.Services.Implementations
{
    public class BankAccountService : IBankAccountService
    {
        private readonly IGenericRepositories<BankAccount> _bankAccountRepository;
        private readonly IGenericUnitofWork _unitOfWork;
        private readonly IMapper _mapper;

        public BankAccountService(IGenericRepositories<BankAccount> bankAccountRepository, IGenericUnitofWork unitOfWork, IMapper mapper)
        {
            _bankAccountRepository = bankAccountRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetBankAccountVM>> GetAllBankAccountsAsync()
        {
            var bankAccounts = await _bankAccountRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<GetBankAccountVM>>(bankAccounts);
        }

        public async Task<GetBankAccountVM> GetBankAccountByIdAsync(Guid id)
        {
            var bankAccount = await _bankAccountRepository.GetByGuidAsync(id);
            return _mapper.Map<GetBankAccountVM>(bankAccount);
        }

        public async Task CreateBankAccountAsync(CreateBankAccountVM model)
        {
            var bankAccount = _mapper.Map<BankAccount>(model);
            await _bankAccountRepository.AddSync(bankAccount);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateBankAccountAsync(Guid id, UpdateBankAccountVM model)
        {
            var bankAccount = await _bankAccountRepository.GetByGuidAsync(id);
            _mapper.Map(model, bankAccount);
            _bankAccountRepository.Update(bankAccount);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteBankAccountAsync(Guid id)
        {
            var bankAccount = await _bankAccountRepository.GetByGuidAsync(id);
            if (bankAccount != null)
            {
                await _bankAccountRepository.DeleteAsync(bankAccount);
            }
        }

    }
}
