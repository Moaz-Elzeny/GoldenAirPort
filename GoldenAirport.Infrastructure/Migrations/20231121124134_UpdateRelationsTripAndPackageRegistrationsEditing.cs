using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelationsTripAndPackageRegistrationsEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_PackageRegistrations_PackageRegistrationId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_Package_PackageId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropIndex(
                name: "IX_TripRegistrationsEditing_TripId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropIndex(
                name: "IX_PackageRegistrationsEditing_PackageId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "TripId",
                table: "TripRegistrationsEditing");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.AlterColumn<int>(
                name: "PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PackageRegistrationsEditing_PackageRegistrations_PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                column: "PackageRegistrationId",
                principalTable: "PackageRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackageRegistrationsEditing_PackageRegistrations_PackageRegistrationId",
                table: "PackageRegistrationsEditing");

            migrationBuilder.AddColumn<int>(
                name: "TripId",
                table: "TripRegistrationsEditing",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PackageRegistrationId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "PackageRegistrationsEditing",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistrationsEditing_TripId",
                table: "TripRegistrationsEditing",
                column: "TripId");

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrationsEditing_PackageId",
                table: "PackageRegistrationsEditing",
                column: "PackageId");

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
                name: "FK_TripRegistrationsEditing_Trip_TripId",
                table: "TripRegistrationsEditing",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id");
        }
    }
}
