using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class Rounds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Races_Rounds_RaceId",
                table: "Races");

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Races",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "RaceId",
                table: "Races",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Races_Rounds_RaceId",
                table: "Races",
                column: "RaceId",
                principalTable: "Rounds",
                principalColumn: "RoundId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
