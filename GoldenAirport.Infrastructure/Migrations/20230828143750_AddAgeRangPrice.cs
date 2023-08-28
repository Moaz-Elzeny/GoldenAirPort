using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAgeRangPrice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "PriceLessThan12YearsOld",
                table: "Trip",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "PriceLessThan2YearsOld",
                table: "Trip",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriceLessThan12YearsOld",
                table: "Trip");

            migrationBuilder.DropColumn(
                name: "PriceLessThan2YearsOld",
                table: "Trip");
        }
    }
}
