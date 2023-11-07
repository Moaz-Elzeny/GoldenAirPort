using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newUpdateAdminDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "AdminDetails",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_AdminDetails_AppUserId",
                table: "AdminDetails",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminDetails_AppUsers_AppUserId",
                table: "AdminDetails",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminDetails_AppUsers_AppUserId",
                table: "AdminDetails");

            migrationBuilder.DropIndex(
                name: "IX_AdminDetails_AppUserId",
                table: "AdminDetails");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "AdminDetails");
        }
    }
}
