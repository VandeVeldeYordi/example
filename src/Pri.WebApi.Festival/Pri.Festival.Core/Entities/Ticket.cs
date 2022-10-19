using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Ticket : BaseEntity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int Available { get; set; }
        public int TicketsSold { get; set; }
        public Festival Festival { get; set; }
        public int FestivalId { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
