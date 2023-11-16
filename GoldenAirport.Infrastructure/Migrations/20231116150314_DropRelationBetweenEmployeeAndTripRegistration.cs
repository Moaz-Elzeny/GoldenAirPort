using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DropRelationBetweenEmployeeAndTripRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeTripRegistration");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeTripRegistration",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TripRegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTripRegistration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTripRegistration_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeTripRegistration_TripRegistration_TripRegistrationId",
                        column: x => x.TripRegistrationId,
                        principalTable: "TripRegistration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTripRegistration_EmployeeId",
                table: "EmployeeTripRegistration",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTripRegistration_TripRegistrationId",
                table: "EmployeeTripRegistration",
                column: "TripRegistrationId");
        }
    }
}
