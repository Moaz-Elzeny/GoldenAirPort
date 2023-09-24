using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateEmployeeDailyGoal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeDailyGoal");

            migrationBuilder.AddColumn<string>(
                name: "EmployeeId",
                table: "DailyGoals",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_DailyGoals_EmployeeId",
                table: "DailyGoals",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DailyGoals_Employee_EmployeeId",
                table: "DailyGoals",
                column: "EmployeeId",
                principalTable: "Employee",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DailyGoals_Employee_EmployeeId",
                table: "DailyGoals");

            migrationBuilder.DropIndex(
                name: "IX_DailyGoals_EmployeeId",
                table: "DailyGoals");

            migrationBuilder.DropColumn(
                name: "EmployeeId",
                table: "DailyGoals");

            migrationBuilder.CreateTable(
                name: "EmployeeDailyGoal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyGoalId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedById = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDailyGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeDailyGoal_DailyGoals_DailyGoalId",
                        column: x => x.DailyGoalId,
                        principalTable: "DailyGoals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeDailyGoal_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDailyGoal_DailyGoalId",
                table: "EmployeeDailyGoal",
                column: "DailyGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDailyGoal_EmployeeId",
                table: "EmployeeDailyGoal",
                column: "EmployeeId");
        }
    }
}
