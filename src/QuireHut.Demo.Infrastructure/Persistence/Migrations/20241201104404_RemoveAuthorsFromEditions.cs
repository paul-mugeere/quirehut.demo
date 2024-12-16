using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveAuthorsFromEditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authors",
                table: "Editions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "authors",
                table: "Editions",
                type: "jsonb",
                nullable: true);
        }
    }
}
