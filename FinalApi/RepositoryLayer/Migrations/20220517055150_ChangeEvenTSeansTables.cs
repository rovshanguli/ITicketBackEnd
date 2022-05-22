using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace RepositoryLayer.Migrations
{
    public partial class ChangeEvenTSeansTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Afternoon",
                table: "Seans");

            migrationBuilder.DropColumn(
                name: "Morning",
                table: "Seans");

            migrationBuilder.DropColumn(
                name: "End",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Night",
                table: "Seans",
                newName: "Hour");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Event",
                newName: "Date");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Seans",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<byte[]>(
                name: "BackImage",
                table: "Event",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Event",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Event",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Seans");

            migrationBuilder.DropColumn(
                name: "BackImage",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Event");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Event");

            migrationBuilder.RenameColumn(
                name: "Hour",
                table: "Seans",
                newName: "Night");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Event",
                newName: "Start");

            migrationBuilder.AddColumn<DateTime>(
                name: "Afternoon",
                table: "Seans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Morning",
                table: "Seans",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "End",
                table: "Event",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
