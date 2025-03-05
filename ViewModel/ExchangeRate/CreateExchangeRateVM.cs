using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.ViewModel.ExchangeRate
{
    public class CreateExchangeRateVM
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(3, ErrorMessage = "Currency code must be exactly 3 characters.")]
        [MinLength(3, ErrorMessage = "Currency code must be exactly 3 characters.")]
        public string FromCurrency { get; set; } = "MYR";

        [Required]
        [MaxLength(3, ErrorMessage = "Currency code must be exactly 3 characters.")]
        [MinLength(3, ErrorMessage = "Currency code must be exactly 3 characters.")]
        public string ToCurrency { get; set; } = "NPR";

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Exchange rate must be greater than zero.")]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "Effective date is required.")]
        public DateTime EffectiveDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
