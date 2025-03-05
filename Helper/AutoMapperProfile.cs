using AutoMapper;
using MoneyTransferApplication.Models;
using MoneyTransferApplication.ViewModel.BankAccount;
using MoneyTransferApplication.ViewModel.ExchangeRate;
using MoneyTransferApplication.ViewModel.Transaction;

namespace MoneyTransferApplication.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            // Mapping BankAccount
            CreateMap<BankAccount, CreateBankAccountVM>().ReverseMap();
            CreateMap<BankAccount, GetBankAccountVM>().ReverseMap();
            CreateMap<BankAccount, UpdateBankAccountVM>().ReverseMap();

            // Mapping ExchangeRate
            CreateMap<ExchangeRate, CreateExchangeRateVM>().ReverseMap();
            CreateMap<ExchangeRate, GetExchangeRateVM>().ReverseMap();
            CreateMap<ExchangeRate, UpdateExchangeRateVM>().ReverseMap();

            // Mapping Transactions
            CreateMap<Transaction, CreateTransactionVM>().ReverseMap();
            CreateMap<Transaction, GetTransactionVM>().ReverseMap();
            CreateMap<Transaction, UpdateTransactionVM>().ReverseMap();
        }
    }
}
