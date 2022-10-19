using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        [Display(Name = "Character name")]
        public string Name { get; set; }
       
    }
}
