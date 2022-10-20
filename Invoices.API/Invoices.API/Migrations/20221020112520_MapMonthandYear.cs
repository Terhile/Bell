using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Invoices.API.Migrations
{
    public partial class MapMonthandYear : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueMonth",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IssueYear",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueMonth",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "IssueYear",
                table: "Invoices");
        }
    }
}
