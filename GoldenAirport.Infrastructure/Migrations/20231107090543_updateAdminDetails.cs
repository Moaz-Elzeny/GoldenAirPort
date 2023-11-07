using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAdminDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminDetails_Companies_CompanyId1",
                table: "AdminDetails");

            migrationBuilder.DropIndex(
                name: "IX_AdminDetails_CompanyId1",
                table: "AdminDetails");

            migrationBuilder.DropColumn(
                name: "CompanyId1",
                table: "AdminDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServiceFees",
                table: "AdminDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CompanyId",
                table: "AdminDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookingTime",
                table: "AdminDetails",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_CompanyId",
                table: "AdminDetails",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminDetails_Companies_CompanyId",
                table: "AdminDetails",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminDetails_Companies_CompanyId",
                table: "AdminDetails");

            migrationBuilder.DropIndex(
                name: "IX_AdminDetails_CompanyId",
                table: "AdminDetails");

            migrationBuilder.AlterColumn<decimal>(
                name: "ServiceFees",
                table: "AdminDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CompanyId",
                table: "AdminDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<decimal>(
                name: "BookingTime",
                table: "AdminDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CompanyId1",
                table: "AdminDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_CompanyId1",
                table: "AdminDetails",
                column: "CompanyId1");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminDetails_Companies_CompanyId1",
                table: "AdminDetails",
                column: "CompanyId1",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
