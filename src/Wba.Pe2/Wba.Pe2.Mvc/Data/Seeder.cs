using Microsoft.EntityFrameworkCore;
using System;
using Wba.Pe2.Domain;

namespace Wba.Pe2.Mvc.Data
{
    public class Seeder
    {
        public static void SeedData(ModelBuilder modelBuilder)
        {
            //add Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Shooter" },
                new Category { Id = 2, Name = "Sports" },
                new Category { Id = 3, Name = "Role playing" },
                new Category { Id = 4, Name = "Moba" },
                new Category { Id = 5, Name = "Action-Adventure" }
                //new Category { Id = 6 ,Name ="Simulation"}
                );
            modelBuilder.Entity<Character>().HasData(
                new Character { Id = 1, Name = "Kratos" },
                new Character { Id = 2, Name = "Ratchet" },
                new Character { Id = 3, Name = "Clank" },
                new Character { Id = 4, Name = "Geralt" },
                new Character { Id = 5, Name = "Dazzle" },
                new Character { Id = 6, Name = "Luna" },
                new Character { Id = 7, Name = "Nathan Drake" },
                new Character { Id = 8, Name = "Sully" },
                new Character { Id = 9, Name = "Messi" },
                new Character { Id = 10, Name = "Ronaldo" },
                new Character { Id = 11, Name = "Jak" },
                new Character { Id = 12, Name = "Joel" },
                new Character { Id = 13, Name = "Ellie" },
                new Character { Id = 14, Name = "Ghost" }
                );
            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Santa Monica" },
                new Developer { Id = 2, Name = "Valve Corporation" },
                new Developer { Id = 3, Name = "Insomniac games" },
                new Developer { Id = 4, Name = "Cd Projekt" },
                new Developer { Id = 5, Name = "Ea Sports" },
                new Developer { Id = 6, Name = "Naughty Dog" },
                new Developer { Id = 7, Name = "Infinity ward" }
                );
            modelBuilder.Entity<Game>().HasData(
                new Game { Id = 1, Name = "God of War", Price = 39.99m, CategoryId = 5, DeveloperId = 1 , ImagePath = "godOfWar.png" , ReleaseDate = new DateTime(2018,04,20)}, //todo imagepath en releasedate 
                new Game { Id = 2, Name = "Ratchet and Clank", Price = 19.99m, CategoryId = 5, DeveloperId = 3 , ImagePath = "ratchet.png" , ReleaseDate = new (2016,04,12)},
                new Game { Id = 3, Name = "Ratchet and Clank : A Rift Apart", Price = 69.99m, CategoryId = 5, DeveloperId = 3 , ImagePath = "riftApart.png" ,ReleaseDate = new(2021,06,11)},
                new Game { Id = 4, Name = "Dota 2", Price = 0m, CategoryId = 4, DeveloperId = 2 , ImagePath = "dota.png",ReleaseDate = new(2013,06,9)},
                new Game { Id = 5, Name = "Uncharted : Drake's fortune", Price = 9.99m, CategoryId = 5, DeveloperId = 6 ,ImagePath = "uncharted.png" , ReleaseDate = new(2007,11,19)},
                new Game { Id = 6, Name = "Uncharted 2:Among thieves ", Price = 14.99m, CategoryId = 5, DeveloperId = 6 ,ImagePath = "uncharted2.png",ReleaseDate = new(2009,10,13)},
                new Game { Id = 7, Name = "Fifa 2021", Price = 19.99m, CategoryId = 2, DeveloperId = 5 , ImagePath = "fifa21.png",ReleaseDate = new(2020,10,5)},
                new Game { Id = 8, Name = "Fifa 2020", Price = 7.99m, CategoryId = 2, DeveloperId = 5 ,ImagePath="fifa20.png",ReleaseDate = new(2019,10,4)},
                new Game { Id = 9, Name = "The last of us", Price = 17.99m, CategoryId = 5, DeveloperId = 6 , ImagePath ="lastofus.png" ,ReleaseDate=new(2013,06,14)},
                new Game { Id = 10, Name = "The last of us part 2", Price = 49.99m, CategoryId = 5, DeveloperId = 6 , ImagePath = "lastofus2.png",ReleaseDate=new(2020,06,19)},
                new Game { Id = 11, Name = "The Witcher", Price = 24.99m, CategoryId = 3, DeveloperId = 4 , ImagePath = "witcher.png",ReleaseDate=new(2019,12,20)},
                new Game { Id = 12, Name = "Call of duty: Modern Warfare", Price = 55.45m, CategoryId = 1, DeveloperId = 7, ImagePath = "cod.png" ,ReleaseDate = new(2019,10,25) }
                );
            modelBuilder.Entity<Platform>().HasData(
                new Platform { Id = 1, Name = "Pc" },
                new Platform { Id = 2, Name = "Xbox" },
                new Platform { Id = 3, Name = "Playstation" },
                new Platform { Id = 4, Name = "Nintendo" }
                );
            modelBuilder.Entity<Property>().HasData(
                new Property { Id = 1, SubCategory = "Blood" },
                new Property { Id = 2, SubCategory = "Drugs" },
                new Property { Id = 3, SubCategory = "Violence" },
                new Property { Id = 4, SubCategory = "Foul language" },
                new Property { Id = 5, SubCategory = "18+" },
                new Property { Id = 6, SubCategory = "7+" },
                new Property { Id = 7, SubCategory = "3+" },
                new Property { Id = 8, SubCategory = "In-game purchases" }
                );

            //many-to-many
            modelBuilder.Entity<Character>()
                .HasMany(c => c.Games)
                .WithMany(g => g.Characters)
                .UsingEntity(x => x.HasData(
                    new { CharactersId = 1, GamesId = 1 },
                    new { CharactersId = 2, GamesId = 2 },
                    new { CharactersId = 2, GamesId = 3 },
                    new { CharactersId = 3, GamesId = 2 },
                    new { CharactersId = 3, GamesId = 3 },
                    new { CharactersId = 4, GamesId = 11 },
                    new { CharactersId = 5, GamesId = 4 },
                    new { CharactersId = 6, GamesId = 4 },
                    new { CharactersId = 7, GamesId = 5 },
                    new { CharactersId = 7, GamesId = 6 },
                    new { CharactersId = 8, GamesId = 5 },
                    new { CharactersId = 8, GamesId = 6 },
                    new { CharactersId = 9, GamesId = 7 },
                    new { CharactersId = 9, GamesId = 8 },
                    new { CharactersId = 10, GamesId = 7 },
                    new { CharactersId = 10, GamesId = 8 },
                    new { CharactersId = 12, GamesId = 9 },
                    new { CharactersId = 12, GamesId = 10 },
                    new { CharactersId = 13, GamesId = 9 },
                    new { CharactersId = 13, GamesId = 10 },
                    new { CharactersId = 14, GamesId = 12 }
                    ));
            modelBuilder.Entity<Platform>()
                .HasMany(p => p.Games)
                .WithMany(g => g.Platforms)
                .UsingEntity(x => x.HasData(
                    new { PlatformsId = 1, GamesId = 1 },
                    new { PlatformsId = 1, GamesId = 4 },
                    new { PlatformsId = 1, GamesId = 7 },
                    new { PlatformsId = 1, GamesId = 8 },
                    new { PlatformsId = 1, GamesId = 11 },
                    new { PlatformsId = 1, GamesId = 12 },
                    new { PlatformsId = 2, GamesId = 7 },
                    new { PlatformsId = 2, GamesId = 8 },
                    new { PlatformsId = 2, GamesId = 11 },
                    new { PlatformsId = 2, GamesId = 12 },
                    new { PlatformsId = 3, GamesId = 1 },
                    new { PlatformsId = 3, GamesId = 2 },
                    new { PlatformsId = 3, GamesId = 3 },
                    new { PlatformsId = 3, GamesId = 5 },
                    new { PlatformsId = 3, GamesId = 6 },
                    new { PlatformsId = 3, GamesId = 7 },
                    new { PlatformsId = 3, GamesId = 8 },
                    new { PlatformsId = 3, GamesId = 9 },
                    new { PlatformsId = 3, GamesId = 10 },
                    new { PlatformsId = 3, GamesId = 11 },
                    new { PlatformsId = 3, GamesId = 12 },
                    new { PlatformsId = 4, GamesId = 7 },
                    new { PlatformsId = 4, GamesId = 8 },
                    new { PlatformsId = 4, GamesId = 11 }
                    ));
         
            modelBuilder.Entity<Property>()
                 .HasMany(p => p.Games)
                 .WithMany(g => g.Properties)
                 .UsingEntity(x => x.HasData(//2 3  7  8
                     new { PropertiesId = 1, GamesId = 1 },
                     new { PropertiesId = 1, GamesId = 5 },
                     new { PropertiesId = 1, GamesId = 6 },
                     new { PropertiesId = 1, GamesId = 11 },
                     new { PropertiesId = 1, GamesId = 12 },
                     new { PropertiesId = 2, GamesId = 11 },
                     new { PropertiesId = 2, GamesId = 4 },
                     new { PropertiesId = 3, GamesId = 1 },
                     new { PropertiesId = 3, GamesId = 2},
                     new { PropertiesId = 3, GamesId = 3},
                     new { PropertiesId = 3, GamesId = 4 },
                     new { PropertiesId = 3, GamesId = 8 },
                     new { PropertiesId = 3, GamesId = 9 },
                     new { PropertiesId = 3, GamesId = 10 },
                     new { PropertiesId = 3, GamesId = 11 },
                     new { PropertiesId = 3, GamesId = 12 },
                     new { PropertiesId = 4, GamesId = 1 },
                     new { PropertiesId = 4, GamesId = 11 },
                     new { PropertiesId = 4, GamesId = 12 },
                     new { PropertiesId = 5, GamesId = 1 },
                     new { PropertiesId = 5, GamesId = 11 },
                     new { PropertiesId = 5, GamesId = 12 },
                     new { PropertiesId = 6, GamesId = 4},
                     new { PropertiesId = 6, GamesId = 5 },
                     new { PropertiesId = 6, GamesId = 6 },
                     new { PropertiesId = 6, GamesId = 9 },
                     new { PropertiesId = 6, GamesId = 10},
                     new { PropertiesId = 7, GamesId = 2 },
                     new { PropertiesId = 7, GamesId = 3 },
                     new { PropertiesId = 7, GamesId = 7 },
                     new { PropertiesId = 7, GamesId = 8 },
                     new { PropertiesId = 8, GamesId = 1},
                     new { PropertiesId = 8, GamesId = 2 },
                     new { PropertiesId = 8, GamesId = 3 },
                     new { PropertiesId = 8, GamesId = 4 },
                     new { PropertiesId = 8, GamesId = 5 },
                     new { PropertiesId = 8, GamesId = 6 },
                     new { PropertiesId = 8, GamesId = 7 },
                     new { PropertiesId = 8, GamesId = 8},
                     new { PropertiesId = 8, GamesId = 9 },
                     new { PropertiesId = 8, GamesId = 10 },
                     new { PropertiesId = 8, GamesId = 11 },
                     new { PropertiesId = 8, GamesId = 12 }                
                     ));

        }
    }
}
