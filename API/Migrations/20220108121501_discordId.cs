using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class discordId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Races_RoundId",
                table: "RaceResults");

            migrationBuilder.DropIndex(
                name: "IX_RaceResults_RoundId",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "RoundId",
                table: "RaceResults");

            migrationBuilder.AddColumn<string>(
                name: "DiscordId",
                table: "Users",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PenaltyPoints",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DiscordId",
                table: "Users");

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
        }
    }
}
