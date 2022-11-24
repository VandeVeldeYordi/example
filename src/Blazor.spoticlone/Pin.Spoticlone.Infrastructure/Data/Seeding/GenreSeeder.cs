using Microsoft.EntityFrameworkCore;
using Pin.Spoticlone.Core.Entities;
using System;

namespace Pin.Spoticlone.Infrastructure.Data.Seeding
{
    public class GenreSeeder
    {

        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre { Name = "hard rock", Id = Guid.Parse("17156d67-7976-4206-8c11-897beb6ee00d"), },
                new Genre { Name = "metal", Id = Guid.Parse("f890a69a-b11d-4489-b811-92b22f0c00ae"), },
                new Genre { Name = "old school thrash", Id = Guid.Parse("dfb4c6ac-3c46-4702-8aef-e284c0ba679f"), },
                new Genre { Name = "rock", Id = Guid.Parse("399093b8-a6ac-4fb8-ab8e-e35855ce6c12"), },
                new Genre { Name = "thrash metal", Id = Guid.Parse("86ed3950-4ba1-42d6-a9e9-c985f95c0eda"), },
                new Genre { Name = "glam metal", Id = Guid.Parse("baa90967-7dc0-44dc-b8c2-de607b4834e0"), },
                new Genre { Name = "alternative rock", Id = Guid.Parse("3e24548d-811a-4bf6-b83a-15cfb04895b1"), },
                new Genre { Name = "grunge", Id = Guid.Parse("b083db21-7525-4528-8e97-cfcba2ebb129"), },
                new Genre { Name = "permanent wave", Id = Guid.Parse("2d17836f-3de5-4e05-b505-9c4ed8504ff8"), },
                new Genre { Name = "belgian metal", Id = Guid.Parse("4ba19196-0b99-47d3-9ede-6c61002ba744"), },
                new Genre { Name = "belgian rock", Id = Guid.Parse("1996a37b-3330-424c-929a-1911d687a74e"), }
            );
        }
    }
}
