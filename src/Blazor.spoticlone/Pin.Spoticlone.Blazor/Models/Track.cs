using System.ComponentModel.DataAnnotations;

namespace Pin.Spoticlone.Blazor.Models
{
    public class Track
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(200, ErrorMessage = "Title is too long.")]
        public string Title { get; set; }
        //public string SpotifyId { get; set; }
        [Required]
        public int TrackNumber { get; set; }
        [Required]
        public int DiscNumber { get; set; }
        [Required]
        public string DurationMs { get; set; }
        public bool Explicit { get; set; }
        //public Uri PreviewUrl { get; set; }
        public Guid AlbumId { get; set; }
        public string AlbumName { get; set; }
    }
}
