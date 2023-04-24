using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADACA.Migrations
{
    public partial class reverseAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "aboveAmount", "belowAmount" },
                values: new object[] { 19, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "aboveAmount", "belowAmount" },
                values: new object[] { 2, 19 });
        }
    }
}
