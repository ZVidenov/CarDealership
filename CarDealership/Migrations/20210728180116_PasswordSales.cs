using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Migrations
{
    public partial class PasswordSales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Salesmen",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Profits",
                table: "Salesmen",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Salesmen");

            migrationBuilder.DropColumn(
                name: "Profits",
                table: "Salesmen");
        }
    }
}
