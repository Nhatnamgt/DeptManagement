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
        modelBuilder
            .HasPostgresEnum("auth", "aal_level", new[] { "aal1", "aal2", "aal3" })
            .HasPostgresEnum("auth", "code_challenge_method", new[] { "s256", "plain" })
            .HasPostgresEnum("auth", "factor_status", new[] { "unverified", "verified" })
            .HasPostgresEnum("auth", "factor_type", new[] { "totp", "webauthn", "phone" })
            .HasPostgresEnum("auth", "oauth_authorization_status", new[] { "pending", "approved", "denied", "expired" })
            .HasPostgresEnum("auth", "oauth_client_type", new[] { "public", "confidential" })
            .HasPostgresEnum("auth", "oauth_registration_type", new[] { "dynamic", "manual" })
            .HasPostgresEnum("auth", "oauth_response_type", new[] { "code" })
            .HasPostgresEnum("auth", "one_time_token_type", new[] { "confirmation_token", "reauthentication_token", "recovery_token", "email_change_token_new", "email_change_token_current", "phone_change_token" })
            .HasPostgresEnum("realtime", "action", new[] { "INSERT", "UPDATE", "DELETE", "TRUNCATE", "ERROR" })
            .HasPostgresEnum("realtime", "equality_op", new[] { "eq", "neq", "lt", "lte", "gt", "gte", "in", "like", "ilike", "is", "match", "imatch", "isdistinct" })
            .HasPostgresEnum("storage", "buckettype", new[] { "STANDARD", "ANALYTICS", "VECTOR" })
            .HasPostgresExtension("extensions", "pg_stat_statements")
            .HasPostgresExtension("extensions", "pgcrypto")
            .HasPostgresExtension("extensions", "uuid-ossp")
            .HasPostgresExtension("vault", "supabase_vault");

        modelBuilder.Entity<Chitietkhoanvay>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("chitietkhoanvay_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Tongtien).HasComputedColumnSql("(sotienvay + sotienlai)", true);

            entity.HasOne(d => d.Khoanno).WithMany(p => p.Chitietkhoanvays).HasConstraintName("fk_chitietkhoanvay_quanlykhoanno");
        });

        modelBuilder.Entity<Quanlykhoanno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quanlykhoanno_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
        });

        modelBuilder.Entity<Quanlynaprut>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("quanlynaprut_pkey");

            entity.Property(e => e.Id).UseIdentityAlwaysColumn();
            entity.Property(e => e.Lailo).HasComputedColumnSql("(sotienrut - sotiennap)", true);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
