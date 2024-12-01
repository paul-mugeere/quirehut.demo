using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "authors",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "genres",
                table: "Books");

            migrationBuilder.AddColumn<string>(
                name: "authors",
                table: "Editions",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genres",
                table: "Editions",
                type: "jsonb",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_genres", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropColumn(
                name: "authors",
                table: "Editions");

            migrationBuilder.DropColumn(
                name: "genres",
                table: "Editions");

            migrationBuilder.AddColumn<string>(
                name: "authors",
                table: "Books",
                type: "jsonb",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "genres",
                table: "Books",
                type: "jsonb",
                nullable: true);
        }
    }
}
