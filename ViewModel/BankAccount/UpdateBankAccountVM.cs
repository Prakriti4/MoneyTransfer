using System;
using System.ComponentModel.DataAnnotations;

namespace MoneyTransferApplication.ViewModel.BankAccount
{
    public class UpdateBankAccountVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Country name is required.")]
        public string CountryName { get; set; }

        [Required(ErrorMessage = "Bank name is required.")]
        public string BankName { get; set; }

        [Required(ErrorMessage = "Account holder name is required.")]
        public string AccountHolderName { get; set; }

        [Required(ErrorMessage = "Account number is required.")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Currency is required.")]
        public string Currency { get; set; }

        public bool IsPrimary { get; set; }

        [Required(ErrorMessage = "Country selection is required.")]
        public BankCountry Country { get; set; }
    }
}
