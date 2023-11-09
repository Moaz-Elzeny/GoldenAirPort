using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addCodeToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "code",
                table: "AppUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "code",
                table: "AppUsers");
        }
    }
}
