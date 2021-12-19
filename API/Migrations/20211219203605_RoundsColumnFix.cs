using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class RoundsColumnFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SeverPassword",
                table: "Rounds",
                newName: "ServerPassword");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServerPassword",
                table: "Rounds",
                newName: "SeverPassword");
        }
    }
}
