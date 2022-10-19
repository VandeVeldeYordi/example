using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Genre : BaseEntity
    {
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }
        public ICollection<Artist> Artists { get; set; }
    }
}
