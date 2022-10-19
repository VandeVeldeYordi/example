using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Pe2.Mvc.Migrations
{
    public partial class SeedingImagePath : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GameProperty",
                columns: new[] { "GamesId", "PropertiesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 6, 6 },
                    { 9, 6 },
                    { 10, 6 },
                    { 3, 7 },
                    { 7, 7 },
                    { 8, 7 },
                    { 1, 8 },
                    { 2, 8 },
                    { 5, 6 },
                    { 3, 8 },
                    { 5, 8 },
                    { 6, 8 },
                    { 7, 8 },
                    { 8, 8 },
                    { 9, 8 },
                    { 10, 8 },
                    { 11, 8 },
                    { 12, 8 },
                    { 4, 8 },
                    { 4, 6 },
                    { 2, 7 },
                    { 11, 5 },
                    { 5, 1 },
                    { 6, 1 },
                    { 11, 1 },
                    { 12, 1 },
                    { 12, 5 },
                    { 4, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 11, 2 },
                    { 9, 3 },
                    { 10, 3 },
                    { 11, 3 },
                    { 12, 3 },
                    { 8, 3 },
                    { 1, 4 },
                    { 11, 4 },
                    { 12, 4 }
                });

            migrationBuilder.InsertData(
                table: "GameProperty",
                columns: new[] { "GamesId", "PropertiesId" },
                values: new object[] { 1, 5 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "godOfWar");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "ratchet");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "riftApart");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: "dota");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: "uncharted");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: "uncharted2");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: "fifa21");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: "fifa20");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: "lastofus");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: "lastofus2");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: "witcher");

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: "cod");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 1, 4 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 1, 5 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 2, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 3, 7 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 6, 1 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 6, 6 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 6, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 7, 7 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 7, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 8, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 9, 6 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 10, 6 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 10, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 5 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 11, 8 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 12, 3 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 12, 4 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 12, 5 });

            migrationBuilder.DeleteData(
                table: "GameProperty",
                keyColumns: new[] { "GamesId", "PropertiesId" },
                keyValues: new object[] { 12, 8 });

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 4,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 5,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 6,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 7,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 8,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 9,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 10,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 11,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 12,
                column: "ImagePath",
                value: null);
        }
    }
}
