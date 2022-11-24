using AutoMapper;
using Pin.Spoticlone.Core.Dtos;
using Pin.Spoticlone.Core.Extensions;
using Pin.Spoticlone.Core.Entities;
using System.Linq;

namespace Pin.Spoticlone.Core.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            #region Artist
            CreateMap<Artist, ArtistResponseDto>()
                .ForMember(dest => dest.AlbumsCount,
                    opt => opt.MapFrom(src => src.Albums.Count()))
                .ForMember(dest => dest.Genres,
                    opt => opt.MapFrom(src => src.ArtistGenres
                        .Select(ag => new GenreResponseDto
                        {
                            Id = ag.GenreId,
                            Name = ag.Genre.Name
                        })));

            CreateMap<ArtistRequestDto, Artist>();
            #endregion

            #region Genre
            CreateMap<Genre, GenreResponseDto>();
            CreateMap<GenreRequestDto, Genre>();
            #endregion

            #region Album
            CreateMap<Album, AlbumResponseDto>()
                .ForMember(dest => dest.NumberOfTracks,
                    opt => opt.MapFrom(src => src.Tracks.Count))
                .ForMember(dest => dest.NumberOfDiscs,
                        opt => opt.MapFrom(src => src.Tracks.Max(t => t.DiscNumber)))
                .ForMember(dest => dest.Duration,
                    opt => opt.MapFrom(src => src.Tracks.Sum(t => t.DurationMs)
                        .ConvertToStringDuration()));
            CreateMap<AlbumRequestDto, Album>();
            #endregion

            #region Track
            CreateMap<Track, TrackResponseDto>()
                .ForMember(dest => dest.Title,
                    opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Duration,
                    opt => opt.MapFrom(src => src.DurationMs
                        .ConvertToStringDuration()));
            CreateMap<TrackRequestDto, Track>();
            #endregion
        }
    }
}
