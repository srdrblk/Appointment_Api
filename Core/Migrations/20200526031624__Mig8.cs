using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class _Mig8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Detail",
                table: "UserProducts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WithWho",
                table: "UserProducts",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Detail",
                table: "UserProducts");

            migrationBuilder.DropColumn(
                name: "WithWho",
                table: "UserProducts");
        }
    }
}
