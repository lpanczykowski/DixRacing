using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class Add_Table_RaceIncidents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaceIncidents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReportedUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsSolved = table.Column<int>(type: "INTEGER", nullable: true),
                    Time = table.Column<int>(type: "INTEGER", nullable: false),
                    Lap = table.Column<int>(type: "INTEGER", nullable: false),
                    PointPenalty = table.Column<int>(type: "INTEGER", nullable: true),
                    TimePenalty = table.Column<int>(type: "INTEGER", nullable: true),
                    Penalty = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceIncidents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceIncidents_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceIncidents_RaceId",
                table: "RaceIncidents",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceIncidents");
        }
    }
}
