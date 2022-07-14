using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class RaceIncidentUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppealDescription",
                table: "RaceIncidents",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AppealDescription",
                table: "RaceIncidents");
        }
    }
}
