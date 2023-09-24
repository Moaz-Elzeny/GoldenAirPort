using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateEmployeeBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Employee");

            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "Employee",
                newName: "BalanceId");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "TripRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "PaymentOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Balances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BalanceAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Balances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Balances_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_EmployeeId",
                table: "PaymentOptions",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Balances_EmployeeId",
                table: "Balances",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptions_Employee_EmployeeId",
                table: "PaymentOptions",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptions_Employee_EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.DropTable(
                name: "Balances");

            migrationBuilder.DropIndex(
                name: "IX_PaymentOptions_EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.RenameColumn(
                name: "BalanceId",
                table: "Employee",
                newName: "Balance");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Employee",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
