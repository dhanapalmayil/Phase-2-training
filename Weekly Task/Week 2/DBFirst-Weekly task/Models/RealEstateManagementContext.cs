using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBFirst_Weekly_task.Models;

public partial class RealEstateManagementContext : DbContext
{
    public RealEstateManagementContext()
    {
    }

    public RealEstateManagementContext(DbContextOptions<RealEstateManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Transaction> Transactions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=PTSQLTESTDB01;database=Real_Estate_Management;integrated security=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("PK__Properti__70C9A755D8069D8D");

            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.Address).HasMaxLength(255);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Description).HasMaxLength(1000);
            entity.Property(e => e.ImagePath).HasMaxLength(255);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
            entity.Property(e => e.Title).HasMaxLength(100);
            entity.Property(e => e.ZipCode).HasMaxLength(20);
        });

        modelBuilder.Entity<Transaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Transact__55433A4B7F93093D");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.ClientId).HasColumnName("ClientID");
            entity.Property(e => e.PropertyId).HasColumnName("PropertyID");
            entity.Property(e => e.TransactionDate).HasColumnType("datetime");
            entity.Property(e => e.TransactionType).HasMaxLength(50);

            entity.HasOne(d => d.Property).WithMany(p => p.Transactions)
                .HasForeignKey(d => d.PropertyId)
                .HasConstraintName("FK__Transacti__Prope__4BAC3F29");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC8E50ECDF");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.UserType).HasMaxLength(10);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
