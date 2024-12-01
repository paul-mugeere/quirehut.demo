﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using QuireHut.Demo.Infrastructure;

#nullable disable

namespace QuireHut.Demo.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(LibraryDemoDbContext))]
    [Migration("20241201105851_AddBookGenres")]
    partial class AddBookGenres
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("QuireHut.Demo.Domain.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("subject");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Id")
                        .HasName("pk_books");

                    b.ToTable("Books", (string)null);
                });

            modelBuilder.Entity("QuireHut.Demo.Domain.Genre", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_genres");

                    b.ToTable("Genres", (string)null);
                });

            modelBuilder.Entity("QuireHut.Demo.Domain.Book", b =>
                {
                    b.OwnsMany("Edition", "Editions", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("BookId")
                                .HasColumnType("uuid")
                                .HasColumnName("book_id");

                            b1.Property<string>("Dimensions")
                                .HasColumnType("jsonb")
                                .HasColumnName("dimensions");

                            b1.Property<int>("Format")
                                .HasColumnType("integer")
                                .HasColumnName("format");

                            b1.Property<string>("ISBN")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("isbn");

                            b1.Property<string>("Language")
                                .IsRequired()
                                .HasColumnType("text")
                                .HasColumnName("language");

                            b1.Property<int>("NumberOfPages")
                                .HasColumnType("integer")
                                .HasColumnName("number_of_pages");

                            b1.Property<decimal>("Price")
                                .HasColumnType("numeric")
                                .HasColumnName("price");

                            b1.Property<DateTime?>("PublicationDate")
                                .HasColumnType("timestamp with time zone")
                                .HasColumnName("publication_date");

                            b1.Property<string>("Publisher")
                                .HasColumnType("jsonb")
                                .HasColumnName("publisher");

                            b1.Property<int>("Status")
                                .HasColumnType("integer")
                                .HasColumnName("status");

                            b1.Property<int>("Stock")
                                .HasColumnType("integer")
                                .HasColumnName("stock");

                            b1.HasKey("Id")
                                .HasName("pk_editions");

                            b1.HasIndex("BookId")
                                .HasDatabaseName("ix_editions_book_id");

                            b1.ToTable("Editions", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BookId")
                                .HasConstraintName("fk_editions_books_book_id");
                        });

                    b.OwnsMany("QuireHut.Demo.Domain.Entities.BookGenre", "BookGenres", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<Guid>("BookId")
                                .HasColumnType("uuid")
                                .HasColumnName("book_id");

                            b1.Property<Guid>("GenreId")
                                .HasColumnType("uuid")
                                .HasColumnName("genre_id");

                            b1.HasKey("Id")
                                .HasName("pk_book_genres");

                            b1.HasIndex("BookId")
                                .HasDatabaseName("ix_book_genres_book_id");

                            b1.HasIndex("GenreId")
                                .HasDatabaseName("ix_book_genres_genre_id");

                            b1.ToTable("BookGenres", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("BookId")
                                .HasConstraintName("fk_book_genres_books_book_id");

                            b1.HasOne("QuireHut.Demo.Domain.Genre", "Genre")
                                .WithMany()
                                .HasForeignKey("GenreId")
                                .OnDelete(DeleteBehavior.Cascade)
                                .IsRequired()
                                .HasConstraintName("fk_book_genres_genres_genre_id");

                            b1.Navigation("Genre");
                        });

                    b.Navigation("BookGenres");

                    b.Navigation("Editions");
                });
#pragma warning restore 612, 618
        }
    }
}
