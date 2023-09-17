using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChildPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "PriceLessThan12YearsOld",
                table: "Package");

            migrationBuilder.RenameColumn(
                name: "PriceLessThan2YearsOld",
                table: "Package",
                newName: "ChildPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChildPrice",
                table: "Package",
                newName: "PriceLessThan2YearsOld");

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceLessThan12YearsOld",
                table: "Package",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
