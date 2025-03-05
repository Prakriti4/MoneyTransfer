using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.Models
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public Guid UserId {  get; set; }
        public virtual User User { get; set; }
        public Guid SenderBankAccountId { get; set; }
        public virtual BankAccount SenderBankAccount { get; set; }  
        public string ReceiverFullName {  get; set; }
        public string ReceiverBankName { get; set; }    
        public string ReceiverAccountNumber {  get; set; }
        public string ReceiverPhoneNumber   { get; set; }
        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountSentMYR { get; set; }

        [Required]
        public int ExchangeRateId { get; set; }
        public virtual ExchangeRate ExchangeRate { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountReceivedNPR { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionFee { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmountDeducted { get; set; }

        [Required]
        public TransactionStatus Status {  get; set; }=TransactionStatus.Pending;
        public DateTime TransactionDate { get; set; }= DateTime.Now;
        public DateTime CreatedAt {  get; set; }
    }

    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed
    }
}
