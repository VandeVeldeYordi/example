using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Pe2.Mvc.Migrations
{
    public partial class SeedingPlatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "GamePlatform",
                columns: new[] { "GamesId", "PlatformsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 7, 4 },
                    { 12, 3 },
                    { 11, 3 },
                    { 10, 3 },
                    { 9, 3 },
                    { 8, 3 },
                    { 7, 3 },
                    { 6, 3 },
                    { 5, 3 },
                    { 3, 3 },
                    { 2, 3 },
                    { 1, 3 },
                    { 12, 2 },
                    { 11, 2 },
                    { 8, 2 },
                    { 7, 2 },
                    { 12, 1 },
                    { 11, 1 },
                    { 8, 1 },
                    { 7, 1 },
                    { 4, 1 },
                    { 8, 4 },
                    { 11, 4 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 5, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 6, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 7, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 7, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 7, 4 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 8, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 8, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 8, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 8, 4 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 9, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 10, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 11, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 11, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 11, 3 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 11, 4 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 12, 1 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 12, 2 });

            migrationBuilder.DeleteData(
                table: "GamePlatform",
                keyColumns: new[] { "GamesId", "PlatformsId" },
                keyValues: new object[] { 12, 3 });
        }
    }
}
