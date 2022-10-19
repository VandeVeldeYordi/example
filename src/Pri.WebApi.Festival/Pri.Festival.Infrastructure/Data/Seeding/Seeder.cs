using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pri.Festivals.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Pri.Festivals.Infrastructure.Data.Seeding
{
    public class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<Location>().HasData(
                new Location[]
                {
                    new Location{ Id = 1,Name ="PRC de Schorre" , City= "Boom" ,Postal="2850" },
                    new Location{ Id = 2,Name ="Haachsesteenweg" , City= "Werchter" ,Postal="3118" },
                    new Location{ Id = 3,Name ="Kempische Steenweg" , City= "Hasselt" ,Postal="3500" },
                    new Location{ Id = 4,Name ="Beersebaan" , City= "Gierle" ,Postal="2275" },
                    new Location{ Id = 5,Name ="Kastelsedijk" , City= "Dessel" ,Postal="2480" },
                    new Location{ Id = 6,Name ="provinciaal domein" , City="Wachtebeke" ,Postal="9185"},
                });
            modelBuilder.Entity<Organizer>().HasData(
                new Organizer[]
                {
                    new Organizer{Id = 1 , Name = "We Are One World"},
                    new Organizer{Id = 2 , Name = "Herman Schueremans"},
                    new Organizer{Id = 3 , Name = "Chokri Mahassine"},
                    new Organizer{Id = 4 , Name = "Sunrise Festival"},
                    new Organizer{Id = 5 , Name = "Peter Van Geel"},
                    new Organizer{Id = 6 , Name = "Bass events"}
                });
            modelBuilder.Entity<Genre>().HasData(
                new Genre[]
                {
                    new Genre{Id = 1 ,Name = "EDM" , Description = "Electronic dance music"},
                    new Genre{Id = 2 ,Name = "Rock" , Description = "Rock & roll , strong beat"},
                    new Genre{Id = 3 ,Name = "Hiphop" , Description = "Rap , r&b en funky music"},
                    new Genre{Id = 4 ,Name = "Techno" , Description = "Dance music with electronic instruments"},
                    new Genre{Id = 5 ,Name = "Metal" , Description = "Intense and powerful"},
                    new Genre{Id = 6 ,Name = "Hard dance" , Description = "Bpm range from 140 to 180"}
                });
            modelBuilder.Entity<Artist>().HasData(
                new Artist[]
                {
                    new Artist{Id = 1 , Name = "Armin van Buuren" ,Image = "arminvb.jpg" , GenreId = 1},
                    new Artist{Id = 2 , Name = "Martin Garrix" , Image = "martin.jpg" , GenreId = 1},
                    new Artist{Id = 3 , Name = "The war on drugs" ,Image = "wardrugs.jpg" , GenreId = 2 },
                    new Artist{Id = 4 , Name = "Red hot chili peppers" , Image = "chili.jpg" , GenreId = 2 },
                    new Artist{Id = 5 , Name = "Drake" , Image = "drake.jpg", GenreId = 3 },
                    new Artist{Id = 6 , Name = "Ye" , Image = "ye.jpg" , GenreId = 3 },
                    new Artist{Id = 7 , Name = "Charlotte de Witte" , Image = "charlotte.jpg" ,GenreId = 4},
                    new Artist{Id = 8 , Name = "Amelie Lense" , Image = "amelie.jpg" , GenreId = 4},
                    new Artist{Id = 9 , Name = "Rammstein", Image = "rammstein.jpg" , GenreId = 5},
                    new Artist{Id = 10 , Name = "Iron Maiden" , Image = "iron.jpg" , GenreId= 5},
                    new Artist{Id = 11 , Name = "Rebelion" , Image = "rebelion.jpg" , GenreId = 6 },
                    new Artist{Id = 12 , Name = "Sefa" , Image = "sefa.jpg" , GenreId = 6}
                });
            modelBuilder.Entity<Festival>().HasData(
                new Festival[]
                {
                    new Festival{Id = 1 , Name = "Tomorrowland" , Description = "Belgium's biggest dance festival" , LocationId = 1 , OrganizerId= 1, StartDate =DateTime.Parse("15/07/2022 6:00:00") , EndDate = DateTime.Parse("19/07/2022 12:00:00"), Image = "tomorrowland.jpg"},
                    new Festival{Id = 2 , Name = "Rock Werchter" , Description = "Pop and rock festival" , LocationId = 2 , OrganizerId= 2, StartDate =DateTime.Parse("30/06/2022 6:00:00") , EndDate = DateTime.Parse("3/07/2022 12:00:00"), Image = "rock.jpg"},
                    new Festival{Id = 3 , Name = "Pukkelpop" , Description = "pop music festival" , LocationId = 3, OrganizerId= 3, StartDate =DateTime.Parse("18/08/2022 6:00:00") , EndDate = DateTime.Parse("21/08/2022 12:00:00"), Image = "pukkelpop.jpg"},
                    new Festival{Id = 4 , Name = "Sunrise festival" , Description = "Escape into Happiness!" , LocationId = 4 , OrganizerId= 4, StartDate =DateTime.Parse("24/06/2022 6:00:00") , EndDate = DateTime.Parse("26/07/2022 12:00:00"), Image = "sunrise.jpg"},
                    new Festival{Id = 5 , Name = "Graspop" , Description = "Graspop metal meeting" , LocationId = 5 , OrganizerId= 5, StartDate =DateTime.Parse("16/06/2022 6:00:00") , EndDate = DateTime.Parse("19/06/2022 12:00:00"), Image = "graspop.jpg"},
                    new Festival{Id = 6 , Name = "Qontinent" , Description = "Breaking boundaries" , LocationId = 6 , OrganizerId= 6, StartDate =DateTime.Parse("12/08/2022 6:00:00") , EndDate = DateTime.Parse("14/08/2022 12:00:00"), Image = "qontinent.jpg"},
                });
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket[]
                {
                    new Ticket{Id = 1 , Name ="Full Madness Pass" , Available = 0 , Price = 293m , TicketsSold = 400000 , FestivalId = 1},
                    new Ticket{Id = 2 , Name ="Rock werchter Weekend" , Available = 15000 , Price = 243m , TicketsSold = 15000 ,FestivalId = 2},
                    new Ticket{Id = 3 , Name = "Pukkelpop combi ticket" , Available = 20000 , Price = 245m , TicketsSold = 2500 , FestivalId = 3},
                    new Ticket{Id = 4 , Name = "Pukkelop day ticket" , Available = 12000 , Price = 115m , TicketsSold = 0 , FestivalId = 3},
                    new Ticket{Id = 5 , Name = "Sunrise Weekend ticket " , Available = 10000 , Price = 120m , TicketsSold= 1555 , FestivalId = 4},
                    new Ticket{Id = 6 , Name = "Sunrise sunday ticket " , Available = 10000 , Price = 60.99m , TicketsSold= 1555 , FestivalId = 4},
                    new Ticket{Id = 7 , Name = "Graspop Weekend ticket " , Available = 12000 , Price = 55.50m , TicketsSold = 1450, FestivalId = 5},
                    new Ticket{Id = 8 , Name = "Qontinent Vip Ticket" , Available = 500 , Price = 175m ,TicketsSold = 200, FestivalId = 6 },
                    new Ticket{Id = 9 , Name = "Qontinent weekend Ticket" , Available = 15000 , Price = 120m ,TicketsSold = 5000 ,  FestivalId = 6}
                });
            modelBuilder.Entity($"{nameof(Artist)}{nameof(Festival)}").HasData
                (
                 new[]
                {
                    new {FestivalsId = 1 , ArtistsId = 1 },
                    new {FestivalsId = 1 , ArtistsId = 2 },
                    new {FestivalsId = 1 , ArtistsId = 7 },
                    new {FestivalsId = 1 , ArtistsId = 8 },
                    new {FestivalsId = 1 , ArtistsId = 12 },
                    new {FestivalsId = 2 , ArtistsId = 4 },
                    new {FestivalsId = 2 , ArtistsId = 3 },
                    new {FestivalsId = 2 , ArtistsId = 7 },
                    new {FestivalsId = 2 , ArtistsId = 8 },
                    new {FestivalsId = 3 , ArtistsId = 5 },
                    new {FestivalsId = 3 , ArtistsId = 6 },
                    new {FestivalsId = 3 , ArtistsId = 4 },
                    new {FestivalsId = 4 , ArtistsId = 7 },
                    new {FestivalsId = 4 , ArtistsId = 8 },
                    new {FestivalsId = 4 , ArtistsId = 11 },
                    new {FestivalsId = 4 , ArtistsId = 12 },
                    new {FestivalsId = 5 , ArtistsId = 9},
                    new {FestivalsId = 5 , ArtistsId = 10},
                    new {FestivalsId = 6 , ArtistsId = 11 },
                    new {FestivalsId = 6 , ArtistsId = 12 },
                });
            IPasswordHasher<ApplicationUser> passwordHasher
                = new PasswordHasher<ApplicationUser>();
            var admin = new ApplicationUser
            {
                Id = "1",
                UserName = "admin@festivals.com",
                NormalizedUserName = "ADMIN@FESTIVALS.COM",
                Email = "admin@festivals.com",
                NormalizedEmail = "ADMIN@FESTIVALS.COM",
                Firstname = "Yordi",
                Lastname = "Van de Velde",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1996, 02, 19),
                City = "Zingem",
                AddressLine = "Kruishoutemsesteenweg 36",
                PostalCode = "9750"
            };
            //hash password
            admin.PasswordHash = passwordHasher.HashPassword(admin, "test");
            //add to applicationuser entity
            modelBuilder.Entity<ApplicationUser>().HasData(admin);
            //add claim to user
            modelBuilder.Entity<IdentityUserClaim<string>>()
                .HasData(new IdentityUserClaim<string>
                {
                    Id = 1,
                    UserId = "1",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "admin"
                });
            var seedUsers = new List<ApplicationUser>();
            seedUsers.Add(new ApplicationUser
            {
                Id = "2",
                UserName = "user@festivals.com",
                NormalizedUserName = "USER@FESTIVALS.COM",
                Email = "user@festivals.com",
                NormalizedEmail = "USER@FESTIVALS.COM",
                Firstname = "jules",
                Lastname = "Van de Velde",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                DateOfBirth = new DateTime(2000, 02, 19),
                City = "Gent",
                AddressLine = "Gentstesteenweg 56",
                PostalCode = "9000"
            });
            seedUsers.Add(new ApplicationUser
            {
                Id = "3",
                UserName = "tom@festivals.com",
                NormalizedUserName = "TOM@FESTIVALS.COM",
                Email = "tom@festivals.com",
                NormalizedEmail = "TOM@FESTIVALS.COM",
                Firstname = "Tom",
                Lastname = "Roels",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1990, 01, 10),
                City = "Antwerpen",
                AddressLine = "Antwerpselaan 5",
                PostalCode = "2000"
            });
            seedUsers.Add(new ApplicationUser
            {
                Id = "4",
                UserName = "laura@festivals.com",
                NormalizedUserName = "LAURA@FESTIVALS.COM",
                Email = "laura@festivals.com",
                NormalizedEmail = "LAURA@FESTIVALS.COM",
                Firstname = "Laura",
                Lastname = "De Waele",
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                EmailConfirmed = true,
                DateOfBirth = new DateTime(1997, 10, 19),
                City = "Drongen",
                AddressLine = " Drongsesteenweg 1",
                PostalCode = "9031"
            });

            foreach (var costumer in seedUsers)
            {
                costumer.PasswordHash = passwordHasher.HashPassword(costumer, "test");
            }

            modelBuilder.Entity<ApplicationUser>().HasData(seedUsers);

            modelBuilder.Entity<IdentityUserClaim<string>>()
               .HasData(
                new IdentityUserClaim<string>
                {
                    Id = 2,
                    UserId = "2",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "customer"
                },
                  new IdentityUserClaim<string>
                  {
                      Id = 3,
                      UserId = "3",
                      ClaimType = ClaimTypes.Role,
                      ClaimValue = "customer"
                  },
                new IdentityUserClaim<string>
                {
                    Id = 4,
                    UserId = "4",
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "customer"
                });
            modelBuilder.Entity<Ticket>().HasMany(t => t.ApplicationUsers).WithMany(t => t.Tickets).UsingEntity(x => x.HasData
                (

                    new { TicketsId = 2, ApplicationUsersId = "4" },
                    new { TicketsId = 4, ApplicationUsersId = "2" }           
                ));
        }
    }
}
