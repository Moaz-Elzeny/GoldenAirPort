using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptions_Employee_EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.DropIndex(
                name: "IX_PaymentOptions_EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "PaymentOptions");

            migrationBuilder.CreateTable(
                name: "PaymentOptionEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PaymentOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentOptionEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaymentOptionEmployee_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PaymentOptionEmployee_PaymentOptions_PaymentOptionId",
                        column: x => x.PaymentOptionId,
                        principalTable: "PaymentOptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptionEmployee_EmployeeId",
                table: "PaymentOptionEmployee",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptionEmployee_PaymentOptionId",
                table: "PaymentOptionEmployee",
                column: "PaymentOptionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PaymentOptionEmployee");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "PaymentOptions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentOptions_EmployeeId",
                table: "PaymentOptions",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptions_Employee_EmployeeId",
                table: "PaymentOptions",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
