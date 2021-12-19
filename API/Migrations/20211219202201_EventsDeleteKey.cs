using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class EventsDeleteKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Events_RoundId",
                table: "Rounds");

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "Rounds",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "EventsEventId",
                table: "Rounds",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rounds_EventsEventId",
                table: "Rounds",
                column: "EventsEventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Events_EventsEventId",
                table: "Rounds",
                column: "EventsEventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rounds_Events_EventsEventId",
                table: "Rounds");

            migrationBuilder.DropIndex(
                name: "IX_Rounds_EventsEventId",
                table: "Rounds");

            migrationBuilder.DropColumn(
                name: "EventsEventId",
                table: "Rounds");

            migrationBuilder.AlterColumn<int>(
                name: "RoundId",
                table: "Rounds",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rounds_Events_RoundId",
                table: "Rounds",
                column: "RoundId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
