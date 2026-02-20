using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TouristExamPrep.Data.Models;

namespace TouristExamPrep.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tourist> Tourists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\sqlexpress;Database=TouristExamDb;Integrated Security=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Bookings__3214EC07D04577AF");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK__Bookings__HotelI__46E78A0C");

            entity.HasOne(d => d.Room).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Booking_Room");

            entity.HasOne(d => d.Tourist).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TouristId)
                .HasConstraintName("FK__Bookings__Touris__45F365D3");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Countrie__3214EC07F32BBE37");

            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Destinat__3214EC07261B4E65");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Country).WithMany(p => p.Destinations)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK__Destinati__Count__398D8EEE");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hotels__3214EC07DC832753");

            entity.Property(e => e.Name).HasMaxLength(50);

            entity.HasOne(d => d.Destination).WithMany(p => p.Hotels)
                .HasForeignKey(d => d.DestinationId)
                .HasConstraintName("FK__Hotels__Destinat__3F466844");

            entity.HasMany(d => d.Rooms).WithMany(p => p.Hotels)
                .UsingEntity<Dictionary<string, object>>(
                    "HotelsRoom",
                    r => r.HasOne<Room>().WithMany()
                        .HasForeignKey("RoomId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HotelsRoo__RoomI__4CA06362"),
                    l => l.HasOne<Hotel>().WithMany()
                        .HasForeignKey("HotelId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__HotelsRoo__Hotel__4BAC3F29"),
                    j =>
                    {
                        j.HasKey("HotelId", "RoomId").HasName("PK_Hotels_Rooms");
                        j.ToTable("HotelsRooms");
                    });
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rooms__3214EC07C7C5784F");

            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(40)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tourist>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Tourists__3214EC07E1164C06");

            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.Name).HasMaxLength(80);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Tourists)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tourist_Country");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
