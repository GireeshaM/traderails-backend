using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace traderails_backend_dataAccess.Models;

public partial class StoneflowContext : DbContext
{
    public StoneflowContext()
    {
    }

    public StoneflowContext(DbContextOptions<StoneflowContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankAccount> BankAccounts { get; set; }

    public virtual DbSet<LegalDetail> LegalDetails { get; set; }

    public virtual DbSet<Organization> Organizations { get; set; }

    public virtual DbSet<RefreshToken> RefreshTokens { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=SPRINTPARK\\SQLEXPRESS;Database=stoneflow ;User Id=sa;Password=a;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankAccount>(entity =>
        {
            entity.HasKey(e => e.BankAccountId).HasName("PK__BankAcco__4FC8E4A147370266");

            entity.Property(e => e.AccountNumber).HasMaxLength(50);
            entity.Property(e => e.BankName).HasMaxLength(200);
            entity.Property(e => e.Ifsccode)
                .HasMaxLength(20)
                .HasColumnName("IFSCCode");

            entity.HasOne(d => d.Organization).WithMany(p => p.BankAccounts)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK__BankAccou__Organ__5812160E");
        });

        modelBuilder.Entity<LegalDetail>(entity =>
        {
            entity.HasKey(e => e.LegalDetailId).HasName("PK__LegalDet__03ACE7AE0CCEB37E");

            entity.Property(e => e.CountryOfIncorporation).HasMaxLength(100);
            entity.Property(e => e.LegalName).HasMaxLength(200);
            entity.Property(e => e.RegisteredAddress).HasMaxLength(500);
            entity.Property(e => e.RegisteredNumber).HasMaxLength(100);

            entity.HasOne(d => d.Organization).WithMany(p => p.LegalDetails)
                .HasForeignKey(d => d.OrganizationId)
                .HasConstraintName("FK__LegalDeta__Organ__5535A963");
        });

        modelBuilder.Entity<Organization>(entity =>
        {
            entity.HasKey(e => e.OrganizationId).HasName("PK__Organiza__CADB0B12FD02B4CF");

            entity.Property(e => e.ContactEmail).HasMaxLength(256);
            entity.Property(e => e.ContactPhone).HasMaxLength(20);
            entity.Property(e => e.OrganizationName).HasMaxLength(200);
            entity.Property(e => e.OrganizationType).HasMaxLength(100);
            entity.Property(e => e.TermsAccepted).HasDefaultValue(false);

            entity.HasOne(d => d.User).WithMany(p => p.Organizations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Organizat__UserI__5165187F");
        });

        modelBuilder.Entity<RefreshToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RefreshT__3214EC07FD2BCA1C");

            entity.Property(e => e.ReplacedByTokenHash).HasMaxLength(512);
            entity.Property(e => e.TokenHash).HasMaxLength(512);

            entity.HasOne(d => d.User).WithMany(p => p.RefreshTokens)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RefreshTokens_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1A351A9914");

            entity.Property(e => e.RoleName).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CF9F23D97");

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.EmailAddress).HasMaxLength(256);
            entity.Property(e => e.IsEmailVerified).HasDefaultValue(false);
            entity.Property(e => e.IsPhoneVerified).HasDefaultValue(false);
            entity.Property(e => e.Mfaotp)
                .HasMaxLength(10)
                .HasColumnName("MFAOtp");
            entity.Property(e => e.PasswordHash).HasMaxLength(512);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.PhoneOtp).HasMaxLength(10);
            entity.Property(e => e.PhoneVerificationMethod).HasMaxLength(10);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleId__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
