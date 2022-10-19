using System;
using System.ComponentModel.DataAnnotations;

namespace Pri.WebApi.Festival.Api.DTOs.Accounts
{
    public class AccountsRegisterRequestDto : AccountsLoginRequestDto
    {
        [Required(ErrorMessage = "Please provide {0}")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Please provide {0}")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Please provide {0}")]
        [Compare("Password", ErrorMessage = "Passwords must match!")]
        public string RepeatPassword { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        public string AddressLine { get; set; }
        [Required]
        [RegularExpression(@"^(\d{4})$", ErrorMessage = "Please Enter a valid postal Code")]
        [DataType(DataType.PostalCode, ErrorMessage = "Please Enter a valid  postal Code")]
        public string PostalCode { get; set; }
        [Required(ErrorMessage = "Please provide {0}")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
    }
}
