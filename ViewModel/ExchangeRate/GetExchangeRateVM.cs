using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.ViewModel.ExchangeRate
{
    public class GetExchangeRateVM
    {
        public Guid Id { get; set; }

        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }

        public DateTime EffectiveDate { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
