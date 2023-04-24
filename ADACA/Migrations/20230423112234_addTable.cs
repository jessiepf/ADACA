using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADACA.Migrations
{
    public partial class addTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "timeTrading",
                table: "Loans",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "LoanAmountConfigs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    aboveAmount = table.Column<int>(type: "int", nullable: false),
                    belowAmount = table.Column<int>(type: "int", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanAmountConfigs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoanAmountConfigs",
                columns: new[] { "Id", "aboveAmount", "belowAmount", "type" },
                values: new object[] { 1, 9999, 10001, 1 });

            migrationBuilder.InsertData(
                table: "LoanAmountConfigs",
                columns: new[] { "Id", "aboveAmount", "belowAmount", "type" },
                values: new object[] { 2, 2, 19, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanAmountConfigs");

            migrationBuilder.AlterColumn<string>(
                name: "timeTrading",
                table: "Loans",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
