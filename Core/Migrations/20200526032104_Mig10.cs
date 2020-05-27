using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Mig10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelProductId",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "test",
                table: "UserProducts");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "UserProducts",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "UserProducts");

            migrationBuilder.AddColumn<int>(
                name: "HotelProductId",
                table: "UserProducts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "test",
                table: "UserProducts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
