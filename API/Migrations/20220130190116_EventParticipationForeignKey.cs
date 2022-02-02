using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EventParticipationForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Races_RoundId",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Weathers_WeatherId",
                table: "Races");

            migrationBuilder.DropTable(
                name: "Weathers");

            migrationBuilder.DropIndex(
                name: "IX_Races_WeatherId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_RoundId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "WeatherId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "RaceResults");

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
                name: "PenaltyPoints",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<string>(
                name: "Team",
                table: "EventParticipants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventParticipants_Users_UserId",
                table: "EventParticipants",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventParticipants_Users_UserId",
                table: "EventParticipants");

            migrationBuilder.DropForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_EventParticipants_UserId",
                table: "EventParticipants");

            migrationBuilder.DropColumn(
                name: "Team",
                table: "EventParticipants");

            migrationBuilder.AlterColumn<int>(
                name: "EventId",
                table: "Races",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "WeatherId",
                table: "Races",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PenaltyPoints",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoundId",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Weathers",
                columns: table => new
                {
                    WeatherId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weathers", x => x.WeatherId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Races_WeatherId",
                table: "Races",
                column: "WeatherId");

            migrationBuilder.CreateIndex(
                name: "IX_RaceResults_RoundId",
                table: "RaceResults",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Races_RoundId",
                table: "RaceResults",
                column: "RoundId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Events_EventId",
                table: "Races",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Weathers_WeatherId",
                table: "Races",
                column: "WeatherId",
                principalTable: "Weathers",
                principalColumn: "WeatherId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
