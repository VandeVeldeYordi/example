using System.ComponentModel.DataAnnotations;

namespace Wba.Pe2.Mvc.ViewModels
{
    public class PropertiesDetailsViewModel
    {

       public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "sub category")]
        public string SubCategory { get; set; }

    
    }
}
