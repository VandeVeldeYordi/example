using Microsoft.EntityFrameworkCore.Migrations;

namespace Wba.Pe2.Mvc.Migrations
{
    public partial class UpdateGameEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Games",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Games",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Games");
        }
    }
}
