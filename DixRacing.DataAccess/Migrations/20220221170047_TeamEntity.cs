using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class TeamEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Team",
                table: "EventParticipants");

            migrationBuilder.AddColumn<int>(
                name: "TeamId",
                table: "EventParticipants",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_TeamId",
                table: "EventParticipants",
                column: "TeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Teams_TeamId",
                table: "EventParticipants",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Teams_TeamId",
                table: "EventParticipants");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_TeamId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "TeamId",
                table: "EventParticipants");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "EventParticipants",
                type: "TEXT",
                nullable: true);
        }
    }
}
