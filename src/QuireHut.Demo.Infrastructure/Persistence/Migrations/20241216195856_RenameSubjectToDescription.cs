using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class RenameSubjectToDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "subject",
                table: "Books",
                newName: "description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "description",
                table: "Books",
                newName: "subject");
        }
    }
}
