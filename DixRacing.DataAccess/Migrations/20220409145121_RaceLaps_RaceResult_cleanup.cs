using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class RaceLaps_RaceResult_cleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsValid",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Lap",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "PenaltyPoints",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "Split1",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "UserSteamId",
                table: "RaceResults");

            migrationBuilder.RenameColumn(
                name: "Split3",
                table: "RaceResults",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Split2",
                table: "RaceResults",
                newName: "IncidentId");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "RaceLaps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserSteamId = table.Column<string>(type: "TEXT", nullable: true),
                    Lap = table.Column<int>(type: "INTEGER", nullable: false),
                    Split1 = table.Column<int>(type: "INTEGER", nullable: false),
                    Split2 = table.Column<int>(type: "INTEGER", nullable: false),
                    Split3 = table.Column<int>(type: "INTEGER", nullable: false),
                    IsValid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaceLaps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RaceLaps_Races_RaceId",
                        column: x => x.RaceId,
                        principalTable: "Races",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RaceLaps_RaceId",
                table: "RaceLaps",
                column: "RaceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RaceLaps");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "RaceResults",
                newName: "Split3");

            migrationBuilder.RenameColumn(
                name: "IncidentId",
                table: "RaceResults",
                newName: "Split2");

            migrationBuilder.AlterColumn<int>(
                name: "Position",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "IsValid",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Lap",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PenaltyPoints",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "Points",
                table: "RaceResults",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "Split1",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserSteamId",
                table: "RaceResults",
                type: "TEXT",
                nullable: true);
        }
    }
}
