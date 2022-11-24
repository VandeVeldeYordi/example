namespace Pin.Spoticlone.Blazor.DTOs
{
    public class TracksUpdateDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public string Duration { get; set; }
        public bool Explicit { get; set; }
        public Guid AlbumId { get; set; }
     
    }
}
