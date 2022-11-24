namespace Pin.Spoticlone.Blazor.DTOs
{
    public class ArtistDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Popularity { get; set; }
        public string SpotifyId { get; set; }
        public Uri Image { get; set; }
        public IEnumerable<GenresDto> Genres { get; set; }
        public IEnumerable<AlbumsDto> Albums { get; set; }      
        public int AlbumsCount { get; set; }
    }
}
