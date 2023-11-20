using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createPackageRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PackageRegistrationId",
                table: "Child",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PackageRegistrationId",
                table: "Adult",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "PackageRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdultCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdminFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRegistrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageRegistrations_AppUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AppUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PackageRegistrations_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Child_PackageRegistrationId",
                table: "Child",
                column: "PackageRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_Adult_PackageRegistrationId",
                table: "Adult",
                column: "PackageRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrations_AppUserId",
                table: "PackageRegistrations",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrations_PackageId",
                table: "PackageRegistrations",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_PackageRegistrations_PackageRegistrationId",
                table: "Adult",
                column: "PackageRegistrationId",
                principalTable: "PackageRegistrations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_PackageRegistrations_PackageRegistrationId",
                table: "Child",
                column: "PackageRegistrationId",
                principalTable: "PackageRegistrations",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adult_PackageRegistrations_PackageRegistrationId",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Child_PackageRegistrations_PackageRegistrationId",
                table: "Child");

            migrationBuilder.DropTable(
                name: "PackageRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_Child_PackageRegistrationId",
                table: "Child");

            migrationBuilder.DropIndex(
                name: "IX_Adult_PackageRegistrationId",
                table: "Adult");

            migrationBuilder.DropColumn(
                name: "PackageRegistrationId",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "PackageRegistrationId",
                table: "Adult");
        }
    }
}
