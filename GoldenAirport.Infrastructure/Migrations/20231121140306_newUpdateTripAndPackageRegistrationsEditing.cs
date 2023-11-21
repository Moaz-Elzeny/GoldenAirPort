using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateTripAndPackageRegistrationsEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AdminFees",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "AdultCost",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "ChildCost",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "EmployeeFees",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "OtherFees",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "Taxes",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "TotalAmount",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "AdminFees",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "AdultCost",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "ChildCost",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "EmployeeFees",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "Taxes",
                table: "PackageRegistrationsEditing");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "AdminFees",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(    
                name: "AdultCost",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildCost",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployeeFees",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherFees",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxes",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAmount",
                table: "TripRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "AdminFees",
                table: "PackageRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AdultCost",
                table: "PackageRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "ChildCost",
                table: "PackageRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "EmployeeFees",
                table: "PackageRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Taxes",
                table: "PackageRegistrationsEditing",
                type: "decimal(18,2)",
                nullable: true);
        }
    }
}
