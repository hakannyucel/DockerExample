using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DockerExample.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateBooksPageColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Page",
                table: "books",
                newName: "page");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "page",
                table: "books",
                newName: "Page");
        }
    }
}
