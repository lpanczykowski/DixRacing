using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class RaceResult_AddColumn_TotalTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IncidentId",
                table: "RaceResults",
                newName: "TotalTime");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalTime",
                table: "RaceResults",
                newName: "IncidentId");
        }
    }
}
