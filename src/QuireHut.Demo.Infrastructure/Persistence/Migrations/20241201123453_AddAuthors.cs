using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddAuthors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    bibliography = table.Column<string>(type: "text", nullable: false),
                    book_id = table.Column<Guid>(type: "uuid", nullable: false),
                    person_id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_authors", x => x.id);
                    table.ForeignKey(
                        name: "fk_authors_books_book_id",
                        column: x => x.book_id,
                        principalTable: "Books",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_authors_persons_person_id",
                        column: x => x.person_id,
                        principalTable: "persons",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_authors_book_id",
                table: "Authors",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "ix_authors_person_id",
                table: "Authors",
                column: "person_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
