using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class EditBalanceIdInEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_EmployeeId",
                table: "Balances");

            migrationBuilder.DropColumn(
                name: "BalanceId",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_EmployeeId",
                table: "Balances",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Balances_EmployeeId",
                table: "Balances");

            migrationBuilder.AddColumn<decimal>(
                name: "BalanceId",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Balances_EmployeeId",
                table: "Balances",
                column: "EmployeeId",
                unique: true);
        }
    }
}
