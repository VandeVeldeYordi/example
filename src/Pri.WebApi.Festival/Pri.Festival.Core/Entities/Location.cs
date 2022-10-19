using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Location :BaseEntity
    {        
        public string Postal { get; set; }
        public string City { get; set; }
        public ICollection<Festival> Festivals { get; set; }
    }
}
