using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.Models
{
    public class ExchangeRate
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string FromCurrency { get; set; } = "MYR";

        [Required]
        [MaxLength(3)]

        public string ToCurrency { get; set; } = "NPR";
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Rate { get; set; }
        public DateTime EffectiveDate {  get; set; }
        public DateTime CreatedAt {  get; set; }=DateTime.UtcNow;
    }
}
