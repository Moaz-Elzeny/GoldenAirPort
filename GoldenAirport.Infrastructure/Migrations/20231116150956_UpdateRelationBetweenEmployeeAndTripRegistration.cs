using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationBetweenEmployeeAndTripRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "TripRegistration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "TripRegistration",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistration_AppUserId",
                table: "TripRegistration",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistration_EmployeeId",
                table: "TripRegistration",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistration_AppUsers_AppUserId",
                table: "TripRegistration",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistration_Employee_EmployeeId",
                table: "TripRegistration",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistration_AppUsers_AppUserId",
                table: "TripRegistration");

            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistration_Employee_EmployeeId",
                table: "TripRegistration");

            migrationBuilder.DropIndex(
                name: "IX_TripRegistration_AppUserId",
                table: "TripRegistration");

            migrationBuilder.DropIndex(
                name: "IX_TripRegistration_EmployeeId",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "TripRegistration");
        }
    }
}
