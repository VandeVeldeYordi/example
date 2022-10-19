using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Organizer : BaseEntity
    {
        public ICollection<Festival> Festivals { get; set; }
    }
}
