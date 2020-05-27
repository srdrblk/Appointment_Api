using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Migrations
{
    public partial class Mig7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices");

            migrationBuilder.RenameTable(
                name: "UserServices",
                newName: "UserProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProducts",
                table: "UserProducts");

            migrationBuilder.RenameTable(
                name: "UserProducts",
                newName: "UserServices");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserServices",
                table: "UserServices",
                column: "Id");
        }
    }
}
