using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatePaymentOptionsss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "BalanceHistories",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BalanceHistories_AppUserId",
                table: "BalanceHistories",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceHistories_AppUsers_AppUserId",
                table: "BalanceHistories",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceHistories_AppUsers_AppUserId",
                table: "BalanceHistories");

            migrationBuilder.DropIndex(
                name: "IX_BalanceHistories_AppUserId",
                table: "BalanceHistories");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "BalanceHistories");
        }
    }
}
