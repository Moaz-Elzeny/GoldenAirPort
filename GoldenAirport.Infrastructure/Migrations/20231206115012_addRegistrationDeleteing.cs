using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addRegistrationDeleteing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "RegistrationDeleteing",
                table: "TripRegistration",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "RegistrationDeleteing",
                table: "PackageRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "PackageRegistrationsDeleting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PackageRegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PackageRegistrationsDeleting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PackageRegistrationsDeleting_PackageRegistrations_PackageRegistrationId",
                        column: x => x.PackageRegistrationId,
                        principalTable: "PackageRegistrations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TripRegistrationsDeleting",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TripRegistrationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TripRegistrationsDeleting", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TripRegistrationsDeleting_TripRegistration_TripRegistrationId",
                        column: x => x.TripRegistrationId,
                        principalTable: "TripRegistration",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PackageRegistrationsDeleting_PackageRegistrationId",
                table: "PackageRegistrationsDeleting",
                column: "PackageRegistrationId");

            migrationBuilder.CreateIndex(
                name: "IX_TripRegistrationsDeleting_TripRegistrationId",
                table: "TripRegistrationsDeleting",
                column: "TripRegistrationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PackageRegistrationsDeleting");

            migrationBuilder.DropTable(
                name: "TripRegistrationsDeleting");

            migrationBuilder.DropColumn(
                name: "RegistrationDeleteing",
                table: "TripRegistration");

            migrationBuilder.DropColumn(
                name: "RegistrationDeleteing",
                table: "PackageRegistrations");
        }
    }
}
