using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Blazor.Models
{
    public class Email
    {
        [Required]
        [EmailAddress]
        public string EmailAdress{ get; set; }
    }
}
