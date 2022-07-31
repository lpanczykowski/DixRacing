using Microsoft.EntityFrameworkCore.Migrations;

namespace DixRacing.DataAccess.Migrations
{
    public partial class Add_GameId_To_Tracks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Tracks",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "GameName",
                table: "Tracks",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_GameId",
                table: "Tracks",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Games_GameId",
                table: "Tracks",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Games_GameId",
                table: "Tracks");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_GameId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "GameName",
                table: "Tracks");
        }
    }
}
