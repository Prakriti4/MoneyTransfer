using System;

namespace MoneyTransferApplication.ViewModel.BankAccount
{
    public class GetBankAccountVM
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string CountryName { get; set; }
        public string BankName { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountNumber { get; set; }
        public string Currency { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPrimary { get; set; }
        public BankCountry Country { get; set; }
    }
}
