using System.ComponentModel.DataAnnotations;

namespace MoneyTransferApplication.ViewModel.Authentication.User
{
    public class LoginUserVM
    {
        [Required]
        public string Email {  get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }    
    }
}
