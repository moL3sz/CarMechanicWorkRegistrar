using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRegistrarAPI.Migrations
{
    public partial class LogicDeleteCreatedDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Workflows",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Workflows",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Active",
                table: "Workflows");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Workflows");
        }
    }
}
