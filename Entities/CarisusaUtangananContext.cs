using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LawX_Utanganan.Entities;

public partial class CarisusaUtangananContext : DbContext
{
    public CarisusaUtangananContext()
    {
    }

    public CarisusaUtangananContext(DbContextOptions<CarisusaUtangananContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClientInfo> ClientInfos { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=CarisusaUtanganan;TrustServerCertificate=true;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClientInfo>(entity =>
        {
            entity.ToTable("ClientInfo");

            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Birthdate).HasColumnType("date");
            entity.Property(e => e.CivilStatus)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("Civil_Status");
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MiddleName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NameOfFather)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.NameOfMother)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Occupation)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Religion)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserType");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
