//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pin.Spoticlone.Core.Entities
{
    using System;


    public class Track : EntityBase
    {
        public string Name { get; set; }
        public string SpotifyId { get; set; }
        public int TrackNumber { get; set; }
        public int DiscNumber { get; set; }
        public int DurationMs { get; set; }
        public bool Explicit { get; set; }
        public Uri PreviewUrl { get; set; }
        public Guid AlbumId { get; set; }
        public Album Album { get; set; }
    }
}