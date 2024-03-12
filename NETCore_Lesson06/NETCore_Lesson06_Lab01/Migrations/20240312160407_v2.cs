using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NETCore_Lesson06_Lab01.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate1",
                table: "Category",
                newName: "CreateDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreateDate",
                table: "Category",
                newName: "CreateDate1");
        }
    }
}
