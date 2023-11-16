using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateTripRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OutherFees",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "TripRegistration");

            migrationBuilder.RenameColumn(
                name: "TaxesAndFees",
                table: "TripRegistration",
                newName: "Taxes");

            migrationBuilder.RenameColumn(
                name: "PackageCost",
                table: "TripRegistration",
                newName: "AdultCost");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "TripRegistration",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TripRegistration",
                type: "DATETIME",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "TripRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TripRegistration",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "TripRegistration",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TripRegistration",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<decimal>(
                name: "AdminFees",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildCost",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployeeFees",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherFees",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "RemainingGuests",
                table: "Trip",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminFees",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "ChildCost",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "EmployeeFees",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "OtherFees",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "RemainingGuests",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "Taxes",
                table: "TripRegistration",
                newName: "TaxesAndFees");

            migrationBuilder.RenameColumn(
                name: "AdultCost",
                table: "TripRegistration",
                newName: "PackageCost");

            migrationBuilder.AlterColumn<string>(
                name: "ModifiedById",
                table: "TripRegistration",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModificationDate",
                table: "TripRegistration",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Deleted",
                table: "TripRegistration",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDate",
                table: "TripRegistration",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedById",
                table: "TripRegistration",
                type: "nvarchar(450)",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<bool>(
                name: "Active",
                table: "TripRegistration",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OutherFees",
                table: "TripRegistration",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "TripRegistration",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
