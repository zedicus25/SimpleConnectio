using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SimpleConnectio.Models;

public partial class SmartphonesDataBaseContext : DbContext
{
    public SmartphonesDataBaseContext()
    {
    }

    public SmartphonesDataBaseContext(DbContextOptions<SmartphonesDataBaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Smartphone> Smartphones { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-GLH25AE\\SQLEXPRESS;Database=SmartphonesDataBase;Trusted_Connection=True;Encrypt=false;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Smartphone>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__smartpho__3214EC0707BD3A4A");

            entity.ToTable("smartphones");

            entity.Property(e => e.Model).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
