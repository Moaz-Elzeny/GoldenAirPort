using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgeRange",
                table: "Child");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxes",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Child",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Child",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Child",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Child");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Child");

            migrationBuilder.AlterColumn<decimal>(
                name: "Taxes",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgeRange",
                table: "Child",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
