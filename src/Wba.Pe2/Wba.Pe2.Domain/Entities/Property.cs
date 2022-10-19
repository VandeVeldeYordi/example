using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.Pe2.Domain
{
    public class Property
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string SubCategory { get; set; }
        public ICollection<Game> Games { get; set; }

    }
}
