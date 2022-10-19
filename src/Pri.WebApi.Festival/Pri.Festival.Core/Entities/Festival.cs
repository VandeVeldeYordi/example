using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Festival : BaseEntity
    {
        [Required]
        [MaxLength(200)]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public string Image { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public Location Location { get; set; }
        public int LocationId { get; set; }
        public Organizer Organizer { get; set; }
        public int OrganizerId { get; set; }
    }
}
