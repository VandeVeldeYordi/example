namespace Pin.Spoticlone.Blazor.Models
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public ICollection<ArtistGenre> ArtistGenres { get; set; }
    }
}
