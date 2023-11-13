using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentOptions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceHistories_Balances_BalanceId",
                table: "BalanceHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionEmployee_Employee_EmployeeId",
                table: "PaymentOptionEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionEmployee_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentOptionEmployee",
                table: "PaymentOptionEmployee");

            migrationBuilder.DropIndex(
                name: "IX_BalanceHistories_BalanceId",
                table: "BalanceHistories");

            migrationBuilder.RenameTable(
                name: "PaymentOptionEmployee",
                newName: "paymentOptionEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionEmployee_PaymentOptionId",
                table: "paymentOptionEmployee",
                newName: "IX_paymentOptionEmployee_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionEmployee_EmployeeId",
                table: "paymentOptionEmployee",
                newName: "IX_paymentOptionEmployee_EmployeeId");

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "BalanceHistories",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentOptionEmployee",
                table: "paymentOptionEmployee",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_paymentOptionEmployee_Employee_EmployeeId",
                table: "paymentOptionEmployee",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_paymentOptionEmployee_PaymentOptions_PaymentOptionId",
                table: "paymentOptionEmployee",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_paymentOptionEmployee_Employee_EmployeeId",
                table: "paymentOptionEmployee");

            migrationBuilder.DropForeignKey(
                name: "FK_paymentOptionEmployee_PaymentOptions_PaymentOptionId",
                table: "paymentOptionEmployee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentOptionEmployee",
                table: "paymentOptionEmployee");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "BalanceHistories");

            migrationBuilder.RenameTable(
                name: "paymentOptionEmployee",
                newName: "PaymentOptionEmployee");

            migrationBuilder.RenameIndex(
                name: "IX_paymentOptionEmployee_PaymentOptionId",
                table: "PaymentOptionEmployee",
                newName: "IX_PaymentOptionEmployee_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_paymentOptionEmployee_EmployeeId",
                table: "PaymentOptionEmployee",
                newName: "IX_PaymentOptionEmployee_EmployeeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentOptionEmployee",
                table: "PaymentOptionEmployee",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BalanceHistories_BalanceId",
                table: "BalanceHistories",
                column: "BalanceId");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceHistories_Balances_BalanceId",
                table: "BalanceHistories",
                column: "BalanceId",
                principalTable: "Balances",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionEmployee_Employee_EmployeeId",
                table: "PaymentOptionEmployee",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionEmployee_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionEmployee",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
