using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MNS_Games_WebApplication.Models;

public partial class MnsgamesContext : DbContext
{
    public MnsgamesContext()
    {
    }

    public MnsgamesContext(DbContextOptions<MnsgamesContext> options)
        : base(options)
    {
    }


    public virtual DbSet<AppUser> AppUsers { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<AppUser>(entity =>
        {
            entity.ToTable("AppUser");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.City)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LoginNickname).HasMaxLength(50);
            entity.Property(e => e.LoginPassword).HasMaxLength(200);
            entity.Property(e => e.StreetName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.StreetNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Zipcode)
                .HasMaxLength(50)
                .IsUnicode(false);
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
