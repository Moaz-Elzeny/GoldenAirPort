using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBalanceHistoryToBalance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BalanceHistories_AppUsers_AppUserId",
                table: "BalanceHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BalanceHistories",
                table: "BalanceHistories");

            migrationBuilder.RenameTable(
                name: "BalanceHistories",
                newName: "Balances");

            migrationBuilder.RenameIndex(
                name: "IX_BalanceHistories_AppUserId",
                table: "Balances",
                newName: "IX_Balances_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Balances",
                table: "Balances",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Balances_AppUsers_AppUserId",
                table: "Balances",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Balances_AppUsers_AppUserId",
                table: "Balances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Balances",
                table: "Balances");

            migrationBuilder.RenameTable(
                name: "Balances",
                newName: "BalanceHistories");

            migrationBuilder.RenameIndex(
                name: "IX_Balances_AppUserId",
                table: "BalanceHistories",
                newName: "IX_BalanceHistories_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BalanceHistories",
                table: "BalanceHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BalanceHistories_AppUsers_AppUserId",
                table: "BalanceHistories",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id");
        }
    }
}
