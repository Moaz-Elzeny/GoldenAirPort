using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updateAppuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AppUsers_AppUserId1",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ServiceFees",
                table: "Employee");

            migrationBuilder.AlterColumn<string>(
                name: "AppUserId",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceFees",
                table: "AppUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AppUsers_AppUserId",
                table: "Employee",
                column: "AppUserId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AppUsers_AppUserId",
                table: "Employee");

            migrationBuilder.DropIndex(
                name: "IX_Employee_AppUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "ServiceFees",
                table: "AppUsers");

            migrationBuilder.AlterColumn<int>(
                name: "AppUserId",
                table: "Employee",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId1",
                table: "Employee",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "ServiceFees",
                table: "Employee",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_Employee_AppUserId1",
                table: "Employee",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AppUsers_AppUserId1",
                table: "Employee",
                column: "AppUserId1",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
