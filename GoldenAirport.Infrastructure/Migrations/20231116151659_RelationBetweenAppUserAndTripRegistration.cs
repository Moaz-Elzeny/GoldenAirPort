using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RelationBetweenAppUserAndTripRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistration_Employee_EmployeeId",
                table: "TripRegistration");

            migrationBuilder.DropIndex(
                name: "IX_TripRegistration_EmployeeId",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TripRegistration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "TripRegistration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistration_EmployeeId",
                table: "TripRegistration",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistration_Employee_EmployeeId",
                table: "TripRegistration",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }
    }
}
