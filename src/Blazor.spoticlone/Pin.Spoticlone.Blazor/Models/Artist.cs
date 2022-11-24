using Pin.Spoticlone.Blazor.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Blazor.Models
{
    public class Artist
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public IEnumerable<string> GenresName { get; set; }
        public IEnumerable<Album> Albums { get; set; }
        public Guid AlbumsId { get; set; }

        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public IEnumerable<Artist> ArtistsWithSameGenre { get; set; }
        public int AlbumCount { get; set; }

    }
}
