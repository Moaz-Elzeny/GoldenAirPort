﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etqaan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class GradeQBanks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestionsBanks_GradeId",
                table: "QuestionsBanks",
                column: "GradeId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionsBanks_Grades_GradeId",
                table: "QuestionsBanks",
                column: "GradeId",
                principalTable: "Grades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionsBanks_Grades_GradeId",
                table: "QuestionsBanks");

            migrationBuilder.DropIndex(
                name: "IX_QuestionsBanks_GradeId",
                table: "QuestionsBanks");
        }
    }
}
