using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAdultAndChild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adult_TripRegistration_TripRegistrationId",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Child_TripRegistration_TripRegistrationId",
                table: "Child");

            migrationBuilder.AlterColumn<int>(
                name: "TripRegistrationId",
                table: "Child",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "TripRegistrationId",
                table: "Adult",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_TripRegistration_TripRegistrationId",
                table: "Adult",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Child_TripRegistration_TripRegistrationId",
                table: "Child",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adult_TripRegistration_TripRegistrationId",
                table: "Adult");

            migrationBuilder.DropForeignKey(
                name: "FK_Child_TripRegistration_TripRegistrationId",
                table: "Child");

            migrationBuilder.AlterColumn<int>(
                name: "TripRegistrationId",
                table: "Child",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TripRegistrationId",
                table: "Adult",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Adult_TripRegistration_TripRegistrationId",
                table: "Adult",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Child_TripRegistration_TripRegistrationId",
                table: "Child",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
