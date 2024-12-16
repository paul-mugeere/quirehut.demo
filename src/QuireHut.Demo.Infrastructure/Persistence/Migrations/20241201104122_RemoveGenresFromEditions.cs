using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RemoveGenresFromEditions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "genres",
                table: "Editions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "genres",
                table: "Editions",
                type: "jsonb",
                nullable: true);
        }
    }
}
