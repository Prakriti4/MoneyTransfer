using System.ComponentModel.DataAnnotations;

namespace MoneyTransferApplication.ViewModel.Authentication.User
{
    public class RegisterUserVM
    {
        [Required(ErrorMessage = "UserName is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "FirstName is required")]
        public string FirstName { get; set; }

        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "PhoneNumber is required, not of telephone")]
        [RegularExpression("^9\\d{9}$", ErrorMessage = "Phone must only contain perfetch 10 digit number")]
        public string PhoneNumber { get; set; }


        //[Required(ErrorMessage = "Email is required")]
        //[EmailAddress(ErrorMessage = "Should be of email '@gmail/@yahoo/@hotmail'.com type")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [RegularExpression("^(?=.*[A-Z])(?=.*\\d)(?=.*[@#$%^&+=!])(?!.*\\s).{8,}$", ErrorMessage = "Use 8 or more characters with atleast one uppercase letter, numbers & symbol")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
