using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class removeCountryFromPackageAndAddAboutExploreTour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package");

            migrationBuilder.DropIndex(
                name: "IX_Package_CountryId",
                table: "Package");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Package");

            migrationBuilder.AddColumn<string>(
                name: "AboutExploreTour",
                table: "Package",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutExploreTour",
                table: "Package");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "Package",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Package_CountryId",
                table: "Package",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Package_Country_CountryId",
                table: "Package",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id");
        }
    }
}
