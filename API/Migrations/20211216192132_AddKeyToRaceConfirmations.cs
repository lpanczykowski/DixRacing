using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddKeyToRaceConfirmations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RaceConfirmationId",
                table: "RaceConfirmations",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0)
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceConfirmations",
                table: "RaceConfirmations",
                column: "RaceConfirmationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceConfirmations",
                table: "RaceConfirmations");

            migrationBuilder.DropColumn(
                name: "RaceConfirmationId",
                table: "RaceConfirmations");
        }
    }
}
