using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionPackage_Package_PackageId",
                table: "PaymentOptionPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionPackage_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionPackage");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionTrip_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionTrip");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionTrip_Trip_TripId",
                table: "PaymentOptionTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentOptionTrip",
                table: "PaymentOptionTrip");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentOptionPackage",
                table: "PaymentOptionPackage");

            migrationBuilder.DropColumn(
                name: "BookingTime",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "ServiceFees",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "TaxValue",
                table: "AppUsers");

            migrationBuilder.RenameTable(
                name: "PaymentOptionTrip",
                newName: "PaymentOptionTrips");

            migrationBuilder.RenameTable(
                name: "PaymentOptionPackage",
                newName: "PaymentOptionPackages");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionTrip_TripId",
                table: "PaymentOptionTrips",
                newName: "IX_PaymentOptionTrips_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionTrip_PaymentOptionId",
                table: "PaymentOptionTrips",
                newName: "IX_PaymentOptionTrips_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionPackage_PaymentOptionId",
                table: "PaymentOptionPackages",
                newName: "IX_PaymentOptionPackages_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionPackage_PackageId",
                table: "PaymentOptionPackages",
                newName: "IX_PaymentOptionPackages_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentOptionTrips",
                table: "PaymentOptionTrips",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentOptionPackages",
                table: "PaymentOptionPackages",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionPackages_Package_PackageId",
                table: "PaymentOptionPackages",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionPackages_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionPackages",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionTrips_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionTrips",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionTrips_Trip_TripId",
                table: "PaymentOptionTrips",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionPackages_Package_PackageId",
                table: "PaymentOptionPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionPackages_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionPackages");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionTrips_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionTrips");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentOptionTrips_Trip_TripId",
                table: "PaymentOptionTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentOptionTrips",
                table: "PaymentOptionTrips");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentOptionPackages",
                table: "PaymentOptionPackages");

            migrationBuilder.RenameTable(
                name: "PaymentOptionTrips",
                newName: "PaymentOptionTrip");

            migrationBuilder.RenameTable(
                name: "PaymentOptionPackages",
                newName: "PaymentOptionPackage");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionTrips_TripId",
                table: "PaymentOptionTrip",
                newName: "IX_PaymentOptionTrip_TripId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionTrips_PaymentOptionId",
                table: "PaymentOptionTrip",
                newName: "IX_PaymentOptionTrip_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionPackages_PaymentOptionId",
                table: "PaymentOptionPackage",
                newName: "IX_PaymentOptionPackage_PaymentOptionId");

            migrationBuilder.RenameIndex(
                name: "IX_PaymentOptionPackages_PackageId",
                table: "PaymentOptionPackage",
                newName: "IX_PaymentOptionPackage_PackageId");

            migrationBuilder.AddColumn<byte>(
                name: "BookingTime",
                table: "AppUsers",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceFees",
                table: "AppUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<byte>(
                name: "TaxValue",
                table: "AppUsers",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentOptionTrip",
                table: "PaymentOptionTrip",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentOptionPackage",
                table: "PaymentOptionPackage",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionPackage_Package_PackageId",
                table: "PaymentOptionPackage",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionPackage_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionPackage",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionTrip_PaymentOptions_PaymentOptionId",
                table: "PaymentOptionTrip",
                column: "PaymentOptionId",
                principalTable: "PaymentOptions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentOptionTrip_Trip_TripId",
                table: "PaymentOptionTrip",
                column: "TripId",
                principalTable: "Trip",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
