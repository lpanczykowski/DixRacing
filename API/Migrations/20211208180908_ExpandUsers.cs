using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ExpandUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Users",
                newName: "Surname");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Users",
                newName: "Nick");

            migrationBuilder.RenameColumn(
                name: "Nickname",
                table: "Users",
                newName: "Name");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "BLOB",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "BLOB",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "Surname",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Nick",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Users",
                newName: "Nickname");
        }
    }
}
