using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DropdownBI.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableCourse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Categort",
                table: "Courses",
                newName: "Category");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Category",
                table: "Courses",
                newName: "Categort");
        }
    }
}
