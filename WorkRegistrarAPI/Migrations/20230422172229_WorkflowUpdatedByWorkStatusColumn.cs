using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WorkRegistrarAPI.Migrations
{
    public partial class WorkflowUpdatedByWorkStatusColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WorkStatus",
                table: "Workflows",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkStatus",
                table: "Workflows");
        }
    }
}
