using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.ViewModel.ExchangeRate
{
    public class UpdateExchangeRateVM
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Exchange rate must be greater than zero.")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Effective date is required.")]
        public DateTime EffectiveDate { get; set; }
    }
}
