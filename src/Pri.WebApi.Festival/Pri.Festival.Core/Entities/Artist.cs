using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Core.Entities
{
    public class Artist : BaseEntity
    {
        public string Image { get; set; }
        public Genre Genre { get; set; }
        //shadow foreign key for genre
        public int GenreId { get; set; }
        // many-to-many 
        public ICollection<Festival> Festivals { get; set; }
    }
}
