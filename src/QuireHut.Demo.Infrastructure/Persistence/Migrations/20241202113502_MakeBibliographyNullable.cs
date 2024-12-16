using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class MakeBibliographyNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bibliography",
                table: "Authors");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bibliography",
                table: "Authors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
