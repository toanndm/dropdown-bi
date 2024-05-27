using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropdownBI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableEnroll : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls");

            migrationBuilder.DropIndex(
                name: "IX_Enrolls_CourseId",
                table: "Enrolls");

            migrationBuilder.AlterColumn<string>(
                name: "CourseId",
                table: "Enrolls",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CourseId",
                table: "Enrolls",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.CreateIndex(
                name: "IX_Enrolls_CourseId",
                table: "Enrolls",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Enrolls_Courses_CourseId",
                table: "Enrolls",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
