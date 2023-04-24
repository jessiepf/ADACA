using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ADACA.Migrations
{
    public partial class removeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "LoanAmountConfigs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "LoanAmountConfigs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 1,
                column: "type",
                value: 1);

            migrationBuilder.UpdateData(
                table: "LoanAmountConfigs",
                keyColumn: "Id",
                keyValue: 2,
                column: "type",
                value: 2);
        }
    }
}
