using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Accounts
{
    public class AccountsLoginRequestDto
    {
        [Required(ErrorMessage = "Please provide {0}")]
        [EmailAddress(ErrorMessage = "Please provide a valid email!")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]

        public string Password { get; set; }
    }
}
