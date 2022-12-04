using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Pe2.Mvc.Migrations
{
    public partial class Seeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_Games_GameId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_GameId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "GameProperty",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "int", nullable: false),
                    PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProperty", x => new { x.GamesId, x.PropertiesId });
                    table.ForeignKey(
                        name: "FK_GameProperty_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameProperty_Properties_PropertiesId",
                        column: x => x.PropertiesId,
                        principalTable: "Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shooter" },
                    { 2, "Sports" },
                    { 3, "Role playing" },
                    { 4, "Moba" },
                    { 5, "Action-Adventure" }
                });

            migrationBuilder.InsertData(
                table: "Characters",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 13, "Ellie" },
                    { 12, "Joel" },
                    { 11, "Jak" },
                    { 10, "Ronaldo" },
                    { 9, "Messi" },
                    { 8, "Sully" },
                    { 14, "Ghost" },
                    { 6, "Luna" },
                    { 5, "Dazzle" },
                    { 4, "Geralt" },
                    { 3, "Clank" },
                    { 2, "Ratchet" },
                    { 1, "Kratos" },
                    { 7, "Nathan Drake" }
                });

            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 7, "Infinity ward" },
                    { 5, "Ea Sports" },
                    { 4, "Cd Projekt" },
                    { 6, "Naughty Dog" },
                    { 2, "Valve Corporation" },
                    { 1, "Santa Monica" },
                    { 3, "Insomniac games" }
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Pc" },
                    { 2, "Xbox" },
                    { 3, "Playstation" },
                    { 4, "Nintendo" }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "SubCategory" },
                values: new object[,]
                {
                    { 7, "3+" },
                    { 1, "Blood" },
                    { 2, "Drugs" },
                    { 3, "Violence" },
                    { 4, "Foul language" },
                    { 5, "18+" },
                    { 6, "7+" },
                    { 8, "In-game purchases" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "DeveloperId", "ImagePath", "Name", "Price", "ReleaseDate" },
                values: new object[,]
                {
                    { 1, 5, 1, null, "God of War", 39.99m, null },
                    { 4, 4, 2, null, "Dota 2", 0m, null },
                    { 2, 5, 3, null, "Ratchet and Clank", 19.99m, null },
                    { 3, 5, 3, null, "Ratchet and Clank : A Rift Apart", 69.99m, null },
                    { 11, 3, 4, null, "The Witcher", 24.99m, null },
                    { 7, 2, 5, null, "Fifa 2021", 19.99m, null },
                    { 8, 2, 5, null, "Fifa 2020", 7.99m, null },
                    { 5, 5, 6, null, "Uncharted : Drake's fortune", 9.99m, null },
                    { 6, 5, 6, null, "Uncharted 2:Among thieves ", 14.99m, null },
                    { 9, 5, 6, null, "The last of us", 17.99m, null },
                    { 10, 5, 6, null, "The last of us part 2", 49.99m, null },
                    { 12, 1, 7, null, "Call of duty: Modern Warfare", 55.45m, null }
                });

            migrationBuilder.InsertData(
                table: "CharacterGame",
                columns: new[] { "CharactersId", "GamesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 12, 10 },
                    { 13, 9 },
                    { 12, 9 },
                    { 8, 6 },
                    { 7, 6 },
                    { 8, 5 },
                    { 7, 5 },
                    { 10, 8 },
                    { 13, 10 },
                    { 9, 8 },
                    { 9, 7 },
                    { 4, 11 },
                    { 3, 3 },
                    { 2, 3 },
                    { 3, 2 },
                    { 2, 2 },
                    { 6, 4 },
                    { 5, 4 },
                    { 10, 7 },
                    { 14, 12 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameProperty_PropertiesId",
                table: "GameProperty",
                column: "PropertiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "GameProperty");

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 4, 11 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 5, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 6, 4 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 7, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 7, 6 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 8, 5 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 8, 6 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 9, 7 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 10, 7 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 12, 9 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 13, 9 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 13, 10 });

            migrationBuilder.DeleteData(
                table: "CharacterGame",
                keyColumns: new[] { "CharactersId", "GamesId" },
                keyValues: new object[] { 14, 12 });

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Platforms",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Characters",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Properties",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Properties_GameId",
                table: "Properties",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Categories_CategoryId",
                table: "Games",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_Games_GameId",
                table: "Properties",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
