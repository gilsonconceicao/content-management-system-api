using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cmsapplication.Migrations
{
    /// <inheritdoc />
    public partial class createmodelspersons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "hideLikesNumber",
                table: "posts",
                newName: "HideLikesNumber");

            migrationBuilder.RenameColumn(
                name: "disableComments",
                table: "posts",
                newName: "DisableComments");

            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");

            migrationBuilder.RenameColumn(
                name: "HideLikesNumber",
                table: "posts",
                newName: "hideLikesNumber");

            migrationBuilder.RenameColumn(
                name: "DisableComments",
                table: "posts",
                newName: "disableComments");
        }
    }
}
