﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wba.Pe2.Mvc.Data;

namespace Wba.Pe2.Mvc.Migrations
{
    [DbContext(typeof(GameContext))]
    [Migration("20220104121254_FixEntityGame")]
    partial class FixEntityGame
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "GamesId");

                    b.HasIndex("GamesId");

                    b.ToTable("CharacterGame");

                    b.HasData(
                        new
                        {
                            CharactersId = 1,
                            GamesId = 1
                        },
                        new
                        {
                            CharactersId = 2,
                            GamesId = 2
                        },
                        new
                        {
                            CharactersId = 2,
                            GamesId = 3
                        },
                        new
                        {
                            CharactersId = 3,
                            GamesId = 2
                        },
                        new
                        {
                            CharactersId = 3,
                            GamesId = 3
                        },
                        new
                        {
                            CharactersId = 4,
                            GamesId = 11
                        },
                        new
                        {
                            CharactersId = 5,
                            GamesId = 4
                        },
                        new
                        {
                            CharactersId = 6,
                            GamesId = 4
                        },
                        new
                        {
                            CharactersId = 7,
                            GamesId = 5
                        },
                        new
                        {
                            CharactersId = 7,
                            GamesId = 6
                        },
                        new
                        {
                            CharactersId = 8,
                            GamesId = 5
                        },
                        new
                        {
                            CharactersId = 8,
                            GamesId = 6
                        },
                        new
                        {
                            CharactersId = 9,
                            GamesId = 7
                        },
                        new
                        {
                            CharactersId = 9,
                            GamesId = 8
                        },
                        new
                        {
                            CharactersId = 10,
                            GamesId = 7
                        },
                        new
                        {
                            CharactersId = 10,
                            GamesId = 8
                        },
                        new
                        {
                            CharactersId = 12,
                            GamesId = 9
                        },
                        new
                        {
                            CharactersId = 12,
                            GamesId = 10
                        },
                        new
                        {
                            CharactersId = 13,
                            GamesId = 9
                        },
                        new
                        {
                            CharactersId = 13,
                            GamesId = 10
                        },
                        new
                        {
                            CharactersId = 14,
                            GamesId = 12
                        });
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PlatformsId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PlatformsId");

                    b.HasIndex("PlatformsId");

                    b.ToTable("GamePlatform");

                    b.HasData(
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 4,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 7,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 8,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 11,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 12,
                            PlatformsId = 1
                        },
                        new
                        {
                            GamesId = 7,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 8,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 11,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 12,
                            PlatformsId = 2
                        },
                        new
                        {
                            GamesId = 1,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 2,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 3,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 5,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 6,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 7,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 8,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 9,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 10,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 11,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 12,
                            PlatformsId = 3
                        },
                        new
                        {
                            GamesId = 7,
                            PlatformsId = 4
                        },
                        new
                        {
                            GamesId = 8,
                            PlatformsId = 4
                        },
                        new
                        {
                            GamesId = 11,
                            PlatformsId = 4
                        });
                });

            modelBuilder.Entity("GameProperty", b =>
                {
                    b.Property<int>("GamesId")
                        .HasColumnType("int");

                    b.Property<int>("PropertiesId")
                        .HasColumnType("int");

                    b.HasKey("GamesId", "PropertiesId");

                    b.HasIndex("PropertiesId");

                    b.ToTable("GameProperty");

                    b.HasData(
                        new
                        {
                            GamesId = 1,
                            PropertiesId = 1
                        },
                        new
                        {
                            GamesId = 5,
                            PropertiesId = 1
                        },
                        new
                        {
                            GamesId = 6,
                            PropertiesId = 1
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 1
                        },
                        new
                        {
                            GamesId = 12,
                            PropertiesId = 1
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 2
                        },
                        new
                        {
                            GamesId = 4,
                            PropertiesId = 2
                        },
                        new
                        {
                            GamesId = 1,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 2,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 3,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 4,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 8,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 9,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 10,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 12,
                            PropertiesId = 3
                        },
                        new
                        {
                            GamesId = 1,
                            PropertiesId = 4
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 4
                        },
                        new
                        {
                            GamesId = 12,
                            PropertiesId = 4
                        },
                        new
                        {
                            GamesId = 1,
                            PropertiesId = 5
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 5
                        },
                        new
                        {
                            GamesId = 12,
                            PropertiesId = 5
                        },
                        new
                        {
                            GamesId = 4,
                            PropertiesId = 6
                        },
                        new
                        {
                            GamesId = 5,
                            PropertiesId = 6
                        },
                        new
                        {
                            GamesId = 6,
                            PropertiesId = 6
                        },
                        new
                        {
                            GamesId = 9,
                            PropertiesId = 6
                        },
                        new
                        {
                            GamesId = 10,
                            PropertiesId = 6
                        },
                        new
                        {
                            GamesId = 2,
                            PropertiesId = 7
                        },
                        new
                        {
                            GamesId = 3,
                            PropertiesId = 7
                        },
                        new
                        {
                            GamesId = 7,
                            PropertiesId = 7
                        },
                        new
                        {
                            GamesId = 8,
                            PropertiesId = 7
                        },
                        new
                        {
                            GamesId = 1,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 2,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 3,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 4,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 5,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 6,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 7,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 8,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 9,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 10,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 11,
                            PropertiesId = 8
                        },
                        new
                        {
                            GamesId = 12,
                            PropertiesId = 8
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Shooter"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sports"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Role playing"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Moba"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Action-Adventure"
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Kratos"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Ratchet"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Clank"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Geralt"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Dazzle"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Luna"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Nathan Drake"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Sully"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Messi"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Ronaldo"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Jak"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Joel"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Ellie"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Ghost"
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Santa Monica"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Valve Corporation"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Insomniac games"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Cd Projekt"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Ea Sports"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Naughty Dog"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Infinity ward"
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int?>("DeveloperId")
                        .HasColumnType("int");

                    b.Property<string>("ImagePath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DeveloperId");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 5,
                            DeveloperId = 1,
                            ImagePath = "godOfWar.png",
                            Name = "God of War",
                            Price = 39.99m,
                            ReleaseDate = new DateTime(2018, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 5,
                            DeveloperId = 3,
                            ImagePath = "ratchet.png",
                            Name = "Ratchet and Clank",
                            Price = 19.99m,
                            ReleaseDate = new DateTime(2016, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 5,
                            DeveloperId = 3,
                            ImagePath = "riftApart.png",
                            Name = "Ratchet and Clank : A Rift Apart",
                            Price = 69.99m,
                            ReleaseDate = new DateTime(2021, 6, 11, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            DeveloperId = 2,
                            ImagePath = "dota.png",
                            Name = "Dota 2",
                            Price = 0m,
                            ReleaseDate = new DateTime(2013, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 5,
                            DeveloperId = 6,
                            ImagePath = "uncharted.png",
                            Name = "Uncharted : Drake's fortune",
                            Price = 9.99m,
                            ReleaseDate = new DateTime(2007, 11, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 6,
                            CategoryId = 5,
                            DeveloperId = 6,
                            ImagePath = "uncharted2.png",
                            Name = "Uncharted 2:Among thieves ",
                            Price = 14.99m,
                            ReleaseDate = new DateTime(2009, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 7,
                            CategoryId = 2,
                            DeveloperId = 5,
                            ImagePath = "fifa21.png",
                            Name = "Fifa 2021",
                            Price = 19.99m,
                            ReleaseDate = new DateTime(2020, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 8,
                            CategoryId = 2,
                            DeveloperId = 5,
                            ImagePath = "fifa20.png",
                            Name = "Fifa 2020",
                            Price = 7.99m,
                            ReleaseDate = new DateTime(2019, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 9,
                            CategoryId = 5,
                            DeveloperId = 6,
                            ImagePath = "lastofus.png",
                            Name = "The last of us",
                            Price = 17.99m,
                            ReleaseDate = new DateTime(2013, 6, 14, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 10,
                            CategoryId = 5,
                            DeveloperId = 6,
                            ImagePath = "lastofus2.png",
                            Name = "The last of us part 2",
                            Price = 49.99m,
                            ReleaseDate = new DateTime(2020, 6, 19, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 11,
                            CategoryId = 3,
                            DeveloperId = 4,
                            ImagePath = "witcher.png",
                            Name = "The Witcher",
                            Price = 24.99m,
                            ReleaseDate = new DateTime(2019, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 12,
                            CategoryId = 1,
                            DeveloperId = 7,
                            ImagePath = "cod.png",
                            Name = "Call of duty: Modern Warfare",
                            Price = 55.45m,
                            ReleaseDate = new DateTime(2019, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Platform", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Pc"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Xbox"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Playstation"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Nintendo"
                        });
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Property", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("SubCategory")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("Id");

                    b.ToTable("Properties");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            SubCategory = "Blood"
                        },
                        new
                        {
                            Id = 2,
                            SubCategory = "Drugs"
                        },
                        new
                        {
                            Id = 3,
                            SubCategory = "Violence"
                        },
                        new
                        {
                            Id = 4,
                            SubCategory = "Foul language"
                        },
                        new
                        {
                            Id = 5,
                            SubCategory = "18+"
                        },
                        new
                        {
                            Id = 6,
                            SubCategory = "7+"
                        },
                        new
                        {
                            Id = 7,
                            SubCategory = "3+"
                        },
                        new
                        {
                            Id = 8,
                            SubCategory = "In-game purchases"
                        });
                });

            modelBuilder.Entity("CharacterGame", b =>
                {
                    b.HasOne("Wba.Pe2.Domain.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wba.Pe2.Domain.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamePlatform", b =>
                {
                    b.HasOne("Wba.Pe2.Domain.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wba.Pe2.Domain.Platform", null)
                        .WithMany()
                        .HasForeignKey("PlatformsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GameProperty", b =>
                {
                    b.HasOne("Wba.Pe2.Domain.Game", null)
                        .WithMany()
                        .HasForeignKey("GamesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wba.Pe2.Domain.Property", null)
                        .WithMany()
                        .HasForeignKey("PropertiesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Game", b =>
                {
                    b.HasOne("Wba.Pe2.Domain.Category", "Category")
                        .WithMany("Games")
                        .HasForeignKey("CategoryId");

                    b.HasOne("Wba.Pe2.Domain.Developer", "Developer")
                        .WithMany("Games")
                        .HasForeignKey("DeveloperId");

                    b.Navigation("Category");

                    b.Navigation("Developer");
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Category", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("Wba.Pe2.Domain.Developer", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}