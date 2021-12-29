using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddedForeginKeyRacesRounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Rounds_RoundsRoundId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_RoundsRoundId",
                table: "Races");

            migrationBuilder.DropColumn(
                name: "RoundsRoundId",
                table: "Races");

            migrationBuilder.CreateIndex(
                name: "IX_Races_RoundId",
                table: "Races",
                column: "RoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Rounds_RoundId",
                table: "Races",
                column: "RoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Rounds_RoundId",
                table: "Races");

            migrationBuilder.DropIndex(
                name: "IX_Races_RoundId",
                table: "Races");

            migrationBuilder.AddColumn<int>(
                name: "RoundsRoundId",
                table: "Races",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Races_RoundsRoundId",
                table: "Races",
                column: "RoundsRoundId");

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Rounds_RoundsRoundId",
                table: "Races",
                column: "RoundsRoundId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
