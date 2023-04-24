using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADACA.Migrations
{
    public partial class updateAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "aboveAmount",
                value: 99999);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "aboveAmount",
                value: 9999);
        }
    }
}
