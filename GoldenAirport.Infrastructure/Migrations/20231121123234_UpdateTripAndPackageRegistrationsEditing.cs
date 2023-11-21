using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTripAndPackageRegistrationsEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_Package_PackageId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TripRegistrationsEditing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "TripRegistrationId",
                table: "TripRegistrationsEditing",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistrationsEditing_TripRegistrationId",
                table: "TripRegistrationsEditing",
                column: "TripRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrationsEditing_PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                column: "PackageRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRegistrationsEditing_PackageRegistrations_PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                column: "PackageRegistrationId",
                principalTable: "PackageRegistrations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRegistrationsEditing_Package_PackageId",
                table: "PackageRegistrationsEditing",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistrationsEditing_TripRegistration_TripRegistrationId",
                table: "TripRegistrationsEditing",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_PackageRegistrations_PackageRegistrationId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_Package_PackageId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistrationsEditing_TripRegistration_TripRegistrationId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropIndex(
                name: "IX_TripRegistrationsEditing_TripRegistrationId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropIndex(
                name: "IX_PackageRegistrationsEditing_PackageRegistrationId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "TripRegistrationId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "PackageRegistrationId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.AlterColumn<int>(
                name: "TripId",
                table: "TripRegistrationsEditing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PackageId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRegistrationsEditing_Package_PackageId",
                table: "PackageRegistrationsEditing",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
