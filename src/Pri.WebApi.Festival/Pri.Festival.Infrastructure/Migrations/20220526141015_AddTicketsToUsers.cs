using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Pri.Festivals.Infrastructure.Migrations
{
    public partial class AddTicketsToUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Postal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organizers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Festivals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    OrganizerId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Festivals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Festivals_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Festivals_Organizers_OrganizerId",
                        column: x => x.OrganizerId,
                        principalTable: "Organizers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistFestival",
                columns: table => new
                {
                    ArtistsId = table.Column<int>(type: "int", nullable: false),
                    FestivalsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFestival", x => new { x.ArtistsId, x.FestivalsId });
                    table.ForeignKey(
                        name: "FK_ArtistFestival_Artists_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFestival_Festivals_FestivalsId",
                        column: x => x.FestivalsId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Available = table.Column<int>(type: "int", nullable: false),
                    TicketsSold = table.Column<int>(type: "int", nullable: false),
                    FestivalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_Festivals_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festivals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUserTicket",
                columns: table => new
                {
                    ApplicationUsersId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TicketsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserTicket", x => new { x.ApplicationUsersId, x.TicketsId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket_AspNetUsers_ApplicationUsersId",
                        column: x => x.ApplicationUsersId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserTicket_Tickets_TicketsId",
                        column: x => x.TicketsId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "AddressLine", "City", "ConcurrencyStamp", "DateOfBirth", "Email", "EmailConfirmed", "Firstname", "Lastname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "PostalCode", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "Kruishoutemsesteenweg 36", "Zingem", "1e940d21-12e9-4e53-a44a-d94b9ddb754a", new DateTime(1996, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@festivals.com", true, "Yordi", "Van de Velde", false, null, "ADMIN@FESTIVALS.COM", "ADMIN@FESTIVALS.COM", "AQAAAAEAACcQAAAAECq5O7k3RN2jQCXKXNMm1RtF/soMLbFwV46vOOOHz3VC9TKw3l9f7QJQq9K0KIgRnQ==", null, false, "9750", "3f83c1f8-ce8f-4c7d-bf1d-1b58ad675ba2", false, "admin@festivals.com" },
                    { "2", 0, "Gentstesteenweg 56", "Gent", "289082f1-18f7-4973-b62b-e6f6f4d0aefc", new DateTime(2000, 2, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@festivals.com", true, "jules", "Van de Velde", false, null, "USER@FESTIVALS.COM", "USER@FESTIVALS.COM", "AQAAAAEAACcQAAAAEJRZj/5sOHdV5pokb87dCz22QRs2nPKv61ftjT6ZdM57CyqggXRvYn/+at9FV2afrw==", null, false, "9000", "e181e2c2-403d-4d93-a7f6-3978f8427cd0", false, "user@festivals.com" },
                    { "3", 0, "Antwerpselaan 5", "Antwerpen", "0ab4bae4-b3a2-4271-be3b-25209752126c", new DateTime(1990, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "tom@festivals.com", true, "Tom", "Roels", false, null, "TOM@FESTIVALS.COM", "TOM@FESTIVALS.COM", "AQAAAAEAACcQAAAAEEeq0jbUjLlLiQGrb6dZlp3fze0ReaxLwK3GXsLFD2PrATlPo/nBDf+toJpfNUJ1CA==", null, false, "2000", "1d341350-a3c3-4ae6-a601-a06f06ca9df9", false, "tom@festivals.com" },
                    { "4", 0, " Drongsesteenweg 1", "Drongen", "f749bf15-00bd-4cf0-a14f-c2d4f20fe8c8", new DateTime(1997, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "laura@festivals.com", true, "Laura", "De Waele", false, null, "LAURA@FESTIVALS.COM", "LAURA@FESTIVALS.COM", "AQAAAAEAACcQAAAAEBcf3k+bXohd7+Ir/3LAQieFuHnxn5v7vWYhJwutQtfvDg/4R0r2HucMEMq5WrlN9A==", null, false, "9031", "29fd9cfe-728e-43af-ae9a-ce7fc48c2a71", false, "laura@festivals.com" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Electronic dance music", "EDM" },
                    { 2, "Rock & roll , strong beat", "Rock" },
                    { 3, "Rap , r&b en funky music", "Hiphop" },
                    { 4, "Dance music with electronic instruments", "Techno" },
                    { 5, "Intense and powerful", "Metal" },
                    { 6, "Bpm range from 140 to 180", "Hard dance" }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "City", "Name", "Postal" },
                values: new object[,]
                {
                    { 6, "Wachtebeke", "provinciaal domein", "9185" },
                    { 5, "Dessel", "Kastelsedijk", "2480" },
                    { 4, "Gierle", "Beersebaan", "2275" },
                    { 1, "Boom", "PRC de Schorre", "2850" },
                    { 2, "Werchter", "Haachsesteenweg", "3118" },
                    { 3, "Hasselt", "Kempische Steenweg", "3500" }
                });

            migrationBuilder.InsertData(
                table: "Organizers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 5, "Peter Van Geel" },
                    { 1, "We Are One World" },
                    { 2, "Herman Schueremans" },
                    { 3, "Chokri Mahassine" },
                    { 4, "Sunrise Festival" },
                    { 6, "Bass events" }
                });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "GenreId", "Image", "Name" },
                values: new object[,]
                {
                    { 7, 4, "charlotte.jpg", "Charlotte de Witte" },
                    { 12, 6, "sefa.jpg", "Sefa" },
                    { 11, 6, "rebelion.jpg", "Rebelion" },
                    { 10, 5, "iron.jpg", "Iron Maiden" },
                    { 1, 1, "arminvb.jpg", "Armin van Buuren" },
                    { 2, 1, "martin.jpg", "Martin Garrix" },
                    { 3, 2, "wardrugs.jpg", "The war on drugs" },
                    { 4, 2, "chili.jpg", "Red hot chili peppers" },
                    { 5, 3, "drake.jpg", "Drake" },
                    { 6, 3, "ye.jpg", "Ye" },
                    { 9, 5, "rammstein.jpg", "Rammstein" },
                    { 8, 4, "amelie.jpg", "Amelie Lense" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "UserId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "admin", "1" },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "customer", "4" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "customer", "3" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "customer", "2" }
                });

            migrationBuilder.InsertData(
                table: "Festivals",
                columns: new[] { "Id", "Description", "EndDate", "Image", "LocationId", "Name", "OrganizerId", "StartDate" },
                values: new object[,]
                {
                    { 1, "Belgium's biggest dance festival", new DateTime(2022, 7, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "tomorrowland.jpg", 1, "Tomorrowland", 1, new DateTime(2022, 7, 15, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Pop and rock festival", new DateTime(2022, 7, 3, 12, 0, 0, 0, DateTimeKind.Unspecified), "rock.jpg", 2, "Rock Werchter", 2, new DateTime(2022, 6, 30, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "pop music festival", new DateTime(2022, 8, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), "pukkelpop.jpg", 3, "Pukkelpop", 3, new DateTime(2022, 8, 18, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Escape into Happiness!", new DateTime(2022, 7, 26, 12, 0, 0, 0, DateTimeKind.Unspecified), "sunrise.jpg", 4, "Sunrise festival", 4, new DateTime(2022, 6, 24, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Graspop metal meeting", new DateTime(2022, 6, 19, 12, 0, 0, 0, DateTimeKind.Unspecified), "graspop.jpg", 5, "Graspop", 5, new DateTime(2022, 6, 16, 6, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, "Breaking boundaries", new DateTime(2022, 8, 14, 12, 0, 0, 0, DateTimeKind.Unspecified), "qontinent.jpg", 6, "Qontinent", 6, new DateTime(2022, 8, 12, 6, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ArtistFestival",
                columns: new[] { "ArtistsId", "FestivalsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 11, 4 },
                    { 8, 4 },
                    { 7, 4 },
                    { 10, 5 },
                    { 4, 3 },
                    { 6, 3 },
                    { 5, 3 },
                    { 12, 4 },
                    { 11, 6 },
                    { 7, 2 },
                    { 3, 2 },
                    { 4, 2 },
                    { 12, 6 },
                    { 12, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 2, 1 },
                    { 8, 2 },
                    { 9, 5 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "Available", "FestivalId", "Name", "Price", "TicketsSold" },
                values: new object[,]
                {
                    { 7, 12000, 5, "Graspop Weekend ticket ", 55.50m, 1450 },
                    { 3, 20000, 3, "Pukkelpop combi ticket", 245m, 2500 },
                    { 5, 10000, 4, "Sunrise Weekend ticket ", 120m, 1555 },
                    { 4, 12000, 3, "Pukkelop day ticket", 115m, 0 },
                    { 8, 500, 6, "Qontinent Vip Ticket", 175m, 200 },
                    { 2, 15000, 2, "Rock werchter Weekend", 243m, 15000 },
                    { 1, 0, 1, "Full Madness Pass", 293m, 400000 },
                    { 6, 10000, 4, "Sunrise sunday ticket ", 60.99m, 1555 },
                    { 9, 15000, 6, "Qontinent weekend Ticket", 120m, 5000 }
                });

            migrationBuilder.InsertData(
                table: "ApplicationUserTicket",
                columns: new[] { "ApplicationUsersId", "TicketsId" },
                values: new object[] { "4", 2 });

            migrationBuilder.InsertData(
                table: "ApplicationUserTicket",
                columns: new[] { "ApplicationUsersId", "TicketsId" },
                values: new object[] { "2", 4 });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserTicket_TicketsId",
                table: "ApplicationUserTicket",
                column: "TicketsId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFestival_FestivalsId",
                table: "ArtistFestival",
                column: "FestivalsId");

            migrationBuilder.CreateIndex(
                name: "IX_Artists_GenreId",
                table: "Artists",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_LocationId",
                table: "Festivals",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Festivals_OrganizerId",
                table: "Festivals",
                column: "OrganizerId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_FestivalId",
                table: "Tickets",
                column: "FestivalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserTicket");

            migrationBuilder.DropTable(
                name: "ArtistFestival");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Festivals");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Organizers");
        }
    }
}
