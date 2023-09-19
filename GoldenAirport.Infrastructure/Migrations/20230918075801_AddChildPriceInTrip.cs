using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChildPriceInTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceLessThan12YearsOld",
                table: "Trip");

            migrationBuilder.RenameColumn(
                name: "PriceLessThan2YearsOld",
                table: "Trip",
                newName: "ChildPrice");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChildPrice",
                table: "Trip",
                newName: "PriceLessThan2YearsOld");

            migrationBuilder.AddColumn<decimal>(
                name: "PriceLessThan12YearsOld",
                table: "Trip",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
