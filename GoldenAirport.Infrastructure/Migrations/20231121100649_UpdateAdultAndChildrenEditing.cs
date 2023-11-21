using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GoldenAirport.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAdultAndChildrenEditing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdultEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "AdultEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_AdultEditing_TripRegistration_TripRegistrationId",
                table: "AdultEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_AdultEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "AdultEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "ChildEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "ChildEditing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildEditing",
                table: "ChildEditing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdultEditing",
                table: "AdultEditing");

            migrationBuilder.DropIndex(
                name: "IX_AdultEditing_TripRegistrationId",
                table: "AdultEditing");

            migrationBuilder.DropColumn(
                name: "TripRegistrationId",
                table: "AdultEditing");

            migrationBuilder.RenameTable(
                name: "ChildEditing",
                newName: "ChildrenEditing");

            migrationBuilder.RenameTable(
                name: "AdultEditing",
                newName: "AdultsEditing");

            migrationBuilder.RenameIndex(
                name: "IX_ChildEditing_TripRegistrationEditingId",
                table: "ChildrenEditing",
                newName: "IX_ChildrenEditing_TripRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildEditing_PackageRegistrationEditingId",
                table: "ChildrenEditing",
                newName: "IX_ChildrenEditing_PackageRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultEditing_TripRegistrationEditingId",
                table: "AdultsEditing",
                newName: "IX_AdultsEditing_TripRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultEditing_PackageRegistrationEditingId",
                table: "AdultsEditing",
                newName: "IX_AdultsEditing_PackageRegistrationEditingId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildrenEditing",
                table: "ChildrenEditing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdultsEditing",
                table: "AdultsEditing",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultsEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "AdultsEditing",
                column: "PackageRegistrationEditingId",
                principalTable: "PackageRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultsEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "AdultsEditing",
                column: "TripRegistrationEditingId",
                principalTable: "TripRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "ChildrenEditing",
                column: "PackageRegistrationEditingId",
                principalTable: "PackageRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildrenEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "ChildrenEditing",
                column: "TripRegistrationEditingId",
                principalTable: "TripRegistrationsEditing",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdultsEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "AdultsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_AdultsEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "AdultsEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "ChildrenEditing");

            migrationBuilder.DropForeignKey(
                name: "FK_ChildrenEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "ChildrenEditing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChildrenEditing",
                table: "ChildrenEditing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdultsEditing",
                table: "AdultsEditing");

            migrationBuilder.RenameTable(
                name: "ChildrenEditing",
                newName: "ChildEditing");

            migrationBuilder.RenameTable(
                name: "AdultsEditing",
                newName: "AdultEditing");

            migrationBuilder.RenameIndex(
                name: "IX_ChildrenEditing_TripRegistrationEditingId",
                table: "ChildEditing",
                newName: "IX_ChildEditing_TripRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_ChildrenEditing_PackageRegistrationEditingId",
                table: "ChildEditing",
                newName: "IX_ChildEditing_PackageRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultsEditing_TripRegistrationEditingId",
                table: "AdultEditing",
                newName: "IX_AdultEditing_TripRegistrationEditingId");

            migrationBuilder.RenameIndex(
                name: "IX_AdultsEditing_PackageRegistrationEditingId",
                table: "AdultEditing",
                newName: "IX_AdultEditing_PackageRegistrationEditingId");

            migrationBuilder.AddColumn<int>(
                name: "TripRegistrationId",
                table: "AdultEditing",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChildEditing",
                table: "ChildEditing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdultEditing",
                table: "AdultEditing",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AdultEditing_TripRegistrationId",
                table: "AdultEditing",
                column: "TripRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "AdultEditing",
                column: "PackageRegistrationEditingId",
                principalTable: "PackageRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultEditing_TripRegistration_TripRegistrationId",
                table: "AdultEditing",
                column: "TripRegistrationId",
                principalTable: "TripRegistration",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AdultEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "AdultEditing",
                column: "TripRegistrationEditingId",
                principalTable: "TripRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildEditing_PackageRegistrationsEditing_PackageRegistrationEditingId",
                table: "ChildEditing",
                column: "PackageRegistrationEditingId",
                principalTable: "PackageRegistrationsEditing",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChildEditing_TripRegistrationsEditing_TripRegistrationEditingId",
                table: "ChildEditing",
                column: "TripRegistrationEditingId",
                principalTable: "TripRegistrationsEditing",
                principalColumn: "Id");
        }
    }
}
