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
	using System.Collections.Generic;
	
	
	public class Artist : EntityBase
	{
		
		public string Name { get; set; }
		public int Followers { get; set; }
		public int Popularity { get; set; }
		public ICollection<ArtistGenre> ArtistGenres { get; set; }
		public ICollection<Album> Albums { get; set; }
		public string SpotifyId { get; set; }
		public Uri Image { get; set; }
	}
}