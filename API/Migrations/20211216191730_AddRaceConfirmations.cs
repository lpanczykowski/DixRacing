using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class AddRaceConfirmations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersRaces_Races_RoundId",
                table: "UsersRaces");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRaces_Users_UserId",
                table: "UsersRaces");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersRaces",
                table: "UsersRaces");

            migrationBuilder.RenameTable(
                name: "UsersRaces",
                newName: "RaceResults");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRaces_UserId",
                table: "RaceResults",
                newName: "IX_RaceResults_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersRaces_RoundId",
                table: "RaceResults",
                newName: "IX_RaceResults_RoundId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Games",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "RaceResults",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<int>(
                name: "RaceId",
                table: "RaceResults",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults",
                column: "RaceResultId");

            migrationBuilder.CreateTable(
                name: "RaceConfirmations",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INTEGER", nullable: false),
                    RaceId = table.Column<int>(type: "INTEGER", nullable: false),
                    Confrimed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Races_RoundId",
                table: "RaceResults",
                column: "RoundId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RaceResults_Users_UserId",
                table: "RaceResults",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Races_RoundId",
                table: "RaceResults");

            migrationBuilder.DropForeignKey(
                name: "FK_RaceResults_Users_UserId",
                table: "RaceResults");

            migrationBuilder.DropTable(
                name: "RaceConfirmations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RaceResults",
                table: "RaceResults");

            migrationBuilder.DropColumn(
                name: "RaceId",
                table: "RaceResults");

            migrationBuilder.RenameTable(
                name: "RaceResults",
                newName: "UsersRaces");

            migrationBuilder.RenameIndex(
                name: "IX_RaceResults_UserId",
                table: "UsersRaces",
                newName: "IX_UsersRaces_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_RaceResults_RoundId",
                table: "UsersRaces",
                newName: "IX_UsersRaces_RoundId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "UsersRaces",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersRaces",
                table: "UsersRaces",
                column: "RaceResultId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRaces_Races_RoundId",
                table: "UsersRaces",
                column: "RoundId",
                principalTable: "Races",
                principalColumn: "RaceId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRaces_Users_UserId",
                table: "UsersRaces",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
