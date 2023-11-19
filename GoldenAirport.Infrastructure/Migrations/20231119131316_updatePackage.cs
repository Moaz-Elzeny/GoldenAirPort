using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatePackage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Package",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ToCityId",
                table: "Package",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_ToCityId",
                table: "Package",
                column: "ToCityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_City_ToCityId",
                table: "Package",
                column: "ToCityId",
                principalTable: "City",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_City_ToCityId",
                table: "Package");

            migrationBuilder.DropForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_ToCityId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "ToCityId",
                table: "Package");

            migrationBuilder.AlterColumn<int>(
                name: "CountryId",
                table: "Package",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
