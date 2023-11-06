using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateEmployeeAndAddAdminDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrivacyPolicyAndTerms",
                table: "AppUsers");

            migrationBuilder.RenameColumn(
                name: "Target",
                table: "Employee",
                newName: "ServiceFees");

            migrationBuilder.AddColumn<decimal>(
                name: "Target",
                table: "DailyGoals",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "AdminDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceFees = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TaxValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BookingTime = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrivacyPolicyAndTerms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompanyId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompanyId1 = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdminDetails_Companies_CompanyId1",
                        column: x => x.CompanyId1,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_CompanyId1",
                table: "AdminDetails",
                column: "CompanyId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminDetails");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "DailyGoals");

            migrationBuilder.RenameColumn(
                name: "ServiceFees",
                table: "Employee",
                newName: "Target");

            migrationBuilder.AddColumn<string>(
                name: "PrivacyPolicyAndTerms",
                table: "AppUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
