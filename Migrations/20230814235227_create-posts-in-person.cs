using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cmsapplication.Migrations
{
    /// <inheritdoc />
    public partial class createpostsinperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PersonId",
                table: "posts",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_posts_PersonId",
                table: "posts",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_persons_PersonId",
                table: "posts",
                column: "PersonId",
                principalTable: "persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_persons_PersonId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_PersonId",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "posts");
        }
    }
}
