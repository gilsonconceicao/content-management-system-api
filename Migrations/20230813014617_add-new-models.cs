using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cmsapplication.Migrations
{
    /// <inheritdoc />
    public partial class addnewmodels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurePost");

            migrationBuilder.AddColumn<bool>(
                name: "disableComments",
                table: "posts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "hideLikesNumber",
                table: "posts",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "disableComments",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "hideLikesNumber",
                table: "posts");

            migrationBuilder.CreateTable(
                name: "ConfigurePost",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    disableComments = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    hideLikesNumber = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurePost", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurePost_posts_PostId",
                        column: x => x.PostId,
                        principalTable: "posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurePost_PostId",
                table: "ConfigurePost",
                column: "PostId",
                unique: true);
        }
    }
}
