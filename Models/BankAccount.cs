using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace MoneyTransferApplication.Models
{
    public class BankAccount
    {
        public Guid Id { get; set; }
        [Required]
        public string UserId {  get; set; }
        public virtual User User { get; set; }
        [Required]
        public BankCountry Country { get; set; }
        public string CountryName {  get; set; }
        [Required]
        public string BankName { get; set; }
        [Required]
        [MaxLength(50)]
        public string AccountHolderName {  get; set; }
        [Required]
        public string AccountNumber {  get; set; }
        public string Currency {  get; set; }
        public DateTime CreatedAt {  get; set; }
        public bool IsPrimary { get; set;} =false;

    }

    public enum BankCountry
    {
        MY,
        NP
    }
}
