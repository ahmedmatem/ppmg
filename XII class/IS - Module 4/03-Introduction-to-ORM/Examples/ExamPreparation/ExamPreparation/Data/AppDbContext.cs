using System;
using System.Collections.Generic;
using ExamPreparation.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamPreparation.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Genre> Genres { get; set; }

    public virtual DbSet<Library> Libraries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=LibrearyExamDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Authors__3214EC07F65C6A1A");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Contact).WithMany(p => p.Authors)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Authors__Contact__3B75D760");
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Books__3214EC0722566777");

            entity.HasIndex(e => e.Isbn, "UQ__Books__447D36EAD249F993").IsUnique();

            entity.Property(e => e.Isbn)
                .HasMaxLength(13)
                .HasColumnName("ISBN");
            entity.Property(e => e.Title).HasMaxLength(100);

            entity.HasOne(d => d.Author).WithMany(p => p.Books)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__AuthorId__4222D4EF");

            entity.HasOne(d => d.Genre).WithMany(p => p.Books)
                .HasForeignKey(d => d.GenreId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Books__GenreId__4316F928");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Contacts__3214EC071126DB94");

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PostAddress).HasMaxLength(200);
            entity.Property(e => e.Website).HasMaxLength(50);
        });

        modelBuilder.Entity<Genre>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Genres__3214EC071C3935CC");

            entity.Property(e => e.Name).HasMaxLength(30);
        });

        modelBuilder.Entity<Library>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Librarie__3214EC07CFE78161");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Contact).WithMany(p => p.Libraries)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("FK__Libraries__Conta__3E52440B");

            entity.HasMany(d => d.Books).WithMany(p => p.Libraries)
                .UsingEntity<Dictionary<string, object>>(
                    "LibrariesBook",
                    r => r.HasOne<Book>().WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Libraries__BookI__46E78A0C"),
                    l => l.HasOne<Library>().WithMany()
                        .HasForeignKey("LibraryId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Libraries__Libra__45F365D3"),
                    j =>
                    {
                        j.HasKey("LibraryId", "BookId").HasName("PK_Books_Libraries");
                        j.ToTable("LibrariesBooks");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
