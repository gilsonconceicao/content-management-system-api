using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cmsapplication.Migrations
{
    /// <inheritdoc />
    public partial class createnewformatbuilder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "comment",
                table: "comments",
                newName: "Comment");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "comments",
                newName: "comment");
        }
    }
}
