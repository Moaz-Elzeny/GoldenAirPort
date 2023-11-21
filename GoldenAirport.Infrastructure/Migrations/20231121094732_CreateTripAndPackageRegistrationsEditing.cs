using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CreateTripAndPackageRegistrationsEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PackageRegistrationsEditing",
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
                    CreatedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRegistrationsEditing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageRegistrationsEditing_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripRegistrationsEditing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdultCost = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ChildCost = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AdminFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    EmployeeFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Taxes = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OtherFees = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TotalAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    TripId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    ModifiedById = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Active = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripRegistrationsEditing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripRegistrationsEditing_Trip_TripId",
                        column: x => x.TripId,
                        principalTable: "Trip",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdultEditing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripRegistrationId = table.Column<int>(type: "int", nullable: true),
                    PackageRegistrationEditingId = table.Column<int>(type: "int", nullable: true),
                    TripRegistrationEditingId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdultEditing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdultEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                        column: x => x.PackageRegistrationEditingId,
                        principalTable: "PackageRegistrationsEditing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdultEditing_TripRegistration_TripRegistrationId",
                        column: x => x.TripRegistrationId,
                        principalTable: "TripRegistration",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AdultEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                        column: x => x.TripRegistrationEditingId,
                        principalTable: "TripRegistrationsEditing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChildEditing",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PassportNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TripRegistrationEditingId = table.Column<int>(type: "int", nullable: true),
                    PackageRegistrationEditingId = table.Column<int>(type: "int", nullable: true),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildEditing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                        column: x => x.PackageRegistrationEditingId,
                        principalTable: "PackageRegistrationsEditing",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChildEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                        column: x => x.TripRegistrationEditingId,
                        principalTable: "TripRegistrationsEditing",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdultEditing_PackageRegistrationEditingId",
                table: "AdultEditing",
                column: "PackageRegistrationEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_AdultEditing_TripRegistrationEditingId",
                table: "AdultEditing",
                column: "TripRegistrationEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_AdultEditing_TripRegistrationId",
                table: "AdultEditing",
                column: "TripRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildEditing_PackageRegistrationEditingId",
                table: "ChildEditing",
                column: "PackageRegistrationEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_ChildEditing_TripRegistrationEditingId",
                table: "ChildEditing",
                column: "TripRegistrationEditingId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrationsEditing_PackageId",
                table: "PackageRegistrationsEditing",
                column: "PackageId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistrationsEditing_TripId",
                table: "TripRegistrationsEditing",
                column: "TripId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdultEditing");

            migrationBuilder.DropTable(
                name: "ChildEditing");

            migrationBuilder.DropTable(
                name: "PackageRegistrationsEditing");

            migrationBuilder.DropTable(
                name: "TripRegistrationsEditing");
        }
    }
}
