using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Etqaan.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Vark : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VarkExams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarkExams", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VarkExamResponses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarkExamId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SubmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalVarkScore = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarkExamResponses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VarkExamResponses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);

                    table.ForeignKey(
                        name: "FK_VarkExamResponses_VarkExams_VarkExamId",
                        column: x => x.VarkExamId,
                        principalTable: "VarkExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VarkQuestions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VarkExamId = table.Column<int>(type: "int", nullable: false),
                    QuestionHead = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarkQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VarkQuestions_VarkExams_VarkExamId",
                        column: x => x.VarkExamId,
                        principalTable: "VarkExams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VarkQuestionChoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    VarkScore = table.Column<int>(type: "int", nullable: false),
                    VarkQuestionId = table.Column<int>(type: "int", nullable: false),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedById = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Deleted = table.Column<bool>(type: "bit", nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VarkQuestionChoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VarkQuestionChoices_VarkQuestions_VarkQuestionId",
                        column: x => x.VarkQuestionId,
                        principalTable: "VarkQuestions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VarkExamResponses_StudentId",
                table: "VarkExamResponses",
                column: "StudentId");



            migrationBuilder.CreateIndex(
                name: "IX_VarkExamResponses_VarkExamId",
                table: "VarkExamResponses",
                column: "VarkExamId");

            migrationBuilder.CreateIndex(
                name: "IX_VarkQuestionChoices_VarkQuestionId",
                table: "VarkQuestionChoices",
                column: "VarkQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_VarkQuestions_VarkExamId",
                table: "VarkQuestions",
                column: "VarkExamId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VarkExamResponses");

            migrationBuilder.DropTable(
                name: "VarkQuestionChoices");

            migrationBuilder.DropTable(
                name: "VarkQuestions");

            migrationBuilder.DropTable(
                name: "VarkExams");
        }
    }
}
