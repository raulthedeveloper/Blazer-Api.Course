using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LibraryApp.API.Data
{
    public partial class LibraryDbContext : DbContext
    {
        public LibraryDbContext()
        {
        }

        public LibraryDbContext(DbContextOptions<LibraryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; } = null!;
        public virtual DbSet<Book> Books { get; set; } = null!;
        public virtual DbSet<BookRental> BookRentals { get; set; } = null!;
        public virtual DbSet<Patron> Patrons { get; set; } = null!;

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Biography).HasMaxLength(255);

                entity.Property(e => e.FirsrName).HasMaxLength(50);

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("authorId");

                entity.Property(e => e.Image).HasMaxLength(50);

                entity.Property(e => e.Isbn)
                    .HasMaxLength(50)
                    .HasColumnName("isbn");

                entity.Property(e => e.Summary).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .HasColumnName("title");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Books)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Books_ToTable");
            });

            modelBuilder.Entity<BookRental>(entity =>
            {
                entity.Property(e => e.CheckIn).HasColumnType("date");

                entity.Property(e => e.CheckOut).HasColumnType("date");

                entity.Property(e => e.DueDate).HasColumnType("date");

                entity.HasOne(d => d.Patron)
                    .WithMany(p => p.BookRentals)
                    .HasForeignKey(d => d.PatronId)
                    .HasConstraintName("FK_BookRentals_ToTable");
            });

            modelBuilder.Entity<Patron>(entity =>
            {
                entity.Property(e => e.FirstName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
