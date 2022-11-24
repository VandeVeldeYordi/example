using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Core.Entities;
using System;

namespace Pin.Spoticlone.Infrastructure.Data.Seeding
{
    public class ArtistGenreSeeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArtistGenre>().HasData(
                new ArtistGenre { ArtistId = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), GenreId = Guid.Parse("17156d67-7976-4206-8c11-897beb6ee00d"), },
                new ArtistGenre { ArtistId = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), GenreId = Guid.Parse("f890a69a-b11d-4489-b811-92b22f0c00ae"), },
                new ArtistGenre { ArtistId = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), GenreId = Guid.Parse("dfb4c6ac-3c46-4702-8aef-e284c0ba679f"), },
                new ArtistGenre { ArtistId = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), GenreId = Guid.Parse("399093b8-a6ac-4fb8-ab8e-e35855ce6c12"), },
                new ArtistGenre { ArtistId = Guid.Parse("b091f529-1905-4ad7-a4fe-a07d412ba6dc"), GenreId = Guid.Parse("86ed3950-4ba1-42d6-a9e9-c985f95c0eda"), },
                new ArtistGenre { ArtistId = Guid.Parse("00cbf3a7-fc78-4576-aab9-920aae6cba13"), GenreId = Guid.Parse("17156d67-7976-4206-8c11-897beb6ee00d"), },
                new ArtistGenre { ArtistId = Guid.Parse("00cbf3a7-fc78-4576-aab9-920aae6cba13"), GenreId = Guid.Parse("399093b8-a6ac-4fb8-ab8e-e35855ce6c12"), },
                new ArtistGenre { ArtistId = Guid.Parse("00cbf3a7-fc78-4576-aab9-920aae6cba13"), GenreId = Guid.Parse("baa90967-7dc0-44dc-b8c2-de607b4834e0"), },
                new ArtistGenre { ArtistId = Guid.Parse("c83d1ac4-416b-4010-8906-0f1344d0ed49"), GenreId = Guid.Parse("399093b8-a6ac-4fb8-ab8e-e35855ce6c12"), },
                new ArtistGenre { ArtistId = Guid.Parse("c83d1ac4-416b-4010-8906-0f1344d0ed49"), GenreId = Guid.Parse("3e24548d-811a-4bf6-b83a-15cfb04895b1"), },
                new ArtistGenre { ArtistId = Guid.Parse("c83d1ac4-416b-4010-8906-0f1344d0ed49"), GenreId = Guid.Parse("b083db21-7525-4528-8e97-cfcba2ebb129"), },
                new ArtistGenre { ArtistId = Guid.Parse("c83d1ac4-416b-4010-8906-0f1344d0ed49"), GenreId = Guid.Parse("2d17836f-3de5-4e05-b505-9c4ed8504ff8"), },
                new ArtistGenre { ArtistId = Guid.Parse("6115fe9a-2c15-4307-b4f9-8bc28b4afe31"), GenreId = Guid.Parse("399093b8-a6ac-4fb8-ab8e-e35855ce6c12"), },
                new ArtistGenre { ArtistId = Guid.Parse("6115fe9a-2c15-4307-b4f9-8bc28b4afe31"), GenreId = Guid.Parse("3e24548d-811a-4bf6-b83a-15cfb04895b1"), },
                new ArtistGenre { ArtistId = Guid.Parse("6115fe9a-2c15-4307-b4f9-8bc28b4afe31"), GenreId = Guid.Parse("b083db21-7525-4528-8e97-cfcba2ebb129"), },
                new ArtistGenre { ArtistId = Guid.Parse("6115fe9a-2c15-4307-b4f9-8bc28b4afe31"), GenreId = Guid.Parse("2d17836f-3de5-4e05-b505-9c4ed8504ff8"), },
                new ArtistGenre { ArtistId = Guid.Parse("fc8a71e6-18d8-459d-bbf2-aa9346d96788"), GenreId = Guid.Parse("dfb4c6ac-3c46-4702-8aef-e284c0ba679f"), },
                new ArtistGenre { ArtistId = Guid.Parse("fc8a71e6-18d8-459d-bbf2-aa9346d96788"), GenreId = Guid.Parse("4ba19196-0b99-47d3-9ede-6c61002ba744"), },
                new ArtistGenre { ArtistId = Guid.Parse("fc8a71e6-18d8-459d-bbf2-aa9346d96788"), GenreId = Guid.Parse("1996a37b-3330-424c-929a-1911d687a74e"), }
            );
        }
    }
}
