using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DeptManagement.Repository.Models;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Chitietkhoanvay> Chitietkhoanvays { get; set; }

    public virtual DbSet<Quanlykhoanno> Quanlykhoannos { get; set; }

    public virtual DbSet<Quanlynaprut> Quanlynapruts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chitietkhoanvay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("chitietkhoanvay_pkey");

            entity.ToTable("chitietkhoanvay");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Khoannoid).HasColumnName("khoannoid");
            entity.Property(e => e.Ngayvay).HasColumnName("ngayvay");
            entity.Property(e => e.Songaytra).HasColumnName("songaytra");
            entity.Property(e => e.Sotienlai)
                .HasPrecision(18, 2)
                .HasColumnName("sotienlai");
            entity.Property(e => e.Sotientramoiky)
                .HasPrecision(18, 2)
                .HasColumnName("sotientramoiky");
            entity.Property(e => e.Sotienvay)
                .HasPrecision(18, 2)
                .HasColumnName("sotienvay");
            entity.Property(e => e.Tongtien)
                .HasPrecision(18, 2)
                .HasComputedColumnSql("(sotienvay + sotienlai)", true)
                .HasColumnName("tongtien");

            entity.HasOne(d => d.Khoanno).WithMany(p => p.Chitietkhoanvays)
                .HasForeignKey(d => d.Khoannoid)
                .HasConstraintName("fk_chitietkhoanvay_quanlykhoanno");
        });

        modelBuilder.Entity<Quanlykhoanno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quanlykhoanno_pkey");

            entity.ToTable("quanlykhoanno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Ghichu).HasColumnName("ghichu");
            entity.Property(e => e.Nguoichovay)
                .HasMaxLength(255)
                .HasColumnName("nguoichovay");
            entity.Property(e => e.Tenkhoanno)
                .HasMaxLength(255)
                .HasColumnName("tenkhoanno");
        });

        modelBuilder.Entity<Quanlynaprut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quanlynaprut_pkey");

            entity.ToTable("quanlynaprut");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Lailo)
                .HasPrecision(18, 2)
                .HasComputedColumnSql("(sotienrut - sotiennap)", true)
                .HasColumnName("lailo");
            entity.Property(e => e.Ngaynap).HasColumnName("ngaynap");
            entity.Property(e => e.Ngayrut).HasColumnName("ngayrut");
            entity.Property(e => e.Sotiennap)
                .HasPrecision(18, 2)
                .HasColumnName("sotiennap");
            entity.Property(e => e.Sotienrut)
                .HasPrecision(18, 2)
                .HasColumnName("sotienrut");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
