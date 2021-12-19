using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Tracks_TrackId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_TrackId",
                table: "Races");

            migrationBuilder.RenameColumn(
                name: "TrackId",
                table: "Races",
                newName: "RoundId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Races",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Races",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "Rounds",
                columns: table => new
                {
                    RoundId = table.Column<int>(type: "INTEGER", nullable: false),
                    EventId = table.Column<int>(type: "INTEGER", nullable: false),
                    ServerName = table.Column<string>(type: "TEXT", nullable: true),
                    SeverPassword = table.Column<string>(type: "TEXT", nullable: true),
                    TrackId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rounds", x => x.RoundId);
                    table.ForeignKey(
                        name: "FK_Rounds_Events_RoundId",
                        column: x => x.RoundId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rounds_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "TrackId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_TrackId",
                table: "Rounds",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Rounds_RaceId",
                table: "Races",
                column: "RaceId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Rounds_RaceId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Rounds");

            migrationBuilder.RenameColumn(
                name: "RoundId",
                table: "Races",
                newName: "TrackId");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Races",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Races",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_TrackId",
                table: "Races",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Tracks_TrackId",
                table: "Races",
                column: "TrackId",
                principalTable: "Tracks",
                principalColumn: "TrackId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
