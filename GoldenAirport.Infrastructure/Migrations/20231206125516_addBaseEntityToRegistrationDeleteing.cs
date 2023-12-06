using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addBaseEntityToRegistrationDeleteing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "TripRegistrationsDeleting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "TripRegistrationsDeleting",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "TripRegistrationsDeleting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "TripRegistrationsDeleting",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "TripRegistrationsDeleting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "PackageRegistrationsDeleting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "PackageRegistrationsDeleting",
                type: "DATETIME",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "PackageRegistrationsDeleting",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModificationDate",
                table: "PackageRegistrationsDeleting",
                type: "DATETIME",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedById",
                table: "PackageRegistrationsDeleting",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "PackageRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "PackageRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "PackageRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "ModificationDate",
                table: "PackageRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "ModifiedById",
                table: "PackageRegistrationsDeleting");
        }
    }
}
