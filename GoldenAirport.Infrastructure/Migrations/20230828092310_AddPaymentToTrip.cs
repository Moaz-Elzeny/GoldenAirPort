using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddPaymentToTrip : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Trip",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Trip");
        }
    }
}
