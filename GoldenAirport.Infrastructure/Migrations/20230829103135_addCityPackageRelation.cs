using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCityPackageRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_City_Package_PackageId",
                table: "City");

            migrationBuilder.DropForeignKey(
                name: "FK_packagePlans_Package_PackageId",
                table: "packagePlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_packagePlans",
                table: "packagePlans");

            migrationBuilder.DropIndex(
                name: "IX_City_PackageId",
                table: "City");

            migrationBuilder.DropColumn(
                name: "PackageId",
                table: "City");

            migrationBuilder.RenameTable(
                name: "packagePlans",
                newName: "PackagePlans");

            migrationBuilder.RenameIndex(
                name: "IX_packagePlans_PackageId",
                table: "PackagePlans",
                newName: "IX_PackagePlans_PackageId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PackagePlans",
                table: "PackagePlans",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "CityPackge",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PackageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityPackge", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CityPackge_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CityPackge_Package_PackageId",
                        column: x => x.PackageId,
                        principalTable: "Package",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CityPackge_CityId",
                table: "CityPackge",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CityPackge_PackageId",
                table: "CityPackge",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_PackagePlans_Package_PackageId",
                table: "PackagePlans",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PackagePlans_Package_PackageId",
                table: "PackagePlans");

            migrationBuilder.DropTable(
                name: "CityPackge");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PackagePlans",
                table: "PackagePlans");

            migrationBuilder.RenameTable(
                name: "PackagePlans",
                newName: "packagePlans");

            migrationBuilder.RenameIndex(
                name: "IX_PackagePlans_PackageId",
                table: "packagePlans",
                newName: "IX_packagePlans_PackageId");

            migrationBuilder.AddColumn<int>(
                name: "PackageId",
                table: "City",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_packagePlans",
                table: "packagePlans",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_City_PackageId",
                table: "City",
                column: "PackageId");

            migrationBuilder.AddForeignKey(
                name: "FK_City_Package_PackageId",
                table: "City",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_packagePlans_Package_PackageId",
                table: "packagePlans",
                column: "PackageId",
                principalTable: "Package",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
