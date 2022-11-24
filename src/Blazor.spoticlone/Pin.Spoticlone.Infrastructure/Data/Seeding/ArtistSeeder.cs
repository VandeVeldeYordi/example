using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Core.Entities;
using System;

namespace Pin.Spoticlone.Infrastructure.Data.Seeding
{
    public class ArtistSeeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Artist>().HasData(
                new Artist { Name = "Metallica", Followers = 15044763, Popularity = 85, SpotifyId = "2ye2Wgw4gimLv2eAKyk1NB", Image = new Uri("https://i.scdn.co/image/5a06711d7fc48d5e0e3f9a3274ffed3f0af1bd91"), Id = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), },
                new Artist { Name = "Guns N' Roses", Followers = 17664350, Popularity = 82, SpotifyId = "3qm84nBOXUEQ2vnTfUTTFC", Image = new Uri("https://i.scdn.co/image/80920b4fc80b6d970e2934eb8abe27014fc60632"), Id = Guid.Parse("00cbf3a7-fc78-4576-aab9-920aae6cba13"), },
                new Artist { Name = "Nirvana", Followers = 11175759, Popularity = 82, SpotifyId = "6olE6TJLqED3rqDCT0FyPh", Image = new Uri("https://i.scdn.co/image/84282c28d851a700132356381fcfbadc67ff498b"), Id = Guid.Parse("c83d1ac4-416b-4010-8906-0f1344d0ed49"), },
                new Artist { Name = "Pearl Jam", Followers = 5980792, Popularity = 79, SpotifyId = "1w5Kfo2jwwIPruYS2UWh56", Image = new Uri("https://i.scdn.co/image/8a7775f16a99af5d353d4eb31ec0ccf908a6a6d1"), Id = Guid.Parse("6115fe9a-2c15-4307-b4f9-8bc28b4afe31"), },
                new Artist { Name = "Channel Zero", Followers = 9637, Popularity = 30, SpotifyId = "5yasj6KkVhjlz5JNJFbZkf", Image = new Uri("https://i.scdn.co/image/69c2970f59620de59462a0eea5e4c9e9a43e8f91"), Id = Guid.Parse("fc8a71e6-18d8-459d-bbf2-aa9346d96788"), }
            );
        }
    }
}