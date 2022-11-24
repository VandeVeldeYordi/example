using Pin.Spoticlone.Core.Dtos.Base;
using System;
using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Core.Dtos
{
    public class ArtistRequestDto : DtoBase
    {
        [Required(ErrorMessage = "Naam is verplicht")]
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public Uri Image { get; set; }
    }
}
