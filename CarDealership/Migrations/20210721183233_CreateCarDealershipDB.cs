using Microsoft.EntityFrameworkCore.Migrations;

namespace CarDealership.Migrations
{
    public partial class CreateCarDealershipDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinanceHouses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceHouses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    SalesmanId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cars_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesmenHouses",
                columns: table => new
                {
                    SalesmanId = table.Column<int>(type: "int", nullable: false),
                    FinanceHouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesmenHouses", x => new { x.SalesmanId, x.FinanceHouseId });
                    table.ForeignKey(
                        name: "FK_SalesmenHouses_FinanceHouses_FinanceHouseId",
                        column: x => x.FinanceHouseId,
                        principalTable: "FinanceHouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesmenHouses_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SalesmanId",
                table: "Cars",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesmenHouses_FinanceHouseId",
                table: "SalesmenHouses",
                column: "FinanceHouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cars");

            migrationBuilder.DropTable(
                name: "SalesmenHouses");

            migrationBuilder.DropTable(
                name: "FinanceHouses");

            migrationBuilder.DropTable(
                name: "Salesmen");
        }
    }
}
