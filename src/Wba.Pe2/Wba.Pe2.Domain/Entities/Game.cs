using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wba.Pe2.Domain
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        public string ImagePath { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public ICollection<Character> Characters { get; set; }

        public ICollection<Platform> Platforms { get; set; }
        
        public ICollection<Property> Properties { get; set; }

        public int? DeveloperId { get; set; }

        public Developer Developer { get; set; }

        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
