using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etqaan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddSizeToLearningResource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "LearningResources",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "LearningResources");
        }
    }
}
