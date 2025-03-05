using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoneyTransferApplication.ViewModel.Transaction
{
    public class CreateTransactionVM
    {
        public Guid Id { get; set; }

        [Required]
        public Guid SenderBankAccountId { get; set; }

        [Required]
        public string ReceiverFullName { get; set; }

        [Required]
        public string ReceiverBankName { get; set; }

        [Required]
        public string ReceiverAccountNumber { get; set; }

        [Required]
        public string ReceiverPhoneNumber { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero")]
        public decimal AmountSentMYR { get; set; }

        [Required]
        public int ExchangeRateId { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal AmountReceivedNPR { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TransactionFee { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal TotalAmountDeducted { get; set; }

        [Required]
        public TransactionStatus Status { get; set; } = TransactionStatus.Pending;

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }

    public enum TransactionStatus
    {
        Pending,
        Completed,
        Failed
    }
}
